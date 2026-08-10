---
title: จัดการวัตถุ Ink ในการนำเสนอด้วย C++
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/cpp/manage-ink/
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
- IInkOptions
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการวัตถุ Ink ของ PowerPoint, แก้ไขรอยและคุณสมบัติของแปรง, และควบคุมการแสดงผล Ink ระหว่างการส่งออกเป็น PDF, HTML, SVG, TIFF, และภาพด้วย Aspose.Slides สำหรับ C++."
---
## **บทนำ**

PowerPoint มีฟีเจอร์ Ink ที่ให้คุณวาดเส้นอิสระได้ Ink สามารถใช้เพื่อไฮไลท์วัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์

The [Aspose.Slides.Ink](https://reference.aspose.com/slides/th/cpp/aspose.slides.ink/) namespace contains the classes and interfaces needed to work with ink objects. For example, the [IInk](https://reference.aspose.com/slides/th/cpp/aspose.slides.ink/iink/) interface represents an ink object on a slide.

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุ Ink**

Objects on a PowerPoint slide are typically represented by shape objects. In its simplest form, a shape is a container that defines the area of the object itself (its frame) along with properties such as the container size, shape, and background. For more information, see [Shape Layout Format](https://docs.aspose.com/slides/th/cpp/shape-manipulations/#access-layout-formats-for-shape).

อย่างไรก็ตามเมื่อ PowerPoint จัดการกับวัตถุ Ink มันจะละเลยคุณสมบัติทั้งหมดของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์จะถูกกำหนดโดยเมธอดมาตรฐาน [IShape::get_Width](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_width/) และ [IShape::get_Height](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_height/) :

![ink_powerpoint1](ink_powerpoint1.png)

## **รอย Ink**

An ink trace is a basic element used to record the trajectory of a pen as a user writes digital ink. A trace stores a sequence of connected points.

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดที่เชื่อมต่อทั้งหมดถูกเรนเดอร์ พวกมันจะสร้างภาพเช่นนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติของ Brush สำหรับการวาด**

A brush is used to draw lines that connect the points of an ink trace. The brush has its own color and size, represented by the [IInkBrush::get_Color](https://reference.aspose.com/slides/th/cpp/aspose.slides.ink/iinkbrush/get_color/) and [IInkBrush::get_Size](https://reference.aspose.com/slides/th/cpp/aspose.slides.ink/iinkbrush/get_size/) methods.

### **ตั้งค่าสีของ Ink Brush**

This C++ code shows how to set the color of an ink brush:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **ตั้งค่าขนาดของ Ink Brush**

This C++ code shows how to set the size of an ink brush:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

โดยทั่วไป ความกว้างและความสูงของ brush จะไม่ตรงกัน ดังนั้น PowerPoint จึงไม่แสดงขนาดของ brush (ส่วนข้อมูลที่เกี่ยวข้องจะเป็นสีเทา) เมื่อความกว้างและความสูงของ brush ตรงกัน PowerPoint จะแสดงขนาดของมันดังนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน เราจะเพิ่มความสูงของวัตถุ Ink และพิจารณามิติที่สำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (เฟรม) ไม่คำนึงถึงขนาดของ brush—มันจะถือว่าเส้นมีความหนาเป็นศูนย์เสมอ (ดูภาพก่อนหน้า)

ดังนั้นเพื่อกำหนดพื้นที่ที่มองเห็นของวัตถุ Ink ทั้งหมด ขนาดของ brush ในรอยต้องนำมาพิจารณา ที่นี่วัตถุเป้าหมาย (รอยข้อความที่เขียนด้วยมือ) ถูกสเกลให้ตรงกับขนาดของคอนเทนเนอร์ (เฟรม) เมื่อขนาดของคอนเทนเนอร์เปลี่ยนแปลง ขนาดของ brush จะคงที่ และในทางกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint ใช้พฤติกรรมคล้ายกันสำหรับวัตถุข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

## **ควบคุมลักษณะของ Ink ระหว่างการส่งออกและการเรนเดอร์**

Aspose.Slides provides the [IInkOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/iinkoptions/) interface to control how ink objects appear in exported or rendered output. You can use its methods to hide ink completely or change how ink brush mask operations are interpreted.

Ink options are available through the export or rendering options for several output types:

| ผลลัพธ์ | วิธีการ Ink options |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

The same two settings are available through these methods:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/iinkoptions/set_hideink/) determines whether ink objects are included in the output. Its default value is `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) determines whether a mask operation is interpreted as opacity when rendering an ink brush. Its default value is `true`; set it to `false` to use the ROP operation instead.

### **ซ่อนวัตถุ Ink ในผลลัพธ์ PDF**

By default, ink objects remain visible during export. Call [IInkOptions::set_HideInk](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/iinkoptions/set_hideink/) with `true` when you need a clean output without handwritten annotations or other ink content.

The following C++ example exports a presentation to PDF while hiding all ink objects:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **ซ่อนวัตถุ Ink เมื่อเรนเดอร์สไลด์เป็นภาพ**

To hide ink objects when rendering slides as bitmap images, configure [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) and pass the rendering options to the [ISlide::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/) method.

The following C++ example renders the first slide as a PNG image without ink objects:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **ควบคุมการเรนเดอร์ Mask ของ Ink**

The [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) method controls how mask operations are interpreted when rendering ink brushes. The default value is `true`, which uses opacity. Call the method with `false` to use the ROP operation instead.

The following C++ example exports a slide to SVG and uses ROP-based rendering for ink mask operations:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

The same setting can be applied through [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) when exporting a presentation or rendering a slide to TIFF.

### **เลือกว่าจะซ่อนหรือรักษา Ink**

Use [IInkOptions::set_HideInk](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/iinkoptions/set_hideink/) with `true` when the exported file should be a clean version of an annotated presentation, for example, a final copy intended for distribution without review marks.

Leave ink visible (the default `false` setting) when ink annotations are part of the intended content, such as review comments, handwritten notes, highlights, or drawings that should remain visible in the exported result. This allows applications to generate separate review and final outputs from the same presentation without modifying the source ink objects.

## **คำถามที่พบบ่อย**

**ฉันสามารถเปลี่ยนสีหรือขนาดของเส้น Ink ที่มีอยู่ได้หรือไม่?**

Yes. Get the trace from [IInk::get_Traces](https://reference.aspose.com/slides/th/cpp/aspose.slides.ink/iink/get_traces/), then change its [IInkTrace::get_Brush](https://reference.aspose.com/slides/th/cpp/aspose.slides.ink/iinktrace/get_brush/). You can call [IInkBrush::set_Color](https://reference.aspose.com/slides/th/cpp/aspose.slides.ink/iinkbrush/set_color/) and [IInkBrush::set_Size](https://reference.aspose.com/slides/th/cpp/aspose.slides.ink/iinkbrush/set_size/) on the brush.

**การซ่อน Ink จะเปลี่ยนแปลงการนำเสนอที่เป็นต้นทางหรือไม่?**

No. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/iinkoptions/set_hideink/) affects only the rendered or exported result; it does not remove or modify ink objects in the source presentation.

**ฟอร์แมตการส่งออกใดบ้างที่รองรับ Ink options?**

You can configure ink options for PDF, HTML, SVG, TIFF, and bitmap slide images through the corresponding export or rendering options shown above.

**อ่านเพิ่มเติม**

* To read about shapes in general, see the [PowerPoint Shapes](https://docs.aspose.com/slides/th/cpp/powerpoint-shapes/) section.
* For more information on effective values, see [Shape Effective Properties](https://docs.aspose.com/slides/th/cpp/shape-effective-properties/#get-effective-font-height-value).
* For details on PDF export, see [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/th/cpp/convert-powerpoint-to-pdf/).
* For details on HTML export, see [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/th/cpp/convert-powerpoint-to-html/).
* For details on SVG export, see [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/th/cpp/render-a-slide-as-an-svg-image/).
* For details on TIFF export, see [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/th/cpp/convert-powerpoint-to-tiff/).
* For details on slide-to-image rendering, see [Convert Presentation Slides to Images](https://docs.aspose.com/slides/th/cpp/convert-slide/).