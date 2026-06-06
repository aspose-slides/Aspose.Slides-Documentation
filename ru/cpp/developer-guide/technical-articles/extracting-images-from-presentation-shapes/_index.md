---
title: Извлечение изображений из фигур презентации на C++
linktitle: Изображение из фигуры
type: docs
weight: 90
url: /ru/cpp/extracting-images-from-presentation-shapes/
keywords:
- извлечь изображение
- получить изображение
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Извлекайте изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++ — быстрое, удобное для кода решение."
---
## **Обзор**

Изображения в презентации могут находиться в нескольких типах фигур: в обычных кадровых изображениях, в виде заливки изображением, в предварительных просмотрах OLE‑объектов, в миниатюрах видеоматериалов или аудио‑фреймов, в изображениях зума, а также вложенными в таблицы, диаграммы и SmartArt. Aspose.Slides хранит эти изображения в коллекции изображений презентации, доступной через [IImageCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimagecollection/) и [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) объекты.

Если вам нужно лишь экспортировать каждый встроенный в презентацию ресурс изображения, пройдитесь по `presentation->get_Images()`. Эта статья рассматривает другую задачу: обход фигур, чтобы определить, где изображения используются на слайдах, чтобы сохранённые файлы могли содержать полезный контекст, такой как номер слайда, позиция фигуры и тип источника (кадр изображения, заливка, предварительный просмотр медиа, предварительный просмотр OLE или изображение зума).

{{% alert title="Tip" color="primary" %}}
Используйте [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/)::`get_BinaryData()` для сохранения оригинальных закодированных данных изображения и типа файла. Используйте [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/)::`get_Image()` вместе с [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/)::`Save`, когда необходимо привести вывод к конкретному формату, например PNG.
{{% /alert %}}

## **Общие вспомогательные методы**

Ниже представленные вспомогательные методы делают примеры короче. `SaveOriginalImage` записывает оригинальные вложенные байты, выбирает безопасное расширение из MIME‑типа и пропускает дублирующие бинарные данные изображений, используя хеш SHA‑256.

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

## **Извлечение изображений из кадровых фигур**

Используйте этот подход для изображений, вставленных как отдельные объекты. [IPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/) хранит своё изображение в `get_PictureFormat()->get_Picture()->get_Image()`, что возвращает объект [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/).

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

## **Извлечение изображений из фигур, залитых картинкой**

Фигуры могут использовать картинку в качестве заливки. Сначала проверьте тип заливки фигуры: если это не [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/)::`Picture`, то из такой заливки извлекать картинку нечего. Пример ниже работает с объектами [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) и сохраняет каждое изображение как PNG через [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Извлечение предварительных изображений из OLE‑кадров**

[IOleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ioleobjectframe/) может иметь заменяющую картинку, которую PowerPoint использует как превью объекта на слайде. Это изображение доступно через `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Извлечение этой картинки выдаёт изображение превью, а не содержимое встроенного OLE‑пакета.

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

## **Извлечение предварительных изображений из видеокадров**

[IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) также может хранить превью‑изображение в `get_PictureFormat()->get_Picture()->get_Image()`. Это постер или миниатюра, отображаемая на слайде, а не кадр, декодированный из видеопотока.

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

## **Извлечение предварительных изображений из аудиокадров**

[IAudioFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iaudioframe/) может хранить миниатюру в `get_PictureFormat()->get_Picture()->get_Image()`. Это изображение, показываемое для аудио‑объекта на слайде.

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

## **Извлечение изображений из объектов зума**

[IZoomFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/izoomframe/) и [ISectionZoomFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isectionzoomframe/) могут использовать пользовательские изображения. Читайте `get_ZoomImage()` из кадра зума.

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

## **Извлечение изображений из сводных кадров зума**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isummaryzoomframe/) также является фигурой. Его разделы могут использовать пользовательские изображения, доступные через метод `get_ZoomImage()` каждого раздела сводного зума.

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

## **Извлечение изображений из фигур таблиц**

[ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/) — это фигура. Изображения в таблице обычно хранятся как заливка картинкой в ячейках таблицы.

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

## **Извлечение изображений из фигур диаграмм**

[IChart](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/) — это фигура. Пример ниже извлекает изображение из заливки области диаграммы.

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

## **Извлечение изображений из фигур SmartArt**

[ISmartArt](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/ismartart/) — объект фигуры. В зависимости от макета SmartArt изображения могут храниться в заливках маркеров узлов или в форматах заливки фигур узлов.

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

## **Включение изображений внутри сгруппированных фигур**

Сгруппированные фигуры содержат собственные коллекции фигур. Общий вспомогательный метод `EnumerateShapes` имеет параметр `includeGroupedShapes`. Установите его в `true`, если нужно исследовать фигуры внутри объектов [IGroupShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igroupshape/). Пример ниже извлекает изображения из кадровых фигур, фигур с заливкой‑картинкой, превью OLE‑объектов, миниатюр видеокадров и аудиокадров. Чтобы также включить изображения из таблиц, диаграмм, SmartArt и сводных зумов, повторно используйте специализированную логику извлечения из предыдущих разделов, сохраняя тот же рекурсивный обход фигур.

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

## **Пограничные случаи и практические замечания**

- **Дублирующиеся изображения:** Несколько фигур могут ссылаться на одно и то же изображение или на разные изображения с идентичными байтами. Хешируйте [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/)::`get_BinaryData()` перед записью файлов, если требуется один файл на каждое уникальное изображение.
- **Оригинальные данные vs. преобразованный вывод:** Сохранение [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/)::`get_BinaryData()` сохраняет встроенные JPEG, PNG, GIF, SVG, EMF или WMF. Сохранение [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/)::`get_Image()` через [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/)::`Save` удобно, когда нужен единый формат вывода.
- **Неподдерживаемые типы заливки:** Сплошные, градиентные, узорные и беззаполнение фигуры не содержат заливки‑картинки. Проверьте [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) перед чтением `get_PictureFillFormat()`.
- **Сгруппированные фигуры:** Коллекция фигур верхнего уровня слайда не разворачивает группы. Рекурсивно исследуйте [IGroupShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igroupshape/)::`get_Shapes()`, когда важен групповой контент.
- **Превью OLE‑объектов:** [IOleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ioleobjectframe/) может предоставлять превью‑изображение через `get_SubstitutePictureFormat()`, но это лишь превью слайда, а не встроенный файл внутри OLE‑объекта.
- **Миниатюры видеокадров:** [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/) может предоставлять превью‑изображение через `get_PictureFormat()`, но это лишь постер, отображаемый на слайде, а не кадр, извлечённый из видеопотока.
- **Миниатюры аудиокадров:** [IAudioFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iaudioframe/) может предоставлять иконку или миниатюру через `get_PictureFormat()`; это не вложенные аудио‑данные.
- **Изображения зума:** Фигуры зума слайда, раздела и сводки могут использовать пользовательские [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) объекты через `get_ZoomImage()`.
- **Вложенные модели фигур:** Таблицы, диаграммы и SmartArt реализуют [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/), но их изображения часто хранятся в вложенных объектах форматирования ячеек таблиц, элементов диаграмм или узлов SmartArt.
- **Обрезанные или трансформированные картинки:** Доступ к [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) даёт вам сохранённый ресурс изображения. Он не учитывает обрезку, прозрачность, перекрас, вращение или другие визуальные эффекты, применённые фигурой.

## **FAQ**

**Могу ли я извлечь оригинальное изображение без обрезки, эффектов и трансформаций фигуры?**

Да. Обратитесь к объекту [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) и запишите `get_BinaryData()` на диск. Это сохраняет оригинальное закодированное изображение, хранящееся в презентации, а не то, как оно отображается на слайде.

**Можно ли экспортировать каждое извлечённое изображение в PNG?**

Да. Используйте [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/)::`get_Image()` для получения объекта [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/), а затем вызовите [IImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimage/)::`Save` с [ImageFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imageformat/)::`Png`. Это преобразует вывод и может не сохранить оригинальный тип файла или векторные данные.

**Как избежать множественного сохранения одного и того же изображения?**

Вычисляйте хеш от [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/)::`get_BinaryData()` и храните хеши в наборе. Если новое изображение имеет уже существующий хеш, пропустите его или запишите другую ссылку на существующий файл вывода.

**Почему некоторые фигуры не дают изображение?**

Кадровые фигуры, фигуры с заливкой‑картинкой, OLE‑кадры, медиа‑кадры, зум‑фигуры, таблицы, диаграммы и SmartArt могут ссылаться на изображения. Некоторые типы фигур раскрывают изображения через вложенные объекты форматирования, поэтому простая проверка `get_PictureFormat()` или `get_FillFormat()` может быть недостаточной.

**Можно ли извлечь миниатюру, отображаемую для видеокадра?**

Да. Используйте [IVideoFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` и прочитайте `get_PictureFormat()->get_Picture()->get_Image()`. Это извлечёт постер‑изображение, хранящееся вместе с видеокадром, а не кадр, сгенерированный из видео‑файла.

**Как определить, какие фигуры используют конкретное изображение из коллекции изображений презентации?**

Aspose.Slides не хранит обратные ссылки от [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) к фигурам. Постройте отображение во время обхода: когда находите ссылку на изображение, запишите номер слайда, путь к фигуре и хеш изображения или элемент коллекции.

**Могу ли я извлечь изображения, встроенные в OLE‑объекты, например вложенные документы?**

Вы можете извлечь превью OLE‑объекта из [IOleObjectFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`. Однако это превью не является самим вложенным документом. Чтобы извлечь изображения из внутри вложенного файла, экспортируйте OLE‑данные и проанализируйте их с помощью инструментов, соответствующих типу файла.