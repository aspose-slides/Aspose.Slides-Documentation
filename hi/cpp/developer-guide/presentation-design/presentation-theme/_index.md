---
title: C++ में प्रस्तुति थीम प्रबंधित करें
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
- बाहरी थीम
- THMX
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
description: "Aspose.Slides for C++ में मुख्य प्रस्तुति थीम को बनाना, अनुकूलित करना और स्थिर ब्रांडिंग के साथ PowerPoint फ़ाइलों को बदलना।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सचेत वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करती हैं, इसलिए थीम परिवर्तन कई वस्तुओं को एक साथ अद्यतन कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/) के माध्यम से उपलब्ध है। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। कोई मास्टर [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) के माध्यम से प्रस्तुति थीम को ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) का उपयोग कर सकती है। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस वारिसी श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्य‑प्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और वारिसी तथा ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [get_ColorScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), और [get_FormatScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) मेथड उजागर करता है। इन्हें बदलने से पहले इन संग्रहों की जाँच विशेष रूप से उपयोगी होती है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

यदि फ़ाइल कई मास्टर का उपयोग करती है, तो यह न मानें कि प्रत्येक स्लाइड का समान प्रभावी थीम है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं तो इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्य‑प्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑सचेत भराव, रेखा और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग का संदर्भ ले सकते हैं। जब आप थीम के [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग को संदर्भित करती हैं, नए मान के विरुद्ध हल हो जाती हैं। सीधे RGB रंग का उपयोग करने वाली वस्तुओं को थीम‑रंग अद्यतन से नहीं बदला जाता।

निम्न अंत‑से‑अंत उदाहरण एक आकृति बनाता है जो `Accent4` का उपयोग करती है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति सहेजता है, पुनः खोलता है, और प्रभावी भराव रंग को प्रिंट करता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

चूँकि आयत `Accent4` से जुड़ी हुई रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकृति पर स्कीम रंग को सीधे रंग से बदल देते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करने के लिए रंग परिवर्तन लागू करता है। Aspose.Slides इन परिवर्तनों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/colortransformoperation/) के माध्यम से उजागर करता है।

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - मुख्य थीम रंग।  
**2** - मुख्य थीम रंगों से निर्मित हल्के और गहरे वैरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम सहेजता है:

```cpp
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
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

ये वैरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नए `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) समान थीम स्लॉट को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

ये एक ही थीम स्लॉट के वैकल्पिक नाम हैं; ये कोई गतिशील रूपांतरण नहीं हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग के लिए एक प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए एक गौण फ़ॉन्ट सेट होता है। [FontScheme::get_Major()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_major/) और [FontScheme::get_Minor()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_minor/) मेथड इन सेटों को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)  
* `+mj‑lt`- हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)  
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियाई (Minor East Asian Font)  
* `+mj‑ea` - हेडिंग फ़ॉन्ट ईस्ट एशियाई (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी पंक्ति जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। यदि फ़ॉन्ट नाम स्पष्ट रूप से निर्दिष्ट है न कि थीम पहचानकर्ता, तो थीम फ़ॉन्ट स्कीम बदलने पर वह स्वचालित रूप से नहीं बदलेगा।

मुख्य और गौण फ़ॉन्ट संग्रह व्यक्तिगत लिपि प्रणालियों, जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन, और थाना के लिए फ़ॉन्ट मैपिंग भी रख सकते हैं। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/cpp/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
परिचय फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/cpp/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

नीचे के कार्य‑प्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **मास्टर‑निर्भर स्लाइड्स पर बाहरी थीम लागू करें**

जब आपके पास एक PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशिष्ट मास्टर पर निर्भर सभी स्लाइड्स की शैली बदलना चाहते हों, तो [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) का उपयोग करें। [Presentation::get_Masters](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_masters/) संग्रह से इच्छित मास्टर चुनें, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/) को लागू करता है, और मेथड को थीम फ़ाइल पथ प्रदान करें।

यह मेथड निम्न कार्य करता है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।  
2. नई मास्टर पर बाहरी थीम लागू करता है।  
3. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नई मास्टर सौंपता है।  
4. नए बनाए गए [IMasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) को लौटाता है।

निम्न उदाहरण बाहरी थीम को पहले मास्टर पर निर्भर स्लाइड्स पर लागू करता है और प्रस्तुति सहेजता है:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

एक अमान्य, दूषित, या असमर्थित थीम [PptxException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxexception/) या उसके फ़ॉर्मेट‑संबंधी उप‑क्लास को उत्पन्न कर सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पथों को मान्य करें, फ़ाइल‑सिस्टम पहुंच विफलताओं को संभालें, और केवल तब ही प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल उन स्लाइड्स को पुनः‑सौंपा जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों से जुड़ी स्लाइड्स अपने मौजूदा मास्टर और थीम को बना रखती हैं। थीम‑सचेत रंग, फ़ॉन्ट, भराव, रेखा, पृष्ठभूमि, और प्रभाव बाहरी थीम के विरुद्ध हल होते हैं। सीधे सौंपे गए रंग, फ़ॉन्ट, भराव और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड नई मास्टर से विरासत प्राप्त मानों पर भी प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट का संदर्भ दे सकती है जो रन‑टाइम वातावरण में उपलब्ध नहीं हों। निरंतर रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट इंस्टॉल करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/cpp/custom-font/) के माध्यम से उपलब्ध कराएँ, या [फ़ॉन्ट प्रतिरूपण](/slides/hi/cpp/font-substitution/) कॉन्फ़िगर करें।

यह सीधा मास्टर‑स्तर कार्य‑प्रवाह है: मेथड एक `.thmx` फ़ाइल पथ स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअली बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब प्रासंगिक मास्टर पहले से ज्ञात न हो, तो इसे प्रतिनिधि स्लाइड से [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/get_layoutslide/) और [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_masterslide/) के माध्यम से प्राप्त करें। किसी भी थीम को लागू करने से पहले मूल मास्टर संदर्भों को सहेजें, क्योंकि प्रत्येक कॉल प्रस्तुति में एक और मास्टर बनाती है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स के मास्टर खोजता है और प्रत्येक समूह पर अलग‑अलग बाहरी थीम लागू करता है:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

पहला कॉल केवल `firstGroupMaster` पर निर्भर स्लाइड्स को प्रभावित करता है, जबकि दूसरा कॉल केवल `secondGroupMaster` पर निर्भर स्लाइड्स को। अन्य मास्टरों से जुड़ी स्लाइड्स का स्वरूप नहीं बदलता।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप एक स्लाइड को दूसरी प्रस्तुति में ले जाना चाहते हैं और उसका मूल डिज़ाइन बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) से क्लोन करें, फिर स्लाइड को क्लोन किए गए मास्टर के साथ [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) से क्लोन करें। इससे मास्टर, उसके लेआउट, और संबंधित थीम साथ में चलते हैं।

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

यह वह पसंदीदा कार्य‑प्रवाह है जब स्रोत स्लाइड का स्वरूप गंतव्य में समान रहना चाहिए। असंबंधित गंतव्य मास्टर पर केवल सामग्री क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर रखना है, तो स्रोत थीम से स्लाइड‑स्तर का ओवरराइड प्रारंभ करें। [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), और [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) मेथड तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

यह अन्य स्लाइड्स द्वारा विरासत में प्राप्त थीम को बदले बिना उस स्लाइड की थीम बदलता है। स्थानीय ओवरराइड हटाकर विरासत मानों पर लौटने के लिए [OverrideTheme::Clear()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/clear/) कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

एक लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट को उपयोग करती हैं, जब तक कि कोई विशिष्ट स्लाइड अपनी स्वयं की ओवरराइड न रखे। समान प्रारंभिक मेथड लेआउट के [IOverrideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

जब कई लेआउट और स्लाइड्स को समान बुनियादी डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर थीम उपयोग करें, एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) में संग्रहीत होती हैं। PowerPoint UI में पृष्ठभूमि विकल्पों की संख्या इस संग्रह में वास्तविक भराव परिभाषाओं से अधिक हो सकती है, क्योंकि UI थीम भराव को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकती है।

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले संग्रह और वर्तमान [Background::get_StyleIndex()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/get_styleindex/) जाँचें। `StyleIndex` `0` का उपयोग थीम्ड भराव न होने के लिए करता है; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह C++ संग्रह को `idx_get(0)` से सीधे इंडेक्स करने से अलग है, जहाँ `0` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि हर प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियाँ होती हैं।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, पहले मास्टर को थीम्ड पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति सहेजता है:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

दर्शित परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगा। अंतिम पृष्ठभूमि जानने के लिए जब वारिसी लागू हो गई हो, तब [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`StyleIndex` को शून्य‑आधारित संग्रह इंडेक्स न समझें। किसी फ़ाइल से स्थिर शैली संख्या को कोड में हार्ड‑कोड करके दूसरे फ़ाइल में उपयोग न करें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि वारिसी के लिए देखें [Presentation Background](/slides/hi/cpp/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_linestyles/), और [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) संग्रह होते हैं। सामान्य Office थीम में अक्सर तीन मुख्य शैली प्रविष्टियाँ होती हैं जो क्रमशः सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह को जाँचना चाहिए न कि निश्चित गिनती मान लेना चाहिए।

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C++ में इन संग्रहों तक पहुँचते समय इंडेक्स शून्य‑आधारित होता है: `idx_get(0)` पहला संग्रहीत शैली है और `idx_get(2)` तीसरा। आकृति का शैली‑संदर्भ इंडेक्स एक अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली को बदलने से उन आकृतियों पर प्रभाव पड़ता है जो उस शैली को संदर्भित करती हैं; सीधे फ़ॉर्मेट की गई आकृतियाँ अपरिवर्तित रह सकती हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
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
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

इन स्लॉटों को संदर्भित करने वाली आकृतियों के लिए पहली थीम रेखा शैली लाल हो जाती है, तीसरी थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन हो जाती है, और तीसरी प्रभाव शैली को 10 पॉइंट दूरी के साथ बाहरी छाया मिलती है। सटीक दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकृति किन शैली स्लॉट को संदर्भित करती है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड कर रही है।

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट केवल बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि वारिसी और स्थानीय ओवरराइड के बाद स्लाइड या आकृति वास्तव में क्या उपयोग करती है। स्लाइड के लिए [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) कॉल करें। पृष्ठभूमि के लिए [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) उपयोग करें, और भराव के लिए [FillFormat::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/geteffective/)।

निम्न उदाहरण स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहले आकृति भराव को पढ़ता है:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

रेंडरिंग डायग्नोस्टिक्स, वैधता और तुलना के लिए प्रभावी डेटा उपयोग करें। यदि आप केवल [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/) को निरीक्षण करते हैं, तो आप मास्टर, लेआउट, स्लाइड या आकृति ओवरराइड को छूट सकते हैं जो अंतिम स्वरूप को बदलते हैं।

## **FAQ**

**क्या बाहरी थीम लागू करने से प्रस्तुति की प्रत्येक स्लाइड प्रभावित होती है?**

नहीं। [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) केवल उन स्लाइड्स को पुनः‑सौंपता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों का उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम बनाए रखती हैं।

**क्या मैं मास्टर बदलें बिना किसी एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के [IOverrideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/) का उपयोग करके उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में जारी रखेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब एक स्लाइड को ले जा रहे हों और उसके स्रोत स्वरूप को बनाए रखना चाहें, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर स्लाइड को उसी मास्टर के साथ क्लोन करें, जैसा कि [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) और [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) से किया जाता है। इससे मास्टर, लेआउट और थीम एक साथ रखी जाती हैं।

**वारिसी और ओवरराइड के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिए [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट जैसे [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) तथा [FillFormat::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/geteffective/) के संबंधित प्रभावी‑डेटा मेथड का प्रयोग करें। ये API वारिसी और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।