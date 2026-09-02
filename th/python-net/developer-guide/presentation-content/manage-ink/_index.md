---
title: จัดการวัตถุ Ink ของพรีเซนเทชันใน Python
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/python-net/manage-ink/
keywords:
- หมึก
- วัตถุหมึก
- รอยหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- การส่งออกหมึก
- การเรนเดอร์หมึก
- ซ่อนหมึก
- InkOptions
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการวัตถุ Ink ของ PowerPoint, แก้ไขรอยและคุณสมบัติของ Brush, และควบคุมการแสดงผลของ Ink ระหว่างการส่งออกเป็น PDF, HTML, SVG, TIFF และรูปภาพด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **บทนำ**

PowerPoint มีคุณลักษณะ Ink ที่ช่วยให้คุณวาดเส้นที่ไม่มีรูปแบบได้ Ink สามารถใช้เพื่อเน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์

The [aspose.slides.ink](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/) namespace contains the classes needed to work with ink objects. For example, the [Ink](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/ink/) class represents an ink object on a slide.

## **ความแตกต่างระหว่างอ็อบเจ็กต์ทั่วไปและอ็อบเจ็กต์ Ink**

Objects on a PowerPoint slide are typically represented by shape objects. In its simplest form, a shape is a container that defines the area of the object itself (its frame) along with properties such as the container size, shape, and background. For more information, see [Shape Layout Format](https://docs.aspose.com/slides/th/python-net/shape-manipulations/#access-layout-formats-for-shape).

However, when PowerPoint handles an ink object, it ignores all properties of the object frame (container) except its size. The size of the container area is determined by the standard [Ink.width](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/ink/width/) and [Ink.height](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/ink/height/) properties:

![ink_powerpoint1](ink_powerpoint1.png)

## **รอย Ink**

An ink trace is a basic element used to record the trajectory of a pen as a user writes digital ink. A trace stores a sequence of connected points.

The simplest form of encoding specifies the X and Y coordinates of each sample point. When all connected points are rendered, they produce an image like this:

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติ Brush สำหรับการวาด**

A brush is used to draw lines that connect the points of an ink trace. Its [InkBrush.color](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/inkbrush/color/) and [InkBrush.size](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/inkbrush/size/) properties control its color and size.

### **กำหนดสี Brush ของ Ink**

This Python code shows how to set the color of an ink brush:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **กำหนดขนาด Brush ของ Ink**

This Python code shows how to set the size of an ink brush:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Generally, a brush's width and height do not match, so PowerPoint does not display the brush size (the corresponding data section is grayed out). When the brush width and height match, PowerPoint displays its size this way:

![ink_powerpoint3](ink_powerpoint3.png)

For clarity, let's increase the height of the ink object and review the important dimensions:

![ink_powerpoint4](ink_powerpoint4.png)

The container (frame) does not account for the size of the brushes—it always assumes that the line thickness is zero (see the previous image).

Therefore, to determine the visible area of the entire ink object, the brush size of its traces must be taken into account. Here, the target object (the handwritten text trace) has been scaled to the size of the container (frame). When the size of the container changes, the brush size remains constant, and vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint uses similar behavior for text objects:

![ink_powerpoint6](ink_powerpoint6.png)

## **ควบคุมการแสดงผล Ink ในระหว่างการส่งออกและการเรนเดอร์**

Aspose.Slides provides the [InkOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/inkoptions/) class to control how ink objects appear in exported or rendered output. You can use its properties to hide ink completely or change how ink brush mask operations are interpreted.

Ink options are available through the export or rendering options for several output types:

| ผลลัพธ์ | คุณสมบัติ Ink options |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/ink_options/) |

The same two settings are available through these properties:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/inkoptions/hide_ink/) determines whether ink objects are included in the output. Its default value is `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) determines whether a mask operation is interpreted as opacity when rendering an ink brush. Its default value is `True`; set it to `False` to use the ROP operation instead.

### **ซ่อนอ็อบเจ็กต์ Ink ในผลลัพธ์ PDF**

By default, ink objects remain visible during export. Set [InkOptions.hide_ink](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/inkoptions/hide_ink/) to `True` when you need a clean output without handwritten annotations or other ink content.

The following Python example exports a presentation to PDF while hiding all ink objects:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **ซ่อนอ็อบเจ็กต์ Ink เมื่อเรนเดอร์สไลด์เป็นภาพ**

To hide ink objects when rendering slides as bitmap images, configure [RenderingOptions.ink_options](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/ink_options/) and pass the rendering options to the [Slide.get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/) method.

The following Python example renders the first slide as a PNG image without ink objects:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **ควบคุมการเรนเดอร์ Mask ของ Ink**

The [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) property controls how mask operations are interpreted when rendering ink brushes. The default value is `True`, which uses opacity. Set the property to `False` to use the ROP operation instead.

The following Python example exports a slide to SVG and uses ROP-based rendering for ink mask operations:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

The same setting can be applied through [TiffOptions.ink_options](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/ink_options/) when exporting a presentation or rendering a slide to TIFF.

### **เลือกว่าจะซ่อนหรือคง Ink**

Set [InkOptions.hide_ink](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/inkoptions/hide_ink/) to `True` when the exported file should be a clean version of an annotated presentation, for example, a final copy intended for distribution without review marks.

Leave [InkOptions.hide_ink](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/inkoptions/hide_ink/) at its default value of `False` when ink annotations are part of the intended content, such as review comments, handwritten notes, highlights, or drawings that should remain visible in the exported result. This allows applications to generate separate review and final outputs from the same presentation without modifying the source ink objects.

## **คำถามที่พบบ่อย**

**ฉันสามารถเปลี่ยนสีหรือขนาดของเส้น Ink ที่มีอยู่ได้หรือไม่?**

Yes. Get the trace from [Ink.traces](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/ink/traces/), then change its [InkTrace.brush](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/inktrace/brush/). You can set the brush's [InkBrush.color](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/inkbrush/color/) and [InkBrush.size](https://reference.aspose.com/slides/th/python-net/aspose.slides.ink/inkbrush/size/) properties.

**การซ่อน Ink จะเปลี่ยนแปลงพรีเซนเทชันต้นฉบับหรือไม่?**

No. [InkOptions.hide_ink](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/inkoptions/hide_ink/) affects only the rendered or exported result; it does not remove or modify ink objects in the source presentation.

**ฟอร์แมตการส่งออกใดบ้างที่รองรับ Ink options?**

You can configure ink options for PDF, HTML, SVG, TIFF, and bitmap slide images through the corresponding export or rendering options shown above.

**เพิ่มเติม**

* เพื่ออ่านเกี่ยวกับรูปทรงโดยทั่วไป ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/python-net/powerpoint-shapes/).
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่าที่มีประสิทธิภาพ ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/python-net/shape-effective-properties/#get-effective-font-height-value).
* สำหรับรายละเอียดการส่งออกเป็น PDF ดู [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/th/python-net/convert-powerpoint-to-pdf/).
* สำหรับรายละเอียดการส่งออกเป็น HTML ดู [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/th/python-net/convert-powerpoint-to-html/).
* สำหรับรายละเอียดการส่งออกเป็น SVG ดู [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/th/python-net/render-a-slide-as-an-svg-image/).
* สำหรับรายละเอียดการส่งออกเป็น TIFF ดู [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/th/python-net/convert-powerpoint-to-tiff/).
* สำหรับรายละเอียดการเรนเดอร์สไลด์เป็นภาพดู [Convert Presentation Slides to Images](https://docs.aspose.com/slides/th/python-net/convert-slide/).