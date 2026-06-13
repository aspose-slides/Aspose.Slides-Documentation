---
title: C++ में प्रेजेंटेशन इंक ऑब्जेक्ट्स प्रबंधित करें
linktitle: इंक प्रबंधित करें
type: docs
weight: 95
url: /hi/cpp/manage-ink/
keywords:
- इंक
- इंक ऑब्जेक्ट
- इंक ट्रेस
- इंक प्रबंधित करें
- इंक बनाएं
- ड्रॉइंग
- PowerPoint
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "PowerPoint इंक ऑब्जेक्ट्स को प्रबंधित करें—Aspose.Slides for C++ के साथ डिजिटल इंक बनाएं, संपादित करें और स्टाइल करें। ट्रेसेस, ब्रश रंग और आकार के कोड नमूने प्राप्त करें।"
---
## **Introduction**

PowerPoint इंक फ़ंक्शन प्रदान करता है जिससे आप गैर-स्टैंडर्ड आकृतियाँ बना सकते हैं, जिन्हें स्लाइड पर अन्य वस्तुओं को उजागर करने, कनेक्शन और प्रक्रियाओं को दर्शाने, तथा विशिष्ट आइटमों पर ध्यान आकर्षित करने के लिए उपयोग किया जा सकता है। 

Aspose.Slides [Aspose.Slides.Ink](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ink/) इंटरफ़ेस प्रदान करता है, जिसमें उन प्रकारों को शामिल किया गया है जो आपको इंक ऑब्जेक्ट बनाने और प्रबंधित करने के लिए आवश्यक हैं। 

## **सामान्य ऑब्जेक्ट्स और इंक ऑब्जेक्ट्स के बीच अंतर**

PowerPoint स्लाइड पर ऑब्जेक्ट्स आमतौर पर शैप ऑब्जेक्ट्स द्वारा दर्शाए जाते हैं। शैप ऑब्जेक्ट, सबसे सरल रूप में, एक कंटेनर होता है जो स्वयं ऑब्जेक्ट (उसका फ्रेम) के क्षेत्र को उसकी गुणों के साथ परिभाषित करता है। इसके अलावा इसमें कंटेनर के क्षेत्र का आकार, कंटेनर का आकार, कंटेनर की पृष्ठभूमि आदि शामिल हैं। अधिक जानकारी के लिए, देखें [Shape Layout Format](https://docs.aspose.com/slides/hi/cpp/shape-manipulations/#access-layout-formats-for-shape)。

हालाँकि, जब PowerPoint इंक ऑब्जेक्ट से निपटता है, तो यह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी गुणों को अनदेखा करता है सिवाय उसके आकार के। कंटेनर क्षेत्र का आकार मानक `width` और `height` मानों द्वारा निर्धारित होता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंकशेप ट्रेसेस**

ट्रेस एक बुनियादी तत्व या मानक है जो उपयोगकर्ता द्वारा डिजिटल इंक लिखते समय पेन की गति को रिकॉर्ड करने के लिए उपयोग किया जाता है। ट्रेसेस ऐसी रिकॉर्डिंग्स हैं जो जुड़े हुए बिंदुओं की क्रमावली का वर्णन करती हैं। 

एन्कोडिंग का सबसे सरल रूप प्रत्येक सैंपल बिंदु के X और Y निर्देशांक निर्दिष्ट करता है। जब सभी जुड़े बिंदुओं को रेंडर किया जाता है, तो यह इस प्रकार की छवि बनती है:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्रॉइंग के लिए ब्रश गुण**

आप ब्रश का उपयोग ट्रेस तत्वों के बिंदुओं को जोड़ने वाली रेखाएँ बनाने के लिये कर सकते हैं। ब्रश का अपना रंग और आकार होता है, जो `Brush.Color` और `Brush.Size` गुणों के अनुरूप होता है। 

### **इंक ब्रश का रंग सेट करें**

यह C++ कोड आपको ब्रश का रंग सेट करने का तरीका दिखाता है:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **इंक ब्रश का आकार सेट करें** 

यह C++ कोड आपको ब्रश का आकार सेट करने का तरीका दिखाता है:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

आमतौर पर, ब्रश की चौड़ाई और ऊँचाई मेल नहीं खाती, इसलिए PowerPoint ब्रश का आकार प्रदर्शित नहीं करता (डेटा सेक्शन ग्रे रंग में दिखाया जाता है)। लेकिन जब ब्रश की चौड़ाई और ऊँचाई समान होती है, तो PowerPoint उसका आकार इस प्रकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टता के लिए, चलिए इंक ऑब्जेक्ट की ऊँचाई बढ़ाते हैं और महत्वपूर्ण आयामों की समीक्षा करते हैं: 

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ्रेम) ब्रश के आकार को नहीं मानता—यह हमेशा मान लेता है कि रेखा की मोटाई शून्य है (अंतिम छवि देखें)। 

इसलिए, पूरे इंक ऑब्जेक्ट के दृश्यमान क्षेत्र का निर्धारण करने के लिए हमें ट्रेस ऑब्जेक्ट्स के ब्रश आकार को ध्यान में रखना होगा। यहाँ, लक्ष्य ऑब्जेक्ट (हैंडराइटन टेक्स्ट ट्रेस ऑब्जेक्ट) को कंटेनर (फ्रेम) के आकार में स्केल किया गया है। जब कंटेनर (फ्रेम) का आकार बदलता है, तो ब्रश का आकार स्थिर रहता है और इसके विपरीत भी। 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint टेक्स्ट के साथ काम करने पर भी वही व्यवहार प्रदर्शित करता है:

![ink_powerpoint6](ink_powerpoint6.png)

**अधिक पढ़ना**

* सामान्य रूप से शैप्स के बारे में पढ़ने के लिए, देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/cpp/powerpoint-shapes/) अनुभाग। 
* प्रभावी मानों के बारे में अधिक जानकारी के लिए, देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/cpp/shape-effective-properties/#get-effective-font-height-value)।