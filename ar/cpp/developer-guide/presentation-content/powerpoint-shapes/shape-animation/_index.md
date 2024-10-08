---
title: تنشيط الشكل
type: docs
weight: 60
url: /ar/cpp/shape-animation/
keywords: "تنشيط PowerPoint, تأثير التنشيط, تطبيق التنشيط, عرض PowerPoint, C++, CPP, Aspose.Slides for C++"
description: "تطبيق تنشيط PowerPoint في C++"
---

التنشيطات هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [الرسوم البيانية](/slides/ar/cpp/animated-charts/). إنها تعطي الحياة للعروض التقديمية أو مكوناتها.

### **لماذا تستخدم التنشيطات في العروض التقديمية؟**

باستخدام التنشيطات، يمكنك 

* التحكم في تدفق المعلومات
* التأكيد على النقاط المهمة
* زيادة الاهتمام أو المشاركة بين جمهورك
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه قرائك أو مشاهديك إلى الأجزاء المهمة في العرض التقديمي

يوفر PowerPoint العديد من الخيارات والأدوات للتنشيطات وتأثيرات التنشيط عبر فئات **الدخول** و**الخروج** و**التأكيد** و**مسارات الحركة**.

### **التنشيطات في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع التنشيطات تحت مساحة الاسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation)،
* توفر Aspose.Slides أكثر من **150 تأثير تنشيط** تحت تعداد [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). هذه التأثيرات متطابقة أساسًا (أو معادلة) للتأثيرات المستخدمة في PowerPoint.

## **تطبيق تنشيط على TextBox**

تسمح لك Aspose.Slides for C++ بتطبيق التنشيط على النص في شكل. 

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. احصل على مرجع شريحة من خلال الفهرس الخاص بها.
3. أضف شكلًا `مستطيل` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. أضف النص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. احصل على تسلسل رئيسي من التأثيرات.
6. أضف تأثير تنشيط إلى [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
7. قم بتعيين خاصية [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) إلى القيمة من [BuildType Enumeration](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. اكتب العرض التقديمي إلى القرص كملف PPTX.

يظهر لك هذا الكود C++ كيفية تطبيق تأثير `Fade` على AutoShape وتعيين تنشيط النص إلى القيمة *حسب الفقرات من المستوى الأول*:

```c++
// ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// يضيف AutoShape جديد مع نص
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"الفقرة الأولى \nالفقرة الثانية \n الفقرة الثالثة");

// يحصل على التسلسل الرئيسي للشريحة.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// يضيف تأثير تنشيط Fade إلى الشكل
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// ينشط نص الشكل حسب الفقرات من المستوى الأول
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// احفظ ملف PPTX إلى القرص
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

بالإضافة إلى تطبيق التنشيطات على النص، يمكنك أيضًا تطبيق التنشيطات على فقرة واحدة [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph). انظر [**النص المتحرك**](/slides/ar/cpp/animated-text/).

{{% /alert %}} 

## **تطبيق تنشيط على PictureFrame**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. احصل على مرجع شريحة من خلال الفهرس الخاص بها.
3. أضف أو احصل على [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) على الشريحة. 
4. احصل على التسلسل الرئيسي من التأثيرات.
5. أضف تأثير تنشيط إلى [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame).
6. اكتب العرض التقديمي إلى القرص كملف PPTX.

يظهر لك هذا الكود C++ كيفية تطبيق تأثير `Fly` على إطار الصورة:

```c++
// ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// تحميل الصورة لإضافتها في مجموعة صور العرض التقديمي
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// يضيف إطار صورة إلى الشريحة
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// يحصل على التسلسل الرئيسي للشريحة.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// يضيف تأثير تنشيط Fly من اليسار إلى إطار الصورة
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// احفظ ملف PPTX إلى القرص
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تطبيق تنشيط على الشكل**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
2. احصل على مرجع شريحة من خلال الفهرس الخاص بها.
3. أضف شكلًا `مستطيل` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). 
4. أضف شكل `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) (عند النقر على هذا الكائن، يتم تشغيل التنشيط).
5. أنشئ تسلسل تأثيرات على الشكل المنقوش.
6. أنشئ مسار `UserPath` مخصص.
7. أضف أوامر للانتقال إلى `UserPath`.
8. اكتب العرض التقديمي إلى القرص كملف PPTX.

يظهر لك هذا الكود C++ كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:

```c++
	// مسار الدليل إلى مجلد الوثائق.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// تحميل العرض التقديمي
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// الوصول إلى مجموعة الأشكال الخاصة بالشريحة المحددة
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// إنشاء تأثير PathFootball لشكل موجود من الصفر.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"TextBox المتحرك");

	// يضيف تأثير تنشيط PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// إنشاء نوع من "الزر".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// إنشاء تسلسل تأثيرات لهذا الزر.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // إنشاء مسار مستخدم مخصص. سيتم نقل كائننا فقط بعد النقر على الزر.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// إضافة أوامر للتحرك نظرًا لأن المسار المنشأ فارغ.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //يكتب ملف PPTX إلى القرص
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **الحصول على تأثيرات التنشيط المطبقة على الشكل**

قد تقرر معرفة جميع تأثيرات التنشيط المطبقة على شكل واحد. 

يظهر لك هذا الكود C++ كيفية الحصول على جميع التأثيرات المطبقة على شكل معين:

```c++
// ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

System::SharedPtr<ISlide> firstSlide = pres->get_Slides()->idx_get(0);

// يحصل على التسلسل الرئيسي للشريحة.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// يحصل على الشكل الأول على الشريحة.
System::SharedPtr<IShape> shape = firstSlide->get_Shapes()->idx_get(0);

// يحصل على جميع تأثيرات التنشيط المطبقة على الشكل.
System::ArrayPtr<System::SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    System::Console::WriteLine(System::String(u"الشكل ") + shape->get_Name() + u" يحتوي على " + shapeEffects->get_Length() + u" تأثيرات تنشيط.");
}
```

## **تغيير خصائص توقيت تأثير التنشيط**

تسمح لك Aspose.Slides for C++ بتغيير خصائص التوقيت لتأثير التنشيط.

هذا هو لوحة توقيت التنشيط في Microsoft PowerPoint:

![example1_image](shape-animation.png)

تتطابق هذه هي الطرفيات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- قائمة المنسدل PowerPoint توقيت **البداية** تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- يتطابق توقيت PowerPoint **المدة** مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). تبلغ مدة التنشيط (بالثواني) هو الوقت الإجمالي الذي يستغرقه التنشيط لإكمال دورة واحدة. 
- يتطابق توقيت PowerPoint **التأخير** مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

هذه هي كيفية تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير التنشيط.
2. قم بتعيين قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) التي تحتاجها. 
3. احفظ ملف PPTX المعدل.

يقوم هذا الكود C++ بإظهار العملية:

```c++
// ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// يحصل على التسلسل الرئيسي للشريحة.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// يحصل على أول تأثير في التسلسل الرئيسي.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// يغير TriggerType للتأثير ليبدأ عند النقر
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// يغير مدة التأثير
effect->get_Timing()->set_Duration(3.f);

// يغير TriggerDelayTime للتأثير
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// يحفظ ملف PPTX على القرص
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **صوت تأثير التنشيط**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع الأصوات في تأثيرات التنشيط: 

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **إضافة صوت تأثير التنشيط**

يظهر لك هذا الكود C++ كيفية إضافة صوت تأثير التنشيط وإيقافه عند بدء التأثير التالي:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// يضيف الصوت إلى مجموعة الصوتيات في العرض التقديمي
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// يحصل على التسلسل الرئيسي للشريحة.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// يحصل على أول تأثير في التسلسل الرئيسي
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// يتحقق من التأثير "بدون صوت"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // يضيف الصوت للتأثير الأول
    firstEffect->set_Sound(effectSound);
}

// يحصل على أول تسلسل تفاعلي في الشريحة.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// يضع علامة "توقف الصوت السابق" على التأثير
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// يكتب ملف PPTX إلى القرص
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **استخراج صوت تأثير التنشيط**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
2. احصل على مرجع لشريحة من خلال الفهرس الخاص بها. 
3. احصل على التسلسل الرئيسي للتأثيرات. 
4. استخراج [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) المدمج بكل تأثير تنشيط. 

يظهر لك هذا الكود C++ كيفية استخراج الصوت المدمج في تأثير تنشيط:

```c++
// ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// يحصل على التسلسل الرئيسي للشريحة.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **بعد التنشيط**

تسمح لك Aspose.Slides for C++ بتغيير خاصية بعد التنشيط لتأثير التنشيط.

هذه هي لوحة تأثير التنشيط والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

تتطابق قائمة منسدلة PowerPoint تأثير **بعد التنشيط** مع هذه الخصائص: 

- خاصية [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) التي تصف نوع بعد التنشيط :
  * تطابق PowerPoint **أكثر من ألوان** [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) النوع;
  * تطابق عنصر القائمة **لا تخفت** [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) النوع (افتراضي بعد نوع التنشيط);
  * تطابق عنصر القائمة **إخفاء بعد التنشيط** [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) النوع;
  * تطابق عنصر القائمة **إخفاء عند النقر التالي بالفأرة** [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) النوع;
- خاصية [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) التي تحدد تنسيق لون بعد التنشيط. تعمل هذه الخاصية بالتعاون مع  [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) النوع. إذا قمت بتغيير النوع إلى نوع آخر، سيتم مسح لون بعد التنشيط.

يظهر لك هذا الكود C++ كيفية تغيير تأثير بعد التنشيط:

```c++
// ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف عرض تقديمي
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// يحصل على أول تأثير في التسلسل الرئيسي
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// يغير نوع بعد التنشيط إلى لون
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// يقوم بتعيين لون التعتيم بعد التنشيط
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// يكتب ملف PPTX إلى القرص
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **تنشيط النص**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع *كتلة تنشيط النص* لتأثير التنشيط:

- [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) التي تصف نوع النص المنشيط للتأثير. يمكن تنشيط نص الشكل:
  - جميعها مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) النوع)
  - حسب الكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) النوع)
  - حسب الحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) النوع)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) يقوم بتعيين تأخير بين أجزاء النص المتحركة (كلمات أو أحرف). تحدد القيمة الإيجابية النسبة المئوية لمدة التأثير. تحدد القيمة السلبية التأخير بالثواني.

هذه هي كيفية تغيير خصائص تأثير تنشيط النص:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير التنشيط.
2. قم بتعيين خاصية [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) إلى قيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) لإيقاف تشغيل وضع التنشيط *حسب الفقرات*.
3. قم بتعيين قيم جديدة لخاصيتي [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) و[set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) .
4. احفظ ملف PPTX المعدل.

يقوم هذا الكود C++ بتوضيح العملية:

```c++
// ينشئ مثيلًا لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// يحصل على أول تأثير في التسلسل الرئيسي
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// يغير نوع تأثير النص إلى "ككائن واحد"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// يغير نوع تنشيط النص التأثير إلى "حسب الكلمة"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// يقوم بتعيين التأخير بين الكلمات إلى 20% من مدة التأثير
firstEffect->set_DelayBetweenTextParts(20.0f);

// يكتب ملف PPTX إلى القرص
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```