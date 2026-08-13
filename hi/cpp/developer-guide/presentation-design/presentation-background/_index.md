---
title: C++ में प्रस्तुति बैकग्राउंड प्रबंधित करें
linktitle: स्लाइड बैकग्राउंड
type: docs
weight: 20
url: /hi/cpp/presentation-background/
keywords:
- प्रस्तुति बैकग्राउंड
- स्लाइड बैकग्राउंड
- सॉलिड रंग
- ग्रेडिएंट रंग
- छवि बैकग्राउंड
- बैकग्राउंड पारदर्शिता
- बैकग्राउंड गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील बैकग्राउंड सेट करना सीखें, तथा अपने प्रस्तुतियों को बेहतर बनाने के लिए कोड टिप्स प्राप्त करें।
---
## **परिचय**

सॉलिड रंग, ग्रेडिएंट और छवियों का अक्सर स्लाइड बैकग्राउंड के रूप में उपयोग किया जाता है। आप **सामान्य स्लाइड** (एकल स्लाइड) या **मास्टर स्लाइड** (जो एक साथ कई स्लाइड पर लागू होती है) के लिए बैकग्राउंड सेट कर सकते हैं।

![PowerPoint background](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग बैकग्राउंड सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड के लिए सॉलिड रंग को बैकग्राउंड के रूप में सेट करने की सुविधा देता है—भले ही प्रस्तुति में मास्टर स्लाइड उपयोग हो। यह परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड बैकग्राउंड के [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Solid` सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/) पर [get_SolidFillColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/get_solidfillcolor/) मेथड का उपयोग करके सॉलिड बैकग्राउंड रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सेव करें।

निम्नलिखित C++ उदाहरण दिखाता है कि सामान्य स्लाइड के लिए नीला सॉलिड रंग कैसे सेट करें:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation वर्ग का एक इंस्टेंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// स्लाइड की पृष्ठभूमि रंग को नीला सेट करें।
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// प्रस्तुति को डिस्क पर सहेजें।
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **मास्टर स्लाइड के लिए सॉलिड रंग बैकग्राउंड सेट करें**

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड के लिए सॉलिड रंग को बैकग्राउंड के रूप में सेट करने की अनुमति देता है। मास्टर स्लाइड सभी स्लाइड के फ़ॉर्मेटिंग को नियंत्रित करने वाला टेम्पलेट होती है, इसलिए जब आप मास्टर स्लाइड के बैकग्राउंड के लिए सॉलिड रंग चुनते हैं, तो वह प्रत्येक स्लाइड पर लागू हो जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. मास्टर स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/backgroundtype/) को (`get_Masters` के माध्यम से) `OwnBackground` सेट करें।
3. मास्टर स्लाइड बैकग्राउंड के [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Solid` सेट करें।
4. सॉलिड बैकग्राउंड रंग निर्दिष्ट करने के लिए [get_SolidFillColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/get_solidfillcolor/) मेथड का उपयोग करें।
5. संशोधित प्रस्तुति को सेव करें।

निम्नलिखित C++ उदाहरण दिखाता है कि मास्टर स्लाइड के लिए फॉरेस्ट ग्रीन सॉलिड रंग कैसे सेट करें:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation क्लास का एक इंस्टेंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// मास्टर स्लाइड की पृष्ठभूमि रंग को फ़ॉरेस्ट ग्रीन सेट करें।
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// प्रस्तुति को डिस्क पर सहेजें।
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **स्लाइड के लिए ग्रेडिएंट बैकग्राउंड सेट करें**

ग्रेडिएंट एक ग्राफिकल प्रभाव है जो रंग के धीरज परिवर्तन से बनता है। जब इसे स्लाइड बैकग्राउंड के रूप में उपयोग किया जाता है, तो ग्रेडिएंट प्रस्तुति को अधिक कलात्मक और पेशेवर दिखा सकते हैं। Aspose.Slides आपको स्लाइड के लिए ग्रेडिएंट रंग को बैकग्राउंड के रूप में सेट करने की सुविधा देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड बैकग्राउंड के [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Gradient` सेट करें।
4. अपनी पसंद के ग्रेडिएंट सेटिंग को कॉन्फ़िगर करने के लिए [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/) पर [get_GradientFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/get_gradientformat/) मेथड का उपयोग करें।
5. संशोधित प्रस्तुति को सेव करें।

निम्नलिखित C++ उदाहरण दिखाता है कि स्लाइड के लिए ग्रेडिएंट रंग कैसे सेट करें:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation वर्ग का एक इंस्टेंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// पृष्ठभूमि पर ग्रेडिएंट इफ़ेक्ट लागू करें।
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// प्रस्तुति को डिस्क पर सहेजें।
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **स्लाइड बैकग्राउंड के रूप में छवि सेट करें**

सॉलिड और ग्रेडिएंट फ़िल के अलावा, Aspose.Slides आपको स्लाइड बैकग्राउंड के रूप में छवियों का उपयोग करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड बैकग्राउंड के [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Picture` सेट करें।
4. वह छवि लोड करें जिसे आप स्लाइड बैकग्राउंड के रूप में उपयोग करना चाहते हैं।
5. छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/) पर [get_PictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/get_picturefillformat/) मेथड का उपयोग करके छवि को बैकग्राउंड के रूप में असाइन करें।
7. संशोधित प्रस्तुति को सेव करें।

निम्नलिखित C++ उदाहरण दिखाता है कि स्लाइड के बैकग्राउंड के रूप में छवि कैसे सेट करें:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation वर्ग का एक इंस्टेंस बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// पृष्ठभूमि छवि गुण सेट करें।
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// छवि लोड करें।
auto image = Images::FromFile(u"Tulips.jpg");
// छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// प्रस्तुति को डिस्क पर सहेजें।
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

निम्न कोड नमूना दिखाता है कि बैकग्राउंड फ़िल टाइप को टाइल्ड पिक्चर पर सेट करें और टाइलिंग गुणों को संशोधित करें:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}

और पढ़ें: [**Tile Picture As Texture**](/slides/hi/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **बैकग्राउंड इमेज की ट्रांसपेरेंसी बदलें**

आप स्लाइड की बैकग्राउंड इमेज की ट्रांसपेरेंसी को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री अधिक उभरे। निम्नलिखित C++ कोड दिखाता है कि स्लाइड बैकग्राउंड इमेज की ट्रांसपेरेंसी कैसे बदलें:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // उदाहरण के लिए।

// Presentation वर्ग का एक इंस्टेंस बनाएं।
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// चित्र ट्रांसफ़ॉर्म ऑपरेशन्स का संग्रह प्राप्त करें।
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// मौजूदा निश्चित-प्रति-शतांश पारदर्शिता प्रभाव खोजें।
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// नया पारदर्शिता मान सेट करें।
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// प्रस्तुति को डिस्क पर सहेजें।
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **स्लाइड बैकग्राउंड मान प्राप्त करें**

Aspose.Slides एक [IBackgroundEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibackgroundeffectivedata/) इंटरफ़ेस प्रदान करता है जो स्लाइड के प्रभावी बैकग्राउंड मानों को प्राप्त करने के लिए उपयोग किया जाता है। यह इंटरफ़ेस प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) और [EffectFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) को उजागर करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseslide/) क्लास के `get_Background` मेथड का उपयोग करके, आप स्लाइड के प्रभावी बैकग्राउंड को प्राप्त कर सकते हैं।

निम्नलिखित C++ उदाहरण दिखाता है कि स्लाइड के प्रभावी बैकग्राउंड मान को कैसे प्राप्त करें:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Presentation वर्ग का एक इंस्टेंस बनाएं।
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं कस्टम बैकग्राउंड रीसेट करके थीम/लेआउट बैकग्राउंड को पुनर्स्थापित कर सकता हूँ?

हां। स्लाइड की कस्टम फ़िल को हटाएँ, और बैकग्राउंड फिर से संबंधित [layout](/slides/hi/cpp/slide-layout/)/[master](/slides/hi/cpp/slide-master/) स्लाइड (अर्थात् [theme background](/slides/hi/cpp/presentation-theme/)) से विरासत में मिल जाएगा।

### यदि मैं बाद में प्रस्तुति का थीम बदलूँ तो बैकग्राउंड पर क्या प्रभाव पड़ेगा?

यदि स्लाइड की अपनी फ़िल है, तो वह अपरिवर्तित रहेगी। यदि बैकग्राउंड [layout](/slides/hi/cpp/slide-layout/)/[master](/slides/hi/cpp/slide-master/) से विरासत में मिला है, तो वह नया थीम के अनुसार अपडेट हो जाएगा।