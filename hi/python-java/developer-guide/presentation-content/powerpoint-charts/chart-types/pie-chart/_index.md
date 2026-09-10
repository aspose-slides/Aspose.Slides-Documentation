---
title: Python के माध्यम से Java का उपयोग करके प्रस्तुतियों में पाई चार्ट को कस्टमाइज़ करें
linktitle: पाई चार्ट
type: docs
url: /hi/python-java/pie-chart/
keywords:
- पाई चार्ट
- चार्ट प्रबंधित करें
- चार्ट को कस्टमाइज़ करें
- चार्ट विकल्प
- चार्ट सेटिंग्स
- प्लॉट विकल्प
- स्लाइस रंग
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python के माध्यम से Java में पाई चार्ट बनाना और कस्टमाइज़ करना सीखें, जिन्हें PowerPoint में निर्यात किया जा सकता है, जिससे आपके डेटा कथा को सेकंडों में तेज़ किया जा सके।"
---
## **परिचय**

यह लेख Aspose.Slides में पाई चार्ट के साथ काम करने का तरीका समझाता है। यह पाई ऑफ पाई और बार ऑफ पाई चार्ट्स के लिए द्वितीयक प्लॉट विकल्पों को कॉन्फ़िगर करने और मानक पाई चार्ट के लिए स्वचालित स्लाइस रंग निर्धारण को सक्षम करने का तरीका दर्शाता है।

उदाहरण व्यावहारिक चार्ट अनुकूलन चरणों पर केंद्रित हैं, जैसे स्लाइड में चार्ट जोड़ना, श्रृंखला और लेबल सेटिंग्स को समायोजित करना, डिफ़ॉल्ट चार्ट डेटा को कस्टम श्रेणियों और मानों से बदलना, और अद्यतन प्रेजेंटेशन को सहेजना।

## **Pie of Pie और Bar of Pie चार्ट्स के लिए द्वितीयक प्लॉट विकल्प**

Aspose.Slides for Python via Java पाई चार्ट्स के लिए द्वितीयक प्लॉट विकल्प, जिसमें Pie of Pie और Bar of Pie प्रकार शामिल हैं, का समर्थन करता है। यह अनुभाग दिखाता है कि इन विकल्पों को Aspose.Slides का उपयोग करके कैसे निर्दिष्ट किया जाए। नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट बनाएं।
1. स्लाइड में एक चार्ट जोड़ें।
1. चार्ट के द्वितीयक प्लॉट विकल्प निर्दिष्ट करें।
1. प्रेजेंटेशन को डिस्क पर लिखें।

निम्नलिखित उदाहरण Pie of Pie चार्ट की विभिन्न गुणधर्मों को सेट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Presentation क्लास की एक इंस्टेंस बनाएं।
presentation = Presentation()
try:
    # स्लाइड में एक चार्ट जोड़ें।
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # विभिन्न गुण स्थापित करें।
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # प्रेजेंटेशन को डिस्क पर लिखें।
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्वचालित पाई चार्ट स्लाइस रंग सेट करें**

Aspose.Slides for Python via Java स्वचालित पाई चार्ट स्लाइस रंग सेट करने के लिए एक सरल API प्रदान करता है। निम्नलिखित उदाहरण दर्शाता है कि इन सेटिंग्स को कैसे लागू किया जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. पहली स्लाइड तक पहुंचें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. चार्ट शीर्षक सेट करें।
1. चार्ट डेटा वर्कशीट का इंडेक्स सेट करें।
1. चार्ट डेटा वर्कबुक प्राप्त करें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को हटाएँ।
1. नई श्रेणियां जोड़ें।
1. एक नई सीरीज़ जोड़ें।
1. नई सीरीज़ को मान दिखाने के लिए सेट करें।

बदलाव किया गया प्रेजेंटेशन एक PPTX फ़ाइल में लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Presentation क्लास की एक इंस्टेंस बनाएं।
presentation = Presentation()
try:
    # डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # चार्ट शीर्षक सेट करें।
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # चार्ट डेटा वर्कशीट का इंडेक्स सेट करें।
    default_worksheet_index = 0

    # चार्ट डेटा वर्कबुक प्राप्त करें।
    workbook = chart.getChartData().getChartDataWorkbook()

    # डिफ़ॉल्ट सीरीज़ और श्रेणियों को हटाएँ।
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # नई श्रेणियां जोड़ें।
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # एक नई सीरीज़ जोड़ें।
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # सीरीज़ डेटा भरें।
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # नई सीरीज़ को मान दिखाने के लिए सेट करें।
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या 'Pie of Pie' और 'Bar of Pie' वैरिएंट्स समर्थित हैं?**

हाँ, लाइब्रेरी [समर्थित](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/) एक द्वितीयक प्लॉट पाई चार्ट्स के लिए, जिसमें 'Pie of Pie' और 'Bar of Pie' प्रकार शामिल हैं।

**क्या मैं केवल चार्ट को एक छवि (उदाहरण के लिए, PNG) के रूप में निर्यात कर सकता हूँ?**

हाँ, आप पूरे प्रेजेंटेशन के बिना चार्ट को स्वयं एक छवि के रूप में निर्यात कर सकते हैं, जैसे PNG, इसके लिए आप [चार्ट को स्वयं एक छवि के रूप में निर्यात करें](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) कर सकते हैं।