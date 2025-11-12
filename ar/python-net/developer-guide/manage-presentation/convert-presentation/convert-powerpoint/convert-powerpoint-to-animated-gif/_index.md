---
title: "تحويل العروض التقديمية إلى صور GIF متحركة في بايثون"
linktitle: "العرض إلى GIF"
type: docs
weight: 65
url: /ar/python-net/convert-powerpoint-to-animated-gif/
keywords:
- "GIF متحرك"
- "تحويل PowerPoint"
- "تحويل OpenDocument"
- "تحويل العرض التقديمي"
- "تحويل الشريحة"
- "تحويل PPT"
- "تحويل PPTX"
- "تحويل ODP"
- "PowerPoint إلى GIF"
- "OpenDocument إلى GIF"
- "العرض التقديمي إلى GIF"
- "الشريحة إلى GIF"
- "PPT إلى GIF"
- "PPTX إلى GIF"
- "ODP إلى GIF"
- "الإعدادات الافتراضية"
- "الإعدادات المخصصة"
- "Python"
- "Aspose.Slides"
description: "قم بتحويل عروض PowerPoint (PPT, PPTX) وملفات OpenDocument (ODP) إلى صور GIF متحركة بسهولة باستخدام Aspose.Slides لبايثون. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض لك هذا المثال البرمجي بلغة بايثون كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية. 

{{% alert title="نصيحة" color="primary" %}} 
إذا كنت تفضل تخصيص معلمات الـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/) . راجع المثال البرمجي أدناه. 
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة**

يعرض لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في بايثون:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # حجم GIF الناتج  
options.default_delay = 2000 # المدة التي ستُعرض فيها كل شريحة قبل الانتقال إلى التالية
options.transition_fps = 35  # زيادة عدد الإطارات في الثانية لتحسين جودة حركة الانتقال

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="معلومات" color="info" %}}
قد ترغب في تجربة محول مجاني من [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره من قبل Aspose. 
{{% /alert %}}

## **الأسئلة المتكررة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [تكوين الخطوط الاحتياطية](/slides/ar/python-net/powerpoint-fonts/). سيستبدل Aspose.Slides الخطوط، لكن المظهر قد يختلف. بالنسبة للعلامة التجارية، تأكد دائمًا من توفر الأنواع المطلوبة من الخطوط بشكل صريح.

**هل يمكنني إضافة علامة مائية على إطارات GIF؟**

نعم. [أضف كائنًا/شعارًا شبه شفاف](/slides/ar/python-net/watermark/) إلى الشريحة الرئيسة أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.