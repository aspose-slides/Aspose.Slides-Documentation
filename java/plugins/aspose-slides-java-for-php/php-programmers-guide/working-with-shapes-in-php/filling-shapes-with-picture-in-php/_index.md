---
title: Filling Shapes with Picture in PHP
type: docs
weight: 60
url: /java/filling-shapes-with-picture-in-php/
---

## **Aspose.Slides - Filling Shapes with Picture**
To Fill Shapes with Picture using **Aspose.Slides Java for PHP**, call **fill_shapes_with_picture** method of **FillingShapes** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function fill_shapes_with_picture($dataDir=null)

{

    # Create an instance of Presentation class

    $pres = new Presentation();

    # Get the first slide

    $sld = $pres->getSlides()->get_Item(0);

    # Add autoshape of rectangle type

    $shapeType = new ShapeType();

    $shp = $sld->getShapes()->addAutoShape($shapeType->Rectangle, 50, 150, 75, 150);

    # Set the fill type to Picture

    $fillType = new FillType();

    $shp->getFillFormat()->setFillType($fillType->Picture);

    # Set the picture fill mode

    $pictureFillMode = new PictureFillMode();

    $shp->getFillFormat()->getPictureFillFormat()->setPictureFillMode($pictureFillMode->Tile);

    # Set the picture

    $imgx = $pres->getImages()->addImage(new FileInputStream(new File($dataDir . "night.jpg")));

    $shp->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);

    # Write the presentation as a PPTX file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "RectShpPic.pptx", $save_format->Pptx);

    print "Filled shapes with Picture, please check the output file." . PHP_EOL;

}

{{< /highlight >}}
## **Download Running Code**
Download **Filling Shapes with Picture (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithShapes/FillingShapes.php)
