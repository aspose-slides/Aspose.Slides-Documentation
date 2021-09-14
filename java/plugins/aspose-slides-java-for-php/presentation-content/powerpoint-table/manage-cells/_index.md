---
title: Manage Cells
type: docs
weight: 30
url: /java/manage-cells/
---


## **Identify Merged Table Cell**
Aspose.Slides for Java has provided the simplest API to identify merge table cells in an easiest way. To identify merge cells in table, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the the table from first slide.
- Iterate through row and columns of table to find out merge cells.
- Print Message if cells are merged.

```php
$pres = new Java("com.aspose.slides.Presentation", "SomePresentationWithTable.pptx");
try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0); // assuming that Slide#0.Shape#0 is a table
    for ($i = 0; $i < $table->getRows()->size(); $i++)
    {
        for ($j = 0; $j < $table->getColumns()->size(); $j++)
        {
            $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
            if ($currentCell->isMergedCell())
            {
                echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Remove Table Cells Border**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. In order to remove the borders from table cells, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using [addTable](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
- Iterate through each Cell to clear the Top, Bottom, Right, Left Borders.
- Save the modified presentation as a PPTX file.

```php
// Instantiate Presentation class that represents PPTX file
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Access first slide
    $sld = $pres->getSlides()->get_Item(0);

    // Define columns with widths and rows with heights
    $Array = new JavaClass("java.lang.reflect.Array");
    $Double = new JavaClass("java.lang.Double");
    $dblCols = $Array->newInstance($Double, 4);
    $dblCols[0] = 50;
    $dblCols[1] = 50;
    $dblCols[2] = 50;
    $dblCols[3] = 50;
    $dblRows = $Array->newInstance($Double, 5);
    $dblRows[0] = 50;
    $dblRows[1] = 30;
    $dblRows[2] = 30;
    $dblRows[3] = 30;
    $dblRows[4] = 30;

    // Add table shape to slide

    // Add table shape to slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);

    // Set border format for each cell
    foreach( $tbl->getRows() as $row )
    {
        foreach( $row as $cell )
        {
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->NoFill);
        }
    }

    // Write PPTX to Disk
    $pres->save("table_out.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Numbering in Merged Cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2) then table will be numbered and look like this:

```php
// Instantiate Presentation class that represents PPTX file
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Access first slide
    $sld = $pres->getSlides()->get_Item(0);

    // Define columns with widths and rows with heights
        $Array = new JavaClass("java.lang.reflect.Array");
        $Double = new JavaClass("java.lang.Double");
        $dblCols = $Array->newInstance($Double, 4);
        $dblCols[0] = 70;
        $dblCols[1] = 70;
        $dblCols[2] = 70;
        $dblCols[3] = 70;
        $dblRows = $Array->newInstance($Double, 4);
        $dblRows[0] = 70;
        $dblRows[1] = 70;
        $dblRows[2] = 70;
        $dblRows[3] = 70;

    // Add table shape to slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);

    // Set border format for each cell
    foreach( $tbl->getRows() as $row )
    {
        foreach( $row as $cell )
        {
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderTop()->setWidth(5);

            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderBottom()->setWidth(5);

            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderLeft()->setWidth(5);

            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderRight()->setWidth(5);
        }
    }

    // Merging cells (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);

    // Merging cells (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);

    $pres->save("MergeCells_out.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

Let's continue merging cells. Now we merge (1, 1) and (1, 2). As a result we have table with large merged cell in the middle:

```php
// Instantiate Presentation class that represents PPTX file
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Access first slide
    $sld = $pres->getSlides()->get_Item(0);

    // Define columns with widths and rows with heights
    $Array = new JavaClass("java.lang.reflect.Array");
    $Double = new JavaClass("java.lang.Double");
    $dblCols = $Array->newInstance($Double, 4);
    $dblCols[0] = 70;
    $dblCols[1] = 70;
    $dblCols[2] = 70;
    $dblCols[3] = 70;
    $dblRows = $Array->newInstance($Double, 4);
    $dblRows[0] = 70;
    $dblRows[1] = 70;
    $dblRows[2] = 70;
    $dblRows[3] = 70;    
    // Add table shape to slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);

    // Set border format for each cell
    foreach( $tbl->getRows() as $row )
    {
        foreach( $row as $cell )
        {
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderTop()->setWidth(5);

            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderBottom()->setWidth(5);

            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderLeft()->setWidth(5);

            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderRight()->setWidth(5);
        }
    }

    // Merging cells (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);

    // Merging cells (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);

    // Merging cells (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);

    $pres->save("MergeCells_out.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Numbering in Splitted Cell**
We could see in previous example when table cells are merged then numeration of other cells is not changed.Now let's return to our normal table (without merged cells) and try to split cell (1, 1). The result is strange enough but that is the way MS PowerPoint and Aspose.Slides for Java numerate table cells.

```php
// Instantiate Presentation class that represents PPTX file
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Access first slide
    $sld = $pres->getSlides()->get_Item(0);

    // Define columns with widths and rows with heights
        $Array = new JavaClass("java.lang.reflect.Array");
        $Double = new JavaClass("java.lang.Double");
        $dblCols = $Array->newInstance($Double, 4);
        $dblCols[0] = 70;
        $dblCols[1] = 70;
        $dblCols[2] = 70;
        $dblCols[3] = 70;
        $dblRows = $Array->newInstance($Double, 4);
        $dblRows[0] = 70;
        $dblRows[1] = 70;
        $dblRows[2] = 70;
        $dblRows[3] = 70;

    // Add table shape to slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);

    // Set border format for each cell
    foreach( $tbl->getRows() as $row )
    {
        foreach( $row as $cell )
        {
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderTop()->setWidth(5);

            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderBottom()->setWidth(5);

            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderLeft()->setWidth(5);

            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->RED);
            $cell->getCellFormat()->getBorderRight()->setWidth(5);
        }
    }

    // Merging cells (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);

    // Merging cells (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);

    // Spliting cell (1, 1)
    $tbl->get_Item(1, 1).splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);

    $pres->save("SplitCells_out.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Add Image Inside Table Cell**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. To add image in a table cell while creating a new table, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using [addTable](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
- Create a BufferedImage object to hold the image file.
- Add the BufferedImage image to IPPImage Object.
- Set Fill Format of the Table Cell as Picture.
- Add the image to the first cell of the table.
- Save the modified presentation as a PPTX file

```php
// Instantiate Presentation class object
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Access first slide
    $islide = $pres->getSlides()->get_Item(0);

    // Define columns with widths and rows with heights
    $Array = new JavaClass("java.lang.reflect.Array");
    $Double = new JavaClass("java.lang.Double");
    $dblCols = $Array->newInstance($Double, 4);
    $dblCols[0] = 150;
    $dblCols[1] = 150;
    $dblCols[2] = 150;
    $dblCols[3] = 150;
    $dblRows = $Array->newInstance($Double, 5);
    $dblRows[0] = 100;
    $dblRows[1] = 100;
    $dblRows[2] = 100;
    $dblRows[3] = 100;
    $dblRows[4] = 90;
    // Add table shape to slide
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);

    // Creating a Bitmap Image object to hold the image file
    $image = Java("java.io.ImageIO")->read(new Java("java.io.File", "image.jpg"));

    // Create an IPPImage object using the bitmap object
    $imgx1 = $pres->getImages()->addImage($image);

    // Add image to first table cell
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Picture);
    $cellFormat->getFillFormat()->getPictureFillFormat()->setPictureFillMode(Java("com.aspose.slides.PictureFillMode")->Stretch);
    $cellFormat->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx1);

    // Save PPTX to Disk
    $pres->save("Image_In_TableCell_out.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} catch (JavaException $e) {
} finally {
    if ($pres != null) $pres->dispose();
}
```