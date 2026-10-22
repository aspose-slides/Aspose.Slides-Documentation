---
title: Python के साथ प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/python-net/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक कोशिका
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
description: "Aspose.Slides for Python via .NET की खोज करें: PowerPoint और OpenDocument फॉर्मेट में आसानी से चार्ट वर्कबुक प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीकों को बताता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक की कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने पर भी चर्चा करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पाथ प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित करें।

गुम डेटा का प्रतिनिधित्व करने वाली वर्कबुक कोशिकाओं के लिए, अंतर देखने के लिये खाली कोशिका बनाम शून्य, तथा उपलब्ध डिस्प्ले मोड की लाइन-चार्ट तुलना के लिये देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-net/chart-series/)।

## **छिपी हुई पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करता है या नहीं, इसे नियंत्रित करने के लिये [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) का उपयोग करें। केवल दृश्यमान कोशिकाओं को प्लॉट करने के लिये इसे `True` सेट करें, या दोनों दृश्यमान और छिपी हुई कोशिकाओं को शामिल करने के लिये `False` सेट करें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छुपाती या प्रदर्शित नहीं करती।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहले स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज, `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: महीना | B: रिटेल | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी हुई पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिये [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) का उपयोग करें और उनकी छिपी हुई स्थिति का निरीक्षण करने के लिये [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) पढ़ें। यह गुण केवल‑पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी हुई पंक्ति की कोशिका है, और C2 छिपे हुए स्तंभ की कोशिका है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिये, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ़्रेश करें: एम्बेडेड वर्कबुक को [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) से बनाए रखें और उसे [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) से पुनः लोड करें। सभी कोशिकाओं को शामिल करने पर, छिपी हुई फ़रवरी श्रेणी को पुनर्स्थापित करने के लिये [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) भी उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश किए हुए चार्ट डेटा और श्रेणी लेबल को रिफ़्रेश करने के लिये पर्याप्त नहीं है।

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

            # एम्बेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # छिपी हुई श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

उदाहरण दो संस्करणों में प्रस्तुति को सहेजता है: एक केवल दृश्यमान रिटेल मान (10 और 20) के साथ, और दूसरा सभी छह मानों के साथ। नीचे की छवियां सहेजी हुई प्रस्तुतियों को पुनः खोलने के बाद रेंडर की गई हैं; दोनों फ़ाइलें अपने नियत प्लॉटिंग सेटिंग को बनाए रखती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपी हुई बनी रहती हैं।

| केवल दृश्यमान कोशिकाएँ (`True`) | सभी कोशिकाएँ (`False`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और थोक मान।](hidden_cells_False.png) |

एक मान वाला छिपा हुआ सेल खाली सेल से भिन्न होता है। [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) नियंत्रित करता है कि गुम मान कैसे प्रदर्शित हों; यह छिपे हुए स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिये देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-net/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज पुनः प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज की जाँच करें ताकि यह पता चल सके कि प्रत्येक चार्ट कौन सी वर्कशीट कोशिकाओं का उपयोग करता है। [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) मेथड वर्तमान डेटा रेंज को वर्कशीट‑क्वालिफाइड फ़ॉर्मूला के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाओं A1 से D5 (समेत) को दर्शाता है। डॉलर संकेत पूर्ण (absolute) पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह मेथड वर्तमान रेंज को बिना चार्ट या उसकी वर्कबुक को बदले पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक नहीं उपयोग करता, तो यह अपवाद फेंकेगा। अधिक जानकारी के लिये देखें [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकृतियों की जाँच करता है ताकि चार्ट मिलें। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि रेंज प्राप्त नहीं हो पाती, तो यह एक निदान संदेश प्रिंट करता है और अगले चार्ट की ओर बढ़ जाता है।

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

Aspose.Slides for Python via .NET [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) मेथड प्रदान करता है जिससे आप चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells से संपादित डेटा होता है) को पढ़ और लिख सकते हैं। **Note** कि चार्ट डेटा को समान संरचना में व्यवस्थित होना चाहिए या उसका स्रोत के समान होना चाहिए।

यह उदाहरण पहले स्लाइड की पहली आकृति पर एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह एम्बेडेड वर्कबुक को स्ट्रीम में पढ़ता है, मौजूदा श्रृंखलाएँ और श्रेणियाँ साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट का वैलिडेशन करें**

जब आप संशोधित वर्कबुक के साथ एम्बेडेड वर्कबुक को बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रह को बरकरार रखता है। यह असंगति [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ विफल कर सकती है। अद्यतन वर्कबुक को चार्ट में लिखने से पहले मौजूदा श्रृंखलाएँ और श्रेणियाँ साफ़ करें। यह उदाहरण पहले स्लाइड की पहली आकृति पर स्थित चार्ट का उपयोग करता है। टिप्पणी उन स्थानों को दर्शाती है जहाँ वर्कबुक संपादन होगा; निष्पादन योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को वैध करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # यहाँ कार्यपुस्तिका स्ट्रीम को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

संग्रहों को साफ़ करने से लिखे जाने से पहले पुराने डेटा संदर्भ हट जाते हैं। अद्यतन वर्कबुक के लिये आवश्यक श्रृंखला और श्रेणी मैपिंग को पुनः बनाएं।

## **वर्कबुक कोशिकाओं के लिये कस्टम नंबर फ़ॉर्मेट सेट करें**

[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) का उपयोग करके आप नियंत्रित कर सकते हैं कि चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक मान कैसे प्रदर्शित हों। उदाहरण के लिये, एक रिपोर्ट को परिवर्तन दर को प्रतिशत के रूप में चार दशमलव स्थान के साथ तथा गुणांक को पाँच दशमलव स्थान के साथ दिखाने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणना और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

एक नंबर फ़ॉर्मेट केवल डिस्प्ले को बदलता है, संग्रहीत मान नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बनाता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को राउंड किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसकी कोशिकाओं तक [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) से पहुँचता है। वर्कशीट 0 में, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फ़ॉर्मेट्स से जुड़े मान लेबल भी सक्षम करता है।

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

वर्कबुक कोशिका फ़ॉर्मेट्स चार्ट धुरी या डेटा लेबल पर सीधे सेट किए गए फ़ॉर्मेट्स से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपना स्रोत कोशिका मान दिखाता है क्योंकि [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) सक्षम है, और स्रोत नंबर फ़ॉर्मेट को फ़ॉलो करता है क्योंकि [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True` है। प्रस्तुति को सहेज कर पुनः खोलने पर लेबल `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दर्शाया गया है। लंबवत धुरी अपना स्वयं का [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00` उपयोग करती है, जबकि [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) `False` है।

डेटा लेबल को स्वतंत्र रूप से फॉर्मेट करने के लिये, उसका स्रोत‑लिंक फ़्लैग `False` सेट करें और उसका [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) निर्दिष्ट करें। यह वर्कबुक सेल के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` दिखाता है, जबकि B2 अभी भी `12.5000%` दिखाता है। सीधे लेबल फ़ॉर्मेटिंग के लिये देखें [Chart Data Labels](/slides/hi/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

![स्रोत‑लिंक्ड लेबल के साथ कॉलम चार्ट जो 12.5000% और 0.12346 दिखा रहा है तथा स्वतंत्र रूप से फॉर्मेट किया गया संख्यात्मक अक्ष।](custom-cell-formats.png)

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं के पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक बबल चार्ट जोड़ता है जिसमें डिफ़ॉल्ट डेटा है। यह वर्कशीट 0 पर कोशिकाएँ A10:A12 का उपयोग पहले श्रृंखला के पहले तीन लेबल के लिये करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **वर्कशीट्स को प्रबंधित करें**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) प्रॉपर्टी चार्ट वर्कबुक में मौजूद वर्कशीट्स तक पहुँच प्रदान करती है। यह उदाहरण एक पाई चार्ट डिफ़ॉल्ट डेटा के साथ बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

श्रृंखला बिंदु मानों को सीधे संख्यात्मक लिटरल्स के रूप में भी संग्रहीत किया जा सकता है। पूर्ण उदाहरण के लिये देखें [Set Series Values Using Numeric Literals](/slides/hi/python-net/chart-series/#set-series-values-using-numeric-literals) जो उन्हें सहेजता और पढ़ता है। बिंदु मानों का स्रोत प्रकार चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग है; संख्यात्मक लिटरल्स का उपयोग स्वयं में एम्बेडेड वर्कबुक को हटाता नहीं है।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नामों को विभिन्न डेटा स्रोतों से सेट करता है। पहला नाम स्ट्रिंग लिटरल से आता है; दूसरा वर्कशीट 0 के सेल C1 से। [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) एनेमरेशन प्रत्येक नाम के लिये स्रोत चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट्स का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता जिसे कुछ चार्ट में एम्बेड किया जा सकता है। आप [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) पर [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) एनेमरेशन के साथ उपयोग कर असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकृतियों की जाँच करता है, गैर‑चार्ट आकृतियों को छोड़ता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिये निदान संदेश प्रिंट करता है।

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

        # समर्थन प्राप्त चार्ट वर्कबुक डेटा यहाँ पढ़ें या संशोधित करें।
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिये बाहरी वर्कबुक को डेटा स्रोत के रूप में उपयोग करने का समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएँ**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक को निर्यात करता है। आउटपुट स्ट्रीम को बंद करने के बाद बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करके आप किसी चार्ट को बाहरी वर्कबुक को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पाथ को अप‑डेट करने के लिये भी उपयोग किया जा सकता है (यदि वर्कबुक को स्थानांतरित कर दिया गया हो)।

रिमोट लोकेशन या संसाधन में संग्रहीत वर्कबुक के डेटा को आप सीधे संपादित नहीं कर सकते, फिर भी उन्हें बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। यदि बाहरी वर्कबुक का रिलेटिव पाथ प्रदान किया जाता है, तो इसे स्वचालित रूप से पूर्ण पाथ में परिवर्तित कर दिया जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसमें `Sheet1` नाम की वर्कशीट में B1 में एक श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों के साथ मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

* जब `update_chart_data` `False` हो, केवल वर्कबुक पाथ अपडेट किया जाता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध भी हो सकता है।
* जब `update_chart_data` `True` हो, तो लक्ष्य वर्कबुक से चार्ट डेटा अपडेट किया जाता है।

निम्न उदाहरण `update_chart_data` को `False` रखकर एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **चार्ट की बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिये, जाँचें कि चार्ट बाहरी डेटा स्रोत का उपयोग करता है या नहीं और उसकी वर्कबुक पाथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति की पहली स्लाइड पर पहले आकृति की जाँच करता है जिसमें लिंक्ड बाहरी वर्कबुक है। यदि वह एक चार्ट है जो बाहरी वर्कबुक से लिंक्ड है, तो यह [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) को कंसोल पर प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

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

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड की पहली आकृति पर स्थित एक चार्ट का उपयोग करता है जो उपलब्ध बाहरी वर्कबुक से लिंक्ड है। यह पहली श्रृंखला के पहले डेटा बिंदु का सेल‑बैक्ड मान 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिये एक कॉपी का प्रयोग करें।

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

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या लुप्त है, तो Aspose.Slides प्रस्तुति में कैश किए हुए डेटा से चार्ट वर्कबुक को पुनः बन सकता है। [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) बनाएं, उसकी [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) कॉन्फ़िगर करें, और [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) को `True` सेट करें, फिर प्रस्तुति खोलें।

निम्न Python उदाहरण पहले स्लाइड की पहली आकृति पर स्थित चार्ट के लिये वर्कबुक डेटा को पुनः प्राप्त करता है जो उपलब्ध नहीं है। यह पुनः प्राप्त डेटा को [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) और [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के माध्यम से एक्सेस करता है:

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

        # यहाँ पुनर्प्राप्त वर्कबुक डेटा पढ़ें या संशोधित करें।
    else:
        print("The first shape is not a chart.")
```

यदि बाहरी वर्कबुक उपलब्ध नहीं है और रिकवरी अक्षम है, तो Aspose.Slides अपवाद फेंकेगा। केवल तब रिकवरी सक्षम करें जब कैश्ड चार्ट डेटा को fallback के रूप में उपयोग करना स्वीकार्य हो, क्योंकि कैश में वह बदलाव नहीं हो सकता जो बाहरी वर्कबुक में अंतिम प्रस्तुति अपडेट के बाद किए गए हों।

## **FAQ**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से लिंक्ड है?**

हाँ। एक चार्ट का [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) और एक [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़ सकते हैं जिससे पुष्टि हो सके कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पाथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पाथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालाँकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति में [external file के लिंक](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) संग्रहीत होता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल को अपरिवर्तित रखना है, तो वर्कबुक की एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड है तो मैं क्या करूँ?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य समाधान है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिये [Aspose.Cells](https://reference.aspose.com/cells/python-net/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगले डेटा लोड होने पर सभी चार्ट प्रभावित होंगे।