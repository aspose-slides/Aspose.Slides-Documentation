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
- интервал между символами
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
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Настраивать шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Рассматриваются цвета фона, прозрачность, интервал между символами, свойства шрифта, вращение, отступы абзаца, поведение автоподгонки, привязка текста, позиции табуляции и настройки языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — текстовое поле, первое его абзац содержит приведённый ниже текст. Индексы слайдов и фигур нумеруются с нуля. Примеры, в которых выделены жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Sample text](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения по регулярному выражению, см. [Search and Replace Text](/slides/ru/net/search-and-replace-text/).

## **Установка цвета фона текста**

Используйте [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) для задания цвета подсветки по умолчанию для абзаца или [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) для отдельных текстовых частей.

Следующий пример задаёт светло‑серый цвет подсветки по умолчанию для первого абзаца. Явные цвета подсветки у отдельных частей имеют приоритет перед этим значением:

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

![The gray paragraph](gray_paragraph.png)

Ниже приведён пример кода, демонстрирующий, как установить цвет фона для **текстовых частей с полужирным шрифтом**:

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

![The gray text portions](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) для установки выравнивания абзаца внутри текстового фрейма. Значение может быть по центру, по левому краю, по правому краю, по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

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

![The aligned paragraph](aligned_paragraph.png)

## **Выравнивание шрифтов в строке**

Используйте [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) для вертикального выравнивания текстовых частей разного размера шрифта внутри строки. Эта настройка применяется ко всему абзацу и контролирует выравнивание в каждой его строке.

Следующий автономный пример создаёт четыре подписанных текстовых поля на одном слайде. Каждый абзац содержит одинаковый текст размером 18, 36 и 54 пункта с разным выравниванием шрифта. Используется Arial, отключена автоподгонка и перенос, а фреймы текста достаточно велики для одной строки.

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

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

Выравнивание шрифтов использует метрики шрифта, поэтому видимые края отдельных букв не всегда совпадают точно. В примере присутствуют прописная буква и нисходящий элемент, чтобы продемонстрировать разницу между базовой линией и нижним выравниванием. Доступность шрифтов и их замена, используемые символы и различие размеров шрифтов влияют на результат. Размеры фрейма, отступы, межстрочный интервал, перенос и автоподгонка также влияют на разметку; используйте одинаковые шрифты и настройки разметки при сравнении режимов.

Эта настройка отличается от [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), который контролирует горизонтальное выравнивание абзаца, и от [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), который позиционирует текстовый блок вертикально внутри фигуры. Форматирование надстрочного и подстрочного текста через [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) сдвигает отдельные части относительно базовой линии, а не задаёт выравнивание шрифта для строк абзаца.

## **Установка прозрачности текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Следующий пример кода показывает, как применить прозрачность к **всему абзацу**:

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

![The transparent paragraph](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **текстовым частям с полужирным шрифтом**:

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

![The transparent text portions](transparent_text_portions.png)

## **Установка интервала между символами текста**

Используйте [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) для расширения или сжатия расстояния между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сжимают текст.

Следующий C#‑код показывает, как расширить интервал между символами в **всём абзаце**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Примечание: используйте отрицательные значения для сжатия интервала между символами.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Увеличить интервал между символами.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Ниже приведён пример кода, демонстрирующий расширение интервала между символами в **текстовых частях с полужирным шрифтом**:

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
        // Примечание: используйте отрицательные значения для сжатия интервала между символами.
        portion.PortionFormat.Spacing = 3;  // Увеличить интервал между символами.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Отключение кернинга для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит чуть плотнее, чем тот же текст в PowerPoint. Это может происходить из‑за того, что PowerPoint игнорирует данные кернинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы добиться более близкого к PowerPoint результата, можно отключить кернинг для текстовых частей, использующих затронутый шрифт. Установите [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) в значение, превышающее фактический размер шрифта. В примере требуется файл "presentation.pptx" с текстовым полем в первой фигуре первого слайда. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог 100 пунктов для частей, использующих Roboto. Это отключает кернинг для соответствующих частей с размером шрифта менее 100 пунктов:

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

Для соответствующего текста ниже порога эта настройка предотвращает кернинг и может помочь согласовать отображение Aspose.Slides с визуальным выводом PowerPoint для шрифтов, на которые влияет данное поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) или на отдельных частях через [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Следующий пример задаёт первой абзацу шрифт Times New Roman 12 пунктов с полужирным, курсивным и пунктирным подчёркиванием. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Задать свойства шрифта для абзаца.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![The font properties for the paragraph](font_properties_for_paragraph.png)

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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Управление нормализацией высоты текста**

Используйте [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) при воспроизведении типографики шаблона или исследовании различий в высоте символов. В PowerPoint включение нормализации растягивает или сжимает отдельные символы по вертикали, делая их визуально одинаковой высоты в пределах текстовой части. Это не гарантирует одинаковую высоту текста между разными шрифтами.

Установите свойство в [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) для явного включения или отключения нормализации. `NullableBool.NotDefined` оставляет локальную настройку неопределённой, так что часть наследует значение, например, из [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) абзаца. Это не то же самое, что `False`. Используйте [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) и прочитайте [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) для получения разрешённого булевого значения.

Следующий автономный пример требует установленного **Arial**. Он создаёт два текстовых блока, содержащих одинаковые заглавные буквы, строчные, нисходящие элементы и символы с диакритикой, размером 54 пункта. Оба абзаца по умолчанию включают нормализацию. Верхняя часть явно отключает её; нижняя часть наследует настройку. Размеры фреймов, отступы и межабзацный интервал одинаковы, перенаправление и автоподгонка отключены для согласованного сравнения. Пример выводит `False: False` и `NotDefined: True`, затем сохраняет файл "text_height_normalization.pptx".

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

Сравнение ниже экспортировано из сохранённой презентации. В верхней строке нормализация отключена (`False`); в нижней — наследовано включённое значение (`NotDefined` → `True`). Оставьте установленный Arial для воспроизведения внешнего вида.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Нормализация изменяет высоту символов без изменения заданного значения [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/), которое определяет размер шрифта в пунктах. Параметр абзаца [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) управляет межстрочным интервалом, а параметр текстового фрейма [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) определяет, как текст или его контейнер подстраивается под размер. Эти настройки служат разным целям и могут независимо влиять на общую разметку. Подробнее о форматировании абзацев и наследовании см. в разделе [Manage Paragraph](/slides/ru/net/manage-paragraph/).

## **Применение и удаление зачеркивания**

Используйте [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) на текстовой части, чтобы отобразить исправления, отменённые термины или предыдущие цены без удаления оригинального текста. Установите значение [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) для одной или двух линий через текст.

Чтобы удалить зачеркивание, задайте `TextStrikethroughType.None`. Это явно отключает эффект, даже если окружающее форматирование указывает зачеркивание. В отличие от этого, `TextStrikethroughType.NotDefined` оставляет локальную настройку неопределённой, позволяя части унаследовать форматирование, например, от абзаца. Это не гарантирует, что зачеркивание будет удалено. Используйте [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) для чтения итогового форматирования, включая унаследованные значения.

Следующий автономный пример создаёт три сравнения цен. Каждый абзац имеет отдельные части для метки, прежней цены и текущей цены, поэтому только прежняя цена затрагивается. В первой строке зачеркивание применяется, а затем удаляется; остальные строки сохраняют одно‑ и двойное зачеркивание. Изменение этого свойства сохраняет текст и его другое форматирование, включая полужирную прежнюю цену.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Применить зачеркивание, затем явно удалить его у первой прежней цены.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Результат сверху вниз: без зачеркивания, с одиночным зачеркиванием и с двойным зачеркиванием.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Установка вращения текста**

Используйте [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) для задания предустановленной ориентации текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

![The text rotation](text_rotation.png)

## **Установка пользовательского вращения для текстовых фреймов**

Используйте [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) для задания произвольного угла вращения [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Следующий пример кода вращает текстовый фрейм на 3 градуса по часовой стрелке внутри фигуры:

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

![The custom text rotation](custom_text_rotation.png)

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) и [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) для управления интервалом абзацев. Эти свойства используются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

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

![The line spacing within the paragraph](line_spacing.png)

## **Управление разрывом строк**

Правила разрыва строк абзаца полезны в узких текстовых блоках и презентациях, где смешаны латинский и восточно‑азиатский текст. Следующие свойства принадлежат [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), поэтому они применяются ко всему абзацу:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) контролирует правила разрыва латинского текста. В смешанном тексте изменение этого свойства может также изменить места переноса соседнего восточно‑азиатского текста и знаков пунктуации.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) контролирует правила разрыва восточно‑азиатского текста, включая ограничения на символы в начале и в конце строки.

Эти правила не заменяют [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), который включает автоматический перенос внутри текстового фрейма. Они влияют на разметку, когда происходит перенос; они не вставляют символы разрыва строки. Явный разрыв строки принудительно создаёт новую строку внутри абзаца независимо от доступной ширины.

Следующий автономный пример создаёт узкий текстовый блок, содержащий китайский и латинский текст. Он явно задаёт оба свойства разрыва строк и сохраняет файл "line_breaking.pptx". Чтобы поэкспериментировать с отдельным правилом, измените значение этого свойства, оставив другое без изменений. Пример использует Arial 24 пункта и SimSun, ширину фрейма 160 пунктов и нулевые горизонтальные отступы текстового фрейма. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) установлен в [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/), чтобы размер текста и параметры фрейма оставались фиксированными.

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

## **Управление «висительной» пунктуацией**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) позволяет допустимой пунктуации выходить за правый край строки вместо того, чтобы занимать следующую строку. Применяется к целому абзацу и отличается от «висительного» отступа.

Следующий автономный пример включает «висительную» пунктуацию в текстовом фрейме шириной 100 пунктов и сохраняет файл "hanging_punctuation.pptx". При Arial 24 пункта и нулевых горизонтальных отступах конечная точка остаётся после слова «sentence» и выступает за правый край текста. Установите свойство в [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) для сравнения: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы ширина оставалась фиксированной.

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

Не каждая пунктуация может «висеть». Применяются условия шрифта и разметки, описанные выше в разделе [control-line-breaking](#control-line-breaking): изменение шрифта, доступной ширины, отступов или автоподгонки может убрать видимую разницу.

## **Установка типа автоподгонки для текстовых фреймов**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) определяет, как текст ведёт себя, когда выходит за пределы контейнера. Используйте его для управления тем, будет ли текст уменьшаться, выходить за пределы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру на изменение размеров для размещения текста и сохраняет результат в "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Чтобы посчитать строки после автоматического переноса и увидеть, как меняются ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/net/manage-paragraph/). Только количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установка привязки текстовых фреймов**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, по центру или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Установка табуляции текста**

Используйте [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) и [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) для настройки позиций табуляции в абзаце. Следующий пример задаёт интервал табуляции по умолчанию 100 пунктов и добавляет левый таб‑стоп на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

![The paragraph tabs](paragraph_tabs.png)

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), позволяющий задать язык проверки орфографии для текстовой части. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует файл "presentation.pptx" с текстовым полем в первой фигуре первого слайда и как минимум одним абзацем. Он заменяет содержимое первого абзаца на "1。", задаёт SimSun как шрифт и устанавливает язык проверки упрощённого китайского (`zh-CN`). Сохраняет результат в "proofing_language.pptx":

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

### **Копирование метаданных языка**

При копировании многоязычного текста из шаблона сохраняйте как [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), так и [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). Следующий автономный пример создаёт исходную часть с английским (США) в качестве основного языка и французским в качестве альтернативного, затем копирует текст и идентификаторы в часть новой презентации.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// Если у источника нет альтернативного языка, null очищает значение назначения.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Чтобы попробовать источник без альтернативного языка, опустите присваивание `"fr-FR"`. В этом случае альтернативный идентификатор будет `null`, и тот же оператор копирования сохранит его отсутствие без введения значения по умолчанию, даже если у назначения ранее был задан альтернативный язык.

Эти идентификаторы хранят метаданные языка. Их сохранение не определяет, какой словарь PowerPoint выберет для проверки орфографии или грамматики.

## **Установка языка по умолчанию**

Используйте [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с английским (США) в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для первой текстовой части.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Добавить новую прямоугольную фигуру с текстом.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Проверить язык первой части.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Установка стиля текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Следующий пример задаёт шрифт 14 пунктов полужирным в качестве стиля по умолчанию для абзацев верхнего уровня новой презентации и сохраняет её в "default_text_style.pptx". Текст может наследовать эти настройки, если более конкретное форматирование их не переопределяет.

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

## **Извлечение текста с эффектом «Все заглавные»**

В PowerPoint применение эффекта **All Caps** делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такой текстовой части через Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) и при значении `All` преобразуйте возвращённую строку в верхний регистр.

Этот пример требует файл "sample2.pptx" с текстовым полем в первой фигуре первого слайда. Первая часть первого абзаца содержит "Hello, Aspose!" с применённым эффектом All Caps, как показано ниже.

![The All Caps effect](all_caps_effect.png)

Ниже приведён пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:

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

Для изменения текста в таблице на слайде используйте [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Пройдитесь по ячейкам и обновите каждую через [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) и форматирование абзаца через [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Установите [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) в [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.

Связанная функция: [Format text within slides](/slides/ru/features/text-formatting/).