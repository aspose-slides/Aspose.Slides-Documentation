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
- Miniaturansicht aktualisieren
- Speicherfortschritt
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Sie Präsentationen in .NET mit Aspose.Slides speichern – Export nach PowerPoint oder OpenDocument bei Beibehaltung von Layouts, Schriften und Effekten."
---

## **Übersicht**

[Präsentationen in C# öffnen](/slides/de/net/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie Präsentationen erstellt und gespeichert werden. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, Sie möchten sie am Ende speichern. Mit Aspose.Slides für .NET können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie man mit Aspose.Slides eine Präsentation speichert.
```cs
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei repräsentiert.
using (Presentation presentation = new Presentation())
{
    // Führen Sie hier einige Arbeiten aus...

    // Speichern Sie die Präsentation in einer Datei.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.
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


## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint verwendet, wenn die erzeugte Präsentation über die [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/) Klasse geöffnet wird. Setzen Sie die [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) Eigenschaft auf einen Wert aus der [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) Aufzählung.
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Präsentationen im Strict Office Open XML-Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML-Format. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) Klasse und setzen Sie deren Conformance‑Eigenschaft beim Speichern. Wenn Sie `Conformance.Iso29500_2008_Strict` festlegen, wird die Ausgabedatei im Strict Office Open XML-Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML-Format.
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


## **Präsentationen im Office Open XML-Format im Zip64-Modus speichern**

Eine Office Open XML-Datei ist ein ZIP-Archiv, das Grenzen von 4 GB (2^32 Bytes) für die unkomprimierte Größe einer Datei, die komprimierte Größe einer Datei und die Gesamtabmessungen des Archivs festlegt und zudem das Archiv auf 65 535 (2^16‑1) Dateien begrenzt. ZIP64-Formatserweiterungen erhöhen diese Grenzen auf 2^64.

Die [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) Eigenschaft lässt Sie festlegen, wann ZIP64-Formatserweiterungen beim Speichern einer Office Open XML-Datei verwendet werden sollen.

Diese Eigenschaft bietet die folgenden Modi:

- `IfNecessary` verwendet ZIP64-Formatserweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- `Never` verwendet niemals ZIP64-Formatserweiterungen.
- `Always` verwendet immer ZIP64-Formatserweiterungen.

Der folgende Code demonstriert, wie man eine Präsentation als PPTX mit aktivierten ZIP64-Formatserweiterungen speichert:
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

## **Präsentationen ohne Aktualisierung des Miniaturbildes speichern**

Die [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) Eigenschaft steuert die Generierung des Miniaturbildes beim Speichern einer Präsentation als PPTX:

- Ist sie auf `true` gesetzt, wird das Miniaturbild beim Speichern aktualisiert. Dies ist die Standardeinstellung.
- Ist sie auf `false` gesetzt, bleibt das aktuelle Miniaturbild erhalten. Falls die Präsentation kein Miniaturbild hat, wird keines erzeugt.

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
Diese Option trägt dazu bei, die zum Speichern einer Präsentation im PPTX-Format benötigte Zeit zu reduzieren.
{{% /alert %}}

## **Speicherfortschritts-Aktualisierungen in Prozent anzeigen**

Das [IProgressCallback](https://reference.aspose.com/slides/net/iprogresscallback/) Interface wird über die `ProgressCallback` Eigenschaft verwendet, die vom [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) Interface und der abstrakten [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) Klasse bereitgestellt wird. Weisen Sie eine [IProgressCallback](https://reference.aspose.com/slides/net/iprogresscallback/) Implementierung der `ProgressCallback` Eigenschaft zu, um Speicherfortschritts‑Updates als Prozentsatz zu erhalten.

Die folgenden Codeausschnitte zeigen, wie man `IProgressCallback` verwendet.
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
Aspose hat eine kostenlose PowerPoint Splitter‑App entwickelt, die seine eigene API verwendet. Die App ermöglicht es Ihnen, eine Präsentation in mehrere Dateien zu splitten, indem Sie ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien speichern.
{{% /alert %}}

## **FAQ**

**Wird "Schnellspeichern" (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei neu erstellt; inkrementelles „Schnellspeichern“ wird nicht unterstützt.

**Ist das Speichern derselben Presentation‑Instanz aus mehreren Threads gleichzeitig threadsicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Instanz ist [nicht threadsicher](/slides/de/net/multithreading/); speichern Sie sie aus einem einzelnen Thread.

**Was passiert mit Hyperlinks und extern verlinkten Dateien beim Speichern?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden beibehalten. Extern verlinkte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokumentmetadaten (Autor, Titel, Firma, Datum) festlegen/speichern?**

Ja. Standard‑[Dokumenteigenschaften](/slides/de/net/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.