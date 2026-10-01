---
title: .NET में प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/net/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को नियंत्रित करें
- अक्ष प्रबंधन
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने हेतु Aspose.Slides for .NET का उपयोग कैसे करें, जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET के साथ चार्ट अक्षों को अनुकूलित करने के तरीके को समझाता है। यह गणना किए गए अक्ष मानों, चार्ट पंक्तियों और कॉलमों को स्विच करने, अक्ष दृश्यमानता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक घुमाव, अक्ष स्थिति, और डिस्प्ले यूनिट्स को कवर करता है।

## **चार्ट पर ऊर्ध्वाधर अक्ष के अधिकतम मान प्राप्त करें**

एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) को कॉल करें ताकि चार्ट लेआउट नवीनतम हो।

[ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) और [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) को अक्ष सीमाओं के लिए पढ़ें, और [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) तथा [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) को टिक अंतराल के लिए पढ़ें। [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) और [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय वेरिएबल में संग्रहीत करता है और चार्ट को सहेजता है।

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

[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) का उपयोग करके चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाएँ बदलें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूहित होने के तरीके को बदलता है; यह क्षैतिज और ऊर्ध्वाधर अक्षों को नहीं बदलता। उदाहरण [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी कॉलम शामिल हैं, क्रम बदलने से पहले। यह चार श्रृंखला और तीन श्रेणियों वाला चार्ट सहेजता है।

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

## **लाइन चार्ट के लिए ऊर्ध्वाधर अक्ष को अक्षम करें**

ऊर्ध्वाधर अक्ष पर [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) को `false` सेट करके उसे छुपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और ऊर्ध्वाधर अक्ष छिपा कर उसे सहेजता है।

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

## **लाइन चार्ट के लिए क्षैतिज अक्ष को अक्षम करें**

क्षैतिज अक्ष पर [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) को `false` सेट करके उसे छुपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और क्षैतिज अक्ष छिपा कर उसे सहेजता है।

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

## **श्रेणी अक्ष बदलें**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) सेट करके तिथि या टेक्स्ट श्रेणी अक्ष चुनें। इस उदाहरण को `ExistingChart.pptx` की आवश्यकता है, जिसमें प्रथम स्लाइड पर पहला शेप एक चार्ट है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) को `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) को `1`, और [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) को महीनों पर सेट करने से मुख्य टिक एक‑महीने के अंतराल पर रखे जाते हैं।

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

जब किसी चार्ट में बहुत सारी श्रेणियाँ हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्यमान अक्ष लेबलों की संख्या घटाएँ। [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) को `false` सेट करें, फिर वांछित श्रेणी अंतराल के लिए [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) को सेट करें। सामान्य क्रम में टेक्स्ट श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में दिखाए गए लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, ... श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, ... श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, ... श्रेणी 22 |

`3` का अंतराल प्रत्येक तीसरे लेबल को दिखाता है, प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित कॉलमों को नहीं हटाता। स्वतः अंतराल उपलब्ध स्थान के आधार पर चुना जाता है; यह आवश्यक नहीं कि हर लेबल दिखे।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) को `false` सेट करके [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) से उनका अंतराल निर्धारित करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर टिक‑मार्क रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखाई देते हैं। परिणाम देखने के लिए किसी दृश्य शैली के साथ [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) सेट करें। किसी भी स्वतः‑स्पेसिंग गुण को फिर से `true` करने से चार्ट स्वचालित रूप से वह अंतराल चुन लेगा।

नीचे दिया गया स्वतंत्र उदाहरण 24 श्रेणियाँ और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड्स सहेजता है: स्वतः स्पेसिंग, स्वतंत्र लेबल स्पेसिंग के साथ मैन्युअल टिक‑मार्क, और पुनर्स्थापित स्वतः स्पेसिंग। दोनों कॉपी मूल चार्ट डेटा को बरकरार रखती हैं। कोई इनपुट प्रेज़ेंटेशन आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व के अंतर को स्पष्ट रूप से दिखाता है।

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

// स्लाइड 2: हर तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें।
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// स्लाइड 3: चार्ट को दोनों अंतराल फिर से चुनने दें।
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**स्वचालित स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में हर दूसरा श्रेणी लेबल दिखाया जाता है और दो पंक्तियों में लपेटा जाता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर पर निर्भर कर सकता है।

![सभी 24 कॉलम दृश्यमान के साथ स्वचालित श्रेणी लेबल स्पेसिंग](category-axis-automatic.png)

**मैन्युअल स्पेसिंग (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखाया जाता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बने रहते हैं। सभी 24 कॉलम, जिसमें लेबल‑हीन कॉलम भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 उपरोक्त स्वचालित रूप को पुनर्स्थापित करता है।

![सभी 24 कॉलम दृश्यमान के साथ तीन का मैन्युअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

टेक्स्ट श्रेणी अक्ष (जैसे कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष) के लिए इस श्रेणी‑गणना अंतराल का प्रयोग करें। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष ऊर्ध्वाधर होता है, इसलिए इन सेटिंग्स को [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) पर लागू करें। टिक‑मार्क अंतराल उन चार्टों में श्रृंखला अक्ष पर भी लागू होता है जिनमें वह मौजूद है।

मान अक्ष के संख्यात्मक स्केल को सेट करने के लिए श्रेणी लेबल स्पेसिंग का उपयोग न करें। मान अक्ष पर, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) मानों के अंतर को दर्शाता है: उदाहरण के लिये `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों से परे। स्कैटर और बबल चार्ट मान अक्षों का प्रयोग करते हैं, न कि टेक्स्ट श्रेणी अक्ष का। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयों और स्केले का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियाँ पहली वर्कशीट (सूचकांक `0`) में OLE Automation क्रमांक के रूप में संग्रहीत होती हैं। [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) को तिथि अक्ष पर सेट करें, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) को निष्क्रिय करें, और [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) को `yyyy` असाइन करें ताकि श्रेणी लेबल चार अंकों के वर्ष को सेल स्वरूप से स्वतंत्र रूप से दिखाएँ।

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

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करें**

ऊर्ध्वाधर अक्ष पर [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) को सक्रिय करें, शीर्षक टेक्स्ट प्रदान करें, और शीर्षक को घुमाने के लिए [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) को सेट करें। कोण डिग्री में मापा जाता है; यह उदाहरण मान‑अक्ष शीर्षक को 90 डिग्री घुमाकर एक कॉलम चार्ट को सहेजता है।

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

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) का प्रयोग करके तय करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करे। यह गुण केवल श्रेणी अक्षों पर लागू होता है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `true` सेट करता है और परिणाम सहेजता है।

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

## **चार्ट मान अक्ष पर डिस्प्ले यूनिट सेट करें**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) को सेट करके मान अक्ष के लेबलों को डेटा बदले बिना स्केल करें। जब [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` पर सेट हो, तो 60,000,000 को 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसकी ऊर्ध्वाधर अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक अक्ष को दूसरे के ऊपर कहाँ पार करता हूँ (अक्ष पार) का मान कैसे सेट करूँ?**

[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) का उपयोग करके पार होने के व्यवहार को चुनें। संख्यात्मक पार मान निर्दिष्ट करने के लिए [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) सेट करें। ये सेटिंग्स आपको अक्ष पार को उपयुक्त बेसलाइन पर ले जाने देती हैं।

**टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करें?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) (`Low`, `High`, `NextTo`, या `None`) में से एक से सेट करें। टिक‑मार्क को नियंत्रित करने के लिए, [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) या [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) का उपयोग करें; ये लेबल पोज़िशन से अलग होते हैं।