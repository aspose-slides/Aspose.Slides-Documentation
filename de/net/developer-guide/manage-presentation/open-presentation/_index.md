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
description: "Öffnen Sie PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für .NET—schnell, zuverlässig, vollständig ausgestattet."
---

## **Übersicht**

Neben dem Erstellen von PowerPoint‑Präsentationen von Grund auf ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen darüber abrufen, Folieninhalte bearbeiten, neue Folien hinzufügen, vorhandene entfernen und vieles mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse und übergeben ihr den Dateipfad im Konstruktor.

Das folgende C#‑Beispiel zeigt, wie man eine Präsentation öffnet und die Folienanzahl ermittelt:
```cs
// Instanziieren Sie die Presentation-Klasse und übergeben Sie einen Dateipfad an ihren Konstruktor.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Geben Sie die Gesamtzahl der Folien in der Präsentation aus.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, übergeben Sie das Passwort über die [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/)‑Eigenschaft der [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)‑Klasse, um sie zu entschlüsseln und zu laden. Der folgende C#‑Code demonstriert diesen Vorgang:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Vorgänge an der entschlüsselten Präsentation ausführen.
}
```


## **Große Präsentationen öffnen**

Aspose.Slides bietet Optionen – insbesondere die [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/)‑Eigenschaft in der [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)‑Klasse – um große Präsentationen zu laden.

Der folgende C#‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Wählen Sie das KeepLocked-Verhalten – die Präsentationsdatei bleibt für die gesamte Lebensdauer von 
        // der Presentation-Instanz, muss jedoch nicht in den Speicher geladen oder in eine temporäre Datei kopiert werden.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Die große Präsentation wurde geladen und kann verwendet werden, während der Speicherverbrauch gering bleibt.

    // Änderungen an der Präsentation vornehmen.
    presentation.Slides[0].Name = "Large presentation";

    // Speichern Sie die Präsentation in eine andere Datei. Der Speicherverbrauch bleibt während dieses Vorgangs gering.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Machen Sie das nicht! Es wird eine I/O‑Ausnahme ausgelöst, weil die Datei gesperrt ist, bis das Präsentationsobjekt freigegeben wird.
    File.Delete(filePath);
}

// Hier ist es in Ordnung, dies zu tun. Die Quelldatei ist nicht mehr durch das Präsentationsobjekt gesperrt.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird und das Laden verlangsamen kann. Daher empfehlen wir, beim Laden einer großen Präsentation den Dateipfad der Präsentation anstelle eines Streams zu verwenden.

Wenn Sie eine Präsentation erstellen, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie das [BLOB‑Management](/slides/de/net/manage-blob/) nutzen, um den Speicherverbrauch zu reduzieren.
{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt das [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/)‑Interface zur Verfügung, mit dem Sie externe Ressourcen verwalten können. Der folgende C#‑Code zeigt, wie das `IResourceLoadingCallback`‑Interface verwendet wird:
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
                // Ein Ersatzbild laden.
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
            // Eine Ersatz-URL setzen.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Alle anderen Bilder überspringen.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint‑Präsentation kann die folgenden Arten von eingebetteten Binärobjekten enthalten:

- VBA‑Projekt (zugänglich über [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- OLE‑Objekt‑eingebettete Daten (zugänglich über [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

Mit der [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/)‑Eigenschaft können Sie eine Präsentation ohne jegliche eingebettete Binärobjekte laden.

Diese Eigenschaft ist nützlich, um potenziell schädliche Binärinhalte zu entfernen. Das folgende C#‑Beispiel demonstriert das Laden einer Präsentation ohne eingebettete Binärinhalte:
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

**Wie erkenne ich, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Während des Ladens erhalten Sie eine Parsing‑/Format‑Validierungs‑Ausnahme. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Datensätze.

**Was passiert, wenn beim Öffnen erforderliche Schriftarten fehlen?**

Die Datei wird geöffnet, aber späteres [Rendern/Exportieren](/slides/de/net/convert-presentation/) kann Schriftarten substituieren. [Schriftart‑Substitutionen konfigurieren](/slides/de/net/font-substitution/) oder [die erforderlichen Schriftarten hinzufügen](/slides/de/net/custom-font/) in der Laufzeitumgebung.

**Wie wird mit eingebetteten Medien (Video/Audio) beim Öffnen umgegangen?**

Sie stehen als Präsentationsressourcen zur Verfügung. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung zugänglich sind; andernfalls kann das [Rendern/Exportieren](/slides/de/net/convert-presentation/) die Medien weglassen.