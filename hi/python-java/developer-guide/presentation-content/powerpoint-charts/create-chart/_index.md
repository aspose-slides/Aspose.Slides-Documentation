---
title: PowerPoint प्रस्तुति चार्ट्स को Python में बनाएं या अपडेट करें
linktitle: चार्ट बनाएं या अपडेट करें
type: docs
weight: 10
url: /hi/python-java/create-chart/
keywords:
- चार्ट जोड़ें
- चार्ट बनाएं
- चार्ट संपादित करें
- चार्ट बदलें
- चार्ट अपडेट करें
- स्कैटर चार्ट
- पाई चार्ट
- लाइन चार्ट
- ट्री मैप चार्ट
- स्टॉक चार्ट
- बॉक्स एंड व्हिस्कर चार्ट
- फ़नल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टी‑कैटेगरी चार्ट
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। Python में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके चार्ट बनाने और अनुकूलित करने के लिए एक व्यापक गाइड प्रदान करता है। आप सीखेंगे कि प्रोग्रामेटिक रूप से स्लाइड में चार्ट कैसे जोड़ें, डेटा के साथ उसे भरें, और आपके विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार विभिन्न फ़ॉर्मेटिंग विकल्प कैसे लागू करें। पूरे लेख में विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को प्रारंभ करने से लेकर सीरीज़, अक्ष, और लेजेंड को कॉन्फ़िगर करने तक। इस गाइड का पालन करके आप अपने अनुप्रयोगों में डायनेमिक चार्ट जनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवन प्रस्तुतियों को बनाना सरल हो जाएगा।

## **चार्ट बनाएं**

चार्ट लोगों को डेटा को जल्दी से विज़ुअलाइज़ करने और ऐसे अंतर्दृष्टि प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं होते।

**चार्ट क्यों बनायें?**

चार्ट का उपयोग करके आप:

* एक ही स्लाइड में बड़ी मात्रा में डेटा को संक्षिप्त या सारांशित कर सकते हैं
* डेटा में पैटर्न और रुझान उजागर कर सकते हैं
* समय के साथ या किसी विशिष्ट माप इकाई के संदर्भ में डेटा की दिशा और गति का अनुमान लगा सकते हैं
* विसंगतियों, त्रुटियों, निरर्थक डेटा आदि को पहचान सकते हैं
* जटिल डेटा को सुगमता से संप्रेषित या प्रस्तुत कर सकते हैं

PowerPoint में आप *Insert* कार्य का उपयोग करके कई प्रकार के चार्ट टेम्प्लेट्स से चार्ट बना सकते हैं। Aspose.Slides का उपयोग करके आप सामान्य चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" title="Note" %}}

चार्ट बनाने के लिए, [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) क्लास का उपयोग करें। इस क्लास के फ़ील्ड विभिन्न चार्ट प्रकारों से मेल खाते हैं।

{{% /alert %}}

### **क्लस्टर्ड कॉलम चार्ट बनाएं**

यह अनुभाग Aspose.Slides का उपयोग करके क्लस्टर्ड कॉलम चार्ट बनाने की विधि समझाता है। आप प्रस्तुति को प्रारंभ करना, चार्ट जोड़ना, तथा शीर्षक, डेटा, सीरीज़, श्रेणियाँ, और स्टाइलिंग जैसे तत्वों को अनुकूलित करना सीखेंगे। नीचे दिए गए चरणों का पालन करके देखें कि एक मानक क्लस्टर्ड कॉलम चार्ट कैसे उत्पन्न होता है:

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
1. कुछ डेटा के साथ एक चार्ट जोड़ें और `ChartType.ClusteredColumn` प्रकार निर्दिष्ट करें।
1. चार्ट में एक शीर्षक जोड़ें।
1. चार्ट के डेटा वर्कशीट तक पहुंचें।
1. सभी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ करें।
1. नई सीरीज़ और श्रेणियाँ जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. चार्ट सीरीज़ पर फ़िल रंग लागू करें।
1. चार्ट सीरीज़ के लिए लेबल जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड क्लस्टर्ड कॉलम चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# एक प्रस्तुति क्लास का उदाहरण बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation()
try:
    # पहले स्लाइड तक पहुँचता है
    slide = presentation.getSlides().get_Item(0)

    # डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # चार्ट शीर्षक सेट करता है
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # चार्ट डेटा शीट के लिए इंडेक्स सेट करता है
    default_worksheet_index = 0

    # चार्ट डेटा वर्कशीट प्राप्त करता है
    workbook = chart.getChartData().getChartDataWorkbook()

    # डिफ़ॉल्ट जनरेटेड सीरीज़ और श्रेणियों को हटाता है
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # नई सीरीज़ जोड़ता है
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # नई श्रेणियाँ जोड़ता है
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # पहली चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(0)

    # अब सीरीज़ डेटा को भरता है
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # सीरीज़ के लिए भरने का रंग सेट करता है
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1)

    # सीरीज़ डेटा को भरता है
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # सीरीज़ के लिए भरने का रंग सेट करता है
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #नई सीरीज़ के लिए प्रत्येक श्रेणी के लिए कस्टम लेबल बनाएं
    # पहले लेबल को श्रेणी नाम दिखाने के लिए सेट करता है
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # तीसरे लेबल के लिए मान दिखाता है
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # चार्ट के साथ प्रस्तुति सहेजता है
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **स्कैटर चार्ट बनाएं**
स्कैटर चार्ट (जो स्कैटर प्लॉट या x‑y ग्राफ़ के रूप में भी जाने जाते हैं) अक्सर दो चर के बीच पैटर्न या सहसंबंध को जांचने के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट का उपयोग तब करें जब:

* आपके पास युग्मित संख्यात्मक डेटा हो
* दो चर एक दूसरे के साथ अच्छी तरह मेल खाते हों
* आप निर्धारित करना चाहते हों कि दो चर संबंधित हैं या नहीं
* आपके पास एक स्वतंत्र चर हो जिसके कई मान निर्भर चर के लिए हों

1. [Create Clustered Column Charts](#create-clustered-column-charts) में बताए गए चरणों का पालन करें।
2. तीसरे चरण में, कुछ डेटा के साथ एक चार्ट जोड़ें और नीचे दिए गए किसी एक चार्ट प्रकार को निर्दिष्ट करें:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _एक स्कैटर चार्ट दर्शाता है।_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _एक स्कैटर चार्ट दर्शाता है जो वक्र रेखाओं से जुड़ा होता है, जिसमें डेटा मार्कर हों।_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _एक स्कैटर चार्ट दर्शाता है जो वक्र रेखाओं से जुड़ा होता है, बिना डेटा मार्कर के।_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _एक स्कैटर चार्ट दर्शाता है जो रेखाओं से जुड़ा होता है, जिसमें डेटा मार्कर हों।_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _एक स्कैटर चार्ट दर्शाता है जो रेखाओं से जुड़ा होता है, बिना डेटा मार्कर के।_

यह Python कोड प्रत्येक सीरीज़ के लिए विभिन्न मार्कर के साथ स्कैटर चार्ट बनाने का तरीका दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# PPTX फ़ाइल का प्रतिनिधित्व करने वाले प्रस्तुति क्लास का उदाहरण बनाता है।
presentation = Presentation()
try:
    # पहली स्लाइड तक पहुँचता है
    slide = presentation.getSlides().get_Item(0)

    # डिफ़ॉल्ट चार्ट बनाता है
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त करता है
    default_worksheet_index = 0

    # चार्ट डेटा वर्कशीट प्राप्त करता है
    workbook = chart.getChartData().getChartDataWorkbook()

    # डेमो सीरीज़ को हटाता है
    chart.getChartData().getSeries().clear()

    # नई सीरीज़ जोड़ता है
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # पहली चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(0)

    # सीरीज़ में नया बिंदु (1:3) जोड़ता है
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # नया बिंदु (2:10) जोड़ता है
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # सीरीज़ प्रकार बदलता है
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # चार्ट सीरीज़ मार्कर बदलता है
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1)

    # वहाँ नया बिंदु (5:2) जोड़ता है
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # नया बिंदु (3:1) जोड़ता है
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # नया बिंदु (2:2) जोड़ता है
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # नया बिंदु (5:1) जोड़ता है
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # चार्ट सीरीज़ मार्कर बदलता है
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेषकर जब डेटा में श्रेणीबद्ध लेबल के साथ संख्यात्मक मान हों। हालांकि, यदि आपके डेटा में बहुत सारे भाग या लेबल हों, तो बार चार्ट का उपयोग करने पर विचार करें।

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Pie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Pie) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. पाई चार्ट के सेक्टरों के लिए कस्टम रंग लागू करें और नए पॉइंट जोड़ें।
9. सीरीज़ के लिए लेबल सेट करें।
10. सीरीज़ लेबल के लिए लीडर लाइन्स सक्षम करें।
11. पाई चार्ट सेक्टरों के लिए घूर्णन कोण सेट करें।
12. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड पाई चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# PPTX फ़ाइल का प्रतिनिधित्व करने वाले प्रस्तुति क्लास का उदाहरण बनाता है।
presentation = Presentation()
try:
    # पहली स्लाइड तक पहुँचता है
    slide = presentation.getSlides().get_Item(0)

    # डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # चार्ट शीर्षक सेट करता है
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # चार्ट डेटा शीट के लिए इंडेक्स सेट करता है
    default_worksheet_index = 0

    # चार्ट डेटा वर्कशीट प्राप्त करता है
    workbook = chart.getChartData().getChartDataWorkbook()

    # डिफ़ॉल्ट जनरेटेड सीरीज़ और श्रेणियों को हटाता है
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # नई श्रेणियाँ जोड़ता है
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # नई सीरीज़ जोड़ता है
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #सीरीज़ डेटा को भरता है
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # नए बिंदु जोड़ता है और सेक्टर का रंग सेट करता है
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # सेक्टर बॉर्डर सेट करता है
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # सेक्टर बॉर्डर सेट करता है
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # सेक्टर बॉर्डर सेट करता है
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # नई सीरीज़ की प्रत्येक श्रेणी के लिए कस्टम लेबल बनाता है
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # चार्ट के लिए लीडर लाइन्स दिखाता है
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # पाई चार्ट सेक्टरों के लिए घूर्णन कोण सेट करता है
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # चार्ट के साथ प्रस्तुति सहेजता है
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिन्हें लाइन ग्राफ़ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मान में परिवर्तन दर्शाना चाहते हैं। लाइन चार्ट का उपयोग करके आप बड़ी मात्रा में डेटा की तुलना एक साथ कर सकते हैं, समय के साथ परिवर्तन और रुझानों को ट्रैक कर सकते हैं, डेटा सीरीज़ में अनियमितताओं को उजागर कर सकते हैं, आदि।

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Line](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Line) प्रकार निर्दिष्ट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड लाइन चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

डिफ़ॉल्ट रूप से, लाइन चार्ट में बिंदु सीधी निरंतर रेखाओं से जुड़े होते हैं। यदि आप बिंदुओं को डैशेज़ से जोड़ना चाहते हैं, तो नीचे दर्शाए अनुसार अपनी पसंदीदा डैश टाइप निर्दिष्ट कर सकते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट बिक्री डेटा के लिए सबसे उपयुक्त होते हैं जब आप डेटा श्रेणियों के सापेक्ष आकार दिखाना और प्रत्येक श्रेणी के भीतर बड़े योगदानकर्ताओं पर जल्दी से ध्यान आकर्षित करना चाहते हैं।

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Treemap](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Treemap) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड ट्री मैप चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #शाखा 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #शाखा 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **स्टॉक चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#OpenHighLowClose) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. हाई‑लो लाइन्स का फ़ॉर्मेट निर्दिष्ट करें।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड स्टॉक चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **बॉक्स एंड व्हिस्कर चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#BoxAndWhisker) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड बॉक्स एंड व्हिस्कर चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **फ़नल चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Funnel](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Funnel) प्रकार निर्दिष्ट करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड फ़नल चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सनबर्स्ट चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Sunburst](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Sunburst) प्रकार निर्दिष्ट करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड सनबर्स्ट चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #शाखा 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #शाखा 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **हिस्टोग्राम चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Histogram](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Histogram) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड हिस्टोग्राम चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **रेडार चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. कुछ डेटा के साथ एक चार्ट जोड़ें और अपनी पसंद के चार्ट प्रकार को निर्दिष्ट करें ([ChartType.Radar](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Radar) इस मामले में)।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड रेडार चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **मल्टी‑कैटेगरी चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.ClusteredColumn](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ClusteredColumn) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड मल्टी‑कैटेगरी चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # सीरीज़ जोड़ना
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # चार्ट के साथ प्रस्तुति सहेजें
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को विज़ुअलाइज़ करते हैं और क्षेत्रों के बीच मूल्यों की तुलना करने में मदद करते हैं।

यह Python कोड मैप चार्ट बनाने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **कम्बिनेशन चार्ट बनाएं**

कम्बिनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ़ में दो या अधिक चार्ट प्रकारों को मिलाता है। इस चार्ट से आप दो या अधिक डेटा सेट के बीच अंतर को उजागर, तुलना या विश्लेषण कर सकते हैं, जिससे उनके बीच संबंधों की पहचान करने में सहायता मिलती है।

![The combination chart](combination_chart.png)

निम्नलिखित Python कोड ऊपर दिखाए गए कॉम्बिनेशन चार्ट को PowerPoint प्रस्तुति में बनाने का तरीका दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # चार्ट शीर्षक सेट करें।
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # चार्ट लेजेंड सेट करें।
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाएँ।
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # नई श्रेणियाँ जोड़ें।
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # पहली सीरीज़ जोड़ें।
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # क्षैतिज अक्ष सेट करें।
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # ऊर्ध्वाधर अक्ष सेट करें।
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # ऊर्ध्वाधर मेजर ग्रिडलाइन का रंग सेट करें।
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # सेकेंडरी क्षैतिज अक्ष सेट करें।
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # सेकेंडरी ऊर्ध्वाधर अक्ष सेट करें।
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **चार्ट अपडेट करें**

1. उस [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं जो उस प्रस्तुति का प्रतिनिधित्व करता है जिसमें वह चार्ट है जिसे आप अपडेट करना चाहते हैं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. सभी शेप्स को पारित करके इच्छित चार्ट खोजें।
4. चार्ट डेटा वर्कशीट तक पहुंचें।
5. सीरीज़ मान बदलकर चार्ट डेटा सीरीज़ को संशोधित करें।
6. एक नई सीरीज़ जोड़ें और उसका डेटा भरें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड चार्ट को अपडेट करने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# उस प्रस्तुति को खोलता है जिसमें अपडेट करने के लिये चार्ट है
presentation = Presentation("ExistingChart.pptx")
try:
    # पहले स्लाइड तक पहुँचें
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड से चार्ट प्राप्त करें
    chart = slide.getShapes().get_Item(0)

    # चार्ट डेटा शीट का इंडेक्स सेट कर रहा है
    default_worksheet_index = 0

    # चार्ट डेटा वर्कशीट प्राप्त कर रहा है
    workbook = chart.getChartData().getChartDataWorkbook()

    # चार्ट श्रेणी नाम बदल रहा है
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # पहली चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(0)

    # अब सीरीज़ डेटा अपडेट कर रहा है
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# सीरीज़ नाम संशोधित कर रहा है
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1)

    # अब सीरीज़ डेटा अपडेट कर रहा है
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# सीरीज़ नाम संशोधित कर रहा है
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # अब, नई सीरीज़ जोड़ रहा है
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # तीसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(2)

    # अब सीरीज़ डेटा भर रहा है
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # चार्ट के साथ प्रस्तुति सहेजें
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट के लिए डेटा रेंज सेट करें**

किसी मौजूदा चार्ट द्वारा पहले से उपयोग की गई रेंज को जांचने के लिए, देखें [Retrieve a Chart's Data Range](/slides/hi/python-java/chart-workbook/#retrieve-a-charts-data-range)।

चार्ट के लिए डेटा रेंज सेट करने के लिए निम्न कार्य करें:

1. उस [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं जो उस प्रस्तुति का प्रतिनिधित्व करता है जिसमें चार्ट है।
2. उसके इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
3. सभी शेप्स को पारित करके इच्छित चार्ट खोजें।
4. डेटा तक पहुंचें और रेंज सेट करें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह Python कोड चार्ट की डेटा रेंज सेट करने का उदाहरण दिखाता है:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# उस प्रस्तुति को खोलता है जिसमें चार्ट है
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट्स में डिफ़ॉल्ट मार्कर उपयोग करें**

जब आप चार्ट्स में डिफ़ॉल्ट मार्कर उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से एक अलग मार्कर प्रतीक प्राप्त होता है।

यह Python कोड एक चार्ट सीरीज़ मार्कर को स्वचालित रूप से सेट करने का उदाहरण दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #दूसरी चार्ट सीरीज़ ले
    second_series = chart.getChartData().getSeries().get_Item(1)

    #अब सीरीज़ डेटा भर रहे हैं
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides द्वारा कौन‑से चार्ट प्रकार समर्थित हैं?**

Aspose.Slides विभिन्न [chart types](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) का समर्थन करता है, जिसमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार और कई अन्य शामिल हैं। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**मैं स्लाइड में नया चार्ट कैसे जोड़ूँ?**

एक नया चार्ट जोड़ने के लिए, पहले आप [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने की विधि को कॉल करके चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में एकीकृत करती है।

**मैं चार्ट में प्रदर्शित डेटा को कैसे अपडेट करूँ?**

आप चार्ट का डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)) तक पहुंचकर, डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ करके, और फिर अपने कस्टम डेटा को जोड़कर अपडेट कर सकते हैं। इस प्रकार आप चार्ट को नवीनतम डेटा दर्शाने के लिए रिफ्रेश कर सकते हैं।

**क्या मैं चार्ट की उपस्थिति को अनुकूलित कर सकता हूँ?**

हाँ, Aspose.Slides व्यापक अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य [formatting elements](/slides/hi/python-java/chart-entities/) को बदलकर चार्ट की उपस्थिति को आपके विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार ढाल सकते हैं।