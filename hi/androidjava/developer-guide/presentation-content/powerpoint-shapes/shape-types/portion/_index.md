---
title: "एंड्रॉइड पर प्रस्तुतियों में टेक्स्ट पोर्शन प्रबंधन"
linktitle: "टेक्स्ट पोर्शन"
type: docs
weight: 70
url: /hi/androidjava/portion/
keywords:
- "टेक्स्ट पोर्शन"
- "टेक्स्ट भाग"
- "टेक्स्ट निर्देशांक"
- "टेक्स्ट स्थिति"
- "पावरपॉइंट"
- "प्रेजेंटेशन"
- "एंड्रॉइड"
- "जावा"
- "Aspose.Slides"
description: "Aspose.Slides for Android via Java का उपयोग करके पावरपॉइंट प्रस्तुतियों में टेक्स्ट पोर्शन को प्रबंधित करना सीखें, जिससे प्रदर्शन और अनुकूलन में सुधार हो।"
---
## **परिचय**

एक टेक्स्ट पोर्शन पैराग्राफ के भीतर एक विशिष्ट टेक्स्ट अंश को दर्शाता है और आपको उस अंश को आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, पोर्शन का उपयोग तब किया जा सकता है जब आपको टेक्स्ट अंश की स्थिति प्राप्त करनी हो, केवल पैराग्राफ के किसी भाग पर फ़ॉर्मेटिंग लागू करनी हो, या अधिक विस्तृत स्तर पर टेक्स्ट व्यवहार को नियंत्रित करना हो।

## **टेक्स्ट पोर्शन के निर्देशांक प्राप्त करें**
[**getCoordinates()**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPortion#getCoordinates--) विधि को [IPortion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/) और [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) क्लास में जोड़ा गया है, जो पोर्शन की शुरुआत के निर्देशांक प्राप्त करने की अनुमति देता है।

```java
// PPTX का प्रतिनिधित्व करने वाले Presentation क्लास को बनाएं
Presentation pres = new Presentation();
try {
    // प्रेजेंटेशन के संदर्भ को पुनः आकार देना
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही पैराग्राफ के भीतर टेक्स्ट के केवल एक भाग पर हाइपरलिंक लगा सकता हूँ?**

हाँ, आप एक व्यक्तिगत पोर्शन को [हाइपरलिंक असाइन](/slides/hi/androidjava/manage-hyperlinks/) कर सकते हैं; केवल वह अंश क्लिक करने योग्य होगा, पूरा पैराग्राफ नहीं।

**शैलियों की विरासत कैसे काम करती है: एक पोर्शन क्या ओवरराइड करता है, और क्या पैराग्राफ/टेक्स्टफ़्रेम से लिया जाता है?**

पोर्टशन-स्तर की विशेषताएँ सबसे उच्च प्राथमिकता रखती हैं। यदि कोई विशेषता [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) पर सेट नहीं है, तो इंजन इसे [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/paragraph/) से लेता है; यदि वहा भी सेट नहीं है, तो इसे [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) या [theme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/theme/) शैली से लिया जाता है।

**यदि कोई पोर्शन के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन/सर्वर पर अनुपलब्ध हो तो क्या होता है?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/androidjava/font-selection-sequence/) लागू होते हैं। टेक्स्ट का पुनः प्रवाह हो सकता है: मीट्रिक्स, हाइफ़नेशन, और चौड़ाई बदल सकती है, जो सटीक पोजिशनिंग के लिए महत्वपूर्ण है।

**क्या मैं पोर्शन-विशिष्ट टेक्स्ट भराव पारदर्शिता या ग्रेडिएंट को पैराग्राफ के अन्य भागों से स्वतंत्र रूप से सेट कर सकता हूँ?**

हाँ, [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) स्तर पर टेक्स्ट रंग, भराव, और पारदर्शिता पड़ोसी अंशों से भिन्न हो सकती है।