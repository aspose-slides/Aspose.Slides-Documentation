---
title: Efficiently Merge Presentations in PHP
linktitle: Merge Presentations
type: docs
weight: 40
url: /php-java/merge-presentation/
keywords:
- merge PowerPoint
- merge presentations
- merge slides
- merge PPT
- merge PPTX
- merge ODP
- combine PowerPoint
- combine presentations
- combine slides
- combine PPT
- combine PPTX
- combine ODP
- PHP
- Aspose.Slides
description: "Effortlessly merge PowerPoint (PPT, PPTX) and OpenDocument (ODP) presentations with Aspose.Slides for PHP via Java, streamlining your workflow."
---


## **Presentation Merging**

When you merge one presentation to another, you are effectively combining their slides in a single presentation to obtain one file. 

{{% alert title="Info" color="info" %}}

Most presentation programs (PowerPoint or OpenOffice) lack functions that allow users to combine presentations in such manner. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data.

**See also**

[Clone Slides](/slides/php-java/clone-slides/).

{{% /alert %}}

### **What Can Be Merged**

With Aspose.Slides, you can merge 

* entire presentations. All the slides from the presentations end up in one presentation
* specific slides. Selected slides end up in one presentation
* presentations in one format (PPT to PPT, PPTX to PPTX, etc) and in different formats (PPT to PPTX, PPTX to ODP, etc) to one another. 

{{% alert title="Note" color="warning" %}} 

Besides presentations, Aspose.Slides allows you to merge other files:

* [Images](https://products.aspose.com/slides/php-java/merger/image-to-image/), such as [JPG to JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) or [PNG to PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Documents, such as [PDF to PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) or [HTML to HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* And two different files such as [image to PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) or [JPG to PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) or [TIFF to PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Merging Options**

You can apply options that determine whether

* each slide in the output presentation retains a unique style
* a specific style is used for all the slides in the output presentation. 

To merge presentations, Aspose.Slides provides [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) methods (from the [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) class). There are several implementations of the `addClone` methods that define the presentation merging process parameters. Every Presentation object has a [slide](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) collection, so you can call a `addClone` method from the presentation to which you want to merge slides.

The `addClone` method returns a `Slide` object, which is a clone of the source slide. The slides in an output presentation are simply a copy of the slides from the source. Therefore, you can make changes the resulting slides (for example, apply styles or formatting options or layouts) without worrying about the source presentations becoming affected. 

## **Merge Presentations** 

Aspose.Slides provides the [addClone(Slide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) method that allows you to combine slides while the slides retain their layouts and styles (default parameters).

This PHP code shows you how to merge presentations:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Merge Presentations with a Slide Master**

Aspose.Slides provides the [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) method that allows you to combine slides while applying a slide master presentation template. This way, if necessary, you get to change the style for slides in the output presentation.

This code  demonstrates the described operation:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

The slide layout for the slide master is determined automatically. When an appropriate layout can't be determined, if the `allowCloneMissingLayout` boolean parameter of the `addClone` method is set to true, the layout for the source slide is used. Otherwise, [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) will be thrown.

{{% /alert %}}

If you want the slides in the output presentation to have a different slide layout, use the [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) method instead when merging.

## **Merge Specific Slides from Presentations**

Merging specific slides from multiple presentations is useful for creating custom slide decks. Aspose.Slides for PHP via Java allows you to select and import only the slides you need. The API preserves formatting, layout, and design of the original slides.

The following PHP code creates a new presentation, adds title slides from two other presentations, and saves the result to a file:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Merge Presentations with a Slide Layout**

This PHP code shows you how to combine slides from presentations while applying your preferred slide layout to them to get one output presentation:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Merge Presentations with Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 

You cannot merge presentations with different slide sizes. 

{{% /alert %}}

To merge 2 presentations with different slide sizes, you have to resize one of the presentations to make its size match that of the other presentation. 

This sample code demonstrates the described operation:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Merge Slides to a Presentation Section**

This PHP code shows you how to merge a specific slide to a section in a presentation:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

The slide is added at the end of the section. 

## **See Also**


Aspose provides a [FREE Online Collage Maker](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and more.

Check out the [Aspose FREE Online Merger](https://products.aspose.app/slides/merger). It allows you to merge PowerPoint presentations in the same format (e.g., PPT to PPT, PPTX to PPTX) or across different formats (e.g., PPT to PPTX, PPTX to ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **FAQ**

**Are there any limitations on the number of slides when merging presentations?**

No strict limitations. Aspose.Slides can handle large files, but performance depends on the size and system resources. For very large presentations, it's recommended to use a 64-bit JVM and allocate sufficient heap memory.

**Can I merge presentations with embedded video or audio?**

Yes, Aspose.Slides preserves multimedia content embedded in slides, but the final presentation might become significantly larger.

**Will fonts be preserved when merging presentations?**

Yes. Fonts used in source presentations are preserved in the output file, assuming they are installed on the system or [embedded](/slides/php-java/embedded-font/).
