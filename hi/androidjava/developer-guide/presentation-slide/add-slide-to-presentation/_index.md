---
title: Android पर प्रस्तुतियों में स्लाइड जोड़ें
linktitle: स्लाइड जोड़ें
type: docs
weight: 10
url: /hi/androidjava/add-slide-to-presentation/
keywords:
- स्लाइड जोड़ें
- स्लाइड बनाएं
- खाली स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके अपने PowerPoint और OpenDocument प्रस्तुतियों में आसानी से स्लाइड जोड़ें—सेकंडों में सहज, कुशल स्लाइड सम्मिलन।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामेटिक तरीके से PowerPoint प्रस्तुतियों में स्लाइड जोड़ने की अनुमति देता है। एक प्रस्तुति में master/layout स्लाइड और सामान्य स्लाइड होती हैं, और सामान्य स्लाइड को शून्य-आधारित इंडेक्स द्वारा व्यवस्थित किया जाता है। प्रत्येक स्लाइड का एक अनूठा ID होता है, और स्लाइड रहित प्रस्तुति फ़ाइलें समर्थित नहीं हैं।

यह लेख बताता है कि कैसे `Presentation` ऑब्जेक्ट बनाया जाए, उसकी स्लाइड कलेक्शन तक पहुंचा जाए, एक खाली स्लाइड जोड़ी जाए, नई जोड़ी गई स्लाइड के साथ काम किया जाए, और अद्यतन प्रस्तुति सहेजी जाए। यह विशिष्ट स्थान पर स्लाइड जोड़ना, लेआउट का उपयोग करना, और नई बनाई गई प्रस्तुति में मौजूद खाली स्लाइड को समझना जैसे संबंधित बिंदुओं को भी कवर करता है।

## **प्रस्तुति में स्लाइड जोड़ें**

प्रेजेंटेशन फ़ाइलों में स्लाइड जोड़ने के बारे में बात करने से पहले, आइए स्लाइड के कुछ तथ्य देखें। प्रत्येक PowerPoint प्रस्तुति फ़ाइल में **Master / Layout** स्लाइड और अन्य **Normal** स्लाइड्स होती हैं। इसका मतलब है कि एक प्रस्तुति फ़ाइल में कम से कम एक या अधिक स्लाइड्स होती हैं। यह जानना महत्वपूर्ण है कि Aspose.Slides for Android via Java द्वारा स्लाइड-रहित प्रस्तुति फ़ाइलों को समर्थन नहीं मिलता है। प्रत्येक स्लाइड का एक अनूठा Id होता है और सभी Normal स्लाइड्स शून्य-आधारित इंडेक्स द्वारा निर्धारित क्रम में व्यवस्थित होती हैं।

Aspose.Slides for Android via Java डेवलपर्स को उनकी प्रस्तुति में खाली स्लाइड जोड़ने की अनुमति देता है। प्रस्तुति में एक खाली स्लाइड जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक instance बनाएँ [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का।
- [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection) क्लास को इंस्टैंसिएट करें, जहाँ [Slides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) (सामग्री Slide ऑब्जेक्ट्स का संग्रह) प्रॉपर्टी की रेफरेंस सेट की जाती है, जो [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर की गई है।
- प्रस्तुति में सामग्री स्लाइड्स संग्रह के अंत में एक खाली स्लाइड जोड़ें, इसके लिए [**addEmptySlide**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) मेथड को कॉल करें, जो [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection) ऑब्जेक्ट द्वारा उजागर किया गया है।
- नई जोड़ी गई खाली स्लाइड के साथ कुछ कार्य करें।
- अंत में, [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) ऑब्जेक्ट का उपयोग करके प्रस्तुति फ़ाइल लिखें।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को instantiate करें
Presentation pres = new Presentation();
try {
    // SlideCollection क्लास को instantiate करें
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slides संग्रह में एक खाली स्लाइड जोड़ें
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // नई जोड़ी गई स्लाइड पर कुछ कार्य करें

    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Can I insert a new slide at a specific position, not just at the end?**

हाँ। लाइब्रेरी स्लाइड कलेक्शन और [insert](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ऑपरेशन का समर्थन करती है, इसलिए आप आवश्यक इंडेक्स पर स्लाइड जोड़ सकते हैं, न कि केवल अंत में।

**Are the theme/styles preserved when adding a slide based on a layout?**

हाँ। एक लेआउट अपने master से फ़ॉर्मेटिंग को विरासत में लेता है, और नई स्लाइड चयनित लेआउट और उसके संबंधित master से विरासत में लेती है।

**Which slide is present in a new "empty" presentation before adding slides?**

एक नई बनाई गई प्रस्तुति में पहले से ही शून्य इंडेक्स वाली एक खाली स्लाइड होती है। यह सम्मिलन इंडेक्स की गणना करते समय ध्यान में रखना महत्वपूर्ण है।

**How do I choose the "right" layout for a new slide if the master has many options?**

आमतौर पर आवश्यक संरचना से मेल खाने वाला [LayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslide/) चुनें ([Title and Content, Two Content, आदि](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidelayouttype/))। यदि ऐसा लेआउट उपस्थित नहीं है, तो आप उसे [add it to the master](/slides/hi/androidjava/slide-layout/) कर सकते हैं और फिर उपयोग कर सकते हैं।