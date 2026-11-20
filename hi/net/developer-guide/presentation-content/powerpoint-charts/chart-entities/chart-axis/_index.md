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
description: "रिपोर्ट और दृश्यांकन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने हेतु Aspose.Slides for .NET के उपयोग के तरीके जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET के साथ चार्ट अक्षों को अनुकूलित करने के तरीके को समझाता है। यह गणना किए गए अक्ष मान, चार्ट पंक्तियों और स्तंभों को बदलना, अक्ष दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक घुमाव, अक्ष स्थिति, प्रदर्शित इकाइयों, और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट्स में लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) को कॉल करें ताकि चार्ट लेआउट अद्यतन हो।

अक्ष सीमाओं के लिए [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) और [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) पढ़ें, और टिक अंतराल के लिए [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) और [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) पढ़ें। [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) और [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक होते हैं। उदाहरण इन मानों को स्थानीय वेरिएबल्स में संग्रहीत करता है और चार्ट को सहेजता है।

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

[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) का उपयोग करके चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाएँ बदलें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूह बनाने के तरीके को बदलता है; यह水平 और垂直 अक्षों को नहीं बदलता। उदाहरण [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बंधित करता है, जिसमें हेडर पंक्ति और श्रेणी कॉलम शामिल है, फिर पंक्तियों और स्तंभों को बदलता है। यह चार श्रृंखलाओं और तीन श्रेणियों के साथ एक चार्ट सहेजता है।

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

## **अक्ष के प्लॉट क्रम को उल्टें**

[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) का उपयोग करके श्रेणी या मान अक्ष को उलटा करें। उदाहरण के तौर पर, एक क्षैतिज बार चार्ट वर्कशीट के समान क्रम में प्रोजेक्ट चरणों को ऊपर से नीचे दिखा सकता है: Planning, Development, Testing। अक्ष को उलटना प्लॉट दिशा को बदलता है; यह डेटा को क्रमबद्ध या पुनर्व्यवस्थित नहीं करता। तुलना में, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) श्रृंखला और श्रेणियों की भूमिकाएँ बदलता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला के साथ एक क्षैतिज बार चार्ट बनाता है। यह तीन स्लाइडों के साथ एक प्रेज़ेंटेशन सहेजता है: सामान्य क्रम, उल्टे श्रेणियाँ, और उल्टे मान। प्रत्येक प्रतिलिपि समान डेटा सेट का उपयोग करती है, और प्रत्येक पर केवल एक अक्ष उलटा होता है।

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

// स्लाइड 2: पहली श्रेणी को ऊपर प्रदर्शित करें।
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

अक्ष को उलटने से लंबवत अक्ष को प्लॉट के विपरीत पक्ष पर भी ले जाया जा सकता है। [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) निर्धारित करता है कि कॉन्फ़िगर किए जा रहे अक्ष के अन्य अक्ष को कहाँ पर काटना है। स्लाइड 2 में, उल्टे श्रेणी अक्ष पर `Maximum` सेट करने से क्षैतिज मान अक्ष नीचे रहता है। किसी विशिष्ट काटने बिंदु के लिए, [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) का उपयोग करें। दिशा बदलते समय काटने सेटिंग्स की जाँच करें, विशेषकर यदि चार्ट में पहले से एक कस्टम काटने बिंदु है। सामान्य प्लॉट दिशा को पुनर्स्थापित करने के लिए `IsPlotOrderReversed` को `false` करें; काटने सेटिंग्स अलग रहती हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टे श्रेणियाँ (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे से ऊपर तक जाती हैं; मान बाएँ से दाएँ बढ़ते हैं। | Planning, Development, और Testing ऊपर से नीचे तक चलते हैं। मान और वर्कबुक पंक्ति क्रम नहीं बदलता। | श्रेणियाँ अपना सामान्य क्रम बनाये रखती हैं; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष शून्य पर दाएँ काटता है। |

## **लाइन चार्ट्स के लिए लंबवत अक्ष को अक्षम करें**

वर्टिकल अक्ष पर [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) को `false` सेट करके इसे छुपाएँ। उदाहरण एक लाइन चार्ट को डिफ़ॉल्ट डेटा के साथ बनाता है और लंबवत अक्ष को छुपा कर सहेजता है।

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

## **लाइन चार्ट्स के लिए क्षैतिज अक्ष को अक्षम करें**

हॉरिज़ॉन्टल अक्ष पर [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) को `false` सेट करके इसे छुपाएँ। उदाहरण एक लाइन चार्ट को डिफ़ॉल्ट डेटा के साथ बनाता है और क्षैतिज अक्ष को छुपा कर सहेजता है।

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

## **चार्ट ग्रिडलाइन दिखाएँ या छुपाएँ**

[ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) और [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/) पढ़कर पता करें कि कोई अक्ष कौन सी ग्रिडलाइन दिखाता है। दोनों गुण केवल‑पढ़ने योग्य हैं। [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/) की लाइन फ़िल से माइनर ग्रिडलाइन को दिखाया या छुपाया जा सकता है। दृश्यमान रंग के साथ ठोस फ़िल सेट करें ताकि वे दिखें, या `FillType.NoFill` का उपयोग करके उन्हें छुपाएँ। प्रमुख ग्रिडलाइन के लिए समान सेटिंग [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat` है। ग्रिडलाइन फ़िल बदलने से अक्ष दृश्यता और टिक‑मार्क नहीं बदलते।

इस क्लस्टर्ड कॉलम चार्ट के वर्टिकल अक्ष में प्रमुख ग्रिडलाइन दिखाई देती हैं और माइनर ग्रिडलाइन छुपी रहती हैं। उदाहरण माइनर ग्रिडलाइन को नारंगी रंग में दिखाता है, फिर फिर से छुपाकर प्रेज़ेंटेशन सहेजता है।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| माइनर ग्रिडलाइन सक्रिय | माइनर ग्रिडलाइन छुपी |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **एक श्रेणी अक्ष बदलें**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) को सेट करके तिथि या टेक्स्ट श्रेणी अक्ष चुनें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहले स्लाइड के पहले आकार के रूप में एक चार्ट रहता है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान होते हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) को `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) को `1`, और [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) को महीनों में सेट करने से प्रमुख टिक एक‑महीने के अंतराल पर मिलते हैं।

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

### **डेटा से श्रेणी अक्ष प्रकार निर्धारित करें**

श्रेणियों को भरने के बाद [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) को कॉल करें, फिर चयन की जांच के लिए [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) पढ़ें। यह तब उपयोगी है जब समान चार्ट को या तो टेक्स्ट लेबल या संख्यात्मक तिथि मान मिलें। यह विधि कॉल किए जाने पर प्रकार निर्धारित करती है; यह बाद में डेटा परिवर्तन पर पुनर्मूल्यांकन नहीं करती। श्रेणियों को बदलने के बाद इसे फिर से कॉल करें।

निम्न उदाहरण टेक्स्ट श्रेणियों के साथ एक चार्ट बनाता है और `Text` प्रिंट करता है। फिर यह श्रेणी कोशिका मानों को तिथियों से बदलता है और विधि को फिर से कॉल करता है, जो `Date` प्रिंट करती है। तिथियाँ OLE Automation संख्यात्मक मानों के रूप में संग्रहीत होती हैं, जो [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate) द्वारा लौटाई जाती हैं, न कि तिथि स्ट्रिंग। [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) यह नियंत्रित करता है कि वे मान कैसे दिखते हैं; यह टेक्स्ट को संख्यात्मक तिथियों में नहीं बदलता। श्रेणी कोशिकाओं के बारे में अधिक जानकारी के लिए देखें [Chart Workbook](/slides/hi/net/chart-workbook/)।

इनपुट के टेक्स्ट श्रेणियों या संख्यात्मक तिथियों की स्थिति ज्ञात होने पर स्वचालित निर्धारण का उपयोग करें, जैसा कि इस उदाहरण में है। सामान्य संख्यात्मक लेबल, मिश्रित श्रेणियों, या खाली डेटा के लिए स्पष्ट रूप से [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) को इच्छित अर्थ के अनुसार सेट करें। केवल संख्यात्मक मान यह स्थापित नहीं करते कि श्रेणियाँ तिथियों को दर्शाती हैं।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // पाठ

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // तिथि

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियाँ हों, तो श्रेणियों या डेटा पॉइंट्स को हटाए बिना दिखाए जाने वाले अक्ष लेबलों की संख्या घटाएँ। [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) को `false` सेट करें, फिर वांछित श्रेणी अंतराल के लिए [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) सेट करें। सामान्य क्रम में टेक्स्ट श्रेणियों के लिये गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में दिखाए गए लेबल |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` का अंतराल प्रत्येक तीसरे लेबल को दिखाता है, दो लेबल छिपे रहते हैं। यह संबंधित कॉलम को नहीं हटाता। स्वचालित स्पेसिंग उपलब्ध स्थान के आधार पर अंतराल चुनती है; यह आवश्यक रूप से सभी लेबल नहीं दिखाती।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) को `false` सेट करें और उनके अंतराल को सेट करने के लिए [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) का उपयोग करें। उदाहरण के लिये, `1` प्रत्येक श्रेणी अंतराल पर एक टिक‑मार्क रखता है जबकि लेबल केवल प्रत्येक तीसरी श्रेणी पर दिखते हैं। परिणाम देखने के लिये [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) को दृश्यमान शैली में सेट करें। किसी भी स्वचालित‑स्पेसिंग गुण को फिर से `true` करने से चार्ट पुनः वही अंतराल चुन लेगा।

निम्न स्व-निहित उदाहरण 24 श्रेणियों और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइडें सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र लेबल स्पेसिंग के साथ मैन्युअल टिक‑मार्क, और पुनर्स्थापित स्वचालित स्पेसिंग। दो प्रतियों में मूल चार्ट डेटा बरकरार रहता है। कोई इनपुट प्रेज़ेंटेशन आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व में स्पष्ट अंतर दर्शाता है।

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

// स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए टिक‑मार्क रखें।
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

**स्वचालित स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में हर दूसरा श्रेणी लेबल दिखाया जाता है और दो पंक्तियों में रैप होता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**मैन्युअल स्पेसिंग (स्लाइड 2):** हर तीसरा लेबल एक पंक्ति में दिखता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर रहते हैं। सभी 24 कॉलम, जिनमें लेबल नहीं हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 स्वचालित उपस्थिति को पुनर्स्थापित करता है।

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिये इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लंबवत होता है, इसलिए इन सेटिंग्स को [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) पर लागू करें। टिक‑मार्क स्पेसिंग उन चार्ट्स में श्रृंखला अक्ष पर भी लागू होती है जिनमें वह मौजूद हो।

श्रेणी लेबल स्पेसिंग का उपयोग मान अक्ष के संख्यात्मक स्केल को सेट करने के लिये न करें। मान अक्ष पर, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) मानांतर को निर्दिष्ट करता है: उदाहरण के लिये `10` का प्रमुख इकाई 0, 10, 20 … पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट मान अक्षों का उपयोग करते हैं, न कि पाठ श्रेणी अक्ष का। तिथि अक्ष के लिये, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयाँ और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिये तिथि प्रारूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियाँ प्रथम कार्यपत्रक (सूचकांक `0`) में OLE Automation क्रमांक के रूप में संग्रहीत होती हैं। [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) को तिथि अक्ष करने के लिये सेट करें, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) को निष्क्रिय करें, और [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) को `yyyy` असाइन करें ताकि श्रेणी लेबल चार्ट की सेल फ़ॉर्मेट से स्वतंत्र रूप से चार-अंकि वर्ष दिखाएँ।

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

## **चार्ट अक्ष शीर्षक के लिये घूर्णन कोण सेट करें**

वर्टिकल अक्ष पर [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) को सक्षम करें, शीर्षक टेक्स्ट प्रदान करें, और [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) को सेट करके शीर्षक घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण वैल्यू‑ऐक्सिस शीर्षक को 90 डिग्री घुमाकर एक कॉलम चार्ट सहेजता है।

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

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) का उपयोग करके निर्धारित करें कि मान अक्ष श्रेणी अक्ष के बीच या श्रेणी टिक‑मार्क पर कटे। यह गुण श्रेणी अक्षों पर लागू होता है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `true` सेट करता है और परिणाम सहेजता है।

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

## **चार्ट मान अक्ष पर प्रदर्शित इकाई सेट करें**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) को सेट करके मान अक्ष पर लेबलों को डेटा को बदले बिना स्केल करें। जब [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` पर सेट होता है, तो 60 000 000 को 60 दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसकी वर्टिकल अक्ष पर मिलियन‑प्रदर्शित इकाई लागू करता है।

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

## **लघुगणकीय मान अक्ष कॉन्फ़िगर करें**

लघुगणकीय मान अक्ष तब उपयोगी होता है जब सकारात्मक मान अनेक क्रमशः बड़ी मात्रा में हों। उदाहरण के लिये, एक सेवा पाँच अवधियों में 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक साथ दिखाई देते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि को तुलना में आसान बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान अक्ष पर [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) को `true` सेट करें और बेस चुनने के लिये [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित करने का तरीका बदलता है; यह डेटा नहीं बदलता न ही लघुगणकीय ट्रेंडलाइन जोड़ता है। ट्रेंडलाइन डेटा में फिटेड संबंध को दर्शाता है और एक अलग सुविधा है।

### **मान अक्ष और बेस चुनें**

लाइन या कॉलम चार्ट के लिये मान अक्ष [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) है। क्षैतिज बार चार्ट के लिये यह [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) है। स्कैटर और बबल चार्ट के दो मान अक्ष होते हैं, इसलिए X मानों के लिये क्षैतिज अक्ष, Y मानों के लिये ऊर्ध्वाधर अक्ष, या दोनों का चयन करें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय बेस `10` है। PPTX चार्ट्स के लिये `2` से `1000` (समावेशी) तक का बेस उपयोग किया जा सकता है; अंशात्मक बेस जैसे `2.5` भी समर्थित हैं। बेस `10` के साथ 10, 100, 1 000, 10 000 जैसे क्रमागत घात समान रूप से spaced होते हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना**

निम्न स्व‑निहित उदाहरण पहले स्लाइड पर पाँच अनुरोध गिनती के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड की प्रतिलिपि बनाकर दूसरी स्लाइड पर बेस‑10 लघुगणकीय मान अक्ष सक्रिय करता है। दोनों स्लाइड एक ही डेटा रखती हैं।

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

// पहली स्लाइड को रैखिक रखें और केवल कॉपी के मान‑अक्ष स्केल को बदलें।
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**रैखिक स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी अनुरोध गिनती के समान अंतर को दर्शाती है। सबसे बड़ा मान चार्ट को हावी करता है, जिससे छोटे मान अलग‑अलग दिखना कठिन हो जाता है।

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु बेस‑10 स्केल पर एक सीधी बढ़ती रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गिनती दिखाते हैं।

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शुद्ध सकारात्मक मान दिखा सकता है। इसे सक्षम करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिये उन मानों को बाहर करना उपयुक्त है, तो अनुपस्थिति का कारण समझाएँ। उन्हें छोटे सकारात्मक संख्याओं से मौन रूप से बदलें नहीं, क्योंकि इससे डेटा का अर्थ बदल जाता है। लघुगणकीय अक्ष के लिये मैन्युअल रूप से सेट किया गया न्यूनतम या अधिकतम भी सकारात्मक ही होना चाहिए।

## **FAQ**

**एक अक्ष को दूसरे अक्ष के साथ कहाँ काटना है (अक्ष क्रॉसिंग) सेट कैसे करें?**

अक्ष क्रॉसिंग व्यवहार चुनने के लिये [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) का उपयोग करें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिये [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) सेट करें। ये सेटिंग्स आपको उपयुक्त बेसलाइन पर अक्ष क्रॉसिंग ले जाने देती हैं।

**टिक‑लेबल को अक्ष के सापेक्ष कैसे स्थित करें?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) को [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) के साथ सेट करें: `Low`, `High`, `NextTo`, या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिये, [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) या [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) उपयोग करें; ये लेबल स्थान निर्धारण से अलग होते हैं।