---
title: تطبيق رسوم متحركة للأشكال في العروض التقديمية باستخدام C++
linktitle: رسوم متحركة للأشكال
type: docs
weight: 60
url: /ar/cpp/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة رسوم متحركة
- الحصول على رسوم متحركة
- استخراج رسوم متحركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق رسوم متحركة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص رسوم متحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة C++. تميز!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [المخططات](/slides/ar/cpp/animated-charts/). إنها تضيف حياة إلى العروض التقديمية أو مكوناتها. 

## **لماذا نستخدم الرسوم المتحركة في العروض التقديمية؟**

* التحكم في تدفق المعلومات
* التأكيد على النقاط الهامة
* زيادة الاهتمام أو المشاركة بين الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء الهامة في العرض التقديمي

PowerPoint يوفر العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الاسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) ،
* توفر Aspose.Slides أكثر من **150 تأثيرًا للرسوم المتحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). هذه التأثيرات هي في الأساس نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على مربع نص**

يتيح Aspose.Slides للـ C++ تطبيق الرسوم المتحركة على النص داخل الشكل. 

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) .
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) .
5. الحصول على تسلسل رئيسي للتأثيرات.
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) .
7. ضبط خاصية [TextAnimation.BuildType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) إلى القيمة من تعداد [BuildType Enumeration](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) .
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود C++ كيفية تطبيق تأثير `Fade` على AutoShape وتعيين الرسوم المتحركة للنص إلى القيمة *By 1st Level Paragraphs* :
```c++
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// يضيف AutoShape جديد مع نص
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// يحصل على التسلسل الرئيسي للشرائح.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// يضيف تأثير الرسوم المتحركة Fade إلى الشكل
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// يحرك نص الشكل وفقًا للفقرة ذات المستوى الأول
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// حفظ ملف PPTX إلى القرص
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert color="primary"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph] واحد. راجع [**النص المتحرك**](/slides/ar/cpp/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) على الشريحة.
4. الحصول على التسلسل الرئيسي للتأثيرات.
5. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_frame) .
6. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود C++ كيفية تطبيق تأثير `Fly` على إطار صورة:
```c++
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// تحميل الصورة لإضافتها إلى مجموعة صور العرض التقديمي
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// إضافة إطار صورة إلى الشريحة
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// الحصول على التسلسل الرئيسي للشرحة.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// إضافة تأثير التحليق من اليسار إلى إطار الصورة
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// حفظ ملف PPTX إلى القرص
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **تطبيق الرسوم المتحركة على شكل**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) .
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).
5. إنشاء تسلسل من التأثيرات على شكل الـ bevel.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود C++كيفية تطبيق تأثير `PathFootball` (path football) على شكل:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// يقوم بتحميل العرض التقديمي
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// الوصول إلى مجموعة الأشكال للشريحة المحددة
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// إنشاء تأثير PathFootball للشكل الحالي من الصفر.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// إضافة تأثير PathFootBall للرسوم المتحركة
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// إنشاء نوع من "زر".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// إنشاء تسلسل من التأثيرات لهذا الزر.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // إنشاء مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// إضافة أوامر للحركة لأن المسار المُنشأ فارغ.
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
	 
	 // كتابة ملف PPTX إلى القرص
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل**

توضح الأمثلة التالية كيفية استخدام طريقة `GetEffectsByShape` من واجهة [ISequence](https://reference.aspose.com/slides/cpp/aspose.slides.animation/isequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

في السابق، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint. يوضح الكود التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض التقديمي `AnimExample_out.pptx`.
```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// يحصل على تسلسل الرسوم المتحركة الرئيسي للشرحة.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// يحصل على الشكل الأول في الشريحة الأولى.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// يحصل على تأثيرات الرسوم المتحركة المطبقة على الشكل.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```


**مثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان الشكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو شريحة الرئيس، وتمت إضافة تأثيرات رسومية لهذه العناصر النائبة، فسيتم تشغيل جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة فيها فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![Slide shape animation effect](slide-shape-animation.png)

لنفترض أيضًا أن تأثير **Split** تم تطبيقه على العنصر النائب للتذييل في شريحة **layout**.

![Layout shape animation effect](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب للتذييل في شريحة **master**.

![Master shape animation effect](master-shape-animation.png)

يظهر لك الكود التالي كيفية استخدام طريقة `GetBasePlaceholder` من واجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) للوصول إلى عناصر الشكل النائبة والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شريحة التخطيط والرئيس.
```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```

```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// احصل على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة التخطيط.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب في الشريحة الرئيسية.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```


Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // تحليق، أسفل
Type: 134, subtype: 45            // انقسام، عمودي داخلي
Type: 126, subtype: 22            // أشرطة عشوائية، أفقي
```


## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

يتيح Aspose.Slides للـ C++ تغيير خصائص التوقيت لتأثير الرسوم المتحركة.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) properties:

- قائمة **Start** في توقيت PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- **Duration** في توقيت PowerPoint يتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). مدة الرسوم المتحركة (بالثواني) هي الوقت الكلي لإكمال دورة واحدة. 
- **Delay** في توقيت PowerPoint يتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

This is how you change the Effect Timing properties:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. ضبط قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) التي تحتاجها. 
3. حفظ ملف PPTX المعدل.

This C++ code demonstrates the operation:
```c++
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// يحصل على التسلسل الرئيسي للشريحة.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// يحصل على التأثير الأول في التسلسل الرئيسي.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// يغيّر نوع TriggerType للتأثير ليبدأ عند النقر
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// يغيّر مدة التأثير
effect->get_Timing()->set_Duration(3.f);

// يغيّر وقت تأخير TriggerDelayTime للتأثير
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// يحفظ ملف PPTX إلى القرص
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides هذه الخصائص لتسمح لك بالعمل مع الأصوات في تأثيرات الرسوم المتحركة: 

- [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **إضافة صوت لتأثير الرسوم المتحركة**

يعرض لك هذا الكود C++كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// يضيف صوتًا إلى مجموعة الأصوات في العرض التقديمي
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// يحصل على التسلسل الرئيسي للشرائح.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// يحصل على التأثير الأول في التسلسل الرئيسي
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// يتحقق من عدم وجود صوت في التأثير
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // يضيف صوتًا للتأثير الأول
    firstEffect->set_Sound(effectSound);
}

// يحصل على التسلسل التفاعلي الأول للشرائح.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// يضع علامة إيقاف الصوت السابق للتأثير
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// يكتب ملف PPTX إلى القرص
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```


### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج الصوت المضمن في كل تأثير رسوم متحركة عبر [set_Sound()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/effect/set_sound/). 

هذا الكود C++ يوضح كيفية استخراج الصوت المضمّن في تأثير الرسوم المتحركة:
```c++
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// يحصل على التسلسل الرئيسي للشرائح.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```


## **بعد الرسوم المتحركة**

يتيح Aspose.Slides للـ C++ تغيير خاصية "After animation" لتأثير الرسوم المتحركة.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** drop-down list matches these properties: 

- خاصية [set_AfterAnimationType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) التي تصف نوع "After animation":
  * **More Colors** في PowerPoint تتطابق مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
  * **Don't Dim** تتطابق مع النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) (نوع الرسوم المتحركة الافتراضي بعد التشغيل);
  * **Hide After Animation** تتطابق مع النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
  * **Hide on Next Mouse Click** تتطابق مع النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/) ;
- خاصية [set_AfterAnimationColor()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) التي تحدد تنسيق لون "After animation". تعمل هذه الخاصية بالتزامن مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/cpp/aspose.slides.animation/afteranimationtype/). إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون "After animation".

هذا الكود C++ يوضح كيفية تغيير تأثير بعد الرسوم المتحركة:
```c++
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// يحصل على التأثير الأول في التسلسل الرئيسي
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// يغيّر نوع الرسوم المتحركة بعد التشغيل إلى اللون
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// يضبط لون التعتيم بعد الرسوم المتحركة
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// يكتب ملف PPTX إلى القرص
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```


## **تحريك النص**

توفر Aspose.Slides هذه الخصائص لتسمح لك بالعمل مع كتلة *Animate text* لتأثير الرسوم المتحركة:

- خاصية [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) التي تصف نوع نص التحريك للتأثير. يمكن تحريك نص الشكل:
  * بالكامل مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) النوع);
  * كلمة بكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) النوع);
  * حرف بحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cpp/aspose.slides.animation/animatetexttype/) النوع);
- خاصية [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) التي تحدد تأخيرًا بين أجزاء النص المتحركة (الكلمات أو الحروف). القيمة الموجبة تحدد نسبة مئوية من مدة التأثير. القيمة السالبة تحدد التأخير بالثواني.

هذه هي الطريقة التي يمكنك من خلالها تغيير خصائص تحريك النص للتأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. ضبط خاصية [set_BuildType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/itextanimation/set_buildtype/) إلى قيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/cpp/aspose.slides.animation/buildtype/) لإلغاء وضع التحريك *By Paragraphs*.
3. ضبط قيم جديدة لخصائص [set_AnimateTextType()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) و[set_DelayBetweenTextParts()](https://reference.aspose.com/slides/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. حفظ ملف PPTX المعدل.

هذا الكود C++ يوضح العملية:
```c++
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// يحصل على التأثير الأول في التسلسل الرئيسي
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// يغيّر نوع تحريك النص للتأثير إلى "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// يغيّر نوع تحريك النص للتأثير إلى "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// يضبط التأخير بين الكلمات إلى 20% من مدة التأثير
firstEffect->set_DelayBetweenTextParts(20.0f);

// يكتب ملف PPTX إلى القرص
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```


## **الأسئلة الشائعة**

**كيف يمكنني التأكد من الحفاظ على الرسوم المتحركة عند نشر العرض على الويب؟**

[التصدير إلى HTML5](/slides/ar/cpp/export-to-html5/) وتمكين [الخيارات](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) المسؤولة عن الرسوم المتحركة للـ [shape](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) و[transition](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/). HTML العادي لا يشغل الرسوم المتحركة للشرائح، بينما HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب Z (ترتيب الطبقات) للأشكال على الرسوم المتحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: التحكم في التأثير يحدد توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) ما يغطي ما. النتيجة المرئية تُحدد بتلك التركيبة. (هذا هو سلوك PowerPoint العام؛ نموذج التأثيرات والأشكال في Aspose.Slides يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

عمومًا، [الرسوم المتحركة مدعومة](/slides/ar/cpp/convert-powerpoint-to-video/)، لكن قد تُعرض بعض الحالات النادرة أو التأثيرات المحددة بشكل مختلف. يُنصح باختبار التأثيرات التي تستخدمها ومع نسخة المكتبة.