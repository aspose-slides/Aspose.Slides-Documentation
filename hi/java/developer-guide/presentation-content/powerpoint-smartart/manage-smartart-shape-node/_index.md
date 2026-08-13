---
title: Java का उपयोग करके प्रस्तुतियों में SmartArt आकार नोड्स का प्रबंधन
linktitle: SmartArt आकार नोड
type: docs
weight: 30
url: /hi/java/manage-smartart-shape-node/
keywords:
- SmartArt नोड
- चाइल्ड नोड
- नोड जोड़ें
- नोड स्थिति
- नोड एक्सेस
- नोड हटाएँ
- कस्टम स्थिति
- असिस्टेंट नोड
- फ़िल फ़ॉर्मेट
- रेंडर नोड
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PPT और PPTX में SmartArt आकार नोड्स का प्रबंधन। स्पष्ट कोड नमूने और टिप्स प्राप्त करके अपनी प्रस्तुतियों को सुगम बनाएँ।"
---
## **परिचय**

PowerPoint प्रस्तुतियों में SmartArt ग्राफिक्स को उन नोड्स के माध्यम से व्यवस्थित किया जाता है जो टेक्स्ट रखते हैं और आरेख की संरचना को परिभाषित करते हैं। Aspose.Slides आपको इन SmartArt नोड्स के साथ प्रोग्रामेटिक रूप से काम करने की सुविधा देता है: नए नोड और चाइल्ड नोड जोड़ना, किसी विशिष्ट स्थान पर चाइल्ड नोड डालना, मौजूदा नोड्स तक पहुंचना, और उनके टेक्स्ट, लेवल तथा पोजिशन पढ़ना।

यह लेख SmartArt शAPE नोड्स को प्रबंधित करने के तरीकों को समझाता है। इसमें नोड्स को हटाना, इंडेक्स या पोजिशन द्वारा चाइल्ड नोड्स के साथ काम करना, एक असिस्टेंट नोड को सामान्य नोड में बदलना, SmartArt नोड शAPE की पोजिशन, आकार और रोटेशन को समायोजित करना, नोड फ़िल फ़ॉर्मेट सेट करना, और SmartArt चाइल्ड नोड की थंबनेल इमेज जनरेट करना शामिल है।

## **SmartArt नोड जोड़ें**
Aspose.Slides for Java ने SmartArt शAPE को सबसे आसान तरीके से प्रबंधित करने के लिए सबसे सरल API प्रदान किया है। नीचे दिया गया नमूना कोड SmartArt शAPE के अंदर नोड और चाइल्ड नोड जोड़ने में मदद करेगा।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं और SmartArt शAPE के साथ प्रस्तुति लोड करें।
2. उसके Index का उपयोग करके प्रथम स्लाइड का रेफ़रेंस प्राप्त करें।
3. प्रथम स्लाइड के अंदर प्रत्येक शAPE को पार करें।
4. जाँचें कि शAPE [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि हाँ तो चयनित शAPE को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) में टाइप‑कास्ट करें।
5. SmartArt शAPE के [**NodeCollection**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt#getAllNodes--) में एक नया नोड [Add a new Node](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) जोड़ें और TextFrame में टेक्स्ट सेट करें।
6. अब, नवीनतम जोड़े गये [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) नोड में एक [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) [Add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) करें और TextFrame में टेक्स्ट सेट करें।
7. प्रस्तुति को Save करें।

```java
import com.aspose.slides.*;

// इच्छित प्रस्तुति लोड करें
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // प्रथम स्लाइड के अंदर प्रत्येक आकार को पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof SmartArt) 
        {
            // आकार को SmartArt में टाइप‑कास्ट करें
            SmartArt smart = (SmartArt) shape;
    
            // नया SmartArt नोड जोड़ना
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // टेक्स्ट जोड़ना
            TemNode.getTextFrame().setText("Test");
    
            // पैरेंट नोड में नया चाइल्ड नोड जोड़ना। यह संग्रह के अंत में जोड़ा जायेगा
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // टेक्स्ट जोड़ना
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // प्रस्तुति सहेजना
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **विशिष्ट पोजिशन पर SmartArt नोड जोड़ें**
निम्न नमूना कोड में हम समझाते हैं कि SmartArt शAPE के संबंधित नोड्स में चाइल्ड नोड्स को विशेष पोजिशन पर कैसे जोड़ा जाए।

1. Presentation क्लास का एक इंस्टेंस बनाएं।
2. उसके Index का उपयोग करके प्रथम स्लाइड का रेफ़रेंस प्राप्त करें।
3. अभिगमित स्लाइड में एक [**StackedList**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType#StackedList) प्रकार का [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArt) शAPE जोड़ें।
4. जोड़े गये SmartArt शAPE में पहला नोड एक्सेस करें।
5. चयनित [**Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtNode) के लिए पोजिशन 2 पर एक [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) जोड़ें और उसका टेक्स्ट सेट करें।
6. प्रस्तुति को Save करें।

```java
import com.aspose.slides.*;

// एक प्रस्तुति इंस्टेंस बनाना
Presentation pres = new Presentation();
try {
    // प्रस्तुति स्लाइड तक पहुंचें
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape जोड़ें
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // इंडेक्स 0 पर SmartArt नोड तक पहुंचना
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // पैरेंट नोड में स्थान 2 पर नया चाइल्ड नोड जोड़ना
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // टेक्स्ट जोड़ें
    chNode.getTextFrame().setText("Sample Text Added");

    // प्रस्तुति सहेजें
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt नोड एक्सेस करें**
निम्न नमूना कोड SmartArt शAPE के अंदर नोड्स को एक्सेस करने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt के LayoutType को नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और केवल शAPE जोड़ने के समय सेट होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का इंस्टेंस बनाएं और SmartArt शAPE के साथ प्रस्तुति लोड करें।
2. उसके Index का उपयोग करके प्रथम स्लाइड का रेफ़रेंस प्राप्त करें।
3. प्रथम स्लाइड के अंदर प्रत्येक शAPE को पार करें।
4. जाँचें कि शAPE [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि हाँ तो चयनित शAPE को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) में टाइप‑कास्ट करें।
5. SmartArt शAPE के अंदर सभी [**Nodes**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArt#getAllNodes--) को पार करें।
6. SmartArt नोड की पोजिशन, लेवल और टेक्स्ट जैसी जानकारी को एक्सेस और प्रदर्शित करें।

```java
import com.aspose.slides.*;

// Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के अंदर प्रत्येक आकार को पार करें
    for (IShape shape : slide.getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइप‑कास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt के अंदर सभी नोड्स को पार करें
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // इंडेक्स i पर SmartArt नोड तक पहुंचना
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // SmartArt नोड पैरामीटर प्रिंट करना
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt चाइल्ड नोड एक्सेस करें**
निम्न नमूना कोड SmartArt शAPE के संबंधित नोड्स के चाइल्ड नोड्स को एक्सेस करने में मदद करेगा।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का इंस्टेंस बनाएं और SmartArt शAPE के साथ प्रस्तुति लोड करें।
2. उसके Index का उपयोग करके प्रथम स्लाइड का रेफ़रेंस प्राप्त करें।
3. प्रथम स्लाइड के अंदर प्रत्येक शAPE को पार करें।
4. जाँचें कि शAPE [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि हाँ तो चयनित शAPE को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) में टाइप‑कास्ट करें।
5. SmartArt शAPE के अंदर सभी [**Nodes**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArt#getAllNodes--) को पार करें।
6. प्रत्येक चयनित SmartArt शAPE [**Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtNode) के लिए, विशेष नोड के अंदर सभी [**Child Nodes**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtNode#getChildNodes--) को पार करें।
7. [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) की पोजिशन, लेवल और टेक्स्ट जैसी जानकारी को एक्सेस और प्रदर्शित करें।

```java
import com.aspose.slides.*;

// Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड के अंदर प्रत्येक आकार को पार करें
    for (IShape shape : slide.getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइप‑कास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt के अंदर सभी नोड्स को पार करें
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // इंडेक्स i पर SmartArt नोड तक पहुंचना
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // इंडेक्स i पर SmartArt नोड में चाइल्ड नोड्स को पार करना
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArt नोड में चाइल्ड नोड तक पहुंचना
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // SmartArt चाइल्ड नोड पैरामीटर प्रिंट करना
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **निश्चित पोजिशन पर SmartArt चाइल्ड नोड एक्सेस करें**
इस उदाहरण में हम सीखेंगे कि कैसे विशेष पोजिशन पर SmartArt शAPE के संबंधित नोड्स के चाइल्ड नोड्स को एक्सेस किया जाए।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
2. उसके Index का उपयोग करके प्रथम स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक [**StackedList**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType#StackedList) प्रकार का SmartArt शAPE जोड़ें।
4. जोड़े गये SmartArt शAPE को एक्सेस करें।
5. अभिगमित SmartArt शAPE के लिए Index 0 पर नोड एक्सेस करें।
6. अब, **get_Item()** मेथड का उपयोग करके अभिगमित SmartArt नोड के लिए पोजिशन 1 पर [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getChildNodes--) एक्सेस करें।
7. [**Child Node**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArtNode#getChildNodes--) की पोजिशन, लेवल और टेक्स्ट जैसी जानकारी को एक्सेस और प्रदर्शित करें।

```java
import com.aspose.slides.*;

// प्रस्तुति का इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुंचना
    ISlide slide = pres.getSlides().get_Item(0);
    
    // पहली स्लाइड में SmartArt आकार जोड़ना
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // इंडेक्स 0 पर SmartArt नोड तक पहुंचना
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // पैरेंट नोड में स्थिति 1 पर चाइल्ड नोड तक पहुंचना
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt चाइल्ड नोड पैरामीटर प्रिंट करना
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt नोड हटाएँ**
इस उदाहरण में हम सीखेंगे कि SmartArt शAPE के अंदर नोड्स को कैसे हटाया जाए।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का इंस्टेंस बनाएं और SmartArt शAPE के साथ प्रस्तुति लोड करें।
2. उसके Index का उपयोग करके प्रथम स्लाइड का रेफ़रेंस प्राप्त करें।
3. प्रथम स्लाइड के अंदर प्रत्येक शAPE को पार करें।
4. जाँचें कि शAPE [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArt) प्रकार का है और यदि हाँ तो चयनित शAPE को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArt) में टाइप‑कास्ट करें।
5. जाँचें कि [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArt) में 0 से अधिक नोड्स हैं।
6. हटाने हेतु SmartArt नोड चुनें।
7. अब, चयनित नोड को [**RemoveNode**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) मेथड से हटाएँ।
8. प्रस्तुति को Save करें।

```java
import com.aspose.slides.*;

// इच्छित प्रस्तुति लोड करें
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // प्रथम स्लाइड के अंदर प्रत्येक आकार को पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइप‑कास्ट करें
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // इंडेक्स 0 पर SmartArt नोड तक पहुंचना
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // चयनित नोड को हटाना
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

## **विशिष्ट पोजिशन से SmartArt नोड हटाएँ**
इस उदाहरण में हम सीखेंगे कि विशेष पोजिशन पर SmartArt शAPE के नोड्स को कैसे हटाया जाए।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का इंस्टेंस बनाएं और SmartArt शAPE के साथ प्रस्तुति लोड करें।
2. उसके Index का उपयोग करके प्रथम स्लाइड का रेफ़रेंस प्राप्त करें।
3. प्रथम स्लाइड के अंदर प्रत्येक शAPE को पार करें।
4. जाँचें कि शAPE [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArt) प्रकार का है और यदि हाँ तो चयनित शAPE को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArt) में टाइप‑कास्ट करें।
5. Index 0 पर SmartArt शAPE नोड चुनें।
6. अब, जाँचें कि चयनित SmartArt नोड में 2 से अधिक चाइल्ड नोड्स हैं।
7. अब, **Position 1** पर नोड को [**RemoveNode**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArtNodeCollection#removeNode-int-) मेथड से हटाएँ।
8. प्रस्तुति को Save करें।

```java
import com.aspose.slides.*;

// इच्छित प्रस्तुति लोड करें
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // प्रथम स्लाइड के अंदर प्रत्येक आकार को पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof SmartArt) 
        {
            // आकार को SmartArt में टाइप‑कास्ट करें
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // इंडेक्स 0 पर SmartArt नोड तक पहुंचना
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // स्थिति 1 पर चाइल्ड नोड को हटाना
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

## **SmartArt ऑब्जेक्ट में चाइल्ड नोड के लिए कस्टम पोजिशन सेट करें**
अब Aspose.Slides for Java [SmartArtShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtShape) के [X](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#setX-float-) और [Y](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#setY-float-) प्रॉपर्टीज़ को सेट करने का समर्थन करता है। नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे कस्टम SmartArtShape पोजिशन, साइज और रोटेशन सेट किया जाए; कृपया ध्यान दें कि नए नोड जोड़ने से सभी नोड्स की पोजिशन और साइज पुनः गणना हो जाती है। कस्टम पोजिशन सेटिंग्स के साथ उपयोगकर्ता आवश्यकतानुसार नोड्स सेट कर सकता है।

```java
import com.aspose.slides.*;

// Presentation क्लास का इंस्टेंस बनाएं
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

## **असिस्टेंट नोड जांचें**
{{% alert color="info" %}} 

इस लेख में हम प्रोग्रामेटिक रूप से Aspose.Slides for Java का उपयोग करके प्रस्तुति स्लाइड्स में जोड़ें गए SmartArt शAPE की विशेषताओं की आगे पड़ताल करेंगे।

{{% /alert %}} 

हम इस लेख के विभिन्न भागों में अपने जांच के लिए नीचे दिए गये स्रोत SmartArt शAPE का उपयोग करेंगे।

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**चित्र: स्लाइड में स्रोत SmartArt शAPE**|

निम्न नमूना कोड में हम जांचेंगे कि कैसे SmartArt नोड कलेक्शन में **Assistant Nodes** की पहचान की जाए और उन्हें बदलें।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का इंस्टेंस बनाएं और SmartArt शAPE के साथ प्रस्तुति लोड करें।
2. उसके Index का उपयोग करके दूसरे स्लाइड का रेफ़रेंस प्राप्त करें।
3. प्रथम स्लाइड के अंदर प्रत्येक शAPE को पार करें।
4. जाँचें कि शAPE [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArt) प्रकार का है और यदि हाँ तो चयनित शAPE को [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArt) में टाइप‑कास्ट करें।
5. SmartArt शAPE के सभी नोड्स को पार करें और जाँचें कि क्या वे [**Assistant Nodes**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtNode#isAssistant--) हैं।
6. Assistant Node की स्थिति को सामान्य नोड में बदलें।
7. प्रस्तुति को Save करें।

```java
import com.aspose.slides.*;

// प्रस्तुति इंस्टेंस बनाना
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // प्रथम स्लाइड के अंदर प्रत्येक आकार को पार करें
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // जाँचें कि आकार SmartArt प्रकार का है
        if (shape instanceof ISmartArt) 
        {
            // आकार को SmartArt में टाइप‑कास्ट करें
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt आकार के सभी नोड्स को पार करना
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // जाँचें कि नोड Assistant नोड है
                if (node.isAssistant()) 
                {
                    // Assistant नोड को false सेट करना और उसे सामान्य नोड बनाना
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
|**चित्र: स्लाइड के अंदर SmartArt शAPE में बदल गए Assistant Nodes**|

## **नोड के Fill फ़ॉर्मेट को सेट करें**
Aspose.Slides for Java कस्टम SmartArt शAPE जोड़ने और उनके Fill फ़ॉर्मेट को सेट करने को संभव बनाता है। यह लेख बताता है कि कैसे SmartArt शAPE बनाकर उनके Fill फ़ॉर्मेट को Aspose.Slides for Java का उपयोग करके सेट किया जाए।

कृपया नीचे दिए गये चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके Index का उपयोग करके किसी स्लाइड का रेफ़रेंस प्राप्त करें।
3. उसके [**LayoutType**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) को सेट करके एक [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArt) शAPE जोड़ें।
4. SmartArt शAPE नोड्स के लिए [**FillFormat**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#getFillFormat--) सेट करें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
import com.aspose.slides.*;
import java.awt.Color;

// प्रस्तुति का इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // स्लाइड तक पहुंचना
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt आकार और नोड्स जोड़ना
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // नोड का फ़िल रंग सेट करना
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

## **SmartArt चाइल्ड नोड की थंबनेल जनरेट करें**
डेवलपर्स नीचे दिए गये चरणों का पालन करके SmartArt के चाइल्ड नोड की थंबनेल इमेज जनरेट कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
2. [Add SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISSmartArtNodeCollection#addNode--)।
3. उसके Index का उपयोग करके किसी नोड का रेफ़रेंस प्राप्त करें।
4. थंबनेल इमेज प्राप्त करें।
5. थंबनेल इमेज को इच्छित किसी भी इमेज फ़ॉर्मेट में Save करें।

```java
import com.aspose.slides.*;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें 
Presentation pres = new Presentation();
try {
    // SmartArt जोड़ें
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // इंडेक्स का उपयोग करके नोड का रेफ़रेंस प्राप्त करें  
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

### क्या SmartArt एनिमेशन समर्थित है?

हाँ। SmartArt को एक सामान्य शAPE माना जाता है, इसलिए आप [मानक एनिमेशन](/slides/hi/java/shape-animation/) (प्रवेश, निकास, ज़ोर, मोशन पाथ) लागू कर सकते हैं और टाइमिंग को समायोजित कर सकते हैं। आवश्यकता पड़ने पर आप SmartArt नोड्स के भीतर शAPE को भी एनिमेट कर सकते हैं।

### यदि किसी स्लाइड पर SmartArt का आंतरिक ID अज्ञात हो तो उसे कैसे भरोसेमंद रूप से locate करें?

[alternative text](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getAlternativeText--) द्वारा असाइन और सर्च करें। SmartArt पर एक विशिष्ट AltText सेट करने से आप उसे प्रोग्रामेटिक रूप से आंतरिक पहचानकर्ताओं पर निर्भर हुए बिना खोज सकते हैं।

### क्या प्रस्तुति को PDF में बदलते समय SmartArt की उपस्थिति बनी रहती है?

हाँ। Aspose.Slides [PDF export](/slides/hi/java/convert-powerpoint-to-pdf/) के दौरान SmartArt को उच्च दृश्य सटीकता के साथ रेंडर करता है, लेआउट, रंग और इफ़ेक्ट्स को संरक्षित रखते हुए।

### क्या मैं पूरे SmartArt की इमेज (प्रिव्यू या रिपोर्ट के लिए) निकाल सकता हूँ?

हाँ। आप SmartArt शAPE को [raster formats](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getImage-int-float-float-) या [SVG](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) में रेंडर कर सकते हैं, जिससे थंबनेल, रिपोर्ट या वेब उपयोग के लिए उच्च गुणवत्ता वाले स्केलेबल आउटपुट मिलते हैं।