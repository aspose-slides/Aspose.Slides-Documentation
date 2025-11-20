---
title: Convert PowerPoint Presentations to HTML in Python
linktitle: PowerPoint to HTML
type: docs
weight: 30
url: /python-net/convert-powerpoint-to-html/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to HTML
- presentation to HTML
- slide to HTML
- PPT to HTML
- PPTX to HTML
- save PowerPoint as HTML
- save presentation as HTML
- save slide as HTML
- save PPT as HTML
- save PPTX as HTML
- Python
- Aspose.Slides
description: "Convert PowerPoint presentations to responsive HTML in Python. Preserve layout, links, and images with Aspose.Slides conversion guide for fast, flawless results."
---

## **Overview**

This article explains how to convert PowerPoint Presentation in HTML format using Python. It covers the following topics.

- Convert PowerPoint to HTML in Python
- Convert PPT to HTML in Python
- Convert PPTX to HTML in Python
- Convert ODP to HTML in Python
- Convert PowerPoint Slide to HTML in Python

## **Python PowerPoint to HTML**

For Python sample code to convert PowerPoint to HTML, please see the section below i.e. [Convert PowerPoint to HTML](#convert-powerpoint-to-html). The code can load number of formats like PPT, PPTX and ODP in Presentation object and save it to HTML format.


## **About PowerPoint to HTML Conversion**
Using [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), applications and developers can convert a PowerPoint presentation to HTML: **PPTX to HTML** or **PPT to HTML**. 

**Aspose.Slides** provides many options (mostly from the [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) class) that define the PowerPoint to HTML conversion process:

* Convert an entire PowerPoint presentation to HTML.
* Convert a specific slide in a PowerPoint presentation to HTML.
* Convert presentation media (images, videos, etc.) to HTML.
* Convert a PowerPoint presentation to responsive HTML. 
* Convert a PowerPoint presentation to HTML with speaker notes included or excluded. 
* Convert a PowerPoint presentation to HTML with comments included or excluded. 
* Convert a PowerPoint presentation to HTML with original or embedded fonts. 
* Convert a PowerPoint presentation to HTML while using the new CSS style. 

{{% alert color="primary" %}} 

Using its own API, Aspose developed free [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) converters: [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html), etc. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

You may want to check out other [free converters from Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Besides the conversion processes described here, Aspose.Slides also supports these conversion operations involving the HTML format: 

* [HTML to image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **Convert PowerPoint to HTML**
Using Aspose.Slides, you can convert an entire PowerPoint presentation to HTML this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class
1. Use the [Save ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)method  to save the object as an HTML file.

This code shows you how to convert a PowerPoint to HTML in python:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Saving the presentation to HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Convert PowerPoint to Responsive HTML**

Aspose.Slides provides the [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) class that allows you to generate responsive HTML files. This code shows you how to convert a PowerPoint presentation to responsive HTML in python:

```py
# Instantiate a Presentation object that represents a presentation file
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Saving the presentation to HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Convert PowerPoint to HTML with Notes**
This code shows you how to convert a PowerPoint to HTML with notes in python:

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Convert PowerPoint to HTML with Original Fonts**
Aspose.Slides provides the [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) class that allows you to embed all the fonts in a presentation while converting the presentation to HTML.

To prevent certain fonts from being embedded, you can pass an array of font names to a parameterized constructor from the [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) class. Popular fonts, such as Calibri or Arial, when used in a presentation, do not have to be embedded because most systems already contain such fonts. When those fonts are embedded, the resulting HTML document becomes unnecessarily large.

The [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) class  supports inheritance and provides the `WriteFont` method, which is meant to be overwritten. 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclude default presentation fonts
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Convert Slide to HTML**
Convert a separate presentation slide to HTML. For that use the same [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) method exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class that is used to convert the whole PPT(X) presentation into a HTML document. The [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) class can be also used to set the additional conversion options:

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```


## **Save CSS and Images When Exporting To HTML**
Using new CSS style files, you can easily change the style of the HTML file resulting from the PowerPoint to HTML conversion process. 

The python code in this example shows you how to use overridable methods to create a custom HTML document with a link to a CSS file:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Link All Fonts When Converting Presentation to HTML**
If you do not want to embed fonts (to avoid increasing the size of the resulting HTML), you can link all fonts by implementing your own  `LinkAllFontsHtmlController` version. 

This python code shows you how to convert a PowerPoint to HTML while linking all fonts and excluding "Calibri" and "Arial" (since they already exist in the system): 

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Support of SVG Responsive Property**
The code sample below shows how to export a PPT(X) presentation to HTML with the responsive layout:

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **Export Media Files to HTML file**
Using Aspose.Slides for python, you can export media files this way:

1. Create an instance of of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide.
1. Add a video to the slide.
1. Write the presentation as a HTML file.

This python code shows you how to add a video to the presentation and then save it as HTML:

```py
import aspose.slides as slides

# Loading a presentation
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

## **FAQ**

**How can I convert a PowerPoint presentation to HTML using Python?**

You can use the Aspose.Slides for Python via .NET library to load PPT, PPTX, or ODP files and convert them to HTML using the `save()` method with `SaveFormat.HTML`.

**Does Aspose.Slides support converting individual PowerPoint slides to HTML?**

Yes, Aspose.Slides allows you to convert either the entire presentation or specific slides to HTML by configuring `HtmlOptions` accordingly.

**Can I generate responsive HTML from PowerPoint presentations?**

Yes, with the `ResponsiveHtmlController` class, you can export your presentation to a responsive HTML layout that adapts to different screen sizes.

**Is it possible to include speaker notes or comments in the exported HTML?**

Yes, you can configure the `HtmlOptions` to include or exclude speaker notes and comments when exporting PowerPoint presentations to HTML.

**Can I embed fonts when converting a presentation to HTML?**

Yes, Aspose.Slides provides the `EmbedAllFontsHtmlController` class, which allows you to embed fonts or exclude certain fonts to reduce the output file size.

**Does the PowerPoint to HTML conversion support media files like videos and audio?**

Yes, Aspose.Slides allows exporting media content embedded in slides to HTML using `VideoPlayerHtmlController` and related configuration classes.

**What file formats are supported for conversion to HTML?**

Aspose.Slides supports converting PPT, PPTX, and ODP presentation formats to HTML. It also allows saving slide content as SVG and exporting media assets.

**Can I avoid embedding fonts to reduce HTML output size?**

Yes, you can link commonly available system fonts like Arial or Calibri instead of embedding them, using a custom implementation of the `HtmlController`.

**Is there an online tool to convert PowerPoint to HTML?**

Yes, you can try Aspose’s free web tools such as [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html) or [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html) to convert presentations directly in your browser without writing any code.

**Can I use custom CSS styles in the exported HTML file?**

Yes, Aspose.Slides allows linking to external CSS files during conversion, enabling you to fully customize the appearance of the resulting HTML content.
