---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام .NET
linktitle: انتقال الشريحة
type: docs
weight: 90
url: /ar/net/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال شريحة متقدم
- تحويل Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص Morph وتأثيرات الانتقال الأخرى باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides لـ .NET، يمكنك اختيار تأثير انتقال لكل شريحة، تكوين التقدم عبر النقر بالماوس أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. يستخدم هذا المقال أمثلة بلغة C# لتطبيق الانتقالات، تحديد أوقات انتقال دقيقة، إدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. كما تُظهر الأمثلة كيفية حفظ الإعدادات إلى ملف PPTX.

## **Add Slide Transition**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) والوصول إلى خاصية [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) للشرائح. اضبط خاصية [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) على قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)، ثم احفظ العرض التقديمي.

المثال التالي يطبق انتقال Circle على الشريحة الأولى وانتقال Comb على الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Wheel Transition**

خاصية [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) في [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) تتحكم في عدد القطاعات الشعاعية التي تكشف الشريحة الهدف. اضبط خاصية [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) للشرائح إلى Wheel من تعداد [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) قبل الوصول إلى [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) كـ [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

هذا المثال ينشئ زوجين متطابقين من الشرائح: شريحة سوداء تليها شريحة ذات مستطيل ذهبي. الشرائح الهدف تستخدم عدد أسنان 1 و8، مع نفس [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) و[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) صريحة قيمتها 8 000 مللي ثانية لجعل الفرق واضحًا.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

افتح العرض الناتج في PowerPoint وشغّل عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2، ثم من الشريحة 3 إلى الشريحة 4. في تشغيل PowerPoint، عدد الأسنان 1 يكشف الشريحة باندفاع واحد مع اتجاه عقلي؛ عدد الأسنان 8 يكشفها عبر ثمانية قطاعات شعاعية في آن واحد. المحتوى والوقت متطابقان، لذا الفرق هو عدد قطاعات الكشف.

## **Add Advanced Slide Transition**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالماوس يتقدم بالعرض. الخصائص التالية تتحكم في هذا السلوك:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) يسمح للمستعرض بالتقدم عبر النقر بالماوس.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) يتيح التقدم التلقائي.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعِّل كلا من النقر والتقدم الزمني لتسمح للمستعرض بالتقدم بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، اضبط [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) إلى `false`. يتحكم التأخير في توقيت تقدم العرض؛ لا يحدد مدة تأثير الانتقال البصري.

هذا المثال يعين تأثيرات مختلفة للشرائح الثلاث الأولى ويفعل التقدم التلقائي بعد 3 و5 و7 ثوانٍ على التوالي. يمكن للنقرات أيضًا التقدم بهذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

للتحقق مما إذا كان التقدم الزمني مفعلاً، اقرأ [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). التخزين للوقت وحده لا يعني أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يُبلغ عن كل مؤقت مفعَّل، ويعطل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يُفَعِّل النقرات لتلك الشرائح ويُحفظ الإعدادات المحدثة.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Control Transition Timing Precisely**

استخدم [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. خاصية [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) للشرائح تكشف هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| الخاصية | الغرض |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | يحدد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالمللي ثانية. فعل [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) لتفعيل هذا المؤقت. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | يختار فئة السرعة المحددة مسبقًا من [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow، Medium أو Fast. يُستَخدم عندما لا تُحدَّد مدة صريحة. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) يتحكم فقط في تأثير الانتقال؛ لا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدَّد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Apply the Same Duration to Every Slide**

لضمان وتيرة ثابتة، طبق نفس التأثير والمدة الدقيقة على كل شريحة. هذا المثال يحمل `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يفعّل أيضًا التقدم التلقائي بعد 5 000 مللي ثانية ويعطّل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // تكوين التقدم التلقائي بشكل مستقل عن مدة التأثير.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Set Different Durations for Individual Slides**

يمكن للشرائح المختلفة أن تستخدم مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. هذا المثال يحدد 500 مللي ثانية للشفريحة الأولى و1 200 مللي ثانية للثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Coordinate Transitions with Animated Output**

عند إعداد [animated GIF](/slides/ar/net/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/net/export-to-html5/) أو [video](/slides/ar/net/convert-powerpoint-to-video/)، عيّن مدد الانتقال الدقيقة قبل التصدير لمطابقة الوتيرة المطلوبة. على سبيل المثال، استخدم تلاشيًا مدته 600 مللي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بوقت للتعليق الصوتي أو المحتوى.

بالنسبة للـ GIF والفيديو، نسق معدل الإطارات مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من التأثيرات وتوقيت الخيارات المدعومة في تنسيق التصدير المختار، وكان المعاينة لتأكيد التزامن.

### **Read an Existing Transition Duration**

اقرأ [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم تحديد مدة صريحة؛ القيمة غير السالبة تحدد مدة التخزين بالمللي ثانية. القيمة غير المحددة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال و[Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) لتحديد تلك المدة. قد يهيئ ضبط نوع الانتقال مدةً، لذا افحص الإعدادات الأصلية أولاً.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph Transition**

ينتقل Morph بين التغييرات في الكائنات على شرائح متتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرّك أو غير حجم كائن على النسخة، ثم طبق انتقال Morph على الشريحة الثانية. يمنح ذلك الكائنات المتطابقة ما بين حالتها الأصلية والمعدلة.

المثال التالي ينشئ شريحة تحتوي على مستطيل نص، يستنسخ الشريحة، ويغيّر موضع وحجم المستطيل في النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) للشفريحة الثانية. افتح الملف المحفوظ في عارض يدعم Morph لمشاهدة التأثير أثناء عرض الشرائح.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph Transition Types**

تعداد [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) يتحكم في طريقة مطابقة وتحريك المحتوى في Morph:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الأحرف حيثما أمكن.

اضبط خاصية [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) للانتقال إلى Morph قبل الوصول إلى [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). تُعيد القيمة واجهة [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/)، حيث تختار خاصية [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) وضع المطابقة.

هذا المثال يفتح العرض الذي تم إنشاؤه في القسم السابق ويضبط الشريحة الثانية لاستخدام حركة Morph على أساس الكلمات.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

<!-- visual-explanation:slide-transition:start -->
[![Morph matching units shown as a whole shape, individual words, and individual characters.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*يمكن لـ Morph مطابقة الأشكال الكاملة أو الكلمات أو الحروف حسب الإمكان. تُظهر هذه المربعات وحدات المطابقة بدلاً من الحركة الملحوظة. يختار المثال ByWord في الشريحة الثانية.*
<!-- visual-explanation:slide-transition:end -->

## **Set Transition Effects**

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان يبدأ التأثير من شاشة سوداء. تعتمد الخيارات المتاحة على نوع الانتقال المحدد في خاصية [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). اضبط النوع أولًا، ثم استخدم الواجهة المناسبة من خاصية [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

المثال التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يضبط [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) عبر [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) لتبدأ الانتقال من شاشة سوداء.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يُفضَّل استخدام [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) المحددة مسبقًا—Slow، Medium أو Fast—كافية ولا يُحدد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مدمجًا إلى خاصية [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/)، اضبط [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) إلى StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/)، وفعل [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). سيستمر الصوت في التكرار حتى يحدث حدث صوتي التالي في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على جميع الشرائح؟**

تجول عبر مجموعة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) في العرض، واضبط خاصية [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) لكل شريحة إلى نفس القيمة. اضبط أي توقيتات أو خيارات تأثير داخل نفس الحلقة للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المعين على شريحة؟**

اقرأ خاصية [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) من [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) للشرائح. تُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/); قيمة None تعني أنه لا يُطبق أي تأثير انتقال.