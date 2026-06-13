---
title: PPTX को PPT में .NET में परिवर्तित करें
linktitle: PPTX से PPT
type: docs
weight: 21
url: /hi/net/convert-pptx-to-ppt/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPTX रूपांतरित करें
- PPTX से PPT
- PPTX को PPT के रूप में सहेजें
- PPTX को PPT निर्यात करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PPTX को आसानी से PPT में बदलें—PowerPoint फ़ॉर्मेट के साथ निर्बाध संगतता सुनिश्चित करें और आपकी प्रस्तुति का लेआउट और गुणवत्ता संरक्षित रखें।"
---
## **अवलोकन**

यह लेख समझाता है कि C# का उपयोग करके PPTX फॉर्मेट की PowerPoint प्रस्तुति को PPT फॉर्मेट में कैसे बदला जाए। नीचे दिया गया विषय कवर किया गया है।

- C# में PPTX को PPT में बदलें

## **.NET में PPTX को PPT में बदलें**

C# नमूना कोड के लिए जो PPTX को PPT में बदलता है, कृपया नीचे के सेक्शन को देखें अर्थात् [Convert PPTX to PPT](#convert-pptx-to-ppt)। यह केवल PPTX फ़ाइल को लोड करता है और PPT फॉर्मेट में सहेजता है। विभिन्न सहेजने के फॉर्मेट निर्दिष्ट करके आप PPTX फ़ाइल को PDF, XPS, ODP, HTML आदि कई अन्य फ़ॉर्मेट में भी सहेज सकते हैं, जैसा कि इन लेखों में चर्चा की गई है।

- [.NET में PPTX को PDF में बदलें](/slides/hi/net/convert-powerpoint-to-pdf/)
- [.NET में PPTX को XPS में बदलें](/slides/hi/net/convert-powerpoint-to-xps/)
- [.NET में PPTX को HTML में बदलें](/slides/hi/net/convert-powerpoint-to-html/)
- [.NET में PPTX को ODP में बदलें](/slides/hi/net/save-presentation/)
- [.NET में PPTX को PNG में बदलें](/slides/hi/net/convert-powerpoint-to-png/)

## **PPTX को PPT में बदलें**
PPTX को PPT में बदलने के लिए बस फ़ाइल नाम और सहेजने के फॉर्मेट को [**Save**](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड में पास करें, जो [**Presentation**](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का भाग है। नीचे दिया गया C# कोड नमूना डिफ़ॉल्ट विकल्पों का उपयोग करके PPTX से PPT में एक प्रस्तुति को बदलता है।

```c#
// एक Presentation ऑब्जेक्ट बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("presentation.pptx");

// PPTX प्रस्तुति को PPT फ़ॉर्मेट में सहेजना
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **FAQ**

**क्या सभी PPTX इफ़ेक्ट्स और फीचर लेगेसी PPT (97–2003) फॉर्मेट में सहेजने पर बरकरार रहते हैं?**

हमेशा नहीं। PPT फॉर्मेट में कुछ नई क्षमताएँ (जैसे कुछ इफ़ेक्ट्स, ऑब्जेक्ट्स, और व्यवहार) नहीं होतीं, इसलिए रूपांतरण के दौरान फीचर सरल या रास्टराइज़ हो सकते हैं।

**क्या मैं पूरी प्रस्तुति के बजाय केवल चयनित स्लाइड्स को PPT में बदल सकता हूँ?**

डायरेक्ट सहेजना पूरी प्रस्तुति को लक्षित करता है। विशिष्ट स्लाइड्स को बदलने के लिए, उन स्लाइड्स के साथ एक नई प्रस्तुति बनाएँ और उसे PPT के रूप में सहेजें; वैकल्पिक रूप से, ऐसी सर्विस/API का उपयोग करें जो प्रति‑स्लाइड रूपांतरण पैरामीटर को सपोर्ट करती हो।

**क्या पासवर्ड‑सुरक्षित प्रस्तुतियों को सपोर्ट किया जाता है?**

हाँ। आप पता लगा सकते हैं कि फ़ाइल संरक्षित है या नहीं, पासवर्ड के साथ उसे खोल सकते हैं, और सहेजे गए PPT के लिए [protection/encryption सेटिंग्स को कॉन्फ़िगर](/slides/hi/net/password-protected-presentation/) भी कर सकते हैं।