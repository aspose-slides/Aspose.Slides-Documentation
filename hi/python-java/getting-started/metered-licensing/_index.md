---
title: मीटर्ड लाइसेंसिंग
type: docs
weight: 100
url: /hi/python-java/metered-licensing/
keywords:
- लाइसेंस
- मीटर्ड लाइसेंस
- लाइसेंस कुंजियां
- सार्वजनिक कुंजी
- निजी कुंजी
- उपभोग मात्रा
- पावरपॉइंट
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "जाने कैसे Aspose.Slides for Python via Java मीटर्ड लाइसेंसिंग आपको PowerPoint और OpenDocument फ़ाइलों को लचीलादार तरीके से प्रोसेस करने देता है, और केवल उपयोग के आधार पर भुगतान करना पड़ता है।"
---
## **परिचय**

मीटर्ड लाइसेंसिंग एक लाइसेंसिंग तंत्र है जिसे मौजूदा लाइसेंसिंग तरीकों के साथ उपयोग किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के आपके उपयोग के आधार पर बिल प्राप्त करना चाहते हैं, तो मीटर्ड लाइसेंसिंग चुनें।

## **मीटर्ड कुंजी लागू करें**

{{% alert color="info" title="Note" %}}

मीटर्ड लाइसेंसिंग एक नया लाइसेंसिंग तंत्र है जिसे मौजूदा लाइसेंसिंग तरीकों के साथ उपयोग किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के आपके उपयोग के आधार पर बिल प्राप्त करना चाहते हैं, तो मीटर्ड लाइसेंसिंग चुनें।

जब आप मीटर्ड लाइसेंस खरीदते हैं, तो आपको कुंजियां मिलती हैं (और कोई लाइसेंस फ़ाइल नहीं)। यह मीटर्ड कुंजी Aspose द्वारा प्रदान की गई [Metered](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/) क्लास का उपयोग करके लागू की जा सकती है। अधिक विवरण के लिए, देखें [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. [Metered](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/) क्लास का एक इंस्टेंस बनाएं।

2. अपनी सार्वजनिक और निजी कुंजियां [setMeteredKey](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/#setMeteredKey) मेथड को पास करें।

3. कुछ प्रोसेसिंग करें (कार्यों को निष्पादित करें)।

4. [Metered](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/) क्लास की [getConsumptionQuantity](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/#getConsumptionQuantity) मेथड को कॉल करें।

आपको अब तक उपयोग की गई API अनुरोधों की मात्रा/संख्या दिखाई देनी चाहिए।

यह नमूना कोड दिखाता है कि मीटर्ड लाइसेंसिंग का उपयोग कैसे किया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Metered क्लास का एक इंस्टेंस बनाएं।
metered = Metered()

try:
    # सार्वजनिक और निजी कुंजियों को Metered ऑब्जेक्ट में पास करें।
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # API कॉल्स से पहले उपभोग मात्रा प्राप्त करें।
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # यहाँ Aspose.Slides API के साथ कुछ करें।
    # ...

    # API कॉल्स के बाद उपभोग मात्रा प्राप्त करें।
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Warning"  %}}

मीटर्ड लाइसेंसिंग का उपयोग करने के लिए आपको स्थिर इंटरनेट कनेक्शन चाहिए क्योंकि लाइसेंसिंग तंत्र लगातार हमारे सर्विसेज़ के साथ इंटरैक्ट करने और गणनाएँ करने के लिए इंटरनेट का उपयोग करता है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही एप्लिकेशन में मीटर्ड लाइसेंस को सामान्य (स्थायी या अस्थायी) लाइसेंस के साथ उपयोग कर सकता हूँ?**

हां। मीटर्ड एक अतिरिक्त लाइसेंसिंग तंत्र है जिसे मौजूदा [licensing methods](/slides/hi/python-java/licensing/) के साथ उपयोग किया सकता है। आप एप्लिकेशन शुरू होने पर कौन सा तंत्र लागू करना है, इसे चुनते हैं।

**मीटर्ड लाइसेंस के तहत उपभोग में क्या गिना जाता है: ऑपरेशन्स या फ़ाइलें?**

API उपयोग गिना जाता है, अर्थात् अनुरोधों या ऑपरेशनों की संख्या। आप वर्तमान उपभोग को [consumption-tracking methods](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/) के माध्यम से प्राप्त कर सकते हैं।

**क्या मीटर्ड माइक्रोसर्विसेज़ और सर्वरलेस पर्यावरण के लिए उपयुक्त है जहाँ इंस्टेंस अक्सर रीस्टार्ट होते हैं?**

हां। चूंकि लेखा-जोखा API कॉल स्तर पर किया जाता है, इसलिए बार-बार कोल्ड स्टार्ट वाले परिदृश्य संगत हैं, बशर्ते मीटर्ड गणनाओं के लिए स्थिर नेटवर्क एक्सेस उपलब्ध हो।

**क्या मीटर्ड लाइसेंस का उपयोग करने पर लाइब्रेरी की कार्यक्षमता स्थायी लाइसेंस की तुलना में अलग होती है?**

नहीं। यह केवल लाइसेंसिंग और बिलिंग तंत्र के बारे में है; उत्पाद की क्षमताएँ समान रहती हैं।

**मीटर्ड ट्रायल संस्करण और अस्थायी लाइसेंस से कैसे संबंधित है?**

ट्रायल संस्करण में सीमाएँ और वॉटरमार्क होते हैं, [temporary license](https://purchase.aspose.com/temporary-license/) 30 दिनों के लिए सीमाओं को हटाता है, और मीटर्ड सीमाओं को हटाता है और वास्तविक उपयोग के आधार पर शुल्क लेता है।

**क्या मैं उपभोग सीमा पार होने पर स्वतः प्रतिक्रिया देकर बजट नियंत्रित कर सकता हूँ?**

हां। एक सामान्य प्रथा यह है कि आप समय-समय पर [tracking methods](https://reference.aspose.com/slides/hi/python-java/aspose.slides/metered/) के माध्यम से वर्तमान उपभोग पढ़ें और एप्लिकेशन या मॉनिटरिंग स्तर पर अपनी सीमाएँ या अलर्ट लागू करें।