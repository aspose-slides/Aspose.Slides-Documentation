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
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java को खोजें: PowerPoint और OpenDocument स्वरूपों में चार्ट वर्कबुक को सहजता से प्रबंधित करें ताकि आपकी प्रस्तुति डेटा को बेहतर बनाया जा सके।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रह तक पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि बाहरी वर्कबुक कैसे बनाएं और असाइन करें, चार्ट से लिंक की गई बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**
Aspose.Slides प्रदान करता है [ReadWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData#readWorkbookStream--) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) मेथड्स जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा) को पढ़ने और लिखने की अनुमति देते हैं। **नोट** कि चार्ट डेटा को समान क्रम में व्यवस्थित होना चाहिए या उसके संरचना स्रोत के समान होनी चाहिए।

यह Java कोड एक नमूना ऑपरेशन दर्शाता है:

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को मान्य करें**
जब आप एक एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रह को बनाए रखता है। यह असंगति `chart.validateChartLayout()` को `ArgumentOutOfRangeException` (पैरामीटर: index) फेंकने का कारण बन सकती है। अपवाद से बचने के लिए, अपडेटेड वर्कबुक को चार्ट में वापस लिखने **से पहले** मौजूदा सीरीज़ और श्रेणियों को साफ़ करें।

```java
// वर्कबुक स्ट्रीम को संशोधित करने के बाद (उदा., Aspose.Cells का उपयोग करके)
byte[] updatedWorkbook = baos.toByteArray();

// मौजूदा डेटा रेफ़रेंसेज़ को साफ़ करें।
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// अपडेटेड वर्कबुक को चार्ट में वापस लिखें।
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// अब वैधता सफल होती है।
chart.validateChartLayout();
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई वर्कबुक के साथ मेल खाती है, जिससे `validateChartLayout()` त्रुटियों के बिना पूरा हो सकता है।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**
1. [Presentation](https://apireference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
4. चार्ट सीरीज़ तक पहुँचें।  
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
6. प्रेजेंटेशन को सहेजें।

यह Java कोड आपको वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करने को दर्शाता है:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रेजेंटेशन क्लास का उदाहरण बनाता है
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instantiates a presentation class that represents a presentation file
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
यह Java कोड आपको डेटा स्रोत के लिए प्रकार निर्दिष्ट करने को दिखाता है:

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**
Aspose.Slides कुछ चार्ट्स में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप [IChartData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartData) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/WorkbookType) एन्नुमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं।

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
            // एम्बेडेड वर्कबुक .xlsb फॉर्मैट में है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**
{{% alert color="info" %}} 
Aspose.Slides 19.4 में, हमने चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का समर्थन लागू किया।
{{% /alert %}} 

### **एक बाहरी वर्कबुक बनाएं**
**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

यह Java कोड बाहरी वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

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

### **एक बाहरी वर्कबुक सेट करें**
**`setExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को उसका डेटा स्रोत के रूप में बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिये भी उपयोग किया जा सकता है (यदि बाद वाला स्थानांतरित हो गया हो)।

जब आप रिमोट लोकेशन या संसाधन में संग्रहित वर्कबुक के डेटा को संपादित नहीं कर सकते, तब भी आप ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए रिलेटिव पाथ प्रदान किया गया है, तो वह स्वतः पूर्ण पाथ में परिवर्तित हो जाता है।

यह Java कोड आपको बाहरी वर्कबुक सेट करने को दिखाता है:

```java
import com.aspose.slides.*;

// Presentation क्लास का एक उदाहरण बनाता है
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

`setExternalWorkbook` मेथड का दूसरा (`boolean`) पैरामीटर यह निर्धारित करता है कि एक्सेल वर्कबुक लोड की जाएगी या नहीं। 

* जब इसका मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पाथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता। इस सेटिंग का उपयोग तब किया जा सकता है जब लक्ष्य वर्कबुक मौजूद नहीं हो या उपलब्ध न हो।  
* जब इसका मान `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```java
import com.aspose.slides.*;

// Presentation क्लास का एक उदाहरण बनाता है
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

### **एक चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ को प्राप्त करें**
1. [Presentation](https://apireference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएँ।  
4. डेटा स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएँ जो चार्ट के डेटा स्रोत का प्रतिनिधित्व करता है।  
5. स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

यह Java कोड ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;

// Presentation क्लास का एक उदाहरण बनाता है
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
आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक की सामग्री में बदलाव करते हैं। जब बाहरी वर्कबुक लोड नहीं की जा सकती, तो एक अपवाद फेंका जाता है।

यह Java कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```java
import com.aspose.slides.*;

// Presentation क्लास का एक उदाहरण बनाता है
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

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**
यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो अनुपस्थित या उपलब्ध नहीं है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) बनाएँ, इसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `true` के साथ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को कॉल करें।

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

    // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक उपलब्ध नहीं है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकेगा। केवल तब पुनर्प्राप्ति सक्षम करें जब कैश किया गया चार्ट डेटा एक स्वीकार्य बैकअप माना जा सके, क्योंकि कैश में बाहरी वर्कबुक में अंतिम प्रस्तुति अपडेट के बाद किए गए बदलाव नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से लिंक्ड है?**  
हाँ। एक चार्ट के पास [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getDataSourceType--) और [एक बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं यह सुनिश्चित करने के लिए कि एक बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  
हाँ। यदि आप एक रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वतः एक एब्सॉल्यूट पाथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रस्तुति एब्सॉल्यूट पाथ को PPTX फ़ाइल में संग्रहीत करेगी।

**क्या मैं नेटवर्क संसाधन/शेयर पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**  
हाँ, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में प्रयुक्त हो सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रस्तुति एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) संग्रहीत करती है और डेटा पढ़ने के लिए उसे उपयोग करती है। प्रस्तुति सहेजते समय बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड है तो मुझे क्या करना चाहिए?**  
Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले से प्रोटेक्शन हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, [Aspose.Cells](/cells/java/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**  
हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल को दर्शाते हैं, तो फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन परिलक्षित होगा।