---
title: C++ में प्रेज़ेंटेशन थीम प्रबंधित करें
linktitle: प्रेज़ेंटेशन थीम
type: docs
weight: 10
url: /hi/cpp/presentation-theme/
keywords:
- PowerPoint थीम
- प्रेज़ेंटेशन थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- C++
- Aspose.Slides
description: "C++ के लिए Aspose.Slides में प्रेज़ेंटेशन थीम को मास्टर करके, निरंतर ब्रांडिंग के साथ PowerPoint फ़ाइलों को बनाएं, कस्टमाइज़ करें और कनवर्ट करें।"
---
## **परिचय**

एक प्रेज़ेंटेशन थीम रंगों, फ़ॉन्ट्स, बैकग्राउंड शैलियों, फ़िल्स, लाइनों और इफ़ेक्ट्स का एक समन्वित सेट निर्धारित करता है। थीम‑समझदार ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि हर दृश्य गुण को स्थिर मान के रूप में संग्रहीत करते हैं, इसलिए थीम में बदलाव कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में प्रेज़ेंटेशन‑स्तर की थीम [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/) के माध्यम से उपलब्ध है। एक प्रेज़ेंटेशन में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) से प्रेज़ेंटेशन थीम को ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) का उपयोग कर सकते हैं। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला से निर्धारित होती है: प्रेज़ेंटेशन थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, बैकग्राउंड शैलियाँ, और इफ़ेक्ट्स](theme-constituents.png)

नीचे के सेक्शन्स सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, बैकग्राउंड और इफ़ेक्ट शैलियों को अपडेट करना, तथा विरासत और ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण**

[MasterTheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [get_ColorScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), और [get_FormatScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) मेथड्स को उजागर करता है। इन संग्रहों को बदलने से पहले निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रेज़ेंटेशन बाहरी स्रोत से आता है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन, और इफ़ेक्ट शैलियाँ संग्रहीत हैं:

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

यदि फ़ाइल कई मास्टर उपयोग करती है, तो यह मान न रखें कि प्रत्येक स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हों तो इस लेख के बाद दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑समझदार फ़िल्स, लाइन्स, और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग का संदर्भ ले सकते हैं। जब आप थीम के [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित कर रहे हैं, नया मान ले लेते हैं। सीधे RGB रंग उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रेज़ेंटेशन सहेजता है, फिर उसे पुनः खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `Accent4` में किए गए परिवर्तन उस फ़िल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट बनाता है रंग रूपांतरण लागू करके। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/colortransformoperation/) के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के तथा गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।  
**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम सहेजता है:

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

ये वैरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करती है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) वही थीम स्लॉट `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; इन्हें एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित नहीं किया जाता।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होता है। [FontScheme::get_Major()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_major/) और [FontScheme::get_Minor()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_minor/) मेथड्स इन सेट्स को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj‑lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj‑ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट को फ़ॉलो करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट को। जिस टेक्स्ट में स्पष्ट फ़ॉन्ट नाम थीम पहचानकर्ता के बजाय दिया गया है, वह थीम फ़ॉन्ट स्कीम बदलने पर स्वचालित रूप से नहीं बदलेगा।

मुख्य और गौण फ़ॉन्ट संग्रह व्यक्तिगत लेखन प्रणाली, जैसे Cyrillic, Arabic, Japanese, Georgian, और Thaana के लिए फ़ॉन्ट मैपिंग भी रख सकते हैं। इन मैपिंग को निरीक्षण, जोड़ना, बदलना या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/cpp/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रेज़ेंटेशन फ़ॉन्ट्स के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/cpp/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

दो सामान्य कार्यप्रवाह होते हैं, और वे अलग समस्याओं को हल करते हैं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप स्लाइड को किसी अन्य प्रेज़ेंटेशन में ले जाना चाहते हैं और उसकी मूल डिज़ाइन को बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रेज़ेंटेशन में [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) से क्लोन करें, फिर स्लाइड को [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) और क्लोन किए गए मास्टर के साथ क्लोन करें। यह मास्टर, उसके लेआउट, और संबंधित थीम को साथ ले जाता है।

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

जब स्रोत स्लाइड को लक्ष्य में वैसा ही दिखना हो, तो यह पसंदीदा कार्यप्रवाह है। अनभिज़ी लक्ष्य मास्टर पर सामग्री क्लोन करने से थीम‑ड्रिवेन रंग, फ़ॉन्ट, बैकग्राउंड और इफ़ेक्ट बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर का ओवरराइड प्रारंभ करें। [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), और [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह उस स्लाइड के द्वारा उपयोग की गई थीम को बदलता है जबकि अन्य स्लाइड्स की विरासत वाली थीम नहीं बदलता। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिए [OverrideTheme::Clear()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/clear/) कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर का ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि विशेष स्लाइड का अपना ओवरराइड न हो। वही प्रारंभिक मेथड्स लेआउट की [IOverrideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

जब कई लेआउट और स्लाइड एक ही बेस डिज़ाइन साझा करनी चाहिए तो मास्टर या प्रेज़ेंटेशन‑स्तर की थीम उपयोग करें, एक लेआउट परिवार को अलग स्टाइलिंग चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइट इस्तेमाल करें। अत्यधिक स्लाइड‑स्तर ओवरराइड्स बाद के वैश्विक थीम परिवर्तन को अनुमान लगाना कठिन बना देते हैं।

## **थीम बैकग्राउंड शैलियों को अपडेट करें**

थीम की बैकग्राउंड फ़िल्स [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) में संग्रहीत होती हैं। PowerPoint अपनी UI में अधिक बैकग्राउंड विकल्प प्रस्तुत कर सकता है क्योंकि UI थीम फ़िल्स को थीम रंगों और अन्य शैली संदर्भों के साथ मिलाकर दिखा सकता है।

![PowerPoint बैकग्राउंड शैली गैलरी प्रेज़ेंटेशन थीम के लिए](presentation-design_8.png)

बैकग्राउंड शैली उपयोग करने से पहले संग्रहीत संग्रह और वर्तमान [Background::get_StyleIndex()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/get_styleindex/) को निरीक्षण करें। `StyleIndex` `0` को थीम‑फ़िल न होने के रूप में उपयोग करता है; सकारात्मक मान थीम बैकग्राउंड‑स्टाइल संदर्भ होते हैं। यह C++ संग्रह को सीधे `idx_get(0)` से इंडेक्स करने से अलग है, जहाँ `0` पहला संग्रहीत आइटम दर्शाता है। यह मान न रखें कि प्रत्येक प्रेज़ेंटेशन में समान संख्या में बैकग्राउंड फ़िल शैलियाँ होंगी।

निम्न उदाहरण उपलब्ध बैकग्राउंड फ़िल गिनती रिपोर्ट करता है, पहले मास्टर को थीमेटिक बैकग्राउंड संदर्भ असाइन करता है, और प्रेज़ेंटेशन सहेजता है:

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

दिखाया गया परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदलेगी। अंतिम बैकग्राउंड जानने के लिए जब विरासत लागू हो चुकी हो, तब [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`StyleIndex` को शून्य‑आधारित संग्रह इंडेक्स न समझें। किसी फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरी फ़ाइल में समान उपस्थिति मान लेना भी न करें; थीम शैली परिभाषाएँ प्रेज़ेंटेशन‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
प्रत्यक्ष बैकग्राउंड फ़ॉर्मेटिंग और बैकग्राउंड विरासत के लिए देखें [Presentation Background](/slides/hi/cpp/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट्स को अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_linestyles/), और [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) संग्रह होते हैं। सामान्य Office थीम अक्सर तीन मुख्य शैली प्रविष्टियों को शामिल करती हैं जो दृश्य रूप से Subtle, Moderate, और Intense फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि निश्चित गिनती मान लेना चाहिए।

![एक ही आकार पर लागू Subtle, Moderate, और Intense थीम इफ़ेक्ट्स](presentation-design_10.png)

जब आप C++ में इन संग्रहों तक पहुँचते हैं, तो संग्रह इंडेक्स शून्य‑आधारित होता है: `idx_get(0)` पहला संग्रहीत शैली है और `idx_get(2)` तीसरा है। आकार की शैली‑संदर्भ इंडेक्स अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapestyle/) द्वारा उजागर किया जाता है। थीम शैली को संशोधित करने से उन आकारों पर असर पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेट किए गए आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, पहला लाइन शैली बदलता है, तीसरा फ़िल शैली बदलता है, तीसरी इफ़ेक्ट शैली में बाहरी शैडो सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिए, पहला थीम लाइन शैली लाल हो जाता है, तीसरा थीम फ़िल शैली ठोस फॉरेस्ट ग्रीन, और तीसरी इफ़ेक्ट शैली 10 पॉइंट दूरी के साथ बाहरी शैडो प्राप्त करती है। अंतिम दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकार कौन-से शैली स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, फ़िल, और शैडो सेटिंग्स बदलने के बाद थीम इफ़ेक्ट शैलियाँ](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड के बाद स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिए, [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) कॉल करें। बैकग्राउंड के लिए, [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) और फ़िल के लिए, [FillFormat::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/geteffective/) उपयोग करें।

निम्न उदाहरण स्लाइड से प्रभावी थीम, बैकग्राउंड, और पहली आकार फ़िल पढ़ता है:

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

रेंडरिंग डायग्नॉस्टिक्स, वैलिडेशन, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/) का निरीक्षण करते हैं, तो आप मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को चूक सकते हैं जो अंतिम उपस्थिति बदलते हैं।

## **FAQ**

**क्या मैं एकल स्लाइड पर थीम लागू कर सकता हूँ बिना मास्टर बदले?**

हां। स्लाइड के [IOverrideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/) का उपयोग करके उसके ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम विरासत में लेते रहेंगी।

**एक थीम को एक प्रेज़ेंटेशन से दूसरे में ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को स्थानांतरित कर रहे हों और उसकी स्रोत उपस्थिति को संरक्षित रखना चाहते हों, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) और [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) से क्लोन करें। यह मास्टर, लेआउट, और थीम को साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिए [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) और फ़ॉर्मेट ऑब्जेक्ट जैसे [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) और [FillFormat::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/geteffective/) के संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद समाधान किए हुए मान लौटाते हैं।