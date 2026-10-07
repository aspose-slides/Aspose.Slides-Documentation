---
title: Manage Table Cells in Presentations Using PHP
linktitle: Manage Cells
type: docs
weight: 30
url: /php-java/manage-cells/
keywords:
- table cell
- merge cells
- remove border
- split cell
- image in cell
- background color
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Manage PowerPoint table cells in PHP: identify merged cells, remove borders, split cells, and set background colors and images with Aspose.Slides for PHP via Java."
---

## **Overview**

Aspose.Slides allows you to access and modify table cells in PowerPoint presentations. This article explains how to identify merged table cells, remove cell borders, work with cell numbering after merging or splitting cells, change a cell’s background color, and add an image inside a table cell. The examples show how to create or open a presentation, get a table from a slide, update cell formatting through cell properties, and save the modified presentation as a PPTX file.

Aspose.Slides uses zero-based indices to access table cells in the order `(column, row)`.

## **Identify a Merged Table Cell**

The example opens an existing presentation and accesses the first shape on the first slide as a table. It assumes that the slide and shape exist and that the shape is a table. It then iterates through all rows and columns and uses [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) to identify cells in merged regions. For each match, it prints the cell coordinates in `row;column` order, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), and the region's starting coordinates, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) and [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Remove Table Cell Borders**

Create a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) and add a table to its first slide with [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Column widths, row heights, and the table position are specified in points. The example sets all four cell borders to [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), making them invisible.

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

## **Merge Table Cells**

Use [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) to combine a rectangular range of table cells into one cell. Specify the cells at the top-left and bottom-right corners of the range. The final argument controls whether the merge may include cells outside the specified range; `false` keeps the merge within that range.

The example creates a 4-by-4 table with 70-point columns and rows, then merges the four central cells from `(1, 1)` through `(2, 2)`. The resulting cell spans two columns and two rows, while the table's underlying grid retains four columns and four rows. To access the merged cell's content or formatting, use its top-left position: `$table->get_Item(1, 1)` in this example. The other positions in the merged range remain part of the table grid, so the indices of cells outside the range do not change.

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

## **Split Table Cells**

Merging cells in the previous example preserves the table's grid. Splitting a cell can introduce a new grid column and change the column indices of cells to its right. Aspose.Slides follows PowerPoint's table grid model.

This example creates a 4-by-4 table with 70-point columns and rows and calls [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) on cell `(1, 1)`. Half of the cell's 70-point width is passed to create two equal-width cells.

After this split, the two halves are accessed as `$table->get_Item(1, 1)` and `$table->get_Item(2, 1)`. The table grid now has five columns: cells originally in columns 2 and 3 move to columns 3 and 4, respectively. Row indices remain unchanged. Use these updated column indices when accessing cells after the split.

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

### **Split Merged Cells by Row or Column Span**

To prepare merged template cells for data population, use [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) to split along an existing row boundary, or [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) to split along a column boundary.

The `index` argument counts rows in the upper part or columns in the left part of the split; it is relative to the merged region:

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

The example expects a presentation to have a table as the first shape on the first slide, with `(1, 2)` and `(1, 3)` merged vertically. Starting from the lower position, it uses [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) and [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) to locate the origin and checks both spans. `splitByRowSpan(1)` then separates rows 2 and 3 for product names. For a horizontal two-column merge, use `splitByColSpan(1)` instead.

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

        // Retrieve the resulting cells from the table after splitting.
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

The table grid and surrounding cell indices stay unchanged. Retrieve the resulting cells by their coordinates; here, both have spans of 1 and [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) prints `false`. Larger regions can remain partly merged after one split.

The original text and its formatting remain in the upper (or left) cell; the new cell is empty but inherits cell formatting such as fill, borders, and margins. Populate the cells after splitting and set any required text formatting explicitly.

The saved presentation contains separate "Product A" and "Product B" cells with the template's cell formatting retained. See the [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) for details.

## **Change the Table Cell Background Color**

This example creates a table with 150-point columns and 50-point rows. It uses [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) to select a solid fill and sets the color returned by [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) to red for cell `(2, 3)`, in the third column and fourth row.

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

## **Add an Image Inside a Table Cell**

Place the input image in the working directory before running this example. It loads the image with [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) and adds it to the presentation's image collection with [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). It then assigns the image to the picture fill of cell `(0, 0)`, the first cell in the table.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) stretches the image to fill the cell, which may change its aspect ratio. Column widths and row heights are in points. The loaded image is disposed in a `finally` block after it is added to the presentation.

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

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) borders have separate properties, so the thickness and style of each side can differ.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/php-java/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.
