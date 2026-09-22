---
title: C++ में मूल प्रस्तुति फ़ॉर्मेट निर्धारित करें
linktitle: स्रोत फ़ॉर्मेट
type: docs
weight: 35
url: /hi/cpp/detect-presentation-source-format/
keywords:
- स्रोत फ़ॉर्मेट
- प्रस्तुति फ़ॉर्मेट का पता लगाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ C++ में लोड की गई प्रस्तुति के मूल फ़ॉर्मेट को पढ़ें, पहचान API की तुलना करें, और फ़ाइलें, स्ट्रीम और लेगेसी फ़ॉर्मेट को संभालें।"
---
## **अवलोकन**

एक प्रस्तुति लोड करने के बाद, इसका मूल फ़ॉर्मेट निर्धारित करने के लिए [Presentation::get_SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_sourceformat/) को कॉल करें। यह मेथड [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_sourceformat/) के माध्यम से भी उपलब्ध है। इसका उपयोग तब करें जब अगले प्रोसेसिंग को वर्तमान इंस्टेंस के लोड किए गए फ़ॉर्मेट पर निर्भरता हो।

स्रोत फ़ॉर्मेट आउटपुट फ़ाइल के लिए चयनित [SaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) से अलग होता है। किसी अन्य फ़ॉर्मेट में सहेजने से मौजूदा इंस्टेंस के स्रोत फ़ॉर्मेट में परिवर्तन नहीं होता।

## **फ़ाइल का स्रोत फ़ॉर्मेट पढ़ें**

यह उदाहरण एक मौजूदा `sample.pptx` फ़ाइल की आवश्यकता रखता है। यह फ़ाइल को लोड करता है और फ़ाइलनाम के बजाय [Presentation::get_SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_sourceformat/) का उपयोग करके अनुप्रयोग प्रोसेसिंग नीति चुनता है। अन्य फ़ॉर्मेट आज़माने के लिए इनपुट पथ बदलें। उदाहरण चयनित नीति को प्रिंट करता है; संदेशों को अपने अनुप्रयोग तर्क से बदलें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **समर्थित मानों को पहचानें**

[SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sourceformat/) एनीमरेशन निम्नलिखित प्रस्तुति फ़ॉर्मेट को अलग करता है। नीचे दिए गए एक्सटेंशन सामान्य एक्सटेंशन हैं, मूल फ़ाइल नाम का पुनर्निर्माण नहीं हैं।

| SourceFormat मान | एक्सटेंशन | फ़ॉर्मेट |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 प्रस्तुति |
| `Pptx` | `.pptx` | Office Open XML प्रस्तुति |
| `Pptm` | `.pptm` | मैक्रो-सक्षम Office Open XML प्रस्तुति |
| `Pps` | `.pps` | PowerPoint 97–2003 स्लाइड शो |
| `Ppsx` | `.ppsx` | Office Open XML स्लाइड शो |
| `Ppsm` | `.ppsm` | मैक्रो-सक्षम Office Open XML स्लाइड शो |
| `Pot` | `.pot` | PowerPoint 97–2003 टेम्पलेट |
| `Potx` | `.potx` | Office Open XML टेम्पलेट |
| `Potm` | `.potm` | मैक्रो-सक्षम Office Open XML टेम्पलेट |
| `Odp` | `.odp` | OpenDocument प्रस्तुति |
| `Otp` | `.otp` | OpenDocument प्रस्तुति टेम्पलेट |
| `Fodp` | `.fodp` | फ्लैट XML ODF प्रस्तुति |
| `Xml` | `.xml` | PowerPoint XML प्रस्तुति |

## **स्ट्रीम का स्रोत फ़ॉर्मेट पढ़ें**

यह उदाहरण एक मौजूदा `sample.pps` फ़ाइल की आवश्यकता रखता है। उसके बाइट्स को मेमोरी स्ट्रीम में पढ़ना ऐसे इनपुट का मॉडल बनाता है जो फ़ाइलनाम के बिना प्राप्त किया गया है, जैसे डेटाबेस मान या अपलोड किया गया बाइट एरे। [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) कंस्ट्रक्टर केवल स्ट्रीम प्राप्त करता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS, और POT एक ही बाइनरी फ़ॉर्मेट का उपयोग करते हैं। फ़ाइल पथ से लोड करते समय, एक्सटेंशन स्लाइड शो या टेम्पलेट को अलग करने में मदद कर सकता है। फ़ाइलनाम के बिना, लेगेसी PPS और POT सामग्री को `SourceFormat::Ppt` के रूप में रिपोर्ट किया जा सकता है; ऊपर का PPS उदाहरण `Ppt` रिपोर्ट करता है।

यदि आपके अनुप्रयोग को अंतर बनाए रखना आवश्यक है, तो मूल फ़ाइलनाम या सबटाइप मेटाडेटा को अलग से रखें। एक्सटेंशन इन लेगेसी सबटाइप के लिए एक उपयोगी संकेत है, लेकिन इसे मनमाने प्रस्तुति सामग्री की पहचान के एकमात्र आधार नहीं बनाना चाहिए।

## **लोड करने से पहले और बाद में पहचान की तुलना करें**

जब आपको फ़ाइल को पूरी प्रस्तुति ऑब्जेक्ट मॉडल में लोड किए बिना जांचना हो, तो [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationfactory/getpresentationinfo/) और [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/get_loadformat/) का उपयोग करें। जब इंस्टेंस पहले से मौजूद हो, तो [Presentation::get_SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_sourceformat/) का उपयोग करें।

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और दोनों जांचों के लिए `Pptx` प्रिंट करता है। उत्पादन में, अपने प्रोसेसिंग चरण के अनुसार उपयुक्त API चुनें; पहले से लोड हुई प्रस्तुति को केवल स्रोत फ़ॉर्मेट प्राप्त करने के लिए दूसरी बार जांचने की आवश्यकता नहीं है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

परिणामों के एनीमरेशन प्रकार अलग होते हैं: [LoadFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadformat/) और [SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sourceformat/)। उनका संख्यात्मक मान कास्ट करके तुलना न करें या यह अनुमान न लगाएँ कि हर फ़ॉर्मेट के समान पहचान परिणाम होते हैं। PowerPoint XML को लोड करने से पहले `LoadFormat::Unknown` और लोड करने के बाद `SourceFormat::Xml` रिपोर्ट किया जा सकता है।

## **स्रोत और आउटपुट फ़ॉर्मेट को अलग रखें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और `converted.odp` लिखता है। यह मूल इंस्टेंस को सहेजने से पहले और बाद दोनों में `Pptx` प्रिंट करता है। केवल ODP आउटपुट से लोड किया गया नया इंस्टेंस `Odp` रिपोर्ट करता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

`MakeObject<Presentation>()` से शून्य से बनाई गई प्रस्तुति `SourceFormat::Pptx` रिपोर्ट करती है। इसके पास कोई इनपुट फ़ाइल नहीं है: यह नए बनाए गए इंस्टेंस के लिए डिफ़ॉल्ट मान है, यह प्रमाण नहीं कि PPTX फ़ाइल लोड हुई थी। यदि यह अंतर आपके लिए महत्वपूर्ण है, तो यह ट्रैक करें कि आपका अनुप्रयोग इंस्टेंस को बनाया या लोड किया।

## **स्रोत फ़ॉर्मेट को एक्सटेंशन में मैप करें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है। यह प्रत्येक वर्तमान में समर्थित [SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sourceformat/) मान को एक पारंपरिक एक्सटेंशन में मैप करता है, बिना इनपुट फ़ाइलनाम को पार्स किए। फॉलबैक अनपहचाने मान को चुपचाप एक्सटेंशन असाइन करने से बचाता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

यह मैपिंग फ़ाइल को नहीं बदलती या स्ट्रीम लोडिंग के दौरान खोए लेगेसी PPS/POT सबटाइप को पुनः प्राप्त नहीं करती। वास्तविक सहेजने के लिए, स्पष्ट रूप से एक [SaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) चुनें, या [Save Presentations in Their Original Format](/slides/hi/cpp/save-presentation/#save-presentations-in-their-original-format) में दिखाए गए रूपांतरण का उपयोग करें।

## **सहेजकर और पुनः खोलकर फ़ॉर्मेट की पुष्टि करें**

यह स्व-निहित उदाहरण एक प्रस्तुति बनाता है और कार्य निर्देशिका में तीन फ़ाइलें लिखता है, समान नाम की फ़ाइलों को ओवरराइट करता है। यह प्रत्येक आउटपुट को पथ और मेमोरी स्ट्रीम दोनों से पुनः खोलता है। PPTX और ODP के लिए, दोनों मार्ग सहेजे गए फ़ॉर्मेट को रिपोर्ट करते हैं। PPS के लिए, पथ से लोड करने पर `Pps` रिपोर्ट होता है, जबकि फ़ाइलनाम के बिना समान बाइट्स लोड करने पर `Ppt` रिपोर्ट होता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

| सहेजा गया फ़ॉर्मेट | फ़ाइल पथ से SourceFormat | नामरहित स्ट्रीम से SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` क्रमशः | फ़ाइल पथ के समान |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` क्रमशः | फ़ाइल पथ के समान |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` क्रमशः | फ़ाइल पथ के समान |
| ODP, OTP | `Odp`, `Otp` क्रमशः | फ़ाइल पथ के समान |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

लेगेसी PPS/POT सामग्री नामरहित स्ट्रीम के लिए `Ppt` में सामान्यीकृत की जाती है। तालिका फ़ॉर्मेट पहचान को दर्शाती है, न कि रूपांतरण के दौरान प्रत्येक प्रस्तुति फीचर के संरक्षण को।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ODP में सहेजने से PPTX से लोड की गई प्रस्तुति का स्रोत फ़ॉर्मेट बदलता है?**

नहीं। मौजूदा इंस्टेंस अभी भी `Pptx` रिपोर्ट करता है। सहेजे गए ODP फ़ाइल से लोड किया गया इंस्टेंस `Odp` रिपोर्ट करता है।

**क्या स्ट्रीम हमेशा लेगेसी प्रस्तुति, स्लाइड शो और टेम्पलेट को अलग कर सकती है?**

नहीं। PPT, PPS, और POT बाइनरी फ़ॉर्मेट साझा करते हैं। जब यह अंतर आवश्यक हो, तो फ़ाइलनाम या सबटाइप मेटाडेटा को अलग से रखें।

**यदि प्रस्तुति पहले से लोड है तो मुझे कौन सा API उपयोग करना चाहिए?**

[Presentation::get_SourceFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_sourceformat/) पढ़ें। लोड करने से पहले निरीक्षण के लिए [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करें।