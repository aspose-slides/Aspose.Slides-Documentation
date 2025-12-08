---
title: الخطوط الافتراضية - واجهة برمجة تطبيقات PowerPoint JavaScript
linktitle: الخطوط الافتراضية
type: docs
weight: 30
url: /ar/nodejs-java/default-font/
description: تتيح لك واجهة برمجة تطبيقات PowerPoint JavaScript تعيين الخط الافتراضي لتصوير العرض التقديمي إلى PDF أو XPS أو الصور المصغرة. تُظهر هذه المقالة كيفية تعريف DefaultRegular Font و DefaultAsian Font للاستخدام كخطوط افتراضية.
---

## **استخدام الخطوط الافتراضية لتصوير العرض التقديمي**
Aspose.Slides يتيح لك تعيين الخط الافتراضي لتصوير العرض التقديمي إلى PDF أو XPS أو صور مصغرة. توضح هذه المقالة كيفية تعريف DefaultRegularFont و DefaultAsianFont لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من دلائل خارجية باستخدام Aspose.Slides لـ Node.js عبر واجهة Java API:

1. إنشاء مثال من [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) إلى الخط الذي تريده. في المثال التالي، استخدمت Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) إلى الخط الذي تريده. استخدمت Wingdings في العينة التالية.
1. تحميل العرض التقديمي باستخدام Presentation وتعيين خيارات التحميل.
1. الآن، قم بإنشاء صورة مصغرة للشرائح، وPDF وXPS للتحقق من النتائج.

التنفيذ المذكور أعلاه موضح أدناه.
```javascript
// استخدم خيارات التحميل لتحديد الخطوط الافتراضية العادية والآسيوية
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// تحميل العرض التقديمي
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // إنشاء صورة مصغرة للشرائح
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // حفظ الصورة على القرص.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // إنشاء ملف PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // إنشاء ملف XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**ما الذي تؤثر به DefaultRegularFont و DefaultAsianFont بالضبط — هل هو التصدير فقط أم تشمل الصور المصغرة، PDF، XPS، HTML، و SVG؟**

إنهما يشاركان في خط أنابيب التصوير لجميع المخرجات المدعومة. وهذا يشمل الصور المصغرة للشرائح، [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/)، [صور نقطية](/slides/ar/nodejs-java/convert-powerpoint-to-png/)، [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)، و[SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق تخطيط الأحرف وحل الرموز عبر هذه الأهداف.

**هل تُطبق الخطوط الافتراضية عند قراءة وحفظ ملف PPTX دون أي تصوير؟**

لا. الخطوط الافتراضية ذات أهمية عندما يجب قياس النص ورسمه. الحفظ المفتوح المباشر للعرض التقديمي لا يغيّر تشغيلات الخط المخزنة أو بنية الملف. الخطوط الافتراضية تدخل حيز التنفيذ خلال العمليات التي تُصوّر أو تُعيد تنسيق النص.

**إذا أضفت مجلدات خطوط خاصة بي أو وفرت خطوطًا من الذاكرة، هل ستؤخذ في الاعتبار عند اختيار الخطوط الافتراضية؟**

نعم. [Custom font sources](/slides/ar/nodejs-java/custom-font/) توسِّع كتالوج العائلات والرموز المتاحة التي يمكن للمحرك استخدامها. الخطوط الافتراضية وأية [fallback rules](/slides/ar/nodejs-java/fallback-font/) ستُحلّ ضد تلك المصادر أولاً، مما يوفر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل ستؤثر الخطوط الافتراضية على مقاييس النص (kerning, advances) وبالتالي على فواصل الأسطر واللف؟**

نعم. تغيير الخط يغيّر مقاييس الرموز ويمكن أن يغيّر فواصل الأسطر واللف والصفحات أثناء التصوير. لضمان استقرار التخطيط، [embed the original fonts](/slides/ar/nodejs-java/embedded-font/) أو اختر عائلات افتراضية وبديلة متناسقة مقاييميًا.

**هل هناك فائدة من تعيين الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مدمجة؟**

غالبًا لا يكون ذلك ضروريًا، لأن [embedded fonts](/slides/ar/nodejs-java/embedded-font/) تضمن بالفعل مظهرًا متسقًا. ومع ذلك، لا تزال الخطوط الافتراضية مفيدة كشبكة أمان للأحرف غير المشمولة في المجموعة المدمجة أو عندما يختلط النص المدمج وغير المدمج في الملف.