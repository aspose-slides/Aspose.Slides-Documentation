---
title: Integrera Aspose.Slides med Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /sv/net/integrating-aspose-slides-with-google-slides/
keywords:
- molnplattformar
- molnintegration
- Google Slides
- Google Drive
- Google API
- Google Service Account
- SaaS-integration
- OAuth 2.0
- PPT to PDF
- PowerPoint-automatisering
- presentationbearbetning
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Anslut Aspose.Slides till Google Slides för att importera, synkronisera och konvertera presentationer, automatisera arbetsflöden och hålla PowerPoint och OpenDocument i samma pipeline."
---
## **Introduktion**

Aspose.Slides erbjuder nu integration med Google Slides och Google Drive via sitt [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). Denna integration möjliggör för .NET‑appar att konvertera, redigera, ladda ner och ladda upp Google Slides‑presentationer.

## **Vad är Google Slides?**
[Google Slides](https://workspace.google.com/products/slides/sv/) är en gratis, webbaserad presentationsprogramvara utvecklad av Google. Den låter användare skapa, redigera och dela bildpresentationer online, på liknande sätt som Microsoft PowerPoint. Den stöder samarbete i realtid, molnlagring och fungerar på vilken enhet som helst med internetåtkomst.

## **Google API**
Innan du börjar arbeta med din Google Slides‑presentation via Aspose.Slides måste du skapa ett Google API‑projekt och skapa ett [Google Cloud‑projekt](https://developers.google.com/workspace/guides/create-project), sedan aktivera de önskade API:erna. 

Sedan måste du välja ett sätt att komma åt Google API – [Aspose.SlideS Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) stöder två sätt att komma åt Google API: 
- `Google Service Account`
- `OAuth 2.0` med användarinteraktion via en webbläsare.

### **Google Service Account**
Ett service‑konto är ett speciellt Google‑konto som används av applikationer eller servrar för att programatiskt komma åt Google API:er utan användarinteraktion. Det används vanligtvis för bakgrundssystem eller automatiserade uppgifter. Service‑konton autentiseras med en JSON‑nyckelfil och har sin egen e‑postadress. De kan tilldelas specifika behörigheter via [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) och används ofta med API:er som Google Drive, Sheets eller BigQuery för säker, automatiserad åtkomst till resurser.

### **OAuth 2.0**
Ett annat vanligt sätt att komma åt Google API:er är via OAuth 2.0 med användarinteraktion via en webbläsare. I detta flöde omdirigeras användaren till en Google‑inloggningssida där de ger appen behörighet. Efter godkännande får appen en auktoriseringskod som den byter mot en åtkomsttoken och en refresh‑token.

Åtkomsttokenen ger tillfällig åtkomst till Google API:er, medan refresh‑tokenen kan lagras och återanvändas för att erhålla nya åtkomsttoken utan att användaren måste logga in igen. Detta betyder att webbläsarinteraktionen endast krävs en gång, vilket gör efterföljande API‑åtkomst helt automatiserad. Denna metod används typiskt för appar som behöver komma åt en användares data (som Gmail, Calendar eller Drive) med användarens samtycke.

## **Låt oss koda**
Först, lägg till [Aspose.Slides SaaS Integration NuGet package](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) i ditt projekt:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **Exempel 1**
I följande exempel kommer vi att ladda ner en Google Slides‑presentation från Google Drive och spara den på den lokala disken som en PDF‑fil. Vi kommer att använda ett Google Service Account för auktorisation, under förutsättning att service‑konto‑JSON‑filen med autentiseringsuppgifter redan har laddats ner.

```csharp
// Skapa externt hanterad HttpClient
HttpClient httpClient = new HttpClient();

// Skapa en auktoriseringsleverantör med en servicekontos JSON-fil
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Initiera Google Slides-integrationsservice med auktoriseringsleverantören
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Ladda en presentation från Google Drive med dess fil-ID till en Aspose.Slides IPresentation-instans
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Ändra presentationen vid behov (t.ex. ta bort den andra bilden)
pres.Slides.RemoveAt(1);

// Spara presentationen lokalt som en PDF-fil
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

För enkelhetens skull tillhandahåller Aspose.Slides SaaS Integration en metod för att lista alla filer som är tillgängliga för användaren. Den returnerade datan innehåller filnamn, MIME‑typ och fil‑ID.

```csharp
// Hämta listan över filer som är tillgängliga för det angivna servicekontot
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

Ett annat sätt att hitta fil‑ID är att öppna presentationen i Google Slides‑webbappen och lokalisera den i URL‑adressen.

Till exempel, i följande URL:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

Fil‑ID är:

```
1A2B3C4D5E6F7G8H9I0J
```

## **Exempel 2**
I nästa exempel kommer vi att skapa en PowerPoint‑presentation från början och ladda upp den till Google Drive i Google Slides‑format. För auktorisation kommer vi att använda OAuth 2.0.

```csharp
// Skapa externt hanterad HttpClient
HttpClient httpClient = new HttpClient();

// Skapa en auktoriseringsleverantör med OAuth med klient‑ID och klienthemlighet
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Initiera Google Slides‑integrationsservice med auktoriseringsleverantören
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Skapa en exempelpresentation
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Spara presentationen till Google Drives rotmapp i Google Slides‑format
    // Du kan också välja något annat exportformat som stöds av Aspose.Slides
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```

Om du använder den här typen av auktorisation i din app, `interaction with the browser is required`. Du måste välja ditt konto och bekräfta att du tillåter appen att komma åt ditt Google Drive‑API. Det är allt—denna operation krävs bara vid första körningen.

### **Exempel 3**
I följande exempel använder vi en förhandsinhämtad åtkomsttoken. `GoogleAccessTokenAuthProvider` är en implementation av `IGoogleAuthorizationProvider`‑gränssnittet som använder en befintlig OAuth 2.0‑åtkomsttoken för att auktorisera förfrågningar till Google API:er. Till skillnad från leverantörer som initierar eller hanterar OAuth‑flödet, förlitar sig denna klass på att anroparen tillhandahåller en giltig åtkomsttoken.

Denna leverantör är användbar i system där åtkomsttoken erhålls externt—vanligtvis av en frontend‑applikation eller en annan tjänst—och skickas till backend. Den är särskilt lämplig för distribuerade miljöer där hantering av refresh‑token på serversidan inför komplexitet eller risk för token‑ogiltighet på grund av samtidiga refresh‑försök.

Detta exempel visar hur man ersätter en fil och uppdaterar dess namn på Google Drive samtidigt som fil‑ID bevaras.

```csharp
// Skapa en HTTP client för att göra förfrågningar
using HttpClient httpClient = new HttpClient();

// Ställ in Google Drive autentisering med en åtkomsttoken
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Initiera integration med Google Slides/Drive med autentiseringen och HTTP client
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Skapa en exempelpresentation med Aspose.Slides
using (var presentation = new Presentation())
{
    // Lägg till en rektangelshape på den första bilden och sätt dess text
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Definiera PDF-sparalternativ med specifik kvalitet och efterlevnadsinställningar
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Spara (ersätt) den befintliga filen på Google Drive med fil ID, uppdatera dess namn och exportera som PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID för den befintliga filen på Google Drive
        GoogleSaveFormatType.Pdf,         // Önskat format att spara som
        saveOptions,           
        "NewFileName.pdf"                 // Nytt namn att tilldela filen
    );
}
```

## **Sammanfattning**
Aspose.Slides stödjer nu ett extra filformat för hantering, vilket förenklar automatiseringen av molnbaserade arbetsflöden för att skapa, dela och redigera presentationer.

Denna artikel täckte grundfunktionerna. Du kan också spara filer i underkataloger, ersätta befintliga filer och exportera till Google Drive i olika format—inte begränsat till Google Slides‑presentationer.

Aspose.Slides SaaS Integration kommer fortsätta att utöka stödet för presentation‑SaaS‑plattformar, så håll utkik efter framtida uppdateringar.

## **FAQ**

**Behöver jag ett Google Workspace‑konto för att använda denna integration?**  
Nej. Du kan använda antingen ett gratis Google‑konto eller ett Google Workspace‑konto. Den nödvändiga åtkomsten beror på dina Google Drive‑ och Slides‑behörigheter.

**Vilken autentiseringsmetod bör jag välja—Service Account eller OAuth 2.0?**  
Använd ett **Service Account** för backend‑ eller automatiserade arbetsflöden utan användarinteraktion.  
Använd **OAuth 2.0** om du behöver komma åt en specifik användares Google Slides‑ eller Drive‑filer med deras samtycke.

**Kan jag arbeta med andra format än Google Slides?**  
Ja. Aspose.Slides låter dig spara presentationer till olika format (t.ex. PDF, PPTX, HTML) innan du laddar upp dem till Google Drive.

**Hur kan jag få fil‑ID för en Google Slides‑presentation?**  
Du kan hämta den med metoden `GetDriveFileInfosAsync()` eller genom att kopiera den från presentationens URL i Google Slides.

**Stöder integrationen att ersätta en befintlig fil på Google Drive?**  
Ja. Använd metoden `SavePresentationToExistingFileAsync` för att uppdatera en fil samtidigt som fil‑ID bevaras.

**Krävs webbläsarinteraktion varje gång när man använder OAuth 2.0?**  
Nej. Webbläsarinteraktion krävs endast vid första auktorisationen. Därefter möjliggör lagrade refresh‑token automatiserad åtkomst.