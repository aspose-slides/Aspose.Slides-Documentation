---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट कार्यपुस्तिकाओं का प्रबंधन
linktitle: चार्ट कार्यपुस्तिका
type: docs
weight: 70
url: /hi/nodejs-java/chart-workbook/
keywords:
- चार्ट कार्यपुस्तिका
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी कार्यपुस्तिका
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Java के माध्यम से Node.js के लिए Aspose.Slides की खोज करें: PowerPoint और OpenDocument स्वरूपों में चार्ट कार्यपुस्तिकाओं का सहजता से प्रबंधन करें और अपने प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट कार्यपुस्तिकाओं के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि कार्यपुस्तिका स्ट्रीम के माध्यम से chart डेटा को कैसे पढ़ें और लिखें, कार्यपुस्तिका कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करें, worksheet संग्रह तक पहुंचें, और चार्ट मूल्यों के लिए डेटा स्रोत प्रकार कैसे निर्दिष्ट करें।

यह बाहरी कार्यपुस्तिकाओं को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी कार्यपुस्तिका बनाएं और उसे असाइन करें, चार्ट से जुड़े बाहरी कार्यपुस्तिका का पथ प्राप्त करें, और जब कार्यपुस्तिका उपलब्ध हो तो चार्ट डेटा को संपादित करें।

जो कार्यपुस्तिका कोशिकाएँ लापता डेटा का प्रतिनिधित्व करती हैं, उनके लिए देखें [Control the Display of Empty Cells](/slides/hi/nodejs-java/chart-series/) ताकि खाली कोशिका और शून्य के बीच अंतर एवं उपलब्ध डिस्प्ले मोड की लाइन-चार्ट तुलना को समझा जा सके।

## **कार्यपुस्तिका से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides [readWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) मेथड प्रदान करता है जो आपको चार्ट डेटा कार्यपुस्तिकाएँ (Aspose.Cells के साथ संपादित चार्ट डेटा वाली) पढ़ने और लिखने की अनुमति देती हैं। **ध्यान दें** कि चार्ट डेटा को उसी तरह व्यवस्थित किया जाना चाहिए या उसकी संरचना स्रोत के समान होनी चाहिए।

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

### **कार्यपुस्तिका संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप एक एम्बेडेड कार्यपुस्तिका को संशोधित कार्यपुस्तिका से बदलते हैं, तो चार्ट अपनी मूल series और category संग्रह को बरकरार रखता है। यह असंगति [Chart.validateChartLayout](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Chart#validateChartLayout--) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड कार्यपुस्तिका को फिर से चार्ट में लिखने से पहले मौजूदा series और categories को साफ़ करें।

```javascript
// वर्कबुक स्ट्रीम को संशोधित करने के बाद (उदा., Aspose.Cells का उपयोग करके)
var updatedWorkbook = chartData.readWorkbookStream();

// मौजूदा डेटा संदर्भ साफ़ करें।
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई कार्यपुस्तिका के साथ संगत है, जिससे `validateChartLayout` बिना त्रुटियों के पूर्ण हो सकता है।

## **वर्कबुक सेल को चार्ट DataLabel के रूप में सेट करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट series तक पहुंचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेजेंटेशन सहेजें।

यह JavaScript कोड दिखाता है कि कैसे वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट किया जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टैंसिएट करता है
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

## **Worksheets प्रबंधित करें**

यह JavaScript कोड एक ऑपरेशन दर्शाता है जहाँ [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) मेथड का उपयोग करके worksheet संग्रह तक पहुंचा जाता है:

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

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह JavaScript कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाए:

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

## **असमर्थित एम्बेडेड कार्यपुस्तिका फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी कार्यपुस्तिका (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप [ChartData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/workbooktype/) एन्न्यूमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं।

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

## **बाहरी कार्यपुस्तिका**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी कार्यपुस्तिकाओं का समर्थन करता है।

### **बाहरी कार्यपुस्तिका बनाएं**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड का उपयोग करके आप या तो नई बाहरी कार्यपुस्तिका बना सकते हैं या किसी आंतरिक कार्यपुस्तिका को बाहरी बना सकते हैं।

यह JavaScript कोड बाहरी कार्यपुस्तिका निर्माण प्रक्रिया को दर्शाता है:

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

### **बाहरी कार्यपुस्तिका सेट करें**

**`setExternalWorkbook`** मेथड का उपयोग करके आप किसी चार्ट को उसकी डेटा स्रोत के रूप में एक बाहरी कार्यपुस्तिका असाइन कर सकते हैं। इस मेथड का उपयोग बाहरी कार्यपुस्तिका के पथ को अपडेट करने के लिए भी किया जा सकता है (यदि वह स्थानांतरित कर दी गई है)।

जबकि आप रिमोट लोकेशन या संसाधन में संग्रहीत कार्यपुस्तिकाओं के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे कार्यपुस्तिकाओं को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी कार्यपुस्तिका के लिए सापेक्ष पथ प्रदान किया जाता है, तो उसे स्वतः पूर्ण पथ में बदल दिया जाता है।

यह JavaScript कोड दिखाता है कि बाहरी कार्यपुस्तिका कैसे सेट की जाए:

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

`setExternalWorkbook` मेथड का दूसरा पैरामीटर, `updateChartData`, यह निर्दिष्ट करता है कि Excel कार्यपुस्तिका लोड होगी या नहीं।

* जब `updateChartData` को `false` पर सेट किया जाता है, तो केवल कार्यपुस्तिका पथ अपडेट होता है—चार्ट डेटा लक्ष्य कार्यपुस्तिका से लोड या अपडेट नहीं किया जाता। यह सेटिंग तब उपयोगी होती है जब लक्ष्य कार्यपुस्तिका मौजूद नहीं है या उपलब्ध नहीं है।  
* जब `updateChartData` को `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य कार्यपुस्तिका से अपडेट हो जाता है।

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

### **चार्ट बाहरी डेटा स्रोत कार्यपुस्तिका पथ प्राप्त करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
1. इंडेक्स के आधार पर स्लाइड का संदर्भ प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
1. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।  
1. बाहरी कार्यपुस्तिका डेटा स्रोत प्रकार के समान स्रोत प्रकार के आधार पर संबंधित शर्त निर्दिष्ट करें।

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

### **चार्ट डेटा संपादित करें**

आप बाहरी कार्यपुस्तिकाओं में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक कार्यपुस्तिकाओं की सामग्री को बदलते हैं। जब कोई बाहरी कार्यपुस्तिका लोड नहीं की जा सकती, तो एक अपवाद फेंका जाता है।

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

### **चार्ट कैश से कार्यपुस्तिका पुनः प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी कार्यपुस्तिका का उपयोग करता है जो अनुपलब्ध या लापता है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट कार्यपुस्तिका को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) बनाएं, उसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `true` के साथ [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को कॉल करें।

निम्नलिखित JavaScript उदाहरण एक ऐसी प्रस्तुति खोलता है जिसका चार्ट अनुपलब्ध बाहरी कार्यपुस्तिका को संदर्भित करता है और [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से पुनः प्राप्त डेटा तक पहुँचता है:

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

यदि बाहरी कार्यपुस्तिका उपलब्ध नहीं है और पुनर्प्राप्ति निष्क्रिय है, तो Aspose.Slides एक अपवाद फेंकेगा। केवल तब पुनर्प्राप्ति सक्षम करें जब कैश किए गए चार्ट डेटा को वैकल्पिक फ़ॉलबैक के रूप में स्वीकार्य हो, क्योंकि कैश में बाहरी कार्यपुस्तिका में अंतिम प्रस्तुति अपडेट के बाद किए गए परिवर्तन नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड कार्यपुस्तिका से जुड़ा है?**

हाँ। एक चार्ट में [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी कार्यपुस्तिका का पथ](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत बाहरी कार्यपुस्तिका है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी कार्यपुस्तिकाओं के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालाँकि, ध्यान रखें कि प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित कार्यपुस्तिकाओं का उपयोग कर सकता हूँ?**

हाँ, ऐसे कार्यपुस्तिकाओं को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालाँकि, Aspose.Slides से सीधे रिमोट कार्यपुस्तिकाओं को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रस्तुति एक [बाहरी फ़ाइल के लिंक](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) को संग्रहीत करती है और डेटा पढ़ने के लिए उसका उपयोग करती है। प्रस्तुति सहेजते समय बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका यह है कि पहले संरक्षण हटाया जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](/cells/nodejs-java/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी कार्यपुस्तिका को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपनी लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल को दर्शाते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड करने पर प्रत्येक चार्ट में परिवर्तन प्रतिबिंबित होंगे।