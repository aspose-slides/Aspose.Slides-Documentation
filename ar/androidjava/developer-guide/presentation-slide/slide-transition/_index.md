---
title: إدارة انتقالات الشرائح في العروض التقديمية على Android
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/androidjava/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال شريحة متقدم
- تحول Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides for Android via Java، مع إرشادات خطوة بخطوة لعروض PowerPoint و OpenDocument."
---

## **نظرة عامة**
{{% alert color="primary" %}} 

تسمح Aspose.Slides for Android via Java أيضًا للمطورين بإدارة أو تخصيص تأثيرات انتقال الشرائح. في هذا الموضوع، سنناقش التحكم في انتقالات الشرائح بسهولة كبيرة باستخدام Aspose.Slides for Android via Java.

{{% /alert %}} 

لتسهيل الفهم، قمنا بتوضيح استخدام Aspose.Slides for Android via Java لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين ليس فقط تطبيق تأثيرات انتقال شرائح مختلفة على الشرائح، بل أيضًا تخصيص سلوك هذه التأثيرات.

## **إضافة انتقال شريحة**
لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. تطبيق نوع انتقال شريحة على الشريحة من أحد تأثيرات الانتقال التي تقدمها Aspose.Slides for Android via Java عبر تعداد TransitionType.
3. كتابة ملف العرض المعدل.
```java
// إنشاء كائن من فئة Presentation لتحميل ملف العرض المصدر
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تطبيق انتقال من النوع دائرة على الشريحة 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تطبيق انتقال من النوع مشط على الشريحة 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // حفظ العرض التقديمي إلى القرص
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إضافة انتقال شريحة متقدم**
في القسم السابق، قمنا بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل هذا التأثير البسيط أفضل ومتحكمًا بشكل أكبر، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
2. تطبيق نوع انتقال شريحة على الشريحة من أحد تأثيرات الانتقال التي تقدمها Aspose.Slides for Android via Java.
3. يمكنك أيضًا إعداد الانتقال للتقدم عند النقر، بعد فترة زمنية محددة أو كلاهما.
4. إذا تم تمكين انتقال الشريحة للتقدم عند النقر، فإن الانتقال سيتقدم فقط عند نقر المستخدم بالماوس. علاوة على ذلك، إذا تم تعيين خاصية Advance After Time، سيتقدم الانتقال تلقائيًا بعد انقضاء الوقت المحدد.
5. كتابة العرض المعدل كملف عرض.
```java
// إنشاء فئة Presentation التي تمثل ملف عرض
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // تطبيق انتقال من النوع دائرة على الشريحة 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تعيين مدة الانتقال إلى 3 ثوانٍ
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // تطبيق انتقال من النوع مشط على الشريحة 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // تعيين مدة الانتقال إلى 5 ثوانٍ
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // تطبيق انتقال من النوع تكبير على الشريحة 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // تعيين مدة الانتقال إلى 7 ثوانٍ
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // حفظ العرض التقديمي إلى القرص
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **انتقال Morph**
{{% alert color="primary" %}} 

تدعم Aspose.Slides for Android via Java الآن [Morph Transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). إنها تمثل التحول Morph الجديد الذي تم تقديمه في PowerPoint 2019.

{{% /alert %}} 

يتيح لك انتقال Morph تحريكًا سلسًا من شريحة إلى أخرى. تصف هذه المقالة مفهوم الانتقال وكيفية استخدام انتقال Morph. لاستخدام انتقال Morph بفعالية، ستحتاج إلى شريحتين تحتويان على كائن واحد على الأقل مشترك. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن في الشريحة الثانية إلى مكان مختلف.

يظهر مقطع الشيفرة التالي كيفية إضافة نسخة من الشريحة تحتوي على بعض النص إلى العرض وتعيين انتقال من نوع [morph type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) إلى الشريحة الثانية.
```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


## **أنواع انتقال Morph**
تم إضافة تعداد جديد [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType). يمثل أنواعًا مختلفة من انتقال شريحة Morph.

تعداد TransitionMorphType يحتوي على ثلاثة أعضاء:
- ByObject: سيتم تنفيذ انتقال Morph مع اعتبار الأشكال ككائنات غير قابلة للتقسيم.
- ByWord: سيتم تنفيذ انتقال Morph بنقل النص كلمة بكلمة حيثما أمكن.
- ByChar: سيتم تنفيذ انتقال Morph بنقل النص حرفًا بحرف حيثما أمكن.

يظهر مقطع الشيفرة التالي كيفية تعيين انتقال Morph إلى شريحة وتغيير نوع morph:
```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين تأثيرات الانتقال**
تدعم Aspose.Slides for Android via Java تعيين تأثيرات الانتقال مثل من الأسود، من اليسار، من اليمين، إلخ. لتعيين تأثير الانتقال، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة.
- تعيين تأثير الانتقال.
- كتابة العرض كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

في المثال أدناه، قمنا بتعيين تأثيرات الانتقال.
```java
// إنشاء مثيل من فئة Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تعيين التأثير
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // حفظ العرض التقديمي إلى القرص
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. قم بتعيين [speed] للانتقال باستخدام إعداد [TransitionSpeed] (مثلاً بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت وإعادة التكرار (مثل [setSound]...، [setSoundMode]...، [setSoundLoop]...، بالإضافة إلى البيانات الوصفية مثل [setSoundIsBuiltIn]... و[setSoundName]...).

**ما هي أسرع طريقة لتطبيق نفس الانتقال على جميع الشرائح؟**

قم بتكوين نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ فإن الانتقالات تُحفظ لكل شريحة، لذا تطبيق نفس النوع على جميع الشرائح يعطي نتيجة متسقة.

**كيف يمكنني التحقق من الانتقال الحالي المُعيّن على شريحة؟**

افحص [إعدادات الانتقال] الخاصة بالشريحة واقرأ [نوع الانتقال]؛ تلك القيمة تُظهر لك بالضبط أي تأثير تم تطبيقه.