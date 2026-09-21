---
title: पाइथन में PDF दस्तावेज़ संपादित करें
linktitle: PDF संपादित करें
type: docs
weight: 65
url: /hi/python-net/edit-pdf/
keywords:
- PDF संपादित करें
- PDF टेक्स्ट बदलें
- PDF से PPTX
- PPTX से PDF
- पाइथन
- Aspose.Slides
description: "पाइथन में Aspose.Slides में आयात करके, टेक्स्ट बदलकर और संशोधित प्रस्तुति को वापस PDF में सहेजकर PDF दस्तावेज़ संपादित करें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET आपको PDF सामग्री को उसकी पृष्ठों को स्लाइड्स के रूप में आयात करके, प्रस्तुति को संशोधित करके और फिर उसे PDF में निर्यात करके संपादित करने की अनुमति देता है। यह लेख एक सरल टेक्स्ट बदलने का उदाहरण दर्शाता है। प्रस्तुति मेमोरी में रहती है, इसलिए मध्यवर्ती PPTX फ़ाइल को सहेजना वैकल्पिक है।

## **PDF में टेक्स्ट बदलें**

पृष्ठों को आयात करने के लिए [add_from_pdf](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_from_pdf/) का उपयोग करें, टेक्स्ट को अपडेट करने के लिए [replace_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/replace_text/) और परिणाम को निर्यात करने के लिए [save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/)।

निम्नलिखित उदाहरण मानता है कि `input.pdf` में आयात के बाद शब्द "Draft" संपादन योग्य टेक्स्ट के रूप में मौजूद है। यह शब्द "Final" से बदलता है और `edited.pdf` लिखता है। आयात से पहले प्रारंभिक स्लाइड को साफ़ करने से आउटपुट में अतिरिक्त खाली पृष्ठ नहीं बनता। खोज पूरे शब्दों को समान केस के साथ मिलाती है; `None` का अर्थ है कि परिणाम कॉलबैक आवश्यक नहीं है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

अधिक विकल्पों के लिए देखें [Search and Replace Text](/slides/hi/python-net/search-and-replace-text/) और [Convert PowerPoint to PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/)।

{{% alert color="info" title="Note" %}}
टेक्स्ट बदलना आयातित टेक्स्ट पर काम करता है, स्कैन की गई छवियों के भीतर के टेक्स्ट पर नहीं। रूपांतरण लेआउट और फ़ॉर्मेटिंग को प्रभावित कर सकता है, इसलिए आउटपुट की समीक्षा करें, विशेष रूप से जब प्रतिस्थापन टेक्स्ट मूल से लंबा हो।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे PDF निर्यात करने से पहले PPTX फ़ाइल सहेजनी चाहिए?**

नहीं। आप उसी प्रस्तुति को मेमोरी में संपादित और निर्यात कर सकते हैं। केवल तभी PPTX की एक प्रति सहेजें जब आप उसे PowerPoint में आगे संपादित करना चाहते हों; देखें [Save Presentations](/slides/hi/python-net/save-presentation/)।

**कुछ टेक्स्ट क्यों नहीं बदलता?**

उदाहरण पूरे शब्द "Draft" को सटीक केस के साथ मिलाता है। टेक्स्ट जो चित्र के रूप में आयात हुआ है या अलग-अलग टेक्स्ट फ्रेम में बँटा हुआ है, वह खोज से आवश्यक रूप से मेल नहीं खा सकता। आयातित सामग्री की जाँच करें और अपने दस्तावेज़ के अनुसार खोज को समायोजित करें।