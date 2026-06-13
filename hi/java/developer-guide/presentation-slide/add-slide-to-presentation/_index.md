---
title: जावा में प्रस्तुतियों में स्लाइड जोड़ें
linktitle: स्लाइड जोड़ें
type: docs
weight: 10
url: /hi/java/add-slide-to-presentation/
keywords:
- स्लाइड जोड़ें
- स्लाइड बनाएं
- खाली स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके अपने PowerPoint और OpenDocument प्रस्तुतियों में आसानी से स्लाइड जोड़ें—सेकंड में सहज और कुशल स्लाइड सम्मिलन।"
---
## **समीक्षा**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में स्लाइड जोड़ने की अनुमति देता है। एक प्रस्तुति में मास्टर/लेआउट स्लाइड और सामान्य स्लाइड होती हैं, और सामान्य स्लाइड शून्य‑आधारित इंडेक्स द्वारा व्यवस्थित होती हैं। प्रत्येक स्लाइड का एक अनूठा ID होता है, और स्लाइडों के बिना प्रस्तुति फ़ाइलें समर्थित नहीं हैं।

यह लेख बताता है कि कैसे `Presentation` ऑब्जेक्ट बनाया जाए, उसकी स्लाइड संग्रह तक पहुंचा जाए, एक खाली स्लाइड जोड़ी जाए, नए जोड़े गए स्लाइड के साथ काम किया जाए, और अपडेटेड प्रस्तुति को सहेजा जाए। यह विशेष स्थिति में स्लाइड सम्मिलन, लेआउट उपयोग, और नई बनाई गई प्रस्तुति में मौजूद खाली स्लाइड को समझने जैसे संबंधित बिंदुओं को भी कवर करता है।

## **प्रस्तुति में एक स्लाइड जोड़ें**

प्रस्तुति फ़ाइलों में स्लाइड जोड़ने के बारे में बात करने से पहले, चलिए स्लाइडों के कुछ तथ्यों पर चर्चा करते हैं। प्रत्येक PowerPoint प्रस्तुति फ़ाइल में **Master / Layout** स्लाइड और अन्य **Normal** स्लाइडें होती हैं। इसका अर्थ है कि प्रस्तुति फ़ाइल में कम से कम एक या अधिक स्लाइडें होती हैं। यह जानना महत्वपूर्ण है कि Aspose.Slides for Java द्वारा स्लाइडों के बिना प्रस्तुति फ़ाइलें समर्थित नहीं हैं। प्रत्येक स्लाइड का एक अनूठा Id होता है और सभी Normal स्लाइडें शून्य‑आधारित इंडेक्स द्वारा निर्दिष्ट क्रम में व्यवस्थित होती हैं।

Aspose.Slides for Java डेवलपर्स को उनकी प्रस्तुति में खाली स्लाइड जोड़ने की अनुमति देता है। प्रस्तुति में एक खाली स्लाइड जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
- प्रस्तुति ऑब्जेक्ट द्वारा प्रदर्शित [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) ऑब्जेक्ट की [Slides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) (सामग्री स्लाइड ऑब्जेक्ट्स का संग्रह) प्रॉपर्टी का संदर्भ सेट करके [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection) क्लास का एक उदाहरण बनाएं।
- प्रस्तुति में सामग्री स्लाइड्स संग्रह के अंत में एक खाली स्लाइड जोड़ने के लिए [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection) ऑब्जेक्ट द्वारा प्रदर्शित [**addEmptySlide**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) मेथड को कॉल करें।
- नए जोड़े गए खाली स्लाइड के साथ कुछ कार्य करें।
- अंत में, [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) ऑब्जेक्ट का उपयोग करके प्रस्तुति फ़ाइल लिखें।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation();
try {
    // SlideCollection क्लास को इंस्टैंशिएट करें
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slides संग्रह में एक खाली स्लाइड जोड़ें
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // नई जोड़ी गई स्लाइड पर कुछ काम करें

    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नई स्लाइड को अंत में केवल नहीं, बल्कि विशिष्ट स्थिति पर सम्मिलित कर सकता हूं?**

हाँ। लाइब्रेरी स्लाइड संग्रह और [insert](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ऑपरेशन्स का समर्थन करती है, इसलिए आप केवल अंत में नहीं, बल्कि आवश्यक इंडेक्स पर स्लाइड जोड़ सकते हैं।

**क्या लेआउट के आधार पर स्लाइड जोड़ते समय थीम/स्टाइल संरक्षित रहती हैं?**

हाँ। लेआउट अपने मास्टर से फ़ॉर्मेटिंग को विरासत में लेता है, और नई स्लाइड चयनित लेआउट और उसके संबंधित मास्टर से विरासत में लेती है।

**स्लाइड जोड़ने से पहले नई "खाली" प्रस्तुति में कौन सी स्लाइड मौजूद होती है?**

नव निर्मित प्रस्तुति में पहले से ही शून्य इंडेक्स वाली एक खाली स्लाइड मौजूद होती है। यह सम्मिलन इंडेक्स की गणना करते समय महत्वपूर्ण है।

**यदि मास्टर में कई विकल्प हैं तो नई स्लाइड के लिए "सही" लेआउट कैसे चुनें?**

आमतौर पर वह [LayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/layoutslide/) चुनें जो आवश्यक संरचना ([Title and Content, Two Content, आदि](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidelayouttype/)) से मेल खाता हो। यदि ऐसी लेआउट उपलब्ध नहीं है, तो आप इसे [add it to the master](/slides/hi/java/slide-layout/) में जोड़ सकते हैं और फिर उपयोग करें।