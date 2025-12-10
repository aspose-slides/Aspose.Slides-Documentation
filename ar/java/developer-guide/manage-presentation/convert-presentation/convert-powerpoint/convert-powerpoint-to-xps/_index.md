---
title: تحويل عروض PowerPoint إلى XPS في Java
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/java/convert-powerpoint-to-xps/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى XPS
- العرض التقديمي إلى XPS
- الشريحة إلى XPS
- PPT إلى XPS
- PPTX إلى XPS
- حفظ PPT كـ XPS
- حفظ PPTX كـ XPS
- تصدير PPT إلى XPS
- تصدير PPTX إلى XPS
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "تحويل ملفات PowerPoint PPT/PPTX إلى XPS عالي الجودة ومستقل عن المنصة في Java باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينة الكود."
---

## **حول XPS**
طورت مايكروسوفت [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إنتاج ملف يشبه ملف PDF كثيرًا. يعتمد تنسيق XPS على XML. يبقى تخطيط أو بنية ملف XPS كما هي على جميع أنظمة التشغيل والطابعات. 

## **متى تستخدم تنسيق Microsoft XPS**

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides لعروض PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى تنسيق XPS. بهذه الطريقة، ستجد أن حفظ المستندات ومشاركتها وطباعةها يصبح أسهل. 

مايكروسوفت تستمر في توفير دعم قوي لـ XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح ولكن لا توجد ميزة الطباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر أنظمة التشغيل هذه أيضًا دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** لا قارئ PDF. لا ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

مايكروسوفت نفذت في النهاية دعم عمليات الطباعة في PDF عبر ميزة الطباعة إلى PDF في Windows 10. سابقًا، كان من المتوقع أن يقوم المستخدمون بطباعة المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/java/) للـ Java، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) لتحويل العرض بالكامل إلى مستند XPS. 

عند تحويل عرض إلى XPS، عليك حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

هذا المثال البرمجي بلغة Java يوضح كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:
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
هذا المثال البرمجي يوضح كيفية تحويل عرض إلى مستند XPS باستخدام إعدادات مخصصة في Java:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // إنشاء كائن من فئة TiffOptions
    XpsOptions options = new XpsOptions();

    // حفظ ملفات MetaFiles كـ PNG
    options.setSaveMetafilesAsPng(true);

    // حفظ العرض التقديمي إلى مستند XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**هل يمكنني حفظ XPS إلى تدفق بدلًا من ملف؟**

نعم—Aspose.Slides يتيح لك التصدير مباشرة إلى تدفق، مما يكون مثاليًا لواجهات برمجة التطبيقات على الويب، أو خطوط الأنابيب على الخادم، أو أي سيناريو تريد فيه إرسال XPS دون التعامل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكنني استبعادها؟**

بشكل افتراضي، يتم عرض الشرائح العادية (المظهرية) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) من خلال [إعدادات التصدير](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تريدها بالضبط.