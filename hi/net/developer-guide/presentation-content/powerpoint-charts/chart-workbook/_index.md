---
title: ".NET में प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें"
linktitle: "चार्ट वर्कबुक"
type: docs
weight: 70
url: /hi/net/chart-workbook/
keywords:
- "चार्ट वर्कबुक"
- "चार्ट डेटा"
- "वर्कबुक सेल"
- "डेटा लेबल"
- "वर्कशीट"
- "डेटा स्रोत"
- "बाहरी वर्कबुक"
- "बाहरी डेटा"
- "चार्ट कैश"
- "वर्कबुक पुनर्प्राप्ति"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET को खोजें: PowerPoint और OpenDocument फ़ॉर्मैट्स में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपकी प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रिम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और असाइन करें, एक चार्ट से जुड़े बाहरी वर्कबुक का पाथ प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित करें।

वह वर्कबुक सेल्स जो अनुपलब्ध डेटा का प्रतिनिधित्व करते हैं, उसके लिए देखें [Control the Display of Empty Cells](/slides/hi/net/chart-series/) जिसमें खाली सेल और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शित मोड्स की लाइन-चार्ट तुलना दी गई है।

## **छिपी पंक्तियों और कॉलमों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और कॉलमों से डेटा प्लॉट करने के लिये या न करने के लिये नियंत्रित करने हेतु [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) का उपयोग करें। केवल दृश्य सेल्स को प्लॉट करने के लिये `true` सेट करें, या दृश्य तथा छिपे दोनों सेल्स को शामिल करने के लिये `false` सेट करें। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या कॉलमों को छिपाती या दिखाती नहीं है।

[sample presentation](hidden-source-data.pptx) में पहली स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और कॉलम C छिपे हुए हैं, लेकिन उनके सेल्स अभी भी मान रखते हैं।

| वर्कशीट पंक्ति | A: माह | B: खुदरा | C: थोक (छिपा कॉलम) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत सेल्स तक पहुँचने के लिये [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) का उपयोग करें और उनके छिपे होने की स्थिति का निरीक्षण करने के लिये [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) पढ़ें। यह प्रॉपर्टी केवल‑पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्य है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे कॉलम से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करेगा।

इस उदाहरण के लिये, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड वर्कबुक को [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) से रखें और उसे [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) से पुनः लोड करें। सभी सेल्स को शामिल करने के लिये, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने हेतु [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने हेतु पर्याप्त नहीं है।

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

        // एम्बेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण दो संस्करणों की प्रस्तुति सहेजता है: एक जिसमें केवल दृश्य खुदरा मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की छवियां सहेजी गई प्रस्तुतियों को पुनः खोलने के बाद रेंडर की गई हैं; दोनों फ़ाइलें अपनी नियत प्लॉटिंग सेटिंग को संरक्षित करती हैं। पंक्ति 3 और कॉलम C दोनों एम्बेडेड वर्कबुक में छिपे रहे हैं।

| केवल दिखाई देने वाले सेल (`true`) | सभी सेल (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मानधारी सेल जिसमें मान है, वह खाली सेल से भिन्न है। [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) नियंत्रित करता है कि अनुपलब्ध मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या छोड़ता नहीं है। उदाहरण के लिये देखें [Control the Display of Empty Cells](/slides/hi/net/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट का डेटा रेंज प्राप्त करें**

किसी मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले स्रोत रेंज की जाँच करें ताकि पता चल सके कि प्रत्येक चार्ट किन वर्कशीट सेल्स का उपयोग करता है। [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) मेथड वर्तमान डेटा रेंज को वर्कशीट‑योग्य फॉर्मूले के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` A1 से D5 तक के सेल्स को सम्मिलित करता है। डॉलर चिह्न निरपेक्ष पंक्ति और कॉलम संदर्भ दर्शाते हैं।

यह मेथड चार्ट या उसके वर्कबुक को बदले बिना वर्तमान रेंज पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता है, तो यह [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकेगा। अधिक जानकारी के लिये देखें [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकृतियों की जाँच करता है ताकि चार्ट मिलें। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर जारी रहता है।

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

Aspose.Slides for .NET प्रदान करता है [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells से संपादित डेटा हो) को पढ़ने और लिखने की सुविधा देते हैं। **Note** कि चार्ट डेटा को उसी तरह व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण पहली स्लाइड की पहली आकृति के रूप में एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह एम्बेडेड वर्कबुक को एक स्ट्रीम में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, तथा वही वर्कबुक फिर से लिखता है। परिवर्तन मेमोरी में रहता है; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बरकरार रखता है। यह असंगति [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को चार्ट में लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड की पहली आकृति के रूप में एक चार्ट का उपयोग करता है। टिप्पणी दर्शाती है कि जहाँ वर्कबुक संपादन होगा; चलायमान उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को सत्यापित करता है।

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

    // वर्कबुक स्ट्रीम को यहाँ संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

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

संग्रहों को साफ़ करने से वर्कबुक वापस लिखने से पहले पुराने डेटा रेफरेंसेस हट जाते हैं। अपडेटेड वर्कबुक के लिये आवश्यक कोई भी श्रृंखला और श्रेणी मैपिंग को पुनः बनाएँ, फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल्स के लिये कस्टम नंबर फॉर्मेट सेट करें**

[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) का उपयोग करके आप नियंत्रित कर सकते हैं कि संख्यात्मक मान एम्बेडेड वर्कबुक में चार्ट में कैसे दिखाए जाएँ। उदाहरण के लिये, एक रिपोर्ट को परिवर्तन दर को प्रतिशत में चार दशमलव स्थानों के साथ और गुणांक को पाँच दशमलव स्थानों के साथ दिखाने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

नंबर फॉर्मेट केवल प्रदर्शित करता है, संग्रहीत मान नहीं बदलता। फॉर्मेट `0.0000%` `0.125` को `12.5000%` दिखाएगा; यह संग्रहीत संख्या को `12.5` नहीं बदलता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फॉर्मेट खाली स्ट्रिंग (`""`) है, तो [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसकी सेल्स तक पहुँचता है [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से। वर्कशीट 0 में, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों सेल्स चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फॉर्मेट से जुड़ी वैल्यू लेबल्स को भी सक्षम करता है।

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

वर्कबुक सेल फॉर्मेट्स चार्ट एक्सिस या डेटा लेबल्स पर सीधे सेट किए गए फॉर्मेट्स से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपने स्रोत सेल के मान को दिखाता है क्योंकि [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) सक्षम है, और स्रोत नंबर फॉर्मेट का अनुसरण करता है क्योंकि [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true` है। सहेजने और प्रस्तुति को पुनः खोलने के बाद, लेबल्स `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दर्शाया गया है। वर्टिकल एक्सिस अपना स्वयं का [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00` उपयोग करता है, तथा [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) `false` है।

डेटा लेबल को स्वतंत्र रूप से फॉर्मेट करने के लिये, उसके स्रोत‑लिंक फ्लैग को `false` सेट करें और उसका [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) असाइन करें। यह वर्कबुक सेल के फॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फॉर्मेट `0.00` पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दिखाएगा। सीधे लेबल फॉर्मेटिंग के लिये देखें [Chart Data Labels](/slides/hi/net/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में एक बबल चार्ट डिफ़ॉल्ट डेटा के साथ जोड़ता है। यह वर्कशीट 0 की सेल्स A10:A12 को पहली श्रृंखला के पहले तीन लेबल्स के लिये उपयोग करता है, सेल‑आधारित लेबल्स को सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) प्रॉपर्टी आपको चार्ट वर्कबुक में वर्कशीट्स तक पहुंच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

श्रृंखला बिंदु मान सीधे संख्यात्मक लिटरल्स के रूप में भी संग्रहीत किए जा सकते हैं। पूर्ण उदाहरण के लिये देखें [Set Series Values Using Numeric Literals](/slides/hi/net/chart-series/#set-series-values-using-numeric-literals) जिसमें वे सहेजे और पढ़े जाते हैं। बिंदु मानों का स्रोत प्रकार चार्ट की आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग है; संख्यात्मक लिटरल्स का उपयोग स्वयं एम्बेडेड वर्कबुक को नहीं हटाता।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम अलग-अलग डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा नाम वर्कशीट 0 के सेल C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) एन्नुमरेशन प्रत्येक नाम के लिये स्रोत चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फॉर्मेट्स का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फॉर्मेट का समर्थन नहीं करता। आप [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) पर [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) एन्नुमरेशन के साथ उपयोग करके असमर्थित फॉर्मेट्स का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकृतियों की जाँच करता है, गैर‑चार्ट आकृतियों को छोड़ता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिये एक निदान संदेश प्रिंट करता है।

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

    // समर्थित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिये डेटा स्रोत के रूप में बाहरी वर्कबुक्स के उपयोग को समर्थन देता है।

### **बाहरी वर्कबुक बनाएँ**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का उपयोग करके एक एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसका वर्कबुक निर्यात करता है। यह आउटपुट स्ट्रिम को बंद करता है, फिर बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, और लिंक्ड प्रस्तुति को सहेजता है।

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

### **बाहरी वर्कबुक असाइन करें**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) मेथड का उपयोग करके आप एक चार्ट को उसके डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक का पाथ अपडेट करने (यदि उसे स्थानांतरित किया गया हो) के लिये भी उपयोग किया जा सकता है।

हालाँकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसी वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिये सापेक्ष पाथ प्रदान किया गया है, तो उसे स्वचालित रूप से पूर्ण पाथ में बदल दिया जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसमें वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो।

* जब `updateChartData` `false` हो, केवल वर्कबुक पाथ अपडेट किया जाता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता, इसलिए वर्कबुक अनुपलब्ध हो सकती है।
* जब `updateChartData` `true` हो, चार्ट डेटा लक्ष्य वर्कबुक से अपडेट किया जाता है।

निम्न उदाहरण एक प्लेसहोल्डर URL को `updateChartData` को `false` सेट करके असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बनाए रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट का बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करें**

किसी चार्ट से जुड़े वर्कबुक को पहचानने के लिये, जांचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पाथ प्राप्त करें।

यह उदाहरण प्रस्तुति की पहली स्लाइड पर पहला आकृति जांचता है जिसमें एक लिंक्ड बाहरी वर्कबुक है। यदि यह एक चार्ट है जो बाहरी वर्कबुक से लिंक्ड है, तो उदाहरण कंसोल पर [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) प्रिंट करता है। फिर वह प्रस्तुति की एक कॉपी सहेजता है।

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

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक के साथ करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड पर पहला आकृति के रूप में एक चार्ट का उपयोग करता है और वह एक सुलभ बाहरी वर्कबुक से लिंक्ड है। यह पहली श्रृंखला के पहले डेटा बिंदु के सेल‑बैक्ड मान को 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए यदि मूल वर्कबुक को सुरक्षित रखना है तो एक कॉपी का उपयोग करें।

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

Aspose.Slides for .NET 26.11 ने एक चार्ट के लिये [IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) और प्रस्तुति के लिये [IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) जोड़ा है। स्रोत वर्कबुक मान बदलने के बाद उनका उपयोग करें। बाहरी वर्कबुक्स पहुंच योग्य और समर्थित होने चाहिए।

[Aspose.Slides for .NET](/slides/hi/net/installation/) 26.11 या बाद के संस्करण स्थापित होने पर, यह उदाहरण `charts.pptx` की पहली स्लाइड पर पहले चार्ट को रीफ़्रेश करता है। उसका स्रोत वर्कबुक उपलब्ध होना चाहिए। अपडेटेड चार्ट डेटा को बनाये रखने के लिये परिणाम को सहेजें।

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

सभी चार्ट्स को रीफ़्रेश करने हेतु, एक अलग प्रस्तुति इंस्टेंस के साथ नीचे दिखाए अनुसार उपयोग करें। `false` पास करने से रीफ़्रेश विफलता कॉलर को प्रसारित होती है; यह पहले से रीफ़्रेश किए गए चार्ट्स को रोल‑बैक नहीं करता।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

पैरामीटर का डिफ़ॉल्ट `true` है: [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) विफल चार्ट को स्किप करता है और अन्य के साथ जारी रखता है। यह प्रति‑चार्ट परिणाम नहीं लौटाता, इसलिए पूर्ण कॉल यह सिद्ध नहीं करता कि प्रत्येक चार्ट रीफ़्रेश हुआ। यदि आपको प्रत्येक विफल चार्ट पहचानना है, तो व्यक्तिगत [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) कॉल्स का उपयोग करें।

रीफ़्रेश स्रोत डेटा को पुनः लोड करता है। यह फॉर्मूला गणना, चार्ट लेआउट वैधीकरण और OLE प्रीव्यू अपडेट से अलग है। मेमोरी में रीफ़्रेश की जाँच के लिये लाइव सेल‑बैक्ड मान निरीक्षण करें। एक [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) अभी भी पहले सहेजे चार्ट को वर्णित कर सकता है जब तक आप प्रस्तुति को सहेज कर पुनः नहीं खोलते।

### **वर्कबुक के बिना कैश्ड चार्ट मान पढ़ें**

.NET 26.11 में, कैश्ड‑वैल्यू एक्सेसर्स चार्ट के साथ संग्रहीत मानों को वर्कबुक खोले बिना पढ़ते हैं। ये तब उपयोगी होते हैं जब लिंक्ड फ़ाइल अनुपलब्ध हो और आपको केवल चार्ट का अंतिम संग्रहीत डेटा चाहिए। यह नीचे दिए गए रिकवरी विकल्प से वर्कबुक पुनर्निर्माण से अलग है।

| ऑब्जेक्ट | कैश्ड एक्सेसर |
| --- | --- |
| सामान्य श्रृंखला डेटा बिंदु | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| स्कैटर या बबल डेटा बिंदु | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| बबल डेटा बिंदु | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| चार्ट श्रेणी | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

प्रत्येक एक्सेसर [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/) लौटाता है। [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) संग्रहीत ऑब्जेक्ट को उजागर करता है; [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) टेक्स्ट देती है; [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) अनुपलब्ध या गैर‑संख्यात्मक मान के लिये `NaN` लौटाता है। एक कैश अनुपलब्ध या पुराना हो सकता है, जिसमें अभी-अभी बनाया गया चार्ट भी शामिल है जिसे अभी तक सहेजा नहीं गया। यह न मानें कि हर फ़ील्ड मौजूद है या संख्या रखती है।

यह उदाहरण `cached-chart.pptx` से उन सभी फ़ील्ड को पढ़ता है, जो चार्ट्स वाली एक सहेजी गई प्रस्तुति है। एक अनुपलब्ध बाहरी वर्कबुक स्वीकार्य है क्योंकि कोड [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) या लाइव वर्कबुक सेल्स तक नहीं पहुँचता।

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

जब आपको वर्तमान स्रोत डेटा चाहिए तब रीफ़्रेश का उपयोग करें; जब संग्रहीत स्नैपशॉट पर्याप्त हो तब कैश्ड रीड्स का उपयोग करें। कैश वर्कबुक की पूर्ण कॉपी नहीं होती और अंतिम अपडेट के बाद किए गए परिवर्तन प्रदान नहीं कर सकती।

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गुम है, तो Aspose.Slides प्रस्तुति में कैश्ड डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) बनाएं, उसकी [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) को `true` सेट करें।

निम्न C# उदाहरण एक चार्ट के लिये वर्कबुक डेटा पुनः प्राप्त करता है जो पहली स्लाइड की पहली आकृति है और एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है। यह पुनः प्राप्त डेटा को [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) और [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

    // पुनः प्राप्त वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

यदि कोड बाहरी वर्कबुक तक पहुंचता है जबकि वह अनुपलब्ध है और रिकवरी अक्षम है, तो Aspose.Slides एक [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकेगा। केवल तब रिकवरी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य बैकअप हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तन शामिल नहीं हो सकते।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। एक चार्ट की [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) और एक [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) होती है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के लिये सापेक्ष पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पाथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पाथ में बदल जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पाथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**

हां, ऐसी वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक्स को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक को अपरिवर्तित रखना है तो उसकी एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित हो तो मैं क्या करूं?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिये [Aspose.Cells](https://reference.aspose.com/cells/net/) का उपयोग करके) और फिर उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट्स पर प्रतिबिंबित होगा।