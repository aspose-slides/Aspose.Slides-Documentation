---
title: .NET में प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/net/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET को खोजें: PowerPoint और OpenDocument फॉर्मैट में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपनी प्रस्तुति डेटा को सुगम बनाएँ."
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि कैसे वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को पढ़ा और लिखा जा सकता है, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाता है, वर्कशीट कलेक्शन्स तक पहुंच प्राप्त की जाती है, और चार्ट मूल्यों के लिए डेटा स्रोत प्रकार को निर्दिष्ट किया जाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने के बारे में भी बताता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाता है, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाता है, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाता है।

गुम डेटा का प्रतिनिधित्व करने वाले वर्कबुक सेल्स के लिए, खाली सेल और शून्य के बीच अंतर तथा उपलब्ध डिस्प्ले मोड्स की लाइन‑चार्ट तुलना के लिए देखें [Control the Display of Empty Cells](/slides/hi/net/chart-series/)।

## **छिपी पंक्तियों और कॉलमों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और कॉलमों से डेटा प्लॉट किया जाए या न हो, इसे नियंत्रित करने के लिए [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) का उपयोग करें। केवल दृश्यमान सेल्स को प्लॉट करने के लिए इसे `true` सेट करें, या दृश्यमान और छिपे दोनों सेल्स को शामिल करने के लिए `false`। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या कॉलमों को छिपाती या प्रदर्शित नहीं करती।

[उदाहरण प्रस्तुति](hidden-source-data.pptx) में पहले स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में स्रोत रेंज `A1:C4` है। पंक्ति 3 और कॉलम C छिपे हुए हैं, लेकिन उनकी सेल्स में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: थोक (छिपा कॉलम) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छुपी पंक्ति) | फरवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत सेल्स तक पहुंचने के लिए [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) का उपयोग करें और उनकी छिपी स्थिति का निरीक्षण करने के लिए [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) पढ़ें। यह प्रॉपर्टी केवल‑पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे कॉलम से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड वर्कबुक को [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) से रखिए और उसे [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) से पुनः लोड कीजिए। सभी सेल्स को शामिल करते समय, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने के लिए [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का भी उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए अपर्याप्त है।

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
            // छिपी श्रेणियों सहित संपूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

यह उदाहरण दो संस्करणों में प्रस्तुति को सहेजता है: एक केवल दृश्यमान रिटेल मान (10 और 20) के साथ, और दूसरा सभी छह मानों के साथ। नीचे दी गई छवियां सहेजी गई प्रस्तुतियों को पुनः खोलने के बाद रेंडर की गई हैं; दोनों फ़ाइलें अपनी सेट की गई प्लॉटिंग सेटिंग को बनाए रखती हैं। पंक्ति 3 और कॉलम C दोनों एम्बेडेड वर्कबुक में छिपे हुए रहते हैं।

| केवल दृश्यमान सेल्स (`true`) | सभी सेल्स (`false`) |
| --- | --- |
| ![केवल दृश्यमान सेल्स: जनवरी और मार्च के लिए रिटेल मान 10 और 20.](hidden_cells_True.png) | ![सभी सेल्स: जनवरी, फरवरी, और मार्च के लिए रिटेल और थोक मान.](hidden_cells_False.png) |

एक मान वाला छिपा सेल खाली सेल से अलग होता है। [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) नियंत्रित करता है कि गुम मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [Control the Display of Empty Cells](/slides/hi/net/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट के डेटा रेंज को प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंजेज़ की जांच करें ताकि यह पहचान सकें कि प्रत्येक चार्ट कौन-से वर्कशीट सेल्स का उपयोग करता है। [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) मेथड वर्तमान डेटा रेंज को वर्कशीट‑क्वालिफाइड फ़ॉर्मूला के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` उसे सेल रेंज से अलग करता है, और `$A$1:$D$5` A1 से D5 तक के सेल्स को सम्मिलित करता है। डॉलर साइन निरपेक्ष पंक्ति और कॉलम रेफ़रेंस को दर्शाते हैं।

यह मेथड चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक उपयोग नहीं करता, तो यह [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) उत्पन्न करता है। अधिक जानकारी के लिए देखें [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकारों को जांचता है कि कौन‑से चार्ट हैं। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर जाता है।

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

Aspose.Slides for .NET [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells से संपादित डेटा होता है) को पढ़ने और लिखने की सुविधा देता है। **Note** कि चार्ट डेटा को उसी प्रकार व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण पहली स्लाइड की पहली आकृति पर एक चार्ट वाले प्रस्तुति का उपयोग करता है। यह एम्बेडेड वर्कबुक को स्ट्रीम में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में बने रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट की पुष्टि करें**

जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी कलेक्शन को बरकरार रखता है। यह असंगति [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) को इंडेक्स‑आउट‑ऑफ‑रेंज त्रुटि के साथ फेल कर सकती है। अपडेटेड वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहली आकृति के रूप में एक चार्ट का उपयोग करता है। टिप्पणी उस स्थान को दर्शाती है जहाँ वर्कबुक संपादन होगा; रन करने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

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

    // यहाँ वर्कबुक स्ट्रीम को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके.

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

कलेक्शन को साफ़ करने से वर्कबुक को वापस लिखने से पहले पुराने डेटा रेफ़रेंसेज़ हट जाते हैं। अपडेटेड वर्कबुक के लिए आवश्यक सीरीज़ और श्रेणी मैपिंग को फिर से बनाएं इससे पहले कि आप चार्ट का उपयोग करें।

## **वर्कबुक सेल्स के लिए कस्टम नंबर फॉर्मैट सेट करें**

चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक मूल्यों की प्रस्तुति को नियंत्रित करने के लिए [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) का उपयोग करें। उदाहरण के लिये, एक रिपोर्ट को प्रतिशत के रूप में चार दशमलव स्थान और एक गुणांक को पाँच दशमलव स्थान के साथ दिखाना पड़ सकता है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिए उपलब्ध रहें।

नंबर फॉर्मैट केवल प्रस्तुति को बदलता है, संग्रहीत मान नहीं। फॉर्मैट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बनाता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को राउंड किए। यदि कस्टम फॉर्मैट एक खाली स्ट्रिंग (`""`) है, तो [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसके सेल्स को [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है। वर्कशीट 0 में, B2 में रूपांतरण दर और C2 में गुणांक है। दोनों सेल्स चार्ट मूल्यों को प्रदान करते हैं। उदाहरण स्रोत फॉर्मैट से जुड़े मान लेबल को भी सक्षम करता है।

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

वर्कबुक सेल फॉर्मैट्स चार्ट अक्षों या डेटा लेबल्स पर सीधे सेट किए गए फॉर्मैट्स से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपना स्रोत सेल मान दिखाता है क्योंकि [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) सक्षम है, और स्रोत नंबर फॉर्मैट का पालन करता है क्योंकि [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true` है। प्रस्तुति को सहेजने और पुनः खोलने के बाद, लेबल `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। ऊर्ध्वाधर अक्ष अपना स्वयं का [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00` उपयोग करता है, और [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) `false` है।

किसी डेटा लेबल को स्वतंत्र रूप से फॉर्मैट करने के लिए, उसके स्रोत‑लिंक फ़्लैग को `false` सेट करें और उसका [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) असाइन करें। यह वर्कबुक सेल के फॉर्मैट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फॉर्मैट `0.00` पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दिखाएगा। सीधे लेबल फॉर्मैटिंग के लिए देखें [Chart Data Labels](/slides/hi/net/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![स्रोत‑लिंक्ड लेबल वाले कॉलम चार्ट जो 12.5000% और 0.12346 दिखाते हैं और स्वतंत्र रूप से फॉर्मैट किए गए संख्यात्मक अक्ष.](custom-cell-formats.png)

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में एक बबल चार्ट जोड़ता है जिसमें डिफ़ॉल्ट डेटा होता है। यह वर्कशीट 0 में सेल्स A10:A12 को पहली सीरीज़ के पहले तीन लेबल्स के लिए उपयोग करता है, सेल‑बेस्ड लेबल्स को सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **वर्कशीट्स प्रबंधित करें**

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) प्रॉपर्टी चार्ट वर्कबुक में मौजूद वर्कशीट्स तक पहुंच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा वाला एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट नाम को कंसोल पर प्रिंट करता है।

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

सीरीज़ पॉइंट मानों को सीधे संख्यात्मक लिटेरल्स के रूप में भी संग्रहीत किया जा सकता है। पूर्ण उदाहरण के लिए देखें [Set Series Values Using Numeric Literals](/slides/hi/net/chart-series/#set-series-values-using-numeric-literals) जो उन्हें सहेजता और पढ़ता है। पॉइंट मानों का स्रोत प्रकार चार्ट की आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग है; संख्यात्मक लिटेरल्स का उपयोग स्वयं एम्बेडेड वर्कबुक को नहीं हटाता।

यह उदाहरण डिफ़ॉल्ट डेटा वाला एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नाम अलग-अलग डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटेरल का उपयोग करता है; दूसरा वर्कशीट 0 के सेल C1 का उपयोग करता है। [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) एन्‍युमेरेशन प्रत्येक नाम के स्रोत को चुनता है। उदाहरण अद्यतन सीरीज़ नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फॉर्मैट्स का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फॉर्मैट को सपोर्ट नहीं करता जो कुछ चार्ट्स में एम्बेड हो सकते हैं। आप [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) पर [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) एन्‍युमेरेशन के साथ उपयोग करके असमर्थित फॉर्मैट्स का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों को निरीक्षित करता है, गैर‑चार्ट आकारों को छोड़ता है, और एम्बेडेड .xlsb वर्कबुक वाले प्रत्येक चार्ट के लिए एक निदान संदेश प्रिंट करता है।

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

    // यहाँ समर्थित चार्ट वर्कबुक डेटा पढ़ें या संशोधित करें।
}
```

## **बाह्य वर्कबुक**

Aspose.Slides चार्ट्स के डेटा स्रोत के रूप में बाह्य वर्कबुक का उपयोग समर्थन करता है।

### **बाह्य वर्कबुक बनाएं**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाह्य वर्कबुक से जोड़ें।

यह उदाहरण डिफ़ॉल्ट डेटा वाला एक पाई चार्ट बनाता है और उसकी वर्कबुक को निर्यात करता है। यह आउटपुट स्ट्रीम को बंद करता है इससे पहले कि बाह्य वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन किया जाए, फिर लिंक्ड प्रस्तुति को सहेजता है।

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

### **बाह्य वर्कबुक सेट करें**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) मेथड का उपयोग करके आप एक बाह्य वर्कबुक को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाह्य वर्कबुक का पथ अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

जबकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को सीधे संपादित नहीं कर सकते, फिर भी आप ऐसे वर्कबुक को बाह्य डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाह्य वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाह्य वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और A1:B4 को एक सीरीज़ और तीन श्रेणियों के रूप में मैप करने के लिए [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` होता है, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध हो सकता है।
* जब `updateChartData` `true` होता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

निम्न उदाहरण प्लेसहोल्डर URL को `updateChartData` `false` के साथ असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट के बाह्य डेटा स्रोत वर्कबुक पथ को प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक की पहचान करने के लिए, जांचें कि क्या चार्ट बाह्य डेटा स्रोत उपयोग करता है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण प्रस्तुति की पहली स्लाइड पर पहले आकार को जांचता है जो बाह्य वर्कबुक से लिंक्ड है। यदि यह बाह्य वर्कबुक से लिंक्ड चार्ट है, तो यह कंसोल पर [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) प्रिंट करता है। फिर यह प्रस्तुति की एक प्रति सहेजता है।

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

आप बाह्य वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक के सामग्री को बदलते हैं। जब कोई बाह्य वर्कबुक लोड नहीं की जा सकती, तो एक अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड पर पहली आकृति के रूप में एक चार्ट का उपयोग करता है जो एक सुलभ बाह्य वर्कबुक से जुड़ा है। यह पहली सीरीज़ के पहले डेटा पॉइंट के सेल‑बैक्ड मान को 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाह्य XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिए कॉपी का उपयोग करें।

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

### **चार्ट कैश से वर्कबुक को पुनर्प्राप्त करें**

यदि कोई चार्ट ऐसी बाह्य वर्कबुक का उपयोग करता है जो अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश्ड डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) बनाइए, उसके [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) को कॉन्फ़िगर कीजिए, और प्रस्तुति खोलने से पहले [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) को `true` सेट कीजिए।

निम्न C# उदाहरण प्रथम स्लाइड पर प्रथम आकृति वाले चार्ट के लिए वर्कबुक डेटा को पुनर्प्राप्त करता है जो अनुपलब्ध बाह्य वर्कबुक को संदर्भित करता है। यह पुनर्प्राप्त डेटा को [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) और [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

    // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

यदि बाह्य वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति निष्क्रिय है, तो Aspose.Slides एक [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकता है। पुनर्प्राप्ति तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाह्य वर्कबुक में किए गए परिवर्तनों का समावेश नहीं हो सकता।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट की [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) और [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) होती है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं यह सुनिश्चित करने के लिए कि बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाह्य वर्कबुक के सापेक्ष पथ समर्थित हैं, और कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाह्य डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे दूरस्थ वर्कबुक को संपादित करना समर्थित नहीं है—इन्हें केवल स्रोत के रूप में उपयोग किया जा सकता है।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाह्य XLSX को ओवरराइट करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो वर्कबुक की कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड है तो क्या करें?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। आम तौर पर पहले सुरक्षा हटा दें या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/net/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाह्य वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट प्रतिबिंबित करेंगे।