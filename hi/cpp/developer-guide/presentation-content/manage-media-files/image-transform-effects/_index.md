---
title: C++ के साथ प्रस्तुतियों में छवि रूपांतरण प्रभावों का प्रबंधन
linktitle: छवि रूपांतरण प्रभाव
type: docs
weight: 11
url: /hi/cpp/image-transform-effects/
keywords:
- छवि रूपांतरण
- चित्र प्रभाव
- चमक
- कंट्रास्ट
- ग्रेस्केल
- डुओटोन
- टिंट
- HSL
- रंग प्रतिस्थापन
- धुंध
- पारदर्शिता
- अल्फा प्रभाव
- प्रभाव श्रृंखला
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ चित्र फ़्रेम के लिये छवि रूपांतरण प्रभाव लागू करें, श्रृंखलाबद्ध करें, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **सारांश**

Aspose.Slides चित्र समायोजन को छवि रूपांतरण कार्यों के क्रमबद्ध संग्रह के रूप में दर्शाता है। एक चित्र फ़्रेम के लिए, फ्रेम की [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) से शुरू करें और [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/) तक पहुँचें। लौटाया गया [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) आपको प्रभावों को जोड़ने, क्रमबद्ध करने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देता है, बिना मूल छवि बाइट्स को पुनः लिखे।

यह लेख चमक और कंट्रास्ट, रंग रूपांतरण, धुंध, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखलाएँ, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए पूर्ण कार्यप्रवाह दर्शाता है।

## **प्रभाव स्वामित्व और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और उसे प्रदर्शित करने वाला चित्र अलग‑अलग वस्तुएँ हैं:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) प्रस्तुति द्वारा स्वामित्व वाली स्रोत छवि डेटा को संग्रहीत या संदर्भित करता है।
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) चित्र भराव से जुड़ा होता है और एक छवि संसाधन को संदर्भित करता है जबकि छवि रूपांतरण संग्रह को संग्रहीत करता है।
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) वह स्लाइड आकार है जो संबंधित चित्र भराव, ज्यामिति, क्रॉप सेटिंग्स और अन्य फ़्रेम‑स्तरीय स्वरूपण को स्वामित्व में रखता है।

इसलिए, छवि रूपांतरण संचालन [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) में बाइट्स को संशोधित नहीं करते। जब वही `IPPImage` को कई बार [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) में पास किया जाता है, तो प्रत्येक नया चित्र फ़्रेम अपना स्वयं का `ISlidesPicture` तथा अपना रूपांतरण संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करने से अन्य फ्रेम ग्रेस्केल नहीं होते, भले ही सभी समान एम्बेडेड छवि संसाधन का पुनः उपयोग करें।

उसी `ISlidesPicture::get_ImageTransform` मॉडल का उपयोग अन्य चित्र भराव, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे के उदाहरण मुख्य रूप से चित्र फ़्रेम पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयों का उपयोग करें**

दर्शाए गए मेथड्स निम्नलिखित अर्थपूर्ण रेंज और इकाइयों का उपयोग करते हैं। इन रेंजों के भीतर मान रखें, भले ही कोई लाइब्रेरी संस्करण तुरंत सभी आउट‑ऑफ़‑रेंज मानों को अस्वीकार न करे; लक्ष्य प्रस्तुति स्वरूप सहेजते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, हटाए या अस्वीकार कर सकता है।

| ऑपरेशन | पैरामीटर | वैध रेंज और इकाई |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित रखता है। |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | कोई नहीं | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | गहरे और हल्के पिक्सेल के लिये दो रंग। `System::Drawing::Color` में RGB और अल्फा चैनल `0` से `255` तक होते हैं। |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | ह्यू `0` (समावेशी) से `360` (असमावेशी) डिग्री तक; मात्रा `-100` से `100` प्रतिशत। |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | ह्यू `0` से `360` डिग्री; संतृप्ति और ल्यूमिनेंस `-100` से `100` प्रतिशत। |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | प्रतिस्थापन रंग के चैनल मान `0` से `255` तक। मौजूदा अल्फा मान अपरिवर्तित रहता है। |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | त्रिज्या गैर‑नकारात्मक और पॉइंट्स में मापी जाती है; `grow` निर्धारित करता है कि धुंधला सामग्री मूल सीमा से बाहर तक विस्तारित हो सकती है या नहीं। |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | गैर‑नकारात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिये `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` से `100` प्रतिशत अपारदर्शिता। |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` से `100` प्रतिशत अल्फा थ्रेशहोल्ड। इसके नीचे के मान पारदर्शी, इसके बराबर या ऊपर के मान अस्पष्ट हो जाते हैं। |

स्थिर अल्फा मॉड्यूलेशन के लिये पारदर्शिता और अपारदर्शिता परस्पर पूरक हैं। उदाहरण के लिये, 35 % पारदर्शिता अल्फा मॉड्यूलेशन मात्रा 65 % के बराबर है।

## **चमक और कंट्रास्ट लागू करें**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) एक [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) ऑपरेशन लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन बनाते समय प्रदान की जाती हैं। `IBrightnessContrast::GetEffective` मेथड गणना किए गए केवल‑पढ़ने‑योग्य मानों को लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण चमक को 15 % और कंट्रास्ट को 20 % बढ़ाता है, फिर एम्बेडेड छवि को बदले बिना एक प्रीव्यू रेंडर करता है:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) Office 2010 चित्र‑प्रभाव विस्तार है और मानक DrawingML ल्यूमिनेंस प्रभाव की तुलना में कम पोर्टेबल है। जब चमक और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन‑योग्य रखना हो, तो [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) का उपयोग करें और फ़ाइल पुनः खोलने के बाद परिणाम सत्यापित करें। फ़ॉर्मेट सीमाएँ अनुभाग इस अंतर को अधिक विस्तार से समझाता है।

## **रंग रूपांतरण लागू करें**

रंग प्रभाव स्वतंत्र रूप से विभिन्न चित्र फ़्रेम पर लागू किए जा सकते हैं जो वही छवि संसाधन पुनः उपयोग करते हैं। निम्न उदाहरण पाँच फ़्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) दो स्वतंत्र रूप से संपादन‑योग्य रंग पैरामीटर रखता है: `get_Color1` गहरे पिक्सेल को मानचित्रित करता है, जबकि `get_Color2` हल्के पिक्सेल को। यह एक ऐसे प्रभाव का उपयोगी उदाहरण है जिसकी सेटिंग्स एकल स्केलर मान से अधिक जटिल हैं।

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) प्रत्येक पिक्सेल के रंग को एक स्थिर रंग से प्रतिस्थापित करता है जबकि अल्फा को संरक्षित रखता है। यह [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) से अलग है, जो एक स्रोत रंग को दूसरे में मानचित्रित करता है और दोनों स्रोत तथा लक्ष्य रंग स्वरूप उजागर करता है।

### **ल्यूमिनेंस थ्रेशहोल्ड लागू करें**

ल्यूमिनेंस थ्रेशहोल्ड स्कैन किए गए पृष्ठ पर हल्की निशानों को पृष्ठभूमि से बेहतर पहचानने में मदद करता है। [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) मध्यवर्ती ग्रे शेड को बरकरार रखता है। [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) ल्यूमिनेंस को काले या सफेद में मानचित्रित करता है, जबकि [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) अपारदर्शिता पर थ्रेशहोल्ड लागू करता है।

ल्यूमिनेंस थ्रेशहोल्ड 0 % से 100 % सम्मिलित है। थ्रेशहोल्ड से नीचे के पिक्सेल काले हो जाते हैं। थ्रेशहोल्ड से बराबर या ऊपर के पिक्सेल सफेद हो जाते हैं। थ्रेशहोल्ड बढ़ाने से कई शेड काले हो जाते हैं क्योंकि वे कट‑ऑफ़ से नीचे गिरते हैं।

[grayscale-swatches.png](grayscale-swatches.png) को कार्य निर्देशिका में डाउनलोड करें। प्रत्येक लेबल मूल ग्रे स्तर को 0‑255 के मापदंड पर दर्शाता है। उदाहरण मूल को दो प्रतियों के साथ रखता है और प्रत्येक प्रतिलिपि का थ्रेशहोल्ड प्रस्तुति में सहेजता है।

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और तीन फ़्रेम की तुलना करें। लेबल 96 वाला स्वैच लगभग 38 % ल्यूमिनेंस (96/255) दर्शाता है। यह 20 % थ्रेशहोल्ड पर सफेद और 60 % थ्रेशहोल्ड पर काला हो जाता है।

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **धुंध, पारदर्शिता और अल्फा प्रभाव जोड़ें**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) सभी रंग चैनलों, अल्फा सहित, को प्रभावित करता है। जब धुंधली किनारी मूल चित्र सीमा से बाहर तक विस्तारित हो सकती है, तो `grow` को `true` सेट करें।

समान पारदर्शिता के लिये, [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए आंशिक रूप से पारदर्शी पिक्सेल अनुपातिक रूप से भिन्न रहते हैं। [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) सभी पिक्सेल को एक ही अल्फा मान देता है। [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) थ्रेशहोल्ड के आधार पर अल्फा को दो स्तरों में बदलता है।

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

अन्य पैरामीटर‑रहित अल्फा ऑपरेशन में [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) शामिल है, जो शून्य से भिन्न प्रत्येक अल्फा को पूरी तरह अस्पष्ट बनाता है; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) जो 100 % से नीचे के प्रत्येक अल्फा को पूरी तरह पारदर्शी बनाता है; तथा [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) जो अल्फा को `100% - alpha` में बदलता है।

## **एक क्रमबद्ध प्रभाव श्रृंखला बनाएं**

प्रत्येक `Add...Effect` मेथड संग्रह के अंत में नया ऑपरेशन जोड़ता है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, आदि। इसलिए समान ऑपरेशन अलग क्रम में होने पर अलग छवि उत्पन्न हो सकती है।

उदाहरण के लिये, ग्रेस्केल के बाद टिंट पहले क्रोमैटिक जानकारी हटाता है और फिर ल्यूमिनेंस परिणाम को पुनः रंगता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटाता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले के ऑपरेशनों द्वारा गणना किए गए अल्फा मानों को अधिलेखित कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके सापेक्ष अंतर को बरकरार रखता है।

निम्न उदाहरण चार‑ऑपरेशन श्रृंखला बनाता है, इसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, दोनों ऑपरेशन प्रकार और क्रम की जाँच करता है, तथा पुनः खोलें परिणाम रेंडर करता है:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

संग्रह कोई संगतता मैट्रिक्स लागू नहीं करता जो रंग, अल्फा और धुंध प्रभावों को अलग‑अलग श्रृंखलाओं तक सीमित करे। इन्हें संयोजित किया जा सकता है, लेकिन सभी संयोजन हमेशा उपयोगी नहीं होते। स्थिर रंग प्रतिस्थापन पहले की रंग प्रभावों द्वारा उत्पन्न RGB विविधता को हटाता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटाता है; तथा अल्फा Ceiling, Floor, Replacement या Bi‑Level ऑपरेशन पहले निर्मित अल्फा विवरण को निरस्त कर सकते हैं। आवश्यक पिक्सेल‑प्रसंस्करण क्रम के अनुसार श्रृंखला बनाएं, न कि इसे अनऑर्डर्ड फ़ॉर्मेटिंग फ़्लैग मानें।

<!-- visual-explanation:image-transform-effects:start -->
[![एक ही छवि पहले ग्रेस्केल, फिर टिंट, और फिर टिंट, फिर ग्रेस्केल के क्रम से गुजरती है। दो अंतिम ग्रेस्केल छवियों के रंग अलग होते हैं।](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Aspose.Slides for .NET 26.11 में इस दर्शनीय रेंडर में, 220° टिंट 25 % पर ग्रेस्केल छवि को अपरिवर्तित छोड़ता है। वही टिंट ग्रेस्केल से पहले लागू करने से अलग‑अलग टोन उत्पन्न होते हैं।*
<!-- visual-explanation:image-transform-effects:end -->

## **संपादन‑योग्य और प्रभावी मानों का निरीक्षण करें**

एक संपादन‑योग्य ऑपरेशन वह वस्तु है जो `ISlidesPicture::get_ImageTransform` में संग्रहित होती है। प्रभाव के अनुसार यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिये, [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) `set_Radius` और `set_Grow` उजागर करता है, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) `set_Amount` उजागर करता है, और [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) `set_Threshold` उजागर करता है। [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) जैसे रंग प्रभाव परिवर्तन योग्य [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) वस्तुओं को उजागर करते हैं।

कुछ ऑपरेशन इंटरफ़ेस, जैसे [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), और [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), अपनी निर्माण स्केलर्स को लिखने योग्य गुणों के रूप में उजागर नहीं करते। इन सेटिंग्स को बदलने के लिये ऑपरेशन को हटाएँ और आवश्यक स्थान पर नया जोड़ें।

`GetEffective()` द्वारा लौटाया गया प्रभावी डेटा गणना‑आधारित और केवल‑पढ़ने‑योग्य होता है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए जाने वाले सामान्यीकृत मान पढ़ने में उपयोगी है, परंतु यह नया संपादन‑सतह नहीं है। नीचे का उदाहरण श्रृंखला को क्रमबद्ध करता है और कई सामान्य ऑपरेशनों के लिए प्रभावी मानों का निरीक्षण करता है:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

ग्रेस्केल, अल्फा Ceiling, और अल्फा Inverse जैसे पैरामीटर‑रहित प्रभावों के पास भी प्रभावी‑डेटा वस्तु होती है, परंतु प्रिंट करने हेतु कोई स्केलर सेटिंग नहीं होती। उनका अस्तित्व और संग्रह में स्थिति ही महत्वपूर्ण जानकारी है।

## **छवि रूपांतरण हटाएँ या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने के लिये [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) का उपयोग करें। चूँकि हटाने के बाद इंडेक्स बदलते हैं, पहले लक्ष्य की खोज करें और क्रमबद्ध करने के बाद इसे हटाएँ। पूरी श्रृंखला को हटाने के लिये `Clear()` का उपयोग करें।

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

रूपांतरण को हटाने या साफ़ करने से केवल चित्र स्वरूपण बदलता है। यह पुनः‑उपयोग किए गए [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) संसाधन को नहीं हटाता, संपीड़ित नहीं करता, या अन्यथा बदलता नहीं।

## **प्रेजेंटेशन फ़ॉर्मेट और निर्यात लक्ष्य पर विचार करें**

छवि रूपांतरण DrawingML में उत्पन्न होते हैं, इसलिए प्रभाव श्रृंखलाओं के लिये PPTX सबसे उपयुक्त संपादन‑योग्य फ़ॉर्मेट है। PPTX के साथ भी सभी ऑपरेशन समान पोर्टेबिलिटी नहीं रखते:

- मानक DrawingML ऑपरेशनों जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, धुंध, और सामान्य अल्फा ऑपरेशन PPTX राउंड‑ट्रिप में सबसे अधिक बने रहने की संभावना रखते हैं। जब संरक्षण आवश्यक हो, तो उत्पन्न फ़ाइल को हमेशा पुनः खोलें और संग्रह का निरीक्षण करें।
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) Office 2010 विस्तार है, न कि मानक DrawingML ल्यूमिनेंस ऑपरेशन। इसे मेमोरी में रेंडरिंग के लिये उपयोग किया जा सकता है, परंतु सहेजने और PPTX पुनः खोलने के बाद यह संपादन‑योग्य [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) के रूप में बरकरार नहीं रह सकता। स्थायी चमक‑कंट्रास्ट समायोजन के लिये [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) को प्राथमिकता दें।
- बाइनरी PPT फ़ॉर्मेट पूर्ण DrawingML प्रभाव मॉडल से पूर्व है। PPT में सहेजने से असमर्थित ऑपरेशन हटाए जा सकते हैं, श्रृंखला को समर्थित उपसमुच्चय में घटाया जा सकता है, या स्वरूप का अनुमानित रूप दिया जा सकता है। जटिल संपादन‑योग्य श्रृंखला के लिये PPT को सत्यापन फ़ॉर्मेट के रूप में उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML, या अन्य दृश्य आउटपुट पर रेंडर करने से समर्थित श्रृंखला लागू होती है, परन्तु ये आउटपुट संपादन‑योग्य `IImageTransformOperationCollection` नहीं रखते; रास्टर फ़ॉर्मेट परिणाम को पिक्सेल में फ़्लैटन करता है, और दस्तावेज़ या वेक्टर निर्यात अपने स्वयं के रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- प्रभाव लिंक्ड छवि को स्वयंक-contained नहीं बनाते। लिंक्ड चित्र का रेंडरिंग अभी भी लिंक्ड संसाधन के उपलब्ध होने पर निर्भर करता है जब प्रस्तुति लोड की जाती है।

विभिन्न प्रस्तुति उपभोक्ताओं द्वारा किनारी मामलों का रेंडरिंग अलग हो सकता है, विशेषकर जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशन संयोजित हों। महत्वपूर्ण आउटपुट के लिये उसी Aspose.Slides संस्करण से संपादन‑योग्य राउंड‑ट्रिप और अंतिम निर्यात फ़ॉर्मेट दोनों का परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि रूपांतरण प्रभाव एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। ये ऑपरेशन चित्र भराव द्वारा उपयोग की गई `ISlidesPicture` से सम्बंधित हैं। आधारभूत `IPPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ़्रेम जो समान छवि पुनः उपयोग करते हैं, अपने प्रभाव साझा करते हैं?**

नहीं। `IPPImage` को पुनः उपयोग करने से डुप्लिकेट छवि डेटा बचता है, परन्तु प्रत्येक चित्र फ़्रेम आमतौर पर अपना अलग `ISlidesPicture` तथा छवि रूपांतरण संग्रह रखता है।

**क्या रंग, धुंध और अल्फा प्रभावों को संयोजित किया जा सकता है?**

हां। संग्रह इन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक ऑपरेशन के परिणाम पर अगले ऑपरेशन के प्रभाव को ध्यान में रखें, क्योंकि प्रतिस्थापन और थ्रेशहोल्ड ऑपरेशन पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान केवल‑पढ़ने‑योग्य क्यों हैं?**

प्रभावी डेटा रेंडरिंग हेतु गणना किए गए मानों को दर्शाता है, जिसमें समाधान किए गए रंग भी शामिल हैं। जहाँ लिखने योग्य सदस्य मौजूद हों, रूपांतरण संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर के साथ प्रतिस्थापित करें।

**कौन‑सा फ़ॉर्मेट रूपांतरण श्रृंखला को संरक्षित रखने के लिये उपयोग करना चाहिए?**

PPTX उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML प्रभाव मॉडल को प्रदर्शित नहीं कर सकता, और रेंडर किए गए निर्यात फ़ॉर्मेट केवल स्वरूप को संरक्षित रखते हैं, न कि संपादन‑योग्य रूपांतरण ऑपरेशन।