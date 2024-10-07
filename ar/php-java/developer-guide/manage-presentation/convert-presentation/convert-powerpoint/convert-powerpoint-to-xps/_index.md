---
title: تحويل PowerPoint إلى XPS
type: docs
weight: 70
url: /php-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX إلى XPS"
description: "تحويل PowerPoint PPT(X) إلى XPS"
---

## **حول XPS**
طورت شركة مايكروسوفت [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يتيح لك هذا تنسيق طباعة المحتوى من خلال إخراج ملف مشابه جداً لـ PDF. يعتمد تنسيق XPS على XML. يظل تخطيط أو هيكل ملف XPS كما هو في جميع أنظمة التشغيل والطابعات.

## متى يجب استخدام تنسيق XPS من مايكروسوفت

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides لعرض PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المحول المجاني عبر الإنترنت](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة، ستجد أن حفظ ومشاركة وطباعة مستنداتك أسهل.

تستمر مايكروسوفت في تقديم الدعم القوي لـ XPS في ويندوز (حتى في ويندوز 10)، لذا قد تريد التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع ويندوز 8.1، ويندوز 8، ويندوز 7، و ويندوز فيستا، فإن XPS قد يكون خيارك الأفضل لبعض العمليات.

- **ويندوز 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة معيارية من تنسيق XPS الأصلي. يوفر ويندوز 8 دعمًا أفضل لملفات XPS مقارنةً بملفات PDF.
  - **XPS:** قارئ / عارض XPS مدمج وميزة الطباعة إلى XPS متاحة.
  - **PDF**: متوفر قارئ PDF ولكن لا توجد ميزة الطباعة إلى PDF.

-  **ويندوز 7 و ويندوز فيستا** يستخدمان تنسيق XPS الأصلي. تقدم هذه أنظمة التشغيل أيضًا دعمًا أفضل لملفات XPS مقارنةً بملفات PDF.
  - **XPS**: قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة.
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة الطباعة إلى PDF.

|<p>**PPT(X) المدخلات:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**XPS الناتج:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



في النهاية، قامت مايكروسوفت بتنفيذ دعم لعمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في ويندوز 10. سابقًا، كان يُتوقع من المستخدمين طباعة المستندات من خلال تنسيق XPS.

## تحويل XPS باستخدام Aspose.Slides

في [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) لجافا، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي تعرضها فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS.

عند تحويل عرض تقديمي إلى XPS، يجب عليك حفظ العرض باستخدام أي من هذه الإعدادات:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

يوضح لك هذا الكود النموذجي كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات قياسية:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # حفظ العرض التقديمي إلى مستند XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات المخصصة**
يظهر لك هذا الكود النموذجي كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات مخصصة:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # إنشاء كائن من فئة TiffOptions
    $options = new XpsOptions();
    # حفظ MetaFiles بصيغة PNG
    $options->setSaveMetafilesAsPng(true);
    # حفظ العرض التقديمي إلى مستند XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```