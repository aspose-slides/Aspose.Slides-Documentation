---
title: Извлечение изображений из фигур презентации на C++
linktitle: Изображение из фигуры
type: docs
weight: 90
url: /ru/cpp/extracting-images-from-presentation-shapes/
keywords:
- извлечение изображения
- получение изображения
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Извлеките изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++ - быстрое, удобное для кода решение."
---
## **Обзор**

Изображения в презентации могут появляться в нескольких типах фигур: в виде обычных рамок изображений, в виде заливок изображениями, применяемыми к фигурам, в виде предварительных изображений объектов OLE, в виде миниатюр видео- или аудио‑кадров, в виде изображений зум‑фреймов или как вложенные изображения в таблицах, диаграммах и фигурах SmartArt. Aspose.Slides хранит эти изображения в коллекции изображений презентации, доступной через [IImageCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iimagecollection/) и [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) объекты.

Если вам нужно только экспортировать каждый встроенный в презентацию ресурс изображения, пройдитесь по `presentation->get_Images()`. Эта статья посвящена иной задаче: обходу фигур для поиска, где изображения используются на слайдах, чтобы сохраняемые файлы сохраняли полезный контекст, например номер слайда, позицию фигуры и тип источника (рамка изображения, заливка изображением, предварительный просмотр медиа, предварительный просмотр OLE или зум‑изображение).

{{% alert title="Tip" color="info" %}}
Используйте [IPPImage]::`get_BinaryData()` для сохранения исходных кодированных данных изображения и типа файла. Используйте [IPPImage]::`get_Image()` совместно с [IImage]::`Save`, когда необходимо привести вывод к определенному формату, например PNG.
{{% /alert %}}

## **Общие вспомогательные методы**

Ниже представленные вспомогательные методы делают примеры короче. `SaveOriginalImage` записывает оригинальные вложенные байты, выбирает безопасное расширение из MIME‑типа и пропускает дублирующие бинарные данные изображений по SHA‑256 хешу.

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

## **Извлечение изображений из рамок изображений**

Используйте этот подход для изображений, вставленных как отдельные объекты. [IPictureFrame] хранит своё изображение в `get_PictureFormat()->get_Picture()->get_Image()`, который возвращает объект [IPPImage].

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

## **Извлечение изображений из фигур, заполненных изображениями**

Фигуры могут использовать изображение в качестве заливки. Сначала проверьте тип заливки фигуры: если он не [FillType]::`Picture`, то нет изображения для извлечения из этой заливки. Приведённый ниже пример работает с объектами [IAutoShape] и сохраняет каждое изображение в PNG через [IPPImage]::`get_Image()`.

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

## **Извлечение изображений предварительного просмотра из кадров объектов OLE**

[IOleObjectFrame] может иметь заменяющее изображение, которое PowerPoint использует как предварительный просмотр объекта на слайде. Это изображение доступно через `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Извлечение этого изображения даёт вам превью, а не содержимое вложенного пакета OLE.

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

## **Извлечение изображений предварительного просмотра из видеокадров**

[IVideoFrame] также может хранить изображение предварительного просмотра в `get_PictureFormat()->get_Picture()->get_Image()`. Это постер или миниатюра, отображаемая на слайде, а не кадр, декодированный из видеопотока.

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

## **Извлечение изображений предварительного просмотра из аудиокадров**

[IAudioFrame] может хранить миниатюру в `get_PictureFormat()->get_Picture()->get_Image()`. Это изображение, отображаемое для аудио‑объекта на слайде.

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

## **Извлечение изображений из объектов зума**

Фигуры [IZoomFrame] и [ISectionZoomFrame] могут использовать пользовательские изображения. Читайте `get_ZoomImage()` у зум‑кадра.

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

## **Извлечение изображений из суммарных зум‑кадров**

[ISummaryZoomFrame] также является фигурой. Его элементы разделов могут использовать пользовательские изображения, доступные через метод `get_ZoomImage()` каждого раздела суммарного зума.

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

## **Извлечение изображений из таблиц**

[ITable] является фигурой. Изображения в таблице обычно хранятся как заливка изображением в ячейках таблицы.

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

## **Извлечение изображений из диаграмм**

[IChart] является фигурой. Пример ниже извлекает изображение из заливки области диаграммы.

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

## **Извлечение изображений из фигур SmartArt**

[ISmartArt] является фигурой. В зависимости от макета SmartArt изображения могут храниться в заливках маркеров узлов или в форматах заливки фигур узлов.

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

## **Включение изображений внутри сгруппированных фигур**

Сгруппированные фигуры содержат собственные коллекции фигур. Общий вспомогательный метод `EnumerateShapes` имеет параметр `includeGroupedShapes`. Установите его в `true`, когда необходимо проверять фигуры внутри объектов [IGroupShape]. Пример ниже извлекает изображения из рамок изображений, фигур, заполненных изображениями, предварительных просмотров OLE‑объектов, миниатюр видеокадров и аудиокадров. Чтобы также включить изображения таблиц, диаграмм, SmartArt и суммарных зум‑кадров, переиспользуйте специализированную логику извлечения из предыдущих разделов, сохраняя тот же рекурсивный обход фигур.

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

## **Пограничные случаи и практические замечания**

- **Дублирующие изображения:** Несколько фигур могут ссылаться на одно и то же изображение или на отдельные изображения с идентичными байтами. Вычисляйте хеш [IPPImage]::`get_BinaryData()` перед записью файлов, если хотите один файл вывода на уникальное изображение.
- **Оригинальные данные vs. конвертированный вывод:** Сохранение [IPPImage]::`get_BinaryData()` сохраняет встроенные данные JPEG, PNG, GIF, SVG, EMF или WMF. Сохранение [IPPImage]::`get_Image()` через [IImage]::`Save` полезно, когда требуется единый формат вывода.
- **Неподдерживаемые типы заливки:** Сплошные, градиентные, шаблонные и беззаливные фигуры не содержат заливку изображением. Проверьте [FillType] перед чтением `get_PictureFillFormat()`.
- **Сгруппированные фигуры:** Коллекция фигур верхнего уровня слайда не разворачивает группы. Рекурсивно проверяйте [IGroupShape]::`get_Shapes()`, когда важен контент группы.
- **Предпросмотр OLE‑объектов:** [IOleObjectFrame] может предоставлять изображение предварительного просмотра через `get_SubstitutePictureFormat()`, но это изображение только превью слайда. Оно не является вложенным файлом внутри OLE‑объекта.
- **Миниатюры видеокадров:** [IVideoFrame] может предоставлять изображение предварительного просмотра через `get_PictureFormat()`, но это изображение только постер, отображаемый на слайде. Оно не извлекается из видеопотока.
- **Миниатюры аудиокадров:** [IAudioFrame] может предоставлять значок или миниатюру через `get_PictureFormat()`; это не вложенные аудиоданные.
- **Изображения зумов:** Фигуры зум‑слайда, зум‑раздела и суммарного зума могут использовать пользовательские объекты [IPPImage] через `get_ZoomImage()`.
- **Вложенные модели фигур:** Объекты таблиц, диаграмм и SmartArt реализуют [IShape], но их изображения часто хранятся во вложенных объектах форматирования ячеек таблиц, элементов диаграмм или узлов SmartArt.
- **Обрезанные или трансформированные изображения:** Доступ к [IPPImage] даёт вам хранимый ресурс изображения. Он не учитывает обрезку, прозрачность, перекраску, вращение или другие визуальные эффекты, применённые фигурой.

## **ЧАВО**

### Могу ли я извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?

Да. Доступ к объекту [IPPImage] и запись [IPPImage]::`get_BinaryData()` на диск сохраняет оригинальные закодированные данные изображения, хранящиеся в презентации, а не способ их отображения на слайде.

### Могу ли я экспортировать каждое извлечённое изображение в PNG?

Да. Используйте [IPPImage]::`get_Image()` чтобы получить объект [IImage], затем вызовите [IImage]::`Save` с [ImageFormat]::`Png`. Это преобразует вывод и может не сохранять оригинальный тип файла или векторные данные.

### Как избежать сохранения одного и того же изображения более одного раза?

Используйте хеш [IPPImage]::`get_BinaryData()` и храните хеши в наборе. Если новое изображение имеет уже существующий хеш, пропустите его или запишите другую ссылку на существующий файл.

### Почему некоторые фигуры не дают изображение?

Рамки изображений, фигуры, заполненные изображениями, кадры объектов OLE, медиа‑кадры, зум‑кадры, таблицы, диаграммы и объекты SmartArt могут ссылаться на изображения. Некоторые типы фигур предоставляют изображения через вложенные объекты форматирования, поэтому простая проверка `get_PictureFormat()` или `get_FillFormat()` может быть недостаточной.

### Могу ли я извлечь миниатюру, отображаемую для видеокадра?

Да. Используйте [IVideoFrame]::`get_PictureFormat()` и считайте `get_PictureFormat()->get_Picture()->get_Image()`. Это извлекает постер‑изображение, хранящееся вместе с видеокадром, а не кадр, созданный из видеофайла.

### Как определить, какие фигуры используют конкретное изображение из коллекции изображений презентации?

Aspose.Slides не хранит обратные ссылки от [IPPImage] к фигурам. Постройте отображение во время обхода: каждый раз, когда находите ссылку на изображение, записывайте номер слайда, путь к фигуре и хеш изображения или элемент коллекции.

### Могу ли я извлечь изображения, вложенные в OLE‑объекты, например прикреплённые документы?

Вы можете извлечь превью OLE‑объекта из [IOleObjectFrame]::`get_SubstitutePictureFormat()`. Однако это превью не является самим вложенным документом. Чтобы извлечь изображения из внутри вложенного файла, извлеките OLE‑данные и проанализируйте их с помощью соответствующих инструментов.