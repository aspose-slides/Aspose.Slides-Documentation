---
title: C++ का उपयोग करके प्रेजेंटेशन में चित्र फ्रेम प्रबंधित करें
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/cpp/picture-frame/
keywords:
- चित्र फ्रेम
- चित्र फ्रेम जोड़ें
- चित्र फ्रेम बनाएं
- छवि जोड़ें
- छवि बनाएं
- छवि निकालें
- रास्टर छवि
- वेक्टर छवि
- छवि क्रॉप करें
- क्रॉप किया हुआ क्षेत्र
- StretchOff प्रॉपर्टी
- चित्र फ्रेम फॉर्मेटिंग
- चित्र फ्रेम प्रॉपर्टीज़
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट रेशियो
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ्रेम जोड़ें। अपने कार्य प्रवाह को सरल बनाएं और स्लाइड डिज़ाइन को सुधारें।"
---
## **परिचय**

एक चित्र फ्रेम वह आकार है जो किसी छवि को समेटे रहता है—यह फ्रेम में रखे चित्र जैसा है।

आप एक स्लाइड में चित्र फ्रेम के माध्यम से छवि जोड़ सकते हैं। इस तरह, आप चित्र फ्रेम को फ़ॉर्मेट करके छवि को फ़ॉर्मेट कर सकते हैं।

{{% alert  title="Tip" color="info" %}} 

Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG को PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG को PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से तेज़ी से प्रेजेंटेशन बनाने की अनुमति देता है। 

{{% /alert %}} 

## **चित्र फ्रेम बनाना**

1. [Presentation क्लास](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) का एक उदाहरण बनाएँ।  
2. स्लाइड का संदर्भ उसके इंडेक्स द्वारा प्राप्त करें।  
3. प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_p_p_image) ऑब्जेक्ट बनाएँ, जो आकार को भरने के लिये उपयोग होगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. स्लाइड से जुड़े shape ऑब्जेक्ट द्वारा उजागर `AddPictureFrame` मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_frame) बनाएँ।  
6. स्लाइड में चित्र फ्रेम (जिसमें चित्र है) जोड़ें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड आपको दिखाता है कि कैसे एक चित्र फ्रेम बनाया जाता है:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// वांछित प्रस्तुति लोड करें
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> slide = pres->get_Slide(0);

// छवि लोड करता है जो प्रस्तुति की इमेज कलेक्शन में जोड़ी जाएगी
// चित्र प्राप्त करता है
auto image = Images::FromFile(filePath);

// प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// स्लाइड में एक चित्र फ्रेम जोड़ता है
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करता है
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// PictureFrame पर कुछ फ़ॉर्मेटिंग लागू करता है
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

चित्र फ्रेम आपको छवियों के आधार पर शीघ्रता से प्रस्तुति स्लाइड बनाने में सक्षम बनाते हैं। जब आप चित्र फ्रेम को Aspose.Slides की सहेजने की विकल्पों के साथ संयोजित करते हैं, तो आप इनपुट/आउटपुट संचालन को नियंत्रित करके एक फ़ॉर्मेट की छवि को दूसरे फ़ॉर्मेट में परिवर्तित कर सकते हैं। आप ये पृष्ठ देख सकते हैं: [image को JPG में बदलें](https://products.aspose.com/slides/hi/cpp/conversion/image-to-jpg/); [JPG को image में बदलें](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-image/); [JPG को PNG में बदलें](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-png/), [PNG को JPG में बदलें](https://products.aspose.com/slides/hi/cpp/conversion/png-to-jpg/); [PNG को SVG में बदलें](https://products.aspose.com/slides/hi/cpp/conversion/png-to-svg/), [SVG को PNG में बदलें](https://products.aspose.com/slides/hi/cpp/conversion/svg-to-png/)।

{{% /alert %}}

## **सापेक्ष स्केल के साथ चित्र फ्रेम बनाना**

छवि के सापेक्ष स्केल को बदलकर आप एक अधिक जटिल चित्र फ्रेम बना सकते हैं।  

1. [Presentation क्लास](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) का एक उदाहरण बनाएँ।  
2. स्लाइड का संदर्भ उसके इंडेक्स द्वारा प्राप्त करें।  
3. प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ें।  
4. प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_p_p_image) ऑब्जेक्ट बनाएँ।  
5. चित्र फ्रेम में छवि की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड आपको दिखाता है कि कैसे सापेक्ष स्केल वाला चित्र फ्रेम बनाया जाता है:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// इच्छित प्रस्तुति लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> slide = pres->get_Slide(0);

// प्रस्तुति की इमेज कलेक्शन में जोड़ने के लिये छवि लोड करता है
// चित्र प्राप्त करता है
auto image = Images::FromFile(filePath);

// प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// स्लाइड में एक चित्र फ्रेम जोड़ता है
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करता है
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **चित्र फ्रेम से रास्टर छवियों को निकालना**

आप [PictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_frame) ऑब्जेक्ट्स से रास्टर छवियों को निकाल कर उन्हें PNG, JPG और अन्य फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दस्तावेज़ “sample.pptx” से एक छवि निकालता है और उसे PNG फ़ॉर्मेट में सहेजता है।

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **चित्र फ्रेम से SVG छवियों को निकालना**

जब किसी प्रस्तुति में SVG ग्राफ़िक्स को [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) आकारों के भीतर रखा जाता है, तो Aspose.Slides for C++ आपको मूल वेक्टर छवियों को पूर्ण सत्यता के साथ प्राप्त करने देता है। स्लाइड के shape कलेक्शन को पार करके आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) की पहचान कर सकते हैं, जाँच सकते हैं कि अंतर्निहित [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) में SVG सामग्री है या नहीं, और फिर उस छवि को उसकी मूल SVG फ़ॉर्मेट में डिस्क या स्ट्रीम पर सहेज सकते हैं।

निम्नलिखित कोड उदाहरण दिखाता है कि कैसे एक चित्र फ्रेम से SVG छवि निकाली जाती है:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **छवि की पारदर्शिता प्राप्त करना**

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव को प्राप्त करने की सुविधा देता है। यह C++ कोड इस ऑपरेशन को दर्शाता है:

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="info" %}} 
सभी प्रभावों को छवियों पर लागू करने के लिये आप [Aspose::Slides::Effects](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/) देख सकते हैं। 
{{% /alert %}}

## **छवि की चमक और कंट्रास्ट प्राप्त करना**

Aspose.Slides आपको छवि पर लागू चमक और कंट्रास्ट प्रभाव को प्राप्त करने की सुविधा देता है। यह प्रभाव [ILuminance](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iluminance/) इंटरफ़ेस द्वारा दर्शाया गया है।

यह C++ कोड दिखाता है कि कैसे चित्र फ्रेम से चमक और कंट्रास्ट सेटिंग्स प्राप्त की जा सकती हैं:

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **चित्र फ्रेम फ़ॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जिन्हें आप चित्र फ्रेम पर लागू कर सकते हैं। इन विकल्पों का उपयोग करके आप चित्र फ्रेम को विशिष्ट आवश्यकताओं के अनुरूप संशोधित कर सकते हैं।

1. [Presentation क्लास](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) का एक उदाहरण बनाएँ।  
2. स्लाइड का संदर्भ उसके इंडेक्स द्वारा प्राप्त करें।  
3. प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_p_p_image) ऑब्जेक्ट बनाएँ।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. [AddPictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) मेथड द्वारा उजागर `PictureFrame` को छवि की चौड़ाई और ऊँचाई के आधार पर बनाएँ, जो स्लाइड से जुड़े [IShapes](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection) ऑब्जेक्ट पर लागू होता है।  
6. स्लाइड में चित्र फ्रेम (जिसमें चित्र है) जोड़ें।  
7. चित्र फ्रेम की लाइन रंग सेट करें।  
8. चित्र फ्रेम की लाइन चौड़ाई सेट करें।  
9. चित्र फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है।  
   * नकारात्मक मान छवि को प्रतिगामी दिशा में घुमाता है।  
10. चित्र फ्रेम को स्लाइड में फिर से जोड़ें।  
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C++ कोड चित्र फ्रेम फ़ॉर्मेटिंग प्रक्रिया को प्रदर्शित करता है:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// इच्छित प्रस्तुति लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// प्रस्तुति की इमेज कलेक्शन में जोड़ने के लिये छवि लोड करता है
// चित्र प्राप्त करता है
auto image = Images::FromFile(filePath);

// प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// स्लाइड में एक चित्र फ्रेम जोड़ता है
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करता है
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}

Aspose ने हाल ही में एक [नि:शुल्क कोलाज मेकर](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG को मिलाना](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मिलाना हो, या [फ़ोटो से ग्रिड बनाना](https://products.aspose.app/slides/hi/collage/photo-grid) हो, तो आप इस सेवा का उपयोग कर सकते हैं। 

{{% /alert %}}

## **लिंक के रूप में छवि जोड़ना**

प्रस्तुति का आकार कम रखने के लिये आप छवियों (या वीडियो) को फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से जोड़ सकते हैं। यह C++ कोड आपको दिखाता है कि कैसे एक प्लेसहोल्डर में छवि और वीडियो जोड़ा जाता है:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **छवियों को क्रॉप करना**

यह C++ कोड दिखाता है कि स्लाइड पर मौजूदा छवि को कैसे क्रॉप किया जाता है: 

``` CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// नया इमेज ऑब्जेक्ट बनाता है
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Adds a PictureFrame to a Slide
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Crops the image (percentage values)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Saves the result
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **चित्र फ्रेम के क्रॉप किए गए क्षेत्रों को हटाना**

यदि आप फ्रेम में मौजूद छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप किया हुआ चित्र या मूल चित्र लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।

यह C++ कोड इस ऑपरेशन को दर्शाता है: 

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// पहली स्लाइड से PictureFrame प्राप्त करता है
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// PictureFrame छवि के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई छवि लौटाता है
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// परिणाम सहेजता है
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) मेथड क्रॉप की गई छवि को प्रस्तुति इमेज कलेक्शन में जोड़ता है। यदि छवि केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) में उपयोग हुई है, तो यह सेटअप प्रस्तुति के आकार को कम कर सकता है। अन्यथा, परिणामी प्रस्तुति में छवियों की संख्या बढ़ेगी।

यह मेथड क्रॉपिंग प्रक्रिया में WMF/EMF मीटाफाइलों को रास्टर PNG छवि में बदल देता है। 

{{% /alert %}}

## **छवियों को संपीडित करना**

आप एक प्रस्तुति में चित्र को [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/compressimage/) मेथड का उपयोग करके संपीड़ित कर सकते हैं। यह मेथड आकार को आकार के अनुसार और निर्दिष्ट रेजॉल्यूशन के अनुसार घटाकर तथा आवश्यक होने पर क्रॉप किए गए क्षेत्रों को हटाकर छवि को संपीडित करता है।

यह PowerPoint के **Picture Format -> Compress Pictures -> Resolution** फीचर के समान है।

निम्नलिखित C++ उदाहरण दिखाते हैं कि कैसे लक्ष्य रेजॉल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप क्षेत्रों को हटाकर प्रस्तुति में छवि को संपीड़ित किया जाता है:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 150 DPI (वेब रिज़ॉल्यूशन) लक्ष्य रिज़ॉल्यूशन के साथ छवि को संपीड़ित करें और क्रॉप किए गए क्षेत्रों को हटाएँ.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// संपीड़न के परिणाम की जाँच करें.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

या सीधे एक कस्टम DPI मान का उपयोग करके:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// छवि को 150 DPI (वेब रिज़ॉल्यूशन) पर संपीड़ित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

यह मेथड आकार के आधार पर छवि को कम रेजॉल्यूशन में बदलता है और क्रॉप किए गए क्षेत्रों को हटाकर फ़ाइल आकार को अनुकूलित करता है। यदि छवि मेटाफाइल (WMF/EMF) या SVG है, तो संपीड़न लागू नहीं होता। JPEG की गुणवत्ता रेजॉल्यूशन के अनुसार बरकरार रहती है या हल्की कमी आती है, जैसा कि PowerPoint उच्च रेजॉल्यूशन JPEG को संभालता है।

{{% /alert %}}

## **आस्पेक्ट रेशियो को लॉक करना**

यदि आप चाहते हैं कि छवि युक्त आकार इमेज के आयाम बदलने पर भी अपना आस्पेक्ट रेशियो बनाए रखे, तो आप *Lock Aspect Ratio* सेटिंग को सेट करने हेतु [set_AspectRatioLocked()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) मेथड का उपयोग कर सकते हैं। 

यह C++ कोड दिखाता है कि कैसे आकार का आस्पेक्ट रेशियो लॉक किया जाता है:

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

यह *Lock Aspect Ratio* सेटिंग केवल आकार के आस्पेक्ट रेशियो को ही संरक्षित करती है, न कि उसमें निहित छवि को। 
{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग**

[IPictureFillFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_picture_fill_format) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format) क्लास की [StretchOffsetLeft](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) प्रॉपर्टीज़ का उपयोग करके आप एक भराव आयत निर्दिष्ट कर सकते हैं। 

जब किसी छवि के स्ट्रेचिंग को निर्दिष्ट किया जाता है, तो स्रोत आयत को निर्दिष्ट भराव आयत में फिट करने के लिये स्केल किया जाता है। भराव आयत का प्रत्येक किनारा आकार की बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित होता है। सकारात्मक प्रतिशत एक इनसेट को दर्शाता है। नकारात्मक प्रतिशत एक आउटसेट को दर्शाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक उदाहरण बनाएँ।  
2. स्लाइड का संदर्भ उसके इंडेक्स द्वारा प्राप्त करें।  
3. एक आयत `AutoShape` जोड़ें।  
4. एक छवि बनाएं।  
5. आकार की भराव टाइप सेट करें।  
6. आकार की चित्र भराव मोड सेट करें।  
7. भराव के लिये सेट छवि जोड़ें।  
8. आकार की बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्दिष्ट करें।  
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह C++ कोड दर्शाता है कि कैसे StretchOff प्रॉपर्टी का उपयोग किया जाता है:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// आकार के बॉडी में प्रत्येक ओर से छवि को विस्तारित करने के लिए सेट करता है
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

### चित्र फ्रेम के लिये कौनसे इमेज फ़ॉर्मेट समर्थित हैं, मैं कैसे पता करूँ?

Aspose.Slides रास्टर इमेज (PNG, JPEG, BMP, GIF, आदि) तथा वेक्टर इमेज (जैसे SVG) को उन इमेज ऑब्जेक्ट्स के द्वारा समर्थन देता है जो एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) से जुड़े होते हैं। समर्थित फ़ॉर्मेट की सूची आमतौर पर स्लाइड और इमेज कन्वर्शन इंजन की क्षमताओं के साथ ओवरलैप करती है।

### बड़ी मात्रा में बड़े इमेज जोड़ने से PPTX का आकार और प्रदर्शन पर क्या असर पड़ेगा?

बड़ी इमेज को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; इमेज को लिंक करने से प्रस्तुति का आकार कम रहता है लेकिन बाहरी फ़ाइलों को सुलभ रखना आवश्यक है। Aspose.Slides लिंक द्वारा इमेज जोड़ने की सुविधा देता है जिससे फ़ाइल आकार घटाया जा सकता है।

### कैसे मैं इमेज ऑब्जेक्ट को अनजाने में स्थानांतरित/रीसाइज़ होने से रोक सकता हूँ?

[shape locks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/get_pictureframelock/) का उपयोग करके आप एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) को लॉक कर सकते हैं (जैसे, मूविंग या रिसाइज़िंग को निष्क्रिय करना)। लॉकिंग मेकैनिज़्म अलग से [protection article](/slides/hi/cpp/applying-protection-to-presentation/) में वर्णित है और विभिन्न shape प्रकारों के लिये समर्थित है, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) भी शामिल है।

### क्या SVG वेक्टर फ़िडेलिटी PDF/इमेज में एक्सपोर्ट करते समय बनी रहती है?

Aspose.Slides एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) से SVG को मूल वेक्टर के रूप में निकालने की सुविधा देता है। जब आप [PDF में एक्सपोर्ट](/slides/hi/cpp/convert-powerpoint-to-pdf/) या [रास्टर फ़ॉर्मेट में](/slides/hi/cpp/convert-powerpoint-to-png/) करते हैं, तो एक्सपोर्ट सेटिंग्स के आधार पर परिणाम रास्टराइज़्ड हो सकता है; मूल SVG को वेक्टर के रूप में संग्रहीत किया जाना निकासी व्यवहार से पुष्टि होती है।