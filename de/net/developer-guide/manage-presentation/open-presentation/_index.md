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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in C# öffnen, Öffnungspasswörter bereitstellen, das Laden von Ressourcen steuern und mit Aspose.Slides für .NET den Speicherverbrauch reduzieren."
---
## **Einführung**

[Aspose.Slides für .NET](https://products.aspose.com/slides/de/net/) kann PowerPoint‑ und OpenDocument‑Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie deren Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im ursprünglichen oder einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/) angepasst werden. Beispielsweise können Sie ein Öffnungspasswort angeben, große Binärobjekte außerhalb des verwalteten Speichers halten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihren Dateipfad dem Konstruktor von [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/). Entsorgen Sie das Presentation‑Objekt nach der Verwendung, damit Dateihandles, temporäre Daten und andere Ressourcen zeitnah freigegeben werden.

Das folgende C#‑Beispiel zeigt, wie eine Präsentation geöffnet und die Folienanzahl ermittelt wird:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Passwortgeschützte Präsentationen öffnen**

Ein Öffnungspasswort verschlüsselt den Präsentationsinhalt. Um die komplette Präsentation zu laden, setzen Sie das korrekte Passwort auf [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/) und übergeben die Optionen dem Konstruktor von [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/). Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Zum Erkennen, Validieren und Verschlüsseln von Passwörtern siehe [Password-Protect Presentations](/slides/de/net/password-protected-presentation/). Wenn eine verschlüsselte Präsentation absichtlich mit öffentlichen Dokumenteneigenschaften gespeichert wurde, können diese ohne Passwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/net/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/blobmanagementoptions/) steuert, wie Aspose.Slides große Binärobjekte wie Bilder, Audio und Video behandelt. Sie können die Quelldatei gesperrt halten, temporäre Dateien zulassen und die Menge an im Speicher gehaltenen BLOB‑Daten begrenzen.

Der folgende C#‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

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

Mit `PresentationLockingBehavior.KeepLocked` bleibt die Quelldatei gesperrt, bis das `Presentation`‑Objekt entsorgt wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange dieses Objekt lebt.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Für große Präsentationen ist ein Dateipfad daher im Allgemeinen effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/net/manage-blob/) für weitere Speicher‑ und Speicherverwaltungsoptionen.

{{% /alert %}}

## **Externe Ressourcen steuern**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/resourceloadingcallback/) akzeptiert eine Implementierung von [IResourceLoadingCallback](https://reference.aspose.com/slides/de/net/aspose.slides/iresourceloadingcallback/). Der Rückruf kann Ersatzdaten bereitstellen, eine Ressource umleiten, den Standard‑Lader verwenden oder die Ressource überspringen. Dies ist nützlich, wenn Präsentationen externe Bilder enthalten, die gemäß anwendungsspezifischer Sicherheits‑ oder Speicherregeln aufgelöst werden müssen.

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

Eine Präsentation kann eingebettete Binärdaten enthalten, die eine Anwendung nicht benötigt oder nicht behalten möchte. Beispiele sind:

- VBA‑Projekte, verfügbar über [IPresentation.VbaProject](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/vbaproject/);
- eingebettete OLE‑Daten, verfügbar über [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/de/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- ActiveX‑Steuerungsdaten, verfügbar über [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/de/net/aspose.slides/icontrol/activexcontrolbinary/).

Setzen Sie [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) auf `true`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu behalten.

Diese Option reduziert die Exposition gegenüber unerwünschten eingebetteten Payloads, stellt jedoch kein vollständiges Malware‑Erkennungs‑ oder Inhalts‑Sanitisierungssystem dar.

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

**Wie kann ich erkennen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Aspose.Slides wirft beim Laden eine Parsing‑ oder Format‑Ausnahme. Behandeln Sie diesen Fehler separat von einem falschen Passwort‑Fehler, damit die Anwendung die Ursache genau melden kann.

**Was passiert, wenn erforderliche Schriftarten fehlen?**

Die Präsentation kann weiterhin geladen werden, aber beim Rendern und Exportieren können Schriftarten substituiert werden. Sie können die [Schriftart‑Substitution konfigurieren](/slides/de/net/font-substitution/) oder [benutzerdefinierte Schriftarten bereitstellen](/slides/de/net/custom-font/), um die Ausgabe vorhersagbarer zu machen.

**Wird beim Laden einer Präsentation auch deren eingebettete Medien geladen?**

Eingebettete Audio‑ und Videodaten werden über das Präsentations‑Objektmodell verfügbar. Externe Ressourcen werden gemäß dem konfigurierten Ressourcen‑Ladeverhalten aufgelöst und können nicht verfügbar sein, wenn ihre Orte nicht zugänglich sind.