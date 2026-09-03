---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอด้วย C++
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/cpp/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้การเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, กำหนดการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมวิธีการที่สไลด์ปรากฏระหว่างการแสดงสไลด์โชว์ ด้วย Aspose.Slides for C++ คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ กำหนดการเลื่อนหน้าโดยคลิกเมาส์หรือโดยตัวจับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงสำหรับเอฟเฟกต์นั้นได้ บทความนี้ใช้ตัวอย่าง C++ เพื่อใช้การเปลี่ยนสไลด์ ตั้งค่าระยะเวลาการเปลี่ยนอย่างแม่นยำ จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยนแบบ Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน ให้โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) แล้วเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [get_SlideShowTransition](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)。เรียก [set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_type/) ด้วยค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitiontype/) แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Circle กับสไลด์แรกและการเปลี่ยน Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์ค้างอยู่บนหน้าจอและว่าจะให้คลิกเมาส์เลื่อนการแสดงสไลด์หรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) ให้ผู้ชมเลื่อนหน้าโดยคลิกเมาส์
- [set_AdvanceAfter](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_advanceafter/) เปิดใช้งานการเลื่อนอัตโนมัติ
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) ระบุความหน่วงก่อนการเลื่อนอัตโนมัติ (หน่วยมิลลิวินาที)

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมสามารถเลื่อนด้วยการคลิกหรือรอจนตัวจับเวลา ตัวเลือกนี้กำหนดเวลาเมื่อการแสดงสไลด์เลื่อนหน้า ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนที่มองเห็น

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรก และเปิดใช้งานการเลื่อนอัตโนมัติหลังจาก 3, 5, และ 7 วินาทีตามลำดับ คลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

เพื่อเช็คว่าการเลื่อนตามเวลาถูกเปิดหรือไม่ ให้เรียก [get_AdvanceAfter](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/get_advanceafter/)。ค่าความหน่วงที่จัดเก็บเพียงอย่างเดียวไม่ได้บ่งบอกว่าตัวจับเวลาเปิดทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานตัวจับเวลาที่เปิดอยู่แต่ละตัว และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความหน่วงมากกว่าสองวินาที แล้วเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าที่อัปเดต

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **ควบคุมเวลาเปลี่ยนสไลด์อย่างแม่นยำ**

ใช้ [set_Duration](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_duration/) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยน (มิลลิวินาที) เมธอด [get_SlideShowTransition](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [ISlideShowTransition](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/) :

| Method | Purpose |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_duration/) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยน (มิลลิวินาที) |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | กำหนดความหน่วงก่อนสไลด์เลื่อนอัตโนมัติ (มิลลิวินาที) เรียก [set_AdvanceAfter](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_advanceafter/) กับ `true` เพื่อเปิดใช้งานตัวจับเวลานี้ |
| [set_Speed](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_speed/) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitionspeed/) : Slow, Medium, หรือ Fast ใช้เมื่อไม่มีการระบุระยะเวลาที่แน่นอน |

[set_Duration](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_duration/) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอ กำหนดความหน่วงของการเลื่อนอัตโนมัติแยกต่างหาก เมื่อไม่มีการตั้งค่าระยะเวลาชัดเจน Aspose.Slides จะคำนวณระยะเวลาของเอฟเฟกต์จากประเภทการเปลี่ยนและค่าที่คืนจาก [get_Speed](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/get_speed/)

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้อง ให้ใช้เอฟเฟ็กต์และระยะเวลาที่แน่นอนเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitiontype/) และกำหนดระยะเวลาการเปลี่ยนเป็น 750 มิลลิวินาที พร้อมเปิดการเลื่อนอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยคลิกเมาส์ แล้วบันทึกผลเป็น PPTX

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // กำหนดการเลื่อนอัตโนมัติแยกจากระยะเวลาเอฟเฟกต์.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **ตั้งค่าระยะเวลาต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่แตกต่างกัน ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับสไลด์แนะนำส่วน ตัวอย่างนี้ตั้งค่า 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **ประสานการเปลี่ยนสไลด์กับผลลัพธ์แบบเคลื่อนไหว**

เมื่อเตรียม [animated GIF](/slides/th/cpp/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/th/cpp/export-to-html5/)、หรือ [video](/slides/th/cpp/convert-powerpoint-to-video/) ให้ตั้งค่าระยะเวลาการเปลี่ยนอย่างแม่นยำก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 มิลลิวินาทีระหว่างฉากและปรับความหน่วงการเลื่อนของแต่ละสไลด์แยกต่างหากเพื่อให้มีเวลาสำหรับการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดการเปลี่ยนแบบเคลื่อนไหวในตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาแบบรองรับของรูปแบบการส่งออกที่เลือกและดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

เรียก [get_Duration](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/get_duration/) ก่อนแก้ไขการเปลี่ยนเพื่อพิจารณาว่ามีค่าที่กำหนดไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการกำหนดระยะเวลาชัดเจน; ค่าไม่เป็นลบระบุระยะเวลาที่เก็บไว้ (มิลลิวินาที) ค่าที่ไม่ได้ตั้งไว้ไม่ใช่ระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่าที่คืนจาก [get_Speed](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/get_speed/) เพื่อตัดสินระยะเวลา การตั้งค่าประเภทการเปลี่ยนอาจเริ่มต้นระยะเวลาไว้ ดังนั้นตรวจสอบการตั้งค่าเดิมก่อน

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **การเปลี่ยน Morph**

การเปลี่ยน Morph ทำให้การเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ต่อเนื่องเป็นภาพเคลื่อนไหว เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้ทำสำเนาสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนา แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง ทำให้วัตถุที่เกี่ยวข้องเคลื่อนไหวจากสถานะเดิมไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ ทำสำเนาสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกไว้ในโปรแกรมดูงานนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **ประเภทการเปลี่ยน Morph**

Enumeration [TransitionMorphType](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และทำภาพเคลื่อนไหวของเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitionmorphtype/) ปฏิบัติต่อแต่ละรูปร่างเป็นวัตถุหนึ่งทั้งหมด
- [ByWord](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitionmorphtype/) ทำภาพเคลื่อนไหวข้อความโดยจับคู่คำเมื่อทำได้
- [ByChar](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitionmorphtype/) ทำภาพเคลื่อนไหวข้อความโดยจับคู่อักขระเมื่อทำได้

เรียก [set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_type/) กับ Morph ก่อนเข้าถึง [get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/get_value/)。ค่าที่ได้ให้ส่วนติดต่อ [IMorphTransition](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/imorphtransition/) ซึ่งเมธอด [set_MorphType](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การเคลื่อนไหว Morph ตามคำ

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **ตั้งค่าผลกระทบการเปลี่ยนสไลด์**

บางการเปลี่ยนมีตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าจะเริ่มจากหน้าจอสีดำหรือไม่ ตัวเลือกที่มีขึ้นอยู่กับประเภทการเปลี่ยนที่เลือก ตั้งค่าประเภทก่อน แล้วใช้ interface ที่คืนจาก [get_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/get_value/) ที่เหมาะสม

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` โดยเรียก [set_FromBlack](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) ด้วย `true` ผ่าน [IOptionalBlackTransition](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **FAQ**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ได้. ควรใช้ [set_Duration](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_duration/) เมื่อคุณต้องการระบุระยะเวลาของเอฟเฟกต์อย่างแม่นยำ (มิลลิวินาที) ใช้ [set_Speed](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_speed/) เมื่อหมวด [TransitionSpeed](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitionspeed/) ที่กำหนดไว้—Slow, Medium, หรือ Fast—เพียงพอและไม่มีการกำหนดระยะเวลาชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากความหน่วงของการเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงไปกับการเปลี่ยนและทำให้มันวนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงฝังด้วย [set_Sound](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_sound/), เรียก [set_SoundMode](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_soundmode/) กับ `StartSound` จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitionsoundmode/) และเปิดการวนซ้ำด้วย [set_SoundLoop](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_soundloop/)。เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชันที่คืนจากเมธอด [get_Slides](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slides/) ของงานนำเสนอและเรียก [set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/set_type/) ด้วยค่าที่เดียวกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั่วทั้งสไลด์

**ฉันจะตรวจสอบว่าเดี๋ยวนี้สไลด์มีการตั้งค่าการเปลี่ยนอะไรอยู่ได้อย่างไร?**

เรียก [get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideshowtransition/get_type/) บนวัตถุการเปลี่ยนที่คืนจากเมธอด [get_SlideShowTransition](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) ของสไลด์ มันจะคืนค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitiontype/) ; ค่า `None` หมายถึงไม่มีการใช้เอฟเฟกต์การเปลี่ยนใด ๆ