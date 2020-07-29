---
title: Removing Slides from a Presentation in PHP
type: docs
weight: 90
url: /java/removing-slides-from-a-presentation-in-php/
---

## **Aspose.Slides - Remove Slide by Index**
To remove Slide by Index from a Presentation using **Aspose.Slides Java for PHP**, call **remove_slide_by_index** method of **RemoveSlides** module. Here you can see example code.

**PHP Code**

{{< highlight php >}}

 public static function remove_slide_by_index($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'Aspose.pptx');

\# Accessing a slide using its slide index

$slide = $pres->getSlides()->get_Item(0);

\# Removing a slide using its reference

$pres->getSlides()->remove($slide);

\# Saving the presentation file

$save_format = new SaveFormat();

$pres->save($dataDir . "Modified.pptx", $save_format->Pptx);

print "Removed slide by Index, please check the output file." . PHP_EOL;

}

{{< /highlight >}}
## **Aspose.Slides - Remove Slide by ID**
To remove Slide by ID from a Presentation using **Aspose.Slides Java for PHP**, call **remove_slide_by_id** method of **RemoveSlides** module. Here you can see example code.

**PHP Code**

{{< highlight php >}}

 public static function remove_slide_by_id($dataDir=null)

{

    # Instantiate Presentation class that represents the presentation file

    $pres = new Presentation($dataDir . 'Aspose.pptx');

    # Removing a slide using its slide index

    $pres->getSlides()->removeAt(1);

    # Saving the presentation file

    $save_format = new SaveFormat();

    $pres->save($dataDir . "Modified.pptx", $save_format->Pptx);

    print "Removed slide by ID, please check the output file." . PHP_EOL;


}

{{< /highlight >}}
## **Download Running Code**
Download **Removing Slides from a Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/RemoveSlides.php)
