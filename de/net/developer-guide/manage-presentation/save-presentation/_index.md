---
title: Präsentationen speichern in .NET
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
- Präsentation zu Datei
- Präsentation zu Stream
- vordefinierter Ansichtstyp
- Striktes Office Open XML-Format
- Zip64-Modus
- Vorschaubild aktualisieren
- Speicherfortschritt
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen in .NET mit Aspose.Slides speichern—Export nach PowerPoint oder OpenDocument bei Beibehaltung von Layouts, Schriftarten und Effekten."
---

## **Übersicht**

[Open Presentations in C#](/slides/de/net/open-presentation/) beschrieb, wie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, Sie möchten sie speichern, wenn Sie fertig sind. Mit Aspose.Slides für .NET können Sie in eine **Datei** oder einen **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie man eine Präsentation mit Aspose.Slides speichert.
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

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im nachfolgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.
```cs
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Speichern Sie die Präsentation im Stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```


## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht es, die anfängliche Ansicht, die PowerPoint beim Öffnen der erzeugten Präsentation verwendet, über die [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/) Klasse festzulegen. Setzen Sie die [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) Eigenschaft auf einen Wert aus der [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) Aufzählung.
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Präsentationen im strikten Office Open XML-Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im strikten Office Open XML‑Format. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) Klasse und setzen Sie beim Speichern ihre Conformance‑Eigenschaft. Wenn Sie `Conformance.Iso29500_2008_Strict` festlegen, wird die Ausgabedatei im strikten Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im strikten Office Open XML‑Format.
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Speichern Sie die Präsentation im strikten Office Open XML-Format.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **Präsentationen im Office Open XML-Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das Grenzen von 4 GB (2^32 Bytes) für die unkomprimierte Größe einer Datei, die komprimierte Größe einer Datei und die Gesamtgröße des Archivs festlegt und zudem das Archiv auf 65 535 (2^16‑1) Dateien begrenzt. ZIP64‑Formaterweiterungen erhöhen diese Grenzen auf 2^64.

Die [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) Eigenschaft ermöglicht es, zu wählen, wann ZIP64‑Formaterweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden sollen.

Diese Eigenschaft bietet die folgenden Modi:
- `IfNecessary` verwendet ZIP64‑Formaterweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- `Never` verwendet niemals ZIP64‑Formaterweiterungen.
- `Always` verwendet immer ZIP64‑Formaterweiterungen.

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
Wenn Sie mit `Zip64Mode.Never` speichern, wird eine [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) ausgelöst, falls die Präsentation nicht im ZIP32-Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen speichern, ohne das Vorschaubild zu aktualisieren**

Die [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) Eigenschaft steuert die Generierung des Vorschaubilds beim Speichern einer Präsentation im PPTX‑Format:
- Ist sie auf `true` gesetzt, wird das Vorschaubild beim Speichern aktualisiert. Dies ist der Standard.
- Ist sie auf `false` gesetzt, wird das aktuelle Vorschaubild beibehalten. Hat die Präsentation kein Vorschaubild, wird keines erzeugt.

Im nachstehenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Vorschaubild zu aktualisieren.
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
Diese Option hilft, die zum Speichern einer Präsentation im PPTX‑Format benötigte Zeit zu verkürzen.
{{% /alert %}}

## **Speicherfortschritt in Prozent anzeigen**

Das [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) Interface wird über die `ProgressCallback`‑Eigenschaft verwendet, die vom [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) Interface und der abstrakten [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) Klasse bereitgestellt wird. Weisen Sie eine [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) Implementierung der `ProgressCallback`‑Eigenschaft zu, um Speicherfortschritts‑Updates in Prozent zu erhalten.

Die folgenden Code‑Snippets zeigen, wie `IProgressCallback` verwendet wird.
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
Aspose hat eine [kostenlose PowerPoint‑Splitter‑App](https://products.aspose.app/slides/splitter) mit seiner eigenen API entwickelt. Die App ermöglicht es, eine Präsentation in mehrere Dateien zu splitten, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „Fast Save“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die komplette Zieldatei erstellt; inkrementelles „Fast Save“ wird nicht unterstützt.

**Ist das Speichern derselben Presentation‑Instanz aus mehreren Threads threadsicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Instanz [ist nicht threadsicher](/slides/de/net/multithreading/); speichern Sie sie aus einem einzelnen Thread.

**Was passiert beim Speichern mit Hyperlinks und extern verlinkten Dateien?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden beibehalten. Extern verlinkte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Firma, Datum) setzen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/net/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.