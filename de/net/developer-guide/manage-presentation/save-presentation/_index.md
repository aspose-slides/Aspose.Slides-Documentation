---
title: Präsentationen in .NET speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /de/net/save-presentation/
keywords:
- PowerPoint speichern
- OpenDocument speichern
- Präsentation speichern
- Folie speichern
- PPT speichern
- PPTX speichern
- ODP speichern
- Präsentation in Datei
- Präsentation in Stream
- vordefinierter Ansichtstyp
- Strict Office Open XML-Format
- Zip64-Modus
- Thumbnail aktualisieren
- Speicherfortschritt
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen in .NET mit Aspose.Slides speichern – exportieren Sie nach PowerPoint oder OpenDocument und behalten dabei Layouts, Schriftarten und Effekte bei."
---
## **Übersicht**

[Open Presentations in C#](/slides/de/net/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie Präsentationen erstellt und gespeichert werden. Die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, möchten Sie sie nach Abschluss speichern. Mit Aspose.Slides für .NET können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie man mit Aspose.Slides eine Präsentation speichert.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanzieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Führen Sie hier einige Arbeiten aus...

    // Speichern Sie die Präsentation in einer Datei.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanzieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Speichern Sie die Präsentation in den Stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint verwendet, wenn die erzeugte Präsentation über die Klasse [ViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/) geöffnet wird. Setzen Sie die Eigenschaft [LastView](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/lastview/) auf einen Wert aus der Aufzählung [ViewType](https://reference.aspose.com/slides/de/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Präsentationen im Strict Office Open XML-Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die Klasse [PptxOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pptxoptions/) und setzen Sie deren Conformance‑Eigenschaft beim Speichern. Wenn Sie `Conformance.Iso29500_2008_Strict` setzen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instanzieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Speichern Sie die Präsentation im Strict Office Open XML‑Format.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Präsentationen im Office Open XML-Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das 4 GB (2^32 Bytes) Grenzen für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtgröße des Archivs festlegt und das Archiv auf 65 535 (2^16‑1) Dateien begrenzt. ZIP64‑Format-Erweiterungen erhöhen diese Grenzen auf 2^64.

Die Eigenschaft [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipptxoptions/zip64mode/) ermöglicht es Ihnen, zu bestimmen, wann beim Speichern einer Office Open XML‑Datei ZIP64‑Format‑Erweiterungen verwendet werden.

Diese Eigenschaft bietet die folgenden Modi:

- `IfNecessary` verwendet ZIP64‑Format‑Erweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- `Never` verwendet ZIP64‑Format‑Erweiterungen niemals.
- `Always` verwendet ZIP64‑Format‑Erweiterungen immer.

Der folgende Code zeigt, wie man eine Präsentation als PPTX‑Datei mit aktivierten ZIP64‑Format‑Erweiterungen speichert:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="HINWEIS" color="warning" %}}
Wenn Sie mit `Zip64Mode.Never` speichern, wird eine [PptxException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxexception/) ausgelöst, wenn die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen im Office Open XML-Format mit Komprimierungsstufen speichern**

Beim Arbeiten mit großen Präsentationen können Sie die Komprimierungsstufe anpassen, um Dateigröße und Verarbeitungszeit auszubalancieren. Je nach Anforderung bevorzugen Sie möglicherweise schnellere Verarbeitung oder kleinere Ausgabedateien.

Aspose.Slides stellt die Eigenschaft [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipptxoptions/compressionlevel/) bereit, mit der Sie die beim Speichern einer Präsentation im Office Open XML‑Format zu verwendende Komprimierungsstufe festlegen können.

Die folgenden Komprimierungsstufen sind verfügbar:

- **None**: Es wird keine Komprimierung angewendet. Dateien werden unverändert gespeichert.
- **Level1**: Die schnellste Komprimierung mit dem niedrigsten Komprimierungsgrad.
- **Level2**: Schnellere Komprimierung mit einem etwas besseren Komprimierungsgrad als **Level1**.
- **Level3**: Bietet bessere Komprimierung als **Level2** mit moderatem Einfluss auf die Verarbeitungszeit.
- **Level4**: Bietet bessere Komprimierung als **Level3**.
- **Level5**: Verbesserte Komprimierung gegenüber **Level4** mit zusätzlicher Verarbeitungszeit.
- **Level6**: Standardkomprimierung, die ein gutes Gleichgewicht zwischen Verarbeitungsgeschwindigkeit und Dateigröße bietet. Dies ist die *Standardkomprimierungsstufe*.
- **Level7**: Bietet bessere Komprimierung als **Level6** bei langsamerer Verarbeitung.
- **Level8**: Bietet bessere Komprimierung als **Level7**.
- **Level9**: Maximale Komprimierung. Produziert die kleinste Dateigröße auf Kosten der längsten Verarbeitungszeit.

Das folgende Beispiel demonstriert, wie man eine Präsentation als PPTX‑Datei *ohne Komprimierung* speichert:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Dieses Beispiel zeigt, wie man eine Präsentation als PPTX‑Datei mit *maximaler Komprimierung* speichert:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Präsentationen ohne Aktualisierung des Thumbnails speichern**

Die Eigenschaft [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) steuert die Thumbnail‑Erstellung beim Speichern einer Präsentation als PPTX:

- Bei `true` wird das Thumbnail während des Speicherns aktualisiert. Dies ist der Standardwert.
- Bei `false` wird das aktuelle Thumbnail beibehalten. Hat die Präsentation kein Thumbnail, wird keines erzeugt.

Im nachfolgenden Code wird die Präsentation als PPTX ohne Aktualisierung ihres Thumbnails gespeichert.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Diese Option hilft, die zum Speichern einer Präsentation im PPTX‑Format erforderliche Zeit zu reduzieren.
{{% /alert %}}

## **Speicherfortschritt in Prozent anzeigen**

Das Interface [IProgressCallback](https://reference.aspose.com/slides/de/net/aspose.slides/iprogresscallback/) wird über die Eigenschaft `ProgressCallback` verwendet, die vom Interface [ISaveOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/isaveoptions/) und der abstrakten Klasse [SaveOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveoptions/) bereitgestellt wird. Weisen Sie einer [IProgressCallback](https://reference.aspose.com/slides/de/net/aspose.slides/iprogresscallback/)‑Implementierung die Eigenschaft `ProgressCallback` zu, um Speicherfortschritts‑Updates als Prozentsatz zu erhalten.

Die folgenden Code‑Snippets zeigen, wie `IProgressCallback` verwendet wird.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Verwenden Sie hier den Prozentsatz des Fortschritts.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose hat eine [kostenlose PowerPoint Splitter‑App](https://products.aspose.app/slides/de/splitter) entwickelt, die seine eigene API nutzt. Die App ermöglicht es Ihnen, eine Präsentation in mehrere Dateien zu splitten, indem Sie ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien speichern.
{{% /alert %}}

## **FAQ**

**Unterstützt "Fast Save" (inkrementelles Speichern), sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die gesamte Zieldatei erstellt; inkrementelles "Fast Save" wird nicht unterstützt.

**Ist das Speichern der gleichen Presentation‑Instanz aus mehreren Threads thread‑sicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Instanz [ist nicht thread‑sicher](/slides/de/net/multithreading/); speichern Sie sie aus einem einzelnen Thread.

**Was passiert beim Speichern mit Hyperlinks und extern verknüpften Dateien?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) bleiben erhalten. Extern verknüpfte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokumentmetadaten (Autor, Titel, Unternehmen, Datum) setzen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/net/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.