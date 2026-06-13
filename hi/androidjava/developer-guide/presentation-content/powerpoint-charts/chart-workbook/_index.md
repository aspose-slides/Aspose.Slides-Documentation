---
title: Android पर प्रस्तुतियों में चार्ट वर्कबुक प्रबंधन
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
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Java के माध्यम से Android के लिए Aspose.Slides की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपनी प्रस्तुति डेटा को सहज बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट वर्कबुक्स के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि कैसे वर्कबुक स्ट्रिम्स के माध्यम से चार्ट डेटा को पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रह तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को निर्दिष्ट करें।

यह बाहरी वर्कबुक्स को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**
Aspose.Slides प्रदान करता है [ReadWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) और [WriteWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) मेथड्स जो आपको चार्ट डेटा वर्कबुक्स (Aspose.Cells के साथ संपादित चार्ट डेटा सहित) को पढ़ने और लिखने की अनुमति देते हैं। **Note** कि चार्ट डेटा को उसी प्रकार व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

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

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।
4. चार्ट सीरीज़ तक पहुंचें।
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
6. प्रेजेंटेशन को सहेजें।

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का इंस्टेंस बनाता है
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

## **वर्कशीट्स प्रबंधित करें**

यह Java कोड दर्शाता है कि कैसे [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुंचा जा सकता है:

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

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह Java कोड दिखाता है कि कैसे डेटा स्रोत के लिए एक प्रकार निर्दिष्ट किया जाता है:

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

## **असमर्थित एम्बेडेड वर्कबुक फॉर्मेट्स का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को सपोर्ट नहीं करता। आप [IChartData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartData) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/WorkbookType) एनेमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट्स का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं।

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
            // एंबेडेड वर्कबुक .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक्स को सपोर्ट करता है।

### **बाहरी वर्कबुक बनाएं**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड्स का उपयोग करके आप या तो स्क्रैच से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

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

### **बाहरी वर्कबुक सेट करें**

**`setExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को उसके डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि बाद वाला स्थानांतरित किया गया हो)।

हालांकि आप रिमोट लोकेशन या संसाधनों में संग्रहीत वर्कबुक्स का डेटा संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक का रिलेटिव पथ प्रदान किया गया है, तो इसे स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है।

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

`setExternalWorkbook` मेथड के तहत `ChartData` पैरामीटर यह निर्दिष्ट करता है कि Excel वर्कबुक लोड किया जाएगा या नहीं।

* जब `ChartData` मान `false` पर सेट होता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। यह सेटिंग तब उपयोगी है जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है।  
* जब `ChartData` मान `true` पर सेट होता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

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

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
2. उसके इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।
4. स्रोत (`ChartDataSourceType`) प्रकार का एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।
5. उस स्थिति को निर्दिष्ट करें जो स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान हो।

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
	
	// प्रस्तुतिकरण सहेजता है
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक्स में डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक्स के कंटेंट को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक एक्सेप्शन उत्पन्न होता है।

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

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**  
हाँ। एक चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर यह पुष्टि कर सकते हैं कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक्स के रिलेटिव पाथ सपोर्टेड हैं, और वे कैसे संग्रहीत होते हैं?**  
हाँ। यदि आप एक रिलेटिव पाथ निर्दिष्ट करते हैं, तो इसे स्वचालित रूप से एब्सॉल्यूट पाथ में बदल दिया जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, प्रेजेंटेशन PPTX फ़ाइल में एब्सॉल्यूट पाथ स्टोर करता है।

**क्या मैं नेटवर्क रिसोर्सेज/शेयर्स पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**  
हाँ, ऐसे वर्कबुक्स को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। लेकिन Aspose.Slides से रिमोट वर्कबुक्स को सीधे संपादित करना सपोर्टेड नहीं है—वे केवल स्रोत के रूप में इस्तेमाल किए जा सकते हैं।

**क्या Aspose.Slides प्रेजेंटेशन सहेजते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रेजेंटेशन एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) स्टोर करता है और डेटा पढ़ने के लिए इसका उपयोग करता है। प्रेजेंटेशन सहेजने पर बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड-प्रोटेक्टेड है तो मुझे क्या करना चाहिए?**  
Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। आम तौर पर पहले सुरक्षा हटाकर या डिक्रिप्टेड कॉपी (उदाहरण के लिए [Aspose.Cells](/cells/androidjava/)) तैयार करके लिंक किया जाता है।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक को रेफ़र कर सकते हैं?**  
हाँ। प्रत्येक चार्ट अपना लिंक स्टोर करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने पर अगली बार डेटा लोड होने पर सभी चार्ट्स में परिवर्तन दर्शाए जाएंगे।