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
description: "Aspose.Slides for .NET की खोज करें: PowerPoint और OpenDocument स्वरूपों में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपने प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार कैसे निर्धारित करें।

यह भी बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को कवर करता है। उदाहरण दर्शाते हैं कि बाहरी वर्कबुक कैसे बनाएं और असाइन करें, चार्ट से जुड़े बाहरी वर्कबुक का पाथ कैसे प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा कैसे संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**
Aspose.Slides [ReadWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/readworkbookstream/) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/writeworkbookstream/) मेथड्स प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells द्वारा संपादित चार्ट डेटा होता है) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को उसी तरीके से व्यवस्थित किया जाना चाहिए या इसका ढांचा स्रोत के समान होना चाहिए।

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

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**
1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक उदाहरण बनाएं।  
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
4. चार्ट सीरीज़ तक पहुंचें।  
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
6. प्रेजेंटेशन को सहेजें।

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टैंसिएट करता है 

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

## **वर्कशीट्स का प्रबंधन**
यह C# कोड दर्शाता है कि कैसे [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) प्रॉपर्टी का उपयोग करके वर्कशीट संग्रह तक पहुंचा जाता है:

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
यह C# कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाता है:

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**
Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप `EmbeddedWorkbookType` प्रॉपर्टी को [IChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/) पर और [WorkbookType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/workbooktype/) एनेमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं।

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
            // .xlsb फ़ॉर्मेट में एम्बेडेड वर्कबुक है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा पढ़ें या संशोधित करें।
    }
}
```

## **बाहरी वर्कबुक**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/hi/net/aspose-slides-for-net-19-4-release-notes/) में, हमने चार्ट के डेटा स्रोत के रूप में बाहरी वर्कबुक का समर्थन लागू किया। 
{{% /alert %}} 

### **एक बाहरी वर्कबुक बनाएं**
**`ReadWorkbookStream`** और **`SetExternalWorkbook`** मेथड्स का उपयोग करके आप शून्य से एक बाहरी वर्कबुक बना सकते हैं या किसी आंतरिक वर्कबुक को बाहरी बना सकते हैं।

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
**`SetExternalWorkbook`** मेथड का उपयोग करके आप एक बाहरी वर्कबुक को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पाथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित हो गई हो)।

जबकि आप रिमोट लोकेशन या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पाथ प्रदान किया जाता है, तो यह स्वचालित रूप से पूर्ण पाथ में परिवर्तित हो जाता है।

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

`ChartData` पैरामीटर (`SetExternalWorkbook` मेथड के तहत) यह निर्दिष्ट करने के लिए उपयोग किया जाता है कि Excel वर्कबुक लोड होगा या नहीं।

* जब `ChartData` मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पाथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता। आप इस सेटिंग का उपयोग तब कर सकते हैं जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।  
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

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करें**
1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक उदाहरण बनाएं।  
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
4. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत का प्रतिनिधित्व करता है।  
5. स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान होने के आधार पर प्रासंगिक शर्त निर्दिष्ट करें।

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
    
    // प्रेजेंटेशन को सहेजें
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **चार्ट डेटा संपादित करें**
आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक एक्सेप्शन फेंका जाता है।

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
यदि कोई चार्ट उस बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या गुम है, तो Aspose.Slides प्रेजेंटेशन में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः बनाकर पुनर्प्राप्त कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) बनाएं, उसकी [SpreadsheetOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/spreadsheetoptions/) कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `ISpreadsheetOptions.RecoverWorkbookFromChartCache` को `true` सेट करें।

निम्न C# उदाहरण एक ऐसी प्रेजेंटेशन खोलता है जिसमें चार्ट किसी अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है और पुनर्प्राप्त डेटा को [IChart.ChartData](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/chartdata/) तथा [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdata/chartdataworkbook/) के माध्यम से एक्सेस करता है:

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

यदि बाहरी वर्कबुक अनुपलब्ध है और रिकवरी अक्षम है, तो Aspose.Slides `InvalidOperationException` फेंकेगा। केवल तब रिकवरी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य बैकअप हो, क्योंकि कैश में बाहरी वर्कबुक में आखिरी बार प्रेजेंटेशन अपडेट होने के बाद किए गए परिवर्तन नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**  
हाँ। एक चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/datasourcetype/) और एक [बाहरी वर्कबुक का पाथ](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पाथ समर्थित हैं, और वे कैसे संग्रहित होते हैं?**  
हाँ। यदि आप सापेक्ष पाथ निर्दिष्ट करते हैं, तो यह स्वचालित रूप से पूर्ण पाथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रेजेंटेशन PPTX फ़ाइल में पूर्ण पाथ संग्रहीत करेगा।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**  
हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। लेकिन Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—उन्हें केवल स्रोत के रूप में ही उपयोग किया जा सकता है।

**क्या Aspose.Slides प्रेजेंटेशन सहेजते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रेजेंटेशन एक [बाहरी फ़ाइल लिंक](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) संग्रहित करता है और डेटा पढ़ने के लिए इसका उपयोग करता है। प्रेजेंटेशन सहेजते समय बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड-प्रोटेक्टेड है तो क्या करना चाहिए?**  
Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। सामान्य समाधान यह है कि पहले संरक्षण को हटाएं या एक डिक्रिप्टेड कॉपी तैयार करें (जैसे, [Aspose.Cells](/cells/net/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**  
हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगले डेटा लोड होने पर सभी चार्ट्स में बदलाव परिलक्षित होंगे।