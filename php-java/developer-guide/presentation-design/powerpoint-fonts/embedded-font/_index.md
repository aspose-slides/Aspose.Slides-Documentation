---
title: Embedded Font - PowerPoint Java API
linktitle: Embedded Font
type: docs
weight: 40
url: /php-java/embedded-font/
keywords: "Fonts, embedded fonts, add fonts, PowerPoint presentation, Java, Aspose.Slides for PHP via Java"
description: "Use embedded fonts in PowerPoint presentation "

---

**Embedded fonts in PowerPoint** are useful when you want your presentation to appear correctly when opened on any system or device. If you used a third-party or non-standard font because you got creative with your work, then you have even more reasons to embed your font. Otherwise (without embedded fonts), the texts or numbers on your slides, the layout, styling, etc. may change or turn into confusing rectangles. 

The [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) class, [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) class, and their interfaces contain most of the properties and methods you need to work with embedded fonts in PowerPoint presentations.

## **Get or Remove Embedded Fonts from Presentation**

Aspose.Slides provides the [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) method (exposed by the [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) class) to allow you to get (or find out) the fonts embedded in a presentation. To remove fonts, the [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) method (exposed by the same class) is used.

This PHP code shows you how to get and remove embedded fonts from a presentation:

```php
  // Instantiates a Presentation object that represents a presentation file
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    // Renders a slide containing a text frame that uses embedded "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    // Save the image to disk in JPEG format
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    // Gets all embedded fonts
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    // Finds the "Calibri" font
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    // Removes "Calibri" font
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    // Renders the presentation; "Calibri" font is replaced with an existing one
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    // Save the image to disk in JPEG format
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    // Saves the presentation without embedded "Calibri" font to disk
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add Embedded Fonts to Presentation**

Using the [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) enum and two overloads of the [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) method, you can select your preferred (embedding) rule to embed the fonts in a presentation. This PHP code shows you how to embed and add fonts to a presentation:

```php
  // Loads the presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    // Saves the presentation to disk
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Compress Embedded Fonts**

To allow you to compress the fonts embedded in a presentation and reduce its file size, Aspose.Slides provides the [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) method (exposed by the [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) class).

This PHP code shows you how to compress embedded PowerPoint fonts:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

