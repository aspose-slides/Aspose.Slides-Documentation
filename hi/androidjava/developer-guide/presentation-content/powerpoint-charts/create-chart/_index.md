---
title: एंड्रॉइड पर PowerPoint प्रस्तुति चार्ट बनाएं या अपडेट करें
linktitle: चार्ट बनाएं या अपडेट करें
type: docs
weight: 10
url: /hi/androidjava/create-chart/
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
- मल्टी‑कैटेगोरी चार्ट
- PowerPoint
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और कस्टमाइज़ करें। Java में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **समग्र अवलोकन**

यह लेख Aspose.Slides for Android via Java का उपयोग करके चार्ट बनाने और कस्टमाइज़ करने के लिए व्यापक गाइड प्रदान करता है। आप सीखेंगे कि प्रोग्रामेटिक रूप से स्लाइड में चार्ट कैसे जोड़ा जाए, डेटा से भरें, और विभिन्न फ़ॉर्मेटिंग विकल्पों को आपके विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार कैसे लागू किया जाए। लेख केThroughout, विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को इनिशियलाइज़ करने से लेकर सीरीज़, एक्सिस और लेजेंड को कॉन्फ़िगर करने तक। इस गाइड का पालन करके, आप एन्ड्रॉइड अनुप्रयोगों में डायनामिक चार्ट जनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवन प्रस्तुतियों को बनाना सुगम हो जाएगा।

## **चार्ट बनाएं**

चार्ट लोगों को डेटा को जल्दी से विज़ुअलाइज़ करने और ऐसे अंतर्दृष्टि प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं होते।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप:

* एक ही स्लाइड में बड़ी मात्रा में डेटा को समेकित, संक्षिप्त या सारांशित कर सकते हैं;
* डेटा में पैटर्न और ट्रेंड को उजागर कर सकते हैं;
* समय के साथ या किसी विशिष्ट मापन इकाई के संदर्भ में डेटा की दिशा और गति का अनुमान लगा सकते हैं;
* अपवर्जन, विचलन, त्रुटियाँ और असंगत डेटा को पहचान सकते हैं;
* जटिल डेटा को संप्रेषित या प्रस्तुत कर सकते हैं।

PowerPoint में, आप *Insert* फ़ंक्शन के माध्यम से कई प्रकार के चार्ट टेम्पलेट का उपयोग करके चार्ट बना सकते हैं। Aspose.Slides के साथ, आप सामान्य चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" title="Note" %}}
Use the [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) enumeration in the [com.aspose.slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/) package. The values in this enumeration correspond to different chart types.
{{% /alert %}}

### **समूहीकृत कॉलम चार्ट बनाएं**

यह उदाहरण [addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) का उपयोग करके एक समूहीकृत कॉलम चार्ट बनाता है जो तीन श्रेणियों में दो सीरीज़ की तुलना करता है। सीरीज़ लाल और हरे फ़िल का उपयोग करती हैं, और व्यक्तिगत लेबल श्रेणी नाम, सीरीज़ नाम और मान दिखाते हैं। वर्कशीट इंडेक्स 0 एम्बेडेड चार्ट वर्कबुक में पहले शीट को दर्शाता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartDataCell categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    series = chart.getChartData().getSeries().get_Item(1);

    valueCell = workbook.getCell(worksheetIndex, 1, 2, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.rgb(0, 128, 0));

    IDataLabel label = series.getDataPoints().get_Item(0).getLabel();
    label.getDataLabelFormat().setShowCategoryName(true);

    label = series.getDataPoints().get_Item(1).getLabel();
    label.getDataLabelFormat().setShowSeriesName(true);

    label = series.getDataPoints().get_Item(2).getLabel();
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setShowSeriesName(true);
    label.getDataLabelFormat().setSeparator("/");

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![समूहीकृत कॉलम चार्ट](clustered_column_chart.png)

### **स्कैटर चार्ट बनाएं**

स्कैटर चार्ट (जिसे स्कैटर प्लॉट या x‑y ग्राफ़ भी कहा जाता है) अक्सर दो चर के बीच पैटर्न या सहसंबंध जांचने के लिए उपयोग किए जाते हैं।

आप स्कैटर चार्ट का उपयोग तब करें जब:

* आपके पास संख्यात्मक युग्मित डेटा हो;
* दो चर आपस में ठीक से जुड़े हों;
* आप निर्धारित करना चाहते हों कि दोनों चर संबंधित हैं या नहीं;
* आपके पास एक स्वतंत्र चर हो जिसके कई मान निर्भरचर के लिए हों।

यह उदाहरण दो सेट x‑y मान प्लॉट करता है। पहली सीरीज़ में स्टार मार्कर के साथ सीधी रेखाएँ हैं, जबकि दूसरी में सर्कल मार्कर के साथ स्मूद रेखाएँ हैं; दोनों में मार्कर आकार 10 है, जिसे [setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imarker/#setSize-int-) से कॉन्फ़िगर किया गया है। [setSymbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imarker/#setSymbol-int-) मेथड मार्कर आकार को नियंत्रित करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 1, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 1, 3, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IChartDataCell xValueCell = workbook.getCell(worksheetIndex, 2, 1, 1);
    IChartDataCell yValueCell = workbook.getCell(worksheetIndex, 2, 2, 3);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 1, 2);
    yValueCell = workbook.getCell(worksheetIndex, 3, 2, 10);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);

    series = chart.getChartData().getSeries().get_Item(1);

    xValueCell = workbook.getCell(worksheetIndex, 2, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 2, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 3, 3);
    yValueCell = workbook.getCell(worksheetIndex, 3, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 4, 3, 2);
    yValueCell = workbook.getCell(worksheetIndex, 4, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 5, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 5, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![स्कैटर चार्ट](scatter_chart.png)

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेषकर जब डेटा में श्रेणी लेबल के साथ संख्यात्मक मान हों। हालांकि, यदि आपके डेटा में कई भाग या लेबल हों, तो बार चार्ट का उपयोग करने पर विचार करें।

यह उदाहरण तीन त्रैमासिक मानों के साथ पाई चार्ट बनाता है। प्रत्येक स्लाइस का कस्टम फ़िल और बॉर्डर है, और लेबल विभिन्न संयोजन (मान, प्रतिशत, सीरीज़ जानकारी) दिखाते हैं। [setFirstSliceAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setFirstSliceAngle-int-) मेथड पहला स्लाइस 180 डिग्री से शुरू करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataCell categoryCell = workbook.getCell(0, 1, 0, "1st Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "2nd Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "3rd Qtr");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForPieSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);

    IChartDataPoint firstSlice = series.getDataPoints().get_Item(0);
    firstSlice.getFormat().getFill().setFillType(FillType.Solid);
    firstSlice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);

    firstSlice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    firstSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(128, 128, 128));
    firstSlice.getFormat().getLine().setWidth(3.0);
    firstSlice.getFormat().getLine().setStyle(LineStyle.ThinThick);
    firstSlice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash);

    IChartDataPoint secondSlice = series.getDataPoints().get_Item(1);
    secondSlice.getFormat().getFill().setFillType(FillType.Solid);
    secondSlice.getFormat().getFill().getSolidFillColor().setColor(Color.rgb(165, 42, 42));

    secondSlice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    secondSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    secondSlice.getFormat().getLine().setWidth(3.0);
    secondSlice.getFormat().getLine().setStyle(LineStyle.Single);
    secondSlice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);

    IChartDataPoint thirdSlice = series.getDataPoints().get_Item(2);
    thirdSlice.getFormat().getFill().setFillType(FillType.Solid);
    thirdSlice.getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 127, 80));

    thirdSlice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    thirdSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    thirdSlice.getFormat().getLine().setWidth(2.0);
    thirdSlice.getFormat().getLine().setStyle(LineStyle.ThinThin);
    thirdSlice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);

    IDataLabel firstLabel = series.getDataPoints().get_Item(0).getLabel();
    firstLabel.getDataLabelFormat().setShowValue(true);

    IDataLabel secondLabel = series.getDataPoints().get_Item(1).getLabel();
    secondLabel.getDataLabelFormat().setShowValue(true);
    secondLabel.getDataLabelFormat().setShowLegendKey(true);
    secondLabel.getDataLabelFormat().setShowPercentage(true);

    IDataLabel thirdLabel = series.getDataPoints().get_Item(2).getLabel();
    thirdLabel.getDataLabelFormat().setShowSeriesName(true);
    thirdLabel.getDataLabelFormat().setShowPercentage(true);

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);

    presentation.save("PieChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![पाई चार्ट](pie_chart.png)

लेबल की पठनीयता सुधारने के लिए, बाहर के पाई लेबल के लिए [फ़ॉर्मेट लीडर लाइन्स](/slides/hi/androidjava/chart-data-label/#format-leader-lines) देखें, जहाँ आप लेबल की स्थिति और लाइन के रंग, चौड़ाई, पारदर्शिता तथा डैश स्टाइल को कस्टमाइज़ कर सकते हैं।

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिसे लाइन ग्राफ़ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मान में परिवर्तन दिखाना चाहते हैं। लाइन चार्ट के साथ आप बड़ी मात्रा में डेटा की एक साथ तुलना, परिवर्तन एवं ट्रेंड ट्रैक, तथा डेटा सीरीज़ में विसंगतियों को उजागर कर सकते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) का उपयोग करके डिफ़ॉल्ट सीरीज़ और श्रेणियों के साथ लाइन चार्ट बनाता है, फिर प्रस्तुति को PPTX के रूप में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart lineChart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300);

    presentation.save("lineChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, लाइन चार्ट में बिंदु सीधी निरंतर रेखाओं से जुड़े होते हैं। यदि आप बिंदुओं को डैश वाले रेखा से जोड़ना चाहते हैं, तो [setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) को [LineDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) से किसी मान के साथ कॉल करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart lineChart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![लाइन चार्ट](line_chart.png)

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट बिक्री डेटा के लिए सबसे उपयुक्त होते हैं जब आप डेटा श्रेणियों के सापेक्ष आकार दिखाना चाहते हैं और प्रत्येक श्रेणी के बड़े योगदानकर्ताओं पर जल्दी ध्यान आकर्षित करना चाहते हैं।

यह उदाहरण आठ लीव्स को चार स्टेम और दो ब्रांच में समूहित करके ट्री मैप बनाता है। [setGroupingItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) मेथड स्तर 1 पर स्टेम और स्तर 2 पर ब्रांच असाइन करता है। मान सापेक्ष आयत आकार निर्धारित करते हैं, जबकि श्रेणी लेबल और ओवरलैपिंग पैरेंट लेबल पदानुक्रम को दर्शाते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // ब्रांच 1
    IChartDataCell categoryCell = workbook.getCell(0, "C1", "Leaf1");
    IChartCategory leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // ब्रांच 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    IChartDataCell valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    presentation.save("Treemap.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![ट्रीमैप चार्ट](treemap_chart.png)

### **वॉटरफ़ॉल चार्ट बनाएं**

वॉटरफ़ॉल चार्ट दिखाते हैं कि सकारात्मक और नकारात्मक परिवर्तन अंतिम मान में कैसे योगदान देते हैं। उदाहरण के तौर पर, लाभ विश्लेषण में राजस्व से लागत घटा कर शुद्ध लाभ प्राप्त किया जाता है। परिवर्तन कॉलम पिछले और नए चल रहे मानों के बीच फ़्लोट करते हैं, जबकि कुल कॉलम शून्य से संचित मान तक विस्तृत होते हैं।

निम्नलिखित उदाहरण हजारों अमेरिकी डॉलर में राशि का उपयोग करता है:

| श्रेणी | वर्कबुक मान | कॉलम प्रकार |
| --- | ---: | --- |
| राजस्व | 1000 | वृद्धि |
| बिक्री लागत | -400 | घटाव |
| सकल लाभ | 600 | मध्यवर्ती कुल |
| संचालन खर्च | -200 | घटाव |
| अन्य आय | 50 | वृद्धि |
| शुद्ध लाभ | 450 | अंतिम कुल |

किसी बिंदु को मध्यवर्ती या अंतिम कुल के रूप में चिह्नित करने के लिए, उसके [setSetAsTotal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdatapoint/#setSetAsTotal-boolean-) मेथड को `true` के साथ कॉल करें। उस बिंदु की वर्कबुक सेल में वास्तविक संचित राशि प्रदान करें: सकल लाभ के लिए `600` (`1000 - 400`) और शुद्ध लाभ के लिए `450` (`600 - 200 + 50`)। यह मेथड कॉलम को कुल के रूप में चिह्नित करता है; यह सेल मान की गणना या पूर्ति नहीं करता। शून्य को प्लेसहोल्डर के रूप में उपयोग न करें और कुल बिंदु के लिए कोई अन्य परिवर्तन न दें। कुल कॉलम संचित मान को दिखाता है बिना उसे फिर से चल रहे मान में जोड़ें।

यह पूर्ण Java उदाहरण `Waterfall` सदस्य का उपयोग करके [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) से चार्ट बनाता है, डिफ़ॉल्ट डेटा साफ़ करता है, और एम्बेडेड वर्कबुक को भरता है। वर्कशीट इंडेक्स `0` पहली शीट चुनता है; कॉलम A में श्रेणी नाम और कॉलम B में मान होते हैं। प्रत्येक मान सेल को [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#addDataPointForWaterfallSeries-com.aspose.slides.IChartDataCell-) से जोड़ा जाता है। शून्य‑आधारित बिंदु सूचकांक `2` और `5` क्रमशः मध्यवर्ती और अंतिम कुल दर्शाते हैं। [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) को `true` पर सेट करने से मान कॉलम पर दिखते हैं। इनपुट प्रस्तुति या वर्कबुक की आवश्यकता नहीं है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)");
    chart.getChartTitle().setOverlay(false);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    workbook.clear(worksheetIndex);

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Profit");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Waterfall);
    String[] categories = new String[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
    double[] values = new double[] { 1000, -400, 600, -200, 50, 450 };

    for (int i = 0; i < categories.length; i++)
    {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categories[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForWaterfallSeries(valueCell);
    }

    // तीसरे और छठे बिंदु कुल दर्शाते हैं, अतिरिक्त परिवर्तन नहीं।
    series.getDataPoints().get_Item(2).setSetAsTotal(true);
    series.getDataPoints().get_Item(5).setSetAsTotal(true);
    series.setShowConnectorLines(true);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

सीरीज़‑लेवल पर [setShowConnectorLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartseries/#setShowConnectorLines-boolean-) को `true` करने से क्रमिक कॉलम को जोड़ने वाली रेखाएँ दिखती हैं और चल रहा मान आसान से ट्रैक होता है। इन रेखाओं को छिपाने के लिए, उदाहरण में मेथड कॉल को `series.setShowConnectorLines(false);` से बदलें और फिर सहेजें। यह केवल रेखा की दृश्यता बदलता है, न कि डेटा या कुल को।

सहेजी गई प्रस्तुति में सकल लाभ 600 और शुद्ध लाभ 450 दिखता है, दोनों कुल शून्य से शुरू होते हैं:

![वॉटरफ़ॉल चार्ट जिसमें राजस्व, लागत, 600 का सकल लाभ और 450 का शुद्ध लाभ दिखाया गया है, साथ में मान लेबल और कनेक्टर लाइनें](waterfall_chart.png)

### **स्टॉक चार्ट बनाएं**

स्टॉक चार्ट वित्तीय डेटा जैसे ओपन, हाई, लो और क्लोज कीमतें दिखाने के लिए उपयोग किए जाते हैं, जिससे बाजार ट्रेंड और अस्थिरता का विश्लेषण किया जा सके। ये स्टॉक प्रदर्शन के प्रमुख अंतर्दृष्टि प्रदान करते हैं, जिससे निवेशकों और विश्लेषकों को सूचित निर्णय लेने में मदद मिलती है।

यह उदाहरण चार श्रृंखला के साथ ओपन‑हाई‑लो‑क्लोज़ चार्ट बनाता है, क्रमशः चार श्रेणियाँ बनाते हुए। [setUpDownBars](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iupdownbarsmanager/#setUpDownBars-boolean-) मेथड अप/डाउन बार सक्षम करता है, और [getHiLowLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getHiLowLinesFormat--) हाई‑लो रेखाओं को नियंत्रित करता है, जबकि व्यक्तिगत श्रृंखला रेखाएँ और छोटे क्षैतिज ग्रिडलाइन छिपे होते हैं।

[getUpDownBars](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getUpDownBars--) द्वारा लौटाया गया मैनेजर [getUpBarsFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iupdownbarsmanager/#getUpBarsFormat--) और [getDownBarsFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iupdownbarsmanager/#getDownBarsFormat--) के माध्यम से अलग‑अलग फ़ॉर्मेटिंग ऑब्जेक्ट प्रदान करता है। प्रत्येक ऑब्जेक्ट की [getFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformat/#getFill--) और [getLine](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformat/#getLine--) मेथड से फ़िल और आउटलाइन स्वतंत्र रूप से सेट की जा सकती हैं। इस उदाहरण में बढ़ते अंतराल के लिए हरे बार और गहरे‑हरे आउटलाइन, तथा गिरते अंतराल के लिए नारंगी‑लाल बार और गहरे‑लाल आउटलाइन उपयोग किए गए हैं।

प्रत्येक श्रेणी में सभी चार श्रृंखलाओं के लिए संख्यात्मक मान प्रदान करें, जहाँ हाई और लो ओपन और क्लोज़ को घेरते हैं। बार एक ही श्रेणी के भीतर क्लोज़ को ओपन से तुलना करते हैं, न कि पिछले श्रेणी से: A 72 से 25 तक घटता है, जबकि B 25 से 38 तक बढ़ता है और C 38 से 50 तक बढ़ता है। समान ओपन और क्लोज़ मान कोई दृश्यमान भराव अंतराल नहीं बनाते। अप/डाउन बार ओपन‑से‑क्लोज़ को घेरते हैं; हाई‑लो रेखाएँ लो‑से‑हाई को घेरती हैं। ये बार श्रृंखला‑ग्रुप का हिस्सा हैं, सामान्य बार‑चार्ट श्रृंखला नहीं।

यह फ़ॉर्मेटिंग कम से कम दो श्रृंखला वाले [Line और LineWithMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) चार्ट पर भी काम करती है, जहाँ प्रत्येक श्रेणी के लिए संख्यात्मक मान मौजूद होते हैं। इन नॉन‑स्टैक्ड लाइन्ड चार्ट में, अप/डाउन बार पहली और अंतिम श्रृंखला की तुलना करते हैं: उच्च अंतिम मान अप‑बार देता है, और निचला अंतिम मान डाउन‑बार देता है। श्रृंखला क्रम बदलने से वर्गीकरण उलट जाता है। नीचे का उदाहरण [OpenHighLowClose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) का उपयोग करता है; यह मानना न चाहिए कि अन्य स्टॉक, स्टैक्ड‑लाइन या 3D वेरिएंट समान डेटा व्यवस्था या अंतराल व्याख्या का उपयोग करते हैं।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell categoryCell = workbook.getCell(0, 1, 0, "A");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "B");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "C");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Open");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 2, "High");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 3, "Low");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 4, "Close");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataCell valueCell = workbook.getCell(0, 1, 1, 72);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 1, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 1, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(1);
    valueCell = workbook.getCell(0, 1, 2, 172);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(2);
    valueCell = workbook.getCell(0, 1, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 3, 13);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(3);
    valueCell = workbook.getCell(0, 1, 4, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 4, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 4, 50);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    IUpDownBarsManager upDownBars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars();
    upDownBars.setUpDownBars(true);

    upDownBars.getUpBarsFormat().getFill().setFillType(FillType.Solid);
    upDownBars.getUpBarsFormat().getFill().getSolidFillColor().setColor(Color.rgb(50, 205, 50));
    upDownBars.getUpBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    upDownBars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 100, 0));
    upDownBars.getUpBarsFormat().getLine().setWidth(2);

    upDownBars.getDownBarsFormat().getFill().setFillType(FillType.Solid);
    upDownBars.getDownBarsFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 69, 0));
    upDownBars.getDownBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    upDownBars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    upDownBars.getDownBarsFormat().getLine().setWidth(2);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries stockSeries : chart.getChartData().getSeries())
    {
        stockSeries.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम, PowerPoint से निर्यात किया गया:

![स्टॉक चार्ट जिसमें A के लिए गिरता हुआ नारंगी‑लाल अंतराल और B तथा C के लिए बढ़ता हुआ हरा अंतराल दिखाया गया है](stock_chart.png)

### **बॉक्स एंड व्हिस्कर चार्ट बनाएं**

बॉक्स एंड व्हिस्कर चार्ट डेटा के वितरण को मुख्य सांख्यिकीय माप (मेडियन, क्वार्टाइल, संभावित अपवर्जन) को संक्षेपित करके प्रदर्शित करते हैं। ये विशेष रूप से अन्वेषी डेटा विश्लेषण और सांख्यिकीय अध्ययनों में डेटा परिवर्तनशीलता को जल्दी समझने और किसी भी विसंगति की पहचान करने में उपयोगी होते हैं।

यह उदाहरण छह मानों से बॉक्स एंड व्हिस्कर चार्ट बनाता है। [setQuartileMethod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setQuartileMethod-int-) मेथड एक्सक्लूसिव क्वार्टाइल गणना चुनता है। उदाहरण में औसत रेखाएं, औसत मार्कर, आंतरिक बिंदु और अपवर्जन बिंदु भी सक्षम किए गए हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    IChartDataCell valueCell = workbook.getCell(0, "B1", 15);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 41);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 10);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 23);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

### **फ़नल चार्ट बनाएं**

फ़नल चार्ट उन प्रक्रियाओं को विज़ुअलाइज़ करने के लिए उपयोग किए जाते हैं जिनमें क्रमिक चरण होते हैं, जहाँ डेटा की मात्रा प्रत्येक चरण में घटती जाती है। ये रूपांतरण दरों का विश्लेषण करने, बाधाओं की पहचान करने और बिक्री या मार्केटिंग प्रक्रिया की दक्षता को ट्रैक करने में विशेष रूप से मददगार होते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में [addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) का उपयोग करके फ़नल चार्ट जोड़ता है। यह डिफ़ॉल्ट डेटा को छह श्रेणियों और 50 से 500 तक के मानों से बदलता है, फिर अपडेटेड प्रस्तुति को सहेजता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होना आवश्यक है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    IChartDataCell valueCell = workbook.getCell(0, "B1", 50);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 100);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 200);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 300);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 400);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 500);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);

    presentation.save("Funnel.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![फ़नल चार्ट](funnel_chart.png)

### **सनबर्स्ट चार्ट बनाएं**

सनबर्स्ट चार्ट पद‑से‑सम्पूर्ण संबंधों को दर्शाते हुए पदानुक्रमिक डेटा को एकाधिक समकेंद्रित वलयों में प्रदर्शित करते हैं। ये नेस्टेड श्रेणियों और उप‑श्रेणियों को स्पष्ट, कॉम्पैक्ट प्रारूप में दर्शाने के लिए आदर्श होते हैं।

यह उदाहरण आठ लीव्स को चार स्टेम और दो ब्रांच में समूहित करके सनबर्स्ट चार्ट बनाता है। [setGroupingItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) मेथड स्तर 1 पर स्टेम और स्तर 2 पर ब्रांच असाइन करता है। श्रेणी लेबल सेगमेंट की पहचान करता है, और मान उनके सापेक्ष आकार निर्धारित करते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // ब्रांच 1
    IChartDataCell categoryCell = workbook.getCell(0, "C1", "Leaf1");
    IChartCategory leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // ब्रांच 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    IChartDataCell valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);

    presentation.save("Sunburst.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![सनबर्स्ट चार्ट](sunburst_chart.png)

### **हिस्टोग्राम चार्ट बनाएं**

हिस्टोग्राम चार्ट दिखाते हैं कि संख्यात्मक मान अंतराल (बिन) में कैसे वितरित होते हैं। मासिक रिपोर्टों में ऑर्डर प्रोसेसिंग समय के लिए, समान बिन चौड़ाई और थ्रेशहोल्ड का उपयोग करके अंतराल समान रखें और वितरण की तुलना आसान बनाएं।

आड़िशीय एक्सिस पर [setAggregationType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAggregationType-int-) को [AxisAggregationType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axisaggregationtype/) के किसी मोड के साथ कॉल करें। [setBinWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setBinWidth-double-) केवल `ByBinWidth` के लिए लागू होता है; [setNumberOfBins](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberOfBins-long-) केवल `ByNumberOfBins` के लिए। `Automatic` सेट करने से चार्ट अपनी बिन चुनता है।

#### **स्थिर बिन चौड़ाई का उपयोग करें**

यह उदाहरण प्रोसेसिंग समय को 10‑मिनट अंतराल में समूहित करता है, जिसमें 10 मिनट या उससे कम तथा 40 मिनट से अधिक के लिए अलग बिन होते हैं। इन बिनों को [setUnderflowBin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setUnderflowBin-boolean-) और [setOverflowBin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setOverflowBin-boolean-) से सक्षम करें। जब आप स्पष्ट थ्रेशहोल्ड को [setUnderflowBin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setUnderflowBin-double-) और [setOverflowBin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setOverflowBin-double-) के साथ प्रदान करते हैं, तो [setAutomaticUnderflowBin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticUnderflowBin-boolean-) और [setAutomaticOverflowBin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticOverflowBin-boolean-) को `false` पर सेट करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
    for (int i = 0; i < values.length; i++)
    {
        IChartDataCell valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(AxisAggregationType.ByBinWidth);
    axis.setBinWidth(10);
    axis.setUnderflowBin(true);
    axis.setAutomaticUnderflowBin(false);
    axis.setUnderflowBin(10);
    axis.setOverflowBin(true);
    axis.setAutomaticOverflowBin(false);
    axis.setOverflowBin(40);

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

PowerPoint में प्रदर्शित प्रस्तुति में बिन गणना **3, 4, 4, 4, और 2** है। अंडरफ़्लो बिन में `5, 10, 10` शामिल हैं, इसलिए इसका थ्रेशहोल्ड शामिल है। ओवरफ़्लो बिन में केवल `41, 50` हैं, इसलिए इसका थ्रेशहोल्ड बहिष्कृत है; दोनों `40` बराबर मान पिछले अंतराल में रहते हैं। आंतरिक बिन अपने निचले सीमा से बड़े और ऊपर की सीमा तक ≤ होते हैं।

![10‑मिनट बिन और स्पष्ट अंडरफ़्लो व ओवरफ़्लो थ्रेशहोल्ड के साथ हिस्टोग्राम](histogram_bin_width.png)

#### **बिन की संख्या निर्दिष्ट करें**

स्थिर अंतराल के बजाय स्थिर विवरण स्तर चाहिए, तो समान डेटा के लिए पाँच बिन का अनुरोध करें। यह उदाहरण अंडरफ़्लो और ओवरफ़्लो बिन को निष्क्रिय रखता है। चार्ट डेटा रेंज से चौड़ाई निर्धारित करता है, इसलिए सीमा रिपोर्ट के बीच बदल सकती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
    for (int i = 0; i < values.length; i++)
    {
        IChartDataCell valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins);
    axis.setNumberOfBins(5);

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

पाँच बिन की गणना **4, 4, 4, 4, और 1** है। इसे ऊपर के स्थिर‑चौड़ाई परिणाम से तुलना करें: इनपुट मान समान हैं, लेकिन सीमाएँ अलग हैं।

![समान डेटा से गणना किए गए पाँच बिन वाला हिस्टोग्राम](histogram_bin_count.png)

### **रेडार चार्ट बनाएं**

रेडार चार्ट बहु‑चर डेटा को दो‑आयामी रूप में प्रदर्शित करते हैं, जिससे कई चर की एक साथ आसान तुलना संभव होती है। ये कई प्रदर्शन मीट्रिक या गुणों में पैटर्न, ताकत और कमजोरियों की पहचान करने में विशेष रूप से उपयोगी होते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) का उपयोग करके डिफ़ॉल्ट सीरीज़ और श्रेणियों के साथ रेडार चार्ट बनाता है, फिर प्रस्तुति को PPTX के रूप में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addChart(ChartType.Radar, 20, 20, 500, 300);

    presentation.save("Radar-chart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![रेडार चार्ट](radar_chart.png)

### **मल्टी‑कैटेगिरी चार्ट बनाएं**

मल्टी‑कैटेगिरी चार्ट उन डेटा को प्रदर्शित करने के लिए उपयोग होते हैं जिनमें एक से अधिक वर्गीकरण समूह शामिल होते हैं, जिससे कई आयामों में मानों की एक साथ तुलना संभव हो जाती है। ये जटिल, बहु‑स्तरीय डेटा सेट में ट्रेंड और संबंधों का विश्लेषण करने में विशेष रूप से मददगार होते हैं।

यह उदाहरण चार जोड़ी में व्यवस्थित आठ श्रेणियों के साथ समूहीकृत कॉलम चार्ट बनाता है। [setGroupingItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) मेथड प्रत्येक जोड़ी को स्तर 1 पर साझा लेबल देता है, जिससे व्यक्तिगत और समूह लेबल दोनों वाले श्रेणी एक्सिस बनता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    int worksheetIndex = 0;

    IChartDataCell categoryCell = workbook.getCell(0, "c2", "A");
    IChartCategory category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    categoryCell = workbook.getCell(0, "c3", "B");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c4", "C");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    categoryCell = workbook.getCell(0, "c5", "D");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c6", "E");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    categoryCell = workbook.getCell(0, "c7", "F");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c8", "G");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    categoryCell = workbook.getCell(0, "c9", "H");
    category = chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell seriesNameCell = workbook.getCell(0, "D1", "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    IChartDataCell valueCell = workbook.getCell(worksheetIndex, "D2", 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D3", 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D4", 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D5", 40);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D6", 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D7", 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D8", 70);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D9", 80);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![मल्टी कैटेगोरी चार्ट](multi_category_chart.png)

#### **एक क्वार्टर लेबल हटाएं**

[quarters.pptx](quarters.pptx) डाउनलोड करके कार्य निर्देशिका में रखें। इसका चार्ट नौ महीने और एकल बिक्री सीरीज़ 10‑18 मानों के साथ दिखाता है। श्रेणी एक्सिस पर Q1 जनवरी‑मार्च, Q2 अप्रैल‑जून, Q3 जुलाई‑सितंबर को कवर करता है।

अप्रैल चौथा वर्गीकरण (इंडेक्स 3) है और Q2 लेबल रखता है। [getGroupingLevels](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/#getGroupingLevels--) को कॉल करके अप्रैल के ग्रुपिंग लेवल प्राप्त करें, फिर स्तर 1 के साथ [deleteGroupingItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategorylevelsmanager/#deleteGroupingItem-int-) को कॉल करके उसका क्वार्टर लेबल हटाएं। स्तर 0 स्वयं महीना दर्शाता है और इस मेथड से हटाया नहीं जा सकता।

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;
import android.text.TextUtils;

Presentation presentation = new Presentation("quarters.pptx");
try {
    IChart chart = (IChart) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartCategory april = chart.getChartData().getCategories().get_Item(3);
    april.getGroupingLevels().deleteGroupingItem(1);

    presentation.save("quarters-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopened = new Presentation("quarters-updated.pptx");
try {
    IChart updatedChart = (IChart) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = updatedChart.getChartData();
    
    List<String> months = new ArrayList<>();
    for (IChartCategory month : data.getCategories()) {
        months.add(String.valueOf(month.getAsCell().getValue()));
    }
    List<String> sales = new ArrayList<>();
    for (IChartDataPoint point : data.getSeries().get_Item(0).getDataPoints()) {
        sales.add(String.valueOf(point.getValue().getData()));
    }
    System.out.println(TextUtils.join(", ", months));
    System.out.println(TextUtils.join(", ", sales));
} finally {
    reopened.dispose();
}
```

चार्ट पुनः खोलने के बाद, उदाहरण मूल महीनों (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) और बिक्री मान (`10, 11, 12, 13, 14, 15, 16, 17, 18`) को उसी क्रम में प्रिंट करता है। PowerPoint में `quarters-updated.pptx` खोलकर अक्ष लेबल तुलना करें। Q2 लेबल और अप्रैल से पहले का समूह सीमा हट जाता है, इसलिए Q1 जनवरी‑जून तक विस्तारित हो जाता है। Q3 अभी भी जुलाई से शुरू होता है।

![लेबल हटाने से पहले और बाद में क्वार्टर लेबल। बाएँ पर Q2 अप्रैल‑जून को कवर करता है। दाएँ पर Q1 जनवरी‑जून को कवर करता है।](quarter-label-comparison.png)

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को विशिष्ट स्थानों (देश, राज्य, शहर) से जोड़कर विज़ुअलाइज़ करने के लिए उपयोग होते हैं। ये क्षेत्रीय ट्रेंड, जनसांख्यिकीय डेटा और स्थानीय वितरण को स्पष्ट, आकर्षक रूप में विश्लेषित करने में मदद करते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) का उपयोग करके डिफ़ॉल्ट भू‑डेटा के साथ मैप चार्ट बनाता है और PowerPoint में देखने के लिए सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300);

    presentation.save("mapChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

परिणाम:

![मैप चार्ट](map_chart.png)

{{% alert color="info" title="Note" %}}
ऊपर की तस्वीर में सहेजी गई प्रस्तुति PowerPoint में खोली गई है। Aspose.Slides मैप चार्ट और उसके डेटा को सही ढंग से लिखता है, लेकिन स्वयं मैप चार्ट नहीं बनाता: जब कोई स्लाइड जिसमें मैप चार्ट हो, को इमेज में रेंडर किया जाता है या PDF या SVG में परिवर्तित किया जाता है, तो चार्ट क्षेत्र खाली रहता है। उसी स्लाइड पर अन्य शेमिंग अप्रभावित रहती हैं।
{{% /alert %}}

### **कॉम्बिनेशन चार्ट बनाएं**

कॉम्बिनेशन (या कॉम्बो) चार्ट एक ही ग्राफ़ में दो या अधिक चार्ट प्रकारों को जोड़ता है। यह चार्ट आपको दो या अधिक डेटा सेट के बीच अंतर को उजागर, तुलना या परीक्षण करने की अनुमति देता है, जिससे उनके बीच संबंधों की पहचान आसान होती है।

![कॉम्बिनेशन चार्ट](combination_chart.png)

यह उदाहरण चार श्रेणियों में दो समूहीकृत कॉलम सीरीज़ को एक लाइन सीरीज़ के साथ जोड़ता है। कॉलम प्राथमिक वर्टिकल एक्सिस का उपयोग करते हैं, जबकि [setPlotOnSecondAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setPlotOnSecondAxis-boolean-) लाइन को दाईं ओर द्वितीय वैर्टिकल एक्सिस पर रखता है। सहायक फ़ंक्शन शीर्षक, लेजेंड, एक्सिस लेबल और ग्रिडलाइन को कॉन्फ़िगर करते हैं।

```java
import com.aspose.slides.*;
import android.graphics.Color;

class ComboChartExample
{
    void createComboChart()
    {
        Presentation presentation = new Presentation();
        try
        {
            IChart chart = createChartWithFirstSeries(presentation.getSlides().get_Item(0));

            addSecondSeriesToChart(chart);
            addThirdSeriesToChart(chart);

            setPrimaryAxesFormat(chart);
            setSecondaryAxesFormat(chart);

            presentation.save("combo-chart.pptx", SaveFormat.Pptx);
        }
        finally
        {
            presentation.dispose();
        }
    }

    IChart createChartWithFirstSeries(ISlide slide)
    {
        IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

        chart.setTitle(true);
        chart.getChartTitle().addTextFrameForOverriding("Chart Title");
        chart.getChartTitle().setOverlay(false);
        IPortionFormat portionFormat = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
        portionFormat.setFontBold(NullableBool.False);
        portionFormat.setFontHeight(18f);

        chart.getLegend().setPosition(LegendPositionType.Bottom);
        chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

        chart.getChartData().getSeries().clear();
        chart.getChartData().getCategories().clear();

        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        int worksheetIndex = 0;

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
        chart.getChartData().getCategories().add(categoryCell);
        categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
        chart.getChartData().getCategories().add(categoryCell);
        categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
        chart.getChartData().getCategories().add(categoryCell);
        categoryCell = workbook.getCell(worksheetIndex, 4, 0, "Category 4");
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
        IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

        series.getParentSeriesGroup().setOverlap((byte) -25);
        series.getParentSeriesGroup().setGapWidth(220);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 1, 4.3);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 2, 1, 2.5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 3, 1, 3.5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 4, 1, 4.5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);

        return chart;
    }

    void addSecondSeriesToChart(IChart chart)
    {
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        final int worksheetIndex = 0;

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
        IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

        series.getParentSeriesGroup().setOverlap((byte) -25);
        series.getParentSeriesGroup().setGapWidth(220);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 2, 2.4);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 2, 2, 4.4);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 3, 2, 1.8);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 4, 2, 2.8);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    void addThirdSeriesToChart(IChart chart)
    {
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        final int worksheetIndex = 0;

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
        IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 3, 2.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 2, 3, 2.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 3, 3, 3.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 4, 3, 5.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);

        series.setPlotOnSecondAxis(true);
    }

    void setPrimaryAxesFormat(IChart chart)
    {
        IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
        horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
        horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        setAxisTitle(horizontalAxis, "X Axis");

        IAxis verticalAxis = chart.getAxes().getVerticalAxis();
        verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
        verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        setAxisTitle(verticalAxis, "Y Axis 1");

        ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
        majorGridLinesFormat.setFillType(FillType.Solid);
        majorGridLinesFormat.getSolidFillColor().setColor(Color.rgb(217, 217, 217));
    }

    void setSecondaryAxesFormat(IChart chart)
    {
        IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
        secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
        secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
        secondaryHorizontalAxis.setVisible(false);
        secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
        secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
        secondaryVerticalAxis.setPosition(AxisPositionType.Right);
        secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
        secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
        secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
        secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
    }

    void setAxisTitle(IAxis axis, String axisTitle)
    {
        axis.setTitle(true);
        axis.getTitle().setOverlay(false);
        IPortionFormat titlePortionFormat = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
        titlePortionFormat.setFontBold(NullableBool.False);
        titlePortionFormat.setFontHeight(12f);
    }
}

ComboChartExample example = new ComboChartExample();
example.createComboChart();
```

## **Charts को अपडेट करें**

Aspose.Slides for Android via Java आपको PowerPoint चार्ट को डेटा, फ़ॉर्मेटिंग और स्टाइलिंग को संशोधित करके अपडेट करने की सुविधा देता है। यह कार्यक्षमता गतिशील सामग्री के साथ प्रस्तुतियों को अद्यतन रखने की प्रक्रिया को सरल बनाती है और सुनिश्चित करती है कि चार्ट वर्तमान डेटा और दृश्य मानकों को सही ढंग से प्रतिबिंबित करें।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में "My chart" नामक चार्ट को अपडेट करता है। इसमें प्रत्येक में तीन डेटा पॉइंट वाली दो कॉलम सीरीज़ की आवश्यकता है, जहाँ श्रेणी लेबल कॉलम A में और सीरीज़ नाम पहली पंक्ति के पहले वर्कशीट में हैं। उदाहरण [getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-java.lang.Object-) का उपयोग करके वर्कबुक सेल बदलता है, सीरीज़ मान अपडेट करता है, तीसरी सीरीज़ जोड़ता है, और [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setType-int-) से चार्ट को समूहीकृत सिलेंडर में बदलता है।

```java
import com.aspose.slides.*;

final String chartName = "My chart";

Presentation presentation = new Presentation("ExistingChart.pptx");
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes())
    {
        if (shape instanceof IChart && chartName.equals(shape.getName()))
        {
            IChart chart = (IChart) shape;
            int worksheetIndex = 0;

            IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

            workbook.getCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.getCell(worksheetIndex, 2, 0, "Modified Category 2");

            IChartSeries series = chart.getChartData().getSeries().get_Item(0);

            workbook.getCell(worksheetIndex, 0, 1, "New_Series 1");
            series.getDataPoints().get_Item(0).getValue().setData(90);
            series.getDataPoints().get_Item(1).getValue().setData(123);
            series.getDataPoints().get_Item(2).getValue().setData(44);

            series = chart.getChartData().getSeries().get_Item(1);

            workbook.getCell(worksheetIndex, 0, 2, "New_Series 2");
            series.getDataPoints().get_Item(0).getValue().setData(23);
            series.getDataPoints().get_Item(1).getValue().setData(67);
            series.getDataPoints().get_Item(2).getValue().setData(99);

            IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
            series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

            IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 3, 20);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 2, 3, 50);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 3, 3, 30);
            series.getDataPoints().addDataPointForBarSeries(valueCell);

            chart.setType(ChartType.ClusteredCylinder);
        }
    }

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **चार्ट के लिए डेटा रेंज सेट करें**

मौजूदा चार्ट द्वारा पहले उपयोग किए गए रेंज को देखने के लिए, देखें [Retrieve a Chart's Data Range](/slides/hi/androidjava/chart-workbook/#retrieve-a-charts-data-range)।

Aspose.Slides for Android via Java आपको वर्कशीट से विशिष्ट डेटा रेंज को चार्ट डेटा स्रोत के रूप में परिभाषित करने की लचीलापन प्रदान करता है। इसका अर्थ है कि आप सीधे वर्कशीट के एक भाग को चार्ट से मैप कर सकते हैं, जिससे आप तय कर सकते हैं कि कौन‑से सेल्स चार्ट की सीरीज़ और श्रेणियों में योगदान देंगे। परिणामस्वरूप, आप अपने चार्ट को नवीनतम डेटा परिवर्तन के साथ आसानी से अपडेट और सिंक्रनाइज़ कर सकते हैं, जिससे आपके PowerPoint प्रस्तुतियों में वर्तमान और सटीक जानकारी बनी रहे।

यह उदाहरण [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करके मौजूदा प्रस्तुति की पहली स्लाइड में "My chart" नामक चार्ट का डेटा स्रोत `Sheet1!A1:B4` पर सेट करता है। चार्ट वर्कबुक में वह शीट और एक भरा हुआ रेंज होना चाहिए, जिसमें पहली पंक्ति में सीरीज़ हेडिंग, कॉलम A में श्रेणी लेबल और कॉलम B में तीन मान हों।

```java
import com.aspose.slides.*;

final String chartName = "My chart";

Presentation presentation = new Presentation("ExistingChart.pptx");
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes())
    {
        if (shape instanceof IChart && chartName.equals(shape.getName()))
        {
            IChart chart = (IChart) shape;
            chart.getChartData().setRange("Sheet1!A1:B4");
        }
    }

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करें**

जब आप चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से अलग‑अलग डिफ़ॉल्ट मार्कर प्रतीक मिलते हैं।

यह उदाहरण [addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) का उपयोग करके दो लाइन सीरीज़ और एक लेजेंड वाला चार्ट बनाता है। [getMarker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getMarker--) के माध्यम से प्राप्त मार्कर सेटिंग्स स्वचालित रूप से असाइन किए गए मार्कर प्रतीकों को बरकरार रखती हैं। पहली सीरीज़ में एक नकारात्मक मान और एक अनुपलब्ध मान (`null`) है, जबकि दूसरी में प्रत्येक श्रेणी के लिए मान है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartDataCell categoryCell = workbook.getCell(0, 1, 0, "C1");
    chart.getChartData().getCategories().add(categoryCell);
    IChartDataCell valueCell = workbook.getCell(0, 1, 1, 24);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 2, 0, "C2");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 2, 1, 23);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 3, 0, "C3");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 3, 1, -10);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 4, 0, "C4");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 4, 1, null);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    seriesNameCell = workbook.getCell(0, 0, 2, "Series 2");
    IChartSeries secondSeries = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    valueCell = workbook.getCell(0, 1, 2, 30);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 10);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 60);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 4, 2, 40);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides for Android via Java द्वारा कौन‑से चार्ट प्रकार समर्थित हैं?**

Aspose.Slides for Android via Java कई प्रकार के चार्ट समर्थन करता है, जिनमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार और कई अन्य शामिल हैं। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन आवश्यकताओं के लिए सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**मैं स्लाइड में नया चार्ट कैसे जोड़ूं?**

एक चार्ट जोड़ने के लिए, पहले आप [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने की मेथड को कॉल करते हैं, जिसमें चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट होते हैं। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में एकीकृत करती है।

**मैं चार्ट में प्रदर्शित डेटा को कैसे अपडेट करूं?**

आप चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)) तक पहुँचकर, किसी भी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करके, और अपनी कस्टम डेटा जोड़कर डेटा अपडेट कर सकते हैं। इससे आप प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा के साथ ताज़ा कर सकते हैं।

**क्या मैं चार्ट की उपस्थिति को कस्टमाइज़ कर सकता हूं?**

हाँ, Aspose.Slides for Android via Java व्यापक कस्टमाइज़ेशन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य फ़ॉर्मेटिंग तत्वों को अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार बदल सकते हैं।