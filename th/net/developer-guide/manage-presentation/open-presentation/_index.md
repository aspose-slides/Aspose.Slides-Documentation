---
title: "เปิดงานนำเสนอใน .NET"
linktitle: "เปิดงานนำเสนอ"
type: docs
weight: 20
url: /th/net/open-presentation/
keywords:
- "เปิด PowerPoint"
- "เปิดงานนำเสนอ"
- "เปิด PPTX"
- "เปิด PPT"
- "เปิด ODP"
- "โหลดงานนำเสนอ"
- "โหลด PPTX"
- "โหลด PPT"
- "โหลด ODP"
- "งานนำเสนอที่ป้องกัน"
- "งานนำเสนอขนาดใหญ่"
- "ทรัพยากรภายนอก"
- "วัตถุไบนารี"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "เปิดงานนำเสนอ PowerPoint (.pptx, .ppt) และ OpenDocument (.odp) อย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET—รวดเร็ว เชื่อถือได้ และครบคุณสมบัติ"
---
## **บทนำ**

นอกจากการสร้างงานนำเสนอ PowerPoint ตั้งแต่ต้นแล้ว Aspose.Slides ยังอนุญาตให้คุณเปิดงานนำเสนอที่มีอยู่ได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถดึงข้อมูลเกี่ยวกับงานนำเสนอ แก้ไขเนื้อหาสไลด์ เพิ่มสไลด์ใหม่ ลบสไลด์ที่มีอยู่เดิม และอื่น ๆ อีกมาก

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) และส่งพาธของไฟล์ไปยังคอนสตรัคเตอร์ของมัน

โค้ด C# ด้านล่างแสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์ของมัน:

```cs
// สร้างอ็อบเจ็กต์ของคลาส Presentation และส่งพาธไฟล์ให้กับคอนสตรัคเตอร์ของมัน.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // พิมพ์จำนวนสไลด์ทั้งหมดในงานนำเสนอ.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **เปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

เมื่อคุณต้องการเปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน ให้ส่งรหัสผ่านผ่านคุณสมบัติ [Password](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/password/) ของคลาส [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) เพื่อถอดรหัสและโหลดงานนำเสนอ โค้ด C# ด้านล่างแสดงการดำเนินการนี้:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // ดำเนินการต่าง ๆ บนงานนำเสนอที่ถอดรหัสแล้ว.
}
```

## **เปิดงานนำเสนอขนาดใหญ่**

Aspose.Slides มีตัวเลือก—โดยเฉพาะคุณสมบัติ [BlobManagementOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/blobmanagementoptions/) ในคลาส [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/)—เพื่อช่วยคุณโหลดงานนำเสนอขนาดใหญ่

โค้ด C# ด้านล่างแสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // เลือกพฤติกรรม KeepLocked—ไฟล์งานนำเสนอจะถูกล็อกไว้ตลอดอายุของ 
        // อินสแตนซ์ Presentation แต่ไม่จำเป็นต้องโหลดเข้าสู่หน่วยความจำหรือคัดลอกไปยังไฟล์ชั่วคราว.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // งานนำเสนอขนาดใหญ่ได้ถูกโหลดและสามารถใช้งานได้ ในขณะที่การใช้หน่วยความจำน้อย

    // ทำการเปลี่ยนแปลงงานนำเสนอ
    presentation.Slides[0].Name = "Large presentation";

    // บันทึกงานนำเสนอลงไฟล์อื่น การใช้หน่วยความจำยังคงต่ำในระหว่างดำเนินการนี้
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // อย่าทำเช่นนี้! จะเกิดข้อยกเว้น I/O เนื่องจากไฟล์ยังถูกล็อกจนกว่าอ็อบเจ็กต์ Presentation จะถูกทำลาย
    File.Delete(filePath);
}

// สามารถทำได้ที่นี่ไฟล์ต้นฉบับไม่ถูกล็อกโดยอ็อบเจ็กต์ Presentation อีกต่อไป
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
เพื่อแก้ไขข้อจำกัดบางอย่างเมื่อต้องทำงานกับสตรีม Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่จากสตรีมจะทำให้ต้องคัดลอกงานนำเสนอซึ่งอาจทำให้การโหลดช้าลง ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราแนะนำอย่างยิ่งให้ใช้พาธไฟล์งานนำเสนอแทนการใช้สตรีม

เมื่อสร้างงานนำเสนอที่มีวัตถุขนาดใหญ่ (วิดีโอ, เสียง, ภาพความละเอียดสูง ฯลฯ) คุณสามารถใช้ [BLOB management](/slides/th/net/manage-blob/) เพื่อลดการใช้หน่วยความจำ
{{%/alert %}}

## **ควบคุมทรัพยากรภายนอก**

Aspose.Slides มีอินเทอร์เฟซ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/net/aspose.slides/iresourceloadingcallback/) ที่ช่วยให้คุณจัดการทรัพยากรภายนอก โค้ด C# ด้านล่างแสดงวิธีใช้อินเทอร์เฟซ `IResourceLoadingCallback`:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // โหลดภาพทดแทน.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // กำหนด URL ทดแทน.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // ข้ามภาพอื่นทั้งหมด.
        return ResourceLoadingAction.Skip;
    }
}
```

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝัง**

งานนำเสนอ PowerPoint สามารถมีประเภทของวัตถุไบนารีฝังดังต่อไปนี้:

- โครงการ VBA (เข้าถึงได้ผ่าน [IPresentation.VbaProject](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/vbaproject/));
- ข้อมูลฝังของวัตถุ OLE (เข้าถึงได้ผ่าน [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/th/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ข้อมูลไบนารีของคอนโทรล ActiveX (เข้าถึงได้ผ่าน [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/th/net/aspose.slides/icontrol/activexcontrolbinary/)).

โดยใช้คุณสมบัติ [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) คุณสามารถโหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝังใด ๆ

คุณสมบัตินี้มีประโยชน์สำหรับการลบเนื้อหาไบนารีที่อาจเป็นอันตราย โค้ด C# ด้านล่างแสดงวิธีโหลดงานนำเสนอโดยไม่มีเนื้อหาไบนารีฝัง:

```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // ดำเนินการต่าง ๆ บนงานนำเสนอ.
}
```

## **คำถามที่พบบ่อย**

**How can I tell that a file is corrupted and can’t be opened?**

คุณจะได้รับข้อยกเว้นการตรวจสอบการพาร์ส/รูปแบบระหว่างการโหลด ข้อผิดพลาดเหล่านี้มักจะระบุโครงสร้าง ZIP ที่ไม่ถูกต้องหรือบันทึก PowerPoint ที่เสีย

**What happens if required fonts are missing when opening?**

ไฟล์จะเปิดได้ แต่ภายหลังการ [rendering/export](/slides/th/net/convert-presentation/) อาจทำการทดแทนฟอนท์ [Configure font substitutions](/slides/th/net/font-substitution/) หรือ [add the required fonts](/slides/th/net/custom-font/) ให้กับสภาพแวดล้อมการทำงาน

**What about embedded media (video/audio) when opening?**

พวกมันจะพร้อมเป็นทรัพยากรของงานนำเสนอ หากมีการอ้างอิงสื่อผ่านเส้นทางภายนอก ให้ตรวจสอบว่าเส้นทางเหล่านั้นเข้าถึงได้ในสภาพแวดล้อมของคุณ มิฉะนั้นการ [rendering/export](/slides/th/net/convert-presentation/) อาจละเว้นสื่อนั้น