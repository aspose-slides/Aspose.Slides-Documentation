---
title: Estrarre immagini dalle forme della presentazione in C++
linktitle: Immagine da forma
type: docs
weight: 90
url: /it/cpp/extracting-images-from-presentation-shapes/
keywords:
- estrarre immagine
- recuperare immagine
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Estrai immagini da forme in presentazioni PowerPoint e OpenDocument con Aspose.Slides per C++ - soluzione rapida e adatta al codice."
---
## **Panoramica**

Le immagini in una presentazione possono comparire in diversi tipi di forma: come normali riquadri immagine, come riempimenti immagine applicati a forme, come anteprime di oggetti OLE, come miniature di fotogrammi video o audio, come immagini di zoom o come immagini annidate all’interno di tabelle, grafici e forme SmartArt. Aspose.Slides memorizza queste immagini nella raccolta di immagini della presentazione, esposta tramite [IImageCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimagecollection/) e [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) .

Se ti serve solo esportare ogni risorsa immagine incorporata in una presentazione, itera su `presentation->get_Images()`. Questo articolo si concentra su un compito diverso: attraversare le forme per trovare dove le immagini sono utilizzate nelle diapositive, così i file salvati possono mantenere un contesto utile come il numero della diapositiva, la posizione della forma e il tipo di origine (riquadro immagine, immagine di riempimento, anteprima multimediale, anteprima OLE o immagine di zoom).

{{% alert title="Tip" color="primary" %}}
Usa [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/)::`get_BinaryData()` per preservare i dati dell’immagine codificati originali e il tipo di file. Usa [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/)::`get_Image()` con [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/)::`Save` quando desideri normalizzare l’output in un formato specifico come PNG.
{{% /alert %}}

## **Metodi di supporto condivisi**

I metodi di supporto di seguito mantengono gli esempi brevi. `SaveOriginalImage` scrive i byte incorporati originali, sceglie un’estensione sicura dal tipo MIME e ignora i binari immagine duplicati tramite hash SHA‑256.

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

## **Estrai immagini da riquadri immagine**

Usa questo approccio per le immagini inserite come oggetti autonomi. Un [IPictureFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipictureframe/) memorizza la sua immagine in `get_PictureFormat()->get_Picture()->get_Image()`, che restituisce un oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) .

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

## **Estrai immagini da forme riempite con immagine**

Le forme possono utilizzare un’immagine come riempimento. Controlla prima il tipo di riempimento della forma: se non è [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/)::`Picture`, non c’è alcuna immagine da estrarre da quel riempimento. L’esempio sotto gestisce oggetti [IAutoShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/iautoshape/) e salva ogni immagine come PNG tramite [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Estrai anteprime immagine da riquadri oggetto OLE**

Un [IOleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ioleobjectframe/) può avere un’immagine sostitutiva che PowerPoint utilizza come anteprima dell’oggetto sulla diapositiva. Questa immagine è disponibile tramite `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Estrarre questa immagine fornisce l’anteprima, non il contenuto del pacchetto OLE incorporato.

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

## **Estrai anteprime immagine da riquadri video**

Un [IVideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/) può anche memorizzare un’immagine di anteprima in `get_PictureFormat()->get_Picture()->get_Image()`. Questa è la locandina o miniatura mostrata sulla diapositiva, non un fotogramma decodificato dal flusso video.

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

## **Estrai anteprime immagine da riquadri audio**

Un [IAudioFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/iaudioframe/) può memorizzare una miniatura in `get_PictureFormat()->get_Picture()->get_Image()`. Questa è l’immagine visualizzata per l’oggetto audio sulla diapositiva.

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

## **Estrai immagini da oggetti Zoom**

Le forme [IZoomFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/izoomframe/) e [ISectionZoomFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/isectionzoomframe/) possono utilizzare immagini personalizzate. Leggi `get_ZoomImage()` dal riquadro zoom.

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

## **Estrai immagini da riquadri Summary Zoom**

Un [ISummaryZoomFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/isummaryzoomframe/) è anche una forma. I suoi elementi di sezione possono usare immagini personalizzate, esposte tramite il metodo `get_ZoomImage()` di ciascuna sezione zoom.

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

## **Estrai immagini da forme tabella**

Un [ITable](https://reference.aspose.com/slides/it/cpp/aspose.slides/itable/) è una forma. Le immagini in una tabella sono solitamente memorizzate come riempimenti immagine nelle celle della tabella.

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

## **Estrai immagini da forme grafico**

Un [IChart](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/) è una forma. L’esempio sotto estrae un’immagine dal riempimento immagine dell’area del grafico.

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

## **Estrai immagini da forme SmartArt**

Un [ISmartArt](https://reference.aspose.com/slides/it/cpp/aspose.slides.smartart/ismartart/) è una forma. A seconda del layout SmartArt, le immagini possono essere memorizzate nei riempimenti dei punti elenco dei nodi o nei formati di riempimento delle forme nodo.

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

## **Includi immagini all’interno di forme raggruppate**

Le forme raggruppate contengono le proprie raccolte di forme. Il metodo di supporto condiviso `EnumerateShapes` ha un’opzione `includeGroupedShapes`. Impostala su `true` quando vuoi ispezionare le forme all’interno di oggetti [IGroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/igroupshape/) . L’esempio sotto estrae immagini da riquadri immagine, forme riempite con immagine, anteprime OLE, miniature di fotogrammi video e miniature di fotogrammi audio. Per includere anche immagini da tabelle, grafici, SmartArt e Summary Zoom, riutilizza la logica di estrazione specializzata delle sezioni precedenti mantenendo lo stesso percorso ricorsivo delle forme.

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

## **Casi limite e note pratiche**

- **Immagini duplicate:** più forme possono fare riferimento alla stessa immagine o a immagini diverse con byte identici. Esegui l’hash di [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/)::`get_BinaryData()` prima di scrivere i file se desideri un file di output per ogni immagine unica.
- **Dati originali vs output convertito:** salvare [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/)::`get_BinaryData()` preserva i dati JPEG, PNG, GIF, SVG, EMF o WMF incorporati. Salvare [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/)::`get_Image()` tramite [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/)::`Save` è utile quando vuoi un formato di output coerente.
- **Tipi di riempimento non supportati:** le forme con riempimento solido, sfumatura, motivo o senza riempimento non contengono un riempimento immagine. Controlla [FillType](https://reference.aspose.com/slides/it/cpp/aspose.slides/filltype/) prima di leggere `get_PictureFillFormat()` .
- **Forme raggruppate:** la raccolta forme di livello superiore dello slide non appiattisce i gruppi. Ispeziona ricorsivamente [IGroupShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/igroupshape/)::`get_Shapes()` quando il contenuto raggruppato è importante.
- **Anteprime oggetti OLE:** un [IOleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ioleobjectframe/) può esporre un’immagine di anteprima tramite `get_SubstitutePictureFormat()`, ma quell’immagine è solo l’anteprima della diapositiva. Non è il file incorporato all’interno dell’oggetto OLE.
- **Miniature fotogrammi video:** un [IVideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/) può esporre un’immagine di anteprima tramite `get_PictureFormat()`, ma quell’immagine è solo la locandina mostrata sulla diapositiva. Non è estratta dal flusso video.
- **Miniature fotogrammi audio:** un [IAudioFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/iaudioframe/) può esporre un’icona o miniatura tramite `get_PictureFormat()`; non è il dato audio incorporato.
- **Immagini zoom:** le forme di zoom slide, zoom sezione e zoom riepilogo possono utilizzare oggetti [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) personalizzati tramite `get_ZoomImage()` .
- **Modelli di forma annidati:** gli oggetti tabella, grafico e SmartArt implementano [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/), ma le loro immagini sono spesso memorizzate in oggetti di formattazione annidati di cella tabella, elemento grafico o nodo SmartArt.
- **Immagini ritagliate o trasformate:** accedere a [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) fornisce la risorsa immagine memorizzata. Non applica ritagli, trasparenze, ricolorazioni, rotazioni o altri effetti visivi applicati dalla forma.

## **FAQ**

**Posso estrarre l’immagine originale senza ritagli, effetti o trasformazioni di forma?**

Sì. Accedi all’oggetto [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) e scrivi [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/)::`get_BinaryData()` su disco. Questo preserva l’immagine codificata originale memorizzata nella presentazione, non il modo in cui l’immagine è renderizzata sulla diapositiva.

**Posso esportare ogni immagine estratta come PNG?**

Sì. Usa [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/)::`get_Image()` per ottenere un oggetto [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/) e poi chiama [IImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/iimage/)::`Save` con [ImageFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/imageformat/)::`Png`. Questo converte l’output e potrebbe non preservare il tipo di file originale o i dati vettoriali.

**Come evito di salvare la stessa immagine più di una volta?**

Usa un hash di [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/)::`get_BinaryData()` e conserva gli hash in un set. Se una nuova immagine ha un hash già presente, saltala o registra un’altra riferimento al file di output esistente.

**Perché alcune forme non producono un’immagine?**

Riquadri immagine, forme riempite con immagine, riquadri oggetto OLE, riquadri multimediali, riquadri zoom, tabelle, grafici e oggetti SmartArt possono fare riferimento a immagini. Alcuni tipi di forma espongono le immagini tramite oggetti di formattazione annidati, quindi un semplice controllo `get_PictureFormat()` o `get_FillFormat()` della forma non è sempre sufficiente.

**Posso estrarre la miniatura mostrata per un riquadro video?**

Sì. Usa [IVideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` e leggi `get_PictureFormat()->get_Picture()->get_Image()`. Questo estrae l’immagine di locandina memorizzata con il riquadro video, non un fotogramma generato dal file video.

**Come posso determinare quali forme usano un’immagine specifica dalla raccolta immagini della presentazione?**

Aspose.Slides non memorizza collegamenti inversi da [IPPImage](https://reference.aspose.com/slides/it/cpp/aspose.slides/ippimage/) alle forme. Costruisci una mappatura durante il percorso: ogni volta che trovi un riferimento immagine, registra il numero della diapositiva, il percorso della forma e l’hash o l’elemento della raccolta immagine.

**Posso estrarre le immagini incorporate all’interno di oggetti OLE, come documenti allegati?**

Puoi estrarre l’anteprima della diapositiva dell’oggetto OLE da [IOleObjectFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` . Tuttavia, quell’anteprima non è il documento incorporato stesso. Per estrarre le immagini dal file incorporato, estrai i dati OLE e analizzali con strumenti appropriati per quel tipo di file.