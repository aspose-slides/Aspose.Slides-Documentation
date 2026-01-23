---
title: Manage Presentation Tables in PHP
linktitle: Manage Table
type: docs
weight: 10
url: /php-java/manage-table/
keywords:
- add table
- create table
- access table
- aspect ratio
- align text
- text formatting
- table style
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Create & edit tables in PowerPoint slides with Aspose.Slides for PHP via Java. Discover simple code examples to streamline your table workflows."
---

A table in PowerPoint is an efficient way of displaying and portraying information. The information in a grid of cells (arranged in rows and columns) is straightforward and easy to understand.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) class, [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) class, and other types to allow you to create, update, and manage tables in all kinds of presentations.

## **Create a Table from Scratch**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) object to the slide through the [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) method.
6. Iterate through each [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row. 
8. Access an [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
9. Add some text to the [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. Save the modified presentation.

This PHP code shows you how to create a table in a presentation:

```php
  # Instantiates a Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Adds a table shape to slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Sets the border format for each cell
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Merges cells 1 & 2 of row 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Adds some text to the merged cell
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Saves the presentation to Disk
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numbering in a Standard Table**

In a standard table, the numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). 

For example, the cells in a table with 4 columns and 4 rows are numbered this way:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This PHP code shows you how to specify the numbering for cells in a table:

```php
  # Instantiates a Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Adds a table shape to slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Sets the border format for each cell
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Saves presentation to disk
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Access an Existing Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.

2. Get a reference to the slide containing the table through its index. 

3. Create an [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) object and set it to null.

4. Iterate through all [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) objects till the table is found.

   If you suspect the slide you are dealing with contains a single table, you can simply check all the shapes it contains. When a shape is identified as a table, you can typecast it as a [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) object. But if the slide you are dealing with contains several tables, then you are better off searching for the table you need through its [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/).

5. Use the [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) object to work with the table. In the example below, we added a new row to the table.

6. Save the modified presentation.

This PHP code shows you how to access and work with an existing table:

```php
  # Instantiates the Presentation class that represents a PPTX file
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Initializes null TableEx
    $tbl = null;
    # Iterates through the shapes and sets a reference to the table found
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Sets the text for the first column of the second row
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Saves the modified presentation to disk
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Align Text in a Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) object to the slide.
4. Access an [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) object from the table.
5. Access the [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
6. Align the text vertically.
7. Save the modified presentation.

This PHP code shows you how to align the text in a table:

```php
  # Creates an instance of the Presentation class
  $pres = new Presentation();
  try {
    # Gets the first slide
    $slide = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Adds the table shape to the slide
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Accesses the text frame
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Creates the Paragraph object for the text frame
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Creates the Portion object for paragraph
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Aligns the text vertically
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Saves the presentation to disk
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Text Formatting on the Table Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Access an [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) object from the Slide.
4. Set the [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) for the text.
5. Set the [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) and [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Set the [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Save the modified presentation. 

This PHP code shows you how to apply your preferred formatting options to the text in a table:

```php
  # Creates an instance of the Presentation class
  $pres = new Presentation("simpletable.pptx");
  try {
    # Let's assume that the first shape on the first slide is a table
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Sets the table cells' font height
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Sets the table cells' text alignment and right margin in one call
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Sets the table cells' text vertical type
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This PHP code shows you how to get the style properties from a table preset style:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// change the default style preset theme

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lock Aspect Ratio of a Table**

The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. Aspose.Slides provided the [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) method to allow you to lock the aspect ratio setting for tables and other shapes.

This PHP code shows you how to lock the aspect ratio for a table:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

Yes. The table exposes a [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) method, and paragraphs have [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Using both ensures the correct RTL order and rendering inside cells.

**How can I prevent users from moving or resizing a table in the final file?**

Use shape locks to disable moving, resizing, selection, etc. These locks apply to tables as well.

**Is inserting an image inside a cell as a background supported?**

Yes. You can set a [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) for a cell; the image will cover the cell area according to the chosen mode (stretch or tile).
