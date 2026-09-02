---
title: Получить эффективные свойства фигуры из презентаций в PHP
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/php-java/shape-effective-properties/
keywords:
- свойства фигуры
- свойства камеры
- система освещения
- фаска фигуры
- текстовый кадр
- текстовый стиль
- высота шрифта
- формат заполнения
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для PHP через Java, чтобы различать локальное, унаследованное и эффективное форматирование фигур в презентациях PowerPoint."
---
## **Понимание локальных, унаследованных и эффективных свойств**

Форматирование PowerPoint может поступать из нескольких источников. Значение, сохранённое непосредственно в объекте, называется его **локальное значение**. Если это значение не установлено, PowerPoint ищет в родительских источниках форматирования, таких как значение по умолчанию для абзаца, стиль текста, макет или шаблонный слайд, тема или значения по умолчанию уровня презентации. Эти значения являются **унаследованными значениями**. Значение, которое остаётся после разрешения всей иерарии, является **эффективным значением** — значение, используемое для отображения объекта.

Например, часть текста может не определять собственный размер шрифта. Ее локальное значение [getFontHeight](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/) тогда равно `NAN`, что означает «не задано здесь». Часть может унаследовать высоту от абзаца, стиля текста по умолчанию презентации или другого применимого источника. Вызов [getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/geteffective/) для формата части возвращает окончательно разрешённую высоту.

Используйте два типа данных форматирования для разных целей:

- Читать или изменять локальный объект формата, например [PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/), когда необходимо контролировать, где определено значение.
- Читать объект эффективных данных, например [данные, возвращаемые PortionFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/geteffective/), когда нужен окончательный отрисованный результат. Эффективные данные доступны только для чтения.

Перед запуском примеров, [установите Aspose.Slides для PHP через Java](/slides/ru/php-java/installation/).

## **Сравнение локальных, унаследованных и эффективных значений**

Следующий полный пример создает фигуру и задаёт высоту шрифта на уровнях презентации, абзаца и части текста. На каждом этапе выводятся значения, определённые на этих уровнях, и получаемое эффективное значение для той же части текста. Также показано, почему эффективные данные необходимо считывать снова после изменений форматирования.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Прочитать эффективные данные после предыдущих изменений.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Определить унаследованные значения на двух разных уровнях.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Локальное значение в части переопределяет обоих унаследованных значения.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Изменение унаследованного значения не переопределяет существующее локальное значение.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Очистить локальное значение. Часть теперь снова наследует от абзаца опять.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Очистить значение абзаца. Значение по умолчанию презентации теперь поставляет результат.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Приоритет в этом примере: локальное форматирование части, затем форматирование абзаца, затем значение по умолчанию презентации. У других объектов может быть другая цепочка наследования, но принцип остаётся тем же: более конкретное явное значение выигрывает, и [getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/geteffective/) возвращает окончательный результат.

## **Получение эффективных свойств текста**

Форматирование текста распределено по нескольким объектам:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/geteffective/) определяет свойства текстового кадра, такие как отступы, привязка, автоподгонка и вертикальное направление текста.
- [TextStyle.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textstyle/geteffective/) определяет форматирование абзаца для каждого уровня стиля текста.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraphformat/geteffective/) определяет свойства абзаца, такие как выравнивание, отступы и маркеры.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/geteffective/) определяет свойства символов, такие как высота шрифта, гарнитура, цвет, полужирный и курсив.

Для следующего примера `text-formatting.pptx` должен содержать как минимум один слайд и одну [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) с непустым текстовым кадром. AutoShape может находиться в любой позиции коллекции фигур; код ищет подходящий объект и проверяет его перед использованием.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Получение эффективных 3D‑свойств**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/geteffective/) возвращает один объект эффективных данных, который группирует все разрешённые 3D‑настройки. Его методы [getCamera](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/geteffective/) и [getBevelBottom](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/geteffective/) предоставляют соответствующие эффективные данные. Совместное чтение этих связанных настроек упрощает понимание окончательного 3D‑внешнего вида фигуры.

Для этого примера `shape-3d.pptx` должен содержать как минимум одну фигуру на первом слайде. Примените к этой фигуре 3D‑камеру, освещение или настройки фаски, если хотите, чтобы вывод содержал значения, отличные от стандартных.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Получение эффективного форматирования таблицы**

Форматирование таблицы может исходить из стиля таблицы и из форматов, применённых ко всей таблице, столбцу, строке или отдельной ячейке. При конфликте явно заданных заполнений приоритет имеет ячейка, затем строка, столбец и, наконец, вся таблица. Эффективный формат ячейки — это окончательный формат, используемый для её отрисовки.

Для этого примера `table-formatting.pptx` должен содержать как минимум одну таблицу на первом слайде. Таблица должна иметь хотя бы одну строку и один столбец. Код ищет объект [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/), а не предполагает, что `getShapes()->get_Item(0)` является таблицей.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Если вам нужен цвет, а не только тип заполнения, сначала проверьте эффективное значение [getFillType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/geteffective/), а затем вызовите метод, соответствующий этому типу — например, [getSolidFillColor](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/geteffective/) для сплошного заполнения.

## **Повторное чтение эффективных данных после изменений**

Эффективные данные описывают иерархию форматирования в момент их разрешения. Вызовите `getEffective` снова после изменения любого элемента, участвующего в этой иерархии, включая:

- локальное форматирование объекта;
- значения по умолчанию абзаца или текстового кадра;
- стиль таблицы, таблицу, столбец, строку или формат ячейки;
- форматирование макета или шаблонного слайда;
- данные темы или значения по умолчанию уровня презентации;
- макет или шаблон, назначенный слайду.

Не храните объект эффективных данных как постоянный снимок. Aspose.Slides может кэшировать некоторые эффективные данные внутренне, и последующий вызов `getEffective` может обновить эти данные. Если нужно сравнить значения до и после изменения, скопируйте необходимые скалярные значения — например, высоту шрифта, цвет, выравнивание или ширину фаски — в свои переменные перед внесением изменений.

Чтобы изменить значение, обновите соответствующий локальный объект формата, а затем вызовите `getEffective` для проверки результата. Объекты эффективных данных сами по себе доступны только для чтения.

## **FAQ**

**Как определить, какой уровень предоставил эффективное значение?**

Эффективные данные содержат только окончательное значение, а не его источник. Проверьте соответствующие локальные объекты, начиная с самого специфичного уровня и переходя наружу. Для текста это могут быть часть, абзац, текстовый кадр, макет, шаблон, тема и значения по умолчанию презентации. Неопределённые значения, такие как `NAN` или `null`, указывают, что поиск продолжается на следующем уровне.

**Что происходит, когда ни один уровень не определяет свойство?**

Aspose.Slides определяет соответствующее значение по умолчанию PowerPoint или библиотеки. Это разрешённое значение появляется в эффективных данных, даже если ни один локальный объект явно его не задаёт.

**Почему эффективное значение иногда равно локальному?**

Локальное значение победило в расчёте наследования. Это происходит, когда свойство явно установлено у объекта и более специфичное правило его не переопределяет.

**Когда следует использовать локальные данные вместо эффективных?**

Используйте локальные данные для проверки или изменения конкретного уровня форматирования. Используйте эффективные данные, когда нужен окончательный внешний вид после применения наследования, правил темы и соответствующих стилей. [Полный пример сравнения](#compare-local-inherited-and-effective-values) демонстрирует оба подхода в одном рабочем процессе.