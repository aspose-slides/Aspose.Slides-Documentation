---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट कार्यपुस्तिकाओं का प्रबंधन
linktitle: चार्ट कार्यपुस्तिका
type: docs
weight: 70
url: /hi/java/chart-workbook/
keywords:
- चार्ट कार्यपुस्तिका
- चार्ट डेटा
- कार्यपुस्तिका सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाह्य कार्यपुस्तिका
- बाह्य डेटा
- चार्ट कैश
- कार्यपुस्तिका पुनरुद्धार
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java को खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट कार्यपुस्तिकाओं का सहजता से प्रबंधन करें ताकि आपकी प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **समीक्षा**

यह लेख Aspose.Slides में चार्ट कार्यपुस्तिकाओं के साथ काम करने का विवरण देता है। यह दिखाता है कि कार्यपुस्तिका स्ट्रिम्स के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, कार्यपुस्तिका सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार कैसे निर्दिष्ट करें।

यह बाह्य कार्यपुस्तिकाओं को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाह्य कार्यपुस्तिका बनाएं और असाइन करें, चार्ट से जुड़ी बाह्य कार्यपुस्तिका का पाथ कैसे प्राप्त करें, और जब कार्यपुस्तिका उपलब्ध हो तो चार्ट डेटा को संपादित करें।

## **कार्यपुस्तिका से चार्ट डेटा को पढ़ना और लिखना**

Aspose.Slides [ReadWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData#readWorkbookStream--) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) मेथड्स प्रदान करता है जो आपको चार्ट डेटा कार्यपुस्तिकाओं (Aspose.Cells के साथ संपादित चार्ट डेटा वाली) को पढ़ने और लिखने की अनुमति देता है। **ध्यान दें** कि चार्ट डेटा को उसी क्रम में व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होना चाहिए।

```java
import com.aspose.slides.*;

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

### **कार्यपुस्तिका संशोधन के बाद चार्ट लेआउट की मान्यताप्राप्ति**

जब आप एम्बेडेड कार्यपुस्तिका को संशोधित कार्यपुस्तिका से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बनाए रखता है। यह असंगतता [IChart.validateChartLayout](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#validateChartLayout--) को `ArgumentOutOfRangeException` (parameter: index) उत्पन्न करने का कारण बन सकती है। अपवाद से बचने के लिए, अपडेटेड कार्यपुस्तिका को चार्ट में लिखने से **पहले** मौजूदा श्रृंखला और श्रेणियों को साफ़ करें।

```java
// कार्यपुस्तिका स्ट्रिम को संशोधित करने के बाद (उदाहरण के लिए, Aspose.Cells का उपयोग करके)
byte[] updatedWorkbook = baos.toByteArray();

// मौजूदा डेटा रेफरेंसेज को साफ़ करें।
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई कार्यपुस्तिका के साथ मेल खाती है, जिससे `validateChartLayout` त्रुटियों के बिना पूरा हो पाता है।

## **कार्यपुस्तिका सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट की श्रृंखला तक पहुँचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेजेंटेशन को सेव करें।

यह Java कोड दिखाता है कि कैसे वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट किया जाए:

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले प्रस्तुति वर्ग को इंस्टैंसिएट करता है
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

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

यह Java कोड एक ऑपरेशन दर्शाता है जहाँ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुँच प्राप्त की जाती है:

```java
import com.aspose.slides.*;

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

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह Java कोड दर्शाता है कि कैसे डेटा स्रोत के लिए प्रकार निर्दिष्ट किया जाए:

```java
import com.aspose.slides.*;

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

## **असमर्थित एम्बेडेड कार्यपुस्तिका स्वरूपों का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी कार्यपुस्तिकाओं (.xlsb) को समर्थन नहीं देता जो कुछ चार्ट में एम्बेड की जा सकती हैं। आप [IChartData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData) पर `getEmbeddedWorkbookType` मेथड के साथ [WorkbookType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/WorkbookType) एनेमरेशन का उपयोग करके असमर्थित स्वरूपों का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // एम्बेडेड कार्यपुस्तिका .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट कार्यपुस्तिका डेटा को पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाह्य कार्यपुस्तिका**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/hi/java/aspose-slides-for-java-19-4-release-notes/) में, हमने चार्ट के डेटा स्रोत के रूप में बाह्य कार्यपुस्तिकाओं के समर्थन को लागू किया। 
{{% /alert %}} 

### **बाह्य कार्यपुस्तिका बनाएं**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाह्य कार्यपुस्तिका बना सकते हैं या एक आंतरिक कार्यपुस्तिका को बाह्य बना सकते हैं।

यह Java कोड बाह्य कार्यपुस्तिका निर्माण प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

### **बाह्य कार्यपुस्तिका सेट करें**

**`setExternalWorkbook`** मेथड का उपयोग करके आप एक बाह्य कार्यपुस्तिका को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाह्य कार्यपुस्तिका के पाथ को अपडेट करने के लिए भी इस्तेमाल किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

रिमोट लोकेशंस या रिसोर्सेज़ में संग्रहीत कार्यपुस्तिकाओं के डेटा को आप संपादित नहीं कर सकते, लेकिन इन्हें बाह्य डेटा स्रोत के रूप में अभी भी उपयोग किया जा सकता है। यदि बाह्य कार्यपुस्तिका के लिए रिलेटिव पाथ प्रदान किया जाता है, तो इसे स्वतः पूर्ण पाथ में बदल दिया जाता है।

यह Java कोड दिखाता है कि कैसे बाह्य कार्यपुस्तिका सेट की जाए:

```java
import com.aspose.slides.*;

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

`setExternalWorkbook` मेथड का दूसरा (`boolean`) पैरामीटर यह निर्दिष्ट करता है कि Excel कार्यपुस्तिका लोड होगी या नहीं।

* जब इसका मान `false` रखा जाता है, तो केवल कार्यपुस्तिका पाथ अपडेट होता है—चार्ट डेटा लक्ष्य कार्यपुस्तिका से लोड या अपडेट नहीं होगा। आप इस सेटिंग का उपयोग तब कर सकते हैं जब लक्ष्य कार्यपुस्तिका मौजूद न हो या उपलब्ध न हो।  
* जब इसका मान `true` रखा जाता है, तो चार्ट डेटा लक्ष्य कार्यपुस्तिका से अपडेट हो जाता है।

```java
import com.aspose.slides.*;

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

### **चार्ट की बाह्य डेटा स्रोत कार्यपुस्तिका पाथ प्राप्त करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
1. डेटा स्रोत प्रकार (`ChartDataSourceType`) को दर्शाने वाला एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को प्रस्तुत करता है।  
1. उपयुक्त शर्त निर्दिष्ट करें कि स्रोत प्रकार बाह्य कार्यपुस्तिका डेटा स्रोत प्रकार के समान है या नहीं।

यह Java कोड ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;

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

### **चार्ट डेटा संपादित करें**

आप बाह्य कार्यपुस्तिकाओं के डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक कार्यपुस्तिकाओं के सामग्री को बदलते हैं। जब एक बाह्य कार्यपुस्तिका लोड नहीं हो पाती, तो एक एक्सेप्शन फेंका जाता है।

यह Java कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```java
import com.aspose.slides.*;

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

### **चार्ट कैश से कार्यपुस्तिका पुनः प्राप्त करें**

यदि कोई चार्ट बाह्य कार्यपुस्तिका का उपयोग करता है जो अनुपलब्ध या गायब है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट कार्यपुस्तिका को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) बनाएं, उसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `true` के साथ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को कॉल करें।

निम्नलिखित Java उदाहरण एक प्रस्तुति खोलता है जिसकी चार्ट एक अनुपलब्ध बाह्य कार्यपुस्तिका को संदर्भित करता है और पुनः प्राप्त डेटा को [IChart.getChartData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#getChartData--) तथा [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से एक्सेस करता है:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // यहाँ पुनर्प्राप्त कार्यपुस्तिका डेटा को पढ़ें या संशोधित करें।
} finally {
    presentation.dispose();
}
```

यदि बाह्य कार्यपुस्तिका अनुपलब्ध है और पुनरुद्धार निष्क्रिय है, तो Aspose.Slides एक एक्सेप्शन फेंकेगा। केवल तभी पुनरुद्धार सक्षम करें जब कैश्ड चार्ट डेटा को फॉलबैक के रूप में उपयोग करना स्वीकार्य हो, क्योंकि कैश में बाह्य कार्यपुस्तिका में किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाह्य या एम्बेडेड कार्यपुस्तिका से जुड़ा है?**  

हाँ। एक चार्ट के पास [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getDataSourceType--) और एक [बाह्य कार्यपुस्तिका पाथ](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत बाह्य कार्यपुस्तिका है, तो आप पूर्ण पाथ पढ़कर सुनिश्चित कर सकते हैं कि बाह्य फ़ाइल का उपयोग किया जा रहा है।

**क्या बाह्य कार्यपुस्तिकाओं के लिए रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  

हाँ। यदि आप एक रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वतः एक एब्सॉल्यूट पाथ में बदल जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, प्रस्तुति PPTX फ़ाइल में एब्सॉल्यूट पाथ को स्टोर करेगी।

**क्या मैं नेटवर्क रिसोर्सेज़/शेयर पर स्थित कार्यपुस्तिकाओं का उपयोग कर सकता हूँ?**  

हाँ, ऐसी कार्यपुस्तिकाओं को बाह्य डेटा स्रोत के रूप में उपयोग किया जा सकता है। लेकिन Aspose.Slides से सीधे रिमोट कार्यपुस्तिकाओं को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति को सेव करने पर बाह्य XLSX को ओवरराइट करता है?**  

नहीं। प्रस्तुति एक [बाह्य फ़ाइल लिंक](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) को स्टोर करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति को सेव करने पर बाह्य फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाह्य फ़ाइल पासवर्ड-प्रोटेक्टेड है तो मुझे क्या करना चाहिए?**  

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। आम तौर पर पहले सुरक्षा हटाना या एक डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिए, [Aspose.Cells](/cells/java/) का उपयोग करके) और उस कॉपी को लिंक करना बेहतर होता है।

**क्या कई चार्ट एक ही बाह्य कार्यपुस्तिका को संदर्भित कर सकते हैं?**  

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल में परिवर्तन अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिलक्षित होगा।