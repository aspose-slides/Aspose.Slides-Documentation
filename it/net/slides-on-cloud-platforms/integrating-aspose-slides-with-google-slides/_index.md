---
title: Integrazione di Aspose.Slides con Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /it/net/integrating-aspose-slides-with-google-slides/
keywords:
- piattaforme cloud
- integrazione cloud
- Google Slides
- Google Drive
- Google API
- Account di servizio Google
- integrazione SaaS
- OAuth 2.0
- PPT in PDF
- automazione PowerPoint
- elaborazione di presentazioni
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Collega Aspose.Slides a Google Slides per importare, sincronizzare e convertire le presentazioni, automatizzare i flussi di lavoro e mantenere PowerPoint e OpenDocument in un unico processo."
---
## **Introduzione**

Aspose.Slides ora offre integrazione con Google Slides e Google Drive tramite la sua [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). Questa integrazione consente alle app .NET di convertire, modificare, scaricare e caricare presentazioni Google Slides.

## **Cos'è Google Slides?**
[Google Slides](https://workspace.google.com/products/slides/it/) è un software di presentazione gratuito basato sul web sviluppato da Google. Consente agli utenti di creare, modificare e condividere presentazioni diapositive online, in modo simile a Microsoft PowerPoint. Supporta la collaborazione in tempo reale, l'archiviazione cloud e funziona su qualsiasi dispositivo con accesso a Internet.

## **Google API**
Prima di iniziare a lavorare con la tua presentazione Google Slides tramite Aspose.Slides devi creare un progetto Google API e creare un [Google Cloud project](https://developers.google.com/workspace/guides/create-project), quindi abilitare le API desiderate.

Successivamente devi scegliere il modo in cui accedere a Google API: [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) supporta due modalità di accesso a Google API:
- `Google Service Account`
- `OAuth 2.0` con interazione dell'utente tramite un browser.

### **Account di servizio Google**
Un account di servizio è un account Google speciale utilizzato da applicazioni o server per accedere programmaticamente alle Google API senza interazione dell'utente. È comunemente usato per sistemi backend o attività automatizzate. Gli account di servizio vengono autenticati tramite un file chiave JSON e hanno un proprio indirizzo email. Possono essere assegnati permessi specifici tramite [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) e sono spesso usati con API come Google Drive, Sheets o BigQuery per un accesso sicuro e automatizzato alle risorse.

### **OAuth 2.0**
Un altro metodo comune per accedere alle Google API è tramite OAuth 2.0 con interazione dell'utente tramite un browser. In questo flusso l'utente viene reindirizzato a una pagina di accesso Google dove concede l'autorizzazione all'app. Dopo l'approvazione, l'app riceve un codice di autorizzazione, che scambia per un token di accesso e un token di aggiornamento.

Il token di accesso consente l'accesso temporaneo alle Google API, mentre il token di aggiornamento può essere memorizzato e riutilizzato per ottenere nuovi token di accesso senza richiedere nuovamente il login all'utente. Ciò significa che l'interazione con il browser è necessaria solo una volta, rendendo gli accessi API successivi completamente automatizzati. Questo metodo è tipicamente usato per app che devono accedere ai dati di un utente (come Gmail, Calendar o Drive) con il consenso dell'utente.

## **Scriviamo del codice**
Per prima cosa, aggiungi il [Aspose.Slides SaaS Integration NuGet package](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) al tuo progetto:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **Example 1**
Nell'esempio seguente scaricheremo una presentazione Google Slides da Google Drive e la salveremo sul disco locale come file PDF. Utilizzeremo un Account di servizio Google per l'autorizzazione, presumendo che il file JSON dell'account di servizio con le credenziali sia già stato scaricato.

```csharp
// Crea HttpClient gestito esternamente
HttpClient httpClient = new HttpClient();

// Crea un provider di autorizzazione utilizzando un file JSON dell'account di servizio
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Inizializza il servizio di integrazione Google Slides con il provider di autorizzazione
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Carica una presentazione da Google Drive tramite il suo ID file in un'istanza IPresentation di Aspose.Slides
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Modifica la presentazione se necessario (ad es., rimuovi la seconda diapositiva)
pres.Slides.RemoveAt(1);

// Salva la presentazione localmente come file PDF
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

Per comodità, Aspose.Slides SaaS Integration fornisce un metodo per elencare tutti i file disponibili per l'utente. I dati restituiti includono il nome del file, il tipo MIME e l'ID del file.

```csharp
// Ottieni l'elenco dei file disponibili per l'account di servizio fornito
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

Un altro modo per trovare l'ID del file è aprire la presentazione nell'app web Google Slides e individuarlo nell'URL.

Ad esempio, nell'URL seguente:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

L'ID del file è:

```
1A2B3C4D5E6F7G8H9I0J
```

## **Example 2**
Nel prossimo esempio creeremo una presentazione PowerPoint da zero e la caricheremo su Google Drive in formato Google Slides. Per l'autorizzazione utilizzeremo OAuth 2.0.

```csharp
// Crea HttpClient gestito esternamente
HttpClient httpClient = new HttpClient();

// Crea un provider di autorizzazione utilizzando OAuth con client ID e client secret
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Inizializza il servizio di integrazione Google Slides con il provider di autorizzazione
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Crea una presentazione di esempio
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Salva la presentazione nella cartella radice di Google Drive in formato Google Slides
    // Puoi anche scegliere qualsiasi altro formato di esportazione supportato da Aspose.Slides
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

Se usi questo tipo di autorizzazione nella tua app, `interaction with the browser is required`. Dovrai selezionare il tuo account e confermare che consenti all'app di accedere alla tua Google Drive API. Questo è tutto: l'operazione è richiesta solo al primo avvio.

### **Example 3**
Nel seguente esempio utilizzeremo un token di accesso pre‑ottenuto. `GoogleAccessTokenAuthProvider` è un'implementazione dell'interfaccia `IGoogleAuthorizationProvider` che usa un token di accesso OAuth 2.0 esistente per autorizzare le richieste alle Google API. A differenza dei provider che avviano o gestiscono il flusso OAuth, questa classe si affida al chiamante per fornire un token di accesso valido.

Questo provider è utile in sistemi in cui il token di accesso viene ottenuto esternamente—tipicamente da un'applicazione frontend o da un altro servizio—e passato al backend. È particolarmente adatto per ambienti distribuiti dove la gestione dei token di aggiornamento lato server introduce complessità o rischi di invalidazione del token a causa di tentativi di aggiornamento concorrenti.

Questo esempio dimostra come sostituire un file e aggiornare il suo nome su Google Drive mantenendo invariato il suo ID file.

```csharp
// Crea un client HTTP per effettuare richieste
using HttpClient httpClient = new HttpClient();

// Configura l'autenticazione di Google Drive utilizzando un token di accesso
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Inizializza l'integrazione con Google Slides/Drive usando l'autenticazione e il client HTTP
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Crea una presentazione di esempio usando Aspose.Slides
using (var presentation = new Presentation())
{
    // Aggiungi una forma rettangolare alla prima diapositiva e imposta il suo testo
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Definisci le opzioni di salvataggio PDF con impostazioni specifiche di qualità e conformità
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Salva (sostituisci) il file esistente su Google Drive mediante ID file, aggiorna il suo nome ed esporta come PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID del file esistente su Google Drive
        GoogleSaveFormatType.Pdf,         // Formato desiderato per il salvataggio
        saveOptions,           
        "NewFileName.pdf"                 // Nuovo nome da assegnare al file
    );
}
```

## **Riepilogo**
Aspose.Slides ora supporta un formato file aggiuntivo per la gestione, semplificando l'automazione dei flussi di lavoro basati sul cloud per la creazione, la condivisione e la modifica delle presentazioni.

Questo articolo ha coperto le funzionalità di base. È inoltre possibile salvare i file in sotto‑cartelle, sostituire file esistenti ed esportare su Google Drive in vari formati—non limitati alle sole presentazioni Google Slides.

Aspose.Slides SaaS Integration continuerà a espandere il supporto per le piattaforme SaaS di presentazione, quindi torna a controllare per futuri aggiornamenti.

## **FAQ**

**È necessario un account Google Workspace per utilizzare questa integrazione?**  
No. Puoi utilizzare sia un account Google gratuito sia un account Google Workspace. L'accesso richiesto dipende dalle autorizzazioni di Google Drive e Slides.

**Quale metodo di autenticazione devo scegliere—Account di servizio o OAuth 2.0?**  
Utilizza un **Account di servizio** per flussi di lavoro backend o automatizzati senza interazione dell'utente.  
Utilizza **OAuth 2.0** se devi accedere ai file Google Slides o Drive di un utente specifico con il suo consenso.

**Posso lavorare con formati diversi da Google Slides?**  
Sì. Aspose.Slides consente di salvare le presentazioni in vari formati (ad es., PDF, PPTX, HTML) prima di caricarle su Google Drive.

**Come posso ottenere l'ID file di una presentazione Google Slides?**  
Puoi recuperarlo usando il metodo `GetDriveFileInfosAsync()` o copiandolo dall'URL della presentazione in Google Slides.

**L'integrazione supporta la sostituzione di un file esistente su Google Drive?**  
Sì. Usa il metodo `SavePresentationToExistingFileAsync` per aggiornare un file mantenendo invariato il suo ID file.

**È necessaria l'interazione del browser ogni volta quando si utilizza OAuth 2.0?**  
No. L'interazione del browser è richiesta solo durante la prima autorizzazione. Successivamente, i token di aggiornamento memorizzati consentono l'accesso automatizzato.