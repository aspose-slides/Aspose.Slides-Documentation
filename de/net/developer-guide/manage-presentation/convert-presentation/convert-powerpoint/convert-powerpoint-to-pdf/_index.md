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
description: "PowerPoint PPT/PPTX in .NET mit Aspose.Slides in hochwertige, durchsuchbare PDFs konvertieren, mit schnellen C#-Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in C# bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieses Handbuch zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen, PDF‑Dateien mit einem Passwort geschützt, Schriftarten‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Klasse und speichern die Präsentation anschließend mit der [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/)-Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Klasse stellt die [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/)-Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides für .NET fügt seinen API‑Informationen und die Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren:

* Gesamte Präsentationen in PDF
* Einzelner Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs den Originalpräsentationen sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualitätsstufe in PDF zu konvertieren.

Dieser C#‑Code zeigt, wie eine Präsentation (PPT, PPTX, ODP usw.) in PDF konvertiert wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.ppt");

// Speichern Sie die Präsentation als PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live umzusetzen.

{{% /alert %}}

## **PowerPoint in PDF konvertieren mit Optionen**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/)-Klasse – bereit, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF konvertieren mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, einen Komprimierungsgrad für Text setzen, DPI für Bilder konfigurieren und vieles mehr.

Das folgende Codebeispiel demonstriert, wie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die PdfOptions-Klasse.
var pdfOptions = new PdfOptions
{
    // Legen Sie die Qualität für JPG-Bilder fest.
    JpegQuality = 90,

    // Legen Sie die DPI für Bilder fest.
    SufficientResolution = 300,

    // Definieren Sie das Verhalten für Metadateien.
    SaveMetafilesAsPng = true,

    // Legen Sie die Textkomprimierungsstufe für Textinhalte fest.
    TextCompression = PdfTextCompression.Flate,

    // Definieren Sie den PDF-Compliance-Modus.
    Compliance = PdfCompliance.Pdf15
};

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Speichern Sie die Präsentation als PDF-Dokument.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint in PDF konvertieren mit versteckten Folien**

Enthält eine Präsentation versteckte Folien, können Sie die [ShowHiddenSlides](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/showhiddenslides/)-Eigenschaft der [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/)-Klasse verwenden, um die versteckten Folien als Seiten in das resultierende PDF aufzunehmen.

Dieser C#‑Code zeigt, wie eine PowerPoint‑Präsentation in PDF konvertiert wird, wobei versteckte Folien eingebunden werden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanziieren Sie die PdfOptions-Klasse.
var pdfOptions = new PdfOptions();

// Versteckte Folien hinzufügen.
pdfOptions.ShowHiddenSlides = true;

// Speichern Sie die Präsentation als PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint in passwortgeschütztes PDF konvertieren**

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation mittels der Schutzparameter der [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/)-Klasse in ein passwortgeschütztes PDF konvertiert wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides stellt die [WarningCallback](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveoptions/warningcallback/)-Eigenschaft der [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/)-Klasse bereit, mit der Sie Schriftarten‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Dieser C#‑Code zeigt, wie Schriftarten‑Ersetzungen erkannt werden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt. 
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

{{%  alert color="info"  %}} 

Weitere Informationen zum Empfangen von Callbacks für Schriftarten‑Ersetzungen während des Renderings finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zur Schriftarten‑Ersetzung finden Sie im Artikel [Font Substitution](/slides/de/net/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien aus PowerPoint in PDF konvertieren**

Dieser C#‑Code demonstriert, wie nur bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertiert werden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
using var presentation = new Presentation("PowerPoint.pptx");

// Legen Sie ein Array von Foliennummern fest.
int[] slides = { 1, 3 };

// Speichern Sie die Präsentation als PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation mit einer festgelegten Foliengröße in PDF konvertiert wird:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Laden Sie eine PowerPoint-Präsentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Erstellen Sie eine neue Präsentation mit angepasster Foliengröße.
using var resizedPresentation = new Presentation();

// Legen Sie die benutzerdefinierte Foliengröße fest.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Klonen Sie die erste Folie der Originalpräsentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Entfernen Sie die leere Folie, mit der die neue Präsentation erstellt wurde.
resizedPresentation.Slides.RemoveAt(1);

// Speichern Sie die skalierte Präsentation als PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **PowerPoint in PDF im Notiz‑Folien‑Modus konvertieren**

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation in ein PDF konvertiert wird, das die Notizen beinhaltet:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Laden Sie eine PowerPoint-Präsentation.
using var presentation = new Presentation("NotesFile.pptx");

// Konfigurieren Sie die PDF-Optionen mit Notiz-Layout.
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

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem der folgenden Compliance‑Standards in PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C#‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Dateiformate umwandeln können. Sie können [PDF zu HTML](https://products.aspose.com/slides/de/net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/de/net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/de/net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/de/net/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/de/net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/de/net/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/de/net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte gekennzeichnet werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

### Kann ich mehrere PowerPoint‑Dateien gleichzeitig in PDF konvertieren?

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

### Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?

Absolut. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/)-Klasse, um ein Passwort festzulegen und Zugriffsberechtigungen während des Konvertierungsprozesses zu definieren.

### Wie kann ich versteckte Folien in das PDF einbinden?

Setzen Sie die `ShowHiddenSlides`‑Eigenschaft in der [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/)-Klasse auf `true`, um versteckte Folien in das resultierende PDF aufzunehmen.

### Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?

Ja, Sie können die Bildqualität steuern, indem Sie Eigenschaften wie `JpegQuality` und `SufficientResolution` in der [PdfOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/)-Klasse festlegen, um hochwertige Bilder in Ihrem PDF sicherzustellen.

### Unterstützt Aspose.Slides die PDF/A‑Compliance‑Standards?

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den verschiedenen Standards PDF/A1a, PDF/A1b und PDF/UA entsprechen, wodurch Ihre Dokumente Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Weitere Ressourcen**

- [Aspose.Slides für .NET Dokumentation](/slides/de/net/)
- [Aspose.Slides für .NET API‑Referenz](https://reference.aspose.com/slides/de/net/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)