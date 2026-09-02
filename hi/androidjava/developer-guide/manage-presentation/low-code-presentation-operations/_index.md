---
title: Android पर लो-कोड प्रेज़ेंटेशन ऑपरेशन्स
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/androidjava/low-code-presentation-operations/
keywords:
- लो-कोड प्रेज़ेंटेशन API
- प्रेज़ेंटेशन परिवर्तित करें
- प्रेज़ेंटेशन मर्ज करें
- स्लाइड्स पर पुनरावृति करें
- शेप्स पर पुनरावृति करें
- टेक्स्ट पर पुनरावृति करें
- शेप्स एकत्रित करें
- प्रेज़ेंटेशन संपीड़ित करें
- अनुपयोगी मास्टर स्लाइड्स हटाएँ
- अनुपयोगी लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट्स संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Android पर Aspose.Slides लो-कोड API का उपयोग करके प्रेज़ेंटेशन को परिवर्तित और मर्ज करें, सामग्री में पुनरावृति करें, शैप्स एकत्रित करें, और प्रेज़ेंटेशन का आकार घटाएँ।"
---
## **परिचय**

The [com.aspose.slides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/) package provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| सहायक | उपयोग कब करें |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/convert/) | एक प्रेज़ेंटेशन को सीधे फ़ाइल-से-फ़ाइल कॉल के साथ अन्य फ़ॉर्मेट में परिवर्तित करना। |
| [Merger](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/merger/) | एक ही फ़ॉर्मेट की पूरी प्रेज़ेंटेशन फ़ाइलों को मिलाना। |
| [ForEach](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/) | प्रत्येक स्लाइड, शैप, पैराग्राफ या टेक्स्ट भाग के लिए एक क्रिया चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/collect/) | पूरे प्रेज़ेंटेशन से शैप्स को पुनरावृत्ति प्रोसेसिंग या विश्लेषण के लिए प्राप्त करना। |
| [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) | अप्रयुक्त मास्टर और लेआउट्स को हटाना तथा एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **एक प्रेज़ेंटेशन को परिवर्तित करें**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/androidjava/convert-presentation/) for format-specific workflows and options.

## **प्रेज़ेंटेशन मर्ज करें**

Use [Merger.process](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) to combine complete presentation files with one call. The input presentations must have the same file format.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/androidjava/merge-presentation/) for those scenarios.

## **प्रेज़ेंटेशन तत्वों पर पुनरावृति करें**

The [ForEach](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), and [ForEach.portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) to inspect the corresponding elements:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **शेप्स संग्रहित करें**

Use [Collect.shapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Use [ForEach.shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **प्रेज़ेंटेशन सामग्री को संपीड़ित करें**

The [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) removes layout slides that no normal slide references.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) removes master slides that are no longer used.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) removes unused characters from embedded fonts.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/androidjava/slide-master/) and [Embedded Font](/androidjava/embedded-font/).

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं लो-कोड API का उपयोग कब करूँ, जबकि पूरी ऑब्जेक्ट मॉडल का उपयोग न करूँ?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**क्या Merger अलग-अलग फ़ाइल फ़ॉर्मेट के प्रेज़ेंटेशन को संयोजित कर सकता है?**

No. [Merger.process](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.autoByExtension](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), and then merge the converted files.

**क्या ForEach मास्टर, लेआउट और नोट्स स्लाइड्स को प्रोसेस करता है?**

[ForEach.slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iterates through normal presentation slides. Presentation-wide [ForEach.shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), and [ForEach.portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**ForEach.shape और Collect.shapes में अंतर क्या है?**

Use [ForEach.shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) to process each shape immediately through a callback. Use [Collect.shapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) when you need an iterable result that can be retained, filtered, counted, or traversed multiple times.

**क्या Compress हमेशा प्रेज़ेंटेशन फ़ाइल को छोटा बनाता है?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) operations may not reduce the file size.

**क्या ForEach या Compress द्वारा किए गए बदलाव स्वतः सहेजे जाते हैं?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/) callback or running [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/), call [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) to write the result.

## **संबंधित लेख**

- [प्रेज़ेंटेशन को बदलें](/androidjava/convert-presentation/)
- [प्रेज़ेंटेशन मर्ज करें](/androidjava/merge-presentation/)
- [स्लाइड मास्टर](/androidjava/slide-master/)
- [टेक्स्ट बॉक्स प्रबंधित करें](/androidjava/manage-textbox/)
- [एम्बेडेड फ़ॉन्ट](/androidjava/embedded-font/)