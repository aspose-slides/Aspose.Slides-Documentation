---
title: जावा का उपयोग करके प्रस्तुतियों में SmartArt आकार नोड्स का प्रबंधन
linktitle: SmartArt आकार नोड
type: docs
weight: 30
url: /hi/java/manage-smartart-shape-node/
keywords:
- SmartArt नोड
- चाइल्ड नोड
- नोड जोड़ें
- नोड स्थिति
- नोड तक पहुंचें
- नोड हटाएं
- कस्टम स्थिति
- सहायक नोड
- फ़िल फ़ॉर्मेट
- नोड रेंडर करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PPT और PPTX में SmartArt आकार नोड्स को प्रबंधित करें। स्पष्ट कोड उदाहरण और टिप्स प्राप्त करें जिससे आपकी प्रस्तुतियों को सुव्यवस्थित किया जा सके।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों में SmartArt ग्राफ़िक्स को उन नोड्स के माध्यम से व्यवस्थित किया जाता है जो टेक्स्ट रखते हैं और डायग्राम की संरचना को परिभाषित करते हैं। Aspose.Slides आपको इन SmartArt नोड्स के साथ प्रोग्रामेटिक रूप से काम करने की अनुमति देता है: नए नोड और चाइल्ड नोड जोड़ना, एक विशिष्ट स्थिति में चाइल्ड नोड सम्मिलित करना, मौजूदा नोड्स तक पहुंचना, और उनका टेक्स्ट, स्तर, और स्थिति पढ़ना।

यह लेख SmartArt आकार नोड्स को प्रबंधित करने के तरीके को समझाता है। यह दिखाता है कि नोड्स को कैसे हटाया जाए, इंडेक्स या स्थिति द्वारा चाइल्ड नोड्स के साथ कैसे काम किया जाए, एक सहायक नोड को सामान्य नोड में कैसे बदला जाए, SmartArt नोड आकारों की स्थिति, आकार, और घुमाव को कैसे समायोजित किया जाए, नोड फ़िल फ़ॉर्मैट सेट किया जाए, और SmartArt चाइल्ड नोड के लिए थंबनेल छवि कैसे उत्पन्न की जाए।

## **SmartArt नोड जोड़ें**
Aspose.Slides for Java ने SmartArt आकारों को सबसे आसान तरीके से प्रबंधित करने के लिए सबसे सरल API प्रदान किया है। निम्नलिखित नमूना कोड SmartArt आकार के अंदर नोड और चाइल्ड नोड जोड़ने में मदद करेगा।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएँ और SmartArt Shape के साथ प्रस्तुति लोड करें।
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
3. पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें।
4. जाँचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि यह SmartArt है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
5. [Add a new Node](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) को SmartArt shape के [**NodeCollection**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt#getAllNodes--) में जोड़ें और TextFrame में टेक्स्ट सेट करें।
6. अब, [Add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) एक [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) को नए जोड़े गए [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) Node में जोड़ें और TextFrame में टेक्स्ट सेट करें।
7. प्रस्तुति सहेजें।

```java
// वांछित प्रस्तुति लोड करें
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof SmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            SmartArt smart = (SmartArt) shape;
    
            // नया SmartArt नोड जोड़ रहे हैं
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // टेक्स्ट जोड़ रहे हैं
            TemNode.getTextFrame().setText("Test");
    
            // पैरेंट नोड में नया चाइल्ड नोड जोड़ रहे हैं। यह संग्रह के अंत में जोड़ा जाएगा
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // टेक्स्ट जोड़ रहे हैं
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // प्रस्तुति सहेज रहे हैं
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट स्थिति पर SmartArt नोड जोड़ें**
निम्नलिखित नमूना कोड में हमने बताया है कि SmartArt आकार के संबंधित नोड्स से संबंधित चाइल्ड नोड्स को विशिष्ट स्थिति पर कैसे जोड़ा जा सकता है।

1. Presentation क्लास का एक इंस्टेंस बनाएँ।
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
3. एक्सेस की गई स्लाइड में एक [**StackedList**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType#StackedList) प्रकार का [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArt) आकार जोड़ें।
4. जोड़े गए SmartArt आकार में पहला नोड एक्सेस करें।
5. अब, चयनित [**Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtNode) के लिए स्थिति 2 पर एक [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) जोड़ें और उसका टेक्स्ट सेट करें।
6. प्रस्तुति सहेजें।

```java
// प्रस्तुति इंस्टेंस बना रहे हैं
Presentation pres = new Presentation();
try {
    // प्रस्तुति स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape जोड़ें
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // इंडेक्स 0 पर SmartArt नोड तक पहुँच रहे हैं
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // पैरेंट नोड में स्थिति 2 पर नया चाइल्ड नोड जोड़ रहे हैं
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // टेक्स्ट जोड़ें
    chNode.getTextFrame().setText("Sample Text Added");

    // प्रस्तुति सहेजें
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt नोड तक पहुँचें**
निम्नलिखित नमूना कोड SmartArt आकार के अंदर नोड्स तक पहुँचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt के LayoutType को बदल नहीं सकते क्योंकि यह केवल पढ़ने योग्य है और केवल तब सेट होता है जब SmartArt आकार जोड़ा जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएँ और SmartArt Shape के साथ प्रस्तुति लोड करें।
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
3. पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें।
4. जाँचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि यह SmartArt है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
5. SmartArt Shape के भीतर सभी [**Nodes**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArt#getAllNodes--) को पार करें।
6. SmartArt नोड की स्थिति, स्तर और टेक्स्ट जैसी जानकारी प्रदर्शित करें।

```java
// प्रस्तुति क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें
    for (IShape shape : slide.getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt के भीतर सभी नोड्स के माध्यम से पार करें
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
निम्नलिखित नमूना कोड SmartArt आकार के विभिन्न नोड्स से संबंधित चाइल्ड नोड्स तक पहुँचने में मदद करेगा।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएँ और SmartArt Shape के साथ प्रस्तुति लोड करें।
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
3. पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें।
4. जाँचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि यह SmartArt है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
5. SmartArt Shape के भीतर सभी [**Nodes**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArt#getAllNodes--) को पार करें।
6. प्रत्येक चयनित SmartArt आकार [**Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtNode) के लिए, विशेष नोड के भीतर सभी [**Child Nodes**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtNode#getChildNodes--) को पार करें।
7. [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) की स्थिति, स्तर और टेक्स्ट जैसी जानकारी प्रदर्शित करें।

```java
// प्रस्तुति क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें
    for (IShape shape : slide.getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt के भीतर सभी नोड्स के माध्यम से पार करें
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // इंडेक्स i पर SmartArt नोड तक पहुँच रहे हैं
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // इंडेक्स i पर SmartArt नोड के चाइल्ड नोड्स के माध्यम से पार कर रहे हैं
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
इस उदाहरण में, हम SmartArt आकार के विभिन्न नोड्स से संबंधित चाइल्ड नोड्स को कुछ विशिष्ट स्थितियों पर कैसे एक्सेस करें, सीखेंगे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएँ।
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
3. एक [**StackedList**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType#StackedList) प्रकार का SmartArt आकार जोड़ें।
4. जोड़े गए SmartArt आकार को एक्सेस करें।
5. एक्सेस किए गए SmartArt आकार के लिए इंडेक्स 0 पर नोड एक्सेस करें।
6. अब, एक्सेस किए गए SmartArt नोड के लिए **get_Item()** मेथड का उपयोग करके स्थिति 1 पर [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) एक्सेस करें।
7. [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) की स्थिति, स्तर और टेक्स्ट जैसी जानकारी प्रदर्शित करें।

```java
// प्रस्तुति का इंस्टांस बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँच रहे हैं
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड में SmartArt आकार जोड़ रहे हैं
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
इस उदाहरण में, हम SmartArt आकार के अंदर नोड्स को हटाना सीखेंगे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएँ और SmartArt Shape के साथ प्रस्तुति लोड करें।
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
3. पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें।
4. जाँचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि यह SmartArt है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
5. जाँचें कि SmartArt में 0 से अधिक नोड्स हैं या नहीं।
6. हटाने के लिए SmartArt नोड का चयन करें।
7. अब, चयनित नोड को [**RemoveNode**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) मेथड का उपयोग करके हटाएँ।
8. प्रस्तुति सहेजें।

```java
// Load the desired the presentation
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Traverse through every shape inside first slide
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Check if shape is of SmartArt type
        if (shape instanceof ISmartArt) 
        {
            // Typecast shape to SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accessing SmartArt node at index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Removing the selected node
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Save Presentation
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट स्थिति से SmartArt नोड हटाएँ**
इस उदाहरण में, हम विशेष स्थिति पर SmartArt आकार के अंदर नोड्स को हटाना सीखेंगे।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएँ और SmartArt Shape के साथ प्रस्तुति लोड करें।
2. इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
3. पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें।
4. जाँचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि यह SmartArt है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
5. इंडेक्स 0 पर SmartArt आकार नोड का चयन करें।
6. अब, जाँचें कि चयनित SmartArt नोड में 2 से अधिक चाइल्ड नोड्स हैं या नहीं।
7. अब, **Position 1** पर नोड को [**RemoveNode**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) मेथड का उपयोग करके हटाएँ।
8. प्रस्तुति सहेजें।

```java
// इच्छित प्रस्तुति लोड करें
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof SmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // इंडेक्स 0 पर SmartArt नोड तक पहुँच रहे हैं
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // स्थिति 1 पर चाइल्ड नोड हटाया जा रहा है
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
अब Aspose.Slides for Java [SmartArtShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtShape) के [X](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#setX-float-) और [Y](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#setY-float-) प्रॉपर्टी सेट करने का समर्थन करता है। नीचे दिया गया कोड स्निपेट दिखाता है कि कस्टम SmartArtShape स्थिति, आकार और घुमाव कैसे सेट किया जाए; कृपया ध्यान दें कि नए नोड जोड़ने से सभी नोड्स की स्थिति और आकार फिर से गणना होते हैं। साथ ही कस्टम स्थिति सेटिंग्स के साथ, उपयोगकर्ता आवश्यकता अनुसार नोड्स सेट कर सकता है।

```java
// प्रस्तुति क्लास का इंस्टेंस बनाएं
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

    // SmartArt आकार का घुमाव बदलें
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **सहायक नोड की जाँच करें**
{{% alert color="primary" %}} 

इस लेख में हम Aspose.Slides for Java का उपयोग करके प्रस्तुति स्लाइड्स में प्रोग्रामेटिक रूप से जोड़े गए SmartArt आकारों की सुविधाओं की आगे जांच करेंगे।

{{% /alert %}} 

हम इस लेख के विभिन्न अनुभागों में हमारी जाँच के लिए निम्नलिखित स्रोत SmartArt आकार का उपयोग करेंगे।

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**चित्र: स्लाइड में स्रोत SmartArt आकार**|

निम्नलिखित नमूना कोड में हम जांचेंगे कि SmartArt नोड्स संग्रह में **Assistant Nodes** की पहचान कैसे की जाए और उन्हें कैसे बदला जाए।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएँ और SmartArt Shape के साथ प्रस्तुति लोड करें।
2. इंडेक्स का उपयोग करके दूसरी स्लाइड का संदर्भ प्राप्त करें।
3. पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें।
4. जाँचें कि आकार [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि यह SmartArt है तो चयनित आकार को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) में टाइपकास्ट करें।
5. SmartArt आकार के सभी नोड्स को पार करें और जाँचें कि वे [**Assistant Nodes**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtNode#isAssistant--) हैं या नहीं।
6. Assistant Node की स्थिति को सामान्य नोड में बदलें।
7. प्रस्तुति सहेजें।

```java
// प्रस्तुति का इंस्टांस बना रहे हैं
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइपकास्ट करें
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt आकार के सभी नोड्स के माध्यम से पार कर रहे हैं
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // जाँचें कि नोड Assistant नोड है
                if (node.isAssistant()) 
                {
                    // Assistant नोड को false सेट कर रहे हैं और सामान्य नोड बना रहे हैं
                    node.isAssistant();
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
|**चित्र: स्लाइड के भीतर SmartArt आकार में सहायक नोड्स बदलें**|

## **नोड के Fill Format को सेट करें**
Aspose.Slides for Java कस्टम SmartArt आकार जोड़ने और उनके Fill Format सेट करने को संभव बनाता है। यह लेख बताता है कि Aspose.Slides for Java का उपयोग करके SmartArt आकार बनाना, एक्सेस करना और उनका Fill Format कैसे सेट किया जाए।

कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।
2. इंडेक्स का उपयोग करके एक स्लाइड का संदर्भ प्राप्त करें।
3. उसके [**LayoutType**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) को सेट करके एक [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) आकार जोड़ें।
4. SmartArt आकार नोड्स के लिए [**FillFormat**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#getFillFormat--) सेट करें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
// प्रस्तुति का इंस्टांस बनाएं
Presentation pres = new Presentation();
try {
    // स्लाइड तक पहुँच रहे हैं
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt आकार और नोड्स जोड़ रहे हैं
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // नोड का फिल रंग सेट कर रहे हैं
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // प्रस्तुति सहेजें
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt चाइल्ड नोड की थंबनेल उत्पन्न करें**
डेवलपर्स नीचे दिए गए चरणों का पालन करके SmartArt के चाइल्ड नोड की थंबनेल उत्पन्न कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का उदाहरण बनाएँ।
2. [Add SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) करें।
3. इंडेक्स का उपयोग करके एक नोड का संदर्भ प्राप्त करें।
4. थंबनेल छवि प्राप्त करें।
5. थंबनेल छवि को किसी भी इच्छित छवि फ़ॉर्मेट में सहेजें।

```java
// PPTX फाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टांस बनाएं 
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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt एनीमेशन समर्थित है?**

हां। SmartArt को एक सामान्य आकार माना जाता है, इसलिए आप [मानक एनीमेशन](/slides/hi/java/shape-animation/) (प्रवेश, निकास, ज़ोर, गति पथ) लागू कर सकते हैं और टाइमिंग को समायोजित कर सकते हैं। आवश्यकता पड़ने पर SmartArt नोड्स के भीतर के आकारों को भी एनीमेट किया जा सकता है।

**यदि किसी स्लाइड पर SmartArt का आंतरिक ID नहीं पता है तो उसे कैसे खोजा जा सकता है?**

[Alternative text](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getAlternativeText--) के द्वारा असाइन और खोज करके। SmartArt पर विशिष्ट AltText सेट करने से आप इसे प्रोग्रामेटिक रूप से बिना आंतरिक पहचानकर्ताओं पर निर्भर किए खोज सकते हैं।

**क्या प्रस्तुति को PDF में बदलते समय SmartArt का रूप बना रहता है?**

हां। Aspose.Slides [PDF एक्सपोर्ट](/slides/hi/java/convert-powerpoint-to-pdf/) के दौरान SmartArt को उच्च दृश्य सटीकता के साथ रेंडर करता है, लेआउट, रंग और प्रभाव संरक्षित रहते हैं।

**क्या मैं पूरे SmartArt की छवि (पूर्वावलोकन या रिपोर्ट के लिए) निकाल सकता हूं?**

हां। आप SmartArt आकार को [रास्टर फ़ॉर्मेट्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getImage-int-float-float-) या [SVG](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) में रेंडर कर सकते हैं, जिससे थंबनेल, रिपोर्ट या वेब उपयोग के लिए उपयुक्त स्केलेबल वेक्टर आउटपुट प्राप्त होता है।