---
title: البرمجة المتعددة الخيوط في Aspose.Slides
type: docs
weight: 310
url: /ar/net/multithreading/
keywords:
- PowerPoint
- عرض تقديمي
- البرمجة المتعددة الخيوط
- عمل متوازي
- تحويل الشرائح
- شرائح إلى صور
- C#
- .NET
- Aspose.Slides لـ .NET
---

## **Introduction**

في حين أن العمل المتوازي مع العروض التقديمية ممكن (بخلاف التحليل/التحميل/الاستنساخ) وعادةً ما يسير كل شيء على ما يرام (في معظم الأوقات)، إلا أن هناك احتمالًا صغيرًا للحصول على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة بعدم استخدام نسخة واحدة من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) في بيئة متعددة الخيوط لأنه قد يؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو/أو استنساخ نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) في عدة خيوط. هذه العمليات غير مدعومة. إذا كنت بحاجة إلى تنفيذ مثل هذه المهام، عليك تنفيذها بالتوازي باستخدام عدة عمليات أحادية الخيط—ويجب على كل عملية أن تستخدم نسخة عرض تقديمي خاصة بها.

## **Convert Presentation Slides to Images in Parallel**

لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بالتوازي. بما أنه غير آمن استخدام نسخة واحدة من `Presentation` في عدة خيوط، نقسم شرائح العرض إلى عروض تقديمية منفصلة ونحول الشرائح إلى صور بالتوازي، باستخدام كل عرض تقديمي في خيط منفصل. يظهر مثال الكود التالي كيفية القيام بذلك.
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
    // استخراج الشريحة i في عرض تقديمي منفصل.
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


## **FAQ**

**Do I need to call license setup in every thread?**

No. It’s enough to do it once per process/app domain before threads start. If [إعداد الترخيص](/slides/ar/net/licensing/) might be invoked concurrently (for example, during lazy initialization), synchronize that call because the license setup method itself is not thread‑safe.

**Can I pass `Presentation` or `Slide` objects between threads?**

Passing "live" presentation objects between threads is not recommended: use independent instances per thread or precreate separate presentations/slide containers for each thread. This approach follows the general recommendation not to share a single presentation instance across threads.

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own `Presentation` instance?**

Yes. With independent instances and separate output paths, such tasks typically parallelize correctly; avoid any shared presentation objects and shared I/O streams.

**What should I do with global font settings (folders, substitutions) in multithreading?**

Initialize all global font settings before starting the threads and do not change them during parallel work. This eliminates races when accessing shared font resources.