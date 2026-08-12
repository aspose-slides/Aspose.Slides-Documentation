---
title: "Форматирование текста презентации в .NET"
linktitle: "Форматирование текста"
type: docs
weight: 50
url: /ru/net/text-formatting/
keywords:
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- интервал между символами
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
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

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Рассматриваются фоновые цвета, прозрачность, интервал между символами, свойства шрифта, вращение, интервалы абзацев, поведение автоподгонки, привязка текста, табуляция и настройки языка.

В приведённых ниже примерах мы будем использовать файл «sample.pptx», который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения по регулярному выражению, см. [Поиск и замена текста](/slides/ru/net/search-and-replace-text/).

## **Установка фонового цвета текста**

Используйте [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaultportionformat/) для установки цвета подсветки по умолчанию для абзаца или [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/highlightcolor/) для отдельных текстовых фрагментов.

Следующий пример кода показывает, как задать фоновый цвет для **всего абзаца**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Установите цвет подсветки для всего абзаца.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже показан пример кода, который задаёт фоновый цвет для **текстовых фрагментов полужирным шрифтом**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Установите цвет подсветки для текстового фрагмента.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Результат:

![Серые текстовые фрагменты](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/alignment/) для установки выравнивания абзаца внутри текстового кадра. Значение может быть по центру, по левому краю, по правому краю, с выравниванием по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Установите выравнивание абзаца по центру.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Установка прозрачности текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/fillformat/). В примерах ниже `alpha = 50` – это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Пример кода, показывающий, как применить прозрачность к **всему абзацу**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Установите цвет заливки текста в прозрачный цвет.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода демонстрирует, как применить прозрачность к **текстовым фрагментам полужирным шрифтом**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Установите прозрачность текстового фрагмента.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Результат:

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установка интервала между символами текста**

Используйте [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/spacing/) для расширения или сжатия интервала между символами в текстовом блоке.

Следующий код C# показывает, как расширить интервал между символами в **всём абзаце**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Примечание: используйте отрицательные значения для сжатия интервала между символами.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Расширить интервал между символами.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Ниже пример кода, который расширяет интервал между символами в **текстовых фрагментах полужирным шрифтом**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Примечание: используйте отрицательные значения для сжатия интервала между символами.
            portion.PortionFormat.Spacing = 3;  // Расширить интервал между символами.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Результат:

![Интервал между символами в текстовых фрагментах](character_spacing_in_text_portions.png)

### **Отключение кернинга для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит чуть плотнее, чем тот же текст в PowerPoint. Это может происходить потому, что PowerPoint игнорирует данные о кернинге для определённых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint, в таких случаях можно отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/kerningminimalsize/) в значение, значительно превышающее фактический размер шрифта:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

Эта настройка предотвращает применение кернинга к соответствующим текстовым фрагментам и помогает согласовать визуальный вывод Aspose.Slides с PowerPoint для шрифтов, на которые влияет данное специфическое поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaultportionformat/) или для отдельных фрагментов через [IPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/).

Следующий код задаёт шрифт и стиль текста для всего абзаца: он применяет размер шрифта, полужирный, курсив, пунктирное подчёркивание и шрифт Times New Roman ко всем фрагментам абзаца.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Установите свойства шрифта для абзаца.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Результат:

![Свойства шрифта абзаца](font_properties_for_paragraph.png)

Ниже пример кода, который применяет аналогичные свойства к **текстовым фрагментам полужирным шрифтом**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Установите свойства шрифта для текстового фрагмента.
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

![Свойства шрифта текстовых фрагментов](font_properties_for_text_portions.png)

## **Установка вращения текста**

Используйте [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/textverticaltype/) для задания предопределённой ориентации текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Результат:

![Вращение текста](text_rotation.png)

## **Установка пользовательского вращения для текстовых кадров**

Используйте [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/rotationangle/) для задания собственного угла вращения [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/).

Пример кода ниже вращает текстовый кадр на 3 градуса по часовой стрелке внутри фигуры:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spacebefore/) и [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/spacewithin/) для управления интервалами абзацев. Эти свойства используются следующим образом:

* Положительное значение указывает межстрочный интервал в процентах от высоты строки.
* Отрицательное значение указывает межстрочный интервал в пунктах.

Следующий пример кода показывает, как задать межстрочный интервал внутри абзаца:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Результат:

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Установка типа автоподгонки для текстовых кадров**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/autofittype/) определяет, как текст будет вести себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за пределы или автоматически менять размер фигуры.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Установка привязки текстовых кадров**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframeformat/anchoringtype/) определяет, как текст позиционируется вертикально внутри фигуры, например вверху, по центру или внизу.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Установка табуляции текста**

Используйте [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/defaulttabsize/) и [IParagraphFormat.Tabs](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraphformat/tabs/) для настройки позиций табуляции в абзаце.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/languageid/), который позволяет задать язык проверки орфографии для текстового фрагмента. Язык проверки определяет, какой язык будет использоваться для проверки правописания и грамматики в PowerPoint.

Следующий пример кода показывает, как установить язык проверки орфографии для текстового фрагмента:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Установите идентификатор проверочного языка.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Установка языка по умолчанию**

Используйте [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/defaulttextlanguage/) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Добавьте новую прямоугольную форму с текстом.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Проверьте язык первого фрагмента.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Установка стиля текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ru/net/aspose.slides/ipresentation/defaulttextstyle/).

Следующий пример кода показывает, как задать шрифт полужирный размером 14 pt для всего текста во всех слайдах новой презентации.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Извлечение текста с эффектом «Все заглавные»**

В PowerPoint применение эффекта шрифта **All Caps** заставляет текст отображаться заглавными буквами на слайде, даже если он был введён строчными. При получении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы привести его к отображаемому виду, проверьте [TextCapType](https://reference.aspose.com/slides/ru/net/aspose.slides/textcaptype/) и при значении `All` преобразуйте возвращённую строку в верхний регистр.

Предположим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект All Caps](all_caps_effect.png)

Ниже пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:

```cs
using Aspose.Slides;

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

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/fillformat/). Установите [IFillFormat.FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/ifillformat/filltype/) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) и настройте градиентные остановки, направление и прозрачность.