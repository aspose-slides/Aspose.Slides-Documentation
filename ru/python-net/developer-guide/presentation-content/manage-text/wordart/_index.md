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
- эффект отображения
- эффект свечения
- трансформация WordArt
- 3D‑эффект
- эффект внешней тени
- эффект внутренней тени
- Python
- Aspose.Slides
description: "Узнайте, как создавать и настраивать эффекты WordArt в Aspose.Slides для Python через .NET. Это пошаговое руководство помогает разработчикам улучшать презентации стильным, профессиональным текстом в Python."
---

## **О WordArt?**
WordArt или Word Art — это функция, позволяющая применять эффекты к тексту, чтобы он выделялся. С помощью WordArt, например, можно обвести текст контуром или заполнить его цветом (или градиентом), добавить 3D‑эффекты и т.д. Также можно наклонять, изгибать и растягивать форму текста. 

{{% alert color="primary" %}} 

WordArt позволяет обращаться с текстом так же, как с графическим объектом. WordArt состоит из эффектов или специальных модификаций, применяемых к тексту, чтобы сделать его более привлекательным или заметным. 

{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, необходимо выбрать один из предопределённых шаблонов WordArt. Шаблон WordArt — это набор эффектов, которые применяются к тексту или его форме. 

**WordArt в Aspose.Slides**

В Aspose.Slides для Python через .NET 20.10 была реализована поддержка WordArt, а в последующих версиях Aspose.Slides для Python через .NET функциональность была улучшена. 

С Aspose.Slides для Python через .NET вы можете легко создавать собственный шаблон WordArt (один эффект или комбинацию эффектов) в Python и применять его к текстам. 

## Создание простого шаблона WordArt и применение его к тексту

**Использование Aspose.Slides** 

Сначала мы создаём простой текст с помощью этого кода Python: 
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

Теперь мы задаём высоту шрифта текста большим значением, чтобы эффект был более заметным, используя следующий код: 
```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```


**Использование Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

В правой части меню можно выбрать предопределённый эффект WordArt. В левой части меню можно задать настройки нового WordArt. 

Ниже перечислены некоторые доступные параметры или опции:

![todo:image_alt_text](image-20200930114015-3.png)

**Использование Aspose.Slides**

Здесь мы применяем к тексту цвет шаблона SmallGrid и добавляем чёрную границу шириной 1 пкс с помощью следующего кода: 
```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```


Полученный текст:

![todo:image_alt_text](image-20200930114108-4.png)

## Применение других эффектов WordArt

**Использование Microsoft PowerPoint**

Из интерфейса программы можно применять эти эффекты к тексту, текстовому блоку, фигуре или аналогичному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, к тексту можно применить эффекты Тень, Отражение и Свечение; к текстовому блоку — эффекты 3D Формат и 3D Вращение; к объекту формы — свойство Мягкие края (оно действует, даже если не задано свойство 3D Формат). 

### Применение теневых эффектов

Здесь мы будем менять свойства, относящиеся только к тексту. Применяем теневой эффект к тексту с помощью следующего кода Python: 
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

С помощью PresetShadow можно применить тень к тексту (используя предустановленные значения). 

**Использование Microsoft PowerPoint**

В PowerPoint доступен только один тип тени. Пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Использование Aspose.Slides**

Aspose.Slides позволяет одновременно применять два типа теней: InnerShadow и PresetShadow.

**Примечания:**

- При одновременном использовании OuterShadow и PresetShadow применяется только эффект OuterShadow. 
- Если OuterShadow и InnerShadow используются одновременно, применяемый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется OuterShadow. 

### Применение отображения к текстам

Мы добавляем отображение к тексту с помощью следующего примера кода Python: 
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

Мы применяем эффект свечения к тексту, чтобы он сиял или выделялся, используя следующий код: 
```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```


Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Вы можете менять параметры тени, отображения и свечения. Свойства эффектов задаются отдельно для каждой части текста. 

{{% /alert %}} 

### Использование трансформаций в WordArt

Мы применяем свойство Transform (действующее на весь блок текста) с помощью следующего кода: 
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```


Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

И Microsoft PowerPoint, и Aspose.Slides для Python через .NET предоставляют определённое количество предопределённых типов трансформаций. 

{{% /alert %}} 

**Использование PowerPoint**

Для доступа к предопределённым типам трансформаций перейдите: **Format** -> **TextEffect** -> **Transform**

**Использование Aspose.Slides**

Для выбора типа трансформации используйте перечисление TextShapeType. 

### Применение 3D‑эффектов к текстам и фигурам

Мы задаём 3D‑эффект форме текста с помощью следующего примера кода: 
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


Полученный текст и его форма:

![todo:image_alt_text](image-20200930114816-9.png)

Мы применяем 3D‑эффект к тексту с помощью этого кода Python: 
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

Применение 3D‑эффектов к текстам или их формам и взаимодействие между эффектами основывается на определённых правилах. 

Рассмотрим сцену для текста и формы, содержащей этот текст. 3D‑эффект включает представление 3D‑объекта и сцену, на которой объект размещён. 

- Когда сцена задаётся как для фигуры, так и для текста, приоритет имеет сцена фигуры — сцена текста игнорируется. 
- Когда у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста. 
- Иначе — когда у формы изначально нет 3D‑эффекта, форма остаётся плоской, а 3D‑эффект применяется только к тексту. 

Эти описания связаны со свойствами [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) и [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/). 

{{% /alert %}} 

## **Применение внешних теней к текстам**
Aspose.Slides для Python через .NET предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) и [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/), позволяющие применять теневые эффекты к тексту, содержащемуся в TextFrame. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Получите ссылку на слайд, используя его индекс. 
3. Добавьте к слайду AutoShape типа Rectangle. 
4. Получите доступ к TextFrame, связанному с AutoShape. 
5. Установите свойство FillType у AutoShape в значение NoFill. 
6. Создайте экземпляр класса OuterShadow. 
7. Задайте BlurRadius тени. 
8. Установите Direction тени. 
9. Задайте Distance тени. 
10. Установите RectanglelAlign в TopLeft. 
11. Установите PresetColor тени в Black. 
12. Сохраните презентацию в файл PPTX. 

Этот пример кода на Python, реализующий описанные шаги, показывает, как применить внешний теневой эффект к тексту: 
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Получить ссылку на слайд
    sld = pres.slides[0]

    # Добавить AutoShape типа Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Добавить TextFrame к Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Отключить заливку фигуры, если нужно получить тень текста
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Добавить внешнюю тень и установить все необходимые параметры
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Сохранить презентацию на диск
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Применение внутренней тени к фигурам**
Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Получите ссылку на слайд. 
3. Добавьте AutoShape типа Rectangle. 
4. Включите InnerShadowEffect. 
5. Задайте все необходимые параметры. 
6. Установите ColorType в Scheme. 
7. Установите Scheme Color. 
8. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Этот пример кода (основанный на вышеуказанных шагах) показывает, как добавить соединитель между двумя фигурами в Python: 
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Получить ссылку на слайд
    slide = presentation.slides[0]

    # Добавить AutoShape типа Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Добавить TextFrame к Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Включить inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Установить все необходимые параметры
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Установить ColorType как Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Установить Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Сохранить презентацию
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли использовать эффекты WordArt с разными шрифтами или скриптами (например, арабский, китайский)?**

Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и скриптами. Эффекты WordArt, такие как тень, заливка и контур, можно применять независимо от языка, хотя доступность шрифтов и их отображение зависят от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайдов?**

Да, вы можете применять эффекты WordArt к фигурам на шаблонах слайдов, включая заполнитель заголовка, нижний колонтитул или фоновый текст. Изменения, внесённые в шаблон, отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**

Слегка. Такие эффекты, как тени, свечение и градиентные заливки, могут немного увеличить размер файла за счёт добавления метаданных форматирования, но разница обычно незначительна.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**

Да, вы можете отрисовать слайды с WordArt в изображения (например, PNG, JPEG), используя метод `get_image` классов [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) или [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). Это позволяет увидеть результат в памяти или на экране перед сохранением или экспортом полной презентации.