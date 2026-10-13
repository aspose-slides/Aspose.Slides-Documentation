---
title: .NET में प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करें
linktitle: चार्ट एक्सिस
type: docs
url: /hi/net/chart-axis/
keywords:
- चार्ट एक्सिस
- ऊर्ध्वाधर एक्सिस
- क्षैतिज एक्सिस
- एक्सिस को अनुकूलित करें
- एक्सिस को हेरफेर करें
- एक्सिस को प्रबंधित करें
- एक्सिस गुण
- अधिकतम मान
- न्यूनतम मान
- एक्सिस रेखा
- तिथि स्वरूप
- एक्सिस शीर्षक
- एक्सिस स्थिति
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में रिपोर्ट और विज़ुअलाइज़ेशन के लिए चार्ट एक्सिस को कैसे अनुकूलित करें, इसे जानें."
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET के साथ चार्ट एक्सिस को अनुकूलित करने के तरीकों को समझाता है। इसमें गणना किए गए एक्सिस मान, चार्ट पंक्तियों और स्तंभों को बदलना, एक्सिस की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियाँ और स्वरूपण, शीर्षक का घूर्णन, एक्सिस की स्थितियाँ, डिस्प्ले यूनिट तथा लघुगणकीय स्केलिंग शामिल हैं।

## **चार्ट्स में ऊर्ध्वाधर एक्सिस पर अधिकतम मान प्राप्त करें**

एक [प्रस्तुति](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाएँ और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए एक्सिस मान पढ़ने से पहले [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) को कॉल करें ताकि चार्ट लेआउट अद्यतित रहे।

एक्सिस सीमाओं के लिए [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) और [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) पढ़ें, और टिक अंतराल के लिए [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) व [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) पढ़ें। तिथि एक्सिस के लिए प्रासंगिक समय‑इकाई स्केल प्रदान करने वाले [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) और [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) का उपयोग करें। उदाहरण इन मानों को स्थानीय चर में संग्रहीत करता है और चार्ट को सहेजता है।

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

## **एक्सिस के बीच डेटा बदलें**

चार्ट डेटा में श्रृंखलाओं और श्रेणियों की भूमिकाओं को बदलने के लिए [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूह बनाने के तरीके को बदलता है; यह क्षैतिज और ऊर्ध्वाधर एक्सिस को नहीं बदलता। उदाहरण डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` (हेडर पंक्ति और श्रेणी स्तंभ सहित) से बाँधने के लिए [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) का उपयोग करता है, फिर पंक्तियों और स्तंभों को बदलता है। यह चार श्रृंखलाओं और तीन श्रेणियों वाला चार्ट सहेजता है।

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

## **लाइन चार्ट के लिए ऊर्ध्वाधर एक्सिस को निष्क्रिय करें**

ऊर्ध्वाधर एक्सिस पर [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) को `false` सेट करके इसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा वाले एक लाइन चार्ट को बनाता है और उसे ऊर्ध्वाधर एक्सिस छिपा कर सहेजता है।

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

## **लाइन चार्ट के लिए क्षैतिज एक्सिस को निष्क्रिय करें**

क्षैतिज एक्सिस पर [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) को `false` सेट करके इसे छिपाएँ। उदाहरण डिफ़ॉल्ट डेटा वाले एक लाइन चार्ट को बनाता है और उसे क्षैतिज एक्सिस छिपा कर सहेजता है।

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

## **एक श्रेणी एक्सिस बदलें**

तिथि या पाठ श्रेणी एक्सिस चुनने के लिए [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) सेट करें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहले स्लाइड पर पहला आकार एक चार्ट है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान हैं। यह क्षैतिज एक्सिस को तिथि एक्सिस में बदलता है। [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) को `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) को `1`, और [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) को महीने सेट करने से प्रमुख टिक एक‑महीने के अंतराल पर स्थित होते हैं।

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

## **श्रेणी एक्सिस लेबल अंतराल नियंत्रित करें**

जब किसी चार्ट में कई श्रेणियाँ हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्यमान एक्सिस लेबलों की संख्या घटाएँ। [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) को `false` सेट करें, फिर वांछित श्रेणी अंतराल के लिए [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) सेट करें। सामान्य क्रम में पाठ श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, … श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, … श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, … श्रेणी 22 |

`3` का अंतराल हर तीसरे लेबल को दिखाता है, तथा प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर तय होता है; यह आवश्यक नहीं कि प्रत्येक लेबल दिखे।

टिक‑मार्क के अलग नियंत्रण होते हैं। [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) को `false` करें और उनके अंतराल को सेट करने के लिए [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) का उपयोग करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर एक टिक रखता है जबकि लेबल केवल प्रत्येक तीसरी श्रेणी पर दिखते हैं। परिणाम देख पाने के लिए [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) को कोई स्पष्ट शैली दें। किसी भी स्वचालित‑अंतराल गुण को फिर से `true` करने से चार्ट स्वयं अंतराल चुन लेगा।

निम्नलिखित स्व-निहित उदाहरण 24 श्रेणियाँ और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित अंतराल, स्वतंत्र टिक‑मार्क वाले मैनुअल लेबल अंतराल, तथा पुनर्स्थापित स्वचालित अंतराल। दोनों प्रतियाँ मूल चार्ट डेटा को बनाए रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व में अंतर को स्पष्ट देखाता है।

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

// स्लाइड 2: हर तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक मार्क रखें।
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

**स्वचालित अंतराल (स्लाइड 1):** इस रेंडरिंग में प्रत्येक दूसरी श्रेणी लेबल दिखता है और दो पंक्तियों में लिपटा रहता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**मैनुअल अंतराल (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति पर दिखता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बना रहता है। सभी 24 स्तंभ, लेबल वाले और बिना लेबल वाले, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचालित स्वरूप को पुनर्स्थापित करता है।

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **सही एक्सिस और अंतराल चुनें**

पाठ श्रेणी एक्सिस के लिए यह श्रेणी‑गणना अंतराल उपयोग करें, जैसे कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी एक्सिस। कॉलम चार्ट में यह क्षैतिज एक्सिस होता है। क्षैतिज बार चार्ट में श्रेणी एक्सिस ऊर्ध्वाधर होता है, इसलिए इन सेटिंग्स को [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) पर लागू करें। टिक‑मार्क अंतराल उन चार्ट्स में श्रृंखला एक्सिस पर भी लागू होते हैं जिनमें वह मौजूद होता है।

मूल्य एक्सिस की संख्यात्मक स्केल सेट करने के लिए श्रेणी लेबल अंतराल का उपयोग न करें। मूल्य एक्सिस पर, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) मानों के अंतर को दर्शाता है: उदाहरण के लिए, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब एक्सिस शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों को नहीं देखता। स्कैटर और बबल चार्ट मूल्य एक्सिस का उपयोग करते हैं, न कि पाठ श्रेणी एक्सिस। तिथि एक्सिस के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयाँ और स्केल का प्रयोग करें।

## **श्रेणी एक्सिस मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियों को पहले कार्यपत्रक (सूचकांक `0`) में OLE Automation क्रमिक संख्याओं के रूप में संग्रहित किया जाता है। तिथि एक्सिस के लिए [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) को सेट करें, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) को निष्क्रिय करें, और लेबल को सेल स्वरूप से स्वतंत्र रूप से चार-अंकीय वर्ष दिखाने हेतु `yyyy` को [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) को सौंपें।

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

## **एक चार्ट एक्सिस शीर्षक के लिए घूर्णन कोण सेट करें**

ऊर्ध्वाधर एक्सिस पर [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) को सक्षम करें, शीर्षक पाठ प्रदान करें, तथा [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) को सेट कर शीर्षक घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण वैल्यू‑एक्सिस शीर्षक को 90 डिग्री घुमा कर एक कॉलम चार्ट सहेजता है।

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

## **श्रेणी या मूल्य एक्सिस पर एक्सिस स्थिति सेट करें**

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) का प्रयोग करके निर्धारित करें कि मूल्य एक्सिस श्रेणी एक्सिस को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करे। यह गुण केवल श्रेणी एक्सिस पर लागू होता है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी एक्सिस पर `true` सेट करता है और परिणाम सहेजता है।

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

## **चार्ट मूल्य एक्सिस पर डिस्प्ले यूनिट सेट करें**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) सेट करने से डेटा को बदले बिना मूल्य एक्सिस पर लेबलों का स्केल बदलता है। जब [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` पर हो, तो 60,000,000 का मान 60 दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसकी ऊर्ध्वाधर एक्सिस पर मिलियन डिस्प्ले यूनिट लागू करता है।

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

## **लघुगणकीय मूल्य एक्सिस को कॉन्फ़िगर करें**

जब सकारात्मक मान कई क्रम पैमाने में फैले हों तो लघुगणकीय मूल्य एक्सिस उपयोगी होता है। उदाहरण के लिये, कोई सेवा पाँच अवधियों में 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक साथ दिखाई देते हैं। लघुगणकीय स्केल उनके सापेक्ष विकास को आसान बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

वैल्यू एक्सिस पर [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) को `true` सेट करें और आधार चुनने के लिए [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) का प्रयोग करें। यह मौजूदा मानों के प्रदर्शन को बदलता है; डेटा को नहीं बदलता और न ही लघुगणकीय ट्रेंड‑लाइन जोड़ता है। ट्रेंड‑लाइन डेटा में फिटेड रिलेशनशिप का प्रतिनिधित्व करती है और एक अलग सुविधा है।

### **वैल्यू एक्सिस और आधार चुनें**

लाइन या कॉलम चार्ट के लिये वैल्यू एक्सिस [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) है। क्षैतिज बार चार्ट में यह [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) है। स्कैटर और बबल चार्ट में दो वैल्यू एक्सिस होते हैं, इसलिए X मानों के लिये क्षैतिज एक्सिस, Y मानों के लिये ऊर्ध्वाधर एक्सिस या दोनों चुनें। श्रेणी एक्सिस पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट्स में आप `2` से `1000` (समावेशी) तक कोई भी आधार उपयोग कर सकते हैं; `2.5` जैसी भिन्नात्मक आधार भी समर्थित हैं। आधार `10` के साथ क्रमागत शक्तियाँ 10, 100, 1 000, 10 000 समान अंतर पर होती हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना करें**

निम्नलिखित स्व-निहित उदाहरण पहले स्लाइड पर पाँच अनुरोध गिनती के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करके दूसरे पर आधार‑10 लघुगणकीय वैल्यू एक्सिस सक्षम करता है। दोनों स्लाइड एक ही डेटा बनाए रखती हैं।

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

// पहली स्लाइड को रैखिक रखें और केवल कॉपी के वैल्यू-एक्सिस स्केल को बदलें।
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**रैखिक स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी अनुरोध गिनती में समान अंतर दर्शाती है। सबसे बड़ा मान चार्ट पर हावी हो जाता है, जिससे छोटे मानों को पहचानना कठिन हो जाता है।

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु आधार‑10 स्केल पर सीधे उठते हुए रेखा बनाते हैं। एक्सिस लेबल अभी भी मूल अनुरोध गिनती दिखाते हैं।

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शुद्ध सकारात्मक मान दिखा सकता है। इसे सक्रिय करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग‑से दिखाएँ। यदि उन मानों को विश्लेषण से बाहर हटाना उपयुक्त है, तो बहिष्करण का कारण स्पष्ट करें। उन्हें छोटे सकारात्मक संख्याओं से बदलना चुपके से डेटा का अर्थ बदल देता है। लघुगणकीय एक्सिस के लिए मैन्युअल रूप से सेट किया गया न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक्सिस का वह बिंदु कैसे सेट करूँ जहाँ एक एक्सिस दूसरे को पार करता है (axis crossing)?**

क्रॉसिंग व्यवहार चुनने के लिये [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) का उपयोग करें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिये [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) सेट करें। ये सेटिंग्स आपको एक्सिस क्रॉसिंग को उपयुक्त बेसलाइन पर स्थानांतरित करने देती हैं।

**टिक लेबल को एक्सिस के सापेक्ष कैसे स्थित करें?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) के साथ सेट करें: `Low`, `High`, `NextTo` या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिये, [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) या [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) का प्रयोग करें; ये लेबल स्थितियों से अलग होते हैं।