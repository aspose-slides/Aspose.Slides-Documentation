---
title: Python में लो-कोड प्रेज़ेंटेशन ऑपरेशन्स
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/python-net/low-code-presentation-operations/
keywords:
- लो-कोड प्रेज़ेंटेशन API
- प्रेज़ेंटेशन परिवर्तित करें
- प्रेज़ेंटेशन मिलाएँ
- आकृतियों को एकत्र करें
- प्रेज़ेंटेशन संकुचित करें
- अनुपयोगी मास्टर स्लाइड्स हटाएँ
- अनुपयोगी लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट संकुचित करें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Python में Aspose.Slides लो-कोड API का उपयोग करके प्रेज़ेंटेशन को परिवर्तित और मिलाएँ, आकृतियों को एकत्र करें, और प्रेज़ेंटेशन का आकार घटाएँ।"
---
## **अवलोकन**

The [aspose.slides.lowcode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/) module provides helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/hi/python-net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| सहायक | उपयोग |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/convert/) | सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ प्रेज़ेंटेशन को किसी अन्य फ़ॉर्मेट में परिवर्तित करना। |
| [Merger](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/merger/) | एक ही फ़ॉर्मेट की संपूर्ण प्रेज़ेंटेशन फ़ाइलों को मिलाना। |
| [Collect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/collect/) | पूरे प्रेज़ेंटेशन से आकृतियों को प्राप्त करना ताकि उन्हें बार‑बार प्रोसेस या विश्लेषण किया जा सके। |
| [Compress](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/) | अनावश्यक मास्टर और लेआउट्स को हटाना तथा एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **प्रेज़ेंटेशन को परिवर्तित करें**

Use [Convert.auto_by_extension](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/convert/auto_by_extension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

The [Convert](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/hi/python-net/convert-presentation/) for format-specific workflows and options.

## **प्रेज़ेंटेशन मिलाएँ**

Use [Merger.process](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/hi/python-net/merge-presentation/) for those scenarios.

## **आकृतियों को एकत्र करें**

Use [Collect.shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation. This is useful when the same set will be filtered, counted, or processed more than once.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Use direct collection loops when traversal order, early exit, filtering before processing, or detailed parent-child control is important.

## **प्रेज़ेंटेशन सामग्री संकुचित करें**

The [Compress](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) removes layout slides that no normal slide references.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) removes master slides that are no longer used.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) removes unused characters from embedded fonts.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/hi/python-net/slide-master/) and [Embedded Font](/slides/hi/python-net/embedded-font/).

## **अक्सर पूछे जाने वाले प्रश्न**

**When should I use the low-code API instead of the full object model?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Can Merger combine presentations in different file formats?**

No. [Merger.process](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.auto_by_extension](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/convert/auto_by_extension/), and then merge the converted files.

**What does Collect.shapes include?**

[Collect.shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/collect/shapes/) retrieves shapes from the presentation so they can be retained, filtered, counted, or traversed multiple times. Use direct collection loops when you need precise control over which slide types or nested objects are visited.

**Does Compress always make the presentation file smaller?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/) operations may not reduce the file size.

**Are changes made by Compress saved automatically?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) object in memory. After running [Compress](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/), call [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) to write the result.

## **संबंधित लेख**

- [Convert Presentation](/slides/hi/python-net/convert-presentation/)
- [Merge Presentations](/slides/hi/python-net/merge-presentation/)
- [Slide Master](/slides/hi/python-net/slide-master/)
- [Manage Text Box](/slides/hi/python-net/manage-textbox/)
- [Embedded Font](/slides/hi/python-net/embedded-font/)