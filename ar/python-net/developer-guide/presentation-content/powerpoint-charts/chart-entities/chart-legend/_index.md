---
title: تخصيص وسائط إيضاح المخططات في العروض التقديمية باستخدام بايثون
linktitle: وسائط إيضاح المخطط
type: docs
url: /ar/python-net/chart-legend/
keywords:
- وسيلة إيضاح المخطط
- موضع وسيلة الإيضاح
- حجم الخط
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بتخصيص وسائط إيضاح المخططات باستخدام Aspose.Slides للبايثون عبر .NET لتحسين عروض PowerPoint التقديمية من خلال تنسيق وسائط إيضاح مخصص."
---
## **نظرة عامة**

توفر Aspose.Slides for Python via .NET خيارات لتخصيص وسائط إيضاح المخطط في عروض PowerPoint. تُظهر هذه المقالة كيفية تحديد موضع وحجم وسيلة الإيضاح، وضبط حجم الخط للوسيلة بأكملها، وتنسيق مدخل وسيلة إيضاح فردي، وإخفاء أو استعادة المدخلات المحددة.

يغطي قسم الأسئلة المتكررة السلوكيات المرتبطة، بما في ذلك حجز مساحة لوسيلة الإيضاح، وعرض تسميات متعددة الأسطر، ورث التنسيق من سمة العرض التقديمي.

## **تموضع وسيلة الإيضاح**

استخدم خصائص [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/)، [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/)، [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/)، و[height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) للوسيلة لتحديد موقعها وحجمها كنسب من أبعاد المخطط.

هذا المثال ينشئ عرض تقديمي ويضيف مخطط أعمدة مُجمَّع ببيانات افتراضية إلى الشريحة الأولى. تقسيم إزاحات وأبعاد وسيلة الإيضاح المطلوبة على عرض وارتفاع المخطط يحولها إلى قيم نسبية: تُبعد الوسيلة 50 نقطة عن الزاوية العلوية اليسرى للمخطط وتكون بحجم 100 × 100 نقطة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # عبّر عن موضع وسيلة الإيضاح وحجمها نسبةً إلى المخطط.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين حجم الخط لوسيلة الإيضاح**

استخدم [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) للوسيلة للوصول إلى تنسيق النص وضبط [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) بالنقاط.

هذا المثال ينشئ مخططًا ببيانات افتراضية ويضبط نص وسيلة الإيضاح إلى 20 نقطة. كما يقوم بإلغاء الحدود التلقائية للمحور العمودي ويضبط نطاقه من -5 إلى 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين حجم الخط لمدخل وسيلة إيضاح فردي**

استخدم مجموعة [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) للوسيلة للوصول إلى تنسيق مدخل محدد. فهارس المدخلات تبدأ من الصفر، لذا يشير الفهرس `1` إلى المدخل الثاني.

هذا المثال ينشئ مخطط أعمدة مُجمَّع يحتوي على بيانات افتراضية تشمل على الأقل سلسلتين. يُنسق المدخل الثاني لوسيلة الإيضاح بنص غامق ومائل وبلون أزرق بحجم 20 نقطة.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **إخفاء مدخلات وسيلة إيضاح فردية**

لإستثناء سلسلة مساعدة من وسيلة الإيضاح مع إبقاء بياناتها مرئية، اضبط [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) إلى `True` عبر [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). هذا يخفي فقط مدخل وسيلة الإيضاح المحدد؛ لا يزيل السلسلة أو نقاط البيانات الخاصة بها. ضبط [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) إلى `False`، على النقيض، يخفي وسيلة الإيضاح بأكملها.

المثال أدناه ينشئ مخطط أعمدة مُجمَّع مع عدة سلاسل باستخدام بيانات افتراضية. يخفي مدخل وسيلة الإيضاح للسلسلة الثانية (الفهرس `1`) ويحفظ العرض التقديمي. ثم يُعيد استعادة المدخل بضبط [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) إلى `False` ويحفظ نسخة ثانية. تظل الأعمدة مرئية في كلا الملفين.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # استعادة نفس المدخل دون تغيير بيانات المخطط.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

المقارنة أدناه تُظهر نفس المخطط مع جميع المدخلات مرئية ومع إخفاء السلسلة 2 من وسيلة الإيضاح؛ جميع الأعمدة تبقى مرئية.

![مقارنة مخطط مع كل مداخل وسيلة الإيضاح مرئية ومع إخفاء السلسلة 2 من وسيلة الإيضاح؛ جميع الأعمدة تبقى مرئية.](hide-legend-entry.png)

في مخططات الأعمدة، الأشرطة، والخطوط، تُعرِّف مدخلات وسيلة الإيضاح السلاسل. بالنسبة لمخططات الدوائر، تُعرِّف المدخلات نقاط البيانات الفردية (الشرائح)، لذا استخدم [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) على الشريحة المختارة بدلاً من ذلك. توثِّق API هذه الخاصية لنقاط البيانات لأنواع المخططات `PIE`، `PIE3D`، `EXPLODED_PIE`، `EXPLODED_PIE3D`، `PIE_OF_PIE`، و`BAR_OF_PIE`. لا تفترض أنها تنطبق على مخططات الدونات، التي لا تُضمّن في تلك القائمة.

## **الأسئلة المتكررة**

**هل يمكنني جعل المخطط يخصص مساحة لوسيلة الإيضاح بدلاً من تغطيتها؟**

نعم. اضبط [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) إلى `False` لحجز مساحة لوسيلة الإيضاح بدلاً من السماح لها بتغطية مساحة الرسم.

**هل يمكنني إنشاء تسميات متعددة الأسطر لوسيلة الإيضاح؟**

نعم. يمكن أن تُلتف التسميات الطويلة عندما يكون العرض المتاح غير كافٍ. يمكنك أيضًا استخدام أحرف السطر الجديد في أسماء السلاسل لطلب فواصل أسطر.

**كيف أجعل وسيلة الإيضاح تتبع مخطط ألوان سمة العرض التقديمي؟**

اترك ألوان وسيلة الإيضاح، والتعبئات، والخطوط غير محددة حتى تتمكن من وراثة تنسيق السمة. التنسيق الصريح يتجاوز إعدادات السمة المقابلة.