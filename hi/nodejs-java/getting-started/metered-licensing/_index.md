---
title: मीटर लाइसेंसिंग
type: docs
weight: 100
url: /hi/nodejs-java/metered-licensing/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "जानें कि कैसे Aspose.Slides for Node.js via Java मीटर लाइसेंसिंग आपको PowerPoint और OpenDocument फ़ाइलों को लचीले ढंग से प्रोसेस करने देती है, और आप केवल उपयोग किए गए के लिए भुगतान करते हैं।"
---
## **परिचय**

मीटर लाइसेंसिंग एक लाइसेंसिंग तंत्र है जिसे मौजूदा लाइसेंसिंग विधियों के साथ उपयोग किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के उपयोग के आधार पर बिलिंग चाहते हैं, तो आप मीटर लाइसेंसिंग चुनते हैं।

## **मीटर कुंजियों को लागू करें**

जब आप मीटर लाइसेंस खरीदते हैं, तो आपको कुंजियां मिलती हैं (और लाइसेंस फ़ाइल नहीं)। इस मीटर कुंजी को Aspose द्वारा प्रदान किए गए मीटरिंग ऑपरेशन्स के लिए [Metered](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/metered/) क्लास का उपयोग करके लागू किया जा सकता है। अधिक विवरण के लिए, देखें [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. [Metered](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/metered/) क्लास का एक इंस्टेंस बनाएं।

1. अपने सार्वजनिक और निजी कुंजियों को [setMeteredKey](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/metered/#setMeteredKey) मेथड में पास करें।

1. कुछ प्रोसेसिंग करें (कार्य निष्पादित करें)।

1. `Metered` क्लास की [getConsumptionQuantity](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) मेथड को कॉल करें।

आपको अब तक उपयोग किए गए API अनुरोधों की मात्रा/संख्या दिखनी चाहिए।

यह नमूना कोड दिखाता है कि मीटर लाइसेंसिंग का उपयोग कैसे करें:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Creates an instance of the Metered class
// Metered वर्ग का एक इंस्टेंस बनाता है
var metered = new aspose.slides.Metered();

// Passes the public and private keys to the Metered object
// सार्वजनिक और निजी कुंजियों को Metered ऑब्जेक्ट में पास करता है
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Gets the consumed quantity value before API calls
// API कॉल से पहले उपभोग की मात्रा मान प्राप्त करता है
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Do something with Aspose.Slides API here
// यहाँ Aspose.Slides API के साथ कुछ करें
// ...

// Gets the consumed quantity value after API calls
// API कॉल के बाद उपभोग की मात्रा मान प्राप्त करता है
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"%}} 
मीटर लाइसेंसिंग का उपयोग करने के लिए, आपको एक स्थिर इंटरनेट कनेक्शन की आवश्यकता होती है क्योंकि लाइसेंसिंग तंत्र इंटरनेट का उपयोग करके लगातार हमारी सेवाओं के साथ संपर्क करता है और गणनाएँ करता है।
{{% /alert %}} 

## **FAQ**

**क्या मैं एक ही एप्लिकेशन में मीटर लाइसेंस को सामान्य (परपेचुअल या टेम्पररी) लाइसेंस के साथ उपयोग कर सकता हूँ?**

हाँ। मीटर एक अतिरिक्त लाइसेंसिंग तंत्र है जिसे मौजूदा [licensing methods](/slides/hi/nodejs-java/licensing/) के साथ उपयोग किया जा सकता है। आप एप्लिकेशन शुरू होने पर कौन सा तंत्र लागू करना है, चुनते हैं।

**एक मीटर लाइसेंस के तहत उपभोग में क्या गिना जाता है: ऑपरेशंस या फ़ाइलें?**

API उपयोग गिना जाता है, अर्थात अनुरोधों या ऑपरेशंस की संख्या। आप वर्तमान उपभोग को [consumption-tracking methods](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/metered/) के माध्यम से प्राप्त कर सकते हैं।

**क्या मीटर माइक्रोसर्विसेज़ और सर्वरलेस परिवेशों में उपयुक्त है जहाँ इंस्टेंस बार‑बार रीस्टार्ट होते हैं?**

हाँ। चूँकि लेखा‑जोखा API‑कॉल स्तर पर किया जाता है, इसलिए बार‑बार कोल्ड स्टार्ट वाले परिदृश्य संगत हैं, बशर्ते मीटर गणनाओं के लिए स्थिर नेटवर्क पहुँच उपलब्ध हो।

**क्या मीटर लाइसेंस का उपयोग करने पर लाइब्रेरी की कार्यक्षमता परपेचुअल लाइसेंस की तुलना में अलग होती है?**

नहीं। यह केवल लाइसेंसिंग और बिलिंग तंत्र के बारे में है; उत्पाद की क्षमताएँ समान हैं।

**मीटर ट्रायल संस्करण और टेम्पररी लाइसेंस से कैसे संबंधित है?**

ट्रायल संस्करण में सीमाएँ और वॉटरमार्क होते हैं, [temporary license](https://purchase.aspose.com/temporary-license/) 30 दिनों के लिए सीमाएँ हटाता है, और मीटर सीमाओं को हटाता है और वास्तविक उपयोग के आधार पर शुल्क लेता है।

**क्या मैं उपभोग सीमा पार होने पर स्वचालित प्रतिक्रिया देकर बजट को नियंत्रित कर सकता हूँ?**

हाँ। आम प्रथा यह है कि आप [tracking methods](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/metered/) के माध्यम से वर्तमान उपभोग को समय‑समय पर पढ़ें और एप्लिकेशन या मॉनिटरिंग स्तर पर अपनी सीमाएँ या अलर्ट लागू करें।