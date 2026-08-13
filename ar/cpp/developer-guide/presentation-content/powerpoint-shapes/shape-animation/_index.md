---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية باستخدام C++
linktitle: حركة الشكل
type: docs
weight: 60
url: /ar/cpp/shape-animation/
keywords:
- شكل
- حركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة حركة
- الحصول على حركة
- استخراج حركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق حركة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص رسومات حركة الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة C++. تميز!"
---
## **المقدمة**

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [الرسوم البيانية](/slides/ar/cpp/animated-charts/). تعطي الحياة للعروض التقديمية أو مكوناتها. 

## **لماذا نستخدم الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك 

* التحكم في تدفق المعلومات
* تأكيد النقاط المهمة
* زيادة الاهتمام أو المشاركة بين الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض

يوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الاسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/ar/cpp/namespace/aspose.slides.animation)،
* توفر Aspose.Slides أكثر من **150 تأثير حركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/ar/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). هذه التأثيرات هي في الأساس نفسها (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على مربع نص**

تتيح Aspose.Slides للغة C++ تطبيق الرسوم المتحركة على النص داخل الشكل. 

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_auto_shape) من نوع `rectangle`. 
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. الحصول على تسلسل رئيسي من التأثيرات.
6. إضافة تأثير حركة إلى [IAutoShape](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_auto_shape). 
7. ضبط خاصية [TextAnimation.BuildType](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) إلى القيمة من تعداد [BuildType Enumeration](https://reference.aspose.com/slides/ar/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود C++ كيفية تطبيق تأثير `Fade` على AutoShape وضبط حركة النص إلى القيمة *By 1st Level Paragraphs*:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// يضيف AutoShape جديد مع نص
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// يحصل على التسلسل الرئيسي للشرائح.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// يضيف تأثير حركة Fade إلى الشكل
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// يحرك نص الشكل حسب فقرات المستوى الأول
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// يحفظ ملف PPTX إلى القرص
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_paragraph). راجع [**النص المتحرك**](/slides/ar/cpp/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_picture_frame) على الشريحة. 
4. الحصول على التسلسل الرئيسي للتأثيرات.
5. إضافة تأثير حركة إلى [PictureFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_picture_frame).
6. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود C++ كيفية تطبيق تأثير `Fly` على إطار صورة:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// تحميل صورة لإضافتها إلى مجموعة صور العرض التقديمي
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// يضيف إطار صورة إلى الشريحة
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// يحصل على التسلسل الرئيسي للشرائح.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// يضيف تأثير حركة Fly من اليسار إلى إطار الصورة
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// يحفظ ملف PPTX إلى القرص
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تطبيق الرسوم المتحركة على شكل**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_auto_shape) من نوع `rectangle`. 
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_auto_shape) (عند النقر على هذا الكائن يتم تشغيل الحركة).
5. إنشاء تسلسل من التأثيرات على الشكل المائل.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود C++ كيفية تطبيق تأثير `PathFootball` (path football) على شكل:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// مسار دليل المستند.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// يقوم بتحميل العرض التقديمي
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// الوصول إلى مجموعة الأشكال للشريحة المحددة
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// ينشئ تأثير PathFootball للشكل الحالي من الصفر.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// يضيف تأثير الحركة PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// إنشاء نوع من "الزر".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// ينشئ تسلسلًا من التأثيرات لهذا الزر.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // ينشئ مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// يضيف أوامر للتحرك لأن المسار المُنشأ فارغ.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	//SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // يكتب ملف PPTX إلى القرص
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل**

تُظهر الأمثلة التالية كيفية استخدام طريقة `GetEffectsByShape` من واجهة [ISequence](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

سابقًا، تعلمت كيفية إضافة تأثيرات حركة إلى الأشكال في عروض PowerPoint. يوضح الكود التالي كيفية الحصول على التأثيرات المطبقة على أول شكل في أول شريحة عادية في العرض `AnimExample_out.pptx`.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// يحصل على التسلسل الرئيسي للرسوم المتحركة للشريحة.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// يحصل على الشكل الأول في الشريحة الأولى.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// يحصل على تأثيرات الحركة المطبقة على الشكل.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**مثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان هناك شكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو الشريحة الأساسية، وتم إضافة تأثيرات حركة إلى هذه العناصر النائبة، فسيتم تشغيل جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

فلنفرض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة بها شكل تذييل فقط بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير حركة شكل الشريحة](slide-shape-animation.png)

ولنفرض أيضًا أن تأثير **Split** تم تطبيقه على العنصر النائب للتذييل في شريحة **layout**.

![تأثير حركة شكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب للتذييل في شريحة **master**.

![تأثير حركة شكل الشريحة الأساسية](master-shape-animation.png)

يُظهر الكود التالي كيفية استخدام طريقة `GetBasePlaceholder` من واجهة [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides.ishape/) للوصول إلى العناصر النائبة للشكل والحصول على تأثيرات الحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شرائح التخطيط والاساسية.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// احصل على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة التخطيط.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب في الشريحة الأساسية.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

الناتج:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // تحليق، أسفل
Type: 134, subtype: 45            // تقسيم، عمودي داخل
Type: 126, subtype: 22            // أشرطة عشوائية، أفقي
```

## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

تتيح Aspose.Slides للغة C++ تغيير خصائص التوقيت لتأثير الحركة.

![لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint](shape-animation.png)

هذه هي العلاقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- قائمة **Start** المنسدلة في توقيت PowerPoint تطابق خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- توقيت **Duration** في PowerPoint يطابق خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). مدة الحركة (بالثواني) هي الوقت الكلي الذي تستغرقه الحركة لإكمال دورة واحدة. 
- توقيت **Delay** في PowerPoint يطابق خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

هذه هي طريقة تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الحركة.
2. ضبط القيم الجديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) التي تحتاجها. 
3. حفظ ملف PPTX المعدل.

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// يحصل على التسلسل الرئيسي للشريحة.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// يحصل على أول تأثير في التسلسل الرئيسي.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// يغيّر TriggerType للتأثير ليبدأ عند النقر
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// يغيّر مدة التأثير
effect->get_Timing()->set_Duration(3.f);

// يغيّر TriggerDelayTime للتأثير
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// يحفظ ملف PPTX إلى القرص
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع الأصوات في تأثيرات الحركة: 

- [set_Sound()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **إضافة صوت لتأثير الرسوم المتحركة**

يعرض لك هذا الكود C++ كيفية إضافة صوت لتأثير الحركة وإيقافه عندما يبدأ التأثير التالي:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// يحصل على التسلسل الرئيسي للشريحة.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// يحصل على أول تأثير في التسلسل الرئيسي
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// يفحص التأثير للتأكد من عدم وجود صوت
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // يضيف صوتًا للتأثير الأول
    firstEffect->set_Sound(effectSound);
}

// يحصل على أول تسلسل تفاعلي في الشريحة.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// يضبط علامة "إيقاف الصوت السابق" للتأثير
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// يكتب ملف PPTX إلى القرص
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج الدالة [set_Sound()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/effect/set_sound/) المضمِّنة في كل تأثير حركة. 

يعرض لك هذا الكود C++ كيفية استخراج الصوت المضمّن في تأثير الحركة:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
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

تتيح Aspose.Slides للغة C++ تغيير خاصية After animation لتأثير الحركة.

![لوحة تأثير الرسوم المتحركة وخياراته الموسعة في Microsoft PowerPoint](shape-after-animation.png)

قائمة **After animation** المنسدلة في PowerPoint تطابق هذه الخصائص: 

- خاصية [set_AfterAnimationType()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) التي تصف نوع After animation :
  * عنصر **More Colors** في PowerPoint يطابق النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/afteranimationtype/);
  * عنصر **Don't Dim** في PowerPoint يطابق النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/afteranimationtype/) (نوع After animation الافتراضي);
  * عنصر **Hide After Animation** في PowerPoint يطابق النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/afteranimationtype/);
  * عنصر **Hide on Next Mouse Click** في PowerPoint يطابق النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/afteranimationtype/);
- خاصية [set_AfterAnimationColor()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) التي تحدد تنسيق لون After animation. تعمل هذه الخاصية بالتزامن مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/afteranimationtype/). إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون After animation.

يعرض لك هذا الكود C++ كيفية تغيير تأثير After animation:

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// يحصل على أول تأثير في التسلسل الرئيسي
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// يغيّر نوع الحركة اللاحقة إلى اللون
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// يضبط لون التعتيم بعد الحركة
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// يكتب ملف PPTX إلى القرص
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **تحريك النص**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *Animate text* في تأثير الحركة:

- [set_AnimateTextType()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) التي تصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - كله مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/animatetexttype/) النوع)
  - حسب الكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/animatetexttype/) النوع)
  - حسب الحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/animatetexttype/) النوع)
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) لتعيين تأخير بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الإيجابية تحدد نسبة مدة التأثير. القيمة السلبية تحدد التأخير بالثواني.

هذه هي طريقة تغيير خصائص تحريك النص للتأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الحركة.
2. ضبط خاصية [set_BuildType()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation.itextanimation/set_buildtype/) إلى القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/buildtype/) لإيقاف وضعية التحريك *By Paragraphs*.
3. ضبط القيم الجديدة لخصائص [set_AnimateTextType()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation.ieffect/set_animatetexttype/) و[set_DelayBetweenTextParts()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation.ieffect/set_delaybetweentextparts/).
4. حفظ ملف PPTX المعدل.

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// يحصل على أول تأثير في التسلسل الرئيسي
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

### كيف يمكنني ضمان حفظ الرسوم المتحركة عند نشر العرض التقديمي على الويب؟

[تصدير إلى HTML5](/slides/ar/cpp/export-to-html5/) وتمكين [الخيارات](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/html5options/) المسؤولة عن [الشكل](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/html5options/set_animateshapes/) و[الانتقال](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/html5options/set_animatetransitions/) . HTML العادي لا يشغل رسوم الشرائح، بينما HTML5 يفعل ذلك.

### كيف يؤثر تغيير ترتيب الـ z (ترتيب الطبقات) للأشكال على الرسوم المتحركة؟

التوقيت وترتيب الرسم مستقلان: التحكم في ظهور/اختفاء العناصر يتم عبر التأثير، بينما يحدد [z-order](https://reference.aspose.com/slides/ar/cpp/aspose.slides.shape/get_zorderposition/) ما يغطي ما. النتيجة المرئية محددة بتكاملهما. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للتأثيرات والأشكال يتبع نفس المنطق.)

### هل توجد قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟

بشكل عام، [الرسوم المتحركة مدعومة](/slides/ar/cpp/convert-powerpoint-to-video/)، لكن الحالات النادرة أو التأثيرات المحددة قد تُعرض بشكل مختلف. يوصى باختبار التأثيرات التي تستخدمها ومع نسخة المكتبة.