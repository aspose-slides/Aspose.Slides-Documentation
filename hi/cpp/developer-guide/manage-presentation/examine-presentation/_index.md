---
title: C++ में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/cpp/examine-presentation/
keywords:
- प्रस्तुति प्रारूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX जांचें
- PPT जांचें
- ODP जांचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडाटा की खोज करें ताकि तेज़ अंतर्दृष्टि और अधिक समझदार सामग्री ऑडिट मिल सके।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति का फ़ॉर्मेट पहचान सकता है और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके दस्तावेज़ मेटाडेटा को पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करना हो, एक इन्वेंटरी बनानी हो, या प्रॉपर्टीज़ का निरीक्षण करना हो, इससे पहले कि आप यह तय करें कि प्रस्तुति की सामग्री को लोड और प्रोसेस किया जाए।

यह लेख हल्की जांच को [PresentationFactory](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationfactory/) और [IPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/) के माध्यम से दर्शाता है, साथ ही लक्षित अपडेट को [IDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/) के माध्यम से करता है।

## **प्रस्तुति फ़ॉर्मेट जांचें**

यदि आपके पास पहले से एक लोड की गई प्रस्तुति है, तो लोड करने के बाद पहचान के लिए और लेगेसी PPT, PPS, और POT स्ट्रीमर की सीमाओं के लिए [Determine the Original Presentation Format](/slides/hi/cpp/detect-presentation-source-format/) देखें।

फ़ाइल का निरीक्षण करने के लिए बिना [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस बनाए, [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग करें। [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/get_loadformat/) मेथड पता लगाए गए फ़ॉर्मेट को रिपोर्ट करता है, जैसे PPTX, PPT या ODP।

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

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो वैधता, इंडेक्सिंग या दस्तावेज़‑प्रबंधन प्रणाली के लिए आपको एक संक्षिप्त इन्वेंटरी की आवश्यकता हो सकती है। इस स्थिति में, एक [IPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/) ऑब्जेक्ट प्राप्त करने के लिए [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग करें, और फिर दस्तावेज़ मेटाडेटा पढ़ने के लिए [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) को कॉल करें। यह तरीका एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस नहीं बनाता और पूरी प्रस्तुति ऑब्जेक्ट मॉडल को पार नहीं करना पड़ता।

[IDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/) द्वारा एक्सपोज़ किए गए विस्तारित प्रॉपर्टीज़ निम्नलिखित इन्वेंटरी मान प्रदान करते हैं:

| विधि | इन्वेंटरी मान |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_slides/) | स्लाइड्स की कुल संख्या। |
| [get_HiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | छिपी हुई स्लाइड्स की संख्या। |
| [get_Notes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_notes/) | नोट्स वाली स्लाइड्स की संख्या। |
| [get_Paragraphs](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | उपलब्ध होने पर पैराग्राफ़ की कुल संख्या। |
| [get_Words](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_words/) | शब्दों की कुल संख्या। |
| [get_MultimediaClips](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट बनाए बिना पढ़ता है और एक संक्षिप्त इन्वेंटरी प्रिंट करता है। यह [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_headingpairs/) को [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) के साथ मिलाकर फ़ॉन्ट्स, थीम और स्लाइड शीर्षकों जैसे कंटेंट समूह दर्शाता है।

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

प्रत्येक [IHeadingPair](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iheadingpair/) [IHeadingPair::get_Name](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iheadingpair/get_name/) द्वारा समूह नाम और [IHeadingPair::get_Count](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iheadingpair/get_count/) द्वारा उस समूह में आइटमों की संख्या प्रदान करता है। [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) एक फ्लैट, क्रमित एरे लौटाता है, इसलिए प्रत्येक हेडिंग पेयर द्वारा निर्दिष्ट क्रमिक शीर्षकों की संख्या को उपभोग करें।

### **संचित मेटाडेटा और फ़ॉर्मेट सीमाएँ**

[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) द्वारा लौटाए गए इन्वेंटरी प्रॉपर्टीज़ स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को प्रतिबिंबित करते हैं। Aspose.Slides इस कॉल के लिए इन मानों की पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और ट्रैवर्स नहीं करता। अनुपलब्ध प्रॉपर्टीज़ डिफ़ॉल्ट मानों द्वारा दर्शाई जाती हैं, और यदि अंतिम बार फ़ाइल सहेजने वाला अनुप्रयोग अपनी दस्तावेज़ प्रॉपर्टीज़ अपडेट नहीं करता तो संग्रहीत मान पुराना हो सकता है।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द और मल्टीमीडिया काउंट्स के साथ विस्तारित दस्तावेज़ प्रॉपर्टीज़ प्रदान करता है, साथ ही हेडिंग पेयर्स और भाग शीर्षक। उपलब्धता इस पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन‑सी प्रॉपर्टीज़ लिखी हैं।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित डॉक्यूमेंट‑समरी प्रॉपर्टीज़ स्टोर कर सकता है। यदि कोई प्रॉपर्टी अनुपस्थित है या निर्माता द्वारा रिफ्रेश नहीं की गई है, तो Aspose.Slides स्लाइड्स से गणना करने के बजाय उसका संग्रहीत या डिफ़ॉल्ट मान लौटाता है।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े जैसे पेज, पैराग्राफ और शब्द काउंट प्रदान करता है, लेकिन ये मान प्रत्येक PowerPoint‑विशिष्ट विस्तारित प्रॉपर्टी से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर और भाग‑शीर्षक मेटाडेटा उपलब्ध नहीं हो सकता, और इन्वेंटरी प्रॉपर्टीज़ डिफ़ॉल्ट मान लौटा सकती हैं। शून्य मान या खाली एरे को इस बात का प्रामाणिक सबूत न मानें कि संबंधित कंटेंट अनुपस्थित है।

इन्वेंटरी और प्रारम्भिक जांचों के लिए हल्के मेटाडेटा दृष्टिकोण का उपयोग करें। जब परिणाम को मेमोरी‑में बदलावों को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री की पुष्टि करनी हो, तो प्रस्तुति को लोड करें और उसके लाइव ऑब्जेक्ट मॉडल का निरीक्षण करें।

## **प्रस्तुति प्रॉपर्टीज़ अपडेट करें**

[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) द्वारा लौटाए गए प्रॉपर्टीज़ को एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस बनाए बिना बदला भी जा सकता है। बदलावों को [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) से लागू करें, और फिर बँधी हुई प्रस्तुति को [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) के साथ लिखें।

![PowerPoint प्रस्तुति की मूल दस्तावेज़ प्रॉपर्टीज़](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑सहेजने का समय बदलता है और परिणाम को नई फ़ाइल में लिखता है:

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

![PowerPoint प्रस्तुति की बदली हुई दस्तावेज़ प्रॉपर्टीज़](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जांच और संरक्षण सेटिंग्स के लिए, निम्न लेख देखें:

- [Password-Protect Presentations](/slides/hi/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/cpp/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जांचूं कि फ़ॉन्ट एम्बेडेड हैं और कौन से हैं?**

प्रेजेंटेशन को लोड करें और [Presentation::get_FontsManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_fontsmanager/) का उपयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getembeddedfonts/) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट्स के लिए [FontsManager::GetFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsmanager/getfonts/) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट्स का पता लगाएँ जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेड नहीं हैं।

**मैं जल्दी से कैसे पता लगा सकता हूँ कि फ़ाइल में छिपी हुई स्लाइड्स हैं और उनकी संख्या कितनी है?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) और [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) के माध्यम से [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) पढ़ें। यह हल्की इन्वेंटरी के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा अनुपलब्ध या पुराना हो सकता है; ऐसी स्थिति में जीवित मानों की पुष्टि के लिए [Presentation::get_Slides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slides/) पर इटरेट करें और प्रत्येक स्लाइड के [Slide::get_Hidden](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/get_hidden/) मेथड को जांचें।

**क्या मैं पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में हैं, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हां। प्रस्तुति को लोड करें और [Presentation::get_SlideSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slidesize/) पढ़ें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रीसेट और आयामों से करने के लिए [ISlideSize::get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidesize/get_size/) और [ISlideSize::get_Orientation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidesize/get_orientation/) को निरीक्षण करें।

**क्या चार्ट्स के बाहरी डेटा स्रोतों के संकेत जल्दी से देखे जा सकते हैं?**

हां। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/) को खोजें और उसके [ChartData::get_DataSourceType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) को जांचें। यदि बाहरी वर्कबुक है, तो [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) पढ़ें। डेटा स्रोत प्रकार और पाथ बाहरी संदर्भ को इंगित करते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि एक अलग रिसोर्स चेक की आवश्यकता होती है।

**मैं 'भारी' स्लाइड्स का आकलन कैसे करूँ जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकते हैं?**

कोई एकल जटिलता प्रॉपर्टी नहीं है। सभी स्लाइड्स के [Presentation::get_Slides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_slides/) और प्रत्येक स्लाइड के [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/get_shapes/) संग्रह को ट्रैवर्स करें। आकार वाली इमेजेज, इफ़ेक्ट्स, एनीमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और किसी स्लाइड को पुष्टि करने से पहले प्रतिनिधि रेंडर या एक्सपोर्ट मापें।