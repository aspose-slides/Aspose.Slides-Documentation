---
title: PPT und PPTX in PDF konvertieren in Python via Java [Erweiterte Funktionen enthalten]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Python via Java mit Aspose.Slides konvertieren, mit schnellen Codebeispielen und erweiterten Konvertierungsoptionen."
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in Python über Java bietet mehrere Vorteile, darunter Kompatibilität auf verschiedenen Geräten und die Bewahrung von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente umgewandelt werden, wie verschiedene Optionen zur Steuerung der Bildqualität genutzt, versteckte Folien einbezogen, PDF‑Dateien passwortgeschützt, Schriftarten‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse und speichern die Präsentation anschließend mit der [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode bereit, die typischerweise zur Konvertierung einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielsweise wird beim Konvertieren einer Präsentation in PDF das Feld *Application* mit "*Aspose.Slides*" und das Feld *PDF Producer* mit einem Wert der Form "*Aspose.Slides v XX.XX*" gefüllt. **Note** Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu entfernen oder zu ändern.
{{% /alert %}}

Aspose.Slides ermöglicht Ihnen:

* Ganze Präsentationen in PDF zu konvertieren
* Bestimmte Folien einer Präsentation in PDF zu konvertieren

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass die resultierenden PDFs eng an den Originalpräsentationen bleiben. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungen
* Tabellen

## **PowerPoint in PDF konvertieren**

Die Standardkonvertierung verwendet die voreingestellten PDF‑Export‑Einstellungen. Verwenden Sie benutzerdefinierte Optionen, wenn Sie Bildqualität, Seiteninhalt oder PDF‑Compliance steuern müssen.

Installieren Sie [Aspose.Slides for Python via Java](/slides/de/python-java/installation/) und eine kompatible Java‑Runtime, bevor Sie die Beispiele ausführen. Jedes Beispiel liest `presentation.pptx` aus dem aktuellen Arbeitsverzeichnis; ersetzen Sie es durch Ihre PPT‑, PPTX‑ oder ODP‑Datei. Starten Sie die JVM einmal pro Python‑Prozess.

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

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Sie können mit diesem Konverter einen Testlauf durchführen, um die hier beschriebene Vorgehensweise live zu erleben.
{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/)‑Klasse – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Verhalten des Konvertierungsprozesses festlegen können.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden, ein Kompressionslevel für Text setzen, DPI für Bilder konfigurieren und vieles mehr.

Das folgende Codebeispiel zeigt, wie eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird:

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

Enthält eine Präsentation versteckte Folien, können Sie die [setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides)‑Methode der [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/)‑Klasse verwenden, um die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

Der folgende Code zeigt, wie eine PowerPoint‑Präsentation mit einbezogenen versteckten Folien in PDF konvertiert wird:

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

### **PowerPoint in passwortgeschütztes PDF konvertieren**

Dieses Beispiel demonstriert, wie eine PowerPoint‑Präsentation mithilfe der Schutzparameter der [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/)‑Klasse in ein passwortgeschütztes PDF konvertiert wird:

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

Aspose.Slides bietet die [setWarningCallback](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveoptions/#setWarningCallback)‑Methode innerhalb der [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/)‑Klasse, mit der Sie Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Verwenden Sie einen JPype‑Proxy, um Warn‑Callbacks aus der Java‑API zu erhalten. Konvertieren Sie den Java‑Beschreibungs‑String in einen Python‑String, bevor Sie dessen Präfix prüfen:

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

{{% alert color="info" title="Note" %}}
Weitere Informationen zum Empfangen von Callbacks für Schriftart‑Ersetzungen während des Renderings finden Sie unter [Getting Warning Callbacks for Fonts Substitution](/slides/de/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/python-java/font-substitution/).
{{% /alert %}}

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

An an die [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) übergebenen Foliennummern wird eine 1‑basierte Indexierung zugrunde gelegt. Dieses Beispiel exportiert die Folien 1 und 3, sofern beide vorhanden sind:

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

Dieses Beispiel exportiert die erste Folie auf einer Seite mit den Maßen 612 × 792 Punkten (US‑Letter). Die Folie wird in eine neue Präsentation mit der angegebenen Größe geklont:

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

## **PowerPoint in PDF im Notiz‑Folien‑Ansicht konvertieren**

Der folgende Code demonstriert, wie eine PowerPoint‑Präsentation in ein PDF konvertiert wird, das die Notizen enthält:

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

Beim Erstellen barrierefreier PDFs beachten Sie die [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Verwenden Sie [PdfOptions.setCompliance](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setCompliance), um einen Ausgabestandard zu wählen: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der nachfolgende Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

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

> **Note:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien stapelweise in PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien in PDF. Sie können Ihre Dateien iterativ durchgehen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF zu passwortschützen?**

Ja. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/)‑Klasse, um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses festzulegen.

**Wie kann ich versteckte Folien in das PDF einbeziehen?**

Verwenden Sie die [setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides)‑Methode in der [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/)‑Klasse, um versteckte Folien im resultierenden PDF zu integrieren.

**Kann Aspose.Slides hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setJpegQuality) und [setSufficientResolution](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in der [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/)‑Klasse verwenden, um hochwertige Bilder im PDF zu gewährleisten.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, für Barrierefreiheit oder Archivierung. Wählen Sie den geeigneten Standard und prüfen Sie die Ausgabe nach Ihren Anforderungen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides for Python via Java Documentation](/slides/de/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/de/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/de/conversion)