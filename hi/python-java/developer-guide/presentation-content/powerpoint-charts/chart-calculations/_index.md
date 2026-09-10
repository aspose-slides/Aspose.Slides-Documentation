---
title: Python via Java में प्रस्तुतियों के लिए चार्ट गणनाओं का अनुकूलन
linktitle: चार्ट गणनाएँ
type: docs
weight: 50
url: /hi/python-java/chart-calculations/
keywords:
- चार्ट गणनाएँ
- चार्ट तत्व
- तत्व स्थिति
- वास्तविक स्थिति
- चाइल्ड तत्व
- पैरेंट तत्व
- चार्ट मान
- वास्तविक मान
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में PPT और PPTX के लिए चार्ट गणनाओं, डेटा अपडेट और सटीकता नियंत्रण को समझें, व्यावहारिक Python कोड उदाहरणों के साथ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुतीकरण में चार्ट की गणनाओं और लेआउट डेटा के साथ काम करने के लिए API प्रदान करता है। यह लेख दिखाता है कि चार्ट तत्वों के वास्तविक मान कैसे प्राप्त किए जाएँ, जिसमें चार्ट तत्वों की वास्तविक स्थिति और आकार तथा चार्ट अक्षों के वास्तविक मान शामिल हैं। यह भी समझाता है कि ये मान चार्ट लेआउट वैधता के बाद भरते हैं।

इसके अतिरिक्त, लेख यह प्रदर्शित करता है कि मातृ चार्ट तत्वों की वास्तविक स्थिति कैसे प्राप्त करें और शीर्षक, अक्ष, लीजेंड एवं ग्रिड रेखाओं जैसे चार्ट घटकों को कैसे छिपाएँ। ये उदाहरण आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतीकरण में चार्ट लेआउट जानकारी का निरीक्षण करने और चार्ट तत्वों की दृश्यमानता को नियंत्रित करने में मदद करते हैं।

## **चार्ट तत्वों के वास्तविक मान की गणना**
Aspose.Slides for Python via Java इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। [अक्ष](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/) वर्ग की विधियाँ चार्ट अक्षों के वास्तविक मान के बारे में जानकारी देती हैं ([getActualMaxValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/hi/python-java/aspose.slides/axis/#getActualMinorUnitScale))। इन गुणों को वास्तविक मानों से भरने के लिए पहले [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#validateChartLayout) विधि को कॉल करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **मातृ चार्ट तत्वों की वास्तविक स्थिति की गणना**
Aspose.Slides for Python via Java इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। [ChartPlotArea](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartplotarea/) वर्ग की विधियाँ चार्ट प्लॉट क्षेत्र की वास्तविक स्थिति और आकार के बारे में जानकारी देती हैं ([getActualX](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartplotarea/#getActualHeight))। इन गुणों को वास्तविक मानों से भरने के लिए पहले [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#validateChartLayout) विधि को कॉल करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **चार्ट तत्वों को छिपाएँ**
यह अनुभाग बताता है कि चार्ट से जानकारी कैसे छिपायी जा सकती है। Aspose.Slides for Python via Java का उपयोग करके आप **शीर्षक**, **ऊर्ध्वाधर अक्ष**, **क्षैतिज अक्ष**, और **ग्रिड रेखाएँ** को छिपा सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि इन गुणों का उपयोग कैसे किया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # चार्ट शीर्षक को छिपाएँ।
    chart.setTitle(False)

    # मान अक्ष को छिपाएँ।
    chart.getAxes().getVerticalAxis().setVisible(False)

    # श्रेणी अक्ष को छिपाएँ।
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # लेजेंड को छिपाएँ।
    chart.setLegend(False)

    # प्रमुख ग्रिड रेखाएँ छिपाएँ।
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # केवल पहला श्रृंखला रखें। अंत से हटाने से शेष इंडेक्स वैध रहते हैं।
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # श्रृंखला रेखा का रंग सेट करें।
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाह्य Excel कार्यपुस्तिकाएँ डेटा स्रोत के रूप में काम करती हैं, और इसका पुनःगणना पर क्या प्रभाव पड़ता है?**

हाँ। एक चार्ट बाहरी कार्यपुस्तिका को संदर्भित कर सकता है: जब आप बाहरी स्रोत से कनेक्ट या रिफ्रेश करते हैं, तो फ़ॉर्मूले और मान उस कार्यपुस्तिका से लिये जाते हैं, और चार्ट खुलने/संपादन के दौरान अपडेट दर्शाता है। API आपको [बाहरी कार्यपुस्तिका](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) पथ निर्दिष्ट करने और लिंक्ड डेटा का प्रबंधन करने की अनुमति देता है।

**क्या मैं प्रतिगमन को स्वयं लागू किए बिना ट्रेंडलाइन की गणना और प्रदर्शन कर सकता हूँ?**

हाँ। [Trendlines](/slides/hi/python-java/trend-line/) (रैखिक, घातीय और अन्य) Aspose.Slides द्वारा जोड़े और अपडेट किए जाते हैं; उनके पैरामीटर स्वचालित रूप से श्रृंखला डेटा से पुनःगणना किए जाते हैं, इसलिए आपको अपनी स्वयं की गणना लागू करने की आवश्यकता नहीं है।

**यदि प्रस्तुतीकरण में कई चार्ट बाहरी लिंक के साथ हैं, तो क्या मैं प्रत्येक चार्ट के लिए उपयोग की जाने वाली कार्यपुस्तिका को नियंत्रित कर सकता हूँ?**

हाँ। प्रत्येक चार्ट अपना स्वयं का [बाहरी कार्यपुस्तिका](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#setExternalWorkbook) इंगित कर सकता है, या आप प्रत्येक चार्ट के लिए स्वतंत्र रूप से एक बाहरी कार्यपुस्तिका बना/प्रतिस्थापित कर सकते हैं।