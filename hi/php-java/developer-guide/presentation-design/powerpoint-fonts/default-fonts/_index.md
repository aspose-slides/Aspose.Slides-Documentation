---
title: PHP में डिफ़ॉल्ट प्रस्तुति फ़ॉन्ट निर्दिष्ट करें
linktitle: डिफ़ॉल्ट फ़ॉन्ट
type: docs
weight: 30
url: /hi/php-java/default-font/
keywords:
- डिफ़ॉल्ट फ़ॉन्ट
- नियमित फ़ॉन्ट
- सामान्य फ़ॉन्ट
- एशियाई फ़ॉन्ट
- PDF निर्यात
- XPS निर्यात
- इमेज निर्यात
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के माध्यम से Java में Aspose.Slides के लिए डिफ़ॉल्ट फ़ॉन्ट सेट करें ताकि PowerPoint (PPT, PPTX) और OpenDocument (ODP) को PDF, XPS और इमेज में सही रूप से परिवर्तित किया जा सके।"
---
## **परिचय**

Aspose.Slides आपको डिफ़ॉल्ट फ़ॉन्ट निर्दिष्ट करने की अनुमति देता है जो प्रस्तुति रेंडर होती समय उपयोग होते हैं। यह स्लाइड थंबनेल बनाने या प्रस्तुति को PDF और XPS जैसे फ़ॉर्मैट में निर्यात करने के समय उपयोगी है। डिफ़ॉल्ट फ़ॉन्ट `LoadOptions` के माध्यम से कॉन्फ़िगर किए जाते हैं, इससे पहले कि प्रस्तुति लोड हो।

`setDefaultRegularFont` मेथड नियमित टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट को परिभाषित करता है, जबकि `setDefaultAsianFont` एशियाई टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट को परिभाषित करता है। इन विकल्पों को सेट करने के बाद, प्रस्तुति को लोड किया जा सकता है और निर्दिष्ट फ़ॉन्ट का उपयोग करके रेंडर किया जा सकता है।

## **प्रस्तुति रेंडर करने के लिए डिफ़ॉल्ट फ़ॉन्ट का उपयोग करें**
Aspose.Slides आपको PDF, XPS या थंबनेल में प्रस्तुति रेंडर करने के लिए डिफ़ॉल्ट फ़ॉन्ट सेट करने की अनुमति देता है। यह लेख दिखाता है कि डिफ़ॉल्ट फ़ॉन्ट के रूप में उपयोग करने के लिए DefaultRegularFont और DefaultAsianFont कैसे परिभाषित करें। कृपया नीचे दिए गए चरणों का पालन करें ताकि आप बाहरी डायरेक्टरी से फ़ॉन्ट लोड कर सकें, Aspose.Slides for PHP via Java API का उपयोग करके:

1. एक [LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LoadOptions) का इंस्टेंस बनाएं।
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) को अपनी इच्छित फ़ॉन्ट पर सेट करें। निम्न उदाहरण में, मैंने Wingdings का उपयोग किया है।
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) को अपनी इच्छित फ़ॉन्ट पर सेट करें। मैंने निम्न नमूने में Wingdings का उपयोग किया है।
4. Presentation का उपयोग करके और लोड विकल्प सेट करके प्रस्तुति को लोड करें।
5. अब, परिणामों की पुष्टि करने के लिए स्लाइड थंबनेल, PDF और XPS उत्पन्न करें।

उपरोक्त का कार्यान्वयन नीचे दिया गया है।

```php
  # लोड विकल्पों का उपयोग करके डिफ़ॉल्ट नियमित और एशियाई फ़ॉन्ट निर्धारित करें
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # प्रस्तुति लोड करें
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # स्लाइड थंबनेल बनाएं
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # डिस्क पर छवि सहेजें।
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # PDF बनाएं
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # XPS बनाएं
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **अक्सर पूछे जाने वाले प्रश्न**

**DefaultRegularFont और DefaultAsianFont वास्तव में क्या प्रभावित करते हैं—केवल निर्यात, या थंबनेल, PDF, XPS, HTML, और SVG भी?**  
वे सभी समर्थित आउटपुट के रेंडरिंग पाइपलाइन में भाग लेते हैं। इसमें स्लाइड थंबनेल, [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/php-java/convert-powerpoint-to-xps/), [raster images](/slides/hi/php-java/convert-powerpoint-to-png/), [HTML](/slides/hi/php-java/convert-powerpoint-to-html/), और [SVG](/slides/hi/php-java/render-a-slide-as-an-svg-image/) शामिल हैं, क्योंकि Aspose.Slides इन सभी लक्ष्यों के लिए समान लेआउट और ग्लिफ़ रेज़ोल्यूशन लॉजिक का उपयोग करता है।

**क्या डिफ़ॉल्ट फ़ॉन्ट केवल पढ़ने और PPTX को सहेजने पर रेंडरिंग के बिना लागू होते हैं?**  
नहीं। डिफ़ॉल्ट फ़ॉन्ट तभी मायने रखते हैं जब टेक्स्ट को मापना और ड्रॉ करना आवश्यक हो। प्रस्तुति को सीधे खोलकर सहेजने से संग्रहीत फ़ॉन्ट रन या फ़ाइल की संरचना नहीं बदलती। डिफ़ॉल्ट फ़ॉन्ट उन ऑपरेशनों के दौरान उपयोग होते हैं जो टेक्स्ट को रेंडर या रीफ़्लो करते हैं।

**यदि मैं अपने स्वयं के फ़ॉन्ट फ़ोल्डर जोड़ता हूँ या मेमोरी से फ़ॉन्ट प्रदान करता हूँ, तो क्या वे डिफ़ॉल्ट फ़ॉन्ट चुनते समय विचार किए जाएंगे?**  
हां। [Custom font sources](/slides/hi/php-java/custom-font/) उपलब्ध फ़ॉन्ट परिवारों और ग्लिफ़ों का कैटलॉग विस्तारित करता है जिसे इंजन उपयोग कर सकता है। डिफ़ॉल्ट फ़ॉन्ट और कोई भी [fallback rules](/slides/hi/php-java/fallback-font/) पहले इन स्रोतों के विरुद्ध हल किए जाएंगे, जिससे सर्वरों और कंटेनरों में अधिक विश्वसनीय कवरेज मिलेगा।

**क्या डिफ़ॉल्ट फ़ॉन्ट टेक्स्ट मीट्रिक्स (करनिंग, एडवांस) को प्रभावित करेंगे और इस प्रकार लाइन ब्रेक और रैपिंग को?**  
हां। फ़ॉन्ट बदलने से ग्लिफ़ मीट्रिक्स बदलते हैं और रेंडरिंग के दौरान लाइन ब्रेक, रैपिंग और पेजिनेशन को बदल सकता है। लेआउट स्थिरता के लिए, [embed the original fonts](/slides/hi/php-java/embedded-font/) करें या मीट्रिकली संगत डिफ़ॉल्ट और फॉलबैक परिवार चुनें।

**यदि प्रस्तुति में उपयोग किए गए सभी फ़ॉन्ट एम्बेडेड हैं, तो डिफ़ॉल्ट फ़ॉन्ट सेट करने का कोई मतलब है क्या?**  
अक्सर यह आवश्यक नहीं होता, क्योंकि [embedded fonts](/slides/hi/php-java/embedded-font/) पहले से ही स्थिर स्वरूप सुनिश्चित करते हैं। डिफ़ॉल्ट फ़ॉन्ट अभी भी एक सुरक्षा जाल के रूप में मदद करते हैं उन अक्षरों के लिए जो एम्बेडेड उपसमुच्चय में नहीं आते या जब फ़ाइल एम्बेडेड और नॉन-एम्बेडेड टेक्स्ट को मिश्रित करती है।