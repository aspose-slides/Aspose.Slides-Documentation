---
title: Extrahování obrázků z tvarů prezentace v C++
linktitle: Obrázek ze tvaru
type: docs
weight: 90
url: /cs/cpp/extracting-images-from-presentation-shapes/
keywords:
- extrahovat obrázek
- získat obrázek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Extrahujte obrázky z tvarů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++ – rychlé, programátorsky přátelské řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou objevit v několika typech tvarů: jako běžné rámy obrázků, jako výplně obrázkem aplikované na tvary, jako náhledové obrázky OLE objektů, jako miniatury video‑ nebo audio‑rámů, jako zoom obrázky nebo jako obrázky vnořené v tabulkách, grafech a tvarech SmartArt. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, která je dostupná prostřednictvím objektů [IImageCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimagecollection/) a [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) .

Pokud potřebujete pouze exportovat všechny obrázkové zdroje vložené v prezentaci, projděte `presentation->get_Images()`. Tento článek se zaměřuje na jiný úkol: procházet tvary a najít, kde jsou obrázky na snímcích použity, aby uložené soubory mohly zachovat užitečný kontext, jako je číslo snímku, pozice tvaru a typ zdroje (rám obrázku, výplň obrázkem, náhled média, náhled OLE nebo zoom obrázek).

{{% alert title="Tip" color="primary" %}}
Použijte [IPPImage]::`get_BinaryData()` k zachování původních kódovaných dat obrázku a typu souboru. Použijte [IPPImage]::`get_Image()` s [IImage]::`Save`, pokud chcete normalizovat výstup do konkrétního formátu, například PNG.
{{% /alert %}}

## **Sdílené pomocné metody**

Následující pomocné metody zkracují příklady. `SaveOriginalImage` zapisuje původní vložené bajty, vybírá bezpečnou příponu podle MIME typu a přeskočí duplicitní binární data obrázku pomocí SHA‑256 hashe.

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
    if (mediaType == u"image/bbmp")
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

## **Extrahování obrázků z rámců obrázků**

Použijte tento přístup pro obrázky vložené jako samostatné objekty. [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) ukládá svůj obrázek v `get_PictureFormat()->get_Picture()->get_Image()`, což vrací objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) .

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

## **Extrahování obrázků z tvarů vyplněných obrázkem**

Tvary mohou používat obrázek jako výplň. Nejprve zkontrolujte typ výplně tvaru: pokud není [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/)::`Picture`, neexistuje obrázek, který by se z výplně mohl extrahovat. Níže uvedený příklad zpracovává objekty [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) a ukládá každý obrázek jako PNG pomocí [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_Image()` .

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

## **Extrahování náhledových obrázků z rámců OLE objektů**

[IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/) může mít náhradní obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je dostupný skrze `get_SubstitutePictureFormat()->get_Picture()->get_Image()` . Extrahování tohoto obrázku vám poskytne náhledový obrázek, nikoli vložený obsah OLE balíčku.

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

## **Extrahování náhledových obrázků z video rámců**

[IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/) může také uložit náhledový obrázek v `get_PictureFormat()->get_Picture()->get_Image()` . Jedná se o plakát nebo miniaturu zobrazenou na snímku, nikoli o snímek dekódovaný z video proudu.

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

## **Extrahování náhledových obrázků z audio rámců**

[IAudioFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudioframe/) může uložit miniaturu v `get_PictureFormat()->get_Picture()->get_Image()` . Jedná se o obrázek zobrazovaný pro audio objekt na snímku.

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

## **Extrahování obrázků ze zoom objektů**

[IZoomFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/izoomframe/) a [ISectionZoomFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectionzoomframe/) mohou používat vlastní obrázky. Přečtěte `get_ZoomImage()` ze zoom rámce.

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

## **Extrahování obrázků ze souhrnných zoom rámců**

[ISummaryZoomFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isummaryzoomframe/) je také tvar. Jeho sekční položky mohou používat vlastní obrázky, které jsou vystaveny přes metodu `get_ZoomImage()` každé sekce souhrnného zoomu.

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

## **Extrahování obrázků z tvarů tabulek**

[ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) je tvar. Obrázky v tabulce jsou obvykle uloženy jako výplně obrázkem v buňkách tabulky.

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

## **Extrahování obrázků z tvarů grafů**

[IChart](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/) je tvar. Níže uvedený příklad extrahuje obrázek z výplně obrázkem oblasti grafu.

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

## **Extrahování obrázků z tvarů SmartArt**

[ISmartArt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/ismartart/) je objekt tvaru. V závislosti na rozložení SmartArt mohou být obrázky uloženy ve výplních odrážek uzlů nebo ve formátech výplní uzlových tvarů.

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

## **Zahrnutí obrázků uvnitř seskupených tvarů**

Seskupené tvary obsahují své vlastní kolekce tvarů. Sdílený pomocník `EnumerateShapes` má možnost `includeGroupedShapes`. Nastavte ji na `true`, pokud chcete prohlížet tvary uvnitř objektů [IGroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igroupshape/) . Níže uvedený příklad extrahuje obrázky z rámců obrázků, tvarů vyplněných obrázkem, náhledů OLE objektů, miniatur video rámců a miniatur audio rámců. Pro zahrnutí obrázků z tabulek, grafů, SmartArt a souhrnných zoomů použijte specializovanou logiku extrakce z předchozích sekcí při zachování stejného rekurzivního procházení tvarů.

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

## **Okrajové případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na různé obrázky se stejnými bajty. Vytvořte hash pomocí [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_BinaryData()` před zápisem souborů, pokud chcete jeden výstupní soubor na jedinečný obrázek.
- **Původní data vs. konvertovaný výstup:** Ukládání [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_BinaryData()` zachovává vložená data JPEG, PNG, GIF, SVG, EMF nebo WMF. Ukládání [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_Image()` přes [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/)::`Save` je užitečné, když chcete konzistentní výstupní formát.
- **Nepodporované typy výplní:** Tvary s plnou, gradientní, vzorovou nebo žádnou výplní neobsahují obrázkovou výplň. Zkontrolujte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) před čtením `get_PictureFillFormat()` .
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku nevyrovnává seskupení. Rekurzivně prohlédněte [IGroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igroupshape/)::`get_Shapes()` , pokud jsou seskupené obsahy důležité.
- **Náhledy OLE objektů:** [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/) může vystavit náhledový obrázek přes `get_SubstitutePictureFormat()`, ale tento obrázek je jen náhled snímku. Nejedná se o vložený soubor uvnitř OLE objektu.
- **Miniatury video rámců:** [IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/) může vystavit náhledový obrázek přes `get_PictureFormat()`, ale tento obrázek je jen plakát zobrazený na snímku. Není extrahován z video proudu.
- **Miniatury audio rámců:** [IAudioFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudioframe/) může vystavit ikonu nebo miniaturu přes `get_PictureFormat()`; není to vložený audio data.
- **Zoom obrázky:** Tvary slide zoom, section zoom a summary zoom mohou používat vlastní objekty [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) přes `get_ZoomImage()` .
- **Vnořené modely tvarů:** Objektů tabulka, graf a SmartArt implementují [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) , ale jejich obrázky jsou často uloženy ve vnořených buňkách tabulky, prvcích grafu nebo formátovacích objektech uzlů SmartArt.
- **Oříznuté nebo transformované obrázky:** Přístup k [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) poskytuje uložený obrázkový zdroj. Nevykresluje ořez, průhlednost, přeobarvení, rotaci ani jiné vizuální efekty aplikované tvarem.

## **Často kladené otázky**

**Mohu extrahovat původní obrázek bez ořezů, efektů nebo transformací tvaru?**

Ano. Přistupte k objektu [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) a zapište [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_BinaryData()` na disk. Tím se zachová původní kódovaný obrázek uložený v prezentaci, nikoli způsob, jakým je obrázek renderován na snímku.

**Mohu exportovat každý extrahovaný obrázek jako PNG?**

Ano. Použijte [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_Image()` k získání objektu [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/) a poté zavolejte [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/)::`Save` s [ImageFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imageformat/)::`Png`. Tento převod může nezachovat původní typ souboru nebo vektorová data.

**Jak zabránit vícenásobnému uložení stejného obrázku?**

Vytvořte hash z [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_BinaryData()` a udržujte hashe v množině. Pokud nový obrázek má hash, který již existuje, přeskočte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

**Proč některé tvary nevytvoří obrázek?**

Rámy obrázků, tvary vyplněné obrázkem, OLE objektové rámce, mediální rámy, zoom rámy, tabulky, grafy a objekty SmartArt mohou odkazovat na obrázky. Některé typy tvarů vystavují obrázky přes vnořené formátovací objekty, takže jednoduchá kontrola `get_PictureFormat()` nebo `get_FillFormat()` tvaru není vždy dostačující.

**Mohu extrahovat miniaturu zobrazenou pro video rám?**

Ano. Použijte [IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` a přečtěte `get_PictureFormat()->get_Picture()->get_Image()` . Tím získáte plakátový obrázek uložený s video rámem, nikoli snímek vygenerovaný z video souboru.

**Jak mohu určit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?**

Aspose.Slides neuchovává reverzní odkazy z [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) na tvary. Vytvořte mapování během procházení: kdykoli najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu tvaru a hash nebo položku kolekce obrázku.

**Mohu extrahovat obrázky vložené uvnitř OLE objektů, například připojené dokumenty?**

Můžete extrahovat náhled OLE objektu z [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` . Tento náhled však není samotný vložený dokument. Pro extrahování obrázků z vnitřku vloženého souboru musíte extrahovat OLE data a prozkoumat je nástroji určenými pro daný typ souboru.