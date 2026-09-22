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
- सुरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- C++
- Aspose.Slides
description: "C++ में PowerPoint और OpenDocument प्रस्तुतियों को खोलना, खोलने के पासवर्ड प्रदान करना, संसाधन लोडिंग को नियंत्रित करना, और Aspose.Slides for C++ के साथ मेमोरी उपयोग को कम करना सीखें।"
---
## **परिचय**

[Aspose.Slides for C++](https://products.aspose.com/slides/hi/cpp/) फाइलों और स्ट्रीम्स से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक प्रस्तुति लोड होने के बाद, आप उसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और उसे मूल या किसी अन्य समर्थित प्रारूप में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप खोलने का पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुति खोलें**

फ़ाइल या स्ट्रीम लोड होने के बाद, आप अपनी एप्लिकेशन को यह निर्धारित करने के लिए [determine its original presentation format](/slides/hi/cpp/detect-presentation-source-format/) का उपयोग कर सकते हैं कि उसे कैसे प्रोसेस किया जाए।

मौजूदा प्रस्तुति खोलने के लिए, उसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) कन्स्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधन तुरंत मुक्त हो जाएँ।

निम्न C++ उदाहरण दिखाता है कि प्रस्तुति को कैसे खोलें और उसकी स्लाइड गिनती प्राप्त करें:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **पासवर्ड-प्रोटेक्टेड प्रस्तुतियों को खोलें**

एक खोलने वाला पासवर्ड प्रस्तुति सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) में पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) कन्स्ट्रक्टर में पास करें। पासवर्ड गायब या गलत होने पर लोडिंग विफल हो जाती है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

पासवर्ड पहचान, वैधता और एन्क्रिप्शन कार्यप्रवाह के लिए देखें [Password-Protect Presentations](/slides/hi/cpp/password-protected-presentation/)। यदि एक एन्क्रिप्टेड प्रस्तुति को जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया है, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/cpp/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) नियंत्रित करता है कि Aspose.Slides बाइनरी बड़े ऑब्जेक्ट्स जैसे इमेज, ऑडियो और वीडियो को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में बनाए रखने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्न C++ कोड दिखाता है कि बड़ी प्रस्तुति (उदाहरण के लिए 2 GB) को कैसे लोड किया जाता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior::KeepLocked` के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक `Presentation` ऑब्जेक्ट डिस्पोज़ नहीं हो जाता। उस ऑब्जेक्ट के जीवित रहने के दौरान स्रोत फ़ाइल को स्थानांतरित, ओवरराइट या डिलीट न करें।

Aspose.Slides इनपुट स्ट्रीम की सामग्री को लोड करते समय कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिए फ़ाइल पाथ आमतौर पर स्ट्रीम से अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी‑प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/cpp/manage-blob/)।
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iresourceloadingcallback/) कार्यान्वयन को स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, एक संसाधन को पुनर्निर्देशित कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी इमेजेज़ होते हैं जिन्हें एप्लिकेशन‑विशिष्ट सुरक्षा या स्टोरेज नियमों के अनुसार हल करना आवश्यक होता है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक प्रस्तुति में एम्बेडेड बाइनरी डेटा हो सकता है जिसे एप्लिकेशन को आवश्यक नहीं होता या वह नहीं रखना चाहता। उदाहरणों में शामिल हैं:

- VBA प्रोजेक्ट्स, जो [IPresentation::get_VbaProject](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_vbaproject/) के माध्यम से उपलब्ध हैं;
- एम्बेडेड OLE डेटा, जो [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) के माध्यम से उपलब्ध है;
- ActiveX नियंत्रण डेटा, जो [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) के माध्यम से उपलब्ध है।

लोडिंग के दौरान इस बाइनरी डेटा को हटाने के लिए [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) को `true` सेट करें। लोड की गई प्रस्तुति को सहेजें ताकि स्वच्छ परिणाम सुरक्षित रहे।

यह विकल्प अनपेक्षित एम्बेडेड पेलोड के एक्सपोज़र को कम करता है, लेकिन यह पूरी तरह से मालवेयर‑डिटेक्शन या कंटेंट‑सैनिटाइज़ेशन प्रणाली नहीं है।

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि फ़ाइल क्षतिग्रस्त है और नहीं खोली जा सकती?**

Aspose.Slides लोडिंग के दौरान एक पार्सिंग या फ़ॉर्मेट अपवाद फेंकता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग ढंग से हैंडल करें ताकि एप्लिकेशन कारण को सही‑से‑सही रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स अनुपलब्ध हों तो क्या होगा?**

प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और एक्सपोर्ट फ़ॉन्ट प्रतिस्थापन का उपयोग कर सकते हैं। आप [configure font substitution](/slides/hi/cpp/font-substitution/) या [provide custom fonts](/slides/hi/cpp/custom-font/) कर सकते हैं ताकि आउटपुट अधिक भविष्यवाणी योग्य हो।

**क्या प्रस्तुति लोड करने से उसके एम्बेडेड मीडिया भी लोड होते हैं?**

एम्बेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधन कॉन्फ़िगर किए गए रिसोर्स‑लोडिंग व्यवहार के अनुसार हल होते हैं और यदि उनके स्थानों तक पहुँच नहीं पाते तो अनुपलब्ध रह सकते हैं।