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
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- якорь текстовой рамки
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Форматируйте и оформляйте текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java. В ней рассматриваются цвета фона, прозрачность, интервал между символами, свойства шрифта, вращение, интервалы абзацев, поведение автоподгонки, привязка текста, табуляция и настройки языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, а его первый абзац содержит текст, показанный ниже. Индексы слайдов и фигур начинаются с нуля. Примеры, выбирающие жирные фрагменты, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения с регулярным выражением, см. [Поиск и замена текста](/slides/ru/php-java/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), чтобы задать цвет подсветки по умолчанию для абзаца, или [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) для отдельных фрагментов текста.

В следующем примере задаётся светло-серая подсветка как значение по умолчанию для первого абзаца. Явные цвета подсветки у отдельных фрагментов имеют приоритет над этим значением по умолчанию:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

Ниже показан пример кода, демонстрирующий, как установить цвет фона для **фрагментов текста с жирным шрифтом**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
        // Установить цвет подсветки для фрагмента текста.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Серые фрагменты текста](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), чтобы задать выравнивание абзаца внутри текстового кадра. Значение может быть «центрировано», «по левому краю», «по правому краю», «по ширине» и т.д.

В следующем примере показано, как выровнять абзац **по центру**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

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

## **Выравнивание шрифтов в строке**

Используйте [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment), чтобы вертикально выровнять фрагменты текста с разными размерами шрифта внутри линии. Эта настройка применяется ко всему абзацу и управляет выравниванием в каждой его строке.

В следующем автономном примере создаются четыре текстовых поля с метками на одном слайде. Каждый абзац содержит одинаковый текст размером 18, 36 и 54 пункта с разным выравниванием шрифта. Используется шрифт Arial, отключены автоподгонка и перенос, а рамки текста достаточно большие для одной строки.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Сравнение выравниваний Baseline, Top, Center и Bottom при смешанных размерах шрифта](font_alignment.png)

Выравнивание шрифта использует метрики шрифта, поэтому видимые края отдельных букв не всегда совпадают точно. Пример включает заглавную букву и нижний вынос, чтобы продемонстрировать разницу между базовой линией и нижним выравниванием. Доступность шрифтов и их замена, использованные символы и различия в размерах шрифтов влияют на результат. Размеры рамки, отступы, межстрочный интервал, перенос и автоподгонка также влияют на разметку; при сравнении режимов используйте одинаковые шрифты и настройки разметки.

Эта настройка отличается от [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), который управляет горизонтальным выравниванием абзаца, и от [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), который позиционирует текстовый блок вертикально внутри его фигуры. Форматирование надстрочных и подстрочных индексов через [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) смещает отдельные фрагменты относительно базовой линии, а не задаёт выравнивание шрифта для строк абзаца.

## **Установить прозрачность текста**

Прозрачность текста контролируется альфа‑компонентой цвета, заданного в [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). В приведённых ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже показан пример кода, демонстрирующий, как применить прозрачность к **целому абзацу**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

В следующем примере показано, как применить прозрачность к **фрагментам текста с жирным шрифтом**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Установить прозрачность фрагмента текста.
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

![Прозрачные фрагменты текста](transparent_text_portions.png)

## **Установить интервал между символами текста**

Используйте [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing), чтобы увеличить или уменьшить интервал между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сжимают текст.

Ниже показан PHP‑код, демонстрирующий, как увеличить интервал между символами в **целом абзаце**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже демонстрирует, как увеличить интервал между символами в **фрагментах текста с жирным шрифтом**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

![Интервал между символами в фрагментах текста](character_spacing_in_text_portions.png)

### **Отключить кернинг для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит слегка уже, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint игнорирует данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы в таких случаях сделать вывод более похожим на PowerPoint, можно отключить кернинг для фрагментов текста, использующих затронутый шрифт. Установите [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) в значение, превышающее фактический размер шрифта. В примере требуется файл «presentation.pptx» с текстовым полем в качестве первой фигуры на первом слайде. Программа проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для фрагментов, использующих Roboto. Это отключит кернинг для соответствующих фрагментов с размером шрифта ниже 100 пунктов:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Для соответствующего текста ниже порога эта настройка предотвращает кернинг и может помочь согласовать вывод Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) или на отдельных фрагментах через [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

В следующем примере задаётся шрифт по умолчанию для первого абзаца: Times New Roman 12 пунктов, жирный, курсив и пунктирное подчёркивание. Явное форматирование отдельных фрагментов имеет приоритет над этими значениями по умолчанию.

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

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

![Свойства шрифта абзаца](font_properties_for_paragraph.png)

В следующем примере применяется Times New Roman 13 пунктов, курсив и пунктирное подчёркивание к фрагментам, у которых эффективное форматирование является жирным:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Установить свойства шрифта для фрагмента текста.
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

![Свойства шрифта фрагментов текста](font_properties_for_text_portions.png)

## **Контроль нормализации высоты текста**

Используйте [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight), когда воспроизводите типографику шаблона или исследуете различия в высоте символов. В PowerPoint включение нормализации растягивает или сжимает отдельные символы по вертикали, чтобы они имели одинаковую видимую высоту внутри текстового фрагмента. Это не гарантирует одинаковую высоту текста между разными шрифтами.

Задайте свойство в [NullableBool::True или False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), чтобы явно включить или отключить нормализацию. `NullableBool::NotDefined` оставляет локальную настройку неопределённой, чтобы фрагмент наследовал её, например, из [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) абзаца. Это не то же самое, что `False`. Используйте [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) и прочитайте `getNormaliseHeight` в возвращённых эффективных данных форматирования, чтобы получить вычисленное булевое значение.

В следующем автономном примере требуется установленный **Arial**. Создаются два текстовых блока, содержащих одинаковые заглавные буквы, строчные буквы, нижние выносы и символы с диакритикой, размером 54 пункта. Оба абзаца по умолчанию включают нормализацию. Верхний фрагмент явно отключает её; нижний наследует настройку. Размеры рамок, отступы и интервалы абзацев одинаковы, перенос и автоподгонка отключены для согласованного сравнения. Пример выводит `False: false` и `NotDefined: true`, затем сохраняет «text_height_normalization.pptx».

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сравнение ниже экспортировано из сохранённой презентации. В верхней строке нормализация отключена (`False`); в нижней — наследуется включённая настройка (`NotDefined` → `True`). Оставьте установленный Arial, чтобы воспроизвести внешний вид.

![Текст Arial 54 пункта с отключённой нормализацией сверху и наследуемой нормализацией снизу](text_height_normalization.png)

Нормализация меняет высоту символов без изменения заданного значения [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight), которое указывает размер шрифта в пунктах. [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) контролирует межстрочный интервал, тогда как [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) управляет тем, как текст или его контейнер адаптируются к размеру. Эти настройки служат разным целям и могут независимо влиять на общую разметку. Подробнее о форматировании абзацев и наследовании см. в статье [Управление абзацем](/slides/ru/php-java/manage-paragraph/).

## **Применить и удалить зачёркивание**

Используйте [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) на фрагменте текста, чтобы отобразить исправления, отменённые термины или прежние цены без удаления оригинального текста. Установите значение [TextStrikethroughType::Single или Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) для одной или двух линий через текст.

Чтобы удалить зачёркивание, передайте [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None). Это явно отключает эффект, даже если окружающее форматирование указывает на зачёркивание. В отличие от этого, [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) оставляет локальную настройку неопределённой, позволяя фрагменту наследовать форматирование, например, из абзаца. Это не гарантирует, что зачёркивание будет удалено. Используйте [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective), чтобы прочитать получившееся форматирование, включая унаследованные значения.

В следующем автономном примере создаются три сравнения цен. Каждый абзац содержит отдельные фрагменты для метки, прежней цены и текущей цены, поэтому только прежняя цена получает зачёркивание. В первой строке применяется и затем удаляется зачёркивание; остальные строки сохраняют одно и двойное зачёркивание. Изменение этой настройки сохраняет текст и его прочее форматирование, включая жирную прежнюю цену.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // Применить зачёркивание, затем явно удалить его у первой прежней цены.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат сверху вниз: без зачёркивания, с одинарным зачёркиванием и с двойным зачёркиванием.

![Прежние цены без зачёркивания, с одинарным и с двойным зачёркиванием](strikethrough.png)

## **Установить вращение текста**

Используйте [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType), чтобы задать предопределённую ориентацию текста внутри фигуры.

В следующем примере код задаёт ориентацию текста в фигуре как [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

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

## **Установить пользовательский угол вращения для текстовых рамок**

Используйте [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle), чтобы задать произвольный угол вращения для [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

Пример кода ниже вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

Aspose.Slides предоставляет [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) и [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) для управления интервалами абзацев. Эти свойства используются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

В следующем примере задаётся интервал внутри первого абзаца равный 200 % от высоты строки (двойной межстрочный интервал):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Контроль разрыва строк**

Правила разрыва строк абзаца полезны в узких текстовых блоках и презентациях, где смешаны латинский и восточноазиатский тексты. Следующие методы принадлежат [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/), поэтому они применяются ко всему абзацу:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) управляет правилами разрыва строк латиницы. В смешанном тексте изменение этого параметра может также менять место переноса соседнего восточноазиатского текста и знаков пунктуации.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) управляет правилами разрыва строк восточноазиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText), который включает автоматический перенос внутри текстовой рамки. Они влияют на разметку, когда перенос включён; они не вставляют символы разрыва строки. Явный разрыв строки принудительно создаёт новую строку в абзаце независимо от доступной ширины.

В следующем автономном примере создаётся узкий текстовый блок, содержащий китайский и латинский тексты. Оба параметра разрыва строк задаются явно, а результат сохраняется в «line_breaking.pptx». Для экспериментов меняйте соответствующее значение, оставляя другое фиксированным. Пример использует шрифт Arial 24 пункта и SimSun, ширина рамки 160 пунктов и нулевые горизонтальные отступы текстовой рамки. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) вызывается с [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/), чтобы размер текста и размеры рамки оставались фиксированными.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Контроль «висящей» пунктуации**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) позволяет допускаемым знакам пунктуации выходить за правый край строки текста вместо того, чтобы занимать следующую строку. Применяется ко всему абзацу и отличается от висячего отступа.

В следующем автономном примере включается «висящая» пунктуация в текстовой рамке шириной 100 пунктов и сохраняется в «hanging_punctuation.pptx». При шрифте Arial 24 пункта и нулевых горизонтальных отступах последний символ точки остаётся после слова «sentence» и выступает за правый край текста. Установите свойство в [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), чтобы сравнить: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы ширина оставалась фиксированной.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Не каждый знак пунктуации может «висеть». Описанные выше [условия шрифта и разметки](#control-line-breaking) также применимы к этому сравнению: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать видимую разницу.

## **Установить тип автоподгонки для текстовых рамок**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст уменьшаться, выходить за пределы или автоматически изменять размер фигуры. В следующем примере фигура конфигурируется на автоматическое изменение размера под текст, и результат сохраняется в «autofit_type.pptx».

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

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

Чтобы подсчитать количество строк после автоматического переноса и увидеть, как меняются ширина текста или фигуры, см. [Подсчёт отображённых строк](/slides/ru/php-java/manage-paragraph/). Само количество строк не указывает, выходит ли текст за границы контейнера.

## **Установить привязку текстовых рамок**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, посередине или внизу. В следующем примере текст привязывается к нижней части первой фигуры и сохраняется в «text_anchor.pptx».

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

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

Используйте [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) и [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs), чтобы настроить табуляцию в абзаце. В следующем примере задаётся интервал табуляции по умолчанию в 100 пунктов и добавляется табуляция, выровненная по левому краю, в 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

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

Aspose.Slides предоставляет [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId), который позволяет задать язык проверки правописания для фрагмента текста. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

В следующем примере требуется файл «presentation.pptx» с текстовым полем в качестве первой фигуры на первом слайде и как минимум один абзац. Пример заменяет содержимое первого абзаца на «1。», задаёт SimSun как шрифт и назначает язык проверки Simplified Chinese (`zh-CN`). Результат сохраняется в «proofing_language.pptx»:

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

    // Установить идентификатор языка проверки правописания.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Копировать метаданные языка**

При копировании многоязычного текста из шаблона сохраняйте как [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId), так и [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). В следующем автономном примере создаётся исходный фрагмент с английским языком США и альтернативным французским языком, после чего текст и идентификаторы копируются в фрагмент новой презентации.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // Если у источника нет альтернативного языка, null очищает значение назначения.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Чтобы попробовать источник без альтернативного языка, опустите присвоение `"fr-FR"`. Тогда альтернативный идентификатор будет `null`, и та же инструкция копирования сохранит его отсутствие без введения значения по умолчанию, даже если у назначения ранее был установлен альтернативный язык.

Эти идентификаторы хранят метаданные языка. Их сохранение не определяет, какой словарь PowerPoint выберет для проверки орфографии или грамматики.

## **Установить язык по умолчанию**

Используйте [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), чтобы задать язык по умолчанию для текста, создаваемого при загрузке или создании презентации. В следующем примере создаётся презентация с английским языком США в качестве языка текста по умолчанию, добавляется текстовое поле и выводится `en-US` для первого фрагмента текста.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

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

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

В следующем примере задаётся шрифт 14 пунктов, жирный, в качестве значения по умолчанию для абзацев верхнего уровня новой презентации, и сохраняется в «default_text_style.pptx». Текст может наследовать эти значения, если более конкретное форматирование их не переопределяет.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

В PowerPoint применение эффекта шрифта **All Caps** делает текст на слайде отображаемым заглавными буквами, даже если изначально он был введён строчными. При получении такого фрагмента текста с помощью Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы сопоставить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) и при значении `All` преобразуйте возвращённую строку в верхний регистр.

Этот пример требует файл «sample2.pptx» с текстовым полем в качестве первой фигуры на первом слайде. Первый абзац его первого фрагмента содержит «Hello, Aspose!», к которому применён эффект All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

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

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую ячейку через [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) и форматирование абзацев через [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Задайте [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) в значение [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) и настройте точки градиента, направление и прозрачность.