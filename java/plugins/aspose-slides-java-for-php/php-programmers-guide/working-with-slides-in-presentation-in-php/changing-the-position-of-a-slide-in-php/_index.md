---
title: Changing the Position of a Slide in PHP
type: docs
weight: 30
url: /java/changing-the-position-of-a-slide-in-php/
---

## **Aspose.Slides - Changing the Position of a Slide**
To change the Position of a Slide using **Aspose.Slides Java for PHP**, simply invoke **ChangingPosition** module. Here you can see example code.

**PHP Code**

```

 public static function run($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'Aspose.pptx');

\# Get the slide whose position is to be changed

$slide = $pres->getSlides()->get_Item(0);

\# Set the new position for the slide

$slide->setSlideNumber(2);

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose_Position.pptx", $save_format->Pptx);

print "Changes slide position, please check the output file." . PHP_EOL;

}

```
## **Download Running Code**
Download **Changing the Position of a Slide (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/ChangingPosition.php)
