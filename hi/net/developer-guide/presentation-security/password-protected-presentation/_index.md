---
title: .NET में प्रस्तुतियों को पासवर्ड-प्रोटेक्ट करें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/net/password-protected-presentation/
keywords:
- पासवर्ड-रक्षित प्रस्तुति
- ओपनिंग पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड मान्य करें
- प्रस्तुति पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "C# के साथ Aspose.Slides for .NET का उपयोग करके पासवर्ड-रक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचान, मान्य, खोल और डिक्रिप्ट करें।"
---
## **सारांश**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड आवश्यक होता है प्रस्तुति की सामग्री को लोड और देख पाने के लिए, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक ओपनिंग पासवर्ड लिखने-रोक थाम पासवर्ड से अलग होता है। लिखने-रोकथाम संशोधन को सीमित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता और प्रस्तुति को लोड होने से नहीं रोकता। प्रस्तुतियों के संशोधन के लिए पासवर्ड प्रबंधित करने हेतु देखें [Write-Protect Presentations](/slides/hi/net/write-protected-presentation/)।

नीचे दिए गए वर्कफ़्लो दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों फ़ॉर्मेट्स का उपयोग करते हैं जहाँ उनका फ़ाइल-आधारित और स्ट्रीम-आधारित व्यवहार महत्वपूर्ण होता है।

## **एक ओपनिंग पासवर्ड के साथ प्रस्तुति को एन्क्रिप्ट करना**

एक ओपनिंग पासवर्ड निर्धारित करने के लिए [IProtectionManager.Encrypt](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/encrypt/) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को स्थायी करने के लिए [IPresentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/) का उपयोग करें।

निम्न उदाहरण एक PPTX प्रस्तुति को एन्क्रिप्ट करता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **एक एन्क्रिप्टेड प्रस्तुति को लोड करना**

[LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) को ओपनिंग पासवर्ड पर सेट करें और फ़ाइल लोड करते समय विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) को पास करें। लोडिंग विफल हो जाती है जब ओपनिंग पासवर्ड आवश्यक हो लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत हो।

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// डिक्रिप्टेड प्रस्तुति के साथ काम करें।
```

## **एक प्रस्तुति से एन्क्रिप्शन हटाना**

प्रस्तुति को उसके ओपनिंग पासवर्ड के साथ लोड करें, [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/removeencryption/) को कॉल करें, और परिणाम को सेव करें। सहेजी गई प्रस्तुति को फिर पासवर्ड के बिना लोड किया जा सकता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **लोड करने से पहले एक ओपनिंग पासवर्ड को मान्य करना**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग करके [IPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/) प्राप्त करें बिना पूर्ण प्रस्तुति इंस्टेंस बनाए। पासवर्ड पूछने या मान्य करने से पहले [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/ispasswordprotected/) को जांचें। जब सुरक्षा मौजूद हो, तो प्रदान किए गए मान को [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/checkpassword/) से मान्य करें।

### **फ़ाइल-पथ वर्कफ़्लो**

निम्न उदाहरण PPTX फ़ाइल के लिए ओपनिंग पासवर्ड को मान्य करता है, मान्य मान को [LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) को पास करता है, और फिर पूरी प्रस्तुति को लोड करता है:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **स्ट्रीम वर्कफ़्लो**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) का स्ट्रीम ओवरलोड वही वर्कफ़्लो प्रदान करता है। उस स्ट्रीम से पूर्ण प्रस्तुति लोड करने से पहले एक seekable स्ट्रीम की पोजिशन रीसेट करें।

निम्न उदाहरण PPT फ़ाइल का उपयोग करता है:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **CheckPassword रिटर्न वैल्यूज**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/checkpassword/) केवल तभी `true` लौटाता है जब प्रस्तुति में ओपनिंग पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह निम्न मामलों में `false` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में ओपनिंग पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या खाली है।

यह व्यवहार PPT और PPTX प्रस्तुतियों के लिए समान है।

## **लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं जांचें**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, स्रोत प्रस्तुति एन्क्रिप्टेड थी यह पुष्टि करने के लिए [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/isencrypted/) की जांच करें। लोड करने से पहले ओपनिंग-पासवर्ड सुरक्षा का पता लगाने के लिए ऊपर दिखाए अनुसार `IPresentationInfo.IsPasswordProtected` का उपयोग करें।

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **सुरक्षा सिफारिशें**
{{% alert color="warning" title="Security" %}}
ओपनिंग पासवर्ड को लॉग नहीं करें या उन्हें निदान संदेशों में शामिल न करें। अनावश्यक दोहराए गए मान्यकरण प्रयासों से बचें, पासवर्ड को मेमोरी में केवल आवश्यक अवधि तक रखें, और जब तुरंत प्रस्तुति लोड की जा रही हो तो सफल मान्यकरण परिणाम को पुनः उपयोग करें।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड-प्रोटेक्ट करें**
1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।  
1. प्रस्तुति को चुनें या अपलोड करें।  
1. दृश्य सुरक्षा के लिए पासवर्ड दर्ज करें।  
1. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।  
1. सुरक्षा लागू करें और उत्पन्न फ़ाइल डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/hi/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**ओपनिंग पासवर्ड और लिखने-रोकथाम पासवर्ड में क्या अंतर है?**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री को लोड करने के लिए आवश्यक होता है। लिखने-रोकथाम पासवर्ड सामग्री को एन्क्रिप्ट किए बिना संशोधन को सीमित करता है।

**क्या मैं सभी स्लाइड्स लोड किए बिना ओपनिंग पासवर्ड को मान्य कर सकता हूँ?**

हां। प्रस्तुति जानकारी प्राप्त करें, जांचें कि ओपनिंग-पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड को मान्य करें।

**क्या पासवर्ड-चेकिंग वर्कफ़्लो दोनों PPT और PPTX का समर्थन करते हैं?**

हां। फ़ाइल-पथ और स्ट्रीम-आधारित पासवर्ड डिटेक्शन और वैधता दोनों PPT और PPTX प्रस्तुतियों के लिए समान व्यवहार करती है।