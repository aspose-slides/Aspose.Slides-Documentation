---
title: تحويل عروض PowerPoint إلى XPS على Android
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/androidjava/convert-powerpoint-to-xps/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى XPS
- العرض إلى XPS
- الشريحة إلى XPS
- PPT إلى XPS
- PPTX إلى XPS
- حفظ PPT كـ XPS
- حفظ PPTX كـ XPS
- تصدير PPT إلى XPS
- تصدير PPTX إلى XPS
- PowerPoint
- العرض
- Android
- Java
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى XPS عالي الجودة، مستقل عن النظام الأساسي، باستخدام Java و Aspose.Slides لنظام Android. احصل على دليل خطوة بخطوة وعينات الكود."
---

## **حول XPS**
قامت مايكروسوفت بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إخراج ملف مشابه جدًا لملف PDF. يعتمد تنسيق XPS على XML. يظل تخطيط أو بنية ملف XPS ثابتًا على جميع أنظمة التشغيل والطابعات. 

## **متى تُستخدم تنسيق Microsoft XPS**
{{% alert color="primary" %}} 
لرؤية كيفية تحويل Aspose.Slides لعروض PPT أو PPTX إلى تنسيق XPS، يمكنك زيارة [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى تنسيق XPS. بهذه الطريقة، ستجد حفظ ومشاركة وطباعة المستندات أسهل. 

مايكروسوفت تستمر في تقديم دعم قوي لـ XPS في نظام Windows (حتى في Windows 10)، لذلك قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1، Windows 8، Windows 7، وWindows Vista، فربما يكون XPS هو الخيار الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 وWindows Vista** يستخدمان تنسيق XPS الأصلي. توفر هذه الأنظمة دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** لا قارئ PDF. لا ميزة طباعة إلى PDF. 

|<p>**الإدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**الإخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



مايكروسوفت قامت لاحقًا بتنفيذ دعم عمليات الطباعة في PDF من خلال ميزة Print to PDF في Windows 10. في السابق، كان من المتوقع أن يقوم المستخدمون بطباعة المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**
في [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) للـ Java، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) المعروضة في فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) لتحويل العرض بالكامل إلى مستند XPS.

عند تحويل عرض إلى XPS، عليك حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون XPSOptions)
- الإعدادات المخصصة (مع XPSOptions)

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**
يظهر لك هذا المثال البرمجي بلغة Java كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // حفظ العرض التقديمي إلى مستند XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
هذا المثال البرمجي يوضح لك كيفية تحويل عرض إلى مستند XPS باستخدام إعدادات مخصصة في Java:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // إنشاء كائن فئة TiffOptions
    XpsOptions options = new XpsOptions();

    // حفظ ملفات Meta كـ PNG
    options.setSaveMetafilesAsPng(true);

    // حفظ العرض التقديمي إلى مستند XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—Aspose.Slides يتيح لك التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات الويب، خطوط الأنابيب على الخادم، أو أي سيناريو تحتاج فيه إلى إرسال XPS دون التعامل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكنني استثناؤها؟**

بشكل افتراضي، يتم تجسيد الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) عبر [إعدادات التصدير](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تريدها بالضبط.