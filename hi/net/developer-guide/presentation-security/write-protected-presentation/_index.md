---
title: .NET में लिखने‑रोकथाम प्रस्तुतियां
linktitle: लिखने‑रोकथाम
type: docs
weight: 25
url: /hi/net/write-protected-presentation/
keywords:
- लिखने‑रोकथाम
- PowerPoint को लिखने‑रोकथाम
- संशोधन के लिए पासवर्ड
- प्रस्तुति संपादन को प्रतिबंधित करें
- लिखने‑रोकथाम हटाएँ
- संशोधन पासवर्ड सत्यापित करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint PPT और PPTX प्रस्तुतियों में लिखने‑रोकथाम पासवर्ड सेट करें, पता लगाएँ, सत्यापित करें और हटाएँ।"
---
## **परिचय**

एक लिखने‑रोकथाम पासवर्ड प्रस्तुति में संशोधन को रोकता है लेकिन इसकी सामग्री को एन्क्रिप्ट नहीं करता। उपयोगकर्ता पासवर्ड के बिना लिखे‑रोकथाम वाले प्रस्तुति को लोड और देख सकते हैं। एप्लिकेशन के आधार पर, वे सामग्री को संपादित करके किसी दूसरे नाम से भी सहेज सकते हैं, इसलिए लिखने‑रोकथाम को गोपनीयता तंत्र के रूप में नहीं माना जाना चाहिए।

एक ओपनिंग पासवर्ड का उद्देश्य अलग है: यह प्रस्तुति को एन्क्रिप्ट करता है और इसकी सामग्री लोड करने के लिए आवश्यक होता है। प्रस्तुति को एन्क्रिप्ट करने या ओपनिंग पासवर्ड को वैध करने के लिए, देखें [प्रेज़ेंटेशन को पासवर्ड‑सुरक्षित बनाना](/slides/hi/net/password-protected-presentation/)।

इस लेख में वर्णित कार्यप्रवाह दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण PPTX फ़ाइलों का उपयोग करते हैं; PPT में सहेजते समय, `.ppt` एक्सटेंशन और संबंधित PPT सहेजने के फ़ॉर्मेट का उपयोग करें।

## **प्रेज़ेंटेशन में लिखने‑रोकथाम सेट करें**

[IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/setwriteprotection/) का उपयोग करके प्रस्तुति को संशोधित करने हेतु पासवर्ड असाइन करें। प्रस्तुति को सहेजने से सुरक्षा सेटिंग बनी रहती है।

निम्नलिखित उदाहरण PPTX प्रेज़ेंटेशन पर लिखने‑रोकथाम सेट करता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **लिखे‑रोकथाम वाले प्रेज़ेंटेशन को लोड करें**

चूंकि लिखने‑रोकथाम प्रस्तुति की सामग्री को एन्क्रिप्ट नहीं करता, इसलिए प्रस्तुति को लोड करने के लिए पासवर्ड आवश्यक नहीं है। पासवर्ड केवल तब प्रासंगिक होता है जब संरक्षित प्रस्तुति को संशोधित करने के अधिकार की वैधता जाँचनी होती है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

[LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) में लिखने‑रोकथाम पासवर्ड न भेजें। यह प्रॉपर्टी एन्क्रिप्टेड सामग्री के लिए ओपनिंग पासवर्ड स्वीकार करती है। यदि कोई प्रस्तुति दोनों प्रकार की सुरक्षा रखती है, तो उसे लोड करने के लिए ओपनिंग पासवर्ड प्रदान करें और लिखने‑रोकथाम पासवर्ड को अलग से संभालें।

## **प्रेज़ेंटेशन से लिखने‑रोकथाम हटाएँ**

[IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/removewriteprotection/) का उपयोग करके संशोधन प्रतिबंध हटाएँ, फिर प्रस्तुति को सहेजें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **जाँचें कि प्रस्तुति लिखने‑रोकथाम है या नहीं**

फ़ाइल को पूर्ण [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस बनाए बिना निरीक्षण करने के लिए, [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) कॉल करें और [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/iswriteprotected/) की जांच करें। यह प्रॉपर्टी [NullableBool](https://reference.aspose.com/slides/hi/net/aspose.slides/nullablebool/) का उपयोग करती है और लिखने‑रोकथाम पता चलने पर `NullableBool.True` लौटाती है।

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationfactory/getpresentationinfo/) का स्ट्रीम ओवरलोड एक स्ट्रीम के रूप में प्रदान की गई प्रस्तुति के लिए समान जानकारी देता है।

## **लिखने‑रोकथाम पासवर्ड मान्य करें**

पूर्ण प्रस्तुति लोड किए बिना संशोधन पासवर्ड को मान्य करने के लिए [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/checkwriteprotection/) का उपयोग करें। पहले [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/iswriteprotected/) जांचें ताकि एप्लिकेशन केवल लिखने‑रोकथाम मौजूद होने पर ही पासवर्ड का अनुरोध या सत्यापन करे।

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/checkwriteprotection/) केवल लिखने‑रोकथाम पासवर्ड को मान्य करता है। यह ओपनिंग पासवर्ड को मान्य नहीं करता या यह निर्धारित नहीं करता कि एन्क्रिप्टेड सामग्री लोड की जा सकती है या नहीं। इसके विपरीत, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/checkpassword/) केवल ओपनिंग पासवर्ड को मान्य करता है। यदि पूर्ण प्रस्तुति पहले से लोड हो चुकी है, तो [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/hi/net/aspose.slides/iprotectionmanager/checkwriteprotection/) अपने प्रोटेक्शन मैनेजर के माध्यम से समान लिखने‑रोकथाम जाँच प्रदान करता है।

उत्पादन परिवेश में, पासवर्ड को लॉग न करें या उन्हें डायग्नोस्टिक संदेशों में शामिल न करें। अनावश्यक पुनः‑पुस्ति जाँच प्रयासों से बचें, और पासवर्ड को मेमोरी में केवल आवश्यक अवधि तक रखें।

{{% alert color="info" title="और देखें" %}}
- [प्रेज़ेंटेशन को पासवर्ड‑सुरक्षित बनाना](/slides/hi/net/password-protected-presentation/)
- [केवल‑पढ़ने योग्य प्रस्तुतियाँ](/slides/hi/net/read-only-presentation/)
- [PowerPoint में डिजिटल हस्ताक्षर](/slides/hi/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या लिखने‑रोकथाम प्रस्तुति को एन्क्रिप्ट करती है?**

नहीं। यह संशोधन को सीमित करती है लेकिन प्रस्तुति की सामग्री को लोड और देखने के लिए उपलब्ध रखती है।

**क्या लिखने‑रोकथाम पासवर्ड को प्रस्तुति खोलने के लिए आवश्यक है?**

नहीं। केवल एक ओपनिंग पासवर्ड एन्क्रिप्टेड प्रस्तुति की सामग्री को लोड करने के लिए आवश्यक है।

**क्या एक प्रस्तुति दोनों ओपनिंग पासवर्ड और लिखने‑रोकथाम पासवर्ड रख सकती है?**

हां। एन्क्रिप्टेड प्रस्तुति को खोलने के लिए लोड विकल्पों के माध्यम से ओपनिंग पासवर्ड प्रदान करें, और संशोधन के अधिकार की आवश्यकता होने पर लिखने‑रोकथाम पासवर्ड को अलग से मान्य करें।