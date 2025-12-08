---
title: تحويل عروض PowerPoint إلى XPS باستخدام Python
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
- Python
- Aspose.Slides
description: "تحويل ملفات PowerPoint PPT/PPTX إلى XPS عالي الجودة وغير معتمد على نظام التشغيل باستخدام Python و Aspose.Slides. احصل على دليل خطوة بخطوة وعينات الكود."
---

## **حول XPS**
قامت مايكروسوفت بتطوير [XPS](https://docs.fileformat.com/page-description-language/xps/) كبديل لـ[PDF](https://docs.fileformat.com/pdf/). يسمح لك بطباعة المحتوى عن طريق إنشاء ملف يشبه ملف PDF إلى حد كبير. تنسيق XPS مبني على XML. يبقى تخطيط أو بنية ملف XPS نفسه على جميع أنظمة التشغيل والطابعات. 

## متى يجب استخدام تنسيق XPS من مايكروسوفت

{{% alert color="primary" %}} 
لمعرفة كيفية تحويل Aspose.Slides لعرض PPT أو PPTX إلى تنسيق XPS، يمكنك زيارة [هذا التطبيق المجاني للتحويل عبر الإنترنت](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

إذا كنت ترغب في تقليل تكاليف التخزين، يمكنك تحويل عرض Microsoft PowerPoint إلى تنسيق XPS. بهذه الطريقة سيكون من الأسهل حفظ المستندات ومشاركتها وطباعةها. 

مايكروسوفت تستمر في تقديم دعم قوي لتنسيق XPS في نظام Windows (حتى في Windows 10)، لذا قد ترغب في حفظ الملفات بهذا التنسيق. إذا كنت تتعامل مع Windows 8.1 أو Windows 8 أو Windows 7 أو Windows Vista، فقد يكون XPS خيارك الأفضل لبعض العمليات. 

- **Windows 8** يستخدم تنسيق OXPS (Open XPS) لملفات XPS. OXPS هو نسخة موحدة من تنسيق XPS الأصلي. يوفر Windows 8 دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض/قارئ XPS مدمج وميزة طباعة إلى XPS متوفرة. 
  - **PDF:** قارئ PDF متوفر لكن لا توجد ميزة طباعة إلى PDF. 

- **Windows 7 وWindows Vista** يستخدمان تنسيق XPS الأصلي. كذلك توفر هاتان الأنظمة دعماً أفضل لملفات XPS مقارنة بملفات PDF. 
  - **XPS:** عارض XPS مدمج وميزة طباعة إلى XPS متوفرة. 
  - **PDF:** لا يوجد قارئ PDF. لا توجد ميزة طباعة إلى PDF. 

|<p>**إدخال PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**إخراج XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

قامت مايكروسوفت في النهاية بتطبيق دعم عمليات الطباعة إلى PDF عبر ميزة Print to PDF في Windows 10. في السابق كان يُتوقع من المستخدمين طباعة المستندات عبر تنسيق XPS. 

## تحويل XPS باستخدام Aspose.Slides

في [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) لـ.NET، يمكنك استخدام طريقة [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) المعروضة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحويل العرض بالكامل إلى مستند XPS. 

عند تحويل عرض تقديمي إلى XPS، يجب حفظ العرض باستخدام أحد الإعدادات التالية:

- الإعدادات الافتراضية (بدون [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- الإعدادات المخصصة (مع [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات الافتراضية**

يظهر هذا الكود النموذجي بلغة Python كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات القياسية:
```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("Convert_XPS.pptx")

# حفظ العرض التقديمي إلى مستند XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **تحويل العروض التقديمية إلى XPS باستخدام الإعدادات المخصصة**
يظهر هذا الكود النموذجي كيفية تحويل عرض تقديمي إلى مستند XPS باستخدام الإعدادات المخصصة في Python:
```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
pres = slides.Presentation("Convert_XPS_Options.pptx")

# إنشاء فئة TiffOptions
options = slides.export.XpsOptions()

# حفظ ملفات MetaFiles بصيغة PNG
options.save_metafiles_as_png = True

# حفظ العرض التقديمي إلى مستند XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم—Aspose.Slides يتيح لك تصدير مباشرة إلى تدفق، وهو مثالي لواجهات برمجة التطبيقات على الويب، أو خطوط الأنابيب على الخادم، أو أي سيناريو تحتاج فيه إلى إرسال XPS دون التعامل مع نظام الملفات.

**هل يتم نقل الشرائح المخفية إلى XPS، وهل يمكن استبعادها؟**

بشكل افتراضي، يتم تصيير الشرائح العادية (المرئية) فقط. يمكنك [include or exclude hidden slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) من خلال [export settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) قبل الحفظ إلى XPS، لضمان أن يحتوي الناتج على الصفحات التي تريدها بالضبط.