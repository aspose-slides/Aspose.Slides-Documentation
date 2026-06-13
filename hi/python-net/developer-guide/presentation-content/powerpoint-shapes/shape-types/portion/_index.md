---
title: Python के साथ प्रस्तुतियों में टेक्स्ट भागों का प्रबंधन
linktitle: टेक्स्ट भाग
type: docs
weight: 70
url: /hi/python-net/portion/
keywords:
- टेक्स्ट भाग
- टेक्स्ट भाग
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट भागों का प्रबंधन करने के लिए Aspose.Slides for Python via .NET का उपयोग करके, प्रदर्शन और अनुकूलन को बढ़ाते हुए सीखें।"
---
## **परिचय**

पाठ भाग पैराग्राफ के भीतर एक विशिष्ट टेक्स्ट फ्रैगमेंट का प्रतिनिधित्व करता है और आपको उस फ्रैगमेंट को आस-पास की सामग्री से स्वतंत्र रूप से काम करने की सुविधा देता है। Aspose.Slides में, जब आपको टेक्स्ट फ्रैगमेंट की स्थिति प्राप्त करनी हो, केवल पैराग्राफ के भाग पर फॉर्मेटिंग लागू करनी हो, या टेक्स्ट व्यवहार को अधिक विस्तृत स्तर पर नियंत्रित करना हो, तो भागों का उपयोग किया जा सकता है।

## **पाठ भागों के निर्देशांक प्राप्त करें**

The [get_coordinates](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/get_coordinates/) मेथड को [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) क्लास में जोड़ा गया है जो पाठ भागों के निर्देशांक प्राप्त करने की अनुमति देता है:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही पैराग्राफ के भीतर केवल टेक्स्ट के किसी भाग पर हाइपरलिंक लगा सकता हूँ?**

हाँ, आप व्यक्तिगत भाग पर [assign a hyperlink](/slides/hi/python-net/manage-hyperlinks/) लगा सकते हैं; केवल वह फ्रैगमेंट क्लिक करने योग्य होगा, पूरे पैराग्राफ नहीं।

**स्टाइल इनहेरिटेंस कैसे काम करता है: एक Portion कौन सी चीज़ ओवरराइड करता है, और क्या Paragraph/TextFrame से लिया जाता है?**

Portion-स्तर की प्रॉपर्टी सबसे अधिक प्राथमिकता रखती हैं। यदि कोई प्रॉपर्टी [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) पर सेट नहीं है, तो इंजन इसे [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) से लेता है; यदि वहां भी सेट नहीं है, तो इसे [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) या [theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/theme/) शैली से लेता है।

**यदि Portion के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन/सर्वर पर उपलब्ध नहीं है तो क्या होता है?**

[Font substitution rules](/slides/hi/python-net/font-selection-sequence/) लागू होते हैं। टेक्स्ट पुनः व्यवस्थित हो सकता है: मेट्रिक, हाइफ़नेशन और चौड़ाई बदल सकती है, जो सटीक पोजिशनिंग के लिए महत्वपूर्ण है।

**क्या मैं Paragraph के बाकी हिस्सों से स्वतंत्र रूप से Portion-विशिष्ट टेक्स्ट फ़िल ट्रांसपेरेंसी या ग्रेडिएंट सेट कर सकता हूँ?**

हाँ, [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) स्तर पर टेक्स्ट रंग, फ़िल और ट्रांसपेरेंसी पड़ोसी फ्रैगमेंट्स से अलग हो सकते हैं।