---
title: ".NET में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें"
linktitle: "प्रस्तुति जानकारी"
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
description: ".NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटा डेटा का अन्वेषण करें, तेज़ अंतर्दृष्टियों और अधिक बुद्धिमान सामग्री ऑडिट के लिए।"
---
## **सारांश**

यह लेख दिखाता है कि Aspose.Slides में प्रस्तुति जानकारी कैसे जांचें। यह समझाता है कि पूरी फ़ाइल लोड किए बिना प्रस्तुति के वर्तमान प्रारूप को कैसे निर्धारित किया जाए, उसकी दस्तावेज़ गुण पढ़ें, और आवश्यकता पड़ने पर उन गुणों को अपडेट करें।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/documentproperties/) APIs पर आधारित हैं और प्रस्तुति मेटा डेटा के साथ काम करने के सामान्य कार्यों को प्रदर्शित करते हैं।

## **प्रस्तुति प्रारूप जाँचें**

किसी प्रस्तुति पर काम करने से पहले, आप यह जानना चाह सकते हैं कि वर्तमान में प्रस्तुति किस प्रारूप (PPT, PPTX, ODP, आदि) में है।

आप प्रस्तुति को लोड किए बिना उसके प्रारूप की जाँच कर सकते हैं। यह C# कोड देखें:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **प्रस्तुति गुण प्राप्त करें**

यह C# कोड दिखाता है कि प्रस्तुति गुण (प्रस्तुति की जानकारी) कैसे प्राप्त करें:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

आप [DocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/documentproperties/#properties) वर्ग के अंतर्गत [गुणों] को देखना चाह सकते हैं।

## **प्रस्तुति गुण अपडेट करें**

Aspose.Slides [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) मेथड प्रदान करता है जो प्रस्तुति गुणों में परिवर्तन करने की अनुमति देता है।

मान लीजिए हमारे पास नीचे दिखाए गए दस्तावेज़ गुणों वाली एक PowerPoint प्रस्तुति है।

![Original document properties of the PowerPoint presentation](input_properties.png)

यह कोड उदाहरण दिखाता है कि कुछ प्रस्तुति गुणों को कैसे संपादित करें:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

दस्तावेज़ गुणों में परिवर्तन के परिणाम नीचे दिखाए गए हैं।

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **उपयोगी लिंक्स**

प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी प्राप्त करने के लिए, आप इन लिंक्स को उपयोगी पा सकते हैं:

- [Password-Protect Presentations](/slides/hi/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/net/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट एम्बेडेड हैं या नहीं और कौन‑से हैं, यह कैसे जाँचें?**

प्रस्तुति स्तर पर [embedded-font information](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getembeddedfonts/) देखें, फिर उन प्रविष्टियों की तुलना [फ़ॉन्ट्स जो वास्तव में सामग्री में उपयोग किए गए हैं](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getfonts/) से करें ताकि रेंडरिंग के लिए महत्वपूर्ण फ़ॉन्ट्स पहचान सकें।

**फ़ाइल में छिपी हुई स्लाइड्स हैं या नहीं और उनकी संख्या कैसे जल्दी पता करें?**

[slide collection](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/) के माध्यम से इटरैट करें और प्रत्येक स्लाइड के [visibility flag](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/hidden/) को जांचें।

**क्या मैं कस्टम स्लाइड आकार और अभिमुखता का पता लगा सकता हूँ, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हां। वर्तमान [slide size](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slidesize/) और अभिमुखता की तुलना मानक प्रीसेट्स से करें; यह प्रिंटिंग और एक्सपोर्ट के व्यवहार का अनुमान लगाने में मदद करता है।

**क्या चार्ट्स बाहरी डेटा स्रोतों को संदर्भित कर रहे हैं, यह जल्दी कैसे देखें?**

हां। सभी [charts](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/) को ट्रैवर्स करें, उनके [data source](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/datasourcetype/) को जांचें, और नोट करें कि डेटा आंतरिक है या लिंक‑आधारित, जिसमें कोई टूटे हुए लिंक भी शामिल हों।

**'भारी' स्लाइड्स का आकलन कैसे करें जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए ऑब्जेक्ट काउंट गिनें और बड़ी इमेजेज़, ट्रांसपेरेंसी, शैडोज़, एनीमेशन और मल्टीमीडिया देखिए; संभावित प्रदर्शन समस्याओं को चिन्हित करने के लिए एक मोटा जटिलता स्कोर असाइन करें।