---
title: تخصيص نقاط البيانات في مخططات Treemap و Sunburst في Python
linktitle: نقاط البيانات في مخططات Treemap و Sunburst
type: docs
url: /ar/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط Treemap
- مخطط Sunburst
- مخطط هرمي
- نقطة بيانات
- تسمية بيانات
- لون الفرع
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء بيانات هرمية وتخصيص المستويات والتسميات والألوان في مخططات Treemap و Sunburst باستخدام Aspose.Slides لPython عبر .NET."
---
## **نظرة عامة**

تُظهر مخططات Treemap و Sunburst نوعًا واحدًا من البيانات الهرمية، لكنهما تستخدمان تخطيطات مختلفة. تُرسم Treemap الهرمية على شكل مستطيلات متداخلة تمثل قيم الأوراق من حيث المساحة. تُرسم Sunburst كحلقات متحدة المركز: تُقَرّب مجموعات المستوى الأعلى من المركز، وتُوضع فئات الأوراق على الحلقة الخارجية.

في Aspose.Slides for Python عبر .NET، كل قيمة عددية هي [ChartDataPoint](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/). توفر مجموعة [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) إمكانية الوصول إلى الورقة ومجموعات الأبوين الخاصة بها. يشرح هذا المقال هذا الربط ويُظهر كيفية إنشاء وتنسيق كلا نوعي المخططات من نفس بيانات العينة.

![مخطط Treemap مع فروع Consumer و Business](treemap-hierarchy.png)

![مخطط Sunburst مع نفس هيكل Consumer و Business](sunburst-hierarchy.png)

## **فهم الفئات ونقاط البيانات والمستويات**

العينة المستخدمة أدناه تحتوي على ثلاث مستويات فئة وسلسلة عددية واحدة:

| الفرع | السلسلة | العنصر | الإيرادات |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

كل صف يُنشئ فئة ورقية واحدة ونقطة بيانات واحدة. تصف مستويات تجميع الفئات المسار من تلك الورقة إلى الأبوين. بالنسبة للصف الأول، المسار هو `Consumer > Computers > Laptops`.

الفهارس في [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) تُعد من الورقة صعودًا:

| فهرس `data_point_levels` | المستوى المنطقي | تمثيل Treemap | تمثيل Sunburst |
| ---: | --- | --- | --- |
| `0` | ورقة | مستطيل القيمة | قطاع الحلقة الخارجية |
| `1` | سلسلة | مستطيل أو عنوان الأب | قطاع الحلقة المتوسطة |
| `2` | فرع | مستطيل أو عنوان المستوى الأعلى | قطاع الحلقة الداخلية |

هذا الترتيب هو نفسه لكلا نوعي المخططات رغم اختلاف تخطيطاتهما البصرية. يُشارك مقطع أب العديد من الأوراق. لتنسيقه، استخدم المستوى المقابل لأول نقطة بيانات في تلك المجموعة. على سبيل المثال، يبدأ فرع `Consumer` بنقطة `Laptops`، بينما يبدأ سطر `Software` بنقطة `Licenses`. الاحتفاظ بمراجع لتلك النقاط أوضح وأكثر أمانًا من استخدام تعبيرات غير مفسَّرة مثل `data_points[0]` أو `data_points[6]`.

## **إنشاء وتخصيص كلا النوعين من المخططات**

المثال الكامل التالي يُنشئ مخطط Treemap في الشريحة الأولى ومخطط Sunburst في الشريحة الثانية. يبني الهرمية، يعرض القيمة لـ `Tablets`، يطبق ألوانًا ثابتة على مستويات مختارة، يُنسق تسمية فرع، ويحفظ العرض التقديمي.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # أضف فئات الأوراق. يتم تعيين عنصر تجميع فقط عندما يبدأ مجموعة جديدة;
    # الفئات التالية تبقى في تلك المجموعة حتى يتم تعيين عنصر آخر.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # إظهار الفئة والقيمة على ورقة Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # تنسيق فرع Consumer عبر أول ورقة في ذلك الفرع.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # تنسيق السلسلة Software عبر أول ورقة في تلك السلسلة.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # يؤثر parent_label_layout على تسميات الوالد في Treemap؛ يستخدم Sunburst قطاعات الحلقة.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```


تستخدم خلايا الفئات وخلايا القيم نفس صف ورقة العمل، لذا تظل مواقع مجموعاتهما متطابقة. عند العمل على مخطط موجود بدلاً من إنشاء واحد، افحص صفوف الفئات أولًا وخزن مراجع مسماة لنقاط البيانات والمستويات التي تنوي تنسيقها.

## **السلوك والاعتبارات العملية**

### **اختلافات Treemap و Sunburst**

- يستخدم Treemap المساحة لنقل القيمة والمستطيلات المتداخلة لنقل الهرمية. تتحكم خاصية [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/parent_label_layout/) في كيفية ظهور تسميات الأبوين في هذا النوع من المخططات.
- يستخدم Sunburst الزاوية لنقل القيمة وعمق الحلقة لنقل الهرمية. لا تتحكم [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartseries/parent_label_layout/) في تسميات حلقاته.
- كلا النوعين يستخدمان نفس مستويات تجميع الفئات ونفس ترتيب الورقة إلى الأب في `data_point_levels`، لذا يمكن مشاركة كود بناء البيانات وتنسيق المستويات.
- تُحسب قيم الأبوين من أوراقهم التابعة. لا تضف نقاطًا عددية منفصلة للفروع أو السلاسل.

### **الفرز وترتيب القطاعات**

يحدد محرك تخطيط المخطط الموضع النهائي للمستطيلات وقطاعات الحلقة. رتب صفوف الفئات ذات الصلة معًا قبل إضافتها، لكن لا تعتمد على موضع مستطيل معين أو زاوية بدء محددة. إذا كان التسلسل يحمل معنى، فأدرجه في التسميات أو استخدم نوع مخطط يحتوي على محور فئات صريح.

### **السمة والألوان الثابتة**

ترث مستويات المخطط غير المُنسقة ألوانها من سمة العرض التقديمي. يستخدم المثال تعبئات RGB صريحة للحصول على مخرجات يمكن التنبؤ بها. إذا كان المخطط ينبغي أن يتبع تغييرات السمة، استخدم ألوان المخطط بدلاً من قيم RGB ثابتة وتجنب تجاوز كل مستوى. كما يجب فحص تباين التسميات بعد تغيير تعبئة فرع أو سلسلة.

### **التسميات والمساحة المتاحة**

قد يخفي PowerPoint أو يقتطع التسميات عندما يكون القطاع صغيرًا جدًا. زيادة حجم المخطط، تقصير أسماء الفئات، أو إظهار عدد أقل من حقول التسميات عادةً ما ينتج نتيجة أوضح. يمكن للتسمية دمج اسم الفئة واسم السلسلة والقيمة عبر [DataLabelFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/)، لكن تمكين كل الحقول غالبًا ما يجعل المخططات الهرمية صعبة القراءة.

### **التصدير والعرض**

يظل حفظ الملف كـ PPTX يتيح تعديل المخطط. عندما يقوم Aspose.Slides بتحويل العرض التقديمي إلى PDF أو صورة، تُرسم التعبئات وإعدادات التسميات المدعومة مع المخطط. يمكن أن تُغيّر استبدال الخطوط والاختلافات الصغيرة في مساحة التخطيط المتاحة الالتفاف أو رؤية التسميات، لذا قم بتثبيت الخطوط المطلوبة وتحقق من أهداف التصدير المهمة.

## **الأسئلة المتكررة**

**لماذا يؤثر تعديل مستوى أب على عدة أوراق؟**

الفرع أو السلسلة هو قطاع بصري مشترك. يمكن الوصول إلى [ChartDataPointLevel](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdatapointlevel/) عبر ورقة تابعة، لكن التنسيق يخص القطاع الأب المشترك وليس الورقة فقط.

**لماذا إحدى تسميات البيانات مفقودة؟**

أولاً فعِّل الحقول المطلوبة على كائن [DataLabelFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/datalabelformat/) الخاص بالتسمية. ثم تحقق مما إذا كان للقطاع مساحة كافية. يؤثر تخطيط تسميات الوالد في Treemap، أبعاد المخطط، طول التسمية، حجم الخط، وعدد الحقول المفعَّلة جميعًا على إمكانية عرض التسمية.

**هل يمكنني تحديد الترتيب الدقيق أو إحداثيات القطاعات؟**

يمكنك التحكم في ترتيب صفوف المصدر والحفاظ على كل مجموعة متصلة، لكن لا يمكنك تعيين مستطيلات Treemap أو زوايا Sunburst بدقة. يحسب محرك تخطيط المخطط هذه القيم من الهرمية والقيم والمساحة المتاحة.

**لماذا تتغير الألوان بعد تغيير سمة العرض التقديمي؟**

تُصمم التعبئات المعتمدة على السمة لتتبع لوحة ألوان العرض التقديمي. استخدم ألوان RGB صريحة للمستويات التي يجب أن تبقى ثابتة، أو احتفظ بألوان المخطط عند تعديل السمة.

**هل سيُحفظ التنسيق المخصص في تصدير PDF والصور؟**

نعم، تُدرج تعبئات المخطط المدعومة وإعدادات التسميات أثناء العرض. للحصول على نتائج متسقة عبر الأنظمة، وفّر الخطوط المطلوبة واختبر حجم التصدير النهائي لأن ملاءمة التسميات تعتمد على التخطيط.

## **انظر أيضًا**

- [Create Treemap charts](/slides/ar/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ar/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ar/python-net/export-chart/)
- [Manage presentation themes](/slides/ar/python-net/presentation-theme/)