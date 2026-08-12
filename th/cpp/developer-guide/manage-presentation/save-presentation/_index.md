---
title: บันทึกงานนำเสนอใน C++
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/cpp/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำสินค้าเป็นสตรีม
- ชนิดมุมมองที่กำหนดไว้ล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชรูปย่อ
- ความคืบหน้าการบันทึก
- C++
- Aspose.Slides
description: "ค้นพบวิธีการบันทึกงานนำเสนอใน C++ ด้วย Aspose.Slides—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงเลย์เอาต์ ฟอนต์และเอฟเฟกต์."
---
## **ภาพรวม**

[Open Presentations in C++](/slides/th/cpp/open-presentation/) อธิบายวิธีการใช้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เพื่อเปิดไฟล์งานนำเสนอ บทความนี้จะอธิบายวิธีการสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) จัดเก็บเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำเสนอจากศูนย์หรือแก้ไขงานที่มีอยู่แล้ว คุณก็ต้องการบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides for C++ คุณสามารถบันทึกเป็น **file** หรือ **stream** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกงานนำเสนอ

## **บันทึกงานนำเสนอเป็นไฟล์**

ใช้เมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เพื่อบันทึกงานนำเสนอเป็นไฟล์ โดยส่งชื่อไฟล์และรูปแบบการบันทึกให้เมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// ทำงานบางอย่างที่นี่...
// บันทึกงานนำเสนอลงไฟล์.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมได้โดยส่งสตรีมออกไปยังเมธอด `Save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) งานนำเสนอสามารถเขียนลงสตรีมประเภทต่าง ๆ ได้ ในตัวอย่างด้านล่าง เราสร้างงานนำเสนอใหม่และบันทึกลงไฟล์สตรีม

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// บันทึกงานนำเสนอลงสตรีม.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **บันทึกงานนำเสนอพร้อมกำหนดมุมมองเริ่มต้น**

Aspose.Slides ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint จะใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/) ใช้เมธอด [set_LastView](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/set_lastview/) พร้อมค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewtype/)

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/) และตั้งค่าคุณสมบัติ conformance เมื่อต้องการบันทึก หากคุณตั้งค่า `Conformance.Iso29500_2008_Strict` ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างต่อไปนี้สร้างงานนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>();

// บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML แบบ Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดที่ไม่ได้บีบอัดของไฟล์ใดไฟล์หนึ่ง ขนาดบีบอัดของไฟล์ใดไฟล์หนึ่ง และขนาดรวมของอาร์ไชน์ รวมถึงจำกัดจำนวนไฟล์สูงสุดที่ 65 535 (2^16‑1) รูปแบบส่วนขยาย Zip64 จะเพิ่มขีดจำกัดเหล่านี้เป็น 2^64

เมธอด [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) ให้คุณเลือกใช้ส่วนขยายรูปแบบ Zip64 เมื่อบันทึกไฟล์ Office Open XML

เมธอดนี้สามารถใช้ได้กับโหมดต่อไปนี้:

- `IfNecessary` ใช้ส่วนขยาย Zip64 เฉพาะเมื่อขนาดงานนำเสนอเกินขีดจำกัดด้านบน นี่คือค่าเริ่มต้น
- `Never` ไม่ใช้ส่วนขยาย Zip64 เลย
- `Always` ใช้ส่วนขยาย Zip64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX พร้อมเปิดใช้งานส่วนขยาย Zip64

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="หมายเหตุ" color="warning" %}}

เมื่อบันทึกด้วย `Zip64Mode.Never` จะเกิด [PptxException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxexception/) หากงานนำเสนอไม่สามารถบันทึกในรูปแบบ ZIP32 ได้

{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

เมื่อต้องจัดการกับงานนำเสนอขนาดใหญ่ คุณสามารถปรับระดับการบีบอัดเพื่อสมดุลระหว่างขนาดไฟล์และเวลาการประมวลผล ตามความต้องการของคุณ คุณอาจเลือกประมวลผลที่เร็วขึ้นหรือไฟล์ผลลัพธ์ที่เล็กลง

Aspose.Slides มีเมธอด [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) ที่อนุญาตให้คุณกำหนดระดับการบีบอัดเมื่อบันทึกงานนำเสนอในรูปแบบ Office Open XML

ระดับการบีบอัดที่มีให้เลือกมีดังนี้:

- **None**: ไม่บีบอัด ไฟล์จะถูกเก็บไว้ตามต้นฉบับ
- **Level1**: การบีบอัดที่เร็วที่สุดโดยอัตราการบีบอัดต่ำสุด
- **Level2**: การบีบอัดที่เร็วกว่าและอัตราการบีบอัดดีขึ้นเล็กน้อยเมื่อเทียบกับ **Level1**
- **Level3**: ให้การบีบอัดที่ดีกว่า **Level2** โดยมีผลกระทบต่อเวลาประมวลผลระดับปานกลาง
- **Level4**: ให้การบีบอัดที่ดีกว่า **Level3**
- **Level5**: ปรับปรุงการบีบอัดเหนือ **Level4** พร้อมเพิ่มเวลาประมวลผล
- **Level6**: การบีบอัดมาตรฐานที่ให้สมดุลที่ดีระหว่างความเร็วและขนาดไฟล์ ซึ่งเป็น *ระดับการบีบอัดเริ่มต้น*
- **Level7**: ให้การบีบอัดที่ดีกว่า **Level6** แต่การประมวลผลช้าลง
- **Level8**: ให้การบีบอัดที่ดีกว่า **Level7**
- **Level9**: การบีบอัดสูงสุด ผลลัพธ์ไฟล์จะมีขนาดเล็กที่สุดแต่ต้องใช้เวลาประมวลผลนานที่สุด

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX *โดยไม่มีการบีบอัด*

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

ตัวอย่างนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX *ด้วยการบีบอัดสูงสุด*

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **บันทึกงานนำเสนอโดยไม่รีเฟรชรูปย่อ**

เมธอด [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) ควบคุมการสร้างรูปย่อเมื่อบันทึกงานนำเสนอเป็น PPTX:

- หากตั้งค่าเป็น `true` รูปย่อจะถูกรีเฟรชระหว่างการบันทึก (ค่าเริ่มต้น)
- หากตั้งค่าเป็น `false` รูปย่อปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีรูปย่อ จะไม่สร้างรูปย่อใหม่

โค้ดด้านล่างบันทึกงานนำเสนอเป็น PPTX โดยไม่รีเฟรชรูปย่อ

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="ข้อมูล" color="info" %}}

ตัวเลือกนี้ช่วยลดเวลาที่ใช้ในการบันทึกงานนำเสนอในรูปแบบ PPTX

{{% /alert %}}

## **อัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์**

อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprogresscallback/) ถูกใช้ผ่านเมธอด `set_ProgressCallback` ของอินเทอร์เฟซ [ISaveOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isaveoptions/) และคลาสเชิงนามธรรม [SaveOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/) ให้นำไปใช้งานโดยกำหนดการทำงานของ [IProgressCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprogresscallback/) ผ่าน `set_ProgressCallback` เพื่อรับการอัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ `IProgressCallback`

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // ใช้ค่าร้อยละของความคืบหน้าที่นี่.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// คลาส callback สำหรับความคืบหน้าที่กำหนดไว้ข้างต้น.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="ข้อมูล" color="info" %}}

Aspose ได้พัฒนาแอป **PowerPoint Splitter** ฟรี ([ลิงก์](https://products.aspose.app/slides/th/splitter)) โดยใช้ API ของตนเอง แอปนี้ช่วยให้คุณแยกงานนำเสนอออกเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่

{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับการ “บันทึกเร็ว” (incremental save) ที่บันทึกเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่ รองรับการบันทึกแบบ incremental “fast save” การบันทึกจะสร้างไฟล์เป้าหมายเต็มทุกครั้ง

**การบันทึกอ็อบเจ็กต์ Presentation เดียวจากหลายเธรดปลอดภัยหรือไม่?**

ไม่ อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ไม่รองรับการทำงานหลายเธรด (/slides/th/cpp/multithreading/) ควรบันทึกจากเธรดเดียวเท่านั้น

**ไฮเปอร์ลิงก์และไฟล์ที่ลิงก์ภายนอกจะเกิดอะไรขึ้นเมื่อบันทึก?**

[Hyperlinks](/slides/th/cpp/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่ลิงก์ภายนอก (เช่นวิดีโอที่อ้างอิงด้วยเส้นทางสัมพัทธ์) จะไม่ถูกคัดลอกโดยอัตโนมัติ – ต้องตรวจสอบให้แน่ใจว่าเส้นทางที่อ้างอิงยังคงเข้าถึงได้

**สามารถตั้งค่า/บันทึกเมตาเดาตาของเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ได้ รองรับคุณสมบัติมาตรฐานของเอกสาร ([document properties](/slides/th/cpp/presentation-properties/)) และจะถูกเขียนลงไฟล์เมื่อบันทึก