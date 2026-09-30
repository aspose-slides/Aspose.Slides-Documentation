---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में चार्ट लेजेंड को अनुकूलित करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/nodejs-java/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके चार्ट लेजेंड को अनुकूलित करें, ताकि कस्टम लेजेंड फ़ॉर्मेटिंग के साथ PowerPoint प्रस्तुतियों को बेहतर बनाया जा सके।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java PowerPoint प्रस्तुतियों में चार्ट लीजेंड को अनुकूलित करने के विकल्प प्रदान करता है। इस लेख में दिखाया गया है कि कैसे लीजेंड की स्थिति और आकार निर्धारित किया जाए, पूरे लीजेंड के फ़ॉन्ट आकार को सेट किया जाए, व्यक्तिगत लीजेंड प्रविष्टि को स्वरूपित किया जाए, और चयनित प्रविष्टियों को छुपाया या पुनर्स्थापित किया जाए।

FAQ संबंधित व्यवहारों को कवर करती है, जिसमें लीजेंड के लिए स्थान आरक्षित करना, मल्टीलाइन लेबल प्रदर्शित करना, और प्रस्तुति थीम से स्वरूपण का उत्तराधिकार प्राप्त करना शामिल है।

## **लीजेंड की स्थिति निर्धारण**

लीजेंड के [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), और [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) मेथड का उपयोग करके उसकी स्थिति और आकार को चार्ट के आयामों के अंश के रूप में निर्दिष्ट किया जाता है।

यह उदाहरण एक प्रस्तुति बनाता है और पहले स्लाइड में डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ता है। वांछित लीजेंड ऑफ़सेट और आयामों को चार्ट की चौड़ाई और ऊँचाई से विभाजित करने पर वे सापेक्ष मान बन जाते हैं: लीजेंड चार्ट के टॉप-लेफ़्ट कोने से 50 पॉइंट की दूरी पर स्थित है और 100 × 100 पॉइंट आकार का है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // चार्ट के सापेक्ष लेजेंड की स्थिति और आकार को व्यक्त करें।
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लीजेंड का फ़ॉन्ट आकार निर्धारित करें**

लीजेंड के [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) का उपयोग करके उसके टेक्स्ट फ़ॉर्मेटिंग तक पहुँचें और [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) द्वारा फ़ॉन्ट आकार को पॉइंट में सेट करें।

यह उदाहरण एक चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा है और लीजेंड टेक्स्ट को 20 पॉइंट पर सेट करता है। यह ऊर्ध्वाधर अक्ष के लिए स्वचालित सीमा को भी निष्क्रिय करता है और उसकी रेंज को -5 से 10 तक निर्धारित करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **व्यक्तिगत लीजेंड प्रविष्टि का फ़ॉन्ट आकार निर्धारित करें**

लीजेंड के [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) मेथड द्वारा लौटाए गए संग्रह का उपयोग करके आप किसी विशिष्ट प्रविष्टि के स्वरूपण तक पहुँच सकते हैं। प्रविष्टि इंडेक्स शून्य‑आधारित होते हैं, इसलिए इंडेक्स `1` दूसरी प्रविष्टि को दर्शाता है।

यह उदाहरण कम से कम दो श्रृंखलाएँ शामिल करने वाले डिफ़ॉल्ट डेटा वाले एक क्लस्टर्ड कॉलम चार्ट को बनाता है। यह दूसरी लीजेंड प्रविष्टि को बोल्ड, इटैलिक और 20‑पॉइंट नीले रंग के टेक्स्ट के साथ स्वरूपित करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **व्यक्तिगत लीजेंड प्रविष्टियों को छुपाएँ**

एक सहायक श्रृंखला को लीजेंड से हटाने के लिए जबकि उसका डेटा दृश्य रहे, [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) को `true` के साथ कॉल करें, यह [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/) के माध्यम से किया जाता है। यह केवल चयनित लीजेंड प्रविष्टि को छुपाता है; श्रृंखला या उसके डेटा बिंदुओं को हटाता नहीं है। इसके विपरीत, [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) को `false` करने से पूरे लीजेंड को छुपाया जाता है।

नीचे का उदाहरण डिफ़ॉल्ट डेटा के साथ कई श्रृंखलाओं वाले एक क्लस्टर्ड कॉलम चार्ट को बनाता है। यह दूसरी श्रृंखला की लीजेंड प्रविष्टि (इंडेक्स `1`) को छुपाता है और प्रस्तुति को सहेजता है। फिर [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) को `false` करके प्रविष्टि को पुनः स्थापित करता है और दूसरी प्रति सहेजता है। दोनों फ़ाइलों में कॉलम दिखाई देते रहेंगी।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // चार्ट डेटा को बदले बिना उसी प्रविष्टि को पुनर्स्थापित करें।
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे की तुलना में वही चार्ट दिखाया गया है, जहाँ सभी प्रविष्टियाँ दिखाई दे रही हैं और दूसरी प्रविष्टि छुपी हुई है। दूसरी श्रृंखला के कॉलम अपरिवर्तित रहते हैं।

![सभी लीजेंड प्रविष्टियों के दृश्य और दूसरी प्रविष्टि के लीजेंड से छिपे होने वाले चार्ट की तुलना; सभी कॉलम दृश्य रहते हैं।](hide-legend-entry.png)

कॉलम, बार, और लाइन चार्ट में, लीजेंड प्रविष्टियाँ श्रृंखलाओं की पहचान करती हैं। पाई चार्ट में, वे व्यक्तिगत डेटा बिंदुओं (सेक्शन) की पहचान करती हैं, इसलिए चयनित सेक्शन पर [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) का उपयोग करें। API इस डेटा‑पॉइंट मेथड को `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, और `BarOfPie` चार्ट प्रकारों के लिए दस्तावेज़ करती है। इसे डोनट चार्ट पर लागू न मानें, क्योंकि वे इस सूची में नहीं हैं।

## **FAQ**

**क्या मैं लीजेंड के लिए ओवरले करने के बजाय उसे जगह आरक्षित कर सकता हूँ?**

हाँ। लीजेंड को प्लॉट एरिया के ऊपर ओवरले करने के बजाय स्थान आरक्षित करने के लिए [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) को `false` के साथ कॉल करें।

**क्या मैं मल्टीलाइन लीजेंड लेबल बना सकता हूँ?**

हाँ। जब उपलब्ध चौड़ाई अपर्याप्त हो तो लंबे लेबल रैप हो सकते हैं। आप श्रृंखला नामों में नई पंक्ति (`\n`) डालकर लाइन ब्रेक भी बना सकते हैं।

**मैं लीजेंड को प्रस्तुति थीम के रंग योजना के साथ कैसे मिलाऊँ?**

लीजेंड के रंग, फ़िल और फ़ॉन्ट को अनसेट रखें ताकि वह थीम फ़ॉर्मेटिंग को विरासत में ले सके। स्पष्ट स्वरूपण थीम की संबंधित सेटिंग्स को ओवरराइड कर देता है।