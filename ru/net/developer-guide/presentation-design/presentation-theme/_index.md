---
title: Управление темами презентаций в .NET
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/net/presentation-theme/
keywords:
- Тема PowerPoint
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
- .NET
- C#
- Aspose.Slides
description: "Основные темы презентаций в Aspose.Slides для .NET для создания, настройки и конвертации файлов PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может обновить множество объектов сразу.

В Aspose.Slides тема уровня презентации доступна через свойство [Presentation.MasterTheme](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/mastertheme/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/masterthememanager/overridetheme/), макет может переопределять унаследованную тему через [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), и отдельный слайд может делать то же самое. На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже перечислены наиболее распространённые сценарии работы с темой: проверка темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Осмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/mastertheme/) предоставляет доступ к [ColorScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/mastertheme/fontscheme/) и [FormatScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/mastertheme/formatscheme/). Проверка этих коллекций до их изменения особенно полезна, когда презентация поступает из внешнего источника, поскольку количество и содержимое записей стилей могут различаться.

Следующий пример считывает основные свойства темы и сообщает, сколько стилей фона, заливки, линий и эффектов хранится в теме:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте мастер, связанный со слайдом, и используйте рабочий процесс с эффективной темой, показанный далее в статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Тема‑зависимые заливки, линии и текст могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/net/aspose.slides/schemecolor/). При изменении соответствующей записи в [IColorScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/icolorscheme/) все объекты, всё ещё ссылающиеся на этот цвет темы, будут разрешены к новому значению. Объекты, использующие прямой RGB‑цвет, не изменятся при обновлении цвета темы.

Следующий сквозной пример создаёт фигуру, использующую `Accent4`, меняет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Поскольку прямоугольник остаётся привязанным к `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в фигуре, дальнейшие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и более тёмные варианты из цвета темы, применяя преобразования цветов. Aspose.Slides раскрывает эти преобразования через [ColorTransformOperation](https://reference.aspose.com/slides/ru/net/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и более тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** – Основные цвета темы.  
**2** – Более светлые и более тёмные варианты, полученные из основных цветов темы.

Следующий пример создаёт шесть прямоугольников на основе `Accent4`, применяет к пяти из них преобразования яркости и сохраняет результат:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Эти варианты остаются основанными на цвете темы. Если `Accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Сопоставление значений `SchemeColor` слотам `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/net/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/icolorscheme/) представляет те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, динамически преобразуемыми из одной формы в другую.

## **Изменение шрифтов темы**

Набор шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор для основного текста. Свойства [FontScheme.Major](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/fontscheme/major/) и [FontScheme.Minor](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/fontscheme/minor/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться в форматировании текста:

* `+mn-lt` – основной шрифт тела Latin (Minor Latin Font)
* `+mj-lt` – шрифт заголовка Latin (Major Latin Font)
* `+mn-ea` – основной шрифт East Asian (Minor East Asian Font)
* `+mj-ea` – шрифт заголовка East Asian (Major East Asian Font)

Следующий пример создаёт один заголовок, использующий основной латинский шрифт темы, и одну строку основного текста, использующую вспомогательный латинский шрифт темы. Затем он меняет шрифты темы и сохраняет результат:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Заголовок следует за основным шрифтом, а основной текст — за вспомогательным шрифтом. Текст, у которого указано явное имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении набора шрифтов темы.

Основные и вспомогательные коллекции шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и тамильский. Чтобы просмотреть, добавить, заменить или удалить эти сопоставления, см. [Script-Specific Theme Fonts](/slides/ru/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения более подробной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/net/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Ниже приведённые рабочие процессы решают разные задачи, связанные с темами.

### **Применить внешний шаблон к слайдам, зависящим от мастера**

Используйте [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/), когда у вас есть файл темы PowerPoint (`.thmx`) и нужно изменить стиль всех слайдов, зависящих от конкретного мастера. Выберите мастер из коллекции [Presentation.Masters](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/masters/), реализующей [IMasterSlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection/), и передайте путь к файлу темы в метод.

Метод выполняет следующие операции:

1. Создаёт новый мастер‑слайд на основе выбранного мастера.  
2. Применяет внешний шаблон к новому мастеру.  
3. Назначает новый мастер всем слайдам, которые ранее зависели от выбранного мастера.  
4. Возвращает вновь созданный [IMasterSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/).

Следующий пример применяет внешний шаблон к слайдам, зависящим от первого мастера, сохраняет презентацию и открывает результат снова:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Недопустимая, повреждённая или неподдерживаемая тема может вызвать [PptxException](https://reference.aspose.com/slides/ru/net/aspose.slides/pptxexception/) или один из её подклассов, связанных с форматом. Проверяйте пути, вводимые пользователями, обрабатывайте ошибки доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Переназначаются только слайды, зависимые от выбранного мастера. Слайды, связанные с другими мастерами, сохраняют свои текущие мастера и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, зависящие от темы, будут разрешены в соответствии с внешним шаблоном. Прямо назначенные цвета, шрифты, заливки и другая явная форматировка могут остаться без изменений. Переопределения уровня макета и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового мастера.

Тема может ссылаться на шрифты, отсутствующие в среде выполнения. Для согласованного рендеринга и экспорта установите требуемые шрифты, предоставьте их через [custom font sources](/slides/ru/net/custom-font/), либо настройте [font substitution](/slides/ru/net/font-substitution/).

Это прямой рабочий процесс уровня мастера: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы уровня слайда или макета.

### **Применить разные внешние темы в презентации с несколькими мастерами**

Когда нужный мастер неизвестен заранее, получите его из представительного слайда через [ISlide.LayoutSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/layoutslide/) и [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/masterslide/). Сохраните оригинальные ссылки на мастеров перед применением любых тем, так как каждый вызов создаёт новый мастер в презентации.

Следующий пример использует слайды из двух разделов, чтобы найти их мастера, и применяет к каждой группе свой внешний шаблон:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

Первый вызов затрагивает только слайды, зависящие от `firstGroupMaster`, а второй — только слайды, зависящие от `secondGroupMaster`. Слайды, принадлежащие другим мастерам, не меняются.

### **Сохранить исходную тему при перемещении слайдов**

Если нужно переместить слайд в другую презентацию, сохранив его исходный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection/addclone/), затем клонируйте слайд с помощью [ISlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/addclone/) и клонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Этот подход предпочтителен, когда исходный слайд должен выглядеть одинаково в целевом документе. Простое клонирование содержимого на несвязанный мастер получателя может изменить цвета, шрифты, фон и эффекты, управляемые темой.

### **Применить значения темы к существующему слайду**

Если целевой слайд должен оставаться на текущем мастере и макете, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/overridetheme/initfontschemefrom/) и [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/overridetheme/initformatschemefrom/) копируют три основных компонента темы в переопределение.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Это меняет тему, используемую этим слайдом, без изменения темы, унаследованной другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.Clear](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/overridetheme/clear/).

### **Применить переопределение темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если у конкретного слайда нет собственного переопределения. Те же методы инициализации могут быть использованы через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/layoutslidethememanager/) макета:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Используйте тему мастера или презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета — когда одной группе макетов нужен иной стиль; а переопределение слайда — только для истинных исключений. Чрезмерные переопределения уровня слайда усложняют предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Заливки фоновых стилей темы хранятся в [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint может показывать в интерфейсе больше вариантов фоновых стилей, чем фактически хранится в этой коллекции, поскольку UI может комбинировать заливки темы с цветовыми схемами темы и другими ссылками на стили.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Прежде чем использовать стиль фона, проверьте хранимую коллекцию и текущий [Background.StyleIndex](https://reference.aspose.com/slides/ru/net/aspose.slides/background/styleindex/). `StyleIndex` использует `0` для отсутствия тематической заливки; положительные значения — ссылки на стили фоновой темы. Это отличается от индексации .NET‑коллекции, где `[0]` означает первый сохранённый элемент. Не полагайтесь на то, что у каждой презентации одинаковое количество стилей фоновых заливок.

Следующий пример выводит количество доступных фоновых заливок, назначает тематическую ссылку на фон первому мастеру и сохраняет презентацию:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Видимый результат зависит от записи темы, на которую ссылается мастер, а также от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фонового стиля мастера может не затронуть этот слайд. Используйте [Background.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/background/geteffective/) при необходимости узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не рассматривайте `StyleIndex` как нулевой индекс коллекции. Также избегайте жёстко фиксировать номер стиля из одного файла и предполагать, что в другом файле он будет выглядеть одинаково; определения стилей темы специфичны для каждой презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/net/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FillStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/linestyles/) и [EffectStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/effectstyles/). Типичные офисные темы часто включают три основных стиля, визуально соответствующие «нежному», «умеренному» и «интенсивному» форматированию, но код должен проверять каждую коллекцию, а не предполагать фиксированное количество.

![Тонкие, умеренные и интенсивные эффекты темы, применённые к одной фигуре](presentation-design_10.png)

При работе с этими коллекциями в C# индекс коллекции начинается с нуля: `[0]` — первый сохранённый стиль, `[2]` — третий. Индексы ссылок на стили в фигурах — отдельная концепция, открытая через [IShapeStyle](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapestyle/). Изменение стиля темы влияет на фигуры, которые ссылаются на этот стиль; фигуры с прямым форматированием могут остаться без изменений.

Следующий пример проверяет наличие необходимых записей стилей, меняет первый стиль линии, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Для фигур, ссылающихся на эти слоты, первый стиль линии темы становится красным, третий стиль заливки темы — сплошным тёмно‑зёлёным, а третий стиль эффекта получает внешнюю тень с отступом 10 пунктов. Точный визуальный результат всё ещё зависит от того, какие слоты стилей каждая фигура использует и переопределяется ли прямое форматирование.

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть сохранена непосредственно в объекте или унаследована от абзаца, макета, мастера, стиля темы или другого уровня форматирования. Вызов [IFillFormat.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformat/geteffective/) преобразует эту иерархию в неизменяемый [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformateffectivedata/). Сначала проверьте [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformateffectivedata/filltype/). Только когда он равен `FillType.Solid`, следует читать свойства сплошной заливки.

Для сплошной заливки [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) возвращает окончательное отрисованное значение RGB после наследования, поиска по теме и применения цветовых преобразований. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/ru/net/aspose.slides/schemecolor/), например `Text1` или `Accent6`. Значение `SchemeColor.NotDefined` означает, что эффективная сплошная заливка не основана на цветовом слоте схемы. В рабочем процессе, где заливки либо являются цветовыми слотами темы, либо прямыми RGB‑цветами, это значение идентифицирует прямую RGB‑заливку.

Не используйте локальное значение [IColorFormat.SchemeColor](https://reference.aspose.com/slides/ru/net/aspose.slides/icolorformat/schemecolor/) единственно для классификации заливки. Например, часть текста может не иметь локального определения цветового слота, поэтому её локальное значение — `NotDefined`, в то время как её эффективная заливка наследует цвет темы и разрешается к `Text1` или `Accent6`. С другой стороны, `SolidFillSchemeColor` показывает, какой логический слот темы дал итоговый цвет, но не указывает, откуда именно этот слот пришёл — от объекта, абзаца, макета, мастера или другого уровня иерархии.

Следующий пример загружает презентацию, проверяет заливки фигур и заливки фрагментов текста, выводит каждое окончательное RGB‑значение и связанный цвет схемы, а также помечает сплошные заливки, которые не будут отслеживать изменения цвета темы:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

Ветвь `NotDefined` предоставляет список аудита сплошных заливок, которые не будут реагировать на изменения слотов цветовой схемы. Просмотрите эти объекты, когда необходимо, чтобы презентация соответствовала новой брендовой палитре. Отчётное RGB‑значение всё ещё отображает текущий внешний вид, а значение схемы объясняет, связано ли оно с темой.

Эффективные объекты формата — это снимки. После изменения темы презентации, переопределения темы или любого наследуемого форматирования вновь вызовите `GetEffective` и прочитайте новый объект `IFillFormatEffectiveData` перед сравнением или выводом цветов.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Для фона используйте [Background.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/background/geteffective/), а для заливки — [FillFormat.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/geteffective/).

Следующий пример читает эффективную тему, фон и первую заливку фигуры со слайда:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Используйте эффективные данные для диагностики рендеринга, проверки и сравнения. Если проверять только [Presentation.MasterTheme](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/mastertheme/), можно упустить переопределения мастера, макета, слайда или фигуры, меняющие окончательный вид.

## **FAQ**

**Применение внешней темы влияет на каждый слайд презентации?**

Нет. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) переназначает только слайды, зависящие от выбранного мастера. Слайды, использующие другие мастеры, сохраняют свои текущие темы.

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой способ самый безопасный для переноса темы из одной презентации в другую?**

При перемещении слайда и сохранении его исходного вида клонируйте исходный мастер в целевую презентацию и клонируйте слайд с этим мастером, используя [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection/addclone/) и [ISlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/addclone/). Это сохраняет мастер, макеты и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) для темы слайда или макета и соответствующие методы получения эффективных данных для форматных объектов, таких как [Background.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/background/geteffective/) и [FillFormat.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/geteffective/). Эти API возвращают разрешённые значения после применения наследования и переопределений.