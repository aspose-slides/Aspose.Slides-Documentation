---
title: Extrahera bilder från presentationsformer i C++
linktitle: Bild från form
type: docs
weight: 90
url: /sv/cpp/extracting-images-from-presentation-shapes/
keywords:
- extrahera bild
- hämta bild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Extrahera bilder från former i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++ - snabb, kodvänlig lösning."
---
## **Översikt**

Bilder i en presentation kan visas i flera typ av former: som vanliga bildramar, som bildfyllningar som tillämpas på former, som förhandsgranskningsbilder för OLE-objekt, som miniatyrbilder för video- eller ljudramar, som zoombilder, eller som bilder som är inbäddade i tabell-, diagram- och SmartArt‑former. Aspose.Slides lagrar dessa bilder i presentationens bildsamling, som exponeras via [IImageCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimagecollection/) och [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/) objekt.

Om du bara behöver exportera varje bildresurs som är inbäddad i en presentation, iterera genom `presentation->get_Images()`. Denna artikel fokuserar på en annan uppgift: att gå igenom former för att hitta var bilder används på bilder, så att de sparade filerna kan behålla användbar kontext såsom bildnummer, formens position och källtyp (bildram, fyllningsbild, medieförhandsgranskning, OLE‑förhandsgranskning eller zoombild).

{{% alert title="Tips" color="primary" %}}
Använd [IPPImage]::`get_BinaryData()` för att behålla den ursprungliga kodade bilddata och filtypen. Använd [IPPImage]::`get_Image()` tillsammans med [IImage]::`Save` när du vill normalisera utdata till ett specifikt format som PNG.
{{% /alert %}}

## **Gemensamma hjälpfunktioner**

Hjälpfunktionerna nedan håller exemplen korta. `SaveOriginalImage` skriver de ursprungliga inbäddade byten, väljer en säker filändelse baserat på MIME‑typen och hoppar över duplicerade bildbinaryer med SHA‑256‑hash.

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

## **Extrahera bilder från bildramar**

Använd detta tillvägagångssätt för bilder som infogats som fristående objekt. En [IPictureFrame] lagrar sin bild i `get_PictureFormat()->get_Picture()->get_Image()`, vilket returnerar ett [IPPImage]-objekt.

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

## **Extrahera bilder från bildfyllda former**

Former kan använda en bild som fyllning. Kontrollera först formens fyllningstyp: om den inte är [FillType]::`Picture` finns det ingen bild att extrahera från den fyllningen. Exemplet nedan hanterar [IAutoShape]-objekt och sparar varje bild som PNG via [IPPImage]::`get_Image()`.

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

## **Extrahera förhandsgranskningsbilder från OLE‑objekt‑ramar**

En [IOleObjectFrame] kan ha en ersättningsbild som PowerPoint använder som objektets förhandsgranskning på en bild. Denna bild är tillgänglig via `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Att extrahera denna bild ger dig förhandsgranskningsbilden, inte innehållet i det inbäddade OLE‑paketet.

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

## **Extrahera förhandsgranskningsbilder från videoram**

En [IVideoFrame] kan också lagra en förhandsgranskningsbild i `get_PictureFormat()->get_Picture()->get_Image()`. Detta är postern eller miniatyrbilden som visas på bilden, inte en bildruta som avkodats från videoströmmen.

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

## **Extrahera förhandsgranskningsbilder från ljudramar**

En [IAudioFrame] kan lagra en miniatyrbild i `get_PictureFormat()->get_Picture()->get_Image()`. Detta är bilden som visas för ljudobjektet på bilden.

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

## **Extrahera bilder från zoom‑objekt**

[IZoomFrame] och [ISectionZoomFrame]-former kan använda anpassade bilder. Läs `get_ZoomImage()` från zoom‑ramen.

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

## **Extrahera bilder från sammanfattnings‑zoom‑ramar**

En [ISummaryZoomFrame] är också en form. Dess sektionselement kan använda anpassade bilder, som exponeras via varje sammanfattnings‑zoom‑sektion's `get_ZoomImage()`-metod.

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

## **Extrahera bilder från tabellformer**

En [ITable] är en form. Bilder i en tabell lagras vanligtvis som bildfyllningar i tabellceller.

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

## **Extrahera bilder från diagramformer**

En [IChart] är en form. Exemplet nedan extraherar en bild från diagramområdets bildfyllning.

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

## **Extrahera bilder från SmartArt‑former**

Ett [ISmartArt]-objekt är en form. Beroende på SmartArt‑layouten kan bilder lagras i nodpunkts‑fyllningar eller i fyllningsformaten för nodformer.

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

## **Inkludera bilder i grupperade former**

Grupperade former innehåller sina egna formsamlingar. Den delade hjälpfunktionen `EnumerateShapes` har ett alternativ `includeGroupedShapes`. Sätt det till `true` när du vill inspektera former inuti [IGroupShape]-objekt. Exemplet nedan extraherar bilder från bildramar, bildfyllda former, OLE‑objekt‑förhandsgranskningar, videoramas miniatyrbilder och ljudramars miniatyrbilder. För att även inkludera bilder från tabeller, diagram, SmartArt och sammanfattnings‑zoom‑bilder, återanvänd den specialiserade extraktionslogiken från de föregående sektionerna samtidigt som du behåller samma rekursiva formtraversering.

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

## **Särskilda fall och praktiska noteringar**

- **Duplicerade bilder:** Flera former kan referera till samma bild eller till separata bilder med identiska byte. Hasha [IPPImage]::`get_BinaryData()` innan du skriver filer om du vill ha en utdatafil per unik bild.
- **Original data vs. konverterad utdata:** Att spara [IPPImage]::`get_BinaryData()` behåller den inbäddade JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ eller WMF‑data. Att spara [IPPImage]::`get_Image()` via [IImage]::`Save` är användbart när du vill ha ett konsekvent utdataformat.
- **Ej stödda fyllningstyper:** Solid, gradient, pattern, och no-fill former innehåller ingen bildfyllning. Kontrollera [FillType] innan du läser `get_PictureFillFormat()`.
- **Grupperade former:** Den översta bildens formsamling plattar inte ner grupper. Inspektera rekursivt [IGroupShape]::`get_Shapes()` när grupperat innehåll är viktigt.
- **OLE‑objekt‑förhandsgranskningar:** En [IOleObjectFrame] kan exponera en förhandsgranskningsbild via `get_SubstitutePictureFormat()`, men den bilden är endast förhandsgranskning på bilden. Det är inte den inbäddade filen i OLE‑objektet.
- **Miniatyrbilder för videoram:** En [IVideoFrame] kan exponera en förhandsgranskningsbild via `get_PictureFormat()`, men den bilden är endast postern som visas på bilden. Den extraheras inte från videoströmmen.
- **Miniatyrbilder för ljudram:** En [IAudioFrame] kan exponera en ikon eller miniatyrbild via `get_PictureFormat()`; det är inte det inbäddade ljuddata.
- **Zoom‑bilder:** Slide‑zoom, sektion‑zoom och sammanfattnings‑zoom‑former kan använda anpassade [IPPImage]-objekt via `get_ZoomImage()`.
- **Nästlade formmodeller:** Tabell-, diagram- och SmartArt‑objekt implementerar [IShape], men deras bilder lagras ofta i nästlade tabellcell‑, diagram‑element‑ eller SmartArt‑nod‑formateringsobjekt.
- **Beskurna eller transformerade bilder:** Att få åtkomst till [IPPImage] ger dig den lagrade bildresursen. Det renderar inte beskärning, transparens, omfärgning, rotation eller andra visuella effekter som tillämpas av formen.

## **FAQ**

**Kan jag extrahera den ursprungliga bilden utan beskärning, effekter eller formtransformationer?**

Ja. Åtkomst till [IPPImage]-objektet och skriv [IPPImage]::`get_BinaryData()` till disk. Detta bevarar den ursprungliga kodade bilden som lagras i presentationen, inte hur bilden renderas på bilden.

**Kan jag exportera varje extraherad bild som PNG?**

Ja. Använd [IPPImage]::`get_Image()` för att få ett [IImage]-objekt, och anropa sedan [IImage]::`Save` med [ImageFormat]::`Png`. Detta konverterar utdata och kan sakna att bevara den ursprungliga filtypen eller vektordata.

**Hur undviker jag att spara samma bild mer än en gång?**

Använd en hash av [IPPImage]::`get_BinaryData()` och behåll hasharna i en uppsättning. Om en ny bild har en hash som redan finns, hoppa över den eller registrera en annan referens till den befintliga utdatafilen.

**Varför genererar vissa former ingen bild?**

Bildramar, bildfyllda former, OLE‑objekt‑ramar, mediaramar, zoom‑ramar, tabeller, diagram och SmartArt‑objekt kan referera till bilder. Vissa formtyper exponerar bilder via nästlade formateringsobjekt, så en enkel kontroll av `get_PictureFormat()` eller formens `get_FillFormat()` är inte alltid tillräcklig.

**Kan jag extrahera miniatyrbilden som visas för en videoram?**

Ja. Använd [IVideoFrame]::`get_PictureFormat()` och läs `get_PictureFormat()->get_Picture()->get_Image()`. Detta extraherar postern som lagras med videoramen, inte en bildruta som genererats från videofilen.

**Hur kan jag avgöra vilka former som använder en specifik bild från presentationens bildsamling?**

Aspose.Slides lagrar inte omvända länkar från [IPPImage] till former. Bygg en mappning under traverseringen: när du hittar en bildreferens, registrera bildnumret, formens sökväg och bildens hash eller samlingsobjekt.

**Kan jag extrahera bilder som är inbäddade i OLE‑objekt, såsom bifogade dokument?**

Du kan extrahera OLE‑objektets bildförhandsgranskning från [IOleObjectFrame]::`get_SubstitutePictureFormat()`. Den förhandsgranskningen är dock inte det inbäddade dokumentet i sig. För att extrahera bilder från den inbäddade filen, extrahera OLE‑data och inspektera den med verktyg för den filtypen.