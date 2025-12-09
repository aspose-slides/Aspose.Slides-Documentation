---
title: "العمل المتعدد الخيوط في Aspose.Slides للـ .NET"
linktitle: "العمل المتعدد الخيوط"
type: docs
weight: 310
url: /ar/net/multithreading/
keywords:
- "العمل المتعدد الخيوط"
- "عدة خيوط"
- "عمل متوازي"
- "تحويل الشرائح"
- "شرائح إلى صور"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "يدعم العمل المتعدد الخيوط في Aspose.Slides للـ .NET معالجة PowerPoint و OpenDocument بشكل أسرع. اكتشف أفضل الممارسات لإنشاء تدفقات عمل فعّالة للعرض التقديمي."
---

## **المقدمة**

في حين أن العمل المتوازي مع العروض التقديمية ممكن (إلى جانب التحليل/التحميل/الاستنساخ) وتعمل الأمور بشكل جيد في معظم الأحيان، هناك احتمال صغير قد تحصل فيه على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة بعدم استخدام كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) واحد في بيئة متعددة الخيوط لأنه قد ينتج عنه أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو/أو استنساخ كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) في عدة خيوط. هذه العمليات غير مدعومة. إذا كنت بحاجة إلى أداء هذه المهام، عليك تنفيذها بشكل متوازي باستخدام عدة عمليات أحادية الخيط—ويجب على كل عملية منها أن تستخدم نسخة العرض التقديمي الخاصة بها.

## **تحويل شرائح العرض التقديمي إلى صور بشكل متوازي**

لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. لأن استخدام كائن `Presentation` واحد في عدة خيوط غير آمن، نقسم شرائح العرض إلى عروض تقديمية منفصلة ونحوِّل الشرائح إلى صور في متوازٍ، باستخدام كل عرض في خيط منفصل. مثال الشيفرة التالي يوضح كيفية القيام بذلك.
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


## **الأسئلة الشائعة**

**هل أحتاج إلى استدعاء إعداد الترخيص في كل خيط؟**

لا. يكفي القيام بذلك مرة واحدة لكل عملية/نطاق تطبيق قبل بدء الخيوط. إذا كان قد يتم استدعاء [إعداد الترخيص](/slides/ar/net/licensing/) بصورة متزامنة (على سبيل المثال، أثناء التهيئة المتأخرة)، قم بمزامنة هذا الاستدعاء لأن طريقة إعداد الترخيص نفسها غير آمنة للخيوط.

**هل يمكنني تمرير كائنات `Presentation` أو `Slide` بين الخيوط؟**

تمرير كائنات العرض "الحية" بين الخيوط غير مفضَّل: استخدم نسخ مستقلة لكل خيط أو أنشئ مسبقًا عروض تقديمية/حاويات شرائح منفصلة لكل خيط. يتبع هذا النهج التوصية العامة بعدم مشاركة نسخة عرض تقديمي واحدة عبر الخيوط.

**هل من الآمن تنفيذ تصدير متوازي إلى صيغ مختلفة (PDF, HTML, images) بشرط أن يكون لكل خيط نسخة `Presentation` خاصة به؟**

نعم. مع نسخ مستقلة ومسارات إخراج منفصلة، عادةً ما تتم هذه المهام بشكل متوازي الصحيح؛ تجنَّب أي مشاركة لكائنات العرض أو تدفقات الإدخال/الإخراج المشتركة.

**ماذا أفعل بإعدادات الخطوط العامة (المجلدات، البدائل) في بيئة متعددة الخيوط؟**

قم بتهيئة جميع إعدادات الخطوط العامة قبل بدء الخيوط ولا تقم بتغييرها أثناء العمل المتوازي. هذا يُزيل حالات التنافس عند الوصول إلى موارد الخطوط المشتركة.