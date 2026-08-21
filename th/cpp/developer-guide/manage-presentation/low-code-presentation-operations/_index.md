---
title: การดำเนินการพรีเซนเทชันแบบ Low-Code ใน C++
linktitle: API Low-Code
type: docs
weight: 50
url: /th/cpp/low-code-presentation-operations/
keywords:
- API พรีเซนเทชันแบบ Low-Code
- แปลงพรีเซนเทชัน
- รวมพรีเซนเทชัน
- วนซ้ำสไลด์
- วนซ้ำรูปร่าง
- วนซ้ำข้อความ
- รวบรวมรูปร่าง
- บีบอัดพรีเซนเทชัน
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ที่ฝังไว้
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน C++ เพื่อแปลงและรวมพรีเซนเทชัน, วนซ้ำเนื้อหา, รวบรวมรูปร่าง, และลดขนาดพรีเซนเทชัน"
---
## **ภาพรวม**

เนมสเปซ [Aspose::Slides::LowCode](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/) ให้คลาสช่วยเหลือแบบสแตติกสำหรับการดำเนินการพรีเซนเทชันทั่วไป ตัวช่วยเหลือนี้ห่อหุ้มกระบวนการทำงานของโมเดลวัตถุที่ใช้บ่อยในเมธอดที่มุ่งเน้น ทำให้คุณสามารถแปลงหรือรวมไฟล์, ประมวลผลองค์ประกอบของพรีเซนเทชัน, รวบรวมรูปร่าง, และลบเนื้อหาที่ไม่ได้ใช้โดยใช้โค้ดน้อยลง  

Low‑code helpers มีประโยชน์สูงสุดเมื่อการดำเนินการใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและเวิร์กฟลอว์เริ่มต้นตรงตามความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/cpp/aspose.slides/) ทั้งหมดเมื่อคุณต้องการการควบคุมละเอียดระดับสไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, การตั้งค่าการส่งออก หรือความสัมพันธ์ระหว่างองค์ประกอบของพรีเซนเทชัน  

ตารางต่อไปนี้สรุปตัวช่วยเหลือที่มีอยู่:

| ตัวช่วยเหลือ | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/convert/) | แปลงพรีเซนเทชันเป็นรูปแบบอื่นด้วยการเรียกไฟล์ต่อไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/merger/) | รวมไฟล์พรีเซนเทชันเต็มรูปแบบที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/) | ดำเนินการสำหรับสไลด์, รูปร่าง, ย่อหน้า หรือส่วนข้อความแต่ละรายการ |
| [Collect](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/collect/) | ดึงรูปทรงจากพรีเซนเทชันทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) | ลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่ |

## **แปลงพรีเซนเทชัน**

ใช้ [Convert::AutoByExtension](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/convert/autobyextension/) เมื่อส่วนขยายไฟล์ผลลัพธ์เพียงพอสำหรับเลือกฟอร์แมตการส่งออก เมธอดนี้จะเปิดพรีเซนเทชันต้นฉบับ, กำหนดฟอร์แมตที่ต้องการจากเส้นทางไฟล์ผลลัพธ์, และเขียนผลลัพธ์ออกมา  

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG และ TIFF อีกด้วย ใช้โมเดลวัตถุเต็มเมื่อคุณต้องการตรวจสอบหรือแก้ไขพรีเซนเทชันก่อนการส่งออกหรือกำหนดตัวเลือกการส่งออกที่ตัวช่วยเหลือไม่ได้เปิดเผย ดู [Convert Presentation](/cpp/convert-presentation/) สำหรับเวิร์กฟลอว์และตัวเลือกตามฟอร์แมต

## **รวมพรีเซนเทชัน**

ใช้ [Merger::Process](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/merger/process/) เพื่อรวมไฟล์พรีเซนเทชันเต็มรูปแบบด้วยคำสั่งเดียว พรีเซนเทชันต้นทางต้องมีรูปแบบไฟล์เดียวกัน  

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

ตัวช่วยนี้เหมาะสมเมื่อสไลด์ทั้งหมดควรถูกต่อท้ายเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือแมปใหม่แต่ละสไลด์ ใช้โมเดลวัตถุเต็มเมื่อคุณต้องการรวมสไลด์ที่เลือก, ใช้มาสเตอร์หรือเลย์เอาต์ปลายทาง, เก็บส่วนอย่างชัดเจน, หรือปรับขนาดสไลด์ที่ต่างกัน ดู [Merge Presentations](/cpp/merge-presentation/) สำหรับสถานการณ์เหล่านี้

## **วนซ้ำผ่านองค์ประกอบของพรีเซนเทชัน**

คลาส [ForEach](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/) จะเรียกคอลแบ็กสำหรับแต่ละประเภทขององค์ประกอบพรีเซนเทชันที่ร้องขอ ช่วยหลีกเลี่ยงลูปคอลเลกชันซ้อนกันและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนรูปแบบทั่วพรีเซนเทชัน  

ตัวอย่างต่อไปนี้ใช้ [ForEach::Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/paragraph/), และ [ForEach::Portion](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/portion/) เพื่อตรวจสอบองค์ประกอบที่สอดคล้องกัน:  

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

โดยค่าเริ่มต้น การท่องรูปทรงและข้อความทั่วพรีเซนเทชันจะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์อยู่ด้วย การ overload ที่มีพารามิเตอร์ `includeNotes` ยังสามารถประมวลผลสไลด์โน้ตได้ ใช้ลูปคอลเลกชันโดยตรงเมื่อลำดับการท่อง, การออกก่อน, การกรองก่อนเรียกคอลแบ็ก, หรือการควบคุมความสัมพันธ์พาเรนท์‑ชิลด์โดยละเอียดเป็นสิ่งสำคัญ

## **รวบรวมรูปร่าง**

ใช้ [Collect::Shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/collect/shapes/) เมื่อคุณต้องการคอลเลกชันของรูปทรงทั้งหมดในพรีเซนเทชันแทนคอลแบ็กสำหรับแต่ละรูปทรง ซึ่งมีประโยชน์เมื่อชุดเดียวกันต้องถูกกรอง, นับ, หรือประมวลผลหลายครั้ง  

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

ใช้ [ForEach::Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/shape/) แทนเมื่อรูปทรงแต่ละอันสามารถจัดการได้ทันทีและคุณไม่จำเป็นต้องเก็บผลลัพธ์ที่รวบรวมไว้

## **บีบอัดเนื้อหาพรีเซนเทชัน**

คลาส [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่ได้:  

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) ลบสไลด์เลย์เอาต์ที่ไม่มีสไลด์ปกติใดอ้างอิง  
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้แล้ว  
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) ลบอักขระที่ไม่ได้ใช้จากฟอนต์ที่ฝังอยู่  

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

ให้ลบเลย์เอาต์ที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดเลย์เอาต์ก็สามารถลบได้ บันทึกพรีเซนเทชันที่ปรับแต่งแล้วลงไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลย์เอาต์, หรือข้อมูลฟอนต์ฝังทั้งหมดเดิมในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดู [Slide Master](/cpp/slide-master/) และ [Embedded Font](/cpp/embedded-font/)

## **คำถามที่พบบ่อย**

**เมื่อใดที่ควรใช้ low‑code API แทนโมเดลวัตถุเต็ม?**  
ใช้ตัวช่วย low‑code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและไม่ต้องการการควบคุมละเอียดระดับองค์ประกอบส่วนบุคคล ใช้โมเดลวัตถุเต็มเมื่อคุณต้องการเลือกสไลด์เฉพาะ, ควบคุมความสัมพันธ์ของมาสเตอร์และเลย์เอาต์, ตรวจสอบสถานะกลาง, หรือกำหนดพฤติกรรมที่ตัวช่วยไม่ได้เปิดเผย  

**Merger สามารถรวมพรีเซนเทชันที่มีรูปแบบไฟล์ต่างกันได้หรือไม่?**  
ไม่ได้ ตัวเมธอด [Merger::Process](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/merger/process/) ต้องการพรีเซนเทชันต้นทางที่มีรูปแบบไฟล์เดียวกัน ก่อนรวมไฟล์ให้แปลงเป็นรูปแบบเดียวกันก่อน เช่นโดยใช้ [Convert::AutoByExtension](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/convert/autobyextension/) แล้วจึงทำการรวมไฟล์ที่แปลงแล้ว  

**ForEach ประมวลผลมาสเตอร์, เลย์เอาต์ และสไลด์โน้ตหรือไม่?**  
[ForEach::Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/slide/) จะวนผ่านสไลด์ปกติของพรีเซนเทชัน ส่วนการดำเนินการ [ForEach::Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/paragraph/), และ [ForEach::Portion](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/portion/) จะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์โดยค่าเริ่มต้น ใช้ overload ที่มี `includeNotes` เป็น `true` เพื่อรวมสไลด์โน้ตด้วย  

**ความแตกต่างระหว่าง ForEach::Shape กับ Collect::Shapes คืออะไร?**  
ใช้ [ForEach::Shape](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/shape/) เพื่อประมวลผลแต่ละรูปทรงทันทีผ่านคอลแบ็ก ใช้ [Collect::Shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/collect/shapes/) เมื่อคุณต้องการผลลัพธ์ที่เป็นคอลเลกชันสามารถเก็บไว้, กรอง, นับ, หรือท่องหลายครั้งได้  

**Compress ทำให้ไฟล์พรีเซนเทชันเล็กลงเสมอหรือไม่?**  
ไม่จำเป็น ผลลัพธ์ขึ้นกับว่าพรีเซนเทชันมีเลย์เอาต์, มาสเตอร์, หรือฟอนต์ฝังที่ไม่ได้ใช้หรือไม่ หากไม่มีองค์ประกอบเหล่านั้น การดำเนินการ [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) อาจไม่ลดขนาดไฟล์ได้  

**การเปลี่ยนแปลงที่ทำโดย ForEach หรือ Compress ถูกบันทึกอัตโนมัติหรือไม่?**  
ไม่ได้ ตัวช่วยเหลือนี้ทำงานบนอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่โหลดอยู่ในหน่วยความจำ หลังจากแก้ไของค์ประกอบในคอลแบ็กของ [ForEach](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/foreach/) หรือเรียกใช้ [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) ให้เรียก [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) เพื่อบันทึกผลลัพธ์  

## **บทความที่เกี่ยวข้อง**

- [แปลงพรีเซนเทชัน](/cpp/convert-presentation/)
- [รวมพรีเซนเทชัน](/cpp/merge-presentation/)
- [มาสเตอร์สไลด์](/cpp/slide-master/)
- [จัดการกล่องข้อความ](/cpp/manage-textbox/)
- [ฟอนต์ฝัง](/cpp/embedded-font/)