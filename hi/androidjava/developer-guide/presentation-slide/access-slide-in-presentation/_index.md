---
title: Android पर प्रस्तुति स्लाइड्स तक पहुँचें
linktitle: स्लाइड तक पहुँचें
type: docs
weight: 20
url: /hi/androidjava/access-slide-in-presentation/
keywords:
- स्लाइड तक पहुँचना
- स्लाइड इंडेक्स
- स्लाइड आईडी
- स्लाइड स्थिति
- स्थिति बदलें
- स्लाइड गुण
- स्लाइड नंबर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स को एक्सेस और प्रबंधित करना सीखें। जावा कोड उदाहरणों के साथ उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में स्लाइड्स को एक्सेस और प्रबंधित करने के तरीके को समझाता है। यह स्लाइड्स संग्रह से शून्य-आधारित इंडेक्स द्वारा स्लाइड्स प्राप्त करने तथा `getSlideById` मेथड का उपयोग करके एक स्लाइड को उसके अद्वितीय ID से एक्सेस करने का तरीका दर्शाता है।

आप `setSlideNumber` मेथड का उपयोग करके स्लाइड की स्थिति बदलना और `setFirstSlideNumber` मेथड से प्रस्तुति के प्रारंभिक स्लाइड नंबर को निर्धारित करना भी सीखेंगे। उदाहरणों में प्रस्तुति लोड करना, स्लाइड रेफ़रेंसेज़ प्राप्त करना, स्लाइड क्रम या क्रमांक अपडेट करना, और संशोधित प्रस्तुति को सहेजना दिखाया गया है।

## **इंडेक्स द्वारा स्लाइड तक पहुँचें**

एक प्रस्तुति में सभी स्लाइड्स स्लाइड पोजीशन के आधार पर संख्यात्मक रूप से व्यवस्थित होती हैं, जो 0 से शुरू होती है। पहला स्लाइड इंडेक्स 0 के माध्यम से पहुँचा जा सकता है; दूसरा स्लाइड इंडेक्स 1 के माध्यम से पहुँचा जाता है; आदि।

Presentation क्लास, जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है, सभी स्लाइड्स को एक [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) संग्रह (जिसमें [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) ऑब्जेक्ट्स होते हैं) के रूप में उजागर करता है। यह जावा कोड दिखाता है कि कैसे इंडेक्स के माध्यम से स्लाइड तक पहुँचा जाए:

```java
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("demo.pptx");
try {
    // स्लाइड को उसके स्लाइड इंडेक्स का उपयोग करके पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **ID द्वारा स्लाइड तक पहुँचें**

प्रस्तुति में प्रत्येक स्लाइड का एक अनूठा ID जुड़ा होता है। आप उस ID को लक्षित करने के लिए [getSlideById](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlideById-long-) मेथड (जो [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है) का उपयोग कर सकते हैं। यह जावा कोड दिखाता है कि वैध स्लाइड ID कैसे प्रदान करें और [getSlideById](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlideById-long-) मेथड के माध्यम से उस स्लाइड तक पहुँचें:

```java
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("demo.pptx");
try {
    // एक स्लाइड ID प्राप्त करता है
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // स्लाइड को उसके ID के माध्यम से एक्सेस करता है
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **स्लाइड की स्थिति बदलें**

Aspose.Slides आपको स्लाइड की स्थिति बदलने की अनुमति देता है। उदाहरण के लिए, आप यह निर्धारित कर सकते हैं कि पहला स्लाइड दूसरा बन जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उस स्लाइड का रेफ़रेंस प्राप्त करें (जिसकी स्थिति बदलनी है) उसके इंडेक्स के माध्यम से।
1. स्लाइड की नई स्थिति को [setSlideNumber](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#setSlideNumber-int-) प्रॉपर्टी के माध्यम से सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह जावा कोड एक ऐसी कार्रवाई दिखाता है जिसमें स्थिति 1 में स्थित स्लाइड को स्थिति 2 पर ले जाया जाता है: 

```java
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Presentation.pptx");
try {
    // उस स्लाइड को प्राप्त करता है जिसकी स्थिति बदली जाएगी
    ISlide sld = pres.getSlides().get_Item(0);
    
    // स्लाइड के लिए नई स्थिति सेट करता है
    sld.setSlideNumber(2);
    
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

पहला स्लाइड दूसरा बन गया; दूसरा स्लाइड पहला बन गया। जब आप स्लाइड की स्थिति बदलते हैं, तो अन्य स्लाइड्स स्वत: समायोजित हो जाती हैं।

## **स्लाइड नंबर सेट करें**

[setFirstSlideNumber](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) प्रॉपर्टी (जो [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास द्वारा उपलब्ध कराई जाती है) का उपयोग करके आप प्रस्तुति में पहले स्लाइड के लिए नया नंबर निर्धारित कर सकते हैं। यह कार्रवाई अन्य स्लाइड नंबरों को पुनः गणना करने का कारण बनती है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. स्लाइड नंबर प्राप्त करें।
1. स्लाइड नंबर सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह जावा कोड एक ऐसी कार्रवाई दिखाता है जहाँ पहले स्लाइड नंबर को 10 पर सेट किया गया है: 

```java
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // स्लाइड नंबर प्राप्त करता है
    int firstSlideNumber = pres.getFirstSlideNumber();

    // स्लाइड नंबर सेट करता है
    pres.setFirstSlideNumber(10);
	
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

यदि आप पहला स्लाइड छोड़ना चाहते हैं, तो आप नंबरिंग को दूसरे स्लाइड से शुरू कर सकते हैं (और पहले स्लाइड के लिए नंबरिंग को छिपा सकते हैं) इस प्रकार:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // पहली प्रस्तुति स्लाइड के लिए नंबर सेट करता है
    presentation.setFirstSlideNumber(0);

    // सभी स्लाइड्स के लिए स्लाइड नंबर दिखाता है
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // पहली स्लाइड के लिए स्लाइड नंबर छुपाता है
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // संशोधित प्रस्तुति को सहेजता है
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या उपयोगकर्ता को दिखने वाला स्लाइड नंबर संग्रह के शून्य-आधारित इंडेक्स के बराबर होता है?**

स्लाइड पर दिखाया गया नंबर मनचाहे मान (जैसे 10) से शुरू हो सकता है और उसे इंडेक्स से मिलना आवश्यक नहीं है; यह संबंध प्रस्तुति के [first slide number](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) सेटिंग द्वारा नियंत्रित किया जाता है।

**क्या छिपी हुई स्लाइड्स इंडेक्सिंग को प्रभावित करती हैं?**

हां। एक छिपी हुई स्लाइड संग्रह में बनी रहती है और इंडेक्सिंग में गिनी जाती है; "छिपी" शब्द केवल दिखाने से संबंधित है, न कि संग्रह में उसकी स्थिति से।

**क्या अन्य स्लाइड्स जोड़ने या हटाने पर स्लाइड का इंडेक्स बदलता है?**

हां। इंडेक्स हमेशा स्लाइड्स के वर्तमान क्रम को दर्शाते हैं और जोड़ने, हटाने और स्थानांतरित करने के ऑपरेशनों के बाद पुनः गणना किए जाते हैं।