---
title: .NET में PPT को PPTX में बदलें
linktitle: PPT से PPTX
type: docs
weight: 20
url: /hi/net/convert-ppt-to-pptx/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPT से PPTX
- PPT को PPTX के रूप में सहेजें
- PPT को PPTX में निर्यात करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides के साथ लेगेसी PPT फ़ाइलों को PPTX में बदलें। एकल‑फ़ाइल और बैच रूपांतरण, त्रुटि संभाल, और निष्ठा नोट्स के लिए C# उदाहरण शामिल हैं।"
---
## **अवलोकन**

PPT लेगेसी बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX नया Open XML फ़ॉर्मेट है। Aspose.Slides for .NET Microsoft PowerPoint के बिना PPT फ़ाइल को लोड करके उसे PPTX के रूप में सहेज सकता है। यह लेख दिखाता है कि एक फ़ाइल या फ़ाइलों की निर्देशिका को कैसे बदलें और परिवर्तन के बाद क्या सत्यापित करना चाहिए।

## **PPT फ़ाइल को PPTX में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास से लोड करें, फिर [IPresentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) के साथ कॉल करें। `using` घोषणा प्रस्तुति को समाप्त करती है और स्कोप समाप्त होने पर उसके संसाधन जारी कर देती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// लेगेसी PPT प्रस्तुति लोड करें.
using var presentation = new Presentation("presentation.ppt");

// प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

फ़ाइल एक्सटेंशन स्वयं आउटपुट फ़ॉर्मेट को नहीं चुनता; यह कार्य [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) तर्क करता है। यदि आपको मूल PPT फ़ाइल रखना है तो इनपुट और आउटपुट पथ अलग रखें।

## **एकाधिक PPT फ़ाइलों को बदलें**

निम्नलिखित उदाहरण एक निर्देशिका में प्रत्येक `.ppt` फ़ाइल को बदलता है। प्रत्येक फ़ाइल स्वतंत्र रूप से प्रोसेस होती है, इसलिए एक विफल परिवर्तन शेष बैच को नहीं रोकता।

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

प्रोडक्शन कार्यभार के लिए, पूरी अपवाद को लॉग करें, तय करें कि मौजूदा आउटपुट फ़ाइल को ओवरराइट किया जा सकता है या नहीं, और विफल फ़ाइलों के नाम को पुनः प्रयास या समीक्षा कतार में लिखें। खराब फ़ाइलें, पासवर्ड‑सुरक्षित फ़ाइलें बिना आवश्यक पासवर्ड के खोली गई, पहुँच न रखने वाले पथ, और असमर्थित सामग्री सभी परिवर्तन को विफल कर सकते हैं। एन्क्रिप्टेड फ़ाइलों को लोड करने के लिए देखें [Password-Protected Presentations](/slides/hi/net/password-protected-presentation/)।

## **निष्ठा और लेगेसी सुविधाएँ**

परिवर्तन सामान्यतः स्लाइड्स, मास्टर्स, लेआउट्स, टेक्स्ट, शैप्स, इमेजेज, टेबल्स और चार्ट्स को संरक्षित रखता है। हालांकि, PPT और PPTX प्रत्येक सुविधा को बिल्कुल समान तरीके से प्रस्तुत नहीं करते। एक लेगेसी सुविधा जिसका PPTX समकक्ष नहीं है, या जो लाइब्रेरी द्वारा समर्थित नहीं है, उसे सामान्यीकृत, हटाया या अलग तरीके से दिखाया जा सकता है।

जब परिवर्तित फ़ाइल में एनीमेशन, ट्रांज़िशन, एम्बेडेड या लिंक्ड OLE ऑब्जेक्ट्स, ActiveX कंट्रोल्स, एम्बेडेड मीडिया, असामान्य फोंट्स, या VBA मैक्रो शामिल हों तो फ़ाइल की जांच करें। एक साधारण PPTX फ़ाइल मैक्रो‑सक्षम फ़ॉर्मेट नहीं है, इसलिए जब VBA उपलब्ध रहना आवश्यक हो तो उपयुक्त मैक्रो‑सक्षम कार्यप्रवाह का उपयोग करें। यह भी सत्यापित करें कि आवश्यक फोंट और बाहरी संसाधन उस पर्यावरण में मौजूद हों जहाँ परिवर्तित प्रस्तुति खोली या रेंडर की जाएगी।

महत्वपूर्ण दस्तावेज़ों के लिए, उत्पन्न PPTX को प्रोग्रामेटिकली फिर से खोलें और प्रमुख स्लाइड गिनती और सामग्री की जाँच करें, फिर इच्छित दर्शक में उसकी उपस्थिति और स्लाइड‑शो व्यवहार की तुलना करें। सफलता प्राप्त [IPresentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/) कॉल को इस बात का प्रमाण न मानें कि प्रत्येक लेगेसी सुविधा का सटीक PPTX प्रतिनिधित्व है।

## **जब PPTX उपयोग करें**

PPTX का उपयोग तब करें जब प्रस्तुति को वर्तमान PowerPoint संस्करणों में संपादित किया जाएगा, Open XML पैकेज के साथ कार्य करने वाले सिस्टमों के साथ आदान‑प्रदान किया जाएगा, या ऐसी फ़ॉर्मेट में संग्रहीत किया जाएगा जो लेगेसी बाइनरी PPT की तुलना में जांचना और पुनर्प्राप्त करना आसान हो। जब तक परिवर्तित प्रस्तुति आपके निष्ठा जांच पास नहीं कर ले, तब तक मूल PPT को अभिलेखीय या रोलबैक कॉपी के रूप में रखें।

यदि आपको PDF, HTML, इमेजेज, XPS, या कोई अन्य आउटपुट प्रकार चाहिए, तो सभी लक्ष्यों के संपादित PowerPoint सुविधाओं को संरक्षित रखने का अनुमान लगाने के बजाय [Convert Presentations to Multiple Formats](/slides/hi/net/convert-presentation/) में फ़ॉर्मेट‑विशिष्ट मार्गदर्शन का उपयोग करें।

## **ऑनलाइन रूपांतरणकर्ता**

अवध्य फाइल या त्वरित तुलना के लिए, आप [online PPT to PPTX converter](https://products.aspose.app/slides/hi/conversion/ppt-to-pptx) का उपयोग कर सकते हैं। दोहराने योग्य रूपांतरण, बैच प्रोसेसिंग, या एप्लिकेशन‑स्तर त्रुटि संभालने के लिए .NET API का उपयोग करें।

## **संबंधित लेख**

- [PPT बनाम PPTX](/slides/hi/net/ppt-vs-pptx/)
- [.NET में प्रस्तुतियों को सहेजें](/slides/hi/net/save-presentation/)
- [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/net/supported-file-formats/)
- [.NET में प्रस्तुतियों को खोलें](/slides/hi/net/open-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Microsoft PowerPoint स्थापित किए बिना PPT को PPTX में बदल सकता हूँ?**

हाँ। Aspose.Slides for .NET Microsoft PowerPoint की आवश्यकता के बिना प्रस्तुति फ़ाइलों को लोड और सहेजता है।

**क्या PPT‑to‑PPTX परिवर्तन सभी सामग्री को ठीक‑ठीक संरक्षित रखेगा?**

यह सामान्य प्रस्तुति सामग्री को संरक्षित रखता है, लेकिन हर लेगेसी या असमर्थित सुविधा के लिए सटीक निष्ठा गारंटीकृत नहीं है। जब उत्पन्न फ़ाइल में मैक्रो, OLE या ActiveX ऑब्जेक्ट्स, मीडिया, विशेष एनीमेशन, या असामान्य फ़ॉन्ट्स हों तो फ़ाइल की समीक्षा करें।

**क्या मैं पासवर्ड‑सुरक्षित PPT फ़ाइल को बदल सकता हूँ?**

हाँ, यदि आप फ़ाइल लोड करते समय सही पासवर्ड प्रदान करते हैं। एक गायब या गलत पासवर्ड लोड ऑपरेशन को विफल कर देता है।

**क्या मुझे परिवर्तन के बाद PPT फ़ाइल हटानी चाहिए?**

मूल फ़ाइल को तब तक रखें जब तक आप अपने लिए महत्वपूर्ण दर्शकों और वर्कफ़्लो में PPTX को सत्यापित नहीं कर लेते। इससे यदि कोई लेगेसी सुविधा अलग रूप से बदलती है तो रोलबैक कॉपी मिलती है।