---
title: แปลงงานนำเสนอ PowerPoint เป็นวิดีโอใน C++
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/cpp/convert-powerpoint-to-video/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็นวิดีโอ
- งานนำเสนอเป็นวิดีโอ
- PPT เป็นวิดีโอ
- PPTX เป็นวิดีโอ
- PowerPoint เป็น MP4
- งานนำเสนอเป็น MP4
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
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint เป็นวิดีโอใน C++. ค้นหาโค้ดตัวอย่างและเทคนิคการอัตโนมัติเพื่อเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **บทนำ**

โดยการแปลงงานนำเสนอ PowerPoint ของคุณเป็นวิดีโอ คุณจะได้

* **เพิ่มความเข้าถึงได้:** ทุกอุปกรณ์ (ไม่ว่าจะเป็นแพลตฟอร์มใด) มีโปรแกรมเล่นวิดีโอเป็นค่าเริ่มต้นเมื่อเทียบกับแอปพลิเคชันเปิดงานนำเสนอ ทำให้ผู้ใช้เปิดหรือเล่นวิดีโอได้ง่ายขึ้น
* **เข้าถึงได้มากขึ้น:** ผ่านวิดีโอ คุณสามารถเข้าถึงผู้ชมจำนวนมากและนำเสนอข้อมูลที่อาจดูน่าเบื่อในงานนำเสนอ ตามการสำรวจและสถิติส่วนใหญ่ ผู้คนมักดูและบริโภควิดีโอมากกว่ารูปแบบเนื้อหาอื่น ๆ และโดยทั่วไปพวกเขาชอบเนื้อหานั้น

ใน [Aspose.Slides 22.11](https://docs.aspose.com/slides/th/cpp/aspose-slides-for-cpp-22-11-release-notes/), เราเพิ่มการสนับสนุนการแปลงงานนำเสนอเป็นวิดีโอ

* ใช้ Aspose.Slides เพื่อสร้างชุดเฟรม (จากสไลด์งานนำเสนอ) ที่สอดคล้องกับ FPS (เฟรมต่อวินาที) ที่ระบุ
* ใช้เครื่องมือของบุคคลที่สามเช่น `ffmpeg` เพื่อสร้างวิดีโอตามเฟรมเหล่านั้น

## **แปลงงานนำเสนอ PowerPoint เป็นวิดีโอ**

1. ดาวน์โหลด ffmpeg [here](https://ffmpeg.org/download.html).
2. เพิ่มพาธไปยัง `ffmpeg.exe` ในตัวแปรสภาพแวดล้อม `PATH`.
3. รันโค้ดแปลง PowerPoint เป็นวิดีโอ

โค้ด C++ นี้แสดงวิธีแปลงงานนำเสนอ (ที่มีรูปภาพและสองเอฟเฟกต์แอนิเมชัน) เป็นวิดีโอ:

```c++
void OnFrameTick(System::SharedPtr<PresentationPlayer> sender, System::SharedPtr<FrameTickEventArgs> args)
{
    System::String fileName = System::String::Format(u"frame_{0}.png", sender->get_FrameIndex());
    args->GetFrame()->Save(fileName);
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่มรูปแบบรอยยิ้มแล้วทำแอนิเมชันให้
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **เอฟเฟกต์วิดีโอ**

คุณสามารถใส่แอนิเมชันให้กับวัตถุบนสไลด์และใช้การเปลี่ยนผ่านระหว่างสไลด์ได้

{{% alert color="primary" %}} 
คุณอาจต้องการอ่านบทความเหล่านี้: [PowerPoint Animation](https://docs.aspose.com/slides/th/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/th/cpp/shape-animation/), และ [Shape Effect](https://docs.aspose.com/slides/th/cpp/shape-effect/).
{{% /alert %}} 

แอนิเมชันและการเปลี่ยนผ่านทำให้การแสดงสไลด์มีชีวิตชีวาและน่าสนใจ—และทำเช่นเดียวกันกับวิดีโอ มาเพิ่มสไลด์และการเปลี่ยนผ่านอีกหนึ่งสไลด์ลงในโค้ดของงานนำเสนอก่อนหน้า:

```c++
// เพิ่มรูปแบบรอยยิ้มและทำแอนิเมชันให้

// ...

// เพิ่มสไลด์ใหม่และการเปลี่ยนผ่านแบบแอนิเมชัน

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```

Aspose.Slides ยังสนับสนุนแอนิเมชันสำหรับข้อความด้วย เราจึงแอนิเมทย่อหน้าบนวัตถุให้ปรากฏต่อเนื่องกัน (โดยตั้งค่าหน่วงเวลาเป็นหนึ่งวินาที):

```c++
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
        u"warning", m_fps, "frame_%d.png", u"libx264", u"yuv420p", "video.mp4");
    auto ffmpegProcess = System::Diagnostics::Process::Start(u"ffmpeg", ffmpegParameters);
    ffmpegProcess->WaitForExit();
}
```

## **คลาสสำหรับการแปลงวิดีโอ**

เพื่อให้คุณทำงานแปลง PowerPoint เป็นวิดีโอได้, Aspose.Slides มีคลาส [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_animations_generator/) และ [PresentationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_player/) ให้ใช้

PresentationAnimationsGenerator ให้คุณตั้งขนาดเฟรมของวิดีโอ (ที่จะสร้างต่อไป) ผ่านคอนสตรัคเตอร์ของมัน หากคุณส่งอินสแตนซ์ของงานนำเสนอ, `Presentation.SlideSize` จะถูกใช้และมันจะสร้างแอนิเมชันที่ [PresentationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_player/) ใช้

เมื่อแอนิเมชันถูกสร้าง, เหตุการณ์ `NewAnimation` จะถูกสร้างสำหรับแต่ละแอนิเมชันต่อเนื่อง, ซึ่งมีพารามิเตอร์ประเภท [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.i_presentation_animation_player/) ตัวหลังเป็นคลาสที่แทนผู้เล่นสำหรับแอนิเมชันแยกต่างหาก

เพื่อทำงานกับ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.i_presentation_animation_player/), ใช้คุณสมบัติ [get_Duration](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (ระยะเวลาทั้งหมดของแอนิเมชัน) และเมธอด [SetTimePosition](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) แต่ละตำแหน่งแอนิเมชันจะถูกตั้งค่าในช่วง *0 ถึง duration* จากนั้นเมธอด `GetFrame` จะคืนค่า Bitmap ที่สอดคล้องกับสถานะแอนิเมชันในขณะนั้น

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // สถานะเริ่มต้นของแอนิเมชัน
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // บิทแมปสถานะเริ่มต้นของแอนิเมชัน

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // สถานะสุดท้ายของแอนิเมชัน
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // เฟรมสุดท้ายของแอนิเมชัน
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่มรูปแบบรอยยิ้มและทำแอนิเมชันให้
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

เพื่อให้แอนิเมชันทั้งหมดในงานนำเสนอเล่นพร้อมกัน, ใช้คลาส [PresentationPlayer](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_player/) คลาสนี้รับอินสแตนซ์ของ [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.presentation_animations_generator/) และ FPS สำหรับเอฟเฟกต์ในคอนสตรัคเตอร์ แล้วเรียกเหตุการณ์ `FrameTick` สำหรับแอนิเมชันทั้งหมดเพื่อให้เล่น:

```c++
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

จากนั้นเฟรมที่สร้างจะถูกคอมไพล์เพื่อผลิตวิดีโอ ดูส่วน [แปลง PowerPoint เป็นวิดีโอ](https://docs.aspose.com/slides/th/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video) เพื่อรายละเอียดเพิ่มเติม

## **แอนิเมชันและเอฟเฟกต์ที่สนับสนุน**


**Entrance**:

| Animation Type | Aspose.Slides | PowerPoint |
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


**Emphasis**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Exit**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Motion Paths**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**สามารถแปลงงานนำเสนอที่มีการตั้งรหัสผ่านได้หรือไม่?**

ใช่, Aspose.Slides รองรับการทำงานกับ [password‑protected presentations](/slides/th/cpp/password-protected-presentation/). เมื่อประมวลผลไฟล์ดังกล่าว คุณต้องใส่รหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของงานนำเสนอได้

**Aspose.Slides รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?**

ใช่, Aspose.Slides สามารถผสานรวมกับแอปพลิเคชันและบริการบนคลาวด์ได้ ไลบรารีออกแบบมาสำหรับสภาพแวดล้อมเซิร์ฟเวอร์ เพื่อให้ได้ประสิทธิภาพสูงและขยายตัวได้ดีสำหรับการประมวลผลไฟล์เป็นชุด

**มีข้อจำกัดขนาดของงานนำเสนอระหว่างการแปลงหรือไม่?**

Aspose.Slides สามารถจัดการงานนำเสนอขนาดใด ๆ ก็ได้ อย่างไรก็ตาม เมื่อทำงานกับไฟล์ที่มีขนาดใหญ่มาก อาจต้องการทรัพยากรระบบเพิ่มเติม และบางครั้งแนะนำให้ทำการปรับขนาดงานนำเสนอเพื่อเพิ่มประสิทธิภาพ