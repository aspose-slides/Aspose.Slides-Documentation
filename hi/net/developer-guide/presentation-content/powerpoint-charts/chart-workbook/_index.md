---
title: .NET में प्रस्तुतियों में चार्ट कार्यपुस्तिकाओं का प्रबंधन
linktitle: चार्ट कार्यपुस्तिका
type: docs
weight: 70
url: /hi/net/chart-workbook/
keywords:
- चार्ट कार्यपुस्तिका
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी कार्यपुस्तिका
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET को खोजें: PowerPoint और OpenDocument स्वरूपों में चार्ट कार्यपुस्तिकाओं को सहजता से प्रबंधित करें ताकि आपके प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रह तक पहुंचें, और चार्ट मानों के लिये डेटा स्रोत प्रकार कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और असाइन करें, किसी चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित करें।

गुम डेटा को दर्शाने वाले वर्कबुक सेल्स के लिये, उपलब्ध डिस्प्ले मोड के बीच अंतर के लिये [खाली सेल्स के प्रदर्शन को नियंत्रित करें](/slides/hi/net/chart-series/) देखें।

## **छुपी हुई पंक्तियों और कॉलमों से डेटा शामिल करें**

छुपी हुई कार्यपत्र पंक्तियों और कॉलमों से डेटा प्लॉट किया जाए या नहीं, यह नियंत्रित करने के लिये [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) का उपयोग करें। केवल दृश्यमान सेल्स प्लॉट करने के लिये इसे `true` सेट करें, या दृश्यमान एवं छुपी दोनों सेल्स शामिल करने के लिये `false` सेट करें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह कार्यपत्र पंक्तियों या कॉलमों को छुपाती या दिखाती नहीं है।

[sample presentation](hidden-source-data.pptx) में पहली स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एम्बेडेड कार्यपत्र, `Sheet1`, में निम्न स्रोत सीमा `A1:C4` है। पंक्ति 3 और कॉलम C छुपे हुए हैं, लेकिन उनके सेल्स में अभी भी मान हैं।

| कार्यपत्र पंक्ति | A: माह | B: रिटेल | C: थोक (छुपा कॉलम) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छुपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से स्रोत सेल्स तक पहुंचें और [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) को पढ़ें ताकि उनके छुपे होने की स्थिति जांच सकें। यह प्रॉपर्टी केवल-पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छुपी पंक्ति से संबंधित है, और C2 छुपे कॉलम से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिये, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड वर्कबुक को [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) से रखें और [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) से पुनः लोड करें। सभी सेल्स शामिल करने के लिये, छुपी फ़रवरी श्रेणी को पुनर्स्थापित करने हेतु [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) भी उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिये अपर्याप्त है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // एंबेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // छुपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

उदाहरण दो संस्करणों में प्रस्तुति को सेव करता है: एक केवल दृश्यमान रिटेल मान (10 और 20) के साथ, और दूसरा सभी छह मानों के साथ। नीचे की छवियां सेव की गई प्रस्तुतियों को पुनः खोलने के बाद रेंडर की गई हैं; दोनों फ़ाइलें अपनी असाइन की गई प्लॉटिंग सेटिंग को बनाए रखती हैं। पंक्ति 3 और कॉलम C दोनों एम्बेडेड वर्कबुक में छुपे रहते हैं।

| केवल दृश्यमान सेल्स (`true`) | सभी सेल्स (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक छुपा सेल जिसमें मान हो, वह खाली सेल से अलग होता है। [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) नियंत्रित करता है कि अनुपस्थित मान कैसे प्रदर्शित किए जाएँ; यह छुपे स्रोत डेटा को शामिल या बाहर नहीं रखता। उदाहरण के लिये देखें [खाली सेल्स के प्रदर्शन को नियंत्रित करें](/slides/hi/net/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज प्राप्त करें**

किसी मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज की जाँच करें ताकि पता चल सके कि प्रत्येक चार्ट कौन से कार्यपत्र सेल्स का उपयोग करता है। [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) मेथड वर्तमान डेटा रेंज को कार्यपत्र-योग्य फ़ॉर्मूले के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` कार्यपत्र का नाम है, `!` उसे सेल रेंज से अलग करता है, और `$A$1:$D$5` A1 से D5 तक की सेल्स को दर्शाता है। डॉलर चिह्न पूर्ण पंक्ति और कॉलम संदर्भ दर्शाते हैं।

यह मेथड चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज को पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकेगा। अधिक जानकारी के लिये देखें [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर आकृतियों को सीधे चार्ट के लिये जांचता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट कर अगला चार्ट प्रोसेस करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for .NET [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड प्रदान करता है जिससे आप चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells से संपादित डेटा होता है) को पढ़ और लिख सकते हैं। **ध्यान दें** कि चार्ट डेटा को समान रूप से व्यवस्थित होना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण पहली स्लाइड की पहली आकृति पर एक चार्ट के साथ एक प्रस्तुति का उपयोग करता है। यह एम्बेडेड वर्कबुक को स्ट्रीम में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सेव नहीं करता।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को वैध करें**

जब आप एक एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रह को बरकरार रखता है। यह असंगति [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) को सूचकांक-सीमा त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को वापस लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड के पहले चार्ट का उपयोग करता है। टिप्पणी दर्शाती है जहाँ वर्कबुक संपादन होगा; चलाने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को वैध करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // यहाँ वर्कबुक स्ट्रीम को संशोधित करें, उदाहरण के लिये Aspose.Cells का उपयोग करके।

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

संग्रहों को साफ़ करने से वर्कबुक लिखे जाने से पहले पुराने डेटा रेफ़रेंसेस हट जाते हैं। अपडेटेड वर्कबुक के लिये आवश्यक श्रृंखला और श्रेणी मैपिंग्स को फिर से बनाएं।

## **कैटेगरी लेबल्स को संग्रहीत करने का तरीका चुनें**

लेबल्स जोड़ने से पहले खाली श्रेणी संग्रह पर [IChartCategoryCollection.UseCells](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorycollection/usecells/) सेट करें। वर्कशीट सेल्स का उपयोग उन लेबल्स के लिये करें जो वर्कबुक डेटा का संदर्भ देते हैं या पदानुक्रम बनाते हैं, जैसे वर्ष के आधार पर क्वार्टर समूह। स्ट्रिंग लिटरल्स का उपयोग एकल स्तर के लेबल्स के लिये करें जिनके लिये सेल रेफ़रेंस की आवश्यकता नहीं है। यह सेटिंग केवल श्रेणियों पर लागू होती है। नीचे दोनों चार्ट वर्कशीट सेल्स का उपयोग संख्यात्मक श्रृंखला मानों के लिये करते हैं।

यह उदाहरण दो कॉलम चार्ट बनाता है और प्रत्येक के लिये `Q1 Q2 Q3 Q4` तथा उसका स्टोरेज मोड प्रिंट करता है। वर्कशीट-समर्थित लेबल्स के लिये, [IChartCategory.AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/ascell/) अंतर्निहित सेल तक पहुंच देता है और [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) उसका लेबल लौटाता है। लिटरल लेबल्स के लिये, सीधे [IChartCategory.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/value/) से स्ट्रिंग पढ़ें।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

foreach (var useCells in new[] { true, false })
{
    var x = useCells ? 20 : 360;
    var chart = shapes.AddChart(ChartType.ClusteredColumn, x, 20, 320, 250);
    var data = chart.ChartData;
    data.Series.Clear();
    data.Categories.Clear();
    data.Categories.UseCells = useCells;

    var workbook = data.ChartDataWorkbook;
    var seriesName = workbook.GetCell(0, 0, 1, "Sales");
    var series = data.Series.Add(seriesName, chart.Type);
    for (var row = 1; row <= 4; row++)
    {
        var label = $"Q{row}";
        if (useCells)
        {
            var labelCell = workbook.GetCell(0, row, 0, label);
            data.Categories.Add(labelCell);
        }
        else
        {
            data.Categories.Add(label);
        }

        var valueCell = workbook.GetCell(0, row, 1, row * 10);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    Console.Write($"UseCells = {data.Categories.UseCells}:");
    foreach (var category in data.Categories)
    {
        var label = data.Categories.UseCells ? category.AsCell.Value : category.Value;
        Console.Write($" {label}");
    }
    Console.WriteLine();
}

presentation.Save("category-labels.pptx", SaveFormat.Pptx);
```

## **वर्कबुक सेल्स के लिये कस्टम नंबर फ़ॉर्मेट सेट करें**

[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) का उपयोग करके आप चार्ट के एम्बेडेड वर्कबुक में संख्यात्मक मानों के प्रदर्शित रूप को नियंत्रित कर सकते हैं। उदाहरण के लिये, एक रिपोर्ट को प्रतिशत के रूप में चार दशमलव स्थानों के साथ घातांक के साथ दिखाने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

नंबर फ़ॉर्मेट केवल प्रदर्शन को बदलता है, संग्रहीत मान नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बनाता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो इसके बजाय [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) उपयोग होता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसके सेल्स को [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है। कार्यपत्र 0 पर, B2 में रूपांतरण दर और C2 में गुणांक है। दोनों सेल्स चार्ट मान प्रदान करते हैं। उदाहरण स्रोत फ़ॉर्मेट से लिंक्ड वैल्यू लेबल्स को भी सक्षम करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

वर्कबुक सेल फ़ॉर्मेट्स चार्ट धुरी या डेटा लेबल्स पर सेट किए गए फ़ॉर्मेट्स से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपने स्रोत सेल के मान को दिखाता है क्योंकि [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) सक्षम है, और स्रोत नंबर फ़ॉर्मेट को अनुसरण करता है क्योंकि [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true` है। प्रस्तुति को सेव करने और पुनः खोलने के बाद, लेबल्स `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। ऊर्ध्वाधर धुरी अपनी स्वयं की [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00` उपयोग करती है, जबकि [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) `false` है।

किसी डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिये, उसके स्रोत-लिंक फ़्लैग को `false` सेट करें और उसका [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) असाइन करें। यह वर्कबुक सेल के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दिखाएगा। अधिक जानकारी हेतु देखें [Chart Data Labels](/slides/hi/net/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की छवि सेव की गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक बबल चार्ट डिफ़ॉल्ट डेटा के साथ जोड़ता है। यह कार्यपत्र 0 पर A10:A12 सेल्स को पहले श्रृंखला के पहले तीन लेबल्स के लिये उपयोग करता है, सेल्स से लेबल्स सक्षम करता है, और अपडेटेड प्रस्तुति को सेव करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **वर्कशीट्स का प्रबंधन करें**

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) प्रॉपर्टी चार्ट वर्कबुक में मौजूद कार्यशीट्स तक पहुंच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक कार्यशीट का नाम कंसोल पर प्रिंट करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

श्रृंखला बिंदु मानों को सीधे संख्यात्मक लिटरल्स के रूप में भी संग्रहीत किया जा सकता है। पूर्ण उदाहरण के लिये देखें [Set Series Values Using Numeric Literals](/slides/hi/net/chart-series/#set-series-values-using-numeric-literals) जो उन्हें सेव और पढ़ता है। बिंदु मानों का स्रोत प्रकार चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग होता है; संख्यात्मक लिटरल्स का उपयोग स्वाभाविक रूप से एम्बेडेड वर्कबुक को हटा नहीं देता।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों से सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा कार्यपत्र 0 के सेल C1 से है। [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) एनीमरेशन प्रत्येक नाम के लिये स्रोत चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति को सेव करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट्स का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) प्रॉपर्टी को [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) के साथ [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) एनीमरेशन का उपयोग करके असमर्थित फ़ॉर्मेट्स का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकृतियों को जांचता है, गैर-चार्ट आकृतियों को स्किप करता है, और .xlsb एम्बेडेड वर्कबुक वाले प्रत्येक चार्ट के लिये एक निदान संदेश प्रिंट करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // यहाँ समर्थित चार्ट कार्यपुस्तिका डेटा पढ़ें या संशोधित करें।
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिये बाहरी वर्कबुक को डेटा स्रोत के रूप में उपयोग करने का समर्थन करता है।

### **बाहरी वर्कबुक बनाएँ**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में एक्सपोर्ट करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक एक्सपोर्ट करता है। यह आउटपुट स्ट्रीम को बंद करता है और फिर बाहरी वर्कबुक को चार्ट डेटा स्रोत के तौर पर असाइन करता है, फिर लिंक्ड प्रस्तुति को सेव करता है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **बाहरी वर्कबुक सेट करें**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) मेथड के द्वारा आप किसी चार्ट को बाहरी वर्कबुक को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। इस मेथड का उपयोग बाहरी वर्कबुक के पथ को अपडेट करने के लिये भी किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

जबकि आप रिमोट स्थानों या संसाधनों में संग्रहीत वर्कबुक्स के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिये सापेक्ष पथ दिया जाता है, तो इसे स्वचालित रूप से पूर्ण पथ में परिवर्तित किया जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसमें कार्यपत्र `Sheet1` में B1 में एक श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान होते हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक लिंक करता है, और [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सेव करता है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड की जाए या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध हो सकती है।
* जब `updateChartData` `true` हो, तो लक्ष्य वर्कबुक से चार्ट डेटा अपडेट किया जाता है।

निम्न उदाहरण `updateChartData` को `false` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बनाए रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सेव करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **चार्ट की बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिये, जांचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण प्रस्तुति की पहली स्लाइड पर पहले आकार को जांचता है जिसमे लिंक्ड बाहरी वर्कबुक है। यदि वह एक चार्ट है जो बाहरी वर्कबुक से लिंक्ड है, तो उदाहरण [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) को कंसोल में प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी को सेव करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक्स के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक्स के डेटा को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो सकती, तो एक एक्सेप्शन फेंका जाता है।

यह उदाहरण पहली स्लाइड के पहले आकार पर एक चार्ट का उपयोग करता है और वह एक सुलभ बाहरी वर्कबुक से लिंक्ड है। यह पहले श्रृंखला के पहले डेटा बिंदु की सेल-आधारित मान को 100 सेट करता है और अपडेटेड प्रस्तुति को सेव करता है। सेल मानों को संपादित करने से जुड़े बाहरी XLSX फ़ाइल को भी अपडेट किया जा सकता है, इसलिए यदि मूल वर्कबुक को अपरिवर्तित रखना है तो एक कॉपी का उपयोग करें।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

## **स्रोत वर्कबुक्स से चार्ट डेटा रीफ़्रेश करें**

Aspose.Slides for .NET 26.11 ने एक चार्ट के लिये [IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) और प्रस्तुति के लिये [IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) जोड़ा है। स्रोत वर्कबुक मान बदलने के बाद इन्हें उपयोग करें। बाहरी वर्कबुक्स उपलब्ध और समर्थित होने चाहिए।

[Aspose.Slides for .NET](/slides/hi/net/installation/) 26.11 या बाद का संस्करण स्थापित होने पर, यह उदाहरण `charts.pptx` की पहली स्लाइड पर पहला चार्ट रीफ़्रेश करता है। उसका स्रोत वर्कबुक उपलब्ध होना चाहिए। परिणामी प्रस्तुति को सेव करें ताकि अपडेटेड चार्ट डेटा बरकरार रहे।

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
var chart = presentation.Slides[0].Shapes.OfType<IChart>().FirstOrDefault();
if (chart == null)
{
    Console.WriteLine("The first slide must contain a chart.");
    return;
}

chart.ChartData.RefreshData();
presentation.Save("refreshed-chart.pptx", SaveFormat.Pptx);
```

सभी चार्ट्स को रीफ़्रेश करने के लिये, एक अलग प्रस्तुति इंस्टेंस का उपयोग करें जैसा नीचे दिखाया गया है। `false` पास करने पर रीफ़्रेश विफलता कॉलर को प्रोपेगेट होती है; यह पहले से रीफ़्रेश किए गए चार्ट्स को रोल बैक नहीं करता।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

पैरामीटर का डिफ़ॉल्ट मान `true` है: [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) विफल चार्ट को स्किप करता है और अन्य के साथ जारी रखता है। यह प्रति-चार्ट परिणाम वापस नहीं करता, इसलिए पूर्ण कॉल यह प्रमाणित नहीं करता कि हर चार्ट रीफ़्रेश हुआ। यदि आपको प्रत्येक विफल चार्ट की पहचान करनी है तो व्यक्तिगत [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) कॉल्स का उपयोग करें।

रीफ़्रेश स्रोत डेटा को पुनः लोड करता है। यह फ़ॉर्मूला गणना, चार्ट लेआउट वैधता और OLE प्रीव्यू अपडेट से अलग है। मेमोरी में रीफ़्रेश की जांच के लिये लाइव सेल-आधारित मान देखें। एक [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) अभी भी पहले सेव किए गए चार्ट का वर्णन कर सकता है जब तक आप प्रस्तुति को सेव करके पुनः नहीं खोलते।

### **वर्कबुक के बिना कैश्ड चार्ट मान पढ़ें**

.NET 26.11 में, कैश्ड-मान एक्सेसर्स चार्ट के साथ संग्रहीत मानों को वर्कबुक खोले बिना पढ़ते हैं। यह तब उपयोगी है जब लिंक्ड फ़ाइल अनुपलब्ध हो और आपको केवल चार्ट का अंतिम संग्रहीत डेटा चाहिए। यह नीचे दी गई रिकवरी विकल्प से वर्कबुक पुनर्निर्माण से अलग है।

| ऑब्जेक्ट | कैश्ड एक्सेसर |
| --- | --- |
| सामान्य श्रृंखला डेटा बिंदु | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| स्कैटर या बबल डेटा बिंदु | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| बबल डेटा बिंदु | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| चार्ट श्रेणी | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

प्रत्येक एक्सेसर [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/) लौटाता है। [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) संग्रहीत ऑब्जेक्ट को उजागर करता है; [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) टेक्स्ट प्रदान करता है; [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) अनुपलब्ध या गैर-संख्यात्मक मान के लिये `NaN` लौटाता है। कैश अनुपलब्ध या पुराना हो सकता है, जिसमें अभी-अभी बनाया गया चार्ट शामिल है जिसे अभी तक सेव नहीं किया गया। मान न लें कि हर फ़ील्ड मौजूद है या संख्या रखता है।

यह उदाहरण `cached-chart.pptx` से सभी फ़ील्ड पढ़ता है, जो चार्ट्स वाली एक सेव की गई प्रस्तुति है। एक स्थगित बाहरी वर्कबुक स्वीकार्य है क्योंकि कोड [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) या लाइव वर्कबुक सेल्स तक पहुंचता नहीं है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("cached-chart.pptx");
foreach (var slide in presentation.Slides)
foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
        continue;

    foreach (var category in chart.ChartData.Categories)
        PrintCache("Category", category.CachedValue);

    foreach (var series in chart.ChartData.Series)
    foreach (var point in series.DataPoints)
    {
        PrintCache("Value", point.CachedValue);
        PrintCache("X", point.CachedXValue);
        PrintCache("Y", point.CachedYValue);
        PrintCache("Bubble size", point.CachedBubbleSize);
    }
}

static void PrintCache(string name, ICachedChartValue value)
{
    var number = value.ToDouble();
    if (value.Data == null)
        Console.WriteLine($"{name}: no cached value");
    else if (double.IsNaN(number))
        Console.WriteLine($"{name}: {value} (not numeric)");
    else
        Console.WriteLine($"{name}: {number}");
}
```

वर्तमान स्रोत डेटा की आवश्यकता होने पर रीफ़्रेश उपयोग करें; जब संग्रहीत स्नैपशॉट पर्याप्त हो तो कैश्ड रीड्स उपयोग करें। कैश वर्कबुक की पूर्ण कॉपी नहीं है और अंतिम अपडेट के बाद किए गए परिवर्तन प्रदान नहीं कर सकता।

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश्ड डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। प्रस्तुति खोलने से पहले [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) बनाएं, उसकी [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) कॉन्फ़िगर करें, और [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) को `true` सेट करें।

नीचे का C# उदाहरण एक ऐसी चार्ट के लिये वर्कबुक डेटा पुनः प्राप्त करता है जो पहली स्लाइड की पहली आकृति है और अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनः प्राप्त डेटा को [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) और [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // यहाँ पुनः प्राप्त वर्कबुक डेटा पढ़ें या संशोधित करें।
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

यदि कोड बाहरी वर्कबुक को एक्सेस करता है जबकि वह अनुपलब्ध है और रीकोवरी निष्क्रिय है, तो Aspose.Slides एक [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकेगा। केवल तभी रीकोवरी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग वहनीय हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तनों को शामिल नहीं किया जा सकता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से लिंक्ड है?**

हां। चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं ताकि सुनिश्चित हो सके कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक्स के लिये सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो इसे स्वचालित रूप से पूर्ण पथ में परिवर्तित कर दिया जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयर्स पर स्थित वर्कबुक्स का उपयोग कर सकता हूं?**

हां, ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सेव करने पर बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [बाहरी फ़ाइल के लिंक](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहीत करती है। सेल-आधारित चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल को अपरिवर्तित रखना है तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड-प्रोटेक्टेड है तो क्या करना चाहिए?**

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। सामान्य उपाय है पहले सुरक्षा हटाना या एक डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिये, [Aspose.Cells](https://reference.aspose.com/cells/net/)) और उस कॉपी को लिंक करना।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक रखता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो फ़ाइल को अपडेट करने से प्रत्येक चार्ट में अगली बार डेटा लोड होने पर परिवर्तन परिलक्षित होंगे।