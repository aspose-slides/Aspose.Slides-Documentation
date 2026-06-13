---
title: Android पर PPTX को PPT में बदलें
linktitle: PPTX से PPT
type: docs
weight: 21
url: /hi/androidjava/convert-pptx-to-ppt/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPTX बदलें
- PPTX से PPT
- PPTX को PPT के रूप में सहेजें
- PPTX को PPT में निर्यात करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके PPTX को PPT में आसानी से बदलें—PowerPoint फ़ॉर्मेट के साथ सहज संगतता सुनिश्चित करें और अपनी प्रस्तुति का लेआउट और गुणवत्ता बनाए रखें।"
---
## **अवलोकन**

यह लेख Java का उपयोग करके PPTX प्रारूप में PowerPoint प्रस्तुति को PPT प्रारूप में परिवर्तित करने के बारे में बताता है। निम्नलिखित विषय कवर किया गया है।

- Java में PPTX को PPT में परिवर्तित करें

## **Android पर PPTX को PPT में परिवर्तित करें**

PPTX को PPT में परिवर्तित करने के लिए Java नमूना कोड के लिये, कृपया नीचे दिए गए अनुभाग देखें यानी [Convert PPTX to PPT](#convert-pptx-to-ppt)। यह केवल PPTX फ़ाइल को लोड करता है और PPT प्रारूप में सहेजता है। विभिन्न सहेजने के स्वरूप निर्दिष्ट करके, आप PPTX फ़ाइल को कई अन्य स्वरूपों जैसे PDF, XPS, ODP, HTML आदि में भी सहेज सकते हैं जैसा कि इन लेखों में चर्चा की गई है।

- [Android पर PPTX को PDF में परिवर्तित करें](/slides/hi/androidjava/convert-powerpoint-to-pdf/)
- [Android पर PPTX को XPS में परिवर्तित करें](/slides/hi/androidjava/convert-powerpoint-to-xps/)
- [Android पर PPTX को HTML में परिवर्तित करें](/slides/hi/androidjava/convert-powerpoint-to-html/)
- [Android पर PPTX को ODP में परिवर्तित करें](/slides/hi/androidjava/save-presentation/)
- [Android पर PPTX को PNG में परिवर्तित करें](/slides/hi/androidjava/convert-powerpoint-to-png/)

## **PPTX को PPT में परिवर्तित करें**
PPTX को PPT में परिवर्तित करने के लिए केवल फ़ाइल नाम और सहेजने के स्वरूप को [**Presentation**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास की **Save** मेथड में पास करें। नीचे दिया गया Java कोड नमूना डिफ़ॉल्ट विकल्पों का उपयोग करके PPTX से PPT में एक Presentation को परिवर्तित करता है।

```java
// एक Presentation ऑब्जेक्ट बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
Presentation presentation = new Presentation("template.pptx");

// प्रस्तुति को PPT के रूप में सहेजें
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सभी PPTX प्रभाव और सुविधाएँ लेगेसी PPT (97–2003) स्वरूप में सहेजते समय बनती रहेंगी?**

हमेशा नहीं। PPT स्वरूप में कुछ नई क्षमताएँ (जैसे, कुछ प्रभाव, ऑब्जेक्ट्स, और व्यवहार) नहीं होते, इसलिए परिवर्तन के दौरान सुविधाओं को सरल या रास्टर किया जा सकता है।

**क्या मैं पूरी प्रस्तुति के बजाय केवल चयनित स्लाइड्स को PPT में परिवर्तित कर सकता हूँ?**

सीधा सहेजना पूरी प्रस्तुति को लक्षित करता है। विशिष्ट स्लाइड्स को परिवर्तित करने के लिए, केवल उन स्लाइड्स के साथ एक नई प्रस्तुति बनाएँ और उसे PPT के रूप में सहेजें; वैकल्पिक रूप से, ऐसी सेवा/API का उपयोग करें जो प्रति-स्लाइड परिवर्तन पैरामीटर को समर्थन देती हो।

**क्या पासवर्ड‑सुरक्षित प्रस्तुतियों का समर्थन किया जाता है?**

हाँ। आप यह पता लगा सकते हैं कि फ़ाइल संरक्षित है या नहीं, पासवर्ड के साथ इसे खोल सकते हैं, और सहेजे गए PPT के लिए [configure protection/encryption settings](/slides/hi/androidjava/password-protected-presentation/) भी कर सकते हैं।