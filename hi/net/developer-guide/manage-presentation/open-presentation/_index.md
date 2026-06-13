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
- संरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint (.pptx, .ppt) और OpenDocument (.odp) प्रस्तुतियों को आसानी से खोलें—तेज़, विश्वसनीय, पूर्ण सुविधाओं वाला।"
---
## **परिचय**

शुरू से PowerPoint प्रस्तुतियों को बनाने के अलावा, Aspose.Slides आपको मौजूदा प्रस्तुतियों को खोलने की भी सुविधा देता है। एक प्रस्तुति लोड करने के बाद, आप इसके बारे में जानकारी प्राप्त कर सकते हैं, स्लाइड सामग्री को संपादित कर सकते हैं, नई स्लाइड जोड़ सकते हैं, मौजूदा स्लाइड्स को हटाना आदि कर सकते हैं।

## **प्रस्तुतियां खोलें**

एक मौजूदा प्रस्तुति खोलने के लिए, [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) वर्ग को इंस्टैंसिएट करें और फ़ाइल पथ को उसके कन्स्ट्रक्टर में पास करें।

निम्नलिखित C# उदाहरण दर्शाता है कि प्रस्तुति कैसे खोलें और उसकी स्लाइड गिनती प्राप्त करें:

```cs
// Presentation क्लास का इंस्टैंस बनाएं और इसके कंस्ट्रक्टर को फ़ाइल पथ पास करें।
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // प्रस्तुति में कुल स्लाइड्स की संख्या प्रिंट करें।
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

जब आपको पासवर्ड-संरक्षित प्रस्तुति खोलनी हो, तो [Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) प्रॉपर्टी को [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) वर्ग के माध्यम से पासवर्ड प्रदान करके इसे डिक्रिप्ट और लोड कर सकते हैं। निम्नलिखित C# कोड इस ऑपरेशन को दर्शाता है:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // डिक्रिप्टेड प्रस्तुति पर संचालन करें।
}
```

## **बड़ी प्रस्तुतियों को खोलें**

Aspose.Slides विकल्प प्रदान करता है—विशेषतः [BlobManagementOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/blobmanagementoptions/) प्रॉपर्टी को [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) वर्ग में—जो आपको बड़ी प्रस्तुतियों को लोड करने में मदद करती है।

निम्नलिखित C# कोड बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) को लोड करने का प्रदर्शन करता है:

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // KeepLocked व्यवहार चुनें—प्रेज़ेंटेशन फ़ाइल जीवनकाल तक लॉक रहेगी 
        // प्रेज़ेंटेशन इंस्टेंस तक, लेकिन इसे मेमोरी में लोड करने या अस्थायी फ़ाइल में कॉपी करने की आवश्यकता नहीं है।
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // बड़ी प्रस्तुति लोड हो गई है और उपयोग की जा सकती है, जबकि मेमोरी उपभोग कम रहता है।

    // प्रस्तुति में परिवर्तन करें।
    presentation.Slides[0].Name = "Large presentation";

    // प्रस्तुति को दूसरी फ़ाइल में सहेजें। इस संचालन के दौरान मेमोरी उपभोग कम रहता है।
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // ऐसा न करें! एक I/O अपवाद फेंका जाएगा क्योंकि फ़ाइल तब तक लॉक रहती है जब तक प्रेज़ेंटेशन ऑब्जेक्ट डिस्पोज़ नहीं हो जाता।
    File.Delete(filePath);
}

// यहाँ इसे करना ठीक है। स्रोत फ़ाइल अब प्रेज़ेंटेशन ऑब्जेक्ट द्वारा लॉक नहीं है।
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
स्ट्रीम के साथ काम करते समय कुछ सीमाओं को दूर करने के लिए, Aspose.Slides स्ट्रीम की सामग्री को कॉपी कर सकता है। स्ट्रीम से बड़ी प्रस्तुति लोड करने से प्रस्तुति कॉपी हो जाती है और लोडिंग धीमी हो सकती है। इसलिए, जब आपको बड़ी प्रस्तुति लोड करनी हो, तो हम दृढ़ता से अनुशंसा करते हैं कि स्ट्रीम के बजाय प्रस्तुति फ़ाइल पथ का उपयोग करें।

जब आप ऐसी प्रस्तुति बना रहे हैं जिसमें बड़े ऑब्जेक्ट (वीडियो, ऑडियो, हाई-रिज़ॉल्यूशन इमेजेज आदि) होते हैं, तो आप मेमोरी उपयोग को कम करने के लिए [BLOB management](/slides/hi/net/manage-blob/) का उपयोग कर सकते हैं।
{{%/alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iresourceloadingcallback/) इंटरफ़ेस प्रदान करता है जो आपको बाहरी संसाधनों को प्रबंधित करने की अनुमति देता है। निम्नलिखित C# कोड `IResourceLoadingCallback` इंटरफ़ेस का उपयोग कैसे करें, दर्शाता है:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // एक वैकल्पिक इमेज लोड करें।
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // एक वैकल्पिक URL सेट करें।
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // सभी अन्य इमेजेस को छोड़ें।
        return ResourceLoadingAction.Skip;
    }
}
```

## **एंबेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक PowerPoint प्रस्तुति में निम्नलिखित प्रकार के एंबेडेड बाइनरी ऑब्जेक्ट्स हो सकते हैं:

- VBA प्रोजेक्ट (जिसे [IPresentation.VbaProject](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/vbaproject/) के माध्यम से पहुँचा जा सकता है);
- OLE ऑब्जेक्ट एंबेडेड डेटा (जिसे [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/hi/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) के माध्यम से पहुँचा जा सकता है);
- ActiveX कंट्रोल बाइनरी डेटा (जिसे [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/hi/net/aspose.slides/icontrol/activexcontrolbinary/) के माध्यम से पहुँचा जा सकता है).

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) प्रॉपर्टी का उपयोग करके, आप प्रस्तुति को बिना किसी एंबेडेड बाइनरी ऑब्जेक्ट के लोड कर सकते हैं।

यह प्रॉपर्टी संभावित दुर्भावनापूर्ण बाइनरी कंटेंट को हटाने के लिए उपयोगी है। निम्नलिखित C# कोड बिना किसी एंबेडेड बाइनरी कंटेंट के प्रस्तुति को लोड करने का प्रदर्शन करता है:

```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // प्रस्तुति पर संचालन करें।
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि फ़ाइल भ्रष्ट है और नहीं खोली जा सकती?**

लोड के दौरान आपको पार्सिंग/फ़ॉर्मेट वैलिडेशन एक्सेप्शन मिलेगा। ऐसे त्रुटियों में अक्सर एक अमान्य ZIP संरचना या टूटे हुए PowerPoint रिकॉर्ड्स का उल्लेख होता है।

**खोलते समय आवश्यक फ़ॉन्ट्स अनुपलब्ध हों तो क्या होता है?**

फ़ाइल खुल जाएगी, लेकिन बाद में [rendering/export](/slides/hi/net/convert-presentation/) फ़ॉन्ट्स को बदल सकता है। रनटाइम वातावरण में [Configure font substitutions](/slides/hi/net/font-substitution/) या [add the required fonts](/slides/hi/net/custom-font/)।

**खोलते समय एंबेडेड मीडिया (वीडियो/ऑडियो) के बारे में क्या?**

वे प्रस्तुति संसाधनों के रूप में उपलब्ध हो जाते हैं। यदि मीडिया को बाहरी पथों के माध्यम से संदर्भित किया गया है, तो सुनिश्चित करें कि ये पथ आपके वातावरण में सुलभ हों; नहीं तो [rendering/export](/slides/hi/net/convert-presentation/) मीडिया को छोड़ सकता है।