---
title: "प्रेजेंटेशन में जावास्क्रिप्ट का उपयोग करके टेक्स्ट बॉक्स प्रबंधित करें"
linktitle: "टेक्स्ट बॉक्स प्रबंधित करें"
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
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स बनाने, संपादित करने और क्लोन करने को आसान बनाता है, जिससे आपकी प्रस्तुति ऑटोमेशन में सुधार होता है।"
---
## **परिचय**

स्लाइड्स पर टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या आकृतियों में होते हैं। इसलिए, स्लाइड पर टेक्स्ट जोड़ने के लिए आपको एक टेक्स्ट बॉक्स जोड़ना होगा और फिर उस टेक्स्ट बॉक्स के भीतर कुछ टेक्स्ट डालना होगा। Aspose.Slides for Node.js via Java [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) क्लास प्रदान करता है जो आपको टेक्स्ट वाला आकार जोड़ने की अनुमति देता है।

{{% alert title="जानकारी" color="info" %}}
Aspose.Slides [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape) क्लास भी प्रदान करता है जो आपको स्लाइड्स में आकृतियाँ जोड़ने की अनुमति देता है। हालांकि, `Shape` क्लास के माध्यम से जोड़ी गई सभी आकृतियों में टेक्स्ट नहीं हो सकता। लेकिन [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) क्लास के माध्यम से जोड़ी गई आकृतियों में टेक्स्ट हो सकता है।
{{% /alert %}}

{{% alert title="नोट" color="warning" %}} 
इसलिए, जब आप किसी ऐसे आकार के साथ काम कर रहे हैं जिससे आप टेक्स्ट जोड़ना चाहते हैं, तो आपको यह जांचना और पुष्टि करना चाहिए कि वह `AutoShape` क्लास के माध्यम से कास्ट किया गया है। केवल तभी आप [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame) के साथ काम कर पाएँगे, जो `AutoShape` के तहत एक प्रॉपर्टी है। इस पृष्ठ पर [Update Text](https://docs.aspose.com/slides/hi/nodejs-java/manage-textbox/#update-text) सेक्शन देखें।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाएं**

स्लाइड पर टेक्स्ट बॉक्स बनाने के लिए, इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. नई बनाई गई प्रस्तुति में पहले स्लाइड के लिए एक रेफरेंस प्राप्त करें। 
3. स्लाइड पर एक निर्दिष्ट स्थान पर `Rectangle` के रूप में सेट किए गए [ShapeType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) के साथ एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) ऑब्जेक्ट जोड़ें और नए जोड़े गए `AutoShape` ऑब्जेक्ट के लिए रेफरेंस प्राप्त करें।
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` प्रॉपर्टी जोड़ें जो टेक्स्ट रखेगा। नीचे के उदाहरण में, हमने यह टेक्स्ट जोड़ा: *Aspose TextBox*
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह JavaScript कोड—ऊपर बताए गए चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में टेक्स्ट कैसे जोड़ें:

```javascript
// प्रेजेंटेशन का इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation();
try {
    // प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    var sld = pres.getSlides().get_Item(0);
    // Rectangle प्रकार के साथ एक AutoShape जोड़ता है
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Rectangle में TextFrame जोड़ता है
    ashp.addTextFrame(" ");
    // टेक्स्ट फ्रेम तक पहुँचता है
    var txtFrame = ashp.getTextFrame();
    // टेक्स्ट फ्रेम के लिए पैराग्राफ ऑब्जेक्ट बनाता है
    var para = txtFrame.getParagraphs().get_Item(0);
    // पैराग्राफ के लिए Portion ऑब्जेक्ट बनाता है
    var portion = para.getPortions().get_Item(0);
    // टेक्स्ट सेट करता है
    portion.setText("Aspose TextBox");
    // प्रेजेंटेशन को डिस्क पर सेव करता है
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेक्स्ट बॉक्स आकार की जाँच करें**

Aspose.Slides [AutoShape] क्लास से [isTextBox](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/#isTextBox) मेथड प्रदान करता है, जिससे आप आकृतियों की जांच कर सकते हैं और टेक्स्ट बॉक्स की पहचान कर सकते हैं।

![टेक्स्ट बॉक्स और आकार](istextbox.png)

यह JavaScript कोड दिखाता है कि कैसे जांचें कि कोई आकार टेक्स्ट बॉक्स के रूप में बनाया गया है या नहीं:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

ध्यान दें कि यदि आप केवल [ShapeCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/) क्लास के `addAutoShape` मेथड का उपयोग करके एक ऑटोशेप जोड़ते हैं, तो ऑटोशेप की `isTextBox` मेथड `false` लौटाएगी। हालांकि, यदि आप `addTextFrame` मेथड या `setText` मेथड का उपयोग करके ऑटोशेप में टेक्स्ट जोड़ते हैं, तो `isTextBox` प्रॉपर्टी `true` लौटाएगी।

```javascript
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

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides [TextFrameFormat] क्लास से [setColumnCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) और [setColumnSpacing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) मेथड प्रदान करता है जो आपको टेक्स्ट बॉक्स में कॉलम जोड़ने की अनुमति देता है। आप टेक्स्ट बॉक्स में कॉलमों की संख्या निर्दिष्ट कर सकते हैं और कॉलमों के बीच पॉइंट्स में स्पेसिंग सेट कर सकते हैं।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    var slide = pres.getSlides().get_Item(0);
    // Rectangle प्रकार के साथ एक AutoShape जोड़ता है
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Rectangle में TextFrame जोड़ता है
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // TextFrame का टेक्स्ट फॉर्मेट प्राप्त करता है
    var format = aShape.getTextFrame().getTextFrameFormat();
    // TextFrame में कॉलमों की संख्या निर्दिष्ट करता है
    format.setColumnCount(3);
    // कॉलमों के बीच की स्पेसिंग निर्दिष्ट करता है
    format.setColumnSpacing(10);
    // प्रेजेंटेशन को सेव करता है
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**

Aspose.Slides for Node.js via Java [TextFrameFormat] क्लास से [setColumnCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) मेथड प्रदान करता है जो आपको टेक्स्ट फ्रेम में कॉलम जोड़ने की अनुमति देता है। इस प्रॉपर्टी के माध्यम से आप टेक्स्ट फ्रेम में वांछित कॉलमों की संख्या निर्दिष्ट कर सकते हैं।

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

## **टेक्स्ट अपडेट करें**

Aspose.Slides आपको टेक्स्ट बॉक्स में मौजूद टेक्स्ट या पूरी प्रस्तुति में मौजूद सभी टेक्स्ट को बदलने या अपडेट करने की सुविधा देता है। 

```javascript
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
                    // पैराग्राफ में प्रत्येक भाग (portion) पर इटरेट करता है
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// टेक्स्ट बदलता है
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// फ़ॉर्मेटिंग बदलता है
                    }
                }
            }
        }
    }
    // बदलाव किया गया प्रेजेंटेशन सेव करता है
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें** 

आप टेक्स्ट बॉक्स के अंदर एक लिंक सम्मिलित कर सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ताओं को लिंक खोलने के लिए निर्देशित किया जाता है। 

लिंक वाला टेक्स्ट बॉक्स जोड़ने के लिए, इन चरणों का पालन करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएं। 
2. नई बनाई गई प्रस्तुति में पहले स्लाइड के लिए एक रेफरेंस प्राप्त करें। 
3. स्लाइड पर एक निर्दिष्ट स्थान पर `Rectangle` के रूप में सेट किए गए `ShapeType` के साथ एक `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़े गए AutoShape ऑब्जेक्ट का रेफरेंस प्राप्त करें।
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें *Aspose TextBox* उसके डिफ़ॉल्ट टेक्स्ट के रूप में हो। 
5. `HyperlinkManager` क्लास का इंस्टेंस बनाएं। 
6. `HyperlinkManager` ऑब्जेक्ट को `TextFrame` के इच्छित भाग से जुड़े [HyperlinkClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) प्रॉपर्टी को असाइन करें।
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह JavaScript कोड—ऊपर बताए गए चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स कैसे जोड़ें:

```javascript
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    var slide = pres.getSlides().get_Item(0);
    // प्रकार को Rectangle सेट करके एक AutoShape ऑब्जेक्ट जोड़ता है
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // आकार को AutoShape में कास्ट करता है
    var pptxAutoShape = shape;
    // AutoShape से जुड़े ITextFrame प्रॉपर्टी तक पहुँचता है
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // फ्रेम में कुछ टेक्स्ट जोड़ता है
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // भाग (portion) के टेक्स्ट के लिए हाइपरलिंक सेट करता है
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // PPTX प्रस्तुति को सेव करता है
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड्स के साथ काम करने पर टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/nodejs-java/manage-placeholder/) [master](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) से शैली/स्थिति विरासत में लेता है और [layouts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि एक सामान्य टेक्स्ट बॉक्स एक विशिष्ट स्लाइड पर स्वतंत्र ऑब्जेक्ट है और लेआउट बदलने पर नहीं बदलता।

**मैं प्रस्तुति में चार्ट, टेबल और SmartArt के अंदर के टेक्स्ट को छुए बिना बड़े पैमाने पर टेक्स्ट प्रतिस्थापन कैसे कर सकता हूँ?**

अपनी इटरेशन को केवल उन ऑटो-शेप्स तक सीमित रखें जिनमें टेक्स्ट फ्रेम हों और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartart/)) को अलग-अलग उनकी कलेक्शन को ट्रैवर्स करके या उन ऑब्जेक्ट टाइप्स को स्किप करके बाहर रखें।