---
title: C++ में प्रस्तुतियों को खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/cpp/open-presentation/
keywords:
- PowerPoint खोलें
- OpenDocument खोलें
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint (.pptx, .ppt) और OpenDocument (.odp) प्रस्तुतियों को आसानी से खोलें—तेज़, विश्वसनीय, पूरी तरह से सुविधाजनक।"
---
## **परिचय**

शुरुआत से PowerPoint प्रस्तुतियाँ बनाने के अलावा, Aspose.Slides आपको मौजूदा प्रस्तुतियों को खोलने की भी अनुमति देता है। एक प्रस्तुति लोड करने के बाद, आप उसके बारे में जानकारी प्राप्त कर सकते हैं, स्लाइड सामग्री को संपादित कर सकते हैं, नई स्लाइडें जोड़ सकते हैं, मौजूदा स्लाइडें हटा सकते हैं, और भी बहुत कुछ।

## **प्रस्तुतियों को खोलें**

किसी मौजूदा प्रस्तुति को खोलने के लिए, [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और उसके कन्स्ट्रक्टर को फ़ाइल पथ पास करें।

निम्नलिखित C++ उदाहरण दर्शाता है कि प्रस्तुति कैसे खोली जाए और उसकी स्लाइड गिनती कैसे प्राप्त की जाए:

```cpp
// Presentation क्लास का उदाहरण बनाएं और उसके कन्स्ट्रक्टर में फ़ाइल पथ पास करें।
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// प्रस्तुति में कुल स्लाइडों की संख्या प्रिंट करें।
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

जब आपको पासवर्ड-संरक्षित प्रस्तुति खोलनी हो, तो इसे डिक्रिप्ट और लोड करने के लिए पासवर्ड को [LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/) क्लास की [set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) मेथड के माध्यम से पास करें। निम्नलिखित C++ कोड इस संचालन को दर्शाता है:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
    // डिक्रिप्टेड प्रस्तुति पर कार्य करें।

presentation->Dispose();
```

## **बड़ी प्रस्तुतियों को खोलें**

Aspose.Slides विकल्प प्रदान करता है—विशेष रूप से [LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/) क्लास में [get_BlobManagementOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) मेथड—जो बड़े प्रस्तुतियों को लोड करने में आपकी मदद करता है।

निम्नलिखित C++ कोड बड़े प्रस्तुति को लोड करने को प्रदर्शित करता है (उदाहरण के लिए, 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// KeepLocked व्यवहार चुनें—प्रेज़ेंटेशन फ़ाइल जीवनकाल तक लॉक रहेगी
// प्रेज़ेंटेशन इंस्टेंस, लेकिन इसे मेमोरी में लोड करने या अस्थायी फ़ाइल में कॉपी करने की आवश्यकता नहीं है।
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// बड़ी प्रेज़ेंटेशन लोड हो गई है और उपयोग की जा सकती है, जबकि मेमोरी उपयोग कम रहता है.

// प्रेज़ेंटेशन में बदलाव करें।
presentation->get_Slide(0)->set_Name(u"Large presentation");

// प्रेज़ेंटेशन को किसी अन्य फ़ाइल में सहेजें। इस ऑपरेशन के दौरान मेमोरी उपयोग कम रहता है।
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// यह न करें! एक I/O अपवाद फेंका जाएगा क्योंकि फ़ाइल तब तक लॉक रहती है जब तक प्रेज़ेंटेशन ऑब्जेक्ट डिस्पोज़ नहीं हो जाता।
File::Delete(filePath);

presentation->Dispose();

// यहाँ करने में कोई समस्या नहीं है। स्रोत फ़ाइल अब प्रेज़ेंटेशन ऑब्जेक्ट द्वारा लॉक नहीं रह गई है।
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
स्ट्रीम के साथ काम करते समय कुछ सीमाओं को दूर करने के लिए, Aspose.Slides स्ट्रीम की सामग्री की प्रतिलिपि बना सकता है। एक स्ट्रीम से बड़ी प्रस्तुति लोड करने से प्रस्तुति की प्रतिलिपि बनती है और लोडिंग धीमी हो सकती है। इसलिए, जब आपको बड़ी प्रस्तुति लोड करनी हो, तो हम दृढ़ता से सुझाव देते हैं कि स्ट्रीम के बजाय प्रस्तुति फ़ाइल पथ का उपयोग करें।

जब आप ऐसी प्रस्तुति बना रहे हैं जिसमें बड़े वस्तुएँ (वीडियो, ऑडियो, हाई‑रिज़ॉल्यूशन छवियाँ आदि) शामिल हों, तो आप मेमोरी खपत कम करने के लिए [BLOB management](/slides/hi/cpp/manage-blob/) का उपयोग कर सकते हैं।
{{%/alert %}}

## **बाह्य संसाधनों को नियंत्रित करें**

Aspose.Slides वह [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iresourceloadingcallback/) इंटरफ़ेस प्रदान करता है जो आपको बाहरी संसाधनों को प्रबंधित करने देता है। निम्नलिखित C++ कोड दर्शाता है कि `IResourceLoadingCallback` इंटरफ़ेस का कैसे उपयोग किया जाए:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // प्रतिस्थापित छवि लोड करें।
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // प्रतिस्थापित URL सेट करें।
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // सभी अन्य छवियों को छोड़ें।
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **बिना एम्बेडेड बाइनरी ऑब्जेक्ट्स के प्रस्तुतियों को लोड करें**

एक PowerPoint प्रस्तुति में निम्न प्रकार के एम्बेडेड बाइनरी ऑब्जेक्ट्स हो सकते हैं:
- VBA प्रोजेक्ट (जिसे [IPresentation::get_VbaProject](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_vbaproject/) के माध्यम से पहुँचा जा सकता है);
- OLE ऑब्जेक्ट एम्बेडेड डेटा (जिसे [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) के माध्यम से पहुँचा जा सकता है);
- ActiveX कंट्रोल बाइनरी डेटा (जिसे [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) के माध्यम से पहुँचा जा सकता है)।

[ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) मेथड का उपयोग करके, आप प्रस्तुति को बिना किसी एम्बेडेड बाइनरी ऑब्जेक्ट के लोड कर सकते हैं।

यह मेथड संभावित दुर्भावनापूर्ण बाइनरी सामग्री को हटाने के लिए उपयोगी है। निम्नलिखित C++ कोड दिखाता है कि कैसे प्रस्तुति को बिना किसी एम्बेडेड बाइनरी सामग्री के लोड किया जाए:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि फ़ाइल भ्रष्ट है और नहीं खुल रही है?**

लोडिंग के दौरान आपको पार्सिंग/फ़ॉर्मेट वैलिडेशन अपवाद मिलेगा। ऐसे त्रुटियों में अक्सर अमान्य ZIP संरचना या टूटे हुए PowerPoint रिकॉर्ड का उल्लेख होता है।

**यदि खोलते समय आवश्यक फ़ॉन्ट्स गायब हों तो क्या होता है?**

फ़ाइल खुल जाएगी, लेकिन बाद में [rendering/export](/slides/hi/cpp/convert-presentation/) फ़ॉन्ट्स को प्रतिस्थापित कर सकता है। रनटाइम पर्यावरण में [Configure font substitutions](/slides/hi/cpp/font-substitution/) या [add the required fonts](/slides/hi/cpp/custom-font/) जोड़ें।

**खोलते समय एम्बेडेड मीडिया (वीडियो/ऑडियो) के बारे में क्या?**

वे प्रस्तुति संसाधनों के रूप में उपलब्ध हो जाते हैं। यदि मीडिया बाहरी पथों के माध्यम से संदर्भित हैं, तो सुनिश्चित करें कि ये पथ आपके पर्यावरण में उपलब्ध हों; अन्यथा [rendering/export](/slides/hi/cpp/convert-presentation/) मीडिया को छोड़ सकता है।