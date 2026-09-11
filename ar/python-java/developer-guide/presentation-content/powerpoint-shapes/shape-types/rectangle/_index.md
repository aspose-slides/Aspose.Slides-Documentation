---
title: إضافة مستطيلات إلى العروض التقديمية في بايثون عبر جافا
linktitle: مستطيل
type: docs
weight: 80
url: /ar/python-java/rectangle/
keywords:
- إضافة مستطيل
- إنشاء مستطيل
- شكل مستطيل
- مستطيل بسيط
- مستطيل منسق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "عزز عروض PowerPoint التقديمية الخاصة بك عن طريق إضافة مستطيلات باستخدام Aspose.Slides للبايثون عبر جافا — صمّم وعدّل الأشكال برمجيًا بسهولة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إضافة أشكال مستطيلة إلى شرائح PowerPoint باستخدام Aspose.Slides. تغطي إنشاء مستطيل بسيط، وإنشاء مستطيل منسق، وحفظ العرض التقديمي المحدّث كملف PPTX.

سترى أيضًا كيفية تطبيق تنسيق أساسي للمستطيل، مثل لون تعبئة صلب، ولون الخط، وعرض الخط. بالإضافة إلى ذلك، تشير الأسئلة المتكررة في المقالة إلى مهام مستطيلة ذات صلة، بما في ذلك الزوايا المستديرة، وتعبئة الصور، والمؤثرات البصرية، والارتباطات التشعبية، وتأمين الأشكال، وخيارات التصدير، والخصائص الفعّالة.

## **إضافة مستطيل إلى شريحة**

لإضافة مستطيل بسيط إلى شريحة محددة في العرض التقديمي، اتبع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
- الحصول على إشارة إلى شريحة حسب فهرستها.
- إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) من نوع المستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/) .
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل مستطيل.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # كتابة ملف PPTX إلى القرص.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إضافة مستطيل منسق إلى شريحة**

لإضافة مستطيل منسق إلى شريحة، اتبع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
- الحصول على إشارة إلى شريحة حسب فهرستها.
- إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) من نوع المستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape) التي توفرها كائن [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/) .
- ضبط [fill type](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) للمستطيل إلى صلب.
- ضبط لون المستطيل باستخدام طريقة [setColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/colorformat/#setColor) على لون التعبئة الصلب لـ كائن [FillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/) المرتبط بكائن [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) .
- ضبط لون حد المستطيل.
- ضبط عرض حد المستطيل.
- كتابة العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات المذكورة أعلاه في المثال أدناه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل مستطيل.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # تنسيق تعبئة المستطيل.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # تنسيق حدود المستطيل.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # كتابة ملف PPTX إلى القرص.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**كيف يمكنني إضافة مستطيل بزوايا مستديرة؟**

استخدم نوع الشكل [shape type](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/) بزوايا مستديرة وقم بضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق الاستدارة على كل زاوية على حدة عبر تعديلات الهندسة.

**كيف أملأ مستطيلًا بصورة (نقش)؟**

اختر [fill type](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) لتعبئة الصورة، زوّد مصدر الصورة، واضبط وضعيات [stretching/tiling modes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillmode/) حسب الحاجة.

**هل يمكن للمستطيل أن يحتوي على ظل وتوهج؟**

نعم. الظلال الخارجية/الداخلية، والتوهج، والحواف الناعمة متاحة عبر [/slides/ar/python-java/shape-effect/](/slides/ar/python-java/shape-effect/) مع إمكانية ضبط المعلمات.

**هل يمكن تحويل المستطيل إلى زر مع ارتباط تشعبي؟**

نعم. يمكن [Assign a hyperlink](/slides/ar/python-java/manage-hyperlinks/) للنقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف أحمي المستطيل من التحريك والتغيير؟**

استخدم [shape locks](/slides/ar/python-java/applying-protection-to-presentation/) لتمنع التحريك، إعادة الحجم، الاختيار، أو تحرير النص للحفاظ على التخطيط.

**هل يمكن تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [render the shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) إلى صورة بحجم/مقياس محدد أو [export it as SVG](/slides/ar/python-java/create-shape-thumbnails/) للاستخدام المتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**

استخدم [shape’s effective properties](/slides/ar/python-java/shape-effective-properties/)؛ تُعيد الواجهة البرمجية القيم المحسوبة التي تأخذ في الاعتبار أنماط السمة، والتخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.