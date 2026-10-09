---
title: .NET में प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/net/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक कोशिका
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
description: "Aspose.Slides for .NET को खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपनी प्रस्तुति डेटा को व्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने का तरीका बताता है। यह वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट संग्रहों तक पहुंचने, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने को दिखाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाई और असाइन की जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाए।

जो वर्कबुक कोशिकाएँ अनुपलब्ध डेटा का प्रतिनिधित्व करती हैं, उनके लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/net/chart-series/) ताकि खाली कोशिका और शून्य के बीच अंतर और उपलब्ध प्रदर्शन मोड की लाइन-चार्ट तुलना समझी जा सके।

## **छिपी हुई पंक्तियों और कॉलमों से डेटा शामिल करना**

छिपी हुई वर्कशीट पंक्तियों और कॉलमों से डेटा प्लॉट करे या न करे, इसे नियंत्रित करने के लिए [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) का उपयोग करें। केवल दृश्य कोशिकाओं को प्लॉट करने के लिए इसे `true` सेट करें, या दृश्य एवं छिपी हुई दोनों कोशिकाओं को शामिल करने के लिए `false` सेट करें। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या कॉलमों को छिपाती या दिखाती नहीं है।

[sample presentation](hidden-source-data.pptx) में पहले स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज है, `A1:C4`। पंक्ति 3 और कॉलम C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: थोक (छिपी हुई कॉलम) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छुपी हुई पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुंचने के लिए [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) का उपयोग करें और उनके छिपे होने की स्थिति को जांचने के लिए [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) पढ़ें। यह प्रॉपर्टी केवल-पढ़ने योग्य है। इस फ़ाइल में, B2 दिखने योग्य है, B3 छिपी हुई पंक्ति से संबंधित है, और C2 छिपे हुए कॉलम से संबंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा रीफ़्रेश करें: एम्बेडेड वर्कबुक को [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) से रखें और इसे [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) से पुनः लोड करें। सभी कोशिकाओं को शामिल करने पर, छिपी हुई फ़रवरी श्रेणी को पुनर्स्थापित करने के लिए [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

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

        // एम्बेडेड वर्कबुक से चार्ट डेटा रीफ़्रेश करें।
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // छिपी हुई श्रेणियों सहित पूर्ण स्रोत रेंज पुनर्स्थापित करें।
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

उदाहरण दो संस्करणों में प्रस्तुति को सहेजता है: एक जिसमें केवल दिखाई देने वाले रिटेल मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की छवियाँ सहेजी गई प्रस्तुतियों को पुनः खोलने के बाद रेंडर की गई हैं; दोनों फ़ाइलें अपने असाइन की गई प्लॉटिंग सेटिंग को बरकरार रखती हैं। पंक्ति 3 और कॉलम C दोनों एम्बेडेड वर्कबुक में छिपे रहेंगे।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाला छिपा हुआ कोशिका एक खाली कोशिका से अलग होता है। [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) नियंत्रित करता है कि अनुपलब्ध मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। उदाहरण के लिये देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/net/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट के डेटा रेंज को प्राप्त करना**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज की जांच करें ताकि पता चल सके कि प्रत्येक चार्ट कौन सी वर्कशीट कोशिकाओं का उपयोग करता है। [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) मेथड वर्तमान डेटा रेंज को वर्कशीट-योग्य फ़ॉर्मूले के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाएँ A1 से D5 तक (समावेशी) पहचानता है। डॉलर संकेत पूर्ण पंक्ति और कॉलम संदर्भ दर्शाते हैं।

यह मेथड चार्ट या उसके वर्कबुक को बदले बिना वर्तमान रेंज पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता है, तो यह [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकेगा। अधिक जानकारी के लिये देखें [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड की आकृतियों में सीधे चार्ट ढूँढता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर चलता रहता है।

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

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides for .NET प्रदान करता है [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड जो आपको चार्ट डेटा वर्कबुक (जो Aspose.Cells से संपादित डेटा रखती हैं) को पढ़ने और लिखने की अनुमति देते हैं। **Note** कि चार्ट डेटा को उसी रूप में या स्रोत के समान संरचना में व्यवस्थित होना चाहिए।

यह उदाहरण एक प्रस्तुति का उपयोग करता है जिसमें पहले स्लाइड की पहली आकृति में एक चार्ट है। यह एम्बेडेड वर्कबुक को एक स्ट्रीम में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहता है; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को मान्य करना**

जब आप एक संशोधित वर्कबुक के साथ एम्बेडेड वर्कबुक को बदलते हैं, तो चार्ट अपने मूल सीरीज़ और श्रेणी संग्रह रखता है। यह असंगति [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ विफल कर सकती है। अद्यतन वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहली आकृति में एक चार्ट का उपयोग करता है। टिप्पणी दर्शाती है जहाँ वर्कबुक संपादन होगा; चलाने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

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

    // वर्कबुक स्ट्रीम को यहां संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

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

कलेक्शन को साफ़ करने से वर्कबुक लिखे जाने से पहले पुरानी डेटा रेफ़रेंसेज़ हट जाती हैं। अद्यतन वर्कबुक के लिए आवश्यक सीरीज़ और श्रेणी मैपिंग को फिर से बनाएं, फिर चार्ट का उपयोग करें।

## **वर्कबुक कोशिका को चार्ट डेटा लेबल के रूप में सेट करना**

आप वर्कबुक कोशिकाओं के पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 की कोशिकाएँ A10:A12 का उपयोग प्रथम सीरीज़ के पहले तीन लेबल के लिये करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **वर्कशीट्स का प्रबंधन**

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) प्रॉपर्टी चार्ट वर्कबुक में वर्कशीट्स तक पहुंच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

## **डेटा स्रोत प्रकार निर्दिष्ट करना**

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा वर्कशीट 0 की कोशिका C1 से आता है। [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) एनीमरेशन प्रत्येक नाम के स्रोत को चुनता है। उदाहरण अपडेटेड सीरीज़ नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाना**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता जो कुछ चार्ट में एम्बेड किए जा सकते हैं। आप [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) प्रॉपर्टी को [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) के साथ [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) एनीमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड की आकृतियों की जांच करता है, गैर-चार्ट आकृतियों को छोड़ता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिये एक डायग्नोस्टिक संदेश प्रिंट करता है।

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

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक बनाना**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक निर्यात करता है। यह आउटपुट स्ट्रीम को बंद करता है फिर बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन करता है, और फिर लिंक्ड प्रस्तुति को सहेजता है।

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

### **बाहरी वर्कबुक सेट करना**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) मेथड का उपयोग करके आप एक चार्ट के डेटा स्रोत के रूप में बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को भी अपडेट करने के लिये उपयोग किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

हालांकि आप रिमोट स्थान या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, फिर भी आप ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक का रिलेटिव पथ प्रदान किया जाता है, तो यह स्वतः पूर्ण पथ में बदल जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में एक सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों के साथ मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) के `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` हो, केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्षित वर्कबुक से लोड या अपडेट नहीं किया जाता, इसलिए वर्कबुक अनुपलब्ध हो भी सकता है।
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्षित वर्कबुक से अपडेट किया जाता है।

निम्न उदाहरण `updateChartData` को `false` सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करना**

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिये, जांचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति की पहली स्लाइड की पहली आकृति की जांच करता है जिसमें एक लिंक्ड बाहरी वर्कबुक है। यदि यह एक चार्ट है जो बाहरी वर्कबुक से जुड़ा है, तो उदाहरण कंसोल पर [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

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

### **चार्ट डेटा संपादित करना**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक एक्सेप्शन फेंका जाता है।

यह उदाहरण एक चार्ट का उपयोग करता है जो पहली स्लाइड की पहली आकृति में है और एक सुलभ बाहरी वर्कबुक से जुड़ा है। यह पहली सीरीज़ के पहले डेटा पॉइंट का सेल-बैक्स्ड मान 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिये एक कॉपी का उपयोग करें।

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

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करना**

यदि कोई चार्ट एक बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्माण कर सकता है। [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) बनाएं, उसके [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) को कॉन्फ़िगर करें, और [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) को `true` सेट करें, फिर प्रस्तुति खोलें।

निम्न C# उदाहरण एक चार्ट के लिए वर्कबुक डेटा पुनर्प्राप्त करता है जो पहली स्लाइड की पहली आकृति में है और एक अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनः प्राप्त डेटा को [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) और [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

यदि बाहरी वर्कबुक अनुपलब्ध है और रीकवरी निष्क्रिय है, तो Aspose.Slides एक [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकेगा। रीकवरी केवल तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकृत बैकअप हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तन नहीं हो सकते।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट का [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) और एक [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर पुष्टि कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वतः एक एब्सोल्यूट पाथ में परिवर्तित हो जाता है। प्रस्तुति एब्सोल्यूट पाथ को PPTX फ़ाइल में संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधन/शेयर पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजने पर बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहीत करती है। सेल-आधारित चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड-प्रोटेक्टेड है तो क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका है पहले सुरक्षा हटाना या एक डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिये, [Aspose.Cells](https://reference.aspose.com/cells/net/) का उपयोग करके) और उस कॉपी को लिंक करना।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी वही फ़ाइल दर्शाते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिलक्षित होगा।