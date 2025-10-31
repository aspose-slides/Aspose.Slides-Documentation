---
title: تحويل عروض PowerPoint إلى XPS في Python
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/python-net/convert-powerpoint-to-xps/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- PowerPoint إلى XPS
- العرض التقديمي إلى XPS
- PPT إلى XPS
- PPTX إلى XPS
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحويل عروض PowerPoint PPT/PPTX إلى XPS عالي الجودة وغير مرتبط بالنظام الأساسي باستخدام Aspose.Slides في Python. احصل على دليل خطوة بخطوة وعينة شفرة."
---

## **حول XPS**
قامت Microsoft بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يتيح لك طباعة المحتوى عن طريق إخراج ملف مشابه جدًا لملف PDF. يعتمد تنسيق XPS على XML. يبقى تخطيط أو بنية ملف XPS كما هو على جميع أنظمة التشغيل والطابعات. 

## متى تستخدم تنسيق Microsoft XPS

{{% alert color="primary" %}} 

لمعرفة كيف يقوم Aspose.Slides بتحويل عرض PPT أو PPTX إلى تنسيق XPS، يمكنك الاطلاع على [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى تنسيق XPS. بهذه الطريقة، ستجد أنه من الأسهل حفظ المستندات ومشاركتها وطباعةها. 

تستمر Microsoft في تنفيذ دعم قوي لتنسيق XPS في Windows (حتى في Windows 10)، لذا قد ترغب في التفكير في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS هو الخيار الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** قارئ PDF متاح لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7** و **Windows Vista** يستخدمان تنسيق XPS الأصلي. تقدم هذه الأنظمة دعمًا أفضل لملفات XPS مقارنةً بـ PDF. 
  - **XPS:** عارض XPS مدمج وميزة الطباعة إلى XPS متاحة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):**<p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**الإخراج XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft في النهاية نفذت دعم عمليات الطباعة إلى PDF عبر ميزة Print to PDF في Windows 10. سابقًا، كان يُتوقع من المستخدمين طباعة المستندات عبر تنسيق XPS. 

## تحويل XPS باستخدام Aspose.Slides

في [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) لـ .NET، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) المتاحة في فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحويل العرض بالكامل إلى مستند XPS. 

عند تحويل عرض تقديمي إلى XPS، عليك حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

هذا المثال البرمجي بلغة Python يوضح كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("Convert_XPS.pptx")

# حفظ العرض التقديمي كملف XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات المخصصة**
هذا المثال البرمجي يوضح كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام إعدادات مخصصة في Python:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("Convert_XPS_Options.pptx")

# إنشاء كائن XpsOptions
options = slides.export.XpsOptions()

# حفظ ملفات Meta كـ PNG
options.save_metafiles_as_png = True

# حفظ العرض التقديمي كملف XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **الأسئلة الشائعة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم – يتيح لك Aspose.Slides التصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، أو خطوط الأنابيب على الخادم، أو أي سيناريو تريد فيه إرسال XPS دون التعامل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكنني استثناؤها؟**

بشكل افتراضي، يتم عرض الشرائح العادية (المظهر) فقط. يمكنك [تضمين أو استبعاد الشرائح المخفية](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) عبر [إعدادات التصدير](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) قبل الحفظ إلى XPS، مما يضمن أن الناتج يحتوي فقط على الصفحات التي تريدها.