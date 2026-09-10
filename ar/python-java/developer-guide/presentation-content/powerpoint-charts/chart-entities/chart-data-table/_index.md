---
title: تخصيص جداول بيانات المخططات في العروض التقديمية باستخدام بايثون
linktitle: جدول البيانات
type: docs
url: /ar/python-java/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "قم بتخصيص جداول بيانات المخططات في بايثون لملفات PPT و PPTX باستخدام Aspose.Slides for Python via Java لزيادة الكفاءة والجاذبية في العروض التقديمية."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع جداول بيانات المخطط في Aspose.Slides. تُظهر كيفية عرض جدول بيانات لمخطط وتخصيص تنسيق النص الخاص به عن طريق تعيين خصائص الخط مثل النمط العريض وارتفاع الخط. يُظهر المثال إنشاء عرض تقديمي، إضافة مخطط، تمكين جدول بيانات المخطط، تطبيق إعدادات الخط، وحفظ العرض التقديمي المحدث.

كما يتضمن إجابات مختصرة على الأسئلة الشائعة حول إظهار مفاتيح الأسطورة في جدول بيانات المخطط، الحفاظ على جدول البيانات أثناء التصدير، العمل مع المخططات التي تم تحميلها من عروض تقديمية أو قوالب موجودة، وتحديد المخططات التي تم تمكين جدول البيانات لها.

## **تعيين خصائص الخط لجدول بيانات المخطط**

Aspose.Slides for Python via Java تسمح لك بعرض جدول بيانات المخطط وتغيير خصائص الخط لنصه.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. إضافة مخطط إلى الشريحة.
1. إظهار جدول بيانات المخطط.
1. تعيين النمط العريض وارتفاع الخط لنص جدول البيانات.
1. حفظ العرض التقديمي المعدل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# إنشاء عرض تقديمي فارغ.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني إظهار مفاتيح أسطورة صغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [legend keys](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datatable/#setShowLegendKey)، ويمكنك تشغيلها أو إيقافها.

**هل سيتم الحفاظ على جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذا فإن [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/python-java/convert-powerpoint-to-html/)/[image](/slides/ar/python-java/convert-powerpoint-to-png/) المُصدَّر يتضمن المخطط مع جدول بياناته.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. بالنسبة لأي مخطط تم تحميله من عرض تقديمي أو قالب موجود، يمكنك فحص وتغيير ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#hasDataTable) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات في ملف ما التي تم تمكين جدول البيانات لها؟**

افحص خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [is shown](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/#hasDataTable) ثم تكرار عبر الشرائح لتحديد المخططات التي تم تمكين جدول البيانات لها.