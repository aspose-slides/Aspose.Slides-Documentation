---
title: تحويل PowerPoint إلى XPS
type: docs
weight: 70
url: /java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX إلى XPS"
description: "تحويل PowerPoint PPT(X) إلى XPS في Java"
---

## **عن XPS**
طوّرت مايكروسوفت [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/).  يتيح لك طباعة المحتوى من خلال إخراج ملف مشابه جدًا لملف PDF. يعتمد تنسيق XPS على XML. تظل تخطيط أو هيكل ملف XPS كما هو على جميع أنظمة التشغيل والطابعات. 

## متى يجب استخدام تنسيق Microsoft XPS

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides عرض PPT أو PPTX إلى تنسيق XPS، يمكنك التحقق من [هذا التطبيق المجاني لتحويل الملفات على الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة، ستجد أنه من الأسهل حفظ ومشاركة وطباعة مستنداتك. 

تواصل مايكروسوفت تنفيذ دعم قوي لـ XPS في Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات إلى هذا التنسيق. إذا كنت تتعامل مع Windows 8.1، Windows 8، Windows 7، و Windows Vista، فإن XPS قد يكون في الواقع أفضل خيار لك لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو إصدار موحد من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** متصفح/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: قارئ PDF متاح ولكن لا توجد ميزة الطباعة إلى PDF. 

-  **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر هذه أنظمة التشغيل أيضًا دعمًا أفضل لملفات XPS مقارنةً بـ PDF. 
  - **XPS**: متصفح XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة الطباعة إلى PDF. 

|<p>**مدخل PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خرج XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

في النهاية، نفذت مايكروسوفت دعمًا لعمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. سابقًا، كان من المتوقع أن يقوم المستخدمون بطباعة المستندات من خلال تنسيق XPS. 

## تحويل XPS باستخدام Aspose.Slides

في [**Aspose.Slides**](https://products.aspose.com/slides/java/) لـ Java، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) المعروضة من قبل فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS. 

عند تحويل عرض تقديمي إلى XPS، عليك حفظ العرض باستخدام أي من هذه الإعدادات:

- إعدادات افتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))
- إعدادات مخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

هذا الرمز النموذجي في Java يوضح لك كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:

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


### **تحويل العروض التقديمية إلى XPS باستخدام إعدادات مخصصة**
هذا الرمز النموذجي يوضح لك كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات مخصصة في Java:

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // إنشاء كائن XpsOptions
    XpsOptions options = new XpsOptions();

    // حفظ ملفات التعريف كـ PNG
    options.setSaveMetafilesAsPng(true);

    // حفظ العرض التقديمي إلى مستند XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```