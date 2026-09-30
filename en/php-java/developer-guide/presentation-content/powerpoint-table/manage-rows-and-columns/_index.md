---
title: Manage Rows and Columns in PowerPoint Tables Using PHP
linktitle: Rows and Columns
type: docs
weight: 20
url: /php-java/manage-rows-and-columns/
keywords:
- table row
- table column
- first row
- table header
- clone row
- clone column
- copy row
- copy column
- remove row
- remove column
- row text formatting
- column text formatting
- table style
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Manage table rows and columns in PowerPoint with Aspose.Slides for PHP via Java and speed up presentation editing and data updates."
---

## **Introduction**

Aspose.Slides for PHP via Java lets you manage table structure and formatting in PowerPoint presentations through the [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) class. You can designate a header row, clone or remove rows and columns, and apply text formatting to an entire row or column.

This article explains these operations with PHP examples. It also shows how to retrieve a table's style preset so you can reuse it. Table row and column indices are zero-based.

## **Control Row Height**

Use [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) to set a row's minimum height in points. It is a lower bound, not a fixed height. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) returns the actual height. Access the row through [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

The example loads [row-height-input.pptx](row-height-input.pptx), which has a table as the first shape on the first slide. Its first row starts at 70 points. The cells use 18-point Arial text, wrapping, and 6-point top and bottom margins; the longer text in the second column wraps onto multiple lines. The example increases the minimum to 100 points, then decreases it to 20 points, prints the actual height after each change, and saves both results.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

With the supplied presentation, increasing the minimum adds space to the row. Decreasing it removes that extra space, but the actual height remains greater than 20 points because the text and cell margins need more room. Reducing the minimum alone cannot force the row below the space required by its content.

Several factors affect the actual height:

- **Text and font size:** longer text, explicit line breaks, or a larger font can require more vertical space.
- **Wrapping and column width:** with wrapping enabled, reducing the column width with [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) can produce more lines. A wider column can reduce the space required vertically.
- **Cell margins:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) and [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) add vertical space. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) and [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) reduce the width available for text and can cause additional wrapping.

For this table without merged cells, the cell that needs the most vertical space determines the content-driven lower limit for the entire row. To make the row shorter, you may also need to shorten the text, reduce the font size or margins, or widen a column.

The images below show the same table at the same scale. In the illustrated results, the actual heights were 70, 100, and 55.2 points: the final row remained taller than its 20-point minimum. Exact text measurements can vary with the fonts available in your environment. Download the saved results: [increased minimum](row-height-increased.pptx) and [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Set the First Row as a Header**

Use the [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) method to mark the first row for header formatting. Its appearance depends on the table style applied to the table.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Access the first slide.
3. Access the table stored as the first shape on the slide.
4. Enable header formatting for its first row.
5. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide. It enables header formatting for the first row and saves `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Clone a Table Row or Column**

Clone rows or columns to reuse their content and formatting. You can append a copy to the end of the table or insert it at a specific position.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Access the first slide.
3. Define the column widths and row heights.
4. Add a table with the [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) method.
5. Clone the required rows.
6. Clone the required columns.
7. Save the modified presentation.

The example requires `Test.pptx` with at least one slide. It creates a table with three columns and five rows, with dimensions specified in points. It appends copies of the first row and column, then inserts copies of the second row and column at index 3 (the fourth position). The resulting table has seven rows and five columns. The `false` argument disables cloning into adjacent merged rows or columns; this table has no merged cells.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Remove a Row or Column from a Table**

Remove rows or columns that are no longer needed in a table. Removing an item shifts the indices of the rows or columns that follow it.

1. Create a presentation with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Access the first slide.
3. Define the column widths and row heights.
4. Add a table with the [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) method.
5. Remove the second row and second column.
6. Save the modified presentation.

This example creates a three-by-three table and removes the row and column at index 1, leaving a two-by-two table in `TestTable_out.pptx`. The dimensions are in points. The `false` argument disables removal of adjacent merged rows or columns; this table has no merged cells.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Set Text Formatting on the Table Row Level**

Apply text formatting to an entire row to keep its cells consistent. You can set font properties, paragraph formatting, and text direction without formatting each cell individually.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Access the table on the first slide.
3. Use [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) for the first row.
4. Use [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) and [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) for the first row.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) for the second row.
6. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide and at least two rows. It applies 25-point text, right alignment, and a 20-point right paragraph margin to the first row, then sets vertical text in the second row.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Set Text Formatting on the Table Column Level**

Apply text formatting to an entire column to keep its cells consistent. You can set font properties, paragraph formatting, and text direction without formatting each cell individually.

1. Load the presentation with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
2. Access the table on the first slide.
3. Use [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) for the first column.
4. Use [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) and [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) for the first column.
5. Use [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) for the second column.
6. Save the modified presentation.

The example requires `table.pptx` with a table as the first shape on the first slide and at least two columns. It applies 25-point text, right alignment, and a 20-point right paragraph margin to the first column, then sets vertical text in the second column.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Get Table Style Properties**

Use the [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) method to retrieve the preset applied to a table and reuse it on another table. This identifies the preset rather than individual cell formatting overrides.

The example creates a table, applies [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1), and reads the preset back. It prints the integer value corresponding to `DarkStyle1` and saves the table in `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that's already created?**

Yes. The table inherits the slide/layout/master theme, and you can still override fills, borders, and text colors on top of that theme.

**Can I sort table rows like in Excel?**

No, Aspose.Slides tables don't have built-in sorting or filters. Sort your data in memory first, then repopulate the table rows in that order.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

Yes. Turn on banded columns, then override specific cells with local formatting; cell-level formatting takes precedence over the table style.
