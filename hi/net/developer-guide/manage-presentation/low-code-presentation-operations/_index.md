---
title: .NET में लो-कोड प्रस्तुति संचालन
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/net/low-code-presentation-operations/
keywords:
- लो-कोड प्रस्तुति API
- प्रस्तुति रूपांतरण
- प्रस्तुति संयोजन
- स्लाइड्स की पुनरावृत्ति
- आकृतियों की पुनरावृत्ति
- टेक्स्ट की पुनरावृत्ति
- आकृतियों का संग्रह
- प्रस्तुति संपीड़न
- अप्रयुक्त मास्टर स्लाइड्स हटाएँ
- अप्रयुक्त लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट्स संकुचन
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides लो-कोड API का उपयोग करके प्रस्तुतियों को रूपांतरित और मिलाएँ, सामग्री पर पुनरावृत्ति करें, आकृतियों को एकत्र करें, तथा प्रस्तुति का आकार कम करें।"
---
## **अवलोकन**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| सहायक | उपयोग |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ प्रस्तुति को एक अन्य प्रारूप में बदलना। |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | एक ही प्रारूप की संपूर्ण प्रस्तुति फ़ाइलों को संयोजित करना। |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | प्रत्येक स्लाइड, शैप, पैराग्राफ या टेक्स्ट भाग के लिए कार्रवाई चलाना। |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | पुनरावर्ती प्रक्रिया या विश्लेषण के लिए संपूर्ण प्रस्तुति से शैप्स को प्राप्त करना। |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | अप्रयुक्त मास्टर/लेआउट को हटाना, एम्बेडेड फ़ॉन्ट डेटा को कम करना और चित्रों को संकुचित करना। |

## **Convert a Presentation**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/hi/net/convert-presentation/) for format-specific workflows and options.

## **Merge Presentations**

Use [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/hi/net/merge-presentation/) for those scenarios.

## **Iterate Through Presentation Elements**

The [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **Collect Shapes**

Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Compress Presentation Content**

The [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/hi/net/slide-master/) and [Embedded Font](/slides/hi/net/embedded-font/).

### **Compress the Whole Presentation**

Aspose.Slides for .NET 26.11 adds [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). It combines removal of unused layout/master slides, subsetting of embedded fonts to used characters, and picture compression at 150 DPI. Use the individual operations above when you need to control which changes are applied.

Install [Aspose.Slides for .NET](/slides/hi/net/installation/) 26.11 or later and provide `input.pptx`. Save to a separate file: removed layouts, font characters and cropped picture pixels may be needed for later editing.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Compress Images at a Chosen Resolution**

Use [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) to process eligible pictures without also removing layouts or subsetting fonts. This example uses 96 DPI; select another [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) value for your output needs.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Both helpers use the following picture-processing scope:

| सामग्री | उपचार |
| --- | --- |
| सामान्य, मास्टर और लेआउट स्लाइडों पर रैस्टर चित्र और शैप पिक्चर फ़िल्स, समूहित शैप सहित | संकुचन के योग्य। |
| अनुरोधित रिज़ॉल्यूशन से पहले या उससे कम वाले चित्र | अपस्केल नहीं किया जाता। क्रॉप किए हुए हिस्से अभी भी हटाए जा सकते हैं। |
| क्रॉप किए हुए चित्र क्षेत्र | छिपे पिक्सेल स्थायी रूप से हटाए जाते हैं और क्रॉप ऑफ़सेट रीसेट होते हैं। |
| स्लाइड बैकग्राउंड और टेबल‑सेल फ़िल्स | इन सहायक द्वारा प्रोसेस नहीं किये जाते। |
| चार्ट/स्मार्टआर्ट इंटर्नल्स, GIF और वेक्टर फ़ॉर्मेट जैसे SVG, EMF और WMF | दस्तावेज़ित इमेज‑कम्प्रेशन स्कोप के बाहर। |

In 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) avoids resolution‑based downsampling of an uncropped picture, but **does not preserve cropped pixels**. A cropped picture can still be rewritten with its hidden areas removed. Neither helper exposes a preserve‑crop option. For individual control, see the [per-picture compression example](/slides/hi/net/examples/optimization-batch/compression/).

Compare the output's appearance and file size before replacing the original. Savings depend on the source pictures, their displayed size and unused content; compression does not guarantee a smaller file. See [Embedded Fonts](/slides/hi/net/embedded-font/) for the implications of font subsetting.

## **FAQ**

**When should I use the low-code API instead of the full object model?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Can Merger combine presentations in different file formats?**

No. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), and then merge the converted files.

**Does ForEach process master, layout, and notes slides?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) iterates through normal presentation slides. Presentation-wide [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), and [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `true` to include notes slides.

**What is the difference between ForEach.Shape and Collect.Shapes?**

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) to process each shape immediately through a callback. Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) when you need an enumerable result that can be retained, filtered, counted, or traversed multiple times.

**Does Compress always make the presentation file smaller?**

Not necessarily. Savings depend on unused layouts/masters, embedded fonts with unused characters, and pictures that benefit from compression. The [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) helpers may leave the size unchanged or produce a larger file for some inputs. Compare both size and rendered quality, and keep the original.

**Are changes made by ForEach or Compress saved automatically?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) callback or running [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), call [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) to write the result.

## **Related Articles**

- [Convert Presentation](/slides/hi/net/convert-presentation/)
- [Merge Presentations](/slides/hi/net/merge-presentation/)
- [Slide Master](/slides/hi/net/slide-master/)
- [Manage Text Box](/slides/hi/net/manage-textbox/)
- [Embedded Font](/slides/hi/net/embedded-font/)