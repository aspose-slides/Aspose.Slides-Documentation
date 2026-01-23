---
title: Automate Presentation Localization in PHP
linktitle: Presentation Localization
type: docs
weight: 100
url: /php-java/presentation-localization/
keywords:
- change language
- spell check
- language id
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Automate PowerPoint and OpenDocument slide localization with Aspose.Slides for PHP via Java, using practical code samples and tips for faster global rollout."
---

## **Change Language for a Presentation and Shape Text**
- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) of [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) type to the slide.
- Add some text to the TextFrame.
- [Set Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) to text.
- Write the presentation as a PPTX file.

The implementation of the above steps is demonstrated below in an example.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Does language ID trigger automatic text translation?**

No. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) in Aspose.Slides stores the language for spell-checking and grammar proofing, but it does not translate or change the text content. It is metadata that PowerPoint understands for proofing.

**Does language ID affect hyphenation and line breaks during rendering?**

In Aspose.Slides, [language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) is for proofing. Hyphenation quality and line wrapping primarily depend on the availability of [proper fonts](/slides/php-java/powerpoint-fonts/) and layout/line-break settings for the writing system. To ensure correct rendering, make the required fonts available, configure [font substitution rules](/slides/php-java/font-substitution/), and/or [embed fonts](/slides/php-java/embedded-font/) into the presentation.

**Can I set different languages within a single paragraph?**

Yes. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) is applied at the text portion level, so a single paragraph can mix multiple languages with distinct proofing settings.
