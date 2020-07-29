---
title: Creating TextBox with Hyperlink in PHP
type: docs
weight: 30
url: /java/creating-textbox-with-hyperlink-in-php/
---

## **Aspose.Slides - Creating TextBox with Hyperlink**
To Create a TextBox with Hyperlink using **Aspose.Slides Java for PHP**, call **create_textbox_with_hyperlink** method of **CreateTextBox** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

     public static function create_textbox_with_hyperlink(){



        $pres = new Presentation();



        # Get the first slide

        $sld = $pres->getSlides()->get_Item(0);



        # Add autoshape of rectangle type

        $shapeType=new ShapeType();

        $pptxShape = $sld->getShapes()->addAutoShape($shapeType->Rectangle, 150, 150, 150, 50);



        # Cast the shape to AutoShape

        $pptxAutoShape = $pptxShape;



        # Access ITextFrame associated with the AutoShape

        $pptxAutoShape->addTextFrame("");



        $text_frame = $pptxAutoShape->getTextFrame();



        # Add some text to the frame

        $text_frame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");



        #Set Hyperlink for the portion text

        $hypman = $text_frame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();

        $hypman->setExternalHyperlinkClick("http://www.aspose.com");



        # Write the presentation as a PPTX file

        $save_format =new SaveFormat();

        $pres->save(data_dir + "hLinkPPTX.pptx", $save_format->Pptx);



        print "Created TextBox with Hyperlink, please check the output file.".PHP_EOL;



    }

{{< /highlight >}}
## **Download Running Code**
Download **Creating TextBox with Hyperlink (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithText/CreateTextBox.php)
