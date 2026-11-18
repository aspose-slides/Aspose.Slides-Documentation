---
title: Python में PowerPoint प्रस्तुति चार्ट बनाना या अपडेट करना
linktitle: चार्ट बनाना या अपडेट करना
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
- फनल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकैटेगरी चार्ट
- पावरपॉइंट
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। Python में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, स्वरूपित करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via Java का उपयोग करके चार्ट बनाने और अनुकूलित करने की व्यापक गाइड प्रदान करता है। आप प्रोग्रामेटिक रूप से स्लाइड में चार्ट जोड़ना, डेटा से भरना, और अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुरूप विभिन्न स्वरूपण विकल्प लागू करना सीखेंगे। लेख में विस्तृत कोड उदाहरण प्रत्येक चरण को प्रदर्शित करते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को इनिशियलाइज़ करने से लेकर श्रृंखला, अक्ष और लेजेंड को कॉन्फ़िगर करने तक। इस गाइड का पालन करके आप Python अनुप्रयोगों में डायनेमिक चार्ट जेनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवेन प्रस्तुतियों का निर्माण आसान हो जाएगा।

## **चार्ट बनाना**

चार्ट लोगों को डेटा को शीघ्रता से दृश्य रूप में प्रस्तुत करने और उन अंतर्दृष्टियों को प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं होतीं।

**चार्ट क्यों बनाएँ?**

चार्ट का उपयोग करके आप:

* बड़े पैमाने पर डेटा को एक ही स्लाइड में समेकित, संक्षिप्त या सारांशित कर सकते हैं;
* डेटा में पैटर्न और रुझान उजागर कर सकते हैं;
* समय के साथ या किसी विशिष्ट माप इकाई के सापेक्ष डेटा की दिशा और गति निर्धारित कर सकते हैं;
* अपवाद, विचलन, त्रुटियाँ और असंगत डेटा की पहचान कर सकते हैं;
* जटिल डेटा को प्रभावी रूप से संप्रेषित या प्रस्तुत कर सकते हैं।

PowerPoint में आप *Insert* फ़ंक्शन के माध्यम से कई प्रकार के चार्ट टेम्प्लेट चुनकर चार्ट बना सकते हैं। Aspose.Slides का उपयोग करके आप सामान्य चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" title="Note" %}}

[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) enumeration को [asposeslides.api](https://reference.aspose.com/slides/python-java/aspose.slides/) पैकेज में उपयोग करें। इस enumeration के मान विभिन्न चार्ट प्रकारों के अनुरूप होते हैं।

{{% /alert %}}

### **क्लस्टरित कॉलम चार्ट बनाना**

यह उदाहरण [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) का उपयोग करके क्लस्टरित कॉलम चार्ट बनाता है जो तीन श्रेणियों में दो श्रृंखलाओं की तुलना करता है। श्रृंखलाएँ लाल और हरे रंग से भरी हुई हैं, और व्यक्तिगत लेबल श्रेणी नाम, श्रृंखला नाम तथा मान प्रदर्शित करते हैं। वर्कशीट इंडेक्स 0 एंबेडेड चार्ट वर्कबुक की पहली शीट को दर्शाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().get_Item(0)

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    series = chart.getChartData().getSeries().get_Item(1)

    value_cell = workbook.getCell(worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    series.getFormat().getFill().getSolidFillColor().setColor(color)

    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![क्लस्टरित कॉलम चार्ट](clustered_column_chart.png)

### **स्कैटर चार्ट बनाना**

स्कैटर चार्ट (जिसे स्कैटर प्लॉट या x‑y ग्राफ भी कहा जाता है) अक्सर दो चर के बीच पैटर्न या सहसम्बन्ध जांचने के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट का उपयोग तब करें जब:

* आपके पास युग्मित संख्यात्मक डेटा हो।
* दो चर अच्छे से जुड़ते हों।
* आप यह निर्धारित करना चाहते हों कि दोनों चर संबंधित हैं या नहीं।
* आपके पास एक स्वतंत्र चर हो जिसके कई मान आश्रित चर के लिये हों।

यह उदाहरण दो सेट के x‑y मानों को प्लॉट करता है। पहली श्रृंखला स्टार मार्कर वाली सीधी रेखा का उपयोग करती है, जबकि दूसरी स्मूद रेखा के साथ सर्कल मार्कर उपयोग करती है; दोनों का मार्कर आकार 10 है, जो [setSize](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSize) द्वारा कॉन्फ़िगर किया गया है। [setSymbol](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSymbol) मेथड मार्कर के आकार को नियंत्रित करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()

    series_name_cell = workbook.getCell(worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    x_value_cell = workbook.getCell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.getCell(worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.getCell(worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    series = chart.getChartData().getSeries().get_Item(1)

    x_value_cell = workbook.getCell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.getCell(worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.getCell(worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![स्कैटर चार्ट](scatter_chart.png)

### **पाई चार्ट बनाना**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए आदर्श होते हैं, विशेष रूप से जब डेटा में श्रेणी लेबल के साथ संख्यात्मक मान हों। हालांकि, यदि आपके डेटा में बहुत अधिक भाग या लेबल हों तो बार चार्ट पर विचार किया जा सकता है।

यह उदाहरण तीन तिमाही मानों के साथ पाई चार्ट बनाता है। प्रत्येक स्लाइस में कस्टम फ़िल और बॉर्डर है, और लेबल विभिन्न संयोजन (मान, प्रतिशत, श्रृंखला सूचना) प्रदर्शित करते हैं। [setFirstSliceAngle](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setFirstSliceAngle) मेथड पहले स्लाइस को 180 डिग्री पर शुरू करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    category_cell = workbook.getCell(0, 1, 0, "1st Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    first_slice = series.getDataPoints().get_Item(0)
    first_slice.getFormat().getFill().setFillType(FillType.Solid)
    first_slice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    first_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    first_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    first_slice.getFormat().getLine().setWidth(3.0)
    first_slice.getFormat().getLine().setStyle(LineStyle.ThinThick)
    first_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash)

    second_slice = series.getDataPoints().get_Item(1)
    second_slice.getFormat().setFillType(FillType.Solid)
    color = Color(165, 42, 42)
    second_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    second_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_slice.getFormat().getLine().setWidth(3.0)
    second_slice.getFormat().getLine().setStyle(LineStyle.Single)
    second_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_slice = series.getDataPoints().get_Item(2)
    third_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(255, 127, 80)
    third_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    third_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_slice.getFormat().getLine().setWidth(2.0)
    third_slice.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    presentation.save("PieChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पाई चार्ट](pie_chart.png)

बाहरी लेबल की पठनीयता सुधारने के लिए देखें [Format Leader Lines](/slides/hi/python-java/chart-data-label/#format-leader-lines) जहाँ लेबल का स्थान निर्धारण और लाइनों का रंग, चौड़ाई, पारदर्शिता एवं डैश शैली को कस्टमाइज़ किया गया है।

### **लाइन चार्ट बनाना**

लाइन चार्ट (जिसे लाइन ग्राफ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मान में परिवर्तन दर्शाना चाहते हैं। लाइन चार्ट के माध्यम से आप बड़ी मात्रा में डेटा की तुलना, समय के साथ रुझान ट्रैक, डेटा श्रृंखला में विसंगतियों को उजागर आदि कर सकते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) का उपयोग करके डिफ़ॉल्ट श्रृंखला और श्रेणियों के साथ लाइन चार्ट बनाता है और प्रस्तुति को PPTX के रूप में सहेजता है।

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

डिफ़ॉल्ट रूप से, लाइन चार्ट के बिंदु सीधी निरंतर रेखाओं से जुड़े होते हैं। यदि आप डैश लाइन चाहते हैं तो [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) को [LineDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) के मान के साथ कॉल करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)
finally:
    presentation.dispose()
```

परिणाम:

![लाइन चार्ट](line_chart.png)

### **ट्री मैप चार्ट बनाना**

ट्री मैप चार्ट उन बिक्री डेटा के लिए उपयुक्त होते हैं जहाँ आप डेटा श्रेणियों के सापेक्ष आकार दिखाना चाहते हैं और प्रत्येक श्रेणी में बड़े योगदानकर्ता आइटम पर जल्दी से ध्यान आकर्षित करना चाहते हैं।

यह उदाहरण आठ पत्तियों को चार स्टेम और दो ब्रांच में समूहित करके ट्री मैप बनाता है। [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) मेथड स्टेम को ग्रुपिंग लेवल 1 और ब्रांच को लेवल 2 पर सेट करता है। मान आयतों के सापेक्ष आकार निर्धारित करते हैं, जबकि श्रेणी लेबल और ओवरलैपिंग पैरेंट लेबल पदानुक्रम पहचानते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # शाखा 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # शाखा 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![ट्रीमैप चार्ट](treemap_chart.png)

### **वॉटरफ़ॉल चार्ट बनाना**

वॉटरफ़ॉल चार्ट दिखाता है कि सकारात्मक और नकारात्मक परिवर्तन अंतिम मान में कैसे योगदान देते हैं। उदाहरण के तौर पर, लाभ विभाजन में राजस्व से शुरू होकर लागत घटाकर अन्य आय जोड़ने तक प्रक्रिया दिखायी जा सकती है। परिवर्तन कॉलम पिछले और नई चल रही मान के बीच तैरते हैं, जबकि कुल कॉलम शून्य से संचयी मान तक विस्तारित होते हैं।

नीचे दिया गया उदाहरण हजारों अमेरिकी डॉलर में मान दर्शाता है:

| Category | Workbook value | Column type |
| --- | ---: | --- |
| Revenue | 1000 | Increase |
| Cost of sales | -400 | Decrease |
| Gross profit | 600 | Intermediate total |
| Operating expenses | -200 | Decrease |
| Other income | 50 | Increase |
| Net profit | 450 | Final total |

किसी बिंदु को मध्यवर्ती या अंतिम कुल के रूप में चिह्नित करने के लिये उसके [setSetAsTotal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setSetAsTotal) मेथड को `True` से कॉल करें। उस बिंदु की वर्कबुक सेल में वास्तविक संचयी राशि प्रदान करें: कुल लाभ के लिये `600` (`1000 - 400`) और शुद्ध लाभ के लिये `450` (`600 - 200 + 50`)। यह मेथड कॉलम को कुल के रूप में चिह्नित करता है; यह सेल मान की गणना नहीं करता। शून्य को प्लेसहोल्डर के रूप में उपयोग न करें या कुल बिंदु के लिये कोई अन्य परिवर्तन न जोड़ें। कुल कॉलम केवल संचयी मान दिखाता है, उसे दोबारा जोड़ता नहीं।

यह पूर्ण Python उदाहरण `Waterfall` सदस्य का उपयोग करके [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) से चार्ट बनाता है, डिफ़ॉल्ट डेटा साफ़ करता है और एम्बेडेड वर्कबुक को भरता है। वर्कशीट इंडेक्स `0` पहली शीट चुनता है; कॉलम A में श्रेणी नाम और कॉलम B में मान होते हैं। प्रत्येक मान सेल को [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#addDataPointForWaterfallSeries) से जोड़ा जाता है। शून्य‑आधारित बिंदु इंडेक्स `2` और `5` क्रमशः मध्यवर्ती और अंतिम कुल दर्शाते हैं। [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) को `True` करने से मान कॉलम पर दिखाई देते हैं। कोई इनपुट प्रस्तुति या वर्कबुक आवश्यक नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)")
    chart.getChartTitle().setOverlay(False)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Profit")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Waterfall)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, categories[i])
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(worksheet_index, i + 1, 1, values[i])
        series.getDataPoints().addDataPointForWaterfallSeries(value_cell)

    # तीसरा और छठा बिंदु कुल को दर्शाते हैं, अतिरिक्त परिवर्तन नहीं।
    series.getDataPoints().get_Item(2).setSetAsTotal(True)
    series.getDataPoints().get_Item(5).setSetAsTotal(True)
    series.setShowConnectorLines(True)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

श्रृंखला‑स्तर पर [setShowConnectorLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setShowConnectorLines) को `True` करने से क्रमागत कॉलमों को जोड़ने वाली रेखाएँ दिखती हैं, जिससे चल रही मान को फॉलो करना आसान हो जाता है। इन रेखाओं को छिपाने के लिये उदाहरण में `series.setShowConnectorLines(False)` कॉल को सहेजने से पहले बदलें। यह केवल रेखा की दृश्यता बदलता है, डेटा या कुल को नहीं।

सहेजी गई प्रस्तुति में कुल लाभ 600 और शुद्ध लाभ 450 दर्शाए गए हैं, दोनों शून्य से शुरू होते हैं:

![वॉटरफ़ॉल चार्ट जिसमें राजस्व, लागत, कुल लाभ 600 और शुद्ध लाभ 450 के साथ मान लेबल और कनेक्टर लाइन्स हैं](waterfall_chart.png)

### **स्टॉक चार्ट बनाना**

स्टॉक चार्ट का उपयोग ओपन, हाई, लो और क्लोज कीमतों जैसे वित्तीय डेटा को दर्शाने के लिये किया जाता है, जिससे बाजार के रुझान और अस्थिरता का विश्लेषण आसान हो जाता है। ये चार्ट स्टॉक प्रदर्शन पर आवश्यक अंतर्दृष्टि प्रदान करते हैं, जिससे निवेशकों और विश्लेषकों को सूचित निर्णय लेने में मदद मिलती है।

यह उदाहरण चार श्रृंखलाओं (Open‑High‑Low‑Close क्रम) और तीन श्रेणियों के साथ ओपन‑हाई‑लो‑क्लोज चार्ट बनाता है। [setUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#setUpDownBars) मेथड अप/डाउन बार सक्षम करता है, और [getHiLowLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getHiLowLinesFormat) हाई‑लो लाइन्स को नियंत्रित करता है, जबकि व्यक्तिगत श्रृंखला रेखाएँ और छोटे हॉरिज़ॉन्टल ग्रिडलाइन छिपी रहती हैं।

[getUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getUpDownBars) द्वारा लौटाए गए मैनेजर में [getUpBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getUpBarsFormat) और [getDownBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getDownBarsFormat) के माध्यम से अलग‑अलग फ़ॉर्मेटिंग ऑब्जेक्ट्स उपलब्ध होते हैं। प्रत्येक ऑब्जेक्ट की [getFill](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getFill) और [getLine](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getLine) मेथड से फ़िल और आउटलाइन स्वतंत्र रूप से सेट करें। यह उदाहरण ग्रिन बार्स को डार्क‑ग्रिन आउटलाइन और ऑरेंज‑रेड बार्स को डार्क‑रेड आउटलाइन के साथ दिखाता है।

सभी चार श्रृंखलाओं के लिये प्रत्येक श्रेणी में संख्यात्मक मान प्रदान करें, जहाँ हाई और लो ओपन और क्लोज को घेरते हैं। बार्स समान श्रेणी में क्लोज को ओपन के साथ तुलना करते हैं, पहले श्रेणी के साथ नहीं: A 72 से 25 तक गिरता है, जबकि B 25 से 38 और C 38 से 50 तक बढ़ता है। समान ओपन और क्लोज मानों से कोई दृश्य फ़िल्ड इंटर्वल नहीं बनता। अप/डाउन बार ओपन‑क्लोज को कवर करते हैं; हाई‑लो लाइन्स लो‑हाई को कवर करती हैं। ये बार्स श्रृंखला‑ग्रुप का हिस्सा होते हैं, सामान्य बार‑चार्ट श्रृंखलाएँ नहीं।

यह फ़ॉर्मेटिंग [Line and LineWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) चार्ट्स पर भी काम करती है, जिसमें कम से कम दो श्रृंखलाएँ एक ही ग्रुप में हों और प्रत्येक श्रेणी के लिये संख्यात्मक मान उपलब्ध हों। इन गैर‑स्टैक्ड लाइन चार्ट्स में अप/डाउन बार पहली और अंतिम श्रृंखला की तुलना करते हैं: उच्च अंतिम मान अप‑बार उत्पन्न करता है, और निम्न अंतिम मान डाउन‑बार। श्रृंखलाओं का क्रम बदलने से वर्गीकरण उलट जाता है। नीचे का उदाहरण [OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) का उपयोग करता है; अन्य स्टॉक, स्टैक्ड‑लाइन या 3D वैरिएंट्स समान डेटा व्यवस्था या इंटरवल व्याख्या नहीं मानते।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, False)

    workbook = chart.getChartData().getChartDataWorkbook()

    category_cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)

    series = chart.getChartData().getSeries().get_Item(0)
    value_cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(1)
    value_cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(2)
    value_cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(3)
    value_cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    up_down_bars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars()
    up_down_bars.setUpDownBars(True)

    up_down_bars.getUpBarsFormat().getFill().setFillType(FillType.Solid)
    up_fill_color = Color(50, 205, 50)
    up_down_bars.getUpBarsFormat().getFill().getSolidFillColor().setColor(up_fill_color)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    up_line_color = Color(0, 100, 0)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(up_line_color)
    up_down_bars.getUpBarsFormat().getLine().setWidth(2)

    up_down_bars.getDownBarsFormat().getFill().setFillType(FillType.Solid)
    down_fill_color = Color(255, 69, 0)
    up_down_bars.getDownBarsFormat().getFill().getSolidFillColor().setColor(down_fill_color)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    down_line_color = Color(139, 0, 0)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(down_line_color)
    up_down_bars.getDownBarsFormat().getLine().setWidth(2)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for stock_series in chart.getChartData().getSeries():
        stock_series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम, PowerPoint से निर्यात किया गया:

![स्टॉक चार्ट जिसमें A के लिये ऑरेंज‑रेड गिरता हुआ इंटरवल और B तथा C के लिये ग्रीन बढ़ता हुआ इंटरवल है](stock_chart.png)

### **बॉक्स एंड व्हिस्कर चार्ट बनाना**

बॉक्स एंड व्हिस्कर चार्ट डेटा वितरण को मुख्य सांख्यिकीय माप (मध्यम, क्वार्टाइल, संभावित आउट्लायर्स) के सारांश के साथ दर्शाते हैं। ये अन्वेषणात्मक डेटा विश्लेषण और सांख्यिकीय अध्ययनों में डेटा परिवर्तनशीलता को जल्दी समझने और विसंगतियों की पहचान करने में उपयोगी होते हैं।

यह उदाहरण छह मानों से बॉक्स एंड व्हिस्कर चार्ट बनाता है। [setQuartileMethod](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setQuartileMethod) मेथड एक्सक्लूसिव क्वार्टाइल गणना चुनता है। उदाहरण में माध्य रेखाएँ, माध्य मार्कर, भीतरी बिंदु और आउट्लायर बिंदु भी सक्षम किए गए हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    value_cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **फनल चार्ट बनाना**

फनल चार्ट उन प्रक्रियाओं को दृश्य रूप में प्रस्तुत करते हैं जिनमें क्रमिक चरण होते हैं, जहाँ डेटा की मात्रा प्रत्येक चरण के साथ घटती जाती है। ये रूपांतरण दरों का विश्लेषण, बाधाओं की पहचान और बिक्री या मार्केटिंग प्रक्रिया की दक्षता ट्रैक करने में विशेष रूप से सहायक होते हैं।

यह उदाहरण मौजूदा प्रस्तुति के पहले स्लाइड में [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) का उपयोग करके फनल चार्ट जोड़ता है। यह डिफ़ॉल्ट डेटा को छह श्रेणियों और 50‑से‑500 तक के मानों से बदलता है, फिर अद्यतित प्रस्तुति को सहेजता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होना आवश्यक है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    value_cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![फनल चार्ट](funnel_chart.png)

### **सनबर्स्ट चार्ट बनाना**

सनबर्स्ट चार्ट पदानुक्रमित डेटा को प्रदर्शित करने के लिये उपयोग किए जाते हैं, जहाँ स्तरों को गोलाकार रिंग के रूप में दिखाया जाता है। ये भाग‑से‑सम्पूर्ण संबंधों को स्पष्ट और संक्षिप्त रूप में प्रस्तुत करने में मदद करते हैं, विशेष रूप से नेस्टेड श्रेणियों के लिये।

यह उदाहरण आठ पत्तियों को चार स्टेम और दो ब्रांच में समूहित करके सनबर्स्ट चार्ट बनाता है। [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) मेथड स्टेम को लेवल 1 और ब्रांच को लेवल 2 पर सेट करता है। श्रेणी लेबल से सेगमेंट की पहचान होती है, और मान सापेक्ष आकार निर्धारित करते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # शाखा 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # शाखा 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![सनबर्स्ट चार्ट](sunburst_chart.png)

### **हिस्टोग्राम चार्ट बनाना**

हिस्टोग्राम चार्ट दर्शाते हैं कि संख्यात्मक मान अंतराल (बिन) में कैसे वितरित होते हैं। मासिक ऑर्डर प्रोसेसिंग समय रिपोर्टों में समान बिन चौड़ाई और थ्रेशहोल्ड रखकर अंतराल निरंतर रख सकते हैं और तुलना आसान बना सकते हैं।

हॉरिज़ॉन्टल एक्सिस पर [setAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAggregationType) को [AxisAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axisaggregationtype/) के मान से सेट करें। [setBinWidth](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setBinWidth) केवल `ByBinWidth` के लिये लागू होता है; [setNumberOfBins](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberOfBins) केवल `ByNumberOfBins` के लिये। `Automatic` का उपयोग करके चार्ट को बिन चुनने दें।

#### **स्थिर बिन चौड़ाई का उपयोग**

यह उदाहरण प्रोसेसिंग समय को 10‑मिनट अंतराल में समूहित करता है, जिसमें 10 मिनट तक के और 40 मिनट से अधिक के लिये अलग बिन होते हैं। इन बिन को [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) और [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin) से सक्षम करें। जब आप स्पष्ट थ्रेशहोल्ड [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) और [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin) से देते हैं, तो [setAutomaticUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticUnderflowBin) और [setAutomaticOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticOverflowBin) को `False` सेट करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByBinWidth)
    axis.setBinWidth(10.0)
    axis.setUnderflowBin(True)
    axis.setAutomaticUnderflowBin(False)
    axis.setUnderflowBin(10.0)
    axis.setOverflowBin(True)
    axis.setAutomaticOverflowBin(False)
    axis.setOverflowBin(40.0)

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint में प्रदर्शित प्रस्तुति में बिन काउंट **3, 4, 4, 4, और 2** हैं। अंडरफ़्लो बिन में `5, 10, 10` शामिल हैं, इसलिए इसका थ्रेशहोल्ड इनक्लूसिव है। ओवरफ़्लो बिन में केवल `41, 50` हैं, इसलिए इसका थ्रेशहोल्ड एक्सक्लूसिव है; दोनों मान `40` पूर्ववर्ती अंतराल में रहते हैं। इंटरनल बिन में मान निचली सीमा से बड़े और ऊपर की सीमा से छोटे या बराबर होते हैं।

![10‑मिनट बिन और स्पष्ट अंडरफ़्लो व ओवरफ़्लो थ्रेशहोल्ड के साथ हिस्टोग्राम](histogram_bin_width.png)

#### **बिन की संख्या निर्दिष्ट करें**

स्थिर अंतराल के बजाय स्थिर विवरण स्तर चाहिए तो समान डेटा के लिये पाँच बिन अनुरोध करें। यह उदाहरण अंडरफ़्लो और ओवरफ़्लो बिन को अक्षम रखता है। चार्ट डेटा रेंज से चौड़ाई निर्धारित करता है, इसलिए सीमाएँ रिपोर्ट‑दर‑रिपोर्ट बदल सकती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins)
    axis.setNumberOfBins(5)

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

पाँच बिन का काउंट **4, 4, 4, 4, और 1** है। ऊपर के स्थिर‑चौड़ाई परिणाम से तुलना करें: इनपुट मान समान हैं, लेकिन सीमाएँ अलग हैं।

![एक ही डेटा से गणना किए गए पाँच बिन के साथ हिस्टोग्राम](histogram_bin_count.png)

### **रेडार चार्ट बनाना**

रेडार चार्ट कई चर को दो‑आयामी फ़ॉर्मेट में प्रदर्शित करता है, जिससे कई वैरिएबल की एक साथ तुलना आसान हो जाती है। ये चार्ट विभिन्न प्रदर्शन मीट्रिक या विशेषताओं में पैटर्न, ताकत और कमजोरियों की पहचान करने में विशेष रूप से उपयोगी होते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) का उपयोग करके डिफ़ॉल्ट श्रृंखला और श्रेणियों के साथ रेडार चार्ट बनाता है और प्रस्तुति को PPTX के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addChart(ChartType.Radar, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![रेडार चार्ट](radar_chart.png)

### **मल्टी‑कैटेगरी चार्ट बनाना**

मल्टी‑कैटेगरी चार्ट उन डेटा को दर्शाते हैं जिनमें एक से अधिक श्रेणी समूह होते हैं, जिससे आप कई आयामों में मानों की तुलना एक साथ कर सकते हैं। ये जटिल, बहु‑परत डेटा सेट में रुझान और संबंध विश्लेषण के लिये विशेष रूप से सहायक होते हैं।

यह उदाहरण चार जोड़े में व्यवस्थित आठ श्रेणियों के साथ क्लस्टरित कॉलम चार्ट बनाता है। [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) मेथड प्रत्येक जोड़े को ग्रुपिंग लेवल 1 पर साझा लेबल देता है, जिससे व्यक्तिगत और समूह दोनों लेबल वाली श्रेणी अक्ष बनती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    category_cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    category_cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    category_cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    category_cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    value_cell = workbook.getCell(worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![मल्टी‑कैटेगरी चार्ट](multi_category_chart.png)

#### **एक क्वार्टर लेबल हटाएँ**

[quarters.pptx](quarters.pptx) डाउनलोड करके कार्य निर्देशिका में रखें। इसका चार्ट नौ महीने और एक बिक्री श्रृंखला को 10‑से‑18 मानों के साथ प्रदर्शित करता है। श्रेणी अक्ष पर Q1 जनवरी‑मार्च, Q2 अप्रैल‑जून, Q3 जुलाई‑सितंबर को कवर करता है।

अप्रैल चौथा श्रेणी (इंडेक्स 3) है और Q2 लेबल रखता है। अप्रैल के ग्रुपिंग लेवल को प्राप्त करने के लिये [getGroupingLevels](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getGroupingLevels) कॉल करें, फिर लेवल 1 को हटाने हेतु [deleteGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#deleteGroupingItem) को कॉल करें। लेवल 0 स्वयं महीने को दर्शाता है और इस मेथड से हटाया नहीं जा सकता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("quarters.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    april = chart.getChartData().getCategories().get_Item(3)
    april.getGroupingLevels().deleteGroupingItem(1)

    presentation.save("quarters-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened = Presentation("quarters-updated.pptx")
try:
    chart = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
    data = chart.getChartData()
    
    points = data.getSeries().get_Item(0).getDataPoints()
    print(", ".join(str(month.getAsCell().getValue()) for month in data.getCategories()))
    print(", ".join(str(point.getValue().getData()) for point in points))
finally:
    reopened.dispose()
```

चार्ट को पुनः खोलने के बाद उदाहरण मूल महीनों (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) और बिक्री मान (`10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0`) को उसी क्रम में प्रिंट करता है। `quarters-updated.pptx` को PowerPoint में खोलें और अक्ष लेबल की तुलना करें। Q2 लेबल और अप्रैल से पहले का समूह सीमा हट गया है, इसलिए Q1 अब जनवरी‑से‑जून को कवर करता है। Q3 अभी भी जुलाई से शुरू होता है।

![लेबल हटाने से पहले और बाद की तुलना। बाईं ओर Q2 अप्रैल‑से‑जून को कवर करता है, दायीँ ओर Q1 जनवरी‑से‑जून को।](quarter-label-comparison.png)

### **मैप चार्ट बनाना**

मैप चार्ट भौगोलिक डेटा को देशों, राज्यों या शहरों जैसी विशिष्ट लोकेशन पर मैप करके दृश्यमान बनाते हैं। ये क्षेत्रीय रुझान, जनसांख्यिकीय डेटा और स्थानिक वितरण का विश्लेषण स्पष्ट और आकर्षक रूप में करने में उपयोगी होते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) का उपयोग करके डिफ़ॉल्ट भू‑गर्भीय डेटा वाले मैप चार्ट को बनाता है और PowerPoint में देखने के लिये सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![मैप चार्ट](map_chart.png)

{{% alert color="info" title="Note" %}}

ऊपर की तस्वीर में सहेजी गई प्रस्तुति PowerPoint में खुली हुई दिखाई गई है। Aspose.Slides मानचित्र चार्ट और उसका डेटा सही ढंग से लिखता है, लेकिन स्वयं मानचित्र चार्ट नहीं बनाता: जब कोई स्लाइड जिसमें मानचित्र चार्ट हो इमेज या PDF या SVG में रेंडर होता है, तो चार्ट क्षेत्र खाली दिखता है। उसी स्लाइड के अन्य आकार प्रभावित नहीं होते।

{{% /alert %}}

### **कम्बिनेशन चार्ट बनाना**

कम्बिनेशन (या कॉम्बो) चार्ट एक ही ग्राफ़ में दो या अधिक चार्ट प्रकारों को जोड़ता है। यह चार्ट आपको कई डेटा सेटों की तुलना, अंतर को उजागर या जांचने में मदद करता है, जिससे उनके बीच के संबंध समझना आसान हो जाता है।

![कम्बिनेशन चार्ट](combination_chart.png)

यह उदाहरण चार क्लस्टरित कॉलम श्रृंखलाओं को एक लाइन श्रृंखला के साथ चार श्रेणियों में जोड़ता है। कॉलम प्राथमिक वर्टिकल अक्ष का उपयोग करते हैं, जबकि [setPlotOnSecondAxis](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setPlotOnSecondAxis) लाइन को दाएँ ओर द्वितीयक वर्टिकल अक्ष पर रखता है। सहायक फ़ंक्शन शीर्षक, लेजेंड, अक्ष लेबल और ग्रिडलाइन को कॉन्फ़िगर करते हैं।

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

    # डिफ़ॉल्ट जेनरेट की गई श्रृंखला और श्रेणियों को हटाएँ।
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # नई श्रेणियां जोड़ें।
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # पहली श्रृंखला जोड़ें।
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

    # ऊर्ध्वाधर प्रमुख ग्रिडलाइन का रंग सेट करें।
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # द्वितीयक क्षैतिज अक्ष सेट करें।
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # द्वितीयक ऊर्ध्वाधर अक्ष सेट करें।
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

## **चार्ट अपडेट करना**

Aspose.Slides for Python via Java आपको PowerPoint चार्ट को डेटा, स्वरूपण और स्टाइलिंग संशोधित करके अपडेट करने की सुविधा देता है। यह कार्यक्षमता प्रस्तुतियों को गतिशील सामग्री के साथ अद्यतित रखने और चार्ट को वर्तमान डेटा और दृश्य मानकों के अनुसार सटीक रूप से प्रतिबिंबित करने को सरल बनाती है।

यह उदाहरण मौजूदा प्रस्तुति के पहले स्लाइड पर "My chart" नामक चार्ट को अपडेट करता है। इसमें प्रत्येक में तीन डेटा बिंदुओं वाली दो कॉलम श्रृंखलाओं की आवश्यकता होती है, जहाँ श्रेणी लेबल कॉलम A में और श्रृंखला नाम प्रथम पंक्ति में होते हैं। उदाहरण [getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) का उपयोग करके वर्कबुक सेल बदलता है, श्रृंखला मान अपडेट करता है, तीसरी श्रृंखला जोड़ता है, और [setType](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setType) के माध्यम से चार्ट को क्लस्टरित सिलिंडर में बदलता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartType, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            worksheet_index = 0

            workbook = chart.getChartData().getChartDataWorkbook()

            workbook.getCell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.getCell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.getChartData().getSeries().get_Item(0)

            workbook.getCell(worksheet_index, 0, 1, "New_Series 1")
            series.getDataPoints().get_Item(0).getValue().setData(90)
            series.getDataPoints().get_Item(1).getValue().setData(123)
            series.getDataPoints().get_Item(2).getValue().setData(44)

            series = chart.getChartData().getSeries().get_Item(1)

            workbook.getCell(worksheet_index, 0, 2, "New_Series 2")
            series.getDataPoints().get_Item(0).getValue().setData(23)
            series.getDataPoints().get_Item(1).getValue().setData(67)
            series.getDataPoints().get_Item(2).getValue().setData(99)

            series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
            series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

            value_cell = workbook.getCell(worksheet_index, 1, 3, 20)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 2, 3, 50)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 3, 3, 30)
            series.getDataPoints().addDataPointForBarSeries(value_cell)

            chart.setType(ChartType.ClusteredCylinder)

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट के लिये डेटा रेंज सेट करना**

किसी मौजूदा चार्ट द्वारा उपयोग की गई रेंज देखने के लिये देखें [Retrieve a Chart's Data Range](/slides/hi/python-java/chart-workbook/#retrieve-a-charts-data-range)।

Aspose.Slides for Python via Java आपको वर्कशीट के किसी भाग को चार्ट के डेटा स्रोत के रूप में परिभाषित करने की लचीलापन देता है। इसका अर्थ है कि आप सीधे वर्कशीट के किसी भाग को चार्ट से मैप कर सकते हैं, जिससे आप तय कर सकते हैं कि कौन‑से सेल्स श्रृंखला और श्रेणियों में योगदान देंगे। इस प्रकार आप अपने चार्ट को नवीनतम डेटा परिवर्तन के साथ आसानी से अपडेट और सिंक्रनाइज़ कर सकते हैं, जिससे PowerPoint प्रस्तुतियों में वर्तमान और सटीक जानकारी बनी रहती है।

यह उदाहरण [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) का उपयोग करके पहले स्लाइड पर "My chart" नामक चार्ट के डेटा स्रोत को `Sheet1!A1:B4` पर सेट करता है। चार्ट वर्कबुक में वह शीट और एक पॉप्युलेटेड रेंज होना चाहिए, जहाँ पहली पंक्ति में श्रृंखला हेडिंग, कॉलम A में श्रेणी लेबल और कॉलम B में तीन मान हों।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट में डिफ़ॉल्ट मार्कर उपयोग करना**

जब आप चार्ट में डिफ़ॉल्ट मार्कर उपयोग करते हैं, तो प्रत्येक श्रृंखला को स्वचालित रूप से एक अलग डिफ़ॉल्ट मार्कर प्रतीक मिलता है।

यह उदाहरण [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) का उपयोग करके दो लाइन श्रृंखलाओं और लेजेंड के साथ चार्ट बनाता है। [getMarker](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getMarker) के माध्यम से एक्सेस किए गए मार्कर सेटिंग्स स्वचालित असाइन किए गए मार्कर प्रतीकों को बरकरार रखते हैं। पहली श्रृंखला में एक नकारात्मक मान और एक गायब मान (`None`) है, जबकि दूसरी में प्रत्येक श्रेणी के लिये मान है।

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

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    series_name_cell = workbook.getCell(0, 0, 2, "Series 2")
    second_series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides for Python via Java द्वारा समर्थित चार्ट प्रकार कौन‑से हैं?**

Aspose.Slides for Python via Java कई प्रकार के चार्ट का समर्थन करता है, जैसे बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार आदि। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट चुनने देता है।

**एक स्लाइड में नया चार्ट कैसे जोड़ें?**

चार्ट जोड़ने के लिये पहले आप [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने वाली मेथड को कॉल करते हैं, जिसमें चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में इंटीग्रेट करती है।

**चार्ट में प्रदर्शित डेटा को कैसे अपडेट करें?**

आप [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) तक पहुँचकर डिफ़ॉल्ट श्रृंखला और श्रेणियों को साफ़ कर सकते हैं, और फिर अपनी कस्टम डेटा जोड़ सकते हैं। इससे आप प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा के साथ रिफ्रेश कर सकते हैं।

**क्या चार्ट की उपस्थिति को अनुकूलित करना संभव है?**

हाँ, Aspose.Slides for Python via Java व्यापक अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य स्वरूपण तत्वों को अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार बदल सकते हैं।