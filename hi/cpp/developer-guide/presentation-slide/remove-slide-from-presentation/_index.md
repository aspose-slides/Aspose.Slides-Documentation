---
title: C++ में प्रेजेंटेशन से स्लाइड हटाएँ
linktitle: स्लाइड हटाएँ
type: docs
weight: 30
url: /hi/cpp/remove-slide-from-presentation/
keywords:
- स्लाइड हटाएँ
- स्लाइड हटाएँ
- अनावश्यक स्लाइड हटाएँ
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों से आसानी से स्लाइड हटाएँ। स्पष्ट कोड उदाहरण प्राप्त करें और अपना कार्यप्रवाह तेज़ करें।"
---
## **परिचय**

यदि कोई स्लाइड (या उसकी सामग्री) अनावश्यक हो जाए, तो आप इसे हटा सकते हैं। Aspose.Slides प्रदान करता है [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास जो [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) को समेटे हुए है, जो प्रस्तुति में सभी स्लाइडों का रिपॉज़िटरी है। किसी ज्ञात [ISlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) ऑब्जेक्ट के लिए पॉइंटर्स (रेफ़रेंस या इंडेक्स) का उपयोग करके, आप वह स्लाइड निर्दिष्ट कर सकते हैं जिसे आप हटाना चाहते हैं। 

## **रेफ़रेंस द्वारा स्लाइड हटाएँ**

1. [Presentation] क्लास का एक उदाहरण बनाएँ।  
1. अपने हटाने के इच्छित स्लाइड का ID या इंडेक्स के माध्यम से रेफ़रेंस प्राप्त करें।  
1. प्रस्तुति से संदर्भित स्लाइड को हटाएँ।  
1. परिवर्तित प्रस्तुति को सहेजें।  

यह C++ कोड दिखाता है कि रेफ़रेंस के द्वारा स्लाइड कैसे हटाएँ:  

```c++
	// दस्तावेज़ निर्देशिका का पथ
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// एक Presentation वस्तु बनाता है जो प्रस्तुति फ़ाइल को दर्शाती है
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// स्लाइड संग्रह में उसके इंडेक्स के माध्यम से स्लाइड तक पहुंचता है
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// संदर्भ के माध्यम से एक स्लाइड को हटाता है
	pres->get_Slides()->Remove(slide);

	// परिवर्तित प्रस्तुति को सहेजता है
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **इंडेक्स द्वारा स्लाइड हटाएँ**

1. [Presentation] क्लास का एक उदाहरण बनाएँ।  
1. इंडेक्स स्थिति के माध्यम से प्रस्तुति से स्लाइड को हटाएँ।  
1. परिवर्तित प्रस्तुति को सहेजें।  

यह C++ कोड दिखाता है कि इंडेक्स के द्वारा स्लाइड कैसे हटाएँ:  

```c++
	// दस्तावेज़ निर्देशिका का पथ
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// एक Presentation वस्तु बनाता है जो प्रस्तुति फ़ाइल को दर्शाती है
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// स्लाइड इंडेक्स के माध्यम से एक स्लाइड हटाता है
	pres->get_Slides()->RemoveAt(0);

	// परिवर्तित प्रस्तुति को सहेजता है
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **अप्रयुक्त लेआउट स्लाइड हटाएँ**

Aspose.Slides प्रदान करता है [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) मेथड ([Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) क्लास से) जिससे आप अनावश्यक और अप्रयुक्त लेआउट स्लाइड को हटा सकते हैं। यह C++ कोड दर्शाता है कि PowerPoint प्रस्तुति में लेआउट स्लाइड को कैसे हटाया जाए:  

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **अप्रयुक्त मास्टर स्लाइड हटाएँ**

Aspose.Slides प्रदान करता है [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) मेथड ([Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) क्लास से) जिससे आप अनावश्यक और अप्रयुक्त मास्टर स्लाइड को हटा सकते हैं। यह C++ कोड दर्शाता है कि PowerPoint प्रस्तुति में मास्टर स्लाइड को कैसे हटाया जाए:  

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड को हटाने के बाद स्लाइड इंडेक्स का क्या होता है?**

हटाने के बाद, [संग्रह](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidecollection/) पुनः‑इंडेक्स करता है: हर बाद की स्लाइड एक पोजीशन बाएँ शिफ्ट हो जाती है, इसलिए पहले के इंडेक्स नंबर पुराने हो जाते हैं। यदि आपको स्थायी रेफ़रेंस चाहिए, तो प्रत्येक स्लाइड के स्थायी ID का उपयोग करें, न कि उसके इंडेक्स का।  

**क्या स्लाइड का ID उसके इंडेक्स से अलग है, और क्या यह पड़ोसी स्लाइड हटाने पर बदलता है?**

हां। इंडेक्स स्लाइड की स्थिति है और स्लाइड जोड़ने या हटाने पर बदलता है। स्लाइड ID एक स्थायी पहचानकर्ता है और अन्य स्लाइड हटाने पर नहीं बदलता।  

**स्लाइड को हटाने से स्लाइड सेक्शन पर क्या प्रभाव पड़ता है?**

यदि स्लाइड किसी सेक्शन से संबंधित थी, तो वह सेक्शन केवल एक कम स्लाइड रखेगा। सेक्शन संरचना वैसी ही बनी रहती है; यदि कोई सेक्शन खाली हो जाए, तो आप [सेक्शन हटाएँ या पुनः व्यवस्थित करें](/slides/hi/cpp/slide-section/) को आवश्यक अनुसार कर सकते हैं।  

**स्लाइड हटाने पर उससे जुड़े नोट्स और टिप्पणियों का क्या होता है?**

[नोट्स](/slides/hi/cpp/presentation-notes/) और [टिप्पणियाँ](/slides/hi/cpp/presentation-comments/) उस विशिष्ट स्लाइड से जुड़े होते हैं और वह हटाने के साथ ही हट जाते हैं। अन्य स्लाइडों की सामग्री पर कोई प्रभाव नहीं पड़ता।  

**स्लाइड हटाना और अप्रयुक्त लेआउट/मास्टर को साफ़ करना में क्या अंतर है?**

डिलीट करने से डेक से विशिष्ट सामान्य स्लाइड हटती हैं। अप्रयुक्त लेआउट/मास्टर को साफ़ करने से उन लेआउट या मास्टर स्लाइड्स को हटाया जाता है जिनका किसी भी स्लाइड द्वारा संदर्भ नहीं है, जिससे फ़ाइल आकार घटता है जबकि शेष स्लाइड सामग्री नहीं बदलती। ये कार्य परस्पर पूरक हैं: आमतौर पर पहले डिलीट करें, फिर साफ़ करें।