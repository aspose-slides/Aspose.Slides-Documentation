---
title: Управление ячейками таблиц в презентациях с использованием PHP
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/php-java/manage-cells/
keywords:
- ячейка таблицы
- объединять ячейки
- удалять границу
- разделять ячейку
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Управляйте ячейками таблиц PowerPoint в PHP: определяйте объединённые ячейки, удаляйте границы, разделяйте ячейки и задавайте цвета фона и изображения с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблиц в презентациях PowerPoint и изменять их. В этой статье объясняется, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разбиения, изменить цвет фона ячейки и добавить изображение внутри ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячеек через свойства ячеек и сохранить изменённую презентацию в файл PPTX.

Aspose.Slides использует нулевые индексы для доступа к ячейкам таблицы в порядке `(column, row)`.

## **Определить объединённую ячейку таблицы**

Пример открывает существующую презентацию и получает первую форму на первом слайде как таблицу. Предполагается, что слайд и форма существуют и что форма является таблицей. Затем он перебирает все строки и столбцы и использует [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) для определения ячеек в объединённых областях. Для каждого совпадения выводятся координаты ячейки в порядке `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/) и начальные координаты области, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) и [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Удалить границы ячеек таблицы**

Создайте [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и добавьте таблицу на первый слайд с помощью [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Ширины столбцов, высоты строк и позиция таблицы указываются в пунктах. Пример устанавливает все четыре границы ячейки в значение [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), делая их невидимыми.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Объединить ячейки таблицы**

Используйте [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) для объединения прямоугольного диапазона ячеек таблицы в одну ячейку. Укажите ячейки в левом верхнем и правом нижнем углах диапазона. Последний аргумент управляет тем, могут ли объединяться ячейки за пределами указанного диапазона; `false` сохраняет объединение внутри этого диапазона.

Пример создаёт таблицу 4×4 с колонками и строками по 70 пунктов, затем объединяет четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, тогда как базовая сетка таблицы остаётся четырёхколоночной и четырёхстрочной. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её позицию в левом верхнем углу: `$table->get_Item(1, 1)` в этом примере. Другие позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек вне диапазона не меняются.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Разделить ячейки таблицы**

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек справа от неё. Aspose.Slides следует модели сетки таблицы PowerPoint.

Этот пример создаёт таблицу 4×4 с колонками и строками по 70 пунктов и вызывает [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) для ячейки `(1, 1)`. Площадью в половину ширины 70 пунктов передаётся для создания двух ячеек одинаковой ширины.

После этого разделения две половины доступны как `$table->get_Item(1, 1)` и `$table->get_Item(2, 1)`. Сетка таблицы теперь содержит пять столбцов: ячейки, первоначально в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте обновлённые индексы столбцов при доступе к ячейкам после разделения.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Разделить объединённые ячейки по строке или столбцу**

Чтобы подготовить объединённые шаблонные ячейки для заполнения данными, используйте [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) для разбиения вдоль существующей границы строки или [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) для разбиения вдоль границы столбца.

Аргумент `index` считает строки в верхней части или столбцы в левой части разбиения; он относителен к объединённой области:

- Разделение по строке: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Разделение по столбцу: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Пример ожидает, что в презентации первая форма на первом слайде будет таблицей, где ячейки `(1, 2)` и `(1, 3)` объединены вертикально. Начиная с нижней позиции, он использует [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) и [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) для определения начала и проверяет оба охвата. `splitByRowSpan(1)` затем разделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте вместо этого `splitByColSpan(1)`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Получить ячейки, получившиеся в таблице после разбиения.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Сетка таблицы и окружающие индексы ячеек остаются без изменений. Получите результирующие ячейки по их координатам; здесь обе имеют охваты равные 1, и [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) возвращает `false`. Более крупные области могут оставаться частично объединёнными после одного разбиения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пустая, но наследует форматирование ячейки, такое как заливка, границы и отступы. Заполняйте ячейки после разбиения и при необходимости явно задавайте форматирование текста.

Сохранённая презентация содержит отдельные ячейки «Product A» и «Product B» с сохранённым форматированием ячейки шаблона. См. [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) для подробностей.

## **Изменить цвет фона ячейки таблицы**

Этот пример создаёт таблицу со столбцами 150 пунктов и строками 50 пунктов. Он использует [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) для выбора сплошной заливки и задаёт цвет, возвращаемый [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/), в красный для ячейки `(2, 3)`, т. е. в третьем столбце и четвёртой строке.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Добавить изображение внутри ячейки таблицы**

Поместите входное изображение в рабочий каталог перед запуском этого примера. Оно загружается с помощью [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) и добавляется в коллекцию изображений презентации через [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Затем изображение назначается заливке рисунком ячейки `(0, 0)`, первой ячейки таблицы.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) растягивает изображение, заполняя ячейку, что может изменить её соотношение сторон. Ширины столбцов и высоты строк указаны в пунктах. Загруженное изображение освобождается в блоке `finally` после того, как оно добавлено в презентацию.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Можно ли задать разную толщину и стиль линии для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться.

**Что происходит с изображением, если изменить размер столбца/строки после установки рисунка в качестве фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при плиточном отображении плитки пересчитываются.

**Можно ли присвоить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/php-java/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/формы. На практике ссылку назначают части или всему тексту в ячейке.

**Можно ли задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (фрагменты) с независимым форматированием — типом шрифта, стилем, размером и цветом.