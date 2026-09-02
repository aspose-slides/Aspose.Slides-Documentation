---
title: C++ में PowerPoint आकृतियों को स्वरूपित करें
linktitle: आकार स्वरूपण
type: docs
weight: 20
url: /hi/cpp/shape-formatting/
keywords:
- आकार स्वरूपित करें
- रेखा स्वरूपित करें
- स्केच प्रभाव
- आकार रेखा स्केच
- जॉइन शैली स्वरूपित करें
- ग्रेडिएंट भराव
- पैटर्न भराव
- चित्र भराव
- टेक्सचर भराव
- सॉलिड रंग भराव
- आकार पारदर्शिता
- आकार घुमाएँ
- 3D बिवेल प्रभाव
- 3D घूर्णन प्रभाव
- फ़ॉर्मेटिंग रीसेट करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint आकारों को स्वरूपित करना सीखें—PPT, PPTX और ODP फाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में, आप स्लाइड्स में आकार जोड़ सकते हैं। क्योंकि आकार रेखाओं से बनते हैं, आप उनके रूपरेखा को संशोधित या प्रभाव लागू करके स्वरूपित कर सकते हैं। अतिरिक्त रूप से, आप आकारों को उनके भीतर भराव को नियंत्रित करने वाली सेटिंग्स निर्दिष्ट करके स्वरूपित कर सकते हैं।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ उन इंटरफ़ेस और मेथड्स को प्रदान करता है जो आपको PowerPoint में उपलब्ध वही विकल्पों का उपयोग करके आकारों को स्वरूपित करने की अनुमति देते हैं।

## **रेखा स्वरूपित करें**

Aspose.Slides का उपयोग करके आप एक आकार के लिए कस्टम लाइन स्टाइल निर्दिष्ट कर सकते हैं। निम्नलिखित चरण प्रक्रिया को दर्शाते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [line style](https://reference.aspose.com/slides/hi/cpp/aspose.slides/linestyle/) सेट करें।
1. रेखा की चौड़ाई सेट करें।
1. रेखा का [dash style](https://reference.aspose.com/slides/hi/cpp/aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए रेखा का रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार का एक ऑटो शेप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// आयताकार आकार के लिए भराव रंग सेट करें।
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// आयताकार की रेखाओं पर स्वरूपण लागू करें।
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// आयताकार की रेखा का रंग सेट करें।
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![प्रस्तुति में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकार रेखाओं पर स्केच प्रभाव लागू करें**

एक स्केच प्रभाव आकार की रेखा को हाथ से खींचे गए जैसा दिखाता है। [IShape::get_LineFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_lineformat/) का उपयोग करके रेखा सेटिंग्स तक पहुंचें, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilineformat/get_sketchformat/) का उपयोग करके स्केच सेटिंग्स तक पहुंचें, और [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isketchformat/set_sketchtype/) का उपयोग करके [LineSketchType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/linesketchtype/) एनोमरेशन से एक मान चुनें।

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isketchformat/get_sketchtype/) द्वारा लौटाया गया मान सीधे आकार को सौंपे गए सेटिंग का प्रतिनिधित्व करता है। यदि लाइन फ़ॉर्मेटिंग थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में ली जा सकती है, तो [ILineFormat::GetEffective](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilineformat/geteffective/) का उपयोग करके, [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) तक पहुंचें, और [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) पढ़ें। प्रभावी मान विरासत के हल होने के बाद वास्तव में लागू हुई फ़ॉर्मेटिंग को दर्शाता है:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **जॉइन शैलियों को स्वरूपित करें**

तीन जॉइन प्रकार विकल्प हैं:

* Round
* Miter
* Bevel

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे किसी आकार के कोने पर), वह **Round** सेटिंग का उपयोग करता है। हालांकि, यदि आप तेज कोणों वाले आकार बना रहे हैं, तो आप **Miter** विकल्प को प्राथमिकता दे सकते हैं।

![प्रस्तुति में जॉइन शैली](join-style-powerpoint.png)

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार के तीन ऑटो शेप जोड़ें।
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// प्रत्येक आयताकार आकार के लिए भराव रंग सेट करें।
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

// प्रत्येक आयताकार की रेखा का रंग सेट करें।
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// जॉइन शैली सेट करें।
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// प्रत्येक आयताकार में टेक्स्ट जोड़ें।
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ग्रेडिएंट फिल**

PowerPoint में, ग्रेडिएंट फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार पर सतत रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंगों को इस तरह लागू कर सकते हैं कि एक धीरे-धीरे दूसरे में मिल जाए।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट फिल लगाने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Gradient` सेट करें।
1. [IGradientFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/igradientformat/) इंटरफ़ेस द्वारा एक्स्पोज़ किए गए ग्रेडिएंट स्टॉप कलेक्शन की `Add` विधियों का उपयोग करके निर्दिष्ट स्थितियों के साथ दो पसंदीदा रंग जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```cpp
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Ellipse प्रकार का एक ऑटो शेप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// ellipse पर ग्रेडिएंट फ़ॉर्मेटिंग लागू करें।
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

![ग्रेडिएंट फिल के साथ अंडाकार](gradient-fill.png)

## **पैटर्न फिल**

PowerPoint में, पैटर्न फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको दो‑रंगीन डिज़ाइन—जैसे बिंदु, धारीदार, क्रॉसहैच या चेक—को आकार पर लागू करने की अनुमति देता है। आप पैटर्न के फोरग्राउंड और बैकग्राउंड के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियों प्रदान करता है जिन्हें आप अपनी प्रस्तुतियों के दृश्य आकर्षण को बढ़ाने के लिए आकारों पर लागू कर सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप उस पैटर्न के लिए उपयोग किए जाने वाले सटीक रंग निर्दिष्ट कर सकते हैं।

पैटर्न फिल लागू करने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वनिर्धारित विकल्पों से एक पैटर्न शैली चुनें।
1. पैटर्न के [Background Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipatternformat/get_backcolor/) को सेट करें।
1. पैटर्न के [Foreground Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipatternformat/get_forecolor/) को सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```cpp
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें.
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार का एक ऑटो शेप जोड़ें.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// भरण प्रकार को Pattern सेट करें.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// पैटर्न शैली सेट करें.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// पैटर्न की पृष्ठभूमि और अग्रभूमि रंग सेट करें.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// PPTX फ़ाइल को डिस्क पर सहेजें.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![पैटर्न फिल के साथ आयत](pattern-fill.png)

## **पिक्चर फिल**

PowerPoint में, पिक्चर फिल एक फ़ॉर्मेटिंग विकल्प है जो आपको आकार के अंदर एक चित्र सम्मिलित करने की अनुमति देता है—प्रभावी रूप से चित्र को आकार की पृष्ठभूमि के रूप में उपयोग करता है।

Aspose.Slides का उपयोग करके पिक्चर फिल लागू करने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Picture` सेट करें।
1. पिक्चर फिल मोड को `Tile` (या कोई अन्य पसंदीदा मोड) सेट करें।
1. जिस चित्र का आप उपयोग करना चाहते हैं, उससे एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) ऑब्जेक्ट बनाएं।
1. चित्र को `ISlidesPicture.set_Image` मेथड में पास करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

![लोटस चित्र](lotus.png)

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार का एक ऑटो शेप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// भराव प्रकार को Picture सेट करें.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// पिक्चर भराव मोड सेट करें.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// चित्र लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// चित्र सेट करें.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// PPTX फ़ाइल को डिस्क पर सहेजें.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![चित्र फिल के साथ आकार](picture-fill.png)

### **टाइल पिक्चर को टेक्सचर के रूप में सेट करें**

यदि आप टाइल्ड चित्र को टेक्सचर के रूप में सेट करना चाहते हैं और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [IPictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/picturefillformat/) क्लास की निम्नलिखित विधियों का उपयोग कर सकते हैं:

- [set_PictureFillMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): चित्र फिल मोड सेट करता है—`Tile` या `Stretch`।
- [set_TileAlignment](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): आकार के भीतर टाइलों की एलाइन्मेंट निर्दिष्ट करता है।
- [set_TileFlip](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tileflip/): निर्धारित करता है कि टाइल क्षैतिज, लंबवत या दोनों रूप में फ़्लिप हो।
- [set_TileOffsetX](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): आकार की मूल बिंदु से टाइल का क्षैतिज ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [set_TileOffsetY](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): आकार की मूल बिंदु से टाइल का लंबवत ऑफ़सेट (पॉइंट्स में) सेट करता है।
- [set_TileScaleX](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): टाइल का क्षैतिज स्केल प्रतिशत में परिभाषित करता है।
- [set_TileScaleY](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): टाइल का लंबवत स्केल प्रतिशत में परिभाषित करता है।

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto firstSlide = presentation->get_Slide(0);

// एक आयताकार ऑटो शेप जोड़ें।
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// आकार के भराव प्रकार को Picture सेट करें.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// चित्र लोड करें और इसे प्रस्तुति संसाधनों में जोड़ें.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// चित्र को आकार को असाइन करें.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// पिक्चर भराव मोड और टाइलिंग गुण कॉन्फ़िगर करें.
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

![टाइल विकल्प](tile-options.png)

## **सॉलिड कलर फिल**

PowerPoint में, सॉलिड कलर फिल एक फ़ॉर्मेटिंग विकल्प है जो आकार को एक ही समान रंग से भर देता है। यह साधारण पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, टेक्सचर या पैटर्न के लागू किया जाता है।

Aspose.Slides का उपयोग करके आकार पर सॉलिड कलर फिल लागू करने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Solid` सेट करें।
1. अपनी पसंदीदा फिल रंग को आकार को असाइन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार का एक ऑटो शेप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// भराव प्रकार को Solid सेट करें।
shape->get_FillFormat()->set_FillType(FillType::Solid);

// भराव रंग सेट करें।
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Save the PPTX file to disk.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![सॉलिड कलर फिल के साथ आकार](solid-color-fill.png)

## **पारदर्शिता सेट करें**

PowerPoint में, जब आप आकार पर सॉलिड कलर, ग्रेडिएंट, चित्र या टेक्सचर फिल लागू करते हैं, तो आप फिल की अपारदर्शिता को नियंत्रित करने के लिए पारदर्शिता स्तर भी सेट कर सकते हैं। उच्च पारदर्शिता मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे मौजूद ऑब्जेक्ट्स भागिक रूप से दिखाई देते हैं।

Aspose.Slides आपको फिल में उपयोग किए गए रंग के अल्फा मान को समायोजित करके पारदर्शिता स्तर सेट करने की अनुमति देता है। यह करने का तरीका इस प्रकार है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Solid` सेट करें।
1. `Color` का उपयोग करके अल्फा घटक के साथ पारदर्शी रंग परिभाषित करें।
1. प्रस्तुति को सहेजें।

```cpp
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// एक ठोस आयताकार ऑटो शेप जोड़ें।
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// ठोस आकार के ऊपर एक पारदर्शी आयताकार ऑटो शेप जोड़ें।
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![पारदर्शी आकार](shape-transparency.png)

## **आकार घुमाएँ**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकारों को घुमाने की सुविधा देता है। यह विशेष संरेखण या डिज़ाइन आवश्यकताओं के साथ दृश्य तत्वों को स्थित करने में उपयोगी हो सकता है।

एक स्लाइड पर आकार को घुमाने के लिए निम्नलिखित चरण अपनाएँ:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की रोटेशन प्रॉपर्टी को वांछित कोण पर सेट करें।
1. प्रस्तुति को सहेजें।

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार का एक ऑटो शेप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// आकार को 5 डिग्री घुमाएँ।
shape->set_Rotation(5);

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![आकार घुमाव](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर 3D बिवेल प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

एक आकार पर 3D बिवेल प्रभाव जोड़ने के चरण इस प्रकार हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक ऑब्जेक्ट बनाएं।
1. इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. बिवेल सेटिंग्स को परिभाषित करने के लिए आकार के [ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/threedformat/) को कॉन्फ़िगर करें।
1. प्रस्तुति को सहेजें।

```cpp
// Presentation क्लास की एक इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// स्लाइड में एक आकार जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// आकार की ThreeDFormat प्रॉपर्टीज़ सेट करें।
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

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D घूर्णन प्रभाव जोड़ें**

Aspose.Slides आपको आकारों पर 3D घूर्णन प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/threedformat/) प्रॉपर्टीज़ को कॉन्फ़िगर करते हैं।

एक आकार पर 3D घूर्णन लागू करने के चरण इस प्रकार हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. इंडेक्स द्वारा स्लाइड का एक संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) जोड़ें।
1. [set_CameraType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icamera/set_cameratype/) और [set_LightType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilightrig/set_lighttype/) का उपयोग करके 3D घूर्णन परिभाषित करें।
1. प्रस्तुति को सहेजें।

```cpp
// Presentation क्लास की एक इंस्टैंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![3D घूर्णन प्रभाव](3D-rotation-effect.png)

## **फ़ॉर्मेटिंग रीसेट करें**

निम्नलिखित C++ कोड दिखाता है कि स्लाइड की फ़ॉर्मेटिंग को कैसे रीसेट करके सभी प्लेसहोल्डर वाले आकारों की स्थिति, आकार और फ़ॉर्मेटिंग को उनके डिफ़ॉल्ट सेटिंग्स पर [LayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/layoutslide/) में कैसे वापस लाया जाए:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // लेआउट में प्लेसहोल्डर वाले स्लाइड पर प्रत्येक आकार को रीसेट करें.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**क्या आकार फ़ॉर्मेटिंग अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करती है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियां और मीडिया फ़ाइलें अधिकांश फ़ाइल स्थान लेती हैं, जबकि रंग, प्रभाव और ग्रेडिएंट जैसे आकार पैरामीटर मेटाडेटा के रूप में संग्रहीत होते हैं और लगभग कोई अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे उन स्लाइड पर आकारों को पहचानूं जो समान फ़ॉर्मेटिंग साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार की प्रमुख फ़ॉर्मेटिंग प्रॉपर्टीज़—फिल, लाइन और प्रभाव सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके शैलियों को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे बाद में शैली प्रबंधन सरल हो जाता है।

**क्या मैं कस्टम आकार शैलियों का एक सेट अलग फ़ाइल में सहेजकर अन्य प्रस्तुतियों में पुनः उपयोग कर सकता हूँ?**

हाँ। वांछित शैलियों वाले नमूना आकारों को एक टेम्पलेट स्लाइड डेक या .POTX टेम्पलेट फ़ाइल में संग्रहित करें। नई प्रस्तुति बनाते समय टेम्पलेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ आवश्यकता हो वहां फ़ॉर्मेटिंग पुनः लागू करें।