---
title: تحديد خطوط العرض الافتراضية في .NET
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/net/default-font/
keywords:
- الخط الافتراضي
- الخط العادي
- الخط الطبيعي
- الخط الآسيوي
- تصدير PDF
- تصدير XPS
- تصدير الصور
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تعيين الخطوط الافتراضية في Aspose.Slides لـ .NET لضمان تحويل صحيح لملفات PowerPoint (PPT، PPTX) و OpenDocument (ODP) إلى PDF و XPS والصور."
---

## **استخدام الخطوط الافتراضية لتصيير عرض تقديمي**
تتيح لك Aspose.Slides ضبط الخط الافتراضي لتصيير العرض إلى PDF أو XPS أو صور مصغرة. توضح هذه المقالة كيفية تعريف DefaultRegularFont وDefaultAsianFont لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من دلائل خارجية باستخدام Aspose.Slides for .NET API:

1. أنشئ مثيلاً من LoadOptions.
1. اضبط DefaultRegularFont إلى الخط الذي ترغب به. في المثال التالي، استخدمت Wingdings.
1. اضبط DefaultAsianFont إلى الخط الذي ترغب به. استخدمت Wingdings في العينة التالية.
1. حمّل العرض باستخدام Presentation وتحديد خيارات التحميل.
1. الآن، أنشئ الصورة المصغرة للشرائح، PDF وXPS للتحقق من النتائج.

التنفيذ أعلاه موضح أدناه.
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


## **الأسئلة المتداولة**

**ما الذي يؤثر عليه DefaultRegularFont وDefaultAsianFont بالضبط—هل هو التصدير فقط، أم أيضًا الصور المصغرة، PDF، XPS، HTML، وSVG؟**  
إنها تشارك في أنبوب التصيير لجميع المخرجات المدعومة. وهذا يشمل الصور المصغرة للشرائح، [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/net/convert-powerpoint-to-xps/)، [الصور النقطية](/slides/ar/net/convert-powerpoint-to-png/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، و[SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق التخطيط وحل الرموز عبر هذه الأهداف.

**هل تُطبق الخطوط الافتراضية عند قراءة وحفظ ملف PPTX ببساطة دون أي تصيير؟**  
لا. الخطوط الافتراضية ذات أهمية عندما يجب قياس النص ورسمه. عملية الفتح‑الحفظ المباشرة للعرض لا تغير من سلاسل الخط المخزنة أو بنية الملف. تصبح الخطوط الافتراضية فعّالة أثناء العمليات التي تقوم بتصيير أو إعادة تدفق النص.

**إذا أضفت دلائل خطوط خاصة بي أو زودت الخطوط من الذاكرة، هل ستؤخذ في الاعتبار عند اختيار الخطوط الافتراضية؟**  
نعم. [مصادر الخطوط المخصصة](/slides/ar/net/custom-font/) توسّع كتالوج العائلات والرموز المتاحة التي يمكن للمحرك استخدامها. الخطوط الافتراضية وأية [قواعد احتياطية](/slides/ar/net/fallback-font/) ستحل أولاً مقابل تلك المصادر، مما يوفّر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل ستؤثر الخطوط الافتراضية على مقاييس النص (التعديل، التقدم) وبالتالي على فواصل الأسطر والالتفاف؟**  
نعم. تغيير الخط يغيّر مقاييس الرموز وقد يغير فواصل الأسطر، الالتفاف، والترقيم الصفحات أثناء التصيير. لضمان استقرار التخطيط، [قم بتضمين الخطوط الأصلية](/slides/ar/net/embedded-font/) أو اختر عائلات افتراضية واحتياطية متوافقة من الناحية المترية.

**هل هناك فائدة من ضبط الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مضمّنة؟**  
غالبًا لا يكون ذلك ضروريًا، لأن [الخطوط المضمّنة](/slides/ar/net/embedded-font/) تضمن بالفعل مظهرًا متسقًا. لا تزال الخطوط الافتراضية مفيدة كشبكة أمان للأحرف التي لا تغطيها المجموعة المضمّنة أو عندما يخلط الملف بين نص مضمّن ونص غير مضمّن.