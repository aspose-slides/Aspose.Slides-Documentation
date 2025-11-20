---
title: أتمتة تعريب العروض التقديمية باستخدام Python
linktitle: تعريب العرض التقديمي
type: docs
weight: 100
url: /ar/python-net/presentation-localization/
keywords:
- تغيير اللغة
- تدقيق إملائي
- معرف اللغة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "أتمتة تعريب شرائح PowerPoint وOpenDocument في Python باستخدام Aspose.Slides، مع أمثلة عملية على الشيفرة ونصائح لتسريع الإطلاق العالمي."
---

## **تغيير اللغة لعرض الشرائح ونص الشكل**
- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع مستطيل إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- تعيين معرف اللغة (Language Id) للنص.
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


## **الأسئلة المتكررة**

**هل language_id يُفضي إلى ترجمة تلقائية للنص؟**

لا. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) في Aspose.Slides يخزن اللغة لتدقيق الإملائي وإثبات القواعد، لكنه لا يترجم أو يغيّر محتوى النص. إنه بيانات وصفية تفهمها PowerPoint لأغراض التدقيق.

**هل language_id يؤثر على التجزئة واستخدام الفواصل السطرية أثناء العرض؟**

في Aspose.Slides، يُستخدم language_id لأغراض التدقيق. جودة التجزئة وتغليف الأسطر تعتمد أساساً على توفر [proper fonts](/slides/ar/python-net/powerpoint-fonts/) وإعدادات التخطيط/فواصل السطر للنظام الكتابي. لضمان عرض صحيح، احرص على توفير الخطوط المطلوبة، وعيّن [font substitution rules](/slides/ar/python-net/font-substitution/)، و/أو [embed fonts](/slides/ar/python-net/embedded-font/) في العرض.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) يُطبق على مستوى جزء النص، لذا يمكن لفقرة واحدة أن تمزج بين عدة لغات بإعدادات تدقيق مختلفة.