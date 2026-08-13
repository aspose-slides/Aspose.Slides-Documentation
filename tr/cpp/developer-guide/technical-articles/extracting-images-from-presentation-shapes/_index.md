---
title: C++'ta Sunum Şekillerinden Görselleri Çıkarma
linktitle: Şekilden Görsel
type: docs
weight: 90
url: /tr/cpp/extracting-images-from-presentation-shapes/
keywords:
- görsel çıkar
- görsel al
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarındaki şekillerden görselleri çıkarın - hızlı ve kod dostu bir çözüm."
---
## **Genel Bakış**

Bir sunumdaki görseller çeşitli şekil türlerinde görünebilir: normal resim çerçeveleri olarak, şekillere uygulanan resim doldurmaları olarak, OLE nesne önizleme görselleri olarak, video veya ses çerçevesi küçük resimleri olarak, yakınlaştırma görselleri olarak veya tablo, grafik ve SmartArt şekilleri içinde iç içe geçmiş görseller olarak. Aspose.Slides bu görselleri sunum görsel koleksiyonunda saklar; bu koleksiyon [IImageCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimagecollection/) ve [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesneleri aracılığıyla erişilebilir.

Eğer bir sunuma gömülü tüm görüntü kaynaklarını dışa aktarmanız gerekiyorsa, `presentation->get_Images()` üzerinden döngü yapın. Bu makale farklı bir göreve odaklanır: kaydırılarda görüntülerin nerede kullanıldığını bulmak için şekilleri taramak, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, doldurma resmi, medya önizlemesi, OLE önizlemesi veya yakınlaştırma resmi) gibi yararlı bağlamı koruyabilir.

{{% alert title="Tip" color="info" %}}
[IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/)::`get_BinaryData()` kullanarak orijinal kodlanmış görüntü verisini ve dosya türünü koruyun. Çıktıyı PNG gibi belirli bir formata normalleştirmek istediğinizde [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/)::`get_Image()` metodunu [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/)::`Save` ile kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Yöntemler**

Aşağıdaki yardımcı yöntemler örnekleri kısa tutar. `SaveOriginalImage` orijinal gömülü baytları yazar, MIME tipinden güvenli bir uzantı seçer ve SHA-256 hash ile yinelenen görüntü ikili dosyalarını atlar.

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

## **Resim Çerçevelerinden Görselleri Çıkarma**

Bu yaklaşımı bağımsız nesne olarak eklenen resimler için kullanın. Bir [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) resmi `get_PictureFormat()->get_Picture()->get_Image()` içinde saklar; bu da bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi döndürür.

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

## **Resim Doldurmalı Şekillerden Görselleri Çıkarma**

Şekiller bir resmi doldurma olarak kullanabilir. Önce şeklin doldurma türünü kontrol edin: eğer [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/)::`Picture` değilse, o doldurmadan çıkarılacak bir resim yoktur. Aşağıdaki örnek [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) nesnelerini ele alır ve her görüntüyü [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/)::`get_Image()` aracılığıyla PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Önizleme Görsellerini Çıkarma**

Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) bir yedek resim içerebilir; PowerPoint bu resmi slayttaki nesnenin önizlemesi olarak kullanır. Bu görüntü `get_SubstitutePictureFormat()->get_Picture()->get_Image()` üzerinden elde edilebilir. Bu resmi çıkarmak, OLE paketinin gömülü içeriği değil, önizleme görselini verir.

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

## **Video Çerçevelerinden Önizleme Görsellerini Çıkarma**

Bir [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) aynı zamanda `get_PictureFormat()->get_Picture()->get_Image()` içinde bir önizleme görüntüsü saklayabilir. Bu, slaytta gösterilen poster veya küçük resimdir, video akışından çözülen bir çerçeve değildir.

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

## **Ses Çerçevelerinden Önizleme Görsellerini Çıkarma**

Bir [IAudioFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iaudioframe/) `get_PictureFormat()->get_Picture()->get_Image()` içinde bir küçük resim saklayabilir. Bu, slayttaki ses nesnesi için gösterilen görseldir.

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

## **Yakınlaştırma Nesnelerinden Görselleri Çıkarma**

[IZoomFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/izoomframe/) ve [ISectionZoomFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectionzoomframe/) şekilleri özel görseller kullanabilir. Yakınlaştırma çerçevesinden `get_ZoomImage()` metodunu okuyun.

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

## **Özet Yakınlaştırma Çerçevelerinden Görselleri Çıkarma**

[ISummaryZoomFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isummaryzoomframe/) aynı zamanda bir şekildir. Bölüm öğeleri özel görseller kullanabilir; bu, her özet yakınlaştırma bölümünün `get_ZoomImage()` yöntemiyle ortaya çıkar.

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

## **Tablo Şekillerinden Görselleri Çıkarma**

[ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) bir şekildir. Tablodaki görseller genellikle tablo hücrelerinde resim doldurması olarak saklanır.

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

## **Grafik Şekillerinden Görselleri Çıkarma**

[IChart](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/) bir şekildir. Aşağıdaki örnek, grafik alanının resim doldurmasından bir görsel çıkarır.

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

## **SmartArt Şekillerinden Görselleri Çıkarma**

[ISmartArt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/ismartart/) nesnesi bir şekildir. SmartArt düzenine bağlı olarak, görseller düğüm madde işareti doldurmalarında veya düğüm şekillerinin doldurma formatlarında depolanabilir.

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

## **Gruplandırılmış Şekiller İçindeki Görselleri Dahil Et**

Gruplandırılmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `EnumerateShapes` yardımcı fonksiyonunda `includeGroupedShapes` seçeneği vardır. [IGroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igroupshape/) nesneleri içindeki şekilleri incelemek istediğinizde bunu `true` olarak ayarlayın. Aşağıdaki örnek, resim çerçevelerinden, resim doldurmalı şekillerden, OLE nesne önizlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görselleri çıkarır. Tablo, grafik, SmartArt ve özet yakınlaştırma görsellerini de dahil etmek için, aynı yinelemeli şekil geçişini koruyarak önceki bölümlerdeki özelleştirilmiş çıkarma mantığını yeniden kullanın.

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

## **Köşe Durumları ve Pratik Notlar**

- **Yinelenen görseller:** Birden fazla şekil aynı görsele ya da aynı baytlara sahip ayrı görsellere referans verebilir. Her benzersiz görsel için bir çıktı dosyası istiyorsanız, dosyaları yazmadan önce [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/)::`get_BinaryData()` değerini hash'leyin.
- **Orijinal veri vs. dönüştürülmüş çıktı:** [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/)::`get_BinaryData()` kaydetmek gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verilerini korur. [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/)::`get_Image()` metodunu [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/)::`Save` ile kaydetmek, tutarlı bir çıktı formatı istediğinizde kullanışlıdır.
- **Desteklenmeyen doldurma türleri:** Katı, degrade, desen ve doldurulmamış şekillerde resim doldurması bulunmaz. `get_PictureFillFormat()`'ı okumadan önce [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) kontrol edin.
- **Gruplandırılmış şekiller:** Üst düzey slayt şekil koleksiyonu grupları düzleştirmez. Gruplandırılmış içerik önemli olduğunda [IGroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igroupshape/)::`get_Shapes()` metodunu yinelemeli olarak inceleyin.
- **OLE nesne önizlemeleri:** Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) `get_SubstitutePictureFormat()` üzerinden bir önizleme görseli sunabilir, ancak bu görsel sadece slayt önizlemesidir. OLE nesnesinin içindeki gömülü dosya değildir.
- **Video çerçeve küçük resimleri:** Bir [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) `get_PictureFormat()` üzerinden bir önizleme görseli sağlayabilir, ancak bu görsel sadece slaytta gösterilen posterdir. Video akışından çıkarılmaz.
- **Ses çerçeve küçük resimleri:** Bir [IAudioFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iaudioframe/) `get_PictureFormat()` üzerinden bir simge veya küçük resim sunabilir; bu gömülü ses verisi değildir.
- **Yakınlaştırma görselleri:** Slayt yakınlaştırma, bölüm yakınlaştırma ve özet yakınlaştırma şekilleri `get_ZoomImage()` aracılığıyla özel [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesneleri kullanabilir.
- **İç içe şekil modelleri:** Tablo, grafik ve SmartArt nesneleri [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) uygular, ancak görselleri çoğunlukla iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde saklanır.
- **Kırpılmış veya dönüştürülmüş resimler:** [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) erişimi, saklanan görüntü kaynağını verir. Şeklin uyguladığı kırpma, şeffaflık, yeniden renklendirme, döndürme veya diğer görsel etkileri render etmez.

## **SSS**

### Orijinal görüntüyü kırpma, efektler veya şekil dönüşümleri olmadan çıkarabilir miyim?

Evet. [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesine erişin ve [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/)::`get_BinaryData()`'yı diske yazın. Bu, sunumda depolanan orijinal kodlanmış görüntüyü, slaytta nasıl render edildiğiyle ilgili şeyleri korumadan saklar.

### Çıkarılan her görüntüyü PNG olarak dışa aktarabilir miyim?

Evet. [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/)::`get_Image()` kullanarak bir [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) nesnesi elde edin ve ardından [IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/)::`Save`'i [ImageFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imageformat/)::`Png` ile çağırın. Bu, çıktıyı dönüştürür ve orijinal dosya türü ya da vektör verisini korumayabilir.

### Aynı görüntüyü birden fazla kez kaydetmemek için ne yapmalıyım?

[IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/)::`get_BinaryData()`'ın bir hash'ini oluşturup hash'leri bir kümeye kaydedin. Yeni bir görüntünün hash'i zaten var ise, atlayın ya da mevcut çıktı dosyasına bir başka referans kaydedin.

### Neden bazı şekiller görüntü üretmiyor?

Resim çerçeveleri, resim doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, yakınlaştırma çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görüntülere referans verebilir. Bazı şekil türleri, görüntüleri iç içe biçimlendirme nesneleri aracılığıyla sunar, bu yüzden sadece `get_PictureFormat()` veya şekil `get_FillFormat()` kontrolü her zaman yeterli değildir.

### Bir video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?

Evet. [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` kullanın ve `get_PictureFormat()->get_Picture()->get_Image()`'ı okuyun. Bu, video çerçevesiyle birlikte saklanan poster görselini çıkarır, video dosyasından üretilen bir çerçeve değildir.

### Sunum görüntü koleksiyonundaki belirli bir görüntüyü hangi şekiller kullandığını nasıl belirleyebilirim?

Aspose.Slides, [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnelerinden şekillere geri bağlantılar tutmaz. Gezinme sırasında bir eşleme oluşturun: bir görüntü referansı bulduğunuzda, slayt numarasını, şekil yolunu ve görüntü hash'ini veya koleksiyon öğesini kaydedin.

### Ekli belgeler gibi OLE nesneleri içinde gömülü görselleri çıkarabilir miyim?

[IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` üzerinden OLE nesnesinin slayt önizlemesini çıkarabilirsiniz. Ancak bu önizleme, gömülü belgeyi içermez. Gömülü dosyadan görselleri çıkarmak için OLE verisini çıkarıp ilgili dosya türü araçlarıyla incelemeniz gerekir.