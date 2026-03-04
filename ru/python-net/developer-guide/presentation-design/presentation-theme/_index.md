---
title: Управление темами презентаций PowerPoint в Python
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/python-net/presentation-theme/
keywords:
- Тема PowerPoint
- Тема презентации
- Тема слайда
- Установить тему
- Изменить тему
- Управление темой
- Цвет темы
- Дополнительная палитра
- Шрифт темы
- Стиль темы
- Эффект темы
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте, настраивайте и конвертируйте файлы PowerPoint с единым брендингом, используя основные темы презентаций в Aspose.Slides для Python через .NET."
---
## **Обзор**

Тема презентации определяет свойства её элементов дизайна. Выбирая тему, вы выбираете согласованный набор визуальных элементов и их свойства.

В PowerPoint тема включает цвета, [шрифты](/slides/ru/python-net/powerpoint-fonts/), [стили фона](/slides/ru/python-net/presentation-background/), и эффекты.

![theme-constituents](theme-constituents.png)

## **Изменить цвет темы**

Тема PowerPoint использует определённый набор цветов для разных элементов слайда. Если вам не нравятся значения по умолчанию, вы можете изменить их, применив новые цвета темы. Чтобы позволить вам выбрать новый цвет темы, Aspose.Slides предоставляет значения в перечислении [SchemeColor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/schemecolor/).

Этот пример кода Python показывает, как изменить акцентный цвет темы:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Вы можете определить фактическое значение полученного цвета следующим образом:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Пример вывода:
#
# ff8064a2 (Цвет [A=255, R=128, G=100, B=162])
```

Чтобы дополнительно продемонстрировать изменение цвета, мы создаём ещё один элемент, назначаем ему акцентный цвет из начального шага и затем обновляем цвет темы.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Новый цвет автоматически применяется к обоим элементам.

### **Задать цвет темы из дополнительной палитры**

Когда вы применяете преобразования яркости к основному цвету темы (1), генерируются цвета из дополнительной палитры (2). Затем вы можете установить и получить эти цвета темы.

![additional-palette-colors](additional-palette-colors.png)

**1** — Основные цвета темы  
**2** — Цвета из дополнительной палитры

Этот пример кода Python демонстрирует, как цвета дополнительной палитры выводятся из основного цвета темы и затем используются в фигурах:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Акцент 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Акцент 4, светлее 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Акцент 4, светлее 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Акцент 4, светлее 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Акцент 4, темнее 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Акцент 4, темнее 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **Сопоставление `SchemeColor` и цветов `ColorScheme`**

Работая с [SchemeColor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/schemecolor/), вы можете заметить, что он содержит следующие значения цветов темы:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1`, and `TEXT2`.

Однако `Presentation.master_theme.color_scheme` возвращает [ColorScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/colorscheme/), который представляет соответствующие цвета как:

`dark1`, `dark2`, `light1`, and `light2`.

Это различие только в названиях. Эти значения относятся к тем же слотам цветов темы, и сопоставление фиксировано:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Динамического преобразования между `TEXT`/`BACKGROUND` и `dark`/`light` нет. Это просто альтернативные имена одних и тех же цветов темы.

Такое различие в названиях происходит из терминологии Microsoft Office. В старых версиях Office использовались `Dark 1`, `Light 1`, `Dark 2` и `Light 2`, в то время как в новых версиях пользовательского интерфейса те же слоты отображаются как `Text 1`, `Background 1`, `Text 2` и `Background 2`.

## **Изменить шрифт темы**

Чтобы позволить вам выбирать шрифты для тем и других целей, Aspose.Slides использует следующие специальные идентификаторы (аналогичные тем, что в PowerPoint):

- **+mn-lt** — Основной шрифт Latin (Minor Latin Font)
- **+mj-lt** — Шрифт заголовка Latin (Major Latin Font)
- **+mn-ea** — Основной шрифт East Asian (Minor East Asian Font)
- **+mj-ea** — Шрифт заголовка East Asian (Major East Asian Font)

Этот пример кода Python показывает, как назначить шрифт Latin элементу темы:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Этот пример кода Python показывает, как изменить шрифт темы презентации:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Все текстовые поля будут обновлены новым шрифтом.

{{% alert color="primary" title="TIP" %}}
Для получения дополнительной информации смотрите [Основные шрифты PowerPoint для Python](/slides/ru/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Изменить стиль фона темы**

По умолчанию PowerPoint предоставляет 12 предустановленных фонов, но обычная презентация хранит только 3 из них.

![todo:image_alt_text](presentation-design_8.png)

Например, после сохранения презентации в PowerPoint вы можете выполнить следующий код Python, чтобы определить, сколько предустановленных фонов она содержит:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Используя свойство `background_fill_styles` из класса [FormatScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/) вы можете добавить или получить доступ к стилям фона в теме PowerPoint.
{{% /alert %}}

```python
presentation.masters[0].background.style_index = 2  # 0 обозначает отсутствие заливки; индексация начинается с 1.
```

{{% alert color="primary" title="TIP" %}}
Для получения дополнительной информации см. [Управление фонами презентации в Python](/slides/ru/python-net/presentation-background/).
{{% /alert %}}

## **Изменить эффекты темы**

Тема PowerPoint обычно содержит три значения в каждом массиве стилей. Эти массивы комбинируются в три уровня эффектов: тонкий, умеренный и интенсивный. Например, ниже показан результат применения этих эффектов к конкретной фигуре:

![todo:image_alt_text](presentation-design_10.png)

Используя три свойства — `FillStyles`, `LineStyles` и `EffectStyles` — из класса [FormatScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/) вы можете изменять элементы темы (даже более гибко, чем в PowerPoint).

Этот пример кода Python показывает, как изменить эффект темы, изменяя части этих элементов:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Полученные изменения включают обновления цвета заливки, типа заливки, эффекта тени и других свойств:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Могу ли я применить тему к отдельному слайду без изменения мастера?**  
Да. Aspose.Slides поддерживает переопределения темы на уровне слайда, поэтому вы можете применить локальную тему только к этому слайду, оставив мастер‑тему неизменной (через [SlideThemeManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/slidethememanager/)).

**Какой самый безопасный способ перенести тему из одной презентации в другую?**  
[Клонировать слайды](/slides/ru/python-net/clone-slides/) вместе с их мастером в целевую презентацию. Это сохраняет оригинальный мастер, макеты и связанную тему, поэтому внешний вид остаётся одинаковым.

**Как я могу увидеть «фактические» значения после всей наследования и переопределений?**  
Используйте «фактические» представления API [/slides/ru/python-net/shape-effective-properties/] для темы/цвета/шрифта/эффекта. Они возвращают окончательные разрешённые свойства после применения мастера и всех локальных переопределений.