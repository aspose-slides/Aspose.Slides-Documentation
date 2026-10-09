---
title: Применение эффектов фигур в презентациях с помощью Python
linktitle: Эффект формы
type: docs
weight: 30
url: /ru/python-net/shape-effect
keywords:
- эффект формы
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффекта
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT, PPTX и ODP с помощью продвинутых эффектов фигур, используя Aspose.Slides для Python — создавайте впечатляющие, профессиональные слайды за секунды."
---
## **Введение**

В то время как эффекты в PowerPoint можно использовать, чтобы выделить форму, они отличаются от [заполнений](/slides/ru/python-net/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать правдоподобные отражения на форме, распространять свечения формы и т.п.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к фигурам. Вы можете применить один или несколько эффектов к фигуре.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине PowerPoint имеет параметры в разделе **Preset**. Параметры Preset по сути представляют собой проверенную красивую комбинацию двух и более эффектов. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование различных эффектов в поиске удачной комбинации.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), которые позволяют применять те же эффекты к фигурам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Python via .NET поддерживает внешние и внутренние тени для фигур. Вы можете настраивать их цвет, направление, расстояние и радиус размытия, чтобы соответствовать дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы границ фигуры, создавая впечатление, что фигура поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы соответствовать освещению и стилю вашего шаблона.

Этот код на Python показывает, как применить [внешний эффект тени](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) к прямоугольнику:

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

![Эффект тени](shadow_effect.png)

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное ощущение. Внешняя тень выходит за пределы фигуры и делает её выглядящей приподнятой, тогда как внутренняя тень затемняет внутреннюю часть её границ.

Вызовите [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), затем настройте [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Более большие значения радиуса размытия дают более мягкие края.

Этот пример на Python создаёт светло‑голубую карточку с темно‑серой внутренней тенью и сохраняет её как файл PPTX:

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

![Светло‑голубой прямоугольник с внутренней тенью](inner_shadow_effect.png)

Чтобы удалить внутреннюю тень, вызовите [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) у формата эффекта фигуры.

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides for Python via .NET, вы можете добавить зеркальное отражение к фигурам, регулируя параметры такие как расстояние, прозрачность и размер. Этот эффект улучшает эстетический вид ваших презентаций, придавая фигурам более изысканный и отполированный вид. Его легко реализовать с помощью простого кода, позволяя быстро применять его к нескольким элементам для единообразного дизайна.

Этот код на Python показывает, как применить [эффект отражения](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) к фигуре:

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

Чтобы применить эффект свечения к фигуре в Aspose.Slides for Python via .NET, вы можете добавить мягкое светящееся сияние вокруг фигур, регулируя такие свойства как цвет и размер. Этот эффект помогает выделить фигуры и добавляет привлекательный, привлекающий внимание визуальный элемент в вашу презентацию. Его легко реализовать с минимальным кодом, улучшая общий вид ваших слайдов.

Этот код на Python показывает, как применить [эффект свечения](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) к фигуре:

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

![Эффект свечения](glow_effect.png)

## **Применить эффект мягких краев**

Чтобы применить эффект мягких краев в Aspose.Slides for Python via .NET, вы можете создать плавный, размазанный переход вокруг краев фигуры. Этот эффект придаёт более тонкий и изысканный вид, идеально подходящий для дизайнов, которым требуется нежный, более мягкий вид. Вы можете легко регулировать такие параметры, как радиус, чтобы добиться желаемого эффекта для различных фигур в вашей презентации.

Этот код на Python показывает, как применить [мягкие края](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) к фигуре:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Эффект мягких краев](soft_edges_effect.png)

## **FAQ**

**Можно ли применить несколько эффектов к одной и той же фигуре?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной фигуре, чтобы создать более динамичный вид.

**Каким фигурам можно применять эффекты?**

Эффекты можно применять к различным фигурам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным фигурам?**

Да, вы можете применять эффекты к сгруппированным фигурам. Эффект будет применён ко всей группе.