---
title: توطين العرض
type: docs
weight: 100
url: /python-net/presentation-localization/
keywords: "تغيير اللغة، التدقيق الإملائي، فحص الإملاء، مدقق الإملاء، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "تغيير أو فحص اللغة في عرض PowerPoint. فحص إملائي للنص في بايثون"
---
## **تغيير اللغة لعرض النص والشكل**
- أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- احصل على مرجع الشريحة باستخدام فهرسها.
- أضف شكل تلقائي من نوع المستطيل إلى الشريحة.
- أضف بعض النصوص إلى إطار النص.
- ضبط معرّف اللغة على النص.
- اكتب العرض كملف PPTX.

يتم توضيح تنفيذ الخطوات أعلاه في المثال أدناه.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("نص لتطبيق لغة التدقيق الإملائي")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```