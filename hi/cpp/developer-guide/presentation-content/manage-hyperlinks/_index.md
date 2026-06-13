---
title: C++ में प्रस्तुति हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/cpp/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक स्वरूपित करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- पाठ हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक को आसानी से प्रबंधित करें — मिनटों में इंटरैक्टिविटी और कार्यप्रवाह को बढ़ाएं।"
---
## **परिचय**

हाइपरलिंक कोई वस्तु, डेटा या किसी स्थान का संदर्भ होता है। ये PowerPoint प्रस्तुतियों में सामान्य हाइपरलिंक हैं:

* पाठ, आकार या मीडिया के अंदर वेबसाइटों के लिंक
* स्लाइडों के लिंक

Aspose.Slides for C++ प्रस्तुतियों में हाइपरलिंक से संबंधित कई कार्य करने की अनुमति देता है। 

{{% alert color="primary" %}} 
आप नि:शुल्क ऑनलाइन PowerPoint संपादक को देख सकते हैं।[नि:शुल्क ऑनलाइन PowerPoint संपादक।](https://products.aspose.app/slides/hi/editor)
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

### **पाठ में URL हाइपरलिंक जोड़ें**

यह C++ कोड दिखाता है कि कैसे किसी पाठ में वेबसाइट हाइपरलिंक जोड़ा जाए:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **आकार या फ्रेम में URL हाइपरलिंक जोड़ें**

यह C++ नमूना कोड दिखाता है कि कैसे किसी आकार में वेबसाइट हाइपरलिंक जोड़ा जाए:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **मीडिया में URL हाइपरलिंक जोड़ें**

Aspose.Slides आपको छवियों, ऑडियो और वीडियो फ़ाइलों में हाइपरलिंक जोड़ने की अनुमति देता है। 

यह नमूना कोड दिखाता है कि कैसे **छवि** में हाइपरलिंक जोड़ा जाए:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// प्रस्तुति में छवि जोड़ता है
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

यह नमूना कोड दिखाता है कि कैसे **ऑडियो फ़ाइल** में हाइपरलिंक जोड़ा जाए:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

यह नमूना कोड दिखाता है कि कैसे **वीडियो** में हाइपरलिंक जोड़ा जाए:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}} 
आप देखना चाह सकते हैं *[Manage OLE](https://docs.aspose.com/slides/hi/cpp/manage-ole/)*।
{{% /alert %}}

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

चूंकि हाइपरलिंक आपको वस्तुओं या स्थानों के संदर्भ जोड़ने की अनुमति देता है, आप उनका उपयोग करके सामग्री तालिका बना सकते हैं। 

यह नमूना कोड दिखाता है कि कैसे हाइपरलिंक के साथ सामग्री तालिका बनाई जाए:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```

## **हाइपरलिंक फ़ॉर्मेट करें**

### **रंग**

[IHyperlink](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink) इंटरफ़ेस में [set_ColorSource()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) और [get_ColorSource()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) मेथड का उपयोग करके आप हाइपरलिंक का रंग सेट कर सकते हैं और उसकी रंग जानकारी प्राप्त कर सकते हैं। यह सुविधा PowerPoint 2019 में पहली बार पेश की गई थी, इसलिए इस प्रॉपर्टी से संबंधित परिवर्तन पुराने PowerPoint संस्करणों पर लागू नहीं होते। 

यह नमूना कोड दर्शाता है कि कैसे विभिन्न रंगों के हाइपरलिंक को एक ही स्लाइड में जोड़ा गया:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

## **प्रस्तुतियों से हाइपरलिंक हटाएँ**

### **पाठ से हाइपरलिंक हटाएँ**

यह C++ कोड दिखाता है कि कैसे प्रस्तुति स्लाइड के पाठ से हाइपरलिंक हटाया जाए:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **आकार या फ्रेम से हाइपरलिंक हटाएँ**

यह C++ कोड दिखाता है कि कैसे प्रस्तुति स्लाइड के आकार से हाइपरलिंक हटाया जाए: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

## **परिवर्तनीय हाइपरलिंक**

[Hyperlink](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.hyperlink) क्लास परिवर्तनशील है। इस क्लास के साथ आप इन मेथड्स के मान बदल सकते हैं:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

यह कोड स्निपेट दिखाता है कि कैसे स्लाइड में हाइपरलिंक जोड़ा जाए और बाद में उसका टूलटिप संपादित किया जाए:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **IHyperlinkQueries में समर्थित मेथड्स**

आप प्रस्तुति, स्लाइड या उस पाठ से IHyperlinkQueries तक पहुंच सकते हैं जिसके लिए हाइपरलिंक परिभाषित है। 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

IHyperlinkQueries क्लास इन मेथड्स का समर्थन करता है: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं केवल स्लाइड नहीं, बल्कि "सेक्शन" या सेक्शन की पहली स्लाइड पर अंतर्निहित नेविगेशन कैसे बना सकता हूँ?**

PowerPoint में सेक्शन स्लाइडों का समूह होते हैं; नेविगेशन तकनीकी रूप से किसी विशिष्ट स्लाइड को लक्षित करता है। "सेक्शन पर नेविगेट" करने के लिए आप आमतौर पर उसकी पहली स्लाइड से लिंक बनाते हैं।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक लगा सकता हूँ ताकि यह सभी स्लाइडों पर कार्य करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक को सपोर्ट करते हैं। ऐसे लिंक चाइल्ड स्लाइडों पर प्रदर्शित होते हैं और स्लाइडशो के दौरान क्लिक योग्य होते हैं।

**PDF, HTML, इमेज या वीडियो में एक्सपोर्ट करने पर हाइपरलिंक बरकरार रहेंगे क्या?**

[PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/cpp/convert-powerpoint-to-html/) में हाइपरलिंक सामान्यतः संरक्षित रहते हैं। जब आप [images](/slides/hi/cpp/convert-powerpoint-to-png/) या [video](/slides/hi/cpp/convert-powerpoint-to-video/) में एक्सपोर्ट करते हैं, तो क्लिक करने योग्यता नहीं रहती क्योंकि रास्टर फ्रेम/वीडियो हाइपरलिंक को सपोर्ट नहीं करते।