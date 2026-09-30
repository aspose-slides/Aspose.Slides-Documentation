---
title: Управление таблицами презентаций в PHP
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/php-java/manage-table/
keywords:
- добавить таблицу
- создать таблицу
- доступ к таблице
- соотношение сторон
- выравнивание текста
- форматирование текста
- стиль таблицы
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для PHP через Java. Откройте простые примеры кода, чтобы оптимизировать работу с таблицами."
---
## **Введение**

Таблицы в PowerPoint упорядочивают информацию в строки и столбцы, упрощая чтение и сравнение значений.

Aspose.Slides предоставляет класс [Таблица](https://reference.aspose.com/slides/php-java/aspose.slides/table/) класс [Ячейка](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами в презентациях.

## **Создать таблицу с нуля**

Создайте таблицу, указав её положение, ширину столбцов и высоту строк. После добавления её в слайд вы можете форматировать границы ячеек, объединять ячейки и вставлять текст.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Определите массив ширин столбцов в пунктах.
4. Определите массив высот строк в пунктах.
5. Добавьте объект [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
6. Итерируйтесь по каждой [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)..., чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите доступ к объединённой ячейке через её метод [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/).
9. Установите текст в объединённой ячейке.
10. Сохраните изменённую презентацию.

Пример ниже создаёт таблицу с тремя колонками и пятью строками в точках (100, 50). Он применяет красные границы шириной 5 пунктов, объединяет первые две ячейки первой строки и сохраняет результат как `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Нумерация в обычной таблице**

В обычной таблице индексы ячеек нумеруются с нуля и используют порядок (столбец, строка). Первая ячейка имеет индекс (0, 0).

Например, ячейки в таблице с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот пример создаёт 4 × 4 таблицу, изображённую выше, с шириной столбцов и высотой строк по 70 пунктов и красными границами ячеек шириной 5 пунктов. Координаты показывают индексы ячеек; пример оставляет ячейки пустыми и сохраняет таблицу как `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Доступ к существующей таблице**

Таблицы хранятся в коллекции фигур слайда. Итерируйтесь по фигурам, чтобы найти таблицу, затем используйте класс [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) для чтения или обновления её ячеек.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий таблицу, по её индексу.
3. Итерируйтесь по объектам [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) и останавливайтесь, когда найдёте таблицу. Если слайд содержит несколько таблиц, используйте [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) для определения нужной.
4. Обновите текст в целевой ячейке.
5. Сохраните изменённую презентацию.

Пример ниже открывает `UpdateExistingTable.pptx` и находит первую таблицу на первом слайде. Он устанавливает значение ячейки в столбце 0, строке 1 в `New` и сохраняет результат как `table1_out.pptx`. Входной файл должен содержать минимум один слайд, а первая таблица на этом слайде должна иметь хотя бы один столбец и две строки.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Чтобы изменить высоту строки в существующей таблице и понять, почему её фактическая высота может превышать запрошенный минимум, см. [Управление высотой строки](/slides/ru/php-java/manage-rows-and-columns/#control-row-height).

## **Найти ячейку, владеющую текстовым фреймом**

Когда общий код обработки текста получает [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) из таблицы, используйте метод [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) для получения владеющей [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/). Для текстового фрейма ячейки таблицы [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) возвращает владельца, а [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) возвращает `null`, хотя сама таблица является фигурой.

Координаты ячейки доступны через только для чтения методы [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) и [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/). [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) также обеспечивает навигацию только для чтения: он возвращает владельца, но не меняет собственность. Всегда проверяйте возвращённую ячейку с помощью `java_is_null` перед её использованием.

Для полного примера, который определяет владельцев ячеек таблицы и фигур, включая фигуры, связанные с узлами SmartArt, см. [Поиск и замена текста](/slides/ru/php-java/search-and-replace-text/).

## **Выравнивание текста в таблице**

Вы можете управлять вертикальной привязкой и направлением текста отдельных ячеек таблицы. Пример в этом разделе центрирует текст в первой ячейке и вращает его на 270 градусов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) на слайд.
4. Получите объект [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) из таблицы.
5. Получите первый [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) и задайте его текст и цвет.
6. Установите вертикальную привязку ячейки и направление текста с помощью [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) и [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/).
7. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 4 × 4 со шириной столбцов 120 пунктов и высотой строк 100 пунктов. Он форматирует текст в ячейке (0, 0), добавляет значения в оставшиеся ячейки первой строки и сохраняет результат как `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установить форматирование текста на уровне таблицы**

Используйте [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) для применения форматирования текста ко всем ячейкам в таблице. Его перегрузки принимают форматирование части, абзаца и текстового фрейма, поэтому вы можете задавать эти свойства без перебора отдельных ячеек.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите объект [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) со слайда.
4. Установите размер шрифта с помощью [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) для текста.
5. Установите выравнивание абзаца и правый отступ с помощью [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) и [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Установите направление текста с помощью [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Сохраните изменённую презентацию.

Пример ниже открывает `table.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он задаёт размер шрифта 25 пунктов, выравнивает абзацы по правому краю с правым отступом 20 пунктов и делает текст вертикальным. Отформатированная презентация сохраняется как `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Получить свойства стиля таблицы**

Используйте [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) для чтения предустановленного стиля таблицы и [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) для его назначения. Этот пример применяет [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) к одной таблице, выводит значение предустановки и назначает ту же предустановку второй таблице. Обе таблицы сохраняются в `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Блокировать соотношение сторон таблицы**

Соотношение сторон таблицы — это отношение её ширины к высоте. Используйте [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) для блокировки этого соотношения у таблицы.

Пример ниже открывает `pres.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он выводит текущее состояние блокировки, включает блокировку соотношения сторон, выводит обновлённое состояние (`true`) и сохраняет результат как `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Можно ли включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/), а у абзацев есть [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Использование обоих обеспечивает правильный порядок RTL и рендеринг внутри ячеек.

**Как предотвратить перемещение или изменение размера таблицы пользователями в конечном файле?**

Используйте [блокировки фигур](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) для отключения перемещения, изменения размера, выделения и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) для ячейки; изображение будет покрывать область ячейки в соответствии с выбранным режимом (растягивание или плитка).