---
title: تحديد خطوط العرض التقديمي الافتراضية في .NET
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/net/default-font/
keywords:
- الخط الافتراضي
- خط عادي
- خط طبيعي
- خط آسيوي
- تصدير PDF
- تصدير XPS
- تصدير الصور
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بتحديد الخطوط الافتراضية في Aspose.Slides لـ .NET لضمان التحويل الصحيح لعروض PowerPoint (PPT، PPTX) و OpenDocument (ODP) إلى PDF و XPS والصور."
---

## **استخدام الخطوط الافتراضية لتصيير العرض التقديمي**
Aspose.Slides تتيح لك تعيين الخط الافتراضي لتصيير العرض التقديمي إلى PDF أو XPS أو الصور المصغرة. يوضح هذا المقال كيفية تعريف DefaultRegularFont و DefaultAsianFont للاستخدام كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من دلائل خارجية باستخدام Aspose.Slides for .NET API:

1. إنشاء مثيل من LoadOptions.
1. تعيين DefaultRegularFont إلى الخط الذي تريده. في المثال التالي، استخدمت Wingdings.
1. تعيين DefaultAsianFont إلى الخط الذي تريده. استخدمت Wingdings في العينة التالية.
1. تحميل العرض التقديمي باستخدام Presentation وتعيين خيارات التحميل.
1. الآن، قم بإنشاء الصورة المصغرة للشريحة، PDF و XPS للتحقق من النتائج.

تنفيذ ما سبق موضح أدناه.
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


## **الأسئلة الشائعة**

**ما الذي يؤثر عليه DefaultRegularFont و DefaultAsianFont بالضبط—هل هو التصدير فقط، أم يشمل أيضًا الصور المصغرة و PDF و XPS و HTML و SVG؟**

إنها تشارك في خط أنابيب التصيير لجميع المخرجات المدعومة. وهذا يشمل الصور المصغرة للشرائح، [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/net/convert-powerpoint-to-xps/)، [صور نقطية](/slides/ar/net/convert-powerpoint-to-png/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، و [SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق تخطيط وحل الرموز عبر هذه الأهداف.

**هل تُطبق الخطوط الافتراضية عند مجرد قراءة وحفظ ملف PPTX دون أي تصيير؟**

لا. تهم الخطوط الافتراضية عندما يجب قياس النص ورسمه. مجرد فتح وحفظ العرض التقديمي لا يغيّر تشغيلات الخط المخزنة أو بنية الملف. الخطوط الافتراضية تدخل في الصعيد أثناء العمليات التي تقوم بتصيير أو إعادة تدفق النص.

**إذا قمت بإضافة مجلدات خطوط خاصة بي أو زودت الخطوط من الذاكرة، هل سيتم أخذها في الاعتبار عند اختيار الخطوط الافتراضية؟**

نعم. [مصادر الخطوط المخصصة](/slides/ar/net/custom-font/) توسع كتالوج العائلات والرموز المتاحة التي يمكن للمحرك استخدامها. الخطوط الافتراضية وأي [قواعد الخطوط الاحتياطية](/slides/ar/net/fallback-font/) ستحل أولاً ضد تلك المصادر، مما يوفر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل ستؤثر الخطوط الافتراضية على قياسات النص (التتبع، التقدم) وبالتالي على فواصل الأسطر واللف؟**

نعم. تغيير الخط يغيّر مقاييس الرموز ويمكن أن يغيّر فواصل الأسطر، واللف، والصفحات أثناء التصيير. للحصول على استقرار التخطيط، [تضمين الخطوط الأصلية](/slides/ar/net/embedded-font/) أو اختيار عائلات افتراضية واحتياطية متوافقة من حيث المقاييس.

**هل هناك فائدة من ضبط الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مضمَّنة؟**

في كثير من الأحيان لا يكون ذلك ضروريًا، لأن [الخطوط المضمنة](/slides/ar/net/embedded-font/) تضمن بالفعل مظهرًا متسقًا. ما زالت الخطوط الافتراضية مفيدة كشبكة أمان للأحرف التي لا يغطيها الجزء المضمن أو عندما يخلط الملف النص المضمّن وغير المضمّن.