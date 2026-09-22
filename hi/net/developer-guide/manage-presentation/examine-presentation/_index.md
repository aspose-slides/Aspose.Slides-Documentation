---
title: .NET में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/net/examine-presentation/
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
- .NET
- C#
- Aspose.Slides
description: ".NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें ताकि तेज़ अंतर्दृष्टि और स्मार्ट सामग्री ऑडिट प्राप्त हो सके।"
---
## **सारांश**

Aspose.Slides किसी प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके दस्तावेज़ मेटाडेटा को पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करना, एक इन्वेंटरी बनाना, या प्रस्तुति की सामग्री को लोड और प्रोसेस करने का निर्णय लेने से पहले गुणों की जाँच करना हो।

यह लेख हल्के निरीक्षण को [PresentationFactory](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/) और [IPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/) के माध्यम से दर्शाता है, तथा लक्षित अपडेट को [IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) के माध्यम से दिखाता है।

## **प्रेज़ेंटेशन फ़ॉर्मेट जांचें**

यदि आपके पास पहले से लोड की गई प्रस्तुति है, तो लोड करने के बाद पहचान और लेगेसी PPT, PPS, और POT स्ट्रीम की सीमाओं के लिए [Determine the Original Presentation Format](/slides/hi/net/detect-presentation-source-format/) देखें।

फ़ाइल को जांचने के लिए बिना कोई [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस बनाए, [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करें। [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/loadformat/) प्रॉपर्टी पता लगाए गए फ़ॉर्मेट को दर्शाती है, जैसे PPTX, PPT या ODP।

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **हल्की प्रस्तुति इन्वेंटरी बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो सत्यापन, अनुक्रमण या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक संक्षिप्त इन्वेंटरी की आवश्यकता हो सकती है। इस स्थिति में, [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करके एक [IPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर दस्तावेज़ मेटाडेटा पढ़ने के लिए [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) को कॉल करें। इस विधि से कोई [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस नहीं बनता और आपको पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को पार करने की आवश्यकता नहीं होती।

विस्तारित प्रॉपर्टीज़ जो [IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) द्वारा प्रदान की गई हैं, निम्नलिखित इन्वेंटरी मान देती हैं:

| प्रॉपर्टी | इन्वेंटरी मान |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/slides/hi/) | कुल स्लाइडों की संख्या। |
| [HiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/hiddenslides/) | छिपी हुई स्लाइडों की संख्या। |
| [Notes](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/notes/) | नोट्स वाली स्लाइडों की संख्या। |
| [Paragraphs](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/paragraphs/) | उपलब्ध होने पर कुल पैराग्राफ़ की संख्या। |
| [Words](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/words/) | कुल शब्दों की संख्या। |
| [MultimediaClips](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/multimediaclips/) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को बिना कोई [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक संक्षिप्त इन्वेंटरी प्रदर्शित करता है। यह [HeadingPairs](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/headingpairs/) को [TitlesOfParts](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/titlesofparts/) के साथ मिलाकर फ़ॉन्ट्स, थीम्स और स्लाइड शीर्षकों जैसे कंटेंट ग्रुप्स दिखाता है।

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

प्रत्येक [IHeadingPair](https://reference.aspose.com/slides/hi/net/aspose.slides/iheadingpair/) एक समूह का नाम और उस समूह में आइटम्स की संख्या प्रदान करता है। [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/titlesofparts/) एक फ्लैट, क्रमबद्ध एरे है, इसलिए प्रत्येक हेडिंग पेयर द्वारा निर्दिष्ट निरंतर शीर्षकों की संख्या का उपयोग करें।

### **संग्रहित मेटाडेटा और फ़ॉर्मेट सीमाएँ**

जो इन्वेंटरी प्रॉपर्टीज़ [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) द्वारा लौटाई जाती हैं, स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को दर्शाते हैं। Aspose.Slides प्रस्तुति ऑब्जेक्ट मॉडल को लोड और पार नहीं करता ताकि इस कॉल के लिए इन मानों की पुनः गणना की जा सके। अनुपलब्ध प्रॉपर्टीज़ डिफ़ॉल्ट मानों द्वारा दर्शाई जाती हैं, और संग्रहीत मान पुराने हो सकते हैं यदि अंतिम बार फ़ाइल सहेजने वाले अनुप्रयोग ने अपने डॉक्यूमेंट प्रॉपर्टीज़ को अपडेट नहीं किया।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी स्लाइड, पैराग्राफ, शब्द, और मल्टीमीडिया गिनती के लिए विस्तारित डॉक्यूमेंट प्रॉपर्टीज़ प्रदान करता है, साथ ही हेडिंग पेयर और पार्ट शीर्षक। उपलब्धता इस पर निर्भर करती है कि डॉक्यूमेंट निर्माता ने कौन सी प्रॉपर्टीज़ लिखी हैं।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित डॉक्यूमेंट‑समरी प्रॉपर्टीज़ को संग्रहीत कर सकता है। यदि कोई प्रॉपर्टी अनुपलब्ध है या डॉक्यूमेंट निर्माता द्वारा रिफ्रेश नहीं हुई है, तो Aspose.Slides उसके संग्रहीत या डिफ़ॉल्ट मान को लौटाता है न कि स्लाइड्स से गणना करके।
- **ODP:** OpenDocument मेटाडेटा सामान्य डॉक्यूमेंट आँकड़े जैसे पेज, पैराग्राफ और शब्द गिनती प्रदान करता है, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित प्रॉपर्टी से मेल नहीं खाते। छिपी स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर, और पार्ट‑टाइटल मेटाडेटा उपलब्ध नहीं हो सकता, और इन्वेंटरी प्रॉपर्टीज़ डिफ़ॉल्ट मान लौट सकती हैं। शून्य मान या खाली एरे को इस बात का प्रमाण न मानें कि संबंधित कंटेंट अनुपस्थित है।

इन्वेंटरी और प्रारम्भिक जाँचों के लिए हल्के मेटाडेटा दृष्टिकोण का उपयोग करें। जब परिणाम को मेमोरी‑में किए गए बदलावों को दर्शाना हो या वास्तविक प्रस्तुति सामग्री की पुष्टि करनी हो, तब प्रस्तुति को लोड करके उसके लाइव ऑब्जेक्ट मॉडल की जाँच करें।

## **प्रेज़ेंटेशन प्रॉपर्टीज़ अपडेट करें**

जो प्रॉपर्टीज़ [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) द्वारा लौटाई जाती हैं, उन्हें भी बिना कोई [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस बनाए बदला जा सकता है। बदलावों को लागू करने के लिए [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) उपयोग करें, और फिर बंधी हुई प्रस्तुति को [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/writebindedpresentation/) के साथ लिखें।

निम्न छवि मूल दस्तावेज़ प्रॉपर्टीज़ को दर्शाती है।

![PowerPoint प्रस्तुति की मूल दस्तावेज़ प्रॉपर्टीज़](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑सेव किए समय को बदलता है और परिणाम को नई फ़ाइल में लिखता है:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

![PowerPoint प्रस्तुति की बदली हुई दस्तावेज़ प्रॉपर्टीज़](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जांच और सुरक्षा सेटिंग्स के लिए निम्न लेख देखें:

- [प्रेज़ेंटेशन्स को पासवर्ड‑प्रोटेक्ट करें](/slides/hi/net/password-protected-presentation/)
- [प्रेज़ेंटेशन्स को राइट‑प्रोटेक्ट करें](/slides/hi/net/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जांच सकता हूँ कि फ़ॉन्ट्स एम्बेडेड हैं और कौन से हैं?**

प्रेज़ेंटेशन को लोड करें और [Presentation.FontsManager](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/fontsmanager/) का उपयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getembeddedfonts/) कॉल करें और प्रेज़ेंटेशन द्वारा उपयोग किए गए फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager.GetFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getfonts/) कॉल करें। रेंडरिंग के लिए आवश्यक लेकिन एम्बेडेड न होने वाले फ़ॉन्ट्स को खोजने के लिए दोनों परिणामों की तुलना करें।

**मैं जल्दी से कैसे पता कर सकता हूँ कि फ़ाइल में छिपी स्लाइड्स हैं और उनकी संख्या क्या है?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) और [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) के माध्यम से [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/hiddenslides/) पढ़ें। यह हल्की इन्वेंटरी के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा गायब या पुराना हो सकता है, या आपको लाइव मानों की जाँच करनी हो, तो [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slides/hi/) के माध्यम से इटररेट करके प्रत्येक स्लाइड की [Slide.Hidden](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/hidden/) प्रॉपर्टी की जाँच करें।

**क्या मैं पता कर सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में है या नहीं, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हाँ। प्रेज़ेंटेशन को लोड करें और [Presentation.SlideSize](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slidesize/) पढ़ें। वर्तमान सेटिंग्स की तुलना पूर्वनिर्धारित मानों और आयामों से करने के लिए [ISlideSize.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/hi/net/aspose.slides/islidesize/size/), और [ISlideSize.Orientation](https://reference.aspose.com/slides/hi/net/aspose.slides/islidesize/orientation/) की जाँच करें।

**क्या चार्ट्स के बाहरी डेटा स्रोतों को संदर्भित करने का त्वरित तरीका है?**

हाँ। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/) को खोजें और [ChartData.DataSourceType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/datasourcetype/) की जाँच करें। यदि वह बाहरी वर्कबुक है, तो [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) पढ़ें। डेटा स्रोत प्रकार और पथ एक बाहरी रेफ़रेंस दर्शाते हैं, लेकिन यह सत्यापित करने के लिए कि लक्ष्य उपलब्ध है या नहीं, एक अलग संसाधन जाँच आवश्यक है।

**मैं 'भारी' स्लाइड्स को कैसे आकलन करूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता प्रॉपर्टी नहीं है। [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slides/hi/) और प्रत्येक स्लाइड की [IBaseSlide.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/shapes/) संग्रह को पार करें। आकार गिनती और बड़ी इमेजेज़, इफ़ेक्ट्स, एनीमेशन या मल्टीमीडिया की उपस्थिति को संकेतक के रूप में उपयोग करें, और स्लाइड को निश्चित प्रदर्शन बाधा मानने से पहले प्रतिनिधिवादी रेंडर या एक्सपोर्ट को मापें।