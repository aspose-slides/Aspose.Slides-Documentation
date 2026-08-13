---
title: تحويل عروض PowerPoint التقديمية إلى ملفات GIF متحركة في .NET
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
description: "قم بتحويل عروض PowerPoint التقديمية (PPT، PPTX) إلى ملفات GIF متحركة بسهولة باستخدام Aspose.Slides للـ .NET. نتائج سريعة وعالية الجودة."
---
## **نظرة عامة**

تتيح لك Aspose.Slides تحويل عروض PowerPoint إلى ملفات GIF متحركة ببضع أسطر من الشيفرة فقط. هذا مفيد عندما تحتاج إلى مشاركة محتوى الشرائح بتنسيق متحرك خفيف الوزن ويدعم على نطاق واسع يمكن تضمينه في صفحات الويب أو المراسلات أو الوثائق. يشرح هذا المقال كيفية تصدير عرض تقديمي إلى GIF باستخدام الإعدادات الافتراضية وكيفية تخصيص الناتج عن طريق تكوين خيارات مثل حجم الإطار، تأخير الشريحة، ومعدل إطار الانتقال من خلال [GifOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/gifoptions/).

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

هذا المثال البرمجي بلغة C# يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

سيتم إنشاء ملف GIF المتحرك باستخدام المعلمات الافتراضية. 

{{%  alert  title="TIP"  color="info"  %}} 
إذا كنت تفضل تخصيص معلمات GIF، يمكنك استخدام فئة [GifOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/gifoptions). راجع الشيفرة النموذجية أدناه. 
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

هذا المثال البرمجي يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في C#:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // حجم ملف GIF الناتج
        DefaultDelay = 2000, // المدة التي ستظهر فيها كل شريحة قبل أن يتم الانتقال إلى التالية
        TransitionFps = 35 // زيادة FPS لتحسين جودة انتقال الرسوم المتحركة
    });
}
```

{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محول مجاني من النص إلى GIF تم تطويره بواسطة Aspose. يمكنك زيارة [Text to GIF](https://products.aspose.app/slides/ar/text-to-gif). 
{{% /alert %}}

## **الأسئلة المتكررة**

### ماذا لو كانت الخطوط المستخدمة في العرض التقديمي غير مثبتة على النظام؟

قم بتثبيت الخطوط المفقودة أو [configure fallback fonts](/slides/ar/net/powerpoint-fonts/). ستقوم Aspose.Slides بالاستبدال، لكن قد يختلف المظهر. بالنسبة للعلامة التجارية، تأكد دائمًا من توفر الأنماط المطلوبة صراحةً.

### هل يمكنني إضافة علامة مائية على إطارات GIF؟

نعم. يمكنك [Add a semi-transparent object/logo](/slides/ar/net/watermark/) إلى الشريحة الأم أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.