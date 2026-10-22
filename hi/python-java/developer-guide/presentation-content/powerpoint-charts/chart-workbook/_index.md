---
title: Python via Java का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/python-java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपकी प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने का तरीका समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने के बारे में भी बताता है। उदाहरण प्रदर्शित करते हैं कि बाहरी वर्कबुक कैसे बनाएँ और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा कैसे संपादित करें।

वह कोशिकाओं के लिए जो डेटा नहीं है, उसके लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-java/chart-series/) ताकि खाली कोशिका और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शन मोड के एक रेखा-चार्ट तुलना को समझा जा सके।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट किया जाए या नहीं, इसे नियंत्रित करने के लिए [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) का उपयोग करें। केवल दृश्यमान कोशिकाओं को प्लॉट करने के लिए इसे `True` सेट करें, या दृश्यमान और छिपी दोनों कोशिकाओं को शामिल करने के लिए `False` सेट करें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या दिखाती नहीं है।

[उदाहरण प्रस्तुतिकरण](hidden-source-data.pptx) में पहली स्लाइड के पहले आकार के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट `Sheet1` में निम्न स्रोत रेंज, `A1:C4` मौजूद है। पंक्ति 3 और स्तंभ C छिपी हुई हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: होलसेल (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फरवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिए [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) का उपयोग करें और उनकी छिपी स्थिति को जांचने के लिए [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) पढ़ें। यह विधि छिपी स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) से प्राप्त करें और [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) से पुनः लोड करें। सभी कोशिकाओं को शामिल करने के लिए, छिपी फ़रवरी श्रेणी को भी पुनर्स्थापित करने हेतु [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # एम्बेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

उदाहरण प्रस्तुति के दो संस्करण सहेजता है: एक में केवल दृश्यमान रिटेल मान (10 और 20) हैं, और दूसरा में सभी छह मान हैं। नीचे की छवियों में दो प्लॉटिंग मोड दिखाए गए हैं। पंक्ति 3 और स्तम्भ C दोनों एम्बेडेड वर्कबुक में छिपे रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`True`) | सभी कोशिकाएँ (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान सहित छिपी कोशिका खाली कोशिका से अलग होती है। [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) नियंत्रित करता है कि अनुपलब्ध मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/python-java/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट के डेटा रेंज को पुनः प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंजों की जांच करें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन-कौन सी वर्कशीट कोशिकाओं का उपयोग करता है। [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) विधि वर्तमान डेटा रेंज को एक वर्कशीट-योग्य फ़ॉर्मूला के रूप में लौटाती है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाएँ A1 से D5 तक, दोनों सहित, को दर्शाता है। डॉलर चिह्न पूर्ण पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह विधि चार्ट या उसके वर्कबुक को बदले बिना वर्तमान रेंज को पढ़ती है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह `InvalidOperationException` फेंकता है। अधिक जानकारी के लिए देखें [ChartData API रेफ़रेंस](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकारों की जाँच करता है कि क्या उनमें चार्ट हैं। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर जारी रहता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Python via Java, [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) विधियों को प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells के साथ संपादित डेटा होता है) को पढ़ने और लिखने की अनुमति देती हैं। **ध्यान दें** कि चार्ट डेटा को उसी प्रकार संगठित होना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण पहली स्लाइड के पहले आकार के रूप में एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह एम्बेडेड वर्कबुक को बाइट ऐरे में पढ़ता है, मौजूदा श्रृंखलाएँ और श्रेणियाँ साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **वर्कबुक संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप एक संशोधित वर्कबुक से एम्बेडेड वर्कबुक को प्रतिस्थापित करते हैं, तो चार्ट अपनी मूल श्रृंखलाएँ और श्रेणी संग्रह बनाए रखता है। यह असंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ विफल कर सकती है। अद्यतन वर्कबुक को वापस लिखने से पहले मौजूदा श्रृंखलाएँ और श्रेणियाँ साफ़ करें। यह उदाहरण पहली स्लाइड के पहले आकार के रूप में एक चार्ट का उपयोग करता है। टिप्पणी वह स्थान दर्शाती है जहाँ वर्कबुक संपादन होगा; चलने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को वैध करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # यहाँ वर्कबुक बाइट्स संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

संग्रहों को साफ़ करने से वर्कबुक को वापस लिखने से पहले पुराने डेटा रेफ़रेंस हट जाते हैं। अद्यतन वर्कबुक के लिए आवश्यक कोई भी श्रृंखला और श्रेणी मैपिंग को फिर से बनाएं, फिर चार्ट का उपयोग करें।

## **वर्कबुक कोशिकाओं के लिए कस्टम नंबर फ़ॉर्मेट सेट करें**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) का उपयोग करके आप नियंत्रित कर सकते हैं कि संख्यात्मक मान चार्ट की एम्बेडेड वर्कबुक में कैसे प्रदर्शित हों। उदाहरण के लिए, एक रिपोर्ट को परिवर्तन दर को प्रतिशत के रूप में चार दशमलव स्थानों के साथ और गुणांक को पाँच दशमलव स्थानों के साथ दिखाना पड़ सकता है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिए उपलब्ध रहें।

एक नंबर फ़ॉर्मेट केवल प्रदर्शित करता है, संग्रहीत मान को नहीं बदलता। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` में नहीं बदलता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` के रूप में दिखाता है बिना संग्रहीत मान को राउंड किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) द्वारा लौटाया गया फ़ॉर्मेट उपयोग किया जाता है।

नीचे का उदाहरण एक कॉलम चार्ट बनाता है और उसकी कोशिकाओं तक पहुँचता है [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के द्वारा। वर्कशीट 0 पर, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़ी मान लेबल भी सक्षम करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

वर्कबुक कोशिका फ़ॉर्मेट्स चार्ट अक्ष या डेटा लेबल पर सीधे सेट किए गए फ़ॉर्मेट्स से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपने स्रोत कोशिका के मान को दिखाता है क्योंकि [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) `True` पर सेट है, और स्रोत नंबर फ़ॉर्मेट का अनुसरण करता है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) भी `True` है। प्रस्तुति सहेजने और पुनः खोलने के बाद, लेबल `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। लंबवत अक्ष अपना स्वयं का नंबर फ़ॉर्मेट उपयोग करता है, जिसे [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) द्वारा `0.00` सेट किया गया है, और [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) `False` पर है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिए, उसके स्रोत‑लिंक फ़्लैग को `False` सेट करें और [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) से फ़ॉर्मेट असाइन करें। यह वर्कबुक कोशिका के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिए, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दिखाएगा। सीधे लेबल फ़ॉर्मेटिंग के लिये देखें [Chart Data Labels](/slides/hi/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **वर्कबुक कोशिका को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं के पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक बबल चार्ट डिफ़ॉल्ट डेटा के साथ जोड़ता है। यह वर्कशीट 0 की कोशिकाएँ A10:A12 का उपयोग पहले श्रृंखला के पहले तीन लेबल के लिए करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **वर्कशीट प्रबंधित करें**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) विधि चार्ट वर्कबुक में मौजूद वर्कशीटों तक पहुँच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

श्रृंखला बिंदु मानों को सीधे संख्यात्मक लिटरल के रूप में भी संग्रहीत किया जा सकता है। एक पूर्ण उदाहरण के लिये देखें [Set Series Values Using Numeric Literals](/slides/hi/python-java/chart-series/#set-series-values-using-numeric-literals) जो उन्हें सहेजता और पढ़ता है। बिंदु मानों का स्रोत प्रकार चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग होता है; संख्यात्मक लिटरल का उपयोग स्वयं एम्बेडेड वर्कबुक को नहीं हटाता।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नामों को विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल से लिया गया है; दूसरा नाम वर्कशीट 0 की कोशिका C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) enumeration प्रत्येक नाम के स्रोत का चयन करता है। उदाहरण प्रस्तुति को अपडेटेड श्रृंखला नामों के साथ सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides उन चार्ट्स में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) विधि को [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) enumeration के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों की जाँच करता है, गैर‑चार्ट आकारों को छोड़ता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिये एक डायग्नॉस्टिक संदेश प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # यहाँ समर्थित चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।

finally:
    presentation.dispose()
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक बनाएँ**

[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) और [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) का उपयोग करके आप एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात कर सकते हैं और चार्ट को उस बाहरी वर्कबुक से लिंक कर सकते हैं।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक निर्यात करता है। फ़ाइल लिखना पूरा होने के बाद बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, फिर लिंक्ड प्रस्तुति सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **बाहरी वर्कबुक असाइन करें**

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) विधि का उपयोग करके आप किसी चार्ट को उसका डेटा स्रोत के रूप में बाहरी वर्कबुक असाइन कर सकते हैं। यह विधि बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग की जा सकती है (यदि वह स्थानांतरित किया गया हो)।

भले ही आप रिमोट स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को सीधे संपादित न कर सकें, आप फिर भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिये सापेक्ष पथ प्रदान किया जाता है, तो उसे स्वतः पूर्ण पथ में परिवर्तित कर दिया जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `False` हो, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक उपलब्ध नहीं भी हो सकती।
* जब `updateChartData` `True` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `False` के साथ एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक की पहचान करने के लिए, जांचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति में पहले स्लाइड के पहले आकार को जांचता है, जिसमें लिंक्ड बाहरी वर्कबुक है। यदि वह एक चार्ट है जो बाहरी वर्कबुक से जुड़ा है, तो उदाहरण [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) को कंसोल पर प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड के पहले आकार के रूप में एक चार्ट का उपयोग करता है, जो एक सुलभ बाहरी वर्कबुक से जुड़ा है। यह पहले श्रृंखला के पहले डेटा बिंदु का सेल‑बैक्ड मान 100 सेट करता है और अपडेटेड प्रस्तुति सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने हेतु एक कॉपी का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) को कॉल करें, और [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को `True` सेट करें, फिर प्रस्तुति खोलें।

निम्न Python उदाहरण एक चार्ट के लिए वर्कबुक डेटा पुनः प्राप्त करता है जो पहली स्लाइड के पहले आकार में है और एक अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनः प्राप्त डेटा को [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # यहाँ पुनः प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

यदि बाहरी वर्कबुक अनुपलब्ध है और रिकवरी निष्क्रिय है, तो Aspose.Slides एक अपवाद फेंकता है। केवल तब रिकवरी सक्षम करें जब कैश्ड चार्ट डेटा को फॉलबैक के रूप में उपयोग करना स्वीकार्य हो, क्योंकि कैश में बाहरी वर्कबुक में अंतिम अपडेट के बाद किए गए परिवर्तन शामिल न भी हो सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट का [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) और [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालाँकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) तैयार करें और उस कॉपी से लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से प्रत्येक चार्ट में अगली बार डेटा लोड होने पर परिवर्तन प्रतिबिंबित होते हैं।