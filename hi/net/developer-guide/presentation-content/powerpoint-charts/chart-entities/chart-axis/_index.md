---
title: ".NET में प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें"
linktitle: "चार्ट अक्ष"
type: docs
url: /hi/net/chart-axis/
keywords:
- "चार्ट अक्ष"
- "ऊर्ध्वाधर अक्ष"
- "क्षैतिज अक्ष"
- "अक्ष को अनुकूलित करें"
- "अक्ष को नियंत्रित करें"
- "अक्ष का प्रबंधन करें"
- "अक्ष गुण"
- "अधिकतम मान"
- "न्यूनतम मान"
- "अक्ष रेखा"
- "तिथि स्वरूप"
- "अक्ष शीर्षक"
- "अक्ष स्थिति"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिये PowerPoint प्रस्तुतियों में चार्ट अक्षों को कैसे अनुकूलित करें, जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET के साथ चार्ट अक्षों को अनुकूलित करने का तरीका समझाता है। इसमें गणना किए गए अक्ष मान, चार्ट पंक्तियों और स्तम्भों को बदलना, अक्ष दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक घुमाव, अक्ष स्थिति, प्रदर्शन इकाइयाँ, तथा लघुगणकीय स्केलिंग शामिल हैं।

## **चार्ट में वर्टिकल अक्ष पर अधिकतम मान प्राप्त करें**

एक [प्रेजेंटेशन](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाकर डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले चार्ट लेआउट को अद्यतित रखने के लिए [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) को कॉल करें।

अक्ष सीमाओं के लिए [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) और [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) पढ़ें, तथा टिक अंतराल के लिए [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) और [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) पढ़ें। तिथि अक्षों के लिए प्रासंगिक समय‑इकाई स्केल उपलब्ध कराने वाले [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) और [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) का उपयोग करें। उदाहरण इन मानों को स्थानीय वेरिएबल्स में संग्रहीत करता है और चार्ट को सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **अक्षों के बीच डेटा बदलें**

[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) का उपयोग करके चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाएँ बदलें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। इससे डेटा का समूह बदलता है; यह क्षैतिज और लम्बवत अक्षों को नहीं बदलता। उदाहरण [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` (हेडर पंक्तियों सहित) से बाइंड करता है, फिर पंक्तियों और स्तम्भों को बदलता है। यह चार श्रृंखला और तीन श्रेणियों वाला चार्ट सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **अक्ष की प्लॉटिंग क्रम को उलटें**

[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) का उपयोग करके श्रेणी या मान अक्ष को उलटा करें। उदाहरण के लिए, एक क्षैतिज बार चार्ट कार्य चरणों को शीर्ष‑से‑नीचे उसी क्रम में दिखा सकता है जैसा कि वर्कशीट में है: योजना, विकास, परीक्षण। अक्ष को उलटने से प्लॉटिंग दिशा बदलती है; यह वर्कबुक डेटा को क्रमबद्ध या पुनः व्यवस्थित नहीं करता। तुलना में, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) श्रृंखला और श्रेणियों की भूमिकाएँ बदलता है।

निम्नलिखित उदाहरण तीन चरणों के साथ एक क्षैतिज बार चार्ट बनाता है और तीन स्लाइड्स सहेजता है: सामान्य क्रम, उलटी श्रेणियाँ, और उलटे मान। प्रत्येक प्रतिलिपि एक ही डेटा सेट का उपयोग करती है, और प्रत्येक पर केवल एक अक्ष उलटा किया गया है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// स्लाइड 2: पहली श्रेणी को शीर्ष पर दिखाएँ।
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// क्षैतिज मान अक्ष को नीचे रखें।
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उलटें।
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

अक्ष को उलटने से लंबवत अक्ष को प्लॉट के विपरीत पक्ष पर ले जाया जा सकता है। [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) निर्धारित करता है कि कॉन्फ़िगर किए जा रहे अक्ष को अन्य अक्ष कहाँ पार करता है। स्लाइड 2 में, उलटी श्रेणी अक्ष पर इसे `Maximum` पर सेट करने से क्षैतिज मान अक्ष नीचे रहता है। विशिष्ट पार बिंदु के लिए, [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) का उपयोग करें। दिशा बदलते समय पार सेटिंग्स की जाँच करें, विशेषकर जब चार्ट में पहले से कस्टम पार बिंदु हो। सामान्य प्लॉटिंग दिशा बहाल करने के लिए `IsPlotOrderReversed` को `false` पर सेट करें; पार सेटिंग्स अलग रहती हैं।

| सामान्य क्रम (स्लाइड 1) | उलटी श्रेणियाँ (स्लाइड 2) | उलटे मान (स्लाइड 3) |
| --- | --- | --- |
| ![साधारण श्रेणी और मान अक्ष क्रम वाला क्षैतिज बार चार्ट](axis-order-normal.png) | ![शीर्ष से नीचे श्रेणियों के साथ क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![उलटा मान अक्ष और दाईं ओर शून्य वाला क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे से ऊपर तक चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | योजना, विकास, और परीक्षण शीर्ष से नीचे तक चलते हैं। मान और वर्कबुक पंक्ति क्रम अपरिवर्तित रहता है। | श्रेणियों का क्रम सामान्य रहता है; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष शून्य पर दाईं ओर पार करता है। |

## **लाइन चार्ट के लिए वर्टिकल अक्ष को निष्क्रिय करें**

वर्टिकल अक्ष को छिपाने के लिए [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) को `false` सेट करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और वर्टिकल अक्ष को छिपाकर सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **लाइन चार्ट के लिए हॉरिज़ॉन्टल अक्ष को निष्क्रिय करें**

हॉरिज़ॉन्टल अक्ष को छिपाने के लिए [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) को `false` सेट करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और हॉरिज़ॉन्टल अक्ष को छिपाकर सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **एक श्रेणी अक्ष बदलें**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) को सेट करके तिथि या पाठ श्रेणी अक्ष चुनें। इस उदाहरण के लिए `ExistingChart.pptx` आवश्यक है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है और श्रेणी कोशिकाएँ संख्यात्मक Excel तिथि मान रखती हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) को `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) को `1`, और [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) को `Months` सेट करने से प्रमुख टिक एक‑महीने अंतराल पर रखे जाते हैं।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियाँ हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्यमान अक्ष लेबलों की संख्या घटाएँ। [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) को `false` करें, फिर इच्छित श्रेणी अंतराल के लिए [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) सेट करें। सामान्य क्रम में पाठ श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में दर्शाए गए लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, … श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, … श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, … श्रेणी 22 |

`3` का अंतराल हर तीसरे लेबल को दिखाता है, दो लेबल छिपे रहते हैं। यह संबंधित स्तम्भों को नहीं हटाता। स्वतः अंतराल उपलब्ध स्थान के आधार पर चुना जाता है; यह आवश्यक नहीं कि सभी लेबल दिखाए।

टिक‑मार्क का अलग नियंत्रण है। [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) को `false` करें और उनके अंतराल को सेट करने के लिए [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) का प्रयोग करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर टिक‑मार्क रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखते हैं। परिणाम देखे जाने के लिए [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) को एक दृश्यमान शैली पर सेट करें। किसी भी स्वतः‑स्पेसिंग गुण को फिर `true` पर सेट करने से चार्ट स्वतः वह अंतराल चुन लेता है।

निम्नलिखित स्वतंत्र उदाहरण 24 श्रेणियाँ और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड्स सहेजता है: स्वतः स्पेसिंग, स्वतंत्र लेबल स्पेसिंग के साथ मैनुअल टिक‑मार्क, तथा पुनः स्वतः स्पेसिंग। दोनों प्रतियों में मूल चार्ट डेटा बना रहता है। कोई इनपुट प्रेजेंटेशन आवश्यक नहीं है। क्षैतिज लेबल पाठ घनत्व अंतर को स्पष्ट रूप से दिखाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन प्रत्येक श्रेणी के लिये टिक‑मार्क रखें।
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// स्लाइड 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**स्वतः स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में हर दूसरा श्रेणी लेबल दिखाया गया है और दो पंक्तियों में लिपटा है। स्वतः परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![सभी 24 स्तम्भ दिखाई देते हुए स्वतः श्रेणी लेबल स्पेसिंग](category-axis-automatic.png)

**मैनुअल स्पेसिंग (स्लाइड 2):** हर तीसरा लेबल एक पंक्ति में दिखाया गया है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बना रहता है। सभी 24 स्तम्भ, लेबल‑रहित सहित, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 में ऊपर दिखाए अनुसार स्वतः स्वरूप बहाल किया गया है।

![सभी 24 स्तम्भ दिखाई देते हुए तीन का मैनुअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लंबवत होता है, इसलिए इन सेटिंग्स को [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) पर लागू करें। टिक‑मार्क अंतराल का उपयोग उन चार्टों में श्रृंखला अक्ष के लिए भी किया जा सकता है जिनमें वह मौजूद हो।

श्रेणी लेबल स्पेसिंग का उपयोग मान अक्ष की संख्यात्मक स्केल सेट करने के लिए न करें। मान अक्ष पर, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) मान अंतर को निर्धारित करता है: उदाहरण के लिये, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों की गणना करता है, डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट मान अक्ष का उपयोग करते हैं, न कि पाठ श्रेणी अक्ष। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में बताई गई समय‑आधारित प्रमुख इकाइयाँ और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

यह उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियाँ पहले कार्यपत्रक (सूचक `0`) में OLE ऑटोमेशन क्रमांक के रूप में संग्रहीत हैं। [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) को तिथि अक्ष पर सेट करें, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) को अक्षम करें, और [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) को `yyyy` असाइन करें ताकि श्रेणी लेबल सेल स्वरूप से स्वतंत्र रूप से चार-अंकीय वर्ष दिखाएँ।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **चार्ट अक्ष शीर्षक के लिए घुमाव कोण सेट करें**

वर्टिकल अक्ष पर [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) को सक्रिय करें, शीर्षक पाठ प्रदान करें, और शीर्षक को घुमाने के लिए [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) सेट करें। कोण डिग्री में मापा जाता है; यह उदाहरण कॉलम चार्ट को उसके मान‑अक्ष शीर्षक को 90 डिग्री घुमाकर सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **श्रेणी या मान अक्ष पर अक्ष स्थिति सेट करें**

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) का उपयोग करके निर्धारित करें कि मान अक्ष श्रेणी अक्ष के बीच में या श्रेणी टिक‑मार्क पर पार करे। यह गुण केवल श्रेणी अक्षों पर लागू होता है। उदाहरण कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर इसे `true` सेट करता है और परिणाम सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **चार्ट मान अक्ष पर प्रदर्शन इकाई सेट करें**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) को सेट करके मान अक्ष पर लेबल स्केल करें, बिना मूल डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` पर हो, तो 60 000 000 का मान 60 के रूप में प्रदर्शित होता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके वर्टिकल अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **लघुगणकीय मान अक्ष को कॉन्फ़िगर करें**

लघुगणकीय मान अक्ष तब उपयोगी होता है जब सकारात्मक मान कई क्रम magnitude में होते हैं। उदाहरण के लिये, कोई सेवा पाँच अवधि में 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक‑दूसरे के पास दिखते हैं। लघुगणकीय स्केल उनके सापेक्ष विकास को तुलना‑योग्य बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान अक्ष पर [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) को `true` सेट करें और बेस चुनने के लिए [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित रूप को बदलता है; डेटा या लघुगणकीय ट्रेंड‑लाइन नहीं जोड़ता। ट्रेंड‑लाइन डेटा में फिटेड संबंध दर्शाती है और एक अलग सुविधा है।

### **मान अक्ष और बेस चुनें**

लाइन या कॉलम चार्ट के लिए मान अक्ष [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) है। क्षैतिज बार चार्ट के लिए यह [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिये क्षैतिज अक्ष, Y मानों के लिये लम्बवत अक्ष, या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय बेस `10` है। PPTX चार्ट के लिये `2` से `1000` (समावेशी) के बीच कोई भी बेस इस्तेमाल किया जा सकता है; अंशात्मक बेस जैसे `2.5` भी समर्थित हैं। बेस `10` पर क्रमशः 10, 100, 1 000, 10 000 समान अंतर पर स्थित होते हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना करें**

निम्नलिखित स्वतंत्र उदाहरण पहली स्लाइड पर पाँच अनुरोध गिनती के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करके दूसरी स्लाइड पर बेस‑10 लघुगणकीय मान अक्ष सक्रिय करता है। दोनों स्लाइड्स समान डेटा रखती हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// पहली स्लाइड को रैखिक रखें और केवल कॉपी के मान-अक्ष स्केल को बदलें।
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**रैखिक स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी अनुरोध गिनती के समान अंतर दर्शाती है। सबसे बड़ा मान चार्ट में हावी हो जाता है, जिससे छोटे मान पहचानने में कठिनाई होती है।

![लाइन चार्ट जिसमें पाँच अनुरोध गिनती रैखिक मान अक्ष पर दिखाए गये हैं](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु बेस‑10 स्केल पर एक सीधा ऊपर‑की‑तरफ़ रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गिनती दिखाते हैं।

![इसी पाँच अनुरोध गिनती का बेस‑10 लघुगणकीय मान अक्ष पर प्रेजेंटेशन](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल पूरी तरह सकारात्मक मान दिखा सकता है। इसे सक्षम करने से पहले डेटा की जाँच करें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिये उन मानों को छोड़ना उपयुक्त है, तो त्याग का कारण स्पष्ट करें। उन्हें छोटे सकारात्मक संख्याओं से चुपचाप बदलना डेटा का अर्थ बदल देता है। लघुगणकीय अक्ष के किसी भी मैन्युअल न्यूनतम या अधिकतम को भी सकारात्मक ही होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे निर्दिष्ट करूँ कि एक अक्ष दूसरे को कहाँ पार करता है (अक्ष पार करना)?**

[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) का उपयोग करके पार‑व्यवहार चुनें। संख्यात्मक पार मान निर्दिष्ट करने के लिये [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) सेट करें। ये सेटिंग्स आपको अक्ष पार को उचित बेसलाइन पर ले जाने देती हैं।

**मैं टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) के साथ उपयोग करें: `Low`, `High`, `NextTo` या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिये [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) या [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) का प्रयोग करें; ये लेबल स्थिति से अलग होते हैं।