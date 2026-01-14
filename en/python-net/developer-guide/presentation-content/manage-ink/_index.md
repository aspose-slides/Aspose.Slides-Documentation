---
title: Manage Ink Objects in Presentations with Python
linktitle: Manage Ink
type: docs
weight: 95
url: /python-net/manage-ink/
keywords:
- ink
- ink object
- ink trace
- manage ink
- draw ink
- drawing
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Manage PowerPoint ink objects—create, edit & style digital ink with Aspose.Slides for Python via .NET. Get code samples for traces, brush color & size."
---

PowerPoint provides the ink function to allow you to draw non-standard figures, which can be used to highlight other objects, show connections and processes, and draw attention to specific items on a slide. 

Aspose.Slides provides the [aspose.slides.ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/) namespace, which contains the types you need to create and manage ink objects. 

## **Differences between Regular Object and Ink Objects**

Objects on a PowerPoint slide are typically represented by shape objects. A shape object, in its simplest form, is a container that defines the area of the object itself (its frame) alongside its properties. The latter includes the container area size, the shape of the container, the container's background, etc. For information, see [Shape Layout Format](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape).

However, when PowerPoint is dealing with an ink object, it ignores all properties of the object frame (container) except its size. The size of the container area is determined by the standard `width` and `height` values:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Traces**

Trace is a basic element or standard used to record the trajectory of a pen as a user writes digital ink. Traces are recordings that describe sequences of connected points. 

The simplest form of encoding specifies the X and Y coordinates of each sample point. When all the connected points are rendered, they produce an image like this:

![ink_powerpoint2](ink_powerpoint2.png)

## Brush Properties For Drawing 

You can use a brush to draw lines connecting trace elements' points. The brush has its own color and size, corresponding to the `Brush.color` and `Brush.size` properties. 

### **Set Ink Brush Color**

This Python code shows you how to set the color for a brush:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Set Ink Brush Size** 

This Python code shows you how to set the size for a brush:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Generally, a brush's width and height don't match, so PowerPoint does not display the brush size (the data section is grayed out). But when the brush width and height match, PowerPoint displays its size this way:

![ink_powerpoint3](ink_powerpoint3.png)

For clarity, let's increase the height of the ink object and review the important dimensions: 

![ink_powerpoint4](ink_powerpoint4.png)

The container (frame) does not consider the size of the brushes--it always assumes that the thickness of the line is zero (see the last image). 

Therefore, to determine the visible area of the entire ink object, we must consider the trace objects' brush size. Here, the target object (the handwritten text trace object) has been scaled to the container (frame) size. When the size of the container (frame) changes, the brush size remains constant and vice versa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint exhibits the same behavior when dealing with texts:

![ink_powerpoint6](ink_powerpoint6.png)

**Further reading**

* To read about shapes in general, see the [PowerPoint Shapes](https://docs.aspose.com/slides/python-net/powerpoint-shapes/) section. 
* For more information on effective values, see [Shape Effective Properties](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value). 

