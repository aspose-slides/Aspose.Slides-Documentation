---
title: إدارة انتقالات الشرائح في العروض التقديمية في .NET
linktitle: انتقال الشريحة
type: docs
weight: 90
url: /ar/net/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال شريحة متقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وغيره من تأثيرات الانتقال باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides for .NET، يمكنك اختيار تأثير انتقال لكل شريحة، تكوين التقدم عبر النقر بالفأرة أو المؤقت، وضبط الخيارات الخاصة بتأثير معين. تستخدم هذه المقالة أمثلة C# لتطبيق الانتقالات، تحديد مدة الانتقال بدقة، إدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. كما تظهر الأمثلة كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال للشرائح**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) والوصول إلى خاصية [SlideShowTransition](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/slideshowtransition/) للشرائح. عيّن [Type](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/type/) إلى قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitiontype/)، ثم احفظ العرض التقديمي.

المثال التالي يطبق انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

## **إضافة انتقال متقدم للشرائح**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالفأرة يتقدم بعرض الشرائح. الخصائص التالية تتحكم في هذا السلوك:

- [AdvanceOnClick](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/advanceonclick/) يتيح للمشاهد التقدم بالنقر على الفأرة.
- [AdvanceAfter](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/advanceafter/) يتيح التقدم التلقائي.
- [AdvanceAfterTime](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/advanceaftertime/) يحدّد التأخير قبل التقدم التلقائي، بالميلي ثانية.

فعّل كل من التقدم بالنقر والتقدم المؤقت للسماح للمشاهد بالمتابعة بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، عيّن [AdvanceOnClick](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/advanceonclick/) إلى `false`. يتحكم التأخير في توقيت تقدم عرض الشرائح؛ ولا يحدّد مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعل التقدم التلقائي بعد 3، 5، و7 ثوانٍ على التوالي. يمكن للنقرات بالفأرة أيضًا التقدم بهذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق مما إذا كان التقدم المؤقت مفعَّلًا، اقرأ [AdvanceAfter](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/advanceafter/). مجرد وجود تأخير مخزن لا يدل على أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يبلغ عن كل مؤقت مفعَّل، ويعطّل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يُفعّل النقر بالفأرة لهذه الشرائح ويحفظ الإعدادات المحدثة.

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

## **التحكم بدقة في توقيت الانتقال**

استخدم [Duration](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/duration/) لتحديد الطول الدقيق لتأثير الانتقال بالميلي ثانية. خاصية [SlideShowTransition](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/slideshowtransition/) للشرائح تكشف عن هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/):

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/duration/) | يحدد مدة تأثير الانتقال نفسه، بالميلي ثانية. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | يحدد التأخير قبل أن تتقدم الشريحة تلقائيًا، بالميلي ثانية. فعّل [AdvanceAfter](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/advanceafter/) لتفعيل هذا المؤقت. |
| [Speed](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/speed/) | يختار فئة سرعة مسبقة من [TransitionSpeed](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitionspeed/): Slow، Medium، أو Fast. يستخدم عندما لا يتم تحديد مدة دقيقة. |

[Duration](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/duration/) يتحكم فقط في تأثير الانتقال؛ ولا يحدّد مدة بقاء الشريحة مرئية. قم بتكوين تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [Speed](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **تطبيق نفس المدة على كل شريحة**

لتنظيم الإيقاع بشكل ثابت، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. هذا المثال يحمّل `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitiontype/)، ويعطي كل انتقال مدة 750 ميلي ثانية. كما يفعّل التقدم التلقائي بعد 5,000 ميلي ثانية ويعطّل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

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

### **تعيين مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة استخدام مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. هذا المثال يحدد 500 ميلي ثانية للشرحة الأولى و1,200 ميلي ثانية للشرحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

### **تنسيق الانتقالات مع الإخراج المتحرك**

عند إعداد [GIF متحرك](/slides/ar/net/convert-powerpoint-to-animated-gif/)، [عرض HTML5](/slides/ar/net/export-to-html5/)، أو [الفيديو](/slides/ar/net/convert-powerpoint-to-video/)، حدد مدد الانتقال الدقيقة قبل التصدير لتتناسب مع الإيقاع المطلوب. على سبيل المثال، استخدم تلاشيًا بمدة 600 ميلي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل لتوفير وقت للسرد أو المحتوى.

للـ GIF والفيديو، نسّق معدل الإطار مع مدة التأثير: 600 ميلي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من تأثيرات وإعدادات التوقيت المدعومة في تنسيق التصدير المختار، وقم بمعاينة النتيجة لتأكيد التزامن.

### **قراءة مدة الانتقال الحالية**

اقرأ [Duration](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/duration/) قبل تعديل الانتقال لتحديد ما إذا كان هناك قيمة صريحة مخزنة. القيمة `-1` تعني عدم تحديد مدة صريحة؛ والقيمة غير السالبة تحدد المدة المخزنة بالميلي ثانية. القيمة غير المضبوطة ليست مدة التشغيل المحتسبة: يستخدم Aspose.Slides نوع الانتقال و[Speed](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/speed/) لتحديد تلك المدة. تعيين نوع الانتقال قد يهيئ مدةً، لذا تحقق من الإعدادات الأصلية أولاً.

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

## **انتقال Morph**

يُحرك انتقال Morph التغييرات بين الكائنات على الشرائح المتتالية. لإنشاء تأثير Morph بسيط، انسخ شريحة، حرّك أو غير حجم كائن على النسخة، وطبق انتقال Morph على الشريحة الثانية. يمنح ذلك الكائنات المتطابقة للانتقال فرصة التحريك بين حالتها الأصلية والمعدّلة.

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

## **أنواع انتقال Morph**

تتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitionmorphtype/) في طريقة مطابقة وتحريك المحتوى بواسطة Morph:

- [ByObject](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitionmorphtype/) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الأحرف حيثما أمكن.

عيّن [Type](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/type/) للانتقال إلى Morph قبل الوصول إلى [Value](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/value/). ثم توفر القيمة واجهة [IMorphTransition](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/imorphtransition/)، التي يختار خاصية [MorphType](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/imorphtransition/morphtype/) وضع المطابقة.

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

## **تعيين تأثيرات الانتقال**

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. الخيارات المتاحة تعتمد على [Type](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/type/) الانتقال المختار. عيّن النوع أولاً، ثم استخدم الواجهة المناسبة من [Value](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/value/).

المثال التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يضبط [FromBlack](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) عبر [IOptionalBlackTransition](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/ioptionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

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

## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يفضَّل استخدام [Duration](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/duration/) عندما تحتاج إلى مدة تأثير دقيقة بالميلي ثانية. استخدم [Speed](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/slideshowtransition/speed/) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitionspeed/) مسبقة—Slow، Medium، أو Fast—كافية ولا يتم تعيين مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن الصوت المدمج إلى [Sound](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/sound/)، اضبط [SoundMode](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/soundmode/) إلى StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitionsoundmode/)، وفعل [SoundLoop](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/soundloop/). سيستمر الصوت في التكرار حتى حدث صوتي التالي في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

مرِّر عبر مجموعة [Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slides/ar/) في العرض التقديمي وعين خاصية [Type](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/type/) للانتقال في كل شريحة إلى نفس القيمة. اضبط أي خيارات توقيت وتأثير في نفس الحلقة للحفاظ على سلوك موحد عبر الشرائح.

**كيف يمكنني التحقق من الانتقال الحالي المعيّن على شريحة ما؟**

اقرأ خاصية [Type](https://reference.aspose.com/slides/ar/net/aspose.slides/islideshowtransition/type/) من [SlideShowTransition](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/slideshowtransition/) للشفرة. تُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/net/aspose.slides.slideshow/transitiontype/)؛ القيمة None تعني عدم تطبيق أي تأثير انتقال.