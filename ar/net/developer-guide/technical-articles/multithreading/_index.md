---
title: البرمجة المتعددة الخيوط في Aspose.Slides
type: docs
weight: 310
url: /ar/net/multithreading/
keywords:
- PowerPoint
- عرض تقديمي
- البرمجة المتعددة الخيوط
- العمل المتوازي
- تحويل الشرائح
- الشرائح إلى صور
- C#
- .NET
- Aspose.Slides for .NET
---

## **مقدمة**

بينما العمل المتوازي مع العروض التقديمية ممكن (بجانب التحليل/التحميل/النسخ)، ويجري كل شيء بشكل جيد (معظم الأوقات)، هناك فرصة صغيرة أنك قد تحصل على نتائج غير صحيحة عند استخدام المكتبة في خيوط متعددة.

نوصي بشدة بعدم استخدام نسخة واحدة من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) في بيئة متعددة الخيوط لأنها قد تؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس آمناً تحميل أو حفظ أو/و نسخ نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) في خيوط متعددة. مثل هذه العمليات **غير** مدعومة. إذا كنت بحاجة لأداء مثل هذه المهام، عليك أن تنظم العمليات بالتوازي باستخدام عدة عمليات ذات خيط واحد—ويجب أن تستخدم كل من هذه العمليات نسختها الخاصة من العرض التقديمي.

## **تحويل شرائح العرض التقديمي إلى صور بشكل متوازي**

 لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. بما أنه غير آمن استخدام نسخة واحدة من `Presentation` في خيوط متعددة، نقوم بتقسيم شرائح العرض التقديمي إلى عروض تقديمية منفصلة ونحول الشرائح إلى صور بشكل متوازي، باستخدام كل عرض تقديمي في خيط منفصل. يوضح المثال البرمجي التالي كيفية القيام بذلك.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // استخراج الشريحة i إلى عرض تقديمي منفصل.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // تحويل الشريحة إلى صورة في مهمة منفصلة.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```