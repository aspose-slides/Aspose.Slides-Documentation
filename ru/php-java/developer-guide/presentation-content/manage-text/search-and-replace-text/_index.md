---
title: Поиск и замена текста в презентациях PowerPoint на PHP
linktitle: Поиск и замена текста
type: docs
weight: 55
url: /ru/php-java/search-and-replace-text/
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
- PHP
- Aspose.Slides
description: "Ищите, выделяйте и заменяйте текст в презентациях PowerPoint, собирая каждое совпадение с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Aspose.Slides for PHP via Java может выполнять поиск, выделение и замену текста в отдельном текстовом фрейме или по всей презентации. Каждая операция также может уведомлять приложение о каждом совпадении через обратный вызов результата. Это позволяет обновлять презентацию и одновременно формировать журнал аудита, содержащий найденный текст, его контекст, позицию, текстовый фрейм и номер слайда.

Эти возможности полезны для рецензирования, редактирования, проверки терминологии, очистки шаблонов и автоматических рабочих потоков отчетности.

В первых примерах ниже используется файл с именем «sample.pptx», который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выберите область поиска**

Используйте методы [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) для ограничения операции одним текстовым фреймом. Используйте методы [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) для обработки всего применимого текста в презентации.

| Операция | Один текстовый фрейм | Вся презентация |
|---|---|---|
| Выделить буквальный текст | [TextFrame::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#highlightText) |
| Выделить совпадения регулярного выражения | [TextFrame::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#highlightRegex) |
| Заменить буквальный текст | [TextFrame::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#replaceText) |
| Заменить совпадения регулярного выражения | [TextFrame::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#replaceRegex) |

## **Настройка сопоставления текста**

Для операций с буквальным текстом используйте [TextSearchOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/) для управления сопоставлением:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) ограничивает совпадения полными словами.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) определяет, должен ли регистр символов совпадать.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) включает заметки слайдов в операции поиска, замены и выделения на уровне презентации.

Операции с регулярными выражениями используют Java `Pattern`, поэтому правила сопоставления, такие как чувствительность к регистру и границы слов, определяются выражением и его флагами.

## **Сбор информации о совпадениях с помощью обратного вызова**

Передайте Java‑прокси‑обратный вызов в метод выделения или замены, чтобы получать уведомление о каждом совпадении. Метод обратного вызова получает соответствующий текстовый фрейм, исходный текст, найденный текст и позицию совпадения.

Обратный вызов не получает номер слайда напрямую. Реализация ниже получает его из родительского слайда и также обрабатывает текст, найденный в заметках слайда. Массив результата использует `null`, когда текст связан с другим типом слайда.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Создайте прокси для этого PHP‑объекта перед передачей его в операцию:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Для операций замены `foundText` содержит оригинальный найденный текст, поэтому обратный вызов может точно записать, какие термины были заменены.

## **Выделение текста**

Используйте метод [TextFrame::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightText) для выделения совпадений буквального текста в текстовом фрейме. Передайте [TextSearchOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/) для управления поиском.

Пример кода ниже выделяет все вхождения символов **"try"** и затем выделяет только полное слово **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Выделить каждое вхождение "try" в текстовом фрейме.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Выделить только полное слово "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделение текста с использованием регулярных выражений**

Метод [TextFrame::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightRegex) выделяет совпадения текста, найденные с помощью регулярного выражения, в текстовом фрейме.

Следующий код выделяет все слова, содержащие семь и более символов:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Результат:

![Выделенный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Выделение текста по всей презентации**

Используйте [Presentation::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#highlightText) и [Presentation::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#highlightRegex) для поиска всех применимых текстовых фреймов в презентации. Следующий пример выделяет буквальный термин и все адреса электронной почты:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Замена текста в текстовом фрейме**

Используйте [TextFrame::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceText) для буквального текста и [TextFrame::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceRegex) для замены по шаблону. Эти методы обновляют найденный текст внутри существующего текстового фрейма, сохраняющего форматирование окружающих частей, вместо перестроения фрейма из простой строки.

В следующем примере стандартизируется вариант написания, а затем заменяются метки версий:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Если одно совпадение охватывает части с различным форматированием, проверьте результат, чтобы подтвердить, какое форматирование должно быть применено к заменяемому тексту.

## **Замена текста по всей презентации**

Используйте [Presentation::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#replaceText) и [Presentation::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#replaceRegex) для применения тех же операций по всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Группировка совпадений для отчетности**

Поскольку каждый результат хранит номер слайда и текстовый фрейм, приложения могут группировать совпадения для аудита, отчетности или процессов обзора. В следующем примере результаты группируются сначала по слайду, затем по текстовому фрейму:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **FAQ**

**Как искать только один текстовый блок вместо всей презентации?**

Получите текстовый фрейм фигуры и вызовите [TextFrame::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceText) или [TextFrame::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceRegex) для этого текстового фрейма. Методы уровня презентации обрабатывают все применимые текстовые фреймы.

**Как сопоставить полные слова с правильным регистром?**

Установите [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) и [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) в `true` и передайте параметры методу выделения или замены буквального текста. Для регулярных выражений определяйте границы слов и чувствительность к регистру непосредственно в Java `Pattern`.

**Можно ли включить поиск и замену текста в заметках слайдов?**

Да. Установите [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) в `true`, используя операцию буквального текста на уровне презентации.

**Как создать отчет без повторного сканирования презентации?**

Передайте Java‑прокси‑обратный вызов в операцию выделения или замены. Он получает каждое совпадение в процессе выполнения операции, поэтому приложение может сохранять исходный текст, найденный текст, позицию, текстовый фрейм и вычисленный номер слайда для последующей группировки или экспорта.

**Сохраняет ли замена текста его форматирование?**

[TextFrame::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceText) и [TextFrame::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceRegex) изменяют найденный текст внутри существующего текстового фрейма и сохраняют форматирование окружающих частей. Если совпадение охватывает части с разным форматированием, проверьте результат, чтобы убедиться, что замена использует требуемый стиль.