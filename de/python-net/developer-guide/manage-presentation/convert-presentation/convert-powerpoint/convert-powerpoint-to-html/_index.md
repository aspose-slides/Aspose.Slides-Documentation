---
title: PowerPoint in HTML in Python konvertieren
linktitle: PowerPoint in HTML konvertieren
type: docs
weight: 30
url: /de/python-net/convert-powerpoint-to-html/
keywords: "Python PowerPoint in HTML, PowerPoint-Präsentation konvertieren, PPTX, PPT, PPT in HTML, PPTX in HTML, PowerPoint in HTML, PowerPoint als HTML speichern, PPT als HTML speichern, PPTX als HTML speichern, Python, Aspose.Slides, HTML-Export"
description: "PowerPoint HTML konvertieren: Speichern Sie PPTX oder PPT als HTML. Speichern Sie Folien als HTML"
---

## **Überblick**

Dieser Artikel erklärt, wie Sie eine PowerPoint-Präsentation im HTML-Format mithilfe von Python konvertieren. Es werden die folgenden Themen behandelt.

- PowerPoint in HTML in Python konvertieren
- PPT in HTML in Python konvertieren
- PPTX in HTML in Python konvertieren
- ODP in HTML in Python konvertieren
- PowerPoint-Folie in HTML in Python konvertieren

## **Python PowerPoint in HTML**

Für Beispielcode in Python zur Konvertierung von PowerPoint in HTML siehe den Abschnitt unten d.h. [PowerPoint in HTML konvertieren](#convert-powerpoint-to-html). Der Code kann eine Vielzahl von Formaten wie PPT, PPTX und ODP im Präsentationsobjekt laden und im HTML-Format speichern.

## **Über die PowerPoint zu HTML-Konvertierung**
Mit [**Aspose.Slides für Python über .NET**](https://products.aspose.com/slides/python-net/) können Anwendungen und Entwickler eine PowerPoint-Präsentation in HTML konvertieren: **PPTX in HTML** oder **PPT in HTML**.

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) Klasse), die den Konvertierungsprozess von PowerPoint zu HTML definieren:

* Eine gesamte PowerPoint-Präsentation in HTML konvertieren.
* Eine bestimmte Folie in einer PowerPoint-Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint-Präsentation in responsives HTML konvertieren.
* Eine PowerPoint-Präsentation in HTML mit einbezogenen oder ausgeschlossenen Referatnotizen konvertieren.
* Eine PowerPoint-Präsentation in HTML mit einbezogenen oder ausgeschlossenen Kommentaren konvertieren.
* Eine PowerPoint-Präsentation in HTML mit ursprünglichen oder eingebetteten Schriftarten konvertieren.
* Eine PowerPoint-Präsentation in HTML unter Verwendung des neuen CSS-Stils konvertieren.

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentationen zu HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Sie möchten möglicherweise auch andere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) überprüfen.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch diese Konvertierungsoperationen im Zusammenhang mit dem HTML-Format:

* [HTML zu Bild](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint in HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint-Präsentation auf folgende Weise in HTML konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse
1. Verwenden Sie die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode, um das Objekt als HTML-Datei zu speichern.

Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in HTML in Python konvertieren:

```python
import aspose.slides as slides

# Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Speichern der Präsentation als HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **PowerPoint in responsives HTML konvertieren**

Aspose.Slides bietet die [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) Klasse, die es Ihnen ermöglicht, responsive HTML-Dateien zu generieren. Dieser Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in responsives HTML in Python konvertieren:

```py
# Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Speichern der Präsentation als HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **PowerPoint in HTML mit Notizen konvertieren**
Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in HTML mit Notizen in Python konvertieren:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **PowerPoint in HTML mit ursprünglichen Schriftarten konvertieren**
Aspose.Slides bietet die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) Klasse, die es Ihnen ermöglicht, alle Schriftarten in einer Präsentation einzubetten, während Sie die Präsentation in HTML konvertieren.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie ein Array von Schriftartnamen an einen parameterisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) Klasse übergeben. Beliebte Schriftarten, wie Calibri oder Arial, müssen nicht eingebettet werden, da die meisten Systeme bereits solche Schriftarten enthalten. Wenn diese Schriftarten eingebettet werden, wird das resultierende HTML-Dokument unnötig groß.

Die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) Klasse unterstützt die Vererbung und bietet die Methode `WriteFont`, die überschrieben werden soll.

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# Standard-Präsentationsschriften ausschließen
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Folie in HTML konvertieren**
Konvertieren Sie eine separate Präsentationsfolie in HTML. Dazu verwenden Sie dieselbe [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode, die von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse bereitgestellt wird, die verwendet wird, um die gesamte PPT(X) Präsentation in ein HTML-Dokument zu konvertieren. Die [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) Klasse kann ebenfalls verwendet werden, um zusätzliche Konvertierungsoptionen festzulegen:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **CSS und Bilder beim Exportieren nach HTML speichern**
Mit neuen CSS-Stildateien können Sie den Stil der HTML-Datei, die aus dem Konvertierungsprozess von PowerPoint in HTML resultiert, einfach ändern.

Der Python-Code in diesem Beispiel zeigt Ihnen, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML-Dokument mit einem Link zu einer CSS-Datei zu erstellen:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Alle Schriftarten verlinken, wenn Sie eine Präsentation in HTML konvertieren**
Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML zu vermeiden), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version des `LinkAllFontsHtmlController` implementieren.

Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint in HTML konvertieren, während Sie alle Schriftarten verlinken und "Calibri" und "Arial" ausschließen (da sie bereits im System vorhanden sind):

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Unterstützung der SVG-responsiven Eigenschaft**
Das folgende Codebeispiel zeigt, wie Sie eine PPT(X)-Präsentation in HTML mit dem responsiven Layout exportieren:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Medien-Dateien in eine HTML-Datei exportieren**
Mit Aspose.Slides für Python können Sie Medien-Dateien auf folgende Weise exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf die Folie.
1. Fügen Sie ein Video zur Folie hinzu.
1. Schreiben Sie die Präsentation als HTML-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Video zur Präsentation hinzufügen und es dann als HTML speichern:

```py
import aspose.slides as slides

# Eine Präsentation laden
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