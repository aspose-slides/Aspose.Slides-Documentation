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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Java mit Aspose.Slides für Android, inklusive schneller Codebeispiele und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format auf Android bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Bewahrung von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität genutzt, ausgeblendete Folien einbezogen, PDF‑Dateien passwortgeschützt werden, Font‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit einer [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Android via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld „Application“ mit „*Aspose.Slides*“ und das Feld „PDF Producer“ mit einem Wert im Format „*Aspose.Slides v XX.XX*“. **Hinweis:** Sie können Aspose.Slides nicht anweisen, diese Information aus Ausgabedokumenten zu entfernen oder zu ändern.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* gesamten Präsentationen in PDF
* bestimmten Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs eng an den Originalpräsentationen bleiben. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Export‑Einstellungen als PDF.

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

Aspose bietet einen kostenlosen Online‑[**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können diesen Konverter testen, um die hier beschriebene Vorgehensweise live zu sehen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)-Klasse – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Vorgehen des Konvertierungsprozesses festlegen können.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionslevel für Text setzen, die DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation zu PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, Metadateien als PNG und Flate‑Textkompression.

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

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien sehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, die eingebettete Datei jedoch nicht als Anhang hinzugefügt. Durch Setzen der Option auf `true` wird zusätzlich die Dateidaten beigefügt. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie zu PDF mit angehängter Arbeitsmappe.

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

Zur Prüfung des Ergebnisses:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}

Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Anforderungen der Standards, keine Einschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Konformitätseinstellung und demonstriert keinen PDF/A‑Export.

{{% /alert %}}

### **PowerPoint in PDF mit ausgeblendeten Folien konvertieren**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)-Klasse aufrufen, um die ausgeblendeten Folien als Seiten im resultierenden PDF einzubeziehen.

Das folgende Beispiel exportiert eine Präsentation zu PDF, einschließlich aller ausgeblendeten Folien.

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

Das folgende Beispiel exportiert eine Präsentation zu einem PDF, das das Passwort `password` zum Öffnen erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich hochqualitativen Drucks.

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

### **Font‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) unter der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)-Klasse bereit, mit der Sie Font‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation zu PDF und gibt Font‑Ersetzungswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird.

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

Für weitere Informationen zu Font‑Ersetzungen siehe den Artikel [Font Substitution](/slides/de/androidjava/font-substitution/).

{{% /alert %}} 

### **Umgang mit Schriften ohne eigene fette Variante**

Eine Präsentation kann fetten Text anwenden, obwohl die verwendete Schriftart keine eigene fette Variante besitzt. Der Text kann trotzdem durch synthetisches Fetten hervorgehoben werden, das die regulären Glyphen künstlich verdickt. Wenn dieser Text im PDF zu schwer wirkt oder vom gewünschten Aussehen abweicht, rufen Sie [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) mit `true` auf. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Aussehen bei bestimmten Schriften verbessern. Der Standardwert ist `false`.

Die Beispielpräsentation enthält zwei Textfelder: eines mit normalem Text und eines mit fetter Formatierung derselben Schrift, die keine eigene fette Variante besitzt. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Schriftstile und exportiert sie zu PDF:

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

Die nachfolgenden Vorschaubilder zeigen die Ausgabe mit deaktivierter bzw. aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option schwerere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel führt das Aktivieren der Option dazu, dass nur der fette Text in eine Bitmap umgewandelt wird: Er kann nicht ausgewählt, kopiert oder ohne OCR als Text durchsucht werden, und seine Kanten erscheinen bei 800 % Zoom weicher. Der reguläre Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text erhalten.

Diese Option rasterisiert Text, der als fett formatiert ist, wenn die Schriftart keine eigene fette Variante besitzt. [Font Substitution](/slides/de/androidjava/font-substitution/) wählt stattdessen eine andere Schrift, wenn die Originalschrift nicht verfügbar ist.

## **Ausgewählte Folien einer PowerPoint‑Präsentation in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation zu PDF. Die Foliennummern in diesem Array sind einsbasiert, und die Eingabepäsentation muss mindestens drei Folien enthalten.

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

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Der Folieninhalt wird skaliert, um zu passen, und die einzelne Folie wird zu PDF exportiert.

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

    // Entferne die leere Folie, mit der die neue Präsentation erstellt wurde.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint in PDF im Notizfolien‑Ansicht konvertieren**

Das folgende Beispiel exportiert eine Präsentation zu PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

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

## **Zugänglichkeit und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht die Nutzung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument zu PDF unter Verwendung der folgenden Konformitätsstandards exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Konformitätsstandards erzeugt:

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

Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) und [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) und [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Batch‑Konvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)-Klasse, um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich ausgeblendete Folien in das PDF einbinden?**

Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) mit `true` in der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)-Klasse auf, um ausgeblendete Folien im resultierenden PDF zu berücksichtigen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) und [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)-Klasse verwenden, um hochwertige Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Konformitätsstandards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [various standards](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente den Anforderungen an Barrierefreiheit und Archivierung genügen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides for Android via Java Documentation](/slides/de/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)