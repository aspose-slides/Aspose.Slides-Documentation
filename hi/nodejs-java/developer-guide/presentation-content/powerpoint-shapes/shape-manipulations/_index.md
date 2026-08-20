---
title: जावास्क्रिप्ट में प्रस्तुति आकारों का प्रबंधन
linktitle: आकार हेरफेर
type: docs
weight: 40
url: /hi/nodejs-java/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रस्तुति आकार
- स्लाइड पर आकार
- आकार खोजें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छुपाएँ
- आकार क्रम बदलें
- इंटरऑप आकार ID प्राप्त करें
- आकार वैकल्पिक पाठ
- आकार लेआउट स्वरूप
- आकार SVG के रूप में
- आकार को SVG में
- आकार संरेखित करें
- आकार फ़्लिप करें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ प्रस्तुति आकारों की पहचान, क्लोन, हटाना, छुपाना, क्रम बदलना, निर्यात, संरेखण और फ़्लिप करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java एक स्लाइड पर आकारों को क्रमबद्ध [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/) के रूप में प्रस्तुत करता है। यह संग्रह न केवल आकारों को खोजने और संशोधित करने की जगह है, बल्कि उनकी स्टैकिंग क्रम का स्रोत भी है: इंडेक्स `0` सबसे पीछे वाला आकार है, जबकि अंतिम इंडेक्स सबसे आगे वाला आकार है।

यह लेख उसी मॉडल का अनुसरण करता है। यह पहले विश्वसनीय रूप से किसी आकार की पहचान कैसे करें समझाता है, फिर आकारों को क्लोन, हटाने, छुपाने और पुनः क्रमबद्ध करने का तरीका दिखाता है। अंतिम अनुभाग लेआउट‑स्तर के फ़ॉर्मेटिंग, SVG निर्यात, संरेखण और फ़्लिप सेटिंग्स को कवर करते हैं। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही ऑपरेशन्स उपयोग कर सकते हैं जो आपके कार्यप्रवाह की आवश्यकता है।

## **आकारों की पहचान और खोज**

जब ज्ञात फ़ाइल को प्रोसेस किया जाता है तो कलेक्शन इंडेक्स सुविधाजनक होते हैं, लेकिन वे स्थायी पहचानकर्ता नहीं होते। आकार को जोड़ने, हटाने या क्रमबद्ध करने से उसका इंडेक्स बदल सकता है। प्रस्तुति के निर्माण और रखरखाव के तरीकों के अनुसार एक पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getname/) डेवलपर‑नियंत्रित टेम्प्लेट्स के लिए उपयोगी है और इसे PowerPoint के Selection Pane में आसानी से देखा जा सकता है। नामों को संपादित किया जा सकता है और उनकी विशिष्टता की गारंटी नहीं होती, इसलिए यदि कोड उन पर निर्भर करता है तो एक नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getalternativetext/) तब उपयोगी है जब एक्सेसिबिलिटी विवरण या लेखक‑द्वारा प्रदान किया गया टैग पहले से ही आकार की पहचान करता है। यह उपयोगकर्ताओं को दिखाई देता है, इसे स्थानीयकृत या एक्सेसिबिलिटी के लिए पुनर्लिखित किया जा सकता है, और इसकी विशिष्टता की गारंटी नहीं होती। सार्थक एक्सेसिबिलिटी टेक्स्ट को चुपचाप डेटाबेस कुंजी के रूप में पुनः उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) एक रीड‑ओनली पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय होता है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले shape ID से मेल खाता है। इसे PowerPoint के साथ एकीकरण करते समय या किसी आकार के जीवनकाल के दौरान स्पष्ट संदर्भ की आवश्यकता होने पर उपयोग करें। एक क्लोन या पुनः निर्मित आकार एक अलग आकार होता है और उसे अपना ID मिलता है।

संबंधित [getUniqueId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getuniqueid/) मेथड प्रस्तुति स्तर पर एक पहचानकर्ता लौटाता है, लेकिन यह पहचानकर्ता ऐड‑इन्स के लिए अभिप्रेत है और पुनः असाइन किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो मैपिंग को एप्लिकेशन डेटा में रखें और सत्यापित करें कि अपेक्षित आकार अभी भी मौजूद है।

निम्न उदाहरण नाम द्वारा सटीक तुलना के साथ खोज करता है और स्लाइड‑स्कोप्ड इंटरऑप ID रिपोर्ट करता है। जब टेम्प्लेट में अपेक्षित आकार नहीं मिलता, तो कोड उस परिणाम की रिपोर्ट करता है बजाय गलत ऑब्जेक्ट के साथ जारी रखने के।

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

जब कोई ऑपरेशन आकार प्रकार के लिए विशिष्ट हो, तो प्रकार‑विशिष्ट सदस्य उपयोग करने से पहले रन‑टाइम क्लास की जाँच करें। यह उदाहरण तब ही टेक्स्ट और ऑल्टरनेटिव टेक्स्ट अपडेट करता है जब नामित ऑब्जेक्ट एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) हो।

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **आकार संग्रह को संशोधित करें**

add, clone, remove और reorder मेथड्स तुरंत संग्रह पर कार्य करते हैं। यदि कोई ऑपरेशन आकारों की संख्या या क्रम को बदलता है, तो उस ऑपरेशन से पहले संग्रहित इंडेक्स पर भरोसा न करें।

### **आकार को क्लोन करें**

[addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/addclone/) एक स्वतंत्र कॉपी बनाता है और उसे लक्ष्य संग्रह में जोड़ता है। [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/insertclone/) भी एक कॉपी बनाता है लेकिन इसे निर्दिष्ट z‑order इंडेक्स पर रखता है। जो ओवरलोड कोऑर्डिनेट्स लेते हैं वे आकार बदले बिना क्लोन को स्थानांतरित करते हैं; चौड़ाई और ऊँचाई वाले ओवरलोड इसे पुनः आकार भी दे सकते हैं।

उदाहरण एक लक्ष्य स्लाइड बनाता है, लेबलयुक्त आयत को आगे क्लोन करता है, और दूसरे क्लोन को पीछे सम्मिलित करता है। दोनों क्लोन में किए गये परिवर्तन मूल आकार को नहीं बदलते।

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

क्लोनिंग आकार की सामग्री और फ़ॉर्मेटिंग, जिसमें उसका नाम और ऑल्टरनेटिव टेक्स्ट शामिल है, को कॉपी करता है। जब इन मानों को अद्वितीय होना आवश्यक हो तो क्लोन को नए तर्कसंगत पहचानकर्ता सौंपें। जटिल आकारों द्वारा उपयोग किए गए संसाधनों को प्रस्तुति संभालती है, लेकिन क्लोन एक नया संग्रह आइटम रहता है जिसके पास नई आकार पहचान होती है।

### **आकार हटाएँ**

[remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/remove/) किसी विशेष आकार ऑब्जेक्ट को उसके संग्रह से हटाता है। इंडेक्स्ड इटरशन के दौरान कई मिलानों को हटाते समय अंत से यात्रा करें ताकि शेष प्रत्येक इंडेक्स वैध रहे।

यह उदाहरण निर्धारित नाम वाले प्रत्येक आकार को हटाता है। यह वर्तमान इंडेक्स पर आकार को पढ़ता है और किसी विशेष आकार प्रकार को मानता नहीं है।

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

हटाने के बाद, आकारों की गिनती और बाद के आकारों के इंडेक्स बदल जाते हैं। अनछुए आकारों के संदर्भ सहेजे गये इंडेक्स की तुलना में अधिक विश्वसनीय रहते हैं। कनेक्टर्स, एनीमेशन और अन्य प्रस्तुति विशेषताओं पर भी विचार करें जो हटाए गये ऑब्जेक्ट को संदर्भित कर सकते हैं; एक दिखाई देने वाले आकार को हटाने से स्लाइड की उपस्थिति से अधिक कुछ बदल सकता है।

### **आकार को छुपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/sethidden/) को `true` पर सेट करने से आकार संग्रह में रहता है लेकिन सामान्य स्लाइड शो में दिखाई नहीं देता। इसका इंडेक्स, फ़ॉर्मेटिंग और सामग्री कोड के लिए उपलब्ध रहती है, इसलिए छुपाना वैकल्पिक तत्वों के लिए उपयुक्त है जिन्हें बाद में पुनः स्थापित किया जा सकता है।

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

छुपाना हटाना या सुरक्षा नहीं है। ऑब्जेक्ट को अभी भी उपयोगकर्ता या कोड द्वारा खोजा और पुनः दृश्यमान किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑क्रम बदलें**

ओवरलैपिंग आकार संग्रह क्रम में पेंट किए जाते हैं। [reorder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/reorder/) मौजूदा आकार को क्लोन किए बिना लक्ष्य इंडेक्स पर ले जाता है। इंडेक्स `0` पीछे है; `size() - 1` सामने है।

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आयत पहले बनाया जाता है और प्रारंभ में दीर्घवृत्त के पीछे रहता है। इसे अंतिम इंडेक्स पर ले जाने से यह आगे आ जाता है। सभी संबंधित आकारों को जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकारों की जाँच**

सामान्य स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स के पास अलग-अलग आकार संग्रह होते हैं। लेआउट संग्रह में एक आकार सामान्य स्लाइड पर समान स्थित आकार नहीं होता। जब आपको लेआउट द्वारा प्रदान किए गए फ़ॉर्मेटिंग को समझने या बदलने की आवश्यकता हो तो लेआउट आकारों की जाँच करें।

निम्न उदाहरण प्रत्येक लेआउट आकार के [FillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getfillformat/) और [LineFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getlineformat/) को पढ़ता है बिना यह माना कि प्रत्येक आकार एक `AutoShape` है।

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

लेआउट को संपादित करने से उसके उपयोग वाली कई स्लाइड्स पर प्रभाव पड़ सकता है। लेआउट आकार को बदलने से पहले निर्धारित करें कि क्या सामान्य स्लाइड ऑब्जेक्ट को विरासत में प्राप्त करती है या स्थानीय रूप से ओवरराइड करती है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकार को SVG में निर्यात करें**

[writeAsSvg](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/writeassvg/) एक आकार की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल आकार होता है, पूरी स्लाइड बैकग्राउंड या पड़ोसी आकार नहीं।

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

रेंडरिंग के दौरान प्रस्तुति को खुला रखें। आउटपुट आकार के फ़ॉर्मेटिंग और फ़ॉन्ट्स एवं छवियों जैसे संसाधनों पर निर्भर है। यदि आपको पूरी संरचना चाहिए, तो व्यक्तिगत आकार के बजाय स्लाइड निर्यात करें। कॉलर को स्ट्रीम का स्वामित्व है और उसे बंद करना चाहिए।

## **आकारों को संरेखित करें**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/alignshapes/) के ओवरलोड सभी आकारों या चयनित संग्रह इंडेक्स को संरेखित करते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapesalignmenttype/) किनारा, केंद्ररेखा, या वितरण मोड निर्दिष्ट करता है। स्लाइड किनारों का उपयोग करने के लिए `alignToSlide` को `true` सेट करें; चयनित आकारों को आपस में सापेक्ष संरेखित करने के लिए इसे `false` सेट करें।

यह उदाहरण तीन आकारों को स्लाइड के शीर्ष किनारे के साथ संरेखित करता है। लौटाए गये आकार संदर्भों को संरेखण से तुरंत पहले उनके वर्तमान इंडेक्स में परिवर्तित किया जाता है।

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

संरेखण स्थितियों को बदलता है, न कि z‑order को। सापेक्ष संरेखण को सामान्यतः कम से कम दो आकारों की आवश्यकता होती है, जबकि क्षैतिज या लंबवत वितरण के लिए पर्याप्त आकार चाहिए जो अन्तराल निर्धारित कर सकें। यदि आप मेथड को कॉल करने से पहले संग्रह को संशोधित करते हैं तो इंडेक्स को पुनः गणना करें।

## **आकार को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और ऊभ्य फ्लिप सेटिंग्स, और घुमाव को संग्रहीत करता है। इसके `getFlipH` और `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ्लिप को सक्षम करता है, `False` इसे अक्षम करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकार रखती है।

![फ़्लिप करने से पहले का आकार](shape_to_be_flipped.png)

यह उदाहरण अन्य सभी फ्रेम मानों को बरकरार रखता है और केवल दो फ्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/setframe/) असाइन करने से सम्पूर्ण फ्रेम बदल जाता है।

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजा गया आकार क्षैतिज और ऊभ्य दोनों दिशा में प्रतिबिंबित किया गया है, जबकि उसकी स्थिति, आकार और घुमाव बरकरार रहता है।

![फ़्लिप करने के बाद का आकार](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकार पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिए जब संग्रह का उपयोग किए जाने से पहले नहीं बदलेगा। निर्मित टेम्प्लेट्स के लिए सत्यापित `Name` या `AlternativeText` नियम को प्राथमिकता दें, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिए `OfficeInteropShapeId` का प्रयोग करें।

**क्या आकार को छुपाने से वह z‑order से हट जाता है?**

नहीं। छुपा हुआ आकार वही इंडेक्स पर संग्रह में बना रहता है। इसे पाया जा सकता है, पुनः क्रमबद्ध किया जा सकता है, संपादित किया जा सकता है या फिर से दृश्यमान किया जा सकता है।

**क्लोन किया हुआ आकार दूसरे आकार के सामने क्यों दिखाई दिया?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order के सामने को दर्शाता है। प्रारंभिक इंडेक्स चुनने के लिये `insertClone` उपयोग करें या सभी आकार जोड़ने के बाद `reorder` करें।