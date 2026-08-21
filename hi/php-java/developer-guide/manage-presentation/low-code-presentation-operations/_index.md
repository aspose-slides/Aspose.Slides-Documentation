---
title: PHP में लो-कोड प्रस्तुति संचालन
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/php-java/low-code-presentation-operations/
keywords:
- लो-कोड प्रस्तुति API
- प्रस्तुति रूपांतरण
- प्रस्तुति मिलाना
- स्लाइड्स पर पुनरावृति
- आकारों पर पुनरावृति
- पाठ पर पुनरावृति
- आकार एकत्र करना
- प्रस्तुति को संपीड़ित करना
- अप्रयुक्त मास्टर स्लाइड्स हटाएँ
- अप्रयुक्त लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट्स संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides लो-कोड API का उपयोग करके प्रस्तुतियों को परिवर्तित और मिलाएँ, सामग्री पर पुनरावृति करें, आकार एकत्र करें, और प्रस्तुति का आकार घटाएँ।"
---
## **परिचय**

The [aspose.slides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/hi/php-java/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| सहायक | उपयोग |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/php-java/aspose.slides/convert/) | सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ एक प्रस्तुति को दूसरे फ़ॉर्मेट में बदलना। |
| [Merger](https://reference.aspose.com/slides/hi/php-java/aspose.slides/merger/) | एक ही फ़ॉर्मेट की पूर्ण प्रस्तुति फ़ाइलों को मिलाना। |
| [ForEach_](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/) | प्रत्येक स्लाइड, आकार, पैराग्राफ या टेक्स्ट भाग के लिए एक कॉलबैक चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/collect/) | पुनरावृत्ति प्रोसेसिंग या विश्लेषण के लिए पूरी प्रस्तुति से आकार प्राप्त करना। |
| [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) | अप्रयुक्त मास्टर और लेआउट को हटाना और एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **एक प्रस्तुति को बदलना**

Use [Convert::autoByExtension](https://reference.aspose.com/slides/hi/php-java/aspose.slides/convert/#autoByExtension) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/hi/php-java/aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/php-java/convert-presentation/) for format-specific workflows and options.

## **प्रस्तुति को मिलाना**

Use [Merger::process](https://reference.aspose.com/slides/hi/php-java/aspose.slides/merger/#process) to combine complete presentation files with one call. The input presentations must have the same file format.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/php-java/merge-presentation/) for those scenarios.

## **प्रस्तुति तत्वों पर क्रमागत कार्य करना**

The [ForEach_](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach_::slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#paragraph), and [ForEach_::portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#portion) to inspect the corresponding elements:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **आकार एकत्र करना**

Use [Collect::shapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/collect/#shapes) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Use [ForEach_::shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#shape) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **प्रस्तुति सामग्री को संपीड़ित करना**

The [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) removes layout slides that no normal slide references.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#removeUnusedMasterSlides) removes master slides that are no longer used.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#compressEmbeddedFonts) removes unused characters from embedded fonts.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/php-java/slide-master/) and [Embedded Font](/php-java/embedded-font/).

## **अक्सर पूछे जाने वाले प्रश्न**

**किस स्थिति में मुझे पूर्ण ऑब्जेक्ट मॉडल के बजाय लो‑कोड API का उपयोग करना चाहिए?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**क्या Merger अलग‑अलग फ़ाइल फ़ॉर्मेट वाली प्रस्तुतियों को मिल सकता है?**

No. [Merger::process](https://reference.aspose.com/slides/hi/php-java/aspose.slides/merger/#process) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert::autoByExtension](https://reference.aspose.com/slides/hi/php-java/aspose.slides/convert/#autoByExtension), and then merge the converted files.

**क्या ForEach_ मास्टर, लेआउट और नोट्स स्लाइड्स को प्रोसेस करता है?**

[ForEach_::slide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#slide) iterates through normal presentation slides. Presentation-wide [ForEach_::shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#paragraph), and [ForEach_::portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#portion) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**ForEach_::shape और Collect::shapes में क्या अंतर है?**

Use [ForEach_::shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/#shape) to process each shape immediately through a callback. Use [Collect::shapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/collect/#shapes) when you need an iterable result that can be retained, filtered, counted, or traversed multiple times.

**क्या Compress हमेशा प्रस्तुति फ़ाइल को छोटा करता है?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) operations may not reduce the file size.

**क्या ForEach_ या Compress द्वारा किए गए परिवर्तन स्वचालित रूप से सहेजे जाते हैं?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach_](https://reference.aspose.com/slides/hi/php-java/aspose.slides/foreach_/) callback or running [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/), call [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) to write the result.

## **संबंधित लेख**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)