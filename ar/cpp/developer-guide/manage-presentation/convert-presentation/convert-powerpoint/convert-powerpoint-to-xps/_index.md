---
title: تحويل عروض PowerPoint إلى XPS في C++
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/cpp/convert-powerpoint-to-xps
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى XPS
- العرض إلى XPS
- الشريحة إلى XPS
- PPT إلى XPS
- PPTX إلى XPS
- حفظ PPT كـ XPS
- حفظ PPTX كـ XPS
- تصدير PPT إلى XPS
- تصدير PPTX إلى XPS
- PowerPoint
- العرض
- C++
- Aspose.Slides
description: "قم بتحويل PowerPoint PPT/PPTX إلى XPS عالي الجودة غير مرتبط بمنصة في C++ باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينة الكود."
---
## **نظرة عامة**

Aspose.Slides يتيح لك تحويل عروض PowerPoint إلى XPS عن طريق حفظ ملف PPT أو PPTX بتنسيق XPS. يشرح هذا المقال متى قد يكون تنسيق XPS مفيدًا ويظهر كيفية إجراء التحويل باستخدام Aspose.Slides إما بإعدادات افتراضية أو إعدادات مخصصة لـ [XpsOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/xpsoptions/).

## **حول XPS**
مايكروسوفت طورت [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إخراج ملف مشابه جدًا لملف PDF. تنسيق XPS يعتمد على XML. يبقى تخطيط أو بنية ملف XPS ثابتًا على جميع أنظمة التشغيل والطابعات.

## **متى تستخدم تنسيق XPS من مايكروسوفت**

{{% alert color="info" %}} 

لمعرفة كيف يقوم Aspose.Slides بتحويل عرض PPT أو PPTX إلى تنسيق XPS، يمكنك زيارة [this free online converter app](https://products.aspose.app/slides/ar/conversion). 

{{% /alert %}} 

إذا رغبت في خفض تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى تنسيق XPS. بهذه الطريقة، سيكون من الأسهل حفظ مستنداتك، مشاركتها، وطباعةها.

مايكروسوفت تواصل تقديم دعم قوي لتنسيق XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في التفكير بحفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1، Windows 8، Windows 7، أو Windows Vista، فقد يكون XPS هو الخيار الأنسب لبعض العمليات.

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متوفرة. 
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر أنظمة التشغيل هذه أيضًا دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متوفرة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**الإخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

مايكروسوفت نفذت في النهاية دعم عمليات الطباعة إلى PDF عبر ميزة Print to PDF في Windows 10. في السابق، كان من المتوقع أن يقوم المستخدمون بطباعة المستندات عبر تنسيق XPS.

## **تحويل XPS باستخدام Aspose.Slides**

في [**Aspose.Slides**](https://products.aspose.com/slides/ar/cpp/) للغة C++، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) التي تقدمها فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation) لتحويل العرض بالكامل إلى مستند XPS.

عند تحويل عرض إلى XPS، يجب حفظ العرض باستخدام إحدى الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.export.xps_options))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.export.xps_options))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

يعرض هذا المثال البرمجي بلغة C++ كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
يعرض هذا المثال البرمجي كيفية تحويل عرض إلى مستند XPS باستخدام إعدادات مخصصة في C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// إنشاء كائن من فئة TiffOptions
auto options = System::MakeObject<XpsOptions>();

// حفظ ملفات Meta كـ PNG
options->set_SaveMetafilesAsPng(true);

// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **الأسئلة المتكررة**

### هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟

نعم—Aspose.Slides يتيح لك التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، خطوط الأنابيب على الخادم، أو أي سيناريو تريد فيه إرسال XPS دون التعامل مع نظام الملفات.

### هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكنني استثناؤها؟

افتراضيًا، يتم عرض الشرائح العادية (المشاهدة) فقط. يمكنك [include or exclude hidden slides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) من خلال [export settings](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تقصدها بالضبط.