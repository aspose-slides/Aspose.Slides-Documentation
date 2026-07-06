---
title: जावा में प्रस्तुतियों से टेक्स्ट पोर्शन सीमाएँ प्राप्त करें
linktitle: पोर्शन सीमाएँ
type: docs
weight: 47
url: /hi/java/portion-bounds/
keywords:
- टेक्स्ट पोर्शन सीमाएँ
- टेक्स्ट पोर्शन
- टेक्स्ट भाग
- टेक्स्ट कोऑर्डिनेट्स
- टेक्स्ट स्थिति
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा के लिए Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट पोर्शन सीमाएँ कैसे प्राप्त करें, सीखें।"
---
## **परिचय**

टेक्स्ट पोर्शन पैराग्राफ के भीतर के टेक्स्ट के एक विशिष्ट भाग को दर्शाता है और आपको उस भाग को आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, पोर्शन का उपयोग तब किया जाता है जब आपको टेक्स्ट फ्रैगमेंट की सीमा प्राप्त करनी हो, पैराग्राफ के केवल एक भाग पर फ़ॉर्मेटिंग लागू करनी हो, या टेक्स्ट व्यवहार को अधिक विस्तृत स्तर पर नियंत्रित करना हो।

यह लेख दिखाता है कि कैसे [IPortion.getRect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPortion#getRect--) का उपयोग करके पोर्शन का बाउंडिंग रेक्टैंगल प्राप्त किया जा सकता है। यह यह भी दिखाता है कि कैसे [IPortion.getCoordinates](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPortion#getCoordinates--) का उपयोग करके पोर्शन की शुरुआत के कोऑर्डिनेट्स प्राप्त किए जा सकते हैं। अतिरिक्त रूप से, यह सामान्य पोर्शन-संबंधी परिदृश्यों को उजागर करता है, जैसे एकल टेक्स्ट फ्रैगमेंट पर हाइपरलिंक लागू करना, यह समझना कि फ़ॉर्मेटिंग पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम और थीम इनहेरिटेंस के माध्यम से कैसे रिजॉल्व होती है, और वह स्थितियाँ जहाँ निर्दिष्ट फ़ॉन्ट उपलब्ध नहीं होता।

## **टेक्स्ट पोर्शन का बाउंडिंग रेक्टैंगल प्राप्त करें**

[IPortion.getRect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPortion#getRect--) का उपयोग करके टेक्स्ट पोर्शन का बाउंडिंग रेक्टैंगल प्राप्त करें:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट पोर्शन के कोऑर्डिनेट्स प्राप्त करें**

[IPortion.getCoordinates](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPortion#getCoordinates--) का उपयोग करके टेक्स्ट पोर्शन की शुरुआत के कोऑर्डिनेट्स प्राप्त करें:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही पैराग्राफ के भीतर केवल टेक्स्ट के हिस्से पर हाइपरलिंक लागू कर सकता हूँ?**

हां, आप एक व्यक्तिगत पोर्शन को [हाइपरलिंक असाइन करें](/slides/hi/java/manage-hyperlinks/) कर सकते हैं; केवल वही भाग क्लिक करने योग्य होगा, पूरे पैराग्राफ नहीं।

**स्टाइल इनहेरिटेंस कैसे काम करता है: पोर्शन क्या ओवरराइड करता है, और पैराग्राफ या टेक्स्ट फ्रेम से क्या लिया जाता है?**

पोर्शन-स्तर की प्रॉपर्टीज़ को सबसे अधिक प्राथमिकता मिलती है। यदि कोई प्रॉपर्टी [IPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/) पर सेट नहीं है, तो Aspose.Slides इसे [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) से लेता है। यदि वहाँ भी सेट नहीं है, तो Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) या [theme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/theme/) शैली का उपयोग करता है।

**यदि पोर्शन के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन या सर्वर पर अनुपलब्ध हो तो क्या होता है?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/java/font-selection-sequence/) लागू होते हैं। टेक्स्ट का रिफ्लो हो सकता है: मीट्रिक्स, हाइफ़नेशन, और चौड़ाई बदल सकती है, जो सटीक पोजिशनिंग के लिए महत्वपूर्ण है।

**क्या मैं पोर्शन-विशिष्ट टेक्स्ट फ़िल ट्रांसपेरेंसी या ग्रेडिएंट को पैराग्राफ के बाकी हिस्सों से स्वतंत्र रूप से सेट कर सकता हूँ?**

हां, IPortion स्तर पर टेक्स्ट रंग, फ़िल और ट्रांसपेरेंसी पड़ोसियों फ्रैगमेंट्स से अलग हो सकते हैं।