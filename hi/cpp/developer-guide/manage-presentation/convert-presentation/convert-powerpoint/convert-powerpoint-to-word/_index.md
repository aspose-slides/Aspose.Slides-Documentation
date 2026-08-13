---
title: C++ में PowerPoint प्रस्तुतियों को Word दस्तावेज़ों में बदलें
linktitle: PowerPoint से Word
type: docs
weight: 110
url: /hi/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
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
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint PPT और PPTX स्लाइड्स को संपादन योग्य Word दस्तावेज़ों में बदलें, सटीक लेआउट, चित्र और स्वरूपण को संरक्षित रखते हुए."
---
## **परिचय**

यदि आप किसी प्रस्तुति (PPT या PPTX) से पाठ्य सामग्री या जानकारी को नए तरीकों से उपयोग करने की योजना बना रहे हैं, तो आप प्रस्तुति को Word (DOC या DOCX) में परिवर्तित करने से लाभ उठा सकते हैं।

* जब Microsoft PowerPoint की तुलना में देखें, तो Microsoft Word एप्लिकेशन सामग्री के लिए अधिक टूल्स या कार्यात्मकताओं से सुसज्जित है।
* Word में संपादन कार्यों के अलावा, आप उन्नत सहयोग, प्रिंटिंग और शेयरिंग सुविधाओं से भी लाभ उठा सकते हैं।

{{% alert color="info" %}} 
आप हमारे [**Presentation to Word Online Converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-word) को आज़मा सकते हैं ताकि आप स्लाइड्स की पाठ्य सामग्री के साथ काम करने से क्या लाभ मिल सकता है, देख सकें। 
{{% /alert %}} 

## **Aspose.Slides और Aspose.Words**

PowerPoint फ़ाइल (PPTX या PPT) को Word (DOCX या DOC) में परिवर्तित करने के लिए, आपको दोनों [Aspose.Slides for C++](https://products.aspose.com/slides/hi/cpp/) और [Aspose.Words for C++](https://products.aspose.com/words/cpp/) की आवश्यकता है।

एक स्वतंत्र API के रूप में, C++ के लिए [Aspose.Slides](https://products.aspose.app/slides) फ़ंक्शन प्रदान करता है जो आपको प्रस्तुतियों से पाठ निकालने की अनुमति देता है।

[Aspose.Words](https://docs.aspose.com/words/cpp/) एक उन्नत दस्तावेज़ प्रोसेसिंग API है जो अनुप्रयोगों को बिना Microsoft Word का उपयोग किए फ़ाइलें उत्पन्न करने, संशोधित करने, रूपांतरित करने, रेंडर करने, प्रिंट करने और दस्तावेज़ों के साथ अन्य कार्य करने की अनुमति देता है।

## **PowerPoint प्रस्तुति को Word दस्तावेज़ में परिवर्तित करें**

PowerPoint को Word में परिवर्तित करने के लिए इस कोड स्निपेट का उपयोग करें:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // स्लाइड की इमेज को बाइट एरे स्ट्रीम के रूप में उत्पन्न करता है
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // स्लाइड के टेक्स्ट को सम्मिलित करता है
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

doc->Save(u"output.docx");
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

### PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ में परिवर्तित करने के लिए किन घटकों को स्थापित करने की आवश्यकता है?

आपको केवल अपने प्रोजेक्ट में संबंधित पैकेज [Aspose.Slides for C++](https://releases.aspose.com/slides/hi/cpp/) और [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) जोड़ने की आवश्यकता है। दोनों लाइब्रेरी स्वतंत्र APIs के रूप में कार्य करती हैं, और Microsoft Office स्थापित करने की कोई आवश्यकता नहीं है।

### क्या सभी PowerPoint और OpenDocument प्रस्तुति फ़ॉर्मेट समर्थित हैं?

Aspose.Slides [सभी प्रस्तुति फ़ॉर्मेट का समर्थन करता है](/slides/hi/cpp/supported-file-formats/), जिसमें PPT, PPTX, ODP और अन्य सामान्य फ़ाइल प्रकार शामिल हैं। यह सुनिश्चित करता है कि आप विभिन्न संस्करणों के Microsoft PowerPoint में बनाई गई प्रस्तुतियों के साथ काम कर सकें।