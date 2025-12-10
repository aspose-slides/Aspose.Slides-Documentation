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
- حفظ PPT ك PNG
- حفظ PPTX ك PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint التقديمية إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides لـ .NET، مما يضمن نتائج دقيقة ومؤتمتة."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض تقديمي PowerPoint إلى صيغة PNG باستخدام C#. تغطي المواضيع التالية.

- [تحويل PowerPoint إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل PPT إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل PPTX إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل ODP إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل شريحة PowerPoint إلى صورة في C#](#convert-powerpoint-to-png)

## **PowerPoint إلى PNG في .NET**

للحصول على عينة كود C# لتحويل PowerPoint إلى PNG، يرجى مراجعة القسم أدناه أي [Convert PowerPoint to PNG](#convert-powerpoint-to-png). يمكن للكود تحميل عدد من الصيغ مثل PPT وPPTX وODP في كائن Presentation ثم حفظ صورة مصغرة للشريحة بصيغة PNG. التحويلات الأخرى من PowerPoint إلى صور مثل JPG وBMP وTIFF وSVG يتم مناقشتها في هذه المقالات.

- [C# PowerPoint إلى JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint إلى SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **حول تحويل PowerPoint إلى PNG**

صيغة PNG (Portable Network Graphics) ليست شائعة مثل JPEG (Joint Photographic Experts Group)، لكنها لا تزال شائعة جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا يعتبر الحجم مشكلة، فإن PNG يعتبر تنسيق صورة أفضل من JPEG.

{{% alert title="Tip" color="primary" %}} قد ترغب في إلقاء نظرة على محولات Aspose المجانية **PowerPoint إلى PNG**: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و[PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). هذه هي تطبيق مباشر للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) تحت واجهة [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. استخدم طريقة [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم طريقة [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) لحفظ الصورة المصغرة للشريحة بصيغة PNG.

يعرض هذا الكود C# كيفية تحويل عرض تقديمي PowerPoint إلى PNG. يمكن لكائن Presentation تحميل PPT وPPTX وODP وغيرها، ثم يتم تحويل كل شريحة في كائن العرض إلى صيغة PNG أو صيغ صور أخرى.
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

إذا كنت تريد الحصول على ملفات PNG بأبعاد معينة، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، والتي تحدد أبعاد الصورة المصغرة الناتجة.

هذا الكود في C# يوضح العملية الموصوفة:
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

إذا كنت ترغب في الحصول على ملفات PNG بحجم محدد، يمكنك تمرير قيم `width` و `height` المفضلة لك إلى المتغير `imageSize`.

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


## **الأسئلة الشائعة**

**كيف يمكنني تصدير شكل محدد فقط (مثل مخطط أو صورة) بدلاً من كامل الشريحة؟**  
يدعم Aspose.Slides [إنشاء صور مصغرة لأشكال منفردة](/slides/ar/net/create-shape-thumbnails/); يمكنك تحويل الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**  
نعم، ولكن لا يجب [مشاركة](/slides/ar/net/multithreading/) كائن Presentation واحد عبر الخيوط. استخدم كائنًا منفصلًا لكل خيط أو عملية.

**ما هي قيود نسخة التجربة عند التصدير إلى PNG؟**  
يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويطبق [قيودًا أخرى](/slides/ar/net/licensing/) حتى يتم تطبيق ترخيص.