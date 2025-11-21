---
title: Präsentationen in .NET öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/net/open-presentation/
keywords:
- PowerPoint öffnen
- Präsentation öffnen
- PPTX öffnen
- PPT öffnen
- ODP öffnen
- Präsentation laden
- PPTX laden
- PPT laden
- ODP laden
- geschützte Präsentation
- große Präsentation
- externe Ressource
- Binärobjekt
- .NET
- C#
- Aspose.Slides
description: "Öffnen Sie PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für .NET – schnell, zuverlässig, voll ausgestattet."
---

## **Übersicht**

Neben dem Erstellen von PowerPoint‑Präsentationen von Grund auf ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nach dem Laden einer Präsentation können Sie Informationen darüber abrufen, Folieninhalte bearbeiten, neue Folien hinzufügen, vorhandene entfernen und mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse und übergeben dem Konstruktor den Dateipfad.

Das folgende C#‑Beispiel zeigt, wie man eine Präsentation öffnet und deren Folienanzahl abruft:
```cs
// Instanziieren Sie die Presentation-Klasse und übergeben Sie einen Dateipfad an ihren Konstruktor.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Gibt die Gesamtzahl der Folien in der Präsentation aus.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, übergeben Sie das Passwort über die [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) Eigenschaft der [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) Klasse, um sie zu entschlüsseln und zu laden. Der folgende C#‑Code demonstriert diesen Vorgang:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Operationen an der entschlüsselten Präsentation durchführen.
}
```


## **Große Präsentationen öffnen**

Aspose.Slides stellt Optionen bereit – insbesondere die [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) Eigenschaft in der [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) Klasse – um Ihnen beim Laden großer Präsentationen zu helfen.

Der folgende C#‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Wählen Sie das KeepLocked‑Verhalten – die Präsentationsdatei bleibt für die gesamte Lebensdauer der 
        // Presentation‑Instanz, muss jedoch nicht in den Speicher geladen oder in eine temporäre Datei kopiert werden.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Die große Präsentation wurde geladen und kann verwendet werden, während der Speicherverbrauch niedrig bleibt.

    // Änderungen an der Präsentation vornehmen.
    presentation.Slides[0].Name = "Large presentation";

    // Die Präsentation in einer anderen Datei speichern. Der Speicherverbrauch bleibt während dieses Vorgangs niedrig.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nicht tun! Es wird eine I/O‑Ausnahme ausgelöst, weil die Datei gesperrt ist, bis das Präsentationsobjekt freigegeben wird.
    File.Delete(filePath);
}

// Hier ist es in Ordnung. Die Quelldatei ist nicht mehr durch das Präsentationsobjekt gesperrt.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}

Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream bewirkt, dass die Präsentation kopiert wird und kann das Laden verlangsamen. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation anstelle eines Streams zu verwenden.

Wenn Sie eine Präsentation erstellen, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie das [BLOB‑Management](/slides/de/net/manage-blob/) nutzen, um den Speicherverbrauch zu reduzieren.

{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt die [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) Schnittstelle bereit, mit der Sie externe Ressourcen verwalten können. Der folgende C#‑Code zeigt, wie man die `IResourceLoadingCallback`‑Schnittstelle verwendet:
```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Lade ein Ersatzbild.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Setze eine Ersatz-URL.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Alle anderen Bilder überspringen.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint‑Präsentation kann die folgenden Arten eingebetteter Binärobjekte enthalten:

- VBA‑Projekt (zugänglich über [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- eingebettete OLE‑Objektdaten (zugänglich über [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

Mit der [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) Eigenschaft können Sie eine Präsentation ohne eingebettete Binärobjekte laden.

Diese Eigenschaft ist nützlich, um potenziell schädliche Binärinhalte zu entfernen. Der folgende C#‑Code demonstriert, wie man eine Präsentation ohne eingebettete Binärinhalte lädt:
```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Vorgänge an der Präsentation ausführen.
}
```


## **FAQ**

**Wie kann ich feststellen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Beim Laden erhalten Sie eine Parsing‑/Formatvalidierungs‑Ausnahme. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Datensätze.

**Was passiert, wenn beim Öffnen erforderliche Schriftarten fehlen?**

Die Datei wird geöffnet, jedoch kann die spätere [Rendern/Export](/slides/de/net/convert-presentation/) Schriftarten ersetzen. [Konfigurieren Sie Schriftarten‑Ersetzungen](/slides/de/net/font-substitution/) oder [fügen Sie die erforderlichen Schriftarten](/slides/de/net/custom-font/) zur Laufzeitumgebung hinzu.

**Was ist mit eingebetteten Medien (Video/Audio) beim Öffnen?**

Sie werden als Präsentations‑Ressourcen verfügbar. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung zugänglich sind; andernfalls kann das [Rendern/Export](/slides/de/net/convert-presentation/) die Medien weglassen.