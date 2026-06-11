---
title: "Wyodrębnianie obrazów z kształtów prezentacji w C++"
linktitle: "Obraz z kształtu"
type: docs
weight: 90
url: /pl/cpp/extracting-images-from-presentation-shapes/
keywords:
- "wyodrębnić obraz"
- "pobrać obraz"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "C++"
- "Aspose.Slides"
description: "Wyodrębnij obrazy z kształtów w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++ – szybkie, przyjazne programiście rozwiązanie."
---
## **Przegląd**

Obrazy w prezentacji mogą występować w kilku typach kształtów: jako zwykłe ramki obrazów, jako wypełnienia obrazem zastosowane do kształtów, jako obrazy podglądu obiektów OLE, jako miniatury klatek wideo lub audio, jako obrazy powiększenia lub jako obrazy zagnieżdżone w kształtach tabel, wykresów i SmartArt. Aspose.Slides przechowuje te obrazy w kolekcji obrazów prezentacji, udostępnianej poprzez obiekty [IImageCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimagecollection/) i [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) .

Jeśli potrzebujesz jedynie wyeksportować każdy zasób obrazu osadzony w prezentacji, iteruj przez `presentation->get_Images()`. Ten artykuł koncentruje się na innym zadaniu: przeszukiwaniu kształtów, aby znaleźć miejsca użycia obrazów na slajdach, tak aby zapisane pliki mogły zachować przydatny kontekst, taki jak numer slajdu, pozycja kształtu i typ źródła (rama obrazu, wypełnienie obrazem, podgląd multimediów, podgląd OLE lub obraz zoom).

{{% alert title="Tip" color="primary" %}}
Użyj [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/)::`get_BinaryData()`, aby zachować oryginalne zakodowane dane obrazu i typ pliku. Użyj [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/)::`get_Image()` wraz z [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/)::`Save`, gdy chcesz znormalizować wyjście do konkretnego formatu, takiego jak PNG.
{{% /alert %}}

## **Wspólne Metody Pomocnicze**

Poniższe metody pomocnicze skracają przykłady. `SaveOriginalImage` zapisuje oryginalne osadzone bajty, wybiera bezpieczne rozszerzenie na podstawie typu MIME i pomija zduplikowane binaria obrazów przy użyciu hasha SHA‑256.

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

## **Wyodrębnianie Obrazów z Ramki Obrazów**

Użyj tego podejścia dla obrazów wstawionych jako odrębne obiekty. [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) przechowuje swój obraz w `get_PictureFormat()->get_Picture()->get_Image()`, co zwraca obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) .

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

## **Wyodrębnianie Obrazów z Kształtów Wypełnionych Obrazem**

Kształty mogą używać obrazu jako wypełnienia. Najpierw sprawdź typ wypełnienia kształtu: jeśli nie jest to [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/)::`Picture`, nie ma obrazu do wyodrębnienia z tego wypełnienia. Poniższy przykład obsługuje obiekty [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) i zapisuje każdy obraz jako PNG przy użyciu [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Wyodrębnianie Obrazów Podglądu z Ram OLE**

[IOleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleobjectframe/) może mieć zamienny obraz, którego PowerPoint używa jako podgląd obiektu na slajdzie. Ten obraz jest dostępny poprzez `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Wyodrębnienie tego obrazu daje podgląd, a nie osadzoną zawartość pakietu OLE.

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

## **Wyodrębnianie Obrazów Podglądu z Klatek Wideo**

[IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) może również przechowywać obraz podglądu w `get_PictureFormat()->get_Picture()->get_Image()`. Jest to plakat lub miniatura wyświetlana na slajdzie, a nie klatka zdekodowana z strumienia wideo.

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

## **Wyodrębnianie Obrazów Podglądu z Klatek Audio**

[IAudioFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iaudioframe/) może przechowywać miniaturę w `get_PictureFormat()->get_Picture()->get_Image()`. Jest to obraz wyświetlany dla obiektu audio na slajdzie.

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

## **Wyodrębnianie Obrazów z Obiektów Zoom**

[IZoomFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/izoomframe/) i [ISectionZoomFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectionzoomframe/) mogą używać własnych obrazów. Odczytaj `get_ZoomImage()` z ramki zoom.

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

## **Wyodrębnianie Obrazów z Ramików Zoom Podsumowania**

[ISummaryZoomFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isummaryzoomframe/) jest również kształtem. Jego elementy sekcji mogą używać własnych obrazów, udostępnianych przez metodę `get_ZoomImage()` każdego elementu podsumowania.

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

## **Wyodrębnianie Obrazów z Kształtów Tabeli**

[ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) jest kształtem. Obrazy w tabeli są zazwyczaj przechowywane jako wypełnienia obrazem w komórkach tabeli.

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

## **Wyodrębnianie Obrazów z Kształtów Wykresu**

[IChart](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/) jest kształtem. Poniższy przykład wyodrębnia obraz z wypełnienia obszaru wykresu.

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

## **Wyodrębnianie Obrazów z Kształtów SmartArt**

[ISmartArt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/ismartart/) jest kształtem. W zależności od układu SmartArt, obrazy mogą być przechowywane w wypełnieniach wypunktowań węzłów lub w formatach wypełnień kształtów węzłów.

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

## **Dołączanie Obrazów wewnątrz Zgrupowanych Kształtów**

Zgrupowane kształty zawierają własne kolekcje kształtów. Wspólna metoda pomocnicza `EnumerateShapes` posiada opcję `includeGroupedShapes`. Ustaw ją na `true`, gdy chcesz analizować kształty wewnątrz obiektów [IGroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igroupshape/) . Poniższy przykład wyodrębnia obrazy z ramek obrazów, kształtów wypełnionych obrazem, podglądów obiektów OLE, miniatur klatek wideo i miniatur klatek audio. Aby dołączyć także obrazy tabel, wykresów, SmartArt i podsumowania zoom, ponownie użyj specjalistycznej logiki wyodrębniania z poprzednich sekcji, zachowując tę samą rekurencyjną traversę kształtów.

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

## **Przypadki Krawędziowe i Praktyczne Uwagi**

- **Duplikaty obrazów:** Wiele kształtów może odwoływać się do tego samego obrazu lub do osobnych obrazów o identycznych bajtach. Oblicz hash [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/)::`get_BinaryData()` przed zapisem plików, jeśli chcesz mieć jeden plik wyjściowy na unikalny obraz.
- **Oryginalne dane vs. skonwertowany wynik:** Zapisanie [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/)::`get_BinaryData()` zachowuje osadzony JPEG, PNG, GIF, SVG, EMF lub WMF. Zapisanie [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/)::`get_Image()` poprzez [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/)::`Save` jest przydatne, gdy potrzebny jest spójny format wyjściowy.
- **Nieobsługiwane typy wypełnień:** Kształty o wypełnieniu jednolitym, gradientowym, wzorowym lub bez wypełnienia nie zawierają obrazu wypełnienia. Sprawdź [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) przed odczytem `get_PictureFillFormat()`.
- **Zgrupowane kształty:** Górna kolekcja kształtów slajdu nie spłaszcza grup. Rekurencyjnie analizuj [IGroupShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igroupshape/)::`get_Shapes()` kiedy zawartość grup ma znaczenie.
- **Podglądy obiektów OLE:** [IOleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleobjectframe/) może udostępniać obraz podglądu poprzez `get_SubstitutePictureFormat()`, ale jest to jedynie podgląd slajdu, nie osadzony plik w obiekcie OLE.
- **Miniatury klatek wideo:** [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) może udostępniać obraz podglądu poprzez `get_PictureFormat()`, ale jest to jedynie plakat wyświetlany na slajdzie, nie wyodrębniony z strumienia wideo.
- **Miniatury klatek audio:** [IAudioFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iaudioframe/) może udostępniać ikonę lub miniaturę poprzez `get_PictureFormat()`; nie jest to osadzony dźwięk.
- **Obrazy zoom:** Kształty zoom slajdu, sekcji i podsumowania mogą używać własnych obiektów [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) poprzez `get_ZoomImage()`.
- **Zagnieżdżone modele kształtów:** Obiekty tabel, wykresów i SmartArt implementują [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/), ale ich obrazy są często przechowywane w zagnieżdżonych obiektach formatowania komórek tabel, elementów wykresu lub węzłów SmartArt.
- **Obrazy przycięte lub przekształcone:** Dostęp do [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) daje zasób przechowywanego obrazu. Nie renderuje przycinania, przezroczystości, recoloru, rotacji ani innych efektów wizualnych zastosowanych przez kształt.

## **FAQ**

**Czy mogę wyodrębnić oryginalny obraz bez przycinania, efektów ani przekształceń kształtu?**

Tak. Uzyskaj obiekt [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) i zapisz `get_BinaryData()` na dysku. Zachowuje to oryginalnie zakodowany obraz przechowywany w prezentacji, a nie sposób, w jaki jest renderowany na slajdzie.

**Czy mogę wyeksportować każdy wyodrębniony obraz jako PNG?**

Tak. Użyj [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/)::`get_Image()`, aby uzyskać obiekt [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/), a następnie wywołaj [IImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/)::`Save` z [ImageFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imageformat/)::`Png`. To konwertuje wyjście i może nie zachować oryginalnego typu pliku ani danych wektorowych.

**Jak uniknąć zapisywania tego samego obrazu wielokrotnie?**

Użyj hasha [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/)::`get_BinaryData()` i przechowuj hashe w zbiorze. Jeśli nowy obraz posiada hash, który już istnieje, pomiń go lub zarejestruj kolejną referencję do istniejącego pliku wyjściowego.

**Dlaczego niektóre kształty nie generują obrazu?**

Ramki obrazów, kształty wypełnione obrazem, ramki obiektów OLE, ramki multimedialne, ramki zoom, tabele, wykresy i obiekty SmartArt mogą odwoływać się do obrazów. Niektóre typy kształtów udostępniają obrazy przez zagnieżdżone obiekty formatowania, więc proste sprawdzenie `get_PictureFormat()` lub `get_FillFormat()` nie zawsze wystarczy.

**Czy mogę wyodrębnić miniaturę wyświetlaną dla klatki wideo?**

Tak. Użyj [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` i odczytaj `get_PictureFormat()->get_Picture()->get_Image()`. To wyodrębnia obraz plakatu przechowywany razem z klatką wideo, a nie klatkę wygenerowaną z pliku wideo.

**Jak określić, które kształty używają konkretnego obrazu z kolekcji obrazów prezentacji?**

Aspose.Slides nie przechowuje odwróconych odnośników od [IPPImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ippimage/) do kształtów. Zbuduj mapowanie podczas traversu: za każdym razem, gdy znajdziesz odwołanie do obrazu, zarejestruj numer slajdu, ścieżkę kształtu oraz hash obrazu lub element kolekcji.

**Czy mogę wyodrębnić obrazy osadzone wewnątrz obiektów OLE, takie jak załączone dokumenty?**

Możesz wyodrębnić podgląd slajdu obiektu OLE z [IOleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`. Jednak ten podgląd nie jest samym osadzonym dokumentem. Aby wyodrębnić obrazy z wewnątrz pliku OLE, wyodrębnij dane OLE i przeanalizuj je przy pomocy narzędzi odpowiednich dla tego typu pliku.