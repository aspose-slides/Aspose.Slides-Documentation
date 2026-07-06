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
- Strenges Office Open XML-Format
- Zip64-Modus
- Miniaturbild aktualisieren
- Speicherfortschritt
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen in .NET mit Aspose.Slides speichern—Export nach PowerPoint oder OpenDocument bei gleichzeitiger Beibehaltung von Layouts, Schriftarten und Effekten."
---
## **Übersicht**

[Open Presentations in C#](/slides/de/net/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine bestehende ändern, Sie möchten sie am Ende speichern. Mit Aspose.Slides für .NET können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erläutert die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie man mit Aspose.Slides eine Präsentation speichert.

```cs
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
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
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
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

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint verwendet, wenn die erzeugte Präsentation über die [ViewProperties](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/) Klasse geöffnet wird. Setzen Sie die [LastView](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/lastview/) Eigenschaft auf einen Wert aus der [ViewType](https://reference.aspose.com/slides/de/net/aspose.slides/viewtype/) Aufzählung.

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Präsentationen im strengen Office Open XML‑Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im strengen Office Open XML‑Format. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pptxoptions/) Klasse und setzen Sie deren Conformance‑Eigenschaft beim Speichern. Wenn Sie `Conformance.Iso29500_2008_Strict` festlegen, wird die Ausgabedatei im strengen Office Open XML‑Format gespeichert.

Das nachstehende Beispiel erstellt eine Präsentation und speichert sie im strengen Office Open XML‑Format.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Speichern Sie die Präsentation im strengen Office Open XML‑Format.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das Beschränkungen von 4 GB (2^32 Bytes) für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtabgröße des Archivs auferlegt und das Archiv zudem auf 65 535 (2^16‑1) Dateien begrenzt. ZIP64‑Format-Erweiterungen erhöhen diese Grenzen auf 2^64.

Die Eigenschaft [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipptxoptions/zip64mode/) ermöglicht Ihnen zu wählen, wann ZIP64‑Format-Erweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden sollen.

Diese Eigenschaft bietet die folgenden Modi:

- `IfNecessary` verwendet ZIP64‑Format-Erweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- `Never` verwendet niemals ZIP64‑Format-Erweiterungen.
- `Always` verwendet immer ZIP64‑Format-Erweiterungen.

Der folgende Code demonstriert, wie man eine Präsentation als PPTX‑Datei mit aktivierten ZIP64‑Format-Erweiterungen speichert:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Wenn Sie mit `Zip64Mode.Never` speichern, wird eine [PptxException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxexception/) ausgelöst, falls die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen im Office Open XML‑Format mit Komprimierungsstufen speichern**

Bei der Arbeit mit großen Präsentationen können Sie die Komprimierungsstufe anpassen, um Dateigröße und Verarbeitungszeit auszubalancieren. Je nach Anforderung können Sie schnellere Verarbeitung oder kleinere Ausgabedateien bevorzugen.

Aspose.Slides stellt die Eigenschaft [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipptxoptions/compressionlevel/) bereit, mit der Sie die beim Speichern einer Präsentation im Office Open XML‑Format zu verwendende Komprimierungsstufe festlegen können.

Die folgenden Komprimierungsstufen sind verfügbar:

- **None**: Keine Kompression wird angewendet. Dateien werden unverändert gespeichert.
- **Level1**: Die schnellste Kompression mit dem niedrigsten Komprimierungsverhältnis.
- **Level2**: Schnellere Kompression mit einem etwas besseren Komprimierungsverhältnis als **Level1**.
- **Level3**: Bietet bessere Kompression als **Level2** bei mäßigem Einfluss auf die Verarbeitungszeit.
- **Level4**: Bietet bessere Kompression als **Level3**.
- **Level5**: Bietet verbesserte Kompression gegenüber **Level4** mit zusätzlicher Verarbeitungszeit.
- **Level6**: Standardkompression, die ein gutes Gleichgewicht zwischen Verarbeitungsgeschwindigkeit und Dateigröße bietet. Dies ist die *Standardkomprimierungsstufe*.
- **Level7**: Bietet bessere Kompression als **Level6** bei langsamerer Verarbeitung.
- **Level8**: Bietet bessere Kompression als **Level7**.
- **Level9**: Maximale Kompression. Produziert die kleinste Dateigröße, kostet jedoch die längste Verarbeitungszeit.

Das folgende Beispiel demonstriert, wie man eine Präsentation als PPTX‑Datei *ohne Kompression* speichert:

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Dieses Beispiel zeigt, wie man eine Präsentation als PPTX‑Datei mit *maximaler Kompression* speichert:

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Präsentationen speichern, ohne das Miniaturbild zu aktualisieren**

Die Eigenschaft [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) steuert die Erzeugung des Miniaturbilds beim Speichern einer Präsentation als PPTX:

- Wenn sie auf `true` gesetzt ist, wird das Miniaturbild beim Speichern aktualisiert. Dies ist die Standardeinstellung.
- Wenn sie auf `false` gesetzt ist, bleibt das aktuelle Miniaturbild erhalten. Hat die Präsentation kein Miniaturbild, wird keines erzeugt.

Im nachstehenden Code wird die Präsentation als PPTX gespeichert, ohne das Miniaturbild zu aktualisieren.

```cs
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

## **Speicherfortschritts‑Updates in Prozent erhalten**

Die Schnittstelle [IProgressCallback](https://reference.aspose.com/slides/de/net/aspose.slides/iprogresscallback/) wird über die `ProgressCallback`‑Eigenschaft verwendet, die von der [ISaveOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/isaveoptions/) Schnittstelle und der abstrakten Klasse [SaveOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveoptions/) bereitgestellt wird. Weisen Sie einer [IProgressCallback](https://reference.aspose.com/slides/de/net/aspose.slides/iprogresscallback/)‑Implementierung `ProgressCallback` zu, um Speicherfortschritts‑Updates in Prozent zu erhalten.

Die folgenden Code‑Snippets zeigen, wie `IProgressCallback` verwendet wird:

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Verwenden Sie hier den prozentualen Fortschrittswert.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose hat eine [kostenlose PowerPoint‑Splitter‑App](https://products.aspose.app/slides/de/splitter) mit seiner eigenen API entwickelt. Die App ermöglicht es, eine Präsentation in mehrere Dateien zu splitten, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „schnelles Speichern“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Antwort: Nein. Beim Speichern wird jedes Mal die komplette Zieldatei erstellt; inkrementelles „schnelles Speichern“ wird nicht unterstützt.

**Ist das Speichern derselben Presentation‑Instanz aus mehreren Threads thread‑sicher?**

Antwort: Nein. Eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) Instanz [ist nicht thread‑sicher](/slides/de/net/multithreading/); speichern Sie sie aus einem einzigen Thread.

**Was passiert mit Hyperlinks und extern verknüpften Dateien beim Speichern?**

Antwort: [Hyperlinks](/slides/de/net/manage-hyperlinks/) bleiben erhalten. Extern verknüpfte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin erreichbar sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Firma, Datum) setzen/speichern?**

Antwort: Ja. Standard‑[Dokumenteneigenschaften](/slides/de/net/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.