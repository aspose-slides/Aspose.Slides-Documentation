---
title: "تحويل عروض PowerPoint إلى XPS في C++"
linktitle: "PowerPoint إلى XPS"
type: docs
weight: 70
url: /ar/cpp/convert-powerpoint-to-xps
keywords:
- "تحويل PowerPoint"
- "تحويل العرض التقديمي"
- "تحويل الشريحة"
- "تحويل PPT"
- "تحويل PPTX"
- "PowerPoint إلى XPS"
- "العرض التقديمي إلى XPS"
- "الشريحة إلى XPS"
- "PPT إلى XPS"
- "PPTX إلى XPS"
- "حفظ PPT كـ XPS"
- "حفظ PPTX كـ XPS"
- "تصدير PPT إلى XPS"
- "تصدير PPTX إلى XPS"
- "PowerPoint"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "تحويل PowerPoint PPT/PPTX إلى XPS عالي الجودة ومستقل عن النظام الأساسي في C++ باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينة الشفرة."
---

## **حول XPS**
قامت Microsoft بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إخراج ملف شبيه جدًا بـ PDF. تنسيق XPS مبني على XML. يبقى تخطيط أو بنية ملف XPS كما هي على جميع أنظمة التشغيل والطابعات. 

## **متى تستخدم تنسيق XPS من Microsoft**

{{% alert color="primary" %}} 

لمعرفة كيفية تحويل Aspose.Slides للعرض التقديمي PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني لتحويل الملفات عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint التقديمي إلى تنسيق XPS. بهذه الطريقة، ستجد حفظ المستندات ومشاركتها وطباعةها أسهل. 

ما زالت Microsoft تدعم XPS بقوة في Windows (حتى في Windows 10)، لذا قد ترغب في التفكير بحفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1، Windows 8، Windows 7، و Windows Vista، فقد يكون XPS هو الخيار الأمثل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنةً بملفات PDF.  
  - **XPS:** عارض/قارئ XPS مدمج ومتاحة ميزة الطباعة إلى XPS.  
  - **PDF**: قارئ PDF متوفر لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر هذه الأنظمة دعمًا أفضل لملفات XPS مقارنةً بـ PDFs.  
  - **XPS**: عارض XPS مدمج ومتاحة ميزة الطباعة إلى XPS.  
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)</p>|<p>**إخراج XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)</p>|
| :- | :- |

في النهاية قامت Microsoft بتنفيذ دعم عمليات الطباعة في PDF عبر ميزة الطباعة إلى PDF في Windows 10. سابقًا، كان من المتوقع أن يقوم المستخدمون بطباعة المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) لـ C++، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) المعروضة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS. 

عند تحويل عرض تقديمي إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

هذا الكود النموذجي في C++ يوضح لك كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:
``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Saving the presentation to XPS document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات المخصصة**

هذا الكود النموذجي يوضح لك كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات المخصصة في C++:
``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// إنشاء فئة TiffOptions
auto options = System::MakeObject<XpsOptions>();

// حفظ ملفات MetaFiles كـ PNG
options->set_SaveMetafilesAsPng(true);

// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم — يتيح لك Aspose.Slides التصدير مباشرةً إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، خطوط أنابيب الخادم، أو أي سيناريو ترغب فيه بإرسال XPS دون التعامل مع نظام الملفات.

**هل تُنقل الشرائح المخفية إلى XPS، وهل يمكن استثناؤها؟**

بشكل افتراضي، يتم تصيير الشرائح العادية (المرئية) فقط. يمكنك [إدراج أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) من خلال [إعدادات التصدير](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) قبل حفظ إلى XPS، ما يضمن أن يحتوي الناتج على الصفحات التي تقصدها بالضبط.