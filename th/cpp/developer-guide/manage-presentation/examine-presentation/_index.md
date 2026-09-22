---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน C++
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/cpp/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- รับคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้างและเมตาดาต้าในการนำเสนอ PowerPoint และ OpenDocument ด้วย C++ เพื่อรับข้อมูลที่รวดเร็วและการตรวจสอบเนื้อหาที่ฉลาดขึ้น"
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของการนำเสนอและอ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างโมเดลอ็อบเจกต์การนำเสนอทั้งหมด ซึ่งเป็นประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์ สร้างรายการสินค้าคงคลัง หรือตรวจสอบคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาการนำเสนอหรือไม่  

บทความนี้แสดงการตรวจสอบแบบน้ำหนักเบาผ่าน [PresentationFactory](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationfactory/) และ [IPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/), รวมถึงการอัปเดตแบบเจาะจงผ่าน [IDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/)  

## **ตรวจสอบรูปแบบการนำเสนอ**

หากคุณมีการนำเสนอที่โหลดแล้ว ให้ดูที่ [Determine the Original Presentation Format](/slides/th/cpp/detect-presentation-source-format/) เพื่อการตรวจจับหลังจากโหลดและข้อจำกัดของสตรีม PPT, PPS, และ POT รุ่นเก่า  
ใช้ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) วิธีการ [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/get_loadformat/) รายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP  

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **สร้างรายการสินค้าคงคลังการนำเสนอแบบเบา**

เมื่อคุณประมวลผลไฟล์การนำเสนอหลายไฟล์ คุณอาจต้องการรายการสินค้าคงคลังแบบกะทัดรัดสำหรับการตรวจสอบ การทำดัชนี หรือระบบการจัดการเอกสาร ในสถานการณ์นี้ ให้ใช้ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) เพื่อรับอ็อบเจกต์ [IPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/) จากนั้นเรียก [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสาร วิธีนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) หรือจำเป็นต้องสำรวจโมเดลอ็อบเจกต์การนำเสนอทั้งหมด  

คุณสมบัติเพิ่มเติมที่เปิดเผยโดย [IDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/) ให้ค่ารายการสินค้าคงคลังต่อไปนี้:  

| วิธี | ค่ารายการ |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_slides/) | จำนวนสไลด์ทั้งหมด. |
| [get_HiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | จำนวนสไลด์ที่ซ่อนอยู่. |
| [get_Notes](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_notes/) | จำนวนสไลด์ที่มีบันทึก. |
| [get_Paragraphs](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | จำนวนย่อหน้าทั้งหมด (ถ้ามี). |
| [get_Words](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_words/) | จำนวนคำทั้งหมด. |
| [get_MultimediaClips](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | จำนวนคลิปเสียงและวิดีโอทั้งหมด. |

ตัวอย่างต่อไปนี้อ่านค่าต่างๆ เหล่านี้โดยไม่สร้างอ็อบเจกต์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และพิมพ์รายการสินค้าคงคลังแบบกะทัดรัด นอกจากนี้ยังรวม [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_headingpairs/) กับ [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) เพื่อแสดงกลุ่มเนื้อหา เช่น แบบอักษร ธีม และชื่อสไลด์  

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

แต่ละ [IHeadingPair](https://reference.aspose.com/slides/th/cpp/aspose.slides/iheadingpair/) ให้ชื่อกลุ่มผ่าน [IHeadingPair::get_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/iheadingpair/get_name/) และจำนวนรายการในกลุ่มนั้นผ่าน [IHeadingPair::get_Count](https://reference.aspose.com/slides/th/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) คืนค่าระดับแบนเรียงลำดับ ดังนั้นให้ใช้จำนวนชื่อที่ต่อเนื่องตามที่แต่ละ heading pair ระบุ  

### **เมตาดาต้าที่จัดเก็บและข้อจำกัดของรูปแบบ**

คุณสมบัติรายการสินค้าคงคลังที่คืนค่าจาก [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) สะท้อนเมตาดาต้าที่มีในเอกสารต้นฉบับ Aspose.Slides ไม่ได้โหลดและสำรวจโมเดลอ็อบเจกต์การนำเสนอเพื่อคำนวณค่าเหล่านี้ใหม่ในการเรียกนี้ คุณสมบัติที่หายไปจะแสดงด้วยค่าเริ่มต้นและค่าที่จัดเก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งล่าสุดไม่ได้อัปเดตคุณสมบัติเอกสาร  

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับจำนวนสไลด์, บันทึก, สไลด์ที่ซ่อน, ย่อหน้า, คำ, และคลิปมัลติมีเดีย รวมถึง heading pairs และ part titles การพร้อมใช้งานขึ้นอยู่กับคุณสมบัติที่ผู้ผลิตเอกสารเขียนไว้.  
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกัน หากคุณสมบัติบางอย่างไม่มีหรือไม่ได้รับการรีเฟรชโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่จัดเก็บหรือค่าเริ่มต้นแทนการคำนวณจากสไลด์.  
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติเอกสารทั่วไป เช่น จำนวนหน้า ย่อหน้า และคำ แต่ค่าดังกล่าวไม่ได้แมพกับคุณสมบัติเพิ่มเติมของ PowerPoint ทุกอย่าง เมตาดาต้าเกี่ยวกับสไลด์ที่ซ่อน, สไลด์บันทึก, มัลติมีเดีย, heading‑pair, และ part‑title อาจไม่มีและคุณสมบัติรายการสินค้าคงคลังอาจคืนค่าดีฟอลต์ อย่าพิจารณาค่าเป็นศูนย์หรืออาร์เรย์ว่างเป็นหลักฐานแน่นอนว่าข้อมูลนั้นไม่มี.  

ใช้วิธีเมตาดาต้าน้ำหนักเบาสำหรับรายการสินค้าคงคลังและการตรวจสอบเบื้องต้น โหลดการนำเสนอและตรวจสอบโมเดลอ็อบเจกต์แบบสดเมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการตรวจสอบเนื้อหาการนำเสนอจริง.  

## **อัปเดตคุณสมบัติการนำเสนอ**

คุณสมบัติที่คืนค่าจาก [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ใช้การเปลี่ยนแปลงด้วย [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), จากนั้นเขียนการนำเสนอที่ผูกไว้ด้วย [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).  

รูปภาพต่อไปนี้แสดงคุณสมบัติเอกสารต้นฉบับ.  

![Original document properties of the PowerPoint presentation](input_properties.png)  

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาที่บันทึกล่าสุดและเขียนผลลัพธ์ไปยังไฟล์ใหม่:  

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```  

รูปภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่อัปเดต.  

![Changed document properties of the PowerPoint presentation](output_properties.png)  

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการป้องกันที่เกี่ยวข้อง ดูบทความต่อไปนี้:  

- [การป้องกันการนำเสนอด้วยรหัสผ่าน](/slides/th/cpp/password-protected-presentation/)  
- [การป้องกันการเขียนของการนำเสนอ](/slides/th/cpp/write-protected-presentation/)  

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนต์ถูกฝังและเป็นฟอนต์ใดบ้าง?**  

โหลดการนำเสนอและใช้ [Presentation::get_FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_fontsmanager/). เรียก [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getembeddedfonts/) เพื่อรับฟอนต์ที่ฝังอยู่และ [FontsManager::GetFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getfonts/) เพื่อรับฟอนต์ที่การนำใช้เปรียบเทียบผลลัพธ์ทั้งสองเพื่อหาฟอนต์ที่จำเป็นสำหรับการแสดงผลแต่ไม่ได้ฝัง.  

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และมีจำนวนเท่าไหร่?**  

เมื่อเมตาดาต้าเอกสารที่จัดเก็บเพียงพอ ให้อ่าน [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) ผ่าน [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) และ [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). วิธีนี้เหมาะกับรายการสินค้าคงคลังแบบเบา หากการนำเสนอได้รับการแก้ไขในหน่วยความจำ เมตาดาต้าที่จัดเก็บอาจหายหรือล้าสมัย หรือคุณต้องตรวจสอบค่าที่เป็นสด ให้วนลูปผ่าน [Presentation::get_Slides](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slides/) และตรวจสอบวิธีการ [Slide::get_Hidden](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/get_hidden/) ของแต่ละสไลด์แทน.  

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและแนวตั้งของสไลด์ที่กำหนดเองและว่ามันแตกต่างจากค่าปริยายหรือไม่?**  

ได้. โหลดการนำเสนอและอ่าน [Presentation::get_SlideSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slidesize/). ตรวจสอบ [ISlideSize::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidesize/get_size/), และ [ISlideSize::get_Orientation](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidesize/get_orientation/) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าที่กำหนดและขนาดที่คาดไว้.  

**มีวิธีเร็ว ๆ ที่จะตรวจสอบว่าชาร์ตอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**  

ได้. ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/) และตรวจสอบ [ChartData::get_DataSourceType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). สำหรับเวิร์กบุ๊กภายนอก ให้อ่าน [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). ประเภทและเส้นทางของแหล่งข้อมูลบ่งชี้ถึงการอ้างอิงภายนอก แต่การตรวจสอบว่าปลายทางพร้อมใช้งานหรือไม่ต้องทำการตรวจสอบแหล่งทรัพยากรแยกต่างหาก.  

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**  

ไม่มีคุณสมบัติเชิงความซับซ้อนเดียว ให้สำรวจ [Presentation::get_Slides](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slides/) และคอลเลกชัน [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/get_shapes/) ของแต่ละสไลด์ ใช้จำนวนรูปทรงและการมีอยู่ของรูปภาพขนาดใหญ่, เอฟเฟกต์, แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และวัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนพิจารณาสไลด์เป็นคอขวดประสิทธิภาพที่ยืนยันแล้ว.