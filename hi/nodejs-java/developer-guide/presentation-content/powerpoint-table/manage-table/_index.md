---
title: जावास्क्रिप्ट में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधित करें
type: docs
weight: 10
url: /hi/nodejs-java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- आस्पेक्ट अनुपात
- पाठ को संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js का उपयोग करके PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सुव्यवस्थित करने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में तालिका जानकारी को प्रदर्शित और व्यक्त करने का एक प्रभावी तरीका है। कोशिकाओं की ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी सीधी और समझने में आसान है।

Aspose.Slides [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) क्लास, [Cell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/) क्लास, और अन्य प्रकार प्रदान करता है जिससे आप सभी प्रकार की प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरू से तालिका बनाएँ**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. `columnWidth` की एक एरे परिभाषित करें।  
4. `rowHeight` की एक एरे परिभाषित करें।  
5. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट को [addTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) मेथड के माध्यम से जोड़ें।  
6. प्रत्येक [Cell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/) पर इटरेट करके शीर्ष, नीचे, दायां और बायां बॉर्डर पर फॉर्मेटिंग लागू करें।  
7. तालिका की पहली पंक्ति की पहली दो कोशिकाएँ मर्ज करें।  
8. एक [Cell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cell/) के [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) को एक्सेस करें।  
9. [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।  
10. संशोधित प्रस्तुति को सहेजें।  

यह JavaScript कोड आपको दिखाता है कि प्रस्तुति में तालिका कैसे बनाई जाए:

```javascript
// एक Presentation क्लास का उदाहरण बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var sld = pres.getSlides().get_Item(0);
    // कॉलम्स को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // स्लाइड में एक टेबल शेप जोड़ता है
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
    // पंक्ति 1 के सेल 1 और 2 को मर्ज करता है
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // मर्ज किए गए सेल में कुछ टेक्स्ट जोड़ता है
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // प्रेज़ेंटेशन को डिस्क पर सहेजता है
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में, कोशिकाओं का क्रमांकन सीधा और शून्य-आधारित होता है। तालिका की पहली कोशिका को 0,0 (स्तंभ 0, पंक्ति 0) के रूप में इंडेक्स किया जाता है।

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका की कोशिकाओं को इस प्रकार क्रमांकित किया गया है:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह JavaScript कोड आपको दिखाता है कि तालिका में कोशिकाओं के क्रमांकन को कैसे निर्दिष्ट किया जाए:

```javascript
// एक Presentation क्लास का उदाहरण बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var sld = pres.getSlides().get_Item(0);
    // स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // स्लाइड में एक टेबल आकार जोड़ता है
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

## **मौजूदा तालिका तक पहुँच**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।  
2. तालिका वाले स्लाइड का इंडेक्स के माध्यम से संदर्भ प्राप्त करें।  
3. एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट बनाएं और उसे null सेट करें।  
4. तालिका मिलने तक सभी [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) ऑब्जेक्ट्स पर इटरेट करें।  

यदि आपको संदेह है कि जिस स्लाइड को आप देख रहे हैं उसमें केवल एक तालिका है, तो आप बस उसमें मौजूद सभी शैप्स की जाँच कर सकते हैं। जब कोई शैप तालिका के रूप में पहचाना जाता है, तो आप उसे [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट में टाइपकास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई तालिकाएँ हैं, तो आपको आवश्यक तालिका को उसके [setAlternativeText(String value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) के माध्यम से खोजना बेहतर रहेगा।  

5. तालिका के साथ काम करने के लिए [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट का उपयोग करें। नीचे के उदाहरण में, हमने तालिका में एक नई पंक्ति जोड़ी।  
6. संशोधित प्रस्तुति को सहेजें।  

यह JavaScript कोड आपको दिखाता है कि मौजूदा तालिका तक कैसे पहुँचा जा सके और उसके साथ काम किया जा सके:

```javascript
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // पहली स्लाइड तक पहुँचता है
    var sld = pres.getSlides().get_Item(0);
    // null TableEx को आरंभीकृत करता है
    var tbl = null;
    // शेप्स पर इटरेट करता है और पाए गए तालिका का संदर्भ सेट करता है
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // दूसरी पंक्ति के पहले कॉलम के लिए टेक्स्ट सेट करता है
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // संशोधित प्रस्तुति को डिस्क पर सहेजता है
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका में टेक्स्ट को संरेखित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट जोड़ें।  
4. तालिका से एक [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) ऑब्जेक्ट को एक्सेस करें।  
5. [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) के [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) को एक्सेस करें।  
6. टेक्स्ट को ऊर्ध्वाधर रूप से संरेखित करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह JavaScript कोड आपको दिखाता है कि तालिका में टेक्स्ट कैसे संरेखित किया जाए:

```javascript
// Presentation क्लास का एक instance बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड को प्राप्त करता है
    var slide = pres.getSlides().get_Item(0);
    // स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // स्लाइड में टेबल आकार जोड़ता है
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // टेक्स्ट फ्रेम तक पहुँचता है
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // टेक्स्ट फ्रेम के लिए Paragraph ऑब्जेक्ट बनाता है
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Paragraph के लिए Portion ऑब्जेक्ट बनाता है
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // टेक्स्ट को ऊर्ध्वाधर रूप से संरेखित करता है
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // प्रेज़ेंटेशन को डिस्क पर सहेजता है
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड से एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Table) ऑब्जेक्ट को एक्सेस करें।  
4. टेक्स्ट के लिए [setFontHeight(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) सेट करें।  
5. [setAlignment(int value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) सेट करें।  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) सेट करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह JavaScript कोड आपको दिखाता है कि तालिका में टेक्स्ट पर अपनी पसंदीदा फॉर्मेटिंग विकल्प कैसे लागू किए जाएँ:

```javascript
// Presentation क्लास का एक instance बनाता है
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // मान लेते हैं कि पहली स्लाइड पर पहला shape एक तालिका है
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // तालिका की कोशिकाओं का फ़ॉन्ट ऊँचाई सेट करता है
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // एक ही कॉल में तालिका की कोशिकाओं का टेक्स्ट संरेखण और दायाँ मार्जिन सेट करता है
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // तालिका की कोशिकाओं का टेक्स्ट वर्टिकल प्रकार सेट करता है
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के लिए शैली गुण प्राप्त करने की सुविधा देता है ताकि आप इन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह JavaScript कोड आपको दिखाता है कि तालिका के प्रीसेट स्टाइल से शैली गुण कैसे प्राप्त किए जाएँ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// डिफ़ॉल्ट शैली प्रीसेट थीम बदलें
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका का आस्पेक्ट अनुपात लॉक करें**

ज्यामितीय आकार का आस्पेक्ट अनुपात विभिन्न आयामों में इसके आकार का अनुपात होता है। Aspose.Slides ने [**setAspectRatioLocked**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) प्रॉपर्टी प्रदान की है जिससे आप तालिकाओं और अन्य शैप्स के लिए आस्पेक्ट अनुपात लॉक कर सकते हैं।

यह JavaScript कोड आपको दिखाता है कि तालिका के लिए आस्पेक्ट अनुपात कैसे लॉक किया जाए:

```javascript
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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्रिय कर सकता हूँ?**  
हां। तालिका एक [setRightToLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/setrighttoleft/) मेथड प्रदान करती है, और पैराग्राफ में भी [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) है। दोनों का उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं अंतिम फ़ाइल में उपयोगकर्ताओं को तालिका को मूव या रीसाइज़ करने से कैसे रोक सकता हूँ?**  
शेपी लॉक का उपयोग करके मूविंग, रीसाइज़िंग, सिलेक्शन आदि को निष्क्रिय कर सकते हैं। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या किसी कोशिका के भीतर छवि को बैकग्राउंड के रूप में डालना समर्थित है?**  
हां। आप किसी कोशिका के लिए [picture fill](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/) सेट कर सकते हैं; चयनित मोड (स्ट्रेच या टाइल) के अनुसार छवि कोशिका क्षेत्र को कवर कर देगी।