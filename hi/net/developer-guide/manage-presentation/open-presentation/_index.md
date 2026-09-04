---
title: ".NET में प्रस्तुतियों को खोलें"
linktitle: "प्रस्तुति खोलें"
type: docs
weight: 20
url: /hi/net/open-presentation/
keywords:
- "PowerPoint खोलें"
- "प्रस्तुति खोलें"
- "PPTX खोलें"
- "PPT खोलें"
- "ODP खोलें"
- "प्रस्तुति लोड करें"
- "PPTX लोड करें"
- "PPT लोड करें"
- "ODP लोड करें"
- "सुरक्षित प्रस्तुति"
- "बड़ी प्रस्तुति"
- "बाहरी संसाधन"
- "बाइनरी ऑब्जेक्ट"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "C# में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, खोलने के पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for .NET के साथ मेमोरी उपयोग को कम करें, यह जानें।"
---
## **परिचय**

[Aspose.Slides for .NET](https://products.aspose.com/slides/hi/net/) फ़ाइलों और स्ट्रीमों से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक बार प्रस्तुति लोड हो जाने के बाद, आप उसकी संरचना का निरीक्षण, स्लाइड्स का संपादन, संसाधनों का प्रबंधन, और मूल या किसी अन्य समर्थित फ़ॉर्मेट में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप खोलने का पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को प्रबंधित मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुति खोलें**

मौजूदा प्रस्तुति को खोलने के लिए, उसकी फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) कन्स्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा, और अन्य संसाधन तुरंत मुक्त हो जाएँ।

निम्न C# उदाहरण दिखाता है कि प्रस्तुति को कैसे खोलें और उसके स्लाइडों की संख्या प्राप्त करें:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **पासवर्ड‑सुरक्षित प्रस्तुतियों को खोलें**

एक खोलने वाला पासवर्ड प्रस्तुति की सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) में सेट करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) कन्स्ट्रक्टर में पास करें। पासवर्ड न होने या गलत होने पर लोडिंग विफल हो जाएगी।

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

पासवर्ड पहचान, वैधता जाँच, और एन्क्रिप्शन कार्यप्रवाहों के लिए देखें [Password‑Protect Presentations](/slides/hi/net/password-protected-presentation/)। यदि एन्क्रिप्टेड प्रस्तुति को जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया है, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/net/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/blobmanagementoptions/) नियंत्रित करता है कि Aspose.Slides छवियों, ऑडियो, और वीडियो जैसे बाइनरी बड़े ऑब्जेक्ट्स को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्न C# कोड बड़ी प्रस्तुति (उदाहरण के लिये 2 GB) को लोड करने का प्रदर्शन करता है:

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
`PresentationLockingBehavior.KeepLocked` के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक `Presentation` ऑब्जेक्ट डिस्पोज़ न हो जाए। उस ऑब्जेक्ट के जीवित रहने के दौरान स्रोत फ़ाइल को स्थानांतरित, ओवरराइट या डिलीट न करें।

Aspose.Slides लोड करने के दौरान इनपुट स्ट्रीम की सामग्री की कॉपी बना सकता है। बड़ी प्रस्तुतियों के लिए फ़ाइल पथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी‑प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/net/manage-blob/)।
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/resourceloadingcallback/) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iresourceloadingcallback/) कार्यान्वयन स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को पुनःनिर्देशित कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी चित्र होते हैं जिन्हें एप्लिकेशन‑विशिष्ट सुरक्षा या स्टोरेज नियमों के अनुसार हल करना आवश्यक होता है।

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

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

किसी प्रस्तुति में एम्बेडेड बाइनरी डेटा हो सकता है जिसे एप्लिकेशन को आवश्यकता नहीं होती या नहीं रखना चाहता। उदाहरणों में शामिल हैं:

- VBA प्रोजेक्ट्स, जो [IPresentation.VbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/vbaproject/) के माध्यम से उपलब्ध हैं;
- एम्बेडेड OLE डेटा, जो [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) के माध्यम से उपलब्ध है;
- ActiveX कंट्रोल डेटा, जो [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/hi/net/aspose.slides/icontrol/activexcontrolbinary/) के माध्यम से उपलब्ध है।

लोडिंग के दौरान यह बाइनरी डेटा हटाने के लिए [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) को `true` सेट करें। संशोधित परिणाम को सहेजने के लिए लोड की गई प्रस्तुति को सहेजें।

यह विकल्प अनचाहे एम्बेडेड पेलोड्स के संपर्क को कम करता है, लेकिन यह पूर्ण मालवेयर‑डिटेक्शन या कंटेंट‑सैनीटाइज़ेशन प्रणाली नहीं है।

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

**मैं कैसे पता करूँ कि फ़ाइल क्षतिग्रस्त है और नहीं खोली जा सकती?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या फ़ॉर्मेट अपवाद फेंकता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग रूप से हैंडल करें ताकि अनुप्रयोग कारण को सटीक रूप से रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट नहीं मिलते तो क्या होता है?**

प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और निर्यात फ़ॉन्ट प्रतिस्थापन कर सकते हैं। आप आउटपुट को अधिक भविष्यवाणी योग्य बनाने के लिए [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर](/slides/hi/net/font-substitution/) कर सकते हैं या [कस्टम फ़ॉन्ट प्रदान](/slides/hi/net/custom-font/) कर सकते हैं।

**क्या प्रस्तुति लोड करने से उसकी एम्बेडेड मीडिया भी लोड हो जाती है?**

एम्बेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधन कॉन्फ़िगर किए गए संसाधन‑लोडिंग व्यवहार के अनुसार हल किए जाते हैं और यदि उनके स्थान तक पहुंच नहीं मिलती तो अनुपलब्ध रह सकते हैं।