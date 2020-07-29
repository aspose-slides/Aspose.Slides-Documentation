---
title: Adding Slides to Presentation in PHP
type: docs
weight: 20
url: /java/adding-slides-to-presentation-in-php/
---

## **Aspose.Slides - Adding Slides to Presentation**
To add Slides to Presentation using **Aspose.Slides Java for PHP**, simply invoke **AddSlides** module. Here you can see example code.

**PHP Code**

{{< highlight php >}}

 # Instantiate Presentation class that represents the presentation file

$pres = new Presentation();

\# Instantiate SlideCollection calss

$slides = $pres->getSlides();

$i = 0;

while ($i < $pres->getLayoutSlides()->size()) {

\# Add an empty slide to the Slides collection

$slides->addEmptySlide($pres->getLayoutSlides()->get_Item($i));

$i+=1;

}

#Do some work on the newly added slide

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "EmptySlide.pptx", $save_format->Pptx);

print "Document has been created, please check the output file.";

{{< /highlight >}}
## **Download Running Code**
Download **Adding Slides to Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/AddSlides.php)
