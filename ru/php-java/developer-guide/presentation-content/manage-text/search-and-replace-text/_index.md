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

Aspose.Slides for PHP via Java может выполнять поиск, выделять и заменять текст в отдельном текстовом фрейме или во всей презентации. Каждая операция также может уведомлять приложение о каждом совпадении через обратный вызов результата. Это позволяет обновлять презентацию и одновременно вести журнал аудита, содержащий найденный текст, его контекст, позицию, текстовый фрейм и номер слайда.

Эти возможности полезны для проверки, редактирования, проверки терминологии, очистки шаблонов и автоматизированных процессов формирования отчетов.

В первых примерах ниже используется файл «sample.pptx», содержащий один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выберите область поиска**

Используйте методы на [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) для ограничения операции одним текстовым фреймом. Используйте методы на [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) для обработки всего применимого текста в презентации.

| Операция | Один текстовый фрейм | Вся презентация |
|---|---|---|
| Выделить буквальный текст | [TextFrame::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#highlightText) |
| Выделить совпадения регулярного выражения | [TextFrame::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#highlightRegex) |
| Заменить буквальный текст | [TextFrame::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#replaceText) |
| Заменить совпадения регулярного выражения | [TextFrame::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#replaceRegex) |

## **Настройка сопоставления текста**

Для операций с буквальным текстом используйте [TextSearchOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/) для управления поиском:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) ограничивает совпадения полными словами.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) определяет, должен ли регистр символов совпадать.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) включает заметки слайдов в операции поиска, замены и выделения на уровне презентации.

Операции с регулярными выражениями используют Java `Pattern`, поэтому такие правила, как чувствительность к регистру и границы слов, задаются непосредственно в выражении и его флагах.

## **Определение владельца текстового фрейма**

В типовых рабочих процессах обработки текста часто получают объект [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) при поиске, замене, проверке или экспорте текста. Используйте [TextFrame::getParentShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentShape) и [TextFrame::getParentCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentCell), чтобы определить, какой объект презентации владеет этим фреймом.

Ожидаемые значения зависят от владельца:

| Владелец текстового фрейма | `getParentShape` | `getParentCell` |
|---|---|---|
| Автофигура или другая форма, содержащая текст | Соответствующая [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) | `null` |
| Ячейка таблицы | `null` | Соответствующая [Cell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/) |

Оба метода предоставляют навигацию только для чтения. Их вызов не перемещает текстовый фрейм и не меняет его владельца. Универсальный код должен проверять оба значения с помощью `java_is_null` и учитывать возможность отсутствия обоих владельцев.

Следующий пример использует [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideutil/#getAllTextFrames) для перебора текстовых фреймов в презентации. Для фигур выводятся имя фигуры, тип Java‑runtime и содержащий слайд. Для ячеек таблицы выводятся нулевые индексы столбца и строки и содержащий слайд.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

Для содержимого SmartArt перебирайте формы в [SmartArtNode::getShapes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartartnode/#getShapes) и получайте каждый [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartartshape/#getTextFrame). Текстовый фрейм можно отследить до связанной формы через [TextFrame::getParentShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentShape), а [TextFrame::getParentCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentCell) возвращает `null`. Поэтому ветка формы в примере также обрабатывает текст из узлов SmartArt.

## **Сбор информации о совпадениях с помощью обратного вызова**

Передайте Java‑прокси‑обратный вызов в метод выделения или замены, чтобы получать уведомление о каждом совпадении. Метод обратного вызова получает соответствующий текстовый фрейм, исходный текст, найденный текст и позицию совпадения.

Обратный вызов не получает номер слайда напрямую. Реализация ниже извлекает его из родительского слайда и также обрабатывает текст, найденный в заметках слайдов. В результирующем массиве используется `null`, когда текст относится к другому типу слайда.

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

Для операций замены `foundText` содержит оригинальный найденный текст, поэтому обратный вызов может точно зафиксировать, какие термины были заменены.

## **Выделение текста**

Используйте метод [TextFrame::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightText) для выделения совпадений буквального текста в текстовом фрейме. Передайте [TextSearchOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/) для управления поиском.

Ниже пример кода, который выделяет все вхождения символов **"try"**, а затем выделяет только полное слово **"to"**.

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

Метод [TextFrame::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightRegex) выделяет совпадения, найденные регулярным выражением, в текстовом фрейме.

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

Используйте [Presentation::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#highlightText) и [Presentation::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#highlightRegex) для поиска во всех применимых текстовых фреймах презентации. В следующем примере выделяется буквальный термин и все адреса электронной почты:

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

Используйте [TextFrame::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceText) для буквального текста и [TextFrame::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceRegex) для замены по шаблону. Эти методы обновляют найденный текст внутри существующего текстового фрейма, сохраняя форматирование окружающих фрагментов вместо полной перестройки фрейма из строки.

Ниже пример, который стандартизирует вариант написания и затем заменяет метки версий:

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

Если одно совпадение охватывает участки с разным форматированием, проверьте результат, чтобы убедиться, какое форматирование должно применяться к замещаемому тексту.

## **Замена текста по всей презентации**

Используйте [Presentation::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#replaceText) и [Presentation::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#replaceRegex) для применения одинаковых операций ко всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

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

Поскольку каждый результат хранит номер слайда и текстовый фрейм, приложения могут группировать совпадения для аудита, отчетов или проверочных процессов. Ниже пример, который группирует собранные результаты сначала по слайдам, а затем по текстовым фреймам:

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

**Как выполнить поиск только в одном текстовом поле, а не во всей презентации?**

Получите текстовый фрейм формы и вызовите [TextFrame::highlightText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceText) или [TextFrame::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceRegex) для этого фрейма. Методы уровня презентации обрабатывают все применимые текстовые фреймы.

**Как найти полные слова с правильным регистром?**

Установите [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) и [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) в `true` и передайте параметры в метод выделения или замены буквального текста. Для регулярных выражений задавайте границы слов и чувствительность к регистру непосредственно в Java `Pattern`.

**Можно ли включить поиск и замену текста из заметок слайдов?**

Да. Установите [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) в `true` при использовании буквального текстового действия на уровне презентации.

**Как создать отчет без повторного сканирования презентации?**

Передайте Java‑прокси‑обратный вызов в операцию выделения или замены. Он получает каждое совпадение во время выполнения операции, поэтому приложение может сохранять исходный текст, найденный текст, позицию, текстовый фрейм и вычисленный номер слайда для последующей группировки или экспорта.

**Сохраняет ли замена текста его форматирование?**

[TextFrame::replaceText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceText) и [TextFrame::replaceRegex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#replaceRegex) изменяют найденный текст внутри существующего фрейма и сохраняют форматирование окружающих участков. Если совпадение охватывает фрагменты с разным форматированием, проверьте результат, чтобы убедиться, что замена использует требуемый стиль.