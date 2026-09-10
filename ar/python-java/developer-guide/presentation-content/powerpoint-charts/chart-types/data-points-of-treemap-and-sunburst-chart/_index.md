---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst في بايثون
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- مخطط Treemap
- مخطط Sunburst
- مخطط هرمي
- نقطة بيانات
- تسمية البيانات
- لون الفرع
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: تعلم كيفية إنشاء بيانات هرمية وتخصيص المستويات والتسميات والألوان في مخططات Treemap و Sunburst باستخدام Aspose.Slides للبايثون عبر الجافا.
---
## **نظرة عامة**

تُظهر مخططات Treemap و Sunburst نفس نوع البيانات الهرمية، لكنها تستخدم تخطيطات مختلفة. يرسم Treemap الهرمية كمستطيلات متداخلة تمثل مساحات القيم النهائية. يرسم Sunburstها كحلقات مت concentric: المجموعات ذات المستوى الأعلى تكون قريبة من المركز، وفئات الأوراق تكون على الحلقة الخارجية.

في Aspose.Slides for Python via Java، كل قيمة رقمية هي [ChartDataPoint](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/). تقدم طريقة [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) إمكانية الوصول إلى الورقة وأقسامها الأصلية. يوضح هذا المقال ذلك الربط ويظهر كيفية إنشاء وتنسيق كلا نوعي المخططات من نفس بيانات العينة.

![مخطط Treemap مع فروع المستهلك والأعمال](treemap-hierarchy.png)

![مخطط Sunburst مع نفس هرمية المستهلك والأعمال](sunburst-hierarchy.png)

## **فهم الفئات ونقاط البيانات والمستويات**

العينة المستخدمة أدناه تحتوي على ثلاثة مستويات فئة وسلسلة رقمية واحدة:

| الفرع | الجذر | الورقة | الإيرادات |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

كل صف يُنشئ فئة ورقة واحدة ونقطة بيانات واحدة. تصف مستويات تجميع الفئات المسار من تلك الورقة إلى أصولها. بالنسبة للصف الأول، المسار هو `Consumer > Computers > Laptops`.

المؤشرات التي تُرجعها [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) تبدأ من الورقة صعودًا:

| الفهرس `getDataPointLevels()` | المستوى المنطقي | تمثيل Treemap | تمثيل Sunburst |
| ---: | --- | --- | --- |
| `0` | ورقة | مستطيل القيمة | قطاع الحلقة الخارجية |
| `1` | جذر | مستطيل أو رأس الأصل | قطاع الحلقة الوسطى |
| `2` | فرع | مستطيل أو رأس المستوى الأعلى | قطاع الحلقة الداخلية |

هذا الترتيب هو نفسه لكلا نوعي المخططات رغم اختلاف تخطيطهما البصري. يُشارك القطاع الأصلي عدة أوراق. لتنسيقه، استخدم المستوى المقابل لأول نقطة بيانات في تلك المجموعة. على سبيل المثال، يبدأ فرع `Consumer` بنقطة `Laptops`، بينما يبدأ جذر `Software` بنقطة `Licenses`. الاحتفاظ بإشارات إلى تلك النقاط أوضح وأكثر أمانًا من استخدام تعبيرات غير مفسرة مثل `data_points.get_Item(0)` أو `data_points.get_Item(6)`.

## **إنشاء وتخصيص كلا نوعي المخططات**

المثال الكامل التالي يُنشئ مخطط Treemap على الشريحة الأولى ومخطط Sunburst على الشريحة الثانية. يبني الهرمية، يعرض القيمة لـ `Tablets`، يُطبق ألوان ثابتة على المستويات المحددة، يُنسق تسمية فرع، ويحفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpure.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # إضافة فئات الأوراق. يتم تعيين عنصر التجميع فقط عندما يبدأ مجموعة جديدة؛
        # الفئات التالية تظل في تلك المجموعة حتى يتم تعيين عنصر آخر.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # إظهار الفئة والقيمة على ورقة Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # تنسيق فرع Consumer من خلال أول ورقة في ذلك الفرع.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # تنسيق الجذر Software من خلال أول ورقة في ذلك الجذر.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # يؤثر ParentLabelLayout على تسميات أصل Treemap؛ يستخدم Sunburst قطاعات الحلقة.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تستخدم خلايا الفئة وخلايا القيمة نفس صف ورقة العمل، لذا تبقى مواضع مجموعاتهما مُحاذاة. عندما تعمل مع مخطط موجود بدلاً من إنشائه، افحص صفوف الفئة أولًا وخزن مراجع مسماة لنقاط البيانات والمستويات التي تنوي تنسيقها.

## **السلوك والاعتبارات العملية**

### **اختلافات Treemap و Sunburst**

- يستخدم Treemap المساحة لنقل القيمة والمستطيلات المتداخلة لنقل الهرمية. تتحكم طريقة [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#setParentLabelLayout) في طريقة ظهور تسميات الأصل في هذا النوع من المخططات.
- يستخدم Sunburst الزاوية لنقل القيمة وعمق الحلقة لنقل الهرمية. لا تتحكم طريقة [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartseries/#setParentLabelLayout) في تسميات حلقاتها.
- يستخدم كلا النوعين نفس مستويات تجميع الفئات ونفس ترتيب الورقة إلى الأصل الذي تُرجعه [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapoint/#getDataPointLevels)، لذا يمكن مشاركة كود بناء البيانات وتنسيق المستويات.
- تُحسب قيم الأصل من أوراقها التابعة. لا تُضف نقاطًا رقمية منفصلة للفروع أو الجذور.

### **الترتيب وتتابع القطاعات**

يحدد محرك تخطيط المخطط الموقع النهائي للمستطيلات وقطاعات الحلقة. رتب صفوف الفئة ذات الصلة معًا قبل إضافتها، ولكن لا تعتمد على موقع مستطيل محدد أو زاوية بدء محددة. إذا كان التسلسل يحمل معنى، أدمجه في التسميات أو استخدم نوع مخطط يُظهر محور فئة صريح.

### **المظهر والألوان الثابتة**

تُورث مستويات المخطط غير المُنسقة الألوان من سمة العرض التقديمي. يستخدم المثال ملء RGB صريح للحصول على مخرجات متوقعة. إذا أردت أن يتبع المخطط تغييرات السمة، استخدم ألوان المخطط بدلاً من قيم RGB ثابتة وتجنّب تجاوز كل مستوى. كما يُنصح بالتحقق من تباين التسمية بعد تغيير ملء فرع أو جذر.

### **التسميات والمساحة المتاحة**

قد يخفي PowerPoint أو يقتطع التسميات عندما يكون القطاع صغيرًا جدًا. زيادة حجم المخطط، تقصير أسماء الفئات، أو إظهار عدد أقل من حقول التسمية عادةً ما ينتج نتيجة أوضح. يمكن للتسمية دمج اسم الفئة، اسم السلسلة، والقيمة عبر [DataLabelFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datalabelformat/)، لكن تمكين كل الحقول غالبًا ما يجعل المخططات الهرمية صعبة القراءة.

### **التصدير والتصيير**

يحفظ حفظ الملف بصيغة PPTX المخطط قابلًا للتعديل. عندما تقوم Aspose.Slides بتصيير العرض التقديمي إلى PDF أو صورة، تُصَرّف التعبئات وإعدادات التسميات المدعومة مع المخطط. قد تغير استبدال الخطوط والاختلافات الصغيرة في مساحة التخطيط المتاحة طريقة التفاف النص أو ظهور التسمية، لذا ثبّت الخطوط المطلوبة وتحقق من أهداف التصدير المهمة.

## **الأسئلة المتكررة**

**لماذا يؤدي تعديل مستوى أصل إلى تأثير عدة أوراق؟**

الفرع أو الجذر هو قطاع بصري مُشترك. يمكن الوصول إلى [ChartDataPointLevel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdatapointlevel/) عبر ورقة تابعة، لكن التنسيق يخص القطاع الأصلي المشترك وليس الورقة فقط.

**لماذا تت缺 تسمية البيانات؟**

أولاً فعّل الحقول المطلوبة على كائن [DataLabelFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/datalabelformat/) الخاص بالتسمية. ثم تحقق مما إذا كان للقطاع مساحة كافية. يؤثر تخطيط تسميات أصل Treemap، أبعاد المخطط، طول التسمية، حجم الخط، وعدد الحقول المفعلة جميعًا على إمكانية عرض التسمية.

**هل يمكنني تحديد الترتيب أو إحداثيات القطاعات بدقة؟**

يمكنك التحكم في ترتيب الصفوف المصدرية وإبقاء كل مجموعة متتابعة، لكن لا يمكنك تعيين مستطيلات Treemap أو زوايا Sunburst بدقة. يحسب محرك تخطيط المخطط هذه القيم من الهرمية والقيم والمساحة المتاحة.

**لماذا تتغير الألوان بعد تغيير سمة العرض التقديمي؟**

التعبئات القائمة على السمة مُصممة لتتبع لوحة ألوان العرض. استخدم ألوان RGB صريحة للمستويات التي يجب أن تظل ثابتة، أو احتفظ بألوان المخطط عندما يكون التكيّف مع سمة جديدة مفضلًا.

**هل سيُحفظ التنسيق المخصص في تصدير PDF والصور؟**

نعم، تُدرج تعبئات المخطط وإعدادات التسميات المدعومة أثناء التصيير. للحصول على نتائج متسقة بين الأنظمة، وفّر الخطوط المطلوبة واختبر حجم التصدير النهائي لأن ملاءمة التسمية تعتمد على التخطيط.

## **انظر أيضًا**

- [Create Treemap charts](/slides/ar/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ar/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ar/python-java/export-chart/)
- [Manage presentation themes](/slides/ar/python-java/presentation-theme/)