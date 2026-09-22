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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in C# öffnen, Öffnungspasswörter angeben, das Laden von Ressourcen steuern und den Speicherverbrauch mit Aspose.Slides für .NET reduzieren."
---
## **Einleitung**

[Aspose.Slides for .NET](https://products.aspose.com/slides/de/net/) kann PowerPoint- und OpenDocument-Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie ihre Struktur prüfen, Folien bearbeiten, Ressourcen verwalten und sie im ursprünglichen oder in einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/) angepasst werden. Beispielsweise können Sie ein Öffnungspasswort angeben, große Binärobjekte außerhalb des verwalteten Speichers halten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Nach dem Laden einer Datei oder eines Streams können Sie [das ursprüngliche Präsentationsformat ermitteln](/slides/de/net/detect-presentation-source-format/), um zu entscheiden, wie Ihre Anwendung sie verarbeitet.

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihren Dateipfad an den Konstruktor von [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/). Entsorgen Sie das Presentation-Objekt nach Gebrauch, damit Dateihandles, temporäre Daten und andere Ressourcen zügig freigegeben werden.

Das folgende C#-Beispiel zeigt, wie man eine Präsentation öffnet und die Folienzahl ermittelt:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Passwortgeschützte Präsentationen öffnen**

Ein Öffnungspasswort verschlüsselt den Präsentationsinhalt. Um die gesamte Präsentation zu laden, weisen Sie das korrekte Passwort [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/) zu und übergeben Sie die Optionen an den [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Konstruktor. Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Für Passworterkennung, -validierung und -verschlüsselungs-Workflows siehe [Password-Protect Presentations](/slides/de/net/password-protected-presentation/). Wenn eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteneigenschaften gespeichert wurde, können diese Eigenschaften ohne Passwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/net/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/blobmanagementoptions/) steuert, wie Aspose.Slides große Binärobjekte wie Bilder, Audio und Video behandelt. Sie können die Quelldatei gesperrt lassen, temporäre Dateien zulassen und die Menge an BLOB-Daten, die im Speicher gehalten wird, begrenzen.

Der folgende C#-Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Hinweis" %}}

Mit `PresentationLockingBehavior.KeepLocked` bleibt die Quelldatei gesperrt, bis das `Presentation`-Objekt freigegeben wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange das Objekt aktiv ist.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Für große Präsentationen ist ein Dateipfad daher in der Regel effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/net/manage-blob/) für weitere Speicher- und Speicherverwaltungsoptionen.

{{% /alert %}}

## **Externe Ressourcen steuern**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/resourceloadingcallback/) akzeptiert eine Implementierung von [IResourceLoadingCallback](https://reference.aspose.com/slides/de/net/aspose.slides/iresourceloadingcallback/). Der Callback kann Ersatzdaten bereitstellen, eine Ressource umleiten, den Standard-Lader verwenden oder die Ressource ueberspringen. Dies ist nützlich, wenn Präsentationen externe Bilder enthalten, die gemessen an anwendungsspezifischen Sicherheits- oder Speicherregeln aufgeloest werden muessen.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine Präsentation kann eingebettete Binärdaten enthalten, die eine Anwendung nicht benoetigt oder nicht behalten moechte. Beispiele:

- VBA-Projekte, verfuegbar ueber [IPresentation.VbaProject](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/vbaproject/);
- eingebettete OLE-Daten, verfuegbar ueber [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/de/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- ActiveX-Steuerungsdaten, verfuegbar ueber [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/de/net/aspose.slides/icontrol/activexcontrolbinary/).

Setzen Sie [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) auf `true`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu erhalten.

Diese Option reduziert die Gefahr unerwuenschter eingebetteter Payloads, stellt jedoch kein vollstaendiges Malware-Erkennungs- oder Inhalts-Sanitaersystem dar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Wie kann ich feststellen, dass eine Datei beschädigt ist und nicht geoeffnet werden kann?**

Aspose.Slides wirft beim Laden eine Parsing- oder Format-Ausnahme. Behandeln Sie diesen Fehler separat von einem falschen Passwort-Fehler, damit die Anwendung die Ursache korrekt melden kann.

**Was passiert, wenn erforderliche Schriften fehlen?**

Die Präsentation kann dennoch geladen werden, aber Rendering und Export koennen Schriften substituieren. Sie können [die Schriftart-Substitution konfigurieren](/slides/de/net/font-substitution/) oder [benutzerdefinierte Schriften bereitstellen](/slides/de/net/custom-font/), um das Ausgabeergebnis vorhersehbarer zu machen.

**Wird beim Laden einer Präsentation auch deren eingebettete Medien geladen?**

Eingebettete Audio- und Videodaten werden ueber das Praesentation-Objektmodell verfuegbar. Externe Ressourcen werden gemaess dem konfigurierten Ressourcen-Ladeverhalten aufgeloest und koennen nicht verfuegbar sein, wenn ihre Speicherorte nicht erreichbar sind.