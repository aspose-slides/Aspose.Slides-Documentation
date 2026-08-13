---
title: "Képek kinyerése prezentáció alakzatokból C++‑ban"
linktitle: "Kép az alakzatról"
type: docs
weight: 90
url: /hu/cpp/extracting-images-from-presentation-shapes/
keywords:
- "kép kinyerése"
- "kép lekérése"
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Képek kinyerése PowerPoint és OpenDocument prezentációk alakzataiból az Aspose.Slides for C++ segítségével – gyors, kódbarát megoldás."
---
## **Áttekintés**

A prezentációban a képek többféle alakzat típusban jelenhetnek meg: mint egyszerű képkeretek, alakzatokra alkalmazott képkitöltések, OLE‑objektum előnézeti képek, videó‑ vagy hangkeret bélyegképek, nagyítási képek, vagy a táblázat, diagram és SmartArt alakzatokba ágyazott képek. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjteményében tárolja, amely a [IImageCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimagecollection/) és a [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumokon keresztül érhető el.

Ha csak a prezentációba beágyazott minden képes erőforrást szeretné exportálni, akkor iteráljon a `presentation->get_Images()`‑en. Ez a cikk egy másik feladatra koncentrál: az alakzatok bejárására, hogy megtalálja, hol használják a képeket a diákon, így a mentett fájlok hasznos kontextust is megőrizhetnek, például a dia számát, az alakzat pozícióját és a forrástípust (képkeret, kitöltő kép, média előnézet, OLE előnézet vagy nagyítási kép).

{{% alert title="Tip" color="info" %}}
Használja a [IPPImage]::`get_BinaryData()`‑t az eredeti kódolt képadatok és fájltípus megőrzéséhez. Használja a [IPPImage]::`get_Image()`‑t a [IImage]::`Save`‑kel, ha a kimenetet egy adott formátumra, például PNG‑re szeretné normalizálni.
{{% /alert %}}

## **Megosztott segítő metódusok**

Az alábbi segítő metódusok rövidítik a példákat. A `SaveOriginalImage` az eredeti beágyazott bájtokat írja, a MIME‑típus alapján biztonságos kiterjesztést választ, és a SHA‑256 hash alapján kihagyja a duplikált kép binárisokat.

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

## **Képek kinyerése képkeretekből**

Használja ezt a megközelítést a önálló objektumként beszúrt képekhez. Egy [IPictureFrame] a képét a `get_PictureFormat()->get_Picture()->get_Image()`‑ben tárolja, amely egy [IPPImage] objektumot ad vissza.

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

## **Képek kinyerése képkitöltésű alakzatokból**

Az alakzatok használhatnak képet kitöltésként. Először ellenőrizze az alakzat kitöltés típusát: ha nem [FillType]::`Picture`, nincs kép, amit ebből a kitöltésből ki lehetne nyerni. Az alábbi példa a [IAutoShape] objektumokat kezeli, és minden képet PNG‑ként ment a [IPPImage]::`get_Image()` segítségével.

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

## **Előnézeti képek kinyerése OLE‑objektumkeretekből**

Egy [IOleObjectFrame] tartalmazhat helyettesítő képet, amelyet a PowerPoint az objektum dián megjelenő előnézeteként használ. Ez a kép a `get_SubstitutePictureFormat()->get_Picture()->get_Image()`‑en keresztül érhető el. A kép kinyerése az előnézeti képet adja, nem az beágyazott OLE‑csomag tartalmát.

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

## **Előnézeti képek kinyerése videókeretekből**

Egy [IVideoFrame] szintén tárolhat előnézeti képet a `get_PictureFormat()->get_Picture()->get_Image()`‑ben. Ez a dián megjelenő plakát vagy bélyegkép, nem egy a videófolyamból dekódolt keret.

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

## **Előnézeti képek kinyerése hangkeretekből**

Egy [IAudioFrame] tárolhat bélyegképet a `get_PictureFormat()->get_Picture()->get_Image()`‑ben. Ez a hangobjektus dián megjelenő kép.

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

## **Képek kinyerése Zoom objektumokból**

A [IZoomFrame] és a [ISectionZoomFrame] alakzatok egyedi képeket használhatnak. Olvassa ki a `get_ZoomImage()`‑t a zoom keretből.

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

## **Képek kinyerése összegző zoom keretekből**

Az [ISummaryZoomFrame] szintén egy alakzat. A szekcióelemei egyedi képeket használhatnak, amelyeket az egyes összegző zoom szekciók `get_ZoomImage()` metódusa tesz elérhetővé.

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

## **Képek kinyerése táblázat alakzatokból**

Az [ITable] egy alakzat. A táblázatban lévő képek általában a táblázatcellák képkitöltéseiként vannak tárolva.

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

## **Képek kinyerése diagram alakzatokból**

Az [IChart] egy alakzat. Az alábbi példa a diagram területének képkitöltéséből nyer ki egy képet.

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

## **Képek kinyerése SmartArt alakzatokból**

Az [ISmartArt] objektum egy alakzat. A SmartArt elrendezéstől függően a képek a csomópontok felsoroláskitöltéseiben vagy a csomópont alakzatok kitöltési formátumaiban tárolódhatnak.

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

## **Képek beillesztése csoportosított alakzatokba**

A csoportosított alakzatok saját alakzategységgel rendelkeznek. A megosztott `EnumerateShapes` segédnek van egy `includeGroupedShapes` opciója. Állítsa `true`‑ra, ha a [IGroupShape] objektumok belsejében lévő alakzatokat szeretné vizsgálni. Az alábbi példa a képkeretekből, képkitöltésű alakzatokból, OLE‑objektum előnézetekből, videókeret bélyegképekből és hangkeret bélyegképekből nyeri ki a képeket. A táblázat, diagram, SmartArt és összegző zoom képek beillesztéséhez használja újra a korábbi szakaszokból származó specializált kinyerési logikát, miközben ugyanazt a rekurzív alakzat bejárást tartja.

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

## **Szélsőséges esetek és gyakorlati megjegyzések**

- **Duplikált képek:** Több alakzat is hivatkozhat ugyanarra a képre, vagy különálló képekre, amelyek azonos bájtokat tartalmaznak. Írja hash‑el a [IPPImage]::`get_BinaryData()`‑t a fájlok írása előtt, ha egy kimeneti fájlt szeretne egyedi képenként.
- **Eredeti adatok vs. konvertált kimenet:** A [IPPImage]::`get_BinaryData()` mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatokat. A [IPPImage]::`get_Image()` mentése a [IImage]::`Save`‑el hasznos, ha egységes kimeneti formátumra van szükség.
- **Nem támogatott kitöltéstípusok:** Szilárd, gradient, minta és nincs kitöltésű alakzatok nem tartalmaznak képkitöltést. Ellenőrizze a [FillType] értékét, mielőtt a `get_PictureFillFormat()`‑et olvasná.
- **Csoportosított alakzatok:** A felső szintű dia alakzatgyűjtemény nem laposítja a csoportokat. Rekurzívan vizsgálja a [IGroupShape]::`get_Shapes()`‑t, ha a csoportos tartalom fontos.
- **OLE‑objektum előnézetek:** Egy [IOleObjectFrame] előnézeti képet adhat a `get_SubstitutePictureFormat()`‑en keresztül, de ez csak a dia előnézete. Nem az OLE‑objektumban beágyazott fájl.
- **Videókeret bélyegképek:** Egy [IVideoFrame] előnézeti képet adhat a `get_PictureFormat()`‑on keresztül, de ez csak a dián megjelenő poszter. Nem a videófolyamból származik.
- **Hangkeret bélyegképek:** Egy [IAudioFrame] ikont vagy bélyegképet adhat a `get_PictureFormat()`‑on keresztül; ez nem a beágyazott hangadat.
- **Zoom képek:** A slide zoom, szekció zoom és összegző zoom alakzatok egyedi [IPPImage] objektumokat használhatnak a `get_ZoomImage()`‑on keresztül.
- **Beágyazott alakzatmodellek:** A táblázat, diagram és SmartArt objektumok implementálják az [IShape] interfészt, de a képek gyakran beágyazott táblázatcella, diagram elem vagy SmartArt csomópont formázási objektumokban vannak tárolva.
- **Vágott vagy átalakított képek:** A [IPPImage] elérése a tárolt kép erőforrást adja. Nem rendereli a vágást, átlátszóságot, színátmenetet, forgatást vagy egyéb vizuális hatásokat, amelyeket az alakzat alkalmaz.

## **GYIK**

### Kinyerhetem‑e az eredeti képet vágás, hatások vagy alakzattranszformációk nélkül?

Igen. Hozzáfér a [IPPImage] objektumhoz, és a lemezre írja a [IPPImage]::`get_BinaryData()`‑t. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem pedig a dián megjelenített kép módját.

### Exportálhatom‑e az összes kinyert képet PNG‑ként?

Igen. Használja a [IPPImage]::`get_Image()`‑t, hogy egy [IImage] objektumot kapjon, majd hívja meg a [IImage]::`Save`‑et a [ImageFormat]::`Png`‑el. Ez átalakítja a kimenetet, és előfordulhat, hogy nem őrzi meg az eredeti fájltípust vagy vektoradatot.

### Hogyan kerülhetem el, hogy ugyanazt a képet többször mentsem?

Használjon egy hash‑t a [IPPImage]::`get_BinaryData()`‑ből, és tartsa a hasheket egy halmazban. Ha egy új kép hash‑e már létezik, hagyja ki, vagy rögzítsen egy újabb hivatkozást a meglévő kimeneti fájlra.

### Miért nem ad ki kép egyes alakzatok?

Képkeretek, képkitöltésű alakzatok, OLE‑objektum keretek, média keretek, zoom keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Egyes alakzat típusok a képeket beágyazott formázási objektumokon keresztül teszik elérhetővé, ezért egy egyszerű `get_PictureFormat()` vagy `get_FillFormat()` ellenőrzés gyakran nem elegendő.

### Kinyerhetem‑e a videókerethez tartozó bélyegképet?

Igen. Használja a [IVideoFrame]::`get_PictureFormat()`‑t, és olvassa a `get_PictureFormat()->get_Picture()->get_Image()`‑t. Ez a videókerethez tárolt poszterképet nyeri ki, nem egy a videófájlból generált keretet.

### Hogyan határozhatom meg, mely alakzatok használják egy adott képet a prezentáció képgyűjteményéből?

Az Aspose.Slides nem tárol visszahivatkozásokat a [IPPImage] és az alakzatok között. A bejárás során építsen fel egy leképezést: minden kép hivatkozásnál rögzítse a dia számát, az alakzat útvonalát és a kép hash‑ét vagy a gyűjteményelemét.

### Kinyerhetek‑e képeket, amelyek OLE‑objektumokba vannak beágyazva, például csatolt dokumentumok?

Kinyerheti az OLE‑objektum dia előnézetét a [IOleObjectFrame]::`get_SubstitutePictureFormat()` segítségével. Azonban ez az előnézet nem magát a beágyazott dokumentumot jelenti. A beágyazott fájlon belüli képek kinyeréséhez először nyissa ki az OLE‑adatot, majd vizsgálja meg a megfelelő fájltípusú eszközökkel.