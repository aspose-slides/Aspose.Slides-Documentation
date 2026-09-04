---
title: "เปิดการนำเสนอใน .NET"
linktitle: "เปิดการนำเสนอ"
type: docs
weight: 20
url: /th/net/open-presentation/
keywords:
- "เปิด PowerPoint"
- "เปิดการนำเสนอ"
- "เปิด PPTX"
- "เปิด PPT"
- "เปิด ODP"
- "โหลดการนำเสนอ"
- "โหลด PPTX"
- "โหลด PPT"
- "โหลด ODP"
- "การนำเสนอที่ป้องกัน"
- "การนำเสนอขนาดใหญ่"
- "ทรัพยากรภายนอก"
- "วัตถุไบต์"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "เรียนรู้วิธีเปิดการนำเสนอ PowerPoint และ OpenDocument ด้วย C#, จัดหารหัสผ่านสำหรับการเปิด, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ .NET."
---
## **คำนำ**

[Aspose.Slides for .NET](https://products.aspose.com/slides/th/net/) สามารถโหลดการนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดการนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบที่รองรับอื่นได้

พฤติกรรมในการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านสำหรับการเปิด เก็บวัตถุไบต์ขนาดใหญ่ไอยู่ด้านนอกหน่วยความจำที่จัดการ ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบต์ที่ฝังไว้

## **เปิดการนำเสนอ**

เพื่อเปิดการนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ปิดการใช้งานการนำเสนอหลังจากใช้เพื่อให้มั่นใจว่าตัวจัดการไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่น ๆ ถูกปล่อยออกโดยเร็ว

ตัวอย่าง C# ด้านล่างแสดงวิธีเปิดการนำเสนอและรับจำนวนสไลด์ของมัน:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **เปิดการนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

รหัสผ่านเปิดทำให้เนื้อหาการนำเสนอถูกเข้ารหัส เพื่อโหลดการนำเสนอเต็มรูปแบบ ให้กำหนดรหัสผ่านที่ถูกต้องให้กับ [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/) แล้วส่งตัวเลือกเหล่านั้นไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) การโหลดจะล้มเหลือเมื่อไม่มีรหัสผ่านหรือรหัสผ่านไม่ถูกต้อง

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส ดูที่ [การป้องกันรหัสผ่านของการนำเสนอ](/slides/th/net/password-protected-presentation/) หากการนำเสนอที่เข้ารหัสถูกบันทึกโดยเจตนาพร้อมคุณสมบัติเ�เอกสารสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [จัดการคุณสมบัติการนำเสนอ](/slides/th/net/presentation-properties/)

## **เปิดการนำเสนอขนาดใหญ่**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/blobmanagementoptions/) ควบคุมวิธีการที่ Aspose.Slides จัดการวัตถุไบต์ขนาดใหญ่ เช่น รูปภาพ เสียง และวิดีโอ คุณสามารถล็อกไฟล์ต้นทางไว้ อนุญาตให้สร้างไฟล์ชั่วคราว และจำกัดจำนวนข้อมูล BLOB ที่เก็บในหน่วยความจำ

โค้ด C# ด้านล่างแสดงการโหลดการนำเสนอขนาดใหญ่ (เช่น 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="หมายเหตุ" %}}
ด้วย `PresentationLockingBehavior.KeepLocked` ไฟล์ต้นทางจะคงล็อกไว้จนกว่าอ็อบเจ็กต์ `Presentation` จะถูกปิด อย่าเคลื่อนย้าย เขียนทับ หรือทำลายไฟล์ต้นทางขณะอ็อบเจ็กต์นั้นยังคงอยู่

Aspose.Slides อาจทำสำเนาข้อมูลจากสตรีมอินพุตขณะโหลด สำหรับการนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงโดยทั่วไปมีประสิทธิภาพมากกว่าสตรีม ดูที่ [จัดการ BLOBs](/slides/th/net/manage-blob/) เพื่อเรียนรู้ตัวเลือกเพิ่มเติมเกี่ยวกับการจัดเก็บและการจัดการหน่วยความจำ
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/resourceloadingcallback/) รับการนำไปใช้ของ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/net/aspose.slides/iresourceloadingcallback/) คอลแบ็กนี้สามารถให้ข้อมูลแทนที่ ทำการเปลี่ยนเส้นทางของทรัพยากร ใช้โหลดเดฟอลท์ หรือข้ามทรัพยากร การทำเช่นนี้มีประโยชน์เมื่อการนำเสนอมีรูปภาพภายนอกที่ต้องแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **โหลดการนำเสนอโดยไม่มีวัตถุไบต์แบบฝัง**

การนำเสนออาจมีข้อมูลไบต์แบบฝังที่แอปพลิเคชันไม่ต้องการหรือไม่ต้องการเก็บ ตัวอย่างเช่น:

- โปรเจกต์ VBA ที่เข้าถึงได้ผ่าน [IPresentation.VbaProject](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/vbaproject/)
- ข้อมูล OLE ที่ฝังอยู่ที่เข้าถึงได้ผ่าน [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/th/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/)
- ข้อมูลคอนโทรล ActiveX ที่เข้าถึงได้ผ่าน [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/th/net/aspose.slides/icontrol/activexcontrolbinary/)

ตั้งค่า [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) เป็น `true` เพื่อเอาข้อมูลไบต์เหล่านี้ออกขณะโหลด บันทึกการนำเสนอที่โหลดแล้วเพื่อให้ผลลัพธ์ที่ทำความสะอาดคงอยู่

ตัวเลือกนี้ลดความเสี่ยงจากการฝังโค้ดที่ไม่ต้องการ แต่ไม่ได้เป็นระบบตรวจจับมัลแวร์หรือทำความสะอาดเนื้อหาอย่างสมบูรณ์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียหายและไม่สามารถเปิดได้?**  
Aspose.Slides จะโยนข้อยกเว้นการพาร์สหรือรูปแบบในระหว่างการโหลด ให้จัดการความล้มเหลือนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้องเพื่อให้แอปพลิเคชันรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนต์ที่จำเป็นหายไป?**  
การนำเสนอยังคงโหลดได้ แต่การเรนเดอร์และการส่งออกอาจแทนที่ฟอนต์ได้ คุณสามารถ [กำหนดค่าการแทนที่ฟอนต์](/slides/th/net/font-substitution/) หรือ [จัดหา ฟอนต์แบบกำหนดเอง](/slides/th/net/custom-font/) เพื่อทำให้ผลลัพธ์คาดการณ์ได้มากขึ้น

**การโหลดการนำเสนอจะโหลดสื่อที่ฝังอยู่ด้วยหรือไม่?**  
เสียงและวิดีโอที่ฝังไว้จะพร้อมใช้ผ่านโมเดลอ็อบเจ็กต์ของการนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนดไว้และอาจไม่พร้อมใช้งานหากไม่สามารถเข้าถึงตำแหน่งที่ตั้งของมันได้