---
title: C++'da Sunum Şekillerinden Görüntü Çıkarma
linktitle: Şekilden Görüntü
type: docs
weight: 90
url: /tr/cpp/extracting-images-from-presentation-shapes/
keywords:
- görüntü çıkarma
- görüntü alma
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarındaki şekillerden görüntüleri çıkarın - hızlı, kod dostu bir çözüm."
---
## **Genel Bakış**

Bir sunumdaki görüntüler birkaç şekil türünde görünebilir: sıradan resim çerçeveleri olarak, şekillere uygulanan resim doldurması olarak, OLE nesne önizleme görüntüleri olarak, video veya ses çerçeve küçük resimleri olarak, yakınlaştırma görüntüleri olarak veya tablo, grafik ve SmartArt şekilleri içinde iç içe geçmiş görüntüler olarak. Aspose.Slides bu görüntüleri sunum görüntü koleksiyonunda depolar ve bu koleksiyon [IImageCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimagecollection/) ve [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesneleri aracılığıyla sunulur.

Sadece sunuma gömülü tüm görüntü kaynaklarını dışa aktarmanız gerekiyorsa `presentation->get_Images()` üzerinde yineleme yapın. Bu makale farklı bir göreve odaklanır: şekilleri gezerek görüntülerin slaytlarda nerede kullanıldığını bulmak, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, doldurma resmi, medya önizleme, OLE önizleme veya yakınlaştırma resmi) gibi yararlı bağlamı koruyabilir.

{{% alert title="İpucu" color="primary" %}}
Orijinal kodlanmış görüntü verisini ve dosya türünü korumak için [IPPImage]::`get_BinaryData()` kullanın. Çıktıyı PNG gibi belirli bir biçime normalleştirmek istediğinizde [IPPImage]::`get_Image()` ile [IImage]::`Save` kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Yöntemler**

Aşağıdaki yardımcı yöntemler örnekleri kısa tutar. `SaveOriginalImage` orijinal gömülü baytları yazar, MIME tipinden güvenli bir uzantı seçer ve SHA-256 karmasıyla yinelenen görüntü ikili dosyalarını atlar.

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

## **Resim Çerçevelerinden Görüntü Çıkarma**

Bu yaklaşımı bağımsız nesneler olarak eklenen resimler için kullanın. Bir [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/) resmini `get_PictureFormat()->get_Picture()->get_Image()` içinde saklar; bu, bir [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesi döndürür.

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

## **Resim Doldurmalı Şekillerden Görüntü Çıkarma**

Şekiller bir resmi doldurma olarak kullanabilir. İlk olarak şeklin doldurma tipini kontrol edin: eğer [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/)::`Picture` değilse, o doldurmadan çıkarılacak bir resim yoktur. Aşağıdaki örnek [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) nesnelerini işler ve her bir görüntüyü [IPPImage]::`get_Image()` aracılığıyla PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Önizleme Görüntüleri Çıkarma**

Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) PowerPoint'in nesnenin slayt üzerindeki önizlemesi olarak kullandığı bir yedek resme sahip olabilir. Bu resim `get_SubstitutePictureFormat()->get_Picture()->get_Image()` üzerinden erişilebilir. Bu resmi çıkarmak, gömülü OLE paketi içeriğini değil, önizleme görüntüsünü verir.

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

## **Video Çerçevelerinden Önizleme Görüntüleri Çıkarma**

Bir [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) de `get_PictureFormat()->get_Picture()->get_Image()` içinde bir önizleme resmi saklayabilir. Bu, slaytta gösterilen poster veya küçük resimdir, video akışından çözülen bir kare değildir.

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

## **Ses Çerçevelerinden Önizleme Görüntüleri Çıkarma**

Bir [IAudioFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iaudioframe/) `get_PictureFormat()->get_Picture()->get_Image()` içinde bir küçük resim tutabilir. Bu, ses nesnesi için slaytta gösterilen görüntüdür.

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

## **Yakınlaştırma Nesnelerinden Görüntü Çıkarma**

[IZoomFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/izoomframe/) ve [ISectionZoomFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isectionzoomframe/) şekilleri özel resimler kullanabilir. Yakınlaştırma çerçevesinden `get_ZoomImage()` okuyun.

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

## **Özet Yakınlaştırma Çerçevelerinden Görüntü Çıkarma**

[ISummaryZoomFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isummaryzoomframe/) de bir şekildir. Bölüm öğeleri özel resimler kullanabilir; her özet yakınlaştırma bölümünün `get_ZoomImage()` yöntemiyle ortaya çıkar.

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

## **Tablo Şekillerinden Görüntü Çıkarma**

[ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) bir şekildir. Tablo içindeki görüntüler genellikle tablo hücrelerindeki resim doldurmaları olarak saklanır.

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

## **Grafik Şekillerinden Görüntü Çıkarma**

[IChart](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/) bir şekildir. Aşağıdaki örnek grafik alanının resim doldurmasından bir görüntü çıkarır.

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

## **SmartArt Şekillerinden Görüntü Çıkarma**

[ISmartArt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/ismartart/) bir nesnedir ve bir şekildir. SmartArt yerleşimine bağlı olarak görüntüler düğüm madde doldurmalarında veya düğüm şekillerinin doldurma formatlarında saklanabilir.

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

## **Gruplandırılmış Şekiller İçindeki Görüntüleri Dahil Etme**

Gruplandırılmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `EnumerateShapes` yardımcı yöntemi bir `includeGroupedShapes` seçeneğine sahiptir. [IGroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igroupshape/) nesneleri içinde şekilleri incelemek istiyorsanız bunu `true` yapın. Aşağıdaki örnek resim çerçevelerinden, resim doldurmalı şekillerden, OLE nesne önizlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görüntüleri çıkarır. Tablo, grafik, SmartArt ve özet yakınlaştırma görüntülerini de dahil etmek için önceki bölümlerdeki özel çıkarma mantığını yeniden kullanın ve aynı yinelemeli şekil taramasını koruyun.

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

## **Köşe Durumları ve Pratik Notlar**

- **Yinelenen görüntüler:** Birden çok şekil aynı görüntüyü ya da aynı baytlara sahip ayrı görüntüleri referans gösterebilir. Benzersiz bir görüntü başına tek bir çıktı dosyası istiyorsanız dosyaları yazmadan önce [IPPImage]::`get_BinaryData()` karmasını alarak kontrol edin.
- **Orijinal veri vs. dönüştürülmüş çıktı:** [IPPImage]::`get_BinaryData()` kaydedildiğinde gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verisi korunur. Tutarlı bir çıktı biçimi istediğinizde [IPPImage]::`get_Image()` ve ardından [IImage]::`Save` kullanmak faydalıdır.
- **Desteklenmeyen doldurma tipleri:** Katı, degrade, desen ve boş doldurma şekilleri resim doldurması içermez. `get_PictureFillFormat()` okumadan önce [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/filltype/) kontrol edin.
- **Gruplandırılmış şekiller:** Üst‑seviye slayt şekil koleksiyonu grupları düzleştirmez. Gruplandırılmış içerik önemliyse [IGroupShape]::`get_Shapes()`'i yinelemeli olarak inceleyin.
- **OLE nesne önizlemeleri:** Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ioleobjectframe/) `get_SubstitutePictureFormat()` aracılığıyla bir önizleme resmi sunabilir, ancak bu sadece slayt önizlemesidir; OLE nesnesinin içinde gömülü dosya değildir.
- **Video çerçeve küçük resimleri:** Bir [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) `get_PictureFormat()` üzerinden bir önizleme resmi sunabilir, ancak bu yalnızca slaytta gösterilen poster/görseldir; video akışından çözülen bir kare değildir.
- **Ses çerçeve küçük resimleri:** Bir [IAudioFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iaudioframe/) `get_PictureFormat()` aracılığıyla bir simge ya da küçük resim sağlayabilir; bu, gömülü ses verisi değildir.
- **Yakınlaştırma resimleri:** Slayt yakınlaştırma, bölüm yakınlaştırma ve özet yakınlaştırma şekilleri `get_ZoomImage()` üzerinden özel [IPPImage] nesneleri kullanabilir.
- **İç içe şekil modelleri:** Tablo, grafik ve SmartArt nesneleri [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) uygular, ancak görüntüleri genellikle iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde saklanır.
- **Kırpılmış veya dönüştürülmüş resimler:** [IPPImage] eriştiğinizde depolanmış görüntü kaynağını alırsınız; şekil tarafından uygulanan kırpma, şeffaflık, renk değişimi, döndürme veya diğer görsel efektler işleme dahil değildir.

## **SSS**

**Orijinal resmi kırpma, efekt veya şekil dönüşümleri olmadan çıkarabilir miyim?**  
Evet. [IPPImage] nesnesine erişin ve `get_BinaryData()` sonucunu diske yazın. Bu, sunumda saklanan orijinal kodlanmış görüntüyü korur, slaytta nasıl render edildiğiyle ilgili hiçbir değişiklik yapmaz.

**Çıkarılan tüm görüntüleri PNG olarak dışa aktarabilir miyim?**  
Evet. [IPPImage]::`get_Image()` ile bir [IImage] elde edin ve ardından [IImage]::`Save` ile [ImageFormat]::`Png` kullanarak kaydedin. Bu, çıktıyı PNG’ye dönüştürür ve orijinal dosya türü ya da vektör verisi korunmayabilir.

**Aynı resmi birden fazla kez kaydetmekten nasıl kaçınabilirim?**  
[IPPImage]::`get_BinaryData()` karmasını alın ve bir kümede saklayın. Yeni bir resmin karması zaten mevcutsa dosyayı atlayın ya da aynı çıktı dosyasına başka bir referans kaydedin.

**Neden bazı şekiller görüntü üretmiyor?**  
Resim çerçeveleri, resim doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, yakınlaştırma çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görüntü referansları tutabilir. Bazı şekil türleri görüntüleri iç içe biçimlendirme nesneleri üzerinden sunar; bu yüzden yalnızca `get_PictureFormat()` veya `get_FillFormat()` kontrolü her zaman yeterli değildir.

**Video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?**  
Evet. [IVideoFrame]::`get_PictureFormat()` kullanın ve ardından `get_PictureFormat()->get_Picture()->get_Image()` okuyun. Bu, video çerçevesiyle birlikte saklanan poster/görseli çıkarır; video dosyasından oluşturulmuş bir kare değildir.

**Bir sunum görüntü koleksiyonundaki belirli bir görüntüyü hangi şekiller kullandığını nasıl belirleyebilirim?**  
Aspose.Slides, [IPPImage] nesnesinden şekillere ters bağlantı tutmaz. Gezinme sırasında bir görüntü referansı bulduğunuzda slayt numarasını, şekil yolunu ve görüntü karmasını (veya koleksiyon öğesini) kaydedin.

**OLE nesneleri içinde gömülü, örneğin ekli belgeler gibi, görüntüleri çıkarabilir miyim?**  
[IOleObjectFrame]::`get_SubstitutePictureFormat()` aracılığıyla nesnenin slayt önizlemesini çıkarabilirsiniz; ancak bu önizleme gömülü belgeyi içermez. Gömülü dosyanın içindeki görüntüleri çıkarmak için OLE verisini dışa aktarın ve ilgili dosya türü araçlarıyla inceleyin.