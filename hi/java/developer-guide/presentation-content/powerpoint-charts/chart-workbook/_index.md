---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक्स का प्रबंधन
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "जावा के लिए Aspose.Slides की खोज करें: PowerPoint और OpenDocument फॉर्मैट में चार्ट वर्कबुक्स को आसानी से प्रबंधित करें ताकि आपके प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **Overview**

यह लेख Aspose.Slides में चार्ट वर्कबुक्स के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में कैसे उपयोग करें, वर्कशीट संग्रहों तक कैसे पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाएँ और असाइन करें, चार्ट से जुड़े बाहरी वर्कबुक का पथ प्राप्त करें, तथा वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित करें।

## **Read and Write Chart Data from a Workbook**
Aspose.Slides [ReadWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData#readWorkbookStream--) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) मेथड्स प्रदान करता है जो आपको चार्ट डेटा वर्कबुक्स (जो Aspose.Cells के साथ संपादित किए गए हैं) को पढ़ने और लिखने की अनुमति देते हैं। **Note** कि चार्ट डेटा को समान रूप से व्यवस्थित होना चाहिए या स्रोत के समान संरचना होना चाहिए।

यह Java कोड एक नमूना ऑपरेशन को दर्शाता है:

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set a WorkBook Cell as a Chart Data Label**

1. [Presentation](https://apireference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
4. चार्ट सीरीज़ तक पहुंचें।  
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
6. प्रेजेंटेशन को सहेजें।

यह Java कोड दिखाता है कि वर्कबुक सेल को चार्ट डेटा लेबल कैसे सेट करें:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले प्रस्तुति क्लास का एक उदाहरण बनाता है
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Worksheets**

यह Java कोड दिखाता है कि कैसे [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुंचा जा सकता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specify the Data Source Type**

यह Java कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मैट को सपोर्ट नहीं करता जिसे कुछ चार्ट्स में एम्बेड किया जा सकता है। आप [IChartData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/WorkbookType) एनेमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मैट की पहचान कर सकते हैं और उन चार्ट्स को स्किप कर सकते हैं।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // एम्बेडेड वर्कबुक .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है.
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें.
    }
} finally {
    presentation.dispose();
}
```

## **External Workbook**

{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/hi/java/aspose-slides-for-java-19-4-release-notes/) में, हमने चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक्स का समर्थन लागू किया है।
{{% /alert %}} 

### **Create an External Workbook**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

यह Java कोड बाहरी वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Set an External Workbook**

**`setExternalWorkbook`** मेथड का उपयोग करके आप चार्ट को उसकी डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि बाद वाला स्थानांतरित किया गया हो)।

हालांकि आप रिमोट स्थानों या संसाधनों में संग्रहीत वर्कबुक्स के डेटा को संपादित नहीं कर सकते, फिर भी आप इन्हें बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए रिलेटिव पाथ दिया जाता है, तो यह स्वचालित रूप से पूर्ण पाथ में बदल जाता है।

यह Java कोड दिखाता है कि कैसे एक बाहरी वर्कबुक सेट करें:

```java
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

`ChartData` पैरामीटर (`setExternalWorkbook` मेथड के अंतर्गत) यह निर्दिष्ट करता है कि क्या Excel वर्कबुक लोड की जाएगी या नहीं।

* जब `ChartData` मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पाथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता। यह सेटिंग तब उपयोगी है जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है।  
* जब `ChartData` मान `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```java
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Get the External Data Source Workbook Path of a Chart**

1. [Presentation](https://apireference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
4. स्रोत (`ChartDataSourceType`) प्रकार का एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।  
5. संबंधित शर्त को निर्दिष्ट करें जिससे स्रोत प्रकार बाहरी वर्कबुक डेटा स्रोत प्रकार के समान हो।

यह Java कोड ऑपरेशन को दर्शाता है:

```java
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// प्रस्तुति को सहेजता है
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Edit Chart Data**

आप बाहरी वर्कबुक्स के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक्स की सामग्री में परिवर्तन करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं की जा सकती, तो एक अपवाद फेंका जाता है।

यह Java कोड वर्णित प्रक्रिया को लागू करता है:

```java
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Recover a Workbook from the Chart Cache**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्माण कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) बनाएं, उसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `true` के साथ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को कॉल करें।

निम्नलिखित Java उदाहरण एक ऐसी प्रस्तुति खोलता है जिसका चार्ट अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है और पुनर्प्राप्त डेटा को [IChart.getChartData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से एक्सेस करता है:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें.
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकेगा। केवल तभी पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा को फ़ॉलबैक के रूप में स्वीकार्य हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बाद के परिवर्तन नहीं हो सकते।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट में [data source type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getDataSourceType--) और एक [path to an external workbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर यह सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक्स के लिए रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो यह स्वचालित रूप से एब्सोल्यूट पाथ में बदल दिया जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालाँकि, प्रस्तुति PPTX फ़ाइल में एब्सोल्यूट पाथ संग्रहीत करती है।

**क्या मैं नेटवर्क रिसोर्सेज/शेयर्स पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**

हाँ, ऐसी वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक्स को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति सहेजते समय बाहरी फ़ाइल स्वयं नहीं बदली जाती।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड हो तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। सामान्य उपाय यह है कि पहले संरक्षण हटाया जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](/cells/java/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल को संकेत करते हैं, तो उस फ़ाइल में किए गए अपडेट अगले बार डेटा लोड होने पर प्रत्येक चार्ट में प्रतिबिंबित होंगे।