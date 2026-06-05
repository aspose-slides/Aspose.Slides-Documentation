---
title: Форматирование текста презентации в PHP
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/php-java/text-formatting/
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
- PHP
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для PHP через Java. Настройте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java. Описываются выделение, цвета фона, прозрачность, интервал между символами, свойства шрифта, вращение, интервалы абзацев, поведение автоподгонки, привязка текста, табуляция и параметры языка.

В примерах ниже мы будем использовать файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выделить текст**

Используйте метод [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/)`::highlightText`, когда необходимо выделять текст, соответствующий определенному образцу внутри текстового кадра. Метод применяет цвет выделения к соответствующим фрагментам текста и может использоваться совместно с [TextHighlightingOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/texthighlightingoptions/) для управления тем, как производится поиск, например, чтобы сопоставлять только целые слова.

Пример кода ниже выделяет все вхождения символов **"try"** и затем выделяет только полное слово **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
        // Получить первую форму с первого слайда.
        $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $lightBlue = new Java("java.awt.Color", 173, 216, 230);
        $violet = new Java("java.awt.Color", 238, 130, 238);

        // Выделить слово "try" в форме.
        $shape->getTextFrame()->highlightText("try", $lightBlue);

        $searchOptions = new TextHighlightingOptions();
        $searchOptions->setWholeWordsOnly(true);

        // Выделить слово "to" в форме.
        $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

        $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделение текста с помощью регулярных выражений**

Метод [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/)`::highlightRegex` выделяет совпадения текста, найденные с помощью регулярного выражения.

Пример кода ниже выделяет все слова, содержащие **семь и более символов**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Выделить все слова, содержащие семь или более символов.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Выделенный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Установить цвет фона текста**

Используйте метод default portion format класса [ParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/), чтобы установить цвет выделения по умолчанию для абзаца, или используйте [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/) для отдельных текстовых фрагментов.

Следующий пример кода показывает, как задать цвет фона для **всего абзаца**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Задать цвет выделения для всего абзаца.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Серый абзац](gray_paragraph.png)

Пример кода ниже демонстрирует, как задать цвет фона для **текстовых фрагментов с полужирным шрифтом**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Задать цвет выделения для текстового фрагмента.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Серые текстовые фрагменты](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте метод [ParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/)`::setAlignment`, чтобы задать выравнивание абзаца внутри текстового кадра. Значение может быть центрировано, выровнено по левому краю, по правому краю, выровнено по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац по **центру**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Задать выравнивание абзаца по центру.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного формату заливки [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0‑255, а не процент прозрачности.

Пример кода ниже показывает, как применить прозрачность к **всему абзацу**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Задать цвет заливки текста прозрачным цветом.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **текстовым фрагментам с полужирным шрифтом**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Задать прозрачность текстового фрагмента.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установить интервал между символами текста**

Используйте метод [BasePortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/)`::setSpacing`, чтобы увеличить или уменьшить интервал между символами в текстовом поле.

Следующий код PHP показывает, как расширить интервал между символами в **всём абзаце**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Примечание: используйте отрицательные значения, чтобы сжать интервал между символами.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Увеличить интервал между символами.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как расширить интервал между символами в **текстовых фрагментах с полужирным шрифтом**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Примечание: используйте отрицательные значения, чтобы сжать интервал между символами.
            $portion->getPortionFormat()->setSpacing(3); // Увеличить интервал между символами.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Интервал между символами в текстовых фрагментах](character_spacing_in_text_portions.png)

### **Отключить кернинг для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть немного плотнее, чем тот же текст в PowerPoint. Это может происходить потому, что PowerPoint игнорирует данные о кернинге для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы полученный вывод был ближе к отображению в PowerPoint, в подобных случаях можно отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите метод [BasePortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` в значение, значительно превышающее реальный размер шрифта:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Эта настройка предотвращает применение кернинга к соответствующим текстовым фрагментам и может помочь синхронизировать рендеринг Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через default portion format класса [ParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/) или для отдельных фрагментов через [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/).

Следующий код задаёт шрифт и стиль текста для всего абзаца: он применяет размер шрифта, полужирный, курсив, пунктирное подчеркивание и шрифт Times New Roman ко всем фрагментам в абзаце.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Задать свойства шрифта для абзаца.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Пример кода ниже применяет аналогичные свойства к **текстовым фрагментам с полужирным шрифтом**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Задать свойства шрифта для текстового фрагмента.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Свойства шрифта для текстовых фрагментов](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте метод [TextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/)`::setTextVerticalType`, чтобы задать предопределённую ориентацию текста внутри формы.

Следующий пример кода задаёт ориентацию текста в форме `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Вращение текста](text_rotation.png)

## **Установить пользовательское вращение для текстовых рамок**

Используйте метод [TextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/)`::setRotationAngle`, чтобы задать пользовательский угол вращения для [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).

Пример кода ниже вращает текстовую рамку на 3 градуса по часовой стрелке внутри формы:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Задать межстрочный интервал абзацев**

Aspose.Slides предоставляет методы [ParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore` и `ParagraphFormat::setSpaceWithin` для управления интервалами абзацев. Эти методы используются следующим образом:

* Используйте положительное значение, чтобы указать межстрочный интервал в процентах от высоты строки.
* Используйте отрицательное значение, чтобы указать межстрочный интервал в пунктах.

Следующий пример кода показывает, как задать межстрочный интервал в абзаце:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Межстрочный интервал в абзаце](line_spacing.png)

## **Задать тип автоподгонки для текстовых рамок**

Метод [TextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/)`::setAutofitType` определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы управлять тем, будет ли текст сжиматься, выходить за пределы или автоматически изменять размер формы.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Задать привязку текстовых рамок**

Метод [TextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/)`::setAnchoringType` определяет, как текст размещается вертикально внутри формы, например, вверху, по центру или внизу.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Задать табуляцию текста**

Используйте метод [ParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` и его коллекцию табуляций для настройки позиций табуляции в абзаце.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Табуляция абзаца](paragraph_tabs.png)

## **Задать язык проверки орфографии**

Aspose.Slides предоставляет метод [BasePortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/)`::setLanguageId`, позволяющий задать язык проверки орфографии для текстового фрагмента. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример кода показывает, как задать язык проверки орфографии для текстового фрагмента:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Задать идентификатор языка проверки орфографии.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Задать язык по умолчанию**

Используйте метод [LoadOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage`, чтобы определить язык по умолчанию для текста, создаваемого при загрузке или создании презентации.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить новую прямоугольную форму с текстом.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Проверить язык первого фрагмента.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Задать стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте стиль текста по умолчанию объекта [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/).

Следующий пример кода показывает, как задать полужирный шрифт размером 14 пунктов по умолчанию для всего текста на всех слайдах новой презентации.

```php
$presentation = new Presentation();
try {
    // Получить формат абзаца верхнего уровня.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Извлечь текст с эффектом «Все заглавные»**

В PowerPoint применение эффекта шрифта **All Caps** делает текст на слайде отображаемым заглавными буквами, даже если он был введён строчными. При извлечении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textcaptype/) и преобразуйте возвращённую строку к верхнему регистру, если значение равно `All`.

Предположим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Вывод:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую ячейку через текстовый кадр [Cell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/) и форматирование абзаца через [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/)`s paragraph format.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте формат заливки [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/). Установите тип заливки [FillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/) в [FillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) `Gradient` и настройте остановки градиента, направление и прозрачность.