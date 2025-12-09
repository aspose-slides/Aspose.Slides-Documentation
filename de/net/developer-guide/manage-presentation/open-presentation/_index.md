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
description: "PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos öffnen mit Aspose.Slides für .NET – schnell, zuverlässig, vollständig ausgestattet."
---

## **Übersicht**

Über das Erstellen von PowerPoint‑Präsentationen von Grund auf hinaus ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nach dem Laden einer Präsentation können Sie Informationen darüber abrufen, Folieninhalte bearbeiten, neue Folien hinzufügen, vorhandene entfernen und vieles mehr.

## **Präsentationen öffnen**

Um eine bestehende Präsentation zu öffnen, erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und übergeben den Dateipfad an deren Konstruktor.

Das folgende C#‑Beispiel zeigt, wie man eine Präsentation öffnet und die Folienanzahl ermittelt:
```cs
// Instanziieren Sie die Presentation-Klasse und übergeben Sie ihr einen Dateipfad im Konstruktor.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Geben Sie die Gesamtzahl der Folien in der Präsentation aus.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, geben Sie das Passwort über die Eigenschaft [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) der Klasse [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) an, um sie zu entschlüsseln und zu laden. Der folgende C#‑Code demonstriert diesen Vorgang:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Vorgänge an der entschlüsselten Präsentation ausführen.
}
```


## **Große Präsentationen öffnen**

Aspose.Slides bietet Optionen – insbesondere die Eigenschaft [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) in der Klasse [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) – um das Laden großer Präsentationen zu unterstützen.

Der folgende C#‑Code zeigt das Laden einer großen Präsentation (zum Beispiel 2 GB):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Wählen Sie das KeepLocked‑Verhalten — die Präsentationsdatei bleibt für die Lebensdauer der 
        // Präsentationsinstanz gesperrt, muss jedoch nicht in den Speicher geladen oder in eine temporäre Datei kopiert werden.
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

    // Die Präsentation in eine andere Datei speichern. Der Speicherverbrauch bleibt während dieses Vorgangs gering.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nicht tun! Es wird eine I/O‑Ausnahme ausgelöst, weil die Datei gesperrt ist, bis das Präsentationsobjekt freigegeben wird.
    File.Delete(filePath);
}

// Hier ist es in Ordnung. Die Quelldatei ist nicht mehr durch das Präsentationsobjekt gesperrt.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}

Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird, was das Laden verlangsamen kann. Daher empfehlen wir dringend, bei großen Präsentationen den Dateipfad der Präsentation anstelle eines Streams zu verwenden.

Wenn Sie eine Präsentation erstellen, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie [BLOB‑Management](/slides/de/net/manage-blob/) verwenden, um den Speicherverbrauch zu reduzieren.

{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt das Interface [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) bereit, mit dem Sie externe Ressourcen verwalten können. Der folgende C#‑Code zeigt, wie das `IResourceLoadingCallback`‑Interface verwendet wird:
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

        // Überspringe alle anderen Bilder.
        return ResourceLoadingAction.Skip;
    }
}
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint‑Präsentation kann die folgenden Arten eingebetteter Binärobjekte enthalten:

- VBA‑Projekt (zugänglich über [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- OLE‑Objekt‑eingebettete Daten (zugänglich über [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

Mit der Eigenschaft [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) können Sie eine Präsentation ohne eingebettete Binärobjekte laden.

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

**Wie erkenne ich, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Beim Laden erhalten Sie eine Parsing‑/Formatvalidierungs‑Ausnahme. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Datensätze.

**Was passiert, wenn beim Öffnen erforderliche Schriften fehlen?**

Die Datei wird geöffnet, aber beim anschließenden [Rendering/Export](/slides/de/net/convert-presentation/) können Schriften substituiert werden. [Schrift‑Substitutionen konfigurieren](/slides/de/net/font-substitution/) oder die erforderlichen Schriften [zur Laufzeitumgebung hinzufügen](/slides/de/net/custom-font/).

**Wie werden eingebettete Medien (Video/Audio) beim Öffnen behandelt?**

Sie werden als Präsentations‑Ressourcen verfügbar. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung zugänglich sind; andernfalls können beim [Rendering/Export](/slides/de/net/convert-presentation/) die Medien weggelassen werden.