---
title: แปลงการนำเสนอ PowerPoint เป็นวิดีโอใน C++
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/cpp/convert-powerpoint-to-video/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็นวิดีโอ
- การนำเสนอเป็นวิดีโอ
- PPT เป็นวิดีโอ
- PPTX เป็นวิดีโอ
- PowerPoint เป็น MP4
- การนำเสนอเป็น MP4
- PPT เป็น MP4
- PPTX เป็น MP4
- บันทึก PPT เป็น MP4
- บันทึก PPTX เป็น MP4
- ส่งออก PPT เป็น MP4
- ส่งออก PPTX เป็น MP4
- การแปลงวิดีโอ
- PowerPoint
- C++
- Aspose.Slides
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint เป็นวิดีโอใน C++ ค้นหาโค้ดตัวอย่างและเทคนิคการอัตโนมัติเพื่อทำให้กระบวนการทำงานของคุณมีประสิทธิภาพมากขึ้น."
---
## **บทนำ**

โดยการแปลงการนำเสนอ PowerPoint ของคุณเป็นวิดีโอ คุณจะได้รับ 

* **เพิ่มการเข้าถึง:** ทุกอุปกรณ์ (ไม่ว่าจะเป็นแพลตฟอร์มใด) มีตัวเล่นวิดีโอติดตั้งโดยปริยายเมื่อเทียบกับแอปพลิเคชันที่เปิดการนำเสนอ ทำให้ผู้ใช้พบว่าการเปิดหรือเล่นวิดีโอทำได้ง่ายกว่า
* **เข้าถึงมากขึ้น:** ผ่านวิดีโอ คุณสามารถเข้าถึงผู้ชมจำนวนมากและมุ่งเป้าหมายให้ข้อมูลที่อาจดูน่าเบื่อในรูปแบบการนำเสนอ การสำรวจและสถิติส่วนใหญ่แสดงว่าผู้คนชมและบริโภควิดีโอมากกว่ารูปแบบเนื้อหาอื่น ๆ และโดยทั่วไปพวกเขาชอบเนื้อหาแบบนี้

ใน [Aspose.Slides 22.11](https://docs.aspose.com/slides/th/cpp/aspose-slides-for-cpp-22-11-release-notes/), เราได้ทำการสนับสนุนการแปลงการนำเสนอเป็นวิดีโอ

* ใช้ Aspose.Slides เพื่อสร้างชุดเฟรม (จากสไลด์การนำเสนอ) ที่สอดคล้องกับ FPS (เฟรมต่อวินาที) ที่กำหนด
* ใช้ยูทิลิตี้ของบุคคลที่สามเช่น `ffmpeg` เพื่อสร้างวิดีโอตามเฟรม

## **แปลงการนำเสนอ PowerPoint เป็นวิดีโอ**

1. ดาวน์โหลด ffmpeg [ที่นี่](https://ffmpeg.org/download.html).
2. เพิ่มเส้นทางไปยัง `ffmpeg.exe` ในตัวแปรสภาพแวดล้อม `PATH`.
3. เรียกใช้โค้ดแปลง PowerPoint เป็นวิดีโอ.

โค้ด C++ นี้จะแสดงวิธีแปลงการนำเสนอ (ที่มีรูปภาพและสองเอฟเฟ็กต์แอนิเมชัน) เป็นวิดีโอ:

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่มรูปสัญลักษณ์ยิ้มแล้วทำแอนิเมชันให้
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);
    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **เอฟเฟ็กต์วิดีโอ**

คุณสามารถใช้แอนิเมชันกับวัตถุในสไลด์และใช้การเปลี่ยนสไลด์ระหว่างสไลด์

{{% alert color="info" %}} 

คุณอาจต้องการดูบทความเหล่านี้: [PowerPoint Animation](https://docs.aspose.com/slides/th/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/th/cpp/shape-animation/), และ [Shape Effect](https://docs.aspose.com/slides/th/cpp/shape-effect/).

{{% /alert %}} 

แอนิเมชันและการเปลี่ยนสไลด์ทำให้การพรีเซนต์ชวนติดตามและน่าสนใจ—และทำเช่นเดียวกันสำหรับวิดีโอ ให้เพิ่มสไลด์และการเปลี่ยนสไลด์อีกหนึ่งสไลด์ในโค้ดของการนำเสนอก่อนหน้า:

```c++
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;

// เพิ่มรูปสัญลักษณ์ยิ้มและทำแอนิเมชันให้ตามที่แสดงด้านบน
auto presentation = System::MakeObject<Presentation>();

// เพิ่มสไลด์ใหม่และการเปลี่ยนสไลด์แบบแอนิเมชัน

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides ยังรองรับการแอนิเมชันสำหรับข้อความ ดังนั้นเราจึงแอนิเมชันย่อหน้าบนวัตถุ ซึ่งจะปรากฏต่อเนื่องกัน (โดยตั้งค่าความล่าช้าเป็นหนึ่งวินาที):

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/diagnostics/process.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่มข้อความและแอนิเมชัน
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"convert PowerPoint Presentation with text to video"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"paragraph by paragraph"));
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Add(para1);
    paragraphs->Add(para2);
    paragraphs->Add(para3);
    paragraphs->Add(System::MakeObject<Paragraph>());

    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effect = sequence->AddEffect(para1, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect2 = sequence->AddEffect(para2, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect3 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    System::SharedPtr<IEffect> effect4 = sequence->AddEffect(para3, EffectType::Appear, EffectSubtype::None, EffectTriggerType::AfterPrevious);

    effect->get_Timing()->set_TriggerDelayTime(1.0f);
    effect2->get_Timing()->set_TriggerDelayTime(1.0f);
    effect3->get_Timing()->set_TriggerDelayTime(1.0f);
    effect4->get_Timing()->set_TriggerDelayTime(1.0f);

    // แปลงเฟรมเป็นวิดีโอ
    const int32_t fps = 33;

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, fps);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());

    const System::String ffmpegParameters = System::String::Format(
        u"-loglevel {0} -framerate {1} -i {2} -y -c:v {3} -pix_fmt {4} {5}",
        u"warning", fps, u"frame_%d.png", u"libx264", u"yuv420p", u"video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **คลาสการแปลงวิดีโอ**

เพื่อให้คุณทำงานแปลง PowerPoint เป็นวิดีโอได้ Aspose.Slides มีคลาส [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_animations_generator/) และ [PresentationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_player/) 

PresentationAnimationsGenerator อนุญาตให้คุณตั้งขนาดเฟรมสำหรับวิดีโอ (ที่จะสร้างในภายหลัง) ผ่านคอนสตรัคเตอร์ของมัน หากคุณส่งอินสแตนซ์ของการนำเสนอ `Presentation.SlideSize` จะถูกใช้และมันจะสร้างแอนิเมชันที่ [PresentationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_player/) ใช้. 

เมื่อสร้างแอนิเมชันแล้ว จะเกิดเหตุการณ์ `NewAnimation` สำหรับแต่ละแอนิเมชันต่อเนื่อง ซึ่งมีพารามิเตอร์เป็น [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.i_presentation_animation_player/) ตัวหลังเป็นคลาสที่แสดงถึงผู้เล่นสำหรับแอนิเมชันแยกต่างหาก. 

เพื่อทำงานกับ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.i_presentation_animation_player/), จะใช้คุณสมบัติ [get_Duration](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (ระยะเวลาทั้งหมดของแอนิเมชัน) และเมธอด [SetTimePosition](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). ตำแหน่งของแต่ละแอนิเมชันจะตั้งค่าในช่วง *0 ถึง duration* แล้วเมธอด `GetFrame` จะคืนค่า Bitmap ที่สอดคล้องกับสถานะแอนิเมชันในขณะนั้น.

```c++
#include <DOM/Animation/EffectPresetClassType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/FramesStream/IPresentationAnimationPlayer.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <IImage.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // สถานะแอนิเมชันเริ่มต้น
    System::SharedPtr<IImage> image = animationPlayer->GetFrame();
    // บิทแมปสถานะแอนิเมชันเริ่มต้น

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // สถานะสุดท้ายของแอนิเมชัน
    System::SharedPtr<IImage> lastImage = animationPlayer->GetFrame();
    // เฟรมสุดท้ายของแอนิเมชัน
    lastImage->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่มรูปสัญลักษณ์ยิ้มและทำแอนิเมชันให้
    System::SharedPtr<IAutoShape> smile = slide->get_Shapes()->AddAutoShape(ShapeType::SmileyFace, 110.0f, 20.0f, 500.0f, 500.0f);
    auto sequence = slide->get_Timeline()->get_MainSequence();
    System::SharedPtr<IEffect> effectIn = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::TopLeft, EffectTriggerType::AfterPrevious);
    System::SharedPtr<IEffect> effectOut = sequence->AddEffect(smile, EffectType::Fly, EffectSubtype::BottomRight, EffectTriggerType::AfterPrevious);
    effectIn->get_Timing()->set_Duration(2.0f);
    effectOut->set_PresetClassType(EffectPresetClassType::Exit);

    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    animationsGenerator->NewAnimation += OnNewAnimation;
}
```

เพื่อให้แอนิเมชันทั้งหมดในการนำเสนอเล่นพร้อมกัน จะใช้คลาส [PresentationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_player/) นี้รับอินสแตนซ์ของ [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_animations_generator/) และ FPS สำหรับเอฟเฟ็กต์ในคอนสตรัคเตอร์ แล้วเรียกเหตุการณ์ `FrameTick` สำหรับแอนิเมชันทั้งหมดเพื่อให้เล่น:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/FramesStream/FrameTickEventArgs.h>
#include <Export/FramesStream/PresentationAnimationsGenerator.h>
#include <Export/FramesStream/PresentationPlayer.h>
#include <IImage.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>(u"animated.pptx");
    auto animationsGenerator = System::MakeObject<PresentationAnimationsGenerator>(presentation);
    auto player = System::MakeObject<PresentationPlayer>(animationsGenerator, 33);

    player->FrameTick += OnFrameTick;
    animationsGenerator->Run(presentation->get_Slides());
}
```

จากนั้นเฟรมที่สร้างขึ้นสามารถนำมาประกอบเป็นวิดีโอได้ ดูส่วน [Convert PowerPoint to Video](https://docs.aspose.com/slides/th/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **แอนิเมชันและเอฟเฟ็กต์ที่รองรับ**


**การเข้า**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |


**การเน้น**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**การออก**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**เส้นทางการเคลื่อนที่:**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **คำถามที่พบบ่อย**

### สามารถแปลงการนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?

ใช่, Aspose.Slides รองรับการทำงานกับ [password-protected presentations](/slides/th/cpp/password-protected-presentation/). เมื่อประมวลผลไฟล์เหล่านี้ คุณต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของการนำเสนอได้.

### Aspose.Slides รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?

ใช่, Aspose.Slides สามารถผสานรวมกับแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีออกแบบมาสำหรับทำงานในสภาพแวดล้อมเซิร์ฟเวอร์ ทำให้มีประสิทธิภาพสูงและสเกลได้สำหรับการประมวลผลไฟล์เป็นชุด.

### มีข้อจำกัดขนาดของการนำเสนอในระหว่างการแปลงหรือไม่?

Aspose.Slides สามารถจัดการการนำเสนอที่มีขนาดใกล้เคียงกับใดก็ได้ อย่างไรก็ตาม เมื่อทำงานกับไฟล์ขนาดใหญ่มาก อาจต้องการทรัพยากรระบบเพิ่มเติม และบางครั้งแนะนำให้ทำการปรับปรุงการนำเสนอเพื่อเพิ่มประสิทธิภาพ.