---
title: Filling Shapes with Pattern in PHP
type: docs
weight: 50
url: /java/filling-shapes-with-pattern-in-php/
---

## **Aspose.Slides - Filling Shapes with Pattern**
To Fill Shapes with Pattern using **Aspose.Slides Java for PHP**, call **fill_shapes_with_pattern** method of **FillingShapes** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function fill_shapes_with_pattern($dataDir=null)

{

    # Create an instance of Presentation class

    $pres = new Presentation();

    # Get the first slide

    $sld = $pres->getSlides()->get_Item(0);

    # Add autoshape of rectangle type

    $shapeType = new ShapeType();

    $shp = $sld->getShapes()->addAutoShape($shapeType->Rectangle, 50, 150, 75, 150);

    # Set the fill type to Pattern

    $fillType = new FillType();

    $shp->getFillFormat()->setFillType($fillType->Pattern);

    # Set the pattern style

    $patternStyle = new PatternStyle();

    $shp->getFillFormat()->getPatternFormat()->setPatternStyle($patternStyle->Trellis);

    # Set the pattern back and fore colors

    $color = new Color();

    $shp->getFillFormat()->getPatternFormat()->getBackColor()->setColor($color->LIGHT_GRAY);

    $shp->getFillFormat()->getPatternFormat()->getForeColor()->setColor($color->YELLOW);

    # Write the presentation as a PPTX file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "RectShpPatt.pptx", $save_format->Pptx);

    print "Filled shapes with Pattern, please check the output file." . PHP_EOL;

}

{{< /highlight >}}
## **Download Running Code**
Download **Filling Shapes with Pattern (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithShapes/FillingShapes.php)
