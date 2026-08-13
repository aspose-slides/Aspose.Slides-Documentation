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
- تحول Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides for Java، مع إرشادات خطوة بخطوة لعروض PowerPoint وOpenDocument التقديمية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إدارة انتقالات الشرائح في العروض التقديمية باستخدام Aspose.Slides. تُظهر كيفية تطبيق أنواع الانتقال على الشرائح، وتكوين سلوك الانتقال مثل التقدم عند النقر أو بعد زمن محدد، والتحقق من وتعطيل التقدم التلقائي، واستخدام انتقال Morph وأنواعه، وتعيين خيارات تأثير الانتقال. تُظهر الأمثلة كيفية تحميل عرض تقديمي أو إنشاءه، وتعديل إعدادات الانتقال للشرائح المحددة، وحفظ النتيجة كملف PPTX. كما تُجيب المقالة على أسئلة شائعة حول سرعة الانتقال، أصوات الانتقال، تطبيق نفس الانتقال على عدة شرائح، والتحقق من الانتقال الحالي المحدد على الشريحة.

## **إضافة انتقال الشريحة**
لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
2. تطبيق نوع انتقال شريحة على الشريحة من أحد تأثيرات الانتقال المتوفرة في Aspose.Slides for Java عبر تعداد TransitionType.
3. كتابة ملف العرض التقديمي المعدل.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تطبيق انتقال من نوع دائرة على الشريحة 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تطبيق انتقال من نوع مشط على الشريحة 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // حفظ العرض التقديمي إلى القرص
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة انتقال شريحة متقدم**
في القسم السابق، قمنا بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل هذا التأثير أبسط وأكثر تحكمًا، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
2. تطبيق نوع انتقال شريحة على الشريحة من أحد تأثيرات الانتقال المتوفرة في Aspose.Slides for Java.
3. يمكنك أيضًا ضبط الانتقال للتقدم عند النقر، أو بعد فترة زمنية محددة، أو كلاهما.
4. إذا تم تمكين الانتقال للتقدم عند النقر، سيتقدم الانتقال فقط عند نقر الفأرة. علاوة على ذلك، إذا تم تعيين خاصية Advance After Time، سيتقدم الانتقال تلقائيًا بعد مرور الوقت المحدد.
5. كتابة العرض التقديمي المعدل كملف عرض تقديمي.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // تطبيق انتقال من نوع دائرة على الشريحة 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تعيين مدة الانتقال بـ 3 ثوانٍ
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // تطبيق انتقال من نوع مشط على الشريحة 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // تعيين مدة الانتقال بـ 5 ثوانٍ
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // تطبيق انتقال من نوع تكبير على الشريحة 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // تعيين مدة الانتقال بـ 7 ثوانٍ
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // حفظ العرض التقديمي إلى القرص
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **التحول Morph**
{{% alert color="info" %}} 

Aspose.Slides for Java الآن يدعم [Morph Transition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IMorphTransition). إنها تمثل التحول Morph الجديد المقدم في PowerPoint 2019.

{{% /alert %}} 

يسمح انتقال Morph بتحريك سلس من شريحة إلى أخرى. تصف هذه المقالة المفهوم وكيفية استخدام انتقال Morph. لاستخدامه بفعالية، ستحتاج إلى شريحتين تتشاركان على الأقل كائنًا واحدًا. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن في الشريحة الثانية إلى موضع مختلف.

يعرض المقتطف البرمجي التالي كيفية إضافة نسخة مكررة من الشريحة مع بعض النص إلى العرض التقديمي وتعيين نوع انتقال [morph type](https://reference.aspose.com/slides/ar/java/com.aspose.slides/TransitionType) على الشريحة الثانية.

```java
import com.aspose.slides.*;

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

## **أنواع التحول Morph**
تم إضافة تعداد [TransitionMorphType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/TransitionMorphType). يمثل أنواعًا مختلفة من انتقال شريحة Morph.

يحتوي تعداد TransitionMorphType على ثلاث قيم:

- ByObject: سيتم تنفيذ انتقال Morph مع اعتبار الأشكال ككائنات غير قابلة للتقسيم.
- ByWord: سيتم تنفيذ انتقال Morph بنقل النص كلمة بكلمة حيثما كان ذلك ممكنًا.
- ByChar: سيتم تنفيذ انتقال Morph بنقل النص حرفًا بحرف حيثما كان ذلك ممكنًا.

يعرض المقتطف البرمجي التالي كيفية تعيين انتقال Morph على شريحة وتغيير نوع Morph:

```java
import com.aspose.slides.*;

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
يدعم Aspose.Slides for Java تعيين تأثيرات الانتقال مثل من الأسود، من اليسار، من اليمين وما إلى ذلك. لتعيين تأثير الانتقال، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة.
- تعيين تأثير الانتقال.
- كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

في المثال أدناه، قمنا بتعيين تأثيرات الانتقال.

```java
import com.aspose.slides.*;

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

## **الأسئلة الشائعة**

### هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟

نعم. اضبط [speed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) للانتقال باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/transitionspeed/) (مثلاً بطيء/متوسط/سريع).

### هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت وإعادة التكرار (مثل [setSound](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)، [setSoundMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-)، [setSoundLoop](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)، بالإضافة إلى بيانات وصفية مثل [setSoundIsBuiltIn](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) و[setSoundName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟

قم بإعداد نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ يتم تخزين الانتقالات لكل شريحة، لذا تطبيق نفس النوع على جميع الشرائح يعطي نتيجة متسقة.

### كيف يمكنني التحقق من أي انتقال مُعيّن حاليًا على شريحة؟

افحص [transition settings](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslide/#getSlideShowTransition--) للشريحة واقرأ [transition type](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideshowtransition/#setType-int-); تلك القيمة تخبرك بالضبط أي تأثير تم تطبيقه.