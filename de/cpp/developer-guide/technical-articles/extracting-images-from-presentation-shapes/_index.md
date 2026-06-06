---
title: Bilder aus Präsentationsformen in C++ extrahieren
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
description: "Extrahieren Sie Bilder aus Formen in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für C++ – schnelle, codefreundliche Lösung."
---
## **Übersicht**

Bilder in einer Präsentation können in mehreren Formtypen erscheinen: als gewöhnliche Bildrahmen, als Bildfüllungen, die auf Formen angewendet werden, als OLE‑Objekt‑Vorschaubilder, als Video‑ oder Audio‑Miniaturansichten, als Zoom‑Bilder oder als Bilder, die in Tabellen-, Diagramm‑ und SmartArt‑Formen eingebettet sind. Aspose.Slides speichert diese Bilder in der Bildsammlung der Präsentation, die über [IImageCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimagecollection/) und [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) Objekte bereitgestellt wird.

Wenn Sie nur jede in einer Präsentation eingebettete Bildressource exportieren möchten, iterieren Sie über `presentation->get_Images()`. Dieser Artikel konzentriert sich auf eine andere Aufgabe: das Durchlaufen von Formen, um zu ermitteln, wo Bilder auf Folien verwendet werden, damit die gespeicherten Dateien nützlichen Kontext wie Foliennummer, Formposition und Quellentyp (Bildrahmen, Füllbild, Medien‑Vorschau, OLE‑Vorschau oder Zoom‑Bild) behalten können.

{{% alert title="Tip" color="primary" %}}
Verwenden Sie [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()`, um die ursprünglichen codierten Bilddaten und den Dateityp zu erhalten. Verwenden Sie [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_Image()` zusammen mit [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)::`Save`, wenn Sie die Ausgabe in ein bestimmtes Format wie PNG normalisieren möchten.
{{% /alert %}}

## **Gemeinsame Hilfsmethoden**

Die unten stehenden Hilfsmethoden halten die Beispiele kurz. `SaveOriginalImage` schreibt die ursprünglich eingebetteten Bytes, wählt eine sichere Erweiterung aus dem MIME‑Typ und überspringt doppelte Bild‑Binaries anhand eines SHA‑256‑Hashes.

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

## **Bilder aus Bildrahmen extrahieren**

Verwenden Sie diesen Ansatz für Bilder, die als eigenständige Objekte eingefügt wurden. Ein [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) speichert sein Bild in `get_PictureFormat()->get_Picture()->get_Image()`, was ein [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) Objekt zurückgibt.

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

## **Bilder aus bildgefüllten Formen extrahieren**

Formen können ein Bild als Füllung verwenden. Prüfen Sie zuerst den Fülltyp der Form: Wenn er nicht [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/)::`Picture` ist, gibt es kein Bild, das aus dieser Füllung extrahiert werden kann. Das nachstehende Beispiel behandelt [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) Objekte und speichert jedes Bild als PNG über [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Vorschaubilder aus OLE‑Objekt‑Rahmen extrahieren**

Ein [IOleObjectFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ioleobjectframe/) kann ein Ersatzbild besitzen, das PowerPoint als Vorschau des Objekts auf einer Folie verwendet. Dieses Bild ist über `get_SubstitutePictureFormat()->get_Picture()->get_Image()` verfügbar. Das Extrahieren dieses Bildes liefert das Vorschaubild, nicht den eingebetteten OLE‑Paketinhalt.

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

## **Vorschaubilder aus Video‑Frames extrahieren**

Ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/) kann ebenfalls ein Vorschaubild in `get_PictureFormat()->get_Picture()->get_Image()` speichern. Dies ist das Poster oder die Miniatur, die auf der Folie angezeigt wird, nicht ein aus dem Videostrom dekodierter Frame.

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

## **Vorschaubilder aus Audio‑Frames extrahieren**

Ein [IAudioFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iaudioframe/) kann ein Miniaturbild in `get_PictureFormat()->get_Picture()->get_Image()` speichern. Dies ist das Bild, das für das Audio‑Objekt auf der Folie angezeigt wird.

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

## **Bilder aus Zoom‑Objekten extrahieren**

[IZoomFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/izoomframe/) und [ISectionZoomFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectionzoomframe/) Formen können benutzerdefinierte Bilder verwenden. Lesen Sie `get_ZoomImage()` vom Zoom‑Frame.

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

## **Bilder aus Zusammenfassungs‑Zoom‑Frames extrahieren**

Ein [ISummaryZoomFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/isummaryzoomframe/) ist ebenfalls eine Form. Seine Abschnittselemente können benutzerdefinierte Bilder verwenden, die über die `get_ZoomImage()`‑Methode jedes Zusammenfassungs‑Zoom‑Abschnitts bereitgestellt werden.

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

## **Bilder aus Tabellenformen extrahieren**

Ein [ITable](https://reference.aspose.com/slides/de/cpp/aspose.slides/itable/) ist eine Form. Bilder in einer Tabelle werden üblicherweise als Bildfüllungen in Tabellenzellen gespeichert.

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

## **Bilder aus Diagrammformen extrahieren**

Ein [IChart](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/) ist eine Form. Das nachstehende Beispiel extrahiert ein Bild aus der Bildfüllung des Diagrammbereichs.

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

## **Bilder aus SmartArt‑Formen extrahieren**

Ein [ISmartArt](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/ismartart/) Objekt ist eine Form. Abhängig vom SmartArt‑Layout können Bilder in Knoten‑Aufzählungs‑Füllungen oder in den Füllformaten von Knotenknoten gespeichert sein.

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

## **Bilder in gruppierten Formen einbeziehen**

Gruppierte Formen besitzen eigene Formsammlungen. Die gemeinsam genutzte Hilfsfunktion `EnumerateShapes` hat eine Option `includeGroupedShapes`. Setzen Sie sie auf `true`, wenn Sie Formen innerhalb von [IGroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/igroupshape/) Objekten untersuchen möchten. Das nachstehende Beispiel extrahiert Bilder aus Bildrahmen, bildgefüllten Formen, OLE‑Objekt‑Vorschauen, Video‑Miniaturansichten und Audio‑Miniaturansichten. Um Tabellen-, Diagramm‑, SmartArt‑ und Zusammenfassungs‑Zoom‑Bilder ebenfalls einzubeziehen, verwenden Sie die spezialisierte Extraktionslogik aus den vorherigen Abschnitten, während Sie dieselbe rekursive Formtraversierung beibehalten.

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

## **Grenzfälle und praktische Hinweise**

- **Doppelte Bilder:** Mehrere Formen können auf dasselbe Bild verweisen oder separate Bilder mit identischen Bytes besitzen. Bilden Sie einen Hash von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()` bevor Sie Dateien schreiben, wenn Sie für jedes eindeutige Bild nur eine Ausgabedatei benötigen.
- **Originaldaten vs. konvertierte Ausgabe:** Das Speichern von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()` bewahrt die eingebetteten JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ oder WMF‑Daten. Das Speichern von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_Image()` über [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)::`Save` ist sinnvoll, wenn Sie ein einheitliches Ausgabeformat benötigen.
- **Nicht unterstützte Fülltypen:** Solide, Gradient‑, Muster‑ und Keine‑Füll‑Formen enthalten keine Bildfüllung. Prüfen Sie [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) bevor Sie `get_PictureFillFormat()` lesen.
- **Gruppierte Formen:** Die oberste Formsammlung einer Folie glättet Gruppen nicht. Durchsuchen Sie rekursiv [IGroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/igroupshape/)::`get_Shapes()`, wenn gruppierter Inhalt relevant ist.
- **OLE‑Objekt‑Vorschauen:** Ein [IOleObjectFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ioleobjectframe/) kann über `get_SubstitutePictureFormat()` ein Vorschaubild bereitstellen, aber dieses Bild ist nur die Folien‑Vorschau. Es ist nicht die eingebettete Datei im OLE‑Objekt.
- **Video‑Frame‑Miniaturbilder:** Ein [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/) kann über `get_PictureFormat()` ein Vorschaubild bereitstellen, aber dieses Bild ist nur das Poster, das auf der Folie angezeigt wird. Es wird nicht aus dem Videostream extrahiert.
- **Audio‑Frame‑Miniaturbilder:** Ein [IAudioFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/iaudioframe/) kann über `get_PictureFormat()` ein Symbol oder Miniaturbild bereitstellen; es ist nicht das eingebettete Audiodaten‑File.
- **Zoom‑Bilder:** Slide‑Zoom, Section‑Zoom und Summary‑Zoom Formen können benutzerdefinierte [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) Objekte über `get_ZoomImage()` verwenden.
- **Verschachtelte Formmodelle:** Tabellen-, Diagramm‑ und SmartArt‑Objekte implementieren [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/), aber ihre Bilder werden häufig in verschachtelten Tabellenzellen-, Diagrammelement‑ oder SmartArt‑Knoten‑Formatierungsobjekten gespeichert.
- **Zugeschnittene oder transformierte Bilder:** Der Zugriff auf [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) liefert die gespeicherte Bildressource. Es wird kein Beschneiden, Transparenz, Nachfärben, Drehen oder andere visuelle Effekte berücksichtigt, die von der Form angewendet wurden.

## **FAQ**

**Kann ich das Originalbild ohne Zuschneiden, Effekte oder Form‑Transformationen extrahieren?**

Ja. Greifen Sie auf das [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) Objekt zu und schreiben Sie [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()` auf die Festplatte. Dadurch bleibt das ursprünglich codierte Bild erhalten, nicht die Art, wie es auf der Folie gerendert wird.

**Kann ich jedes extrahierte Bild als PNG exportieren?**

Ja. Verwenden Sie [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_Image()`, um ein [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/) Objekt zu erhalten, und rufen Sie dann [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)::`Save` mit [ImageFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/imageformat/)::`Png` auf. Dies konvertiert die Ausgabe und bewahrt ggf. nicht den ursprünglichen Dateityp oder Vektordaten.

**Wie verhindere ich, dass dasselbe Bild mehrmals gespeichert wird?**

Verwenden Sie einen Hash von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)::`get_BinaryData()` und speichern Sie die Hashes in einer Menge. Wenn ein neues Bild einen bereits vorhandenen Hash hat, überspringen Sie es oder verweisen Sie erneut auf die vorhandene Ausgabedatei.

**Warum erzeugen einige Formen kein Bild?**

Bildrahmen, bildgefüllte Formen, OLE‑Objekt‑Rahmen, Medien‑Rahmen, Zoom‑Rahmen, Tabellen, Diagramme und SmartArt‑Objekte können Bilder referenzieren. Einige Formtypen stellen Bilder über verschachtelte Formatierungsobjekte bereit, sodass ein einfacher Aufruf von `get_PictureFormat()` oder `get_FillFormat()` nicht immer ausreicht.

**Kann ich das Miniaturbild eines Video‑Frames extrahieren?**

Ja. Verwenden Sie [IVideoFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` und lesen Sie `get_PictureFormat()->get_Picture()->get_Image()`. Damit wird das Poster‑Bild extrahiert, das zusammen mit dem Video‑Frame gespeichert ist, nicht ein Frame, der aus der Videodatei erzeugt wurde.

**Wie kann ich bestimmen, welche Formen ein bestimmtes Bild aus der Präsentations‑Bildsammlung verwenden?**

Aspose.Slides speichert keine Rückverweise von [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) zu Formen. Bauen Sie während der Traversierung eine Zuordnung auf: Wann immer Sie eine Bildreferenz finden, notieren Sie die Folien‑Nummer, den Form‑Pfad und den Bild‑Hash oder das Sammlungs‑Element.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Sie können die Folien‑Vorschau des OLE‑Objekts über [IOleObjectFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` extrahieren. Diese Vorschau ist jedoch nicht das eingebettete Dokument selbst. Um Bilder aus der eingebetteten Datei zu extrahieren, müssen Sie die OLE‑Daten auslesen und mit geeigneten Werkzeugen für diesen Dateityp untersuchen.