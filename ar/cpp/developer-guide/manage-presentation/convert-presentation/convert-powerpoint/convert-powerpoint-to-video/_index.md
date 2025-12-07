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
- حفظ PPT كـ MP4
- حفظ PPTX كـ MP4
- تصدير PPT إلى MP4
- تصدير PPTX إلى MP4
- تحويل الفيديو
- PowerPoint
- C++
- Aspose.Slides
description: "تعرف على كيفية تحويل عروض PowerPoint إلى فيديو باستخدام C++. اكتشف عينة الشيفرة وتقنيات الأتمتة لتبسيط سير العمل الخاص بك."
---

## **نظرة عامة**

من خلال تحويل عرض PowerPoint التقديمي إلى فيديو، ستحصل على 

* **زيادة في إمكانية الوصول:** جميع الأجهزة (بغض النظر عن النظام الأساسي) مجهزة بمشغلات الفيديو بشكل افتراضي مقارنةً بتطبيقات فتح العروض، لذا يجد المستخدمون أنه من الأسهل فتح أو تشغيل الفيديوهات.
* **نطاق أوسع:** من خلال الفيديوهات، يمكنك الوصول إلى جمهور كبير وتوجيههم بالمعلومات التي قد تبدو مملة في عرض تقديمي. تشير معظم الاستطلاعات والإحصاءات إلى أن الناس يشاهدون ويستهلكون الفيديوهات أكثر من أشكال المحتوى الأخرى، وعادةً ما يفضلون هذا النوع من المحتوى.

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-22-11-release-notes/) تم تنفيذ دعم تحويل العرض إلى فيديو. 

* استخدم Aspose.Slides لتوليد مجموعة من الإطارات (من شرائح العرض) التي تتوافق مع عدد محدد من الإطارات في الثانية (FPS).
* استخدم أداة طرف ثالث مثل `ffmpeg` لإنشاء فيديو بناءً على الإطارات.

## **تحويل عرض PowerPoint إلى فيديو**

1. قم بتنزيل ffmpeg [هنا](https://ffmpeg.org/download.html).
2. أضف مسار `ffmpeg.exe` إلى متغير البيئة `PATH`.
3. شغّل كود تحويل PowerPoint إلى فيديو.

هذا الكود بلغة C++ يوضح لك كيفية تحويل عرض ( يحتوي على شكل وتأثيري تحريك ) إلى فيديو:
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

يمكنك تطبيق التحريكات على الكائنات داخل الشرائح واستخدام الانتقالات بين الشرائح.

{{% alert color="primary" %}} 
قد ترغب في الاطلاع على هذه المقالات: [PowerPoint Animation](https://docs.aspose.com/slides/cpp/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cpp/shape-animation/), و [Shape Effect](https://docs.aspose.com/slides/cpp/shape-effect/).
{{% /alert %}} 

تجعل التحريكات والانتقالات عروض الشرائح أكثر جذباً وإثارة— وتفعل الشيء نفسه للفيديوهات. لنضيف شريحة وانتقال آخر إلى الكود للعرض السابق:
```c++
// يضيف شكل ابتسامة ويُحركه

// ...

// يضيف شريحة جديدة مع انتقال متحرك

System::SharedPtr<ISlide> newSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_Slide(0)->get_LayoutSlide());

System::SharedPtr<IBackground> slideBackground = newSlide->get_Background();

slideBackground->set_Type(BackgroundType::OwnBackground);

auto fillFormat = slideBackground->get_FillFormat();

fillFormat->set_FillType(FillType::Solid);

fillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Indigo());

newSlide->get_SlideShowTransition()->set_Type(TransitionType::Push);
```


تدعم Aspose.Slides أيضًا التحريك للنصوص. لذا نقوم بتحريك الفقرات على الكائنات، بحيث تظهر واحدة تلو الأخرى (مع تأخير ثانية واحدة):
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

    // يحوّل الإطارات إلى فيديو
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

لتمكينك من أداء مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides الفئات [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) و[PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/).

PresentationAnimationsGenerator تتيح لك ضبط حجم الإطار للفيديو (الذي سيُنشأ لاحقًا) عبر المُنشئ الخاص بها. إذا مررت كائن عرض، سيتم استخدام `Presentation.SlideSize` وتوليد التحريكات التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). 

عند توليد التحريكات، يُنشأ حدث `NewAnimation` لكل تحريك لاحق، يحتوي على معامل [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/). الأخير هو فئة تمثل مشغلًا لتحريك منفصل.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player/)، تُستخدم الخاصية [get_Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29881d28eb42f345ab130d52f05a2d91) (المدة الكاملة للتحريك) والطريقة [SetTimePosition](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_presentation_animation_player#a29cb11a73e3ad5f645626fcee3bc4ea0). يتم ضبط موقع كل تحريك ضمن النطاق *0 إلى المدة*، ثم تُعيد طريقة `GetFrame` صورة Bitmap تتطابق مع حالة التحريك في تلك اللحظة.
```c++
void OnNewAnimation(System::SharedPtr<IPresentationAnimationPlayer> animationPlayer)
{
    System::Console::WriteLine(u"Total animation duration: {0}", animationPlayer->get_Duration());

    animationPlayer->SetTimePosition(0);
    // حالة الرسوم المتحركة الأولية
    System::SharedPtr<System::Drawing::Bitmap> bitmap = animationPlayer->GetFrame();
    // صورة البت لحالة الرسوم المتحركة الأولية

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

    // يضيف شكل ابتسامة ويحرّكه
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


لجعل جميع التحريكات في عرض ما تُشغل مرة واحدة، تُستخدم فئة [PresentationPlayer](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_player/). تأخذ هذه الفئة كائنًا من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.presentation_animations_generator/) ومعدل FPS للتأثيرات في مُنشئها ثم تستدعي حدث `FrameTick` لجميع التحريكات لتشغيلها:
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
| **الظهور** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **التحليق الداخل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الطفو الداخل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تقسيم** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **عجلة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أعمدة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو وتدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تدوير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |


**التأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **نَبْض** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **نَبْض اللون** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تمايل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوران** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تكبير/تصغير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **إزالة التشبع** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تغميق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تفتح** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **شفافية** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الكائن** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **اللون المكمل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الخط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون التعبئة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**الخروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **اختفاء** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **التحليق الخارج** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **الطفو الخارج** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تقسيم** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أعمدة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تصغير وتدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تدوير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدبوم](v.png) |

**مسارات الحركة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أقواس** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دورات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشكال** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **حلقات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسار مخصص** | ![مدعوم](v.png) | ![مدعوم](v.png) |

## **الأسئلة المتكررة**

**هل من الممكن تحويل العروض التقديمية المحمية بكلمة مرور؟**

نعم، تتيح Aspose.Slides العمل مع [العروض التقديمية المحمية بكلمة مرور](/slides/ar/cpp/password-protected-presentation/). عند معالجة مثل هذه الملفات، تحتاج إلى تقديم كلمة المرور الصحيحة لتتمكن المكتبة من الوصول إلى محتوى العرض.

**هل تدعم Aspose.Slides الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides في التطبيقات والخدمات السحابية. صُممت المكتبة لتعمل في بيئات الخادم، مع ضمان الأداء العالي والقابلية للتوسع لمعالجة دفعات الملفات.

**هل هناك أي حدود لحجم العروض التقديمية أثناء التحويل؟**

تستطيع Aspose.Slides التعامل مع عروض تقديمية بحجم افتراضي كبير. ومع ذلك، عند التعامل مع ملفات ضخمة جدًا قد تحتاج إلى موارد نظام إضافية، وغالبًا ما يُنصح بتحسين العرض لتحسين الأداء.