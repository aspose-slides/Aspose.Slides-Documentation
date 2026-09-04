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
- งานนำเสนอที่ป้องกัน
- งานนำเสนอขนาดใหญ่
- แหล่งข้อมูลภายนอก
- วัตถุไบนารี
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ใน C++, จัดหารหัสผ่านเปิดไฟล์, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides for C++."
---
## **คำนำ**

[Aspose.Slides for C++](https://products.aspose.com/slides/th/cpp/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบที่สนับสนุนอื่นได้

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านเปิดไฟล์ เก็บวัตถุไบนารีขนาดใหญ่ให้อยู่เหนือหน่วยความจำ ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบนารีที่ฝังอยู่

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) แล้วทำการ Dispose งานนำเสนอหลังการใช้งานเพื่อให้ตัวจัดการไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่น ๆ ถูกปล่อยโดยเร็ว

ตัวอย่าง C++ ด้านล่างแสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **เปิดงานนำเสนอที่มีรหัสผ่านป้องกัน**

รหัสผ่านเปิดไฟล์จะเข้ารหัสเนื้อหาของงานนำเสนอ เพื่อโหลดงานนำเสนอเต็มรูปแบบ ให้ส่งรหัสผ่านที่ถูกต้องไปยังเมธอด [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) แล้วส่งออปชันเหล่านั้นไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) การโหลดจะล้มเหลือเมื่อรหัสผ่านหายไปหรือไม่ถูกต้อง

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส ดูที่ [Password-Protect Presentations](/slides/th/cpp/password-protected-presentation/) หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยเจตนาพร้อมกับคุณสมบัติเ�เอกสารสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/cpp/presentation-properties/)

## **เปิดงานนำเสนอขนาดใหญ่**

เมธอด [LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) ควบคุมวิธีที่ Aspose.Slides จัดการวัตถุไบนารีขนาดใหญ่ เช่น รูปภาพ เสียง และวิดีโอ คุณสามารถทำให้ไฟล์ต้นทางล็อกอยู่, อนุญาตไฟล์ชั่วคราว, และจำกัดปริมาณข้อมูล BLOB ที่เก็บไว้ในหน่วยความจำ

โค้ด C++ ด้านล่างแสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
ด้วย `PresentationLockingBehavior::KeepLocked` ไฟล์ต้นทางจะยังคงล็อกอยู่จนกว่าอ็อบเจกต์ `Presentation` จะถูก Dispose อย่าย้าย เขียนทับ หรือ ลบไฟล์ต้นทางขณะอ็อบเจกต์นั้นยังมีชีวิตอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตขณะโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงมักมีประสิทธิภาพกว่าสตรีม ดูที่ [Manage BLOBs](/slides/th/cpp/manage-blob/) เพื่อเรียนรู้ตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

เมธอด [LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) รับการทำงานของอินเทอร์เฟซ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/iresourceloadingcallback/) คอลแบ็กสามารถให้ข้อมูลทดแทน, เปลี่ยนเส้นทางทรัพยากร, ใช้ตัวโหลดเริ่มต้น, หรือข้ามทรัพยากรได้ สิ่งนี้มีประโยชน์เมื่องานนำเสนอมีรูปภาพภายนอกที่ต้องแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝังอยู่**

งานนำเสนออาจมีข้อมูลไบนารีฝังอยู่ที่แอปพลิเคชันไม่ต้องการหรือไม่ต้องการเก็บ ตัวอย่างได้แก่:

- โครงการ VBA ที่เข้าถึงได้ผ่าน [IPresentation::get_VbaProject](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_vbaproject/)
- ข้อมูล OLE ฝังอยู่ที่เข้าถึงได้ผ่าน [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/)
- ข้อมูลคอนโทรล ActiveX ที่เข้าถึงได้ผ่าน [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/th/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)

ตั้งค่า `true` ให้กับเมธอด [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) เพื่อให้ลบข้อมูลไบนารีเหล่านี้ขณะโหลด แล้วบันทึกงานนำเสนอที่โหลดแล้วเพื่อให้ผลลัพธ์ที่ทำความสะอาด

ตัวเลือกนี้ช่วยลดความเสี่ยงจากโค้ดที่ฝังอยู่โดยไม่ได้ตั้งใจ แต่ไม่ได้เป็นระบบตรวจจับมัลแวร์หรือทำความสะอาดเนื้อหาอย่างสมบูรณ์

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียและไม่สามารถเปิดได้?**

Aspose.Slides จะโยนข้อยกเว้นการพาร์สหรือรูปแบบขณะโหลด ให้จัดการความล้มเหลวนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้องเพื่อให้แอปพลิเคชันรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนต์ที่ต้องการหายไป?**

งานนำเสนอยังคงสามารถโหลดได้ แต่การเรนเดอร์และการส่งออกอาจแทนที่ฟอนต์ คุณสามารถ [configure font substitution](/slides/th/cpp/font-substitution/) หรือ [provide custom fonts](/slides/th/cpp/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอมาพร้อมกับสื่อฝังอยู่หรือไม่?**

สื่อเสียงและวิดีโอที่ฝังอยู่จะพร้อมใช้งานผ่านโมเดลอ็อบเจกต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนดค่าไว้และอาจไม่สามารถเข้าถึงได้หากตำแหน่งของมันไม่สามารถเข้าถึงได้.