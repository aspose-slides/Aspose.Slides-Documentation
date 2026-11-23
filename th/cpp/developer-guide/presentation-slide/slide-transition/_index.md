---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอโดยใช้ C++
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
- ชนิดการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, ตั้งค่าการก้าวหน้าสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมวิธีการที่สไลด์ปรากฏในระหว่างการแสดงสไลด์โชว์ ด้วย Aspose.Slides for C++ คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ ตั้งค่าการก้าวหน้าผ่านการคลิกเมาส์หรือโดยจับเวลา และปรับตัวเลือกเฉพาะของเอฟเฟกต์ บทความนี้ใช้ตัวอย่าง C++ เพื่อใช้การเปลี่ยนตั้งค่าระยะเวลาเปลี่ยนที่แม่นยำ จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเหล่านี้เป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน ให้โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/)。เรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) พร้อมค่าจากการนับ [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Circle กับสไลด์แรกและการเปลี่ยน Comb กับสไลด์ที่สอง โดยใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

## **การเปลี่ยนแบบล้อ**

เมธอด [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) ของ [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) ควบคุมจำนวนส่วนรัศมีที่เปิดเผยสไลด์ปลายทาง เรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) ด้วย Wheel จาก [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) ก่อนเข้าถึง [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) เป็น [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/)

ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองชุด: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมทอง สีปลายทางใช้จำนวน spoke 1 และ 8 พร้อมความเร็วเดียวกันที่ตั้งด้วย [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) และระยะเวลาชัดเจน 8,000 มิลลิวินาทีโดยใช้ [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) เพื่อให้เห็นความแตกต่างง่ายขึ้น

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

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint แล้วเริ่มการแสดงสไลด์ ไปจากสไลด์ 1 ไปสไลด์ 2 แล้วจากสไลด์ 3 ไปสไลด์ 4 ในการเล่น PowerPoint จำนวน spoke 1 ที่ตรวจสอบแล้วจะเปิดเผยสไลด์ด้วยการกวาดตามเข็มนาฬิกาเพียงครั้งเดียว; จำนวน 8 จะเปิดเผยด้วยส่วนรัศมีแปดส่วนพร้อมกัน เนื้อหาและเวลาการเปลี่ยนของสไลด์ปลายทางเหมือนกัน ดังนั้นความแตกต่างอยู่ที่จำนวนส่วนที่เปิดเผย

## **การจางผ่านสีดำด้วยการเปลี่ยน Reveal**

ตั้งค่าชนิดการเปลี่ยนของสไลด์ปลายทางเป็น Reveal แล้วเรียก [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/) บนอินเตอร์เฟส [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/) ตัวอย่างสร้างสไลด์ต้นฉบับสีเทาเขียวและสไลด์ปลายทางสีโค랄 แล้วทำสำเนาทั้งสองเพื่อเปรียบเทียบการเปลี่ยนสองวินาทีที่เปิดหรือปิดการจางผ่านสีดำ

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/SlideShowTransition/IRevealTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionLeftRightDirectionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto styleSlide = [](SharedPtr<ISlide> slide, Color background, const String& label)
{
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
    auto fill = slide->get_Background()->get_FillFormat();
    fill->set_FillType(FillType::Solid);
    fill->get_SolidFillColor()->set_Color(background);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(label);
    textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_FontHeight(44);
};

auto presentation = MakeObject<Presentation>();

auto source = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddClone(source);
styleSlide(source, Color::get_Teal(), u"Source");
styleSlide(destination, Color::get_Coral(), u"Destination");
presentation->get_Slides()->AddClone(source);
presentation->get_Slides()->AddClone(destination);

for (auto index : {1, 3})
{
    auto transition = presentation->get_Slide(index)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Reveal);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(2000);

    auto reveal = ExplicitCast<IRevealTransition>(transition->get_Value());
    reveal->set_Direction(TransitionLeftRightDirectionType::Left);
    reveal->set_ThroughBlack(index == 3);
}

presentation->Save(u"reveal-transitions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ในการแสดงสไลด์ PowerPoint ให้ก้าวจากสไลด์ 1 ไปสไลด์ 2 สีเทาเขียวจางเข้าไปในสีโค랄โดยตรง แล้วก้าวจากสไลด์ 3 ไปสไลด์ 4 หน้าจอจะมืดลงชั่วครู่ใกล้สีดำก่อนสีโค랄ปรากฏ สไลด์ทั้งสองคงสีพื้นหลังต้นฉบับไว้

แถวด้านล่างแสดงเฟรมจาก PowerPoint ทุกครึ่งวินาที เปรียบเทียบเฟรมกลางของแต่ละแถวเพื่อดูผลของการตั้งค่า

![การเล่น PowerPoint พร้อม WithThroughBlack ปิด (บน) และเปิด (ล่าง) เฉพาะแถวล่างผ่านสีดำใกล้เคียง](reveal-through-black.png)

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอและว่าจะให้การคลิกเมาส์ก้าวหน้าการแสดงหรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) อนุญาตให้ผู้ชมก้าวหน้าด้วยการคลิกเมาส์
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) เปิดการก้าวหน้าอัตโนมัติ
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) ระบุเวลาหน่วงก่อนการก้าวหน้าอัตโนมัติเป็นมิลลิวินาที

เปิดการก้าวหน้าแบบคลิกและแบบจับเวลาเพื่อให้ผู้ชมเลือกคลิกหรือรอไทม์เมอร์ หากต้องการใช้เฉพาะไทม์เมอร์ ให้เรียก [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) ด้วย `false` ค่าหน่วงกำหนดเวลาที่การแสดงสไลด์จะก้าวหน้า ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพ

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดการก้าวหน้าอัตโนมัติหลัง 3, 5, และ 7 วินาทีตามลำดับ ขณะที่การคลิกเมาส์ก็สามารถก้าวหน้าได้เช่นกัน ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าการก้าวหน้าแบบจับเวลาถูกเปิดหรือไม่ เรียก [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/) ค่าหน่วงที่เก็บไว้เพียงอย่างเดียวไม่ได้หมายความว่าไทม์เมอร์ทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานไทม์เมอร์ที่เปิดอยู่แต่ละอัน และปิดการก้าวหน้าอัตโนมัติสำหรับสไลด์ที่มีค่าหน่วงมากกว่าสองวินาที พร้อมเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าอัปเดต

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

ใช้ [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) เพื่อตั้งความยาวที่แม่นยำของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที วิธี [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) ของสไลด์ให้เข้าถึงการตั้งค่าเหล่านี้ผ่าน [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| Method | Purpose |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | กำหนดเวลาหน่วงก่อนสไลด์ก้าวหน้าอัตโนมัติเป็นมิลลิวินาที เรียก [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) ด้วย `true` เพื่อเปิดไทม์เมอร์นี้ |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | เลือกความเร็วที่กำหนดไว้ล่วงหน้าจากการนับ [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) ได้แก่ Slow, Medium หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาชัดเจน |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอ จัดการค่าหน่วงการก้าวหน้าอัตโนมัติแยกต่างหาก เมื่อไม่ได้ตั้งระยะเวลาอย่างชัดเจน Aspose.Slides จะคำนวณระยะเวลาเอฟเฟกต์จากชนิดการเปลี่ยนและค่าที่ได้จาก [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/)

<!-- visual-explanation:slide-transition:start -->
[![แถบแยกแสดงระยะเวลาเปลี่ยน 750 ms และการก้าวหน้าอัตโนมัติ 5 000 ms](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*ตัวอย่างร่วมให้แต่ละสไลด์มีการเปลี่ยน Fade 750 ms และเปิดการก้าวหน้าอัตโนมัติที่ 5 000 ms แยกกัน แถบเหล่านี้เป็นการตั้งค่าเชิงโครงสร้าง ไม่ใช่ไทม์ไลน์ที่วัดได้ร่วมกัน*
<!-- visual-explanation:slide-transition:end -->

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้อง ใช้เอฟเฟกต์เดียวและระยะเวลาที่แม่นยำเดียวกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) และกำหนดระยะเวลา 750 มิลลิวินาทีให้กับการเปลี่ยนแต่ละอัน พร้อมเปิดการก้าวหน้าอัตโนมัติหลัง 5 000 มิลลิวินาทีและปิดการก้าวหน้าโดยคลิกเมาส์ แล้วบันทึกเป็น PPTX

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

    // กำหนดการก้าวหน้าอัตโนมัติแยกจากระยะเวลาเอฟเฟกต์
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **ตั้งระยะเวลาต่างกันสำหรับสไลด์แต่ละรายการ**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาการเปลี่ยนที่ต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวข้อและการเปลี่ยนยาวสำหรับการแนะนำส่วน ตัวอย่างนี้ตั้ง 500 มิลลิวินาทีให้สไลด์แรกและ 1 200 มิลลิวินาทีให้สไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ประสานการเปลี่ยนกับผลลัพธ์แบบเคลื่อนไหว**

เมื่อเตรียม [animated GIF](/slides/th/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/cpp/export-to-html5/), หรือ [video](/slides/th/cpp/convert-powerpoint-to-video/), ให้ตั้งระยะเวลาเปลี่ยนอย่างแม่นยำก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 มิลลิวินาทีระหว่างฉาก และปรับค่าหน่วงการก้าวหน้าของแต่ละสไลด์แยกกันเพื่อให้มีเวลาอธิบายหรือเนื้อหา

สำหรับ GIF และวิดีโอให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินัติ corresponds to 18 frames at 30 fps. ใน HTML5 ให้เปิดการเปลี่ยนแบบเคลื่อนไหวในตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาในรูปแบบการส่งออกที่เลือกและดูตัวอย่างผลลัพธ์เพื่อยืนยันความสอดคล้อง

### **อ่านระยะเวลาเปลี่ยนที่มีอยู่**

เรียก [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีค่าระยะเวลาที่ระบุไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการตั้งระยะเวลาโดยตรง; ค่าที่ไม่เป็นลบจะเป็นระยะเวลาที่เก็บไว้เป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งไว้ไม่เท่ากับระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ชนิดการเปลี่ยนและค่าที่ได้จาก [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) เพื่อกำหนดระยะเวลานั้น การตั้งชนิดการเปลี่ยนอาจทำให้มีการกำหนดระยะเวลาโดยอัตโนมัติ ดังนั้นตรวจสอบการตั้งค่าต้นฉบับก่อน

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

การเปลี่ยน Morph ทำให้การเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ต่อเนื่องเป็นอนิเมชัน เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้ทำสำเนาสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนา แล้วใส่การเปลี่ยน Morph กับสไลด์ที่สอง จะทำให้วัตถุที่ตรงกันถูกแอนิเมตจากสถานะเดิมไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ ทำสำเนาสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จากการนับ [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกไว้ในโปรแกรมดูงานนำเสนอที่สนับสนุน Morph เพื่อดูเอฟเฟกต์ในโหมดสไลด์โชว์

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

การนับ [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และแอนิเมตเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) ปฏิบัติกับแต่ละรูปทรงเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) แอนิเมตข้อความโดยจับคู่คำตามที่เป็นไปได้
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) แอนิเมตข้อความโดยจับคู่ตัวอักษรตามที่เป็นไปได้

เรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) ด้วย Morph ก่อนเข้าถึง [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/)。ค่าที่ได้จะให้อินเตอร์เฟส [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) ซึ่งเมธอด [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดสไลด์ที่สองให้ใช้การแอนิเมต Morph แบบตามคำ

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

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าจะเริ่มจากหน้าจอสีดำหรือไม่ ตัวเลือกที่ใช้ได้ขึ้นกับชนิดการเปลี่ยนที่เลือก ให้ตั้งชนิดก่อนแล้วใช้อินเตอร์เฟสที่เหมาะสมที่คืนจาก [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/)

ตัวอย่างต่อไปใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` โดยเรียก [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) ด้วย `true` ผ่าน [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

**สามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ได้. ใช้ [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แม่นยำเป็นมิลลิวินาที ใช้ [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) เมื่อการจัดอยู่ในหมวด [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) — Slow, Medium, หรือ Fast — เพียงพอและไม่มีการตั้งระยะเวลาชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนแยกจากหน่วงเวลาการก้าวหน้าอัตโนมัติ

**สามารถแนบเสียงกับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงที่ฝังด้วย [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/), เรียก [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) ด้วย StartSound จากการนับ [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) และเปิดการวนซ้ำด้วย [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชันที่คืนจากเมธอด [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) ของงานนำเสนอ แล้วเรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) ด้วยค่าที่เดียวกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าการเวลาและตัวเลือกเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั้งหมด

**ฉันจะตรวจสอบว่าการเปลี่ยนใดตั้งอยู่บนสไลด์ปัจจุบันได้อย่างไร?**

เรียก [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) จากการเปลี่ยนที่คืนโดยเมธอด [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) ของสไลด์ จะได้ค่าจากการนับ [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) ; None หมายถึงไม่มีการตั้งค่าเอฟเฟกต์การเปลี่ยนใด ๆ.