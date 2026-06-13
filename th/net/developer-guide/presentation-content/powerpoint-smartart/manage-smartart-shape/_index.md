---
title: จัดการกราฟิก SmartArt ในการนำเสนอด้วย .NET
linktitle: กราฟิก SmartArt
type: docs
weight: 20
url: /th/net/manage-smartart-shape/
keywords:
- วัตถุ SmartArt
- กราฟิก SmartArt
- สไตล์ SmartArt
- สี SmartArt
- สร้าง SmartArt
- เพิ่ม SmartArt
- แก้ไข SmartArt
- เปลี่ยน SmartArt
- เข้าถึง SmartArt
- ประเภทเค้าโครง SmartArt
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำงานอัตโนมัติการสร้าง แก้ไข และจัดสไตล์ SmartArt ของ PowerPoint ใน .NET ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดสั้น ๆ และคำแนะนำที่เน้นประสิทธิภาพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสร้างและจัดการกราฟิก SmartArt ในไฟล์นำเสนอ PowerPoint อย่างโปรแกรมมิ่ง บทความนี้อธิบายวิธีการเพิ่มรูป SmartArt ลงในสไลด์, เข้าถึง SmartArt ที่มีอยู่, ค้นหา SmartArt ตามประเภทเค้าโครงที่เฉพาะเจาะจง, และอัปเดตลักษณะภาพที่มองเห็นโดยการเปลี่ยนสไตล์หรือสีของ SmartArt

ตัวอย่างแสดงวิธีการทำงานกับ SmartArt ผ่านคอลเลกชันรูปร่างของสไลด์ในไฟล์นำเสนอ, ตรวจสอบว่ารูปร่างเป็น SmartArt หรือไม่ แล้วทำการแก้ไขหรือสอบถามคุณสมบัติของมัน

## **สร้างรูป SmartArt**
Aspose.Slides for .NET ตอนนี้อำนวยความสะดวกในการเพิ่มรูป SmartArt ที่กำหนดเองลงในสไลด์ตั้งแต่ต้น Aspose.Slides for .NET ได้ให้ API ที่ง่ายที่สุดสำหรับสร้างรูป SmartArt อย่างง่ายดาย เพื่อสร้างรูป SmartArt ในสไลด์, โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่มรูป SmartArt โดยตั้งค่า LayoutType
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```c#
// สร้างอินสแตนซ์ของการนำเสนอ
using (Presentation pres = new Presentation())
{

    // เข้าถึงสไลด์ของการนำเสนอ
    ISlide slide = pres.Slides[0];

    // เพิ่มรูปร่าง Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // บันทึกการนำเสนอ
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **เข้าถึงรูป SmartArt บนสไลด์**
โค้ดต่อไปนี้จะใช้เพื่อเข้าถึงรูป SmartArt ที่เพิ่มในสไลด์ของการนำเสนอ ในโค้ดตัวอย่างเราจะวนผ่านทุกรูปร่างภายในสไลด์และตรวจสอบว่ามันเป็นรูป SmartArt หรือไม่ หากรูปร่างเป็นประเภท SmartArt เราจะทำการแปลงเป็นอินสแตนซ์ SmartArt

```c#
// โหลดการนำเสนอที่ต้องการ
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // วนผ่านทุกรูปร่างภายในสไลด์แรก
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape is ISmartArt)
        {
            // แปลงรูปแบบของรูปร่างเป็น SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```

## **เข้าถึงรูป SmartArt ด้วย Layout Type เฉพาะ**
โค้ดตัวอย่างต่อไปนี้จะช่วยให้เข้าถึงรูป SmartArt ที่มี LayoutType เฉพาะ โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เนื่องจากเป็นค่าอ่านอย่างเดียวและจะตั้งค่าเมื่อตัวรูป SmartArt ถูกเพิ่ม

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดการนำเสนอที่มีรูป SmartArt อยู่
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านทุกรูปร่างในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และแปลงรูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- ตรวจสอบรูป SmartArt ที่มี LayoutType เฉพาะและดำเนินการตามที่ต้องการต่อไป

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // วนผ่านทุกรูปร่างภายในสไลด์แรก
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape is ISmartArt)
        {
            // แปลงรูปร่างเป็น SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // ตรวจสอบเค้าโครง SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **เปลี่ยนสไตล์ของรูป SmartArt**
โค้ดตัวอย่างต่อไปนี้จะช่วยให้เข้าถึงรูป SmartArt ที่มี LayoutType เฉพาะ

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดการนำเสนอที่มีรูป SmartArt อยู่
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านทุกรูปร่างในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และแปลงรูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- ค้นหารูป SmartArt ที่มี Style เฉพาะ
- ตั้งค่า Style ใหม่ให้กับรูป SmartArt
- บันทึกการนำเสนอ

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // วนผ่านทุกรูปร่างภายในสไลด์แรก
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape is ISmartArt)
        {
            // แปลงรูปร่างเป็น SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // ตรวจสอบสไตล์ SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // เปลี่ยนสไตล์ SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // บันทึกการนำเสนอ
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **เปลี่ยนสไตล์สีของรูป SmartArt**
ในตัวอย่างนี้เราจะเรียนรู้วิธีการเปลี่ยนสไตล์สีสำหรับรูป SmartArt ใด ๆ ในโค้ดตัวอย่างต่อไปนี้จะเข้าถึงรูป SmartArt ที่มีสไตล์สีเฉพาะและจะเปลี่ยนสไตล์ของมัน

- สร้างอินสแตนซ์ของคลาส `Presentation` และโหลดการนำเสนอที่มีรูป SmartArt อยู่
- รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
- วนผ่านทุกรูปร่างในสไลด์แรก
- ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่และแปลงรูปร่างที่เลือกเป็น SmartArt หากเป็น SmartArt
- ค้นหารูป SmartArt ที่มี Color Style เฉพาะ
- ตั้งค่า Color Style ใหม่ให้กับรูป SmartArt
- บันทึกการนำเสนอ

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // วนผ่านทุกรูปร่างภายในสไลด์แรก
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // ตรวจสอบว่ารูปร่างเป็นประเภท SmartArt หรือไม่
        if (shape is ISmartArt)
        {
            // แปลงรูปร่างเป็น SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // ตรวจสอบประเภทสีของ SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // เปลี่ยนประเภทสีของ SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // บันทึกการนำเสนอ
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถทำแอนิเมชัน SmartArt เป็นวัตถุเดียวได้หรือไม่?**

ใช่. SmartArt เป็นรูปร่าง, ดังนั้นคุณสามารถใช้ [standard animations](/slides/th/net/powerpoint-animation/) ผ่าน API แอนิเมชัน (การเข้ามา, การออก, การเน้น, เส้นทางการเคลื่อนที่) เช่นเดียวกับรูปร่างอื่น ๆ

**ฉันจะค้นหา SmartArt ที่เฉพาะเจาะจงบนสไลด์ได้อย่างไรถ้าฉันไม่ทราบ ID ภายในของมัน?**

ตั้งค่าและใช้ Alternative Text (AltText) แล้วค้นหารูปร่างโดยค่านั้น—นี่เป็นวิธีที่แนะนำในการค้นหารูปร่างเป้าหมาย

**ฉันสามารถจัดกลุ่ม SmartArt กับรูปร่างอื่นได้หรือไม่?**

ใช่. คุณสามารถจัดกลุ่ม SmartArt กับรูปร่างอื่น (รูปภาพ, ตาราง, ฯลฯ) แล้ว [manipulate the group](/slides/th/net/group/)

**ฉันจะได้รับภาพของ SmartArt เฉพาะได้อย่างไร (เช่น สำหรับการแสดงตัวอย่างหรือรายงาน)?**

ส่งออกภาพย่อ/รูปภาพของรูปร่าง; ไลบรารีสามารถ [render individual shapes](/slides/th/net/create-shape-thumbnails/) เป็นไฟล์ราสเตอร์ (PNG/JPG/TIFF)

**ลักษณะของ SmartArt จะยังคงเหมือนเดิมเมื่อตั้งค่าแปลงการนำเสนอทั้งหมดเป็น PDF หรือไม่?**

ใช่. กลไกการเรนเดอร์มุ่งเน้นความแม่นยำสูงสำหรับ [PDF export](/slides/th/net/convert-powerpoint-to-pdf/), พร้อมตัวเลือกคุณภาพและความเข้ากันได้หลายระดับ