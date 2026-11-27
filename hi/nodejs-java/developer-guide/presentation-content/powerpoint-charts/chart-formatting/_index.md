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
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के लिए Node.js में जावास्क्रिप्ट के माध्यम से चार्ट फ़ॉर्मेटिंग सीखें और कस्टम अक्ष, फ़ॉन्ट, संख्या स्वरूप और गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने के बारे में बताता है। यह अक्ष, ग्रिड लाइनें, शीर्षक, लीजेंड, प्लॉट क्षेत्र और वॉल फ़िल्स जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को बेहतर बनाना दर्शाता है।

यह भी दर्शाता है कि चार्ट टेक्स्ट के फ़ॉन्ट गुण कैसे सेट करें, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक प्रारूप कैसे लागू करें, और चार्ट क्षेत्र के लिए गोल कोने सक्षम कैसे करें। साथ में, ये उदाहरण दिखाते हैं कि प्रस्तुतिकरण में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को कैसे नियंत्रित करें।

उठती और गिरती अंतरालों पर अलग-अलग फ़िल और रूपरेखा के लिए, देखें [स्टॉक चार्ट उदाहरण](/slides/hi/nodejs-java/create-chart/#create-stock-charts)।

## **चार्ट इकाइयों को स्वरूपित करें**

चार्ट को फ़ॉर्मेट करने के लिए [चार्ट](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) का उपयोग करें। यह उदाहरण मार्कर और डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, फिर उसके मान और श्रेणी अक्षों पर अलग‑अलग टेक्स्ट और लाइन शैलियों को लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट्स में निर्दिष्ट हैं; श्रेणी लेबल 45 डिग्री घुमाए गए हैं।

मान अक्ष [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) का उपयोग स्रोत कोशिकाओं से स्वतंत्र रूप से करता है। इसका स्केल -2 से 15 तक है, प्रमुख अंतराल 2 और गौण अंतराल 0.5 हैं। उदाहरण प्रतिशत स्वरूपण को [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) के साथ हज़ारों पर सेट करके भी जोड़ता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार अनुकूलित करें। लीजेंड प्लॉट क्षेत्र के बाहर रहता है क्योंकि [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) को `false` के साथ बुलाया गया है। बैक‑वॉल और फ़्लोर फ़िल्स को क्रमशः [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) और [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor) के माध्यम से कॉन्फ़िगर किया जाता है, लेकिन ये सतहें केवल 3D चार्ट में ही दिखाई देती हैं।

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

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**

[Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat) के माध्यम से चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार सेट करें। उदाहरण 20‑पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और पहले सीरीज़ के लिए [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) के द्वारा मान लेबल सक्षम करता है। अपने स्वयं के स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट के डिफ़ॉल्ट को अधिलेखित कर सकते हैं।

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

## **चार्ट लीजेंड के लिए टेक्स्ट फ्रेम स्वरूपण पुनः उपयोग करें**

स्लाइड शीर्षक से मेल खाने के लिए, पहले पैरा‍ग्राफ़ पर [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से शीर्षक का फ़ॉन्ट सेट करें। लीजेंड के [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#getTextFormat) द्वारा लौटाए गए स्वरूप पर [copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyFrom) को कॉल करें। यह टेक्स्ट फ्रेम सेटिंग्स, पहले पैराग्राफ की फ़ॉर्मेटिंग और उस पैराग्राफ के डिफ़ॉल्ट फ़ॉन्ट गुणों को कॉपी करता है। व्यक्तिगत हिस्सों या बाद के पैराग्राफ़ पर सीधे लागू फ़ॉर्मेटिंग स्रोत पर बनी रहती है।

उदाहरण एक मोटे, 26‑पॉइंट Calibri शीर्षक को नेवी रंग में टेम्पलेट के रूप में उपयोग करता है। लीजेंड को स्टाइल करने के बाद, यह समान फ़ॉर्मेटिंग को एक अलग कैप्शन पर लागू करने के लिए [copyTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyTo) को कॉल करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const heading = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 20, 640, 40, false);
    const sourceTextFrame = heading.addTextFrame("Quarterly sales");
    const font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new aspose.slides.FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    font.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    font.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 32, 64, 96));

    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(java.newByte(aspose.slides.StyleType.Style3));
    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (let quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(java.newByte(aspose.slides.LegendPositionType.Bottom));
    const legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    const caption = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 460, 640, 40, false);
    const captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजी गई प्रस्तुति में, लीजेंड और कैप्शन आकार, वजन और रंग में शीर्षक से मेल खाते हैं। लीजेंड अभी भी सीरीज़ नाम दिखाता है, और कैप्शन अपना स्वयं का टेक्स्ट रखता है। यदि कैप्शन में कोई हिस्सा पहले से स्पष्ट फ़ॉन्ट आकार रखता है, तो वह आकार कॉपी किए गए पैराग्राफ़ डिफ़ॉल्ट पर प्राथमिकता लेगा।

| Before copying | After copying |
| --- | --- |
| ![त्रैमासिक बिक्री चार्ट जिसमें नियमित काले लीजेंड लेबल और काली कैप्शन है](legend-formatting-before.png) | ![एक ही चार्ट जिसमें बड़े, मोटे नेवी लीजेंड लेबल और मिलते हुए कैप्शन हैं](legend-formatting.png) |

## **संख्यात्मक स्वरूप सेट करें**

[ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) का उपयोग करके चार्ट वर्कबुक कोशिकाओं पर बिल्ट‑इन संख्या स्वरूप लागू करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक सीरीज़ मान कोशिका पर स्वरूप सूचकांक 10 (`0.00%`) लागू करता है। इससे वर्कबुक में मानों का प्रदर्शन बदलता है जबकि अंतर्निहित संख्या नहीं बदलती; उदाहरण के लिये, 0.25 को 25.00% दिखाया जाता है। अक्ष और डेटा‑लेबल स्वरूप को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

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

निम्न तालिका इंग्लिश (United States) लोकैल के लिए प्रतिनिधि Excel स्वरूपों के साथ बिल्ट‑इन संख्या स्वरूप सूचकांकों को दर्शाती है। सटीक स्वरूप स्ट्रिंग और उनका प्रदर्शन अनुप्रयोग और लोकैल के अनुसार बदल सकता है, विशेष रूप से मुद्रा और तिथि के लिए। कुछ Excel स्वरूप OOXML मानक के डिफ़ॉल्ट से भी भिन्न होते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

| सूचकांक | स्वरूप |
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

[Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) को `true` के साथ कॉल करके चार्ट क्षेत्र के कोनों को गोल करें। उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) का उपयोग करके उसकी रूपरेखा को ठोस ग्रे रंग और सिंगल‑लाइन शैली देता है, फिर प्रस्तुति सहेजता है।

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

## **मौजूदा चार्ट टिप्पणी संपादित करें**

एक चार्ट में कस्टम आकार हो सकते हैं, जैसे कि रिपोर्ट की स्थिति समझाने वाला टेक्स्ट एनोटेशन। इन आकारों तक पहुंचने के लिए [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes) का उपयोग करें। [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) द्वारा लौटाए गए संग्रह में चार्ट‑स्वामित्व वाले आकार होते हैं।

एक सामान्य टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा गया हो, वह स्लाइड से संबंधित होता है, भले ही वह चार्ट का हिस्सा दिखे। [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) के माध्यम से इटरेट करने पर चार्ट और सामान्य स्लाइड आकार मिलते हैं, लेकिन चार्ट के भीतर व्यक्तिगत आकार नहीं गिने जाते। चार्ट शीर्षक और डेटा लेबल अलग‑अलग चार्ट तत्व होते हैं, न कि इस संग्रह में कस्टम एनोटेशन।

[chart-annotations.pptx](chart-annotations.pptx) डाउनलोड करके इसे एप्लिकेशन की कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें अनग्रुप्ड एनोटेशन "Preliminary results", चार्ट‑स्वामित्व वाली रेखा, और एक सामान्य स्लाइड टेक्स्ट बॉक्स "Slide overlay" है। उदाहरण उस स्लाइड पर पहला चार्ट ढूँढता है और रिपोर्ट प्रकाशित होने पर एनोटेशन को "Final results" में बदल देता है। यह खाली संग्रह की जाँच करता है और केवल उन [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) को संपादित करता है जिनका टेक्स्ट फ़्रेम [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) द्वारा गैर‑null लौटाया गया हो और जिसकी सामग्री अपेक्षित हो।

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

रेखा और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहते हैं। इनपुट और सहेजे गए, पुनः खोलने योग्य परिणाम नीचे दिखाए गए हैं:

| Before editing | After editing |
| --- | --- |
| ![प्रारंभिक परिणाम दर्शाने वाली चार्ट टिप्पणी](chart-annotations-before.png) | ![अंतिम परिणाम दर्शाने वाली चार्ट टिप्पणी](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल शीर्ष‑स्तरीय चार्ट‑स्वामित्व वाले आकारों की जांच करता है। यदि कोई एनोटेशन किसी [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) के भीतर है, तो उस समूह की [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) संग्रह की भी जांच करें। नेस्टेड समूहों के लिए यह प्रक्रिया पुनरावर्ती रूप से दोहराएँ, उनके बाल आकारों पर समान टेक्स्ट जाँच लागू करें। एक समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में न देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/क्षेत्रों के लिए अर्द्ध‑पारदर्शी फ़िल सेट कर सकता हूँ जबकि किनारा अपारदर्शी बना रहे?**

हाँ। फ़िल पारदर्शिता और रूपरेखा को अलग‑अलग कॉन्फ़िगर किया जाता है। यह घने दृश्यावलियों में ग्रिड और डेटा की पठनीयता सुधारने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं क्या करूँ?**

फ़ॉन्ट आकार घटाएँ, गैर‑जरूरी लेबल घटकों (जैसे श्रेणियां) को निष्क्रिय करें, लेबल की स्थिति समायोजित करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या स्वरूप को “value + legend” में बदलें।

**क्या मैं श्रृंखलाओं पर ग्रेडिएंट या पैटर्न फ़िल लागू कर सकता हूँ?**

हाँ। श्रृंखलाएँ ठोस, ग्रेडिएंट और पैटर्न फ़िल का समर्थन करती हैं। व्यवहार में, ग्रेडिएंट को सीमित रूप में उपयोग करें और ऐसी संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट घटा दें।