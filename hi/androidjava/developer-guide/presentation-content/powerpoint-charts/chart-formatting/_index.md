---
title: Android पर प्रस्तुति चार्ट स्वरूपित करें
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में Java के माध्यम से चार्ट स्वरूपण सीखें और कस्टम अक्ष, फ़ॉन्ट, संख्यात्मक स्वरूप और गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनायें।"
---
## **अवलोकन**

यह लेख PowerPoint प्रस्तुतियों में चार्ट को Aspose.Slides का उपयोग करके स्वरूपित करने के तरीके को समझाता है। यह अक्ष, ग्रिड रेखाएं, शीर्षक, लीजेंड, प्लॉट क्षेत्र, और दीवार भराव जैसी प्रमुख चार्ट तत्वों को अनुकूलित करने का प्रदर्शन करता है ताकि चार्ट डेटा की उपस्थिति और पठनीयता में सुधार हो सके।

यह चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक स्वरूप लागू करने, और चार्ट क्षेत्र के लिए गोल कोनों को सक्षम करने का भी प्रदर्शन करता है। साथ में, ये उदाहरण दिखाते हैं कि कैसे प्रस्तुतियों में चार्ट के दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित किया जा सकता है।

उभयनिर्देशीय अंतराल पर अलग भराव और रूपरेखा के लिए, देखें [स्टॉक चार्ट उदाहरण](/slides/hi/androidjava/create-chart/#create-stock-charts)।

## **चार्ट घटकों का स्वरूपण**

चार्ट शीर्षकों, अक्षों, ग्रिड रेखाओं, लीजेंड और प्लॉट क्षेत्र को स्वरूपित करने के लिए [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) का उपयोग करें। यह उदाहरण मार्कर और डिफ़ॉल्ट डेटा वाले लाइन चार्ट बनाता है, फिर इसके मान और वर्गीकरण अक्षों पर अलग टेक्स्ट और रेखा शैलियों को लागू करता है। फ़ॉन्ट आकार और रेखा चौड़ाई पॉइंट में निर्दिष्ट की जाती हैं; वर्गीकरण लेबल को 45 डिग्री घुमा दिया जाता है।

मान अक्ष स्रोत कोशिकाओं से स्वतंत्र रूप से [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) का उपयोग करता है। इसका स्केल -2 से 15 तक है, प्रमुख अंतराल 2 और द्वितीयक अंतराल 0.5 हैं। यह उदाहरण प्रतिशत स्वरूपण को [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) को हजारों पर सेट करने के साथ भी संयोजित करता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार अनुकूलित करें। लीजेंड प्लॉट क्षेत्र के बाहर रहता है क्योंकि [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) को `false` के साथ बुलाया गया है। बैक‑वॉल और फ़्लोर भराव को [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) और [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) के माध्यम से कॉन्फ़िगर किया जाता है, लेकिन ये सतहें केवल 3D चार्ट में दिखाई देती हैं।

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

चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार को [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--) के माध्यम से सेट करें। यह उदाहरण 20 पॉइंट फ़ॉन्ट वाले क्लस्टर्ड कॉलम चार्ट बनाता है और [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) के द्वारा प्रथम श्रृंखला के लिए मान लेबल सक्षम करता है। अपने स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट के डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

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

## **चार्ट लीजेंड के लिए टेक्स्ट फ्रेम स्वरूपण का पुन: उपयोग करें**

लेजेंड को स्लाइड शीर्षक के साथ मेल खाने के लिए, पहले पैराग्राफ पर [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) के माध्यम से शीर्षक का फ़ॉन्ट सेट करें। लेजेंड के [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) द्वारा लौटाए गए स्वरूप पर [copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) को कॉल करें। यह टेक्स्ट फ्रेम सेटिंग्स, पहले पैराग्राफ का स्वरूप, और उस पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट गुण कॉपी करता है। व्यक्तिगत भागों या बाद के पैराग्राफ़ पर सीधे लागू किया गया स्वरूप स्रोत के स्थानीय रहता है।

यह उदाहरण टेम्पलेट के रूप में नेवी रंग में बोल्ड, 26‑पॉइंट कैलिब्री शीर्षक का उपयोग करता है। लेजेंड को स्टाइल करने के बाद, यह एक अलग कैप्शन पर वही स्वरूप लागू करने के लिए [copyTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) को कॉल करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    font.getFillFormat().getSolidFillColor().setColor(Color.rgb(32, 64, 96));

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

सहेजे गए प्रस्तुति में, लेजेंड और कैप्शन आकार, वजन और रंग में शीर्षक से मेल खाते हैं। लेजेंड अभी भी श्रृंखला नाम प्रदर्शित करता है, और कैप्शन अपना स्वयं का पाठ रखता है। यदि कैप्शन के किसी भाग में पहले से स्पष्ट फ़ॉन्ट आकार मौजूद है, तो वह आकार कॉपी किए गए पैराग्राफ़ डिफ़ॉल्ट पर प्राथमिकता लेता है।

| कॉपी करने से पहले | कॉपी करने के बाद |
| --- | --- |
| ![त्रैमासिक बिक्री चार्ट जिसमें सामान्य काली लेजेंड लेबल और काली कैप्शन है](legend-formatting-before.png) | ![उसी चार्ट में बड़े, बोल्ड नेवी लेजेंड लेबल और मिलते-जुलते कैप्शन](legend-formatting.png) |

## **संख्यात्मक स्वरूप सेट करें**

[IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) का उपयोग करके चार्ट वर्कबुक कोशिकाओं पर निर्मित संख्या स्वरूप लागू करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा वाले क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक श्रृंखला मान कोशिका पर स्वरूप इंडेक्स 10 (`0.00%`) लागू करता है। यह वर्कबुक में मानों के प्रदर्शित होने के तरीके को बदलता है बिना अंतर्निहित संख्याओं को बदले; उदाहरण के लिए, 0.25 को 25.00% दिखाया जाएगा। अक्ष और डेटा‑लेबल स्वरूप को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

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

निम्न तालिका में अंग्रेज़ी (संयुक्त राज्य) क्षेत्र के प्रतिनिधि Excel स्वरूपों के साथ निर्मित संख्या स्वरूप सूचकांक सूचीबद्ध हैं। सटीक स्वरूप स्ट्रिंग और उनका प्रदर्शन एप्लिकेशन और लोकेल के अनुसार अलग हो सकता है, विशेषकर मुद्रा और तिथियों के लिए। कुछ Excel स्वरूप OOXML मानक के डिफ़ॉल्ट से भी भिन्न होते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

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

## **चार्ट क्षेत्र गोल किनारे सेट करें**

`true` के साथ [IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) को कॉल करके चार्ट क्षेत्र के कोनों को गोल करें। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और सहेजने से पहले उसकी रूपरेखा को ठोस ग्रे रंग और सिंगल‑लाइन शैली देने के लिए [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) का उपयोग करता है।

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

एक चार्ट में कस्टम आकृतियां हो सकती हैं, जैसे रिपोर्ट की स्थिति समझाने वाला टेक्स्ट एनोटेशन। इन आकृतियों तक पहुंचने के लिए [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--) का उपयोग करें, जो [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) के अंतर्गत भी सूचीबद्ध है। [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) द्वारा लौटाए गए संग्रह में चार्ट‑स्वामित्व वाली आकृतियां होती हैं।

एक सामान्य टेक्स्ट बॉक्स जो चार्ट के ऊपर रखी जाती है, स्लाइड की ही होती है, भले ही वह चार्ट का हिस्सा लगती हो। [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) के माध्यम से इटररेट करने से चार्ट और सामान्य स्लाइड आकृतियां मिलती हैं, लेकिन चार्ट के भीतर की व्यक्तिगत आकृतियों को सूचीबद्ध नहीं करता। चार्ट शीर्षक और डेटा लेबल अलग‑अलग चार्ट तत्व होते हैं, इस संग्रह में कस्टम एनोटेशन नहीं होते।

[chart-annotations.pptx](chart-annotations.pptx) डाउनलोड करें और इसे एप्लिकेशन की कार्यशील निर्देशिका में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें "Preliminary results" पढ़ने वाला अनग्रुप्ड एनोटेशन, एक चार्ट‑स्वामित्व वाली रेखा, और "Slide overlay" पढ़ने वाला सामान्य स्लाइड टेक्स्ट बॉक्स है। उदाहरण उस स्लाइड पर पहला चार्ट खोजता है और रिपोर्ट प्रकाशित करने के लिए तैयार होने पर एनोटेशन को "Final results" में बदल देता है। यह खाली संग्रह की जाँच करता है और केवल एक ऐसे [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) को संपादित करता है जिसका नॉन‑नल टेक्स्ट फ्रेम [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) द्वारा लौटाया जाता है और अपेक्षित टेक्स्ट मौजूद है।

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

रेखा और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहता है। निम्न छवियां इनपुट और सहेजे गए, फिर खोलने पर प्राप्त परिणाम दिखाती हैं:

| संपादन से पहले | संशोधन के बाद |
| --- | --- |
| ![चार्ट एनोटेशन जिसमें "Preliminary results" लिखा है](chart-annotations-before.png) | ![चार्ट एनोटेशन जिसमें "Final results" लिखा है](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
यह उदाहरण केवल शीर्ष‑स्तर के चार्ट‑स्वामित्व वाले आकृतियों की जाँच करता है। यदि कोई एनोटेशन किसी [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/) के भीतर है, तो उस समूह की [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) संग्रह को भी जाँचें। नेस्टेड समूहों के लिए इसे पुनरावर्ती रूप से दोहराएँ, उनके चाइल्ड शैप्स पर समान टेक्स्ट जांच लागू करें। स्वयं एक समूह एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में न मानें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्ध-पारदर्शी भराव सेट कर सकता हूँ जबकि बॉर्डर अपारदर्शी रखूँ?**  
हां। भराव की पारदर्शिता और रूपरेखा को अलग‑अलग कॉन्फ़िगर किया जाता है। यह घनी दृश्यावली में ग्रिड और डेटा की पठनीयता सुधारने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं कैसे निपटूँ?**  
फ़ॉन्ट आकार कम करें, अनावश्यक लेबल घटकों को अक्षम करें (उदाहरण के लिए, वर्गीकरण), लेबल स्थान समायोजित करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या स्वरूप को "मान + लीजेंड" में बदलें।

**क्या मैं श्रृंखला पर ग्रेडिएंट या पैटर्न भराव लागू कर सकता हूँ?**  
हां। श्रृंखला ठोस, ग्रेडिएंट और पैटर्न भराव का समर्थन करती हैं। वास्तव में, ग्रेडिएंट का सीमित उपयोग करें और ऐसी संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट को घटाते हैं।