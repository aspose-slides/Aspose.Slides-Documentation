---
title: تحديد خطوط العرض التقديمي الافتراضية في Java
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/java/default-font/
keywords:
- خط افتراضي
- خط عادي
- خط طبيعي
- خط آسيوي
- تصدير PDF
- تصدير XPS
- تصدير الصور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعيين الخطوط الافتراضية في Aspose.Slides لجافا لضمان تحويل صحيح لعروض PowerPoint (PPT, PPTX) وOpenDocument (ODP) إلى PDF وXPS والصور."
---

## **استخدام الخطوط الافتراضية لتصيير عرض تقديمي**
Aspose.Slides تتيح لك تعيين الخط الافتراضي لتصيير العرض التقديمي إلى PDF أو XPS أو صور مصغرة. يوضح هذا المقال كيفية تعريف DefaultRegularFont وDefaultAsianFont لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات التالية لتحميل الخطوط من أدلة خارجية باستخدام Aspose.Slides for Java API:

1. إنشاء نسخة من [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
2. [تعيين DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) إلى الخط الذي تريده. في المثال التالي، استخدمت Wingdings.
3. [تعيين DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) إلى الخط الذي تريده. استخدمت Wingdings في العينة التالية.
4. تحميل العرض التقديمي باستخدام Presentation وتعيين خيارات التحميل.
5. الآن، أنشئ صورة مصغرة للشريحة، PDF وXPS للتحقق من النتائج.

```java
// استخدم خيارات التحميل لتحديد الخطوط الافتراضية العادية والآسيوية
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// تحميل العرض التقديمي
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // إنشاء صورة مصغرة للشريحة
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // حفظ الصورة على القرص.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // إنشاء PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // إنشاء XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**ما الذي تؤثر عليه بالضبط DefaultRegularFont وDefaultAsianFont — هل هو فقط التصدير أم يشمل أيضًا الصور المصغرة، PDF، XPS، HTML، وSVG؟**

إنها تشارك في خط أنابيب التصيير لجميع المخرجات المدعومة. وهذا يشمل صور مصغرة للشرائح، [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/java/convert-powerpoint-to-xps/)، [raster images](/slides/ar/java/convert-powerpoint-to-png/)، [HTML](/slides/ar/java/convert-powerpoint-to-html/)، و[SVG](/slides/ar/java/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق التخطيط وحل الرموز عبر هذه الأهداف.

**هل تُطبق الخطوط الافتراضية عند مجرد قراءة وحفظ ملف PPTX دون أي تصيير؟**

لا. الخطوط الافتراضية مهمة عندما يجب قياس النص ورسمه. عملية فتح‑حفظ مباشرة للعرض لا تغيّر تشغيلات الخط المخزنة أو بنية الملف. الخطوط الافتراضية تدخل حيّز التنفيذ أثناء العمليات التي تقوم بتصيير أو إعادة تدفق النص.

**إذا أضفت مجلدات خطوط خاصة بي أو زوّدت الخطوط من الذاكرة، هل سيؤخذ ذلك في الاعتبار عند اختيار الخطوط الافتراضية؟**

نعم. [مصادر الخطوط المخصصة](/slides/ar/java/custom-font/) توسّع كتالوج العائلات والرموز المتاحة للمحرك. الخطوط الافتراضية وأي [قواعد احتياطي](/slides/ar/java/fallback-font/) ستُحلّ أولاً ضد تلك المصادر، مما يوفّر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل ستؤثر الخطوط الافتراضية على مقاييس النص (التقريب، التقدم) وبالتالي على فواصل الأسطر واللف؟**

نعم. تغيير الخط يغيّر مقاييس الرموز ويمكن أن يغيّر فواصل الأسطر واللف والصفحات أثناء التصيير. للحفاظ على استقرار التخطيط، يمكنك [تضمين الخطوط الأصلية](/slides/ar/java/embedded-font/) أو اختيار عائلات افتراضية واحتياطية متوافقة من الناحية المترية.

**هل هناك فائدة من ضبط الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مضمّنة؟**

غالبًا لا تكون ضرورية، لأن [الخطوط المضمّنة](/slides/ar/java/embedded-font/) تضمن مظهرًا ثابتًا بالفعل. ومع ذلك، تظل الخطوط الافتراضية مفيدة كشبكة أمان للأحرف غير المغطاة في المجموعة المضمّنة أو عندما يمزج الملف بين نص مضمّن وغير مضمّن.