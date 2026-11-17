---
title: Управление ячейками таблиц в презентациях с использованием PHP
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/php-java/manage-cells/
keywords:
- ячейка таблицы
- объединение ячеек
- удаление границы
- разделение ячейки
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Управляйте ячейками таблиц PowerPoint в PHP: определяйте объединённые ячейки, удаляйте границы, разделяйте ячейки и задавайте цвета фона и изображения с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблиц в презентациях PowerPoint и изменять их. В этой статье объясняется, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разбиения, изменить цвет фона ячейки и добавить изображение внутри ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячеек через свойства ячейки и сохранить изменённую презентацию в файл PPTX.

Aspose.Slides использует индексы, начинающиеся с нуля, для доступа к ячейкам таблицы в порядке `(column, row)`.

## **Определение объединённой ячейки таблицы**

Пример открывает существующую презентацию и получает доступ к первой фигуре на первом слайде как к таблице. Предполагается, что слайд и фигура существуют и что фигура является таблицей. Затем он перебирает все строки и столбцы и использует [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) для определения ячеек в объединённых областях. Для каждой найденной ячейки выводятся её координаты в порядке `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), и начальные координаты области, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) и [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Удаление границ ячейки таблицы**

Создайте [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и добавьте таблицу на её первый слайд с помощью [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Ширины столбцов, высоты строк и позиция таблицы задаются в пунктах. В примере все четыре границы ячейки устанавливаются в [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), делая их невидимыми.

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

## **Добавление диагональных границ ячейки**

Используйте [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) для рисования линии от верхнего левого угла к нижнему правому, и [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) для линии от нижнего левого угла к верхнему правому. Диагональ может обозначать заголовок угла; обе диагонали могут образовать X, помечая ячейку как не применимую.

У каждой диагонали есть собственный [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/). В его [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) используйте [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) для выбора [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) и выберите цвет через [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). Установите толщину линии в пунктах с помощью [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/).

Пример создает три ячейки в одной строке: красную диагональ, направленную вниз, синюю диагональ, направленную вверх, и обе диагонали. Верхние, нижние, левый и правый края ячеек остаются без изменений.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Диагональ изменяет только форматирование ячейки. Каждая ячейка сохраняет единственный текстовый фрейм, доступ к которому осуществляется через [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). Области по обе стороны от диагонали нельзя редактировать независимо.

Сохранённая таблица, отображённая в Microsoft PowerPoint:
![Три ячейки таблицы, показывающие красную диагональ от верхнего левого угла к нижнему правому, синюю диагональ от нижнего левого угла к верхнему правому и обе диагонали, образующие X.](diagonal-cell-borders.png)

*Слева направо: диагональ вниз (красная, 3 пт), диагональ вверх (синяя, 5 пт) и обе диагонали.*

## **Объединение ячеек таблицы**

Используйте [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) для объединения прямоугольного диапазона ячеек таблицы в одну ячейку. Укажите ячейки в левом верхнем и правом нижнем углах диапазона. Последний аргумент определяет, может ли объединение включать ячейки за пределами указанного диапазона; `false` сохраняет объединение внутри этого диапазона.

Пример создаёт таблицу 4 × 4 со столбцами и строками по 70 пунктов, затем объединяет четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, при этом базовая сетка таблицы остаётся четырёх столбцов и четырёх строк. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её позицию в левом верхнем углу: `$table->get_Item(1, 1)` в этом примере. Другие позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек за пределами диапазона не меняются.

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

## **Разделение ячеек таблицы**

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек справа от неё. Aspose.Slides следует модели сетки таблиц PowerPoint.

В этом примере создаётся таблица 4 × 4 со столбцами и строками по 70 пунктов и вызывается [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) для ячейки `(1, 1)`. Половина ширины ячейки 70 пунктов передаётся для создания двух ячеек одинаковой ширины.

После этого разделения две половины доступны как `$table->get_Item(1, 1)` и `$table->get_Item(2, 1)`. Сетка таблицы теперь имеет пять столбцов: ячейки, первоначально в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте обновлённые индексы столбцов при доступе к ячейкам после разделения.

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

<!-- visual-explanation:manage-cells:start -->
[![Необъединённая ячейка шириной 70 пунктов разбивается на две ячейки по 35 пунктов, добавляя пятый столбец сетки и сдвигая индексы справа.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Разделение по ширине влияет на ячейку (1, 1), используя нулевые (column, row) индексы. Другие строки сохраняют ячейку, охватывающую оба новых положения столбца.*
<!-- visual-explanation:manage-cells:end -->

### **Разделение объединённых ячеек по строковому или столбцовому охвату**

Чтобы подготовить объединённые ячейки шаблона к заполнению данными, используйте [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) для разделения вдоль существующей границы строки, или [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) для разделения вдоль границы столбца.

Аргумент `index` считает строки в верхней части или столбцы в левой части разделения; он относителен к объединённой области:
- Разделение по строке: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Разделение по столбцу: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

В примере предполагается, что презентация содержит таблицу в виде первой фигуры на первом слайде, при этом `(1, 2)` и `(1, 3)` объединены вертикально. Начиная с нижней позиции, он использует [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) и [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) для определения начала и проверяет оба охвата. `splitByRowSpan(1)` затем разделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте `splitByColSpan(1)` вместо этого.

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

        // Получить результирующие ячейки из таблицы после разделения.
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

Сетка таблицы и окружающие индексы ячеек остаются без изменений. Получите результирующие ячейки по их координатам; здесь обе имеют охват 1, и [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) выводит `false`. Более крупные области могут оставаться частично объединёнными после одного разделения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пуста, но наследует форматирование ячейки, такое как заливка, границы и отступы. Заполните ячейки после разделения и явно задайте необходимое форматирование текста.

Сохранённая презентация содержит отдельные ячейки "Product A" и "Product B" с сохранённым форматированием ячеек из шаблона. См. [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) для деталей.

### **Разделение ячейки на определённую высоту**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) принимает высоту верхней части в пунктах. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) принимает количество существующих строк сетки в верхней части. Чтобы расположить 40‑пунктовую ячейку по центру правого столбца, вычтите 40 из фактической высоты ячейки и равномерно распределите оставшееся пространство сверху и снизу.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Первое разделение добавляет строку в сетку и оставляет нижние 90 пунктов в ячейке `(1, 1)`. Второе разделение делит эту ячейку на среднюю ячейку высотой 40 пунктов и нижнюю ячейку высотой 50 пунктов. Правый столбец теперь содержит три ячейки высотой 50, 40 и 50 пунктов сверху вниз. Левая ячейка охватывает все три строки и сохраняет свою исходную высоту 140 пунктов.

![Левая ячейка охватывает всю высоту таблицы рядом с тремя ячейками, где средняя находится в центре.](split-by-height.png)

## **Изменение цвета фона ячейки таблицы**

В этом примере создаётся таблица со столбцами по 150 пунктов и строками по 50 пунктов. Он использует [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) для выбора сплошной заливки и задаёт цвет, возвращаемый [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/), как красный для ячейки `(2, 3)`, в третьем столбце и четвёртой строке.

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

## **Добавление изображения внутрь ячейки таблицы**

Поместите исходное изображение в рабочий каталог перед запуском этого примера. Он загружает изображение с помощью [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile), и добавляет его в коллекцию изображений презентации через [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Затем изображение назначается как заливка картинки ячейки `(0, 0)`, первой ячейки таблицы.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) растягивает изображение, заполняя ячейку, что может изменить его соотношение сторон. Ширины столбцов и высоты строк задаются в пунктах. Загруженное изображение освобождается в блоке `finally` после добавления в презентацию.

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

**Могу ли я задать различную толщину и стиль линий для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки как фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/). При растягивании изображение подгоняется под новую ячейку; при плиточном заполнении плитки пересчитываются.

**Могу ли я присвоить гиперссылку всему содержимому ячейки?**

[Гиперссылки](/slides/ru/php-java/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/фигуры. На практике ссылка назначается части или всему тексту в ячейке.

**Могу ли я задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), позволяющие задавать независимое форматирование — семейство шрифта, стиль, размер и цвет.