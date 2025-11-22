---
title: PowerPoint-Präsentationen in HTML mit Python konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/python-net/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- PowerPoint als HTML speichern
- Präsentation als HTML speichern
- Folie als HTML speichern
- PPT als HTML speichern
- PPTX als HTML speichern
- Python
- Aspose.Slides
description: "PowerPoint-Präsentationen in responsives HTML mit Python konvertieren. Layout, Links und Bilder mit dem Aspose.Slides-Konvertierungsleitfaden erhalten für schnelle, fehlerfreie Ergebnisse."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit Python in das HTML‑Format konvertiert. Er behandelt die folgenden Themen.

- PowerPoint in HTML mit Python konvertieren
- PPT in HTML mit Python konvertieren
- PPTX in HTML mit Python konvertieren
- ODP in HTML mit Python konvertieren
- PowerPoint‑Folie in HTML mit Python konvertieren

## **Python PowerPoint zu HTML**

Den Python‑Beispielcode zum Konvertieren von PowerPoint zu HTML finden Sie im Abschnitt unten, d.h.[PowerPoint zu HTML konvertieren](#convert-powerpoint-to-html). Der Code kann verschiedene Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und sie im HTML‑Format speichern.

## **Über die PowerPoint‑zu‑HTML‑Konvertierung**
Using [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), applications and developers can convert a PowerPoint presentation to HTML: **PPTX to HTML** or **PPT to HTML**. 

**Aspose.Slides** provides many options (mostly from the [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) class) that define the PowerPoint to HTML conversion process:

* Eine komplette PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit Sprecheranmerkungen ein‑ oder ausblenden.
* Eine PowerPoint‑Präsentation in HTML mit Kommentaren ein‑ oder ausblenden.
* Eine PowerPoint‑Präsentation in HTML mit Original‑ oder eingebetteten Schriftarten konvertieren.
* Eine PowerPoint‑Präsentation in HTML konvertieren und dabei den neuen CSS‑Stil verwenden.

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation zu HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)-Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html), usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie sich auch andere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides diese Konvertierungsoperationen für das HTML‑Format: 

* [HTML zu Bild](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint zu HTML konvertieren**
Using Aspose.Slides, you can convert an entire PowerPoint presentation to HTML this way:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), um das Objekt als HTML‑Datei zu speichern.

This code shows you how to convert a PowerPoint to HTML in python:
```python
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Speichern der Präsentation als HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```


## **PowerPoint zu Responsive HTML konvertieren**

Aspose.Slides provides the [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) class that allows you to generate responsive HTML files. This code shows you how to convert a PowerPoint presentation to responsive HTML in python:
```py
# Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Speichern der Präsentation als HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **PowerPoint zu HTML mit Notizen konvertieren**
This code shows you how to convert a PowerPoint to HTML with notes in python:
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **PowerPoint zu HTML mit Original‑Schriftarten konvertieren**
Aspose.Slides provides the [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) class that allows you to embed all the fonts in a presentation while converting the presentation to HTML.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie dem parametrisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) Klasse ein Array von Schriftartnamen übergeben. Populäre Schriftarten wie Calibri oder Arial müssen nicht eingebettet werden, weil die meisten Systeme sie bereits enthalten. Werden diese Schriftarten eingebettet, wird das resultierende HTML‑Dokument unnötig groß.

Die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) Klasse unterstützt Vererbung und stellt die Methode `WriteFont` bereit, die überschrieben werden soll. 
```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# Standardpräsentationsschriftarten ausschließen
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```


## **Folie zu HTML konvertieren**
Convert a separate presentation slide to HTML. For that use the same [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) method exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class that is used to convert the whole PPT(X) presentation into a HTML document. The [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) class can be also used to set the additional conversion options:
```py
# [TODO[not_supported_yet]: Python-Implementierung der .net-Schnittstelle]
```


## **CSS und Bilder beim Export nach HTML speichern**
Using new CSS style files, you can easily change the style of the HTML file resulting from the PowerPoint to HTML conversion process. 

The python code in this example shows you how to use overridable methods to create a custom HTML document with a link to a CSS file:
```py
# [TODO[not_supported_yet]: Python-Implementierung von .net-Schnittstellen]
```


## **Alle Schriftarten beim Konvertieren der Präsentation zu HTML verlinken**
If you do not want to embed fonts (to avoid increasing the size of the resulting HTML), you can link all fonts by implementing your own `LinkAllFontsHtmlController` version. 

This python code shows you how to convert a PowerPoint to HTML while linking all fonts and excluding "Calibri" and "Arial" (since they already exist in the system): 
```py
# [TODO[not_supported_yet]: Python-Implementierung von .net-Schnittstellen]
```


## **Unterstützung der SVG-Responsive-Eigenschaft**
The code sample below shows how to export a PPT(X) presentation to HTML with the responsive layout:
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **Mediendateien nach HTML exportieren**
Using Aspose.Slides for python, you can export media files this way:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf die Folie.
1. Fügen Sie der Folie ein Video hinzu.
1. Schreiben Sie die Präsentation als HTML‑Datei.

This python code shows you how to add a video to the presentation and then save it as HTML:
```py
import aspose.slides as slides

# Laden einer Präsentation
presentation = slides.Presentation("Media File.pptx")

path = "C:\\"
fileName = "ExportMediaFiles_out.html"
baseUri = "http://www.example.com/"

controller = slides.export.VideoPlayerHtmlController(path, fileName, baseUri)

htmlOptions = slides.export.HtmlOptions(controller)
svgOptions = slides.export.SVGOptions(controller)

htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
htmlOptions.slide_image_format = slides.export.SlideImageFormat.svg(svgOptions)

presentation.save(path + "ExportMediaFiles_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **Häufig gestellte Fragen**

### **Wie kann ich eine PowerPoint‑Präsentation mit Python zu HTML konvertieren?**

Sie können die Bibliothek Aspose.Slides for Python via .NET verwenden, um PPT-, PPTX‑ oder ODP‑Dateien zu laden und sie mit der `save()`‑Methode und `SaveFormat.HTML` zu HTML zu konvertieren.

### **Unterstützt Aspose.Slides das Konvertieren einzelner PowerPoint‑Folien zu HTML?**

Ja, Aspose.Slides ermöglicht das Konvertieren entweder der gesamten Präsentation oder einzelner Folien zu HTML, indem die `HtmlOptions` entsprechend konfiguriert werden.

### **Kann ich responsives HTML aus PowerPoint‑Präsentationen erzeugen?**

Ja, mit der Klasse `ResponsiveHtmlController` können Sie Ihre Präsentation in ein responsives HTML‑Layout exportieren, das sich an verschiedene Bildschirmgrößen anpasst.

### **Kann ich Sprecheranmerkungen oder Kommentare in das exportierte HTML einbinden?**

Ja, Sie können die `HtmlOptions` so konfigurieren, dass Sprecheranmerkungen und Kommentare ein‑ oder ausgeschlossen werden, wenn Sie PowerPoint‑Präsentationen zu HTML exportieren.

### **Kann ich Schriftarten einbetten, wenn ich eine Präsentation zu HTML konvertiere?**

Ja, Aspose.Slides stellt die Klasse `EmbedAllFontsHtmlController` bereit, mit der Sie Schriftarten einbetten oder bestimmte Schriftarten ausschließen können, um die Dateigröße zu reduzieren.

### **Unterstützt die PowerPoint‑zu‑HTML‑Konvertierung Mediendateien wie Videos und Audio?**

Ja, Aspose.Slides ermöglicht das Exportieren von in Folien eingebetteten Medieninhalten zu HTML mithilfe von `VideoPlayerHtmlController` und zugehörigen Konfigurationsklassen.

### **Welche Dateiformate werden für die Konvertierung zu HTML unterstützt?**

Aspose.Slides unterstützt die Konvertierung der Formate PPT, PPTX und ODP zu HTML. Außerdem können Sie Folieninhalte als SVG speichern und Medienassets exportieren.

### **Kann ich das Einbetten von Schriftarten vermeiden, um die HTML‑Ausgabedatei zu verkleinern?**

Ja, Sie können gängige Systemschriftarten wie Arial oder Calibri verlinken, anstatt sie einzubetten, indem Sie eine benutzerdefinierte Implementierung des `HtmlController` verwenden.

### **Gibt es ein Online‑Tool, um PowerPoint zu HTML zu konvertieren?**

Ja, Sie können Asposes kostenlose Web‑Tools wie [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html) oder [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html) nutzen, um Präsentationen direkt im Browser ohne Programmierung zu konvertieren.

### **Kann ich benutzerdefinierte CSS‑Stile im exportierten HTML‑Datei verwenden?**

Ja, Aspose.Slides ermöglicht das Verlinken externer CSS‑Dateien während der Konvertierung, sodass Sie das Erscheinungsbild des erzeugten HTML‑Inhalts vollständig anpassen können.