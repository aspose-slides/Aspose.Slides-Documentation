---
title: C++ में PowerPoint प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करें
linktitle: PowerPoint से Word
type: docs
weight: 110
url: /hi/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से Word
- प्रस्तुति से Word
- स्लाइड से Word
- PPT से Word
- PPTX से Word
- PowerPoint से DOCX
- प्रस्तुति से DOCX
- स्लाइड से DOCX
- PPT से DOCX
- PPTX से DOCX
- PowerPoint से DOC
- प्रस्तुति से DOC
- स्लाइड से DOC
- PPT से DOC
- PPTX से DOC
- PPT को DOCX के रूप में सहेजें
- PPTX को DOCX के रूप में सहेजें
- PPT को DOCX में निर्यात करें
- PPTX को DOCX में निर्यात करें
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PowerPoint PPT और PPTX स्लाइड्स को संपादन योग्य Word दस्तावेज़ों में परिवर्तित करें, जो सटीक लेआउट, छवियां और फ़ॉर्मेटिंग को संरक्षित रखता है।"
---
## **परिचय**

यदि आप नई तरीकों से एक प्रस्तुति (PPT या PPTX) से पाठ्य सामग्री या जानकारी का उपयोग करने की योजना बनाते हैं, तो आप प्रस्तुति को Word (DOC या DOCX) में परिवर्तित करने से लाभ उठा सकते हैं। 

* Microsoft PowerPoint की तुलना में, Microsoft Word एप्लिकेशन सामग्री के लिए अधिक उपकरण या कार्यात्मकता प्रदान करता है। 
* Word में संपादन कार्यों के अलावा, आप उन्नत सहयोग, प्रिंटिंग और शेयरिंग सुविधाओं से भी लाभ उठा सकते हैं। 

{{% alert color="primary" %}} 
आप हमारे [**Presentation to Word Online Converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-word) को आज़माना चाह सकते हैं ताकि आप स्लाइड्स की पाठ्य सामग्री के साथ काम करके क्या लाभ प्राप्त कर सकते हैं, देख सकें। 
{{% /alert %}} 

## **Aspose.Slides और Aspose.Words**

PowerPoint फ़ाइल (PPTX या PPT) को Word (DOCX या DOC) में परिवर्तित करने के लिए आपको दोनों [Aspose.Slides for C++](https://products.aspose.com/slides/hi/cpp/) और [Aspose.Words for C++](https://products.aspose.com/words/cpp/) की आवश्यकता है। 

एक स्टैंडअलोन्‍न API के रूप में, C++ के लिए [Aspose.Slides](https://products.aspose.app/slides) ऐसी कार्यक्षमता प्रदान करता है जो आपको प्रस्तुतियों से पाठ निकालने की अनुमति देती है। 

[Aspose.Words](https://docs.aspose.com/words/cpp/) एक उन्नत दस्तावेज़ प्रोसेसिंग API है जो अनुप्रयोगों को फ़ाइलें उत्पन्न करने, संशोधित करने, परिवर्तित करने, रेंडर करने, प्रिंट करने और Microsoft Word का उपयोग किए बिना दस्तावेज़ों के साथ अन्य कार्य करने में सक्षम बनाता है। 

## **PowerPoint प्रस्तुति को Word दस्तावेज़ में परिवर्तित करें**

PowerPoint को Word में परिवर्तित करने के लिए इस कोड स्निपेट का उपयोग करें: 

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // स्लाइड की छवि उत्पन्न करता है और सम्मिलित करता है
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // स्लाइड के पाठ सम्मिलित करता है
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करने के लिए किन घटकों की स्थापना आवश्यक है?**

आपको केवल अपने प्रोजेक्ट में [Aspose.Slides for C++](https://releases.aspose.com/slides/hi/cpp/) और [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) के संबंधित पैकेज जोड़ने की जरूरत है। दोनों लाइब्रेरी स्टैंडअलोन्‍न API के रूप में काम करती हैं, और Microsoft Office की स्थापना आवश्यक नहीं है।

**क्या सभी PowerPoint और OpenDocument प्रस्तुति फ़ॉर्मेट समर्थित हैं?**

Aspose.Slides सभी प्रस्तुति फ़ॉर्मेट को [सपोर्ट करता है](/slides/hi/cpp/supported-file-formats/), जिसमें PPT, PPTX, ODP और अन्य सामान्य फ़ाइल प्रकार शामिल हैं। इससे आप विभिन्न संस्करणों के Microsoft PowerPoint में बनाई गई प्रस्तुतियों के साथ काम कर सकते हैं।