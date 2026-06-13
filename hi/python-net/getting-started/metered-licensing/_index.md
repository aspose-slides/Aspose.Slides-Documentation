---
title: "Metered लाइसेंसिंग"
type: docs
weight: 90
url: /hi/python-net/metered-licensing/
keywords:
- लाइसेंस
- मेटर्ड लाइसेंस
- लाइसेंस कुंजियाँ
- सार्वजनिक कुंजी
- निजी कुंजी
- उपभोग मात्रा
- Python
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for Python via .NET मेटर्ड लाइसेंसिंग आपको PowerPoint और OpenDocument फ़ाइलें लचीले ढंग से प्रोसेस करने देता है, और आप केवल वही भुगतान करते हैं जो आप उपयोग करते हैं।"
---
## **परिचय**

Metered लाइसेंसिंग एक लाइसेंसिंग तंत्र है जिसे मौजूदा लाइसेंसिंग विधियों के साथ उपयोग किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के अपने उपयोग के आधार पर बिल प्राप्त करना चाहते हैं, तो आप Metered लाइसेंसिंग चुनते हैं।

## **Metered कुंजियों को लागू करें**

{{% alert color="primary" %}} 

Metered लाइसेंसिंग एक नया लाइसेंसिंग तंत्र है जिसे मौजूदा लाइसेंसिंग विधियों के साथ उपयोग किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के अपने उपयोग के आधार पर बिल प्राप्त करना चाहते हैं, तो आप Metered लाइसेंसिंग चुनते हैं।

जब आप एक metered लाइसेंस खरीदते हैं, तो आपको कुंजियाँ मिलती हैं (और लाइसेंस फ़ाइल नहीं)। यह metered कुंजी Aspose द्वारा प्रदान की गई [Metered](https://reference.aspose.com/slides/hi/python-net/aspose.slides/metered/) क्लास का उपयोग करके लागू की जा सकती है, जो मीटरिंग ऑपरेशन्स के लिए है। अधिक विवरण के लिए, देखें [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. एक instance बनाएं [Metered](https://reference.aspose.com/slides/hi/python-net/aspose.slides/metered/) क्लास का।
1. अपने सार्वजनिक और निजी कुंजियों को [set_metered_key](https://reference.aspose.com/slides/hi/python-net/aspose.slides/metered/set_metered_key/#str-str) मेथड में पास करें।
1. कुछ प्रसंस्करण करें (कार्य करें)।
1. `Metered` क्लास की [get_consumption_quantity](https://reference.aspose.com/slides/hi/python-net/aspose.slides/metered/get_consumption_quantity/#) मेथड को कॉल करें।

आपको अब तक उपयोग किए गए API अनुरोधों की मात्रा/संख्या दिखनी चाहिए।

यह नमूना कोड आपको दिखाता है कि metered लाइसेंसिंग कैसे उपयोग की जाती है:

```python
import aspose.slides as slides

# Metered वर्ग का एक उदाहरण बनाता है
metered = slides.Metered()

# public और private कुंजियों को Metered ऑब्जेक्ट को पास करता है
metered.set_metered_key("<valid public key>", "<valid private key>")

# API कॉल्स से पहले उपयोग की गई मात्रा मान प्राप्त करता है
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# यहाँ Aspose.Slides API के साथ कुछ करें
# ...

# API कॉल्स के बाद उपयोग की गई मात्रा मान प्राप्त करता है
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Metered लाइसेंसिंग का उपयोग करने के लिए आपको स्थिर इंटरनेट कनेक्शन की आवश्यकता होती है क्योंकि लाइसेंसिंग तंत्र इंटरनेट का उपयोग करके हमारे सेवाओं के साथ निरंतर इंटरैक्ट करता है और गणनाएँ करता है।

{{% /alert %}} 

## **FAQ**

**क्या मैं एक ही एप्लिकेशन में नियमित (स्थायी या अस्थायी) लाइसेंस के साथ metered लाइसेंस का उपयोग कर सकता हूँ?**

हाँ। Metered एक अतिरिक्त लाइसेंसिंग तंत्र है जिसे मौजूदा [licensing methods](/slides/hi/python-net/licensing/) के साथ उपयोग किया जा सकता है। आप एप्लिकेशन शुरू होने पर कौन सा तंत्र लागू करना है, चुनते हैं।

**Metered लाइसेंस के तहत वास्तविक उपभोग क्या गिना जाता है: ऑपरेशन्स या फ़ाइलें?**

API उपयोग गिना जाता है, अर्थात् अनुरोधों या ऑपरेशन्स की संख्या। आप वर्तमान उपभोग को [consumption-tracking methods](https://reference.aspose.com/slides/hi/python-net/aspose.slides/metered/) के माध्यम से प्राप्त कर सकते हैं।

**क्या metered माइक्रोसर्विसेज और सर्वरलेस परिवेशों के लिए उपयुक्त है जहाँ इंस्टेंस अक्सर रीस्टार्ट होते हैं?**

हाँ। चूंकि लेखा API कॉल स्तर पर किया जाता है, इसलिए अक्सर कोल्ड स्टार्ट वाले परिदृश्य संगत हैं, बशर्ते metered गणनाओं के लिए स्थिर नेटवर्क एक्सेस उपलब्ध हो।

**क्या एक perpetual लाइसेंस की तुलना में metered लाइसेंस उपयोग करने पर लाइब्रेरी की कार्यक्षमता में अंतर है?**

नहीं। यह केवल लाइसेंसिंग और बिलिंग तंत्र के बारे में है; उत्पाद की क्षमताएँ समान हैं।

**Metered, ट्रायल संस्करण और अस्थाई लाइसेंस से कैसे संबंधित है?**

ट्रायल संस्करण में सीमाएँ और वाटरमार्क होते हैं, [temporary license](https://purchase.aspose.com/temporary-license/) 30 दिनों के लिए सीमाओं को हटाता है, और metered सीमाओं को हटाता है और वास्तविक उपयोग के आधार पर शुल्क लेता है।

**क्या मैं उपभोग सीमा से अधिक होने पर स्वचालित प्रतिक्रिया देकर बजट नियंत्रित कर सकता हूँ?**

हाँ। एक सामान्य प्रथा है कि आप नियमित रूप से [tracking methods](https://reference.aspose.com/slides/hi/python-net/aspose.slides/metered/) के माध्यम से वर्तमान उपभोग पढ़ें और एप्लिकेशन या मॉनिटरिंग स्तर पर अपनी सीमाएँ या अलर्ट लागू करें।