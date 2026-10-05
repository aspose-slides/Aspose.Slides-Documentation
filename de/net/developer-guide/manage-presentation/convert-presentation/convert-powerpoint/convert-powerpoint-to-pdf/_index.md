---
title: PPT und PPTX zu PDF konvertieren in .NET [Erweiterte Funktionen enthalten]
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
- PPT zu PDF exportieren
- PPTX zu PDF exportieren
- Anhang
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in .NET mit Aspose.Slides, inklusive schneller C#-Codebeispiele und erweiterter Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in C# bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Beibehalten des Layouts und der Formatierung Ihrer Präsentation. Diese Anleitung zeigt, wie Sie Präsentationen in PDF‑Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität verwenden, versteckte Folien einbinden, PDF‑Dateien mit einem Kennwort schützen, Schriftartsubstitutionen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance‑Standards auf die Ausgabedokumente anwenden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und speichern Sie die Präsentation anschließend mit der Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) als PDF. Die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) stellt die Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für .NET fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* Gesamte Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs der Originalpräsentation sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung genau gerendert, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und höchstmöglicher Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den standardmäßigen Exporteinstellungen als PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können diesen Konverter testen, um eine Live‑Umsetzung des hier beschriebenen Verfahrens zu sehen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen—Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Kennwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Durch die Verwendung benutzerdefinierter Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, festlegen, wie Metadateien verarbeitet werden sollen, ein Kompressionslevel für Text einstellen, die DPI für Bilder konfigurieren und vieles mehr.

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

### **Eingebettete OLE‑Dateien als PDF‑Anhänge beibehalten**

Wenn eine Präsentation eine eingebettete Excel‑Arbeitsmappe enthält, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl auf die Daten der Arbeitsmappe zugreifen als auch die Folien ansehen können. Setzen Sie [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) auf `true`, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF beizubehalten.

Der Standardwert ist `false`: Das Vorschau‑Bild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite dargestellt, aber die eingebettete Datei wird nicht als Anhang hinzugefügt. Durch Setzen der Option auf `true` werden außerdem die Dateidaten hinzugefügt. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es den Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie als PDF mit der angehängten Arbeitsmappe.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Um das Ergebnis zu überprüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies erlaubt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Anforderungen der Standards, keine Einschränkungen, die speziell für Aspose.Slides gelten. Dieses Beispiel verwendet die standardmäßige PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint in PDF mit versteckten Folien konvertieren**

Wenn eine Präsentation versteckte Folien enthält, können Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Kennwort `password` erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich hochqualitativen Drucks.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Schriftartsubstitutionen erkennen**

Aspose.Slides stellt die Eigenschaft [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) bereit, die es Ihnen ermöglicht, während des Präsentation‑zu‑PDF‑Konvertierungsprozesses Schriftartsubstitutionen zu erkennen.

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
Für weitere Informationen zur Schriftartsubstitution siehe den Artikel [Schriftartsubstitution](/slides/de/net/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien von PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Foliennummern in diesem Array beginnen bei 1, und die Eingabepäsentation muss mindestens drei Folien enthalten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt, um ihn anzupassen, und exportiert die einzelne Folie nach PDF.

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

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Rednernotizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Rednernotizen, um das Ergebnis zu sehen.

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

Aspose.Slides ermöglicht Ihnen ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument in PDF exportieren, wobei Sie einen dieser Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser C#‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

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
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) Umwandlungen durchführen. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten—[PDF zu SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien iterieren und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Kennwort zu schützen?**

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), um ein Kennwort festzulegen und Zugriffsberechtigungen während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbinden?**

Setzen Sie die Eigenschaft [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) auf `true`, um versteckte Folien im resultierenden PDF zu berücksichtigen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Eigenschaften wie [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) und [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) in der Klasse [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) festlegen, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die verschiedenen Standards entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, wodurch Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung entsprechen.

## **Weitere Ressourcen**

- [Aspose.Slides für .NET Dokumentation](/slides/de/net/)
- [Aspose.Slides für .NET API‑Referenz](https://reference.aspose.com/slides/net/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)