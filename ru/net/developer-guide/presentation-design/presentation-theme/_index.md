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
description: "Мастер‑темы презентаций в Aspose.Slides для .NET, позволяющие создавать, настраивать и конвертировать файлы PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может одновременно обновить множество объектов.

В Aspose.Slides тема уровня презентации доступна через свойство [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/). Презентация также может содержать переопределения темы на более низких уровнях. master может переопределять тему презентации через [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/), layout может переопределять унаследованную тему через [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), и отдельный слайд может делать то же самое. На практике эффективная тема для слайда определяется через эту цепочку наследования: тема презентации, переопределение master, переопределение layout и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

В следующих разделах показаны самые распространённые сценарии работы с темой: просмотр темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после применения наследования и переопределений.

## **Просмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) раскрывает [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) и [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/). Просмотр этих коллекций перед их изменением особенно полезен, когда презентация поступает из внешнего источника, поскольку количество и содержание записей стилей могут различаться.

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

Если файл использует несколько master‑ов, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Просмотрите master, связанный со слайдом, и используйте рабочий процесс эффективной темы, описанный далее в статье, когда могут присутствовать переопределения layout или слайда.

## **Изменение цветов темы**

Заполнения, линии и текст, учитывающие тему, могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/). Когда вы изменяете соответствующую запись в [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не меняются при обновлении цвета темы.

Следующий сквозной пример создаёт форму, использующую `Accent4`, меняет цвет `Accent4` темы на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся привязан к `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цветовой шаблон на прямой цвет в форме, последующие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint генерирует более светлые и более тёмные варианты из цветовой схемы темы, применяя трансформации цвета. Aspose.Slides предоставляет эти трансформации через [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и тёмные цвета, полученные из дополнительной палитры](additional-palette-colors.png)

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

Эти варианты остаются привязанными к цветовому шаблону темы. Если `Accent4` изменится позже, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Сопоставление значений `SchemeColor` слотам `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Соответствие фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, которые динамически преобразуются из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит основной набор шрифтов для заголовков и вспомогательный набор для основного текста. Свойства [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) и [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) раскрывают эти наборы.

Идентификаторы шрифтов темы, совместимые с PowerPoint, могут использоваться в форматировании текста:

* `+mn‑lt` – Основной шрифт тела Latin (Minor Latin Font)
* `+mj‑lt` – Шрифт заголовка Latin (Major Latin Font)
* `+mn‑ea` – Основной шрифт East Asian (Minor East Asian Font)
* `+mj‑ea` – Шрифт заголовка East Asian (Major East Asian Font)
* `+mn‑cs` – Основной шрифт Complex Script (Minor Complex Script Font)
* `+mj‑cs` – Шрифт заголовка Complex Script (Major Complex Script Font)

Следующий пример создаёт один заголовок, использующий основной шрифт Latin темы, и одну строку основного текста, использующую вспомогательный шрифт Latin. Затем меняет шрифты темы и сохраняет результат:

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

Заголовок следует за основным шрифтом, а основной текст – за вспомогательным. Текст, у которого явно указано имя шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные коллекции шрифтов также могут содержать сопоставления шрифтов для отдельных систем письма, таких как кириллическая, арабская, японская, грузинская и таанская. Для просмотра, добавления, замены или удаления этих сопоставлений см. [Script‑Specific Theme Fonts](/slides/ru/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения более подробной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/net/powerpoint-fonts/).
{{% /alert %}}

### **Разрешение ссылок на шрифты темы**

При инспекции текста [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) может содержать ссылку на тему, например `+mn‑lt`, вместо имени семейства шрифтов. Вызовите [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) с соответствующим [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) для разрешения этой ссылки. Префиксы `+mj` и `+mn` выбирают основные и вспомогательные наборы шрифтов; суффиксы `-lt`, `-ea` и `-cs` выбирают их Latin, East Asian и Complex Script шрифты соответственно.

Получите эффективную тему через [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) у объекта, к которому применяется тема рассматриваемого текста. Для обычного текста на слайде используйте `slide.CreateThemeEffective()`, чтобы контекст включал унаследованную тему слайда и локальные переопределения. При инспекции самого layout или master используйте их собственную эффективную тему. Не предполагайте, что тема первого master применяется ко всем слайдам.

Следующий пример создаёт часть текста, явно ссылающуюся на вспомогательный шрифт Latin. Он инициализирует схему шрифтов слайда через [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) и задаёт основные и вспомогательные семейства Latin как `Arial` и `Calibri`, делая результат воспроизводимым без входного файла.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

Вывод: `+mn‑lt -> Calibri`, за которым следует `Verdana -> Verdana`. Сохранённая ссылка остаётся неизменной, в то время как явное семейство шрифта возвращается как есть. Если бы часть использовала `+mj‑lt`, она бы разрешилась в `Arial` в этой теме.

Разрешение ссылки темы определяет семейство шрифтов, указанное в теме. Оно не проверяет наличие шрифта и не определяет фактический файл шрифта, используемый после подстановки или замены глифов во время рендеринга. См. [Font Selection Sequence](/slides/ru/net/font-selection-sequence/) и [Font Substitution](/slides/ru/net/font-substitution/) для этих отдельных шагов.

## **Копирование или применение темы**

Ниже представлены различные рабочие процессы решения проблем, связанных с темами.

### **Применение внешней темы к слайдам, зависящим от master‑а**

Используйте [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/), когда у вас есть файл темы PowerPoint (`.thmx`) и нужно переоформить каждый слайд, зависящий от конкретного master‑а. Выберите master из коллекции [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/), которая реализует [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/), и передайте путь к файлу темы в метод.

Метод выполняет следующие операции:

1. Создаёт новый master‑slide на основе выбранного master‑а.  
2. Применяет внешнюю тему к новому master‑у.  
3. Присваивает новый master всем слайдам, ранее зависящим от выбранного master‑а.  
4. Возвращает вновь созданный [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/).

Следующий пример применяет внешнюю тему к слайдам, зависящим от первого master‑а, сохраняет презентацию и открывает результат:

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

Недопустимая, повреждённая или неподдерживаемая тема может вызвать [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) или один из её подклассов, связанных с форматом. Проверяйте пути, предоставленные пользователями, обрабатывайте сбои доступа к файловой системе и сохраняйте презентацию только после успешного применения темы.

Только слайды, зависевшие от выбранного master‑а, пере‑назначаются. Слайды, связанные с другими master‑ами, сохраняют свои существующие master‑ы и темы. Цвета, шрифты, заливки, линии, фоны и эффекты, учитывающие тему, разрешаются относительно внешней темы. Прямо назначенные цвета, шрифты, заливки и другие явные форматы могут оставаться неизменными. Переопределения уровня layout и уровня слайда также могут иметь приоритет над значениями, унаследованными от нового master‑а.

Тема может ссылаться на шрифты, отсутствующие в среде выполнения. Для согласованного рендеринга и экспорта установите необходимые шрифты, предоставьте их через [custom font sources](/slides/ru/net/custom-font/), либо настройте [font substitution](/slides/ru/net/font-substitution/).

Это прямой рабочий процесс уровня master: метод принимает путь к файлу `.thmx` и не требует ручного создания переопределений темы на уровнях слайда или layout.

### **Применение разных внешних тем в многомастеровой презентации**

Когда конкретный master неизвестен заранее, получите его из представительного слайда через [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) и [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/). Сохраните исходные ссылки на master‑ы перед применением тем, так как каждый вызов создаёт новый master в презентации.

Следующий пример использует слайды из двух разделов, определяет их master‑ы и применяет к каждой группе свою внешнюю тему:

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

Первый вызов влияет только на слайды, зависевшие от `firstGroupMaster`, а второй – только на слайды, зависевшие от `secondGroupMaster`. Слайды, принадлежащие другим master‑ам, не переоформляются.

### **Сохранение исходной темы при перемещении слайдов**

Если необходимо переместить слайд в другую презентацию, сохранив его оригинальный дизайн, склонируйте исходный master в целевую презентацию с помощью [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/), затем склонируйте слайд с помощью [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) вместе с клонированным master‑ом. Это переносит master, его layout‑ы и связанную тему вместе.

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

Это предпочтительный рабочий процесс, когда исходный слайд должен выглядеть одинаково в целевом документе. Простое клонирование содержимого на несвязанном master‑е может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применение значений темы к существующему слайду**

Если целевой слайд должен оставаться на текущем master‑е и layout‑е, инициализируйте переопределение уровня слайда из исходной темы. Методы [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/) и [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) копируют три основных компонента темы в переопределение.

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

Это меняет тему, используемую этим слайдом, без изменения темы, унаследованной другими слайдами. Чтобы удалить локальное переопределение и вернуться к унаследованным значениям, вызовите [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/).

### **Применение переопределения темы к layout‑у**

Переопределение уровня layout применяется к слайдам, использующим этот layout, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации могут быть использованы через [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/) layout‑а:

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

Используйте тему уровня master или презентации, когда многие layout‑ы и слайды должны разделять один базовый дизайн; переопределение layout – когда одной семье layout нужен иной стиль; и переопределение слайда лишь для истинных исключений. Чрезмерное количество переопределений на уровне слайда усложняет предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Фоновые заливки темы хранятся в [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint может показывать в интерфейсе больше вариантов фона, чем количество фактически сохранённых в этой коллекции определений заливок, поскольку UI может комбинировать заливки темы с цветовыми схемами и другими ссылками на стили.

![Галерея фоновых стилей PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием фонового стиля просмотрите сохранённую коллекцию и текущий [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/). `StyleIndex` использует `0` для отсутствия тематической заливки; положительные значения – ссылки на стили фонового оформления темы. Это отличается от индексации .NET‑коллекции напрямую, где `[0]` означает первый сохранённый элемент. Не предполагаете, что у каждой презентации одинаковое количество стилей фоновых заливок.

Следующий пример выводит количество доступных фоновых заливок, задаёт тематическую ссылку на фон первого master‑а и сохраняет презентацию:

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

Видимый результат зависит от записи темы, на которую ссылается master, и от любых переопределений фона на уровнях layout или слайда. Если слайд использует собственный фон, изменение только фона master может не повлиять на этот слайд. Используйте [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) когда необходимо узнать окончательный фон после применения наследования.

{{% alert color="warning" title="Warning" %}}
Не рассматривайте `StyleIndex` как нулевой индекс коллекции. Также избегайте жёсткого кодирования номера стиля из одного файла и предположения, что он будет выглядеть так же в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/net/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/) и [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/). Типичные офисные темы часто включают три основных стиля, визуально соответствующие «тонкому», «умеренно насыщенному» и «интенсивному» форматированию, но код должен проверять каждую коллекцию, а не предполагать фиксированное количество.

![Тонкие, умеренные и интенсивные эффекты темы, применённые к одной и той же форме](presentation-design_10.png)

При доступе к этим коллекциям в C# индекс коллекции начинается с нуля: `[0]` – первая сохранённая стиль, `[2]` – третья. Индексы ссылок стилей формы – отдельное понятие, раскрывается через [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/). Изменение стиля темы влияет на формы, которые ссылаются на этот стиль; формы с прямым форматированием могут оставаться без изменений.

Следующий пример проверяет наличие требуемых записей стилей, меняет первый стиль линии, третий стиль заливки, включает внешнюю тень в третьем стиле эффекта и сохраняет результат:

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

Для форм, ссылающихся на эти слоты, первый стиль линии темы станет красным, третий стиль заливки – сплошным лесным зелёным, а третий стиль эффекта получит внешнюю тень с удалением 10 пунктов. Точный визуальный результат всё ещё зависит от того, какие слоты стилей использует каждая форма и перекрывает ли прямое форматирование тему.

![Эффекты темы после изменения линии, заливки и настройки тени](presentation-design_11.png)

## **Выбор стилей заливки и линии темы для формы**

Форма может независимо выбирать заливку и контур через [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) и [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/). Для обеих свойств индекс `1` выбирает первую запись в соответствующей тематической коллекции (`FillStyles[0]` или `LineStyles[0]`), а индекс `2` – вторую запись.

Следующий пример создаёт два стиля заливки (золотой и небесно‑голубой) и два стиля линии (тёмно‑синий 6 pt и тёмно‑красный 12 pt) в стандартной теме новой презентации. Он сохраняет слайд в трёх этапах, чтобы вы могли сравнить результаты в PowerPoint.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| Начальные стили | Изменить правый контур | Отредактировать первую заливку темы |
|:---:|:---:|:---:|
| ![Золотые и небесно‑голубые прямоугольники с тонкими тёмно‑синими контурами](theme-style-initial.png) | ![Небесно‑голубой прямоугольник теперь имеет толстый тёмно‑красный контур](theme-style-line-changed.png) | ![Левый прямоугольник стал зелёным, контуры остались без изменений](theme-style-fill-changed.png) |

Выбор другого стиля линии меняет только контур правого прямоугольника. Изменение первой заливки темы обновляет каждую форму, использующую её. Здесь только левый прямоугольник стал зелёным.

У уже существующей формы локальный цвет заливки, цвет линии или ширина линии могут переопределять соответствующую часть стиля темы. Если изменение индекса стиля не даёт видимого эффекта, проверьте [direct formatting](/slides/ru/net/shape-formatting/) формы.

## **Определение, использует ли эффективная сплошная заливка цвет темы**

Заливка может быть сохранена непосредственно в объекте или унаследована от абзаца, layout‑а, master‑а, стиля темы или другого уровня форматирования. Вызовите [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) чтобы превратить эту иерархию в неизменяемый [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/). Сначала проверьте [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/). Только когда он равен `FillType.Solid`, следует читать свойства сплошной заливки.

Для сплошной заливки [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) возвращает окончательное значение RGB после наследования, поиска в теме и применения трансформаций цвета. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) возвращает соответствующий логический слот [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/), например `Text1` или `Accent6`. Значение `SchemeColor.NotDefined` означает, что эффективная сплошная заливка не основана на цветовом шаблоне. В рабочем процессе, где заливки являются либо цветовыми шаблонами темы, либо прямыми RGB‑цветами, это значение указывает на прямую RGB‑заливку.

Не используйте локальное значение [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) самостоятельно для классификации заливки. Например, часть текста может не иметь локально определённого цвета схемы, поэтому её локальное значение – `NotDefined`, в то время как её эффективная заливка наследует цвет темы и разрешается в `Text1` или `Accent6`. Напротив, `SolidFillSchemeColor` говорит, какой логический слот темы создал эффективный цвет, но не сообщает, откуда этот слот пришёл – из объекта, абзаца, layout‑а, master‑а или другого уровня.

Следующий пример загружает презентацию, проверяет заливки форм и заливки частей текста, выводит каждый окончательный RGB‑цвет и связанный цвет схемы, а также помечает сплошные заливки, которые не будут отслеживать изменения цвета темы:

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

Ветвь `NotDefined` предоставляет список сплошных заливок, которые не отреагируют на изменения цветовых слотов темы. Просмотрите эти объекты, когда презентация должна соответствовать новой брендовой палитре. Отображаемое RGB‑значение всё ещё показывает текущий вид, а значение схемы объясняет, связано ли этот вид с темой.

Эффективные объекты форматов – это снимки. После изменения темы презентации, переопределения темы или любого унаследованного форматирования вызовите `GetEffective` ещё раз и прочитайте новый объект `IFillFormatEffectiveData`, прежде чем сравнивать или сообщать цвета.

## **Чтение эффективных значений темы**

Необработанные объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или форма действительно используют после применения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Для фона используйте [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/), а для заливки – [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/).

Следующий пример читает эффективную тему, фон и первую заливку формы со слайда:

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

Используйте эффективные данные для диагностики рендеринга, валидации и сравнений. Если вы проверяете только [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/), можете пропустить переопределения master‑а, layout‑а, слайда или формы, меняющие окончательный вид.

## **FAQ**

**Применяется ли внешняя тема ко всем слайдам презентации?**

Нет. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) пере‑назначает только слайды, зависящие от выбранного master‑а. Слайды, использующие другие master‑ы, сохраняют свои существующие темы.

**Могу ли я применить тему к отдельному слайду без изменения master‑а?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) слайда и инициализируйте его переопределение темы. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Какой способ самый безопасный для переноса темы из одной презентации в другую?**

При перемещении слайда и сохранении его внешнего вида клонируйте исходный master в целевую презентацию и клонируйте сам слайд с этим master с помощью [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) и [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/). Это сохраняет master, layout‑ы и тему вместе.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) для темы слайда или layout‑а и соответствующие методы получения эффективных данных для объектов формата, такие как [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) и [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/). Эти API возвращают разрешённые значения после применения наследования и переопределений.