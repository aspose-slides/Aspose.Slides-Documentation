---
title: Android पर प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/androidjava/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- आस्पेक्ट अनुपात
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सरल बनाने के लिए सरल Java कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में एक तालिका जानकारी को प्रदर्शित करने और अभिव्यक्त करने का एक प्रभावी तरीका है। सेलों के ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी सीधी‑सादी और समझने में आसान होती है।

Aspose.Slides प्रदान करता है [Table](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Table) क्लास, [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार जिससे आप विभिन्न प्रकार की प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरू से एक तालिका बनाएं**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) class.  
2. Get a slide's reference through its index.  
3. `columnWidth` की एक एरे परिभाषित करें।  
4. `rowHeight` की एक एरे परिभाषित करें।  
5. Add an [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object to the slide through the [addTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) method.  
6. Iterate through each [ICell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/) to apply formatting to the top, bottom, right, and left borders.  
7. तालिका की पहली पंक्ति के पहले दो सेल्स को मर्ज करें।  
8. एक [ICell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) तक पहुंचें।  
9. [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।  
10. संशोधित प्रस्तुति को सहेजें।

This Java code shows you how to create a table in a presentation:

```java
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // स्तंभों को चौड़ाइयों के साथ और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // स्लाइड में तालिका का आकार जोड़ता है
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // पंक्ति 1 की कोशिकाएँ 1 और 2 को मिलाता है
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // मर्ज की गई सेल में कुछ टेक्स्ट जोड़ता है
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **मानक तालिका में क्रमांकन**

मानक तालिका में, कोशिकाओं का क्रमांकन सरल और शून्य‑आधारित होता है। तालिका की पहली कोशिका का इंडेक्स 0,0 (स्तंभ 0, पंक्ति 0) होता है।

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका की कोशिकाओं को इस प्रकार क्रमांकित किया जाता है:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This Java code shows you how to specify the numbering for cells in a table:

```java
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // स्तंभों को चौड़ाइयों के साथ और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में तालिका का आकार जोड़ता है
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **मौजूदा तालिका तक पहुँचें**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) class.  
2. इंडेक्स के द्वारा उस स्लाइड का संदर्भ प्राप्त करें जिसमें तालिका है।  
3. Create an [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object and set it to null.  
4. Iterate through all [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) objects till the table is found.  

   यदि आपको संदेह है कि जिस स्लाइड को आप देख रहे हैं उसमें केवल एक तालिका है, तो आप आसानी से उसकी सभी शैप्स को जांच सकते हैं। जब कोई शैप तालिका के रूप में पहचाना जाता है, तो आप इसे [Table](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Table) ऑब्जेक्ट में टाइपकास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई तालिकाएँ हैं, तो आपको आवश्यक तालिका को उसके [setAlternativeText(String value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) के माध्यम से खोजना बेहतर रहेगा।  

5. Use the [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object to work with the table. In the example below, we added a new row to the table.  
6. संशोधित प्रस्तुति को सहेजें।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx को इनिशियलाइज़ करता है
    ITable tbl = null;

    // शैप्स के माध्यम से इटरेट करता है और मिलने वाली तालिका का रेफ़रेंस सेट करता है
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // दूसरी पंक्ति के पहले स्तंभ के लिए टेक्स्ट सेट करता है
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // संशोधित प्रस्तुति को डिस्क पर सहेजता है
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका में टेक्स्ट को संरेखित करें**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) class.  
2. Get a slide's reference through its index.  
3. Add an [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object to the slide.  
4. Access an [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) object from the table.  
5. Access the [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/).  
6. टेक्स्ट को लंबवत रूप से संरेखित करें।  
7. संशोधित प्रस्तुति को सहेजें।

```java
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // स्तंभों को चौड़ाइयों के साथ और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // स्लाइड में तालिका आकार जोड़ता है
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // टेक्स्ट फ्रेम तक पहुँचता है
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // टेक्स्ट फ्रेम के लिए पैराग्राफ ऑब्जेक्ट बनाता है
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // पैराग्राफ के लिए पोर्शन ऑब्जेक्ट बनाता है
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // टेक्स्ट को लंबवत रूप से संरेखित करता है
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) class.  
2. Get a slide's reference through its index.  
3. Access an [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) object from the Slide.  
4. टेक्स्ट के लिए [setFontHeight(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) सेट करें।  
5. टेक्स्ट के लिए [setAlignment(int value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) सेट करें।  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) सेट करें।  
7. संशोधित प्रस्तुति को सहेजें।  

```java
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation("simpletable.pptx");
try {
    // मान लेते हैं कि पहली स्लाइड पर पहला शैप एक तालिका है
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // तालिका कोशिकाओं का फ़ॉन्ट उँचाई सेट करता है
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // एक कॉल में तालिका कोशिकाओं का टेक्स्ट संरेखण और दाएँ मार्जिन सेट करता है
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // तालिका कोशिकाओं का टेक्स्ट वर्टिकल टाइप सेट करता है
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के लिए शैली गुण प्राप्त करने की अनुमति देता है ताकि आप इन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह Java कोड दिखाता है कि तालिका की प्रीसेट शैली से शैली गुण कैसे प्राप्त करें:

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

## **तालिका का पहलू अनुपात लॉक करें**

ज्यामितीय आकार का पहलू अनुपात विभिन्न आयामों में उसके आकार का अनुपात है। Aspose.Slides ने [**setAspectRatioLocked**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) प्रॉपर्टी प्रदान की है जिससे आप तालिकाओं और अन्य आकारों के लिए पहलू अनुपात सेटिंग को लॉक कर सकते हैं।

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // उलटें

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सामान्य प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**  
हां। तालिका एक [setRightToLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) मेथड प्रदान करती है, और पैराग्राफ में [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) होता है। दोनों का उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को मूव या रिसाइज़ करने से कैसे रोक सकता हूँ?**  
शेप लॉक का उपयोग करके मूविंग, रिसाइज़िंग, चयन आदि को निष्क्रिय करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या सेल के भीतर एक चित्र को बैकग्राउंड के रूप में सम्मिलित करना समर्थित है?**  
हां। आप सेल के लिए एक [picture fill](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturefillformat/) सेट कर सकते हैं; चित्र चयनित मोड (विस्तार या टाइल) के अनुसार सेल क्षेत्र को कवर करेगा।