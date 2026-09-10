---
title: تخصيص مخططات 3D في العروض التقديمية باستخدام Python
linktitle: مخطط 3D
type: docs
url: /ar/python-java/3d-chart/
keywords:
- مخطط 3D
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص مخططات ثلاثية الأبعاد في Aspose.Slides for Python via Java، مع دعم ملفات PPT و PPTX—عزز عروضك اليوم."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص مخطط ثلاثي الأبعاد في Aspose.Slides عن طريق تكوين إعدادات [Rotation3D](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotation3d/) مثل [setRotationX](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotation3d/#setRotationX)، [setRotationY](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotation3d/#setRotationY)، [setDepthPercents](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotation3d/#setDepthPercents)، و[setRightAngleAxes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/rotation3d/#setRightAngleAxes). تتناول إنشاء عرض تقديمي، وإضافة مخطط ثلاثي الأبعاد بالبيانات الافتراضية، وتطبيق إعدادات العرض الثلاثي الأبعاد المطلوبة، وحفظ العرض التقديمي المعدل كملف PPTX.

## **تعيين دوران X، دوران Y، وعمق مخطط ثلاثي الأبعاد**
توفر Aspose.Slides for Python via Java واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. يوضح المثال التالي كيفية تعيين دوران X، دوران Y، وعمق مخطط ثلاثي الأبعاد.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط بالبيانات الافتراضية.
4. تعيين خصائص دوران ثلاثي الأبعاد.
5. كتابة العرض التقديمي المعدل إلى ملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # الوصول إلى الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة مخطط بالبيانات الافتراضية.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # تعيين فهرس ورقة عمل بيانات المخطط.
    default_worksheet_index = 0

    # الحصول على دفتر عمل بيانات المخطط.
    workbook = chart.getChartData().getChartDataWorkbook()

    # إضافة سلسلة.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # إضافة فئات.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # تعيين خصائص دوران 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # الوصول إلى سلسلة المخطط الثانية.
    series = chart.getChartData().getSeries().get_Item(1)

    # تعبئة بيانات السلسلة.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # حفظ العرض التقديمي.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides إصدارات ثلاثية الأبعاد من مخططات الأعمدة، بما في ذلك Column 3D وClustered Column 3D وStacked Column 3D و100% Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد المرتبطة التي يتم عرضها عبر الفئة [ChartType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدثة، تحقق من أعضاء [ChartType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/charttype/) في مرجع API للنسخة المثبتة لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط كصورة عبر [chart API](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) أو [render the entire slide](/slides/ar/python-java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة دقيقة بالبكسل أو تريد تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء وعرض مخططات 3D الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد العرض البصري. للحصول على أفضل النتائج، قم بتقليل تأثيرات 3D إلى الحد الأدنى، وتجنب القوام الثقيلة على الجدران ومناطق الرسم، وقلل عدد نقاط البيانات لكل سلسلة إن أمكن، وقم بالعرض إلى مخرج بالحجم المناسب (الدقة والأبعاد) ليتطابق مع شاشة العرض أو متطلبات الطباعة المستهدفة.