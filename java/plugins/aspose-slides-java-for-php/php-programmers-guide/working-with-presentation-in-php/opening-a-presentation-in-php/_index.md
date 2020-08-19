---
title: Opening a Presentation in PHP
type: docs
weight: 90
url: /java/opening-a-presentation-in-php/
---

## **Aspose.Slides - Opening a Presentation**
In order to open presentation using **Aspose.Slides Java for PHP**, you can use below code.

**PHPCode**

```



\# Instantiate a Presentation object that represents a PPTX file

$pres = new Presentation("demo.pptx");

\# Printing the total number of slides present in the presentation

print $pres->getSlides()->size();


```
