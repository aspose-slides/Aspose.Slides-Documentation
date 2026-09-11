---
title: إضافة أشكال إهليلجية إلى العروض التقديمية في بايثون عبر جافا
linktitle: إهليلج
type: docs
weight: 30
url: /ar/python-java/ellipse/
keywords:
- إهليلج
- شكل
- إضافة إهليلج
- إنشاء إهليلج
- رسم إهليلج
- إهليلج منسق
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق وتعديل أشكال الإهليلج في Aspose.Slides لبايثون عبر جافا عبر عروض PPT و PPTX — تتضمن أمثلة كود بايثون."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إضافة أشكال بيضاوية إلى شرائح PowerPoint باستخدام Aspose.Slides. تغطي إنشاء بيضاوي بسيط، وإنشاء بيضاوي منسَّق، وحفظ العرض التقديمي المُحدَّث كملف PPTX. كما تتطرق إلى أسئلة ذات صلة مثل العمل مع موضع البيضاوي وحجمه، والتحكم في ترتيب الطبقات، وتطبيق تأثيرات الرسوم المتحركة.

## **إنشاء بيضاوي**

لإضافة بيضاوي بسيط إلى شريحة مختارة من العرض التقديمي، اتبع الخطوات أدناه:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
- الحصول على إشارة إلى شريحة بواسطة فهرستها.
- إضافة بيضاوي باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape) لكائن [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/).
- كتابة العرض التقديمي المعدَّل كملف PPTX.

المثال التالي يضيف بيضاويًا إلى الشريحة الأولى:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل إهليلجي.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # كتابة ملف PPTX إلى القرص.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إنشاء بيضاوي منسَّق**

لإضافة بيضاوي منسَّق إلى شريحة، اتبع الخطوات أدناه:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
- الحصول على إشارة إلى شريحة بواسطة فهرستها.
- إضافة بيضاوي باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape) لكائن [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/).
- تعيين نوع تعبئة البيضاوي إلى صلب.
- تعيين لون تعبئة البيضاوي عبر [getSolidFillColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#getSolidFillColor) في كائن [FillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/) المرتبط بكائن [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/).
- تعيين لون حدود البيضاوي.
- تعيين عرض حدود البيضاوي.
- كتابة العرض التقديمي المعدَّل كملف PPTX.

المثال التالي يضيف بيضاويًا منسَّقًا إلى الشريحة الأولى من العرض التقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل إهليلج.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # تنسيق تعبئة الإهليلج.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # تنسيق حد الإهليلج.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # كتابة ملف PPTX إلى القرص.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**كيف يمكنني ضبط الموضع والحجم الدقيق للبيضاوي بالنسبة إلى وحدات الشريحة؟**

عادةً ما تُحدد الإحداثيات والأحجام **بالنقاط**. للحصول على نتائج متوقعة، احسب بناءً على حجم الشريحة وحوّل المليمترات أو الإنش المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع البيضاوي فوق أو تحت كائنات أخرى (التحكم في ترتيب الطبقات)؟**

قم بتعديل ترتيب الرسم للكائن عن طريق إحضاره إلى المقدمة أو إرساله إلى الخلف. هذا يسمح للبيضاوي بالتراكب فوق كائنات أخرى أو كشف ما تحتها.

**كيف يمكنني تحريك ظهور أو تأكيد البيضاوي؟**

[تطبيق](/slides/ar/python-java/shape-animation/) تأثيرات الدخول أو التشديد أو الخروج على الشكل، وقم بإعداد المشغلات والتوقيت لتحديد متى وكيف تُنفّذ الرسوم المتحركة.