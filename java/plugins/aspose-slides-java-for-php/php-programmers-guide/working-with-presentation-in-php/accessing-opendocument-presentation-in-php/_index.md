---
title: Accessing OpenDocument Presentation in PHP
type: docs
weight: 10
url: /java/accessing-opendocument-presentation-in-php/
---

## **Aspose.Slides - Accessing OpenDocument Presentation**
To convert OpenDocument to PPTX presentation using **Aspose.Slides Java for PHP**, simply invoke **OdpToPptx** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 # Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Source.odp");

\# Saving the PPTX presentation to PPTX format

$save_format = new SaveFormat();

$pres->save($dataDir . "Source.pptx", $save_format->Pptx);

print "Document has been converted, please check the output file.";

{{< /highlight >}}
## **Download Running Code**
Download **Accessing OpenDocument Presentation (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithPresentation/OdpToPptx.php)
