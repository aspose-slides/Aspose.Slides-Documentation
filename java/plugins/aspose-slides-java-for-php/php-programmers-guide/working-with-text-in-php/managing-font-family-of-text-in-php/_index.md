---
title: Managing Font Family of Text in PHP
type: docs
weight: 40
url: /java/managing-font-family-of-text-in-php/
---

## **Aspose.Slides - Managing Font Family of Text**
To Manage Font Family of Text using **Aspose.Slides Java for PHP**, call **font_family_of_text** method of **TextFont** module. Here you can see example code.

**PHPCode**

```

     public static function font_family_of_text($dataDir=null){


        # Create an instance of Presentation class

        $pres = new Presentation();

        # Get the first slide

        $sld = $pres->getSlides()->get_Item(0);

        # Add an AutoShape of Rectangle type

        $shapeType=new ShapeType();

        $ashp = $sld->getShapes()->addAutoShape($shapeType->Rectangle, 50, 50, 200, 50);

        # Remove any fill style associated with the AutoShape

        $fillType=new FillType();

        $ashp->getFillFormat()->setFillType($fillType->NoFill);

        # Access the TextFrame associated with the AutoShape

        $tf = $ashp->getTextFrame();

        $tf->setText("Aspose TextBox");

        # Access the Portion associated with the TextFrame

        $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

        # Set the Font for the Portion

        $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));

        # Set Bold property of the Font

        $nullableBool=new NullableBool();

        $port->getPortionFormat()->setFontBold($nullableBool->True);

        # Set Italic property of the Font

        $port->getPortionFormat()->setFontItalic($nullableBool->True);

        # Set Underline property of the Font

        $textUnderlineType=new TextUnderlineType();

        $port->getPortionFormat()->setFontUnderline($textUnderlineType->Single);

        # Set the Height of the Font

        $port->getPortionFormat()->setFontHeight(25);

        # Set the color of the Font

        $color=new Color();

        $port->getPortionFormat()->getFillFormat()->setFillType($fillType->Solid);

        $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->BLUE);

        # Write the presentation as a PPTX file

        $save_format = new SaveFormat();

        $pres->save($dataDir . "FontFamilyOfText.pptx", $save_format->Pptx);

        print "Done with font family for text, please check the output file.".PHP_EOL;

    }

```
## **Download Running Code**
Download **Managing Font Family of Text (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithText/TextFont.php)
