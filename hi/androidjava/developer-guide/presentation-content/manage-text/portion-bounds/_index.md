---
title: एंड्रॉइड में प्रस्तुतियों से टेक्स्ट भाग की सीमाएँ प्राप्त करें
linktitle: भाग सीमाएँ
type: docs
weight: 47
url: /hi/androidjava/portion-bounds/
keywords:
- टेक्स्ट भाग सीमाएँ
- टेक्स्ट भाग
- टेक्स्ट हिस्सा
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करते हुए PowerPoint प्रस्तुतियों में टेक्स्ट भाग की सीमाएँ कैसे प्राप्त करें, सीखें।"
---
## **परिचय**

एक पाठ भाग पैराग्राफ के भीतर एक विशिष्ट पाठ अंश का प्रतिनिधित्व करता है और आपको उस अंश को आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, भागों का उपयोग तब किया जा सकता है जब आपको किसी पाठ अंश की सीमाएँ प्राप्त करनी हों, केवल पैराग्राफ के किसी भाग पर फ़ॉर्मेटिंग लागू करनी हो, या अधिक विस्तृत स्तर पर पाठ व्यवहार को नियंत्रित करना हो।

यह लेख दिखाता है कि कैसे [IPortion.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPortion#getRect--) का उपयोग करके भाग का बाउंडिंग आयत प्राप्त किया जाए। यह यह भी दिखाता है कि कैसे [IPortion.getCoordinates](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPortion#getCoordinates--) का उपयोग करके भाग की शुरुआत के निर्देशांक प्राप्त किए जाएँ। अतिरिक्त रूप से, यह सामान्य भाग-संबंधी परिदृश्यों को उजागर करता है, जैसे एकल पाठ अंश पर हाइपरलिंक लागू करना, समझना कि फ़ॉर्मेटिंग भाग, पैराग्राफ, टेक्स्ट फ्रेम, और थीम इनहेरिटेंस के माध्यम से कैसे हल होती है, और जब निर्दिष्ट फ़ॉन्ट उपलब्ध नहीं होता है तो उसके मामलों को संभालना।

## **पाठ भाग की सीमाएँ प्राप्त करें**

पाठ भाग का बाउंडिंग आयत प्राप्त करने के लिए [IPortion.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPortion#getRect--) का उपयोग करें:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **पाठ भाग के निर्देशांक प्राप्त करें**

पाठ भाग की शुरुआत के निर्देशांक प्राप्त करने के लिए [IPortion.getCoordinates](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPortion#getCoordinates--) का उपयोग करें:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एकल पैराग्राफ के भीतर केवल पाठ के भाग पर हाइपरलिंक लागू कर सकता हूँ?**

हाँ, आप किसी व्यक्तिगत भाग को [हाइपरलिंक असाइन करें](/slides/hi/androidjava/manage-hyperlinks/) कर सकते हैं; केवल वही अंश क्लिक करने योग्य होगा, न कि पूरा पैराग्राफ।

**स्टाइल इनहेरिटेंस कैसे काम करता है: एक भाग क्या ओवरराइड करता है और क्या पैराग्राफ या टेक्स्ट फ्रेम से लिया जाता है?**

भाग‑स्तर की प्रॉपर्टीज़ का सबसे अधिक प्राथमिकता है। यदि कोई प्रॉपर्टी [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) पर सेट नहीं है, तो Aspose.Slides इसे [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) से लेती है। यदि वहा भी सेट नहीं है, तो Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) या [theme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/theme/) शैली का उपयोग करती है।

**यदि भाग के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन या सर्वर पर अनुपलब्ध हो तो क्या होता है?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/androidjava/font-selection-sequence/) लागू होते हैं। पाठ पुनः प्रवाहित हो सकता है: मीट्रिक्स, हाइफ़नेशन, और चौड़ाई बदल सकती है, जो सटीक स्थान निर्धारण के लिए महत्वपूर्ण है।

**क्या मैं भाग‑विशिष्ट पाठ फ़िल ट्रांसपेरेन्सी या ग्रेडिएंट को पैराग्राफ के बाकी हिस्से से स्वतंत्र रूप से सेट कर सकता हूँ?**

हां, [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) स्तर पर पाठ का रंग, फ़िल और ट्रांसपेरेन्सी पड़ोसी अंशों से भिन्न हो सकते हैं।