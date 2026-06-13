---
title: जावास्क्रिप्ट में प्रस्तुति स्लाइड्स तक पहुंचें
linktitle: स्लाइड तक पहुंचें
type: docs
weight: 20
url: /hi/nodejs-java/access-slide-in-presentation/
keywords:
- स्लाइड तक पहुंचें
- स्लाइड अनुक्रमणिका
- स्लाइड आईडी
- स्लाइड स्थिती
- स्थिति बदलें
- स्लाइड गुण
- स्लाइड संख्या
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स तक पहुंचने और उनका प्रबंधन करने के बारे में जानें। कोड उदाहरणों से उत्पादनशीलता बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में स्लाइड्स तक पहुंचने और उनका प्रबंधन करने के तरीकों को समझाता है। यह दिखाता है कि स्लाइड्स संग्रह से शून्य-आधारित अनुक्रमणिका के आधार पर स्लाइड्स कैसे प्राप्त करें और `getSlideById` मेथड का उपयोग करके उसके अनूठे ID से स्लाइड तक कैसे पहुंचें।

आप यह भी सीखेंगे कि `setSlideNumber` मेथड का उपयोग करके स्लाइड की स्थिति कैसे बदलें और `setFirstSlideNumber` मेथड से प्रस्तुति के लिए प्रारंभिक स्लाइड संख्या कैसे निर्धारित करें। उदाहरणों में प्रस्तुति लोड करना, स्लाइड संदर्भ प्राप्त करना, स्लाइड क्रम या क्रमांक अपडेट करना, और संशोधित प्रस्तुति को सहेजना दिखाया गया है।

## **इंडेक्स द्वारा स्लाइड तक पहुंचें**

एक प्रस्तुति में सभी स्लाइड्स को स्लाइड स्थिति के आधार पर संख्यात्मक रूप से व्यवस्थित किया जाता है, जो 0 से शुरू होती है। पहली स्लाइड को इंडेक्स 0 से पहुंचा जा सकता है; दूसरी स्लाइड को इंडेक्स 1 से; आदि।

Presentation क्लास, जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है, सभी स्लाइड्स को एक [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) संग्रह ( [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) वस्तुओं की संग्रह) के रूप में उजागर करती है। यह JavaScript कोड आपको दिखाता है कि इंडेक्स के माध्यम से स्लाइड तक कैसे पहुंचा जाए:

```javascript
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // स्लाइड को उसके स्लाइड अनुक्रमणिका का उपयोग करके पहुँचता है
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **ID द्वारा स्लाइड तक पहुंचें**

एक प्रस्तुति में प्रत्येक स्लाइड का एक अनूठा ID जुड़ा होता है। आप इस ID को लक्षित करने के लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास द्वारा उजागर किए गए [getSlideById](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSlideById-long-) मेथड का उपयोग कर सकते हैं। यह JavaScript कोड दिखाता है कि वैध स्लाइड ID प्रदान करके और [getSlideById](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSlideById-long-) मेथड का उपयोग करके उस स्लाइड तक कैसे पहुंचा जाए:

```javascript
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // स्लाइड ID प्राप्त करता है
    var id = pres.getSlides().get_Item(0).getSlideId();
    // स्लाइड को उसके ID के माध्यम से पहुँचता है
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **स्लाइड स्थिति बदलें**

Aspose.Slides आपको स्लाइड की स्थिति बदलने की अनुमति देता है। उदाहरण के लिए, आप यह निर्दिष्ट कर सकते हैं कि पहली स्लाइड दूसरी बन जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
1. उस स्लाइड का संदर्भ प्राप्त करें (जिसकी स्थिति आप बदलना चाहते हैं) उसका इंडेक्स उपयोग करके।  
1. [setSlideNumber](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#setSlideNumber-int-) प्रॉपर्टी के माध्यम से स्लाइड की नई स्थिति सेट करें।  
1. संशोधित प्रस्तुति को सहेजें।

यह JavaScript कोड एक ऑपरेशन को दर्शाता है जिसमें स्थिति 1 वाली स्लाइड को स्थिति 2 पर ले जाया जाता है:

```javascript
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // वह स्लाइड प्राप्त करता है जिसकी स्थिति बदली जाएगी
    var sld = pres.getSlides().get_Item(0);
    // स्लाइड के लिए नई स्थिति सेट करता है
    sld.setSlideNumber(2);
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

पहली स्लाइड दूसरी बन गई; दूसरी स्लाइड पहली बन गई। जब आप स्लाइड की स्थिति बदलते हैं, तो अन्य स्लाइड्स स्वचालित रूप से समायोजित हो जाती हैं।

## **स्लाइड नंबर सेट करें**

[Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास द्वारा उजागर किए गए [setFirstSlideNumber](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) प्रॉपर्टी का उपयोग करके आप प्रस्तुति में पहली स्लाइड के लिए नया नंबर निर्धारित कर सकते हैं। यह ऑपरेशन अन्य स्लाइड नंबरों को पुनः गणना करने का कारण बनता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
1. स्लाइड नंबर प्राप्त करें।  
1. स्लाइड नंबर सेट करें।  
1. संशोधित प्रस्तुति को सहेजें।

यह JavaScript कोड दर्शाता है कि पहली स्लाइड का नंबर 10 पर सेट किया गया है:

```javascript
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // स्लाइड संख्या प्राप्त करता है
    var firstSlideNumber = pres.getFirstSlideNumber();
    // स्लाइड संख्या सेट करता है
    pres.setFirstSlideNumber(10);
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

यदि आप पहली स्लाइड को छोड़ना चाहते हैं, तो आप क्रमांकन को दूसरी स्लाइड से शुरू कर सकते हैं (और पहली स्लाइड के लिए क्रमांकन को छिपा सकते हैं) इस तरह:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // पहली प्रस्तुति स्लाइड के लिए संख्या सेट करता है
    presentation.setFirstSlideNumber(0);
    // सभी स्लाइड्स के लिए स्लाइड नंबर दिखाता है
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // पहली स्लाइड के लिए स्लाइड नंबर छुपाता है
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // संशोधित प्रस्तुति को सहेजता है
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**क्या उपयोगकर्ता को दिखाया गया स्लाइड नंबर संग्रह के शून्य-आधारित इंडेक्स से मेल खाता है?**

स्लाइड पर दिखाया गया नंबर मनमाने मूल्य (जैसे 10) से शुरू हो सकता है और इसे इंडेक्स से मिलाना आवश्यक नहीं है; यह संबंध प्रस्तुति के [first slide number](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) सेटिंग द्वारा नियंत्रित किया जाता है।

**क्या छिपी हुई स्लाइड्स इंडेक्सिंग को प्रभावित करती हैं?**

हां। एक छिपी हुई स्लाइड संग्रह में बनी रहती है और इंडेक्सिंग में गिनी जाती है; "छिपी हुई" का अर्थ केवल प्रदर्शन से है, न कि संग्रह में उसकी स्थिति से।

**क्या अन्य स्लाइड्स जोड़ने या हटाने पर स्लाइड का इंडेक्स बदलता है?**

हां। इंडेक्स हमेशा वर्तमान स्लाइड क्रम को दर्शाते हैं और सम्मिलित, हटाए या स्थानांतरित करने के बाद पुनः गणना की जाती हैं।