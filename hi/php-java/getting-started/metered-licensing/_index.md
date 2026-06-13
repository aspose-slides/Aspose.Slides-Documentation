---
title: मेटर्ड लाइसेंसिंग
type: docs
weight: 100
url: /hi/php-java/metered-licensing/
keywords:
- लाइसेंस
- मेटर्ड लाइसेंस
- लाइसेंस कुंजियाँ
- सार्वजनिक कुंजी
- निजी कुंजी
- उपभोग मात्रा
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "जानेँ कि Aspose.Slides for PHP via Java मेटर्ड लाइसेंसिंग कैसे आपको PowerPoint और OpenDocument फ़ाइलों को लचीले ढंग से प्रोसेस करने की अनुमति देता है, और आप केवल उसी के लिए भुगतान करते हैं जो आप उपयोग करते हैं।"
---
## **परिचय**

Metered लाइसेंसिंग वह लाइसेंसिंग तंत्र है जिसे मौजूदा लाइसेंसिंग तरीकों के साथ उपयोग किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के उपयोग के आधार पर बिलिंग चाहते हैं, तो आप Metered लाइसेंसिंग चुनते हैं।

## **Metered Keys लागू करना**

जब आप एक Metered लाइसेंस खरीदते हैं, तो आपको कुंजियाँ मिलती हैं (और लाइसेंस फ़ाइल नहीं)। यह Metered कुंजी Aspose द्वारा मेटरिंग ऑपरेशन्स के लिए प्रदान किए गए [Metered](https://reference.aspose.com/slides/hi/php-java/aspose.slides/metered/) क्लास का उपयोग करके लागू की जा सकती है। अधिक विवरण के लिए, देखें [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)।

1. एक [Metered](https://reference.aspose.com/slides/hi/php-java/aspose.slides/metered/) क्लास का एक उदाहरण बनाएँ।

1. अपने सार्वजनिक और निजी कुंजियों को [setMeteredKey](https://reference.aspose.com/slides/hi/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) मेथड में पास करें।

1. कुछ प्रोसेसिंग करें (कार्य निष्पादित करें)।

1. `Metered` क्लास की [getConsumptionQuantity](https://reference.aspose.com/slides/hi/php-java/aspose.slides/metered/#getConsumptionQuantity--) मेथड को कॉल करें।

आपको अब तक उपयोग किए गए API अनुरोधों की मात्रा/संख्या दिखाई देगी।

यह नमूना कोड आपको दिखाता है कि Metered लाइसेंसिंग का उपयोग कैसे करें:

```php
// Metered क्लास का एक उदाहरण बनाता है
$metered = new Metered();

try {
    // सार्वजनिक और निजी कुंजी को Metered ऑब्जेक्ट को पास करता है
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // API कॉल से पहले उपभोग मात्रा मान प्राप्त करता है
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // यहाँ Aspose.Slides API के साथ कुछ करें
    // ...

    // API कॉल के बाद उपभोग मात्रा मान प्राप्त करता है
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 
Metered लाइसेंसिंग का उपयोग करने के लिए आपको एक स्थिर इंटरनेट कनेक्शन की आवश्यकता है क्योंकि लाइसेंसिंग तंत्र इंटरनेट का उपयोग करता है हमारे सेवाओं के साथ निरंतर संवाद करने और गणनाएँ करने के लिए।
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही एप्लिकेशन में Metered लाइसेंस को सामान्य लाइसेंस (स्थायी या अस्थायी) के साथ उपयोग कर सकता हूँ?**

हाँ। Metered एक अतिरिक्त लाइसेंसिंग तंत्र है जिसे मौजूदा [licensing methods](/slides/hi/php-java/licensing/) के साथ उपयोग किया जा सकता है। आप एप्लिकेशन शुरू होने पर कौन सा तंत्र लागू करना है, चुनते हैं।

**एक Metered लाइसेंस के तहत उपभोग में ठीक-ठीक क्या गिना जाता है: ऑपरेशन्स या फ़ाइलें?**

API उपयोग गिना जाता है, अर्थात अनुरोधों या ऑपरेशनों की संख्या। आप वर्तमान उपभोग [consumption-tracking methods](https://reference.aspose.com/slides/hi/php-java/aspose.slides/metered/) के माध्यम से प्राप्त कर सकते हैं।

**क्या Metered माइक्रोसर्विसेज़ और सर्वरलेस वातावरण में जो अक्सर इंस्टेंस रीस्टार्ट होते हैं, के लिए उपयुक्त है?**

हाँ। चूँकि लेखा-जोखा API कॉल स्तर पर किया जाता है, इसलिए अक्सर कोल्ड स्टार्ट वाले परिदृश्य संगत हैं, बशर्ते Metered गणनाओं के लिए स्थिर नेटवर्क एक्सेस उपलब्ध हो।

**क्या Metered लाइसेंस का उपयोग करने पर लाइब्रेरी की कार्यक्षमता स्थायी लाइसेंस की तुलना में भिन्न होती है?**

नहीं। यह केवल लाइसेंसिंग और बिलिंग तंत्र के बारे में है; उत्पाद की क्षमताएँ समान हैं।

**Metered ट्रायल संस्करण और अस्थायी लाइसेंस से कैसे जुड़ा है?**

ट्रायल संस्करण में सीमाएँ और वॉटरमार्क होते हैं, [temporary license](https://purchase.aspose.com/temporary-license/) 30 दिनों के लिए सीमाओं को हटाता है, और Metered सीमाओं को हटाता है और वास्तविक उपयोग के आधार पर शुल्क लेता है।

**क्या मैं उपभोग सीमा पार होने पर स्वचालित रूप से प्रतिक्रिया देकर बजट को नियंत्रित कर सकता हूँ?**

हाँ। एक सामान्य प्रथा है कि आप समय-समय पर वर्तमान उपभोग को [tracking methods](https://reference.aspose.com/slides/hi/php-java/aspose.slides/metered/) के माध्यम से पढ़ें और एप्लिकेशन या मॉनिटरिंग स्तर पर अपनी सीमाएँ या अलर्ट लागू करें।