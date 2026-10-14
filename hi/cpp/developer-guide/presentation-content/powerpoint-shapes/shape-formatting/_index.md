---
title: "C++ में PowerPoint आकारों को स्वरूपित करें"
linktitle: "आकार स्वरूपण"
type: docs
weight: 20
url: /hi/cpp/shape-formatting/
keywords:
- "आकार स्वरूपण"
- "रेखा स्वरूपण"
- "स्केच प्रभाव"
- "स्केच आकार रेखा"
- "जॉइन शैली स्वरूपण"
- "ग्रेडिएंट भराव"
- "पैटर्न भराव"
- "चित्र भराव"
- "टेक्सचर भराव"
- "एकरंगी रंग भराव"
- "आकार पारदर्शिता"
- "काले-सफ़ेद आकार रेंडरिंग"
- "ग्रेस्केल आकार रेंडरिंग"
- "आकार घुमाना"
- "3D बिवेल प्रभाव"
- "3D घुमाव प्रभाव"
- "स्वरूपण रीसेट"
- "PowerPoint"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint आकारों को स्वरूपित करना सीखें—PPT, PPTX और ODP फ़ाइलों के लिए भराव, रेखा और प्रभाव शैलियों को सटीकता और पूर्ण नियंत्रण के साथ सेट करें।"
---
## **परिचय**

PowerPoint में आप स्लाइड्स में आकार जोड़ सकते हैं। चूँकि आकार रेखाओं से बने होते हैं, आप उनकी रूपरेखा को संशोधित करके या उस पर इफ़ेक्ट्स लागू करके उनका स्वरूपण कर सकते हैं। अतिरिक्त रूप से, आप आकारों का स्वरूपण ऐसे सेटिंग्स निर्दिष्ट करके कर सकते हैं जो नियंत्रित करता है कि उनका आंतरिक भाग कैसे भरा जाता है।

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ इंटरफ़ेस और मेथड्स प्रदान करता है जो आपको PowerPoint में उपलब्ध समान विकल्पों का उपयोग करके आकारों को स्वरूपित करने की अनुमति देता है।

## **रेखाओं का स्वरूपण**

Aspose.Slides का उपयोग करके आप आकार के लिए कस्टम लाइन शैली निर्दिष्ट कर सकते हैं। नीचे दी गई चरण‑बद्ध प्रक्रिया इसे दर्शाती है:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [लाइन शैली](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) सेट करें।
1. लाइन की चौड़ाई सेट करें।
1. लाइन की [डैश शैली](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) सेट करें।
1. आकार के लिए लाइन का रंग सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

आयत `AutoShape` को स्वरूपित करने वाला कोड इस प्रकार है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instantiate the Presentation class that represents a presentation file.
auto presentation = MakeObject<Presentation>();

// Get the first slide.
auto slide = presentation->get_Slide(0);

// Add an auto shape of the Rectangle type.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Set the fill color for the rectangle shape.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Apply formatting to the rectangle's lines.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Set the color for the rectangle's line.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the PPTX file to disk.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![प्रेजेंटेशन में स्वरूपित रेखाएँ](formatted-lines.png)

## **आकार रेखाओं पर स्केच प्रभाव लागू करना**

स्केच प्रभाव आकार की रेखा को हाथ से लिखी हुई जैसा बनाता है। लाइन सेटिंग्स तक पहुंचने के लिए [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) का उपयोग करें, स्केच सेटिंग्स तक पहुंचने के लिए [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) का उपयोग करें, और [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) से [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) एन्हुमरेशन में से मान चुनें।

नीचे दिया गया C++ कोड दिखाता है कि कैसे [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) प्रभाव लागू किया जाता है, मान पढ़ा जाता है, और [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) से प्रभाव हटाया जाता है:

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

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) द्वारा लौटाया गया मान सीधे आकार को असाइन किए गए सेटिंग को दर्शाता है। यदि लाइन स्वरूपण थीम, मास्टर स्लाइड या लेआउट स्लाइड से विरासत में मिल सकता है, तो [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) का उपयोग करें, [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) तक पहुंचें, और [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) पढ़ें। प्रभावी मान वह स्वरूपण दर्शाता है जो विरासत के समाधान के बाद वास्तव में लागू होता है:

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

## **जॉइन शैली स्वरूपण**

तीन जॉइन प्रकार विकल्प हैं:

* गोल
* मिटर
* बीवल

डिफ़ॉल्ट रूप से, जब PowerPoint दो रेखाओं को कोण पर जोड़ता है (जैसे आकार के कोने पर), वह **गोल** सेटिंग का उपयोग करता है। हालांकि, यदि आप तीव्र कोण वाले आकार बनाते हैं, तो आप **मिटर** विकल्प को पसंद कर सकते हैं।

![प्रेजेंटेशन में जॉइन शैली](join-style-powerpoint.png)

नीचे दिया गया C++ कोड दर्शाता है कि ऊपर दिखाए गए चित्र की तरह तीन आयतों को मिटर, बीवल और गोल जॉइन शैली सेटिंग्स के साथ कैसे बनाया गया:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation क्लास का एक इंस्टेंस बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार के तीन ऑटो शैप्स जोड़ें।
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// प्रत्येक आयत आकार के भराव रंग को सेट करें।
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

// प्रत्येक आयत की रेखा का रंग सेट करें।
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

// प्रत्येक आयत में टेक्स्ट जोड़ें।
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ग्रेडिएंट भराव**

PowerPoint में ग्रेडिएंट भराव एक स्वरूपण विकल्प है जो आपको आकार पर निरंतर रंग मिश्रण लागू करने की अनुमति देता है। उदाहरण के लिए, आप दो या अधिक रंग इस प्रकार लागू कर सकते हैं कि एक धीरे‑धीरे दूसरे में बदलता रहे।

Aspose.Slides का उपयोग करके आकार पर ग्रेडिएंट भराव लागू करने के चरण इस प्रकार हैं:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) को `Gradient` सेट करें।
1. [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) इंटरफ़ेस द्वारा प्रदान किए गए ग्रेडिएंट स्टॉप कलेक्शन की `Add` विधियों का उपयोग करके दो वांछित रंग तथा उनकी स्थितियों को परिभाषित करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया C++ कोड दिखाता है कि कैसे एक दीर्घवृत्त पर ग्रेडिएंट भराव प्रभाव लागू किया जाता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का एक इंस्टेंस बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Ellipse प्रकार का एक ऑटो शैप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// एलीप्स पर ग्रेडिएंट स्वरूपण लागू करें।
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

![ग्रेडिएंट भराव वाला दीर्घवृत्त](gradient-fill.png)

यदि ग्रेडिएंट निर्यातित छवि में PowerPoint की तुलना में अलग दिखता है, तो देखें [Choose a Gradient Rendering Style](/slides/hi/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)। आप प्रस्तुतिकरण में संग्रहीत ग्रेडिएंट भराव को बदले बिना रेंडरिंग शैली चुन सकते हैं।

## **पैटर्न भराव**

PowerPoint में पैटर्न भराव एक स्वरूपण विकल्प है जो आपको दो‑रंग डिज़ाइन—जैसे बिंदु, धारियां, क्रॉसहैच या चेक—आकार पर लागू करने देता है। आप पैटर्न के अग्रभूमि और पृष्ठभूमि के लिए कस्टम रंग चुन सकते हैं।

Aspose.Slides 45 से अधिक पूर्वनिर्धारित पैटर्न शैलियाँ प्रदान करता है जिन्हें आप आकारों पर लागू करके अपनी प्रस्तुतियों की दृश्य आकर्षकता बढ़ा सकते हैं। पूर्वनिर्धारित पैटर्न चुनने के बाद भी आप सटीक रंग निर्धारित कर सकते हैं।

Aspose.Slides का उपयोग करके आकार पर पैटर्न भराव लागू करने के चरण इस प्रकार हैं:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) को `Pattern` सेट करें।
1. पूर्वनिर्धारित विकल्पों में से एक पैटर्न शैली चुनें।
1. पैटर्न की [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) सेट करें।
1. पैटर्न की [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) सेट करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया C++ कोड दर्शाता है कि कैसे एक आयत पर पैटर्न भराव लागू किया जाता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation क्लास का एक इंस्टेंस बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार का एक ऑटो शैप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// भरण प्रकार को Pattern सेट करें।
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// पैटर्न शैली सेट करें।
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// पैटर्न की पृष्ठभूमि और अग्रभूमि रंग सेट करें।
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैटर्न भराव वाला आयत](pattern-fill.png)

## **चित्र भराव**

PowerPoint में चित्र भराव एक स्वरूपण विकल्प है जो आपको आकार के भीतर एक छवि डालने की अनुमति देता है—वास्तव में छवि को आकार की पृष्ठभूमि बनाते हुए।

Aspose.Slides का उपयोग करके आकार पर चित्र भराव लागू करने के चरण इस प्रकार हैं:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) को `Picture` सेट करें।
1. चित्र भराव मोड को `Tile` (या कोई अन्य वांछित मोड) सेट करें।
1. उपयोग करने वाली छवि से एक [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) ऑब्जेक्ट बनाएं।
1. छवि को `ISlidesPicture.set_Image` मेथड में पास करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

मान लें कि हमारे पास "lotus.png" फ़ाइल है जिसके साथ निम्न चित्र जुड़ा है:

![लोटस चित्र](lotus.png)

नीचे दिया गया C++ कोड दर्शाता है कि कैसे आकार को चित्र से भरा जाता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का एक इंस्टेंस बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार का एक ऑटो शैप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// भरण प्रकार को Picture सेट करें।
shape->get_FillFormat()->set_FillType(FillType::Picture);

// चित्र भराव मोड सेट करें।
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// एक छवि लोड करें और उसे प्रेजेंटेशन संसाधनों में जोड़ें।
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// चित्र सेट करें।
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![चित्र भराव वाला आकार](picture-fill.png)

### **टाइल चित्र को बनावट के रूप में उपयोग करना**

यदि आप टाइल किए गए चित्र को बनावट के रूप में सेट करना और टाइलिंग व्यवहार को अनुकूलित करना चाहते हैं, तो आप [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) क्लास की निम्न विधियों का उपयोग कर सकते हैं:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): चित्र भराव मोड `Tile` या `Stretch` सेट करता है।
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): आकार के भीतर टाइल की संरेखण निर्दिष्ट करता है।
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): टाइल को क्षैतिज, लंबवत या दोनों दिशाओं में उलटने को नियंत्रित करता है।
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): आकार की मूल बिंदु से टाइल के क्षैतिज ऑफ़सेट (पॉइंट में) स्थापित करता है।
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): आकार की मूल बिंदु से टाइल के लंबवत ऑफ़सेट (पॉइंट में) स्थापित करता है।
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): टाइल के क्षैतिज स्केल को प्रतिशत में परिभाषित करता है।
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): टाइल के लंबवत स्केल को प्रतिशत में परिभाषित करता है।

नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे एक आयत आकार में टाइल चित्र भराव जोड़कर टाइल विकल्प कॉन्फ़िगर किए जाते हैं:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का एक इंस्टेंस बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto firstSlide = presentation->get_Slide(0);

// एक आयत ऑटो शैप जोड़ें।
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// आकार का भराव प्रकार Picture सेट करें।
shape->get_FillFormat()->set_FillType(FillType::Picture);

// छवि लोड करें और उसे प्रेजेंटेशन संसाधनों में जोड़ें।
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// छवि को आकार को असाइन करें।
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// चित्र भराव मोड और टाइलिंग गुण कॉन्फ़िगर करें।
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![टाइल विकल्प](tile-options.png)

## **एकरंगी रंग भराव**

PowerPoint में एकरंगी रंग भराव एक स्वरूपण विकल्प है जो आकार को एक समान रंग से भरता है। यह साधारण पृष्ठभूमि रंग बिना किसी ग्रेडिएंट, बनावट या पैटर्न के लागू होता है।

Aspose.Slides का उपयोग करके आकार पर एकरंगी रंग भराव लागू करने के चरण इस प्रकार हैं:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) को `Solid` सेट करें।
1. आकार को अपनी इच्छित भराव रंग असाइन करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया C++ कोड दर्शाता है कि कैसे PowerPoint स्लाइड में एक आयत पर एकरंगी रंग भराव लागू किया जाता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation क्लास का एक इंस्टेंस बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार का एक ऑटो शैप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// भरण प्रकार को Solid सेट करें।
shape->get_FillFormat()->set_FillType(FillType::Solid);

// भरण रंग सेट करें।
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![एकरंगी रंग भराव वाला आकार](solid-color-fill.png)

## **पारदर्शिता सेट करना**

PowerPoint में, जब आप आकार पर एकरंगी, ग्रेडिएंट, चित्र या बनावट भराव लागू करते हैं, तो आप भराव की अपारदर्शिता स्तर भी सेट कर सकते हैं जिससे भराव की पारदर्शिता नियंत्रित होती है। अधिक पारदर्शिता मान आकार को अधिक पारदर्शी बनाता है, जिससे पृष्ठभूमि या नीचे के वस्तुएँ आंशिक रूप से दिखाई देती हैं।

Aspose.Slides आपको भराव के लिए उपयोग किए गए रंग में अल्फा मान समायोजित करके पारदर्शिता स्तर सेट करने देता है। इसे करने के चरण इस प्रकार हैं:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) जोड़ें।
1. [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) को `Solid` सेट करें।
1. `Color` का उपयोग करके पारदर्शिता (अल्फा घटक) वाले रंग को परिभाषित करें।
1. प्रेजेंटेशन को सहेजें।

नीचे दिया गया C++ कोड दर्शाता है कि कैसे एक आयत पर पारदर्शी भराव रंग लागू किया जाता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation क्लास का एक इंस्टेंस बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// एक ठोस आयत ऑटो शैप जोड़ें।
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// ठोस आकार के ऊपर एक पारदर्शी आयत ऑटो शैप जोड़ें।
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पारदर्शी आकार](shape-transparency.png)

## **आकारों को घुमाना**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में आकारों को घुमाने की सुविधा देता है। यह दृश्य तत्वों को विशेष संरेखण या डिज़ाइन आवश्यकता के साथ स्थित करने के लिए उपयोगी हो सकता है।

स्लाइड पर एक आकार को घुमाने के चरण इस प्रकार हैं:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की घुमाव प्रॉपर्टी को वांछित कोण पर सेट करें।
1. प्रेजेंटेशन को सहेजें।

नीचे दिया गया C++ कोड दिखाता है कि कैसे आकार को 5 डिग्री घुमाया जाता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का एक इंस्टेंस बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करें।
auto slide = presentation->get_Slide(0);

// Rectangle प्रकार का एक ऑटो शैप जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// आकार को 5 डिग्री घुमाएं।
shape->set_Rotation(5);

// PPTX फ़ाइल को डिस्क पर सहेजें।
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![आकार घुमाव](shape-rotation.png)

## **3D बिवेल प्रभाव जोड़ना**

Aspose.Slides आपको आकारों पर 3D बिवेल प्रभाव लागू करने की अनुमति देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) प्रॉपर्टी को कॉन्फ़िगर करते हैं।

एक आकार पर 3D बिवेल प्रभाव जोड़ने के चरण इस प्रकार हैं:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास को इंस्टैंशिएट करें।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) जोड़ें।
1. आकार की [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) को बिवेल सेटिंग्स परिभाषित करने के लिए कॉन्फ़िगर करें।
1. प्रेजेंटेशन को सहेजें।

नीचे दिया गया C++ कोड दिखाता है कि कैसे आकार पर 3D बिवेल प्रभाव लागू किया जाता है:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation क्लास का एक इंस्टेंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// स्लाइड में एक आकार जोड़ें।
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// आकार की ThreeDFormat प्रॉपर्टीज सेट करें।
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![3D बिवेल प्रभाव](3D-bevel-effect.png)

## **3D घुमाव प्रभाव जोड़ना**

Aspose.Slides आपको आकारों पर 3D घुमाव प्रभाव लागू करने की सुविधा देता है, जिसके लिए आप उनके [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) प्रॉपर्टी को कॉन्फ़िगर करते हैं।

आकार पर 3D घुमाव लागू करने के चरण इस प्रकार हैं:

1. [प्रेजेंटेशन](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में एक [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) जोड़ें।
1. [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) और [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) का उपयोग करके 3D घुमाव परिभाषित करें।
1. प्रेजेंटेशन को सहेजें।

नीचे दिया गया C++ कोड दर्शाता है कि कैसे आकार पर 3D घुमाव प्रभाव लागू किया जाता है:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास का एक इंस्टेंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![3D घुमाव प्रभाव](3D-rotation-effect.png)

## **आकारों के लिए काले‑सफ़ेद रेंडरिंग नियंत्रित करना**

[IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) मेथड निर्धारित करता है कि जब प्रस्तुति को काले‑सफ़ेद मोड में देखा या प्रोसेस किया जाता है तो व्यक्तिगत आकार कैसे रेंडर किया जाता है। यह स्वयं काले‑सफ़ेद प्रदर्शन को सक्षम नहीं करता और न ही सामान्य रंग मोड में आकार की भराव, रेखा या अन्य स्वरूपण को बदलता है।

वांछित व्यवहार चुनने के लिए आप [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) एन्हुमरेशन से मान उपयोग कर सकते हैं। उदाहरण के लिए, `Automatic` रेंडरिंग एप्लिकेशन को परिवर्तन चुनने देता है, `Gray` और `LightGray` ग्रे रंग उपयोग करते हैं, `BlackWhite` केवल काला‑सफ़ेद उपयोग करता है, `Black` और `White` एकल रंग लागू करते हैं, `Color` सामान्य रंग संरक्षित रखता है, और `Hidden` काले‑सफ़ेद मोड में आकार को हटाता है। `NotDefined` का अर्थ है कि कोई आकार‑स्तर मोड असाइन नहीं किया गया है।

नीचे दिया गया C++ कोड एक रंगीन आकार बनाता है और इसे काले‑सफ़ेद प्रदर्शन मोड में ग्रे दिखाता है:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// रंग मोड में नारंगी भराव रखें, लेकिन काले-सफ़ेद मोड में आकार को ग्रे रंग में रेंडर करें.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

सामान्य रंग मोड में, आयत का नारंगी भराव बना रहता है। काले‑सफ़ेद प्रदर्शन वर्कफ़्लो में, यह ग्रे दिखता है क्योंकि उसका मोड `Gray` पर सेट है। यह आपको पूर्ण‑रंग स्लाइड को संरक्षित रखने की अनुमति देता है, जबकि प्रिंट, प्री‑व्यू या अन्य वर्कफ़्लो के लिए अलग दृश्य परिभाषित करता है जो प्रस्तुति के काले‑सफ़ेद प्रदर्शन सेटिंग्स का सम्मान करते हैं।

## **स्वरूपण रीसेट करना**

नीचे दिया गया C++ कोड दिखाता है कि कैसे स्लाइड का स्वरूपण रीसेट किया जाए और [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) पर सभी प्लेसहोल्डर वाले आकारों की स्थिति, आकार और स्वरूपण को उनकी डिफ़ॉल्ट सेटिंग्स पर वापस लाया जाए:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // लेआउट पर प्लेसहोल्डर वाले स्लाइड में सभी आकार को रीसेट करें।
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अधिक पूछे जाने वाले प्रश्न**

**क्या आकार स्वरूपण अंतिम प्रस्तुति फ़ाइल आकार को प्रभावित करता है?**

केवल न्यूनतम रूप से। एम्बेडेड छवियों और मीडिया फ़ाइलों का आकार अधिकांश फ़ाइल स्पेस लेता है, जबकि रंग, इफ़ेक्ट और ग्रेडिएंट जैसे आकार पैरामीटर मेटाडेटा के रूप में संग्रहीत होते हैं और व्यावहारिक रूप से अतिरिक्त आकार नहीं जोड़ते।

**मैं कैसे पता लगा सकता हूँ कि स्लाइड पर कौन‑से आकार समान स्वरूपण साझा करते हैं ताकि मैं उन्हें समूहित कर सकूँ?**

प्रत्येक आकार के प्रमुख स्वरूपण गुणों—भरण, रेखा और इफ़ेक्ट सेटिंग्स—की तुलना करें। यदि सभी संबंधित मान मेल खाते हैं, तो उनके शैलियों को समान मानें और उन आकारों को तार्किक रूप से समूहित करें, जिससे आगे के शैली प्रबंधन को सरल बनाया जा सके।

**क्या मैं कस्टम आकार शैलियों का सेट अलग फ़ाइल में सहेज कर अन्य प्रस्तुतियों में दोबारा उपयोग कर सकता हूँ?**

हाँ। वांछित शैलियों वाले नमूना आकारों को एक टेम्प्लेट स्लाइड डेक या .POTX टेम्प्लेट फ़ाइल में स्टोर करें। नई प्रस्तुति बनाते समय टेम्प्लेट खोलें, आवश्यक शैली वाले आकारों को क्लोन करें, और जहाँ‑जहाँ आवश्यक हो उनके स्वरूपण को दोबारा लागू करें।