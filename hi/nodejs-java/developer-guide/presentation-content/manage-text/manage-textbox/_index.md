---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/nodejs-java/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- पावरपॉइंट
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स बनाना, संपादित करना और क्लोन करना आसान बनाता है, जिससे आपका प्रेजेंटेशन ऑटोमेशन बेहतर होता है।"
---
## **परिचय**

स्लाइड पर मौजूद पाठ आमतौर पर टेक्स्ट बॉक्स या शेप में होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए आपको एक टेक्स्ट बॉक्स जोड़ना पड़ेगा और फिर उसके भीतर कुछ पाठ डालना होगा। Aspose.Slides for Node.js via Java वह [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) क्लास प्रदान करता है जो आपको टेक्स्ट वाला शेप जोड़ने की अनुमति देता है।

{{% alert title="Info" color="info" %}}
Aspose.Slides वह भी [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape) क्लास प्रदान करता है जो स्लाइड्स में शेप जोड़ने की सुविधा देता है। हालांकि, `Shape` क्लास के माध्यम से जोड़े गए सभी शेप टेक्स्ट नहीं रख सकते। परन्तु, [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) क्लास के माध्यम से जोड़े गए शेप में टेक्स्ट हो सकता है।
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
इसलिए, जब आप किसी ऐसे शेप से निपट रहे हों जिसमें आप टेक्स्ट जोड़ना चाहते हैं, तो आपको यह जाँच कर लेनी चाहिए कि वह `AutoShape` क्लास के माध्यम से कास्ट किया गया है या नहीं। तभी आप `AutoShape` के अंतर्गत स्थित [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame) के साथ काम कर पाएँगे। इस पेज के [Update Text](https://docs.aspose.com/slides/hi/nodejs-java/manage-textbox/#update-text) सेक्शन को देखें।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाना**

स्लाइड पर टेक्स्ट बॉक्स बनाने के लिए नीचे दिए गए कदमों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. नए बनाए गए प्रेजेंटेशन की पहली स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड पर निर्दिष्ट स्थान पर `Rectangle` के रूप में `ShapeType` सेट करके एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) ऑब्जेक्ट जोड़ें और नए जोड़े गए `AutoShape` ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` प्रॉपर्टी जोड़ें जिसमें टेक्स्ट रहेगा। नीचे दिए गए उदाहरण में हमने यह टेक्स्ट जोड़ा है: *Aspose TextBox*
5. अंत में, `Presentation` ऑब्जेक्ट के ज़रिए PPTX फाइल लिखें। 

ऊपर बताये कदमों का एक JavaScript कार्यान्वयन यह दिखाता है कि स्लाइड में टेक्स्ट कैसे जोड़ा जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation का इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation();
try {
    // प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    var sld = pres.getSlides().get_Item(0);
    // Rectangle प्रकार के साथ AutoShape जोड़ता है
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Rectangle में TextFrame जोड़ता है
    ashp.addTextFrame(" ");
    // TextFrame तक पहुँचता है
    var txtFrame = ashp.getTextFrame();
    // TextFrame के लिए Paragraph ऑब्जेक्ट बनाता है
    var para = txtFrame.getParagraphs().get_Item(0);
    // Paragraph के लिए Portion ऑब्जेक्ट बनाता है
    var portion = para.getPortions().get_Item(0);
    // टेक्स्ट सेट करता है
    portion.setText("Aspose TextBox");
    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेक्स्ट बॉक्स शेप की जाँच करना**

Aspose.Slides वह [isTextBox](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/#isTextBox) मेथड प्रदान करता है, जो [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) क्लास से उपलब्ध है, जिससे आप शेप की जाँच करके पता लगा सकते हैं कि वह टेक्स्ट बॉक्स है या नहीं।

![पाठ बॉक्स और आकार](istextbox.png)

यह JavaScript कोड दिखाता है कि कैसे यह पता लगाया जाए कि कोई शेप टेक्स्ट बॉक्स के रूप में बनाया गया है या नहीं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

ध्यान रखें कि यदि आप केवल `addAutoShape` मेथड का उपयोग करके [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/) क्लास से एक ऑटोशेप जोड़ते हैं, तो उस ऑटोशेप का `isTextBox` मेथड `false` लौटाएगा। हालांकि, जब आप `addTextFrame` मेथड या `setText` मेथड से उस ऑटोशेप में टेक्स्ट जोड़ते हैं, तो `isTextBox` प्रॉपर्टी `true` वापस करेगी।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() false लौटाता है
shape1.addTextFrame("shape 1");
// shape1.isTextBox() true लौटाता है

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() false लौटाता है
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() true लौटाता है

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() false लौटाता है
shape3.addTextFrame("");
// shape3.isTextBox() false लौटाता है

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() false लौटाता है
shape4.getTextFrame().setText("");
// shape4.isTextBox() false लौटाता है
```

## **टेक्स्ट फ्रेम वाले शेप का पता लगाना**

सामान्य टेक्स्ट‑प्रोसेसिंग कोड में, आप किसी [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) को प्राप्त कर सकते हैं बिना यह जाने कि यह किस प्रेजेंटेशन ऑब्जेक्ट में मौजूद है। आप [TextFrame.getParentShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentShape--) मेथड का उपयोग करके संबंधित [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) तक वापस नेविगेट कर सकते हैं।

जब कोई टेक्स्ट फ्रेम एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) या किसी अन्य टेक्स्ट‑वाला शेप से जुड़ा होता है, तो [TextFrame.getParentShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentShape--) मालिक को लौटाता है और [TextFrame.getParentCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/#getParentCell--) `null` देता है। दोनों मेथड सिर्फ पढ़ने योग्य नेविगेशन प्रदान करते हैं, इसलिए इनके कॉल से स्वामित्व नहीं बदलता। हमेशा `null` के लिए लौटाए गए मान की जाँच करें जिससे आप शेप तक पहुंचें।

शेप और टेबल‑सेल मालिकों की पहचान करने वाला पूर्ण उदाहरण, जिसमें SmartArt नोड्स भी शामिल हैं, के लिए देखें [Search and Replace Text](/slides/hi/nodejs-java/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ना**

Aspose.Slides वह [setColumnCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) और [setColumnSpacing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) मेथड प्रदान करता है, जो [TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat) क्लास से आते हैं, जिससे आप टेक्स्ट बॉक्स में कॉलम जोड़ सकते हैं। आप टेक्स्ट बॉक्स में कॉलमों की संख्या निर्धारित कर सकते हैं और कॉलमों के बीच बिंदुओं (points) में स्पेसिंग सेट कर सकते हैं।

नीचे दिया गया JavaScript कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    var slide = pres.getSlides().get_Item(0);
    // प्रकार को Rectangle सेट करके AutoShape जोड़ता है
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Rectangle में TextFrame जोड़ता है
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // TextFrame के टेक्स्ट फॉर्मेट को प्राप्त करता है
    var format = aShape.getTextFrame().getTextFrameFormat();
    // TextFrame में कॉलमों की संख्या निर्दिष्ट करता है
    format.setColumnCount(3);
    // कॉलमों के बीच स्पेसिंग निर्दिष्ट करता है
    format.setColumnSpacing(10);
    // प्रेजेंटेशन को सहेजता है
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ना**

Aspose.Slides for Node.js via Java वह [setColumnCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) मेथड प्रदान करता है, जो [TextFrameFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat) क्लास से जुड़ा है, जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस प्रॉपर्टी के माध्यम से आप टेक्स्ट फ्रेम में इच्छित कॉलमों की संख्या निर्दिष्ट कर सकते हैं।

यह JavaScript कोड दिखाता है कि टेक्स्ट फ्रेम के भीतर कॉलम कैसे जोड़ें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // कॉलम स्पेसिंग कभी सेट नहीं किया गया था, इसलिए इसे NaN के रूप में रिपोर्ट किया जाता है।
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेक्स्ट अपडेट करना**

Aspose.Slides आपको टेक्स्ट बॉक्स में मौजूद टेक्स्ट या पूरी प्रेजेंटेशन में सभी टेक्स्ट को बदलने या अपडेट करने की सुविधा देता है। 

यह JavaScript कोड एक ऐसा कार्य दर्शाता है जहाँ प्रेजेंटेशन में सभी टेक्स्ट अपडेट या बदल दिए जाते हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // जाँचता है कि आकार टेक्स्ट फ्रेम (IAutoShape) का समर्थन करता है।
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // टेक्स्ट फ्रेम में पैराग्राफ़ों पर इटरेट करता है
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // पैराग्राफ़ में प्रत्येक पोर्शन पर इटरेट करता है
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// टेक्स्ट बदलता है
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// फॉर्मेटिंग बदलता है
                    }
                }
            }
        }
    }
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ना** 

आप टेक्स्ट बॉक्स के भीतर एक लिंक डाल सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता को वह लिंक खोलने के लिए निर्देशित किया जाता है। 

हाइपरलिंक वाले टेक्स्ट बॉक्स को जोड़ने के लिए नीचे दिए कदमों का पालन करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएँ। 
2. नई बनाई गई प्रेजेंटेशन की पहली स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड पर निर्दिष्ट स्थान पर `Rectangle` के रूप में `ShapeType` सेट करके एक `AutoShape` ऑब्जेक्ट जोड़ें और उसके रेफ़रेंस को प्राप्त करें।
4. `AutoShape` ऑब्जेक्ट में `TextFrame` जोड़ें और उसकी पहली पोर्शन का टेक्स्ट सेट करें। नीचे के उदाहरण में हमने यह टेक्स्ट उपयोग किया: *Aspose.Slides*
5. उस पोर्शन के `PortionFormat` के माध्यम से उसका `HyperlinkManager` प्राप्त करें।
6. `HyperlinkManager` पर `setExternalHyperlinkClick` कॉल करके पोर्शन से लिंक जोड़ें।
7. अंत में, `Presentation` ऑब्जेक्ट के ज़रिए PPTX फाइल लिखें। 

ऊपर बताये कदमों का यह JavaScript कार्यान्वयन आपको दिखाता है कि कैसे स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ा जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation();
try {
    // प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    var slide = pres.getSlides().get_Item(0);
    // टाइप को Rectangle सेट करके AutoShape ऑब्जेक्ट जोड़ता है
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // shape को AutoShape में कास्ट करता है
    var pptxAutoShape = shape;
    // AutoShape से संबंधित ITextFrame प्रॉपर्टी तक पहुँचता है
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // फ्रेम में कुछ टेक्स्ट जोड़ता है
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // पोर्शन टेक्स्ट के लिए हाइपरलिंक सेट करता है
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // PPTX प्रेजेंटेशन को सहेजता है
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/nodejs-java/manage-placeholder/) अपने शैली/स्थिति को [master](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) से विरासत में लेता है और इसे [layouts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि सामान्य टेक्स्ट बॉक्स किसी विशिष्ट स्लाइड पर स्वतंत्र ऑब्जेक्ट होता है और लेआउट बदलने पर नहीं बदलता।

**मैं प्रेजेंटेशन में चार्ट, टेबल और SmartArt के भीतर के टेक्स्ट को छोड़े बिना बड़े पैमाने पर टेक्स्ट प्रतिस्थापन कैसे कर सकता हूँ?**

ऑटो‑शेप्स जिनमें टेक्स्ट फ्रेम हैं, उन्हें ही इटरेट करें और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartart/)) को उनके संग्रहों को अलग‑अलग ट्रैवर्स करके या उन ऑब्जेक्ट‑टाइप्स को स्किप करके बाहर रखें।