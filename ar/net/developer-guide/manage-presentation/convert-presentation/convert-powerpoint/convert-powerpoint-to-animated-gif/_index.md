---
title: تحويل PowerPoint إلى GIF متحرك
type: docs
weight: 65
url: /ar/net/convert-powerpoint-to-animated-gif/
keywords: "تحويل PowerPoint, PPT, PPTX, GIF متحرك, PPT إلى GIF متحرك, PPTX إلى GIF متحرك C#, Csharp, .NET, الإعدادات الافتراضية, الإعدادات المخصصة"
description: "تحويل عرض PowerPoint إلى GIF متحرك: PPT إلى GIF, PPTX إلى GIF باستخدام C# أو .NET"
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض لك هذا المثال البرمجي بلغة C# كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية.

{{%  alert  title="TIP"  color="primary"  %}} 

إذا كنت تفضل تخصيص المعلمات الخاصة بـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). راجع المثال البرمجي أدناه. 

{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

يعرض لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة بلغة C#:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // حجم الـ GIF الناتج  
        DefaultDelay = 2000, // المدة التي ستظهر فيها كل شريحة قبل الانتقال إلى التالية
        TransitionFps = 35 // زيادة عدد الإطارات في الثانية لتحسين جودة انتقال الرسوم المتحركة
    });
}
```


{{% alert title="Info" color="info" %}}

قد ترغب في تجربة محول مجاني إلى GIF من النصوص [Text to GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره من قبل Aspose. 

{{% /alert %}}

## **الأسئلة الشائعة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [configure fallback fonts](/slides/ar/net/powerpoint-fonts/). سيقوم Aspose.Slides باستبدالها، لكن قد يختلف المظهر. بالنسبة للعلامة التجارية، تأكد دائمًا من توفر الخطوط المطلوبة صراحة.

**هل يمكنني إضافة علامة مائية فوق إطارات GIF؟**

نعم. [Add a semi-transparent object/logo](/slides/ar/net/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.