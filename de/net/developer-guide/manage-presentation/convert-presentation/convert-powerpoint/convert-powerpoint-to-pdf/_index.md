---
title: PPT und PPTX in PDF konvertieren in .NET [Erweiterte Funktionen enthalten]
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
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in .NET mit Aspose.Slides konvertieren, mit schnellen C#-Code-Beispielen und erweiterten Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in C# bietet mehrere Vorteile, darunter Kompatibilität auf verschiedenen Geräten und das Erhalten des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Sie Präsentationen in PDF‑Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität verwenden, ausgeblendete Folien einbeziehen, PDF‑Dateien mit einem Passwort schützen, Schriftart‑Ersetzungen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance‑Standards auf Ausgabedokumente anwenden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit einer [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse stellt die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für .NET fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld „Application“ mit „*Aspose.Slides*“ und das Feld „PDF Producer“ mit einem Wert im Format „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht Ihnen die Konvertierung von:

* gesamten Präsentationen zu PDF
* bestimmten Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs den Originalpräsentationen sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Der folgende C#‑Code zeigt, wie Sie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertieren:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse – bereit, mit denen Sie das resultierende PDF anpassen, es mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionsniveau für Text setzen, DPI für Bilder konfigurieren und mehr.

Das folgende Code‑Beispiel demonstriert, wie Sie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertieren.
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

    // Legen Sie die Textkomprimierungsstufe für Textinhalte fest.
    TextCompression = PdfTextCompression.Flate,

    // Definieren Sie den PDF-Konformitätsmodus.
    Compliance = PdfCompliance.Pdf15
};

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Speichern Sie die Präsentation als PDF-Dokument.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **PowerPoint in PDF mit ausgeblendeten Folien konvertieren**

Enthält eine Präsentation ausgeblendete Folien, können Sie die [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/)‑Eigenschaft der [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse verwenden, um die ausgeblendeten Folien als Seiten in das resultierende PDF aufzunehmen.

Der folgende C#‑Code zeigt, wie Sie eine PowerPoint‑Präsentation mit einbezogenen ausgeblendeten Folien in PDF konvertieren:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
var pdfOptions = new PdfOptions();

// Ausgeblendete Folien hinzufügen.
pdfOptions.ShowHiddenSlides = true;

// Speichern Sie die Präsentation als PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **PowerPoint in passwortgeschütztes PDF konvertieren**

Der folgende C#‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit einem Passwort geschützten PDF mithilfe der Schutz‑Parameter der [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse konvertieren:
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


### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/)‑Eigenschaft der [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse bereit, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Der folgende C#‑Code zeigt, wie Sie Schriftart‑Ersetzungen erkennen:
```c#
public static void Main()
{
    // Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt. 
    using var presentation = new Presentation("sample.pptx");

    // Legen Sie den Warning‑Callback in den PDF‑Optionen fest.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Speichern Sie die Präsentation als PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementierung des Warning‑Callbacks.
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

Weitere Informationen zum Empfangen von Callbacks für Schriftart‑Ersetzungen während des Renderings finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Details zur Schriftart‑Ersetzung finden Sie im Artikel [Font Substitution](/slides/de/net/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien einer PowerPoint‑Präsentation in PDF konvertieren**

Der folgende C#‑Code demonstriert, wie Sie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Legen Sie ein Array von Foliennummern fest.
int[] slides = { 1, 3 };

// Speichern Sie die Präsentation als PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Der folgende C#‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation mit einer angegebenen Foliengröße in PDF konvertieren:
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


## **PowerPoint in PDF im Notiz‑Folien‑Ansicht konvertieren**

Der folgende C#‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation in ein PDF konvertieren, das Notizen enthält:
```c#
// Lade eine PowerPoint-Präsentation.
using var presentation = new Presentation("NotesFile.pptx");

// Konfiguriere die PDF-Optionen mit Notiz-Layout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Speichere die Präsentation als PDF mit Notizen.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht Ihnen ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem der folgenden Compliance‑Standards exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende C#‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:
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


{{% alert title="Hinweis" color="warning" %}} 

Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen, sodass Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungs‑Operationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien in einem Batch‑Vorgang in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Selbstverständlich. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich ausgeblendete Folien in das PDF aufnehmen?**

Setzen Sie die Eigenschaft `ShowHiddenSlides` in der [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse auf `true`, um ausgeblendete Folien im resultierenden PDF zu inkludieren.

**Kann Aspose.Slides hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Eigenschaften wie `JpegQuality` und `SufficientResolution` in der [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)‑Klasse setzen, um hochwertige Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente Barrierefreiheit und Archivierungsanforderungen erfüllen.

## **Weitere Ressourcen**

- [Aspose.Slides für .NET‑Dokumentation](/slides/de/net/)
- [Aspose.Slides für .NET API‑Referenz](https://reference.aspose.com/slides/net/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)