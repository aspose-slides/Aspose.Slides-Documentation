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
- ब्लर
- पारदर्शिता
- अल्फा प्रभाव
- प्रभाव श्रृंखला
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ चित्र फ्रेम के लिए छवि रूपांतरण प्रभावों को लागू करें, श्रृंखलाबद्ध करें, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **सारांश**

Aspose.Slides चित्र समायोजन को छवि रूपांतरण ऑपरेशनों के क्रमबद्ध संग्रह के रूप में दर्शाता है। एक चित्र फ्रेम के लिए, फ्रेम के [ISlidesPicture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidespicture/) से शुरू करें और [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidespicture/get_imagetransform/) तक पहुंचें। लौटाए गए [IImageTransformOperationCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/) आपको मूल छवि बाइट्स को पुनः लिखे बिना प्रभावों को जोड़ने, गिनने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देते हैं।

यह लेख चमक और कंट्रास्ट, रंग रूपांतरण, ब्लर, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखला, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए पूर्ण कार्यप्रवाह दिखाता है।

## **इफ़ेक्ट स्वामित्व और छवि पुन: उपयोग को समझें**

- [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) प्रस्तुति द्वारा स्वामित्व वाली स्रोत छवि डेटा को संग्रहित या संदर्भित करता है।
- [ISlidesPicture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidespicture/) एक चित्र फ़िल में रहता है और एक छवि संसाधन को संदर्भित करता है जबकि छवि रूपांतरण संग्रह को संग्रहीत करता है।
- [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) वह स्लाइड आकार है जो संबंधित चित्र फ़िल, जियोमेट्री, क्रॉप सेटिंग्स और अन्य फ्रेम‑स्तरीय फ़ॉर्मेटिंग को स्वामित्व में लेता है।

इसलिए, छवि रूपांतरण ऑपरेशनों से [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) की बाइट्स नहीं बदलती। जब वही `IPPImage` को [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addpictureframe/) में एक से अधिक बार पास किया जाता है, तो प्रत्येक नया चित्र फ्रेम अपना स्वयं का `ISlidesPicture` और अपना स्वयं का रूपांतरण संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करने से अन्य फ्रेम ग्रेस्केल नहीं होते, भले ही सभी समान एम्बेडेड छवि संसाधन का पुन: उपयोग करें।

उसी `ISlidesPicture::get_ImageTransform` मॉडल का उपयोग अन्य चित्र फ़िल के द्वारा भी किया जाता है, जैसे कि आकार या स्लाइड पृष्ठभूमि। नीचे के उदाहरण मुख्यतः चित्र फ्रेम पर केन्द्रित हैं।

## **मान्य पैरामीटर रेंज और इकाइयों का उपयोग करें**

प्रदर्शित विधियों में निम्नलिखित अर्थभारित रेंज और इकाइयाँ उपयोग की गई हैं। भले ही कोई विशेष लाइब्रेरी संस्करण तुरंत सभी अतिपारर रेंज मानों को अस्वीकृत न करे, लक्ष्य प्रस्तुतिकरण स्वरूप सहेजते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, निकाल या अस्वीकृत कर सकता है।

| ऑपरेशन | पैरामीटर | मान्य रेंज और इकाई |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित रखता है। |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | कोई नहीं। कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [AddDuotoneEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | गहरे और हल्के पिक्सेल के लिए दो रंग। `System::Drawing::Color` में RGB और अल्फा चैनल `0` से `255` तक उपयोग करते हैं। |
| [AddTintEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | ह्यू `0` (समावेशी) से `360` (असमावेशी) डिग्री में है; मात्रा `-100` से `100` तक, प्रतिशत। |
| [AddHSLEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | ह्यू `0` (समावेशी) से `360` (असमावेशी) डिग्री में है; संतृप्ति और प्रकाशमानता `-100` से `100` तक, प्रतिशत। |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | प्रतिस्थापन रंग `0` से `255` तक चैनल मान उपयोग करता है। मौजूदा अल्फा मान अपरिवर्तित रहता है। |
| [AddBlurEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | त्रिज्या अपरिचित है और पॉइंट्स में मापी जाती है; `grow` नियंत्रित करता है कि धुंधला कंटेंट मूल सीमा के बाहर फैल सकता है या नहीं। |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | अपरिचित प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को बनाए रखता है। |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेशहोल्ड। इसके नीचे के मान पारदर्शी हो जाते हैं; थ्रेशहोल्ड के बराबर या ऊपर के मान अपारदर्शी हो जाते हैं। |

स्थिर अल्फा माड्यूलेशन के लिए, पारदर्शिता और अपारदर्शिता परस्परपूरक होते हैं। उदाहरण के लिए, 35 % पारदर्शिता अल्फा माड्यूलेशन मात्रा 65 % के बराबर है।

## **चमक और कंट्रास्ट लागू करें**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) एक [IBrightnessContrast](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/ibrightnesscontrast/) ऑपरेशन लौटाता है। उसके स्केलर सेटिंग्स ऑपरेशन बनाते समय आपूर्ति की जाती हैं। `IBrightnessContrast::GetEffective` मेथड गणना किए गए केवल‑पढ़ने‑योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

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

[BrightnessContrast](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/brightnesscontrast/) एक Office 2010 चित्र‑इफ़ेक्ट विस्तार है और मानक DrawingML ल्यूमिनेंस इफ़ेक्ट की तुलना में कम पोर्टेबल है। जब चमक और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन योग्य रखना हो, तो [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) का उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम सत्यापित करें। स्वरूप सीमाएँ इस अंतर को अधिक विस्तार से समझाती हैं।

## **रंग रूपांतरण लागू करें**

रंग प्रभावों को स्वतंत्र रूप से विभिन्न चित्र फ्रेम पर लागू किया जा सकता है जो एक ही छवि संसाधन को पुन: उपयोग करते हैं। निम्न उदाहरण पाँच फ्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[IDuotone](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iduotone/) दो स्वतंत्र रूप से संपादन योग्य रंग पैरामीटर रखता है: `get_Color1` गहरे पिक्सेल को मैप करता है, जबकि `get_Color2` हल्के पिक्सेल को मैप करता है। यह एक ऐसे इफ़ेक्ट का उपयोगी उदाहरण है जिसकी सेटिंग्स एकल स्केलर मान से अधिक जटिल हैं।

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) प्रत्येक पिक्सेल के रंग को एक निश्चित रंग से बदलता है जबकि अल्फा को बरकरार रखता है। यह [AddColorChangeEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत व लक्ष्य रंग स्वरूपों को उजागर करता है।

## **ब्लर, पारदर्शिता, और अल्फा प्रभाव जोड़ें**

[AddBlurEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) सभी रंग चैनलों को प्रभावित करता है, जिसमें अल्फा भी शामिल है। जब धुंधली किनारा मूल चित्र सीमा से बाहर फैल सकता है, तो `grow` को `true` सेट करें।

समरूप पारदर्शिता के लिए, [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) का उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए आंशिक रूप से पारदर्शी पिक्सेल आनुपातिक रूप से अलग रहते हैं। [AddAlphaReplaceEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) सभी पिक्सेल को एक ही अल्फा मान असाइन करता है। [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) थ्रेशहोल्ड के आधार पर अल्फा को दो स्तरों में बदलता है।

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

अन्य पैरामीटर‑रहित अल्फा ऑपरेशन में [AddAlphaCeilingEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) शामिल है, जो प्रत्येक शून्य‑से‑भिन्न अल्फा को पूरी तरह अपारदर्शी बनाता है; [AddAlphaFloorEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) जो 100 % से कम प्रत्येक अल्फा को पूरी तरह पारदर्शी बना देता है; और [AddAlphaInverseEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) जो अल्फा को `100% - alpha` में बदलता है।

## **एक क्रमबद्ध प्रभाव श्रृंखला बनाएं**

प्रत्येक `Add...Effect` मेथड संग्रह के अंत में एक नया ऑपरेशन जोड़ता है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, आगे इसी प्रकार। परिणामस्वरूप, समान ऑपरेशनों को अलग क्रम में रखने से विभिन्न चित्र बन सकते हैं।

उदाहरण के तौर पर, ग्रेस्केल के बाद टिंट पहले रंगीय जानकारी हटाता है और फिर ल्यूमिनेंस परिणाम को पुनः रंग देता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटा देता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले के ऑपरेशनों द्वारा गणना किए गए अल्फा मानों को अधिलेखित कर सकता है, जबकि अल्फा मोड्यूलेशन उनके सापेक्ष अंतर को संरक्षित रखता है।

निम्न उदाहरण चार‑ऑपरेशन श्रृंखला बनाता है, उसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, दोनों ऑपरेशन प्रकार और उनका क्रम जाँचता है, और पुनः खुले परिणाम को रेंडर करता है:

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

संग्रह एक संगतता मैट्रिक्स लागू नहीं करता जो रंग, अल्फा और ब्लर ऑपरेशनों को अलग‑अलग श्रृंखलाओं तक सीमित करता हो। उन्हें संयोजित किया जा सकता है, लेकिन सभी संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पिछले रंग प्रभावों द्वारा उत्पन्न RGB परिवर्तन को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन या बि‑लेवल ऑपरेशनों से पहले बनाए गए अल्फा विवरण को हटा दिया जा सकता है। श्रृंखला को इच्छित पिक्सेल‑प्रक्रिया क्रम के अनुसार बनाएं, न कि इसकी वस्तुओं को अनऑर्डर्ड फ़ॉर्मेटिंग फ़्लैग मानें।

## **संपादन योग्य और प्रभावी मानों का निरीक्षण करें**

एक संपादन योग्य ऑपरेशन वह वस्तु है जो `ISlidesPicture::get_ImageTransform` में संग्रहीत होती है। प्रभाव के आधार पर, यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिए, [IBlur](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iblur/) `set_Radius` और `set_Grow` उजागर करता है, [IAlphaModulateFixed](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/ialphamodulatefixed/) `set_Amount` उजागर करता है, और [IAlphaBiLevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/ialphabilevel/) `set_Threshold` उजागर करता है। [IDuotone](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iduotone/) जैसे रंग प्रभाव mutable [IColorFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icolorformat/) वस्तुओं को उजागर करते हैं।

कुछ ऑपरेशन इंटरफ़ेस, जैसे कि [IBrightnessContrast](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/itint/), और [IAlphaReplace](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/ialphareplace/), अपनी निर्माण स्केलर को लिखने योग्य प्रॉपर्टी के रूप में उजागर नहीं करते। इन सेटिंग्स को बदलने के लिए, ऑपरेशन को हटाएँ और आवश्यक स्थिति पर प्रतिस्थापन जोड़ें।

`GetEffective()` द्वारा लौटाया गया प्रभावी डेटा गणना किया हुआ तथा केवल‑पढ़ने‑योग्य होता है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मान पढ़ने में उपयोगी है, लेकिन यह एक अन्य संपादन सतह नहीं है। निम्न उदाहरण श्रृंखला को गिनती करता है और कई सामान्य ऑपरेशनों के प्रभावी मानों को निरीक्षण करता है:

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

पैरामीटर‑रहित प्रभाव जैसे ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स के भी प्रभावी‑डेटा वस्तु होती है, लेकिन प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। उनकी उपस्थिति एवं संग्रह में स्थिति ही महत्वपूर्ण सूचना होती है।

## **छवि रूपांतरण हटाएं या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने के लिए [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) का उपयोग करें। चूँकि हटाने के बाद इंडेक्स शिफ्ट होते हैं, पहले लक्ष्य को खोजें और गिनती के बाद उसे हटाएँ। पूरी श्रृंखला को हटाने के लिए `Clear()` का उपयोग करें।

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

रूपांतरण हटाने या साफ़ करने से केवल चित्र फ़ॉर्मेटिंग बदलती है। यह पुनः उपयोग किए गए [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) संसाधन को हटाता, पुनः‑संपीड़ित करता या अन्यथा परिवर्तित नहीं करता।

## **प्रेजेंटेशन फ़ॉर्मेट और निर्यात लक्ष्यों पर विचार करें**

छवि रूपांतरण DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव श्रृंखलाओं के लिए प्राथमिक संपादन योग्य स्वरूप है। PPTX के साथ भी, सभी ऑपरेशनों की पोर्टेबिलिटी समान नहीं है:

- मानक DrawingML ऑपरेशन जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा ऑपरेशन PPTX राउंड‑ट्रिप में जीवित रहने की सबसे अधिक संभावना रखते हैं। जब संरक्षण आवश्यक हो तो उत्पन्न फ़ाइल को हमेशा पुनः खोलें और संग्रह का निरीक्षण करें।
- [BrightnessContrast](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/brightnesscontrast/) Office 2010 विस्तार है, न कि मानक DrawingML ल्यूमिनेंस ऑपरेशन। इसे केवल‑इन‑मेमोरी रेंडरिंग के लिए उपयोग किया जा सकता है, लेकिन सहेजने और PPTX को पुनः खोलने के बाद यह संपादन योग्य [IBrightnessContrast](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/ibrightnesscontrast/) के रूप में बना रहना गारंटी नहीं है। निरंतर चमक और कंट्रास्ट समायोजन के लिए [AddLuminanceEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) को प्राथमिकता दें।
- बाइनरी PPT स्वरूप DrawingML प्रभाव मॉडल से पूर्व का है। PPT में सहेजने पर असमर्थित ऑपरेशन छोड़े जा सकते हैं, श्रृंखला को समर्थित उपसमुच्चय में घटाया जा सकता है, या रूप दिखाने के लिए अनुमानित किया जा सकता है। जटिल संपादन योग्य श्रृंखला के सत्यापन के लिये PPT का उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML या अन्य दृश्य आउटपुट में रेंडरिंग समर्थित श्रृंखला को रेंडर किए गए रूप में लागू करती है। इन आउटपुट में संपादन योग्य `IImageTransformOperationCollection` नहीं होता; रास्टर स्वरूप परिणाम को पिक्सेल में फ्लैट कर देते हैं, और दस्तावेज़ या वेक्टर निर्यात अपनी स्वयं की रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- प्रभाव लिंक्ड छवि को आत्मनिर्भर नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिये प्रस्तुति लोड होते समय लिंक्ड संसाधन उपलब्ध होना आवश्यक है।

विभिन्न प्रस्तुति उपभोक्ता किनारा‑केस को अलग‑अलग रेंडर कर सकते हैं, विशेष रूप से जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशन सम्मिलित हों। महत्वपूर्ण आउटपुट के लिये, संपादन योग्य राउंड‑ट्रिप और अंतिम निर्यात स्वरूप दोनों को उसी Aspose.Slides संस्करण के साथ परीक्षण करें जो उत्पादन में उपयोग हो रहा है।

## **FAQ**

**क्या छवि रूपांतरण प्रभाव एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। ऑपरेशन `ISlidesPicture` से संबंधित होते हैं जो चित्र फ़िल द्वारा उपयोग किए जाते हैं। अंतर्निहित `IPPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ्रेम जो समान छवि को पुन: उपयोग करते हैं, अपने प्रभाव साझा करेंगे?**

नहीं। `IPPImage` को पुन: उपयोग करने से दोहराव वाली छवि डेटा बचती है, लेकिन प्रत्येक चित्र फ्रेम सामान्यतः अलग `ISlidesPicture` और अलग छवि रूपांतरण संग्रह रखता है।

**क्या रंग, ब्लर, और अल्फा प्रभावों को संयोजित किया जा सकता है?**

हां। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक ऑपरेशन के पिछले आउटपुट पर प्रभाव को ध्यान में रखें, क्योंकि प्रतिस्थापन और थ्रेशहोल्ड ऑपरेशन पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान केवल‑पढ़ने‑योग्य क्यों होते हैं?**

प्रभावी डेटा रेंडरिंग के लिये उपयोग किए गए गणना किए गए मान दर्शाता है, जिसमें हल किए गए रंग शामिल होते हैं। उन ऑपरेशनों को संपादित करें जहाँ लिखने योग्य सदस्य मौजूद हों; अन्यथा उन्हें हटाएँ और नई निर्माण पैरामीटर के साथ प्रतिस्थापन जोड़ें।

**कौन‑सा स्वरूप उपयोग करना चाहिए ताकि रूपांतरण श्रृंखला संरक्षित रहे?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML प्रभाव मॉडल को नहीं दर्शा सकता, और रेंडर किए गए निर्यात स्वरूप केवल रूप दिखाते हैं, न कि संपादन योग्य रूपांतरण ऑपरेशन।