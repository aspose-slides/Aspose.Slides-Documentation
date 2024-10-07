---
title: Präsentation in C# Öffnen
linktitle: Präsentation Öffnen
type: docs
weight: 20
url: /net/open-presentation/
keywords: "PowerPoint Öffnen, PPTX, PPT, Präsentation Öffnen, Präsentation Laden, C#, Csharp, .NET"
description: "Öffnen oder Laden der Präsentation PPT, PPTX, ODP in C# oder .NET"
---

Neben der Erstellung von PowerPoint-Präsentationen von Grund auf ermöglicht es Aspose.Slides, bestehende Präsentationen zu öffnen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen über die Präsentation abrufen, die Präsentation bearbeiten (Inhalt auf ihren Folien), neue Folien hinzufügen oder bestehende entfernen usw.

## Präsentation Öffnen

Um eine vorhandene Präsentation zu öffnen, müssen Sie einfach die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse instanziieren und den Dateipfad (zur Präsentation, die Sie öffnen möchten) an ihren Konstruktor übergeben.

Dieser C#-Code zeigt Ihnen, wie Sie eine Präsentation öffnen und auch die Anzahl der Folien darin herausfinden können:

```c#
// Instanziiert die Presentation-Klasse und übergibt den Dateipfad an ihren Konstruktor
Presentation pres = new Presentation("OpenPresentation.pptx");

// Gibt die Gesamtzahl der Folien in der Präsentation aus
System.Console.WriteLine(pres.Slides.Count.ToString());
```

## **Passwortgeschützte Präsentation Öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, können Sie das Passwort über die [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) Eigenschaft (aus der [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) Klasse) übergeben, um die Präsentation zu entschlüsseln und zu laden. Dieser C#-Code demonstriert den Vorgang:

```c#
	LoadOptions loadOptions = new LoadOptions {Password = "DEIN_PASSWORT"};
	using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
	{
	  // Aufgaben mit der entschlüsselten Präsentation ausführen
	}
```

## Große Präsentation Öffnen

Aspose.Slides bietet Optionen (insbesondere die [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) Eigenschaft) unter der [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) Klasse, um Ihnen das Laden großer Präsentationen zu ermöglichen.

Dieser C#-Code demonstriert einen Vorgang, bei dem eine große Präsentation (sagen wir 2 GB groß) geladen wird:

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // Wählen wir das KeepLocked-Verhalten - die "veryLargePresentation.pptx" wird für
        // die Lebensdauer der Präsentationsinstanz gesperrt, aber wir müssen sie nicht in den Speicher laden oder
        // in die temporäre Datei kopieren
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // Die große Präsentation wurde geladen und kann verwendet werden, aber der Speicherverbrauch bleibt niedrig.

    // Änderungen an der Präsentation vornehmen.
    pres.Slides[0].Name = "Sehr große Präsentation";

    // Die Präsentation wird in die andere Datei gespeichert. Der Speicherverbrauch bleibt während des Vorgangs niedrig
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // Das ist nicht möglich! Eine IO-Ausnahme wird ausgelöst, da die Datei gesperrt ist, während pres-Objekte
    // nicht freigegeben werden
    File.Delete(pathToVeryLargePresentationFile);
}

// Es ist in Ordnung, dies hier zu tun, die Quelldatei wird nicht vom pres-Objekt gesperrt
File.Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Info" %}}

Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt dazu, dass die Inhalte der Präsentation kopiert werden, was zu langsamen Ladezeiten führt. Daher empfehlen wir Ihnen dringend, beim Laden einer großen Präsentation den Präsentationsdateipfad und nicht ihren Stream zu verwenden.

Wenn Sie eine Präsentation erstellen möchten, die große Objekte (Video, Audio, große Bilder usw.) enthält, können Sie die [Blob-Funktion](https://docs.aspose.com/slides/net/manage-blob/) verwenden, um den Speicherverbrauch zu reduzieren.

{{%/alert %}}

## Präsentation Laden
Aspose.Slides bietet [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) mit einer einzigen Methode, die es Ihnen ermöglicht, externe Ressourcen zu verwalten. Dieser C#-Code zeigt Ihnen, wie Sie das `IResourceLoadingCallback`-Interface verwenden:

```c#
LoadOptions opts = new LoadOptions();
opts.ResourceLoadingCallback = new ImageLoadingHandler();
Presentation presentation = new Presentation("presentation.pptx", opts);
```

```c#
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try // Lädt das Ersatzbild
            {
                byte[] imageBytes = File.ReadAllBytes("c:\\aspose-logo.jpg");
                args.SetData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Setzt die Ersatz-URL
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Überspringt alle anderen Bilder
        return ResourceLoadingAction.Skip;
    }
}
```

## Präsentation ohne Eingebettete Binäre Objekte Laden

Die PowerPoint-Präsentation kann die folgenden Arten von eingebetteten binären Objekten enthalten:

- VBA-Projekt ([IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- OLE-Objekt eingebettete Daten ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX-Steuerung binäre Daten ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/));

Mit der [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) Eigenschaft können Sie die Präsentation ohne eingebettete binäre Objekte laden.

Diese Eigenschaft kann nützlich sein, um potenziell schädliche binäre Inhalte zu entfernen.

Der C#-Code demonstriert, wie Sie eine Präsentation ohne Malware-Inhalte laden und speichern:

```c#
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (var pres = new Presentation("malware.ppt", loadOptions))
{
    pres.Save("clean.ppt", SaveFormat.Ppt);
}
```

<h2>Präsentation Öffnen und Speichern</h2>

<a name="csharp-open-save-presentation"><strong>Schritte: Präsentation in C# Öffnen und Speichern</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse und übergeben Sie die Datei, die Sie öffnen möchten.
2. Speichern Sie die Präsentation.

```c#
// Lade eine unterstützte Präsentation, z.B. ppt, pptx, odp
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```