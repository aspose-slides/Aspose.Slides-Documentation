---
title: एंड्रॉइड पर PDF दस्तावेज़ संपादित करें
linktitle: PDF संपादित करें
type: docs
weight: 65
url: /hi/androidjava/edit-pdf/
keywords:
- PDF संपादित करें
- PDF टेक्स्ट बदलें
- PDF से PPTX
- PPTX से PDF
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "जावा के साथ एंड्रॉइड पर PDF दस्तावेज़ को Aspose.Slides में आयात करके, टेक्स्ट बदल कर, और संशोधित प्रस्तुति को फिर से PDF में सहेजकर संपादित करें।"
---
## **अवलोकन**

Aspose.Slides for Android via Java आपको PDF सामग्री को उसके पृष्ठों को स्लाइड्स के रूप में आयात करके, प्रस्तुति को संशोधित करके, और इसे फिर PDF में निर्यात करके संपादित करने देती है। यह लेख एक सरल टेक्स्ट प्रतिस्थापन दिखाता है। प्रस्तुति मेमोरी में रहती है, इसलिए मध्यवर्ती PPTX फ़ाइल को सहेजना वैकल्पिक है।

## **PDF में टेक्स्ट बदलें**

पृष्ठों को आयात करने के लिए [addFromPdf](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) का उपयोग करें, टेक्स्ट को अपडेट करने के लिए [replaceText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) और परिणाम को निर्यात करने के लिए [save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) का उपयोग करें।

निम्नलिखित उदाहरण यह मानता है कि `input.pdf` में आयात के बाद शब्द "Draft" संपादन योग्य टेक्स्ट के रूप में मौजूद है। यह शब्द को "Final" से प्रतिस्थापित करता है और `edited.pdf` लिखता है। आयात से पहले प्रारंभिक स्लाइड को साफ़ करने से आउटपुट में अतिरिक्त खाली पृष्ठ नहीं बनता। खोज पूरी शब्दों को समान अक्षर केस के साथ मिलाती है; `null` का मतलब है कि परिणाम कॉलबैक की आवश्यकता नहीं है।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

और अधिक विकल्पों के लिए देखें [Search and Replace Text](/slides/hi/androidjava/search-and-replace-text/) और [Convert PowerPoint to PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/)।

{{% alert color="info" title="Note" %}}
टेक्स्ट प्रतिस्थापन आयातित टेक्स्ट पर काम करता है, स्कैन की गई छवियों के अंदर टेक्स्ट पर नहीं। परिवर्तन लेआउट और फ़ॉर्मेटिंग को प्रभावित कर सकता है, इसलिए आउटपुट की समीक्षा करें, विशेष रूप से जब प्रतिस्थापित टेक्स्ट मूल से लंबा हो।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे PDF निर्यात करने से पहले PPTX फ़ाइल को सहेजने की आवश्यकता है?**

नहीं। आप मेमोरी में उसी प्रस्तुति को संपादित और निर्यात कर सकते हैं। केवल तब ही PPTX की कॉपी सहेजें जब आप इसे PowerPoint में आगे संपादित करना चाहें; देखें [Save Presentations](/slides/hi/androidjava/save-presentation/)।

**क्यों कुछ टेक्स्ट अपरिवर्तित रहता है?**

उदाहरण पूरी शब्द "Draft" को सटीक केस के साथ मिलाता है। टेक्स्ट जो छवि के रूप में आयात किया गया है या अलग-अलग टेक्स्ट फ्रेम में विभाजित है, वह आवश्यक रूप से खोज से मेल नहीं खा सकता। आयातित सामग्री की जाँच करें और अपने दस्तावेज़ के लिए खोज को समायोजित करें।