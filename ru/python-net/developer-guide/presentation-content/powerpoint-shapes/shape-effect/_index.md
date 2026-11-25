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
description: "Преобразуйте ваши файлы PPT, PPTX и ODP с помощью продвинутых эффектов фигур, используя Aspose.Slides для Python — создавайте яркие, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint могут использоваться для выделения формы, но они отличаются от [заливок](/slides/ru/python-net/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint можно создавать убедительные отражения на форме, распространять сияние формы и т.д.

![Эффект формы](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры в разделе **Preset**. Параметры Preset представляют собой проверенные комбинации из двух и более эффектов с хорошим внешним видом. Таким образом, выбирая предустановку, вам не придется терять время на тестирование или комбинирование различных эффектов в поисках удачной комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), позволяющие применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides для Python через .NET поддерживает внешние и внутренние тени для форм. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы соответствовать дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы краев формы, создавая впечатление, что форма поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия в соответствии с освещением и стилем вашего шаблона.

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

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели вдавленное изображение. Внешняя тень выходит за пределы формы и создаёт ощущение подъёма, тогда как внутренняя тень затемняет внутренние части её краев.

Вызовите [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), затем настройте [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Большие значения радиуса размытия дают более мягкие края.

В этом примере на Python создаётся светло‑голубая карточка с темно‑серой внутренней тенью и сохраняется в файле PPTX:

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

Чтобы удалить внутреннюю тень, вызовите [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) у формата эффектов формы.

### **Применить, изменить и удалить предустановленную тень**

Вызовите [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) и задайте свойству тени [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) значение типа [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Чтобы переключить стили, измените предустановку у той же формы. Вызовите [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/), чтобы удалить тень, сохранив заливку и контур.

Этот пример демонстрирует четыре стадии рядом на одном слайде. Перед каждым изменением прямоугольник клонируется, чтобы вы могли сравнить результаты. Оба теневых эффекта смещены на 10 пунктов. Направление 225° размещает первую тень выше и слева от прямоугольника, а 45° — вторую ниже и справа.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| Оригинал | Первая предустановка | Вторая предустановка | После удаления |
| :---: | :---: | :---: | :---: |
| ![Без тени](preset_shadow_original.png) | ![Тень сверху‑слева](preset_shadow_top_left.png) | ![Тень снизу‑справа](preset_shadow_bottom_right.png) | ![Без тени после удаления](preset_shadow_removed.png) |

## **Применить эффект отражения**

Чтобы применить эффект отражения в Aspose.Slides для Python через .NET, вы можете добавить зеркальное отражение к формам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетическое восприятие ваших презентаций, придавая формам более отполированный и утончённый вид. Его легко реализовать с помощью простого кода, позволяющего быстро применять эффект к нескольким элементам для согласованного дизайна.

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

Чтобы применить эффект свечения к форме в Aspose.Slides для Python через .NET, вы можете добавить мягкое, светящееся сияние вокруг формы, настраивая такие свойства, как цвет и размер. Этот эффект помогает выделить формы и добавляет привлекательный, бросающийся в глаза визуальный элемент в вашу презентацию. Его легко реализовать с минимальным объёмом кода, улучшая общий внешний вид ваших слайдов.

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

Чтобы применить эффект мягких краёв в Aspose.Slides для Python через .NET, вы можете создать плавный, размытый переход вокруг краёв формы. Этот эффект придаёт более утончённый и деликатный вид, идеально подходящий для дизайнов, требующих мягкого, нежного отображения. Параметры, такие как радиус, можно легко настроить для получения желаемого результата на разных формах в вашей презентации.

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

Используйте размытие формы, чтобы смягчить заливку и контур формы, оставаясь при этом редактируемой. Вызовите [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) у формата эффектов формы. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, при этом большие значения дают более сильное размытие. Радиус, равный нулю, не меняет внешний вид.

Параметр [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) управляет видимыми границами эффекта. При `False` размытие обрезается до исходных нарисованных границ, включая контур. При `True` размытие может выходить за эти границы. Ни одна из настроек не меняет положение или размеры формы.

Сравнение ниже использует одинаковую заливку, контур и размеры формы на протяжении всего примера. Верхняя строка использует `grow = False`; нижняя строка — `grow = True`.

![Исходный прямоугольник, сравнение с радиусами размытия 5 и 15 пунктов, с отключённым и включённым grow](shape_blur_comparison.png)

В этом примере на Python создаётся оранжевый прямоугольник с темно‑синим контуром, применяется размытие с радиусом 5 пунктов, затем обновляется до радиуса 15 пунктов повторным вызовом [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/). Сохраняются оба состояния с размытием, после чего вызывается [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) и сохраняется форма без размытия.

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

Размытие формы влияет одновременно на заливку и контур. Эффект мягких краёв смягчает только края формы, тогда как размытие тени смягчает только её тень. Эффекты трансформации изображения работают с содержимым изображения; в этом примере размытие применяется напрямую к формату эффектов формы без преобразования её в изображение.

## **Часто задаваемые вопросы**

**Можно ли применять несколько эффектов к одной и той же форме?**

Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечения, на одной форме для создания более динамичного внешнего вида.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формулам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и многое другое.

**Можно ли применять эффекты к сгруппированным формам?**

Да, эффекты можно применять к сгруппированным формам. Эффект будет применён ко всей группе.