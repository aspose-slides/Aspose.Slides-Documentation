---
title: Manage Rows and Columns
type: docs
weight: 20
url: /php-java/manage-rows-and-columns/
keywords: "Table, table rows and columns, PowerPoint presentation, Java, Aspose.Slides for PHP via Java"
description: "Manage table rows and columns in PowerPoint presentations "
---

To allow you to manage a table's rows and columns in a PowerPoint presentation, Aspose.Slides provides the [Table](https://reference.aspose.com/slides/php-java/com.aspose.slides/table/) class, [ITable](https://reference.aspose.com/slides/php-java/com.aspose.slides/ITable) interface, and many other types.

## **Set First Row as Header**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) class and load the presentation.
2. Get a slide's reference through its index. 
3. Create an [ITable](https://reference.aspose.com/slides/php-java/com.aspose.slides/ITable) object and set it to null.
4. Iterate through all [IShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/ishape/) objects to find the relevant table.
5. Set the table's first row as its header. 

This Java code shows you how to set a table's first row as its header:

```php
  // Instantiates the Presentation class
  $pres = new Presentation("table.pptx");
  try {
    // Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    // Initializes the null TableEx
    $tbl = null;
    // Iterates through the shapes and sets a reference to the table
    foreach ($sld->getShapes() as $shp) {
      if ($shp instanceof ITable) {
        $tbl = $shp;
        // Sets the first row of a table as its header
        $tbl->setFirstRow(true);
      }
    }
    // Saves the presentation to disk
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```


## **Clone Table's Row or Column**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) class and load the presentation,
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/php-java/com.aspose.slides/ITable) object to the slide through the [addTable](https://reference.aspose.com/slides/php-java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) method.
6. Clone the table row.
7. Clone the table column.
8. Save the modified presentation.

This Java code shows you how to clone a PowerPoint table's row or column:

```php
  // Instantiates the Presentation class
  $pres = new Presentation("Test.pptx");
  try {
    // Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    // Defines columns with widths and rows with heights
    $dblCols = new double[]{ 50, 50, 50 };
    $dblRows = new double[]{ 50, 30, 30, 30, 30 };
    // Adds a table shape to slide
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    // Adds some text to the row 1 cell 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    // Adds some text to the row 1 cell 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    // Clones Row 1 at end of table
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    // Adds some text to the row 2 cell 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    // Adds some text to the row 2 cell 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    // Clones Row 2 as 4th row of table
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    // Clones first column at the end
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    // Clones 2nd column at 4th column index
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    // Saves the presentation to disk
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Remove Row or Column from Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) class and load the presentation,
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/php-java/com.aspose.slides/ITable) object to the slide through the [addTable](https://reference.aspose.com/slides/php-java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) method.
6. Remove the table row.
7. Remove the table column.
8. Save the modified presentation. 

This Java code shows you how to remove a row or column from a table:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = new double[]{ 100, 50, 30 };
    $rowHeight = new double[]{ 30, 50, 30 };
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Set Text Formatting on Table Row Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) class and load the presentation,
2. Get a slide's reference through its index. 
3. Access the relevant [ITable](https://reference.aspose.com/slides/php-java/com.aspose.slides/ITable) object from the slide.
4. Set the first-row cells' [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Set the first-row cells' [setAlignment(int value)](https://reference.aspose.com/slides/php-java/com.aspose.slides/iparagraphformat/#setAlignment-int-) and [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Set the second-row cells' [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Save the modified presentation.

This Java code demonstrates the operation.

```php
  // Creates an instance of the Presentation class
  $pres = new Presentation();
  try {
    // Let's assume that the first shape on the first slide is a table
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    // Sets first row cells' font height
    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    // Sets the first row cells' text alignment and right margin
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    // Sets the second row cells' text vertical type
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    // Saves the presentation to disk
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Set Text Formatting on Table Column Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) class and load the presentation,
2. Get a slide's reference through its index. 
3. Access the relevant [ITable](https://reference.aspose.com/slides/php-java/com.aspose.slides/ITable) object from the slide.
4. Set the first-column cells' [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Set the first-column cells' [setAlignment(int value)](https://reference.aspose.com/slides/php-java/com.aspose.slides/iparagraphformat/#setAlignment-int-) and [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Set the second-column cells' [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Save the modified presentation. 

This Java code demonstrates the operation: 

```php
  // Creates an instance of the Presentation class
  $pres = new Presentation();
  try {
    // Let's assume that the first shape on the first slide is a table
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    // Sets the first column cells' font height
    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    // Sets the first column cells' text alignment and right margin in one call
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    // Sets the second column cells' text vertical type
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This Java code shows you how to get the style properties from a table preset style:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, new double[]{ 100, 150 }, new double[]{ 5, 5, 5 });
    $table->setStylePreset(TableStylePreset::DarkStyle1);// change the default style preset theme

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

