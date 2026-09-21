---
title: "Java में PDF दस्तावेज़ संपादित करें"
linktitle: "PDF संपादित करें"
type: docs
weight: 65
url: /hi/java/edit-pdf/
keywords:
- PDF संपादित करें
- PDF टेक्स्ट बदलें
- PDF से PPTX
- PPTX से PDF
- Java
- Aspose.Slides
description: "Java में Aspose.Slides में आयात करके, टेक्स्ट बदलकर, और संशोधित प्रस्तुति को पुनः PDF में सहेजकर PDF दस्तावेज़ संपादित करें।"
---
## **अवलोकन**

Aspose.Slides for Java आपको PDF सामग्री को उसके पृष्ठों को स्लाइड्स के रूप में आयात करके, प्रस्तुति को संशोधित करके, और उसे पुनः PDF के रूप में निर्यात करके संपादित करने की अनुमति देता है। यह लेख एक सरल टेक्स्ट प्रतिस्थापन दर्शाता है। प्रस्तुति मेमोरी में रहती है, इसलिए मध्यवर्ती PPTX फ़ाइल को सहेजना वैकल्पिक है।

## **PDF में टेक्स्ट बदलें**

पृष्ठों को आयात करने के लिए [addFromPdf](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) का उपयोग करें, टेक्स्ट को अद्यतन करने के लिए [replaceText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) का उपयोग करें, और परिणाम को निर्यात करने के लिए [save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) का उपयोग करें।

निम्नलिखित उदाहरण में अपेक्षा की जाती है कि `input.pdf` में आयात के बाद शब्द "Draft" संपादन योग्य टेक्स्ट के रूप में हो। यह शब्द को "Final" से प्रतिस्थापित करता है और `edited.pdf` लिखता है। आयात से पहले प्रारंभिक स्लाइड को साफ़ करने से आउटपुट में अतिरिक्त खाली पृष्ठ नहीं आता। खोज समान अक्षर केस के साथ पूर्ण शब्दों से मिलती है; `null` का अर्थ है कि कोई परिणाम कॉलबैक आवश्यक नहीं है।

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

अधिक विकल्पों के लिए, देखें [पाठ खोजें और बदलें](/slides/hi/java/search-and-replace-text/) और [PowerPoint को PDF में बदलें](/slides/hi/java/convert-powerpoint-to-pdf/)।

{{% alert color="info" title="Note" %}}
टेक्स्ट प्रतिस्थापन आयातित टेक्स्ट पर काम करता है, स्कैन की गई छवियों के भीतर के टेक्स्ट पर नहीं। रूपांतरण लेआउट और स्वरूपण को प्रभावित कर सकता है, इसलिए आउटपुट की समीक्षा करें, विशेषकर जब प्रतिस्थापित टेक्स्ट मूल से लंबा हो।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे PDF निर्यात करने से पहले PPTX फ़ाइल को सहेजना आवश्यक है?**

नहीं। आप उसी प्रस्तुति को मेमोरी में संपादित और निर्यात कर सकते हैं। केवल तब PPTX की एक प्रति सहेजें जब आप इसे PowerPoint में आगे संपादित करना चाहते हों; देखें [प्रस्तुति सहेजें](/slides/hi/java/save-presentation/)।

**कुछ टेक्स्ट क्यों अपरिवर्तित रह सकता है?**

उदाहरण पूर्ण शब्द "Draft" को सटीक केस के साथ मिलाता है। छवि के रूप में आयात किया गया टेक्स्ट या अलग-अलग टेक्स्ट फ्रेम में विभाजित किया गया टेक्स्ट आवश्यकतः खोज से मेल नहीं खा सकता। आयातित सामग्री की जाँच करें और अपने दस्तावेज़ के लिए खोज को समायोजित करें।