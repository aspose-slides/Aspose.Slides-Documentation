---
title: C++ का उपयोग करके प्रस्तुतियों में टैग और कस्टम डेटा का प्रबंधन
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
- जोड़ी मान
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों में टैग और कस्टम XML डेटा को प्रबंधित करना सीखें, जिसमें कस्टम XML भाग जोड़ना, पढ़ना, अद्यतित करना, ऑडिट करना और हटाना शामिल है।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides PowerPoint प्रस्तुतियों में टैग और कस्टम डेटा के साथ कैसे काम करता है। प्रस्तुति‑विशिष्ट डेटा को टैग या कस्टम XML भागों के रूप में संग्रहीत किया जा सकता है। टैग सरल कुंजी‑मान स्ट्रिंग जोड़े होते हैं, जबकि कस्टम XML भाग संरचित मेटाडेटा और एप्लिकेशन‑विशिष्ट XML पेलोड संग्रहीत कर सकते हैं।

Aspose.Slides प्रस्तुतियों, स्लाइड और आकार स्तरों पर कस्टम XML भागों को जोड़ने, पढ़ने, अपडेट करने, ऑडिट करने और हटाने के लिए API प्रदान करता है। कस्टम XML भाग उन एकीकरणों के लिए उपयोगी हैं जो दस्तावेज‑प्रबंधन पहचानकर्ताओं, कार्य‑प्रवाह स्थिति, अनुपालन मेटाडेटा, टेम्प्लेट‑बाइंडिंग डेटा, या अन्य संरचित एप्लिकेशन डेटा जैसी जानकारी को प्रस्तुति के भीतर संग्रहीत करते हैं।

## **प्रस्तुति फ़ाइलों में डेटा संग्रह**

PPTX फ़ाइलें—`.pptx` एक्स्टेंशन वाली फ़ाइलें—PresentationML स्वरूप में संग्रहीत होती हैं, जो Office Open XML विनिर्देशन का हिस्सा है। Office Open XML पैकेज संरचना और संबंधों को परिभाषित करता है जो प्रस्तुति सामग्री और संबंधित डेटा को संग्रहीत करने के लिए उपयोग होते हैं।

एक प्रस्तुति में कई भाग होते हैं जो संबंधों द्वारा जुड़े होते हैं। उदाहरण के लिए, एक स्लाइड भाग में एकल स्लाइड की सामग्री होती है और उसे ISO/IEC 29500 द्वारा परिभाषित अन्य भागों के साथ स्पष्ट संबंध हो सकते हैं।

कस्टम डेटा को टैग ([ITagCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itagcollection/)) या कस्टम XML भाग ([ICustomXmlPartCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/)) के रूप में संग्रहीत किया जा सकता है। दोनों ही [`ICustomData`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomdata/) इंटरफ़ेस के माध्यम से उपलब्ध हैं।

{{% alert color="primary" %}}

टैग सरल स्ट्रिंग कुंजी‑मान जोड़े संग्रहीत करते हैं। कस्टम XML भाग संरचित XML डेटा संग्रहीत करते हैं और उन्हें प्रस्तुति, स्लाइड या आकार के साथ जोड़ा जा सकता है।

{{% /alert %}}

## **कस्टम XML भागों के साथ कार्य करना**

[`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomdata/get_customxmlparts/) विधि उस प्रस्तुति वस्तु से जुड़े कस्टम XML भागों के संग्रह को लौटाती है। उदाहरण के रूप में:

- `presentation->get_CustomData()->get_CustomXmlParts()` में स्वयं प्रस्तुति से जुड़े कस्टम XML भाग शामिल होते हैं।
- `slide->get_CustomData()->get_CustomXmlParts()` में किसी विशिष्ट स्लाइड से जुड़े कस्टम XML भाग शामिल होते हैं।
- `shape->get_CustomData()->get_CustomXmlParts()` में किसी विशिष्ट आकार से जुड़े कस्टम XML भाग शामिल होते हैं।

जब आपको प्रस्तुति में सभी कस्टम XML भागों को निरीक्षण करना हो, चाहे वे जहाँ भी जुड़े हों, तब आप [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) का उपयोग कर सकते हैं।

### **एक प्रस्तुति में कस्टम XML भाग जोड़ना**

कस्टम XML भाग संग्रह में XML डेटा जोड़ने के लिए आप [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/add/) का उपयोग कर सकते हैं। XML वैध और खाली नहीं होना चाहिए।

निम्न उदाहरण प्रस्तुति‑स्तर के कस्टम डेटा संग्रह में संरचित मेटाडेटा जोड़ता है:

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

// जोड़ने से एक पहचानकर्ता स्वचालित रूप से सौंपा जाता है। केवल आवश्यकता होने पर विशिष्ट GUID सेट करें।
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add` विधि XML को बाइट एरे या स्ट्रीम के रूप में भी स्वीकार कर सकती है, जो तब उपयोगी होता है जब XML सामग्री पहले से बाइनरी रूप में उपलब्ध हो।

### **एक स्लाइड या आकार में कस्टम XML भाग जोड़ना**

कस्टम XML डेटा को संपूर्ण प्रस्तुति के बजाय किसी विशिष्ट स्लाइड या आकार के साथ जोड़ा जा सकता है। यह उपयोगी है जब मेटाडेटा केवल एक वस्तु का वर्णन करता है, जैसे टेम्प्लेट कुंजी, बाहरी रिकॉर्ड पहचानकर्ता, या बाइंडिंग जानकारी।

निम्न उदाहरण एक स्लाइड में एक कस्टम XML भाग और एक आकार में另 एक कस्टम XML भाग जोड़ता है:

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

जिस स्तर पर भाग जोड़ा जाता है, वह निर्धारित करता है कि किस वस्तु के `get_CustomData()->get_CustomXmlParts()` संग्रह में उस भाग का संबंध मौजूद है। प्रस्तुति‑स्तर का डेटा दस्तावेज‑व्यापी मेटाडेटा के लिए उपयुक्त है, स्लाइड‑स्तर का डेटा किसी विशेष स्लाइड की जानकारी के लिए, और आकार‑स्तर का डेटा व्यक्तिगत आकार से जुड़े मेटाडेटा के लिए।

### **सभी कस्टम XML भागों की सूची बनाना और ऑडिट करना**

सभी कस्टम XML भागों को प्राप्त करने के लिए आप [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) का उपयोग कर सकते हैं। प्रत्येक [`ICustomXmlPart`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/) अपने पहचानकर्ता, XML सामग्री और जुड़े Namespace स्कीमा को उजागर करता है।

निम्न उदाहरण सभी कस्टम XML भागों और उनके Namespace स्कीमा को सूचीबद्ध करता है:

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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) कस्टम XML भाग से जुड़े XML स्कीमा लौटाता है। यह जानकारी तब उपयोगी हो सकती है जब आप उन प्रस्तुतियों का ऑडिट कर रहे हों जिनमें बाहरी सिस्टम द्वारा निर्मित XML शामिल है।

### **XML सामग्री और ItemId को पढ़ना और अपडेट करना**

XML को UTF‑8 स्ट्रिंग के रूप में काम करने के लिए आप [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) और `set_XmlAsString` का उपयोग कर सकते हैं, या कच्चे XML बाइट्स के लिए [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/get_xmldata/) और `set_XmlData` का उपयोग कर सकते हैं। दोनों प्रतिनिधित्व को पढ़ा और अपडेट किया जा सकता है।

[`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/get_itemid/) विधि उस GUID को लौटाती है जो Office Open XML दस्तावेज़ में कस्टम XML भाग को पहचानता है। जब एकीकृत प्रणाली को नया पहचानकर्ता चाहिए, तब `set_ItemId` के साथ इसे बदला भी जा सकता है।

निम्न उदाहरण XML सामग्री और पहचानकर्ता को अपडेट करता है:

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

// वर्तमान XML को पाठ के रूप में पढ़ें।
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

`set_XmlAsString` या `set_XmlData` के साथ XML असाइन करते समय वैध, खाली‑नहीं‑हुआ XML प्रदान करें। वह प्रतिनिधित्व चुनें जो आपके एप्लिकेशन के डेटा प्रकार (स्ट्रिंग या बाइट) के साथ अधिक उपयुक्त हो।

### **एक कस्टम XML भाग को हटाना**

Aspose.Slides कस्टम XML डेटा को हटाने के कई तरीके प्रदान करता है:

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpart/remove/) कस्टम XML भाग को प्रस्तुति से हटाता है।
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/remove/) किसी विशिष्ट भाग को कस्टम XML भाग संग्रह से हटाता है।
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/removeat/) निर्दिष्ट संग्रह इंडेक्स पर स्थित भाग को हटाता है।
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icustomxmlpartcollection/clear/) विशिष्ट संग्रह से सभी भागों को हटाता है।

निम्न उदाहरण रेफ़रेंस द्वारा एक प्रस्तुति‑स्तर का कस्टम XML भाग हटाता है:

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

यदि आपके पास पहले से `ICustomXmlPart` है और आप उस भाग को प्रस्तुति से हटाना चाहते हैं, तो `customXmlPart->Remove()` को कॉल करें।

आप इंडेक्स द्वारा भी एक आइटम हटा सकते हैं:

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **कलेक्शन से सभी कस्टम XML भागों को साफ़ करना**

जब किसी विशेष प्रस्तुति वस्तु से जुड़े सभी कस्टम XML भागों को हटाना हो, तब `Clear` का उपयोग करें।

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

प्रस्तुति में प्रत्येक कस्टम XML भाग को हटाने के लिए `get_AllCustomXmlParts()` पर लूप चलाएँ और प्रत्येक भाग को हटाएँ:

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

### **लिंक्ड या साझा कस्टम XML भागों को संभालना**

Office Open XML प्रस्तुति में, वही कस्टम XML भाग कई प्रस्तुति वस्तुओं द्वारा संदर्भित किया जा सकता है। उदाहरण के तौर पर, एक मौजूदा फ़ाइल में कई स्लाइड या आकार एक ही बुनियादी कस्टम XML भाग के संबंध रख सकते हैं।

एक साझा भाग को कई संदर्भों वाले एक डेटा ऑब्जेक्ट के रूप में माना जाना चाहिए:

- `set_XmlAsString`, `set_XmlData` या `set_ItemId` के साथ इसे अपडेट करने से मूल कस्टम XML भाग बदलता है, इसलिए परिवर्तन जहाँ‑जहाँ वह भाग संदर्भित है, वहाँ लागू होता है।
- `get_ItemId()` का उपयोग ऑब्जेक्ट‑स्तर के संग्रहों को ऑडिट करते समय समान कस्टम XML भाग को पहचानने के लिये किया जा सकता है।
- किसी विशिष्ट `get_CustomXmlParts()` संग्रह से भाग हटाने से वह केवल उस संग्रह से हटता है। जब भाग स्वयं को प्रस्तुति से हटाना हो, तो `ICustomXmlPart::Remove()` का उपयोग करें।
- साझा भाग को हटाने या बदलने से पहले, वस्तु‑स्तर के संग्रहों की जाँच करें कि क्या अन्य स्लाइड या आकार अभी भी उसका संदर्भ रखते हैं।

`Add` ओवरलोड नए XML सामग्री से नया कस्टम XML भाग बनाते हैं; वे मौजूदा `ICustomXmlPart` को स्वीकार नहीं करते। इसलिए साझा संबंध अक्सर उन प्रस्तुतियों में मिलते हैं जिनमें पहले से ये संबंध मौजूद होते हैं।

निम्न उदाहरण `ItemId` द्वारा प्रस्तुति‑, स्लाइड‑ और आकार‑स्तर के संग्रहों को ऑडिट करता है और उन भागों की रिपोर्ट देता है जो एक से अधिक स्थानों से संदर्भित हैं:

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

यह प्रकार का ऑडिट उन प्रस्तुतियों में कस्टम XML डेटा को संशोधित या हटाने से पहले उपयोगी है, जो बाहरी सिस्टम द्वारा बनाई गई हैं, क्योंकि समान मेटाडेटा भाग कई संबंधों में भाग ले सकता है।

## **टैग के मान प्राप्त करना**

स्लाइड में, एक टैग `IDocumentProperties::get_Keywords` प्रॉपर्टी के अनुरूप होता है। यह नमूना कोड दिखाता है कि Aspose.Slides for C++ के साथ [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) से टैग मान कैसे प्राप्त किया जाता है:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **प्रस्तुतियों में टैग जोड़ना**

Aspose.Slides आपको प्रस्तुतियों में टैग जोड़ने की अनुमति देता है। एक टैग आमतौर पर दो भागों से बना होता है:

- कस्टम प्रॉपर्टी का नाम, उदाहरण के लिये `MyTag`;
- कस्टम प्रॉपर्टी का मान, उदाहरण के लिये `My Tag Value`।

यदि आपको किसी विशिष्ट नियम या प्रॉपर्टी के आधार पर प्रस्तुतियों को वर्गीकृत करना है, तो आप उस उद्देश्य के लिये टैग जोड़ सकते हैं। उदाहरण के लिये, यदि आप उत्तरी अमेरिकी देशों की प्रस्तुतियों को वर्गीकृत करना चाहते हैं, तो आप एक “NorthAmerican” टैग बना सकते हैं और संबंधित देश को उसके मान के रूप में असाइन कर सकते हैं।

यह नमूना कोड दिखाता है कि Aspose.Slides for C++ के साथ [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) में टैग कैसे जोड़ा जाता है:

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

टैग को एक [Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slide/) के लिए भी सेट किया जा सकता है:

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

या एक व्यक्तिगत [Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/) के लिए:

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

`get_CustomData()->get_Tags()` संग्रह के माध्यम से जोड़े गए टैग केवल PowerPoint फ़ाइल में संग्रहीत होते हैं। वे प्रस्तुति को PDF में निर्यात करने पर PDF टैग संरचना में **स्थानांतरित नहीं होते**। परिणामस्वरूप, टैग के रूप में असाइन किया गया कस्टम पहचानकर्ता टैगयुक्त PDF से प्राप्त नहीं किया जा सकता।

**वैकल्पिक समाधान**: आप कस्टम पहचानकर्ता को वस्तु के **Alt Text** में संग्रहीत कर सकते हैं (उदाहरण के लिये, `shape->set_AlternativeText(u"MyId")`)। PDF में निर्यात करने के बाद Alt Text PDF टैग संरचना में दिखाई दे सकता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑपरेशन में सभी टैग को प्रस्तुति, स्लाइड या आकार से हटा सकता हूँ?**

हाँ। [tag collection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/) में एक [Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/clear/) ऑपरेशन उपलब्ध है जो सभी कुंजी‑मान जोड़े को एक साथ हटाता है।

**मैं पूरी संग्रह को इटरैट किए बिना किसी एकल टैग को उसके नाम से कैसे हटा सकता हूँ?**

[TagCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/) पर `Remove(name)` का उपयोग करके टैग को उसकी कुंजी से हटाएँ।

**मैं विश्लेषण या फ़िल्टरिंग के लिये सभी टैग नामों की पूरी सूची कैसे प्राप्त करूँ?**

[GetNamesOfTags](https://reference.aspose.com/slides/hi/cpp/aspose.slides/tagcollection/getnamesoftags/) का उपयोग करके टैग संग्रह से सभी टैग नामों की एरे प्राप्त करें।

**मैं सभी कस्टम XML भागों को कैसे खोजूँ, चाहे वे जहाँ भी संग्रहीत हों?**

[`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_allcustomxmlparts/) का उपयोग करके प्रस्तुति में सभी कस्टम XML भाग प्राप्त करें।

**कस्टम XML भाग को अपडेट करने के लिये मुझे `get_XmlAsString`/`set_XmlAsString` या `get_XmlData`/`set_XmlData` में से कौन‑सा उपयोग करना चाहिए?**

जब एप्लिकेशन UTF‑8 XML पाठ के साथ काम करता है, तो `get_XmlAsString` और `set_XmlAsString` उपयोग करें। जब XML पहले से बाइट एरे के रूप में उपलब्ध है या बाइनरी‑उन्मुख प्रोसेसिंग अधिक सुविधाजनक है, तो `get_XmlData` और `set_XmlData` उपयोग करें। दोनों प्रतिनिधित्व एक ही कस्टम XML भाग की सामग्री को दर्शाते हैं।