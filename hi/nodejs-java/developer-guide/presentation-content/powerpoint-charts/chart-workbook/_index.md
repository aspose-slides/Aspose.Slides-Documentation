---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक का प्रबंधन
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
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट के माध्यम से Aspose.Slides for Node.js की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपने प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे उपयोग करें, कार्यपत्रक संग्रहों तक कैसे पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि बाहरी वर्कबुक कैसे बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित करें।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides [readWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित चार्ट डेटा वाले) पढ़ने और लिखने की अनुमति देता है। **ध्यान दें** कि चार्ट डेटा को समान क्रम में व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह JavaScript कोड एक नमूना ऑपरेशन दर्शाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को मान्य करना**

जब आप एक एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बनाए रखता है। यह असंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Chart#validateChartLayout--) को इंडेक्स-आउट-ऑफ-रेंज त्रुटि के साथ फेल कर सकती है। अपडेट की गई वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा श्रृंखलाओं और श्रेणियों को साफ़ करें।

```javascript
// वर्कबुक स्ट्रीम को संशोधित करने के बाद (उदाहरण के लिए, Aspose.Cells का उपयोग करके)
var updatedWorkbook = chartData.readWorkbookStream();

// मौजूदा डेटा रेफ़रेंसेज़ को साफ़ करें।
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई वर्कबुक के साथ संगत है, जिससे `validateChartLayout` बिना त्रुटियों के पूरा हो जाता है।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करना**

1. [Presentation](https://apireference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट श्रृंखला तक पहुँचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेजेंटेशन सहेजें।

यह JavaScript कोड दिखाता है कि वर्कबुक सेल को चार्ट डेटा लेबल के रूप में कैसे सेट करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
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

## **वर्कशीट्स का प्रबंधन**

यह JavaScript कोड दर्शाता है कि [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) मेथड का उपयोग करके वर्कशीट संग्रह तक कैसे पहुँचा जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **डेटा स्रोत प्रकार निर्दिष्ट करना**

यह JavaScript कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाना**

Aspose.Slides कुछ चार्ट में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/workbooktype/) एनेमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का समर्थन करता है।

### **बाहरी वर्कबुक बनाना**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

यह JavaScript कोड बाहरी वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream वर्कबुक बाइट्स को Node Buffer के रूप में लौटाता है।
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **बाहरी वर्कबुक सेट करना**

**`setExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को उसके डेटा स्रोत के रूप में बाहरी वर्कबुक असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को भी अपडेट करने के लिए उपयोग किया जा सकता है (यदि बाद वाला स्थानांतरित किया गया हो)।

जबकि आप रिमोट लोकेशन या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह JavaScript कोड दिखाता है कि बाहरी वर्कबुक कैसे सेट करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation क्लास का एक इंस्टेंस बनाता है
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

`setExternalWorkbook` मेथड का दूसरा पैरामीटर, `updateChartData`, यह निर्धारित करता है कि Excel वर्कबुक लोड की जाएगी या नहीं।

* जब `updateChartData` को `false` पर सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता। आप इस सेटिंग का उपयोग तब करना चाहेंगे जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।  
* जब `updateChartData` को `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation क्लास का एक इंस्टेंस बनाता है
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

### **चार्ट बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करना**

1. [Presentation](https://apireference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
1. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को प्रतिनिधित्व करता है।  
1. संबंधित शर्त निर्दिष्ट करें जो यह दर्शाती है कि स्रोत प्रकार बाहरी वर्कबुक डेटा स्रोत प्रकार के समान है।

यह JavaScript कोड ऑपरेशन को दर्शाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation क्लास का एक इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // प्रस्तुति को सहेजता है
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **चार्ट डेटा संपादित करना**

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री में परिवर्तन करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

यह JavaScript कोड वर्णित प्रक्रिया को लागू करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation क्लास का एक इंस्टेंस बनाता है
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

### **चार्ट कैश से वर्कबुक को पुनर्स्थापित करना**

यदि कोई चार्ट किसी बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रेजेंटेशन में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः बनाता है। [LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) बनाएं, इसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `true` के साथ [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को कॉल करें।

नीचे दिया गया JavaScript उदाहरण एक ऐसी प्रेजेंटेशन खोलता है जिसकी चार्ट एक अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है और पुनः प्राप्त डेटा को [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकेगा। केवल तब पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बदलाव शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**  
हाँ। एक चार्ट के पास [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी वर्कबुक पथ](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं ताकि यह सुनिश्चित हो सके कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  
हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है।

**क्या मैं नेटवर्क संसाधनों/शेयर्स पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**  
हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रस्तुति एक [बाहरी फ़ाइल लिंक](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति सहेजते समय बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड से सुरक्षित है तो क्या करें?**  
Aspose.Slides लिंक बनाते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका है पहले सुरक्षा हटाना या एक डिक्रिप्टेड कॉपी तैयार करना (उदाहरण के लिए, [Aspose.Cells](/cells/nodejs-java/) का उपयोग करके) और उस कॉपी को लिंक करना।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**  
हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन प्रतिबिंबित होंगे।