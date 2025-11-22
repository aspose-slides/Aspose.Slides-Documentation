---
title: "انتقال الشريحة"
type: docs
weight: 90
url: /ar/net/slide-transition/
keywords: "إضافة انتقال الشريحة, انتقال شريحة PowerPoint, انتقال morph, انتقال شريحة متقدم, تأثيرات الانتقال, C#, Csharp, .NET, Aspose.Slides"
description: "إضافة انتقال شريحة PowerPoint وتأثيرات الانتقال في C# أو .NET"
---

## **إضافة انتقال الشريحة**
لتسهيل الفهم، قدمنا مثالًا على استخدام Aspose.Slides for .NET لإدارة انتقالات الشرائح البسيطة. يمكن للمطوّرين ليس فقط تطبيق تأثيرات انتقال مختلفة على الشرائح بل أيضًا تخصيص سلوك هذه التأثيرات. لإنشاء تأثير انتقال شريحة بسيط، اتّبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. تطبيق نوع انتقال الشريحة على الشريحة باستخدام أحد تأثيرات الانتقال المتوفرة في Aspose.Slides for .NET عبر تعداد TransitionType.
1. كتابة ملف العرض المعدّل.
```c#
// إنشاء كائن من فئة Presentation لتحميل ملف العرض المصدر
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // تطبيق انتقال بنوع دائرة على الشريحة 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // تطبيق انتقال بنوع مشط على الشريحة 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // حفظ العرض إلى القرص
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **إضافة انتقال شريحة متقدّم**
في القسم السابق، قمنا بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل هذا التأثير أبسط وأكثر تحكمًا، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. تطبيق نوع انتقال الشريحة على الشريحة باستخدام أحد تأثيرات الانتقال المتوفرة في Aspose.Slides for .NET.
1. يمكنك أيضًا ضبط الانتقال على التقدم عند النقر، بعد فترة زمنية محددة أو كلاهما.
1. إذا تم تمكين الانتقال للتقدم عند النقر، سيتقدم الانتقال فقط عند النقر بالفأرة. علاوةً على ذلك، إذا تم تعيين خاصية Advance After Time، سيتقدم الانتقال تلقائيًا بعد مرور الوقت المحدد.
1. كتابة العرض المعدّل كملف عرض.
```c#
// إنشاء كائن من فئة Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // تطبيق انتقال من نوع دائرة على الشريحة 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // تعيين زمن الانتقال إلى 3 ثوانٍ
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // تطبيق انتقال من نوع مشط على الشريحة 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // تعيين زمن الانتقال إلى 5 ثوانٍ
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // تطبيق انتقال من نوع تكبير على الشريحة 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // تعيين زمن الانتقال إلى 7 ثوانٍ
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // حفظ العرض على القرص
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


بالإضافة إلى ذلك، باستخدام خاصية [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/)، يمكنك التحقق مما إذا كان تم تكوين انتقال الشريحة للانتقال إلى الشريحة التالية أو تعطيل الإعداد.

يعرض الكود التالي عملية ذلك في C#:
```c#
// ينشئ كائنًا من فئة Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // يحصل على انتقال الشريحة
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // يتحقق مما إذا كان إعداد التقدم بعد الوقت مفعلاً
        if (slideTransition.AdvanceAfter)
        {
            // يطبع قيمة التقدم بعد الوقت
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // يعطل الانتقال بعد فترة زمنية محددة إذا كانت قيمة AdvancedAfterTime أكبر من ثانيتين
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```


## **انتقال Morph**
يدعم Aspose.Slides for .NET الآن [Morph Transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). وهو يمثل انتقال Morph الجديد الذي تم تقديمه في PowerPoint 2019. يسمح انتقال Morph بإنشاء حركة سلسة من شريحة إلى أخرى. تصف هذه المقالة المفهوم وكيفية استخدام انتقال Morph. لاستخدام انتقال Morph بفعالية، ستحتاج إلى شريحتين تحتويان على كائن واحد على الأقل مشترك. أسهل طريقة هي استنساخ الشريحة ثم نقل الكائن في الشريحة الثانية إلى موقع مختلف.

يعرض المقتطف البرمجي التالي كيفية إضافة نسخة من الشريحة تحتوي على بعض النصوص إلى العرض وتعيين انتقال من نوع [morph type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) للشريحة الثانية.
```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **أنواع انتقال Morph**
تم إضافة تعداد [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype) جديد. يمثل أنواعًا مختلفة من انتقال شريحة Morph.

يحتوي تعداد TransitionMorphType على ثلاث قيم:

- ByObject: يتم تنفيذ انتقال Morph مع اعتبار الأشكال ككائنات غير قابلة للتقسيم.
- ByWord: يتم تنفيذ انتقال Morph بنقل النص كلمةً كلمةً حيثما أمكن.
- ByChar: يتم تنفيذ انتقال Morph بنقل النص حرفًا بحرف حيثما أمكن.

يعرض المقتطف البرمجي التالي كيفية تعيين انتقال Morph للشريحة وتغيير نوع Morph:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **تعيين تأثيرات الانتقال**
يدعم Aspose.Slides for .NET تعيين تأثيرات الانتقال مثل الانتقال من الأسود، من اليسار، من اليمين، إلخ. لتعيين تأثير الانتقال، يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- الحصول على مرجع الشريحة.
- تعيين تأثير الانتقال.
- كتابة العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

في المثال أدناه، قمنا بتعيين تأثيرات الانتقال.
```c#
// إنشاء كائن من فئة Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// تعيين التأثير
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// حفظ العرض إلى القرص
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```


## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. اضبط خاصية [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) للانتقال باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) (مثلاً، بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت وإعادة التكرار (مثلاً، [Sound](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/sound/)، [SoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundmode/)، [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundloop/)، بالإضافة إلى بيانات وصفية مثل [SoundIsBuiltIn](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) و [SoundName](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**ما هي أسرع طريقة لتطبيق نفس الانتقال على جميع الشرائح؟**

قم بتكوين نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ لأن الانتقالات تُخزن لكل شريحة على حدة، لذا فإن تطبيق نفس النوع على جميع الشرائح ينتج نتيجة متسقة.

**كيف يمكنني التحقق من نوع الانتقال المحدد حاليًا على شريحة ما؟**

افحص إعدادات انتقال الشريحة عبر [transition settings](https://reference.aspose.com/slides/net/aspose.slides/baseslide/slideshowtransition/) وقراءة [transition type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/type/)؛ ستوضح لك القيمة بالضبط أي تأثير تم تطبيقه.