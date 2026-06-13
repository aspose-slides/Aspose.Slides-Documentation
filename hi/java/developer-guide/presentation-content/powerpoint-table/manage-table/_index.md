---
title: Java में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधित करें
type: docs
weight: 10
url: /hi/java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुँचें
- आस्पेक्ट अनुपात
- टेक्स्ट संरेखित करें
- टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint स्लाइड्स में तालिकाओं को बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सुव्यवस्थित करने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में एक तालिका जानकारी को प्रदर्शित करने और चित्रित करने का एक प्रभावी तरीका है। कोशिकाओं की ग्रिड (पंक्तियों और स्तम्भों में व्यवस्थित) में जानकारी सीधी और समझने में आसान होती है।

Aspose.Slides [Table](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Table) क्लास, [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार प्रदान करता है जिससे आप सभी प्रकार की प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं। 

## **सुरुआत से एक तालिका बनाना**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक नई इंस्टेंस बनाएं।  
2. स्लाइड का रेफ़रेंस उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. `columnWidth` की एक array परिभाषित करें।  
4. `rowHeight` की एक array परिभाषित करें।  
5. स्लाइड में एक [ITable] ऑब्जेक्ट को [addTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) मेथड के माध्यम से जोड़ें।  
6. प्रत्येक [ICell] के माध्यम से इटररेट करके ऊपर, नीचे, दाएँ और बाएँ बॉर्डर पर फ़ॉर्मेट लागू करें।  
7. तालिका की पहली पंक्ति के पहले दो कोशिकाओं को मर्ज करें।  
8. [ICell] की [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) तक पहुंचें।  
9. [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।  
10. परिवर्तित प्रस्तुति को सहेजें।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों के साथ परिभाषित करता है
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // स्लाइड में एक टेबल शैप जोड़ता है
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
    // पंक्ति 1 की कोशिकाएँ 1 और 2 को मर्ज करता है
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // मर्ज की गई कोशिका में कुछ टेक्स्ट जोड़ता है
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में, कोशिकाओं का क्रमांक सरल और शून्य-आधारित होता है। तालिका की पहली कोशिका 0,0 (स्तम्भ 0, पंक्ति 0) के रूप में अनुक्रमित होती है।

उदाहरण के लिए, 4 स्तम्भ और 4 पंक्तियों वाली तालिका में कोशिकाएँ इस प्रकार क्रमांकित हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह Java कोड दिखाता है कि तालिका में कोशिकाओं के क्रमांक कैसे निर्दिष्ट करें:

```java
// PPTX फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में एक टेबल शैप जोड़ता है
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

## **मौजूदा तालिका तक पहुंचें**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक नई इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से तालिका वाली स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक [ITable] ऑब्जेक्ट बनाएं और उसे null सेट करें।  
4. सभी [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) ऑब्जेक्ट्स के माध्यम से इटररेट करें जब तक तालिका न मिल जाए। यदि आपको संदेह है कि स्लाइड जिसमें आप काम कर रहे हैं, एक ही तालिका रखती है, तो आप केवल सभी शैप्स की जाँच कर सकते हैं। जब कोई शैप तालिका के रूप में पहचाना जाता है, तो आप इसे [Table](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Table) ऑब्जेक्ट में टाइपकास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई तालिकाएँ हैं, तो आप [setAlternativeText(String value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) मेथड के माध्यम से आवश्यक तालिका खोज सकते हैं।  
5. तालिका के साथ कार्य करने के लिए [ITable] ऑब्जेक्ट का उपयोग करें। नीचे के उदाहरण में, हमने तालिका में एक नई पंक्ति जोड़ी।  
6. परिवर्तित प्रस्तुति को सहेजें।

```java
// PPTX फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx को इनिशियलाइज़ करता है
    ITable tbl = null;

    // शैप्स के माध्यम से इटररेट करता है और मिली तालिका का रेफ़रेंस सेट करता है
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // दूसरी पंक्ति के पहले कॉलम के लिए टेक्स्ट सेट करता है
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

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक नई इंस्टेंस बनाएं।  
2. स्लाइड का रेफ़रेंस उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. स्लाइड में एक [ITable] ऑब्जेक्ट जोड़ें।  
4. तालिका से एक [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) ऑब्जेक्ट तक पहुंचें।  
5. [ITextFrame] की [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) तक पहुंचें।  
6. टेक्स्ट को लंबवत रूप से संरेखित करें।  
7. परिवर्तित प्रस्तुति को सहेजें।

```java
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // स्लाइड में टेबल शैप जोड़ता है
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // टेक्स्ट फ्रेम तक पहुँचता है
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // टेक्स्ट फ्रेम के लिए पैराग्राफ ऑब्जेक्ट बनाता है
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // पैराग्राफ के लिए भाग (पॉर्शन) ऑब्जेक्ट बनाता है
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

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक नई इंस्टेंस बनाएं।  
2. स्लाइड का रेफ़रेंस उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. स्लाइड से एक [ITable] ऑब्जेक्ट तक पहुंचें।  
4. टेक्स्ट के लिए [setFontHeight(float value)] सेट करें।  
5. [setAlignment(int value)] और [setMarginRight(float value)] सेट करें।  
6. [setTextVerticalType(byte value)] सेट करें।  
7. परिवर्तित प्रस्तुति को सहेजें।  

```java
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation("simpletable.pptx");
try {
    // मान लेते हैं कि पहली स्लाइड के पहले शैप एक तालिका है
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // तालिका कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // तालिका कोशिकाओं का टेक्स्ट संरेखण और दायाँ मार्जिन एक ही कॉल में सेट करता है
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

Aspose.Slides आपको तालिका के शैली गुण प्राप्त करने की सुविधा देता है ताकि आप इन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह Java कोड दिखाता है कि तालिका के प्रीसेट शैली से शैली गुण कैसे प्राप्त करें:

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

## **तालिका का एस्पेक्ट रेशियो लॉक करें**

ज्यामितीय आकार का एस्पेक्ट रेशियो विभिन्न आयामों में उनके आकार का अनुपात होता है। Aspose.Slides ने [**setAspectRatioLocked**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) प्रॉपर्टी प्रदान की है जिससे आप तालिकाओं और अन्य आकारों के लिए एस्पेक्ट रेशियो सेटिंग को लॉक कर सकते हैं। 

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

## **FAQ**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हां। तालिका एक [setRightToLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/table/#setRightToLeft-boolean-) मेथड प्रदान करती है, और पैराग्राफ़ में [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) उपलब्ध है। दोनों का उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं अंतिम फ़ाइल में उपयोगकर्ताओं को तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**

तालिका को स्थानांतरित, आकार बदलने, चयन आदि को निष्क्रिय करने के लिए आप [shape locks](/slides/hi/java/applying-protection-to-presentation/) का उपयोग कर सकते हैं। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या सेल के अंदर एक छवि को पृष्ठभूमि के रूप में डालना समर्थित है?**

हां। आप सेल के लिए एक [picture fill](https://reference.aspose.com/slides/hi/java/com.aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्ट्रेच या टाइल) के अनुसार सेल के क्षेत्र को कवर कर दी जाएगी।