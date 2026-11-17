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
description: "ใช้การเปลี่ยนสไลด์ ตั้งค่าการเลื่อนสไลด์อัตโนมัติ และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides for C++."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมวิธีการแสดงสไลด์ระหว่างการนำเสนอด้วยสไลด์โชว์ ด้วย Aspose.Slides for C++ คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสไลด์สำหรับแต่ละสไลด์ กำหนดการเลื่อนไปโดยการคลิกเมาส์หรือโดยตัวจับเวลา และปรับตัวเลือกเฉพาะของเอฟเฟกต์ บทความนี้ใช้ตัวอย่าง C++ เพื่อใช้การเปลี่ยนสไลด์ ตั้งค่าเวลาการเปลี่ยนที่แม่นยำ จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีการบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยนสไลด์ ให้โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนสไลด์ของสไลด์ผ่าน [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). เรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) ด้วยค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) จากนั้นบันทึกการนำเสนอ. ตัวอย่างต่อไปใช้การเปลี่ยน Circle กับสไลด์แรกและการเปลี่ยน Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

## **การเปลี่ยนแบบ Wheel**

เมธอด [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) ของ [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) ควบคุมจำนวนเซคเตอร์รังสีที่เปิดเผยสไลด์ปลายทาง เรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) ด้วยค่า Wheel จาก [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) ก่อนเข้าถึง [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) เป็น [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/). ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองคู่: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมสีทอง สไลด์ปลายทางใช้จำนวน spoke เป็น 1 และ 8 โดยใช้ความเร็วเดียวกันผ่าน [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) และระยะเวลาที่กำหนดเป็น 8,000 มิลลิวินาทีผ่าน [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) เพื่อให้เห็นความแตกต่างได้ง่าย

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

เปิดการนำเสนอผลลัพธ์ใน PowerPoint และเปิดการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 จากนั้นจากสไลด์ 3 ไปสไลด์ 4 ในการเล่น PowerPoint จำนวน spoke ที่ตรวจสอบแล้วเป็น 1 จะเปิดเผยสไลด์ด้วยการสวิงตามเข็มนาฬิกาเดียว; จำนวน 8 จะเปิดเผยด้วยเซคเตอร์รังสีแปดส่วนพร้อมกัน เนื้อหาและเวลาการเปลี่ยนของสไลด์ปลายทางเหมือนกัน ดังนั้นความแตกต่างคือจำนวนเซคเตอร์ที่เปิดเผย

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์ค้างอยู่บนหน้าจอและว่าจะให้การคลิกเมาส์ทำให้การแสดงสไลด์ก้าวต่อหรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:
- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) ให้ผู้ชมเลื่อนไปโดยคลิกเมาส์
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) เปิดการเลื่อนอัตโนมัติ
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) ระบุความล่าช้าก่อนการเลื่อนอัตโนมัติเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมสามารถก้าวต่อด้วยการคลิกหรือรอจนถึงตัวจับเวลา หากต้องการใช้เฉพาะตัวจับเวลา ให้เรียก [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) ด้วยค่า `false` ความล่าช้าควบคุมเวลาที่การแสดงสไลด์เลื่อนไป; ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนที่มองเห็น

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสไลด์สามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลังจาก 3, 5, และ 7 วินาทีตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าการเลื่อนตามเวลาถูกเปิดหรือไม่ ให้เรียก [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/). ความล่าช้าที่จัดเก็บเพียงอย่างเดียวไม่แสดงว่าตัวจับเวลากำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ด้านบน รายงานตัวจับเวลาที่เปิดแต่ละรายการ และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความล่าช้าเกินสองวินาที เปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าใหม่

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

## **ควบคุมเวลาการเปลี่ยนอย่างแม่นยำ**

ใช้ [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) เพื่อระบุความยาวที่แม่นยำของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที วิธี [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| เมธอด | วัตถุประสงค์ |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | กำหนดความล่าช้าก่อนที่สไลด์จะเลื่อนอัตโนมัติเป็นมิลลิวินาที เรียก [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) ด้วยค่า `true` เพื่อเปิดใช้งานตัวจับเวลา |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium หรือ Fast จะใช้เมื่อไม่ได้กำหนดระยะเวลาที่แม่นยำ |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน; ไม่กำหนดว่าสไลด์จะคงอยู่บนจอเท่าใด ตั้งค่าความล่าช้าการเลื่อนอัตโนมัติแยกต่างหาก เมื่อไม่มีการกำหนดระยะเวลาโดยตรง Aspose.Slides จะกำหนดระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่าที่ [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) คืนมา

<!-- visual-explanation:slide-transition:start -->
[![แถบแยกบ่งบอกระยะเวลาการเปลี่ยน 750‑ms และการตั้งค่าการเลื่อนอัตโนมัติ 5,000‑ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)
*ตัวอย่างร่วมให้แต่ละสไลด์มีการเปลี่ยน Fade 750 ms และเปิดการเลื่อนอัตโนมัติที่ 5,000 ms แยกกัน ระยะเวลาเปลี่ยนควบคุมเอฟเฟกต์; การเลื่อนควบคุมเวลาที่ออกจากสไลด์ แถบเหล่านี้เป็นการตั้งค่าเชิง schematic ไม่ใช่ไทม์ไลน์ที่วัดได้*
<!-- visual-explanation:slide-transition:end -->

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้อง ใช้เอฟเฟกต์และระยะเวลาที่แม่นยำเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) และกำหนดระยะเวลา 750 มิลลิวินาทีให้แต่ละการเปลี่ยน เปิดการเลื่อนอัตโนมัติหลังจาก 5,000 มิลลิวินาทีแยกกันและปิดการเลื่อนด้วยคลิกเมาส์ จากนั้นบันทึกผลเป็น PPTX

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

### **ตั้งระยะเวลาที่ต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่ต่างกัน ตัวอย่างเช่น ใช้การเปลี่ยนสั้น ๆ สำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวกว่าในสไลด์แนะนำส่วน ตัวอย่างนี้กำหนด 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ประสานการเปลี่ยนกับผลลัพธ์ที่เป็นภาพเคลื่อนไหว**

เมื่อตั้งค่าการแปลงเป็น [animated GIF](/slides/th/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/cpp/export-to-html5/), หรือ [video](/slides/th/cpp/convert-powerpoint-to-video/), ตั้งค่าระยะเวลาเปลี่ยนที่แม่นยำก่อนการส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 ms ระหว่างฉากและปรับความล่าช้าการเลื่อนของแต่ละสไลด์แยกกันเพื่อให้มีเวลาสำหรับการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 ms เท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดการเปลี่ยนที่เคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลา ที่รองรับโดยรูปแบบการส่งออกที่เลือกและดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงค์

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

เรียก [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) ก่อนแก้ไขการเปลี่ยนเพื่อกำหนดว่ามีค่าที่กำหนดไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการกำหนดระยะเวลา; ค่าที่เป็นจำนวนเต็มบวกหรือศูนย์ระบุระยะเวลาที่เก็บเป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งค่าไม่ใช่ระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่าที่ [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) คืนมาเพื่อกำหนดระยะเวลานั้น การตั้งค่าประเภทการเปลี่ยนอาจเริ่มต้นระยะเวลา ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

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

การเปลี่ยน Morph ทำให้การเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ต่อเนื่องเป็นภาพเคลื่อนไหว เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้ทำการโคลนสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนา แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง ทำให้วัตถุที่สัมพันธ์กันถูกทำให้เคลื่อนไหวระหว่างสถานะเดิมและแก้ไข

ตัวอย่างต่อไปสร้างสไลด์ที่มีสี่เหลี่ยมข้อความ โคลนสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในโปรแกรมดูการนำเสนอที่สนับสนุน Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

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

enumeration [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) กำหนดวิธีที่ Morph ตรงกับและทำให้เนื้อหาเคลื่อนไหว:
- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) พิจารณารูปร่างแต่ละอันเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) ทำให้ข้อความเคลื่อนไหวโดยจับคู่คำตามที่เป็นไปได้
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) ทำให้ข้อความเคลื่อนไหวโดยจับคู่อักขระตามที่เป็นไปได้

เรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) ด้วย Morph ก่อนเข้าถึง [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/). ค่านี้จะให้อินเตอร์เฟส [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) ที่มีเมธอด [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) เพื่อเลือกโหมดการจับคู่

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

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**

บางการเปลี่ยนมีตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์เริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นอยู่กับประเภทการเปลี่ยนที่เลือก ตั้งค่าประเภทก่อนแล้วใช้อินเตอร์เฟสที่เหมาะสมที่ [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) คืนมา

ตัวอย่างต่อไปใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` โดยเรียก [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) ด้วยค่า `true` ผ่าน [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ได้. แนะนำให้ใช้ [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) เมื่อคุณต้องการระยะเวลาเอฟเฟ็กต์ที่แม่นยำเป็นมิลลิวินาที ใช้ [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) เมื่อหมวด [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) ที่กำหนดไว้ล่วงหน้า—Slow, Medium หรือ Fast เพียงพอและไม่มีการกำหนดระยะเวลาที่ชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟ็กต์การเปลี่ยนโดยอิสระจากความล่าช้าการเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงฝังด้วย [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), เรียก [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) ด้วยค่า StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/), และเปิดการวนซ้ำด้วย [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในการแสดงสไลด์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชันที่คืนโดยเมธอด [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) ของการนำเสนอและเรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) ด้วยค่เดียวกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์ใด ๆ ในลูปเดียวเพื่อให้พฤติกรรมสอดคล้องกันในทุกสไลด์

**ฉันจะตรวจสอบการเปลี่ยนที่ตั้งอยู่บนสไลด์ในขณะนี้ได้อย่างไร?**

เรียก [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) บนการเปลี่ยนที่คืนจากเมธอด [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) ของสไลด์ จะคืนค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/); None หมายถึงไม่มีการใช้เอฟเฟกต์การเปลี่ยน