---
title: إدارة انتقالات الشرائح في العروض التقديمية على Android
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/androidjava/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال شريحة
- تطبيق انتقال شريحة
- انتقال شريحة متقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides for Android عبر Java، مع إرشادات خطوة بخطوة لعروض PowerPoint وOpenDocument التقديمية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إدارة انتقالات الشرائح في العروض التقديمية باستخدام Aspose.Slides. تُظهر كيفية تطبيق أنواع الانتقالات على الشرائح، وتكوين سلوك الانتقال مثل التقدم عند النقر أو بعد وقت محدد، واستخدام انتقال Morph وأنواعه، وتعيين خيارات تأثير الانتقال. توضح الأمثلة كيفية تحميل أو إنشاء عرض تقديمي، وتعديل إعدادات الانتقال للشرائح المحددة، وحفظ النتيجة كملف PPTX. كما تجيب المقالة على الأسئلة الشائعة حول سرعة الانتقال، أصوات الانتقال، تطبيق نفس الانتقال على عدة شرائح، والتحقق من الانتقال المُعين حاليًا على شريحة.

## **إضافة انتقال للشرائح**
لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) .
1. تطبيق نوع انتقال شريحة على الشريحة من أحد تأثيرات الانتقال التي يوفرها Aspose.Slides for Android عبر Java من خلال تعداد TransitionType
1. كتابة ملف العرض التقديمي المعدل.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تطبيق انتقال نوع دائرة على الشريحة 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // تطبيق انتقال نوع مشط على الشريحة 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // حفظ العرض التقديمي إلى القرص
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة انتقال شريحة متقدم**
في القسم أعلاه، قمنا فقط بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل هذا التأثير البسيط أفضل وأكثر تحكمًا، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) .
1. تطبيق نوع انتقال شريحة على الشريحة من أحد تأثيرات الانتقال التي يوفرها Aspose.Slides for Android عبر Java
1. يمكنك أيضًا ضبط الانتقال ليتم التقدم عند النقر، بعد فترة زمنية محددة أو كلاهما.
1. إذا تم تمكين انتقال الشريحة للتقدم عند النقر، سيتقدم الانتقال فقط عندما يقوم أحدهم بالنقر بالفأرة. علاوة على ذلك، إذا تم تعيين خاصية Advance After Time، سيتقدم الانتقال تلقائيًا بعد مرور الوقت المحدد.
1. اكتب العرض التقديمي المعدل كملف عرض تقديمي.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // تطبيق انتقال نوع دائرة على الشريحة 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // التقدم عند النقر أو تلقائيًا بعد 3 ثوانٍ
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // تطبيق انتقال نوع مشط على الشريحة 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // التقدم عند النقر أو تلقائيًا بعد 5 ثوانٍ
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // تطبيق انتقال نوع تكبير على الشريحة 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // التقدم عند النقر أو تلقائيًا بعد 7 ثوانٍ
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // حفظ العرض التقديمي إلى القرص
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **انتقال Morph**
{{% alert color="info" %}} 

الآن يدعم Aspose.Slides for Android عبر Java [انتقال Morph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IMorphTransition). يمثلون انتقال Morph الجديد الذي تم تقديمه في PowerPoint 2019.

{{% /alert %}} 

يتيح لك انتقال Morph تحريك سلس من شريحة إلى أخرى. تصف هذه المقالة المفهوم وكيفية استخدام انتقال Morph. لاستخدام انتقال Morph بفعالية، تحتاج إلى وجود شريحتين على الأقل تشتركان في كائن واحد. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن في الشريحة الثانية إلى مكان مختلف.

تُظهر الشفرة التالية كيفية إضافة نسخة من الشريحة مع بعض النص إلى العرض التقديمي وتعيين انتقال من [نوع morph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/TransitionType) إلى الشريحة الثانية.

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

## **أنواع انتقال Morph**
تمت إضافة تعداد جديد [TransitionMorphType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/TransitionMorphType). يمثل أنواعًا مختلفة من انتقال شريحة Morph.

تعداد TransitionMorphType يحتوي على ثلاثة أعضاء:

- ByObject: سيُجرى انتقال Morph مع اعتبار الأشكال ككائنات غير قابلة للتقسيم.
- ByWord: سيُجرى انتقال Morph بنقل النص كلمةً كلمةً حيثما كان ذلك ممكنًا.
- ByChar: سيُجرى انتقال Morph بنقل النص حرفًا حرفًا حيثما كان ذلك ممكنًا.

تُظهر الشفرة التالية كيفية تعيين انتقال Morph إلى شريحة وتغيير نوع Morph:

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

## **ضبط تأثيرات الانتقال**
يدعم Aspose.Slides for Android عبر Java ضبط تأثيرات الانتقال مثل من الأسود، من اليسار، من اليمين، إلخ. لتعيين تأثير الانتقال، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) .
- الحصول على مرجع الشريحة.
- ضبط تأثير الانتقال.
- كتابة العرض التقديمي كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/) .

في المثال أدناه، قمنا بضبط تأثيرات الانتقال.

```java
import com.aspose.slides.*;

// إنشاء نسخة من فئة Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تعيين التأثير
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // كتابة العرض التقديمي إلى القرص
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟

نعم. اضبط [السرعة] للانتقال باستخدام إعداد [TransitionSpeed] (مثلاً بطئ/متوسط/سريع).

### هل يمكنني إرفاق صوت بانتقال وجعله يتكرر؟

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت والتكرار (مثل [setSound](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), بالإضافة إلى بيانات وصفية مثل [setSoundIsBuiltIn](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) و [setSoundName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### ما هو أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟

قم بتكوين نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ تُحفظ الانتقالات لكل شريحة على حدة، لذا تطبيق نفس النوع على جميع الشرائح سيعطي نتيجة متسقة.

### كيف يمكنني التحقق من الانتقال المحدد حاليًا على شريحة؟

افحص [إعدادات الانتقال] الخاصة بالشريحة واقرأ [نوع الانتقال]؛ هذه القيمة تخبرك بدقة ما هو التأثير المطبق.