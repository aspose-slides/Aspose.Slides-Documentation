---
title: "Aspose.Slides के साथ PPT, PPTX और ODP से टेक्स्ट निकालने की विधि"
linktitle: "स्लाइड्स"
type: docs
weight: 30
url: /hi/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- "क्लाउड प्लेटफ़ॉर्म"
- "क्लाउड इंटीग्रेशन"
- "टेक्स्ट निष्कर्षण"
- "टेक्स्ट निकालें"
- PPT
- PPTX
- ODP
- "प्रेज़ेंटेशन फ़ाइलें"
- "क्रॉस-प्लेटफ़ॉर्म"
- "ऑफ़िस-स्वतंत्र"
- "नोट्स और कमेंट्स"
- "कॉर्पोरेट इंडेक्सिंग"
- "डेटा एन्हांसमेंट"
- .NET
- Aspose.Slides
description: "Aspose.Slides APIs का उपयोग करके लोकप्रिय क्लाउड प्लेटफ़ॉर्म पर प्रेज़ेंटेशन से टेक्स्ट निकालें, जिससे PPT, PPTX और ODP के लिए खोज, विश्लेषण और निर्यात स्वचालित हो सके।"
---
## **परिचय**

Aspose.Slides एक **शक्तिशाली, उच्च-स्तरीय API** प्रदान करता है जो प्रस्तुति फ़ाइलों से टेक्स्ट निकालता है, जिसमें **PPT, PPTX, और ODP** शामिल हैं। Open XML SDK—जो केवल PPTX का समर्थन करता है और जटिल XML पार्सिंग की आवश्यकता रखता है—के विपरीत, Aspose.Slides टेक्स्ट निष्कर्षण को सरल बनाता है, जिससे आप निकाले गए कंटेंट को अपने वर्कफ़्लो में एकीकृत करने पर ध्यान केंद्रित कर सकते हैं।

## **PresentationFactory.Instance.GetPresentationText के साथ तेज़ टेक्स्ट निष्कर्षण**

एक प्रस्तुति से टेक्स्ट निकालने के लिए, **Aspose.Slides API** स्थैतिक मेथड `PresentationFactory.Instance.GetPresentationText` प्रदान करता है। यह मेथड कई ओवरलोड्स के साथ आता है जो प्रस्तुति फ़ाइल या डेटा स्ट्रीम के साथ काम करते हैं, और **स्लाइड्स, मास्टर स्लाइड्स, लेआउट्स, नोट्स, और कमेंट्स** से टेक्स्ट कैप्चर करता है। निकाला गया टेक्स्ट `IPresentationText` इंटरफ़ेस के माध्यम से एक्सेस किया जाता है।

उदाहरण उपयोग:

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **GetPresentationText के संचालन मोड**

`PresentationFactory` में `GetPresentationText` मेथड आपको `TextExtractionArrangingMode` पैरामीटर का उपयोग करके टेक्स्ट निष्कर्षण को बारीकी से समायोजित करने की अनुमति देता है, जो आउटपुट में टेक्स्ट के व्यवस्थित होने के तरीके को नियंत्रित करता है।

### **उपलब्ध मोड**

- **TextExtractionArrangingMode.Unarranged** – मूल स्लाइड लेआउट को नजरअंदाज करते हुए, मुक्त रूप में टेक्स्ट निकालता है।  
- **TextExtractionArrangingMode.Arranged** – प्रत्येक स्लाइड पर टेक्स्ट की स्थिति के अनुसार क्रम को बरकरार रखता है।

उपयोग उदाहरण:

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **PresentationFactory मेथड्स के मुख्य लाभ**

- **पूरी प्रस्तुतियों को लोड करने की आवश्यकता नहीं**: मेमोरी खपत को न्यूनतम करता है और प्रोसेसिंग गति को बढ़ाता है।  
- **बड़ी फ़ाइलों के लिए अनुकूलित**: बड़े आकार की प्रस्तुतियों को भी कुशलतापूर्वक संभालता है, तेज़ी से टेक्स्ट निकालता है।  
- **नोट्स और कमेंट्स भी प्राप्त करता है**: व्यापक कंटेंट कवरेज के लिए उपयोगकर्ता एनोटेशन शामिल करता है।  
- **इंडेक्सिंग और कंटेंट विश्लेषण के लिए आदर्श**: स्वचालित प्रोसेसिंग और डेटा एन्हांसमेंट की आवश्यकता वाले कॉर्पोरेट सिस्टम के लिए परिपूर्ण।  
- **ऑफ़िस-स्वतंत्र**: Microsoft PowerPoint स्थापित किए बिना काम करता है, एक वास्तविक स्टैंडअलोन समाधान प्रदान करता है।  
- **मल्टी-फ़ॉर्मेट सपोर्ट**: **PPT, PPTX, और ODP** के साथ सहजता से कार्य करता है।  
- **लचीला, शक्तिशाली API**: संरचित टेक्स्ट निष्कर्षण के लिए विविध मेथड्स प्रदान करता है।  
- **पूरा स्लाइड कवरेज**: **लेआउट्स, मास्टर स्लाइड्स, स्टैंडर्ड स्लाइड्स, बैकग्राउंड्स, स्पीकर नोट्स, और कमेंट्स** से टेक्स्ट निकालता है।  
- **क्रॉस-प्लेटफ़ॉर्म संगतता**: **Windows, Linux, macOS** पर तथा क्लाउड वातावरण में संचालित होता है।  
- **उच्च प्रदर्शन और स्केलेबिलिटी**: **SaaS एप्लिकेशन** और बड़े पैमाने पर एंटरप्राइज़ डिप्लॉयमेंट के लिए उपयुक्त।

## **समर्थित ऑपरेटिंग सिस्टम**

Aspose.Slides विभिन्न ऑपरेटिंग सिस्टम पर चलता है:

- **Windows** (जैसे Windows 7, 8, 10, 11, और Server संस्करण)  
- **Linux** (विभिन्न वितरण, जिसमें Ubuntu, Debian, Fedora, CentOS आदि शामिल हैं)  
- **macOS** (आधुनिक संस्करण जैसे 10.15 Catalina और बाद के संस्करण)  

## **समर्थित प्रोग्रामिंग भाषाएँ**

Aspose.Slides कई प्लेटफ़ॉर्म और भाषाओं के साथ एकीकृत है:

- **C#** – मुख्य रूप से Aspose.Slides for .NET के माध्यम से समर्थित।  
- **Java** – Aspose.Slides for Java के साथ पूर्ण‑फ़ीचर API उपलब्ध।  
- **C++** – प्रदर्शन‑संकल्पित C++ अनुप्रयोगों के लिए Aspose.Slides का उपयोग करें।  
- **Python via .NET** – .NET इंटरऑपरेबिलिटी के माध्यम से Aspose.Slides कार्यक्षमता को शामिल करें।  
- **Other .NET-Compatible Languages** – .NET द्वारा समर्थित किसी भी वातावरण में लाइब्रेरी का उपयोग करें।

## **निष्कर्ष**

Aspose.Slides PowerPoint और OpenDocument प्रस्तुतियों के लिए **समग्र टेक्स्ट निष्कर्षण** प्रदान करता है, जो **विविध फ़ाइल फ़ॉर्मैट, सहज टेक्स्ट संरचना, और सरल कार्यान्वयन** को सपोर्ट करता है, जबकि Open XML SDK की तुलना में अधिक आसान है। **स्लाइड्स और नोट्स से लेकर टेम्पलेट कंटेंट तक**, **Aspose.Slides** टेक्स्ट निकालने और प्रबंधित करने के लिए उच्च‑दक्षता, फीचर‑समृद्ध समाधान है।