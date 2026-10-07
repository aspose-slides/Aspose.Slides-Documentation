---
title: प्रस्तुतियों में तालिका कोशिकाओं को JavaScript का उपयोग करके प्रबंधित करें
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/nodejs-java/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में PowerPoint तालिका कोशिकाओं का प्रबंधन: मर्ज्ड कोशिकाओं की पहचान करें, सीमाओं को हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for Node.js के माध्यम से Java द्वारा पृष्ठभूमि रंग और छवियों को सेट करें।"
---
## **समीक्षा**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुंचने और उन्हें संशोधित करने की अनुमति देता है। इस लेख में बताया गया है कि कैसे मर्ज्ड तालिका कोशिकाओं की पहचान करें, कोशिका सीमाओं को हटाएँ, कोशिकाओं को मिलाने या विभाजित करने के बाद उनकी क्रमांकिंग के साथ काम करें, कोशिका की पृष्ठभूमि रंग बदलें, और तालिका कोशिका के अंदर एक छवि जोड़ें। उदाहरण दिखाते हैं कि कैसे प्रस्तुति बनाएं या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका स्वरूपण को अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides तालिका कोशिकाओं को एक्सेस करने के लिए शून्य‑आधारित सूचकांक का प्रयोग करता है, क्रम `(column, row)` में।

## **मर्ज्ड तालिका सेल की पहचान**

उदाहरण एक मौजूदा प्रस्तुति खोलता है और पहले स्लाइड पर पहले आकार को तालिका के रूप में एक्सेस करता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार एक तालिका है। फिर यह सभी पंक्तियों और कॉलमों के माध्यम से इटरित करता है और [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) का उपयोग करके मर्ज्ड क्षेत्रों में स्थित कोशिकाओं की पहचान करता है। प्रत्येक मिलान के लिए यह `row;column` क्रम में कोशिका निर्देशांक, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), तथा क्षेत्र की प्रारंभिक निर्देशांक, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) और [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) को प्रिंट करता है।

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

## **तालिका सेल की सीमाएँ हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाइए और उसके पहले स्लाइड में [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) का उपयोग करके एक तालिका जोड़िए। कॉलम चौड़ाई, पंक्ति ऊँचाई, और तालिका का स्थान बिंदु में निर्दिष्ट किया जाता है। उदाहरण सभी चार सेल सीमाओं को [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्य हो जाती हैं।

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

## **तालिका कोशिकाओं को मिलाएँ**

[mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) का उपयोग करके तालिका कोशिकाओं की आयताकार रेंज को एक ही कोशिका में संयोजित करें। रेंज के शीर्ष‑बायें और निचले‑दाएँ कोने की कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क यह नियंत्रित करता है कि क्या मिलान निर्दिष्ट रेंज के बाहर की कोशिकाओं को शामिल कर सकता है; `false` मिलान को उसी रेंज में रखता है।

उदाहरण 70‑पॉइंट कॉलम और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार मध्यवर्ती कोशिकाओं को मिलाता है। resulting कोशिका दो कॉलम और दो पंक्तियों में फैली होती है, जबकि तालिका का आधारभूत ग्रिड चार कॉलम और चार पंक्तियों को बरकरार रखता है। मिलाए गए सेल की सामग्री या स्वरूपण तक पहुँचने के लिए, इस उदाहरण में उसकी शीर्ष‑बायें स्थिति का उपयोग करें: `table.get_Item(1, 1)`। मिलान रेंज में अन्य स्थितियां तालिका ग्रिड का हिस्सा बनी रहती हैं, इसलिए रेंज के बाहर की कोशिकाओं के सूचकांक नहीं बदलते।

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

पिछले उदाहरण में कोशिकाओं को मिलाने से तालिका का ग्रिड बरकरार रहता है। एक कोशिका को विभाजित करने से एक नया ग्रिड कॉलम बन सकता है और दाईं ओर की कोशिकाओं के कॉलम सूचकांक बदल सकते हैं। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का अनुसरण करता है।

यह उदाहरण 70‑पॉइंट कॉलम और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है और सेल `(1, 1)` पर [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) को कॉल करता है। 70‑पॉइंट चौड़ाई का आधा भाग दो समान‑चौड़ाई वाली कोशिकाओं को बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दो आधे हिस्से `table.get_Item(1, 1)` और `table.get_Item(2, 1)` के रूप में एक्सेस होते हैं। तालिका ग्रिड अब पाँच कॉलम रखता है: मूल रूप से कॉलम 2 और 3 में स्थित कोशिकाएँ क्रमशः कॉलम 3 और 4 में चली जाती हैं। पंक्ति सूचकांक समान रहता है। विभाजन के बाद कोशिकाओं को एक्सेस करने के लिए इन अद्यतन कॉलम सूचकांकों का उपयोग करें।

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

### **पंक्ति या कॉलम स्पैन के आधार पर मर्ज्ड कोशिकाओं को विभाजित करें**

डेटा भरने के लिए मर्ज्ड टेम्पलेट कोशिकाओं को तैयार करने हेतु, मौजूदा पंक्ति सीमा के साथ विभाजित करने के लिए [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) और कॉलम सीमा के साथ विभाजित करने के लिए [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) का उपयोग करें।

`index` तर्क विभाजन के ऊपरी हिस्से में पंक्तियों या बाएँ हिस्से में कॉलमों की संख्या गिनता है; यह मर्ज्ड क्षेत्र के सापेक्ष होता है:

- पंक्ति विभाजन: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)।
- कॉलम विभाजन: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)।

उदाहरण यह मानता है कि प्रस्तुति की पहली स्लाइड पर पहला आकार एक तालिका है, जिसमें `(1, 2)` और `(1, 3)` ऊर्ध्वाधर रूप से मर्ज्ड हैं। निचले पद से शुरू करके यह [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) और [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) का उपयोग करके मूल स्थान खोजता है और दोनों स्पैन को जांचता है। `splitByRowSpan(1)` तब उत्पाद नामों के लिए पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो‑कॉलम मर्ज के लिए, `splitByColSpan(1)` का उपयोग करें।

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

तालिका ग्रिड और आसपास की कोशिका सूचकांक अपरिवर्तित रहती हैं। परिणामस्वरूप कोशिकाओं को उनके निर्देशांक से प्राप्त करें; यहाँ दोनों का स्पैन 1 है और [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) `false` प्रिंट करता है। एक विभाजन के बाद बड़ी क्षेत्रों को कुछ हद तक मर्ज्ड रखा जा सकता है।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) कोशिका में रहता है; नई कोशिका खाली होती है लेकिन फ़िल, सीमाएँ और मार्जिन जैसे सेल स्वरूपण को विरासत में लेती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक पाठ स्वरूपण को स्पष्ट रूप से सेट करें।

सेव की गई प्रस्तुति में अलग‑अलग "Product A" और "Product B" कोशिकाएँ होती हैं, जिसमें टेम्पलेट की कोशिका स्वरूपण बरकरार रहती है। विवरण के लिए देखें [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)।

## **तालिका सेल की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट कॉलम और 50‑पॉइंट पंक्तियों वाली तालिका बनाता है। यह [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) का उपयोग करके ठोस फ़िल चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) से प्राप्त रंग को लाल सेट करता है, सेल `(2, 3)` के लिए, जो तीसरे कॉलम और चौथी पंक्ति में स्थित है।

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

## **एक तालिका सेल के भीतर छवि जोड़ें**

उदाहरण चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) से लोड करता है और प्रस्तुति की छवि संग्रह में [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) के साथ जोड़ता है। फिर यह छवि को सेल `(0, 0)`—तालिका की पहली कोशिका—के चित्र फ़िल में असाइन करता है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) छवि को सेल भरने के लिए खींचता है, जिससे उसका अनुपात बदल सकता है। कॉलम चौड़ाई और पंक्ति ऊँचाई बिंदु में हैं। लोड की गई छवि को `finally` ब्लॉक में डिस्पोज़ कर दिया जाता है, उसके प्रस्तुति में जोड़ने के बाद।

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

## **FAQ**

**क्या मैं एक ही सेल के विभिन्न पक्षों के लिए अलग‑अलग लाइन मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) सीमाओं के अलग‑अलग गुण होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली भिन्न हो सकती है।

**यदि मैं चित्र को सेल की पृष्ठभूमि के रूप में सेट करने के बाद कॉलम/पंक्ति आकार बदलूँ तो क्या होता है?**

यह व्यवहार [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग के साथ, चित्र नई सेल के अनुसार समायोजित होता है; टाइलिंग के साथ, टाइलें पुन: गणना की जाती हैं।

**क्या मैं सेल की पूरी सामग्री पर एक हाइपरलिंक जोड़ सकता हूँ?**

[Hyperlinks](/slides/hi/nodejs-java/manage-hyperlinks/) को सेल के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/आकार स्तर पर सेट किया जाता है। व्यावहारिक रूप से, आप लिंक को किसी भाग या सेल के सभी टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही सेल में विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। सेल का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (रन) को स्वतंत्र रूप से फ़ॉर्मेट करने की अनुमति देता है—फ़ॉन्ट परिवार, शैली, आकार, और रंग।