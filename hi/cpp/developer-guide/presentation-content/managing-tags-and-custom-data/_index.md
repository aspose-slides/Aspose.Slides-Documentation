---
title: C++ का उपयोग करके प्रस्तुतियों में टैग और कस्टम डेटा प्रबंधित करना
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/cpp/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- टैग जोड़ें
- जुड़वां मान
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में टैग और कस्टम डेटा को जोड़ना, पढ़ना, अपडेट करना और हटाना सीखें, PowerPoint और OpenDocument प्रस्तुतियों के उदाहरणों सहित।"
---
## **समीक्षा**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। यह संक्षिप्त रूप से इस बात को रेखांकित करता है कि डेटा PPTX फ़ाइलों में कैसे संग्रहीत किया जाता है, यह नोट करता है कि प्रस्तुति-विशिष्ट डेटा टैग और कस्टम XML भागों के रूप में मौजूद हो सकता है, और टैग को कुंजी‑मान स्ट्रिंग जोड़ों के रूप में वर्णित करता है।

यह दिखाता है कि टैग मानों को कैसे पढ़ा जाए और एक प्रस्तुति, व्यक्तिगत स्लाइड या आकार में टैग कैसे जोड़े जाएँ। इसके अतिरिक्त, लेख सामान्य टैग‑प्रबंधन कार्यों जैसे सभी टैग साफ़ करना, नाम द्वारा टैग हटाना, और टैग नामों की सूची प्राप्त करना को कवर करता है।

## **प्रस्तुति फ़ाइलों में डेटा संग्रह**

PPTX फ़ाइलें—.pptx एक्सटेंशन वाली वस्तुएँ—PresentationML स्वरूप में संग्रहीत होती हैं, जो Office Open XML विशिष्टता का हिस्सा है। Office Open XML स्वरूप प्रस्तुतियों में मौजूद डेटा की संरचना को परिभाषित करता है।

प्रेजेंटेशन में *स्लाइड* एक तत्व है, और *स्लाइड भाग* एकल स्लाइड की सामग्री रखता है। एक स्लाइड भाग को ISO/IEC 29500 द्वारा परिभाषित कई हिस्सों—जैसे User Defined Tags—के साथ स्पष्ट संबंध रखने की अनुमति होती है।

कस्टम डेटा (प्रेजेंटेशन‑विशिष्ट) या उपयोगकर्ता टैग ([ITagCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itagcollection/)) और CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/)) के रूप में मौजूद हो सकता है।

{{% alert color="primary" %}} 
टैग मूलतः स्ट्रिंग‑की जोड़ी मान होते हैं। 
{{% /alert %}} 

## **टैग के मान प्राप्त करना**

स्लाइड्स में, एक टैग IDocumentProperties.Keywords प्रॉपर्टी के अनुरूप होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for C++ का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) से टैग का मान कैसे प्राप्त किया जाए:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **प्रस्तुति में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग आमतौर पर दो आइटम से बना होता है:

- कस्टम प्रॉपर्टी का नाम - `MyTag`
- कस्टम प्रॉपर्टी का मान - `My Tag Value`

यदि आपको कुछ प्रस्तुतियों को विशिष्ट नियम या प्रॉपर्टी के आधार पर वर्गीकृत करने की आवश्यकता है, तो आप उन प्रस्तुतियों में टैग जोड़कर लाभ उठा सकते हैं। उदाहरण के लिए, यदि आप उत्तर अमेरिकी देशों की सभी प्रस्तुतियों को एक साथ वर्गीकृत करना चाहते हैं, तो आप एक North American टैग बना सकते हैं और संबंधित देशों (U.S., Mexico, Canada) को मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for C++ का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) में टैग कैसे जोड़ें:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

टैग को [Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/) के लिए भी सेट किया जा सकता है:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

या किसी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/) के लिए:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **सीमाएं**

`get_CustomData()->get_Tags()` का उपयोग करके कस्टम डेटा टैग संग्रह में जोड़े गए टैग केवल PowerPoint फ़ाइल के भीतर संग्रहीत होते हैं। वे प्रस्तुति को PDF में निर्यात करने पर PDF टैग संरचना में **स्थानांतरित नहीं** होते। परिणामस्वरूप, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैगेड PDF से प्राप्त नहीं किया जा सकता।

**वैकल्पिक समाधान**: आप ऑब्जेक्ट के **Alt Text** (उदाहरण : `shape->set_AlternativeText(u"MyId")`) में कस्टम पहचानकर्ता संग्रहीत कर सकते हैं। PDF निर्यात के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही क्रिया में प्रस्तुति, स्लाइड या आकार से सभी टैग हटा सकता हूँ?**

हाँ। [tag collection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/) में एक [clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/clear/) ऑपरेशन उपलब्ध है जो सभी कुंजी‑मान जोड़े को एक साथ हटाता है।

**कैसे बिना पूरी संग्रह को इटरनेट किए नाम द्वारा एकल टैग हटाऊँ?**

[TagCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/) पर [Remove(name)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/remove/) ऑपरेशन का उपयोग करके टैग को उसकी कुंजी द्वारा हटाएँ।

**विश्लेषण या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

[टैग संग्रह](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/) पर [GetNamesOfTags](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/getnamesoftags/) कॉल करें; यह सभी टैग नामों की एक एरे लौटाता है।