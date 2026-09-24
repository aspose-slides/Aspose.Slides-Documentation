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
description: "Aspose.Slides for .NET को खोजें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपके प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि कैसे वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ा और लिखा जाए, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में इस्तेमाल किया जाए, वर्कशीट संग्रहों तक पहुँच प्राप्त की जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार को निर्दिष्ट किया जाए।

यह लेख बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाए, चार्ट से जुड़े बाहरी वर्कबुक का पथ प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाए।

गुम डेटा दर्शाने वाले वर्कबुक सेल्स के लिए, खाली सेल और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शन मोडों की रेखा-चार्ट तुलना के लिए देखें [Control the Display of Empty Cells](/slides/hi/net/chart-series/)।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**
Aspose.Slides [ReadWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड्स प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा वाली) पढ़ने और लिखने की अनुमति देते हैं। **Note** कि चार्ट डेटा को उसी तरह संगठित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को मान्य करें**
जब आप एक संशोधित वर्कबुक के साथ एम्बेडेड वर्कबुक को बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रहों को बरकरार रखता है। यह असंगति [IChart.ValidateChartLayout](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/validatechartlayout/) को इंडेक्स-ऑफ़-रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें।

```csharp
// वर्कबुक स्ट्रीम को संशोधित करने के बाद (जैसे, Aspose.Cells का उपयोग करके)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// मौजूदा डेटा संदर्भों को साफ़ करें।
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नए वर्कबुक के साथ संगत हो, जिससे `ValidateChartLayout` बिना त्रुटि के पूरा हो सकता है।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**
1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड के इंडेक्स के द्वारा उसका रेफ़रेंस प्राप्त करें।
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुँच प्राप्त करें।
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
1. प्रेज़ेंटेशन को सहेजें।

यह C# कोड दिखाता है कि वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे सेट किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली प्रेज़ेंटेशन क्लास का एक उदाहरण बनाता है 

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

## **वर्कशीट्स को प्रबंधित करें**

यह C# कोड एक ऑपरेशन दर्शाता है जहाँ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) प्रॉपर्टी का उपयोग करके वर्कशीट संग्रह तक पहुँच प्राप्त की जाती है:

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
यह C# कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाए:

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

## **असमर्थित एम्बेडेड वर्कबुक फॉर्मैट्स का पता लगाएँ**
Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फॉर्मैट का समर्थन नहीं करता जो कुछ चार्ट में एम्बेड किए जा सकते हैं। आप [IChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/) पर `EmbeddedWorkbookType` प्रॉपर्टी को [WorkbookType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/workbooktype/) ए़न्युमरेशन के साथ उपयोग करके असमर्थित फॉर्मैट्स का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं।

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

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक उपयोग करने का समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**
**`ReadWorkbookStream`** और **`SetExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शुरुआत से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

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

### **एक बाहरी वर्कबुक सेट करें**
**`SetExternalWorkbook`** मेथड का उपयोग करके आप एक बाहरी वर्कबुक को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी इस्तेमाल किया जा सकता है (यदि बाद वाला स्थानांतरित किया गया हो)।

जबकि आप रिमोट लोकेशन या रिसोर्स में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि किसी बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो यह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह C# कोड दिखाता है कि एक बाहरी वर्कबुक कैसे सेट किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// दस्तावेज़ डायरेक्ट्री का पथ.
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

`ChartData` पैरामीटर (`SetExternalWorkbook` मेथड के तहत) यह निर्धारित करने के लिए उपयोग होता है कि क्या Excel वर्कबुक लोड होगी या नहीं।

* जब `ChartData` मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता। यह सेटिंग तब उपयोगी है जब लक्ष्य वर्कबुक अस्तित्व में नहीं है या उपलब्ध नहीं है।  
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

### **एक चार्ट का बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**
1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड के इंडेक्स के द्वारा उसका रेफ़रेंस प्राप्त करें।
1. चार्ट शैप के लिए एक ऑब्जेक्ट बनाएं।
1. स्रोत (`ChartDataSourceType`) प्रकार का एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।
1. स्रोत प्रकार के समान होने पर बाहरी वर्कबुक डेटा स्रोत प्रकार के आधार पर संबंधित शर्त निर्धारित करें।

यह C# कोड ऑपरेशन को दर्शाता है:

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
    
    // प्रस्तुति को सहेजें
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **चार्ट डेटा संपादित करें**
आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक की सामग्री में परिवर्तन करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक एक्सेप्शन फेंका जाता है।

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

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**
यदि कोई चार्ट ऐसे बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) बनाएं, उसके [SpreadsheetOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/spreadsheetoptions/) को कॉन्फ़िगर करें, और [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) को `true` सेट करें प्रस्तुतिकरण खोलने से पहले।

निम्न C# उदाहरण एक प्रस्तुति खोलता है जिसमें चार्ट एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है और पुनर्प्राप्त डेटा को [IChart.ChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/chartdata/) और [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides `InvalidOperationException` फेंकेगा। केवल तभी पुनर्प्राप्ति सक्षम करें जब कैश किया गया चार्ट डेटा एक स्वीकार्य वैकल्पिक उपाय हो, क्योंकि कैश में बाहरी वर्कबुक में अंतिम प्रस्तुति अपडेट के बाद किए गए परिवर्तन नहीं हो सकते।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**  
हाँ। एक चार्ट के पास एक [data source type](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/datasourcetype/) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर यह सत्यापित कर सकते हैं कि बाहरी फ़ाइल प्रयुक्त हो रही है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  
हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालाँकि, ध्यान रखें कि प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**  
हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति सहेजने पर बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड है तो क्या करें?**  
Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य उपाय यह है कि पहले सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](/cells/net/) का उपयोग करके) और उस कॉपी से लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**  
हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल को संदर्भित करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन प्रतिबिंबित होंगे।