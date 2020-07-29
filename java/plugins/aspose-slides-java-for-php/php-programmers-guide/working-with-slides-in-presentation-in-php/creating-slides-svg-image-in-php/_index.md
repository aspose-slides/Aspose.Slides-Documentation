---
title: Creating Slides SVG Image in PHP
type: docs
weight: 50
url: /java/creating-slides-svg-image-in-php/
---

## **Aspose.Slides - Creating Slides SVG Image**
To Create Slides SVG Image using **Aspose.Slides Java for PHP**, simply invoke **CreatingSvg** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 # Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'demo.pptx');

\# Getting last slide index

$last_slide_position = $pres->getSlides()->size();

#Iterating through every presentation slide and generating SVG image

$i = 0;

while ($i < $last_slide_position){

\# Accessing Slides

$slide = $pres->getSlides()->get_Item($i);

\# Getting and saving the slide SVG image

$slide->writeAsSvg(new FileOutputStream($dataDir . "SvgImage#{i}.svg"));

$i++;

}

print "Created SVG images, please check output files." . PHP_EOL;


{{< /highlight >}}
## **Download Running Code**
Download **Creating Slides SVG Image (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/CreatingSvg.php)
