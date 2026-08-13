---
title: Extrahovat obrázky z tvarů prezentace v C++
linktitle: Obrázek z tvaru
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
description: "Extrahovat obrázky z tvarů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++ – rychlé, programátorsky přívětivé řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou objevit v několika typech tvarů: jako běžné rámečky obrázků, jako výplně obrázky aplikované na tvary, jako náhledové obrázky OLE objektů, jako miniatury video‑ nebo audio‑rámců, jako zoomové obrázky nebo jako obrázky vložené do tabulek, grafů a tvarů SmartArt. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, která je zpřístupněna přes objekty [IImageCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimagecollection/) a [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/).

Pokud potřebujete pouze exportovat všechny obrázkové zdroje vložené v prezentaci, projděte `presentation->get_Images()`. Tento článek se zaměřuje na jiný úkol: procházení tvarů za účelem nalezení, kde jsou obrázky na snímcích použity, aby uložené soubory mohly zachovat užitečný kontext, jako je číslo snímku, pozice tvaru a typ zdroje (rámec obrázku, obrázek výplně, náhled média, náhled OLE nebo zoomový obrázek).

{{% alert title="Tip" color="info" %}}
Použijte [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_BinaryData()` k zachování původních kódovaných dat obrázku a typu souboru. Použijte [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_Image()` s [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/)::`Save`, když chcete normalizovat výstup do konkrétního formátu, například PNG.
{{% /alert %}}

## **Sdílené pomocné metody**

Pomocné metody níže zkracují příklady. `SaveOriginalImage` zapisuje původní vložené bajty, vybírá bezpečnou příponu z MIME typu a přeskočí duplicitní binární data obrázku pomocí SHA‑256 haše.

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

## **Extrahovat obrázky z rámečků obrázků**

Tento postup použijte pro obrázky vložené jako samostatné objekty. [IPictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipictureframe/) ukládá svůj obrázek v `get_PictureFormat()->get_Picture()->get_Image()`, což vrací objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/).

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

## **Extrahovat obrázky ze tvarů vyplněných obrázkem**

Tvar může používat obrázek jako výplň. Nejprve zkontrolujte typ výplně tvaru: pokud to není [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/)::`Picture`, neexistuje žádný obrázek k extrahování z této výplně. Níže uvedený příklad zpracovává objekty [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) a ukládá každý obrázek jako PNG pomocí [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Extrahovat náhledové obrázky z OLE objektových rámců**

[IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/) může mít náhradní obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je dostupný přes `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Extrahování tohoto obrázku vám poskytne náhledový obrázek, nikoli vložený obsah OLE balíčku.

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

## **Extrahovat náhledové obrázky z video rámců**

[IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/) může také uchovávat náhledový obrázek v `get_PictureFormat()->get_Picture()->get_Image()`. Jedná se o plakát nebo miniaturu zobrazenou na snímku, nikoli o snímek dekódovaný z video proudu.

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

## **Extrahovat náhledové obrázky z audio rámců**

[IAudioFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudioframe/) může uložit miniaturu v `get_PictureFormat()->get_Picture()->get_Image()`. Jedná se o obrázek zobrazený pro audio objekt na snímku.

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

## **Extrahovat obrázky ze zoomových objektů**

[Tvary](https://reference.aspose.com/slides/cs/cpp/aspose.slides/izoomframe/) [IZoomFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/izoomframe/) a [ISectionZoomFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectionzoomframe/) mohou používat vlastní obrázky. Načtěte `get_ZoomImage()` ze zoomového rámce.

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

## **Extrahovat obrázky ze souhrnných zoomových rámců**

[ISummaryZoomFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isummaryzoomframe/) je také tvar. Jeho položky sekcí mohou používat vlastní obrázky, k nimž se přistupuje pomocí metody `get_ZoomImage()` každé sekce souhrnného zoomu.

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

## **Extrahovat obrázky z tvarů tabulky**

[ITable](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itable/) je tvar. Obrázky v tabulce jsou obvykle uloženy jako výplně obrázků v buňkách tabulky.

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

## **Extrahovat obrázky z tvarů grafu**

[IChart](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/) je tvar. Níže uvedený příklad extrahuje obrázek z výplně obrázkem oblasti grafu.

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

## **Extrahovat obrázky z tvarů SmartArt**

Objekt [ISmartArt](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/ismartart/) je tvar. V závislosti na rozložení SmartArt mohou být obrázky uloženy ve výplních odrážek uzlů nebo ve výplňových formátech tvarů uzlů.

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

## **Zahrnout obrázky uvnitř seskupených tvarů**

Seskupené tvary obsahují své vlastní kolekce tvarů. Sdílená pomocná metoda `EnumerateShapes` má volbu `includeGroupedShapes`. Nastavte ji na `true`, pokud chcete zkoumat tvary uvnitř objektů [IGroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igroupshape/). Níže uvedený příklad extrahuje obrázky z rámečků obrázků, tvarů vyplněných obrázkem, náhledů OLE objektů, miniatur video rámců a miniatur audio rámců. Pro zahrnutí obrázků tabulek, grafů, SmartArt a souhrnných zoomů také, použijte specializovanou logiku extrakce z předchozích sekcí při zachování stejného rekurzivního procházení tvarů.

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

## **Okrajové případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na samostatné obrázky se stejnými bajty. Vytvořte haš z [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_BinaryData()` před zápisem souborů, pokud chcete jeden výstupní soubor na unikátní obrázek.
- **Originální data vs. převedený výstup:** Ukládání [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_BinaryData()` zachovává vložená data JPEG, PNG, GIF, SVG, EMF nebo WMF. Ukládání [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_Image()` přes [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/)::`Save` je užitečné, když chcete jednotný výstupní formát.
- **Nepodporované typy výplní:** Tvary s plnou, gradientní, vzorovanou nebo žádnou výplní neobsahují výplň obrázkem. Zkontrolujte [FillType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/filltype/) před čtením `get_PictureFillFormat()`.
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku nevyrovnává skupiny. Rekurzivně prozkoumejte [IGroupShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igroupshape/)::`get_Shapes()`, pokud je seskupený obsah důležitý.
- **Náhledy OLE objektů:** [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/) může zobrazit náhledový obrázek přes `get_SubstitutePictureFormat()`, ale tento obrázek je jen náhled na snímku. Nejedná se o vložený soubor uvnitř OLE objektu.
- **Miniatury video rámců:** [IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/) může zobrazit náhledový obrázek přes `get_PictureFormat()`, ale tento obrázek je jen plakát zobrazený na snímku. Není extrahován z video proudu.
- **Miniatury audio rámců:** [IAudioFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iaudioframe/) může zobrazit ikonu nebo miniaturu přes `get_PictureFormat()`; nejde o vložená audio data.
- **Zoomové obrázky:** Tvary slide zoom, section zoom a summary zoom mohou používat vlastní objekty [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) přes `get_ZoomImage()`.
- **Vnořené modely tvarů:** Objektů tabulka, graf a SmartArt implementují [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), ale jejich obrázky jsou často uloženy ve vnořených buňkách tabulky, prvcích grafu nebo formátovacích objektech uzlů SmartArt.
- **Oříznuté nebo transformované obrázky:** Přístup k [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) vám poskytne uložený obrázkový zdroj. Neprovádí vykreslení oříznutí, průhlednosti, změny barev, rotace ani dalších vizuálních efektů aplikovaných tvarem.

## **Často kladené otázky**

### Můžu extrahovat původní obrázek bez oříznutí, efektů nebo transformací tvaru?

Ano. Přistupte k objektu [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) a zapište [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_BinaryData()` na disk. Tím zachováte původní kódovaný obrázek uložený v prezentaci, nikoli způsob, jakým je obrázek vykreslen na snímku.

### Mohu exportovat každý extrahovaný obrázek jako PNG?

Ano. Použijte [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_Image()` k získání objektu [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/), a poté zavolejte [IImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iimage/)::`Save` s [ImageFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imageformat/)::`Png`. Toto převádí výstup a nemusí zachovat původní typ souboru nebo vektorová data.

### Jak se vyhnout uložení stejného obrázku vícekrát?

Použijte haš z [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/)::`get_BinaryData()` a uložte haše do množiny. Pokud nový obrázek má haš, který již existuje, přeskakujte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

### Proč některé tvary nevytvářejí obrázek?

Rámečky obrázků, tvary vyplněné obrázkem, OLE objektové rámy, mediální rámy, zoomové rámy, tabulky, grafy a objekty SmartArt mohou odkazovat na obrázky. Některé typy tvarů zpřístupňují obrázky prostřednictvím vnořených formátovacích objektů, takže jednoduchá kontrola `get_PictureFormat()` nebo `get_FillFormat()` tvaru není vždy dostatečná.

### Mohu extrahovat miniaturu zobrazovanou pro video rámec?

Ano. Použijte [IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` a přečtěte `get_PictureFormat()->get_Picture()->get_Image()`. Toto extrahuje plakátový obrázek uložený s video rámcem, ne snímek vytvořený ze souboru videa.

### Jak mohu určit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?

Aspose.Slides neukládá zpětné odkazy z [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) na tvary. Vytvořte mapování během procházení: kdykoli najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu tvaru a haš obrázku nebo položku v kolekci.

### Můžu extrahovat obrázky vložené uvnitř OLE objektů, jako jsou připojené dokumenty?

Můžete extrahovat náhled OLE objektu ze [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`. Tento náhled však není samotný vložený dokument. Pro extrakci obrázků z vnitřku vloženého souboru nejprve extrahujte OLE data a prozkoumejte je pomocí nástrojů pro daný typ souboru.