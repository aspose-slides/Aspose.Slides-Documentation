---
title: Форматирование текста презентации в .NET
linktitle: Форматирование текста
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
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Настройка шрифтов, цветов, выравнивания и других параметров."
---

## **Обзор**

В этой статье рассматривается, как управлять и форматировать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides for .NET. Вы узнаете, как применять функции форматирования текста, такие как выбор шрифта, размер, цвет, подсветка, цвет фона, интервал и выравнивание. Кроме того, рассматривается работа с текстовыми рамками, абзацами, форматирование и расширенные параметры макета, такие как пользовательский поворот и поведение автоподгонки.

Независимо от того, генерируете ли вы презентации программно или настраиваете существующее содержимое, эти примеры помогут создать чёткие, профессионально выглядящие текстовые макеты, которые улучшат ваши слайды и повысит их читаемость.

В приведённых ниже примерах мы будем использовать файл под названием **"sample.pptx"**, содержащий один текстовый блок на первом слайде со следующим текстом:

![Sample text](sample_text.png)

## **Подсветка текста**

Метод [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) позволяет подсвечивать часть текста фоном на основе образца текста.

Чтобы использовать этот метод, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) с входным файлом (PPT, PPTX, ODP и т.д.).
2. Получите нужный слайд из коллекции [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
3. Получите целевую форму из коллекции [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) и приведите её к типу [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
4. Подсвечьте нужный текст, вызвав метод [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/), передав образец текста и цвет.
5. Сохраните презентацию в требуемом формате вывода (например, PPT, PPTX, ODP).

В примере кода ниже подсвечиваются все вхождения символов **"try"** и полного слова **"to"**.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Получить первую фигуру с первого слайда.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Подсветить слово "try" в фигуре.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Подсветить слово "to" в фигуре.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```


Результат:

![The highlighted text](highlighted_text.png)

{{% alert color="primary" %}} 

Aspose предлагает простой, [БЕСПЛАТНЫЙ онлайн‑редактор PowerPoint](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **Подсветка текста с помощью регулярных выражений**

Aspose.Slides for .NET позволяет искать и подсвечивать определённые части текста в слайдах PowerPoint с использованием регулярных выражений. Эта возможность особенно полезна, когда необходимо динамически выделять ключевые слова, шаблоны или данные. Метод [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) позволяет подсвечивать части текста фоном, используя регулярное выражение.

В примере кода ниже подсвечиваются все слова, содержащие **семь и более символов**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Подсветить все слова из семи и более символов.
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


Результат:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Установка цвета фона текста**

Aspose.Slides for .NET позволяет применять фоновые цвета к целым абзацам или отдельным частям текста в слайдах PowerPoint. Эта функция полезна, когда нужно выделять отдельные слова или фразы, привлекать внимание к ключевым сообщениям или улучшать визуальную привлекательность презентаций.

Следующий пример кода показывает, как задать цвет фона для **всего абзаца**: 
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Установить цвет подсветки для всего абзаца.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```


Результат:

![The gray paragraph](gray_paragraph.png)

В примере кода ниже демонстрируется, как задать цвет фона для **частей текста со жирным шрифтом**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```


Результат:

![The gray text portions](gray_text_portions.png)

## **Выравнивание абзацев текста**

Выравнивание текста — ключевой аспект форматирования слайдов, влияющий как на читаемость, так и на визуальную привлекательность. В Aspose.Slides for .NET вы можете точно контролировать выравнивание абзацев внутри текстовых рамок, обеспечивая согласованное представление контента — центрирование, выравнивание по левому, правому краю или по ширине. Этот раздел объясняет, как применять и настраивать выравнивание текста в презентациях PowerPoint.

Следующий пример кода показывает, как выровнять абзац **по центру**:
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

Регулирование прозрачности текста позволяет создавать тонкие визуальные эффекты и улучшать эстетику слайдов. Aspose.Slides for .NET предоставляет возможность задавать уровень прозрачности абзацев и частей текста, упрощая интеграцию текста с фоном или акцентирование отдельных элементов. В этом разделе показано, как применять настройки прозрачности к тексту в презентациях.

В примере кода ниже показано, как задать прозрачность для **всего абзаца**:
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

Следующий пример кода демонстрирует, как задать прозрачность для **частей текста со жирным шрифтом**:
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

Aspose.Slides позволяет задавать интервал между буквами в текстовом блоке. Это позволяет регулировать визуальную плотность строки или блока текста, расширяя или сужая пространство между символами.

Следующий код C# показывает, как расширить интервал между символами в **всём абзаце**:
```cs
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

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

В примере кода ниже показано, как расширить интервал между символами в **частях текста со жирным шрифтом**:
```cs
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

![The character spacing in the text portions](character_spacing_in_text_portions.png)

## **Управление свойствами шрифта текста**

Aspose.Slides for .NET позволяет тонко настраивать параметры шрифта как на уровне абзаца, так и для отдельных частей текста, обеспечивая визуальную согласованность и соответствие требованиям дизайна презентаций. Вы можете задавать стили шрифта, размеры и другие параметры форматирования для целых абзацев, получая больший контроль над внешним видом текста. Этот раздел демонстрирует, как управлять свойствами шрифта для текстовых абзацев на слайде.

Следующий код задаёт шрифт и стиль текста для **всего абзаца**: применяется размер шрифта, полужирное начертание, курсив, пунктирное подчеркивание и шрифт Times New Roman для всех частей абзаца.
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

В примере кода ниже применяются аналогичные свойства к **частям текста со жирным шрифтом**:
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

Поворот текста может улучшить макет слайдов и подчеркнуть определённый контент. С помощью Aspose.Slides for .NET вы можете легко применять поворот к тексту внутри фигур, регулируя угол в соответствии с дизайном. Этот раздел показывает, как задавать и управлять поворотом текста для достижения желаемого визуального эффекта.

Следующий пример кода устанавливает ориентацию текста в форме в значение `Vertical270`, что поворачивает текст **на 90 градусов против часовой стрелки**:
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

## **Установка пользовательского поворота для текстовых рамок**

Задание пользовательского угла поворота для `TextFrame` позволяет позиционировать текст под точными углами, обеспечивая более креативные и гибкие дизайны слайдов. Aspose.Slides for .NET предоставляет полный контроль над поворотом текстовых рамок, упрощая выравнивание текста с другими элементами слайда. В этом разделе показано, как применить конкретный угол поворота к `TextFrame`.

В примере кода ниже текстовая рамка поворачивается на 3 градуса по часовой стрелке внутри формы: 
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

Aspose.Slides предоставляет свойства `SpaceAfter`, `SpaceBefore` и `SpaceWithin` класса [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/), позволяющие управлять межстрочным интервалом абзаца. Эти свойства используются следующим образом:

* Положительное значение задаёт интервал как процент от высоты строки.
* Отрицательное значение задаёт интервал в пунктах.

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

## **Установка типа автоподгонки для текстовых рамок**

Свойство `AutofitType` определяет поведение текста, когда он превышает границы контейнера. Aspose.Slides for .NET позволяет контролировать, должен ли текст сжиматься, выходить за пределы или автоматически изменять размер формы. Этот раздел демонстрирует, как задать `AutofitType` для `TextFrame` с целью эффективного управления расположением текста внутри фигур.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **Установка привязки текстовых рамок**

Привязка определяет, как текст позиционируется внутри фигуры по вертикали. С помощью Aspose.Slides for .NET можно задать тип привязки `TextFrame`, чтобы выровнять текст по верху, центру или низу фигуры. В этом разделе показано, как настроить параметры привязки для достижения желаемого вертикального выравнивания текстового содержимого.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **Установка табуляции текста**

Табуляция помогает организовать текст в чётко структурированные макеты, добавляя одинаковые интервалы между элементами содержимого. Aspose.Slides for .NET поддерживает задание пользовательских табуляционных позиций внутри абзацев текста, позволяя точно контролировать позиционирование текста. Этот раздел демонстрирует, как настроить табуляцию текста для улучшенного выравнивания и форматирования.
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

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет свойство `LanguageId` класса [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/), позволяющее задать язык проверки орфографии для документа PowerPoint. Язык проверки определяет, на каком языке будут проводиться проверка правописания и грамматики в PowerPoint.

Следующий пример кода показывает, как задать язык проверки орфографии для части текста:
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

    // Установить идентификатор проверочного языка.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```


## **Установка языка по умолчанию**

Указание языка по умолчанию для текста обеспечивает корректную проверку орфографии, переносов и работу синтеза речи в PowerPoint. Aspose.Slides for .NET позволяет задавать язык на уровне части текста или абзаца. В этом разделе показано, как определить язык по умолчанию для текста вашей презентации.
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

Если необходимо применить одинаковое форматирование ко всем текстовым элементам презентации одновременно, можно использовать свойство `DefaultTextStyle` интерфейса [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) и определить предпочтительные параметры форматирования.

Следующий пример кода показывает, как задать жирный шрифт размером 14 пунктов по умолчанию для всего текста на слайдах новой презентации.
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


## **Извлечение текста с эффектом All‑Caps**

В PowerPoint применение эффекта **All Caps** заставляет текст отображаться заглавными буквами на слайде, даже если он был введён строчными. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст в том виде, в каком он был введён. Чтобы корректно обработать это, проверьте [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) — если он указывает `All`, просто преобразуйте полученную строку в верхний регистр, чтобы ваш вывод соответствовал тому, что видно на слайде.

Предположим, что на первом слайде файла **sample2.pptx** находится следующий текстовый блок.

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

Для изменения текста в таблице на слайде необходимо использовать объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Можно пройтись по всем ячейкам таблицы и изменить текст в каждой ячейке, получив её `TextFrame` и свойства `ParagraphFormat`.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте свойство `FillFormat` класса [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). Установите `FillFormat` в `Gradient`, где можно задать начальный и конечный цвета градиента, а также другие параметры, такие как направление и прозрачность, чтобы создать градиентный эффект для текста.