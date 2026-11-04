---
title: Применение эффектов фигур в презентациях с Python
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/python-net/shape-effect
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краёв
- формат эффекта
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT, PPTX и ODP с помощью продвинутых эффектов фигур в Aspose.Slides для Python — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

While effects in PowerPoint can be used to make a shape stand out, they differ from [заливки](/slides/ru/python-net/shape-formatting/#gradient-fill) or outlines. Using PowerPoint effects, you can create convincing reflections on a shape, spread a shape's glow, etc.

![Эффект формы](shape-effect.png)

PowerPoint provides six effects that can be applied to shapes. You can apply one or more effects to a shape.

Some combinations of effects look better than others. For this reason, PowerPoint has options under **Preset**. The Preset options are essentially a known good‑looking combination of two or more effects. This way, by selecting a preset, you won't have to waste time testing or combining different effects to find a nice combination.

Aspose.Slides provides properties and methods under the [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) class that allow you to apply the same effects to shapes in PowerPoint presentations.

## **Применить эффект тени**

Aspose.Slides for Python via .NET supports outer and inner shadows for shapes. You can customize their color, direction, distance, and blur radius to match your presentation's design.

### **Применить внешнюю тень**

Use an outer shadow to make a card or panel stand out against the slide background. The shadow extends beyond the shape's edges, creating the impression that the shape is raised above the slide. Adjust its color, direction, distance, and blur radius to match the lighting and styling of your template.

This Python code shows how to apply the [эффект внешней тени](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) to a rectangle:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Эффект тени](shadow_effect.png)

### **Применить внутреннюю тень**

When reproducing a template's visual styling, use an inner shadow to give a card or panel a recessed appearance. An outer shadow extends outside the shape and makes it appear raised, while an inner shadow shades the inside of its edges.

Call [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), then configure [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Larger blur-radius values produce softer edges.

This Python example creates a light blue card with a dark gray inner shadow and saves it as a PPTX file:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Светло‑голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

To remove the inner shadow, call [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) on the shape's effect format.

## **Применить эффект отражения**

To apply a reflection effect in Aspose.Slides for Python via .NET, you can add a mirror‑like reflection to shapes, adjusting parameters such as distance, transparency, and size. This effect enhances the aesthetic of your presentations by giving shapes a more polished and sophisticated look. It’s easy to implement with simple code, enabling quick application across multiple elements for a consistent design.

This Python code shows how to apply the [эффект отражения](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) to a shape:

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

![Эффект отражения](reflection_effect.png)

## **Применить эффект свечения**

To apply a glow effect to a shape in Aspose.Slides for Python via .NET, you can add a soft, luminous aura around shapes, adjusting properties like color and size. This effect helps make shapes stand out and adds an attractive, eye‑catching visual element to your presentation. It's easy to implement with minimal code, enhancing the overall look of your slides.

This Python code shows how to apply the [эффект свечения](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) to a shape:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Эффект свечения](glow_effect.png)

## **Применить эффект мягких краёв**

To apply a soft edges effect in Aspose.Slides for Python via .NET, you can create a smooth, blurred transition around the edges of a shape. This effect adds a more subtle and refined look, perfect for designs that need a gentle, softer appearance. You can easily adjust parameters like radius to achieve the desired effect across various shapes in your presentation.

This Python code shows how to apply the [мягкие края](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) to a shape:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Эффект мягких краёв](soft_edges_effect.png)

## **Применить эффект размытия**

Use shape blur to soften a shape's fill and outline while keeping the shape editable. Call [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) on the shape's effect format. The radius is measured in points (1/72 inch): use a nonnegative value, with larger values producing stronger blur. A radius of zero leaves the appearance unchanged.

The [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) setting controls the visible bounds of the effect. With `False`, the blur is clipped to the original painted bounds, including the outline. With `True`, the blur can extend beyond those bounds. Neither setting changes the shape's position or dimensions.

The comparison below uses the same fill, outline, and shape dimensions throughout. The top row uses `grow = False`; the bottom row uses `grow = True`.

![Исходный прямоугольник сравнивается с размитием радиуса 5 и 15 пунктов, при отключённом и включённом grow](shape_blur_comparison.png)

This Python example creates an orange rectangle with a dark blue outline, applies a 5‑point blur, and then updates it to a 15‑point blur by calling [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) again. It saves both blurred states, then calls [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) and saves the shape without blur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Shape blur affects the fill and outline together. A soft edges effect fades the shape's edges, while shadow blur softens only the shadow. Image transformation effects operate on image content; this example applies blur directly to the shape's effect format without converting the shape to an image.

## **Часто задаваемые вопросы**

**Могу ли я применить несколько эффектов к одной фигуре?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной фигуре, чтобы создать более динамичный вид.

**Каким фигурам можно применять эффекты?**

Вы можете применять эффекты к различным фигурам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и др.

**Можно ли применять эффекты к сгруппированным фигурам?**

Да, эффекты можно применять к сгруппированным фигурам. Эффект будет применён ко всей группе.