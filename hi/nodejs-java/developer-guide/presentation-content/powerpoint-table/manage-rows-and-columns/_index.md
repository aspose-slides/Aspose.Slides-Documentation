---
title: PowerPoint तालिकाओं में पंक्तियों और कॉलमों को JavaScript के साथ प्रबंधित करें
linktitle: पंक्तियाँ और कॉलम
type: docs
weight: 20
url: /hi/nodejs-java/manage-rows-and-columns/
keywords:
- तालिका पंक्ति
- तालिका कॉलम
- पहली पंक्ति
- तालिका हेडर
- पंक्ति क्लोन
- कॉलम क्लोन
- पंक्ति कॉपी
- कॉलम कॉपी
- पंक्ति हटाएँ
- कॉलम हटाएँ
- पंक्ति पाठ फ़ॉर्मेटिंग
- कॉलम पाठ फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Java और Aspose.Slides for Node.js के माध्यम से JavaScript के साथ PowerPoint में तालिका पंक्तियों और कॉलमों का प्रबंधन करें और प्रस्तुति संपादन एवं डेटा अपडेट को तेज़ बनाएँ।"
---
## **परिचय**

Aspose.Slides for Node.js via Java आपको PowerPoint प्रेजेंटेशन में टेबल संरचना और स्वरूपण को [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) क्लास के माध्यम से प्रबंधित करने देता है। आप हेडर पंक्ति निर्धारित कर सकते हैं, पंक्तियाँ और कॉलम क्लोन या हटाकर सकते हैं, और पूरी पंक्ति या कॉलम पर टेक्स्ट फ़ॉर्मेटिंग लागू कर सकते हैं।

यह लेख इन संचालन को JavaScript उदाहरणों के साथ समझाता है। यह यह भी दिखाता है कि टेबल की शैली प्रीसेट को कैसे प्राप्त करें ताकि आप इसे पुनः उपयोग कर सकें। टेबल पंक्ति और कॉलम इंडेक्स शून्य-आधारित होते हैं।

## **पंक्ति की ऊँचाई नियंत्रित करें**

पंक्ति की न्यूनतम ऊँचाई को पॉइंट में सेट करने के लिए [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) का उपयोग करें। यह एक निचली सीमा है, न कि एक निश्चित ऊँचाई। [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) वास्तविक ऊँचाई लौटाता है। पंक्ति को [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--) के माध्यम से एक्सेस करें।

उदाहरण [row-height-input.pptx](row-height-input.pptx) लोड करता है, जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक टेबल है। इसकी पहली पंक्ति 70 पॉइंट से शुरू होती है। सेल्स 18‑पॉइंट Arial टेक्स्ट, रैपिंग, और 6‑पॉइंट ऊपर और नीचे मार्जिन का उपयोग करती हैं; दूसरे कॉलम में लंबा टेक्स्ट कई लाइनों में रैप हो जाता है। उदाहरण न्यूनतम को 100 पॉइंट तक बढ़ाता है, फिर इसे 20 पॉइंट तक घटाता है, प्रत्येक परिवर्तन के बाद वास्तविक ऊँचाई प्रिंट करता है, और दोनों परिणाम सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

प्रदान किए गए प्रेजेंटेशन में, न्यूनतम बढ़ाने से पंक्ति में जगह जोड़ती है। इसे घटाने से वह अतिरिक्त जगह हटती है, लेकिन वास्तविक ऊँचाई 20 पॉइंट से अधिक रहती है क्योंकि टेक्स्ट और सेल मार्जिन को अधिक जगह की आवश्यकता होती है। केवल न्यूनतम को घटाने से पंक्ति को उसके सामग्री द्वारा आवश्यक जगह से कम नहीं किया जा सकता।

कई कारक वास्तविक ऊँचाई को प्रभावित करते हैं:

- **टेक्स्ट और फ़ॉन्ट आकार:** लंबा टेक्स्ट, स्पष्ट लाइन ब्रेक, या बड़ा फ़ॉन्ट अधिक ऊर्ध्वाधर स्थान की आवश्यकता पैदा कर सकता है।
- **रैपिंग और कॉलम चौड़ाई:** रैपिंग सक्रिय होने पर, [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) के साथ कॉलम चौड़ाई कम करने से अधिक लाइनों का निर्माण हो सकता है। एक चौड़ी कॉलम ऊर्ध्वाधर रूप से आवश्यक स्थान को कम कर सकती है।
- **सेल मार्जिन:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) और [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) ऊर्ध्वाधर जगह जोड़ते हैं। [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) और [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) टेक्स्ट के लिए उपलब्ध चौड़ाई घटाते हैं और अतिरिक्त रैपिंग का कारण बन सकते हैं।

इस टेबल में मर्ज किए गए सेल नहीं हैं, इसलिए वह सेल जो सबसे अधिक ऊर्ध्वाधर जगह चाहिए, पूरी पंक्ति के लिए सामग्री‑प्रेरित निचली सीमा निर्धारित करता है। पंक्ति को छोटा करने के लिए आपको टेक्स्ट को छोटा करना, फ़ॉन्ट आकार या मार्जिन घटाना, या कॉलम को चौड़ा करना पड़ सकता है।

नीचे की छवियाँ समान स्केल पर उसी टेबल को दर्शाती हैं। प्रदर्शित परिणामों में वास्तविक ऊँचाई क्रमशः 70, 100 और 55.2 पॉइंट थीं: अंतिम पंक्ति अपने 20‑पॉइंट न्यूनतम से ऊँची बनी रही। सटीक टेक्स्ट माप आपके वातावरण में उपलब्ध फ़ॉन्ट के आधार पर बदल सकते हैं। सहेजे गए परिणाम डाउनलोड करें: [increased minimum](row-height-increased.pptx) और [decreased minimum](row-height-decreased.pptx).

| मूल: न्यूनतम 70 pt, वास्तविक 70 pt | बढ़ाया: न्यूनतम 100 pt, वास्तविक 100 pt | घटाया: न्यूनतम 20 pt, वास्तविक 55.2 pt |
| --- | --- | --- |
| ![70‑पॉइंट पहली पंक्ति वाली मूल तालिका।](row-height-before.png) | ![पहली पंक्ति का न्यूनतम 100 पॉइंट बढ़ाने के बाद तालिका।](row-height-increased.png) | ![पहली पंक्ति का न्यूनतम 20 पॉइंट घटाने के बाद तालिका; रैप किया हुआ टेक्स्ट पंक्ति को न्यूनतम से ऊँचा रखता है।](row-height-decreased.png) |

## **पहली पंक्ति को हेडर के रूप में सेट करें**

पहली पंक्ति को हेडर फ़ॉर्मेटिंग के लिए चिह्नित करने के लिए [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) मेथड का उपयोग करें। उसका रूप टेबल पर लागू शैली पर निर्भर करता है।

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास के साथ प्रेजेंटेशन लोड करें।
2. पहली स्लाइड तक पहुंचें।
3. स्लाइड पर पहली आकृति के रूप में संग्रहीत टेबल तक पहुंचें।
4. उसकी पहली पंक्ति के लिए हेडर फ़ॉर्मेटिंग सक्षम करें।
5. संशोधित प्रेजेंटेशन सहेजें।

उदाहरण को `table.pptx` की आवश्यकता होती है जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक टेबल हो। यह पहली पंक्ति के लिए हेडर फ़ॉर्मेटिंग सक्षम करता है और `First_row_header.pptx` सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेबल पंक्ति या कॉलम क्लोन करें**

पंक्तियों या कॉलमों को क्लोन करके उनकी सामग्री और स्वरूपण को पुन: उपयोग करें। आप एक कॉपी को टेबल के अंत में जोड़ सकते हैं या इसे किसी विशिष्ट स्थान पर सम्मिलित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास के साथ प्रेजेंटेशन लोड करें।
2. पहली स्लाइड तक पहुंचें।
3. कॉलम चौड़ाई और पंक्ति ऊँचाई निर्धारित करें।
4. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) मेथड के साथ टेबल जोड़ें।
5. आवश्यक पंक्तियों को क्लोन करें।
6. आवश्यक कॉलमों को क्लोन करें।
7. संशोधित प्रेजेंटेशन सहेजें।

उदाहरण को `Test.pptx` की आवश्यकता होती है जिसमें कम से कम एक स्लाइड हो। यह तीन कॉलम और पाँच पंक्तियों वाला टेबल बनाता है, बिंदुओं में आयाम निर्दिष्ट करता है। यह पहली पंक्ति और कॉलम की प्रतियाँ अंत में जोड़ता है, फिर दूसरी पंक्ति और कॉलम की प्रतियों को इंडेक्स 3 (चौथा स्थान) पर सम्मिलित करता है। resulting टेबल में सात पंक्तियाँ और पाँच कॉलम होते हैं। `false` तर्क निकटवर्ती मर्ज किए गए पंक्तियों या कॉलमों में क्लोनिंग को असक्षम करता है; इस टेबल में कोई मर्जेड सेल नहीं है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेबल से पंक्ति या कॉलम हटाएँ**

टेबल में अब आवश्यक न रहने वाली पंक्तियों या कॉलमों को हटाएँ। किसी आइटम को हटाने से उसके बाद आने वाली पंक्तियों या कॉलमों के इंडेक्स शिफ़्ट होते हैं।

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास के साथ प्रेजेंटेशन बनाएं।
2. पहली स्लाइड तक पहुंचें।
3. कॉलम चौड़ाई और पंक्ति ऊँचाई निर्धारित करें।
4. [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) मेथड के साथ टेबल जोड़ें।
5. दूसरी पंक्ति और दूसरी कॉलम हटाएँ।
6. संशोधित प्रेजेंटेशन सहेजें।

यह उदाहरण एक तीन‑बाय‑तीन टेबल बनाता है और इंडेक्स 1 पर पंक्ति और कॉलम हटाता है, जिससे `TestTable_out.pptx` में दो‑बाय‑दो टेबल बचता है। आयाम बिंदुओं में हैं। `false` तर्क निकटवर्ती मर्ज किए गए पंक्तियों या कॉलमों के हटाने को असक्षम करता है; इस टेबल में कोई मर्जेड सेल नहीं है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेबल पंक्ति स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

पूरी पंक्ति पर टेक्स्ट फ़ॉर्मेटिंग लागू करें ताकि उसकी सभी सेल्स सुसंगत रहें। आप फ़ॉन्ट विशेषताओं, पैराग्राफ फ़ॉर्मेटिंग और टेक्स्ट दिशा को प्रत्येक सेल को अलग‑अलग फ़ॉर्मेट किए बिना सेट कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास के साथ प्रेजेंटेशन लोड करें।
2. पहली स्लाइड पर टेबल तक पहुंचें।
3. पहली पंक्ति के लिए [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) का उपयोग करें।
4. पहली पंक्ति के लिए [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) और [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) का उपयोग करें।
5. दूसरी पंक्ति के लिए [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) का उपयोग करें।
6. संशोधित प्रेजेंटेशन सहेजें।

उदाहरण को `table.pptx` की आवश्यकता होती है जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक टेबल हो और कम से कम दो पंक्तियाँ हों। यह पहली पंक्ति पर 25‑पॉइंट टेक्स्ट, दाएँ संरेखण, और 20‑पॉइंट दाएँ पैराग्राफ़ मार्जिन लागू करता है, फिर दूसरी पंक्ति पर वर्टिकल टेक्स्ट सेट करता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेबल कॉलम स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

पूरे कॉलम पर टेक्स्ट फ़ॉर्मेटिंग लागू करें ताकि उसकी सभी सेल्स सुसंगत रहें। आप फ़ॉन्ट विशेषताओं, पैराग्राफ फ़ॉर्मेटिंग और टेक्स्ट दिशा को प्रत्येक सेल को अलग‑अलग फ़ॉर्मेट किए बिना सेट कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास के साथ प्रेजेंटेशन लोड करें।
2. पहली स्लाइड पर टेबल तक पहुंचें।
3. पहली कॉलम के लिए [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) का उपयोग करें।
4. पहली कॉलम के लिए [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) और [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) का उपयोग करें।
5. दूसरी कॉलम के लिए [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) का उपयोग करें।
6. संशोधित प्रेजेंटेशन सहेजें।

उदाहरण को `table.pptx` की आवश्यकता होती है जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक टेबल हो और कम से कम दो कॉलम हों। यह पहली कॉलम पर 25‑पॉइंट टेक्स्ट, दाएँ संरेखण, और 20‑पॉइंट दाएँ पैराग्राफ़ मार्जिन लागू करता है, फिर दूसरी कॉलम पर वर्टिकल टेक्स्ट सेट करता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेबल शैली गुण प्राप्त करें**

टेबल पर लागू प्रीसेट को प्राप्त करने और उसे किसी अन्य टेबल पर पुनः उपयोग करने के लिए [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) मेथड का उपयोग करें। यह व्यक्तिगत सेल फ़ॉर्मेटिंग ओवरराइड के बजाय प्रीसेट की पहचान करता है।

उदाहरण टेबल बनाता है, [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) लागू करता है, और प्रीसेट को वापस पढ़ता है। यह `DarkStyle1` के अनुरूप पूर्णांक मान प्रिंट करता है और टेबल को `table.pptx` में सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**क्या मैं पहले से बनी टेबल पर PowerPoint थीम/स्टाइल लागू कर सकता हूँ?**

हां। टेबल स्लाइड/लेआउट/मास्टर थीम को विरासत में प्राप्त करती है, और आप उस थीम के ऊपर फिल, बॉर्डर और टेक्स्ट रंगों को ओवरराइड कर सकते हैं।

**क्या मैं Excel की तरह टेबल पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides टेबल में बिल्ट‑इन सॉर्टिंग या फ़िल्टर नहीं हैं। पहले मेमोरी में डेटा सॉर्ट करें, फिर उस क्रम में टेबल पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) कॉलम रख सकता हूँ जबकि विशिष्ट सेल्स पर कस्टम रंग बनाए रखूँ?**

हां। बैंडेड कॉलम चालू करें, फिर विशिष्ट सेल्स को स्थानीय फ़ॉर्मेटिंग से ओवरराइड करें; सेल‑स्तर फ़ॉर्मेटिंग टेबल स्टाइल पर प्राथमिकता रखती है।

{{}}