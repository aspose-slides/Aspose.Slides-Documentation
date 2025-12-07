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
- العرض التقديمي إلى فيديو
- PPT إلى فيديو
- PPTX إلى فيديو
- PowerPoint إلى MP4
- العرض التقديمي إلى MP4
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
description: "تعلم كيفية تحويل عروض PowerPoint إلى فيديو في C++. اكتشف نماذج الشيفرة وتقنيات الأتمتة لتبسيط سير عملك."
---

## **نظرة عامة**

عن طريق تحويل عرض PowerPoint التقديمي إلى فيديو، ستحصل على 

* **زيادة إمكانية الوصول:** جميع الأجهزة (بغض النظر عن النظام الأساسي) مجهزة ببرامج تشغيل الفيديو بشكل افتراضي مقارنةً بتطبيقات فتح العروض التقديمية، لذا يجد المستخدمون أنه من الأسهل فتح أو تشغيل مقاطع الفيديو.
* **نطاق أوسع:** من خلال الفيديوهات، يمكنك الوصول إلى جمهور كبير وتوجيههم بمعلومات قد تبدو مملة في عرض تقديمي. تشير معظم الاستطلاعات والإحصاءات إلى أن الناس يشاهدون ويستهلكون مقاطع الفيديو أكثر من أشكال المحتوى الأخرى، وعادةً ما يفضلون هذا النوع من المحتوى.

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/)، نفّذنا دعم تحويل العرض التقديمي إلى فيديو. 

* استخدم Aspose.Slides لتوليد مجموعة من الإطارات (من شرائح العرض) التي تتوافق مع معدل إطارات معين (FPS).
* استخدم أداة طرف ثالث مثل `ffmpeg` لإنشاء فيديو بناءً على الإطارات.

## **تحويل عرض PowerPoint إلى فيديو**

1. حمّل ffmpeg [هنا](https://ffmpeg.org/download.html).
2. أضف مسار `ffmpeg.exe` إلى متغير البيئة `PATH`.
3. شغّل كود تحويل PowerPoint إلى فيديو.

هذا الكود C++ يوضح لك كيفية تحويل عرض تقديمي (يحتوي على شكل وتأثيرين حركيين) إلى فيديو:
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

    // يضيف شكل ابتسامة ثم يحركه
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

يمكنك تطبيق الرسوم المتحركة على الكائنات في الشرائح واستخدام الانتقالات بين الشرائح.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على هذه المقالات: [PowerPoint Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cpp/shape-animation/), و[Shape Effect](https://docs.aspose.com/slides/cpp/shape-effect/).

{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات عروض الشرائح أكثر جاذبية وإثارة — وتفعل الشيء نفسه للفيديوهات. دعنا نضيف شريحة أخرى وانتقالًا إلى الكود للعرض التقديمي السابق:
```c++
// يضيف شكل ابتسامة ويُحركه

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


يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا نقوم بتحريك الفقرات على الكائنات، بحيث تظهر واحدة تلو الأخرى (مع تأخير مدته ثانية واحدة):
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

    // يضيف النص والرسوم المتحركة
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

لتمكينك من تنفيذ مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides فئتي [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) و[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) .

تسمح لك PresentationAnimationsGenerator بتحديد حجم الإطار للفيديو (الذي سيتم إنشاؤه لاحقًا) عبر المُنشئ الخاص بها. إذا قمت بتمرير نسخة من العرض التقديمي، سيتم استخدام `Presentation.SlideSize` وتولد الرسوم المتحركة التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/) .

عند توليد الرسوم المتحركة، يتم إنشاء حدث `NewAnimation` لكل حركة متتالية، والذي يحتوي على معامل [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). الأخير هو فئة تمثل مشغلًا لحركة منفصلة.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)، يتم استخدام خاصية [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (المدة الكاملة للرسوم المتحركة) والطريقة [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). يتم تعيين كل موقع للرسوم المتحركة ضمن النطاق *0 إلى المدة*، ثم ستعيد طريقة `GetFrame` صورة Bitmap تتوافق مع حالة الرسوم المتحركة في تلك اللحظة.
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

    // يضيف شكل ابتسامة ويُحركه
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


لجعل جميع الرسوم المتحركة في عرض تقديمي تُشغل مرة واحدة، تُستخدم فئة [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). تأخذ هذه الفئة نسخة من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) ومعدل FPS للتأثيرات في مُنشئها ثم تستدعي حدث `FrameTick` لجميع الرسوم المتحركة لتشغيلها:
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


بعد ذلك يمكن تجميع الإطارات المولدة لإنتاج فيديو. راجع قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة والتأثيرات المدعومة**


**الدخول**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظهور** | ![not supported](x.png) | ![supported](v.png) |
| **تلاشي** | ![supported](v.png) | ![supported](v.png) |
| **تحليق داخلي** | ![supported](v.png) | ![supported](v.png) |
| **انزلاق داخلي** | ![supported](v.png) | ![supported](v.png) |
| **انقسام** | ![supported](v.png) | ![supported](v.png) |
| **مسح** | ![supported](v.png) | ![supported](v.png) |
| **شكل** | ![supported](v.png) | ![supported](v.png) |
| **عجلة** | ![supported](v.png) | ![supported](v.png) |
| **أشرطة عشوائية** | ![supported](v.png) | ![supported](v.png) |
| **نمو وتدوير** | ![not supported](x.png) | ![supported](v.png) |
| **تكبير** | ![supported](v.png) | ![supported](v.png) |
| **تدوير** | ![supported](v.png) | ![supported](v.png) |
| **ارتداد** | ![supported](v.png) | ![supported](v.png) |


**التشديد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **نَبْض** | ![not supported](x.png) | ![supported](v.png) |
| **نَبْض اللون** | ![not supported](x.png) | ![supported](v.png) |
| **تأرجح** | ![supported](v.png) | ![supported](v.png) |
| **دوران** | ![supported](v.png) | ![supported](v.png) |
| **تكبير/تصغير** | ![not supported](x.png) | ![supported](v.png) |
| **إزالة التشبع** | ![not supported](x.png) | ![supported](v.png) |
| **تغميق** | ![not supported](x.png) | ![supported](v.png) |
| **تفتيح** | ![not supported](x.png) | ![supported](v.png) |
| **شفافية** | ![not supported](x.png) | ![supported](v.png) |
| **لون الكائن** | ![not supported](x.png) | ![supported](v.png) |
| **اللون المكمل** | ![not supported](x.png) | ![supported](v.png) |
| **لون الخط** | ![not supported](x.png) | ![supported](v.png) |
| **لون التعبئة** | ![not supported](x.png) | ![supported](v.png) |

**الخروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **اختفاء** | ![not supported](x.png) | ![supported](v.png) |
| **تلاشي** | ![supported](v.png) | ![supported](v.png) |
| **تحليق خارجي** | ![supported](v.png) | ![supported](v.png) |
| **انزلاق خارجي** | ![supported](v.png) | ![supported](v.png) |
| **انقسام** | ![supported](v.png) | ![supported](v.png) |
| **مسح** | ![supported](v.png) | ![supported](v.png) |
| **شكل** | ![supported](v.png) | ![supported](v.png) |
| **أشرطة عشوائية** | ![supported](v.png) | ![supported](v.png) |
| **تصغير وتدوير** | ![not supported](x.png) | ![supported](v.png) |
| **تكبير** | ![supported](v.png) | ![supported](v.png) |
| **تدوير** | ![supported](v.png) | ![supported](v.png) |
| **ارتداد** | ![supported](v.png) | ![supported](v.png) |

**مسارات الحركة:**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![supported](v.png) | ![supported](v.png) |
| **أقواس** | ![supported](v.png) | ![supported](v.png) |
| **انعطافات** | ![supported](v.png) | ![supported](v.png) |
| **أشكال** | ![supported](v.png) | ![supported](v.png) |
| **حلقات** | ![supported](v.png) | ![supported](v.png) |
| **مسار مخصص** | ![supported](v.png) | ![supported](v.png) |

## **الأسئلة المتكررة**

**هل يمكن تحويل العروض التقديمية المحمية بكلمة مرور؟**

نعم، تتيح Aspose.Slides العمل مع [العروض التقديمية المحمية بكلمة مرور](/slides/ar/cpp/password-protected-presentation/). عند معالجة هذه الملفات، تحتاج إلى تقديم كلمة المرور الصحيحة لكي تتمكن المكتبة من الوصول إلى محتوى العرض.

**هل تدعم Aspose.Slides الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides في تطبيقات وخدمات السحابة. تم تصميم المكتبة للعمل في بيئات الخوادم، مما يضمن أداءً عاليًا وقابلية توسيع لمعالجة دفعات الملفات.

**هل توجد أية حدود لحجم العروض التقديمية أثناء التحويل؟**

تستطيع Aspose.Slides التعامل مع عروض تقديمية بحجم تقريبا أي حجم. ومع ذلك، عند العمل مع ملفات كبيرة جدًا، قد تحتاج إلى موارد نظام إضافية، ومن الأفضل أحيانًا تحسين العرض لتقليل حجم الملف وتحسين الأداء.