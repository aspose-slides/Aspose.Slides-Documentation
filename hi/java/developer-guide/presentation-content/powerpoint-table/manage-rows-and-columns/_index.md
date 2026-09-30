---
title: PowerPoint तालिकाओं में पंक्तियों और स्तंभों का प्रबंधन Java का उपयोग करके
linktitle: पंक्तियाँ और स्तंभ
type: docs
weight: 20
url: /hi/java/manage-rows-and-columns/
keywords:
- टेबल पंक्ति
- टेबल स्तंभ
- पहली पंक्ति
- टेबल हैडर
- पंक्ति क्लोन
- स्तंभ क्लोन
- पंक्ति कॉपी
- स्तंभ कॉपी
- पंक्ति हटाएँ
- स्तंभ हटाएँ
- पंक्ति पाठ स्वरूपण
- स्तंभ पाठ स्वरूपण
- टेबल शैली
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "PowerPoint में Aspose.Slides for Java का उपयोग करके तालिका पंक्तियों और स्तंभों को प्रबंधित करें और प्रस्तुति संपादन तथा डेटा अपडेट को तेज़ बनाएं।"
---
## **परिचय**

Aspose.Slides for Java आपको PowerPoint प्रस्तुतियों में तालिका की संरचना और स्वरूपण को [टेबल](https://reference.aspose.com/slides/java/com.aspose.slides/table/) क्लास और [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) इंटरफ़ेस के माध्यम से प्रबंधित करने की अनुमति देता है। आप हेडर पंक्ति निर्धारित कर सकते हैं, पंक्तियों और स्तंभों को क्लोन या हटाकर, और पूरी पंक्ति या स्तंभ पर पाठ स्वरूपण लागू कर सकते हैं।

यह लेख इन कार्यों को Java उदाहरणों के साथ समझाता है। यह दिखाता है कि तालिका की शैली प्रीसेट को कैसे प्राप्त करें ताकि उसे पुन: उपयोग किया जा सके। तालिका पंक्ति और स्तंभ सूचकांक शून्य‑आधारित होते हैं।

## **पंक्ति ऊँचाई नियंत्रण**

[IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) का उपयोग करके पंक्ति की न्यूनतम ऊँचाई पॉइंट में निर्धारित करें। यह एक निचला मान है, स्थायी ऊँचाई नहीं। [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) वास्तविक ऊँचाई लौटाता है। पंक्ति तक पहुँचें [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--) के द्वारा।

उदाहरण में [row-height-input.pptx](row-height-input.pptx) लोड किया गया है, जिसमें पहले स्लाइड पर पहली आकृति के रूप में एक तालिका है। इसकी पहली पंक्ति 70 पॉइंट पर शुरू होती है। सेल्स में 18‑पॉइंट Arial पाठ, रैपिंग, तथा 6‑पॉइंट ऊपर‑नीचे मार्जिन है; दूसरे स्तंभ में लंबा पाठ कई लाइनों में रैप होता है। उदाहरण न्यूनतम को 100 पॉइंट बढ़ाता है, फिर 20 पॉइंट घटाता है, प्रत्येक परिवर्तन के बाद वास्तविक ऊँचाई को प्रिंट करता है, और दोनों परिणाम सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

प्रदान की गई प्रस्तुति के साथ, न्यूनतम बढ़ाने से पंक्ति में जगह जुड़ती है। घटाने से वह अतिरिक्त जगह हटती है, पर वास्तविक ऊँचाई 20 पॉइंट से अधिक ही रहती है क्योंकि पाठ और सेल मार्जिन को अधिक जगह चाहिए। केवल न्यूनतम घटाना सामग्री द्वारा आवश्यक जगह से नीचे पंक्ति को नहीं ला सकता।

वास्तविक ऊँचाई को प्रभावित करने वाले कई कारक हैं:

- **पाठ और फ़ॉन्ट आकार:** लंबा पाठ, स्पष्ट लाइन ब्रेक, या बड़ा फ़ॉन्ट अधिक ऊर्ध्वाधर जगह ले सकता है।
- **रैपिंग और स्तंभ चौड़ाई:** रैपिंग सक्षम होने पर, [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) से स्तंभ चौड़ाई घटाने से अधिक लाइनों का निर्माण हो सकता है। चौड़ा स्तंभ ऊर्ध्वाधर जगह कम कर सकता है।
- **सेल मार्जिन:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) और [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) ऊर्ध्वाधर जगह जोड़ते हैं। [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) और [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) पाठ के लिए उपलब्ध चौड़ाई घटाते हैं और अतिरिक्त रैपिंग का कारण बन सकते हैं।

इस तालिका में बिना मर्ज किए हुए सेल्स के लिए, वह सेल जो सबसे अधिक ऊर्ध्वाधर जगह लेता है, वह पूरी पंक्ति के लिए सामग्री‑निर्भर निचला सीमा निर्धारित करता है। पंक्ति को छोटा करने के लिए आपको पाठ को घटाना, फ़ॉन्ट आकार या मार्जिन कम करना, या स्तंभ की चौड़ाई बढ़ाना पड़ सकता है।

नीचे दी गई छवियाँ समान तालिका को समान स्केल पर दिखाती हैं। प्रदर्शित परिणामों में वास्तविक ऊँचाइयाँ क्रमशः 70, 100 और 55.2 पॉइंट थीं: अंतिम पंक्ति का न्यूनतम 20 पॉइंट होने के बावजूद वह अधिक ऊँची रही। सटीक पाठ माप आपके वातावरण में उपलब्ध फ़ॉन्ट पर निर्भर कर सकते हैं। सहेजे गए परिणाम डाउनलोड करें: [बढ़ाया गया न्यूनतम](row-height-increased.pptx) और [घटाया गया न्यूनतम](row-height-decreased.pptx).

| मूल: न्यूनतम 70 pt, वास्तविक 70 pt | बढ़ाया गया: न्यूनतम 100 pt, वास्तविक 100 pt | घटाया गया: न्यूनतम 20 pt, वास्तविक 55.2 pt |
| --- | --- | --- |
| ![70‑पॉइंट पहले पंक्ति वाली मूल तालिका।](row-height-before.png) | ![पहली पंक्ति का न्यूनतम 100 पॉइंट करने के बाद तालिका।](row-height-increased.png) | ![पहली पंक्ति का न्यूनतम 20 पॉइंट करने के बाद तालिका; रैप्ड पाठ पंक्ति को न्यूनतम से अधिक ऊँचा रखता है।](row-height-decreased.png) |

## **पहली पंक्ति को हेडर के रूप में सेट करें**

[setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) मेथड का उपयोग करके पहली पंक्ति को हेडर स्वरूपण के लिए चिह्नित करें। उसका रूप तालिका पर लागू शैली पर निर्भर करता है।

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।
2. पहली स्लाइड तक पहुँचें।
3. स्लाइड पर पहली आकृति के रूप में संग्रहीत तालिका तक पहुँचें।
4. उसकी पहली पंक्ति के लिए हेडर स्वरूपण सक्षम करें।
5. संशोधित प्रस्तुति को सहेजें।

उदाहरण को `table.pptx` की आवश्यकता है जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक तालिका है। यह पहली पंक्ति के लिए हेडर स्वरूपण सक्षम करता है और `First_row_header.pptx` सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **तालिका की पंक्ति या स्तंभ को क्लोन करें**

पंक्तियों या स्तंभों को क्लोन करके उनकी सामग्री और स्वरूपण को पुन: उपयोग करें। आप कॉपी को तालिका के अंत में जोड़ सकते हैं या किसी विशेष स्थान पर सम्मिलित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।
2. पहली स्लाइड तक पहुँचें।
3. स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
4. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) मेथड से तालिका जोड़ें।
5. आवश्यक पंक्तियों को क्लोन करें।
6. आवश्यक स्तंभों को क्लोन करें।
7. संशोधित प्रस्तुति को सहेजें।

उदाहरण को `Test.pptx` की आवश्यकता है जिसमें कम से कम एक स्लाइड हो। यह तीन स्तंभ और पाँच पंक्तियों वाली तालिका बनाता है, आकार पॉइंट में निर्दिष्ट। यह पहली पंक्ति और स्तंभ की प्रतियाँ अंत में जोड़ता है, फिर दूसरी पंक्ति और स्तंभ की प्रतियों को इंडेक्स 3 (चौथा स्थान) पर सम्मिलित करता है। परिणामस्वरूप तालिका में सात पंक्तियाँ और पाँच स्तंभ होते हैं। `false` तर्क निकटवर्ती मर्ज किए हुए पंक्तियों या स्तंभों में क्लोनिंग को निष्क्रिय करता है; इस तालिका में कोई मर्ज किए हुए सेल नहीं हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **तालिका से पंक्ति या स्तंभ हटाएँ**

तालिका में अब आवश्यक न रहने वाली पंक्तियों या स्तंभों को हटाएँ। कोई आइटम हटाने से उसके बाद आने वाली पंक्तियों या स्तंभों के सूचकांक शिफ्ट हो जाते हैं।

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास से नई प्रस्तुति बनाएँ।
2. पहली स्लाइड तक पहुँचें।
3. स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
4. [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) मेथड से तालिका जोड़ें।
5. दूसरी पंक्ति और दूसरा स्तंभ हटाएँ।
6. संशोधित प्रस्तुति को सहेजें।

यह उदाहरण तीन‑बाय‑तीन तालिका बनाता है और इंडेक्स 1 पर पंक्ति और स्तंभ हटाता है, जिससे `TestTable_out.pptx` में दो‑बाय‑दो तालिका बचती है। आकार पॉइंट में हैं। `false` तर्क निकटवर्ती मर्ज किए हुए पंक्तियों या स्तंभों के हटाने को निष्क्रिय करता है; इस तालिका में कोई मर्ज किए हुए सेल नहीं हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **तालिका पंक्ति स्तर पर पाठ स्वरूपण सेट करें**

पूरी पंक्ति पर पाठ स्वरूपण लागू करके उसकी सभी सेल्स को समान रखें। आप फ़ॉन्ट गुण, पैराग्राफ स्वरूपण, और पाठ दिशा सेट कर सकते हैं बिना प्रत्येक सेल को अलग‑अलग स्वरूपित किए।

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।
2. पहली स्लाइड पर तालिका तक पहुँचें।
3. पहली पंक्ति के लिए [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) का उपयोग करें।
4. पहली पंक्ति के लिए [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) और [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) का उपयोग करें।
5. दूसरी पंक्ति के लिए [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) का उपयोग करें।
6. संशोधित प्रस्तुति को सहेजें।

उदाहरण को `table.pptx` की आवश्यकता है जिसमें पहली स्लाइड पर पहली आकृति के रूप में तालिका और कम से कम दो पंक्तियाँ हों। यह पहली पंक्ति पर 25‑पॉइंट पाठ, दाएँ संरेखण, और 20‑पॉइंट दाएँ पैराग्राफ मार्जिन लागू करता है, फिर दूसरी पंक्ति में ऊर्ध्वाधर पाठ सेट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **तालिका स्तंभ स्तर पर पाठ स्वरूपण सेट करें**

पूरे स्तंभ पर पाठ स्वरूपण लागू करके उसकी सभी सेल्स को समान रखें। आप फ़ॉन्ट गुण, पैराग्राफ स्वरूपण, और पाठ दिशा सेट कर सकते हैं बिना प्रत्येक सेल को अलग‑अलग स्वरूपित किए।

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।
2. पहली स्लाइड पर तालिका तक पहुँचें।
3. पहले स्तंभ के लिए [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) का उपयोग करें।
4. पहले स्तंभ के लिए [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) और [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) का उपयोग करें।
5. दूसरे स्तंभ के लिए [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) का उपयोग करें।
6. संशोधित प्रस्तुति को सहेजें।

उदाहरण को `table.pptx` की आवश्यकता है जिसमें पहली स्लाइड पर पहली आकृति के रूप में तालिका और कम से कम दो स्तंभ हों। यह पहले स्तंभ पर 25‑पॉइंट पाठ, दाएँ संरेखण, और 20‑पॉइंट दाएँ पैराग्राफ मार्जिन लागू करता है, फिर दूसरे स्तंभ में ऊर्ध्वाधर पाठ सेट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **तालिका शैली गुण प्राप्त करें**

[getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) मेथड का उपयोग करके तालिका पर लागू प्रीसेट प्राप्त करें और उसे दूसरी तालिका पर पुन: उपयोग करें। यह व्यक्तिगत सेल स्वरूपण ओवरराइड की बजाय प्रीसेट की पहचान करता है।

उदाहरण एक तालिका बनाता है, [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) लागू करता है, और प्रीसेट को वापस पढ़ता है। यह `DarkStyle1` के समकक्ष पूर्णांक मान प्रिंट करता है और तालिका को `table.pptx` में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनाई गई तालिका पर PowerPoint थीम/शैलियों को लागू कर सकता हूँ?**

हाँ। तालिका स्लाइड/लेआउट/मास्टर थीम को वंशागत रूप से प्राप्त करती है, और आप उस थीम के ऊपर फ़िल, बॉर्डर, और पाठ रंगों को अभी भी ओवरराइड कर सकते हैं।

**क्या मैं Excel की तरह तालिका पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides की तालिकाओं में अंतर्निहित सॉर्टिंग या फ़िल्टर नहीं होते। पहले डेटा को मेमोरी में सॉर्ट करें, फिर क्रम के अनुसार तालिका पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) स्तंभ रख सकते हूँ जबकि कुछ विशेष सेल्स पर कस्टम रंग बनाए रखें?**

हाँ। बैंडेड स्तंभ सक्रिय करें, फिर विशिष्ट सेल्स को लोकल फ़ॉर्मेटिंग से ओवरराइड करें; सेल‑स्तर का फ़ॉर्मेटिंग तालिका शैली पर प्राथमिकता लेता है।