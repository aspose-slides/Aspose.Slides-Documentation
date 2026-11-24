---
title: Python के साथ प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/python-net/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET को खोजें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आप अपनी प्रस्तुति डेटा को सुव्यवस्थित कर सकें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दर्शाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट कलेक्शन्स तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और सौंपा जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाए।

ग़ायब डेटा का प्रतिनिधित्व करने वाली वर्कबुक सेल्स के लिए, [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-net/chart-series/) देखें ताकि खाली सेल और शून्य के बीच अंतर और उपलब्ध प्रदर्शन मोड की रेखा-चार्ट तुलना समझ सकें।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी कार्यपत्र पंक्तियों और स्तंभों से डेटा प्लॉट किया जाए या नहीं, इसे नियंत्रित करने के लिए [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) का उपयोग करें। केवल दृश्य सेल्स को प्लॉट करने के लिए इसे `True` सेट करें, या दृश्य और छिपी दोनों सेल्स को शामिल करने के लिए `False` सेट करें। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह कार्यपत्र पंक्तियों या स्तंभों को छिपाती या दिखाती नहीं है।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड पर पहला आकार एक कॉलम चार्ट है। एम्बेडेड कार्यपत्र, `Sheet1`, में स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनके सेल्स में अभी भी मान हैं।

| कार्यपत्र पंक्ति | A: महीना | B: खुदरा | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

स्रोत सेल्स तक पहुंचने के लिए [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) का उपयोग करें और उनकी छिपी स्थिति का निरीक्षण करने के लिए [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) पढ़ें। यह गुण केवल-पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ़्रेश करें: एम्बेडेड वर्कबुक को [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) के साथ बनाए रखें और उसे [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) के साथ पुनः लोड करें। सभी सेल्स को शामिल करने के लिए, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने हेतु [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रिफ़्रेश करने के लिए अपर्याप्त है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # एम्बेडेड वर्कबुक से चार्ट डेटा को रिफ्रेश करें।
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

उदाहरण दो संस्करणों में प्रस्तुति को सहेजता है: एक में केवल दृश्यमान Retail मान (10 और 20), और दूसरा सभी छह मानों के साथ। नीचे दिखाए गए चित्र सहेजी गई प्रस्तुतियों को पुनः खोलने के बाद रेंडर किए गए हैं; दोनों फ़ाइलें अपनी सौंपित प्लॉटिंग सेटिंग को बनाए रखती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपे रहेंगे।

| केवल दृश्यमान सेल्स (`True`) | सभी सेल्स (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

किसी छिपे सेल में मान होना खाली सेल से अलग है। [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) नियंत्रित करता है कि ग़ायब मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-net/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट के डेटा रेंज को प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज की जांच करें ताकि यह पहचान सकें कि प्रत्येक चार्ट कौन सी कार्यपत्र कोशिकाओं का उपयोग करता है। [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) मेथड वर्तमान डेटा रेंज को एक कार्यपत्र-योग्य सूत्र के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` कार्यपत्र का नाम है, `!` उसे सेल रेंज से अलग करता है, और `$A$1:$D$5` सेल्स A1 से D5 (समावेशी) को दर्शाता है। डॉलर चिन्ह निरपेक्ष पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह मेथड चार्ट या उसके वर्कबुक को बदले बिना वर्तमान रेंज को पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता है, तो यह एक एक्सेप्शन उठाता है। अधिक जानकारी के लिए देखें [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकारों की जांच करता है ताकि चार्ट मिलें। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि रेंज प्राप्त नहीं की जा सकती, तो यह एक निदान संदेश प्रिंट करता है और अगले चार्ट पर जारी रहता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Python via .NET [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जो Aspose.Cells से संपादित चार्ट डेटा रखती है) को पढ़ने और लिखने की अनुमति देता है। **Note** कि चार्ट डेटा को उसी तरीके से व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण पहली स्लाइड पर पहले आकार के रूप में एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह एम्बेडेड वर्कबुक को एक स्ट्रीम में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। बदलाव मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को मान्य करें**

जब आप एक संशोधित वर्कबुक से एम्बेडेड वर्कबुक को बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी कलेक्शन्स को बनाए रखता है। यह असंगति [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ विफल करा सकती है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट है। टिप्पणी उस स्थान को दर्शाती है जहाँ वर्कबुक संपादन होगा; चालू उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # यहाँ कार्यबुक स्ट्रीम को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

कलेक्शन्स को साफ़ करने से वर्कबुक लिखे जाने से पहले पुरानी डेटा रेफरेंसेस हट जाती हैं। अपडेटेड वर्कबुक के लिए आवश्यक सीरीज़ और श्रेणी मैपिंग को पुनः बनाएं, फिर चार्ट को उपयोग करें।

## **श्रेणी लेबल्स को कैसे संग्रहीत करें चुनें**

जब श्रेणी कलेक्शन खाली हो, तब [ChartCategoryCollection.use_cells](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorycollection/use_cells/) सेट करें। लेबल्स जो कार्यपत्र कोशिकाओं का संदर्भ देते हैं या वर्ष द्वारा समूहित तिमाहियों जैसे पदानुक्रम बनाते हैं, उनके लिए इसे `True` सेट करें। केवल स्ट्रिंग्स के रूप में प्रदान किए गए एक स्तर के लेबल्स के लिए इसे `False` सेट करें। यह सेटिंग केवल श्रेणियों पर लागू होती है। दोनों उदाहरणों में संख्यात्मक सीरीज़ मानों के लिए कार्यपत्र कोशिकाओं का उपयोग किया गया है।

उदाहरण दो कॉलम चार्ट बनाता है और प्रत्येक के लिए स्टोरेज मोड और लेबल्स `Q1 Q2 Q3 Q4` प्रिंट करता है। सेल-समर्थित लेबल्स के लिए, [ChartCategory.as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/as_cell/) कार्यपत्र कोशिका लौटाता है, और [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) उसमें संग्रहीत लेबल लौटाता है। लिटरेट लेबल्स के लिए सीधे [ChartCategory.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/value/) से स्ट्रिंग पढ़ें।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    for use_cells, x in [(True, 20), (False, 360)]:
        chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, x, 20, 320, 250)
        data = chart.chart_data
        data.series.clear()
        data.categories.clear()
        data.categories.use_cells = use_cells

        workbook = data.chart_data_workbook
        series_name = workbook.get_cell(0, 0, 1, "Sales")
        series = data.series.add(series_name, chart.type)
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.get_cell(0, row, 0, label)
                data.categories.add(label_cell)
            else:
                data.categories.add(label)

            value_cell = workbook.get_cell(0, row, 1, row * 10)
            series.data_points.add_data_point_for_bar_series(value_cell)

        labels = [category.as_cell.value if use_cells else category.value for category in data.categories]
        print(f"use_cells = {data.categories.use_cells}:", *labels)

    presentation.save("category-labels.pptx", slides.export.SaveFormat.PPTX)
```

## **वर्कबुक कोशिकाओं के लिए कस्टम नंबर फ़ॉर्मेट सेट करें**

[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) का उपयोग करके आप नियंत्रित कर सकते हैं कि संख्यात्मक मान चार्ट के एम्बेडेड वर्कबुक में कैसे दिखाए जाएँ। उदाहरण के लिए, एक रिपोर्ट को परिवर्तन दर को चार दशमलव स्थानों के साथ प्रतिशत के रूप में और गुणांक को पाँच दशमलव स्थानों के साथ दिखाना पड़ सकता है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिए उपलब्ध रहें।

नंबर फ़ॉर्मेट केवल प्रदर्शन को बदलता है, संग्रहीत मान को नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बनाता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को राउंड किए। यदि कस्टम फ़ॉर्मेट एक खाली स्ट्रिंग (`""`) है, तो [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसके सेल्स को [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के माध्यम से एक्सेस करता है। कार्यपत्र 0 में, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों सेल्स चार्ट मान प्रदान करते हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़े मान लेबल्स को भी सक्षम करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

वर्कबुक सेल फ़ॉर्मेट चार्ट अक्षों या डेटा लेबल्स पर सीधे सेट किए गए फ़ॉर्मेट से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपना स्रोत सेल मान दिखाता है क्योंकि [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) सक्षम है, और स्रोत नंबर फ़ॉर्मेट का पालन करता है क्योंकि [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True` है। प्रस्तुति को सहेजने और पुनः खोलने के बाद, लेबल्स `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। वर्टिकल अक्ष अपना स्वयं का [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00` उपयोग करता है, और [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) `False` है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिए, उसके स्रोत-लिंक फ़्लैग को `False` सेट करें और उसका [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) असाइन करें। यह वर्कबुक सेल के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिए, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहले मान को `0.13` दिखाता है, जबकि B2 अभी भी `12.5000%` दिखाता है। सीधे लेबल फ़ॉर्मेटिंग के लिए देखें [Chart Data Labels](/slides/hi/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **एक वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स से पाठ का उपयोग चार्ट डेटा लेबल के रूप में कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक डिफ़ॉल्ट डेटा वाले बबल चार्ट को जोड़ता है। यह कार्यपत्र 0 में सेल्स A10:A12 को पहले सीरीज़ के पहले तीन लेबल्स के रूप में उपयोग करता है, सेल्स से लेबल्स को सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **वर्कशीट्स का प्रबंधन करें**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) प्रॉपर्टी चार्ट वर्कबुक में मौजूद कार्यपत्रों तक पहुंच प्रदान करती है। यह उदाहरण एक डिफ़ॉल्ट डेटा वाले पाई चार्ट को बनाता है और प्रत्येक कार्यपत्र का नाम कंसोल पर प्रिंट करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

सीरीज़ पॉइंट मानों को सीधे संख्यात्मक लिटरल के रूप में भी संग्रहीत किया जा सकता है। पूर्ण उदाहरण के लिए देखें [Set Series Values Using Numeric Literals](/slides/hi/python-net/chart-series/#set-series-values-using-numeric-literals) जो उन्हें सहेजता और पढ़ता है। पॉइंट मानों का स्रोत प्रकार चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग है; संख्यात्मक लिटरल का उपयोग करने से एम्बेडेड वर्कबुक स्वचालित रूप से हटती नहीं है।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नाम अलग-अलग डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा कार्यपत्र 0 में सेल C1 है। [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) एनेमरेशन प्रत्येक नाम के स्रोत को चुनता है। उदाहरण अपडेटेड सीरीज़ नामों के साथ प्रस्तुति को सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **असमर्थित एम्बेडेड वर्कबुक फॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फॉर्मेट का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) पर [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) एनेमरेशन के साथ उपयोग कर असमर्थित फॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों की जांच करता है, गैर-चार्ट आकारों को स्किप करता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिए एक निदान संदेश प्रिंट करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # समर्थित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग करने का समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) का उपयोग करके आप एम्बेडेड चार्ट वर्कबुक को फ़ाइल में एक्सपोर्ट कर सकते हैं और चार्ट को उस बाहरी वर्कबुक से लिंक कर सकते हैं।

यह उदाहरण एक डिफ़ॉल्ट डेटा वाला पाई चार्ट बनाता है और उसकी वर्कबुक को एक्सपोर्ट करता है। यह आउटपुट स्ट्रीम को बंद करता है, फिर बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, और लिंक्ड प्रस्तुति को सहेजता है।

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **एक बाहरी वर्कबुक सेट करें**

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करके आप एक चार्ट को बाहरी वर्कबुक को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी इस्तेमाल किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

जबकि आप रिमोट लोकेशन्स या रिसोर्सेज में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक का रिलेटिव पथ प्रदान किया जाता है, तो इसे स्वतः पूर्ण पथ में परिवर्तित कर दिया जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसमें `Sheet1` नामक कार्यपत्र में B1 में सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों में मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) का `update_chart_data` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `update_chart_data` `False` होता है, तो केवल वर्कबुक पथ अपडेट किया जाता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध हो सकती है।
* जब `update_chart_data` `True` होता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `update_chart_data` को `False` सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **एक चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक की पहचान करने के लिए, जांचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति में पहली स्लाइड पर पहले आकार की जांच करता है जिसमें एक लिंक्ड बाहरी वर्कबुक है। यदि यह एक चार्ट है जो बाहरी वर्कबुक से जुड़ा है, तो उदाहरण [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) को कंसोल पर प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक के सामग्री को बदलते हैं। जब बाहरी वर्कबुक लोड नहीं हो पाती, तो एक एक्सेप्शन फेंका जाता है।

यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट है और यह एक पहुंच योग्य बाहरी वर्कबुक से लिंक्ड है। यह पहले सीरीज़ के पहले डेटा पॉइंट का सेल-समर्थित मान `100` सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने हेतु एक कॉपी का उपयोग करें।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो ग़ायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः बना सकता है। [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) बनाएं, उसकी [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) को `True` सेट करें।

निम्न Python उदाहरण एक चार्ट के लिए वर्कबुक डेटा पुनः प्राप्त करता है जो पहली स्लाइड पर पहला आकार है और जो एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है। यह पुनः प्राप्त डेटा को [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) और [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के माध्यम से एक्सेस करता है:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # यहाँ पुनः प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    else:
        print("The first shape is not a chart.")
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनः प्राप्ति निष्क्रिय है, तो Aspose.Slides एक एक्सेप्शन उठाता है। पुनः प्राप्ति केवल तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बदलाव शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से लिंक्ड है?**

हां। एक चार्ट का [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) और एक [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पाथ में बदल जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पाथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना आवश्यक हो सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयर्स पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति को सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) संग्रहीत करती है। सेल-समर्थित चार्ट डेटा को संपादित करने से लिंक्ड लोकल XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड-प्रोटेक्टेड हो तो मैं क्या करूं?**

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। एक सामान्य उपाय है पहले सुरक्षा हटाना या डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/python-net/) का उपयोग करके) और उस कॉपी से लिंक करना।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से प्रत्येक चार्ट में अगली बार डेटा लोड होने पर परिवर्तन प्रतिबिंबित होंगे।