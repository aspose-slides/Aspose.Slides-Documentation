---
title: "تحويل PowerPoint إلى PNG باستخدام C#"
linktitle: "تحويل PowerPoint إلى PNG"
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-png/
keywords:
- "PowerPoint إلى PNG"
- "ppt إلى PNG"
- "pptx إلى PNG"
- "odp إلى PNG"
- "PowerPoint إلى PNG"
- "PPT إلى PNG"
- "PPTX إلى PNG"
- "ODP إلى PNG"
- "C#"
- "Csharp"
- "Aspose.Slides لـ .NET"
description: "تحويل عرض PowerPoint إلى PNG باستخدام C#. تحويل PPT إلى PNG باستخدام C#. تحويل PPTX إلى PNG باستخدام C#. تحويل ODP إلى PNG باستخدام C#"
---

## **نظرة عامة**

هذا المقال يشرح كيفية تحويل عرض PowerPoint إلى تنسيق PNG باستخدام C#. يغطي المواضيع التالية.

- [تحويل PowerPoint إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل PPT إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل PPTX إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل ODP إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل شريحة PowerPoint إلى صورة في C#](#convert-powerpoint-to-png)

## **PowerPoint إلى PNG باستخدام C#**

للحصول على عينة كود C# لتحويل PowerPoint إلى PNG، يرجى مراجعة القسم أدناه أي [تحويل PowerPoint إلى PNG](#convert-powerpoint-to-png). يمكن للكود تحميل عدد من الصيغ مثل PPT و PPTX و ODP في كائن Presentation ثم حفظ صورة المصغرة للشرائح بتنسيق PNG. التحويلات الأخرى من PowerPoint إلى صور مثل JPG و BMP و TIFF و SVG موضحة في هذه المقالات.

- [C# PowerPoint إلى JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint إلى SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا كما هو JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا.

**حالة الاستخدام:** عندما تكون الصورة معقدة ولا تشكل الحجم مشكلة، يكون PNG أفضل من JPEG.

{{% alert title="Tip" color="primary" %}} قد ترغب في تجربة محولات Aspose المجانية **PowerPoint to PNG Converters**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). هي تنفيذ حي للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على كائن الشريحة من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) تحت واجهة [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. استخدام طريقة [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) للحصول على الصورة المصغرة لكل شريحة.
4. استخدام طريقة [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) لحفظ الصورة المصغرة للشفرة بصيغة PNG.

يعرض هذا الكود C# كيفية تحويل عرض PowerPoint إلى PNG. يمكن لكائن Presentation تحميل PPT و PPTX و ODP وغيرها، ثم يتم تحويل كل شريحة في الكائن إلى صيغة PNG أو صيغ صور أخرى.
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

إذا رغبت في الحصول على ملفات PNG بأبعاد معينة، يمكنك ضبط القيم `desiredX` و `desiredY` التي تحدد أبعاد الصورة المصغرة الناتجة.

هذا الكود في C# يوضح العملية المذكورة:
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

إذا رغبت في الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم `width` و `height` المفضلة لـ `imageSize`.

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

**كيف يمكنني تصدير شكل محدد فقط (مثل مخطط أو صورة) بدلاً من الشريحة بأكملها؟**

Aspose.Slides يدعم [إنشاء صور مصغرة لأشكال فردية](/slides/ar/net/create-shape-thumbnails/); يمكنك تصيير الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم، ولكن [لا تشارك](/slides/ar/net/multithreading/) كائن Presentation واحد عبر الخيوط. استخدم كائنًا منفصلًا لكل خيط أو عملية.

**ما هي قيود نسخة التجربة عند التصدير إلى PNG؟**

وضع التقييم يضيف علامة مائية إلى الصور الناتجة ويطبق [قيود أخرى](/slides/ar/net/licensing/) حتى يتم تطبيق الترخيص.