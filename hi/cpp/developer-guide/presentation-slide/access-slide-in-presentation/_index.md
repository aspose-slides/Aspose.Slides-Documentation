---
title: C++ में प्रस्तुति स्लाइड्स तक पहुँच
linktitle: स्लाइड तक पहुँच
type: docs
weight: 20
url: /hi/cpp/access-slide-in-presentation/
keywords:
- स्लाइड तक पहुँच
- स्लाइड अनुक्रमणिका
- स्लाइड आईडी
- स्लाइड स्थिति
- स्थिति बदलें
- स्लाइड गुण
- स्लाइड नंबर
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स तक पहुँचने और उन्हें प्रबंधित करने के तरीके सीखें। कोड उदाहरणों के साथ उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति में स्लाइड्स तक पहुँचने और उनका प्रबंधन करने के तरीके को समझाता है। यह स्लाइड्स संग्रह से शून्य-आधारित अनुक्रमणिका के द्वारा स्लाइड्स को प्राप्त करने और `GetSlideById` मेथड का उपयोग करके किसी स्लाइड को उसके अनूठे ID से एक्सेस करने का प्रदर्शन करता है।

आप यह भी सीखेंगे कि `set_SlideNumber` मेथड का उपयोग करके स्लाइड की स्थिति कैसे बदलें और `set_FirstSlideNumber` मेथड से प्रस्तुति के प्रारंभिक स्लाइड नंबर को कैसे निर्धारित करें। उदाहरण प्रदर्शित करते हैं कि प्रस्तुति कैसे लोड करें, स्लाइड रेफ़रेंसेज़ प्राप्त करें, स्लाइड क्रम या नंबरिंग को अपडेट करें, और संशोधित प्रस्तुति को सहेजें।

## **इंडेक्स द्वारा स्लाइड तक पहुँच**

एक प्रस्तुति में सभी स्लाइड्स को स्लाइड स्थिति के आधार पर संख्यात्मक रूप से व्यवस्थित किया जाता है, जो 0 से शुरू होती है। पहली स्लाइड इंडेक्स 0 से एक्सेस की जा सकती है; दूसरी स्लाइड इंडेक्स 1 से एक्सेस होती है; आदि।

Presentation क्लास, जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है, सभी स्लाइड्स को एक [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) संग्रह (जिसमें [ISlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) ऑब्जेक्ट होते हैं) के रूप में प्रदर्शित करता है। यह C++ कोड आपको दिखाता है कि कैसे इंडेक्स के माध्यम से स्लाइड तक पहुँचा जाए: 

```c++
	// दस्तावेज़ डायरेक्टरी का पथ।
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentation क्लास का उदाहरण बनाता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **ID द्वारा स्लाइड तक पहुँच**

प्रति प्रस्तुति में प्रत्येक स्लाइड का एक अनूठा ID जुड़ा होता है। आप उस ID को लक्षित करने के लिए [GetSlideById()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/getslidebyid/) मेथड (जो [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है) का उपयोग कर सकते हैं। यह C++ कोड आपको दिखाता है कि वैध स्लाइड ID कैसे प्रदान करें और [GetSlideById()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/getslidebyid/) मेथड द्वारा उस स्लाइड तक पहुँचा जाए: 

```c++
	// डॉक्यूमेंट डायरेक्टरी का पथ।
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentation क्लास का उदाहरण बनाता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// स्लाइड का ID प्राप्त करता है
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// स्लाइड को उसके ID के माध्यम से एक्सेस करता है
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **स्लाइड स्थिति बदलें**

Aspose.Slides आपको स्लाइड की स्थिति बदलने की अनुमति देता है। उदाहरण के लिए, आप यह निर्दिष्ट कर सकते हैं कि पहली स्लाइड दूसरी स्लाइड बन जाए।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड का रेफ़रेंस (जिसकी स्थिति आप बदलना चाहते हैं) उसके इंडेक्स के माध्यम से प्राप्त करें।
3. [set_SlideNumber()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/set_slidenumber/) प्रॉपर्टी के माध्यम से स्लाइड की नई स्थिति सेट करें।
4. संशोधित प्रस्तुति को सहेजें।

यह C++ कोड एक ऐसी कार्रवाई दर्शाता है जिसमें स्थिति 1 की स्लाइड को स्थिति 2 में ले जाया जाता है:

```c++
	// डॉक्यूमेंट्स डायरेक्ट्री का पथ।
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Presentation क्लास का उदाहरण बनाता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// उस स्लाइड को प्राप्त करता है जिसकी स्थिति बदली जाएगी
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// स्लाइड के लिए नई स्थिति सेट करता है
	slide->set_SlideNumber(2);

	// संशोधित प्रस्तुति को सहेजता है
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

पहली स्लाइड दूसरी बन गई; दूसरी स्लाइड पहली बन गई। जब आप स्लाइड की स्थिति बदलते हैं, तो अन्य स्लाइड्स स्वचालित रूप से समायोजित हो जाती हैं।

## **स्लाइड नंबर सेट करें**

[set_FirstSlideNumber()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/set_firstslidenumber/) प्रॉपर्टी (जो [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास द्वारा प्रदान की गई है) का उपयोग करके आप प्रस्तुति में पहली स्लाइड के लिए नया नंबर निर्दिष्ट कर सकते हैं। यह कार्रवाई अन्य स्लाइड नंबरों को फिर से गणना करती है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड नंबर प्राप्त करें।
3. स्लाइड नंबर सेट करें।
4. संशोधित प्रस्तुति को सहेजें।

यह C++ कोड एक ऐसी कार्रवाई दर्शाता है जहाँ पहली स्लाइड नंबर को 10 पर सेट किया गया है: 

```c++
	// दस्तावेज़ डायरेक्टरी का पथ।
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Presentation क्लास का उदाहरण बनाता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// स्लाइड नंबर प्राप्त करता है
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// स्लाइड नंबर सेट करता है
	pres->set_FirstSlideNumber(2);
	
	// संशोधित प्रस्तुति को सहेजता है
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

यदि आप पहली स्लाइड को छोड़ना चाहते हैं, तो आप नंबरिंग को दूसरी स्लाइड से शुरू कर सकते हैं (और पहली स्लाइड के लिए नंबरिंग को छिपा सकते हैं) इस प्रकार:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या उपयोगकर्ता द्वारा देखा गया स्लाइड नंबर संग्रह की शून्य-आधारित अनुक्रमणिका से मेल खाता है?**

स्लाइड पर दिखाया गया नंबर 任意 मान (जैसे, 10) से शुरू हो सकता है और इसे अनुक्रमणिका से मेल करने की आवश्यकता नहीं है; यह संबंध प्रस्तुति की [first slide number](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/set_firstslidenumber/) सेटिंग द्वारा नियंत्रित होता है।

**क्या छुपी हुई स्लाइड्स अनुक्रमणिका को प्रभावित करती हैं?**

हां। एक छुपी हुई स्लाइड संग्रह में बनी रहती है और अनुक्रमणिका में गिनी जाती है; "hidden" का अर्थ प्रदर्शन है, न कि उसके संग्रह में स्थिति से।

**क्या अन्य स्लाइड्स जोड़ने या हटाने पर स्लाइड का अनुक्रमणिका बदलता है?**

हां। अनुक्रमणिकाएँ हमेशा स्लाइड्स के वर्तमान क्रम को दर्शाती हैं और इन्सर्ट, डिलीट और मूव ऑपरेशनों पर पुनः गणना की जाती हैं।