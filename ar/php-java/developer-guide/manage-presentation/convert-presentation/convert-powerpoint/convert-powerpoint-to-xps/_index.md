---
title: تحويل عروض PowerPoint إلى XPS في PHP
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "تحويل ملفات PowerPoint PPT/PPTX إلى XPS عالي الجودة ومستقل عن المنصة باستخدام Aspose.Slides لـ PHP عبر Java. احصل على دليل خطوة بخطوة وعينة كود."
---

## **حول XPS**
قامت مايكروسوفت بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يتيح لك طباعة المحتوى من خلال إخراج ملف يشبه ملف PDF إلى حد كبير. يعتمد تنسيق XPS على XML. يبقى تخطيط أو بنية ملف XPS نفسه على جميع أنظمة التشغيل والطابعات. 

## **متى تستخدم تنسيق Microsoft XPS**
{{% alert color="primary" %}} 
لرؤية كيف يحول Aspose.Slides عروض PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى تنسيق XPS. بهذه الطريقة، سيكون من الأسهل حفظ مستنداتك ومشاركتها وطباعةها. 

تستمر مايكروسوفت في تنفيذ دعم قوي لتنسيق XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 و Windows 8 و Windows 7 و Windows Vista، فقد يكون XPS هو الخيار الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة معيارية من تنسيق XPS الأصلي. يقدم Windows 8 دعماً أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة طباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر أنظمة التشغيل هذه دعماً أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة طباعة إلى XPS متاحة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

قامت مايكروسوفت في النهاية بتنفيذ دعم عمليات الطباعة في PDF عبر ميزة الطباعة إلى PDF في Windows 10. سابقاً، كان من المتوقع أن يقوم المستخدمون بطباعة المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**
في [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) لـ Java، يمكنك استخدام الطريقة [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) المعروضة بواسطة فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) لتحويل العرض الكامل إلى مستند XPS. 

عند تحويل عرض إلى XPS، عليك حفظ العرض باستخدام أحد الإعدادات التالية:
- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**
يعرض لك هذا المثال كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:
```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # حفظ العرض التقديمي كوثيقة XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
يعرض لك هذا المثال كيفية تحويل عرض إلى مستند XPS باستخدام إعدادات مخصصة:
```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # إنشاء فئة TiffOptions
    $options = new XpsOptions();
    # حفظ MetaFiles بصيغة PNG
    $options->setSaveMetafilesAsPng(true);
    # حفظ العرض التقديمي كوثيقة XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—تتيح لك Aspose.Slides تصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، أو سلاسل المعالجة على الخادم، أو أي سيناريو ترغب فيه بإرسال XPS دون التعامل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استبعادها؟**

بشكل افتراضي، يتم تصيير الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) عبر [إعدادات التصدير](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تقصدها بالضبط.