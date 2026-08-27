---
title: JavaScript में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/nodejs-java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएँ
- तालिका तक पहुँचें
- आस्पेक्ट अनुपात
- टेक्स्ट संरेखित करें
- टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सुव्यवस्थित करने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में एक तालिका जानकारी को प्रदर्शित और प्रस्तुत करने का एक प्रभावी तरीका है। सेल्स के ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी सीधी और समझने में आसान होती है।

Aspose.Slides एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) क्लास, [Cell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/) क्लास, और अन्य टाइप्स प्रदान करता है जिससे आप सभी प्रकार की प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरुआत से तालिका बनाना**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. `columnWidth` का एक एरे परिभाषित करें।
4. `rowHeight` का एक एरे परिभाषित करें।
5. [addTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) मेथड के माध्यम से स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट जोड़ें।
6. प्रत्येक [Cell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/) के माध्यम से इटररेट करके टॉप, बॉटम, राइट और लेफ्ट बॉर्डर्स पर फ़ॉर्मेटिंग लागू करें।
7. तालिका के टॉप-लेफ़्ट कोने (पहली दो पंक्तियों के पहले दो स्तंभ) के चार सेल्स को एक ही सेल में मर्ज करें। 
8. एक [Cell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुंचें।
9. [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
10. परिवर्तित प्रस्तुतिकरण को सहेजें।

This JavaScript code shows you how to create a table in a presentation:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक Presentation क्लास का उदाहरण बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुंचता है
    var sld = pres.getSlides().get_Item(0);
    // स्तंभों की चौड़ाई और पंक्तियों की ऊँचाई परिभाषित करता है
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // स्लाइड में एक तालिका आकार जोड़ता है
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // ऊपरी-बाएँ 2x2 ब्लॉक के सेल्स को एक सेल में मर्ज करता है
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // मर्ज किए गए सेल में कुछ टेक्स्ट जोड़ता है
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में सेल्स की क्रमांकन सरल और शून्य-आधारित होती है। तालिका का पहला सेल 0,0 (स्तंभ 0, पंक्ति 0) के रूप में अनुक्रमित होता है। 

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका में सेल्स इस प्रकार क्रमांकित होते हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This JavaScript code shows you how to specify the numbering for cells in a table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक Presentation क्लास का उदाहरण बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुंचता है
    var sld = pres.getSlides().get_Item(0);
    // स्तंभों की चौड़ाई और पंक्तियों की ऊँचाई परिभाषित करता है
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // स्लाइड में एक तालिका आकार जोड़ता है
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // प्रेज़ेंटेशन को डिस्क पर सहेजता है
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **मौजूदा तालिका तक पहुंच**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।

2. इंडेक्स के माध्यम से तालिका वाली स्लाइड का संदर्भ प्राप्त करें। 

3. एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट बनाएं और उसे null सेट करें।

4. सभी [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) ऑब्जेक्ट्स के माध्यम से इटररेट करें जब तक तालिका नहीं मिल जाती।  
यदि आपको संदेह है कि जिस स्लाइड को आप संभाल रहे हैं उसमें केवल एक तालिका है, तो आप बस उसके सभी शैप्स की जाँच कर सकते हैं। जब कोई शैप तालिका के रूप में पहचाना जाता है, तो आप उसे एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट में टाइपकास्ट कर सकते हैं। लेकिन यदि उस स्लाइड में कई तालिकाएँ हैं, तो आपको आवश्यक तालिका को उसके [setAlternativeText(String value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) के माध्यम से खोजना बेहतर रहेगा।

5. [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट का उपयोग करके तालिका के साथ काम करें। नीचे दिए गए उदाहरण में, हम तालिका के एक सेल का टेक्स्ट सेट करते हैं।

6. परिवर्तित प्रस्तुतिकरण को सहेजें।

This JavaScript code shows you how to access and work with an existing table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// एक Presentation क्लास का उदाहरण बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // पहली स्लाइड तक पहुंचता है
    var sld = pres.getSlides().get_Item(0);
    // null TableEx को प्रारंभ करता है
    var tbl = null;
    // शेप्स के माध्यम से इटररेट करता है और पाए गए तालिका के लिए एक संदर्भ सेट करता है
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // दूसरी पंक्ति के पहले स्तंभ के लिए टेक्स्ट सेट करता है
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // परिवर्तित प्रस्तुतीकरण को डिस्क पर सहेजता है
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **उस सेल को ढूंढें जो टेक्स्ट फ़्रेम का मालिक है**

जब सामान्य टेक्स्ट-प्रोसेसिंग कोड को तालिका से एक [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) प्राप्त होता है, तो मालिक [Cell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/) को प्राप्त करने के लिए [TextFrame.getParentCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentCell--) मेथड का उपयोग करें। एक तालिका-सेल टेक्स्ट फ़्रेम के लिए, [TextFrame.getParentCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentCell--) मालिक को लौटाता है और [TextFrame.getParentShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentShape--) `null` लौटाता है, भले ही तालिका स्वयं एक शैप हो।

सेल कोऑर्डिनेट्स पढ़ने-केवल [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) और [Cell.getFirstRowIndex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) मेथड्स के माध्यम से उपलब्ध हैं। [TextFrame.getParentCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentCell--) भी पढ़ने-केवल नेविगेशन प्रदान करता है: यह मालिक को लौटाता है लेकिन स्वामित्व नहीं बदलता। हमेशा उपयोग करने से पहले लौटाए गए सेल को `null` के लिए जाँचें।

टेबल-सेल और शैप मालिकों की पहचान करने वाले पूर्ण उदाहरण के लिए, जिसमें SmartArt नोड्स से जुड़े शैप्स भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/nodejs-java/search-and-replace-text/)।

## **तालिका में टेक्स्ट संरेखित करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) ऑब्जेक्ट तक पहुंचें।
5. [TextFrame] के [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) तक पहुंचें।
6. टेक्स्ट को लंबवत रूप से संरेखित करें।
7. परिवर्तित प्रस्तुतिकरण को सहेजें।

This JavaScript code shows you how to align the text in a table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Creates an instance of the Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Gets the first slide
    var slide = pres.getSlides().get_Item(0);
    // Defines columns with widths and rows with heights
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Adds the table shape to the slide
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Accesses the text frame
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Creates the Paragraph object for the text frame
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Creates the Portion object for paragraph
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Aligns the text vertically
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Saves the presentation to disk
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेबल स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें। 
3. स्लाइड से एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट तक पहुंचें।
4. टेक्स्ट के लिए [setFontHeight(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) सेट करें।
5. [setAlignment(int value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) सेट करें।
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) सेट करें।
7. परिवर्तित प्रस्तुतिकरण को सहेजें। 

This JavaScript code shows you how to apply your preferred formatting options to the text in a table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation क्लास का एक इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // मान लेते हैं कि पहली स्लाइड पर पहला आकार एक तालिका है
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // तालिका कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // एक कॉल में तालिका कोशिकाओं का टेक्स्ट संरेखण और दायाँ मार्जिन सेट करता है
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // तालिका कोशिकाओं का टेक्स्ट वर्टिकल टाइप सेट करता है
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेबल शैली प्रीसेट सेट करें**

Aspose.Slides निर्मित PowerPoint तालिका शैलियों को [TableStylePreset](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tablestylepreset/) एनोमेरेशन के रूप में प्रदान करता है, जिससे आप किसी भी तालिका पर समान लुक लागू कर सकते हैं। यह JavaScript कोड दिखाता है कि तालिका की डिफ़ॉल्ट शैली को प्रीसेट शैली से कैसे बदला जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// डिफ़ॉल्ट स्टाइल प्रीसेट थीम बदलें
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेबल का आस्पेक्ट अनुपात लॉक करें**

ज्यामितीय आकार का आस्पेक्ट अनुपात विभिन्न आयामों में उसके आकारों का अनुपात होता है। Aspose.Slides ने तालिकाओं और अन्य आकारों के लिए आश्पेक्ट अनुपात सेटिंग को लॉक करने हेतु [**setAspectRatioLocked**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) प्रॉपर्टी प्रदान की है।

This JavaScript code shows you how to lock the aspect ratio for a table:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या मैं पूरी तालिका और उसके सेल्स में टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) रीडिंग दिशा सक्षम कर सकता हूँ?**

हाँ। तालिका एक [setRightToLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/setrighttoleft/) मेथड प्रदान करती है, और पैराग्राफ में [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) उपलब्ध है। दोनों का उपयोग करने से सेल्स के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को हिलाने या आकार बदलने से कैसे रोक सकता हूँ?**

हल्के, आकार बदलने, चयन आदि को निष्क्रिय करने के लिए शैप लॉक का उपयोग करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या एक सेल के अंदर बैकग्राउंड के रूप में इमेज डालना समर्थित है?**

हां। आप किसी सेल के लिए [picture fill](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) सेट कर सकते हैं; इमेज चयनित मोड (स्ट्रैच या टाइल) के अनुसार सेल क्षेत्र को कवर कर देगी।