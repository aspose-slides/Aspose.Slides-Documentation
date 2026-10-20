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
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Java mit Aspose.Slides für Android, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format auf Android bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Bewahrung von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, wie versteckte Folien einbezogen, PDF‑Dateien passwortgeschützt, Font‑Ersetzungen erkannt, bestimmte Folien zur Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint zu PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten nach PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit der [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides für Android via Java fügt seinen API‑Informationen und die Versionsnummer in Ausgabedokumente ein. Beispielweise füllt Aspose.Slides beim Konvertieren einer Präsentation nach PDF das Feld **Application** mit "*Aspose.Slides*" und das Feld **PDF Producer** mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis**, dass Sie Aspose.Slides nicht anweisen können, diese Informationen aus Ausgabedokumenten zu entfernen oder zu ändern.
{{% /alert %}}

Aspose.Slides ermöglicht Ihnen, zu konvertieren:

* komplette Präsentationen zu PDF
* bestimmte Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint‑zu‑PDF‑Konvertierungsprozess verwendet die Standardeinstellungen. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und höchster Qualität in PDF zu konvertieren.

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
Aspose bietet einen kostenlosen Online‑[**PowerPoint zu PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test für die hier beschriebene Vorgehensweise durchführen.
{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen — Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑Klasse — zur Verfügung, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden, einen Kompressionsgrad für Text setzen, die DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation nach PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, gespeicherten Metadateien als PNG und Flate‑Textkompression.

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

### **Automatisches Auswählen der Bildkomprimierung**

Enthält eine Präsentation viele Fotos oder Screenshots, kann das Reduzieren der Größe des exportierten PDFs das Versenden per E‑Mail oder das Herunterladen erleichtern. Rufen Sie [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) mit `true` auf, um während des PDF‑Exports automatisch den am besten geeigneten Kompressionsalgorithmus für jedes Bild auszuwählen.

Das folgende Beispiel lädt eine bestehende Präsentation, aktiviert die automatische Bildkomprimierung und speichert sie als PDF‑Dokument. Alle anderen PDF‑Export‑Einstellungen behalten ihre Standardwerte.

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

Diese Option wählt für jedes Bild einen Kompressionsalgorithmus aus. Das Anpassen des mit [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) übergebenen Werts reduziert die JPEG‑Bildqualität, während das Verringern des mit [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) übergebenen Werts erlaubt, Bilder auf eine niedrigere Auflösung herunterzusampeln, was Details reduzieren kann. Das Aktivieren der automatischen Kompressionsauswahl reduziert diese Einstellungen jedoch nicht automatisch.

Das Auswählen von Bildkompressionsalgorithmen erfordert zusätzlichen Verarbeitungs‑ und Speicheraufwand. Die Größenreduktion hängt von den Bildern der Präsentation und den Export‑Einstellungen ab; eine feste Reduktion ist für jede Präsentation nicht garantiert.

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation ein eingebettetes Excel‑Arbeitsblatt, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl die Daten des Arbeitsblatts als auch die Folien sehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) mit `true` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `false`: Das Vorschaubild oder das Symbol des OLE‑Objekts wird auf der PDF‑Seite dargestellt, aber die eingebettete Datei ist nicht als Anhang enthalten. Setzt man die Option auf `true`, wird zusätzlich die Dateidaten eingebunden. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits ein eingebettetes Excel‑Arbeitsblatt enthält, und exportiert sie nach PDF mit dem angehängten Arbeitsblatt.

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

Um das Ergebnis zu überprüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie das eingebettete Arbeitsblatt.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards setzen Beschränkungen für Anhänge: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt weitere Dateitypen, einschließlich Excel‑Arbeitsblätter. Dies sind Anforderungen der Standards, nicht Einschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑Klasse verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

Das folgende Beispiel exportiert eine Präsentation nach PDF und schließt dabei alle versteckten Folien mit ein.

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

Das folgende Beispiel exportiert eine Präsentation in ein PDF, das zum Öffnen das Passwort `password` benötigt. Die Zugriffsrechte erlauben das Drucken, einschließlich qualitativ hochwertigem Druck.

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

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑Klasse bereit, mit der Sie Font‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation nach PDF und gibt Font‑Ersetzungs‑Warnungen in der Konsole aus. Eine Warnung wird nur dann ausgegeben, wenn während des Exports ein nicht verfügbarer Font substituiert wird.

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
Weitere Informationen zu Font‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/androidjava/font-substitution/).
{{% /alert %}} 

### **Schriften ohne dedizierten Fett‑Typeface behandeln**

Eine Präsentation kann Text fett formatieren, obwohl die verwendete Schriftart keinen eigenen Fettschrift‑Typeface besitzt. Der Text kann dennoch durch synthetisches Fettdrucken hervorgehoben werden, wobei die regulären Glyphen künstlich verdickt werden. Wenn dieser Text im PDF zu schwer oder anderweitig von der gewünschten Darstellung abweicht, versuchen Sie, [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) mit `true` aufzurufen. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Erscheinungsbild bei bestimmten Schriften verbessern. Der Standardwert ist `false`.

Die Beispielpräsentation enthält zwei Textfelder: eines mit normalem Text und eines, bei dem derselbe Font fett formatiert ist, obwohl er keinen dedizierten Fettschrift‑Typeface besitzt. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Font‑Stile und exportiert sie nach PDF:

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

Die nachfolgenden Vorschaubilder zeigen das Ergebnis mit deaktivierter bzw. aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option schwerere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`false`, Standard) | Option aktiviert (`true`) |
|---|---|
| ![PDF mit deaktivierter Rasterisierung nicht unterstützter Schriftstile](unsupported-bold-disabled.png) | ![PDF mit aktivierter Rasterisierung nicht unterstützter Schriftstile](unsupported-bold-enabled.png) |

In diesem Beispiel wird bei aktivierter Option nur der fette Text zu einer Bitmap: Er kann nicht ausgewählt, kopiert oder ohne OCR durchsucht werden und seine Kanten erscheinen bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text erhalten.

Diese Option rastert Text, der als fett formatiert ist, wenn die Schriftart keinen eigenen Fettschrift‑Typeface besitzt. [Font substitution](/slides/de/androidjava/font-substitution/) wählt stattdessen eine andere Schrift, wenn die Originalschrift nicht verfügbar ist.

## **Ausgewählte Folien von PowerPoint zu PDF konvertieren**

Das folgende Beispiel exportiert die Folien 1 und 3 einer Präsentation nach PDF. Die Foliennummern in diesem Array sind einsbasiert, und die Eingabepäsentation muss mindestens drei Folien enthalten.

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

Das folgende Beispiel kopiert die erste Folie einer Präsentation in eine neue Präsentation mit einer Foliengröße von 612 × 792 Punkten (8,5 × 11 Zoll). Es skaliert den Folieninhalt, um zu passen, und exportiert die einzelne Folie nach PDF.

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

## **PowerPoint zu PDF in Notiz‑Folien‑Ansicht konvertieren**

Das folgende Beispiel exportiert eine Präsentation nach PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

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

Aspose.Slides erlaubt Ihnen, ein Konvertierungsverfahren zu nutzen, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem der folgenden Compliance‑Standards nach PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

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
Aspose.Slides unterstützt PDF‑Konvertierungs‑Operationen, sodass Sie PDF‑Dateien in gängige Formate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) konvertieren. Weitere PDF‑Konvertierungen zu speziellen Formaten — [PDF zu SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — werden ebenfalls unterstützt.
{{% /alert %}}

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**  
Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien nach PDF. Sie können Ihre Dateien programmgesteuert durchlaufen und den Konvertierungsprozess anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**  
Ja. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich versteckte Folien in das PDF einbinden?**  
Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) mit `true` in der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑Klasse auf, um versteckte Folien im resultierenden PDF zu integrieren.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**  
Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) und [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) in der [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)‑Klasse verwenden, um hochwertige Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**  
Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, sodass Ihre Dokumente Barrierefreiheit und Archivierungsanforderungen erfüllen.

## **Weitere Ressourcen**

- [Aspose.Slides für Android via Java Dokumentation](/slides/de/androidjava/)
- [Aspose.Slides für Android via Java API‑Referenz](https://reference.aspose.com/slides/androidjava/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)