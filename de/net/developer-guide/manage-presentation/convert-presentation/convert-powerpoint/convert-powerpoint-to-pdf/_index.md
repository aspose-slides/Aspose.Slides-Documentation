---
title: Konvertieren Sie PPT und PPTX zu PDF in C# [Erweiterte Funktionen enthalten]
linktitle: PPT und PPTX zu PDF konvertieren
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
- ODP zu PDF
- ODP zu PDF konvertieren
- PowerPoint als PDF speichern
- PDF/A1a
- PDF/A1b
- PDF/UA
- C#
- Csharp
- .NET
- Aspose.Slides for .NET
description: "Erfahren Sie, wie Sie PPT-, PPTX- und ODP-Präsentationen mit Aspose.Slides in C# oder .NET zu PDF konvertieren. Implementieren Sie erweiterte Funktionen wie Passwortschutz, Compliance-Standards und benutzerdefinierte Optionen für hochwertige, barrierefreie PDF-Dokumente."
---

## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in C# bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Erhalten des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie man Präsentationen in PDF-Dokumente konvertiert, verschiedene Optionen verwendet, um die Bildqualität zu steuern, versteckte Folien einzuschließen, PDF-Dateien mit einem Passwort zu schützen, Schriftarten‑Ersetzungen zu erkennen, bestimmte Folien für die Konvertierung auszuwählen und Compliance‑Standards auf die Ausgabedokumente anzuwenden.

## **PowerPoint-zu-PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und speichern dann die Präsentation mit der Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) als PDF. Die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) stellt die Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="HINWEIS" color="warning" %}} 
Aspose.Slides für .NET fügt seine API-Informationen und Versionsnummer in Ausgabedokumente ein. Zum Beispiel füllt Aspose.Slides beim Konvertieren einer Präsentation zu PDF das Feld Application mit „*Aspose.Slides*“ und das Feld PDF Producer mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* Gesamten Präsentationen zu PDF
* Spezifischen Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr ähnlich sind. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der standardmäßige PowerPoint-zu-PDF-Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualitätsstufe in PDF zu konvertieren.

Der folgende C#‑Code zeigt, wie man eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertiert:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert color="primary" %}} 
Aspose bietet einen kostenlosen Online-[**PowerPoint-zu-PDF-Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation-zu-PDF-Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu sehen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) – zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort sichern oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden sollen, ein Kompressionsniveau für Text setzen, DPI für Bilder konfigurieren und mehr.

Das nachstehende Codebeispiel demonstriert, wie man eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert:
```c#
// Instanziieren Sie die PdfOptions-Klasse.
var pdfOptions = new PdfOptions
{
    // Legen Sie die Qualität für JPG-Bilder fest.
    JpegQuality = 90,

    // Legen Sie die DPI für Bilder fest.
    SufficientResolution = 300,

    // Definieren Sie das Verhalten für Metadateien.
    SaveMetafilesAsPng = true,

    // Legen Sie die Textkomprimierungsstufe für textuelle Inhalte fest.
    TextCompression = PdfTextCompression.Flate,

    // Definieren Sie den PDF-Konformitätsmodus.
    Compliance = PdfCompliance.Pdf15
};

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Speichern Sie die Präsentation als PDF-Dokument.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) verwenden, um die versteckten Folien als Seiten in das resultierende PDF aufzunehmen.

Der folgende C#‑Code zeigt, wie man eine PowerPoint‑Präsentation mit einbezogenen versteckten Folien in PDF konvertiert:
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

Der folgende C#‑Code demonstriert, wie man eine PowerPoint‑Präsentation mit den Schutzparametern der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) in ein passwortgeschütztes PDF konvertiert:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
var pdfOptions = new PdfOptions();

// Setzen Sie ein PDF-Passwort und Zugriffsrechte.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Speichern Sie die Präsentation als PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Schriftarten‑Ersetzungen erkennen**

Aspose.Slides stellt die Eigenschaft [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) bereit, mit der Sie Schriftarten‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Der folgende C#‑Code zeigt, wie man Schriftarten‑Ersetzungen erkennt:
```c#
public static void Main()
{
    // Instanzieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt. 
    using var presentation = new Presentation("sample.pptx");

    // Setzen Sie den Warn-Callback in den PDF-Optionen.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Speichern Sie die Präsentation als PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementierung des Warn-Callbacks.
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


{{%  alert color="primary" %}} 
Für weitere Informationen zum Empfangen von Callbacks für Schriftarten‑Ersetzungen während des Render‑Vorgangs siehe [Getting Warning Callbacks for Fonts Substitution](/slides/de/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Für weitere Informationen zu Schriftarten‑Ersetzungen siehe den Artikel [Font Substitution](/slides/de/net/font-substitution/).
{{% /alert %}}

## **Ausgewählte Folien von PowerPoint zu PDF konvertieren**

Der folgende C#‑Code demonstriert, wie man nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertiert:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Legen Sie ein Array von Foliennummern fest.
int[] slides = { 1, 3 };

// Speichern Sie die Präsentation als PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Der folgende C#‑Code demonstriert, wie man eine PowerPoint‑Präsentation mit einer angegebenen Foliengröße in PDF konvertiert:
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

Der folgende C#‑Code demonstriert, wie man eine PowerPoint‑Präsentation in ein PDF konvertiert, das Notizen enthält:
```c#
// Laden Sie eine PowerPoint-Präsentation.
using var presentation = new Presentation("NotesFile.pptx");

// Konfigurieren Sie die PDF-Optionen mit Notizenlayout.
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

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument in PDF mit einem dieser Compliance‑Standards exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

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
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) Konvertierungen durchführen. Andere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF passwortgeschützt zu sichern?**

Absolut. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbinden?**

Setzen Sie die Eigenschaft `ShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) auf `true`, um versteckte Folien im resultierenden PDF zu berücksichtigen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Eigenschaften wie `JpegQuality` und `SufficientResolution` in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) festlegen, um hochqualitative Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, wodurch Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung entsprechen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für .NET Dokumentation](/slides/de/net/)
- [Aspose.Slides für .NET API-Referenz](https://reference.aspose.com/slides/net/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)