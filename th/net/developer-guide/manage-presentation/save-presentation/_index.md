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
description: "ค้นพบวิธีบันทึกงานนำเสนอใน .NET ด้วย Aspose.Slides—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมรักษาเค้าโครง, ฟอนต์ และเอฟเฟกต์ไว้."
---
## **ภาพรวม**

[Open Presentations in C#](/slides/th/net/open-presentation/) อธิบายวิธีการใช้คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) มีเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำตั้งแต่ต้นหรือแก้ไขงานที่มีอยู่ คุณจะต้องบันทึกเมื่อทำเสร็จ ด้วย Aspose.Slides สำหรับ .NET คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกงานนำเสนอ

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอเป็นไฟล์โดยเรียกเมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกให้เมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // ทำงานบางอย่างที่นี่...

    // บันทึกงานนำเสนอเป็นไฟล์.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมได้โดยส่งสตรีมผลลัพธ์ไปยังเมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) งานนำเสนอสามารถเขียนไปยังสตรีมหลายประเภท ในตัวอย่างด้านล่าง เราสร้างงานนำเสนอใหม่และบันทึกเป็นสตรีมไฟล์

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // บันทึกงานนำเสนอลงสตรีม.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **บันทึกงานนำเสนอด้วยประเภทการแสดงผลที่กำหนดล่วงหน้า**

Aspose.Slides ให้คุณกำหนดมุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/) ตั้งค่าคุณสมบัติ [LastView](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/lastview/) เป็นค่าจากการนับจำนวน [ViewType](https://reference.aspose.com/slides/th/net/aspose.slides/viewtype/)

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pptxoptions/) และตั้งค่าคุณสมบัติ conformance ขณะบันทึก หากคุณตั้งค่า `Conformance.Iso29500_2008_Strict` ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML  
ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกเป็นรูปแบบ Strict Office Open XML

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation())
{
    // บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ด้วยโหมด Zip64**

ไฟล์ Office Open XML คือไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดที่ไม่บีบอัดของไฟล์ใดไฟล์หนึ่ง ขนาดที่บีบอัดของไฟล์ใดไฟล์หนึ่ง และขนาดรวมของไฟล์บีบอัดทั้งหมด รวมถึงจำกัดจำนวนไฟล์ในอาร์ไคฟ์ไว้ที่ 65,535 (2^16‑1) ไฟล์ การขยายรูปแบบ ZIP64 เพิ่มขีดจำกัดเหล่านี้เป็น 2^64  
คุณสมบัติ [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipptxoptions/zip64mode/) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML หรือไม่  
คุณสมบัตินี้ให้โหมดต่อไปนี้:

- ``IfNecessary`` ใช้ส่วนขยายรูปแบบ ZIP64 เฉพาะเมื่อการนำเสนอเกินขีดจำกัดที่กล่าวไว้ นี่คือโหมดค่าเริ่มต้น
- ``Never`` ไม่เคยใช้ส่วนขยายรูปแบบ ZIP64
- ``Always`` ใช้ส่วนขยายรูปแบบ ZIP64 เสมอ  

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX โดยเปิดใช้งานส่วนขยายรูปแบบ ZIP64

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
เมื่อคุณบันทึกด้วย `Zip64Mode.Never` จะเกิด [PptxException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxexception/) หากไม่สามารถบันทึกงานนำเสนอในรูปแบบ ZIP32
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

เมื่อทำงานกับงานนำเสน ขนาดใหญ่ คุณสามารถปรับระดับการบีบอัดเพื่อสมดุลระหว่างขนาดไฟล์และเวลาในการประมวลผล ตามความต้องการของคุณอาจต้องการการประมวลผลที่เร็วหรือไฟล์ผลลัพธ์ขนาดเล็กกว่า  
Aspose.Slides มีคุณสมบัติ [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipptxoptions/compressionlevel/) ที่ให้คุณระบุระดับการบีบอัดที่ใช้เมื่อบันทึกงานนำเสนอในรูปแบบ Office Open XML  

ระดับการบีบอัดที่มีให้เลือกมีดังนี้:

- **None**: ไม่มีการบีบอัด ไฟล์จะถูกเก็บไว้โดยไม่มีการเปลี่ยนแปลง
- **Level1**: การบีบอัดที่เร็วที่สุดด้วยอัตราการบีบอัดต่ำสุด
- **Level2**: การบีบอัดที่เร็วกว่าโดยมีอัตราการบีบอัดที่ดีกว่าเล็กน้อยเมื่อเทียบกับ **Level1**
- **Level3**: ให้การบีบอัดที่ดีกว่า **Level2** โดยมีผลกระทบต่อเวลาในการประมวลผลระดับปานกลาง
- **Level4**: ให้การบีบอัดที่ดีกว่า **Level3**
- **Level5**: ให้การบีบอัดที่ดีขึ้นเมื่อเทียบกับ **Level4** พร้อมเวลาการประมวลผลเพิ่มเติม
- **Level6**: การบีบอัดมาตรฐานที่ให้สมดุลที่ดีระหว่างความเร็วในการประมวลผลและขนาดไฟล์ นี่คือ *ระดับการบีบอัดเริ่มต้น*
- **Level7**: ให้การบีบอัดที่ดีกว่า **Level6** โดยมีการประมวลผลที่ช้าลง
- **Level8**: ให้การบีบอัดที่ดีกว่า **Level7**
- **Level9**: การบีบอัดสูงสุด ผลลัพธ์เป็นไฟล์ที่มีขนาดเล็กที่สุดแต่ใช้เวลาการประมวลผลนานที่สุด  

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX *โดยไม่มีการบีบอัด*:

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

ตัวอย่างนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX พร้อม *การบีบอัดสูงสุด*:

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **บันทึกงานนำเสนอโดยไม่ทำการรีเฟรชภาพย่อ**

คุณสมบัติ [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) ควบคุมการสร้างภาพย่อเมื่อบันทึกงานนำเสนอเป็น PPTX:

- หากตั้งค่าเป็น `true` ภาพย่อจะถูกรีเฟรชระหว่างการบันทึก นี่คือค่าเริ่มต้น
- หากตั้งค่าเป็น `false` ภาพย่อปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีภาพย่อ จะไม่มีการสร้างภาพย่อ  

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
ตัวเลือกนี้ช่วยลดเวลาที่ใช้ในการบันทึกงานนำเสนอในรูปแบบ PPTX
{{% /alert %}}

## **บันทึกการอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

[IProgressCallback](https://reference.aspose.com/slides/th/net/aspose.slides/iprogresscallback/) อินเทอร์เฟซถูกใช้ผ่านคุณสมบัติ `ProgressCallback` ที่เปิดเผยโดยอินเทอร์เฟซ [ISaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/isaveoptions/) และคลาสเชิงนามธรรม [SaveOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/) กำหนดการทำงานของ [IProgressCallback](https://reference.aspose.com/slides/th/net/aspose.slides/iprogresscallback/) ให้กับ `ProgressCallback` เพื่อรับการอัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์  

โค้ดสแน็ปเพจต่อไปนี้แสดงวิธีใช้ `IProgressCallback`:

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
Aspose ได้พัฒนาแอป [PowerPoint Splitter ฟรี](https://products.aspose.app/slides/th/splitter) ด้วย API ของตนเอง แอปนี้ช่วยให้คุณแยกงานนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**สนับสนุนการบันทึกแบบ "fast save" (การบันทึกแบบเพิ่มส่วน) ที่เขียนเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่ การบันทึกสร้างไฟล์เป้าหมายเต็มรูปแบบทุกครั้ง; การบันทึกแบบเพิ่มส่วน "fast save" ไม่ได้รับการสนับสนุน  

**สามารถบันทึกอินสแตนซ์ Presentation เดียวจากหลายเธรดได้อย่างปลอดภัยหรือไม่?**

ไม่ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) [isn’t thread-safe](/slides/th/net/multithreading/); บันทึกจากเธรดเดียว  

**เกิดอะไรขึ้นกับไฮเพอร์ลิงก์และไฟล์ที่ลิงก์ภายนอกเมื่อบันทึก?**

[Hyperlinks](/slides/th/net/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่ลิงก์ภายนอก (เช่น วิดีโอที่อ้างอิงด้วยเส้นทางสัมพันธ์) จะไม่ถูกคัดลอกโดยอัตโนมัติ — โปรดตรวจสอบว่าเส้นทางที่อ้างอิงยังคงเข้าถึงได้  

**ฉันสามารถตั้ง/บันทึกเมตาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ใช่ คุณสมบัติมาตรฐานของ [document properties](/slides/th/net/presentation-properties/) ได้รับการสนับสนุนและจะถูกเขียนลงในไฟล์เมื่อบันทึก