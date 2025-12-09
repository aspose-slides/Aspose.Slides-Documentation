---
title: Integration von Aspose.Slides mit Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /de/net/integrating-aspose-slides-with-google-slides/
keywords:
- Cloud-Plattformen
- Cloud-Integration
- Google Slides
- Google Drive
- Google API
- Google Servicekonto
- SaaS-Integration
- OAuth 2.0
- PPT zu PDF
- PowerPoint-Automatisierung
- Präsentationsverarbeitung
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Verbinden Sie Aspose.Slides mit Google Slides, um Präsentationen zu importieren, zu synchronisieren und zu konvertieren, Workflows zu automatisieren und PowerPoint sowie OpenDocument in einer Pipeline zu behalten."
---

# Integration von Aspose.Slides in Google Slides

Aspose.Slides bietet jetzt eine Integration mit Google Slides und Google Drive über die [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). Diese Integration ermöglicht .NET‑Apps das Konvertieren, Bearbeiten, Herunterladen und Hochladen von Google Slides‑Präsentationen.

## Was ist Google Slides?
[Google Slides](https://workspace.google.com/products/slides/) ist eine kostenlose, webbasierte Präsentationssoftware von Google. Sie ermöglicht es Benutzern, Präsentationen online zu erstellen, zu bearbeiten und zu teilen, ähnlich wie Microsoft PowerPoint. Sie unterstützt Echtzeit‑Zusammenarbeit, Cloud‑Speicherung und funktioniert auf jedem Gerät mit Internetzugang.

## Google‑API
Bevor Sie über Aspose.Slides mit Ihrer Google Slides‑Präsentation arbeiten, müssen Sie ein Google‑API‑Projekt erstellen und ein [Google Cloud‑Projekt](https://developers.google.com/workspace/guides/create-project) anlegen, dann die gewünschten APIs aktivieren.

Anschließend wählen Sie, wie Sie auf die Google‑API zugreifen möchten – [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) unterstützt zwei Zugriffswege:
- `Google Service Account`
- `OAuth 2.0` mit Benutzerinteraktion über einen Browser.

### Google Service Account
Ein Service‑Account ist ein spezielles Google‑Konto, das von Anwendungen oder Servern verwendet wird, um Google‑APIs programmgesteuert ohne Benutzerinteraktion zu nutzen. Er wird häufig für Backend‑Systeme oder automatisierte Aufgaben eingesetzt. Service‑Accounts werden über eine JSON‑Schlüsseldatei authentifiziert und besitzen eine eigene E‑Mail‑Adresse. Sie können über [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) mit spezifischen Berechtigungen versehen werden und werden oft mit APIs wie Google Drive, Sheets oder BigQuery für sicheren, automatisierten Zugriff auf Ressourcen verwendet.

### OAuth 2.0
Eine weitere gängige Methode, auf Google‑APIs zuzugreifen, ist OAuth 2.0 mit Benutzerinteraktion über einen Browser. In diesem Ablauf wird der Benutzer auf eine Google‑Anmeldeseite weitergeleitet, wo er der Anwendung die Erlaubnis erteilt. Nach der Genehmigung erhält die Anwendung einen Autorisierungscode, den sie gegen ein Zugriffstoken und ein Refresh‑Token eintauscht.

Das Zugriffstoken ermöglicht temporären Zugriff auf Google‑APIs, während das Refresh‑Token gespeichert und wiederverwendet werden kann, um neue Zugriffstoken zu erhalten, ohne dass sich der Benutzer erneut anmelden muss. Das bedeutet, die Browser‑Interaktion ist nur einmal erforderlich; nachfolgende API‑Aufrufe können vollständig automatisiert werden. Diese Methode wird typischerweise für Apps verwendet, die auf Benutzerdaten (z. B. Gmail, Kalender oder Drive) mit Zustimmung des Benutzers zugreifen müssen.

## Let's code
Fügen Sie zunächst das [Aspose.Slides SaaS Integration NuGet‑Paket](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) zu Ihrem Projekt hinzu:
```
dotnet add package Aspose.Slides.SaaSIntegrations
```


### Beispiel 1
Im folgenden Beispiel laden wir eine Google Slides‑Präsentation aus Google Drive herunter und speichern sie lokal als PDF‑Datei. Wir verwenden einen Google Service Account zur Authentifizierung, wobei angenommen wird, dass die Service‑Account‑JSON‑Datei bereits heruntergeladen wurde.
```csharp
// Erstelle extern verwalteten HttpClient
HttpClient httpClient = new HttpClient();

// Create an authorization provider using a service account JSON file
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Initialize Google Slides integration service with the authorization provider
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Load a presentation from Google Drive by its file ID into an Aspose.Slides IPresentation instance
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Modify the presentation if needed (e.g., remove the second slide)
pres.Slides.RemoveAt(1);

// Save the presentation locally as a PDF file
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```


Zur Vereinfachung stellt Aspose.Slides SaaS Integration eine Methode bereit, um alle dem Benutzer verfügbaren Dateien aufzulisten. Die zurückgegebenen Daten enthalten Dateiname, MIME‑Typ und Datei‑ID.
```csharp
// Holen Sie die Liste der für das angegebene Servicekonto verfügbaren Dateien
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```


Eine weitere Möglichkeit, die Datei‑ID zu ermitteln, besteht darin, die Präsentation in der Google Slides‑Web‑App zu öffnen und sie in der URL zu finden.

Zum Beispiel in der folgenden URL:
```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```


Die Datei‑ID lautet:
```
1A2B3C4D5E6F7G8H9I0J
```


## Beispiel 2
Im nächsten Beispiel erstellen wir eine PowerPoint‑Präsentation von Grund auf und laden sie im Google Slides‑Format zu Google Drive hoch. Zur Authentifizierung verwenden wir OAuth 2.0.
```csharp
// Erstelle extern verwalteten HttpClient
HttpClient httpClient = new HttpClient();

// Erstelle einen Autorisierungsanbieter mit OAuth unter Verwendung von Client-ID und Client-Secret
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Initialisiere den Google Slides-Integrationsservice mit dem Autorisierungsanbieter
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Erstelle eine Beispielpräsentation
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Speichere die Präsentation im Stammordner von Google Drive im Google Slides-Format
    // Du kannst auch ein anderes von Aspose.Slides unterstütztes Exportformat wählen
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```


Wenn Sie diese Art der Authentifizierung in Ihrer App verwenden, ist `interaction with the browser is required`. Sie müssen Ihr Konto auswählen und bestätigen, dass Sie der App den Zugriff auf Ihre Google Drive‑API erlauben. Das ist alles – dieser Vorgang ist nur beim ersten Ausführen erforderlich.

### Beispiel 3
Im folgenden Beispiel verwenden wir ein bereits erhaltendes Zugriffstoken. `GoogleAccessTokenAuthProvider` ist eine Implementierung des `IGoogleAuthorizationProvider`‑Interfaces, die ein vorhandenes OAuth 2.0‑Zugriffstoken nutzt, um Anfragen an Google‑APIs zu autorisieren. Im Gegensatz zu Providern, die den OAuth‑Ablauf initiieren oder verwalten, verlässt sich diese Klasse darauf, dass der Aufrufer ein gültiges Zugriffstoken bereitstellt.

Dieser Provider ist nützlich in Systemen, in denen das Zugriffstoken extern beschafft wird – typischerweise von einer Front‑End‑Anwendung oder einem anderen Service – und an das Backend übergeben wird. Er eignet sich besonders für verteilte Umgebungen, in denen die Verwaltung von Refresh‑Tokens auf der Serverseite Komplexität oder das Risiko von Token‑Ungültigkeit durch gleichzeitige Aktualisierungsversuche mit sich bringt.

Dieses Beispiel zeigt, wie man eine Datei ersetzt und ihren Namen auf Google Drive aktualisiert, während die Datei‑ID erhalten bleibt.
```csharp
// Erstelle einen HTTP-Client zum Ausführen von Anfragen
using HttpClient httpClient = new HttpClient();

// Richte die Google Drive-Authentifizierung mit einem Zugriffstoken ein
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Initialisiere die Integration mit Google Slides/Drive unter Verwendung der Authentifizierung und des HTTP-Clients
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Erstelle eine Beispielpräsentation mit Aspose.Slides
using (var presentation = new Presentation())
{
    // Füge der ersten Folie ein Rechteck-Shape hinzu und setze dessen Text
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Definiere PDF-Speicheroptionen mit spezifischer Qualität und Konformitätseinstellungen
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Speichere (ersetze) die vorhandene Datei auf Google Drive anhand der Datei-ID, aktualisiere ihren Namen und exportiere sie als PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID der vorhandenen Datei auf Google Drive
        GoogleSaveFormatType.Pdf,         // Gewünschtes Format zum Speichern
        saveOptions,           
        "NewFileName.pdf"                 // Neuer Name, der der Datei zugewiesen wird
    );
}
```


## Zusammenfassung
Aspose.Slides unterstützt nun ein zusätzliches Dateiformat für die Verwaltung, wodurch die Automatisierung cloud‑basierter Workflows zum Erstellen, Teilen und Bearbeiten von Präsentationen vereinfacht wird.

Dieser Artikel behandelte die Grundfunktionen. Sie können Dateien auch in Unterordnern speichern, vorhandene Dateien ersetzen und in verschiedenen Formaten zu Google Drive exportieren – nicht nur als Google Slides‑Präsentationen.

Aspose.Slides SaaS Integration wird die Unterstützung für Präsentations‑SaaS‑Plattformen weiter ausbauen, also schauen Sie bald wieder für zukünftige Updates vorbei.

## FAQ

**Q: Benötige ich ein Google Workspace‑Konto, um diese Integration zu nutzen?**  
Nein. Sie können entweder ein kostenloses Google‑Konto oder ein Google Workspace‑Konto verwenden. Der erforderliche Zugriff hängt von Ihren Google Drive‑ und Slides‑Berechtigungen ab.

**Q: Welche Authentifizierungsmethode sollte ich wählen – Service Account oder OAuth 2.0?**  
Verwenden Sie ein **Service Account** für Backend‑ oder automatisierte Workflows ohne Benutzerinteraktion.  
Verwenden Sie **OAuth 2.0**, wenn Sie auf die Google Slides‑ oder Drive‑Dateien eines bestimmten Benutzers mit dessen Zustimmung zugreifen müssen.

**Q: Kann ich mit anderen Formaten als Google Slides arbeiten?**  
Ja. Aspose.Slides ermöglicht das Speichern von Präsentationen in verschiedenen Formaten (z. B. PDF, PPTX, HTML), bevor sie zu Google Drive hochgeladen werden.

**Q: Wie erhalte ich die Datei‑ID einer Google Slides‑Präsentation?**  
Sie können sie über die Methode `GetDriveFileInfosAsync()` abrufen oder sie aus der URL der Präsentation in Google Slides kopieren.

**Q: Unterstützt die Integration das Ersetzen einer bereits vorhandenen Datei auf Google Drive?**  
Ja. Verwenden Sie die Methode `SavePresentationToExistingFileAsync`, um eine Datei zu aktualisieren und dabei die Datei‑ID beizubehalten.

**Q: Ist bei OAuth 2.0 jedes Mal eine Browser‑Interaktion erforderlich?**  
Nein. Die Browser‑Interaktion ist nur bei der ersten Autorisierung nötig. Danach ermöglichen gespeicherte Refresh‑Tokens einen automatisierten Zugriff.