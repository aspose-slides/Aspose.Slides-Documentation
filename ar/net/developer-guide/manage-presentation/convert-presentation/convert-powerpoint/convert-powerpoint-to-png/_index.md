---
title: تحويل شرائح PowerPoint إلى PNG في .NET
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint التقديمية إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides for .NET، مع ضمان نتائج دقيقة ومؤتمتة."
---

## **نظرة عامة**

يفسر هذا المقال كيفية تحويل عرض PowerPoint إلى صيغة PNG باستخدام C#. يغطي المواضيع التالية.

- [تحويل PowerPoint إلى PNG باستخدام C#](#convert-powerpoint-to-png)
- [تحويل PPT إلى PNG باستخدام C#](#convert-powerpoint-to-png)
- [تحويل PPTX إلى PNG باستخدام C#](#convert-powerpoint-to-png)
- [تحويل ODP إلى PNG باستخدام C#](#convert-powerpoint-to-png)
- [تحويل شريحة PowerPoint إلى صورة باستخدام C#](#convert-powerpoint-to-png)

## **PowerPoint إلى PNG باستخدام C#**

للحصول على مثال كود C# لتحويل PowerPoint إلى PNG، يرجى الاطلاع على القسم أدناه أي [تحويل PowerPoint إلى PNG](#convert-powerpoint-to-png). يمكن للشفرة تحميل عدة تنسيقات مثل PPT وPPTX وODP في كائن Presentation ثم حفظ صورة المصغرة للشريحة بصيغة PNG. التحويلات الأخرى من PowerPoint إلى صور مثل JPG وBMP وTIFF وSVG تم مناقشتها في هذه المقالات.

- [C# PowerPoint إلى JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint إلى SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا مثل JPEG (Joint Photographic Experts Group)، لكنه لا يزال واسع الانتشار.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا تمثل حجمها مشكلة، يكون PNG تنسيقًا أفضل من JPEG.

{{% alert title="Tip" color="primary" %}} قد ترغب في تجربة أدوات Aspose المجانية **لتحويل PowerPoint إلى PNG**: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و[PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). وهي تنفيذ حي للعملية الموصوفة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على كائن الشريحة من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) عبر واجهة [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. استخدام طريقة [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) للحصول على صورة المصغرة لكل شريحة.
4. استخدام طريقة [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) لحفظ صورة المصغرة للشفرة بصيغة PNG.

تُظهر هذه الشفرة المكتوبة بـ C# كيفية تحويل عرض PowerPoint إلى PNG. يمكن لكائن Presentation تحميل PPT أو PPTX أو ODP وغيرها، ثم تُحوَّل كل شريحة في كائن العرض إلى صيغة PNG أو صيغ صور أخرى.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

إذا كنت ترغب في الحصول على ملفات PNG بمقاس معين، يمكنك تعيين القيم للمتغيرين `desiredX` و`desiredY` لتحديد أبعاد صورة المصغرة الناتجة.

هذا الكود بـ C# يوضح العملية الموضحة:
```c#
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

إذا كنت ترغب في الحصول على ملفات PNG بحجم محدد، يمكنك تمرير القيم `width` و`height` التي تفضلها للمعامل `imageSize`.

هذا الكود يوضح كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور:
```c#
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

**كيف يمكنني تصدير شكل معين فقط (مثل مخطط أو صورة) بدلاً من الشريحة بالكامل؟**

يدعم Aspose.Slides [إنشاء صور مصغرة لأشكال فردية](/slides/ar/net/create-shape-thumbnails/); يمكنك تحويل الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم، ولكن لا يجب [مشاركة](/slides/ar/net/multithreading/) كائن Presentation واحد بين الخيوط. استخدم كائنًا منفصلًا لكل خيط أو عملية.

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية على الصور الناتجة ويفرض [قيودًا أخرى](/slides/ar/net/licensing/) حتى يتم تطبيق ترخيص.