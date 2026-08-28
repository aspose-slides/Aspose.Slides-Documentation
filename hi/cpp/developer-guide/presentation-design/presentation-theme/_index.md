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
- थीम प्रबंधन
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
description: "Aspose.Slides for C++ में मुख्य प्रस्तुति थीम को बनाएँ, अनुकूलित करें तथा PowerPoint फ़ाइलों को निरंतर ब्रांडिंग के साथ परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भराव, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सचेत वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, इसलिए थीम परिवर्तन कई वस्तुओं को एक साथ अद्यतन कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम को [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/) के माध्यम से प्राप्त किया जा सकता है। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर प्रस्तुति थीम को [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) से ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) का उपयोग कर सकते हैं। वास्तविकता में, स्लाइड के लिए प्रभावी थीम इस वंशानुक्रम द्वारा निर्धारित होती है: प्रस्तुति थीम → मास्टर ओवरराइड → लेआउट ओवरराइड → स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्य‑प्रवाह दर्शाते हैं: थीम का निरीक्षण करें, रंग और फ़ॉन्ट बदलें, थीम कॉपी या लागू करें, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करें, तथा विरासत और ओवरराइड समाधान के बाद प्रभावी मान पढ़ें।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [get_ColorScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), और [get_FormatScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) मेथड्स को उजागर करता है। इन संग्रहों को बदलने से पहले उनका निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और बताता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा, और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि फ़ाइल में कई मास्टर उपयोग होते हैं, तो यह न मानें कि प्रत्येक स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़ी मास्टर को निरीक्षण करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं, तो इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्य‑प्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑सचेत भराव, रेखा, और पाठ एक तर्कसंगत रंग को संदर्भित कर सकते हैं जो [SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) एनेमरेशन में परिभाषित है। जब आप थीम के [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग को संदर्भित करती हैं, नए मान के आधार पर पुनः निर्धारित होती हैं। जो वस्तुएँ प्रत्यक्ष RGB रंग का उपयोग करती हैं, वे थीम‑रंग अपडेट से प्रभावित नहीं होतीं।

निम्न अंत‑से‑अंत उदाहरण एक आकृति बनाता है जो `Accent4` का उपयोग करती है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, फिर उसे पुनः खोलता है, और प्रभावी भराव रंग को प्रिंट करता है:

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

क्योंकि आयत अभी भी `Accent4` से जुड़ी हुई है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकृति पर योजना रंग को सीधे रंग से बदल देते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करने के लिए रंग रूपांतरण लागू करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/colortransformoperation/) के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** – मुख्य थीम रंग।  
**2** – मुख्य थीम रंगों से उत्पन्न हल्के व गहरे वैरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, पाँच पर चमक रूपांतरण लागू करता है, और परिणाम सहेजता है:

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

ये वैरिएंट अभी भी थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना होते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) एनेमरेशन `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) समान थीम स्लॉट को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये वही थीम स्लॉट के वैकल्पिक नाम हैं; ये मूल्य नहीं हैं जो एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित होते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में शीर्षकों के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए लघु फ़ॉन्ट सेट होता है। [FontScheme::get_Major()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_major/) और [FontScheme::get_Minor()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_minor/) मेथड्स इन सेटों को उजागर करते हैं।

PowerPoint‑अनुकूल थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग टेक्स्ट फॉर्मेटिंग में किया जा सकता है:

* `+mn-lt` – बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` – हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` – बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` – हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो लघु लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट लघु फ़ॉन्ट का। यदि किसी फ़ॉन्ट के लिए स्पष्ट फ़ॉन्ट नाम दिया गया है, बजाय थीम पहचानकर्ता के, तो थीम फ़ॉन्ट योजना बदलने पर वह स्वचालित रूप से नहीं बदलेगा।

प्रमुख और लघु फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणाली (जैसे Cyrillic, Arabic, Japanese, Georgian, Thaana) के लिए फ़ॉन्ट मैपिंग भी हो सकते हैं। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें: [Script‑Specific Theme Fonts](/slides/hi/cpp/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रेजेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें: [PowerPoint Fonts](/slides/hi/cpp/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

निम्न कार्य‑प्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **बाहरी थीम को मुख्य स्लाइड पर निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स की शैली बदलना चाहते हों, तो [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) का उपयोग करें। चयनित मास्टर को [Presentation::get_Masters](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_masters/) संग्रह से लें, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/) को लागू करता है, और विधि को थीम फ़ाइल पथ पास करें।

विधि निम्न कार्य करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाती है।  
1. बाहरी थीम को नए मास्टर पर लागू करती है।  
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर को सौंपती है।  
1. नया निर्मित [IMasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/) लौटाती है।

निम्न उदाहरण पहली मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति को सहेजता है:

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

अमान्य, दूषित या असमर्थित थीम से [PptxException](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pptxexception/) या उसके फ़ॉर्मेट‑संबंधी उपवर्ग उत्पन्न हो सकते हैं। उपयोगकर्ता द्वारा प्रदान किए गए पथ को मान्य करें, फ़ाइल‑सिस्टम एक्सेस त्रुटियों को संभालें, और केवल तभी प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल वही स्लाइड्स पुनः असाइन की जाती हैं जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर से जुड़ी स्लाइड्स अपने मौजूदा मास्टर और थीम को बरकरार रखती हैं। थीम‑सचेत रंग, फ़ॉन्ट, भराव, रेखा, पृष्ठभूमि, और प्रभाव बाहरी थीम के विरुद्ध निर्धारित होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, भराव आदि अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर के ओवरराइड नए मास्टर से विरासत में मिली शैलियों पर भी श्रेष्ठ हो सकते हैं।

थीम ऐसे फ़ॉन्ट को संदर्भित कर सकती है जो रन‑टाइम वातावरण में उपलब्ध नहीं हैं। निरंतर रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/cpp/custom-font/) के माध्यम से प्रदान करें, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/cpp/font-substitution/) कॉन्फ़िगर करें।

यह सीधा मास्टर‑स्तर कार्य‑प्रवाह है: विधि एक `.thmx` फ़ाइल पथ लेती है और स्लाइड‑स्तर या लेआउट‑स्तर के थीम ओवरराइड को मैन्युअली बनाने की आवश्यकता नहीं है।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर पूर्वनिर्धारित न हो, तो उसे किसी प्रतिनिधि स्लाइड से [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/get_layoutslide/) और [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilayoutslide/get_masterslide/) के माध्यम से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत करें, क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाती है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स से उनके मास्टर खोजता है और प्रत्येक समूह पर अलग‑अलग बाहरी थीम लागू करता है:

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

पहला कॉल केवल `firstGroupMaster` पर निर्भर स्लाइड्स को प्रभावित करता है, और दूसरा कॉल केवल `secondGroupMaster` पर निर्भर स्लाइड्स को। अन्य किसी मास्टर से जुड़ी स्लाइड्स को शैली नहीं बदली जाती।

### **स्लाइड को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप स्लाइड को किसी अन्य प्रस्तुति में ले जाना चाहते हैं और उसके मूल डिज़ाइन को बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) से क्लोन करें, फिर उस क्लोन किए गए मास्टर के साथ [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) से स्लाइड क्लोन करें। यह मास्टर, उसके लेआउट और संबंधित थीम को साथ में ले जाता है।

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

यह वह पसंदीदा कार्य‑प्रवाह है जब स्रोत स्लाइड को लक्ष्य में बिल्कुल समान दिखना आवश्यक हो। केवल सामग्री को किसी असंबद्ध लक्ष्य मास्टर पर क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपना मौजूदा मास्टर और लेआउट बनाए रखना हो, तो स्रोत थीम से स्लाइड‑स्तर का ओवरराइड प्रारम्भ करें। [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), और [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) मेथड तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह अन्य स्लाइड्स की विरासतित थीम को बदले बिना केवल उस स्लाइड की थीम बदलता है। स्थानीय ओवरराइड को हटाकर विरासतित मानों पर लौटने के लिए [OverrideTheme::Clear()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/clear/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर का ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपना स्वयं का ओवरराइड न रखे। वही प्रारम्भिक मेथड लेआउट के [IOverrideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

जब कई लेआउट और स्लाइड एक ही बेस डिज़ाइन साझा करनी चाहिए, तो मास्टर या प्रस्तुति‑स्तर की थीम उपयोग करें; जब किसी लेआउट परिवार को अलग शैली चाहिए, तो लेआउट ओवरराइड उपयोग करें; और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड भविष्य में वैश्विक थीम परिवर्तन को भविष्यवाणी करने में कठिनाई पैदा करते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) में संग्रहीत रहती हैं। PowerPoint UI में अधिक पृष्ठभूमि विकल्प दिखा सकता है क्योंकि UI थीम भराव को थीम रंगों और अन्य शैली संदर्भों के साथ मिलाकर दिखाता है।

![प्रेजेंटेशन थीम के लिए PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली प्रयोग करने से पहले, संग्रह और वर्तमान [Background::get_StyleIndex()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/get_styleindex/) को निरीक्षण करें। `StyleIndex` `0` को “कोई थीम भराव नहीं” के रूप में उपयोग करता है; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह `idx_get(0)` से अलग है, जहाँ `0` प्रथम संग्रहीत आइटम को दर्शाता है। न मानें कि प्रत्येक प्रस्तुति में पृष्ठभूमि भराव शैलियों की समान संख्या है।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, पहले मास्टर को थीम‑बैकग्राउंड संदर्भ असाइन करता है, और प्रस्तुति सहेजता है:

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

दिखाई देने वाला परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि कोई स्लाइड अपनी स्वयं की पृष्ठभूमि का उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। अंतिम पृष्ठभूमि जानने के लिए विरासत लागू होने पर [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`StyleIndex` को शून्य‑आधारित संग्रह सूचकांक न समझें। किसी एक फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरे फ़ाइल में समान उपस्थिति की अपेक्षा न करें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
प्रत्यक्ष पृष्ठभूमि फॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें: [Presentation Background](/slides/hi/cpp/presentation-background/)।
{{% /alert %}}

## **थीम प्रभावों को अपडेट करें**

एक थीम फ़ॉर्मेट योजना में अलग‑अलग [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_linestyles/), और [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) संग्रह होते हैं। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप से Subtle, Moderate, और Intense स्वरूपण के अनुरूप होती हैं, लेकिन कोड को प्रत्येक संग्रह को जांचना चाहिए न कि स्थिर संख्या मानना चाहिए।

![एक ही आकृति पर लागू Subtle, Moderate, और Intense थीम प्रभाव](presentation-design_10.png)

C++ में इन संग्रहों को पहुँचते समय संग्रह सूचकांक शून्य‑आधारित होता है: `idx_get(0)` प्रथम शैली है और `idx_get(2)` तृतीय। एक आकृति का शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जो [IShapeStyle](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapestyle/) द्वारा उजागर किया जाता है। थीम शैली को बदलने से उन आकृतियों पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करती हैं; सीधे फॉर्मेट किए गए आकृतियों में परिवर्तन नहीं हो सकता।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, प्रथम रेखा शैली बदलता है, तृतीय भराव शैली बदलता है, तृतीय प्रभाव शैली में बाहरी छाया सक्रिय करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाली आकृतियों के लिए, प्रथम थीम रेखा शैली लाल हो जाती है, तृतीय थीम भराव शैली सॉलिड फ़ॉरेस्ट ग्रीन हो जाती है, और तृतीय प्रभाव शैली 10 पॉइंट दूरी के साथ बाहरी छाया प्राप्त करती है। दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकृति कौन से स्लॉट संदर्भित करती है और क्या सीधे फॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, भराव, और छाया सेटिंग बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **निर्धारित करें कि प्रभावी सॉलिड भराव थीम रंग उपयोग करता है या नहीं**

एक भराव वस्तु पर सीधे संग्रहीत या पैराग्राफ, लेआउट, मास्टर, थीम शैली, या अन्य फ़ॉर्मेट स्तर से विरासत में मिला हो सकता है। इसे हल करने के लिए [IFillFormat::GetEffective](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformat/geteffective/) को कॉल करें, जो इसे अपरिवर्तनीय [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformateffectivedata/) में बदल देता है। पहले [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformateffectivedata/get_filltype/) देखें। केवल जब यह `FillType::Solid` हो, तभी सॉलिड‑भराव गुण पढ़ें।

सॉलिड भराव के लिये, [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) विरासत, थीम लुक‑अप, और रंग रूपांतरण के बाद अंतिम RGB मान लौटाता है। [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) संबंधित तर्कसंगत [SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) स्लॉट, जैसे `Text1` या `Accent6`, लौटाता है। `SchemeColor::NotDefined` का अर्थ है कि प्रभावी सॉलिड भराव योजना रंग पर आधारित नहीं है। ऐसी कार्य‑प्रवाह में जहाँ भराव थीम रंग या प्रत्यक्ष RGB रंग होते हैं, यह मान सीधे RGB भराव को पहचानता है।

स्थानीय [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icolorformat/get_schemecolor/) मान केवल उपयोग न करें वर्गीकरण के लिये। उदाहरण के लिये, किसी टेक्स्ट भाग में कोई स्थानीय योजना रंग नहीं हो सकता, इसलिए उसका स्थानीय मान `NotDefined` होगा, जबकि उसका प्रभावी भराव थीम रंग विरासत में लेकर `Text1` या `Accent6` बन सकता है। दूसरी ओर, `get_SolidFillSchemeColor` बताता है कि कौन सा तर्कसंगत थीम स्लॉट प्रभावी रंग उत्पन्न करता है, पर यह नहीं बताता कि वह स्लॉट वस्तु, पैराग्राफ, लेआउट, मास्टर, या फ़ॉर्मेट हायरेर्की के किस स्तर से आया है।

निम्न उदाहरण एक प्रस्तुति लोड करता है, दोनों आकृति भराव और टेक्स्ट‑भाग भराव का ऑडिट करता है, प्रत्येक अंतिम RGB मान और सम्बंधित योजना रंग प्रिंट करता है, और उन सॉलिड भरावों को संकेत देता है जो थीम रंग परिवर्तन को ट्रैक नहीं करेंगे:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

`NotDefined` शाखा उन सॉलिड भरावों की ऑडिट सूची प्रदान करती है जो थीम‑रंग स्लॉट में परिवर्तन पर प्रतिक्रिया नहीं देंगे। जब प्रस्तुति को नई ब्रांड पैलेट के साथ संरेखित करना हो, तो इन वस्तुओं की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान दृश्य दिखाता है, जबकि योजना मान बताता है कि वह दिखावट थीम से जुड़ी है या नहीं।

प्रभावी‑फ़ॉर्मेट वस्तुएँ स्नैपशॉट होती हैं। प्रस्तुति थीम, थीम‑ओवरराइड, या कोई भी विरासतित फ़ॉर्मेट बदलने के बाद, दोबारा `GetEffective` कॉल करें और नई `IFillFormatEffectiveData` वस्तु पढ़ें, फिर रंगों की तुलना या रिपोर्ट करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट केवल बताते हैं कि किसी स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड हल होने के बाद स्लाइड या आकृति वास्तव में क्या उपयोग करती है। स्लाइड के लिये, [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) कॉल करें। पृष्ठभूमि के लिये, [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) उपयोग करें, और भराव के लिये, [FillFormat::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/geteffective/) उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और प्रथम आकृति भराव पढ़ता है:

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

रेंडरिंग निदान, वैधता, और तुलना के लिये प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/) को निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकृति ओवरराइड को मिस कर सकते हैं जो अंतिम दृश्य को बदलता है।

## **FAQ**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**

नहीं। [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम को बरकरार रखती हैं।

**क्या मैं मास्टर बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [IOverrideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/) का उपयोग करें और उसका ओवरराइड थीम प्रारम्भ करें। परिवर्तन केवल उस स्लाइड पर स्थानीय रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में प्राप्त करती रहेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को स्थानांतरित कर उसके स्रोत रूप‑रचना को बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को क्लोन करें, इसके लिये [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) और [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) का उपयोग करें। यह मास्टर, लेआउट और थीम को साथ ले जाता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिये [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) तथा [FillFormat::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/geteffective/) के संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।