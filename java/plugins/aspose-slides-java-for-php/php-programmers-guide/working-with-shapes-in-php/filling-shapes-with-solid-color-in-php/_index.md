---
title: Filling Shapes with Solid Color in PHP
type: docs
weight: 70
url: /java/filling-shapes-with-solid-color-in-php/
---

## **Aspose.Slides - Filling Shapes with Solid Color**
To Fill Shapes with Solid Color using **Aspose.Slides Java for PHP**, call **fill_shapes_with_solid_color** method of **FillingShapes** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function fill_shapes_with_solid_color($dataDir=null)

{

    # Create an instance of Presentation class

    $pres = new Presentation();

    # Get the first slide

    $sld = $pres->getSlides()->get_Item(0);

    # Add autoshape of rectangle type

    $shapeType = new ShapeType();

    $shp = $sld->getShapes()->addAutoShape($shapeType->Rectangle, 50, 150, 75, 150);

    # Set the fill type to Solid

    $fillType = new FillType();

    $shp->getFillFormat()->setFillType($fillType->Solid);

    # Set the color of the rectangle

    $color = new Color();

    $shp->getFillFormat()->getSolidFillColor()->setColor($color->YELLOW);

    # Write the presentation as a PPTX file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "RectShpSolid.pptx", $save_format->Pptx);

    print "Filled shapes with Solid Color, please check the output file.";

}

{{< /highlight >}}
## **Download Running Code**
Download **Filling Shapes with Solid Color (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithShapes/FillingShapes.php)
