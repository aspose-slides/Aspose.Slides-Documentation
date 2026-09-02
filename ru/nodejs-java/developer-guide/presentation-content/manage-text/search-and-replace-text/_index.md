---
title: Поиск и замена текста в презентациях PowerPoint на JavaScript
linktitle: Поиск и замена текста
type: docs
weight: 55
url: /ru/nodejs-java/search-and-replace-text/
keywords:
- поиск текста
- выделение текста
- замена текста
- регулярное выражение
- обратный вызов результата
- текстовый фрейм
- аудиторский отчёт
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Поиск, выделение и замена текста в презентациях PowerPoint с одновременным сбором всех совпадений с помощью Aspose.Slides for Node.js via Java."
---
## **Обзор**

Aspose.Slides for Node.js via Java может искать, выделять и заменять текст в отдельном текстовом фрейме или по всей презентации. Каждая операция также может уведомлять приложение о каждом совпадении через обратный вызов результата. Это позволяет обновлять презентацию и одновременно создавать журнал аудита, содержащий найденный текст, его контекст, позицию, текстовый фрейм и номер слайда.

Эти возможности полезны для рецензирования, редактирования, проверки терминологии, очистки шаблонов и автоматизированных рабочих процессов отчетности.

В первых примерах ниже мы используем файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выбор области поиска**

Используйте методы класса [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) для ограничения операции одним текстовым фреймом. Используйте методы класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) для обработки всего соответствующего текста в презентации.

| Операция | Один текстовый фрейм | Вся презентация |
|---|---|---|
| Выделить буквальный текст | [TextFrame.highlightText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Выделить совпадения регулярного выражения | [TextFrame.highlightRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Заменить буквальный текст | [TextFrame.replaceText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Заменить совпадения регулярного выражения | [TextFrame.replaceRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Настройка сопоставления текста**

Для операций с буквальным текстом используйте [TextSearchOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textsearchoptions/) для управления сопоставлением:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) ограничивает совпадения полными словами.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) управляет тем, должен ли учитываться регистр символов.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) включает заметки слайдов в операции поиска, замены и выделения на уровне презентации.

Операции с регулярными выражениями используют Java `Pattern`, поэтому правила сопоставления, такие как чувствительность к регистру и границы слов, определяются выражением и его флагами.

## **Сбор информации о совпадениях с помощью обратного вызова**

Создайте Java‑прокси для обратного вызова результата, чтобы получать уведомление о каждом совпадении. Функция прокси получает связанные текстовый фрейм, исходный текст, найденный текст и позицию совпадения.

Обратный вызов не получает номер слайда напрямую. Реализация ниже выводит его с помощью [TextFrame.getSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#getSlideNumber--), и [NotesSlide.getParentSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notesslide/#getParentSlide--). Она также обрабатывает текст, найденный в заметках слайдов.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Для операций замены `foundText` содержит оригинальный найденный текст, поэтому обратный вызов может точно зафиксировать, какие термины были заменены.

## **Выделить текст**

Используйте метод [TextFrame.highlightText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) , чтобы выделить совпадения буквального текста в текстовом фрейме. Передайте [TextSearchOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textsearchoptions/) для управления поиском.

Пример кода ниже выделяет все вхождения символов **"try"** и затем выделяет только полное слово **"to"**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Выделить каждое вхождение "try" в текстовом фрейме.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Выделить только полное слово "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделить текст с помощью регулярных выражений**

Метод [TextFrame.highlightRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) выделяет совпадения текста, найденные регулярным выражением, в текстовом фрейме.

Следующий код выделяет все слова, содержащие семь и более символов:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Выделенный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Выделить текст по всей презентации**

Используйте [Presentation.highlightText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) и [Presentation.highlightRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) , чтобы искать во всех соответствующих текстовых фреймах презентации. В следующем примере выделяется буквальный термин и все адреса электронной почты:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Заменить текст в текстовом фрейме**

Используйте [TextFrame.replaceText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) для буквального текста и [TextFrame.replaceRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) для замены по шаблону. Эти методы обновляют найденный текст внутри существующего текстового фрейма, сохраняя форматирование окружающих частей вместо пересоздания фрейма из обычной строки.

В следующем примере стандартизируется вариант написания, а затем заменяются метки версии:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если одно совпадение охватывает участки с разным форматированием, проверьте вывод, чтобы подтвердить, какое форматирование следует применить к заменяемому тексту.

## **Заменить текст по всей презентации**

Используйте [Presentation.replaceText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) и [Presentation.replaceRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) , чтобы применять те же операции по всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Группировка совпадений для отчётов**

Поскольку каждый собранный результат хранит номер слайда и текстовый фрейм, приложения могут группировать совпадения для аудита, отчетности или рабочих процессов проверки. В следующем примере результаты группируются сначала по слайду, а затем по текстовому фрейму:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Как я могу искать только в одном текстовом блоке вместо всей презентации?**

Получите текстовый фрейм формы и вызовите [TextFrame.highlightText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), или [TextFrame.replaceRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) для этого фрейма. Методы уровня презентации обрабатывают все соответствующие текстовые фреймы.

**Как я могу находить полные слова с правильным регистром?**

Установите [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) и [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) в `true` и передайте параметры в метод выделения или замены буквального текста. Для регулярных выражений определяйте границы слов и чувствительность к регистру непосредственно в Java `Pattern`.

**Можно ли включить поиск и замену текста в заметках слайдов?**

Да. Установите [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) в `true` при использовании операции буквального текста на уровне презентации. Реализация обратного вызова, показанная выше, сопоставляет найденный в заметках слайда совпадение с номером родительского слайда.

**Как создать отчёт, не сканируя презентацию второй раз?**

Передайте Java‑прокси обратного вызова результата в операцию выделения или замены. Обратный вызов получает каждое совпадение во время выполнения операции, поэтому приложение может сохранять исходный текст, найденный текст, позицию, текстовый фрейм и вычисленный номер слайда для последующей группировки или экспорта.

**Сохраняет ли замена текста его форматирование?**

[TextFrame.replaceText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) и [TextFrame.replaceRegex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) изменяют найденный текст внутри существующего текстового фрейма, сохраняя форматирование окружающих частей. Если совпадение охватывает участки с разным форматированием, проверьте результат, чтобы убедиться, что замена используется нужный стиль.