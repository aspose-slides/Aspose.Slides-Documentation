---
title: นำไปใช้หรือเปลี่ยนแปลงเค้าโครงสไลด์ใน C++
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/cpp/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวแทนตำแหน่ง
- การออกแบบงานนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวเรื่องส่วน
- สองเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เค้าโครงเปล่า
- เนื้อหาพร้อมคำอธิบาย
- รูปภาพพร้อมคำอธิบาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "นำไปใช้, สร้าง และแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ C++, เพิ่มตัวแทนตำแหน่ง, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการมองเห็นส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและรูปแบบของตัวแทนตำแหน่ง (placeholder) เช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ และตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างที่สอดคล้องกันในขณะที่แต่ละสไลด์ยังคงมีเนื้อหาเป็นของตนเอง

เค้าโครงที่พบมากที่สุด ได้แก่:

- **Title Slide**: มีตัวแทนตำแหน่งของหัวเรื่องและหัวเรื่องย่อย
- **Title and Content**: มีตัวแทนตำแหน่งของหัวเรื่องและตัวแทนตำแหน่งเนื้อหาทั่วไป
- **Blank**: ไม่มีตัวแทนตำแหน่งเนื้อหาและมีประโยชน์เมื่อรูปทรงทุกอย่างจะถูกจัดตำแหน่งด้วยตนเอง

## **ทำความเข้าใจการสืบทอดเค้าโครง**

งานนำเสนอมีระดับที่เกี่ยวข้องสามระดับ:

1. A [สไลด์แม่](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/) กำหนดธีม การจัดรูปแบบที่ใช้ร่วมกัน พื้นหลัง และอ็อบเจ็กต์ทั่วไป
1. A [สไลด์เค้าโครง](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/) เป็นส่วนหนึ่งของสไลด์แม่และกำหนดการจัดวางตัวแทนตำแหน่งเฉพาะ
1. A [สไลด์ปกติ](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) ใช้เค้าโครงหนึ่งและเก็บเนื้อหาที่ป้อนสำหรับสไลด์นั้น

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเค้าโครงของมัน และเค้าโครงสืบทอดจากสไลด์แม่ ค่าใดค่าหนึ่งที่ตั้งโดยตรงบนสไลด์ปกติจะแทนที่ค่าที่สืบทอดในระดับนั้น เมื่อสร้างสไลด์ปกติ รูปร่างตัวแทนตำแหน่งจะถูกสร้างจากเค้าโครงที่เลือก ในขณะที่เนื้อหาที่ป้อนลงในตัวแทนตำแหน่งเหล่านั้นเป็นของสไลด์ปกติ

เพิ่มตัวแทนตำแหน่งที่จำเป็นลงในเค้าโครงก่อนสร้างสไลด์จากเค้าโครงนั้น การเพิ่มตัวแทนตำแหน่งอื่นในเค้าโครงภายหลังจะไม่ทำให้รูปร่างตัวแทนตำแหน่งที่สอดคล้องกันถูกเพิ่มอัตโนมัติในสไลด์ปกติที่มีอยู่แล้ว

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนแปลงการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวแทนตำแหน่งที่มีอยู่ในเค้าโครงสามารถอัปเดตทุกสไลด์ที่พึ่งพาเค้าโครงนั้นได้ ก่อนแก้ไขเค้าโครงที่กำลังใช้อยู่ให้ตรวจสอบสไลด์ที่พึ่งพาและทบทวนการนำเสนอที่ได้
- เค้าโครงที่ยังถูกสไลด์ใช้งานอยู่ไม่สามารถลบได้ ให้เปลี่ยนสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อน หรือเพียงลบเค้าโครงที่ไม่ได้ใช้

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของลำดับชั้นนี้ ดูที่ [สไลด์แม่](/slides/th/cpp/slide-master/)

## **เลือกและใช้เค้าโครงสไลด์**

ใช้ประเภทเค้าโครงเมื่อการนำเสนอปฏิบัติตามคำนิยามเค้าโครงมาตรฐานของ PowerPoint ชื่อเค้าโครงสามารถแก้ไขโดยผู้ใช้และสามารถแปลเป็นภาษาต่าง ๆ ได้ ดังนั้นการเลือกตามชื่อจึงน้อยความน่าเชื่อถือเว้นแต่คุณควบคุมเทมเพลตต้นฉบับ

ตัวอย่างต่อไปนี้ค้นหา **Title and Content** ในสไลด์แม่แรก หากเค้าโครงนั้นไม่มีอยู่จะย้อนกลับไปใช้ **Blank** อย่างตั้งใจ การตรวจสอบค่า null ครั้งที่สองจำเป็นเพราะงานนำเสนออาจมีเฉพาะเค้าโครงที่กำหนดเองเท่านั้น เค้าโครงที่เลือกจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านเมธอด [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/set_layoutslide/)

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

การเปลี่ยนเค้าโครงของสไลด์จะไม่ลบรูปร่างปกติที่เพิ่มโดยตรงลงในสไลด์ อย่างไรก็ตาม ตำแหน่งของตัวแทนตำแหน่ง การจัดรูปแบบที่สืบทอด และความสัมพันธ์ระหว่างตัวแทนตำแหน่งที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลงได้ ดังนั้นให้ตรวจสอบผลลัพธ์เมื่อสลับระหว่างเค้าโครงที่แตกต่างอย่างมาก

## **เพิ่มสไลด์เค้าโครง**

การเลือกและการสร้างเป็นการดำเนินการที่แยกจากกัน ตัวอย่างก่อนหน้านี้เลือกเค้าโครงที่มีอยู่; ไม่ได้สร้างเค้าโครงใหม่ หากต้องการสร้างเค้าโครง ให้เรียกเมธอด [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterlayoutslidecollection/add/) บนคอลเลกชันเค้าโครงของสไลด์แม่เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มเค้าโครง **Title and Content** ใหม่เสมอโดยใช้ชื่อ `Report Title and Content` จากนั้นเพิ่มสไลด์ปกติโดยอิงจากเค้าโครงนั้น ชื่อเค้าโครงต้องไม่ซ้ำกันภายในคอลเลกชัน

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

เพิ่มเค้าโครงเฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่ใช้ซ้ำได้อีกหนึ่งชุด หากมีเค้าโครงที่เหมาะสมอยู่แล้ว ให้เลือกและใช้ซ้ำแทนการสร้างสำเนาใหม่

## **เพิ่มตัวแทนตำแหน่งในสไลด์เค้าโครง**

เมธอด [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) ให้ [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/) สำหรับเพิ่มรูปร่างตัวแทนตำแหน่งลงในเค้าโครง

| PowerPoint Placeholder | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
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

ตัวอย่างต่อไปนี้ตรวจสอบว่าเค้าโครง **Blank** มีอยู่แล้ว เพิ่มตัวแทนตำแหน่งสี่รายการลงในเค้าโครงนั้น แล้วสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว การเรียงลำดับนี้เป็นตามเจตนา: ตัวแทนตำแหน่งถูกเพิ่มก่อนสร้างสไลด์ปกติ เพื่อให้ Aspose.Slides สามารถสร้างรูปร่างตัวแทนตำแหน่งที่สอดคล้องกันบนสไลด์นั้น

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

![ตัวแทนตำแหน่งบนสไลด์เค้าโครง](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Changing inherited formatting or the geometry of existing layout placeholders can affect dependent slides. A newly added layout placeholder is not backfilled into existing normal slides. Test layout changes on a copy of the presentation and inspect every dependent slide.
{{% /alert %}}

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

ใช้เมธอด [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติอ้างอิง เมธอดนี้จะคงเค้าโครงที่ยังถูกใช้อยู่ไว้

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

เพื่อเลือกลบเค้าโครงหนึ่งเฉพาะ ให้ใช้เมธอด [get_HasDependingSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) หรือ [GetDependingSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/getdependingslides/) ของเค้าโครงนั้นก่อน ย้ายสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อนเรียก [ILayoutSlide::Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/remove/) การพยายามลบเค้าโครงที่ยังถูกใช้จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxeditexception/)

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์เค้าโครง**

เค้าโครงมีส่วนท้าย, ตัวเลขสไลด์, และตัวแทนตำแหน่งวัน-เวลาของตนเอง ใช้เมธอด [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) เพื่อควบคุมตัวแทนตำแหน่งเหล่านั้นสำหรับเค้าโครงหนึ่ง ตัวอย่างเช่น เนื้อหาเค้าโครงควรแสดงส่วนท้ายแต่เค้าโครงหัวเรื่องไม่ควรแสดง

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

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์แม่และเค้าโครงลูก**

เพื่อให้ตั้งค่าส่วนท้ายอย่างสม่ำเสมอทั่วระดับสไลด์แม่ ใช้เมธอด [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/get_headerfootermanager/) วิธีการกระจายของ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslideheaderfootermanager/) ทำงานบนสไลด์แม่และสไลด์เค้าโครงและสไลด์ปกติที่พึ่งพา; ไม่ได้มุ่งเป้าเพียงสไลด์ปกติเดียว

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

**ความแตกต่างระหว่างสไลด์แม่และสไลด์เค้าโครงคืออะไร?**

สไลด์แม่กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของการนำเสนอ สไลด์เค้าโครงเป็นส่วนหนึ่งของสไลด์แม่และกำหนดการจัดวางตัวแทนตำแหน่งที่สามารถใช้ซ้ำได้หนึ่งแบบ สไลด์ปกติใช้เค้าโครงเหล่านั้นและเก็บเนื้อหาเฉพาะของสไลด์

**ฉันสามารถคัดลอกสไลด์เค้าโครงจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งได้หรือไม่?**

ได้. เพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยเมธอด [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/igloballayoutslidecollection/addclone/) เมื่อคัดลอกระหว่างงานนำเสนอควรตรวจสอบแบบอักษร, ธีม, รูปภาพ และทรัพยากรอื่น ๆ ที่ใช้โดยเค้าโครงต้นฉบับด้วย

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขเค้าโครงที่กำลังใช้งานอยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเค้าโครง เว้นแต่พวกมันจะโอเวอร์ไรด์การจัดรูปแบบหรืออ็อบเจ็กต์ที่เกี่ยวข้องในระดับท้องถิ่น รูปร่างของตัวแทนตำแหน่งและสไตล์ที่สืบทอดจึงอาจเปลี่ยนแปลงในหลายสไลด์พร้อมกัน ใช้เมธอด [GetDependingSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/getdependingslides/) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเค้าโครง

**จะเกิดอะไรขึ้นหากฉันลบเค้าโหมดที่ยังถูกใช้อยู่?**

Aspose.Slides จะโยน [PptxEditException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxeditexception/) ให้เปลี่ยนสไลด์ที่พึ่งพาก่อน หรือใช้เมธอด [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) เพื่อลบเค้าโครงที่ไม่ได้อ้างอิงเท่านั้น