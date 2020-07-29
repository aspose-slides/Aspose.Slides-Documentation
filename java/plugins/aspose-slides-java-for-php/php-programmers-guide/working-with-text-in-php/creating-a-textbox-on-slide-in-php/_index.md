---
title: Creating a TextBox on Slide in PHP
type: docs
weight: 20
url: /java/creating-a-textbox-on-slide-in-php/
---

## **Aspose.Slides - Creating a TextBox on Slide**
To Create a TextBox on Slide using **Aspose.Slides Java for PHP**, call **create_textbox** method of **CreateTextBox** Class. Here you can see example code.

**PHPCode**

{{< highlight php >}}

     public static function create_textbox($dataDir=null){

        # Create an instance of Presentation class

        $pres = new Presentation();

        # Get the first slide

        $sld = $pres->getSlides()->get_Item(0);

        # Add autoshape of rectangle type

        $shapeType=new ShapeType();

        $shp = $sld->getShapes()->addAutoShape($shapeType->Rectangle, 150, 75, 150, 50);

        # Add TextFrame to the Rectangle

        $shp->addTextFrame(" ");

        # Accessing the text frame

        $txt_frame = $shp->getTextFrame();

        # Create the Paragraph object for text frame

        $para = $txt_frame->getParagraphs()->get_Item(0);

        # Create Portion object for paragraph

        $portion = $para->getPortions()->get_Item(0);

        # Set Text

        $portion->setText("Aspose TextBox");

        # Write the presentation as a PPTX file

        $save_format = new SaveFormat();

        $pres->save($dataDir . "TextBox.pptx", $save_format->Pptx);

        print "Created TextBox, please check the output file.".PHP_EOL;

    }

{{< /highlight >}}
## **Download Running Code**
Download **Creating a TextBox on Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithText/CreateTextBox.php)
