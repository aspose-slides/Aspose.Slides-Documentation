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
- презентация
- Python
- Aspose.Slides
description: "Основные темы презентаций в Aspose.Slides для Python через .NET для создания, настройки и конвертации файлов PowerPoint с единообразным брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через свойство [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации с помощью [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/), макет может переопределять наследованную тему с помощью [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), и отдельный слайд может делать то же самое. На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

В секциях ниже показаны наиболее распространённые сценарии работы с темой: проверка темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Осмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) предоставляет свойства темы: [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) и [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/). Проверка этих коллекций перед изменением особенно полезна, когда презентация поступает из внешнего источника, поскольку количество и содержимое записей стилей могут варьироваться.

Следующий пример читает основные свойства темы и сообщает, сколько стилей фона, заливки, линий и эффектов хранится в теме:

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

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте мастер, связанный со слайдом, и используйте рабочий процесс effective‑theme, показанный позже в статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Заливки, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/). При изменении соответствующей записи в [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) темы все объекты, продолжающие ссылаться на этот цвет темы, будут использованы с новым значением. Объекты, использующие прямой цвет RGB, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `ACCENT4`, меняет цвет темы `accent4` на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `ACCENT4`, его видимый цвет станет красным после изменения темы. Если заменить цвет схемы прямым цветом в фигуре, последующие изменения `accent4` больше не будут влиять на эту заливку.

### **Использовать цвета из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides открывает эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, полученные из дополнительной палитры](additional-palette-colors.png)

**1** - Основные цвета темы.  
**2** - Более светлые и более тёмные варианты, полученные из основных цветов темы.

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

Эти варианты остаются основанными на цвете темы. Если `accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `accent4`.

### **Отобразить значения `SchemeColor` в слоты `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) использует `TEXT1`, `BACKGROUND1`, `TEXT2` и `BACKGROUND2`, тогда как [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) представляет те же слоты темы как `dark1`, `light1`, `dark2` и `light2`. Отображение фиксировано:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Это альтернативные названия одних и тех же слотов темы; они не являются динамически конвертируемыми значениями.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор для основного текста. Свойства [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) и [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) предоставляют эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться в форматировании текста:

* `+mn‑lt` - Шрифт тела Latin (Minor Latin Font)
* `+mj‑lt` - Шрифт заголовка Latin (Major Latin Font)
* `+mn‑ea` - Шрифт тела East Asian (Minor East Asian Font)
* `+mj‑ea` - Шрифт заголовка East Asian (Major East Asian Font)
* `+mn‑cs` - Шрифт тела Complex Script (Minor Complex Script Font)
* `+mj‑cs` - Шрифт заголовка Complex Script (Major Complex Script Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем меняет шрифты темы и сохраняет результат:

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

Заголовок следует за основным шрифтом, а основной текст — за вспомогательным. Текст, у которого указано явное имя шрифта вместо идентификатора темы, не переключится автоматически при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Для проверки, добавления, замены или удаления этих сопоставлений см. [Script-Specific Theme Fonts](/slides/ru/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
For more information about presentation fonts, see [PowerPoint Fonts](/slides/ru/python-net/powerpoint-fonts/).
{{% /alert %}}

### **Разрешение ссылок на шрифты темы**

При проверке текста [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) может содержать ссылку на тему, например `+mn‑lt`, вместо имени семейства шрифта. Вызовите [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) с соответствующим [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) для разрешения этой ссылки. Префиксы `+mj` и `+mn` выбирают основной и вспомогательный набор шрифтов; суффиксы `-lt`, `-ea` и `-cs` выбирают их латинские, восточноазиатские и сложные скрипты соответственно.

Получите эффективную тему через [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) у объекта, к которому применяется тема проверяемого текста. Для обычного текста на слайде используйте `slide.create_theme_effective`, чтобы контекст включал наследованную тему слайда и локальные переопределения. При проверке самого макета или мастера используйте его собственную эффективную тему. Не предполагаете, что тема первого мастера относится ко всем слайдам.

Следующий пример создаёт часть текста, явно ссылающуюся на вспомогательный латинский шрифт. Он инициализирует схему шрифтов слайда через [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) и задаёт основные и вспомогательные латинские семейства как `Arial` и `Calibri`, делая результат воспроизводимым без входного файла.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

Вывод будет `+mn‑lt -> Calibri`, затем `Verdana -> Verdana`. Сохранённая ссылка остаётся неизменной, в то время как явное имя семейства возвращается как есть. Если бы часть использовала `+mj‑lt`, она бы разрешилась в `Arial` в этой теме.

Разрешение ссылки темы определяет семейство шрифта, указанное темой. Оно не проверяет наличие шрифта и не определяет, какой файл шрифта будет использован после подстановки или резервирования глифов при рендеринге. Смотрите [Font Selection Sequence](/slides/ru/python-net/font-selection-sequence/) и [Font Substitution](/slides/ru/python-net/font-substitution/) для этих отдельных шагов.

## **Копировать или применить тему**

Нижеописанные рабочие процессы решают разные задачи, связанные с темой.

### **Применить внешний шаблон к слайдам, зависящим от мастера**

Используйте [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/), когда у вас есть файл темы PowerPoint (`.thmx`) и нужно изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) и передайте путь к файлу темы методу.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.  
2. Применяет внешний шаблон к новому мастеру.  
3. Назначает новый мастер всем слайдам, ранее зависявшим от выбранного мастера.  
4. Возвращает вновь созданный [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

Следующий пример применяет внешний шаблон к слайдам, зависящим от первого мастера, и сохраняет презентацию:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Недопустимый, повреждённый или неподдерживаемый шаблон может вызвать [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) или один из его подклассов, связанных с форматом. Проверяйте пути, задаваемые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переназначаются только слайды, зависявшие от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, учитывающие тему, разрешаются относительно внешнего шаблона. Прямо назначенные цвета, шрифты, заливки и другое явное форматирование могут остаться без изменений. Переопределения уровня макета и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, недоступные в среде выполнения. Для согласованного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/python-net/custom-font/), либо настройте [font substitution](/slides/ru/python-net/font-substitution/).

Это прямой рабочий процесс уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или макета.

### **Применить разные внешние шаблоны в презентации с несколькими мастерами**

Когда нужный мастер неизвестен заранее, получите его из представительного слайда через [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) и [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). Сохраните исходные ссылки на мастеры до применения любой темы, так как каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух секций для определения их мастеров и применяет различный внешний шаблон к каждой группе:

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

Первый вызов влияет только на слайды, зависящие от `first_group_master`, а второй — только на слайды, зависящие от `second_group_master`. Слайды, принадлежащие другим мастерам, не изменятся.

### **Сохранить исходную тему при перемещении слайдов**

Если необходимо перенести слайд в другую презентацию, сохранив его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/), затем клонируйте слайд с помощью [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) и клонированного мастера. Это перенесёт мастер, его макеты и связанную тему вместе.

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

Это предпочтительный рабочий процесс, когда исходный слайд должен выглядеть одинаково в целевом документе. Простое клонирование содержимого на несвязанный мастер‑назначения может изменить цвета, шрифты, фоны и эффекты, зависящие от темы.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) и [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) копируют три основных компонента темы в переопределение.

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

Это меняет тему, используемую этим слайдом, без изменения темы, унаследованной другими слайдами. Чтобы удалить локальное переопределение и вернуть унаследованные значения, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно использовать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) макета:

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

Используйте тему мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета — когда одной семье макетов нужен иной стиль; и переопределение слайда — только для истинных исключений. Чрезмерные переопределения уровня слайда усложняют предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Заливки фона темы хранятся в [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint может предлагать больше вариантов фона в пользовательском интерфейсе, чем количество определений заливок, физически сохранённых в этой коллекции, поскольку UI может комбинировать заливки темы с цветовыми схемами темы и другими ссылками на стили.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Перед использованием стиля фона проверьте сохранённую коллекцию и текущий [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/). `style_index` использует `0` для отсутствия заливки темы; положительные значения — ссылки на стили фона темы. Это отличается от индексации коллекции Python, где `[0]` означает первый сохранённый элемент. Не предполагаете, что у каждой презентации одинаковое количество стилей заливки фона.

Следующий пример выводит количество доступных заливок фона, назначает ссылку на тематический фон первому мастеру и сохраняет презентацию:

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

Видимый результат зависит от темы, на которую ссылается мастер, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона мастера может не затронуть этот слайд. При необходимости узнать окончательный фон после применения наследования, используйте [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/).

{{% alert color="warning" title="Warning" %}}
Do not treat `style_index` as a zero-based collection index. Also avoid hard-coding a style number from one file and assuming it has the same appearance in another file; theme style definitions are presentation-specific.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
For direct background formatting and background inheritance, see [Presentation Background](/slides/ru/python-net/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) и [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/). Типичные темы Office часто включают три основных стиля, визуально соответствующие «тонким», «умеренным» и «интенсивным» форматированиям, но в коде следует проверять каждую коллекцию, а не полагаться на фиксированное количество.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

При работе с этими коллекциями в Python индексация начинается с нуля: `[0]` — первый сохранённый стиль, `[2]` — третий. Индексы ссылок стилей фигуры — отдельная концепция, представленная через [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/). Изменение стиля темы влияет на фигуры, ссылающиеся на этот стиль; фигуры с прямым форматированием могут оставаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, меняет первый стиль линии, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

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

Для фигур, ссылающихся на эти слоты, первый стиль линии темы станет красным, третий стиль заливки темы — сплошным лесным зелёным, а третий стиль эффекта получит внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё ещё зависит от того, какие слоты стилей использует каждая фигура и переопределяется ли прямая заливка.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Выбор стилей заливки и линии темы для фигуры**

Фигура может независимо выбирать заливку и контур через [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) и [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/). Для обоих свойств индекс `1` выбирает первую запись в соответствующей коллекции темы (`fill_styles[0]` или `line_styles[0]`), а индекс `2` — вторую запись.

Следующий пример определяет две заливки (золотую и небесно‑голубую) и два контура (тёмно‑синий 6 pt и тёмно‑красный 12 pt) в стандартной теме новой презентации. Он сохраняет слайд на трёх этапах, чтобы вы могли сравнить результаты в PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| Начальные стили | Изменить правый контур | Изменить первую заливку темы |
|:---:|:---:|:---:|
| ![Золотые и небесно‑голубые прямоугольники с совпадающими тонкими тёмно‑синими контурами](theme-style-initial.png) | ![Небесно‑голубой прямоугольник теперь имеет толстый тёмно‑красный контур](theme-style-line-changed.png) | ![Левый прямоугольник теперь зелёный, оба контура остаются без изменений](theme-style-fill-changed.png) |

Выбор другого стиля линии меняет только контур правого прямоугольника. Изменение первой заливки темы обновляет каждую фигуру, использующую её. Здесь только левый прямоугольник стал зелёным.

На существующей фигуре локальный цвет заливки, цвет линии или ширина линии могут переопределять соответствующую часть стиля темы. Если изменение индекса стиля не даёт видимого эффекта, проверьте [прямое форматирование](/slides/ru/python-net/shape-formatting/) фигуры.

## **Определить, использует ли эффективная сплошная заливка цвет темы**

Заливка может храниться непосредственно в объекте или наследоваться от абзаца, макета, мастера, стиля темы или другого уровня форматирования. Вызовите [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) для преобразования этой иерархии в неизменяемый объект [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/). Сначала проверьте [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Только если он равен `FillType.SOLID`, следует читать свойства сплошной заливки.

Для сплошной заливки [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) возвращает окончательное отображаемое значение RGB после наследования, поиска в теме и применения преобразований цвета. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/), например `TEXT1` или `ACCENT6`. Значение `SchemeColor.NOT_DEFINED` означает, что эффективная сплошная заливка не основана на цветовом слоте схемы. В рабочем процессе, где заливки либо цвета темы, либо прямые RGB‑цвета, это значение идентифицирует прямую RGB‑заливку.

Не используйте только локальное значение [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) для классификации заливки. Например, часть текста может не иметь локального цвета схемы, поэтому её локальное значение — `NOT_DEFINED`, тогда как её эффективная заливка наследует цвет темы и разрешается в `TEXT1` или `ACCENT6`. С другой стороны, `solid_fill_scheme_color` указывает, какой логический слот темы создал эффективный цвет, но не сообщает, от какого уровня (объекта, абзаца, макета, мастера и т.д.) он пришёл.

Следующий пример загружает презентацию, проверяет заливки фигур и заливки текстовых частей, выводит каждое окончательное значение RGB и связанный цвет схемы, а также помечает сплошные заливки, которые не будут отслеживать изменения цвета темы:

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

Ветка `NOT_DEFINED` предоставляет список сплошных заливок, которые не будут реагировать на изменения цветовых слотов темы. Проверьте эти объекты, когда презентация должна соответствовать новой бренд‑палитре. Выводимое значение RGB всё ещё отражает текущий вид, а значение схемы объясняет, связано ли оно с темой.

Объекты эффективного формата — это снимки. После изменения темы презентации, переопределения темы или любого наследуемого форматирования вызовите `get_effective` снова и получите новый объект `IFillFormatEffectiveData` перед сравнением или отчётом о цветах.

## **Чтение эффективных значений темы**

Сырые объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура фактически используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Для фона используйте [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), а для заливки — [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

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

Используйте эффективные данные для диагностики рендеринга, проверки и сравнения. Если проверять только [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/), можно упустить переопределения мастера, макета, слайда или фигуры, меняющие окончательный вид.

## **FAQ**

**Применение внешнего шаблона влияет на каждый слайд в презентации?**

Нет. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) переassigns только те слайды, которые зависят от выбранного мастера. Слайды, использующие другие мастера, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) слайда и инициализируйте его переопределённую тему. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой самый безопасный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного вида клонируйте исходный мастер в целевую презентацию и клонируйте слайд с этим мастером, используя [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) и [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) для слайда или темы макета и соответствующие методы effective‑data для форматных объектов, таких как [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) и [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). Эти API возвращают разрешённые значения после применения наследования и переопределений.