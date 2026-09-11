---
title: إضافة أشكال الخط إلى العروض التقديمية في Python عبر Java
linktitle: خط
type: docs
weight: 50
url: /ar/python-java/line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط عادي
- تهيئة خط
- تخصيص خط
- نمط الشرط
- رأس السهم
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ Python عبر Java. اكتشف الخصائص والطرق والأمثلة."
---
## **نظرة عامة**

تسمح لك Aspose.Slides بإضافة أشكال الخط إلى شرائح PowerPoint برمجيًا. يوضح هذا المقال كيفية إنشاء خط بسيط وكيفية تخصيص الخط ليظهر كسهم.

ستتعلم كيفية إضافة شكل خط إلى شريحة، وضبط مظهره البصري، وحفظ العرض التقديمي المحدث. تركز الأمثلة على إعدادات تنسيق الخط العملية مثل النمط، العرض، نمط الشرط، خيارات رأس السهم، ولون التعبئة.

## **إنشاء خط عادي**

لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، اتبع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
- احصل على مرجع إلى شريحة حسب فهرسها.
- أضف شكل خط باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape) لكائن [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/).
- احفظ العرض التقديمي المعدل كملف PPTX.

المثال التالي يضيف خطًا إلى الشريحة الأولى من العرض التقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
presentation = Presentation()
try:
    # احصل على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # أضف شكل خط.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # اكتب ملف PPTX إلى القرص.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إنشاء خط على شكل سهم**

تسمح Aspose.Slides for Python via Java أيضًا للمطورين بتكوين خصائص الخط لجعل الخط أكثر جاذبية. لتكوين خط يبدو كسهم، اتبع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
- احصل على مرجع إلى شريحة حسب فهرسها.
- أضف شكل خط باستخدام الطريقة [addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape) لكائن [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/).
- حدد [نمط الخط](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linestyle/) إلى أحد الأنماط التي توفرها Aspose.Slides for Python via Java.
- حدد عرض الخط.
- حدد [نمط الشرط](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linedashstyle/) إلى أحد الأنماط التي توفرها Aspose.Slides for Python via Java.
- حدد [نمط رأس السهم](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linearrowheadstyle/) و[الطول](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linearrowheadlength/) في بداية الخط.
- حدد [نمط رأس السهم](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linearrowheadstyle/) و[الطول](https://reference.aspose.com/slides/ar/python-java/aspose.slides/linearrowheadlength/) في نهاية الخط.
- احفظ العرض التقديمي المعدل كملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
presentation = Presentation()
try:
    # احصل على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # أضف شكل خط.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # تطبيق تنسيق على الخط.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # كتابة ملف PPTX إلى القرص.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتقط" الأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتقط الأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/ar/python-java/aspose.slides/connector/) والـ[APIs المقابلة](/slides/ar/python-java/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ومن الصعب تحديد القيم النهائية؟**

اقرأ [الخصائص الفعلية](/slides/ar/python-java/shape-effective-properties/) للخط وتعبئته — هذه بالفعل تأخذ في الاعتبار الوراثة وأنماط السمة.

**هل يمكنني قفل الخط ضد التعديل (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال [كائنات القفل](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#getAutoShapeLock) التي تسمح لك [بحظر عمليات التعديل](/slides/ar/python-java/applying-protection-to-presentation/).