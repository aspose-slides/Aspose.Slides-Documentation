---
title: تحويل PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/cpp/convert-powerpoint-to-video/
keywords: "تحويل PowerPoint, PPT, PPTX, عرض, فيديو, MP4, PPT إلى فيديو, PPT إلى MP4, C++, Aspose.Slides"
description: "تحويل PowerPoint إلى الفيديو باستخدام Aspose.Slides لـ C++ API"
---

من خلال تحويل عرض PowerPoint الخاص بك إلى فيديو، تحصل على 

* **زيادة في الوصول:** جميع الأجهزة (بغض النظر عن النظام الأساسي) مزودة بلاعبات فيديو بشكل افتراضي مقارنةً بتطبيقات فتح العروض، لذا يجد المستخدمون أنه من الأسهل فتح أو تشغيل مقاطع الفيديو.
* **نطاق أوسع:** يمكنك من خلال مقاطع الفيديو الوصول إلى جمهور كبير واستهدافهم بمعلومات قد تبدو مملة بخلاف ذلك في عرض. تشير معظم الاستطلاعات والإحصائيات إلى أن الناس يشاهدون ويستهلكون مقاطع الفيديو أكثر من أشكال المحتوى الأخرى، وعادةً ما يفضلون مثل هذا المحتوى.

## **تحويل PowerPoint إلى فيديو في Aspose.Slides**

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/)، قمنا بتنفيذ دعم تحويل العرض إلى فيديو. 

* استخدم Aspose.Slides لتوليد مجموعة من الإطارات (من شرائح العرض) التي تتوافق مع معدل إطارات معين (إطارات في الثانية)
* استخدم أداة خارجية مثل `ffmpeg` لإنشاء فيديو بناءً على الإطارات.

### **تحويل PowerPoint إلى فيديو**

1. قم بتنزيل ffmpeg [هنا](https://ffmpeg.org/download.html).
2. أضف المسار إلى `ffmpeg.exe` إلى متغير البيئة `PATH`.
3. قم بتشغيل كود تحويل PowerPoint إلى فيديو.

هذا الكود C++ يوضح لك كيفية تحويل عرض (يحتوي على شكل وصفتين متحركتين) إلى فيديو:

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

    // يضيف شكل مبتسم ثم يحركه
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

يمكنك تطبيق الرسوم المتحركة على الكائنات على الشرائح واستخدام الانتقالات بين الشرائح.

{{% alert color="primary" %}} 

قد ترغب في رؤية هذه المقالات: [رسوم متحركة PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-animation/)، [رسوم متحركة الشكل](https://docs.aspose.com/slides/cpp/shape-animation/)، و[تأثير الشكل](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات العروض التقديمية أكثر جاذبية واهتمامًا—وهي تفعل نفس الشيء بالنسبة للفيديوهات. دعنا نضيف شريحة أخرى وانتقالًا إلى الكود الخاص بالعرض السابق:

```c++
// يضيف شكل مبتسم ثم يحركه

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

يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا نقوم بتحريك الفقرات على الكائنات، والتي ستظهر واحدة تلو الأخرى (مع التأخير المحدد إلى ثانية):

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

    // يضيف نصوصًا ورسوم متحركة
    System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210.0f, 120.0f, 300.0f, 300.0f);
    System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
    para1->get_Portions()->Add(System::MakeObject<Portion>(u"Aspose Slides for C++"));
    System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
    para2->get_Portions()->Add(System::MakeObject<Portion>(u"تحويل عرض PowerPoint مع نص إلى فيديو"));

    System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
    para3->get_Portions()->Add(System::MakeObject<Portion>(u"فقرة تلو الأخرى"));
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

    // تحويل الإطارات إلى فيديو
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

لتتمكن من تنفيذ مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) و[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) كلاس.

يتيح لك PresentationAnimationsGenerator تعيين حجم الإطار للفيديو (الذي سيتم إنشاؤه لاحقًا) من خلال مُنشئه. إذا قمت بتمرير مثيل العرض، فسيتم استخدام `Presentation.SlideSize` وتوليد الرسوم المتحركة التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). 

عند توليد الرسوم المتحركة، يتم إنشاء حدث `NewAnimation` لكل رسوم متحركة تالية، والذي يحتوي على المعامل [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). الأخير هو كلاس يمثل مشغلًا لرسوم متحركة منفصلة.

للاستفادة من [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)، يتم استخدام خاصية [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (المدة الكاملة للرسوم المتحركة) و[SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0) الطريقة. يتم تعيين كل موضع رسوم متحركة ضمن نطاق *0 إلى المدة*، ثم ستعيد `GetFrame` طريقة صورة متجهة تتوافق مع حالة الرسوم المتحركة في تلك اللحظة.

```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"المدة الإجمالية للرسوم المتحركة: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // حالة الرسوم المتحركة الأولية
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // صورة حالة الرسوم المتحركة الأولية

    animationPlayer->SetTimePosition(animationPlayer->get_Duration());
    // الحالة النهائية للرسوم المتحركة
    System::SharedPtr<System::Drawing::Bitmap> lastBitmap = animationPlayer->GetFrame();
    // الإطار الأخير من الرسوم المتحركة
    lastBitmap->Save(u"last.png");
}

void Run()
{
    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // يضيف شكل مبتسم ثم يحركه
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

لجعل جميع الرسوم المتحركة في العرض تلعب معًا، يتم استخدام [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) كلاس. يستقبل هذا الكلاس مثيلًا من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) وFPS للتأثيرات في مُنشئه، ثم يستدعي حدث `FrameTick` لجميع الرسوم المتحركة لتشغيلها:

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

ثم يمكن تجميع الإطارات الناتجة لإنتاج فيديو. انظر قسم [تحويل PowerPoint إلى فيديو](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة والتأثيرات المدعومة**


**الدخول**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظهور** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **طيران داخلي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **عائم داخلي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دائرة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو وتدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوار** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |


**التأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **نبضة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **نبضة اللون** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **توازن** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوران** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو/تقليص** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تتلاشى** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تعتيم** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تيسير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **شفافية** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الكائن** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون مكمل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الخط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون التعبئة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**الخروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **اختفاء** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **طيران خارجي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **عائم خارجي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تقليص وتدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوار** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مسارات الحركة:**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوائر** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **اللفات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشكال** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **حلقات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسار مخصص** | ![مدعوم](v.png) | ![مدعوم](v.png) |