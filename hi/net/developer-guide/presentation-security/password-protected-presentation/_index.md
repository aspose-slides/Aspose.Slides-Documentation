---
title: .NET में प्रस्तुतियों को पासवर्ड से सुरक्षित करें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/net/password-protected-presentation/
keywords:
- पासवर्ड-सुरक्षित प्रस्तुति
- खोलने वाला पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड सत्यापित करें
- प्रस्तुति पासवर्ड जांचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "C# में Aspose.Slides for .NET के साथ पासवर्ड‑सुरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पता लगाएँ, सत्यापित, खोलें और डिक्रिप्ट करें।"
---
## **अवलोकन**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड आवश्यक होता है प्रस्तुति की सामग्री को लोड और देखने के लिए, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक खोलने वाला पासवर्ड लिखने‑से‑रोकें पासवर्ड से अलग होता है। लिखने‑से‑रोकें पासवर्ड संशोधन को प्रतिबंधित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता या प्रस्तुति को लोड होने से नहीं रोकता। प्रस्तुतियों को संशोधित करने के पासवर्ड प्रबंधन के लिए देखें [प्रस्तुतियों को लिखने से रोकें](/slides/hi/net/write-protected-presentation/)।

नीचे दिए गए कार्यप्रवाह PPT और PPTX दोनों प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों फ़ॉर्मैट का उपयोग करते हैं जहाँ फ़ाइल‑आधारित और स्ट्रीम‑आधारित व्यवहार महत्वपूर्ण होता है।

## **एक खोलने वाले पासवर्ड के साथ प्रस्तुति एन्क्रिप्ट करें**

[IProtectionManager.Encrypt](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/encrypt/) का उपयोग करके खोलने वाला पासवर्ड निर्धारित करें। फिर एन्क्रिप्टेड प्रस्तुति को स्थायी बनाने के लिए [IPresentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/) का उपयोग करें।

निम्न उदाहरण एक PPTX प्रस्तुति को एन्क्रिप्ट करता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **दस्तावेज़ गुण सार्वजनिक रखें**

डिफ़ॉल्ट रूप से, Aspose.Slides प्रस्तुति एन्क्रिप्शन में दस्तावेज़ गुण शामिल करता है। [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) प्रॉपर्टी इस व्यवहार को स्लाइड‑सामग्री एन्क्रिप्शन से स्वतंत्र रूप से नियंत्रित करती है। जब कोई इंडेक्सिंग, वर्गीकरण, खोज या दस्तावेज़‑प्रबंधन प्रणाली पासवर्ड के बिना मेटाडाटा पढ़ना चाहे, तो [IProtectionManager.Encrypt](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/encrypt/) को कॉल करने से पहले इसे `false` सेट करें।

निम्न उदाहरण एक एन्क्रिप्टेड PPTX प्रस्तुति बनाता है जबकि उसकी अंतर्निहित दस्तावेज़ गुण सार्वजनिक रखता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

`EncryptDocumentProperties` को `false` करने से स्लाइड, मास्टर, लेआउट, आकार, मीडिया या अन्य प्रस्तुति सामग्री सार्वजनिक नहीं होती। यह केवल दस्तावेज़ गुणों को ही प्रभावित करता है। एन्क्रिप्टेड सामग्री लोड किए बिना उन गुणों को पढ़ने के लिए देखें [प्रस्तुति गुण प्रबंधित करें](/slides/hi/net/presentation-properties/)।

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

[LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) को खोलने वाले पासवर्ड पर सेट करें और फ़ाइल लोड करते समय विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) को पास करें। यदि खोलने वाला पासवर्ड आवश्यक है लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत है, तो लोड विफल हो जाता है।

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// डिक्रिप्टेड प्रस्तुति के साथ काम करें।
```

## **प्रस्तुति से एन्क्रिप्शन हटाएँ**

प्रस्तुति को उसके खोलने वाले पासवर्ड के साथ लोड करें, फिर [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/removeencryption/) को कॉल करें और परिणाम को सहेजें। सहेजी गई प्रस्तुति अब पासवर्ड के बिना लोड की जा सकती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **लोड करने से पहले खोलने वाले पासवर्ड का सत्यापन करें**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग करके [IPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/) प्राप्त करें, बिना पूर्ण प्रस्तुति उदाहरण बनाए। पासवर्ड का अनुरोध या सत्यापन करने से पहले [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/ispasswordprotected/) की जाँच करें। यदि सुरक्षा मौजूद है, तो प्रदान किए गए मान को [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/checkpassword/) से वैध करें।

### **फ़ाइल‑पथ कार्यप्रवाह**

निम्न उदाहरण PPTX फ़ाइल के लिए खोलने वाले पासवर्ड को सत्यापित करता है, सत्यापित मान को [LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) को पास करता है, और फिर पूर्ण प्रस्तुति लोड करता है:

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

### **स्ट्रीम कार्यप्रवाह**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) की स्ट्रीम ओवरलोड समान कार्यप्रवाह प्रदान करती है। पूर्ण प्रस्तुति को उस स्ट्रीम से लोड करने से पहले एक Seekable स्ट्रीम की स्थिति रीसेट करें।

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

### **CheckPassword रिटर्न मान**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/checkpassword/) केवल तब `true` लौटाता है जब प्रस्तुति में खोलने वाला पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह प्रत्येक निम्न मामलों में `false` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में खोलने वाला पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या खाली है।

व्यवहार PPT और PPTX दोनों प्रस्तुतियों के लिए समान है।

## **लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं जाँचें**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/isencrypted/) की जाँच करें ताकि स्रोत प्रस्तुति एन्क्रिप्टेड थी यह पुष्टि हो सके। लोड करने से पहले खोलने‑पासवर्ड सुरक्षा का पता लगाने के लिए ऊपर दिखाए अनुसार `IPresentationInfo.IsPasswordProtected` का उपयोग करें।

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
खोलने वाले पासवर्ड को लॉग न करें या उन्हें निदान संदेशों में शामिल न करें। अनावश्यक दोहराए गए सत्यापन प्रयासों से बचें, पासवर्ड को केवल आवश्यक अवधि तक स्मृति में रखें, और तुरंत प्रस्तुति लोड करते समय सफल सत्यापन परिणाम को पुन: उपयोग करें।

सार्वजनिक दस्तावेज़ गुण लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मानों को उजागर कर सकते हैं जबकि प्रस्तुति सामग्री एन्क्रिप्टेड रहती है। संवेदनशील मेटाडाटा को प्रस्तुति के साथ एन्क्रिप्ट करें। गुणों को सार्वजनिक रखने का निर्णय केवल तभी लेना चाहिए जब सिस्टम को खोलने वाले पासवर्ड के बिना फ़ाइल को इंडेक्स, वर्गीकृत, खोज या प्रबंधित करना आवश्यक हो।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड‑प्रोटेक्ट करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति चुनें या अपलोड करें।
3. देखे जाने की सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामी फ़ाइल डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [प्रस्तुतियों को लिखने से रोकें](/slides/hi/net/write-protected-presentation/)
- [PowerPoint में डिजिटल हस्ताक्षर](/slides/hi/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक खोलने वाला पासवर्ड और लिखने‑से‑रोकें पासवर्ड में क्या अंतर है?**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री लोड करने के लिए आवश्यक होता है। लिखने‑से‑रोकें पासवर्ड संशोधन को प्रतिबंधित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता।

**क्या मैं सभी स्लाइड लोड किए बिना खोलने वाले पासवर्ड को सत्यापित कर सकता हूँ?**

हाँ। प्रस्तुति जानकारी प्राप्त करें, जांचें कि खोलने‑पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति उदाहरण बनाने से पहले पासवर्ड को सत्यापित करें।

**क्या कोई एप्लिकेशन खोलने वाले पासवर्ड के बिना मेटाडाटा पढ़ सकता है?**

हाँ, लेकिन केवल तभी जब प्रस्तुति को `EncryptDocumentProperties` `false` रखकर एन्क्रिप्ट किया गया हो। तब एप्लिकेशन को केवल‑दस्तावेज‑गुण लोड मोड का उपयोग करना चाहिए जैसा कि [प्रस्तुति गुण प्रबंधित करें](/slides/hi/net/presentation-properties/) में बताया गया है।

**क्या पासवर्ड‑जांच कार्यप्रवाह PPT और PPTX दोनों का समर्थन करते हैं?**

हाँ। फ़ाइल‑पथ और स्ट्रीम‑आधारित पासवर्ड डिटेक्शन तथा सत्यापन PPT और PPTX दोनों प्रस्तुतियों के लिए समान व्यवहार रखते हैं।