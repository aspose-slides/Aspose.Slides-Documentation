---
title: C++ का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/cpp/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- छवि जोड़ें
- छवि बनाएं
- छवि निकालें
- रास्टर छवि
- वेक्टर छवि
- छवि क्रॉप करें
- क्रॉप किया गया क्षेत्र
- StretchOff प्रॉपर्टी
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- पिक्चर फ्रेम प्रॉपर्टी
- सापेक्ष स्केल
- छवि इफ़ेक्ट
- आस्पेक्ट रेशियो
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों में पिक्चर फ्रेम जोड़ें। अपने कार्यप्रवाह को सुगम बनाएं और स्लाइड डिज़ाइन को बेहतर बनाएं।"
---
## **परिचय**

एक पिक्चर फ्रेम एक ऐसा आकार है जो एक छवि को समेटे रहता है—यह फ्रेम में चित्र की तरह है।

आप एक पिक्चर फ्रेम के माध्यम से स्लाइड में छवि जोड़ सकते हैं। इस प्रकार, आप पिक्चर फ्रेम को फ़ॉर्मेट करके छवि को फ़ॉर्मेट कर सकते हैं।

{{% alert  title="Tip" color="primary" %}} 
Aspose मुफ्त कनवर्टर्स प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो उपयोगकर्ताओं को छवियों से जल्दी प्रस्तुतियां बनाने की अनुमति देते हैं।
{{% /alert %}} 

## **एक पिक्चर फ्रेम बनाएं**

1. [Presentation class](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. प्रस्तुति ऑब्जेक्ट से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_p_p_image) ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. रेफ़रेंस किए गए स्लाइड से जुड़े शैप ऑब्जेक्ट द्वारा उपलब्ध `AddPictureFrame` मेथड का उपयोग करके, छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_frame) बनाएं।
6. स्लाइड में एक पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// इच्छित प्रस्तुति लोड करें
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचें
SharedPtr<ISlide> slide = pres->get_Slide(0);

// प्रस्तुति इमेज कलेक्शन में जोड़ी जाने वाली छवि लोड करता है
// चित्र प्राप्त करता है
auto image = Images::FromFile(filePath);

// प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// स्लाइड में एक पिक्चर फ्रेम जोड़ता है
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// रिलेटिव स्केल की चौड़ाई और ऊँचाई सेट करता है
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// पिक्चर फ्रेम पर कुछ फ़ॉर्मेटिंग लागू करता है
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Writes the PPTX file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
पिक्चर फ्रेम आपको छवियों के आधार पर जल्दी प्रस्तुति स्लाइड बनाने की अनुमति देते हैं। जब आप पिक्चर फ्रेम को Aspose.Slides के सहेजने विकल्पों के साथ मिलाते हैं, तो आप इनपुट/आउटपुट ऑपरेशन्स को नियंत्रित करके छवियों को एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में परिवर्तित कर सकते हैं। आप निम्न पेज देख सकते हैं: convert [image to JPG](https://products.aspose.com/slides/hi/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/svg-to-png/)।
{{% /alert %}}

## **रिलेटिव स्केल के साथ पिक्चर फ्रेम बनाएं**

इमेज के रिलेटिव स्केल को बदलकर आप अधिक जटिल पिक्चर फ्रेम बना सकते हैं। 

1. [Presentation class](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. प्रस्तुति इमेज कलेक्शन में एक छवि जोड़ें।
4. प्रस्तुति ऑब्जेक्ट से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_p_p_image) ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।
5. पिक्चर फ्रेम में छवि की रिलेटिव चौड़ाई और ऊँचाई निर्दिष्ट करें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// इच्छित प्रस्तुति लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> slide = pres->get_Slide(0);

// प्रस्तुति इमेज कलेक्शन में जोड़ी जाने वाली छवि लोड करता है
// चित्र प्राप्त करता है
auto image = Images::FromFile(filePath);

// प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// स्लाइड में एक पिक्चर फ्रेम जोड़ता है
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// रिलेटिव स्केल की चौड़ाई और ऊँचाई सेट करता है
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes the PPTX file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **पिक्चर फ्रेम से रास्टर छवियों को निकालें**

[PictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_frame) ऑब्जेक्ट्स से रास्टर छवियों को निकाल सकते हैं और उन्हें PNG, JPG आदि फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि दस्तावेज़ "sample.pptx" से छवि को निकालकर PNG फ़ॉर्मेट में कैसे सहेजा जाए। 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **पिक्चर फ्रेम से SVG छवियों को निकालें**

जब कोई प्रस्तुति SVG ग्राफिक्स को [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) आकारों के भीतर रखती है, तो Aspose.Slides for C++ आपको मूल वेक्टर छवियों को पूरी सटीकता के साथ पुनः प्राप्त करने देता है। स्लाइड की शैप कलेक्शन को ट्रैवर्स करके आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि अंतर्निहित [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) में SVG सामग्री है या नहीं, और फिर उस छवि को डिस्क या स्ट्रीम में उसके मूल SVG फ़ॉर्मेट में सहेज सकते हैं।

```cpp
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

## **छवि की ट्रांसपरेंसी प्राप्त करें**

Aspose.Slides आपको छवि पर लागू ट्रांसपरेंसी इफ़ेक्ट को प्राप्त करने की अनुमति देता है। यह C++ कोड इस ऑपरेशन को प्रदर्शित करता है:

```c++
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

{{% alert color="primary" %}} 
छवियों पर लागू सभी इफ़ेक्ट्स [Aspose::Slides::Effects](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/) में पाए जा सकते हैं।
{{% /alert %}}

## **छवि की ब्राइटनेस और कंट्रास्ट प्राप्त करें**

Aspose.Slides आपको छवि पर लागू ब्राइटनेस और कंट्रास्ट इफ़ेक्ट को प्राप्त करने की अनुमति देता है। [ILuminance](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/iluminance/) इंटरफ़ेस इस इमेज ट्रांसफ़ॉर्म इफ़ेक्ट का प्रतिनिधित्व करता है।

यह C++ कोड पिक्चर फ्रेम से ब्राइटनेस और कंट्रास्ट सेटिंग्स प्राप्त करने को दर्शाता है:

```c++
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

## **पिक्चर फ्रेम फॉर्मेटिंग**

Aspose.Slides कई फॉर्मेटिंग विकल्प प्रदान करता है जिन्हें पिक्चर फ्रेम पर लागू किया जा सकता है। इन विकल्पों का उपयोग करके आप पिक्चर फ्रेम को इस प्रकार बदल सकते हैं कि वह विशिष्ट आवश्यकताओं को पूरा करे।

1. [Presentation class](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. प्रस्तुति ऑब्जेक्ट से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) में एक छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_p_p_image) ऑब्जेक्ट बनाएं, जिसका उपयोग आकार को भरने के लिए किया जाएगा।
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।
5. रेफ़रेंस किए गए स्लाइड से जुड़े [IShapes](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection) ऑब्जेक्ट द्वारा उपलब्ध [AddPictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) मेथड का उपयोग करके, छवि की चौड़ाई और ऊँचाई के आधार पर एक `PictureFrame` बनाएं।
6. स्लाइड में पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।
7. पिक्चर फ्रेम की लाइन रंग सेट करें।
8. पिक्चर फ्रेम की लाइन चौड़ाई सेट करें।
9. पिक्चर फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है। 
   * नकारात्मक मान छवि को प्रतिक्लॉकवाइज़ घुमाता है।
10. स्लाइड में पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें।
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// इच्छित प्रस्तुति लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// प्रस्तुति इमेज कलेक्शन में जोड़ी जाने वाली छवि लोड करता है
// चित्र प्राप्त करता है
auto image = Images::FromFile(filePath);

// प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// स्लाइड में एक पिक्चर फ्रेम जोड़ता है
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// रिलेटिव स्केल की चौड़ाई और ऊँचाई सेट करता है
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose ने हाल ही में एक मुफ्त कोलाज मेकर [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [merge JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मर्ज करना हो, या फोटो से ग्रिड बनाना हो, तो आप इस सेवा का उपयोग कर सकते हैं। 
{{% /alert %}}

## **एक लिंक के रूप में छवि जोड़ें**

बड़ी प्रस्तुति फ़ाइलों के आकार को कम करने के लिए, आप छवियों (या वीडियो) को लिंक के माध्यम से जोड़ सकते हैं, बजाय इसके कि फ़ाइलों को सीधे प्रस्तुति में एम्बेड किया जाए। यह C++ कोड दिखाता है कि प्लेसहोल्डर में छवि और वीडियो कैसे जोड़ें:

```cpp
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

## **छवियों को क्रॉप करें**

यह C++ कोड दिखाता है कि स्लाइड पर मौजूद छवि को कैसे क्रॉप किया जाए: 

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// नई छवि ऑब्जेक्ट बनाता है
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// स्लाइड में एक पिक्चर फ्रेम जोड़ता है
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// छवि को क्रॉप करता है (प्रतिशत मान)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// परिणाम सहेजता है
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **पिक्चर के क्रॉप किए गए क्षेत्रों को हटाएँ**

यदि आप फ्रेम में सम्मिलित छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि को लौटाता है यदि क्रॉप करना आवश्यक नहीं है।

```c++
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
[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) मेथड क्रॉप की गई छवि को प्रस्तुति इमेज कलेक्शन में जोड़ता है। यदि छवि केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) में उपयोग हुई है, तो यह सेटअप प्रस्तुति का आकार कम कर सकता है। अन्यथा, परिणामस्वरूप प्रस्तुति में छवियों की संख्या बढ़ जाएगी।

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मेटाफाइल को रास्टर PNG छवि में परिवर्तित करता है। 
{{% /alert %}}

## **छवियों को संकुचित करें**

आप प्रस्तुति में एक चित्र को [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/compressimage/) मेथड का उपयोग करके संकुचित कर सकते हैं।
यह मेथड आकार को शैप के आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर घटाकर, तथा क्रॉप किए हुए क्षेत्रों को हटाने के विकल्प के साथ, छवि को संकुचित करता है।

यह चित्र का आकार और रिज़ॉल्यूशन को PowerPoint की **Picture Format -> Compress Pictures -> Resolution** सुविधा के समान समायोजित करता है।

निम्न C++ उदाहरण दर्शाते हैं कि लक्ष्य रिज़ॉल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए हुए क्षेत्रों को हटाकर प्रस्तुति में छवि को कैसे संकुचित किया जाए:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// लक्ष्य रिज़ॉल्यूशन 150 DPI (वेब रिज़ॉल्यूशन) के साथ छवि को संपीड़ित करें और क्रॉप किए गए क्षेत्रों को हटाएँ।
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// संपीड़न के परिणाम की जाँच करें।
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
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// छवि को 150 DPI (वेब रिज़ॉल्यूशन) पर संपीड़ित करता है, क्रॉप किए गए क्षेत्रों को हटाते हुए।
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
यह मेथड शैप के आकार और प्रदान किए गए DPI के आधार पर छवि को कम रिज़ॉल्यूशन में परिवर्तित करता है। क्रॉप किए गए क्षेत्रों को भी फ़ाइल आकार को अनुकूलित करने के लिए हटाया जा सकता है।
यदि छवि एक मेटाफाइल (WMF/EMF) या SVG है, तो संपीड़न लागू नहीं होगा। साथ ही, JPEG की गुणवत्ता रिज़ॉल्यूशन के अनुसार बरकरार या थोड़ी घटाई जाएगी, जैसा कि PowerPoint उच्च‑रिज़ॉल्यूशन JPEG को संभालता है।
{{% /alert %}}

## **आस्पेक्ट रेशियो लॉक करें**

यदि आप चाहते हैं कि छवि वाला शैप इमेज के आयाम बदलने के बाद भी अपना आस्पेक्ट रेशियो बनाए रखे, तो आप *Lock Aspect Ratio* सेटिंग को सेट करने के लिए [set_AspectRatioLocked()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) मेथड का उपयोग कर सकते हैं। 

यह C++ कोड दिखाता है कि शैप के आस्पेक्ट रेशियो को कैसे लॉक किया जाए:

```c++
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
यह *Lock Aspect Ratio* सेटिंग केवल शैप के आस्पेक्ट रेशियो को सुरक्षित रखती है, न कि उसके अंदर की छवि को।
{{% /alert %}}

## **StretchOff प्रॉपर्टी का प्रयोग करें**

[IPictureFillFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_picture_fill_format) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format) क्लास से [StretchOffsetLeft](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) प्रॉपर्टीज़ का उपयोग करके आप एक फ़िल रेक्टैंगल निर्दिष्ट कर सकते हैं। 

जब छवि के स्ट्रेचिंग को निर्दिष्ट किया जाता है, तो स्रोत रेक्टैंगल को निर्दिष्ट फ़िल रेक्टैंगल में फिट होने के लिए स्केल किया जाता है। फ़िल रेक्टैंगल का प्रत्येक किनारा शैप के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा निर्धारित होता है। सकारात्मक प्रतिशत इनसेट को दर्शाता है। नकारात्मक प्रतिशत आउटसेट को दर्शाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक रेक्टैंगल `AutoShape` जोड़ें। 
4. एक छवि बनाएं।
5. शैप की फ़िल टाइप सेट करें।
6. शैप की पिक्चर फ़िल मोड सेट करें।
7. शैप को भरने के लिए एक इमेज सेट करें।
8. शैप के बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफ़सेट निर्दिष्ट करें।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// आकार के बॉडी के प्रत्येक किनारे से छवि को स्ट्रेच करता है
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**PictureFrame के लिए कौन से इमेज फ़ॉर्मेट समर्थित हैं, यह कैसे पता करूं?**

Aspose.Slides दोनों रास्टर इमेज (PNG, JPEG, BMP, GIF आदि) और वेक्टर इमेज (जैसे SVG) को सपोर्ट करता है, जो कि एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) को असाइन किए गए इमेज ऑब्जेक्ट के माध्यम से होता है। समर्थित फ़ॉर्मेटों की सूची आम तौर पर स्लाइड और इमेज कन्वर्ज़न इंजन की क्षमताओं के साथ ओवरलैप करती है।

**दसियों बड़ी छवियों को जोड़ने से PPTX का आकार और प्रदर्शन पर क्या असर पड़ेगा?**

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; लिंक के माध्यम से छवियों को जोड़ने से प्रस्तुति का आकार घटता है, लेकिन इसके लिए बाहरी फ़ाइलों का सुलभ रहना आवश्यक है। Aspose.Slides लिंक के द्वारा छवियों को जोड़ने की सुविधा प्रदान करता है जिससे फ़ाइल आकार कम किया जा सके।

**इमेज ऑब्जेक्ट को आकस्मिक रूप से मूव/रिज़ाइज़ होने से कैसे लॉक करूँ?**

[shape locks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/get_pictureframelock/) का उपयोग करके आप एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) (उदाहरण के लिए, मूव या रिसाइज़ को डिसेबल करना) को लॉक कर सकते हैं। लॉकिंग मैकेनिज़्म शैप्स के लिए एक अलग [protection article](/slides/hi/cpp/applying-protection-to-presentation/) में वर्णित है और विभिन्न शैप टाइप्स जैसे कि [PictureFrame] के लिए सपोर्टेड है।

**प्रेज़ेंटेशन को PDF/इमेज में एक्सपोर्ट करने पर SVG वेक्टर की फिडेलिटी बनी रहती है क्या?**

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG को निकालने की अनुमति देता है। जब [PDF में एक्सपोर्ट](/slides/hi/cpp/convert-powerpoint-to-pdf/) या [रास्टर फ़ॉर्मेट्स](/slides/hi/cpp/convert-powerpoint-to-png/) में आउटपुट किया जाता है, तो एक्सपोर्ट सेटिंग्स के आधार पर परिणाम रास्टराइज़ हो सकता है; मूल SVG वेक्टर के रूप में संग्रहीत रहता है यह एक्सट्रैक्शन व्यवहार द्वारा पुष्टि होती है।