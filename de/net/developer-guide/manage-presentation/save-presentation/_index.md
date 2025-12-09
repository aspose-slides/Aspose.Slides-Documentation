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
- Präsentation zu Datei
- Präsentation zu Stream
- vordefinierter Ansichtstyp
- Strict Office Open XML-Format
- Zip64-Modus
- Thumbnail aktualisieren
- Speicherfortschritt
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Sie Präsentationen in .NET mit Aspose.Slides speichern—Export nach PowerPoint oder OpenDocument bei gleichzeitiger Beibehaltung von Layouts, Schriften und Effekten."
---

## **Übersicht**

[Open Presentations in C#](/slides/de/net/open-presentation/) beschrieb, wie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse zum Öffnen einer Präsentation verwendet wird. Dieser Artikel erklärt, wie Präsentationen erstellt und gespeichert werden. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene bearbeiten, Sie möchten sie am Ende speichern. Mit Aspose.Slides für .NET können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel beschreibt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie Sie mit Aspose.Slides eine Präsentation speichern.
```cs
// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
using (Presentation presentation = new Presentation())
{
    // Hier etwas Arbeit erledigen...
    // Speichere die Präsentation in einer Datei.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.
```cs
// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Speichere die Präsentation in den Stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```


## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint beim Öffnen der erzeugten Präsentation verwendet, über die [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/)‑Klasse. Setzen Sie die [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/)‑Eigenschaft auf einen Wert aus der Aufzählung [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/).
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Präsentationen im Strict Office Open XML‑Format speichern**

Aspose.Slides ermöglicht es Ihnen, eine Präsentation im Strict Office Open XML‑Format zu speichern. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/)‑Klasse und setzen Sie deren `Conformance`‑Eigenschaft beim Speichern. Wenn Sie `Conformance.Iso29500_2008_Strict` festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation())
{
    // Speichere die Präsentation im Strict Office Open XML-Format.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das 4 GB (2^32 Bytes) für die unkomprimierte Größe einer Datei, die komprimierte Größe einer Datei und die Gesamtabgröße des Archivs begrenzt und zudem maximal 65 535 (2^16‑1) Dateien zulässt. ZIP64‑Formatserweiterungen erhöhen diese Grenzen auf 2^64.

Die Eigenschaft [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) ermöglicht es Ihnen, festzulegen, wann ZIP64‑Formatserweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden.

Diese Eigenschaft bietet die folgenden Modi:

- `IfNecessary` verwendet ZIP64‑Formatserweiterungen nur, wenn die Präsentation die obigen Begrenzungen überschreitet. Dies ist der Standardmodus.
- `Never` verwendet ZIP64‑Formatserweiterungen niemals.
- `Always` verwendet ZIP64‑Formatserweiterungen stets.

Der folgende Code demonstriert, wie eine Präsentation als PPTX mit aktivierten ZIP64‑Formatserweiterungen gespeichert wird:
```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```


{{% alert title="HINWEIS" color="warning" %}}

Wenn Sie mit `Zip64Mode.Never` speichern, wird eine [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) ausgelöst, wenn die Präsentation nicht im ZIP32‑Format gespeichert werden kann.

{{% /alert %}}

## **Präsentationen ohne Aktualisierung des Vorschaubilds speichern**

Die Eigenschaft [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) steuert die Generierung des Vorschaubilds beim Speichern einer Präsentation als PPTX:

- Wenn sie auf `true` gesetzt ist, wird das Vorschaubild während des Speichervorgangs aktualisiert. Dies ist die Standardeinstellung.
- Wenn sie auf `false` gesetzt ist, bleibt das aktuelle Vorschaubild erhalten. Gibt es kein Vorschaubild, wird keines erzeugt.

Im folgenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Vorschaubild zu aktualisieren.
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

## **Speicherfortschritt in Prozent erhalten**

Das Interface [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) wird über die `ProgressCallback`‑Eigenschaft des [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/)‑Interfaces und der abstrakten Klasse [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) verwendet. Implementieren Sie ein [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) und weisen Sie es `ProgressCallback` zu, um Fortschrittsupdates beim Speichern in Prozent zu erhalten.

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
        // Verwenden Sie hier den Fortschrittsprozentsatz.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}

Aspose hat eine [kostenlose PowerPoint‑Splitter‑App](https://products.aspose.app/slides/splitter) entwickelt, die die eigene API nutzt. Die App ermöglicht es, eine Präsentation in mehrere Dateien zu splitten, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.

{{% /alert %}}

## **FAQ**

**Wird „schnelles Speichern“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei erstellt; inkrementelles „schnelles Speichern“ wird nicht unterstützt.

**Ist das gleichzeitige Speichern derselben Presentation‑Instanz aus mehreren Threads threadsicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz ist [nicht threadsicher](/slides/de/net/multithreading/); speichern Sie sie aus einem einzelnen Thread.

**Was passiert mit Hyperlinks und extern verknüpften Dateien beim Speichern?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) bleiben erhalten. Extern verknüpfte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Unternehmen, Datum) festlegen/​speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/net/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.