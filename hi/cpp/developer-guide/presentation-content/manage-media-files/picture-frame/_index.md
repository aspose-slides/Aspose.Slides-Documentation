---
title: "C++ का उपयोग करके प्रस्तुतियों में चित्र फ्रेम प्रबंधित करें"
linktitle: "चित्र फ्रेम"
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
- चित्र फ्रेम फ़ॉर्मेटिंग
- चित्र फ्रेम गुण
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ्रेम जोड़ें। अपने कार्यप्रवाह को सुव्यवस्थित करें और स्लाइड डिज़ाइन को सुधारें।"
---
## **परिचय**

एक चित्र फ्रेम वह आकार है जो एक छवि को समाहित करता है—यह फ्रेम में स्थित चित्र जैसा होता है।

आप एक स्लाइड में चित्र फ्रेम के माध्यम से छवि जोड़ सकते हैं। इस प्रकार, आप चित्र फ्रेम को स्वरूपित करके छवि को स्वरूपित कर सकते हैं।

{{% alert  title="टिप" color="primary" %}} 

Aspose मुफ्त रूपांतरक प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से शीघ्र प्रस्तुति बनाने की सुविधा देते हैं। 

{{% /alert %}} 

## **चित्र फ्रेम बनाएं**

1. एक [Presentation class](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) का एक उदाहरण बनाएँ।  
2. उसके अनुक्रमांक (index) के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. वह छवि जो आकार को भरने के लिए उपयोग की जाएगी, उसे प्रस्तुतिकरण वस्तु से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) में जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_p_p_image) ऑब्जेक्ट बनाएँ।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. स्लाइड से जुड़े shape ऑब्जेक्ट द्वारा उजागर `AddPictureFrame` मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_frame) बनाएँ।  
6. स्लाइड में चित्र फ्रेम (जिसमें चित्र है) जोड़ें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह C++ कोड दर्शाता है कि कैसे एक चित्र फ्रेम बनाया जाता है:

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// वांछित प्रस्तुति लोड करें
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> slide = pres->get_Slide(0);

// प्रस्तुति की इमेज कलेक्शन में जोड़ी जाने वाली छवि लोड करता है
// चित्र प्राप्त करता है
auto image = Images::FromFile(filePath);

// प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// स्लाइड में चित्र फ्रेम जोड़ता है
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करता है
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// PictureFrame पर कुछ फ़ॉर्मेटिंग लागू करता है
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

चित्र फ्रेम आपको छवियों के आधार पर शीघ्र प्रस्तुति स्लाइड बनाने की अनुमति देते हैं। जब आप चित्र फ्रेम को Aspose.Slides की सहेजने विकल्पों के साथ संयोजित करते हैं, तो आप इनपुट/आउटपुट संचालन को नियंत्रित करके छवियों को एक स्वरूप से दूसरे में रूपांतरित कर सकते हैं। आप इन पृष्ठों को देखना चाह सकते हैं: रूपांतरण [image to JPG](https://products.aspose.com/slides/hi/cpp/conversion/image-to-jpg/); रूपांतरण [JPG to image](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-image/); रूपांतरण [JPG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-png/), रूपांतरण [PNG to JPG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-jpg/); रूपांतरण [PNG to SVG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-svg/), रूपांतरण [SVG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/svg-to-png/).  

{{% /alert %}}

## **सापेक्ष स्केल के साथ चित्र फ्रेम बनाएं**

छवि के सापेक्ष स्केलिंग को बदलकर, आप अधिक जटिल चित्र फ्रेम बना सकते हैं।

1. एक [Presentation class](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) का एक उदाहरण बनाएँ।  
2. उसके अनुक्रमांक के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. प्रस्तुति की छवि संग्रह में एक छवि जोड़ें।  
4. प्रस्तुति वस्तु से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) में छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_p_p_image) ऑब्जेक्ट बनाएँ।  
5. चित्र फ्रेम में छवि की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह C++ कोड दर्शाता है कि कैसे सापेक्ष स्केल के साथ चित्र फ्रेम बनाया जाता है:

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// वांछित प्रस्तुति लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> slide = pres->get_Slide(0);

// प्रस्तुति इमेज संग्रह में जोड़ी जाने वाली छवि लोड करता है
// चित्र प्राप्त करता है
auto image = Images::FromFile(filePath);

// प्रस्तुति की इमेज संग्रह में एक छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// स्लाइड में चित्र फ्रेम जोड़ता है
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करता है
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **चित्र फ्रेम से रास्टर छवियां निकालें**

आप [PictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_frame) ऑब्जेक्ट्स से रास्टर छवियां निकाल सकते हैं और उन्हें PNG, JPG आदि स्वरूपों में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण यह दर्शाता है कि दस्तावेज़ "sample.pptx" से छवि को निकालकर PNG स्वरूप में कैसे सहेजा जाए।

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

## **चित्र फ्रेम से SVG छवियां निकालें**

जब कोई प्रस्तुति SVG ग्राफिक्स को [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) आकारों के भीतर रखती है, तो Aspose.Slides for C++ आपको मूल वेक्टर छवियों को पूर्ण शुद्धता के साथ पुनः प्राप्त करने देता है। स्लाइड के shape संग्रह को पार करते हुए, आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) को पहचान सकते हैं, जाँच सकते हैं कि अंतर्निहित [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) में SVG सामग्री है या नहीं, और फिर उस छवि को उसकी मूल SVG स्वरूप में डिस्क या स्ट्रीम पर सहेज सकते हैं।

निम्नलिखित कोड उदाहरण दिखाता है कि कैसे एक चित्र फ्रेम से SVG छवि निकाली जाए:

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

## **छवि की पारदर्शिता प्राप्त करें**

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव प्राप्त करने की सुविधा देता है। यह C++ कोड इस क्रिया को दर्शाता है:

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
छवियों पर लागू सभी प्रभावों को आप [Aspose::Slides::Effects](https://reference.aspose.com/slides/hi/cpp/aspose.slides.effects/) में देख सकते हैं।  
{{% /alert %}}

## **चित्र फ्रेम फ़ॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जिन्हें आप चित्र फ्रेम पर लागू कर सकते हैं। इन विकल्पों का उपयोग करके आप चित्र फ्रेम को विशिष्ट आवश्यकताओं के अनुसार बदल सकते हैं।

1. एक [Presentation class](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) का एक उदाहरण बनाएँ।  
2. उसके अनुक्रमांक के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. प्रस्तुति वस्तु से जुड़ी [IImagescollection](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_image_collection) में छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_p_p_image) ऑब्जेक्ट बनाएँ।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. स्लाइड से जुड़े [IShapes](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection) ऑब्जेक्ट द्वारा उजागर [AddPictureFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) मेथड के माध्यम से छवि की चौड़ाई और ऊँचाई के आधार पर एक `PictureFrame` बनाएँ।  
6. स्लाइड में चित्र फ्रेम (जिसमें चित्र है) जोड़ें।  
7. चित्र फ्रेम की रेखा का रंग सेट करें।  
8. चित्र फ्रेम की रेखा की चौड़ाई सेट करें।  
9. चित्र फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है।  
   * नकारात्मक मान छवि को प्रतिगामी दिशा में घुमाता है।  
10. चित्र फ्रेम (जिसमें चित्र है) को फिर से स्लाइड में जोड़ें।  
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह C++ कोड चित्र फ्रेम फ़ॉर्मेटिंग प्रक्रिया को दर्शाता है:

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// वांछित प्रस्तुति लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// प्रस्तुति इमेज संग्रह में जोड़ी जाने वाली छवि लोड करता है
// चित्र प्राप्त करता है
auto image = Images::FromFile(filePath);

// प्रस्तुति की इमेज संग्रह में छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// स्लाइड में चित्र फ्रेम जोड़ता है
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करता है
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="टिप" color="primary" %}}

Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मिलाना हो, या [फ़ोटो ग्रिड](https://products.aspose.app/slides/hi/collage/photo-grid) बनाना हो, तो आप इस सेवा का उपयोग कर सकते हैं।  

{{% /alert %}}

## **एक छवि को लिंक के रूप में जोड़ें**

बड़ी प्रस्तुति आकारों से बचने के लिए, आप छवियों (या वीडियो) को लिंक के माध्यम से जोड़ सकते हैं, बजाय इसके कि फ़ाइलों को सीधे प्रस्तुति में एम्बेड किया जाए। यह C++ कोड आपको दिखाता है कि कैसे एक प्लेसहोल्डर में छवि और वीडियो जोड़ें:

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

यह C++ कोड दर्शाता है कि स्लाइड पर मौजूदा छवि को कैसे क्रॉप किया जाए:

```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// नई छवि ऑब्जेक्ट बनाता है
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// स्लाइड में एक PictureFrame जोड़ता है
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// छवि को क्रॉप करता है (प्रतिशत मान)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// परिणाम को सहेजता है
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **चित्र फ्रेम के क्रॉप किए गए क्षेत्रों को हटाएँ**

यदि आप फ्रेम में निहित छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ipicturefillformat/deletepicturecroppedareas/) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।

यह C++ कोड इस क्रिया को दर्शाता है:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="ध्यान दें" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ipicturefillformat/deletepicturecroppedareas/) मेथड क्रॉप की गई छवि को प्रस्तुति की छवि संग्रह में जोड़ता है। यदि छवि केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) में उपयोग की गई है, तो यह सेटअप प्रस्तुति आकार को कम कर सकता है। अन्यथा, परिणामस्वरूप प्रस्तुति में छवियों की संख्या बढ़ सकती है।

यह मेथड क्रॉपिंग प्रक्रिया में WMF/EMF मेटाफाइल को रास्टर PNG छवि में बदलता है।  

{{% /alert %}}

## **छवियों को संकुचित करें**

आप प्रस्तुति में किसी चित्र को [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ipicturefillformat/compressimage/) मेथड का उपयोग करके संकुचित कर सकते हैं। यह मेथड आकार को आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर घटाता है, तथा आवश्यक होने पर क्रॉप किए गए क्षेत्रों को हटाने का विकल्प देता है।

यह PowerPoint की **Picture Format → Compress Pictures → Resolution** सुविधा के समान रूप से चित्र का आकार और रिज़ॉल्यूशन समायोजित करता है।

निम्नलिखित C++ उदाहरण दिखाते हैं कि लक्ष्य रिज़ॉल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में छवि को कैसे संकुचित किया जाए:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// छवि को 150 DPI (वेब रिज़ॉल्यूशन) लक्ष्य रिज़ॉल्यूशन के साथ संकुचित करें और क्रॉप किए हुए क्षेत्रों को हटाएँ।
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// संकुचन के परिणाम की जाँच करें।
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

// छवि को 150 DPI (वेब रिज़ॉल्यूशन) तक संकुचित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="ध्यान दें" color="warning" %}}

यह मेथड आकार को shape के आकार और प्रदान किए गए DPI के आधार पर कम रिज़ॉल्यूशन में बदलता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप किए गए क्षेत्रों को भी हटाया जा सकता है। यदि छवि एक मेटाफाइल (WMF/EMF) या SVG है, तो संकुचन लागू नहीं होगा। JPEG की गुणवत्ता भी रिज़ॉल्यूशन के आधार पर संग्रहीत या थोड़ा घटाया जाता है, ठीक उसी प्रकार जैसे PowerPoint उच्च‑रिज़ॉल्यूशन JPEG को संभालता है।  

{{% /alert %}}

## **आस्पेक्ट अनुपात लॉक करें**

यदि आप चाहते हैं कि छवि वाला shape छवि के आयाम बदलने के बाद भी अपना आस्पेक्ट अनुपात बरकरार रखे, तो आप [set_AspectRatioLocked()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ipictureframelock/set_aspectratiolocked/) मेथड का उपयोग करके *Lock Aspect Ratio* सेटिंग सेट कर सकते हैं।

यह C++ कोड दिखाता है कि कैसे shape के आस्पेक्ट अनुपात को लॉक किया जाए:

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

{{% alert title="ध्यान दें" color="warning" %}} 

यह *Lock Aspect Ratio* सेटिंग केवल shape के आस्पेक्ट अनुपात को संजोती है, न कि उसमें निहित छवि को।  

{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

[IPictureFillFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_picture_fill_format) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format) क्लास की [StretchOffsetLeft](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) प्रॉपर्टीज़ का उपयोग करके आप एक फाइल भरने वाला rectangle निर्धारित कर सकते हैं।

जब छवि के स्ट्रेचिंग को निर्दिष्ट किया जाता है, तो स्रोत rectangle को निर्दिष्ट fill rectangle में फिट होने के लिए स्केल किया जाता है। fill rectangle के प्रत्येक किनारे को shape के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित किया जाता है। सकारात्मक प्रतिशत एक अंतर्निहित (inset) को दर्शाता है। नकारात्मक प्रतिशत एक बहिर्निहित (outset) को दर्शाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक उदाहरण बनाएँ।  
2. उसके अनुक्रमांक के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. एक `AutoShape` rectangle जोड़ें।  
4. एक छवि बनाएँ।  
5. shape के fill प्रकार को सेट करें।  
6. shape के picture fill मोड को सेट करें।  
7. shape को भरने के लिए सेट छवि जोड़ें।  
8. shape के बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्दिष्ट करें।  
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह C++ कोड दर्शाता है कि कैसे StretchOff प्रॉपर्टी का उपयोग किया जाता है:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// आकार बॉडी के प्रत्येक पक्ष से छवि स्ट्रेच सेट करता है
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि PictureFrame के लिए कौन-से छवि स्वरूप समर्थित हैं?**

Aspose.Slides छवि ऑब्जेक्ट के माध्यम से [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) में रास्टर छवियां (PNG, JPEG, BMP, GIF, आदि) तथा वेक्टर छवियां (जैसे SVG) दोनों का समर्थन करता है। समर्थित स्वरूपों की सूची सामान्यतः स्लाइड और छवि रूपांतरण इंजन की क्षमताओं के साथ ओवरलैप करती है।

**सैकड़ों बड़ी छवियों को जोड़ने से PPTX आकार और प्रदर्शन पर क्या प्रभाव पड़ेगा?**

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; छवियों को लिंक करने से प्रस्तुति का आकार कम रहता है, परन्तु बाहरी फ़ाइलों को सुलभ रखना आवश्यक है। Aspose.Slides लिंक द्वारा छवियों को जोड़ने की सुविधा प्रदान करता है जिससे फ़ाइल आकार घटाया जा सकता है।

**मैं कैसे एक छवि ऑब्जेक्ट को आकस्मिक मूव/रिसाइज़ से लॉक करूँ?**

आप [shape locks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/get_pictureframelock/) का उपयोग करके एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) को लॉक कर सकते हैं (उदाहरण के लिए, मूव या रिसाइज़ को निष्क्रिय करना)। लॉकिंग तंत्र shape के लिए अलग [protection article](/slides/hi/cpp/applying-protection-to-presentation/) में वर्णित है और विभिन्न shape प्रकारों, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) भी शामिल है, के लिये समर्थित है।

**क्या SVG वेक्टर फ़िडेलिटी PDF/छवियों में निर्यात करते समय बरकरार रहती है?**

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने की अनुमति देता है। जब आप [PDF के रूप में निर्यात](/slides/hi/cpp/convert-powerpoint-to-pdf/) या [रास्टर स्वरूपों](/slides/hi/cpp/convert-powerpoint-to-png/) में निर्यात करते हैं, तो परिणाम निर्यात सेटिंग्स पर निर्भर करता है; मूल SVG को वेक्टर के रूप में संग्रहीत रहने की पुष्टि निकासी व्यवहार से होती है।