---
title: "JavaScript का उपयोग करके प्रस्तुतियों में तालिका सेल प्रबंधित करें"
linktitle: "सेल प्रबंधित करें"
type: docs
weight: 30
url: /hi/nodejs-java/manage-cells/
keywords:
- "तालिका सेल"
- "सेल मर्ज"
- "सीमा हटाएँ"
- "सेल विभाजित करें"
- "सेल में छवि"
- "पृष्ठभूमि रंग"
- PowerPoint
- "प्रस्तुति"
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides के साथ PowerPoint में तालिका सेल प्रबंधित करें। शीघ्रता से सेल तक पहुँच, संशोधन और शैली निर्धारण में निपुण बनें और सहज स्लाइड ऑटोमेशन प्राप्त करें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका सेल तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बतलाता है कि मर्ज किए गए तालिका सेल की पहचान कैसे करें, सेल सीमा को कैसे हटाएँ, सेल को मर्ज या विभाजित करने के बाद क्रमांकण कैसे काम करता है, सेल की पृष्ठभूमि रंग कैसे बदलें, और तालिका सेल के अंदर छवि कैसे जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएँ या खोलें, स्लाइड से तालिका प्राप्त करें, सेल गुणों के माध्यम से सेल स्वरूपण को अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

## **मर्ज किए गए तालिका सेल की पहचान**
1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएं।  
2. पहले स्लाइड से तालिका प्राप्त करें।  
3. मर्ज किए गए सेल खोजने के लिए तालिका की पंक्तियों और स्तंभों में इटररेट करें।  
4. जब मर्ज किए गए सेल मिलें तो संदेश प्रिंट करें।

यह JavaScript कोड आपको दिखाता है कि प्रस्तुति में मर्ज किए गए तालिका सेल की पहचान कैसे करें:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// यह मानते हुए कि Slide#0.Shape#0 एक तालिका है
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका सेल की सीमाएं हटाएँ**
1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. चौड़ाई के साथ कॉलम की एक सरणी परिभाषित करें।  
4. ऊँचाई के साथ पंक्तियों की एक सरणी परिभाषित करें।  
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) मेथड के माध्यम से एक तालिका जोड़ें।  
6. प्रत्येक सेल के शीर्ष, नीचे, दाएँ और बाएँ सीमा को साफ़ करने के लिए इटररेट करें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड आपको दिखाता है कि तालिका सेल से सीमाएं कैसे हटाएँ:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहले स्लाइड तक पहुँचता है
    var sld = pres.getSlides().get_Item(0);
    // चौड़ाई के साथ कॉलम और ऊँचाई के साथ पंक्तियों को परिभाषित करता है
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // स्लाइड में तालिका आकार जोड़ता है
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // प्रत्येक सेल के लिए सीमा स्वरूप सेट करता है
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // PPTX को डिस्क पर लिखता है
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **मर्ज किए गए सेल में क्रमांक**
यदि हम दो जोड़े सेल (1, 1) x (2, 1) और (1, 2) x (2, 2) को मर्ज करते हैं, तो परिणामी तालिका क्रमांकित होगी। यह JavaScript कोड प्रक्रिया को दर्शाता है:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहले स्लाइड तक पहुँचता है
    var sld = pres.getSlides().get_Item(0);
    // चौड़ाई के साथ कॉलम और ऊँचाई के साथ पंक्तियों को परिभाषित करता है
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // स्लाइड में तालिका आकार जोड़ता है
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // प्रत्येक सेल के लिए सीमा स्वरूप सेट करता है
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
    // सेल (1, 1) x (2, 1) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // सेल (1, 2) x (2, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


इसके बाद हम (1, 1) और (1, 2) को मर्ज करके सेल को आगे मर्ज करते हैं। परिणामस्वरूप केंद्र में एक बड़ा मर्ज किया हुआ सेल वाली तालिका बनती है:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहले स्लाइड तक पहुँचता है
    var sld = pres.getSlides().get_Item(0);
    // चौड़ाई के साथ कॉलम और ऊँचाई के साथ पंक्तियों को परिभाषित करता है
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // स्लाइड में तालिका आकार जोड़ता है
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // प्रत्येक सेल के लिए सीमा स्वरूप सेट करता है
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
    // सेल (1, 1) x (2, 1) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // सेल (1, 2) x (2, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // सेल (1, 1) x (1, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **विभाजित सेल में क्रमांक**
पहले के उदाहरणों में, जब तालिका सेल मर्ज हुए, तो अन्य सेल में क्रमांक या क्रम प्रणाली में परिवर्तन नहीं हुआ।  

इस बार, हम एक सामान्य तालिका (बिना मर्ज किए हुए सेल) लेते हैं और फिर (1,1) सेल को विभाजित करके एक विशेष तालिका बनाते हैं। आप इस तालिका के क्रमांक पर ध्यान देना चाहेंगे, जो कुछ अजीब लग सकता है। हालांकि, यही Microsoft PowerPoint तालिका सेल को क्रमांकित करने का तरीका है और Aspose.Slides भी यही करता है।  

यह JavaScript कोड वह प्रक्रिया दर्शाता है जिसका हमने वर्णन किया था:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहले स्लाइड तक पहुँचता है
    var sld = pres.getSlides().get_Item(0);
    // चौड़ाई के साथ कॉलम और ऊँचाई के साथ पंक्तियों को परिभाषित करता है
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // स्लाइड में तालिका आकार जोड़ता है
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // प्रत्येक सेल के लिए सीमा स्वरूप सेट करता है
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
    // सेल (1, 1) x (2, 1) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // सेल (1, 2) x (2, 2) को मर्ज करता है
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // सेल (1, 1) को विभाजित करता है
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **तालिका सेल की पृष्ठभूमि रंग बदलें**

यह JavaScript कोड आपको दिखाता है कि तालिका सेल की पृष्ठभूमि रंग कैसे बदलें:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // एक नई तालिका बनाएं
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // एक सेल के लिए पृष्ठभूमि रंग निर्धारित करें
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **तालिका सेल के अंदर छवि जोड़ें**
1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. चौड़ाई के साथ कॉलम की एक सरणी परिभाषित करें।  
4. ऊँचाई के साथ पंक्तियों की एक सरणी परिभाषित करें।  
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) मेथड के माध्यम से एक तालिका जोड़ें।  
6. छवि फ़ाइल रखने के लिए एक `Images` ऑब्जेक्ट बनाएं।  
7. `IImage` छवि को `PPImage` ऑब्जेक्ट में जोड़ें।  
8. तालिका सेल के लिए `FillFormat` को `Picture` सेट करें।  
9. छवि को तालिका के पहले सेल में जोड़ें।  
10. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड आपको दिखाता है कि तालिका बनाते समय तालिका सेल के अंदर छवि कैसे रखें:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहले स्लाइड तक पहुँचता है
    var islide = pres.getSlides().get_Item(0);
    // चौड़ाई के साथ कॉलम और ऊँचाई के साथ पंक्तियों को परिभाषित करता है
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // स्लाइड में तालिका आकार जोड़ता है
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // छवि फ़ाइल का उपयोग करके PPImage ऑब्जेक्ट बनाता है
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // छवि को पहली तालिका सेल में जोड़ता है
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही सेल के विभिन्न पक्षों के लिए अलग‑अलग लाइन मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [ऊपर](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellformat/getbordertop/)/[नीचे](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[बाएँ](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellformat/getborderleft/)/[दाएँ](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellformat/getborderright/) सीमाओं में अलग‑अलग गुण होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है। यह लेख में प्रदर्शित सेल के प्रति‑पक्ष सीमा नियंत्रण से तर्कसंगत रूप से व्युत्पन्न है।

**यदि मैं एक चित्र को सेल की पृष्ठभूमि के रूप में सेट करने के बाद कॉलम/पंक्ति का आकार बदलता हूँ तो छवि क्या करती है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग पर, छवि नए सेल के अनुरूप समायोजित हो जाती है; टाइलिंग पर, टाइलें फिर से गणना की जाती हैं। लेख में सेल में छवि प्रदर्शित मोड का उल्लेख किया गया है।

**क्या मैं सेल की पूरी सामग्री पर एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/nodejs-java/manage-hyperlinks/) को सेल के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/शेप स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को एक भाग या सेल के सभी टेक्स्ट पर असाइन कर सकते हैं।

**क्या मैं एक ही सेल में अलग‑अलग फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। सेल की टेक्स्ट फ्रेम [portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) (रन) को स्वतंत्र स्वरूपण—फ़ॉन्ट परिवार, शैली, आकार और रंग—के साथ समर्थन देती है।