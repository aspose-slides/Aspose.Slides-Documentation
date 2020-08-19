---
title: Adding Line Shape to Slide in PHP
type: docs
weight: 20
url: /java/adding-line-shape-to-slide-in-php/
---

## **Aspose.Slides - Adding Plain Line to Slide**
To Add Plain Line to Slide using **Aspose.Slides Java for PHP**, call **add_plain_line** method of **AddingLineShape** module. Here you can see example code.

**PHPCode**

```

 public static function add_plain_line($dataDir=null)

{

    # Create an instance of Presentation class

    $pres = new Presentation();

    # Get the first slide

    $sld = $pres->getSlides()->get_Item(0);

    # Add an autoshape of type line

    $shapeType = new ShapeType();

    $sld->getShapes()->addAutoShape($shapeType->Line, 50, 150, 300, 0);

    # Write the presentation as a PPTX file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "LineShape.pptx", $save_format->Pptx);

    print "Added plain line to slide, please check the output file." . PHP_EOL;

}

```
## **Aspose.Slides - Adding Arrow Shaped Line to Slide**
To Add Arrow Shaped Line to Slide using **Aspose.Slides Java for PHP**, call **add_arrow_line** method of **AddingLineShape** module. Here you can see example code.

**PHPCode**

```

 public static function add_arrow_line($dataDir=null)

{

    # Create an instance of Presentation class

    $pres = new Presentation();

    # Get the first slide

    $sld = $pres->getSlides()->get_Item(0);

    # Add an autoshape of type line

    $shapeType = new ShapeType();

    $shp = $sld->getShapes()->addAutoShape($shapeType->Line, 50, 150, 300, 0);

    # Apply some formatting on the line

    $lineStyle = new LineStyle();

    $shp->getLineFormat()->setStyle($lineStyle->ThickBetweenThin);

    $shp->getLineFormat()->setWidth(10);

    $lineDashStyle = new LineDashStyle();

    $shp->getLineFormat()->setDashStyle($lineDashStyle->DashDot);

    $lineArrowheadLength = new LineArrowheadLength();

    $lineArrowheadStyle = new LineArrowheadStyle();

    $fillType = new FillType();

    $color = new Color();

    $presetColor = new PresetColor();

    $shp->getLineFormat()->setBeginArrowheadLength($lineArrowheadLength->Short);

    $shp->getLineFormat()->setBeginArrowheadStyle($lineArrowheadStyle->Oval);

    $shp->getLineFormat()->setEndArrowheadLength($lineArrowheadLength->Long);

    $shp->getLineFormat()->setEndArrowheadStyle($lineArrowheadStyle->Triangle);

    $shp->getLineFormat()->getFillFormat()->setFillType($fillType->Solid);

    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color($presetColor->Maroon));


    # Write the presentation as a PPTX file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "ArrowShape.pptx", $save_format->Pptx);

    print "Added arrow shape line to slide, please check the output file." . PHP_EOL;

}

```
## **Download Running Code**
Download **Adding Line Shape to Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithShapes/AddingLineShape.php)
