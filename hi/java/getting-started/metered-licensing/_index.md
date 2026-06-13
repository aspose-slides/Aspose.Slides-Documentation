---
title: मीटर लाइसेंसिंग
type: docs
weight: 100
url: /hi/java/metered-licensing/
keywords:
- लाइसेंस
- मीटर लाइसेंस
- लाइसेंस कुंजियां
- सार्वजनिक कुंजी
- निजी कुंजी
- उपभोग मात्रा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for Java मीटर लाइसेंसिंग आपको PowerPoint और OpenDocument फ़ाइलों को लचीले ढंग से प्रोसेस करने देती है, केवल उपयोग के अनुसार भुगतान करते हुए।"
---
## **परिचय**

Metered लाइसेंसिंग एक लाइसेंसिंग तंत्र है जिसका उपयोग मौजूदा लाइसेंसिंग विधियों के साथ किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के उपयोग के आधार पर बिलिंग करना चाहते हैं, तो आप Metered लाइसेंसिंग चुनते हैं।

## **Metered कुंजियों को लागू करें**

{{% alert color="primary" %}} 

Metered लाइसेंसिंग एक नया लाइसेंसिंग तंत्र है जिसका उपयोग मौजूदा लाइसेंसिंग विधियों के साथ किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के उपयोग के आधार पर बिलिंग करना चाहते हैं, तो आप Metered लाइसेंसिंग चुनते हैं।

जब आप Metered लाइसेंस खरीदते हैं, तो आपको कुंजियां (और लाइसेंस फ़ाइल नहीं) मिलती हैं। यह Metered कुंजी को Aspose द्वारा Metered संचालन के लिए प्रदान किए गए [Metered](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/) क्लास का उपयोग करके लागू किया जा सकता है। अधिक विवरण के लिए, देखें [Metered लाइसेंसिंग FAQ](https://purchase.aspose.com/faqs/licensing/metered)।

{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/) क्लास का एक इंस्टेंस बनाएं।

2. अपने सार्वजनिक और निजी कुंजियों को [setMeteredKey](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) मेथड में पास करें।

3. कुछ प्रोसेसिंग (कार्य) करें।

4. `Metered` क्लास की [getConsumptionQuantity](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/#getConsumptionQuantity--) मेथड को कॉल करें।

आपको अब तक उपभोग की गई API अनुरोधों की मात्रा/संख्या दिखाई देगी।

यह नमूना कोड दर्शाता है कि Metered लाइसेंसिंग का उपयोग कैसे करें:

```java
// मीटर क्लास का एक इंस्टेंस बनाता है
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // सार्वजनिक और निजी कुंजियों को मीटर ऑब्जेक्ट में पास करता है
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // API कॉल से पहले उपभोग की मात्रा प्राप्त करता है
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // यहाँ Aspose.Slides API के साथ कुछ करें
    // ...

    // API कॉल के बाद उपभोग की मात्रा प्राप्त करता है
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Metered लाइसेंसिंग का उपयोग करने के लिए स्थिर इंटरनेट कनेक्शन आवश्यक है क्योंकि यह तंत्र लगातार हमारे सेवाओं के साथ इंटरैक्ट करता है और गणनाएँ करता है।

{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक Metered लाइसेंस को ही एक नियमित (स्थायी या अस्थायी) लाइसेंस के साथ उसी एप्लिकेशन में उपयोग कर सकता हूँ?**

हां। Metered एक अतिरिक्त लाइसेंसिंग तंत्र है जिसे मौजूदा [licensing methods](/slides/hi/java/licensing/) के साथ उपयोग किया जा सकता है। एप्लिकेशन शुरू होने पर आप तय कर सकते हैं कि कौन सा तंत्र लागू करना है।

**Metered लाइसेंस के तहत उपभोग में क्या गिना जाता है: संचालन या फ़ाइलें?**

API उपयोग गिना जाता है, अर्थात् अनुरोधों या संचालन की संख्या। आप वर्तमान उपभोग को [consumption-tracking methods](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/) के माध्यम से प्राप्त कर सकते हैं।

**क्या Metered माइक्रोसर्विसेज और सर्वरलेस वातावरणों के लिए उपयुक्त है जहाँ इंस्टेंस अक्सर पुनः शुरू होते हैं?**

हां। चूंकि लेखा-जोखा API‑कॉल स्तर पर किया जाता है, इसलिए बार‑बार कोल्ड स्टार्ट वाले परिदृश्य संगत हैं, बशर्ते Metered गणनाओं के लिए स्थिर नेटवर्क एक्सेस उपलब्ध हो।

**क्या Metered लाइसेंस का उपयोग करने पर लाइब्रेरी की कार्यक्षमता स्थायी लाइसेंस के मुकाबले अलग होती है?**

नहीं। यह केवल लाइसेंसिंग और बिलिंग तंत्र से संबंधित है; उत्पाद की क्षमताएँ समान रहती हैं।

**Metered का ट्रायल संस्करण और अस्थायी लाइसेंस से क्या संबंध है?**

ट्रायल संस्करण में सीमाएँ और वॉटरमार्क होते हैं, [अस्थायी लाइसेंस](https://purchase.aspose.com/temporary-license/) 30 दिनों के लिए सीमाओं को हटाता है, और Metered वास्तविक उपयोग के आधार पर चार्ज करता है तथा सीमाओं को हटाता है।

**क्या मैं उपभोग थ्रेशोल्ड से अधिक होने पर स्वचालित प्रतिक्रिया देकर बजट को नियंत्रित कर सकता हूँ?**

हां। एक सामान्य अभ्यास है कि आप [tracking methods](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/) के माध्यम से समय‑समय पर वर्तमान उपभोग पढ़ें और एप्लिकेशन या मॉनिटरिंग स्तर पर अपनी स्वयं की सीमाएँ या अलर्ट लागू करें।