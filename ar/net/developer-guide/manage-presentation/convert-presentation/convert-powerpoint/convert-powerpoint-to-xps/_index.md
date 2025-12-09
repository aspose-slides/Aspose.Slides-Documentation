---
title: تحويل عروض PowerPoint إلى XPS في .NET
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/net/convert-powerpoint-to-xps/
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
- .NET
- C#
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى XPS عالي الجودة وغير مرتبط بالمنصات في .NET باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينة كود C#."
---

## **حول XPS**
طورت Microsoft [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يتيح لك طباعة المحتوى عن طريق إخراج ملف مشابه جداً لملف PDF. يعتمد تنسيق XPS على XML. يبقى تخطيط أو هيكل ملف XPS ثابتاً على جميع أنظمة التشغيل والطابعات.

## **متى تستخدم تنسيق Microsoft XPS**

{{% alert color="primary" %}} 

لمعرفة كيف يقوم Aspose.Slides بتحويل عرض PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة، ستجد أنه من الأسهل حفظ المستندات ومشاركتها وطباعةها.

ما زالت Microsoft تدعم XPS بقوة في نظام Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تستخدم Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأفضل لبعض العمليات.

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة معيارية من تنسيق XPS الأصلي. يوفر Windows 8 دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. كما يوفر هذان النظامان دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**الإخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



في النهاية، نفذت Microsoft دعماً لعمليات الطباعة إلى PDF عبر ميزة Print to PDF في Windows 10. في السابق، كان من المتوقع أن يطبع المستخدمون المستندات عبر تنسيق XPS.

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/net/) للـ .NET، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS.

عند تحويل عرض تقديمي إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

هذا الكود النموذجي بلغة C# يوضح كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات المخصصة**
هذا الكود النموذجي يوضح كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات مخصصة بلغة C#:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // إنشاء كائن من الفئة TiffOptions
    XpsOptions options = new XpsOptions();

    // حفظ ملفات الميتا كـ PNG
    options.SaveMetafilesAsPng = true;

    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—تتيح لك Aspose.Slides التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، وسلاسل المعالجة على الخادم، أو أي سيناريو تريد فيه إرسال XPS دون التفاعل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استثنائها؟**

بشكل افتراضي، يتم عرض الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استثناء الشرائح المخفية](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) من خلال [إعدادات التصدير](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) قبل الحفظ إلى XPS، مما يضمن أن يحتوي الناتج على الصفحات التي تقصدها بالضبط.