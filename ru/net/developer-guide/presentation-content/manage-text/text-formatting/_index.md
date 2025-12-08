---
title: Форматирование текста PowerPoint на C#
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
- межбуквенный интервал
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
- C#
- Aspose.Slides
description: "Узнайте, как форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Настройте шрифты, цвета, выравнивание и многое другое с помощью мощных примеров кода на C#."
---

## **Обзор**

Эта статья рассказывает, как управлять и форматировать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides for .NET. Вы узнаете, как применять функции форматирования текста, такие как выбор шрифта, размер, цвет, выделение, цвет фона, интервал и выравнивание. Кроме того, рассматривается работа с текстовыми рамками, абзацами, форматированием и расширенными параметрами макета, такими как пользовательское вращение и поведения автоподгонки.

Независимо от того, генерируете ли вы презентации программно или настраиваете существующее содержание, эти примеры помогут создать чёткие, профессионально выглядящие текстовые макеты, которые улучшат ваши слайды и повысит читаемость.

В примерах ниже мы будем использовать файл «sample.pptx», который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выделение текста**

Метод [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) позволяет выделять часть текста фоновым цветом на основе образца текста.

Чтобы использовать этот метод, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) с входным файлом (PPT, PPTX, ODP и т.д.).
2. Получите нужный слайд, используя коллекцию [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).
3. Получите целевую форму из коллекции [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) и приведите её к типу [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
4. Выделите нужный текст, используя метод [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/), указав образец текста и цвет.
5. Сохраните презентацию в нужном выходном формате (например, PPT, PPTX, ODP).

Ниже приведён пример кода, который выделяет все вхождения символов **"try"** и полного слова **"to"**.
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

![Выделенный текст](highlighted_text.png)

{{% alert color="primary" %}} 

Aspose предоставляет простой, [БЕСПЛАТНЫЙ онлайн-редактор PowerPoint](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **Выделение текста с использованием регулярных выражений**

Aspose.Slides for .NET позволяет искать и выделять определённые части текста в слайдах PowerPoint с помощью регулярных выражений. Эта функция особенно полезна, когда необходимо динамически подчёркивать ключевые слова, шаблоны или данные. Метод [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) позволяет выделять части текста фоновым цветом, используя регулярное выражение.

Ниже пример кода, который выделяет все слова, содержащие **семь или более символов**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Выделить все слова, содержащие семь или более символов.
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


Результат:

![Выделенный текст с помощью регулярного выражения](highlighted_text_using_regex.png)

## **Установка фонового цвета текста**

Aspose.Slides for .NET позволяет применять фоновые цвета ко всему абзацу или отдельным частям текста в слайдах PowerPoint. Это полезно, когда нужно выделить конкретные слова или фразы, привлечь внимание к ключевым сообщениям или улучшить визуальную привлекательность презентаций.

Ниже пример кода, показывающий, как задать фоновый цвет для **всего абзаца**: 
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

![Серый абзац](gray_paragraph.png)

Ниже пример кода, демонстрирующий, как задать фоновый цвет для **частей текста с полужирным шрифтом**:
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

![Серые части текста](gray_text_portions.png)

## **Выравнивание абзацев текста**

Выравнивание текста — ключевой аспект форматирования слайдов, влияющий как на читаемость, так и на визуальную привлекательность. В Aspose.Slides for .NET вы можете точно управлять выравниванием абзацев внутри текстовых рамок, обеспечивая единообразное представление содержимого — по центру, слева, справа или по ширине. Этот раздел объясняет, как применять и настраивать выравнивание текста в презентациях PowerPoint.

Ниже пример кода, показывающий, как выровнять абзац по **центру**:
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

## **Установка прозрачности для текста**

Регулирование прозрачности текста позволяет создавать тонкие визуальные эффекты и улучшать эстетику слайдов. Aspose.Slides for .NET предоставляет возможность задавать уровень прозрачности абзацев и частей текста, упрощая сочетание текста с фоном или акцентирование отдельных элементов. Этот раздел показывает, как применять настройки прозрачности к тексту в ваших презентациях.

Ниже пример кода, показывающий, как применить прозрачность к **всему абзацу**:
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

Ниже пример кода, показывающий, как применить прозрачность к **частям текста с полужирным шрифтом**:
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

![Прозрачные части текста](transparent_text_portions.png)

## **Установка межбуквенного интервала для текста**

Aspose.Slides позволяет задавать интервал между буквами в текстовом блоке. Это даёт возможность регулировать визуальную плотность строки или блока текста, расширяя или сжимая пространство между символами.

Ниже пример кода C#, показывающий, как расширить межбуквенный интервал в **всём абзаце**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Примечание: используйте отрицательные значения для сжатия межбуквенного интервала.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Расширить межбуквенный интервал.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


Результат:

![Межбуквенный интервал в абзаце](character_spacing_in_paragraph.png)

Ниже пример кода, показывающий, как расширить межбуквенный интервал в **частях текста с полужирным шрифтом**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Примечание: используйте отрицательные значения для сжатия межбуквенного интервала.
            portion.PortionFormat.Spacing = 3;  // Расширить межбуквенный интервал.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```


Результат:

![Межбуквенный интервал в частях текста](character_spacing_in_text_portions.png)

## **Управление свойствами шрифта текста**

Aspose.Slides for .NET позволяет точно настраивать параметры шрифта как на уровне абзаца, так и для отдельных частей текста, обеспечивая визуальную согласованность и соответствие требованиям дизайна презентации. Вы можете задавать стили шрифта, размеры и другие параметры форматирования для всех частей абзаца, получая больший контроль над отображением текста. Этот раздел демонстрирует, как управлять свойствами шрифта для текстовых абзацев в слайде.

Ниже пример кода, задающий шрифт и стиль текста для **всего абзаца**: применяется размер шрифта, полужирный, курсив, пунктирное подчёркивание и шрифт Times New Roman для всех частей абзаца.
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

![Свойства шрифта абзаца](font_properties_for_paragraph.png)

Ниже пример кода, применяющий аналогичные свойства к **частям текста с полужирным шрифтом**:
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

![Свойства шрифта частей текста](font_properties_for_text_portions.png)

## **Установка вращения текста**

Вращение текста может улучшить макет слайдов и помочь подчеркнуть определённое содержание. С помощью Aspose.Slides for .NET вы легко можете применять вращение текста внутри фигур, задавая угол в соответствии с дизайном. Этот раздел демонстрирует, как задать и контролировать вращение текста для достижения нужного визуального эффекта.

Ниже пример кода, устанавливающий ориентацию текста в фигуре в `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:
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

## **Установка пользовательского вращения для текстовых рамок**

Задание пользовательского угла вращения для `TextFrame` позволяет позиционировать текст под точными углами, открывая возможности более креативных и гибких дизайнов слайдов. Aspose.Slides for .NET предоставляет полный контроль над вращением текстовых рамок, упрощая выравнивание текста с другими элементами слайда. Этот раздел покажет, как применить конкретный угол вращения к `TextFrame`.

Ниже пример кода, вращающий текстовую рамку на 3 градуса по часовой стрелке внутри фигуры: 
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

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет свойства `SpaceAfter`, `SpaceBefore` и `SpaceWithin` в классе [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/), позволяя управлять межстрочным интервалом абзаца. Эти свойства используются следующим образом:

* Положительное значение указывает межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

Ниже пример кода, показывающий, как задать межстрочный интервал внутри абзаца:
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

## **Установка типа автоподгонки для текстовых рамок**

Свойство `AutofitType` определяет, как текст ведёт себя, когда превышает границы контейнера. Aspose.Slides for .NET позволяет контролировать, должен ли текст сжиматься, выходить за пределы или автоматически изменять размер фигуры. Этот раздел демонстрирует, как задать `AutofitType` для `TextFrame` для эффективного управления расположением текста внутри фигур.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **Установка привязки текстовых рамок**

Привязка определяет, как текст позиционируется внутри фигуры по вертикали. С помощью Aspose.Slides for .NET вы можете задать тип привязки `TextFrame`, чтобы выровнять текст к верхней, средней или нижней части фигуры. Этот раздел показывает, как настроить параметры привязки для достижения желаемого вертикального выравнивания текста.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **Установка табуляции текста**

Табуляция помогает организовать текст в хорошо структурированные макеты, добавляя согласованные интервалы между элементами содержимого. Aspose.Slides for .NET поддерживает настройку пользовательских позиций табуляции внутри абзацев текста, позволяя точно управлять размещением текста. Этот раздел демонстрирует, как настроить табуляцию текста для улучшенного выравнивания и форматирования.
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

## **Установка языка проверки правописания**

Aspose.Slides предоставляет свойство `LanguageId` класса [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/), которое позволяет задать язык проверки правописания для документа PowerPoint. Язык проверки определяет, какой язык будет использоваться для проверки орфографии и грамматики в PowerPoint.

Ниже пример кода, показывающий, как задать язык проверки правописания для части текста:
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

Указание языка по умолчанию для текста обеспечивает корректную проверку орфографии, переносов и синтез речи в PowerPoint. Aspose.Slides for .NET позволяет задавать язык на уровне части текста или абзаца. Этот раздел показывает, как определить язык по умолчанию для текста вашей презентации.
```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Добавить новую прямоугольную форму с текстом.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Проверить язык первой части.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```


## **Установка стиля текста по умолчанию**

Если необходимо применить одинаковое форматирование текста ко всем элементам презентации одновременно, вы можете использовать свойство `DefaultTextStyle` интерфейса [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) и задать предпочитаемое форматирование.

Ниже пример кода, показывающий, как задать полужирный шрифт размером 14 пунктов по умолчанию для всего текста на слайдах новой презентации.
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


## **Извлечение текста с эффектом «Все прописные»**

В PowerPoint применение эффекта **All Caps** делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такой части текста с помощью Aspose.Slides библиотека возвращает оригинальный ввод. Чтобы обработать это, проверьте [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) — если он указывает `All`, просто преобразуйте полученную строку в верхний регистр, чтобы ваш вывод соответствовал тому, что видят пользователи на слайде.

Предположим, что на первом слайде файла sample2.pptx находится следующий текстовый блок.

![Эффект All Caps](all_caps_effect.png)

Ниже пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:
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

Для изменения текста в таблице на слайде необходимо использовать объект [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Вы можете перебрать все ячейки таблицы и изменить текст в каждой, получая доступ к её `TextFrame` и параметрам `ParagraphFormat`.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте свойство `FillFormat` в классе [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). Установите `FillFormat` в `Gradient`, где можно задать начальный и конечный цвета градиента, а также другие параметры, такие как направление и прозрачность, для создания градиентного эффекта в тексте.