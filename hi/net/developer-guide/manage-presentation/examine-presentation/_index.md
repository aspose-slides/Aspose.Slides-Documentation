---
title: .NET में प्रस्तुति जानकारी पुनः प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/net/examine-presentation/
keywords:
- प्रस्तुति फ़ॉर्मेट
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
description: ".NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड, संरचना और मेटाडेटा का अन्वेषण करें ताकि तेज़ अंतर्दृष्टि और स्मार्ट सामग्री ऑडिट प्राप्त हों।"
---
## **समीक्षा**

Aspose.Slides एक प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना दस्तावेज़ मेटाडेटा पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करना हो, इन्वेंटरी बनानी हो, या सामग्री को लोड और प्रोसेस करने का निर्णय लेने से पहले गुणों की जाँच करनी हो।

यह लेख [PresentationFactory](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/) और [IPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/) के माध्यम से हल्की जाँच, तथा [IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) के माध्यम से लक्षित अपडेट दिखाता है।

## **एक प्रस्तुति फ़ॉर्मेट जांचें**

फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस बनाए बिना जाँचने के लिए [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करें। [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/loadformat/) प्रॉपर्टी पता किए गए फ़ॉर्मेट को रिपोर्ट करती है, जैसे PPTX, PPT, या ODP।

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

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो वैधता, इंडेक्सिंग, या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक कॉम्पैक्ट इन्वेंटरी की आवश्यकता हो सकती है। इस स्थिति में, [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग कर एक [IPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/) ऑब्जेक्ट प्राप्त करें, फिर [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) को कॉल कर दस्तावेज़ मेटाडेटा पढ़ें। यह तरीका [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस नहीं बनाता और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को ट्रैवर्स करने की आवश्यकता नहीं रखता।

[IDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/) द्वारा उजागर विस्तारित गुण निम्नलिखित इन्वेंटरी मान प्रदान करते हैं:

| गुण | इन्वेंटरी मान |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/slides/hi/) | स्लाइडों की कुल संख्या। |
| [HiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/hiddenslides/) | छिपी हुई स्लाइडों की संख्या। |
| [Notes](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/notes/) | नोट्स वाली स्लाइडों की संख्या। |
| [Paragraphs](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/paragraphs/) | उपलब्ध होने पर पैराग्राफों की कुल संख्या। |
| [Words](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/words/) | शब्दों की कुल संख्या। |
| [MultimediaClips](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/multimediaclips/) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) ऑब्जेक्ट बनाए बिना पढ़ता है और एक कॉम्पैक्ट इन्वेंटरी प्रिंट करता है। यह [HeadingPairs](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/headingpairs/) को [TitlesOfParts](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/titlesofparts/) के साथ मिलाकर फ़ॉन्ट, थीम, और स्लाइड शीर्षकों जैसे कंटेंट समूह प्रदर्शित करता है।

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

प्रत्येक [IHeadingPair](https://reference.aspose.com/slides/hi/net/aspose.slides/iheadingpair/) समूह का नाम और उस समूह में आइटमों की संख्या प्रदान करता है। [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/titlesofparts/) एक फ्लैट, क्रमबद्ध एरे है, इसलिए प्रत्येक हेडिंग पैयर द्वारा निर्दिष्ट लगातार शीर्षकों की संख्या को उपभोग करें।

### **संचित मेटाडेटा और फ़ॉर्मेट सीमाएँ**

[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) द्वारा लौटाए गए इन्वेंटरी गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को दर्शाते हैं। Aspose.Slides इस कॉल के लिए इन मानों को पुनःगणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और ट्रैवर्स नहीं करता। अनुपस्थित गुण डिफ़ॉल्ट मानों द्वारा प्रतिनिधित्व किए जाते हैं, और संग्रहीत मान पुराने हो सकते हैं यदि अंतिम बार फ़ाइल सहेजने वाला एप्लिकेशन अपने दस्तावेज़ गुण अपडेट नहीं करता।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपा‑स्लाइड, पैराग्राफ, शब्द, और मल्टीमीडिया गणनाओं के लिए विस्तारित दस्तावेज़ गुण प्रदान करता है, साथ ही हेडिंग पैयर और भाग शीर्षकों को भी। उपलब्धता इस बात पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन‑से गुण लिखे हैं।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित दस्तावेज़‑सारांश गुणों को संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या निर्माता ने उसे रीफ़्रेश नहीं किया है, तो Aspose.Slides संग्रहीत या डिफ़ॉल्ट मान लौटाता है, न कि स्लाइडों से गणना किया हुआ मान।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े प्रदान करता है, जैसे पृष्ठ, पैराग्राफ, और शब्द गणना, लेकिन ये मूल्य हर PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर, और भाग‑शीर्षक मेटाडेटा उपलब्ध नहीं हो सकता, और इन्वेंटरी गुण डिफ़ॉल्ट मान लौटाएंगे। शून्य मान या खाली एरे को यह प्रमाण नहीं मानें कि संबंधित सामग्री अनुपस्थित है।

हल्की मेटाडेटा विधि का उपयोग इन्वेंटरी और प्रारंभिक जाँचों के लिए करें। जब परिणाम को मेमोरी में हुए बदलावों को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री की पुष्टि करनी हो, तब पूर्ण प्रस्तुति लोड कर उसका लाइव ऑब्जेक्ट मॉडल जांचें।

## **प्रस्तुति गुण अपडेट करें**

[IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) द्वारा लौटाए गए गुणों को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस बनाए बिना भी बदला जा सकता है। परिवर्तन को [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) से लागू करें, और फिर बाउंड प्रस्तुति को [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/writebindedpresentation/) से लिखें।

निम्न छवि मूल दस्तावेज़ गुणों को दिखाती है।

![Original document properties of the PowerPoint presentation](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑सहेजा समय बदलता है और परिणाम को नई फ़ाइल में लिखता है:

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

निम्न छवि अपडेट किए गए दस्तावेज़ गुणों को दिखाती है।

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **उपयुक्त लिंक**

संबंधित सुरक्षा जाँच और सुरक्षा सेटिंग्स के लिए, नीचे दिए गए लेख देखें:

- [Password-Protect Presentations](/slides/hi/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/net/write-protected-presentation/)

## **FAQ**

**फ़ॉन्ट एम्बेडेड हैं या नहीं, और कौन‑से हैं, यह कैसे जाँचें?**

प्रस्तुति लोड करें और [Presentation.FontsManager](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/fontsmanager/) का उपयोग करें। एम्बेडेड फ़ॉन्ट प्राप्त करने के लिए [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getembeddedfonts/) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट प्राप्त करने के लिए [FontsManager.GetFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getfonts/) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट की पहचान करें जो रेंडरिंग के लिये आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**फ़ाइल में छिपी स्लाइडें हैं और उनकी संख्या कितनी है, यह जल्दी कैसे पता करें?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) और [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/readdocumentproperties/) के माध्यम से [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/idocumentproperties/hiddenslides/) पढ़ें। यह हल्की इन्वेंटरी के लिये उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा अनुपलब्ध या पुराना हो सकता है; ऐसे में लाइव मानों की पुष्टि के लिये [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slides/hi/) को इटरिटेट कर प्रत्येक स्लाइड के [Slide.Hidden](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/hidden/) गुण की जाँच करें।

**क्या कस्टम स्लाइड आकार और ओरिएंटेशन उपयोग किए गए हैं, और क्या वे डिफ़ॉल्ट से भिन्न हैं, पता चल सकता है?**

हाँ। प्रस्तुति लोड करें और [Presentation.SlideSize](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slidesize/) पढ़ें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रीसेट और आयामों से करने के लिये [ISlideSize.Type](https://reference.aspose.com/slides/hi/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/hi/net/aspose.slides/islidesize/size/), और [ISlideSize.Orientation](https://reference.aspose.com/slides/hi/net/aspose.slides/islidesize/orientation/) की जाँच करें।

**क्या चार्ट बाहरी डेटा स्रोतों को संदर्भित कर रहे हैं, इसे जल्दी कैसे देखें?**

हाँ। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/) को खोजें और [ChartData.DataSourceType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/datasourcetype/) की जाँच करें। यदि बाहरी वर्कबुक है, तो [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/externalworkbookpath/) पढ़ें। डेटा सोर्स टाइप और पाथ बाहरी संदर्भ को दर्शाते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि के लिये अलग संसाधन जाँच आवश्यक है।

**'भारी' स्लाइडें जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं, उन्हें कैसे आँकें?**

कोई एकल जटिलता गुण नहीं है। [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slides/hi/) और प्रत्येक स्लाइड के [IBaseSlide.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/shapes/) कलेक्शन को ट्रैवर्स करें। शAPE काउंट, बड़े इमेज, इफ़ेक्ट, एनीमेशन, या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और प्रतिनिधि रेंडर या एक्सपोर्ट को मापें इससे पहले कि स्लाइड को पुष्टि किए गए प्रदर्शन बोतलबंद के रूप में माना जाए।