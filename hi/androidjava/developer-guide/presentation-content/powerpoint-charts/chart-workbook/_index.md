---
title: Android पर प्रस्तुतियों में चार्ट वर्कबुक्स को प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/androidjava/chart-workbook/
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
- वर्कबुक रिकवरी
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java के माध्यम से Android के लिए Aspose.Slides की खोज करें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक्स को आसानी से प्रबंधित करें ताकि आपकी प्रस्तुति डेटा सुगम हो सके।"
---
## **समीक्षा**

यह लेख Aspose.Slides में चार्ट वर्कबुक्स के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक्स को चार्ट डेटा स्रोतों के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाएँ और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides में [ReadWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) मेथड्स उपलब्ध हैं, जो आपको चार्ट डेटा वर्कबुक्स (Aspose.Cells के साथ संपादित चार्ट डेटा वाले) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को उसी क्रम में व्यवस्थित होना चाहिए या इसकी संरचना स्रोत के समान होनी चाहिए।

यह Java कोड एक नमूना ऑपरेशन दर्शाता है:

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

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करना**

1. [Presentation](https://apireference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास की एक instance बनाएँ।  
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट सीरीज़ तक पहुँचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेजेंटेशन को सहेजें।

यह Java कोड दिखाता है कि कैसे वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट किया जाता है:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
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

## **वर्कशीट्स का प्रबंधन**

यह Java कोड एक ऑपरेशन दर्शाता है जिसमें [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुँचा जाता है:

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

## **डेटा स्रोत प्रकार निर्दिष्ट करना**

यह Java कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाए:

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मैट्स की पहचान करना**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मैट को सपोर्ट नहीं करता जो कुछ चार्ट्स में एम्बेड किए जा सकते हैं। आप [IChartData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/WorkbookType) एन्न्यूमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मैट्स की पहचान कर सकते हैं और उन चार्ट्स को स्किप कर सकते हैं।

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
            // एम्बेडेड वर्कबुक .xlsb फ़ॉर्मैट में है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक्स का समर्थन करता है।

### **बाहरी वर्कबुक बनाना**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

यह Java कोड बाहरी वर्कबुक निर्माण प्रक्रिया दर्शाता है:

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

### **बाहरी वर्कबुक सेट करना**

**`setExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को उसकी डेटा स्रोत के रूप में बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

हालाँकि आप रिमोट लोकेशन या रिसोर्सेज़ में संग्रहीत वर्कबुक्स के डेटा को संपादित नहीं कर सकते, फिर भी आप ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए रिलेटिव पाथ प्रदान किया गया है, तो वह स्वचालित रूप से पूर्ण पाथ में बदल दिया जाता है।

यह Java कोड दिखाता है कि कैसे एक बाहरी वर्कबुक सेट की जाए:

```java
// Presentation क्लास की एक instance बनाता है
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

`setExternalWorkbook` मेथड के तहत `ChartData` पैरामीटर यह निर्धारित करता है कि क्या Excel वर्कबुक लोड किया जाएगा या नहीं।

* जब `ChartData` मान को `false` सेट किया जाता है, तो केवल वर्कबुक पाथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। यह सेटिंग तब उपयोगी है जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है।  
* जब `ChartData` मान को `true` सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```java
// Presentation क्लास की एक instance बनाता है
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

### **चार्ट की बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करना**

1. [Presentation](https://apireference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास की एक instance बनाएँ।  
1. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएँ।  
1. स्रोत (`ChartDataSourceType`) प्रकार का ऑब्जेक्ट बनाएँ जो चार्ट के डेटा स्रोत को दर्शाता है।  
1. संबंधित शर्त को निर्दिष्ट करें जो स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान हो।

यह Java कोड ऑपरेशन दर्शाता है:

```java
// Presentation क्लास की एक instance बनाता है
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

### **चार्ट डेटा संपादित करना**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक्स की सामग्री में परिवर्तन करते हैं। जब किसी बाहरी वर्कबुक को लोड नहीं किया जा सकता, तो एक एक्सेप्शन फेंका जाता है।

यह Java कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```java
// Presentation क्लास की एक instance बनाता है
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

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करना**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रेजेंटेशन में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) बनाएँ, इसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रेजेंटेशन खोलने से पहले `true` के साथ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को कॉल करें।

निम्नलिखित Java उदाहरण एक प्रेजेंटेशन खोलता है जिसका चार्ट अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है और पुनर्प्राप्त डेटा को [IChart.getChartData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से एक्सेस करता है:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और रीकोवरी अक्षम है, तो Aspose.Slides एक एक्सेप्शन फेंकेगा। केवल तभी रीकोवरी को सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य बैकअप माना जाए, क्योंकि कैश में बाहरी वर्कबुक में अंतिम अपडेट के बाद किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। एक चार्ट में [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) और एक [बाहरी वर्कबुक पाथ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर पुष्टि कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक्स के रिलेटिव पाथ सपोर्ट किए जाते हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से एब्सोल्यूट पाथ में बदल जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, प्रेजेंटेशन PPTX फ़ाइल में एब्सोल्यूट पाथ संग्रहीत करेगा।

**क्या मैं नेटवर्क रिसोर्सेज़/शेयर पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में इस्तेमाल किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक्स को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रेजेंटेशन सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रेजेंटेशन एक [बाहरी फ़ाइल लिंक](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) संग्रहीत करता है और डेटा पढ़ने के लिए इसका उपयोग करता है। प्रेजेंटेशन सहेजते समय बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड-प्रोटेक्टेड है तो मैं क्या करूँ?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका यह है कि पहले प्रोटेक्शन हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, [Aspose.Cells](/cells/androidjava/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो फ़ाइल में किए गए अपडेट अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिलक्षित होंगे।