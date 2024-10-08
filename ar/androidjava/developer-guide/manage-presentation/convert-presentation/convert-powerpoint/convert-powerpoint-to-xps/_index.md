---
title: تحويل PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/androidjava/convert-powerpoint-to-xps/
keywords: "PPT, PPTX إلى XPS"
description: "تحويل PowerPoint PPT(X) إلى XPS في Java"
---

## **حول XPS**
طورت مايكروسوفت [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى من خلال إنتاج ملف مشابه جداً لـ PDF. صيغة XPS تعتمد على XML. تظل تخطيط أو بنية ملف XPS كما هي على جميع أنظمة التشغيل والطابعات. 

## متى تستخدم صيغة Microsoft XPS

{{% alert color="primary" %}} 

لمعرفة كيف تقوم Aspose.Slides بتحويل عرض PPT أو PPTX إلى صيغة XPS، يمكنك التحقق من [هذا التطبيق المجاني عبر الإنترنت للتحويل](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint الخاص بك إلى صيغة XPS. بهذه الطريقة، ستجد أنه من الأسهل حفظ ومشاركة وطباعة مستنداتك. 

تواصل مايكروسوفت تنفيذ دعم قوي لصيغة XPS في Windows (حتى في Windows 10)، لذلك قد ترغب في اعتبار حفظ الملفات إلى هذه الصيغة. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد تكون XPS هي أفضل خياراتك لبعض العمليات. 

- **Windows 8** يستخدم صيغة OXPS (Open XPS) لملفات XPS. OXPS هي نسخة معيارية من صيغة XPS الأصلية. يوفر Windows 8 دعماً أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** ميزة عارض/قارئ XPS مدمجة وطباعة إلى XPS متاحة. 
  - **PDF**: قارئ PDF متاح ولكن لا توجد ميزة الطباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان صيغة XPS الأصلية. توفر أنظمة التشغيل هذه أيضاً دعماً أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS**: عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة الطباعة إلى PDF. 

|<p>**مدخل PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خارج XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



في النهاية، قامت مايكروسوفت بتنفيذ دعم لعمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. في السابق، كان من المتوقع أن يقوم المستخدمون بطباعة المستندات عبر صيغة XPS. 

## تحويل XPS باستخدام Aspose.Slides

في [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) لـ Java، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) لتحويل العرض بالكامل إلى مستند XPS.

عند تحويل العرض إلى XPS، يجب عليك حفظ العرض باستخدام أي من هذه الإعدادات:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

هذا الكود النموذجي في Java يوضح لك كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // حفظ العرض كوثيقة XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
هذا الكود النموذجي يوضح لك كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات المخصصة في Java:

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // إنشاء كائن XpsOptions
    XpsOptions options = new XpsOptions();

    // حفظ ملفات التعريف كـ PNG
    options.setSaveMetafilesAsPng(true);

    // حفظ العرض كوثيقة XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```