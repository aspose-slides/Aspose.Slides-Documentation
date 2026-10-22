---
title: Java में प्रस्तुति चार्ट्स को फ़ॉर्मेट करें
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
description: "Aspose.Slides for Java में चार्ट फ़ॉर्मेटिंग सीखें और कस्टम अक्ष, फ़ॉन्ट, संख्या फ़ॉर्मेट, तथा गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने के तरीके को समझाता है। यह अक्ष, ग्रिड लाइनों, शीर्षक, लीज़ेंड, प्लॉट एरिया और वॉल फ़िल्स जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की दिखावट और पठनीयता को बेहतर बनाने का प्रदर्शन करता है।

यह चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक फ़ॉर्मेट लागू करने और चार्ट एरिया के लिए गोल कोने सक्षम करने को भी दर्शाता है। साथ मिलकर, ये उदाहरण प्रस्तुतियों में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने का तरीका दिखाते हैं।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**

[IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) का उपयोग करके चार्ट शीर्षक, अक्ष, ग्रिड लाइनों, लीज़ेंड और प्लॉट एरिया को फ़ॉर्मेट करें। यह उदाहरण मार्कर वाले एक लाइन चार्ट को डिफ़ॉल्ट डेटा के साथ बनाता है, फिर इसके वैल्यू और कैटेगरी अक्षों पर अलग-अलग टेक्स्ट और लाइन स्टाइल लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट में निर्दिष्ट हैं; कैटेगरी लेबल को 45 डिग्री घुमा दिया गया है।

वैल्यू एक्सिस [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) का उपयोग स्रोत सेल्स से स्वतंत्र रूप से करता है। इसका स्केल -2 से 15 तक है, प्रमुख अंतराल 2 और न्यूनतर अंतराल 0.5 है। यह उदाहरण प्रतिशत फ़ॉर्मेट को [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) के साथ हजारों में सेट करके जोड़ता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार अनुकूलित करें। लीज़ेंड प्लॉट एरिया के बाहर रहता है क्योंकि [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) को `false` के साथ कॉल किया गया है। बैक‑वॉल और फ़्लोर फ़िल्स को [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) और [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) के माध्यम से कॉन्फ़िगर किया जाता है, लेकिन ये सतहें केवल 3D चार्ट में दिखाई देती हैं।

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

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**

[Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--) के माध्यम से चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार सेट करें। यह उदाहरण 20‑पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और पहले सीरीज़ के लिए [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) के माध्यम से वैल्यू लेबल सक्षम करता है। अपने स्वयं के स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

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

## **संख्यात्मक फ़ॉर्मेट सेट करें**

[IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) का उपयोग करके चार्ट वर्कबुक सेल्स पर बिल्ट‑इन नंबर फ़ॉर्मेट लागू करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक सीरीज़ वैल्यू सेल पर फ़ॉर्मेट इंडेक्स 10 (`0.00%`) लागू करता है। यह वर्कबुक में मानों को बदलें बिना ही उनके प्रदर्शित रूप को बदलता है; उदाहरण के लिए, 0.25 को 25.00% दिखाया जाता है। अक्ष और डेटा‑लेबल फ़ॉर्मेट को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

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

नीचे दी गई तालिका में अंग्रेज़ी (United States) लोकेल के लिये प्रतिनिधि Excel फ़ॉर्मेट के साथ बिल्ट‑इन नंबर फ़ॉर्मेट इंडेक्स सूचीबद्ध हैं। सटीक फ़ॉर्मेट स्ट्रिंग्स और उनका प्रदर्शन एप्लिकेशन और लोकेल के अनुसार बदल सकता है, विशेष रूप से मुद्रा और तिथियों के लिये। कुछ Excel फ़ॉर्मेट OOXML मानक के डिफ़ॉल्ट से भी भिन्न होते हैं, जैसा कि [Microsoft की संख्या फ़ॉर्मेट कार्यान्वयन नोट्स](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

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

## **चार्ट एरिया के गोल किनारे सेट करें**

[IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) को `true` के साथ कॉल करके चार्ट एरिया के किनारों को गोल करें। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) का उपयोग करके उसके आउटलाइन को सॉलिड ग्रे रंग और सिंगल‑लाइन स्टाइल देता है, फिर प्रस्तुति को सेव करता है।

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

## **मौजूदा चार्ट एनोटेशन संपादित करें**

एक चार्ट में कस्टम श्येप्स हो सकते हैं, जैसे रिपोर्ट की स्थिति समझाने वाला टेक्स्ट एनोटेशन। इन श्येप्स तक पहुँचने के लिए [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--) का उपयोग करें, जिसे Chart API रेफ़रेंस में [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) के तहत भी सूचीबद्ध किया गया है। [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) द्वारा लौटाए गए संग्रह में चार्ट‑स्वामित्व वाले श्येप्स होते हैं।

एक सामान्य टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा जाता है, स्लाइड से संबंधित रहता है, भले ही वह चार्ट का हिस्सा दिखे। [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) के माध्यम से इटरेट करने पर चार्ट और सामान्य स्लाइड श्येप्स मिलते हैं, लेकिन चार्ट के भीतर व्यक्तिगत श्येप्स की सूची नहीं बनती। चार्ट शीर्षक और डेटा लेबल अलग‑अलग चार्ट तत्व हैं, न कि इस संग्रह में कस्टम एनोटेशन।

[chart-annotations.pptx](chart-annotations.pptx) डाउनलोड करें और इसे एप्लिकेशन की वर्किंग डायरेक्टरी में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें "Preliminary results" लिखा अनग्रुप्ड एनोटेशन, चार्ट‑स्वामित्व वाली एक लाइन, और "Slide overlay" लिखा एक सामान्य स्लाइड टेक्स्ट बॉक्स है। उदाहरण पहले चार्ट को खोजता है और रिपोर्ट के प्रकाशित होने पर एनोटेशन को "Final results" में बदल देता है। यह खाली संग्रह की जाँच करता है और केवल उन [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) को संपादित करता है जिनका नॉन‑नल टेक्स्ट फ्रेम [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) द्वारा वापस किया जाता है और अपेक्षित टेक्स्ट होता है।

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

लाइन और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहता है। नीचे की छवियों में इनपुट और सहेजे‑गए, पुनः खोले परिणाम दिखाए गए हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल टॉप‑लेवल चार्ट‑स्वामित्व वाले श्येप्स की जाँच करता है। यदि कोई एनोटेशन [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/) के भीतर है, तो उस समूह के [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) संग्रह को भी inspect करें। नेस्टेड समूहों के लिये यह प्रक्रिया पुनरावर्ती रूप से दोहराएँ, और उनके चाइल्ड श्येप्स पर समान टेक्स्ट जाँच लागू करें। समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में न मानें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/क्षेत्रों के लिए अर्ध‑पारदर्शी फ़िल्स सेट कर सकता हूँ जबकि बॉर्डर अपरदर्शी रहे?**

हाँ। फ़िल ट्रांसपेरेंसी और आउटलाइन को अलग‑अलग कॉन्फ़िगर किया जाता है। यह ग्रिड और घनी विज़ुअलाइज़ेशन में डेटा की पठनीयता को सुधारने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं क्या करूँ?**

फ़ॉन्ट आकार घटाएँ, गैर‑आवश्यक लेबल घटकों (जैसे कैटेगरी) को निष्क्रिय करें, लेबल स्थिति समायोजित करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिये लेबल दिखाएँ, या फ़ॉर्मेट को “value + legend” में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल्स लागू कर सकता हूँ?**

हाँ। सीरीज़ सॉलिड, ग्रेडिएंट और पैटर्न फ़िल्स का समर्थन करती हैं। व्यावहारिक रूप से, ग्रेडिएंट को संयम से उपयोग करें और ऐसी संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट को घटा दें।