---
title: Java में प्रस्तुति स्लाइड्स तक पहुँचें
linktitle: स्लाइड तक पहुँचें
type: docs
weight: 20
url: /hi/java/access-slide-in-presentation/
keywords:
- स्लाइड तक पहुँचें
- स्लाइड अनुक्रमणिका
- स्लाइड पहचान
- स्लाइड स्थिति
- स्थिति बदलें
- स्लाइड गुण
- स्लाइड नंबर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स तक पहुँचने और उनका प्रबंधन करने के लिए सीखें। कोड उदाहरणों के साथ उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में स्लाइड को कैसे एक्सेस और प्रबंधित किया जाए, यह समझाता है। यह दिखाता है कि स्लाइड्स संग्रह से शून्य-आधारित इंडेक्स द्वारा स्लाइड्स को कैसे प्राप्त किया जाए और `getSlideById` मेथड का प्रयोग करके उसकी विशिष्ट ID से स्लाइड को कैसे एक्सेस किया जाए।

आप यह भी सीखेंगे कि `setSlideNumber` मेथड का उपयोग करके स्लाइड का स्थान कैसे बदलें और `setFirstSlideNumber` मेथड से प्रस्तुति के लिए प्रारंभिक स्लाइड नंबर कैसे निर्धारित करें। उदाहरणों में प्रस्तुति लोड करना, स्लाइड रेफरेंसेस प्राप्त करना, स्लाइड क्रम या क्रमांकन को अपडेट करना, और संशोधित प्रस्तुति को सहेजना दर्शाया गया है।

## **इंडेक्स द्वारा स्लाइड तक पहुँचें**

एक प्रस्तुति में सभी स्लाइड्स को स्लाइड स्थिति के आधार पर संख्यात्मक रूप से व्यवस्थित किया जाता है, जो 0 से शुरू होती है। पहला स्लाइड इंडेक्स 0 के माध्यम से एक्सेस किया जाता है; दूसरा स्लाइड इंडेक्स 1 के माध्यम से; आदि।

Presentation क्लास, जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है, सभी स्लाइड्स को एक [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) संग्रह (जिनमें [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) ऑब्जेक्ट होते हैं) के रूप में उजागर करता है। यह जावा कोड आपको दिखाता है कि इंडेक्स द्वारा स्लाइड कैसे एक्सेस करें:

```java
// एक Presentation ऑब्जेक्ट का इंस्टेंस बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("demo.pptx");
try {
    // स्लाइड को उसके स्लाइड इंडेक्स का उपयोग करके एक्सेस करता है
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **ID द्वारा स्लाइड तक पहुँचें**

प्रति प्रस्तुति प्रत्येक स्लाइड का एक विशिष्ट ID जुड़ा होता है। आप इस ID को लक्षित करने के लिए [getSlideById](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlideById-long-) मेथड (जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास द्वारा उपलब्ध कराई गई है) का उपयोग कर सकते हैं। यह जावा कोड आपको दिखाता है कि वैध स्लाइड ID प्रदान करके उस स्लाइड को [getSlideById](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlideById-long-) मेथड से कैसे एक्सेस किया जाए:

```java
// एक Presentation ऑब्जेक्ट का इंस्टेंस बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("demo.pptx");
try {
    // स्लाइड ID प्राप्त करता है
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // ID के माध्यम से स्लाइड को एक्सेस करता है
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **स्लाइड स्थान बदलें**

Aspose.Slides आपको स्लाइड का स्थान बदलने की सुविधा देता है। उदाहरण के तौर पर, आप निर्दिष्ट कर सकते हैं कि पहला स्लाइड दूसरा स्लाइड बन जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. उस स्लाइड का रेफरेंस प्राप्त करें (जिसका स्थान बदलना है) उसके इंडेक्स के माध्यम से।
1. स्लाइड के लिए नया स्थान [setSlideNumber](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#setSlideNumber-int-) प्रॉपर्टी के माध्यम से सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह जावा कोड एक ऑपरेशन दिखाता है जिसमें स्थिति 1 वाली स्लाइड को स्थिति 2 पर ले जाया जाता है:

```java
// एक Presentation ऑब्जेक्ट का इंस्टेंस बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Presentation.pptx");
try {
    // स्लाइड को प्राप्त करता है जिसकी स्थिति बदली जाएगी
    ISlide sld = pres.getSlides().get_Item(0);
    
    // स्लाइड के लिए नई स्थिति सेट करता है
    sld.setSlideNumber(2);
    
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

पहला स्लाइड दूसरा बन गया; दूसरा स्लाइड पहला बन गया। जब आप स्लाइड का स्थान बदलते हैं, तो अन्य स्लाइड्स स्वचालित रूप से समायोजित हो जाती हैं।

## **स्लाइड नंबर निर्धारित करें**

[setFirstSlideNumber](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) प्रॉपर्टी (जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास द्वारा उपलब्ध है) का उपयोग करके आप प्रस्तुति में पहले स्लाइड के लिए नया नंबर निर्दिष्ट कर सकते हैं। यह ऑपरेशन अन्य स्लाइड नंबरों को पुनः गणना कराता है।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. स्लाइड नंबर प्राप्त करें।
1. स्लाइड नंबर सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

यह जावा कोड वह ऑपरेशन दर्शाता है जहाँ पहले स्लाइड का नंबर 10 सेट किया गया है:

```java
// एक Presentation ऑब्जेक्ट का इंस्टेंस बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
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

यदि आप पहले स्लाइड को छोड़ना चाहते हैं, तो आप नंबरिंग को दूसरे स्लाइड से शुरू कर सकते हैं (और पहले स्लाइड के लिए नंबरिंग को छिपा सकते हैं) इस प्रकार:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // प्रस्तुति की पहली स्लाइड के लिए संख्या सेट करता है
    presentation.setFirstSlideNumber(0);

    // सभी स्लाइड्स के लिए स्लाइड नंबर दिखाता है
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // पहली स्लाइड के लिए स्लाइड नंबर को छुपाता है
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // संशोधित प्रस्तुति को सहेजता है
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या उपयोगकर्ता द्वारा देखे जाने वाला स्लाइड नंबर संग्रह के शून्य-आधारित इंडेक्स से मेल खाता है?**

स्लाइड पर दिखाया गया नंबर मनमाने मान (जैसे 10) से शुरू हो सकता है और उसे इंडेक्स से मिलान करने की आवश्यकता नहीं है; यह संबंध प्रस्तुति के [first slide number](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) सेटिंग द्वारा नियंत्रित होता है।

**क्या छिपी हुई स्लाइड्स इंडेक्सिंग को प्रभावित करती हैं?**

हाँ। एक छिपी हुई स्लाइड संग्रह में बनी रहती है और इंडेक्सिंग में गिनी जाती है; "छिपी हुई" का अर्थ केवल प्रदर्शन से है, न कि संग्रह में उसकी स्थिति से।

**क्या अन्य स्लाइड्स जोड़ने या हटाने पर स्लाइड का इंडेक्स बदलता है?**

हाँ। इंडेक्स हमेशा स्लाइड्स के वर्तमान क्रम को दर्शाते हैं और सम्मिलन, विलोपन और स्थानांतरण ऑपरेशनों पर पुनः गणना होते हैं।