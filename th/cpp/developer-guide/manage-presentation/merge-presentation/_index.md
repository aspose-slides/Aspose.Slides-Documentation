---
title: รวมงานนำเสนออย่างมีประสิทธิภาพใน C++
linktitle: รวมงานนำเสนอ
type: docs
weight: 40
url: /th/cpp/merge-presentation/
keywords:
- รวม PowerPoint
- รวมงานนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- รวม PowerPoint
- รวมงานนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- C++
- Aspose.Slides
description: "เรียนรู้วิธีรวมงานนำเสนอ PowerPoint และ OpenDocument ใน C++ ด้วยการทำสำเนาสไลด์ การควบคุมมาสเตอร์และเลเอาต์ การปรับขนาดเนื้อหาสไลด์ การคงส่วนต่าง ๆ และการจัดการไฟล์ที่มีการป้องกันหรือขนาดใหญ่"
---
## **ภาพรวม**

Aspose.Slides for C++ รวมการนำเสนอโดยการทำสำเนาสไลด์จาก [การนำเสนอ](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) หนึ่งไปยังอีกอันหนึ่ง การดำเนินการหลักคือ [ISlideCollection::AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/)、ซึ่งสามารถคงรูปแบบของสไลด์ต้นฉบับหรือแนบสไลด์ที่ทำสำเนาไปยังมาสเตอร์หรือเลเอาต์ในงานนำเสนอปลายทางได้

บทความนี้ครอบคลุมการทำงานการรวมที่พบบ่อยที่สุด:

- รวมสไลด์ทั้งหมดพร้อมคงรูปแบบต้นฉบับ;
- รวมสไลด์ที่เลือก;
- ใช้มาสเตอร์จากงานนำเสนอปลายทาง;
- ใช้เลเอาต์เฉพาะจากงานนำเสนอปลายทาง;
- ทำให้ขนาดสไลด์ต่างกันสอดคล้องก่อนทำการรวม;
- เพิ่มสไลด์ที่ทำสำเนาไปยังส่วน (section);
- รวมหลายงานนำเสนอในกระบวนการต่อเนื่องหนึ่งขั้น;
- จัดการมาสเตอร์, แหล่งข้อมูล, โน้ต, คอมเมนต์, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และข้อควรระวังเรื่องการทำงานหลายเธรด

## **ผลของการทำสำเนาสไลด์ต่อมาสเตอร์และเลเอาต์**

สไลด์สืบทอดรูปลักษณ์ส่วนใหญ่จากเลเอาต์และมาสเตอร์ ดังนั้นโอเวอร์โหลดการทำสำเนาที่คุณเลือกจะกำหนดว่าสตลด์ที่รวมจะถูกผนวกเข้ากับงานนำเสนอปลายทางอย่างไร

ใช้ [ISlideCollection::AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ในหนึ่งในวิธีต่อไปนี้:

- `AddClone(sourceSlide)` — คงเลเอาต์และรูปแบบของสไลด์ต้นฉบับ เมื่อจำเป็น มาสเตอร์ต้นฉบับจะถูกทำสำเนาไปยังงานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่ทำสำเนาอัตโนมัติเพื่อไม่ให้สไลด์ที่ใช้มาสเตอร์เดียวกันทำการทำสำเนามาสเตอร์ซ้ำ ๆ
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — แนบสไลด์ที่ทำสำเนาไปยัง [IMasterSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/) ปลายทางที่ระบุ Aspose.Slides จะค้นหาเลเอาต์ที่ตรงกันภายใต้มาสตานั้นตามประเภทหรือชื่อของเลเอาต์
- `AddClone(sourceSlide, destinationLayout)` — แนบสไลด์ที่ทำสำเนาโดยตรงไปยัง [ILayoutSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/) ปลายทางที่ระบุ

มาสเตอร์หรือเลเอาต์ที่ส่งให้โอเวอร์โหลด `AddClone` ต้องเป็นของ **งานนำเสนอปลายทาง** ไม่ใช่ของงานนำเสนอแหล่ง

## **รวมงานนำเสนอทั้งหมดและคงรูปแบบต้นฉบับ**

การรวมที่ง่ายที่สุดคือคัดลอกทุกสไลด์จากงานนำเสนอแหล่งไปยังงานนำเสนอปลายทาง วิธีนี้เหมาะเมื่อสไลด์ที่นำเข้าต้องคงธีม, มาสเตอร์, และความสัมพันธ์ของเลเอาต์เดิมไว้

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

ผลลัพธ์อาจมีหลายมาสเตอร์เมื่องานนำเสนอแหล่งและปลายทางใช้การออกแบบที่แตกต่างกัน สิ่งนี้เป็นเรื่องปกติเมื่อต้องคงรูปแบบต้นฉบับไว้โดยเจตนา

## **รวมสไลด์ที่เลือก**

คุณไม่จำเป็นต้องทำสำเนาทุกสไลด์ ตัวอย่างต่อไปนี้จะนำเข้าตำแหน่งสไลด์ที่เลือกจากงานนำเสนอแหล่งเท่านั้น

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

ตรวจสอบตำแหน่งสไลด์ก่อนทำสำเนาเมื่อตำแหน่งมาจากผู้ใช้หรือการกำหนดค่าภายนอก

## **รวมสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้โอเวอร์โหลด [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) เมื่อสไลด์ที่นำเข้าต้องใช้มาสเตอร์ที่มีอยู่แล้วในงานนำเสนอปลายทาง

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

Aspose.Slides จะเลือกเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยจับคู่ประเภทหรือชื่อของเลเอาต์ต้นฉบับ หากไม่มีเลเอาต์ที่เหมาะสมและ `allowCloneMissingLayout` เป็น `true` เลเอาต์ต้นฉบับจะถูกทำสำเนาเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `false` จะเกิด [PptxEditException](https://reference.aspose.com/slides/th/cpp/aspose.slides/details_pptxeditexception/) ขึ้น

ใช้ `false` หากต้องการให้การรวมล้มเหลวแทนที่จะเพิ่มเลเอาต์เพิ่มเติมในมาสเตอร์ปลายทาง

## **รวมสไลด์โดยใช้เลเอาต์ปลายทางเฉพาะ**

ใช้โอเวอร์โหลด [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) เมื่อคุณทราบเลเอาต์ปลายทางที่สไลด์นำเข้าต้องใช้อย่างแน่นอน

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

การใช้เลเอาต์ปลายทางจะเปลี่ยนความสัมพันธ์ของเลเอาต์ที่สืบทอด แต่ไม่ได้ออกแบบเนื้อหาของสไลด์ต้นฉบับใหม่ หากเลเอาต์ต้นฉบับและปลายทางมีโครงสร้าง placeholder ที่แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรม placeholder ที่สืบทอดนั้นเหมาะสม

## **รวมงานนำเสนอที่มีขนาดสไลด์ต่างกัน**

งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถรวมกันได้ แต่การทำสำเนาสไลด์ไปยังงานนำเสนอที่มีขนาดสไลด์อื่นจะไม่ทำการออกแบบเนื้อหาใหม่อัตโนมัติสำหรับขนาดผืนผ้าใบใหม่ รูปร่างอาจปรากฏโดยการย้าย, ขยายผิดพลาด, หรืออยู่นอกพื้นที่สไลด์ที่มองเห็นได้

วิธีปฏิบัติง่าย ๆ คือปรับขนาดงานนำเสนอแหล่งก่อนทำสำเนา วิธี [SlideSize::SetSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidesize/setsize/) สามารถสเกลเนื้อหาที่มีอยู่พร้อมกับเปลี่ยนขนาดสไลด์ได้ [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ร้องขอ

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

การปรับขนาดจะเปลี่ยนวัตถุงานนำเสนอแหล่งในหน่วยความจำ หากคุณต้องการให้งานนำเสนอแหล่งต้นฉบับคงเดิมสำหรับการดำเนินการอื่น ๆ ให้เปิดอินสแตนซ์แยกออกสำหรับการรวม

## **รวมสไลด์เข้าส่วนของงานนำเสนอ**

ลูปการทำสำเนาสไลด์พื้นฐานจะไม่สร้างโครงสร้างส่วนของงานนำเสนอแหล่งใหม่ หากส่วน (section) มีความสำคัญในผลลัพธ์ ให้สร้างหรือเลือกส่วนในงานนำเสนอปลายทางและทำสำเนาสไลด์เข้าไปโดยเจาะจงด้วย [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/)

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

สไลด์ที่ทำสำเนาจะถูกเพิ่มต่อท้ายส่วนปลายทางที่ระบุ เพื่อคงหลายส่วนของแหล่ง ให้วนลูป [Presentation::get_Sections](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_sections/), ดึงสไลด์ปัจจุบันของแต่ละส่วนแหล่งด้วย [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/th/cpp/aspose.slides/isection/getslideslistofsection/), สร้างส่วนในปลายทางใหม่ และทำสำเนาสไลด์ที่ส่งคืนเข้าสู่ส่วนปลายทางที่สอดคล้องกัน ดูตัวอย่างการจัดการส่วนสไลด์เต็มรูปแบบที่ [Manage Slide Sections](/slides/th/cpp/slide-section/) ซึ่งรวมส่วนว่างและการเปลี่ยนแปลงโครงสร้าง

## **รวมหลายงานนำเสนออย่างปลอดภัย**

ตัวอย่างต่อไปนี้เป็นกระบวนการต่อเนื่องแบบครบวงจร ใช้งานนำเสนอแรกเป็นปลายทาง, ทำให้ขนาดสไลด์ของแหล่งแต่ละอันสอดคล้อง, เปิดแต่ละแหล่งเฉพาะเมื่อทำการคัดลอก, และบันทึกไฟล์สุดท้ายเมื่อเสร็จ

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

นี่เป็นจุดเริ่มต้นที่มีประโยชน์สำหรับการคงรูปแบบต้นฉบับของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ธีมเดียวของปลายทาง ให้แทนที่การเรียก `AddClone(slide)` ง่าย ๆ ด้วยโอเวอร์โหลดมาสเตอร์หรือเลเอาต์ปลายทางที่แสดงในส่วนก่อนหน้า

## **ข้อพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลเอาต์, และความแม่นยำของการจัดรูปแบบ**

การทำสำเนาสไลด์ตามค่าเริ่มต้นสามารถนำมาสเตอร์ที่จำเป็นจากแหล่งเข้าไปในงานนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บทะเบียนภายในสำหรับมาสเตอร์ที่ทำสำเนาอัตโนมัติเพื่อหลีกเลี่ยงการทำสำเนามาสเตอร์เดียวกันซ้ำ ๆ มาสเตอร์ที่ทำสำเนาแบบแมนนวลจะไม่ได้รับการบันทึกในทะเบียนนั้น ดังนั้นควรหลีกเลี่ยงการทำสำเนามาสเตอร์ล่วงหน้า เว้นแต่คุณต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่าเพิ่งสรุปว่ามาสเตอร์หรือเลเอาต์ที่มีชื่อเดียวกันจะดูเหมือนกันในเชิงภาพ หากเทมเพลตองค์กรต้องควบคุมรูปลักษณ์สุดท้าย ให้เลือกมาสเตอร์หรือเลเอาต์ปลายทางอย่างเจาะจงและตรวจสอบผลลัพธ์หลังการรวม

### **โน้ตและคอมเมนต์**

โน้ตของผู้พูดและคอมเมนต์สไลด์เชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อสไลด์ถูกทำสำเนา Aspose.Slides ยังมี API เฉพาะสำหรับ [โน้ตของงานนำเสนอ](/slides/th/cpp/presentation-notes/) และ [คอมเมนต์ของงานนำเสนอ](/slides/th/cpp/presentation-comments/)

หากการจัดรูปแบบของหน้าโน้ตสำคัญ ให้ตรวจสอบงานนำเสนอที่รวมแล้ว เนื่องจากโน้ตมาสเตอร์เป็นวัตถุระดับงานนำเสนอและอาจต่างกันระหว่างไฟล์แหล่ง สำหรับกระบวนการตรวจสอบ ให้ตรวจสอบผู้เขียนคอมเมนต์และคอมเมนต์แบบเชื่อมโยงหลังจากรวมไฟล์จากผู้เขียนหรือเทมเพลตต่างกัน

### **รูปภาพ, เสียง, วิดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์อาจอ้างอิงแหล่งทรัพยากรระดับงานนำเสนอเช่นรูปภาพ, เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ให้ทำสำเนาสไลด์ทั้งหมดแทนการคัดลอกรูปทรงที่มองเห็นเท่านั้น เพื่อให้ Aspose.Slides รักษาความสัมพันธ์ของสไลด์ต่อทรัพยากรเหล่านั้น

แหล่งทรัพยากรที่ฝังและที่เชื่อมโยงควรจัดการแตกต่างกัน เสียง, วิดีโอ, วัตถุ OLE หรือไฮเพอร์ลิงก์ที่เชื่อมโยงยังคงพึ่งพาเป้าหมายภายนอก; การทำสำเนาสไลด์จะไม่เปลี่ยนลิงก์ภายนอกให้เป็นเนื้อหาฝัง ตรวจสอบเส้นทางและ URL ของแหล่งที่เชื่อมโยงในสภาพแวดล้อมที่งานนำเสนอที่รวมจะถูกเปิด

Aspose.Slides ติดตามมาสเตอร์ที่ทำสำเนาอัตโนมัติ แต่ไม่ควรถือว่าเป็นการรับประกันทั่วไปว่าแหล่งไบนารีที่เหมือนกันจากงานนำเสนอแหล่งที่ไม่มีความสัมพันธ์จะถูกลบซ้ำเสมอ หากขนาดไฟล์ผลลัพธ์มีความสำคัญ ให้ตรวจสอบแพ็กเกจที่รวมและวัดผลโดยตรงแทนการพึ่งพาการลบซ้ำโดยนัย

### **ฟอนต์ฝังและความพร้อมใช้งานของฟอนต์**

ฟอนต์ถูกจัดการระดับงานนำเสนอ หากต้องการให้การพิมพ์มีความสอดคล้องระหว่างเครื่อง อย่างใจว่าแค่การทำสำเนาสไลด์ไม่ได้รับประกันว่าฟอนต์ที่ต้องการทั้งหมดจะพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ฝังด้วย [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getembeddedfonts/) และจัดการการฝังอย่างเจาะจงตามที่อธิบายใน [ฝังฟอนต์ในงานนำเสนอ](/slides/th/cpp/embedded-font/)

นอกจากนี้ยังต้องตรวจสอบว่าคุณได้รับอนุญาตให้ฝังฟอนต์ที่ใช้ในไฟล์แหล่งหรือไม่ เนื่องจากสัญญาอนุญาตฟอนต์อาจจำกัดการฝัง

### **งานนำเสนอที่มีรหัสผ่าน**

งานนำเสนอแหล่งที่มีรหัสผ่านต้องเปิดสำเร็จก่อนจึงจะทำการทำสำเนาสไลด์ได้ ให้ใส่รหัสผ่านผ่าน [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/)

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

การเปิดไฟล์ที่เข้ารหัสไม่ทำให้การปกป้องเดียวกันถูกนำไปใช้กับงานนำเสนอปลายทาง ตั้งค่าการปกป้องผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **งานนำเสนอขนาดใหญ่และการใช้หน่วยความจำ**

งานนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, เสียง, วิดีโอ, หรือวัตถุไบนารีขนาดใหญ่อาจใช้หน่วยความจำมาก [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) ให้ตัวเลือกสำหรับการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [จัดการ BLOB ของงานนำเสนอ](/slides/th/cpp/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ใหญ่ ควรโหลดจากเส้นทางไฟล์เมือเป็นไปได้, ปลดปล่อยงานนำเสนอแหล่งแต่ละอันทันทีหลังการรวม, และหลีกเลี่ยงการบันทึกผลลัพธ์กลางหลาย ๆ ครั้ง เว้นแต่กระบวนการต้องการจุดตรวจสอบ

### **ความปลอดภัยในการทำงานหลายเธรด**

อย่าลoad, แก้ไข, บันทึก, หรือทำสำเนาอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เดียวพร้อมกันจากหลายเธรด เก็บอินสแตนซ์ของแต่ละงานนำเสนอให้จำกัดอยู่ในหนึ่งกระบวนการรวม หากคุณทำงานแบบขนานหลายงาน ควรใช้อินสแตนซ์งานนำเสนอแยกกันและปฏิบัติตาม [แนวทางการทำงานหลายเธรดของ Aspose.Slides](/slides/th/cpp/multithreading/)

## **คำถามที่พบบ่อย**

**ฉันจะรักษาการออกแบบเดิมของงานนำเสนอแหล่งได้อย่างไร?**

ใช้ [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) โดยไม่ระบุมาสเตอร์หรือเลเอาต์ปลายทาง Aspose.Slides สามารถทำสำเนามาสเตอร์แหล่งโดยอัตโนมัติเมื่อต้องการโดยสไลด์ที่นำเข้า

**ทำอย่างไรให้สไลด์ที่นำเข้าใช้ธีมของปลายทาง?**

ใช้โอเวอร์โหลดที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากงานนำเสนอปลายทาง ไม่ใช่จากแหล่ง Aspose.Slides จะพยายามแมปสไลด์แหล่งแต่ละอันกับเลเออต์ที่เหมาะสมภายใต้มาสเตอร์นั้น

**เมื่อใดควรใช้เลเอาต์ปลายทางเฉพาะแทนมาสเตอร์ปลายทาง?**

ใช้เลเอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกอันต้องใช้เลเอาต์ที่รู้จักล่วงหน้า ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกเลเอาต์จากมาสเตอร์นั้นตามประเภทหรือชื่อของเลเอาต์แหล่ง

**งานนำเสนอที่มีขนาดสไลด์ต่างกันสามารถรวมกันได้หรือไม่?**

ได้ แต่เนื้อหาสไลด์จะไม่ได้ออกแบบใหม่อัตโนมัติสำหรับมุมมองปลายทาง ปรับขนาดงานนำเสนอแหล่งก่อนเมื่อคุณต้องการตำแหน่งที่คาดเดาได้ เช่นใช้ [SlideSize::SetSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidesize/setsize/) และ [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidesizescaletype/)

**ฉันสามารถรวมไฟล์ PPT, PPTX, และ ODP เป็นไฟล์เดียวได้หรือไม่?**

ได้ เปิดงานนำเสนอแหล่งแต่ละไฟล์, ทำสำเนาสไลด์ที่ต้องการเข้าสู่ปลายทางหนึ่ง, แล้วบันทึกปลายทางในรูปแบบที่รองรับ เนื่องจากรูปแบบงานนำเสนอไม่ได้สนับสนุนคุณลักษณะเดียวกันทั้งหมด จึงควรตรวจสอบเนื้อหาที่ซับซ้อนหลังการรวมข้ามรูปแบบ ดู [รูปแบบไฟล์ที่รองรับ](/slides/th/cpp/supported-file-formats/)

**ส่วนของแหล่งจะถูกเก็บอัตโนมัติหรือไม่?**

ไม่ได้จากลูปพื้นฐานที่ทำสำเนาเฉพาะสไลด์ ให้สร้างส่วนที่ต้องการในปลายทางและใช้โอเวอร์โหลดส่วนของ [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) เมื่อโครงสร้างส่วนต้องการคงไว้

**โน้ตและคอมเมนต์จะถูกเก็บไว้หรือไม่?**

พวกมันจะถูกคัดลอกพร้อมสไลด์ที่ทำสำเนา สำหรับกระบวนการทำงานที่พึ่งพาการสไตลิ่งของโน็ตรมาสเตอร์, ผู้เขียนคอมเมนต์, หรือข้อมูลการตรวจสอบแบบเชื่อมโยง ให้ตรวจสอบผลลัพธ์ที่รวมเนื่องจากสถานการณ์เหล่านี้เกี่ยวข้องกับโครงสร้างระดับงานนำเสนอและระดับสไลด์

**จะเกิดอะไรขึ้นกับเสียง, วิดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์?**

เนื้อหาฝังจะถูกนำมาพร้อมกับความสัมพันธ์ของทรัพยากรสไลด์ที่ทำสำเนา ลิงก์ภายนอกยังคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL ปลายทางต้องยังคงพร้อมใช้งานหลังการรวม

**ฟอนต์ที่ฝังจากทุกแหล่งจะได้รับการรับประกันว่าอยู่ในงานนำเสนอที่รวมหรือไม่?**

不要依赖仅仅克隆幻灯片来部署字体。检查目标文件中嵌入的字体，并在排版重要时明确管理字体嵌入或外部字体可用性。

**ฉันจะรวมไฟล์ที่มีรหัสผ่านได้อย่างไร?**

ใช้ [LoadOptions::set_Password](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_password/) เพื่อเปิดไฟล์ด้วยรหัสผ่านที่ถูกต้อง แล้วทำสำเนาสไลด์ตามปกติ การตั้งค่าการปกป้องผลลัพธ์ทำแยกต่างหาก

**ฉันควรจัดการกับงานนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีขนาดใหญ่ครอบงำหน่วยความจำ, พักโหลดจากเส้นทางไฟล์สำหรับไฟล์ขนาดใหญ่อย่างเป็นไปได้, ปลดปล่อยงานนำเสนอแหล่งทันทีหลังการรวม, และบันทึกผลลัพธ์ขั้นสุดท้ายเมื่อจำเป็นเท่านั้น

**ฉันสามารถทำการรวมสไลด์จากหลายเธรดได้หรือไม่?**

不要同时使用同一个 [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 实例在多个线程中进行加载、修改、保存或克隆。保持每个合并操作使用独立的实例。如果并行处理独立的任务，请为每个任务使用独立的实例，并遵循 [Aspose.Slides 多线程指南](/slides/th/cpp/multithreading/)。