---
title: .NET में प्रस्तुतियों में चार्ट कार्यपुस्तिकाओं का प्रबंधन
linktitle: चार्ट कार्यपुस्तिका
type: docs
weight: 70
url: /hi/net/chart-workbook/
keywords:
- चार्ट कार्यपुस्तिका
- चार्ट डेटा
- कार्यपुस्तिका कोशिका
- डेटा लेबल
- कार्यपत्रक
- डेटा स्रोत
- बाहरी कार्यपुस्तिका
- बाहरी डेटा
- चार्ट कैश
- कार्यपुस्तिका पुनर्प्राप्ति
- पावरपॉइंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET की खोज करें: PowerPoint और OpenDocument प्रारूपों में चार्ट कार्यपुस्तिकाओं को सहजता से प्रबंधित करके अपनी प्रस्तुति डेटा को सरल बनाएं।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट कार्यपुस्तिकाओं के साथ काम करने के तरीके को समझाता है। यह दर्शाता है कि कार्यपुस्तिका प्रवाहों के माध्यम से चार्ट डेटा को पढ़ा और लिखा जाए, कार्यपुस्तिका कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट संग्रहों तक पहुँचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार को निर्दिष्ट किया जाए।

यह लेख बाहरी कार्यपुस्तिकाओं को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी कार्यपुस्तिका बनाई और असाइन की जाए, चार्ट से जुड़ी बाहरी कार्यपुस्तिका का पथ प्राप्त किया जाए, और कार्यपुस्तिका उपलब्ध होने पर चार्ट डेटा को संपादित किया जाए।

गायब डेटा का प्रतिनिधित्व करने वाली कार्यपुस्तिका कोशिकाओं के लिए, [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/net/chart-series/) देखें — खाली कोशिका और शून्य के बीच अंतर, तथा उपलब्ध प्रदर्शन मोड के लाइन‑चार्ट तुलना के लिए।

## **छुपी हुई पंक्तियों और स्तंभों से डेटा शामिल करें**

[ IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) का उपयोग करें ताकि यह नियंत्रित किया जा सके कि चार्ट छुपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करता है या नहीं। इसे `true` सेट करने पर केवल दृश्यमान कोशिकाएँ प्लॉट होंगी, और `false` सेट करने पर दृश्यमान और छुपी दोनों कोशिकाएँ शामिल होंगी। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छुपाती या दिखाती नहीं है।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहले स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छुपे हुए हैं, लेकिन उनकी कोशिकाएँ अभी भी मान रखती हैं।

| वर्कशीट पंक्ति | A: महीना | B: खुदरा | C: थोक (छुपा हुआ स्तंभ) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से स्रोत कोशिकाओं तक पहुँचें और [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) पढ़कर उनकी छुपी स्थिति की जांच करें। यह गुण केवल‑पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छुपी पंक्ति से संबंधित है, और C2 छुपे स्तंभ से संबंधित है; उदाहरण क्रमशः `False`, `True`, `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ्रेश करें: एम्बेडेड कार्यपुस्तिका को [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) से रखें और उसे [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) से फिर लोड करें। सभी कोशिकाएँ शामिल करने पर, छुपी फ़रवरी श्रेणी को पुनर्स्थापित करने के लिए [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का भी उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रिफ्रेश करने के लिए पर्याप्त नहीं है।

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

        // एम्बेडेड कार्यपुस्तिका से चार्ट डेटा को रिफ्रेश करें।
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // छुपी हुई श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण दो संस्करणों में प्रस्तुति को सहेजता है: एक जिसमें केवल दृश्यमान खुदरा मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की छवियाँ सहेजी गई प्रस्तुतियों को पुनः खोलने के बाद रेंडर की गई हैं; दोनों फ़ाइलें अपनी असाइन की गई प्लॉटिंग सेटिंग को संरक्षित करती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड कार्यपुस्तिकाओं में छुपे रहते हैं।

| केवल दृश्य कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्य कोशिकाएँ: जनवरी और मार्च के लिए खुदरा मान 10 और 20.](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी, और मार्च के लिए खुदरा और थोक मान.](hidden_cells_False.png) |

एक मान वाले छुपे हुए कोशिका का अलग अर्थ है खाली कोशिका से। [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) नियंत्रित करता है कि गायब मान कैसे दिखाए जाएँ; यह छुपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/net/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज प्राप्त करें**

मौजूदा प्रस्तुति में कार्यपुस्तिका डेटा को अपडेट करने से पहले, स्रोत रेंज की जाँच करें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन‑सी वर्कशीट कोशिकाओं का उपयोग करता है। [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) मेथड वर्तमान डेटा रेंज को वर्कशीट‑योग्य फ़ॉर्मूले के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाएँ A1 से D5 तक, सम्मिलित, दर्शाता है। डॉलर संकेत निरपेक्ष पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह मेथड वर्तमान रेंज को पढ़ता है बिना चार्ट या उसकी कार्यपुस्तिका को बदले। यदि चार्ट डेटा स्रोत के रूप में कार्यपुस्तिका का उपयोग नहीं करता, तो यह [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकता है। अधिक जानकारी के लिए देखें [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकृतियों को चार्ट के लिए जाँचता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट कार्यपुस्तिका का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर आगे बढ़ता है।

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

Aspose.Slides for .NET द्वारा प्रदान किए गए [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड आपको चार्ट डेटा कार्यपुस्तिकाओं (जो Aspose.Cells से संपादित किए गए डेटा रखती हैं) को पढ़ने और लिखने की अनुमति देते हैं। **नोट** कि चार्ट डेटा को समान रूप से व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण एक प्रस्तुति का उपयोग करता है जिसमें पहले स्लाइड की पहली आकृति के रूप में एक चार्ट है। यह एम्बेडेड कार्यपुस्तिका को एक स्ट्रीम में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही कार्यपुस्तिका वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को मान्य करें**

जब आप एम्बेडेड कार्यपुस्तिका को संशोधित संस्करण से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बरकरार रखता है। यह असंगति [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) को इंडेक्स‑आउट‑ऑफ‑रेंज त्रुटि के साथ असफल कर सकती है। अपडेटेड कार्यपुस्तिका को चार्ट में लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहले स्लाइड की पहली आकृति के रूप में एक चार्ट का उपयोग करता है। टिप्पणी वह जगह दर्शाती है जहाँ कार्यपुस्तिका संपादन होगा; चलने वाला उदाहरण मूल कार्यपुस्तिका को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

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

    // वर्कबुक स्ट्रीम को यहां संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके.

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

संग्रहों को साफ़ करने से लेखा‑जुड़ा डेटा संदर्भ हट जाता है इससे पहले कि कार्यपुस्तिका वापस लिखी जाए। अपडेटेड कार्यपुस्तिका के लिए आवश्यक श्रृंखला और श्रेणी मैपिंग को पुनः बनाएं फिर चार्ट का उपयोग करें।

## **वर्कबुक कोशिकाओं के लिए कस्टम नंबर फ़ॉर्मेट सेट करें**

[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) का उपयोग करके आप यह नियंत्रित कर सकते हैं कि संख्यात्मक मान एम्बेडेड कार्यपुस्तिका में चार्ट में कैसे दिखें। उदाहरण के लिए, किसी रिपोर्ट को परिवर्तन दर को प्रतिशत के रूप में चार दशमलव स्थानों के साथ और गुणांक को पाँच दशमलव स्थानों के साथ प्रदर्शित करने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिए उपलब्ध रहें।

एक नंबर फ़ॉर्मेट केवल प्रदर्शन बदलता है, संग्रहीत मान नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बनाता। इसी तरह, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसकी कोशिकाओं तक [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से पहुँचता है। वर्कशीट 0 में, B2 परिवर्तन दर रखता है और C2 गुणांक रखता है। दोनों कोशिकाएँ चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़े मान लेबल भी सक्षम करता है।

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

वर्कबुक कोशिका फ़ॉर्मेट चार्ट अक्षों या डेटा लेबलों पर सीधे सेट किए गए फ़ॉर्मेट से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपना स्रोत कोशिका मान दिखाता है क्योंकि [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) सक्षम है, और स्रोत नंबर फ़ॉर्मेट का पालन करता है क्योंकि [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true` है। प्रस्तुति को सहेजने और पुनः खोलने के बाद लेबल `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। ऊर्ध्वाधर अक्ष अपना स्वयं का [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00` उपयोग करता है, और [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) `false` पर सेट है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिए, उसका स्रोत‑लिंक फ़्लैग `false` सेट करें और उसका [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) असाइन करें। यह कार्यपुस्तिका कोशिका के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिए, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दिखाता रहेगा। सीधे लेबल फ़ॉर्मेटिंग के लिए देखें [Chart Data Labels](/slides/hi/net/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![ स्रोत‑लिंक्ड लेबल वाले कॉलम चार्ट जिसमें 12.5000% और 0.12346 दिख रहा है तथा स्वतंत्र रूप से फ़ॉर्मेटेड संख्यात्मक अक्ष.](custom-cell-formats.png)

## **वर्कबुक कोशिका को चार्ट डेटा लेबल के रूप में सेट करें**

आप कार्यपुस्तिका कोशिकाओं से टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण एक मौजूदा प्रस्तुति के पहले स्लाइड में डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह कार्यपुस्तिका 0 की कोशिकाएँ A10:A12 को पहले श्रृंखला के पहले तीन लेबल के रूप में उपयोग करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) गुण आपको चार्ट कार्यपुस्तिका में मौजूद वर्कशीट्स तक पहुँच प्रदान करता है। यह उदाहरण एक डिफ़ॉल्ट डेटा वाले पाई चार्ट को बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा वाले 3D कॉलम चार्ट को बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल से लिया जाता है; दूसरा कार्यपुस्तिका 0 की कोशिका C1 से। [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) एन्नुमरेशन प्रत्येक नाम के स्रोत का चयन करता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित एम्बेडेड कार्यपुस्तिका फ़ॉर्मेट्स का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेड किए जा सकने वाले Excel बाइनरी कार्यपुस्तिका (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) गुण को [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) के साथ [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) एन्नुमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट्स का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति के पहले स्लाइड पर आकृतियों को इन्स्पेक्ट करता है, गैर‑चार्ट आकृतियों को छोड़ता है, और प्रत्येक एम्बेडेड .xlsb कार्यपुस्तिका वाले चार्ट के लिए एक निदान संदेश प्रिंट करता है।

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

    // समर्थित चार्ट कार्यपुस्तिका डेटा को यहाँ पढ़ें या संशोधित करें।
}
```

## **बाहरी कार्यपुस्तिका**

Aspose.Slides चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी कार्यपुस्तिकाओं का उपयोग समर्थन करता है।

### **एक बाहरी कार्यपुस्तिका बनाएं**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का उपयोग करके एम्बेडेड चार्ट कार्यपुस्तिका को फ़ाइल में एक्सपोर्ट करें और चार्ट को उस बाहरी कार्यपुस्तिका से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा वाले एक पाई चार्ट को बनाता है और उसकी कार्यपुस्तिका को एक्सपोर्ट करता है। यह आउटपुट स्ट्रीम को बंद करता है फिर बाहरी कार्यपुस्तिका को चार्ट डेटा स्रोत के रूप में असाइन करता है, और फिर लिंक्ड प्रस्तुति को सहेजता है।

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

### **एक बाहरी कार्यपुस्तिका सेट करें**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) मेथड का उपयोग करके आप एक बाहरी कार्यपुस्तिका को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। इस मेथड का उपयोग बाहरी कार्यपुस्तिका के पथ को अपडेट करने के लिए भी किया जा सकता है (यदि उसे स्थानांतरित किया गया है)।

आप रिमोट लोकेशन या संसाधनों में संग्रहीत कार्यपुस्तिकाओं को संपादित नहीं कर सकते, लेकिन फिर भी उन्हें बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी कार्यपुस्तिका के लिए सापेक्ष पथ प्रदान किया जाता है, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी कार्यपुस्तिका का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, कार्यपुस्तिका को लिंक करता है, और [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों के रूप में मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का `updateChartData` पैरामीटर नियंत्रित करता है कि कार्यपुस्तिका लोड की जाए या नहीं।

* जब `updateChartData` `false` है, केवल कार्यपुस्तिका पथ अपडेट होता है। चार्ट डेटा लक्ष्य कार्यपुस्तिका से लोड या अपडेट नहीं होता, इसलिए कार्यपुस्तिका अनुपलब्ध हो सकती है।
* जब `updateChartData` `true` है, चार्ट डेटा लक्ष्य कार्यपुस्तिका से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `false` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध कार्यपुस्तिका को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट की बाहरी डेटा स्रोत कार्यपुस्तिका पथ प्राप्त करें**

किसी चार्ट से जुड़े कार्यपुस्तिका की पहचान करने के लिए, जाँचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका कार्यपुस्तिका पथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति के पहले स्लाइड की पहली आकृति को इन्स्पेक्ट करता है जिसमें एक लिंक्ड बाहरी कार्यपुस्तिका है। यदि यह एक चार्ट है जो बाहरी कार्यपुस्तिका से जुड़ा है, तो उदाहरण [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) को कंसोल पर प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

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

आप बाहरी कार्यपुस्तिकाओं में डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक कार्यपुस्तिकाओं में करते हैं। जब कोई बाहरी कार्यपुस्तिका लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

यह उदाहरण एक चार्ट का उपयोग करता है जो पहले स्लाइड की पहली आकृति है और एक सुलभ बाहरी कार्यपुस्तिका से लिंक्ड है। यह पहले श्रृंखला के पहले डेटा पॉइंट की कोशिका‑बैक्ड वैल्यू को 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। कोशिका मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल कार्यपुस्तिका को संरक्षित रखने के लिए एक कॉपी का उपयोग करें।

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

### **चार्ट कैश से कार्यपुस्तिका पुनर्प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी कार्यपुस्तिका का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश्ड डेटा से चार्ट कार्यपुस्तिका को पुनः बनाता है। [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) बनाएं, उसका [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) कॉन्फ़िगर करें, और खोलने से पहले [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) को `true` सेट करें।

निम्न C# उदाहरण एक चार्ट के लिए कार्यपुस्तिका डेटा को पुनर्प्राप्त करता है जो पहले स्लाइड की पहली आकृति है और एक अनुपलब्ध बाहरी कार्यपुस्तिका का संदर्भ देता है। यह पुनर्प्राप्त डेटा को [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) और [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true;
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions;
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // यहाँ पुनः प्राप्त कार्यपुस्तिका डेटा को पढ़ें या संशोधित करें।
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

यदि बाहरी कार्यपुस्तिका अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकता है। पुनर्प्राप्ति केवल तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य फ़ॉलबैक हो, क्योंकि कैश में बाहरी कार्यपुस्तिका में किए गए परिवर्तनों को शामिल नहीं किया गया हो सकता है।

## **FAQ**

**क्या मैं यह निर्धारित कर सकता हूं कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड कार्यपुस्तिका से लिंक है?**

हां। एक चार्ट का एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) और एक [बाहरी कार्यपुस्तिका का पथ](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) होता है; यदि स्रोत एक बाहरी कार्यपुस्तिका है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि एक बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी कार्यपुस्तिकाओं के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप एक सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए कार्यपुस्तिका को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित कार्यपुस्तिकाओं का उपयोग कर सकता हूं?**

हां, ऐसे कार्यपुस्तिकाओं को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधा रिमोट कार्यपुस्तिका संपादन समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो कार्यपुस्तिका की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करें?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका यह है कि पहले सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/net/) का उपयोग करके) और उस कॉपी से लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी कार्यपुस्तिका का संदर्भ दे सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट पर प्रभाव पड़ेगा।