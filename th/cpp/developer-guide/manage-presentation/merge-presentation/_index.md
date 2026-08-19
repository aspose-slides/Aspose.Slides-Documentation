---
title: "รวมงานนำเสนออย่างมีประสิทธิภาพใน C++"
linktitle: "รวมงานนำเสนอ"
type: docs
weight: 40
url: /th/cpp/merge-presentation/
keywords:
- "รวม PowerPoint"
- "รวมงานนำเสนอ"
- "รวมสไลด์"
- "รวม PPT"
- "รวม PPTX"
- "รวม ODP"
- "รวม PowerPoint"
- "รวมงานนำเสนอ"
- "รวมสไลด์"
- "รวม PPT"
- "รวม PPTX"
- "รวม ODP"
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการรวมงานนำเสนอ PowerPoint และ OpenDocument ใน C++ ด้วยการคัดลอกสไลด์, การควบคุมมาสเตอร์และเลย์เอาต์, การปรับขนาดเนื้อหาสไลด์, การคงส่วน, และการจัดการไฟล์ที่มีการป้องกันหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for C++ ผสานการนำเสนอโดยการคัดลอกสไลด์จากหนึ่ง [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ไปยังอีกอันหนึ่ง การดำเนินการหลักคือ [ISlideCollection::AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ซึ่งสามารถคงรูปแบบของสไลด์ต้นฉบับหรือแนบสไลด์ที่คัดลอกไปยังมาสเตอร์หรือเลย์เอาต์ในงานนำเสนอปลายทางได้

บทความนี้ครอบคลุมกระบวนการผสานที่พบมากที่สุด:

- ผสานสไลด์ทั้งหมดพร้อมคงรูปแบบต้นฉบับ  
- ผสานสไลด์ที่เลือกเท่านั้น  
- ใช้มาสเตอร์จากงานนำเสนอปลายทาง  
- ใช้เลย์เอาต์เฉพาะจากงานนำเสนอปลายทาง  
- ทำให้ขนาดสไลด์ต่างกันสม่ำเสมอก่อนผสาน  
- เพิ่มสไลด์ที่คัดลอกเข้าไปในส่วน (section)  
- ผสานหลายงานนำเสนอในขั้นตอนทำงานแบบปลายทางถึงปลายทาง  
- จัดการมาสเตอร์, ทรัพยากร, โน้ต, ความคิดเห็น, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และข้อกังวลเรื่องการทำงานหลายเธรด

## **ผลของการคัดลอกสไลด์ต่อมาสเตอร์และเลย์เอาต์**

สไลด์สืบทอดลักษณะหลายอย่างจากเลย์เอาต์และมาสเตอร์ด้วยเหตุนี้ การเลือกรูปแบบการคัดลอก (overload) จะกำหนดวิธีที่สไลด์ที่ผสานจะถูกผสานเข้าไปในงานนำเสนอปลายทาง

ใช้ [ISlideCollection::AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ในหนึ่งในรูปแบบต่อไปนี้:

- `AddClone(sourceSlide)` — คงเลย์เอาต์และรูปแบบของสไลด์ต้นฉบับ เมื่อจำเป็น มาสเตอร์ต้นฉบับจะถูกคัดลอกเข้าไปในงานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่คัดลอกอัตโนมัติไว้เพื่อไม่ให้สไลด์ที่ใช้มาสเตอร์เดียวกันทำการคัดลอกมาสเตอร์ซ้ำหลายครั้ง  
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่คัดลอกไปยัง [IMasterSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/) ปลายทางที่ระบุ Aspose.Slides จะค้นหาเลย์เอาต์ที่ตรงกันภายใต้มาสเตอร์นั้นโดยใช้ประเภทหรือชื่อของเลย์เอาต์  
- `AddClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่คัดลอกโดยตรงไปยัง [ILayoutSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/) ปลายทางที่ระบุ

มาสเตอร์หรือเลย์เอาต์ที่ส่งเข้า overload ของ `AddClone` ต้องเป็นของ **งานนำเสนอปลายทาง** ไม่ใช่งานนำเสนอต้นฉบับ

## **ผสานงานนำเสนอทั้งหมดและคงรูปแบบต้นฉบับ**

การผสานแบบง่ายที่สุดคือคัดลอกทุกสไลด์จากงานนำเสนอต้นฉบับไปยังงานนำเสนอปลายทาง นี่เป็นตัวเลือกที่เหมาะสมเมื่อสไลด์ที่นำเข้าต้องการคงธีม, มาสเตอร์, และความสัมพันธ์ของเลย์เอาต์เดิมไว้

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

งานนำเสนอผลลัพธ์อาจมีมาสเตอร์หลายชุดเมื่อทั้งต้นฉบับและปลายทางใช้ดีไซน์ที่แตกต่างกัน ซึ่งเป็นพฤติกรรมที่คาดหวังเมื่อต้องคงรูปแบบต้นฉบับไว้

## **ผสานสไลด์ที่เลือก**

คุณไม่จำเป็นต้องคัดลอกทุกสไลด์ ตัวอย่างต่อไปนี้นำเข้าเฉพาะสไลด์ตามดัชนีที่เลือกจากงานนำเสนอต้นฉบับ

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

ตรวจสอบดัชนีสไลด์ก่อนทำการคัดลอกเมื่อดัชนีมาจากการป้อนข้อมูลของผู้ใช้หรือการกำหนดค่าภายนอก

## **ผสานสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้ overload [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) เมื่อสไลด์ที่นำเข้าต้องการใช้มาสเตอร์ที่เป็นของงานนำเสนอปลายทางอยู่แล้ว

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides จะเลือกเลย์เอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยอิงจากประเภทหรือชื่อของเลย์เอาต์ต้นฉบับ หากไม่มีเลย์เอาต์ที่เหมาะสมและ `allowCloneMissingLayout` เป็น `true` เลย์เอาต์ต้นฉบับจะถูกคัดลอกเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `false` จะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/cpp/aspose.slides/details_pptxeditexception/)

ใช้ค่า `false` เมื่อต้องการให้การผสานล้มเหลวแทนการเพิ่มเลย์เอาต์ใหม่เข้าไปในมาสเตอร์ปลายทาง

## **ผสานสไลด์โดยใช้เลย์เอาต์ปลายทางเฉพาะ**

ใช้ overload [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) เมื่อคุณทราบแน่ชัดว่าเลย์เอาต์ปลายทางใดที่สไลด์ที่นำเข้าต้องใช้

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

การใช้เลย์เอาต์ปลายทางเปลี่ยนความสัมพันธ์ของเลย์เอาต์ที่สืบทอด; มันไม่ได้ปรับออกแบบเนื้อหาสไลด์ต้นฉบับ หากเลย์เอาต์ต้นฉบับและปลายทางมีโครงสร้าง placeholder ที่แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรม placeholder ที่สืบทอดนั้นเหมาะสม

## **ผสานงานนำเสนอที่มีขนาดสไลด์ต่างกัน**

งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถผสานได้ แต่การคัดลอกสไลด์ไปยังงานนำเสนอที่มีขนาดสไลด์แตกต่างกันจะไม่ทำการออกแบบเนื้อหาใหม่อัตโนมัติสำหรับพิมพ์เขียวขนาดใหม่ รูปร่างอาจถูกเลื่อน, ขยายหรืออยู่ข้างนอกพื้นที่มองเห็นของสไลด์

วิธีที่เป็นประโยชน์คือการปรับขนาดงานนำเสนอต้นฉบับก่อนทำการคัดลอก วิธี [SlideSize::SetSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidesize/setsize/) สามารถสเกลเนื้อหาที่มีอยู่พร้อมกับการเปลี่ยนขนาดสไลด์ได้ [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ต้องการ

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

การปรับขนาดจะเปลี่ยนวัตถุงานนำเสนอต้นฉบับในหน่วยความจำ หากคุณต้องการให้งานนำต้นฉบับยังคงอยู่ไม่เปลี่ยนแปลงสำหรับการดำเนินการอื่น ๆ ให้เปิดอินสแตนซ์แยกสำหรับการผสาน

## **ผสานสไลด์เข้าไปยัง Section ของงานนำเสนอ**

ลูปคัดลอกสไลด์พื้นฐานจะไม่สร้างโครงสร้าง Section ของงานนำเสนอต้นฉบับ หากต้องการให้ Section มีผลในผลลัพธ์ ให้สร้างหรือเลือก Section ในงานนำเสนอปลายทางและคัดลอกสไลด์เข้าไปในนั้นโดยใช้ [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/)

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

สไลด์ที่คัดลอกจะถูกเพิ่มต่อท้ายใน Section ปลายทางที่ระบุ เพื่อคงหลาย Section ของต้นฉบับ ให้สร้าง Section เหล่านั้นในปลายทางและแมปสไลด์ต้นฉบับแต่ละสไลด์ไปยัง Section ปลายทางที่สอดคล้องกัน

## **ผสานหลายงานนำเสนออย่างปลอดภัย**

ตัวอย่างขั้นตอนทำงานแบบปลายทางถึงปลายทางต่อไปนี้ใช้งานนำเสนอแรกเป็นปลายทาง, ปรับขนาดสไลด์ของแต่ละแหล่งข้อมูลเพิ่มเติม, เปิดแต่ละแหล่งข้อมูลเฉพาะเมื่อทำการคัดลอก, และบันทึกไฟล์สุดท้ายเพียงครั้งเดียว

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

นี่เป็นพื้นฐานที่มีประโยชน์สำหรับการคงรูปแบบต้นฉบับของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ธีมเดียวของปลายทาง ให้แทนที่การเรียก `AddClone(slide)` ง่าย ๆ ด้วย overload มาสเตอร์หรือเลย์เอาต์ปลายทางที่แสดงไว้ก่อนหน้านี้

## **ข้อควรพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลย์เอาต์, และความแม่นยำของการจัดรูปแบบ**

การคัดลอกสไลด์แบบเริ่มต้นสามารถนำมาสเตอร์ต้นฉบับที่จำเป็นเข้าสู่งานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บทะเบียนภายในสำหรับมาสเตอร์ที่คัดลอกอัตโนมัติเพื่อหลีกเลี่ยงการคัดลอกมาสเตอร์เดียวซ้ำหลายครั้ง มาสเตอร์ที่คัดลอกด้วยตนเองจะไม่ถูกติดตามโดยทะเบียนนั้น ดังนั้นหลีกเลี่ยงการคัดลอกมาสเตอร์ล่วงหน้า เว้นแต่คุณต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่ assuming ว่ามาสเตอร์หรือเลย์เอาต์สองชุดที่มีชื่อเดียวกันจะแสดงผลเหมือนกัน หากเทมเพลตองค์กรต้องควบคุมรูปลักษณ์สุดท้าย ให้เลือกมาสเตอร์หรือเลย์เอาต์ปลายทางอย่างเจาะจงและตรวจสอบผลหลังการผสาน

### **โน้ตและความคิดเห็น**

โน้ตของผู้นำเสนอและความคิดเห็นของสไลด์เชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อสไลด์ถูกคัดลอก Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](https://docs.aspose.com/slides/th/cpp/presentation-notes/) และ [presentation comments](https://docs.aspose.com/slides/th/cpp/presentation-comments/)

หากรูปแบบของหน้าโน้ตสำคัญ ให้ตรวจสอบงานนำเสนอที่ผสานแล้ว เนื่องจากโน้ตมาสเตอร์เป็นอ็อบเจกต์ระดับงานนำเสนอและอาจแตกต่างระหว่างไฟล์ต้นฉบับ สำหรับกระบวนการตรวจทาน ให้ตรวจสอบผู้เขียนความคิดเห็นและเธรดของความคิดเห็นหลังจากรวมไฟล์จากผู้เขียนหรือเทมเพลตต่าง ๆ

### **รูปภาพ, เสียง, วีดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์อาจอ้างอิงทรัพยากรระดับงานนำเสนอเช่นรูปภาพ, เสียงฝัง, วีดีโอฝัง, และข้อมูล OLE ให้คัดลอกสไลด์เองแทนการคัดลอกเฉพาะรูปร่างที่มองเห็น เพื่อให้ Aspose.Slides คงความสัมพันธ์ของสไลด์กับทรัพยากรเหล่านั้นได้

ทรัพยากรที่ฝังและที่ลิงก์ควรจัดการแยกกัน เสียง, วีดีโอ, วัตถุ OLE หรือไฮเปอร์ลิงก์ที่ลิงก์อยู่ยังคงพึ่งพาแหล่งภายนอก; การคัดลอกสไลด์ไม่ได้เปลี่ยนลิงก์ภายนอกให้กลายเป็นเนื้อหาที่ฝังไว้ ตรวจสอบเส้นทางและ URL ของทรัพยากรที่ลิงก์ในสภาพแวดล้อมที่งานนำเสนอที่ผสานจะถูกเปิด

Aspose.Slides ติดตามมาสเตอร์ที่คัดลอกอัตโนมัติ แต่ไม่ควรถือว่าเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากแหล่งต้นฉบับที่ไม่เกี่ยวข้องจะถูกทำสำเนาอัตโนมัติ หากขนาดไฟล์ผลลัพธ์สำคัญ ให้ตรวจสอบแพคเกจที่ผสานและวัดผลลัพธ์แทนการพึ่งพาการทำสำเนาโดยอ้อม

### **ฟอนต์ที่ฝังและความพร้อมใช้งานของฟอนต์**

ฟอนต์ถูกจัดการระดับงานนำเสนอ หากต้องการให้การจัดพิมพ์คงที่บนหลายเครื่อง อย่า assuming ว่าการคัดลอกสไลด์อย่างเดียวทำให้ฟอนต์ที่ต้องการทั้งหมดพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getembeddedfonts/) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](https://docs.aspose.com/slides/th/cpp/embedded-font/)

นอกจากนี้ ตรวจสอบว่าคุณได้รับสิทธิ์ในการฝังฟอนต์ที่ใช้ในไฟล์ต้นฉบับ ใบอนุญาตฟอนต์บางประเภทอาจจำกัดการฝังได้

### **งานนำเสนอที่มีรหัสผ่าน**

ไฟล์ต้นฉบับที่มีรหัสผ่านต้องเปิดสำเร็จก่อนจึงจะคัดลอกสไลด์ได้ ให้ส่งรหัสผ่านผ่าน [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/)

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

การเปิดไฟล์ที่เข้ารหัสไม่ได้ทำให้การป้องกันเดียวกันถูกนำไปใช้กับงานนำเสนอปลายทาง เพียงกำหนดการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **งานนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

งานนำเสนอขนาดใหญ่ที่มีภาพความละเอียดสูง, เสียง, วีดีโอ หรืออ็อบเจกต์ไบนารีขนาดใหญ่สามารถใช้หน่วยความจำอย่างมาก [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) ให้การควบคุมการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](https://docs.aspose.com/slides/th/cpp/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ขนาดใหญ่ ให้โหลดจากเส้นทางไฟล์เมื่อเป็นไปได้ ปล่อยงานนำเสนอต้นฉบับทิ้งทันทีหลังจากทำการผสานเสร็จ และหลีกเลี่ยงการบันทึกผลลัพธ์กลางหลายครั้ง เว้นแต่กระบวนการต้องการจุดตรวจสอบ

### **ความปลอดภัยเมื่อทำงานหลายเธรด**

ห้ามโหลด, แก้ไข, บันทึกหรือคัดลอกอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้จำกัดอินสแตนซ์งานนำเสนอแต่ละอันให้ทำงานผสานเพียงหนึ่งครั้ง หากต้องการประมวลผลแบบขนาน ให้ใช้อินสแตนซ์งานนำเสนอแยกกันและปฏิบัติตามคำแนะนำ [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/th/cpp/multithreading/)

## **คำถามที่พบบ่อย**

**ฉันจะรักษาการออกแบบเดิมของแต่ละงานนำเสนอได้อย่างไร?**

ใช้ [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) โดยไม่ระบุมาสเตอร์หรือเลย์เอาต์ปลายทาง Aspose.Slides สามารถคัดลอกมาสเตอร์ต้นฉบับโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ

**จะทำให้งานนำเข้าสไลด์ใช้ธีมของปลายทางได้อย่างไร?**

ใช้ overload ที่รับมาสเตอร์ปลายทาง ให้ส่งมาสเตอร์จากงานนำเสนอปลายทาง ไม่ใช่จากต้นฉบับ Aspose.Slides จะพยายามแมปสไลด์แต่ละสไลด์ไปยังเลย์เอาต์ที่เหมาะสมภายใต้มาสเตอร์นั้น

**ควรใช้เลย์เอาต์ปลายทางเฉพาะแทนมาสเตอร์ปลายทางเมื่อใด?**

ใช้เลย์เอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ต้องใช้เลย์เอาต์ที่รู้จักเดียวกัน ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกเลย์เอาต์จากมาสเตอร์นั้นตามประเภทหรือชื่อของเลย์เอาต์ต้นฉบับ

**สามารถผสานงานนำเสนอที่มีขนาดสไลด์ต่างกันได้หรือไม่?**

ทำได้ แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่อัตโนมัติเพื่อให้เข้ากับมิติปลายทาง ปรับขนาดงานนำเสนอต้นฉบับก่อนเมื่อจำเป็นต้องการตำแหน่งที่คาดการณ์ได้ เช่นใช้ [SlideSize::SetSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidesize/setsize/) และ [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidesizescaletype/)

**สามารถผสานไฟล์ PPT, PPTX, และ ODP ไว้ในไฟล์เดียวได้หรือไม่?**

ได้ เปิดแต่ละงานนำเสนอที่เป็นแหล่งข้อมูล คัดลอกสไลด์ที่ต้องการเข้าไปในงานนำเสนอปลายทางหนึ่งและบันทึกผลลัพธ์ในรูปแบบที่รองรับ เนื่องจากฟอร์แมตงานนำเสนอไม่สนับสนุนชุดฟีเจอร์เดียวกันทั้งหมด จึงควรตรวจสอบเนื้อหาซับซ้อนหลังการผสานแบบข้ามฟอร์แมต ดู [Supported File Formats](https://docs.aspose.com/slides/th/cpp/supported-file-formats/)

**ส่วนของงานนำเสนอ (Section) ของต้นฉบับจะถูกเก็บไว้โดยอัตโนมัติหรือไม่?**

ไม่โดยลูปพื้นฐานที่คัดลอกสไลด์เท่านั้น ให้สร้างส่วนที่ต้องการในงานนำเสนอปลายทางและใช้ overload ของ [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่รวม Section เมื่อโครงสร้าง Section ต้องการคงไว้

**โน้ตของผู้บรรยายและความคิดเห็นจะถูกเก็บไว้หรือไม่?**

พวกมันจะถูกคัดลอกพร้อมกับสไลด์ที่คัดลอก สำหรับกระบวนการที่ต้องอิงสไลด์มาสเตอร์ของโน้ต, ผู้เขียนความคิดเห็น หรือข้อมูลการตรวจทานแบบเธรด ให้ตรวจสอบผลลัพธ์ที่ผสาน เนื่องจากสถานการณ์เหล่านั้นเกี่ยวข้องกับโครงสร้างระดับงานนำเสนอและระดับสไลด์พร้อมกัน

**เสียง, วีดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์จะเกิดอะไรขึ้น?**

เนื้อหาที่ฝังจะติดตามมาเป็นส่วนของความสัมพันธ์ทรัพยากรของสไลด์ที่คัดลอก ลิงก์ภายนอกยังคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL ปลายทางต้องยังคงพร้อมใช้งานหลังการผสาน

**ฟอนต์ที่ฝังจากทุกแหล่งจะพร้อมใช้งานในงานนำเสนอที่ผสานแล้วหรือไม่?**

อย่าอาศัยการคัดลอกสไลด์อย่างเดียวสำหรับการจัดเตรียมฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังฟอนต์หรือความพร้อมใช้งานฟอนต์ภายนอกอย่างชัดเจนเมื่อการพิมพ์สำคัญ

**จะผสานไฟล์ที่มีรหัสผ่านอย่างไร?**

เปิดไฟล์ด้วย [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) ที่ถูกต้อง จากนั้นคัดลอกสไลด์ตามปกติ การป้องกันผลลัพธ์ต้องกำหนดแยกต่างหาก

**ควรจัดการงานนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีขนาดใหญ่เป็นภาระหลัก, โหลดจากเส้นทางไฟล์สำหรับไฟล์ขนาดใหญ่อย่างเต็มที่, ปล่อยงานนำเสนอแหล่งข้อมูลโดยเร็วหลังการผสาน, และบันทึกผลลัพธ์สุดท้ายเฉพาะเมื่อจำเป็น

**สามารถคัดลอกสไลด์จากหลายเธรดได้หรือไม่?**

ห้ามใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้แยกแต่ละการผสานเป็นอินสแตนซ์งานนำเสนอของตนเอง.