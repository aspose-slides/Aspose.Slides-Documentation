---
title: تحويل PowerPoint إلى XPS 
type: docs
weight: 70
url: /net/convert-powerpoint-to-xps
keywords: "تحويل عرض PowerPoint, PowerPoint إلى XPS, PPT إلى XPS, PPTX إلى XPS, تحويل, C#, Csharp, .NET, Aspose.Slides"
description: "تحويل عرض PowerPoint إلى XPS باستخدام C# أو .NET."
---

## **حول XPS**
طورت Microsoft [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى من خلال إخراج ملف مشابه جدًا لـ PDF. تنسيق XPS يعتمد على XML. تبقى تخطيط أو بنية ملف XPS كما هي على جميع أنظمة التشغيل والطابعات. 

## متى يجب استخدام تنسيق Microsoft XPS

{{% alert color="primary" %}} 

لمعرفة كيف تقوم Aspose.Slides بتحويل عرض PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة، ستجد أنه من الأسهل حفظ ومشاركة وطباعة مستنداتك. 

تستمر Microsoft في تنفيذ دعم قوي لـ XPS في Windows (حتى في Windows 10)، لذا قد ترغب في considerar حفظ الملفات بهذا الشكل. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأفضل لديك لعمليات معينة. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** متوفر عارض/قارئ XPS وميزة الطباعة إلى XPS. 
  - **PDF**: متوفر قارئ PDF ولكن لا توجد ميزة الطباعة إلى PDF. 

-  **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر هذه الأنظمة التشغيلية أيضًا دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS**: متوفر عارض XPS وميزة الطباعة إلى XPS. 
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة الطباعة إلى PDF. 

|<p>**مدخل PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**مخرج XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



في النهاية، نفذت Microsoft دعم العمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. سابقًا، كان من المتوقع من المستخدمين طباعة المستندات من خلال تنسيق XPS. 

## تحويل XPS باستخدام Aspose.Slides

في [**Aspose.Slides**](https://products.aspose.com/slides/net/) لـ .NET، يمكنك استخدام [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) الطريقة التي تعرضها [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS. 

عند تحويل العرض التقديمي إلى XPS، عليك حفظ العرض باستخدام أي من هذه الإعدادات:

- إعدادات افتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- إعدادات مخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

يوضح هذا الكود النموذجي باللغة C# كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:

```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
يوضح هذا الكود النموذجي كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات مخصصة في C#:

```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // إنشاء كائن من فئة XpsOptions
    XpsOptions options = new XpsOptions();

    // حفظ الملفات كصور PNG
    options.SaveMetafilesAsPng = true;

    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```