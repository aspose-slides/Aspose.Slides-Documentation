---
title: "Android पर प्रेजेंटेशन टेबल्स प्रबंधित करें"
linktitle: "टेबल प्रबंधित करें"
type: docs
weight: 10
url: /hi/androidjava/manage-table/
keywords:
- "टेबल जोड़ें"
- "टेबल बनाएं"
- "टेबल तक पहुँचें"
- "आस्पेक्ट अनुपात"
- "पाठ संरेखित करें"
- "पाठ स्वरूपण"
- "टेबल शैली"
- "पावरपॉइंट"
- "प्रेजेंटेशन"
- "एंड्रॉइड"
- "जावा"
- "Aspose.Slides"
description: "Aspose.Slides for Android के साथ PowerPoint स्लाइड्स में टेबल बनाएं और संपादित करें। अपनी टेबल कार्यवाही को सरल बनाने के लिए सरल Java कोड उदाहरण देखें।"
---
## **Introduction**

PowerPoint में एक तालिका जानकारी को प्रदर्शित करने और प्रस्तुत करने का एक कुशल तरीका है। कोशिकाओं के ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी सीधी और समझने में आसान होती है।

Aspose.Slides [Table](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Table) क्लास, [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITable) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार प्रदान करता है जो आपको सभी प्रकार की प्रस्तुतियों में तालिकाएँ बनाने, अपडेट करने और प्रबंधित करने की अनुमति देते हैं।

## **Create a Table from Scratch**

1. Presentation क्लास की एक instance बनाएँ।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. `columnWidth` का एक array परिभाषित करें।
4. `rowHeight` का एक array परिभाषित करें।
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) मेथड के माध्यम से एक [ITable] ऑब्जेक्ट जोड़ें।
6. ऊपर, नीचे, दाएँ और बाएँ बॉर्डर पर फ़ॉर्मेटिंग लागू करने के लिए प्रत्येक [ICell] पर इटरेंट करें।
7. तालिका की पहली पंक्ति की पहले दो कोशिकाओं को मर्ज करें। 
8. [ICell] की [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) तक पहुँचें।
9. [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
10. संशोधित प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
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
    // पंक्ति 1 की सेल 1 और 2 को मर्ज करता है
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // मर्ज किए गए सेल में कुछ टेक्स्ट जोड़ता है
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numbering in a Standard Table**

एक मानक तालिका में, कोशिकाओं की क्रमांकन सीधी और जिरो‑आधारित होती है। तालिका की पहली कोशिका का इंडेक्स 0,0 (स्तंभ 0, पंक्ति 0) होता है। 

उदाहरण के लिये, 4 स्तंभ और 4 पंक्तियों वाली तालिका की कोशिकाएँ इस प्रकार क्रमांकित होती हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह Java कोड दिखाता है कि तालिका में कोशिकाओं के क्रमांकन को कैसे निर्दिष्ट किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
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

    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Access an Existing Table**

1. Presentation क्लास की एक instance बनाएँ।

2. इंडेक्स के माध्यम से तालिका वाली स्लाइड का रेफ़रेंस प्राप्त करें। 

3. एक [ITable] ऑब्जेक्ट बनाएँ और उसे null सेट करें।

4. सभी [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) ऑब्जेक्ट्स पर इटरेंट करें जब तक तालिका न मिल जाये।

   यदि आपको संदेह है कि वर्तमान स्लाइड में केवल एक तालिका है, तो आप उसकी सभी शैप्स को जांच सकते हैं। जब कोई शैप तालिका के रूप में पहचाना जाता है, तो आप इसे [Table](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Table) ऑब्जेक्ट में टाइप‑कास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई तालिकाएँ हैं, तो आपको आवश्यक तालिका को उसके [setAlternativeText(String value)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) द्वारा खोजना बेहतर रहेगा।

5. तालिका के साथ काम करने के लिए [ITable] ऑब्जेक्ट का उपयोग करें। नीचे दिए गए उदाहरण में, हम तालिका की एक कोशिका का टेक्स्ट सेट करते हैं।

6. संशोधित प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx को आरंभ करता है
    ITable tbl = null;

    // शैप्स के माध्यम से इटरेट करता है और पाए गए टेबल का रेफ़रेंस सेट करता है
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // दूसरी पंक्ति के पहले कॉलम के लिए टेक्स्ट सेट करता है
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // संशोधित प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Find the Cell That Owns a Text Frame**

जब सामान्य टेक्स्ट‑प्रोसेसिंग कोड को तालिका से एक [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) मिलता है, तो स्वामित्व वाली [ICell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/) को प्राप्त करने के लिए [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentCell--) मेथड का उपयोग करें। टेबल‑सेल टेक्स्ट फ्रेम के लिए, [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentCell--) मालिक को लौटाता है और [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentShape--) `null` लौटाता है, भले ही टेबल स्वयं एक शैप हो।

सेल के निर्देशांक केवल‑पढ़ने‑योग्य [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) और [ICell.getFirstRowIndex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) मेथड्स के माध्यम से उपलब्ध होते हैं। [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentCell--) भी केवल‑पढ़ने‑योग्य नेविगेशन प्रदान करता है: यह मालिक को लौटाता है लेकिन स्वामित्व नहीं बदलता। हमेशा उपयोग करने से पहले लौटाए गए सेल को `null` के लिये जांचें।

एक पूर्ण उदाहरण के लिये जो टेबल‑सेल और शैप मालिकों को पहचानता है, जिसमें SmartArt नोड्स से जुड़े शैप्स भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/androidjava/search-and-replace-text/)।

## **Align Text in a Table**

1. Presentation क्लास की एक instance बनाएँ।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड में एक [ITable] ऑब्जेक्ट जोड़ें।
4. तालिका से एक [ITextFrame] ऑब्जेक्ट तक पहुँचें।
5. [ITextFrame] के [IParagraph] तक पहुँचें।
6. टेक्स्ट को लंबवत संरेखित करें।
7. संशोधित प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास की एक instance बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // चौड़ाइयों के साथ कॉलम और ऊँचाइयों के साथ पंक्तियों को परिभाषित करता है
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // स्लाइड में टेबल शैप जोड़ता है
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // टेक्स्ट फ्रेम तक पहुँचता है
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // टेक्स्ट फ्रेम के लिए Paragraph ऑब्जेक्ट बनाता है
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // पैराग्राफ के लिए Portion ऑब्जेक्ट बनाता है
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // टेक्स्ट को लंबवत संरेखित करता है
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Text Formatting on the Table Level**

1. Presentation क्लास की एक instance बनाएँ।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड से एक [ITable] ऑब्जेक्ट तक पहुँचें।
4. टेक्स्ट के लिए [setFontHeight(float value)] सेट करें।
5. [setAlignment(int value)] और [setMarginRight(float value)] सेट करें।
6. [setTextVerticalType(byte value)] सेट करें।
7. संशोधित प्रस्तुति को सहेजें। 

```java
import com.aspose.slides.*;

// Presentation क्लास की एक instance बनाता है
Presentation pres = new Presentation("simpletable.pptx");
try {
    // मान लेते हैं कि पहली स्लाइड पर पहला शैप एक टेबल है
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // टेबल सेल्स की फ़ॉन्ट ऊँचाई सेट करता है
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // टेबल सेल्स का टेक्स्ट एलाइमेंट और दायाँ मार्जिन एक ही कॉल में सेट करता है
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // टेबल सेल्स का टेक्स्ट वर्टिकल टाइप सेट करता है
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get Table Style Properties**

Aspose.Slides आपको एक तालिका की शैली गुणों को प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह Java कोड दिखाता है कि तालिका के प्रीसेट स्टाइल से शैली गुणों को कैसे प्राप्त किया जाए:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // डिफ़ॉल्ट शैली प्रीसेट थीम बदलें

    // टेबल का शैली प्रीसेट प्राप्त करें
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // प्राप्त किए गए शैली प्रीसेट को दूसरे टेबल पर लागू करें
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lock Aspect Ratio of a Table**

ज्यामितीय आकृति का पहलू अनुपात उसके विभिन्न आयामों में आकारों का अनुपात होता है। Aspose.Slides ने टेबल और अन्य शैप्स के लिए पहलू अनुपात को लॉक करने हेतु [**setAspectRatioLocked**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) प्रॉपर्टी प्रदान की है।

यह Java कोड दिखाता है कि तालिका के लिए पहलू अनुपात को कैसे लॉक किया जाए:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // उलटा करें

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

हाँ। तालिका में एक [setRightToLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) मेथड उपलब्ध है, और पैराग्राफ़ में [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) है। दोनों का उपयोग करने से सेल्स के अंदर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**How can I prevent users from moving or resizing a table in the final file?**

शैप लॉक का उपयोग करके मूविंग, रिसाइज़िंग, चयन आदि को निष्क्रिय करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**Is inserting an image inside a cell as a background supported?**

हाँ। आप एक सेल के लिए [picture fill](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्टेच या टाइल) के अनुसार सेल क्षेत्र को कवर कर देगी।