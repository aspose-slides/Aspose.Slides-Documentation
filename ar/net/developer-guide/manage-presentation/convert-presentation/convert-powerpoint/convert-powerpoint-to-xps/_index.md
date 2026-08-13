---
title: تحويل عروض PowerPoint إلى XPS في .NET
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/net/convert-powerpoint-to-xps/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى XPS
- عرض تقديمي إلى XPS
- شريحة إلى XPS
- PPT إلى XPS
- PPTX إلى XPS
- حفظ PPT كـ XPS
- حفظ PPTX كـ XPS
- تصدير PPT إلى XPS
- تصدير PPTX إلى XPS
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل ملفات PowerPoint PPT/PPTX إلى XPS عالي الجودة ومستقل عن المنصة في .NET باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينة كود C#."
---
## **نظرة عامة**

Aspose.Slides يتيح لك تحويل عروض PowerPoint إلى XPS عن طريق حفظ ملف PPT أو PPTX بصيغة XPS. يشرح هذا المقال متى قد يكون تنسيق XPS مفيدًا ويظهر كيفية إجراء التحويل باستخدام Aspose.Slides إما باستخدام الإعدادات الافتراضية أو إعدادات [XpsOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/xpsoptions/) المخصصة.

## **حول XPS**
قامت Microsoft بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إخراج ملف يشبه كثيرًا PDF. يعتمد تنسيق XPS على XML. يبقى تخطيط أو بنية ملف XPS هو نفسه على جميع أنظمة التشغيل والطابعات.

## **متى تستخدم تنسيق Microsoft XPS**

{{% alert color="info" %}} 
لرؤية كيفية تحويل Aspose.Slides لعرض PPT أو PPTX إلى تنسيق XPS، يمكنك تجربة [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/ar/conversion).
{{% /alert %}} 

إذا كنت ترغب في خفض تكاليف التخزين، يمكنك تحويل عرض PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة سيكون من الأسهل حفظ المستندات ومشاركتها وطبعها.

ما زالت Microsoft تستمر في تقديم دعم قوي لتنسيق XPS في Windows (حتى في Windows 10)، لذا قد ترغب في النظر في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فإن XPS قد يكون خيارك الأفضل لبعض العمليات.

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة معيارية من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنة بملفات PDF.  
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة.  
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF.  

- **Windows 7** و **Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر أنظمة التشغيل هذه دعمًا أفضل لملفات XPS مقارنة بملفات PDF.  
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متاحة.  
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF.  

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**الإخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

في النهاية نفذت Microsoft دعمًا لعمليات الطباعة إلى PDF عبر ميزة Print to PDF في Windows 10. كان المستخدمون في السابق يُتوقع منهم طباعة المستندات عبر تنسيق XPS.

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/ar/net/) لـ .NET، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/methods/save/index) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) لتحويل العرض بالكامل إلى مستند XPS.

عند تحويل عرض إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/ar/net/aspose.slides.export/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/ar/net/aspose.slides.export/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

يعرض هذا المثال البرمجي بلغة C# كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**

يعرض هذا المثال البرمجي كيفية تحويل عرض إلى مستند XPS باستخدام إعدادات مخصصة في C#:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // إنشاء كائن من الفئة TiffOptions
    XpsOptions options = new XpsOptions();

    // حفظ ملفات MetaFiles كـ PNG
    options.SaveMetafilesAsPng = true;

    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **الأسئلة المتكررة**

### هل يمكن حفظ XPS إلى تدفق بدلاً من ملف؟

نعم—Aspose.Slides يتيح لك التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب أو خطوط أنابيب الخادم أو أي سيناريو تريد فيه إرسال XPS دون لمس نظام الملفات.

### هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استبعادها؟

بشكل افتراضي، يتم عرض الشرائح العادية (المشاهد) فقط. يمكنك [include or exclude hidden slides](https://reference.aspose.com/slides/ar/net/aspose.slides.export/xpsoptions/showhiddenslides/) عبر [export settings](https://reference.aspose.com/slides/ar/net/aspose.slides.export/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تريدها تمامًا.