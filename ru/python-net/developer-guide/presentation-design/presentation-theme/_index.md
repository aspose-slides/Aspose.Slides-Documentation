---
title: У管理ление темами презентаций PowerPoint в Python
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
description: "Управляйте темами презентаций в Aspose.Slides для Python через .NET, создавая, настраивая и конвертируя файлы PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения, а не хранят каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить многие объекты одновременно.

В Aspose.Slides тема уровня презентации доступна через свойство [Presentation.master_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/master_theme/). Презентация также может содержать переопределения темы на более низких уровнях. Master может переопределить тему презентации через [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/masterthememanager/override_theme/), макет может переопределить унаследованную тему через [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), и отдельный слайд может сделать то же самое. На практике эффективная тема для слайда определяется по этой цепочке наследования: тема презентации, переопределение master, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже показаны самые распространённые сценарии работы с темой: проверка темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Проверка темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/) раскрывает свойства темы: [color_scheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/font_scheme/) и [format_scheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/mastertheme/format_scheme/). Проверка этих коллекций перед их изменением особенно полезна, когда презентация поступает из внешнего источника, поскольку количество и содержание записей стиля могут различаться.

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

Если файл использует несколько master, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте master, связанный со слайдом, и используйте рабочий процесс с эффективной темой, описанный ниже, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Заливки, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/schemecolor/). Когда вы изменяете соответствующую запись в [ColorScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/colorscheme/) темы, все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт форму, использующую `ACCENT4`, меняет цвет темы `accent4` на красный, сохраняет презентацию, открывает её заново и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся связанным с `ACCENT4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет на форме, последующие изменения `accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint генерирует более светлые и более тёмные варианты из цвета темы, применяя преобразования цвета. Aspose.Slides раскрывает эти преобразования через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

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

Эти варианты остаются основанными на цветовом шаблоне темы. Если `accent4` позже изменится, преобразованные цвета будут пересчитаны из нового значения `accent4`.

### **Сопоставление значений `SchemeColor` со слотами `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/python-net/aspose.slides/schemecolor/) использует `TEXT1`, `BACKGROUND1`, `TEXT2` и `BACKGROUND2`, тогда как [ColorScheme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/colorscheme/) раскрывает те же слоты темы как `dark1`, `light1`, `dark2` и `light2`. Сопоставление фиксировано:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Это альтернативные имена одних и тех же слотов темы; они не являются значениями, динамически преобразуемыми из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для основного текста. Свойства [FontScheme.major](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/fontscheme/major/) и [FontScheme.minor](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/fontscheme/minor/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться при форматировании текста:

* `+mn-lt` – Шрифт тела Latin (Minor Latin Font)
* `+mj-lt` – Шрифт заголовка Latin (Major Latin Font)
* `+mn-ea` – Шрифт тела East Asian (Minor East Asian Font)
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

Заголовок следует основному шрифту, а основной текст – вспомогательному шрифту. Текст, в котором явно указано имя шрифта вместо идентификатора темы, не переключится автоматически при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Существует два распространённых рабочего процесса, решающих разные задачи.

### **Сохранение исходной темы при перемещении слайдов**

Если необходимо переместить слайд в другую презентацию, сохранив его оригинальный дизайн, клонируйте исходный master в целевую презентацию с помощью [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/add_clone/), затем клонируйте слайд с помощью [SlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/add_clone/) и клонированного master. Это переносит master, его макеты и связанную тему вместе.

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

Это предпочтительный процесс, когда исходный слайд должен выглядеть идентично в целевом файле. Простое клонирование содержимого на несвязанный master может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применение значений темы к существующему слайду**

Если целевой слайд должен оставаться на текущем master и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) и [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) копируют три основных компонента темы в переопределение.

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

Это меняет тему, используемую этим слайдом, не затрагивая тему, унаследованную другими слайдами. Чтобы удалить локальное переопределение и вернуть унаследованные значения, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/overridetheme/clear/).

### **Применение переопределения темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно вызвать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/layoutslidethememanager/) макета:

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

Используйте тему уровня master или презентации, когда многие макеты и слайды должны делить один базовый дизайн; используйте переопределение макета, когда одной группе макетов требуется иной стиль; и переопределение слайда — только для истинных исключений. Чрезмерное количество переопределений на уровне слайда усложняет предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Заливки фона темы хранятся в [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint может показывать в пользовательском интерфейсе больше вариантов фона, чем реально хранится в этой коллекции, потому что UI может комбинировать заливки темы с цветовыми схемами и другими ссылками стилей.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Прежде чем использовать стиль фона, проверьте хранимую коллекцию и текущий [Background.style_index](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/style_index/). `style_index` использует `0` для отсутствия тематической заливки; положительные значения являются ссылками на стили фона темы. Это отличается от обычного индекса Python‑коллекции, где `[0]` обозначает первый элемент. Не предполагайте, что у каждой презентации одинаковое количество стилей фоновых заливок.

Следующий пример сообщает количество доступных фоновых заливок, назначает тематическую ссылку на фон первому master и сохраняет презентацию:

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

Видимый результат зависит от записи темы, на которую ссылается master, и от любых переопределений фона на уровне макета или слайда. Если у слайда задан собственный фон, изменение только фона master может не затронуть этот слайд. Используйте [Background.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/get_effective/), когда нужно узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не воспринимайте `style_index` как нуль‑базовый индекс коллекции. Также избегайте «жёсткого» кодирования номера стиля из одного файла и предположения, что он будет выглядеть одинаково в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона смотрите [Presentation Background](/slides/ru/python-net/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FormatScheme.fill_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/line_styles/) и [FormatScheme.effect_styles](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/formatscheme/effect_styles/). Типичные офисные темы часто включают три основных стиля, визуально соответствующие «тонким», «средним» и «интенсивным» форматам, но код должен проверять каждую коллекцию, а не полагаться на фиксированное количество записей.

![Тонкие, средние и интенсивные эффекты темы, применённые к одной форме](presentation-design_10.png)

При доступе к этим коллекциям в Python индексы являются нуль‑базовыми: `[0]` – первый записанный стиль, `[2]` – третий. Индексы ссылок стилей формы – отдельная концепция, раскрытая через [IShapeStyle](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ishapestyle/). Изменение стиля темы влияет на формы, которые ссылаются на этот стиль; формы с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие необходимых записей стилей, меняет первый стиль линии, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

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

Для форм, ссылающихся на эти слоты, первый стиль линии темы становится красным, третий стиль заливки темы становится сплошным лесным зелёным, а третий стиль эффекта получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей использует каждая форма и перекрывает ли прямое форматирование тему.

![Стили эффектов темы после изменения линии, заливки и настроек тени](presentation-design_11.png)

## **Чтение эффективных значений темы**

Сырые объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или форма действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Для фона используйте [Background.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/get_effective/), а для заливки – [FillFormat.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fillformat/get_effective/).

Следующий пример читает эффективную тему, фон и первую заливку формы со слайда:

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнения. Если проверять только [Presentation.master_theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/master_theme/), можно упустить переопределения master, макета, слайда или формы, меняющие окончательный вид.

## **FAQ**

**Можно ли применить тему к отдельному слайду без изменения master?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/slidethememanager/) слайда и инициализируйте его переопределённую тему. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Как безопаснее всего перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного вида клонируйте исходный master в целевую презентацию и клонируйте слайд с этим master, используя [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslidecollection/add_clone/) и [SlideCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slidecollection/add_clone/). Это сохраняет master, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) для темы слайда или макета и соответствующие методы получения эффективных данных для форматных объектов, таких как [Background.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/background/get_effective/) и [FillFormat.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fillformat/get_effective/). Эти API возвращают разрешённые значения после применения наследования и переопределений.