---
title: Java का उपयोग करके PowerPoint तालिकाओं में पंक्तियों और स्तंभों का प्रबंधन
linktitle: पंक्तियाँ और स्तंभ
type: docs
weight: 20
url: /hi/java/manage-rows-and-columns/
keywords:
- तालिका पंक्ति
- तालिका स्तंभ
- पहली पंक्ति
- तालिका हेडर
- पंक्ति क्लोन
- स्तंभ क्लोन
- पंक्ति कॉपी
- स्तंभ कॉपी
- पंक्ति हटाएँ
- स्तंभ हटाएँ
- पंक्ति टेक्स्ट फ़ॉर्मेटिंग
- स्तंभ टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint में तालिका पंक्तियों और स्तंभों का प्रबंधन करें और प्रस्तुति संपादन तथा डेटा अपडेट को तेज़ करें।"
---
## **परिचय**

PowerPoint प्रस्तुति में तालिका की पंक्तियों और स्तंभों का प्रबंधन करने के लिए, Aspose.Slides [Table](https://reference.aspose.com/slides/hi/java/com.aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) इंटरफ़ेस, और कई अन्य प्रकार प्रदान करता है। 

## **पहली पंक्ति को हेडर रूप में सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ और प्रस्तुति लोड करें। 
2. उसकी अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) वस्तु बनाएँ और उसे null सेट करें। 
4. संबंधित तालिका खोजने के लिए सभी [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) वस्तुओं पर पुनरावृति करें। 
5. तालिका की पहली पंक्ति को उसके हेडर के रूप में सेट करें। 

यह Java कोड दिखाता है कि कैसे तालिका की पहली पंक्ति को हेडर सेट करें:

```java
// Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation("table.pptx");
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx को प्रारंभ करता है
    ITable tbl = null;

    // शेप्स के माध्यम से इटरॉरेट करता है और तालिका का संदर्भ सेट करता है
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //तालिका की पहली पंक्ति को उसके हेडर के रूप में सेट करता है
            tbl.setFirstRow(true);
        }
    }
    
    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका की पंक्ति या स्तंभ को क्लोन करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ और प्रस्तुति लोड करें, 
2. उसकी अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. `columnWidth` का एक एरे परिभाषित करें। 
4. `rowHeight` का एक एरे परिभाषित करें। 
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) मेथड के माध्यम से एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) वस्तु जोड़ें। 
6. तालिका पंक्ति को क्लोन करें। 
7. तालिका स्तंभ को क्लोन करें। 
8. संशोधित प्रस्तुति सहेजें। 

यह Java कोड दिखाता है कि कैसे PowerPoint तालिका की पंक्ति या स्तंभ को क्लोन करें:

```java
 // Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation("Test.pptx");
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // स्तंभों को चौड़ाई और पंक्तियों को ऊँचाई के साथ परिभाषित करता है
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // स्लाइड में तालिका आकार जोड़ता है
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // पंक्ति 1 सेल 1 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // पंक्ति 1 सेल 2 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // तालिका के अंत में पंक्ति 1 को क्लोन करता है
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // पंक्ति 2 सेल 1 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // पंक्ति 2 सेल 2 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // तालिका की 4थी पंक्ति के रूप में पंक्ति 2 को क्लोन करता है
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // अंत में पहला स्तंभ क्लोन करता है
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // 4थी स्तंभ इंडेक्स पर दूसरा स्तंभ क्लोन करता है
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका से पंक्ति या स्तंभ हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ और प्रस्तुति लोड करें, 
2. उसकी अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. `columnWidth` का एक एरे परिभाषित करें। 
4. `rowHeight` का एक एरे परिभाषित करें। 
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) मेथड के माध्यम से एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) वस्तु जोड़ें। 
6. तालिका पंक्ति को हटाएँ। 
7. तालिका स्तंभ को हटाएँ। 
8. संशोधित प्रस्तुति सहेजें। 

यह Java कोड दिखाता है कि कैसे तालिका से पंक्ति या स्तंभ हटाएँ:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका पंक्ति स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ और प्रस्तुति लोड करें, 
2. उसकी अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. स्लाइड से संबंधित [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) वस्तु तक पहुँचें। 
4. पहली‑पंक्ति के सेल्स के लिए [setFontHeight(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) सेट करें। 
5. पहली‑पंक्ति के सेल्स के लिए [setAlignment(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) सेट करें। 
6. दूसरी‑पंक्ति के सेल्स के लिए [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) सेट करें। 
7. संशोधित प्रस्तुति सहेजें। 

यह Java कोड इस ऑपरेशन को दर्शाता है।

```java
// Presentation क्लास का एक उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // मान लेते हैं कि पहली स्लाइड पर पहला आकार एक तालिका है
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // पहली पंक्ति के सेल्स का फ़ॉन्ट ऊँचाई सेट करता है
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // पहली पंक्ति के सेल्स का टेक्स्ट अलाइनमेंट और दायाँ मार्जिन सेट करता है
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // दूसरी पंक्ति के सेल्स का टेक्स्ट वर्टिकल प्रकार सेट करता है
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका स्तंभ स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएँ और प्रस्तुति लोड करें, 
2. उसकी अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. स्लाइड से संबंधित [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) वस्तु तक पहुँचें। 
4. पहली‑स्तंभ के सेल्स के लिए [setFontHeight(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) सेट करें। 
5. पहली‑स्तंभ के सेल्स के लिए [setAlignment(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) सेट करें। 
6. दूसरी‑स्तंभ के सेल्स के लिए [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) सेट करें। 
7. संशोधित प्रस्तुति सहेजें। 

यह Java कोड इस ऑपरेशन को दर्शाता है: 

```java
// Presentation क्लास का एक उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // मान लीजिए कि पहली स्लाइड पर पहला आकार एक तालिका है
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // पहले स्तंभ के सेल्स की फ़ॉन्ट ऊँचाई सेट करता है
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // एक कॉल में पहले स्तंभ के सेल्स का टेक्स्ट एलाइनमेंट और दायाँ मार्जिन सेट करता है
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // दूसरे स्तंभ के सेल्स का टेक्स्ट वर्टिकल प्रकार सेट करता है
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के शैली गुण प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह Java कोड दिखाता है कि कैसे तालिका प्रीसेट शैली से शैली गुण प्राप्त करें:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // डिफ़ॉल्ट शैली प्रीसेट थीम बदलें
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनाई गई तालिका पर PowerPoint थीम/स्टाइल लागू कर सकता हूँ?**

हाँ। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में प्राप्त करती है, और आप उस थीम के ऊपर फ़िल, बॉर्डर और टेक्स्ट रंगों को ओवरराइड भी कर सकते हैं।

**क्या मैं Excel की तरह तालिका की पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में बिल्ट‑इन सॉर्टिंग या फ़िल्टर नहीं होते। पहले मेमोरी में डेटा को सॉर्ट करें, फिर उसी क्रम में तालिका की पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) स्तंभ रख सकते हैं जबकि विशिष्ट कोशिकाओं में कस्टम रंग बनाए रखें?**

हाँ। बैंडेड कॉलम को चालू करें, फिर विशिष्ट कोशिकाओं को स्थानीय फ़ॉर्मेटिंग से ओवरराइड करें; सेल‑लेवल फ़ॉर्मेटिंग तालिका शैली पर प्राथमिकता लेती है।