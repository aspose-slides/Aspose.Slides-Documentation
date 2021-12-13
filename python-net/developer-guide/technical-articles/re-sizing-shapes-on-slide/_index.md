---
title: Re-sizing Shapes on Slide
type: docs
weight: 130
url: /python-net/re-sizing-shapes-on-slide/
---

## **Resizing Shapes on Slide**
One of the most frequent questions asked by the Aspose.Slides for Python via .NET customers is how to resize shapes so that when Slide size is changed the data does not cut off. This short technical tip shows how to achieve that. 

To avoid shapes disorientation, each shape on the slide needs to be updated according to new slide size.

```py
import aspose.slides as slides

#Load a presentation
with slides.Presentation("pres.pptx") as presentation:
    #Old slide size
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #Changing slide size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #New slide size
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #Resize position
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Resize shape size if required 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

    presentation.save("Resize-1.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

If there is any table in the slide then above code would not work perfect. In that case, every cell of the table needs to be resized.

{{% /alert %}} 

You need to use following code on your end if you need to re-size the slides with tables. Setting table width or height is a special case in shapes where you need to alter the individual row height and column width to alter the table height and width.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    #Old slide size
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #Changing slide size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #New slide size
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width


    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for master in presentation.masters:
        for shape in master.shapes:
            #Resize position
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Resize shape size if required 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

        for layoutslide in master.layout_slides:
            for shape in layoutslide.shapes:
                #Resize position
                shape.height = shape.height * ratioHeight
                shape.width = shape.width * ratioWidth

                #Resize shape size if required 
                shape.y = shape.y * ratioHeight
                shape.x = shape.x * ratioWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #Resize position
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Resize shape size if required 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth
            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * ratioHeight
                for col in shape.columns:
                    col.width = col.width * ratioWidth

    presentation.save("Resize-2.pptx", slides.export.SaveFormat.PPTX)
```



