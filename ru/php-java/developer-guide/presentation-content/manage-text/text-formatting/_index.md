---
title: Форматирование текста презентации в PHP
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/php-java/text-formatting/
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
- PHP
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java. Рассматриваются цвета фона, прозрачность, интервал между символами, свойства шрифта, вращение, межстрочный интервал, поведение автоподгонки, привязка текста, табуляция и настройки языка.

В примерах ниже мы будем использовать файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения по регулярному выражению, см. [Поиск и замена текста](/slides/ru/php-java/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), чтобы задать цвет выделения по умолчанию для абзаца, или используйте [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#getHighlightColor) для отдельных текстовых фрагментов.

Следующий пример кода показывает, как задать цвет фона для **всего абзаца**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Установить цвет подсветки для всего абзаца.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже пример кода, демонстрирующего, как установить цвет фона для **текстовых фрагментов с полужирным шрифтом**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Установить цвет подсветки для текстового фрагмента.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Серые части текста](gray_text_portions.png)

## **Выровнять абзацы текста**

Используйте [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setAlignment), чтобы задать выравнивание абзаца внутри текстового кадра. Значение может быть центрированным, выровненным по левому, правому краю, по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац по **центру**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Установить выравнивание абзаца по центру.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного свойству [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#getFillFormat). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Следующий пример кода показывает, как применить прозрачность к **всему абзацу**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Установить цвет заливки текста в прозрачный цвет.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

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
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Установить прозрачность текстового фрагмента.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Прозрачные части текста](transparent_text_portions.png)

## **Установить интервал между символами текста**

Используйте [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setSpacing), чтобы увеличить или уменьшить интервал между символами в текстовом блоке.

Следующий PHP‑код показывает, как увеличить интервал между символами в **всём абзаце**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Примечание: используйте отрицательные значения, чтобы сжать интервал между символами.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Увеличить интервал между символами.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Интервал символов в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как увеличить интервал между символами в **текстовых фрагментах с полужирным шрифтом**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

![Интервал символов в частях текста](character_spacing_in_text_portions.png)

### **Отключить кернинг для определенных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть чуть плотнее, чем тот же текст в PowerPoint. Это может происходить потому, что PowerPoint игнорирует данные кернинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы вывести результат ближе к отображению в PowerPoint, можно отключить кернинг для текстовых фрагментов, использующих проблемный шрифт. Установите [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) в значение, значительно превышающее фактический размер шрифта:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

Эта настройка препятствует применению кернинга к соответствующим фрагментам текста и помогает согласовать визуальное отображение Aspose.Slides с PowerPoint для шрифтов, затронутых особенностями PowerPoint.

## **Управление параметрами шрифта текста**

Параметры шрифта можно задать на уровне абзаца через [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) или для отдельных фрагментов через [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/).

Следующий код задаёт шрифт и стиль текста для **всего абзаца**: устанавливается размер шрифта, полужирный, курсив, пунктирное подчёркивание и шрифт Times New Roman для всех фрагментов абзаца.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Установить свойства шрифта для абзаца.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Параметры шрифта для абзаца](font_properties_for_paragraph.png)

Пример кода ниже применяет аналогичные свойства к **текстовым фрагментам с полужирным шрифтом**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Установить свойства шрифта для текстового фрагмента.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Параметры шрифта для частей текста](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setTextVerticalType), чтобы задать предопределённую ориентацию текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Вращение текста](text_rotation.png)

## **Установить пользовательское вращение для текстовых фреймов**

Используйте [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setRotationAngle), чтобы задать произвольный угол вращения для [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).

Пример кода ниже вращает текстовый фрейм на 3 градуса по часовой стрелке внутри фигуры:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет методы [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setSpaceBefore) и [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setSpaceWithin) для управления интервалом абзацев. Эти свойства используются следующим образом:

* Задайте положительное значение, чтобы указать межстрочный интервал в процентах от высоты строки.
* Задайте отрицательное значение, чтобы указать межстрочный интервал в пунктах.

Следующий пример кода показывает, как задать межстрочный интервал внутри абзаца:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Межстрочный интервал в абзаце](line_spacing.png)

## **Установить тип автоподгонки для текстовых фреймов**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setAutofitType) определяет, как текст будет вести себя, когда превышает границы контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за границы или автоматически менять размер фигуры.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняется ширина текста или фигуры, см. [Подсчитать отрендеренные строки](/slides/ru/php-java/manage-paragraph/). Само количество строк не указывает, переполняет ли текст свой контейнер.

## **Установить привязку текстовых фреймов**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setAnchoringType) определяет, как текст позиционируется вертикально внутри фигуры, например вверху, посередине или внизу.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установить табуляцию текста**

Используйте [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) и [ParagraphFormat::getTabs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getTabs) для настройки позиций табуляции в абзаце.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

## **Установить язык проверки правописания**

Aspose.Slides предоставляет [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId), который позволяет задать язык проверки правописания для текстового фрагмента. Язык проверки определяет, какой язык будет использоваться для проверки орфографии и грамматики в PowerPoint.

Следующий пример кода показывает, как задать язык проверки правописания для текстового фрагмента:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Установить идентификатор проверочного языка.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установить язык по умолчанию**

Используйте [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), чтобы задать язык по умолчанию для текста, создаваемого при загрузке или создании презентации.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавить новую прямоугольную фигуру с текстом.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Проверить язык первого фрагмента.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Следующий пример кода показывает, как задать шрифт полужирным размером 14 pt для всего текста на всех слайдах новой презентации.

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

## **Извлечь текст с эффектом All Caps**

В PowerPoint применение эффекта **All Caps** делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы отобразить его так же, как на слайде, проверьте [TextCapType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Предположим, что на первом слайде файла sample2.pptx есть следующий текстовый блок.

![Эффект All Caps](all_caps_effect.png)

Следующий пример кода показывает, как извлечь текст с применённым эффектом **All Caps**:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

## **Вопросы и ответы**

**Как изменить текст в таблице на слайде?**

Для изменения текста в таблице на слайде используйте [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/). Проходите по ячейкам и обновляйте каждую ячейку через [Cell::getTextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/#getTextFrame) и форматирование абзацев через [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#getFillFormat). Установите [FillFormat::setFillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/#setFillType) в значение [FillType::Gradient](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.