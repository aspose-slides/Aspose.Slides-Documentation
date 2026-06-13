---
title: PowerPoint तालिकाओं में पंक्तियों और स्तंभों को JavaScript द्वारा प्रबंधित करें
linktitle: पंक्तियाँ और स्तंभ
type: docs
weight: 20
url: /hi/nodejs-java/manage-rows-and-columns/
keywords:
- टेबल पंक्ति
- टेबल स्तंभ
- पहली पंक्ति
- टेबल हेडर
- पंक्ति क्लोन
- स्तंभ क्लोन
- पंक्ति कॉपी
- स्तंभ कॉपी
- पंक्ति हटाएँ
- स्तंभ हटाएँ
- पंक्ति टेक्स्ट स्वरूपण
- स्तंभ टेक्स्ट स्वरूपण
- टेबल शैली
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js के माध्यम से PowerPoint में तालिका की पंक्तियों और स्तंभों को प्रबंधित करें और प्रस्तुति संपादन तथा डेटा अपडेट को तेज़ करें।"
---
## **परिचय**

PowerPoint प्रस्तुति में तालिका की पंक्तियों और स्तंभों को प्रबंधित करने के लिए, Aspose.Slides [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/) क्लास और अन्य प्रकार प्रदान करता है।

## **पहली पंक्ति को हेडर के रूप में सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं और प्रस्तुति लोड करें।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट बनाएं और उसे null सेट करें।
4. सभी [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) ऑब्जेक्ट्स पर इटरैट करें ताकि संबंधित तालिका मिल सके।
5. तालिका की पहली पंक्ति को उसके हेडर के रूप में सेट करें। 

यह JavaScript कोड दिखाता है कि कैसे तालिका की पहली पंक्ति को हेडर सेट किया जाता है:

```javascript
// Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // पहली स्लाइड तक पहुंचता है
    var sld = pres.getSlides().get_Item(0);
    // null TableEx को प्रारंभ करता है
    var tbl = null;
    // शेप्स में इटरैट करता है और तालिका के लिए संदर्भ सेट करता है
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // तालिका की पहली पंक्ति को हेडर के रूप में सेट करता है
            tbl.setFirstRow(true);
        }
    }
    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **तालिका की पंक्ति या स्तंभ को क्लोन करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं और प्रस्तुति लोड करें,
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. एक `columnWidth` एरे निर्धारित करें।
4. एक `rowHeight` एरे निर्धारित करें।
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) मेथड के माध्यम से एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट जोड़ें।
6. तालिका की पंक्ति को क्लोन करें।
7. तालिका के स्तंभ को क्लोन करें।
8. संशोधित प्रस्तुति सहेजें।

यह JavaScript कोड दिखाता है कि कैसे PowerPoint तालिका की पंक्ति या स्तंभ को क्लोन किया जाता है:

```javascript
// Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // पहली स्लाइड तक पहुंचता है
    var sld = pres.getSlides().get_Item(0);
    // कॉलमों को चौड़ाई और पंक्तियों को ऊंचाई के साथ परिभाषित करता है
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // स्लाइड में एक तालिका शेप जोड़ता है
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // पंक्ति 1 कोशिका 1 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // पंक्ति 1 कोशिका 2 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // तालिका के अंत में पंक्ति 1 को क्लोन करता है
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // पंक्ति 2 कोशिका 1 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // पंक्ति 2 कोशिका 2 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // पंक्ति 2 को तालिका की 4थी पंक्ति के रूप में क्लोन करता है
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // पहले स्तंभ को अंत में क्लोन करता है
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // दूसरे स्तंभ को 4थे स्तंभ इंडेक्स पर क्लोन करता है
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका से पंक्ति या स्तंभ हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं और प्रस्तुति लोड करें,
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. एक `columnWidth` एरे निर्धारित करें।
4. एक `rowHeight` एरे निर्धारित करें।
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) मेथड के माध्यम से एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट जोड़ें।
6. तालिका की पंक्ति को हटाएँ।
7. तालिका के स्तंभ को हटाएँ।
8. संशोधित प्रस्तुति सहेजें। 

यह JavaScript कोड दिखाता है कि कैसे तालिका से पंक्ति या स्तंभ हटाया जाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका पंक्ति स्तर पर पाठ स्वरूपण सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं और प्रस्तुति लोड करें,
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. स्लाइड से संबंधित [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट तक पहुंचें।
4. पहली पंक्ति की कोशिकाओं के [setFontHeight(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) को सेट करें।
5. पहली पंक्ति की कोशिकाओं के [setAlignment(int value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) को सेट करें।
6. दूसरी पंक्ति की कोशिकाओं के [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) को सेट करें।
7. संशोधित प्रस्तुति सहेजें।

यह JavaScript कोड इस ऑपरेशन को दर्शाता है:

```javascript
// Presentation क्लास का एक उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // मान लें कि पहली स्लाइड की पहली आकृति एक तालिका है
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // पहली पंक्ति की कोशिकाओं का फ़ॉन्ट ऊँचाई सेट करता है
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // पहली पंक्ति की कोशिकाओं का टेक्स्ट संरेखण और दायाँ मार्जिन सेट करता है
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // दूसरी पंक्ति की कोशिकाओं का टेक्स्ट वर्टिकल प्रकार सेट करता है
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका स्तंभ स्तर पर पाठ स्वरूपण सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं और प्रस्तुति लोड करें,
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. स्लाइड से संबंधित [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट तक पहुंचें।
4. पहला‑स्तंभ की कोशिकाओं के [setFontHeight(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) को सेट करें।
5. पहला‑स्तंभ की कोशिकाओं के [setAlignment(int value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) को सेट करें।
6. दूसरा‑स्तंभ की कोशिकाओं के [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) को सेट करें।
7. संशोधित प्रस्तुति सहेजें। 

यह JavaScript कोड इस ऑपरेशन को दर्शाता है:

```javascript
// Presentation क्लास का एक उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // मान लें कि पहली स्लाइड की पहली आकृति एक टेबल है
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // पहली कॉलम की कोशिकाओं का फ़ॉन्ट ऊँचाई सेट करता है
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // पहली कॉलम की कोशिकाओं का टेक्स्ट संरेखण और दायाँ मार्जिन एक ही कॉल में सेट करता है
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // दूसरी कॉलम की कोशिकाओं का टेक्स्ट वर्टिकल प्रकार सेट करता है
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के लिए शैली गुण प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह JavaScript कोड दिखाता है कि कैसे तालिका प्रीसेट शैली से शैली गुण प्राप्त किए जाते हैं:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// डिफ़ॉल्ट शैली प्रीसेट थीम बदलें
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनाई गई तालिका पर PowerPoint थीम/शैलियाँ लागू कर सकता हूँ?**

हाँ। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में प्राप्त करती है, और आप फिर भी उस थीम के ऊपर फ़िल, बॉर्डर और पाठ रंगों को ओवरराइड कर सकते हैं।

**क्या मैं तालिका की पंक्तियों को Excel की तरह क्रमबद्ध कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में अंतर्निहित सॉर्टिंग या फ़िल्टर नहीं होते हैं। पहले अपने डेटा को मेमोरी में क्रमबद्ध करें, फिर उस क्रम में तालिका की पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) स्तंभ रख सकते हुए विशिष्ट कोशिकाओं पर कस्टम रंग रख सकता हूँ?**

हाँ। बैंडेड स्तंभ सक्रिय करें, फिर विशिष्ट कोशिकाओं को स्थानीय स्वरूपण से ओवरराइड करें; कोशिका-स्तर का स्वरूपण तालिका शैली पर प्राथमिकता लेता है।