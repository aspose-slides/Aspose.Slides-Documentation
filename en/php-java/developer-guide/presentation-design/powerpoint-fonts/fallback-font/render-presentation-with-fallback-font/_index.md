---
title: Render Presentations with Fallback Fonts in PHP
linktitle: Render Presentations
type: docs
weight: 30
url: /php-java/render-presentation-with-fallback-font/
keywords:
- fallback font
- render PowerPoint
- render presentation
- render slide
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Render presentations with fallback fonts in Aspose.Slides for PHP via Java – keep text consistent across PPT, PPTX and ODP with step-by-step code samples."
---

The following example includes these steps:

1. We [create fallback font rules collection](/slides/php-java/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) a fallback font rule and [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) to another rule.
1. Set rules collection to [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) method.
1. With [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) method we can save presentation in the same format, or save it in another one. After fallback font rules collection is set to [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), these rules are applied during any operations over the presentation: save, render, convert, etc.

```php
  # Create new instance of a rules collection
  $rulesList = new FontFallBackRulesCollection();
  # create a number of rules
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Trying to remove FallBack font "Tahoma" from loaded rules
    $fallBackRule->remove("Tahoma");
    # And to update of rules for specified range
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Also we can remove any existing rules from list
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Assigning a prepared rules list for using
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Rendering of thumbnail with using of initialized rules collection and saving to JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Save the image to disk in JPEG format
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
Read more about how to [Convert PPT and PPTX to JPG in PHP](/slides/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}
