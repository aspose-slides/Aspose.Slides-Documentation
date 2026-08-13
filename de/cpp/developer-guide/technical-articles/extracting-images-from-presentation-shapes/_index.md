---
title: Extrahieren von Bildern aus Formen in Präsentationen in C++
linktitle: Bild aus Form
type: docs
weight: 90
url: /de/cpp/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Extrahieren Sie Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ – schnelle, codefreundliche Lösung."
---
## **Übersicht**

Bilder in einer Präsentation können in mehreren Formtypenn auftreten: als gewöhnliche Bildrahmen, als Bildfüllungen, die auf Formen angewendet werden, als Vorschaubilder von OLE-Objekten, als Miniaturansichten von Video- oder Audio-Frames, als Zoom-Bilder oder als in Tabellen-, Diagramm- und SmartArt-Formen verschachtelte Bilder. Aspose.Slides speichert diese Bilder in der Bildsammlung der Präsentation, die über die Objekte [IImageCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimagecollection/) und [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) bereitgestellt werden.

Wenn Sie nur alle in einer Präsentation eingebetteten Bildressourcen exportieren möchten, iterieren Sie über `presentation->get_Images()`. Dieser Artikel konzentriert sich auf eine andere Aufgabe: das Durchlaufen von Formen, um zu ermitteln, wo Bilder auf Folien verwendet werden, damit die gespeicherten Dateien nützliche Kontextinformationen wie Foliennummer, Formposition und Quelltyp (Bildrahmen, Füllbild, Medienvorschau, OLE-Vorschau oder Zoom-Bild) enthalten.

{{% alert title="Tip" color="info" %}}
Verwenden Sie [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()` , um die ursprünglich codierten Bilddaten und den Dateityp beizubehalten. Verwenden Sie [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_Image()` zusammen mit [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)::`Save`, wenn Sie die Ausgabe in ein bestimmtes Format wie PNG normalisieren möchten.
{{% /alert %}}

## **Gemeinsame Hilfsmethoden**

Die Hilfsmethoden unten halten die Beispiele kurz. `SaveOriginalImage` schreibt die ursprünglich eingebetteten Bytes, wählt anhand des MIME-Typs eine sichere Erweiterung und überspringt doppelte Bild-Binärdateien anhand ihres SHA-256-Hashes.

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

## **Bilder aus Bildrahmen extrahieren**

Verwenden Sie diesen Ansatz für Bilder, die als eigenständige Objekte eingefügt wurden. Ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) speichert sein Bild in `get_PictureFormat()->get_Picture()->get_Image()`, das ein [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)‑Objekt zurückgibt.

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

## **Bilder aus bildgefüllten Formen extrahieren**

Formen können ein Bild als Füllung verwenden. Prüfen Sie zunächst den Fülltyp der Form: Wenn er nicht [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/)::`Picture` ist, gibt es kein Bild, das aus dieser Füllung extrahiert werden kann. Das nachstehende Beispiel behandelt [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/)‑Objekte und speichert jedes Bild als PNG über [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Vorschaubilder aus OLE-Objekt-Frames extrahieren**

Ein [IOleObjectFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ioleobjectframe/) kann ein Ersatzbild besitzen, das PowerPoint als Vorschau des Objekts auf einer Folie verwendet. Dieses Bild ist über `get_SubstitutePictureFormat()->get_Picture()->get_Image()` verfügbar. Das Extrahieren dieses Bildes liefert das Vorschaubild, nicht den eingebetteten OLE-Paketinhalt.

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

## **Vorschaubilder aus Video-Frames extrahieren**

Ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/) kann ebenfalls ein Vorschaubild in `get_PictureFormat()->get_Picture()->get_Image()` speichern. Dies ist das Poster‑ oder Miniaturbild, das auf der Folie angezeigt wird, nicht ein aus dem Videostrom dekodierter Frame.

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

## **Vorschaubilder aus Audio-Frames extrahieren**

Ein [IAudioFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iaudioframe/) kann ein Miniaturbild in `get_PictureFormat()->get_Picture()->get_Image()` speichern. Dies ist das Bild, das für das Audio-Objekt auf der Folie angezeigt wird.

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

## **Bilder aus Zoom-Objekten extrahieren**

[IZoomFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/izoomframe/) und [ISectionZoomFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectionzoomframe/) Formen können benutzerdefinierte Bilder verwenden. Lesen Sie `get_ZoomImage()` vom Zoom-Frame.

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

## **Bilder aus Zusammenfassungs-Zoom-Frames extrahieren**

Ein [ISummaryZoomFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/isummaryzoomframe/) ist ebenfalls eine Form. Seine Abschnittselemente können benutzerdefinierte Bilder verwenden, die über die `get_ZoomImage()`‑Methode jedes Zusammenfassungs-Zoom-Abschnitts bereitgestellt werden.

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

## **Bilder aus Tabellen-Formen extrahieren**

Ein [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) ist eine Form. Bilder in einer Tabelle werden normalerweise als Bildfüllungen in Tabellenzellen gespeichert.

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

## **Bilder aus Diagramm-Formen extrahieren**

Ein [IChart](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/) ist eine Form. Das nachstehende Beispiel extrahiert ein Bild aus der Bildfüllung des Diagrammbereichs.

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

## **Bilder aus SmartArt-Formen extrahieren**

Ein [ISmartArt](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/ismartart/)‑Objekt ist eine Form. Je nach SmartArt-Layout können Bilder in Aufzählungs‑Füllungen der Knoten oder in den Füllformaten der Knotformen gespeichert sein.

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

## **Bilder in gruppierten Formen einbeziehen**

Gruppierte Formen enthalten eigene Formsammlungen. Der gemeinsam genutzte Hilfs-`EnumerateShapes`‑Helper verfügt über die Option `includeGroupedShapes`. Setzen Sie sie auf `true`, wenn Sie Formen innerhalb von [IGroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/igroupshape/)‑Objekten untersuchen möchten. Das nachstehende Beispiel extrahiert Bilder aus Bildrahmen, bildgefüllten Formen, OLE-Objekt-Vorschauen, Video-Frame-Miniaturbildern und Audio-Frame-Miniaturbildern. Um außerdem Tabellen-, Diagramm-, SmartArt- und Zusammenfassungs-Zoom-Bilder einzubeziehen, verwenden Sie die spezialisierte Extraktionslogik der vorherigen Abschnitte und behalten dabei die gleiche rekursive Form‑Durchsuchung bei.

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

## **Randfälle und praktische Hinweise**

- **Doppelte Bilder:** Mehrere Formen können dasselbe Bild oder verschiedene Bilder mit identischen Bytes referenzieren. Bilden Sie einen Hash von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()` bevor Sie Dateien schreiben, wenn Sie jeweils eine Ausgabedatei pro eindeutigem Bild wünschen.
- **Originaldaten vs. konvertierte Ausgabe:** Das Speichern von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()` bewahrt die eingebetteten JPEG-, PNG-, GIF-, SVG-, EMF- oder WMF-Daten. Das Speichern von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_Image()` über [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)::`Save` ist nützlich, wenn Sie ein einheitliches Ausgabeformat wünschen.
- **Nicht unterstützte Fülltypen:** Solide, Verlauf-, Muster- und keine-Füllungsformen enthalten keine Bildfüllung. Prüfen Sie [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/)..., bevor Sie `get_PictureFillFormat()` lesen.
- **Gruppierte Formen:** Die Formsammlung der obersten Folienebene flacht Gruppen nicht ab. Durchsuchen Sie rekursiv [IGroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/igroupshape/)::`get_Shapes()`, wenn gruppierter Inhalt von Bedeutung ist.
- **OLE-Objekt-Vorschauen:** Ein [IOleObjectFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ioleobjectframe/) kann ein Vorschaubild über `get_SubstitutePictureFormat()` bereitstellen, jedoch ist dieses Bild nur die Folienvorschau. Es ist nicht die im OLE-Objekt eingebettete Datei.
- **Video-Frame-Miniaturbilder:** Ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/) kann ein Vorschaubild über `get_PictureFormat()` bereitstellen, aber dieses Bild ist nur das Poster, das auf der Folie angezeigt wird. Es wird nicht aus dem Videostrom extrahiert.
- **Audio-Frame-Miniaturbilder:** Ein [IAudioFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iaudioframe/) kann ein Symbol oder Miniaturbild über `get_PictureFormat()` bereitstellen; es handelt sich nicht um die eingebetteten Audiodaten.
- **Zoom-Bilder:** Folien-Zoom, Abschnitts-Zoom und Zusammenfassungs-Zoom-Formen können benutzerdefinierte [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)‑Objekte über `get_ZoomImage()` verwenden.
- **Verschachtelte Formmodelle:** Tabellen-, Diagramm- und SmartArt-Objekte implementieren [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/), aber ihre Bilder werden häufig in verschachtelten Tabellenzellen, Diagrammelementen oder SmartArt‑Knoten‑Formatierungsobjekten gespeichert.
- **Zugeschnittene oder transformierte Bilder:** Der Zugriff auf [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) liefert die gespeicherte Bildressource. Es wird kein Zuschneiden, Transparenz, Umfärben, Drehen oder andere visuelle Effekte, die von der Form angewendet werden, gerendert.

## **FAQ**

### Kann ich das Originalbild ohne Zuschneiden, Effekte oder Form‑Transformationen extrahieren?

Ja. Greifen Sie auf das [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)‑Objekt zu und schreiben Sie [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()` auf die Festplatte. Dadurch bleibt das ursprünglich codierte Bild, das in der Präsentation gespeichert ist, erhalten und nicht die Art, wie das Bild auf der Folie gerendert wird.

### Kann ich jedes extrahierte Bild als PNG exportieren?

Ja. Verwenden Sie [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_Image()`, um ein [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)‑Objekt zu erhalten, und rufen Sie dann [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)::`Save` mit [ImageFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/imageformat/)::`Png` auf. Dadurch wird die Ausgabe konvertiert und der ursprüngliche Dateityp oder Vektordaten können verloren gehen.

### Wie vermeide ich, dass dasselbe Bild mehrmals gespeichert wird?

Verwenden Sie einen Hash von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()` und speichern Sie die Hashes in einer Menge. Hat ein neues Bild einen bereits vorhandenen Hash, überspringen Sie es oder vermerken Sie eine weitere Referenz zur bestehenden Ausgabedatei.

### Warum erzeugen einige Formen kein Bild?

Bildrahmen, bildgefüllte Formen, OLE-Objekt-Frames, Medien-Frames, Zoom-Frames, Tabellen, Diagramme und SmartArt-Objekte können Bilder referenzieren. Einige Formtypen geben Bilder über verschachtelte Formatierungsobjekte frei, sodass ein einfacher Check von `get_PictureFormat()` oder `get_FillFormat()` der Form nicht immer ausreicht.

### Kann ich das für einen Video‑Frame angezeigte Miniaturbild extrahieren?

Ja. Verwenden Sie [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` und lesen Sie `get_PictureFormat()->get_Picture()->get_Image()`. Damit wird das Poster‑Bild extrahiert, das mit dem Video‑Frame gespeichert ist, nicht ein aus der Videodatei erzeugter Frame.

### Wie kann ich feststellen, welche Formen ein bestimmtes Bild aus der Präsentations‑Bildsammlung verwenden?

Aspose.Slides speichert keine Rückverweise von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) zu Formen. Erstellen Sie während der Durchlaufung eine Zuordnung: Jedes Mal, wenn Sie eine Bildreferenz finden, notieren Sie die Foliennummer, den Formpfad und den Bild‑Hash bzw. das Sammlungs‑Element.

### Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?

Sie können die Folien‑Vorschau des OLE‑Objekts über [IOleObjectFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` extrahieren. Diese Vorschau ist jedoch nicht das eingebettete Dokument selbst. Um Bilder aus der eingebetteten Datei zu extrahieren, lösen Sie die OLE‑Daten und untersuchen sie mit Werkzeugen für den jeweiligen Dateityp.