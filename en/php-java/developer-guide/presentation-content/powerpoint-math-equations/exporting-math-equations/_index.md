---
title: Export Math Equations from Presentations in PHP
linktitle: Export Equations
type: docs
weight: 30
url: /php-java/exporting-math-equations/
keywords:
- export math equations
- MathML
- LaTeX
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Unlock seamless export of math equations from PowerPoint to MathML using Aspose.Slides for PHP via Java — preserve formatting and boost compatibility."
---

## **Export Math Equations from Presentations**

Aspose.Slides for PHP via Java allows you to export math equations from presentations. For example, you may need to extract the mathematical equations on slides (from a specific presentation) and use them in another program or platform.

{{% alert color="primary" %}} 

You can export equations to MathML, a popular format or standard for mathematical equations and similar content seen on the web and in many applications. 

{{% /alert %}}

While humans easily write the code for some equation formats like LaTeX, they struggle to write the code for MathML because the latter is meant to be generated automatically by apps. Programs read and parse MathML easily because its code is in XML, so MathML is commonly used as an output and printing format in many fields. 

This sample code shows you how to export a math equation from a presentation to MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

You can export either an entire math paragraph ([MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)) or an individual block ([MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)) to MathML. Both types provide a method to write to MathML.

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

A formula lives in a [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) and has a [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Images and regular text portions without a [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) are not exportable formulas.

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

The export targets standard MathML (XML). Aspose uses Presentation MathML—the presentation subset of the standard—which is widely used across applications and the web.

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

Yes, if those objects contain text portions with a [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) (i.e., genuine PowerPoint formulas), they are exported. If a formula is embedded as an image, it is not.

**Does exporting to MathML modify the original presentation?**

No. Writing MathML is a serialization of the formula’s content; it does not modify the presentation file.
