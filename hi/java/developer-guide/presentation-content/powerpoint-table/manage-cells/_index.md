---
title: Java के साथ प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/java/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java में Aspose.Slides के साथ PowerPoint तालिका कोशिकाओं को प्रबंधित करें: मर्ज की गई कोशिकाओं की पहचान, सीमाओं को हटाना, कोशिकाओं को विभाजित करना, और पृष्ठभूमि रंग तथा छवियों को सेट करना।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बताता है कि मर्ज की गई तालिका कोशिकाओं की पहचान कैसे करें, कोशिका की सीमाएँ कैसे हटाएँ, मर्ज या स्प्लिट करने के बाद कोशिका क्रमांकन के साथ कैसे काम करें, कोशिका की पृष्ठभूमि रंग कैसे बदलें, और तालिका कोशिका के अंदर एक छवि कैसे जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएँ या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका स्वरूपण कैसे अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides शून्य-आधारित सूचकांकों का उपयोग करता है तालिका कोशिकाओं तक पहुँचने के लिए क्रम `(column, row)` में।

## **एक मर्ज की गई तालिका कोशिका की पहचान करें**

उदाहरण एक मौजूदा प्रस्तुति खोलता है और पहली स्लाइड पर पहली आकृति को तालिका के रूप में पहुँचता है। यह मान लेता है कि स्लाइड और आकृति मौजूद हैं और आकृति एक तालिका है। फिर यह सभी पंक्तियों और स्तंभों में इटरिट करता है और मर्ज किए गए क्षेत्रों में कोशिकाओं की पहचान करने के लिए [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) का उपयोग करता है। प्रत्येक मिलान के लिए, यह कोशिका निर्देशांक `row;column` क्रम में, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), तथा क्षेत्र की प्रारंभिक निर्देशांक, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) और [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) प्रिंट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```
## **तालिका कोशिका सीमाओं को हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) बनाएँ और उसकी पहली स्लाइड पर [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) के साथ एक तालिका जोड़ें। स्तंभ चौड़ाई, पंक्ति ऊँचाई, और तालिका की स्थिति बिंदुओं (points) में निर्दिष्ट की गई है। उदाहरण सभी चार कोशिका सीमाओं को [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्य हो जाते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **तालिका कोशिकाओं को मिलाएँ**

[mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) का उपयोग करके तालिका कोशिकाओं की आयताकार सीमा को एक ही कोशिका में मिलाएँ। सीमा के ऊपर-बाएँ और नीचे-दाएँ कोने की कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि मर्ज निर्दिष्ट सीमा से बाहर की कोशिकाओं को शामिल करे या नहीं; `false` मर्ज को उसी सीमा में रखता है।

उदाहरण 70‑पॉइंट स्तंभों और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार केंद्रीय कोशिकाओं को मिलाता है। परिणामी कोशिका दो स्तंभों और दो पंक्तियों को कवर करती है, जबकि तालिका का मूल ग्रिड चार स्तंभों और चार पंक्तियों को बनाए रखता है। मिलाए गए कोशिका की सामग्री या स्वरूपण तक पहुँचने के लिए, इस उदाहरण में उसकी ऊपर‑बाएँ स्थिति का उपयोग करें: `table.get_Item(1, 1)`। मिलाए गए सीमा में अन्य स्थितियाँ तालिका ग्रिड का हिस्सा बनी रहती हैं, इसलिए सीमा से बाहर की कोशिकाओं के सूचकांक नहीं बदलते।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **तालिका कोशिकाओं को विभाजित करें**

पिछले उदाहरण में कोशिकाओं को मिलाने से तालिका का ग्रिड बरकरार रहता है। एक कोशिका को विभाजित करने से एक नया ग्रिड स्तंभ बन सकता है और दाईं ओर की कोशिकाओं के स्तंभ सूचकांक बदल सकते हैं। Aspose.Slides PowerPoint के तालिका ग्रिड मॉडल का पालन करता है।

यह उदाहरण 70‑पॉइंट स्तंभों और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है और कोशिका `(1, 1)` पर [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) को कॉल करता है। कोशिका की 70‑पॉइंट चौड़ाई का आधा भाग दो समान‑चौड़ाई वाली कोशिकाएँ बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दो भागों को `table.get_Item(1, 1)` और `table.get_Item(2, 1)` के रूप में पहुँचाया जाता है। तालिका ग्रिड अब पाँच स्तंभ रखता है: मूलतः स्तंभ 2 और 3 में मौजूद कोशिकाएँ क्रमशः स्तंभ 3 और 4 में चली जाती हैं। पंक्ति सूचकांक अपरिवर्तित रहता है। विभाजन के बाद कोशिकाओं तक पहुँचते समय इन अद्यतन स्तंभ सूचकांकों का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **पंक्ति या स्तंभ स्पैन के अनुसार मर्ज किए गए कोशिकाओं को विभाजित करें**

डेटा भरने के लिए मर्ज किए गए टेम्पलेट कोशिकाओं को तैयार करने के लिए, मौजूदा पंक्ति सीमा के साथ विभाजन के लिए [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) का उपयोग करें, या स्तंभ सीमा के साथ विभाजन के लिए [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) का उपयोग करें।

`index` तर्क विभाजन के ऊपरी भाग में पंक्तियों या बाएँ भाग में स्तंभों की गणना करता है; यह मर्ज की गई क्षेत्र के सापेक्ष है:

- पंक्ति विभाजन: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)।
- स्तंभ विभाजन: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)।

उदाहरण मानता है कि प्रस्तुति की पहली स्लाइड पर पहली आकृति एक तालिका है, जिसमें `(1, 2)` और `(1, 3)` ऊर्ध्वाधर रूप से मर्ज किए गए हैं। निचली स्थिति से शुरू करके, यह मूल को खोजने के लिए [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) और [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) का उपयोग करता है और दोनों स्पैन की जाँच करता है। `splitByRowSpan(1)` फिर उत्पाद नामों के लिए पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो‑स्तंभ मर्ज के लिए, इसके बजाय `splitByColSpan(1)` का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // विभाजन के बाद तालिका से प्राप्त होने वाली कोशिकाओं को प्राप्त करें।
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```
तालिका ग्रिड और आसपास की कोशिका सूचकांक अपरिवर्तित रहते हैं। परिणामी कोशिकाओं को उनके निर्देशांक द्वारा प्राप्त करें; यहाँ दोनों का स्पैन 1 है और [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) `false` प्रिंट करता है। एक विभाजन के बाद बड़े क्षेत्रों का कुछ हिस्सा मर्ज्ड रह सकता है।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) कोशिका में रहता है; नई कोशिका खाली होती है लेकिन फ़िल, सीमाएँ और मार्जिन जैसी कोशिका स्वरूपण विरासत में लेती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक किसी भी पाठ स्वरूपण को स्पष्ट रूप से सेट करें।

सहेजी गई प्रस्तुति में अलग-अलग "Product A" और "Product B" कोशिकाएँ होती हैं, जिनमें टेम्पलेट की कोशिका स्वरूपण बनी रहती है। विवरण के लिए [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) देखें।

## **तालिका कोशिका पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट स्तंभों और 50‑पॉइंट पंक्तियों वाली तालिका बनाता है। यह [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) का उपयोग करके ठोस फ़िल चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) द्वारा लौटाए गए रंग को कोशिका `(2, 3)` के लिए लाल सेट करता है, जो तीसरे स्तंभ और चौथी पंक्ति में है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **तालिका कोशिका के अंदर एक छवि जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट छवि को कार्य डायरेक्टरी में रखें। यह छवि को [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) से लोड करता है और प्रस्तुति की इमेज कलेक्शन में [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) के साथ जोड़ता है। फिर यह छवि को कोशिका `(0, 0)` के पिक्चर फ़िल में असाइन करता है, जो तालिका की पहली कोशिका है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) छवि को कोशिका में भरने के लिए खींचता है, जिससे उसका अनुपात बदल सकता है। स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ बिंदुओं में हैं। लोड की गई छवि को प्रस्तुति में जोड़ने के बाद एक `finally` ब्लॉक में नष्ट किया जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग-अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हां। [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) सीमाओं की अलग‑अलग गुणधर्म होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है।

**यदि मैं कोशिका की पृष्ठभूमि के रूप में चित्र सेट करने के बाद स्तंभ/पंक्ति का आकार बदलूँ तो छवि के साथ क्या होता है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग के साथ, छवि नए कोशिका के अनुसार समायोजित होती है; टाइलिंग के साथ, टाइलें पुनः गणना की जाती हैं।

**क्या मैं एक कोशिका की सभी सामग्री को हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/java/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/आकृति स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को एक भाग या कोशिका के सभी टेक्स्ट को असाइन करते हैं।

**क्या मैं एक ही कोशिका के भीतर विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हां। एक कोशिका का टेक्स्ट फ्रेम स्वतंत्र स्वरूपण—फ़ॉन्ट परिवार, शैली, आकार, और रंग—के साथ [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (रन) को समर्थन देता है।