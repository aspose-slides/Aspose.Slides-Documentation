---
title: Android पर प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/androidjava/managing-tags-and-custom-data
keywords:
- दस्तावेज़ प्रॉपर्टी
- टैग
- कस्टम डेटा
- टैग जोड़ें
- जुड़े मान
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में टैग और कस्टम डेटा को जोड़ें, पढ़ें, अपडेट करें और हटाएँ, PowerPoint और OpenDocument प्रस्तुतियों के लिए Java उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। यह संक्षेप में बताता है कि डेटा PPTX फ़ाइलों में कैसे संग्रहीत होता है, उल्लेख करता है कि प्रस्तुति-विशिष्ट डेटा टैग और कस्टम XML भागों के रूप में मौजूद हो सकता है, और टैग को कुंजी‑मूल्य स्ट्रिंग जोड़े के रूप में वर्णित करता है।

यह यह भी दर्शाता है कि टैग मानों को कैसे पढ़ा जाए और प्रस्तुति, किसी व्यक्तिगत स्लाइड, या किसी आकार में टैग कैसे जोड़े जाएँ। इसके अतिरिक्त, यह लेख सामान्य टैग‑प्रबंधन कार्यों जैसे सभी टैग साफ़ करना, नाम द्वारा टैग हटाना, और टैग नामों की सूची प्राप्त करना को शामिल करता है।

## **प्रेजेंटेशन फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें—.pptx एक्सटेंशन वाली वस्तुएँ—PresentationML फ़ॉर्मेट में संग्रहीत होती हैं, जो Office Open XML स्पेसिफिकेशन का हिस्सा है। Office Open XML फ़ॉर्मेट प्रस्तुतियों में मौजूद डेटा की संरचना को परिभाषित करता है।

प्रस्तुतियों में *स्लाइड* तत्वों में से एक है, एक *स्लाइड पार्ट* एकल स्लाइड की सामग्री रखता है। एक स्लाइड पार्ट को ISO/IEC 29500 द्वारा परिभाषित कई भागों—जैसे यूज़र डिफाइन्ड टैग—से स्पष्ट संबंध रखने की अनुमति है।

कस्टम डेटा (प्रेजेंटेशन‑विशिष्ट) या उपयोगकर्ता टैग ([ITagCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITagCollection)) और CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICustomXmlPartCollection)) के रूप में मौजूद हो सकता है।

{{% alert color="primary" %}} 
टैग मूल रूप से स्ट्रिंग‑की जोड़ी मान होते हैं। 
{{% /alert %}} 

## **टैग के मान प्राप्त करें**

स्लाइड में, एक टैग [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) और [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) मेथड्स के अनुरूप है। यह नमूना कोड दिखाता है कि Aspose.Slides for Android के माध्यम से जावा में [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) के लिए टैग का मान कैसे प्राप्त किया जाए:

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **प्रेजेंटेशन में टैग जोड़ें**

Aspose.Slides आपको प्रेजेंटेशन में टैग जोड़ने की अनुमति देता है। एक टैग सामान्यतः दो वस्तुओं से बना होता है:

- कस्टम प्रॉपर्टी का नाम - `MyTag`
- कस्टम प्रॉपर्टी का मान - `My Tag Value`

यदि आपको कुछ प्रेजेंटेशन को विशिष्ट नियम या प्रॉपर्टी के आधार पर वर्गीकृत करना हो, तो उन प्रेजेंटेशन में टैग जोड़ने से आपको लाभ मिल सकता है। उदाहरण के लिए, यदि आप सभी उत्तर अमेरिकी देशों के प्रेजेंटेशन को समूहबद्ध करना चाहते हैं, तो आप एक North American टैग बना सकते हैं और संबंधित देशों (अमेरिका, मैक्सिको, और कनाडा) को मानों के रूप में असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for Android के माध्यम से जावा में एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) में टैग कैसे जोड़ा जाए:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

टैग को [Slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlide) के लिए भी सेट किया जा सकता है:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

या किसी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) के लिए:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **सीमाएँ**

`getCustomData().getTags()` का उपयोग करके कस्टम डेटा टैग कलेक्शन के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। जब प्रस्तुतीकरण को PDF में निर्यात किया जाता है तो वे PDF टैग संरचना में **स्थानांतरित नहीं** होते। परिणामस्वरूप, टैग के रूप में सौंपा गया कस्टम पहचानकर्ता टैग्ड PDF से पुनः प्राप्त नहीं किया जा सकता।

**वैकल्पिक उपाय**: आप किसी ऑब्जेक्ट के **Alt Text** में कस्टम पहचानकर्ता संग्रहीत कर सकते हैं (उदा., `shape.setAlternativeText("MyId")`)। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में प्रेजेंटेशन, स्लाइड, या शेप से सभी टैग हटा सकता हूँ?**

हां। [tag collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/) में [clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/#clear--) ऑपरेशन उपलब्ध है जो सभी कुंजी‑मान जोड़े को एक बार में हटा देता है।

**मैं पूरे कलेक्शन को इटरेट किए बिना नाम द्वारा एकल टैग कैसे हटाऊँ?**

टैग को उसके कुंजी द्वारा हटाने के लिए [tag collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/) पर [remove(name)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) ऑपरेशन का उपयोग करें।

**मैं विश्लेषण या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

[tag collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/) पर [getNamesOfTags](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) का प्रयोग करें; यह सभी टैग नामों की एक एरे लौटाता है।