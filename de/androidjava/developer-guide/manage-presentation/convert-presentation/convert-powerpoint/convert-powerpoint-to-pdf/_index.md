---
title: PPT und PPTX auf Android in PDF konvertieren [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/androidjava/convert-powerpoint-to-pdf/
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
- Anhang
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint‑PPT/PPTX in hochwertige, durchsuchbare PDFs in Java mit Aspose.Slides für Android, inklusive schneller Code‑Beispiele und erweiterter Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint-Präsentationen (PPT, PPTX, ODP usw.) in das PDF-Format auf Android bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und das Bewahren des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF-Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet, ausgeblendete Folien einbezogen, PDF-Dateien passwortgeschützt werden, Schriftartsubstitutionen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance-Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)-Klasse und speichern Sie die Präsentation anschließend als PDF mithilfe der [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)-Methode. Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)-Klasse stellt die [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)-Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für Android via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht die Konvertierung von:
* Komplette Präsentationen nach PDF
* Bestimmte Folien einer Präsentation nach PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:
* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der standardmäßige PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximalen Qualitätsstufen in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Exporteinstellungen als PDF.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides bietet benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) –, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, einen Komprimierungsgrad für Text setzen, DPI‑Werte für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit einer JPEG‑Qualität von 90, einer Bildauflösung von 300 DPI, Metadateien, die als PNG gespeichert werden, und einer Flate‑Textkomprimierung.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl auf die Daten der Arbeitsmappe als auch die Folien zugreifen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild bzw. das Symbol des OLE‑Objekts wird auf der PDF‑Seite dargestellt, aber die eingebettete Datei wird nicht als Anhang hinzugefügt. Wird die Option auf `true` gesetzt, werden zusätzlich die Dateidaten eingebettet. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie nach PDF mit der angehängten Arbeitsmappe.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Um das Ergebnis zu prüfen:
1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Anforderungen der Standards, keine spezifischen Beschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint in PDF mit ausgeblendeten Folien konvertieren**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) verwenden, um die ausgeblendeten Folien als Seiten im resultierenden PDF einzuschließen.

Das folgende Beispiel exportiert eine Präsentation nach PDF und schließt dabei alle ausgeblendeten Folien ein.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das das Passwort `password` zum Öffnen erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich hochqualitativen Druckens.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Schriftartsubstitutionen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) bereit, mit der Sie Schriftartsubstitutionen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Schriftartsubstitutionswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart substituiert wird.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Weitere Informationen zu Schriftartsubstitutionen finden Sie im Artikel [Font Substitution](/slides/de/androidjava/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien von PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Folienzahlen in diesem Array beginnen bei eins, und die Eingabepräsentation muss mindestens drei Folien enthalten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt passend und exportiert die einzelne Folie nach PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Entferne die leere Folie, die bei der Erstellung der neuen Präsentation hinzugefügt wurde.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint in PDF im Notizfolien‑Ansicht konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Rednernotizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Rednernotizen, um das Ergebnis zu sehen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument nach PDF exportieren und dabei einen der folgenden Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können Konvertierungen zu [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) durchführen. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) und [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien auf einmal in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF passwortgeschützt zu speichern?**

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich ausgeblendete Folien in das PDF einbeziehen?**

Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) mit `true` in der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) auf, um ausgeblendete Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) und [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in der Klasse [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides die PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente die Anforderungen an Barrierefreiheit und Archivierung erfüllen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Android via Java Dokumentation](/slides/de/androidjava/)
- [Aspose.Slides für Android via Java API-Referenz](https://reference.aspose.com/slides/androidjava/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)