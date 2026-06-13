---
title: JavaScript का उपयोग करके प्रस्तुतियों में SmartArt ग्राफ़िक्स प्रबंधित करें
linktitle: SmartArt ग्राफ़िक्स
type: docs
weight: 20
url: /hi/nodejs-java/manage-smartart-shape/
keywords:
- SmartArt ऑब्जेक्ट
- SmartArt ग्राफ़िक
- SmartArt शैली
- SmartArt रंग
- SmartArt बनाएं
- SmartArt जोड़ें
- SmartArt संपादित करें
- SmartArt बदलें
- SmartArt तक पहुंचें
- SmartArt लेआउट प्रकार
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके JavaScript में PowerPoint SmartArt निर्माण, संपादन और शैलीकरण को स्वचालित करें, संक्षिप्त कोड उदाहरण और प्रदर्शन-केंद्रित मार्गदर्शन प्रदान करते हुए।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में SmartArt ग्राफ़िक्स बनाने और प्रबंधित करने की अनुमति देता है। यह लेख बताता है कि स्लाइड में SmartArt आकृति कैसे जोड़ें, मौजूदा SmartArt आकृतियों तक कैसे पहुँचें, किसी विशिष्ट लेआउट प्रकार से SmartArt कैसे खोजें, और SmartArt शैली या रंग शैली बदलकर उसकी दृश्य उपस्थिति को अपडेट कैसे करें।

उदाहरण दिखाते हैं कि प्रस्तुति स्लाइड की आकृति संग्रह के माध्यम से SmartArt आकृतियों के साथ कैसे काम किया जाए, यह जांचें कि कोई आकृति SmartArt है या नहीं, और फिर उसकी गुणधर्मों को संशोधित या निरीक्षण करें।

## **SmartArt आकृति बनाएं**
Aspose.Slides for Node.js via Java ने SmartArt आकृतियों को बनाने के लिए एक API प्रदान किया है। स्लाइड में SmartArt आकृति बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. [Add a SmartArt shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) by setting it [LayoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SmartArtLayoutType).
1. Save the modified presentation as a PPTX file.

```javascript
// प्रस्तुति क्लास का उदाहरण बनाएँ
var pres = new aspose.slides.Presentation();
try {
    // पहला स्लाइड प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    // Smart Art आकृति जोड़ें
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // प्रस्तुति सहेजना
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape added to the slide**|

## **स्लाइड में SmartArt आकृति तक पहुंचें**
निम्न कोड का उपयोग प्रस्तुति स्लाइड में जोड़ी गई SmartArt आकृतियों तक पहुँचने के लिए किया जाएगा। नमूना कोड में हम स्लाइड के भीतर प्रत्येक आकृति पर यात्रा करेंगे और जांचेंगे कि क्या वह एक [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SmartArt) आकृति है। यदि आकृति SmartArt प्रकार की है तो हम उसे [**SmartArt**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SmartArt) इंस्टेंस में टाइपकास्ट करेंगे।

```javascript
// इच्छित प्रस्तुति लोड करें
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // पहले स्लाइड के भीतर प्रत्येक आकृति पर यात्रा करें
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // जांचें कि आकृति SmartArt प्रकार की है या नहीं
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // आकृति को SmartArtEx में टाइपकास्ट करें
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **विशिष्ट लेआउट प्रकार के साथ SmartArt आकृति तक पहुंचें**
निम्न नमूना कोड आपको विशिष्ट LayoutType वाले [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SmartArt) आकृति तक पहुँचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt की LayoutType नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और केवल तब सेट होता है जब [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SmartArt) आकृति जोड़ी जाती है।

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Check the SmartArt shape with particular LayoutType and perform what is required to be done afterwards.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // पहले स्लाइड के भीतर प्रत्येक आकृति पर यात्रा करें
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // जांचें कि आकृति SmartArt प्रकार की है या नहीं
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // आकृति को SmartArtEx में टाइपकास्ट करें
            var smart = shape;
            // SmartArt लेआउट की जाँच कर रहे हैं
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt आकृति शैली बदलें**
इस उदाहरण में, हम किसी भी SmartArt आकृति के लिए त्वरित शैली को बदलना सीखेंगे।

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Style.
1. Set the new Style for the SmartArt shape.
1. Save the Presentation.

```javascript
// प्रस्तुति क्लास का उदाहरण बनाएँ
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // पहला स्लाइड प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    // पहले स्लाइड के भीतर प्रत्येक आकृति पर यात्रा करें
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // जांचें कि आकृति SmartArt प्रकार की है या नहीं
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // आकृति को SmartArtEx में टाइपकास्ट करें
            var smart = shape;
            // SmartArt शैली की जाँच कर रहे हैं
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // SmartArt शैली बदल रहे हैं
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // प्रस्तुति सहेजना
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: SmartArt shape with changed Style**|

## **SmartArt आकृति रंग शैली बदलें**
इस उदाहरण में, हम किसी भी SmartArt आकृति के लिए रंग शैली बदलना सीखेंगे। निम्न नमूना कोड विशिष्ट रंग शैली वाली SmartArt आकृति तक पहुँचता है और उसकी शैली को बदलता है।

1. Create an instance of [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class and load the presentation with SmartArt Shape.
1. Obtain the reference of first slide by using its Index.
1. Traverse through every shape inside first slide.
1. Check if shape is of [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SmartArt) type and Typecast selected shape to SmartArt if it is SmartArt.
1. Find the SmartArt shape with particular Color Style.
1. Set the new Color Style for the SmartArt shape.
1. Save the Presentation.

```javascript
// प्रस्तुति क्लास का उदाहरण बनाएँ
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // पहला स्लाइड प्राप्त करें
    var slide = pres.getSlides().get_Item(0);
    // पहले स्लाइड के भीतर प्रत्येक आकृति पर यात्रा करें
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // जांचें कि आकृति SmartArt प्रकार की है या नहीं
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // आकृति को SmartArtEx में टाइपकास्ट करें
            var smart = shape;
            // SmartArt रंग प्रकार की जाँच कर रहे हैं
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // SmartArt रंग प्रकार बदल रहे हैं
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // प्रस्तुति सहेजना
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: SmartArt shape with changed Color Style**|

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं SmartArt को एक एकल वस्तु के रूप में एनीमेट कर सकता हूँ?**

हाँ। SmartArt एक आकृति है, इसलिए आप अन्य आकृतियों की तरह ही एनीमेशन API (प्रवेश, निकास, जोर, मोशन पाथ) के माध्यम से [मानक एनीमेशन](/slides/hi/nodejs-java/powerpoint-animation/) लागू कर सकते हैं।

**यदि मुझे स्लाइड में किसी विशिष्ट SmartArt का आंतरिक ID नहीं पता है तो मैं उसे कैसे खोजूँ?**

Alternative Text (AltText) सेट करें और उस मान द्वारा आकृति को खोजें—यह लक्ष्य आकृति को खोजने का अनुशंसित तरीका है।

**क्या मैं SmartArt को अन्य आकृतियों के साथ समूहित कर सकता हूँ?**

हाँ। आप SmartArt को अन्य आकृतियों (चित्र, तालिकाएँ आदि) के साथ समूहित कर सकते हैं और फिर [समूह को संशोधित](/slides/hi/nodejs-java/group/) कर सकते हैं।

**मैं किसी विशिष्ट SmartArt की छवि (जैसे प्रीव्यू या रिपोर्ट के लिए) कैसे प्राप्त करूँ?**

आकृति की थंबनेल/छवि निर्यात करें; लाइब्रेरी [व्यक्तिगत आकृतियों को रेंडर](/slides/hi/nodejs-java/create-shape-thumbnails/) कर PNG/JPG/TIFF जैसे रास्टर फ़ाइलों में बना सकती है।

**पूरा प्रस्तुति PDF में बदलने पर SmartArt की उपस्थिति बनी रहती है या नहीं?**

हाँ। रेंडरिंग इंजन उच्च फ़िडेलिटी के साथ [PDF निर्यात](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) के लिए लक्षित है, जिसमें विभिन्न गुणवत्ता और संगतता विकल्प उपलब्ध हैं।