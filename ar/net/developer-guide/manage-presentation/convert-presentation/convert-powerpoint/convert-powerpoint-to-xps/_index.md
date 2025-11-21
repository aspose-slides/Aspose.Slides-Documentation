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
- باوربوينت
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: تحويل عروض PowerPoint PPT/PPTX إلى XPS عالي الجودة ومستقل عن المنصة في .NET باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينة كود C#.
---

## **حول XPS**
طورت Microsoft [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يتيح لك طباعة المحتوى عن طريق إخراج ملف مشابه جداً لملف PDF. يعتمد تنسيق XPS على XML. يبقى تخطيط أو بنية ملف XPS نفسه على جميع أنظمة التشغيل والطابعات.

## **متى يستخدم تنسيق Microsoft XPS**

{{% alert color="primary" %}} 
لمعرفة كيف يقوم Aspose.Slides بتحويل عروض PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة، سيصبح حفظ المستندات ومشاركتها وطباعةها أسهل.

تستمر Microsoft في تقديم دعم قوي لـ XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في التفكير بحفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS في الواقع خيارك الأفضل لبعض العمليات.

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح ولكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7** و **Windows Vista** يستخدمان تنسيق XPS الأصلي. هذه الأنظمة أيضًا توفر دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

قامت Microsoft لاحقًا بتنفيذ دعم عمليات الطباعة في PDF عبر ميزة الطباعة إلى PDF في Windows 10. في السابق، كان يُتوقع من المستخدمين طباعة المستندات عبر تنسيق XPS.

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/net/) لـ .NET، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض بالكامل إلى مستند XPS.

عند تحويل عرض إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

يعرض هذا المثال البرمجي بلغة C# كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **تحويل العروض إلى XPS باستخدام إعدادات مخصصة**

يعرض هذا المثال البرمجي كيفية تحويل عرض إلى مستند XPS باستخدام إعدادات مخصصة في C#:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // إنشاء كائن فئة TiffOptions
    XpsOptions options = new XpsOptions();

    // حفظ MetaFiles كـ PNG
    options.SaveMetafilesAsPng = true;

    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **الأسئلة المتداولة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم — Aspose.Slides يتيح لك التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة تطبيقات الويب، سلاسل المعالجة على الخادم، أو أي سيناريو يتطلب إرسال XPS دون التعامل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استثناؤها؟**

بشكل افتراضي، يتم تصيير الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) عبر [إعدادات التصدير](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) قبل حفظ إلى XPS، مما يضمن أن يحتوي الناتج على الصفحات التي تريدها بالضبط.