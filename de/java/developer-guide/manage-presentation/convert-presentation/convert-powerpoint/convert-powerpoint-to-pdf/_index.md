---
title: PPT und PPTX in Java zu PDF konvertieren [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX in Java mit Aspose.Slides in hochqualitative, durchsuchbare PDFs konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in Java bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und das Bewahren des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen werden, PDF‑Dateien mit Passwort geschützt werden, Schriftarten‑Ersetzungen erkannt werden, bestimmte Folien für die Konvertierung ausgewählt werden und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse und speichern dann die Präsentation als PDF mithilfe einer [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode. Die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für Java fügt seine API‑Informationen und Versionsnummer in AusgAbedokumente ein. Zum Beispiel befüllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis** dass Sie Aspose.Slides nicht anweisen können, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren:

* Ganze Präsentationen nach PDF
* Bestimmte Folien einer Präsentation nach PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung genau gerendert, einschließlich:

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

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Exporteinstellungen in PDF.

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
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test für die hier beschriebene Vorgehensweise durchführen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Vorgehen des Konvertierungsprozesses festlegen können.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Raster‑Bilder festlegen, bestimmen, wie Metadateien verarbeitet werden, ein Komprimierungsniveau für Text festlegen, die DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit JPEG‑Qualität von 90, Bildauflösung von 300 DPI, Metadateien als PNG gespeichert und Flate‑Textkompression.

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

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien einsehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, aber die eingebettete Datei wird nicht als Anhang hinzugefügt. Wird die Option auf `true` gesetzt, werden zusätzlich die Dateidaten eingebunden. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht Empfängern das getrennte Öffnen oder Speichern der eingebetteten Datei. Das OLE‑Objekt wird auf der PDF‑Seite nicht zu einem interaktiven Excel‑Arbeitsblatt.

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

So prüfen Sie das Ergebnis:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist getrennt vom Anhang.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Vorgaben der Standards, keine spezifischen Beschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Konformitätseinstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint in PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) nutzen, um die versteckten Folien als Seiten im resultierenden PDF einzubeziehen.

Das folgende Beispiel exportiert eine Präsentation nach PDF und schließt dabei alle versteckten Folien ein.

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

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das das Passwort `password` zum Öffnen benötigt. Die Zugriffsrechte erlauben das Drucken, einschließlich Druck in hoher Qualität.

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

### **Schriftarten‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) in der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) bereit, mit der Sie während des Präsentation‑zu‑PDF‑Konvertierungsprozesses Schriftarten‑Ersetzungen erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Schriftarten‑Ersetzungswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird.

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
Weitere Informationen zu Schriftarten‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/java/font-substitution/).
{{% /alert %}} 

## **Ausgewählte Folien von PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Folienzahlen in diesem Array beginnen bei eins, und die Eingabepäsentation muss mindestens drei Folien enthalten.

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

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt, sodass er passt, und exportiert die einzelne Folie nach PDF.

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

    // Entfernen Sie die leere Folie, mit der die neue Präsentation erstellt wurde.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint in PDF im Notizfolien‑Modus konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Referenten‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Referenten‑Notizen, um das Ergebnis zu sehen.

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

## **Barrierefreiheit und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument nach PDF exportieren, wobei Sie einen der folgenden Konformitätsstandards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der basierend auf verschiedenen Konformitätsstandards mehrere PDFs erzeugt:

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
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Dateiformate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte gekennzeichnet werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien gleichzeitig in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ verarbeiten und den Konvertierungsprozess programmatisch anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses festzulegen.

**Wie kann ich versteckte Folien in das PDF einbinden?**

Rufen Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) mit `true` in der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) auf, um versteckte Folien in das resultierende PDF einzubeziehen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) und [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides die PDF/A‑Konformitätsstandards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung genügen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Java Dokumentation](/slides/de/java/)
- [Aspose.Slides für Java API‑Referenz](https://reference.aspose.com/slides/java/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)