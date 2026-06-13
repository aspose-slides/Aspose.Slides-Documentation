---
title: C++ का उपयोग करके प्रस्तुतियों में टेक्स्ट पोर्शन प्रबंधित करें
linktitle: टेक्स्ट पोर्शन
type: docs
weight: 70
url: /hi/cpp/portion/
keywords:
- टेक्स्ट पोर्शन
- टेक्स्ट भाग
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट पोर्शन को कैसे प्रबंधित करें, सीखें, जिससे प्रदर्शन और अनुकूलन में सुधार होता है।"
---
## **परिचय**

एक टेक्स्ट पोर्शन पैराग्राफ के भीतर एक विशिष्ट टेक्स्ट अंश का प्रतिनिधित्व करता है और आपको उस अंश के साथ आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, पोर्शन का उपयोग तब किया जा सकता है जब आपको टेक्स्ट अंश की स्थिति प्राप्त करनी हो, केवल पैराग्राफ के किसी हिस्से पर फ़ॉर्मेटिंग लागू करनी हो, या टेक्स्ट व्यवहार को अधिक विस्तृत स्तर पर नियंत्रित करना हो।

## **टेक्स्ट पोर्शन के निर्देशांक प्राप्त करें**
**GetCoordinates()** मेथड को IPortion और Portion क्लास में जोड़ा गया है जो पोर्शन की शुरुआत के निर्देशांक प्राप्त करने की सुविधा देता है:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक पैराग्राफ के भीतर केवल टेक्स्ट के किसी हिस्से पर हाइपरलिंक लागू कर सकता हूँ?**

हाँ, आप एक व्यक्तिगत पोर्शन को [हाइपरलिंक असाइन](/slides/hi/cpp/manage-hyperlinks/) कर सकते हैं; केवल वह अंश क्लिक योग्य होगा, पूरी पैराग्राफ नहीं।

**स्टाइल इनहेरिटेंस कैसे काम करता है: एक पोर्शन क्या ओवरराइड करता है, और क्या Paragraph/TextFrame से लिया जाता है?**

Portion-स्तर की प्रॉपर्टीज़ का सबसे उच्च प्राथमिकता होती है। यदि कोई प्रॉपर्टी [Portion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portion/) पर सेट नहीं है, तो इंजन इसे [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) से लेता है; यदि वहां भी सेट नहीं है, तो इसे [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframe/) या [theme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/theme/) स्टाइल से लिया जाता है।

**यदि किसी पोर्शन के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन/सर्वर पर उपलब्ध नहीं है तो क्या होगा?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/cpp/font-selection-sequence/) लागू होते हैं। टेक्स्ट पुनः व्यवस्थित हो सकता है: मीट्रिक्स, हाइफ़नेशन, और चौड़ाई बदल सकती है, जो सटीक पोज़िशनिंग के लिए महत्वपूर्ण है।

**क्या मैं पोर्शन-विशिष्ट टेक्स्ट फ़िल ट्रांसपैरेंसी या ग्रेडिएंट को पैराग्राफ के बाकी हिस्सों से स्वतंत्र रूप से सेट कर सकता हूँ?**

हाँ, [Portion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portion/) स्तर पर टेक्स्ट रंग, फ़िल और ट्रांसपैरेंसी पड़ोसी अंशों से अलग हो सकते हैं।