---
title: Управление темами презентаций в Python через Java
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/python-java/presentation-theme/
keywords:
- тема PowerPoint
- тема презентации
- тема слайда
- установить тему
- изменить тему
- управлять темой
- внешняя тема
- THMX
- цвет темы
- дополнительная палитра
- шрифт темы
- стиль темы
- эффект темы
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Управляйте темами презентаций в Aspose.Slides для Python через Java, создавайте, настраивайте и конвертируйте файлы PowerPoint с согласованным брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, поддерживающие темы, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов одновременно.

В Aspose.Slides тема уровня презентации доступна через [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getMasterTheme). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterthememanager/#getOverrideTheme), в то время как макет или отдельный слайд может переопределять унаследованную тему через [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). На практике эффективная тема для слайда формируется по этой цепочке наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже представлены наиболее распространённые сценарии работы с темами: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Осмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/mastertheme/) предоставляет доступ к схеме цветов, схеме шрифтов и схеме форматов темы через методы [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/mastertheme/#getFontScheme) и [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/mastertheme/#getFormatScheme). Осмотр этих коллекций перед их изменением особенно полезен, когда презентация поступает из внешнего источника, поскольку количество и содержимое записей стилей могут различаться.

Следующий пример читает основные свойства темы и сообщает, сколько стилей фона, заливки, линии и эффектов хранится в теме:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

Если файл использует несколько мастеров, не следует полагать, что каждый слайд имеет одну и ту же эффективную тему. Осмотрите мастер, связанный со слайдом, и используйте сценарий работы с эффективной темой, показанный ниже, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Заполнения, линии и текст, поддерживающие темы, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/schemecolor/). При изменении соответствующей записи в [ColorScheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/colorscheme/), все объекты, которые по‑прежнему ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт форму, использующую `Accent4`, меняет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её вновь и выводит эффективный цвет заливки:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

Поскольку прямоугольник остаётся связанным с `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в форме, дальнейшие изменения `Accent4` уже не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя цветовые трансформации. Aspose.Slides предоставляет эти трансформации через перечисление [ColorTransformOperation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные варианты, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** – Основные цвета темы.  
**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет к пяти из них преобразования яркости и сохраняет результат:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Эти варианты остаются основанными на цвете темы. Если позже `Accent4` изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Отображение значений `SchemeColor` в ячейки `ColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [ColorScheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/colorscheme/) представляет те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Соответствие фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, которые динамически преобразуются из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор шрифтов для тела текста. Методы [FontScheme.getMajor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontscheme/#getMajor) и [FontScheme.getMinor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontscheme/#getMinor) предоставляют доступ к этим наборам.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться при форматировании текста:

* `+mn-lt` – шрифт тела Latin (Minor Latin Font)
* `+mj-lt` – шрифт заголовка Latin (Major Latin Font)
* `+mn-ea` – шрифт тела East Asian (Minor East Asian Font)
* `+mj-ea` – шрифт заголовка East Asian (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку тела, использующую вспомогательный латинский шрифт темы. Затем он меняет шрифты темы и сохраняет результат:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Заголовок следует за основным шрифтом, а текст тела – за вспомогательным. Текст, в котором явно указано имя шрифта вместо идентификатора темы, не переключится автоматически при изменении схемы шрифтов темы.

Основные и вспомогательные наборы шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. раздел [Script‑Specific Theme Fonts](/slides/ru/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/python-java/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже приведены сценарии, решающие разные задачи, связанные с темами.

### **Применить внешнюю тему к слайдам, зависящим от мастера**

Используйте [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides), когда у вас есть файл темы PowerPoint (`.thmx`) и необходимо изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation.getMasters](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getMasters), представленной классом [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslidecollection/), и передайте путь к файлу темы методу.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.  
1. Применяет внешнюю тему к новому мастеру.  
1. Присваивает новый мастер всем слайдам, ранее зависевшим от выбранного мастера.  
1. Возвращает созданный [MasterSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/).

Следующий пример применяет внешнюю тему к слайдам, зависящим от первого мастера, и сохраняет презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Недействительная, повреждённая или неподдерживаемая тема может вызвать [PptxReadException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxreadexception/). Проверяйте пути, введённые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Пере‑назначаются только слайды, зависившие от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, зависящие от темы, разрешаются по внешней теме. Прямо назначенные цвета, шрифты, заливки и другие явные форматы могут остаться без изменений. Переопределения на уровне макета и слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, отсутствующие в среде выполнения. Для согласованного отображения и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/python-java/custom-font/), или настройте [font substitution](/slides/ru/python-java/font-substitution/).

Это прямой сценарий уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровне слайда или макета.

### **Применить разные внешние темы в презентации с несколькими мастерами**

Когда нужный мастер заранее неизвестен, получите его из представительного слайда через [Slide.getLayoutSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getLayoutSlide) и [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getMasterSlide). Сохраните оригинальные ссылки на мастера перед применением тем, поскольку каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух разделов, определяет их мастера и применяет различную внешнюю тему к каждой группе:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Первый вызов затрагивает только слайды, зависящие от `first_group_master`, второй – только слайды, зависящие от `second_group_master`. Слайды, принадлежащие другим мастерам, не меняются.

### **Сохранить исходную тему при перемещении слайдов**

Если необходимо переместить слайд в другую презентацию, сохранив его исходный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslidecollection/#addClone), а затем клонируйте слайд с помощью [SlideCollection.addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addClone) и склонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Это предпочтительный сценарий, когда исходный слайд должен выглядеть одинаково в назначении. Простое копирование содержимого на несвязанный мастер получателя может изменить цвета, шрифты, фоны и эффекты, зависящие от темы.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) и [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) копируют три основных компонента темы в переопределение.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Это меняет тему, используемую этим слайдом, без изменения темы, унаследованной другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.clear](https://reference.aspose.com/slides/ru/python-java/aspose.slides/overridetheme/#clear).

### **Применить переопределение темы к макету**

Переопределение уровня макета действует на слайды, использующие этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно вызвать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslidethememanager/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Используйте тему мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета, когда одной семье макетов нужен иной стиль; и переопределение слайда только для истинных исключений. Чрезмерные переопределения уровня слайда усложняют предсказание последствий глобальных изменений темы.

## **Обновление стилей фона темы**

Фоновые заливки темы хранятся в [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ru/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint может показывать в UI больше вариантов фона, чем фактически хранится в этой коллекции, так как UI может комбинировать тематические заливки с цветовыми схемами и другими ссылками стилей.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием стиля фона осмотрите сохранённую коллекцию и текущий [Background.getStyleIndex](https://reference.aspose.com/slides/ru/python-java/aspose.slides/background/#getStyleIndex). Индекс `0` означает отсутствие тематической заливки; положительные значения – ссылки на стили фоновой темы. Это отличается от индексации самой коллекции, где `get_Item(0)` обозначает первый элемент. Не предполагаете, что у всех презентаций одинаковое количество стилей фоновых заливок.

Следующий пример сообщает количество доступных фоновых заливок, назначает тематическую ссылку фона первому мастеру и сохраняет презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Видимый результат зависит от записи темы, на которую указывает мастер, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фона мастера может не повлиять на него. Используйте [Background.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/background/#getEffective), когда нужно узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не воспринимайте индекс стиля как нулевой индекс коллекции. Также избегайте «жёсткого» кодирования номера стиля из одного файла в предположении, что он будет выглядеть одинаково в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. раздел [Presentation Background](/slides/ru/python-java/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема форматов темы содержит отдельные коллекции заливок, линий и эффектов, доступные через [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ru/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ru/python-java/aspose.slides/formatscheme/#getLineStyles) и [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ru/python-java/aspose.slides/formatscheme/#getEffectStyles). Обычные офисные темы часто включают три основных стиля, визуально соответствующие «деликатному», «умеренному» и «интенсивному» форматированию, но код должен проверять каждую коллекцию, а не полагаться на фиксированное количество.

![Деликатные, умеренные и интенсивные эффекты темы, применённые к одной и той же фигуре](presentation-design_10.png)

При доступе к этим коллекциям в Python через Java индекс коллекции начинается с нуля: `get_Item(0)` – первая сохранённая стилизация, `get_Item(2)` – третья. Индексы ссылок стиля фигуры – отдельная концепция, доступная через [ShapeStyle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapestyle/). Изменение стилистической записи темы затрагивает фигуры, ссылающиеся на эту запись; фигуры с прямым форматированием могут оставаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, меняет первый стиль линии, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Для фигур, ссылающихся на эти слоты, первый стиль линии темы станет красным, третий стиль заливки – сплошным тёмно‑зелёным, а третий стиль эффекта получит внешнюю тень с отступом 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стиля использует каждая фигура и не переопределено ли её прямое форматирование.

![Стили эффектов темы после изменения линии, заливки и параметров тени](presentation-design_11.png)

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть задана непосредственно объекту или наследоваться от абзаца, макета, мастера, стиля темы или другого уровня форматирования. Вызовите [FillFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#getEffective), чтобы преобразовать эту иерархию в неизменяемые данные эффективной заливки. Сначала проверьте `getFillType` у полученного объекта. Только если значение `FillType.Solid`, читайте свойства сплошной заливки.

Для сплошной заливки `getSolidFillColor` возвращает окончательное значение RGB после применения наследования, поиска в теме и цветовых трансформаций. `getSolidFillSchemeColor` возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/schemecolor/), например `Text1` или `Accent6`. Значение `SchemeColor.NotDefined` означает, что эффективная сплошная заливка не основана на цветовом слоте схемы. В сценарии, где заливки либо являются цветовыми слотами темы, либо прямыми RGB‑цветами, это значение указывает на прямую RGB‑заливку.

Не используйте локальное значение [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/colorformat/#getSchemeColor) в качестве единственного критерия классификации заливки. Например, у части текста может не быть локально определённого цветового слота (значение `NotDefined`), но его эффективная заливка наследует цвет темы и разрешается как `Text1` или `Accent6`. Напротив, `getSolidFillSchemeColor` сообщает, какой логический слот темы породил эффективный цвет, но не указывает, откуда этот слот пришёл – из объекта, абзаца, макета, мастера или другого уровня.

Следующий пример загружает презентацию, проверяет заливки фигур и текстовых фрагментов, выводит каждое окончательное RGB‑значение и соответствующий цветовой слот, а также отмечает сплошные заливки, которые не будут отслеживать изменения цветовых слотов темы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

Ветвь `NotDefined` предоставляет список сплошных заливок, которые не реагируют на изменения цветовых слотов темы. Проверьте эти объекты, когда презентация должна соответствовать новой фирменной палитре. Выведенный RGB‑цвет всё равно показывает текущий внешний вид, а значение схемы объясняет, связано ли он с темой.

Объекты эффективного формата – это «снимки». После изменения темы презентации, переопределения темы или любого унаследованного форматирования вызовите `getEffective` ещё раз и прочитайте новый объект эффективных данных перед сравнением или выводом цветов.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после разрешения наследования и локальных переопределений. Для слайда вызывайте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Для фона используйте [Background.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/background/#getEffective), а для заливки – [FillFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#getEffective).

Следующий пример читает эффективную тему, фон и заливку первой фигуры со слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

Используйте эффективные данные для диагностики отрисовки, валидации и сравнения. Если вы проверяете только [Presentation.getMasterTheme](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getMasterTheme), вы можете упустить переопределения мастера, макета, слайда или фигуры, которые меняют окончательный внешний вид.

## **FAQ**

**Применяет ли внешняя тема все слайды в презентации?**

Нет. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) переопределяет только те слайды, которые зависят от выбранного мастера. Слайды, использующие другие мастера, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду, не меняя мастер?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой самый надёжный способ перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного внешнего вида клонируйте исходный мастер в целевую презентацию и клонируйте слайд с этим мастером, используя [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslidecollection/#addClone) и [SlideCollection.addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addClone). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) для темы слайда или макета и соответствующие методы получения эффективных данных для объектов формата, такие как [Background.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/background/#getEffective) и [FillFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#getEffective). Эти API возвращают разрешённые значения после применения наследования и переопределений.