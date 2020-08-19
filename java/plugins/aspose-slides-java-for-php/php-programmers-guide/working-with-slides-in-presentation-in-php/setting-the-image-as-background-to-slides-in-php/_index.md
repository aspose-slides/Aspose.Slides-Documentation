---
title: Setting the Image as Background to Slides in PHP
type: docs
weight: 110
url: /java/setting-the-image-as-background-to-slides-in-php/
---

## **Aspose.Slides - Setting the Image as Background to Slides**
To Set the Image as Background to Slides using **Aspose.Slides Java for PHP**, simply invoke **set_image_as_background_color** method of **Background** module. Here you can see example code.

**PHPCode**

```

 public static function set_image_as_background_color($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation();

\# Set the background with Image

$backgroundType = new BackgroundType();

$fillType = new FillType();

$pictureFillMode = new PictureFillMode();

$pres->getSlides()->get_Item(0)->getBackground()->setType($backgroundType->OwnBackground);

$pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType($fillType->Picture);

$pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode($pictureFillMode->Stretch);

\# Set the picture

$imgx = $pres->getImages()->addImage(new FileInputStream(new File($dataDir . 'night.jpg')));

\# Image imgx = pres.getImages().addImage(image);

\# Add image to presentation's images collection

$pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "ContentBG_Image.pptx", $save_format->Pptx);

print "Set image as background, please check the output file." . PHP_EOL;

}

```
## **Download Running Code**
Download **Setting the Image as Background to Slides (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/Background.php)
