---
title: C++ में PowerPoint टेक्स्ट पैराग्राफ़ प्रबंधित करें
linktitle: पैराग्राफ प्रबंधित करें
type: docs
weight: 40
url: /hi/cpp/manage-paragraph/
keywords:
- टेक्स्ट जोड़ें
- पैराग्राफ जोड़ें
- टेक्स्ट प्रबंधित करें
- पैराग्राफ प्रबंधित करें
- बुलेट प्रबंधित करें
- पैराग्राफ इंडेंट
- हैंगिंग इंडेंट
- पैराग्राफ बुलेट
- क्रमांकित सूची
- बुलेटेड सूची
- पैराग्राफ प्रॉपर्टीज़
- HTML आयात करें
- टेक्स्ट को HTML में
- पैराग्राफ को HTML में
- पैराग्राफ को चित्र में
- टेक्स्ट को चित्र में
- पैराग्राफ निर्यात करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ पैराग्राफ फॉर्मेटिंग में माहिर बनें—PPT, PPTX, और ODP प्रस्तुतियों में संरेखण, स्पेसिंग और शैली को C++ में अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides C++ में PowerPoint के पाठ, पैराग्राफ और हिस्सों (portions) के साथ काम करने के लिए आवश्यक सभी इंटरफ़ेस और क्लासेज़ प्रदान करता है।

* Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) इंटरफ़ेस प्रदान करता है जिससे आप पैराग्राफ का प्रतिनिधित्व करने वाले ऑब्जेक्ट को जोड़ सकते हैं। एक `ITextFame` ऑब्जेक्ट में एक या कई पैराग्राफ हो सकते हैं (प्रत्येक पैराग्राफ कैरिज रिटर्न द्वारा बनाया जाता है)।
* Aspose.Slides [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) इंटरफ़ेस प्रदान करता है जिससे आप हिस्सों (portions) का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं। एक `IParagraph` ऑब्जेक्ट में एक या कई हिस्से हो सकते हैं (iPortions ऑब्जेक्ट्स का संग्रह)।
* Aspose.Slides [IPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/) इंटरफ़ेस प्रदान करता है जिससे आप टेक्स्ट और उनकी फॉर्मेटिंग प्रॉपर्टीज़ का प्रतिनिधित्व करने वाले ऑब्जेक्ट जोड़ सकते हैं।

एक `IParagraph` ऑब्जेक्ट अपने अंतर्निहित `IPortion` ऑब्जेक्ट्स के माध्यम से विभिन्न फॉर्मेटिंग प्रॉपर्टीज़ वाले टेक्स्ट को संभालने में सक्षम होता है।

## **एकाधिक हिस्सों वाले कई पैराग्राफ जोड़ना**

ये चरण आपको दर्शाते हैं कि 3 पैराग्राफ़ वाला एक टेक्स्ट फ़्रेम कैसे जोड़ें और प्रत्येक पैराग्राफ में 3 हिस्से हों:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. स्लाइड में एक आयताकार [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) से जुड़े ITextFrame को प्राप्त करें।
5. दो [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) ऑब्जेक्ट बनाएँ और उन्हें [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) के `IParagraphs` संग्रह में जोड़ें।
6. प्रत्येक नए `IParagraph` के लिए तीन [IPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/) ऑब्जेक्ट बनाएं (डिफ़ॉल्ट पैराग्राफ़ के लिए दो Portion ऑब्जेक्ट) और प्रत्येक `IPortion` ऑब्जेक्ट को संबंधित `IParagraph` की IPortion संग्रह में जोड़ें।
7. प्रत्येक हिस्से के लिए कुछ टेक्स्ट सेट करें।
8. `IPortion` ऑब्जेक्ट द्वारा प्रदान की गई फॉर्मेटिंग प्रॉपर्टीज़ का उपयोग करके प्रत्येक हिस्से पर अपनी पसंदीदा फॉर्मेटिंग लागू करें।
9. संशोधित प्रेजेंटेशन को सहेजें।

यह C++ कोड हिस्सों वाले पैराग्राफ़ जोड़ने के चरणों का कार्यान्वयन है: 

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// इच्छित प्रस्तुति को लोड करें
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचें
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// आयत प्रकार का AutoShape जोड़ें
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// आयत में TextFrame जोड़ें
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// पहले पैराग्राफ तक पहुँचें
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// दूसरा पैराग्राफ जोड़ें
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// तीसरा पैराग्राफ जोड़ें
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// PPTX को डिस्क पर सहेजें
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **पैराग्राफ बुलेट्स प्रबंधित करना**

बुलेट सूचियां आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बुलेटेड पैराग्राफ़ पढ़ने और समझने में हमेशा आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. चयनित स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. ऑटोशेप की [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें। 
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ बनाएं।
7. पैराग्राफ के बुलेट `Type` को `Symbol` सेट करें और बुलेट कैरेक्टर सेट करें।
8. पैराग्राफ का `Text` सेट करें।
9. बुलेट के लिए पैराग्राफ का `Indent` सेट करें।
10. बुलेट के लिए एक रंग सेट करें।
11. बुलेट की ऊँचाई सेट करें।
12. नई पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
13. दूसरी पैराग्राफ जोड़ें और चरण 7 से 13 तक दिए गए प्रक्रिया को दोहराएँ।
14. प्रेजेंटेशन सहेजें।

यह C++ कोड आपको पैराग्राफ बुलेट जोड़ना दिखाता है: 

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// वांछित प्रस्तुति लोड करें
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचें
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// आयत प्रकार का AutoShape जोड़ें
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// आयत में TextFrame जोड़ें
ashp->AddTextFrame(u"");

// टेक्स्ट फ्रेम तक पहुँ
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// टेक्स्ट फ्रेम के लिए Paragraph वस्तु बनाना
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Setting Text
paragraph->set_Text(u"Welcome to Aspose.Slides");

// बुलेट इंडेंट सेट करना
paragraph->get_ParagraphFormat()->set_Indent (25);

// बुलेट रंग सेट करना
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// अपने बुलेट रंग का उपयोग करने के लिए IsBulletHardColor को true सेट करें
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// बुलेट ऊँचाई सेट करना
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// पैराग्राफ को टेक्स्ट फ्रेम में जोड़ना
txtFrame->get_Paragraphs()->Add(paragraph);

// दूसरा पैराग्राफ बनाना
// टेक्स्ट फ्रेम के लिए Paragraph वस्तु बनाना
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//टेक्स्ट सेट करना
paragraph2->set_Text(u"This is numbered bullet");

// पैराग्राफ बुलेट प्रकार और शैली सेट करना
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// बुलेट इंडेंट सेट करना
paragraph2->get_ParagraphFormat()->set_Indent(25);

// बुलेट रंग सेट करना
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// अपने बुलेट रंग का उपयोग करने के लिए IsBulletHardColor को true सेट करें
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// बुलेट ऊँचाई सेट करना
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// पैराग्राफ को टेक्स्ट फ्रेम में जोड़ना
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTX को डिस्क पर सहेजें
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **चित्र बुलेट्स प्रबंधित करना**

बुलेट सूचियां आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। चित्र पैराग्राफ पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. ऑटोशेप की [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें। 
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ बनाएं।
7. [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) में छवि लोड करें।
8. बुलेट प्रकार को [Picture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) सेट करें और छवि सेट करें।
9. पैराग्राफ का `Text` सेट करें।
10. बुलेट के लिए पैराग्राफ का `Indent` सेट करें।
11. बुलेट के लिए रंग सेट करें।
12. बुलेट की ऊँचाई सेट करें।
13. नई पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
14. दूसरी पैराग्राफ जोड़ें और पहले के चरणों के आधार पर प्रक्रिया दोहराएँ।
15. संशोधित प्रेजेंटेशन सहेजें।

यह C++ कोड आपको चित्र बुलेट जोड़ने और प्रबंधित करने का तरीका दिखाता है: 

```c++
// एक Presentation क्लास का उदाहरण बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// बुलेट्स के लिए इमेज का उदाहरण बनाता है
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Autoshape जोड़ता है और पहुँचता है
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// autoshape के टेक्स्टफ़्रेम तक पहुँचता है
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// डिफ़ॉल्ट पैराग्राफ हटाता है
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// एक नया पैराग्राफ बनाता है
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// पैराग्राफ बुलेट शैली और चित्र सेट करता है
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// बुलेट की ऊँचाई सेट करता है
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// पैराग्राफ को टेक्स्ट फ़्रेम में जोड़ता है
paragraphs->Add(paragraph);

// प्रस्तुति को PPTX फ़ाइल के रूप में सहेजता है
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// प्रस्तुति को PPT फ़ाइल के रूप में सहेजता है
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **बहुस्तरीय बुलेट्स प्रबंधित करना**

बुलेट सूचियां आपको जानकारी को जल्दी और प्रभावी ढंग से व्यवस्थित और प्रस्तुत करने में मदद करती हैं। बहुस्तरीय बुलेट्स पढ़ने और समझने में आसान होते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. नई स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. ऑटोशेप की [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें। 
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) क्लास के माध्यम से पहली पैराग्राफ उदाहरण बनाएं और उसकी गहराई (depth) को 0 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरी पैराग्राफ बनाएं और गहराई को 1 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरी पैराग्राफ बनाएं और गहराई को 2 सेट करें।
9. `Paragraph` क्लास के माध्यम से चौथी पैराग्राफ बनाएं और गहराई को 3 सेट करें।
10. नई पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
11. संशोधित प्रेजेंटेशन सहेजें।

यह C++ कोड आपको बहुस्तरीय बुलेट्स जोड़ने और प्रबंधित करने का तरीका दिखाता है: 

```c++
// एक Presentation क्लास का उदाहरण बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Autoshape जोड़ता है और तक पहुँचता है
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// बनाए गए autoshape के टेक्स्ट फ़्रेम तक पहुँचता है
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// डिफ़ॉल्ट पैराग्राफ को साफ़ करता है
text->get_Paragraphs()->Clear();

// पहला पैराग्राफ जोड़ता है
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// बुलेट स्तर सेट करता है
para1Format->set_Depth(0);

// दूसरा पैराग्राफ जोड़ता है
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// बुलेट स्तर सेट करता है
para2Format->set_Depth(1);

// तीसरा पैराग्राफ जोड़ता है
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// बुलेट स्तर सेट करता है
para3Format->set_Depth(2);

// चौथा पैराग्राफ जोड़ता है
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// बुलेट स्तर सेट करता है
para4Format->set_Depth(3);

// पैराग्राफ को संग्रह में जोड़ता है
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// प्रस्तुति को PPTX फ़ाइल के रूप में लिखता है
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **कस्टम क्रमांकित सूची के साथ पैराग्राफ प्रबंधित करना**

[IBulletFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/) इंटरफ़ेस [NumberedBulletStartWith](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) प्रॉपर्टी और अन्य सुविधाएँ प्रदान करता है जो आपको कस्टम क्रमांकन या फॉर्मेटिंग के साथ पैराग्राफ प्रबंधित करने की अनुमति देती हैं। 

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. पैराग्राफ वाली स्लाइड तक पहुंचें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. ऑटोशेप की [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें। 
5. `TextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) क्लास के माध्यम से पहली पैराग्राफ बनाएं और [NumberedBulletStartWith] को 2 सेट करें।
7. `Paragraph` क्लास के माध्यम से दूसरी पैराग्राफ बनाएं और `NumberedBulletStartWith` को 3 सेट करें।
8. `Paragraph` क्लास के माध्यम से तीसरी पैराग्राफ बनाएं और `NumberedBulletStartWith` को 7 सेट करें।
9. नई पैराग्राफ को `TextFrame` के पैराग्राफ संग्रह में जोड़ें।
10. संशोधित प्रेजेंटेशन सहेजें।

यह C++ कोड आपको कस्टम क्रमांकन या फॉर्मेटिंग के साथ पैराग्राफ जोड़ने और प्रबंधित करने का तरीका दिखाता है: 

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// बनाए गए autoshape के टेक्स्ट फ़्रेम तक पहुंचता है
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// डिफ़ॉल्ट मौजूदा पैराग्राफ को हटाता है
textFrame->get_Paragraphs()->RemoveAt(0);

// पहली सूची
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **पैराग्राफ के प्रथम-पंक्ति इंडेंट सेट करें**

[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मेथड का उपयोग करके पैराग्राफ की पहली पंक्ति का इंडेंट नियंत्रित करें। यह मेथड केवल प्रथम पंक्ति को पैराग्राफ की बायें मार्जिन के सापेक्ष स्थानांतरित करता है। सकारात्मक मान पहली पंक्ति को दाएँ शिफ्ट करता है, जबकि बाकी पंक्तियाँ पैराग्राफ बॉडी के साथ संरेखित रहती हैं।

जब आपको पूरी पैराग्राफ को स्थानांतरित करना हो, तो [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginleft/) उपयोग करें। केवल पहली पंक्ति को स्थानांतरित करने के लिए [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) उपयोग करें।

निम्नलिखित उदाहरण कई पैराग्राफ बनाता है और विभिन्न `Indent` मान लागू करता है जिससे पता चलता है कि प्रथम-पंक्ति इंडेंट पैराग्राफ लेआउट को कैसे प्रभावित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/autoshape/) जोड़ें।
4. शेप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ को हटाएं।
5. कई पैराग्राफ बनाएं और उनके लिए विभिन्न [Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मान सेट करें।
6. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
7. संशोधित प्रेजेंटेशन सहेजें।

यह कोड आपको पैराग्राफ इंडेंट सेट करने का तरीका दिखाता है: 

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![The first-line indent of the paragraphs](first_line_indent.png)

## **पैराग्राफ के लिए हैंगिंग इंडेंट सेट करें**

हैंगिंग इंडेंट वह पैराग्राफ लेआउट है जिसमें पहली पंक्ति शेष पंक्तियों के बाएँ शुरू होती है। Aspose.Slides में आप इस प्रभाव को [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मेथड से बनाते हैं। इंडेंट को नकारात्मक मान पर सेट करके पहली पंक्ति को पैराग्राफ बॉडी की तुलना में बाएँ ले जाएँ।

व्यावहारिक रूप से, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginleft/) पैराग्राफ बॉडी की बायीं स्थिति निर्धारित करता है, और [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) पहली पंक्ति की उस मार्जिन के सापेक्ष स्थिति निर्धारित करता है। हैंगिंग इंडेंट बनाने के लिए, एक सकारात्मक `MarginLeft` मान और एक नकारात्मक `Indent` मान सेट करें।

यह फॉर्मेटिंग बिब्लियोग्राफी, रेफ़रेंस, शब्दकोश प्रविष्टियों, और अन्य पैराग्राफ़ों के लिए उपयोगी है जहाँ रैप्ड लाइन्स पैराग्राफ बॉडी के नीचे संरेखित होनी चाहिए, न कि पहली पंक्ति के पहले कैरेक्टर के नीचे।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. लक्ष्य स्लाइड तक पहुंचें।
3. स्लाइड में एक आयताकार [AutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/autoshape/) जोड़ें।
4. शेप में एक खाली [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframe/) जोड़ें और डिफ़ॉल्ट पैराग्राफ को हटाएं।
5. प्रत्येक पैराग्राफ के लिए सकारात्मक [MarginLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginleft/) मान सेट करें।
6. हैंगिंग इंडेंट प्रभाव बनाने के लिए नकारात्मक [Indent](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_indent/) मान सेट करें।
7. पैराग्राफ को टेक्स्ट फ्रेम में जोड़ें।
8. संशोधित प्रेजेंटेशन सहेजें।

यह कोड आपको पैराग्राफ के लिए हैंगिंग इंडेंट सेट करने का तरीका दिखाता है: 

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफों का हैंगिंग इंडेंट](hanging_indent.png)

## **पैराग्राफ रन अंत प्रॉपर्टीज़ प्रबंधित करना**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. पैराग्राफ वाली स्लाइड का संदर्भ उसकी स्थिति के माध्यम से प्राप्त करें।
3. स्लाइड में एक आयताकार [autoshape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. आयताकार में दो पैराग्राफ वाला एक [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) जोड़ें।
5. पैराग्राफ के लिए `FontHeight` और फ़ॉन्ट प्रकार सेट करें।
6. पैराग्राफ के End प्रॉपर्टीज़ सेट करें।
7. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड आपको PowerPoint में पैराग्राफ के End प्रॉपर्टीज़ सेट करने का तरीका दिखाता है: 

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// इच्छित प्रस्तुति लोड करें
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचें
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// आयत प्रकार का AutoShape जोड़ें
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// आयत में TextFrame जोड़ें
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// पहला पैराग्राफ जोड़ना
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// दूसरा पैराग्राफ जोड़ना
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// PPTX को डिस्क पर सहेजें
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **पैराग्राफ में HTML टेक्स्ट आयात करें**

Aspose.Slides पैराग्राफ में HTML टेक्स्ट आयात करने के लिए उन्नत समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. स्लाइड में एक [autoshape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
4. `autoshape` की [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें और जोड़ें।
5. `ITextFrame` में डिफ़ॉल्ट पैराग्राफ को हटाएं।
6. एक TextReader में स्रोत HTML फ़ाइल पढ़ें।
7. [Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraph/) क्लास का उपयोग करके पहला पैराग्राफ बनाएं।
8. पढ़े हुए TextReader की सामग्री को TextFrame की [ParagraphCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraphcollection/) में जोड़ें।
9. संशोधित प्रेजेंटेशन सहेजें।

यह C++ कोड पैराग्राफ में HTML टेक्स्ट आयात करने के चरणों का कार्यान्वयन है: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// इच्छित प्रस्तुति लोड करें
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचें
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// आयत प्रकार का AutoShape जोड़ें
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// डिफ़ॉल्ट भरण रंग रीसेट कर रहे हैं
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// आयत में TextFrame जोड़ें
ashp->AddTextFrame(u" ");

// टेक्स्ट फ्रेम तक पहुँच रहे हैं
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Paragraphs संग्रह प्राप्त करें
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// जोड़े गए टेक्स्ट फ्रेम में सभी पैराग्राफ साफ़ कर रहे हैं
ParaCollection->Clear();

// स्ट्रीम रीडर का उपयोग करके HTML फ़ाइल लोड कर रहे हैं
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// HTML स्ट्रीम रीडर से टेक्स्ट को टेक्स्ट फ्रेम में जोड़ रहे हैं
ParaCollection->AddFromHtml(tr->ReadToEnd());


// टेक्स्ट फ्रेम के लिए Paragraph वस्तु बनाएं
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// पैराग्राफ के लिए Portion वस्तु बनाएं
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Portion फ़ॉर्मेट प्राप्त करें
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Portion के लिए फ़ॉन्ट सेट करें
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// फ़ॉन्ट की बोल्ड प्रॉपर्टी सेट करें
pf->set_FontBold(NullableBool::True);

// फ़ॉन्ट की इटैलिक प्रॉपर्टी सेट करें
pf->set_FontItalic(NullableBool::True);

// फ़ॉन्ट की अंडरलाइन प्रॉपर्टी सेट करें
pf->set_FontUnderline(TextUnderlineType::Single);

// फ़ॉन्ट की ऊँचाई सेट करें
pf->set_FontHeight(25);

// फ़ॉन्ट का रंग सेट करें
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX को डिस्क पर सहेजें
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **पैराग्राफ टेक्स्ट को HTML में निर्यात करें**

Aspose.Slides पैराग्राफ (जिसमें टेक्स्ट शामिल है) को HTML में निर्यात करने के लिए उन्नत समर्थन प्रदान करता है।

1. इच्छित प्रेजेंटेशन को लोड करके [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. संबंधित स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. उस शेप तक पहुंचें जिसमें वह टेक्स्ट है जिसे HTML में निर्यात किया जाएगा।
4. शेप की [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) तक पहुंचें।
5. एक नया HTML फ़ाइल जोड़ने के लिए `StreamWriter` का एक उदाहरण बनाएं।
6. प्रारंभिक इंडेक्स को StreamWriter को प्रदान करें और अपनी पसंदीदा पैराग्राफ निर्यात करें।

यह C++ कोड आपको PowerPoint पैराग्राफ टेक्स्ट को HTML में निर्यात करने का तरीका दिखाता है: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// इच्छित प्रस्तुति लोड करें
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// प्रेजेंटेशन की डिफ़ॉल्ट पहली स्लाइड तक पहुंचें
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// इच्छित सूचकांक
int index = 0;

// जोड़े गए आकार तक पहुंच रहे हैं
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// पहला पैराग्राफ HTML के रूप में निकाल रहे हैं
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// HTML में पैराग्राफ डेटा लिखें, पैराग्राफ शुरू होने वाले इंडेक्स और कॉपी किए जाने वाले कुल पैराग्राफ प्रदान करके
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **पैराग्राफ को चित्र के रूप में सहेजें**

इस अनुभाग में, हम दो उदाहरणों का पता लगाएंगे जो दिखाते हैं कि [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) इंटरफ़ेस द्वारा प्रतिनिधित्व किए गए टेक्स्ट पैराग्राफ को चित्र के रूप में कैसे सहेजा जाए। दोनों उदाहरण एक शेप की छवि प्राप्त करने को शामिल करते हैं जिसमें पैराग्राफ है, यह [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) इंटरफ़ेस की `GetImage` मेथड्स का उपयोग करके किया जाता है, शेप के भीतर पैराग्राफ की सीमाएँ गणना की जाती हैं, और इसे बिटमैप इमेज के रूप में निर्यात किया जाता है। ये विधियाँ आपको PowerPoint प्रस्तुतियों से टेक्स्ट के विशिष्ट हिस्सों को निकालने और उन्हें अलग-अलग चित्रों के रूप में सहेजने की अनुमति देती हैं, जो विभिन्न परिदृश्यों में आगे उपयोग के लिए उपयोगी हो सकते हैं।

मान लीजिए हमारे पास sample.pptx नामक एक प्रेजेंटेशन फ़ाइल है जिसमें एक स्लाइड है, जहाँ पहली शेप एक टेक्स्ट बॉक्स है जिसमें तीन पैराग्राफ़ हैं।

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

इस उदाहरण में, हम दूसरा पैराग्राफ एक चित्र के रूप में प्राप्त करते हैं। ऐसा करने के लिए, हम प्रेजेंटेशन की पहली स्लाइड से शेप की छवि निकालते हैं और फिर शेप के टेक्स्ट फ़्रेम में दूसरे पैराग्राफ की सीमाएँ गणना करते हैं। फिर पैराग्राफ को नए बिटमैप चित्र पर पुनः रेखांकित किया जाता है, जिसे PNG फ़ॉर्मेट में सहेजा जाता है। यह विधि विशेष रूप से तब उपयोगी होती है जब आपको टेक्स्ट की सटीक आयाम और फ़ॉर्मेटिंग बनाए रखते हुए किसी विशेष पैराग्राफ को अलग चित्र के रूप में सहेजना हो।

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

परिणाम:

![पैराग्राफ छवि](paragraph_to_image_output.png)

**Example 2**

इस उदाहरण में, हम पिछले दृष्टिकोण को पैराग्राफ चित्र में स्केलिंग फैक्टर जोड़कर विस्तारित करते हैं। शेप को प्रेजेंटेशन से निकाला जाता है और `2` के स्केलिंग फैक्टर के साथ चित्र के रूप में सहेजा जाता है। इससे पैराग्राफ निर्यात करते समय उच्च रिज़ॉल्यूशन आउटपुट प्राप्त होता है। फिर स्केल को ध्यान में रखते हुए पैराग्राफ की सीमाएँ गणना की जाती हैं। स्केलिंग विशेष रूप से तब उपयोगी होती है जब अधिक विस्तृत चित्र की आवश्यकता हो, जैसे उच्च‑गुणवत्ता वाले मुद्रित सामग्री में उपयोग के लिए।

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**क्या मैं टेक्स्ट फ्रेम के भीतर लाइन रैपिंग को पूरी तरह से निष्क्रिय कर सकता हूँ?**  
हाँ। टेक्स्ट फ्रेम की रैपिंग विधि ([set_WrapText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframeformat/set_wraptext/)) का उपयोग करके रैपिंग बंद कर दें ताकि लाइनों को फ्रेम की किनारों पर नहीं तोड़ा जाए।

**मैं किसी विशिष्ट पैराग्राफ की स्लाइड पर सटीक सीमाएँ कैसे प्राप्त कर सकता हूँ?**  
आप पैराग्राफ (और यहां तक कि एकल Portion) के सीमित आयत को प्राप्त कर सकते हैं जिससे उसकी स्लाइड पर सटीक स्थिति और आकार पता चलता है।

**पैराग्राफ अभिविन्यास (बाएँ/दाएँ/केंद्रीय/जस्टिफ़ाई) कहाँ नियंत्रित होता है?**  
[Alignment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraphformat/set_alignment/) पैराग्राफ‑स्तर की सेटिंग है जो [ParagraphFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraphformat/) में स्थित है; यह पूरे पैराग्राफ पर लागू होता है चाहे व्यक्तिगत Portion की फॉर्मेटिंग कुछ भी हो।

**क्या मैं पैराग्राफ के केवल एक भाग (जैसे एक शब्द) के लिए स्पेल‑चेक भाषा सेट कर सकता हूँ?**  
हाँ। भाषा को Portion स्तर पर ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_languageid/)) सेट किया जाता है, जिससे एक ही पैराग्राफ में कई भाषाएँ सह-अस्तित्व में हो सकती हैं।