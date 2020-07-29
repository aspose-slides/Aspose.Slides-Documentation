---
title: Replacing Text in a Placeholder in PHP
type: docs
weight: 80
url: /java/replacing-text-in-a-placeholder-in-php/
---

## **Aspose.Slides - Replacing Text in a Placeholder**
To Replace Text in a Placeholder using **Aspose.Slides Java for PHP**, simply invoke **ReplaceText** Class. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 # Create an instance of Presentation class

$pres = new Presentation($dataDir . 'Welcome.pptx');

\# Get the first slide

$sld = $pres->getSlides()->get_Item(0);

\# Change the text of each placeholder

$shp = $sld->getShapes()->get_Item(0);

$shp->getTextFrame()->setText("This is Placeholder");

\# Write the presentation as a PPTX file

$save_format = new SaveFormat();

$pres->save($dataDir . "Welcome_PH.pptx", $save_format->Pptx);

print "Replaced text, please check the output file.".PHP_EOL;

{{< /highlight >}}
## **Download Running Code**
Download **Replacing Text in a Placeholder (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithText/ReplaceText.php)
