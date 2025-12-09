---
title: تحويل عروض PowerPoint التقديمية إلى XPS في .NET
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
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى XPS عالي الجودة وغير تابع لمنصة معينة في .NET باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينة كود C#."
---

## **حول XPS**
قامت Microsoft بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يتيح لك طباعة المحتوى عن طريق إخراج ملف مشابه جداً للـ PDF. يعتمد تنسيق XPS على XML. يظل تخطيط أو بنية ملف XPS ثابتًا على جميع أنظمة التشغيل والطابعات. 

## **متى تستخدم تنسيق Microsoft XPS**

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides للعرض التقديمي PPT أو PPTX إلى تنسيق XPS، يمكنك تجربة [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا رغبت في خفض تكاليف التخزين، يمكنك تحويل عرض PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة سيكون من الأسهل حفظ المستندات ومشاركتها وطباعتها. 

ما زالت Microsoft تدعم XPS بقوة في Windows (حتى في Windows 10)، لذا قد ترغب في التفكير بحفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة معيارية من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** عارض/قاريء XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7** و **Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر أنظمة التشغيل هذه أيضًا دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

قامت Microsoft في النهاية بتنفيذ دعم عمليات الطباعة إلى PDF عبر ميزة Print to PDF في Windows 10. في السابق، كان يُتوقع من المستخدمين طباعة المستندات باستخدام تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/net/) لـ .NET، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS. 

عند تحويل عرض تقديمي إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

يعرض هذا الكود النموذجي بلغة C# كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات المخصصة**
يعرض هذا الكود النموذجي بلغة C# كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات المخصصة:
```c#
 // إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // إنشاء كائن الفئة TiffOptions
    XpsOptions options = new XpsOptions();

    // حفظ ملفات MetaFiles بصيغة PNG
    options.SaveMetafilesAsPng = true;

    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **الأسئلة الشائعة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—تتيح لك Aspose.Slides التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، خطوط المعالجة على الخادم، أو أي سيناريو ترغب فيه بإرسال XPS دون التعامل مع نظام الملفات.

**هل تُنقل الشرائح المخفية إلى XPS، وهل يمكن استثناها؟**

بشكل افتراضي، تُظهر فقط الشرائح العادية (المرئية). يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) عبر [إعدادات التصدير](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) قبل حفظ الملف كـ XPS، مما يضمن أن يحتوي الناتج على الصفحات التي تريدها بالضبط.