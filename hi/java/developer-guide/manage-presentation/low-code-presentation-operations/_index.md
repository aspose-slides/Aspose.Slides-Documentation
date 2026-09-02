---
title: Java में लो-कोड प्रस्तुति संचालन
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/java/low-code-presentation-operations/
keywords:
- लो-कोड प्रस्तुति API
- प्रस्तुति रूपांतरण
- प्रस्तुति मिलाएँ
- स्लाइड्स पर पुनरावृति
- शेप्स पर पुनरावृति
- टेक्स्ट पर पुनरावृति
- शेप्स एकत्र करें
- प्रस्तुति संपीड़न
- अनावश्यक मास्टर स्लाइड्स हटाएँ
- अनावश्यक लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट संपीड़न
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java में Aspose.Slides लो-कोड API का उपयोग करके प्रस्तुतियों को रूपांतरित और मिलाएँ, सामग्री पर पुनरावृति करें, शेप्स एकत्र करें, और प्रस्तुति का आकार घटाएँ।"
---
## **अवलोकन**

The [com.aspose.slides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/) पैकेज सामान्य प्रस्तुति संचालन के लिए स्थैतिक हेल्पर क्लासेस प्रदान करता है। ये हेल्पर अक्सर उपयोग किए जाने वाले ऑब्जेक्ट‑मॉडल वर्कफ़्लो को केंद्रित मेथड्स में लपेटते हैं, जिससे आप फ़ाइलों को परिवर्तित या मर्ज कर सकते हैं, प्रस्तुति तत्वों को प्रोसेस कर सकते हैं, शैप्स एकत्र कर सकते हैं, और कम कोड के साथ अनावश्यक सामग्री हटा सकते हैं।

Low‑code हेल्पर्स सबसे उपयोगी तब होते हैं जब ऑपरेशन पूरी फ़ाइल या प्रस्तुति पर लागू होता है और डिफ़ॉल्ट वर्कफ़्लो आपकी आवश्यकताओं से मेल खाता है। विस्तृत नियंत्रण की आवश्यकता होने पर individual स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, एक्सपोर्ट सेटिंग्स, या प्रस्तुति तत्वों के बीच संबंधों के लिए पूर्ण [Aspose.Slides object model](https://reference.aspose.com/slides/hi/java/com.aspose.slides/) का उपयोग करें।

निम्न तालिका उपलब्ध हेल्पर्स को सारांशित करती है:

| हेल्पर | किनके लिए उपयोग करें |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/java/com.aspose.slides/convert/) | एक प्रस्तुति को सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ अन्य फ़ॉर्मेट में परिवर्तित करना। |
| [Merger](https://reference.aspose.com/slides/hi/java/com.aspose.slides/merger/) | एक ही फ़ॉर्मेट की पूरी प्रस्तुति फ़ाइलों को मिलाना। |
| [ForEach](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/) | प्रत्येक स्लाइड, शैप, पैराग्राफ, या टेक्स्ट पोर्शन के लिए एक्शन चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/collect/) | पूरी प्रस्तुति से शैप्स को पुनः प्रोसेसिंग या विश्लेषण के लिए एकत्र करना। |
| [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) | अनावश्यक मास्टर और लेआउट हटाना और एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **एक प्रस्तुति को परिवर्तित करें**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/hi/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/hi/java/com.aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/hi/java/convert-presentation/) for format-specific workflows and options.

## **प्रस्तुतियों को मिलाएं**

Use [Merger.process](https://reference.aspose.com/slides/hi/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) to combine complete presentation files with one call. The input presentations must have the same file format.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/hi/java/merge-presentation/) for those scenarios.

## **प्रस्तुति तत्वों के माध्यम से पुनरावृत्ति करें**

The [ForEach](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), and [ForEach.portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) to inspect the corresponding elements:

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

## **शैप्स एकत्र करें**

Use [Collect.shapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach.shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **प्रस्तुति सामग्री को संपीड़ित करें**

The [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) removes layout slides that no normal slide references.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) removes master slides that are no longer used.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) removes unused characters from embedded fonts.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/hi/java/slide-master/) and [Embedded Font](/slides/hi/java/embedded-font/).

## **अक्सर पूछे जाने वाले प्रश्न**

**When should I use the low-code API instead of the full object model?**  
Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Can Merger combine presentations in different file formats?**  
No. [Merger.process](https://reference.aspose.com/slides/hi/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.autoByExtension](https://reference.aspose.com/slides/hi/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), and then merge the converted files.

**Does ForEach process master, layout, and notes slides?**  
[ForEach.slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) iterates through normal presentation slides. Presentation-wide [ForEach.shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), and [ForEach.portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**What is the difference between ForEach.shape and Collect.shapes?**  
Use [ForEach.shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) to process each shape immediately through a callback. Use [Collect.shapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) when you need an iterable result that can be retained, filtered, counted, or traversed multiple times.

**Does Compress always make the presentation file smaller?**  
Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) operations may not reduce the file size.

**Are changes made by ForEach or Compress saved automatically?**  
No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/) callback or running [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/), call [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) to write the result.

## **संबंधित लेख**

- [Convert Presentation](/slides/hi/java/convert-presentation/)
- [Merge Presentations](/slides/hi/java/merge-presentation/)
- [Slide Master](/slides/hi/java/slide-master/)
- [Manage Text Box](/slides/hi/java/manage-textbox/)
- [Embedded Font](/slides/hi/java/embedded-font/)