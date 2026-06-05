---
title: "Форматирование текста презентации в .NET"
linktitle: "Форматирование текста"
type: docs
weight: 50
url: /ru/net/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- интервал между символами
- свойства шрифта
- семейство шрифтов
- поворот текста
- угол поворота
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- привязка текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Настройте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Описываются выделение, цвета фона, прозрачность, интервал между символами, свойства шрифта, вращение, интервал между абзацами, поведение автоподгонки, привязка текста, табуляция и настройки языка.

В примерах ниже будет использоваться файл с именем «sample.pptx», в котором на первом слайде находится один текстовый блок со следующим текстом:

![Sample text](sample_text.png)

## **Выделение текста**

Используйте метод [ITextFrame.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlighttext/) когда необходимо выделить текст, соответствующий определённому образцу внутри текстового кадра. Метод применяет цвет выделения к подходящим фрагментам текста и может использоваться совместно с [TextSearchOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/) , чтобы управлять способом выполнения поиска, например, чтобы соответствовать только целым словам.

Пример кода ниже выделяет все вхождения символов **"try"**, а затем выделяет только полное слово **"to"**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Получить первую форму с первого слайда.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Выделить слово "try" в форме.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Выделить слово "to" в форме.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Результат:

![The highlighted text](highlighted_text.png)

## **Выделение текста с помощью регулярных выражений**

Метод [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlightregex/) выделяет совпадения текста, найденные с помощью регулярного выражения. В .NET этот API доступен через [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/).

Пример кода ниже выделяет все слова, содержащие **семь и более символов**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Выделить все слова, содержащие семь или более символов.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Результат:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Установка цвета фона текста**

Используйте [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaultportionformat/) , чтобы задать цвет выделения по умолчанию для абзаца, или используйте [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/highlightcolor/) , чтобы задать его для отдельных частей текста.

Следующий пример кода показывает, как установить цвет фона для **всего абзаца**:

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

![The gray paragraph](gray_paragraph.png)

Пример кода ниже демонстрирует, как установить цвет фона для **частей текста с полужирным шрифтом**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Установить цвет выделения для части текста.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Результат:

![The gray text portions](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/alignment/) , чтобы задать выравнивание абзаца внутри текстового кадра. Значение может быть центрировано, выровнено по левому краю, по правому, выравнено по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац по **центру**:

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

![The aligned paragraph](aligned_paragraph.png)

## **Установка прозрачности текста**

Прозрачность текста регулируется альфа‑компонентой цвета, назначенного [IPortionFormat.FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/fillformat/). В приведённых ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Следующий пример кода показывает, как применить прозрачность к **всему абзацу**:

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

![The transparent paragraph](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **частям текста с полужирным шрифтом**:

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
            // Установить прозрачность части текста.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Результат:

![The transparent text portions](transparent_text_portions.png)

## **Установка интервала между символами текста**

Используйте [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/spacing/) , чтобы увеличить или уменьшить интервал между символами в текстовом блоке.

Следующий C#‑код показывает, как расширить интервал между символами в **всём абзаце**:

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

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как расширить интервал между символами в **частях текста с полужирным шрифтом**:

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

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Отключение кернинга для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть чуть плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint может игнорировать данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы в таких ситуациях отрисовка была ближе к PowerPoint, можно отключить кернинг для частей текста, использующих затронутый шрифт. Установите [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/kerningminimalsize/) в значение, значительно превышающее фактический размер шрифта:

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

Эта настройка предотвращает применение кернинга к соответствующим частям текста и может помочь согласовать визуальный вывод Aspose.Slides с выводом PowerPoint для шрифтов, на которые влияет данное специфическое поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaultportionformat/) или для отдельных частей через [IPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/).

Следующий код задает шрифт и стиль текста для **всего абзаца**: он применяет размер шрифта, полужирный, курсив, пунктирное подчеркивание и шрифт Times New Roman ко всем частям абзаца.

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

Пример кода ниже применяет аналогичные свойства к **частям текста с полужирным шрифтом**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Результат:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Установка поворота текста**

Используйте [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/textverticaltype/) , чтобы установить предопределённую ориентацию текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Результат:

![The text rotation](text_rotation.png)

## **Установка пользовательского поворота для текстовых кадров**

Используйте [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/rotationangle/) , чтобы задать пользовательский угол поворота для [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/).

Пример кода ниже вращает текстовый кадр на 3 градуса по часовой стрелке внутри фигуры:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Результат:

![The custom text rotation](custom_text_rotation.png)

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spacebefore/) и [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spacewithin/) для управления интервалом абзацев. Эти свойства используются следующим образом:

* Укажите положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.  
* Укажите отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример кода показывает, как задать межстрочный интервал внутри абзаца:

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

![The line spacing within the paragraph](line_spacing.png)

## **Установка типа автоподгонки для текстовых кадров**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/autofittype/) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за пределы или автоматически менять размер фигуры.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Установка привязки текстовых кадров**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/anchoringtype/) определяет, как текст позиционируется вертикально внутри фигуры, например вверху, по середине или внизу.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Установка табуляции текста**

Используйте [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaulttabsize/) и [IParagraphFormat.Tabs](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/tabs/) , чтобы настроить позиции табуляции в абзаце.

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

![The paragraph tabs](paragraph_tabs.png)

## **Установка проверочного языка**

Aspose.Slides предоставляет [IPortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/languageid/), который позволяет задать проверочный язык для части текста. Проверочный язык определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример кода показывает, как задать проверочный язык для части текста:

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

## **Установка языка по умолчанию**

Используйте [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/defaulttextlanguage/) , чтобы задать язык по умолчанию для текста, создаваемого при загрузке или создании презентации.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Добавить новую прямоугольную форму с текстом.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Проверить язык первой части текста.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Установка стиля текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/defaulttextstyle/).

Следующий пример кода показывает, как задать шрифт по умолчанию полужирным размером 14 pt для всего текста на всех слайдах новой презентации.

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

## **Извлечение текста с эффектом All Caps**

В PowerPoint применение эффекта **All Caps** делает текст отображаемым заглавными буквами на слайде, даже если он был введён строчными. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в котором он был введён. Чтобы получить отображаемый вариант, проверьте [TextCapType](https://reference.aspose.com/slides/ru/net/aspose.slides/textcaptype/) и при значении `All` преобразуйте возвращённую строку в верхний регистр.

Предположим, что на первом слайде файла sample2.pptx есть следующий текстовый блок.

![The All Caps effect](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

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

Чтобы изменить текст в таблице на слайде, используйте [ITable](https://reference.aspose.com/slides/ru/net/aspose.slides/itable/). Пройдитесь по ячейкам и обновите каждую через [ICell.TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/icell/textframe/) и форматирование абзацев через [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/paragraphformat/).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IPortionFormat.FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/fillformat/). Установите [IFillFormat.FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformat/filltype/) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) и настройте градиентные остановки, направление и прозрачность.