---
title: प्रस्तुति से संपूर्ण स्लाइड पृष्ठभूमि को छवि के रूप में प्राप्त करें
linktitle: संपूर्ण स्लाइड पृष्ठभूमि
type: docs
weight: 95
url: /hi/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- स्लाइड पृष्ठभूमि
- अंतिम पृष्ठभूमि
- पृष्ठभूमि निकालें
- संपूर्ण पृष्ठभूमि
- पृष्ठभूमि को छवि में
- पीपीटी पृष्ठभूमि
- पीपीटीएक्स पृष्ठभूमि
- ओडीपी पृष्ठभूमि
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से पूर्ण स्लाइड पृष्ठभूमियों को छवियों के रूप में निकालें, जिससे दृश्य कार्यप्रवाह सुव्यवस्थित हों।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों में, स्लाइड पृष्ठभूमि कई तत्वों से बन सकती है, जिसमें स्लाइड पृष्ठभूमि छवि, प्रस्तुति थीम, रंग योजना, और मास्टर स्लाइड या लेआउट स्लाइड पर रखे गए ऑब्जेक्ट शामिल हैं।

यह लेख Aspose.Slides for .NET का उपयोग करके संपूर्ण स्लाइड पृष्ठभूमि को छवि के रूप में निकालने का तरीका दिखाता है। चूँकि इस कार्य के लिए कोई एकल विधि उपलब्ध नहीं है, इसलिए दृष्टिकोण में चयनित स्लाइड को एक अस्थायी प्रस्तुति में क्लोन करना, स्लाइड के आकार हटाना, और फिर प्राप्त पृष्ठभूमि को छवि में बदलना शामिल है।

## **पूरी स्लाइड पृष्ठभूमि प्राप्त करें**

Aspose.Slides for Android via Java कोई सरल विधि नहीं देता जिससे संपूर्ण प्रस्तुति स्लाइड पृष्ठभूमि को छवि के रूप में निकाला जा सके, लेकिन आप नीचे दिए गए चरणों का पालन करके यह कर सकते हैं:
1. प्रस्तुति को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
1. प्रस्तुति से स्लाइड का आकार प्राप्त करें।
1. एक स्लाइड चुनें।
1. एक अस्थायी प्रस्तुति बनाएँ।
1. अस्थायी प्रस्तुति में वही स्लाइड आकार सेट करें।
1. चयनित स्लाइड को अस्थायी प्रस्तुति में क्लोन करें।
1. क्लोन की गई स्लाइड से आकृतियों को हटाएँ।
1. क्लोन की गई स्लाइड को छवि में परिवर्तित करें।

निम्नलिखित कोड उदाहरण संपूर्ण प्रस्तुति स्लाइड पृष्ठभूमि को छवि के रूप में निकालता है।
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मास्टर स्लाइड से जटिल ग्रेडिएंट, टेक्सचर, या चित्र भराव परिणामस्वरूप पृष्ठभूमि छवि में संरक्षित रहेंगे?**

हाँ। Aspose.Slides स्लाइड, लेआउट, या मास्टर पर परिभाषित ग्रेडिएंट, चित्र, और टेक्सचर भराव को रेंडर करता है। यदि आपको विरासत में मिले मास्टरों से दृश्य को अलग करना है, तो निर्यात से पहले वर्तमान स्लाइड पर [अपनी पृष्ठभूमि सेट करें](/slides/hi/androidjava/presentation-background/) सेट करें।

**क्या मैं परिणामस्वरूप पृष्ठभूमि छवि को सहेजने से पहले वॉटरमार्क जोड़ सकता हूँ?**

हाँ। आप [वॉटरमार्क जोड़ें](/slides/hi/androidjava/watermark/) आकार या छवि को कार्यशील [स्लाइड की कॉपी](/slides/hi/androidjava/clone-slides/) पर (दूसरी सामग्री के पीछे रखी हुई) जोड़ सकते हैं और फिर निर्यात कर सकते हैं। इससे आप वॉटरमार्क अंतर्निहित एक पृष्ठभूमि छवि बना सकते हैं।

**क्या मैं किसी विशिष्ट लेआउट या मास्टर की पृष्ठभूमि को बिना किसी मौजूदा स्लाइड से जोड़े प्राप्त कर सकता हूँ?**

हाँ। वांछित मास्टर या लेआउट तक पहुँचें, इसे आवश्यक आकार के साथ एक [अस्थायी स्लाइड](/slides/hi/androidjava/clone-slides/) पर लागू करें, और उस स्लाइड को निर्यात करके लेआउट या मास्टर से प्राप्त पृष्ठभूमि प्राप्त करें।

**क्या इमेज निर्यात को प्रभावित करने वाली लाइसेंस प्रतिबंध हैं?**

रेंडरिंग सुविधाएँ एक [मान्य लाइसेंस](/slides/hi/androidjava/licensing/) के साथ पूरी तरह उपलब्ध हैं। मूल्यांकन मोड में, आउटपुट में वॉटरमार्क जैसे प्रतिबंध हो सकते हैं। बैच निर्यात चलाने से पहले प्रत्येक प्रक्रिया में एक बार लाइसेंस सक्रिय करें।