---
title: Setting Default Zoom Value for Presentation in PHP
type: docs
weight: 110
url: /java/setting-default-zoom-value-for-presentation-in-php/
---

## **Aspose.Slides - Setting Default Zoom Value**
To set default Zoom value for presentation using **Aspose.Slides Java for PHP**, simply invoke **Zoom** module. Here you can see example code.

**PHP Code**

{{< highlight php >}}

 # Create an instance of Presentation class

$pres = new Presentation();

\# Setting View Properties of Presentation

#pres.getViewProperties().getSlideViewProperties().setScale(50) # zoom value in percentages for slide view

$pres->getViewProperties()->getNotesViewProperties()->setScale(50); # .Scale = 50; //zoom value in percentages for notes view

\# Save the presentation as a PPTX file

$save_format = new SaveFormat();

$pres->save($dataDir . "Zoom.pptx", $save_format->Pptx);

print "Set zoom value, please check the output file.";

{{< /highlight >}}
## **Download Running Code**
Download **Setting Default Zoom Value (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithPresentation/Zoom.php)
