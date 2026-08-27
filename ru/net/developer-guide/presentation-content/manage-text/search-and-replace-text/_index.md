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
- текстовый фрейм
- аудиторский отчет
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Поиск, выделение и замена текста в презентациях PowerPoint с одновременным сбором всех совпадений с помощью Aspose.Slides for .NET."
---
## **Обзор**

Aspose.Slides for .NET может выполнять поиск, выделение и замену текста в отдельном текстовом фрейме или во всей презентации. Каждая операция также может уведомлять приложение о каждом совпадении через обратный вызов результата. Это позволяет обновлять презентацию и одновременно создавать журнал аудита, содержащий найденный текст, его контекст, позицию, текстовый фрейм и номер слайда.

Эти возможности полезны для рецензирования, редактирования, проверки терминологии, очистки шаблонов и автоматизированных процессов генерации отчетов.

В первых примерах ниже мы используем файл с именем "sample.pptx", содержащий один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выберите область поиска**

Используйте методы интерфейса [ITextFrame] для ограничения операции одним текстовым фреймом. Используйте методы класса [Presentation] для обработки всего применимого текста в презентации.

| Операция | Один текстовый фрейм | Вся презентация |
|---|---|---|
| Выделить дословный текст | [ITextFrame.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/highlighttext/) |
| Выделить совпадения регулярного выражения | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/highlightregex/) |
| Заменить дословный текст | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/replacetext/) |
| Заменить совпадения регулярного выражения | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/replaceregex/) |

## **Настройка сопоставления текста**

Для операций с дословным текстом используйте [TextSearchOptions] для управления сопоставлением:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/wholewordsonly/) ограничивает совпадения полными словами.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/casesensitive/) управляет тем, должно ли учитываться регистр символов.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/includenotes/) включает заметки слайдов в поиск, замену и выделение на уровне презентации.

Операции с регулярными выражениями используют .NET `Regex`, поэтому правила сопоставления, такие как чувствительность к регистру и границы слов, задаются выражением и его параметрами.

## **Определение владельца текстового фрейма**

Общие рабочие процессы обработки текста часто получают объект [ITextFrame] при поиске, замене, проверке или экспорте текста. Используйте [ITextFrame.ParentShape] и [ITextFrame.ParentCell], чтобы определить, какой объект презентации владеет этим текстовым фреймом.

Ожидаемые значения зависят от владельца:

| Владелец текстового фрейма | `ParentShape` | `ParentCell` |
|---|---|---|
| Автофигура или другая фигура, содержащая текст | The owning [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/) | `null` |
| Ячейка таблицы | `null` | The owning [ICell](https://reference.aspose.com/slides/ru/net/aspose.slides/icell/) |

Оба свойства являются навигационными только для чтения. Их чтение не перемещает текстовый фрейм и не меняет его владельца. Общий код должен проверять оба значения на `null` и учитывать возможность, что ни один владелец недоступен.

В следующем примере используется [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/ru/net/aspose.slides.util/slideutil/getalltextframes/) для перебора текстовых фреймов в презентации. Для фигур он выводит имя фигуры, тип фигуры и содержащий слайд. Для ячеек таблицы он выводит нулевые координаты столбца и строки и содержащий слайд.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Для содержимого SmartArt перебирайте фигуры в [ISmartArtNode.Shapes](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/ismartartnode/shapes/) и получайте доступ к каждому [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/ismartartshape/textframe/). Текстовый фрейм можно отследить к связанной фигуре через [ITextFrame.ParentShape](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/parentshape/), тогда как [ITextFrame.ParentCell](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/parentcell/) равно `null`. Поэтому ветка фигур в примере также обрабатывает текст из узлов SmartArt.

## **Сбор информации о совпадениях с помощью обратного вызова**

Реализуйте [IFindResultCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/ifindresultcallback/) чтобы получать уведомление о каждом совпадении. Его метод [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/ru/net/aspose.slides/ifindresultcallback/foundresult/) предоставляет связанный текстовый фрейм, исходный текст, найденный текст и позицию совпадения.

Обратный вызов не получает номер слайда напрямую. Реализация ниже выводит его из родительского слайда и также обрабатывает текст, найденный в заметках слайда. nullable номер слайда позволяет одной модели результата представлять текст, связанный с другими типами слайдов.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

Для операций замены `FoundText` содержит исходный найденный текст, поэтому обратный вызов может точно зафиксировать, какие термины были заменены.

## **Выделение текста**

Используйте метод [ITextFrame.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlighttext/) для выделения совпадений дословного текста в текстовом фрейме. Передайте [TextSearchOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/) для управления поиском и обратный вызов для сбора деталей совпадений.

Пример кода ниже выделяет все вхождения символов **"try"**, а затем выделяет только полное слово **"to"**. Оба поиска передают свои совпадения в один и тот же обратный вызов.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Получить первую фигуру с первого слайда.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Выделить каждое вхождение "try" в текстовом фрейме.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Выделить только полное слово "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделение текста с помощью регулярных выражений**

Метод [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlightregex/) выделяет совпадения текста, найденные регулярным выражением, в текстовом фрейме.

Следующий код выделяет все слова, содержащие семь или более символов, и собирает каждое совпадение:

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

## **Выделение текста по всей презентации**

Используйте [Presentation.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/highlighttext/) и [Presentation.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/highlightregex/) для поиска во всех применимых текстовых фреймах презентации. В следующем примере выделяется дословный термин и все адреса электронной почты, при этом сохраняются отдельные коллекции результатов для двух поисков.

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

## **Замена текста в текстовом фрейме**

Используйте [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replacetext/) для дословного текста и [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replaceregex/) для замены по шаблону. Эти методы обновляют найденный текст в существующем текстовом фрейме, сохраняя форматирование окружающих частей, вместо пересоздания фрейма из обычной строки.

В следующем примере стандартизируется вариант написания, а затем заменяются метки версий. Один и тот же обратный вызов фиксирует исходные термины, найденные обеими операциями.

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

Если одно совпадение охватывает части с разным форматированием, проверьте результат, чтобы подтвердить, какое форматирование должно применяться к заменяемому тексту.

## **Замена текста по всей презентации**

Используйте [Presentation.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/replacetext/) и [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/replaceregex/) для применения тех же операций ко всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

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

## **Группировка совпадений для отчётности**

Поскольку каждый результат хранит номер слайда и текстовый фрейм, приложения могут группировать совпадения для аудита, отчётности или процессов проверки. В следующем примере собираемые результаты группируются сначала по слайду, затем по текстовому фрейму:

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

**Как выполнить поиск только в одном текстовом поле вместо всей презентации?**

Получите текстовый фрейм фигуры и вызовите [ITextFrame.HighlightText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replacetext/) или [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replaceregex/) для этого фрейма. Методы уровня презентации обрабатывают все применимые текстовые фреймы.

**Как сопоставить полные слова с правильным регистром?**

Установите [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/wholewordsonly/) и [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/casesensitive/) в `true` и передайте параметры методу выделения или замены дословного текста. Для регулярных выражений определяйте границы слов и чувствительность к регистру непосредственно в .NET `Regex`.

**Можно ли включить поиск и замену текста в заметках слайдов?**

Да. Установите [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ru/net/aspose.slides/textsearchoptions/includenotes/) в `true` при использовании дословной операции на уровне презентации. Реализация обратного вызова, показанная выше, сопоставляет совпадение в слайде заметок с номером его родительского слайда.

**Как создать отчёт без повторного сканирования презентации?**

Передайте реализацию [IFindResultCallback](https://reference.aspose.com/slides/ru/net/aspose.slides/ifindresultcallback/) в операцию выделения или замены. Обратный вызов получает каждое совпадение во время выполнения операции, поэтому приложение может сохранять исходный текст, найденный текст, позицию, текстовый фрейм и выведенный номер слайда для последующей группировки или экспорта.

**Сохраняет ли замена текста его форматирование?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replacetext/) и [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/replaceregex/) изменяют найденный текст внутри существующего текстового фрейма и сохраняют форматирование окружающих частей. Если совпадение охватывает участки с разным форматированием, проверьте результат, чтобы убедиться, что замена использует требуемый стиль.