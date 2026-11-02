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
- बिल्ट‑इन गुण
- कस्टम गुण
- उन्नत गुण
- गुणों का प्रबंधन
- गुणों में संशोधन
- दस्तावेज़ मेटाडाटा
- मेटाडाटा संपादित करना
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में प्रस्तुति गुणों को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides for C++ **built-in** और **custom** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग प्रस्तुतिकरण मेटाडाटा को पढ़ने और अपडेट करने के लिए किया जाता है, जैसे लेखक, शीर्षक और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुतिकरण दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस की एक इंस्टेंस [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) द्वारा लौटायी जाती है। निम्न उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सहेजते समय एप्लिकेशन और प्रोड्यूसर मेटाडाटा का प्रबंधन करता है; ये फ़ील्ड उस सॉफ़्टवेयर को पहचानते हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में आते हैं:

- **Built-in properties** मानक मेटाडाटा होते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **Custom properties** उपयोगकर्ता‑परिभाषित नाम/मान जोड़े संग्रहीत करते हैं।

Aspose.Slides for C++ दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडाटा की जांच के लिये **File → Info → Properties → Advanced Properties** चुनें। संवाद जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों का प्रबंधन करने के लिए **Custom** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ना**

एक ओपनिंग पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की रक्षा करता है। जब `false` पास करके प्रस्तुति को एन्क्रिप्ट किया जाता है [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), उसके दस्तावेज़ गुण सार्वजनिक रह जाते हैं। तब कोई एप्लिकेशन `true` पास करके [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/), को पास कर सकता है और ओपनिंग पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडाटा पढ़ सकता है।

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) निर्धारित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन मेंincluded थे, तो पासवर्ड के बिना उन्हें लोड करना विफल रहता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प नजरअंदाज किया जाता है और पूरी प्रस्तुति लोड की जाती है।

यह उदाहरण एक एन्क्रिप्टेड प्रस्तुति की आवश्यकता रखता है जिसके दस्तावेज़ गुण सार्वजनिक रखे गये थे। यह लोडिंग मोड को [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) के माध्यम से सत्यापित करता है और फिर [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) के माध्यम से बिल्ट‑इन गुण पढ़ता है:

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

इस मोड में, स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर्स, लेआउट्स, शेप्स, मीडिया, और अन्य प्रस्तुति वस्तुओं तक पहुँच नहीं होती। एप्लिकेशन को हमेशा [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) को जांचना चाहिए इससे पहले कि वह ऐसी ऑपरेशन करे जो पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता रखती हो।

{{% alert color="warning" title="Security" %}}
सार्वजनिक मेटाडाटा लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणियों और कस्टम मानों को उजागर कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। इन्हें केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणाली को पासवर्ड के बिना इन्हें एक्सेस करने की विशेष आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुणों को अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिये, `true` पास करके लोड की गयी प्रस्तुति [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) से सार्वजनिक मेटाडाटा पढ़ने के लिये अभिप्रेत है। Aspose.Slides उस केवल‑मेटाडाटा वस्तु से बदले हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के अंदर के संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिये सही ओपनिंग पासवर्ड और पूर्ण लोड आवश्यक है।

यह उदाहरण एक एन्क्रिप्टेड PPTX प्रस्तुति की आवश्यकता रखता है जिसमें सार्वजनिक दस्तावेज़ गुण और ज्ञात ओपनिंग पासवर्ड हो। यह पूर्ण प्रस्तुति को [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) के साथ खोलता है, सार्वजनिक बिल्ट‑इन गुणों को अपडेट करता है, और परिणाम सहेजता है। फिर यह [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) का उपयोग करके यह सत्यापित करता है कि एन्क्रिप्शन बरकरार है और पासवर्ड के बिना सार्वजनिक मेटाडाटा को फिर से खोलकर नए मानों की पुष्टि करता है:

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

यदि किसी एप्लिकेशन को प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुँच**

[IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) इंटरफ़ेस टाइपड गेटर्स के माध्यम से बिल्ट‑इन मेटाडाटा उजागर करता है, जिसमें [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/), और [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/) शामिल हैं। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और उसकी संग्रहीत मेटाडाटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करता है; कुछ फ़ील्ड ख़ाली हो सकते हैं।

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

## **बिल्ट‑इन गुणों को संशोधित करें**

बिल्ट‑इन मेटाडाटा को अपडेट करने के लिये, [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) द्वारा लौटाए गये ऑब्जेक्ट पर सेटर्स का उपयोग करें। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है, [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), और [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) को कॉल करता है, फिर अपडेटेड प्रस्तुति को [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) के साथ सहेजता है। सहेजा गया PPTX नया मेटाडाटा रखता है।

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

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) सापेक्ष हाइपरलिंक के लिये दस्तावेज़‑स्तरीय बेस पढ़ता है। यह उपयोगी है जब प्रस्तुति और उसकी लिंक्ड फ़ाइलों को किसी अन्य स्थान पर ले जाया जाता है। यह व्यक्तिगत हाइपरलिंक के [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) से अलग है: बेस बदलने से संग्रहीत लिंक एड्रेस नहीं बदले जाते और न ही पूर्ण गंतव्य बदलते हैं।

यह उदाहरण एक ऐसी प्रस्तुति की आवश्यकता रखता है जिसमें एक सापेक्ष लिंक, जैसे `target.html`, और एक पूर्ण लिंक, जैसे `https://example.org/absolute.html` हो। यह मौजूदा बेस पढ़ता है, नई बेस एड्रेस [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) से असाइन करता है, और मूल्य जाँचने के लिये प्रस्तुति को सेव कर पुनः खोलता है। फिर यह बेस को `u""` से साफ़ करता है और अलग सहेजी फ़ाइल में खाली मान की पुष्टि करता है। उदाहरण बेस एड्रेस को अपनी लिंक्ड फ़ाइलों के स्थान से बदलें।

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

दो सत्यापन संदेश `True` प्रिंट करेंगे। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक एड्रेस अपरिवर्तित रहते हैं।

`target.pptx` के सापेक्ष लिंक ने `old/target.pptx` खोला जब बेस `old` फ़ोल्डर की ओर इशारा करता था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। पूर्ण लिंक वही फ़ाइल खोलता रहा। प्रस्तुति को स्थानांतरित करने या उसके बेस को बदलने से पहले और बाद में PowerPoint में अपने सापेक्ष लिंक का परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण उन मेटाडाटा को संग्रहीत करते हैं जिनका कोई संबंधित बिल्ट‑इन फ़ील्ड नहीं होता। [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) आपको गुण नाम द्वारा मान असाइन करने देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और प्रस्तुति को [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) के साथ सहेजता है। मौजूदा नाम पर मान असाइन करने से उस गुण का मान बदल दिया जाता है।

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

## **कस्टम गुणों तक पहुँच और संशोधित करें**

यह उदाहरण कस्टम गुणों वाली एक प्रस्तुति खोलता है और उनके ऊपर इटरेट करने के लिये [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) का उपयोग करता है। [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) शून्य‑आधारित सूचकांक स्वीकार करता है और वह नाम लौटाता है जिसका उपयोग [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) और [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) द्वारा किया जाता है। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, प्रत्येक मान को उसकी मूल प्रकार की परवाह किए बिना क्रमांकित स्ट्रिंग से बदल देता है, और परिवर्तनों को सहेजता है। यदि कोई कस्टम गुण नहीं है, तो लूप कोई परिवर्तन नहीं करता।

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

Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ कैसे काम करें, यह देखने के लिये ऑनलाइन ऐप [**PowerPoint मेटाडाटा देखें एवं संपादित करें**](https://products.aspose.app/slides/metadata) आज़माएँ:

[![PowerPoint मेटाडाटा देखें एवं संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**एक बिल्ट‑इन गुण को प्रस्तुति से कैसे हटाया जा सकता है?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनकी मान को बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं एक मौजूदा कस्टम गुण को जोड़ता हूँ तो क्या होता है?**

यदि आप एक मौजूदा कस्टम गुण को जोड़ते हैं, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से गुण को हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण का मान अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति को लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ। आप [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करके जानकारी प्राप्त कर सकते हैं और फिर [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) से stored document metadata को पढ़ सकते हैं बिना [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) इंस्टेंस बनाए। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिये देखें [Build a Lightweight Presentation Inventory](/slides/hi/cpp/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को उसके ओपनिंग पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को `false` पास करके [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) से एन्क्रिप्ट किया गया होना चाहिए, और इसे `true` पास करके [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) से लोड किया गया होना चाहिए।

**क्या मैं डॉक्यूमेंट‑प्रॉपर्टीज़‑ऑनली मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिये सही ओपनिंग पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।