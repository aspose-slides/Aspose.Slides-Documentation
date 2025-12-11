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
description: "حوّل PowerPoint PPT/PPTX إلى XPS عالي الجودة غير معتمد على منصة باستخدام Java وAspose.Slides لأجهزة Android. احصل على دليل خطوة بخطوة وعينة شفرة."
---

## **حول XPS**
Microsoft طوّرت [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إخراج ملف مشابه جداً لملف PDF. تنسيق XPS مبني على XML. يبقى تخطيط أو بنية ملف XPS ثابتًا على جميع أنظمة التشغيل والطابعات. 

## **متى تستخدم تنسيق Microsoft XPS**
{{% alert color="primary" %}} 
لمعرفة كيفية تحويل Aspose.Slides للعرض التقديمي PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

إذا كنت ترغب في خفض تكاليف التخزين، يمكنك تحويل عرض PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة، ستجد حفظ المستندات ومشاركتها وطبعها أسهل. 

مايكروسوفت تستمر في توفير دعم قوي لـ XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأفضل لعمليات معينة. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. Windows 8 يوفر دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7** و **Windows Vista** يستخدمان تنسيق XPS الأصلي. أنظمة التشغيل هذه توفر دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**الإخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft في النهاية نفذت دعم عمليات الطباعة في PDF عبر ميزة Print to PDF في Windows 10. في السابق, كان من المتوقع أن يطبع المستخدمون المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**
في [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) لـ Java، يمكنك الاستفادة من طريقة [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS.

عند تحويل عرض تقديمي إلى XPS، عليك حفظ العرض باستخدام أحد الإعدادين التاليين:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**
يعرض هذا المثال في Java كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:
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
يعرض هذا المثال كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات مخصصة في Java:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // إنشاء فئة TiffOptions
    XpsOptions options = new XpsOptions();

    // حفظ MetaFiles كـ PNG
    options.setSaveMetafilesAsPng(true);

    // حفظ العرض التقديمي إلى مستند XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—Aspose.Slides يتيح لك التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، خطوط الأنابيب على الخادم، أو أي سيناريو تحتاج فيه إلى إرسال XPS دون التعامل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استثناؤها؟**

إفتراضيًا، يتم تصوير الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استثناؤ الشرائح المخفية](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) عبر [إعدادات التصدير](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تريدها بالضبط.