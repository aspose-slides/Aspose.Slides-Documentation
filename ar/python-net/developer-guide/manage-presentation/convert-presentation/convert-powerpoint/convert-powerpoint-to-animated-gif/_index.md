---
title: تحويل PowerPoint إلى GIF متحرك
type: docs
weight: 65
url: /python-net/convert-powerpoint-to-animated-gif/
keywords: "تحويل PowerPoint, PPT, PPTX, GIF متحرك, PPT إلى GIF متحرك, PPTX إلى GIF متحرك, بايثون, الإعدادات الافتراضية, الإعدادات المخصصة"
description: "تحويل عرض PowerPoint إلى GIF متحرك: PPT إلى GIF, PPTX إلى GIF في بايثون"
---

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية ##

يعرض لك هذا الكود عينات في بايثون كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية.

{{%  alert  title="نصيحة"  color="primary"  %}} 

إذا كنت تفضل تخصيص المعلمات لـ GIF، يمكنك استخدام فئة [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/). انظر الكود النموذجي أدناه.

{{% /alert %}} 

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة ##
يعرض لك هذا الكود العينات كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات المخصصة في بايثون:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # حجم الـ GIF الناتج  
options.default_delay = 2000 # مدة عرض كل شريحة حتى يتم الانتقال إلى الشريحة التالية
options.transition_fps = 35  # زيادة FPS لتحسين جودة انتقال الرسوم المتحركة

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="معلومات" color="info" %}}

قد ترغب في الاطلاع على مُحول [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) مجاني تم تطويره بواسطة Aspose. 

{{% /alert %}}