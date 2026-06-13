---
title: Java का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
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
- बाह्य वर्कबुक
- बाह्य डेटा
- PowerPoint
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java खोजें: PowerPoint और OpenDocument स्वरूपों में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपनी प्रेजेंटेशन डेटा को सुव्यवस्थित करें।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में कैसे उपयोग करें, वर्कशीट कलेक्शन तक कैसे पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाह्य वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाह्य वर्कबुक बनाएँ और असाइन करें, एक चार्ट से जुड़े बाह्य वर्कबुक का पाथ प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित करें।

## **चार्ट डेटा को वर्कबुक से पढ़ना और लिखना**
Aspose.Slides प्रदान करता है [ReadWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData#readWorkbookStream--) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) मेथड्स जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells से संपादित चार्ट डेटा है) पढ़ने और लिखने की अनुमति देते हैं। **Note** कि चार्ट डेटा को उसी तरीके से व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

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

1. [Presentation](https://apireference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
2. स्लाइड का रेफ़रेंस उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
4. चार्ट सीरीज़ तक पहुंचें।  
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
6. प्रेजेंटेशन को सेव करें।  

यह Java कोड आपको वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करने का तरीका दिखाता है:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टैंस बनाता है
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

## **वर्कशीट्स को प्रबंधित करना**
यह Java कोड दर्शाता है कि कैसे [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) मेथड का उपयोग करके वर्कशीट कलेक्शन तक पहुँचा जाता है:

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

## **डेटा सोर्स टाइप निर्दिष्ट करना**
यह Java कोड आपको डेटा स्रोत के लिए टाइप निर्दिष्ट करने का तरीका दिखाता है:

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

## **असमर्थित एम्बेडेड वर्कबुक फॉर्मैट्स का पता लगाना**
Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फॉर्मैट को सपोर्ट नहीं करता जो कुछ चार्ट्स में एम्बेड किए जा सकते हैं। आप `getEmbeddedWorkbookType` मेथड को [IChartData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData) पर और [WorkbookType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/WorkbookType) एन्नमरेशन के साथ उपयोग कर सकते हैं ताकि असमर्थित फॉर्मैट्स का पता लगाया जा सके और उन चार्ट्स को स्किप किया जा सके।

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
            // एम्बेडेड वर्कबुक .xlsb फॉर्मेट में है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाह्य वर्कबुक**

{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/hi/java/aspose-slides-for-java-19-4-release-notes/) में हमने चार्ट्स के लिए डेटा स्रोत के रूप में बाह्य वर्कबुक का समर्थन लागू किया है। 
{{% /alert %}} 

### **बाह्य वर्कबुक बनाना**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड्स का उपयोग करके आप शून्य से एक बाह्य वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाह्य बना सकते हैं।

यह Java कोड बाह्य वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

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

### **बाह्य वर्कबुक सेट करना**

**`setExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को उसका डेटा स्रोत बनाने के लिए बाह्य वर्कबुक असाइन कर सकते हैं। यह मेथड बाह्य वर्कबुक के पाथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि बाद वाला स्थानांतरित हो गया हो)।

हालांकि आप रिमोट लोकेशन या रिसोर्सेज में संग्रहीत वर्कबुक्स के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक्स को बाह्य डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाह्य वर्कबुक के लिए रिलेटिव पाथ प्रदान किया जाता है, तो इसे स्वचालित रूप से पूर्ण पाथ में परिवर्तित कर दिया जाता है।

यह Java कोड आपको बाह्य वर्कबुक सेट करने का तरीका दिखाता है:

```java
// Presentation क्लास का एक इंस्टैंस बनाता है
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

`ChartData` पैरामीटर (`setExternalWorkbook` मेथड के अंतर्गत) यह निर्धारित करने के लिए उपयोग किया जाता है कि Excel वर्कबुक लोड किया जाएगा या नहीं।

* जब `ChartData` मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पाथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। आप इस सेटिंग का उपयोग तब कर सकते हैं जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।  
* जब `ChartData` मान `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

```java
// Presentation क्लास का एक इंस्टैंस बनाता है
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

### **चार्ट के बाह्य डेटा सोर्स वर्कबुक पथ को प्राप्त करना**

1. [Presentation](https://apireference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
2. स्लाइड का रेफ़रेंस उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
4. स्रोत (`ChartDataSourceType`) टाइप के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत का प्रतिनिधित्व करता है।  
5. उस शर्त को निर्दिष्ट करें जो स्रोत टाइप को बाह्य वर्कबुक डेटा स्रोत टाइप के समान होने पर लागू होती है।  

यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
// Presentation क्लास का एक इंस्टैंस बनाता है
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// प्रेजेंटेशन को सहेजता है
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **चार्ट डेटा संपादित करना**
आप बाह्य वर्कबुक्स में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक्स की सामग्री में परिवर्तन करते हैं। जब कोई बाह्य वर्कबुक लोड नहीं हो पाती है, तो एक एक्सेप्शन फेंका जाता है।

यह Java कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```java
// Presentation क्लास का एक इंस्टैंस बनाता है
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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाह्य या एम्बेडेड वर्कबुक से लिंक्ड है?**  
हाँ। चार्ट में एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getDataSourceType--) और एक [बाह्य वर्कबुक का पाथ](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत एक बाह्य वर्कबुक है, तो आप पूर्ण पाथ पढ़ कर यह सुनिश्चित कर सकते हैं कि बाह्य फ़ाइल उपयोग में है।

**क्या बाह्य वर्कबुक्स के रिलेटिव पाथ्स सपोर्टेड हैं, और वे कैसे संग्रहीत होते हैं?**  
हाँ। यदि आप एक रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से एक एब्सोल्यूट पाथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रेजेंटेशन PPTX फ़ाइल में एब्सोल्यूट पाथ संग्रहीत करता है।

**क्या मैं नेटवर्क रिसोर्सेज/शेयर्स पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**  
हाँ, ऐसे वर्कबुक्स को बाह्य डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक्स को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रेजेंटेशन सेव करने पर बाह्य XLSX को ओवरराइट करता है?**  
नहीं। प्रेजेंटेशन एक [बाह्य फ़ाइल के लिंक](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) को संग्रहीत करता है और डेटा पढ़ने के लिए इसका उपयोग करता है। प्रेजेंटेशन सेव करने पर बाह्य फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाह्य फ़ाइल पासवर्ड से सुरक्षित हो तो मुझे क्या करना चाहिए?**  
Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। एक सामान्य दृष्टिकोण यह है कि पहले सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](/cells/java/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट्स एक ही बाह्य वर्कबुक को रेफ़र कर सकते हैं?**  
हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन परिलक्षित होगा।