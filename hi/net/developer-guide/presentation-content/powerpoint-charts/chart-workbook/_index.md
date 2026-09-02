---
title: .NET में प्रस्तुतियों में चार्ट वर्कबुक को प्रबंधित करें
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
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET को खोजें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक को सहजता से प्रबंधित करके अपने प्रेज़ेंटेशन डेटा को सुव्यवस्थित बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीकों को समझाता है। यह वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, चार्ट डेटा लेबल के रूप में वर्कबुक सेल का उपयोग करने, वर्कशीट संग्रहों तक पहुँचने, और चार्ट मूल्यों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने को दर्शाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरणों में बाहरी वर्कबुक बनाने और असाइन करने, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करने, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित करने के तरीके दिखाए गए हैं।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**
Aspose.Slides वह [ReadWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड प्रदान करता है जिससे आप चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा) को पढ़ और लिख सकते हैं। **ध्यान दें** कि चार्ट डेटा को उसी तरीके से व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह C# कोड एक नमूना ऑपरेशन दर्शाता है:

```c#
using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करना**
1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) वर्ग की एक इंस्टेंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट सीरीज़ तक पहुँचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेज़ेंटेशन सहेजें।

यह C# कोड दर्शाता है कि वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे सेट किया जाए:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **वर्कशीट का प्रबंधन**

यह C# कोड एक ऑपरेशन दर्शाता है जहाँ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) प्रॉपर्टी का उपयोग करके वर्कशीट संग्रह तक पहुँचा जाता है:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **डेटा स्रोत प्रकार निर्दिष्ट करना**

यह C# कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाए:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मैट का पता लगाना**

Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मैट को समर्थन नहीं देता। आप `[EmbeddedWorkbookType]` प्रॉपर्टी को `[IChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/)` पर और `[WorkbookType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/workbooktype/)` एन्‍युमरेशन के साथ प्रयोग करके असमर्थित फ़ॉर्मैट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं।

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // एंबेडेड वर्कबुक .xlsb फ़ॉर्मैट में है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
}
```

## **बाहरी वर्कबुक**

{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/hi/net/aspose-slides-for-net-19-4-release-notes/) में हमने चार्ट के डेटा स्रोत के रूप में बाहरी वर्कबुक के समर्थन को लागू किया है। 
{{% /alert %}} 

### **बाहरी वर्कबुक बनाना**
**`ReadWorkbookStream`** और **`SetExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या किसी आंतरिक वर्कबुक को बाहरी बना सकते हैं।

यह C# कोड बाहरी वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

```c#
using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **बाहरी वर्कबुक सेट करना**
**`SetExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को उसकी डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, फिर भी इन्हें बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। यदि बाहरी वर्कबुक के लिए रिलेटिव पथ प्रदान किया जाता है, तो वह स्वतः पूर्ण पथ में बदल जाता है।

यह C# कोड दिखाता है कि बाहरी वर्कबुक कैसे सेट की जाए:

```c#
// दस्तावेज़ निर्देशिका का पथ।
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

`SetExternalWorkbook` मेथड के तहत `ChartData` पैरामीटर यह निर्धारित करता है कि Excel वर्कबुक लोड की जाएगी या नहीं।

* जब `ChartData` को `false` पर सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। यह सेटिंग तब उपयोगी है जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है।  
* जब `ChartData` को `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करना**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) वर्ग की एक इंस्टेंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
1. डेटा स्रोत प्रकार (`ChartDataSourceType`) को दर्शाने वाला एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को प्रतिनिधित्व करता है।  
1. स्रोत प्रकार के समान बाहरी वर्कबुक डेटा स्रोत प्रकार होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

यह C# कोड ऑपरेशन को दर्शाता है:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // प्रस्तुति को सहेजें
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **चार्ट डेटा संपादित करना**

आप बाहरी वर्कबुक में डेटा उसी प्रकार संपादित कर सकते हैं जैसे आंतरिक वर्कबुक में करते हैं। यदि कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो अपवाद फेंका जाता है।

यह C# कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करना**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रेज़ेंटेशन में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः बनाना सकता है। `[LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/)` बनाएं, उसके `[SpreadsheetOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/spreadsheetoptions/)` को कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/)` को `true` सेट करें।

निम्न C# उदाहरण वह प्रेज़ेंटेशन खोलता है जहाँ चार्ट का संदर्भ अनुपलब्ध बाहरी वर्कबुक से जुड़ा है और पुनः प्राप्त डेटा को `[IChart.ChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/chartdata/)` और `[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/chartdataworkbook/)` के माध्यम से एक्सेस करता है:

```csharp
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides `InvalidOperationException` फेंकेगा। पुनर्प्राप्ति तभी सक्षम करें जब कैश्ड चार्ट डेटा को बैकअप के रूप में स्वीकार्य माना जाता हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तन नहीं हो सकते।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी वर्कबुक से जुड़ा है या एम्बेडेड वर्कबुक से?**  
हाँ। चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/datasourcetype/) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर यह पुष्टि कर सकते हैं कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ समर्थित हैं, और उन्हें कैसे संग्रहीत किया जाता है?**  
हाँ। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वतः एबसोल्यूट पाथ में बदल जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालाँकि, प्रेज़ेंटेशन PPTX फ़ाइल में एबसोल्यूट पाथ संग्रहीत करेगा।

**क्या मैं नेटवर्क संसाधन/शेयर पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**  
हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रेज़ेंटेशन सहेजते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रेज़ेंटेशन एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहीत करता है और डेटा पढ़ने के लिए इसका उपयोग करता है। प्रेज़ेंटेशन सहेजने पर बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**  
Aspose.Slides लिंकिंग के दौरान पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले पासवर्ड हटाया जाए या एक डी‑क्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](/cells/net/) का उपयोग करके) और उस कॉपी से लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**  
हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल में किए गए अद्यतन प्रत्येक चार्ट में अगले डेटा लोड होने पर परिलक्षित होंगे।