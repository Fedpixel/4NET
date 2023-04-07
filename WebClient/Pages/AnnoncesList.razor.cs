using ApiModels;
using System.Net.Http.Json;

namespace WebClient.Pages
{
    public partial class AnnonceList
    {
    public enum PopupMode
    {
        Closed,
        Rename,
        Duplicate,
        Create,
    }

    public class AnnonceModel
    {
        public string AnnonceName { get; set; }
    }

    public PopupMode Mode { get; set; }

    private string SaveButtonTitle
    {
        get
        {
            return Mode switch
            {
                PopupMode.Rename => "Rename",
                PopupMode.Duplicate => "Duplicate",
                PopupMode.Create => "Create",
                _ => ""
                };
        }
    }

    private string PopupTitle
    {
        get
        {
            return Mode switch
            {
                PopupMode.Rename => "Renaming annonce: " + _oldAnnonceName,
                PopupMode.Duplicate => "Duplicating annonce: " + _oldAnnonceName,
                PopupMode.Create => "Creation annonce",
                _ => ""
            };
        }
    }


    public string ModalDisplay => Mode!=PopupMode.Closed ? "block" : "none";
    
    private string _oldAnnonceName;

    public AnnonceModel Annonce { get;} = new AnnonceModel();

    private List<AnnoncesHeaderModel>? _annonces;

    protected override async Task OnInitializedAsync()
    {
        _annonces = await HttpClient.GetFromJsonAsync<List<AnnoncesHeaderModel>>("/api/Annonces");
    }

    public void OpenRecipe(string AnnonceName,int annonceVersion)
    {
        NavigationManager.NavigateTo("/annoncedetail/"+Uri.EscapeDataString(AnnonceName)+"/"+annonceVersion);
    }

    public void OpenRenamePopup(string oldAnnonceName)
    {
        _oldAnnonceName = oldAnnonceName;
        Annonce.AnnonceName=oldAnnonceName;
        Mode = PopupMode.Rename;
    }
    
    public void OpenDuplicationPopup(string oldAnnonceName)
    {
        _oldAnnonceName = oldAnnonceName;
        Annonce.AnnonceName = oldAnnonceName;
        Mode = PopupMode.Duplicate;
    }

    public void OpenCreatePopup()
    {
        Annonce.AnnonceName = "";
        Mode = PopupMode.Create;
    }

    public void CloseModal()
    {
        Mode = PopupMode.Closed;
    }

    private async void OnSave()
    {
        switch (Mode)
        {
            case PopupMode.Rename:
                await Rename();
                break;
            case PopupMode.Duplicate:
                await Duplicate();
                break;
            case PopupMode.Create:
                await Create();
                break;
        }

        Mode = PopupMode.Closed;
        this.StateHasChanged();
    }

    private async Task Duplicate()
    {

        await HttpClient.PostAsJsonAsync("/api/Annonce/duplicate/" +
                                        Uri.EscapeDataString(_oldAnnonceName),Annonce.AnnonceName);

        _annonces = await HttpClient.GetFromJsonAsync<List<AnnoncesHeaderModel>>("/api/Annonce");

    }
    
    private async Task Create()
    {

        await HttpClient.PostAsJsonAsync("/api/Annonce",Annonce.AnnonceName);

        _annonces = await HttpClient.GetFromJsonAsync<List<AnnoncesHeaderModel>>("/api/Annonce");

    }

    private async Task Rename()
    {
        if (_oldAnnonceName == Annonce.AnnonceName)
        {
            return;
            
        }

        await HttpClient.PutAsJsonAsync("/api/Annonce/" + 
                                  Uri.EscapeDataString(_oldAnnonceName),Annonce.AnnonceName);

        _annonces = await HttpClient.GetFromJsonAsync<List<AnnoncesHeaderModel>>("/api/Annonce");

    }
    
    private async Task CreateNewVersion(string AnnonceName)
    {
        await HttpClient.PostAsJsonAsync("/api/Annonce/createnewversion/", AnnonceName);

        _annonces = await HttpClient.GetFromJsonAsync<List<AnnoncesHeaderModel>>("/api/Annonce");
    }
    
    private async Task DeleteLastVersion(string AnnonceName)
    {
        await HttpClient.DeleteAsync("/api/Annonce/lastversion/"+ 
                                     Uri.EscapeDataString(AnnonceName));

        _annonces = await HttpClient.GetFromJsonAsync<List<AnnoncesHeaderModel>>("/api/Annonce");
    }
    private async Task DeleteAllVersions(string AnnonceName)
    {
        await HttpClient.DeleteAsync("/api/Annonce/allversions/"+
        Uri.EscapeDataString(AnnonceName));

        _annonces = await HttpClient.GetFromJsonAsync<List<AnnoncesHeaderModel>>("/api/Annonce");
    }
    }
}
