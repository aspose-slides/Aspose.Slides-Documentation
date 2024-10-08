---
title: النص العلوي والنص السفلي
type: docs
weight: 80
url: /ar/python-net/superscript-and-subscript/
keywords: "نص علوي, نص سفلي, إضافة نص علوي, إضافة نص سفلي, عرض PowerPoint, بايثون, Aspose.Slides لبايثون عبر .NET"
description: "إضافة نص علوي ونص سفلي إلى عروض PowerPoint في بايثون"
---

## **إدارة النص العلوي والنص السفلي**
يمكنك إضافة نص علوي ونص سفلي داخل أي جزء من الفقرة. لإضافة نص علوي أو نص سفلي في إطار نص Aspose.Slides، يجب استخدام **خاصية الإزاحة** لفئة PortionFormat.

ترجع هذه الخاصية أو تضبط نصًا علويًا أو نصًا سفليًا (القيمة من -100% (نص سفلي) إلى 100% (نص علوي). على سبيل المثال:

- أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- احصل على مرجع لشريحة باستخدام فهرسها.
- أضف IAutoShape من نوع مستطيل إلى الشريحة.
- الوصول إلى ITextFrame المرتبطة بـ IAutoShape.
- مسح الفقرات الموجودة
- أنشئ كائن فقرة جديدة للاحتفاظ بالنص العلوي وأضفه إلى مجموعة IParagraphs الخاصة بـ ITextFrame.
- أنشئ كائن جزء جديد
- اضبط خاصية الإزاحة للجزء بين 0 إلى 100 لإضافة نص علوي. (0 يعني عدم وجود نص علوي)
- اضبط بعض النصوص للجزء ثم أضف ذلك إلى مجموعة الجزء الخاصة بالفقرة.
- أنشئ كائن فقرة جديدة للاحتفاظ بالنص السفلي وأضفه إلى مجموعة IParagraphs الخاصة بـ ITextFrame.
- أنشئ كائن جزء جديد
- اضبط خاصية الإزاحة للجزء بين 0 إلى -100 لإضافة نص سفلي. (0 يعني عدم وجود نص سفلي)
- اضبط بعض النصوص للجزء ثم أضف ذلك إلى مجموعة الجزء الخاصة بالفقرة.
- احفظ العرض كملف PPTX.

تنفيذ الخطوات المذكورة أعلاه موضح أدناه.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # الحصول على الشريحة
    slide = presentation.slides[0]

    # إنشاء مربع نص
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    textFrame = shape.text_frame
    textFrame.paragraphs.clear()

    # إنشاء فقرة لنص علوي
    superPar = slides.Paragraph()

    # إنشاء جزء بالنص العادي
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superPar.portions.add(portion1)

    # إنشاء جزء بالنص العلوي
    superPortion = slides.Portion()
    superPortion.portion_format.escapement = 30
    superPortion.text = "TM"
    superPar.portions.add(superPortion)

    # إنشاء فقرة لنص سفلي
    paragraph2 = slides.Paragraph()

    # إنشاء جزء بالنص العادي
    portion2 = slides.Portion()
    portion2.text = "a"
    paragraph2.portions.add(portion2)

    # إنشاء جزء بالنص السفلي
    subPortion = slides.Portion()
    subPortion.portion_format.escapement = -25
    subPortion.text = "i"
    paragraph2.portions.add(subPortion)

    # إضافة الفقرات إلى مربع النص
    textFrame.paragraphs.add(superPar)
    textFrame.paragraphs.add(paragraph2)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```