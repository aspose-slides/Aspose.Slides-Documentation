---
title: انتقال الشريحة
type: docs
weight: 80
url: /ar/nodejs-java/slide-transition/
keywords: "انتقال شريحة PowerPoint، انتقال morph في JavaScript"
description: "انتقال شريحة PowerPoint، انتقال morph PowerPoint في JavaScript"
---

## **نظرة عامة**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js عبر Java يتيح أيضًا للمطورين إدارة أو تخصيص تأثيرات انتقال الشرائح. في هذا الموضوع، سنناقش التحكم في انتقالات الشرائح بسهولة كبيرة باستخدام Aspose.Slides for Node.js عبر Java.

{{% /alert %}} 

لتسهيل الفهم، قمنا بشرح كيفية استخدام Aspose.Slides for Node.js عبر Java لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين ليس فقط تطبيق تأثيرات انتقال مختلفة على الشرائح، بل أيضًا تخصيص سلوك هذه التأثيرات.

## **إضافة انتقال للشفرة**
لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
2. تطبيق نوع انتقال شريحة على الشريحة من أحد تأثيرات الانتقال التي تقدمها Aspose.Slides for Node.js عبر Java عبر التعداد TransitionType.
3. كتابة ملف العرض المعدل.
```javascript
// إنشاء كائن من فئة Presentation لتحميل ملف العرض المصدر
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // تطبيق انتقال من نوع دائرة على الشريحة 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // تطبيق انتقال من نوع مشط على الشريحة 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // كتابة العرض إلى القرص
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **إضافة انتقال شريحة متقدم**
في القسم السابق، قمنا فقط بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل هذا التأثير البسيط أفضل وأكثر تحكمًا، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) .
2. تطبيق نوع انتقال شريحة على الشريحة من أحد تأثيرات الانتقال التي تقدمها Aspose.Slides for Node.js عبر Java.
3. يمكنك أيضًا تعيين الانتقال إلى Advance On Click، أو بعد فترة زمنية محددة، أو كليهما.
4. إذا تم تمكين انتقال الشريحة إلى Advance On Click، سيتقدم الانتقال فقط عندما ينقر المستخدم بالفأرة. علاوة على ذلك، إذا تم تعيين خاصية Advance After Time، سيتقدم الانتقال تلقائيًا بعد مرور الوقت المحدد.
5. كتابة العرض المعدل كملف عرض.
```javascript
// إنشاء كائن من الفئة Presentation الذي يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // تطبيق انتقال من نوع دائرة على الشريحة 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // ضبط وقت الانتقال إلى 3 ثوانٍ
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // تطبيق انتقال من نوع مشط على الشريحة 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // ضبط وقت الانتقال إلى 5 ثوانٍ
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // تطبيق انتقال من نوع تكبير على الشريحة 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // ضبط وقت الانتقال إلى 7 ثوانٍ
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // كتابة العرض إلى القرص
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **انتقال Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js عبر Java يدعم الآن [Morph Transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MorphTransition). وهو يمثل انتقال Morph الجديد المقدم في PowerPoint 2019.

{{% /alert %}} 

يسمح لك انتقال Morph بتحريك سلس من شريحة إلى أخرى. يصف هذا المقال المفهوم وكيفية استخدام انتقال Morph. لاستخدامه بفعالية، تحتاج إلى شريحتين على الأقل تشتركان في عنصر واحد. أسهل طريقة هي تكرار الشريحة ثم نقل العنصر في الشريحة الثانية إلى موضع مختلف.

يعرض المقتطف البرمجي التالي كيفية إضافة نسخة من الشريحة بها بعض النص إلى العرض وتعيين نوع انتقال [morph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionType) للشريحة الثانية.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **أنواع انتقال Morph**
تم إضافة تعداد [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionMorphType) جديد. يمثل أنواعًا مختلفة من انتقال شريحة Morph.

يحتوي تعداد TransitionMorphType على ثلاثة أعضاء:

- ByObject: سيتم تنفيذ انتقال Morph مع اعتبار الأشكال ككائنات غير قابلة للتقسيم.
- ByWord: سيتم تنفيذ انتقال Morph بنقل النص كلمة بكلمة حيثما أمكن.
- ByChar: سيتم تنفيذ انتقال Morph بنقل النص حرفًا بحرف حيثما أمكن.

يعرض المقتطف البرمجي التالي كيفية تعيين انتقال Morph إلى الشريحة وتغيير نوع Morph:
```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **تعيين تأثيرات الانتقال**
Aspose.Slides for Node.js عبر Java يدعم تعيين تأثيرات الانتقال مثل من الأسود، من اليسار، من اليمين وغيرها. لتعيين تأثير الانتقال، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة.
- تعيين تأثير الانتقال.
- كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

في المثال أدناه، قمنا بتعيين تأثيرات الانتقال.
```javascript
// إنشاء مثيل من فئة Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // تعيين التأثير
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // كتابة العرض إلى القرص
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. عيّن [سرعة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setspeed/) الانتقال باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) (مثلاً slow/medium/fast).

**هل يمكنني إرفاق صوت بانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت والتكرار (مثلاً [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsound/)، [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/)، [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/)، بالإضافة إلى بيانات تعريف مثل [setSoundIsBuiltIn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) و [setSoundName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**ما أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بتكوين نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ يتم تخزين الانتقالات لكل شريحة على حدة، لذا فإن تطبيق نفس النوع على جميع الشرائح يعطي نتيجة متسقة.

**كيف يمكنني التحقق من الانتقال المعين حاليًا على شريحة؟**

تحقق من [إعدادات الانتقال](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) للشريحة واقرأ [نوع الانتقال](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/gettype/)؛ هذه القيمة تخبرك بالضبط أي تأثير تم تطبيقه.