---
title: C++ का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम्स को प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/cpp/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एम्बेडेड इमेज
- लिंक्ड इमेज
- इमेज निकालें
- रास्टर इमेज
- SVG इमेज
- इमेज क्रॉप करें
- क्रॉप किए गए क्षेत्रों को हटाएँ
- इमेज संपीड़ित करें
- StretchOffset
- पिक्चर फ्रेम फॉर्मेटिंग
- सापेक्ष स्केल
- इमेज इफ़ेक्ट
- आस्पेक्ट अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुतियों में पिक्चर फ्रेम्स को बनाएं, फॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संपीड़ित करें।"
---
## **अवलोकन**

एक picture frame एक slide shape है जो एक image प्रदर्शित करता है। Aspose.Slides में, image resource और shape जो इसे दिखाता है अलग-अलग objects हैं: एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) अपने एम्बेडेड image resources को अपने [छवि संग्रह](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_images/) के माध्यम से रखता है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) image की स्थिति, आकार, रेखा स्वरूपण, घूर्णन, क्रॉपिंग, picture effects और अन्य frame‑level सेटिंग्स को नियंत्रित करता है।

यह विभाजन तब उपयोगी है जब एक ही image को कई बार दिखाया जाता है। image को presentation में एक बार जोड़ें, लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) को रखें, और picture frames बनाते समय उस image resource का उपयोग करें।

Picture frames PNG या JPEG जैसे raster images और SVG जैसे vector images दोनों को समाहित कर सकते हैं। वे image bytes को presentation में संग्रहीत करने के बजाय लिंक किए गए images को भी संदर्भित कर सकते हैं। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण और निर्यात व्यवहार को प्रभावित करता है, इसलिए स्वरूपण या अनुकूलन लागू करने से पहले यह तय करना उपयोगी है कि image कैसे संग्रहीत की जानी चाहिए।

## **एक एम्बेडेड इमेज जोड़ें और स्वरूपित करें**

एक एम्बेडेड इमेज के लिए, image डेटा को presentation में जोड़ें और [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapecollection/addpictureframe/) के साथ एक picture frame बनाएं। image प्रस्तुति पैकेज का हिस्सा बन जाता है, इसलिए presentation को किसी अन्य कंप्यूटर पर ले जाने पर वह self‑contained रहता है।

निम्नलिखित उदाहरण JPEG image जोड़ता है, image के मूल आयामों पर एक frame बनाता है, और रेखा स्वरूपण तथा घूर्णन लागू करता है:

```cpp
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
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

picture frame प्रदर्शित geometry को नियंत्रित करता है; frame आकार बदलने से एम्बेडेड image resource में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में image को क्रॉप या संपीड़ित करने पर महत्वपूर्ण हो जाता है।

## **सापेक्ष स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) फ्रेम के लिए सापेक्ष चौड़ाई और ऊँचाई स्केलिंग को उजागर करता है। `1.0` मान मूल picture आकार के 100 % के बराबर है। सापेक्ष स्केल तब उपयोगी होता है जब workflow को स्रोत image आकार के साथ संबंध बनाए रखना पड़ता है, न कि मैन्युअल रूप से अंतिम आयामों की गणना करनी पड़ती है।

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

सापेक्ष स्केल फ्रेम की स्केल सेटिंग्स को बदलता है; यह एम्बेडेड image को पुनः नमूना या संपीड़ित नहीं करता।

## **एम्बेडेड और लिंक्ड इमेजेज़**

एक एम्बेडेड picture image डेटा को presentation के भीतर संग्रहीत करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमेय रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड picture [ISlidesPicture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidespicture/) लिंक पथ के माध्यम से बाहरी स्थान को संग्रहीत करता है, न कि समान तरीके से image डेटा को एम्बेड करता है।

लिंक्ड images PPTX में संग्रहीत image डेटा की मात्रा को कम कर सकते हैं, लेकिन वे बाहरी निर्भरताएँ लाते हैं। लिंक्ड फ़ाइल उस एप्लिकेशन के लिए सुलभ रहनी चाहिए जो presentation को खोलता या रेंडर करता है। यदि पथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या resource अनुपलब्ध हो जाता है, तो लिंक्ड picture अपेक्षित रूप से प्रदर्शित नहीं हो सकता। ईमेल, अभिलेख या अलगाव वाले वातावरण में रेंडर करने के लिए तैयार प्रस्तुतियों के लिए एम्बेडेड images आमतौर पर अधिक भरोसेमंद होते हैं।

### **एक लिंक्ड इमेज जोड़ें**

निम्नलिखित उदाहरण एक picture frame बनाता है और उसे स्थानीय image फ़ाइल की ओर इंगित करता है। यह केवल image लिंकिंग को संभालता है; वीडियो लिंकिंग एक अलग मीडिया workflow है और जानबूझकर इस उदाहरण में मिश्रित नहीं किया गया है।

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

जब बाहरी फ़ाइल प्रबंधन इरादतन होता है तो लिंक का उपयोग करें। उन्हें केवल संपीड़न का विकल्प बनाने के लिए न उपयोग करें: टूटा हुआ image निर्भरताओं वाला छोटा PPTX अक्सर बड़े self‑contained presentation से कम उपयोगी होता है।

## **Picture Frames से Images निकालें**

किसी मौजूदा presentation से image निकालने से पहले, जाँचें कि shape वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) है और उसमें एम्बेडेड image सम्मिलित है। लिंक्ड picture frames में ऐसे image bytes नहीं हो सकते जिन्हें उसी तरह निकाला जा सके।

### **एक Raster Image निकालें**

आधुनिक image API सीधे [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) का उपयोग करता है। निम्नलिखित उदाहरण स्लाइड पर पहली एम्बेडेड raster picture को खोजता है और उसे PNG के रूप में सहेजता है:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

[IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) के माध्यम से सहेजने से निकाले गए image को अनुरोधित आउटपुट फ़ॉर्मेट में बदल दिया जाता है। यदि आपको presentation में संग्रहीत एन्कोडेड बाइट्स चाहिए, न कि परिवर्तित raster फ़ाइल, तो image resource के बाइनरी डेटा का उपयोग करें।

### **एक SVG Image निकालें**

एक SVG picture के लिए, [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) ऑब्जेक्ट उजागर करता है। यह आपको SVG डेटा को सीधे प्राप्त करने देता है, बजाय पहले picture को rasterize करने के।

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
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

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

SVG कंटेंट को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसे raster निर्यात अनिवार्य रूप से उस वेक्टर कंटेंट को पिक्सेल में रेंडर करते हैं। PDF या SVG स्लाइड निर्यात भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यातित ग्राफिक्स को मूल एम्बेडेड SVG की बाइट‑फ़ॉर‑बाइट कॉपी नहीं माना जाना चाहिए; मूल वेक्टर रिसोर्स की आवश्यकता होने पर एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) डेटा का उपयोग करें।

## **एक Image को क्रॉप करें**

क्रॉपिंग यह बदलता है कि फ्रेम के भीतर image का कौन सा भाग दिखाई देता है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/) पर क्रॉप मान स्रोत image आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारम्भ में एम्बेडेड image से छिपे पिक्सेल को नहीं हटाती; यह केवल दृश्यमान क्षेत्र को बदलती है।

निम्नलिखित उदाहरण एक picture frame को सुरक्षित रूप से खोजता है और क्रॉप मान लागू करता है:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

छिपा image डेटा अभी भी मौजूद होने के कारण, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार को उलटने की तुलना में अधिक महत्व हो, तो अगला अनुभाग बताता है कि क्रॉप किए गए क्षेत्रों को शारीरिक रूप से कैसे हटाया जाए।

## **क्रॉप किए गए Image डेटा को हटाएँ**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) वर्तमान क्रॉप आयत के बाहर के image डेटा को हटाता है और resulting image resource को लौटाता है। यह फ़ाइल आकार को कम कर सकता है, लेकिन यह एक विनाशकारी अनुकूलन है: प्रस्तुति को सहेजने के बाद हटाए गए पिक्सेल बाद में अनक्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहते।

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
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
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

यह विधि प्रस्तुति में एक नया image resource जोड़ सकती है। यदि मूल image का उपयोग अन्य picture frames भी करते हैं, तो इन फ्रेमों को अभी भी अपना मौजूदा resource चाहिए, इसलिए क्रॉप किए गए क्षेत्रों को हटाने से जरूरी नहीं कि कुल image संख्या घटे। WMF या EMF कंटेंट को इस विधि से क्रॉप करने से परिणाम PNG में rasterize हो जाता है।

## **Raster Images को संपीड़ित करें**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/compressimage/) picture के प्रदर्शित आकार के सापेक्ष raster image रिज़ॉल्यूशन को घटाता है। यह उसी ऑपरेशन में क्रॉप किए गए क्षेत्रों को भी हटा सकता है। जब image को री‑साइज़ या क्रॉप किया गया हो तो यह विधि `true` लौटाती है और जब कोई परिवर्तन आवश्यक न हो तो `false`।

जब मानक लक्षित रिज़ॉल्यूशन पर्याप्त हो, तो एक पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/picturescompression/) मान का उपयोग करें:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

यदि विशिष्ट लक्ष्य आवश्यक हो तो enum मान के बजाय एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

संपीड़न raster images के लिए अभिप्रेत है। SVG और मेटाफाइल कंटेंट इस raster संपीड़न workflow द्वारा नहीं घटाया जाता। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप क्षेत्रों को अनुकूलित presentation से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर image वास्तव में देखा या निर्यात किया जाएगा, न कि पूरे दस्तावेज़ पर सर्वनिम्न DPI लागू करके।

## **Image Effects की जाँच करें**

Picture effects frame द्वारा उपयोग किए गए picture पर संग्रहीत होते हैं। image transform संग्रह में transparency के लिए fixed alpha modulation और brightness‑contrast के लिए luminance जैसे प्रभाव हो सकते हैं। नीचे दिया गया उदाहरण स्लाइड पर पहले picture frame से दोनों प्रकार के प्रभाव सुरक्षित रूप से पढ़ता है:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
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

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

ये प्रभाव यह बदलते हैं कि image फ्रेम में कैसे रेंडर होती है; ये मूल एम्बेडेड image बाइट्स को पुनः लिखते नहीं हैं।

## **Picture Frame Geometry को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि picture frame पर कौन‑से संपादन कार्य निष्क्रिय हों। उदाहरण के लिए, [aspect-ratio lock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) आकार बदलते समय shape के अनुपात को बरकरार रखता है।

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

लॉक picture frame shape पर लागू होता है। यह स्रोत image को पुनः नमूना करने या स्थायी रूप से उसी aspect ratio में बदलने को बाध्य नहीं करता।

## **StretchOffset मानों को समायोजित करें**

जब picture fill मोड stretch हो, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/) पर stretch‑offset मान picture frame की bounding box के सापेक्ष fill आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक inset बनाते हैं, जबकि नकारात्मक प्रतिशत एक outset बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत image के किस भाग को दिखाना है यह चुनते हैं; stretch offsets वह आयत बदलते हैं जिसमें दृश्य picture fill खींची जाती है।

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

fill स्थान निर्धारण के लिए stretch offsets का उपयोग करें। स्रोत‑image किनारों को छिपाने के लक्ष्य के लिए crop गुणों का उपयोग करें।

## **भंडारण, फ़ाइल आकार, और निर्यात विचार**

जब image भंडारण और picture‑frame स्वरूपण को अलग‑अलग संभाला जाता है तो मुख्य समझौते प्रबंधित करना आसान हो जाता है:

- **Embedded images** presentation को self‑contained बनाते हैं और साझा करने और सर्वर‑साइड रेंडरिंग के लिए सबसे भरोसेमंद होते हैं, लेकिन बड़े raster images PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **Linked images** पैकेज को छोटा रख सकते हैं, लेकिन presentation को बाहरी फ़ाइलों के उपलब्ध रहने पर निर्भर बनाते हैं।
- **Cropping** प्रारम्भ में गैर‑विनाशकारी होता है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक कि क्रॉप किए गए क्षेत्रों को स्पष्ट रूप से हटाया या संपीड़न के दौरान हटाया न जाए।
- **Compression** अत्यधिक बड़े raster images के फ़ाइल आकार को काफी घटा सकता है, लेकिन यह स्रोत रिज़ॉल्यूशन का त्याग करता है। इसे intended on‑slide आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG images** वेक्टर संरक्षण महत्वपूर्ण होने पर SVG के रूप में ही रहने चाहिए। जब आपको वेक्टर रिसोर्स स्वयं चाहिए तो एम्बेडेड SVG को सीधे निकालें। Raster स्लाइड निर्यात हमेशा रेंडर की गई स्लाइड को पिक्सेल में बदलते हैं।
- **Repeated images** को संभावित होने पर मौजूदा [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) रिसोर्स को पुनः उपयोग करना चाहिए, न कि एक ही फ़ाइल को बार‑बार लोड करना।

बड़ी प्रस्तुतियों के लिए, image अनुकूलन आम तौर पर तब सबसे प्रभावी होता है जब चयनात्मक रूप से किया जाए: लोगो और आरेखों को वेक्टर कंटेंट के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक प्रदर्शन आकार के अनुसार संपीड़ित करें, क्रॉप किए गए पिक्सेल को तभी हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक से बचें जब तक कि निर्भरताओं का प्रबंधन डिप्लॉयमेंट डिज़ाइन का हिस्सा न हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक picture frame और एक image resource में क्या अंतर है?**

[IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) presentation से जुड़ा एक image resource दर्शाता है। [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) स्लाइड पर वह shape है जो image प्रदर्शित करता है और आकार, घूर्णन, क्रॉप मान, इफ़ेक्ट और लॉक जैसे frame‑level geometry और formatting को संग्रहीत करता है।

**मुझे images को embed करना चाहिए या link करना?**

जब presentation को पोर्टेबल, अभिलेखित या बाहरी resources तक पहुंच के बिना रेंडर करने की आवश्यकता हो, तो images को embed करें। केवल तब images को link करें जब image फ़ाइलें बाहर रखी जाएँ और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार को घटाती है?**

खुद से नहीं। सामान्य क्रॉप सेटिंग्स स्रोत image के हिस्सों को छिपाती हैं लेकिन नीचे के पिक्सेल को बनाए रखती हैं। जब उन पिक्सेल को स्थायी रूप से हटाया जा सकता है, तब [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) या क्रॉपेड‑एरिया हटाते हुए image compression का उपयोग करके फ़ाइल आकार घटाया जा सकता है।

**क्या मैं संपीड़न के बाद image गुणवत्ता को पुनः प्राप्त कर सकता हूँ?**

नहीं। संपीड़न संग्रहीत raster रिज़ॉल्यूशन को घटा सकता है, और क्रॉप किए गए क्षेत्रों को हटाने से image डेटा समाप्त हो जाता है। यदि बाद में उच्च‑रिज़ॉल्यूशन संपादन की आवश्यकता हो, तो मूल स्रोत image को presentation के बाहर रखें।

**SVG images को कैसे संभालना चाहिए?**

जब वेक्टर फ़िडेलिटी महत्वपूर्ण हो, तो SVG कंटेंट को SVG के रूप में रखें। एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे raster फ़ॉर्मेट में रेंडर करने से SVG पिक्सेल में rasterize हो जाता है।

**मौजूदा स्लाइड्स पढ़ते समय असुरक्षित casts से कैसे बचा जा सकता है?**

shape का प्रकार जांचें इससे पहले कि picture‑frame‑specific सदस्यों का उपयोग किया जाए। [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) के साथ shape की जाँच करें, फिर runtime cast लागू करें, और picture‑frame‑specific सदस्यों तक पहुँचने से पहले cast परिणाम को स्थानीय चर में असाइन करें।