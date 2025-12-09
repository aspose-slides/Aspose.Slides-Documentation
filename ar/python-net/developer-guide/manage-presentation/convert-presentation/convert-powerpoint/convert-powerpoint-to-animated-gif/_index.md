---
title: تحويل العروض التقديمية إلى GIF متحرك في بايثون
linktitle: العرض التقديمي إلى GIF
type: docs
weight: 65
url: /ar/python-net/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- تحول ODP
- PowerPoint إلى GIF
- OpenDocument إلى GIF
- العرض التقديمي إلى GIF
- الشريحة إلى GIF
- PPT إلى GIF
- PPTX إلى GIF
- ODP إلى GIF
- الإعدادات الافتراضية
- الإعدادات المخصصة
- Python
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint (PPT، PPTX) وملفات OpenDocument (ODP) إلى GIF متحركة بسهولة باستخدام Aspose.Slides للبايثون. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض لك هذا الكود التجريبي بلغة بايثون كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية.

{{%  alert  title="TIP"  color="primary"  %}} 
إذا كنت تفضل تخصيص المعلمات للـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/). راجع الكود التجريبي أدناه. 
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

يعرض لك هذا الكود التجريبي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في بايثون:
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # حجم GIF الناتج  
options.default_delay = 2000 # المدة التي تُعرض فيها كل شريحة حتى يتم تغييرها إلى التالية
options.transition_fps = 35  # زيادة FPS لتحسين جودة حركة الانتقال

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```


{{% alert title="Info" color="info" %}}
قد ترغب في تجربة محول مجاني من النص إلى GIF تم تطويره بواسطة Aspose. 
{{% /alert %}}

## **الأسئلة الشائعة**

**ماذا لو لم يتم تثبيت الخطوط المستخدمة في العرض التقديمي على النظام؟**

قم بتثبيت الخطوط المفقودة أو [قم بتكوين خطوط الاحتياطي](/slides/ar/python-net/powerpoint-fonts/). سيقوم Aspose.Slides باستبدالها، لكن قد يختلف المظهر. بالنسبة للعلامة التجارية، تأكد دائمًا من توفر الخطوط المطلوبة بشكل صريح.

**هل يمكنني إضافة علامة مائية على إطارات GIF؟**

نعم. [أضف كائنًا/شعارًا شبه شفاف](/slides/ar/python-net/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.