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
- अक्ष का प्रबंधन
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
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में रिपोर्ट और विज़ुअलाइज़ेशन के लिए चार्ट अक्ष को कैसे अनुकूलित करें, जानें।"
---
## **सारांश**

यह लेख Aspose.Slides for Python via .NET के साथ चार्ट एक्सिस को अनुकूलित करने का तरीका समझाता है। यह गणना किए गए एक्सिस मानों, चार्ट पंक्तियों और स्तंभों की अदला‑बदली, एक्सिस दृश्यमानता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक घुमाव, एक्सिस स्थिति, प्रदर्शन इकाइयों और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट में ऊर्ध्वाधर अक्ष पर अधिकतम मान प्राप्त करें**

एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए एक्सिस मानों को पढ़ने से पहले [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) कॉल करें ताकि चार्ट लेआउट अद्यतित रहे।

[actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) और [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) को एक्सिस सीमाओं के लिए पढ़ें, और [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) तथा [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) को टिक अंतराल के लिए पढ़ें। [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) और [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि एक्सिस के लिए प्रासंगिक होते हैं। उदाहरण इन मानों को स्थानीय वेरिएबल्स में रखता है और चार्ट सहेजता है।

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

## **अक्षों के बीच डेटा अदला‑बदली करें**

[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) का उपयोग करके चार्ट डेटा में सीरीज़ और श्रेणियों की भूमिकाओं को बदलें। प्रत्येक पूर्व श्रेणी एक सीरीज़ बन जाती है, और प्रत्येक पूर्व सीरीज़ एक श्रेणी बन जाती है। यह डेटा के समूह बनाने के तरीके को बदलता है; यह क्षैतिज और ऊर्ध्वाधर अक्षों को नहीं बदलता। उदाहरण में [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड किया गया है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल है, फिर पंक्तियों और स्तंभों को बदला गया है। यह चार्ट चार सीरीज़ और तीन श्रेणियों के साथ सहेजता है।

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

## **लाइन चार्ट के लिए ऊर्ध्वाधर अक्ष को अक्षम करें**

ऊर्ध्वाधर अक्ष पर [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) को `False` सेट करके उसे छिपा दें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे ऊर्ध्वाधर अक्ष छिपे हुए सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष को अक्षम करें**

क्षैतिज अक्ष पर [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) को `False` सेट करके उसे छिपा दें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे क्षैतिज अक्ष छिपे हुए सहेजता है।

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

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) को सेट करके तिथि या पाठ श्रेणी अक्ष चुनें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहले स्लाइड की पहली आकृति के रूप में एक चार्ट है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) को `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) को `1`, और [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) को महीने सेट करने से प्रमुख टिक एक‑महीने के अंतराल पर दिखते हैं।

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

जब चार्ट में कई श्रेणियां हों, तो श्रेणियों या डेटा पॉइंट्स को हटाए बिना दिखाई देने वाले एक्सिस लेबलों की संख्या घटाएं। [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) को `False` सेट करें, फिर [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) को वांछित श्रेणी अंतराल पर सेट करें। सामान्य क्रम में पाठ श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, ... श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, ... श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, ... श्रेणी 22 |

`3` का अंतराल हर तीसरा लेबल दिखाता है, दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर अंतराल चुनता है; यह जरूरी नहीं कि हर लेबल दिखे।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) को `False` सेट करें और [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) से उनका अंतराल निर्धारित करें। उदाहरण के लिए, `1` हर श्रेणी अंतराल पर एक टिक‑मार्क रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखते हैं। [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) को दृश्यमान शैली पर सेट करें ताकि परिणाम दिखे। किसी भी स्वचालित‑स्पेसिंग प्रॉपर्टी को फिर से `True` करने से चार्ट स्वयं अंतराल चुन लेगा।

निम्न स्व-निहित उदाहरण 24 श्रेणियां और एक सीरीज़ बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र टिक‑मार्क के साथ मैनुअल लेबल स्पेसिंग, और पुनर्स्थापित स्वचालित स्पेसिंग। दोनों कॉपी मूल चार्ट डेटा को रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं। क्षैतिज लेबल पाठ घनत्व अंतर को स्पष्ट करता है।

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

    # स्लाइड 2: प्रत्येक तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें।
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

**स्वचालित अंतराल (स्लाइड 1):** इस रेंडरिंग में हर दूसरे श्रेणी लेबल दिखाया जाता है और दो पंक्तियों में रैप होता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के आधार पर बदल सकता है।

![स्वचालित श्रेणी लेबल स्पेसिंग जिसमें सभी 24 कॉलम दिखाए गए हैं](category-axis-automatic.png)

**मैनुअल अंतराल (स्लाइड 2):** हर तीसरा लेबल एक पंक्ति में दिखाया जाता है, जबकि टिक‑मार्क हर श्रेणी अंतराल पर रहते हैं। सभी 24 कॉलम, जिनमें बिना लेबल वाले भी हैं, समान मानों के साथ दिखाई देते हैं। स्लाइड 3 स्वचालित रूप से दिखाए गए स्वरूप को पुनर्स्थापित करता है।

![तीनों का मैनुअल श्रेणी लेबल अंतराल जिसमें सभी 24 कॉलम दिखाए गए हैं](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कि कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष ऊर्ध्वाधर होता है, इसलिए इन सेटिंग्स को [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) पर लागू करें। टिक‑मार्क अंतराल का उपयोग उन चार्ट्स में सीरीज़ अक्ष पर भी किया जा सकता है जिनमें सीरीज़ अक्ष मौजूद हो।

श्रेणी लेबल स्पेसिंग को मान अक्ष की संख्यात्मक स्केल सेट करने के लिए उपयोग न करें। मान अक्ष पर, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) मानों के अंतर को दर्शाता है: उदाहरण के लिए, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट मान अक्षों का उपयोग करते हैं, न कि पाठ श्रेणी अक्ष का। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयों और स्केलों का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियां पहले कार्यपत्रक (इंडेक्स `0`) में OLE Automation क्रमांक के रूप में संग्रहीत हैं। [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) को तिथि अक्ष पर सेट करें, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) को अक्षम करें, और [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) को `yyyy` असाइन करें ताकि श्रेणी लेबल सेल स्वरूप से स्वतंत्र रूप से चार-अंक वाले वर्ष दिखाएँ।

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

## **चार्ट एक्सिस शीर्षक के लिए घूर्णन कोण सेट करें**

ऊर्ध्वाधर अक्ष पर [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) को सक्रिय करें, शीर्षक पाठ प्रदान करें, और [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) को सेट करके शीर्षक को घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण कॉलम चार्ट को उसके मूल्य‑अक्ष शीर्षक को 90 डिग्री घुमाकर सहेजता है।

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

## **श्रेणी या मूल्य अक्ष पर एक्सिस स्थिति सेट करें**

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) का उपयोग करके यह नियंत्रित करें कि मूल्य अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करता है। यह प्रॉपर्टी केवल श्रेणी अक्षों पर लागू होती है। उदाहरण इस प्रॉपर्टी को कॉलम चार्ट की क्षैतिज श्रेणी अक्ष पर `True` सेट करता है और परिणाम सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट मूल्य अक्ष पर डिस्प्ले यूनिट सेट करें**

[value_axis] पर [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) को सेट करके लेबलों को डेटा बदले बिना स्केल करें। जब [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) को `MILLIONS` पर सेट किया जाता है, तो 60,000,000 को 60 के रूप में प्रदर्शित किया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसकी ऊर्ध्वाधर अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **लघुगणकीय मूल्य अक्ष को कॉन्फ़िगर करें**

जब सकारात्मक मान कई क्रम (orders of magnitude) में फैले हों तो लघुगणकीय मूल्य अक्ष उपयोगी होता है। उदाहरण के लिये, एक सेवा पाँच अवधियों में क्रमशः 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के पास बहुत करीब दिखते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि को आसान बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

[value_axis] पर [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) को `True` सेट करें और [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) से बेस चुनें। यह मौजूदा मानों के प्रदर्शित होने के तरीके को बदलता है; यह डेटा या लघुगणकीय ट्रेंडलाइन को नहीं बदलता। ट्रेंडलाइन डेटा में फ़िटेड रिलेशन को दर्शाती है और एक अलग फीचर है।

### **मूल्य अक्ष और बेस चुनें**

लाइन या कॉलम चार्ट के लिये मूल्य अक्ष [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) है। क्षैतिज बार चार्ट के लिये यह [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) है। स्कैटर और बबल चार्ट में दो मूल्य अक्ष होते हैं, इसलिए X मानों के लिये क्षैतिज अक्ष, Y मानों के लिये ऊर्ध्वाधर अक्ष, या दोनों का उपयोग करें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय बेस `10` है। PPTX चार्ट्स के लिये, `2` से `1000` तक (समावेशी) कोई भी बेस उपयोग किया जा सकता है; `2.5` जैसी भिन्नात्मक बेस भी समर्थित हैं। बेस `10` के साथ क्रमशः 10, 100, 1 000, 10 000 समान रूप से अंतरालित होते हैं।

### **रेखीय और लघुगणकीय स्केलिंग की तुलना करें**

निम्न स्व-निहित उदाहरण पहला स्लाइड पर पाँच अनुरोध गणनाओं के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड की प्रतिलिपि बनाकर दूसरे स्लाइड पर बेस‑10 लघुगणकीय मूल्य अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा रखते हैं।

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

    # पहले स्लाइड को रैखिक रखें और केवल कॉपी के मूल्य‑अक्ष स्केल को बदलें।
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**रेखीय स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी अनुरोध गणनाओं के समान अंतर को दर्शाती है। सबसे बड़ा मान चार्ट को हावी करता है, जिससे छोटे मान पहचानने में कठिनाई होती है।

![रेखीय मूल्य अक्ष पर पाँच अनुरोध गणनाओं के साथ लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि में अनुरोध संख्या पिछले की तुलना में दस गुना होती है, इसलिए बिंदु बेस‑10 स्केल पर एक सीधी बढ़ती रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणनाओं को दिखाते हैं।

![बेस‑10 लघुगणकीय मूल्य अक्ष पर वही पाँच अनुरोध गणनाएं](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शुद्ध सकारात्मक मानों को ही प्रदर्शित कर सकता है। इसे सक्षम करने से पहले डेटा जांचें। यदि शून्य या नकारात्मक मान मायने रखते हैं, तो रैखिक स्केल रखें या उन्हें अलग दिखाएँ। यदि विश्लेषण के लिये उन मानों को बाहर करना उपयुक्त है, तो हटाने का कारण स्पष्ट करें। उन्हें छोटे सकारात्मक संख्याओं से चुपचाप बदलना डेटा का अर्थ बदल देता है। लघुगणकीय अक्ष के लिये मैन्युअल रूप से सेट किया गया न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक अक्ष को दूसरे के साथ कहाँ काटता है (अक्ष प्रतिच्छेदन) यह मान कैसे सेट करूँ?**

[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) का उपयोग करके प्रतिच्छेदन व्यवहार चुनें। संख्यात्मक प्रतिच्छेदन मान निर्दिष्ट करने के लिये [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) सेट करें। इन सेटिंग्स से आप अक्ष प्रतिच्छेदन को उपयुक्त बेसलाइन पर स्थानांतरित कर सकते हैं।

**टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) का उपयोग करके [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) को `LOW`, `HIGH`, `NEXT_TO` या `NONE` पर सेट करें। टिक‑मार्क स्वयं को नियंत्रित करने के लिये [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) या [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) का उपयोग करें; ये लेबल स्थितियों से अलग हैं।