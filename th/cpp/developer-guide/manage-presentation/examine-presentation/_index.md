---
title: ดึงและอัปเดตข้อมูลพรีเซนเทชั่นใน C++
linktitle: ข้อมูลพรีเซนเทชั่น
type: docs
weight: 30
url: /th/cpp/examine-presentation/
keywords:
- รูปแบบพรีเซนเทชั่น
- คุณสมบัตพรีเซนเทชั่น
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
- พรีเซนเทชั่น
- C++
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในพรีเซนเทชั่น PowerPoint และ OpenDocument ด้วย C++ เพื่อให้ได้ข้อมูลเชิงลึกเร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของพรีเซนเทชั่นและอ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างโมเดลวัตถุพรีเซนเทชั่นอย่างสมบูรณ์ ซึ่งเป็นประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์ สร้างรายการตรวจสอบ หรือตรวจสอบคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาพรีเซนเทชั่นหรือไม่

บทความนี้แสดงการตรวจสอบแบบเบาโดยใช้ [PresentationFactory](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationfactory/) และ [IPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/), รวมถึงการอัปเดตแบบเจาะจงโดยใช้ [IDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/)  

## **ตรวจสอบรูปแบบพรีเซนเทชัน**

ใช้ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) วิธี [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/get_loadformat/) จะรายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP

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

## **สร้างรายการพรีเซนเทชันขนาดเบา**

เมื่อคุณต้องประมวลผลไฟล์พรีเซนเทชันจำนวนมาก คุณอาจต้องการรายการสั้น ๆ เพื่อการตรวจสอบ การทำดัชนี หรือระบบจัดการเอกสาร ในกรณีนี้ ให้ใช้ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) เพื่อรับอ็อบเจ็กต์ [IPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/) จากนั้นเรียก [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) เพื่ออ่านเมตาดาต้าเอกสาร วิธีการนี้จะไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) หรือทำให้ต้องเดินทางผ่านโมเดลวัตถุพรีเซนเทชั่นเต็มรูปแบบ

คุณสมบัติเพิ่มเติมที่เปิดโดย [IDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/) ให้ค่าต่อไปนี้ในรายการ:

| วิธีการ | ค่าในรายการ |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_slides/) | จำนวนสไลด์ทั้งหมด |
| [get_HiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | จำนวนสไลด์ที่ซ่อนอยู่ |
| [get_Notes](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_notes/) | จำนวนสไลด์ที่มีบันทึกย่อ |
| [get_Paragraphs](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | จำนวนย่อหน้าทั้งหมด (หากมี) |
| [get_Words](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_words/) | จำนวนคำทั้งหมด |
| [get_MultimediaClips](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | จำนวนคลิปเสียงและวิดีโอทั้งหมด |

ตัวอย่างต่อไปนี้อ่านค่าต่าง ๆ เหล่านี้โดยไม่สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และพิมพ์รายการสั้น ๆ นอกจากนี้ยังผสานการใช้งาน [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_headingpairs/) กับ [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) เพื่อแสดงกลุ่มเนื้อหา เช่น ฟอนต์ ธีม และชื่อสไลด์

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

แต่ละอ็อบเจ็กต์ [IHeadingPair](https://reference.aspose.com/slides/th/cpp/aspose.slides/iheadingpair/) จะให้ชื่อกลุ่มผ่าน [IHeadingPair::get_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/iheadingpair/get_name/) และจำนวนรายการในกลุ่มผ่าน [IHeadingPair::get_Count](https://reference.aspose.com/slides/th/cpp/aspose.slides/iheadingpair/get_count/) เมธอด [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) จะคืนค่าอาร์เรย์แบนที่เรียงลำดับ จึงต้องใช้จำนวนชื่อที่ต่อเนื่องตามที่แต่ละ HeadingPair ระบุ

### **ข้อมูลเมตาที่เก็บไว้และข้อจำกัดของรูปแบบ**

คุณสมบัติลิสต์ที่ส่งกลับโดย [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) สะท้อนเมตาดาต้าที่มีอยู่ในเอกสารต้นทาง Aspose.Slides ไม่ได้โหลดและเดินทางผ่านโมเดลวัตถุพรีเซนเทชั่นเพื่อคำนวณค่าเหล่านี้ใหม่สำหรับการเรียกนี้ คุณสมบัติที่หายไปจะแสดงเป็นค่าเริ่มต้น และค่าที่เก็บไว้อาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติเข้าเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมสำหรับจำนวนสไลด์ บันทึกย่อ สไลด์ที่ซ่อนอยู่ ย่อหน้า คำ และสื่อมัลติมีเดีย รวมถึง HeadingPairs และ PartTitles การใช้งานขึ้นกับว่าผู้ผลิตเอกสารได้เขียนคุณสมบัติเหล่านั้นหรือไม่
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัติเกิดขาดหรือไม่ได้รับการรีเฟรชโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่เก็บไว้หรือค่าเริ่มต้นแทนการคำนวณจากสไลด์
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติทั่วไปของเอกสาร เช่น จำนวนหน้า ย่อหน้า และคำ แต่ค่าดังกล่าวไม่แมปกับคุณสมบัติเพิ่มเติมเฉพาะ PowerPoint เช่น สไลด์ที่ซ่อน บันทึกย่อ สื่อมัลติมีเดีย HeadingPairs และ PartTitles อาจไม่มีให้บริการและคุณสมบัติในรายการอาจคืนค่าเริ่มต้น อย่าถือค่าศูนย์หรืออาร์เรย์ว่างว่าเป็นการพิสูจน์ที่แน่นอนว่าข้อมูลดังกล่าวไม่มีอยู่

ใช้วิธีเมตาดาต้าแบบเบาสำหรับการทำรายการและการตรวจสอบเบื้องต้น โหลดพรีเซนเทชั่นและตรวจสอบโมเดลวัตถุสดเมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการยืนยันเนื้อหาพรีเซนเทชั่นจริง

## **อัปเดตคุณสมบัติพรีเซนเทชั่น**

คุณสมบัติที่ส่งกลับโดย [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ใช้ [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) เพื่อทำการเปลี่ยนแปลง แล้วเขียนพรีเซนเทชั่นที่ผูกไว้ด้วย [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/)

ภาพต่อไปนี้แสดงคุณสมบัติเบื้องต้นของเอกสาร

![Original document properties of the PowerPoint presentation](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาที่บันทึกล่าสุด แล้วเขียนผลลัพธ์ไปยังไฟล์ใหม่:

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

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่ถูกอัปเดต

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการป้องกันที่เกี่ยวข้อง ดูบทความต่อไปนี้:

- [Password-Protect Presentations](/slides/th/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/th/cpp/write-protected-presentation/)

## **FAQ**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังไว้และมีแบบอักษรอะไรบ้าง?**

โหลดพรีเซนเทชั่นและใช้ [Presentation::get_FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_fontsmanager/) เรียก [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getembeddedfonts/) เพื่อรับแบบอักษรที่ฝังไว้และ [FontsManager::GetFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getfonts/) เพื่อรับแบบอักษรที่พรีเซนเทชั่นใช้เปรียบเทียบผลลัพธ์สองชุดเพื่อหาตัวอักษรที่จำเป็นสำหรับการเรนเดอร์แต่ไม่ได้ฝังไว้

**ฉันจะบอกได้เร็ว ๆ ว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และมีจำนวนเท่าไหร่?**

เมื่อเมตาดาต้าเอกสารที่เก็บไว้เพียงพอ ให้อ่าน [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) ผ่าน [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) และ [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) วิธีนี้เหมาะกับการทำรายการเบา หากพรีเซนเทชั่นถูกแก้ไขในหน่วยความจำ เมตาดาต้าที่เก็บไว้อาจหายหรือล้าสมัย หรือคุณต้องการตรวจสอบค่าจริง ให้วนลูปผ่าน [Presentation::get_Slides](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slides/) และตรวจสอบเมธอด [Slide::get_Hidden](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/get_hidden/) ของแต่ละสไลด์แทน

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการกำหนดขนาดสไลด์และการวางแนวแบบกำหนดเองและว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้ โหลดพรีเซนเทชั่นและอ่าน [Presentation::get_SlideSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slidesize/) ตรวจสอบ [ISlideSize::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidesize/get_size/) และ [ISlideSize::get_Orientation](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidesize/get_orientation/) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับพรีเซ็ตและขนาดที่คาดหวัง

**มีวิธีรวดเร็วในการดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

มี ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/) และตรวจสอบ [ChartData::get_DataSourceType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) หากเป็น workbook ภายนอก ให้อ่าน [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) ประเภทและพาธของแหล่งข้อมูลจะแสดงว่าเป็นการอ้างอิงภายนอก แต่การตรวจสอบว่าแหล่งที่มามีอยู่หรือไม่ต้องทำการตรวจสอบแยกต่างหาก

**ฉันจะประเมินสไลด์ “หนัก” ที่อาจทำให้การเรนเดอร์หรือส่งออก PDF ช้าลงได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเพียงหนึ่งค่า ให้วนลูปผ่าน [Presentation::get_Slides](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slides/) และคอลเลกชัน [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/get_shapes/) ของแต่ละสไลด์ ใช้การนับจำนวนรูปทรงและการมีอยู่ของภาพขนาดใหญ่ เอฟเฟกต์ แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และวัดการเรนเดอร์หรือส่งออกตัวอย่างก่อนตัดสินว่าสไลด์เป็นคอขวดประสิทธิภาพอย่างแน่ชัด