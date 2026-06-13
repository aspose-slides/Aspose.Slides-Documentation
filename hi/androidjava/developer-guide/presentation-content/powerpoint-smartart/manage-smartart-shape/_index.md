---
title: Android पर प्रस्तुतियों में SmartArt ग्राफ़िक्स का प्रबंधन
linktitle: SmartArt ग्राफ़िक्स
type: docs
weight: 20
url: /hi/androidjava/manage-smartart-shape/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके PowerPoint SmartArt निर्माण, संपादन और शैलीकरण को स्वचालित करें, संक्षिप्त Java कोड उदाहरण और प्रदर्शन-केंद्रित मार्गदर्शन के साथ।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में SmartArt ग्राफ़िक्स को प्रोग्रामेटिक रूप से बनाने और प्रबंधित करने की अनुमति देता है। यह लेख बताता है कि कैसे किसी स्लाइड में SmartArt आकार जोड़ें, मौजूदा SmartArt आकारों तक पहुँचें, विशिष्ट लेआउट प्रकार से SmartArt खोजें, और SmartArt शैली या रंग शैली बदलकर उसका दृश्य रूप अपडेट करें।

उदाहरण दिखाते हैं कि प्रस्तुति स्लाइड के आकार संग्रह के माध्यम से SmartArt आकारों के साथ कैसे काम करें, जांचें कि कोई आकार SmartArt है या नहीं, और फिर उसकी गुणों को संशोधित या निरीक्षण करें।

## **SmartArt आकार बनाना**
Aspose.Slides for Android via Java ने SmartArt आकार बनाने के लिए API प्रदान किया है। स्लाइड में SmartArt आकार बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
3. [Add a SmartArt shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) को सेट करके [LayoutType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType) निर्धारित करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```java
// प्रस्तुति क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt आकार जोड़ें
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // प्रस्तुति सहेजना
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: स्लाइड में जोड़ा गया SmartArt आकार**|

## **स्लाइड पर SmartArt आकार तक पहुंच**
निम्न कोड का उपयोग प्रस्तुति स्लाइड में जोड़े गए SmartArt आकारों तक पहुंचने के लिए किया जाएगा। नमूना कोड में हम स्लाइड के भीतर प्रत्येक आकार को पार करेंगे और जांचेंगे कि क्या वह [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt) आकार है। यदि आकार SmartArt प्रकार का है तो हम उसे [**SmartArt**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt) इंस्टेंस में प्रकार बदल देंगे।

```java
// वांछित प्रस्तुति लोड करें
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार को पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt)
        {
            // आकार को SmartArtEx में प्रकार बदलें
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट Layout Type के साथ SmartArt आकार तक पहुंच**
निम्न नमूना कोड विशेष LayoutType वाले [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt) आकार तक पहुंचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt का LayoutType नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और केवल जब [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt) आकार जोड़ा जाता है तब सेट होता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं और SmartArt आकार वाली प्रस्तुति लोड करें।
2. इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
3. पहली स्लाइड के भीतर सभी आकृतियों को पार करें।
4. जांचें कि आकृति [SmartArt] प्रकार की है और यदि है तो चयनित आकृति को SmartArt में प्रकार बदलें।
5. विशिष्ट LayoutType वाले SmartArt आकार को जांचें और बाद में आवश्यक कार्य करें।

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार को पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt)
        {
            // आकार को SmartArtEx में प्रकार बदलें
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt लेआउट की जांच
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
इस उदाहरण में हम किसी भी SmartArt आकार के लिए त्वरित शैली बदलना सीखेंगे।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं और SmartArt आकार वाली प्रस्तुति लोड करें।
2. इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
3. पहली स्लाइड के भीतर सभी आकृतियों को पार करें।
4. जांचें कि आकृति [SmartArt] प्रकार की है और यदि है तो चयनित आकृति को SmartArt में प्रकार बदलें।
5. विशिष्ट शैली वाले SmartArt आकार को खोजें।
6. SmartArt आकार के लिए नई शैली सेट करें।
7. प्रस्तुति सहेजें।

```java
// प्रस्तुति क्लास का इंस्टेंस बनाएं
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
            // आकार को SmartArtEx में प्रकार बदलें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt शैली की जाँच
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt शैली बदलें
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // प्रस्तुति सहेजना
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: बदली गई शैली वाला SmartArt आकार**|

## **SmartArt आकार रंग शैली बदलें**
इस उदाहरण में हम किसी भी SmartArt आकार के लिए रंग शैली बदलना सीखेंगे। निम्न नमूना कोड विशिष्ट रंग शैली वाले SmartArt आकार तक पहुंचेगा और उसकी शैली बदल देगा।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं और SmartArt आकार वाली प्रस्तुति लोड करें।
2. इंडेक्स का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
3. पहली स्लाइड के भीतर सभी आकृतियों को पार करें।
4. जांचें कि आकृति [SmartArt] प्रकार की है और यदि है तो चयनित आकृति को SmartArt में प्रकार बदलें।
5. विशिष्ट रंग शैली वाले SmartArt आकार को खोजें।
6. SmartArt आकार के लिए नई रंग शैली सेट करें।
7. प्रस्तुति सहेजें।

```java
// प्रस्तुति क्लास का इंस्टेंस बनाएं
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
            // आकार को SmartArtEx में प्रकार बदलें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt रंग प्रकार की जाँच
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // SmartArt रंग प्रकार बदलें
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // प्रस्तुति सहेजना
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: बदली गई रंग शैली वाला SmartArt आकार**|

## **FAQ**

**क्या मैं SmartArt को एक एकल वस्तु के रूप में एनीमेट कर सकता हूँ?**

हाँ। SmartArt एक आकार है, इसलिए आप अन्य आकारों की तरह ही एनीमेशन API के माध्यम से [standard animations](/slides/hi/androidjava/powerpoint-animation/) (प्रवेश, निकास, ज़ोर, गति पथ) लागू कर सकते हैं।

**यदि मुझे किसी स्लाइड पर उसका आंतरिक ID नहीं पता है तो मैं विशिष्ट SmartArt कैसे खोजूँ?**

वैकल्पिक पाठ (AltText) सेट करें और उस मान से आकार को खोजें—यह लक्ष्य आकार को locate करने का अनुशंसित तरीका है।

**क्या मैं SmartArt को अन्य आकारों के साथ समूहित कर सकता हूँ?**

हां। आप SmartArt को अन्य आकारों (चित्र, तालिकाएँ आदि) के साथ समूहित कर सकते हैं और फिर [manipulate the group](/slides/hi/androidjava/group/) कर सकते हैं।

**मैं किसी विशिष्ट SmartArt की छवि (जैसे प्रीव्यू या रिपोर्ट के लिए) कैसे प्राप्त करूँ?**

आकार की थंबनेल/छवि निर्यात करें; लाइब्रेरी व्यक्तिगत आकारों को raster फ़ाइलों (PNG/JPG/TIFF) में [render individual shapes](/slides/hi/androidjava/create-shape-thumbnails/) कर सकती है।

**क्या पूरी प्रस्तुति को PDF में बदलते समय SmartArt की उपस्थिति बनी रहती है?**

हां। रेंडरिंग इंजन [PDF export](/slides/hi/androidjava/convert-powerpoint-to-pdf/) के लिए उच्च फिडेलिटी लक्षित करता है, विभिन्न गुणवत्ता और संगतता विकल्पों के साथ।