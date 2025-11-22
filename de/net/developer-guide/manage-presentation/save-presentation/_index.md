---
title: Präsentationen in .NET speichern
linktitle: Präsentationen speichern
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
- Miniaturbild aktualisieren
- Speicherfortschritt
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Sie Präsentationen in .NET mit Aspose.Slides speichern – Export nach PowerPoint oder OpenDocument bei Erhalt von Layouts, Schriften und Effekten."
---

## **Übersicht**

[Open Presentations in C#](/slides/de/net/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse zum Öffnen einer Präsentation verwendet wird. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine bestehende ändern, Sie möchten sie speichern, wenn Sie fertig sind. Mit Aspose.Slides für .NET können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie man eine Präsentation mit Aspose.Slides speichert.
```cs
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Führen Sie hier einige Arbeiten aus...

    // Speichern Sie die Präsentation in einer Datei.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.
```cs
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Speichern Sie die Präsentation in den Stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```


## **Präsentationen mit einem vordefinierten Ansichtstyp speichern**

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint verwendet, wenn die erzeugte Präsentation geöffnet wird, über die [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/)‑Klasse. Setzen Sie die [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/)‑Eigenschaft auf einen Wert aus der [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/)‑Aufzählung.
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Präsentationen im Strict Office Open XML‑Format speichern**

Aspose.Slides lässt Sie eine Präsentation im Strict Office Open XML‑Format speichern. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/)‑Klasse und setzen Sie deren Conformance‑Eigenschaft beim Speichern. Wenn Sie `Conformance.Iso29500_2008_Strict` festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Speichern Sie die Präsentation im Strict Office Open XML-Format.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das 4 GB (2^32 Bytes) Grenzen für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtausgröße des Archivs sowie 65 535 (2^16‑1) Dateien festlegt. ZIP64‑Formatserweiterungen heben diese Grenzen auf 2^64 an.

Die [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/)‑Eigenschaft erlaubt Ihnen zu wählen, wann ZIP64‑Formatserweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden.

Diese Eigenschaft bietet die folgenden Modi:

- `IfNecessary` verwendet ZIP64‑Formatserweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- `Never` verwendet niemals ZIP64‑Formatserweiterungen.
- `Always` verwendet immer ZIP64‑Formatserweiterungen.

Der folgende Code zeigt, wie man eine Präsentation als PPTX mit aktivierten ZIP64‑Formaterweiterungen speichert:
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
Wenn Sie mit `Zip64Mode.Never` speichern, wird eine [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) ausgelöst, falls die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen speichern, ohne das Miniaturbild zu aktualisieren**

Die [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/)‑Eigenschaft steuert die Miniaturbild‑Erstellung beim Speichern einer Präsentation als PPTX:

- Wenn auf `true` gesetzt, wird das Miniaturbild beim Speichern aktualisiert. Das ist die Vorgabe.
- Wenn auf `false` gesetzt, bleibt das aktuelle Miniaturbild erhalten. Hat die Präsentation kein Miniaturbild, wird keines erzeugt.

Im folgenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Miniaturbild zu aktualisieren.
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
Diese Option hilft, die zum Speichern einer Präsentation im PPTX‑Format benötigte Zeit zu reduzieren.
{{% /alert %}}

## **Speicherfortschritts‑Updates in Prozent anzeigen**

Die [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/)‑Schnittstelle wird über die `ProgressCallback`‑Eigenschaft der [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/)‑Schnittstelle und der abstrakten [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/)‑Klasse verwendet. Weisen Sie einer [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/)‑Implementierung `ProgressCallback` zu, um Speicher‑Fortschritts‑Updates als Prozentsatz zu erhalten.

Die folgenden Code‑Snippets zeigen, wie man `IProgressCallback` verwendet.
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
        // Verwenden Sie hier den Fortschrittsprozentsatz.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}
Aspose hat eine [kostenlose PowerPoint Splitter‑App](https://products.aspose.app/slides/splitter) mit seiner eigenen API entwickelt. Die App ermöglicht das Aufteilen einer Präsentation in mehrere Dateien, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „schnelles Speichern“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei erstellt; ein inkrementelles „schnelles Speichern“ wird nicht unterstützt.

**Ist das gleichzeitige Speichern derselben Presentation‑Instanz aus mehreren Threads threadsicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz ist nicht threadsicher; speichern Sie sie aus einem einzelnen Thread.

**Was passiert mit Hyperlinks und extern verknüpften Dateien beim Speichern?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) bleiben erhalten. Extern verknüpfte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Unternehmen, Datum) setzen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/net/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.