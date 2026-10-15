---
title: Python के साथ प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/python-net/chart-axis/
keywords:
- चार्ट अक्ष
- लंबवत अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को हेरफेर करें
- अक्ष का प्रबंधन करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में रिपोर्ट और दृश्यात्मकता के लिए चार्ट अक्षों को अनुकूलित करने के तरीके की खोज करें।"
---
## **सारांश**

यह लेख Aspose.Slides for Python via .NET के साथ चार्ट अक्षों को अनुकूलित करने का तरीका समझाता है। यह गणना किए गए अक्ष मानों, चार्ट की पंक्तियों और स्तंभों को बदलने, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक का घुमाव, अक्ष की स्थिति, डिस्प्ले यूनिट और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) को कॉल करें ताकि चार्ट लेआउट अद्यतन हो।

अक्ष सीमा के लिए [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) और [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) पढ़ें, और टिक अंतराल के लिए [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) और [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) पढ़ें। [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) और [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चर में संग्रहीत करता है और चार्ट को सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्षों के बीच डेटा बदलें**

चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाओं को बदलने के लिए [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूह बनाने के तरीके को बदलता है; यह क्षैतिज और लंबवत अक्षों को नहीं बदलता। उदाहरण [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल हैं, पंक्तियों और स्तंभों को बदलने से पहले। यह चार श्रृंखलाओं और तीन श्रेणियों वाले चार्ट को सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्ष के प्लॉटिंग क्रम को उल्टा करें**

एक श्रेणी या मान अक्ष को उल्टा करने के लिए [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) का उपयोग करें। उदाहरण के लिए, एक क्षैतिज बार चार्ट वर्कशीट के समान क्रम में ऊपर से नीचे परियोजना चरण दिखा सकता है: Planning, Development, Testing। अक्ष को उल्टा करने से प्लॉटिंग दिशा बदलती है; यह वर्कबुक डेटा को क्रमबद्ध या पुन: व्यवस्थित नहीं करता। तुलना के लिए, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) श्रृंखला और श्रेणियों की भूमिकाओं को बदलता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला के साथ एक क्षैतिज बार चार्ट बनाता है। यह तीन स्लाइडों के साथ एक प्रस्तुति सहेजता है: सामान्य क्रम, उल्टे श्रेणियाँ, और उल्टे मान। प्रत्येक प्रति समान डेटासेट उपयोग करती है, और प्रत्येक प्रति में केवल एक अक्ष उल्टा किया गया है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # स्लाइड 2: शीर्ष पर पहली श्रेणी प्रदर्शित करें।
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # क्षैतिज मान अक्ष को नीचे रखें।
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उल्टा करें।
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

एक अक्ष को उल्टा करने से लंबरूप अक्ष को प्लॉट के विपरीत पक्ष पर ले जाया जा सकता है। [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) नियंत्रित करता है कि अन्य अक्ष किस बिंदु पर कॉन्फ़िगर किए जा रहे अक्ष को क्रॉस करता है। स्लाइड 2 में, उल्टे श्रेणी अक्ष पर इसे `MAXIMUM` पर सेट करने से क्षैतिज मान अक्ष नीचे बना रहता है। किसी विशिष्ट क्रॉसिंग बिंदु के लिए, [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) का उपयोग करें। दिशा बदलते समय क्रॉसिंग सेटिंग्स की जाँच करें, विशेष रूप से यदि चार्ट में पहले से एक कस्टम क्रॉसिंग बिंदु है। सामान्य प्लॉटिंग दिशा को पुनर्स्थापित करने के लिए `is_plot_order_reversed` को `False` पर सेट करें; क्रॉसिंग सेटिंग्स अलग हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टे श्रेणियाँ (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान अक्ष क्रम के साथ क्षैतिज बार चार्ट](axis-order-normal.png) | ![ऊपर से नीचे श्रेणियों के साथ क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![उल्टा मान अक्ष और दाएँ शून्य के साथ क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे से ऊपर तक चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | योजना, विकास, और परीक्षण ऊपर से नीचे चलते हैं। मान और वर्कबुक पंक्तियों का क्रम अपरिवर्तित रहता है। | श्रेणियाँ अपने सामान्य क्रम को बनाए रखती हैं; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष दाएँ शून्य पर क्रॉस करता है। |

## **लाइन चार्ट के लिए लंबवत अक्ष अक्षम करें**

लंबवत अक्ष को छिपाने के लिए उस पर [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) को `False` सेट करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे लंबवत अक्ष छिपे हुए सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष अक्षम करें**

क्षैतिज अक्ष को छिपाने के लिए उस पर [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) को `False` सेट करें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे क्षैतिज अक्ष छिपे हुए सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **श्रेणी अक्ष बदलें**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) को सेट करके तिथि या टेक्स्ट श्रेणी अक्ष चुना जा सकता है। इस उदाहरण में `ExistingChart.pptx` आवश्यक है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) को `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) को `1`, और [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) को महीनों पर सेट करने से प्रमुख टिक एक महीने के अंतराल पर रखे जाते हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियाँ हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्यमान अक्ष लेबलों की संख्या घटाई जा सकती है। [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) को `False` पर सेट करें, फिर वांछित श्रेणी अंतराल के लिए [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) को सेट करें। सामान्य क्रम में टेक्स्ट श्रेणियों के लिए गणना पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, ... श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, ... श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, ... श्रेणी 22 |

`3` का अंतराल प्रत्येक तृतीय लेबल को दिखाता है, प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वचालित स्पेसिंग उपलब्ध स्थान के आधार पर एक अंतराल चुनती है; यह आवश्यक रूप से प्रत्येक लेबल नहीं दिखाती।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) को `False` पर सेट करें और उनके अंतराल को निर्धारित करने के लिए [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) का उपयोग करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर एक टिक‑मार्क रखता है जबकि लेबल केवल प्रत्येक तृतीय श्रेणी पर दिखाई देते हैं। परिणाम देखने के लिए [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) को एक दृश्यमान शैली पर सेट करें। किसी भी स्वचालित‑स्पेसिंग गुण को फिर से `True` पर सेट करने से चार्ट उस अंतराल को फिर से चुनता है।

निम्न स्वनिहित उदाहरण 24 श्रेणियाँ और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र टिक‑मार्क के साथ मैन्युअल लेबल स्पेसिंग, और पुनर्स्थापित स्वचालित स्पेसिंग। दो प्रतियां मूल चार्ट डेटा को बनाए रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व में अंतर को आसानी से दिखाता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # स्लाइड 2: हर तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें।
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # स्लाइड 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**स्वचालित स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में प्रत्येक दूसरी श्रेणी लेबल दिखाई देती है और दो पंक्तियों में लिपट जाती है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![सभी 24 स्तंभ दृश्यमान के साथ स्वचालित श्रेणी लेबल अंतराल](category-axis-automatic.png)

**मैन्युअल स्पेसिंग (स्लाइड 2):** प्रत्येक तृतीय लेबल एक पंक्ति में दिखाई देता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बने रहते हैं। सभी 24 स्तंभ, जिनमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचालित रूप को पुनर्स्थापित करती है।

![तीन के मैन्युअल श्रेणी लेबल अंतराल के साथ सभी 24 स्तंभ दृश्यमान](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

एक टेक्स्ट श्रेणी अक्ष के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कि कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लंबवत होता है, इसलिए इन सेटिंग्स को [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) पर लागू करें। टिक‑मार्क स्पेसिंग उन चार्टों में श्रृंखला अक्ष पर भी लागू होती है जिनमें ऐसा अक्ष होता है।

श्रेणी लेबल स्पेसिंग का उपयोग मान अक्ष के संख्यात्मक स्केल को निर्धारित करने के लिए न करें। मान अक्ष पर, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिए, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल श्रेणी स्थितियों की गणना करता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट टेक्स्ट श्रेणी अक्ष के बजाय मान अक्ष का उपयोग करते हैं। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयों और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियों को पहले कार्यपत्रक (इंडेक्स `0`) में OLE ऑटोमेशन सीरियल नंबरों के रूप में संग्रहीत किया जाता है। [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) को तिथि अक्ष पर सेट करें, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) को निष्क्रिय करें, और [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) को `yyyy` असाइन करें ताकि श्रेणी लेबल सेल स्वरूपण से स्वतंत्र रूप से चार-अंकीय वर्ष दिखाएँ।

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट अक्ष शीर्षक के लिए घुमाव कोण सेट करें**

लंबवत अक्ष पर [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) को सक्रिय करें, शीर्षक पाठ प्रदान करें, और शीर्षक को घुमाने के लिए [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) को सेट करें। कोण डिग्री में मापा जाता है; यह उदाहरण मान‑अक्ष शीर्षक को 90 डिग्री घुमा कर एक कॉलम चार्ट सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **श्रेणी या मान अक्ष पर अक्ष की स्थिति निर्धारित करें**

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) का उपयोग करके नियंत्रित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर कब पार करे। यह गुण श्रेणी अक्षों पर लागू होता है। उदाहरण ने इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `True` सेट किया और परिणाम सहेजा।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट मान अक्ष पर डिस्प्ले यूनिट सेट करें**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) को सेट करके मान अक्ष पर लेबलों का स्केल बदला जा सकता है без मूल डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) को `MILLIONS` पर सेट किया जाता है, तो 60,000,000 का मान 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके लंबवत अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **लघुगणकीय मान अक्ष को कॉन्फ़िगर करें**

जब सकारात्मक मान कई क्रम magnitude में होते हैं, तो लघुगणकीय मान अक्ष उपयोगी होता है। उदाहरण के लिए, एक सेवा पाँच अवधियों में 10, 100, 1,000, 10,000 और 100,000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट बहुत करीब दिखाई देते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि को तुलना करना आसान बनाता है: समान दूरी समान अनुपात को दर्शाती है, समान अंतर को नहीं।

मान अक्ष पर [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) को `True` सेट करें और आधार चुनने के लिए [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित रूप को बदलता है; यह डेटा को नहीं बदलता या लघुगणकीय ट्रेंड‑लाइन नहीं जोड़ता। ट्रेंड‑लाइन डेटा में एक फिटेड संबंध को दर्शाती है और अलग सुविधा है।

### **मान अक्ष और आधार चुनें**

लाइन या कॉलम चार्ट के लिए, मान अक्ष [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) है। क्षैतिज बार चार्ट के लिए, वह [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिए क्षैतिज अक्ष, Y मानों के लिए लंबवत अक्ष, या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्टों के लिए `2` से `1000` (शामिल) के बीच कोई भी आधार उपयोग किया जा सकता है; `2.5` जैसी भिन्नात्मक आधार भी समर्थित हैं। आधार `10` के साथ क्रमागत शक्ति — 10, 100, 1,000, 10,000 — समान दूरी पर होती हैं।

### **रैखिक और लघुगणकीय स्केलिंग की तुलना**

निम्न स्वनिहित उदाहरण पहली स्लाइड पर पाँच अनुरोध गणनाओं के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड की प्रतिलिपि बनाता है और दूसरी पर आधार‑10 लघुगणकीय मान अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा बनाए रखती हैं।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # पहली स्लाइड को रैखिक रखें और केवल कॉपी के वैल्यू-एक्सिस स्केल को बदलें।
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**रैखिक स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी अनुरोध गणनाओं में समान अंतर दर्शाती है। सबसे बड़ा मान चार्ट पर हावी होता है, जिससे छोटे मानों को अलग‑अलगा देखना कठिन हो जाता है।

![PowerPoint में रैखिक मान अक्ष पर पाँच अनुरोध गणनाओं के साथ लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु आधार‑10 स्केल पर सीधी बढ़ती रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणनाओं को दिखाते हैं।

![PowerPoint में आधार‑10 लघुगणकीय मान अक्ष पर वही पाँच अनुरोध गणनाएँ](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल सशर्त सकारात्मक मान दिखा सकता है। इसे सक्षम करने से पहले डेटा की जाँच करें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग‑अलग दिखाएँ। यदि विश्लेषण के लिए उन मानों को बाहर करना उचित है, तो अपवर्जन का कारण स्पष्ट करें। उन्हें चुपचाप छोटे सकारात्मक संख्याओं से न बदलें, क्योंकि इससे डेटा का अर्थ बदल जाता है। लघुगणकीय अक्ष के लिए मैन्युअल रूप से कॉन्फ़िगर किया गया कोई भी न्यूनतम या अधिकतम मान भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक अक्ष को दूसरे के ऊपर किस मान पर क्रॉस कराना है (अक्ष क्रॉसिंग) को कैसे सेट करूँ?**  
[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) का उपयोग करके क्रॉसिंग व्यवहार चुनें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिए [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) को सेट करें। ये सेटिंग्स आपको अक्ष क्रॉसिंग को उपयुक्त बेजलाइन पर ले जाने में मदद करती हैं।

**टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करें?**  
[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) को [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) के साथ सेट करें: `LOW`, `HIGH`, `NEXT_TO` या `NONE`। टिक‑मार्क स्वयं को नियंत्रित करने के लिए [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) या [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) का उपयोग करें; ये लेबल स्थितिकरण से अलग हैं।