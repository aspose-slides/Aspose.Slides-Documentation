---
title: Python में PPTX को PPT में परिवर्तित करें
linktitle: PPTX से PPT
type: docs
weight: 21
url: /hi/python-net/convert-pptx-to-ppt/
keywords:
- PPTX से PPT
- PPTX को PPT में बदलें
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- Python
- Aspose.Slides
description: "Aspose.Slides for Python द्वारा .NET के माध्यम से PPTX को PPT में आसानी से बदलें—PowerPoint फ़ॉर्मेट्स के साथ सहज संगतता सुनिश्चित करें और अपनी प्रस्तुति के लेआउट और गुणवत्ता को बनाए रखें।"
---
## **अवलोकन**

Aspose.Slides for Python आपको कोड के माध्यम से आधुनिक PPTX प्रस्तुतियों को पुरानी PPT फ़ॉर्मेट में बदलने की अनुमति देता है। एक PPTX खोलें और उसे PPT के रूप में निर्यात करें जबकि प्रस्तुति की सामग्री और लेआउट बरकरार रहे, जिससे परिणाम पुराने संस्करणों के PowerPoint के साथ संगत हो। वही वर्कफ़्लो अन्य आउटपुट जैसे PDF, XPS, ODP, HTML या छवियों को भी बना सकता है, इसलिए यह स्क्रिप्ट्स, CI पाइपलाइनों और बैच प्रोसेसिंग में सहजता से फिट बैठता है।

## **PPTX को PPT में परिवर्तित करें**

PPTX को PPT में परिवर्तित करने के लिए, बस फ़ाइल नाम और सहेजने के फ़ॉर्मेट को [save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) मेथड के [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास में पास करें। नीचे दिया गया Python उदाहरण डिफ़ॉल्ट विकल्पों का उपयोग करके एक प्रस्तुति को PPTX से PPT में परिवर्तित करता है।

```py
import aspose.slides as slides

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
presentation = slides.Presentation("presentation.pptx")

# प्रस्तुति को PPT फ़ाइल के रूप में सहेजें।
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सभी PPTX इफ़ेक्ट्स और फीचर लेगेसी PPT (97–2003) फ़ॉर्मेट में सहेजते समय बरकरार रहते हैं?**

हमेशा नहीं। PPT फ़ॉर्मेट में कुछ नई क्षमताएँ (जैसे कुछ इफ़ेक्ट्स, ऑब्जेक्ट्स, और व्यवहार) नहीं होते हैं, इसलिए परिवर्तन के दौरान फीचर सरल या रास्टराइज़ किए जा सकते हैं।

**क्या मैं पूरी प्रस्तुति के बजाय केवल चयनित स्लाइड्स को PPT में परिवर्तित कर सकता हूँ?**

सीधा सहेजना पूरी प्रस्तुति को लक्षित करता है। विशिष्ट स्लाइड्स को बदलने के लिए, उन स्लाइड्स के साथ एक नई प्रस्तुति बनाएं और उसे PPT के रूप में सहेजें; वैकल्पिक रूप से, ऐसी सेवा/API का उपयोग करें जो प्रति‑स्लाइड रूपांतरण पैरामीटर को सपोर्ट करती हो।

**क्या पासवर्ड‑सुरक्षित प्रस्तुतियों का समर्थन किया जाता है?**

हाँ। आप पता लगा सकते हैं कि फ़ाइल संरक्षित है या नहीं, उसे पासवर्ड के साथ खोल सकते हैं, और सहेजे गए PPT के लिए [configure protection/encryption settings](/slides/hi/python-net/password-protected-presentation/) भी कर सकते हैं।

**संबंधित देखें:**
- [Python में PPT & PPTX को PDF में बदलें | उन्नत विकल्प](/slides/hi/python-net/convert-powerpoint-to-pdf/)
- [Python में PowerPoint प्रस्तुतियों को XPS में बदलें](/slides/hi/python-net/convert-powerpoint-to-xps/)
- [Python में PowerPoint प्रस्तुतियों को HTML में बदलें](/slides/hi/python-net/convert-powerpoint-to-html/)
- [Python में PowerPoint स्लाइड्स को PNG में बदलें](/slides/hi/python-net/convert-powerpoint-to-png/)