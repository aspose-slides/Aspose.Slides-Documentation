---
title: تحويل عروض باوربوينت إلى صور GIF متحركة في .NET
linktitle: باوربوينت إلى GIF
type: docs
weight: 65
url: /ar/net/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل باوربوينت
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- باوربوينت إلى GIF
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
description: "تحويل عروض باوربوينت (PPT، PPTX) إلى صور GIF متحركة بسهولة باستخدام Aspose.Slides لـ .NET. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى صورة GIF متحركة باستخدام الإعدادات الافتراضية**

يعرض لك هذا المثال البرمجي بلغة C# كيفية تحويل عرض تقديمي إلى صورة GIF متحركة باستخدام الإعدادات القياسية:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


سيتم إنشاء صورة GIF المتحركة باستخدام المعلمات الافتراضية.

{{%  alert  title="TIP"  color="primary"  %}} 
إذا كنت تفضل تخصيص معلمات GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). راجع المثال البرمجي أدناه. 
{{% /alert %}} 

## **تحويل العروض التقديمية إلى صورة GIF متحركة باستخدام الإعدادات المخصصة**

يعرض لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى صورة GIF متحركة باستخدام الإعدادات المخصصة في C#:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // حجم GIF الناتج
        DefaultDelay = 2000, // مدة عرض كل شريحة قبل الانتقال إلى التالية
        TransitionFps = 35 // زيادة عدد الإطارات في الثانية لتحسين جودة حركة الانتقال
    });
}
```


{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محول مجاني من النص إلى GIF [Text to GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره بواسطة Aspose. 
{{% /alert %}}

## **الأسئلة الشائعة**

**ماذا لو لم يتم تثبيت الخطوط المستخدمة في العرض التقديمي على النظام؟**
قم بتثبيت الخطوط المفقودة أو [configure fallback fonts](/slides/ar/net/powerpoint-fonts/). سيقوم Aspose.Slides بالاستبدال، لكن قد يختلف المظهر. لضمان العلامة التجارية، تأكد دائمًا من توفر الخطوط المطلوبة صراحة.

**هل يمكنني إضافة علامة مائية فوق إطارات GIF؟**
نعم. [Add a semi-transparent object/logo](/slides/ar/net/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.