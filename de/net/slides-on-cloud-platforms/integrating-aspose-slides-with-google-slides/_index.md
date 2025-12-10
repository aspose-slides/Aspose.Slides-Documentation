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
description: "Verbinden Sie Aspose.Slides mit Google Slides, um Präsentationen zu importieren, zu synchronisieren und zu konvertieren, Workflows zu automatisieren und PowerPoint sowie OpenDocument in einer einzigen Pipeline zu nutzen."
---

## **Einführung**

Aspose.Slides bietet jetzt die Integration mit Google Slides und Google Drive über seine [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). Diese Integration ermöglicht .NET‑Anwendungen das Konvertieren, Bearbeiten, Herunterladen und Hochladen von Google Slides‑Präsentationen.

## **Was ist Google Slides?**

[Google Slides](https://workspace.google.com/products/slides/) ist eine kostenlose, webbasierte Präsentationssoftware von Google. Sie ermöglicht Benutzern das Erstellen, Bearbeiten und Teilen von Folienpräsentationen online, ähnlich wie Microsoft PowerPoint. Sie unterstützt Echtzeit‑Zusammenarbeit, Cloud‑Speicher und funktioniert auf jedem Gerät mit Internetzugang.

## **Google API**

Bevor Sie mit Ihrer Google Slides‑Präsentation über Aspose.Slides arbeiten, müssen Sie ein Google API‑Projekt erstellen und ein [Google Cloud‑Projekt](https://developers.google.com/workspace/guides/create-project) anlegen, dann die gewünschten APIs aktivieren.

Anschließend müssen Sie entscheiden, wie Sie auf die Google API zugreifen – [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) unterstützt zwei Zugriffsmethoden:
- `Google Service Account`
- `OAuth 2.0` mit Benutzerinteraktion über einen Browser.

### **Google Servicekonto**

Ein Servicekonto ist ein spezielles Google‑Konto, das von Anwendungen oder Servern verwendet wird, um programmgesteuert ohne Benutzerinteraktion auf Google APIs zuzugreifen. Es wird häufig für Backend‑Systeme oder automatisierte Aufgaben eingesetzt. Servicekonten werden über eine JSON‑Schlüsseldatei authentifiziert und besitzen eine eigene E‑Mail‑Adresse. Sie können über [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) spezifische Berechtigungen erhalten und werden oft mit APIs wie Google Drive, Sheets oder BigQuery für sicheren, automatisierten Zugriff auf Ressourcen verwendet.

### **OAuth 2.0**

Eine weitere verbreitete Methode, um auf Google APIs zuzugreifen, ist OAuth 2.0 mit Benutzerinteraktion über einen Browser. In diesem Ablauf wird der Benutzer zu einer Google‑Anmeldeseite weitergeleitet, wo er der Anwendung die erforderlichen Berechtigungen erteilt. Nach der Genehmigung erhält die Anwendung einen Autorisierungscode, den sie gegen ein Zugangstoken und ein Aktualisierungstoken austauscht.

Das Zugangstoken ermöglicht temporären Zugriff auf Google APIs, während das Aktualisierungstoken gespeichert und wiederverwendet werden kann, um neue Zugangstoken zu erhalten, ohne dass sich der Benutzer erneut anmelden muss. Das bedeutet, die Browser‑Interaktion ist nur einmalig erforderlich, sodass nachfolgende API‑Aufrufe vollständig automatisiert ablaufen können. Diese Methode wird typischerweise für Anwendungen verwendet, die auf die Daten eines Benutzers (wie Gmail, Kalender oder Drive) mit dessen Zustimmung zugreifen müssen.

## **Loslegen**

Zuerst fügen Sie das [Aspose.Slides SaaS Integration NuGet‑Paket](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) zu Ihrem Projekt hinzu:
```
dotnet add package Aspose.Slides.SaaSIntegrations
```


### **Beispiel 1**

Im folgenden Beispiel laden wir eine Google Slides‑Präsentation von Google Drive herunter und speichern sie lokal als PDF‑Datei. Wir verwenden ein Google Servicekonto für die Authentifizierung, wobei angenommen wird, dass die JSON‑Datei mit den Anmeldeinformationen bereits heruntergeladen wurde.
```csharp
// Extern verwalteten HttpClient erstellen
HttpClient httpClient = new HttpClient();

// Einen Autorisierungsanbieter mit einer Servicekonto-JSON-Datei erstellen
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Google Slides-Integrationsdienst mit dem Autorisierungsanbieter initialisieren
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Eine Präsentation aus Google Drive anhand ihrer Datei-ID in eine Aspose.Slides IPresentation-Instanz laden
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Die Präsentation bei Bedarf ändern (z. B. die zweite Folie entfernen)
pres.Slides.RemoveAt(1);

// Die Präsentation lokal als PDF-Datei speichern
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```


Für Komfort stellt Aspose.Slides SaaS Integration eine Methode bereit, um alle dem Benutzer zur Verfügung stehenden Dateien aufzulisten. Die zurückgegebenen Daten enthalten Dateinamen, MIME‑Typ und Datei‑ID.
```csharp
// Liste der dem bereitgestellten Servicekonto verfügbaren Dateien abrufen
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```


Eine weitere Möglichkeit, die Datei‑ID zu finden, besteht darin, die Präsentation in der Google Slides‑Web‑App zu öffnen und sie in der URL zu suchen.

Zum Beispiel in der folgenden URL:
```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```


Die Datei‑ID ist:
```
1A2B3C4D5E6F7G8H9I0J
```


## **Beispiel 2**

Im nächsten Beispiel erstellen wir von Grund auf eine PowerPoint‑Präsentation und laden sie im Google Slides‑Format zu Google Drive hoch. Für die Authentifizierung verwenden wir OAuth 2.0.
```csharp
// Extern verwalteten HttpClient erstellen
HttpClient httpClient = new HttpClient();

// Einen Autorisierungsanbieter mit OAuth, Client-ID und Client-Secret erstellen
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Google Slides-Integrationsdienst mit dem Autorisierungsanbieter initialisieren
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Create a sample presentation
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Präsentation im Stammordner von Google Drive im Google Slides-Format speichern
    // Sie können auch ein anderes von Aspose.Slides unterstütztes Exportformat wählen
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```


Wenn Sie diese Art der Authentifizierung in Ihrer Anwendung verwenden, `interaction with the browser is required`. Sie müssen Ihr Konto auswählen und bestätigen, dass Sie der Anwendung den Zugriff auf Ihre Google Drive‑API erlauben. Das ist alles – dieser Vorgang ist nur beim ersten Start nötig.

### **Beispiel 3**

Im folgenden Beispiel verwenden wir ein bereits erhaltenes Zugangstoken. `GoogleAccessTokenAuthProvider` ist eine Implementierung des `IGoogleAuthorizationProvider`‑Interfaces, das ein vorhandenes OAuth 2.0‑Zugangstoken nutzt, um Anfragen an Google APIs zu autorisieren. Im Gegensatz zu Anbietern, die den OAuth‑Ablauf initiieren oder verwalten, verlässt sich diese Klasse darauf, dass der Aufrufer ein gültiges Zugangstoken liefert.

Dieser Provider ist nützlich in Systemen, in denen das Zugangstoken extern bezogen wird – typischerweise von einer Front‑End‑Anwendung oder einem anderen Service – und an das Backend weitergegeben wird. Er ist besonders geeignet für verteilte Umgebungen, in denen die Verwaltung von Aktualisierungstoken auf Server‑Seite Komplexität oder das Risiko von Token‑Ungültigkeit durch gleichzeitige Aktualisierungsversuche mit sich bringt.

Dieses Beispiel zeigt, wie man eine Datei ersetzt und ihren Namen auf Google Drive aktualisiert, wobei die Datei‑ID beibehalten wird.
```csharp
// HTTP-Client zum Senden von Anfragen erstellen
using HttpClient httpClient = new HttpClient();

// Google Drive-Authentifizierung mit einem Zugriffstoken einrichten
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Integration mit Google Slides/Drive über Authentifizierung und HTTP-Client initialisieren
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Create a sample presentation using Aspose.Slides
using (var presentation = new Presentation())
{
    // Rechteckform zur ersten Folie hinzufügen und deren Text festlegen
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // PDF-Speicheroptionen mit spezifischer Qualität und Konformitätseinstellungen definieren
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Vorhandene Datei auf Google Drive per Datei-ID speichern (ersetzen), Namen aktualisieren und als PDF exportieren
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID der bestehenden Datei auf Google Drive
        GoogleSaveFormatType.Pdf,         // Gewünschtes Zielformat
        saveOptions,           
        "NewFileName.pdf"                 // Neuer Name, der der Datei zugewiesen wird
    );
}
```


## **Zusammenfassung**

Aspose.Slides unterstützt nun ein zusätzliches Dateiformat zur Verwaltung, wodurch die Automatisierung cloud‑basierter Workflows für das Erstellen, Teilen und Bearbeiten von Präsentationen vereinfacht wird.

Dieser Artikel behandelte die Grundfunktionen. Sie können Dateien auch in Unterordnern speichern, vorhandene Dateien ersetzen und in verschiedenen Formaten zu Google Drive exportieren – nicht nur als Google Slides‑Präsentationen.

Aspose.Slides SaaS Integration wird die Unterstützung für Präsentations‑SaaS‑Plattformen weiter ausbauen. Schauen Sie also später wieder vorbei für zukünftige Updates.

## **FAQ**

**Benötige ich ein Google Workspace‑Konto, um diese Integration zu nutzen?**  
Nein. Sie können entweder ein kostenloses Google‑Konto oder ein Google Workspace‑Konto verwenden. Der erforderliche Zugriff hängt von Ihren Google Drive‑ und Slides‑Berechtigungen ab.

**Welche Authentifizierungsmethode sollte ich wählen – Servicekonto oder OAuth 2.0?**  
Verwenden Sie ein **Servicekonto** für Backend‑ oder automatisierte Workflows ohne Benutzerinteraktion.  
Verwenden Sie **OAuth 2.0**, wenn Sie auf die Google Slides‑ oder Drive‑Dateien eines bestimmten Benutzers mit dessen Zustimmung zugreifen müssen.

**Kann ich mit Formaten arbeiten, die nicht Google Slides sind?**  
Ja. Aspose.Slides ermöglicht das Speichern von Präsentationen in verschiedenen Formaten (z. B. PDF, PPTX, HTML), bevor sie zu Google Drive hochgeladen werden.

**Wie kann ich die Datei‑ID einer Google Slides‑Präsentation erhalten?**  
Sie können sie über die Methode `GetDriveFileInfosAsync()` ermitteln oder sie aus der URL der Präsentation in Google Slides kopieren.

**Unterstützt die Integration das Ersetzen einer bestehenden Datei auf Google Drive?**  
Ja. Verwenden Sie die Methode `SavePresentationToExistingFileAsync`, um eine Datei zu aktualisieren und dabei ihre Datei‑ID beizubehalten.

**Ist bei OAuth 2.0 bei jeder Nutzung eine Browser‑Interaktion erforderlich?**  
Nein. Die Browser‑Interaktion ist nur bei der ersten Autorisierung nötig. Anschließend ermöglichen gespeicherte Aktualisierungstoken einen automatisierten Zugriff.