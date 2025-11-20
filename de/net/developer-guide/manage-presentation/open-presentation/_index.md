---
title: Öffnen einer Präsentation in C#
linktitle: Präsentationen öffnen
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
description: "Öffnen Sie PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für .NET—schnell, zuverlässig, voll funktionsfähig."
---

## **Übersicht**

Über das Erstellen von PowerPoint-Präsentationen von Grund auf hinaus, ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen darüber abrufen, Folieninhalte bearbeiten, neue Folien hinzufügen, bestehende entfernen und vieles mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse und übergeben den Dateipfad an deren Konstruktor.

Das folgende C#-Beispiel zeigt, wie man eine Präsentation öffnet und deren Folienanzahl ermittelt:
```cs
// Instanziieren Sie die Presentation-Klasse und übergeben Sie einen Dateipfad an ihren Konstruktor.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Gibt die Gesamtzahl der Folien in der Präsentation aus.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwordgeschützte Präsentation öffnen müssen, übergeben Sie das Passwort über die [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) Eigenschaft der [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) Klasse, um sie zu entschlüsseln und zu laden. Der folgende C#-Code demonstriert diesen Vorgang:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Vorgänge an der entschlüsselten Präsentation ausführen.
}
```


## **Große Präsentationen öffnen**

Aspose.Slides bietet Optionen – insbesondere die [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) Eigenschaft in der [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) Klasse – um Ihnen beim Laden großer Präsentationen zu helfen.

Der folgende C#-Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Wählen Sie das KeepLocked-Verhalten — die Präsentationsdatei bleibt für die Lebensdauer von 
        // der Presentation-Instanz gesperrt, muss jedoch nicht in den Speicher geladen oder in eine temporäre Datei kopiert werden.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Die große Präsentation wurde geladen und kann verwendet werden, während der Speicherverbrauch niedrig bleibt.

    // Nehmen Sie Änderungen an der Präsentation vor.
    presentation.Slides[0].Name = "Large presentation";

    // Speichern Sie die Präsentation in eine andere Datei. Der Speicherverbrauch bleibt während dieses Vorgangs gering.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nicht tun! Es wird eine I/O-Ausnahme ausgelöst, weil die Datei gesperrt ist, bis das Präsentationsobjekt freigegeben wird.
    File.Delete(filePath);
}

// Es ist hier in Ordnung. Die Quelldatei ist nicht mehr durch das Präsentationsobjekt gesperrt.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird und das Laden verlangsamen kann. Daher empfehlen wir dringend, den Dateipfad der Präsentation anstelle eines Streams zu verwenden, wenn Sie eine große Präsentation laden müssen.

Wenn Sie eine Präsentation erstellen, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie [BLOB management](/slides/de/net/manage-blob/) verwenden, um den Speicherverbrauch zu reduzieren.
{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt die [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) Schnittstelle bereit, mit der Sie externe Ressourcen verwalten können. Der folgende C#-Code zeigt, wie die `IResourceLoadingCallback` Schnittstelle verwendet wird:
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
                // Laden Sie ein Ersatzbild.
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
            // Setzen Sie eine Ersatz-URL.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Alle anderen Bilder überspringen.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint-Präsentation kann die folgenden Arten von eingebetteten Binärobjekten enthalten:

- VBA‑Projekt (zugänglich über [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- OLE‑Objekt‑eingebettete Daten (zugänglich über [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

Mit der [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) Eigenschaft können Sie eine Präsentation ohne eingebettete Binärobjekte laden.

Diese Eigenschaft ist nützlich, um potenziell bösartigen Binärinhalt zu entfernen. Das folgende C#-Code demonstriert, wie man eine Präsentation ohne eingebettete Binärinhalte lädt:
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

Beim Laden erhalten Sie eine Parsing-/Formatvalidierungs‑Ausnahme. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Datensätze.

**Was passiert, wenn beim Öffnen erforderliche Schriftarten fehlen?**

Die Datei wird geöffnet, aber beim anschließenden [rendering/export](/slides/de/net/convert-presentation/) können Schriftarten ersetzt werden. [Configure font substitutions](/slides/de/net/font-substitution/) oder [add the required fonts](/slides/de/net/custom-font/) in die Laufzeitumgebung einbinden.

**Was ist mit eingebetteten Medien (Video/Audio) beim Öffnen?**

Sie stehen als Präsentations‑Ressourcen zur Verfügung. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung zugänglich sind; andernfalls kann [rendering/export](/slides/de/net/convert-presentation/) die Medien weglassen.