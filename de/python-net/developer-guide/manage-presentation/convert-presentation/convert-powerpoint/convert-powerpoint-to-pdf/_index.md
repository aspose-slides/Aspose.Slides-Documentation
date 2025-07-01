---
title: PPT- und PPTX-Dateien in PDF umwandeln in Python | Erweiterte Optionen
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
- Aspose.Slides
description: "Schritt-für-Schritt-Anleitung zur Konvertierung von PPT, PPTX und ODP in hochwertige, WCAG-konforme PDFs in Python mit Aspose.Slides – einschließlich Passwortschutz, Folienauswahl und Kontrolle der Bildqualität."
showReadingTime: true
---

## **Übersicht**

Die Umwandlung von PowerPoint-Dokumenten in PDF-Format bietet mehrere Vorteile, einschließlich der Sicherstellung der Kompatibilität über verschiedene Geräte hinweg und der Bewahrung des Layouts und Formats Ihrer Präsentation. Dieser Artikel zeigt Ihnen, wie Sie Präsentationen in PDF-Dokumente umwandeln, verschiedene Optionen zur Steuerung der Bildqualität verwenden, versteckte Folien einschließen, PDF-Dokumente mit einem Passwort schützen, Schriftartsubstitutionen erkennen, Folien zur Umwandlung auswählen und Konformitätsstandards auf Ausgabedokumente anwenden können.

## **PowerPoint in PDF Umwandlungen**

Mit Aspose.Slides können Sie Präsentationen in diesen Formaten in PDF umwandeln:

* PPT
* PPTX
* ODP

Um eine Präsentation in PDF in Python umzuwandeln, müssen Sie einfach den Dateinamen als Argument in der [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) Klasse übergeben und dann die Präsentation als PDF mit einer [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) Methode speichern. Die [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) Klasse bietet die [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) Methode, die typischerweise verwendet wird, um eine Präsentation in PDF umzuwandeln.

{{%  alert title="HINWEIS"  color="warning"   %}} 

Aspose.Slides für Python schreibt direkt API-Informationen und Versionsnummer in die Ausgabedokumente. Zum Beispiel, wenn es eine Präsentation in PDF umwandelt, füllt Aspose.Slides für Python das Anwendungsfeld mit dem Wert '*Aspose.Slides*' und das PDF-Producer-Feld mit einem Wert in der Form '*Aspose.Slides v XX.XX*'. **Hinweis**: Sie können Aspose.Slides für Python nicht anweisen, diese Informationen aus den Ausgabedokumenten zu ändern oder zu entfernen.

{{% /alert %}}

Aspose.Slides ermöglicht Ihnen die Umwandlung von:

* einer gesamten Präsentation in PDF
* spezifischen Folien einer Präsentation in PDF
* einer Präsentation 

Aspose.Slides exportiert Präsentationen in PDF auf eine Weise, die die Inhalte der resultierenden PDFs den Originalpräsentationen sehr ähnlich macht. Diese bekannten Elemente und Attribute werden oft korrekt in der Umwandlung von Präsentationen in PDF dargestellt:

* Bilder
* Textfelder und andere Formen
* Texte und deren Formatierung
* Absätze und deren Formatierung
* Hyperlinks
* Kopf- und Fußzeilen
* Aufzählungen
* Tabellen

## **PowerPoint in PDF umwandeln**

Der standardmäßige Vorgang zur Umwandlung von PowerPoint in PDF wird mit Standardoptionen ausgeführt. In diesem Fall versucht Aspose.Slides, die bereitgestellte Präsentation mit optimalen Einstellungen auf den maximalen Qualitätsstufen in PDF umzuwandeln. Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint in PDF umwandeln:

_Schritte: PowerPoint in PDF Umwandlungen in Python_

Der folgende Beispielcode beschreibt diese Umwandlungen mithilfe von Python über .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Schritte: PowerPoint in PDF mit Python über .NET umwandeln</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Schritte: PPT in PDF mit Python über .NET umwandeln</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Schritte: PPTX in PDF mit Python über .NET umwandeln</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Schritte: ODP in PDF mit Python über .NET umwandeln</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Schritte: PPS in PDF mit Python über .NET umwandeln</a></strong>

_Code Schritte:_

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und übergeben Sie ihr die PowerPoint-Datei.
  * _.ppt_ Erweiterung, um die **PPT**-Datei innerhalb der _Presentation_ Klasse zu laden.
  * _.pptx_ Erweiterung, um die **PPTX**-Datei innerhalb der _Presentation_ Klasse zu laden.
  * _.odp_ Erweiterung, um die **ODP**-Datei innerhalb der _Presentation_ Klasse zu laden.
  * _.pps_ Erweiterung, um die **PPS**-Datei innerhalb der _Presentation_ Klasse zu laden.
- Speichern Sie die _Presentation_ im **PDF**-Format, indem Sie die **Save** Methode aufrufen und die **SaveFormat.PDF** Aufzählung verwenden.
  

```python
import aspose.slides as slides

# Erstellt eine Präsentationsinstanz, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.ppt")

# Speichert die Präsentation als PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose bietet einen kostenlosen Online-[**PowerPoint zu PDF-Konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) an, der den Prozess der Umwandlung von Präsentationen in PDF demonstriert. Für eine live Implementierung des hier beschriebenen Verfahrens können Sie einen Test mit dem Konverter durchführen.

{{% /alert %}}

## PowerPoint in PDF mit Optionen umwandeln

Aspose.Slides bietet benutzerdefinierte Optionen – Eigenschaften unter der [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) Klasse – die es Ihnen ermöglichen, das PDF (das aus dem Umwandlungsprozess resultiert) anzupassen, das PDF mit einem Passwort zu sperren oder sogar festzulegen, wie der Umwandlungsprozess ablaufen soll.

### **PowerPoint in PDF mit benutzerdefinierten Optionen umwandeln**

Mit benutzerdefinierten Umwandlungsoptionen können Sie Ihre bevorzugte Qualitätseinstellung für Rasterbilder festlegen, angeben, wie Metadateien behandelt werden sollen, ein Kompressionsniveau für Texte festlegen, DPI für Bilder festlegen usw.

Das folgende Codebeispiel demonstriert einen Vorgang, bei dem eine PowerPoint-Präsentation mit mehreren benutzerdefinierten Optionen in PDF umgewandelt wird:

```python
import aspose.slides as slides

# Instanziiert die PdfOptions-Klasse
pdf_options = slides.export.PdfOptions()

# Setzt die Qualität für JPG-Bilder
pdf_options.jpeg_quality = 90

# Setzt DPI für Bilder
pdf_options.sufficient_resolution = 300

# Setzt das Verhalten für Metadateien
pdf_options.save_metafiles_as_png = True

# Setzt das Textkompressionslevel für Textinhalte
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Definiert den PDF-Konformitätsmodus
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instanziiert die Presentation-Klasse, die ein PowerPoint-Dokument darstellt
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Speichert die Präsentation als PDF-Dokument
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint in PDF mit versteckten Folien umwandeln**

Wenn eine Präsentation versteckte Folien enthält, können Sie eine benutzerdefinierte Option – die Eigenschaft `show_hidden_slides` aus der [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) Klasse – verwenden, um Aspose.Slides anzuweisen, die versteckten Folien als Seiten in das resultierende PDF einzufügen.

Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in PDF umwandeln, wobei versteckte Folien eingeschlossen sind:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Instanziiert die PdfOptions-Klasse
pdfOptions = slides.export.PdfOptions()

# Fügt versteckte Folien hinzu
pdfOptions.show_hidden_slides = True

# Speichert die Präsentation als PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint in passwortgeschützte PDF umwandeln**

Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint in eine passwortgeschützte PDF umwandeln (unter Verwendung der Schutzparameter aus der [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) Klasse):

```python
import aspose.slides as slides

# Instanziiert ein Präsentationsobjekt, das eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Instanziiert die PdfOptions-Klasse
pdfOptions = slides.export.PdfOptions()

# Setzt das PDF-Passwort und Zugriffsberechtigungen
pdfOptions.password = "passwort"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Erkennung von Schriftartsubstitutionen**

Aspose.Slides bietet die `warning_callback` Eigenschaft unter der [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) Klasse, um Ihnen zu ermöglichen, Schriftartsubstitutionen im Umwandlungsprozess von Präsentationen in PDF zu erkennen. 

Dieser Python-Code zeigt Ihnen, wie Sie Schriftartsubstitutionen erkennen:  

```python
[TODO[SLIDESPYNET-91]: Callbacks sind derzeit nicht unterstützt]
```

{{%  alert color="primary"  %}} 

Für weitere Informationen zur Schriftartsubstitution siehe den Artikel [Schriftartsubstitution](https://docs.aspose.com/slides/python-net/font-substitution/).

{{% /alert %}} 

## **Ausgewählte Folien in PowerPoint in PDF umwandeln**

Dieser Python-Code zeigt Ihnen, wie Sie spezifische Folien in einer PowerPoint-Präsentation in PDF umwandeln:

```python
import aspose.slides as slides

# Instanziiert ein Präsentationsobjekt, das eine PowerPoint-Datei darstellt
presentation = slides.Presentation("PowerPoint.pptx")

# Setzt ein Array von Folienpositionen
slides_array = [ 1, 3 ]

# Speichert die Präsentation als PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße umwandeln**

Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint umwandeln, wenn die Foliengröße spezifiziert ist, in eine PDF:

```python
import aspose.slides as slides

# Instanziiert ein Präsentationsobjekt, das eine PowerPoint-Datei darstellt 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Setzt den Folientyp und die Größe 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PowerPoint in PDF in Notizenansicht umwandeln**

Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint in PDF-Notizen umwandeln:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine PowerPoint-Datei darstellt
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Speichert die Präsentation als PDF-Notizen
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Zugänglichkeit und Konformitätsstandards für PDF**

Aspose.Slides ermöglicht es Ihnen, ein Umsetzungsverfahren zu verwenden, das den [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) entspricht. Sie können ein PowerPoint-Dokument in PDF unter Verwendung eines dieser Konformitätsstandards exportieren: **PDF/A1a**, **PDF/A1b** und **PDF/UA**.

Dieser Python-Code demonstriert einen Vorgang zur Umwandlung von PowerPoint in PDF, bei dem mehrere PDFs basierend auf verschiedenen Konformitätsstandards erstellt werden:

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

Die Unterstützung von Aspose.Slides für PDF-Umwandlungsoperationen erstreckt sich auch darauf, Ihnen die Möglichkeit zu geben, PDF in die beliebtesten Dateiformate zu konvertieren. Sie können [PDF in HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF in Bild](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF in JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) und [PDF in PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) Umwandlungen durchführen. Andere PDF-Konvertierungsoperationen in spezialisierte Formate—[PDF in SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF in TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) und [PDF in XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—werden ebenfalls unterstützt.

{{% /alert %}}