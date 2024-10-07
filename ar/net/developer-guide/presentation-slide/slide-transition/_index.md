---
title: انتقالات الشرائح
type: docs
weight: 90
url: /net/slide-transition/
keywords: "إضافة انتقال شرائح، انتقال شرائح PowerPoint، انتقالات التحول، انتقال الشرائح المتقدمة، تأثيرات الانتقال، C#، Csharp، .NET، Aspose.Slides"
description: "إضافة انتقال شرائح PowerPoint وتأثيرات الانتقال في C# أو .NET"
---

## **إضافة انتقال الشرائح**
لتسهيل الفهم، قمنا بعرض استخدام Aspose.Slides لـ .NET لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين تطبيق تأثيرات انتقال شرائح مختلفة على الشرائح، بالإضافة إلى تخصيص سلوك هذه التأثيرات. لإنشاء تأثير انتقال شرائح بسيط، اتبع الخطوات أدناه:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. قم بتطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال المقدمة من Aspose.Slides لـ .NET من خلال enum TransitionType.
1. اكتب ملف العرض التقديمي المعدل.

```c#
// Instantiate Presentation class to load the source presentation file
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Apply circle type transition on slide 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Apply comb type transition on slide 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Write the presentation to disk
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **إضافة انتقال شرائح متقدمة**
في القسم أعلاه، قمنا فقط بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل ذلك التأثير الانتقالي البسيط أفضل وقابلًا للتحكم، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. قم بتطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال المقدمة من Aspose.Slides لـ .NET.
1. يمكنك أيضًا تعيين الانتقال على التقدم عند النقر، بعد فترة زمنية معينة أو كليهما.
1. إذا كان الانتقال على الشريحة مفعلًا للتقدم عند النقر، فسيتم الانتقال فقط عند نقر شخص ما على الفأرة. علاوة على ذلك، إذا تم تعيين خاصية التقدم بعد الوقت، فسيتقدم الانتقال تلقائيًا بعد مرور الوقت المحدد.
1. اكتب العرض التقديمي المعدل كملف عرض تقديمي.

```c#
// Instantiate Presentation class that represents a presentation file
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Apply circle type transition on slide 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Set the transition time of 3 seconds
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Apply comb type transition on slide 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Set the transition time of 5 seconds
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Apply zoom type transition on slide 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Set the transition time of 7 seconds
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Write the presentation to disk
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

بالإضافة إلى ذلك، باستخدام خاصية [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/)، يمكنك التحقق مما إذا كان قد تم تكوين انتقال الشريحة للانتقال إلى الشريحة التالية أو تعطيل الإعداد.

توضح كود C# التالي العملية:

```c#
// Instantiates a Presentation class that represents a presentation file
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Gets the slide Transition
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Checks whether the Advance After Time setting is enabled
        if (slideTransition.AdvanceAfter)
        {
            // Prints the Advance After Time value
            Console.WriteLine("الشريحة #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Disables the transition after a specific time if the AdvancedAfterTime value is greater than 2 seconds
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```


## **انتقال التحول**
يدعم Aspose.Slides لـ .NET الآن [انتقال التحول](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). يمثلون انتقال تحولي جديد تم تقديمه في PowerPoint 2019. يسمح انتقال التحول بتحريك سلس من شريحة إلى الأخرى. يصف هذا المقال المفهوم وكيفية استخدام انتقال التحول. لاستخدام انتقال التحول بشكل فعال، ستحتاج إلى الحصول على شريحتين بهما على الأقل كائن مشترك. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن إلى مكان مختلف على الشريحة الثانية.

يعرض كود العينة التالي كيفية إضافة نسخ من الشريحة مع بعض النصوص إلى العرض التقديمي وتعيين انتقال من نوع [تحول](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) إلى الشريحة الثانية.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "انتقال التحول في عروض PowerPoint";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **أنواع انتقال التحول**
تم إضافة enum [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype). يمثل أنواعًا مختلفة من انتقال شرائح التحول.

يحتوي enum TransitionMorphType على ثلاثة أعضاء:

- ByObject: سيتم تنفيذ انتقال التحول مع اعتبار الأشكال ككائنات غير قابلة للتجزئة.
- ByWord: سيتم تنفيذ انتقال التحول من خلال نقل النص حسب الكلمات حيثما أمكن.
- ByChar: سيتم تنفيذ انتقال التحول من خلال نقل النص حسب الأحرف حيثما أمكن.

يعرض كود العينة التالي كيفية تعيين انتقال التحول على الشريحة وتغيير نوع التحول:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **تعيين تأثيرات الانتقال**
يدعم Aspose.Slides لـ .NET تعيين تأثيرات الانتقال مثل، من الأسود، من اليسار، من اليمين، إلخ. لتعيين تأثير الانتقال. يرجى اتباع الخطوات أدناه:

- أنشئ مثيلًا من [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- احصل على مرجع من الشريحة.
- تعيين تأثير الانتقال.
- اكتب العرض التقديمي كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/).

في المثال المعطى أدناه، قمنا بتعيين تأثيرات الانتقال.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation("AccessSlides.pptx");

// Set effect
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Write the presentation to disk
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```