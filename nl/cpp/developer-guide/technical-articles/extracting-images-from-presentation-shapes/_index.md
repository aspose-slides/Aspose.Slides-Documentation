---
title: Afbeeldingen extraheren uit presentatievormen in C++
linktitle: Afbeelding van vorm
type: docs
weight: 90
url: /nl/cpp/extracting-images-from-presentation-shapes/
keywords:
- afbeelding extraheren
- afbeelding ophalen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Afbeeldingen extraheren uit vormen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++ – snelle, codevriendelijke oplossing."
---
## **Overzicht**

Afbeeldingen in een presentatie kunnen voorkomen in verschillende vormtypen: als gewone afbeeldingskaders, als afbeeldingvullingen toegepast op vormen, als OLE‑object voorbeeldafbeeldingen, als video‑ of audio‑kader miniaturen, als zoom‑afbeeldingen, of als afbeeldingen genest in tabel-, diagram‑ en SmartArt‑vormen. Aspose.Slides slaat die afbeeldingen op in de presentatie‑afbeeldingscollectie, blootgelegd via [IImageCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimagecollection/) en [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) objecten.

Als je alleen elke in de presentatie ingesloten beeldbron wilt exporteren, doorloop dan `presentation->get_Images()`. Dit artikel richt zich op een andere taak: het doorlopen van vormen om te vinden waar afbeeldingen worden gebruikt op dia's, zodat de opgeslagen bestanden nuttige context kunnen behouden zoals het dia‑nummer, de vormpositie en het brontype (afbeeldingskader, vulling, media‑voorbeeld, OLE‑voorbeeld of zoom‑afbeelding).

{{% alert title="Tip" color="primary" %}}
Gebruik [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)::`get_BinaryData()` om de originele gecodeerde afbeeldingsdata en bestandstype te behouden. Gebruik [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)::`get_Image()` met [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)::`Save` wanneer je de uitvoer wilt normaliseren naar een specifiek formaat zoals PNG.
{{% /alert %}}

## **Gedeelde hulpmethoden**

De hulpmethoden hieronder houden de voorbeelden kort. `SaveOriginalImage` schrijft de originele ingesloten bytes, kiest een veilige extensie op basis van het MIME‑type, en slaat duplicate afbeeldings‑binaire bestanden over op basis van een SHA‑256 hash.

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

## **Afbeeldingen extraheren uit afbeeldingskaders**

Gebruik deze aanpak voor afbeeldingen die als zelfstandige objecten zijn ingevoegd. Een [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/) slaat zijn afbeelding op in `get_PictureFormat()->get_Picture()->get_Image()`, wat een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) object retourneert.

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

## **Afbeeldingen extraheren uit vormen met afbeeldingvulling**

Vormen kunnen een afbeelding als vulling gebruiken. Controleer eerst het vullingstype van de vorm: als het niet [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/)::`Picture` is, is er geen afbeelding om uit die vulling te extraheren. Het voorbeeld hieronder verwerkt [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) objecten en slaat elke afbeelding op als PNG via [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Voorbeeldafbeeldingen extraheren uit OLE‑objectkaders**

Een [IOleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleobjectframe/) kan een vervangende afbeelding hebben die PowerPoint gebruikt als voorbeeld van het object op een dia. Deze afbeelding is beschikbaar via `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Het extraheren van deze afbeelding levert de voorbeeldafbeelding op, niet de inhoud van het ingesloten OLE‑pakket.

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

## **Voorbeeldafbeeldingen extraheren uit videokaders**

Een [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/) kan ook een voorbeeldafbeelding opslaan in `get_PictureFormat()->get_Picture()->get_Image()`. Dit is de poster of miniatuur die op de dia wordt getoond, niet een frame gedecodeerd uit de videostream.

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

## **Voorbeeldafbeeldingen extraheren uit audiokaders**

Een [IAudioFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iaudioframe/) kan een miniatuur opslaan in `get_PictureFormat()->get_Picture()->get_Image()`. Dit is de afbeelding die wordt getoond voor het audio‑object op de dia.

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

## **Afbeeldingen extraheren uit zoomobjecten**

[IZoomFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/izoomframe/) en [ISectionZoomFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectionzoomframe/) vormen kunnen aangepaste afbeeldingen gebruiken. Lees `get_ZoomImage()` van het zoom‑frame.

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

## **Afbeeldingen extraheren uit samenvattende zoomkaders**

Een [ISummaryZoomFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isummaryzoomframe/) is ook een vorm. De sectie‑items kunnen aangepaste afbeeldingen gebruiken, beschikbaar via de `get_ZoomImage()` methode van elke samenvattende zoomsectie.

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

## **Afbeeldingen extraheren uit tabelvormen**

Een [ITable](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itable/) is een vorm. Afbeeldingen in een tabel worden meestal opgeslagen als afbeeldingvullingen in tabelcellen.

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

## **Afbeeldingen extraheren uit diagramvormen**

Een [IChart](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/) is een vorm. Het voorbeeld hieronder extraheert een afbeelding uit de afbeeldingsvulling van het diagramgebied.

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

## **Afbeeldingen extraheren uit SmartArt‑vormen**

Een [ISmartArt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/ismartart/) object is een vorm. Afhankelijk van de SmartArt‑indeling kunnen afbeeldingen opgeslagen zijn in knooppunt‑bullet‑vullingen of in de vullingsformaten van knooppunt‑vormen.

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

## **Afbeeldingen opnemen in gegroepeerde vormen**

Gegroepeerde vormen bevatten hun eigen vormcollecties. De gedeelde `EnumerateShapes`‑helper heeft een `includeGroupedShapes` optie. Zet deze op `true` wanneer je vormen binnen [IGroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igroupshape/) objecten wilt inspecteren. Het voorbeeld hieronder extraheert afbeeldingen uit afbeeldingskaders, vormen met afbeeldingvulling, OLE‑objectvoorbeelden, videokader‑miniaturen en audio‑kader‑miniaturen. Om ook tabel‑, diagram‑, SmartArt‑ en samenvattende zoom‑afbeeldingen op te nemen, hergebruik je de gespecialiseerde extractielogica uit de vorige secties terwijl je dezelfde recursieve vorm‑traversering behoudt.

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

## **Randgevallen en praktische opmerkingen**

- **Duplicaat‑afbeeldingen:** Meerdere vormen kunnen naar dezelfde afbeelding verwijzen of naar verschillende afbeeldingen met identieke bytes. Hash [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)::`get_BinaryData()` voordat je bestanden schrijft als je één uitvoerbestand per unieke afbeelding wilt.
- **Originele data vs. geconverteerde output:** Het opslaan van [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)::`get_BinaryData()` behoudt de ingesloten JPEG-, PNG-, GIF-, SVG-, EMF- of WMF‑data. Het opslaan van [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)::`get_Image()` via [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)::`Save` is nuttig wanneer je een consistent uitvoerformaat wilt.
- **Niet‑ondersteunde vullingstypen:** Vullingen van solid, gradient, pattern en geen‑vulling bevatten geen afbeeldingvulling. Controleer [FillType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/filltype/) voordat je `get_PictureFillFormat()` leest.
- **Gegroepeerde vormen:** De bovenliggende dia‑vormcollectie maakt geen groepen plat. Inspecteer recursief [IGroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igroupshape/)::`get_Shapes()` wanneer gegroepeerde inhoud van belang is.
- **OLE‑objectvoorbeelden:** Een [IOleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleobjectframe/) kan een voorbeeldafbeelding blootleggen via `get_SubstitutePictureFormat()`, maar die afbeelding is alleen het dia‑voorbeeld. Het is niet het ingesloten bestand binnen het OLE‑object.
- **Videokader‑miniaturen:** Een [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/) kan een voorbeeldafbeelding blootleggen via `get_PictureFormat()`, maar die afbeelding is alleen de poster die op de dia wordt getoond. Het wordt niet uit de videostream gehaald.
- **Audiokader‑miniaturen:** Een [IAudioFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iaudioframe/) kan een pictogram of miniatuur blootleggen via `get_PictureFormat()`; dit is niet de ingesloten audio‑data.
- **Zoom‑afbeeldingen:** Slide‑zoom, sectie‑zoom en samenvattende zoom‑vormen kunnen aangepaste [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) objecten gebruiken via `get_ZoomImage()`.
- **Geneste vormmodellen:** Tabel-, diagram‑ en SmartArt‑objecten implementeren [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/), maar hun afbeeldingen worden vaak opgeslagen in geneste tabelcel‑, diagram‑element‑ of SmartArt‑knooppunt‑formattering‑objecten.
- **Bijsneden of getransformeerde afbeeldingen:** Toegang tot [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) geeft je de opgeslagen afbeeldingresource. Het rendert geen bijsnijden, transparantie, recoloratie, rotatie of andere visuele effecten die door de vorm zijn toegepast.

## **FAQ**

**Kan ik de originele afbeelding extraheren zonder bijsnijden, effecten of vormtransformaties?**

Ja. Benader het [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) object en schrijf [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)::`get_BinaryData()` naar schijf. Dit behoudt de originele gecodeerde afbeelding die in de presentatie is opgeslagen, niet de manier waarop de afbeelding op de dia wordt gerenderd.

**Kan ik elke geëxtraheerde afbeelding exporteren als PNG?**

Ja. Gebruik [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)::`get_Image()` om een [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/) object te krijgen, en roep vervolgens [IImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iimage/)::`Save` aan met [ImageFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imageformat/)::`Png`. Dit converteert de output en behoudt mogelijk niet het originele bestandsformaat of vector‑data.

**Hoe vermijd ik dat dezelfde afbeelding meer dan eens wordt opgeslagen?**

Gebruik een hash van [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/)::`get_BinaryData()` en bewaar de hashes in een set. Als een nieuwe afbeelding een hash heeft die al bestaat, sla deze dan over of noteer een andere verwijzing naar het bestaande uitvoerbestand.

**Waarom leveren sommige vormen geen afbeelding?**

Afbeeldingskaders, vormen met afbeeldingvulling, OLE‑objectkaders, mediakaders, zoom‑kaders, tabellen, diagrammen en SmartArt‑objecten kunnen naar afbeeldingen verwijzen. Sommige vormtypen exposeren afbeeldingen via geneste formatteringsobjecten, dus een eenvoudige `get_PictureFormat()` of vorm `get_FillFormat()` controle is niet altijd voldoende.

**Kan ik de miniatuur die wordt getoond voor een videokader extraheren?**

Ja. Gebruik [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` en lees `get_PictureFormat()->get_Picture()->get_Image()`. Dit extraheert de poster‑afbeelding die is opgeslagen bij het videokader, niet een frame dat uit het videobestand is gegenereerd.

**Hoe kan ik bepalen welke vormen een specifieke afbeelding uit de presentatie‑afbeeldingscollectie gebruiken?**

Aspose.Slides slaat geen omgekeerde koppelingen op van [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) naar vormen. Bouw een mapping tijdens de traversering: wanneer je een afbeeldingsreferentie vindt, noteer het dia‑nummer, het vormpad en de afbeeldings‑hash of collectie‑item.

**Kan ik afbeeldingen extraheren die zijn ingebed in OLE‑objecten, zoals bijgevoegde documenten?**

Je kunt het dia‑voorbeeld van het OLE‑object extraheren via [IOleObjectFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`. Echter, dat voorbeeld is niet het ingebedde document zelf. Om afbeeldingen uit het ingebedde bestand te halen, moet je de OLE‑data extraheren en deze inspecteren met tools die geschikt zijn voor dat bestandstype.