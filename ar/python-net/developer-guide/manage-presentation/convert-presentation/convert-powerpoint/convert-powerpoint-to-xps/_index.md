---
title: تحويل عروض PowerPoint إلى XPS في بايثون
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
- العرض التقديمي
- بايثون
- Aspose.Slides
description: تحويل عروض PowerPoint (PPT/PPTX) إلى XPS عالي الجودة ومستقل عن النظام الأساسي في Python باستخدام Aspose.Slides. احصل على دليل خطوة بخطوة وكود مثال.
---

## **حول XPS**
طورت مايكروسوفت [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ [PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى من خلال إخراج ملف مشابه جدًا لملف PDF. يعتمد تنسيق XPS على XML. يظل تخطيط أو هيكل ملف XPS كما هو في جميع أنظمة التشغيل والطابعات. 

## متى تستخدم تنسيق XPS من مايكروسوفت

{{% alert color="primary" %}} 

لمعرفة كيف تقوم Aspose.Slides بتحويل عرض PPT أو PPTX إلى تنسيق XPS، يمكنك التحقق من [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint الخاص بك إلى تنسيق XPS. بهذه الطريقة، ستجد أنه من الأسهل حفظ ومشاركة وطباعة مستنداتك. 

تواصل مايكروسوفت تنفيذ دعم قوي لـ XPS في ويندوز (حتى في ويندوز 10)، لذا قد ترغب في التفكير في حفظ الملفات إلى هذا التنسيق. إذا كنت تتعامل مع ويندوز 8.1 أو ويندوز 8 أو ويندوز 7 أو ويندوز فيستا، فإن XPS قد يكون في الواقع الخيار الأفضل لك لبعض العمليات. 

- **ويندوز 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر ويندوز 8 دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مضمن وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: قارئ PDF متاح ولكن لا توجد ميزة الطباعة إلى PDF. 

- **ويندوز 7 وويندوز فيستا** يستخدمان تنسيق XPS الأصلي. توفر هذه الأنظمة تشغيل أيضًا دعمًا أفضل لملفات XPS مقارنةً بملفات PDF. 
  - **XPS**: عارض XPS مضمن وميزة الطباعة إلى XPS متاحة. 
  - **PDF**: لا يوجد قارئ PDF. لا توجد ميزة الطباعة إلى PDF. 

|<p>**الإدخال PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**الإخراج XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

نفذت مايكروسوفت في النهاية دعمًا لعمليات الطباعة في PDF من خلال ميزة الطباعة إلى PDF في ويندوز 10. كان من المتوقع من المستخدمين سابقًا طباعة المستندات من خلال تنسيق XPS. 

## تحويل XPS باستخدام Aspose.Slides

في [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) لـ .NET، يمكنك استخدام [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) الطريقة المقدمة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحويل العرض التقديمي بالكامل إلى مستند XPS. 

عند تحويل عرض تقديمي إلى XPS، يجب عليك حفظ العرض التقديمي باستخدام أي من هذه الإعدادات:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

يوضح هذا الكود المصدري في بايثون كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("Convert_XPS.pptx")

# حفظ العرض التقديمي إلى مستند XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات المخصصة**
يظهر هذا الكود المصدري كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات المخصصة في بايثون:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("Convert_XPS_Options.pptx")

# إنشاء كائن من فئة TiffOptions
options = slides.export.XpsOptions()

# حفظ ملفات الميتا كـ PNG
options.save_metafiles_as_png = True

# حفظ العرض التقديمي إلى مستند XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```