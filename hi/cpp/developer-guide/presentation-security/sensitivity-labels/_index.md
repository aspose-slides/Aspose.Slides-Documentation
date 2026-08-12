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
- सामग्री चिन्हांकन
- सूचना संरक्षण
- दस्तावेज़ शासन
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- C++
- Aspose.Slides
description: "Microsoft Purview संवेदनशीलता लेबल को PowerPoint PPTX प्रस्तुतियों में पढ़ें, जोड़ें, अपडेट करें, हटाएँ और माइग्रेट करें, Aspose.Slides for C++ के साथ।"
---
## **अवलोकन**

Microsoft Purview संवेदनशीलता लेबल संस्थानों को दस्तावेज़ों को वर्गीकृत और नियंत्रित करने में सहायता करते हैं। स्वचालित प्रेज़ेंटेशन प्रोसेसिंग के दौरान, एक एप्लिकेशन को मौजूदा लेबल को बनाए रखना, नीति द्वारा चुना गया लेबल लागू करना, उसकी स्थिति को अपडेट करना, या पुराने Microsoft Information Protection (MIP) कार्यप्रवाह द्वारा लिखित लेबल मेटाडाटा को माइग्रेट करना पड़ सकता है।

Aspose.Slides आधुनिक संवेदनशीलता लेबल मेटाडाटा को [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) के माध्यम से उजागर करता है। यह मेथड एक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/) लौटाता है जिसे प्रेज़ेंटेशन को PPTX के रूप में सहेजने से पहले निरीक्षण और संशोधित किया जा सकता है।

{{% alert color="primary" title="Note" %}}
संवेदनशीलता लेबल पहचानकर्ता और नीति जानकारी आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा परिभाषित होते हैं। मेटाडाटा को जोड़ने या माइग्रेट करने से पहले अपने वातावरण में लेबल उपलब्धता और नीति आवश्यकताओं को सत्यापित करें। [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) मान लेबल से जुड़े कंटेंट मार्किंग्स का वर्णन करते हैं; वे स्वयं स्लाइड्स में दृश्यमान टेक्स्ट या आकृतियाँ नहीं जोड़ते हैं।
{{% /alert %}}

## **संवेदनशीलता लेबल गुणों को समझें**

प्रत्येक [ISensitivityLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/) में निम्नलिखित मेटाडाटा शामिल होते हैं:

| एक्सेसर्स | उद्देश्य |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_id/) | Purview नीति में संवेदनशीलता लेबल की पहचान करता है। |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_siteid/) | लेबल नीति से जुड़े साइट की पहचान करता है। |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | निर्दिष्ट करता है कि लेबल सक्षम है या नहीं। |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | सुझाव देता है कि लेबल हटा दिया गया है। जब मेटाडाटा में हटाने की स्थिति को संरक्षित रखना आवश्यक हो तो मान को `true` सेट करें। |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | निर्दिष्ट करता है कि लेबल स्वचालित रूप से लागू हुआ था या उपयोगकर्ता के निर्णय द्वारा। |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | लेबल से जुड़े कंटेंट मार्किंग प्रकारों की सूची देता है। |

[SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelassignmenttype/) एनीयमरेशन यह वर्णन करता है कि लेबल कैसे असाइन किया गया था:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelassignmenttype/) एक डिफ़ॉल्ट या स्वचालित रूप से लागू लेबल को दर्शाता है।
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelassignmenttype/) एक लेबल को दर्शाता है जो उपयोगकर्ता के निर्णय द्वारा लागू होता है, जिसमें मैन्युअल रूप से लागू, अनुशंसित और अनिवार्य लेबल शामिल हैं।

[SensitivityLabelContentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) एनीयमरेशन लेबल से जुड़े मार्किंग को पहचानता है:

| मान | अर्थ |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट या स्वचालित रूप से लागू किया गया था। |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | हेडर कंटेंट मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | फ़ुटर कंटेंट मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | वॉटरमार्क कंटेंट मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sensitivitylabelcontenttype/) | एन्क्रिप्शन सुरक्षा लेबल से जुड़ी है। |

एक लेबल के साथ कई मार्किंग प्रकार जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबलों की सूची**

आधुनिक लेबल संग्रह को [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) से पढ़ें और उसे क्रमबद्ध करें। निम्न उदाहरण प्रत्येक लेबल के लिए संग्रहीत प्रत्येक प्रॉपर्टी और कंटेंट मार्किंग की सूची देता है:

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

## **कंटेंट मार्किंग के साथ संवेदनशीलता लेबल जोड़ें**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/add/) का उपयोग लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट मेथड के साथ करें। मेथड नया [ISensitivityLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/) लौटाने के बाद, आवश्यक मार्किंग मानों को [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) के माध्यम से जोड़ें।

निम्न उदाहरण फ़ुटर और वॉटरमार्क मार्किंग से जुड़ा मैन्युअली चयनित लेबल जोड़ता है, और फिर परिणाम को PPTX के रूप में सहेजता है:

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

## **संवेदनशीलता लेबल को अपडेट करें**

[ISensitivityLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/) मान उनके गेटर और सेटर मेथड्स के माध्यम से पढ़े/लिखे जा सकते हैं, सिवाय इसके कि [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) द्वारा लौटाए गए संग्रह को उसकी सूची संचालन के द्वारा संशोधित किया जाता है। आवश्यक लेबल को खोजने के बाद, आप उसकी पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट मेथड, हटाने की स्थिति और कंटेंट मार्किंग प्रकारों को अपडेट कर सकते हैं। बदलावों को बनाए रखने के लिए प्रेज़ेंटेशन को सहेजें।

निम्न उदाहरण पहले लेबल की सक्षम स्थिति और असाइनमेंट मेथड को अपडेट करता है:

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

## **संवेदनशीलता लेबल को हटाया गया के रूप में चिह्नित करें**

लेबल को हटाने की स्थिति को संरक्षित रखने के लिए, लेबल खोजें और [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) को `true` के साथ कॉल करें। इससे लेबल प्रविष्टि बनी रहती है जबकि उसकी हटाने की स्थिति रिकॉर्ड होती है। यदि आपको आधुनिक संग्रह से प्रविष्टि को पूरी तरह हटाना है, तो [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/removeat/) का उपयोग करें; सभी प्रविष्टियों को हटाने के लिए [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/clear/) का उपयोग करें।

निम्न उदाहरण एक विशिष्ट लेबल को हटाया गया के रूप में चिह्नित करता है और अद्यतन प्रेज़ेंटेशन को सहेजता है:

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

## **पुराने MIP संवेदनशीलता लेबल पढ़ें और माइग्रेट करें**

पुराने MIP‑आधारित कार्यप्रवाह आधुनिक लेबल संग्रह के बजाय कस्टम डॉक्यूमेंट प्रॉपर्टीज़ में संवेदनशीलता लेबल मेटाडाटा रख सकते हैं। इस मेटाडाटा को [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) के साथ पढ़ें। यह मेथड पुरानी कस्टम प्रॉपर्टीज़ को पार्स करता है और [ISensitivityLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/) ऑब्जेक्ट्स की एक सरणी लौटाता है।

मेटाडाटा को माइग्रेट करने के लिए, प्रत्येक लौटाए गए लेबल को [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/add/) के माध्यम से आधुनिक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/) में जोड़ें। डुप्लिकेट लेबल पहचानकर्ता जोड़ने पर अपवाद उत्पन्न होता है, इसलिए उदाहरण प्रत्येक लेबल को कॉपी करने से पहले गंतव्य संग्रह की जाँच करता है। आप अतिरिक्त वैधता भी जोड़ सकते हैं यह पुष्टि करने के लिए कि प्रत्येक पुराना लेबल अभी भी वर्तमान Purview नीति में मौजूद है।

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

माइग्रेशन पार्स किए गए लेबल ऑब्जेक्ट्स को आधुनिक संग्रह में कॉपी करता है। इसे सभी कस्टम डॉक्यूमेंट प्रॉपर्टीज़ को साफ़ करने की आवश्यकता नहीं होती, इसलिए असंबंधित डॉक्यूमेंट मेटाडाटा अपरिवर्तित रहता है। आधुनिक लेबल मेटाडाटा को PPTX फ़ाइल में लिखने के लिए [IPresentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/save/) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) के साथ कॉल करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कंटेंट मार्किंग प्रकार जोड़ने से स्लाइड्स पर दृश्यमान हेडर, फ़ुटर या वॉटरमार्क बनता है?**

नहीं। [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) के माध्यम से जोड़े गए मान लेबल से जुड़ी मार्किंग्स का वर्णन करते हैं। वे स्वयं प्रेज़ेंटेशन में दृश्यमान टेक्स्ट या आकृतियाँ नहीं बनाते। यदि आपका कार्यप्रवाह उन मार्किंग्स को रेंडर करना चाहता है, तो संबंधित स्लाइड कंटेंट को अलग से जोड़ें।

**लेबल को हटाया गया के रूप में चिह्नित करने और संग्रह से हटाने में क्या अंतर है?**

[ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/set_isremoved/) को `true` के साथ कॉल करने से लेबल प्रविष्टि बनी रहती है और उसकी हटाने की स्थिति रिकॉर्ड होती है। [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/removeat/) कॉल करने से लेबल पूरी तरह आधुनिक संग्रह से हट जाता है। अपनी संस्था की मेटाडाटा रखरखाव आवश्यकताओं के अनुसार उपयुक्त ऑपरेशन चुनें।

**क्या एक प्रेज़ेंटेशन में दोनों पुरानी MIP मेटाडाटा और आधुनिक संवेदनशीलता लेबल हो सकते हैं?**

हां। पुरानी लेबल कस्टम डॉक्यूमेंट प्रॉपर्टीज़ में मौजूद रह सकते हैं, जबकि आधुनिक लेबल [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) द्वारा उपलब्ध होते हैं। पुरानी मेटाडाटा पढ़ने और केवल वैध लेबलों को माइग्रेट करने के लिए [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/hi/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) का उपयोग करें।

**जब एक ही पहचानकर्ता वाला लेबल कई बार जोड़ा जाता है तो क्या होता है?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabelcollection/add/) तब तर्कसंगत अपवाद (argument exception) फेंकता है जब संग्रह में पहले से वही पहचानकर्ता वाला लेबल मौजूद हो। लेबल या माइग्रेट करने से पहले मौजूदा [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isensitivitylabel/get_id/) मानों की जाँच करें।

**अद्यतित संवेदनशीलता लेबल को संरक्षित रखने के लिए कौन सा आउटपुट फॉर्मेट उपयोग करना चाहिए?**

उदाहरणों में दिखाए अनुसार प्रेज़ेंटेशन को PPTX के रूप में सहेजें, अर्थात् [IPresentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/save/) को [SaveFormat::Pptx](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) के साथ कॉल करें।