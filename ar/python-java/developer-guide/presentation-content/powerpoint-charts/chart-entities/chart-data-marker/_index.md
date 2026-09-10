---
title: إدارة علامات بيانات المخطط في العروض التقديمية باستخدام بايثون
linktitle: علامة البيانات
type: docs
url: /ar/python-java/chart-data-marker/
keywords:
- مخطط
- نقطة بيانات
- علامة
- خيارات العلامة
- حجم العلامة
- نوع التعبئة
- PowerPoint
- عرض تقديمي
- بايثون
- جافا
- Aspose.Slides
description: "تعلم كيفية تخصيص علامات بيانات المخطط في Aspose.Slides للبايثون عبر جافا، مع تعزيز تأثير العروض التقديمية عبر صيغ PPT و PPTX باستخدام أمثلة واضحة لكود بايثون."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية التعامل مع علامات بيانات المخطط في Aspose.Slides. وتظهر كيفية إنشاء مخطط، والوصول إلى سلسلة ونقاط بياناتها، وتطبيق تعبئة صورة على العلامات على مستوى نقطة البيانات، وضبط حجم العلامة، وحفظ العرض التقديمي المحدث. كما تشير إلى أن أشكال العلامات القياسية متاحة عبر تعداد [MarkerStyleType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markerstyletype/) وأن مظهر العلامة يُحافظ عليه عند تصدير المخططات إلى الصيغ النقطية أو SVG.

## **تعيين خيارات علامات المخطط**
يمكن تعيين العلامات على نقاط بيانات المخطط داخل سلسلة معينة. لتعيين خيارات علامات المخطط، اتبع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
- إنشاء المخطط الافتراضي.
- تعيين الصور.
- الوصول إلى السلسلة الأولى للمخطط.
- إضافة نقاط بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

المثال التالي يعين خيارات علامات المخطط على مستوى نقطة البيانات.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

    # إنشاء عرض تقديمي فارغ.
    presentation = Presentation()
    try:
        # الوصول إلى الشريحة الأولى
        slide = presentation.getSlides().get_Item(0)

        # إنشاء المخطط الافتراضي
        chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

        # الحصول على فهرس ورقة عمل بيانات المخطط الافتراضية.
        default_worksheet_index = 0

        # الحصول على دفتر عمل بيانات المخطط.
        workbook = chart.getChartData().getChartDataWorkbook()

        # حذف السلسلة التجريبية
        chart.getChartData().getSeries().clear()

        # إضافة سلسلة جديدة
        series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
        chart.getChartData().getSeries().add(series_name_cell, chart.getType())

        # تحميل الصورة الأولى.
        desert_bytes = Path("Desert.jpg").read_bytes()
        desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

        # تحميل الصورة الثانية.
        tulips_bytes = Path("Tulips.jpg").read_bytes()
        tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

        # الوصول إلى السلسلة الأولى للمخطط.
        series = chart.getChartData().getSeries().get_Item(0)

        # إضافة نقاط البيانات.
        value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
        point = series.getDataPoints().addDataPointForLineSeries(value_cell)
        point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
        point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

        value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
        point = series.getDataPoints().addDataPointForLineSeries(value_cell)
        point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
        point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

        value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
        point = series.getDataPoints().addDataPointForLineSeries(value_cell)
        point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
        point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

        value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
        point = series.getDataPoints().addDataPointForLineSeries(value_cell)
        point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
        point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

        # تغيير حجم علامة سلسلة المخطط.
        series.getMarker().setSize(15)

        # حفظ العرض التقديمي مع المخطط
        presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **الأسئلة الشائعة**

**ما هي أشكال العلامات المتوفرة بشكل افتراضي؟**

الأشكال القياسية متاحة (دائرة، مربع، ماسي، مثلث، إلخ)؛ القائمة معرفة بواسطة فئة [MarkerStyleType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/markerstyletype/). إذا كنت تحتاج إلى شكل غير قياسي، استخدم علامة مع تعبئة صورة لمحاكاة مرئيات مخصصة.

**هل يتم الحفاظ على العلامات عند تصدير المخطط إلى صورة أو SVG؟**

نعم. عند تصيير المخططات إلى [raster formats](/slides/ar/python-java/convert-powerpoint-to-png/) أو حفظ [shapes as SVG](/slides/ar/python-java/render-a-slide-as-an-svg-image/)، تحتفظ العلامات بمظهرها وإعداداتها، بما في ذلك الحجم والتعبئة والحدود.