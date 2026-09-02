---
title: JavaScript में प्रस्तुति आकारों का प्रबंधन
linktitle: आकार हेरफेर
type: docs
weight: 40
url: /hi/nodejs-java/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रस्तुति आकार
- स्लाइड पर आकार
- आकार ढूंढें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छिपाएँ
- आकार क्रम बदलें
- Interop आकार ID प्राप्त करें
- आकार वैकल्पिक पाठ
- आकार समायोजन बिंदु
- पूर्वनिर्धारित आकार समायोजन
- आकार ज्यामिति
- आकार लेआउट स्वरूप
- SVG के रूप में आकार
- आकार को SVG में
- आकार संरेखित करें
- आकार फ़्लिप करें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ प्रस्तुति आकारों की पहचान, समायोजन, क्लोन, हटाना, छिपाना, क्रम बदलना, निर्यात, संरेखण, और फ़्लिप करना सीखें।"
---
## **समीक्षा**

Aspose.Slides for Node.js via Java एक स्लाइड पर आकारों को क्रमबद्ध [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/) के रूप में दर्शाता है। यह संग्रह न केवल आकारों को खोजने और संशोधित करने की जगह है बल्कि उनका स्टैक क्रम भी निर्धारित करता है: इंडेक्स `0` सबसे पिछला आकार है, जबकि अंतिम इंडेक्स सबसे आगे का आकार है।

यह लेख उसी मॉडल का अनुसरण करता है। यह पहले यह बताता है कि किसी आकार को विश्वसनीय रूप से कैसे पहचानें और पूर्वनिर्धारित आकार समायोजन बिंदुओं को कैसे बदलें, फिर क्लोन, हटाना, छिपाना और क्रम बदलना दिखाता है। अंतिम अनुभाग लेआउट‑स्तरीय फ़ॉर्मेटिंग, SVG निर्यात, संरेखण, और फ़्लिप सेटिंग्स को कवर करते हैं। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही ऑपरेशन उपयोग कर सकते हैं जिन्हें आपके कार्यप्रवाह की आवश्यकता है।

## **आकारों की पहचान व खोज**

कलेक्शन इंडेक्स ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थायी पहचानकर्ता नहीं होते। एक आकार को जोड़ने, हटाने या क्रम बदलने से उसका इंडेक्स बदल सकता है। प्रस्तुति के निर्माण और रखरखाव के अनुसार कोई पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getname/) डेवलपर‑नियंत्रित टेम्प्लेट के लिए उपयोगी है और PowerPoint के Selection Pane में आसानी से देखा जाता है। नामों को संपादित किया जा सकता है और वे अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getalternativetext/) उपयोगी है जब कोई पहुंचयोग्यता विवरण या लेखक‑द्वारा प्रदान किया गया टैग पहले से आकार की पहचान करता हो। यह उपयोगकर्ताओं को दिखता है, स्थानीयकृत या पहुंचयोग्यता के लिए पुनः लिखा जा सकता है, और अनिवार्य रूप से अद्वितीय नहीं होता। सार्थक पहुंचयोग्यता पाठ को चुपचाप डेटाबेस कुंजी के रूप में पुनः उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले आकार ID से मेल खाता है। PowerPoint के साथ एकीकरण करते समय या किसी आकार के जीवन‑काल के दौरान अस्पष्ट संदर्भ की आवश्यकता होने पर इसका उपयोग करें। क्लोन या पुनः निर्मित आकार एक अलग आकार होता है और अपना स्वयं का ID प्राप्त करता है।

संबंधित [getUniqueId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getuniqueid/) विधि प्रस्तुति स्तर की पहचानकर्ता लौटाती है, लेकिन वह पहचानकर्ता ऐड‑इन्स के लिए अभिप्रेत है और पुनः सौंपा जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो मैपिंग को एप्लिकेशन डेटा में रखें और सत्यापित करें कि अपेक्षित आकार अभी भी मौजूद है।

निम्नलिखित उदाहरण सटीक तुलना के साथ नाम द्वारा खोज करता है और स्लाइड‑स्कोप्ड इंटरऑप ID रिपोर्ट करता है। जब टेम्प्लेट में अपेक्षित आकार नहीं होता, तो कोड उस परिणाम को रिपोर्ट करता है न कि गलत वस्तु के साथ जारी रहता है।

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

जब कोई ऑपरेश़न आकार प्रकार पर विशेष हो, तो टाइप‑विशिष्ट सदस्य उपयोग करने से पहले रन‑टाइम क्लास जांचें। यह उदाहरण तभी टेक्स्ट और वैकल्पिक टेक्स्ट अपडेट करता है जब नामित वस्तु एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) हो।

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

## **पूर्वनिर्धारित आकार समायोजन की पहचान व संशोधन**

पूर्वनिर्धारित ज्योमेट्री आकार समायोजन बिंदु उजागर कर सकते हैं जो कोना आकार, तीर अनुपात, या ध्रुवीय कोण जैसी सुविधाओं को नियंत्रित करते हैं। इन्हें केवल‑पढ़ने योग्य [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/geometryshape/) संग्रह के माध्यम से एक्सेस करें। संग्रह स्वयं आकार द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [AdjustValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/) में बदलने योग्य मान होता है।

केवल स्थिर संग्रह इंडेक्स पर निर्भर न रहें। समायोजन के माध्यम से इटरैट करें और केवल‑पढ़ने योग्य [getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/) मेथड देखें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapeadjustmenttype/) मान बताता है कि समायोजन क्या नियंत्रित करता है। केवल‑पढ़ने योग्य [getName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/getname/) मेथड अतिरिक्त पहचान जानकारी देती है और विशेष रूप से उपयोगी है जब किसी पूर्वनिर्धारित में समान सेमेंटिक प्रकार के साथ एक से अधिक समायोजन होते हैं।

समायोजन के अर्थ के अनुसार मान मेथड उपयोग करें:

| समायोजन प्रकार | उद्देश्य | परिवर्तन के लिए मान |
|---|---|---|
| `CornerSize` | गोल किनारों का आकार | [setRawValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | तीर की पूंछ की मोटाई | `setRawValue` |
| `ArrowheadLength` | तीर शीर्ष की लंबाई | `setRawValue` |
| `ArrowheadWidth` | तीर शीर्ष की चौड़ाई | `setRawValue` |
| `StartAngle` | पाई या ध्रुवीय कोण की प्रारंभिक कोण | [setAngleValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | पाई या ध्रुवीय कोण की समाप्ति कोण | `setAngleValue` |

`getType` और `getName` केवल‑पढ़ने योग्य जानकारी लौटाते हैं। `getRawValue` और `setRawValue` पूर्वनिर्धारित की मूल ज्योमेट्री इकाइयों में पूर्णांक के साथ काम करते हैं, जबकि `getAngleValue` और `setAngleValue` डिग्री में कोण के साथ काम करते हैं। समायोजन की संख्या, क्रम, अर्थ और वैध सीमा पूर्वनिर्धारित [GeometryShape.getShapeType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/geometryshape/) पर निर्भर करती है। एक पूर्वनिर्धारित के लिए मान्य मान अन्य के लिए अमान्य या अलग प्रभाव डाल सकता है।

जब `getType` `ShapeAdjustmentType.Custom` लौटाता है, तो API मानक सेमेंटिक अर्थ को पहचान नहीं पाती। `getName`, पूर्वनिर्धारित प्रकार, और मौजूदा मान की जाँच करें, और तब तक समायोजन न बदलें जब तक अपेक्षित अर्थ और सीमा ज्ञात न हों। पहचाने गए प्रकारों के लिए भी, यदि समान प्रकार कई बार आता है तो मान चुनने से पहले जाँचें। कनेक्टर बेंड समायोजनों के साथ इस स्थिति को दिखाने वाला लेख [Connector](/slides/hi/nodejs-java/connector/) देखें।

निम्नलिखित पूर्ण उदाहरण तीन पूर्वनिर्धारित आकारों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह प्रत्येक समायोजन के माध्यम से इटरैट करता है, उसका नाम और प्रकार रिपोर्ट करता है, `setRawValue` के माध्यम से आकार‑संबंधी मान बदलता है, `setAngleValue` के माध्यम से कोण बदलता है, और परिणाम सहेजता है। बायाँ कॉलम डिफ़ॉल्ट ज्योमेट्री रखता है; दायाँ कॉलम संशोधित गोल आयत, चार‑मार्गी तीर, और पाई दिखाता है।

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // डिफ़ॉल्ट और समायोजित आकार कॉलम के लिए शीर्षक जोड़ता है।
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

मान बदलने से पहले सेमेंटिक प्रकार की जाँच करने से कोड अपने इरादे को स्पष्ट करता है और यह मानने से बचाता है कि विभिन्न पूर्वनिर्धारित आकारों में एक ही संग्रह इंडेक्स का अर्थ समान हो।

## **Shape Collection में संशोधन**

जोड़ना, क्लोन करना, हटाना और क्रम बदलना सीधे संग्रह पर काम करता है। यदि कोई ऑपरेशन आकारों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गए इंडेक्स पर निर्भरता न रखें।

### **एक Shape को क्लोन करें**

[addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/addclone/) एक स्वतंत्र प्रतिलिपि बनाता है और इसे लक्ष्य संग्रह में जोड़ता है। [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/insertclone/) भी एक प्रतिलिपि बनाता है लेकिन इसे निर्दिष्ट z‑order इंडेक्स पर रखता है। निर्देशांक स्वीकार करने वाले ओवरलोड क्लोन का आकार नहीं बदलते; चौड़ाई और ऊँचाई वाले ओवरलोड इसे रिसाइज़ भी कर सकते हैं।

उदाहरण एक गंतव्य स्लाइड बनाता है, एक लेबल वाले आयत को सामने क्लोन करता है, और दूसरे क्लोन को पीछे डालता है। किसी भी क्लोन में परिवर्तन स्रोत आकार को नहीं बदलते।

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

क्लोन आकार की सामग्री और फ़ॉर्मेटिंग, जिसमें उसका नाम और वैकल्पिक टेक्स्ट शामिल है, को कॉपी करता है। यदि उन मानों को अद्वितीय होना आवश्यक है तो क्लोन को नए तार्किक पहचानकर्ता असाइन करें। जटिल आकारों द्वारा उपयोग किए गए संसाधनों को प्रस्तुति संभालती है, लेकिन क्लोन एक नया संग्रह आइटम होता है जिसका अपना आकार पहचानकर्ता होता है।

### **Shapes को हटाएँ**

[remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/remove/) किसी विशिष्ट आकार वस्तु को उसके संग्रह से हटाता है। इंडेक्स्ड इटरेशन के दौरान कई मिलानों को हटाते समय, प्रत्येक शेष इंडेक्स वैध रहने के लिए अंत से ट्रैवर्स करें।

यह उदाहरण निर्दिष्ट नाम वाले प्रत्येक आकार को हटाता है। यह वर्तमान इंडेक्स पर आकार को पढ़ता है और किसी विशिष्ट आकार प्रकार को मानता नहीं है।

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

हटाने के बाद आकार की संख्या और बाद के आकारों के इंडेक्स बदलते हैं। अप्रभावित आकारों के संदर्भ सहेजे गए इंडेक्स की तुलना में अधिक विश्वसनीय रहते हैं। कनेक्टर, एनीमेशन और अन्य प्रस्तुति सुविधाओं पर भी विचार करें जो हटाए गए वस्तु को संदर्भित कर सकते हैं; एक दृश्य आकार को हटाने से स्लाइड की उपस्थिति से अधिक प्रभाव पड़ सकता है।

### **एक Shape को छिपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/sethidden/) को `true` सेट करने से आकार संग्रह में बना रहता है लेकिन सामान्य स्लाइड शो में दिखाई नहीं देता। इसका इंडेक्स, फ़ॉर्मेटिंग, और सामग्री कोड के लिए उपलब्ध रहती है, इसलिए वैकल्पिक तत्वों के लिए जो बाद में पुनः प्रदर्शित किए जा सकते हैं, छिपाना उपयुक्त है।

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

छिपाना हटाना या सुरक्षा नहीं है। वस्तु अभी भी उपयोगकर्ता या कोड द्वारा खोजी और अनहिडन की जा सकती है, और यह प्रस्तुति फ़ाइल का हिस्सा बनी रहती है।

### **Z‑Order बदलें**

एक-दूसरे के ऊपर वाले आकार संग्रह क्रम में चित्रित होते हैं। [reorder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/reorder/) एक मौजूदा आकार को लक्ष्य इंडेक्स पर ले जाता है बिना क्लोन किए। इंडेक्स `0` पीछे है; `size() - 1` आगे है।

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

आयत पहले बनाया जाता है और प्रारंभ में दीर्घवृत्त के पीछे रहता है। अंतिम इंडेक्स पर ले जाने से वह सामने आता है। सभी सम्बंधित आकार जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नई संग्रह आइटम जोड़ते या डालते हैं और इच्छित स्टैक को बदल सकते हैं।

## **Layout Slides पर Shapes की जाँच**

सामान्य स्लाइड, लेआउट स्लाइड, और मास्टर स्लाइड के अलग-अलग आकार संग्रह होते हैं। लेआउट संग्रह में एक आकार सामान्य स्लाइड पर समान स्थित आकार के समान वस्तु नहीं होता। लेआउट द्वारा प्रदान किए गए फ़ॉर्मेट को समझने या बदलने की आवश्यकता होने पर लेआउट आकारों की जाँच करें।

निम्नलिखित उदाहरण प्रत्येक लेआउट आकार की [FillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getfillformat/) और [LineFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getlineformat/) को पढ़ता है, बिना यह मानते हुए कि हर आकार `AutoShape` है।

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

लेआउट को संपादित करने से उस लेआउट का उपयोग करने वाली कई स्लाइड प्रभावित हो सकती हैं। लेआउट आकार बदलने से पहले निर्धारित करें कि क्या सामान्य स्लाइड वस्तु को विरासत में लेती है या स्थानीय ओवरराइड रखती है, और उस लेआउट का उपयोग करने वाली हर स्लाइड का परीक्षण करें।

## **Shape को SVG के रूप में निर्यात करें**

[writeAsSvg](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/writeassvg/) एक आकार की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल आकार होता है, पूरी स्लाइड पृष्ठभूमि या आस‑पास के आकार नहीं।

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

रेंडरिंग के दौरान प्रस्तुति खुली रखें। आउटपुट आकार के फ़ॉर्मेटिंग तथा फ़ॉन्ट और छवियों जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी संगीती चाहिए तो व्यक्तिगत आकार के बजाय स्लाइड निर्यात करें। कॉलर स्ट्रीम का स्वामी होता है और उसे बंद करना पड़ता है।

## **Shapes को संरेखित करें**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/alignshapes/) ओवरलोड सभी आकारों या चयनित संग्रह इंडेक्स को संरेखित करता है। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapesalignmenttype/) किनारा, मध्य रेखा, या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` सेट करने से स्लाइड किनारों का उपयोग होता है; `false` सेट करने से चयनित आकार एक‑दूसरे के सापेक्ष संरेखित होते हैं।

यह उदाहरण तीन आकारों को स्लाइड के शीर्ष किनारे के साथ संरेखित करता है। संरेखण से पहले लौटाए गए आकार संदर्भ उनके वर्तमान इंडेक्स में बदल दिए जाते हैं।

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

संरेखण स्थितियों को बदलता है, न कि z‑order को। सापेक्ष संरेखण के लिए आमतौर पर कम से कम दो आकार आवश्यक होते हैं, जबकि क्षैतिज या लंबवत वितरण के लिए पर्याप्त आकार चाहिए ताकि स्पेसिंग निर्धारित हो सके। विधि कॉल करने से पहले संग्रह में परिवर्तन करने पर इंडेक्स पुनः गणना करें।

## **Shape को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और लंबवत फ़्लिप सेटिंग्स, तथा रोटेशन संग्रहीत करता है। इसके `getFlipH` और `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप सक्रिय करता है, `False` निष्क्रिय करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को बनाए रखता है।

नीचे दिया गया इनपुट प्रेजेंटेशन एक अनफ़्लिप्ड आकार रखता है।

![फ़्लिप करने से पहले का आकार](shape_to_be_flipped.png)

उदाहरण सभी अन्य फ्रेम मानों को सुरक्षित रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/setframe/) असाइन करने से पूरा फ्रेम प्रतिस्थापित हो जाता है।

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

सहेजा गया आकार क्षैतिज और लंबवत रूप से मिरर किया गया है जबकि उसकी स्थिति, आकार, और रोटेशन वही रहता है।

![फ़्लिप करने के बाद का आकार](flipped_shape.png)

## **FAQ**

**क्या मुझे आकार पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिए जब संग्रह ऑपरेशन से पहले नहीं बदलेगा। टेम्प्लेट के लिए सत्यापित `Name` या `AlternativeText` नियम अपनाएँ, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिए `OfficeInteropShapeId` उपयोग करें।

**क्या आकार को छिपाने से वह z‑order से हट जाता है?**

नहीं। छिपा हुआ आकार उसी इंडेक्स पर संग्रह में बना रहता है। इसे पाया, क्रम बदला, संपादित या फिर से दिखाई दिया जा सकता है।

**क्लोन किया हुआ आकार दूसरे आकार के सामने क्यों दिखाई दिया?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order का सामने वाला हिस्सा है। प्रारंभिक इंडेक्स चुनने के लिए `insertClone` उपयोग करें या सभी आकार जोड़ने के बाद `reorder` करें।

**क्या मैं पूर्वनिर्धारित आकार समायोजन की पहचान के लिए स्थिर इंडेक्स उपयोग कर सकता हूँ?**

केवल तभी जब आप सटीक पूर्वनिर्धारित और संग्रह लेआउट की पुष्टि कर चुके हों। `GeometryShape.getAdjustments` को इटरैट करके और `AdjustValue.getType` जांचना पसंद करें; जब समान सेमेंटिक प्रकार कई बार आता है तो अतिरिक्त जानकारी के लिए `AdjustValue.getName` उपयोग करें।