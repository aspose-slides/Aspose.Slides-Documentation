---
title: Managing Text Autofit and Rotation in PHP
type: docs
weight: 60
url: /java/managing-text-autofit-and-rotation-in-php/
---

## **Aspose.Slides - Setting the AutofitType property of text frame**
To Set the AutofitType property of text frame using **Aspose.Slides Java for PHP**, call **set_autofittype_of_text** method of **ManageText** Class. Here you can see example code.

**PHPCode**

```

 public static function set_autofittype_of_text($dataDir=null){

\# Create an instance of Presentation class

$pres = new Presentation();

\# Get the first slide

$slide = $pres->getSlides()->get_Item(0);

\# Add an AutoShape of Rectangle type

$shapeType=new ShapeType();

$ashp = $slide->getShapes()->addAutoShape($shapeType->Rectangle, 150, 75, 350, 350);

\# Add TextFrame to the Rectangle

$fillType=new FillType();

$ashp->addTextFrame(" ");

$ashp->getFillFormat()->setFillType($fillType->NoFill);

\# Accessing the text frame

$txt_frame = $ashp->getTextFrame();

\# Setting text autofit type

$textAutofitType=new TextAutofitType();

$txt_frame->getTextFrameFormat()->setAutofitType($textAutofitType->Shape);

\# Create the Paragraph object for text frame

$para = $txt_frame->getParagraphs()->get_Item(0);

\# Create Portion object for paragraph

$color=new Color();

$portion = $para->getPortions()->get_Item(0);

$portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");

$portion->getPortionFormat()->getFillFormat()->setFillType($fillType->Solid);

$portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->BLACK);

\# Write the presentation as a PPTX file

$save_format = new SaveFormat();

$pres->save($dataDir . "formatText.pptx", $save_format->Pptx);

print "Set autofittype of text, please check the output file.".PHP_EOL;

}

```
## **Aspose.Slides - Setting the anchor of TextFrame**
To Set the anchor of TextFrame using **Aspose.Slides Java for PHP**, call **set_anchor_of_text** method of **ManageText** module. Here you can see example code.

**PHPCode**

```

 public static function set_anchor_of_text($dataDir=null){

\# Create an instance of Presentation class

$pres = new Presentation();

\# Get the first slide

$slide = $pres->getSlides()->get_Item(0);

\# Add an AutoShape of Rectangle type

$shapeType=new ShapeType();

$ashp = $slide->getShapes()->addAutoShape($shapeType->Rectangle, 150, 75, 350, 350);

\# Add TextFrame to the Rectangle

$fillType=new FillType();

$ashp->addTextFrame(" ");

$ashp->getFillFormat()->setFillType($fillType->NoFill);

\# Accessing the text frame

$txt_frame = $ashp->getTextFrame();

\# Setting text anchoring to bottom

$textAnchorType=new TextAnchorType();

$txt_frame->getTextFrameFormat()->setAnchoringType($textAnchorType->Bottom);

\# Create the Paragraph object for text frame

$para = $txt_frame->getParagraphs()->get_Item(0);

\# Create Portion object for paragraph

$color=new Color();

$portion = $para->getPortions()->get_Item(0);

$portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");

$portion->getPortionFormat()->getFillFormat()->setFillType($fillType->Solid);

$portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->BLACK);

\# Write the presentation as a PPTX file

$save_format = new SaveFormat();

$pres->save($dataDir . "AnchorText.pptx", $save_format->Pptx);

print "Set anchor of text, please check the output file.".PHP_EOL;

}

```
## **Aspose.Slides - Rotating the text**
To Rotate the text using **Aspose.Slides Java for PHP**, call **rotate_text** method of **ManageText** module. Here you can see example code.

**PHPCode**

```

 public static function rotate_text($dataDir=null){

        # Create an instance of Presentation class

        $pres = new Presentation();

        # Get the first slide

        $slide = $pres->getSlides()->get_Item(0);

        # Add an AutoShape of Rectangle type

        $shapeType=new ShapeType();

        $ashp = $slide->getShapes()->addAutoShape($shapeType->Rectangle, 150, 75, 350, 350);

        # Add TextFrame to the Rectangle

        $fillType=new FillType();

        $ashp->addTextFrame(" ");

        $ashp->getFillFormat()->setFillType($fillType->NoFill);

        # Accessing the text frame

        $txt_frame = $ashp->getTextFrame();

        # Setting text Vertical type

        $textVerticalType=new TextVerticalType();

        $txt_frame->getTextFrameFormat()->setTextVerticalType($textVerticalType->Vertical270);

        # Create the Paragraph object for text frame

        $para = $txt_frame->getParagraphs()->get_Item(0);

        # Create Portion object for paragraph

        $portion = $para->getPortions()->get_Item(0);

        $color=new Color();

        $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");

        $portion->getPortionFormat()->getFillFormat()->setFillType($fillType->Solid);

        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->BLACK);

        # Write the presentation as a PPTX file

        $save_format = new SaveFormat();

        $pres->save($dataDir . "VerticleText.pptx", $save_format->Pptx);

        print "Done with text rotation, please check the output file.".PHP_EOL;

    }

```
## **Download Running Code**
Download **Managing Text Autofit and Rotation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithText/ManageText.php)
