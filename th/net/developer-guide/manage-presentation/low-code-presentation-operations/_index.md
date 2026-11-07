---
title: การดำเนินการการนำเสนอแบบ Low-Code ใน .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /th/net/low-code-presentation-operations/
keywords:
- API การนำเสนอแบบ Low-Code
- แปลงการนำเสนอ
- รวมการนำเสนอ
- วนสไลด์
- วนรูปร่าง
- วนข้อความ
- รวบรวมรูปร่าง
- บีบอัดการนำเสนอ
- ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้
- ลบสไลด์เลย์เอาต์ที่ไม่ได้ใช้
- บีบอัดฟอนท์ที่ฝังไว้
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้ API Low-Code ของ Aspose.Slides ใน .NET เพื่อแปลงและรวมการนำเสนอ, วนผ่านเนื้อหา, รวบรวมรูปร่าง และลดขนาดการนำเสนอ"
---
## **ภาพรวม**

The [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | แปลงการนำเสนอเป็นรูปแบบอื่นด้วยการเรียกไฟล์ต่อไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | รวมไฟล์การนำเสนอเต็มรูปแบบที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | เรียกการกระทำสำหรับทุกสไลด์, รูปร่าง, ย่อหน้า, หรือส่วนของข้อความ |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | ดึงข้อมูลรูปร่างจากการนำเสนอทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | ลบมาสเตอร์/เลย์เอาต์ที่ไม่ได้ใช้, ลดข้อมูลฟอนท์ที่ฝังไว้และบีบอัดรูปภาพ |

## **แปลงการนำเสนอ**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

The [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/th/net/convert-presentation/) for format-specific workflows and options.

## **รวมการนำเสนอ**

Use [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/th/net/merge-presentation/) for those scenarios.

## **วนซ้ำผ่านองค์ประกอบการนำเสนอ**

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

## **รวบรวมรูปร่าง**

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

## **บีบอัดเนื้อหาในการนำเสนอ**

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

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/th/net/slide-master/) and [Embedded Font](/slides/th/net/embedded-font/).

### **บีบอัดการนำเสนอทั้งหมด**

Aspose.Slides for .NET 26.11 adds [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). It combines removal of unused layout/master slides, subsetting of embedded fonts to used characters, and picture compression at 150 DPI. Use the individual operations above when you need to control which changes are applied.

Install [Aspose.Slides for .NET](/slides/th/net/installation/) 26.11 or later and provide `input.pptx`. Save to a separate file: removed layouts, font characters and cropped picture pixels may be needed for later editing.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **บีบอัดรูปภาพที่ความละเอียดที่เลือก**

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

| เนื้อหา | การจัดการ |
| --- | --- |
| ภาพเรสเตอร์และการเติมรูปในรูปร่างบนสไลด์ปกติ, มาสเตอร์และเลย์เอาต์ รวมถึงรูปร่างที่จัดกลุ่ม | มีสิทธิ์บีบอัด |
| ภาพที่มีความละเอียดเท่ากับหรือต่ำกว่าความละเอียดที่ร้องขอ | ไม่ขยายขึ้นใหม่ พื้นที่ที่ถูกตัดยังสามารถลบได้ |
| พื้นที่รูปภาพที่ถูกตัด | พิกเซลที่ซ่อนอยู่จะถูกลบอย่างถาวรและค่าออฟเซ็ตการครอปจะรีเซ็ต |
| พื้นหลังสไลด์และการเติมเซลล์ตาราง | ไม่ถูกประมวลผลโดยตัวช่วยเหล่านี้ |
| ภายในแผนภูมิ/SmartArt, GIF และฟอร์แมตเวกเตอร์เช่น SVG, EMF และ WMF | อยู่นอกขอบเขตการบีบอัดรูปภาพที่ระบุในเอกสาร |

In 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) avoids resolution-based downsampling of an uncropped picture, but **does not preserve cropped pixels**. A cropped picture can still be rewritten with its hidden areas removed. Neither helper exposes a preserve-crop option. For individual control, see the [per-picture compression example](/slides/th/net/examples/optimization-batch/compression/).

Compare the output's appearance and file size before replacing the original. Savings depend on the source pictures, their displayed size and unused content; compression does not guarantee a smaller file. See [Embedded Fonts](/slides/th/net/embedded-font/) for the implications of font subsetting.

## **คำถามที่พบบ่อย**

**ควรใช้ Low-code API แทนโมเดลวัตถุเต็มเมื่อใด?**

ใช้ตัวช่วย low-code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือการนำเสนอทั้งหมดและไม่ต้องการการควบคุมละเอียดของแต่ละองค์ประกอบ ใช้โมเดลวัตถุเต็มเมื่อคุณต้องเลือกสไลด์เฉพาะ, ควบคุมความสัมพันธ์ของมาสเตอร์และเลย์เอาต์, ตรวจสอบสถานะระหว่างขั้นตอน, หรือกำหนดพฤติกรรมที่ตัวช่วยไม่เปิดเผย

**Merger สามารถรวมการนำเสนอในรูปแบบไฟล์ที่แตกต่างกันได้หรือไม่?**

ไม่ได้. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) ต้องการการนำเสนออินพุตที่มีรูปแบบไฟล์เดียวกัน แปลงไฟล์อินพุตเป็นรูปแบบทั่วไปก่อน, ตัวอย่างเช่นด้วย [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), แล้วจึงรวมไฟล์ที่แปลงแล้ว

**ForEach ประมวลผลมาสเตอร์, เลย์เอาต์และสไลด์โน้ตหรือไม่?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) จะวนผ่านสไลด์การนำเสนอปกติ ForEach-wide [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), และ [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) จะรวมสไลด์ปกติ, มาสเตอร์และเลย์เอาต์โดยค่าเริ่มต้น ใช้ overload ที่มีพารามิเตอร์ `includeNotes` ตั้งเป็น `true` เพื่อรวมสไลด์โน้ต

**ความแตกต่างระหว่าง ForEach.Shape กับ Collect.Shapes คืออะไร?**

ใช้ [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) เพื่อประมวลผลแต่ละรูปร่างทันทีผ่าน callback ใช้ [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) เมื่อคุณต้องการผลลัพธ์แบบ enumerable ที่สามารถเก็บ, กรอง, นับ หรือวนซ้ำหลายครั้งได้

**Compress ทำให้ไฟล์การนำเสนอเล็กลงเสมอหรือไม่?**

ไม่จำเป็น การประหยัดขึ้นอยู่กับเลย์เอาต์/มาสเตอร์ที่ไม่ได้ใช้, ฟอนท์ฝังที่มีอักขระไม่ได้ใช้, และรูปภาพที่ได้ประโยชน์จากการบีบอัด ตัวช่วย [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) อาจทำให้ขนาดไม่เปลี่ยนหรือแม้แต่เพิ่มขนาดสำหรับบางอินพุต เปรียบเทียบทั้งขนาดและคุณภาพที่เรนเดอร์, แล้วเก็บไฟล์ต้นฉบับไว้

**การเปลี่ยนแปลงโดย ForEach หรือ Compress จะถูกบันทึกโดยอัตโนมัติหรือไม่?**

ไม่ ตัวช่วยเหล่านี้ทำงานบนวัตถุ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ที่โหลดในหน่วยความจำ หลังจากแก้ไของค์ประกอบใน callback ของ [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) หรือเรียกใช้ [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) ให้เรียก [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) เพื่อเขียนผลลัพธ์ออกไฟล์

## **บทความที่เกี่ยวข้อง**

- [Convert Presentation](/slides/th/net/convert-presentation/)
- [Merge Presentations](/slides/th/net/merge-presentation/)
- [Slide Master](/slides/th/net/slide-master/)
- [Manage Text Box](/slides/th/net/manage-textbox/)
- [Embedded Font](/slides/th/net/embedded-font/)