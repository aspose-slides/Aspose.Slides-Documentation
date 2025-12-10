---
title: تحويل عروض PowerPoint إلى فيديو باستخدام C++
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/cpp/convert-powerpoint-to-video/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى فيديو
- العرض إلى فيديو
- PPT إلى فيديو
- PPTX إلى فيديو
- PowerPoint إلى MP4
- العرض إلى MP4
- PPT إلى MP4
- PPTX إلى MP4
- حفظ PPT كملف MP4
- حفظ PPTX كملف MP4
- تصدير PPT إلى MP4
- تصدير PPTX إلى MP4
- تحويل الفيديو
- PowerPoint
- C++
- Aspose.Slides
description: "تعرّف على كيفية تحويل عروض PowerPoint إلى فيديو باستخدام C++. اكتشف عينة التعليمات البرمجية وتقنيات الأتمتة لتبسيط سير العمل الخاص بك."
---

## **نظرة عامة**

من خلال تحويل عرض PowerPoint إلى فيديو، ستحصل على

* **زيادة في إمكانية الوصول:** جميع الأجهزة (بغض النظر عن النظام الأساسي) مجهزة بمشغلات فيديو بشكل افتراضي مقارنةً بتطبيقات فتح العروض، لذا يجد المستخدمون أنه من الأسهل فتح أو تشغيل الفيديوهات.
* **نطاق أوسع:** من خلال الفيديوهات، يمكنك الوصول إلى جمهور كبير وتوجيههم إلى معلومات قد تبدو مملة في عرض تقديمي. تشير معظم الدراسات والإحصاءات إلى أن الناس يشاهدون الفيديوهات ويستهلكونها أكثر من أشكال المحتوى الأخرى، وهم يميلون عادةً إلى هذا النوع من المحتوى.

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/)، قمنا بتنفيذ دعم تحويل العروض إلى فيديو.

* استخدم Aspose.Slides لإنشاء مجموعة من الإطارات (من شرائح العرض) التي تتوافق مع معدل إطارات معين (FPS) (إطارات في الثانية).
* استخدم أداة طرف ثالث مثل `ffmpeg` لإنشاء فيديو بناءً على الإطارات.

## **تحويل عرض PowerPoint إلى فيديو**

1. قم بتنزيل ffmpeg [هنا](https://ffmpeg.org/download.html).
2. أضف مسار `ffmpeg.exe` إلى متغير البيئة `PATH`.
3. شغّل كود تحويل PowerPoint إلى فيديو.

يُظهر لك هذا الكود C++ كيفية تحويل عرض (يحتوي على شكل وتأثيري تحريك) إلى فيديو:
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

    // يضيف شكلاً مبتسمًا ثم يحركه
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


## **تأثيرات الفيديو**

يمكنك تطبيق رسوم متحركة على الكائنات في الشرائح واستخدام الانتقالات بين الشرائح.

{{% alert color="primary" %}} 
قد ترغب في الاطلاع على هذه المقالات: [PowerPoint Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cpp/shape-animation/), و[Shape Effect](https://docs.aspose.com/slides/cpp/shape-effect/).
{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات عروض الشرائح أكثر جاذبية وإثارة — وتؤدي نفس الغرض للفيديوهات. دعنا نضيف شريحة أخرى وانتقالًا إلى الكود الخاص بالعرض السابق:
```c++
// يضيف شكلاً مبتسماً ويقوم بتحريكه

// ...

// يضيف شريحة جديدة وانتقال متحرك

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


كما يدعم Aspose.Slides الرسوم المتحركة للنصوص. لذا نقوم بتحريك الفقرات على الكائنات، والتي ستظهر واحدة تلو الأخرى (مع ضبط التأخير إلى ثانية واحدة):
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

    // يضيف نصًا ورسومًا متحركة
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

    // يحول الإطارات إلى فيديو
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


## **فئات تحويل الفيديو**

لتتمكن من تنفيذ مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides فئتي [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) و[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

تتيح لك PresentationAnimationsGenerator تعيين حجم الإطار للفيديو (الذي سيُنشأ لاحقًا) عبر المُنشئ الخاص بها. إذا قمت بتمرير نسخة من العرض، سيتم استخدام `Presentation.SlideSize` وتولّد الرسوم المتحركة التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

عند توليد الرسوم المتحركة، يتم إنشاء حدث `NewAnimation` لكل حركة لاحقة، والذي يحتوي على معامل [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). هذا الأخير هو فئة تمثل مشغلًا لحركة منفصلة.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)، يتم استخدام خاصية [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (المدة الكاملة للرسوم المتحركة) وطريقة [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). يتم تعيين موضع كل حركة ضمن النطاق *0 إلى المدة*، ثم تُعيد طريقة `GetFrame` صورة Bitmap تتوافق مع حالة الحركة في تلك اللحظة.
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // حالة الرسوم المتحركة الأولية
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // صورة bitmap لحالة الرسوم المتحركة الأولية

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // الحالة النهائية للرسوم المتحركة
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // الإطار الأخير للرسوم المتحركة
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // يضيف شكلًا مبتسمًا ويقوم بتحريكه
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


لجعل جميع الرسوم المتحركة في عرض تقديمي تُشغل مرة واحدة، يتم استخدام فئة [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). تأخذ هذه الفئة نسخة من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) ومعدل FPS لل Effects في مُنشئها، ثم تُستدعي حدث `FrameTick` لجميع الرسوم المتحركة لتشغيلها:
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


بعد ذلك يمكن تجميع الإطارات المُولدة لإنتاج فيديو. انظر قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة والتأثيرات المدعومة**

**الدخول**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| Appear | ![not supported](x.png) | ![supported](v.png) |
| Fade | ![supported](v.png) | ![supported](v.png) |
| Fly In | ![supported](v.png) | ![supported](v.png) |
| Float In | ![supported](v.png) | ![supported](v.png) |
| Split | ![supported](v.png) | ![supported](v.png) |
| Wipe | ![supported](v.png) | ![supported](v.png) |
| Shape | ![supported](v.png) | ![supported](v.png) |
| Wheel | ![supported](v.png) | ![supported](v.png) |
| Random Bars | ![supported](v.png) | ![supported](v.png) |
| Grow & Turn | ![not supported](x.png) | ![supported](v.png) |
| Zoom | ![supported](v.png) | ![supported](v.png) |
| Swivel | ![supported](v.png) | ![supported](v.png) |
| Bounce | ![supported](v.png) | ![supported](v.png) |

**التأكيد**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| Pulse | ![not supported](x.png) | ![supported](v.png) |
| Color Pulse | ![not supported](x.png) | ![supported](v.png) |
| Teeter | ![supported](v.png) | ![supported](v.png) |
| Spin | ![supported](v.png) | ![supported](v.png) |
| Grow/Shrink | ![not supported](x.png) | ![supported](v.png) |
| Desaturate | ![not supported](x.png) | ![supported](v.png) |
| Darken | ![not supported](x.png) | ![supported](v.png) |
| Lighten | ![not supported](x.png) | ![supported](v.png) |
| Transparency | ![not supported](x.png) | ![supported](v.png) |
| Object Color | ![not supported](x.png) | ![supported](v.png) |
| Complementary Color | ![not supported](x.png) | ![supported](v.png) |
| Line Color | ![not supported](x.png) | ![supported](v.png) |
| Fill Color | ![not supported](x.png) | ![supported](v.png) |

**الخروج**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| Disappear | ![not supported](x.png) | ![supported](v.png) |
| Fade | ![supported](v.png) | ![supported](v.png) |
| Fly Out | ![supported](v.png) | ![supported](v.png) |
| Float Out | ![supported](v.png) | ![supported](v.png) |
| Split | ![supported](v.png) | ![supported](v.png) |
| Wipe | ![supported](v.png) | ![supported](v.png) |
| Shape | ![supported](v.png) | ![supported](v.png) |
| Random Bars | ![supported](v.png) | ![supported](v.png) |
| Shrink & Turn | ![not supported](x.png) | ![supported](v.png) |
| Zoom | ![supported](v.png) | ![supported](v.png) |
| Swivel | ![supported](v.png) | ![supported](v.png) |
| Bounce | ![supported](v.png) | ![supported](v.png) |

**مسارات الحركة**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| Lines | ![supported](v.png) | ![supported](v.png) |
| Arcs | ![supported](v.png) | ![supported](v.png) |
| Turns | ![supported](v.png) | ![supported](v.png) |
| Shapes | ![supported](v.png) | ![supported](v.png) |
| Loops | ![supported](v.png) | ![supported](v.png) |
| Custom Path | ![supported](v.png) | ![supported](v.png) |

## **الأسئلة المتكررة**

**هل يمكن تحويل العروض المحمية بكلمة مرور؟**

نعم، يتيح Aspose.Slides العمل مع [العروض المحمية بكلمة مرور](/slides/ar/cpp/password-protected-presentation/). عند معالجة هذه الملفات، يجب توفير كلمة المرور الصحيحة حتى يتمكن المكتبة من الوصول إلى محتوى العرض.

**هل يدعم Aspose.Slides الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides في تطبيقات وخدمات السحابة. تم تصميم المكتبة للعمل في بيئات الخادم، مما يضمن أداءً عاليًا وقابلية توسيع لمعالجة ملفات الدُفعات.

**هل هناك أي حدود لحجم العروض أثناء التحويل؟**

يستطيع Aspose.Slides التعامل مع عروض بحجم شبه غير محدود. ومع ذلك، عند العمل على ملفات كبيرة جدًا، قد تكون هناك حاجة إلى موارد نظام إضافية، ويُنصح أحيانًا بتحسين العرض لتحسين الأداء.