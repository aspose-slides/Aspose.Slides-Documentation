---
title: บันทึกงานนำเสนอใน .NET
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/net/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- บันทึกความคืบหน้า
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีการบันทึกงานนำเสนอใน .NET ด้วย Aspose.Slides—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงรูปแบบ ตัวอักษร และเอฟเฟกต์ไว้"
---
## **ภาพรวม**

[Open Presentations in C#](/slides/th/net/open-presentation/) แสดงวิธีใช้คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เพื่อเปิดไฟล์งานนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เก็บเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำตั้งแต่เริ่มต้นหรือแก้ไขงานที่มีอยู่ คุณก็ต้องการบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides for .NET คุณสามารถบันทึกเป็น **file** หรือ **stream** บทความนี้อธิบายวิธีบันทึกงานนำเสนอในรูปแบบต่างๆ

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอเป็นไฟล์โดยเรียกเมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกให้เมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    // ทำงานบางอย่างที่นี่...

    // บันทึกงานนำเสนอลงไฟล์
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **บันทึกงานนำเสนอเป็น Streams**

คุณสามารถบันทึกงานนำเสนอเป็น stream ได้โดยส่ง output stream ไปยังเมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) งานนำเสนอสามารถเขียนลงในหลายประเภทของ stream ในตัวอย่างด้านล่าง เราจะสร้างงานนำเสนอใหม่และบันทึกลงในไฟล์ stream

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // บันทึกงานนำเสนอไปยังสตรีม.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **บันทึกงานนำเสนอด้วยมุมมองที่กำหนดล่วงหน้า**

Aspose.Slides ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/) ตั้งค่า property [LastView](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/lastview/) ให้เป็นค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/net/aspose.slides/viewtype/)

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pptxoptions/) และตั้งค่า property conformance ขณะบันทึก หากคุณตั้งค่า `Conformance.Iso29500_2008_Strict` ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างต่อไปนี้สร้างงานนำเสนอแล้วบันทึกในรูปแบบ Strict Office Open XML

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดไฟล์ที่ไม่ได้บีบอัด, ขนาดบีบอัด, และขนาดรวมของ archive, รวมถึงจำกัดจำนวนไฟล์สูงสุด 65 535 (2^16‑1) ไฟล์ ส่วนต่อขยายรูปแบบ ZIP64 เพิ่มขีดจำกัดเหล่านี้เป็น 2^64

Property [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipptxoptions/zip64mode/) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML หรือไม่

Property นี้มีโหมดต่อไปนี้:

- `IfNecessary` ใช้ส่วนขยาย ZIP64 เฉพาะเมื่องานนำเสนอเกินข้อจำกัดข้างต้น นี่คือโหมดเริ่มต้น
- `Never` ไม่ใช้ส่วนขยาย ZIP64 ทั้งใด
- `Always` ใช้ส่วนขยาย ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็น PPTX พร้อมเปิดใช้ส่วนขยายรูปแบบ ZIP64:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
เมื่อคุณบันทึกด้วย `Zip64Mode.Never` จะเกิดการโยนข้อยกเว้น [PptxException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxexception/) หากไม่สามารถบันทึกงานนำเสนอในรูปแบบ ZIP32 ได้
{{% /alert %}}

## **บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อ**

Property [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) ควบคุมการสร้างภาพย่อเมื่อบันทึกงานนำเสนอเป็น PPTX:

- หากตั้งค่าเป็น `true` ภาพย่อจะถูกรีเฟรชระหว่างการบันทึก นี่คือค่าเริ่มต้น
- หากตั้งค่าเป็น `false` ภาพย่อปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีภาพย่อ จะไม่สร้างขึ้น

ในโค้ดด้านล่าง งานนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชภาพย่อ

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
ตัวเลือกนี้ช่วยลดเวลาที่ต้องใช้ในการบันทึกงานนำเสนอในรูปแบบ PPTX
{{% /alert %}}

## **บันทึกการอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/net/aspose.slides/iprogresscallback/) ถูกใช้ผ่าน property `ProgressCallback` ที่เปิดเผยโดยอินเทอร์เฟซ [ISaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/isaveoptions/) และคลาสเชิงนามธรรม [SaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/) กำหนดการทำงานของ [IProgressCallback] ให้กับ `ProgressCallback` เพื่อรับการอัปเดตความคืบหน้าการบันทึกเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ `IProgressCallback`

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // ใช้ค่าร้อยละของความคืบหน้าที่นี่.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนาแอป [PowerPoint Splitter ฟรี](https://products.aspose.app/slides/th/splitter) โดยใช้ API ของตน แอปนี้ช่วยให้คุณแยกงานนำเสนอเป็นไฟล์หลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **FAQ**

**รองรับ “fast save” (การบันทึกแบบเพิ่ม) ที่เขียนเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่ การบันทึกจะสร้างไฟล์เป้าหมายเต็มทุกครั้ง; การบันทึกแบบเพิ่ม “fast save” ไม่ได้รับการสนับสนุน

**เป็น thread‑safe หรือไม่ที่จะบันทึกอินสแตนซ์ Presentation เดียวจากหลายเธรด?**

ไม่ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) [ไม่รองรับการทำงานหลายเธรด](/slides/th/net/multithreading/) ให้บันทึกจากเธรดเดียว

**อะไรจะเกิดขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่ลิงก์ภายนอกเมื่อบันทึก?**

[Hyperlinks](/slides/th/net/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่ลิงก์ภายนอก (เช่นวิดีโอที่อ้างอิงแบบ relative) จะไม่ถูกคัดลอกโดยอัตโนมัติ — โปรดตรวจสอบให้แน่ใจว่าเส้นทางที่อ้างอิงยังคงเข้าถึงได้

**ฉันสามารถตั้งค่า/บันทึก metadata ของเอกสาร (Author, Title, Company, Date) ได้หรือไม่?**

ได้ คุณสมบัติมาตรฐาน [document properties](/slides/th/net/presentation-properties/) รองรับและจะถูกเขียนลงในไฟล์ขณะบันทึก