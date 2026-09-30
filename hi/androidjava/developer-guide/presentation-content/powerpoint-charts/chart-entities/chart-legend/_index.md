---
title: Android पर प्रस्तुतियों में चार्ट लेजेंड को कस्टमाइज़ करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/androidjava/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ चार्ट लेजेंड को कस्टमाइज़ करें ताकि अनुकूलित लेजेंड फ़ॉर्मेटिंग के साथ PowerPoint प्रस्तुतियों का अनुकूलन हो सके।"
---
## **अवलोकन**

Aspose.Slides for Android via Java PowerPoint प्रस्तुतियों में चार्ट लीजेंड को अनुकूलित करने के विकल्प प्रदान करता है। यह लेख दिखाता है कि लीजेंड को कैसे स्थित और आकार दिया जाए, पूरे लीजेंड के लिए फ़ॉन्ट आकार कैसे सेट किया जाए, किसी व्यक्तिगत लीजेंड प्रविष्टि को कैसे स्वरूपित किया जाए, और चयनित प्रविष्टियों को कैसे छिपाया या पुनर्स्थापित किया जाए।

FAQ संबंधित व्यवहारों को कवर करता है, जिसमें लीजेंड के लिए स्थान आरक्षित करना, बहु‑लाइन लेबल प्रदर्शित करना, और प्रस्तुति थीम से स्वरूपण को विरासत में प्राप्त करना शामिल है।

## **लेजेंड स्थिति निर्धारण**

लीजेंड की [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), और [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) विधियों का उपयोग करके उसकी स्थिति और आकार को चार्ट के आयामों के अंश के रूप में निर्दिष्ट करें।

यह उदाहरण एक प्रस्तुति बनाता है और पहले स्लाइड में डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ता है। इच्छित लीजेंड ऑफ़सेट और आयामों को चार्ट की चौड़ाई और ऊँचाई से विभाजित करने पर वे सापेक्ष मानों में बदल जाते हैं: लीजेंड चार्ट के शीर्ष‑बाएँ कोने से 50 पॉइंट्स की दूरी पर स्थित है और इसका आकार 100 बाय 100 पॉइंट्स है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // लीजेंड की स्थिति और आकार को चार्ट के सापेक्ष व्यक्त करें।
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लीजेंड के फ़ॉन्ट आकार को सेट करना**

लीजेंड की [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) का उपयोग करके उसके टेक्स्ट स्वरूपण तक पहुँचें और फ़ॉन्ट आकार को पॉइंट में सेट करने के लिए [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) का उपयोग करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है और लीजेंड टेक्स्ट को 20 पॉइंट्स सेट करता है। यह वर्टिकल एक्सिस के लिए स्वचालित सीमा को भी निष्क्रिय करता है और उसकी रेंज को -5 से 10 तक सेट करता है।

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

## **व्यक्तिगत लीजेंड प्रविष्टि के फ़ॉन्ट आकार को सेट करना**

लीजेंड की [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) विधि द्वारा लौटाए गए संग्रह का उपयोग करके किसी विशिष्ट प्रविष्टि के स्वरूपण तक पहुँचें। प्रविष्टि सूचकांक शून्य‑आधारित होते हैं, इसलिए सूचकांक `1` दूसरी प्रविष्टि को दर्शाता है।

यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा में कम से कम दो श्रृंखलाएँ शामिल हैं। यह दूसरी लीजेंड प्रविष्टि को बोल्ड, इटैलिक, और 20‑पॉइंट नीले टेक्स्ट के साथ स्वरूपित करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

लेजेंड से एक सहायक श्रृंखला को बाहर करने के लिए जबकि उसके डेटा को दृश्यमान रखें, [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) को `true` के साथ कॉल करें, जिसे [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) के माध्यम से किया जाता है। यह केवल चयनित लीजेंड प्रविष्टि को छुपाता है; यह श्रृंखला या उसके डेटा पॉइंट्स को नहीं हटाता। इसके विपरीत, [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) को `false` के साथ कॉल करने से पूरा लीजेंड छिप जाता है।

निम्न उदाहरण डिफ़ॉल्ट डेटा के साथ कई श्रृंखलाओं वाले एक क्लस्टर्ड कॉलम चार्ट बनाता है। यह दूसरी श्रृंखला की लीजेंड प्रविष्टि (सूचकांक `1`) को छिपाता है और प्रस्तुति को सहेजता है। फिर यह [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) को `false` के साथ कॉल करके प्रविष्टि को पुनर्स्थापित करता है और दूसरी प्रतिलिपि सहेजता है। दोनों फ़ाइलों में कॉलम दृश्यमान रहते हैं।

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

    // चार्ट डेटा को बदले बिना वही प्रविष्टि पुनर्स्थापित करें।
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

नीचे का तुलना दिखाती है कि समान चार्ट सभी प्रविष्टियों के दृश्यमान और दूसरी प्रविष्टि के छिपे होने पर कैसा दिखता है। दूसरी श्रृंखला के कॉलम अपरिवर्तित रहते हैं।

![सभी लीजेंड प्रविष्टियों के दृश्यमान और लीजेंड से श्रृंखला 2 छिपी हुई के साथ चार्ट की तुलना; सभी कॉलम दृश्यमान रहते हैं।](hide-legend-entry.png)

कॉलम, बार और लाइन चार्ट में, लीजेंड प्रविष्टियाँ श्रृंखलाओं की पहचान करती हैं। पाई चार्ट के लिए, वे व्यक्तिगत डेटा पॉइंट्स (स्लाइस) की पहचान करती हैं, इसलिए चयनित स्लाइस पर [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) का उपयोग करें। API इस डेटा‑पॉइंट मेथड को `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, और `BarOfPie` चार्ट प्रकारों के लिए दस्तावेज़ित करता है। इस बात का अनुमान न लगाएँ कि यह डोनट चार्ट पर लागू होता है, जो सूची में नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट को लीजेंड के लिए स्थान आरक्षित करने के बजाय इसे ओवरले करने दे सकता हूँ?**  
हां। लीजेंड के लिए स्थान आरक्षित करने के लिए, [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) को `false` के साथ कॉल करें, जिससे यह प्लॉट क्षेत्र के ऊपर ओवरले न हो।

**क्या मैं बहु‑लाइन लेजेंड लेबल बना सकता हूँ?**  
हां। जब उपलब्ध चौड़ाई अपर्याप्त हो तो लंबे लेबल रैप हो सकते हैं। आप श्रृंखला नामों में न्यूलाइन कैरेक्टर का उपयोग करके लाइन ब्रेक भी अनुरोध कर सकते हैं।

**मैं लीजेंड को प्रस्तुति थीम की रंग योजना के अनुसार कैसे बना सकता हूँ?**  
लीजेंड के रंग, भराव और फ़ॉन्ट को अनसेट छोड़ दें ताकि यह थीम स्वरूपण को विरासत में प्राप्त कर सके। स्पष्ट स्वरूपण संबंधित थीम सेटिंग्स को ओवरराइड करता है।