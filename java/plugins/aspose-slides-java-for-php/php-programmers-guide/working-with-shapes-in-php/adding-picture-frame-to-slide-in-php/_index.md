---
title: Adding Picture Frame to Slide in PHP
type: docs
weight: 30
url: /java/adding-picture-frame-to-slide-in-php/
---

## **Aspose.Slides - Adding Picture Frame to Slide**
To Add Picture Frame to Slide using **Aspose.Slides Java for PHP**, call **add_picture_frame** method of **Frame** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function add_picture_frame($dataDir=null)

{

    # Create an instance of Presentation class

    $pres = new Presentation();

    # Get the first slide

    $sId = $pres->getSlides()->get_Item(0);

    # Instantiate the Image class

    $imgx = $pres->getImages()->addImage(new FileInputStream(new File($dataDir . "aspose-logo.jpg")));

    # Add Picture Frame with height and width equivalent of Picture

    $shapeType = new ShapeType();

    $sId->getShapes()->addPictureFrame($shapeType->Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);

    # Write the presentation as a PPTX file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "RectPicFrame.pptx", $save_format->Pptx);

    print "Added picture frame to slide, please check the output file." . PHP_EOL;

}

{{< /highlight >}}
## **Download Running Code**
Download **Adding Picture Frame to Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithShapes/Frame.php)
