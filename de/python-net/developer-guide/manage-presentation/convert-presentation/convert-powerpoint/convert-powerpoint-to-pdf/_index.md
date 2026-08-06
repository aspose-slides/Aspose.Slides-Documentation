---
title: PPT & PPTX nach PDF in Python konvertieren | Erweiterte Optionen
linktitle: PowerPoint zu PDF
type: docs
weight: 40
url: /de/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
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
- Aspose.Slides for Python
description: "Schritt-für-Schritt-Anleitung zur Konvertierung von PPT, PPTX und ODP in hochwertige, WCAG-konforme PDFs in Python mit Aspose.Slides – inklusive Passwortschutz, Folienauswahl und Bildqualitätssteuerung."
showReadingTime: true
---
## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP) in das PDF‑Format mit Python bietet mehrere Vorteile, darunter die Gewährleistung der Kompatibilität auf verschiedenen Geräten und das Bewahren des Layouts sowie der Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Sie Präsentationen in PDF‑Dokumente umwandeln, verschiedene Optionen zur Steuerung der Bildqualität nutzen, ausgeblendete Folien einbeziehen, PDF‑Dokumente mit einem Passwort schützen, Schriftart‑Ersetzungen erkennen, bestimmte Folien für die Konvertierung auswählen und Compliance‑Standards auf Ausgabedokumente anwenden.

## **Installation**

```bash
pip install aspose.slides
```

Das Paket enthält die benötigte Runtime, sodass Microsoft PowerPoint nicht auf dem Rechner installiert sein muss, der die Konvertierung durchführt.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in Python zu PDF zu konvertieren, übergeben Sie einfach den Dateinamen als Argument an die [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse und speichern die Präsentation anschließend mit der [Save](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/#methods)‑Methode als PDF. Die [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse stellt die [Save](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/#methods)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation in PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python schreibt API‑Informationen und Versionsnummer direkt in Ausgabedokumente. Beispiel: Beim Konvertieren einer Präsentation in PDF füllt Aspose.Slides for Python das Feld „Application“ mit dem Wert '*Aspose.Slides*' und das Feld „PDF Producer“ mit einem Wert in der Form '*Aspose.Slides v XX.XX*'. **Hinweis:** Sie können Aspose.Slides for Python nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht das Konvertieren von:

* gesamten Präsentationen zu PDF
* einzelnen Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen nach PDF und stellt sicher, dass der Inhalt der resultierenden PDFs eng mit den Originalpräsentationen übereinstimmt. Elemente und Attribute werden bei der Konvertierung exakt wiedergegeben, darunter:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint‑PDF‑Konvertierungsvorgang wird mit den voreingestellten Optionen ausgeführt. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen und maximaler Qualität in PDF zu konvertieren. Der folgende Python‑Code zeigt, wie Sie ein PowerPoint in PDF umwandeln:

_Schritte: PowerPoint‑zu‑PDF‑Konvertierungen in Python_

Der nachfolgende Beispielcode erklärt diese Konvertierungen mit Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Schritte: PowerPoint mit Python via .NET in PDF konvertieren</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Schritte: PPT mit Python via .NET in PDF konvertieren</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Schritte: PPTX mit Python via .NET in PDF konvertieren</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Schritte: ODP mit Python via .NET in PDF konvertieren</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Schritte: PPS mit Python via .NET in PDF konvertieren</a></strong>

_Code‑Schritte:_

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse und übergeben Sie ihr die PowerPoint‑Datei.
  * *.ppt*‑Erweiterung, um **PPT**‑Dateien in der _Presentation_‑Klasse zu laden.
  * *.pptx*‑Erweiterung, um **PPTX**‑Dateien in der _Presentation_‑Klasse zu laden.
  * *.odp*‑Erweiterung, um **ODP**‑Dateien in der _Presentation_‑Klasse zu laden.
  * *.pps*‑Erweiterung, um **PPS**‑Dateien in der _Presentation_‑Klasse zu laden.
- Speichern Sie die _Presentation_ im **PDF**‑Format, indem Sie die **Save**‑Methode aufrufen und die Aufzählung **SaveFormat.PDF** verwenden.

```python
import aspose.slides as slides

# Instanziiert eine Presentation‑Klasse, die eine PowerPoint‑Datei darstellt
presentation = slides.Presentation("PowerPoint.ppt")

# Speichert die Präsentation als PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/de/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Für eine Live‑Implementierung des hier beschriebenen Verfahrens können Sie den Konverter testen.

{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der Klasse [PdfOptions](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides.export/pdfoptions/) – bereit, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder sogar das Verhalten des Konvertierungsprozesses festlegen können.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Rasterbilder festlegen, festlegen, wie Metadateien behandelt werden, ein Kompressionsniveau für Text festlegen, DPI für Bilder setzen usw.

Das nachstehende Code‑Beispiel demonstriert einen Vorgang, bei dem eine PowerPoint‑Präsentation unter Verwendung mehrerer benutzerdefinierter Optionen in PDF konvertiert wird:

```python
import aspose.slides as slides

# Instanziiert die PdfOptions‑Klasse
pdf_options = slides.export.PdfOptions()

# Legt die Qualität für JPG‑Bilder fest
pdf_options.jpeg_quality = 90

# Legt DPI für Bilder fest
pdf_options.sufficient_resolution = 300

# Legt das Verhalten für Metadateien fest
pdf_options.save_metafiles_as_png = True

# Legt das Textkompressionslevel für textuelle Inhalte fest
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definiert den PDF‑Compliance‑Modus
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instanziiert die Presentation‑Klasse, die ein PowerPoint‑Dokument darstellt
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Speichert die Präsentation als PDF‑Dokument
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint zu PDF mit ausgeblendeten Folien**

Enthält eine Präsentation ausgeblendete Folien, können Sie die benutzerdefinierte Option `show_hidden_slides` der Klasse [PdfOptions](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides.export/pdfoptions/) verwenden, um Aspose.Slides anzuweisen, die ausgeblendeten Folien als Seiten im resultierenden PDF einzubeziehen.

Dieser Python‑Code zeigt, wie Sie eine PowerPoint‑Präsentation mit einbezogenen ausgeblendeten Folien in PDF konvertieren:

```python
import aspose.slides as slides

# Instanziiert eine Presentation‑Klasse, die eine PowerPoint‑Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Instanziiert die PdfOptions‑Klasse
pdfOptions = slides.export.PdfOptions()

# Fügt ausgeblendete Folien hinzu
pdfOptions.show_hidden_slides = True

# Speichert die Präsentation als PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint zu passwortgeschütztem PDF konvertieren**

Dieser Python‑Code zeigt, wie Sie ein PowerPoint in ein passwortgeschütztes PDF konvertieren (unter Verwendung von Schutzparametern aus der Klasse [PdfOptions](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Instanziiert ein Presentation‑Objekt, das eine PowerPoint‑Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Instanziiert die PdfOptions‑Klasse
pdfOptions = slides.export.PdfOptions()

# Legt das PDF‑Passwort und die Zugriffsrechte fest
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Ausgewählte Folien in PowerPoint zu PDF konvertieren**

Dieser Python‑Code zeigt, wie Sie bestimmte Folien einer PowerPoint‑Präsentation in PDF konvertieren:

```python
import aspose.slides as slides

# Instanziiert ein Presentation‑Objekt, das eine PowerPoint‑Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Legt ein Array von Folienpositionen fest
slides_array = [ 1, 3 ]

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser Python‑Code zeigt, wie Sie ein PowerPoint mit festgelegter Foliengröße in PDF konvertieren:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Instanziiert die Presentation‑Klasse, die eine PowerPoint‑ oder OpenDocument‑Datei darstellt.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Erstellt eine neue Präsentation mit angepasster Foliengröße.
    with slides.Presentation() as resized_presentation:

        # Setzt die benutzerdefinierte Foliengröße.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Klonet die erste Folie der ursprünglichen Präsentation und entfernt die standardmäßige leere Folie.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Speichert die skalierte Präsentation als PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint zu PDF im Notiz‑Folien‑Ansicht konvertieren**

Dieser Python‑Code zeigt, wie Sie ein PowerPoint in PDF‑Notizen konvertieren:

```python
import aspose.slides as slides

# Instanziert eine Presentation‑Klasse, die eine PowerPoint‑Datei darstellt
presentation = slides.Presentation("NotesFile.pptx")

# Konfiguriert die PDF‑Optionen mit dem Notiz‑Layout
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Speichert die Präsentation als PDF mit Notizen
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Barrierefreiheit und Compliance‑Standards für PDF**

Aspose.Slides ermöglicht ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument mit einem der folgenden Compliance‑Standards in PDF exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Python‑Code demonstriert einen PowerPoint‑zu‑PDF‑Konvertierungsvorgang, bei dem mehrere PDFs auf Basis verschiedener Compliance‑Standards erstellt werden:

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

Aspose.Slides unterstützt PDF‑Konvertierungsoperationen, die Ihnen erlauben, PDFs in die beliebtesten Dateiformate zu konvertieren. Sie können Konvertierungen zu [PDF nach HTML](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-html/), [PDF nach Bild](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-image/), [PDF nach JPG](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-jpg/) und [PDF nach PNG](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-png/) durchführen. Weitere PDF‑Konvertierungen in Spezialformate – [PDF nach SVG](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-svg/), [PDF nach TIFF](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-tiff/) und [PDF nach XML](https://products.aspose.com/slides/de/python-net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

> **Hinweis:** Beim Exportieren nach PDF/UA behandelt Aspose.Slides komplexe Grafiken wie SmartArt, Diagramme und Formeln als einzelne Figur. Einzelne Pfadelemente werden nicht als separater Inhalt erhalten und können als Artefakte markiert werden; alternativer Text wird nur für die gesamte Figur bereitgestellt.

## **FAQ**

### Kann Aspose.Slides for Python die Anwendungsinformationen aus dem PDF entfernen?

Nein, Aspose.Slides for Python fügt automatisch API‑Informationen und die Versionsnummer in das Ausgabepdf ein. Diese Informationen können nicht geändert oder entfernt werden.

### Wie kann ich nur bestimmte Folien in die PDF‑Konvertierung einbeziehen?

Sie können die Folienindizes, die Sie konvertieren möchten, an die `save`‑Methode übergeben, indem Sie ein Array von Folienpositionen bereitstellen.

### Ist es möglich, das PDF während der Konvertierung mit einem Passwort zu schützen?

Ja, Sie können ein Passwort festlegen und Zugriffsrechte definieren, indem Sie vor dem Speichern der Präsentation als PDF die Klasse `PdfOptions` verwenden.

### Unterstützt Aspose.Slides die Konvertierung von PDF in andere Formate?

Ja, Aspose.Slides unterstützt die Konvertierung von PDFs in Formate wie HTML, Bildformate (JPG, PNG), SVG, TIFF und XML.

### Wie stelle ich sicher, dass mein PDF den Barrierefreiheits‑Standards entspricht?

Setzen Sie die Eigenschaft `compliance` in `PdfOptions` auf Standards wie `PDF_A1A`, `PDF_A1B` oder `PDF_UA`, um die Konformität mit den Barrierefreiheitsrichtlinien zu gewährleisten.

### Kann ich ausgeblendete Folien in die PDF‑Ausgabe einbeziehen?

Ja, indem Sie die Eigenschaft `show_hidden_slides` in `PdfOptions` auf `True` setzen, werden ausgeblendete Folien in das PDF aufgenommen.

### Wie kann ich die Bildqualität und Auflösung während der Konvertierung anpassen?

Verwenden Sie die Eigenschaften `jpeg_quality` und `sufficient_resolution` in `PdfOptions`, um die Bildqualität und Auflösung im resultierenden PDF zu steuern.

### Handhabt Aspose.Slides Schriftart‑Ersetzungen automatisch?

Aspose.Slides erkennt Schriftart‑Ersetzungen während der Konvertierung, und Sie können sie über die Eigenschaft `warning_callback` in `SaveOptions` (derzeit eingeschränkt) behandeln.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für .NET‑Dokumentation](https://docs.aspose.com/slides/de/python-net/)
- [Aspose.Slides API‑Referenz](https://reference.aspose.com/slides/de/python-net/)
- [Aspose kostenlose Online‑Konverter](https://products.aspose.app/slides/de/conversion)