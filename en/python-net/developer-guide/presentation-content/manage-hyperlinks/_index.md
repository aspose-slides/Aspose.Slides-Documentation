---
title: Manage Hyperlinks in Presentations with Python
linktitle: Manage Hyperlink
type: docs
weight: 20
url: /python-net/manage-hyperlinks/
keywords:
- add URL
- add hyperlink
- create hyperlink
- format hyperlink
- remove hyperlink
- update hyperlink
- text hyperlink
- slide hyperlink
- shape hyperlink
- image hyperlink
- video hyperlink
- mutable hyperlink
- PowerPoint
- OpenDocument
- presentation
- Python
description: "Effortlessly manage hyperlinks in PowerPoint and OpenDocument presentations with Aspose.Slides for Python .NET—enhance interactivity and workflow in minutes."
---

A hyperlink is a reference to an object or data or a place in something. These are common hyperlinks in PowerPoint Presentations:

* Links to websites inside texts, shapes, or media
* Links to slides

Aspose.Slides for Python via .NET allows you to perform many tasks involving hyperlinks in presentations. 

{{% alert color="primary" %}} 

You may want to check out Aspose simple, [free online PowerPoint editor.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Adding URL Hyperlinks**

### **Adding URL Hyperlinks to Texts**

This Python code shows you how to add a website hyperlink to a text:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: File Format APIs")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "More than 70% Fortune 100 companies trust Aspose APIs"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32
    
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Adding URL Hyperlinks to Shapes or Frames**

This sample code in Python shows you how to add a website hyperlink to a shape:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% Fortune 100 companies trust Aspose APIs"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Adding URL Hyperlinks to Media**

Aspose.Slides allows you to add hyperlinks to images, audio, and video files. 

This sample code shows you how to add a hyperlink to an **image**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Adds image to presentation
    with open("img.jpeg", "rb") as fs:
        data = fs.read()
        image = pres.images.add_image(data)
        
        # Creates picture frame on slide 1 based on previously added image
        pictureFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

        pictureFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        pictureFrame.hyperlink_click.tooltip = "More than 70% Fortune 100 companies trust Aspose APIs"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

 This sample code shows you how to add a hyperlink to an **audio file**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("audio.mp3", "rb") as fs:
        data = fs.read()
        audio = pres.audios.add_audio(data)
        
        audioFrame = pres.slides[0].shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

        audioFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        audioFrame.hyperlink_click.tooltip = "More than 70% Fortune 100 companies trust Aspose APIs"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

 This sample code shows you how to add a hyperlink to a **video**:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("video.avi", "rb") as fs:
        data = fs.read()
        video = pres.videos.add_video(data)
        
        videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 100, 100, video)

        videoFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        videoFrame.hyperlink_click.tooltip = "More than 70% Fortune 100 companies trust Aspose APIs"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert  title="Tip"  color="primary"  %}} 

You may want to see *[Manage OLE](https://docs.aspose.com/slides/python-net/manage-ole/)*.

{{% /alert %}}



## **Using Hyperlinks to Create Table of Contents**

Since hyperlinks allow you to add references to objects or places, you can use them to create a table of contents. 

This sample code shows you how to create a table of contents with hyperlinks:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    linkPortion = slides.Portion()
    linkPortion.text = "Page 2"
    linkPortion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(linkPortion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```



## **Formatting Hyperlinks**

### **Color**

With the [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/) property in the [IHyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/) interface, you can set the color for hyperlinks and also get the color information from hyperlinks. The feature was first introduced in PowerPoint 2019, so changes involving the property do not apply to older PowerPoint versions.

This sample code demonstrates an operation where hyperlinks with different colors got added to the same slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of colored hyperlink.")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.fill_type = slides.FillType.SOLID
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of usual hyperlink.")
    shape2.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```



## **Removing Hyperlinks in Presentations**

### **Removing Hyperlinks from Texts**

This Python code shows you how to remove the hyperlink from a text in a presentation slide:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    portion.portion_format.hyperlink_manager.remove_hyperlink_click()
    pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Removing Hyperlinks from Shapes or Frames**

This Python code shows you how to remove the hyperlink from a shape in a presentation slide: 

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as pres:
   slide = pres.slides[0]
   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()
   pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```



## **Mutable Hyperlink**

The [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink) class is mutable. With this class, you can change the values for these properties:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.History](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)

The code snippet shows you how to add a hyperlink to a slide and edit its tooltip later:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: File Format APIs")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "More than 70% Fortune 100 companies trust Aspose APIs"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```




## **Supported Properties in IHyperlinkQueries**

You can access IHyperlinkQueries from a presentation, slide, or text for which the hyperlink is defined. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)

The IHyperlinkQueries class supports these methods and properties: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)

