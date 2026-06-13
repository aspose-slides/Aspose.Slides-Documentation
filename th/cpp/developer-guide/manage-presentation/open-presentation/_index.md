---
title: เปิดงานนำเสนอใน C++
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/cpp/open-presentation/
keywords:
- เปิด PowerPoint
- เปิด OpenDocument
- เปิดงานนำเสนอ
- เปิด PPTX
- เปิด PPT
- เปิด ODP
- โหลดงานนำเสนอ
- โหลด PPTX
- โหลด PPT
- โหลด ODP
- งานนำเสนอที่มีการป้องกัน
- งานนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- ออบเจ็กต์ไบนารี
- C++
- Aspose.Slides
description: "เปิดงานนำเสนอ PowerPoint (.pptx, .ppt) และ OpenDocument (.odp) อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++—รวดเร็ว เชื่อถือได้ มีคุณสมบัติครบถ้วน."
---
## **บทนำ**

นอกเหนือจากการสร้างงานนำเสนอ PowerPoint ตั้งแต่ต้นแล้ว Aspose.Slides ยังสามารถเปิดงานนำเสนอที่มีอยู่ได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถดึงข้อมูลเกี่ยวกับงานนำเสนอนั้น, แก้ไขเนื้อหาสไลด์, เพิ่มสไลด์ใหม่, ลบสไลด์ที่มีอยู่, และอื่นๆ อีกมาก

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และส่งเส้นทางไฟล์ไปยังคอนสตรักเตอร์ของมัน

ตัวอย่าง C++ ต่อไปนี้แสดงวิธีการเปิดงานนำเสนอและรับจำนวนสไลด์ของมัน:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation และส่งเส้นทางไฟล์ไปยังคอนสตรักเตอร์ของมัน.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// พิมพ์จำนวนสไลด์ทั้งหมดในงานนำเสนอ.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **เปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

เมื่อคุณต้องการเปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน ให้ส่งรหัสผ่านผ่านเมธอด [set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) ของคลาส [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/) เพื่อถอดรหัสและโหลดงานนำเสนอ โค้ด C++ ต่อไปนี้แสดงการทำงานนี้:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// ทำการดำเนินการบนงานนำเสนอที่ถอดรหัสแล้ว.

presentation->Dispose();
```

## **เปิดงานนำเสนอขนาดใหญ่**

Aspose.Slides มีตัวเลือกโดยเฉพาะเมธอด [get_BlobManagementOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) ในคลาส [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/) เพื่อช่วยคุณโหลดงานนำเสนอที่มีขนาดใหญ่

โค้ด C++ ต่อไปนี้แสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// เลือกพฤติกรรม KeepLocked—ไฟล์งานนำเสนอจะยังคงถูกล็อคตลอดอายุการทำงานของ
// อินสแตนซ์ Presentation, แต่ไม่จำเป็นต้องโหลดเข้าสู่หน่วยความจำหรือคัดลอกไปยังไฟล์ชั่วคราว.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// งานนำเสนอขนาดใหญ่ได้ถูกโหลดแล้วและสามารถใช้ได้ในขณะที่การใช้หน่วยความจำยังคงต่ำ.

// ทำการเปลี่ยนแปลงงานนำเสนอ.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// บันทึกงานนำเสนอไปยังไฟล์อื่น การใช้หน่วยความจำยังคงต่ำในระหว่างการดำเนินการนี้.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// อย่าทำเช่นนี้! จะเกิดข้อยกเว้น I/O เนื่องจากไฟล์ถูกล็อคจนกว่าจะทำลายวัตถุ Presentation.
File::Delete(filePath);

presentation->Dispose();

// สามารถทำได้ที่นี่ไฟล์ต้นทางไม่ได้ถูกล็อคโดยวัตถุ Presentation อีกต่อไป.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
เพื่อหลีกเลี่ยงข้อจำกัดบางอย่างเมื่อทำงานกับสตรีม Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่จากสตรีมทำให้ต้องคัดลอกงานนำเสนอและอาจทำให้การโหลดช้าลง ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราแนะนำอย่างยิ่งให้ใช้เส้นทางไฟล์ของงานนำเสนอแทนการใช้สตรีม

เมื่อสร้างงานนำเสนอที่มีวัตถุขนาดใหญ่ (วิดีโอ, เสียง, ภาพความละเอียดสูง ฯลฯ) คุณสามารถใช้ [BLOB management](/slides/th/cpp/manage-blob/) เพื่อลดการใช้หน่วยความจำ
{{%/alert %}}

## **ควบคุมทรัพยากรภายนอก**

Aspose.Slides มีอินเทอร์เฟซ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/iresourceloadingcallback/) ที่ช่วยให้คุณจัดการทรัพยากรภายนอก โค้ด C++ ต่อไปนี้แสดงวิธีการใช้อินเทอร์เฟซ `IResourceLoadingCallback`:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // โหลดรูปภาพแทน.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // ตั้งค่า URL แทน.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // ข้ามรูปภาพอื่นทั้งหมด.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **โหลดงานนำเสนอโดยไม่มีออบเจ็กต์ไบนารีที่ฝังอยู่**

งานนำเสนอ PowerPoint สามารถมีออบเจ็กต์ไบนารีฝังอยู่ประเภทต่อไปนี้:

- โครงการ VBA (เข้าถึงได้ผ่าน [IPresentation::get_VbaProject](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_vbaproject/));
- ข้อมูลฝังของอ็อบเจ็กต์ OLE (เข้าถึงได้ผ่าน [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- ข้อมูลไบนารีของคอนโทรล ActiveX (เข้าถึงได้ผ่าน [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/th/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

โดยใช้เมธอด [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) คุณสามารถโหลดงานนำเสนอโดยไม่มีออบเจ็กต์ไบนารีที่ฝังอยู่เลย

เมธอดนี้มีประโยชน์สำหรับการลบเนื้อหาไบนารีที่อาจเป็นอันตราย โค้ด C++ ต่อไปนี้แสดงวิธีการโหลดงานนำเสนอโดยไม่มีเนื้อหาไบนารีที่ฝังอยู่ใดๆ:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าไฟล์เสียหายและไม่สามารถเปิดได้?**

คุณจะได้รับข้อยกเว้นการวิเคราะห์/ตรวจสอบรูปแบบระหว่างการโหลด ข้อผิดพลาดเหล่านี้มักจะระบุโครงสร้าง ZIP ที่ไม่ถูกต้องหรือเรคคอร์ด PowerPoint ที่เสียหาย

**เกิดอะไรขึ้นหากฟอนต์ที่ต้องการหายไปเมื่อเปิดไฟล์?**

ไฟล์จะเปิดได้ แต่ภายหลัง [rendering/export](/slides/th/cpp/convert-presentation/) อาจทำการแทนที่ฟอนต์ [กำหนดการแทนที่ฟอนต์](/slides/th/cpp/font-substitution/) หรือ [เพิ่มฟอนต์ที่ต้องการ](/slides/th/cpp/custom-font/) ในสภาพแวดล้อมการทำงาน

**แล้วสื่อฝัง (วิดีโอ/เสียง) เมื่อต้องเปิดเป็นอย่างไร?**

สื่อเหล่านั้นจะพร้อมใช้งานเป็นทรัพยากรของงานนำเสนอ หากสื่อถูกอ้างอิงผ่านเส้นทางภายนอก ให้ตรวจสอบว่าเส้นทางเหล่านั้นสามารถเข้าถึงได้ในสภาพแวดล้อมของคุณ มิฉะนั้น [rendering/export](/slides/th/cpp/convert-presentation/) อาจละเว้นสื่อเหล่านั้น