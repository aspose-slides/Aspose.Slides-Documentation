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
- эффект мягких краев
- формат эффекта
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Преобразуйте ваши файлы PPT, PPTX и ODP с помощью продвинутых эффектов фигур, используя Aspose.Slides for Python — создавайте эффектные, профессиональные слайды за секунды."
---
## **Введение**

Эффекты в PowerPoint могут использоваться, чтобы выделить фигуру, но они отличаются от [заполнений](/slides/ru/python-net/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать убедительные отражения на фигуре, распространять её свечение и т.д.

![Эффект фигуры](shape-effect.png)

PowerPoint предоставляет шесть эффектов, которые можно применять к фигурам. Вы можете применить один или несколько эффектов к фигуре.

Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры в разделе **Preset**. Параметры Preset представляют собой известную хорошо выглядящую комбинацию двух и более эффектов. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или сочетание разных эффектов, чтобы найти хорошую комбинацию.

Aspose.Slides предоставляет свойства и методы под классом [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/), которые позволяют применять те же эффекты к фигурам в презентациях PowerPoint.

## **Применить эффект тени**

Aspose.Slides for Python via .NET поддерживает внешние и внутренние тени для фигур. Вы можете настроить их цвет, направление, расстояние и радиус размытия, чтобы они соответствовали дизайну вашей презентации.

### **Применить внешнюю тень**

Используйте внешнюю тень, чтобы выделить карточку или панель на фоне слайда. Тень выходит за пределы краев фигуры, создавая ощущение, что фигура поднята над слайдом. Настройте её цвет, направление, расстояние и радиус размытия, чтобы они соответствовали освещению и стилю вашего шаблона.

Этот код Python демонстрирует, как применить [внешний эффект тени](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) к прямоугольнику:

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

#### **Управление направлением тени при вращении фигуры**

По умолчанию, [OuterShadow.rotate_shadow_with_shape](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/rotate_shadow_with_shape/) равен `True`, поэтому тень вращается вместе с фигурой. Чтобы фигуры с разными вращениями выглядели освещёнными из одного направления, установите это свойство в `False` и задайте их теням одинаковое [direction](https://reference.aspose.com/slides/python-net/aspose.slides.effects/outershadow/direction/).

В примере создаются две стрелки с серыми тенями, смещёнными на 42 пункта вправо (`direction = 0`). Затем слайд дублируется, и обе стрелки вращаются на 90° по часовой стрелке.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    before = presentation.slides[0]

    left = before.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 55, 130, 110, 60)
    left.fill_format.fill_type = slides.FillType.SOLID
    left.fill_format.solid_fill_color.color = slides.Color.steel_blue
    left.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    left.effect_format.enable_outer_shadow_effect()
    shadow = left.effect_format.outer_shadow_effect
    shadow.shadow_color.color = slides.Color.gray
    shadow.direction = 0
    shadow.distance = 42
    shadow.blur_radius = 0
    shadow.rotate_shadow_with_shape = True

    right = before.shapes.add_clone(left)
    right.x = 395
    right.effect_format.outer_shadow_effect.rotate_shadow_with_shape = False

    after = presentation.slides.add_clone(before)
    for arrow in after.shapes:
        arrow.rotation = 90

    presentation.save("arrow_shadows.pptx", slides.export.SaveFormat.PPTX)
```

На втором слайде левая стрелка отбрасывает тень вниз, тогда как правая стрелка всё ещё отбрасывает тень вправо. Настроенное направление остаётся 0° для обеих теней.

![Отображение PowerPoint до и после вращения на 90°. Обе тени начинаются справа. После вращения тень перемещается под левую стрелку и остаётся справа от правой стрелки.](arrow-shadow-rotation.png)

### **Применить внутреннюю тень**

При воспроизведении визуального стиля шаблона используйте внутреннюю тень, чтобы придать карточке или панели врезной вид. Внешняя тень выходит за пределы фигуры и делает её выглядящей поднятой, а внутренняя тень затемняет внутреннюю сторону её краёв.

Вызовите [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), затем настройте [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Более крупные значения blur-radius дают более мягкие края.

Этот пример Python создаёт светло‑голубую карточку с темно‑серой внутренней тенью и сохраняет её как файл PPTX:

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

Чтобы удалить внутреннюю тень, вызовите [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) у формата эффектов фигуры.

### **Применить, изменить и удалить предустановленную тень**

Вызовите [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) и задайте свойству тени [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) значение типа [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Чтобы переключать стили, измените предустановку у той же фигуры. Вызовите [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) чтобы удалить тень, сохранив заполнение и контур.

Этот пример показывает четыре этапа рядом на одном слайде. Он клонирует прямоугольник перед каждым изменением, чтобы вы могли сравнить результаты. Обе тени смещены на 10 пунктов. Направление 225° размещает первую тень выше и слева от прямоугольника, а 45° — вторую ниже и справа.

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

Чтобы применить эффект отражения в Aspose.Slides for Python via .NET, вы можете добавить зеркальное отражение к фигурам, регулируя такие параметры, как расстояние, прозрачность и размер. Этот эффект улучшает эстетическое восприятие ваших презентаций, придавая фигурам более изысканный и полированный вид. Его легко реализовать с помощью простого кода, что позволяет быстро применять его к множеству элементов для согласованного дизайна.

Этот код Python демонстрирует, как применить [эффект отражения](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) к фигуре:

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

Чтобы применить эффект свечения к фигуре в Aspose.Slides for Python via .NET, вы можете добавить мягкое светящееся поле вокруг фигур, регулируя такие свойства, как цвет и размер. Этот эффект помогает выделить фигуры и добавляет привлекательный, броский визуальный элемент в вашу презентацию. Реализовать его легко, требуется минимум кода, улучшая общий внешний вид слайдов.

Этот код Python демонстрирует, как применить [эффект свечения](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) к фигуре:

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

## **Применить эффект мягких краев**

Чтобы применить эффект мягких краев в Aspose.Slides for Python via .NET, вы можете создать плавный, размытый переход по краям фигуры. Этот эффект придаёт более тонкий и утончённый вид, идеален для дизайнов, требующих нежного, более мягкого появления. Вы легко можете регулировать такие параметры, как радиус, чтобы достичь желаемого эффекта на разных фигурах в презентации.

Этот код Python демонстрирует, как применить [мягкие края](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) к фигуре:

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

## **Применить эффект размытия**

Используйте размытие фигуры, чтобы смягчить заполнение и контур фигуры, оставляя её редактируемой. Вызовите [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) у формата эффектов фигуры. Радиус измеряется в пунктах (1/72 дюйма): используйте неотрицательное значение, более крупные значения дают более сильное размытие. Радиус 0 оставляет внешний вид без изменений.

Настройка [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) управляет видимыми границами эффекта. При `False` размытие ограничивается исходными нарисованными границами, включая контур. При `True` размытие может выходить за эти границы. Ни одна из настроек не изменяет положение или размеры фигуры.

Сравнение ниже использует одинаковое заполнение, контур и размеры фигуры на протяжении всего примера. Верхняя строка использует `grow = False`; нижняя строка — `grow = True`.

![Исходный прямоугольник сравнивается с радиусами размытия 5 и 15 пунктов, с отключённым и включённым grow](shape_blur_comparison.png)

Этот пример Python создаёт оранжевый прямоугольник с тёмно‑синим контуром, применяет размытие радиусом 5 пунктов, а затем обновляет его до размытия радиусом 15 пунктов, вызвав [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) снова. Он сохраняет оба размазанных состояния, затем вызывает [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) и сохраняет фигуру без размытия.

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

Размытие фигуры влияет одновременно на заполнение и контур. Эффект мягких краев размывает края фигуры, тогда как размытие тени смягчает только тень. Эффекты преобразования изображения работают с содержимым изображения; в этом примере размытие применяется непосредственно к формату эффектов фигуры без преобразования её в изображение.

## **Часто задаваемые вопросы**

**Можно ли применить несколько эффектов к одной фигуре?**

Да, вы можете комбинировать разные эффекты, такие как тень, отражение и свечение, на одной фигуре, чтобы создать более динамичный внешний вид.

**К каким фигурам можно применять эффекты?**

Эффекты можно применять к различным фигурам, включая автоконтуры, диаграммы, таблицы, изображения, объекты SmartArt, объекты OLE и другие.

**Можно ли применять эффекты к группированным фигурам?**

Да, вы можете применять эффекты к группированным фигурам. Эффект будет применён ко всей группе.