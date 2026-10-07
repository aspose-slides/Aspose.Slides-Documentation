---
title: एंड्रॉयड पर प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/androidjava/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं का मिलान
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "एंड्रॉयड पर PowerPoint तालिका कोशिकाओं का प्रबंधन: मिलाए गए कोशिकाओं की पहचान करें, सीमा रेखाएँ हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for Android का उपयोग करके Java के माध्यम से पृष्ठभूमि रंग तथा छवियों को सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुति में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख merged तालिका कोशिकाओं की पहचान करने, कोशिका सीमा रेखाएँ हटाने, मर्ज या स्प्लिट करने के बाद कोशिका क्रमांक के साथ काम करने, कोशिका की पृष्ठभूमि रंग बदलने, और तालिका कोशिका के भीतर छवि जोड़ने के तरीकों को समझाता है। उदाहरण दर्शाते हैं कि कैसे प्रस्तुति बनाइए या खोलिए, स्लाइड से तालिका प्राप्त कीजिए, कोशिका गुणों के माध्यम से कोशिका स्वरूपण अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides तालिका कोशिकाओं तक पहुँचने के लिए शून्य-आधारित सूचकांक का उपयोग करता है, क्रम `(column, row)` में।

## **Merged तालिका कोशिका की पहचान करें**

उदाहरण एक मौजूदा प्रस्तुति खोलता है और पहली स्लाइड पर पहले आकार को तालिका के रूप में पहुँचता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार एक तालिका है। फिर यह सभी पंक्तियों और स्तंभों पर इटररेट करता है और [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) का उपयोग करके merged क्षेत्रों में कोशिकाओं की पहचान करता है। प्रत्येक मिलान के लिए यह `row;column` क्रम में कोशिका निर्देशांक, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), और क्षेत्र की प्रारंभिक निर्देशांक, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) तथा [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) को प्रिंट करता है।

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

## **तालिका कोशिका सीमा रेखाएँ हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) बनाइए और उसकी पहली स्लाइड पर [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) का उपयोग करके एक तालिका जोड़िए। स्तंभ चौड़ाई, पंक्ति ऊँचाई, और तालिका की स्थिति बिंदुओं में निर्दिष्ट की गई है। उदाहरण सभी चार कोशिका सीमा रेखाओं को [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्य हो जाती हैं।

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

## **तालिका कोशिकाओं को मर्ज करें**

[mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) का उपयोग करके तालिका कोशिकाओं की आयताकार सीमा को एक कोशिका में मिलाएँ। सीमा के शीर्ष‑बाएँ और नीचे‑दाएँ कोने की कोशिकाएँ निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि क्या मर्ज निर्दिष्ट सीमा के बाहर की कोशिकाओं को शामिल कर सकता है; `false` मर्ज को उसी सीमा के भीतर रखता है।

उदाहरण 70‑पॉइंट स्तंभ और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार केंद्रीय कोशिकाओं को मर्ज करता है। परिणामी कोशिका दो स्तंभ और दो पंक्तियों में फैली होती है, जबकि तालिका का मूल ग्रिड चार स्तंभ और चार पंक्तियों को बरकरार रखता है। मर्ज की गई कोशिका की सामग्री या स्वरूपण तक पहुँचने के लिए शीर्ष‑बाएँ स्थिति का उपयोग करें: इस उदाहरण में `table.get_Item(1, 1)`। मर्ज सीमा के बाहर की कोशिकाओं के सूचकांक नहीं बदलते।

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

पिछले उदाहरण में कोशिकाओं को मर्ज करने से तालिका का ग्रिड बना रहता है। एक कोशिका को विभाजित करने से नई ग्रिड स्तंभ बन सकता है और उसकी दाएँ की कोशिकाओं के स्तंभ सूचकांक बदल सकते हैं। Aspose.Slides PowerPoint के तालिका ग्रिड मॉडल का अनुसरण करता है।

यह उदाहरण 70‑पॉइंट स्तंभ और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है और कोशिका `(1, 1)` पर [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) को कॉल करता है। कोशिका की 70‑पॉइंट चौड़ाई का आधा भाग दो समान‑चौड़ाई वाली कोशिकाएँ बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दो भागों को `table.get_Item(1, 1)` तथा `table.get_Item(2, 1)` के रूप में पहुँचा जाता है। तालिका ग्रिड अब पाँच स्तंभ रखता है: मूलतः स्तंभ 2 और 3 में स्थित कोशिकाएँ क्रमशः स्तंभ 3 और 4 में स्थानांतरित हो जाती हैं। पंक्तियों के सूचकांक अपरिवर्तित रहते हैं। विभाजन के बाद कोशिकाओं तक पहुँचते समय इन अद्यतन स्तंभ सूचकांकों का उपयोग करें।

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

### **पंक्ति या स्तंभ स्पैन के द्वारा मर्ज की गई कोशिकाओं को विभाजित करें**

डेटा भरने के लिए मर्ज किए गए टेम्पलेट कोशिकाओं को तैयार करने हेतु, मौजूदा पंक्ति सीमा पर विभाजित करने के लिए [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) और स्तंभ सीमा पर विभाजित करने के लिए [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) का उपयोग करें।

`index` तर्क विभाजन के ऊपरी भाग में पंक्तियों या बाएँ भाग में स्तंभों की संख्या को गिनता है; यह मर्ज किए गए क्षेत्र के सापेक्ष है:

- पंक्ति विभाजन: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)।
- स्तंभ विभाजन: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)।

उदाहरण मानता है कि प्रस्तुति की पहली स्लाइड पर पहला आकार एक तालिका है, जिसमें `(1, 2)` तथा `(1, 3)` लंबवत रूप से मर्ज किए गए हैं। नीचे की स्थिति से शुरू करके यह [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) तथा [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) का उपयोग करके मूल निर्धारित करता है और दोनों स्पैन की जाँच करता है। `splitByRowSpan(1)` फिर उत्पाद नामों के लिए पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो‑स्तंभ मर्ज के लिए इसके बजाय `splitByColSpan(1)` का उपयोग करें।

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

तालिका ग्रिड और आस‑पास की कोशिका सूचकांक अप्रभावित रहते हैं। परिणामी कोशिकाओं को उनके निर्देशांक से पुनः प्राप्त करें; यहाँ दोनों की स्पैन 1 है और [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) `false` प्रिंट करता है। एक विभाजन के बाद भी बड़े क्षेत्रों को आंशिक रूप से मर्ज रखा जा सकता है।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) वाली कोशिका में बना रहता है; नई कोशिका खाली होती है लेकिन भराव, सीमा रेखा और मार्जिन जैसे कोशिका स्वरूपण को उत्तराधिकार प्राप्त करती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक पाठ स्वरूपण स्पष्ट रूप से सेट करें।

संचित प्रस्तुति में अलग‑अलग “Product A” और “Product B” कोशिकाएँ होती हैं, जिसमें टेम्पलेट की कोशिका स्वरूपण बरकरार रहती है। विवरण के लिए देखें [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/)।

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट स्तंभ और 50‑पॉइंट पंक्तियों के साथ एक तालिका बनाता है। यह [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) का उपयोग करके ठोस भराव चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) द्वारा लौटाए गए रंग को लाल सेट करता है, जो कोशिका `(2, 3)` (तीसरे स्तंभ और चौथी पंक्ति) के लिए है।

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

## **एक तालिका कोशिका के भीतर छवि जोड़ें**

उदाहरण चलाने से पहले इनपुट छवि को कार्यशील निर्देशिका में रखें। यह छवि को [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) से लोड करता है और उसे प्रस्तुति के इमेज कलेक्शन में [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) से जोड़ता है। फिर यह छवि को `(0, 0)` कोशिका (तालिका की पहली कोशिका) के पिक्चर फिल में असाइन करता है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) छवि को कोशिका में भरने के लिए फैलाता है, जिससे उसका अनुपात बदल सकता है। स्तंभ चौड़ाई और पंक्ति ऊँचाई बिंदुओं में दी गई है। लोड की गई छवि को `finally` ब्लॉक में डिस्पोज़ कर दिया जाता है, जब इसे प्रस्तुति में जोड़ दिया जाता है।

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

**क्या मैं एक ही कोशिका के अलग‑अलग पक्षों के लिए विभिन्न रेखा मोटाई और शैली सेट कर सकता हूँ?**

हां। [ऊपर](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[नीचे](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[बाएँ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[दाएँ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) सीमा रेखाओं की अलग‑अलग गुण होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है।

**यदि मैं चित्र को कोशिका की पृष्ठभूमि के रूप में सेट करने के बाद स्तंभ/पंक्ति का आकार बदलूँ तो छवि का क्या होता है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेच करने पर छवि नई कोशिका के अनुसार समायोजित होती है; टाइल करने पर टाइलें पुनः गणना की जाती हैं।

**क्या मैं कोशिका की सभी सामग्री को हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/androidjava/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/shape स्तर पर सेट किया जाता है। व्यावहारिक रूप से आप लिंक को किसी पोर्शन या पूरी कोशिका के टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही कोशिका में विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हां। कोशिका का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (रन) को सपोर्ट करता है, जिनमें फॉन्ट फ़ैमिली, शैली, आकार और रंग स्वतंत्र रूप से सेट किया जा सकता है।