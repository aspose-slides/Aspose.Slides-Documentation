---
title: تحويل PowerPoint إلى GIF متحرك
type: docs
weight: 65
url: /ar/net/convert-powerpoint-to-animated-gif/
keywords: "تحويل PowerPoint، PPT، PPTX، GIF متحرك، PPT إلى GIF متحرك، PPTX إلى GIF متحرك C#، Csharp، .NET، إعدادات افتراضية، إعدادات مخصصة"
description: "تحويل عرض PowerPoint إلى GIF متحرك: PPT إلى GIF، PPTX إلى GIF في C# أو .NET"
---

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية ##

هذا الكود المثال في C# يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

سيتم إنشاء GIF المتحرك باستخدام المعايير الافتراضية.

{{% alert title="نصيحة" color="primary" %}}

إذا كنت تفضل تخصيص المعلمات لـ GIF، يمكنك استخدام فئة [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). انظر الكود المثال أدناه.

{{% /alert %}}

## تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة ##
هذا الكود المثال يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في C#:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // حجم GIF الناتج  
        DefaultDelay = 2000, // المدة التي سيتم عرض كل شريحة قبل الانتقال إلى الشريحة التالية
        TransitionFps = 35 // زيادة FPS لتحسين جودة انتقال الرسوم المتحركة
    });
}
```

{{% alert title="معلومات" color="info" %}}

قد ترغب في الاطلاع على محول [Text to GIF](https://products.aspose.app/slides/text-to-gif) مجاني طورته Aspose.

{{% /alert %}}