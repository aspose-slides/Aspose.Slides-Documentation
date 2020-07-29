---
title: Managing Font Related Properties in PHP
type: docs
weight: 50
url: /java/managing-font-related-properties-in-php/
---

## **Aspose.Slides - Managing Font Related Properties**
To Manage Font Related Properties using **Aspose.Slides Java for PHP**, call **font_properties** method of **TextFont** Class. Here you can see example code.

**PHPCode**

{{< highlight php >}}

     public static function font_properties($dataDir=null){

        # Create an instance of Presentation class

        $pres = new Presentation($dataDir . 'Welcome.pptx');

        # Get the first slide

        $slide = $pres->getSlides()->get_Item(0);

        # Accessing the first and second placeholder in the slide and typecasting it as AutoShape

        $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();

        $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();

        # Accessing the first Paragraph

        $para1 = $tf1->getParagraphs()->get_Item(0);

        $para2 = $tf2->getParagraphs()->get_Item(0);

        # Accessing the first portion

        $port1 = $para1->getPortions()->get_Item(0);

        $port2 = $para2->getPortions()->get_Item(0);

        # Define new fonts

        $fd1 = new FontData("Elephant");

        $fd2 = new FontData("Castellar");

        # Assign new fonts to portion

        $port1->getPortionFormat()->setLatinFont($fd1);

        $port2->getPortionFormat()->setLatinFont($fd2);

        # Set font to Bold

        $nullableBool=new NullableBool();

        $port1->getPortionFormat()->setFontBold($nullableBool->True);

        $port2->getPortionFormat()->setFontBold($nullableBool->True);

        # Set font to Italic

        $port1->getPortionFormat()->setFontItalic($nullableBool->True);

        $port2->getPortionFormat()->setFontItalic($nullableBool->True);

        # Set font color

        $fillType=new FillType();

        $color=new Color();

        $port1->getPortionFormat()->getFillFormat()->setFillType($fillType->Solid);

        $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->BLUE);

        $port2->getPortionFormat()->getFillFormat()->setFillType($fillType->Solid);

        $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($color->GREEN);

        # Write the presentation as a PPTX file

        $save_format = new SaveFormat();

        $pres->save($dataDir . "WelcomeFont.pptx", $save_format->Pptx);

        print "Done with font properties, please check the output file.".PHP_EOL;

    }

{{< /highlight >}}
## **Download Running Code**
Download **Managing Font Related Properties (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithText/TextFont.php)
