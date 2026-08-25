---
title: Управление темами презентаций в .NET
linktitle: Тема презентации
type: docs
weight: 10
url: /ru/net/presentation-theme/
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
- Презентация
- .NET
- C#
- Aspose.Slides
description: "Основные темы презентаций в Aspose.Slides для .NET позволяют создавать, настраивать и конвертировать файлы PowerPoint с единым брендингом."
---
## **Введение**

Тема презентации определяет согласованный набор цветов, шрифтов, стилей фона, заливок, линий и эффектов. Объекты, учитывающие тему, ссылаются на эти общие определения вместо того, чтобы хранить каждое визуальное свойство как фиксированное значение, поэтому изменение темы может одновременно обновить множество объектов.

В Aspose.Slides тема уровня презентации доступна через свойство [Presentation.MasterTheme](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/mastertheme/). Презентация также может содержать переопределения темы на более низких уровнях. Мастер может переопределять тему презентации через [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/masterthememanager/overridetheme/), макет может переопределять наследуемую тему через [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), и отдельный слайд может делать то же самое. На практике эффективная тема для слайда определяется по этой цепочке наследования: тема презентации, переопределение мастера, переопределение макета и переопределение слайда.

![Компоненты темы: цвета, шрифты, стили фона и эффекты](theme-constituents.png)

Ниже показаны наиболее распространённые рабочие процессы с темами: проверка темы, изменение цветов и шрифтов, копирование или применение темы, обновление стилей фона и эффектов, а также чтение эффективных значений после разрешения наследования и переопределений.

## **Осмотр темы**

Объект [MasterTheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/mastertheme/) раскрывает [ColorScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/mastertheme/fontscheme/) и [FormatScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/mastertheme/formatscheme/) темы. Проверка этих коллекций перед их изменением особенно полезна, когда презентация поступает из внешнего источника, поскольку количество и содержимое записей стилей могут различаться.

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

Если файл использует несколько мастеров, не следует предполагать, что каждый слайд имеет одну и ту же эффективную тему. Проверьте мастер, связанный со слайдом, и используйте рабочий процесс эффективной темы, показанный далее в статье, когда могут присутствовать переопределения макета или слайда.

## **Изменение цветов темы**

Тема‑зависимые заливки, линии и текст могут ссылаться на логический цвет из перечисления [SchemeColor](https://reference.aspose.com/slides/ru/net/aspose.slides/schemecolor/). Когда вы изменяете соответствующую запись в [IColorScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/icolorscheme/), все объекты, которые всё ещё ссылаются на этот цвет темы, получают новое значение. Объекты, использующие прямой RGB‑цвет, не изменяются при обновлении цвета темы.

Следующий сквозной пример создаёт форму, использующую `Accent4`, меняет цвет темы `Accent4` на красный, сохраняет презентацию, открывает её снова и выводит эффективный цвет заливки:

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

Поскольку прямоугольник остаётся привязанным к `Accent4`, его видимый цвет становится красным после изменения темы. Если заменить цвет схемы на прямой цвет в форме, последующие изменения `Accent4` больше не будут влиять на эту заливку.

### **Использование цветов из дополнительной палитры**

PowerPoint получает более светлые и тёмные варианты из цвета темы, применяя цветовые трансформации. Aspose.Slides предоставляет эти трансформации через [ColorTransformOperation](https://reference.aspose.com/slides/ru/net/aspose.slides/colortransformoperation/).

![Основные цвета темы и более светлые и тёмные цвета, сгенерированные из дополнительной палитры](additional-palette-colors.png)

**1** — Основные цвета темы.

**2** — Более светлые и более тёмные варианты, полученные из основных цветов темы.

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

Эти варианты остаются основанными на цветовом схеме темы. Если позже `Accent4` изменится, преобразованные цвета будут пересчитаны из нового значения `Accent4`.

### **Сопоставление значений `SchemeColor` со слотами `IColorScheme`**

Перечисление [SchemeColor](https://reference.aspose.com/slides/ru/net/aspose.slides/schemecolor/) использует `Text1`, `Background1`, `Text2` и `Background2`, тогда как [IColorScheme](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/icolorscheme/) раскрывает те же слоты темы как `Dark1`, `Light1`, `Dark2` и `Light2`. Сопоставление фиксировано:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Это альтернативные названия одних и тех же слотов темы; они не являются значениями, динамически преобразуемыми из одной формы в другую.

## **Изменение шрифтов темы**

Схема шрифтов темы содержит набор основных шрифтов для заголовков и набор вспомогательных шрифтов для основного текста. Свойства [FontScheme.Major](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/fontscheme/major/) и [FontScheme.Minor](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/fontscheme/minor/) раскрывают эти наборы.

Идентификаторы шрифтов, совместимые с PowerPoint, можно использовать в форматировании текста:

* `+mn-lt` — основной шрифт латиницы (Minor Latin Font)
* `+mj-lt` — шрифт заголовка латиницы (Major Latin Font)
* `+mn-ea` — основной шрифт восточно‑азиатского текста (Minor East Asian Font)
* `+mj-ea` — шрифт заголовка восточно‑азиатского текста (Major East Asian Font)

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

Заголовок следует за основным шрифтом, а основной текст — за вспомогательным. Текст, в котором явно указано название шрифта вместо идентификатора темы, не будет автоматически переключаться при изменении схемы шрифтов темы.

Основные и вспомогательные наборы шрифтов могут также содержать сопоставления шрифтов для отдельных систем письма, таких как кириллица, арабский, японский, грузинский и таана. Для проверки, добавления, замены или удаления этих сопоставлений см. [Script-Specific Theme Fonts](/slides/ru/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Для получения дополнительной информации о шрифтах презентаций см. [PowerPoint Fonts](/slides/ru/net/powerpoint-fonts/).
{{% /alert %}}

## **Копирование или применение темы**

Существуют два распространённых рабочего процесса, решающих разные задачи.

### **Сохранение исходной темы при перемещении слайдов**

Если необходимо переместить слайд в другую презентацию, сохранив его оригинальный дизайн, клонируйте исходный мастер в целевую презентацию с помощью [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection/addclone/), затем клонируйте слайд с помощью [ISlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/addclone/) и клонированного мастера. Это переносит мастер, его макеты и связанную тему вместе.

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

Это предпочтительный подход, когда исходный слайд должен выглядеть одинаково в целевом файле. Простое клонирование содержимого на несвязанный слайд мастера может изменить цвета, шрифты, фоны и эффекты, управляемые темой.

### **Применение значений темы к существующему слайду**

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

Это меняет тему, используемую этим слайдом, не затрагивая тему, наследуемую другими слайдами. Чтобы удалить локальное переопределение и вернуться к наследуемым значениям, вызовите [OverrideTheme.Clear](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/overridetheme/clear/).

### **Применение переопределения темы к макету**

Переопределение уровня макета применяется к слайдам, использующим этот макет, если только конкретный слайд не имеет собственного переопределения. Те же методы инициализации можно использовать через [LayoutSlideThemeManager](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/layoutslidethememanager/):

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

Используйте мастер или тему уровня презентации, когда многие макеты и слайды должны делить один базовый дизайн; переопределение макета – когда одной семье макетов нужен иной стиль; а переопределение слайда – только для истинных исключений. Чрезмерное количество переопределений на уровне слайда усложняет предсказуемость последующих глобальных изменений темы.

## **Обновление стилей фона темы**

Фоновые заливки темы хранятся в [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint может предлагать в интерфейсе больше вариантов фона, чем количество фактически хранимых определений заливок в этой коллекции, поскольку UI может комбинировать заливки темы с цветовыми ссылками и другими стилями.

![Галерея стилей фона PowerPoint для темы презентации](presentation-design_8.png)

Перед использованием стиля фона проверьте хранимую коллекцию и текущий [Background.StyleIndex](https://reference.aspose.com/slides/ru/net/aspose.slides/background/styleindex/). `StyleIndex` использует `0` для отсутствия тематической заливки; положительные значения – ссылки на стили фоновой темы. Это отличается от индексации .NET‑коллекции, где `[0]` означает первый элемент. Не предполагайте, что каждая презентация содержит одинаковое количество стилей фоновых заливок.

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

Видимый результат зависит от ссылки на запись темы, указанной мастером, и от любых переопределений фона на уровне макета или слайда. Если слайд использует собственный фон, изменение только фонового стиля мастера может не изменить этот слайд. При необходимости узнать окончательный фон после применения наследования используйте [Background.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/background/geteffective/).

{{% alert color="warning" title="Warning" %}}
Не рассматривайте `StyleIndex` как нулевой индекс коллекции. Также избегайте жёсткого кодирования номера стиля из одного файла, полагая, что он будет выглядеть так же в другом файле; определения стилей темы зависят от конкретной презентации.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Для прямого форматирования фона и наследования фона см. [Presentation Background](/slides/ru/net/presentation-background/).
{{% /alert %}}

## **Обновление эффектов темы**

Схема формата темы содержит отдельные коллекции [FillStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/linestyles/) и [EffectStyles](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/formatscheme/effectstyles/). Типичные темы Office часто включают три основных стиля, визуально соответствующие тонкому, умеренному и интенсивному форматированию, но код должен проверять каждую коллекцию вместо предположения фиксированного количества записей.

![Лёгкие, умеренные и интенсивные эффекты темы, применённые к одной фигуре](presentation-design_10.png)

При доступе к этим коллекциям в C# индекс коллекции начинается с нуля: `[0]` – первый сохранённый стиль, `[2]` – третий. Индексы ссылок стилей у фигуры – отдельная концепция, раскрытая через [IShapeStyle](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapestyle/). Изменение стильной темы влияет на фигуры, которые ссылаются на этот стиль; фигуры с прямым форматированием могут остаться без изменений.

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

Для фигур, использующих эти слоты, первый стиль линии темы становится красным, третий стиль заливки темы становится сплошным лесным зелёным, а третий стиль эффекта получает внешнюю тень с расстоянием 10 пунктов. Точный визуальный результат всё равно зависит от того, какие слоты стилей каждая фигура использует и не переопределяется ли тема прямым форматированием.

![Стили эффектов темы после изменения параметров линии, заливки и тени](presentation-design_11.png)

## **Чтение эффективных значений темы**

Сырые объекты темы показывают, что определено на конкретном уровне. Эффективные значения показывают, что слайд или фигура действительно используют после разрешения наследования и локальных переопределений. Для слайда вызовите [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Для фона используйте [Background.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/background/geteffective/), а для заливки – [FillFormat.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/geteffective/).

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

Эффективные данные применяйте для диагностики рендеринга, валидации и сравнения. Если проверять только [Presentation.MasterTheme](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/mastertheme/), можно упустить переопределения мастера, макета, слайда или фигуры, меняющие окончательный вид.

## **FAQ**

**Можно ли применить тему к отдельному слайду без изменения мастера?**

Да. Используйте [SlideThemeManager](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/slidethememanager/) слайда и инициализируйте его переопределяющую тему. Изменение останется локальным для этого слайда; остальные слайды продолжат наследовать свои текущие темы.

**Как безопаснее всего перенести тему из одной презентации в другую?**

При перемещении слайда и сохранении его исходного вида клонируйте исходный мастер в целевую презентацию и клонируйте слайд с этим мастером, используя [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection/addclone/) и [ISlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/islidecollection/addclone/). Это сохраняет вместе мастер, макеты и тему.

**Как увидеть эффективные значения после наследования и переопределений?**

Используйте [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ru/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) для темы слайда или макета и соответствующие методы получения эффективных данных для объектов формата, такие как [Background.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/background/geteffective/) и [FillFormat.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides/fillformat/geteffective/). Эти API возвращают окончательные значения после применения наследования и переопределений.