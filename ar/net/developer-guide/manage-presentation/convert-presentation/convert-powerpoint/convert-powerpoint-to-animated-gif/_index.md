---
title: تحويل عروض PowerPoint إلى GIF متحركة في .NET
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/net/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى GIF
- عرض تقديمي إلى GIF
- شريحة إلى GIF
- PPT إلى GIF
- PPTX إلى GIF
- حفظ PPT كـ GIF
- حفظ PPTX كـ GIF
- تصدير PPT كـ GIF
- تصدير PPTX كـ GIF
- الإعدادات الافتراضية
- الإعدادات المخصصة
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint (PPT, PPTX) بسهولة إلى GIFs متحركة باستخدام Aspose.Slides لـ .NET. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

هذا المثال في C# يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية. 

{{%  alert  title="TIP"  color="primary"  %}} 
إذا كنت تفضل تخصيص معلمات GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). راجع المثال البرمجي أدناه. 
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة**

هذا المثال يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في C#:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // حجم GIF الناتج
        DefaultDelay = 2000, // المدة التي سيُعرض فيها كل شريحة حتى يتم الانتقال إلى الشريحة التالية
        TransitionFps = 35 // زيادة FPS لتحسين جودة انتقال الرسوم المتحركة
    });
}
```


{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محول مجاني [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره من قبل Aspose. 
{{% /alert %}}

## **FAQ**

**ماذا إذا لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [تكوين خطوط الاستبدال](/slides/ar/net/powerpoint-fonts/). ستستبدل Aspose.Slides الخطوط، لكن قد يختلف المظهر. لضمان تمثيل العلامة التجارية، تأكد دائمًا من توفر الخطوط المطلوبة بشكل واضح.

**هل يمكنني إضافة علامة مائية على إطارات GIF؟**

نعم. يمكنك [إضافة كائن/شعار شبه شفاف](/slides/ar/net/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.