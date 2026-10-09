---
title: Apply Shape Effects in Presentations with Python
linktitle: Shape Effect
type: docs
weight: 30
url: /python-net/shape-effect
keywords:
- shape effect
- shadow effect
- reflection effect
- glow effect
- soft edges effect
- effect format
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Transform your PPT, PPTX and ODP files with advanced shape effects using Aspose.Slides for Python—create striking, professional slides in seconds."
---

## **Introduction**

While effects in PowerPoint can be used to make a shape stand out, they differ from [fills](/slides/python-net/shape-formatting/#gradient-fill) or outlines. Using PowerPoint effects, you can create convincing reflections on a shape, spread a shape's glow, etc.

![Shape effect](shape-effect.png)

PowerPoint provides six effects that can be applied to shapes. You can apply one or more effects to a shape.

Some combinations of effects look better than others. For this reason, PowerPoint has options under **Preset**. The Preset options are essentially a known good-looking combination of two or more effects. This way, by selecting a preset, you won't have to waste time testing or combining different effects to find a nice combination.

Aspose.Slides provides properties and methods under the [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) class that allow you to apply the same effects to shapes in PowerPoint presentations.

## **Apply a Shadow Effect**

Aspose.Slides for Python via .NET supports outer and inner shadows for shapes. You can customize their color, direction, distance, and blur radius to match your presentation's design.

### **Apply an Outer Shadow**

Use an outer shadow to make a card or panel stand out against the slide background. The shadow extends beyond the shape's edges, creating the impression that the shape is raised above the slide. Adjust its color, direction, distance, and blur radius to match the lighting and styling of your template.

This Python code shows how to apply the [outer shadow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) to a rectangle:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Shadow effect](shadow_effect.png)

### **Apply an Inner Shadow**

When reproducing a template's visual styling, use an inner shadow to give a card or panel a recessed appearance. An outer shadow extends outside the shape and makes it appear raised, while an inner shadow shades the inside of its edges.

Call [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), then configure [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Larger blur-radius values produce softer edges.

This Python example creates a light blue card with a dark gray inner shadow and saves it as a PPTX file:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

To remove the inner shadow, call [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) on the shape's effect format.

## **Apply a Reflection Effect**

To apply a reflection effect in Aspose.Slides for Python via .NET, you can add a mirror-like reflection to shapes, adjusting parameters such as distance, transparency, and size. This effect enhances the aesthetic of your presentations by giving shapes a more polished and sophisticated look. It’s easy to implement with simple code, enabling quick application across multiple elements for a consistent design.

This Python code shows how to apply the [reflection effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) to a shape:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Reflection effect](reflection_effect.png)

## **Apply a Glow Effect**

To apply a glow effect to a shape in Aspose.Slides for Python via .NET, you can add a soft, luminous aura around shapes, adjusting properties like color and size. This effect helps make shapes stand out and adds an attractive, eye-catching visual element to your presentation. It's easy to implement with minimal code, enhancing the overall look of your slides.

This Python code shows how to apply the [glow effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) to a shape:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Glow effect](glow_effect.png)

## **Apply a Soft Edges Effect**

To apply a soft edges effect in Aspose.Slides for Python via .NET, you can create a smooth, blurred transition around the edges of a shape. This effect adds a more subtle and refined look, perfect for designs that need a gentle, softer appearance. You can easily adjust parameters like radius to achieve the desired effect across various shapes in your presentation.

This Python code shows how to apply the [soft edges](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) to a shape:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Soft edges effect](soft_edges_effect.png)

## **FAQ**

**Can I apply multiple effects to the same shape?**

Yes, you can combine different effects, such as shadow, reflection, and glow, on a single shape to create a more dynamic appearance.

**What shapes can I apply effects to?**

You can apply effects to various shapes, including autoshapes, charts, tables, pictures, SmartArt objects, OLE objects, and more.

**Can I apply effects to grouped shapes?**

Yes, you can apply effects to grouped shapes. The effect will apply to the entire group.
