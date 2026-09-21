---
title: PHP में PDF दस्तावेज़ संपादित करें
linktitle: PDF संपादित करें
type: docs
weight: 65
url: /hi/php-java/edit-pdf/
keywords:
- PDF संपादित करें
- PDF पाठ बदलें
- PDF से PPTX
- PPTX से PDF
- PHP
- Aspose.Slides
description: "PHP में PDF दस्तावेज़ों को Aspose.Slides में आयात करके, पाठ बदलकर, और संशोधित प्रस्तुति को फिर से PDF में सहेजकर संपादित करें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java आपको PDF सामग्री को उसकी पृष्ठों को स्लाइड के रूप में आयात करके, प्रस्तुति को संशोधित करके, और इसे वापस PDF में निर्यात करके संपादित करने की अनुमति देता है। यह लेख एक सरल पाठ प्रतिस्थापन दिखाता है। प्रस्तुति मेमोरी में रहती है, इसलिए मध्यवर्ती PPTX फ़ाइल को सहेजना वैकल्पिक है।

## **PDF में पाठ बदलें**

पृष्ठों को आयात करने के लिए [SlideCollection::addFromPdf](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/#addFromPdf), पाठ को अपडेट करने के लिए [Presentation::replaceText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#replaceText), और परिणाम को निर्यात करने के लिए [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) का उपयोग करें।

निम्नलिखित उदाहरण अपेक्षा करता है कि `input.pdf` में आयात के बाद संपादन योग्य पाठ के रूप में शब्द "Draft" हो। यह शब्द को "Final" से प्रतिस्थापित करता है और `edited.pdf` लिखता है। आयात से पहले प्रारंभिक स्लाइड को साफ़ करने से आउटपुट में अतिरिक्त खाली पृष्ठ नहीं बनता। खोज पूरी शब्दों को समान अक्षर केस के साथ मिलाती है; `null` का अर्थ है कि कोई परिणाम कॉलबैक आवश्यक नहीं है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

अधिक विकल्पों के लिए, देखें [पाठ खोजें और बदलें](/slides/hi/php-java/search-and-replace-text/) और [PowerPoint को PDF में बदलें](/slides/hi/php-java/convert-powerpoint-to-pdf/)।

{{% alert color="info" title="Note" %}}
पाठ प्रतिस्थापन आयातित पाठ पर काम करता है, स्कैन किए गए चित्रों के भीतर के पाठ पर नहीं। रूपांतरण लेआउट और फ़ॉर्मेटिंग को प्रभावित कर सकता है, इसलिए आउटपुट की समीक्षा करें, विशेष रूप से जब प्रतिस्थापित पाठ मूल से लंबा हो।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे PDF निर्यात करने से पहले PPTX फ़ाइल को सहेजना आवश्यक है?**

नहीं। आप मेमोरी में उसी प्रस्तुति को संपादित और निर्यात कर सकते हैं। केवल तभी PPTX की प्रतिलिपि सहेजें जब आप इसे PowerPoint में भी संपादित जारी रखना चाहते हों; देखें [प्रस्तुतियों को सहेजें](/slides/hi/php-java/save-presentation/)।

**कुछ पाठ क्यों अपरिवर्तित रह सकता है?**

उदाहरण पूरे शब्द "Draft" को सटीक केस के साथ मिलाता है। छवि के रूप में आयातित पाठ या अलग-अलग टेक्स्ट फ्रेम में विभाजित किया गया पाठ आवश्यक रूप से खोज से मेल नहीं खा सकता। आयातित सामग्री की जाँच करें और अपने दस्तावेज़ के लिए खोज को समायोजित करें।