---
title: Extraer imágenes de formas de presentación en C++
linktitle: Imagen de forma
type: docs
weight: 90
url: /es/cpp/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Extrae imágenes de formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para C++ - solución rápida y fácil de usar en código."
---
## **Visión general**

Las imágenes en una presentación pueden aparecer en varios tipos de forma: como marcos de imágenes ordinarios, como imágenes de relleno aplicadas a formas, como imágenes de vista previa de objetos OLE, como miniaturas de fotogramas de vídeo o audio, como imágenes de zoom o como imágenes anidadas dentro de formas de tabla, gráfico y SmartArt. Aspose.Slides almacena esas imágenes en la colección de imágenes de la presentación, expuesta a través de los objetos [IImageCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimagecollection/) y [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/).

Si solo necesita exportar cada recurso de imagen incrustado en una presentación, itere a través de `presentation->get_Images()`. Este artículo se centra en una tarea diferente: recorrer las formas para encontrar dónde se usan las imágenes en las diapositivas, de modo que los archivos guardados puedan conservar contexto útil como el número de diapositiva, la posición de la forma y el tipo de origen (marco de imagen, imagen de relleno, vista previa de medios, vista previa OLE o imagen de zoom).

{{% alert title="Tip" color="primary" %}}
Utilice [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/)::`get_BinaryData()` para conservar los datos de imagen codificados originales y el tipo de archivo. Utilice [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/)::`get_Image()` con [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/)::`Save` cuando desee normalizar la salida a un formato específico como PNG.
{{% /alert %}}

## **Métodos auxiliares compartidos**

Los métodos auxiliares a continuación mantienen los ejemplos breves. `SaveOriginalImage` escribe los bytes originales incrustados, elige una extensión segura a partir del tipo MIME y omite binarios de imagen duplicados mediante hash SHA‑256.

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

## **Extraer imágenes de marcos de imágenes**

Utilice este enfoque para imágenes insertadas como objetos independientes. Un [IPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframe/) almacena su imagen en `get_PictureFormat()->get_Picture()->get_Image()`, que devuelve un objeto [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/).

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

## **Extraer imágenes de formas con relleno de imagen**

Las formas pueden usar una imagen como su relleno. Verifique primero el tipo de relleno de la forma: si no es [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/)::`Picture`, no hay ninguna imagen que extraer de ese relleno. El ejemplo a continuación maneja objetos [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) y guarda cada imagen como PNG mediante [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Extraer imágenes de vista previa de marcos de objetos OLE**

Un [IOleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ioleobjectframe/) puede tener una imagen sustituta que PowerPoint usa como vista previa del objeto en una diapositiva. Esta imagen está disponible a través de `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Extraer esta imagen le da la vista previa, no el contenido del paquete OLE incrustado.

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

## **Extraer imágenes de vista previa de marcos de vídeo**

Un [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) también puede almacenar una imagen de vista previa en `get_PictureFormat()->get_Picture()->get_Image()`. Esta es la póster o miniatura mostrada en la diapositiva, no un fotograma decodificado del flujo de vídeo.

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

## **Extraer imágenes de vista previa de marcos de audio**

Un [IAudioFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/iaudioframe/) puede almacenar una miniatura en `get_PictureFormat()->get_Picture()->get_Image()`. Esta es la imagen mostrada para el objeto de audio en la diapositiva.

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

## **Extraer imágenes de objetos de zoom**

Las formas [IZoomFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/izoomframe/) y [ISectionZoomFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/isectionzoomframe/) pueden usar imágenes personalizadas. Lea `get_ZoomImage()` del marco de zoom.

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

## **Extraer imágenes de marcos de resumen de zoom**

Un [ISummaryZoomFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/isummaryzoomframe/) también es una forma. Sus elementos de sección pueden usar imágenes personalizadas, expuestas a través del método `get_ZoomImage()` de cada sección de resumen de zoom.

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

## **Extraer imágenes de formas de tabla**

Una [ITable](https://reference.aspose.com/slides/es/cpp/aspose.slides/itable/) es una forma. Las imágenes en una tabla suelen almacenarse como rellenos de imagen en celdas de tabla.

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

## **Extraer imágenes de formas de gráfico**

Un [IChart](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/) es una forma. El ejemplo a continuación extrae una imagen del relleno de imagen del área del gráfico.

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

## **Extraer imágenes de formas SmartArt**

Un objeto [ISmartArt](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/ismartart/) es una forma. Dependiendo del diseño de SmartArt, las imágenes pueden almacenarse en los rellenos de viñeta de los nodos o en los formatos de relleno de las formas de los nodos.

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

## **Incluir imágenes dentro de formas agrupadas**

Las formas agrupadas contienen sus propias colecciones de formas. El auxiliar compartido `EnumerateShapes` tiene una opción `includeGroupedShapes`. Establécela en `true` cuando quiera inspeccionar formas dentro de objetos [IGroupShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/igroupshape/). El ejemplo a continuación extrae imágenes de marcos de imágenes, formas con relleno de imagen, vistas previas de objetos OLE, miniaturas de fotogramas de vídeo y miniaturas de fotogramas de audio. Para incluir también imágenes de tabla, gráfico, SmartArt y resumen de zoom, reutilice la lógica de extracción especializada de las secciones anteriores manteniendo el mismo recorrido recursivo de formas.

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

## **Casos límite y notas prácticas**

- **Imágenes duplicadas:** Varias formas pueden referenciar la misma imagen o imágenes distintas con bytes idénticos. Haga hash de [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/)::`get_BinaryData()` antes de escribir archivos si desea un archivo de salida por cada imagen única.
- **Datos originales vs. salida convertida:** Guardar [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/)::`get_BinaryData()` conserva los datos JPEG, PNG, GIF, SVG, EMF o WMF incrustados. Guardar [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/)::`get_Image()` mediante [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/)::`Save` es útil cuando se desea un formato de salida consistente.
- **Tipos de relleno no compatibles:** Las formas de relleno sólido, degradado, patrón o sin relleno no contienen una imagen de relleno. Verifique [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) antes de leer `get_PictureFillFormat()`.
- **Formas agrupadas:** La colección de formas de nivel superior de la diapositiva no aplana los grupos. Inspeccione recursivamente [IGroupShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/igroupshape/)::`get_Shapes()` cuando el contenido agrupado sea relevante.
- **Vistas previas de objetos OLE:** Un [IOleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ioleobjectframe/) puede exponer una imagen de vista previa a través de `get_SubstitutePictureFormat()`, pero esa imagen es solo la vista previa de la diapositiva. No es el archivo incrustado dentro del objeto OLE.
- **Miniaturas de fotogramas de vídeo:** Un [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/) puede exponer una imagen de vista previa a través de `get_PictureFormat()`, pero esa imagen es solo el póster mostrado en la diapositiva. No se extrae del flujo de vídeo.
- **Miniaturas de fotogramas de audio:** Un [IAudioFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/iaudioframe/) puede exponer un ícono o miniatura a través de `get_PictureFormat()`; no son los datos de audio incrustados.
- **Imágenes de zoom:** Las formas de zoom de diapositiva, de sección y de resumen pueden usar objetos [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) personalizados mediante `get_ZoomImage()`.
- **Modelos de forma anidados:** Los objetos de tabla, gráfico y SmartArt implementan [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/), pero sus imágenes suelen almacenarse en objetos de formato anidados de celdas de tabla, elementos de gráfico o nodos de SmartArt.
- **Imágenes recortadas o transformadas:** Acceder a [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) le da el recurso de imagen almacenado. No renderiza recortes, transparencias, recoloreado, rotación u otros efectos visuales aplicados por la forma.

## **Preguntas frecuentes**

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de forma?**

Sí. Acceda al objeto [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) y escriba [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/)::`get_BinaryData()` en disco. Esto conserva la imagen codificada original almacenada en la presentación, no la forma en que la imagen se renderiza en la diapositiva.

**¿Puedo exportar cada imagen extraída como PNG?**

Sí. Utilice [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/)::`get_Image()` para obtener un objeto [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/), y luego llame a [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/)::`Save` con [ImageFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/imageformat/)::`Png`. Esto convierte la salida y puede no conservar el tipo de archivo original ni los datos vectoriales.

**¿Cómo evito guardar la misma imagen más de una vez?**

Utilice un hash de [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/)::`get_BinaryData()` y mantenga los hashes en un conjunto. Si una nueva imagen tiene un hash que ya existe, omítala o registre otra referencia al archivo de salida existente.

**¿Por qué algunas formas no generan una imagen?**

Los marcos de imágenes, las formas con relleno de imagen, los marcos de objetos OLE, los marcos de medios, los marcos de zoom, las tablas, los gráficos y los objetos SmartArt pueden hacer referencia a imágenes. Algunos tipos de forma exponen imágenes mediante objetos de formato anidados, por lo que una simple comprobación `get_PictureFormat()` o `get_FillFormat()` de la forma no siempre es suficiente.

**¿Puedo extraer la miniatura mostrada para un marco de vídeo?**

Sí. Utilice [IVideoFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` y lea `get_PictureFormat()->get_Picture()->get_Image()`. Esto extrae la imagen de póster almacenada con el marco de vídeo, no un fotograma generado a partir del archivo de vídeo.

**¿Cómo puedo determinar qué formas usan una imagen específica de la colección de imágenes de la presentación?**

Aspose.Slides no almacena enlaces inversos de [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) a las formas. Construya un mapeo durante el recorrido: siempre que encuentre una referencia a una imagen, registre el número de diapositiva, la ruta de la forma y el hash de la imagen o el elemento de la colección.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

Puede extraer la vista previa del objeto OLE desde [IOleObjectFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`. Sin embargo, esa vista previa no es el documento incrustado propiamente dicho. Para extraer imágenes dentro del archivo incrustado, extraiga los datos OLE y examínelos con herramientas adecuadas para ese tipo de archivo.