---
title: "Форматирование текста презентации в PHP"
linktitle: "Форматирование текста"
type: docs
weight: 50
url: /ru/php-java/text-formatting/
keywords:
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межсимвольный интервал
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

Данная статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. В ней рассматриваются фоновые цвета, прозрачность, межсимвольный интервал, свойства шрифта, вращение, межабзацный интервал, поведение автоподгонки, привязка текста, табуляция и настройки языка.

В приведённых ниже примерах мы будем использовать файл с именем «sample.pptx», в котором на первом слайде находится один текстовый блок со следующим содержимым:

![Пример текста](sample_text.png)

Чтобы находить и выделять буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/php-java/search-and-replace-text/).

## **Установка фонового цвета текста**

Используйте [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) для установки цвета подсветки по умолчанию для абзаца, либо используйте [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#getHighlightColor) для отдельных текстовых фрагментов.

Следующий пример кода показывает, как установить фоновый цвет для **всего абзаца**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Установите цвет подсветки для всего абзаца.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Серый абзац](gray_paragraph.png)

Пример кода ниже демонстрирует, как установить фоновый цвет для **текстовых фрагментов с полужирным шрифтом**:

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
            // Установите цвет подсветки для текстового фрагмента.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
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

Используйте [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setAlignment), чтобы задать выравнивание абзаца внутри текстового кадра. Значение может быть по центру, по левому краю, по правому краю, выровнено по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Установите выравнивание абзаца по центру.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Установка прозрачности текста**

Прозрачность текста управляется с помощью альфа‑компоненты цвета, назначенного [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#getFillFormat). В примерах ниже `alpha = 50` представляет собой значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже приведён пример кода, показывающий, как применить прозрачность к **всему абзацу**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Установите цвет заливки текста в прозрачный цвет.
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
            // Установите прозрачность текстового фрагмента.
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

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установка межсимвольного интервала для текста**

Используйте [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setSpacing), чтобы увеличить или уменьшить интервал между символами в текстовом блоке.

Следующий PHP‑код показывает, как расширить межсимвольный интервал в **всём абзаце**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Увеличить межсимвольный интервал.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как расширить межсимвольный интервал в **текстовых фрагментах с полужирным шрифтом**:

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
            // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
            $portion->getPortionFormat()->setSpacing(3); // Увеличить межсимвольный интервал.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Межсимвольный интервал в текстовых фрагментах](character_spacing_in_text_portions.png)

### **Отключение кернинга для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть немного плотнее, чем тот же текст в PowerPoint. Это может происходить потому, что PowerPoint может игнорировать данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы отрисованный результат был ближе к PowerPoint в подобных случаях, вы можете отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) в значение, значительно превышающее реальный размер шрифта:

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

Эта настройка предотвращает применение кернинга к соответствующим текстовым фрагментам и может помочь согласовать визуальный результат Aspose.Slides с выводом PowerPoint для шрифтов, на которые влияет данное специфическое поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), либо для отдельных фрагментов через [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/).

Следующий код задаёт шрифт и стиль текста для всего абзаца: он применяет размер шрифта, полужирное начертание, курсив, пунктирное подчеркивание и шрифт Times New Roman ко всем фрагментам в абзаце.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Установите свойства шрифта для абзаца.
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

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

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
            // Установите свойства шрифта для текстового фрагмента.
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

![Свойства шрифта для текстовых фрагментов](font_properties_for_text_portions.png)

## **Установка вращения текста**

Используйте [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setTextVerticalType), чтобы задать предопределённую ориентацию текста внутри фигуры.

Следующий пример кода устанавливает ориентацию текста в фигуре в `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

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

## **Установка пользовательского вращения для текстовых рамок**

Используйте [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setRotationAngle), чтобы задать пользовательский угол вращения для [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).

Пример кода ниже вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

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

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setSpaceBefore) и [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setSpaceWithin), чтобы управлять интервалами абзацев. Эти свойства используются следующим образом:

* Укажите положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Укажите отрицательное значение, чтобы задать межстрочный интервал в пунктах.

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

## **Установка типа автоподгонки для текстовых рамок**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setAutofitType) определяет, как текст будет вести себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст уменьшаться, выходить за пределы или автоматически изменять размер фигуры.

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

## **Установка привязки текстовых рамок**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setAnchoringType) определяет, как текст позиционируется по вертикали внутри фигуры, например вверху, по центру или внизу.

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

## **Установка табуляции текста**

Используйте [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) и [ParagraphFormat::getTabs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getTabs), чтобы настроить позиции табуляции в абзаце.

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

![Табуляция в абзаце](paragraph_tabs.png)

## **Установка языка проверки правописания**

Aspose.Slides предоставляет [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId), который позволяет задать язык проверки правописания для текстового фрагмента. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

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

    // Установите идентификатор языка проверки правописания.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установка языка по умолчанию**

Используйте [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), чтобы определить язык по умолчанию для текста, создаваемого при загрузке или создании презентации.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Добавьте новую прямоугольную форму с текстом.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Проверьте язык первой части текста.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Установка стиля текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Следующий пример кода показывает, как задать шрифт по умолчанию полужирным размером 14 пунктов для всего текста на всех слайдах новой презентации.

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

## **Извлечение текста с эффектом всех заглавных букв**

В PowerPoint применение эффекта шрифта **All Caps** заставляет текст отображаться заглавными буквами на слайде, даже если он был введён строчными. При получении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст ровно так, как он был введён. Чтобы сопоставить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textcaptype/) и преобразуйте полученную строку в верхний регистр, когда значение равно `All`.

Допустим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

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

## **FAQ**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую ячейку через [Cell::getTextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/#getTextFrame) и форматирование абзацев через [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#getFillFormat). Установите [FillFormat::setFillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/#setFillType) в [FillType::Gradient](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) и настройте градиентные остановки, направление и прозрачность.