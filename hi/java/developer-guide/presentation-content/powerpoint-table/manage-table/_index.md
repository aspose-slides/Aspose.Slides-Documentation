---
title: जावा में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुँचें
- आस्पेक्ट रेशियो
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint स्लाइड्स में तालिकाओं को बनाएँ और संपादित करें। अपने तालिका कार्यप्रवाह को सुव्यवस्थित करने के लिए आसान कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में तालिका जानकारी को प्रदर्शित करने और अभिव्यक्त करने का एक प्रभावी तरीका है। कोशिकाओं के ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी सीधी और समझने में आसान होती है।

Aspose.Slides [Table](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Table) क्लास, [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार प्रदान करता है ताकि आप सभी प्रकार की प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकें। 

## **शुरू से तालिका बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. `columnWidth` का एक एरे परिभाषित करें।
4. `rowHeight` का एक एरे परिभाषित करें।
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) मेथड के द्वारा एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) ऑब्जेक्ट जोड़ें।
6. प्रत्येक [ICell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/) पर इटररेट करके ऊपर, नीचे, दाएँ और बाएँ बॉर्डर पर फ़ॉर्मेटिंग लागू करें।
7. तालिका की पहली पंक्ति के पहले दो कोशिकाओं को मिलाएँ। 
8. किसी [ICell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/) की [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) तक पहुँचें। 
9. [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
10. संशोधित प्रस्तुति सहेजें।

यह Java कोड दिखाता है कि प्रस्तुति में तालिका कैसे बनायीँ:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // कॉलम की चौड़ाई और पंक्तियों की ऊँचाई परिभाषित करता है
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // स्लाइड में एक तालिका आकार जोड़ता है
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के लिए बॉर्डर फ़ॉर्मेट सेट करता है
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
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // मर्ज की गई कोशिका में कुछ टेक्स्ट जोड़ता है
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **मानक तालिका में क्रमांक निर्धारण**

मानक तालिका में कोशिकाओं का क्रमांक निर्धारण साधारण और शून्य-आधारित होता है। तालिका की पहली कोशिका का इंडेक्स 0,0 (स्तंभ 0, पंक्ति 0) होता है। 

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका की कोशिकाएँ इस प्रकार क्रमांकित होती हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह Java कोड दिखाता है कि तालिका में कोशिकाओं के क्रमांक कैसे निर्धारित करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ परिभाषित करता है
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // स्लाइड में एक तालिका आकार जोड़ता है
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // प्रत्येक कोशिका के बॉर्डर फ़ॉर्मेट को सेट करता है
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

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।

2. अनुक्रमणिका के माध्यम से उस स्लाइड का संदर्भ प्राप्त करें जिसमें तालिका है। 

3. एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) ऑब्जेक्ट बनाएँ और उसे null सेट करें।

4. सभी [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) ऑब्जेक्ट्स को इटररेट करें जब तक कि तालिका न मिल जाए।

   यदि आपको संदेह है कि जिस स्लाइड को आप संभाल रहे हैं उसमें केवल एक तालिका है, तो आप बस उसमें मौजूद सभी शैप्स की जाँच कर सकते हैं। जब कोई शैप तालिका के रूप में पहचाना जाता है, तो आप उसे [Table](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Table) ऑब्जेक्ट में टाइप-कास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई तालिकाएँ हैं, तो आपको उसकी [setAlternativeText(String value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) के माध्यम से आवश्यक तालिका खोजनी होगी।

5. तालिका के साथ काम करने के लिए [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) ऑब्जेक्ट का उपयोग करें। नीचे के उदाहरण में हमने तालिका में एक नई पंक्ति जोड़ दी।

6. संशोधित प्रस्तुति सहेजें।

यह Java कोड दिखाता है कि मौजूदा तालिका तक कैसे पहुँचें और उसके साथ कार्य करें:

```java
import com.aspose.slides.*;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);

    // null TableEx को आरंभ करता है
    ITable tbl = null;

    // शेप्स के माध्यम से इटररेट करता है और मिलने वाली तालिका का संदर्भ सेट करता है
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // दूसरी पंक्ति के पहले कॉलम का टेक्स्ट सेट करता है
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // संशोधित प्रस्तुति को डिस्क पर सहेजता है
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **उन कोशिकाओं को ढूंढें जिनके पास टेक्स्ट फ्रेम है**

जब सामान्य टेक्स्ट-प्रोसेसिंग कोड को तालिका से एक [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) प्राप्त होता है, तो मालिक [ICell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/) को प्राप्त करने के लिए [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentCell--) मेथड का उपयोग करें। एक तालिका-कोशिका टेक्स्ट फ्रेम के लिए, [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentCell--) मालिक को लौटाता है और [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentShape--) `null` लौटाता है, हालांकि तालिका स्वयं एक शैप है।

कोशिका कॉर्डिनेट्स पढ़ने‑के‑लिए‑केवल [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/#getFirstColumnIndex--) और [ICell.getFirstRowIndex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icell/#getFirstRowIndex--) मेथड उपलब्ध हैं। [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentCell--) केवल पढ़ने‑के‑लिए‑नेविगेशन भी प्रदान करता है: यह मालिक को लौटाता है लेकिन स्वामित्व नहीं बदलता। उपयोग करने से पहले हमेशा लौटाए गए कोशिका के `null` होने की जाँच करें।

तालिका‑कोशिका और शैप मालिकों की पहचान करने वाले पूर्ण उदाहरण के लिए, जिसमें SmartArt नोड्स से जुड़े शैप्स भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/java/search-and-replace-text/)।

## **तालिका में टेक्स्ट को संरेखित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. स्लाइड में एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) ऑब्जेक्ट जोड़ें। 
4. तालिका से एक [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) ऑब्जेक्ट तक पहुँचें। 
5. [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) की [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) तक पहुँचें।
6. टेक्स्ट को लंबवत रूप से संरेखित करें।
7. संशोधित प्रस्तुति सहेजें।

यह Java कोड दिखाता है कि तालिका में टेक्स्ट को कैसे संरेखित करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // कॉलम की चौड़ाई और पंक्तियों की ऊँचाई परिभाषित करता है
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // स्लाइड में तालिका आकार जोड़ता है
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

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके अनुक्रमणिका के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. स्लाइड से एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) ऑब्जेक्ट तक पहुँचें।
4. टेक्स्ट के लिए [setFontHeight(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) सेट करें। 
5. [setAlignment(int value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) सेट करें। 
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) सेट करें।
7. संशोधित प्रस्तुति सहेजें। 

यह Java कोड दिखाता है कि तालिका में टेक्स्ट पर अपनी पसंदीदा फ़ॉर्मेटिंग विकल्प कैसे लागू करें:

```java
import com.aspose.slides.*;

// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation("simpletable.pptx");
try {
    // मान लेते हैं कि पहली स्लाइड की पहली आकृति एक तालिका है
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // तालिका कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // तालिका कोशिकाओं के टेक्स्ट संरेखण और दाएँ मार्जिन को एक ही कॉल में सेट करता है
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // तालिका कोशिकाओं के टेक्स्ट वर्टिकल टाइप को सेट करता है
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के लिए शैली गुण प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी अन्य तालिका या किसी अन्य स्थान पर उपयोग कर सकें। यह Java कोड दिखाता है कि तालिका प्रीसेट शैली से शैली गुण कैसे प्राप्त करें:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // डिफ़ॉल्ट शैली प्रीसेट थीम बदलें

    // तालिका की शैली प्रीसेट प्राप्त करता है
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // प्राप्त शैली प्रीसेट को दूसरी तालिका पर लागू करता है
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका का आस्पेक्ट रेश्यो लॉक करें**

ज्यामितीय आकार का आस्पेक्ट रेश्यो विभिन्न आयामों में उसके आकार का अनुपात है। Aspose.Slides ने तालिकाओं और अन्य शैप्स के लिए आस्पेक्ट रेश्यो सेटिंग को लॉक करने हेतु [**setAspectRatioLocked**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) प्रॉपर्टी प्रदान की है। 

यह Java कोड दिखाता है कि तालिका के लिए आस्पेक्ट रेश्यो कैसे लॉक करें:

```java
import com.aspose.slides.*;

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हाँ। तालिका में एक [setRightToLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/table/#setRightToLeft-boolean-) मेथड उपलब्ध है, और पैराग्राफ़ में [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) होता है। दोनों का उपयोग करने से कोशिकाओं के अंदर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**

तालिका सहित शैप्स को स्थानांतरित, आकार बदलने, चयन आदि को निष्क्रिय करने के लिए [shape locks](/slides/hi/java/applying-protection-to-presentation/) का उपयोग करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या एक कोशिका के भीतर पृष्ठभूमि के रूप में छवि सम्मिलित करना समर्थित है?**

हाँ। आप किसी कोशिका के लिए [picture fill](https://reference.aspose.com/slides/hi/java/com.aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्ट्रेच या टाइल) के अनुसार कोशिका क्षेत्र को कवर कर देगी।