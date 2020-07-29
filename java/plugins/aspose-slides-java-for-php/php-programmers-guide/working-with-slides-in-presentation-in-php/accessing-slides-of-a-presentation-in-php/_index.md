---
title: Accessing Slides of a Presentation in PHP
type: docs
weight: 10
url: /java/accessing-slides-of-a-presentation-in-php/
---

## **Aspose.Slides - Access Slide by Index**
To access Slide by Index of a Presentation using **Aspose.Slides Java for PHP**, call **get_slide_by_index** method of **AccessSlides** module. Here you can see example code.

**PHP Code**

{{< highlight php >}}

 public static function get_slide_by_index($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'Aspose.pptx');

\# Accessing a slide using its slide index

$slide = $pres->getSlides()->get_Item(0);

print "Slide: " . $slide . PHP_EOL;

}

{{< /highlight >}}
## **Aspose.Slides - Access Slide by ID**
To access Slide by ID of a Presentation using **Aspose.Slides Java for Ruby**, call **get_slide_by_id** method of **AccessSlides** module. Here you can see example code.

**Ruby Code**

{{< highlight ruby >}}

 public static function get_slide_by_id($dataDir=null)

{

\# Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'Aspose.pptx');

\# Getting Slide ID

$id = $pres->getSlides()->get_Item(0)->getSlideId();

\# Accessing Slide by ID

$slide = $pres->getSlideById($id);

print "Slide: " . $slide . PHP_EOL;

}

{{< /highlight >}}
## **Download Running Code**
Download **Accessing Slides of a Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/AccessSlides.php)
