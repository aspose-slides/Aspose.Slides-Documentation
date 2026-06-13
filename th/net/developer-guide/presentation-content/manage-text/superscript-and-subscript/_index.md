---
title: จัดการอัศเจรีย์และตัวห้อยในงานนำเสนอด้วย .NET
linktitle: อัศเจรีย์และตัวห้อย
type: docs
weight: 80
url: /th/net/superscript-and-subscript/
keywords:
- อัศเจรีย์
- ตัวห้อย
- เพิ่มอัศเจรีย์
- เพิ่มตัวห้อย
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เชี่ยวชาญอัศเจรีย์และตัวห้อยใน Aspose.Slides for .NET และยกระดับงานนำเสนอของคุณด้วยการจัดรูปแบบข้อความระดับมืออาชีพเพื่อให้ได้ผลลัพธ์สูงสุด."
---
## **ภาพรวม**

Aspose.Slides for .NET มีฟีเจอร์สำหรับการรวมข้อความอัศเจรีย์และตัวห้อยลงในงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ของคุณ ไม่ว่าคุณจะต้องการเน้นสูตรเคมี สมการคณิตศาสตร์ หรือใส่หมายเหตุเชิงอรรถ ตัวเลือกการจัดรูปแบบพิเศษเหล่านี้ช่วยให้คงความชัดเจนและความแม่นยำไว้ได้ ในบทความนี้ คุณจะได้เรียนรู้วิธีใช้สไตล์อัศเจรีย์และตัวห้อยอย่างราบรื่นและทำให้แต่ละสไลด์มีผลลัพธ์ระดับมืออาชีพ

## **เพิ่มข้อความอัศเจรีย์และตัวห้อย**

คุณสามารถเพิ่มข้อความอัศเจรีย์และตัวห้อยภายในย่อหน้าใดก็ได้ในงานนำเสนอ เพื่อทำเช่นนี้ด้วย Aspose.Slides คุณต้องใช้คุณสมบัติ `Escapement` ของคลาส [PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/portionformat/)

คุณสมบัตินี้ช่วยให้คุณตั้งค่าข้อความอัศเจรีย์หรือตัวห้อย โดยค่าจะอยู่ในช่วง -100% (ตัวห้อย) ถึง 100% (อัศเจรีย์).

ขั้นตอนการดำเนินการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ชนิด `Rectangle` ลงในสไลด์
1. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ที่เกี่ยวข้องกับ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)
1. ล้างย่อหน้าที่มีอยู่
1. สร้าง [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) ใหม่สำหรับข้อความอัศเจรีย์และเพิ่มลงในคอลเลกชันย่อหน้าของ [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/)
1. สร้างอ็อบเจ็กต์ส่วนข้อความใหม่
1. ตั้งค่าคุณสมบัติ `Escapement` สำหรับส่วนข้อความในช่วง 0 ถึง 100 เพื่อใช้อัศเจรีย์ (ค่า 0 หมายถึงไม่มีอัศเจรีย์)
1. กำหนดข้อความให้กับ [Portion](https://reference.aspose.com/slides/th/net/aspose.slides/portion/) และเพิ่มลงในคอลเลกชันส่วนของย่อหน้า
1. สร้าง [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/) อีกหนึ่งสำหรับข้อความตัวห้อยและเพิ่มลงในคอลเลกชันย่อหน้า
1. สร้างอ็อบเจ็กต์ส่วนข้อความใหม่
1. ตั้งค่าคุณสมบัติ `Escapement` สำหรับส่วนข้อความในช่วง 0 ถึง -100 เพื่อใช้งานตัวห้อย (ค่า 0 หมายถึงไม่มีตัวห้อย)
1. กำหนดข้อความให้กับ [Portion](https://reference.aspose.com/slides/th/net/aspose.slides/portion/) และเพิ่มลงในคอลเลกชันส่วนของย่อหน้า
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

โค้ด C# ต่อไปนี้ดำเนินการตามขั้นตอนเหล่านี้:

```c#
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก.
    ISlide slide = presentation.Slides[0];

    // สร้างกล่องข้อความ.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // สร้างย่อหน้าสำหรับข้อความอัศเจรีย์.
    IParagraph superPar = new Paragraph();

    // สร้างส่วนข้อความด้วยข้อความปกติ.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // สร้างส่วนข้อความด้วยข้อความอัศเจรีย์.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // สร้างย่อหน้าสำหรับข้อความตัวห้อย.
    IParagraph paragraph2 = new Paragraph();

    // สร้างส่วนข้อความด้วยข้อความปกติ.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // สร้างส่วนข้อความด้วยข้อความตัวห้อย.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // เพิ่มย่อหน้าเข้ากล่องข้อความ.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![อัศเจรีย์และตัวห้อย](superscript_and_subscript.png)

## **คำถามที่พบบ่อย**

**ข้อความอัศเจรีย์และตัวห้อยจะคงอยู่เมื่อนำออกเป็น PDF หรือรูปแบบอื่นหรือไม่?**

ใช่, Aspose.Slides for .NET จะเก็บรักษาการจัดรูปแบบอัศเจรีย์และตัวห้อยอย่างถูกต้องเมื่อนำออกงานนำเสนอเป็น PDF, PPT/PPTX, รูปภาพ และรูปแบบที่รองรับอื่น ๆ การจัดรูปแบบพิเศษจะคงอยู่ในไฟล์ผลลัพธ์ทั้งหมด

**อัศเจรีย์และตัวห้อยสามารถผสานกับรูปแบบการจัดรูปแบบอื่น ๆ เช่น ตัวหนา หรือ ตัวเอียง ได้หรือไม่?**

ใช่, Aspose.Slides อนุญาตให้คุณผสมผสานสไตล์ข้อความต่าง ๆ ภายในส่วนข้อความเดียวกันได้ คุณสามารถเปิดใช้งานตัวหนา, ตัวเอียง, ขีดเส้นใต้ และใช้พร้อมกันอัศเจรีย์หรือ ตัวห้อยโดยกำหนดคุณสมบัติตรงตามที่เกี่ยวข้องใน [PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/portionformat/)

**การจัดรูปแบบอัศเจรีย์และตัวห้อยทำงานกับข้อความภายในตาราง, แผนภูมิ, หรือ SmartArt หรือไม่?**

ใช่, Aspose.Slides for .NET รองรับการจัดรูปแบบภายในส่วนใหญ่ของอ็อบเจ็กต์ รวมถึงตารางและองค์ประกอบของแผนภูมิ เมื่อต้องทำงานกับ SmartArt คุณต้องเข้าถึงองค์ประกอบที่เหมาะสม (เช่น [SmartArtNode](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/smartartnode/)) และคอนเทนเนอร์ข้อความของพวกมัน แล้วตั้งค่าคุณสมบัติของ [PortionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/portionformat/) อย่างคล้ายกัน