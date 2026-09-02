---
title: จัดการอ็อบเจกต์หมึกของงานนำเสนอใน .NET
linktitle: จัดการหมึก
type: docs
weight: 95
url: /th/net/manage-ink/
keywords:
- หมึก
- อ็อบเจกต์หมึก
- ร่องรอยหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- การส่งออกหมึก
- การเรนเดอร์หมึก
- ซ่อนหมึก
- IInkOptions
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการอ็อบเจกต์หมึกของ PowerPoint แก้ไขร่องรอยและคุณสมบัติของแปรง และควบคุมลักษณะของหมึกระหว่างการส่งออกเป็น PDF, HTML, SVG, TIFF และภาพด้วย Aspose.Slides สำหรับ .NET."
---
## **บทนำ**

PowerPoint มีฟีเจอร์หมึกที่ให้คุณวาดเส้นรูปแบบอิสระได้ หมึกสามารถใช้เพื่อเน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์

เนมสเปซ [Aspose.Slides.Ink](https://reference.aspose.com/slides/th/net/aspose.slides.ink/) มีคลาสและอินเทอร์เฟซที่จำเป็นสำหรับการทำงานกับอ็อบเจกต์หมึก ตัวอย่างเช่น อินเทอร์เฟซ [IInk](https://reference.aspose.com/slides/th/net/aspose.slides.ink/iink/) แทนอ็อบเจกต์หมึกบนสไลด์

## **ความแตกต่างระหว่างอ็อบเจกต์ธรรมดาและอ็อบเจกต์หมึก**

อ็อบเจกต์บนสไลด์ PowerPoint มักจะแสดงเป็นอ็อบเจกต์รูปทรง (shape) ในรูปแบบที่ง่ายที่สุด รูปร่างเป็นคอนเทนเนอร์ที่กำหนดพื้นที่ของอ็อบเจกต์เอง (กรอบ) พร้อมกับคุณสมบัติต่าง ๆ เช่น ขนาดคอนเทนเนอร์ รูปร่าง และพื้นหลัง สำหรับข้อมูลเพิ่มเติม ดูที่ [Shape Layout Format](https://docs.aspose.com/slides/th/net/shape-manipulations/#access-layout-formats-for-shape)

อย่างไรก็ตาม เมื่อ PowerPoint จัดการกับอ็อบเจกต์หมึก จะละเว้นคุณสมบัติทั้งหมดของกรอบอ็อบเจกต์ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์จะถูกกำหนดโดยคุณสมบัติมาตรฐาน [IShape.Width](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/width/) และ [IShape.Height](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/height/) :

![ink_powerpoint1](ink_powerpoint1.png)

## **ร่องรอยหมึก**

ร่องรอยหมึกเป็นองค์ประกอบพื้นฐานที่ใช้บันทึกเส้นทางของปากกาขณะที่ผู้ใช้เขียนหมึกดิจิทัล ร่องรอยจะเก็บลำดับของจุดที่เชื่อมต่อกัน

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดที่เชื่อมต่อทั้งหมดถูกแสดงผล จะได้ภาพเช่นนี้ :

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติของแปรงสำหรับการวาด**

แปรงใช้ในการวาดเส้นที่เชื่อมต่อจุดของร่องรอยหมึก แปรงมีสีและขนาดของตนเองซึ่งระบุโดยคุณสมบัติ [IInkBrush.Color](https://reference.aspose.com/slides/th/net/aspose.slides.ink/iinkbrush/color/) และ [IInkBrush.Size](https://reference.aspose.com/slides/th/net/aspose.slides.ink/iinkbrush/size/)

### **ตั้งค่าสีของแปรงหมึก**

โค้ด C# นี้แสดงวิธีตั้งค่าสีของแปรงหมึก :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **ตั้งค่าขนาดของแปรงหมึก**

โค้ด C# นี้แสดงวิธีตั้งค่าขนาดของแปรงหมึก :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

โดยทั่วไป ความกว้างและความสูงของแปรงไม่ตรงกัน ดังนั้น PowerPoint จึงไม่แสดงขนาดของแปรง (ส่วนข้อมูลที่สอดคล้องจะสีเทา) เมื่อความกว้างและความสูงของแปรงตรงกัน PowerPoint จะแสดงขนาดของมันดังนี้ :

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อทำให้เห็นชัด เราจะเพิ่มความสูงของอ็อบเจกต์หมึกและตรวจสอบมิติสำคัญ :

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่คำนึงถึงขนาดของแปรง – มันจะสมมติว่าความหนาของเส้นเป็นศูนย์ (ดูภาพก่อนหน้า)

ดังนั้นเพื่อกำหนดพื้นที่ที่มองเห็นได้ของอ็อบเจกต์หมึกทั้งหมด จำเป็นต้องพิจารณาขนาดแปรงของร่องรอยที่เกี่ยวข้อง ที่นี่อ็อบเจกต์เป้าหมาย (ร่องรอยข้อความที่เขียนด้วยมือ) ถูกปรับสเกลให้เท่ากับขนาดของคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์เปลี่ยน แปรงจะคงขนาดเดิมไว้ และในทางกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint ใช้พฤติกรรมคล้ายกันกับอ็อบเจกต์ข้อความ :

![ink_powerpoint6](ink_powerpoint6.png)

## **ควบคุมลักษณะของหมึกระหว่างการส่งออกและการเรนเดอร์**

Aspose.Slides มีอินเทอร์เฟซ [IInkOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/iinkoptions/) เพื่อควบคุมวิธีที่อ็อบเจกต์หมึกปรากฏในผลลัพธ์ที่ส่งออกหรือเรนเดอร์ คุณสามารถใช้คุณสมบัติของมันเพื่อซ่อนหมึกอย่างสมบูรณ์หรือเปลี่ยนวิธีการตีความการทำงานมาสก์ของแปรงหมึก

ตัวเลือกหมึกมีให้ผ่านตัวเลือกการส่งออกหรือเรนเดอร์สำหรับหลายรูปแบบผลลัพธ์ :

| ผลลัพธ์ | คุณสมบัติของตัวเลือกหมึก |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/th/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/inkoptions/) |
| ภาพสไลด์ | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/th/net/aspose.slides.export/renderingoptions/inkoptions/) |

คุณสมบัติสองอย่างที่เหมือนกันสามารถตั้งค่าได้ผ่านคุณสมบัติเหล่านี้ :

- [`HideInk`](https://reference.aspose.com/slides/th/net/aspose.slides.export/iinkoptions/hideink/) กำหนดว่าหมึกจะถูกรวมในผลลัพธ์หรือไม่ ค่าเริ่มต้นคือ `false`
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/th/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) กำหนดว่าการทำงานมาสก์จะถูกตีความเป็นความทึบหรือไม่เมื่อเรนเดอร์แปรงหมึก ค่าเริ่มต้นคือ `true`; ตั้งเป็น `false` เพื่อใช้การทำงาน ROP แทน

### **ซ่อนอ็อบเจกต์หมึกในผลลัพธ์ PDF**

โดยค่าเริ่มต้น หมึกจะยังคงมองเห็นได้ระหว่างการส่งออก ตั้งค่า [IInkOptions.HideInk](https://reference.aspose.com/slides/th/net/aspose.slides.export/iinkoptions/hideink/) เป็น `true` เมื่อคุณต้องการผลลัพธ์สะอาดโดยไม่มีหมายเหตุหรือเนื้อหาหมึกอื่นใด

ตัวอย่าง C# ต่อไปนี้ส่งออกงานนำเสนอเป็น PDF พร้อมซ่อนอ็อบเจกต์หมึกทั้งหมด :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **ซ่อนอ็อบเจกต์หมึกเมื่อเรนเดอร์สไลด์เป็นภาพ**

เพื่อซ่อนหมึกเมื่อเรนเดอร์สไลด์เป็นภาพบิทแมป ให้กำหนดค่า [RenderingOptions.InkOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/renderingoptions/inkoptions/) แล้วส่งตัวเลือกเรนเดอร์ไปยังเมธอด [ISlide.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/)

ตัวอย่าง C# ต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ PNG โดยไม่มีอ็อบเจกต์หมึก :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **ควบคุมการเรนเดอร์มาสก์ของหมึก**

คุณสมบัติ [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) ควบคุมวิธีตีความการทำงานมาสก์เมื่อเรนเดอร์แปรงหมึก ค่าเริ่มต้นคือ `true` ซึ่งใช้ความทึบ ตั้งค่าที่เป็น `false` เพื่อใช้การทำงาน ROP แทน

ตัวอย่าง C# ต่อไปนี้ส่งออกสไลด์เป็น SVG และใช้การเรนเดอร์แบบ ROP สำหรับการทำงานมาสก์ของหมึก :

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

การตั้งค่าเดียวกันสามารถใช้ผ่าน [TiffOptions.InkOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/inkoptions/) เมื่อส่งออกงานนำเสนอหรือเรนเดอร์สไลด์เป็น TIFF

### **เลือกว่าจะซ่อนหรือเก็บรักษาหมึก**

ใช้ [IInkOptions.HideInk](https://reference.aspose.com/slides/th/net/aspose.slides.export/iinkoptions/hideink/) ตั้งค่าเป็น `true` เมื่อไฟล์ที่ส่งออกควรเป็นเวอร์ชันสะอาดของงานนำเสนอที่มีหมายเหตุ เช่น สำเนาสุดท้ายที่ต้องแจกจ่ายโดยไม่มีเครื่องหมายตรวจทาน

ปล่อยให้ [IInkOptions.HideInk](https://reference.aspose.com/slides/th/net/aspose.slides.export/iinkoptions/hideink/) อยู่ที่ค่าเริ่มต้น `false` เมื่อคำอธิบายด้วยหมึกเป็นส่วนที่ต้องการของเนื้อหา เช่น ความคิดเห็นการตรวจทาน บันทึกมือเน้น หรือการวาดที่ต้องมองเห็นในผลลัพธ์ที่ส่งออก สิ่งนี้ช่วยให้แอปพลิเคชันสร้างผลลัพธ์การตรวจทานและผลลัพธ์สุดท้ายแยกกันจากงานนำเสนอเดียวกันโดยไม่ต้องแก้ไขอ็อบเจกต์หมึกต้นฉบับ

## **คำถามที่พบบ่อย**

**ฉันสามารถเปลี่ยนสีหรือขนาดของเส้นหมึกที่มีอยู่แล้วได้หรือไม่?**

ได้ค่ะ ให้ดึงร่องรอยจาก [IInk.Traces](https://reference.aspose.com/slides/th/net/aspose.slides.ink/iink/traces/) แล้วเปลี่ยน [IInkTrace.Brush](https://reference.aspose.com/slides/th/net/aspose.slides.ink/iinktrace/brush/) ของมัน คุณสามารถตั้งค่า [IInkBrush.Color](https://reference.aspose.com/slides/th/net/aspose.slides.ink/iinkbrush/color/) และ [IInkBrush.Size](https://reference.aspose.com/slides/th/net/aspose.slides.ink/iinkbrush/size/) ได้

**การซ่อนหมึกจะเปลี่ยนแปลงงานนำเสนอต้นฉบับหรือไม่?**

ไม่ค่ะ [IInkOptions.HideInk](https://reference.aspose.com/slides/th/net/aspose.slides.export/iinkoptions/hideink/) มีผลต่อผลลัพธ์ที่เรนเดอร์หรือส่งออกเท่านั้น ไม่ได้ลบหรือแก้ไขอ็อบเจกต์หมึกในงานนำเสนอต้นฉบับ

**รูปแบบการส่งออกใดบ้างที่รองรับตัวเลือกหมึก?**

คุณสามารถกำหนดค่าตัวเลือกหมึกสำหรับ PDF, HTML, SVG, TIFF และภาพสไลด์แบบบิทแมปผ่านตัวเลือกการส่งออกหรือเรนเดอร์ตามที่แสดงด้านบน

**เอกสารอ้างอิงเพิ่มเติม**

* เพื่ออ่านเพิ่มเติมเกี่ยวกับรูปร่างทั่วไป ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/net/powerpoint-shapes/)
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่าที่มีประสิทธิภาพ ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/net/shape-effective-properties/#get-effective-font-height-value)
* รายละเอียดการส่งออกเป็น PDF ดู [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/th/net/convert-powerpoint-to-pdf/)
* รายละเอียดการส่งออกเป็น HTML ดู [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/th/net/convert-powerpoint-to-html/)
* รายละเอียดการส่งออกเป็น SVG ดู [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/th/net/render-a-slide-as-an-svg-image/)
* รายละเอียดการส่งออกเป็น TIFF ดู [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/th/net/convert-powerpoint-to-tiff/)
* รายละเอียดการเรนเดอร์สไลด์เป็นภาพดู [Convert Presentation Slides to Images](https://docs.aspose.com/slides/th/net/convert-slide/)