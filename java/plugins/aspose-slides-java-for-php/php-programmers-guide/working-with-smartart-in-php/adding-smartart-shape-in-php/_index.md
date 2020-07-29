---
title: Adding SmartArt shape in PHP
type: docs
weight: 10
url: /java/adding-smartart-shape-in-php/
---

## **Aspose.Slides - Adding SmartArt shape**
To Add SmartArt shape using **Aspose.Slides Java for PHP**, call **create_smartart_shape** method of **AddSmartArt** Class. Here you can see example code.

**PHPCode**

{{< highlight php >}}

     public static function create_smartart_shape($dataDir=null){

        # Create an instance of Presentation class

        $pres = new Presentation();

        # Get the first slide

        $slide = $pres->getSlides()->get_Item(0);

        # Add Smart Art Shape

        $smartArtLayoutType=new SmartArtLayoutType();

        $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, $smartArtLayoutType->BasicBlockList);

        # Write the presentation as a PPTX file

        $saveFormat=new SaveFormat();

        $pres->save($dataDir . "SimpleSmartArt.pptx", $saveFormat->Pptx);

        print "Created smartart shape, please check the output file.".PHP_EOL;

    }

{{< /highlight >}}
## **Download Running Code**
Download **Adding SmartArt shape (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSmartArt/AddSmartArt.php)
