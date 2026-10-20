---
title: PPT und PPTX in PDF in Python via Java konvertieren [Erweiterte Funktionen enthalten]
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/python-java/convert-powerpoint-to-pdf/
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
- Python
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Python via Java mit Aspose.Slides, inklusive schneller Codebeispiele und erweiterter Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in Python via Java bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie man Präsentationen in PDF‑Dokumente konvertiert, verschiedene Optionen zur Steuerung der Bildqualität verwendet, versteckte Folien einbezieht, PDF‑Dateien mit Passwort schützt, Schriftart‑Ersetzungen erkennt, bestimmte Folien für die Konvertierung auswählt und Compliance‑Standards auf Ausgabedokumente anwendet.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Anschließend speichern Sie die Präsentation als PDF mit der Methode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Die Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) stellt die Methode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) bereit, die typischerweise verwendet wird, um eine Präsentation in PDF zu konvertieren.

{{% alert color="info" title="Note" %}}
Aspose.Slides für Python via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Zum Beispiel füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit „*Aspose.Slides*“ und das Feld PDF Producer mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren:

* Komplette Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs dem Original sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint nach PDF konvertieren**

Die Standardkonvertierung verwendet die standardmäßigen PDF‑Export‑Einstellungen. Verwenden Sie benutzerdefinierte Optionen, wenn Sie die Bildqualität, den Seiteninhalt oder die PDF‑Konformität steuern müssen.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mithilfe der standardmäßigen Export‑Einstellungen als PDF.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Test durchführen, um die hier beschriebene Vorgehensweise live zu implementieren.
{{% /alert %}}

## **PowerPoint nach PDF mit Optionen konvertieren**

Aspose.Slides bietet benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) – die es ermöglichen, das resultierende PDF anzupassen, das PDF mit einem Passwort zu sperren oder festzulegen, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint nach PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden, ein Komprimierungsniveau für Text festlegen, DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation zu PDF 1.5 mit JPEG‑Qualität von 90, Bildauflösung von 300 DPI, Metadateien als PNG gespeichert und Flate‑Textkompression.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Automatische Auswahl der Bildkompression**

Enthält eine Präsentation viele Fotos oder Screenshots, kann die Reduzierung der Größe des exportierten PDFs das Versenden per E‑Mail oder Herunterladen erleichtern. Rufen Sie [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) mit `True` auf, um während des PDF‑Exports automatisch den am besten geeigneten Komprimierungsalgorithmus für jedes Bild auszuwählen.

Das folgende Beispiel lädt eine vorhandene Präsentation, aktiviert die automatische Auswahl der Bildkompression und speichert sie als PDF‑Dokument. Alle anderen PDF‑Export‑Einstellungen behalten ihre Standardwerte bei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Diese Option wählt einen Komprimierungsalgorithmus für jedes Bild aus. Das Verringern des an [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) übergebenen Werts reduziert stattdessen die JPEG‑Bildqualität, während das Verringern des an [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) übergebenen Werts erlaubt, dass Bilder auf eine niedrigere Auflösung herunterskaliert werden, was Details reduzieren kann. Das Aktivieren der automatischen Komprimierungsauswahl senkt diese Einstellungen nicht.

Die Auswahl von Bildkomprimierungsalgorithmen erfordert zusätzlichen Verarbeitungszeit und Speicher. Die Größenreduktion hängt von den Bildern und den Export‑Einstellungen der Präsentation ab; eine feste Reduktion ist für jede Präsentation nicht garantiert.

### **Eingebettete OLE‑Dateien als PDF‑Anhänge beibehalten**

Enthält eine Präsentation eine eingebettete Excel‑Arbeitsmappe, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl auf die Daten der Arbeitsmappe zugreifen als auch die Folien ansehen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) mit `True` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu beibehalten.

Der Standardwert ist `False`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite dargestellt, aber die eingebettete Datei wird nicht als Anhang hinzugefügt. Wird die Option auf `True` gesetzt, werden zusätzlich die Dateidaten eingebettet. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits eine eingebettete Excel‑Arbeitsmappe enthält, und exportiert sie zu PDF mit der angehängten Arbeitsmappe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Um das Ergebnis zu prüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie die eingebettete Arbeitsmappe.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}
Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge und PDF/A‑3 erlaubt andere Dateitypen, einschließlich Excel‑Arbeitsmappen. Dies sind Anforderungen der Standards, keine spezifischen Einschränkungen von Aspose.Slides. Dieses Beispiel verwendet die standardmäßige PDF‑Konformitätseinstellung und demonstriert keinen PDF/A‑Export.
{{% /alert %}}

### **PowerPoint nach PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) aus der Klasse [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) verwenden, um die versteckten Folien als Seiten im resultierenden PDF aufzunehmen.

Das folgende Beispiel exportiert eine Präsentation zu PDF und schließt dabei alle versteckten Folien ein.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation zu einem PDF, das zum Öffnen das Passwort `password` erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich Druck in hoher Qualität.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) bereit, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation zu PDF und gibt Schriftart‑Ersetzungswarnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird. Verwenden Sie einen JPype‑Proxy, um Warn‑Callbacks von der Java‑API zu erhalten. Konvertieren Sie den Java‑Beschreibungsstring in einen Python‑String, bevor Sie dessen Präfix prüfen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Schriftart‑Ersetzung](/slides/de/python-java/font-substitution/).
{{% /alert %}}

### **Schriftarten ohne eigene Fettschrift verarbeiten**

Eine Präsentation kann Text fett formatieren, selbst wenn die Schriftart keine eigene Fettschrift hat. Der Text kann dennoch durch synthetisches Fettdrucken fett erscheinen, wobei die regulären Glyphen künstlich verdickt werden. Wenn dieser Text im PDF zu schwer wirkt oder sonst vom gewünschten Aussehen abweicht, versuchen Sie, [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) mit `True` aufzurufen. Diese Option rendert den betroffenen Text während des PDF‑Exports als Bitmap und kann das Aussehen bei bestimmten Schriften verbessern. Der Standardwert ist `False`.

Die Beispielpräsentation enthält zwei Textfelder: eines mit normalem Text und eines mit auf dieselbe Schriftart angewandter Fettschrift, die keine eigene Fettschrift hat. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht unterstützter Schriftstile und exportiert sie zu PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Die folgenden Vorschauen zeigen die Ausgabe mit deaktivierter und aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option stärkere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`False`, Standard) | Option aktiviert (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel wandelt das Aktivieren der Option nur den fetten Text in eine Bitmap um: Er kann nicht ausgewählt, kopiert oder ohne OCR als Text durchsucht werden, und seine Kanten erscheinen bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text.

Diese Option rasterisiert Text, der als fett formatiert ist, wenn die Schriftart keine eigene Fettschrift hat. [Schriftart‑Ersetzung](/slides/de/python-java/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die ursprüngliche nicht verfügbar ist.

## **Ausgewählte Folien aus PowerPoint in PDF konvertieren**

Foliennummern, die an [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) übergeben werden, beginnen bei 1. Dieses Beispiel exportiert die Folien 1 und 3, sofern beide vorhanden sind:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **PowerPoint nach PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieses Beispiel exportiert die erste Folie auf eine Seite von 612 × 792 Punkten (US‑Letter). Es klont die Folie in eine neue Präsentation mit der angegebenen Größe und skaliert den Folieninhalt, damit er passt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Entfernen Sie die leere Folie, mit der die neue Präsentation erstellt wurde.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **PowerPoint nach PDF im Notiz‑Folien‑Ansicht konvertieren**

Das folgende Beispiel exportiert eine Präsentation zu PDF und platziert die Referenten‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Referenten‑Notizen, um das Ergebnis zu sehen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Beim Erstellen zugänglicher PDFs konsultieren Sie die [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Verwenden Sie [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance), um einen Ausgabestandard auszuwählen: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der basierend auf unterschiedlichen Compliance‑Standards mehrere PDFs erzeugt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Hinweis:** Beim Export zu PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als ein einzelnes Objekt. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativtext wird nur für das gesamte Objekt bereitgestellt.

## **FAQ**

Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterieren und den Konvertierungsprozess programmgesteuert anwenden.

Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?

Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

Wie füge ich versteckte Folien in das PDF ein?

Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) mit `True` in der Klasse [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) auf, um versteckte Folien in das resultierende PDF aufzunehmen.

Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) und [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in der Klasse [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) verwenden, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, für Barrierefreiheit oder Archivierung. Wählen Sie den passenden Standard und prüfen Sie die Ausgabe anhand Ihrer Anforderungen.

## **Additional Resources**

- [Aspose.Slides für Python via Java Dokumentation](/slides/de/python-java/)
- [Aspose.Slides für Python via Java API‑Referenz](https://reference.aspose.com/slides/python-java/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)