---
title: Поиск и замена текста в презентациях PowerPoint на .NET
linktitle: Поиск и замена текста
type: docs
weight: 55
url: /ru/net/search-and-replace-text/
keywords:
- поиск текста
- выделение текста
- замена текста
- регулярное выражение
- обратный вызов результата
- текстовый кадр
- отчет аудита
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Поиск, выделение и замена текста в презентациях PowerPoint с одновременным сбором всех совпадений с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET может выполнять поиск, выделение и замену текста в отдельном текстовом кадре или во всей презентации. Каждая операция также может уведомлять приложение о каждом найденном совпадении через обратный вызов результата. Это позволяет обновлять презентацию и одновременно формировать журнал аудита, содержащий найденный текст, его контекст, позицию, текстовый кадр и номер слайда.

Эти возможности полезны для проверки, редактирования, проверки терминологии, очистки шаблонов и автоматизированных процессов формирования отчетов.

В первых примерах ниже используется файл с именем "sample.pptx", содержащий один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выберите область поиска**

Используйте методы [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) для ограничения операции одним текстовым кадром. Используйте методы [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) для обработки всего применимого текста в презентации.

| Операция | Один текстовый кадр | Вся презентация |
|---|---|---|
| Highlight literal text | [ITextFrame.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/highlighttext/) |
| Highlight regular-expression matches | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/highlightregex/) |
| Replace literal text | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/replacetext/) |
| Replace regular-expression matches | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/replaceregex/) |

## **Настройка сопоставления текста**

Для операций с буквальным текстом используйте [TextSearchOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/) для управления сопоставлением:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/wholewordsonly/) ограничивает совпадения полными словами.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/casesensitive/) определяет, должен ли учитываться регистр символов.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/includenotes/) включает заметки слайдов в операции поиска, замены и выделения на уровне презентации.

Операции с регулярными выражениями используют .NET `Regex`, поэтому правила сопоставления, такие как чувствительность к регистру и границы слов, задаются выражением и его параметрами.

## **Сбор информации о совпадениях с помощью обратного вызова**

Реализуйте [IFindResultCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/ifindresultcallback/) , чтобы получать уведомление о каждом совпадении. Его метод [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/ru/net/aspose.slides/ifindresultcallback/foundresult/) предоставляет связанный текстовый кадр, исходный текст, найденный текст и позицию совпадения.

Обратный вызов не получает номер слайда напрямую. Ниже представлена реализация, которая извлекает его из родительского слайда и также обрабатывает текст, найденный в заметках слайда. nullable‑номер слайда позволяет одной модели результата представлять текст, связанный с другими типами слайдов.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Для операций замены `FoundText` содержит оригинальный найденный текст, поэтому обратный вызов может точно зафиксировать, какие термины были заменены.

## **Выделение текста**

Используйте метод [ITextFrame.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlighttext/) для выделения совпадений буквального текста в текстовом кадре. Передайте [TextSearchOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/) для управления поиском и обратный вызов для сбора деталей совпадений.

Пример кода ниже выделяет все вхождения символов **"try"**, а затем выделяет только полное слово **"to"**. Оба поиска передают свои результаты одному и тому же обратному вызову.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделение текста с использованием регулярных выражений**

Метод [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlightregex/) выделяет текст, найденный регулярным выражением, в текстовом кадре.

Следующий код выделяет все слова, содержащие семь и более символов, и собирает каждое совпадение:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

Результат:

![Выделенный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Выделение текста во всей презентации**

Используйте [Presentation.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/highlighttext/) и [Presentation.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/highlightregex/) для поиска по всем применимым текстовым кадрам в презентации. В следующем примере выделяется буквальный термин и все электронные адреса при сохранении отдельных коллекций результатов для двух поисков.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Замена текста в текстовом кадре**

Используйте [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replacetext/) для буквального текста и [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replaceregex/) для замены по шаблону. Эти методы обновляют найденный текст внутри существующего кадра, сохраняя форматирование окружающих частей, вместо перестроения кадра из простой строки.

В следующем примере стандартизируется вариант написания, а затем заменяются метки версий. Тот же обратный вызов фиксирует оригинальные термины, найденные обеими операциями.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Если одно совпадение охватывает части с разным форматированием, проверьте результат, чтобы убедиться, какое форматирование должно применяться к заменяемому тексту.

## **Замена текста во всей презентации**

Используйте [Presentation.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/replacetext/) и [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/replaceregex/) для применения тех же операций по всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Группировка совпадений для отчетов**

Поскольку каждый результат хранит номер слайда и текстовый кадр, приложения могут группировать совпадения для аудита, составления отчетов или процессов проверки. Ниже пример группировки собранных результатов сначала по слайдам, затем по текстовым кадрам:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **Часто задаваемые вопросы**

**Как выполнить поиск только в одном текстовом блоке, а не во всей презентации?**

Получите текстовый кадр формы и вызовите [ITextFrame.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replacetext/) или [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replaceregex/) для этого текстового кадра. Методы уровня презентации обрабатывают все применимые текстовые кадры вместо этого.

**Как подобрать полные слова с правильным регистром?**

Установите [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/wholewordsonly/) и [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/casesensitive/) в `true` и передайте параметры в метод выделения или замены буквального текста. Для регулярных выражений определите границы слов и чувствительность к регистру непосредственно в `Regex`.

**Может ли поиск и замена включать текст в заметках слайдов?**

Да. Установите [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/includenotes/) в `true` при использовании операции с буквальным текстом на уровне презентации. Реализация обратного вызова, показанная выше, сопоставляет совпадение в слайде заметок с номером его родительского слайда.

**Как создать отчет без повторного сканирования презентации?**

Передайте реализацию [IFindResultCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/ifindresultcallback/) в операцию выделения или замены. Обратный вызов получает каждое совпадение во время выполнения операции, позволяя приложению сохранять исходный текст, найденный текст, позицию, текстовый кадр и вычисленный номер слайда для последующей группировки или экспорта.

**Сохраняет ли замена текста его форматирование?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replacetext/) и [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replaceregex/) изменяют найденный текст внутри существующего кадра и сохраняют форматирование окружающих частей. Если совпадение охватывает области с разным форматированием, проверьте результат, чтобы убедиться, что замена использует требуемый стиль.