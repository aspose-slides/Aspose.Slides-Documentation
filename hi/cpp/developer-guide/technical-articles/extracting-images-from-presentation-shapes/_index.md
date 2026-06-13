---
title: C++ में प्रस्तुति आकारों से छवियों को निकालें
linktitle: आकार से छवि
type: docs
weight: 90
url: /hi/cpp/extracting-images-from-presentation-shapes/
keywords:
- छवि निकालें
- छवि प्राप्त करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों में आकारों से छवियों को निकालें - तेज़, कोड-मैत्रीपूर्ण समाधान."
---
## **सारांश**

एक प्रस्तुति में छवियां विभिन्न आकार प्रकारों में प्रकट हो सकती हैं: सामान्य चित्र फ्रेम के रूप में, आकारों पर लागू चित्र भराव के रूप में, OLE ऑब्जेक्ट प्रीव्यू छवियों के रूप में, वीडियो या ऑडियो फ्रेम थंबनेल के रूप में, ज़ूम छवियों के रूप में, या तालिका, चार्ट, और SmartArt आकारों के भीतर नेस्टेड छवियों के रूप में। Aspose.Slides इन छवियों को प्रस्तुति छवि संग्रह में संग्रहीत करता है, जो [IImageCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimagecollection/) और [IPPImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ippimage/) वस्तुओं के माध्यम से उजागर होते हैं।

यदि आपको केवल प्रस्तुति में एम्बेड की गई प्रत्येक छवि संसाधन को निर्यात करने की आवश्यकता है, तो `presentation->get_Images()` के माध्यम से इटररेट करें। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइड पर छवियों के उपयोग वाले आकारों का क्रमवार traversal करना, ताकि सहेजी गई फ़ाइलें उपयोगी संदर्भ जैसे स्लाइड नंबर, आकार की स्थिति, और स्रोत प्रकार (चित्र फ्रेम, भराव छवि, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम छवि) रख सकें।

{{% alert title="Tip" color="primary" %}}
मूल एन्कोडेड छवि डेटा और फ़ाइल प्रकार को संरक्षित करने के लिए [IPPImage]::`get_BinaryData()` का उपयोग करें। जब आप आउटपुट को किसी विशिष्ट फ़ॉर्मेट जैसे PNG में सामान्यित करना चाहते हैं, तो [IPPImage]::`get_Image()` को [IImage]::`Save` के साथ उपयोग करें।
{{% /alert %}}

## **साझा सहायक विधियाँ**

नीचे दी गई सहायक विधियां उदाहरणों को संक्षिप्त रखती हैं। `SaveOriginalImage` मूल एम्बेडेड बाइट्स को लिखता है, MIME प्रकार से एक सुरक्षित एक्सटेंशन चुनता है, और SHA-256 हैश द्वारा डुप्लिकेट छवि बाइनरी को छोड़ देता है।

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
    if (!savedImageHashes->Add(imageHash))
    {
        return false;
    }

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

    sha256->Dispose();
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

स्वतंत्र वस्तुओं के रूप में सम्मिलित छवियों के लिए इस दृष्टिकोण का उपयोग करें। एक [IPictureFrame] अपनी छवि को `get_PictureFormat()->get_Picture()->get_Image()` में संग्रहीत करता है, जो एक [IPPImage] वस्तु लौटाता है।

```cpp
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
```

## **चित्र-भराव आकारों से छवियों को निकालें**

आकार चित्र को अपने भराव के रूप में उपयोग कर सकते हैं। पहले आकार के भराव प्रकार की जाँच करें: यदि यह [FillType]::`Picture` नहीं है, तो उस भराव से निकालने के लिए कोई चित्र नहीं है। नीचे का उदाहरण [IAutoShape] वस्तुओं को संभालता है और प्रत्येक छवि को PNG के रूप में [IPPImage]::`get_Image()` के माध्यम से सहेजता है।

```cpp
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
```

## **OLE ऑब्जेक्ट फ्रेम से प्रीव्यू छवियों को निकालें**

एक [IOleObjectFrame] के पास एक प्रतिस्थापन चित्र हो सकता है जिसका उपयोग PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में करता है। यह छवि `get_SubstitutePictureFormat()->get_Picture()->get_Image()` के माध्यम से उपलब्ध होती है। इस चित्र को निकालने से आपको प्रीव्यू छवि मिलती है, न कि एम्बेडेड OLE पैकेज की सामग्री।

```cpp
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
```

## **वीडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [IVideoFrame] भी `get_PictureFormat()->get_Picture()->get_Image()` में एक प्रीव्यू छवि संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, न कि वीडियो स्ट्रीम से डिकोड किया गया फ्रेम।

```cpp
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
```

## **ऑडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [IAudioFrame] `get_PictureFormat()->get_Picture()->get_Image()` में एक थंबनेल संग्रहीत कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखाया गया छवि है।

```cpp
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
```

## **ज़ूम ऑब्जेक्ट्स से छवियों को निकालें**

[IZoomFrame] और [ISectionZoomFrame] आकार कस्टम छवियों का उपयोग कर सकते हैं। ज़ूम फ्रेम से `get_ZoomImage()` पढ़ें।

```cpp
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
```

## **समरी ज़ूम फ्रेम से छवियों को निकालें**

एक [ISummaryZoomFrame] भी एक आकार है। उसके सेक्शन आइटम कस्टम छवियों का उपयोग कर सकते हैं, जो प्रत्येक सामरी ज़ूम सेक्शन की `get_ZoomImage()` विधि के माध्यम से उजागर होते हैं।

```cpp
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
```

## **टेबल आकारों से छवियों को निकालें**

एक [ITable] एक आकार है। टेबल में छवियां सामान्यतः टेबल सेल में चित्र भराव के रूप में संग्रहीत रहती हैं।

```cpp
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
```

## **चार्ट आकारों से छवियों को निकालें**

एक [IChart] एक आकार है। नीचे का उदाहरण चार्ट एरिया के चित्र भराव से एक छवि निकालता है।

```cpp
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
```

## **SmartArt आकारों से छवियों को निकालें**

एक [ISmartArt] वस्तु एक आकार है। SmartArt लेआउट पर निर्भर करते हुए, छवियां नोड बुलेट भराव में या नोड आकारों के भराव स्वरूपों में संग्रहीत हो सकती हैं।

```cpp
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
```

## **समूहित आकारों के भीतर छवियों को शामिल करें**

समूहित आकारों के अपने स्वयं के आकार संग्रह होते हैं। साझा `EnumerateShapes` सहायक में एक `includeGroupedShapes` विकल्प है। जब आप [IGroupShape] वस्तुओं के भीतर आकारों की जांच करना चाहते हैं तो इसे `true` सेट करें। नीचे का उदाहरण चित्र फ्रेम, चित्र-भराव आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ्रेम थंबनेल, और ऑडियो फ्रेम थंबनेल से छवियों को निकालता है। तालिका, चार्ट, SmartArt, और समरी ज़ूम छवियों को भी शामिल करने के लिए, पिछले अनुभागों से विशेष निकासी लॉजिक को पुन: उपयोग करें जबकि समान पुनरावर्ती आकार traversal बनाए रखें।

```cpp
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
```

## **एज केस और व्यावहारिक नोट्स**

- **डुप्लिकेट छवियां:** कई आकार एक ही छवि या समान बाइट्स वाली अलग छवियों का संदर्भ दे सकते हैं। यदि आप प्रत्येक अद्वितीय छवि के लिए एक आउटपुट फ़ाइल चाहते हैं, तो फ़ाइल लिखने से पहले [IPPImage]::`get_BinaryData()` को हैश करें।
- **मूल डेटा बनाम परिवर्तित आउटपुट:** [IPPImage]::`get_BinaryData()` को सहेजने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा संरक्षित रहता है। जब आप एक समान आउटपुट फ़ॉर्मेट चाहते हैं तो [IPPImage]::`get_Image()` को [IImage]::`Save` के माध्यम से सहेजना उपयोगी है।
- **असमर्थित भराव प्रकार:** ठोस, ग्रेडिएंट, पैटर्न, और नो-फ़िल आकारों में चित्र भराव नहीं होता। `get_PictureFillFormat()` पढ़ने से पहले [FillType] की जाँच करें।
- **समूहित आकार:** शीर्ष-स्तर स्लाइड आकार संग्रह समूहों को फ्लैट नहीं करता। जब समूहित सामग्री महत्वपूर्ण हो, तो [IGroupShape]::`get_Shapes()` को पुनरावर्ती रूप से जांचें।
- **OLE ऑब्जेक्ट प्रीव्यू:** एक [IOleObjectFrame] `get_SubstitutePictureFormat()` के माध्यम से एक प्रीव्यू छवि दिखा सकता है, लेकिन वह छवि केवल स्लाइड प्रीव्यू है। यह OLE ऑब्जेक्ट के भीतर एम्बेडेड फ़ाइल नहीं है।
- **वीडियो फ्रेम थंबनेल:** एक [IVideoFrame] `get_PictureFormat()` के माध्यम से प्रीव्यू छवि दिखा सकता है, लेकिन वह छवि केवल स्लाइड पर दिखाए गए पोस्टर है। यह वीडियो स्ट्रीम से नहीं निकाली गई है।
- **ऑडियो फ्रेम थंबनेल:** एक [IAudioFrame] `get_PictureFormat()` के माध्यम से एक आइकन या थंबनेल दिखा सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **ज़ूम छवियां:** स्लाइड ज़ूम, सेक्शन ज़ूम, और समरी ज़ूम आकार कस्टम [IPPImage] वस्तुओं का उपयोग `get_ZoomImage()` के माध्यम से कर सकते हैं।
- **नेस्टेड आकार मॉडल:** तालिका, चार्ट, और SmartArt वस्तुएं [IShape] को लागू करती हैं, लेकिन उनकी छवियां अक्सर नेस्टेड तालिका सेल, चार्ट एलिमेंट, या SmartArt नोड फ़ॉर्मेटिंग वस्तुओं में संग्रहीत होती हैं।
- **क्रॉप्ड या ट्रांसफ़ॉर्म्ड चित्र:** [IPPImage] तक पहुंचने से आपको संग्रहित छवि संसाधन मिलता है। यह आकार द्वारा लागू क्रॉपिंग, ट्रांसपैरेंसी, रीकलरिंग, रोटेशन, या अन्य दृश्य प्रभावों को रेंडर नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मूल छवि को क्रॉपिंग, प्रभाव या आकार परिवर्तन के बिना निकाल सकता हूँ?**

हाँ। [IPPImage] वस्तु तक पहुंचें और [IPPImage]::`get_BinaryData()` को डिस्क पर लिखें। यह प्रस्तुति में संग्रहीत मूल एन्कोडेड छवि को संरक्षित करता है, न कि स्लाइड पर छवि के रेंडर होने का तरीका।

**क्या मैं प्रत्येक निकाली गई छवि को PNG के रूप में निर्यात कर सकता हूँ?**

हाँ। [IPPImage]::`get_Image()` का उपयोग करके एक [IImage] वस्तु प्राप्त करें, और फिर [IImage]::`Save` को [ImageFormat]::`Png` के साथ कॉल करें। यह आउटपुट को परिवर्तित करता है और मूल फ़ाइल प्रकार या वेक्टर डेटा को संरक्षित नहीं रख सकता।

**मैं एक ही छवि को कई बार सहेजने से कैसे बचूं?**

[IPPImage]::`get_BinaryData()` का हेश उपयोग करें और हेश को एक सेट में रखें। यदि कोई नई छवि का हेश पहले से मौजूद है, तो उसे छोड़ दें या मौजूदा आउटपुट फ़ाइल के लिए एक अन्य संदर्भ दर्ज करें।

**क्यों कुछ आकार छवि उत्पन्न नहीं करते?**

चित्र फ्रेम, चित्र-भराव आकार, OLE ऑब्जेक्ट फ्रेम, मीडिया फ्रेम, ज़ूम फ्रेम, तालिकाएँ, चार्ट, और SmartArt वस्तुएँ छवियों का संदर्भ दे सकती हैं। कुछ आकार प्रकार नेस्टेड फ़ॉर्मेटिंग वस्तुओं के माध्यम से छवियां उजागर करते हैं, इसलिए केवल `get_PictureFormat()` या आकार `get_FillFormat()` जाँच पर्याप्त नहीं है।

**क्या मैं वीडियो फ्रेम के लिए दिखाए गए थंबनेल को निकाल सकता हूँ?**

हाँ। [IVideoFrame]::`get_PictureFormat()` का उपयोग करें और `get_PictureFormat()->get_Picture()->get_Image()` पढ़ें। यह वीडियो फ्रेम के साथ संग्रहीत पोस्टर छवि को निकालता है, न कि वीडियो फ़ाइल से उत्पन्न कोई फ्रेम।

**मैं कैसे निर्धारित करूँ कि कौन से आकार प्रस्तुति छवि संग्रह में किसी विशिष्ट छवि का उपयोग करते हैं?**

Aspose.Slides [IPPImage] से आकारों की रिवर्स लिंक नहीं रखता। traversal के दौरान एक मैपिंग बनाएं: जब भी आप कोई छवि संदर्भ पाएँ, स्लाइड नंबर, आकार पथ, और छवि हेश या संग्रह आइटम को रिकॉर्ड करें।

**क्या मैं OLE ऑब्जेक्ट के भीतर एम्बेडेड छवियों, जैसे जुड़ी दस्तावेज़ों, को निकाल सकता हूँ?**

आप [IOleObjectFrame]::`get_SubstitutePictureFormat()` से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालाँकि, वह प्रीव्यू एम्बेडेड दस्तावेज़ स्वयं नहीं है। एम्बेडेड फ़ाइल के अंदर छवियों को निकालने के लिए, OLE डेटा निकालें और उस फ़ाइल प्रकार के उपकरणों से उसका निरीक्षण करें।