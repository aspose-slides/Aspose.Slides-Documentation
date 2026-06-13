---
title: JavaScript में PPTX को PPT में बदलें
linktitle: PPTX से PPT
type: docs
weight: 21
url: /hi/nodejs-java/convert-pptx-to-ppt/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- स्लाइड को बदलें
- PPTX को बदलें
- PPTX से PPT
- PPTX को PPT के रूप में सहेजें
- PPTX को PPT में निर्यात करें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ PPTX को PPT में आसानी से बदलें—PowerPoint फ़ॉर्मेट्स के साथ निर्बाध संगतता सुनिश्चित करें और अपनी प्रस्तुति का लेआउट और गुणवत्ता बनाए रखें।"
---
## **परिचय**

यह लेख समझाता है कि JavaScript का उपयोग करके PowerPoint प्रस्तुति को PPTX प्रारूप से PPT प्रारूप में कैसे बदलें। निम्नलिखित विषय कवर किया गया है।

- JavaScript में PPTX को PPT में बदलें

## **Java में PPTX को PPT में बदलें**

PPTX को PPT में बदलने के लिए JavaScript सैंपल कोड के लिए, कृपया नीचे दिए गए अनुभाग को देखें अर्थात् [Convert PPTX to PPT](#convert-pptx-to-ppt)। यह सिर्फ PPTX फ़ाइल को लोड करता है और PPT प्रारूप में सहेजता है। विभिन्न सहेजने के प्रारूप निर्दिष्ट करके, आप PPTX फ़ाइल को कई अन्य प्रारूपों जैसे PDF, XPS, ODP, HTML आदि में भी सहेज सकते हैं जैसा कि इन लेखों में चर्चा की गई है।

- [JavaScript में PPTX को PDF में बदलें](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/)
- [JavaScript में PPTX को XPS में बदलें](/slides/hi/nodejs-java/convert-powerpoint-to-xps/)
- [JavaScript में PPTX को HTML में बदलें](/slides/hi/nodejs-java/convert-powerpoint-to-html/)
- [JavaScript में PPTX को ODP में बदलें](/slides/hi/nodejs-java/save-presentation/)
- [JavaScript में PPTX को PNG में बदलें](/slides/hi/nodejs-java/convert-powerpoint-to-png/)

## **PPTX को PPT में बदलें**

PPTX को PPT में बदलने के लिए सिर्फ फ़ाइल नाम और सहेजने के प्रारूप को [**Presentation**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास के **Save** मेथड में पास करें। नीचे दिया गया JavaScript कोड सैंपल डिफ़ॉल्ट विकल्पों का उपयोग करके PPTX से PPT में एक Presentation को बदलता है।

```javascript
// एक Presentation ऑब्जेक्ट बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var presentation = new aspose.slides.Presentation("template.pptx");
// प्रस्तुति को PPT के रूप में सहेजें
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सभी PPTX प्रभाव और विशेषताएँ लेगेसी PPT (97–2003) फ़ॉर्मेट में सहेजने पर बरकरार रहती हैं?**

हमेशा नहीं। PPT फ़ॉर्मेट में कुछ नई क्षमताएँ (जैसे, कुछ प्रभाव, ऑब्जेक्ट्स, और व्यवहार) नहीं होती हैं, इसलिए परिवर्तन के दौरान सुविधाएँ सरल या रास्टराइज़ हो सकती हैं।

**क्या मैं पूरी प्रस्तुति के बजाय केवल चयनित स्लाइड्स को PPT में बदल सकता हूँ?**

सीधे सहेजना पूरे प्रस्तुति को लक्ष्य बनाता है। विशिष्ट स्लाइड्स को बदलने के लिए, उन स्लाइड्स के साथ एक नई प्रस्तुति बनाएँ और उसे PPT के रूप में सहेजें; वैकल्पिक रूप से, ऐसी सेवा/API का उपयोग करें जो प्रति‑स्लाइड रूपांतरण पैरामीटर का समर्थन करता हो।

**क्या पासवर्ड‑सुरक्षित प्रस्तुतियों का समर्थन किया जाता है?**

हां। आप यह पता लगा सकते हैं कि फ़ाइल संरक्षित है या नहीं, पासवर्ड के साथ इसे खोल सकते हैं, और सहेजे गए PPT के लिए [रक्षा/एन्क्रिप्शन सेटिंग्स कॉन्फ़िगर करें](/slides/hi/nodejs-java/password-protected-presentation/) भी कर सकते हैं।