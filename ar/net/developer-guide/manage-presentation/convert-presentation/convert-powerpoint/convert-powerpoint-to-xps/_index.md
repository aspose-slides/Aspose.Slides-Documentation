---
title: تحويل PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/net/convert-powerpoint-to-xps
keywords: "تحويل عرض PowerPoint, PowerPoint إلى XPS, PPT إلى XPS, PPTX إلى XPS, تحويل, C#, Csharp, .NET, Aspose.Slides"
description: "تحويل عرض PowerPoint إلى XPS باستخدام C# أو .NET."
---

## **حول XPS**
مايكروسوفت طورت [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يتيح لك طباعة المحتوى عن طريق إخراج ملف مشابه جدًا لملف PDF. تنسيق XPS مبني على XML. يظل تخطيط أو بنية ملف XPS نفسه على جميع أنظمة التشغيل والطابعات. 

## **متى يستخدم تنسيق Microsoft XPS**

{{% alert color="primary" %}} 

لمعرفة كيفية تحويل Aspose.Slides لعروض PPT أو PPTX إلى تنسيق XPS، يمكنك زيارة [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا أردت تقليل تكلفة التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى تنسيق XPS. بهذه الطريقة، سيكون من الأسهل حفظ مستنداتك ومشاركتها وطباعةها. 

مايكروسوفت تواصل تقديم دعم قوي لـ XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة معيارية من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

-  **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر أنظمة التشغيل هذه أيضًا دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS**: عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft في النهاية نفذت دعم عمليات الطباعة إلى PDF من خلال ميزة الطباعة إلى PDF في Windows 10. في السابق، كان من المتوقع أن يقوم المستخدمون بطباعة المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/net/) لـ .NET، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) المعروضة بواسطة فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض بالكامل إلى مستند XPS. 

عند تحويل عرض إلى XPS، عليك حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

هذا المثال البرمجي بلغة C# يوضح كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```



### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
هذا المثال البرمجي يوضح كيفية تحويل عرض إلى مستند XPS باستخدام إعدادات مخصصة بلغة C#:
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


## **FAQ**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—تتيح لك Aspose.Slides تصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، وسلاسل المعالجة على الخادم، أو أي سيناريو تريد فيه إرسال XPS دون التعامل مع نظام الملفات.

**هل تُنقل الشرائح المخفية إلى XPS، وهل يمكن استبعادها؟**

بشكل افتراضي، يتم تصيير الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) عبر [إعدادات التصدير](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تقصدها بالضبط.