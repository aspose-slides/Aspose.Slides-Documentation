---
title: Форматирование текста презентации в .NET
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/net/text-formatting/
keywords:
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
- текстовый фрейм
- межстрочный интервал
- свойство автоподгонки
- привязка текстового фрейма
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Форматировать и оформлять текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for .NET. Описываются фоновые цвета, прозрачность, межсимвольный интервал, свойства шрифта, вращение, интервалы абзацев, поведение автоподгонки, привязка текста, табуляция и настройки языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, а его первый абзац содержит текст, показанный ниже. Индексы слайдов и фигур начинаются с нуля. Примеры, выбирающие жирные части текста, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения по регулярному выражению, см. [Поиск и замена текста](/slides/ru/net/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) для установки цвета подсветки по умолчанию для абзаца, или используйте [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) для отдельных частей текста.

В следующем примере устанавливается светло‑серая подсветка в качестве значения по умолчанию для первого абзаца. Явные цвета подсветки для отдельных частей текста имеют приоритет над этим значением по умолчанию:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Установить цвет подсветки для всего абзаца.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже приведён пример кода, демонстрирующий, как установить цвет фона **частей текста с жирным шрифтом**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Установить цвет подсветки для части текста.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Серые части текста](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) для установки выравнивания абзаца внутри текстового фрейма. Значение может быть центрировано, выровнено по левому, правому краю, выровнено по ширине и т.д.

В следующем примере показывается, как выровнять абзац **по центру**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Установить выравнивание абзаца по центру.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Выравнивание шрифтов в строке**

Используйте [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) для вертикального выравнивания частей текста разного размера шрифта в пределах строки. Эта настройка применяется ко всему абзацу и управляет выравниванием в каждой его строке.

В следующем автономном примере создаются четыре помеченных текстовых поля на одном слайде. Каждый абзац содержит одинаковый текст размером 18, 36 и 54 пункта с разным выравниванием шрифта. Используется Arial, отключена автоподгонка и перенос, а текстовые фреймы достаточно велики для одной строки.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Результат:

![Сравнение выравниваний Baseline, Top, Center и Bottom при смешанных размерах шрифта](font_alignment.png)

Выравнивание шрифта использует метрики шрифта, поэтому видимые края отдельных букв не всегда точно совпадают. Пример включает заглавную букву и нисходящий элемент, чтобы продемонстрировать разницу между базовой линией и нижним выравниванием. Доступность шрифтов и их замена, используемые символы и разница в размерах шрифтов влияют на результат. Размеры фрейма, отступы, межстрочный интервал, перенос и автоподгонка также влияют на расположение; используйте одинаковые шрифты и настройки макета при сравнении режимов.

Эта настройка отличается от [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), который управляет горизонтальным выравниванием абзаца, и от [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), который позиционирует текстовый блок вертикально внутри фигуры. Форматирование надстрочного и подстрочного текста через [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) сдвигает отдельные части относительно базовой линии вместо установки выравнивания шрифта для строк абзаца.

## **Установить прозрачность текста**

Прозрачность текста контролируется альфа‑компонентой цвета, назначенного [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже показан пример кода, который применяет прозрачность к **всему абзацу**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Установить полупрозрачную черную заливку для текста.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

В следующем примере показывается, как применить прозрачность к **частям текста с жирным шрифтом**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Установить прозрачность части текста.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Прозрачные части текста](transparent_text_portions.png)

## **Установить межсимвольный интервал текста**

Используйте [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) для увеличения или уменьшения расстояния между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сжимают текст.

Ниже показан код C#, который расширяет межсимвольный интервал в **всём абзаце**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Увеличить межсимвольный интервал.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже демонстрирует расширение межсимвольного интервала в **частях текста с жирным шрифтом**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
        portion.PortionFormat.Spacing = 3;  // Увеличить межсимвольный интервал.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Межсимвольный интервал в частях текста](character_spacing_in_text_portions.png)

### **Отключить кернинг для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть немного плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint может игнорировать данные кернинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint в таких случаях, можно отключить кернинг для частей текста, использующих затронутый шрифт. Установите [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) в значение, превышающее фактический размер шрифта. Этот пример требует файл «presentation.pptx» с текстовым полем в первой фигуре первого слайда. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для частей, использующих Roboto. Это отключает кернинг для совпадающих частей, у которых размер шрифта менее 100 пунктов:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Для совпадающего текста ниже порога эта настройка предотвращает кернинг и может помочь согласовать вывод Aspose.Slides с визуальным результатом PowerPoint для шрифтов, на которые влияет данное специфическое поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) или на отдельных частях через [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

В следующем примере задаётся default‑шрифт первого абзаца: Times New Roman 12 пунктов, жирный, курсив и пунктирное подчёркивание. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Установить свойства шрифта для абзаца.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![Свойства шрифта абзаца](font_properties_for_paragraph.png)

В следующем примере применяется Times New Roman 13 пунктов, курсив и пунктирное подчёркивание к тем частям, чьё эффективное форматирование жирное:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Установить свойства шрифта для части текста.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Свойства шрифта частей текста](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) для установки предопределённой ориентации текста внутри фигуры.

Ниже приведён пример кода, который задаёт ориентацию текста в фигуре как [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Результат:

![Вращение текста](text_rotation.png)

## **Установить пользовательское вращение для текстовых фреймов**

Используйте [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) для задания произвольного угла вращения для [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Пример кода ниже вращает текстовый фрейм на 3 градуса по часовой стрелке внутри фигуры:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установить междустрочный интервал абзацев**

Aspose.Slides предоставляет [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) и [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) для управления интервалами абзацев. Эти свойства используются следующим образом:

* Положительное значение задаёт межстрочный интервал как процент от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

В следующем примере задаётся интервал внутри первого абзаца — 200 % от высоты строки (двойной интервал):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Результат:

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Управление переносом строк**

Правила переноса строк в абзаце полезны в узких текстовых блоках и презентациях, где смешаны латинский и восточно‑азиатский тексты. Следующие свойства относятся к [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), поэтому применяются ко всему абзацу:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) управляет правилами переноса для латинского текста. В смешанном тексте изменение этого свойства может также изменить места переноса соседнего восточно‑азиатского текста и знаков препинания.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) управляет правилами переноса для восточно‑азиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), который включает автоматический перенос внутри текстового фрейма. Они влияют на макет, когда происходит перенос; они не вставляют символы разрыва строки. Явный разрыв строки принудительно создаёт новую строку в абзаце независимо от доступной ширины.

В следующем автономном примере создаётся узкий текстовый блок, содержащий китайский и латинский текст. Явным образом задаются оба свойства переноса и сохраняется файл «line_breaking.pptx». Чтобы поэкспериментировать с тем или иным правилом, измените значение соответствующего свойства, оставив другое без изменений. В примере используется Arial 24 пункта и SimSun, ширина фрейма — 160 пунктов, горизонтальные отступы — 0. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) установлен в [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/), чтобы размер текста и размеры фрейма оставались фиксированными.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Управление висячей пунктуацией**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) позволяет допускаемой пунктуации выходить за правый край строки вместо того, чтобы занимать следующую строку. Применяется к целому абзацу и отличается от висячего отступа.

В следующем автономном примере включена висячая пунктуация в текстовом фрейме шириной 100 пунктов и сохраняется файл «hanging_punctuation.pptx». При Arial 24 пункта и нулевых горизонтальных отступах конечная точка остаётся после слова «sentence» и выступает за правый край текста. Установите свойство в [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), чтобы сравнить: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы фиксировать доступную ширину.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Не каждая пунктуация может «висеть». Условия шрифта и разметки, описанные выше (§ [Control Line Breaking](#control-line-breaking)), также применимы к этому сравнению: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать видимую разницу.

## **Установить тип автоподгонки для текстовых фреймов**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за пределы или автоматически менять размер фигуры. В следующем примере конфигурируется фигура для изменения размера под размер текста и сохраняется как «autofit_type.pptx».

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как изменяется ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/net/manage-paragraph/). Одно лишь количество строк не указывает, выходит ли текст за границы контейнера.

## **Установить привязку текстовых фреймов**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, по центру или внизу. В следующем примере текст привязывается к нижней части первой фигуры и сохраняется как «text_anchor.pptx».

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Установить табуляцию текста**

Используйте [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) и [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) для настройки табуляций в абзаце. В следующем примере задаётся интервал табуляции по умолчанию — 100 пунктов, и добавляется табуляция, выровненная по левому краю, в позиции 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Результат:

![Табуляция в абзаце](paragraph_tabs.png)

## **Установить язык проверки орфографии**

Aspose.Slides предоставляет [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), который позволяет задать язык проверки орфографии для части текста. Язык проверки определяет, какой язык используется для проверки правописания и грамматики в PowerPoint.

В следующем примере требуется файл «presentation.pptx» с текстовым полем в первой фигуре первого слайда и как минимум один абзац. Он заменяет содержимое первого абзаца на «1。», задаёт SimSun как шрифт и устанавливает упрощённый китайский язык проверки («zh-CN»). Результат сохраняется как «proofing_language.pptx»:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Установить язык проверки орфографии на упрощённый китайский.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) для определения языка текста по умолчанию, создаваемого при загрузке или создании презентации. В следующем примере создаётся презентация с английским (США) как языком текста по умолчанию, добавляется текстовое поле и выводится `en-US` для первой части текста.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Добавить новую прямоугольную форму с текстом.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Проверить язык первой части текста.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

В следующем примере задаётся шрифт 14 пунктов, полужирный, как стиль по умолчанию для абзацев верхнего уровня в новой презентации, и сохраняется как «default_text_style.pptx». Текст может наследовать эти значения, если более конкретное форматирование их не переопределит.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Получить формат абзаца верхнего уровня.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Извлечение текста с эффектом «Все прописные»**

В PowerPoint применение эффекта шрифта **All Caps** делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такой части текста через Aspose.Slides библиотека возвращает текст в том виде, в котором он был введён. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Этот пример требует файл «sample2.pptx» с текстовым полем в первой фигуре первого слайда. Первая часть первого абзаца содержит «Hello, Aspose!», к которому применён эффект All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Ниже показан пример кода, который извлекает текст с применённым эффектом **All Caps**:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Вывод:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Как изменить текст в таблице на слайде?**

Для изменения текста в таблице на слайде используйте [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Перебирайте ячейки и обновляйте каждую через [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) и форматирование абзацев через [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Установите [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) в [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.