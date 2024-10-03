---
title: WordArt
type: docs
weight: 110
url: /ru/python-net/wordart/
keywords: "WordArt, Word Art, Создать WordArt, шаблон WordArt, эффекты WordArt, тени, эффекты отображения, эффекты свечения, трансформации WordArt, 3D эффекты, внешние тени, внутренние тени, Python, Aspose.Slides для Python через .NET"
description: "Добавляйте, изменяйте и управляйте WordArt и эффектами в презентациях PowerPoint на Python или Aspose.Slides для Python через .NET"
---

## **Что такое WordArt?**
WordArt или Word Art — это функция, которая позволяет применять эффекты к текстам, чтобы они выделялись. Например, с помощью WordArt вы можете обвести текст или залить его цветом (или градиентом), добавить к нему 3D эффекты и т. д. Вы также можете искажать, сгибать и растягивать форму текста.

{{% alert color="primary" %}} 

WordArt позволяет обращаться с текстом так же, как с графическим объектом. WordArt состоит из эффектов или специальных модификаций, внесенных в тексты, чтобы сделать их более привлекательными или заметными.

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, вам нужно выбрать один из предустановленных шаблонов WordArt. Шаблон WordArt — это набор эффектов, которые применяются к тексту или его форме.

**WordArt в Aspose.Slides**

В Aspose.Slides для Python через .NET 20.10 мы реализовали поддержку WordArt и внесли улучшения в эту функцию в последующих версиях Aspose.Slides для Python через .NET.

С помощью Aspose.Slides для Python через .NET вы можете легко создать свой собственный шаблон WordArt (один эффект или комбинацию эффектов) на Python и применить его к текстам.

## Создание простого шаблона WordArt и его применение к тексту

**Использование Aspose.Slides** 

Сначала создадим простой текст с помощью этого кода на Python:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Теперь мы установим высоту шрифта текста на большее значение, чтобы эффект был более заметен, с помощью этого кода:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Из меню справа вы можете выбрать предустановленный эффект WordArt. Из меню слева вы можете задать настройки для нового WordArt. 

Вот некоторые доступные параметры или опции:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем цвет шаблона SmallGrid к тексту и добавляем черную текстовую рамку шириной 1 с помощью этого кода:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Получившийся текст:

![todo:image_alt_text](image-20200930114108-4.png)

## Применение других эффектов WordArt

**Использование Microsoft PowerPoint**

Из интерфейса программы вы можете применить эти эффекты к тексту, текстовому блоку, форме или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты Тени, Отражения и Свечения могут быть применены к тексту; эффекты 3D Формата и 3D Поворота могут быть применены к текстовому блоку; свойство Мягкие края может быть применено к объекту фигуры (оно все равно оказывает влияние, даже если не установлено свойство 3D Формата).

### Применение эффектов тени

Здесь мы намерены установить свойства, относящиеся только к тексту. Мы применяем эффект тени к тексту с помощью этого кода на Python:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

API Aspose.Slides поддерживает три типа теней: OuterShadow, InnerShadow и PresetShadow. 

С помощью PresetShadow вы можете применить тень к тексту (с использованием предустановленных значений). 

**Использование Microsoft PowerPoint**

В PowerPoint вы можете использовать один тип тени. Вот пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides на самом деле позволяет вам применять два типа теней одновременно: InnerShadow и PresetShadow.

**Примечания:**

- Когда OuterShadow и PresetShadow используются вместе, применяется только эффект OuterShadow. 
- Если одновременно используются OuterShadow и InnerShadow, результирующий или примененный эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается. Но в PowerPoint 2007 применяется эффект OuterShadow. 

### Применение отображения к текстам

Мы добавляем отображение к тексту с помощью этого примера кода на Python:

```py 
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

### Применение эффекта свечения к текстам

Мы применяем эффект свечения к тексту, чтобы он сиял или выделялся, с помощью этого кода:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Вы можете изменить параметры тени, отображения и свечения. Свойства эффектов устанавливаются для каждой части текста отдельно. 

{{% /alert %}} 

### Использование трансформаций в WordArt

Мы используем свойство Transform (свойственное всему блоку текста) с помощью этого кода:
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Как Microsoft PowerPoint, так и Aspose.Slides для Python через .NET предоставляют определенное количество предустановленных типов трансформаций. 

{{% /alert %}} 

**Использование PowerPoint**

Чтобы получить доступ к предустановленным типам трансформаций, перейдите в: **Формат** -> **Эффект текста** -> **Трансформация**

**Использование Aspose.Slides**

Для выбора типа трансформации используйте перечисление TextShapeType. 

### Применение 3D эффектов к текстам и формам

Мы устанавливаем 3D эффект на текстовую форму с помощью этого образца кода:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Получившийся текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D эффект к тексту с помощью этого кода на Python:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Результат операции:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Применение 3D эффектов к текстам или их формам и взаимодействие между эффектами основаны на определенных правилах. 

Учтите сцену для текста и формы, содержащей этот текст. 3D эффект содержит представление 3D объекта и сцену, на которой этот объект был размещен. 

- Когда сцена установлена как для фигуры, так и для текста, сцена фигуры имеет приоритет — сцена текста игнорируется. 
- Когда фигура не имеет своей собственной сцены, но имеет 3D представление, используется сцена текста. 
- В противном случае — когда у фигуры изначально нет 3D эффекта — фигура плоская и 3D эффект применяется только к тексту. 

Описание связано с [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) и [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) свойствами.

{{% /alert %}} 

## **Применение эффектов внешней тени к текстам**
Aspose.Slides для Python через .NET предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) и [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/), которые позволяют применять эффекты тени к тексту, представленному TextFrame. Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Rectangle на слайд.
4. Получите доступ к TextFrame, связанному с AutoShape.
5. Установите FillType AutoShape на NoFill.
6. Создайте экземпляр класса OuterShadow.
7. Установите BlurRadius тени.
8. Установите Direction тени.
9. Установите Distance тени.
10. Установите RectanglelAlign на TopLeft.
11. Установите PresetColor тени на Black.
12. Запишите презентацию как файл PPTX.

Этот пример кода на Python — реализация вышеуказанных шагов — показывает, как применить эффект внешней тени к тексту:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Получите ссылку на слайд
    sld = pres.slides[0]

    # Добавьте AutoShape типа Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Добавьте TextFrame в Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Отключите заливку формы, если мы хотим получить тень текста
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Добавьте внешнюю тень и установите все необходимые параметры
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Запишите презентацию на диск
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Применение эффекта внутренней тени к формам**
Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд.
3. Добавьте AutoShape типа Rectangle.
4. Включите InnerShadowEffect.
5. Установите все необходимые параметры.
6. Установите ColorType как Scheme.
7. Установите цвет схемы.
8. Запишите презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Этот пример кода (основываясь на вышеуказанных шагах) показывает, как добавить соединитель между двумя формами на Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Получите ссылку на слайд
    slide = presentation.slides[0]

    # Добавьте AutoShape типа Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Добавьте TextFrame в Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Включите inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Установите все необходимые параметры
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Установите ColorType как Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Установите цвет схемы
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Сохраните презентацию
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```