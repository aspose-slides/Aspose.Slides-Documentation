---
title: إدارة انتقالات الشرائح في العروض التقديمية في .NET
linktitle: انتقال الشريحة
type: docs
weight: 90
url: /ar/net/slide-transition/
keywords:
- انتقال شريحة
- إضافة انتقال شريحة
- تطبيق انتقال شريحة
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
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في كيفية ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides لـ .NET، يمكنك اختيار تأثير انتقال لكل شريحة، وتكوين التقدم بالنقر بالفأرة أو المؤقت، وضبط الخيارات المحددة لتأثير معين. تستخدم هذه المقالة أمثلة C# لتطبيق الانتقالات، وتحديد مدة انتقال دقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تُظهر الأمثلة أيضًا كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) والوصول إلى خاصية [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) للشفرة. عيّن [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) إلى قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)، ثم احفظ العرض التقديمي.

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

## **انتقال Wheel**

خاصية [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) لـ [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) تتحكم في عدد القطاعات الشعاعية التي تكشف الشريحة الهدف. اضبط [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) للشفرة إلى Wheel من [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) قبل الوصول إلى [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) كـ [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

هذا المثال ينشئ زوجين متماثلين من الشرائح: شريحة سوداء تتبعها شريحة بها مستطيل ذهبي. الشرائح الهدف تستخدم عدد أسنان (spoke) 1 و 8، مع نفس [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) و[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) صريحة مقدارها 8000 مللي ثانية لجعل الفرق سهل الملاحظة.

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

افتح العرض الناتج في PowerPoint وشغّل عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2، ثم من الشريحة 3 إلى الشريحة 4. في تشغيل PowerPoint، عدد الأسنان المؤكد 1 يكشف الشريحة بفتحة واحدة مع اتجاه عقار الساعة؛ وعدد 8 يكشفها عبر ثمان قطاعات شعاعية في آن واحد. محتوى الهدف وتوقيت الانتقال متطابقان، لذا الفرق هو عدد قطاعات الكشف.

## **تلاشي عبر الأسود مع انتقال Reveal**

عيّن نوع انتقال الشريحة الهدف إلى Reveal، ثم استخدم [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) لتعيين [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/). ينشئ المثال شريحة مصدر بلون تيل وشريحة هدف بلون مرجاني، ثم ينسخ كلاهما لتتمكن من مقارنة انتقال مدته ثانيتان مع إيقاف التلاشي وتمكينه.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

في عرض شرائح PowerPoint، انتقل من الشريحة 1 إلى الشريحة 2. يتلاشى اللون التيل مباشرة إلى اللون المرجاني. ثم انتقل من الشريحة 3 إلى الشريحة 4. تصبح الشاشة مظلمة قليلاً إلى ما يقرب من الأسود قبل أن تظهر الشريحة المرجانية. تحتفظ كلتا الشريحتين بألوان الخلفية الأصلية.

تُظهر الصفوف أدناه إطارات من PowerPoint بفواصل نصف ثانية. قارن الإطار الأوسط في كل صف لرؤية تأثير الإعداد.

![تشغيل PowerPoint مع تعطيل ThroughBlack (أعلى) وتمكينه (أسفل). الصف السفلي فقط يمر عبر الأسود القريب.](reveal-through-black.png)

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالفأرة يتقدم عرض الشرائح. الخصائص التالية تتحكم في هذا السلوك:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) يسمح للمشاهد بالتقدم بالنقر على الفأرة.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) يفعّل التقدم التلقائي.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كل من النقر والتقدم بالوقت للسماح للمشاهد بالانتقال بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، عيّن [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) إلى `false`. يتحكم التأخير في وقت تقدم عرض الشرائح؛ ولا يحدد مدة تأثير الانتقال البصري.

يُعين هذا المثال تأثيرات مختلفة للشرائح الثلاث الأولى ويفعل التقدم التلقائي بعد 3 و5 و7 ثوانٍ على التوالي. يمكن للنقرات بالفأرة أيضًا تقدم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق ما إذا كان التقدم بالوقت مفعّلاً، اقرأ [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). التخزين المتأخر بمفرده لا يدل على أن المؤقت نشط.

يفتح المثال التالي الملف المحفوظ أعلاه، يُبلغ عن كل مؤقت مفعّل، ويعطّل التقدم التلقائي للشرائح التي تأخيرها أكبر من ثانيتين. يفعّل النقر بالفأرة لتلك الشرائح ويحفظ الإعدادات المحدثة.

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

## **التحكم في توقيت الانتقال بدقة**

استخدم [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. خاصية [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) للشفرة تعرض هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| الخاصية | الغرض |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | يحدد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | يحدد التأخير قبل أن تتقدم الشريحة تلقائيًا، بالمللي ثانية. فعّل [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) لتفعيل هذا المؤقت. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | يختار فئة سرعة محددة مسبقًا من [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow أو Medium أو Fast. يستخدم عندما لا تحدد مدة دقيقة. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) يتحكم فقط في تأثير الانتقال؛ ولا يحدد مدة بقاء الشريحة مرئية. قم بتهيئة تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال وقيمة [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **تطبيق نفس المدة على كل شريحة**

لتحقيق إيقاع ثابت، طبق نفس التأثير والمدة الدقيقة على كل شريحة. يحمل هذا المثال `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/)، ويمنح كل انتقال مدة 750 مللي ثانية. يفعّل بشكل منفصل التقدم التلقائي بعد 5,000 مللي ثانية ويعطل التقدم بالنقر بالفأرة، ثم يحفظ النتيجة كملف PPTX.

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

يمكن للشرائح المختلفة استخدام مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. يحدد هذا المثال 500 مللي ثانية للشريحة الأولى و1,200 مللي ثانية للشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

### **تنسيق الانتقالات مع المخرجات المتحركة**

عند إعداد [animated GIF](/slides/ar/net/convert-powerpoint-to-animated-gif/)، أو [HTML5 presentation](/slides/ar/net/export-to-html5/)، أو [video](/slides/ar/net/convert-powerpoint-to-video/)، عيّن مدد انتقال دقيقة قبل التصدير لتطابق الإيقاع المقصود. على سبيل المثال، استخدم تلاشي مدته 600 مللي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل لإتاحة الوقت للتعليق أو المحتوى.

للـ GIF والفيديو، نسق معدل الإطارات الناتج مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من التأثيرات وخيارات التوقيت المدعومة في صيغة التصدير المختارة، وقم بمعاينة الناتج لتأكيد التزامن.

### **قراءة مدة الانتقال الحالية**

اقرأ [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزنة. القيمة `-1` تعني عدم تحديد مدة صريحة؛ القيمة غير السالبة تحدد المدة المخزنة بالمللي ثانية. القيمة غير المحددة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال و[Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) لتحديد تلك المدة. تعيين نوع الانتقال يمكن أن يهيئ مدة، لذا تحقق من الإعدادات الأصلية أولًا.

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

ينقل انتقال Morph التغييرات بين الكائنات على الشرائح المتتابعة. لإنشاء تأثير Morph بسيط، انسخ شريحة، حرّك أو غير حجم كائن على النسخة، وطبق انتقال Morph على الشريحة الثانية. يمنح ذلك الانتقال الكائنات المقابلة لتتحرك بين حالتها الأصلية والمعدلة.

ينشئ المثال التالي شريحة بها مستطيل نص، ينسخ الشريحة، ويغيّر موضع وحجم المستطيل على النسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لرؤية التأثير أثناء عرض الشرائح.

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

تعداد [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) يتحكم في كيفية مطابقة وتحريك المحتوى:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الأحرف حيثما أمكن.

عيّن [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) للانتقال إلى Morph قبل الوصول إلى [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). ثم توفر القيمة واجهة [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/)، التي يختار خاصية [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) وضع المطابقة.

يفتح هذا المثال العرض التقديمي الذي أنشئ في القسم السابق ويضبط الشريحة الثانية لاستخدام حركة Morph بناءً على الكلمات.

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
[![وحدات مطابقة Morph معروضة كشكل كامل، كلمات فردية، وحروف فردية.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*يمكن لـ Morph مطابقة الأشكال الكاملة أو الكلمات أو الأحرف حيثما أمكن. هذه الصناديق تحدد وحدات المطابقة بدلاً من الحركة المرصودة. يختار المثال ByWord في الشريحة الثانية.*
<!-- visual-explanation:slide-transition:end -->

## **تعيين تأثيرات الانتقال**

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. الخيارات المتاحة تعتمد على [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) للانتقال المختار. عيّن النوع أولاً، ثم استخدم الواجهة المناسبة من [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

ينفذ المثال التالي انتقال Cut على الشريحة الأولى من `input.pptx`. يعيّن [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) عبر [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) بحيث يبدأ الانتقال من شاشة سوداء.

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

## **الأسئلة الشائعة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يفضَّل استخدام [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) عندما تحتاج إلى مدة تأكيدية للتأثير بالمللي ثانية. استخدم [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) محددة مسبقًا—Slow أو Medium أو Fast—كافية ولا توجد مدة صريحة محددة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمّنًا إلى [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/)، اضبط [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) إلى StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/)، وفعل [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). يتكرر الصوت حتى حدث صوتي التالي في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بالتكرار عبر مجموعة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) في العرض وعيّن [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) للانتقال لكل شريحة إلى نفس القيمة. عيّن أي خيارات توقيت وتأثير داخل نفس الحلقة للحفاظ على سلوك متسق عبر الشرائح.

**كيف يمكنني التحقق من الانتقال المُعيّن حاليًا على شريحة؟**

اقرأ خاصية [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) من [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/). تُرجع قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/); القيمة None تعني عدم تطبيق أي تأثير انتقال.