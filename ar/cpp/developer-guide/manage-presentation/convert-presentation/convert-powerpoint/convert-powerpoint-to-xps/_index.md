---
title: تحويل عروض PowerPoint إلى XPS في C++
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "قم بتحويل ملفات PowerPoint PPT/PPTX إلى XPS عالي الجودة وغير معتمد على منصة في C++ باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينات من الكود."
---

## **حول XPS**
قامت مايكروسوفت بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يتيح لك طباعة المحتوى عن طريق إخراج ملف يشبه ملف PDF إلى حد كبير. يعتمد تنسيق XPS على XML. يبقى تخطيط أو بنية ملف XPS نفسه على جميع أنظمة التشغيل والطابعات.

## **متى تستخدم تنسيق Microsoft XPS**

{{% alert color="primary" %}} 
لرؤية كيفية تحويل Aspose.Slides للعرض التقديمي PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة سيكون من الأسهل حفظ مستنداتك ومشاركتها وطباعةها.

مايكروسوفت تستمر في تنفيذ دعم قوي لـ XPS في Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأنسب لبعض العمليات.

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعماً أفضل لملفات XPS مما يوفره لملفات PDF. 
  - **XPS:** عارض/قاريء XPS مدمج وميزة الطباعة إلى XPS متوفرة. 
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7** و **Windows Vista** يستخدمان تنسيق XPS الأصلي. هذه الأنظمة توفر أيضاً دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متوفرة. 
  - **PDF:** لا قارئ PDF. لا ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

في وقت لاحق، نفذت مايكروسوفت دعم عمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. في السابق، كان من المتوقع أن يطبع المستخدمون المستندات عبر تنسيق XPS.

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) للغة C++، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) المعروضة بواسطة فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS.

عند تحويل عرض تقديمي إلى XPS، عليك حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

يظهر هذا المثال في C++ كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:
``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات المخصصة**

يظهر هذا المثال كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات مخصصة في C++:
``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// إنشاء كائن من فئة TiffOptions
auto options = System::MakeObject<XpsOptions>();

// حفظ ملفات MetaFiles كـ PNG
options->set_SaveMetafilesAsPng(true);

// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—تتيح لك Aspose.Slides التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، أو خطوط أنابيب الخادم، أو أي سيناريو تحتاج فيه إلى إرسال XPS دون التعامل مع نظام الملفات.

**هل تُنقل الشرائح المخفية إلى XPS، وهل يمكن استثناؤها؟**

بشكل افتراضي، يتم عرض الشرائح العادية (المظهر) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) من خلال [إعدادات التصدير](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تقصدها بالضبط.