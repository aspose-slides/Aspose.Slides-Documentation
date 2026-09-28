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
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- привязка текстовой рамки
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides for .NET. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for .NET. В ней рассматриваются фоновые цвета, прозрачность, межсимвольный интервал, свойства шрифта, вращение, межабзацный интервал, поведение автоподгонки, привязка текста, табуляция и настройки языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, а его первый абзац содержит текст, показанный ниже. Индексы слайдов и фигур начинаются с нуля. Примеры, выделяющие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Sample text](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см.[Поиск и замена текста](/slides/ru/net/search-and-replace-text/).

## **Установить фоновый цвет текста**

Используйте [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaultportionformat/) для установки цвета подсветки по умолчанию для абзаца, либо используйте [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/highlightcolor/) для отдельных текстовых частей.

Следующий пример задает светло-серую подсветку как значение по умолчанию для первого абзаца. Явные цвета подсветки в отдельных частях имеют приоритет над этим значением по умолчанию:

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

Пример кода ниже демонстрирует, как установить фоновый цвет для **текстовых частей с жирным шрифтом**:

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
        // Установить цвет подсветки для текстовой части.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Серые текстовые части](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/alignment/) для установки выравнивания абзаца внутри текстового кадра. Значение может быть центрированным, по левому краю, по правому краю, выровненным по ширине и т.д.

Следующий пример кода показывает, как выравнивать абзац **по центру**:

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

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/fillformat/). В приведенных ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Пример кода ниже показывает, как применить прозрачность к **всему абзацу**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Установить полупрозрачную чёрную заливку для текста.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **текстовым частям с жирным шрифтом**:

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
        // Установить прозрачность текстовой части.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Прозрачные текстовые части](transparent_text_portions.png)

## **Установить межсимвольный интервал текста**

Используйте [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/spacing/) для увеличения или уменьшения интервала между символами в текстовом поле. В примерах добавляется интервал в 3 пункта; отрицательные значения сжимают текст.

Следующий код C# показывает, как расширить межсимвольный интервал в **всём абзаце**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Расширить межсимвольный интервал.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как расширить межсимвольный интервал в **текстовых частях с жирным шрифтом**:

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
        portion.PortionFormat.Spacing = 3;  // Расширить межсимвольный интервал.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Межсимвольный интервал в текстовых частях](character_spacing_in_text_portions.png)

### **Отключить кернинг для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть чуть плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint может игнорировать данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать отрисованный результат ближе к PowerPoint в подобных случаях, можно отключить кернинг для текстовых частей, использующих затронутый шрифт. Установите [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/kerningminimalsize/) в значение, превышающее фактический размер шрифта. Этот пример требует файл "presentation.pptx" с текстовым полем в качестве первой фигуры на первом слайде. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для частей, использующих Roboto. Это отключает кернинг для соответствующих частей шрифта размером менее 100 пунктов:

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

Для соответствующего текста, размер которого ниже порога, эта настройка предотвращает кернинг и может помочь согласовать вывод Aspose.Slides с визуальным результатом PowerPoint для шрифтов, затронутых этим специфическим для PowerPoint поведением.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задавать на уровне абзаца через [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaultportionformat/) или для отдельных частей через [IPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/).

Следующий пример задаёт шрифт по умолчанию для первого абзаца: Times New Roman 12 пунктов, жирный, курсив и пунктирное подчёркивание. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

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

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Следующий пример применяет к частям, у которых эффективное форматирование жирное, шрифт Times New Roman 13 пунктов, курсив и пунктирное подчёркивание:

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
        // Установить свойства шрифта для текстовой части.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Свойства шрифта для текстовых частей](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/textverticaltype/) для установки предопределённой ориентации текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ru/net/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

## **Установить пользовательское вращение для текстовых рамок**

Используйте [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/rotationangle/) для задания собственного угла вращения для [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/).

Пример кода ниже вращает текстовый кадр на 3 градуса по часовой стрелке внутри фигуры:

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

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spacebefore/), и [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spacewithin/) для управления интервалом абзацев. Эти свойства используются следующим образом:

* Задайте положительное значение, чтобы указать межстрочный интервал в процентах от высоты строки.
* Задайте отрицательное значение, чтобы указать межстрочный интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца как 200 % от высоты строки (двойной интервал):

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

Правила переноса строк в абзаце полезны в узких текстовых блоках и презентациях, содержащих смесь латинского и восточноазиатского текста. Следующие свойства относятся к [IParagraphFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/), поэтому они применяются к целому абзацу:

- [LatinLineBreak](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/latinlinebreak/) управляет правилами переноса строк для латинского текста. В смешанном тексте изменение этого свойства может также менять места переноса соседнего восточноазиатского текста и знаков препинания.
- [EastAsianLineBreak](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/eastasianlinebreak/) управляет правилами переноса строк для восточноазиатского текста, включая ограничения на символы в начале и в конце строки.

Эти правила не заменяют [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/wraptext/), который включает автоматический перенос внутри текстового кадра. Они влияют на макет при переносе, но не вставляют символы переноса строки. Явный перенос строки заставляет начать новую строку в абзаце независимо от доступной ширины.

Следующий автономный пример создаёт узкий текстовый блок, содержащий китайский и латинский текст. Он явно задаёт оба свойства переноса строк и сохраняет файл "line_breaking.pptx". Чтобы поэкспериментировать с любым из правил, измените значение соответствующего свойства, оставив другое неизменным. В примере используется Arial 24 пункта и SimSun с шириной кадра 160 пунктов и нулевыми горизонтальными отступами текстового кадра. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/autofittype/) установлен в [TextAutofitType.None](https://reference.aspose.com/slides/ru/net/aspose.slides/textautofittype/), чтобы размер текста и размеры кадра оставались фиксированными.

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/hangingpunctuation/) позволяет допустимым знакам пунктуации выходить за правый край строки текста вместо того, чтобы занимать следующую строку. Это свойство применяется к всему абзацу и отличается от висячего отступа.

Следующий автономный пример включает висячую пунктуацию в текстовом кадре шириной 100 пунктов и сохраняет файл "hanging_punctuation.pptx". При использовании Arial 24 пункта и нулевых горизонтальных отступов кадра, конечная точка остаётся после слова "sentence" и выходит за правый край текста. Установите свойство в значение [NullableBool.False](https://reference.aspose.com/slides/ru/net/aspose.slides/nullablebool/), чтобы сравнить: при этих настройках точка занимает отдельную строку. Перенос включён, а автоподгонка отключена, чтобы фиксировать доступную ширину.

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

Не каждый знак пунктуации может «висеть». [Условия шрифта и макета, описанные выше](#conditions-and-limitations) также применимы к этому сравнению: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может устранить видимую разницу.

## **Установить тип автоподгонки для текстовых рамок**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/autofittype/) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст уменьшаться, выходить за пределы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру так, чтобы она изменяла размер в соответствии с текстом, и сохраняет результат в файл "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как изменение ширины текста или фигуры влияет на результат, см.[Подсчёт отрисованных строк](/slides/ru/net/manage-paragraph/). Само количество строк не указывает, выходит ли текст за границы контейнера.

## **Установить привязку текстовых рамок**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/anchoringtype/) определяет, как текст расположен вертикально внутри фигуры, например, вверху, по центру или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в файл "text_anchor.pptx".

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

Используйте [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaulttabsize/) и [IParagraphFormat.Tabs](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/tabs/) для настройки табуляций в абзаце. В следующем примере задаётся значение табуляции по умолчанию 100 пунктов и добавляется табуляция, выровненная по левому краю, на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

![Табуляции абзаца](paragraph_tabs.png)

## **Установить язык проверки орфографии**

Aspose.Slides предоставляет [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/languageid/), который позволяет задать язык проверки орфографии для текстовой части. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует файл "presentation.pptx" с текстовым полем в качестве первой фигуры на первом слайде и как минимум один абзац. Он заменяет содержимое первого абзаца на "1。", устанавливает SimSun как шрифт и задаёт язык проверки упрощённого китайского (`zh-CN`). Результат сохраняется в файл "proofing_language.pptx":

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

// Установить язык проверки в упрощённый китайский.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/defaulttextlanguage/) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации. В следующем примере создаётся презентация с американским английским в качестве языка текста по умолчанию, добавляется текстовое поле и выводится `en-US` для первой текстовой части.

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

// Проверить язык первой части.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/defaulttextstyle/).

Следующий пример задаёт шрифт 14 пунктов, жирный, как значение по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в файл "default_text_style.pptx". Текст может наследовать эти значения по умолчанию, если не будет переопределён более специфичным форматированием.

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

## **Извлечь текст с эффектом All-Caps**

В PowerPoint применение эффекта **All Caps** (все заглавные) делает текст отображаемым заглавными буквами на слайде, даже если он был введён строчными. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы соответствовать отображаемому тексту, проверьте [TextCapType](https://reference.aspose.com/slides/ru/net/aspose.slides/textcaptype/) и при значении `All` преобразуйте возвращенную строку в верхний регистр.

Этот пример требует файл "sample2.pptx" с текстовым полем в качестве первой фигуры на первом слайде. Первая часть первого абзаца содержит "Hello, Aspose!" с применённым эффектом All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

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

Чтобы изменить текст в таблице на слайде, используйте [ITable](https://reference.aspose.com/slides/ru/net/aspose.slides/itable/). Пройдитесь по ячейкам и обновите каждую ячейку через [ICell.TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/icell/textframe/) и форматирование абзацев через [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/paragraphformat/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/fillformat/). Установите [IFillFormat.FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformat/filltype/) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) и настройте точки градиента, направление и прозрачность.