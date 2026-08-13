---
title: C++ में प्रस्तुति थीम को प्रबंधित करें
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/cpp/presentation-theme/
keywords:
- PowerPoint थीम
- प्रस्तुति थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में मुख्य प्रस्तुति थीम को बनाना, अनुकूलित करना और निरंतर ब्रांडिंग के साथ PowerPoint फ़ाइलों को परिवर्तित करना।"
---
## **परिचय**

एक प्रस्तुति थीम डिज़ाइन तत्वों की विशेषताओं को परिभाषित करती है। जब आप एक प्रस्तुति थीम चुनते हैं, तो आप मूल रूप से दृश्यमान तत्वों और उनकी विशेषताओं का एक विशिष्ट सेट चुन रहे होते हैं।

PowerPoint में, एक थीम रंग, [फ़ॉन्ट](/slides/hi/cpp/powerpoint-fonts/), [पृष्ठभूमि शैली](/slides/hi/cpp/presentation-background/), और प्रभावों से बनती है।

![थीम के घटक](theme-constituents.png)

## **थीम रंग बदलें**

PowerPoint थीम स्लाइड पर विभिन्न तत्वों के लिए एक विशिष्ट रंग सेट का उपयोग करती है। यदि आपको रंग पसंद नहीं हैं, तो आप थीम के लिए नए रंग लागू करके उन्हें बदल सकते हैं। नया थीम रंग चुनने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) एन्युमरेशन में मान प्रदान करता है।

यह C++ कोड दर्शाता है कि थीम के एक्सेंट रंग को कैसे बदलें:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

आप इस प्रकार परिणामस्वरूप रंग के प्रभावी मान को निर्धारित कर सकते हैं:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (रंग [A=255, R=128, G=100, B=162])
```

रंग परिवर्तन ऑपरेशन को और प्रदर्शित करने के लिए, हम एक अन्य तत्व बनाते हैं और उसे प्रारंभिक ऑपरेशन के एक्सेंट रंग को असाइन करते हैं। फिर हम थीम में रंग बदलते हैं:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

नया रंग दोनों तत्वों पर स्वचालित रूप से लागू हो जाता है।

### **अतिरिक्त पैलेट से थीम रंग सेट करें**

जब आप मुख्य थीम रंग(1) पर ल्यूमीनेस ट्रांसफ़ॉर्मेशन लागू करते हैं, तो अतिरिक्त पैलेट(2) के रंग बनते हैं। आप फिर उन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![अतिरिक्त पैलेट के रंग](additional-palette-colors.png)

**1**- मुख्य थीम रंग  
**2**- अतिरिक्त पैलेट के रंग।

यह C++ कोड एक ऑपरेशन दर्शाता है जहाँ अतिरिक्त पैलेट के रंग मुख्य थीम रंग से प्राप्त किए जाते हैं और फिर आकृतियों में उपयोग किए जाते हैं:

```c++
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **`SchemeColor` को `IColorScheme` रंगों से मैप करें**

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides.schemecolor/) के साथ काम करते हैं, तो आप देख सकते हैं कि इसमें निम्नलिखित थीम रंग मान होते हैं:

`Background1`, `Background2`, `Text1`, and `Text2`.

हालाँकि, `Presentation::get_MasterTheme()::get_ColorScheme()` [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) लौटाता है, जो संबंधित रंगों को इस प्रकार प्रकट करता है:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

यह अंतर केवल नामावली में है। ये मान समान थीम रंग स्लॉट को दर्शाते हैं और मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` और `Dark`/`Light` के बीच कोई गतिशील रूपांतरण नहीं है। वे केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामांकन अंतर Microsoft Office शब्दावली से आता है। पुराने Office संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` का उपयोग किया जाता था, जबकि नवीनतम UI संस्करण समान स्लॉट को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में दिखाते हैं।

## **थीम फ़ॉन्ट बदलें**

थीम और अन्य उद्देश्यों के लिए फ़ॉन्ट चुनने के लिए, Aspose.Slides इन विशेष पहचानकर्ताओं का उपयोग करता है (PowerPoint में उपयोग किए जाने वाले समान):

* **+mn-lt** - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* **+mj-lt** - हेडिंग फ़ॉन्ट लैटिन (मेजर लैटिन फ़ॉन्ट)
* **+mn-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)
* **+mj-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (मेजर ईस्ट एशियन फ़ॉन्ट)

यह C++ कोड दिखाता है कि थीम तत्व को लैटिन फ़ॉन्ट कैसे असाइन करें:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

यह C++ कोड दिखाता है कि प्रस्तुति थीम फ़ॉन्ट कैसे बदलें:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

सभी टेक्स्ट बॉक्स में फ़ॉन्ट अपडेट हो जाएगा।

{{% alert color="info" title="TIP" %}} 
आप शायद [PowerPoint फ़ॉन्ट](/slides/hi/cpp/powerpoint-fonts/) देखना चाहें।  
{{% /alert %}}

## **थीम पृष्ठभूमि शैली बदलें**

डिफ़ॉल्ट रूप से, PowerPoint एप्लिकेशन 12 पूर्वनिर्धारित पृष्ठभूमियाँ प्रदान करता है, लेकिन उन 12 में से केवल 3 पृष्ठभूमियाँ सामान्य प्रस्तुति में सहेजी जाती हैं।

![उदाहरण छवि](presentation-design_8.png)

उदाहरण के लिए, PowerPoint एप्लिकेशन में प्रस्तुति सहेजने के बाद, आप इस C++ कोड को चलाकर प्रस्तुति में पूर्वनिर्धारित पृष्ठभूमियों की संख्या पता कर सकते हैं:

```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
आप [BackgroundFillStyles](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) प्रॉपर्टी को [FormatScheme](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme/) क्लास से उपयोग करके PowerPoint थीम में पृष्ठभूमि शैली जोड़ या एक्सेस कर सकते हैं।  
{{% /alert %}}

यह C++ कोड दर्शाता है कि प्रस्तुति के लिए पृष्ठभूमि कैसे सेट करें:

```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**इंडेक्स गाइड**: 0 का उपयोग बिना भराव के किया जाता है। इंडेक्स 1 से शुरू होता है।

{{% alert color="info" title="TIP" %}} 
आप शायद [PowerPoint पृष्ठभूमि](/slides/hi/cpp/presentation-background/) देखना चाहें।  
{{% /alert %}}

## **थीम प्रभाव बदलें**

PowerPoint थीम आम तौर पर प्रत्येक शैली एरे के लिए 3 मान रखती है। उन एरे को मिलाकर 3 प्रभाव बनते हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, जब इन प्रभावों को किसी विशिष्ट आकृति पर लागू किया जाता है तो यह परिणाम होता है:

![उदाहरण छवि](presentation-design_10.png)

आप [FormatScheme](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme/) क्लास से 3 प्रॉपर्टियों ([FillStyles](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) का उपयोग करके थीम के तत्वों को बदल सकते हैं (PowerPoint में उपलब्ध विकल्पों से भी अधिक लचीलापन के साथ)।

यह C++ कोड दिखाता है कि तत्वों के हिस्सों को बदलकर थीम प्रभाव कैसे बदलें:

```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

परिणामस्वरूप भराव रंग, भराव प्रकार, शैडो प्रभाव आदि में परिवर्तन:

![उदाहरण छवि](presentation-design_11.png)

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं मास्टर को बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?

हाँ। Aspose.Slides स्लाइड-स्तर पर थीम ओवरराइड का समर्थन करता है, इसलिए आप केवल उस स्लाइड पर स्थानीय थीम लागू कर सकते हैं जबकि मास्टर थीम को अपरिवर्तित रख सकते हैं ([SlideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/slidethememanager/) के माध्यम से)।

### एक प्रस्तुति से दूसरी प्रस्तुति में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?

[स्लाइड्स क्लोन](/slides/hi/cpp/clone-slides/) को उनके मास्टर के साथ लक्षित प्रस्तुति में ले जाएँ। यह मूल मास्टर, लेआउट और संबंधित थीम को संरक्षित करता है जिससे स्वरूप समान रहता है।

### सभी विरासत और ओवरराइड के बाद "प्रभावी" मान कैसे देखूँ?

थीम/रंग/फ़ॉन्ट/प्रभाव के लिए API के ["प्रभावी" व्यूज़](/slides/hi/cpp/shape-effective-properties/) का उपयोग करें। ये मास्टर लागू करने के बाद तथा किसी भी स्थानीय ओवरराइड के बाद उत्पन्न अंतिम प्रॉपर्टीज़ को लौटाते हैं।