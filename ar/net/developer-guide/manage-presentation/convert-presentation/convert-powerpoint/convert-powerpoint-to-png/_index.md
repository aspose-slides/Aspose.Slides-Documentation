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
description: "تحويل عروض PowerPoint إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides لـ .NET، مما يضمن نتائج دقيقة ومؤتمتة."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق PNG باستخدام C#. وتغطي المواضيع التالية.

- [تحويل PowerPoint إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل PPT إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل PPTX إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل ODP إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل شريحة PowerPoint إلى صورة في C#](#convert-powerpoint-to-png)

## **C# PowerPoint إلى PNG**

للحصول على عينة كود C# لتحويل PowerPoint إلى PNG، يرجى مراجعة القسم أدناه أي [تحويل PowerPoint إلى PNG](#convert-powerpoint-to-png). يمكن للكود تحميل عدد من الصيغ مثل PPT و PPTX و ODP في كائن Presentation ثم حفظ صورة المصغرة للشريحة بتنسيق PNG. التحويلات الأخرى من PowerPoint إلى صورة والتي تشبهها مثل JPG و BMP و TIFF و SVG تم مناقشتها في هذه المقالات.

- [C# PowerPoint إلى JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint إلى SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا مثل JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة والحجم ليس مشكلة، يكون PNG تنسيق صورة أفضل من JPEG.

{{% alert title="Tip" color="primary" %}} قد ترغب في الاطلاع على محولات Aspose المجانية **PowerPoint إلى PNG**: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). هم تنفيذ حي للعملية الموصوفة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على كائن الشريحة من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) تحت الواجهة [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. استخدام الطريقة [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) للحصول على صورة مصغرة لكل شريحة.
4. استخدام الطريقة [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) لحفظ صورة المصغرة للشريحة بتنسيق PNG.

يظهر لك هذا الكود بلغة C# كيفية تحويل عرض PowerPoint إلى PNG. يمكن لكائن Presentation تحميل PPT و PPTX و ODP وغيرها، ثم يتم تحويل كل شريحة في كائن العرض إلى تنسيق PNG أو تنسيقات صور أخرى.
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

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك ضبط القيم `desiredX` و `desiredY` التي تحدد أبعاد الصورة المصغرة الناتجة.

هذا الكود بلغة C# يوضح العملية الموصوفة:
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

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك تمرير قيم `width` و `height` المفضلة لديك إلى `imageSize`.

هذا الكود يوضح لك كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور:
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
يدعم Aspose.Slides [إنشاء صور مصغرة لأشكال فردية](/slides/ar/net/create-shape-thumbnails/); يمكنك تحويل الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**  
نعم، لكن [لا تشارك](/slides/ar/net/multithreading/) مثال Presentation واحد عبر الخيوط. استخدم مثالًا منفصلًا لكل خيط أو عملية.

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**  
يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويفرض [قيودًا أخرى](/slides/ar/net/licensing/) حتى يتم تطبيق ترخيص.