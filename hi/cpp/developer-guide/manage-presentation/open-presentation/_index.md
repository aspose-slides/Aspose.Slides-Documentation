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
description: "C++ में PowerPoint और OpenDocument प्रस्तुतियों को खोलना, खोलने के पासवर्ड प्रदान करना, संसाधन लोडिंग को नियंत्रित करना, और Aspose.Slides for C++ के साथ मेमोरी उपयोग को कम करना सीखें।"
---
## **परिचय**

[Aspose.Slides for C++](https://products.aspose.com/slides/hi/cpp/) फाइलों और स्ट्रीम से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक बार प्रस्तुति लोड हो जाने के बाद, आप इसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों को प्रबंधित कर सकते हैं, और इसे मूल या किसी अन्य समर्थित स्वरूप में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/) क्लास के माध्यम से अनुकूलित किया जा सकता है। उदाहरण के लिए, आप एक खोलने वाला पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुति खोलें**

मौजूदा प्रस्तुति को खोलने के लिए, उसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) कंस्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुति को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधनों को शीघ्रता से मुक्त किया जा सके।

निम्नलिखित C++ उदाहरण दर्शाता है कि प्रस्तुति कैसे खोली जाए और उसकी स्लाइड गिनती कैसे प्राप्त की जाए:

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

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलना**

एक खोलने वाला पासवर्ड प्रस्तुति की सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) को पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) कंस्ट्रक्टर में पास करें। जब पासवर्ड नहीं दिया गया या गलत होता है तो लोडिंग विफल हो जाती है।

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

पासवर्ड पहचान, वैधता, और एन्क्रिप्शन कार्यप्रवाह के लिए, देखें [पासवर्ड-संरक्षित प्रस्तुतियां](/slides/hi/cpp/password-protected-presentation/). यदि एन्क्रिप्टेड प्रस्तुति जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजी गई हो, तो ये गुण पासवर्ड के बिना पढ़े जा सकते हैं; देखें [प्रेजेंटेशन गुण प्रबंधन](/slides/hi/cpp/presentation-properties/).

## **बड़ी प्रस्तुतियों को खोलना**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) नियंत्रित करता है कि Aspose.Slides बाइनरी बड़े ऑब्जेक्ट्स जैसे छवियां, ऑडियो और वीडियो को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे गए BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्नलिखित C++ कोड एक बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) लोड करने का प्रदर्शन करता है:

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
`PresentationLockingBehavior::KeepLocked` के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक `Presentation` ऑब्जेक्ट डिस्पोज़ नहीं किया जाता। उस ऑब्जेक्ट के जीवित रहने के दौरान स्रोत फ़ाइल को न स्थानांतरित करें, न ओवरराइट करें, न ही delete करें।

Aspose.Slides लोड करते समय इनपुट स्ट्रीम की सामग्री कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिए, फ़ाइल पथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त संग्रहण और मेमोरी-प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/cpp/manage-blob/).
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करना**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iresourceloadingcallback/) कार्यान्वयन को स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को पुनर्निर्देशित कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को छोड़ सकता है। यह तब उपयोगी है जब प्रस्तुतियों में बाहरी छवियाँ होती हैं जिन्हें एप्लिकेशन-विशिष्ट सुरक्षा या संग्रह नियमों के अनुसार हल किया जाना चाहिए।

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

## **एंबेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करना**

एक प्रस्तुति में एम्बेडेड बाइनरी डेटा हो सकता है जिसकी एप्लिकेशन को आवश्यकता नहीं है या वह इसे रखना नहीं चाहती। उदाहरण शामिल हैं:
- VBA प्रोजेक्ट्स, जो [IPresentation::get_VbaProject](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_vbaproject/) के माध्यम से उपलब्ध हैं;
- एम्बेडेड OLE डेटा, जो [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) के माध्यम से उपलब्ध है;
- ActiveX कंट्रोल डेटा, जो [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) के माध्यम से उपलब्ध है।

`true` को [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) में पास करके लोडिंग के दौरान इस बाइनरी डेटा को हटाएँ। साफ किया गया परिणाम रखने के लिए लोड की गई प्रस्तुति को सहेजें।

यह विकल्प अनचाहे एम्बेडेड पेलोड्स के संपर्क को कम करता है, लेकिन यह पूर्ण मालवेयर-डिटेक्शन या कंटेंट-सैनिटाइजेशन प्रणाली नहीं है।

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

**मैं कैसे पता करूं कि फ़ाइल भ्रष्ट है और खोली नहीं जा सकती?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या फ़ॉर्मेट एक्सेप्शन फेंकता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग संभालें ताकि एप्लिकेशन कारण को सटीक रूप से रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स अनुपलब्ध हों तो क्या होता है?**

प्रस्तुति अभी भी लोड हो सकती है, लेकिन रेंडरिंग और निर्यात फ़ॉन्ट को प्रतिस्थापित कर सकते हैं। आउटपुट को अधिक पूर्वानुमेय बनाने के लिए आप [configure font substitution](/slides/hi/cpp/font-substitution/) या [provide custom fonts](/slides/hi/cpp/custom-font/) का उपयोग कर सकते हैं।

**क्या प्रस्तुति को लोड करने से उसकी एम्बेडेड मीडिया भी लोड हो जाती है?**

एम्बेडेड ऑडियो और वीडियो प्रस्तुति ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को कॉन्फ़िगर किए गए रिसोर्स-लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थान तक पहुँच नहीं सकी तो वे अनुपलब्ध हो सकते हैं।