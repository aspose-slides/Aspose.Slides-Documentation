---
title: Low-Code Presentation Operations in Python via Java
linktitle: Low-Code API
type: docs
weight: 50
url: /python-java/low-code-presentation-operations/
keywords:
- low-code presentation API
- convert presentation
- merge presentations
- iterate slides
- iterate shapes
- iterate text
- collect shapes
- compress presentation
- remove unused master slides
- remove unused layout slides
- compress embedded fonts
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Use the Aspose.Slides low-code API in Python via Java to convert and merge presentations, iterate through content, collect shapes, and reduce presentation size."
---

## **Overview**

The [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/python-java/aspose.slides/) API provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/python-java/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/python-java/aspose.slides/convert/) | Converting a presentation to another format with a direct file-to-file call. |
| [Merger](https://reference.aspose.com/slides/python-java/aspose.slides/merger/) | Combining complete presentation files of the same format. |
| [ForEach](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/) | Running an action for every slide, shape, paragraph, or text portion. |
| [Collect](https://reference.aspose.com/slides/python-java/aspose.slides/collect/) | Retrieving shapes from the entire presentation for repeated processing or analysis. |
| [Compress](https://reference.aspose.com/slides/python-java/aspose.slides/compress/) | Removing unused masters and layouts and reducing embedded font data. |

## **Convert a Presentation**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/python-java/aspose.slides/convert/#autoByExtension) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

The [Convert](https://reference.aspose.com/slides/python-java/aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/python-java/convert-presentation/) for format-specific workflows and options.

## **Merge Presentations**

Use [Merger.process](https://reference.aspose.com/slides/python-java/aspose.slides/merger/#process) to combine complete presentation files with one call. The input presentations must have the same file format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/python-java/merge-presentation/) for those scenarios.

## **Iterate Through Presentation Elements**

The [ForEach](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#paragraph), and [ForEach.portion](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#portion) to inspect the corresponding elements:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **Collect Shapes**

Use [Collect.shapes](https://reference.aspose.com/slides/python-java/aspose.slides/collect/#shapes) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Use [ForEach.shape](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#shape) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Compress Presentation Content**

The [Compress](https://reference.aspose.com/slides/python-java/aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) removes layout slides that no normal slide references.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/python-java/aspose.slides/compress/#removeUnusedMasterSlides) removes master slides that are no longer used.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/python-java/aspose.slides/compress/#compressEmbeddedFonts) removes unused characters from embedded fonts.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/python-java/slide-master/) and [Embedded Font](/slides/python-java/embedded-font/).

## **FAQ**

**When should I use the low-code API instead of the full object model?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Can Merger combine presentations in different file formats?**

No. [Merger.process](https://reference.aspose.com/slides/python-java/aspose.slides/merger/#process) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.autoByExtension](https://reference.aspose.com/slides/python-java/aspose.slides/convert/#autoByExtension), and then merge the converted files.

**Does ForEach process master, layout, and notes slides?**

[ForEach.slide](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#slide) iterates through normal presentation slides. Presentation-wide [ForEach.shape](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#paragraph), and [ForEach.portion](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#portion) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `True` to include notes slides.

**What is the difference between ForEach.shape and Collect.shapes?**

Use [ForEach.shape](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/#shape) to process each shape immediately through a callback. Use [Collect.shapes](https://reference.aspose.com/slides/python-java/aspose.slides/collect/#shapes) when you need an iterable result that can be retained, filtered, counted, or traversed multiple times.

**Does Compress always make the presentation file smaller?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/python-java/aspose.slides/compress/) operations may not reduce the file size.

**Are changes made by ForEach or Compress saved automatically?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/python-java/aspose.slides/foreach/) callback or running [Compress](https://reference.aspose.com/slides/python-java/aspose.slides/compress/), call [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) to write the result.

## **Related Articles**

- [Convert Presentation](/slides/python-java/convert-presentation/)
- [Merge Presentations](/slides/python-java/merge-presentation/)
- [Slide Master](/slides/python-java/slide-master/)
- [Manage Text Box](/slides/python-java/manage-textbox/)
- [Embedded Font](/slides/python-java/embedded-font/)
