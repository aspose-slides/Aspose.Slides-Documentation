---
title: تحويل شرائح PowerPoint إلى PNG في .NET
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT بصيغة PNG
- حفظ PPTX بصيغة PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- .NET
- C#
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides لـ .NET، مما يضمن نتائج دقيقة وآلية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى صور PNG باستخدام Aspose.Slides. توضح كيفية تحميل ملفات العرض بأكثر من تنسيق مثل PPT و PPTX و ODP، وتحويل الشرائح إلى صور، وحفظ النتائج بتنسيق PNG.

كما تُظهر المقالة كيفية تخصيص صور PNG المُنشأة عن طريق ضبط قيم المقياس أو تحديد العرض والارتفاع المطلوبين.

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) .
2. الحصول على كائن الشريحة من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/properties/slides) تحت واجهة [ISlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide) .
3. استخدام طريقة [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/) لتصيير كل شريحة بالمقياس المطلوب.
4. استخدام طريقة [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.ipresentation/save/methods/5) لحفظ صورة مصغرة للشريحة بتنسيق PNG.

يُظهر هذا الكود C# كيفية تحويل عرض PowerPoint إلى PNG. يمكن لكائن Presentation تحميل ملفات PPT أو PPTX أو ODP وغيرها، ثم تُحوَّل كل شريحة داخل كائن العرض إلى تنسيق PNG أو أي تنسيق صور آخر.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**ملاحظة:** تُعيد معاملات المقياس `1f, 1f` تصيير كل شريحة بحجمها الكامل، لذا فإن شريحة بحجم 720×540 pt تُنتج صورة بحجم 720×540 بكسل. تُعيد الدالة [GetImage()](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/) بدون معاملات نسخة مصغرة مصغرة أصغر بكثير. 
{{% /alert %}} 

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

إذا كنت تريد الحصول على ملفات PNG بمقياس معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، والتي تحدد أبعاد الصورة المصغرة الناتجة. 

يُظهر هذا الكود بلغة C# العملية الموضحة:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم المفضلة لـ `width` و `height` كوسيطة لـ `imageSize`. 

يُظهر هذا الكود كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **الأسئلة المتكررة**

### كيف يمكنني تصدير شكل معين فقط (مثل مخطط أو صورة) بدلاً من الشريحة بأكملها؟

يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/net/create-shape-thumbnails/); يمكنك تصيير الشكل إلى صورة PNG.

### هل يدعم التحويل المتوازي على الخادم؟

نعم، ولكن لا يجب [مشاركة](/slides/ar/net/multithreading/) كائن Presentation واحد عبر الخيوط. استخدم كائنًا منفصلًا لكل خيط أو عملية.

### ما هي قيود نسخة التجربة عند التصدير إلى PNG؟

يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويفرض [قيودًا أخرى](/slides/ar/net/licensing/) حتى يتم تطبيق ترخيص.