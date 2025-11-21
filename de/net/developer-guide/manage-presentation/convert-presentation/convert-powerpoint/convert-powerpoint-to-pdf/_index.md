---
title: Konvertieren von PPT und PPTX zu PDF in .NET [Erweiterte Funktionen enthalten]
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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in .NET mit Aspose.Slides, mit schnellen C#-Codebeispielen und erweiterten Konvertierungsoptionen."
---

## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in C# bietet mehrere Vorteile, darunter die Kompatibilität mit verschiedenen Geräten und das Erhalten des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen, PDF‑Dateien passwortgeschützt, Schriftarten‑Ersetzungen erkannt, bestimmte Folien zur Konvertierung ausgewählt und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mithilfe der [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse stellt die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für .NET fügt API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Anwendungsfeld mit „*Aspose.Slides*“ und das PDF‑Producer‑Feld mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren:

* Komplette Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs eng an den Originalpräsentationen bleiben. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint‑zu‑PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und höchster Qualität in PDF zu konvertieren.

Dieser C#‑Code zeigt, wie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertiert wird:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online‑**PowerPoint‑zu‑PDF‑Konverter** an, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu sehen.

{{% /alert %}}

## **PowerPoint‑zu‑PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) – zur Verfügung, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Vorgehen des Konvertierungsprozesses festlegen können.

### **PowerPoint‑zu‑PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugten Qualitätseinstellungen für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionsniveau für Text setzen, DPI für Bilder konfigurieren und mehr.

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


### **PowerPoint‑zu‑PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

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


### **PowerPoint‑zu‑passwortgeschütztem PDF konvertieren**

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation mit den Schutzparametern der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) in ein passwortgeschütztes PDF konvertiert wird:
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

Aspose.Slides stellt die Eigenschaft [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) bereit, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Dieser C#‑Code zeigt, wie Schriftart‑Ersetzungen erkannt werden:
```c#
public static void Main()
{
    // Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt. 
    using var presentation = new Presentation("sample.pptx");

    // Setzen Sie den Warnungs‑Callback in den PDF‑Optionen.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Speichern Sie die Präsentation als PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementierung des Warnungs‑Callbacks.
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

Für weitere Informationen zum Empfangen von Callbacks für Schriftart‑Ersetzungen während des Rendering‑Prozesses siehe [Getting Warning Callbacks for Fonts Substitution](/slides/de/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/net/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien aus PowerPoint in PDF konvertieren**

Dieser C#‑Code demonstriert, wie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertiert werden:
```c#
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Array von Folienzahlen festlegen.
int[] slides = { 1, 3 };

// Speichern Sie die Präsentation als PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **PowerPoint‑zu‑PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation mit einer angegebenen Foliengröße in PDF konvertiert wird:
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


## **PowerPoint‑zu‑PDF im Notizfolien‑Ansicht konvertieren**

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation in ein PDF konvertiert wird, das Notizen enthält:
```c#
// Lade eine PowerPoint-Präsentation.
using var presentation = new Presentation("NotesFile.pptx");

// Konfiguriere die PDF-Optionen mit Notizen-Layout.
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


## **Barrierefreiheit und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument in PDF exportieren und dabei einen der folgenden Konformitätsstandards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C#‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf verschiedenen Konformitätsstandards erzeugt:
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

Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können die Konvertierungen [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) durchführen. Weitere PDF‑Konvertierungsoperationen in spezialisierte Formate – [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) und [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterieren und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF passwortgeschützt zu speichern?**

Natürlich. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbeziehen?**

Setzen Sie die Eigenschaft `ShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) auf `true`, um versteckte Folien im resultierenden PDF einzuschließen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Eigenschaften wie `JpegQuality` und `SufficientResolution` in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) festlegen, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Konformitätsstandards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente Barrierefreiheit und Archivierungsanforderungen erfüllen.

## **Weitere Ressourcen**

- [Aspose.Slides für .NET Dokumentation](/slides/de/net/)
- [Aspose.Slides für .NET API‑Referenz](https://reference.aspose.com/slides/net/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)