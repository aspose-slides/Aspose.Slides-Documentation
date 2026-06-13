---
title: รับการแจ้งเตือนการเรียกคืนสำหรับการแทนที่ฟอนต์ใน .NET
type: docs
weight: 120
url: /th/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- การแจ้งเตือนการเรียกคืน
- การแทนที่ฟอนต์
- กระบวนการเรนเดอร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีรับการแจ้งเตือนการเรียกคืนสำหรับการแทนที่ฟอนต์ใน Aspose.Slides สำหรับ .NET และแสดงการนำเสนอ PowerPoint และ OpenDocument อย่างแม่นยำ."
---
## **บทนำ**

Aspose.Slides for .NET อนุญาตให้คุณรับการแจ้งเตือนการเรียกคืนเมื่อมีการแทนที่ฟอนต์ หากฟอนต์ที่จำเป็นไม่มีอยู่บนเครื่องระหว่างการเรนเดอร์ การเรียกคืนเหล่านี้ช่วยวินิจฉัยปัญหาเกี่ยวกับฟอนต์ที่หายไปหรือเข้าถึงไม่ได้

## **เปิดการแจ้งเตือนการเรียกคืน**

Aspose.Slides for .NET มี API ที่ใช้งานง่ายสำหรับรับการแจ้งเตือนการเรียกคืนเมื่อเรนเดอร์สไลด์พรีเซนเทชั่น ทำตามขั้นตอนต่อไปนี้เพื่อกำหนดค่าการแจ้งเตือนการเรียกคืน:

1. สร้างคลาส callback แบบกำหนดเองที่ทำการ 구현อินเทอร์เฟซ [IWarningCallback](https://reference.aspose.com/slides/th/net/aspose.slides.warnings/iwarningcallback/) เพื่อจัดการคำเตือน
1. ตั้งค่าการแจ้งเตือนการเรียกคืนโดยใช้คลาสตัวเลือกเช่น [RenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/htmloptions/), และอื่นๆ
1. โหลดพรีเซนเทชั่นที่ใช้ฟอนต์ที่ไม่พร้อมใช้งานบนเครื่องเป้าหมาย
1. สร้างภาพย่อของสไลด์หรือส่งออกพรีเซนเทชั่นเพื่อสังเกตผลลัพธ์

**คลาส Callback คำเตือนแบบกำหนดเอง:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// ตัวอย่างผลลัพธ์:
//
// ฟอนต์จะถูกแทนที่จาก XYZ ไปยัง {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segue UI Symbol}}
```

**สร้างภาพย่อของสไลด์:**

```c#
// ตั้งค่าการเรียกคืนคำเตือนเพื่อจัดการคำเตือนที่เกี่ยวกับฟอนต์ระหว่างการเรนเดอร์สไลด์.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// โหลดพรีเซนเทชั่นจากเส้นทางไฟล์ที่ระบุ.
using var presentation = new Presentation("sample.pptx");

// สร้างภาพย่อสำหรับแต่ละสไลด์ในพรีเซนเทชั่น.
foreach (var slide in presentation.Slides)
{
    // รับภาพย่อของสไลด์โดยใช้ตัวเลือกการเรนเดอร์ที่ระบุ.
    using var image = slide.GetImage(options);
    // ...
}
```

**ส่งออกเป็นรูปแบบ PDF:**

```c#
// ตั้งค่าการเรียกคืนคำเตือนเพื่อจัดการคำเตือนที่เกี่ยวกับฟอนต์ระหว่างการส่งออกเป็น PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// โหลดพรีเซนเทชั่นจากเส้นทางไฟล์ที่ระบุ.
using var presentation = new Presentation("sample.pptx");

// ส่งออกพรีเซนเทชั่นเป็น PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**ส่งออกเป็นรูปแบบ HTML:**

```c#
// ตั้งค่าการเรียกคืนคำเตือนเพื่อจัดการคำเตือนที่เกี่ยวกับฟอนต์ระหว่างการส่งออกเป็น HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// โหลดพรีเซนเทชั่นจากเส้นทางไฟล์ที่ระบุ.
using var presentation = new Presentation("sample.pptx");

// ส่งออกพรีเซนเทชั่นในรูปแบบ HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```