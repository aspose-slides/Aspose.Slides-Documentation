---
title: PPT & PPTX zu PDF in Python | Erweiterte Optionen
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
- Aspose.Slides for Python
description: "Schritt‑für‑Schritt‑Anleitung zur Konvertierung von PPT, PPTX und ODP in hochwertige, WCAG‑konforme PDFs in Python mit Aspose.Slides – beinhaltet Passwortschutz, Folienauswahl und Bildqualitäts‑Kontrolle."
showReadingTime: true
---

## **Übersicht**

Das Konvertieren von PowerPoint‑Präsentationen (PPT, PPTX, ODP) in das PDF‑Format mit Python bietet mehrere Vorteile, darunter die Sicherstellung der Kompatibilität auf verschiedenen Geräten und das Bewahren von Layout und Formatierung Ihrer Präsentation. Dieser Leitfaden zeigt, wie Präsentationen in PDF‑Dokumente konvertiert werden, verschiedene Optionen zur Steuerung der Bildqualität verwendet werden, versteckte Folien einbezogen, PDF‑Dokumente passwortgeschützt werden, Schriftart‑Ersetzungen erkannt, bestimmte Folien für die Konvertierung ausgewählt und Konformitätsstandards auf Ausgabedokumente angewendet werden.

## **PowerPoint‑zu‑PDF‑Konvertierungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten zu PDF konvertieren:

* **PPT**
* **PPTX**
* **ODP**

Um eine Präsentation in Python zu PDF zu konvertieren, übergeben Sie einfach den Dateinamen als Argument in der [Präsentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)‑Klasse und speichern die Präsentation anschließend als PDF mit einer [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods)‑Methode. Die [Präsentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)‑Klasse stellt die [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods)‑Methode bereit, die typischerweise zum Konvertieren einer Präsentation zu PDF verwendet wird.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides für Python schreibt API‑Informationen und Versionsnummer direkt in Ausgabedokumente. Beispielsweise füllt Aspose.Slides für Python beim Konvertieren einer Präsentation zu PDF das Feld *Application* mit dem Wert '*Aspose.Slides*' und das Feld *PDF Producer* mit einem Wert in der Form '*Aspose.Slides v XX.XX*'. **Hinweis**: Sie können Aspose.Slides für Python nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht Ihnen die Konvertierung von:

* gesamten Präsentationen zu PDF
* einzelnen Folien einer Präsentation zu PDF

Aspose.Slides exportiert Präsentationen zu PDF und stellt sicher, dass der Inhalt der resultierenden PDFs eng mit den Originalpräsentationen übereinstimmt. Elemente und Attribute werden bei der Konvertierung genau wiedergegeben, einschließlich:

* Bilder
* Textfelder und Formen
* Textformatierung
* Absatzformatierung
* Hyperlinks
* Kopf‑ und Fußzeilen
* Aufzählungszeichen
* Tabellen

## **PowerPoint zu PDF konvertieren**

Der Standard‑PowerPoint‑PDF‑Konvertierungsvorgang wird mit den Standardeinstellungen ausgeführt. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation zu PDF mit optimalen Einstellungen und maximaler Qualität zu konvertieren. Dieser Python‑Code zeigt, wie Sie ein PowerPoint‑Dokument zu PDF konvertieren:

_Schritte: PowerPoint‑zu‑PDF‑Konvertierungen in Python_

Der folgende Beispielcode erklärt diese Konvertierungen mit Python über .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Schritte: PowerPoint zu PDF mit Python über .NET konvertieren</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Schritte: PPT zu PDF mit Python über .NET konvertieren</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Schritte: PPTX zu PDF mit Python über .NET konvertieren</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Schritte: ODP zu PDF mit Python über .NET konvertieren</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Schritte: PPS zu PDF mit Python über .NET konvertieren</strong></a>

_Code‑Schritte:_

- Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse erstellen und die PowerPoint‑Datei übergeben.
  * *.ppt*‑Erweiterung zum Laden einer **PPT**‑Datei in der _Presentation_-Klasse.
  * *.pptx*‑Erweiterung zum Laden einer **PPTX**‑Datei in der _Presentation_-Klasse.
  * *.odp*‑Erweiterung zum Laden einer **ODP**‑Datei in der _Presentation_-Klasse.
  * *.pps*‑Erweiterung zum Laden einer **PPS**‑Datei in der _Presentation_-Klasse.
- Die _Presentation_ mit dem Aufruf der **Save**‑Methode und der Verwendung der **SaveFormat.PDF**‑Enumeration im **PDF**‑Format speichern.
```python
import aspose.slides as slides

# Instanziert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.ppt")

# Speichert die Präsentation als PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```


{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online‑[**PowerPoint‑zu‑PDF‑Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf), der den Präsentation‑zu‑PDF‑Konvertierungsprozess demonstriert. Für eine Live‑Implementierung des hier beschriebenen Verfahrens können Sie den Konverter testen.

{{% /alert %}}

## **PowerPoint zu PDF mit Optionen konvertieren**

Aspose.Slides stellt benutzerdefinierte Optionen – Eigenschaften der [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)‑Klasse – zur Verfügung, mit denen Sie das resultierende PDF anpassen, mit einem Passwort schützen oder sogar das Verhalten des Konvertierungsprozesses festlegen können.

### **PowerPoint zu PDF mit benutzerdefinierten Optionen konvertieren**

Mit benutzerdefinierten Konvertierungsoptionen können Sie Ihre bevorzugte Qualitätsstufe für Raster‑Bilder festlegen, bestimmen, wie Metadateien behandelt werden, ein Kompressionsniveau für Texte definieren, DPI für Bilder setzen usw.

Das nachfolgende Code‑Beispiel demonstriert eine Operation, bei der eine PowerPoint‑Präsentation mit mehreren benutzerdefinierten Optionen zu PDF konvertiert wird:
```python
import aspose.slides as slides

# Instanziert die PdfOptions-Klasse
pdf_options = slides.export.PdfOptions()

# Legt die Qualität für JPG-Bilder fest
pdf_options.jpeg_quality = 90

# Legt die DPI für Bilder fest
pdf_options.sufficient_resolution = 300

# Legt das Verhalten für Metadateien fest
pdf_options.save_metafiles_as_png = True

# Legt das Textkomprimierungsniveau für Textinhalte fest
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definiert den PDF-Konformitätsmodus
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instanziert die Presentation-Klasse, die ein PowerPoint-Dokument darstellt
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Speichert die Präsentation als PDF-Dokument
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


### **PowerPoint zu PDF mit versteckten Folien konvertieren**

Enthält eine Präsentation versteckte Folien, können Sie mit der benutzerdefinierten Option `show_hidden_slides` aus der [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)‑Klasse Aspose.Slides anweisen, die versteckten Folien als Seiten im resultierenden PDF einzuschließen.

Dieser Python‑Code zeigt, wie Sie eine PowerPoint‑Präsentation zu PDF mit eingeschlossenen versteckten Folien konvertieren:
```python
import aspose.slides as slides

# Instanziert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Instanziert die PdfOptions-Klasse
pdfOptions = slides.export.PdfOptions()

# Fügt ausgeblendete Folien hinzu
pdfOptions.show_hidden_slides = True

# Speichert die Präsentation als PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```


### **PowerPoint zu passwortgeschütztem PDF konvertieren**

Dieser Python‑Code zeigt, wie Sie ein PowerPoint‑Dokument zu einem passwortgeschützten PDF konvertieren (unter Verwendung von Schutz‑Parametern aus der [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)‑Klasse):
```python
import aspose.slides as slides

# Instanziert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Instanziert die PdfOptions-Klasse
pdfOptions = slides.export.PdfOptions()

# Legt das PDF-Passwort und die Zugriffsrechte fest
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```


### **Schriftart‑Ersetzungen erkennen**

Aspose.Slides stellt die Eigenschaft `warning_callback` unter der [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/)‑Klasse bereit, um Schriftart‑Ersetzungen während des Präsentation‑zu‑PDF‑Konvertierungsprozesses zu erkennen.

Dieser Python‑Code zeigt, wie Sie Schriftart‑Ersetzungen erkennen:
```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```


{{%  alert color="primary"  %}} 

Weitere Informationen zu Schriftart‑Ersetzungen finden Sie im Artikel [Font Substitution](https://docs.aspose.com/slides/python-net/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint zu PDF konvertieren**

Dieser Python‑Code zeigt, wie Sie bestimmte Folien einer PowerPoint‑Präsentation zu PDF konvertieren:
```python
import aspose.slides as slides

# Instanziert ein Presentation-Objekt, das eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Legt ein Array von Folienpositionen fest
slides_array = [ 1, 3 ]

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```


## **PowerPoint zu PDF mit benutzerdefinierter Foliengröße konvertieren**

Dieser Python‑Code zeigt, wie Sie ein PowerPoint‑Dokument mit festgelegter Foliengröße zu PDF konvertieren:
```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Instanziert die Presentation-Klasse, die eine PowerPoint- oder OpenDocument-Datei darstellt.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Erstellt eine neue Präsentation mit angepasster Foliengröße.
    with slides.Presentation() as resized_presentation:

        # Setzt die benutzerdefinierte Foliengröße.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Klont die erste Folie aus der Originalpräsentation.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Speichert die skalierte Präsentation als PDF mit Notizen.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```


## **PowerPoint zu PDF im Notizfolien‑Ansicht konvertieren**

Dieser Python‑Code zeigt, wie Sie ein PowerPoint‑Dokument zu PDF‑Notizen konvertieren:
```python
import aspose.slides as slides

# Instanziert eine Presentation-Klasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Speichert die Präsentation in PDF-Notizen
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```


## **Barrierefreiheit und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht Ihnen ein Konvertierungsverfahren, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint‑Dokument zu PDF exportieren und dabei einen der folgenden Konformitätsstandards verwenden: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Python‑Code demonstriert eine PowerPoint‑zu‑PDF‑Konvertierung, bei der mehrere PDFs basierend auf unterschiedlichen Konformitätsstandards erzeugt werden:
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

Aspose.Slides‑Unterstützung für PDF‑Konvertierungsoperationen erstreckt sich darauf, dass Sie PDFs in die beliebtesten Dateiformate konvertieren können. Sie können [PDF zu HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF zu Bild](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF zu JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) und [PDF zu PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) Konvertierungen durchführen. Weitere PDF‑Konvertierungsoperationen zu spezialisierten Formaten – [PDF zu SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF zu TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), und [PDF zu XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) – werden ebenfalls unterstützt.

{{% /alert %}}

## **FAQ**

**Kann Aspose.Slides für Python die Anwendungsinformationen aus dem PDF entfernen?**

Nein, Aspose.Slides für Python fügt automatisch API‑Informationen und die Versionsnummer in das Ausgabepdf ein. Diese Informationen können nicht geändert oder entfernt werden.

**Wie kann ich nur bestimmte Folien in die PDF‑Konvertierung einbeziehen?**

Sie können die Folienindizes, die Sie konvertieren möchten, angeben, indem Sie ein Array von Folienpositionen an die `save`‑Methode übergeben.

**Ist es möglich, das PDF während der Konvertierung mit einem Passwort zu schützen?**

Ja, Sie können ein Passwort setzen und Zugriffsrechte über die `PdfOptions`‑Klasse definieren, bevor Sie die Präsentation als PDF speichern.

**Unterstützt Aspose.Slides die Konvertierung von PDF in andere Formate?**

Ja, Aspose.Slides unterstützt die Konvertierung von PDFs in Formate wie HTML, Bildformate (JPG, PNG), SVG, TIFF und XML.

**Wie kann ich sicherstellen, dass mein PDF den Barrierefreiheits‑Standards entspricht?**

Setzen Sie die Eigenschaft `compliance` in `PdfOptions` auf Standards wie `PDF_A1A`, `PDF_A1B` oder `PDF_UA`, um die Konformität mit den Barrierefreiheits‑Richtlinien sicherzustellen.

**Kann ich versteckte Folien in die PDF‑Ausgabe aufnehmen?**

Ja, indem Sie die Eigenschaft `show_hidden_slides` in `PdfOptions` auf `True` setzen, werden versteckte Folien in das PDF aufgenommen.

**Wie stelle ich Bildqualität und Auflösung während der Konvertierung ein?**

Verwenden Sie die Eigenschaften `jpeg_quality` und `sufficient_resolution` in `PdfOptions`, um die Bildqualität und Auflösung im resultierenden PDF zu steuern.

**Erkennt Aspose.Slides Schriftart‑Ersetzungen automatisch?**

Aspose.Slides erkennt Schriftart‑Ersetzungen während der Konvertierung, und Sie können sie über die `warning_callback`‑Eigenschaft in `SaveOptions` (derzeit eingeschränkt) behandeln.

## **Zusätzliche Ressourcen**

- [Aspose.Slides für .NET Dokumentation](https://docs.aspose.com/slides/python-net/)
- [Aspose.Slides API‑Referenz](https://reference.aspose.com/slides/python-net/)
- [Aspose Kostenlose Online‑Konverter](https://products.aspose.app/slides/conversion)