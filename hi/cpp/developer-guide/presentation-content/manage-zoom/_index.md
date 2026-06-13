---
title: C++ में प्रस्तुति ज़ूम प्रबंधित करें
linktitle: ज़ूम प्रबंधित करें
type: docs
weight: 60
url: /hi/cpp/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ ज़ूम बनाएँ और अनुकूलित करें — सेक्शन के बीच कूदें, थंबनेल और ट्रांज़िशन PPT, PPTX और ODP प्रस्तुतियों में जोड़ें।"
---
## **परिचय**

PowerPoint में ज़ूम आपको प्रस्तुति के विशेष स्लाइड, सेक्शन और भागों पर जाकर और वापस आने की सुविधा देता है। जब आप प्रस्तुत कर रहे होते हैं, तो सामग्री में जल्दी से नेविगेट करने की यह क्षमता बहुत उपयोगी साबित हो सकती है।

![overview_image](Overview.png)

* पूरी प्रस्तुति को एक ही स्लाइड पर संक्षिप्त करने हेतु, [सारांश ज़ूम](#Summary-Zoom) का उपयोग करें।
* केवल चयनित स्लाइड दिखाने के लिए, [स्लाइड ज़ूम](#Slide-Zoom) का उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, [सेक्शन ज़ूम](#Section-Zoom) का उपयोग करें।

## **स्लाइड ज़ूम**
स्लाइड ज़ूम आपके प्रस्तुति को अधिक गतिशील बना सकता है, जिससे आप प्रस्तुति के प्रवाह को बाधित किए बिना किसी भी क्रम में स्लाइड्स के बीच स्वतंत्र रूप से नेविगेट कर सकते हैं। स्लाइड ज़ूम छोटे प्रस्तुतियों के लिए बहुत उपयुक्त हैं जिनमें कई सेक्शन नहीं होते, लेकिन आप उन्हें विभिन्न प्रस्तुति परिदृश्यों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको कई जानकारी के टुकड़ों में गहराई से जाने की अनुमति देते हैं जबकि आप ऐसा महसूस करते हैं कि आप एक ही कैनवस पर हैं।

![overview_image](slidezoomsel.png)

स्लाइड ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/zoomimagetype/) एनेमरेशन, [IZoomFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/izoomframe/) इंटरफ़ेस, और [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) इंटरफ़ेस के तहत कुछ मेथड्स प्रदान करता है।

### **ज़ूम फ्रेम बनाएँ**

आप एक स्लाइड पर ज़ूम फ्रेम इस प्रकार जोड़ सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2.	उन नई स्लाइड्स को बनाएँ जिन्हें आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
3.	बनी हुई स्लाइड्स में पहचान पाठ और पृष्ठभूमि जोड़ें।
4.	पहली स्लाइड में ज़ूम फ्रेम (बनी हुई स्लाइड्स के रेफ़रेंसेस सहित) जोड़ें।
5.	परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड दिखाता है कि स्लाइड पर ज़ूम फ्रेम कैसे बनाया जाए:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//प्रस्तुति में नई स्लाइड्स जोड़ता है
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// दूसरी स्लाइड के लिए पृष्ठभूमि बनाता है
SetSlideBackground(slide2, Color::get_Cyan());

// दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// तीसरी स्लाइड के लिए पृष्ठभूमि बनाता है
SetSlideBackground(slide3, Color::get_DarkKhaki());

// तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// प्रस्तुति को सहेजता है
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **कस्टम इमेज के साथ ज़ूम फ्रेम बनाएँ**
Aspose.Slides for C++ के साथ, आप इस प्रकार अलग स्लाइड प्रीव्यू इमेज के साथ ज़ूम फ्रेम बना सकते हैं: 
1.	[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2.	एक नई स्लाइड बनाएँ जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
3.	स्लाइड में पहचान पाठ और पृष्ठभूमि जोड़ें।
4.	[IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) ऑब्जेक्ट बनाएँ, इसके लिए उस इमेज को Images कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट से सम्बंधित है और फ्रेम को भरने के लिए उपयोग की जाएगी।
5.	पहली स्लाइड में ज़ूम फ्रेम (बनी हुई स्लाइड के रेफ़रेंस सहित) जोड़ें।
6.	परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड दिखाता है कि अलग इमेज के साथ ज़ूम फ्रेम कैसे बनाया जाए:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//प्रस्तुति में नई स्लाइड जोड़ता है
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//दूसरी स्लाइड के लिए पृष्ठभूमि बनाता है
SetSlideBackground(slide, Color::get_Cyan());

//तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//ZoomFrame ऑब्जेक्ट जोड़ता है
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

//प्रस्तुति को सहेजता है
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **ज़ूम फ्रेम का फ़ॉर्मेटिंग**
पिछले सेक्शन में हमने सरल ज़ूम फ्रेम बनाने का तरीका दिखाया था। अधिक जटिल ज़ूम फ्रेम बनाने के लिए आपको साधारण फ्रेम के फ़ॉर्मेटिंग को बदलना होगा। ज़ूम फ्रेम पर लागू करने के कई फ़ॉर्मेटिंग विकल्प उपलब्ध हैं। 

आप स्लाइड पर ज़ूम फ्रेम के फ़ॉर्मेटिंग को इस प्रकार नियंत्रित कर सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2.	उन नई स्लाइड्स को बनाएँ जिन्हें आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
3.	बनी हुई स्लाइड्स में कुछ पहचान पाठ और पृष्ठभूमि जोड़ें।
4.	पहली स्लाइड में ज़ूम फ्रेम (बनी हुई स्लाइड्स के रेफ़रेंसेस सहित) जोड़ें।
5.	[IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) ऑब्जेक्ट बनाएँ, इसके लिए इमेज को Images कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट से सम्बंधित है और फ्रेम को भरने के लिए उपयोग की जाएगी।
6.	पहले ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
7.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट के लिए लाइन फ़ॉर्मेट बदलें।
8.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट की इमेज से पृष्ठभूमि हटाएँ।
5.	परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड दिखाता है कि स्लाइड पर ज़ूम फ्रेम के फ़ॉर्मेटिंग को कैसे बदला जाए:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//प्रस्तुति में नई स्लाइड्स जोड़ता है
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

//दूसरी स्लाइड के लिए पृष्ठभूमि बनाता है
SetSlideBackground(slide2, Color::get_Cyan());

//दूसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//तीसरी स्लाइड के लिए पृष्ठभूमि बनाता है
SetSlideBackground(slide3, Color::get_DarkKhaki());

//तीसरी स्लाइड के लिए टेक्स्ट बॉक्स बनाता है
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ZoomFrame ऑब्जेक्ट्स जोड़ता है
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
//zoomFrame1 ऑब्जेक्ट के लिए कस्टम इमेज सेट करता है
zoomFrame1->set_Image(image);

//zoomFrame2 ऑब्जेक्ट के लिए ज़ूम फ्रेम फ़ॉर्मेट सेट करता है
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

//zoomFrame2 ऑब्जेक्ट के लिए पृष्ठभूमि न दिखाने की सेटिंग
zoomFrame2->set_ShowBackground(false);

//प्रस्तुति को सहेजता है
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **सेक्शन ज़ूम**

सेक्शन ज़ूम आपके प्रस्तुति में किसी सेक्शन का लिंक होता है। आप सेक्शन ज़ूम का उपयोग उन सेक्शन पर वापस जाने के लिए कर सकते हैं जिन्हें आप वास्तव में ज़ोर देना चाहते हैं। या आप उनका उपयोग इस बात को उजागर करने के लिए कर सकते हैं कि आपके प्रस्तुति के विभिन्न भाग कैसे आपस में जुड़े हुए हैं। 

![overview_image](seczoomsel.png)

सेक्शन ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ISectionZoomFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isectionzoomframe/) इंटरफ़ेस और [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) इंटरफ़ेस के तहत कुछ मेथड्स प्रदान करता है।

### **सेक्शन ज़ूम फ्रेम बनाएँ**

आप एक स्लाइड पर सेक्शन ज़ूम फ्रेम इस प्रकार जोड़ सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2.	एक नई स्लाइड बनाएँ। 
3.	बनी हुई स्लाइड में पहचान पृष्ठभूमि जोड़ें।
4.	एक नया सेक्शन बनाएँ जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनी हुई सेक्शन के रेफ़रेंसेस सहित) जोड़ें।
6.	परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड दिखाता है कि स्लाइड पर ज़ूम फ्रेम कैसे बनाया जाए:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//प्रस्तुति में नई स्लाइड जोड़ता है
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

//प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 1", slide);

//SectionZoomFrame ऑब्जेक्ट जोड़ता है
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

//प्रस्तुति को सहेजता है
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाएँ**

Aspose.Slides for C++ के साथ, आप इस प्रकार अलग स्लाइड प्रीव्यू इमेज के साथ सेक्शन ज़ूम फ्रेम बना सकते हैं: 

1.	[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2.	एक नई स्लाइड बनाएँ।
3.	बनी हुई स्लाइड में पहचान पृष्ठभूमि जोड़ें।
4.	एक नया सेक्शन बनाएँ जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
5.	[IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) ऑब्जेक्ट बनाएँ, इसके लिए इमेज को Images कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट से सम्बंधित है और फ्रेम को भरने के लिए उपयोग की जाएगी।
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बने हुए सेक्शन के रेफ़रेंस सहित) जोड़ें।
6.	परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड दिखाता है कि अलग इमेज के साथ ज़ूम फ्रेम कैसे बनाया जाए:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//प्रस्तुति में नई स्लाइड जोड़ता है
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 1", slide);

// ज़ूम ऑब्जेक्ट के लिए नई इमेज बनाता है
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// SectionZoomFrame ऑब्जेक्ट जोड़ता है
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// प्रस्तुति को सहेजता है
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **सेक्शन ज़ूम फ्रेम का फ़ॉर्मेटिंग**

अधिक जटिल सेक्शन ज़ूम फ्रेम बनाने के लिए आपको साधारण फ्रेम के फ़ॉर्मेटिंग को बदलना होगा। सेक्शन ज़ूम फ्रेम पर लागू करने के कई फ़ॉर्मेटिंग विकल्प उपलब्ध हैं। 

आप स्लाइड पर सेक्शन ज़ूम फ्रेम के फ़ॉर्मेटिंग को इस प्रकार नियंत्रित कर सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2.	एक नई स्लाइड बनाएँ।
3.	बनी हुई स्लाइड में पहचान पृष्ठभूमि जोड़ें।
4.	एक नया सेक्शन बनाएँ जिसे आप ज़ूम फ्रेम से लिंक करना चाहते हैं। 
5.	पहली स्लाइड में सेक्शन ज़ूम फ्रेम (बनी हुई सेक्शन के रेफ़रेंसेस सहित) जोड़ें।
6.	बने हुए सेक्शन ज़ूम ऑब्जेक्ट का आकार और स्थिति बदलें।
7.	[IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) ऑब्जेक्ट बनाएँ, इसके लिए इमेज को Images कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट से सम्बंधित है और फ्रेम को भरने के लिए उपयोग की जाएगी।
8.	बने हुए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9.	*लिंकेड सेक्शन से मूल स्लाइड पर वापस लौटने* की क्षमता सेट करें। 
10.	सेक्शन ज़ूम फ्रेम ऑब्जेक्ट की इमेज से पृष्ठभूमि हटाएँ।
11.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट की लाइन फ़ॉर्मेट बदलें।
12.	ट्रांज़िशन अवधि बदलें।
13.	परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड दिखाता है कि सेक्शन ज़ूम फ्रेम के फ़ॉर्मेटिंग को कैसे बदला जाए:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//प्रस्तुति में नई स्लाइड जोड़ता है
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 1", slide);

// SectionZoomFrame ऑब्जेक्ट जोड़ता है
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// SectionZoomFrame के लिए फ़ॉर्मेटिंग
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// प्रस्तुति को सहेजता है
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **सारांश ज़ूम**

सारांश ज़ूम एक लैंडिंग पेज की तरह है जहाँ आपकी प्रस्तुति के सभी भाग एक साथ प्रदर्शित होते हैं। प्रस्तुत करते समय, आप ज़ूम का उपयोग करके अपनी प्रस्तुति के एक हिस्से से दूसरे हिस्से पर किसी भी क्रम में जा सकते हैं। आप रचनात्मक हो सकते हैं, आगे कूद सकते हैं, या स्लाइड शो के भागों को फिर से देख सकते हैं बिना प्रस्तुति के प्रवाह को बाधित किए।

![overview_image](sumzoomsel.png)

सारांश ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ISummaryZoomFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isummaryzoomsection/), और [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isummaryzoomsectioncollection/) इंटरफ़ेस तथा [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) इंटरफ़ेस के तहत कुछ मेथड्स प्रदान करता है।

### **सारांश ज़ूम बनाएँ**

आप एक स्लाइड पर सारांश ज़ूम फ्रेम इस प्रकार जोड़ सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2.	नए स्लाइड्स बनाएँ जिनमें पहचान पृष्ठभूमि और नई सेक्शन हों।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड दिखाता है कि स्लाइड पर सारांश ज़ूम फ्रेम कैसे बनाया जाए:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// प्रस्तुति में नई स्लाइड जोड़ता है
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 1", slide);

// प्रस्तुति में नई स्लाइड जोड़ता है
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 2", slide);

// प्रस्तुति में नई स्लाइड जोड़ता है
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 3", slide);

// प्रस्तुति में नई स्लाइड जोड़ता है
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 4", slide);

// SummaryZoomFrame ऑब्जेक्ट जोड़ता है
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// प्रस्तुति को सहेजता है
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **सारांश ज़ूम सेक्शन जोड़ें और हटाएँ**

सारांश ज़ूम फ्रेम में सभी सेक्शन को [ISummaryZoomSection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isummaryzoomsection/) ऑब्जेक्ट्स द्वारा दर्शाया जाता है, जो [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isummaryzoomsectioncollection/) ऑब्जेक्ट में संग्रहीत होते हैं। आप [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isummaryzoomsectioncollection/) इंटरफ़ेस के माध्यम से सारांश ज़ूम सेक्शन ऑब्जेक्ट को इस प्रकार जोड़ या हटा सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2.	नए स्लाइड्स बनाएँ जिनमें पहचान पृष्ठभूमि और नई सेक्शन हों।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	प्रस्तुति में एक नया स्लाइड और सेक्शन जोड़ें।
5.	बनाए गए सेक्शन को सारांश ज़ूम फ्रेम में जोड़ें।
6.	सारांश ज़ूम फ्रेम से पहली सेक्शन हटाएँ।
7.	परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड दिखाता है कि सारांश ज़ूम फ्रेम में सेक्शन कैसे जोड़े और हटाए जाएँ:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//प्रस्तुति में नई स्लाइड जोड़ता है
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 1", slide);

//प्रस्तुति में नई स्लाइड जोड़ता है
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 2", slide);

// SummaryZoomFrame ऑब्जेक्ट जोड़ता है
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//प्रस्तुति में नई स्लाइड जोड़ता है
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// प्रस्तुति में नया सेक्शन जोड़ता है
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Summary Zoom में एक सेक्शन जोड़ता है
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Summary Zoom से सेक्शन हटाता है
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// प्रस्तुति को सहेजता है
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **सारांश ज़ूम सेक्शन का फ़ॉर्मेटिंग**

अधिक जटिल सारांश ज़ूम सेक्शन ऑब्जेक्ट बनाने के लिए आपको साधारण फ्रेम के फ़ॉर्मेटिंग को बदलना होगा। सारांश ज़ूम सेक्शन ऑब्जेक्ट पर कई फ़ॉर्मेटिंग विकल्प लागू किए जा सकते हैं। 

आप सारांश ज़ूम फ्रेम में सारांश ज़ूम सेक्शन ऑब्जेक्ट के फ़ॉर्मेटिंग को इस प्रकार नियंत्रित कर सकते हैं:

1.	[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2.	नए स्लाइड्स बनाएँ जिनमें पहचान पृष्ठभूमि और नई सेक्शन हों।
3.	पहली स्लाइड में सारांश ज़ूम फ्रेम जोड़ें।
4.	`ISummaryZoomSectionCollection` से पहली वस्तु का सारांश ज़ूम सेक्शन ऑब्जेक्ट प्राप्त करें।
7.	[IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) ऑब्जेक्ट बनाएँ, इसके लिए इमेज को images कलेक्शन में जोड़ें जो [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट से सम्बंधित है और फ्रेम को भरने के लिए उपयोग की जाएगी।
8.	बने हुए सेक्शन ज़ूम फ्रेम ऑब्जेक्ट के लिए कस्टम इमेज सेट करें।
9.	*लिंकेड सेक्शन से मूल स्लाइड पर वापस लौटने* की क्षमता सेट करें। 
11.	दूसरे ज़ूम फ्रेम ऑब्जेक्ट की लाइन फ़ॉर्मेट बदलें।
12.	ट्रांज़िशन अवधि बदलें।
13.	परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड दिखाता है कि सारांश ज़ूम सेक्शन ऑब्जेक्ट के फ़ॉर्मेटिंग को कैसे बदला जाए:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//प्रस्तुति में नई स्लाइड जोड़ता है
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 1", slide);

//प्रस्तुति में नई स्लाइड जोड़ता है
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// प्रस्तुति में नया सेक्शन जोड़ता है
pres->get_Sections()->AddSection(u"Section 2", slide);

// SummaryZoomFrame ऑब्जेक्ट जोड़ता है
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// पहला SummaryZoomSection ऑब्जेक्ट प्राप्त करता है
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// SummaryZoomSection ऑब्जेक्ट के लिए फ़ॉर्मेटिंग
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// प्रस्तुति को सहेजता है
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं लक्ष्य दिखाने के बाद 'पैरेन्ट' स्लाइड पर लौटने को नियंत्रित कर सकता हूँ?**

हां। [Zoom frame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/zoomframe/) या [section](https://reference.aspose.com/slides/hi/cpp/aspose.slides/sectionzoomframe/) में `set_ReturnToParent` मेथड है जो दर्शकों को लक्ष्य सामग्री देखने के बाद मूल स्लाइड पर वापस भेजता है।

**क्या मैं ज़ूम ट्रांज़िशन की 'गति' या अवधि को समायोजित कर सकता हूँ?**

हां। ज़ूम ट्रांज़िशन की अवधि सेट की जा सकती है जिससे आप एनीमेशन के समय को नियंत्रित कर सकते हैं।

**क्या प्रस्तुति में ज़ूम ऑब्जेक्ट्स की संख्या पर कोई सीमा है?**

दस्तावेज़ में कोई कठोर API सीमा नहीं है। व्यावहारिक सीमाएँ प्रस्तुति की जटिलता और दर्शक के प्रदर्शन पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय को ध्यान में रखें।