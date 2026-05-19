---
title: PPT & PPTX in PDF konvertieren mit Python | Erweiterte Optionen
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/python-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertieren
- Präsentation
- PowerPoint zu PDF
- PPT zu PDF
- PPTX zu PDF
- PowerPoint als PDF speichern
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides für Python
description: "Schritt‑für‑Schritt‑Anleitung zum Konvertieren von PPT, PPTX und ODP in hochwertige, WCAG‑konforme PDFs mit Python und Aspose.Slides – enthält Passwortschutz, Folienauswahl und Kontrolle der Bildqualität."
showReadingTime: true
---
## **Überblick**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP) in das PDF‑Format mit Python bietet mehrere Vorteile, darunter die Sicherstellung der Kompatibilität auf verschiedenen Geräten und das Erhalten von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Sie Präsentationen in PDF‑Dokumente konvertieren, verschiedene Optionen zur Steuerung der Bildqualität nutzen, versteckte Folien einbeziehen, PDF‑Dokumente passwortschützen, Font‑Ersetzungen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance‑Standards auf die Ausgabedokumente anwenden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in Python in PDF zu konvertieren, übergeben Sie einfach den Dateinamen als Argument an die [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse und speichern die Präsentation anschließend mit einer [Save](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/#methods)‑Methode als PDF. Die [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse stellt die [Save](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/#methods)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für Python schreibt API‑Informationen und Versionsnummer direkt in Ausgabedokumente. Beispielsweise füllt Aspose.Slides für Python beim Konvertieren einer Präsentation in PDF das Feld „Application“ mit dem Wert „*Aspose.Slides*“ und das Feld „PDF Producer“ mit einem Wert in der Form „*Aspose.Slides v XX.XX*“. **Hinweis**, dass Sie Aspose.Slides für Python nicht anweisen können, diese Informationen aus Ausgabedokumenten zu entfernen oder zu ändern.

{{% /alert %}}

Aspose.Slides ermöglicht Ihnen das Konvertieren von:

* gesamten Präsentationen in PDF
* bestimmten Folien einer Präsentation in PDF

Aspose.Slides exportiert Präsentationen nach PDF und sorgt dafür, dass der Inhalt der resultierenden PDFs dem Original stark entspricht. Elemente und Attribute werden bei der Konvertierung exakt gerendert, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint in PDF konvertieren**

Der Standard‑PowerPoint‑PDF‑Konvertierungsvorgang wird mit den Standardoptionen ausgeführt. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf höchstem Qualitätsniveau in PDF zu konvertieren. Dieser Python‑Code zeigt, wie Sie eine PowerPoint‑Datei in PDF konvertieren:

_Schritte: PowerPoint‑zu‑PDF‑Konvertierungen in Python_

Der folgende Beispielcode erklärt diese Konvertierungen mit Python über .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Schritte: PowerPoint mit Python über .NET in PDF konvertieren</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Schritte: PPT mit Python über .NET in PDF konvertieren</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Schritte: PPTX mit Python über .NET in PDF konvertieren</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Schritte: ODP mit Python über .NET in PDF konvertieren</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Schritte: PPS mit Python über .NET in PDF konvertieren</strong></a>

_Code‑Schritte:_

- Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse erstellen und die PowerPoint‑Datei übergeben.
  * _.ppt_-Erweiterung zum Laden einer **PPT**‑Datei in der _Presentation_-Klasse.
  * _.pptx_-Erweiterung zum Laden einer **PPTX**‑Datei in der _Presentation_-Klasse.
  * _.odp_-Erweiterung zum Laden einer **ODP**‑Datei in der _Presentation_-Klasse.
  * _.pps_-Erweiterung zum Laden einer **PPS**‑Datei in der _Presentation_-Klasse.
- Die _Presentation_ im **PDF**‑Format speichern, indem die **Save**‑Methode mit der Aufzählung **SaveFormat.PDF** aufgerufen wird.
  

```python
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.ppt")

# Speichert die Präsentation als PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf), der den Konvertierungsprozess von Präsentation zu PDF demonstriert. Für eine Live‑Umsetzung des hier beschriebenen Verfahrens können Sie den Konverter testen.

{{% /alert %}}

## **PowerPoint in PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides.export/pdfoptions/) – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder sogar das Konvertierungsverhalten festlegen können.

### **PowerPoint in PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Komprimierungslevel für Texte setzen, DPI für Bilder festlegen usw.

Das folgende Codebeispiel demonstriert einen Vorgang, bei dem eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen in PDF konvertiert wird:

```python
import aspose.slides as slides

# Erstellt eine Instanz der PdfOptions-Klasse
pdf_options = slides.export.PdfOptions()

# Legt die Qualität für JPG-Bilder fest
pdf_options.jpeg_quality = 90

# Legt die DPI für Bilder fest
pdf_options.sufficient_resolution = 300

# Legt das Verhalten für Metadateien fest
pdf_options.save_metafiles_as_png = True

# Legt das Komprimierungsniveau für Textinhalte fest
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definiert den PDF‑Compliance‑Modus
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Erstellt eine Instanz der Presentation-Klasse, die ein PowerPoint-Dokument darstellt
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Speichert die Präsentation als PDF-Dokument
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint in PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie die benutzerdefinierte Option `show_hidden_slides` der Klasse [PdfOptions](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides.export/pdfoptions/) verwenden, um Aspose.Slides anzuweisen, die versteckten Folien als Seiten im resultierenden PDF aufzunehmen.

Dieser Python‑Code zeigt, wie Sie eine PowerPoint‑Präsentation mit einbezogenen versteckten Folien in PDF konvertieren:

```python
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Erstellt eine Instanz der PdfOptions-Klasse
pdfOptions = slides.export.PdfOptions()

# Fügt versteckte Folien hinzu
pdfOptions.show_hidden_slides = True

# Speichert die Präsentation als PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint in passwortgeschütztes PDF konvertieren**

Dieser Python‑Code zeigt, wie Sie eine PowerPoint‑Datei in ein passwortgeschütztes PDF konvertieren (unter Verwendung von Schutzparametern aus der Klasse [PdfOptions](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Erstellt ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Erstellt eine Instanz der PdfOptions-Klasse
pdfOptions = slides.export.PdfOptions()

# Legt das PDF-Passwort und die Zugriffsberechtigungen fest
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Font‑Ersetzungen erkennen**

Aspose.Slides stellt die Eigenschaft `warning_callback` der Klasse [SaveOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveoptions/) bereit, um Font‑Ersetzungen im Konvertierungsprozess von Präsentation zu PDF zu erkennen.

Dieser Python‑Code zeigt, wie Sie Font‑Ersetzungen erkennen:

```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```

{{%  alert color="primary"  %}} 

Weitere Informationen zu Font‑Ersetzungen finden Sie im Artikel [Font Substitution](https://docs.aspose.com/slides/de/python-net/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF konvertieren**

Dieser Python‑Code zeigt, wie Sie bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:

```python
import aspose.slides as slides

# Erstellt ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Legt ein Array von Folienpositionen fest
slides_array = [ 1, 3 ]

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser Python‑Code zeigt, wie Sie eine PowerPoint‑Präsentation mit festgelegter Foliengröße in PDF konvertieren:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Erstellt eine Instanz der Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Erstellt eine neue Präsentation mit angepasster Foliengröße.
    with slides.Presentation() as resized_presentation:

        # Legt die benutzerdefinierte Foliengröße fest.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Klont die erste Folie aus der Originalpräsentation.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Speichert die angepasste Präsentation als PDF mit Notizen.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint in PDF im Notizfolien‑Modus konvertieren**

Dieser Python‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in PDF‑Notizen konvertieren:

```python
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Speichert die Präsentation als PDF-Notizen
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht Ihnen die Verwendung eines Konvertierungsverfahrens, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument in PDF exportieren und dabei einen der folgenden Compliance‑Standards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Python‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsvorgang, bei dem mehrere PDFs basierend auf unterschiedlichen Compliance‑Standards erzeugt werden:

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

{{% alert title="Hinweis" color="warning" %}} 

Aspose.Slides‑Unterstützung für PDF‑Konvertierungen erstreckt sich zudem auf die Umwandlung von PDF in die beliebtesten Dateiformate. Sie können [PDF zu HTML](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-png/) durchführen. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-tiff/) und [PDF zu XML](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte gekennzeichnet werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

**Kann Aspose.Slides für Python die Anwendungsinformationen aus dem PDF entfernen?**

Nein, Aspose.Slides für Python fügt automatisch API‑Informationen und die Versionsnummer in das Ausgabepdf ein. Diese Informationen können nicht geändert oder entfernt werden.

**Wie kann ich nur bestimmte Folien in die PDF‑Konvertierung einbeziehen?**

Sie können die gewünschten Folienindizes angeben, indem Sie ein Array von Folienpositionen an die `save`‑Methode übergeben.

**Ist es möglich, das PDF während der Konvertierung mit einem Passwort zu schützen?**

Ja, Sie können ein Passwort festlegen und Zugriffsrechte definieren, indem Sie die `PdfOptions`‑Klasse vor dem Speichern der Präsentation als PDF verwenden.

**Unterstützt Aspose.Slides die Konvertierung von PDF in andere Formate?**

Ja, Aspose.Slides unterstützt die Konvertierung von PDFs in Formate wie HTML, Bildformate (JPG, PNG), SVG, TIFF und XML.

**Wie kann ich sicherstellen, dass mein PDF den Barrierefreiheitsstandards entspricht?**

Setzen Sie die Eigenschaft `compliance` in `PdfOptions` auf Standards wie `PDF_A1A`, `PDF_A1B` oder `PDF_UA`, um die Konformität mit den Zugänglichkeitsrichtlinien zu gewährleisten.

**Kann ich versteckte Folien in die PDF‑Ausgabe einbeziehen?**

Ja, indem Sie die Eigenschaft `show_hidden_slides` in `PdfOptions` auf `True` setzen, werden versteckte Folien in das PDF aufgenommen.

**Wie passe ich die Bildqualität und Auflösung während der Konvertierung an?**

Verwenden Sie die Eigenschaften `jpeg_quality` und `sufficient_resolution` in `PdfOptions`, um die Bildqualität und Auflösung im resultierenden PDF zu steuern.

**Erkennt Aspose.Slides Font‑Ersetzungen automatisch?**

Aspose.Slides erkennt Font‑Ersetzungen während der Konvertierung, und Sie können sie über die Eigenschaft `warning_callback` in `SaveOptions` (derzeit eingeschränkt) behandeln.

## **Weitere Ressourcen**

- [Aspose.Slides für .NET‑Dokumentation](https://docs.aspose.com/slides/de/python-net/)
- [Aspose.Slides API‑Referenz](https://reference.aspose.com/slides/de/python-net/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)