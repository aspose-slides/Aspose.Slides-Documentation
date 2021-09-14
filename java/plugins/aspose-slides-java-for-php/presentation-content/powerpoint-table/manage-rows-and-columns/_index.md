---
title: Manage Rows and Columns
type: docs
weight: 20
url: /java/manage-rows-and-columns/
---

## **Set First Row as Header**
Aspose.Slides for Java provides the feature to set the first row as header using the following methods of [ITable](https://apireference.aspose.com/slides/java/com.aspose.slides/ITable) interface. Below code example shows how to set the first row as a header.

```php
// Instantiate Presentation class that represents PPTX
$pres = new Java("com.aspose.slides.Presentation", "table.pptx");
try {
    // Access the first slide
    $sld = $pres->getSlides()->get_Item(0);

    // Initialize null TableEx
    $tbl = null;

    // Iterate through the shapes and set a reference to the table found
    foreach( $sld->getShapes() as $shp )
    {
        if ($shp instanceof ITable) 
        {
            $tbl = $shp;
            
            //Set the first row of a table as header with a special formatting.
            $tbl->setFirstRow(true);
        }
    }
    
    // Save PPTX to Disk
    $pres->save("pres.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Clone Row or Column of Table**
Aspose.Slides for Java has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using [addTable](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
- Clone table row.
- Clone table column.
- Save the presentation as a PPTX file.

```php
// Instantiate presentation class
$pres = new Java("com.aspose.slides.Presentation", "Test.pptx");
try {
    // Access first slide
    $sld = $pres->getSlides()->get_Item(0);

    // Define columns with widths and rows with heights
    $Array = new JavaClass("java.lang.reflect.Array");
    $Double = new JavaClass("java.lang.Double");
    $dblCols = $Array->newInstance($Double, 3);
    $dblCols[0] = 50;
    $dblCols[1] = 50;
    $dblCols[2] = 50;
    $dblRows = $Array->newInstance($Double, 5);
    $dblRows[0] = 50;
    $dblRows[1] = 30;
    $dblRows[2] = 30;
    $dblRows[3] = 30;
    $dblRows[4] = 30;
    // Add table shape to slide
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);

    // Add text to the row 1 cell 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");

    // Add text to the row 1 cell 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");

    // Clone Row 1 at end of table
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    // Add text to the row 2 cell 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");

    // Add text to the row 2 cell 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");

    // Clone Row 2 as 4th row of table
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    //Cloning first column at end
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);

    //Cloning 2nd column at 4th column index
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    
    // Write PPTX to Disk
    $pres->save("table_out.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Remove Row or Column from Table**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using [addTable](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.
- Remove table row.
- Remove table column.
- Write the modified presentation as a PPTX file.

```php
$pres = new Java("com.aspose.slides.Presentation");
try {
    $slide = $pres->getSlides()->get_Item(0);
    
    $Array = new JavaClass("java.lang.reflect.Array");
    $Double = new JavaClass("java.lang.Double");
    $dblCols = $Array->newInstance($Double, 3);
    $dblCols[0] = 100;
    $dblCols[1] = 50;
    $dblCols[2] = 30;
    $dblRows = $Array->newInstance($Double, 3);
    $dblRows[0] = 30;
    $dblRows[1] = 50;
    $dblRows[2] = 30;
    $table = $slide->getShapes()->addTable(100, 100, colWidth, rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    
    $pres->save("TestTable_out.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Set Text Formatting on Table Row Level**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on row level, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first row Cells Font Height.
- Set first row Cells Text Alignment and right Margin in one Call.
- Set second row Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

```php
// Create an instance of Presentation class
$pres = new Java("com.aspose.slides.Presentation");
try {
    // the first shape on the first slide is a table
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0); 
    
    // setting first row cells' font height
    $portionFormat = new Java("com.aspose.slides.PortionFormat");
    $portionFormat->setFontHeight(25);
	
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    
    // setting first row cells' text alignment and right margin in one call
    $paragraphFormat = new Java("com.aspose.slides.ParagraphFormat");
    $paragraphFormat->setAlignment(Java("com.aspose.slides.TextAlignment")->Right);
    $paragraphFormat->setMarginRight(20);
	
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    
    // setting second row cells' text vertical type
    $textFrameFormat = new Java("com.aspose.slides.TextFrameFormat");
    $textFrameFormat->setTextVerticalType(Java("com.aspose.slides.TextVerticalType")->Vertical);
	
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $pres->save("result.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Set Text Formatting on Table Column Level**
Aspose.Slides for Java has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on Column level, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first Column Cells Font Height.
- Set first Column Cells Text Alignment and right Margin in one Call.
- Set second Column Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

```php
// Create an instance of Presentation class
$pres = new Java("com.aspose.slides.Presentation");
try {
    // the first shape on the first slide is a table
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)];

    // setting first column cells' font height
    $portionFormat = new Java("com.aspose.slides.PortionFormat");
    $portionFormat->setFontHeight(25);
	
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    // setting first column cells' text alignment and right margin in one call
    $paragraphFormat = new Java("com.aspose.slides.ParagraphFormat");
    $paragraphFormat->setAlignment(Java("com.aspose.slides.TextAlignment")->Right);
    $paragraphFormat->setMarginRight(20);
	
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    // setting second column cells' text vertical type
    $textFrameFormat = new Java("com.aspose.slides.TextFrameFormat");
    $textFrameFormat->setTextVerticalType(Java("com.aspose.slides.TextVerticalType")->Vertical);
	
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $pres->save("result.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```