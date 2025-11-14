---
title: الخط الافتراضي
type: docs
weight: 30
url: /ar/python-net/default-font/
keywords: "خطوط، خطوط افتراضية، تقديم عرض باوربوينت بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "خطوط باوربوينت الافتراضية في بايثون"
---

## **استخدام الخطوط الافتراضية لتقديم العرض**
تتيح لك Aspose.Slides تعيين الخط الافتراضي لتقديم العرض إلى PDF، XPS أو صور مصغرة. توضح هذه المقالة كيفية تعريف DefaultRegular Font و DefaultAsian Font لاستخدامها كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من الأدلة الخارجية باستخدام Aspose.Slides لـ بايثون عبر .NET API:

1. إنشاء مثيل من LoadOptions.
1. تعيين DefaultRegularFont إلى الخط المرغوب. في المثال التالي، لقد استخدمت Wingdings.
1. تعيين DefaultAsianFont إلى الخط المرغوب. لقد استخدمت Wingdings في العينة التالية.
1. تحميل العرض باستخدام Presentation وتعيين خيارات التحميل.
1. الآن، قم بإنشاء صورة مصغرة للشريحة، PDF و XPS للتحقق من النتائج.

تنفيذ ما سبق موضح أدناه.

```py
import aspose.slides as slides

# استخدم خيارات التحميل لتعريف الخطوط الافتراضية العادية والآسيوية
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# تحميل العرض
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # توليد صورة مصغرة للشريحة
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # توليد PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # توليد XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```