---
title: PPT und PPTX nach PDF in Java konvertieren [Erweiterte Funktionen enthalten]
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
description: "PowerPoint PPT/PPTX in Java mit Aspose.Slides in hochwertige, durchsuchbare PDFs konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in Java bietet mehrere Vorteile, darunter die Kompatibilität mit verschiedenen Geräten und das Beibehalten des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Sie Präsentationen in PDF‑Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität verwenden, versteckte Folien einbinden, PDF‑Dateien mit einem Passwort schützen, Schriftart‑Substitutionen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance‑Standards auf die Ausgabedokumente anwenden.

## **PowerPoint-zu-PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und speichern Sie die Präsentation anschließend als PDF mit der Methode [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) stellt die Methode [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für Java fügt in Ausgabedokumente seine API‑Informationen und Versionsnummer ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen in Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht Ihnen das Konvertieren:

* Ganze Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs eng an die Originalpräsentationen angelehnt sind. Elemente und Attribute werden bei der Konvertierung präzise wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardoptionen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien als PDF unter Verwendung der Standard‑Exporteinstellungen.

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
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) an, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen — Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) — zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Raster‑Bilder festlegen, steuern, wie Metadateien behandelt werden, ein Komprimierungs‑Level für Text setzen, die DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, Metadateien als PNG und Flate‑Textkompression.

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

### **Automatische Auswahl der Bildkompression**

Enthält eine Präsentation viele Fotos oder Screenshots, kann das Reduzieren der Größe des exportierten PDFs das Versenden per E‑Mail oder Herunterladen erleichtern. Rufen Sie [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) mit `true` auf, um während des PDF‑Exports für jedes Bild automatisch den am besten geeigneten Komprimierungs‑Algorithmus auszuwählen.

Das folgende Beispiel lädt eine vorhandene Präsentation, aktiviert die automatische Bildkompressionsauswahl und speichert sie als PDF‑Dokument. Alle anderen PDF‑Export‑Einstellungen behalten ihre Standardwerte.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Diese Option wählt für jedes Bild einen Komprimierungs‑Algorithmus aus. Das Herabsetzen des Wertes, der an [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) übergeben wird, reduziert die JPEG‑Bildqualität, während das Herabsetzen des Wertes, der an [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) übergeben wird, Bilder auf eine niedrigere Auflösung downsamplet und damit Details reduzieren kann. Das Aktivieren der automatischen Komprimierung senkt diese Einstellungen nicht selbst.

Die Auswahl von Bild‑Komprimierungs‑Algorithmen erfordert zusätzlichen Verarbeitungs‑ und Speicheraufwand. Die Größenreduktion hängt von den Bildern der Präsentation und den Export‑Einstellungen ab; eine feste Reduktion ist nicht für jede Präsentation garantiert.

### **Einbetten von OLE‑Dateien als PDF‑Anhänge beibehalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien einsehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild bzw. das Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, die eingebettete Datei wird jedoch nicht als Anhang hinzugefügt. Wird die Option auf `true` gesetzt, werden die Dateidaten zusätzlich eingebettet. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie nach PDF mit angehängter Arbeitsmappe.

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
Die PDF/A‑Standards legen Einschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Diese Vorgaben stammen aus den Standards selbst, nicht aus einer Einschränkung von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

Das folgende Beispiel exportiert eine Präsentation nach PDF, wobei alle versteckten Folien mit einbezogen werden.

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

### **PowerPoint zu einem passwortgeschützten PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Passwort `password` erfordert. Die Zugriffs‑Berechtigungen erlauben das Drucken, einschließlich hochqualitativen Drucks.

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

### **Schriftart‑Substitutionen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) bereit, mit der Sie während des Präsentation‑zu‑PDF‑Konvertierungsprozesses Schriftart‑Substitutionen erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Schriftart‑Substitutionswarnungen in der Konsole aus. Eine Warnung wird nur dann ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart substituiert wird.

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
Weitere Informationen zur Schriftart‑Substitution finden Sie im Artikel [Schriftart‑Substitution](/slides/de/java/font-substitution/).
{{% /alert %}}

### **Umgang mit Schriften ohne dedizierten Fettdruck**

Eine Präsentation kann Text fett formatieren, selbst wenn die verwendete Schriftart keinen eigenen Fettdruck enthält. Der Text kann dann synthetisch „fett“ dargestellt werden, indem die regulären Glyphen künstlich verdickt werden. Wenn dieser Text im PDF zu schwer oder anders als beabsichtigt erscheint, rufen Sie [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) mit `true` auf. Diese Option rendert den betroffenen Text als Bitmap während des PDF‑Exports und kann das Erscheinungsbild bei bestimmten Schriften verbessern. Der Standardwert ist `false`.

Die Beispiels‑Präsentation enthält zwei Textfelder: eines mit normalem Text und eines mit fetter Formatierung derselben Schriftart, die keinen eigenen Fettdruck besitzt. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Schrifts‑Stile und exportiert sie nach PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Die folgende Gegenüberstellung zeigt die Ausgabe mit deaktivierter bzw. aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option stärkere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF mit deaktivierter Rasterisierung von nicht unterstütztem Schriftstil](unsupported-bold-disabled.png) | ![PDF mit aktivierter Rasterisierung von nicht unterstütztem Schriftstil](unsupported-bold-enabled.png) |

In diesem Beispiel wird bei aktivierter Option nur der fette Text in ein Bitmap umgewandelt: Er kann nicht mehr ausgewählt, kopiert oder ohne OCR durchsucht werden, und seine Kanten erscheinen bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text erhalten.

Diese Option rasterisiert Text, der als fett formatiert ist, wenn die Schriftart keinen eigenen Fettdruck besitzt. Die [Schriftart‑Substitution](/slides/de/java/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die ursprüngliche nicht verfügbar ist.

## **Ausgewählte Folien aus PowerPoint in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Folienzahlen in diesem Array sind einsbasiert, und die Eingabe‑Präsentation muss mindestens drei Folien enthalten.

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

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Der Folieninhalt wird skaliert, um zu passen, und die einzelne Folie wird nach PDF exportiert.

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

## **PowerPoint zu PDF im Notizen‑Folien‑Modus konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF, wobei die Sprecher‑Notizen jeder Folie unterhalb der jeweiligen Folie platziert werden. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

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

Aspose.Slides ermöglicht die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit jedem dieser Compliance‑Standards exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der nachstehende Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf verschiedenen Compliance‑Standards erzeugt:

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
Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungsoperationen zu speziellen Formaten — [PDF zu SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als eine einzige Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien gleichzeitig in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmatisch anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), um ein Passwort festzulegen und Zugriffs‑Berechtigungen während des Konvertierungsprozesses zu definieren.

**Wie binde ich versteckte Folien in das PDF ein?**

Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) mit `true` in der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) auf, um versteckte Folien in das resultierende PDF aufzunehmen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) und [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in der Klasse [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides die PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung genügen.

## **Weitere Ressourcen**

- [Aspose.Slides für Java Dokumentation](/slides/de/java/)
- [Aspose.Slides für Java API‑Referenz](https://reference.aspose.com/slides/java/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)