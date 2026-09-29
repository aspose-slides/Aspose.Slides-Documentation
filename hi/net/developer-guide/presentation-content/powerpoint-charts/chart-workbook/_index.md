---
title: .NET में प्रस्तुतियों में चार्ट कार्यपुस्तिकाओं को प्रबंधित करें
linktitle: चार्ट कार्यपुस्तिका
type: docs
weight: 70
url: /hi/net/chart-workbook/
keywords:
- चार्ट कार्यपुस्तिका
- चार्ट डेटा
- कार्यपुस्तिका कोशिका
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी कार्यपुस्तिका
- बाहरी डेटा
- चार्ट कैश
- कार्यपुस्तिका पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट कार्यपुस्तिकाओं को आसानी से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट कार्यपुस्तकों के साथ काम करने का तरीका समझाता है। यह कार्यपुस्तक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, कार्यपुस्तक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट कलेक्शन तक पहुंचने, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने को दर्शाता है।

यह बाहरी कार्यपुस्तकों को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी कार्यपुस्तिका बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी कार्यपुस्तिका का पथ प्राप्त करें, और जब कार्यपुस्तिका उपलब्ध हो तो चार्ट डेटा को संपादित करें।

गायब डेटा का प्रतिनिधित्व करने वाली कार्यपुस्तक कोशिकाओं के लिए, खाली कोशिका और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शन मोड की तुलना के लिए [खाली कोशिकाओं का प्रदर्शन नियंत्रित करें](/slides/hi/net/chart-series/) देखें।

## **छिपी पंक्तियों और स्तम्भों से डेटा शामिल करें**

छिपी कार्यपत्रक पंक्तियों और स्तम्भों से डेटा प्लॉट करने को नियंत्रित करने के लिए [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) का उपयोग करें। केवल दृश्यमान कोशिकाओं को प्लॉट करने के लिए `true` सेट करें, या दृश्यमान और छिपी दोनों कोशिकाओं को शामिल करने के लिए `false` सेट करें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह कार्यपत्रक पंक्तियों या स्तम्भों को छिपाती या प्रदर्शित नहीं करती।

[hidden-source-data.pptx](hidden-source-data.pptx) डाउनलोड करें और इसे कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में पहला आकार कॉलम चार्ट है। अंतर्निहित वर्कशीट, `Sheet1`, में स्रोत सीमा `A1:C4` है। पंक्ति 3 और स्तम्भ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| कार्यपत्रक पंक्ति | A: माह | B: खुदरा | C: थोक (छिपा स्तम्भ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुंचने के लिए [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/chartdataworkbook/) का उपयोग करें और छिपी स्थिति जांचने के लिए [IChartDataCell.IsHidden](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/ishidden/) पढ़ें। यह गुण केवल पढ़ने योग्य है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से सम्बंधित है, और C2 छिपे स्तम्भ से सम्बंधित है; उदाहरण क्रमशः `False`, `True`, और `True` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: [ReadWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/readworkbookstream/) के साथ अंतर्निहित कार्यपुस्तिका रखें और उसे [WriteWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/writeworkbookstream/) से फिर से लोड करें। सभी कोशिकाओं को शामिल करने के लिए, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने हेतु [SetRange](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश किए गए चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

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

        // एम्बेडेड कार्यपुस्तिका से चार्ट डेटा को रीफ़्रेश करें।
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // छिपी श्रेणियों सहित पूर्ण स्रोत सीमा को पुनर्स्थापित करें।
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

उदाहरण `hidden_cells_True.pptx` को केवल दृश्यमान खुदरा मानों (10 और 20) के साथ सहेजता है, और `hidden_cells_False.pptx` को सभी छह मानों के साथ। नीचे की छवियां सहेजे गए प्रस्तुति को पुनः खोलने के बाद रेंडर की गई हैं; दोनों फ़ाइलें अपनी असाइन की गई प्लॉटिंग सेटिंग को संरक्षित रखती हैं। पंक्ति 3 और स्तम्भ C दोनों अंतर्निहित कार्यपुस्तकों में छिपे हुए ही रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाली छिपी हुई कोशिका खाली कोशिका से अलग होती है। [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/displayblanksas/) नियंत्रित करता है कि गायब मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बहिष्कृत नहीं करता। उदाहरण के लिए देखें [खाली कोशिकाओं का प्रदर्शन नियंत्रित करें](/slides/hi/net/chart-series/#control-the-display-of-empty-cells)।

## **कार्यपुस्तक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for .NET दो विधियाँ प्रदान करता है—[ReadWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/writeworkbookstream/)—जो आपको चार्ट डेटा कार्यपुस्तकों (Aspose.Cells के साथ संपादित) को पढ़ने और लिखने की अनुमति देती हैं। **ध्यान दें** कि चार्ट डेटा को उसी प्रकार संगठित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण `chart.pptx` खोलता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए। यह एम्बेडेड कार्यपुस्तिका को स्ट्रीम में पढ़ता है, मौजूदा श्रृंखलाओं और श्रेणियों को साफ़ करता है, और वही कार्यपुस्तिका वापस लिखता है। बदलाव मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **कार्यपुस्तक संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप संशोधित कार्यपुस्तिका से एम्बेडेड कार्यपुस्तिका को बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी कलेक्शन को बरकरार रखता है। यह असंगति [IChart.ValidateChartLayout](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/validatechartlayout/) को सूचकांक‑से‑बाहरी त्रुटि के साथ विफल कर सकती है। अपडेटेड कार्यपुस्तिका को चार्ट में लिखने से पहले मौजूदा श्रृंखलाओं और श्रेणियों को साफ़ करें। यह उदाहरण `chart.pptx` की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक चार्ट हो। टिप्पणी उन स्थानों को दर्शाती है जहाँ कार्यपुस्तिका संपादन होगा; चलने योग्य उदाहरण मूल कार्यपुस्तिका को वापस लिखता है और मेमोरी में लेआउट को सत्यापित करता है।

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

    // यहाँ कार्यपुस्तिका स्ट्रीम को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

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

संग्रहों को साफ़ करने से लिखे जाने से पहले पुराने डेटा संदर्भ हट जाते हैं। अपडेटेड कार्यपुस्तिका के लिए आवश्यक किसी भी श्रृंखला और श्रेणी मानचित्रण को पुनः बनाएं, फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप कार्यपुस्तक कोशिकाओं के पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं। निम्नलिखित चरण बबल चार्ट में लेबल को डेटा कार्यपुस्तिका की कोशिकाओं से जोड़ते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
1. शून्य‑आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुंचें।  
1. डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट श्रृंखला तक पहुंचें।  
1. कार्यपुस्तिक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रस्तुति सहेजें।

यह उदाहरण `chart2.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए, और डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 पर कोशिकाएँ A10:A12 का उपयोग प्रथम श्रृंखला के पहले तीन लेबल के लिए करता है, कोशिकाओं से लेबल सक्षम करता है, और परिणाम `resultchart.pptx` में सहेजता है।

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/worksheets/) गुण चार्ट कार्यपुस्तिका में उपलब्ध वर्कशीट्स तक पहुंच प्रदान करता है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल में प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल से आता है; दूसरा नाम वर्कशीट 0 की कोशिका C1 से। [DataSourceType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/datasourcetype/) एन्यूमरेशन प्रत्येक नाम के स्रोत को चुनता है। परिणाम `pres.pptx` में सहेजा जाता है।

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

## **असमर्थित एम्बेडेड कार्यपुस्तिका स्वरूपों का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेडेड Excel बाइनरी कार्यपुस्तिका (.xlsb) स्वरूप को समर्थन नहीं देता। आप [IChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/) के साथ [EmbeddedWorkbookType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) गुण और [WorkbookType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/workbooktype/) एन्यूमरेशन का उपयोग करके असमर्थित स्वरूपों का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण `sample.pptx` की पहली स्लाइड पर सभी आकृतियों की जाँच करता है, गैर‑चार्ट आकृतियों को छोड़ता है, और एम्बेडेड .xlsb कार्यपुस्तिका वाले प्रत्येक चार्ट के लिए एक डाइग्नोस्टिक संदेश प्रिंट करता है।

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

### **बाहरी कार्यपुस्तिका बनाएं**

एक एम्बेडेड चार्ट कार्यपुस्तिका को फाइल में निर्यात करने और चार्ट को उस बाहरी कार्यपुस्तिका से लिंक करने के लिए [ReadWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [SetExternalWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का उपयोग करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, उसका कार्यपुस्तिका `externalWorkbook1.xlsx` में लिखता है, आउटपुट स्ट्रीम को बंद करता है, और फिर फ़ाइल को चार्ट डेटा स्रोत के रूप में असाइन करता है। लिंक किया हुआ प्रस्तुति `externalWorkbook.pptx` में सहेजा जाता है।

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

### **बाहरी कार्यपुस्तिका असाइन करें**

[SetExternalWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/setexternalworkbook/) विधि का उपयोग करके आप किसी चार्ट को बाहरी कार्यपुस्तिका को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह विधि बाहरी कार्यपुस्तिका के पथ को अपडेट करने के लिए भी प्रयोग की जा सकती है (यदि वह स्थानांतरित हो गया हो)।

रिमोट लोकेशन या संसाधन में मौजूद कार्यपुस्तिकाओं को आप सीधे संपादित नहीं कर सकते, परन्तु उन्हें डेटा स्रोत के रूप में उपयोग किया जा सकता है। यदि बाहरी कार्यपुस्तिका के लिए सापेक्ष पथ दिया गया है, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण कार्य निर्देशिका में `externalWorkbook.xlsx` की आवश्यकता रखता है। इसकी वर्कशीट `Sheet1` में B1 में एक श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान होने चाहिए। उदाहरण एक पाई चार्ट बनाता है, कार्यपुस्तिका को लिंक करता है, और [SetRange](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/setrange/) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों के रूप में मैप करता है। परिणाम `Presentation_with_externalWorkbook.pptx` में सहेजता है।

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

[SetExternalWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/setexternalworkbook/) का `updateChartData` पैरामीटर निर्धारित करता है कि कार्यपुस्तिका लोड की जाए या नहीं।

* जब `updateChartData` `false` हो, तो केवल कार्यपुस्तिका पथ अपडेट होता है। चार्ट डेटा लक्ष्य कार्यपुस्तिका से लोड या अपडेट नहीं होता, इसलिए कार्यपुस्तिका अनुपलब्ध हो भी सकती है।  
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य कार्यपुस्तिका से अपडेट होता है।

निम्नलिखित उदाहरण एक प्लेसहोल्डर URL को `updateChartData` `false` के साथ असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध कार्यपुस्तिका को लोड किए बिना प्रस्तुति को सहेजता है।

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

किसी चार्ट से जुड़े कार्यपुस्तिका की पहचान करने के लिए, पहले जांचें कि चार्ट बाहरी डेटा स्रोत का उपयोग करता है या नहीं। यदि करता है, तो निम्न चरणों के अनुसार कार्यपुस्तिका पथ को निकालें।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
1. शून्य‑आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुंचें।  
1. जांचें कि पहला आकार एक चार्ट है।  
1. चार्ट डेटा स्रोत प्रकार को पढ़ें।  
1. यदि स्रोत एक बाहरी कार्यपुस्तिका है, तो उसका पथ पढ़ें।

यह उदाहरण `externalWorkbook.pptx` खोलता है (जो पिछले उदाहरण में बनाया गया था) और पहली स्लाइड पर पहले आकार का निरीक्षण करता है। यदि वह बाहरी कार्यपुस्तिका से लिंक किया हुआ चार्ट है, तो यह कंसोल में [ExternalWorkbookPath](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/externalworkbookpath/) प्रिंट करता है। फिर यह प्रस्तुति की एक प्रतिलिपि `Result.pptx` में सहेजता है।

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

आप बाहरी कार्यपुस्तिकाओं के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक कार्यपुस्तिकाओं के सामग्री को बदलते हैं। जब कोई बाहरी कार्यपुस्तिका लोड नहीं हो पाती, तो एक अपवाद उत्पन्न हो जाता है।

यह उदाहरण `presentation.pptx` की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक चार्ट हो और एक सुलभ बाहरी कार्यपुस्तिका उपलब्ध हो। यह प्रथम श्रृंखला के प्रथम डेटा पॉइंट के सेल‑बैक्ड मान को 100 सेट करता है और परिणाम `presentation_out.pptx` में सहेजता है। सेल मानों को संपादित करने से लिंक किया हुआ बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल कार्यपुस्तिका को संरक्षित रखने के लिए उसकी प्रतिलिपि का उपयोग करें।

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

### **चार्ट कैश से कार्यपुस्तिका पुनः प्राप्त करें**

यदि कोई चार्ट बाहरी कार्यपुस्तिका का उपयोग कर रहा है जो अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट कार्यपुस्तिका को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) बनाएं, उसके [SpreadsheetOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/spreadsheetoptions/) को कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) को `true` सेट करें।

निम्न C# उदाहरण `presentation.pptx` खोलता है, जिसकी पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए जो अनुपलब्ध बाहरी कार्यपुस्तिका का संदर्भ देता है, और पुनः प्राप्त डेटा को [IChart.ChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/chartdata/) और [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

    // पुनः प्राप्त कार्यपुस्तिका डेटा को यहाँ पढ़ें या संशोधित करें।
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

यदि बाहरी कार्यपुस्तिका अनुपलब्ध है और पुनः प्राप्ति अक्षम है, तो Aspose.Slides एक [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) फेंकता है। पुनः प्राप्ति तभी सक्षम करें जब कैश किए गए चार्ट डेटा को फ़ॉलबैक के रूप में उपयोग करना स्वीकार्य हो, क्योंकि कैश में बाहरी कार्यपुस्तिका में किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड कार्यपुस्तिका से लिंक है?**

हाँ। चार्ट का एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/datasourcetype/) और एक [बाहरी कार्यपुस्तिका पथ](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) होता है; यदि स्रोत बाहरी कार्यपुस्तिका है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी कार्यपुस्तिकाओं के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहित होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए कार्यपुस्तिका को स्थानांतरित करने पर लिंक को अपडेट करने की आवश्यकता हो सकती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित कार्यपुस्तिकाओं का उपयोग कर सकता हूँ?**

हाँ, ऐसी कार्यपुस्तिकाओं को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट कार्यपुस्तिकाओं को सीधे संपादित करना समर्थित नहीं है—उनका उपयोग केवल स्रोत के रूप में किया जा सकता है।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट कर देता है?**

प्रस्तुति में एक [बाहरी फ़ाइल लिंक](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहीत होता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक की गई स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। मूल कार्यपुस्तिका को अपरिवर्तित रखने के लिए उसकी प्रतिलिपि का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य उपाय यह है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड प्रतिलिपि (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/net/)) तैयार करें और उसी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी कार्यपुस्तिका को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट पर परिवर्तन प्रतिबिंबित होंगे।