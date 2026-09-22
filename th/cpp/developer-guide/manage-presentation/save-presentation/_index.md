---
title: บันทึกการนำเสนอใน C++
linktitle: บันทึกการนำเสนอ
type: docs
weight: 80
url: /th/cpp/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกการนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- การนำเสนอเป็นไฟล์
- การนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- การบันทึกความคืบหน้า
- C++
- Aspose.Slides
description: "บันทึกการนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมใน C++ ด้วย Aspose.Slides และกำหนดการส่งออก PPTX รวมถึงการรายงานความคืบหน้า"
---
## **ภาพรวม**

หลังจากที่คุณสร้างการนำเสนอหรือ [เปิดการนำเสนอที่มีอยู่](/slides/th/cpp/open-presentation/), ใช้เมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) เพื่อบันทึกผลลัพธ์ Aspose.Slides for C++ สามารถบันทึกการนำเสนอเป็นไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่น ๆ ส่วนต่อไปนี้จะครอบคลุมการบันทึกมาตรฐานและตัวเลือกที่ใช้ได้สำหรับการส่งออก PPTX

## **บันทึกการนำเสนอเป็นไฟล์**

เพื่อบันทึกการนำเสนอเป็นไฟล์ ให้ส่งพาธไฟล์เอาต์พุตและค่า [SaveFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) ไปยังเมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) ค่ารูปแบบจะกำหนดประเภทของไฟล์ที่ Aspose.Slides จะสร้าง

ตัวอย่างต่อไปนี้สร้างการนำเสนอและบันทึกเป็นไฟล์ PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// เพิ่มหรือแก้ไขเนื้อหาการนำเสนอที่นี่.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **บันทึกการนำเสนอในรูปแบบดั้งเดิม**

สำหรับตัวอย่างการตรวจจับไฟล์และสตรีม, พฤติกรรมของการนำเสนอที่สร้างใหม่, และความแตกต่างระหว่างรูปแบบต้นทางและรูปแบบเอาต์พุต, ดูที่ [Determine the Original Presentation Format](/slides/th/cpp/detect-presentation-source-format/)

ในแอปพลิเคชันการประมวลผลแบบกลุ่ม, รูปแบบอินพุตอาจไม่ทราบล่วงหน้า หลังจากโหลดไฟล์, อ่านรูปแบบดั้งเดิมด้วย [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_sourceformat/) ส่งค่า [SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/sourceformat/) ที่ได้ไปยัง [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/tosaveformat/) เพื่อรับค่า [SaveFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) ที่สอดคล้องกัน แล้วใช้ [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) เพื่อบันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่างต่อไปนี้ประมวลผลทุกไฟล์ในไดเรกทอรีอินพุต, ปรับปรุงชื่อเรื่อง, และบันทึกไปยังไดเรกทอรีเอาต์พุตในรูปแบบที่โหลดมา:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/tosaveformat/) ทำแผนที่ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP และ PowerPoint XML ไปยังรูปแบบการบันทึกการนำเสนอที่สอดคล้องกัน มันทำแผนที่เฉพาะรูปแบบต้นทางของการนำเสนอเท่านั้น; ไม่ได้ออกแบบให้เลือกรูปแบบการส่งออกเช่น PDF, HTML, TIFF หรือภาพ การส่งค่าที่ไม่สนับสนุนหรือไม่ถูกต้องของ [SourceFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/sourceformat/) จะทำให้เกิด [ArgumentException](https://reference.aspose.com/slides/th/cpp/system/argumentexception/)

ไฟล์ PPT, PPS, และ POT รุ่นเก่าใช้คอนเทนเนอร์ไบนารีเดียวกัน เมื่อการนำเสนอประเภทนี้ถูกโหลดจากสตรีมโดยไม่มีนามสกุลไฟล์, ไฟล์ PPS หรือ POT อาจถูกระบุเป็น PPT หากต้องการคงรุ่นย่อยเหล่านี้ไว้ ควรเก็บชื่อไฟล์หรือเมทาดาต้ารูปแบบเดิมไว้แยกต่างหากและใช้เมื่อนำไปกำหนดชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกการนำเสนอเป็นสตรีม**

เพื่อเขียนการนำเสนอโดยไม่ต้องอ้างอิงพาธไฟล์สุดท้าย ให้ส่ง [Stream](https://reference.aspose.com/slides/th/cpp/system.io/stream/) ที่เขียนได้และค่า [SaveFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveformat/) ไปยังเมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) วิธีนี้มีประโยชน์เมื่อเอาต์พุตต้องส่งกลับจากเว็บเซอร์วิส, เก็บในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

ตัวอย่างต่อไปนี้บันทึกการนำเสนอใหม่ไปยังไฟล์สตรีม:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **บันทึกการนำเสนอพร้อมกำหนดประเภทมุมมองล่วงหน้า**

คุณสามารถกำหนดมุมมองที่ PowerPoint เปิดการนำเสนอที่บันทึกไว้ครั้งแรกได้ เรียก [ViewProperties::set_LastView](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/set_lastview/) พร้อมค่า [ViewType](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewtype/) ก่อนบันทึก

ตัวอย่างต่อไปนี้กำหนดมุมมอง Slide Master เป็นมุมมองเริ่มต้น:

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

## **บันทึกการนำเสนอในรูปแบบ Strict Office Open XML**

เพื่อสร้างไฟล์ PPTX ที่สอดคล้องกับโปรไฟล์ Strict ของ Office Open XML ให้สร้างอินสแตนซ์ [PptxOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/) แล้วเรียก [PptxOptions::set_Conformance](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/set_conformance/) ด้วย `Conformance::Iso29500_2008_Strict` จากนั้นส่งตัวเลือกเหล่านั้นไปยังเมธอด [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/)

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **บันทึกการนำเสนอในรูปแบบ Office Open XML โหมด Zip64**

อาร์ไคฟ์ ZIP มาตรฐานจำกัดขนาดบีบอัดและอัดไม่บีบอัดของแต่ละรายการ, ขนาดอาร์ไคฟ์ทั้งหมด, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นอาร์ไคฟ์ ZIP, การนำเสนอขนาดใหญ่มากอาจเกินขีดจำกัดเหล่านี้ ส่วนขยาย ZIP64 เพิ่มขีดจำกัดขนาดและจำนวนรายการที่ใช้ได้

ใช้ [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) เพื่อควบคุมว่าต้องเขียนส่วนขยาย ZIP64 หรือไม่:

- `IfNecessary` ใช้ ZIP64 เฉพาะเมื่อการนำเสนอเกินขีดจำกัด ZIP มาตรฐาน (เป็นค่าเริ่มต้น)
- `Never` ปิดส่วนขยาย ZIP64
- `Always` เขียนส่วนขยาย ZIP64 เสมอ

ตัวอย่างต่อไปนี้เปิดใช้งานส่วนขยาย ZIP64 เสมอสำหรับการนำเสนอเอาต์พุต:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="คำเตือน" %}}
หากตั้งค่า `Zip64Mode` เป็น `Never` และการนำเสนอไม่สามารถใส่ในขีดจำกัด ZIP มาตรฐาน การบันทึกจะโยน [PptxException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxexception/)
{{% /alert %}}

## **บันทึกการนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

สำหรับเอาต์พุต PPTX คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกกับขนาดไฟล์โดยเรียก [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) ค่าตัวนับ [CompressionLevel](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/compressionlevel/) มีดังนี้:

- `None` เก็บข้อมูลโดยไม่มีการบีบอัด
- `Level1` ให้การบีบอัดที่เร็วที่สุดและผลลัพธ์ที่บีบอัดมากที่สุด
- `Level2` ถึง `Level5` ให้ความสำคัญกับผลลัพธ์ที่เล็กลงเรื่อย ๆ มากกว่าความเร็วในการบันทึก
- `Level6` สมดุลความเร็วและขนาดไฟล์ (ค่าเริ่มต้น)
- `Level7` และ `Level8` ให้ความสำคัญกับผลลัพธ์ที่เล็กลงมากกว่าความเร็ว
- `Level9` ให้การบีบอัดสูงสุดแต่ต้องใช้เวลาประมวลผลมากที่สุด

ตัวอย่างต่อไปนี้บันทึกการนำเสนอโดยไม่มีการบีบอัด:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

ตัวอย่างต่อไปนี้ใช้ระดับการบีบอัดสูงสุด:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **บันทึกการนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมื่อการนำเสนอถูกบันทึกเป็น PPTX, [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) ควบคุมภาพย่อของเอกสาร:

- `true` สร้างภาพย่อใหม่ระหว่างการบันทึก (ค่าเริ่มต้น)
- `false` คงภาพย่อยเดิมไว้ หากการนำเสนอไม่มีภาพย่อ Aspose.Slides จะไม่สร้างภาพใหม่

ตัวอย่างต่อไปนี้บันทึกการนำเสนอโดยไม่รีเฟรชภาพย่อ:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="หมายเหตุ" %}}
การปิดการรีเฟรชภาพย่อสามารถลดเวลาที่ใช้ในการบันทึกไฟล์ PPTX ได้
{{% /alert %}}

## **บันทึกความคืบหน้าเป็นเปอร์เซ็นต์**

เพื่อเฝ้าติดตามการบันทึก, ให้ทำการ Implement อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprogresscallback/) และส่งอิมพลีเมนเทชันไปยัง [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isaveoptions/set_progresscallback/) Aspose.Slides จะเรียก [IProgressCallback::Reporting](https://reference.aspose.com/slides/th/cpp/aspose.slides/iprogresscallback/reporting/) พร้อมค่าความคืบหน้าในระหว่างการส่งออก

ตัวอย่างต่อไปนี้แสดงความคืบหน้าการส่งออก PDF ไปยังคอนโซล:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="หมายเหตุ" %}}
Aspose มีเครื่องมือ **PowerPoint Splitter** ฟรี ([link](https://products.aspose.app/slides/th/splitter)) สร้างด้วย Aspose.Slides API ซึ่งจะบันทึกสไลด์ที่เลือกจากการนำเสนอเป็นไฟล์ PPT หรือ PPTX แยกกัน
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการบันทึกแบบ incremental หรือ “fast save” หรือไม่?**

ไม่ รองรับ การบันทึกแต่ละครั้งจะสร้างไฟล์เอาต์พุตเต็มรูปแบบแทนการอัปเดตเฉพาะส่วนที่เปลี่ยนแปลง

**หลายเธรดสามารถบันทึก Presentation instance เดียวกันได้หรือไม่?**

ไม่ได้ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) **ไม่เป็น thread‑safe** (/slides/th/cpp/multithreading/) ให้เข้าถึงและบันทึกแต่ละอินสแตนซ์จากเธรดเดียวเท่านั้น

**ลิงก์และไฟล์ที่เชื่อมโยงภายนอกจะเกิดอะไรขึ้นเมื่อบันทึกการนำเสนอ?**

[Hyperlinks](/slides/th/cpp/manage-hyperlinks/) จะคงอยู่ในการนำเสนอ Aspose.Slides ไม่ได้คัดลอกไฟล์ภายนอก ดังนั้นการนำเสนอที่บันทึกไว้ต้องยังคงสามารถเข้าถึงตำแหน่งของไฟล์เหล่านั้นได้

**สามารถบันทึกเมตาดาต้าเอกสารเช่น ผู้เขียน, ชื่อเรื่อง, บริษัท, และวันสร้างได้หรือไม่?**

ได้ ตั้งค่าคุณสมบัติเอกสารที่เหมาะสม (/slides/th/cpp/presentation-properties/) ก่อนบันทึก แล้ว Aspose.Slides จะเขียนค่าที่ตั้งเหล่านั้นลงในไฟล์เอาต์พุต