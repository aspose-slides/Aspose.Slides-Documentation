---
title: أتمتة توطين العروض التقديمية باستخدام بايثون
linktitle: توطين العروض التقديمية
type: docs
weight: 100
url: /ar/python-net/presentation-localization/
keywords:
- تغيير اللغة
- التدقيق الإملائي
- معرف اللغة
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "أتمتة توطين شرائح PowerPoint وOpenDocument في بايثون باستخدام Aspose.Slides، مع أمثلة شيفرة عملية ونصائح لتسريع النشر العالمي."
---

## **تغيير اللغة للعرض ونص الشكل**
- إنشاء مثيل من فئة [عرض](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- الحصول على مرجع شريحة باستخدام فهرستها.
- إضافة AutoShape من نوع مستطيل إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- تعيين معرف اللغة للنص.
- حفظ العرض كملف PPTX.

يتم توضيح تنفيذ الخطوات السابقة في المثال أدناه.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يُؤدي معرف اللغة إلى ترجمة النص تلقائيًا؟**

لا. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) في Aspose.Slides يخزن اللغة للتدقيق الإملائي والنحوي، ولكنه لا يترجم أو يغيّر محتوى النص. إنها بيانات وصفية تفهمها PowerPoint للتدقيق.

**هل يؤثر معرف اللغة على التجزيء إلى مقاطع والسطور أثناء العرض؟**

في Aspose.Slides، [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) مخصص للتدقيق. تعتمد جودة التجزيء إلى مقاطع وتغليف الأسطر أساسًا على توفر [الخطوط المناسبة](/slides/ar/python-net/powerpoint-fonts/) وإعدادات التخطيط/فواصل الأسطر لنظام الكتابة. لضمان عرض صحيح، اجعل الخطوط المطلوبة متاحة، وضبط [قواعد استبدال الخطوط](/slides/ar/python-net/font-substitution/)، و/أو [تضمين الخطوط](/slides/ar/python-net/embedded-font/) في العرض.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يُطبّق [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) على مستوى جزء النص، لذا يمكن لفقرة واحدة أن تحتوي على لغات متعددة مع إعدادات تدقيق متميزة.
