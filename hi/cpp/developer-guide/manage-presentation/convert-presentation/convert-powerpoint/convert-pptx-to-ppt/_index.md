---
title: C++ में PPTX को PPT में बदलें
linktitle: PPTX से PPT
type: docs
weight: 21
url: /hi/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PPTX को PPT में आसानी से बदलें—PowerPoint फ़ॉर्मेट के साथ सहज संगतता सुनिश्चित करें और अपनी प्रस्तुति का लेआउट और गुणवत्ता बनाये रखें।"
---
## **परिचय**

यह लेख समझाता है कि C++ का उपयोग करके PPTX फ़ॉर्मेट में PowerPoint प्रस्तुति को PPT फ़ॉर्मेट में कैसे बदलें। निम्नलिखित विषय कवर किया गया है।

- C++ में PPTX को PPT में बदलें

## **C++ में PPTX को PPT में बदलें**

C++ नमूना कोड के लिए जो PPTX को PPT में बदलता है, कृपया नीचे दिए गए अनुभाग देखें अर्थात् [Convert PPTX to PPT](#convert-pptx-to-ppt)। यह केवल PPTX फ़ाइल को लोड करता है और इसे PPT फ़ॉर्मेट में सहेजता है। विभिन्न सहेजने के फ़ॉर्मेट निर्दिष्ट करके, आप PPTX फ़ाइल को कई अन्य फ़ॉर्मेट जैसे PDF, XPS, ODP, HTML आदि में भी सहेज सकते हैं जैसा कि इन लेखों में बताया गया है।

- [C++ में PPTX को PDF में बदलें](/slides/hi/cpp/convert-powerpoint-to-pdf/)
- [C++ में PPTX को XPS में बदलें](/slides/hi/cpp/convert-powerpoint-to-xps/)
- [C++ में PPTX को HTML में बदलें](/slides/hi/cpp/convert-powerpoint-to-html/)
- [C++ में PPTX को ODP में बदलें](/slides/hi/cpp/save-presentation/)
- [C++ में PPTX को PNG में बदलें](/slides/hi/cpp/convert-powerpoint-to-png/)

## **PPTX को PPT में बदलें**
PPTX को PPT में बदलने के लिए केवल फ़ाइल नाम और सहेजने का फ़ॉर्मेट [**Presentation**](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation/) क्लास की **Save** मेथड में पास करें। नीचे दिया गया C++ कोड नमूना डिफॉल्ट विकल्पों का उपयोग करके PPTX से PPT में प्रस्तुति को बदलता है।

```cpp
// PPTX लोड करें।
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT फ़ॉर्मेट में सहेजें।
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सभी PPTX प्रभाव और सुविधाएँ लेगेसी PPT (97–2003) फ़ॉर्मेट में सहेजने पर बनी रहती हैं?**

हमेशा नहीं। PPT फ़ॉर्मेट में कुछ नई क्षमताएँ नहीं होती हैं (जैसे, कुछ प्रभाव, ऑब्जेक्ट और व्यवहार), इसलिए परिवर्तन के दौरान सुविधाएँ सरल या रास्टराइज़ हो सकती हैं।

**क्या मैं पूरी प्रस्तुति के बजाय केवल चयनित स्लाइड्स को PPT में बदल सकता हूँ?**

प्रत्यक्ष सहेजना पूरी प्रस्तुति को लक्षित करता है। विशिष्ट स्लाइड्स को बदलने के लिए, केवल उन स्लाइड्स के साथ एक नई प्रस्तुति बनाएं और इसे PPT के रूप में सहेजें; वैकल्पिक रूप से, ऐसी सेवा/API का उपयोग करें जो प्रति-स्लाइड रूपांतरण पैरामीटर का समर्थन करता हो।

**क्या पासवर्ड-संरक्षित प्रस्तुतियों का समर्थन किया जाता है?**

हाँ। आप यह पता लगा सकते हैं कि फ़ाइल संरक्षित है या नहीं, पासवर्ड के साथ इसे खोल सकते हैं, और सहेजे गए PPT के लिए [सुरक्षा/एन्क्रिप्शन सेटिंग्स](/slides/hi/cpp/password-protected-presentation/) भी कॉन्फ़िगर कर सकते हैं।