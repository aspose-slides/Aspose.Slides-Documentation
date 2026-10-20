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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in .NET mit Aspose.Slides, mit schnellen C#-Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Die Konvertierung von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format in C# bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Bewahren des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie man Präsentationen in PDF-Dokumente konvertiert, verschiedene Optionen zur Steuerung der Bildqualität verwendet, versteckte Folien einbezieht, PDF‑Dateien mit einem Passwort schützt, Schriftart‑Ersetzungen erkennt, bestimmte Folien für die Konvertierung auswählt und Compliance‑Standards auf Ausgabedokumente anwendet.

## **PowerPoint‑zu‑PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse und speichern die Präsentation anschließend als PDF mit der [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse stellt die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für .NET fügt seine API-Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren:

* gesamte Präsentationen in PDF
* bestimmte Folien einer Präsentation in PDF

Exportiert Aspose.Slides Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Export‑Einstellungen als PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) an, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können diesen Konverter testen, um die hier beschriebene Vorgehensweise live zu sehen.
{{% /alert %}}

## **PowerPoint in PDF konvertieren mit Optionen**

Aspose.Slides stellt benutzerdefinierte Optionen—Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—zur Verfügung, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Vorgehen des Konvertierungsprozesses festlegen können.

### **PowerPoint in PDF konvertieren mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie die bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionsniveau für Text setzen, die DPI für Bilder konfigurieren und vieles mehr.

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

### **Automatische Auswahl der Bildkompression**

Enthält eine Präsentation viele Fotos oder Screenshots, kann die Reduzierung der Größe des exportierten PDFs das Versenden per E‑Mail oder das Herunterladen erleichtern. Setzen Sie [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) auf `true`, um während des PDF‑Exports automatisch den am besten geeigneten Kompressionsalgorithmus für jedes Bild auszuwählen.

Das folgende Beispiel lädt eine vorhandene Präsentation, aktiviert die automatische Auswahl der Bildkompression und speichert sie als PDF‑Dokument. Alle anderen PDF‑Export‑Einstellungen behalten ihre Standardwerte bei.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Diese Option wählt für jedes Bild einen Kompressionsalgorithmus aus. Das Verringern von [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) reduziert die JPEG‑Bildqualität, während das Verringern von [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) es ermöglicht, Bilder auf eine niedrigere Auflösung heruntersampling, was Details reduzieren kann. Das Aktivieren der automatischen Kompressionsauswahl senkt diese Einstellungen nicht selbst.

Die Auswahl von Bildkompressionsalgorithmen erfordert zusätzliche Verarbeitungszeit und Speicher. Die Größenreduktion hängt von den Bildern der Präsentation und den Export‑Einstellungen ab; eine feste Reduktion ist für jede Präsentation nicht garantiert.

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl auf die Daten der Arbeitsmappe als auch auf die Folien zugreifen können. Setzen Sie [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) auf `true`, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Die Vorschaubild‑ oder Symboldarstellung des OLE‑Objekts wird auf der PDF‑Seite gerendert, aber die eingebettete Datei wird nicht als Anhang einbezogen. Wird die Option auf `true` gesetzt, wird zusätzlich die Dateidaten eingeschlossen. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Um das Ergebnis zu prüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Anforderungen der Standards, keine Beschränkungen, die speziell für Aspose.Slides gelten. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint in PDF konvertieren mit versteckten Folien**

Enthält eine Präsentation versteckte Folien, können Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzubeziehen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Passwort `password` erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich Druck in hoher Qualität.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Eigenschaft [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) bereit, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Schriftart‑Ersetzungswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird.

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

{{% alert color="info" title="Note" %}}
Für weitere Informationen zu Schriftart‑Ersetzungen siehe den Artikel [Schriftart‑Ersetzung](/slides/de/net/font-substitution/).
{{% /alert %}} 

### **Umgang mit Schriftarten ohne dedizierten Fettschriftstil**

Eine Präsentation kann Text fett formatieren, selbst wenn die verwendete Schriftart keinen dedizierten Fettschriftstil besitzt. Der Text kann trotzdem durch synthetische Fettung fett erscheinen, wobei die regulären Glyphen künstlich verdickt werden. Sieht dieser Text im PDF zu schwer aus oder weicht anderweitig vom gewünschten Erscheinungsbild ab, versuchen Sie, [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) auf `true` zu setzen. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Erscheinungsbild bei bestimmten Schriftarten verbessern. Der Standardwert ist `false`.

Die Beispielspräsentation enthält zwei Textfelder: eines mit normalem Text und eines mit fetter Formatierung derselben Schriftart, die keinen dedizierten Fettschriftstil hat. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterung nicht unterstützter Schriftstil‑Varianten und exportiert sie nach PDF:

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

Die folgenden Vorschaubilder zeigen die Ausgabe mit deaktivierter und aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option stärkere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel verwandelt das Aktivieren der Option nur den fetten Text in eine Bitmap: Er kann nicht ausgewählt, kopiert oder ohne OCR als Text durchsucht werden, und seine Kanten erscheinen bei 800 %‑Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten Text.

Diese Option rastert Text, der als fett formatiert ist, wenn seine Schriftart keinen dedizierten Fettschriftstil hat. [Schriftart‑Ersetzung](/slides/de/net/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die Originalschrift nicht verfügbar ist.

## **Ausgewählte Folien von PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Folienzahlen in diesem Array beginnen bei eins, und die Eingabepräsentation muss mindestens drei Folien enthalten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint in PDF konvertieren mit benutzerdefinierter Foliengröße**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Der Folieninhalt wird skaliert, um zu passen, und die einzelne Folie wird nach PDF exportiert.

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

## **PowerPoint in PDF im Notizfolien‑Ansicht konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

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

## **Zugänglichkeits‑ und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument nach PDF exportieren, wobei Sie einen der folgenden Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C#‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der basierend auf verschiedenen Compliance‑Standards mehrere PDFs erzeugt:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen und ermöglicht das Konvertieren von PDF‑Dateien in gängige Dateiformate. Sie können [PDF zu HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), und [PDF zu PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungs‑Operationen zu Spezialformaten — [PDF zu SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als eine einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ verarbeiten und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), um während des Konvertierungsprozesses ein Passwort zu setzen und Zugriffsrechte zu definieren.

**Wie füge ich versteckte Folien in das PDF ein?**

Setzen Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) auf `true`, um versteckte Folien in das resultierende PDF einzubeziehen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Eigenschaften wie [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) und [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) setzen, um hochwertige Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente Zugänglichkeits‑ und Archivierungsanforderungen erfüllen.

## **Weitere Ressourcen**

- [Aspose.Slides für .NET Dokumentation](/slides/de/net/)
- [Aspose.Slides für .NET API-Referenz](https://reference.aspose.com/slides/net/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)