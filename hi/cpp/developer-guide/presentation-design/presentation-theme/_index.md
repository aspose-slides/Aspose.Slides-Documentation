---
title: C++ में प्रेजेंटेशन थीम प्रबंधित करें
linktitle: प्रेजेंटेशन थीम
type: docs
weight: 10
url: /hi/cpp/presentation-theme/
keywords:
- PowerPoint थीम
- प्रेजेंटेशन थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधन
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "C++ के लिए Aspose.Slides में मुख्य प्रेजेंटेशन थीम्स ताकि PowerPoint फ़ाइलों को लगातार ब्रांडिंग के साथ बनाया, अनुकूलित और परिवर्तित किया जा सके।"
---
## **परिचय**

एक प्रेजेंटेशन थीम रंगों, फ़ॉन्ट्स, बैकग्राउंड स्टाइल्स, फ़िल्स, लाइन्स और इफ़ेक्ट्स का समन्वित सेट परिभाषित करती है। थीम‑जागरूक ऑब्जेक्ट्स इन साझा परिभाषाओं का संदर्भ लेते हैं और प्रत्येक विज़ुअल प्रॉपर्टी को स्थिर मान के रूप में नहीं रखते, इसलिए थीम बदलने से कई ऑब्जेक्ट्स एक साथ अपडेट हो सकते हैं।

Aspose.Slides में, प्रेजेंटेशन‑लेवल थीम प्रोवाइड की जाती है [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/). प्रेजेंटेशन में निचले लेवल पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) के माध्यम से प्रेजेंटेशन थीम को ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) का उपयोग कर सकती है। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस इनहेरिटेंस चेन के माध्यम से निर्धारित होती है: प्रेजेंटेशन थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

नीचे के सेक्शन सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, बैकग्राउंड और इफ़ेक्ट स्टाइल्स को अपडेट करना, और इनहेरिटेंस व ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [get_ColorScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), और [get_FormatScheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) मेथड्स को उजागर करता है। इन कलेक्शनों को बदलने से पहले उनका निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रेजेंटेशन बाहरी स्रोत से आया हो क्योंकि स्टाइल एंट्रीज़ की संख्या और सामग्री अलग हो सकती है।

निम्न उदाहरण मुख्य थीम प्रॉपर्टीज़ को पढ़ता है और रिपोर्ट करता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन और इफ़ेक्ट स्टाइल्स संग्रहीत हैं:

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

यदि फ़ाइल में कई मास्टर का उपयोग किया गया है, तो यह न मानें कि हर स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम के रंग बदलें**

थीम‑जागरूक फ़िल्स, लाइन्स और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) एन्ह्यूमरेशन से एक लॉजिकल रंग का संदर्भ ले सकते हैं। जब आप थीम के [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) में संबंधित एंट्री बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग का संदर्भ ले रहे हैं, नए मान के अनुसार रेजॉल्व हो जाते हैं। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑कलर अपडेट से नहीं बदलते।

निम्न अंत‑से‑अंत उदाहरण एक शैप बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रेजेंटेशन को सेव करता है, उसे फिर से खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी हुई है, थीम बदलने के बाद उसका दृश्य रंग लाल हो जाता है। यदि आप शैप पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `Accent4` में बदलाव उस फ़िल को प्रभावित नहीं करेंगे।

### **एडिशनल पैलेट से रंग उपयोग करें**

PowerPoint एक थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करता है रंग ट्रांसफ़ॉर्मेशन लागू करके। Aspose.Slides इन ट्रांसफ़ॉर्मेशन को [ColorTransformOperation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/colortransformoperation/) के माध्यम से उजागर करता है।

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस ट्रांसफ़ॉर्मेशन लागू करता है, और परिणाम सेव करता है:

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

ये वैरिएंट थीम रंग पर आधारित ही रहते हैं। यदि बाद में `Accent4` बदलता है, तो ट्रांसफ़ॉर्म किया गया रंग नए `accent4` मान से पुनः गणना किया जाएगा।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/schemecolor/) एन्ह्यूमरेशन `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/icolorscheme/) समान थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये एक ही थीम स्लॉट के वैकल्पिक नाम हैं; ये किसी रूपांतरण का परिणाम नहीं हैं।

## **थीम के फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग्स के लिए एक मेजर फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए एक माइनर फ़ॉन्ट सेट होता है। [FontScheme::get_Major()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_major/) और [FontScheme::get_Minor()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/fontscheme/get_minor/) मेथड्स इन सेट्स को उजागर करते हैं।

PowerPoint‑अनुपालन थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो मेजर लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो माइनर लैटिन थीम फ़ॉन्ट का, फिर थीम फ़ॉन्ट बदलता है और परिणाम सेव करता है:

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

हेडिंग मेजर फ़ॉन्ट को फॉलो करती है और बॉडी टेक्स्ट माइनर फ़ॉन्ट को। यदि टेक्स्ट में स्पष्ट फ़ॉन्ट नाम थीम पहचानकर्ता के बजाय दिया गया है, तो थीम फ़ॉन्ट स्कीम बदलने पर वह स्वचालित रूप से स्विच नहीं करेगा।

{{% alert color="info" title="Tip" %}}
प्रेजेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/cpp/powerpoint-fonts/)।
{{% /alert %}}

## **थीम को कॉपी या लागू करें**

दो सामान्य कार्यप्रवाह होते हैं, और वे अलग‑अलग समस्याओं को हल करते हैं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप स्लाइड को किसी अन्य प्रेजेंटेशन में ले जाना चाहते हैं और उसका मूल डिज़ाइन बनाए रखना चाहते हैं, तो स्रोत मास्टर को टारगेट प्रेजेंटेशन में [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) से क्लोन करें, फिर स्लाइड को [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) और क्लोन किए गए मास्टर से क्लोन करें। इससे मास्टर, उसके लेआउट्स, और संबंधित थीम एक साथ स्थानांतरित होते हैं।

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

यह वह पसंदीदा कार्यप्रवाह है जब स्रोत स्लाइड को गंतव्य में वही दिखना चाहिए। केवल कंटेंट को एक असंबंधित डेस्टिनेशन मास्टर पर क्लोन करने से थीम‑ड्रिवन रंग, फ़ॉन्ट, बैकग्राउंड और इफ़ेक्ट बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम वैल्यूज़ लागू करें**

यदि टारगेट स्लाइड को उसके वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑लेवल ओवरराइड इनिशियलाइज़ करें। [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), और [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) मेथड्स तीन मुख्य थीम कॉम्पोनेन्ट्स को ओवरराइड में कॉपी करते हैं।

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

यह स्लाइड द्वारा उपयोग की गई थीम को बदलता है बिना अन्य स्लाइड्स की इनहेरिटेड थीम को बदले। स्थानीय ओवरराइड हटाकर इनहेरिटेड वैल्यूज़ पर वापस आने के लिए [OverrideTheme::Clear()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/overridetheme/clear/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑लेवल ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट को उपयोग करती हैं, जब तक कि किसी विशेष स्लाइड के पास अपना ओवरराइड न हो। समान इनिशियलाइज़ेशन मेथड्स लेआउट के [IOverrideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

जब कई लेआउट और स्लाइड्स को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रेजेंटेशन‑लेवल थीम का उपयोग करें, एक लेआउट फैमिली को अलग स्टाइलिंग चाहिए तो लेआउट ओवरराइड, और वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑लेवल ओवरराइड्स बाद के ग्लोबल थीम बदलावों को अनुमान लगाना कठिन बना देते हैं।

## **थीम बैकग्राउंड स्टाइल्स को अपडेट करें**

थीम के बैकग्राउंड फ़िल्स [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) में संग्रहीत होते हैं। PowerPoint UI में अधिक बैकग्राउंड विकल्प दिखा सकता है क्योंकि UI थीम फ़िल्स को थीम रंगों और अन्य स्टाइल रेफ़रेंसेज़ के साथ संयोजित कर सकता है।

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

बैकग्राउंड स्टाइल उपयोग करने से पहले स्टोर्ड कलेक्शन और वर्तमान [Background::get_StyleIndex()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/get_styleindex/) की जाँच करें। `StyleIndex` शून्य (`0`) का उपयोग करता है जब कोई थीम्ड फ़िल नहीं है; पॉज़िटिव मान थीम बैकग्राउंड‑स्टाइल रेफ़रेंसेज़ होते हैं। यह C++ कलेक्शन के `idx_get(0)` से अलग है जहाँ `0` पहला स्टोर्ड आइटम दर्शाता है। यह न मानें कि हर प्रेजेंटेशन में समान संख्या में बैकग्राउंड फ़िल स्टाइल्स होते हैं।

निम्न उदाहरण उपलब्ध बैकग्राउंड फ़िल काउंट रिपोर्ट करता है, पहले मास्टर को एक थीम्ड बैकग्राउंड रेफ़रेंस असाइन करता है, और प्रेजेंटेशन को सेव करता है:

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

विज़िबल परिणाम मास्टर द्वारा रेफ़र किए गए थीम एंट्री और लेआउट या स्लाइड लेवल पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड अपना स्वयं का बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदलेगी। जब आपको इनहेरिटेंस लागू होने के बाद अंतिम बैकग्राउंड जानना हो तो [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`StyleIndex` को शून्य‑आधारित कलेक्शन इंडेक्स न समझें। साथ ही किसी एक फ़ाइल से स्टाइल नंबर हार्ड‑कोड न करें और मान न लें कि वह दूसरे फ़ाइल में समान दिखेगा; थीम स्टाइल डिफ़िनिशन प्रेजेंटेशन‑स्पेसिफिक होते हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे बैकग्राउंड फ़ॉर्मैटिंग और बैकग्राउंड इनहेरिटेंस के लिए देखें [Presentation Background](/slides/hi/cpp/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट्स को अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_linestyles/), और [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) कलेक्शन होते हैं। सामान्य Office थीम में अक्सर तीन प्रमुख स्टाइल एंट्रीज़ होती हैं जो दृश्य रूप से Subtle, Moderate, और Intense फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक कलेक्शन की जाँच करनी चाहिए न कि निश्चित काउंट मान लेना चाहिए।

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

जब आप इन कलेक्शनों को C++ में एक्सेस करते हैं, तो कलेक्शन इंडेक्स ज़ीरो‑बेस्ड होता है: `idx_get(0)` पहला स्टोर्ड स्टाइल है और `idx_get(2)` तीसरा। एक शैप के स्टाइल‑रेफ़रेंस इंडेक्सेस एक अलग अवधारणा हैं, जो [IShapeStyle](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapestyle/) द्वारा उजागर होते हैं। थीम स्टाइल को बदलने से उन शैप्स पर असर पड़ता है जो उस थीम स्टाइल का रेफ़रेंस रखते हैं; सीधे फ़ॉर्मैट किए गए शैप्स अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक स्टाइल एंट्रीज़ मौजूद हैं, पहला लाइन स्टाइल बदलता है, तीसरा फ़िल स्टाइल बदलता है, तीसरे इफ़ेक्ट स्टाइल में आउटर शैडो सक्षम करता है, और परिणाम सेव करता है:

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

इन स्लॉट्स को रेफ़र करने वाले शैप्स के लिए पहला थीम लाइन स्टाइल लाल हो जाता है, तीसरा थीम फ़िल स्टाइल ठोस फ़ॉरेस्ट ग्रीन, और तीसरा इफ़ेक्ट स्टाइल 10 पॉइंट डिस्टेंस के साथ आउटर शैडो प्राप्त करता है। सटीक दृश्य परिणाम इस बात पर अभी भी निर्भर करता है कि प्रत्येक शैप कौन सा स्लॉट रेफ़र करता है और क्या सीधे फ़ॉर्मैटिंग थीम को ओवरराइड करती है।

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **प्रभावी थीम वैल्यूज़ पढ़ें**

रॉ थीम ऑब्जेक्ट आपको बताता है कि किसी विशेष लेवल पर क्या परिभाषित है। प्रभावी वैल्यूज़ आपको बताती हैं कि स्लाइड या शैप वास्तव में इनहेरिटेंस और स्थानीय ओवरराइड के बाद क्या उपयोग कर रहा है। स्लाइड के लिए [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) कॉल करें। बैकग्राउंड के लिए [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) उपयोग करें, और फ़िल के लिए [FillFormat::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/geteffective/)।

निम्न उदाहरण स्लाइड से प्रभावी थीम, बैकग्राउंड और पहले शैप फ़िल पढ़ता है:

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

रेंडरिंग डायग्नॉस्टिक्स, वैलिडेशन और तुलना के लिए प्रभावी डेटा उपयोग करें। यदि आप केवल [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_mastertheme/) को जांचते हैं, तो आप मास्टर, लेआउट, स्लाइड या शैप ओवरराइड को मिस कर सकते हैं जो अंतिम दिखावट बदलते हैं।

## **FAQ**

**क्या मैं मास्टर को बदले बिना किसी एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के [IOverrideThemeManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ioverridethememanager/) का उपयोग करके उसके ओवरराइड थीम को इनिशियलाइज़ करें। बदलाव केवल उस स्लाइड पर स्थानीय रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम को इनहेरिट करती रहेंगी।

**एक प्रेजेंटेशन से दूसरे में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

स्लाइड को मूव करते समय और स्रोत लुक को संरक्षित रखते हुए, स्रोत मास्टर को डेस्टिनेशन में क्लोन करें और फिर स्लाइड को उस क्लोन किए हुए मास्टर के साथ [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/addclone/) और [ISlideCollection::AddClone()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) से क्लोन करें। इससे मास्टर, लेआउट और थीम साथ में रहेंगे।

**इनहेरिटेंस और ओवरराइड के बाद प्रभावी वैल्यूज़ कैसे देखें?**

स्लाइड या लेआउट थीम के लिए [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/background/geteffective/) और [FillFormat::GetEffective()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/geteffective/) के लिए संबंधित प्रभावी‑डेटा मेथड्स कॉल करें। ये API इनहेरिटेंस और ओवरराइड लागू होने के बाद प्रॉपर्टी वैल्यूज़ लौटाते हैं।