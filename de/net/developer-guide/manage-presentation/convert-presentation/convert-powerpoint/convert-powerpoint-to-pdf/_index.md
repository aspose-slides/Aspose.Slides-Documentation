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
- PPT in PDF konvertieren
- PPTX zu PDF
- PPTX in PDF konvertieren
- PowerPoint als PDF speichern
- PPT als PDF speichern
- PPTX als PDF speichern
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- Anhang
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in .NET mit Aspose.Slides konvertieren, inklusive schneller C# Code-Beispiele und erweiterter Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in C# bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Bewahren des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Sie Präsentationen in PDF-Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität verwenden, ausgeblendete Folien einbeziehen, PDF-Dateien mit Passwort schützen, Font‑Substitutionen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance‑Standards auf Ausgabedokumente anwenden.

## **PowerPoint zu PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und speichern Sie die Präsentation anschließend als PDF mit der Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) stellt die Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides für .NET fügt seine API-Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit „*Aspose.Slides*“ und das Feld PDF Producer mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis** dass Sie Aspose.Slides nicht anweisen können, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht Ihnen:

* Ganze Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs dem Original sehr nahekommen. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, darunter:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf höchstem Qualitätsniveau in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standardeinstellungen als PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Hinweis" %}}
Aspose bietet einen kostenlosen Online-[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) an, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können einen Test mit diesem Konverter durchführen, um die hier beschriebene Vorgehensweise live zu sehen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) – zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Komprimierungslevel für Text setzen, DPI für Bilder konfigurieren und vieles mehr.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, Metadateien als PNG und Flate‑Textkompression.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Eingebettete OLE‑Dateien als PDF‑Anlagen beibehalten**

Enthält eine Präsentation ein eingebettetes Excel‑Arbeitsbuch, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten des Arbeitsbuchs als auch die Folien einsehen können. Setzen Sie [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) auf `true`, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild bzw. das Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, die eingebettete Datei jedoch nicht als Anhang beigefügt. Wird die Option auf `true` gesetzt, wird zusätzlich die Dateidaten beigefügt. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits ein eingebettetes Excel‑Arbeitsbuch enthält, und exportiert sie nach PDF mit angehängtem Arbeitsbuch.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Um das Ergebnis zu prüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie das eingebettete Arbeitsbuch.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, sofern der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Hinweis" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt weitere Dateitypen, einschließlich Excel‑Arbeitsbüchern. Das sind Anforderungen der Standards, keine Einschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint in PDF mit ausgeblendeten Folien konvertieren**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) verwenden, um die ausgeblendeten Folien als Seiten in das resultierende PDF aufzunehmen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Passwort `password` erfordert. Die Zugriffsrechte ermöglichen das Drucken, einschließlich Druck in hoher Qualität.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Font‑Substitutionen erkennen**

Aspose.Slides stellt die Eigenschaft [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) bereit, mit der Sie Font‑Substitutionen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Font‑Substitutionswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart substituiert wird.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Hinweis" %}}
Weitere Informationen zu Font‑Substitutionen finden Sie im Artikel [Font‑Substitution](/slides/de/net/font-substitution/).
{{% /alert %}} 

### **Schriften ohne dedizierten Fettschriftstil behandeln**

Eine Präsentation kann Text fett formatieren, obwohl die verwendete Schriftart keinen eigenen Fettschriftstil besitzt. Der Text kann dennoch durch synthetisches Fetten hervorgehoben werden, was die regulären Glyphen künstlich verdickt. Wenn dieser Text zu schwer erscheint oder sonst von der gewünschten Darstellung im PDF abweicht, versuchen Sie, [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) auf `true` zu setzen. Diese Option rendert den betroffenen Text beim PDF‑Export als Bitmap und kann das Aussehen für bestimmte Schriften verbessern. Der Standardwert ist `false`.

Die Beispieldatei enthält zwei Textfelder: eines mit normalem Text und eines mit fetter Formatierung derselben Schriftart, die keinen eigenen Fettschriftstil hat. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Schriftstil‑Varianten und exportiert sie nach PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

Die folgenden Vorschaubilder zeigen das Ergebnis mit deaktivierter bzw. aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option schwerere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel führt das Aktivieren der Option dazu, dass nur der fette Text als Bitmap erzeugt wird: Er kann nicht ausgewählt, kopiert oder ohne OCR als Text durchsucht werden, und seine Kanten wirken bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text erhalten.

Diese Option rasterisiert Text, der als fett formatiert ist, wenn die Schriftart keinen eigenen Fettschriftstil besitzt. [Font‑Substitution](/slides/de/net/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die Originalschrift nicht verfügbar ist.

## **Ausgewählte Folien von PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Folienzahlen in diesem Array beginnen bei 1, und die Eingabedatei muss mindestens drei Folien enthalten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Der Folieninhalt wird skaliert, damit er passt, und die einzelne Folie wird nach PDF exportiert.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **PowerPoint in PDF im Notizfolien‑Modus konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF, wobei die Sprecher‑Notizen jeder Folie unterhalb der Folie platziert werden. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht Ihnen die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument nach PDF exportieren und dabei einen der folgenden Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende C#‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs auf Basis verschiedener Compliance‑Standards erzeugt:

```csharp
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

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint-Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien programmgesteuert durchlaufen und den Konvertierungsprozess anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich ausgeblendete Folien in das PDF aufnehmen?**

Setzen Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) auf `true`, um ausgeblendete Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Eigenschaften wie [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) und [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) festlegen, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht Ihnen den Export von PDFs, die verschiedenen Standards entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung genügen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für .NET Dokumentation](/slides/de/net/)
- [Aspose.Slides für .NET API-Referenz](https://reference.aspose.com/slides/net/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)