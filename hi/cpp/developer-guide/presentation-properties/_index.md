---
title: C++ में प्रस्तुति गुणों का प्रबंधन
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/cpp/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- निर्मित गुण
- स्वनिर्धारित गुण
- उन्नत गुण
- गुणों का प्रबंधन
- गुणों में परिवर्तन
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में प्रस्तुति गुणों पर पूर्ण नियंत्रण प्राप्त करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सहज बनाएं।"
---
## **परिचय**

Aspose.Slides for C++ **built-in** और **custom** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग प्रस्तुति मेटाडेटा को पढ़ने और अद्यतन करने के लिए किया जाता है, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) द्वारा लौटाया जाता है। नीचे दिए गए उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सहेजते समय एप्लिकेशन और प्रोड्यूसर मेटाडेटा का प्रबंधन करता है; ये फ़ील्ड्स उस सॉफ़्टवेयर की पहचान करती हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ विवरणात्मक जानकारी संग्रहीत करते हैं। वे दो वर्गों में विभाजित होते हैं:

- **Built-in properties** मानक मेटाडेटा जैसे शीर्षक, लेखक और दस्तावेज़ आँकड़े शामिल होते हैं।
- **Custom properties** उपयोगकर्ता‑परिभाषित नाम/मान युग्म संग्रहीत करते हैं।

Aspose.Slides for C++ दोनों वर्गों तक पहुंच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडेटा जांचने के लिए **File → Info → Properties → Advanced Properties** चुनें। यह संवाद जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों को प्रबंधित करने के लिए **Custom** टैब का उपयोग करें।

## **एनक्रिप्टेड प्रस्तुति से सार्वजनिक गुणों को पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की सुरक्षा करता है। जब प्रस्तुति को [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) को `false` पास करके एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। तब एप्लिकेशन [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) को `true` पास करके खोलने वाला पासवर्ड दिए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल हो जाता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो विकल्प को नज़रअंदाज़ किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

उदाहरण को एक एन्क्रिप्टेड प्रस्तुति की आवश्यकता होती है जिसमें दस्तावेज़ गुण सार्वजनिक रखे गए हों। यह लोडिंग मोड को [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) द्वारा सत्यापित करता है और फिर [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) के माध्यम से बिल्ट‑इन गुण पढ़ता है:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर, लेआउट, आकार, मीडिया और अन्य प्रस्तुति वस्तुएँ अनुपलब्ध रहती हैं। एप्लिकेशन को हमेशा [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) जांचना चाहिए इससे पहले कि वह पूरी प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता वाली कोई कार्रवाई करे।

{{% alert color="warning" title="Security" %}}
सार्वजनिक मेटाडेटा लेखक नाम, शीर्षक, विषय, कुंजी‑शब्द, कंपनी जानकारी, टिप्पणियाँ और कस्टम मान प्रदर्शित कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। इन्हें केवल तभी सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज या दस्तावेज़‑प्रबंधन प्रणाली को पासवर्ड के बिना उन्हें एक्सेस करने की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एनक्रिप्टेड प्रस्तुति के गुणों को अद्यतन करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) को `true` पास करके लोड किया गया प्रस्तुति केवल सार्वजनिक मेटाडेटा पढ़ने के लिए होता है। Aspose.Slides उस मेटाडेटा‑केवल ऑब्जेक्ट से बदले हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ संगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिए सही खोलने वाला पासवर्ड और पूरी लोड आवश्यक है।

उदाहरण को एक एन्क्रिप्टेड PPTX प्रस्तुति की आवश्यकता है जिसमें सार्वजनिक दस्तावेज़ गुण और ज्ञात खोलने वाला पासवर्ड हो। यह पूरी प्रस्तुति को [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) के साथ खोलता है, सार्वजनिक बिल्ट‑इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) का उपयोग करके पुष्टि करता है कि एन्क्रिप्शन बना रहता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा को फिर से खोल कर नई मानों की जाँच करता है:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुंच**

[IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) इंटरफ़ेस टाइप्ड गेटरों के माध्यम से बिल्ट‑इन मेटाडेटा उजागर करता है, जिसमें [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) और [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/) शामिल हैं। यह उदाहरण मौजूदा प्रस्तुति खोलता है और उसके संग्रहीत मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करता है; कुछ फ़ील्ड खाली हो सकते हैं।

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

### **संशोधन संख्या और संपादन समय रिपोर्ट**

[GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) और [ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) का उपयोग करके प्रत्येक फ़ाइल के [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) को स्लाइड्स लोड किए बिना पढ़ा जा सकता है। यह उदाहरण `presentations` फ़ोल्डर में प्रत्येक PPTX फ़ाइल के लिए एक पंक्ति प्रिंट करता है। मानक `c` फ़ॉर्मेट में दिन गिनती शामिल होती है जब रिकॉर्ड किया गया संपादन समय 24 घंटे तक पहुँच जाता है।

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/timespan.h>

using namespace Aspose::Slides;
using namespace System::IO;

System::Console::WriteLine(u"File | RevisionNumber | TotalEditingTime");
auto paths = Directory::GetFiles(u"presentations", u"*.pptx");
for (const auto& path : paths)
{
    auto info = PresentationFactory::get_Instance()->GetPresentationInfo(path);
    auto properties = info->ReadDocumentProperties();
    auto fileName = Path::GetFileName(path);
    auto editingTime = properties->get_TotalEditingTime().ToString(u"c");
    System::Console::WriteLine(u"{0} | {1} | {2}", fileName, properties->get_RevisionNumber(), editingTime);
}
```

1 दिन, 2 घंटे और 5 मिनट के रिकॉर्ड किए गए संपादन समय वाली प्रस्तुति के लिए रिपोर्ट इस प्रकार दिखती है:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[get_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_revisionnumber/) एक मेटाडेटा मान पढ़ता है जिसे एप्लिकेशन [set_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_revisionnumber/) से बदल सकते हैं। यह मान अकेले यह निर्धारित नहीं कर सकता कि प्रस्तुति कितनी बार सहेजा गया या उसका संस्करण इतिहास कैसे है।

[get_TotalEditingTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_totaleditingtime/) फ़ाइल में रिकॉर्ड किया गया संपादन अवधि लौटाता है। `00:00:00` का मान दर्शाता है कि संग्रहीत अवधि शून्य है। फिर भी प्रस्तुति का संपादन हुआ हो सकता है।

## **बिल्ट‑इन गुणों को संशोधित करें**

बिल्ट‑इन मेटाडेटा को अद्यतन करने के लिए, [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) द्वारा लौटाए गए ऑब्जेक्ट पर सेटर्स का उपयोग करें। यह उदाहरण मौजूदा प्रस्तुति खोलता है, [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) और [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) को कॉल करता है, फिर अद्यतन प्रस्तुति को [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) से सहेजता है। सहेजा गया PPTX नया मेटाडेटा रखता है।

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **हाइपरलिंक बेस का प्रबंधन**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) सापेक्ष हाइपरलिंक्स के लिए दस्तावेज़‑स्तरीय बेस पढ़ता है। यह प्रस्तुति और उसकी लिंक की गई फ़ाइलों को किसी अन्य स्थान पर ले जाने पर उपयोगी होता है। यह व्यक्तिगत हाइपरलिंक के [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) से अलग होता है: बेस बदलने से संग्रहीत लिंक पते नहीं बदलते और न ही निरपेक्ष गंतव्य बदलते हैं।

उदाहरण को ऐसी प्रस्तुति चाहिए जिसमें एक सापेक्ष लिंक जैसे `target.html` और एक निरपेक्ष लिंक जैसे `https://example.org/absolute.html` दोनों हों। यह मौजूदा बेस पढ़ता है, नए बेस पते को [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) से असाइन करता है, और मूल्य जाँचने के लिये प्रस्तुति को सहेजकर पुनः खोलता है। फिर यह बेस को `u""` से साफ़ करता है और अलग सहेजी गई फ़ाइल में खाली मान की जाँच करता है। उदाहरण बेस पते को अपनी लिंक फ़ाइलों के स्थान से बदलें।

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

दोनों सत्यापन संदेश `True` प्रिंट करेंगे। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक पते अपरिवर्तित रहते हैं।

`target.pptx` के लिए एक सापेक्ष लिंक ने `old/target.pptx` खोल दिया था जब बेस `old` फ़ोल्डर की ओर इशारा कर रहा था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। निरपेक्ष लिंक वही फ़ाइल खोलता ही रहता है। प्रस्तुति को स्थानांतरित करने या बेस बदलने से पहले और बाद में PowerPoint में अपने सापेक्ष लिंक्स का परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण उन मेटाडेटा को संग्रहीत करते हैं जिनका कोई बिल्ट‑इन फ़ील्ड नहीं होता। [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) आपको गुण नाम द्वारा मान असाइन करने की अनुमति देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और प्रस्तुति को [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) से सहेजता है। मौजूदा नाम पर मान असाइन करने से उस गुण का मान बदल जाता है।

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **कस्टम गुणों तक पहुंच और संशोधन**

यह उदाहरण कस्टम गुणों वाली प्रस्तुति खोलता है और [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) का उपयोग करके उन पर इटरेट करता है। [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) शून्य‑आधारित इंडेक्स स्वीकार करता है और वह नाम लौटाता है जिसका उपयोग [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) और [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) करते हैं। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, सभी मानों को क्रमिक स्ट्रिंग से बदल देता है चाहे उनका मूल प्रकार कुछ भी हो, और बदलाव सहेजता है। यदि कोई कस्टम गुण नहीं हैं, तो लूप कोई परिवर्तन नहीं करता।

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **लाइव उदाहरण**

Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ काम करने का तरीका देखने के लिए ऑनलाइन ऐप [**PowerPoint मेटाडेटा देखें और संपादित करें**](https://products.aspose.app/slides/metadata) आज़माएँ:

[![PowerPoint मेटाडेटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन गुण को कैसे हटाऊँ?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न भाग होते हैं और पूरी तरह से हटाए नहीं जा सकते। हालांकि, आप उनके मान बदल सकते हैं या यदि उस विशेष गुण द्वारा अनुमति हो तो खाली सेट कर सकते हैं।

**यदि मैं ऐसा कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से गुण हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट करता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुंच सकता हूँ?**

हाँ। आप [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करके और फिर [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) द्वारा एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) इंस्टेंस बनाए बिना संग्रहीत दस्तावेज़ मेटाडेटा पढ़ सकते हैं। पूर्ण रिपोर्ट उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/cpp/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को बिना खोलने वाले पासवर्ड के पढ़ सकता हूँ?**

हाँ। प्रस्तुति को तब एन्क्रिप्ट किया जाना चाहिए जब [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) को `false` पास किया गया हो, और इसे फिर [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) को `true` पास करके लोड किया गया हो।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को संगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खोलने वाला पासवर्ड के साथ पूरी प्रस्तुति लोड करना आवश्यक है।