---
title: PPT und PPTX in PDF in Python über Java konvertieren [Erweiterte Funktionen enthalten]
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
- PPT in PDF konvertieren
- PPTX zu PDF
- PPTX in PDF konvertieren
- PowerPoint als PDF speichern
- PPT als PDF speichern
- PPTX als PDF speichern
- PPT nach PDF exportieren
- PPTX nach PDF exportieren
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Python über Java mit Aspose.Slides, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Überblick**

Die Konvertierung von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in Python über Java bietet mehrere Vorteile, darunter die Kompatibilität über verschiedene Geräte hinweg und die Erhaltung des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie man Präsentationen in PDF‑Dokumente konvertiert, verschiedene Optionen zur Steuerung der Bildqualität nutzt, versteckte Folien einbezieht, PDF‑Dateien mit einem Passwort schützt, Schriftart‑Ersetzungen erkennt, bestimmte Folien für die Konvertierung auswählt und Compliance‑Standards auf Ausgabedokumente anwendet.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit der [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides für Python über Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Zum Beispiel füllt Aspose.Slides beim Konvertieren einer Präsentation in PDF das Feld Application mit "*Aspose.Slides*" und das Feld PDF Producer mit einem Wert in der Form "*Aspose.Slides v XX.XX*". **Hinweis** dass Sie Aspose.Slides nicht anweisen können, diese Informationen aus Ausgabedokumenten zu ändern oder zu entfernen.
{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren:

* Komplette Präsentationen in PDF
* Bestimmte Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs eng an die Originalpräsentationen angelehnt sind. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Die Standardkonvertierung verwendet die standardmäßigen PDF‑Export‑Einstellungen. Verwenden Sie benutzerdefinierte Optionen, wenn Sie die Bildqualität, den Seiteninhalt oder die PDF‑Konformität steuern müssen.

Installieren Sie [Aspose.Slides for Python via Java](/slides/de/python-java/installation/) und eine kompatible Java‑Laufzeit, bevor Sie die Beispiele ausführen. Jedes Beispiel liest `presentation.pptx` aus dem aktuellen Arbeitsverzeichnis; ersetzen Sie es durch Ihre PPT‑, PPTX‑ oder ODP‑Datei. Starten Sie die JVM einmal pro Python‑Prozess.

Dieser Code konvertiert eine Präsentation in PDF:

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

{{% alert color="info" title="Hinweis" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Testlauf durchführen, um die hier beschriebene Vorgehensweise live zu sehen.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides bietet benutzerdefinierte Optionen — Eigenschaften der Klasse [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/) — mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Vorgehen des Konvertierungsprozesses festlegen können.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitäts‑Einstellung für Rasterbilder festlegen, bestimmen, wie Metadateien verarbeitet werden sollen, ein Kompressionsniveau für Text setzen, die DPI für Bilder konfigurieren und vieles mehr.

Das nachstehende Code‑Beispiel zeigt, wie man eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPoint in PDF mit versteckten Folien konvertieren**

Wenn eine Präsentation versteckte Folien enthält, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) der Klasse [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/) verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzubeziehen.

Dieser Code zeigt, wie man eine PowerPoint‑Präsentation in PDF konvertiert, wobei versteckte Folien einbezogen werden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPoint in ein passwortgeschütztes PDF konvertieren**

Dieser Code demonstriert, wie man eine PowerPoint‑Präsentation mit den Schutz‑Parametern der Klasse [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/) in ein passwortgeschütztes PDF konvertiert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveoptions/#setWarningCallback) unter der Klasse [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/) bereit, mit der Sie während des Präsentation‑zu‑PDF‑Konvertierungsprozesses Schriftart‑Ersetzungen erkennen können.

Verwenden Sie einen JPype‑Proxy, um Warn‑Callbacks von der Java‑API zu erhalten. Konvertieren Sie die Java‑Beschreibungszeichenkette in eine Python‑Zeichenkette, bevor Sie deren Präfix prüfen:

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


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Hinweis" %}}
Für weitere Informationen zum Empfangen von Callbacks für Schriftart‑Ersetzungen während des Rendering‑Prozesses siehe [Getting Warning Callbacks for Font Substitution](/slides/de/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zur Schriftart‑Ersetzung finden Sie im Artikel [Font Substitution](/slides/de/python-java/font-substitution/).
{{% /alert %}}

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

Die an [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) übergebenen Foliennummern sind 1‑basiert. Dieses Beispiel exportiert die Folien 1 und 3, sofern beide vorhanden sind:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieses Beispiel exportiert die erste Folie auf einer Seite mit den Maßen 612 × 792 Punkte (US Letter). Es klont die Folie in eine neue Präsentation mit der angegebenen Größe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint in PDF im Notizen‑Folien‑Ansicht konvertieren**

Dieser Code demonstriert, wie man eine PowerPoint‑Präsentation in ein PDF konvertiert, das Notizen enthält:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Beim Erstellen barrierefreier PDFs konsultieren Sie die [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Verwenden Sie [PdfOptions.setCompliance](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setCompliance), um einen Ausgabestandard auszuwählen: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf verschiedenen Compliance‑Standards erzeugt:

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

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; Alternativtext wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**  
Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF passwortgeschützt zu versehen?**  
Ja. Verwenden Sie die Klasse [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/), um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses festzulegen.

**Wie kann ich versteckte Folien in das PDF einbeziehen?**  
Verwenden Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) in der Klasse [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/), um versteckte Folien in das resultierende PDF einzubeziehen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**  
Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setJpegQuality) und [setSufficientResolution](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in der Klasse [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/) verwenden, um hochqualitative Bilder in Ihrem PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**  
Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfcompliance/) entsprechen, darunter PDF/A1a, PDF/A1b und PDF/UA, für Barrierefreiheit oder Archivierung. Wählen Sie den passenden Standard und prüfen Sie die Ausgabe hinsichtlich Ihrer Anforderungen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für Python über Java – Dokumentation](/slides/de/python-java/)
- [Aspose.Slides für Python über Java – API‑Referenz](https://reference.aspose.com/slides/de/python-java/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)