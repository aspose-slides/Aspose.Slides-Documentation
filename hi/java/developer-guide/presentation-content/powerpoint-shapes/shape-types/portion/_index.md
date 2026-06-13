---
title: जावा का उपयोग करके प्रस्तुतियों में टेक्स्ट पोर्शन प्रबंधित करें
linktitle: टेक्स्ट पोर्शन
type: docs
weight: 70
url: /hi/java/portion/
keywords:
- टेक्स्ट पोर्शन
- टेक्स्ट भाग
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट पोर्शन प्रबंधित करना सीखें, जिससे प्रदर्शन और अनुकूलन में सुधार हो।"
---
## **अवलोकन**

एक टेक्स्ट पार्टिशन पैराग्राफ के भीतर एक विशिष्ट टेक्स्ट खंड को दर्शाता है और आपको उस खंड पर आसपास की सामग्री से स्वतंत्र रूप से कार्य करने की अनुमति देता है। Aspose.Slides में, पार्टिशन का उपयोग तब किया जाता है जब आपको टेक्स्ट खंड की स्थिति प्राप्त करनी हो, पैराग्राफ के केवल एक भाग पर फॉर्मेटिंग लागू करनी हो, या अधिक विस्तृत स्तर पर टेक्स्ट व्यवहार को नियंत्रित करना हो।

यह लेख `getCoordinates()` मेथड का उपयोग करके पार्टिशन की शुरुआत के निर्देशांक प्राप्त करने का तरीका दर्शाता है। यह हाइपरलिंक को एकल टेक्स्ट खंड पर लागू करने, फॉर्मेटिंग के पार्टिशन, पैराग्राफ, टेक्स्ट फ़्रेम और थीम विरासत के माध्यम से समाधान को समझने, तथा निर्दिष्ट फ़ॉन्ट अनुपलब्ध होने की स्थिति को संभालने जैसे सामान्य पार्टिशन-संबंधी परिदृश्यों को भी उजागर करता है। इसके अतिरिक्त, यह नोट करता है कि समान पैराग्राफ के भीतर व्यक्तिगत पार्टिशन के लिए टेक्स्ट फ़िल, रंग और पारदर्शिता अलग‑अलग सेट की जा सकती है।

## **पाठ भाग के निर्देशांक प्राप्त करें**
[**getCoordinates()**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPortion#getCoordinates--) मेथड को [IPortion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/) और [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) क्लास में जोड़ा गया है, जो भाग की शुरुआत के निर्देशांक प्राप्त करने की अनुमति देता है।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation();
try {
    // प्रेज़ेंटेशन के कॉन्टेक्स्ट को पुनः आकारित करें
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

**क्या मैं केवल एक पैराग्राफ के भीतर टेक्स्ट के किसी हिस्से पर ही हाइपरलिंक लागू कर सकता हूँ?**

हाँ, आप एक व्यक्तिगत पार्टिशन को [हाइपरलिंक असाइन कर सकते हैं](/slides/hi/java/manage-hyperlinks/); केवल वही खंड क्लिक योग्य होगा, पूरे पैराग्राफ नहीं।

**स्टाइल विरासत कैसे काम करती है: एक Portion क्या ओवरराइड करता है, और क्या Paragraph/TextFrame से लिया जाता है?**

Portion‑स्तर की प्रॉपर्टीज़ की सबसे अधिक प्राथमिकता होती है। यदि कोई प्रॉपर्टी [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) पर सेट नहीं है, तो इंजन इसे [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/paragraph/) से लेता है; यदि वहाँ भी सेट नहीं है, तो [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) या [theme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/theme/) स्टाइल से लेता है।

**यदि किसी Portion के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन/सर्वर पर उपलब्ध नहीं है तो क्या होता है?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/java/font-selection-sequence/) लागू होते हैं। टेक्स्ट का पुनः‑फ़्लो हो सकता है: मीट्रिक, हाइफ़नेशन और चौड़ाई बदल सकती है, जिससे सटीक पोजिशनिंग प्रभावित होती है।

**क्या मैं भाग‑विशिष्ट टेक्स्ट फ़िल पारदर्शिता या ग्रेडिएंट सेट कर सकता हूँ जो पैराग्राफ के बाकी हिस्सों से स्वतंत्र हो?**

हाँ, [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) स्तर पर टेक्स्ट रंग, फ़िल और पारदर्शिता पड़ोसी खंडों से अलग हो सकती है।