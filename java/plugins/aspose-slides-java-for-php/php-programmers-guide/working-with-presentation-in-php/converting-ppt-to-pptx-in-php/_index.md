---
title: Converting PPT to PPTX in PHP
type: docs
weight: 20
url: /java/converting-ppt-to-pptx-in-php/
---

## **Aspose.Slides - Converting PPT to PPTX**
To convert PPT to PPTX presentation using **Aspose.Slides Java for PHP**, simply invoke **PptToPptx** module. Here you can see example code.

**PHP Code**

```

 # Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation($dataDir . "Presentation1.ppt");

\# Saving the PPTX presentation to PPTX format

$save_format = new SaveFormat();

$pres->save($dataDir . "Aspose.pptx", $save_format->Pptx);

print "Document has been converted, please check the output file.";

```
## **Download Running Code**
Download **Converting PPT to PPTX (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithPresentation/PptToPptx.php)
