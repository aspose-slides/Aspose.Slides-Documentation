---
title: "PPT und PPTX in PDF in Java konvertieren [Erweiterte Funktionen enthalten]"
linktitle: "PowerPoint zu PDF"
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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Java mit Aspose.Slides, inklusive schneller Code-Beispiele und erweiterter Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format mit Java bietet mehrere Vorteile, darunter Kompatibilität auf verschiedenen Geräten und die Erhaltung von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen, PDF‑Dateien passwortgeschützt werden, Schriftart‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Konformitäts‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit einer [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java fügt API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beim Konvertieren einer Präsentation in PDF füllt Aspose.Slides beispielsweise das Feld „Application“ mit "*Aspose.Slides*" und das Feld „PDF Producer“ mit einem Wert im Format "*Aspose.Slides v XX.XX*". **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu entfernen oder zu ändern.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* gesamten Präsentationen zu PDF
* bestimmten Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs den Originalpräsentationen eng entsprechen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

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

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) an, der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können diesen Konverter testen, um die hier beschriebene Vorgehensweise live zu sehen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑Klasse – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Verhalten des Konvertierungsprozesses festlegen können.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitäts‑Einstellung für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden, ein Komprimierungs‑Level für Text setzen, DPI für Bilder konfigurieren und vieles mehr.

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

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten der Arbeitsmappe als auch die Folien sehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild bzw. das Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, die eingebettete Datei wird jedoch nicht als Anhang hinzugefügt. Wird die Option auf `true` gesetzt, wird zusätzlich die Dateidaten eingebettet. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

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

So prüfen Sie das Ergebnis:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}

Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge und PDF/A‑3 erlaubt weitere Dateitypen, einschließlich Excel‑Arbeitsmappen. Diese Vorgaben stammen aus den Standards, nicht aus einer Einschränkung von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Konformitätseinstellung und demonstriert keinen PDF/A‑Export.

{{% /alert %}}

### **PowerPoint in PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑Klasse aufrufen, um versteckte Folien als Seiten im resultierenden PDF einzuschließen.

Das folgende Beispiel exportiert eine Präsentation nach PDF, wobei versteckte Folien mit einbezogen werden.

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

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das mit dem Passwort `password` geöffnet werden muss. Die Zugriffsberechtigungen erlauben das Drucken, einschließlich hochqualitativen Drucks.

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

### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) unter der [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑Klasse bereit, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Schriftart‑Ersetzungs‑Warnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird.

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

Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/java/font-substitution/).

{{% /alert %}} 

### **Umgang mit Schriften ohne eigene fette Variante**

Eine Präsentation kann fett formatierten Text verwenden, obwohl die Schriftart keine eigene fette Variante besitzt. Der Text kann dennoch durch synthetisches Fettdrucken hervorgehoben werden, was die regulären Glyphen künstlich verdickt. Wenn dieser Text in PDF zu schwer oder anders als beabsichtigt erscheint, rufen Sie [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) mit `true` auf. Diese Option rendert den betroffenen Text als Bitmap während des PDF‑Exports und kann das Aussehen bei bestimmten Schriften verbessern. Der Standardwert ist `false`.

Die Beispiel‑Präsentation enthält zwei Textfelder: eines mit normalem Text und eines, bei dem auf dieselbe Schriftart fette Formatierung angewendet wurde, die jedoch keine eigene fette Variante besitzt. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Schriftstil‑Varianten und exportiert sie nach PDF:

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

Die folgenden Vorschaubilder zeigen die Ausgabe mit deaktivierter bzw. aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option schwerere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel wird bei aktivierter Option nur der fette Text zu einer Bitmap: Er kann nicht ausgewählt, kopiert oder ohne OCR durchsucht werden, und seine Kanten erscheinen bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text erhalten.

Diese Option rasterisiert Text, der als fett formatiert ist, wenn die Schriftart keine eigene fette Variante besitzt. [Font substitution](/slides/de/java/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die Originalschriftart nicht verfügbar ist.

## **Ausgewählte Folien einer PowerPoint‑Präsentation in PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Foliennummern in diesem Array beginnen bei 1, und die Eingabe‑Präsentation muss mindestens drei Folien enthalten.

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

## **PowerPoint mit benutzerdefinierter Foliengröße in PDF konvertieren**

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

    // Entfernen Sie die leere Folie, die bei Erstellung der neuen Präsentation eingefügt wurde.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint in PDF im Notiz‑Folien‑Modus konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF und legt die Sprecher‑Notizen unter jede Folie. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

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

## **Barrierefreiheit und Konformitäts‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem der folgenden Konformitäts‑Standards nach PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Konformitäts‑Standards erzeugt:

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

Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen, mit denen Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungs‑Operationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativ‑Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF passwortzuschützen?**

Ja. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑Klasse, um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbinden?**

Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) mit `true` in der [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑Klasse auf, um versteckte Folien im resultierenden PDF zu integrieren.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) und [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in der [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)‑Klasse verwenden, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Konformitäts‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente den Barrierefreiheits‑ und Archivierungs‑Anforderungen entsprechen.

## **Weitere Ressourcen**

- [Aspose.Slides for Java Documentation](/slides/de/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)