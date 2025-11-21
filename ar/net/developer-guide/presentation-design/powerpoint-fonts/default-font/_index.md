---
title: الخط الافتراضي - PowerPoint C# API
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/net/default-font/
keywords:
- خط
- خط افتراضي
- تصيير العرض
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: تتيح لك PowerPoint C# API تعيين الخط الافتراضي لتصيير العروض التقديمية إلى PDF أو XPS أو الصور المصغرة
---

## **استخدام الخطوط الافتراضية لتصيير العرض التقديمي**
Aspose.Slides يتيح لك تعيين الخط الافتراضي لتصيير العرض إلى PDF أو XPS أو الصور المصغرة. هذه المقالة توضح كيف تحدد DefaultRegularFont وDefaultAsianFont لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من أدلة خارجية باستخدام Aspose.Slides for .NET API:

1. إنشاء نسخة من LoadOptions.
1. ضبط DefaultRegularFont إلى الخط الذي تريده. في المثال التالي، استخدمت Wingdings.
1. ضبط DefaultAsianFont إلى الخط الذي تريده. استخدمت Wingdings في العينة التالية.
1. تحميل العرض التقديمي باستخدام Presentation وتعيين خيارات التحميل.
1. الآن، إنشاء الصورة المصغرة للشرائح وPDF وXPS للتحقق من النتائج.

التنفيذ المذكور أعلاه موضح أدناه.
```c#
// استخدم خيارات التحميل لتحديد الخطوط الافتراضية العادية والآسيوية
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```


## **FAQ**

**ما الذي تؤثر عليه بالضبط DefaultRegularFont وDefaultAsianFont—هل فقط التصدير أم أيضًا الصور المصغرة وPDF وXPS وHTML وSVG؟**

إنهما يشاركان في خط أنابيب التصيير لجميع المخرجات المدعومة. يشمل ذلك الصور المصغرة للشرائح و[PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، و[XPS](/slides/ar/net/convert-powerpoint-to-xps/)، و[raster images](/slides/ar/net/convert-powerpoint-to-png/)، و[HTML](/slides/ar/net/convert-powerpoint-to-html/)، و[SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق تخطيط وحل الحروف عبر هذه الأهداف.

**هل يتم تطبيق الخطوط الافتراضية عند قراءة وحفظ ملف PPTX دون أي تصيير؟**

لا. الخطوط الافتراضية مهمة عندما يجب قياس النص ورسمه. عملية حفظ مفتوح مباشرة للعرض لا تغير تشغيلات الخط المخزنة أو بنية الملف. تُستَخدم الخطوط الافتراضية خلال العمليات التي تصيّر أو تعيد تدفق النص.

**إذا أضفت أدلة خطوط خاصة بي أو زودت الخطوط من الذاكرة، هل سيتم اعتبارها عند اختيار الخطوط الافتراضية؟**

نعم. [Custom font sources](/slides/ar/net/custom-font/) توسّع كتالوج العائلات والحروف المتاحة التي يمكن للمحرك استخدامها. الخطوط الافتراضية وأي [fallback rules](/slides/ar/net/fallback-font/) ستُحلّ ضد تلك المصادر أولاً، مما يوفّر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل تؤثر الخطوط الافتراضية على مقاييس النص (التقارب، التقدم) وبالتالي على فواصل الأسطر والتغليف؟**

نعم. تغيير الخط يغيّر مقاييس الحروف ويمكن أن يغيّر فواصل الأسطر، والتغليف، والصفحات أثناء التصيير. للحفاظ على استقرار التخطيط، [embed the original fonts](/slides/ar/net/embedded-font/) أو اختر عائلات افتراضية وبديلة متوافقة من الناحية المترية.

**هل هناك فائدة من تعيين الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مضمّنة؟**

غالبًا لا يكون ذلك ضروريًا، لأن [embedded fonts](/slides/ar/net/embedded-font/) تضمن بالفعل مظهرًا متسقًا. ما زالت الخطوط الافتراضية تساعد كشبكة أمان للأحرف التي لا تغطيها المجموعة المضمّنة أو عندما يخلط الملف بين نص مضمّن وغير مضمّن.