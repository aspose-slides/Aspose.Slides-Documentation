---
title: "C++ में प्रस्तुति जानकारी पुनः प्राप्त करें और अपडेट करें"
linktitle: "प्रस्तुति जानकारी"
type: docs
weight: 30
url: /hi/cpp/examine-presentation/
keywords:
- "प्रस्तुति फ़ॉर्मेट"
- "प्रस्तुति गुण"
- "दस्तावेज़ गुण"
- "गुण प्राप्त करें"
- "गुण पढ़ें"
- "गुण बदलें"
- "गुण संशोधित करें"
- "गुण अपडेट करें"
- "PPTX का परीक्षण"
- "PPT का परीक्षण"
- "ODP का परीक्षण"
- PowerPoint
- OpenDocument
- "प्रस्तुति"
- C++
- Aspose.Slides
description: "C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडाटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और स्मार्ट कंटेंट ऑडिट के लिए।"
---
## **अवलोकन**

Aspose.Slides एक प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और उसके दस्तावेज़ मेटाडाटा को बिना पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए पढ़ सकता है। यह तब उपयोगी है जब आपको फ़ाइलों को वर्गीकृत करना हो, एक इन्वेंट्री बनानी हो, या गुणों की जाँच करनी हो इससे पहले कि आप तय करें कि प्रस्तुति की सामग्री को लोड और प्रोसेस किया जाए।

यह लेख हल्की जांच को [PresentationFactory](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationfactory/) और [IPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/) के माध्यम से, तथा लक्षित अद्यतनों को [IDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/) के माध्यम से प्रदर्शित करता है।

## **प्रस्तुति फ़ॉर्मेट की जांच**

फ़ाइल की जांच करने के लिए [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग करें, बिना एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस बनाए। [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/get_loadformat/) विधि पता लगाए गए फ़ॉर्मेट को रिपोर्ट करती है, जैसे PPTX, PPT, या ODP।

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **हल्की प्रस्तुति इन्वेंटरी बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो आपको वैधता, अनुक्रमण या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक कॉम्पैक्ट इन्वेंट्री की आवश्यकता हो सकती है। इस परिदृश्य में, [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग करके एक [IPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) को कॉल करके दस्तावेज़ मेटाडाटा पढ़ें। यह विधि एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस नहीं बनाती और आपको पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को ट्रैवर्स करने की आवश्यकता नहीं पड़ती।

[IDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/) द्वारा उजागर किए गए विस्तारित गुण निम्नलिखित इन्वेंट्री मान प्रदान करते हैं:

| विधि | इन्वेंटरी मान |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_slides/) | स्लाइड्स की कुल संख्या। |
| [get_HiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | छिपी हुई स्लाइड्स की संख्या। |
| [get_Notes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_notes/) | नोट्स वाले स्लाइड्स की संख्या। |
| [get_Paragraphs](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | उपलब्ध होने पर पैराग्राफ की कुल संख्या। |
| [get_Words](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_words/) | शब्दों की कुल संख्या। |
| [get_MultimediaClips](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को बिना एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक कॉम्पैक्ट इन्वेंट्री प्रिंट करता है। यह [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_headingpairs/) को [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) के साथ मिलाता है ताकि फ़ॉन्ट, थीम और स्लाइड शीर्षक जैसी सामग्री समूह दिखाए जा सकें।

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

प्रत्येक [IHeadingPair](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iheadingpair/) [IHeadingPair::get_Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iheadingpair/get_name/) के माध्यम से एक समूह नाम प्रदान करता है और उसी समूह में वस्तुओं की संख्या [IHeadingPair::get_Count](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iheadingpair/get_count/) से। [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) एक फ्लैट, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग‑पेयर द्वारा निर्दिष्ट क्रमागत शीर्षकों की संख्या को उपभोग करें।

### **संग्रहीत मेटाडाटा और फ़ॉर्मेट सीमाएँ**

[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) द्वारा लौटाए गए इन्वेंट्री गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडाटा को प्रतिबिंबित करते हैं। Aspose.Slides इस कॉल के लिए इन मानों को पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड या ट्रैवर्स नहीं करता। अनुपलब्ध गुण डिफ़ॉल्ट मानों द्वारा दर्शाए जाते हैं, और यदि अंतिम बार फ़ाइल को सहेजने वाला एप्लिकेशन अपने दस्तावेज़ गुण अपडेट नहीं करता तो संग्रहीत मान पुराना हो सकता है।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द और मल्टीमीडिया गणना के लिए विस्तारित दस्तावेज़ गुण, साथ ही हेडिंग‑पेयर और भाग‑शीर्षक प्रदान करता है। उपलब्धता इस बात पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन‑से गुण लिखे हैं।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित दस्तावेज़‑सारांश गुण संग्रहीत कर सकता है। यदि कोई गुण अनुपलब्ध है या दस्तावेज़ निर्माता द्वारा रीफ़्रेश नहीं किया गया है, तो Aspose.Slides स्लाइड्स से गणना करने के बजाय उसका संग्रहीत या डिफ़ॉल्ट मान लौटाता है।
- **ODP:** OpenDocument मेटाडाटा सामान्य दस्तावेज़ आँकड़े प्रदान करता है, जैसे पृष्ठ, पैराग्राफ और शब्द गणना, लेकिन ये मान प्रत्येक PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर और भाग‑शीर्षक मेटाडाटा अनुपलब्ध हो सकता है, और इन्वेंट्री गुण डिफ़ॉल्ट मान लौट सकते हैं। शून्य मान या खाली एरे को यह प्रमाण न मानें कि संबंधित सामग्री अनुपस्थित है।

इन्वेंट्री और प्रारंभिक जाँचों के लिए हल्की मेटाडाटा पद्धति का उपयोग करें। जब परिणाम को मेमोरी‑में किए गए परिवर्तन दर्शाने चाहिए या जब आपको वास्तविक प्रस्तुति सामग्री को सत्यापित करना हो, तब प्रस्तुति लोड करके उसके लाइव ऑब्जेक्ट मॉडल की जांच करें।

## **प्रस्तुति गुण अपडेट करें**

[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) द्वारा लौटाए गए गुणों को बिना एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस बनाए भी बदला जा सकता है। परिवर्तनों को [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) से लागू करें, और फिर बंधित प्रस्तुति को [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) से लिखें।

निम्न छवि PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण दिखाती है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑सहेजे समय को बदलता है और परिणाम को नई फ़ाइल में लिखता है:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

निम्न छवि PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण दिखाती है।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जांच और संरक्षण सेटिंग्स के लिए निम्न लेख देखें:

- [प्रेज़ेंटेशन को पासवर्ड से सुरक्षित करें](/slides/hi/cpp/password-protected-presentation/)
- [प्रेज़ेंटेशन को लिखने से सुरक्षित रखें](/slides/hi/cpp/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि फोंट एम्बेडेड हैं और कौन‑से हैं?**

प्रेज़ेंटेशन लोड करें और [Presentation::get_FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_fontsmanager/) का उपयोग करें। एम्बेडेड फोंट प्राप्त करने के लिए [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) कॉल करें और प्रेज़ेंटेशन द्वारा उपयोग किए गए फोंट प्राप्त करने के लिए [FontsManager::GetFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getfonts/) कॉल करें। दोनों परिणामों की तुलना करके उन फोंट्स को पहचानें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**मैं कैसे जल्दी पता करूँ कि फ़ाइल में छिपी स्लाइड्स हैं और उनकी संख्या क्या है?**

जब संग्रहीत दस्तावेज़ मेटाडाटा पर्याप्त हो, तो [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) को [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) और [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) के माध्यम से पढ़ें। यह हल्की इन्वेंट्री के लिए उपयुक्त है। यदि प्रेज़ेंटेशन मेमोरी में संशोधित हुआ है, तो संग्रहीत मेटाडाटा पुराना या अनुपलब्ध हो सकता है; ऐसे में लाइव मानों को सत्यापित करने के लिए [Presentation::get_Slides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slides/) को इटररेट करें और प्रत्येक स्लाइड के [Slide::get_Hidden](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/get_hidden/) मेथड की जाँच करें।

**क्या मैं पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में हैं, और क्या वे डिफ़ॉल्ट से भिन्न हैं?**

हाँ। प्रेज़ेंटेशन लोड करें और [Presentation::get_SlideSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slidesize/) पढ़ें। वर्तमान सेटिंग्स को अपेक्षित प्रीसेट और आयामों से तुलना करने के लिए [ISlideSize::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidesize/get_size/) और [ISlideSize::get_Orientation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidesize/get_orientation/) का निरीक्षण करें।

**क्या चार्ट्स बाहरी डेटा स्रोतों को संदर्भित करते हैं, इसे देखने का कोई तेज़ तरीका है?**

हाँ। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/) को खोजें और उसके [ChartData::get_DataSourceType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) को जाँचें। बाहरी वर्कबुक के लिए, [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) पढ़ें। डेटा स्रोत प्रकार और पथ एक बाहरी संदर्भ का संकेत देते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि के लिए अलग रिसोर्स चेक आवश्यक है।

**मैं 'हैवी' स्लाइड्स का मूल्यांकन कैसे करूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकते हैं?**

एकल जटिलता गुण नहीं है। [Presentation::get_Slides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slides/) को तथा प्रत्येक स्लाइड के [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/get_shapes/) संग्रह को ट्रैवर्स करें। आकार गणना, बड़े चित्र, इफ़ेक्ट्स, एनीमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और बाद में प्रतिनिधित्वात्मक रेंडर या एक्सपोर्ट मापें ताकि स्लाइड को वास्तविक प्रदर्शन बाधा के रूप में पुष्टि किया जा सके।