---
title: ปรับใช้หรือเปลี่ยนแปลงเค้าโครงสไลด์ใน C++
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/cpp/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวแสดงตำแหน่ง
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวข้อส่วน
- สองเนื้อหา
- การเปรียบเทียบ
- เพียงหัวเรื่อง
- เค้าโครงเปล่า
- เนื้อหาพร้อมคำบรรยาย
- รูปภาพพร้อมคำบรรยาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ปรับใช้, สร้างและแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ C++, เพิ่มตัวแสดงตำแหน่ง, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการมองเห็นส่วนท้าย."
---
## **ภาพรวม**

โครงร่างสไลด์กำหนดตำแหน่งและรูปแบบของตัวแสดงตำแหน่ง (placeholder) เช่น ชื่อสไลด์, ข้อความ, รูปภาพ, แผนภูมิ และตาราง การใช้โครงร่างทำให้สไลด์มีโครงสร้างสอดคล้องกันในขณะที่แต่ละสไลด์ยังคงมีเนื้อหาของตนเอง

โครงร่างที่พบมากที่สุด ได้แก่:

- **สไลด์หัวเรื่อง**: มีตัวแสดงตำแหน่งหัวเรื่องและหัวเรื่องย่อย
- **หัวเรื่องและเนื้อหา**: มีตัวแสดงตำแหน่งหัวเรื่องและตัวแสดงตำแหน่งเนื้อหาทั่วไป
- **เปล่า**: ไม่มีตัวแสดงตำแหน่งใด ๆ และเหมาะกับกรณีที่ต้องกำหนดรูปทรงทุกชิ้นด้วยตนเอง

## **ทำความเข้าใจการสืบทอดโครงร่าง**

การนำเสนอมีระดับที่เกี่ยวข้องกันสามระดับ:

1. A [สไลด์หลัก](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/) กำหนดธีม, รูปแบบที่ใช้ร่วมกัน, พื้นหลังและออบเจกต์ทั่วไป
1. A [สไลด์โครงร่าง](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/) อยู่ภายใต้สไลด์หลักและกำหนดการจัดวางตัวแสดงตำแหน่งในรูปแบบเฉพาะ
1. A [สไลด์ปกติ](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) ใช้โครงร่างหนึ่งโครงร่างและเก็บเนื้อหาที่ป้อนไว้สำหรับสไลด์นั้น

สไลด์ปกติสืบทอดธีมและรูปแบบจากโครงร่างของมัน, และโครงร่างสืบทอดจากสไลด์หลัก ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะเขียนทับค่าที่สืบทอดมาที่ระดับนั้น เมื่อสร้างสไลด์ปกติ ตัวรูปร่าง placeholder จะถูกสร้างจากโครงร่างที่เลือก, ส่วนเนื้อหาที่ป้อนเข้า placeholder จะเป็นของสไลด์ปกติ

เพิ่ม placeholder ที่จำเป็นในโครงร่างก่อนสร้างสไลด์จากโครงร่างนั้น การเพิ่ม placeholder อีกตัวในโครงร่างภายหลังจะไม่ทำให้รูปร่าง placeholder ที่สอดคล้องกันถูกเพิ่มอัตโนมัติในสไลด์ปกติที่มีอยู่แล้ว

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนรูปแบบที่สืบทอดหรือรูปทรงของ placeholder ที่มีอยู่ในโครงร่างสามารถอัปเดตสไลด์ทุกสไลด์ที่อิงอยู่ได้ ก่อนแก้ไขโครงร่างที่กำลังใช้งาน ให้ตรวจสอบสไลด์ที่ขึ้นกับมันและทบทวนผลลัพธ์ของการนำเสนอ
- โครงร่างที่ยังคงถูกสไลด์อ้างอิงไม่สามารถลบได้ ให้เปลี่ยนสไลด์ที่ขึ้นกับโครงร่างนั้นไปใช้โครงร่างอื่นก่อน, หรือเพียงลบโครงร่างที่ไม่มีการใช้งานเท่านั้น

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของลำดับชั้นนี้ ดูที่ [มาสเตอร์สไลด์](/slides/th/cpp/slide-master/)

หากต้องการซ่อนโลโก้หรือกราฟิกมาสเตอร์ที่สืบทอดบนสไลด์หนึ่งหรือผ่านโครงร่างที่ใช้ร่วมกัน ดูที่ [ควบคุมการแสดงผลกราฟิกมาสเตอร์](/slides/th/cpp/slide-master/) ตัวอย่างเปรียบเทียบสไลด์สองสไลด์ที่ใช้มาสเตอร์เดียวกัน

## **เลือกและใช้โครงร่างสไลด์**

ใช้ประเภทโครงร่างเมื่อการนำเสนอปฏิบัติตามคำนิยามโครงร่าง PowerPoint มาตรฐาน ชื่อโครงร่างสามารถแก้ไขโดยผู้ใช้และแปลเป็นภาษาต่าง ๆ ได้ ดังนั้นการเลือกตามชื่อจึงน้อยกว่าความน่าเชื่อถือ เว้นแต่คุณควบคุมเทมเพลตต้นฉบับ

ตัวอย่างต่อไปนี้ค้นหา **หัวเรื่องและเนื้อหา** บนมาสเตอร์แรก หากโครงร่างนั้นไม่มีอยู่ จะย้อนกลับไปใช้ **เปล่า** อย่างตั้งใจ การตรวจสอบค่าว่างที่สองจำเป็นเนื่องจากการนำเสนออาจมีเพียงโครงร่างแบบกำหนดเองเท่านั้น โครงร่างที่เลือกจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านเมธอด [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/set_layoutslide/)

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การเปลี่ยนโครงร่างของสไลด์ไม่ได้ลบรูปร่างปกติที่เพิ่มเข้ามาโดยตรงบนสไลด์ อย่างไรก็ตามตำแหน่งของ placeholder, รูปแบบที่สืบทอด, และความสอดคล้องระหว่าง placeholder ที่มีอยู่กับโครงร่างใหม่อาจเปลี่ยนแปลงได้ ดังนั้นควรตรวจสอบผลลัพธ์เมื่อสลับระหว่างโครงร่างที่แตกต่างอย่างมาก

## **เพิ่มสไลด์โครงร่าง**

การเลือกและการสร้างเป็นขั้นตอนที่แยกจากกัน ตัวอย่างก่อนหน้าเลือกโครงร่างที่มีอยู่; ไม่ได้สร้างใหม่ เพื่อสร้างโครงร่างให้เรียกเมธอด [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterlayoutslidecollection/add/) บนคอลเลกชันโครงร่างของมาสเตอร์เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มโครงร่าง **หัวเรื่องและเนื้อหา** ใหม่ชื่อ `Report Title and Content` เสมอ, แล้วเพิ่มสไลด์ปกติที่อิงจากโครงร่างนั้น ชื่อโครงร่างต้องไม่ซ้ำกันภายในคอลเลกชัน

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

เพิ่มโครงร่างเฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่นำกลับมาใช้ใหม่ หากมีโครงร่างที่เหมาะสมแล้ว ให้เลือกและใช้ซ้ำแทนการสร้างโครงร่างซ้ำ

## **เพิ่ม Placeholder ไปยังสไลด์โครงร่าง**

เมธอด [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) ให้ [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/) สำหรับเพิ่มรูปร่าง placeholder ไปยังโครงร่าง

| ตัวแสดงตำแหน่ง PowerPoint | วิธีการ `ILayoutPlaceholderManager` |
| --------------------------- | ----------------------------------- |
| ![เนื้อหา](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![ข้อความ](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![รูปภาพ](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![แผนภูมิ](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![ตาราง](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![สื่อ](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![รูปภาพออนไลน์](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

ตัวอย่างต่อไปนี้ตรวจสอบว่าโครงร่าง **เปล่า** มีอยู่, เพิ่ม placeholder สี่รายการลงในโครงร่างนั้น, แล้วสร้างสไลด์ปกติที่ใช้โครงร่างที่แก้ไขแล้ว ลำดับมีจุดมุ่งหมาย: เพิ่ม placeholder ก่อนสร้างสไลด์ปกติ เพื่อให้ Aspose.Slides สามารถสร้างรูปร่าง placeholder ที่สอดคล้องบนสไลด์นั้นได้

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![Placeholder บนสไลด์โครงร่าง](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนรูปแบบที่สืบทอดหรือรูปทรงของ placeholder ที่มีอยู่ในโครงร่างอาจส่งผลต่อสไลด์ที่อิงอยู่ Placeholder ที่เพิ่มใหม่จะไม่ถูกเติมกลับในสไลด์ปกติที่มีอยู่แล้ว ทดสอบการเปลี่ยนแปลงโครงร่างบนสำเนาของการนำเสนอและตรวจสอบสไลด์ที่อิงทุกสไลด์
{{% /alert %}}

## **ลบสไลด์โครงร่างที่ไม่ได้ใช้**

ใช้เมธอด [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) เพื่อลบโครงร่างที่ไม่มีสไลด์ปกติอ้างอิง เมธอดจะทิ้งโครงร่างที่ยังคงถูกใช้งานไว้เดิม

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

เพื่อเอาโครงร่างเฉพาะหนึ่งออก, ก่อนอื่นให้ใช้เมธอด [get_HasDependingSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) หรือ [GetDependingSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/getdependingslides/) เพื่อตรวจสอบสไลด์ที่อิงอยู่ แล้วเปลี่ยนสไลด์ที่อิงก่อนเรียก [ILayoutSlide::Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/remove/) การพยายามลบโครงร่างที่กำลังใช้งานจะทำให้เกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxeditexception/)

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์โครงร่าง**

โครงร่างมีส่วนท้ายของตนเอง, placeholder หมายเลขสไลด์และวันเวลา ใช้เมธอด [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) เพื่อควบคุม placeholder เหล่านั้นสำหรับโครงร่างหนึ่ง ตัวเลือกนี้เป็นประโยชน์เมื่อเช่น โครงร่างเนื้อหาควรแสดงส่วนท้ายแต่โครงร่างหัวเรื่องไม่ควรแสดง

ตัวอย่างต่อไปนี้เลือกโครงร่างอย่างปลอดภัยและทำให้ส่วนท้ายของมันมองเห็นได้:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ควบคุมการมองเห็นส่วนท้ายบนมาสเตอร์และโครงร่างลูกของมัน**

เพื่อกำหนดค่าการแสดงส่วนท้ายให้สอดคล้องกันทั่วทั้งลำดับชั้นมาสเตอร์, ใช้เมธอด [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/get_headerfootermanager/) วิธีการกระจายของ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslideheaderfootermanager/) จะทำงานบนมาสเตอร์และโครงร่างที่ขึ้นกับมันรวมถึงสไลด์ปกติ; ไม่ได้มุ่งเป้าไปที่สไลด์ปกติเพียงสไลด์เดียว

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างสไลด์มาสเตอร์และสไลด์โครงร่างคืออะไร?**

สไลด์มาสเตอร์กำหนดธีมและรูปแบบที่แชร์ของการนำเสนอ สไลด์โครงร่างเป็นส่วนของมาสเตอร์และกำหนดการจัดวาง placeholder ที่นำกลับมาใช้ได้หนึ่งแบบ สไลด์ปกติใช้โครงร่างเหล่านั้นและเก็บเนื้อหาที่เฉพาะเจาะจงของสไลด์

**ฉันสามารถคัดลอกสไลด์โครงร่างจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งได้หรือไม่?**

ทำได้ โดยเพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยเมธอด [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/igloballayoutslidecollection/addclone/) เมื่อคัดลอกระหว่างการนำเสนอ ควรตรวจสอบฟอนต์, ธีม, รูปภาพและทรัพยากรอื่น ๆ ที่โครงร่างต้นทางใช้

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขโครงร่างที่กำลังใช้งานอยู่?**

สไลด์ที่อิงจะสืบทอดการเปลี่ยนแปลงของโครงร่างเว้นแต่จะเขียนทับรูปแบบหรือออบเจกต์ที่เกี่ยวข้องในระดับท้องถิ่น รูปทรงของ placeholder และสไตล์ที่สืบทอดอาจเปลี่ยนแปลงในหลายสไลด์พร้อมกัน ใช้เมธอด [GetDependingSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/getdependingslides/) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขโครงร่าง

**จะเกิดอะไรขึ้นหากฉันลบโครงร่างที่ยังคงถูกใช้?**

Aspose.Slides จะโยงข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxeditexception/) ให้เปลี่ยนสไลด์ที่อิงก่อน หรือใช้เมธอด [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) เพื่อลบโครงร่างที่ไม่มีการอ้างอิงเท่านั้น