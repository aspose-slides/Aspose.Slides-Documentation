---
title: ".NET में प्रस्तुतियों में टैग और कस्टम डेटा को प्रबंधित करें"
linktitle: "टैग और कस्टम डेटा"
type: docs
weight: 300
url: /hi/net/managing-tags-and-custom-data/
keywords:
- "दस्तावेज़ गुण"
- "टैग"
- "कस्टम डेटा"
- "टैग जोड़ें"
- "जोड़े मान"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET में टैग और कस्टम डेटा को जोड़ना, पढ़ना, अपडेट करना और हटाना सीखें, PowerPoint और OpenDocument प्रस्तुतियों के उदाहरणों के साथ।"
---
## **सारांश**

यह लेख बताता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। यह संक्षेप में बताता है कि डेटा PPTX फ़ाइलों में कैसे संग्रहीत होता है, यह नोट करता है कि प्रस्तुति‑विशिष्ट डेटा टैग और कस्टम XML भागों के रूप में मौजूद हो सकता है, और टैग को कुंजी‑मान स्ट्रिंग जोड़े के रूप में वर्णित करता है।

यह इस बात को भी दिखाता है कि टैग मानों को कैसे पढ़ा जाए और प्रस्तुति, किसी व्यक्तिगत स्लाइड या आकृति में टैग कैसे जोड़े जाएँ। इसके अतिरिक्त, लेख सामान्य टैग‑प्रबंधन कार्यों को कवर करता है जैसे सभी टैग साफ़ करना, नाम द्वारा टैग हटाना, और टैग नामों की सूची प्राप्त करना।

## **प्रस्तुति फ़ाइलों में डेटा संग्रहण**

PPTX फ़ाइलें—.pptx एक्सटेंशन वाली फ़ाइलें—PresentationML फॉर्मेट में संग्रहीत होती हैं, जो Office Open XML विनिर्देश का हिस्सा है। Office Open XML फॉर्मेट प्रस्तुतियों में उपस्थित डेटा की संरचना को परिभाषित करता है।

जब *स्लाइड* प्रस्तुतियों के तत्वों में से एक है, तो *स्लाइड भाग* एकल स्लाइड की सामग्री रखता है। एक स्लाइड भाग को ISO/IEC 29500 द्वारा परिभाषित कई भागों—जैसे User Defined Tags—के साथ स्पष्ट संबंध रखने की अनुमति है।

कस्टम डेटा (प्रस्तुति‑विशिष्ट) या उपयोगकर्ता टैग के रूप में मौजूद हो सकता है ([ITagCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/itagcollection)) और CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icustomxmlpartcollection)) के रूप में।

{{% alert color="primary" %}} 
टैग मूल रूप से स्ट्रिंग‑कुंजी जोड़े होते हैं। 
{{% /alert %}} 

## **टैग मान प्राप्त करना**

स्लाइड्स में, एक टैग IDocumentProperties.Keywords प्रॉपर्टी के समान होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for .NET के साथ [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) में टैग का मान कैसे प्राप्त किया जाए:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **प्रस्तुतियों में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग आमतौर पर दो तत्वों से बना होता है:

- एक कस्टम प्रॉपर्टी का नाम - `MyTag` 
- कस्टम प्रॉपर्टी का मान - `My Tag Value`

यदि आपको कुछ प्रस्तुतियों को किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर वर्गीकृत करने की आवश्यकता है, तो उन प्रस्तुतियों में टैग जोड़ने से आपको लाभ हो सकता है। उदाहरण के लिए, यदि आप सभी उत्तर अमेरिकी देशों की प्रस्तुतियों को एक साथ रखना चाहते हैं, तो आप एक “North American” टैग बना सकते हैं और संबंधित देशों (U.S., Mexico, और Canada) को मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for .NET का उपयोग करके [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) में टैग कैसे जोड़ा जाए:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

टैग को [Slide](https://reference.aspose.com/slides/hi/net/aspose.slides/slide) के लिए भी सेट किया जा सकता है:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

या किसी व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/net/aspose.slides/shape) के लिए:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **सीमाएँ**

`CustomData.Tags` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल के भीतर संग्रहीत होते हैं। वे प्रस्तुति को PDF में निर्यात करने पर PDF टैग संरचना में **ट्रांसफ़र नहीं** होते। परिणामस्वरूप, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग किया गया PDF से पुनः प्राप्त नहीं किया जा सकता।

**वैकल्पिक समाधान**: आप ऑब्जेक्ट के **Alt Text** में कस्टम पहचानकर्ता संग्रहीत कर सकते हैं (जैसे, `shape.AlternativeText = "MyId"`)। PDF में निर्यात करने के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में प्रस्तुति, स्लाइड या आकृति से सभी टैग हटा सकता हूँ?**

हाँ। [tag collection](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/) में [clear](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/clear/) ऑपरेशन समर्थित है, जो सभी कुंजी‑मान जोड़े को एक साथ हटा देता है।

**मैं संपूर्ण संग्रह को इटररेट किए बिना नाम द्वारा एकल टैग कैसे हटाऊँ?**

[TagCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/) पर [Remove(name)](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/remove/) ऑपरेशन का उपयोग करके टैग को उसकी कुंजी से हटा सकते हैं।

**मैं विश्लेषण या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

[tag collection](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/) पर [GetNamesOfTags](https://reference.aspose.com/slides/hi/net/aspose.slides/tagcollection/getnamesoftags/) का उपयोग करें; यह सभी टैग नामों की एक एरे लौटाता है।