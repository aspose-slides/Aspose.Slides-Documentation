---
title: किसी प्रस्तुति से पूरी स्लाइड पृष्ठभूमि को छवि के रूप में प्राप्त करें
linktitle: पूरी स्लाइड पृष्ठभूमि
type: docs
weight: 95
url: /hi/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- स्लाइड पृष्ठभूमि
- अंतिम पृष्ठभूमि
- पृष्ठभूमि निकालें
- पूरी पृष्ठभूमि
- पृष्ठभूमि को छवि में
- PPT पृष्ठभूमि
- PPTX पृष्ठभूमि
- ODP पृष्ठभूमि
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से पूरी स्लाइड पृष्ठभूमियों को छवियों के रूप में निकालें, जिससे दृश्य कार्यप्रवाह सुगम हो जाता है।"
---
## **अवलोकन**

PowerPoint प्रस्तुतियों में, स्लाइड पृष्ठभूमि कई तत्वों से बन सकती है, जिसमें स्लाइड पृष्ठभूमि छवि, प्रस्तुति थीम, रंग योजना, और मास्टर स्लाइड या लेआउट स्लाइड पर रखे गए ऑब्जेक्ट शामिल हैं।

यह लेख Aspose.Slides का उपयोग करके पूरी स्लाइड पृष्ठभूमि को छवि के रूप में निकालने का तरीका दिखाता है। चूंकि इस कार्य के लिए कोई एकल विधि नहीं है, इसलिए दृष्टिकोण में चयनित स्लाइड को एक अस्थायी प्रस्तुति में क्लोन करना, स्लाइड आकार को सेट करना, स्लाइड के आकार को समान बनाना, स्लाइड शैप्स को हटाना, और फिर resulting slide background को छवि में परिवर्तित करना शामिल है।

## **स्लाइड की पूरी पृष्ठभूमि प्राप्त करें**

Aspose.Slides for C++ पूरी प्रस्तुति स्लाइड पृष्ठभूमि को छवि के रूप में निकालने के लिए सीधा तरीका प्रदान नहीं करता, लेकिन आप नीचे दिए गए चरणों का पालन करके यह कर सकते हैं:
1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
1. प्रस्तुति से स्लाइड आकार प्राप्त करें।
1. एक स्लाइड चुनें।
1. एक अस्थायी प्रस्तुति बनाएं।
1. अस्थायी प्रस्तुति में समान स्लाइड आकार सेट करें।
1. चयनित स्लाइड को अस्थायी प्रस्तुति में क्लोन करें।
1. क्लोन की गई स्लाइड से शैप्स को हटाएं।
1. क्लोन की गई स्लाइड को छवि में परिवर्तित करें।

निम्नलिखित कोड उदाहरण पूरी प्रस्तुति स्लाइड पृष्ठभूमि को छवि के रूप में निकालता है।
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मास्टर स्लाइड से जटिल ग्रेडिएंट्स, टेक्सचर, या चित्र भरणों को परिणामी पृष्ठभूमि छवि में संरक्षित रखा जाएगा?**

हाँ। Aspose.Slides स्लाइड, लेआउट या मास्टर पर परिभाषित ग्रेडिएंट, चित्र, और टेक्सचर भरणों को रेंडर करता है। यदि आपको विरासत में मिले मास्टर से लुक अलग करना है, तो निर्यात से पहले वर्तमान स्लाइड पर [set an own background](/slides/hi/cpp/presentation-background/) सेट करें।

**क्या मैं सहेजने से पहले परिणामी पृष्ठभूमि छवि में वॉटरमार्क जोड़ सकता हूँ?**

हाँ। आप एक कार्यशील [copy of the slide](/slides/hi/cpp/clone-slides/) (अन्य सामग्री के पीछे रखी) पर [add a watermark](/slides/hi/cpp/watermark/) शैप या छवि जोड़ सकते हैं और फिर निर्यात कर सकते हैं। यह आपको वॉटरमार्क सहित पृष्ठभूमि छवि उत्पन्न करने की अनुमति देता है।

**क्या मैं किसी विशिष्ट लेआउट या मास्टर की पृष्ठभूमि को बिना किसी मौजूदा स्लाइड से जोड़े प्राप्त कर सकता हूँ?**

हाँ। इच्छित मास्टर या लेआउट तक पहुंचें, आवश्यक आकार के साथ एक [temporary slide](/slides/hi/cpp/clone-slides/) पर लागू करें, और उस स्लाइड को निर्यात करके उस लेआउट या मास्टर से प्राप्त पृष्ठभूमि प्राप्त करें।

**क्या छवि निर्यात पर लाइसेंसिंग सीमाएँ लागू होती हैं?**

रेंडरिंग सुविधाएँ एक [valid license](/slides/hi/cpp/licensing/) के साथ पूरी तरह उपलब्ध हैं। मूल्यांकन मोड में आउटपुट में वॉटरमार्क जैसे सीमाएँ हो सकती हैं। बैच निर्यात चलाने से पहले प्रक्रिया के प्रति एक बार लाइसेंस सक्रिय करें।