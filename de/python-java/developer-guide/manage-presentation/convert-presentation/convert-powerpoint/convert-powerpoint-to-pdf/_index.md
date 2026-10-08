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
- PPT zu PDF exportieren
- PPTX zu PDF exportieren
- Anhang
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX in hochwertige, durchsuchbare PDFs in Python via Java mit Aspose.Slides konvertieren, inklusive schneller Codebeispiele und erweiterter Konvertierungsoptionen."
---
## **Überblick**

Die Konvertierung von PowerPoint‑Präsentationen (PPT, PPTX, ODP usw.) in das PDF‑Format in Python via Java bietet mehrere Vorteile, darunter Kompatibilität über verschiedene Geräte hinweg und die Bewahrung des Layouts sowie der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität genutzt werden, wie ausgeblendete Folien einbezogen, PDF‑Dateien passwortgeschützt, Font‑Ersetzungen erkannt, bestimmte Folien zur Konvertierung ausgewählt und Compliance‑Standards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in den folgenden Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in PDF zu konvertieren, übergeben Sie den Dateinamen als Argument an die [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑Klasse und speichern Sie die Präsentation anschließend mit der [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)‑Methode als PDF. Die [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑Klasse stellt die [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)‑Methode bereit, die typischerweise zur Konvertierung einer Präsentation in PDF verwendet wird.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java fügt seine API‑Informationen und Versionsnummer in Ausgabedokumente ein. Beispielweise wird beim Konvertieren einer Präsentation zu PDF das Feld **Application** mit "*Aspose.Slides*" und das Feld **PDF Producer** mit einem Wert in der Form "*Aspose.Slides v XX.XX*" befüllt. **Hinweis**: Sie können Aspose.Slides nicht anweisen, diese Informationen aus Ausgabedokumenten zu entfernen oder zu ändern.

{{% /alert %}}

Aspose.Slides ermöglicht Ihnen, folgendes zu konvertieren:

* gesamte Präsentationen zu PDF
* ausgewählte Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass die resultierenden PDFs der Originalpräsentation möglichst nahe kommen. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, darunter:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Die Standardkonvertierung verwendet die voreingestellten PDF‑Export‑Einstellungen. Verwenden Sie benutzerdefinierte Optionen, wenn Sie die Bildqualität, den Seiteninhalt oder die PDF‑Compliance steuern müssen.

Installieren Sie [Aspose.Slides for Python via Java](/slides/de/python-java/installation/) und eine kompatible Java‑Runtime, bevor Sie die Beispiele ausführen. Jedes Beispiel liest `presentation.pptx` aus dem aktuellen Arbeitsverzeichnis; ersetzen Sie es durch Ihre PPT‑, PPTX‑ oder ODP‑Datei. Starten Sie die JVM einmal pro Python‑Prozess.

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

Aspose bietet einen kostenlosen Online-[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Konvertierungsprozess von Präsentation zu PDF demonstriert. Sie können mit diesem Konverter einen Testlauf für die hier beschriebene Implementierung durchführen.

{{% /alert %}}

## **PowerPoint zu PDF konvertieren mit Optionen**

Aspose.Slides stellt benutzerdefinierte Optionen — Eigenschaften der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse — bereit, mit denen Sie das resultierende PDF anpassen, das PDF mit einem Passwort schützen oder das Vorgehen der Konvertierung festlegen können.

### **PowerPoint zu PDF konvertieren mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionsniveau für Text setzen, DPI für Bilder konfigurieren und mehr.

Das folgende Beispiel exportiert eine Präsentation zu PDF 1.5 mit JPEG‑Qualität 90, Bildauflösung 300 DPI, Metadateien als PNG und Flate‑Textkompression.

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

Enthält eine Präsentation ein eingebettetes Excel‑Arbeitsbuch, möchten Sie möglicherweise, dass PDF‑Empfänger sowohl auf die Daten des Arbeitsbuchs als auch auf die Folien zugreifen können. Rufen Sie [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) mit `True` auf, um eingebettete OLE‑Dateien als Anhänge im resultierenden PDF zu erhalten.

Der Standardwert ist `False`: Das Vorschaubild oder Symbol des OLE‑Objekts wird auf der PDF‑Seite dargestellt, die eingebettete Datei jedoch nicht als Anhang beigefügt. Wird die Option auf `True` gesetzt, wird zusätzlich die Dateidaten beigefügt. Die Vorschau bleibt eine visuelle Darstellung; der Anhang ermöglicht Empfängern das separate Öffnen oder Speichern der eingebetteten Datei. Das OLE‑Objekt wird nicht zu einem interaktiven Excel‑Arbeitsblatt auf der PDF‑Seite.

Das folgende Beispiel lädt eine Präsentation, die bereits ein eingebettetes Excel‑Arbeitsbuch enthält, und exportiert sie zu PDF mit dem Arbeitsbuch als Anhang.

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

So überprüfen Sie das Ergebnis:

1. Öffnen Sie das exportierte PDF in einem Viewer, der Dateianhänge unterstützt, z. B. Adobe Acrobat Reader.
2. Öffnen Sie das **Attachments**‑Panel des Viewers und suchen Sie das eingebettete Arbeitsbuch.
3. Speichern Sie den Anhang und öffnen Sie ihn in Excel, um die Daten zu prüfen, oder öffnen Sie ihn direkt, falls der Viewer dies zulässt. Die Vorschau auf der PDF‑Seite ist vom Anhang getrennt.

{{% alert color="info" title="Note" %}}

Die PDF/A‑Standards legen Beschränkungen für Anhänge fest: PDF/A‑1 verbietet eingebettete Dateien, PDF/A‑2 erlaubt nur PDF/A‑Anhänge und PDF/A‑3 erlaubt andere Dateitypen, darunter Excel‑Arbeitsbücher. Diese Vorgaben stammen aus den Standards, nicht aus einer Einschränkung von Aspose.Slides. Dieses Beispiel verwendet die Standard‑PDF‑Compliance‑Einstellung und demonstriert keinen PDF/A‑Export.

{{% /alert %}}

### **PowerPoint zu PDF konvertieren mit ausgeblendeten Folien**

Enthält eine Präsentation ausgeblendete Folien, können Sie die Methode [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse verwenden, um die ausgeblendeten Folien als Seiten im resultierenden PDF einzubeziehen.

Das folgende Beispiel exportiert eine Präsentation zu PDF und schließt dabei alle ausgeblendeten Folien ein.

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

### **Font‑Ersetzungen erkennen**

Aspose.Slides stellt die Methode [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse bereit, mit der Sie Font‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses erkennen können.

Das folgende Beispiel exportiert eine Präsentation zu PDF und gibt Font‑Ersetzungs‑Warnungen auf der Konsole aus. Eine Warnung wird nur dann ausgegeben, wenn während des Exports eine nicht verfügbare Schriftart ersetzt wird. Verwenden Sie einen JPype‑Proxy, um Warn‑Callbacks aus der Java‑API zu erhalten. Konvertieren Sie den Java‑Beschreibungstext vor der Prüfung seines Präfixes in einen Python‑String:

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

Weitere Informationen zu Font‑Ersetzungen finden Sie im Artikel [Font Substitution](/slides/de/python-java/font-substitution/).

{{% /alert %}}

### **Umgang mit Schriften ohne eigene fette Schriftart**

Eine Präsentation kann fetten Text anwenden, selbst wenn die verwendete Schriftart keine eigene fette Variante besitzt. Der Text kann dann synthetisch fett dargestellt werden, indem die regulären Glyphen künstlich verdickt werden. Wenn dieser Text im PDF zu schwer wirkt oder vom gewünschten Erscheinungsbild abweicht, rufen Sie [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) mit `True` auf. Diese Option rendert den betroffenen Text als Bitmap während des PDF‑Exports und kann das Aussehen bestimmter Schriften verbessern. Der Standardwert ist `False`.

Die Beispielpräsentation enthält zwei Textfelder: eines mit normalem Text und eines, bei dem dieselbe Schriftart fett formatiert ist, obwohl sie keine eigene fette Variante besitzt. Das folgende Beispiel lädt die Präsentation, aktiviert die Rasterisierung nicht‑unterstützter Schriftstile und exportiert sie zu PDF:

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

Die folgenden Vorschaubilder zeigen das Ergebnis mit deaktivierter bzw. aktivierter Option. In diesem Beispiel hat der fette Text bei deaktivierter Option schwerere Striche. Bei aktivierter Option sind die Striche leichter; der normale Text bleibt unverändert. Vergleichen Sie die Ergebnisse, bevor Sie die Einstellung für Ihre Präsentation wählen.

| Option deaktiviert (`False`, Standard) | Option aktiviert (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

In diesem Beispiel führt das Aktivieren der Option dazu, dass nur der fette Text in eine Bitmap umgewandelt wird: Er kann nicht mehr ausgewählt, kopiert oder ohne OCR durchsucht werden, und seine Kanten wirken bei 800 % Zoom weicher. Der normale Text bleibt durchsuchbar. Bei deaktivierter Option bleiben beide Zeichenketten als Text erhalten.

Diese Option rastert Text, der als fett formatiert ist, wenn die Schriftart keine eigene fette Variante bietet. [Font substitution](/slides/de/python-java/font-substitution/) wählt stattdessen eine andere Schriftart, wenn die Originalschrift nicht verfügbar ist.

## **Ausgewählte Folien aus PowerPoint zu PDF konvertieren**

Folienzahlen, die an [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) übergeben werden, sind 1‑basiert. Dieses Beispiel exportiert die Folien 1 und 3, sofern beide existieren:

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

## **PowerPoint zu PDF konvertieren mit benutzerdefinierter Foliengröße**

Dieses Beispiel exportiert die erste Folie auf einer Seite mit den Maßen 612 × 792 Punkte (US‑Letter). Es klont die Folie in eine neue Präsentation mit der angegebenen Größe und skaliert den Folieninhalt, damit er passt.

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

    # Entferne die leere Folie, die bei der Erstellung der neuen Präsentation hinzugefügt wurde.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **PowerPoint zu PDF in Notizfolien‑Ansicht konvertieren**

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

Wenn Sie barrierefreie PDFs erstellen, konsultieren Sie die [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Verwenden Sie [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance), um einen Ausgabestandard zu wählen: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsprozess, der mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt:

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

> **Hinweis:** Beim Export nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativ‑Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann ich mehrere PowerPoint‑Dateien massenhaft zu PDF konvertieren?**

Ja, Aspose.Slides unterstützt die Stapelkonvertierung mehrerer PPT‑ oder PPTX‑Dateien zu PDF. Sie können Ihre Dateien iterativ durchlaufen und den Konvertierungsprozess programmgesteuert anwenden.

**Ist es möglich, das konvertierte PDF mit einem Passwort zu schützen?**

Ja. Verwenden Sie die [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse, um ein Passwort zu setzen und Zugriffsrechte während des Konvertierungsprozesses zu definieren.

**Wie kann ich ausgeblendete Folien in das PDF einbinden?**

Rufen Sie [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) mit `True` in der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse auf, um ausgeblendete Folien im resultierenden PDF zu berücksichtigen.

**Kann Aspose.Slides eine hohe Bildqualität im PDF beibehalten?**

Ja, Sie können die Bildqualität steuern, indem Sie Methoden wie [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) und [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) in der [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)-Klasse verwenden, um hochqualitative Bilder in Ihrem PDF sicherzustellen.

**Unterstützt Aspose.Slides PDF/A‑Compliance‑Standards?**

Ja, Aspose.Slides ermöglicht den Export von PDFs, die den [verschiedenen Standards](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) entsprechen, einschließlich PDF/A1a, PDF/A1b und PDF/UA, für Barrierefreiheit oder Archivierung. Wählen Sie den passenden Standard und prüfen Sie das Ergebnis gemäß Ihren Anforderungen.

## **Zusätzliche Ressourcen**

- [Aspose.Slides for Python via Java Documentation](/slides/de/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)