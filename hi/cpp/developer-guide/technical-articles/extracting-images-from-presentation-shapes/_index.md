---
title: "C++ में प्रस्तुति आकृतियों से छवियों को निकालें"
linktitle: "आकार से छवि"
type: docs
weight: 90
url: /hi/cpp/extracting-images-from-presentation-shapes/
keywords:
  - "छवि निकालें"
  - "छवि पुनः प्राप्त करें"
  - "PowerPoint"
  - "OpenDocument"
  - "प्रस्तुति"
  - "C++"
  - "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों में आकारों से छवियों को निकालें - तेज़, कोड-मैत्री समाधान।"
---
## **परिचय**

एक प्रस्तुति में छवियाँ कई आकार प्रकारों में दिखाई दे सकती हैं: सामान्य चित्र फ़्रेम के रूप में, आकारों पर लागू चित्र भराव के रूप में, OLE ऑब्जेक्ट प्रीव्यू चित्रों के रूप में, वीडियो या ऑडियो फ़्रेम थंबनेल के रूप में, ज़ूम चित्रों के रूप में, या तालिका, चार्ट और SmartArt आकारों के भीतर नेस्टेड छवियों के रूप में। Aspose.Slides इन छवियों को प्रस्तुति छवि संग्रह में संग्रहीत करता है, जिसे [IImageCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimagecollection/) और [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) ऑब्जेक्ट्स के माध्यम से एक्सपोज़ किया गया है।

यदि आपको केवल प्रस्तुति में एम्बेडेड प्रत्येक छवि संसाधन को निर्यात करने की आवश्यकता है, तो `presentation->get_Images()` पर इटररेट करें। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइड्स पर छवियों के उपयोग को खोजने के लिए आकारों का ट्रैवर्स करना, ताकि सहेजे गए फ़ाइलें स्लाइड नंबर, आकार स्थिती, और स्रोत प्रकार (चित्र फ्रेम, भराव चित्र, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम चित्र) जैसी उपयोगी संदर्भ को बनाए रख सकें।

{{% alert title="Tip" color="info" %}}
[IPPImage]::`get_BinaryData()` का उपयोग करके मूल एन्कोडेड छवि डेटा और फ़ाइल प्रकार को सुरक्षित रखें। जब आप आउटपुट को PNG जैसे विशिष्ट फ़ॉर्मेट में सामान्यीकृत करना चाहते हैं, तो [IPPImage]::`get_Image()` को [IImage]::`Save` के साथ उपयोग करें।
{{% /alert %}}

## **साझा सहायक विधियाँ**

नीचे दिए गए सहायक विधियाँ उदाहरणों को छोटा रखती हैं। `SaveOriginalImage` मूल एम्बेडेड बाइट्स को लिखता है, MIME प्रकार से सुरक्षित एक्सटेंशन चुनता है, और SHA-256 हैश द्वारा डुप्लिकेट छवि बाइनरीज़ को स्किप करता है।

```cpp
#include <vector>
#include <system/array.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <security/cryptography/hash_algorithm.h>
#include <system/text/string_builder.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGroupShape.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlidesPicture.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Security::Cryptography;
using namespace System::Text;

struct ShapeInfo
{
    SharedPtr<IShape> Shape;
    String NamePart;
};

String GetSha256Hash(ArrayPtr<uint8_t> data);
String GetExtensionFromContentType(String contentType);
String MakeSafeFileNamePart(String value);

bool SaveOriginalImage(
    SharedPtr<IPPImage> image,
    String outputDirectory,
    String fileNameBase,
    SharedPtr<HashSet<String>> savedImageHashes)
{
    auto imageData = image->get_BinaryData();
    String imageHash = GetSha256Hash(imageData);
    if (savedImageHashes->Contains(imageHash))
    {
        return false;
    }

    savedImageHashes->Add(imageHash);

    String extension = GetExtensionFromContentType(image->get_ContentType());
    String fileName = String::Format(u"{0}.{1}", fileNameBase, extension);
    String outputPath = Path::Combine(outputDirectory, fileName);
    File::WriteAllBytes(outputPath, imageData);
    return true;
}

void SaveImageAsPng(SharedPtr<IPPImage> image, String outputDirectory, String fileNameBase)
{
    String fileName = String::Format(u"{0}.png", fileNameBase);
    String outputPath = Path::Combine(outputDirectory, fileName);

    auto outputImage = image->get_Image();
    outputImage->Save(outputPath, ImageFormat::Png);
    outputImage->Dispose();
}

SharedPtr<IPPImage> GetPictureFillImage(SharedPtr<IFillFormat> fillFormat)
{
    if (fillFormat == nullptr || fillFormat->get_FillType() != FillType::Picture)
    {
        return nullptr;
    }

    return fillFormat->get_PictureFillFormat()->get_Picture()->get_Image();
}

void EnumerateShapes(
    SharedPtr<IShapeCollection> shapes,
    String prefix,
    bool includeGroupedShapes,
    std::vector<ShapeInfo>& result)
{
    int shapeCount = shapes->get_Count();
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = shapes->idx_get(shapeIndex);
        int displayIndex = shapeIndex + 1;
        String shapeNamePart = String::Format(u"{0}_shape_{1}", prefix, displayIndex);
        result.push_back({ shape, shapeNamePart });

        auto groupShape = System::AsCast<IGroupShape>(shape);
        if (includeGroupedShapes && groupShape != nullptr)
        {
            EnumerateShapes(groupShape->get_Shapes(), shapeNamePart, includeGroupedShapes, result);
        }
    }
}

String GetSha256Hash(ArrayPtr<uint8_t> data)
{
    auto sha256 = HashAlgorithm::Create(u"SHA256");
    auto hash = sha256->ComputeHash(data);
    auto builder = MakeObject<StringBuilder>();

    int hashLength = hash->get_Length();
    for (int index = 0; index < hashLength; index++)
    {
        uint8_t hashByte = hash[index];
        builder->Append(String::Format(u"{0:x2}", hashByte));
    }

    return builder->ToString();
}

String GetExtensionFromContentType(String contentType)
{
    if (String::IsNullOrWhiteSpace(contentType))
    {
        return u"bin";
    }

    int separatorIndex = contentType.IndexOf(u";");
    String mediaType = separatorIndex >= 0 ? contentType.Substring(0, separatorIndex) : contentType;
    mediaType = mediaType.Trim().ToLower();

    if (mediaType == u"image/jpeg")
    {
        return u"jpg";
    }
    if (mediaType == u"image/png")
    {
        return u"png";
    }
    if (mediaType == u"image/gif")
    {
        return u"gif";
    }
    if (mediaType == u"image/bmp")
    {
        return u"bmp";
    }
    if (mediaType == u"image/tiff")
    {
        return u"tiff";
    }
    if (mediaType == u"image/x-emf" || mediaType == u"image/emf")
    {
        return u"emf";
    }
    if (mediaType == u"image/x-wmf" || mediaType == u"image/wmf")
    {
        return u"wmf";
    }
    if (mediaType == u"image/svg+xml")
    {
        return u"svg";
    }
    if (mediaType.StartsWith(u"image/"))
    {
        String extension = mediaType.Substring(String(u"image/").get_Length());
        return MakeSafeFileNamePart(extension);
    }

    return u"bin";
}

String MakeSafeFileNamePart(String value)
{
    auto invalidCharacters = Path::GetInvalidFileNameChars();
    int invalidCharacterCount = invalidCharacters->get_Length();
    for (int index = 0; index < invalidCharacterCount; index++)
    {
        value = value.Replace(invalidCharacters[index], u'_');
    }

    return value;
}
```

## **चित्र फ्रेम से छवियों को निकालें**

यह विधि उन चित्रों के लिए उपयोग करें जो स्वतंत्र ऑब्जेक्ट के रूप में डाली गई हैं। एक [IPictureFrame] अपनी चित्र को `get_PictureFormat()->get_Picture()->get_Image()` में संग्रहीत करता है, जो एक [IPPImage] ऑब्जेक्ट लौटाता है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"extracted-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto pictureFrame = System::AsCast<IPictureFrame>(item.Shape);
            if (pictureFrame != nullptr)
            {
                auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **चित्र-भरे आकारों से छवियों को निकालें**

आकार चित्र को भराव के रूप में उपयोग कर सकते हैं। पहले आकार की भराव प्रकार जाँचें: यदि यह [FillType]::`Picture` नहीं है, तो उस भराव से निकाली जाने वाली कोई चित्र नहीं है। नीचे का उदाहरण [IAutoShape] ऑब्जेक्ट्स को संभालता है और प्रत्येक छवि को PNG के रूप में [IPPImage]::`get_Image()` के माध्यम से सहेजता है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"shape-fill-images");
    Directory::CreateDirectory_(outputDirectory);

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto autoShape = System::AsCast<IAutoShape>(item.Shape);
            if (autoShape != nullptr)
            {
                auto image = GetPictureFillImage(autoShape->get_FillFormat());
                if (image != nullptr)
                {
                    SaveImageAsPng(image, outputDirectory, item.NamePart);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **OLE ऑब्जेक्ट फ्रेम्स से प्रीव्यू छवियों को निकालें**

एक [IOleObjectFrame] के पास एक विकल्पिक चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह चित्र `get_SubstitutePictureFormat()->get_Picture()->get_Image()` के माध्यम से उपलब्ध है। इस चित्र को निकालने से आपको प्रीव्यू छवि मिलती है, न कि एम्बेडेड OLE पैकेज की सामग्री।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"ole-preview-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto oleObjectFrame = System::AsCast<IOleObjectFrame>(item.Shape);
            if (oleObjectFrame != nullptr)
            {
                auto image = oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_ole_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **वीडियो फ़्रेम्स से प्रीव्यू छवियों को निकालें**

एक [IVideoFrame] भी `get_PictureFormat()->get_Picture()->get_Image()` में एक प्रीव्यू छवि संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, न कि वीडियो स्ट्रीम से निकाला गया फ़्रेम।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"video-preview-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto videoFrame = System::AsCast<IVideoFrame>(item.Shape);
            if (videoFrame != nullptr)
            {
                auto image = videoFrame->get_PictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_video_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **ऑडियो फ़्रेम्स से प्रीव्यू छवियों को निकालें**

एक [IAudioFrame] `get_PictureFormat()->get_Picture()->get_Image()` में थंबनेल संग्रहीत कर सकता है। यह ऑडियो ऑब्जेक्ट के लिए स्लाइड पर दिखाया गया चित्र है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"audio-preview-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto audioFrame = System::AsCast<IAudioFrame>(item.Shape);
            if (audioFrame != nullptr)
            {
                auto image = audioFrame->get_PictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_audio_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **जूम ऑब्जेक्ट्स से छवियों को निकालें**

[IZoomFrame] और [ISectionZoomFrame] आकार कस्टम छवियों का उपयोग कर सकते हैं। जूम फ़्रेम से `get_ZoomImage()` पढ़ें।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"zoom-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto zoomFrame = System::AsCast<IZoomFrame>(item.Shape);
            if (zoomFrame != nullptr && zoomFrame->get_ZoomImage() != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_zoom", item.NamePart);
                SaveOriginalImage(zoomFrame->get_ZoomImage(), outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

            auto sectionZoomFrame = System::AsCast<ISectionZoomFrame>(item.Shape);
            if (sectionZoomFrame != nullptr && sectionZoomFrame->get_ZoomImage() != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_section_zoom", item.NamePart);
                SaveOriginalImage(sectionZoomFrame->get_ZoomImage(), outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **समरी जूम फ़्रेम्स से छवियों को निकालें**

[ISummaryZoomFrame] भी एक आकार है। इसके सेक्शन आइटम कस्टम छवियों का उपयोग कर सकते हैं, जो प्रत्येक समरी जूम सेक्शन की `get_ZoomImage()` विधि द्वारा एक्सपोज़ की जाती हैं।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"summary-zoom-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto summaryZoomFrame = System::AsCast<ISummaryZoomFrame>(item.Shape);
            if (summaryZoomFrame != nullptr)
            {
                auto summaryZoomCollection = summaryZoomFrame->get_SummaryZoomCollection();
                int sectionCount = summaryZoomCollection->get_Count();
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    auto section = summaryZoomCollection->idx_get(sectionIndex);
                    if (section->get_ZoomImage() != nullptr)
                    {
                        int displayIndex = sectionIndex + 1;
                        String fileNameBase = String::Format(u"{0}_summary_zoom_{1}", item.NamePart, displayIndex);
                        SaveOriginalImage(section->get_ZoomImage(), outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **टेबल आकारों से छवियों को निकालें**

[ITable] एक आकार है। तालिका में छवियाँ आमतौर पर तालिका सेल में चित्र भराव के रूप में संग्रहीत होती हैं।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"table-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto table = System::AsCast<ITable>(item.Shape);
            if (table != nullptr)
            {
                int rowCount = table->get_Rows()->get_Count();
                int columnCount = table->get_Columns()->get_Count();
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        auto column = table->get_Column(columnIndex);
                        auto cell = column->idx_get(rowIndex);
                        auto image = GetPictureFillImage(cell->get_CellFormat()->get_FillFormat());
                        if (image != nullptr)
                        {
                            String fileNameBase = String::Format(
                                u"{0}_cell_{1}_{2}", item.NamePart, rowIndex + 1, columnIndex + 1);
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **चार्ट आकारों से छवियों को निकालें**

[IChart] एक आकार है। नीचे का उदाहरण चार्ट क्षेत्र की चित्र भराव से एक छवि निकालता है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"chart-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto chart = System::AsCast<Aspose::Slides::Charts::IChart>(item.Shape);
            if (chart != nullptr)
            {
                auto fillFormat = chart->get_FillFormat();
                auto image = GetPictureFillImage(fillFormat);
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_chart_area", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **SmartArt आकारों से छवियों को निकालें**

[ISmartArt] ऑब्जेक्ट एक आकार है। SmartArt लेआउट के आधार पर, छवियाँ नोड बुलेट भराव या नोड आकार की भराव फ़ॉर्मैट में संग्रहीत हो सकती हैं।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"smartart-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto smartArt = System::AsCast<Aspose::Slides::SmartArt::ISmartArt>(item.Shape);
            if (smartArt != nullptr)
            {
                int nodeCount = smartArt->get_AllNodes()->get_Count();
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    auto node = smartArt->get_NodeFromAll(nodeIndex);
                    auto bulletImage = GetPictureFillImage(node->get_BulletFillFormat());
                    if (bulletImage != nullptr)
                    {
                        String fileNameBase = String::Format(
                            u"{0}_smartart_node_{1}_bullet", item.NamePart, nodeIndex + 1);
                        SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node->get_Shapes()->get_Count();
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        auto nodeShape = node->get_Shape(nodeShapeIndex);
                        auto image = GetPictureFillImage(nodeShape->get_FillFormat());
                        if (image != nullptr)
                        {
                            String fileNameBase = String::Format(
                                u"{0}_smartart_node_{1}_shape_{2}",
                                item.NamePart,
                                nodeIndex + 1,
                                nodeShapeIndex + 1);
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **समूहीकृत आकारों के अंदर छवियों को शामिल करें**

समूहीकृत आकारों की अपनी आकार संग्रह होती है। साझा `EnumerateShapes` सहायक में `includeGroupedShapes` विकल्प होता है। जब आप [IGroupShape] ऑब्जेक्ट्स के अंदर के आकारों का निरीक्षण करना चाहते हैं, तो इसे `true` सेट करें। नीचे का उदाहरण चित्र फ्रेम, चित्र-भरे आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ़्रेम थंबनेल और ऑडियो फ़्रेम थंबनेल से छवियों को निकालता है। तालिका, चार्ट, SmartArt और समरी ज़ूम छवियों को भी शामिल करने के लिए, पिछले सेक्शनों की विशिष्ट निष्कर्षण लॉजिक को पुन: उपयोग करें जबकि वही पुनरावृत्त आकार ट्रैवर्सल रखें।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
    String inputPath = u"sample.pptx";
    String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"all-shape-images");
    Directory::CreateDirectory_(outputDirectory);

    auto savedImageHashes = MakeObject<HashSet<String>>();

    auto presentation = MakeObject<Presentation>(inputPath);
    int slideCount = presentation->get_Slides()->get_Count();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        auto slide = presentation->get_Slide(slideIndex);
        String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

        std::vector<ShapeInfo> shapeInfos;
        EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

        for (const ShapeInfo& item : shapeInfos)
        {
            auto pictureFrame = System::AsCast<IPictureFrame>(item.Shape);
            if (pictureFrame != nullptr)
            {
                auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                continue;
            }

            auto autoShape = System::AsCast<IAutoShape>(item.Shape);
            if (autoShape != nullptr)
            {
                auto image = GetPictureFillImage(autoShape->get_FillFormat());
                if (image != nullptr)
                {
                    SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                }

                continue;
            }

            auto oleObjectFrame = System::AsCast<IOleObjectFrame>(item.Shape);
            if (oleObjectFrame != nullptr)
            {
                auto image = oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_ole_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            auto videoFrame = System::AsCast<IVideoFrame>(item.Shape);
            if (videoFrame != nullptr)
            {
                auto image = videoFrame->get_PictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_video_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            auto audioFrame = System::AsCast<IAudioFrame>(item.Shape);
            if (audioFrame != nullptr)
            {
                auto image = audioFrame->get_PictureFormat()->get_Picture()->get_Image();
                if (image != nullptr)
                {
                    String fileNameBase = String::Format(u"{0}_audio_preview", item.NamePart);
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }

    presentation->Dispose();

    return 0;
}
```

## **एज केस और व्यावहारिक नोट्स**

- **डुप्लिकेट छवियों:** कई आकार एक ही छवि का संदर्भ दे सकते हैं या समान बाइट्स वाली अलग छवियाँ हो सकती हैं। फ़ाइल लिखने से पहले [IPPImage]::`get_BinaryData()` का हैश बनाएँ यदि आप प्रत्येक विशिष्ट छवि के लिए एक आउटपुट फ़ाइल चाहते हैं।  
- **मूल डेटा बनाम परिवर्तित आउटपुट:** [IPPImage]::`get_BinaryData()` को सहेजने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा सुरक्षित रहता है। [IPPImage]::`get_Image()` को [IImage]::`Save` के साथ उपयोग करना तब उपयोगी है जब आप एकसमान आउटपुट फ़ॉर्मेट चाहते हैं।  
- **असमर्थित भराव प्रकार:** सॉलिड, ग्रेडिएंट, पैटर्न और नो-फ़िल आकार में चित्र भराव नहीं होता। पढ़ने से पहले [FillType] जाँचें।  
- **समूहीकृत आकार:** टॉप‑लेवल स्लाइड आकार संग्रह समूहों को फ्लैट नहीं करता। जब समूहित सामग्री महत्त्वपूर्ण हो तो [IGroupShape]::`get_Shapes()` को पुनरावृत्त रूप से निरीक्षण करें।  
- **OLE ऑब्जेक्ट प्रीव्यू:** एक [IOleObjectFrame] `get_SubstitutePictureFormat()` के ज़रिए प्रीव्यू छवि प्रदान कर सकता है, लेकिन वह केवल स्लाइड प्रीव्यू है, एम्बेडेड फ़ाइल नहीं।  
- **वीडियो फ़्रेम थंबनेल:** एक [IVideoFrame] `get_PictureFormat()` के ज़रिए प्रीव्यू छवि दिखा सकता है, लेकिन वह वीडियो स्ट्रीम से निकाला गया फ्रेम नहीं है।  
- **ऑडियो फ़्रेम थंबनेल:** एक [IAudioFrame] `get_PictureFormat()` के ज़रिए आइकन या थंबनेल दिखा सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।  
- **ज़ूम छवियां:** स्लाइड ज़ूम, सेक्शन ज़ूम और समरी ज़ूम आकार कस्टम [IPPImage] ऑब्जेक्ट्स को `get_ZoomImage()` के ज़रिए उपयोग कर सकते हैं।  
- **नेस्टेड आकार मॉडल:** तालिका, चार्ट और SmartArt ऑब्जेक्ट्स [IShape] को लागू करते हैं, लेकिन उनकी छवियां अक्सर नेस्टेड तालिका सेल, चार्ट तत्व या SmartArt नोड फ़ॉर्मैटिंग ऑब्जेक्ट्स में संग्रहीत होती हैं।  
- **कट या ट्रांसफ़ॉर्म्ड चित्र:** [IPPImage] तक पहुंचने से आपको संग्रहीत छवि संसाधन मिलता है। यह आकार द्वारा लागू क्रॉपिंग, ट्रांसपेरेंसी, पुनःरंगना, घूर्णन या अन्य दृश्य प्रभावों को रेंडर नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं मूल छवि को बिना क्रॉप, इफ़ेक्ट या आकार ट्रांसफ़ॉर्मेशन के निकाल सकता हूँ?

हाँ। [IPPImage] ऑब्जेक्ट तक पहुंचें और `get_BinaryData()` को डिस्क पर लिखें। यह प्रस्तुति में संग्रहीत मूल एन्कोडेड छवि को संरक्षित रखता है, न कि स्लाइड पर चित्र के रेंडर किए गए रूप को।

### क्या मैं प्रत्येक निकाली गई छवि को PNG के रूप में निर्यात कर सकता हूँ?

हाँ। [IPPImage]::`get_Image()` का उपयोग करके एक [IImage] ऑब्जेक्ट प्राप्त करें, फिर [IImage]::`Save` को [ImageFormat]::`Png` के साथ कॉल करें। यह आउटपुट को PNG में बदल देगा और मूल फ़ाइल प्रकार या वैक्टर डेटा को संरक्षित नहीं रखेगा।

### मैं एक ही छवि को कई बार सहेजने से कैसे बचूँ?

[IPPImage]::`get_BinaryData()` का हैश बनाएं और हैश को एक सेट में रखें। यदि नया हैश पहले से मौजूद है, तो फ़ाइल को स्किप करें या मौजूदा आउटपुट फ़ाइल के लिए एक अतिरिक्त संदर्भ दर्ज करें।

### कुछ आकार छवि क्यों नहीं उत्पन्न करते?

चित्र फ्रेम, चित्र-भरे आकार, OLE ऑब्जेक्ट फ्रेम, मीडिया फ्रेम, ज़ूम फ्रेम, तालिका, चार्ट और SmartArt ऑब्जेक्ट्स चित्रों का संदर्भ दे सकते हैं। कुछ आकार प्रकार नेस्टेड फ़ॉर्मैटिंग ऑब्जेक्ट्स के माध्यम से छवियों को एक्सपोज़ करते हैं, इसलिए केवल `get_PictureFormat()` या आकार का `get_FillFormat()` जाँचना हमेशा पर्याप्त नहीं होता।

### क्या मैं वीडियो फ़्रेम के लिए दिखाए गए थंबनेल को निकाल सकता हूँ?

हाँ। [IVideoFrame]::`get_PictureFormat()` का उपयोग करें और `get_PictureFormat()->get_Picture()->get_Image()` पढ़ें। यह वीडियो फ़्रेम के साथ संग्रहीत पोस्टर छवि को निकालता है, न कि वीडियो फ़ाइल से जनरेट किया गया फ्रेम।

### मैं प्रस्तुति छवि संग्रह से विशिष्ट छवि का उपयोग करने वाले आकार कैसे पहचानूँ?

Aspose.Slides के पास [IPPImage] से आकारों की रिवर्स लिंक नहीं होती। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप किसी छवि संदर्भ को देखें, स्लाइड नंबर, आकार पथ और छवि हैश या संग्रह आइटम को रिकॉर्ड करें।

### क्या मैं OLE ऑब्जेक्ट्स के भीतर एम्बेडेड छवियों को निकाल सकता हूँ, जैसे संलग्न दस्तावेज़?

आप [IOleObjectFrame]::`get_SubstitutePictureFormat()` से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालांकि, वह प्रीव्यू एम्बेडेड दस्तावेज़ नहीं है। एम्बेडेड फ़ाइल के भीतर की छवियों को निकालने के लिए OLE डेटा को निकालें और उस फ़ाइल प्रकार के लिए उपयुक्त टूल्स से निरीक्षण करें।