---
title: JavaScript का उपयोग करके PowerPoint प्रस्तुतियों में SmartArt का प्रबंधन
linktitle: SmartArt प्रबंधन
type: docs
weight: 10
url: /hi/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt टेक्स्ट
- लेआउट प्रकार
- छिपी हुई प्रॉपर्टी
- ऑर्गनाइज़ेशन चार्ट
- चित्र ऑर्गनाइज़ेशन चार्ट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "स्पष्ट JavaScript कोड उदाहरणों का उपयोग करके Aspose.Slides for Node.js के साथ PowerPoint SmartArt को बनाने और संपादित करने की प्रक्रिया सीखें, जो स्लाइड डिज़ाइन और ऑटोमेशन को तेज़ करता है।"
---
## **Overview**

SmartArt एक PowerPoint आरेख है जो नोड, नोड आकार और लेआउट से बनता है। Aspose.Slides for Node.js via Java के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से टेक्स्ट पढ़ सकते हैं, लेआउट बदल सकते हैं, छिपे हुए नोड्स की जाँच कर सकते हैं, ऑर्गनाइज़ेशन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और चित्र ऑर्गनाइज़ेशन चार्ट बना सकते हैं।

## **Get Text from a SmartArt Object**

एक SmartArt नोड में एक या अधिक आकार हो सकते हैं। दृश्यमान टेक्स्ट पढ़ने के लिए, [SmartArt.getAllNodes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartart/#getAllNodes--) को इटरेट करें, फिर [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) द्वारा लौटाए गए [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) को पढ़ें।

```javascript
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
    }
} finally {
    presentation.dispose();
}
```

## **Change the Layout Type of a SmartArt Object**

SmartArt लेआउट यह नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। नीचे दिया गया उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जिसमें [SmartArtLayoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` मान होता है, इसे `BasicProcess` मान में बदलता है, और प्रस्तुति को सहेजता है।

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Check Whether a SmartArt Node Is Hidden**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartnode/ishidden/) बताता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। चयनित लेआउट नोड को दृश्यमान आरेख तत्व के रूप में न दिखा भी सके, फिर भी छिपे हुए नोड्स संरचना में मौजूद हो सकते हैं।

निम्न उदाहरण एक नोड को उस SmartArt ऑब्जेक्ट में जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` मान का उपयोग करता है और नोड की छिपी स्थिति की जाँच करता है।

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Get or Set the Organization Chart Layout**

उन SmartArt आरेखों के लिए जो ऑर्गनाइज़ेशन चार्ट लेआउट का उपयोग करते हैं, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) और [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) यह निर्धारित करते हैं कि चाइल्ड नोड्स पैरेंट नोड के नीचे कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/organizationchartlayouttype/) के आधार पर चाइल्ड नोड्स को बाएँ, दाएँ या दोनों तरफ लटका सकते हैं।

निम्न उदाहरण एक ऑर्गनाइज़ेशन चार्ट बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है।

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Create a Picture Organization Chart**

एक चित्र ऑर्गनाइज़ेशन चार्ट वह SmartArt लेआउट है जो चित्र प्लेसहोल्डर्स वाले पदानुक्रमिक आरेखों के लिए डिज़ाइन किया गया है। स्लाइड में SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें।

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हाँ। जब चयनित SmartArt लेआउट रिवर्सल का समर्थन करता है, तो [SmartArt.setReversed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartart/setreversed/) मेथड आरेख की दिशा को बाएँ‑से‑दाएँ से दाएँ‑से‑बाएँ या वापस बदल देता है।

**मैं एक ही स्लाइड या किसी अन्य प्रस्तुति में SmartArt को फॉर्मेटिंग बनाए रखते हुए कैसे कॉपी कर सकता हूँ?**

आप [ShapeCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/addclone/) के साथ [SmartArt shape को क्लोन]( /slides/hi/nodejs-java/shape-manipulations/) कर सकते हैं या उस पूरी स्लाइड को क्लोन कर सकते हैं जिसमें SmartArt है। दोनों तरीकों से आकार, स्थिति और फॉर्मेटिंग बना रहता है।

**मैं प्रीव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[स्लाइड को रेंडर]( /slides/hi/nodejs-java/convert-powerpoint-to-png/) करें या पूरी प्रस्तुति को PNG या JPEG में बदलें। SmartArt स्लाइड के हिस्से के रूप में रेंडर होता है।

**यदि स्लाइड पर कई SmartArt वस्तुएँ हों तो विशिष्ट SmartArt ऑब्जेक्ट को कैसे ढूँढूँ?**

SmartArt आकार पर एक विशिष्ट [Shape.setAlternativeText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/setalternativetext/) या [Shape.setName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/setname/) सेट करें, फिर [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getShapes) में उस मान को खोजें, और जांचें कि मिलते‑जुलते आकार [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartart/) है या नहीं।