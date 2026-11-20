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
- अक्ष को प्रबंधित करें
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
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में रिपोर्ट और दृश्यावलोकन के लिए चार्ट अक्षों को अनुकूलित करने के तरीकों की खोज करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via .NET का उपयोग करके चार्ट अक्षों को अनुकूलित करने के तरीकों को समझाता है। इसमें गणना किए गए अक्ष मान, चार्ट पंक्तियों और स्तम्भों का अदला‑बदली, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियाँ और स्वरूपण, शीर्षक का घुमाव, अक्ष का स्थान, प्रदर्शित इकाइयाँ और लघुगणकीय स्केलिंग शामिल हैं।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

डिफ़ॉल्ट डेटा के साथ एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) बनाएं और एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले चार्ट लेआउट को अद्यतन रखने के लिए [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) को कॉल करें।

अक्ष सीमाओं के लिए [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) और [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) पढ़ें, तथा टिक अंतराल के लिए [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) और [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) पढ़ें। तिथि अक्षों से संबंधित समय‑इकाई स्केल के लिए [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) और [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) उपलब्ध होते हैं। यह उदाहरण इन मानों को स्थानीय चरों में संग्रहीत करता है और चार्ट को सहेजता है।

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

चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाओं को बदलने के लिए [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बनती है और प्रत्येक पूर्व श्रृंखला एक श्रेणी बनती है। यह डेटा के समूह को बदलता है; यह क्षैतिज और लंबवत अक्षों का अदला‑बदला नहीं करता। उदाहरण में [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` (हेडर पंक्ति और श्रेणी स्तम्भ सहित) से बाँधा गया है, फिर पंक्तियों और स्तम्भों को बदला गया है। यह चार श्रृंखलाओं और तीन श्रेणियों वाला चार्ट सहेजता है।

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

## **अक्ष की प्लॉट क्रम उलटना**

अक्ष को उलटने के लिए [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) का प्रयोग करें। उदाहरण के लिये, एक क्षैतिज बार चार्ट परियोजना चरणों को वर्कशीट क्रम में शीर्ष‑से‑नीचे दिखा सकता है: Planning, Development, Testing। अक्ष को उलटने से प्लॉट दिशा बदलती है; यह वर्कबुक डेटा को सॉर्ट या पुनः व्यवस्थित नहीं करता। तुलना के लिये, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) श्रृंखला और श्रेणियों की भूमिकाओं को बदलता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला वाला क्षैतिज बार चार्ट बनाता है। यह तीन स्लाइडों वाली प्रस्तुति सहेजता है: सामान्य क्रम, उल्टे श्रेणी, और उल्टे मान। प्रत्येक प्रतिलिपि समान डेटा सेट का उपयोग करती है, और प्रत्येक में केवल एक ही अक्ष उलटा होता है।

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

    # स्लाइड 2: पहली श्रेणी को शीर्ष पर प्रदर्शित करें।
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # क्षैतिज मान अक्ष को नीचे रखें।
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उलटें।
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

अक्ष को उलटने से लंबरूप अक्ष को प्लॉट के विपरीत पक्ष पर ले जाया जा सकता है। [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) निर्धारित करता है कि दूसरी अक्ष कहाँ पर निर्धारित अक्ष को पार करती है। स्लाइड 2 में, उल्टे श्रेणी अक्ष पर `MAXIMUM` सेट करने से क्षैतिज मान अक्ष नीचे रहता है। विशिष्ट पार‑बिंदु के लिये, [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) का प्रयोग करें। दिशा बदलते समय पार‑सेटिंग्स की जाँच करें, विशेषकर यदि चार्ट में पहले से कस्टम पार‑बिंदु है। सामान्य प्लॉट दिशा पुनः स्थापित करने के लिये `is_plot_order_reversed` को `False` सेट करें; पार‑सेटिंग्स अलग रहती हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टा श्रेणी (स्लाइड 2) | उल्टा मान (स्लाइड 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे‑से‑ऊपर आती हैं; मान बाएँ‑से‑दाएँ बढ़ते हैं। | Planning, Development, और Testing शीर्ष‑से‑नीचे दिखती हैं। मान और वर्कबुक पंक्ति क्रम अपरिवर्तित रहता है। | श्रेणियाँ सामान्य क्रम रखती हैं; मान दाएँ‑से‑बाएँ बढ़ते हैं। श्रेणी अक्ष शून्य पर दाएँ पार करता है। |

## **लाइन चार्ट में लंबवत अक्ष को निष्क्रिय करें**

लंबवत अक्ष को छिपाने के लिये वह अक्ष पर [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) को `False` सेट करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और लंबवत अक्ष छिपा कर सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **लाइन चार्ट में क्षैतिज अक्ष को निष्क्रिय करें**

क्षैतिज अक्ष को छिपाने के लिये वह अक्ष पर [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) को `False` सेट करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और क्षैतिज अक्ष छिपा कर सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट ग्रिडलाइन दिखाएँ या छिपाएँ**

किस अक्ष पर कौन सी ग्रिडलाइन दिखाई देती हैं, यह जांचने के लिये [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) और [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) पढ़ें। दोनों गुण केवल‑पढ़ने योग्य हैं। मायनर ग्रिडलाइन दिखाने के लिये [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) में लाइन फ़िल को ठोस भराव सेट करें और दृश्यमान रंग चुनें। उन्हें छिपाने के लिये फ़िल प्रकार को `FillType.NO_FILL` सेट करें। मेजर ग्रिडलाइन के लिये, [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format` का प्रयोग करें। फ़िल बदलने से अक्ष की दृश्यता और टिक‑मार्क नहीं बदलते।

इस क्लस्टर्ड कॉलम चार्ट की लंबवत अक्ष प्रारंभ में मेजर ग्रिडलाइन दिखाती है और मायनर ग्रिडलाइन छिपी रहती है। उदाहरण पहले मायनर ग्रिडलाइन को नारंगी दिखाता है, फिर उन्हें फिर से छिपाकर प्रस्तुति सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| मायनर ग्रिडलाइन सक्रिय | मायनर ग्रिडलाइन छिपी |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **श्रेणी अक्ष बदलें**

श्रेणी अक्ष को तिथि या पाठ प्रकार चुनने के लिये [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) सेट करें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहले स्लाइड की पहली आकृति पर एक चार्ट है और श्रेणी कोशिकाएँ संख्यात्मक Excel तिथि मान रखती हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) को `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) को `1`, और [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) को `months` सेट करने से मेजर टिक एक‑महीने के अंतराल पर रखे जाते हैं।

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

### **डेटा से श्रेणी अक्ष प्रकार निर्धारित करें**

श्रेणियों को भरने के बाद [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) को कॉल करें, फिर [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) पढ़ें ताकि चयन देखा जा सके। यह उसी समय प्रकार निर्धारित करता है; यह बाद में डेटा परिवर्तन पर पुनः‑मूल्यांकन नहीं करता। श्रेणियों को बदलने के बाद इसे पुनः कॉल करें।

निम्न उदाहरण पाठ श्रेणियों वाला चार्ट बनाकर `TEXT` प्रिंट करता है। फिर श्रेणी कोशिका मानों को तिथियों से बदलता है और फिर से मेथड को कॉल करता है, जिससे `DATE` प्रिंट होता है। तिथियों को संख्यात्मक OLE Automation मानों के रूप में संग्रहीत किया जाता है, जो 30 December 1899 से बीते दिनों की संख्या होते हैं, न कि तिथि स्ट्रिंग। [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) निर्धारित करता है कि ये मान कैसे दिखाए जाएँ; यह पाठ को संख्यात्मक तिथियों में नहीं बदलता। श्रेणी कोशिकाओं के बारे में अधिक जानकारी के लिये देखें [Chart Workbook](/slides/hi/python-net/chart-workbook/)।

इनपुट में यदि केवल पाठ श्रेणियाँ या संख्यात्मक तिथियाँ हों तो स्वचालित निर्धारण का प्रयोग करें, जैसा कि इस उदाहरण में दिखाया गया है। सामान्य संख्यात्मक लेबल, मिश्रित श्रेणियाँ, या खाली डेटा के लिये स्पष्ट रूप से [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) सेट करें ताकि इच्छित अर्थ के साथ मेल खाए। केवल संख्यात्मक मान यह स्थापित नहीं करते कि श्रेणियाँ तिथियों को दर्शाती हैं।

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # पाठ

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # तारीख

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियाँ हों, तो बिना श्रेणियों या डेटा बिंदुओं को हटाए दृश्य लेबल की संख्या घटाएँ। [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) को `False` करें, फिर इच्छित श्रेणी अंतराल के लिये [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) सेट करें। सामान्य क्रम में पाठ श्रेणियों के लिये गणना पहले श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में दर्शाए गए लेबल |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` का अंतराल प्रत्येक तीसरा लेबल दिखाता है, दो लेबल छुपे रहते हैं। यह संबंधित स्तम्भों को नहीं हटाता। स्वचालित स्पेसिंग उपलब्ध स्थान के आधार पर अंतराल चुनती है; यह आवश्यक नहीं कि हर लेबल दिखे।

टिक‑मार्क के लिये अलग नियंत्रण होते हैं। [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) को `False` करें और [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) के द्वारा उनका अंतराल सेट करें। उदाहरण के लिये, `1` सेट करने से प्रत्येक श्रेणी अंतराल पर टिक‑मार्क रहता है जबकि लेबल केवल प्रत्येक तीसरे श्रेणी पर दिखते हैं। दिखाने योग्य शैली के लिये [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) सेट करें। स्वचालित‑स्पेसिंग गुण को फिर से `True` करने से चार्ट को वही अंतराल फिर से चुनने की अनुमति मिलती है।

निम्न स्वनिर्भर उदाहरण 24 श्रेणियों और एक श्रृंखला बनाकर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र टिक‑मार्क के साथ मैन्युअल लेबल स्पेसिंग, और पुनः स्वचालित स्पेसिंग। दो प्रतिलिपियों में मूल चार्ट डेटा रहता है। इनपुट प्रस्तुति की आवश्यकता नहीं है। क्षैतिज लेबल पाठ घनत्व को आसानी से दिखाता है।

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

    # स्लाइड 2: प्रत्येक तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिये एक टिक‑मार्क रखें।
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

**स्वचालित स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में प्रत्येक दूसरी श्रेणी लेबल दिखाया जाता है और दो पंक्तियों में लिपटे होते हैं। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के आधार पर बदल सकता है।

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**मैन्युअल स्पेसिंग (स्लाइड 2):** प्रत्येक तीसरे लेबल को एक पंक्ति में दिखाया जाता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर रहते हैं। सभी 24 स्तम्भ, चुनिंदा लेबल के बिना भी, समान मान के साथ दिखाई देते हैं। स्लाइड 3 स्वचालित रूप से ऊपर दिखाए गये स्वरूप को पुनर्स्थापित करता है।

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष, जैसे कि कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष, के लिये यह श्रेणी‑गणना अंतराल प्रयोग करें। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लंबवत होता है, इसलिए इन्हें [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) पर लागू करें। टिक‑मार्क स्पेसिंग उन चार्टों में श्रृंखला‑अक्ष पर भी लागू होती है जिनमें वह मौजूद हो।

श्रेणी‑लेबल स्पेसिंग का प्रयोग मान अक्ष के संख्यात्मक स्केल को सेट करने के लिये न करें। मान अक्ष में, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिये, `10` का मेजर यूनिट शून्य से शुरू होने पर 0, 10, 20 आदि पर टिक रखता है। `3` का श्रेणी‑लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों से असंबंधित। स्कैटर और बबल चार्ट मान अक्षों का प्रयोग करते हैं, न कि पाठ श्रेणी अक्ष का। तिथि अक्ष के लिये, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित मेजर यूनिट और स्केल का प्रयोग करें।

## **श्रेणी अक्ष मानों के लिये तिथि स्वरूप निर्धारित करें**

यह उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियाँ पहले कार्यपत्रक (अनुक्रमणिका `0`) में OLE Automation क्रमांक के रूप में संग्रहीत हैं। [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) को तिथि अक्ष पर सेट करें, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) को अक्षम करें, और लेबल को चार‑अंकीय वर्ष दिखाने के लिये [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) को `yyyy` निर्धारित करें, जिससे श्रेणी लेबल सेल स्वरूप से स्वतंत्र रूप से दिखे।

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

## **चार्ट अक्ष शीर्षक के लिये घुमाव कोण निर्धारित करें**

लंबवत अक्ष पर [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) सक्षम करें, शीर्षक पाठ प्रदान करें, और [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) को सेट करके शीर्षक को घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण मान‑अक्ष शीर्षक को 90 डिग्री घुमा कर कॉलम चार्ट सहेजता है।

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

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) का प्रयोग करके निर्धारित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करता है। यह गुण केवल श्रेणी अक्षों पर लागू होता है। उदाहरण में इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `True` सेट करके परिणाम सहेजा गया है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट मान अक्ष पर प्रदर्शित इकाई निर्धारित करें**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) को सेट करके मान अक्ष पर लेबल का स्केल बदले बिना डेटा नहीं बदले जाता। जब [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) `MILLIONS` पर सेट हो, तो 60 000 000 को 60 दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसकी लंबवत अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **लघुगणकीय मान अक्ष कॉन्फ़िगर करें**

जब सकारात्मक मान कई क्रमांकों में फैले हों तो लघुगणकीय मान अक्ष उपयोगी होता है। उदाहरण के लिये, एक सेवा पाँच अवधियों में 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट आपस में बहुत निकट दिखाई देते हैं। लघुगणकीय स्केल सापेक्ष वृद्धि को आसान तुलना प्रदान करता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान अक्ष पर [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) को `True` सेट करें और लघुगणकीय आधार चुनने के लिये [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) का प्रयोग करें। यह मौजूदा मानों के प्रदर्शन को बदलता है; यह डेटा नहीं बदलता और न ही लघुगणकीय ट्रेंड‑लाइन जोड़ता है। ट्रेंड‑लाइन डेटा में फिटेड संबंध का प्रतिनिधित्व करती है और अलग सुविधा है।

### **मान अक्ष और आधार चुनें**

लाइन या कॉलम चार्ट के लिये मान अक्ष [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) होता है। क्षैतिज बार चार्ट के लिये यह [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) होता है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मान के लिये क्षैतिज और Y मान के लिये लंबवत अक्ष चुनें, या दोनों। श्रेणी अक्ष पर लघुगणकीय स्केल लागू न करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट में `2` से `1000` तक (समावेशी) आधार प्रयोग किया जा सकता है; अंशात्मक आधार जैसे `2.5` भी समर्थित हैं। आधार `10` पर क्रमशः 10, 100, 1 000, 10 000 समान अंतराल पर होते हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना करें**

निम्न स्वनिर्भर उदाहरण पहला स्लाइड पर पाँच अनुरोध गणनाओं वाला लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करके दूसरे स्लाइड पर आधार‑10 लघुगणकीय मान अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा रखती हैं।

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

    # पहली स्लाइड को रैखिक रखें और केवल कॉपी के मान-अक्ष स्केल को बदलें।
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**रैखिक स्केल (स्लाइड 1):** समान ऊँचाई अंतर समान अनुरोध सीमा अंतर दर्शाती है। सबसे बड़ा मान चार्ट को प्रभुत्व देता है, जिससे छोटे मान दिखना कठिन हो जाता है।

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊँचाई अंतर समान अनुपात दर्शाती है। प्रत्येक अवधि की अनुरोध संख्या पिछले से दस गुना अधिक है, इसलिए बिंदु आधार‑10 स्केल पर सीधी रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणना दिखाते हैं।

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शून्य से बड़े मान दिखा सकता है। इसे सक्षम करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिये उन मानों को हटाना उचित है, तो वर्जन का कारण बताएँ। उन्हें छोटे सकारात्मक मानों से मौन बदलना डेटा का अर्थ बदल देगा। लघुगणकीय अक्ष के लिये किसी भी मैन्युअल न्यूनतम या अधिकतम को भी सकारात्मक होना चाहिए।

## **बारंबार पूछे जाने वाले प्रश्न**

**एक अक्ष को दूसरे के साथ कहाँ पार करना है (axis crossing) इसे कैसे निर्धारित करूँ?**

अक्ष के पार‑बिंदु व्यवहार को चुनने के लिये [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) का उपयोग करें। संख्यात्मक पार‑बिंदु निर्दिष्ट करने के लिये [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) सेट करें। ये सेटिंग्स आपको अक्ष पार‑बिंदु को उपयुक्त बेसलाइन पर स्थानांतरित करने देती हैं।

**मैं टिक‑लेबल को अक्ष के सापेक्ष कैसे स्थानित करूँ?**

[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) को [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) (`LOW`, `HIGH`, `NEXT_TO`, या `NONE`) के साथ सेट करें। टिक‑मार्क स्वयं को नियंत्रित करने के लिये [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) या [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) का प्रयोग करें; ये लेबल स्थितियों से अलग हैं।