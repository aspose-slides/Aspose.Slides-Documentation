---
title: Rotating Shapes in PHP
type: docs
weight: 100
url: /java/rotating-shapes-in-php/
---

## **Aspose.Slides - Rotating Shapes**
To Rotate Shapes using **Aspose.Slides Java for PHP**, simply invoke **RotatingShapes** module. Here you can see example code.

**PHPCode**

```

 # Create an instance of Presentation class

$pres = new Presentation();

\# Get the first slide

$sld = $pres->getSlides()->get_Item(0);

\# Add autoshape of rectangle type

$shapeType = new ShapeType();

$shp = $sld->getShapes()->addAutoShape($shapeType->Rectangle, 50, 150, 75, 150);

\# Rotate the shape to 90 degree

$shp->setRotation(90);

\# Write the presentation as a PPTX file

$save_format = new SaveFormat();

$pres->save($dataDir . "RectShpRot.pptx", $save_format->Pptx);

print "Rotated shape, please check the output file." . PHP_EOL;

```
## **Download Running Code**
Download **Rotating Shapes (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithShapes/RotatingShapes.php)
