---
title: إدارة النص المرتفع والنص المنخفض في العروض التقديمية باستخدام بايثون عبر جافا
linktitle: النص المرتفع والنص المنخفض
type: docs
weight: 80
url: /ar/python-java/superscript-and-subscript/
keywords:
- نص مرتفع
- نص منخفض
- إضافة نص مرتفع
- إضافة نص منخفض
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "اتقن النص المرتفع والنص المنخفض في Aspose.Slides لبايثون عبر جافا وارتق بعروضك التقديمية باستخدام تنسيق نصي احترافي لتحقيق أقصى تأثير."
---
## **نظرة عامة**

توفر Aspose.Slides ميزات لإدماج النص المرتفع والنص المنخفض في عروض PowerPoint (PPT، PPTX) وOpenDocument (ODP). سواء كنت بحاجة إلى تمييز الصيغ الكيميائية أو المعادلات الرياضية أو توضيح المحتوى بحواشي سفلية، فإن خيارات التنسيق المتخصصة هذه تساعد على الحفاظ على الوضوح والدقة. في هذه المقالة، ستتعلم كيفية تطبيق أنماط النص المرتفع والنص المنخفض بسلاسة وضمان نتائج احترافية في كل شريحة.

## **إدارة النص المرتفع والنص المنخفض**

يمكنك إضافة نص مرتفع أو نص منخفض إلى أي جزء من الفقرة. لتطبيق هذا التنسيق في إطار نص Aspose.Slides، استخدم طريقة [setEscapement](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#setEscapement) في فئة [PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) .

قيمة الـ escapement تتراوح بين -100% (منخفض) إلى 100% (مرتفع). على سبيل المثال:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
- الحصول على شريحة حسب فهرستها.
- إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) من النوع [ShapeType.Rectangle](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#Rectangle) إلى الشريحة.
- الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) المرتبط بـ [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) .
- مسح الفقرات الموجودة.
- إنشاء فقرة لاحتواء النص المرتفع وإضافتها إلى مجموعة الفقرات في إطار النص ([paragraph collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParagraphs)) .
- إنشاء جزء.
- استخدام [setEscapement](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#setEscapement) لتعيين قيمة من 0 إلى 100 للنص المرتفع (0 يعني عدم وجود نص مرتفع) .
- تعيين نص الـ[Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) وإضافته إلى مجموعة الأجزاء في الفقرة.
- إنشاء فقرة لاحتواء النص المنخفض وإضافتها إلى مجموعة الفقرات في إطار النص ([paragraph collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#getParagraphs)) .
- إنشاء جزء.
- استخدام [setEscapement](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/#setEscapement) لتعيين قيمة من -100 إلى 0 للنص المنخفض (0 يعني عدم وجود نص منخفض) .
- تعيين نص الـ[Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) وإضافته إلى مجموعة الأجزاء في الفقرة.
- حفظ العرض كملف PPTX.

المثال التالي يطبق هذه الخطوات:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# إنشاء عرض تقديمي.
presentation = Presentation()
try:
    # الحصول على الشريحة.
    slide = presentation.getSlides().get_Item(0)

    # إنشاء مربع نص.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # إنشاء فقرة للنص المرتفع.
    superscript_paragraph = Paragraph()

    # إنشاء جزء بنص عادي.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # إنشاء جزء بنص مرتفع.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # إنشاء فقرة للنص المنخفض.
    subscript_paragraph = Paragraph()

    # إنشاء جزء بنص عادي.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # إنشاء جزء بنص منخفض.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # إضافة الفقرات إلى مربع النص.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل سيبقى النص المرتفع والنص المنخفض محفوظًا عند التصدير إلى PDF أو صيغ أخرى؟**

نعم، تقوم Aspose.Slides بالحفاظ بشكل صحيح على تنسيق النص المرتفع والنص المنخفض عند تصدير العروض إلى PDF أو PPT/PPTX أو الصور أو أي صيغ مدعومة أخرى. يظل التنسيق المتخصص محفوظًا بالكامل في جميع ملفات الإخراج.

**هل يمكن دمج النص المرتفع والنص المنخفض مع أنماط تنسيق أخرى مثل الغامق أو المائل؟**

نعم، تتيح Aspose.Slides دمج أنماط نصية مختلفة داخل جزء نصي واحد. يمكنك تفعيل الغامق أو المائل أو الخط السفلي، وتطبيق النص المرتفع أو المنخفض في الوقت نفسه عن طريق ضبط الخصائص المقابلة في [PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) .

**هل يعمل تنسيق النص المرتفع والنص المنخفض للنص داخل الجداول أو المخططات أو SmartArt؟**

نعم، تدعم Aspose.Slides التنسيق داخل معظم الكائنات، بما في ذلك الجداول وعناصر المخططات. عند العمل مع SmartArt، تحتاج إلى الوصول إلى العناصر المناسبة (مثل [SmartArtNode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/)) وحاويات النص الخاصة بها، ثم ضبط خصائص [PortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portionformat/) بطريقة مماثلة.