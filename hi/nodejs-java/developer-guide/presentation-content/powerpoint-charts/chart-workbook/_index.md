---
title: JavaScript का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides को Java के माध्यम से खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपनी प्रेजेंटेशन डेटा को सुव्यवस्थित करें।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के बारे में बताता है। यह दर्शाता है कि वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि बाहरी वर्कबुक को कैसे बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को कैसे संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides [readWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा वाली) को पढ़ने और लिखने की अनुमति देता है। **ध्यान दें** कि चार्ट डेटा को समान तरीके से व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

This JavaScript code demonstrates a sample operation:

```javascript
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।
3. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।
4. चार्ट सीरीज़ तक पहुंचें।
5. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
6. प्रेजेंटेशन सहेजें।

This JavaScript code shows you to set a workbook cell as a chart data label:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// प्रस्तुति फ़ाइल को दर्शाने वाली प्रस्तुति क्लास को इंस्टेनशिएट करता है
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **वर्कशीट प्रबंधित करें**

This JavaScript code demonstrates an operation where the [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) method is used to access a worksheet collection:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

This JavaScript code shows you how to specify a type for a data source:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता है। आप [ChartData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड और [WorkbookType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/workbooktype/) एनेमरेशन का उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं।

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // एम्बेडेड वर्कबुक .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है।
            continue;
        }

        // यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक को समर्थन देता है।

### **बाहरी वर्कबुक बनाएं**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

This JavaScript code demonstrates the external workbook creation process:

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **बाहरी वर्कबुक सेट करें**

**`setExternalWorkbook`** मेथड का उपयोग करके आप किसी चार्ट को उसका डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

जबकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक का रिलेटिव पाथ प्रदान किया जाता है, तो यह स्वचालित रूप से पूर्ण पाथ में बदल जाता है।

This JavaScript code shows you how to set an external workbook:

```javascript
// Presentation क्लास की एक इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

`ChartData` पैरामीटर (`setExternalWorkbook` मेथड के तहत) यह निर्दिष्ट करने के लिए उपयोग किया जाता है कि Excel वर्कबुक लोड होगा या नहीं।

* जब `ChartData` मान `false` सेट किया जाता है, तो केवल वर्कबुक पाथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाएगा। आप इस सेटिंग का उपयोग तब कर सकते हैं जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।
* जब `ChartData` मान `true` सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```javascript
// Presentation क्लास की एक इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **चार्ट बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स से प्राप्त करें।
3. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।
4. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।
5. स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

This JavaScript code demonstrates the operation:

```javascript
// Presentation क्लास की एक इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // प्रेज़ेंटेशन को सहेजता है
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री में परिवर्तन करते हैं। जब बाहरी वर्कबुक लोड नहीं हो पाती, तो एक एक्सेप्शन फेंका जाता है।

This JavaScript code is an implementation of the described process:

```javascript
// Presentation क्लास की एक इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। एक चार्ट में एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी वर्कबुक का पाथ](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ समर्थित हैं, और उन्हें कैसे संग्रहीत किया जाता है?**

हां। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो यह स्वचालित रूप से एब्सोल्यूट पाथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; लेकिन ध्यान रखें कि प्रेजेंटेशन PPTX फ़ाइल में एब्सोल्यूट पाथ संग्रहीत करेगा।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—इन्हें केवल स्रोत के रूप में ही उपयोग किया जा सकता है।

**क्या Aspose.Slides प्रेजेंटेशन सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रेजेंटेशन एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) संग्रहीत करता है और इसे डेटा पढ़ने के लिए उपयोग करता है। प्रेजेंटेशन सहेजते समय बाहरी फ़ाइल स्वयं नहीं बदली जाती।

**यदि बाहरी फ़ाइल पासवर्ड-संरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता है। आम तौर पर पहले सुरक्षा हटाना या एक डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिए, [Aspose.Cells](/cells/nodejs-java/) का उपयोग करके) और उस कॉपी को लिंक करना।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फाइल की ओर इशारा करते हैं, तो उस फाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन परिलक्षित होगा।