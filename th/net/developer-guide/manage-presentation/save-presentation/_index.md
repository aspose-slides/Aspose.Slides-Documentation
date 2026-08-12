---
title: บันทึกพรีเซนเทชันใน .NET
linktitle: บันทึกพรีเซนเทชัน
type: docs
weight: 80
url: /th/net/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกพรีเซนเทชัน
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- พรีเซนเทชันเป็นไฟล์
- พรีเซนเทชันเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- บันทึกความคืบหน้า
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีบันทึกพรีเซนเทชันใน .NET ด้วย Aspose.Slides—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงรูปแบบ, แบบอักษร และเอฟเฟกต์."
---
## **ภาพรวม**

[Open Presentations in C#](/slides/th/net/open-presentation/) อธิบายวิธีการใช้คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เพื่อเปิดไฟล์พรีเซนเทชัน บทความนี้อธิบายวิธีสร้างและบันทึกพรีเซนเทชัน คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) มีเนื้อหาของพรีเซนเทชัน ไม่ว่าคุณจะสร้างพรีเซนเทชันตั้งแต่ต้นหรือแก้ไขพรีเซนเทชันที่มีอยู่แล้ว คุณก็ต้องการบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides for .NET คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกพรีเซนเทชัน

## **บันทึกพรีเซนเทชันเป็นไฟล์**

บันทึกพรีเซนเทชันเป็นไฟล์โดยเรียกเมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกพรีเซนเทชันด้วย Aspose.Slides

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
using (Presentation presentation = new Presentation())
{
    // ทำงานบางอย่างที่นี่...

    // บันทึกพรีเซนเทชันเป็นไฟล์
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **บันทึกพรีเซนเทชันเป็นสตรีม**

คุณสามารถบันทึกพรีเซนเทชันเป็นสตรีมโดยส่งสตรีมผลลัพธ์ไปยังเมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) พรีเซนเทชันสามารถเขียนลงสตรีมหลายประเภทได้ ในตัวอย่างด้านล่าง เราจะสร้างพรีเซนเทชันใหม่และบันทึกเป็นไฟล์สตรีม

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // บันทึกพรีเซนเทชันไปยังสตรีม.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **บันทึกพรีเซนเทชันด้วยประเภทมุมมองที่กำหนดล่วงหน้า**

Aspose.Slides ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดพรีเซนเทชันที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/) ตั้งค่า property [LastView](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/lastview/) ให้เป็นค่าหนึ่งจาก enumeration [ViewType](https://reference.aspose.com/slides/th/net/aspose.slides/viewtype/)

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **บันทึกพรีเซนเทชันในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกพรีเซนเทชันในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pptxoptions/) และตั้งค่า property conformance ขณะบันทึก หากคุณตั้งค่า `Conformance.Iso29500_2008_Strict` ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างพรีเซนเทชันและบันทึกในรูปแบบ Strict Office Open XML

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน.
using (Presentation presentation = new Presentation())
{
    // บันทึกพรีเซนเทชันในรูปแบบ Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **บันทึกพรีเซนเทชันในรูปแบบ Office Open XML โหมด Zip64**

ไฟล์ Office Open XML คือไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดไฟล์ที่ไม่ได้บีบอัด, ขนาดที่บีบอัดและขนาดรวมของ archive รวมถึงจำกัดจำนวนไฟล์ที่ 65 535 (2^16‑1) ไฟล์ ส่วนขยายรูปแบบ ZIP64 จะยกขีดจำกัดเหล่านี้เป็น 2^64

คุณสมบัติ [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipptxoptions/zip64mode/) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML หรือไม่

คุณสมบัตินี้ให้โหมดต่อไปนี้:

- `IfNecessary` ใช้ส่วนขยายรูปแบบ ZIP64 เฉพาะเมื่อพรีเซนเทชันเกินขีดจำกัดข้างต้น นี่คือโหมดเริ่มต้น
- `Never` ไม่เคยใช้ส่วนขยายรูปแบบ ZIP64
- `Always` ใช้ส่วนขยายรูปแบบ ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกพรีเซนเทชันเป็นไฟล์ PPTX พร้อมเปิดใช้ส่วนขยายรูปแบบ ZIP64:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
เมื่อคุณบันทึกด้วย `Zip64Mode.Never` จะเกิด [PptxException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxexception/) หากพรีเซนเทชันไม่สามารถบันทึกในรูปแบบ ZIP32 ได้.
{{% /alert %}}

## **บันทึกพรีเซนเทชันในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

เมื่อทำงานกับพรีเซนเทชันขนาดใหญ่ คุณสามารถปรับระดับการบีบอัดเพื่อสมดุลขนาดไฟล์และเวลาประมวลผล ตามความต้องการคุณอาจต้องการประมวลผลที่เร็วขึ้นหรือไฟล์ผลลัพธ์ที่เล็กลง

Aspose.Slides มี property [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipptxoptions/compressionlevel/) ซึ่งให้คุณกำหนดระดับการบีบอัดที่ใช้เมื่อบันทึกพรีเซนเทชันในรูปแบบ Office Open XML

ระดับการบีบอัดต่อไปนี้พร้อมให้ใช้:

- **None**: ไม่ใช้การบีบอัด ไฟล์จะถูกเก็บไว้ตามต้นฉบับ
- **Level1:** การบีบอัดที่เร็วที่สุดโดยอัตราการบีบอัดต่ำสุด
- **Level2:** การบีบอัดที่เร็วกว่าโดยอัตราการบีบอัดดีขึ้นเล็กน้อยเมื่อเทียบกับ **Level1**
- **Level3:** ให้การบีบอัดดีกว่า **Level2** พร้อมผลกระทบต่อเวลาประมวลผลระดับปานกลาง
- **Level4:** ให้การบีบอัดดีกว่า **Level3**
- **Level5:** ให้การบีบอัดที่ดีขึ้นเหนือ **Level4** โดยใช้เวลาประมวลผลเพิ่มขึ้น
- **Level6:** การบีบอัดมาตรฐานที่ให้สมดุลที่ดีระหว่างความเร็วการประมวลผลและขนาดไฟล์ นี่คือ *ระดับการบีบอัดเริ่มต้น*
- **Level7:** ให้การบีบอัดดีกว่า **Level6** แต่ประมวลผลช้า
- **Level8:** ให้การบีบอัดดีกว่า **Level7**
- **Level9:** การบีบอัดสูงสุด ผลออกมามีขนาดไฟล์เล็กที่สุดแต่ใช้เวลาประมวลผลนานที่สุด

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกพรีเซนเทชันเป็นไฟล์ PPTX *โดยไม่มีการบีบอัด*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

ตัวอย่างนี้แสดงวิธีบันทึกพรีเซนเทชันเป็นไฟล์ PPTX ด้วย *การบีบอัดสูงสุด*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **บันทึกพรีเซนเทชันโดยไม่รีเฟรชภาพย่อ**

คุณสมบัติ [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) ควบคุมการสร้างภาพย่อเมื่อบันทึกพรีเซนเทชันเป็น PPTX:

- หากตั้งค่าเป็น `true` ภาพย่อจะถูกรีเฟรชระหว่างการบันทึก นี่เป็นค่าเริ่มต้น
- หากตั้งค่าเป็น `false` ภาพย่อปัจจุบันจะถูกคงไว้ หากพรีเซนเทชันไม่มีภาพย่อ จะไม่มีการสร้างภาพย่อ

ในโค้ดด้านล่าง พรีเซนเทชันจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชภาพย่อของมัน.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
ตัวเลือกนี้ช่วยลดเวลาที่ต้องใช้ในการบันทึกพรีเซนเทชันเป็นรูปแบบ PPTX.
{{% /alert %}}

## **บันทึกอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/net/aspose.slides/iprogresscallback/) ใช้ผ่าน property `ProgressCallback` ที่เปิดเผยโดยอินเทอร์เฟซ [ISaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/isaveoptions/) และคลาสนามธรรม [SaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/) ให้กำหนดการทำงานของ [IProgressCallback](https://reference.aspose.com/slides/th/net/aspose.slides/iprogresscallback/) ให้กับ `ProgressCallback` เพื่อรับการอัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // ใช้ค่าร้อยละของความคืบหน้าในที่นี้.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนา [แอปฟรี PowerPoint Splitter](https://products.aspose.app/slides/th/splitter) โดยใช้ API ของตนเอง แอปนี้ให้คุณแยกพรีเซนเทชันเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับการ "บันทึกเร็ว" (บันทึกเชิงเพิ่ม) ที่เขียนเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่ การบันทึกจะสร้างไฟล์เป้าหมายเต็มทุกครั้ง; การบันทึกเชิงเพิ่ม "บันทึกเร็ว" ไม่ได้รับการสนับสนุน.

**สามารถบันทึกอินสแตนซ์ Presentationเดียวจากหลายเธรดได้อย่างปลอดภัยหรือไม่?**

ไม่ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ไม่เป็น thread‑safe (/slides/th/net/multithreading/); ควรบันทึกจากเธรดเดียว.

**ลิงก์และไฟล์ที่ลิงก์จากภายนอกจะเกิดอะไรเมื่อบันทึก?**

[Hyperlinks](/slides/th/net/manage-hyperlinks/) จะถูกคงไว้ ไฟล์ที่ลิงก์จากภายนอก (เช่น วิดีโอที่ใช้เส้นทางสัมพันธ์) จะไม่ถูกคัดลอกโดยอัตโนมัติ — โปรดตรวจสอบให้เส้นทางที่อ้างอิงยังคงเข้าถึงได้.

**ฉันสามารถตั้งค่า/บันทึกเมตาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ได้ คุณสมบัติเอกสารมาตรฐาน (/slides/th/net/presentation-properties/) ได้รับการสนับสนุนและจะถูกเขียนลงไฟล์เมื่อบันทึก.