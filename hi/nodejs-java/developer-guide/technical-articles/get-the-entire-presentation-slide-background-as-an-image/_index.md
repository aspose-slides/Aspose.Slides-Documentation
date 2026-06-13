---
title: प्रस्तुति से संपूर्ण स्लाइड पृष्ठभूमि को छवि के रूप में प्राप्त करें
linktitle: संपूर्ण स्लाइड पृष्ठभूमि
type: docs
weight: 95
url: /hi/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- स्लाइड पृष्ठभूमि
- अंतिम पृष्ठभूमि
- पृष्ठभूमि निकालें
- संपूर्ण पृष्ठभूमि
- पृष्ठभूमि को छवि में
- PPT पृष्ठभूमि
- PPTX पृष्ठभूमि
- ODP पृष्ठभूमि
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से संपूर्ण स्लाइड पृष्ठभूमियों को छवियों के रूप में निकालें, जिससे दृश्य कार्यप्रवाह सरल हो जाये।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों में, स्लाइड की पृष्ठभूमि कई तत्वों से बन सकती है, जिसमें स्लाइड बैकग्राउंड इमेज, प्रस्तुति थीम, रंग योजना, और मास्टर स्लाइड या लेआउट स्लाइड पर रखे गये वस्तुएँ शामिल हैं।

यह लेख Aspose.Slides का उपयोग करके संपूर्ण स्लाइड पृष्ठभूमि को छवि के रूप में निकालने का तरीका दिखाता है। चूँकि इस कार्य के लिए कोई एकल विधि नहीं है, इसलिए यह प्रक्रिया चयनित स्लाइड को एक अस्थायी प्रस्तुति में क्लोन करने, स्लाइड के आकारों को हटाने, और फिर परिणामी स्लाइड पृष्ठभूमि को छवि में बदलने पर आधारित है।

## **संपूर्ण स्लाइड पृष्ठभूमि प्राप्त करें**

Aspose.Slides for Node.js via Java संपूर्ण प्रस्तुति स्लाइड पृष्ठभूमि को छवि के रूप में निकालने के लिए कोई सरल विधि प्रदान नहीं करता, लेकिन आप नीचे दिए गये चरणों का पालन करके यह कर सकते हैं:
1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
1. प्रेजेंटेशन से स्लाइड का आकार प्राप्त करें।
1. एक स्लाइड का चयन करें।
1. एक अस्थायी प्रेजेंटेशन बनाएं।
1. अस्थायी प्रेजेंटेशन में समान स्लाइड आकार सेट करें।
1. चयनित स्लाइड को अस्थायी प्रेजेंटेशन में क्लोन करें।
1. क्लोन की गई स्लाइड से आकार (शेप्स) हटाएँ।
1. क्लोन की गई स्लाइड को छवि में बदलें।

निम्नलिखित कोड उदाहरण संपूर्ण प्रस्तुति स्लाइड पृष्ठभूमि को छवि के रूप में निकालता है।
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मास्टर स्लाइड के जटिल ग्रेडिएंट, टेक्सचर, या picture fills resulting बैकग्राउंड इमेज में संरक्षित रहेंगे?**

हाँ। Aspose.Slides स्लाइड, लेआउट या मास्टर पर परिभाषित ग्रेडिएंट, picture, और टेक्सचर भरावों को रेंडर करता है। यदि आपको विरासत में मिले मास्टरों से लुक को अलग करना है, तो निर्यात करने से पहले वर्तमान स्लाइड पर [अपना बैकग्राउंड सेट करें](/slides/hi/nodejs-java/presentation-background/) सेट करें।

**क्या मैं resulting बैकग्राउंड इमेज को सहेजने से पहले एक watermark जोड़ सकता हूँ?**

हाँ। आप कार्यशील स्लाइड की [कॉपी](/slides/hi/nodejs-java/clone-slides/) पर एक [watermark](/slides/hi/nodejs-java/watermark/) आकार या छवि जोड़ सकते हैं (अन्य सामग्री के पीछे रखकर) और फिर निर्यात कर सकते हैं। यह आपको watermark समाहित एक बैकग्राउंड इमेज उत्पन्न करने की अनुमति देता है।

**क्या मैं किसी विशिष्ट लेआउट या मास्टर की बैकग्राउंड को बिना किसी मौजूदा स्लाइड से बंधे प्राप्त कर सकता हूँ?**

हाँ। वांछित मास्टर या लेआउट तक पहुँचें, उसे आवश्यक आकार के साथ एक [अस्थायी स्लाइड](/slides/hi/nodejs-java/clone-slides/) पर लागू करें, और उस स्लाइड को निर्यात करके लेआउट या मास्टर से प्राप्त बैकग्राउंड प्राप्त करें।

**क्या ऐसी कोई लाइसेंसिंग प्रतिबंध हैं जो इमेज एक्सपोर्ट को प्रभावित करते हैं?**

रेंडरिंग सुविधाएँ एक [valid license](/slides/hi/nodejs-java/licensing/) के साथ पूरी तरह उपलब्ध हैं। मूल्यांकन मोड में आउटपुट में watermark जैसी सीमाएँ हो सकती हैं। बैच एक्सपोर्ट चलाने से पहले प्रक्रिया के प्रति एक बार लाइसेंस सक्रिय करें।