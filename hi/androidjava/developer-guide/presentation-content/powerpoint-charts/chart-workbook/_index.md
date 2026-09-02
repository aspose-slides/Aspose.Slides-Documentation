---
title: Android पर प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/androidjava/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- कार्यपत्रक
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
description: "Java के माध्यम से Android के लिए Aspose.Slides की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपकी प्रस्तुति डेटा सुव्यवस्थित हो सके।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को कैसे पढ़ा और लिखा जाए, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में कैसे उपयोग किया जाए, वर्कशीट कलेक्शन तक कैसे पहुँचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने पर भी प्रकाश डालता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित किया जाए।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**
Aspose.Slides [ReadWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा वाले) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को समान तरीके से व्यवस्थित होना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह Java कोड एक उदाहरण ऑपरेशन दर्शाता है:

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को वैध करें**

जब आप एक एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल सीरीज और कैटेगरी कलेक्शन को बनाए रखता है। यह विसंगति [IChart.validateChartLayout](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChart#validateChartLayout--) को इंडेक्स‑आउट‑ऑफ‑रेंज त्रुटि के साथ असफल बना सकती है। अपडेटेड वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज और कैटेगरी को स्पष्ट रूप से हटा दें।

```java
// वर्कबुक स्ट्रीम को संशोधित करने के बाद (जैसे, Aspose.Cells का उपयोग करके)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// मौजूदा डेटा रेफरेंसेज़ को साफ़ करें।
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

कलेक्शन को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई वर्कबुक के साथ सुसंगत है, जिससे `validateChartLayout` बिना त्रुटि के पूर्ण हो जाता है।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
1. उसके इंडेक्स के द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट सीरीज तक पहुँचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेज़ेंटेशन को सेव करें।

यह Java कोड दिखाता है कि वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे सेट किया जाए:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली प्रेज़ेंटेशन क्लास का उदाहरण बनाता है
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

यह Java कोड [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) मेथड का उपयोग करके वर्कशीट कलेक्शन तक पहुँचने का उदाहरण प्रस्तुत करता है:

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

यह Java कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाए:

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

Aspose.Slides कुछ चार्ट में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप [IChartData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/WorkbookType) एन्ह्यूमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं।

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

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का समर्थन करता है।

### **बाहरी वर्कबुक बनाएँ**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड का उपयोग करके आप या तो नई बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

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

### **बाहरी वर्कबुक असाइन करें**

**`setExternalWorkbook`** मेथड का प्रयोग करके आप एक बाहरी वर्कबुक को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। इस मेथड का उपयोग बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी किया जा सकता है (यदि उसे स्थानांतरित किया गया हो)।

भले ही आप रिमोट लोकेशन या रिसोर्स में संग्रहीत वर्कबुक का डेटा संपादित न कर सकें, आप फिर भी ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए रिलेटिव पाथ दिया गया है, तो वह स्वचालित रूप से पूर्ण पाथ में बदल दिया जाता है।

यह Java कोड दिखाता है कि बाहरी वर्कबुक कैसे सेट करें:

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

`setExternalWorkbook` मेथड के तहत `updateChartData` पैरामीटर यह निर्धारित करता है कि Excel वर्कबुक लोड की जाएगी या नहीं।

* जब `updateChartData` का मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पाथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। यह सेटिंग उन स्थितियों में उपयोगी है जहाँ लक्ष्य वर्कबुक अस्तित्व में नहीं है या उपलब्ध नहीं है।  
* जब `updateChartData` का मान `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

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

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
1. उसके इंडेक्स के द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएँ।  
1. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएँ जो चार्ट के डेटा स्रोत का प्रतिनिधित्व करता है।  
1. स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

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

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आंतरिक वर्कबुक के कंटेंट को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

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

### **वर्कबुक को चार्ट कैश से पुनः प्राप्त करें**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रेज़ेंटेशन में संग्रहित डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) बनाएँ, उसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रेज़ेंटेशन खोलने से पहले `true` के साथ [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को कॉल करें।

निम्नलिखित Java उदाहरण एक प्रेज़ेंटेशन खोलता है जिसमें चार्ट एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है और पुनः प्राप्त डेटा तक पहुँचता है via [IChart.getChartData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

    // यहाँ पुनः प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनः प्राप्ति निष्क्रिय है, तो Aspose.Slides एक अपवाद फेंकेगा। केवल तब पुनः प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा को फॉलबैक के रूप में उपयोग करना स्वीकार्य हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**  
हाँ। चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) और एक [बाहरी वर्कबुक का पाथ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर यह सुनिश्चित कर सकते हैं कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  
हाँ। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वतः ही एब्सॉल्यूट पाथ में बदल दिया जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, प्रेज़ेंटेशन PPTX फ़ाइल में एब्सॉल्यूट पाथ को स्टोर करता है।

**क्या मैं नेटवर्क रिसोर्स/शेयर पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**  
हाँ, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। लेकिन Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित किया नहीं जा सकता—वे केवल स्रोत के रूप में उपयोग होती हैं।

**क्या Aspose.Slides प्रस्तुति को सेव करते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रस्तुति एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) स्टोर करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति को सेव करने पर बाहरी फ़ाइल स्वयं नहीं बदली जाती।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड है तो मुझे क्या करना चाहिए?**  
Aspose.Slides लिंक करते समय पासवर्ड नहीं लेता। एक सामान्य उपाय यह है कि पहले प्रोटेक्शन हटाया जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](/cells/androidjava/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**  
हाँ। प्रत्येक चार्ट अपना लिंक स्टोर करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल में किया गया अपडेट अगली बार डेटा लोड होने पर सभी चार्ट में प्रतिबिंबित होगा।