---
title: "Создание и применение эффектов WordArt в Python"
linktitle: "WordArt"
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
- преобразование WordArt
- 3D-эффект
- эффект внешней тени
- эффект внутренней тени
- Python
- Aspose.Slides
description: "Узнайте, как создавать и настраивать эффекты WordArt в Aspose.Slides для Python через .NET. Это пошаговое руководство помогает разработчикам улучшать презентации стильным, профессиональным текстом в Python."
---

## **О WordArt?**
WordArt или Word Art — это функция, позволяющая применять эффекты к тексту, чтобы он выделялся. С помощью WordArt, например, можно обвести текст или заполнить его цветом (или градиентом), добавить 3D‑эффекты, и т.д. Вы также можете наклонять, изгибать и растягивать форму текста. 

{{% alert color="primary" %}} 
WordArt позволяет обращаться к тексту как к графическому объекту. WordArt состоит из эффектов или специальных модификаций текста, которые делают его более привлекательным или заметным. 
{{% /alert %}} 

**WordArt в Microsoft PowerPoint**

Чтобы использовать WordArt в Microsoft PowerPoint, нужно выбрать один из предустановленных шаблонов WordArt. Шаблон WordArt — это набор эффектов, который применяется к тексту или его форме. 

**WordArt в Aspose.Slides**

В Aspose.Slides для Python через .NET 20.10 была реализована поддержка WordArt, а в последующих версиях функциональность улучшалась. 

С помощью Aspose.Slides для Python через .NET вы легко можете создать собственный шаблон WordArt (один эффект или их комбинацию) в Python и применить его к тексту. 

## Создание простого шаблона WordArt и применение его к тексту

**Используя Aspose.Slides** 

Сначала создаём простой текст с помощью этого кода на Python: 

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

Теперь задаём высоту шрифта текста больше, чтобы эффект был заметнее, через следующий код:

```py
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Используя Microsoft PowerPoint**

Перейдите в меню эффектов WordArt в Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

В правой панели можно выбрать предустановленный эффект WordArt. В левой — задать настройки нового WordArt. 

Ниже представлены некоторые доступные параметры или опции:

![todo:image_alt_text](image-20200930114015-3.png)

**Используя Aspose.Slides**

Здесь мы применяем цвет узора SmallGrid к тексту и добавляем чёрную границу шириной 1 пиксель с помощью кода:

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

**Используя Microsoft PowerPoint**

Из интерфейса программы можно применять эти эффекты к тексту, блоку текста, фигуре или подобному элементу:

![todo:image_alt_text](image-20200930114129-5.png)

Например, эффекты Тень, Отражение и Свечение можно применить к тексту; Формат 3D и Вращение 3D — к блоку текста; Свойство Мягкие границы — к объекту‑фигуре (оно работает даже без свойства Формат 3D). 

### Применение эффектов тени

Здесь мы будем настраивать свойства, относящиеся только к тексту. Применяем эффект тени к тексту с помощью этого кода на Python:

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

С помощью PresetShadow можно применить предустановленную тень к тексту. 

**Используя Microsoft PowerPoint**

В PowerPoint доступен только один тип тени. Пример:

![todo:image_alt_text](image-20200930114225-6.png)

**Используя Aspose.Slides**

Aspose.Slides позволяет одновременно применять два типа теней: InnerShadow и PresetShadow.

**Примечания:**

- При совместном использовании OuterShadow и PresetShadow применяется только OuterShadow. 
- Если одновременно использовать OuterShadow и InnerShadow, итоговый эффект зависит от версии PowerPoint. Например, в PowerPoint 2013 эффект удваивается, а в PowerPoint 2007 применяется OuterShadow. 

### Применение эффекта отображения к тексту

Мы добавляем эффект отображения к тексту через следующий код на Python:

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

### Применение эффекта свечения к тексту

Применяем эффект свечения, чтобы текст блестел или выделялся, используя следующий код:

```py
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Результат операции:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Вы можете менять параметры теней, отображения и свечения. Свойства эффектов задаются отдельно для каждой части текста. 
{{% /alert %}} 

### Использование преобразований в WordArt

Мы применяем свойство Transform (общее для всего блока текста) через следующий код:
```py
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Результат:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Как Microsoft PowerPoint, так и Aspose.Slides для Python через .NET предоставляют определённое количество предустановленных типов преобразований. 
{{% /alert %}} 

**Используя PowerPoint**

Для доступа к предустановленным типам преобразований перейдите: **Format** → **TextEffect** → **Transform**.

**Используя Aspose.Slides**

Для выбора типа преобразования используйте перечисление TextShapeType. 

### Применение 3D‑эффектов к тексту и фигурам

Мы задаём 3D‑эффект для фигуры текста с помощью этого примера кода:

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

Мы применяем 3D‑эффект к тексту с помощью этого кода на Python:

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
Применение 3D‑эффектов к текстам или их формам и взаимодействие между эффектами регулируются определёнными правилами. 

Рассмотрим сцену для текста и формы, содержащей этот текст. 3D‑эффект состоит из представления 3D‑объекта и сцены, в которой объект размещён. 

- Когда сцена задана как для фигуры, так и для текста, приоритет имеет сцена фигуры — сцена текста игнорируется. 
- Если у фигуры нет собственной сцены, но есть 3D‑представление, используется сцена текста. 
- Иначе, если у формы изначально нет 3D‑эффекта, форма остаётся плоской, а 3D‑эффект применяется только к тексту. 

Описания связаны со свойствами [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) и [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/). 
{{% /alert %}} 

## **Применить внешний эффект тени к тексту**
Aspose.Slides для Python через .NET предоставляет классы [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) и [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/), позволяющие применить эффекты тени к тексту в TextFrame. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд, используя его индекс.  
3. Добавьте AutoShape типа Rectangle на слайд.  
4. Получите доступ к TextFrame, связанному с AutoShape.  
5. Установите FillType AutoShape в NoFill.  
6. Создайте экземпляр класса OuterShadow.  
7. Задайте BlurRadius тени.  
8. Задайте Direction тени.  
9. Задайте Distance тени.  
10. Установите RectangleAlign в TopLeft.  
11. Установите PresetColor тени в Black.  
12. Сохраните презентацию в файл PPTX.  

Пример кода на Python, реализующий указанные шаги:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Get reference of the slide
    sld = pres.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Add TextFrame to the Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Disable shape fill in case we want to get shadow of text
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Add outer shadow and set all necessary parameters
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Write the presentation to disk
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Применить внутренний эффект тени к фигурам**
Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Получите ссылку на слайд.  
3. Добавьте AutoShape типа Rectangle.  
4. Включите InnerShadowEffect.  
5. Задайте все необходимые параметры.  
6. Установите ColorType как Scheme.  
7. Установите Scheme Color.  
8. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Пример кода (по указанным шагам), показывающий, как добавить внутреннюю тень к фигуре в Python:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Get reference of a slide
    slide = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Add TextFrame to the Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Enable inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Set all necessary parameters
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Set ColorType as Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Set Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Save Presentation
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли использовать эффекты WordArt с различными шрифтами или сценариями (например, арабский, китайский)?**  
Да, Aspose.Slides поддерживает Unicode и работает со всеми основными шрифтами и сценариями. Эффекты WordArt, такие как тень, заливка и обводка, можно применять независимо от языка, хотя доступность шрифтов и рендеринг могут зависеть от системных шрифтов.

**Можно ли применять эффекты WordArt к элементам шаблона слайдов?**  
Да, вы можете применять эффекты WordArt к фигурам на шаблонах слайдов, включая заполнители заголовков, колонтитулы или фоновые тексты. Изменения в шаблоне отразятся на всех связанных слайдах.

**Влияют ли эффекты WordArt на размер файла презентации?**  
Незначительно. Эффекты WordArt, такие как тени, свечения и градиентные заливки, могут слегка увеличить размер файла из‑за добавления метаданных форматирования, но обычно разница пренебрежимо мала.

**Можно ли предварительно просмотреть результат эффектов WordArt без сохранения презентации?**  
Да, вы можете отрисовывать слайды с WordArt в изображения (например, PNG, JPEG) с помощью метода `get_image` классов [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) или [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). Это позволяет увидеть результат в памяти или на экране до сохранения или экспорта полной презентации.