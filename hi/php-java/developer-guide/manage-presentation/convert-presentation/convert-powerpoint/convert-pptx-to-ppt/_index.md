---
title: PHP में PPTX को PPT में बदलें
linktitle: PPTX से PPT
type: docs
weight: 21
url: /hi/php-java/convert-pptx-to-ppt/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPTX बदलें
- PPTX से PPT
- PPTX को PPT के रूप में सहेजें
- PPTX को PPT में निर्यात करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ आसानी से PPTX को PPT में बदलें — PowerPoint फॉर्मेट्स के साथ सहज संगतता सुनिश्चित करें और अपनी प्रस्तुति की लेआउट और गुणवत्ता को बनाए रखें।"
---
## **सारांश**

यह लेख समझाता है कि PHP का उपयोग करके PPTX प्रारूप में PowerPoint प्रस्तुति को PPT प्रारूप में कैसे बदलें। नीचे दिए गए विषय को कवर किया गया है।

- PPTX को PPT में बदलें

## **PHP में PPTX को PPT में बदलना**

Java सैंपल कोड के लिए जिसे PPTX को PPT में बदलता है, कृपया नीचे सेक्शन देखें अर्थात् [PPTX को PPT में बदलें](#convert-pptx-to-ppt)। यह सिर्फ PPTX फ़ाइल को लोड करता है और PPT प्रारूप में सहेजता है। विभिन्न सहेजने के फ़ॉर्मेट निर्दिष्ट करके, आप PPTX फ़ाइल को कई अन्य फ़ॉर्मेट जैसे PDF, XPS, ODP, HTML आदि में भी सहेज सकते हैं जैसा कि इन लेखों में चर्चा की गई है।

- [PHP में PPTX को PDF में बदलें](/slides/hi/php-java/convert-powerpoint-to-pdf/)
- [PHP में PPTX को XPS में बदलें](/slides/hi/php-java/convert-powerpoint-to-xps/)
- [PHP में PPTX को HTML में बदलें](/slides/hi/php-java/convert-powerpoint-to-html/)
- [PHP में PPTX को ODP में बदलें](/slides/hi/php-java/save-presentation/)
- [PHP में PPTX को PNG में बदलें](/slides/hi/php-java/convert-powerpoint-to-png/)

## **PPTX को PPT में बदलें**
PPTX को PPT में बदलने के लिए बस फ़ाइल नाम और सहेजने का फ़ॉर्मेट **Save** मेथड को [**Presentation**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास में पास करें। नीचे दिया गया PHP कोड नमूना डिफ़ॉल्ट विकल्पों का उपयोग करके PPTX से PPT में एक प्रस्तुति को बदलता है।

```php
  # एक Presentation ऑब्जेक्ट बनाइए जो PPTX फ़ाइल का प्रतिनिधित्व करता है
  $presentation = new Presentation("template.pptx");
  # प्रस्तुति को PPT के रूप में सहेजें
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सभी PPTX प्रभाव और सुविधाएँ लेगेसी PPT (97–2003) फ़ॉर्मेट में सहेजते समय बनी रहती हैं?**

हमेशा नहीं। PPT फ़ॉर्मेट में कुछ नई क्षमताएँ (उदाहरण के लिए, कुछ प्रभाव, ऑब्जेक्ट और व्यवहार) नहीं होते, इसलिए रूपांतरण के दौरान सुविधाएँ सरलित या रैस्टराइज़ हो सकती हैं।

**क्या मैं पूरी प्रस्तुति के बजाय केवल चयनित स्लाइड्स को PPT में बदल सकता हूँ?**

सीधा सहेजना पूरी प्रस्तुति को लक्ष्य बनाता है। विशिष्ट स्लाइड्स को बदलने के लिए, उन स्लाइड्स के साथ नई प्रस्तुति बनाकर उसे PPT के रूप में सहेजें; वैकल्पिक रूप से, ऐसी सेवा/API प्रयोग करें जो प्रति‑स्लाइड रूपांतरण पैरामीटर को समर्थन देती हो।

**क्या पासवर्ड-रक्षित प्रस्तुतियों का समर्थन किया जाता है?**

हां। आप यह पता लगा सकते हैं कि फ़ाइल संरक्षित है या नहीं, पासवर्ड के साथ इसे खोल सकते हैं, और साथ ही सहेजे गए PPT के लिए [सुरक्षा/एन्क्रिप्शन सेटिंग्स कॉन्फ़िगर करें](/slides/hi/php-java/password-protected-presentation/) भी कर सकते हैं।