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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in .NET mit Aspose.Slides, inklusive schneller C#-Beispielcode und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in C# bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF-Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, ausgeblendete Folien einbezogen werden, PDF-Dateien mit einem Passwort geschützt werden, Schriftarten-Ersetzungen erkannt werden, bestimmte Folien für die Konversion ausgewählt werden und Compliance-Standards auf die Ausgabedokumente angewendet werden.

## **PowerPoint zu PDF-Konvertierungen**

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) und speichern die Präsentation anschließend mit der Methode [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) als PDF. Die Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) stellt die Methode [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/) zur Verfügung, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="HINWEIS"  color="warning"   %}} 
Aspose.Slides für .NET fügt seinen API-Informationen und die Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht:
* Ganze Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen zu PDF und stellt sicher, dass die resultierenden PDFs die Originalpräsentationen genau widerspiegeln. Elemente und Attribute werden in der Konvertierung exakt gerendert, einschließlich:
* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint-zu-PDF-Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und höchster Qualität in PDF zu konvertieren.

Der folgende C#‑Code zeigt, wie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertiert wird:
```c#
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert.
using var presentation = new Presentation("PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 
Aspose bietet einen kostenlosen Online-**PowerPoint-zu-PDF-Konverter**(https://products.aspose.app/slides/de/conversion/ppt-to-pdf) an, der den Präsentation-zu-PDF-Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live umzusetzen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides bietet benutzerdefinierte Optionen - Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/) - die es Ihnen ermöglichen, das resultierende PDF anzupassen, das PDF mit einem Passwort zu sperren oder festzulegen, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionsniveau für Text festlegen, die DPI für Bilder konfigurieren und mehr.

Das nachstehende Codebeispiel zeigt, wie eine PowerPoint-Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird.
```c#
// Instanziieren Sie die PdfOptions‑Klasse.
var pdfOptions = new PdfOptions
{
    // Legen Sie die Qualität für JPG‑Bilder fest.
    JpegQuality = 90,

    // Legen Sie die DPI für Bilder fest.
    SufficientResolution = 300,

    // Legen Sie das Verhalten für Metadateien fest.
    SaveMetafilesAsPng = true,

    // Legen Sie die Textkomprimierungsstufe für Textinhalt fest.
    TextCompression = PdfTextCompression.Flate,

    // Definieren Sie den PDF‑Compliance‑Modus.
    Compliance = PdfCompliance.Pdf15
};

// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Speichern Sie die Präsentation als PDF‑Dokument.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint in PDF mit ausgeblendeten Folien konvertieren**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/) verwenden, um die ausgeblendeten Folien als Seiten im resultierenden PDF einzufügen.

Der folgende C#‑Code zeigt, wie eine PowerPoint‑Präsentation in PDF konvertiert wird, wobei ausgeblendete Folien eingeschlossen werden:
```c#
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanziieren Sie die PdfOptions‑Klasse.
var pdfOptions = new PdfOptions();

// Fügen Sie ausgeblendete Folien hinzu.
pdfOptions.ShowHiddenSlides = true;

// Speichern Sie die Präsentation als PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint in passwortgeschützte PDF konvertieren**

Der folgende C#‑Code demonstriert, wie eine PowerPoint‑Präsentation mit den Schutzparametern der Klasse [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/) in ein passwortgeschütztes PDF konvertiert wird:
```c#
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanziieren Sie die PdfOptions‑Klasse.
var pdfOptions = new PdfOptions();

// Legen Sie ein PDF‑Passwort und Zugriffsberechtigungen fest.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Speichern Sie die Präsentation als PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Eigenschaft [WarningCallback](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveoptions/warningcallback/) der Klasse [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/) bereit, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Der folgende C#‑Code zeigt, wie Schriftart‑Ersetzungen erkannt werden:
```c#
public static void Main()
{
    // Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert. 
    using var presentation = new Presentation("sample.pptx");

    // Setzen Sie den Warn‑Callback in den PDF‑Optionen.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Speichern Sie die Präsentation als PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementierung des Warn‑Callbacks.
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
Weitere Informationen zum Empfangen von Callbacks für Schriftart‑Ersetzungen während des Rendering‑Prozesses finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zur Schriftart‑Ersetzung finden Sie im Artikel [Font Substitution](/slides/de/net/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien von PowerPoint in PDF konvertieren**

Der folgende C#‑Code zeigt, wie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertiert werden:
```c#
// Instanziieren Sie die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei repräsentiert.
using var presentation = new Presentation("PowerPoint.pptx");

// Legen Sie ein Array von Foliennummern fest.
int[] slides = { 1, 3 };

// Speichern Sie die Präsentation als PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Der folgende C#‑Code demonstriert, wie eine PowerPoint‑Präsentation mit einer festgelegten Foliengröße in PDF konvertiert wird:
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

## **PowerPoint in PDF im Notizfolien‑Ansicht konvertieren**

Der folgende C#‑Code zeigt, wie eine PowerPoint‑Präsentation in ein PDF konvertiert wird, das Notizen enthält:
```c#
// Laden Sie eine PowerPoint-Präsentation.
using var presentation = new Presentation("NotesFile.pptx");

// Konfigurieren Sie die PDF-Optionen mit Notizen-Layout.
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

## **Barrierefreiheit und Compliance-Standards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint-Dokument mit einem der folgenden Compliance-Standards nach PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende C#‑Code demonstriert einen PowerPoint-zu-PDF-Konvertierungsprozess, der mehrere PDFs basierend auf verschiedenen Compliance-Standards erzeugt:
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
Aspose.Slides unterstützt PDF-Konvertierungsoperationen, sodass Sie PDF-Dateien in gängige Dateiformate konvertieren können. Sie können [PDF to HTML](https://products.aspose.com/slides/de/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/de/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/de/net/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/de/net/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF-Konvertierungsoperationen zu speziellen Formaten — [PDF to SVG](https://products.aspose.com/slides/de/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/de/net/conversion/pdf-to-tiff/), und [PDF to XML](https://products.aspose.com/slides/de/net/conversion/pdf-to-xml/) — werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren zu PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als ein einzelnes Bild. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für das gesamte Bild bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Absolut. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/), um während des Konvertierungsprozesses ein Passwort festzulegen und Zugriffsrechte zu definieren.

**Wie kann ich ausgeblendete Folien in das PDF einbeziehen?**

Setzen Sie die Eigenschaft `ShowHiddenSlides` in der Klasse [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/) auf `true`, um ausgeblendete Folien im resultierenden PDF zu berücksichtigen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Eigenschaften wie `JpegQuality` und `SufficientResolution` in der Klasse [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/) setzen, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente Barrierefreiheit und Archivierungsanforderungen erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für .NET Dokumentation](/slides/de/net/)
- [Aspose.Slides für .NET API-Referenz](https://reference.aspose.com/slides/de/net/)
- [Aspose kostenlose Online-Konverter](https://products.aspose.app/slides/de/conversion)