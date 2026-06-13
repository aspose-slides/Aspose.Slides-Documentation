---
title: "Android में PowerPoint तालिकाओं में पंक्तियों और स्तंभों का प्रबंधन"
linktitle: "पंक्तियाँ और स्तंभ"
type: docs
weight: 20
url: /hi/androidjava/manage-rows-and-columns/
keywords:
- "तालिका पंक्ति"
- "तालिका स्तंभ"
- "पहली पंक्ति"
- "तालिका शीर्षक"
- "पंक्ति क्लोन"
- "स्तंभ क्लोन"
- "पंक्ति कॉपी"
- "स्तंभ कॉपी"
- "पंक्ति हटाएँ"
- "स्तंभ हटाएँ"
- "पंक्ति टेक्स्ट स्वरूपण"
- "स्तंभ टेक्स्ट स्वरूपण"
- "तालिका शैली"
- "PowerPoint"
- "प्रस्तुति"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Java के माध्यम से Android के लिए Aspose.Slides के साथ PowerPoint में तालिका पंक्तियों और स्तंभों का प्रबंधन करें और प्रस्तुति संपादन और डेटा अपडेट को तेज़ बनाएं।"
---
## **परिचय**

PowerPoint प्रस्तुति में तालिका की पंक्तियों और स्तंभों को प्रबंधित करने के लिए, Aspose.Slides [Table](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) इंटरफ़ेस और कई अन्य प्रकार प्रदान करता है।

## **पहली पंक्ति को शीर्षक के रूप में सेट करें**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) class and load the presentation.
2. Get a slide's reference through its index.
3. Create an [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object and set it to null.
4. Iterate through all [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) objects to find the relevant table.
5. Set the table's first row as its header.

This Java code shows you how to set a table's first row as its header:

```java
// Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation("table.pptx");
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx को आरंभ करता है
    ITable tbl = null;

    // आकारों (shapes) पर इटररेट करता है और तालिका का संदर्भ सेट करता है
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //पहली पंक्ति को उसके शीर्षक (हेडर) के रूप में सेट करता है
            tbl.setFirstRow(true);
        }
    }
    
    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेबल पंक्ति या स्तम्भ को क्लोन करें**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) class and load the presentation,
2. Get a slide's reference through its index.
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object to the slide through the [addTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) method.
6. Clone the table row.
7. Clone the table column.
8. Save the modified presentation.

This Java code shows you how to clone a PowerPoint table's row or column:

```java
 // Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation("Test.pptx");
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // कॉलम चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // स्लाइड में एक तालिका आकार जोड़ता है
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // पंक्ति 1, कोशिका 1 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // पंक्ति 1, कोशिका 2 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // तालिका के अंत में पंक्ति 1 को क्लोन करता है
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // पंक्ति 2, कोशिका 1 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // पंक्ति 2, कोशिका 2 में कुछ टेक्स्ट जोड़ता है
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // पंक्ति 2 को तालिका की 4थी पंक्ति के रूप में क्लोन करता है
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // पहले कॉलम को अंत में क्लोन करता है
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // दूसरे कॉलम को 4थी कॉलम इंडेक्स पर क्लोन करता है
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेबल से पंक्ति या स्तम्भ हटाएँ**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) class and load the presentation,
2. Get a slide's reference through its index.
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object to the slide through the [addTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) method.
6. Remove the table row.
7. Remove the table column.
8. Save the modified presentation.

This Java code shows you how to remove a row or column from a table:

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

## **टेबल पंक्ति स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) class and load the presentation,
2. Get a slide's reference through its index.
3. Access the relevant [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object from the slide.
4. Set the first-row cells' [setFontHeight(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Set the first-row cells' [setAlignment(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) and [setMarginRight(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Set the second-row cells' [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Save the modified presentation.

This Java code demonstrates the operation.

```java
// Presentation क्लास का एक उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // मान लेते हैं कि पहली स्लाइड पर पहला आकार एक तालिका है
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // पहली पंक्ति की कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // पहली पंक्ति की कोशिकाओं का टेक्स्ट संरेखण और दाएँ मार्जिन सेट करता है
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // दूसरी पंक्ति की कोशिकाओं का टेक्स्ट वर्टिकल टाइप सेट करता है
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेबल स्तम्भ स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) class and load the presentation,
2. Get a slide's reference through its index.
3. Access the relevant [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object from the slide.
4. Set the first-column cells' [setFontHeight(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Set the first-column cells' [setAlignment(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) and [setMarginRight(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Set the second-column cells' [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Save the modified presentation.

This Java code demonstrates the operation:

```java
// Presentation क्लास का एक उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // मान लेते हैं कि पहली स्लाइड पर पहला आकार एक तालिका है
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // पहले कॉलम की कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // पहले कॉलम की कोशिकाओं का टेक्स्ट संरेखण और दायाँ मार्जिन एक ही कॉल में सेट करता है
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // दूसरे कॉलम की कोशिकाओं का टेक्स्ट वर्टिकल प्रकार सेट करता है
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेबल शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के लिए शैली गुण पुनः प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह Java कोड दिखाता है कि तालिका प्रीसेट शैली से शैली गुण कैसे प्राप्त करें:

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

**क्या मैं पहले से बनाई गई टेबल पर PowerPoint थीम/स्टाइल लागू कर सकता हूँ?**

हां। टेबल स्लाइड/लेआउट/मास्टर थीम को विरासत में लेती है, और आप उस थीम के ऊपर फ़िल, बॉर्डर और टेक्स्ट रंगों को ओवरराइड कर सकते हैं।

**क्या मैं टेबल की पंक्तियों को Excel की तरह सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides टेबल में अंतर्निहित सॉर्टिंग या फ़िल्टर नहीं हैं। पहले अपने डेटा को मेमोरी में सॉर्ट करें, फिर उस क्रम में टेबल पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) कॉलम रख सकते हुए विशिष्ट कोशिकाओं पर कस्टम रंग रख सकता हूँ?**

हां। बैंडेड कॉलम को सक्रिय करें, फिर विशिष्ट कोशिकाओं को स्थानीय फ़ॉर्मेटिंग के साथ ओवरराइड करें; सेल-स्तर की फ़ॉर्मेटिंग टेबल शैली पर प्राथमिकता लेती है।