---
title: "PPT & PPTX zu PDF in Python | Erweiterte Optionen"
linktitle: "PowerPoint zu PDF"
type: docs
weight: 40
url: /de/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- "PowerPoint konvertieren"
- "Präsentation"
- "PowerPoint zu PDF"
- "PPT zu PDF"
- "PPTX zu PDF"
- "PowerPoint als PDF speichern"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "Python"
- "Aspose.Slides für Python"
description: "Schritt‑für‑Schritt‑Anleitung zur Konvertierung von PPT, PPTX und ODP in hochwertige, WCAG‑konforme PDFs in Python mit Aspose.Slides – beinhaltet Passwortschutz, Folienauswahl und Bildqualitäts‑Steuerung."
showReadingTime: true
---
## **Übersicht**

Die Konvertierung von PowerPoint‑Präsentationen (PPT, PPTX, ODP) in das PDF‑Format in Python bietet mehrere Vorteile, darunter die Gewährleistung der Kompatibilität über verschiedene Geräte hinweg und das Erhalten des Layouts und der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, wie verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen, PDF‑Dokumente mit einem Passwort geschützt, Schriftart‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Compliance‑Standards auf die Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in Python in PDF zu konvertieren, müssen Sie lediglich den Dateinamen als Argument an die [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse übergeben und dann die Präsentation mit einer [Save](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/#methods)‑Methode als PDF speichern. Die [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse stellt die [Save](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/#methods)‑Methode bereit, die typischerweise zur Konvertierung einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides für Python schreibt automatisch API‑Informationen und Versionsnummer in Ausgabedokumente. Wenn eine Präsentation in PDF konvertiert wird, füllt Aspose.Slides für Python das Feld *Application* mit dem Wert '*Aspose.Slides*' und das Feld *PDF Producer* mit einem Wert in der Form '*Aspose.Slides v XX.XX*'. **Hinweis:** Sie können Aspose.Slides für Python nicht anweisen, diese Informationen aus den Ausgabedokumenten zu entfernen oder zu ändern.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* gesamten Präsentationen in PDF
* einzelnen Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass der Inhalt der resultierenden PDFs dem Original sehr nahe kommt. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, darunter:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standardschritt der PowerPoint‑zu‑PDF‑Konvertierung wird mit den Vorgabeoptionen ausgeführt. In diesem Fall versucht Aspose.Slides, die übergebene Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren. Der folgende Python‑Code zeigt, wie Sie PowerPoint in PDF konvertieren:

*Schritte: PowerPoint‑zu‑PDF‑Konvertierungen in Python*

Der folgende Beispielcode erklärt diese Konvertierungen mithilfe von Python über .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Schritte: PowerPoint in PDF konvertieren mit Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Schritte: PPT in PDF konvertieren mit Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Schritte: PPTX in PDF konvertieren mit Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Schritte: ODP in PDF konvertieren mit Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Schritte: PPS in PDF konvertieren mit Python via .NET</a></strong>

**Code‑Schritte:**

- Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse erstellen und ihr die PowerPoint‑Datei übergeben.
  * *.ppt*‑Erweiterung zum Laden einer **PPT**‑Datei in der _Presentation_-Klasse.
  * *.pptx*‑Erweiterung zum Laden einer **PPTX**‑Datei in der _Presentation_-Klasse.
  * *.odp*‑Erweiterung zum Laden einer **ODP**‑Datei in der _Presentation_-Klasse.
  * *.pps*‑Erweiterung zum Laden einer **PPS**‑Datei in der _Presentation_-Klasse.
- Die _Presentation_ mit dem Aufruf der **Save**‑Methode und der Verwendung der Aufzählung **SaveFormat.PDF** im **PDF**‑Format speichern.

```python
import aspose.slides as slides

# Instanziiert eine Presentation‑Klasse, die eine PowerPoint‑Datei darstellt
presentation = slides.Presentation("PowerPoint.ppt")

# Speichert die Präsentation als PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose stellt einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf) bereit, der den Konvertierungsprozess demonstriert. Für eine Live‑Umsetzung des hier beschriebenen Verfahrens können Sie den Konverter testen.

{{% /alert %}}

## **PowerPoint in PDF konvertieren mit Optionen**

Aspose.Slides bietet benutzerdefinierte Optionen — Eigenschaften der Klasse [PdfOptions](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides.export/pdfoptions/) — mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder das Verhalten des Konvertierungsprozesses festlegen können.

### **PowerPoint in PDF konvertieren mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, das Handling von Metadateien bestimmen, ein Komprimierungslevel für Texte setzen, DPI für Bilder definieren usw.

Das folgende Code‑Beispiel demonstriert einen Vorgang, bei dem eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird:

```python
import aspose.slides as slides

# Instanziiert die PdfOptions-Klasse
pdf_options = slides.export.PdfOptions()

# Legt die Qualität für JPG-Bilder fest
pdf_options.jpeg_quality = 90

# Legt DPI für Bilder fest
pdf_options.sufficient_resolution = 300

# Legt das Verhalten für Metadateien fest
pdf_options.save_metafiles_as_png = True

# Legt das Kompressionslevel für Textinhalte fest
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definiert den PDF-Compliance-Modus
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instanziiert die Presentation-Klasse, die ein PowerPoint-Dokument darstellt
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Speichert die Präsentation als PDF-Dokument
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint in PDF konvertieren mit versteckten Folien**

Enthält eine Präsentation versteckte Folien, können Sie die benutzerdefinierte Option `show_hidden_slides` aus der Klasse [PdfOptions](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides.export/pdfoptions/) verwenden, um Aspose.Slides anzuweisen, die versteckten Folien als Seiten im resultierenden PDF einzubeziehen.

Der folgende Python‑Code zeigt, wie Sie eine PowerPoint‑Präsentation mit einbezogenen versteckten Folien in PDF konvertieren:

```python
import aspose.slides as slides

# Instanziiert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Instanziiert die PdfOptions-Klasse
pdfOptions = slides.export.PdfOptions()

# Fügt versteckte Folien hinzu
pdfOptions.show_hidden_slides = True

# Speichert die Präsentation als PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint in passwortgeschütztes PDF konvertieren**

Der folgende Python‑Code zeigt, wie Sie ein PowerPoint‑Dokument in ein passwortgeschütztes PDF konvertieren (unter Verwendung von Schutzparametern aus der Klasse [PdfOptions](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Instanziiert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Instanziiert die PdfOptions-Klasse
pdfOptions = slides.export.PdfOptions()

# Legt das PDF-Passwort und Zugriffsberechtigungen fest
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Ausgewählte Folien einer PowerPoint‑Präsentation in PDF konvertieren**

Der folgende Python‑Code zeigt, wie Sie bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:

```python
import aspose.slides as slides

# Instanziert ein Presentation‑Objekt, das eine PowerPoint‑Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Setzt ein Array von Folienpositionen
slides_array = [ 1, 3 ]

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Der folgende Python‑Code zeigt, wie Sie ein PowerPoint‑Dokument mit festgelegter Foliengröße in PDF konvertieren:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Instanziiert die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Erstellt eine neue Präsentation mit angepasster Foliengröße.
    with slides.Presentation() as resized_presentation:

        # Legt die benutzerdefinierte Foliengröße fest.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Klont die erste Folie aus der Originalpräsentation.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Speichert die skalierte Präsentation als PDF mit Notizen.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint in PDF im Notiz‑Folien‑Ansichtsmodus konvertieren**

Der folgende Python‑Code zeigt, wie Sie ein PowerPoint‑Dokument in PDF‑Notizen konvertieren:

```python
import aspose.slides as slides

# Instanziert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Speichert die Präsentation als PDF-Notizen
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem dieser Compliance‑Standards exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Der folgende Python‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsvorgang, bei dem mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt werden:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides‑Unterstützung für PDF‑Konvertierungsoperationen erstreckt sich darauf, PDFs in die gängigsten Dateiformate zu konvertieren. Sie können Konvertierungen zu [PDF nach HTML](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-html/), [PDF nach Bild](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-image/), [PDF nach JPG](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-jpg/) und [PDF nach PNG](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-png/) durchführen. Weitere spezialisierte Formate — [PDF nach SVG](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-svg/), [PDF nach TIFF](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-tiff/), und [PDF nach XML](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-xml/) — werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann Aspose.Slides für Python die Anwendungsinformationen aus dem PDF entfernen?**

Nein, Aspose.Slides für Python fügt automatisch API‑Informationen und die Versionsnummer in das Ausgabepdf ein. Diese Informationen können nicht geändert oder entfernt werden.

**Wie kann ich nur bestimmte Folien in die PDF‑Konvertierung einbeziehen?**

Sie können die Folienindizes, die Sie konvertieren möchten, an die `save`‑Methode übergeben, indem Sie ein Array von Folienpositionen angeben.

**Ist es möglich, das PDF während der Konvertierung mit einem Passwort zu schützen?**

Ja, Sie können ein Passwort festlegen und Zugriffsrechte definieren, indem Sie die `PdfOptions`‑Klasse vor dem Speichern der Präsentation als PDF konfigurieren.

**Unterstützt Aspose.Slides die Konvertierung von PDF in andere Formate?**

Ja, Aspose.Slides unterstützt die Konvertierung von PDFs in Formate wie HTML, Bildformate (JPG, PNG), SVG, TIFF und XML.

**Wie stelle ich sicher, dass mein PDF den Barrierefreiheitsstandards entspricht?**

Setzen Sie die Eigenschaft `compliance` in `PdfOptions` auf Standards wie `PDF_A1A`, `PDF_A1B` oder `PDF_UA`, um die Konformität mit den Zugänglichkeitsrichtlinien zu gewährleisten.

**Kann ich versteckte Folien in die PDF‑Ausgabe aufnehmen?**

Ja, indem Sie die Eigenschaft `show_hidden_slides` in `PdfOptions` auf `True` setzen, werden versteckte Folien im PDF enthalten sein.

**Wie kann ich die Bildqualität und Auflösung während der Konvertierung anpassen?**

Verwenden Sie die Eigenschaften `jpeg_quality` und `sufficient_resolution` in `PdfOptions`, um die Bildqualität und Auflösung im resultierenden PDF zu steuern.

**Erkennt Aspose.Slides Schriftart‑Ersetzungen automatisch?**

Aspose.Slides erkennt Schriftart‑Ersetzungen während der Konvertierung, und Sie können sie über die Eigenschaft `warning_callback` in `SaveOptions` (derzeit eingeschränkt) behandeln.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für .NET‑Dokumentation](https://docs.aspose.com/slides/de/python-net/)
- [Aspose.Slides API‑Referenz](https://reference.aspose.com/slides/de/python-net/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)