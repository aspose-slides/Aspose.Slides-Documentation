---
title: .NET में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
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
description: ".NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडाटा को खोजें, ताकि तेज़ अंतर्दृष्टि और अधिक समझदार सामग्री ऑडिट मिल सकें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides में प्रस्तुति जानकारी को कैसे निरीक्षण करें। यह बताता है कि पूरी फ़ाइल लोड किए बिना प्रस्तुति के वर्तमान फ़ॉर्मेट को कैसे निर्धारित करें, उसके दस्तावेज़ गुण पढ़ें, और आवश्यकता पड़ने पर उन गुणों को अपडेट करें।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/documentproperties/) APIs पर आधारित हैं और प्रस्तुति मेटाडाटा के साथ काम करने के सामान्य संचालन दर्शाते हैं।

## **प्रस्तुति फ़ॉर्मेट जाँचें**

प्रस्तुति पर काम करने से पहले, आप यह जानना चाह सकते हैं कि वर्तमान में प्रस्तुति किस फ़ॉर्मेट (PPT, PPTX, ODP, और अन्य) में है।

आप प्रस्तुति को लोड किए बिना उसकी फ़ॉर्मेट जाँच सकते हैं। इस C# कोड को देखें:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **प्रस्तुति गुण प्राप्त करें**

यह C# कोड आपको दिखाता है कि प्रस्तुति गुण (प्रस्तुति के बारे में जानकारी) कैसे प्राप्त करें:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

आप [DocumentProperties वर्ग के तहत गुण](https://reference.aspose.com/slides/hi/net/aspose.slides/documentproperties/#properties) क्लास देखना चाह सकते हैं।

## **प्रस्तुति गुण अपडेट करें**

Aspose.Slides [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) मेथड प्रदान करता है जो आपको प्रस्तुति गुणों में परिवर्तन करने देता है।

मान लीजिए हमारे पास नीचे दिखाए गए दस्तावेज़ गुणों वाले एक PowerPoint प्रस्तुति है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

यह कोड उदाहरण बताता है कि कुछ प्रस्तुति गुणों को कैसे संपादित करें:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

दस्तावेज़ गुणों को बदलने के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति के बदलते दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी प्राप्त करने के लिए, ये लिंक उपयोगी हो सकते हैं:

- [जांचना कि क्या प्रस्तुति एन्क्रिप्टेड है](https://docs.aspose.com/slides/hi/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [जांचना कि क्या प्रस्तुति लिखने से सुरक्षित (केवल पढ़ने योग्य) है](https://docs.aspose.com/slides/hi/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [जांचना कि क्या प्रस्तुति लोड करने से पहले पासवर्ड द्वारा सुरक्षित है](https://docs.aspose.com/slides/hi/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [प्रस्तुति को सुरक्षित करने के लिए उपयोग किए गए पासवर्ड की पुष्टि](https://docs.aspose.com/slides/hi/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जाँच सकता हूँ कि फ़ॉन्ट एंबेडेड हैं और कौन से हैं?**

प्रेजेंटेशन स्तर पर [embedded-font information](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getembeddedfonts/) देखें, फिर उन प्रविष्टियों की तुलना [fonts actually used across content](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getfonts/) के सेट से करें ताकि पता चल सके कि कौन से फ़ॉन्ट रेंडरिंग के लिए महत्वपूर्ण हैं।

**मैं जल्दी से कैसे जान सकता हूँ कि फ़ाइल में छिपे स्लाइड्स हैं और उनकी संख्या कितनी है?**

[slide collection](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/) पर इटरेट करें और प्रत्येक स्लाइड के [visibility flag](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/hidden/) को inspect करें।

**क्या मैं पहचान सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में हैं, और क्या वे डिफॉल्ट से अलग हैं?**

हाँ। वर्तमान [slide size](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slidesize/) और अभिविन्यास की तुलना मानक प्रीसेट्स से करें; यह प्रिंटिंग और निर्यात के लिए व्यवहार का अनुमान लगाने में मदद करता है।

**क्या चार्ट्स बाहरी डेटा स्रोतों को संदर्भित करते हैं, यह देखने का त्वरित तरीका है?**

हाँ। सभी [charts](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/) को ट्रैवर्स करें, उनके [data source](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/datasourcetype/) को जांचें, और नोट करें कि डेटा आंतरिक है या लिंक-आधारित, साथ ही किसी भी टूटे हुए लिंक को।

**मैं 'भारी' स्लाइड्स का आकलन कैसे करूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए, ऑब्जेक्ट काउंट गिनें और बड़े इमेज, ट्रांसपेरेंसी, शैडो, एनीमेशन एवं मल्टीमीडिया देखें; संभावित प्रदर्शन हॉटस्पॉट को चिन्हित करने के लिए एक मोटा जटिलता स्कोर निर्धारित करें।