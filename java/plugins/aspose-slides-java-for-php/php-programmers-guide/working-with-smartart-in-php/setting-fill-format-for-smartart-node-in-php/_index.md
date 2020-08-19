---
title: Setting Fill Format for SmartArt Node in PHP
type: docs
weight: 20
url: /java/setting-fill-format-for-smartart-node-in-php/
---

## **Aspose.Slides - Setting Fill Format for SmartArt Node**
To Set Fill Format for SmartArt Node using **Aspose.Slides Java for PHP**, simply invoke **FillFormat** Class. Here you can see example code.

**PHPCode**

```

 # Create an instance of Presentation class

$pres = new Presentation();

\# Get the first slide

$slide = $pres->getSlides()->get_Item(0);

\# Adding SmartArt shape and nodes

$smartArtLayoutType=new SmartArtLayoutType();

$chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, $smartArtLayoutType->ClosedChevronProcess);

$node = $chevron->getAllNodes()->addNode();

$node->getTextFrame()->setText("Some text");

\# Setting node fill color

$color=new Color();

$fillType=new FillType();

$item = $node->getShapes()->get_Item(0);

$item->getFillFormat()->setFillType($fillType->Solid);

$item->getFillFormat()->getSolidFillColor()->setColor($color->RED);

\# Write the presentation as a PPTX file

$saveFormat=new SaveFormat();

$pres->save($dataDir . "FillFormat.pptx", $saveFormat->Pptx);

print "Set fill format for smartart node, please check the output file.".PHP_EOL;

```
## **Download Running Code**
Download **Setting Fill Format for SmartArt Node (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSmartArt/FillFormat.php)
