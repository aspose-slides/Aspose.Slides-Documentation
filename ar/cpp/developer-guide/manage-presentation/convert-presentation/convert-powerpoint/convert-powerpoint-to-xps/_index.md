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
- العرض التقديمي
- C++
- Aspose.Slides
description: "تحويل PowerPoint PPT/PPTX إلى XPS عالي الجودة، مستقل عن النظام الأساسي في C++ باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينات من الشيفرة."
---

## **حول XPS**
قامت Microsoft بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/).  يتيح لك طباعة المحتوى عن طريق إخراج ملف يشبه كثيرًا ملف PDF. يعتمد تنسيق XPS على XML. يبقى تخطيط أو بنية ملف XPS كما هو على جميع أنظمة التشغيل والطابعات. 

## **متى يجب استخدام تنسيق XPS من Microsoft**

{{% alert color="primary" %}} 
لمعرفة كيفية تحويل Aspose.Slides لعروض PPT أو PPTX إلى تنسيق XPS، يمكنك زيارة [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض PowerPoint من Microsoft إلى تنسيق XPS. بهذه الطريقة، ستجد أنه من الأسهل حفظ مستنداتك ومشاركتها وطباعةها. 

تستمر Microsoft في تقديم دعم قوي لتنسيق XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يقدم Windows 8 دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: قارئ PDF متاح لكن لا توجد ميزة الطباعة إلى PDF. 

- **Windows 7 and Windows Vista** تستخدم تنسيق XPS الأصلي. توفر أنظمة التشغيل هذه أيضًا دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS**: عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة الطباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**الإخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

في النهاية، نفذت Microsoft دعم عمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. كان من المتوقع سابقًا أن يقوم المستخدمون بطباعة المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**
في [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) للغة C++، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) المعروضة من قبل الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل العرض الكامل إلى مستند XPS. 

عند تحويل عرض إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**
يعرض لك هذا المثال البرمجي بلغة C++ كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:
``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
يعرض لك هذا المثال البرمجي كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات المخصصة في C++:
``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// إنشاء فئة TiffOptions
auto options = System::MakeObject<XpsOptions>();

// حفظ ملفات Meta ك PNG
options->set_SaveMetafilesAsPng(true);

// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**
نعم — يتيح لك Aspose.Slides التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات عبر الويب، خطوط الأنابيب على الخادم، أو أي سيناريو ترغب فيه بإرسال XPS دون التعامل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استثناؤها؟**
بشكل افتراضي، يتم عرض الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) عبر [إعدادات التصدير](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) قبل الحفظ إلى XPS، ما يضمن أن يحتوي الناتج على الصفحات التي تقصدها بالضبط.