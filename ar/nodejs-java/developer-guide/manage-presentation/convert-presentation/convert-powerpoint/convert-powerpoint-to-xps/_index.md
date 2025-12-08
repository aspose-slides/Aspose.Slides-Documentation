---
title: تحويل PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/nodejs-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX إلى XPS"
description: "تحويل PowerPoint PPT(X) إلى XPS في JavaScript"
---

## **حول XPS**

قامت Microsoft بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يتيح لك طباعة المحتوى عن طريق إخراج ملف مشابه جداً لـ PDF. يعتمد تنسيق XPS على XML. يظل تخطيط أو بنية ملف XPS هو نفسه على جميع أنظمة التشغيل والطابعات. 

## **متى تستخدم تنسيق Microsoft XPS**

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides للعرض التقديمي PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني على الإنترنت للتحويل](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا رغبت في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة، سيكون من الأسهل حفظ المستندات ومشاركتها وطبعها. 

ما زالت Microsoft تدعم XPS بقوة في Windows (حتى في Windows 10)، لذا قد ترغب في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة معيارية من تنسيق XPS الأصلي. يوفر Windows 8 دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متوفرة. 
  - **PDF:** قارئ PDF متوفر لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. هذه الأنظمة أيضاً توفر دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متوفرة. 
  - **PDF:** لا قارئ PDF. لا ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**الإخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



في النهاية، نفذت Microsoft دعماً لعمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. كان من المتوقع في السابق أن يطبع المستخدمون المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/)، يمكنك استخدام طريقة [**save**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS.

عند تحويل عرض تقديمي إلى XPS، عليك حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (دون [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

يوضح لك هذا المثال البرمجي في JavaScript كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:
```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // حفظ العرض التقديمي إلى مستند XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**

يوضح لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات المخصصة في JavaScript:
```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // إنشاء كائن من الفئة TiffOptions
    var options = new aspose.slides.XpsOptions();
    // حفظ ملفات Meta كـ PNG
    options.setSaveMetafilesAsPng(true);
    // حفظ العرض التقديمي إلى مستند XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يمكنني حفظ XPS إلى تدفق (stream) بدلاً من ملف؟**

نعم—تتيح لك Aspose.Slides التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، وخطوط الأنابيب على الخادم، أو أي سيناريو تحتاج فيه إلى إرسال XPS دون الاعتماد على نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استثناؤها؟**

بشكل افتراضي، يتم عرض الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استثناء الشرائح المخفية](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) عبر [إعدادات التصدير](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تريدها بالضبط.