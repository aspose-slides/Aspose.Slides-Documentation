---
title: إدارة النص الفوقي والنص السفلي في بايثون
linktitle: النص الفوقي والنص السفلي
type: docs
weight: 80
url: /ar/python-net/superscript-and-subscript/
keywords:
- نص فوقي
- نص سفلي
- إضافة نص فوقي
- إضافة نص سفلي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إتقان النص الفوقي والنص السفلي في Aspose.Slides لبايثون عبر .NET وتعزيز عروضك التقديمية بتنسيق نص احترافي لتحقيق أقصى تأثير."
---

## **إضافة نص فوقي وأسفل**

يمكنك إضافة نص فوقي وأسفل إلى أي جزء من الفقرة. في Aspose.Slides، استخدم خاصية `escapement` من فئة [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) للتحكم في ذلك.

`escapement` هي نسبة مئوية من **-100% إلى 100%**:

- **> 0** → نص فوقي (مثال: 25% = رفع طفيف؛ 100% = نص فوقي كامل)
- **0** → خط الأساس (لا نص فوقي/أسفل)
- **< 0** → نص أسفل (مثال: -25% = خفض طفيف؛ -100% = نص أسفل كامل)

الخطوات:

1. إنشاء [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والحصول على شريحة.
2. إضافة مستطيل [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) والوصول إلى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
3. مسح الفقرات الحالية.
4. لنص فوقي: أنشئ فقرة وجزءًا، قم بتعيين `portion.portion_format.escapement` إلى قيمة بين **0 و100**, حدد النص, وأضف الجزء.
5. لنص أسفل: أنشئ فقرة أخرى وجزءًا، قم بتعيين `escapement` إلى قيمة بين **-100 و0**, حدد النص, وأضف الجزء.
6. احفظ العرض التقديمي كملف PPTX.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # الحصول على شريحة.
    slide = presentation.slides[0]

    # إنشاء مربع نص.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # إنشاء فقرة للنص الفوقي.
    superscript_paragraph = slides.Paragraph()

    # إنشاء جزء نص مع نص عادي.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # إنشاء جزء نص مع نص فوقي.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # إنشاء فقرة للنص السفلي.
    subscript_paragraph = slides.Paragraph()

    # إنشاء جزء نص مع نص عادي.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # إنشاء جزء نص مع نص سفلي.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # إضافة الفقرات إلى مربع النص.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يمكنني تطبيق النص فوقي/النص أسفل في الجداول والحاويات الأخرى، وليس فقط في مربعات النص العادية؟**

نعم. يمكنك تنسيق النص كنص فوقي أو نص أسفل داخل أي عنصر يعرض [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) (بما في ذلك خلايا الجداول). يتم تطبيق التنسيق على أجزاء النص داخل هذا الإطار.

**هل سيُحافظ على النص فوقي/النص أسفل عند التصدير إلى PDF أو HTML أو صور؟**

نعم. تحافظ Aspose.Slides على تنسيق النص فوقي/النص أسفل أثناء التصدير إلى الصيغ الشائعة مثل [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، و[raster images](/slides/ar/python-net/convert-powerpoint-to-png/) لأن خط أنابيب التصيير يراعي تنسيق النص على مستوى الجزء.

**هل يمكنني دمج النص فوقي/النص أسفل مع الروابط التشعبية في نفس قطعة النص؟**

نعم. يتم تعيين [Hyperlinks](/slides/ar/python-net/manage-hyperlinks/) على مستوى الجزء (القطعة)، بحيث يمكن للجزء أن يحتوي في نفس الوقت على رابط تشعبي وأن يكون منسقًا كنص فوقي أو نص أسفل.