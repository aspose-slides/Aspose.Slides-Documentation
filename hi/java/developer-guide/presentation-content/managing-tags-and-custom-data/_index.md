---
title: जावा का उपयोग करके प्रस्तुतियों में टैग और कस्टम डेटा प्रबंधित करें
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/java/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- टैग जोड़ें
- जोड़ी मान
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में टैग और कस्टम डेटा को जोड़ने, पढ़ने, अपडेट करने और हटाने के बारे में जानें, PowerPoint और OpenDocument प्रस्तुतियों के उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। यह संक्षेप में बताता है कि डेटा PPTX फ़ाइलों में कैसे संग्रहीत होता है, यह उल्लेख करता है कि प्रस्तुति-विशिष्ट डेटा टैग और कस्टम XML भागों के रूप में मौजूद हो सकता है, और टैग को कुंजी‑मान स्ट्रिंग जोड़े के रूप में वर्णित करता है।

यह भी दर्शाता है कि टैग के मान कैसे पढ़ें और एक प्रस्तुति, व्यक्तिगत स्लाइड, या शेप में टैग कैसे जोड़ें। इसके अतिरिक्त, लेख सामान्य टैग‑प्रबंधन कार्यों को कवर करता है जैसे सभी टैग साफ़ करना, नाम द्वारा टैग हटाना, और टैग नामों की सूची प्राप्त करना।

## **प्रेजेंटेशन फ़ाइलों में डेटा संग्रह**

PPTX फ़ाइलें—.pptx एक्सटेंशन वाली फ़ाइलें—PresentationML स्वरूप में संग्रहीत होती हैं, जो Office Open XML विनिर्देशन का हिस्सा है। Office Open XML स्वरूप प्रस्तुतियों में निहित डेटा की संरचना को परिभाषित करता है।

*स्लाइड* प्रस्तुति के तत्वों में से एक है, और *स्लाइड पार्ट* एक एकल स्लाइड की सामग्री रखता है। एक स्लाइड पार्ट को कई भागों—जैसे User Defined Tags—के साथ स्पष्ट संबंध रखने की अनुमति है, जो ISO/IEC 29500 द्वारा निर्धारित हैं।

कस्टम डेटा (प्रस्तुति‑विशिष्ट) या उपयोगकर्ता टैग ([ITagCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITagCollection)) और CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICustomXmlPartCollection)) के रूप में मौजूद हो सकता है।

{{% alert color="primary" %}} 
टैग मूल रूप से स्ट्रिंग‑कुंजी जोड़े के मान होते हैं। 
{{% /alert %}} 

## **टैग के मान प्राप्त करें**

स्लाइड में, एक टैग [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IDocumentProperties#getKeywords--) और [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) मेथड से मेल खाता है। यह नमूना कोड दिखाता है कि Aspose.Slides for Java के साथ [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) के लिए टैग का मान कैसे प्राप्त किया जाए:

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **प्रेजेंटेशन में टैग जोड़ें**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग सामान्यतः दो आइटम से बना होता है:

- कस्टम प्रॉपर्टी का नाम - `MyTag` 
- कस्टम प्रॉपर्टी का मान - `My Tag Value`

यदि आपको कुछ प्रस्तुतियों को किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर वर्गीकृत करने की आवश्यकता है, तो टैग जोड़ना उपयोगी हो सकता है। उदाहरण के लिए, यदि आप उत्तरी अमेरिकी देशों की सभी प्रस्तुतियों को साथ रखना चाहते हैं, तो आप एक North American टैग बना सकते हैं और संबंधित देशों (USA, Mexico, और Canada) को मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for Java का उपयोग करके एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) में टैग कैसे जोड़ें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

टैग [Slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) के लिए भी सेट किए जा सकते हैं:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

या किसी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) के लिए:

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

`getCustomData().getTags()` के माध्यम से कस्टम डेटा टैग कलेक्शन में जोड़े गए टैग केवल PowerPoint फ़ाइल के भीतर संग्रहीत होते हैं। इन्हें PDF टैग संरचना में निर्यात के समय स्थानांतरित **नहीं** किया जाता है। परिणामस्वरूप, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग किए हुए PDF से प्राप्त नहीं किया जा सकता।

**Workaround**: आप कस्टम पहचानकर्ता को ऑब्जेक्ट के **Alt Text** में स्टोर कर सकते हैं (उदाहरण के लिए, `shape.setAlternativeText("MyId")`)। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में प्रस्तुति, स्लाइड या शेप से सभी टैग हटा सकता हूँ?**

हां। [tag collection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/) में एक [clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/#clear--) ऑपरेशन उपलब्ध है जो सभी कुंजी‑मान जोड़े को एक साथ हटा देता है।

**मैं संपूर्ण कलेक्शन को इटरेट किए बिना नाम से एक टैग कैसे हटा सकता हूँ?**

[tag collection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/) पर [Remove(name)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) ऑपरेशन का उपयोग करके टैग को उसके कुंजी से हटा सकते हैं।

**मैं विश्लेषण या फ़िल्टरिंग के目的 से सभी टैग नामों की सूची कैसे प्राप्त कर सकता हूँ?**

[tag collection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/) पर [getNamesOfTags](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tagcollection/#getNamesOfTags--) का उपयोग करें; यह सभी टैग नामों की एक एरे लौटाता है।