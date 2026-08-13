---
title: Android पर प्रस्तुतियों में SmartArt Shape Nodes का प्रबंधन
linktitle: SmartArt आकार नोड
type: docs
weight: 30
url: /hi/androidjava/manage-smartart-shape-node/
keywords:
- SmartArt नोड
- चाइल्ड नोड
- नोड जोड़ें
- नोड स्थिति
- नोड तक पहुँचें
- नोड हटाएँ
- कस्टम स्थिति
- सहायक नोड
- भरण स्वरूप
- नोड रेंडर करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PPT और PPTX में SmartArt आकार नोड्स को प्रबंधित करें। अपनी प्रस्तुतियों को सुगम बनाने के लिए स्पष्ट Java कोड उदाहरण और सुझाव प्राप्त करें।"
---
## **परिचय**

PowerPoint प्रस्तुतियों में SmartArt ग्राफ़िक्स उन नोड्स द्वारा व्यवस्थित होते हैं जो पाठ रखते हैं और आरेख की संरचना निर्धारित करते हैं। Aspose.Slides आपको इन SmartArt नोड्स को प्रोग्रामेटिक तौर पर प्रबंधित करने की अनुमति देता है: नए नोड और चाइल्ड नोड जोड़ना, किसी विशिष्ट स्थान पर चाइल्ड नोड डालना, मौजूदा नोड्स तक पहुँचना, और उनका पाठ, स्तर, तथा स्थिति पढ़ना।

यह लेख SmartArt आकार नोड्स को प्रबंधित करने के तरीकों को समझाता है। इसमें नोड्स को हटाना, इंडेक्स या स्थिति के आधार पर चाइल्ड नोड्स के साथ कार्य करना, एक सहायक नोड को सामान्य नोड में बदलना, SmartArt नोड आकारों की स्थिति, आकार और घूर्णन को समायोजित करना, नोड भराव स्वरूप सेट करना, और SmartArt नोड की थंबनेल छवि उत्पन्न करना शामिल है।

## **SmartArt नोड जोड़ें**
Aspose.Slides for Android via Java ने SmartArt आकारों को सबसे आसान तरीके से प्रबंधित करने के लिए सबसे सरल API प्रदान किया है। निम्नलिखित नमूना कोड आपको SmartArt आकार के भीतर नोड और चाइल्ड नोड जोड़ने में मदद करेगा।

1. SmartArt आकार के साथ प्रस्तुति लोड करने हेतु [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें।
1. जांचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार का है और यदि ऐसा है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. SmartArt आकार के [**NodeCollection**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) में [नया नोड जोड़ें](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) और TextFrame में पाठ सेट करें।
1. अब, नव निर्मित [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) नोड में एक [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) जोड़ें और TextFrame में पाठ सेट करें।
1. प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;

// वांछित प्रस्तुति लोड करें
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जांचें कि आकार SmartArt प्रकार का है
        if (shape instanceof SmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            SmartArt smart = (SmartArt) shape;
    
            // नया SmartArt नोड जोड़ना
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // पाठ जोड़ना
            TemNode.getTextFrame().setText("Test");
    
            // पैरेंट नोड में नया चाइल्ड नोड जोड़ना। यह संग्रह के अंत में जोड़ा जाएगा
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // पाठ जोड़ना
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // प्रस्तुति सहेजना
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट स्थिति पर SmartArt नोड जोड़ें**
नीचे दिए गए नमूना कोड में हम समझाते हैं कि SmartArt आकार के संबंधित नोड्स के चाइल्ड नोड्स को निश्चित स्थिति पर कैसे जोड़ें।

1. Presentation क्लास का एक इंस्टेंस बनाएँ।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. एक्सेस की गई स्लाइड में एक [**StackedList**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) प्रकार का [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt) आकार जोड़ें।
1. जोड़े गए SmartArt आकार में पहला नोड एक्सेस करें।
1. अब, चयनित [**Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtNode) के लिए स्थिति 2 पर एक [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) जोड़ें और उसका पाठ सेट करें।
1. प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;

// प्रस्तुति का इंस्टेंस बनाना
Presentation pres = new Presentation();
try {
    // प्रस्तुति स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape जोड़ें
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // इंडेक्स 0 पर SmartArt नोड तक पहुँचना
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // पैरेंट नोड में स्थिति 2 पर नया चाइल्ड नोड जोड़ना
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // पाठ जोड़ें
    chNode.getTextFrame().setText("Sample Text Added");

    // प्रस्तुति सहेजें
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt नोड तक पहुँचें**
निम्नलिखित नमूना कोड आपको SmartArt आकार के भीतर नोड्स तक पहुँचने में मदद करेगा। कृपया ध्यान दें कि SmartArt का LayoutType आकार जोड़ते समय तय किया जाता है; बाद में **setLayout** से इसे बदलने पर पूरे आरेख का पुनर्निर्माण होता है, इसलिए आपने जो नोड स्थितियाँ और आकार सेट किए थे वे पुनः गणना किए जाते हैं।

1. SmartArt आकार के साथ प्रस्तुति लोड करने हेतु [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें।
1. जांचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार का है और यदि ऐसा है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. SmartArt आकार के भीतर सभी [**Nodes**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt#getAllNodes--) को ट्रैवर्स करें।
1. SmartArt नोड की स्थिति, स्तर और टेक्स्ट जैसी जानकारी को एक्सेस और प्रदर्शित करें।

```java
import com.aspose.slides.*;

// प्रस्तुति क्लास का उदाहरण बनाना
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें
    for (IShape shape : slide.getShapes()) 
    {
        // जांचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt के भीतर सभी नोड्स को ट्रैवर्स करें
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // इंडेक्स i पर SmartArt नोड तक पहुँच रहे हैं
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // SmartArt नोड पैरामीटर प्रिंट कर रहे हैं
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt चाइल्ड नोड तक पहुँचें**
निम्नलिखित नमूना कोड आपको SmartArt आकार के संबंधित नोड्स के चाइल्ड नोड्स तक पहुँचने में मदद करेगा।

1. SmartArt आकार के साथ प्रस्तुति लोड करने हेतु [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें।
1. जांचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार का है और यदि ऐसा है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. SmartArt आकार के भीतर सभी [**Nodes**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt#getAllNodes--) को ट्रैवर्स करें।
1. प्रत्येक चयनित SmartArt आकार [**Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtNode) के लिए, उस नोड के भीतर सभी [**Child Nodes**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) को ट्रैवर्स करें।
1. [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) की स्थिति, स्तर और टेक्स्ट जैसी जानकारी को एक्सेस और प्रदर्शित करें।

```java
import com.aspose.slides.*;

// प्रस्तुति क्लास का उदाहरण बनाना
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें
    for (IShape shape : slide.getShapes()) 
    {
        // जांचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt के भीतर सभी नोड्स को ट्रैवर्स करें
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // इंडेक्स i पर SmartArt नोड तक पहुँच रहे हैं
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // इंडेक्स i पर SmartArt नोड के चाइल्ड नोड्स को ट्रैवर्स कर रहे हैं
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArt नोड में चाइल्ड नोड तक पहुँच रहे हैं
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // SmartArt चाइल्ड नोड पैरामीटर प्रिंट कर रहे हैं
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट स्थिति पर SmartArt चाइल्ड नोड तक पहुँचें**
इस उदाहरण में, हम सीखेंगे कि SmartArt आकार के संबंधित नोड्स के चाइल्ड नोड्स को कुछ विशिष्ट स्थितियों पर कैसे एक्सेस किया जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. एक [**StackedList**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) प्रकार का SmartArt आकार जोड़ें।
1. जोड़े गए SmartArt आकार को एक्सेस करें।
1. एक्सेस किए गए SmartArt आकार के लिए इंडेक्स 0 पर नोड एक्सेस करें।
1. अब, एक्सेस किए गए SmartArt नोड के लिए स्थिति 1 पर [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) को **get_Item()** मेथड का उपयोग करके एक्सेस करें।
1. [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) की स्थिति, स्तर और टेक्स्ट जैसी जानकारी को एक्सेस और प्रदर्शित करें।

```java
import com.aspose.slides.*;

// प्रस्तुति को इंस्टैंसिएट करें
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड में SmartArt आकार जोड़ना
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // इंडेक्स 0 पर SmartArt नोड तक पहुँच रहे हैं
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // पैरेंट नोड में स्थिति 1 पर चाइल्ड नोड तक पहुँच रहे हैं
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt चाइल्ड नोड पैरामीटर प्रिंट कर रहे हैं
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt नोड हटाएँ**
इस उदाहरण में, हम सीखेंगे कि SmartArt आकार के भीतर नोड्स को कैसे हटाया जाए।

1. SmartArt आकार के साथ प्रस्तुति लोड करने हेतु [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें।
1. जांचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार का है और यदि ऐसा है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. जांचें कि [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में 0 से अधिक नोड हैं।
1. हटाने के लिए SmartArt नोड चुनें।
1. अब, चयनित नोड को [**RemoveNode**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) मेथड का उपयोग करके हटाएँ।
1. प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;

// वांछित प्रस्तुति लोड करें
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जांचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // इंडेक्स 0 पर SmartArt नोड तक पहुँच रहे हैं
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // चयनित नोड को हटा रहे हैं
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // प्रस्तुति सहेजें
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट स्थिति से SmartArt नोड हटाएँ**
इस उदाहरण में, हम सीखेंगे कि SmartArt आकार के भीतर नोड्स को विशेष स्थिति से कैसे हटाया जाए।

1. SmartArt आकार के साथ प्रस्तुति लोड करने हेतु [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें।
1. जांचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार का है और यदि ऐसा है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. इंडेक्स 0 पर SmartArt आकार नोड चुनें।
1. अब, जांचें कि चयनित SmartArt नोड में 2 से अधिक चाइल्ड नोड्स हैं।
1. अब, **Position 1** पर नोड को [**RemoveNode**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) मेथड का उपयोग करके हटाएँ।
1. प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;

// वांछित प्रस्तुति लोड करें
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जांचें कि आकार SmartArt प्रकार का है
        if (shape instanceof SmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // इंडेक्स 0 पर SmartArt नोड तक पहुँ रहे हैं
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // स्थिति 1 पर चाइल्ड नोड को हटा रहे हैं
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // प्रस्तुति सहेजें
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt ऑब्जेक्ट में चाइल्ड नोड के लिए कस्टम स्थिति सेट करें**
अब Aspose.Slides for Android via Java समर्थन प्रदान करता है [SmartArtShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtShape) की [X](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#setX-float-) और [Y](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#setY-float-) प्रॉपर्टीज़ को सेट करने का। नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे कस्टम SmartArtShape की स्थिति, आकार और घूर्णन सेट किया जाए; साथ ही यह ध्यान रखें कि नए नोड जोड़ने से सभी नोड्स की स्थितियों और आकारों की पुनः गणना होती है। कस्टम स्थिति सेटिंग्स के साथ उपयोगकर्ता आवश्यकतानुसार नोड्स सेट कर सकता है।

```java
import com.aspose.slides.*;

// प्रस्तुति क्लास का उदाहरण बनाना
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt आकार को नई स्थिति में ले जाएँ
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArt आकार की चौड़ाई बदलें
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArt आकार की ऊँचाई बदलें
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArt आकार का घूर्णन बदलें
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **सहायक नोड की जाँच करें**
{{% alert color="info" %}} 

इस लेख में हम Aspose.Slides for Android via Java का उपयोग करके प्रस्तुति स्लाइड्स में प्रोग्रामेटिक रूप से जोड़े गये SmartArt आकारों की सुविधाओं की आगे जाँच करेंगे।

{{% /alert %}} 

हम इस लेख के विभिन्न भागों में उपयोग के लिए निम्नलिखित स्रोत SmartArt आकार का उपयोग करेंगे।

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**चित्र: स्लाइड में स्रोत SmartArt आकार**|

निम्नलिखित नमूना कोड में हम जांचेंगे कि SmartArt नोड्स संग्रह में **Assistant Nodes** की पहचान कैसे की जाती है और उन्हें कैसे बदलते हैं।

1. SmartArt Shape के साथ प्रस्तुति लोड करने हेतु [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके Index का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
1. पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें।
1. जांचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार का है और यदि ऐसा है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. SmartArt आकार के सभी नोड्स को ट्रैवर्स करें और जांचें कि क्या वे [**Assistant Nodes**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) हैं।
1. Assistant Node की स्थिति को सामान्य नोड में बदलें।
1. प्रस्तुति को सहेजें।

```java
import com.aspose.slides.*;

// प्रस्तुति का इंस्टेंस बनाना
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार को ट्रैवर्स करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जांचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt आकार के सभी नोड्स को ट्रैवर्स करें
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // जांचें कि नोड सहायक नोड है
                if (node.isAssistant()) 
                {
                    // सहायक नोड को false सेट कर सामान्य नोड बनाएं
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // प्रस्तुति सहेजें
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**चित्र: स्लाइड के भीतर SmartArt आकार में सहायक नोड्स बदल दिए गए**|

## **नोड के Fill Format को सेट करें**
Aspose.Slides for Android via Java कस्टम SmartArt आकार जोड़ने और उनके Fill Format को सेट करने को संभव बनाता है। यह लेख बताता है कि कैसे SmartArt आकार बनाएँ, एक्सेस करें और Aspose.Slides for Android via Java का उपयोग करके उनके Fill Format को सेट करें।

कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके इंडेक्स का उपयोग करके किसी स्लाइड का संदर्भ प्राप्त करें।
1. उसके [**LayoutType**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) को सेट करके एक [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) आकार जोड़ें।
1. SmartArt आकार नोड्स के लिए [**FillFormat**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getFillFormat--) सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति को इंस्टैंसिएट करें
Presentation pres = new Presentation();
try {
    // स्लाइड तक पहुँच रहे हैं
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt आकार और नोड्स जोड़ रहे हैं
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // नोड भराव रंग सेट कर रहे हैं
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // प्रस्तुति को सहेजें
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt नोड की थंबनेल उत्पन्न करें**
डेवलपर्स नीचे दिए गए चरणों का पालन करके SmartArt के किसी नोड की थंबनेल उत्पन्न कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. [SmartArt जोड़ें](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)।
1. उसके Index का उपयोग करके नोड का संदर्भ प्राप्त करें।
1. थंबनेल छवि प्राप्त करें।
1. थंबनेल छवि को किसी भी वांछित इमेज फ़ॉर्मेट में सहेजें।

```java
import com.aspose.slides.*;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation();
try {
    // SmartArt जोड़ें
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // इंडेक्स का उपयोग करके नोड का संदर्भ प्राप्त करें
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // थंबनेल प्राप्त करें
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // थंबनेल सहेजें
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### क्या SmartArt एनीमेशन समर्थित है?

हाँ। SmartArt को एक सामान्य आकार माना जाता है, इसलिए आप [मानक एनीमेशन लागू कर सकते हैं](/slides/hi/androidjava/shape-animation/) (प्रवेश, निकास, ज़ोर, गति पथ) और समय-सारिणी समायोजित कर सकते हैं। आवश्यकता पड़ने पर आप SmartArt नोड्स के भीतर के आकारों को भी एनीमेट कर सकते हैं।

### यदि किसी स्लाइड में SmartArt का आंतरिक ID ज्ञात नहीं है तो उसे कैसे भरोसेमंद ढंग से खोजें?

[अल्टरनेटिव टेक्स्ट](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getAlternativeText--) द्वारा असाइन करें और खोजें। SmartArt पर विशिष्ट AltText सेट करके आप इसे प्रोग्रामेटिक रूप से आंतरिक पहचानकर्ताओं पर निर्भर हुए बिना खोज सकते हैं।

### क्या PDF में प्रस्तुति परिवर्तित करते समय SmartArt की उपस्थिति बरकरार रहेगी?

हाँ। Aspose.Slides PDF निर्यात के दौरान [PDF export](/slides/hi/androidjava/convert-powerpoint-to-pdf/) के दौरान उच्च दृश्य शुद्धता के साथ SmartArt को रेंडर करता है, लेआउट, रंग और प्रभावों को संरक्षित करता है।

### क्या मैं सम्पूर्ण SmartArt की छवि (प्रिव्यू या रिपोर्ट के लिए) निकाल सकता हूँ?

हाँ। आप SmartArt आकार को [रैस्टर फॉर्मेट्स](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) या [SVG](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) में रेंडर कर सकते हैं, जिससे थंबनेल, रिपोर्ट या वेब उपयोग के लिए स्केलेबल वेक्टर आउटपुट प्राप्त होता है।