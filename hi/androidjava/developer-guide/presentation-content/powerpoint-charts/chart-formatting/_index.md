---
title: एंड्रॉइड पर प्रस्तुति चार्ट को स्वरूपित करें
linktitle: चार्ट स्वरूपण
type: docs
weight: 60
url: /hi/androidjava/chart-formatting/
keywords:
- चार्ट स्वरूपित करें
- चार्ट स्वरूपण
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android में जावा के माध्यम से चार्ट स्वरूपण सीखें और कस्टम एक्सिस, फ़ॉन्ट, संख्या स्वरूप और गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनाएं।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को स्वरूपित करने का तरीका समझाता है। यह एक्सिस, ग्रिड लाइन्स, शीर्षक, लीजेंड, प्लॉट एरिया, और वॉल फ़िल्स जैसे मुख्य चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को बेहतर बनाने का प्रदर्शन करता है।

यह चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण निर्धारित करने, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक स्वरूप लागू करने, और चार्ट एरिया के लिए गोल किनारों को सक्षम करने का भी प्रदर्शन करता है। ये उदाहरण मिलकर प्रस्तुतिकरण में चार्ट के दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने के तरीके दर्शाते हैं।

## **चार्ट घटकों को स्वरूपित करना**

चार्ट शीर्षक, एक्सिस, ग्रिड लाइन्स, लीजेंड और प्लॉट एरिया को स्वरूपित करने के लिए [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) का उपयोग करें। यह उदाहरण मार्कर वाले एक लाइन चार्ट को डिफ़ॉल्ट डेटा के साथ बनाता है, फिर उसके वैल्यू और कैटेगरी एक्सिस पर अलग-अलग टेक्स्ट और लाइन शैलियों को लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट्स में निर्दिष्ट हैं; कैटेगरी लेबल को 45 डिग्री घुमाया गया है।

वैल्यू एक्सिस स्रोत कोशिकाओं से स्वतंत्र रूप से [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) का उपयोग करता है। इसका स्केल -2 से 15 तक है, प्रमुख अंतराल 2 और छोटा अंतराल 0.5 है। यह उदाहरण प्रतिशत स्वरूप को [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) को हजारों पर सेट करके भी जोड़ता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार समायोजित करें। लेजेंड प्लॉट एरिया के बाहर रहता है क्योंकि [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) को `false` के साथ बुलाया गया है। बैक-वॉल और फर्श भराव [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) और [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) के माध्यम से कॉन्फ़िगर किए जाते हैं, लेकिन ये सतहें केवल 3D चार्ट में ही दृश्य होती हैं।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
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
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

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

चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार को [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--) के माध्यम से सेट करें। यह उदाहरण 20 पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और पहले श्रृंखला के लिए [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) के द्वारा मान लेबल सक्षम करता है। अपने स्वयं के स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट के डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

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

## **संख्यात्मक स्वरूप सेट करें**

[IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) का उपयोग करके चार्ट कार्यपुस्तिका कोशिकाओं पर एक बिल्ट-इन नंबर फ़ॉर्मेट लागू करें। यह उदाहरण डिफ़ॉल्ट, सेल-समर्थित डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक श्रृंखला मान कोशिका पर फ़ॉर्मेट इंडेक्स 10 (`0.00%`) लागू करता है। यह कार्यपुस्तिका में मानों को बदलें बिना संख्याओं को बदले उनके प्रदर्शन को बदलता है; उदाहरण के लिए, 0.25 को 25.00% दिखाया जाता है। एक्सिस और डेटा-लेबल फ़ॉर्मेट को अलग-अलग कॉन्फ़िगर किया जा सकता है।

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

निम्न तालिका में निर्मित संख्या स्वरूप सूचकांक और उनके प्रतिनिधित्व वाले Excel स्वरूपों को इंग्लिश (United States) लोकैल के लिए सूचीबद्ध किया गया है। वास्तविक स्वरूप स्ट्रिंग और उनका प्रदर्शन अनुप्रयोग और लोकैल के अनुसार बदल सकता है, विशेष रूप से मुद्रा और तिथियों के लिये। कुछ Excel स्वरूप OOXML मानक के डिफॉल्ट से भी भिन्न होते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

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

## **चार्ट एरिया के गोल किनारे सेट करें**

[IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) को `true` के साथ बुलाकर चार्ट एरिया के किनारों को गोल करें। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) का उपयोग करके उसकी रूपरेखा को ठोस ग्रे रंग और सिंगल-लाइन शैली देता है, फिर प्रस्तुति को सहेजता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

एक चार्ट में कस्टम शैप्स हो सकते हैं, जैसे कि रिपोर्ट की स्थिति बताने वाला टेक्स्ट एनोटेशन। इन शैप्स तक पहुंचने के लिए [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--) का उपयोग करें, जो [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) में भी सूचीबद्ध है। [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) द्वारा लौटाई गई कलेक्शन में चार्ट-स्वामित्व वाले शैप्स शामिल होते हैं।

एक सामान्य टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा जाता है, वह स्लाइड का हिस्सा होता है, चाहे वह चार्ट का हिस्सा जैसा दिखे। [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) के माध्यम से इटरेट करने पर चार्ट और सामान्य स्लाइड शैप्स मिलते हैं, लेकिन चार्ट के अंदर व्यक्तिगत शैप्स को नहीं गिना जाता। चार्ट शीर्षक और डेटा लेबल अलग-अलग चार्ट तत्व होते हैं, न कि इस कलेक्शन में कस्टम एनोटेशन।

[chart-annotations.pptx](chart-annotations.pptx) डाउनलोड करें और इसे अनुप्रयोग की कार्य निर्देशिका में रखें। इस फ़ाइल की पहली स्लाइड में एक चार्ट है जिसमें अनग्रुप्ड एनोटेशन "Preliminary results", एक चार्ट-स्वामित्व वाली लाइन, और एक सामान्य स्लाइड टेक्स्ट बॉक्स "Slide overlay" है। उदाहरण उस स्लाइड पर पहले चार्ट को खोजता है और रिपोर्ट तैयार होने पर एनोटेशन को "Final results" में बदल देता है। यह खाली कलेक्शन की जाँच करता है और केवल उन [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) को संपादित करता है जिनमें गैर-शून्य टेक्स्ट फ्रेम हो, जिसे [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) द्वारा प्राप्त किया गया हो और अपेक्षित टेक्स्ट हो।

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

लाइन और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहता है। निम्न छवियां इनपुट और सहेजे गए, पुनः खोले गए परिणाम को दर्शाती हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल शीर्ष-स्तर के चार्ट-स्वामित्व वाले शैप्स की जांच करता है। यदि कोई एनोटेशन [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/) के भीतर है, तो उस समूह की [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) कलेक्शन को भी निरीक्षण करें। नेस्टेड समूहों के लिए इसे पुनरावर्ती रूप से दोहराएँ, और उनके चाइल्ड शैप्स पर समान टेक्स्ट जाँच लागू करें। समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स की तरह न मानें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्ध-पारदर्शी फ़िल्स सेट कर सकता हूँ जबकि सीमा को अपारदर्शी रख सकता हूँ?**

हाँ। फ़िल ट्रांसपैरेंसी और बाहरी रूपरेखा को अलग से कॉन्फ़िगर किया जाता है। यह ग्रिड और घनी विज़ुअलाइज़ेशन में डेटा की पठनीयता सुधारने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं क्या करूँ?**

फ़ॉन्ट आकार घटाएँ, गैर-आवश्यक लेबल घटकों को अक्षम करें (जैसे, कैटेगरी), लेबल स्थितियों को समायोजित करें, आवश्यक हो तो केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या फ़ॉर्मेट को "value + legend" में बदलें।

**क्या मैं श्रृंखलाओं पर ग्रेडिएंट या पैटर्न फ़िल्स लागू कर सकता हूँ?**

हाँ। श्रृंखलाएँ ठोस, ग्रेडिएंट और पैटर्न फ़िल्स को समर्थन देती हैं। व्यावहारिक रूप से, ग्रेडिएंट को संयमित रूप से उपयोग करें और ऐसी संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट कम कर दें।