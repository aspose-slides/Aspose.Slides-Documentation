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
description: "Aspose.Slides for Python via .NET की खोज करें: PowerPoint और OpenDocument प्रारूपों में चार्ट वर्कबुक को सहजता से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुगम बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, चार्ट डेटा लेबल के रूप में वर्कबुक सेल्स का उपयोग करने, वर्कशीट संग्रहों तक पहुंचने, और चार्ट मूल्यों के लिए डेटा स्रोत प्रकार को निर्दिष्ट करने का प्रदर्शन करता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि बाहरी वर्कबुक कैसे बनाएं और असाइन करें, चार्ट से जुड़े बाहरी वर्कबुक का मार्ग कैसे प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को कैसे संपादित करें।

गुम डेटा का प्रतिनिधित्व करने वाली वर्कबुक कोशिकाओं के लिए, [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-net/chart-series/) देखें जिससे खाली कोशिका और शून्य के बीच का अंतर, तथा उपलब्ध प्रदर्शन मोडों की लाइन-चार्ट तुलना समझा जा सके।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करता है या नहीं, इसे नियंत्रित करने के लिए [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) का उपयोग करें। इसे `True` सेट करें ताकि केवल दृश्यमान कोशिकाओं को प्लॉट किया जाए, या `False` सेट करें ताकि दृश्यमान और छिपी दोनों कोशिकाएँ शामिल हों। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या प्रदर्शित नहीं करती।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड के पहले आकार के रूप में एक कॉलम चार्ट शामिल है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और कॉलम C छिपे हुए हैं, लेकिन उनकी कोशिकाएँ अभी भी मान रखती हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुंचने के लिए [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) का उपयोग करें और उनके छिपे होने की स्थिति का निरीक्षण करने के लिए [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) पढ़ें। यह गुण केवल-पूड़ा (read-only) है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड वर्कबुक को [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) के साथ बनाए रखें और इसे [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) के साथ पुनः लोड करें। सभी कोशिकाओं को शामिल करने पर, छिपी फ़रवरी श्रेणी सहित संपूर्ण रेंज को पुनर्स्थापित करने के लिए [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का भी उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

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

            # एंबेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # छिपी श्रेणियों सहित, संपूर्ण स्रोत रेंज को पुनर्स्थापित करें।
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

उदाहरण प्रस्तुति के दो संस्करण बचाता है: एक केवल दृश्यमान रिटेल मानों (10 और 20) के साथ, और दूसरा सभी छह मानों के साथ। नीचे की छवियाँ सहेजी गई प्रस्तुतियों को फिर से खोलने के बाद रेंडर की गई हैं; दोनों फ़ाइलें अपनी निर्धारित प्लॉटिंग सेटिंग को बरकरार रखती हैं। पंक्ति 3 और कॉलम C दोनों एम्बेडेड वर्कबुक में छिपे रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`True`) | सभी कोशिकाएँ (`False`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और थोक मान।](hidden_cells_False.png) |

एक मान रखने वाली छिपी कोशिका एक खाली कोशिका से अलग होती है। [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) नियंत्रित करता है कि गायब मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-net/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंजों की जाँच करें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन सी वर्कशीट कोशिकाओं का उपयोग करता है। [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) मेथड वर्तमान डेटा रेंज को वर्कशीट-योग्य फ़ॉर्मूला के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाएँ A1 से D5 तक, शामिल करती हैं। डॉलर चिह्न निरपेक्ष पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह मेथड वर्तमान रेंज को पढ़ता है बिना चार्ट या उसकी वर्कबुक को बदले। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता है, तो यह एक अपवर्जन फेंकेगा। अधिक जानकारी के लिए देखें [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकारों को चार्ट के लिए जाँचता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि रेंज प्राप्त नहीं की जा सकती, तो यह एक निदान संदेश प्रिंट करता है और अगले चार्ट पर आगे बढ़ता है।

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

Aspose.Slides for Python via .NET [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells के साथ संपादित चार्ट डेटा है) को पढ़ने और लिखने की अनुमति देते हैं। **Note** कि चार्ट डेटा को उसी प्रकार व्यवस्थित होना चाहिए या स्रोत के समान संरचना होना आवश्यक है।

यह उदाहरण एक प्रस्तुति का उपयोग करता है जिसमें पहला आकार उसके पहले स्लाइड पर एक चार्ट है। यह एम्बेडेड वर्कबुक को एक स्ट्रीम में पढ़ता है, मौजूदा श्रृंखलाएँ और श्रेणियाँ साफ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बरकरार रखता है। यह असंगति [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) को इंडेक्स-आउट-ऑफ-रेंज त्रुटि के साथ失敗 करवा सकती है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा श्रृंखलाओं और श्रेणियों को साफ करें। यह उदाहरण एक चार्ट का उपयोग करता है जो पहले स्लाइड पर पहला आकार है। टिप्पणी दर्शाती है कि वर्कबुक संपादन कहाँ होगा; चलने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # यहाँ वर्कबुक स्ट्रीम को संशोधित करें, उदाहरण के लिए Aspose.Cells का उपयोग करके।

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

संग्रहों को साफ करने से वर्कबुक को वापस लिखने से पहले पुराने डेटा संदर्भ हट जाते हैं। चार्ट का उपयोग करने से पहले अपडेटेड वर्कबुक के लिए आवश्यक श्रृंखलाएँ और श्रेणी मानचित्रण को पुनः बनाएँ।

## **वर्कबुक कोशिकाओं के लिए कस्टम नंबर फ़ॉर्मैट सेट करें**

एक चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक मान कैसे दिखते हैं, इसे नियंत्रित करने के लिए [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) का उपयोग करें। उदाहरण के लिए, एक रिपोर्ट को परिवर्तन दर को चार दशमलव स्थानों के साथ प्रतिशत में और एक गुणांक को पाँच दशमलव स्थानों के साथ प्रदर्शित करने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिए उपलब्ध रहें।

एक नंबर फ़ॉर्मेट प्रदर्शन को बदलता है, न कि संग्रहीत मान को। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` से बदलता नहीं है। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` के रूप में दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फ़ॉर्मेट एक खाली स्ट्रिंग (`""`) है, तो इसके बजाय [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) का उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और इसकी कोशिकाओं को [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के माध्यम से एक्सेस करता है। वर्कशीट 0 में, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़े वैल्यू लेबल को भी सक्षम करता है।

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

वर्कबुक कोशिका फ़ॉर्मेट चार्ट अक्ष या डेटा लेबल पर सीधे सेट किए गए फ़ॉर्मेट से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपने स्रोत कोशिका का मान प्रदर्शित करता है क्योंकि [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) सक्षम है, और स्रोत नंबर फ़ॉर्मेट का पालन करता है क्योंकि [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True` है। प्रस्तुति को सहेजने और पुनः खोलने के बाद, लेबल नीचे दिखाए अनुसार `12.5000%` और `0.12346` प्रदर्शित करते हैं। वर्टिकल एक्सिस अपना स्वयं का [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00` उपयोग करता है, जिसमें [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) `False` पर सेट है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिए, उसकी स्रोत-लिंक फ़्लैग को `False` सेट करें और उसका [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) असाइन करें। यह वर्कबुक कोशिका के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिए, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` के रूप में दिखाता है, जबकि B2 अभी भी `12.5000%` दिखाता है। सीधे लेबल फ़ॉर्मेटिंग के लिए देखें [Chart Data Labels](/slides/hi/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:
![कॉलम चार्ट जिसमें स्रोत-लिंक्ड लेबल 12.5000% और 0.12346 दिखा रहे हैं और एक स्वतंत्र रूप से फ़ॉर्मेट किया गया संख्यात्मक अक्ष।](custom-cell-formats.png)

## **वर्कबुक कोशिका को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं से पाठ का उपयोग चार्ट डेटा लेबल के रूप में कर सकते हैं।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है, जो मौजूदा प्रस्तुति की पहली स्लाइड पर है। यह वर्कशीट 0 में कोशिकाएँ A10:A12 का उपयोग पहली श्रृंखला के पहले तीन लेबल के लिए करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) प्रॉपर्टी चार्ट वर्कबुक में वर्कशीट्स तक पहुंच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल का उपयोग करता है; दूसरा वर्कशीट 0 में कोशिका C1 का उपयोग करता है। [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) एन्यूमरेशन प्रत्येक नाम के लिए स्रोत चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित एन्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) पर [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) एन्यूमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों की जांच करता है, गैर-चार्ट आकारों को छोड़ता है, और प्रत्येक चार्ट जिसके पास एम्बेडेड .xlsb वर्कबुक है, के लिए एक निदान संदेश प्रिंट करता है।

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

        # यहाँ समर्थित चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग करने का समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) और [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में एक्सपोर्ट करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक को एक्सपोर्ट करता है। यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करने से पहले आउटपुट स्ट्रीम को बंद करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) मेथड का उपयोग करके, आप किसी चार्ट को उसके डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पाथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

हालाँकि आप रिमोट स्थानों या संसाधनों में संग्रहीत वर्कबुक डेटा को संपादित नहीं कर सकते, फिर भी आप इन वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पाथ प्रदान किया जाता है, तो वह स्वतः पूर्ण पाथ में बदल जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों में मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) का `update_chart_data` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड किया जाए या नहीं।

`update_chart_data` `False` होने पर, केवल वर्कबुक पाथ अपडेट किया जाता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता, इसलिए वर्कबुक उपलब्ध नहीं भी हो सकती है।

`update_chart_data` `True` होने पर, चार्ट डेटा लक्ष्य वर्कबुक से अपडेट किया जाता है।

निम्न उदाहरण एक प्लेसहोल्डर URL को `update_chart_data` `False` के साथ असाइन करता है। यह पाई चार्ट का डिफ़ॉल्ट डेटा बरकारार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **एक चार्ट के बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करें**

एक चार्ट से जुड़ी वर्कबुक की पहचान करने के लिए, जाँचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पाथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति के पहले स्लाइड पर पहले आकार को जांचता है जिसमें लिंक्ड बाहरी वर्कबुक है। यदि यह एक चार्ट है जो बाहरी वर्कबुक से जुड़ा है, तो उदाहरण कंसोल में [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

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

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं की जा सकती, तो एक अपवर्जन फेंका जाता है।

यह उदाहरण एक चार्ट का उपयोग करता है जो पहले स्लाइड पर पहला आकार है और एक सुलभ बाहरी वर्कबुक से जुड़ा है। यह पहली श्रृंखला के पहले डेटा पॉइंट की सेल-आधारित मान को 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए यदि आपको मूल वर्कबुक को संरक्षित रखना है तो एक कॉपी का उपयोग करें।

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

यदि कोई चार्ट एक बाहरी वर्कबुक का उपयोग करता है जो उपलब्ध नहीं है या गायब है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। प्रस्तुति खोलने से पहले [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), उसके [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), और [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) को `True` सेट करके कॉन्फ़िगर करें।

निम्न Python उदाहरण एक चार्ट के लिए वर्कबुक डेटा पुनः प्राप्त करता है जो पहले स्लाइड पर पहला आकार है और एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है। यह पुनः प्राप्त डेटा को [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) और [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) के माध्यम से एक्सेस करता है:

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

यदि बाहरी वर्कबुक उपलब्ध नहीं है और पुनर्प्राप्ति निष्क्रिय है, तो Aspose.Slides एक अपवर्जन फेंकेगा। केवल तभी पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य बैकअप हो, क्योंकि कैश में प्रस्तुति के अंतिम अपडेट के बाद बाहरी वर्कबुक में किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा हुआ है?**  
हां। एक चार्ट के पास एक [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) और एक [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़ सकते हैं यह सुनिश्चित करने के लिए कि बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी वर्कबुक के सापेक्ष पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  
हां। यदि आप एक सापेक्ष पाथ निर्दिष्ट करते हैं, तो वह स्वतः एक पूर्ण पाथ में बदल जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पाथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**  
हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—इन्हें केवल स्रोत के रूप में उपयोग किया जा सकता है।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को अधिलेखित करता है?**  
प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) संग्रहीत करती है। सेल-आधारित चार्ट डेटा को संपादित करने से लिंक्ड लोकल XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक को अपरिवर्तित रखना हो तो वर्कबुक की कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड-संरक्षित है तो मुझे क्या करना चाहिए?**  
Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक आम तरीका यह है कि पहले से सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/python-net/) का उपयोग करके) और उस कॉपी से लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**  
हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में वह परिवर्तन परिलक्षित होगा।