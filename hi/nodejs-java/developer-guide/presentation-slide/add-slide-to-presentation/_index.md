---
title: जावास्क्रिप्ट में प्रस्तुतियों में स्लाइड जोड़ें
linktitle: स्लाइड जोड़ें
type: docs
weight: 10
url: /hi/nodejs-java/add-slide-to-presentation/
keywords:
- स्लाइड जोड़ें
- स्लाइड बनाएं
- खाली स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके अपने PowerPoint और OpenDocument प्रस्तुतियों में आसानी से स्लाइड जोड़ें — सेकंड में सहज और प्रभावी स्लाइड सम्मिलन।"
---
## **समीक्षा**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में स्लाइड जोड़ने की अनुमति देता है। एक प्रस्तुति में मास्टर/लेआउट स्लाइड और सामान्य स्लाइड होते हैं, और सामान्य स्लाइड शून्य‑आधारित अनुक्रमणिका द्वारा व्यवस्थित होती हैं। प्रत्येक स्लाइड का एक अनूठा ID होता है, और स्लाइड‑रहित प्रस्तुति फ़ाइलें समर्थित नहीं हैं।

यह लेख बताता है कि कैसे `Presentation` ऑब्जेक्ट बनाएं, उसकी स्लाइड कलेक्शन तक पहुँचें, एक खाली स्लाइड जोड़ें, नई जोड़ी गई स्लाइड के साथ काम करें, और अपडेटेड प्रस्तुति को सहेजें। इसमें स्लाइड को विशिष्ट स्थिति पर सम्मिलित करना, लेआउट का उपयोग करना, और नई बनाई गई प्रस्तुति में मौजूद खाली स्लाइड को समझना जैसे बिंदु भी शामिल हैं।

## **प्रस्तुति में स्लाइड जोड़ें**

प्रस्तुति फ़ाइलों में स्लाइड जोड़ने से पहले, चलिए स्लाइडों के बारे में कुछ तथ्य चर्चा करते हैं। प्रत्येक PowerPoint प्रस्तुति फ़ाइल में **मास्टर / लेआउट** स्लाइड और अन्य **सामान्य** स्लाइडें होती हैं। इसका अर्थ है कि एक प्रस्तुति फ़ाइल में कम से कम एक या अधिक स्लाइडें होती हैं। यह जानना महत्वपूर्ण है कि स्लाइड‑रहित प्रस्तुति फ़ाइलें Aspose.Slides for Node.js via Java द्वारा समर्थित नहीं हैं। प्रत्येक स्लाइड का एक अनूठा Id होता है और सभी सामान्य स्लाइडें शून्य‑आधारित अनुक्रमणिका द्वारा निर्दिष्ट क्रम में व्यवस्थित होती हैं।

Aspose.Slides for Node.js via Java डेवलपर्स को उनकी प्रस्तुति में खाली स्लाइड जोड़ने की सुविधा देता है। प्रस्तुति में खाली स्लाइड जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
- [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) ऑब्जेक्ट द्वारा प्रदर्शित [Slides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) (सामग्री स्लाइड ऑब्जेक्ट्स का संग्रह) प्रॉपर्टी का संदर्भ सेट करके [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection) क्लास का इंस्टेंस बनाएं।
- सामग्री स्लाइड संग्रह के अंत में एक खाली स्लाइड जोड़ने के लिए [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection) ऑब्जेक्ट द्वारा प्रदर्शित [**addEmptySlide**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) मेथड को कॉल करें।
- नई जोड़ी गई खाली स्लाइड के साथ कुछ कार्य करें।
- अंत में, [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) ऑब्जेक्ट का उपयोग करके प्रस्तुति फ़ाइल लिखें।

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    // SlideCollection क्लास का उदाहरण बनाएं
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slides संग्रह में एक खाली स्लाइड जोड़ें
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // नई जोड़ी गई स्लाइड पर कुछ कार्य करें
    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड को केवल अंत में नहीं, बल्कि किसी विशिष्ट स्थिति पर भी डाल सकता हूँ?**

हाँ। लाइब्रेरी स्लाइड कलेक्शन और [insert](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/insertclone/) ऑपरेशनों का समर्थन करती है, इसलिए आप आवश्यक अनुक्रमणिका पर स्लाइड जोड़ सकते हैं, केवल अंत में नहीं।

**क्या लेआउट पर आधारित स्लाइड जोड़ते समय थीम/स्टाइल बरकरार रहते हैं?**

हाँ। एक लेआउट अपने मास्टर से फॉर्मेटिंग विरासत में प्राप्त करता है, और नई स्लाइड चयनित लेआउट और उसके संबंधित मास्टर से विरासत में प्राप्त करती है।

**एक नई “खाली” प्रस्तुति में स्लाइड जोड़ने से पहले कौन सी स्लाइड मौजूद होती है?**

एक नई बनाई गई प्रस्तुति में पहले से ही एक खाली स्लाइड होती है जिसका अनुक्रमणिका शून्य है। यह प्रविष्टि अनुक्रमणिकाओं की गणना करते समय महत्वपूर्ण है।

**यदि मास्टर में कई विकल्प हों, तो नई स्लाइड के लिए “सही” लेआउट कैसे चुनें?**

आमतौर पर वह [LayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) चुनें जो आवश्यक संरचना ([Title and Content, Two Content, आदि](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidelayouttype/)) के साथ मेल खाती हो। यदि ऐसा लेआउट मौजूद नहीं है, तो आप इसे [मास्टर में जोड़ सकते हैं](/slides/hi/nodejs-java/slide-layout/) और फिर उसका उपयोग कर सकते हैं।