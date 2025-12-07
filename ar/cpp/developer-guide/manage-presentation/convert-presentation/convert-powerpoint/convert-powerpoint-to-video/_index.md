---
title: تحويل عروض PowerPoint إلى فيديو في C++
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/cpp/convert-powerpoint-to-video/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
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
- حفظ PPT كـ MP4
- حفظ PPTX كـ MP4
- تصدير PPT إلى MP4
- تصدير PPTX إلى MP4
- تحويل الفيديو
- PowerPoint
- C++
- Aspose.Slides
description: "تعرف على كيفية تحويل عروض PowerPoint إلى فيديو في C++. اكتشف عينة الشفرة وتقنيات الأتمتة لتبسيط سير العمل الخاص بك."
---

## **نظرة عامة**

عن طريق تحويل عرض PowerPoint إلى فيديو، ستحصل على 

* **زيادة في سهولة الوصول:** جميع الأجهزة (بغض النظر عن النظام) مزودة بمشغلات فيديو افتراضيًا مقارنةً بتطبيقات فتح العروض، لذا يجد المستخدمون صعوبة أقل في فتح أو تشغيل الفيديوهات.
* **وصول أوسع:** من خلال الفيديوهات، يمكنك الوصول إلى جمهور كبير واستهدافهم بالمعلومات التي قد تبدو مملة في عرض تقديمي. تُظهر معظم الدراسات والإحصائيات أن الناس يشاهدون الفيديوهات ويستهلكونها أكثر من أشكال المحتوى الأخرى، وعادةً ما يفضلون هذا النوع من المحتوى.

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/)، نفذنا دعم تحويل العروض إلى فيديو. 

* استخدم Aspose.Slides لإنشاء مجموعة من الإطارات (من شرائح العرض) التي تتوافق مع معدل إطارات معين (FPS)
* استخدم أداة خارجية مثل `ffmpeg` لإنشاء فيديو بناءً على الإطارات.

## **تحويل عرض PowerPoint إلى فيديو**

1. تنزيل ffmpeg [من هنا](https://ffmpeg.org/download.html).
2. إضافة مسار `ffmpeg.exe` إلى المتغير البيئي `PATH`.
3. تشغيل كود تحويل PowerPoint إلى فيديو.

يعرض هذا الكود C++ كيفية تحويل عرض تقديمي (يحتوي على شكل وتأثيري تحريك) إلى فيديو:
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

    // يضيف شكلاً مبتسماً ثم يحركه
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

يمكنك تطبيق التحريكات على الكائنات داخل الشرائح واستخدام الانتقالات بين الشرائح.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على هذه المقالات: [رسوم متحركة PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-animation/)، [رسوم متحركة الأشكال](https://docs.aspose.com/slides/cpp/shape-animation/)، و[تأثير الشكل](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

تجعل التحريكات والانتقالات عروض الشرائح أكثر جاذبية وإثارة — وتؤدي نفس الفعل للفيديوهات. لنضيف شريحة وانتقالًا آخر إلى الكود الخاص بالعرض السابق:
```c++
// يضيف شكلاً مبتسماً ويحركه

// ...

// يضيف شريحة جديدة وانتقالًا متحركًا

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


تدعم Aspose.Slides أيضًا التحريك للنصوص. لذا نقوم بتحريك الفقرات على الكائنات، لتظهر واحدةً تلو الأخرى (مع تأخير يُضبط لثانية):
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

    // يضيف نصًا وتحريكات
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

لتمكينك من تنفيذ مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides الفئتين [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) و[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

تسمح لك PresentationAnimationsGenerator بتعيين حجم الإطار للفيديو (الذي سيُنشأ لاحقًا) عبر المُنشئ الخاص بها. إذا مررت كائن عرض تقديمي، سيتم استخدام `Presentation.SlideSize` وتولّد التحريكات التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). 

عند توليد التحريكات، يتم إنشاء حدث `NewAnimation` لكل تحريك لاحق، ويحتوي على معامل [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). هذه الفئة تمثّل مشغلًا لتحريك منفصل.

للتعامل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)، تُستخدم الخاصية [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (المدة الكلية للتحريك) والطريقة [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). يُضبط موقع كل تحريك ضمن النطاق *0 إلى المدة*، ثم تُعيد طريقة `GetFrame` صورة Bitmap تمثّل حالة التحريك في تلك اللحظة.
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // حالة التحريك الأولية
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // صورة bitmap لحالة التحريك الأولية

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // حالة التحريك النهائية
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // الإطار الأخير للتحريك
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // يضيف شكلاً مبتسماً ويحمّله
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


لجعل جميع التحريكات في عرض تقديمي تُشغَل في آنٍ واحد، تُستخدم فئة [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). تأخذ هذه الفئة كائنًا من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) وFPS للتأثيرات في مُنشئها ثم تستدعي حدث `FrameTick` لجميع التحريكات لتشغيلها:
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


بعد ذلك يمكن تجميع الإطارات المُولّدة لإنتاج فيديو. راجع قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **التحريكات والتأثيرات المدعومة**


**دخول**:

| نوع التحريك | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظهور** | ![not supported](x.png) | ![supported](v.png) |
| **تلاشي** | ![supported](v.png) | ![supported](v.png) |
| **تحليق داخلي** | ![supported](v.png) | ![supported](v.png) |
| **طفو داخلي** | ![supported](v.png) | ![supported](v.png) |
| **انقسام** | ![supported](v.png) | ![supported](v.png) |
| **مسح** | ![supported](v.png) | ![supported](v.png) |
| **شكل** | ![supported](v.png) | ![supported](v.png) |
| **عجلة** | ![supported](v.png) | ![supported](v.png) |
| **أشرطة عشوائية** | ![supported](v.png) | ![supported](v.png) |
| **نمو وتدوير** | ![not supported](x.png) | ![supported](v.png) |
| **تكبير** | ![supported](v.png) | ![supported](v.png) |
| **دوران** | ![supported](v.png) | ![supported](v.png) |
| **قفز** | ![supported](v.png) | ![supported](v.png) |


**تأكيد**:

| نوع التحريك | Aspose.Slides | PowerPoint |
|---|---|---|
| **نبضة** | ![not supported](x.png) | ![supported](v.png) |
| **نبضة لون** | ![not supported](x.png) | ![supported](v.png) |
| **تأرجح** | ![supported](v.png) | ![supported](v.png) |
| **دوران** | ![supported](v.png) | ![supported](v.png) |
| **نمو/تصغير** | ![not supported](x.png) | ![supported](v.png) |
| **إزالة تشبع** | ![not supported](x.png) | ![supported](v.png) |
| **تغميق** | ![not supported](x.png) | ![supported](v.png) |
| **تخفيف** | ![not supported](x.png) | ![supported](v.png) |
| **شفافية** | ![not supported](x.png) | ![supported](v.png) |
| **لون الكائن** | ![not supported](x.png) | ![supported](v.png) |
| **لون مكمل** | ![not supported](x.png) | ![supported](v.png) |
| **لون الخط** | ![not supported](x.png) | ![supported](v.png) |
| **لون التعبئة** | ![not supported](x.png) | ![supported](v.png) |

**خروج**:

| نوع التحريك | Aspose.Slides | PowerPoint |
|---|---|---|
| **اختفاء** | ![not supported](x.png) | ![supported](v.png) |
| **تلاشي** | ![supported](v.png) | ![supported](v.png) |
| **تحليق خارجي** | ![supported](v.png) | ![supported](v.png) |
| **طفو خارجي** | ![supported](v.png) | ![supported](v.png) |
| **انقسام** | ![supported](v.png) | ![supported](v.png) |
| **مسح** | ![supported](v.png) | ![supported](v.png) |
| **شكل** | ![supported](v.png) | ![supported](v.png) |
| **أشرطة عشوائية** | ![supported](v.png) | ![supported](v.png) |
| **تصغير وتدوير** | ![not supported](x.png) | ![supported](v.png) |
| **تكبير** | ![supported](v.png) | ![supported](v.png) |
| **دوران** | ![supported](v.png) | ![supported](v.png) |
| **قفز** | ![supported](v.png) | ![supported](v.png) |

**مسارات حركة**:

| نوع التحريك | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![supported](v.png) | ![supported](v.png) |
| **أقواس** | ![supported](v.png) | ![supported](v.png) |
| **تحولات** | ![supported](v.png) | ![supported](v.png) |
| **أشكال** | ![supported](v.png) | ![supported](v.png) |
| **دوائر** | ![supported](v.png) | ![supported](v.png) |
| **مسار مخصص** | ![supported](v.png) | ![supported](v.png) |

## **الأسئلة الشائعة**

**هل يمكن تحويل العروض المحمية بكلمة مرور؟**

نعم، تسمح Aspose.Slides بالعمل مع [العروض المحمية بكلمة مرور](/slides/ar/cpp/password-protected-presentation/). عند معالجة هذه الملفات، يلزم توفير كلمة المرور الصحيحة حتى يتمكن المكتبة من الوصول إلى محتوى العرض.

**هل تدعم Aspose.Slides الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides في تطبيقات وخدمات السحابة. صُممت المكتبة للعمل في بيئات الخادم، مما يضمن أداءً عاليًا وقابلية توسّع لمعالجة الملفات على دفعات.

**هل هناك قيود على حجم العروض أثناء التحويل؟**

تمتلك Aspose.Slides القدرة على معالجة عروض ذات حجم شبه غير محدود. ومع ذلك، عند العمل مع ملفات كبيرة جدًا، قد تُحتاج موارد نظام إضافية، ومن المُستحسن أحيانًا تحسين العرض لتحسين الأداء.