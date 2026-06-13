---
title: जावा का उपयोग करके प्रस्तुतियों में SmartArt ग्राफ़िक्स प्रबंधित करें
linktitle: SmartArt ग्राफ़िक्स
type: docs
weight: 20
url: /hi/java/manage-smartart-shape/
keywords:
- SmartArt ऑब्जेक्ट
- SmartArt ग्राफ़िक
- SmartArt शैली
- SmartArt रंग
- SmartArt बनाएं
- SmartArt जोड़ें
- SmartArt संपादित करें
- SmartArt बदलें
- SmartArt तक पहुंचें
- SmartArt लेआउट प्रकार
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके जावा में PowerPoint SmartArt निर्माण, संपादन और स्टाइलिंग को स्वचालित करें, संक्षिप्त कोड उदाहरण और प्रदर्शन-केंद्रित मार्गदर्शन प्रदान करता है।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में SmartArt ग्राफ़िक्स को प्रोग्रामेटिक रूप से बनाने और प्रबंधित करने की अनुमति देता है। यह लेख बताता है कि कैसे एक स्लाइड में SmartArt आकार जोड़ा जाए, मौजूदा SmartArt आकारों तक पहुंचा जाए, विशिष्ट लेआउट प्रकार द्वारा SmartArt पाया जाए, और SmartArt शैली या कलर शैली बदलकर उसकी दृश्य उपस्थिति को अपडेट किया जाए।

उदाहरण दिखाते हैं कि प्रस्तुति स्लाइड के आकार संग्रह के माध्यम से SmartArt आकारों के साथ कैसे काम किया जाए, यह जांचें कि कोई आकार SmartArt है या नहीं, और फिर उसके गुणों को संशोधित या निरीक्षण किया जाए।

## **SmartArt आकार बनाएं**
Aspose.Slides for Java ने SmartArt आकार बनाने के लिए एक API प्रदान किया है। स्लाइड में SmartArt आकार बनाने के लिए, कृपया नीचे दिए गए कदमों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. उसके Index का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [LayoutType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType) सेट करके [Add a SmartArt shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) जोड़ें।  
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```java
// Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Smart Art आकार जोड़ें
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // प्रस्तुति सहेजें
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**चित्र: स्लाइड में जोड़ा गया SmartArt आकार**|

## **स्लाइड पर SmartArt आकार तक पहुंचें**
निम्न कोड का उपयोग प्रस्तुति स्लाइड में जोड़े गए SmartArt आकारों तक पहुंचने के लिए किया जाएगा। नमूना कोड में हम स्लाइड के भीतर प्रत्येक आकार को पार करेंगे और जांचेंगे कि क्या वह [SmartArt] आकार है। यदि आकार SmartArt प्रकार का है तो हम उसे [**SmartArt**] इंस्टेंस में टाइपकास्ट करेंगे।

```java
// इच्छित प्रस्तुतिकरण लोड करें
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार को पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt)
        {
            // आकार को SmartArtEx में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट LayoutType के साथ SmartArt आकार तक पहुंचें**
निम्न नमूना कोड विशेष LayoutType वाले [SmartArt] आकार तक पहुंचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt का LayoutType नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और केवल तभी सेट होता है जब [SmartArt] आकार जोड़ा जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं और SmartArt आकार वाली प्रस्तुति लोड करें।  
2. पहले स्लाइड का रेफ़रेंस उसके Index से प्राप्त करें।  
3. पहले स्लाइड के भीतर प्रत्येक आकार को पार करें।  
4. जांचें कि क्या आकार [SmartArt] प्रकार का है और यदि यह SmartArt है तो चयनित आकार को SmartArt में टाइपकास्ट करें।  
5. विशिष्ट LayoutType वाले SmartArt आकार की जाँच करें और बाद में आवश्यक कार्य करें।

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार को पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt)
        {
            // आकार को SmartArtEx में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt लेआउट की जाँच
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt आकार शैली बदलें**
इस उदाहरण में, हम किसी भी SmartArt आकार के लिए त्वरित शैली बदलना सीखेंगे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं और SmartArt आकार वाली प्रस्तुति लोड करें।  
2. पहले स्लाइड का रेफ़रेंस उसके Index से प्राप्त करें।  
3. पहले स्लाइड के भीतर प्रत्येक आकार को पार करें।  
4. जांचें कि क्या आकार [SmartArt] प्रकार का है और यदि यह SmartArt है तो चयनित आकार को SmartArt में टाइपकास्ट करें।  
5. विशिष्ट शैली वाले SmartArt आकार को खोजें।  
6. SmartArt आकार के लिए नई शैली सेट करें।  
7. प्रस्तुति सहेजें।

```java
// Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के भीतर प्रत्येक आकार को पार करें
    for (IShape shape : slide.getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArtEx में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt शैली की जाँच
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt शैली बदल रहे हैं
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // प्रस्तुति सहेजें
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**चित्र: बदल दी गई शैली वाला SmartArt आकार**|

## **SmartArt आकार रंग शैली बदलें**
इस उदाहरण में, हम किसी भी SmartArt आकार के लिए रंग शैली बदलना सीखेंगे। अगले नमूना कोड में हम विशेष रंग शैली वाले SmartArt आकार तक पहुंचेंगे और उसकी शैली बदलेंगे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं और SmartArt आकार वाली प्रस्तुति लोड करें।  
2. पहले स्लाइड का रेफ़रेंस उसके Index से प्राप्त करें।  
3. पहले स्लाइड के भीतर प्रत्येक आकार को पार करें।  
4. जांचें कि क्या आकार [SmartArt] प्रकार का है और यदि यह SmartArt है तो चयनित आकार को SmartArt में टाइपकास्ट करें।  
5. विशिष्ट रंग शैली वाले SmartArt आकार को खोजें।  
6. SmartArt आकार के लिए नई रंग शैली सेट करें।  
7. प्रस्तुति सहेजें।

```java
// Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के भीतर प्रत्येक आकार को पार करें
    for (IShape shape : slide.getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArtEx में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt रंग प्रकार की जाँच
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // SmartArt रंग प्रकार बदल रहे हैं
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // प्रस्तुति सहेजें
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**चित्र: बदल दी गई रंग शैली वाला SmartArt आकार**|

## **FAQ**

**क्या मैं SmartArt को एकल वस्तु के रूप में एनीमेट कर सकता हूँ?**  
हाँ। SmartArt एक आकार है, इसलिए आप अन्य आकारों की तरह ही एनीमेशन API (प्रवेश, निकास, जोर, मोशन पाथ) के माध्यम से [standard animations](/slides/hi/java/powerpoint-animation/) लागू कर सकते हैं।

**यदि मुझे SmartArt का आंतरिक ID नहीं पता है तो मैं स्लाइड पर किसी विशिष्ट SmartArt को कैसे खोजूँ?**  
वैकल्पिक पाठ (AltText) सेट करें और उस मान के द्वारा आकार को खोजें—यह लक्ष्य आकार को locate करने का अनुशंसित तरीका है।

**क्या मैं SmartArt को अन्य आकारों के साथ समूहित कर सकता हूँ?**  
हाँ। आप SmartArt को अन्य आकारों (चित्र, तालिका आदि) के साथ समूहित कर सकते हैं और फिर [manipulate the group](/slides/hi/java/group/) कर सकते हैं।

**मैं किसी विशिष्ट SmartArt की छवि (जैसे प्रीव्यू या रिपोर्ट के लिए) कैसे प्राप्त करूँ?**  
आकार की थंबनेल/छवि निर्यात करें; लाइब्रेरी [render individual shapes](/slides/hi/java/create-shape-thumbnails/) को रास्टर फ़ाइलों (PNG/JPG/TIFF) में रेंडर कर सकती है।

**क्या पूरी प्रस्तुति को PDF में परिवर्तित करने पर SmartArt की उपस्थिति बनी रहती है?**  
हाँ। रेंडरिंग इंजन [PDF export](/slides/hi/java/convert-powerpoint-to-pdf/) के लिए उच्च फिडेलिटी लक्ष्य करता है, जिसमें गुणवत्ता और संगतता विकल्पों की विस्तृत रेंज शामिल है।