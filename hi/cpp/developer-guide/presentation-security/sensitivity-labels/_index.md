---
title: C++ में PowerPoint प्रस्तुतियों में संवेदनशीलता लेबल प्रबंधित करें
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/cpp/sensitivity-labels/
keywords:
- संवेदनशीलता लेबल
- Microsoft Purview
- Microsoft Information Protection
- MIP metadata
- सामग्री चिह्नन
- सूचना सुरक्षा
- दस्तावेज़ शासन
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint PPTX प्रस्तुतियों में Microsoft Purview संवेदनशीलता लेबल्स को पढ़ें, जोड़ें, अपडेट करें, हटाएं और माइग्रेट करें।"
---
## **परिचय**

Microsoft Purview संवेदनशीलता लेबल्स संगठनों को दस्तावेज़ों को वर्गीकृत और नियंत्रित करने में मदद करते हैं। स्वचालित प्रस्तुति प्रसंस्करण के दौरान, कोई एप्लिकेशन मौजूदा लेबल को संरक्षित कर सकता है, नीति द्वारा चयनित लेबल लागू कर सकता है, उसकी स्थिति अपडेट कर सकता है, या पुराने Microsoft Information Protection (MIP) वर्कफ़्लो द्वारा लिखे गए लेबल मेटाडेटा को माइग्रेट कर सकता है।

Aspose.Slides आधुनिक संवेदनशीलता लेबल मेटाडेटा को [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) के माध्यम से उजागर करता है। यह विधि एक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/) लौटाती है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले निरीक्षण और संशोधित किया जा सकता है।

{{% alert color="info" title="Note" %}}
संवेदनशीलता लेबल पहचानकर्ता और नीति जानकारी आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा परिभाषित की जाती है। मेटाडेटा जोड़ने या माइग्रेट करने से पहले अपने वातावरण में लेबल उपलब्धता और नीति आवश्यकताओं को सत्यापित करें। [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) मान लेबल से जुड़े सामग्री चिह्नों को वर्णित करते हैं; वे स्वयं स्लाइड्स में दिखाई देने वाला पाठ या आकार नहीं बनाते हैं।
{{% /alert %}}

## **संवेदनशीलता लेबल गुणों को समझें**

प्रत्येक [ISensitivityLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/) में निम्नलिखित मेटाडेटा होता है:

| एक्सेसर | उद्देश्य |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_id/) | Purview नीति में संवेदनशीलता लेबल की पहचान करता है। |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_siteid/) | लेबल नीति से संबद्ध साइट की पहचान करता है। |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | दर्शाता है कि लेबल सक्षम है या नहीं। |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | दर्शाता है कि लेबल हटा दिया गया है। जब हटाने की स्थिति को मेटाडेटा में बनाए रखा जाना हो, तो मान `true` सेट करें। |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | निर्दिष्ट करता है कि लेबल स्वचालित रूप से लागू किया गया था या उपयोगकर्ता के निर्णय के माध्यम से। |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | लेबल से जुड़े सामग्री चिह्न प्रकारों की सूची देता है। |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelassignmenttype/) enumeration बताता है कि लेबल कैसे सौंपा गया:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelassignmenttype/) डिफ़ॉल्ट या स्वचालित रूप से लागू किए गए लेबल को दर्शाता है।
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelassignmenttype/) उपयोगकर्ता के निर्णय के माध्यम से लागू किए गए लेबल को दर्शाता है, जिसमें मैन्युअल, अनुशंसित और अनिवार्य लेबल शामिल हैं।

[SensitivityLabelContentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) enumeration लेबल से जुड़े चिह्न को पहचानता है:

| मान | अर्थ |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट या स्वचालित रूप से लागू किया गया था। |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | हेडर सामग्री चिह्न लेबल से जुड़ा है। |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | फुटर सामग्री चिह्न लेबल से जुड़ा है। |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | वाटरमार्क सामग्री चिह्न लेबल से जुड़ा है। |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | एन्क्रिप्शन सुरक्षा लेबल से जुड़ी है। |

एक ही लेबल के साथ कई चिह्न प्रकार जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबल्स की सूची बनाएं**

[IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) से आधुनिक लेबल संग्रह पढ़ें और उसे क्रमसूची बनाएं। निम्न उदाहरण प्रत्येक लेबल के लिए सभी गुण और सामग्री चिह्न सूचीबद्ध करता है:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **सामग्री चिह्न के साथ संवेदनशीलता लेबल जोड़ें**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/add/) को लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट विधि के साथ उपयोग करें। विधि नया [ISensitivityLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/) लौटाने के बाद, आवश्यक चिह्न मानों को [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) के माध्यम से जोड़ें।

निम्न उदाहरण फ़ूटर और वाटरमार्क चिह्नों के साथ मैन्युअली चयनित लेबल जोड़ता है, और फिर परिणाम को PPTX के रूप में सहेजता है:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **संवेदनशीलता लेबल अपडेट करें**

[ISensitivityLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/) मान उनके getter और setter विधियों के माध्यम से पढ़े/लिखे जा सकते हैं, सिवाय इसके कि [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) द्वारा लौटाए गए संग्रह को उसकी सूची संचालन के माध्यम से संशोधित किया जाता है। आवश्यक लेबल खोजने के बाद, आप उसकी पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट विधि, हटाने की स्थिति और सामग्री चिह्न प्रकारों को अपडेट कर सकते हैं। परिवर्तन स्थायी करने के लिए प्रस्तुति को सहेजें।

निम्न उदाहरण पहले लेबल की सक्षम स्थिति और असाइनमेंट विधि को अपडेट करता है:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **लेबल को हटाए गए रूप में चिह्नित करें**

लेबल हटाने की तथ्य को संरक्षित करने के लिए, लेबल खोजें और [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) को `true` के साथ कॉल करें। इससे लेबल प्रविष्टि बना रहता है जबकि उसकी हटाई गई स्थिति दर्ज होती है। यदि आप आधुनिक संग्रह से प्रविष्टि को पूरी तरह हटाना चाहते हैं, तो [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/removeat/) का उपयोग करें; सभी प्रविष्टियों को हटाने के लिए [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/clear/) का उपयोग करें।

निम्न उदाहरण एक विशिष्ट लेबल को हटाए गए रूप में चिह्नित करता है और अद्यतन प्रस्तुति को सहेजता है:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **पुराने MIP संवेदनशीलता लेबल्स को पढ़ें और माइग्रेट करें**

पुराने MIP-आधारित वर्कफ़्लो संवेदनशीलता लेबल मेटाडेटा को कस्टम दस्तावेज़ गुणों में आधुनिक लेबल संग्रह के बजाय संग्रहीत कर सकते हैं। इस मेटाडेटा को [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) से पढ़ें। यह विधि पुराने कस्टम गुणों को पार्स करती है और [ISensitivityLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/) ऑब्जेक्ट्स की एक सरणी लौटाती है।

मेटाडेटा को माइग्रेट करने के लिए, प्रत्येक लौटाए गए लेबल को [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/add/) के माध्यम से आधुनिक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/) में जोड़ें। चूँकि दोहराए गए लेबल पहचानकर्ता जोड़ने पर अपवाद उत्पन्न होता है, उदाहरण प्रतिलिपि से पहले लक्ष्य संग्रह की जाँच करता है। आप अतिरिक्त सत्यापन जोड़ सकते हैं ताकि प्रत्येक पुराने लेबल अभी भी वर्तमान Purview नीति में मौजूद हो।

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

माइग्रेशन पार्स किए गए लेबल ऑब्जेक्ट्स को आधुनिक संग्रह में कॉपी करता है। इसे सभी कस्टम दस्तावेज़ गुणों को साफ़ करने की आवश्यकता नहीं होती, इसलिए असंबंधित दस्तावेज़ मेटाडेटा अपरिवर्तित रहता है। आधुनिक लेबल मेटाडेटा को PPTX फ़ाइल में लिखने के लिए [IPresentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/save/) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) के साथ उपयोग करें।

## **बारंबार पूछे जाने वाले प्रश्न**

**क्या सामग्री चिह्न प्रकार जोड़ने से स्लाइड्स पर दृश्यमान हेडर, फुटर या वाटरमार्क बनता है?**

नहीं। [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) के माध्यम से जोड़े गए मान केवल संवेदनशीलता लेबल से जुड़े चिह्नों का वर्णन करते हैं। वे प्रस्तुति में दिखाई देने वाले पाठ या आकार नहीं बनाते। यदि आपके वर्कफ़्लो को इन चिह्नों को प्रदर्शित करना आवश्यक है, तो संबंधित स्लाइड सामग्री को अलग से जोड़ें।

**लेबल को हटाए गए रूप में चिह्नित करने और संग्रह से हटाने में क्या अंतर है?**

[ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) को `true` के साथ कॉल करने से लेबल प्रविष्टि बनी रहती है और उसकी हटाई गई स्थिति दर्ज होती है। [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/removeat/) को कॉल करने से प्रविष्टि आधुनिक संग्रह से पूरी तरह हट जाती है। अपने संगठन की मेटाडेटा प्रतिधारण आवश्यकताओं के अनुसार उपयुक्त प्रक्रिया चुनें।

**क्या कोई प्रस्तुति दोनों—पुराने MIP मेटाडेटा और आधुनिक संवेदनशीलता लेबल्स—को रख सकती है?**

हां। पुराने लेबल कस्टम दस्तावेज़ गुणों में बने रह सकते हैं, जबकि आधुनिक लेबल [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) के माध्यम से उपलब्ध होते हैं। पुराने मेटाडेटा को पढ़ने और केवल उन वैध लेबल्स को माइग्रेट करने के लिए जो पहले से आधुनिक संग्रह में नहीं हैं, [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) का उपयोग करें।

**एक ही पहचानकर्ता वाले लेबल को कई बार जोड़ने से क्या होता है?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/add/) संग्रह में समान पहचानकर्ता वाले लेबल की मौजूदगी पर एक आर्ग्यूमेंट एक्सेप्शन फेंकता है। लेबल या माइग्रेट करने से पहले मौजूद [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_id/) मानों की जाँच करें।

**अपडेट किए गए संवेदनशीलता लेबल्स को संरक्षित करने के लिए किस आउटपुट फ़ॉर्मेट का उपयोग किया जाना चाहिए?**

प्रस्तुति को PPTX के रूप में सहेजें, इसके लिए [IPresentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/save/) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) के साथ कॉल करें, जैसा कि ऊपर के उदाहरणों में दिखाया गया है।