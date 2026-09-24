---
title: एंड्रॉइड पर प्रस्तुतियों में चार्ट वर्कबुक का प्रबंधन
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
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java के माध्यम से Android के लिए Aspose.Slides खोजें: PowerPoint और OpenDocument फॉर्मैट में चार्ट वर्कबुक को सहजता से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह बताता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे उपयोग करें, वर्कशीट संग्रहों तक कैसे पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने पर भी प्रकाश डालता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और असाइन करें, चार्ट से जुड़े बाहरी वर्कबुक का पथ प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित करें।

वो वर्कबुक सेल जो अनुपलब्ध डेटा का प्रतिनिधित्व करते हैं, उनके बारे में अधिक जानने के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/androidjava/chart-series/) जहाँ खाली सेल और शून्य के बीच अंतर तथा उपलब्ध डिस्प्ले मोड की लाइन-चार्ट तुलना दी गई है।

## **वर्कबुक से चार्ट डेटा को पढ़ना और लिखना**
Aspose.Slides द्वारा प्रदान किए गए [ReadWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) मेथड्स आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को उसी रूप में व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

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

### **वर्कबुक संशोधित करने के बाद चार्ट लेआउट का सत्यापन**
जब आप एक एम्बेडेड वर्कबुक को संशोधित किए गए वर्कबुक से बदलते हैं, तो चार्ट अपने मूल सीरीज़ और कैटेगरी संग्रहों को बरकरार रखता है। यह असंगति [IChart.validateChartLayout](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChart#validateChartLayout--) को इंडेक्स-आउट-ऑफ-रेंज त्रुटि के साथ विफल कर सकती है। अद्यतन वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा सीरीज़ और कैटेगरी को साफ़ करें।

```java
// वर्कबुक स्ट्रीम को संशोधित करने के बाद (जैसे, Aspose.Cells का उपयोग करके)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// मौजूदा डेटा रेफ़रेंसेज़ को साफ़ करें।
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नए वर्कबुक के साथ संगत है, जिससे `validateChartLayout` बिना त्रुटियों के पूरा हो सकता है।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करना**

1. [Presentation](https://apireference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) वर्ग की एक इंस्टेंस बनाएं।  
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट सीरीज़ तक पहुँचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेज़ेंटेशन को सेव करें।

यह Java कोड दिखाता है कि वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे सेट किया जाता है:

```java
// एक प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
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

यह Java कोड एक ऑपरेशन दर्शाता है जहाँ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुँच प्राप्त की जाती है:

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

## **डेटा स्रोत प्रकार निर्दिष्ट करना**

यह Java कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाता है:

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाना**

Aspose.Slides कुछ चार्टों में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [IChartData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData) पर `getEmbeddedWorkbookType` मेथड और [WorkbookType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/WorkbookType) एन्यूमरेशन का उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्टों को छोड़ सकते हैं।

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
            // .xlsb फ़ॉर्मेट में एम्बेडेड वर्कबुक है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्टों के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक बनाना**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या किसी आंतरिक वर्कबुक को बाहरी बना सकते हैं।

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

### **बाहरी वर्कबुक सेट करना**

**`setExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को उसके डेटा स्रोत के रूप में बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

आप रिमोट लोकेशन या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, लेकिन ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया गया है, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह Java कोड दिखाता है कि बाहरी वर्कबुक कैसे सेट की जाती है:

```java
import com.aspose.slides.*;

// Presentation क्लास की एक इंस्टेंस बनाता है
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

`setExternalWorkbook` मेथड के अंतर्गत `updateChartData` पैरामीटर का उपयोग यह निर्दिष्ट करने के लिए किया जाता है कि Excel वर्कबुक लोड की जाएगी या नहीं।

* जब `updateChartData` को `false` पर सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाएगा। यह सेटिंग तब उपयोगी है जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है।  
* जब `updateChartData` को `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```java
import com.aspose.slides.*;

// Presentation क्लास की एक इंस्टेंस बनाता है
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

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करना**

1. [Presentation](https://apireference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) वर्ग की एक इंस्टेंस बनाएं।  
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
1. चार्ट आकार के लिए एक ऑब्जेक्ट बनाएं।  
1. स्रोत (`ChartDataSourceType`) प्रकार का एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।  
1. स्रोत प्रकार के समान बाहरी वर्कबुक डेटा स्रोत प्रकार होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

यह Java कोड ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;

// Presentation क्लास की एक इंस्टेंस बनाता है
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

आप बाहरी वर्कबुक के डेटा को उसी प्रकार संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री में परिवर्तन करते हैं। जब बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

यह Java कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```java
import com.aspose.slides.*;

// Presentation क्लास की एक इंस्टेंस बनाता है
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

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करना**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) बनाएं, उसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `true` के साथ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को कॉल करें।

निम्न Java उदाहरण वह प्रस्तुति खोलता है जिसमें चार्ट एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है और पुनः प्राप्त डेटा तक पहुंचता है [IChart.getChartData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#getChartData--) तथा [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook-- ) के माध्यम से:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // पुनः प्राप्त वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनः प्राप्ति निष्क्रिय है, तो Aspose.Slides अपवाद फेंकेगा। केवल तब पुनः प्राप्ति सक्षम करें जब कैश किया गया चार्ट डेटा एक स्वीकार्य बैकअप विकल्प हो, क्योंकि कैश में बाहरी वर्कबुक में अंतिम प्रस्तुति अपडेट के बाद किए गए बदलाव शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूं कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**  
हाँ। किसी चार्ट में एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) और एक [बाहरी वर्कबुक पथ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  
हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुकों का उपयोग कर सकता हूँ?**  
हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुकों को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रस्तुति एक [बाहरी फ़ाइल के लिंक](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) को संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति सहेजते समय बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**  
Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। आम तरीका यह है कि पहले सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी (उदाहरण के लिए [Aspose.Cells](/cells/androidjava/) का उपयोग करके) तैयार की जाए और उस कॉपी से लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**  
हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन प्रतिबिंबित होगा।