---
title: Android पर प्रस्तुतियों में SmartArt आकृति नोड्स का प्रबंधन
linktitle: SmartArt आकृति नोड
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
- कैस्टम स्थिति
- असिस्टेंट नोड
- फ़िल फ़ॉर्मेट
- नोड रेंडर करें
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PPT और PPTX में SmartArt आकृति नोड्स का प्रबंधन करें। स्पष्ट Java कोड उदाहरण और टिप्स प्राप्त करें ताकि आप अपनी प्रस्तुतियों को सुगम बना सकें।"
---
## **समीक्षा**

PowerPoint प्रस्तुतियों में SmartArt ग्राफ़िक्स को उन नोड्स के माध्यम से व्यवस्थित किया जाता है जो टेक्स्ट रखते हैं और आरेख की संरचना को परिभाषित करते हैं। Aspose.Slides आपको इन SmartArt नोड्स के साथ प्रोग्रामेटिक रूप से काम करने की सुविधा देता है: नए नोड और चाइल्ड नोड जोड़ना, निर्दिष्ट स्थान पर चाइल्ड नोड डालना, मौजूदा नोड तक पहुँचना, और उनका टेक्स्ट, लेवल और पोज़िशन पढ़ना।

यह आलेख SmartArt आकृति नोड्स को प्रबंधित करने के तरीकों को समझाता है। यह दिखाता है कि नोड्स को कैसे हटाएँ, इंडेक्स या पोज़िशन द्वारा चाइल्ड नोड्स पर कैसे काम करें, असिस्टेंट नोड को सामान्य नोड में बदलें, SmartArt नोड आकृतियों की स्थिति, आकार और घुमाव को समायोजित करें, नोड के फ़िल फ़ॉर्मेट सेट करें, और SmartArt चाइल्ड नोड की थंबनेल छवि कैसे उत्पन्न करें।

## **SmartArt नोड जोड़ें**
Aspose.Slides for Android via Java ने SmartArt आकृति को सबसे सरल तरीके से प्रबंधित करने के लिए सबसे आसान API प्रदान किया है। निम्नलिखित नमूना कोड नोड और चाइल्ड नोड को SmartArt आकृति के अंदर जोड़ने में मदद करेगा।

1. SmartArt Shape के साथ प्रस्तुतीकरण को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसकी Index का उपयोग करके पहला स्लाइड प्राप्त करें।
1. पहले स्लाइड के हर आकृति को ट्रैवर्स करें।
1. जांचें कि आकृति [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार की है और यदि है तो चयनित आकृति को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. SmartArt आकृति के [**NodeCollection**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) में एक नया नोड [Add a new Node](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) जोड़ें और TextFrame में टेक्स्ट सेट करें।
1. अब, हाल ही में जोड़े गए [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) नोड में एक [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) जोड़ें और TextFrame में टेक्स्ट सेट करें।
1. प्रस्तुतीकरण को सहेजें।

```java
// Load the desired the presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Traverse through every shape inside first slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Check if shape is of SmartArt type
        if (shape instanceof SmartArt) 
        {
            // Typecast shape to SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Adding a new SmartArt Node
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Adding text
            TemNode.getTextFrame().setText("Test");
    
            // Adding new child node in parent node. It will be added in the end of collection
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Adding text
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Saving Presentation
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट स्थान पर SmartArt नोड जोड़ें**
निम्नलिखित नमूना कोड में हम समझाते हैं कि SmartArt आकृति के संबंधित नोड्स के चाइल्ड नोड्स को विशेष स्थान पर कैसे जोड़ा जाए।

1. Presentation क्लास का एक इंस्टेंस बनाएँ।
1. उसकी Index का उपयोग करके पहला स्लाइड प्राप्त करें।
1. एक्सेस्ड स्लाइड में एक [**StackedList**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) प्रकार का [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt) आकृति जोड़ें।
1. जोड़े गए SmartArt आकृति में पहला नोड एक्सेस करें।
1. अब, चयनित [**Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtNode) के लिए स्थिति 2 पर एक [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) जोड़ें और उसका टेक्स्ट सेट करें।
1. प्रस्तुतीकरण को सहेजें।

```java
// प्रस्तुतीकरण का एक इंस्टेंस बनाना
Presentation pres = new Presentation();
try {
    // प्रस्तुतीकरण स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape जोड़ें
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // इंडेक्स 0 पर SmartArt नोड तक पहुँच रहे हैं
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // पैरेंट नोड में स्थिति 2 पर नया चाइल्ड नोड जोड़ना
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // टेक्स्ट जोड़ें
    chNode.getTextFrame().setText("Sample Text Added");

    // प्रस्तुतीकरण सहेजें
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt नोड तक पहुँचें**
निम्नलिखित नमूना कोड SmartArt आकृति के भीतर नोड्स तक पहुँचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt का LayoutType नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और केवल SmartArt आकृति जोड़ते समय सेट किया जाता है।

1. SmartArt Shape के साथ प्रस्तुतीकरण को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसकी Index का उपयोग करके पहला स्लाइड प्राप्त करें।
1. पहले स्लाइड के हर आकृति को ट्रैवर्स करें।
1. जांचें कि आकृति [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार की है और यदि है तो चयनित आकृति को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. SmartArt Shape के भीतर सभी [**Nodes**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt#getAllNodes--) को ट्रैवर्स करें।
1. SmartArt नोड की पोज़िशन, लेवल और टेक्स्ट जैसी जानकारी प्रदर्शित करें।

```java
// Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के भीतर सभी आकृतियों को ट्रैवर्स करें
    for (IShape shape : slide.getShapes()) 
    {
        // जांचें कि आकृति SmartArt प्रकार की है
        if (shape instanceof ISmartArt) 
        {
            // आकृति को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt के भीतर सभी नोड्स को ट्रैवर्स करें
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // इंडेक्स i पर SmartArt नोड एक्सेस करना
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
निम्नलिखित नमूना कोड SmartArt आकृति के संबंधित नोड्स के चाइल्ड नोड्स तक पहुँचने में मदद करेगा।

1. SmartArt Shape के साथ प्रस्तुतीकरण को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसकी Index का उपयोग करके पहला स्लाइड प्राप्त करें।
1. पहले स्लाइड के हर आकृति को ट्रैवर्स करें।
1. जांचें कि आकृति [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार की है और यदि है तो चयनित आकृति को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. SmartArt Shape के भीतर सभी [**Nodes**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArt#getAllNodes--) को ट्रैवर्स करें।
1. प्रत्येक चयनित SmartArt आकृति के [**Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtNode) के लिए, विशेष नोड के भीतर सभी [**Child Nodes**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) को ट्रैवर्स करें।
1. [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) की पोज़िशन, लेवल और टेक्स्ट जैसी जानकारी प्रदर्शित करें।

```java
// Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के भीतर सभी आकृतियों को ट्रैवर्स करें
    for (IShape shape : slide.getShapes()) 
    {
        // जांचें कि आकृति SmartArt प्रकार की है
        if (shape instanceof ISmartArt) 
        {
            // आकृति को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt के भीतर सभी नोड्स को ट्रैवर्स करें
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // इंडेक्स i पर SmartArt नोड एक्सेस करना
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // इंडेक्स i पर SmartArt नोड के चाइल्ड नोड्स को ट्रैवर्स करना
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArt नोड में चाइल्ड नोड एक्सेस करना
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
इस उदाहरण में, हम सीखेंगे कि SmartArt आकृति के संबंधित नोड्स के चाइल्ड नोड्स को कुछ विशेष स्थितियों पर कैसे एक्सेस किया जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसकी Index का उपयोग करके पहला स्लाइड प्राप्त करें।
1. एक [**StackedList**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) प्रकार का SmartArt आकृति जोड़ें।
1. जोड़ी गई SmartArt आकृति को एक्सेस करें।
1. एक्सेस्ड SmartArt आकृति के लिए इंडेक्स 0 पर नोड एक्सेस करें।
1. अब, एक्सेस्ड SmartArt नोड के लिए **get_Item()** मेथड का उपयोग करके स्थिति 1 पर [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) एक्सेस करें।
1. [**Child Node**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) की पोज़िशन, लेवल और टेक्स्ट जैसी जानकारी प्रदर्शित करें।

```java
// प्रस्तुतीकरण का इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड एक्सेस करना
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड में SmartArt आकृति जोड़ना
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // इंडेक्स 0 पर SmartArt नोड एक्सेस करना
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // पैरेंट नोड में स्थिति 1 पर चाइल्ड नोड एक्सेस करना
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt चाइल्ड नोड पैरामीटर प्रिंट करना
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt नोड हटाएँ**
इस उदाहरण में, हम सीखेंगे कि SmartArt आकृति के भीतर नोड्स को कैसे हटाएँ।

1. SmartArt Shape के साथ प्रस्तुतीकरण को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसकी Index का उपयोग करके पहला स्लाइड प्राप्त करें।
1. पहले स्लाइड के हर आकृति को ट्रैवर्स करें।
1. जांचें कि आकृति [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार की है और यदि है तो चयनित आकृति को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. जांचें कि [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में 0 से अधिक नोड हैं।
1. हटाने के लिए SmartArt नोड चुनें।
1. अब, चुने गए नोड को [**RemoveNode**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) मेथड का उपयोग करके हटाएँ।
1. प्रस्तुतीकरण को सहेजें।

```java
// इच्छित प्रस्तुतीकरण लोड करें
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // पहली स्लाइड के भीतर सभी आकृतियों को ट्रैवर्स करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जांचें कि आकृति SmartArt प्रकार की है
        if (shape instanceof ISmartArt) 
        {
            // आकृति को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // इंडेक्स 0 पर SmartArt नोड एक्सेस करना
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // चयनित नोड हटाना
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // प्रस्तुतीकरण सहेजें
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट स्थिति से SmartArt नोड हटाएँ**
इस उदाहरण में, हम सीखेंगे कि SmartArt आकृति के भीतर नोड्स को विशेष स्थिति से कैसे हटाया जाए।

1. SmartArt Shape के साथ प्रस्तुतीकरण को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसकी Index का उपयोग करके पहला स्लाइड प्राप्त करें।
1. पहले स्लाइड के हर आकृति को ट्रैवर्स करें।
1. जांचें कि आकृति [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार की है और यदि है तो चयनित आकृति को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. इंडेक्स 0 पर SmartArt आकृति नोड चुनें।
1. अब, जांचें कि चयनित SmartArt नोड में 2 से अधिक चाइल्ड नोड हैं।
1. अब, **Position 1** पर नोड को [**RemoveNode**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) मेथड का उपयोग करके हटाएँ।
1. प्रस्तुतीकरण को सहेजें।

```java
// इच्छित प्रस्तुतीकरण लोड करें
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // पहली स्लाइड के भीतर सभी आकृतियों को ट्रैवर्स करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जांचें कि आकृति SmartArt प्रकार की है
        if (shape instanceof SmartArt) 
        {
            // आकृति को SmartArt में टाइपकास्ट करें
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // इंडेक्स 0 पर SmartArt नोड एक्सेस करना
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // स्थिति 1 पर चाइल्ड नोड हटाना
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // प्रस्तुतीकरण सहेजें
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt ऑब्जेक्ट में चाइल्ड नोड के लिए कस्टम पोज़िशन सेट करें**
अब Aspose.Slides for Android via Java [SmartArtShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtShape) की [X](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#setX-float-) और [Y](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#setY-float-) प्रॉपर्टीज़ को सेट करने का समर्थन करता है। नीचे दिया गया कोड स्निपेट दिखाता है कि कस्टम SmartArtShape पोज़िशन, आकार और घुमाव कैसे सेट करें। कृपया ध्यान दें कि नए नोड जोड़ने से सभी नोड्स की पोज़िशन और आकार का पुनर्गणना होती है। कस्टम पोज़िशन सेटिंग्स के साथ, उपयोगकर्ता आवश्यकतानुसार नोड्स सेट कर सकता है।

```java
// Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt आकृति को नई स्थिति में ले जाएँ
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArt आकृति की चौड़ाइयों को बदलें
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArt आकृति की ऊँचाई बदलें
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArt आकृति का घूर्णन बदलें
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **असिस्टेंट नोड की जाँच करें**
{{% alert color="primary" %}} 

इस लेख में हम Aspose.Slides for Android via Java का उपयोग करके प्रस्तुति स्लाइड्स में प्रोग्रामेटिक रूप से जोड़े गए SmartArt आकृति की सुविधाओं की आगे जाँच करेंगे।

{{% /alert %}} 

हम इस लेख के विभिन्न खंडों में जांच के लिए निम्नलिखित स्रोत SmartArt आकृति का उपयोग करेंगे।

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**चित्र: स्लाइड में स्रोत SmartArt आकृति**|

निम्नलिखित नमूना कोड में हम यह जांचेंगे कि **Assistant Nodes** को SmartArt नोड्स संग्रह में कैसे पहचाना जाए और उन्हें कैसे बदला जाए।

1. SmartArt Shape के साथ प्रस्तुतीकरण को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसकी Index का उपयोग करके दूसरा स्लाइड प्राप्त करें।
1. पहले स्लाइड के हर आकृति को ट्रैवर्स करें।
1. जांचें कि आकृति [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) प्रकार की है और यदि है तो चयनित आकृति को [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
1. SmartArt आकृति के सभी नोड्स को ट्रैवर्स करें और जांचें कि क्या वे [**Assistant Nodes**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) हैं।
1. Assistant Node की स्थिति को सामान्य नोड में बदलें।
1. प्रस्तुतीकरण को सहेजें।

```java
// प्रस्तुतीकरण इंस्टेंस बनाना
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // पहली स्लाइड के भीतर सभी आकृतियों को ट्रैवर्स करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जांचें कि आकृति SmartArt प्रकार की है
        if (shape instanceof ISmartArt) 
        {
            // आकृति को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt आकृति के सभी नोड्स को ट्रैवर्स करें
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // जांचें कि नोड Assistant नोड है
                if (node.isAssistant()) 
                {
                    // Assistant नोड को false सेट करें और इसे सामान्य नोड बनाएं
                    node.isAssistant();
                }
            }
        }
    }
    
    // प्रस्तुतीकरण सहेजें
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**चित्र: स्लाइड के भीतर SmartArt आकृति में बदले गए Assistant Nodes**|

## **नोड के फ़िल फ़ॉर्मेट को सेट करें**
Aspose.Slides for Android via Java कस्टम SmartArt आकृतियों को जोड़ना और उनके फ़िल फ़ॉर्मेट को सेट करना संभव बनाता है। यह लेख बताता है कि कैसे SmartArt आकृतियों को बनाया और एक्सेस किया जाए तथा Aspose.Slides for Android via Java का उपयोग करके उनके फ़िल फ़ॉर्मेट को सेट किया जाए।

कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. इंडेक्स का उपयोग करके किसी स्लाइड का रेफ़रेंस प्राप्त करें।
1. उसकी [**LayoutType**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) सेट करके एक [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArt) आकृति जोड़ें।
1. SmartArt आकृति नोड्स के लिए [**FillFormat**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getFillFormat--) सेट करें।
1. संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में लिखें।

```java
// प्रस्तुतीकरण का इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // स्लाइड तक पहुँच रहे हैं
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt आकृति और नोड्स जोड़ रहे हैं
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // नोड के फ़िल रंग सेट कर रहे हैं
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // प्रस्तुतीकरण सहेजें
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt चाइल्ड नोड की थंबनेल उत्पन्न करें**
डेवलपर्स नीचे दिए गए चरणों का पालन करके SmartArt के चाइल्ड नोड की थंबनेल उत्पन्न कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
1. [Add SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) जोड़ें।
1. उसकी Index का उपयोग करके नोड का रेफ़रेंस प्राप्त करें।
1. थंबनेल इमेज प्राप्त करें।
1. थंबनेल इमेज को किसी भी इच्छित इमेज फ़ॉर्मेट में सहेजें।

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं 
Presentation pres = new Presentation();
try {
    // SmartArt जोड़ें 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // उसके Index का उपयोग करके नोड का रेफ़रेंस प्राप्त करें  
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

**क्या SmartArt एनीमेशन समर्थित है?**

हां। SmartArt को नियमित आकृति की तरह माना जाता है, इसलिए आप [मानक एनीमेशन्स](/slides/hi/androidjava/shape-animation/) (प्रवेश, निकास, ज़ोर, मोशन पाथ) लागू कर सकते हैं और समय समायोजित कर सकते हैं। आवश्यकता पड़ने पर आप SmartArt नोड्स के अंदर की आकृतियों को भी एनीमेट कर सकते हैं।

**यदि किसी स्लाइड में SmartArt का आंतरिक ID अज्ञात हो तो उसे विश्वसनीय रूप से कैसे खोजें?**

[वैकल्पिक पाठ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getAlternativeText--) द्वारा असाइन और खोज करें। SmartArt पर विशिष्ट AltText सेट करने से आप कोड के माध्यम से इसे आसानी से खोज सकते हैं, बिना आंतरिक पहचानकर्ता पर निर्भर हुए।

**क्या प्रस्तुति को PDF में बदलते समय SmartArt का रूप बना रहेगा?**

हां। Aspose.Slides [PDF निर्यात](/slides/hi/androidjava/convert-powerpoint-to-pdf/) के दौरान उच्च दृश्य सटीकता के साथ SmartArt को रेंडर करता है, जिससे लेआउट, रंग और प्रभाव संरक्षित रहते हैं।

**क्या मैं पूरे SmartArt की छवि (पूर्वावलोकन या रिपोर्ट के लिए) निकाल सकता हूँ?**

हां। आप SmartArt आकृति को [रेस्टर फ़ॉर्मेट्स](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) या [SVG](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) में रेंडर कर सकते हैं, जिससे थंबनेल, रिपोर्ट या वेब उपयोग के लिए उपयुक्त स्केलेबल वेक्टर आउटपुट प्राप्त होता है।