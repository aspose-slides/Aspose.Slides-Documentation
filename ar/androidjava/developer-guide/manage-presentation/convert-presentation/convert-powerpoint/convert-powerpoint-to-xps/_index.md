---
title: تحويل عروض PowerPoint إلى XPS على Android
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "تحويل ملفات PowerPoint PPT/PPTX إلى XPS عالي الجودة ومستقل عن المنصة باستخدام Aspose.Slides للـ Android في Java. احصل على دليل خطوة بخطوة وعينات من الكود."
---
## **نظرة عامة**

تمكنك Aspose.Slides من تحويل عروض PowerPoint إلى XPS عن طريق حفظ ملف PPT أو PPTX بصيغة XPS. يشرح هذا المقال متى قد تكون صيغة XPS مفيدة ويظهر كيفية إجراء التحويل باستخدام Aspose.Slides إما بالإعدادات الافتراضية أو إعدادات [XpsOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xpsoptions/) المخصصة.

## **حول XPS**
قامت مايكروسوفت بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إنشاء ملف مشابه جداً للـ PDF. صيغـة XPS مبنية على XML. يبقى تخطيط أو بنية ملف XPS ثابتاً على جميع أنظمة التشغيل والطابعات.

## **متى تستخدم صيغة Microsoft XPS**

{{% alert color="info" %}} 
لمعرفة كيفية تحويل Aspose.Slides لعرض PPT أو PPTX إلى صيغة XPS، يمكنك تجربة [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/ar/conversion). 
{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى صيغة XPS. بهذه الطريقة سيكون من الأسهل حفظ المستندات ومشاركتها وطباعةها. 

تستمر مايكروسوفت في تقديم دعم قوي لـ XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذه الصيغة. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد تكون XPS هي الخيار الأنسب لبعض العمليات. 

- **Windows 8** يستخدم صيغة OXPS (Open XPS) للملفات XPS. OXPS هي نسخة موحدة من الصيغة الأصلية لـ XPS. يوفر Windows 8 دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان الصيغة الأصلية لـ XPS. توفر أنظمة التشغيل هذه دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

في النهاية، نفذت مايكروسوفت دعم عمليات الطباعة في PDF عبر ميزة الطباعة إلى PDF في Windows 10. سابقاً، كان يتوجب على المستخدمين طباعة المستندات عبر صيغة XPS. 

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/ar/androidjava/) للغة Java، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) لتحويل العرض بالكامل إلى مستند XPS.

عند تحويل عرض إلى XPS، عليك حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (دون [**XPSOptions**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

يعرض لك هذا المثال المكتوب بلغة Java كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:

```java
import com.aspose.slides.*;

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
يظهر لك هذا المثال كيفية تحويل عرض إلى مستند XPS باستخدام إعدادات مخصصة في Java:

```java
import com.aspose.slides.*;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // إنشاء كائن من الفئة XpsOptions
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

### هل يمكن حفظ XPS إلى تدفق بدلاً من ملف؟

نعم—تتيح لك Aspose.Slides التصدير مباشرة إلى تدفق، وهو أمر مثالي لواجهات برمجة التطبيقات على الويب، أو خطوط الأنابيب على الخادم، أو أي سيناريو تريد فيه إرسال XPS دون التعامل مع نظام الملفات.

### هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استثناؤها؟

بشكل افتراضي، يتم معالجة الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) عبر [إعدادات التصدير](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تريدها بالضبط.