---
title: استبدال الخط
type: docs
weight: 60
url: /python-net/font-replacement/
keywords: "خط, استبدال الخط, عرض PowerPoint, بايثون, Aspose.Slides لـ بايثون عبر .NET"
description: "استبدال الخطوط بشكل صريح في PowerPoint باستخدام بايثون"
---

إذا غيرت رأيك بشأن استخدام خط معين، يمكنك استبدال هذا الخط بخط آخر. سيتم استبدال جميع حالات الخط القديم بالخط الجديد.

تتيح لك Aspose.Slides استبدال خط بهذه الطريقة:

1. تحميل العرض التقديمي المعني.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. استبدال الخط.
5. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود بلغة بايثون يُظهر استبدال الخط:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# يحمل عرض تقديمي
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # يحمل الخط المصدر الذي سيتم استبداله
    sourceFont = slides.FontData("Arial")

    # يحمل الخط الجديد
    destFont = slides.FontData("Times New Roman")

    # يستبدل الخطوط
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # يحفظ العرض التقديمي
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ملاحظة" color="warning" %}} 

لتعيين قواعد تحدد ما يحدث في ظروف معينة (إذا كان لا يمكن الوصول إلى خط معين، على سبيل المثال)، انظر [**استبدال الخط**](/slides/python-net/font-substitution/). 

{{% /alert %}}