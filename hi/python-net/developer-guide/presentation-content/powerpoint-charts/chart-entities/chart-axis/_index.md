---
title: Python के साथ प्रस्तुतियों में चार्ट अक्ष को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/python-net/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को नियंत्रित करें
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
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में रिपोर्ट और विज़ुअलाइज़ेशन के लिए चार्ट अक्ष को कैसे अनुकूलित किया जाए, जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via .NET के साथ चार्ट अक्षों को अनुकूलित करने के तरीके को समझाता है। इसमें गणना किए गए अक्ष मान, चार्ट पंक्तियों और स्तंभों को बदलना, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियाँ और स्वरूपण, शीर्षक का घुमाव, अक्ष का स्थान और प्रदर्शन इकाइयाँ शामिल हैं।

## **चार्ट में ऊर्ध्वाधर अक्ष पर अधिकतम मान प्राप्त करना**

एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) बनाएँ और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) को कॉल करें ताकि चार्ट लेआउट अद्यतित हो।

अक्ष की सीमाओं के लिए [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) और [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) पढ़ें, और टिक अंतराल के लिए [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) और [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) पढ़ें। समय‑एकक स्केल के लिए [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) और [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) उपयोग करें, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चरों में संग्रहीत करता है और चार्ट को सहेजता है।

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

## **अक्षों के बीच डेटा बदलना**

[swap_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) का उपयोग करके चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाओं को बदलें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बनती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बनती है। यह डेटा के समूह को बदलता है; यह क्षैतिज और ऊर्ध्वाधर अक्षों को नहीं बदलता। उदाहरण [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल है, फिर पंक्तियों और स्तंभों को बदलता है। यह चार्ट को चार श्रृंखलाएँ और तीन श्रेणियाँ के साथ सहेजता है।

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

## **लाइन चार्ट्स के लिए ऊर्ध्वाधर अक्ष निष्क्रिय करें**

ऊर्ध्वाधर अक्ष पर [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) को `False` सेट करके उसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे ऊर्ध्वाधर अक्ष छिपे हुए स्थिति में सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **लाइन चार्ट्स के लिए क्षैतिज अक्ष निष्क्रिय करें**

क्षैतिज अक्ष पर [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) को `False` सेट करके उसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे क्षैतिज अक्ष छिपे हुए स्थिति में सहेजता है।

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

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) को सेट करके तिथि या टेक्स्ट श्रेणी अक्ष चुनें। इस उदाहरण के लिए `ExistingChart.pptx` आवश्यक है, जिसमें पहले स्लाइड पर पहला आकार चार्ट है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) को `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) को `1` और [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) को `months` सेट करने से मुख्य टिक एक‑महीना अंतराल पर आते हैं।

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

जब चार्ट में कई श्रेणियाँ हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्य अक्ष लेबलों की संख्या घटाएँ। [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) को `False` सेट करें, फिर इच्छित श्रेणी अंतराल के लिए [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) सेट करें। टेक्स्ट श्रेणियों के सामान्य क्रम में, गिनती पहली श्रेणी से शुरू होती है:

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` का अंतराल प्रत्येक तीसरे लेबल को दिखाता है, और दिखाए गए लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर चुना जाता है; यह अनिवार्य रूप से सभी लेबल नहीं दिखाता।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) को `False` सेट करें और उनके अंतराल को सेट करने के लिए [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) उपयोग करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर टिक‑मार्क रखता है जबकि लेबल केवल प्रत्येक तीसरी श्रेणी पर दिखाई देते हैं। दृश्यमान शैली के लिए [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) सेट करें। दोनों स्वचालित‑अंतराल गुणों को फिर से `True` करने से चार्ट स्वयं वह अंतराल चुन लेगा।

निम्न स्व-समावेशी उदाहरण 24 श्रेणियाँ और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित अंतराल, स्वतंत्र टिक‑मार्क के साथ मैनुअल लेबल अंतराल, और पुनर्स्थापित स्वचालित अंतराल। दोनों कॉपी मूल चार्ट डेटा को रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व में अंतर को स्पष्ट रूप से दिखाता है।

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

    # Slide 2: हर तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें।
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slide 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatic spacing (slide 1):** इस प्रस्तुति में हर दूसरा श्रेणी लेबल दिखाया जाता है और दो पंक्तियों में लिपटे रहते हैं। स्वचालित परिणाम चार्ट के आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manual spacing (slide 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखाया जाता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बना रहता है। सभी 24 स्तंभ, जिसमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दृश्य रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचालित रूप को पुनर्स्थापित करता है।

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिए यह श्रेणी‑गणना अंतराल उपयोग करें, जैसे कि कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष ऊर्ध्वाधर होता है, इसलिए इन सेटिंग्स को [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) पर लागू करें। टिक‑मार्क का अंतराल उन चार्ट्स में श्रृंखला अक्ष पर भी लागू होता है जिनमें वह मौजूद होता है।

श्रेणी लेबल स्पेसिंग का उपयोग मान अक्ष के संख्यात्मक स्केल को सेट करने के लिए न करें। मान अक्ष पर, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिए, `10` का मुख्य इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट मान अक्षों का उपयोग करते हैं, न कि पाठ श्रेणी अक्ष का। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित मुख्य इकाइयों और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियाँ पहले कार्यपत्रक (सूचकांक `0`) में OLE ऑटोमेशन क्रमांक के रूप में संग्रहीत होती हैं। [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) को तिथि अक्ष पर सेट करें, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) को निष्क्रिय करें, और [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) को `yyyy` असाइन करें ताकि श्रेणी लेबल सेल फ़ॉर्मेट से स्वतंत्र रूप से चार अंकों वाला वर्ष दिखाएँ।

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

## **एक चार्ट अक्ष शीर्षक के लिए घुमाव कोण सेट करें**

ऊर्ध्वाधर अक्ष पर [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) को सक्षम करें, शीर्षक टेक्स्ट प्रदान करें, और शीर्षक को घुमाने के लिए [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) सेट करें। कोण डिग्री में मापा जाता है; यह उदाहरण एक कॉलम चार्ट को उसकी मान‑अक्ष शीर्षक 90 डिग्री घुमाए हुए स्थिति में सहेजता है।

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

## **श्रेणी या मान अक्ष पर अक्ष का स्थान सेट करें**

[value_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) (अक्ष‑के‑बीच‑श्रेणियों) का उपयोग करके निर्धारित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करे। यह गुण केवल श्रेणी अक्षों पर लागू होता है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `True` सेट करता है और परिणाम सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट मान अक्ष पर प्रदर्शन इकाई सेट करें**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) को सेट करके मान अक्ष पर लेबल को स्केल करें बिना मूल डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) `MILLIONS` पर सेट हो, तो 60,000,000 मान को 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसकी ऊर्ध्वाधर अक्ष पर मिलियन्स डिस्प्ले यूनिट लागू करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक अक्ष को दूसरे के पार कहाँ मिलता है (axis crossing) यह मान कैसे सेट करूँ?**

[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) का उपयोग करके क्रॉसिंग व्यवहार चुनें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिए [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) सेट करें। ये सेटिंग्स आपको अक्ष क्रॉसिंग को उपयुक्त बेसलाइन पर ले जाने देती हैं।

**मैं टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) का उपयोग करके [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) को `LOW`, `HIGH`, `NEXT_TO` या `NONE` पर सेट करें। टिक‑मार्क को स्वयं नियंत्रित करने के लिए [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) या [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) उपयोग करें; ये लेबल पोजिशनिंग से अलग हैं।