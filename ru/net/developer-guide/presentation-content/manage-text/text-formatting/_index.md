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
- поворот текста
- угол поворота
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- якорь текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for .NET. Описываются цвета фона, прозрачность, межсимвольный интервал, свойства шрифтов, поворот, интервал абзацев, поведение автоподгонки, привязка текста, табуляторы и настройки языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, и его первый абзац содержит показанный ниже текст. Индексы слайдов и фигур нумеруются с нуля. Примеры, выбирающие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/net/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) для установки цвета подсветки по умолчанию для абзаца, либо используйте [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) для отдельных фрагментов текста.

В следующем примере задаётся светло‑серая подсветка по умолчанию для первого абзаца. Явные цвета подсветки отдельных фрагментов имеют приоритет над этим значением по умолчанию:

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

Пример кода ниже демонстрирует, как установить цвет фона для **текстовых фрагментов с жирным шрифтом**:

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
        // Установить цвет подсветки для текстового фрагмента.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Серые текстовые фрагменты](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) для установки выравнивания абзаца внутри текстового кадра. Значение может быть по центру, по левому краю, по правому краю, выровнено по ширине и т.д.

В следующем примере кода показано, как выровнять абзац **по центру**:

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

Используйте [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) для вертикального выравнивания фрагментов текста разных размеров шрифта в строке. Этот параметр применяется ко всему абзацу и регулирует выравнивание в каждой из его строк.

В следующем самостоятельном примере создаются четыре помеченных текстовых поля на одном слайде. Каждый абзац содержит одинаковый текст размером 18, 36 и 54 пункта, с разным выравниванием шрифта. Используется Arial, отключена автоподгонка и перенос, а текстовые кадры достаточны для одной строки.

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

![Сравнение выравнивания шрифтов по базовой линии, вершине, центру и низу при смешанных размерах шрифта](font_alignment.png)

Выравнивание шрифтов использует метрики шрифта, поэтому видимые границы отдельных букв не обязательно будут точно совпадать. В примере присутствуют как заглавная буква, так и нижний вынос, чтобы показать разницу между выравниванием по базовой линии и нижнему выравниванию. Доступность и подстановка шрифтов, используемые символы и различие в размерах шрифтов влияют на результат. Размеры кадра, поля, межстрочный интервал, перенос и автоподгонка также влияют на расположение; при сопоставлении режимов используйте одинаковые шрифты и параметры макета.

Этот параметр отличается от [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), который управляет горизонтальным выравниванием абзаца, и от [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), который позиционирует текстовый блок вертикально внутри его фигуры. Форматирование надстрочного и подстрочного текста через [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) сдвигает отдельные фрагменты относительно базовой линии, а не устанавливает выравнивание шрифта для строк абзаца.

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

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

// Установить полупрозрачную черную заливку для текста.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **текстовым фрагментам с жирным шрифтом**:

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
        // Установить прозрачность текстового фрагмента.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установить межсимвольный интервал текста**

Используйте [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) для увеличения или уменьшения интервала между символами в текстовом поле. В примерах добавляется интервал в 3 пункта; отрицательные значения сжимаются текст.

Следующий код C# показывает, как расширить межсимвольный интервал в **всём абзаце**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Примечание: используйте отрицательные значения, чтобы сжать межсимвольный интервал.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Увеличить межсимвольный интервал.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как расширить межсимвольный интервал в **текстовых фрагментах с жирным шрифтом**:

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
        // Примечание: используйте отрицательные значения, чтобы сжать межсимвольный интервал.
        portion.PortionFormat.Spacing = 3;  // Увеличить межсимвольный интервал.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Межсимвольный интервал в текстовых фрагментах](character_spacing_in_text_portions.png)

### **Отключить кёрнинг для отдельных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть чуть более плотно, чем тот же текст в PowerPoint. Это происходит потому, что PowerPoint может игнорировать данные кёрнинга для некоторых шрифтов, даже если шрифт содержит корректные данные кёрнинга и кёрнинг включён в настройках PowerPoint.

Чтобы в таких случаях отрисовка была ближе к PowerPoint, можно отключить кёрнинг для фрагментов текста, использующих проблемный шрифт. Установите [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) в значение, превышающее фактический размер шрифта. В этом примере требуется файл “presentation.pptx” с текстовым полем в качестве первой фигуры на первом слайде. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для фрагментов, использующих Roboto. Это отключает кёрнинг для соответствующих фрагментов с размером шрифта менее 100 пунктов:

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

Для текста, попадающего под порог, данная настройка предотвращает кёрнинг и может помочь согласовать отрисовку Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) или для отдельных фрагментов через [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Следующий пример задаёт для первого абзаца шрифт Times New Roman размером 12 пунктов с жирным, курсивом и пунктирным подчёркиванием. Явное форматирование отдельных фрагментов имеет приоритет над этими значениями по умолчанию:

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

Следующий пример применяет к фрагментам, у которых эффективное форматирование жирное, шрифт Times New Roman размером 13 пунктов, курсив и пунктирное подчёркивание:

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
        // Установить свойства шрифта для текстового фрагмента.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Результат:

![Свойства шрифта для текстовых фрагментов](font_properties_for_text_portions.png)

## **Управление нормализацией высоты текста**

Используйте [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) при воспроизведении типографики шаблона или исследовании различий в высоте символов. В PowerPoint включение нормализации растягивает или сжимает отдельные символы по вертикали, чтобы придать им одинаковую видимую высоту внутри текстового фрагмента. Это не гарантирует одинаковую высоту текста между разными шрифтами.

Установите свойство в [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) для явного включения или отключения нормализации. `NullableBool.NotDefined` оставляет локальную настройку необъявленной, позволяя фрагменту наследовать значение, например, из [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) абзаца. Это не то же самое, что `False`. Используйте [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) и читайте [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) для получения раскрытого булевого значения.

Следующий самостоятельный пример требует установленный **Arial**. Он создаёт два блока текста, содержащих одинаковые прописные буквы, строчные буквы, нижние выносы и символы с диакритикой размером 54 пункта. Оба абзаца по умолчанию включают нормализацию. Верхний фрагмент явно отключает её; нижний наследует её. Размеры кадров, поля и интервал абзацев одинаковы, перенос и автоподгонка отключены, чтобы сравнение было последовательным. Пример выводит `False: False` и `NotDefined: True`, затем сохраняет “text_height_normalization.pptx”.

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

Сравнение ниже экспортировано из сохранённой презентации. В верхней строке нормализация отключена (`False`); в нижней строке наследуется включённое значение (`NotDefined` → `True`). Оставьте установленный Arial, чтобы воспроизвести внешний вид.

![Текст Arial 54 пт с отключённой нормализацией сверху и наследованной нормализацией снизу](text_height_normalization.png)

Нормализация изменяет высоту символов без изменения назначенного значения [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/), которое указывает размер шрифта в пунктах. Интервал [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) абзаца управляет межстрочным интервалом, а [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) текстового кадра контролирует, как текст или его контейнер подстраивается под размер. Эти настройки служат разным целям и могут независимо влиять на общую раскладку. Подробнее о форматировании абзацев и наследовании читайте в разделе [Manage Paragraph](/slides/ru/net/manage-paragraph/).

## **Применить и удалить зачеркивание**

Используйте [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) на текстовом фрагменте, чтобы отобразить исправления, отменённые термины или прежние цены без удаления исходного текста. Установите его в [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) для одной или двух линий через текст.

Чтобы удалить зачеркивание, задайте `TextStrikethroughType.None`. Это явно отключает эффект, даже если окружающее форматирование указывает зачеркивание. В отличие от этого, `TextStrikethroughType.NotDefined` оставляет локальную настройку неопределённой, позволяя фрагменту наследовать форматирование, например, из абзаца. Это не гарантирует, что зачеркивание будет удалено. Используйте [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) для чтения получившегося форматирования, включая унаследованные значения.

Следующий самостоятельный пример создаёт три сравнения цен. Каждый абзац имеет отдельные фрагменты для метки, прежней цены и текущей цены, поэтому только прежняя цена подвергается зачеркиванию. В первой строке зачеркивание применяется, а затем удаляется; в остальных строках остаются одиночное и двойное зачеркивание. Изменение этого свойства сохраняет текст и остальные его параметры, включая жирную прежнюю цену.

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

Результат сверху вниз: без зачеркивания, одиночное зачеркивание и двойное зачеркивание.

![Прежние цены без зачеркивания, с одиночным зачеркиванием и с двойным зачеркиванием](strikethrough.png)

## **Установить поворот текста**

Используйте [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) для установки предопределённой ориентации текста внутри фигуры.

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

![Поворот текста](text_rotation.png)

## **Отображать цифры рядом в вертикальном тексте**

Чтобы удержать двухзначное число вместе в вертикальной японской метке, поместите обе цифры в один текстовый фрагмент и задайте [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) для этого фрагмента. В примере используется [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) и шрифт MS Gothic размером 40 пунктов для обеих меток. Единственное различие — значение [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), присвоенное числовому фрагменту.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

В PowerPoint левая метка (`True`) показывает цифры вертикально и рядом между 和 и 年. В правой метке (`False`) пара повёрнута на 90 градусов по часовой стрелке. Окружающие японские символы остаются вертикальными в обеих метках.

![Сравнение вертикальных дат: цифры вертикально слева и повёрнуты справа](vertical_date.png)

## **Установить пользовательский поворот для текстовых кадров**

Используйте [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) для задания пользовательского угла поворота для [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

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

![Пользовательский поворот текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) и [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) для управления интервалом абзацев. Эти свойства используются следующим образом:

* Укажите положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Укажите отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца в 200 % от высоты строки (двойной интервал):

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

## **Управление разрывами строк**

Правила разрыва строк абзаца полезны в узких текстовых блоках и презентациях, где смешаны латинский и восточно‑азиатский тексты. Следующие свойства принадлежат [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), поэтому они применяются ко всему абзацу:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) управляет правилами разрыва латинского текста. В смешанном тексте его изменение может также изменить места переноса соседнего восточно‑азиатского текста и знаков препинания.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) управляет правилами разрыва восточно‑азиатского текста, включая ограничения на символы в начале и в конце строки.

Эти правила не заменяют [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), который включает автоматический перенос внутри текстового кадра. Они влияют на раскладку, когда происходит перенос; они не вставляют символы разрыва строки. Явный разрыв строки принудительно создаёт новую строку в абзаце независимо от доступной ширины.

Следующий самостоятельный пример создаёт узкий текстовый блок, содержащий китайский и латинский тексты. Он явно задаёт оба свойства разрыва строк и сохраняет “line_breaking.pptx”. Чтобы экспериментировать с любым правилом, изменяйте значение этого свойства, оставляя остальные настройки неизменными. В примере используется шрифт Arial 24 пт и SimSun, ширина кадра 160 пт и нулевые горизонтальные отступы текстового кадра. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) установлен в [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/), чтобы размеры текста и кадра оставались фиксированными.

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) позволяет допускаемым знакам пунктуации выступать за правый край строки вместо того, чтобы занимать следующую строку. Он применяется к всему абзацу и отличается от висячего отступа.

Следующий самостоятельный пример включает висячую пунктуацию в текстовом кадре шириной 100 пт и сохраняет “hanging_punctuation.pptx”. При использовании Arial 24 пт и нулевых горизонтальных отступов конечная точка остаётся после слова «sentence» и выступает за правый край текста. Установите свойство в [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), чтобы сравнить: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы ширина оставалась фиксированной.

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

Не каждый знак пунктуации может «висеть». Приведённые выше [условия шрифта и макета](#control-line-breaking) также применимы к этому сравнению: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать видимую разницу.

## **Установить тип автоподгонки для текстовых кадров**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за пределы или автоматически изменять размер фигуры. Следующий пример конфигурирует фигуру так, чтобы она масштабировалась под текст, и сохраняет результат в “autofit_type.pptx”.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняются строки текста или ширина фигуры, см. [Count Rendered Lines](/slides/ru/net/manage-paragraph/). Только количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых кадров**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, по центру или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в “text_anchor.pptx”.

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

Используйте [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) и [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) для настройки табуляций в абзаце. Следующий пример задаёт интервал табуляции по умолчанию в 100 пунктов и добавляет левый табулятор на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

![Табуляция абзаца](paragraph_tabs.png)

## **Установить язык проверки правописания**

Aspose.Slides предоставляет [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), который позволяет задать язык проверки правописания для текстового фрагмента. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует файл “presentation.pptx” с текстовым полем в качестве первой фигуры на первом слайде и хотя бы один абзац. Он заменяет содержимое первого абзаца на “1。”, задаёт SimSun в качестве шрифта и назначает упрощённый китайский язык проверки (`zh-CN`). Результат сохраняется в “proofing_language.pptx”:

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

### **Копировать метаданные языка**

При копировании многоязычного текста из шаблона сохраняйте как [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), так и [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). Следующий самостоятельный пример создаёт исходный фрагмент с английским (США) в качестве языка и французским в качестве альтернативного языка и копирует текст и идентификаторы в фрагмент новой презентации.

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
    // Если у источника нет альтернативного языка, null очищает значение получателя.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Чтобы попробовать источник без альтернативного языка, опустите присвоение `"fr-FR"`. В этом случае альтернативный идентификатор будет `null`, и тот же оператор копирования сохраняет его отсутствие без ввода значения по умолчанию, даже если у назначения ранее был задан альтернативный язык.

Эти идентификаторы хранят метаданные языка. Сохранение их не определяет, какой словарь PowerPoint выберет для проверки орфографии или грамматики.

## **Установить язык по умолчанию**

Используйте [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с английским (США) в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для его первого текстового фрагмента.

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

// Проверить язык первого фрагмента.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Следующий пример задаёт шрифт 14 пт, жирный, в качестве стиля по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в “default_text_style.pptx”. Текст может наследовать эти значения по умолчанию, если более специфичное форматирование их не переопределит.

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

## **Извлечение текста с эффектом всех заглавных**

В PowerPoint применение эффекта **All Caps** делает текст отображаемым заглавными буквами на слайде, даже если он изначально введён строчными. При получении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) и при значении `All` преобразуйте полученную строку в верхний регистр.

Этот пример требует файл “sample2.pptx” с текстовым полем в качестве первой фигуры на первом слайде. Первый абзац его первого фрагмента содержит “Hello, Aspose!” с применённым эффектом All Caps, как показано ниже.

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

## **Вопросы и ответы**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Перебирайте ячейки и обновляйте каждую через [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) и форматирование абзацев через [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Установите [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) в [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.

Related feature: [Форматировать текст в слайдах](/slides/ru/features/text-formatting/).