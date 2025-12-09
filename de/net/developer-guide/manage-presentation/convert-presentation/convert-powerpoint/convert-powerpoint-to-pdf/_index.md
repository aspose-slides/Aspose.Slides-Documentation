---
title: PPT und PPTX nach PDF in .NET konvertieren [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PowerPoint zu PDF
- Präsentation zu PDF
- PPT zu PDF
- PPT zu PDF konvertieren
- PPTX zu PDF
- PPTX zu PDF konvertieren
- PowerPoint als PDF speichern
- PPT als PDF speichern
- PPTX als PDF speichern
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochqualitative, durchsuchbare PDFs in .NET konvertieren mit Aspose.Slides, inklusive schneller C#-Codebeispiele und erweiterter Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in C# bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Bewahrung des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF-Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet, versteckte Folien einbezogen, PDF-Dateien mit einem Passwort geschützt, Font-Substitutionen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance-Standards auf die Ausgabedokumente angewendet werden.

## **PowerPoint zu PDF Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse und speichern dann die Präsentation als PDF mit einer [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) Methode. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse stellt die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET fügt in Ausgabedokumente seine API-Informationen und Versionsnummer ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis** dass Sie Aspose.Slides nicht anweisen können, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* Gesamten Präsentationen zu PDF
* Bestimmten Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr nahe kommen. Elemente und Attribute werden in der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Dieser C#‑Code zeigt, wie Sie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertieren:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online-**PowerPoint‑zu‑PDF‑Konverter**, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu sehen.

{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen—Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden sollen, ein Kompressionsniveau für Text setzen, DPI für Bilder konfigurieren und mehr.

Das untenstehende Codebeispiel zeigt, wie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird.
```c#
// Instanziieren Sie die PdfOptions-Klasse.
var pdfOptions = new PdfOptions
{
    // Legen Sie die Qualität für JPG-Bilder fest.
    JpegQuality = 90,

    // Legen Sie die DPI für Bilder fest.
    SufficientResolution = 300,

    // Legen Sie das Verhalten für Metadateien fest.
    SaveMetafilesAsPng = true,

    // Legen Sie das Komprimierungsniveau für Textinhalte fest.
    TextCompression = PdfTextCompression.Flate,

    // Definieren Sie den PDF-Compliance-Modus.
    Compliance = PdfCompliance.Pdf15
};

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Speichern Sie die Präsentation als PDF-Dokument.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) verwenden, um die versteckten Folien als Seiten in das resultierende PDF einzufügen.

Dieser C#‑Code zeigt, wie eine PowerPoint‑Präsentation in PDF konvertiert wird, wobei versteckte Folien einbezogen werden:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
var pdfOptions = new PdfOptions();

// Versteckte Folien hinzufügen.
pdfOptions.ShowHiddenSlides = true;

// Speichern Sie die Präsentation als PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **PowerPoint zu passwortgeschütztem PDF konvertieren**

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation mittels der Schutzparameter der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) in ein passwortgeschütztes PDF konvertiert wird:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
var pdfOptions = new PdfOptions();

// Legen Sie ein PDF-Passwort und Zugriffsrechte fest.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Speichern Sie die Präsentation als PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Font‑Substitutionen erkennen**

Aspose.Slides stellt die Eigenschaft [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) bereit, die es Ihnen ermöglicht, Font‑Substitutionen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses zu erkennen.

Dieser C#‑Code zeigt, wie Font‑Substitutionen erkannt werden können:
```c#
public static void Main()
{
    // Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt. 
    using var presentation = new Presentation("sample.pptx");

    // Setzen Sie den Warnungs-Callback in den PDF-Optionen.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Speichern Sie die Präsentation als PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementierung des Warnungs-Callbacks.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```


{{%  alert color="primary"  %}} 

Weitere Informationen zum Empfangen von Callbacks für Font‑Substitutionen während des Rendering‑Prozesses finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zu Font‑Substitutionen finden Sie im Artikel [Font Substitution](/slides/de/net/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien von PowerPoint zu PDF konvertieren**

Dieser C#‑Code demonstriert, wie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertiert werden:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Legen Sie das Array von Foliennummern fest.
int[] slides = { 1, 3 };

// Speichern Sie die Präsentation als PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation in PDF mit einer angegebenen Foliengröße konvertiert wird:
```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```


## **PowerPoint zu PDF im Notizfolien‑Ansicht konvertieren**

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation in ein PDF konvertiert wird, das Notizen enthält:
```c#
// Laden Sie eine PowerPoint-Präsentation.
using var presentation = new Presentation("NotesFile.pptx");

// Konfigurieren Sie die PDF-Optionen mit Notizlayout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Speichern Sie die Präsentation als PDF mit Notizen.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem dieser Compliance‑Standards, **PDF/A1a**, **PDF/A1b** und **PDF/UA**, nach PDF exportieren.

Dieser C#‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:
```c#
using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), und [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), und [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterieren und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF passwortgeschützt zu sichern?**

Natürlich. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbinden?**

Setzen Sie die Eigenschaft `ShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) auf `true`, um versteckte Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Eigenschaften wie `JpegQuality` und `SufficientResolution` in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) festlegen, um hochqualitative Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards, einschließlich PDF/A1a, PDF/A1b und PDF/UA, entsprechen, sodass Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für .NET Dokumentation](/slides/de/net/)
- [Aspose.Slides für .NET API-Referenz](https://reference.aspose.com/slides/net/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)