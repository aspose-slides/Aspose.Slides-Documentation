---
title: PowerPoint प्रस्तुतियों में .NET में संवेदनशीलता लेबल प्रबंधित करें
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/net/sensitivity-labels/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint PPTX प्रस्तुतियों में Microsoft Purview संवेदनशीलता लेबल को पढ़ें, जोड़ें, अपडेट करें, हटाएँ और माइग्रेट करें।"
---
## **अवलोकन**

Microsoft Purview संवेदनशीलता लेबल संगठनों को दस्तावेज़ों को वर्गीकृत करने और उनका शासन करने में मदद करते हैं। स्वचालित प्रस्तुति प्रोसेसिंग के दौरान, एक एप्लिकेशन को मौजूदा लेबल को संरक्षित रखना, नीति द्वारा चयनित लेबल लागू करना, उसकी स्थिति को अपडेट करना, या पुराने Microsoft Information Protection (MIP) वर्कफ़्लो द्वारा लिखे गए लेबल मेटाडेटा को माइग्रेट करना पड़ सकता है।

Aspose.Slides आधुनिक संवेदनशीलता लेबल मेटाडेटा को [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sensitivitylabels/) के माध्यम से उजागर करता है। यह प्रॉपर्टी एक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/) लौटाती है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले निरीक्षण और संशोधित किया जा सकता है।

{{% alert color="info" title="Note" %}}
संवेदनशीलता लेबल पहचानकर्ता और नीति जानकारी आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा परिभाषित होती है। मेटाडेटा जोड़ने या माइग्रेट करने से पहले अपने परिवेश में लेबल की उपलब्धता और नीति की आवश्यकताओं को सत्यापित करें। [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) मान लेबल से जुड़े कंटेंट मार्किंग का वर्णन करते हैं; वे स्वयं स्लाइड्स में दृश्य पाठ या आकार नहीं जोड़ते।
{{% /alert %}}

## **संवेदनशीलता लेबल गुणों को समझें**

प्रत्येक [ISensitivityLabel](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/) में निम्नलिखित मेटाडेटा होते हैं:

| गुण | उद्देश्य |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/id/) | Purview नीति में संवेदनशीलता लेबल की पहचान करता है। |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/siteid/) | लेबल नीति से जुड़ी साइट की पहचान करता है। |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/isenabled/) | बताता है कि लेबल सक्षम है या नहीं। |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/isremoved/) | बताता है कि लेबल हटा दिया गया है। जब हटाने की स्थिति मेटाडेटा में बनी रहनी चाहिए तो इस प्रॉपर्टी को `true` सेट करें। |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | निर्धारित करता है कि लेबल स्वचालित रूप से लागू हुआ या उपयोगकर्ता के निर्णय के द्वारा। |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) | लेबल से जुड़े कंटेंट मार्किंग प्रकारों को सूचीबद्ध करता है। |

[ SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelassignmenttype/) एन्यूमरेशन बताता है कि लेबल कैसे असाइन किया गया:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelassignmenttype/) डिफ़ॉल्ट या स्वचालित रूप से लागू लेबल का प्रतिनिधित्व करता है।
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelassignmenttype/) उपयोगकर्ता के निर्णय के माध्यम से लागू लेबल को दर्शाता है, जिसमें हाथ से लागू, अनुशंसित और अनिवार्य लेबल शामिल हैं।

[ SensitivityLabelContentType](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) एन्यूमरेशन लेबल से जुड़े मार्किंग की पहचान करता है:

| मान | अर्थ |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) | लेबल डिफ़ॉल्ट या स्वचालित रूप से लागू हुआ था। |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) | लेबल से हेडर कंटेंट मार्किंग जुड़ा हुआ है। |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) | लेबल से फुटर कंटेंट मार्किंग जुड़ा हुआ है। |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) | लेबल से वाटरमार्क कंटेंट मार्किंग जुड़ी है। |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) | लेबल से एन्क्रिप्शन सुरक्षा जुड़ी है। |

एक लेबल के साथ कई मार्किंग प्रकार जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबलों की सूची**

आधुनिक लेबल संग्रह को [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sensitivitylabels/) से पढ़ें और उसे क्रमबद्ध करें। निम्न उदाहरण प्रत्येक लेबल के लिए संग्रहीत सभी गुण और कंटेंट मार्किंग को सूचीबद्ध करता है:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **कंटेंट मार्किंग के साथ संवेदनशीलता लेबल जोड़ें**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/add/) को लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट विधि के साथ उपयोग करें। विधि नई [ISensitivityLabel](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/) लौटाने के बाद, आवश्यक मार्किंग मानों को [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) के माध्यम से जोड़ें।

निम्न उदाहरण फुटर और वाटरमार्क मार्किंग से जुड़े हाथ से चयनित लेबल को जोड़ता है, और फिर परिणाम को PPTX के रूप में सहेजता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **संवेदनशीलता लेबल को अपडेट करें**

[ISensitivityLabel](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/) प्रॉपर्टीज़ पढ़ने/लिखने योग्य हैं, सिवाय इसके कि [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) द्वारा लौटाए गए संग्रह को उसकी सूची संचालन के माध्यम से संशोधित किया जाता है। आवश्यक लेबल को खोजने के बाद, आप उसकी पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट विधि, हटाने की स्थिति, और कंटेंट मार्किंग प्रकारों को अपडेट कर सकते हैं। परिवर्तन को स्थायी बनाने के लिए प्रस्तुति को सहेजें।

निम्न उदाहरण पहला लेबल की सक्षम स्थिति और असाइनमेंट विधि को अपडेट करता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **संवेदनशीलता लेबल को हटाया गया चिह्नित करें**

लेबल के हटाए गए होने की तथ्य को संरक्षित रखने के लिए, लेबल खोजें और [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/isremoved/) को `true` सेट करें। यह लेबल प्रविष्टि को बरकरार रखता है जबकि उसकी हटाने की स्थिति को रिकॉर्ड करता है। यदि आपको आधुनिक संग्रह से प्रविष्टि हटानी है, तो [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/removeat/) का उपयोग करें; सभी प्रविष्टियों को हटाने के लिए [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/clear/) इस्तेमाल करें।

निम्न उदाहरण एक विशिष्ट लेबल को हटाया गया चिह्नित करता है और अपडेटेड प्रस्तुति को सहेजता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **पुरानी MIP संवेदनशीलता लेबलों को पढ़ें और माइग्रेट करें**

पुराने MIP-आधारित वर्कफ़्लो संवेदनशीलता लेबल मेटाडेटा को आधुनिक लेबल संग्रह की बजाय कस्टम दस्तावेज़ प्रॉपर्टियों में संग्रहीत कर सकते हैं। इस मेटाडेटा को [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/getsensitivitylabels/) से पढ़ें। यह विधि पुराने कस्टम प्रॉपर्टियों को पार्स करती है और [ISensitivityLabel](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/) ऑब्जेक्ट्स की एक ऐरे वापस करती है।

मेटाडेटा को माइग्रेट करने के लिए, प्रत्येक प्राप्त लेबल को आधुनिक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/) में [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/add/) के द्वारा जोड़ें। डुप्लिकेट लेबल पहचानकर्ता जोड़ने से अपवाद उत्पन्न होता है, इसलिए उदाहरण प्रत्येक लेबल को कॉपी करने से पहले गंतव्य संग्रह की जाँच करता है। आप अतिरिक्त सत्यापन जोड़ सकते हैं यह पुष्टि करने के लिए कि प्रत्येक पुराना लेबल वर्तमान Purview नीति में अभी भी मौजूद है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

माइग्रेशन पार्स किए गए लेबल ऑब्जेक्ट्स को आधुनिक संग्रह में कॉपी करता है। यह सभी कस्टम दस्तावेज़ प्रॉपर्टी को साफ़ करने की आवश्यकता नहीं रखता, इसलिए अनावश्यक दस्तावेज़ मेटाडेटा अपरिवर्तित रहता है। आधुनिक लेबल मेटाडेटा को PPTX फ़ाइल में लिखने के लिए [IPresentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) के साथ उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कंटेंट मार्किंग प्रकार जोड़ने से स्लाइड्स पर एक दृश्य हेडर, फुटर, या वाटरमार्क बनता है?**

नहीं। [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) के माध्यम से जोड़े गए मान लेबल से जुड़े मार्किंग का विवरण देते हैं। वे प्रस्तुति में दृश्य पाठ या आकार नहीं बनाते। यदि आपके वर्कफ़्लो को उन मार्किंग को रेंडर करना आवश्यक है तो संबंधित स्लाइड कंटेंट अलग से जोड़ें।

**लेबल को हटाया गया चिह्नित करने और संग्रह से हटाने में अंतर क्या है?**

[ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/isremoved/) को `true` सेट करने से लेबल प्रविष्टि बनी रहती है और उसकी हटाने की स्थिति रिकॉर्ड होती है। [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/removeat/) को कॉल करने से लेबल आधुनिक संग्रह से हट जाता है। अपनी संगठन की मेटाडेटा रिटेंशन आवश्यकताओं के अनुसार उपयुक्त कार्रवाई चुनें।

**क्या एक प्रस्तुति में पुराना MIP मेटाडेटा और आधुनिक संवेदनशीलता लेबल दोनों हो सकते हैं?**

हां। पुरानी लेबल कस्टम दस्तावेज़ प्रॉपर्टियों में रह सकती हैं जबकि आधुनिक लेबल [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sensitivitylabels/) के माध्यम से उपलब्ध होते हैं। पुराना मेटाडेटा पढ़ने और केवल वैध लेबलों को माइग्रेट करने के लिए [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/getsensitivitylabels/) का उपयोग करें जो पहले से आधुनिक संग्रह में नहीं हैं।

**एक ही पहचानकर्ता वाले लेबल को एक से अधिक बार जोड़ने पर क्या होता है?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/add/) तब `ArgumentException` फेंकता है जब संग्रह में पहले से वही पहचानकर्ता वाला लेबल मौजूद हो। जोड़ने या माइग्रेट करने से पहले मौजूदा [ISensitivityLabel.Id](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/id/) मानों की जाँच करें।

**अपडेटेड संवेदनशीलता लेबल को संरक्षित रखने के लिए किन आउटपुट फ़ॉर्मेट का उपयोग करना चाहिए?**

उपरोक्त उदाहरणों की तरह प्रस्तुति को PPTX के रूप में सहेजें, इसके लिए [IPresentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) के साथ कॉल करें।