---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/nodejs-java/chart-axis/
keywords:
- चार्ट अक्ष
- लम्बवत अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को हेरफेर करें
- अक्ष को प्रबंधित करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि प्रारूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट को Aspose.Slides for Node.js via Java के साथ उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को कस्टमाइज़ करने का तरीका जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट एक्सिस को अनुकूलित करने के तरीके को समझाता है। यह वास्तविक अक्ष मान प्राप्त करने, अक्षों के बीच डेटा बदलने, रेखा चार्ट के लिए लम्बवत या क्षैतिज अक्ष को छुपाने, श्रेणी अक्ष प्रकार बदलने, श्रेणी अक्ष मानों के लिए तिथि प्रारूप सेट करने, अक्ष शीर्षक को घुमाने, अक्ष की स्थिति सेट करने, और मान अक्ष पर यूनिट लेबल प्रदर्शित करने को दिखाता है।

## **चार्ट में लम्बवत अक्ष पर अधिकतम मान प्राप्त करना**

Aspose.Slides for Node.js via Java आपको लम्बवत अक्ष पर न्यूनतम और अधिकतम मान प्राप्त करने की अनुमति देता है। इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
1. पहली स्लाइड तक पहुंचें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. अक्ष पर वास्तविक अधिकतम मान प्राप्त करें।
1. अक्ष पर वास्तविक न्यूनतम मान प्राप्त करें।
1. अक्ष की वास्तविक प्रमुख इकाई प्राप्त करें।
1. अक्ष की वास्तविक गौण इकाई प्राप्त करें।
1. अक्ष के वास्तविक प्रमुख इकाई माप प्राप्त करें।
1. अक्ष के वास्तविक गौण इकाई माप प्राप्त करें।

यह नमूना कोड—उपर्युक्त चरणों का कार्यान्वयन—आपको जावास्क्रिप्ट में आवश्यक मान प्राप्त करने का तरीका दिखाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // प्रस्तुति को सहेजता है
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्षों के बीच डेटा का अदला‑बदला**

Aspose.Slides आपको अक्षों के बीच डेटा को तेज़ी से बदलने की सुविधा देता है—लम्बवत अक्ष (y‑axis) पर प्रदर्शित डेटा क्षैतिज अक्ष (x‑axis) पर चलता है और इसके विपरीत।

यह जावास्क्रिप्ट कोड आपको चार्ट में अक्षों के बीच डेटा अदला‑बदला कार्य कैसे करें, दिखाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // पंक्तियों और स्तंभों को बदलता है
    chart.getChartData().switchRowColumn();
    // प्रस्तुति को सहेजता है
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **रेखा चार्ट के लिए लम्बवत अक्ष को निष्क्रिय करना**

यह जावास्क्रिप्ट कोड आपको रेखा चार्ट के लिए लम्बवत अक्ष को छिपाने का तरीका दिखाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **रेखा चार्ट के लिए क्षैतिज अक्ष को निष्क्रिय करना**

यह कोड आपको रेखा चार्ट के लिए क्षैतिज अक्ष को छिपाने का तरीका दिखाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **श्रेणी अक्ष बदलना**

**CategoryAxisType** प्रॉपर्टी का उपयोग करके, आप अपनी पसंदीदा श्रेणी अक्ष प्रकार (**date** या **text**) निर्दिष्ट कर सकते हैं। जावास्क्रिप्ट में यह कोड इस ऑपरेशन को दर्शाता है:

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **श्रेणी अक्ष मान के लिए तिथि प्रारूप सेट करना**

Aspose.Slides for Node.js via Java आपको श्रेणी अक्ष मान के लिए तिथि प्रारूप सेट करने की अनुमति देता है। यह ऑपरेशन इस जावास्क्रिप्ट कोड में प्रदर्शित किया गया है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **चार्ट अक्ष शीर्षक के लिए घुमाव मान सेट करना**

Aspose.Slides for Node.js via Java आपको चार्ट अक्ष शीर्षक के लिए घुमाव मान सेट करने की अनुमति देता है। यह जावास्क्रिप्ट कोड इस ऑपरेशन को दर्शाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **श्रेणी या मान अक्ष में स्थिति अक्ष सेट करना**

Aspose.Slides for Node.js via Java आपको श्रेणी या मान अक्ष में स्थिति अक्ष सेट करने की अनुमति देता है। यह जावास्क्रिप्ट कोड कार्य कैसे करें, दिखाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चार्ट मान अक्ष पर डिस्प्ले यूनिट लेबल सक्षम करना**

Aspose.Slides for Node.js via Java आपको चार्ट को ऐसा कॉन्फ़िगर करने की अनुमति देता है कि वह अपने मान अक्ष पर यूनिट लेबल दिखाए। यह जावास्क्रिप्ट कोड इस ऑपरेशन को दर्शाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**मैं एक अक्ष को दूसरे पर जहां कटता है, उस मान को कैसे सेट करूँ (axis crossing)?**

अक्ष एक [क्रॉसिंग सेटिंग](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/axis/setcrosstype/) प्रदान करते हैं: आप शून्य पर, अधिकतम श्रेणी/मान पर, या किसी विशिष्ट संख्यात्मक मान पर क्रॉस करने का विकल्प चुन सकते हैं। यह X‑अक्ष को ऊपर या नीचे स्थानांतरित करने या बेसलाइन को उजागर करने में उपयोगी है।

**मैं टिक लेबल को अक्ष के सापेक्ष (बगल में, बाहर, अंदर) कैसे स्थित करूँ?**

[लेबल पोजीशन](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/axis/setmajortickmark/) को "cross", "outside", या "inside" पर सेट करें। यह पढ़ने की सुविधा को प्रभावित करता है और विशेष रूप से छोटे चार्टों में स्थान बचाने में मदद करता है।