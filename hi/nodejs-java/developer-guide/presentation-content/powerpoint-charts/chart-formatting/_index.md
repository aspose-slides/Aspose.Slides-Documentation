---
title: जावास्क्रिप्ट में प्रस्तुति चार्ट को फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/nodejs-java/chart-formatting/
keywords:
- चार्ट फ़ॉर्मेट
- चार्ट फ़ॉर्मेटिंग
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides के लिए Node.js में जावा के माध्यम से चार्ट फ़ॉर्मेटिंग सीखें और कस्टम अक्ष, फ़ॉन्ट, संख्या स्वरूप और गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने के बारे में बताता है। यह अक्ष, ग्रिड रेखाएँ, शीर्षक, लीजेंड, प्लॉट एरिया और वॉल भराव जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को कैसे बेहतर बनाया जाए, यह दर्शाता है।

यह यह भी दिखाता है कि चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण कैसे सेट करें, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक स्वरूप कैसे लागू करें, और चार्ट एरिया के किनारों को गोल कैसे बनाएं। ये उदाहरण मिलकर प्रस्तुति में चार्ट के दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने के तरीके दिखाते हैं।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**

[चार्ट](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) का उपयोग करके चार्ट शीर्षक, अक्ष, ग्रिड रेखाएँ, लीजेंड और प्लॉट एरिया को फ़ॉर्मेट करें। यह उदाहरण मार्कर और डिफ़ॉल्ट डेटा वाला एक लाइन चार्ट बनाता है, फिर उसके मान और श्रेणी अक्षों पर अलग‑अलग टेक्स्ट और लाइन शैलियाँ लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट में निर्दिष्ट की गई है; श्रेणी लेबल 45 डिग्री घुमाए गए हैं।

मान अक्ष [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) को स्रोत कोशिकाओं से स्वतंत्र रूप से उपयोग करता है। इसका स्केल -2 से 15 तक है, प्रमुख अंतराल 2 और गौण अंतराल 0.5 है। यह उदाहरण प्रतिशत स्वरूप को [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) के साथ हजारों पर सेट करके भी जोड़ता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार अनुकूलित करें। लीजेंड प्लॉट एरिया के बाहर रहता है क्योंकि [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) को `false` किया गया है। बैक‑वॉल और फ़्लोर भराव को [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) और [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor) के माध्यम से कॉन्फ़िगर किया जाता है, पर ये सतहें केवल 3D चार्ट में ही दिखाई देती हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    let chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    chartTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15);
    chart.getAxes().getVerticalAxis().setMinValue(-2);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);

    let valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkGreen));
    valueAxisText.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    let valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    let categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    categoryAxisText.setLatinFont(new aspose.slides.FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    let categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    let legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    legendText.setFontHeight(16);
    legendText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    legendText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    legendText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkRed));

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.LightCyan));

    presentation.save("FormattedChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एक चार्ट के लिए फ़ॉन्ट गुण सेट करें**

[Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat) के माध्यम से चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार सेट करें। यह उदाहरण 20‑पॉइंट फ़ॉन्ट वाले एक क्लस्टर्ड कॉलम चार्ट बनाता है और पहले सीरीज़ के लिए [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) द्वारा मान लेबल सक्षम करता है। अपने स्वयं के स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट के डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **संख्यात्मक स्वरूप सेट करें**

[ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) का उपयोग करके चार्ट वर्कबुक कोशिकाओं पर निर्मित संख्या स्वरूप लागू करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा वाला एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक सीरीज़ मान कोशिका पर स्वरूप सूचकांक 10 (`0.00%`) लागू करता है। यह वर्कबुक में मानों के प्रदर्शित रूप को बदलता है बिना मूल संख्याओं को बदले; उदाहरण के लिए, 0.25 को 25.00% के रूप में दिखाया जाएगा। अक्ष और डेटा‑लेबल स्वरूप को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    let series = chart.getChartData().getSeries();

    for (let i = 0; i < series.size(); i++) {
        let chartSeries = series.get_Item(i);
        for (let j = 0; j < chartSeries.getDataPoints().size(); j++) {
            let dataPoint = chartSeries.getDataPoints().get_Item(j);
            dataPoint.getValue().getAsCell().setPresetNumberFormat(java.newByte(10)); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे तालिका में अंग्रेज़ी (संयुक्त राज्य) लोकेल के प्रतिनिधि Excel स्वरूपों के साथ निर्मित संख्या स्वरूप सूचकांक सूचीबद्ध हैं। सटीक स्वरूप स्ट्रिंग्स और उनका प्रदर्शन अनुप्रयोग और लोकेल के अनुसार बदल सकता है, विशेषकर मुद्रा और तिथि के लिए। कुछ Excel स्वरूप OOXML मानक के डिफ़ॉल्ट से भी अलग होते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **चार्ट क्षेत्र के गोल किनारे सेट करें**

[Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) को `true` के साथ कॉल करके चार्ट क्षेत्र के किनारों को गोल करें। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और उसके रूपरेखा को ठोस ग्रे रंग तथा सिंगल‑लाइन शैली देने के लिए [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) का उपयोग करता है, फिर प्रस्तुति को सहेजता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chart.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मौजूदा चार्ट एनोटेशन संपादित करें**

एक चार्ट में कस्टम आकार, जैसे रिपोर्ट की स्थिति बताने वाला टेक्स्ट एनोटेशन, हो सकता है। इन आकारों तक पहुंचने के लिए [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes) का प्रयोग करें। [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) द्वारा लौटाई गई संग्रह में चार्ट‑स्वामित्व वाले आकार शामिल होते हैं।

एक साधारण टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा गया है वह स्लाइड का हिस्सा रहता है, भले ही वह चार्ट का हिस्सा जैसा दिखे। [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) के माध्यम से इटरिट करने से चार्ट और साधारण स्लाइड आकार मिलते हैं, पर चार्ट के भीतर व्यक्तिगत आकारों की सूची नहीं बनती। चार्ट शीर्षक और डेटा लेबल अलग‑अलग चार्ट तत्व हैं, न कि इस संग्रह में कस्टम एनोटेशन।

[chart-annotations.pptx](chart-annotations.pptx) डाउनलोड करें और उसे एप्लिकेशन की कार्यशील निर्देशिका में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें अनग्रुप्ड एनोटेशन "Preliminary results", एक चार्ट‑स्वामित्व वाली रेखा और एक साधारण स्लाइड टेक्स्ट बॉक्स "Slide overlay" है। उदाहरण पहले चार्ट को ढूँढता है और रिपोर्ट प्रकाशित होने पर एनोटेशन को "Final results" में बदल देता है। यह खाली संग्रह की जाँच करता है और केवल उस [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) को संपादित करता है जिसका टेक्स्ट फ्रेम [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) द्वारा गैर‑null लौटाया गया हो और अपेक्षित टेक्स्ट हो।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("chart-annotations.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = null;
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
            chart = shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        console.log("No chart or chart-owned shapes found.");
    } else {
        let updated = false;
        for (let i = 0; i < chart.getUserShapes().getShapes().size(); i++) {
            let shape = chart.getUserShapes().getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let annotation = shape;
                if (annotation.getTextFrame() != null && annotation.getTextFrame().getText() === "Preliminary results") {
                    annotation.getTextFrame().setText("Final results");
                    updated = true;
                    break;
                }
            }
        }

        if (updated) {
            presentation.save("chart-annotations-updated.pptx", aspose.slides.SaveFormat.Pptx);
        } else {
            console.log("No matching text annotation found.");
        }
    }
} finally {
    presentation.dispose();
}
```

रेखा और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहते हैं। नीचे की छवियों में इनपुट और सहेजा गया, पुनः खोला गया परिणाम दिखाया गया है:

| Editing से पहले | Editing के बाद |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल शीर्ष‑स्तर के चार्ट‑स्वामित्व वाले आकारों की जाँच करता है। यदि कोई एनोटेशन किसी [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) के भीतर है, तो उस समूह के [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) संग्रह को भी जाँचें। नेस्टेड समूहों के लिए इसे पुनरावृत्त रूप से करें, और उनके चाइल्ड आकारों पर समान टेक्स्ट जाँच लागू करें। समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स मानकर नहीं चलें।
{{% /alert %}}

## **FAQ**

**क्या मैं कॉलम/एरिया के लिए अर्द्ध‑पारदर्शी भराव सेट कर सकता हूँ जबकि सीमा को अपारदर्शी रखूँ?**

हां। भराव की पारदर्शिता और रूपरेखा को अलग‑अलग कॉन्फ़िगर किया जाता है। यह ग्रिड और घनी विज़ुअलाइज़ेशन में डेटा की पठनीयता सुधारने में सहायक है।

**डेटा लेबल ओवरलैप होने पर मैं क्या करूँ?**

फ़ॉन्ट आकार घटाएँ, गैर‑आवश्यक लेबल घटकों को अक्षम करें (जैसे श्रेणियों को), लेबल की स्थिति समायोजित करें, आवश्यकता पड़ने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या स्वरूप को "value + legend" में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न भराव लागू कर सकता हूँ?**

हां। सीरीज़ ठोस, ग्रेडिएंट और पैटर्न भराव का समर्थन करती हैं। वास्तविक उपयोग में ग्रेडिएंट का सीमित उपयोग करें और ऐसे संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट घटा दें।