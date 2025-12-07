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
description: "تحويل PowerPoint PPT/PPTX إلى XPS عالي الجودة ومستقل عن المنصات في C++ باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وعينة من الشيفرة."
---

## **حول XPS**
قامت Microsoft بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إخراج ملف مشابه جدًا لملف PDF. تنسيق XPS مُستند إلى XML. يبقى تنسيق أو بنية ملف XPS كما هو على جميع أنظمة التشغيل والطابعات. 

## **متى يتم استخدام تنسيق Microsoft XPS**
{{% alert color="primary" %}} 
لرؤية كيف يقوم Aspose.Slides بتحويل عروض PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى تنسيق XPS. بهذه الطريقة، سيكون من الأسهل حفظ المستندات ومشاركتها وطباعةها. 

تستمر Microsoft في تقديم دعم قوي لتنسيق XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فإن XPS قد يكون خيارك الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح ولكن لا توجد ميزة الطباعة إلى PDF. 

- **Windows 7 و Windows Vista** يستخدمان تنسيق XPS الأصلي. توفر أنظمة التشغيل هذه أيضًا دعمًا أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS**: عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة الطباعة إلى PDF. 

|<p>**إدخال PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)</p>|<p>**الإخراج XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)</p>|
| :- | :- |

في النهاية، نفذت Microsoft دعم عمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. سابقًا، كان يُتوقع من المستخدمين طباعة المستندات عبر تنسيق XPS. 

## **تحويل XPS باستخدام Aspose.Slides**
في [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) للغة C++، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) التي تُعرضها فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل العرض الكامل إلى مستند XPS. 

عند تحويل عرض إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**
يعرض هذا المثال البرمجي بلغة C++ كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات القياسية:
``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **تحويل العروض إلى XPS باستخدام الإعدادات المخصصة**
يعرض هذا المثال البرمجي كيفية تحويل عرض إلى مستند XPS باستخدام الإعدادات المخصصة في C++:
``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// إنشاء كائن TiffOptions
auto options = System::MakeObject<XpsOptions>();

// حفظ ملفات MetaFiles كـ PNG
options->set_SaveMetafilesAsPng(true);

// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **الأسئلة الشائعة**
**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—يسمح لك Aspose.Slides بالتصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، خطوط الأنابيب على الخادم، أو أي سيناريو ترغب فيه بإرسال XPS دون الحاجة إلى التعامل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استثنائها؟**

افتراضيًا، يتم عرض الشرائح العادية (المرئية) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) عبر [إعدادات التصدير](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) قبل حفظها كـ XPS، مما يضمن أن يحتوي الناتج على الصفحات التي تقصدها بالضبط.