---
title: Управление текстовыми полями в презентациях с использованием PHP
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/php-java/manage-textbox/
keywords:
- текстовое поле
- текстовый кадр
- добавить текст
- обновить текст
- создать текстовое поле
- проверить текстовое поле
- добавить колонку текста
- добавить гиперссылку
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте, определяйте, форматируйте и обновляйте текстовые поля в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java."
---
## **Введение**

В Aspose.Slides for PHP via Java текст слайдов хранится в текстовых кадрах, которые принадлежат фигурам. Класс [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) представляет наиболее распространённую форму, содержащую текст, и предоставляет доступ к её тексту через метод [AutoShape::getTextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Каждая автофигура наследуется от [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/), но не каждая фигура является автофигурой или поддерживает текстовый кадр. При обработке существующей презентации используйте `java_instanceof`, чтобы проверить, что фигура является [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) перед доступом к её тексту.
{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле, добавьте автофигуру на слайд, добавьте текст в её текстовый кадр и сохраните презентацию. Ниже приведён пример, создающий прямоугольное текстовое поле:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Координаты и размеры, передаваемые в метод [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/#addAutoShape), измеряются в пунктах. [AutoShape::addTextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/#addTextFrame) инициализирует текстовый кадр переданным текстом.

## **Проверка, является ли фигура текстовым полем**

Используйте метод [AutoShape::isTextBox](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/#isTextBox), чтобы определить, рассматривается ли автофигура как текстовое поле. Это полезно, когда презентация содержит как автофигуры с текстом, так и чисто графические автофигуры.

![Текстовое поле и фигура](istextbox.png)

Ниже приведён пример, проверяющий каждую автофигуру в презентации:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Новоя добавленная автофигура не считается текстовым полем, пока в ней нет непустого текста. Вы можете задать этот текст через [AutoShape::addTextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/#addTextFrame) или [TextFrame::setText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#setText). Добавление или присвоение пустой строки приводит к тому, что [AutoShape::isTextBox](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/#isTextBox) возвращает `false`:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Первые два вызова выводят `true`; последние два — `false`.

## **Найти форму, владеющую текстовым кадром**

Общий код обработки текста может получать объект [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) без сведения к тому, какой объект презентации его содержит. Используйте только для чтения метод [TextFrame::getParentShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentShape), чтобы вернуться к его родительской [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/).

Для текстового кадра, принадлежащего автофигуре или иной фигуре с текстом, [TextFrame::getParentShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentShape) возвращает владельца, а [TextFrame::getParentCell](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#getParentCell) возвращает `null`. Проверьте возвращаемое значение с помощью `java_is_null` перед доступом к нему. Чтобы определить как владельцев фигур, так и ячеек таблиц, включая фигуры, связанные с узлами SmartArt, см. [Поиск и замена текста](/slides/ru/php-java/search-and-replace-text/).

## **Добавление колонок в текстовое поле**

Метод [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setColumnCount) делит текстовый кадр на колонки, а [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setColumnSpacing) задаёт расстояние между колонками в пунктах. Оба параметра относятся к [TextFrameFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/) и могут быть изменены через текстовый кадр существующего текстового поля. Текст перетекать между колонками внутри одной фигуры; он не продолжает поток в другую фигуру.

Ниже приведён пример, который создаёт текстовое поле с тремя колонками и отступом 10 пунктов между колонками, сохраняет презентацию и считывает сохранённые параметры из выходного файла:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Извлечение текста из отдельных колонок**

Используйте [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/#splitTextByColumns), чтобы получить текст, присвоенный каждой визуальной колонке в существующем текстовом кадре. Метод возвращает одну строку для каждой колонки в порядке чтения по колонкам. Текстовый кадр с одной колонкой возвращает массив из одного элемента, а пустая колонка представлена пустой строкой. Строки содержат только обычный текст; форматирование уровня части не сохраняется.

Это полезно, когда требуется:

- Извлечь текст, сохранив порядок чтения по колонкам.
- Проиндексировать или сравнить содержимое слайдов с несколькими колонками.
- Экспортировать каждую колонку в отдельный файл, поле базы данных или другое назначение.
- Проанализировать, как текст перераспределяется после изменения количества колонок с помощью [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setColumnCount), расстояния с помощью [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/#setColumnSpacing), шрифта или размеров текстового кадра.

Метод сообщает о тексте, распределённом внутри текущего [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/); он не автоматически переносит текст между отдельными фигурами или текстовыми полями. Распределение по колонкам может зависеть от доступных шрифтов и других настроек разметки текста, поэтому убедитесь, что необходимые шрифты доступны, когда важна согласованность результатов.

Ниже пример, который загружает презентацию, находит первую автофигуру с несколькими колонками и текстовым кадром, читает её настроенное количество колонок и записывает текст каждой колонки в отдельный файл. Фигуры без текстового кадра пропускаются.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Обновление текста**

Чтобы обновить текст во всей презентации, пройдите по слайдам и фигурам, выберите автофигуры и затем редактируйте их части текста. Работа на уровне частей позволяет менять как сам текст, так и форматирование символов.

Ниже пример, который заменяет каждое вхождение `years` на `months` в тексте автофигур и делает каждую затронутую часть жирной:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Этот проход обновляет текст только в автофигурах. Текст, хранящийся в таблицах, диаграммах, SmartArt или сгруппированных фигурах, требует обхода соответствующих коллекций этих объектов.

## **Добавление текстового поля со ссылкой**

Ссылка может быть назначена конкретной части текста, поэтому только эта часть будет кликабельной. Используйте [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), чтобы связать часть с внешним URL.

Ниже пример, создающий ссылочный текст и сохраняющий его в презентацию:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Часто задаваемые вопросы**

**В чём разница между текстовым полем и текстовым заполнительным элементом на мастере или макете слайда?**

[Заполнитель](/slides/ru/php-java/manage-placeholder/) может наследовать своё положение и форматирование от [главного слайда](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslide/) или [слайда макета](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslide/). Обычное текстовое поле — это независимая фигура на том слайде, где оно было создано, и не получает поведение заполнителя при изменении макета.

**Как заменить текст, не изменяя его в диаграммах, таблицах или SmartArt?**

Ограничьте обход объектами [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/), как показано в примере «Обновление текста». Диаграммы, таблицы и SmartArt хранят текст в своих собственных моделях объектов, поэтому они не изменятся в этом цикле.