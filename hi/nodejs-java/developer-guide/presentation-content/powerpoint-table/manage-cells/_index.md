---
title: प्रेज़ेंटेशन में जावास्क्रिप्ट का उपयोग करके तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/nodejs-java/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाएँ मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रेज़ेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में PowerPoint तालिका कोशिकाओं का प्रबंधन: मर्ज की गई कोशिकाओं की पहचान करें, सीमाओं को हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for Node.js के द्वारा Java के माध्यम से पृष्ठभूमि रंग और छवियों को सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की सुविधा देता है। यह लेख समझाता है कि मर्ज की गई तालिका कोशिका की पहचान कैसे करें, कोशिका की सीमाएँ हटाएँ, मर्ज या विभाजन के बाद कोशिका क्रमांकन के साथ काम करें, कोशिका की पृष्ठभूमि रंग बदलें, और तालिका कोशिका के अंदर एक छवि जोड़ें। उदाहरण दिखाते हैं कि कैसे प्रस्तुति बनाएं या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका स्वरूपण अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides टेबल कोशिकाओं तक पहुँचने के लिए शून्य-आधारित सूचकांकों का उपयोग करता है, क्रम `(column, row)` में।

## **मर्ज की गई तालिका कोशिका की पहचान करें**

उदाहरण मौजूदा प्रस्तुति को खोलता है और पहले स्लाइड पर पहली आकृति को तालिका के रूप में पहुँचता है। यह मानता है कि स्लाइड और आकृति मौजूद हैं और आकृति एक तालिका है। फिर यह सभी पंक्तियों और स्तम्भों पर इटरेट करता है और [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) का उपयोग करके मर्ज किए गए क्षेत्रों में कोशिकाओं की पहचान करता है। प्रत्येक मिलान के लिए, यह `row;column` क्रम में कोशिका निर्देशांक, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), और क्षेत्र की प्रारंभिक निर्देशांक, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) और [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) प्रिंट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```
## **तालिका कोशिका की सीमाएँ हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाएं और [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) का उपयोग करके इसे पहली स्लाइड पर एक तालिका जोड़ें। स्तम्भ की चौड़ाइयाँ, पंक्ति की ऊँचाइयाँ, और तालिका की स्थिति पॉइंट में निर्दिष्ट हैं। उदाहरण सभी चार कोशिका सीमाओं को [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) सेट करता है, जिससे वे अदृश्य हो जाते हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **कोशिका की विकर्ण सीमाएँ जोड़ें**

विकर्ण रेखा बनाने के लिए [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) का उपयोग करके ऊपर-बाएँ कोने से नीचे‑दाएँ कोने तक एक रेखा बनाएं, और [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) का उपयोग करके नीचे‑बाएँ कोने से ऊपर‑दाएँ कोने तक एक रेखा बनाएं। एक विकर्ण कोना शीर्षक को चिह्नित कर सकता है; दोनों विकर्ण मिलकर X बनाते हैं जिससे कोशिका को लागू नहीं बताया जाता है।

प्रत्येक विकर्ण एक [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) है। इसके [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) में, [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) का उपयोग करके [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) चुनें और [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) के माध्यम से एक रंग चुनें। रेखा की चौड़ाई पॉइंट में [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) से सेट करें।

उदाहरण एक पंक्ति में तीन कोशिकाएँ बनाता है: एक लाल नीचे‑की ओर विकर्ण, एक नीला ऊपर‑की ओर विकर्ण, और दोनों विकर्ण। यह ऊपर, नीचे, बाएँ और दाएँ कोशिका सीमाओं को अपरिवर्तित छोड़ता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

विकर्ण एक स्वरूपण गुण है, न कि कोशिका विभाजन। प्रत्येक कोशिका एकल टेक्स्ट फ्रेम को बनाए रखती है, जिसे [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/) के माध्यम से पहुँचा जाता है; विकर्ण के दोनों तरफ के क्षेत्रों को स्वतंत्र रूप से संपादित नहीं किया जा सकता।

सेव किए गए तालिका, Microsoft PowerPoint में प्रदर्शित:

![तीन तालिका कोशिकाएँ दिखा रही हैं: ऊपर‑बाएँ से नीचे‑दाएँ तक एक लाल विकर्ण, नीचे‑बाएँ से ऊपर‑दाएँ तक एक नीला विकर्ण, और दोनों विकर्ण मिलकर X बनाते हैं।](diagonal-cell-borders.png)

*बाएँ से दाएँ: नीचे‑की ओर विकर्ण (लाल, 3 pt), ऊपर‑की ओर विकर्ण (नीला, 5 pt), और दोनों विकर्ण।*

## **तालिका कोशिकाओं को मिलाएँ**

एक आयताकार कोशिका रेंज को एक कोशिका में संयोजित करने के लिए [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) का उपयोग करें। रेंज के ऊपर‑बाएँ और नीचे‑दाएँ कोनों की कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क यह नियंत्रित करता है कि क्या मर्ज निर्दिष्ट रेंज से बाहर की कोशिकाओं को शामिल कर सकता है; `false` मर्ज को उसी रेंज तक सीमित रखता है।

उदाहरण 4‑×‑4 तालिका बनाता है जिसमें 70‑पॉइंट स्तम्भ और पंक्तियाँ हैं, फिर `(1, 1)` से `(2, 2)` तक के चार मध्य कोशिकाओं को मिलाता है। परिणामस्वरूप कोशिका दो स्तम्भ और दो पंक्तियों को कवर करती है, जबकि तालिका का अंतर्निहित ग्रिड अभी भी चार स्तम्भ और चार पंक्तियों को रखता है। मर्ज की गई कोशिका की सामग्री या स्वरूपण तक पहुँचने के लिए, इस उदाहरण में `table.get_Item(1, 1)` का उपयोग करें। मर्ज रेंज के अन्य स्थान तालिका ग्रिड का भाग बने रहते हैं, इसलिए रेंज के बाहर की कोशिकाओं के सूचकांक नहीं बदलते।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **तालिका कोशिकाओं को विभाजित करें**

पिछले उदाहरण में कोशिकाओं को मिलाने से तालिका का ग्रिड संरक्षित रहता है। किसी कोशिका को विभाजित करने से एक नया ग्रिड स्तम्भ जुड़ सकता है और दाईं ओर की कोशिकाओं के स्तम्भ सूचकांक बदल सकते हैं। Aspose.Slides PowerPoint के तालिका ग्रिड मॉडल का अनुसरण करता है।

यह उदाहरण 4‑×‑4 तालिका बनाता है जिसमें 70‑पॉइंट स्तम्भ और पंक्तियाँ हैं और कोशिका `(1, 1)` पर [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) को कॉल करता है। कोशिका की 70‑पॉइंट चौड़ाई का आधा भाग दो समान‑चौड़ाई वाली कोशिकाएँ बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दो हिस्सों तक `table.get_Item(1, 1)` और `table.get_Item(2, 1)` द्वारा पहुँचा जाता है। तालिका ग्रिड अब पाँच स्तम्भ रखता है: मूलतः स्तम्भ 2 और 3 में स्थित कोशिकाएँ क्रमशः स्तम्भ 3 और 4 में स्थानांतरित हो गई हैं। पंक्ति सूचकांक अपरिवर्तित रहता है। विभाजन के बाद कोशिकाओं तक पहुँचते समय इन अद्यतन स्तम्भ सूचकांकों का उपयोग करें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![एक अनमर्ज्ड 70‑पॉइंट कोशिका दो 35‑पॉइंट कोशिकाओं में विभाजित होती है, पाँचवाँ ग्रिड स्तम्भ जोड़ती है और दाएँ के सूचकांकों को शिफ्ट करती है।](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*चौड़ाई विभाजन कोशिका (1, 1) को प्रभावित करता है, शून्य‑आधारित (column, row) सूचकांकों का उपयोग करके। अन्य पंक्तियों में कोशिका दोनों नई स्तम्भ स्थितियों को कवर करती रहती है।*
<!-- visual-explanation:manage-cells:end -->

### **पंक्ति या स्तम्भ स्पैन द्वारा मर्ज की गई कोशिकाओं को विभाजित करें**

डेटा भरने के लिए मर्ज किए गए टेम्पलेट कोशिकाओं को तैयार करने हेतु, मौजूदा पंक्ति सीमा के साथ विभाजित करने के लिए [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) का उपयोग करें, या स्तम्भ सीमा के साथ विभाजित करने के लिए [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) का उपयोग करें।

`index` तर्क विभाजन के ऊपरी भाग में पंक्तियों या बाएँ भाग में स्तम्भों की गणना करता है; यह मर्ज किए गए क्षेत्र के सापेक्ष होता है:

- पंक्ति विभाजन: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)।
- स्तम्भ विभाजन: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)।

उदाहरण इस बात की अपेक्षा करता है कि प्रस्तुति की पहली स्लाइड पर पहला आकृति एक तालिका हो, जिसमें `(1, 2)` और `(1, 3)` लंबवत मर्ज हों। निचली स्थिति से शुरू करते हुए, यह मूल स्थान खोजने के लिए [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) और [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) का उपयोग करता है और दोनों स्पैन की जाँच करता है। `splitByRowSpan(1)` फिर उत्पाद नामों के लिए पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो‑स्तम्भ मर्ज के लिए, `splitByColSpan(1)` का उपयोग करें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // विभाजन के बाद तालिका से प्राप्त होने वाली कोशिकाओं को पुनः प्राप्त करें।
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

तालिका ग्रिड और आसपास की कोशिका सूचकांक अपरिवर्तित रहते हैं। परिणामी कोशिकाओं को उनके निर्देशांक से प्राप्त करें; यहाँ दोनों का स्पैन 1 है और [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) `false` प्रिंट करता है। बड़े क्षेत्रों को एक विभाजन के बाद भी आंशिक रूप से मर्ज रखा जा सकता है।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) कोशिका में बना रहता है; नई कोशिका खाली होती है लेकिन फ़िल, सीमाएँ और मार्जिन जैसे कोशिका स्वरूपण को विरासत में प्राप्त करती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक किसी भी पाठ स्वरूपण को स्पष्ट रूप से सेट करें।

सेव किया गया प्रस्तुतीकरण अलग-अलग "Product A" और "Product B" कोशिकाएँ रखता है, जिसमें टेम्पलेट की कोशिका स्वरूपण बरकरार रहती है। विवरण के लिए [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) देखें।

### **विशिष्ट ऊँचाई पर एक कोशिका विभाजित करें**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) ऊपरी भाग की ऊँचाई पॉइंट में लेता है। [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) ऊपरी भाग में मौजूदा ग्रिड पंक्तियों की संख्या लेता है। दाएँ स्तम्भ में 40‑पॉइंट कोशिका को केंद्रित करने के लिए, कोशिका की वास्तविक ऊँचाई से 40 घटाएँ और शेष स्थान को ऊपर और नीचे समान रूप से बाँटें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

पहला विभाजन एक ग्रिड पंक्ति जोड़ता है और कोशिका `(1, 1)` में नीचे की 90 पॉइंट छोड़ता है। दूसरा विभाजन उस कोशिका को 40‑पॉइंट मध्य कोशिका और 50‑पॉइंट निचली कोशिका में बाँटता है। दाएँ स्तम्भ में अब ऊपर से नीचे तक 50, 40 और 50 पॉइंट की ऊँचाई वाली तीन कोशिकाएँ हैं। बायीं कोशिका सभी तीन पंक्तियों को कवर करती है और अपनी मूल 140‑पॉइंट ऊँचाई को बरकरार रखती है।

![बायीं कोशिका पूरी तालिका की ऊँचाई को कवर करती है, जबकि मध्य में तीन कोशिकाएँ हैं।](split-by-height.png)

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट स्तम्भ और 50‑पॉइंट पंक्तियों वाली तालिका बनाता है। यह [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) का उपयोग करके ठोस फ़िल चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) द्वारा लौटाए गए रंग को कोशिका `(2, 3)` (तीसरे स्तम्भ और चौथी पंक्ति) के लिए लाल सेट करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **तालिका कोशिका के अंदर एक छवि जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) से लोड करता है और इसे प्रस्तुति की इमेज कलेक्शन में [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) के साथ जोड़ता है। फिर यह छवि को कोशिका `(0, 0)` (तालिका की पहली कोशिका) के चित्र फ़िल में असाइन करता है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) छवि को कोशिका तक फैलाता है, जिससे उसका अनुपात बदल सकता है। स्तम्भ की चौड़ाइयाँ और पंक्ति की ऊँचाइयाँ पॉइंट में हैं। लोड की गई छवि को प्रस्तुति में जोड़ने के बाद `finally` ब्लॉक में नष्ट (dispose) किया जाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग‑अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) सीमाओं की अलग‑अलग प्रॉपर्टी होती है, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग‑अलग हो सकती है।

**यदि मैं कोशिका की पृष्ठभूमि के रूप में चित्र सेट करने के बाद स्तम्भ/पंक्ति का आकार बदलूँ तो छवि के साथ क्या होता है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग पर, छवि नई कोशिका के अनुसार समायोजित होती है; टाइलिंग पर, टाइलें पुनः गणना की जाती हैं।

**क्या मैं कोशिका की सभी सामग्री को एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/nodejs-java/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरे तालिका/shape स्तर पर सेट किया जाता है। व्यावहारिक रूप से, आप लिंक को एक भाग या कोशिका के सभी टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही कोशिका के भीतर अलग‑अलग फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। कोशिका का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (runs) को स्वतंत्र स्वरूपण—फ़ॉन्ट परिवार, शैली, आकार और रंग—के साथ समर्थन करता है।