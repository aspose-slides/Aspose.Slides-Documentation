---
title: C++ में प्रस्तुति गुण प्रबंधित करें
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/cpp/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट-इन गुण
- कस्टम गुण
- उन्नत गुण
- गुण प्रबंधित करें
- गुण संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में प्रस्तुति गुणों को पूरी तरह नियंत्रित करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों प्रकार के गुणों को Aspose.Slides API की मदद से आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की सुविधा देता है [IDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_documentproperties/) द्वारा 반환 किया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="नोट" %}}
कृपया ध्यान दें कि आप **Application** और **Producer** फ़ील्ड के मान सेट नहीं कर सकते हैं, क्योंकि इन फ़ील्ड्स में Aspose Ltd. और Aspose.Slides for C++ x.x.x प्रदर्शित किया जाएगा।
{{% /alert %}} 

## **प्रस्तुति गुणों का प्रबंधन**

Microsoft PowerPoint प्रस्तुतिकरण फ़ाइलों में कुछ गुण जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुण उपयोगी जानकारी को दस्तावेज़ (प्रस्तुति फ़ाइलों) के साथ संग्रहीत करने की अनुमति देते हैं। दो प्रकार के दस्तावेज़ गुण निम्नलिखित हैं:

- सिस्टम द्वारा परिभाषित (Built-in) गुण
- उपयोगकर्ता द्वारा परिभाषित (Custom) गुण

**Built-in** गुण दस्तावेज़ के सामान्य जानकारी जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ सांख्यिकी आदि शामिल करते हैं। **Custom** गुण वे होते हैं जो उपयोगकर्ता द्वारा **Name/Value** जोड़े के रूप में परिभाषित किए जाते हैं, जहाँ नाम और मान दोनों उपयोगकर्ता द्वारा निर्धारित होते हैं। Aspose.Slides for C++ का उपयोग करके डेवलपर Built-in गुणों और Custom गुणों दोनों के मानों को एक्सेस और संशोधित कर सकते हैं। Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों को प्रबंधित करने की सुविधा देता है। आपको केवल Office आइकन पर क्लिक करना है और फिर Microsoft PowerPoint 2007 में **Prepare | Properties | Advanced Properties** मेनू आइटम चुनना है। **Advanced Properties** मेनू आइटम चुनने के बाद, एक संवाद बॉक्स दिखाई देगा जो PowerPoint फ़ाइल के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है। **Properties Dialog** में आप देखेंगे कि कई टैब पेज हैं जैसे **General, Summary, Statistics, Contents and Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों के कस्टम गुणों को प्रबंधित करने के लिए उपयोग किया जाता है।

## **एनक्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक ओपनिंग पासवर्ड सामान्यतः प्रस्तुति की सामग्री और दस्तावेज़ गुण दोनों को सुरक्षित करता है। जब प्रस्तुति को `false` पास करके [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) के साथ एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रह जाते हैं। फिर कोई एप्लिकेशन `true` को [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) में पास कर सकता है और ओपनिंग पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडाटा को पढ़ सकता है।

`set_OnlyLoadDocumentProperties` यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कोई डिक्रिप्शन नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल होगा। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

निम्नलिखित उदाहरण [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) के माध्यम से लोडिंग मोड की जाँच करता है और फिर [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_documentproperties/) के द्वारा Built-in गुणों को पढ़ता है:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर, लेआउट, शेप्स, मीडिया और अन्य प्रस्तुति ऑब्जेक्ट उपलब्ध नहीं होते। एप्लिकेशन को हमेशा `get_IsOnlyDocumentPropertiesLoaded` की जाँच करनी चाहिए इससे पहले कि वह ऐसी ऑपरेशन करे जिसके लिए पूरी प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="चेतावनी" %}}
सार्वजनिक मेटाडाटा लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मान उजागर कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। इन्हें सार्वजनिक केवल तभी रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़-प्रबंधन प्रणालियों को पासवर्ड के बिना एक्सेस करने की विशेष आवश्यकता हो।
{{% /alert %}}

## **एनक्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, `set_OnlyLoadDocumentProperties(true)` कॉल करने के बाद लोड की गई प्रस्तुति सार्वजनिक मेटाडाटा पढ़ने के उद्देश्य से होती है। Aspose.Slides उस केवल‑मेटाडाटा ऑब्जेक्ट से बदले हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के अंदर के संबंधित डेटा के साथ संगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिए सही ओपनिंग पासवर्ड और पूरी लोड आवश्यक है।

निम्नलिखित उदाहरण [LoadOptions::set_Password](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_password/) के साथ प्रस्तुति खोलता है, सार्वजनिक Built-in गुणों को अपडेट करता है, और परिणाम सहेजता है। फिर यह [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) का उपयोग करके एन्क्रिप्शन सुरक्षित है या नहीं, इसकी पुष्टि करता है और पासवर्ड के बिना सार्वजनिक मेटाडाटा को पुनः खोलता है ताकि नए मानों की जाँच की जा सके:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

यदि किसी एप्लिकेशन को प्रस्तुति की सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **Built-in गुणों तक पहुंचें**

**IDocumentProperties** ऑब्जेक्ट द्वारा प्रदर्शित इन गुणों में शामिल हैं: **Creator(Author)**, **Description**, **KeyWords**, **Created** (निर्माण तिथि), **Modified** (संशोधन तिथि), **Printed** (अंतिम प्रिंट तिथि), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या अलग‑अलग उत्पादकों के बीच साझा है?), **PresentationFormat**, **Subject** तथा **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Built-in गुणों को संशोधित करें**

प्रस्तुति फ़ाइलों के Built-in गुणों को संशोधित करना उन्हें एक्सेस करने जितना ही आसान है। आप किसी भी इच्छित गुण को सरलता से स्ट्रिंग मान असाइन कर सकते हैं और वह गुण संशोधित हो जाएगा। नीचे दिए गए उदाहरण में हमने दिखाया है कि कैसे प्रस्तुति फ़ाइल के Built-in दस्तावेज़ गुणों को संशोधित किया जा सकता है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **कस्टम प्रस्तुति गुण जोड़ें**

Aspose.Slides for C++ डेवलपर्स को प्रस्तुति दस्तावेज़ गुणों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि प्रस्तुति के लिए कस्टम गुण कैसे सेट किए जा सकते हैं।

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का उदाहरण बनाएं
auto presentation = System::MakeObject<Presentation>();

// दस्तावेज़ गुण प्राप्त करना
auto documentProperties = presentation->get_DocumentProperties();

// कस्टम गुण जोड़ना
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// विशेष सूचकांक पर गुण का नाम प्राप्त करना
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// चयनित गुण हटाना
documentProperties->RemoveCustomProperty(getPropertyName);

// प्रस्तुति सहेजना
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **कस्टम गुणों तक पहुंचें और संशोधित करें**

Aspose.Slides for C++ डेवलपर्स को कस्टम गुणों के मानों तक पहुँचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दर्शाता है कि आप प्रस्तुति के सभी कस्टम गुणों तक कैसे पहुँच सकते हैं और उन्हें कैसे संशोधित कर सकते हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_languageid/) प्रॉपर्टी (जो [PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portionformat/) क्लास द्वारा उजागर की गई है) प्रदान करता है ताकि आप PowerPoint दस्तावेज़ की प्रूफिंग भाषा सेट कर सकें। प्रूफिंग भाषा वह भाषा होती है जिसमें PowerPoint के वर्तनी और व्याकरण की जाँच की जाती है।

यह C++ कोड दर्शाता है कि PowerPoint के लिए प्रूफिंग भाषा कैसे सेट करें:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह C++ कोड दर्शाता है कि पूरे PowerPoint प्रस्तुति की डिफ़ॉल्ट भाषा कैसे सेट करें:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// नई आयत आकार को टेक्स्ट के साथ जोड़ता है
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// पहले भाग की भाषा की जाँच करता है
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **लाइव उदाहरण**

ऑनलाइन ऐप [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) आज़माएँ ताकि आप Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ काम करने का तरीका देख सकें:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से एक Built-in गुण कैसे हटा सकता हूँ?**

Built-in गुण प्रस्तुति का अभिन्न हिस्सा हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशेष गुण की अनुमति देती है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं एक कस्टम गुण जोड़ता हूँ जो पहले से मौजूद है, तो क्या होगा?**

यदि आप एक ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको पहले से गुण को हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

**क्या मैं पूर्ण रूप से प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुंच सकता हूँ?**

हाँ। आप [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग कर सकते हैं और फिर [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) के द्वारा बिना [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस बनाए संग्रहीत दस्तावेज़ मेटाडाटा को पढ़ सकते हैं। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/cpp/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को उसके ओपनिंग पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को `set_EncryptDocumentProperties` में `false` पास करके एन्क्रिप्ट किया गया होना चाहिए, और उसे `set_OnlyLoadDocumentProperties` में `true` पास करके लोड किया जाना चाहिए।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को संगत रहना आवश्यक है, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही ओपनिंग पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।