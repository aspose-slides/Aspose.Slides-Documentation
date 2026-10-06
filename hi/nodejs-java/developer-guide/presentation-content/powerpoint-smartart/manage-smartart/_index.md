---
title: PowerPoint प्रस्तुतियों में JavaScript का उपयोग करके SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधित करें
type: docs
weight: 10
url: /hi/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt टेक्स्ट
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ स्पष्ट JavaScript कोड नमूनों का उपयोग करके PowerPoint SmartArt बनाना और संपादित करना सीखें, जो स्लाइड डिज़ाइन और ऑटोमेशन को तेज करता है।"
---
## **अवलोकन**

SmartArt एक PowerPoint डायग्राम है जो नोड्स, नोड शैप्स और लेआउट से बनाई जाती है। Aspose.Slides for Node.js via Java का उपयोग करके आप SmartArt बना सकते हैं, उसके नोड्स से टेक्स्ट पढ़ सकते हैं, लेआउट बदल सकते हैं, छिपे नोड्स का निरीक्षण कर सकते हैं, ऑर्गेनाइज़ेशन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और चित्र ऑर्गेनाइज़ेशन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से पाठ प्राप्त करें**

एक SmartArt नोड में एक या अधिक शैप्स हो सकते हैं। नोड शैप्स से टेक्स्ट पढ़ने के लिए, [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/) पर इटररेट करें, फिर [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/) द्वारा लौटाए गए [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) को पढ़ें।

उदाहरण के लिए एक प्रेजेंटेशन चाहिए जिसमें कम से कम एक स्लाइड और उस स्लाइड पर पहला शैप एक SmartArt ऑब्जेक्ट हो। यह प्रत्येक उपलब्ध टेक्स्ट फ्रेम को कंसोल में प्रिंट करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt ऑब्जेक्ट का लेआउट प्रकार बदलें**

SmartArt लेआउट नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और कनेक्ट किए जाते हैं। निम्नलिखित उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जिसमें [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` मान है, इसे `BasicProcess` मान में बदलता है, और प्रेजेंटेशन को सेव करता है। [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) को पास किया गया पोजीशन और साइज पॉइंट्स में मापा जाता है। लेआउट बदलने के लिए [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) का उपयोग करें।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **केवल जांचें कि SmartArt नोड छिपा है या नहीं**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) बताता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। छिपे नोड्स संरचना में मौजूद हो सकते हैं जब चयनित लेआउट उन्हें दृश्यमान डायग्राम तत्वों के रूप में नहीं दिखाता।

निम्नलिखित उदाहरण एक SmartArt ऑब्जेक्ट में एक नोड जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` मान का उपयोग करता है और जोड़े गए नोड की छिपी स्थिति की जांच करता है। यदि नोड छिपा है तो यह एक संदेश प्रिंट करता है और डायग्राम को सेव करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Organization Chart लेआउट प्राप्त करें या सेट करें**

उन SmartArt डायग्रामों के लिए जो Organization Chart लेआउट का उपयोग करते हैं, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) और [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) निर्धारित करते हैं कि चाइल्ड नोड्स पैरेंट नोड के तहत कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चाइल्ड नोड्स को बाएँ, दाएँ, या दोनों ओर लटकाने के लिए सेट कर सकते हैं, चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) के आधार पर।

निम्नलिखित उदाहरण एक Organization Chart बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है। शून्य-आधारित इंडेक्स `0` पहला टॉप-लेवल नोड चुनता है; उसके चाइल्ड नोड्स चयनित व्यवस्था का उपयोग करते हैं। संशोधित प्रेजेंटेशन फिर सेव किया जाता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Picture Organization Chart बनाएँ**

Picture Organization Chart एक SmartArt लेआउट है जो ऐसी हायरार्की डायग्रामों के लिए डिज़ाइन किया गया है जिनमें इमेज प्लेसहोल्डर होते हैं। स्लाइड में SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें। यह उदाहरण इमेज प्लेसहोल्डर वाले डायग्राम को सेव करता है; यह प्लेसहोल्डर में इमेज नहीं भरता।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Legacy डायग्राम को शैलियों के समूह में बदलें**

जब आप मौजूदा प्रेजेंटेशन को आधुनिकीकरण कर रहे हों, तो आपको PowerPoint 97–2003 में बनाई गई Organization Chart को अपडेट करना पड़ सकता है। Aspose.Slides इन लेगेसी डायग्रामों को [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) ऑब्जेक्ट के रूप में दर्शाता है। एक डायग्राम को शैलियों के समूह में बदलने के लिए [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) का उपयोग करें, जिससे आप व्यक्तिगत विज़ुअल एलेमेंट्स को एडिट कर सकें। विवरण के लिए [LegacyDiagram API संदर्भ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) देखें।

कन्वर्ज़न शैप कलेक्शन में एक नया समूह जोड़ता है बिना मूल डायग्राम को हटाए। सफल रूपांतरण के बाद, दोहराए गए कंटेंट से बचने के लिए मूल को [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) से हटाएँ। शैलियों को जोड़ने और हटाने से इटरेशन बाधित न हो, इसके लिए लेगेसी डायग्राम को लिस्ट में कलेक्ट करके कन्वर्ट करें।

निम्नलिखित उदाहरण एक प्रेजेंटेशन खोलता है, प्रत्येक स्लाइड की खोज करता है, डायग्राम को शैलियों के समूह में बदलता है, और अपडेटेड प्रेजेंटेशन को PPTX के रूप में सेव करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सेव किया गया प्रेजेंटेशन परिवर्तित लेगेसी डायग्राम की जगह संपादन योग्य शैलियों के समूह रखता है, मूल डायग्राम अब नहीं रहता। PPTX को PowerPoint में खोल कर प्रत्येक समूह के भीतर व्यक्तिगत एलेमेंट्स जैसे टेक्स्ट, फ़िल, या पोजीशन को एडिट कर सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग को समर्थन देता है?**

हाँ। जब चयनित SmartArt लेआउट रिवर्सल का समर्थन करता है, तब [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) मेथड डायग्राम दिशा को बाएँ‑से‑दाएँ से दाएँ‑से‑बाएँ या वापस बदलता है।

**मैं SmartArt को उसी स्लाइड में या किसी अन्य प्रेजेंटेशन में फॉर्मेटिंग सुरक्षित रखते हुए कैसे कॉपी कर सकता हूँ?**

आप [SmartArt shape को क्लोन करें](/slides/hi/nodejs-java/shape-manipulations/) को [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) या [पूरा स्लाइड क्लोन करें](/slides/hi/nodejs-java/clone-slides/) के साथ कॉपी कर सकते हैं। दोनों तरीकों से आकार, पोजीशन और फॉर्मेटिंग संरक्षित रहती है।

**मैं प्रीव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[स्लाइड को रेंडर करें](/slides/hi/nodejs-java/convert-powerpoint-to-png/) या पूरे प्रेजेंटेशन को PNG या JPEG में रेंडर करें। SmartArt स्लाइड का हिस्सा के रूप में रेंडर होता है।

**यदि स्लाइड पर कई SmartArt ऑब्जेक्ट हों तो मैं किसी विशेष SmartArt ऑब्जेक्ट को कैसे ढूँढ़ूँ?**

[Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) या [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) का उपयोग करके SmartArt शैप को एक विशिष्ट अल्टरनेटिव टेक्स्ट या नाम असाइन करें, फिर उस मान को [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) में खोजें, और पुष्टि करें कि मेल खाता शैप एक [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) है।