---
title: PowerPoint प्रस्तुतियों में .NET के साथ संवेदनशीलता लेबल को प्रबंधित करें
linktitle: संवेदनशीलता लेबल
type: docs
weight: 50
url: /hi/net/sensitivity-labels/
keywords:
- संवेदनशीलता लेबल
- Microsoft Purview
- Microsoft Information Protection
- MIP मेटाडाटा
- सामग्री मार्किंग
- सूचना सुरक्षा
- दस्तावेज़ शासन
- PowerPoint
- PPTX
- प्रस्तुति सुरक्षा
- .NET
- C#
- Aspose.Slides
description: "Microsoft Purview संवेदनशीलता लेबल को PowerPoint PPTX प्रस्तुतियों में पढ़ें, जोड़ें, अपडेट करें, हटाएँ और माइग्रेट करें, Aspose.Slides for .NET के साथ।"
---
## **समीक्षा**

Microsoft Purview संवेदनशीलता लेबल संगठनों को दस्तावेज़ों को वर्गीकृत करने और प्रबंधित करने में मदद करते हैं। स्वचालित प्रस्तुति प्रोसेसिंग के दौरान, एक एप्लिकेशन को मौजूदा लेबल को संरक्षित करने, नीति द्वारा चयनित लेबल लागू करने, उसकी स्थिति को अपडेट करने, या पुराने Microsoft Information Protection (MIP) वर्कफ़्लो द्वारा लिखे गए लेबल मेटाडाटा को माइग्रेट करने की आवश्यकता पड़ सकती है।

Aspose.Slides आधुनिक संवेदनशीलता लेबल मेटाडाटा को [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sensitivitylabels/) के माध्यम से उजागर करता है। यह प्रॉपर्टी एक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/) लौटाता है जिसे प्रस्तुति को PPTX के रूप में सहेजने से पहले जाँच और संशोधित किया जा सकता है।

{{% alert color="primary" title="Note" %}}
संवेदनशीलता लेबल पहचानकर्ता और नीति जानकारी आपके Microsoft Purview कॉन्फ़िगरेशन द्वारा परिभाषित की गई है। मेटाडाटा जोड़ने या माइग्रेट करने से पहले अपने वातावरण में लेबल उपलब्धता और नीति आवश्यकताओं को सत्यापित करें। [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) मान लेबल से जुड़े कंटेंट मार्किंग को वर्णित करते हैं; वे स्वयं स्लाइड्स में दिखाई देने वाला टेक्स्ट या आकार नहीं जोड़ते।
{{% /alert %}}

## **संवेदनशीलता लेबल गुणों को समझें**

प्रत्येक [ISensitivityLabel](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/) में निम्नलिखित मेटाडाटा होता है:

| गुण | उद्देश्य |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/id/) | Purview नीति में संवेदनशीलता लेबल की पहचान करता है। |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/siteid/) | लेबल नीति से जुड़ी साइट की पहचान करता है। |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/isenabled/) | बताता है कि लेबल सक्षम है या नहीं। |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/isremoved/) | बताता है कि लेबल हटा दिया गया है। जब मेटाडाटा में हटाने की स्थिति को बनाए रखना हो तो इस प्रॉपर्टी को `true` सेट करें। |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | निर्दिष्ट करता है कि लेबल स्वचालित रूप से या उपयोगकर्ता निर्णय के द्वारा लागू किया गया था। |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) | लेबल से जुड़े कंटेंट मार्किंग प्रकारों की सूची देता है। |

SensitivityLabelAssignmentType एन्नुमरेशन बताता है कि लेबल कैसे असाइन किया गया था:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelassignmenttype/) डिफ़ॉल्ट या स्वचालित रूप से लागू लेबल का प्रतिनिधित्व करता है।
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelassignmenttype/) उपयोगकर्ता निर्णय द्वारा लागू लेबल का प्रतिनिधित्व करता है, जिसमें मैन्युअल रूप से लागू, अनुशंसित और अनिवार्य लेबल शामिल हैं।

SensitivityLabelContentType एन्नुमरेशन लेबल से जुड़ी मार्किंग को पहचानता है:

| मान | अर्थ |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) लेबल डिफ़ॉल्ट या स्वचालित रूप से लागू किया गया था। |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) हेडर कंटेंट मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) फ़ुटर कंटेंट मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) वॉटरमार्क कंटेंट मार्किंग लेबल से जुड़ी है। |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/hi/net/aspose.slides/sensitivitylabelcontenttype/) एन्क्रिप्शन प्रोटेक्शन लेबल से जुड़ी है। |

कई मार्किंग प्रकार एक लेबल से जुड़े हो सकते हैं।

## **मौजूदा संवेदनशीलता लेबल सूचीबद्ध करें**

आधुनिक लेबल संग्रह को [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sensitivitylabels/) से पढ़ें और उसे क्रमबद्ध करें। निम्न उदाहरण प्रत्येक लेबल के लिए संग्रहीत सभी प्रॉपर्टी और कंटेंट मार्किंग को सूचीबद्ध करता है:

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

लेबल पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति और असाइनमेंट मेथड के साथ [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/add/) का उपयोग करें। मेथड नया [ISensitivityLabel](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/) लौटाने के बाद, आवश्यक मार्किंग मानों को [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) के माध्यम से जोड़ें।

निम्न उदाहरण फ़ुटर और वॉटरमार्क मार्किंग से जुड़े मैन्युअल रूप से चयनित लेबल को जोड़ता है और परिणाम को PPTX के रूप में सहेजता है:

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

[ISensitivityLabel](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/) प्रॉपर्टी पढ़ी/लिखी जा सकती हैं, सिवाय इसके कि [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) द्वारा लौटाया गया संग्रह उसकी सूची कार्यों के माध्यम से संशोधित किया जाता है। आवश्यक लेबल का पता लगाने के बाद, आप उसकी पहचानकर्ता, साइट पहचानकर्ता, सक्षम स्थिति, असाइनमेंट मेथड, हटाने की स्थिति और कंटेंट मार्किंग प्रकारों को अपडेट कर सकते हैं। परिवर्तन को स्थायी बनाने के लिए प्रस्तुति को सहेजें।

निम्न उदाहरण पहले लेबल की सक्षम स्थिति और असाइनमेंट मेथड को अपडेट करता है:

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

## **हटाए गए के रूप में चिह्नित करें**

लेबल हटाए जाने की तथ्य को संरक्षित करने के लिए, लेबल खोजें और [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/isremoved/) को `true` सेट करें। यह लेबल प्रविष्टि को बनाए रखता है जबकि उसकी हटाए गए स्थिति को रिकॉर्ड करता है। यदि आपको आधुनिक संग्रह से प्रविष्टि को हटाने की आवश्यकता है, तो [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/removeat/) का उपयोग करें; सभी प्रविष्टियों को हटाने के लिए [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/clear/) का उपयोग करें।

निम्न उदाहरण एक विशिष्ट लेबल को हटाए गए के रूप में चिह्नित करता है और अपडेटेड प्रस्तुति को सहेजता है:

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

## **पुराने MIP संवेदनशीलता लेबल पढ़ें और माइग्रेट करें**

पुरानी MIP-आधारित वर्कफ़्लो आधुनिक लेबल संग्रह के बजाय कस्टम डॉक्युमेंट प्रॉपर्टीज़ में संवेदनशीलता लेबल मेटाडाटा संग्रहीत कर सकती हैं। उस मेटाडाटा को [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/getsensitivitylabels/) के साथ पढ़ें। यह मेथड पुरानी कस्टम प्रॉपर्टीज़ को पार्स करता है और [ISensitivityLabel](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/) ऑब्जेक्ट्स की एक एरे लौटाता है।

मेटाडाटा को माइग्रेट करने के लिए, प्रत्येक लौटाए गए लेबल को [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/add/) के माध्यम से आधुनिक [ISensitivityLabelCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/) में जोड़ें। डुप्लिकेट लेबल पहचानकर्ता जोड़ने पर एक अपवाद उत्पन्न होता है, इसलिए उदाहरण प्रत्येक लेबल को कॉपी करने से पहले गंतव्य संग्रह की जाँच करता है। आप अतिरिक्त सत्यापन जोड़ सकते हैं यह सुनिश्चित करने के लिए कि प्रत्येक लेगेसी लेबल वर्तमान Purview नीति में अभी भी मौजूद है।

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

माइग्रेशन पार्स किए गए लेबल ऑब्जेक्ट्स को आधुनिक संग्रह में कॉपी करता है। यह सभी कस्टम डॉक्युमेंट प्रॉपर्टीज़ को साफ़ करने की आवश्यकता नहीं रखता, इसलिए असंबंधित डॉक्युमेंट मेटाडाटा अपरिवर्तित रहता है। आधुनिक लेबल मेटाडाटा को PPTX फ़ाइल में लिखने के लिए [IPresentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) के साथ उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कंटेंट मार्किंग प्रकार जोड़ने से स्लाइड्स पर दृश्य हेडर, फ़ुटर या वॉटरमार्क बनता है?**

नहीं। [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/contentmarktypes/) के माध्यम से जोड़े गए मान लेबल से जुड़े मार्किंग को वर्णित करते हैं। वे स्वयं प्रस्तुति में दृश्य टेक्स्ट या आकार नहीं बनाते। यदि आपके वर्कफ़्लो को इन मार्किंग को रेंडर करना आवश्यक है तो संबंधित स्लाइड कंटेंट को अलग से जोड़ें।

**हटाए गए के रूप में लेबल को चिह्नित करने और संग्रह से उसे हटाने में क्या अंतर है?**

[ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/isremoved/) को `true` सेट करने से लेबल प्रविष्टि बनी रहती है तथा उसकी हटाए गए स्थिति रिकॉर्ड होती है। [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/removeat/) को कॉल करने से लेबल आधुनिक संग्रह से पूरी तरह हट जाता है। अपनी संगठना की मेटाडाटा प्रतिधारण आवश्यकताओं के अनुसार उपयुक्त कार्य चुनें।

**क्या प्रस्तुति में दोनों, लेगेसी MIP मेटाडाटा और आधुनिक संवेदनशीलता लेबल, हो सकते हैं?**

हां। लेगेसी लेबल कस्टम डॉक्युमेंट प्रॉपर्टीज़ में रह सकते हैं जबकि आधुनिक लेबल [Presentation.SensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sensitivitylabels/) के माध्यम से उपलब्ध होते हैं। लेगेसी मेटाडाटा को पढ़ने और केवल वैध लेबल को माइग्रेट करने के लिए [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/getsensitivitylabels/) का उपयोग करें।

**जब एक ही पहचानकर्ता वाला लेबल कई बार जोड़ा जाता है तो क्या होता है?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabelcollection/add/) तब `ArgumentException` उत्पन्न करता है जब संग्रह में पहले से वही पहचानकर्ता वाला लेबल मौजूद हो। लेबल जोड़ने या माइग्रेट करने से पहले मौजूदा [ISensitivityLabel.Id](https://reference.aspose.com/slides/hi/net/aspose.slides/isensitivitylabel/id/) मानों की जाँच करें।

**अपडेटेड संवेदनशीलता लेबल को संरक्षित करने के लिए कौन सा आउटपुट फॉर्मेट उपयोग किया जाना चाहिए?**

उपरोक्त उदाहरणों में दिखाए अनुसार प्रस्तुति को PPTX के रूप में सहेजें, अर्थात [IPresentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) के साथ कॉल करें।