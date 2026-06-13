---
title: Python के साथ प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/python-net/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- टैग जोड़ना
- जोड़ी मान
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में टैग और कस्टम डेटा को जोड़ना, पढ़ना, अपडेट करना और हटाना सीखें, PowerPoint और OpenDocument प्रस्तुतियों के उदाहरणों के साथ।"
---
## **परिचय**

यह लेख समझाता है कि Aspose.Slides टैग और कस्टम डेटा के साथ PowerPoint प्रस्तुतियों में कैसे काम करता है। यह संक्षेप में बताता है कि डेटा PPTX फ़ाइलों में कैसे संग्रहीत होता है, यह नोट करता है कि प्रस्तुति‑विशिष्ट डेटा टैग और कस्टम XML भागों के रूप में मौजूद हो सकता है, और टैग को कुंजी‑मूल्य स्ट्रिंग जोड़े के रूप में वर्णित करता है।

यह यह भी दर्शाता है कि टैग मान कैसे पढ़ें और एक प्रस्तुति, एक व्यक्तिगत स्लाइड, या एक आकार में टैग कैसे जोड़ें। अतिरिक्त रूप से, यह लेख सामान्य टैग‑प्रबंधन कार्यों को कवर करता है जैसे सभी टैग साफ़ करना, नाम द्वारा टैग हटाना, और टैग नामों की सूची प्राप्त करना।

## **प्रेजेंटेशन फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें—.pptx एक्सटेंशन वाली वस्तुएँ—PresentationML फ़ॉर्मेट में संग्रहीत होती हैं, जो Office Open XML विनिर्देश का हिस्सा है। Office Open XML फ़ॉर्मेट प्रस्तुतियों में निहित डेटा की संरचना को परिभाषित करता है।

*slide* प्रस्तुतियों के तत्वों में से एक है, एक *slide part* एकल स्लाइड की सामग्री रखता है। एक slide part को कई भागों—जैसे User Defined Tags—के साथ स्पष्ट संबंध रखने की अनुमति है, जो ISO/IEC 29500 द्वारा परिभाषित हैं।

कस्टम डेटा (प्रेजेंटेशन‑विशिष्ट) या उपयोगकर्ता टैग के रूप में मौजूद हो सकता है ([ITagCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/itagcollection/)) और CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/icustomxmlpartcollection/))।

{{% alert color="primary" %}} 
टैग मूल रूप से स्ट्रिंग‑की जोड़ी मान होते हैं। 
{{% /alert %}} 

## **टैग मान प्राप्त करें**

स्लाइड में, एक टैग IDocumentProperties.Keywords प्रॉपर्टी के अनुरूप होता है। यह नमूना कोड दिखाता है कि कैसे Aspose.Slides for Python via .NET के साथ [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) के लिए टैग का मान प्राप्त करें:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **प्रेजेंटेशन में टैग जोड़ें**

Aspose.Slides आपको प्रेजेंटेशन में टैग जोड़ने की अनुमति देता है। एक टैग आमतौर पर दो वस्तुओं से बना होता है:
- कस्टम प्रॉपर्टी का नाम - `MyTag`
- कस्टम प्रॉपर्टी का मान - `My Tag Value`

यदि आपको कुछ प्रेजेंटेशन को किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर वर्गीकृत करने की आवश्यकता है, तो आप उन प्रेजेंटेशन में टैग जोड़कर लाभ उठा सकते हैं। उदाहरण के लिए, यदि आप सभी उत्तरी अमेरिकी देशों के प्रेजेंटेशन को एक साथ वर्गीकृत करना चाहते हैं, तो आप एक North American टैग बना सकते हैं और संबंधित देशों (अमेरिका, मेक्सिको, और कनाडा) को मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि कैसे Aspose.Slides for Python via .NET का उपयोग करके किसी [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) में टैग जोड़ें:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

टैग को [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) के लिए भी सेट किया जा सकता है:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

या किसी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) के लिए:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **सीमाएँ**

`custom_data.tags` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। जब प्रस्तुति को PDF में निर्यात किया जाता है तो वे **PDF** टैग संरचना में स्थानांतरित नहीं होते हैं। परिणामस्वरूप, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग्ड PDF से प्राप्त नहीं किया जा सकता।

**वैकल्पिक उपाय**: आप किसी ऑब्जेक्ट के **Alt Text** में कस्टम पहचानकर्ता सहेज सकते हैं (जैसे, `shape.alternative_text = "MyId"`)। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में प्रस्तुति, स्लाइड, या शैप से सभी टैग हटा सकता हूँ?**

हाँ। [tag collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/) में एक [clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/clear/) ऑपरेशन समर्थित है जो सभी कुंजी‑मान जोड़े को एक साथ हटा देता है।

**मैं पूरे संग्रह को इटरेट किए बिना किसी टैग को उसके नाम से कैसे हटा सकता हूँ?**

[TagCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/) पर [remove(name)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/remove/) ऑपरेशन का उपयोग करके टैग को उसकी कुंजी से हटा सकते हैं।

**मैं विश्लेषण या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त कर सकता हूँ?**

[tag collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/) पर [get_names_of_tags](https://reference.aspose.com/slides/hi/python-net/aspose.slides/tagcollection/get_names_of_tags/) का उपयोग करें; यह सभी टैग नामों का एक एरे लौटाता है।