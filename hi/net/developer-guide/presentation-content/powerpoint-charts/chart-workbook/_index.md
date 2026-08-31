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
description: "Aspose.Slides for .NET की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपकी प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट वर्कबुक्स के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक्स को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाएँ और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**
Aspose.Slides [ReadWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड्स प्रदान करता है जो आपको चार्ट डेटा वर्कबुक्स (जो Aspose.Cells के साथ संपादित किए गए हैं) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को समान तरीके से व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह C# कोड एक नमूना ऑपरेशन को दर्शाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को वैध बनाएं**

जब आप एक एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपने मूल सीरीज़ और कैटेगरी संग्रहों को बनाए रखता है। यह विसंगति [IChart.ValidateChartLayout](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/validatechartlayout/) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ असफल बना सकती है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा सीरीज़ और कैटेगरीज को साफ़ कर दें।

```csharp
// वर्कबुक स्ट्रीम को संशोधित करने के बाद (जैसे, Aspose.Cells का उपयोग करके)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// मौजूदा डेटा रेफ़रेंस को साफ़ करें।
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई वर्कबुक के साथ संगत है, जिससे `ValidateChartLayout` त्रुटियों के बिना पूरा हो जाता है।

## **चार्ट डेटा लेबल के रूप में वर्कबुक सेल सेट करें**
1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टैंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट सीरीज़ तक पहुंचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेज़ेंटेशन सहेजें।

यह C# कोड दिखाता है कि वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे सेट करें:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// प्रस्तुति फ़ाइल को दर्शाने वाली प्रस्तुति क्लास का उदाहरण बनाता है

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

## **वर्कशीट्स का प्रबंधन करें**

यह C# कोड एक ऑपरेशन प्रदर्शित करता है जहाँ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) प्रॉपर्टी का उपयोग करके वर्कशीट संग्रह तक पहुंचा जाता है:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह C# कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट करें:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

## **असमर्थित एंबेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को सपोर्ट नहीं करता जो कुछ चार्ट्स में एंबेडेड हो सकते हैं। आप `EmbeddedWorkbookType` प्रॉपर्टी को [IChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/) पर और [WorkbookType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/workbooktype/) एन्‍युमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

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
            // एम्बेडेड वर्कबुक .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
}
```

## **बाहरी वर्कबुक**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/hi/net/aspose-slides-for-net-19-4-release-notes/) में, हमने चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक्स का समर्थन लागू किया है। 
{{% /alert %}} 

### **बाहरी वर्कबुक बनाएं**
**`ReadWorkbookStream`** और **`SetExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या किसी इंटर्नल वर्कबुक को बाहरी बना सकते हैं।

यह C# कोड बाहरी वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

### **बाहरी वर्कबुक सेट करें**
**`SetExternalWorkbook`** मेथड का उपयोग करके आप एक बाहरी वर्कबुक को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

हालाँकि आप रिमोट लोकेशन्स या रिसोर्सेज में संग्रहीत वर्कबुक्स के डेटा को संपादित नहीं कर सकते, फिर भी आप ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए रिलेटिव पथ प्रदान किया गया है, तो वह स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है।

यह C# कोड दिखाता है कि बाहरी वर्कबुक कैसे सेट करें:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// डॉक्यूमेंट्स निर्देशिका का पथ।
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

`SetExternalWorkbook` मेथड के अंतर्गत `ChartData` पैरामीटर का उपयोग यह बताने के लिए किया जाता है कि क्या एक्सेल वर्कबुक लोड होगी या नहीं।

* जब `ChartData` मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाएगा। यह सेटिंग तब उपयोगी है जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है।  
* जब `ChartData` मान `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टैंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
1. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।  
1. बाहरी वर्कबुक डेटा स्रोत प्रकार के समान होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

यह C# कोड इस ऑपरेशन को दर्शाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // प्रस्तुति सहेजता है
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक्स के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप इंटर्नल वर्कबुक्स की सामग्री में बदलाव करते हैं। जब एक बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद उत्पन्न होता है।

यह C# कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**

यदि एक चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) बनाएं, उसके [SpreadsheetOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/spreadsheetoptions/) को कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) को `true` सेट करें।

निम्न C# उदाहरण एक ऐसी प्रस्तुति खोलता है जहाँ चार्ट एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है और पुनर्प्राप्त डेटा को [IChart.ChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/chartdata/) और [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

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

यदि बाहरी वर्कबुक अनुपलब्ध है और रिकवरी निष्क्रिय है, तो Aspose.Slides `InvalidOperationException` फेंकेगा। केवल तभी रिकवरी सक्षम करें जब कैश किए गए चार्ट डेटा को फ़ॉलबैक के रूप में उपयोग करना स्वीकार्य हो, क्योंकि कैश में उन बदलावों को शामिल नहीं किया जा सकता जो बाहरी वर्कबुक में प्रस्तुति के अंतिम अपडेट के बाद किए गए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एंबेडेड वर्कबुक से जुड़ा है?**  
हां। एक चार्ट के पास [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/datasourcetype/) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक्स के लिए रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  
हां। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से एब्सोल्यूट पाथ में बदल दिया जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, प्रस्तुति PPTX फ़ाइल में एब्सोल्यूट पाथ संग्रहीत करती है।

**क्या मैं नेटवर्क रिसोर्सेज/शेयर पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**  
हां, ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक्स को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रस्तुति एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति सहेजने पर बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड-प्रोटेक्टेड है तो मुझे क्या करना चाहिए?**  
Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। आमतौर पर पहले सुरक्षा हटा देना या एक डिक्रिप्टेड कॉपी तैयार करना (उदा., [Aspose.Cells](/cells/net/) का उपयोग करके) और उस कॉपी को लिंक करना सलाह दिया जाता है।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**  
हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में किए गए अपडेट अगले डेटा लोड के समय प्रत्येक चार्ट में प्रतिबिंबित होंगे।