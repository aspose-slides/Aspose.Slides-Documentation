---
title: ผสานการนำเสนออย่างมีประสิทธิภาพใน C++
linktitle: ผสานการนำเสนอ
type: docs
weight: 40
url: /th/cpp/merge-presentation/
keywords:
- ผสาน PowerPoint
- ผสานการนำเสนอ
- ผสานสไลด์
- ผสาน PPT
- ผสาน PPTX
- ผสาน ODP
- รวม PowerPoint
- รวมการนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- C++
- Aspose.Slides
description: "ผสานการนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++ เพื่อทำให้กระบวนการทำงานของคุณราบรื่นขึ้น"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณผสานการนำเสนอโดยการคัดลอกสไลด์จากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่ง บทความนี้อธิบายวิธีการผสานการนำเสนอทั้งหมดหรือสไลด์ที่เลือก ใช้ slide master หรือ layout เฉพาะระหว่างการผสาน จัดการการนำเสนอที่มีขนาดสไลด์ต่างกัน และเพิ่มสไลด์ที่ผสานแล้วไปยังส่วนของการนำเสนอ นอกจากนี้ยังครอบคลุมโน้ตสำคัญที่เกี่ยวข้องกับเนื้อหาที่ผสานรวม ได้แก่ โน้ตผู้บรรยาย ความคิดเห็น ไฟล์ต้นทางที่ป้องกันด้วยรหัสผ่าน และการใช้เธรด

## **การผสานการนำเสนอ**

เมื่อคุณผสานการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่ง คุณกำลังรวมสไลด์ของทั้งสองเป็นไฟล์เดียว

{{% alert title="Info" color="info" %}}
โปรแกรมนำเสนอส่วนใหญ่ (PowerPoint หรือ OpenOffice) ไม่มีฟังก์ชันที่ให้ผู้ใช้ผสานการนำเสนอในลักษณะนี้
[**Aspose.Slides for C++**](https://products.aspose.com/slides/th/cpp/) อย่างไรก็ตาม ช่วยให้คุณผสานการนำเสนอได้หลายวิธี คุณสามารถผสานการนำเสนอพร้อมกับรูปร่าง สไตล์ ข้อความ การจัดรูปแบบ ความคิดเห็น แอนิเมชัน ฯลฯ โดยไม่ต้องกังวลเรื่องคุณภาพหรือข้อมูลสูญหาย
**ดูเพิ่มเติม**
[Clone Slides](https://docs.aspose.com/slides/th/cpp/clone-slides/)*.* 
{{% /alert %}}

### **สิ่งที่สามารถผสานได้**

ด้วย Aspose.Slides คุณสามารถผสาน

* การนำเสนอทั้งหมด ทุกสไลด์จากการนำเสนอจะอยู่ในไฟล์เดียว
* สไลด์เฉพาะ สไลด์ที่เลือกจะอยู่ในไฟล์เดียว
* การนำเสนอในรูปแบบเดียวกัน (PPT กับ PPT, PPTX กับ PPTX เป็นต้น) หรือในรูปแบบที่ต่างกัน (PPT กับ PPTX, PPTX กับ ODP เป็นต้น) ไปยังกันและกัน

{{% alert title="Note" color="warning" %}} 
นอกเหนือจากการนำเสนอ Aspose.Slides ยังให้คุณผสานไฟล์อื่น ๆ:

* [Images](https://products.aspose.com/slides/th/cpp/merger/image-to-image/), เช่น [JPG to JPG](https://products.aspose.com/slides/th/cpp/merger/jpg-to-jpg/) หรือ [PNG to PNG](https://products.aspose.com/slides/th/cpp/merger/png-to-png/)
* เอกสาร, เช่น [PDF to PDF](https://products.aspose.com/slides/th/cpp/merger/pdf-to-pdf/) หรือ [HTML to HTML](https://products.aspose.com/slides/th/cpp/merger/html-to-html/)
* ไฟล์สองประเภทที่แตกต่างกัน เช่น [image to PDF](https://products.aspose.com/slides/th/cpp/merger/image-to-pdf/) หรือ [JPG to PDF](https://products.aspose.com/slides/th/cpp/merger/jpg-to-pdf/) หรือ [TIFF to PDF](https://products.aspose.com/slides/th/cpp/merger/tiff-to-pdf/)

{{% /alert %}}

### **ตัวเลือกการผสาน**

คุณสามารถกำหนดตัวเลือกที่ระบุว่า

* สไลด์แต่ละสไลด์ในผลลัพธ์จะคงสไตล์เฉพาะของตน
* หรือใช้สไตล์เดียวกันสำหรับสไลด์ทั้งหมดในผลลัพธ์

เพื่อผสานการนำเสนอ Aspose.Slides ให้บริการเมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (จากอินเทอร์เฟซ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection)) มีการนำไปใช้งานหลายรูปแบบของเมธอด `AddClone` ที่กำหนดพารามิเตอร์กระบวนการผสานการนำเสนอ ทุกวัตถุ Presentation มีคอลเลกชัน [Slides](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) คุณจึงเรียกเมธอด `AddClone` จากการนำเสนอที่ต้องการผสานสไลด์เข้าไป

เมธอด `AddClone` จะคืนค่าเป็นวัตถุ `ISlide` ซึ่งเป็นสำเนาของสไลด์ต้นฉบับ สไลด์ในผลลัพธ์จะแค่สำเนาของสไลด์จากต้นฉบับ ดังนั้นคุณสามารถแก้ไขสไลด์ที่ได้ (เช่น ใช้สไตล์หรือการจัดรูปแบบหรือเลเอาต์) โดยไม่กระทบต่อการนำเสนอเดิม

## **ผสานการนำเสนอ**

Aspose.Slides มีเมธอด [**AddClone (ISlide)**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) ที่ช่วยให้คุณรวมสไลด์ขณะสไลด์ยังคงรักษาเลเอาต์และสไตล์ไว้ (พารามิเตอร์เริ่มต้น)

ตัวอย่างโค้ด C++ แสดงวิธีผสานการนำเสนอ:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **ผสานการนำเสนอด้วย Slide Master**

Aspose.Slides มีเมธอด [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) ที่ช่วยให้คุณรวมสไลด์พร้อมประยุกต์เทมเพลต Slide Master วิธีนี้ทำให้คุณสามารถเปลี่ยนสไตล์ของสไลด์ในผลลัพธ์ได้หากต้องการ

โค้ด C++ แสดงการทำงานตามที่อธิบาย:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
เลเอาต์ของ slide master จะกำหนดโดยอัตโนมัติ หากไม่สามารถกำหนดเลเอาต์ที่เหมาะสมได้และพารามิเตอร์ boolean `allowCloneMissingLayout` ของเมธอด `AddClone` ตั้งเป็น true จะใช้เลเอาต์ของสไลด์ต้นฉบับ มิฉะนั้นจะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) 
{{% /alert %}}

หากต้องการให้สไลด์ในผลลัพธ์มีเลเอาต์ที่แตกต่างกันให้ใช้เมธอด [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) แทนเมื่อทำการผสาน

## **ผสานสไลด์เฉพาะจากการนำเสนอ**

การผสานสไลด์เฉพาะจากหลายการนำเสนอเป็นประโยชน์สำหรับการสร้างชุดสไลด์ตามต้องการ Aspose.Slides C++ ให้คุณเลือกและนำเข้าสไลด์ที่ต้องการเท่านั้น API จะรักษาการจัดรูปแบบ เลเอาต์ และการออกแบบของสไลด์ต้นฉบับ

โค้ด C++ ตัวอย่างสร้างการนำเสนอใหม่ เพิ่มสไลด์หัวเรื่องจากสองการนำเสนออื่น ๆ และบันทึกผลลัพธ์เป็นไฟล์:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ประกาศในโค้ดด้านบน.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **ผสานการนำเสนอด้วย Slide Layout**

โค้ด C++ นี้แสดงวิธีรวมสไลด์จากการนำเสนอพร้อมประยุกต์เลเอาต์สไลด์ที่คุณต้องการให้ได้ผลลัพธ์เป็นการนำเสนอไฟล์เดียว:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **ผสานการนำเสนอที่มีขนาดสไลด์ต่างกัน**

{{% alert title="Note" color="warning" %}} 
คุณไม่สามารถผสานการนำเสนอที่มีขนาดสไลด์ต่างกันได้ 
{{% /alert %}}

เพื่อผสานการนำเสนอ 2 รายการที่มีขนาดสไลด์ต่างกัน คุณต้องปรับขนาดหนึ่งการนำเสนอให้ตรงกับการนำเสนออื่น

ตัวอย่างโค้ดแสดงการทำงานดังกล่าว:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **ผสานสไลด์ไปยังส่วนของการนำเสนอ**

โค้ด C++ นี้แสดงวิธีผสานสไลด์เฉพาะไปยังส่วนในการนำเสนอ:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

สไลด์จะถูกเพิ่มที่ส่วนท้ายของเซคชัน

{{% alert title="Tip" color="info" %}}
Aspose มีแอปเว็บ [FREE Collage](https://products.aspose.app/slides/th/collage) ให้บริการออนไลน์ คุณสามารถผสาน [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ 
{{% /alert %}}

## **FAQ**

### มีการเก็บบันทึกพูดของผู้บรรยายไว้หลังการผสานหรือไม่?

ใช่ เมื่อคัดลอกสไลด์ Aspose.Slides จะคัดลอกองค์ประกอบสไลด์ทั้งหมดรวมถึงโน้ต, การจัดรูปแบบและแอนิเมชันด้วย

### ความคิดเห็นและผู้เขียนของความคิดเห็นถูกถ่ายโอนไปหรือไม่?

ความคิดเห็นเป็นส่วนหนึ่งของเนื้อหาสไลด์จะถูกคัดลอกพร้อมสไลด์ ป้ายชื่อผู้เขียนความคิดเห็นจะคงอยู่เป็นวัตถุความคิดเห็นในไฟล์ผลลัพธ์

### ถ้าการนำเสนอต้นทางถูกป้องกันด้วยรหัสผ่านจะทำอย่างไร?

ต้อง [เปิดด้วยรหัสผ่าน](/slides/th/cpp/password-protected-presentation/) ผ่านเมธอด [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) หลังจากโหลดแล้ว สามารถคัดลอกสไลด์เหล่านั้นเข้าสู่ไฟล์เป้าหมายที่ไม่มีการป้องกัน (หรือไฟล์ที่มีการป้องกันได้เช่นกัน)

### การผสานนี้ปลอดภัยต่อการทำงานหลายเธรดแค่ไหน?

ห้ามใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เดียวกันจากหลายเธรด คำแนะนำที่แนะนำคือ “เอกสารหนึ่ง—เธรดหนึ่ง”; สามารถประมวลผลไฟล์ต่าง ๆ ควบคู่กันได้ในเธรดแยกกัน