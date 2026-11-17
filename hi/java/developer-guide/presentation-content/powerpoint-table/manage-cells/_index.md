---
title: जावा का उपयोग करके प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/java/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाना
- सीमा हटाना
- कोशिका विभाजित करना
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा में PowerPoint तालिका कोशिकाओं को प्रबंधित करें: मर्ज्ड कोशिकाओं की पहचान करें, सीमाओं को हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for Java के साथ पृष्ठभूमि रंग और छवियां सेट करें।"
---
## **सारांश**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख मर्ज्ड तालिका कोशिकाओं की पहचान, कोशिका सीमाओं को हटाना, मर्ज या विभाजन के बाद कोशिका क्रमांक के साथ काम करना, कोशिका की पृष्ठभूमि रंग बदलना, और तालिका कोशिका के अंदर एक छवि जोड़ने को समझाता है। उदाहरण दिखाते हैं कि प्रस्तुतिकरण कैसे बनाएँ या खोलें, स्लाइड से तालिका कैसे प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका स्वरूपण कैसे अपडेट करें, और संशोधित प्रस्तुतिकरण को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides तालिका कोशिकाओं को पहुँचने के लिए शून्य-आधारित सूचकांक का उपयोग करता है, क्रम `(column, row)` में।

## **विलीन तालिका सेल की पहचान करें**

उदाहरण एक मौजूदा प्रस्तुतिकरण खोलता है और पहले स्लाइड पर पहले आकार को तालिका के रूप में पहुँचता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार एक तालिका है। फिर यह सभी पंक्तियों और स्तंभों के माध्यम से इटरित करता है और [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) का उपयोग करके मर्ज्ड क्षेत्रों में स्थित कोशिकाओं की पहचान करता है। प्रत्येक मेल के लिए यह `row;column` क्रम में कोशिका निर्देशांक, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), और क्षेत्र के प्रारम्भिक निर्देशांक, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--), तथा [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) को प्रिंट करता है।

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

## **तालिका सेल की सीमाएं हटाएं**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) बनाएँ और [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) का उपयोग करके उसकी पहली स्लाइड में एक तालिका जोड़ें। स्तम्भ चौड़ाई, पंक्ति ऊँचाई, और तालिका स्थिति पॉइंट में निर्दिष्ट की गई है। उदाहरण सभी चार कोशिका सीमाओं को [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्य हो जाती हैं।

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

## **विकर्ण सेल सीमाएं जोड़ें**

[getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) का उपयोग करके शीर्ष-बाएँ कोने से नीचे-दाएँ कोने तक एक रेखा खींचें, और [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) का उपयोग करके नीचे-बाएँ कोने से ऊपर-दाएँ कोने तक एक रेखा खींचें। एक विकर्ण कोने हेडर को चिह्नित कर सकता है; दोनों विकर्ण मिलकर X बनाते हैं जिससे सेल को लागू नहीं के रूप में चिह्नित किया जा सकता है।

प्रत्येक विकर्ण एक [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) है। इसके [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) में, [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) का उपयोग करके [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) चुनें और [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) से रंग चुनें। रेखा की चौड़ाई को पॉइंट में [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) से सेट करें।

उदाहरण एक पंक्ति में तीन कोशिकाएँ बनाता है: एक लाल नीचे की ओर विकर्ण, एक नीला ऊपर की ओर विकर्ण, और दोनों विकर्ण। यह शीर्ष, नीचे, बाएँ और दाएँ कोशिका सीमाओं को अपरिवर्तित छोड़ता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

विकर्ण एक स्वरूपण गुण है, न कि कोशिका का विभाजन। प्रत्येक कोशिका एकल टेक्स्ट फ्रेम रखती है, जिसे [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) के माध्यम से पहुँचा जाता है; विकर्ण के दोनों पक्षों के क्षेत्रों को स्वतंत्र रूप से संपादित नहीं किया जा सकता।

सहेजा गया तालिका, Microsoft PowerPoint में प्रदर्शित:

![तीन तालिका कोशिकाएँ जिनमें शीर्ष-बाएँ से नीचे-दाएँ एक लाल विकर्ण, नीचे-बाएँ से ऊपर-दाएँ एक नीला विकर्ण, और दोनों विकर्ण मिलकर X बनाते हैं।](diagonal-cell-borders.png)

*बाएँ से दाएँ: नीचे की ओर विकर्ण (लाल, 3 pt), ऊपर की ओर विकर्ण (नीला, 5 pt), और दोनों विकर्ण।*

## **तालिका सेल को मिलाएं**

[mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) का उपयोग करके तालिका कोशिकाओं की आयताकार रेंज को एक कोशिका में मिलाएँ। रेंज के शीर्ष-बाएँ और नीचे-दाएँ कोनों की कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि क्या मर्ज निर्दिष्ट रेंज के बाहर की कोशिकाओं को शामिल कर सकता है; `false` मर्ज को उसी रेंज में रखता है।

उदाहरण 70 पॉइंट स्तम्भ और पंक्तियों के साथ 4x4 तालिका बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार केंद्रीय कोशिकाओं को मिलाता है। परिणामी कोशिका दो स्तम्भ और दो पंक्तियों को कवर करती है, जबकि तालिका की आंतरिक ग्रिड चार स्तम्भ और चार पंक्तियाँ रखती है। मर्ज्ड सेल की सामग्री या स्वरूपण तक पहुँचने के लिए, इस उदाहरण में `table.get_Item(1, 1)` का उपयोग करें। मर्ज्ड रेंज के अन्य पद तालिका ग्रिड का हिस्सा बने रहते हैं, इसलिए रेंज के बाहर की कोशिकाओं के सूचक नहीं बदलते।

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

## **तालिका सेल को विभाजित करें**

पिछले उदाहरण में कोशिकाओं का मर्ज तालिका ग्रिड को संरक्षित रखता है। एक सेल को विभाजित करने से नया ग्रिड स्तम्भ बन सकता है और दाएँ वाली कोशिकाओं के स्तम्भ सूचकांक बदल सकते हैं। Aspose.Slides PowerPoint के तालिका ग्रिड मॉडल का अनुसरण करता है।

यह उदाहरण 70 पॉइंट स्तम्भ और पंक्तियों के साथ 4x4 तालिका बनाता है और `(1, 1)` कोशिका पर [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) को कॉल करता है। कोशिका की 70 पॉइंट चौड़ाई का आधा भाग दो समान‑चौड़ाई वाली कोशिकाएँ बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दो हिस्सों को `table.get_Item(1, 1)` और `table.get_Item(2, 1)` के रूप में पहुँचा जाता है। तालिका ग्रिड अब पाँच स्तम्भ रखता है: मूलतः स्तम्भ 2 और 3 में स्थित कोशिकाएँ क्रमशः स्तम्भ 3 और 4 में चली गईं। पंक्ति सूचकांक अपरिवर्तित रहते हैं। विभाजन के बाद कोशिकाओं तक पहुँचते समय इन अद्यतन स्तम्भ सूचकांकों का उपयोग करें।

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

<!-- visual-explanation:manage-cells:start -->
[![एक अनमर्ज्ड 70‑पॉइंट सेल दो 35‑पॉइंट कोशिकाओं में विभाजित होता है, जिससे एक पाँचवाँ ग्रिड स्तम्भ जुड़ता है और दाएँ के सूचकांक शिफ्ट होते हैं।](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*चौड़ाई विभाजन (1, 1) कोशिका को प्रभावित करता है, शून्य‑आधारित (column, row) सूचकांक का उपयोग करता है। अन्य पंक्तियों में एक कोशिका दोनों नए स्तम्भ स्थितियों को कवर करती रहती है।*
<!-- visual-explanation:manage-cells:end -->

### **पंक्ति या स्तम्भ स्पैन द्वारा मर्ज्ड सेल को विभाजित करें**

डेटा भरने के लिए मर्ज्ड टेम्पलेट कोशिकाओं को तैयार करने हेतु, मौजूदा पंक्ति सीमा के साथ विभाजित करने के लिए [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) या स्तम्भ सीमा के साथ विभाजित करने के लिए [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) का उपयोग करें।

`index` तर्क विभाजन के ऊपरी भाग में पंक्तियों या बाएँ भाग में स्तम्भों की संख्या गिनता है; यह मर्ज्ड क्षेत्र के सापेक्ष होता है:

- पंक्ति विभाजन: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)।
- स्तम्भ विभाजन: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)।

उदाहरण अपेक्षा करता है कि प्रस्तुतिकरण में पहली स्लाइड पर पहली आकार के रूप में एक तालिका हो, जिसमें `(1, 2)` और `(1, 3)` वर्टिकल रूप से मर्ज्ड हों। नीचे की स्थिति से शुरू करते हुए, यह [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) और [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) का उपयोग करके मूल बिंदु ढूँढता है और दोनों स्पैन की जाँच करता है। `splitByRowSpan(1)` फिर पंक्तियों 2 और 3 को अलग करता है ताकि उत्पाद नाम रखे जा सकें। क्षैतिज दो‑स्तम्भ मर्ज के लिए, इसके बजाय `splitByColSpan(1)` का उपयोग करें।

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

        // विभाजन के बाद तालिका से प्राप्त होने वाली कोशिकाओं को पुनः प्राप्त करें।
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

तालिका ग्रिड और आसपास की कोशिका सूचकांक अपरिवर्तित रहते हैं। परिणामस्वरूप कोशिकाओं को उनके निर्देशांक से प्राप्त करें; यहाँ दोनों की स्पैन 1 है और [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) `false` प्रिंट करता है। एक विभाजन के बाद बड़े क्षेत्र आंशिक रूप से मर्ज्ड रह सकते हैं।

मूल टेक्स्ट और उसका स्वरूपण ऊपर (या बाएँ) कोशिका में बना रहता है; नई कोशिका खाली रहती है लेकिन भराव, सीमाएँ, मार्जिन जैसी कोशिका स्वरूपण विरासत में लेती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक टेक्स्ट स्वरूपण स्पष्ट रूप से सेट करें।

सहेजा गया प्रस्तुतिकरण अलग‑अलग “Product A” और “Product B” कोशिकाएँ रखता है, जिसमें टेम्पलेट की कोशिका स्वरूपण बरकरार रहता है। विवरण के लिए देखें [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/)।

### **विशिष्ट ऊँचाई पर सेल को विभाजित करें**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) ऊपरी भाग की ऊँचाई पॉइंट में लेता है। [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) ऊपरी भाग में मौजूद ग्रिड पंक्तियों की संख्या लेता है। 40‑पॉइंट सेल को दाएँ स्तम्भ में केंद्रित करने के लिए, सेल की वास्तविक ऊँचाई से 40 घटाएँ और शेष स्थान को ऊपर और नीचे समान रूप से बाँटें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };
    
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

पहला विभाजन एक ग्रिड पंक्ति जोड़ता है और `(1, 1)` कोशिका में नीचे के 90 पॉइंट छोड़ता है। दूसरा विभाजन उस कोशिका को 40‑पॉइंट मध्य कोशिका और 50‑पॉइंट निचली कोशिका में विभाजित करता है। दाएँ स्तम्भ में अब शीर्ष से नीचे तक 50, 40, और 50 पॉइंट की तीन कोशिकाएँ हैं। बायाँ कोशिका सभी तीन पंक्तियों को कवर करता है और अपनी मूल 140 पॉइंट ऊँचाई बनाए रखता है।

![बायाँ कोशिका पूरी तालिका की ऊँचाई को कवर करता है, जबकि तीन कोशिकाएँ मध्य में “Middle” के साथ स्थित हैं।](split-by-height.png)

## **तालिका सेल की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट स्तम्भ और 50‑पॉइंट पंक्तियों वाली तालिका बनाता है। यह [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) का उपयोग करके सॉलिड फिल चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) द्वारा लौटाए गए रंग को लाल सेट करता है, सेल `(2, 3)` (तीसरा स्तम्भ, चौथी पंक्ति) के लिए।

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

## **तालिका सेल के अंदर एक छवि जोड़ें**

उदाहरण चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) से लोड करता है और प्रस्तुति की इमेज कलेक्शन में [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) के साथ जोड़ता है। फिर यह छवि को तालिका के पहले सेल `(0, 0)` के पिक्चर फ़िल में असाइन करता है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) छवि को सेल में भरने के लिये खींचता है, जिससे उसका पहलु अनुपात बदल सकता है। स्तम्भ चौड़ाई और पंक्ति ऊँचाई पॉइंट में हैं। लोड की गई छवि को `finally` ब्लॉक में डिस्पोज़ किया जाता है, जब वह प्रस्तुति में जोड़ दी गई हो।

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

## **FAQ**

**क्या मैं एक ही सेल के विभिन्न पक्षों के लिए अलग‑अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हां। [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) सीमाओं की अलग‑अलग विशेषताएं हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है।

**सेल की पृष्ठभूमि में तस्वीर रखने के बाद यदि मैं स्तम्भ/पंक्ति का आकार बदलूँ तो क्या होता है?**

यह व्यवहार [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग के साथ, नई सेल आकार के अनुसार छवि समायोजित हो जाती है; टाइलिंग के साथ, टाइलें पुनः गणना की जाती हैं।

**क्या मैं सेल की पूरी सामग्री पर एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/java/manage-hyperlinks/) को सेल के टेक्स्ट (portion) स्तर पर या पूरे तालिका/shape स्तर पर सेट किया जाता है। व्यावहारिक रूप से, आप लिंक को किसी portion या सेल के सभी टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही सेल के भीतर अलग‑अलग फॉन्ट निर्धारित कर सकता हूँ?**

हां। एक सेल का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (runs) का समर्थन करता है, जिनके पास स्वतंत्र स्वरूपण—फ़ॉन्ट फ़ैमिली, शैली, आकार, और रंग—होता है।