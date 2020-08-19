---
title: Converting Presentation to PDF in PHP
type: docs
weight: 40
url: /java/converting-presentation-to-pdf-in-php/
---

## **Aspose.Slides - Converting Presentation to PDF**
To convert presentation to PDF document using **Aspose.Slides Java for PHP**, simply invoke **ConvertingToPdf** module. Here you can see example code.

**PHPCode**

```

 # Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Aspose.pptx");

\# Saving the PPTX presentation to Pdf format

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose.pdf", $save_format->Pdf);

print "Document has been converted, please check the output file.";

```
## **Download Running Code**
Download **Hello World (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithPresentation/ConvertingToPdf.php)
