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
- Управлять темой
- Внешняя тема
- THMX
- Цвет темы
- Дополнительная палитра
- Шрифт темы
- Стиль темы
- Эффект темы
- PowerPoint
- OpenDocument
- Презентация
- Python
- Aspose.Slides
description: "Управление темами презентаций в Aspose.Slides для Python через .NET для создания, настройки и конвертации файлов PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через свойство [Presentation.master_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/master_theme/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/masterthememanager/override_theme/), макет может переопределять унаследованную тему через [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), и отдельный слайд может делать то же самое. На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Ниже показаны наиболее распространённые сценарии работы с темой: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после применения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/) предоставляет доступ к свойствам темы: [color_scheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/font_scheme/) и [format_scheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/format_scheme/). Просмотр этих коллекций перед их изменением особенно полезен, когда презентация получена из внешнего источника, поскольку количество и содержание записей стилей могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линий и эффектов хранится в теме:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Просмотрите мастер, связанный со слайдом, и используйте рабочий процесс эффективной темы, показанный позже в статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Заполнения, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/schemecolor/). Когда вы меняете соответствующую запись в [ColorScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/colorscheme/) темы, все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `ACCENT4`, меняет цвет `accent4` темы на красный, сохраняет презентацию, открывает её вновь и выводит эффективный цвет заливки:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Поскольку прямоугольник остаётся связанным с `ACCENT4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет фигуры, последующие изменения `accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цветовой схемы темы, применяя трансформации цвета. Aspose.Slides предоставляет эти трансформации через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Основные цвета темы.

**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `ACCENT4`, применяет к пяти из них преобразования яркости и сохраняет результат:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Эти варианты остаются основанными на цветовом элементе темы. Если `accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `accent4`.

### **Отображение значений `SchemeColor` в слоты `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/schemecolor/) использует `TEXT1`, `BACKGROUND1`, `TEXT2` и `BACKGROUND2`, тогда как [ColorScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/colorscheme/) раскрывает те же слоты темы как `dark1`, `light1`, `dark2` и `light2`. Соответствие фиксировано:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, которые динамически преобразуются из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор для основного текста. Свойства [FontScheme.major](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/fontscheme/major/) и [FontScheme.minor](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/fontscheme/minor/) предоставляют доступ к этим наборам.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться в форматировании текста:

* `+mn-lt` – Основной шрифт Latin (Minor Latin Font)
* `+mj-lt` – Шрифт заголовка Latin (Major Latin Font)
* `+mn-ea` – Основной шрифт East Asian (Minor East Asian Font)
* `+mj-ea` – Шрифт заголовка East Asian (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем он меняет шрифты темы и сохраняет результат:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

Заголовок следует за основным шрифтом, а основной текст – за вспомогательным. Текст, у которого явно указано имя шрифта вместо идентификатора темы, не переключится автоматически при изменении схемы шрифтов темы.

Основные и вспомогательные наборы шрифтов также могут содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить такие сопоставления, см. раздел [Script-Specific Theme Fonts](/slides/ru/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже приведены сценарии решения различных проблем, связанных с темами.

### **Применение внешней темы к слайдам, зависящим от мастера**

Используйте [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/), когда у вас есть файл темы PowerPoint (`.thmx`) и нужно изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation.masters](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/masters/), реализующей [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/), и передайте путь к файлу темы методу.

Метод выполняет следующие операции:

1. Создаёт новый слайд‑мастер на основе выбранного мастера.  
2. Применяет внешнюю тему к новому мастеру.  
3. Назначает новый мастер всем слайдам, ранее зависявшим от выбранного мастера.  
4. Возвращает созданный объект [IMasterSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasterslide/).

Следующий пример применяет внешнюю тему к слайдам, зависящим от первого мастера, и сохраняет презентацию:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Недопустимая, повреждённая или неподдерживаемая тема может вызвать [PptxException](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pptxexception/) или один из её подклассов, связанных с форматом. Проверяйте пути, вводимые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переприсваиваются только слайды, зависевшие от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, учитывающие тему, разрешаются по внешней теме. Прямо назначенные цвета, шрифты, заливки и другое явное форматирование могут остаться без изменений. Переопределения уровня макета и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, недоступные в среде выполнения. Для согласованного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/python-net/custom-font/), или настройте [font substitution](/slides/ru/python-net/font-substitution/).

Это прямой рабочий процесс уровня мастера: метод принимает путь к файлу `.thmx` и не требует вручную создавать переопределения темы уровня слайда или макета.

### **Применение разных внешних тем в презентации с несколькими мастерами**

Когда нужный мастер неизвестен заранее, получите его из представительного слайда через [Slide.layout_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/layout_slide/) и [LayoutSlide.master_slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/master_slide/). Сохраните исходные ссылки на мастера перед применением любых тем, так как каждый вызов создаёт ещё один мастер в презентации.

Следующий пример использует слайды из двух разделов, чтобы найти их мастера, и применяет различную внешнюю тему к каждой группе:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

Первый вызов затрагивает только слайды, зависевшие от `first_group_master`, а второй – только слайды, зависевшие от `second_group_master`. Слайды, принадлежащие другим мастерам, не перекрашиваются.

### **Сохранение исходной темы при перемещении слайдов**

Если нужно переместить слайд в другую презентацию и сохранить его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/add_clone/), затем клонируйте слайд с помощью [SlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/add_clone/) и клонированного мастера. Это перенесёт мастер, его макеты и связанную тему вместе.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Этот подход предпочтителен, когда исходный слайд должен выглядеть одинаково в целевом документе. Простое копирование содержимого на несвязанный мастер получателя может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применение значений темы к существующему слайду**

Если целевой слайд должен остаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) и [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) копируют три основных компонента темы в переопределение.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Это меняет тему, используемую этим слайдом, не затрагивая тему, унаследованную другими слайдами. Чтобы удалить локальное переопределение и вернуть наследуемые значения, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/clear/).

### **Применение переопределения темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только у конкретного слайда нет собственного переопределения. Те же методы инициализации можно вызвать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/layoutslidethememanager/) макета:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Используйте тему мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; используйте переопределение макета, когда одной семье макетов нужен иной стиль; и переопределение слайда – только для истинных исключений. Чрезмерное количество переопределений уровня слайда усложняет предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фоновых заливок темы**

Фоновые заливки темы хранятся в [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint может показывать в интерфейсе больше вариантов фона, чем количество определений заливок, физически хранящихся в этой коллекции, потому что UI может комбинировать заливки темы с цветовыми элементами темы и другими ссылками стилей.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Перед использованием фонового стиля изучите сохранённую коллекцию и текущее значение [Background.style_index](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/style_index/). `style_index` использует `0` для отсутствия темной заливки; положительные значения являются ссылками на стили фоновых заливок темы. Это отличается от индексации Python‑коллекции, где `[0]` означает первый элемент. Не предполагаете, что у каждой презентации одинаковое количество фоновых заливок.

Следующий пример выводит количество доступных фоновых заливок, назначает тематическую ссылку на фон первому мастеру и сохраняет презентацию:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Видимый результат зависит от записи темы, на которую ссылается мастер, а также от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фонового стиля мастера может не изменить этот слайд. Используйте [Background.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/get_effective/), когда нужно узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не рассматривайте `style_index` как индекс, начинающийся с нуля. Также избегайте жёсткой привязки номера стиля из одного файла, предполагая, что в другом файле он будет выглядеть одинаково; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. раздел [Presentation Background](/slides/ru/python-net/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FormatScheme.fill_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/line_styles/) и [FormatScheme.effect_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/effect_styles/). Типичные офисные темы часто включают три основных стиля, визуально соответствующие «тонким», «средним» и «интенсивным» форматам, но код должен проверять каждую коллекцию вместо предположения фиксированного количества.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

При доступе к этим коллекциям в Python индексация начинается с нуля: `[0]` – первая сохранённая запись, `[2]` – третья. Индексы ссылок стиля фигуры – отдельная концепция, представляемая через [IShapeStyle](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ishapestyle/). Изменение стиля темы воздействует на фигуры, ссылающиеся на этот стиль; фигуры с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, изменяет первый линейный стиль, третий заливочный стиль, включает внешнюю тень в третьем стиль‑эффекте и сохраняет результат:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Для фигур, ссылающихся на эти слоты, первый линейный стиль темы станет красным, третий заливочный стиль – сплошным темно‑зелёным, а в третьем стиле эффекта появится внешняя тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей каждая фигура использует и не переопределяется ли её прямым форматированием.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть записана непосредственно в объекте или наследоваться от абзаца, макета, мастера, стиля темы или другого уровня форматирования. Вызовите [FillFormat.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fillformat/get_effective/) для получения иерархии в виде неизменяемого объекта [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ifillformateffectivedata/). Сначала проверьте свойство [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Только если оно равно `FillType.SOLID`, следует читать свойства сплошной заливки.

Для сплошной заливки [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) возвращает окончательное отрисованное RGB‑значение после наследования, поиска в теме и применения цветовых трансформаций. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/schemecolor/), например `TEXT1` или `ACCENT6`. Значение `SchemeColor.NOT_DEFINED` означает, что эффективная сплошная заливка не основана на цветовом элементе схемы. В рабочем процессе, где заливки либо являются цветовыми элементами темы, либо прямыми RGB‑цветами, это значение указывает на прямую RGB‑заливку.

Не используйте только локальное значение [IColorFormat.scheme_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/icolorformat/scheme_color/) для классификации заливки. Например, у части текста может не быть локального определения схемного цвета, поэтому его локальное значение `NOT_DEFINED`, тогда как её эффективная заливка наследует цвет темы и разрешается в `TEXT1` или `ACCENT6`. С другой стороны, `solid_fill_scheme_color` сообщает, какой логический слот темы сформировал эффективный цвет, но не указывает, откуда этот слот пришёл – объект, абзац, макет, мастер или другой уровень иерархии.

Следующий пример загружает презентацию, проверяет заливки фигур и частей текста, выводит каждый окончательный RGB‑цвет и соответствующий цвет схемы, а также помечает сплошные заливки, которые не будут отслеживать изменения цветов темы:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

Ветка `NOT_DEFINED` предоставляет список сплошных заливок, которые не будут реагировать на изменения слотов цвета темы. При необходимости соответствовать новой бренд‑палитре проверьте эти объекты. Отображаемое RGB‑значение всё равно показывает текущий внешний вид, а значение схемы объясняет, связано ли он с темой.

Эффективные объекты – это снимки. После изменения темы презентации, переопределения темы или любого унаследованного форматирования вызовите `get_effective` ещё раз и получите новый объект `IFillFormatEffectiveData` перед сравнением или выводом цветов.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после применения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Для фона используйте [Background.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/get_effective/), а для заливки – [FillFormat.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fillformat/get_effective/).

Следующий пример читает эффективную тему, фон и первую заливку фигуры со слайда:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Используйте эффективные данные для диагностики рендеринга, валидации и сравнения. Если вы проверяете только [Presentation.master_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/master_theme/), вы можете упустить переопределения мастера, макета, слайда или фигуры, которые меняют окончательный внешний вид.

## **FAQ**

**Применяет ли внешняя тема каждую страницу презентации?**

Нет. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) переприсваивает только те слайды, которые зависят от выбранного мастера. Слайды, использующие другие мастеры, сохраняют свои существующие темы.

**Могу ли я применить тему к отдельному слайду, не меняя мастер?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой самый безопасный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида клонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/add_clone/) и затем клонируйте слайд с этим мастером, используя [SlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/add_clone/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) для слайда или темы макета и соответствующие методы получения эффективных данных для форматных объектов, таких как [Background.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/get_effective/) и [FillFormat.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fillformat/get_effective/). Эти API возвращают разрешённые значения после применения наследования и переопределений.