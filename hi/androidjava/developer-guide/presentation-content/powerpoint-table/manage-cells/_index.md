---
title: Android पर प्रस्तुतियों में तालिका कोशिकाओं को प्रबंधित करें
linktitle: कोशिकाओं को प्रबंधित करें
type: docs
weight: 30
url: /hi/androidjava/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- सीमाओं को हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android पर PowerPoint तालिका कोशिकाओं का प्रबंधन: मर्ज्ड कोशिकाओं की पहचान करें, सीमाओं को हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for Android के माध्यम से Java में पृष्ठभूमि रंग और छवियों को सेट करें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बताता है कि कैसे मिलाए गए तालिका कोशिकाओं की पहचान करें, कोशिका सीमाओं को हटाएँ, मर्ज या विभाजन के बाद कोशिका क्रमांक के साथ काम करें, कोशिका की पृष्ठभूमि रंग बदलें, और तालिका कोशिका के भीतर एक छवि जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनायें या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका फॉर्मेटिंग अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides तालिका कोशिकाओं तक पहुँचने के लिए शून्य-आधारित सूचक (`column, row`) उपयोग करता है।

## **मर्ज्ड तालिका कोशिका की पहचान करें**

यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और पहली स्लाइड पर पहले शेप को तालिका के रूप में पहुँचता है। यह मानता है कि स्लाइड और शेप मौजूद हैं तथा शेप एक तालिका है। फिर यह सभी पंक्तियों और स्तम्भों पर इटरट करता है और [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) का उपयोग करके मर्ज्ड क्षेत्रों में कोशिकाओं की पहचान करता है। प्रत्येक मिलान के लिए यह `row;column` क्रम में कोशिका निर्देशांक, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), तथा क्षेत्र के प्रारंभिक निर्देशांक, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) और [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) को प्रिंट करता है।

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

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) बनाएँ और उसके पहले स्लाइड में [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) का उपयोग करके एक तालिका जोड़ें। स्तम्भ चौड़ाई, पंक्ति ऊँचाई, और तालिका स्थिति बिंदुओं में निर्दिष्ट की गई हैं। उदाहरण सभी चार कोशिका सीमाओं को [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) सेट करता है, जिससे वे अदृश्य हो जाती हैं।

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

## **विकर्ण कोशिका सीमाएँ जोड़ें**

[ getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) का उपयोग करके बाएँ‑ऊपरी कोने से दाएँ‑नीचे कोने तक एक रेखा बनाएं, और [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) का उपयोग करके नीचे‑बाएँ कोने से ऊपर‑दाएँ कोने तक एक रेखा बनाएं। एक विकर्ण को कोने शीर्षक के रूप में चिह्नित किया जा सकता है; दोनों विकर्ण मिलकर X बनाते हैं जो दर्शाता है कि कोशिका लागू नहीं है।

प्रत्येक विकर्ण एक [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) है। इसके [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) में, [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) का उपयोग करके [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) चुनें और [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) के माध्यम से एक रंग चुनें। लाइन की चौड़ाई बिंदुओं में [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) से सेट करें।

उदाहरण एक पंक्ति में तीन कोशिकाएँ बनाता है: एक लाल नीचे‑की‑विकर्ण, एक नीला ऊपर‑की‑विकर्ण, और दोनों विकर्ण। यह ऊपर, नीचे, बाएँ और दाएँ कोशिका सीमाओं को अपरिवर्तित छोड़ता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

विकर्ण एक फ़ॉर्मेटिंग प्रॉपर्टी है, न कि कोशिका विभाजन। प्रत्येक कोशिका एकल टेक्स्ट फ्रेम रखती है, जिसे [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) से पहुँचा जाता है; विकर्ण के दोनों पक्षों के क्षेत्रों को स्वतंत्र रूप से संपादित नहीं किया जा सकता।

सहेजा गया तालिका, Microsoft PowerPoint में रेंडर किया गया:

![तीन तालिका कोशिकाएँ जो बाएँ‑ऊपर से दाएँ‑नीचे तक लाल विकर्ण, बाएँ‑नीचे से दाएँ‑ऊपर तक नीला विकर्ण, और दोनों विकर्ण मिलाकर X बनाती हैं।](diagonal-cell-borders.png)

*बाएँ‑से‑दाएँ: नीचे‑की‑विकर्ण (लाल, 3 pt), ऊपर‑की‑विकर्ण (नीला, 5 pt), और दोनों विकर्ण।*

## **तालिका कोशिकाएँ मर्ज करें**

[mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) का उपयोग करके तालिका कोशिकाओं की आयताकार रेंज को एक कोशिका में मिलाएँ। रेंज के बाएँ‑ऊपरी और दाएँ‑नीचे कोनों की कोशिकाएँ निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि क्या मर्ज निर्दिष्ट रेंज के बाहर की कोशिकाओं को शामिल कर सकता है; `false` मर्ज को उसी रेंज में रखता है।

उदाहरण 70‑पॉइंट स्तम्भ और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है, फिर केंद्र के चार कोशिकाओं को `(1, 1)` से `(2, 2)` तक मर्ज करता है। परिणामी कोशिका दो स्तम्भ और दो पंक्तियों को कवर करती है, जबकि तालिका का मूल ग्रिड चार स्तम्भ और चार पंक्तियों को बनाए रखता है। मर्ज्ड कोशिका की सामग्री या फॉर्मेटिंग तक पहुँचने के लिए, इस उदाहरण में उसकी बाएँ‑ऊपरी स्थिति का उपयोग करें: `table.get_Item(1, 1)`। मर्ज्ड रेंज के बाहर की कोशिकाएँ तालिका ग्रिड का हिस्सा रहती हैं, इसलिए रेंज के बाहर की कोशिकाओं के सूचक नहीं बदलते।

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

## **तालिका कोशिकाएँ विभाजित करें**

पिछले उदाहरण में कोशिकाओं को मर्ज करने से तालिका का ग्रिड बरकरार रहता है। एक कोशिका को विभाजित करने से नया ग्रिड स्तम्भ बन सकता है और दाएँ की कोशिकाओं के स्तम्भ सूचक बदल सकते हैं। Aspose.Slides PowerPoint के तालिका ग्रिड मॉडल का अनुसरण करता है।

यह उदाहरण 70‑पॉइंट स्तम्भ और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है और कोशिका `(1, 1)` पर [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) को कॉल करता है। 70‑पॉइंट की आधी चौड़ाई दो समान‑चौड़ाई वाली कोशिकाएँ बनाने के लिए पास की जाती है।

इस विभाजन के बाद, दो आधे `table.get_Item(1, 1)` और `table.get_Item(2, 1)` के रूप में पहुँचे जाते हैं। तालिका ग्रिड अब पाँच स्तम्भ रखता है: मूल रूप से स्तम्भ 2 और 3 में स्थित कोशिकाएँ क्रमशः स्तम्भ 3 और 4 में स्थानांतरित हो जाती हैं। पंक्ति सूचक अपरिवर्तित रहता है। विभाजन के बाद कोशिकाओं को पहुँचते समय इन अद्यतन स्तम्भ सूचकियों का उपयोग करें।

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
[![एक अनमर्ज्ड 70‑पॉइंट कोशिका दो 35‑पॉइंट कोशिकाओं में विभजित होती है, जिससे पाँचवाँ ग्रिड स्तम्भ जुड़ जाता है और दाईं ओर के सूचक बदलते हैं।](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*चौड़ाई विभाजन कोशिका (1, 1) को प्रभावित करता है, शून्य‑आधारित (column, row) सूचक उपयोग करते हुए। अन्य पंक्तियों में एक ही कोशिका दोनों नए स्तम्भ स्थितियों को कवर करती रहती है।*
<!-- visual-explanation:manage-cells:end -->

### **पंक्ति या स्तम्भ स्पैन द्वारा मर्ज्ड कोशिकाएँ विभाजित करें**

मर्ज्ड टेम्पलेट कोशिकाओं को डेटा से भरने की तैयारी के लिए, मौजूदा पंक्ति सीमा के साथ विभाजन करने हेतु [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) या स्तम्भ सीमा के साथ विभाजन करने हेतु [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) का प्रयोग करें।

`index` तर्क विभाजन के ऊपर भाग में पंक्तियों या बाएँ भाग में स्तम्भों की संख्या गिनता है; यह मर्ज्ड क्षेत्र के सापेक्ष होता है:

- पंक्ति विभाजन: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)।
- स्तम्भ विभाजन: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)।

उदाहरण मानता है कि प्रस्तुति की पहली स्लाइड पर पहला शेप एक तालिका है, जिसमें `(1, 2)` और `(1, 3)` को लंबवत रूप से मर्ज किया गया है। नीचे से शुरू करके, यह [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) और [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) का उपयोग करके मूल बिंदु खोजता है और दोनों स्पैन की जाँच करता है। `splitByRowSpan(1)` तब पंक्तियों 2 और 3 को अलग करता है ताकि उत्पाद नाम रखे जा सकें। क्षैतिज दो‑स्तम्भ मर्ज के लिए, `splitByColSpan(1)` प्रयोग करें।

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

        // विभाजन के बाद तालिका से परिणामी कोशिकाओं को प्राप्त करें.
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

तालिका ग्रिड और आसपास की कोशिका सूचकें अपरिवर्तित रहती हैं। परिणामस्वरूप कोशिकाओं को उनके निर्देशांक से प्राप्त करें; यहाँ दोनों की स्पैन 1 है और [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) `false` प्रिंट करता है। बड़े क्षेत्रों को एक विभाजन के बाद भी आंशिक रूप से मर्ज्ड रखा जा सकता है।

मूल टेक्स्ट और उसका फॉर्मेटिंग ऊपर (या बाएँ) कोशिका में रहता है; नई कोशिका खाली होती है लेकिन कोशिका फ़ॉर्मेटिंग जैसे भराव, सीमाएँ और मार्जिन विरासत में लेती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक टेक्स्ट फ़ॉर्मेटिंग स्पष्ट रूप से सेट करें।

सहेजी गई प्रस्तुति में अलग-अलग "Product A" और "Product B" कोशिकाएँ होती हैं, जिनमें टेम्पलेट की कोशिका फ़ॉर्मेटिंग बनी रहती है। विवरण के लिए [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) देखें।

### **विशिष्ट ऊँचाई पर एक कोशिका विभाजित करें**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) ऊपरी भाग की ऊँचाई बिंदुओं में लेता है। [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) ऊपर के भाग में मौजूदा ग्रिड पंक्तियों की संख्या लेता है। दाएँ स्तम्भ में 40‑पॉइंट कोशिका को केन्द्रित करने के लिए, कोशिका की वास्तविक ऊँचाई से 40 घटाएँ और शेष स्थान को ऊपर‑नीचे समान रूप से बाँटें।

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

पहला विभाजन एक ग्रिड पंक्ति जोड़ता है और कोशिका `(1, 1)` में नीचे के 90 पॉइंट छोड़ता है। दूसरा विभाजन उस कोशिका को 40‑पॉइंट मध्य कोशिका और 50‑पॉइंट निचली कोशिका में बाँटता है। दाएँ स्तम्भ अब तीन कोशिकाओं के साथ है, जिनकी ऊँचाई क्रमशः 50, 40 और 50 पॉइंट ऊपर से नीचे तक है। बायीँ कोशिका सभी तीन पंक्तियों को कवर करती है और अपनी मूल 140‑पॉइंट ऊँचाई बनाए रखती है।

![बाएँ कोशिका पूरी तालिका की ऊँचाई को कवर करती है, जबकि दाएँ तीन कोशिकाएँ मध्य में एक 40‑पॉइंट कोशिका के साथ स्थित हैं।](split-by-height.png)

## **तालिका कोशिका पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट स्तम्भ और 50‑पॉइंट पंक्तियों वाली तालिका बनाता है। यह [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) का प्रयोग करके ठोस भराव चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) द्वारा लौटाए गए रंग को लाल सेट करता है, जिससे कोशिका `(2, 3)` (तीसरा स्तम्भ, चौथी पंक्ति) लाल हो जाता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **तालिका कोशिका के भीतर एक छवि जोड़ें**

उदाहरण चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) से लोड करता है और प्रस्तुति की इमेज कलेक्शन में [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) से जोड़ता है। फिर यह छवि को कोशिका `(0, 0)` (तालिका में पहली कोशिका) के पिक्चर फ़िल भराव के रूप में असाइन करता है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) छवि को कोशिका में भरने के लिए खींचता है, जिससे इसका अनुपात बदल सकता है। स्तम्भ चौड़ाई और पंक्ति ऊँचाई बिंदुओं में हैं। लोड की गई छवि को प्रस्तुति में जोड़ने के बाद `finally` ब्लॉक में डिस्पोज़ किया जाता है।

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

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग‑अलग लाइन मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) सीमाओं के अलग‑अलग प्रॉपर्टी होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है।

**यदि मैं पृष्ठभूमि में चित्र सेट करने के बाद स्तम्भ/पंक्ति आकार बदलता हूँ तो छवि क्या करती है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग के साथ, छवि नए कोशिका आकार के अनुसार समायोजित होती है; टाइलिंग के साथ, टाइलें पुनः गणना की जाती हैं।

**क्या मैं पूरे कोशिका की सामग्री पर एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/androidjava/manage-hyperlinks/) को टेक्स्ट (portion) स्तर पर कोशिका के टेक्स्ट फ्रेम में या पूरी तालिका/शेप स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को एक भाग या पूरी कोशिका के टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही कोशिका में विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। एक कोशिका का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (रन) को समर्थन देता है, जिनमें फ़ॉन्ट परिवार, शैली, आकार और रंग जैसी स्वतंत्र फ़ॉर्मेटिंग होती है।