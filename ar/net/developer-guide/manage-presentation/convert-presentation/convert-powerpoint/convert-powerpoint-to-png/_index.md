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
description: "تحويل عروض PowerPoint إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides لـ .NET، مع ضمان نتائج دقيقة ومؤتمتة."
---

## **نظرة عامة**

هذه المقالة توضح كيفية تحويل عرض PowerPoint إلى صيغة PNG باستخدام C#. تغطي المواضيع التالية.

- [تحويل PowerPoint إلى PNG باستخدام C#](#convert-powerpoint-to-png)
- [تحويل PPT إلى PNG باستخدام C#](#convert-powerpoint-to-png)
- [تحويل PPTX إلى PNG باستخدام C#](#convert-powerpoint-to-png)
- [تحويل ODP إلى PNG باستخدام C#](#convert-powerpoint-to-png)
- [تحويل شريحة PowerPoint إلى صورة باستخدام C#](#convert-powerpoint-to-png)

## **PowerPoint إلى PNG باستخدام C#**

للحصول على كود عينة C# لتحويل PowerPoint إلى PNG، يرجى مراجعة القسم أدناه أي [تحويل PowerPoint إلى PNG](#convert-powerpoint-to-png). يمكن للكود تحميل عدد من الصيغ مثل PPT و PPTX و ODP في كائن Presentation ثم حفظ صورة مصغرة للشريحة بصيغة PNG. التحويلات الأخرى من PowerPoint إلى صور مثل JPG و BMP و TIFF و SVG مُناقشة في هذه المقالات.

- [PowerPoint إلى JPG باستخدام C#](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [PowerPoint إلى BMP باستخدام C#](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [PowerPoint إلى TIFF باستخدام C#](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [PowerPoint إلى SVG باستخدام C#](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **حول تحويل PowerPoint إلى PNG**

صيغة PNG (Portable Network Graphics) ليست شائعة كما JPEG (Joint Photographic Experts Group)، لكنها لا تزال شائعة جداً.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا تكون حجمها مشكلة، تكون PNG صيغة صورة أفضل من JPEG.

{{% alert title="Tip" color="primary" %}} قد ترغب في تجربة أدوات Aspose المجانية **لتحويل PowerPoint إلى PNG**: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). هي تنفيذ حي للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على كائن الشريحة من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) عبر الواجهة [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. استخدم طريقة [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم طريقة [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) لحفظ الصورة المصغرة بصيغة PNG.

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PNG. يمكن لكائن Presentation تحميل PPT و PPTX و ODP وغيرها، ثم يتم تحويل كل شريحة في كائن العرض إلى صيغة PNG أو صيغ صور أخرى.
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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY` التي تحدد أبعاد الصورة المصغرة الناتجة.

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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك تمرير قيم `width` و `height` المفضلة إلى المتغير `imageSize`.

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

**كيف يمكنني تصدير شكل محدد فقط (مثل مخطط أو صورة) بدلاً من الشريحة كاملة؟**

تدعم Aspose.Slides [إنشاء صور مصغرة لأشكال فردية](/slides/ar/net/create-shape-thumbnails/); يمكنك استخراج الشكل كصورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم، لكن لا يجب [مشاركة](/slides/ar/net/multithreading/) كائن Presentation واحد عبر خيوط متعددة. استخدم كائنًا منفصلاً لكل خيط أو عملية.

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**

وضع التقييم يضيف علامة مائية إلى الصور الناتجة ويطبق [قيودًا أخرى](/slides/ar/net/licensing/) حتى يتم تطبيق ترخيص.