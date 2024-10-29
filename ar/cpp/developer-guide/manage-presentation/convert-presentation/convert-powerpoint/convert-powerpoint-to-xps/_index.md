---
title: تحويل PowerPoint إلى XPS 
type: docs
weight: 70
url: /ar/cpp/convert-powerpoint-to-xps
keywords: "تحويل, PowerPoint إلى XPS, تحويل, PPT إلى XPS, PPTX إلى XPS"
description: "تحويل PowerPoint PPT و PPTX إلى مستند XPS باستخدام واجهة برمجة تطبيقات Aspose.Slides."
---

## **حول XPS**
طورت مايكروسوفت [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إخراج ملف مشابه جداً لملف PDF. يعتمد تنسيق XPS على XML. تظل تخطيط أو بنية ملف XPS كما هي في جميع أنظمة التشغيل والطابعات.

## متى تستخدم تنسيق Microsoft XPS

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides لعرض PPT أو PPTX إلى تنسيق XPS، يمكنك التحقق من [هذه الأداة المجانية للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة، سيكون من الأسهل عليك حفظ ومشاركة وطباعة مستنداتك.

تواصل مايكروسوفت تقديم دعم قوي لـ XPS في Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 وWindows 8 وWindows 7 وWindows Vista، فقد يكون XPS هو أفضل خيار لك لبعض العمليات.

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة معيارية من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مما يفعله لملفات PDF.
  - **XPS:** متصفح/قارئ XPS مُدمج وميزة الطباعة إلى XPS متاحة.
  - **PDF**: قارئ PDF متاح ولكن لا توجد ميزة الطباعة إلى PDF.

- **Windows 7 وWindows Vista** يستخدمان تنسيق XPS الأصلي. توفر هذه الأنظمة أيضًا دعمًا أفضل لملفات XPS مما تفعله لملفات PDF.
  - **XPS**: قارئ XPS مُدمج وميزة الطباعة إلى XPS متاحة.
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة الطباعة إلى PDF.

|<p>**مدخل PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**خرج XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



في النهاية، نفذت مايكروسوفت دعم عمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في Windows 10. سابقًا، كان يُتوقع من المستخدمين طباعة المستندات من خلال تنسيق XPS.

## تحويل XPS باستخدام Aspose.Slides

في [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) لـ C++، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) التي تقدمها فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) لتحويل العرض التقديمي بالكامل إلى مستند XPS.

عند تحويل عرض تقديمي إلى XPS، يجب عليك حفظ العرض التقديمي باستخدام أحد هذه الإعدادات:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- إعدادات مخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

هذا الكود النموذجي في C++ يوضح لك كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:

``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **تحويل العروض التقديمية إلى XPS باستخدام إعدادات مخصصة**
هذا الكود النموذجي يوضح لك كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات مخصصة في C++:

``` cpp
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// إنشاء فئة TiffOptions
auto options = System::MakeObject<XpsOptions>();

// حفظ ملفات التعريف كـ PNG
options->set_SaveMetafilesAsPng(true);

// حفظ العرض التقديمي إلى مستند XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```