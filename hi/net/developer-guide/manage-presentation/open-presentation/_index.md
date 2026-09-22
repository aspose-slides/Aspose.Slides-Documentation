---
title: .NET में प्रस्तुतियों को खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/net/open-presentation/
keywords:
- PowerPoint खोलें
- प्रस्तुति खोलें
- PPTX खोलें
- PPT खोलें
- ODP खोलें
- प्रस्तुति लोड करें
- PPTX लोड करें
- PPT लोड करें
- ODP लोड करें
- सुरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- .NET
- C#
- Aspose.Slides
description: "C# में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, खोलने के पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for .NET के साथ मेमोरी उपयोग को कम करें, सीखें।"
---
## **परिचय**

[Aspose.Slides for .NET](https://products.aspose.com/slides/hi/net/) फ़ाइलों और स्ट्रीमों से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक बार प्रस्तुति लोड हो जाने के बाद, आप उसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित स्वरूप में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप एक खोलने का पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को प्रबंधित मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुतियों को खोलें**

फ़ाइल या स्ट्रीम को लोड करने के बाद, आप [इसके मूल प्रस्तुति प्रारूप को निर्धारित कर सकते हैं](/slides/hi/net/detect-presentation-source-format/) जिससे आप तय कर सकें कि आपका एप्लिकेशन इसे कैसे प्रोसेस करे।

मौजूदा प्रस्तुति खोलने के लिए, उसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) कन्स्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा, और अन्य संसाधन तुरंत मुक्त हो सकें।

The following C# example shows how to open a presentation and get its slide count:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **पासवर्ड‑संरक्षित प्रस्तुतियों को खोलें**

एक खोलने वाला पासवर्ड प्रस्तुति की सामग्री को एन्क्रिप्ट करता है। संपूर्ण प्रस्तुति को लोड करने के लिए, सही पासवर्ड को [LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) में असाइन करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) कन्स्ट्रक्टर में पास करें। यदि पासवर्ड गायब या गलत है तो लोडिंग विफल हो जाएगी।

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

पासवर्ड पहचान, वैधता, और एन्क्रिप्शन वर्कफ़्लो के लिए, देखें [Password-Protect Presentations](/slides/hi/net/password-protected-presentation/)। यदि एन्क्रिप्टेड प्रस्तुति जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजी गई हो, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/net/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/blobmanagementoptions/) नियंत्रित करता है कि Aspose.Slides बाइनरी बड़े ऑब्जेक्ट्स जैसे छवियां, ऑडियो, और वीडियो को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे गए BLOB डेटा की मात्रा को सीमित कर सकते हैं।

The following C# code demonstrates loading a large presentation (for example, 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior.KeepLocked` के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक `Presentation` ऑब्जेक्ट को डिस्पोज़ नहीं किया जाता। उस ऑब्जेक्ट के जीवित होने के दौरान स्रोत फ़ाइल को न स्थानांतरित करें, न ओवरराइट करें, न हटाएँ।

Aspose.Slides लोडिंग के दौरान इनपुट स्ट्रीम की सामग्री को कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिए, फ़ाइल पथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी‑प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/net/manage-blob/)।
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/resourceloadingcallback/) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iresourceloadingcallback/) कार्यान्वयन को स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को पुनःनिर्देशित कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी चित्र होते हैं जिन्हें एप्लिकेशन‑विशिष्ट सुरक्षा या स्टोरेज नियमों के अनुसार हल किया जाना आवश्यक होता है।

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **एंबेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक प्रस्तुति में एंबेडेड बाइनरी डेटा हो सकता है जिसकी एप्लिकेशन को आवश्यकता नहीं होती या जिसे वह रखना नहीं चाहती। उदाहरण शामिल हैं:

- VBA प्रोजेक्ट्स, उपलब्ध हैं [IPresentation.VbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/vbaproject/) के माध्यम से;
- एंबेडेड OLE डेटा, उपलब्ध हैं [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) के माध्यम से;
- ActiveX कंट्रोल डेटा, उपलब्ध हैं [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/hi/net/aspose.slides/icontrol/activexcontrolbinary/) के माध्यम से।

[LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) को `true` पर सेट करने से लोडिंग के दौरान यह बाइनरी डेटा हटाया जाता है। साफ़ किया गया परिणाम बनाए रखने के लिए लोडेड प्रस्तुति को सहेजें।

यह विकल्प अवांछित एम्बेडेड पेलोड्स के मुखातिब होने को कम करता है, लेकिन यह पूर्ण मैलवेयर‑डिटेक्शन या कंटेंट‑सैनिटाइजेशन सिस्टम नहीं है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जान सकता हूँ कि फ़ाइल दूषित है और नहीं खोली जा सकती?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या फ़ॉर्मेट अपवाद उत्पन्न करता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग ढंग से संभालें ताकि एप्लिकेशन कारण को सटीक रूप से रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स अनुपलब्ध हों तो क्या होता है?**

प्रस्तुति फिर भी लोड हो सकती है, लेकिन रेंडरिंग और निर्यात में फ़ॉन्ट्स को बदल दिया जा सकता है। आप आउटपुट को अधिक पूर्वानुमेय बनाने के लिए [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें](/slides/hi/net/font-substitution/) या [कस्टम फ़ॉन्ट प्रदान करें](/slides/hi/net/custom-font/) कर सकते हैं।

**क्या प्रस्तुति को लोड करने से उसके एम्बेडेड मीडिया भी लोड होते हैं?**

एंबेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को कॉन्फ़िगर किए गए रिसोर्स‑लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थान तक पहुँच नहीं पा रहे हों तो उपलब्ध नहीं हो सकते हैं।