---
title: تحويل عروض PowerPoint التقديمية إلى GIF متحركة في .NET
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/net/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى GIF
- العرض التقديمي إلى GIF
- الشريحة إلى GIF
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
description: "قم بتحويل عروض PowerPoint (PPT, PPTX) بسهولة إلى GIF متحركة باستخدام Aspose.Slides لـ .NET. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

هذا المثال البرمجي بلغة C# يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية.

{{%  alert  title="TIP"  color="primary"  %}} 
إذا كنت تفضل تخصيص معلمات GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). راجع الكود النموذجي أدناه. 
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

هذا المثال البرمجي يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة بلغة C#:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // حجم GIF الناتج  
        DefaultDelay = 2000, // المدة التي ستُعرض فيها كل شريحة حتى يتم تغييرها إلى التالية
        TransitionFps = 35 // زيادة FPS لتحسين جودة انتقال الرسوم المتحركة
    });
}
```


{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محول مجاني من [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره من قبل Aspose. 
{{% /alert %}}

## **الأسئلة المتكررة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [تكوين الخطوط الاحتياطية](/slides/ar/net/powerpoint-fonts/). سيقوم Aspose.Slides باستبدالها، لكن قد يختلف الشكل. بالنسبة للهوية البصرية، تأكد دائمًا من توفر الخطوط المطلوبة بشكل صريح.

**هل يمكنني وضع علامة مائية على إطارات الـ GIF؟**

نعم. [إضافة كائن/شعار شبه شفاف](/slides/ar/net/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.