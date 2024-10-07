---
title: PowerPoint in PDF umwandeln in C#
linktitle: PowerPoint in PDF umwandeln
type: docs
weight: 40
url: /net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint umwandeln
- Präsentation
- PowerPoint in PDF
- PPT in PDF
- PPTX in PDF
- PowerPoint als PDF speichern
- PDF/A1a
- PDF/A1b
- PDF/UA
- C#
- Csharp
- .NET
- Aspose.Slides für .NET
description: "Wandeln Sie PowerPoint-Präsentationen in PDF in C# oder .NET um. Speichern Sie PowerPoint als PDF mit Konformitäts- oder Barrierefreiheitsstandards."
---

## **Überblick**

Die Umwandlung von PowerPoint-Dokumenten in das PDF-Format bietet mehrere Vorteile, darunter die Gewährleistung der Kompatibilität über verschiedene Geräte hinweg und die Bewahrung des Layouts und der Formatierung Ihrer Präsentation. Dieser Artikel zeigt Ihnen, wie Sie Präsentationen in PDF-Dokumente umwandeln, verschiedene Optionen zur Kontrolle der Bildqualität verwenden, versteckte Folien einfügen, PDF-Dokumente passwortschützen, Schriftartsubstitutionen erkennen, Folien zur Umwandlung auswählen und Konformitätsstandards für Ausgabedokumente anwenden.

## **PowerPoint in PDF Umwandlungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF umwandeln:

* PPT
* PPTX
* ODP

Um eine Präsentation in PDF umzuwandeln, müssen Sie lediglich den Dateinamen als Argument in der [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse übergeben und dann die Präsentation mit einer [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) Methode als PDF speichern. Die [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse stellt die [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/#presentationsave-method-5-of-9) Methode zur Verfügung, die typischerweise verwendet wird, um eine Präsentation in PDF umzuwandeln.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für .NET schreibt direkt API-Informationen und Versionsnummern in die Ausgabedokumente. Zum Beispiel, wenn sie eine Präsentation in PDF umwandelt, füllt Aspose.Slides für .NET das Anwendungsfeld mit dem Wert '*Aspose.Slides*' und das PDF-Produzentenfeld mit einem Wert in der Form '*Aspose.Slides v XX.XX*'. **Hinweis**: Sie können Aspose.Slides für .NET nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht es Ihnen, Folgendes umzuwandeln:

* eine gesamte Präsentation in PDF
* spezifische Folien in einer Präsentation in PDF
* eine Präsentation 

Aspose.Slides exportiert Präsentationen in PDF auf eine Weise, die den Inhalt der resultierenden PDFs sehr ähnlich macht wie in den ursprünglichen Präsentationen. Diese bekannten Elemente und Attribute werden oft korrekt bei der Umwandlung von Präsentationen in PDF gerendert:

* Bilder
* Textfelder und andere Formen
* Texte und deren Formatierung
* Absätze und deren Formatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungen
* Tabellen

## **PowerPoint in PDF umwandeln**

Die Standardoperation zur Umwandlung von PowerPoint in PDF wird mit den Standardoptionen ausgeführt. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf den höchsten Qualitätsstufen in PDF umzuwandeln.

Dieser C#-Code zeigt Ihnen, wie Sie eine PowerPoint (PPT, PPTX, ODP) in PDF umwandeln:

```c#
// Erstellt eine Presentation-Klasse, die eine PowerPoint-Datei darstellt, könnte PPT, PPTX, ODP usw. sein.
Presentation presentation = new Presentation("PowerPoint.ppt");

// Speichert die Präsentation als PDF
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online-[**PowerPoint zu PDF-Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Prozess der Umwandlung von Präsentationen in PDF demonstriert. Für eine Live-Implementierung des hier beschriebenen Verfahrens können Sie einen Test mit dem Konverter durchführen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen umwandeln**

Aspose.Slides bietet benutzerdefinierte Optionen – Eigenschaften unter der [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) Klasse – die es Ihnen ermöglichen, das PDF (resultierend aus dem Umwandlungsprozess) anzupassen, das PDF mit einem Passwort zu sperren oder sogar anzugeben, wie der Umwandlungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen umwandeln**

Mit benutzerdefinierten Umwandlungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, angeben, wie Metadateien behandelt werden sollen, ein Komprimierungsniveau für Texte festlegen, DPI für Bilder festlegen usw.

Das folgende Codebeispiel demonstriert eine Operation, bei der eine PowerPoint-Präsentation mit mehreren benutzerdefinierten Optionen in PDF umgewandelt wird:

```c#
// Erstellt die PdfOptions-Klasse
PdfOptions pdfOptions = new PdfOptions
{
    // Legt die Qualität für JPG-Bilder fest
    JpegQuality = 90,

    // Legt DPI für Bilder fest
    SufficientResolution = 300,

    // Legt das Verhalten für Metadateien fest
    SaveMetafilesAsPng = true,

    // Legt das Textkomprimierungsniveau für textliche Inhalte fest
    TextCompression = PdfTextCompression.Flate,

    // Definiert den PDF-Konformitätsmodus
    Compliance = PdfCompliance.Pdf15
};

// Erstellt die Presentation-Klasse, die ein PowerPoint-Dokument darstellt
using (Presentation presentation = new Presentation("PowerPoint.pptx"))
{
    // Speichert die Präsentation als PDF-Dokument
    presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
}
```

### **PowerPoint in PDF mit versteckten Folien umwandeln**

Wenn eine Präsentation versteckte Folien enthält, können Sie eine benutzerdefinierte Option – die [`ShowHiddenSlides`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) Eigenschaft der [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) Klasse – verwenden, um Aspose.Slides anzuweisen, die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

Dieser C#-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PDF umwandeln, wobei versteckte Folien enthalten sind:

```c#
// Erstellt eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
Presentation presentation = new Presentation("PowerPoint.pptx");

// Erstellt die PdfOptions-Klasse
PdfOptions pdfOptions = new PdfOptions();

// Fügt versteckte Folien hinzu
pdfOptions.ShowHiddenSlides = true;

// Speichert die Präsentation als PDF
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint in passwortgeschütztes PDF umwandeln**

Dieser C#-Code zeigt Ihnen, wie Sie eine PowerPoint in ein passwortgeschütztes PDF (unter Verwendung von Schutzparametern aus der [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) Klasse) umwandeln:

```c#
// Erstellt ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
Presentation presentation = new Presentation("PowerPoint.pptx");

/// Erstellt die PdfOptions-Klasse
PdfOptions pdfOptions = new PdfOptions();

// Legt das PDF-Passwort und die Zugriffsberechtigungen fest
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Speichert die Präsentation als PDF
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Schriftartsubstitutionen erkennen**

Aspose.Slides bietet die [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) Eigenschaft unter der [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) Klasse, um Ihnen zu ermöglichen, Schriftartsubstitutionen im Umwandlungsprozess von Präsentationen in PDF zu erkennen. 

Dieser C#-Code zeigt Ihnen, wie Sie Schriftartsubstitutionen erkennen: xxx 

```c#
public static void Main()
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.WarningCallback = warningCallback;

    using (Presentation pres = new Presentation("pres.pptx", loadOptions))
    {
    }
}

private class FontSubstSendsWarningCallback : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Schriftartsubstitutionswarnung: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Für weitere Informationen zum Abrufen von Rückrufen für Schriftartsubstitutionen in einem Rendering-Prozess siehe [Erhalten von Warnrückrufen für Schriftartsubstitution](https://docs.aspose.com/slides/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Für weitere Informationen zur Schriftartsubstitution siehe den Artikel [Schriftartsubstitution](https://docs.aspose.com/slides/net/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF umwandeln**

Dieser C#-Code zeigt Ihnen, wie Sie spezifische Folien in einer PowerPoint-Präsentation in PDF umwandeln:

```c#
// Erstellt ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
Presentation presentation = new Presentation("PowerPoint.pptx");

// Legt ein Array mit Folienpositionen fest
int[] slides = { 1, 3 };

// Speichert die Präsentation als PDF
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße umwandeln**

Dieser C#-Code zeigt Ihnen, wie Sie eine PowerPoint umwandeln, wenn die Foliengröße spezifiziert ist:

```c#
// Erstellt ein Presentation-Objekt, das eine PowerPoint-Datei darstellt 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];
auxPresentation.Slides.InsertClone(0, slide);

// Legt den Folientyp und die Größe fest 
// auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F,SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
options.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PowerPoint in PDF in Notizfolienansicht umwandeln**

Dieser C#-Code zeigt Ihnen, wie Sie eine PowerPoint in PDF-Notizen umwandeln:

```c#
// Erstellt eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
	PdfOptions pdfOptions = new PdfOptions();
	INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
	options.NotesPosition = NotesPositions.BottomFull;

	// Speichert die Präsentation in PDF-Notizen
	presentation.Save("Pdf_Notes_out.tiff", SaveFormat.Pdf, pdfOptions);
}
```

## **Barrierefreiheits- und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht es Ihnen, ein Umwandlungsverfahren zu verwenden, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint-Dokument in PDF unter Verwendung eines dieser Konformitätsstandards exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C#-Code demonstriert eine PowerPoint zu PDF Umwandlungsoperation, bei der mehrere PDFs basierend auf unterschiedlichen Konformitätsstandards erstellt werden:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1a
    });
   
    pres.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1b
    });
   
    pres.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
   {
        Compliance = PdfCompliance.PdfUa
    });
}
```

{{% alert title="Hinweis" color="warning" %}} 

Die Unterstützung von Aspose.Slides für PDF-Konvertierungsoperationen erstreckt sich auch darauf, Ihnen zu ermöglichen, PDF in die beliebtesten Dateiformate zu konvertieren. Sie können [PDF zu HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) Konvertierungen durchführen. Andere PDF-Konvertierungsoperationen in spezielle Formate – [PDF zu SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}