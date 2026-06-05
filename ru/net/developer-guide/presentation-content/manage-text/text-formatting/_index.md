---
title: Форматирование текста презентации в .NET
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/net/text-formatting/
keywords:
- выделение текста
- регулярные выражения
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- интервал между символами
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
- текстовый фрейм
- межстрочный интервал
- свойство автоподбора
- привязка текстового фрейма
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Форматируйте и стилизуйте текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Описываются выделение, цвета фона, прозрачность, интервал между символами, свойства шрифта, вращение, межабзацевый интервал, поведение автоподбора, привязка текста, табуляция и настройки языка.

В примерах ниже мы будем использовать файл под названием **sample.pptx**, который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выделить текст**

Используйте метод [ITextFrame.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlighttext/) , когда необходимо выделить текст, соответствующий определённому образцу внутри текстового блока. Метод применяет цвет выделения к совпадающим фрагментам текста и может использоваться совместно с [TextSearchOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/) для управления способом поиска, например, для поиска только полных слов.

В примере кода ниже выделяются все вхождения символов **"try"**, а затем выделяется только полное слово **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Получите первую фигуру с первого слайда.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Выделите слово "try" в фигуре.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Выделите слово "to" в фигуре.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделить текст с помощью регулярных выражений**

Метод [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlightregex/) выделяет совпадения, найденные регулярным выражением. В .NET этот API реализован в интерфейсе [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/).

В примере кода ниже выделяются все слова, содержащие **семь или более символов**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Выделить все слова из семи и более символов.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Результат:

![Выделенный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Установить цвет фона текста**

Используйте [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaultportionformat/) для задания цвета выделения по умолчанию для абзаца, либо [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/highlightcolor/) для отдельных фрагментов текста.

Следующий пример кода показывает, как задать цвет фона для **всего абзаца**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Установить цвет выделения для всего абзаца.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже показан пример кода, который задаёт цвет фона для **фрагментов текста с полужирным шрифтом**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Установить цвет выделения для фрагмента текста.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Результат:

![Серые фрагменты текста](gray_text_portions.png)

## **Выровнять абзацы текста**

Используйте [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/alignment/) для задания выравнивания абзаца внутри текстового блока. Значение может быть по центру, выровнено по левому, правому краю, по ширине и т.д.

В примере кода ниже показано, как выровнять абзац **по центру**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Установить выравнивание абзаца по центру.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного свойству [IPortionFormat.FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/fillformat/). В примерах ниже `alpha = 50` — значение канала ARGB в диапазоне 0–255, а не процент прозрачности.

В примере кода ниже показано, как применить прозрачность к **всему абзацу**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Установить цвет заливки текста в прозрачный цвет.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **фрагментам текста с полужирным шрифтом**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Установить прозрачность фрагмента текста.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Результат:

![Прозрачные фрагменты текста](transparent_text_portions.png)

## **Установить интервал между символами текста**

Используйте [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/spacing/) для увеличения или уменьшения промежутка между символами в текстовом блоке.

Следующий пример C# показывает, как расширить интервал между символами в **всём абзаце**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Примечание: используйте отрицательные значения, чтобы сжать интервал между символами.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Увеличить интервал между символами.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Ниже приведён пример кода, который расширяет интервал между символами в **фрагментах текста с полужирным шрифтом**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Примечание: используйте отрицательные значения, чтобы сжать интервал между символами.
            portion.PortionFormat.Spacing = 3;  // Увеличить интервал между символами.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Результат:

![Интервал между символами в фрагментах текста](character_spacing_in_text_portions.png)

### **Отключить кернинг для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть чуть плотнее, чем тот же текст в PowerPoint. Это может происходить потому, что PowerPoint игнорирует данные о кернинге для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint, можно отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/kerningminimalsize/) в значение, значительно превышающее реальный размер шрифта:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Эта настройка препятствует применению кернинга к соответствующим фрагментам текста и помогает согласовать визуальное представление Aspose.Slides с выводом PowerPoint для шрифтов, на которые влияет данное поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задавать на уровне абзаца через [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaultportionformat/) или для отдельных фрагментов через [IPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/).

Следующий код задаёт шрифт и стиль текста для **всего абзаца**: он применяет размер шрифта, полужирный, курсив, пунктирное подчёркивание и шрифт Times New Roman ко всем фрагментам абзаца.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Установить свойства шрифта для абзаца.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Ниже пример кода, который применяет аналогичные свойства к **фрагментам текста с полужирным шрифтом**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Установить свойства шрифта для фрагмента текста.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

Результат:

![Свойства шрифта для фрагментов текста](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/textverticaltype/) для задания предопределённой ориентации текста внутри фигуры.

В примере кода ниже ориентация текста в фигуре задаётся как `Vertical270`, что вращает текст **на 90° против часовой стрелки**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Результат:

![Вращение текста](text_rotation.png)

## **Установить пользовательское вращение для текстовых фреймов**

Используйте [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/rotationangle/) для задания пользовательского угла вращения для [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/).

В примере кода ниже текстовый фрейм вращается на 3 градуса по часовой стрелке внутри фигуры:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет свойства [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spacebefore/) и [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spacewithin/) для управления интервалом абзацев. Эти свойства используются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

В примере кода ниже показано, как задать межстрочный интервал внутри абзаца:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Результат:

![Межстрочный интервал в абзаце](line_spacing.png)

## **Установить тип автоподбора для текстовых фреймов**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/autofittype/) определяет, как текст будет вести себя, когда превышает границы своего контейнера. Используйте его для управления тем, будет ли текст сжиматься, выходить за пределы или автоматически изменять размер фигуры.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Установить привязку текстовых фреймов**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/anchoringtype/) определяет, как текст позиционируется вертикально внутри фигуры, например вверху, по центру или внизу.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Установить табуляцию текста**

Используйте [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaulttabsize/) и [IParagraphFormat.Tabs](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/tabs/) для настройки позиций табуляции в абзаце.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Результат:

![Табуляция абзаца](paragraph_tabs.png)

## **Установить язык проверки орфографии**

Aspose.Slides предоставляет [IPortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/languageid/) , который позволяет задать язык проверки орфографии для фрагмента текста. Язык проверки определяет язык, используемый для проверки правописания и грамматики в PowerPoint.

В примере кода ниже показано, как задать язык проверки орфографии для фрагмента текста:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Установить Id проверочного языка.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/defaulttextlanguage/) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Добавить новую прямоугольную форму с текстом.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Проверить язык первого фрагмента.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Установить стиль текста по умолчанию**

Для применения форматирования текста по умолчанию на уровне презентации используйте [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/defaulttextstyle/).

В примере кода ниже задаётся шрифт с полужирным начертанием и размером 14 pt для всего текста во всех слайдах новой презентации.

```cs
using (var presentation = new Presentation())
{
    // Получить формат абзаца верхнего уровня.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Извлечь текст с эффектом All‑Caps**

В PowerPoint применение эффекта **All Caps** делает текст заглавными буквами на слайде, даже если он был введён строчными. При получении такого фрагмента текста с помощью Aspose.Slides библиотека возвращает текст в том виде, в каком он был введён. Чтобы отобразить его так же, проверьте [TextCapType](https://reference.aspose.com/slides/ru/net/aspose.slides/textcaptype/) и при значении `All` преобразуйте возвращённую строку в верхний регистр.

Предположим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект All Caps](all_caps_effect.png)

В примере кода ниже показано, как извлечь текст с применённым эффектом **All Caps**:

```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Вывод:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Как изменить текст в таблице на слайде?**

Для изменения текста в таблице на слайде используйте [ITable](https://reference.aspose.com/slides/ru/net/aspose.slides/itable/). Пройдитесь по ячейкам и обновите каждую через [ICell.TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/icell/textframe/) и форматирование абзацев через [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/paragraphformat/).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте [IPortionFormat.FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/fillformat/). Установите [IFillFormat.FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformat/filltype/) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) и настройте градиентные остановки, направление и прозрачность.