---
title: Setting the Background Color to Slides in PHP
type: docs
weight: 100
url: /java/setting-the-background-color-to-slides-in-php/
---

## **Aspose.Slides - Setting the Background Color of a Master Slide**
To Set the Background Color of a Master Slide using **Aspose.Slides Java for PHP**, simply invoke **set_background_color_of_master_slide** method of **Background** module. Here you can see example code.

**PHP Code**

```

 public static function set_background_color_of_master_slide($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation();

\# Set the background color of the Master Slide to Forest Green

$backgroundType = new BackgroundType();

$fillType = new FillType();

$color = new Color();

$pres->getMasters()->get_Item(0)->getBackground()->setType($backgroundType->OwnBackground);

$pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->setFillType($fillType->Solid);

$pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color->GREEN);

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "MasterBG.pptx", $save_format->Pptx);

print "Set background color of master slide, please check the output file." . PHP_EOL;

}

```
## **Aspose.Slides - Setting the Background Color of a Normal Slide**
To Set the Background Color of a Master Slide using **Aspose.Slides Java for PHP**, simply invoke **set_background_color_of_normal_slide** method of **Background** module. Here you can see example code.

**PHP Code**

```

 public static function set_background_color_of_normal_slide($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation();

\# Set the background color of the Normal slide to Blue

$backgroundType = new BackgroundType();

$fillType = new FillType();

$color = new Color();

$pres->getSlides()->get_Item(0)->getBackground()->setType($backgroundType->OwnBackground);

$pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType($fillType->Solid);

$pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color->BLUE);

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "ContentBG.pptx", $save_format->Pptx);

print "Set background color of normal slide, please check the output file." . PHP_EOL;

}

```
## **Download Running Code**
Download **Setting the Background Color to Slides (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/Background.php)
