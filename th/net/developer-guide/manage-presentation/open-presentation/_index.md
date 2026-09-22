---
title: เปิดงานนำเสนอใน .NET
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/net/open-presentation/
keywords:
- เปิด PowerPoint
- เปิดงานนำเสนอ
- เปิด PPTX
- เปิด PPT
- เปิด ODP
- โหลดงานนำเสนอ
- โหลด PPTX
- โหลด PPT
- โหลด ODP
- งานนำเสนอที่ป้องกัน
- งานนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- วัตถุไบนารี
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ด้วย C#, รองรับรหัสผ่านการเปิด, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ .NET."
---
## **บทนำ**

[Aspose.Slides for .NET](https://products.aspose.com/slides/th/net/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกเป็นรูปแบบต้นฉบับหรือรูปแบบที่รองรับอื่นๆ

พฤติกรรมการโหลดสามารถกำหนดค่าได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านสำหรับการเปิด, เก็บวัตถุไบนารีขนาดใหญ่ให้อยู่นอกหน่วยความจำที่จัดการ, ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบนารีที่ฝังอยู่

## **เปิดงานนำเสนอ**

หลังจากโหลดไฟล์หรือสตรีมแล้ว คุณสามารถ [กำหนดรูปแบบงานนำเสนอเดิม](/slides/th/net/detect-presentation-source-format/) เพื่อเลือกวิธีที่แอปพลิเคชันของคุณจะประมวลผล

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งเส้นทางไฟล์ไปยังคอนสตรักเตอร์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) ปล่อยงานนำเสนอหลังการใช้เพื่อให้ตัวจัดการไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่น ๆ ถูกปล่อยออกอย่างรวดเร็ว

ตัวอย่าง C# ด้านล่างแสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **เปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

รหัสผ่านสำหรับการเปิดจะเข้ารหัสเนื้อหาของงานนำเสนอ เพื่อโหลดงานนำเสนอทั้งหมด ให้กำหนดรหัสผ่านที่ถูกต้องให้กับ [LoadOptions.Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/) และส่งตัวเลือกเหล่านั้นไปยังคอนสตรักเตอร์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) การโหลดจะล้มเหลวเมื่อรหัสผ่านขาดหายหรือไม่ถูกต้อง

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypte

d-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระแสงานการเข้ารหัส ดูที่ [Password-Protect Presentations](/slides/th/net/password-protected-presentation/). หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยเจตนาพร้อมคุณสมบัติเอกสารสาธารณะ คุณสมบัตินั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/net/presentation-properties/).

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/blobmanagementoptions/) ควบคุมวิธีที่ Aspose.Slides จัดการวัตถุไบนารีขนาดใหญ่ เช่น รูปภาพ, เสียง, และวีดีโอ คุณสามารถทำให้ไฟล์ต้นทางล็อกไว้, อนุญาตไฟล์ชั่วคราว, และจำกัดจำนวนข้อมูล BLOB ที่เก็บในหน่วยความจำ

โค้ด C# ด้านล่างแสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

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

{{% alert color="info" title="Note" %}}
เมื่อใช้ `PresentationLockingBehavior.KeepLocked` ไฟล์ต้นทางจะถูกล็อกไว้จนกว่าอ็อบเจกต์ `Presentation` จะถูกปล่อย อย่าย้าย, เขียนทับหรือทำลายไฟล์ต้นทางในขณะที่อ็อบเจกต์นั้นยังคงอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตระหว่างการโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้เส้นทางไฟล์จึงโดยทั่วไปมีประสิทธิภาพมากกว่าสตรีม โปรดดูที่ [Manage BLOBs](/slides/th/net/manage-blob/) สำหรับตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม.
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/resourceloadingcallback/) ยอมรับการทำงานของ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/net/aspose.slides/iresourceloadingcallback/) คอลแบ็กสามารถให้ข้อมูลทดแทน, เปลี่ยนเส้นทางทรัพยากร, ใช้โหลดเดฟอลต์, หรือข้ามทรัพยากรได้ สิ่งนี้มีประโยชน์เมื่องานนำเสนอมีรูปภาพภายนอกที่ต้องถูกแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

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

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝังอยู่**

งานนำเสนออาจมีข้อมูลไบนารีฝังอยู่ที่แอปพลิเคชันไม่ต้องการหรือไม่ต้องการเก็บ ตัวอย่างเช่น:

- โครงการ VBA, เข้าถึงได้ผ่าน [IPresentation.VbaProject](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/vbaproject/);
- ข้อมูล OLE ที่ฝังอยู่, เข้าถึงได้ผ่าน [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/th/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- ข้อมูลคอนโทรล ActiveX, เข้าถึงได้ผ่าน [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/th/net/aspose.slides/icontrol/activexcontrolbinary/).

ตั้งค่า [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) เป็น `true` เพื่อลบข้อมูลไบนารีนี้ขณะโหลด บันทึกรายการงานนำเสนอที่โหลดแล้วเพื่อให้ผลลัพธ์ที่ผ่านการทำความสะอาดคงอยู่

ตัวเลือกนี้ช่วยลดการเปิดเผยต่อข้อมูลฝังที่ไม่ต้องการ แต่ไม่ได้เป็นระบบตรวจจับมัลแวร์หรือการทำความสะอาดเนื้อหาอย่างสมบูรณ์

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

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียและไม่สามารถเปิดได้?**

Aspose.Slides จะโยนข้อยกเว้นการพาร์เซหรือรูปแบบระหว่างการโหลด ให้จัดการความล้มเหลวนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนต์ที่จำเป็นหายไป?**

งานนำเสนอยังสามารถโหลดได้ แต่การเรนเดอร์และการส่งออกอาจใช้ฟอนต์ทดแทน คุณสามารถ [configure font substitution](/slides/th/net/font-substitution/) หรือ [provide custom fonts](/slides/th/net/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอนั้นโหลดสื่อที่ฝังไว้ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังอยู่จะสามารถเข้าถึงได้ผ่านโมเดลอ็อบเจกต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนดไว้และอาจไม่พร้อมใช้งานหากไม่สามารถเข้าถึงตำแหน่งของมันได้