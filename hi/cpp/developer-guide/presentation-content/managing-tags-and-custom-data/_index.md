---
title: C++ का उपयोग करके प्रस्तुतियों में टैग और कस्टम डेटा प्रबंधित करें
linktitle: टैग और कस्टम डेटा
type: docs
weight: 300
url: /hi/cpp/managing-tags-and-custom-data/
keywords:
- दस्तावेज़ गुण
- टैग
- कस्टम डेटा
- कस्टम XML
- कस्टम XML भाग
- XML मेटाडेटा
- ItemId
- टैग जोड़ें
- युग्म मान
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा को कैसे प्रबंधित करें, जिसमें कस्टम XML भागों को जोड़ना, पढ़ना, अपडेट करना, ऑडिट करना और हटाना शामिल है।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। प्रस्तुतियों‑विशिष्ट डेटा को टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग सरल कुंजी‑मान स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन‑विशिष्ट XML पेलोड्स को संग्रहीत कर सकते हैं।

Aspose.Slides प्रस्तुति, स्लाइड और आकार स्तरों पर कस्टम XML भागों को जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और हटाने के लिए API प्रदान करता है। कस्टम XML भाग उन एकीकरणों के लिए उपयोगी होते हैं जो दस्तावेज‑प्रबंधन पहचानकर्ता, वर्कफ़्लो स्थिति, अनुपालन मेटाडेटा, टेम्प्लेट‑बाइंडिंग डेटा या अन्य संरचित एप्लिकेशन डेटा को प्रस्तुति के अंदर संग्रहीत करते हैं।

## **प्रस्तुति फ़ाइलों में डेटा भंडारण**

PPTX फ़ाइलें — `.pptx` एक्सटेंशन वाली फ़ाइलें — PresentationML प्रारूप में संग्रहीत होती हैं, जो Office Open XML विशिष्टता का हिस्सा है। Office Open XML पैकेज संरचना और संबंधों को परिभाषित करता है जो प्रस्तुति सामग्री और संबंधित डेटा को संग्रहीत करने के लिए उपयोग होते हैं।

एक प्रस्तुति कई भागों से बनी होती है जो संबंधों द्वारा जुड़ी होती हैं। उदाहरण के लिए, एक स्लाइड भाग एकल स्लाइड की सामग्री रखता है और ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट संबंध रख सकता है।

कस्टम डेटा को टैग ([ITagCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itagcollection/)) या कस्टम XML भाग ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/)) के रूप में संग्रहीत किया जा सकता है। दोनों ही [`ICustomData`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomdata/) इंटरफ़ेस के माध्यम से उपलब्ध हैं।

{{% alert color="info" %}}
टैग सरल स्ट्रिंग कुंजी‑मान जोड़े संग्रहीत करता है। कस्टम XML भाग संरचित XML डेटा संग्रहीत करता है और इसे प्रस्तुति, स्लाइड या आकार से संबद्ध किया जा सकता है।
{{% /alert %}}

## **कस्टम XML भागों के साथ काम करना**

[`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomdata/get_customxmlparts/) मेथड किसी विशेष प्रस्तुति ऑब्जेक्ट से जुड़े कस्टम XML भागों का संग्रह लौटाता है। उदाहरण के लिए:

- `presentation->get_CustomData()->get_CustomXmlParts()` में प्रस्तुति स्वयं से जुड़े कस्टम XML भाग होते हैं।
- `slide->get_CustomData()->get_CustomXmlParts()` में किसी विशिष्ट स्लाइड से जुड़े कस्टम XML भाग होते हैं।
- `shape->get_CustomData()->get_CustomXmlParts()` में किसी विशिष्ट आकार से जुड़े कस्टम XML भाग होते हैं।

जब आपको प्रस्तुति में सभी कस्टम XML भागों को देखना हो, चाहे वे जहाँ भी जुड़े हों, तब [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) का उपयोग करें।

### **प्रस्तुति में कस्टम XML भाग जोड़ना**

[`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/add/) का उपयोग करके XML डेटा को कस्टम XML भाग संग्रह में जोड़ा जा सकता है। XML वैध और खाली नहीं होना चाहिए।

नीचे प्रस्तुत स्तर के कस्टम डेटा संग्रह में संरचित मेटाडेटा जोड़ने का उदाहरण है:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add स्वचालित रूप से एक पहचानकर्ता असाइन करता है। केवल तब आवश्यक होने पर एक विशिष्ट GUID सेट करें।
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add` मेथड XML को बाइट एरे या स्ट्रीम के रूप में भी स्वीकार कर सकता है, जो तब उपयोगी होता है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **स्लाइड या आकार में कस्टम XML भाग जोड़ना**

कस्टम XML डेटा को पूरी प्रस्तुति के बजाय किसी विशिष्ट स्लाइड या आकार से जोड़ा जा सकता है। यह तब उपयोगी होता है जब मेटाडेटा केवल एक ऑब्जेक्ट का वर्णन करता है, जैसे टेम्प्लेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता, या बाइंडिंग सूचना।

नीचे एक स्लाइड में एक कस्टम XML भाग और एक आकार में दूसरा जोड़ने का उदाहरण है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस ऑब्जेक्ट के `get_CustomData()->get_CustomXmlParts()` संग्रह में उस भाग का संबंध शामिल रहता है। प्रस्तुति‑स्तर डेटा दस्तावेज‑व्यापी मेटाडेटा के लिए, स्लाइड‑स्तर डेटा किसी विशिष्ट स्लाइड के लिए, और आकार‑स्तर डेटा व्यक्तिगत आकार के लिए उपयुक्त है।

### **सभी कस्टम XML भागों की सूची बनाना और ऑडिट करना**

[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) का उपयोग करके प्रस्तुति से सभी कस्टम XML भाग प्राप्त किए जा सकते हैं। प्रत्येक [`ICustomXmlPart`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/) अपना पहचानकर्ता, XML सामग्री और सम्बंधित नेमस्पेस स्कीमा प्रदर्शित करता है।

नीचे सभी कस्टम XML भागों और उनके नेमस्पेस स्कीमा को सूचीबद्ध करने का उदाहरण है:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी उन प्रस्तुतियों को ऑडिट करने में उपयोगी होती है जिनमें बाहरी सिस्टम द्वारा निर्मित XML शामिल है।

### **XML सामग्री और ItemId पढ़ना और अपडेट करना**

[`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) और `set_XmlAsString` का उपयोग करके XML को UTF-8 स्ट्रिंग के रूप में काम किया जा सकता है, या [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/get_xmldata/) और `set_XmlData` का उपयोग करके कच्चे XML बाइट्स के साथ काम किया जा सकता है। दोनों अभ्यावेदन पढ़े और अपडेट किए जा सकते हैं।

[`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/get_itemid/) मेथड वह GUID लौटाता है जो Office Open XML दस्तावेज़ में कस्टम XML भाग की पहचान करता है। आवश्यक होने पर `set_ItemId` के द्वारा पहचानकर्ता को बदला भी जा सकता है।

नीचे XML सामग्री और पहचानकर्ता को अपडेट करने का उदाहरण है:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// वर्तमान XML को टेक्स्ट के रूप में पढ़ें।
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// XML को UTF-8 स्ट्रिंग के रूप में अपडेट करें।
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData वही XML सामग्री कच्चे बाइट्स के रूप में प्रदान करता है।
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// एकीकरण द्वारा आवश्यक होने पर पहचानकर्ता को बदलें।
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

`set_XmlAsString` या `set_XmlData` के साथ XML असाइन करते समय वैध, खाली नहीं वाला XML प्रदान करें। स्ट्रिंग‑आधारित या बाइट‑आधारित प्रोसेसिंग के अनुसार उपयुक्त अभ्यावेदन चुनें।

### **कस्टम XML भाग हटाना**

Aspose.Slides कस्टम XML डेटा को हटाने के कई तरीके प्रदान करता है:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/remove/) कस्टम XML भाग को प्रस्तुति से हटाता है।
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/remove/) विशिष्ट भाग को कस्टम XML भाग संग्रह से हटाता है।
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/removeat/) निर्दिष्ट संग्रह सूचकांक पर भाग को हटाता है।
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/clear/) किसी विशिष्ट संग्रह से सभी भागों को हटाता है।

नीचे एक प्रस्तुति‑स्तर कस्टम XML भाग को उसके रेफ़रेंस द्वारा हटाने का उदाहरण है:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

यदि आपके पास पहले से `ICustomXmlPart` है और आप उसे प्रस्तुति से हटाना चाहते हैं, तो `customXmlPart->Remove()` को कॉल करें।

एक आयटम को सूचकांक द्वारा भी हटाया जा सकता है:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **संग्रह से सभी कस्टम XML भाग साफ़ करना**

जब किसी विशेष प्रस्तुति ऑब्जेक्ट से जुड़े सभी कस्टम XML भागों को हटाना हो, तो `Clear` का उपयोग करें।

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` केवल चयनित संग्रह को प्रभावित करता है। उदाहरण के लिए, स्लाइड के संग्रह को साफ़ करने से प्रस्तुति‑स्तर या आकार‑स्तर के संग्रह नहीं साफ़ होते।

प्रस्तुति में सभी कस्टम XML भागों को हटाने के लिए `get_AllCustomXmlParts()` पर लूप करें और प्रत्येक भाग को हटाएँ:

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **लिंक्ड या शेयर्ड कस्टम XML भागों को संभालना**

Office Open XML प्रस्तुति में एक ही कस्टम XML भाग कई प्रस्तुति ऑब्जेक्ट्स से संदर्भित हो सकता है। उदाहरण के लिए, एक मौज़ूदा फ़ाइल में कई स्लाइड्स या आकारों से समान कस्टम XML भाग के संबंध हो सकते हैं।

शेयर्ड भाग को कई रेफ़रेंसेज़ वाला एक डेटा ऑब्जेक्ट माना जाना चाहिए:

- `set_XmlAsString`, `set_XmlData` या `set_ItemId` से अपडेट करने पर मूल कस्टम XML भाग बदलता है, इसलिए परिवर्तन सभी रेफ़रेंस पर लागू होता है।
- `get_ItemId()` का उपयोग करके ऑडिट के दौरान समान कस्टम XML भाग की पहचान की जा सकती है।
- किसी विशिष्ट `get_CustomXmlParts()` संग्रह से भाग हटाने से वह केवल उस संग्रह से हटता है। पूर्ण प्रस्तुति से हटाने के लिए `ICustomXmlPart::Remove()` का उपयोग करें।
- शेयर्ड भाग को डिलीट या रिप्लेस करने से पहले ऑब्जेक्ट‑स्तर के संग्रहों की जाँच करें कि अन्य स्लाइड्स या आकार अभी भी इसे संदर्भित करते हैं या नहीं।

`Add` ओवरलोड नई कस्टम XML भाग को XML सामग्री से बनाते हैं; वे मौज़ूदा `ICustomXmlPart` को स्वीकार नहीं करते। इसलिए, शेयर्ड संबंध आमतौर पर उन प्रस्तुतियों को लोड करते समय सामने आते हैं जिनमें पहले से ये संबंध मौजूद होते हैं।

नीचे `ItemId` द्वारा प्रस्तुति‑, स्लाइड‑ और आकार‑स्तर के संग्रहों को ऑडिट करने और एक से अधिक स्थानों से संदर्भित भागों की रिपोर्ट करने का उदाहरण है:

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

यह ऑडिट प्रकार बाहरी सिस्टम द्वारा निर्मित प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी है, क्योंकि समान मेटाडेटा भाग कई संबंधों में भाग ले सकता है।

## **टैग के मान प्राप्त करना**

स्लाइड्स में, एक टैग `IDocumentProperties::get_Keywords` प्रॉपर्टी के समकक्ष होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for C++ के साथ [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) से टैग मान कैसे प्राप्त किया जाता है:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **प्रस्तुतियों में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की सुविधा देता है। एक टैग आमतौर पर दो वस्तुओं से बनता है:

- कस्टम प्रॉपर्टी का नाम, उदाहरण के लिए `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिए `My Tag Value`।

यदि आपको किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों को वर्गीकृत करना है, तो आप इसके लिए टैग जोड़ सकते हैं। उदाहरण के लिए, यदि आप उत्तरी अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक North American टैग बना कर संबंधित देश को उसके मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for C++ का उपयोग करके किसी [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) में टैग कैसे जोड़ें:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

टैग को किसी [Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/) के लिए भी सेट किया जा सकता है:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

या व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/) के लिए:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **सीमाएँ**

`get_CustomData()->get_Tags()` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे प्रस्तुति को PDF के रूप में निर्यात करने पर PDF टैग संरचना में **स्थानांतरित नहीं** होते। इसलिए, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैग्ड PDF से प्राप्त नहीं किया जा सकता।

**वैकल्पिक समाधान**: आप ऑब्जेक्ट के **Alt Text** में कस्टम पहचानकर्ता संग्रहीत कर सकते हैं (उदाहरण के लिए, `shape->set_AlternativeText(u"MyId")`)। PDF निर्यात के बाद, Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में प्रस्तुति, स्लाइड या आकार से सभी टैग हटा सकता हूँ?**

हाँ। [tag collection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/) में एक [Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/clear/) ऑपरेशन उपलब्ध है जो सभी कुंजी‑मान जोड़ों को एक साथ हटाता है।

**मैं पूरे संग्रह को इटरफ़ेट किए बिना किसी टैग को उसके नाम से कैसे हटा सकता हूँ?**

[TagCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/) पर [Remove(name)](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/remove/) का उपयोग करके टैग को उसकी कुंजी से हटाएँ।

**एनालिटिक्स या फ़िल्टरिंग के लिए टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

[tag collection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/) पर [GetNamesOfTags](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/getnamesoftags/) का उपयोग करें; यह सभी टैग नामों का ऐरे लौटाता है।

**मैं सभी कस्टम XML भागों को, चाहे वे जहाँ भी संग्रहीत हों, कैसे खोजूँ?**

[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) का उपयोग करके प्रस्तुति में सभी कस्टम XML भाग प्राप्त करें।

**एक कस्टम XML भाग को अपडेट करने के लिए मुझे `get_XmlAsString`/`set_XmlAsString` या `get_XmlData`/`set_XmlData` में से क्या चुनना चाहिए?**

जब एप्लिकेशन UTF-8 XML टेक्स्ट के साथ काम करता है तो `get_XmlAsString` और `set_XmlAsString` उपयोग करें। जब XML पहले से बाइट एरे के रूप में उपलब्ध हो या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक हो, तब `get_XmlData` और `set_XmlData` उपयोग करें। दोनों अभ्यावेदन एक ही कस्टम XML भाग की XML सामग्री को संदर्भित करते हैं।