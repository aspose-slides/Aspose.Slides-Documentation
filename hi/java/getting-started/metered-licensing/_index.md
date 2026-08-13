---
title: मीटर लाइसेंसिंग
type: docs
weight: 100
url: /hi/java/metered-licensing/
keywords:
- लाइसेंस
- मीटर लाइसेंस
- लाइसेंस कुंजियाँ
- सार्वजनिक कुंजी
- निजी कुंजी
- उपभोग मात्रा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "जानें कि Aspose.Slides for Java मीटर लाइसेंसिंग आपको PowerPoint और OpenDocument फ़ाइलों को लचीले ढंग से प्रोसेस करने की अनुमति देती है, और केवल उपयोग के अनुसार भुगतान करते हैं।"
---
## **परिचय**

Metered लाइसेंसिंग एक लाइसेंसिंग तंत्र है जिसे मौजूदा लाइसेंसिंग विधियों के साथ उपयोग किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के अपने उपयोग के आधार पर बिल देना चाहते हैं, तो आप Metered लाइसेंसिंग चुनते हैं।

## **Metered कुंजियों को लागू करें**

{{% alert color="info" %}} 
Metered लाइसेंसिंग एक नई लाइसेंसिंग तंत्र है जिसे मौजूदा लाइसेंसिंग विधियों के साथ उपयोग किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के अपने उपयोग के आधार पर बिल देना चाहते हैं, तो आप Metered लाइसेंसिंग चुनते हैं।

जब आप Metered लाइसेंस खरीदते हैं, तो आपको लाइसेंस फ़ाइल नहीं बल्कि कुंजियाँ मिलती हैं। इस Metered कुंजी को आप Aspose द्वारा प्रदान किए गए [Metered](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/) क्लास का उपयोग करके लागू कर सकते हैं। अधिक विवरण के लिए देखें [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)।
{{% /alert %}} 

1. [Metered](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/) क्लास की एक instance बनाएं।  

2. अपनी सार्वजनिक और निजी कुंजियों को [setMeteredKey](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) मेथड में पास करें।  

3. कुछ प्रोसेसिंग करें (कार्य पूरा करें)।  

4. `Metered` क्लास की [getConsumptionQuantity](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/#getConsumptionQuantity--) मेथड को कॉल करें।  

आपको अब तक उपभोग किए गए API अनुरोधों की संख्या/मात्रा दिखाई देनी चाहिए।

यह नमूना कोड आपको Metered लाइसेंसिंग का उपयोग कैसे किया जाता है दिखाता है:

```java
// Metered क्लास का एक instance बनाता है
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // सार्वजनिक और निजी कुंजियों को Metered ऑब्जेक्ट को पास करता है
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // API कॉल से पहले उपभोग की गई मात्रा का मान प्राप्त करता है
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // यहाँ Aspose.Slides API के साथ कुछ करें
    // ...

    // API कॉल के बाद उपभोग की गई मात्रा का मान प्राप्त करता है
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 
Metered लाइसेंसिंग का उपयोग करने के लिए स्थिर इंटरनेट कनेक्शन आवश्यक है क्योंकि लाइसेंसिंग तंत्र हमारे सेवाओं के साथ निरंतर संपर्क में रहता है और गणनाएँ करता है।  
{{% /alert %}} 

## **FAQ**

### क्या मैं Metered लाइसेंस को किसी नियमित (स्थायी या अस्थायी) लाइसेंस के साथ एक ही एप्लिकेशन में उपयोग कर सकता हूँ?

हाँ। Metered एक अतिरिक्त लाइसेंसिंग तंत्र है जिसे मौजूदा [licensing methods](/slides/hi/java/licensing/) के साथ उपयोग किया जा सकता है। एप्लिकेशन शुरू होते समय आप तय करते हैं कि किस तंत्र को लागू करना है।

### Metered लाइसेंस के तहत उपभोग में क्या गिना जाता है: ऑपरेशन या फ़ाइलें?

API उपयोग गिना जाता है, अर्थात् अनुरोधों या ऑपरेशनों की संख्या। आप वर्तमान उपभोग को [consumption‑tracking methods](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/) के माध्यम से प्राप्त कर सकते हैं।

### क्या Metered माइक्रोसर्विसेज और सर्वरलेस वातावरण में उपयुक्त है जहाँ इंस्टेंस अक्सर रीस्टार्ट होते हैं?

हाँ। चूँकि लेखा‑जोखा API‑कॉल स्तर पर किया जाता है, इसलिए अक्सर कोल्ड‑स्टार्ट वाले परिदृश्य संगत हैं, बशर्ते Metered गणनाओं के लिए स्थिर नेटवर्क पहुँच उपलब्ध हो।

### क्या Metered लाइसेंस का उपयोग करने पर लाइब्रेरी की कार्यक्षमता स्थायी लाइसेंस की तुलना में बदलती है?

नहीं। यह केवल लाइसेंसिंग और बिलिंग तंत्र के बारे में है; उत्पाद की क्षमताएँ समान रहती हैं।

### Metered का ट्रायल संस्करण और अस्थायी लाइसेंस से क्या संबंध है?

ट्रायल संस्करण में सीमाएँ और वॉटरमार्क होते हैं, जबकि [temporary license](https://purchase.aspose.com/temporary-license/) 30 दिनों के लिए सीमाओं को हटाता है, और Metered वास्तविक उपयोग के आधार पर शुल्क लेता है तथा सीमाओं को हटाता है।

### क्या मैं उपभोग सीमा पार होने पर स्वचालित रूप से बजट को नियंत्रित कर सकता हूँ?

हाँ। एक सामान्य अभ्यास यह है कि आप नियमित रूप से वर्तमान उपभोग को [tracking methods](https://reference.aspose.com/slides/hi/java/com.aspose.slides/metered/) के माध्यम से पढ़ें और एप्लिकेशन या मॉनिटरिंग स्तर पर अपनी स्वयं की सीमाएँ या अलर्ट लागू करें।