---
title: Managing the Hyperlinks in Presentation in PHP
type: docs
weight: 80
url: /java/managing-the-hyperlinks-in-presentation-in-php/
---

## **Aspose.Slides - Removing Hyperlinks inside Presentation**
To Remove Hyperlinks inside Presentation using **Aspose.Slides Java for PHP**, simply invoke **Hyperlinks** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 # Instantiate Presentation class that represents the presentation file

$pres = new Presentation($dataDir . 'demo.pptx');

\# Removing the hyperlinks from presentation

$pres->getHyperlinkQueries()->removeAllHyperlinks();

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "Hyperlinks.pptx", $save_format->Pptx);

print "Removed hyperlinks successfully, please check the output file." . PHP_EOL;

{{< /highlight >}}
## **Download Running Code**
Download **Managing the Hyperlinks in Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithSlidesInPresentation/Hyperlinks.php)
