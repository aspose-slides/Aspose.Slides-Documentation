---
title: Создание и применение эффектов WordArt в Python
linktitle: WordArt
type: docs
weight: 110
url: /ru/python-net/wordart/
keywords:
- WordArt
- создать WordArt
- шаблон WordArt
- эффект WordArt
- эффект тени
- эффект отражения
- эффект свечения
- трансформация WordArt
- 3D‑эффект
- эффект внешней тени
- эффект внутренней тени
- Python
- Aspose.Slides
description: "Создайте и настройте эффекты WordArt в Aspose.Slides for Python via .NET. Это пошаговое руководство помогает разработчикам улучшать презентации с профессиональным текстом на Python."
---
## **Обзор**

Эффекты WordArt позволяют стилизовать текст с помощью заливок, контуров, теней, отражений, свечения, трансформаций и 3D‑форматирования. В этой статье объясняется, как создавать и настраивать эти эффекты в презентациях PowerPoint с помощью Aspose.Slides for Python via .NET, без установленного Microsoft Office.

## **Создайте простой шаблон WordArt и примените его к тексту**

В следующих примерах создаётся простой стиль WordArt путём задания текста, шрифта, узорчатой заливки и контура.

Каждый пример создаёт новую презентацию и добавляет прямоугольник на первый слайд; входной файл не требуется. В первом примере текст задаётся как «Aspose.Slides». Позиция и размеры фигуры измеряются в пунктах:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Задайте шрифт Arial Black размером 36 пунктов, чтобы форматирование было более заметным:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Примените узор [SMALL_GRID](https://reference.aspose.com/slides/ru/python-net/aspose.slides/patternstyle/) с тёмно‑оранжевым передним планом и белой заливкой, затем добавьте чёрный контур текста толщиной 1 пункт:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Полученный текст:

![Простой шаблон WordArt](WordArt_template.png)

## **Применение других эффектов WordArt**

В следующих примерах демонстрируется, как применять тени, отражения, свечение, трансформации и 3D‑эффекты к тексту.

### **Применение внешних теней**

Внешняя тень добавляет глубину, размещая тень за текстом. Можно настроить её цвет, направление, расстояние, радиус размытия, масштаб и наклон.

В этом примере вызывается [enable_outer_shadow_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) и задаётся чёрная тень с радиусом размытия 4 пункта, направлением 230° и расстоянием 30 пунктов. Значения масштаба 100 сохраняют размер тени, а горизонтальный наклон наклоняет её на 20°. Прозрачность задаётся альфа‑преобразованием – 32 %:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Полученный текст:

![Эффект внешней тени](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Если одновременно использовать внешние и предустановленные тени, применяется только внешняя тень.
- При одновременном использовании внешних и внутренних теней результат зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется только внешняя тень.
{{% /alert %}}

### **Применение отражений**

Отражение создаёт зеркальную копию текста. Настраивая позицию, масштаб, размытие и прозрачность, можно контролировать его внешний вид.

В этом примере вызывается [enable_reflection_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides/effectformat/enable_reflection_effect/) и отражение переворачивается вертикально со масштабом – 100 %. Используется радиус размытия 0,5 пункта и расстояние 4,72 пункта. Прозрачность уменьшается от 60 % до 0,9 % между позициями 0 % и 60 % вдоль отражения:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

Полученный текст:

![Эффект отражения](reflection_effect.png)

### **Применение свечения**

Свечение добавляет мягкий цветной контур вокруг текста. Регулируя его цвет, непрозрачность и радиус, можно управлять эффектом.

В этом примере вызывается [enable_glow_effect](https://reference.aspose.com/slides/ru/python-net/aspose.slides/effectformat/enable_glow_effect/) и применяется красное свечение с непрозрачностью 54 % и радиусом 7 пунктов:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Полученный текст:

![Эффект свечения](glow_effect.png)

### **Применение трансформаций WordArt**

Трансформации WordArt изгибают, растягивают или деформируют блок текста.

Установите [transform](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/transform/) в значение [ARCH_UP_POUR](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textshapetype/), чтобы изогнуть весь текстовый фрейм вверх:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Полученный текст:

![Трансформация WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via .NET предоставляет набор предопределённых [типов трансформаций](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textshapetype/).
{{% /alert %}}

### **Применение 3D‑эффектов к фигурам и тексту**

Можно применять 3D‑эффекты к фигуре или к её тексту. Скругления, экструзия, освещение и параметры камеры управляют конечным видом.

В следующем примере используется [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/) для добавления круглых скруглений, оранжевой экструзии и тёмно‑красного контура к прямоугольнику. Размеры скруглений, высота экструзии, ширина контура и глубина измеряются в пунктах. Пластиковый материал, сбалансированное освещение, повернутое на 40° вокруг оси Z, и перспектива камеры определяют внешний вид:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Полученная фигура:

![3D-эффект фигуры](shape_3D_effect.png)

Этот пример применяет аналогичное 3D‑форматирование к тексту через [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/three_d_format/). Меньшие скругления формируют края букв, а экструзия и освещение придают тексту глубину:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Полученный текст:

![3D-эффект текста](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Применение 3D‑эффектов к тексту или к их фигурам – и взаимодействие между этими эффектами – регулируются определёнными правилами. Рассмотрим сцену, включающую как текст, так и содержащую его фигуру. 3D‑эффект включает 3D‑представление объекта и сцену, в которой он размещён.

- Если сцена задана как для фигуры, так и для текста, приоритет имеет сцена фигуры, а сцена текста игнорируется.
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста.
- Если у фигуры вообще нет 3D‑эффекта, она считается плоской, и 3D‑эффект применяется только к тексту.

Эти поведения связаны со свойствами [ThreeDFormat.light_rig](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/light_rig/) и [ThreeDFormat.camera](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Чтобы сохранить текст плоским и читаемым, одновременно оставив 3D‑форматирование его фигуры, см. раздел [Keep Text Flat on a 3D Shape](/slides/ru/python-net/3d-presentation/) для сравнения настроек и полного примера на Python.

## **FAQ**

**Могу ли я использовать эффекты WordArt с различными шрифтами или скриптами (например, арабским, китайским)?**

Да, Aspose.Slides for Python via .NET поддерживает Unicode и работает со всеми основными шрифтами и скриптами. Эффекты WordArt, такие как тень, заливка и контур, можно применять независимо от языка, хотя доступность шрифтов и рендеринг могут зависеть от системных шрифтов.

**Могу ли я применять эффекты WordArt к элементам макета слайдов?**

Да, эффекты WordArt можно применять к фигурам на макетных слайдах, включая заполнители заголовков, нижние колонтитулы или фоновый текст. Изменения, внесённые в макет, отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Слегка. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут немного увеличить размер файла из‑за дополнительной мета‑информации форматирования, но разница обычно незначительна.

**Могу ли я предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете отрисовывать слайды с WordArt в изображения (например, PNG, JPEG) с помощью [Slide.get_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/), либо отрисовывать отдельные фигуры через [Shape.get_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_image/). Это позволяет предварительно увидеть результат в памяти или на экране до сохранения или экспорта полной презентации.