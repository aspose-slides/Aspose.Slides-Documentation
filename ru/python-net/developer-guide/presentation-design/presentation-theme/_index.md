---
title: Управление темами презентаций PowerPoint в Python
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/python-net/presentation-theme/
keywords:
- Тема PowerPoint
- тема презентации
- тема слайда
- установить тему
- изменить тему
- управлять темой
- цвет темы
- дополнительная палитра
- шрифт темы
- стиль темы
- эффект темы
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Управляйте темами презентаций в Aspose.Slides для Python через .NET, создавайте, настраивайте и конвертируйте файлы PowerPoint с единой фирменной стилистикой."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через свойство [Presentation.master_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/master_theme/). Презентация также может содержать переопределения темы на более низких уровнях. Майстер может переопределить тему презентации через [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/masterthememanager/override_theme/), макет может переопределить унаследованную тему через [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), а отдельный слайд может сделать то же самое. На практике эффективная тема для слайда разрешается по цепочке наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

В нижеприведённых разделах показаны наиболее распространённые сценарии работы с темой: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/) раскрывает свойства темы: [color_scheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/font_scheme/) и [format_scheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/format_scheme/). Просмотр этих коллекций перед их изменением особенно полезен, когда презентация поступает из внешнего источника, поскольку количество и содержание записей стилей могут различаться.

Следующий пример считывает основные свойства темы и выводит количество стилей фона, заливки, линий и эффектов, хранящихся в теме:

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

Если файл использует несколько мастеров, не следует предполагать, что у каждого слайда одинаковая эффективная тема. Просмотрите мастер, связанный со слайдом, и используйте рабочий процесс с эффективной темой, показанный далее в статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Заливки, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/schemecolor/). Когда вы изменяете соответствующую запись в [ColorScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/colorscheme/) темы, все объекты, которые всё ещё ссылаются на этот цвет темы, переоцениваются с учётом нового значения. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `ACCENT4`, меняет цвет `accent4` темы на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `ACCENT4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в фигуре, дальнейшие изменения `accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides раскрывает эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Основные цвета темы.

**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `ACCENT4`, применяет трансформации яркости к пяти из них и сохраняет результат:

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

Эти варианты остаются привязанными к цвету темы. Если `accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `accent4`.

### **Отображение значений `SchemeColor` в слоты `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/schemecolor/) использует `TEXT1`, `BACKGROUND1`, `TEXT2` и `BACKGROUND2`, тогда как [ColorScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/colorscheme/) раскрывает те же слоты темы как `dark1`, `light1`, `dark2` и `light2`. Соответствие фиксировано:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, которые динамически преобразуются из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для основного текста. Свойства [FontScheme.major](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/fontscheme/major/) и [FontScheme.minor](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/fontscheme/minor/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, можно использовать в форматировании текста:

* `+mn-lt` – Основной шрифт Latin (Minor Latin Font)
* `+mj-lt` – Шрифт заголовков Latin (Major Latin Font)
* `+mn-ea` – Основной шрифт East Asian (Minor East Asian Font)
* `+mj-ea` – Шрифт заголовков East Asian (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем он изменяет шрифты темы и сохраняет результат:

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

Заголовок следует за основным шрифтом, а основной текст – за вспомогательным шрифтом. Текст, у которого явно указано имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

{{% alert color="info" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Существует два распространённых сценария, они решают разные задачи.

### **Сохранить исходную тему при перемещении слайдов**

Если нужно переместить слайд в другую презентацию и сохранить его оригинальный дизайн, склонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/add_clone/), затем склонируйте слайд с помощью [SlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/add_clone/) и склонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

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

Это предпочтительный рабочий процесс, когда исходный слайд должен выглядеть одинаково в месте назначения. Простое клонирование содержимого на несвязанный целевой мастер может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) и [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) копируют три основных компонента темы в переопределение.

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

Это меняет тему, используемую этим слайдом, без изменения темы, наследуемой другими слайдами. Чтобы удалить локальное переопределение и вернуться к наследуемым значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/clear/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только у конкретного слайда нет собственного переопределения. Те же методы инициализации можно использовать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/layoutslidethememanager/) макета:

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

Используйте тему уровня мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн, переопределение макета – когда одной группе макетов нужен иной стиль, а переопределение слайда – только для настоящих исключений. Чрезмерное количество переопределений на уровне слайда усложняет предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Заливки фона темы хранятся в [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint может предлагать в интерфейсе больше вариантов фона, чем фактически определено в этой коллекции, поскольку UI может комбинировать заливки темы с цветовыми схемами и другими ссылками стилей.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Перед использованием стиля фона проверьте сохранённую коллекцию и текущий [Background.style_index](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/style_index/). `style_index` использует `0` для отсутствия заливки темы; положительные значения – ссылки на стили фона темы. Это отличается от индексации Python‑коллекции, где `[0]` означает первый элемент. Не предполагайте, что у каждой презентации одинаковое количество стилей фоновой заливки.

Следующий пример выводит количество доступных фоновых заливок, назначает ссылку на тему фона первому мастеру и сохраняет презентацию:

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

Видимый результат зависит от записи темы, на которую ссылается мастер, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона мастера может не изменить его. Используйте [Background.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/get_effective/), когда нужно узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не рассматривайте `style_index` как нулевой индекс коллекции. Также избегайте жёстко закодированных номеров стилей из одного файла и предположения, что они будут выглядеть так же в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/python-net/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FormatScheme.fill_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/line_styles/) и [FormatScheme.effect_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/effect_styles/). Обычные офисные темы часто включают три основных стиля, визуально соответствующие тонкому, умеренному и интенсивному форматированию, но код следует проверять каждую коллекцию, а не предполагать фиксированное количество записей.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

При доступе к этим коллекциям в Python индекс коллекции начинается с нуля: `[0]` – первый сохранённый стиль, `[2]` – третий. Индексы ссылок стилей у фигур – отдельная концепция, раскрытая через [IShapeStyle](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ishapestyle/). Изменение стиля темы влияет на фигуры, которые ссылаются на этот стиль; фигуры с прямым форматированием могут оставаться без изменений.

Следующий пример проверяет наличие необходимых записей стилей, изменяет первый линейный стиль, третий стиль заливки, включает внешнюю тень в третьем эффекте и сохраняет результат:

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

Для фигур, ссылающихся на эти слоты, первый линейный стиль темы становится красным, третий стиль заливки – сплошным тёмно‑зелёным, а третий эффект получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей каждая фигура использует и переопределяется ли прямое форматирование.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Для фона используйте [Background.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/get_effective/), а для заливки – [FillFormat.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fillformat/get_effective/).

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнения. Если проверять только [Presentation.master_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/master_theme/), можно пропустить переопределения мастера, макета, слайда или фигуры, меняющие окончательный вид.

## **FAQ**

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/slidethememanager/) слайда и инициализируйте его переопределяющую тему. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой способ наиболее безопасен для переноса темы из одной презентации в другую?**

При перемещении слайда и сохранении исходного внешнего вида клонируйте исходный мастер в целевую презентацию и клонируйте слайд с этим мастером, используя [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/add_clone/) и [SlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/add_clone/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) для темы слайда или макета и соответствующие методы эффективных данных для объектов формата, таких как [Background.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/get_effective/) и [FillFormat.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fillformat/get_effective/). Эти API возвращают разрешённые значения после применения наследования и переопределений.