---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام Java
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/java/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال شريحة متقدم
- انتقال Morph
- نوع الانتقال
- مؤثر الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides for Java، مع إرشادات خطوة بخطوة لعروض PowerPoint و OpenDocument."
---

## **نظرة عامة**
{{% alert color="primary" %}} 

تسمح Aspose.Slides for Java أيضًا للمطورين بإدارة أو تخصيص مؤثرات انتقال الشرائح. في هذا الموضوع، سنناقش كيفية التحكم في انتقالات الشرائح بسهولة كبيرة باستخدام Aspose.Slides for Java.

{{% /alert %}} 

لتسهيل الفهم، قمنا بتوضيح كيفية استخدام Aspose.Slides for Java لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين ليس فقط تطبيق مؤثرات انتقال مختلفة على الشرائح، بل أيضًا تخصيص سلوك هذه المؤثرات.

## **إضافة انتقال شريحة**
لإنشاء مؤثر انتقال شريحة بسيط، اتبع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
2. تطبيق نوع انتقال شريحة على الشريحة من أحد مؤثرات الانتقال التي تقدمها Aspose.Slides for Java عبر تعداد TransitionType.
3. كتابة ملف العرض التقديمي المعدل.
```java
// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تطبيق انتقال من نوع دائرة على الشريحة 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تطبيق انتقال من نوع مشط على الشريحة 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // حفظ العرض على القرص
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إضافة انتقال شريحة متقدم**
في القسم السابق، قمنا فقط بتطبيق مؤثر انتقال بسيط على الشريحة. الآن، لجعل هذا المؤثر أبسط وأكثر تحكمًا، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
2. تطبيق نوع انتقال شريحة على الشريحة من أحد مؤثرات الانتقال التي تقدمها Aspose.Slides for Java.
3. يمكنك أيضًا ضبط الانتقال على التقدم عند النقر، بعد فترة زمنية محددة أو كليهما.
4. إذا تم تمكين الانتقال للتقدم عند النقر، سيُقدم الانتقال فقط عندما ينقر المستخدم بالماوس. علاوةً على ذلك، إذا تم ضبط خاصية Advance After Time، سيتقدم الانتقال تلقائيًا بعد مرور الوقت المحدد.
5. كتابة العرض التقديمي المعدل كملف عرض تقديمي.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // تطبيق انتقال من نوع دائرة على الشريحة 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تعيين وقت الانتقال إلى 3 ثوانٍ
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // تطبيق انتقال من نوع مشط على الشريحة 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // تعيين وقت الانتقال إلى 5 ثوانٍ
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // تطبيق انتقال من نوع تكبير على الشريحة 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // تعيين وقت الانتقال إلى 7 ثوانٍ
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // حفظ العرض التقديمي على القرص
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **انتقال Morph**
{{% alert color="primary" %}} 

تدعم Aspose.Slides for Java الآن [Morph Transition](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition). وهي تمثل انتقال morph الجديد الذي تم تقديمه في PowerPoint 2019.

{{% /alert %}} 

يسمح لك انتقال Morph بإنشاء حركة سلسة من شريحة إلى أخرى. يصف هذا المقال المفهوم وكيفية استخدام انتقال Morph. لاستخدام انتقال Morph بفعالية، ستحتاج إلى شريحتين على الأقل تشتركان في كائن واحد. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن في الشريحة الثانية إلى مكان مختلف.

المقتطف البرمجي التالي يوضح كيفية إضافة نسخة من الشريحة تحتوي على نص إلى العرض التقديمي وتعيين انتقال من نوع [morph type](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) إلى الشريحة الثانية.
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
تم إضافة تعداد جديد [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) يمثل أنواعًا مختلفة من انتقال شريحة Morph.

يحتوي تعداد TransitionMorphType على ثلاثة أعضاء:

- ByObject: سيتم تنفيذ انتقال Morph مع اعتبار الأشكال ككائنات غير قابلة للتجزئة.
- ByWord: سيتم تنفيذ انتقال Morph بنقل النص كلمةً كلمةً حيثما أمكن.
- ByChar: سيتم تنفيذ انتقال Morph بنقل النص حرفًا بحرفٍ حيثما أمكن.

المقتطف البرمجي التالي يوضح كيفية تعيين انتقال Morph إلى الشريحة وتغيير نوع Morph:
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


## **تعيين مؤثرات الانتقال**
يدعم Aspose.Slides for Java تعيين مؤثرات الانتقال مثل من الأسود، من اليسار، من اليمين، إلخ. لتعيين مؤثر الانتقال، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- الحصول على مرجع الشريحة.
- ضبط مؤثر الانتقال.
- كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

في المثال المرفق أدناه، قمنا بتعيين مؤثرات الانتقال.
```java
// إنشاء كائن من فئة Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تعيين التأثير
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // حفظ العرض التقديمي على القرص
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. اضبط [speed](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) للانتقال باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) (مثلًا، بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت والتكرار (مثلًا، [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)، بالإضافة إلى بيانات وصفية مثل [setSoundIsBuiltIn](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) و [setSoundName](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**ما أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بتهيئة نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ فالتغييرات تُحفظ لكل شريحة على حدة، لذا تطبيق نفس النوع على جميع الشرائح يعطي نتيجة موحدة.

**كيف يمكنني التحقق من أي انتقال مُعين حاليًا على شريحة؟**

اطلع على [إعدادات الانتقال](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getSlideShowTransition--) الخاصة بالشريحة واقرأ [نوع الانتقال](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setType-int-)؛ هذه القيمة تُظهر لك بالضبط أي مؤثر تم تطبيقه.