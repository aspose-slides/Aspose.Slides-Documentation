---
title: C++ में PowerPoint आकृतियों का फॉर्मेट
linktitle: आकृति फॉर्मेटिंग
type: docs
weight: 20
url: /hi/cpp/shape-formatting/
keywords:
- आकृति फॉर्मेट
- रेखा फॉर्मेट
- जॉइन स्टाइल फॉर्मेट
- ग्रेडिएंट फिल
- पैटर्न फिल
- पिक्चर फिल
- टेक्सचर फिल
- सॉलिड रंग फिल
- आकृति पारदर्शिता
- आकृति घुमाएँ
- 3D बीवल प्रभाव
- 3D घुमाव प्रभाव
- फ़ॉर्मेटिंग रीसेट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint आकृतियों को फॉर्मेट करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में आप स्लाइड्स पर आकृतियाँ जोड़ सकते हैं। चूँकि आकृतियाँ रेखाओं से बनी होती हैं, आप उनकी रूपरेखा को संशोधित करके या प्रभाव लागू करके उन्हें फ़ॉर्मेट कर सकते हैं। अतिरिक्त रूप से, आप आकृति के अंदरूनी भाग को भरने के सेटिंग्स निर्धारित करके भी फ़ॉर्मेट कर सकते हैं।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ उन इंटरफ़ेस और मेथड्स को प्रदान करता है जो PowerPoint में उपलब्ध वही विकल्पों के साथ आकृतियों को फ़ॉर्मेट करने की अनुमति देता है।

## **लाइन फ़ॉर्मेट करना**

Aspose.Slides का उपयोग करके आप किसी आकृति के लिए कस्टम लाइन स्टाइल निर्दिष्ट कर सकते हैं। नीचे दिए गए चरण इस प्रक्रिया को रेखांकित करते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [line style](https://reference.aspose.com/slides/hi/cpp/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई निर्धारित करें।
1. लाइन की [dash style](https://reference.aspose.com/slides/hi/cpp/aspose.slides/linedashstyle/) सेट करें।
1. आकृति के लिए लाइन का रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित कोड दिखाता है कि कैसे एक आयत `AutoShape` को फ़ॉर्मेट किया जाता है:

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार की एक ऑटो आकृति जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// आयत आकृति के लिए फिल रंग सेट करें।
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// आयत की रेखाओं पर फॉर्मेटिंग लागू करें।
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// आयत की रेखा के लिए रंग सेट करें।
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![प्रस्तुति में फ़ॉर्मेट की गई लाइनें](formatted-lines.png)

## **जॉइन स्टाइल फ़ॉर्मेट करना**

यहाँ तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे कि किसी आकृति के कोने पर), यह **Round** सेटिंग का उपयोग करता है। हालाँकि, यदि आप तेज़ कोण वाली आकृति बना रहे हैं, तो आप **Miter** विकल्प को पसंद कर सकते हैं।

![प्रस्तुति में जॉइन स्टाइल](join-style-powerpoint.png)

निम्नलिखित C++ कोड दिखाता है कि कैसे ऊपर की छवि में दर्शाए गए तीन आयतों को Miter, Bevel, और Round जॉइन टाइप सेटिंग्स के साथ बनाया गया:

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार की तीन ऑटो आकृतियों को जोड़ें।
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// प्रत्येक आयत आकृति के लिये फिल रंग सेट करें।
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// रेखा की चौड़ाई सेट करें।
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// प्रत्येक आयत की रेखा के लिये रंग सेट करें।
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// जॉइन स्टाइल सेट करें।
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// प्रत्येक आयत में पाठ जोड़ें।
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ग्रेडिएंट फिल**

PowerPoint में, ग्रेडिएंट फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको एक आकृति पर रंगों का निरंतर मिश्रण लागू करने देता है। उदाहरण के लिए, आप दो या अधिक रंग इस प्रकार लगा सकते हैं कि एक रंग धीरे‑धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके आकृति पर ग्रेडिएंट फिल लागू करने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Gradient` पर सेट करें।
1. दो पसंदीदा रंगों को उनके परिभाषित पोजीशन के साथ जोड़ें, इसके लिये [IGradientFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igradientformat/) इंटरफ़ेस द्वारा प्रदान किए गए `Add` मेथड का उपयोग करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित C++ कोड दिखाता है कि कैसे एक दीर्घवृत्त पर ग्रेडिएंट फिल प्रभाव लागू किया जाता है:

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Ellipse प्रकार की एक ऑटो आकृति जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// दीर्घवृत्त पर ग्रेडिएंट फॉर्मेटिंग लागू करें।
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// ग्रेडिएंट की दिशा सेट करें।
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// दो ग्रेडिएंट स्टॉप जोड़ें।
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![ग्रेडिएंट फिल वाला दीर्घवृत्त](gradient-fill.png)

## **पैटर्न फिल**

PowerPoint में, पैटर्न फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंगीय डिज़ाइन—जैसे डॉट्स, स्ट्राइप्स, क्रॉसहैचेस, या चेक्स—को आकृति पर लागू करने देता है। आप पैटर्न के फ़ोरग्राउंड और बैकग्राउंड के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्व‑परिभाषित पैटर्न स्टाइल प्रदान करता है जिन्हें आप अपनी प्रस्तुतियों की दृश्य आकर्षण बढ़ाने के लिये आकृतियों पर लागू कर सकते हैं। यहाँ तक कि एक पूर्व‑परिभाषित पैटर्न चुनने के बाद भी आप उसके उपयोग किए जाने वाले सटीक रंग निर्धारित कर सकते हैं।

Aspose.Slides का उपयोग करके पैटर्न फिल लागू करने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Pattern` पर सेट करें।
1. पूर्व‑परिभाषित विकल्पों में से एक पैटर्न स्टाइल चुनें।
1. पैटर्न की [Background Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipatternformat/get_backcolor/) सेट करें।
1. पैटर्न की [Foreground Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipatternformat/get_forecolor/) सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित C++ कोड दिखाता है कि कैसे एक आयत पर पैटर्न फिल लागू किया जाता है:

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार की एक ऑटो आकृति जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// फिल टाइप को Pattern पर सेट करें।
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// पैटर्न शैली सेट करें।
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// पैटर्न का बैकग्राउंड और फ़ोरग्राउंड रंग सेट करें।
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैटर्न फिल वाला आयत](pattern-fill.png)

## **पिक्चर फिल**

PowerPoint में, पिक्चर फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकृति के भीतर एक छवि सम्मिलित करने देता है—व्यावहारिक रूप से छवि को आकृति की बैकग्राउंड के रूप में उपयोग करना।

Aspose.Slides का उपयोग करके पिक्चर फिल लागू करने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Picture` पर सेट करें।
1. पिक्चर फिल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) पर सेट करें।
1. उस छवि से एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) ऑब्जेक्ट बनाएँ जिसे आप उपयोग करना चाहते हैं।
1. छवि को `ISlidesPicture.set_Image` मेथड में पास करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

मान लें कि हमारे पास "lotus.png" फ़ाइल है जिसमें निम्नलिखित चित्र सम्मिलित है:

![lotus का चित्र](lotus.png)

निम्नलिखित C++ कोड दिखाता है कि कैसे एक आकृति को पिक्चर से भरा जाता है:

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार की एक ऑटो आकृति जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// फिल टाइप को Picture पर सेट करें।
shape->get_FillFormat()->set_FillType(FillType::Picture);

// पिक्चर फिल मोड सेट करें।
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// एक छवि लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें।
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// पिक्चर सेट करें।
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पिक्चर फिल वाला आकृति](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में उपयोग करना**

यदि आप टाइल्ड पिक्चर को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप निम्नलिखित मेथड्स का उपयोग कर सकते हैं: [IPictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/picturefillformat/) क्लास के:

- [set_PictureFillMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): पिक्चर फ़िल मोड सेट करता है—या तो `Tile` या `Stretch`।
- [set_TileAlignment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): आकृति के भीतर टाइल्स के संरेखण को निर्दिष्ट करता है।
- [set_TileFlip](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tileflip/): नियंत्रित करता है कि टाइल क्षैतिज, ऊर्ध्वाधर या दोनों दिशा में फ़्लिप हो।
- [set_TileOffsetX](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): टाइल का क्षैतिज ऑफसेट (पॉइंट्स में) आकृति की मूल बिंदु से सेट करता है।
- [set_TileOffsetY](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): टाइल का ऊर्ध्वाधर ऑफसेट (पॉइंट्स में) आकृति की मूल बिंदु से सेट करता है।
- [set_TileScaleX](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): टाइल के क्षैतिज स्केल को प्रतिशत के रूप में परिभाषित करता है।
- [set_TileScaleY](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): टाइल के ऊर्ध्वाधर स्केल को प्रतिशत के रूप में परिभाषित करता है।

निम्नलिखित कोड नमूना दिखाता है कि कैसे टाइल्ड पिक्चर फिल के साथ एक आयत जोड़ें और टाइल विकल्प कॉन्फ़िगर करें:

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto firstSlide = presentation->get_Slide(0);

// एक आयत ऑटो आकृति जोड़ें।
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// आकृति का फ़िल टाइप Picture पर सेट करें.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// छवि लोड करें और उसे प्रस्तुति संसाधनों में जोड़ें.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// छवि को आकृति को असाइन करें.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// पिक्चर फिल मोड और टाइलिंग विशेषताओं को कॉन्फ़िगर करें.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// PPTX फ़ाइल को डिस्क पर सहेजें.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![टाइल विकल्प](tile-options.png)

## **सॉलिड कलर फिल**

PowerPoint में, सॉलिड कलर फिल एक फ़ॉर्मेटिंग विकल्प है जो एक आकृति को एकल, समान रंग से भरता है। यह साधारण बैकग्राउंड रंग किसी ग्रेडिएंट, टेक्सचर या पैटर्न के बिना लागू किया जाता है।

Aspose.Slides का उपयोग करके सॉलिड कलर फिल लागू करने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Solid` पर सेट करें।
1. आकृति को अपनी इच्छित फ़िल रंग असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्नलिखित C++ कोड दिखाता है कि कैसे एक PowerPoint स्लाइड में आयत पर सॉलिड कलर फिल लागू किया जाता है:

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें.
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार की एक ऑटो आकृति जोड़ें.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// फ़िल टाइप को Solid पर सेट करें.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// फ़िल रंग सेट करें.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTX फ़ाइल को डिस्क पर सहेजें.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![सॉलिड कलर फिल वाला आकृति](solid-color-fill.png)

## **पारदर्शिता सेट करना**

PowerPoint में, जब आप किसी आकृति पर सॉलिड कलर, ग्रेडिएंट, पिक्चर या टेक्सचर फ़िल लागू करते हैं, तो आप फ़िल की अपारदर्शिता को नियंत्रित करने के लिये पारदर्शिता स्तर भी सेट कर सकते हैं। उच्च पारदर्शिता मान आकृति को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे स्थित वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको फ़िल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने देता है। इसे करने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Solid` पर सेट करें।
1. `Color` का उपयोग करके पारदर्शी रंग परिभाषित करें (अल्फ़ा घटक पारदर्शिता को नियंत्रित करता है)।
1. प्रस्तुति को सहेजें।

निम्नलिखित C++ कोड दिखाता है कि कैसे एक आयत पर पारदर्शी फ़िल रंग लागू किया जाता है:

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// एक ठोस आयत ऑटो आकृति जोड़ें।
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// ठोस आकृति के ऊपर एक पारदर्शी आयत ऑटो आकृति जोड़ें।
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX फ़ाइल को डिस्क पर सहेजें.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पारदर्शी आकृति](shape-transparency.png)

## **आकृतियों को घुमाना**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकृतियों को घुमाने की सुविधा देता है। यह तब उपयोगी हो सकता है जब आपको विशिष्ट संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थित करना हो।

स्लाइड पर एक आकृति को घुमाने के लिए, निम्नलिखित चरण अपनाएँ:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकृति की घूर्णन प्रॉपर्टी को इच्छित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित C++ कोड दिखाता है कि कैसे एक आकृति को 5 डिग्री घुमाया जाता है:

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार की एक ऑटो आकृति जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// आकृति को 5 डिग्री घुमाएँ।
shape->set_Rotation(5);

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![आकृति घुमाव](shape-rotation.png)

## **3D बीवल प्रभाव जोड़ना**

Aspose.Slides आपको आकृतियों पर [ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/threedformat/) प्रॉपर्टी को कॉन्फ़िगर करके 3D बीवल प्रभाव लागू करने की अनुमति देता है।

एक आकृति पर 3D बीवल प्रभाव जोड़ने के लिए, निम्नलिखित चरण अपनाएँ:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकृति के [ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/threedformat/) को कॉन्फ़िगर करके बीवल सेटिंग्स निर्धारित करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित C++ कोड दिखाता है कि कैसे एक आकृति पर 3D बीवल प्रभाव लागू किया जाता है:

```cpp
// Presentation क्लास का एक इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// स्लाइड में एक आकृति जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// आकृति की ThreeDFormat प्रॉपर्टीज़ सेट करें।
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![3D बीवल प्रभाव](3D-bevel-effect.png)

## **3D घुमाव प्रभाव जोड़ना**

Aspose.Slides आपको आकृतियों पर [ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/threedformat/) प्रॉपर्टी को कॉन्फ़िगर करके 3D घुमाव प्रभाव लागू करने की अनुमति देता है।

एक आकृति पर 3D घुमाव लागू करने के लिये:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा एक स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. 3D घुमाव को परिभाषित करने के लिये [set_CameraType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icamera/set_cameratype/) और [set_LightType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilightrig/set_lighttype/) का उपयोग करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित C++ कोड दिखाता है कि कैसे एक आकृति पर 3D घुमाव प्रभाव लागू किया जाता है:

```cpp
// Presentation क्लास का एक इंस्टैंस बनाएं.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![3D घुमाव प्रभाव](3D-rotation-effect.png)

## **फ़ॉर्मेटिंग रीसेट करना**

निम्नलिखित C++ कोड दिखाता है कि कैसे स्लाइड की फ़ॉर्मेटिंग रीसेट की जाए और [LayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/layoutslide/) पर प्लेसहोल्डर वाली सभी आकृतियों की स्थिति, आकार और फ़ॉर्मेटिंग को उनकी डिफ़ॉल्ट सेटिंग्स पर लौटाया जाए:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // लेआउट में प्लेसहोल्डर वाली स्लाइड की प्रत्येक आकृति को रीसेट करें।
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**क्या आकृति फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करती है?**

बहुत कम। एम्बेडेड छवियाँ और मीडिया फ़ाइलें अधिकांश स्थान लेती हैं, जबकि रंग, प्रभाव और ग्रेडिएंट जैसी आकृति पैरामीटर मेटा‑डेटा के रूप में संग्रहीत होते हैं और व्यावहारिक रूप से कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं स्लाइड पर उन आकृतियों का पता कैसे लगा सकता हूँ जिनकी फ़ॉर्मेटिंग समान है ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकृति की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फ़िल, लाइन और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके स्टाइल को समान मानें और उन आकृतियों को तर्कसंगत रूप से समूहित करें, जिससे बाद में स्टाइल प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकृति स्टाइल्स का एक सेट अलग फ़ाइल में सहेज कर विभिन्न प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हाँ। वांछित स्टाइल्स वाली नमूना आकृतियों को एक टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में संग्रहित करें। नई प्रस्तुति बनाते समय टेम्प्लेट खोलें, आवश्यक शैलीयुक्त आकृतियों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो वहाँ फ़ॉर्मेटिंग को पुनः लागू करें।