---
title: Тема презентации
type: docs
weight: 10
url: /ru/python-net/presentation-theme/
keywords: "Тема, тема PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Тема презентации PowerPoint на Python"
---

Тема презентации определяет свойства элементов дизайна. Когда вы выбираете тему презентации, вы по сути выбираете конкретный набор визуальных элементов и их свойства.

В PowerPoint тема включает цвета, [шрифты](/slides/ru/python-net/powerpoint-fonts/), [стили фона](/slides/ru/python-net/presentation-background/) и эффекты.

![theme-constituents](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует конкретный набор цветов для различных элементов на слайде. Если вам не нравятся цвета, вы можете изменить их, применив новые цвета для темы. Чтобы позволить вам выбрать новый цвет темы, Aspose.Slides предоставляет значения в перечислении [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/).

Этот код на Python показывает, как изменить цвет акцента для темы:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Вы можете определить эффективное значение результирующего цвета следующим образом:

```python
fillEffective = shape.fill_format.get_effective()
print("{0} ({1})".format(fillEffective.solid_fill_color.name, fillEffective.solid_fill_color)) # ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Чтобы дополнительно продемонстрировать операцию изменения цвета, мы создаем другой элемент и назначаем ему цвет акцента (из первоначальной операции). Затем мы изменяем цвет в теме:

```python
otherShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
otherShape.fill_format.fill_type = slides.FillType.SOLID
otherShape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

pres.master_theme.color_scheme.accent4.color = draw.Color.red
```

Новый цвет автоматически применяется ко всем элементам.

### **Установить цвет темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы(1), формируются цвета из дополнительной палитры(2). Вы затем можете установить и получить эти цвета темы. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Основные цвета темы

**2** - Цвета из дополнительной палитры.

Этот код на Python демонстрирует операцию, при которой дополнительные цвета палитры получаются из основного цвета темы и затем используются в фигурах:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Акцент 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Акцент 4, Светлее на 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Акцент 4, Светлее на 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Акцент 4, Светлее на 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Акцент 4, Темнее на 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Акцент 4, Темнее на 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменить шрифт темы**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует специальные идентификаторы (аналогичные тем, которые используются в PowerPoint):

* **+mn-lt** - Шрифт тела Латиница (Минорный латинский шрифт)
* **+mj-lt** - Шрифт заголовка Латиница (Мажорный латинский шрифт)
* **+mn-ea** - Шрифт тела Восточная Азия (Минорный восточноазиатский шрифт)
* **+mj-ea** - Шрифт заголовка Восточная Азия (Мажорный восточноазиатский шрифт)

Этот код на Python показывает, как назначить латинский шрифт элементу темы:

```python
shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)

paragraph = slides.Paragraph()
portion = slides.Portion("Формат текста темы")
paragraph.portions.add(portion)
shape.text_frame.paragraphs.add(paragraph)
portion.portion_format.latin_font = slides.FontData("+mn-lt")
```

Этот код на Python показывает, как изменить шрифт темы презентации:

```python
pres.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Шрифт во всех текстовых полях будет обновлен.

{{% alert color="primary" title="ПОДСКАЗКА" %}} 

Вам может быть интересно посмотреть [шрифты PowerPoint](/slides/ru/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Изменить стиль фона темы**

По умолчанию приложение PowerPoint предоставляет 12 предопределенных фонов, но только 3 из этих 12 фонов сохраняются в типичной презентации. 

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в приложении PowerPoint вы можете запустить этот код на Python, чтобы узнать количество предопределенных фонов в презентации:

```python
with slides.Presentation() as pres:
    numberOfBackgroundFills = len(pres.master_theme.format_scheme.background_fill_styles)
    print("Количество стилей заливки фона для темы составляет {0}".format(numberOfBackgroundFills))
```

{{% alert color="warning" %}} 

Используя свойство `BackgroundFillStyles` из класса [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/), вы можете добавить или получить стиль фона в теме PowerPoint. 

{{% /alert %}}

Этот код на Python показывает, как установить фон для презентации:

```python
pres.masters[0].background.style_index = 2
```

**Справочник по индексам**: 0 используется для без заливки. Индекс начинается с 1.

{{% alert color="primary" title="ПОДСКАЗКА" %}} 

Вам может быть интересно посмотреть [фон PowerPoint](/slides/ru/python-net/presentation-background/).

{{% /alert %}}

## **Изменить эффект темы**

Тема PowerPoint обычно содержит 3 значения для каждого массива стилей. Эти массивы объединяются в 3 эффекта: тонкие, умеренные и интенсивные. Например, вот результат, когда эффекты применяются к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя 3 свойства (`FillStyles`, `LineStyles`, `EffectStyles`) из класса [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/), вы можете изменять элементы в теме (даже более гибко, чем опции в PowerPoint).

Этот код на Python показывает, как изменить эффект темы, изменяя части элементов:

```python
with slides.Presentation("combined_with_master.pptx") as pres:
    pres.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    pres.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    pres.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    pres.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", slides.export.SaveFormat.PPTX)
```

Результирующие изменения в цвете заливки, типе заливки, эффекте тени и т.д.:

![todo:image_alt_text](presentation-design_11.png)