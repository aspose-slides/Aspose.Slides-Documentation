---
title: C++ में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/cpp/save-presentation/
keywords:
- PowerPoint सहेजें
- OpenDocument सहेजें
- प्रस्तुति सहेजें
- स्लाइड सहेजें
- PPT सहेजें
- PPTX सहेजें
- ODP सहेजें
- फ़ाइल में प्रस्तुति
- स्ट्रीम में प्रस्तुति
- पूर्वनिर्धारित दृश्य प्रकार
- स्ट्रिक्ट Office Open XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रिफ्रेश करना
- सेविंग प्रोग्रेस
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में प्रस्तुतियों को सहेजने के तरीके खोजें—लेआउट, फ़ॉन्ट और इफेक्ट्स को बरकरार रखते हुए PowerPoint या OpenDocument में निर्यात करें।"
---
## **परिचय**

[Open Presentations in C++](/slides/hi/cpp/open-presentation/) बताता है कि कैसे [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति खोली जाती है। यह लेख बताता है कि कैसे प्रस्तुतियों को बनाया और सहेजा जाता है। [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री होती है। चाहे आप शुरुआत से प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्ति पर उसे सहेजना आवश्यक है। Aspose.Slides for C++ के साथ आप **file** या **stream** में सहेज सकते हैं। यह लेख प्रस्तुतियों को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

एक प्रस्तुति को फ़ाइल में सहेजने के लिए [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की `Save` विधि को कॉल करें। फ़ाइल नाम और सहेजने का फ़ॉर्मेट मेथड को पास करें। निम्न उदाहरण दर्शाता है कि Aspose.Slides के साथ प्रस्तुति कैसे सहेजी जाती है।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// प्रस्तुति फ़ाइल को दर्शाने वाले Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// यहां कुछ काम करें...
// प्रस्तुति को फ़ाइल में सहेजें।
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

आप `Save` मेथड को आउटपुट स्ट्रीम पास करके प्रस्तुति को स्ट्रीम में सहेज सकते हैं। एक प्रस्तुति कई प्रकार की स्ट्रीम में लिखी जा सकती है। नीचे के उदाहरण में, हम नई प्रस्तुति बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// प्रस्तुति फ़ाइल को दर्शाने वाले Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// प्रस्तुति को स्ट्रीम में सहेजें।
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **प्रीडिफाइंड व्यू टाइप के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides आपको उस प्रारंभिक व्यू को सेट करने देता है जिसे PowerPoint उत्पन्न प्रस्तुति खोलते समय उपयोग करता है, [ViewProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/) क्लास के माध्यम से। [set_LastView](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewproperties/set_lastview/) मेथड का उपयोग करके आप [ViewType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/viewtype/) एन्यूमेरेशन से मान सेट कर सकते हैं।

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **स्ट्रिक्ट Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको प्रस्तुति को स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजने की अनुमति देता है। सहेजते समय आप [PptxOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pptxoptions/) क्लास का उपयोग करके उसकी conformance प्रॉपर्टी सेट कर सकते हैं। यदि आप `Conformance.Iso29500_2008_Strict` सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजी जाएगी।

नीचे का उदाहरण एक प्रस्तुति बनाता है और उसे स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// प्रस्तुति फ़ाइल को दर्शाने वाले Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// प्रस्तुति को स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजें।
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Office Open XML फ़ॉर्मेट में Zip64 मोड के साथ प्रस्तुतियों को सहेजें**

Office Open XML फ़ाइल एक ZIP आर्काइव होती है जो किसी भी फ़ाइल के अनकम्प्रेस्ड आकार, कम्प्रेस्ड आकार, और आर्काइव के कुल आकार पर 4 GB (2^32 बाइट) की सीमा लगाती है, तथा आर्काइव में अधिकतम 65 535 (2^16‑1) फ़ाइलें हो सकती हैं। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ा देते हैं।

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) मेथड आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन कब उपयोग करने हैं, चुनने देता है।

यह मेथड निम्न मोड्स के साथ उपयोग किया जा सकता है:

- `IfNecessary` केवल तब ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग करता है जब प्रस्तुति उपर्युक्त सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- `Never` कभी भी ZIP64 फ़ॉर्मेट एक्सटेंशन नहीं उपयोग करता।
- `Always` हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग करता है।

नीचे का कोड दर्शाता है कि कैसे ZIP64 फ़ॉर्मेट एक्सटेंशन सक्षम करके प्रस्तुति को PPTX फ़ाइल के रूप में सहेजा जाए:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
जब आप `Zip64Mode.Never` के साथ सहेजते हैं, तो यदि प्रस्तुति को ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता है, तो एक [PptxException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxexception/) अपवाद फेंका जाता है।
{{% /alert %}}

## **संकुचन स्तरों के साथ Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

बड़ी प्रस्तुतियों के साथ काम करते समय आप फ़ाइल आकार और प्रोसेसिंग समय के बीच संतुलन बनाए रखने के लिए संकुचन स्तर को समायोजित कर सकते हैं। आपकी आवश्यकताओं के अनुसार आप तेज़ प्रोसेसिंग या छोटे आउटपुट फ़ाइलों को प्राथमिकता दे सकते हैं।

Aspose.Slides [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) मेथड प्रदान करता है, जो Office Open XML फ़ॉर्मेट में प्रस्तुति सहेजते समय उपयोग किए जाने वाले संकुचन स्तर को निर्दिष्ट करता है।

निम्नलिखित संकुचन स्तर उपलब्ध हैं:

- **None**: कोई संकुचन लागू नहीं किया जाता। फ़ाइलें जैसा है वैसी ही संग्रहीत रहती हैं।
- **Level1**: सबसे तेज़ संकुचन, सबसे कम संकुचन अनुपात के साथ।
- **Level2**: **Level1** से थोड़ा बेहतर संकुचन अनुपात के साथ तेज़ संकुचन।
- **Level3**: **Level2** से बेहतर संकुचन प्रदान करता है, प्रोसेसिंग समय पर मध्यम प्रभाव के साथ।
- **Level4**: **Level3** से बेहतर संकुचन प्रदान करता है।
- **Level5**: **Level4** से सुधारित संकुचन, अतिरिक्त प्रोसेसिंग समय के साथ।
- **Level6**: मानक संकुचन जो प्रोसेसिंग गति और फ़ाइल आकार के बीच अच्छा संतुलन देता है। यह *डिफ़ॉल्ट संकुचन स्तर* है।
- **Level7**: **Level6** से बेहतर संकुचन, धीमी प्रोसेसिंग के साथ।
- **Level8**: **Level7** से बेहतर संकुचन।
- **Level9**: अधिकतम संकुचन। सबसे छोटा फ़ाइल आकार देता है, लेकिन सबसे लंबी प्रोसेसिंग समय पर।

निम्न उदाहरण दर्शाता है कि कैसे प्रस्तुति को PPTX फ़ाइल के रूप में *बिना संकुचन* सहेजा जाए:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

यह उदाहरण दर्शाता है कि कैसे प्रस्तुति को PPTX फ़ाइल के रूप में *अधिकतम संकुचन* के साथ सहेजा जाए:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **थंबनेल रिफ्रेश किए बिना प्रस्तुतियों को सहेजें**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) मेथड PPTX में प्रस्तुति सहेजते समय थंबनेल जनरेशन को नियंत्रित करता है:

- यदि इसे `true` सेट किया जाता है, तो सहेजते समय थंबनेल रिफ्रेश किया जाता है। यह डिफ़ॉल्ट है।
- यदि इसे `false` सेट किया जाता है, तो मौजूदा थंबनेल बरकरार रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो कोई थंबनेल जेनरेट नहीं होगा।

नीचे के कोड में, प्रस्तुति को थंबनेल रिफ्रेश किए बिना PPTX में सहेजा गया है।

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति सहेजने के समय को कम करने में मदद करता है।
{{% /alert %}}

## **सहेजने की प्रगति अपडेट प्रतिशत में**

[IProgressCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprogresscallback/) इंटरफ़ेस का उपयोग [ISaveOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/isaveoptions/) तथा [SaveOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveoptions/) के द्वारा `set_ProgressCallback` मेथड के माध्यम से किया जाता है। `set_ProgressCallback` के साथ एक [IProgressCallback](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprogresscallback/) कार्यान्वयन असाइन करके आप सहेजने की प्रगति को प्रतिशत में प्राप्त कर सकते हैं।

निम्न कोड स्निपेट्स दर्शाते हैं कि `IProgressCallback` का उपयोग कैसे किया जाता है।

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // यहाँ प्रगति प्रतिशत मान का उपयोग करें।
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ऊपर परिभाषित प्रोग्रेस कॉलबैक क्लास।
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose ने एक [free PowerPoint Splitter app](https://products.aspose.app/slides/hi/splitter) अपने API का उपयोग करके बनाया है। यह ऐप चयनित स्लाइड्स को नए PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करने देता है।
{{% /alert %}}

## **FAQ**

**क्या "फास्ट सेव" (इन्क्रिमेंटल सेव) समर्थित है जिससे केवल परिवर्तन लिखे जाएँ?**

नहीं। सहेजने पर हर बार पूर्ण लक्षित फ़ाइल बनाई जाती है; इन्क्रिमेंटल "फास्ट सेव" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को कई थ्रेड्स से सहेजना थ्रेड-सुरक्षित है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस [थ्रेड-सुरक्षित नहीं है](/slides/hi/cpp/multithreading/); इसे एक ही थ्रेड से सहेजें।

**सहेजते समय हायपरलिंक्स और बाहरी लिंक्ड फ़ाइलों का क्या होता है?**

[Hyperlinks](/slides/hi/cpp/manage-hyperlinks/) बरकरार रहते हैं। बाहरी लिंक्ड फ़ाइलें (जैसे रिलेटिव पाथ वाली वीडियो) स्वचालित रूप से कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ्स उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडेटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सेव कर सकता हूँ?**

हां। मानक [document properties](/slides/hi/cpp/presentation-properties/) समर्थित हैं और सहेजने पर फ़ाइल में लिखे जाएंगे।