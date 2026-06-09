---
title: Extrair Imagens de Formas de Apresentação em C++
linktitle: Imagem da Forma
type: docs
weight: 90
url: /pt/cpp/extracting-images-from-presentation-shapes/
keywords:
- extrair imagem
- recuperar imagem
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Extrair imagens de formas em apresentações PowerPoint e OpenDocument com Aspose.Slides para C++ - solução rápida e amigável ao código."
---
## **Visão geral**

As imagens em uma apresentação podem aparecer em vários tipos de forma: como quadros de imagem comuns, como preenchimentos de imagem aplicados a formas, como imagens de visualização de objetos OLE, como miniaturas de quadros de vídeo ou áudio, como imagens de zoom ou como imagens inseridas dentro de formas de tabela, gráfico e SmartArt. Aspose.Slides armazena essas imagens na coleção de imagens da apresentação, exposta através dos objetos [IImageCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimagecollection/) e [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/).

Se você só precisar exportar todos os recursos de imagem incorporados em uma apresentação, itere através de `presentation->get_Images()`. Este artigo foca em uma tarefa diferente: percorrer as formas para encontrar onde as imagens são usadas nos slides, de modo que os arquivos salvos possam manter contexto útil, como o número do slide, a posição da forma e o tipo de origem (quadro de imagem, imagem de preenchimento, visualização de mídia, visualização OLE ou imagem de zoom).

{{% alert title="Tip" color="primary" %}}
Use [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/)::`get_BinaryData()` para preservar os dados de imagem codificados originais e o tipo de arquivo. Use [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/)::`get_Image()` com [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/)::`Save` quando quiser normalizar a saída para um formato específico, como PNG.
{{% /alert %}}

## **Métodos auxiliares compartilhados**

Os métodos auxiliares abaixo mantêm os exemplos curtos. `SaveOriginalImage` grava os bytes incorporados originais, escolhe uma extensão segura a partir do tipo MIME e ignora binários de imagem duplicados por hash SHA-256.

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

## **Extrair imagens de quadros de imagem**

Use esta abordagem para imagens inseridas como objetos autônomos. Um [IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/) armazena sua imagem em `get_PictureFormat()->get_Picture()->get_Image()`, que retorna um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/).

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

## **Extrair imagens de formas preenchidas com imagem**

Formas podem usar uma imagem como preenchimento. Verifique primeiro o tipo de preenchimento da forma: se não for [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/)::`Picture`, não há imagem para extrair desse preenchimento. O exemplo abaixo trata objetos [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) e salva cada imagem como PNG através de [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Extrair imagens de visualização de quadros de objeto OLE**

Um [IOleObjectFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ioleobjectframe/) pode ter uma imagem substituta que o PowerPoint usa como visualização do objeto em um slide. Essa imagem está disponível através de `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Extrair essa imagem fornece a visualização, não o conteúdo do pacote OLE incorporado.

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

## **Extrair imagens de visualização de quadros de vídeo**

Um [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/) também pode armazenar uma imagem de visualização em `get_PictureFormat()->get_Picture()->get_Image()`. Essa é a capa ou miniatura mostrada no slide, não um quadro decodificado do fluxo de vídeo.

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

## **Extrair imagens de visualização de quadros de áudio**

Um [IAudioFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iaudioframe/) pode armazenar uma miniatura em `get_PictureFormat()->get_Picture()->get_Image()`. Essa é a imagem mostrada para o objeto de áudio no slide.

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

## **Extrair imagens de objetos de zoom**

[IZoomFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/izoomframe/) e [ISectionZoomFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isectionzoomframe/) podem usar imagens personalizadas. Leia `get_ZoomImage()` do quadro de zoom.

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

## **Extrair imagens de quadros de resumo de zoom**

Um [ISummaryZoomFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isummaryzoomframe/) também é uma forma. Seus itens de seção podem usar imagens personalizadas, expostas através do método `get_ZoomImage()` de cada seção de resumo de zoom.

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

## **Extrair imagens de formas de tabela**

Um [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/) é uma forma. Imagens em uma tabela geralmente são armazenadas como preenchimentos de imagem nas células da tabela.

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

## **Extrair imagens de formas de gráfico**

Um [IChart](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichart/) é uma forma. O exemplo abaixo extrai uma imagem do preenchimento de imagem da área do gráfico.

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

## **Extrair imagens de formas SmartArt**

Um [ISmartArt](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/ismartart/) é uma forma. Dependendo do layout do SmartArt, as imagens podem estar armazenadas em preenchimentos de marcadores de nó ou nos formatos de preenchimento das formas dos nós.

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

## **Incluir imagens dentro de formas agrupadas**

Formas agrupadas contêm suas próprias coleções de formas. O método auxiliar compartilhado `EnumerateShapes` tem uma opção `includeGroupedShapes`. Defina-a como `true` quando quiser inspecionar as formas dentro de objetos [IGroupShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/igroupshape/). O exemplo abaixo extrai imagens de quadros de imagem, formas preenchidas com imagem, visualizações de objetos OLE, miniaturas de quadros de vídeo e miniaturas de quadros de áudio. Para incluir também imagens de tabelas, gráficos, SmartArt e zoom de resumo, reutilize a lógica de extração especializada das seções anteriores mantendo a mesma travessia recursiva de formas.

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

## **Casos limites e notas práticas**

- **Imagens duplicadas:** Várias formas podem referenciar a mesma imagem ou imagens distintas com bytes idênticos. Crie hash de [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/)::`get_BinaryData()` antes de gravar arquivos se quiser um arquivo de saída por imagem única.
- **Dados originais vs. saída convertida:** Salvar [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/)::`get_BinaryData()` preserva os dados JPEG, PNG, GIF, SVG, EMF ou WMF incorporados. Salvar [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/)::`get_Image()` através de [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/)::`Save` é útil quando se deseja um formato de saída consistente.
- **Tipos de preenchimento não suportados:** Formas sólidas, gradientes, padrão e sem preenchimento não contêm preenchimento de imagem. Verifique [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) antes de ler `get_PictureFillFormat()`.
- **Formas agrupadas:** A coleção de formas de slide de nível superior não achata grupos. Inspecione recursivamente [IGroupShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/igroupshape/)::`get_Shapes()` quando o conteúdo agrupado for relevante.
- **Visualizações de objetos OLE:** Um [IOleObjectFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ioleobjectframe/) pode expor uma imagem de visualização via `get_SubstitutePictureFormat()`, mas essa imagem é apenas a visualização do slide. Não é o arquivo incorporado dentro do objeto OLE.
- **Miniaturas de quadros de vídeo:** Um [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/) pode expor uma imagem de visualização via `get_PictureFormat()`, mas essa imagem é apenas a capa mostrada no slide. Não é extraída do fluxo de vídeo.
- **Miniaturas de quadros de áudio:** Um [IAudioFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iaudioframe/) pode expor um ícone ou miniatura via `get_PictureFormat()`; não são os dados de áudio incorporados.
- **Imagens de zoom:** Formas de zoom de slide, zoom de seção e zoom de resumo podem usar objetos [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) personalizados via `get_ZoomImage()`.
- **Modelos de forma aninhados:** Objetos de tabela, gráfico e SmartArt implementam [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/), mas suas imagens costumam estar armazenadas em objetos de formatação de célula de tabela, elemento de gráfico ou nó de SmartArt.
- **Imagens recortadas ou transformadas:** Acessar [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) fornece o recurso de imagem armazenado. Ele não renderiza recortes, transparência, recoloração, rotação ou outros efeitos visuais aplicados pela forma.

## **Perguntas frequentes**

**Posso extrair a imagem original sem recortes, efeitos ou transformações de forma?**

Sim. Acesse o objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) e grave [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/)::`get_BinaryData()` no disco. Isso preserva a imagem codificada original armazenada na apresentação, não a forma como a imagem é renderizada no slide.

**Posso exportar every extracted image as PNG?** (Mantendo o texto original da pergunta porque é um termo técnico)  
Sim. Use [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/)::`get_Image()` para obter um objeto [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/), e então chame [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/)::`Save` com [ImageFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imageformat/)::`Png`. Isso converte a saída e pode não preservar o tipo de arquivo original ou dados vetoriais.

**Como evito salvar a mesma imagem mais de uma vez?**

Use um hash de [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/)::`get_BinaryData()` e mantenha os hashes em um conjunto. Se uma nova imagem tiver um hash que já existe, ignore‑a ou registre outra referência ao arquivo de saída existente.

**Por que algumas formas não produzem uma imagem?**

Quadros de imagem, formas preenchidas com imagem, quadros de objeto OLE, quadros de mídia, quadros de zoom, tabelas, gráficos e objetos SmartArt podem referenciar imagens. Alguns tipos de forma expõem imagens através de objetos de formatação aninhados, de modo que uma simples verificação `get_PictureFormat()` ou `get_FillFormat()` da forma nem sempre é suficiente.

**Posso extrair a miniatura mostrada para um quadro de vídeo?**

Sim. Use [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` e leia `get_PictureFormat()->get_Picture()->get_Image()`. Isso extrai a imagem de capa armazenada com o quadro de vídeo, não um quadro gerado a partir do arquivo de vídeo.

**Como posso determinar quais formas usam uma imagem específica da coleção de imagens da apresentação?**

Aspose.Slides não armazena links reversos de [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) para as formas. Construa um mapeamento durante a travessia: sempre que encontrar uma referência a uma imagem, registre o número do slide, o caminho da forma e o hash ou item da coleção da imagem.

**Posso extrair imagens incorporadas dentro de objetos OLE, como documentos anexados?**

Você pode extrair a visualização do slide do objeto OLE via [IOleObjectFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`. No entanto, essa visualização não é o documento incorporado propriamente dito. Para extrair imagens de dentro do arquivo incorporado, extraia os dados OLE e inspecione‑os com ferramentas adequadas ao tipo de arquivo.