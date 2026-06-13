---
title: मीटरड लाइसेंसिंग
type: docs
weight: 90
url: /hi/net/metered-licensing/
keywords:
- लाइसेंस
- मीटरड लाइसेंस
- लाइसेंस कुंजियाँ
- सार्वजनिक कुंजी
- निजी कुंजी
- उपभोग मात्रा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for .NET मीटरड लाइसेंसिंग आपको PowerPoint और OpenDocument फ़ाइलों को लचीले ढंग से प्रोसेस करने देती है, और आप केवल अपने उपयोग के अनुसार भुगतान करते हैं।"
---
## **परिचय**

मीटरड लाइसेंसिंग एक लाइसेंसिंग तंत्र है जिसे मौजूदा लाइसेंसिंग विधियों के साथ उपयोग किया जा सकता है। यदि आप Aspose.Slides API सुविधाओं के उपयोग के आधार पर बिल प्राप्त करना चाहते हैं, तो आप मीटरड लाइसेंसिंग चुनते हैं।

## **मीटरड कुंजियों को लागू करें**

जब आप मीटरड लाइसेंस खरीदते हैं, तो आपको कुंजियाँ मिलती हैं (और कोई लाइसेंस फ़ाइल नहीं)। इस मीटरड कुंजी को Aspose द्वारा मीटरिंग ऑपरेशनों के लिए प्रदान की गई [Metered](https://reference.aspose.com/slides/hi/net/aspose.slides/metered/) क्लास का उपयोग करके लागू किया जा सकता है। अधिक विवरण के लिए देखें [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)।

1. [Metered](https://reference.aspose.com/slides/hi/net/aspose.slides/metered/) क्लास का एक इंस्टेंस बनाएँ।  
2. अपनी सार्वजनिक और निजी कुंजियों को [SetMeteredKey](https://reference.aspose.com/slides/hi/net/aspose.slides/metered/setmeteredkey/) मेथड में पास करें।  
3. कुछ प्रसंस्करण करें (कार्य करें)।  
4. `Metered` क्लास की [GetConsumptionQuantity](https://reference.aspose.com/slides/hi/net/aspose.slides/metered/getconsumptionquantity/) मेथड को कॉल करें।

आपको अब तक उपभोग की गई API अनुरोधों की मात्रा/संख्या दिखाई देगी।

यह नमूना कोड आपको मीटरड लाइसेंसिंग का उपयोग कैसे करें दिखाता है:

```cs
// Metered क्लास का एक उदाहरण बनाता है
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Metered ऑब्जेक्ट को सार्वजनिक और निजी कुंजियाँ पास करता है
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// API कॉल से पहले मीटरड डेटा मात्रा प्राप्त करता है
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// यहाँ Aspose.Slides API के साथ कुछ करें
// ...
// API कॉल के बाद मीटरड डेटा मात्रा प्राप्त करता है
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 
मीटरड लाइसेंसिंग का उपयोग करने के लिए आपको एक स्थिर इंटरनेट कनेक्शन चाहिए क्योंकि लाइसेंसिंग तंत्र हमारे सर्वरों के साथ निरंतर संपर्क में रहता है और गणनाएँ करता है। 
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मीटरड लाइसेंस को नियमित (स्थायी या अस्थायी) लाइसेंस के साथ उसी एप्लिकेशन में उपयोग कर सकता हूँ?**

हाँ। मीटरड एक अतिरिक्त लाइसेंसिंग तंत्र है जिसे मौजूदा [licensing methods](/slides/hi/net/licensing/) के साथ उपयोग किया जा सकता है। एप्लिकेशन शुरू होने पर आप तय कर सकते हैं कि कौन-सा तंत्र लागू करना है।

**मीटरड लाइसेंस के तहत उपभोग किस रूप में गिना जाता है: ऑपरेशन्स या फ़ाइलें?**

API उपयोग गिना जाता है, अर्थात अनुरोधों या ऑपरेशन्स की संख्या। आप वर्तमान उपभोग को [उपभोग ट्रैकिंग मेथड्स](https://reference.aspose.com/slides/hi/net/aspose.slides/metered/) के माध्यम से प्राप्त कर सकते हैं।

**क्या मीटरड माइक्रोसर्विसेज और सर्वरलेस वातावरण में उचित है जहाँ इंस्टेंस बार‑बार रीस्टार्ट होते हैं?**

हाँ। चूँकि लेखा-जोखा API‑कॉल स्तर पर किया जाता है, अक्सर होने वाले कोल्ड स्टार्ट परिदृश्य संगत हैं, बशर्ते मीटरड गणनाओं के लिए नेटवर्क पहुंच स्थिर हो।

**क्या मीटरड लाइसेंस प्रयोग करने पर लाइब्रेरी की कार्यक्षमता स्थायी लाइसेंस की तुलना में बदलती है?**

नहीं। यह केवल लाइसेंसिंग और बिलिंग तंत्र से संबंधित है; उत्पाद की क्षमताएँ समान रहती हैं।

**मीटरड ट्रायल संस्करण और अस्थायी लाइसेंस से कैसे संबंधित है?**

ट्रायल संस्करण में सीमाएँ और वॉटरमार्क होते हैं, जबकि [अस्थायी लाइसेंस](https://purchase.aspose.com/temporary-license/) 30 दिनों के लिए सीमाओं को हटाता है, और मीटरड वास्तविक उपयोग के आधार पर सीमाओं को हटाता है और शुल्क लेता है।

**क्या मैं उपभोग सीमा पार होने पर स्वचालित रूप से प्रतिक्रिया देकर बजट नियंत्रित कर सकता हूँ?**

हाँ। आम तौर पर आप [ट्रैकिंग मेथड्स](https://reference.aspose.com/slides/hi/net/aspose.slides/metered/) के माध्यम से वर्तमान उपभोग को नियमित रूप से पढ़ते हैं और एप्लिकेशन या मॉनिटरिंग स्तर पर अपनी सीमाएँ या अलर्ट सेट करते हैं।