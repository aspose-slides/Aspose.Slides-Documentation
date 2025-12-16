---
title: تحديد الخطوط الافتراضية للعرض التقديمي على Android
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/androidjava/default-font/
keywords:
- خط افتراضي
- خط عادي
- خط طبيعي
- خط آسيوي
- تصدير PDF
- تصدير XPS
- تصدير صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعيين الخطوط الافتراضية في Aspose.Slides للأندرويد عبر جافا لضمان تحويل صحيح لعروض PowerPoint (PPT، PPTX) وOpenDocument (ODP) إلى PDF وXPS والصور."
---

## **استخدام الخطوط الافتراضية لتصيير عرض تقديمي**
تتيح لك Aspose.Slides تعيين الخط الافتراضي لتصيير العرض إلى PDF أو XPS أو صور مصغرة. يوضح هذا المقال كيفية تعريف DefaultRegularFont و DefaultAsianFont كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من أدلة خارجية باستخدام Aspose.Slides للـ Android عبر واجهة Java API:

1. إنشاء نسخة من [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) إلى الخط الذي تريده. في المثال التالي، استخدمت Wingdings.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) إلى الخط الذي تريده. استخدمت Wingdings في العينة التالية.
4. تحميل العرض باستخدام Presentation وتعيين خيارات التحميل.
5. الآن، إنشاء الصورة المصغرة للشريحة، PDF و XPS للتحقق من النتائج.

التنفيذ المذكور أعلاه موضح أدناه.
```java
// استخدم خيارات التحميل لتعريف الخطوط الافتراضية العادية والآسيوية
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

**ما الذي تؤثر عليه خاصيتي DefaultRegularFont و DefaultAsianFont بالضبط—هل هي فقط في التصدير أم تشمل الصور المصغرة، PDF، XPS، HTML و SVG؟**

إنهما يشاركان في خط أنابيب الصيّر لجميع المخرجات المدعومة. يشمل ذلك الصور المصغرة للشرائح، [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/androidjava/convert-powerpoint-to-xps/)، [صور نقطية](/slides/ar/androidjava/convert-powerpoint-to-png/)، [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، و [SVG](/slides/ar/androidjava/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق التخطيط وحل الحروف عبر هذه الأهداف.

**هل تُطبق الخطوط الافتراضية عند قراءة وحفظ ملف PPTX دون أي صيّر؟**

لا. تهم الخطوط الافتراضية عندما يجب قياس النص ورسمه. حفظ العرض مباشرة لا يغيّر تشغيلات الخط المخزنة أو بنية الملف. تظهر الخطوط الافتراضية فقط أثناء العمليات التي تصيّر أو تعيد تنسيق النص.

**إذا أضفت مجلدات خطوط خاصة بي أو زودت الخطوط من الذاكرة، هل سيتم أخذها في الاعتبار عند اختيار الخطوط الافتراضية؟**

نعم. [Custom font sources](/slides/ar/androidjava/custom-font/) توسّع كتالوج العائلات والحروف المتاحة التي يمكن للمحرك استخدامها. الخطوط الافتراضية وأي [fallback rules](/slides/ar/androidjava/fallback-font/) ستحلّ ضد تلك المصادر أولاً، مما يوفر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل تؤثر الخطوط الافتراضية على مقاييس النص (التقريب، التقدم) وبالتالي على فواصل الأسطر واللف؟**

نعم. تغيير الخط يغيّر مقاييس الحروف ويمكن أن يغيّر فواصل الأسطر، واللف، والصفحات أثناء الصيّر. من أجل استقرار التخطيط، يُنصَح [embed the original fonts](/slides/ar/androidjava/embedded-font/) أو اختيار عائلات افتراضية واحتياطية متوافقة من الناحية المترية.

**هل هناك فائدة من تعيين الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مدمجة؟**

غالبًا لا يكون ذلك ضروريًا، لأن [embedded fonts](/slides/ar/androidjava/embedded-font/) تضمن مظهرًا متسقًا بالفعل. ما زالت الخطوط الافتراضية مفيدة كشبكة أمان للأحرف غير المغطاة بالجزء المدمج أو عندما يخلط الملف بين نص مدمج وغير مدمج.