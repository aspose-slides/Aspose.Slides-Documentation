---
title: การดำเนินงานพรีเซนเทชันแบบ Low-Code ใน Python ผ่าน Java
linktitle: API Low-Code
type: docs
weight: 50
url: /th/python-java/low-code-presentation-operations/
keywords:
- API การนำเสนอแบบ Low-Code
- แปลงพรีเซนเทชัน
- รวมพรีเซนเทชัน
- วนซ้ำสไลด์
- วนซ้ำรูปร่าง
- วนซ้ำนข้อความ
- รวบรวมรูปร่าง
- บีบอัดพรีเซนเทชัน
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ฝัง
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Python
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน Python ผ่าน Java เพื่อแปลงและรวมพรีเซนเทชัน, วนผ่านเนื้อหา, รวบรวมรูปร่าง, และลดขนาดพรีเซนเทชัน."
---
## **ภาพรวม**

The [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/th/python-java/aspose.slides/) API provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/th/python-java/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/python-java/aspose.slides/convert/) | แปลงพรีเซนเทชันเป็นรูปแบบอื่นด้วยการเรียกไฟล์ต่อไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/python-java/aspose.slides/merger/) | รวมไฟล์พรีเซนเทชันเต็มรูปแบบที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/) | ดำเนินการบางอย่างสำหรับทุกสไลด์, รูปร่าง, ย่อหน้า หรือส่วนของข้อความ |
| [Collect](https://reference.aspose.com/slides/th/python-java/aspose.slides/collect/) | ดึงรูปร่างจากพรีเซนเทชันทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/) | ลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่ |

## **แปลงพรีเซนเทชัน**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/th/python-java/aspose.slides/convert/#autoByExtension) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

The [Convert](https://reference.aspose.com/slides/th/python-java/aspose.slides/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/th/python-java/convert-presentation/) for format-specific workflows and options.

## **รวมพรีเซนเทชัน**

Use [Merger.process](https://reference.aspose.com/slides/th/python-java/aspose.slides/merger/#process) to combine complete presentation files with one call. The input presentations must have the same file format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/th/python-java/merge-presentation/) for those scenarios.

## **วนซ้ำผ่านองค์ประกอบของพรีเซนเทชัน**

The [ForEach](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach.slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#paragraph), and [ForEach.portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#portion) to inspect the corresponding elements:

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

## **รวบรวมรูปร่าง**

Use [Collect.shapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/collect/#shapes) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

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

Use [ForEach.shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#shape) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **บีบอัดเนื้อหาพรีเซนเทชัน**

The [Compress](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/) class can remove unused structural elements and reduce embedded font data:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) removes layout slides that no normal slide references.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#removeUnusedMasterSlides) removes master slides that are no longer used.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#compressEmbeddedFonts) removes unused characters from embedded fonts.

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/th/python-java/slide-master/) and [Embedded Font](/slides/th/python-java/embedded-font/).

## **FAQ**

**เมื่อใดที่ควรใช้ low-code API แทนโมเดลวัตถุเต็ม?**

Use low-code helpers when a standard operation applies to a complete file or presentation and does not require detailed control over individual elements. Use the full object model when you need to select specific slides, control master and layout relationships, inspect intermediate state, or configure behavior that the helper does not expose.

**Merger สามารถรวมพรีเซนเทชันในรูปแบบไฟล์ที่ต่างกันได้หรือไม่?**

No. [Merger.process](https://reference.aspose.com/slides/th/python-java/aspose.slides/merger/#process) requires input presentations in the same format. Convert the input files to a common format first, for example with [Convert.autoByExtension](https://reference.aspose.com/slides/th/python-java/aspose.slides/convert/#autoByExtension), and then merge the converted files.

**ForEach ประมวลผลมาสเตอร์, เลย์เอาต์, และสไลด์โน้ตหรือไม่?**

[ForEach.slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#slide) iterates through normal presentation slides. Presentation-wide [ForEach.shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#paragraph), and [ForEach.portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#portion) operations include normal, master, and layout slides by default. Use their overloads with `includeNotes` set to `True` to include notes slides.

**ความแตกต่างระหว่าง ForEach.shape และ Collect.shapes คืออะไร?**

Use [ForEach.shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/#shape) to process each shape immediately through a callback. Use [Collect.shapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/collect/#shapes) when you need an iterable result that can be retained, filtered, counted, or traversed multiple times.

**Compress ทำให้ไฟล์พรีเซนเทชันเล็กลงเสมอหรือไม่?**

Not necessarily. The result depends on whether the presentation contains unused layouts, unused masters, or embedded fonts with unused characters. If none of those are present, the corresponding [Compress](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/) operations may not reduce the file size.

**การเปลี่ยนแปลงที่ทำโดย ForEach หรือ Compress จะถูกบันทึกโดยอัตโนมัติหรือไม่?**

No. These helpers operate on the loaded [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) object in memory. After changing elements in a [ForEach](https://reference.aspose.com/slides/th/python-java/aspose.slides/foreach/) callback or running [Compress](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/), call [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) to write the result.

## **บทความที่เกี่ยวข้อง**

- [แปลงพรีเซนเทชัน](/slides/th/python-java/convert-presentation/)
- [รวมพรีเซนเทชัน](/slides/th/python-java/merge-presentation/)
- [มาสเตอร์สไลด์](/slides/th/python-java/slide-master/)
- [จัดการกล่องข้อความ](/slides/th/python-java/manage-textbox/)
- [ฟอนต์ฝัง](/slides/th/python-java/embedded-font/)