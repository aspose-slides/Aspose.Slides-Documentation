---
title: เปิดการนำเสนอใน C++
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
- ทรัพยากรภายนอก
- อ็อบเจกต์ไบเนอรี
- C++
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ใน C++, จัดหา รหัสผ่านเปิดไฟล์, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ C++."
---
## **แนะนำ**

[Aspose.Slides for C++](https://products.aspose.com/slides/th/cpp/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกเป็นรูปแบบเดิมหรือรูปแบบที่รองรับอื่นได้

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถกำหนดรหัสผ่านเปิดไฟล์ เก็บออบเจกต์ไบเนอรีขนาดใหญ่ให้นอกหน่วยความจำ ควบคุมทรัพยากรภายนอก หรือเว้นข้อมูลไบเนอรีฝัง

## **เปิดการนำเสนอ**

หลังจากโหลดไฟล์หรือสตรีมแล้ว คุณสามารถ [determine its original presentation format](/slides/th/cpp/detect-presentation-source-format/) เพื่อเลือกวิธีที่แอปพลิเคชันของคุณจะประมวลผล

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรักเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ปล่อยวัตถุ Presentation หลังการใช้เพื่อให้ตัวจัดการไฟล์และทรัพยากรอื่น ๆ ถูกปล่อยอย่างทันท่วงที

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

## **เปิดงานนำเสนอที่มีรหัสผ่าน**

รหัสผ่านเปิดไฟล์จะทำให้เนื้อหาการนำเสนอถูกเข้ารหัส เพื่อโหลดงานนำเสนอเต็มรูปแบบ ให้ส่งรหัสผ่านที่ถูกต้องไปที่ [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) แล้วส่งตัวเลือกเหล่านั้นไปที่คอนสตรักเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) การโหลดจะล้มเหลือเมื่อไม่มีรหัสผ่านหรือรหัสผ่านไม่ถูกต้อง

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

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส ดูที่ [Password-Protect Presentations](/slides/th/cpp/password-protected-presentation/) หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยเจตนาให้มีคุณสมบัติเ�เอกสารสาธารณะ คุณสมบัตินั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/cpp/presentation-properties/)

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) ควบคุมวิธีที่ Aspose.Slides จัดการออบเจกต์ไบเนอรีขนาดใหญ่ เช่น ภาพ เสียง และวิดีโอ คุณสามารถล็อกไฟล์ต้นทาง อนุญาตให้สร้างไฟล์ชั่วคราว และจำกัดปริมาณข้อมูล BLOB ที่เก็บในหน่วยความจำได้

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

ด้วย `PresentationLockingBehavior::KeepLocked` ไฟล์ต้นทางจะยังคงถูกล็อกจนกว่าอ็อบเจกต์ `Presentation` จะถูกปล่อย อย่าย้าย เขียนทับ หรือทำลายไฟล์ต้นทางในขณะที่อ็อบเจกต์นั้นยังอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตขณะโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงมักมีประสิทธิภาพมากกว่าสตรีม ดูที่ [Manage BLOBs](/slides/th/cpp/manage-blob/) สำหรับตัวเลือกการจัดเก็บและจัดการหน่วยความจำเพิ่มเติม

{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) รับการทำงานของ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/iresourceloadingcallback/) คอลแบ็กสามารถให้ข้อมูลทดแทน เปลี่ยนเส้นทางทรัพยากร ใช้ตัวโหลดค่าเริ่มต้น หรือข้ามทรัพยากรได้ สิ่งนี้มีประโยชน์เมื่อการนำเสนอมีภาพภายนอกที่ต้องแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

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

## **โหลดการนำเสนอโดยไม่มีวัตถุไบเนอรีฝังแน่น**

งานนำเสนออาจมีข้อมูลไบเนอรีฝังที่แอปพลิเคชันไม่จำเป็นต้องใช้หรือไม่ต้องการเก็บ ตัวอย่างเช่น

- โครงการ VBA ที่เข้าถึงได้ผ่าน [IPresentation::get_VbaProject](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_vbaproject/)
- ข้อมูล OLE ฝังที่เข้าถึงได้ผ่าน [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/)
- ข้อมูลคอนโทรล ActiveX ที่เข้าถึงได้ผ่าน [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/th/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)

ตั้งค่า `true` ให้กับ [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) เพื่อลบข้อมูลไบเนอรีนี้ขณะโหลด แล้วบันทึกงานนำเสนอที่โหลดแล้วเพื่อเก็บผลลัพธ์ที่ผ่านการทำความสะอาด

ตัวเลือกนี้ช่วยลดความเสี่ยงจากข้อมูลฝังที่ไม่ต้องการ แต่ไม่ใช่ระบบตรวจจับมัลแวร์หรือทำความสะอาดเนื้อหาอย่างครบถ้วน

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

**ฉันจะทราบได้อย่างไรว่าไฟล์เสียหายและไม่สามารถเปิดได้?**

Aspose.Slides จะโยนข้อยกเว้นการพาร์เซหรือรูปแบบในระหว่างการโหลด ให้จัดการข้อผิดพลาดนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนต์ที่ต้องการหายไป?**

งานนำเสนอยังคงโหลดได้ แต่การเรนเดอร์และการส่งออกอาจแทนที่ฟอนต์ คุณสามารถ [configure font substitution](/slides/th/cpp/font-substitution/) หรือ [provide custom fonts](/slides/th/cpp/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอจะโหลดสื่อฝังอยู่ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังจะพร้อมใช้งานผ่านโมเดลอ็อบเจกต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนดและอาจไม่สามารถเข้าถึงได้หากตำแหน่งของมันไม่สามารถเชื่อมต่อได้