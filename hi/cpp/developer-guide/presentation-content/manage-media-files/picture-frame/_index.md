---
title: C++ का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम्स प्रबंधित करें
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
- इमेज को क्रॉप करें
- क्रॉप्ड क्षेत्रों को हटाएं
- इमेज संपीड़ित करें
- StretchOffset
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- रिलेटिव स्केल
- इमेज इफ़ेक्ट
- आस्पेक्ट रेशियो
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुतियों में पिक्चर फ्रेम्स बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संपीड़ित करें।"
---
## **अवलोकन**

एक picture frame एक slide shape है जो एक इमेज प्रदर्शित करता है। Aspose.Slides में, इमेज रिसोर्स और वह shape जो इसे दिखाता है, अलग‑अलग ऑब्जेक्ट होते हैं: एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) अपने [image collection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_images/) के माध्यम से एम्बेडेड इमेज रिसोर्स को रखता है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) इमेज की स्थिति, आकार, लाइन फ़ॉर्मेटिंग, घुमाव, क्रॉपिंग, picture effects और अन्य frame‑level सेटिंग्स को नियंत्रित करता है।

यह विभाजन तब उपयोगी होता है जब एक ही इमेज कई बार दिखाया जाता है। इमेज को प्रेजेंटेशन में एक बार जोड़ें, लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) को रखें, और picture frames बनाते समय उसी इमेज रिसोर्स का उपयोग करें।

Picture frames raster इमेज जैसे PNG या JPEG और vector SVG इमेज दोनों को रख सकते हैं। वे लिंक्ड इमेज की ओर भी इशारा कर सकते हैं, जिससे इमेज बाइट्स प्रेजेंटेशन में संग्रहीत नहीं होते। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, एक्सट्रैक्शन और एक्सपोर्ट व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या ऑप्टिमाइज़ेशन लागू करने से पहले यह तय करना उपयोगी है कि इमेज कैसे संग्रहीत की जाए।

## **एक एम्बेडेड इमेज जोड़ें और फ़ॉर्मेट करें**

एक एम्बेडेड इमेज के लिए, इमेज डेटा को प्रेजेंटेशन में जोड़ें और [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapecollection/addpictureframe/) का उपयोग करके picture frame बनाएं। इमेज प्रेजेंटेशन पैकेज का हिस्सा बन जाती है, इसलिए प्रेजेंटेशन दूसरे कंप्यूटर पर ले जाने पर भी स्वयं‑समाहित रहता है।

निम्न उदाहरण JPEG इमेज जोड़ता है, इमेज के मूल आयामों पर एक फ्रेम बनाता है, और लाइन फ़ॉर्मेटिंग तथा घुमाव लागू करता है:

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

picture frame प्रदर्शित ज्योमेट्री को नियंत्रित करता है; फ्रेम का आकार बदलने से एम्बेडेड इमेज रिसोर्स में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर तब महत्वपूर्ण हो जाता है जब बाद में इमेज को क्रॉप या संकुचित किया जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) फ्रेम के लिए रिलेटिव चौड़ाई और ऊँचाई स्केलिंग को उजागर करता है। `1.0` का मान मूल picture आकार का 100 % दर्शाता है। रिलेटिव स्केल तब उपयोगी होता है जब वर्कफ़्लो को स्रोत इमेज आकार के संबंध को बनाए रखना आवश्यक हो, बजाय अंतिम आयामों की मैन्युअल गणना के।

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

रिलेटिव स्केल फ्रेम के स्केल सेटिंग्स को बदलता है; यह एम्बेडेड इमेज को री‑सैंपल या कॉम्प्रेस नहीं करता।

## **एम्बेडेड और लिंक्ड इमेज**

एक एम्बेडेड picture इमेज डेटा को प्रेजेंटेशन के भीतर संग्रहीत करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमानित रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड picture इमेज डेटा को एम्बेड करने के बजाय [ISlidesPicture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidespicture/) लिंक पाथ के माध्यम से बाहरी स्थान में रखता है।

लिंक्ड इमेज PPTX में संग्रहीत इमेज डेटा की मात्रा को कम कर सकते हैं, लेकिन वे एक बाहरी निर्भरता लाते हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन द्वारा सुलभ रहना चाहिए जो प्रेजेंटेशन को खोलता या रेंडर करता है। यदि पाथ बदल जाता है, फ़ाइल ले जाया जाता है, या रिसोर्स उपलब्ध नहीं रहता, तो लिंक्ड picture अपेक्षा अनुसार नहीं दिख सकता। उन प्रेजेंटेशन के लिए जिन्हें ई‑मेल, अभिलेख या अलग‑थलग वातावरण में रेंडर करने की आवश्यकता होती है, एम्बेडेड इमेज आमतौर पर अधिक विश्वसनीय होते हैं।

### **एक लिंक्ड इमेज जोड़ें**

निम्न उदाहरण एक picture frame बनाता है और उसे स्थानीय इमेज फ़ाइल की ओर इशारा करता है। यह केवल इमेज लिंकिंग से निपटता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और जानबूझकर इस उदाहरण में शामिल नहीं किया गया है।

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

जब बाहरी फ़ाइल प्रबंधन इरादा हो तो लिंक का प्रयोग करें। उन्हें केवल संपीड़न के विकल्प के रूप में उपयोग न करें: टूटे हुए इमेज निर्भरताओं के साथ छोटा PPTX आमतौर पर बड़े स्वयं‑समाहित प्रेजेंटेशन से कम उपयोगी होता है।

## **Picture Frames से इमेज निकालें**

किसी मौजूदा प्रेजेंटेशन से इमेज निकालने से पहले, जाँचें कि shape वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) है और उसमें एम्बेडेड इमेज है। लिंक्ड picture frames में ऐसे इमेज बाइट्स नहीं हो सकते जिन्हें समान तरीके से निकाला जा सके।

### **एक Raster इमेज निकालें**

आधुनिक इमेज API सीधे [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) का उपयोग करता है। निम्न उदाहरण पहले एम्बेडेड raster picture को स्लाइड पर ढूंढता है और उसे PNG के रूप में सहेजता है:

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

[IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) के माध्यम से सहेजने से निकाली गई इमेज अनुरोधित आउटपुट फ़ॉर्मेट में परिवर्तित हो जाती है। यदि आपको प्रस्तुतिकरण में संग्रहीत एन्कोडेड बाइट्स चाहिए, तो raster फ़ाइल को परिवर्तित करने के बजाय इमेज रिसोर्स का बाइनरी डेटा उपयोग करें।

### **एक SVG इमेज निकालें**

एक SVG picture के लिए, [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) ऑब्जेक्ट को उजागर करता है। यह आपको SVG डेटा सीधे प्राप्त करने की अनुमति देता है, बिना पहले picture को rasterize किए।

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

SVG सामग्री को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसे raster निर्यात अनिवार्य रूप से वह वेक्टर सामग्री को पिक्सेल में रेंडर करता है। PDF या SVG स्लाइड निर्यात भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यातित ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑दर‑बाइट कॉपी न मानें; जब मूल वेक्टर रिसोर्स स्वयं आवश्यक हो तो एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) डेटा का उपयोग करें।

## **इमेज को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर इमेज के कौन से भाग दिखेंगे, इसे बदलती है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/) पर क्रॉप वैल्यू स्रोत इमेज आयामों का प्रतिशत होते हैं। क्रॉपिंग मूल एम्बेडेड इमेज से छिपे पिक्सेल को प्रारंभिक रूप से हटाती नहीं है; यह केवल दृश्य क्षेत्र को बदलती है।

निम्न उदाहरण एक picture frame को सुरक्षित रूप से ढूंढता है और क्रॉप वैल्यू लागू करता है:

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

क्योंकि छुपा इमेज डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनरावर्तितता की आवश्यकता नहीं है, तो अगले सेक्शन में वर्णित अनुसार क्रॉपेड क्षेत्रों को भौतिक रूप से हटा सकते हैं।

## **क्रॉप्ड इमेज डेटा हटाएँ**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) वर्तमान क्रॉप रेक्टेंगल के बाहर के इमेज डेटा को हटाता है और परिणामी इमेज रिसोर्स लौटाता है। यह फ़ाइल आकार को घटा सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: प्रेजेंटेशन सहेजे जाने के बाद हटाए गए पिक्सेल बाद के अनक्रॉप ऑपरेशन में उपलब्ध नहीं रहेंगे।

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

यह मेथड प्रेजेंटेशन में नई इमेज रिसोर्स जोड़ सकता है। यदि मूल इमेज अन्य picture frames द्वारा भी उपयोग की जाती है, तो उन फ्रेमों को अभी भी अपने मौजूदा रिसोर्स की आवश्यकता होगी, इसलिए क्रॉप्ड क्षेत्रों को हटाना जरूरी नहीं कि कुल इमेज संख्या घटाए। WMF या EMF सामग्री को इस मेथड से क्रॉप करने से परिणाम PNG में rasterize हो जाता है।

## **Raster इमेज को संपीड़ित करें**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/compressimage/) raster इमेज रिज़ॉल्यूशन को उस आकार के सापेक्ष घटाता है जिस पर picture प्रदर्शित होती है। यह उसी ऑपरेशन में क्रॉप्ड क्षेत्रों को भी हटा सकता है। मेथड `true` लौटाता है जब इमेज को रिसाइज़ या क्रॉप किया गया हो और `false` जब कोई परिवर्तन आवश्यक न हो।

जब एक मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो, तो एक पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/picturescompression/) मान उपयोग करें:

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

जब विशेष लक्ष्य आवश्यक हो तो enum मान के बजाय कस्टम सकारात्मक DPI मान पास किया जा सकता है।

संकुचन raster इमेज के लिए अभिप्रेत है। SVG और मेटाफाइल सामग्री इस raster संपीड़न वर्कफ़्लो द्वारा नहीं घटती। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप्ड क्षेत्रों को ऑप्टिमाइज़्ड प्रेजेंटेशन से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर इमेज वास्तव में देखी या निर्यात की जाएगी, न कि वैश्विक रूप से सबसे कम DPI लागू करके।

## **Image Transform Effects प्रबंधित करें**

ब्राइटनेस, कंट्रास्ट, कलर ट्रांसफ़ॉर्मेशन, ब्लर, अल्फ़ा इफ़ेक्ट, ऑर्डर्ड चेन, निरीक्षण, हटाना और राउंड‑ट्रिप वेरिफिकेशन को कवर करने वाले पूर्ण वर्कफ़्लो के लिए देखें [Image Transform Effects](/slides/hi/cpp/image-transform-effects/)।

## **Picture Frame ज्योमेट्री को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframelock/) सेटिंग्स निर्धारित करती हैं कि picture frame पर कौन‑से संपादन ऑपरेशन निष्क्रिय हैं। उदाहरण के लिए, [aspect‑ratio lock](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) आकार बदलते समय shape के अनुपात को बनाए रखता है।

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

लॉक picture frame shape पर लागू होता है। यह स्रोत इमेज को री‑सैंपल या स्थायी रूप से समान अनुपात में बदलता नहीं है।

## **StretchOffset वैल्यू समायोजित करें**

जब picture fill मोड stretch हो, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/) पर stretch‑offset वैल्यू picture frame के बाउंडिंग बॉक्स के सापेक्ष fill रेक्टेंगल को परिभाषित करती हैं। सकारात्मक प्रतिशत किनारे से एक inset बनाते हैं, जबकि नकारात्मक प्रतिशत एक outset बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप वैल्यू स्रोत इमेज के दृश्य भाग को चुनती हैं; stretch offsets वह रेक्टेंगल बदलते हैं जिसमें दिखाई देने वाला picture fill खींचा जाता है।

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

fill प्लेसमेंट के लिए stretch offsets उपयोग करें। स्रोत‑इमेज किनारों को छिपाने के लक्ष्य के लिए crop प्रॉपर्टी उपयोग करें।

## **स्टोरेज, फ़ाइल आकार, और एक्सपोर्ट विचार**

जब इमेज स्टोरेज और picture‑frame फ़ॉर्मेटिंग को अलग‑अलग संभालते हैं, तब मुख्य ट्रेड‑ऑफ़ अधिक आसानी से प्रबंधित होते हैं:

- **एम्बेडेड इमेज** प्रेजेंटेशन को स्वयं‑समाहित बनाते हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिए सबसे विश्वसनीय होते हैं, लेकिन बड़े raster इमेज PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **लिंक्ड इमेज** पैकेज को छोटा रख सकते हैं, लेकिन प्रेजेंटेशन को बाहरी फ़ाइलों के उपलब्ध रहने पर निर्भर बनाते हैं।
- **क्रॉपिंग** प्रारम्भ में गैर‑विनाशकारी होती है। छिपे पिक्सेल एम्बेडेड रहते हैं जब तक कि क्रॉप्ड क्षेत्रों को स्पष्ट रूप से हटाया न जाए या संपीड़न के दौरान हटाया न जाए।
- **संकुचन** अत्यधिक बड़े raster इमेज के फ़ाइल आकार को काफी घटा सकता है, लेकिन यह स्रोत रिज़ॉल्यूशन की कीमत पर करता है। इसे स्लाइड पर इच्छित आकार ज्ञात होने के बाद लागू करना चाहिए।
- **SVG इमेज** को वेक्टर संरक्षण आवश्यक होने पर SVG रूप में ही रखना चाहिए। जब आपको स्वयं वेक्टर रिसोर्स चाहिए, तो एम्बेडेड SVG को सीधे निकालें। Raster स्लाइड निर्यात हमेशा रेंडर किए गए स्लाइड को पिक्सेल में बदलते हैं।
- **दोहराई गई इमेज** को संभव हो तो मौजूदा [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) रिसोर्स को पुनः उपयोग करना चाहिए, न कि वही फ़ाइल बार‑बार प्रेजेंटेशन वर्कफ़्लो में लोड करना।

बड़ी प्रेजेंटेशन के लिए, इमेज ऑप्टिमाइज़ेशन आमतौर पर तब सबसे प्रभावी होता है जब चयनात्मक रूप से किया जाए: लोगो और डायग्राम को वेक्टर सामग्री के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक डिस्प्ले आकार के अनुसार संपीड़ित करें, क्रॉप्ड पिक्सेल को तभी हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक तभी उपयोग करें जब निर्भरता प्रबंधन डिप्लॉयमेंट डिज़ाइन का हिस्सा हो।

## **FAQ**

**एक picture frame और इमेज रिसोर्स में क्या अंतर है?**

एक [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) प्रेजेंटेशन से जुड़ी इमेज रिसोर्स का प्रतिनिधित्व करता है। एक [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) स्लाइड पर वह shape है जो इमेज प्रदर्शित करता है और फ्रेम‑लेवल ज्योमेट्री व फ़ॉर्मेटिंग जैसे आकार, घुमाव, क्रॉप वैल्यू, इफ़ेक्ट और लॉक को संग्रहीत करता है।

**मुझे इमेज एम्बेड करनी चाहिए या लिंक?**

जब प्रेजेंटेशन को पोर्टेबल, अभिलेखित या बाहरी रिसोर्स के बिना रेंडर करने की आवश्यकता हो, तो इमेज एम्बेड करें। केवल तब ही इमेज लिंक करें जब इमेज फ़ाइलों को PPTX के बाहर रखना इरादा हो और बाहरी स्थानों को भरोसेमंद तरीके से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार कम करती है?**

केवल इससे नहीं। सामान्य क्रॉप सेटिंग स्रोत इमेज के हिस्सों को छिपाती हैं लेकिन मूल पिक्सेल को रखती हैं। जब उन पिक्सेल को स्थायी रूप से हटाया जा सके, तब [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) या क्रॉप्ड‑एरिया हटाने वाला इमेज संपीड़न उपयोग करें।

**क्या संपीड़न के बाद इमेज क्वालिटी बहाल की जा सकती है?**

नहीं। संपीड़न संग्रहीत raster रिज़ॉल्यूशन को घटा सकता है, और क्रॉप्ड क्षेत्रों को हटाना इमेज डेटा को नष्ट कर देता है। यदि बाद में हाई‑रिज़ॉल्यूशन संपादन की संभावना हो, तो मूल स्रोत इमेज को प्रेजेंटेशन के बाहर रखें।

**SVG इमेज को कैसे संभालें?**

जब वेक्टर फिडेलिटी महत्वपूर्ण हो, तो SVG सामग्री को SVG रूप में रखें। एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) को सीधे निकाला जा सकता है। PNG या JPEG जैसे raster फ़ॉर्मेट में स्लाइड रेंडर करने से SVG पिक्सेल में rasterize हो जाता है।

**मौजूदा स्लाइड पढ़ते समय असुरक्षित cast से कैसे बचें?**

picture‑frame‑विशिष्ट सदस्य उपयोग करने से पहले shape टाइप की जाँच करें। रूपांतरण लागू करने से पहले shape को [IPictureFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipictureframe/) के साथ परीक्षण करें, और cast परिणाम को स्थानीय वैरिएबल में असाइन करके picture‑frame‑विशिष्ट सदस्य तक पहुँचें।