---
title: Java का उपयोग करके प्रस्तुतियों में चार्ट लेजेंड को कस्टमाइज़ करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/java/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ चार्ट लेजेंड को कस्टमाइज़ करके PowerPoint प्रस्तुतियों को अनुकूलित करें, विशेष लेजेंड फ़ॉर्मेटिंग के साथ."
---
## **अवलोकन**

Aspose.Slides for Java PowerPoint प्रस्तुतियों में चार्ट लीजेंड को अनुकूलित करने के विकल्प प्रदान करता है। यह लेख दिखाता है कि कैसे लीजेंड की स्थिति और आकार निर्धारित करें, पूरे लीजेंड के लिए फ़ॉन्ट आकार सेट करें, व्यक्तिगत लीजेंड प्रविष्टि को फॉर्मेट करें, तथा चयनित प्रविष्टियों को छिपाएँ या पुनर्स्थापित करें।

FAQ संबंधित व्यवहारों को कवर करता है, जिसमें लीजेंड के लिए स्थान आरक्षित करना, बहु पंक्तियों वाले लेबल दिखाना, और प्रस्तुति थीम से फ़ॉर्मेटिंग का वारिस होना शामिल है।

## **लीजेंड स्थान निर्धारण**

लीजेंड के [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), और [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) मेथड्स का उपयोग करके उसकी स्थिति और आकार को चार्ट के आयामों के अंश के रूप में निर्दिष्ट करें।

यह उदाहरण एक प्रस्तुति बनाता है और पहले स्लाइड में डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ता है। इच्छित लीजेंड ऑफ़सेट और आयामों को चार्ट की चौड़ाई और ऊँचाई से भाग देने पर वे सापेक्ष मानों में बदल जाते हैं: लीजेंड चार्ट के शीर्ष‑बाएँ कोने से 50 पॉइंट ऑफ़सेट है और इसका आकार 100 बाय 100 पॉइंट है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // चार्ट के सापेक्ष लेजेंड की स्थिति और आकार को व्यक्त करें।
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लीजेंड का फ़ॉन्ट आकार सेट करना**

लीजेंड के [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) का उपयोग करके उसकी टेक्स्ट फ़ॉर्मेटिंग तक पहुंचें और [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) का उपयोग करके फ़ॉन्ट आकार को पॉइंट्स में सेट करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है और लीजेंड टेक्स्ट को 20 पॉइंट सेट करता है। यह वर्टिकल अक्ष के लिए स्वतः सीमा को निष्क्रिय करता है और इसकी रेंज को -5 से 10 तक सेट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **व्यक्तिगत लीजेंड प्रविष्टि का फ़ॉन्ट आकार सेट करना**

लीजेंड के [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) मेथड द्वारा लौटाए गए संग्रह का उपयोग करके विशिष्ट प्रविष्टि के फ़ॉर्मेटिंग तक पहुंचें। प्रविष्टि अनुक्रमण शून्य‑आधारित है, इसलिए अनुक्रम `1` दूसरी प्रविष्टि को दर्शाता है।

यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है जिसका डिफ़ॉल्ट डेटा कम से कम दो सीरीज़ शामिल करता है। यह दूसरी लीजेंड प्रविष्टि को बोल्ड, इटैलिक, और 20‑पॉइंट नीले टेक्स्ट के साथ फ़ॉर्मेट करता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **व्यक्तिगत लीजेंड प्रविष्टियों को छिपाना**

एक सहायक सीरीज़ को लीजेंड से हटाने के लिए जबकि उसका डेटा दृश्यमान रहे, [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) को `true` के साथ [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) के माध्यम से कॉल करें। यह केवल चयनित लीजेंड प्रविष्टि को छिपाता है; यह सीरीज़ या उसके डेटा बिंदुओं को हटाता नहीं है। इसके विपरीत, [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) को `false` के साथ कॉल करने से पूर्ण लीजेंड छिप जाता है।

नीचे दिया गया उदाहरण डिफ़ॉल्ट डेटा का उपयोग करके कई सीरीज़ के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है। यह दूसरी सीरीज़ की लीजेंड प्रविष्टि (अनुक्रम `1`) को छिपाता है और प्रस्तुति को सहेजता है। फिर यह प्रविष्टि को [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) को `false` के साथ कॉल करके पुनर्स्थापित करता है और दूसरी प्रति सहेजता है। दोनों फ़ाइलों में कॉलम दृश्यमान रहते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // एक ही प्रविष्टि को चार्ट डेटा बदले बिना पुनर्स्थापित करें।
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे का तुलना दिखाता है कि सभी प्रविष्टियों के दृश्यमान और दूसरी प्रविष्टि छुपी होने पर एक ही चार्ट कैसा दिखता है। दूसरी सीरीज़ के कॉलम अपरिवर्तित रहते हैं।

![सभी लीजेंड प्रविष्टियों के दृश्यमान और सीरीज़ 2 के लीजेंड से छिपे होने पर चार्ट की तुलना; सभी कॉलम दृश्यमान रहते हैं।](hide-legend-entry.png)

कॉलम, बार और लाइन चार्ट में, लीजेंड प्रविष्टियाँ सीरीज़ को पहचानती हैं। पाई चार्ट में, वे व्यक्तिगत डेटा बिंदुओं (स्लाइस) को पहचानती हैं, इसलिए चयनित स्लाइस पर [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) का उपयोग करें। API इस डेटा‑पॉइंट मेथड को `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, और `BarOfPie` चार्ट प्रकारों के लिए दस्तावेज़ करता है। इसे डोनट चार्ट पर लागू मानने से बचें, जो इस सूची में नहीं हैं।

## **FAQ**

**क्या मैं चार्ट को लीजेंड के लिए स्थान आरक्षित करने के लिए सेट कर सकता हूँ बजाय उसे ओवरले करने के?**  
हाँ। [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) को `false` के साथ कॉल करके लीजेंड के लिए स्थान आरक्षित करें, बजाय प्लॉट एरिया के ऊपर ओवरले करने की अनुमति देने के।

**क्या मैं मल्टीलाइन लीजेंड लेबल बना सकता हूँ?**  
हाँ। जब उपलब्ध चौड़ाई अपर्याप्त हो तो लंबे लेबल रैप हो सकते हैं। आप सीरीज़ नामों में newline अक्षर का उपयोग करके लाइन ब्रेक का अनुरोध भी कर सकते हैं।

**मैं लीजेंड को प्रस्तुति थीम के रंग योजना के अनुसार कैसे बना सकता हूँ?**  
लीजेंड के रंग, फ़िल और फ़ॉन्ट को सेट न रखें ताकि वह थीम फ़ॉर्मेटिंग को वारिस कर सके। स्पष्ट फ़ॉर्मेटिंग संबंधित थीम सेटिंग्स को ओवरराइड करती है।