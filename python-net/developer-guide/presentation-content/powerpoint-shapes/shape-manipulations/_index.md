---
title: Shape Manipulations
type: docs
weight: 30
url: /python-net/shape-manipulations/
keywords: "PowerPoint shape, shape on slide, find shape, clone shape, remove shape, hide shape, change shape order, get interlop shape ID, shape alternative text, shape layout formats, shape as SVG, align shape, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Manipulate PowerPoint shapes in Python"
---

## **Find Shape in Slide**
This topic will describe a simple technique to make it easier for developers to find a specific shape on a slide without using its internal Id. It is important to know that PowerPoint Presentation files do not have any way to identify shapes on a slide except an internal unique Id. It seems to be difficult for developers to find a shape using its internal unique Id. All shapes added to the slides have some Alt Text. We suggest developers to use alternative text for finding a specific shape. You can use MS PowerPoint to define the alternative text for objects which you are planning to change in the future.

After setting the alternative text of any desired shape, you can then open that presentation using Aspose.Slides for Python via .NET and iterate through all shapes added to a slide. During each iteration, you can check the alternative text of the shape and the shape with the matching alternative text would be the shape required by you. To demonstrate this technique in a better way, we have created a method, [FindShape](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) that does the trick to find a specific shape in a slide and then simply returns that shape.

```py
import aspose.slides as slides

# Method implementation to find a shape in a slide using its alternative text
def find_shape(slide, alttext):
    for i in range(len(slide.shapes)):
        if slide.shapes[i].alternative_text == alttext:
            return slide.shapes[i]
    return None
    
# Instantiate a Presentation class that represents the presentation file
with slides.Presentation(path + "FindingShapeInSlide.pptx") as p:
    slide = p.slides[0]
    # Alternative text of the shape to be found
    shape = find_shape(slide, "Shape1")
    if shape != None:
        print("Shape Name: " + shape.name)
```



## **Clone Shape**
To clone a shape to a slide using Aspose.Slides for Python via .NET:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtain the reference of a slide by using its index.
1. Access the source slide shape collection.
1. Add new slide to the presentation.
1. Clone shapes from the source slide shape collection to the new slide.
1. Save the modified presentation as a PPTX file.

The example below adds a group shape to a slide.

```py
import aspose.slides as slides

# Instantiate Presentation class
with slides.Presentation(path + "Source Frame.pptx") as srcPres:
	sourceShapes = srcPres.slides[0].shapes
	blankLayout = srcPres.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
	destSlide = srcPres.slides.add_empty_slide(blankLayout)
	destShapes = destSlide.shapes
	destShapes.add_clone(sourceShapes[1], 50, 150 + sourceShapes[0].height)
	destShapes.add_clone(sourceShapes[2])                 
	destShapes.insert_clone(0, sourceShapes[0], 50, 150)

	# Write the PPTX file to disk
	srcPres.save("CloneShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Remove Shape**
Aspose.Slides for Python via .NET allows developers to remove any shape. To remove the shape from any slide, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Remove the shape.
1. Save file to disk.

```py
import aspose.slides as slides

# Create Presentation object
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "User Defined"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[0]
        if ashp.alternative_text == alttext:
            sld.shapes.remove(ashp)

    # Save presentation to disk
    pres.save("RemoveShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Hide Shape**
Aspose.Slides for Python via .NET allows developers to hide any shape. To hide the shape from any slide, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Access the first slide.
1. Find the shape with specific AlternativeText.
1. Hide the shape.
1. Save file to disk.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "User Defined"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[i]
        if ashp.alternative_text == alttext:
            ashp.hidden = True

    # Save presentation to disk
    pres.save("Hiding_Shapes_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Change Shapes Order**
Aspose.Slides for Python via .NET allows developers to reorder the shapes. Reordering the shape specifies which shape is on the front or which shape is at the back. To reorder the shape from any slide, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Access the first slide.
1. Add a shape.
1. Add some text in shape's text frame.
1. Add another shape with the same co-ordinates.
1. Reorder the shapes.
1. Save file to disk.

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation1:
    slide = presentation1.slides[0]
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 365, 400, 150)
    shp3.fill_format.fill_type = slides.FillType.NO_FILL
    shp3.add_text_frame(" ")

    txtFrame = shp3.text_frame
    para = txtFrame.paragraphs[0]
    portion = para.portions[0]
    portion.text="Watermark Text Watermark Text Watermark Text"
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 200, 365, 400, 150)
    slide.shapes.reorder(2, shp3)
    presentation1.save( "Reshape_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Get Interop Shape ID**
Aspose.Slides for Python via .NET allows developers to get a unique shape identifier in slide scope in contrast to the UniqueId property, which allows obtaining a unique identifier in presentation scope. Property OfficeInteropShapeId was added to IShape interfaces and Shape class respectively. The value returned by OfficeInteropShapeId property corresponds to the value of the Id of the Microsoft.Office.Interop.PowerPoint.Shape object. Below is a sample code is given.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation.pptx") as presentation:
    # Getting unique shape identifier in slide scope
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```



## **Set Alternative Text for Shape**
Aspose.Slides for Python via .NET allows developers to set AlternateText of any shape. 
Shapes in a presentation could be distinguished by the AlternativeText or Shape Name property. 
AlternativeText property could be read or set by using Aspose.Slides as well as Microsoft PowerPoint. 
By using this property, you can tag a shape and can perform different operations as Removing a shape, 
Hiding a shape or Reordering shapes on a slide.
To set the AlternateText of a shape, please follow the steps below:

1. Create an instance of `Presentation` class.
1. Access the first slide.
1. Add any shape to the slide.
1. Do some work with the newly added shape.
1. Traverse through shapes to find a shape.
1. Set the AlternativeText.
1. Save file to disk.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Presentation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.gray

    for i in range(len(sld.shapes)):
        shape = sld.shapes[i]
        if shape != None:
            shape.alternative_text = "User Defined"

    # Save presentation to disk
    pres.save("Set_AlternativeText_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Access Layout Formats for Shape**
 Aspose.Slides for Python via .NET provides a simple API to access layout formats for a shape. This article demonstrates how you can access layout formats.

Below sample code is given.

```py
import aspose.slides as slides

with slides.Presentation("Set_AlternativeText_out.pptx") as pres:
    for layoutSlide in pres.layout_slides:
        fillFormats = list(map(lambda shape: shape.fill_format, layoutSlide.shapes))
        lineFormats = list(map(lambda shape: shape.line_format, layoutSlide.shapes))
```

## **Render Shape as SVG**
Now Aspose.Slides for Python via .NET support for rendering a shape as svg. WriteAsSvg method (and its overload) has been added to Shape class and IShape interface. This method allows to save content of the shape as an SVG file. Code snippet below shows how to export slide's shape to an SVG file.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with open("SingleShape.svg", "wb") as stream:
        pres.slides[0].shapes[0].write_as_svg(stream)
```

## Align Shape

Through the [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) overloaded method, you can 

* align shapes relative to a slide's margins. See Example 1. 
* align shapes relative to each other. See Example 2. 

The [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) enumeration defines the available alignment options.

### Example 1

This Python code shows you how to align shapes with indices 1,2 and 4 along the border at the top of a slide:
Source code below aligns shapes with indices 1,2 and 4 along the top border of the slide. 

```py
import aspose.slides as slides

with slides.Presentation("OutputPresentation.pptx") as pres:
     slide = pres.slides[0]
     shape1 = slide.shapes[1]
     shape2 = slide.shapes[2]
     shape3 = slide.shapes[4]
     slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, pres.slides[0], [
            slide.shapes.index_of(shape1),
            slide.shapes.index_of(shape2),
            slide.shapes.index_of(shape3)])
```

### Example 2

This Python code shows you how to align an entire collection of shapes relative to the bottom shape in the collection:

```py
import aspose.slides as slides

with slides.Presentation("example.pptx") as pres:
    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_BOTTOM, False, pres.slides[0].shapes)
```