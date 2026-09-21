---
title: .NET में PDF दस्तावेज़ संपादित करें
linktitle: PDF संपादित करें
type: docs
weight: 65
url: /hi/net/edit-pdf/
keywords:
- PDF संपादित करें
- PDF टेक्स्ट बदलें
- PDF से PPTX
- PPTX से PDF
- .NET
- C#
- Aspose.Slides
description: "C# में PDF दस्तावेज़ों को Aspose.Slides में आयात करके, टेक्स्ट बदलकर, और संशोधित प्रेज़ेंटेशन को PDF में वापस सहेजकर संपादित करें।"
---
## **अवलोकन**

Aspose.Slides for .NET आपको PDF की सामग्री को संपादित करने की अनुमति देता है, इसके पृष्ठों को स्लाइड्स के रूप में आयात करके, प्रेज़ेंटेशन को संशोधित करके, और फिर इसे PDF में निर्यात करके। यह लेख एक सरल टेक्स्ट प्रतिस्थापन दिखाता है। प्रेज़ेंटेशन मेमोरी में रहता है, इसलिए एक मध्यवर्ती PPTX फ़ाइल सहेजना वैकल्पिक है।

## **PDF में टेक्स्ट बदलें**

पृष्ठों को आयात करने के लिए [AddFromPdf](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/addfrompdf/) का उपयोग करें, टेक्स्ट को अद्यतन करने के लिए [ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/replacetext/) और परिणाम को निर्यात करने के लिए [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) का उपयोग करें।

निम्नलिखित उदाहरण अपेक्षा करता है कि `input.pdf` आयात के बाद संपादन योग्य टेक्स्ट के रूप में शब्द "Draft" रखता हो। यह शब्द को "Final" से बदल देता है और `edited.pdf` लिखता है। आयात से पहले प्रारंभिक स्लाइड को साफ़ करने से आउटपुट में अतिरिक्त खाली पृष्ठ नहीं बनता। खोज पूरे शब्दों को समान केस के साथ मिलाती है; `null` का अर्थ है कोई परिणाम कॉलबैक आवश्यक नहीं है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

अधिक विकल्पों के लिए, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/net/search-and-replace-text/) और [PowerPoint को PDF में बदलें](/slides/hi/net/convert-powerpoint-to-pdf/)।

{{% alert color="info" title="Note" %}}
टेक्स्ट प्रतिस्थापन आयातित टेक्स्ट पर काम करता है, स्कैन किए गए चित्रों के भीतर के टेक्स्ट पर नहीं। रूपांतरण लेआउट और फॉर्मेटिंग को प्रभावित कर सकता है, इसलिए आउटपुट की समीक्षा करें, विशेष रूप से जब प्रतिस्थापित टेक्स्ट मूल से लंबा हो।
{{% /alert %}}

## **FAQ**

**क्या मुझे PDF निर्यात करने से पहले PPTX फ़ाइल सहेजनी चाहिए?**

नहीं। आप मेमोरी में वही प्रेज़ेंटेशन संपादित और निर्यात कर सकते हैं। केवल तभी PPTX की एक प्रति सहेजें जब आप इसे PowerPoint में जारी रखना चाहते हों; देखें [प्रेज़ेंटेशन सहेजें](/slides/hi/net/save-presentation/)।

**कुछ टेक्स्ट क्यों अपरिवर्तित रह जाता है?**

उदाहरण पूरे शब्द "Draft" को सटीक केस के साथ मिलाता है। टेक्स्ट यदि छवि के रूप में आयात किया गया हो या अलग-अलग टेक्स्ट फ्रेम में विभाजित हो तो खोज के साथ आवश्यक रूप से नहीं मिल सकता। आयातित सामग्री की जाँच करें और अपने दस्तावेज़ के लिए खोज को समायोजित करें।