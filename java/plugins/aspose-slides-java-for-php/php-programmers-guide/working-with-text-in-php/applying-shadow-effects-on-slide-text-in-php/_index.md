---
title: Applying Shadow Effects on Slide Text in PHP
type: docs
weight: 10
url: /java/applying-shadow-effects-on-slide-text-in-php/
---

## **Aspose.Slides - Applying Shadow Effects on Slide Text**
To Apply Shadow Effects on Slide Text using **Aspose.Slides Java for PHP**, simply invoke **ShadowEffects** module. Here you can see example code.

**PHPCode**

```

 # Create an instance of Presentation class

$pres = new Presentation();

\# Get the first slide

$slide = $pres->getSlides()->get_Item(0);

\# Add an AutoShape of Rectangle type

$shapeType=new ShapeType();

$shp = $slide->getShapes()->addAutoShape($shapeType->Rectangle, 150, 75, 150, 50);

\# Add TextFrame to the Rectangle

$shp->addTextFrame("Aspose TextBox");

\# Disable shape fill in case we want to get shadow of text

$fillType=new FillType();

$shp->getFillFormat()->setFillType($fillType->NoFill);

\# Add outer shadow and set all necessary parameters

$shp->getEffectFormat()->enableOuterShadowEffect();

$shadow = $shp->getEffectFormat()->getOuterShadowEffect();

$shadow->setBlurRadius(4.0);

$shadow->setDirection(45);

$shadow->setDistance(3);

$rectangleAlignment=new RectangleAlignment();

$color=new Color();

$shadow->setRectangleAlign($rectangleAlignment->TopLeft);

$shadow->getShadowColor()->setColor($color->black);

\# Write the presentation as a PPTX file

$save_format = new SaveFormat();

$pres->save($dataDir . "OutShadow.pptx", $save_format->Pptx);

print "Applied shadow effects on text, please check the output file.".PHP_EOL;

```
## **Download Running Code**
Download **Applying Shadow Effects on Slide Text (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithText/ShadowEffects.php)
