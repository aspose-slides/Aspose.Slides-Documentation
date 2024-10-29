---
title: تحويل PowerPoint إلى PNG في C#
linktitle: تحويل PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-png/
keywords:
- PowerPoint إلى png
- ppt إلى png
- pptx إلى png
- odp إلى png
- PowerPoint إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- ODP إلى PNG
- C#
- Csharp
- Aspose.Slides لـ .NET
description: تحويل عرض PowerPoint إلى PNG في C#. تحويل PPT إلى PNG في C#. تحويل PPTX إلى PNG في C#. تحويل ODP إلى PNG في C#
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى تنسيق PNG باستخدام C#. تغطي المواضيع التالية.

- [تحويل PowerPoint إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل PPT إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل PPTX إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل ODP إلى PNG في C#](#convert-powerpoint-to-png)
- [تحويل شريحة PowerPoint إلى صورة في C#](#convert-powerpoint-to-png)

## **C# PowerPoint إلى PNG**

للحصول على كود C# نموذج لتحويل PowerPoint إلى PNG، يرجى مراجعة القسم أدناه أي [تحويل PowerPoint إلى PNG](#convert-powerpoint-to-png). يمكن للكود تحميل عدد من التنسيقات مثل PPT وPPTX وODP في كائن Presentation ثم حفظ الصورة المصغرة للشرائح في تنسيق PNG. يتم مناقشة تحويلات PowerPoint إلى صورة الأخرى التي تشبه JPG وBMP وTIFF وSVG في هذه المقالات.

- [C# PowerPoint إلى JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint إلى TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint إلى SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (رسومات الشبكة المحمولة) ليس شائعًا مثل JPEG (مجموعة خبراء التصوير المشترك)، لكنه لا يزال شائعًا جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة والحجم ليس مشكلة، فإن PNG هو تنسيق صورة أفضل من JPEG.

{{% alert title="نصيحة" color="primary" %}} قد ترغب في الاطلاع على محولات **PowerPoint إلى PNG** المجانية من Aspose: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و[PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تنفيذ حي للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع هذه الخطوات:

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) تحت واجهة [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide). 
3. استخدم الطريقة [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) للحصول على الصورة المصغرة لكل شريحة. 
4. استخدم الطريقة [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) لحفظ الصورة المصغرة للشرائح بتنسيق PNG. 

يوضح كود C# هذا كيفية تحويل عرض PowerPoint إلى PNG. يمكن لكائن Presentation تحميل PPT وPPTX وODP وما إلى ذلك، ثم يتم تحويل كل شريحة في كائن العرض إلى تنسيق PNG أو تنسيقات الصور الأخرى.

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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، والتي تحدد أبعاد الصورة المصغرة الناتجة.

يوضح هذا الكود في C# العملية الموصوفة:

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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم المفضلة لديك لـ `width` و `height` كوسائط لـ `imageSize`.

يوضح هذا الكود كيفية تحويل PowerPoint إلى PNG مع تحديد الحجم للصور:

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