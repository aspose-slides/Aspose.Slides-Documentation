---
title: C++ में प्रस्तुति पृष्ठभूमियों का प्रबंधन
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/cpp/presentation-background/
keywords:
- प्रस्तुति पृष्ठभूमि
- स्लाइड पृष्ठभूमि
- सॉलिड रंग
- ग्रेडिएंट रंग
- छवि पृष्ठभूमि
- पृष्ठभूमि पारदर्शिता
- पृष्ठभूमि गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील पृष्ठभूमि सेट करना सीखें, साथ में कोड टिप्स जो आपकी प्रस्तुतियों को मजबूत बनाते हैं।"
---
## **परिचय**

Solid colors, gradients, and images are commonly used for slide backgrounds. You can set the background for a **सामान्य स्लाइड** (a single slide) or a **मास्टर स्लाइड** (applies to multiple slides at once).

![PowerPoint background](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग की पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड की पृष्ठभूमि के रूप में सॉलिड रंग सेट करने की अनुमति देता है—भले ही प्रस्तुति में मास्टर स्लाइड का प्रयोग हो। यह परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Solid` सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/) पर [get_SolidFillColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/get_solidfillcolor/) मेथड का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया C++ उदाहरण दिखाता है कि सामान्य स्लाइड के लिए नीला सॉलिड रंग पृष्ठभूमि के रूप में कैसे सेट करें:

```cpp
// Presentation क्लास का एक उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// स्लाइड की पृष्ठभूमि का रंग नीला सेट करें।
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// प्रस्तुति को डिस्क पर सहेजें।
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **मास्टर स्लाइड के लिए सॉलिड रंग की पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड की पृष्ठभूमि के रूप में सॉलिड रंग सेट करने की अनुमति देता है। मास्टर स्लाइड सभी स्लाइडों के फ़ॉर्मेटिंग को नियंत्रित करने वाला टेम्पलेट होता है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, तो वह हर स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. `get_Masters` के माध्यम से मास्टर स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Solid` सेट करें।
4. [get_SolidFillColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/get_solidfillcolor/) मेथड का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया C++ उदाहरण दर्शाता है कि मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग (फॉरेस्ट ग्रीन) कैसे सेट करें:

```cpp
// Presentation क्लास का एक उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// मास्टर स्लाइड की पृष्ठभूमि का रंग फॉरेस्ट ग्रीन सेट करें।
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// प्रस्तुति को डिस्क पर सहेजें।
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **स्लाइड के लिए ग्रेडिएंट पृष्ठभूमि सेट करें**

ग्रेडिएंट एक ग्राफ़िकल प्रभाव है जो रंग में धीरे‑धीरे परिवर्तन द्वारा बनता है। जब इसे स्लाइड पृष्ठभूमि के रूप में उपयोग किया जाता है, तो ग्रेडिएंट प्रस्तुति को अधिक कलात्मक और पेशेवर बना सकता है। Aspose.Slides आपको स्लाइडों की पृष्ठभूमि के रूप में ग्रेडिएंट रंग सेट करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Gradient` सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/) पर [get_GradientFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/get_gradientformat/) मेथड का उपयोग करके अपने इच्छित ग्रेडिएंट सेटिंग्स कॉन्फ़िगर करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया C++ उदाहरण दिखाता है कि स्लाइड की पृष्ठभूमि के लिए ग्रेडिएंट रंग कैसे सेट करें:

```cpp
// Presentation क्लास का एक उदाहरण बनाएं।
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

## **स्लाइड पृष्ठभूमि के रूप में छवि सेट करें**

सॉलिड और ग्रेडिएंट फिल्स के अतिरिक्त, Aspose.Slides आपको स्लाइड पृष्ठभूमि के रूप में छवियों का उपयोग करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
2. स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/) को `Picture` सेट करें।
4. स्लाइड पृष्ठभूमि के रूप में उपयोग करने हेतु छवि लोड करें।
5. छवि को प्रस्तुति के इमेज कलेक्शन में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/) पर [get_PictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fillformat/get_picturefillformat/) मेथड का उपयोग करके छवि को पृष्ठभूमि सौंपें।
7. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया C++ उदाहरण दर्शाता है कि स्लाइड की पृष्ठभूमि के रूप में छवि कैसे सेट करें:

```cpp
// Presentation क्लास का एक उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// पृष्ठभूमि छवि की गुण सेट करें।
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// छवि लोड करें।
auto image = Images::FromFile(u"Tulips.jpg");
// छवि को प्रस्तुति के इमेज कलेक्शन में जोड़ें।
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// प्रस्तुति को डिस्क पर सहेजें।
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

नीचे दिया गया कोड नमूना दिखाता है कि पृष्ठभूमि फ़िल टाइप को टाइल्ड चित्र पर कैसे सेट करें और टाइलिंग प्रॉपर्टीज़ को संशोधित करें:

```cpp
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

{{% alert color="primary" %}}
और पढ़ें: [**Tile Picture As Texture**](/slides/hi/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **पृष्ठभूमि छवि की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि छवि की पारदर्शिता को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री प्रमुख दिखे। नीचे दिया गया C++ कोड दर्शाता है कि स्लाइड पृष्ठभूमि छवि की पारदर्शिता कैसे बदलें:

```cpp
auto transparencyValue = 30; // उदाहरण के लिए।

// चित्र रूपांतरण ऑपरेशन के संग्रह को प्राप्त करें।
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// मौजूद स्थिर-प्रतिशत पारदर्शिता प्रभाव खोजें।
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
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides [IBackgroundEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibackgroundeffectivedata/) इंटरफ़ेस प्रदान करता है जो स्लाइड के प्रभावी पृष्ठभूमि मान प्राप्त करने के लिए है। यह इंटरफ़ेस प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) और [EffectFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) को उजागर करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseslide/) क्लास की `get_Background` मेथड का उपयोग करके आप स्लाइड की प्रभावी पृष्ठभूमि प्राप्त कर सकते हैं।

नीचे दिया गया C++ उदाहरण दर्शाता है कि स्लाइड की प्रभावी पृष्ठभूमि मान कैसे प्राप्त करें:

```cpp
// Presentation क्लास का एक उदाहरण बनाएं।
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// मास्टर, लेआउट और थीम को ध्यान में रखते हुए प्रभावी पृष्ठभूमि प्राप्त करें।
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

**क्या मैं कस्टम पृष्ठभूमि रीसेट कर सकता हूँ और थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?**

हाँ। स्लाइड की कस्टम फ़िल हटाएँ, और पृष्ठभूमि फिर से संबंधित [layout](/slides/hi/cpp/slide-layout/)/[master](/slides/hi/cpp/slide-master/) स्लाइड (अर्थात् [theme background](/slides/hi/cpp/presentation-theme/)) से विरासत में मिलेगी।

**यदि मैं बाद में प्रस्तुति की थीम बदलूँ तो पृष्ठभूमि के साथ क्या होता है?**

यदि किसी स्लाइड की अपनी फ़िल है, तो वह अपरिवर्तित रहेगी। यदि पृष्ठभूमि [layout](/slides/hi/cpp/slide-layout/)/[master](/slides/hi/cpp/slide-master/) से विरासत में मिली है, तो वह नए [theme](/slides/hi/cpp/presentation-theme/) के अनुसार अपडेट हो जाएगी।