---
title: Extraire des images des formes de présentation en C++
linktitle: Image depuis forme
type: docs
weight: 90
url: /fr/cpp/extracting-images-from-presentation-shapes/
keywords:
- extraction d'image
- récupérer image
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour C++ – solution rapide et conviviale pour les développeurs."
---
## **Aperçu**

Les images d'une présentation peuvent apparaître sous plusieurs types de forme : en tant que cadres d'image ordinaires, en tant que remplissages d'image appliqués aux formes, en tant qu'images d'aperçu d'objet OLE, en tant que miniatures de trames vidéo ou audio, en tant qu'images de zoom, ou en tant qu'images imbriquées dans des formes de tableau, de graphique et de SmartArt. Aspose.Slides stocke ces images dans la collection d'images de la présentation, accessible via les objets [IImageCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimagecollection/) et [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) .

Si vous devez uniquement exporter chaque ressource image intégrée dans une présentation, parcourez `presentation->get_Images()`. Cet article se concentre sur une tâche différente : parcourir les formes pour trouver où les images sont utilisées sur les diapositives, afin que les fichiers enregistrés conservent un contexte utile tel que le numéro de diapositive, la position de la forme et le type de source (cadre d'image, image de remplissage, aperçu média, aperçu OLE ou image de zoom).

{{% alert title="Tip" color="info" %}}
Utilisez [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/)::`get_BinaryData()` pour conserver les données d'image codées d'origine et le type de fichier. Utilisez [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/)::`get_Image()` avec [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/)::`Save` lorsque vous voulez normaliser la sortie vers un format spécifique tel que PNG.
{{% /alert %}}

## **Méthodes d'assistance partagées**

Les méthodes d'assistance ci‑dessous raccourcissent les exemples. `SaveOriginalImage` écrit les octets intégrés d'origine, choisit une extension sûre à partir du type MIME et ignore les binaires d'image en double grâce au hachage SHA‑256.

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

## **Extraire les images des cadres d'image**

Utilisez cette approche pour les images insérées comme objets autonomes. Un [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/) stocke son image dans `get_PictureFormat()->get_Picture()->get_Image()`, qui renvoie un objet [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) .

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

## **Extraire les images des formes remplissées d'image**

Les formes peuvent utiliser une image comme remplissage. Vérifiez d'abord le type de remplissage de la forme : s'il n'est pas [FillType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/filltype/)::`Picture`, il n'y a aucune image à extraire de ce remplissage. L'exemple ci‑dessous gère les objets [IAutoShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iautoshape/) et enregistre chaque image au format PNG via [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/)::`get_Image()` .

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

## **Extraire les images d'aperçu des cadres d'objet OLE**

Un [IOleObjectFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ioleobjectframe/) peut posséder une image de substitution que PowerPoint utilise comme aperçu de l'objet sur une diapositive. Cette image est accessible via `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Extraire cette image vous donne l'image d'aperçu, pas le contenu du paquet OLE intégré.

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

## **Extraire les images d'aperçu des cadres vidéo**

Un [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) peut également stocker une image d'aperçu dans `get_PictureFormat()->get_Picture()->get_Image()`. Il s'agit du poster ou de la miniature affichée sur la diapositive, et non d'une trame décodée du flux vidéo.

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

## **Extraire les images d'aperçu des cadres audio**

Un [IAudioFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iaudioframe/) peut stocker une miniature dans `get_PictureFormat()->get_Picture()->get_Image()`. Il s'agit de l'image affichée pour l'objet audio sur la diapositive.

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

## **Extraire les images des objets de zoom**

Les formes [IZoomFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/izoomframe/) et [ISectionZoomFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isectionzoomframe/) peuvent utiliser des images personnalisées. Lisez `get_ZoomImage()` depuis le cadre de zoom.

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

## **Extraire les images des cadres de zoom de résumé**

Un [ISummaryZoomFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/isummaryzoomframe/) est également une forme. Les éléments de ses sections peuvent utiliser des images personnalisées, accessibles via la méthode `get_ZoomImage()` de chaque section de zoom de résumé.

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

## **Extraire les images des formes de tableau**

Une [ITable](https://reference.aspose.com/slides/fr/cpp/aspose.slides/itable/) est une forme. Les images d’un tableau sont généralement stockées comme remplissages d'image dans les cellules du tableau.

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

## **Extraire les images des formes de graphique**

Un [IChart](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/) est une forme. L'exemple ci‑dessus extrait une image du remplissage d'image de la zone du graphique.

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

## **Extraire les images des formes SmartArt**

Un objet [ISmartArt](https://reference.aspose.com/slides/fr/cpp/aspose.slides.smartart/ismartart/) est une forme. Selon la disposition du SmartArt, les images peuvent être stockées dans les remplissages de puces de nœud ou dans les formats de remplissage des formes de nœud.

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

## **Inclure les images à l'intérieur des formes groupées**

Les formes groupées contiennent leurs propres collections de formes. L'assistant partagé `EnumerateShapes` possède une option `includeGroupedShapes`. Définissez-la à `true` lorsque vous souhaitez inspecter les formes à l'intérieur des objets [IGroupShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/igroupshape/) . L'exemple ci‑dessus extrait les images des cadres d'image, des formes remplissées d'image, des aperçus d'objets OLE, des miniatures de cadres vidéo et des miniatures de cadres audio. Pour inclure également les images des tableaux, graphiques, SmartArt et zoom de résumé, réutilisez la logique d'extraction spécialisée des sections précédentes tout en conservant le même parcours récursif des formes.

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

## **Cas particuliers et notes pratiques**

- **Images en double :** Plusieurs formes peuvent référencer la même image ou des images distinctes ayant des octets identiques. Hachez [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/)::`get_BinaryData()` avant d'écrire les fichiers si vous souhaitez un fichier de sortie par image unique.
- **Données originales vs. sortie convertie :** En enregistrant [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/)::`get_BinaryData()` vous conservez les données JPEG, PNG, GIF, SVG, EMF ou WMF intégrées. En enregistrant [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/)::`get_Image()` via [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/)::`Save`, vous obtenez un format de sortie cohérent.
- **Types de remplissage non pris en charge :** Les formes à remplissage uni, dégradé, motif ou sans remplissage ne contiennent pas de remplissage d'image. Vérifiez [FillType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/filltype/) avant de lire `get_PictureFillFormat()` .
- **Formes groupées :** La collection de formes de niveau supérieur de la diapositive n'aplatit pas les groupes. Inspectez récursivement [IGroupShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/igroupshape/)::`get_Shapes()` lorsque le contenu groupé importe.
- **Aperçus d'objets OLE :** Un [IOleObjectFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ioleobjectframe/) peut exposer une image d'aperçu via `get_SubstitutePictureFormat()`, mais cette image n'est que l'aperçu de la diapositive. Ce n’est pas le fichier intégré à l'intérieur de l'objet OLE.
- **Miniatures de cadres vidéo :** Un [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/) peut exposer une image d'aperçu via `get_PictureFormat()`, mais cette image n'est que le poster affiché sur la diapositive. Elle n'est pas extraite du flux vidéo.
- **Miniatures de cadres audio :** Un [IAudioFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iaudioframe/) peut exposer une icône ou une miniature via `get_PictureFormat()` ; ce n’est pas les données audio intégrées.
- **Images de zoom :** Les formes de zoom de diapositive, de section et de résumé peuvent utiliser des objets [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) personnalisés via `get_ZoomImage()` .
- **Modèles de formes imbriquées :** Les objets tableau, graphique et SmartArt implémentent [IShape](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/), mais leurs images sont souvent stockées dans les objets de formatage de cellules de tableau, d'éléments de graphique ou de nœuds SmartArt.
- **Images recadrées ou transformées :** Accéder à [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) vous donne la ressource image stockée. Cela ne rend pas le recadrage, la transparence, la recoloration, la rotation ou d’autres effets visuels appliqués par la forme.

## **FAQ**

### Puis-je extraire l'image originale sans recadrage, effets ou transformations de forme ?

Oui. Accédez à l'objet [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) et écrivez [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/)::`get_BinaryData()` sur le disque. Cela préserve l'image codée originale stockée dans la présentation, pas la façon dont l'image est rendue sur la diapositive.

### Puis-je exporter chaque image extraite au format PNG ?

Oui. Utilisez [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/)::`get_Image()` pour obtenir un objet [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/) , puis appelez [IImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iimage/)::`Save` avec [ImageFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/imageformat/)::`Png`. Cela convertit la sortie et peut ne pas préserver le type de fichier original ou les données vectorielles.

### Comment éviter d'enregistrer la même image plusieurs fois ?

Utilisez un hachage de [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/)::`get_BinaryData()` et conservez les hachages dans un ensemble. Si une nouvelle image possède un hachage déjà présent, ignorez‑la ou enregistrez une autre référence vers le fichier de sortie existant.

### Pourquoi certaines formes ne génèrent-elles pas d'image ?

Les cadres d'image, les formes remplissées d'image, les cadres d'objet OLE, les cadres multimédia, les cadres de zoom, les tableaux, les graphiques et les objets SmartArt peuvent référencer des images. Certains types de forme exposent les images via des objets de formatage imbriqués, de sorte qu'une simple vérification `get_PictureFormat()` ou `get_FillFormat()` n'est pas toujours suffisante.

### Puis-je extraire la miniature affichée pour un cadre vidéo ?

Oui. Utilisez [IVideoFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` et lisez `get_PictureFormat()->get_Picture()->get_Image()` . Cela extrait l'image du poster stockée avec le cadre vidéo, pas une trame générée à partir du fichier vidéo.

### Comment déterminer quelles formes utilisent une image spécifique de la collection d'images de la présentation ?

Aspose.Slides ne stocke pas de liens inverses de [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) vers les formes. Construisez une table de correspondance pendant le parcours : chaque fois que vous trouvez une référence d'image, enregistrez le numéro de diapositive, le chemin de la forme et le hachage ou l'élément de la collection.

### Puis-je extraire les images intégrées dans des objets OLE, comme des documents joints ?

Vous pouvez extraire l'aperçu de la diapositive de l'objet OLE via [IOleObjectFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` . Cependant, cet aperçu n'est pas le document intégré lui‑même. Pour extraire les images du fichier intégré, extrayez les données OLE et inspectez‑les avec les outils appropriés pour ce type de fichier.