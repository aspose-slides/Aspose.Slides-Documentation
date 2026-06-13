---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में टैग और कस्टम डेटा प्रबंधित करें
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/nodejs-java/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- टैग जोड़ें
- जोड़ मान
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js में टैग और कस्टम डेटा को जोड़ना, पढ़ना, अपडेट करना और हटाना सीखें, PowerPoint और OpenDocument प्रस्तुतियों के उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। यह संक्षेप में बताता है कि डेटा PPTX फ़ाइलों में कैसे संग्रहीत होता है, यह नोट करता है कि प्रस्तुतिकरण‑विशिष्ट डेटा टैग और कस्टम XML भागों के रूप में मौजूद हो सकता है, और टैग को कुंजी‑मान स्ट्रिंग जोड़ों के रूप में वर्णित करता है।

यह भी दिखाता है कि टैग मानों को कैसे पढ़ा जाए और प्रस्तुतिकरण, व्यक्तिगत स्लाइड या आकार में टैग कैसे जोड़े जाएँ। साथ ही, लेख सामान्य टैग‑प्रबंधन कार्यों को कवर करता है जैसे सभी टैगों को साफ़ करना, नाम द्वारा टैग हटाना, और टैग नामों की सूची प्राप्त करना।

## **प्रेजेंटेशन फ़ाइलों में डेटा स्टोरेज**

PPTX फ़ाइलें—जिनका विस्तार .pptx है—PresentationML फ़ॉर्मेट में संग्रहीत होती हैं, जो Office Open XML विनिर्देश का हिस्सा है। Office Open XML फ़ॉर्मेट प्रस्तुतियों में मौजूद डेटा की संरचना को परिभाषित करता है।

*स्लाइड* प्रस्तुतियों के तत्वों में से एक है, एक *स्लाइड पार्ट* एकल स्लाइड की सामग्री रखता है। स्लाइड पार्ट को ISO/IEC 29500 द्वारा परिभाषित कई भागों—जैसे User Defined Tags—के साथ स्पष्ट संबंध रखने की अनुमति है।

कस्टम डेटा (प्रेजेंटेशन‑विशिष्ट) या उपयोगकर्ता टैग के रूप में मौजूद हो सकता है ([TagCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TagCollection)) और CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/CustomXmlPartCollection))।

{{% alert color="primary" %}} 
टैग मूलतः स्ट्रिंग‑की जोड़ी मान होते हैं। 
{{% /alert %}} 

## **टैग के मान प्राप्त करना**

स्लाइड्स में, एक टैग [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) और [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) विधियों के अनुरूप होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for Node.js via Java का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) में टैग का मान कैसे प्राप्त किया जाए:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **प्रेजेंटेशन में टैग जोड़ना**

Aspose.Slides आपको प्रेजेंटेशन में टैग जोड़ने की अनुमति देता है। एक टैग आमतौर पर दो भागों से बना होता है:

- एक कस्टम प्रॉपर्टी का नाम - `MyTag`
- कस्टम प्रॉपर्टी का मान - `My Tag Value`

यदि आपको कुछ प्रेजेंटेशन को विशिष्ट नियम या प्रॉपर्टी के आधार पर वर्गीकृत करने की आवश्यकता है, तो टैग जोड़ना लाभदायक हो सकता है। उदाहरण के लिए, यदि आप उत्तरी अमेरिकी देशों की सभी प्रेजेंटेशन को एक साथ वर्गीकृत करना चाहते हैं, तो आप एक North American टैग बना सकते हैं और संबंधित देशों (U.S., Mexico, और Canada) को मानों के रूप में असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for Node.js via Java का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) में टैग कैसे जोड़ें:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

टैग को [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide) के लिए भी सेट किया जा सकता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

या किसी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) के लिए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **सीमाएँ**

`getCustomData().getTags()` के माध्यम से कस्टम डेटा टैग संग्रह में जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे प्रेजेंटेशन को PDF में निर्यात करने पर PDF टैग संरचना में स्थानांतरित **नहीं** होते। परिणामस्वरूप, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग्ड PDF से प्राप्त नहीं किया जा सकता।

**वर्कअराउंड**: आप ऑब्जेक्ट के **Alt Text** (उदा., `shape.setAlternativeText("MyId")`) में कस्टम पहचानकर्ता संग्रहीत कर सकते हैं। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में प्रेजेंटेशन, स्लाइड या आकार से सभी टैग हटा सकता हूँ?**

हां। [tag collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/) में एक [clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/clear/) ऑपरेशन समर्थन है जो एक साथ सभी कुंजी‑मान जोड़ों को हटा देता है।

**मैं पूरे संग्रह पर इटरेट किए बिना नाम द्वारा एकल टैग कैसे हटा सकता हूँ?**

[TagCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/) पर [remove(name)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/remove/) ऑपरेशन का उपयोग करके टैग को उसकी कुंजी से हटाएँ।

**विश्लेषण या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची मैं कैसे प्राप्त करूँ?**

[tag collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/) पर [getNamesOfTags](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) का उपयोग करें; यह सभी टैग नामों की एक array लौटाता है।