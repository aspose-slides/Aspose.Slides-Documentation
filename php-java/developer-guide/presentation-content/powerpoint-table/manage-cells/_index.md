---
title: Manage Cells
type: docs
weight: 30
url: /php-java/manage-cells/
keywords: "Table, merged cells, split cells, image in table cell, Java, Aspose.Slides for PHP via Java"
description: "Table cells in PowerPoint presentations "
---


## **Identify Merged Table Cell**
1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get the table from the first slide. 
3. Iterate through the table's rows and columns to find merge cells.
4. Print message when merged cells are found.

This PHP code shows you how to identify merged table cells in a presentation:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// assuming that Slide#0.Shape#0 is a table

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remove Table Cells Border**
1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Define an array of columns with width.
4. Define an array of rows with height.
5. Add a table to the slide through the [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
6. Iterate through every cell to clear the top, bottom, right, and left borders.
7. Save the modified presentation as a PPTX file.

This PHP code shows you how to remove the borders from table cells:

```php
  # Instantiates Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Adds table shape to slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Sets the border format for each cell
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Writes the PPTX to disk
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numbering in Merged Cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2), the resulting table will be numbered. This PHP code demonstrates the process:

```php
  # Instantiates Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Adds a table shape to the slide
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
    # Merges cells (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Merges cells (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

We then merge the cells further by merging (1, 1) and (1, 2). The result is a table containing a large merged cell in its center: 

```php
  # Instantiates Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Adds a table shape to the slide
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
    # Merges cells (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Merges cells (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Merges cells (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Writes the PPTX file to disk
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numbering in Splitted Cell**
In previous examples, when table cells got merged, the numeration or number system in other cells did not change. 

This time, we take a regular table (a table without merged cells) and then try to split cell (1,1) to get a special table. You may want to pay attention to this table's numbering, which may be considered strange. However, that is the way Microsoft PowerPoint numerates table cells and Aspose.Slides does the same thing. 

This PHP code demonstrates the process we described:

```php
  # Instantiates the Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Adds a table shape to the slide
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
    # Merges cells (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Merges cells (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Splits cell (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Writes the PPTX file to disk
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Change Table Cell Background Color**

This PHP code shows you how to change a table cell's background color:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # create a new table
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # set the background color for a cell
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Add Image Inside Table Cell**

1. Create an instance of the  [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Define an array of columns with width.
4. Define an array of rows with height.
5. Add a table to the slide through the [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
6. Create a `Images` object to hold the image file.
7. Add the `IImage` image to `IPPImage` Object.
8. Set the `FillFormat` for the Table Cell to `Picture`.
9. Add the image to the table's first cell.
10. Save the modified presentation as a PPTX file

This PHP code shows you how to place an image inside a table cell when creating a table:

```php
  # Instantiates the Presentation class that represents a PPTX file
  $pres = new Presentation();
  try {
    # Accesses the first slide
    $islide = $pres->getSlides()->get_Item(0);
    # Defines columns with widths and rows with heights
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Adds a table shape to the slide
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Create an IPPImage object using the image file
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Adds the image to the first table cell
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Saves the PPTX file to Disk
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
