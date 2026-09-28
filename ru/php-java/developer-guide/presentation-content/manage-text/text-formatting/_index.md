---
title: Форматировать текст презентации в PHP
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
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- привязка текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для PHP через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для PHP через Java. Она охватывает фоновые цвета, прозрачность, интервал между символами, свойства шрифта, вращение, интервал между абзацами, поведение автоподгонки, привязку текста, табуляцию и настройки языка.

Если не указано иное, в примерах используется [sample.pptx](sample.pptx). Первая фигура на первом слайде представляет собой текстовое поле, и его первый абзац содержит показанный ниже текст. Индексы слайдов и фигур начинаются с нуля. Примеры, которые выделяют жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярного выражения, см. [Поиск и замена текста](/slides/ru/php-java/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), чтобы задать цвет выделения по умолчанию для абзаца, или используйте [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#getHighlightColor) для отдельных текстовых фрагментов.

Следующий пример задаёт светло‑серое выделение по умолчанию для первого абзаца. Явные цвета выделения для отдельных фрагментов имеют приоритет над этим значением по умолчанию:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Установить цвет выделения для всего абзаца.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже приведён пример кода, демонстрирующий, как установить цвет фона для **текстовых фрагментов с полужирным шрифтом**:

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
            // Установить цвет выделения для текстового фрагмента.
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

Используйте [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setAlignment), чтобы задать выравнивание абзаца внутри текстового кадра. Значение может быть центрировано, выровнено по левому краю, по правому, по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

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

## **Установить прозрачность текста**

Прозрачность текста управляется через альфа‑компонент цвета, назначенного [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#getFillFormat). В приведённых ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже пример кода, показывающий, как применить прозрачность к **всему абзацу**:

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

Следующий пример кода показывает, как применить прозрачность к **текстовым фрагментам с полужирным шрифтом**:

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

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установить интервал между символами для текста**

Используйте [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setSpacing), чтобы расширить или сузить интервал между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сжимают текст.

Ниже PHP‑код, показывающий, как расширить интервал между символами в **всём абзаце**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Примечание: Используйте отрицательные значения для сжатия интервала между символами.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Увеличить интервал между символами.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Ниже пример кода, показывающий, как расширить интервал между символами в **текстовых фрагментах с полужирным шрифтом**:

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
            // Примечание: Используйте отрицательные значения для сжатия интервала между символами.
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

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть слегка уже, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint может игнорировать данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать отрисованный результат более похожим на PowerPoint в таких случаях, можно отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) в значение, большее фактического размера шрифта. Этот пример требует файла "presentation.pptx" с текстовым полем в первой фигуре первого слайда. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог 100 пунктов для фрагментов, использующих Roboto. Это отключает кернинг для соответствующих фрагментов с размером шрифта менее 100 пунктов:

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

Для соответствующего текста ниже порога эта настройка предотвращает кернинг и может помочь согласовать визуальный вывод Aspose.Slides с PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задавать на уровне абзаца через [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) или на отдельных фрагментах через [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/).

Следующий пример задаёт шрифт по умолчанию первого абзаца: Times New Roman 12 пунктов, полужирный, курсив и пунктирное подчеркивание. Явное форматирование отдельных фрагментов имеет приоритет над этими значениями по умолчанию:

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

Следующий пример применяет Times New Roman 13 пунктов, курсив и пунктирное подчеркивание к фрагментам, у которых эффективное форматирование содержит полужирный шрифт:

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

![Свойства шрифта текстовых фрагментов](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setTextVerticalType), чтобы задать предопределённую ориентацию текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как [TextVerticalType::Vertical270](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

## **Установить пользовательское вращение для текстовых рамок**

Используйте [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setRotationAngle), чтобы задать пользовательский угол вращения для [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/).

Приведённый ниже пример кода вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

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

## **Задать межстрочный интервал абзацев**

Aspose.Slides предоставляет [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setSpaceBefore) и [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setSpaceWithin) для управления интервалом абзацев. Эти свойства используются следующим образом:

* Задайте положительное значение, чтобы указать межстрочный интервал в процентах от высоты строки.
* Задайте отрицательное значение, чтобы указать межстрочный интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца как 200 % от высоты строки (двойной интервал):

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

Правила разрыва строк в абзаце полезны в узких блоках текста и презентациях, где смешивается латинский и восточноазиатский текст. Следующие методы принадлежат [ParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/), поэтому они применяются ко всему абзацу:

- [setLatinLineBreak](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) управляет правилами разрыва строк для латинского текста. В смешанном тексте изменение этого параметра также может менять место переноса соседнего восточноазиатского текста и пунктуации.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) управляет правилами разрыва строк для восточноазиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setWrapText), который включает автоматический перенос внутри текстовой рамки. Они влияют на макет при выполнении переноса; они не вставляют символы разрыва строки. Явный разрыв строки принудительно создаёт новую строку в абзаце независимо от доступной ширины.

Следующий автономный пример создаёт узкий блок текста, содержащий китайский и латинский текст. Он явно задаёт оба параметра разрыва строк и сохраняет файл "line_breaking.pptx". Чтобы поэкспериментировать с каждым из правил, измените соответствующее значение, оставив остальные настройки неизменными. В примере используется шрифт Arial 24 пункта и SimSun, ширина рамки 160 пунктов и нулевые горизонтальные отступы текстовой рамки. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setAutofitType) вызывается с [TextAutofitType::None](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textautofittype/), чтобы размер текста и размеры рамки оставались фиксированными.

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

## **Управление висящей пунктуацией**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) позволяет допустимой пунктуации выходить за правый край строки текста вместо того, чтобы занимать следующую строку. Применяется ко всему абзацу и отличается от висячего отступа.

Следующий автономный пример включает висячую пунктуацию в текстовой рамке шириной 100 пунктов и сохраняет файл "hanging_punctuation.pptx". При шрифте Arial 24 пункта и нулевых горизонтальных отступах, конечная точка остаётся после слова "sentence" и выходит за правый край текста. Установите свойство в [NullableBool::False](https://reference.aspose.com/slides/ru/php-java/aspose.slides/nullablebool/), чтобы сравнить: с этими настройками точка будет находиться на отдельной строке. Перенос включён, а автоподгонка отключена, чтобы фиксировать доступную ширину.

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

Не каждый знак пунктуации может висеть. Видимый результат зависит от доступности шрифта и макета: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать видимую разницу.

## **Задать тип автоподгонки для текстовых рамок**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setAutofitType) определяет, как текст будет себя вести, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за пределы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру так, чтобы она изменялась в размере под текст, и сохраняет результат в файл "autofit_type.pptx".

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

Чтобы подсчитать строки после автоматического переноса и увидеть, как изменяется ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/php-java/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых рамок**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setAnchoringType) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, посередине или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в файл "text_anchor.pptx".

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

Используйте [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) и [ParagraphFormat::getTabs](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/#getTabs) для настройки табуляций в абзаце. Следующий пример задаёт интервал табуляции по умолчанию 100 пунктов и добавляет табуляцию, выровненную по левому краю, на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

![Табуляции абзаца](paragraph_tabs.png)

## **Установить язык проверки**

Aspose.Slides предоставляет [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId), который позволяет задать язык проверки для текстового фрагмента. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует файл "presentation.pptx" с текстовым полем в первой фигуре первого слайда и как минимум один абзац. Он заменяет содержимое первого абзаца на "1。", задаёт шрифт SimSun и назначает язык проверки Simplified Chinese (`zh-CN`). Сохраняет результат в файл "proofing_language.pptx":

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

    // Установить идентификатор языка проверки.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установить язык по умолчанию**

Используйте [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), чтобы определить язык по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с американским английским в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для первого текстового фрагмента.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

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

Следующий пример задаёт 14‑пунктовый полужирный шрифт в качестве значения по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в файл "default_text_style.pptx". Текст может наследовать эти значения по умолчанию, если более специфичное форматирование не переопределяет их.

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

## **Извлечь текст с эффектом ALL CAPS**

В PowerPoint применение эффекта шрифта **All Caps** заставляет текст отображаться заглавными буквами на слайде, даже если он был введён строчными. При получении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы соответствовать отображаемому тексту, проверьте [TextCapType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Этот пример требует файл "sample2.pptx" с текстовым полем в первой фигуре первого слайда. Его первый абзац содержит первую часть "Hello, Aspose!" с применённым эффектом All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Ниже пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:

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

## **Часто задаваемые вопросы**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую ячейку через [Cell::getTextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cell/#getTextFrame) и форматирование абзацев через [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#getFillFormat). Установите [FillFormat::setFillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/#setFillType) в [FillType::Gradient](https://reference.aspose.com/slides/ru/php-java/aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.