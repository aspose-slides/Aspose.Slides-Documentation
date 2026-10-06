---
title: เปลี่ยนขนาดและการวางแนวหน้าบันทึกใน .NET
linktitle: ขนาดหน้าบันทึก
type: docs
weight: 10
url: /th/net/notes-size/
keywords:
- ขนาดหน้าบันทึก
- การวางแนวบันทึก
- บันทึกแนวนอน
- บันทึกแนวตั้ง
- ขนาดเอกสารแจก
- PowerPoint
- งานนำเสนอ
- PPT
- PPTX
- C#
- Aspose.Slides
description: "อ่านและเปลี่ยนมิติของหน้าบันทึกใน Aspose.Slides สำหรับ .NET, สลับการวางแนว, ตรวจสอบขนาดที่บันทึก, และส่งออกบันทึกหรือเอกสารแจกเป็น PDF และภาพ."
---
## **ภาพรวม**

ใช้ [Presentation.NotesSize](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/notessize/) เพื่อเข้าถึงการตั้งค่าหน้าบันทึกของงานนำเสนอ มันจะคืนค่าออบเจ็กต์ [INotesSize](https://reference.aspose.com/slides/th/net/aspose.slides/inotessize/) ที่มีคุณสมบัติ [Size](https://reference.aspose.com/slides/th/net/aspose.slides/inotessize/size/) สามารถเขียนได้ แม้ว่าวัตถุการตั้งค่าจะเป็นแบบอ่านอย่างเดียว คุณสามารถกำหนดมิติใหม่ให้กับคุณสมบัติขนาดได้  

ความกว้างและความสูงระบุเป็น **points** โดยมี 72 points ต่อหนึ่งนิ้ว ตัวอย่างเช่น 900 × 600 points เท่ากับ 12.5 × 8⅓ นิ้ว การตั้งค่าเหล่านี้ใช้กับงานนำเสนอทั้งหมด ไม่ได้ใช้กับบันทึกของสไลด์แต่ละสไลด์  

| การตั้งค่า | วัตถุประสงค์ |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/notessize/) | ควบคุมมิติของหน้าบันทึกและมิติของหน้าที่ใช้สำหรับส่งออกเป็นเอกสารแจก |
| [Presentation.SlideSize](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slidesize/) | ควบคุมมิติของสไลด์งานนำเสนอปกติโดยใช้ [ISlideSize](https://reference.aspose.com/slides/th/net/aspose.slides/islidesize/) |

การเปลี่ยนการตั้งค่าใดหนึ่งจะไม่ทำให้การตั้งค่าอีกอันเปลี่ยนโดยอัตโนมัติ การเปลี่ยนการวางแนวของหน้าบันทึกก็ไม่ทำให้สไลด์ปกติหมุน ดู [Slide Size](/slides/th/net/slide-size/) เพื่อปรับขนาดสไลด์ปกติ  

ตัวอย่างต่อไปนี้ใช้ไฟล์ `sample.pptx` ที่มีอยู่แล้ว สำหรับตัวอย่างการส่งออก ให้ใช้งานนำเสนอที่มีสไลด์อย่างน้อยหนึ่งสไลด์ที่มีบันทึกผู้พูด ตัวอย่างแต่ละตัวสามารถรันได้อย่างอิสระ  

## **อ่านขนาดและการวางแนวของหน้าบันทึก**

อ่านค่าความกว้างและความสูงและเปรียบเทียบเพื่อกำหนดการวางแนว: หน้าแนวกว้างคือแนวนอน, หน้าทรงสูงคือแนวตั้ง, และมิติเท่ากันคือหน้าสี่เหลี่ยมจัตุรัส ตัวอย่างนี้พิมพ์มิติจริงเป็น points โดยไม่ได้อ้างอิงขนาดกระดาษมาตรฐาน  

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **สลับเป็นแนวนอนโดยไม่เปลี่ยนขนาดกระดาษ**

หากต้องการเปลี่ยนเฉพาะการวางแนว ให้สลับค่าความกว้างและความสูงที่มีอยู่ ซึ่งจะรักษาความยาวของทั้งสองด้านรวมถึงของขนาดกระดาษที่กำหนดเอง เงื่อนไขด้านล่างจะป้องกันไม่ให้หน้าที่เป็นแนวนอนอยู่แล้วถูกสลับกลับเป็นแนวตั้งและจะไม่เปลี่ยนแปลงหน้าที่เป็นสี่เหลี่ยมจัตุรัส  

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

สำหรับการวางแนวแนวตั้ง ให้ใช้การกำหนดเดียวกันเมื่อ `size.Width > size.Height` อย่าแทนที่ด้วยขนาด A4 หรือ Letter หากคุณไม่ได้ต้องการเปลี่ยนขนาดกระดาษ  

## **ตั้งและตรวจสอบขนาดหน้าบันทึกที่กำหนดเอง**

กำหนดทั้งสองมิติโดยรวมกัน แล้วใช้ [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) เพื่อบันทึกงานนำเสนอ ตัวอย่างนี้ตั้งหน้ากว้างแนวนอนที่มีขนาด 900 × 600 points, บันทึกเป็น PPTX และเปิดไฟล์ที่บันทึกใหม่อีกครั้งเพื่อเช็คค่าที่บันทึกไว้ การเปรียบเทียบอนุญาตความคลาดเคลื่อน 0.01 point สำหรับค่าทศนิยม; ไม่ได้รับประกันความแม่นยำสำหรับทุกรูปแบบไฟล์  

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

ผลลัพธ์ที่คาดหวังคือ `900 x 600 points` และ `Size preserved: True` การตรวจสอบงานนำเสนอที่เปิดใหม่ยืนยันไฟล์ที่บันทึกไว้ ไม่ใช่เพียงการตั้งค่าในหน่วยความจำเท่านั้น  

## **ส่งออกบันทึกและเอกสารแจก**

มิติของหน้ากำหนดพื้นที่ที่ใช้ได้สำหรับบันทึกหรือการจัดรูปแบบเอกสารแจก โดยไม่ได้ทำให้การจัดรูปแบบเหล่านั้นทำงานโดยอัตโนมัติ: ต้องกำหนดตัวเลือกการส่งออกด้วยเช่นกัน การส่งออกสไลด์ปกติยังคงใช้มิติของสไลด์  

### **ส่งออกบันทึกเป็น PDF และ PNG**

กำหนด [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) ให้กับ [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) เพื่อรวมบันทึกใน PDF ตัวอย่างนี้ยังเรนเดอร์สไลด์แรกที่มีบันทึกเป็น PNG ด้วยการใช้ [Slide.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/slide/getimage/) และ [RenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/renderingoptions/)  

โหมด [BottomTruncated](https://reference.aspose.com/slides/th/net/aspose.slides.export/notespositions/) จะเก็บบันทึกไว้บนหนึ่งหน้า; บันทึกที่ไม่พอดีจะถูกตัดส่วนท้าย PDF ใช้หน้าขนาด 900 × 600 points ที่สเกลภาพ 1 × 1 ที่ใช้ด้านล่าง PNG จะมีขนาด 900 × 600 พิกเซล Points อธิบายรูปทรงของหน้า; พิกเซลอธิบายผลลัพธ์แบบแรสเตอร์ ซึ่งมิติก็ขึ้นอยู่กับสเกลการเรนเดอร์ด้วย  

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

สำหรับการส่งออก PDF ที่มีบันทึกยาว, [BottomFull](https://reference.aspose.com/slides/th/net/aspose.slides.export/notespositions/) จะอนุญาตให้มีหน้าเพิ่มเติมตามต้องการ อย่าใช้โหมดนั้นกับการเรียกภาพสไลด์เดียวข้างต้นซึ่งไม่รองรับ หลังจากปรับขนาดแล้ว ตรวจสอบผลลัพธ์ว่ามีบันทึกถูกตัดหรือไม่และตำแหน่งของอ็อบเจ็กต์ notes-master ที่มีอยู่; การเปลี่ยนแปลงมิติของหน้าเพียงอย่างเดียวไม่ถือเป็นการรับประกันว่าทุกเนื้อหาจะพอดี ดู [Convert PowerPoint to PDF with Notes](/slides/th/net/convert-powerpoint-to-pdf-with-notes/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการส่งออกบันทึก  

### **ส่งออกเอกสารแจกเป็น PDF**

ใช้ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/handoutlayoutingoptions/) เพื่อใส่ภาพย่อหลายสไลด์ในหนึ่งหน้า ตัวอย่างต่อไปตั้งหน้าขนาด 900 × 600 points และใช้ [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/th/net/aspose.slides.export/handouttype/) เพื่อจัดวางสูงสุดสี่สไลด์ต่อหน้า พรีเซ็ตแนวนอนควบคุมการเรียงลำดับสไลด์; การวางแนวของหน้ามาจากความกว้างและความสูงของมัน  

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

การเปลี่ยนขนาดหน้าจะเปลี่ยนพื้นที่ที่ใช้ได้สำหรับกริดเอกสารแจกโดยไม่เปลี่ยนมิติของสไลด์ต้นทาง สำหรับภาพเอกสารแจก ให้ใช้ [Presentation.GetImages](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/getimages/) พร้อมการจัดรูปแบบเอกสารแจก แทนการใช้เมธอดภาพของสไลด์เดี่ยว ใน Aspose.Slides การเรนเดอร์เอกสารแจกระดับงานนำเสนอใช้มิติของหน้าบันทึก ส่วนการเรียกภาพสไลด์เดี่ยวจะไม่สร้างหน้าจัดเอกสารแจก ดู [Handout Mode](/slides/th/net/convert-powerpoint-in-handout-mode/) เพื่อดูตัวเลือกการจัดรูปแบบ  

## **ขนาดหน้าในตัวดู, การส่งออก, และการพิมพ์**

แยกขนาดงานนำเสนอที่จัดเก็บ, ขนาดหน้าที่ส่งออก, และขนาดกระดาษที่พิมพ์ออกจากกันให้ชัดเจน:  

- **Presentation viewers:** ตัวดูอาจแสดงหรือพิมพ์บันทึกโดยใช้กฎการจัดเลย์เอาต์ของตนเอง หากแอปพลิเคชันอื่นบันทึกไฟล์ ให้เปิดไฟล์ใหม่และตรวจสอบมิติอีกครั้ง; การแปลงรูปแบบของแอปพลิเคชันนั้นอาจทำให้ค่าเป็นมาตรฐาน  
- **Export formats:** ตัวอย่าง PDF ของบันทึกและเอกสารแจกด้านบนใช้มิติของหน้าที่กำหนดไว้ ภาพแรสเตอร์ใช้มิติพิกเซลเต็มและสเกลการเรนเดอร์ จึงอาจปัดค่าจุดเศษเป็นจำนวนเต็มในผลลัพธ์ภาพ การส่งออกสไลด์ปกติไม่ใช้ขนาดหน้าบันทึก  
- **Printer drivers:** การเลือกกระดาษ, การหมุนอัตโนมัติ, และการตั้งค่าให้พอดีกับหน้าอาจเปลี่ยนผลลัพธ์ทางกายภาพโดยไม่เปลี่ยนมิติที่เก็บในงานนำเสนอหรือ PDF สำหรับขนาดกระดาษเฉพาะ ให้ปรับให้ตรงกับการตั้งค่าของเครื่องพิมพ์และตรวจสอบตัวอย่างการพิมพ์  

## **FAQ**

**ฉันสามารถตั้งขนาดบันทึกสำหรับสไลด์เดียวได้หรือไม่?**

ขนาดหน้าบันทึกเป็นการตั้งค่าระดับงานนำเสนอ สไลด์แต่ละสไลด์อาจมีเนื้อหาบันทึกที่แตกต่างกัน แต่คุณสมบัตินี้ไม่ให้ขนาดหน้าที่แยกต่างหากสำหรับแต่ละสไลด์  

**ทำไมการเปลี่ยนการวางแนวของบันทึกจึงไม่ทำให้สไลด์ของฉันเปลี่ยนแปลง?**

หน้าบันทึกและสไลด์ปกติมีมิติที่แยกจากกัน ใช้การตั้งค่าขนาดสไลด์ปกติเมื่อคุณต้องการปรับขนาดสไลด์เอง  

**ทำไมผลลัพธ์ที่บันทึกหรือพิมพ์ได้จึงมีขนาดแตกต่าง?**

แรกเริ่มให้เปิดงานนำเสนอที่บันทึกใหม่อีกครั้งและเปรียบเทียบมิติของบันทึก หากมีการเปลี่ยนแปลง ให้ตรวจสอบว่าการบันทึกหรือแปลงไฟล์ในแอปพลิเคชันอื่นได้เปลี่ยนการตั้งค่าหน้าหรือไม่ หากไม่ได้เปลี่ยน ให้ตรวจสอบการจัดรูปแบบการส่งออก, สเกลของภาพ, การตั้งค่าตัวดู, และการเลือกกระดาษของเครื่องพิมพ์