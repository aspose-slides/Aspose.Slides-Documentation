---
title: जावा में प्रस्तुति चार्ट फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/java/chart-formatting/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में चार्ट फ़ॉर्मेटिंग सीखें और कस्टम अक्ष, फ़ॉन्ट, संख्या फ़ॉर्मेट और गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मैट करने का तरीका समझाता है। यह अक्ष, ग्रिड रेखाएँ, शीर्षक, लीजेंड, प्लॉट एरिया और वॉल फ़िल्स जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को सुधारने का प्रदर्शन करता है।

यह चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक स्वरूप लागू करने, और चार्ट एरिया के लिए गोल कोने सक्षम करने का भी प्रदर्शन करता है। साथ में, ये उदाहरण प्रस्तुतियों में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने का तरीका दिखाते हैं।

उच्च और निम्न अंतराल पर अलग फ़िल्स और आउटलाइन के लिए, देखें [स्टॉक चार्ट उदाहरण](/slides/hi/java/create-chart/#create-stock-charts)।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**

चार्ट शीर्षक, अक्ष, ग्रिड रेखाएँ, लीजेंड और प्लॉट एरिया को फ़ॉर्मेट करने के लिए [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) का उपयोग करें। यह उदाहरण मार्करों और डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, फिर उसके वैल्यू और श्रेणी अक्षों पर अलग‑अलग टेक्स्ट और लाइन स्टाइल लागू करता है। फ़ॉन्ट आकार और लाइन की चौड़ाई पॉइंट में निर्दिष्ट की गई हैं; श्रेणी लेबल 45 डिग्री घुमा हुआ है।

वैल्यू अक्ष स्रोत कोशिकाओं से स्वतंत्र रूप से [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) का उपयोग करता है। इसका स्केल -2 से 15 तक है, मुख्य अंतराल 2 और गौण अंतराल 0.5 है। उदाहरण प्रतिशत फ़ॉर्मेटिंग को [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) को हजारों पर सेट करके भी जोड़ता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार अनुकूलित करें। लीजेंड प्लॉट एरिया के बाहर रहता है क्योंकि [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) को `false` के साथ बुलाया गया है। बैक‑वॉल और फ्लोर फ़िल्स को [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) और [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) के माध्यम से कॉन्फ़िगर किया जाता है, लेकिन ये सतहें केवल 3D चार्ट में ही दृश्यमान होती हैं।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट के लिए फ़ॉन्ट गुण सेट करना**

चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार को [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--) के माध्यम से सेट करें। यह उदाहरण 20‑पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और पहले श्रृंखला के लिए [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) के द्वारा वैल्यू लेबल सक्षम करता है। अपने स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट के डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट लीजेंड के लिए टेक्स्ट फ्रेम फ़ॉर्मेटिंग का पुनः उपयोग**

लीजेंड को स्लाइड शीर्षक से मिलाने के लिए, पहले पैराग्राफ पर [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) का उपयोग करके शीर्षक का फ़ॉन्ट सेट करें। लीजेंड के [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) द्वारा लौटाए गए फ़ॉर्मेट पर [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) को कॉल करें। यह टेक्स्ट फ्रेम सेटिंग्स, पहले पैराग्राफ का फ़ॉर्मेट और उस पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट प्रॉपर्टीज़ को कॉपी करता है। व्यक्तिगत भागों या बाद के पैराग्राफ़ों पर सीधे लागू फ़ॉर्मेटिंग स्रोत तक ही सीमित रहती है।

उदाहरण में नेवी रंग में एक बोल्ड, 26‑पॉइंट Calibri शीर्षक टेम्पलेट के रूप में उपयोग किया गया है। लीजेंड को स्टाइल करने के बाद, यह [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) को कॉल करके समान फ़ॉर्मेटिंग को एक अलग कैप्शन पर लागू करता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजे गए प्रेजेंटेशन में, लीजेंड और कैप्शन आकार, वजन और रंग में शीर्षक से मेल खाते हैं। लीजेंड अभी भी श्रृंखला नाम दिखाता है, और कैप्शन अपना स्वयं का टेक्स्ट रखता है। यदि कैप्शन में कोई भाग पहले से स्पष्ट फ़ॉन्ट आकार रखता है, तो वह आकार कॉपी किए गए पैराग्राफ़ डिफ़ॉल्ट पर प्राथमिकता लेगा।

| कॉपी करने से पहले | कॉपी करने के बाद |
| --- | --- |
| ![त्रैमासिक बिक्री चार्ट जिसमें सामान्य काली लीजेंड लेबल और काली कैप्शन है](legend-formatting-before.png) | ![वही चार्ट जिसमें बड़े, बोल्ड नेवी लीजेंड लेबल और मिलते हुए कैप्शन हैं](legend-formatting.png) |

## **संख्यात्मक स्वरूप सेट करना**

एकीकृत नंबर फ़ॉर्मेट को चार्ट वर्कबुक कोशिकाओं पर लागू करने के लिए [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक श्रृंखला वैल्यू सेल पर फ़ॉर्मेट इंडेक्स 10 (`0.00%`) लागू करता है। यह वर्कबुक में मानों को बदले बिना मानों के प्रदर्शित होने के तरीके को बदलता है; उदाहरण के लिए, 0.25 को 25.00% दिखाया जाता है। अक्ष और डेटा‑लेबल फ़ॉर्मेट को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

निम्न तालिका में बिल्ट‑इन नंबर फ़ॉर्मेट इंडिसेज़ को अंग्रेज़ी (संयुक्त राज्य) लोकैल के प्रतिनिधि एक्सेल फ़ॉर्मेट्स के साथ सूचीबद्ध किया गया है। सटीक फ़ॉर्मेट स्ट्रिंग्स और उनका प्रदर्शन अनुप्रयोग और लोकैल के अनुसार बदल सकता है, विशेषकर मुद्रा और तिथियों के लिए। कुछ एक्सेल फ़ॉर्मेट्स OOXML मानक के डिफ़ॉल्ट्स से भी अलग होते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

| सूचकांक | फ़ॉर्मेट |
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

## **चार्ट एरिया के गोल कोने सेट करना**

[IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) को `true` के साथ कॉल करके चार्ट एरिया के कोनों को गोल बनाएं। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और सहेजने से पहले [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) का उपयोग करके उसकी रूपरेखा को ठोस ग्रे रंग और सिंगल‑लाइन स्टाइल देता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मौजूदा चार्ट टिप्पणी संपादित करें**

एक चार्ट कस्टम शॅप्स रख सकता है, जैसे रिपोर्ट की स्थिति समझाने वाली टेक्स्ट टिप्पणी। इन शॅप्स तक पहुंचने के लिए [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--) का उपयोग करें, जो चार्ट API रेफ़ेरेन्स में [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) के तहत भी सूचीबद्ध है। [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) द्वारा लौटाई गई कलेक्शन में चार्ट‑स्वामित्व वाले शॅप्स होते हैं।

एक सामान्य टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा गया है वह स्लाइड का हिस्सा रहता है, भले ही वह चार्ट का हिस्सा जैसा दिखे। [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) के माध्यम से इटरटेट करने से चार्ट और सामान्य स्लाइड शॅप्स मिलते हैं, लेकिन चार्ट के अंदर के व्यक्तिगत शॅप्स नहीं मिलते। चार्ट शीर्षक और डेटा लेबल अलग-अलग चार्ट तत्व हैं, न कि इस कलेक्शन में कस्टम टिप्पणी।

[chart-annotations.pptx](chart-annotations.pptx) डाउनलोड करें और इसे एप्लिकेशन की वर्किंग डायरेक्टरी में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें अनग्रुप्ड टिप्पणी "Preliminary results" पढ़ी जाती है, एक चार्ट‑स्वामित्व वाली लाइन, और एक सामान्य स्लाइड टेक्स्ट बॉक्स "Slide overlay" पढ़ता है। उदाहरण उस स्लाइड पर पहला चार्ट ढूंढता है और रिपोर्ट तैयार होने पर टिप्पणी को "Final results" में बदल देता है। यह खाली कलेक्शन की जाँच करता है और केवल एक [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) को संपादित करता है जिसका नॉन‑नल टेक्स्ट फ्रेम [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) द्वारा वापस किया गया हो और अपेक्षित टेक्स्ट हो।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

लाइन और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहता है। निम्न छवियाँ इनपुट और सहेजे गए, पुनः खोलے परिणाम को दिखाती हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![चार्ट टिप्पणी जिसमें लिखा है Preliminary results](chart-annotations-before.png) | ![चार्ट टिप्पणी जिसमें लिखा है Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल टॉप‑लेवल चार्ट‑स्वामित्व वाले शॅप्स को जांचता है। यदि कोई टिप्पणी [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/) के भीतर है, तो उस समूह की [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) कलेक्शन को भी जांचें। घोंसलेदार समूहों के लिए इसे पुनरावर्ती रूप से दोहराएँ, उनके चाइल्ड शॅप्स पर समान टेक्स्ट जाँच लागू करें। एक समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स न समझें।
{{% /alert %}}

## **FAQ**

**क्या मैं कॉलम/एरिया के लिए अर्द्ध‑पारदर्शी फ़िल्स सेट कर सकता हूँ जबकि बॉर्डर को अपारदर्शी रख सकता हूँ?**

हाँ। फ़िल की पारदर्शिता और आउटलाइन अलग‑अलग कॉन्फ़िगर की जाती हैं। यह घनी विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता सुधारने के लिए उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं कैसे निपटूँ?**

फ़ॉन्ट आकार घटाएँ, गैर‑आवश्यक लेबल घटकों (उदाहरण के लिए, श्रेणियाँ) को अक्षम करें, लेबल की स्थिति समायोजित करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या फ़ॉर्मेट को "value + legend" में बदलें।

**क्या मैं श्रृंखला पर ग्रेडिएंट या पैटर्न फ़िल्स लागू कर सकता हूँ?**

हाँ। श्रृंखला ठोस, ग्रेडिएंट और पैटर्न फ़िल्स का समर्थन करती है। व्यावहारिक रूप से, ग्रेडिएंट का सीमित उपयोग करें और ऐसे संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट को कम कर दें।