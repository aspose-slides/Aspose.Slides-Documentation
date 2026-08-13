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
description: "تحويل PowerPoint PPT/PPTX إلى XPS عالي الجودة ومستقل عن المنصة في Java باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينات التعليمات البرمجية."
---
## **نظرة عامة**

تسمح لك Aspose.Slides بتحويل عروض PowerPoint التقديمية إلى XPS عن طريق حفظ ملف PPT أو PPTX بتنسيق XPS. يوضح هذا المقال متى يمكن أن يكون تنسيق XPS مفيدًا ويظهر كيفية إجراء التحويل باستخدام Aspose.Slides إما بالإعدادات الافتراضية أو بإعدادات [XpsOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xpsoptions/) المخصصة.

## **حول XPS**
قامت Microsoft بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إخراج ملف مشابه جدًا لملف PDF. يعتمد تنسيق XPS على XML. يبقى تخطيط أو بنية ملف XPS نفسه على جميع أنظمة التشغيل والطابعات.

## **متى تستخدم تنسيق XPS من Microsoft**

{{% alert color="info" %}} 
لرؤية كيفية تحويل Aspose.Slides لعرض PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/ar/conversion).
{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى تنسيق XPS. بهذه الطريقة، سيكون من الأسهل حفظ المستندات ومشاركتها وطباعتها.

تستمر Microsoft في تنفيذ دعم قوي لـ XPS في Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، قد يكون XPS هو الخيار الأنسب لبعض العمليات.

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة معيارية من تنسيق XPS الأصلي. يقدم Windows 8 دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قاريء XPS مدمج وميزة الطباعة إلى XPS متوفرة. 
  - **PDF:** قارئ PDF متاح ولكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر أنظمة التشغيل هذه دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متوفرة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

في النهاية، نفذت Microsoft دعم عمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. سابقًا، كان من المتوقع أن يطبع المستخدمون المستندات عبر تنسيق XPS.

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/ar/java/) لـ Java، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) المعروضة في فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) لتحويل العرض بالكامل إلى مستند XPS.

عند تحويل عرض إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

هذا المثال البرمجي بلغة Java يوضح كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:

```java
import com.aspose.slides.*;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // حفظ العرض التقديمي كملف XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
هذا المثال البرمجي يوضح كيفية تحويل عرض إلى مستند XPS باستخدام إعدادات مخصصة في Java:

```java
import com.aspose.slides.*;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // إنشاء كائن XpsOptions
    XpsOptions options = new XpsOptions();

    // حفظ ملفات MetaFiles كـ PNG
    options.setSaveMetafilesAsPng(true);

    // حفظ العرض التقديمي كملف XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة المتكررة**

### هل يمكنني حفظ XPS في تدفق بدلاً من ملف؟

نعم—تتيح لك Aspose.Slides التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، أو خطوط الأنابيب على الخادم، أو أي سيناريو ترغب فيه بإرسال XPS دون التعامل مع نظام الملفات.

### هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكنني استثناؤها؟

بشكل افتراضي، يتم عرض الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) من خلال [إعدادات التصدير](https://reference.aspose.com/slides/ar/java/com.aspose.slides/xpsoptions/) قبل الحفظ إلى XPS، مما يضمن أن يحتوي الناتج على الصفحات التي تقصدها بالضبط.