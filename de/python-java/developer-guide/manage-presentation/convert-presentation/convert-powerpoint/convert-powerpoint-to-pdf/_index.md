---
title: PPT und PPTX in PDF konvertieren in Python über Java [Erweiterte Funktionen enthalten]
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
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Python über Java mit Aspose.Slides konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in Python über Java bietet mehrere Vorteile, darunter Kompatibilität auf verschiedenen Geräten und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, wie versteckte Folien einbezogen, PDF‑Dateien passwortgeschützt, Schriftart‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint-zu-PDF-Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Präsentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-Klasse und speichern die Präsentation anschließend mit der [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)-Methode als PDF. Die [Präsentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-Klasse stellt die [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)-Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}

Aspose.Slides für Python über Java fügt seinen API‑Informationen und die Versionsnummer in Ausgabedokumente ein. Beispielsweise füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld „Application“ mit „*Aspose.Slides*“ und das Feld „PDF Producer“ mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht Ihnen das Konvertieren:

* Gesamte Präsentationen zu PDF
* Bestimmte Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs den Originalpräsentationen sehr nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, darunter:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Die Standardkonvertierung verwendet die Standard‑PDF‑Export‑Einstellungen. Verwenden Sie benutzerdefinierte Optionen, wenn Sie die Bildqualität, den Seiteninhalt oder die PDF‑Compliance steuern müssen.

Installieren Sie [Aspose.Slides für Python über Java](/slides/de/python-java/installation/) und eine kompatible Java‑Runtime, bevor Sie die Beispiele ausführen. Jedes Beispiel liest `presentation.pptx` aus dem aktuellen Arbeitsverzeichnis; ersetzen Sie es durch Ihre PPT‑, PPTX‑ oder ODP‑Datei. Starten Sie die JVM einmal pro Python‑Prozess.

Das folgende Beispiel lädt eine Präsentation und speichert alle sichtbaren Folien mit den Standard‑Export‑Einstellungen als PDF.

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

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Testlauf für eine Live‑Implementierung des hier beschriebenen Verfahrens durchführen.

{{% /alert %}}

## **PowerPoint zu PDF mit Optionen**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse – bereit, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder festlegen können, wie der Konvertierungsprozess ablaufen soll.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie die bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Komprimierungsniveau für Text setzen, DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation zu PDF 1.5 mit einer JPEG‑Qualität von 90, einer Bildauflösung von 300 DPI, Metadateien als PNG und Flate‑Textkompression.

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

### **Eingebettete OLE‑Dateien als PDF‑Anhänge erhalten**

Enthält eine Präsentation ein eingebettetes Excel‑Arbeitsbuch, können Sie PDF‑Empfängern den Zugriff auf die Daten des Arbeitsbuchs sowie die Ansicht der Folien ermöglichen. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) mit `True` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `False`: Das Vorschaubild bzw. das Symbol des OLE‑Objekts wird auf der PDF‑Seite gerendert, aber die eingebettete Datei wird nicht als Anhang beigefügt. Durch Setzen der Option auf `True` wird die Dateidaten zusätzlich beigefügt. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht es Empfängern, die eingebettete Datei separat zu öffnen oder zu speichern. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits ein eingebettetes Excel‑Arbeitsbuch enthält, und exportiert sie zu PDF mit dem angehängten Arbeitsbuch.

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

Um das Ergebnis zu überprüfen:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie das eingebettete Arbeitsbuch.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}

Die PDF/A‑Standards setzen Einschränkungen für Anhänge: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge, und PDF/A‑3 erlaubt weitere Dateitypen, einschließlich Excel‑Arbeitsbüchern. Dies sind Anforderungen der Standards, keine spezifischen Einschränkungen von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.

{{% /alert %}}

### **PowerPoint zu PDF mit versteckten Folien**

Enthält eine Präsentation versteckte Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzubeziehen.

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

### **PowerPoint zu einem passwortgeschützten PDF konvertieren**

Das folgende Beispiel exportiert eine Präsentation zu einem PDF, das zum Öffnen das Passwort `password` erfordert. Die Zugriffsrechte erlauben das Drucken, einschließlich hochwertigen Drucks.

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

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) in der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse zur Verfügung, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation zu PDF und gibt Schriftart‑Ersetzungs‑Warnungen in der Konsole aus. Eine Warnung wird nur ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird. Verwenden Sie einen JPype‑Proxy, um Warn‑Callbacks aus der Java‑API zu erhalten. Konvertieren Sie den Java‑Beschreibungs‑String in einen Python‑String, bevor Sie dessen Präfix prüfen:

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

## **PowerPoint‑Folien auswählen und zu PDF konvertieren**

Die an [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) übergebenen Foliennummern sind 1‑basiert. Dieses Beispiel exportiert die Folien 1 und 3, sofern beide vorhanden sind:

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

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße**

Dieses Beispiel exportiert die erste Folie auf einer Seite mit den Maßen 612 × 792 Punkt (US‑Letter). Es klont die Folie in eine neue Präsentation mit der angegebenen Größe und skaliert den Folieninhalt, damit er passt.

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

    # Entfernt die leere Folie, die bei der Erstellung der neuen Präsentation entstanden ist.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **PowerPoint zu PDF in Notiz‑Folien‑Ansicht**

Das folgende Beispiel exportiert eine Präsentation zu PDF und platziert die Sprecher‑Notizen jeder Folie unterhalb der Folie. Verwenden Sie eine Präsentation mit Sprecher‑Notizen, um das Ergebnis zu sehen.

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

Beim Erstellen barrierefreier PDFs konsultieren Sie die [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Verwenden Sie [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance), um einen Ausgabestandard auszuwählen: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

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

> **Hinweis:** Beim Export zu PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien gleichzeitig in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ verarbeiten und den Konvertierungsprozess programmatisch anwenden.

**Ist es möglich, das konvertierte PDF zu passwortschützen?**

Ja. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse, um ein Passwort festzulegen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie füge ich versteckte Folien in das PDF ein?**

Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) mit `True` in der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse auf, um versteckte Folien im resultierenden PDF zu integrieren.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) und [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse verwenden, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, für Barrierefreiheit oder Archivierung. Wählen Sie den passenden Standard und prüfen Sie die Ausgabe anhand Ihrer Anforderungen.

## **Weitere Ressourcen**

- [Aspose.Slides für Python über Java Documentation](/slides/de/python-java/)
- [Aspose.Slides für Python über Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)