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
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل ملفات PowerPoint PPT/PPTX إلى XPS عالي الجودة وذو استقلالية عن المنصة في .NET باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينة كود C#."
---

## **حول XPS**
قامت Microsoft بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/).​ يسمح لك بطباعة المحتوى عن طريق إنشاء ملف يشبه إلى حد كبير ملف PDF. يُستند تنسيق XPS إلى XML. يبقى تخطيط أو بنية ملف XPS هو نفسه على جميع أنظمة التشغيل والطابعات. 

## **متى تستخدم تنسيق Microsoft XPS**

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides للعرض التقديمي PPT أو PPTX إلى تنسيق XPS، يمكنك زيارة [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض PowerPoint إلى تنسيق XPS. سيسهل ذلك حفظ المستندات ومشاركتها وطبعها. 

ما زالت Microsoft تدعم XPS بقوة في Windows (حتى في Windows 10)، لذا قد ترغب في حفظ الملفات بهذا التنسيق. إذا كنت تستخدم Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأنسب لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** متوفر عارض/قاريء XPS مدمج وميزة الطباعة إلى XPS. 
  - **PDF:** متوفر قارئ PDF لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر هذه الأنظمة دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** متوفر عارض XPS مدمج وميزة الطباعة إلى XPS. 
  - **PDF:** لا يوجد قارئ PDF ولا ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



في النهاية، نفذت Microsoft دعم عمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. سابقًا، كان يُتوقع من المستخدمين طباعة المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/net/) لـ .NET، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) التي توفرها فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS. 

عند تحويل عرض تقديمي إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

هذا المثال البرمجي بلغة C# يوضح كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```



### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
هذا المثال البرمجي يوضح كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات مخصصة في C#:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // إنشاء فئة TiffOptions
    XpsOptions options = new XpsOptions();

    // حفظ MetaFiles كـ PNG
    options.SaveMetafilesAsPng = true;

    // حفظ العرض التقديمي إلى مستند XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **الأسئلة الشائعة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—تمكّن Aspose.Slides من التصدير مباشرة إلى تدفق، وهو ما يناسب واجهات برمجة التطبيقات على الويب، أو خطوط الأنابيب على الخادم، أو أي سيناريو تريد فيه إرسال XPS دون التعامل مع نظام الملفات.

**هل تُنقل الشرائح المخفية إلى XPS، وهل يمكنني استثناؤها؟**

بشكل افتراضي، تُظهر فقط الشرائح العادية (المرئية). يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) عبر [إعدادات التصدير](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) قبل الحفظ إلى XPS، ما يضمن أن يحتوي المخرجات على الصفحات التي تريدها بالضبط.