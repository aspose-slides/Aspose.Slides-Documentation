---
title: जावास्क्रिप्ट में PDF दस्तावेज़ संपादित करें
linktitle: PDF संपादित करें
type: docs
weight: 65
url: /hi/nodejs-java/edit-pdf/
keywords:
- PDF संपादित करें
- PDF टेक्स्ट बदलें
- PDF से PPTX
- PPTX से PDF
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट में PDF दस्तावेज़ को Aspose.Slides में आयात करके, टेक्स्ट बदलकर, और संशोधित प्रस्तुति को फिर से PDF के रूप में सहेजकर संपादित करें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java आपको PDF सामग्री को उसके पृष्ठों को स्लाइड्स के रूप में आयात करके, प्रस्तुति को संशोधित करके, और इसे वापस PDF में निर्यात करके संपादित करने की अनुमति देता है। यह लेख एक सरल टेक्स्ट रिप्लेसमेंट दिखाता है। प्रस्तुति मेमोरी में रहती है, इसलिए मध्यवर्ती PPTX फ़ाइल को सहेजना वैकल्पिक है।

## **PDF में टेक्स्ट बदलें**

पृष्ठों को आयात करने के लिए [addFromPdf](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addFromPdf), टेक्स्ट को अपडेट करने के लिए [replaceText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#replaceText), और परिणाम को निर्यात करने के लिए [save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) का उपयोग करें।

निम्नलिखित उदाहरण अपेक्षा करता है कि `input.pdf` में आयात के बाद शब्द "Draft" संपादन योग्य टेक्स्ट के रूप में मौजूद हो। यह शब्द को "Final" से बदलता है और `edited.pdf` लिखता है। आयात से पहले प्रारंभिक स्लाइड को साफ़ करने से आउटपुट में अतिरिक्त खाली पृष्ठ नहीं आता। खोज पूरी शब्दों को समान अक्षर केस के साथ मिलाती है; `null` का अर्थ है कि परिणाम कॉलबैक की आवश्यकता नहीं है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

अधिक विकल्पों के लिए, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/nodejs-java/search-and-replace-text/) और [PowerPoint को PDF में कन्वर्ट करें](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
टेक्स्ट प्रतिस्थापन आयातित टेक्स्ट पर काम करता है, स्कैन की गई छवियों के भीतर के टेक्स्ट पर नहीं। रूपांतरण लेआउट और स्वरूपण को प्रभावित कर सकता है, इसलिए आउटपुट की पुन:जाँच करें, विशेष रूप से जब प्रतिस्थापित टेक्स्ट मूल से लंबा हो।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे PDF निर्यात करने से पहले PPTX फ़ाइल को सहेजना आवश्यक है?**

नहीं। आप उसी प्रस्तुति को मेमोरी में संपादित कर सकते हैं और निर्यात कर सकते हैं। केवल तब PPTX की एक प्रति सहेजें जब आप इसे PowerPoint में भी संपादित करना चाहते हों; देखें [प्रस्तुतियाँ सहेजें](/slides/hi/nodejs-java/save-presentation/)।

**कुछ टेक्स्ट अपरिवर्तित क्यों रह सकता है?**

उदाहरण पूरी शब्द "Draft" को सटीक केस के साथ मिलाता है। छवि के रूप में आयात किया गया टेक्स्ट या अलग-अलग टेक्स्ट फ्रेम में विभाजित टेक्स्ट जरूरी नहीं कि खोज से मेल खाए। आयातित सामग्री की जाँच करें और अपने दस्तावेज़ के लिए खोज को समायोजित करें।