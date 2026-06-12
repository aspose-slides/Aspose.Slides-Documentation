---
title: Ekstrak Gambar dari Bentuk Presentasi dalam C++
linktitle: Gambar dari Bentuk
type: docs
weight: 90
url: /id/cpp/extracting-images-from-presentation-shapes/
keywords:
- ekstrak gambar
- ambil gambar
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Ekstrak gambar dari bentuk dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk C++ - solusi cepat dan ramah kode."
---
## **Gambaran Umum**

Gambar dalam presentasi dapat muncul dalam beberapa jenis bentuk: sebagai bingkai gambar biasa, sebagai isian gambar yang diterapkan pada bentuk, sebagai gambar pratinjau objek OLE, sebagai gambar miniatur bingkai video atau audio, sebagai gambar zoom, atau sebagai gambar yang ditanam di dalam bentuk tabel, diagram, dan SmartArt. Aspose.Slides menyimpan gambar‑gambar tersebut dalam koleksi gambar presentasi, yang dapat diakses melalui [IImageCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimagecollection/) dan [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) .

Jika Anda hanya perlu mengekspor setiap sumber gambar yang disisipkan dalam presentasi, iterasi melalui `presentation->get_Images()`. Artikel ini berfokus pada tugas yang berbeda: menelusuri bentuk untuk menemukan di mana gambar digunakan pada slide, sehingga file yang disimpan dapat menyimpan konteks berguna seperti nomor slide, posisi bentuk, dan jenis sumber (bingkai gambar, isian gambar, pratinjau media, pratinjau OLE, atau gambar zoom).

{{% alert title="Tip" color="primary" %}}

Gunakan [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/)::`get_BinaryData()` untuk mempertahankan data gambar yang terenkripsi asli dan tipe berkasnya. Gunakan [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/)::`get_Image()` dengan [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/)::`Save` ketika Anda ingin menormalkan output ke format tertentu seperti PNG.

{{% /alert %}}

## **Metode Pembantu Bersama**

Metode pembantu di bawah ini menjaga contoh tetap singkat. `SaveOriginalImage` menulis byte tertanam asli, memilih ekstensi yang aman dari tipe MIME, dan melewati gambar biner duplikat berdasarkan hash SHA‑256.

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

## **Ekstrak Gambar dari Bingkai Gambar**

Gunakan pendekatan ini untuk gambar yang disisipkan sebagai objek terpisah. Sebuah [IPictureFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipictureframe/) menyimpan gambar dalam `get_PictureFormat()->get_Picture()->get_Image()`, yang mengembalikan objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) .

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

## **Ekstrak Gambar dari Bentuk yang Diisi Gambar**

Bentuk dapat menggunakan gambar sebagai isian mereka. Periksa tipe isian bentuk terlebih dahulu: jika bukan [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/)::`Picture`, tidak ada gambar yang dapat diekstrak dari isian tersebut. Contoh di bawah menangani objek [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) dan menyimpan setiap gambar sebagai PNG melalui [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/)::`get_Image()` .

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

## **Ekstrak Gambar Pratinjau dari Bingkai Objek OLE**

Sebuah [IOleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ioleobjectframe/) dapat memiliki gambar pengganti yang digunakan PowerPoint sebagai pratinjau objek pada slide. Gambar ini tersedia melalui `get_SubstitutePictureFormat()->get_Picture()->get_Image()` . Mengekstrak gambar ini memberi Anda gambar pratinjau, bukan isi paket OLE yang tertanam.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Video**

Sebuah [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) juga dapat menyimpan gambar pratinjau dalam `get_PictureFormat()->get_Picture()->get_Image()` . Ini adalah poster atau thumbnail yang ditampilkan pada slide, bukan frame yang didekode dari aliran video.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Audio**

Sebuah [IAudioFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iaudioframe/) dapat menyimpan thumbnail dalam `get_PictureFormat()->get_Picture()->get_Image()` . Ini adalah gambar yang ditampilkan untuk objek audio pada slide.

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

## **Ekstrak Gambar dari Objek Zoom**

Bentuk [IZoomFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/izoomframe/) dan [ISectionZoomFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/isectionzoomframe/) dapat menggunakan gambar khusus. Baca `get_ZoomImage()` dari bingkai zoom.

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

## **Ekstrak Gambar dari Bingkai Zoom Ringkasan**

Sebuah [ISummaryZoomFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/isummaryzoomframe/) juga merupakan bentuk. Item bagian ringkasannya dapat menggunakan gambar khusus, yang dapat diakses melalui metode `get_ZoomImage()` pada setiap bagian zoom ringkasan.

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

## **Ekstrak Gambar dari Bentuk Tabel**

Sebuah [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) adalah bentuk. Gambar dalam tabel biasanya disimpan sebagai isian gambar dalam sel tabel.

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

## **Ekstrak Gambar dari Bentuk Diagram**

Sebuah [IChart](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/ichart/) adalah bentuk. Contoh di bawah mengekstrak gambar dari isian gambar area diagram.

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

## **Ekstrak Gambar dari Bentuk SmartArt**

Sebuah [ISmartArt](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/ismartart/) adalah bentuk. Tergantung pada tata letak SmartArt, gambar dapat disimpan dalam isian bulatan node atau dalam format isian bentuk node.

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

## **Sertakan Gambar di Dalam Bentuk yang Dikelompokkan**

Bentuk yang dikelompokkan memiliki koleksi bentuknya sendiri. Pembantu `EnumerateShapes` bersama memiliki opsi `includeGroupedShapes`. Atur menjadi `true` ketika Anda ingin memeriksa bentuk di dalam objek [IGroupShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/igroupshape/) . Contoh di bawah mengekstrak gambar dari bingkai gambar, bentuk yang diisi gambar, pratinjau objek OLE, thumbnail bingkai video, dan thumbnail bingkai audio. Untuk memasukkan gambar tabel, diagram, SmartArt, dan zoom ringkasan juga, gunakan kembali logika ekstraksi khusus dari bagian sebelumnya sambil mempertahankan penelusuran bentuk rekursif yang sama.

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

## **Kasus Khusus dan Catatan Praktis**

- **Gambar duplikat:** Beberapa bentuk dapat merujuk pada gambar yang sama atau gambar terpisah dengan byte identik. Hash [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/)::`get_BinaryData()` sebelum menulis berkas jika Anda menginginkan satu berkas output per gambar unik.
- **Data asli vs. output yang dikonversi:** Menyimpan [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/)::`get_BinaryData()` mempertahankan data JPEG, PNG, GIF, SVG, EMF, atau WMF yang tertanam. Menyimpan [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/)::`get_Image()` melalui [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/)::`Save` berguna ketika Anda menginginkan format output yang konsisten.
- **Tipe isian yang tidak didukung:** Bentuk padat, gradien, pola, dan tanpa isian tidak mengandung isian gambar. Periksa [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) sebelum membaca `get_PictureFillFormat()` .
- **Bentuk yang dikelompokkan:** Koleksi bentuk slide tingkat atas tidak meratakan grup. Periksa secara rekursif [IGroupShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/igroupshape/)::`get_Shapes()` ketika konten grup penting.
- **Pratinjau objek OLE:** Sebuah [IOleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ioleobjectframe/) dapat menampilkan gambar pratinjau melalui `get_SubstitutePictureFormat()` , tetapi gambar tersebut hanya pratinjau slide. Itu bukan berkas tertanam di dalam objek OLE.
- **Thumbnail bingkai video:** Sebuah [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/) dapat menampilkan gambar pratinjau melalui `get_PictureFormat()` , namun gambar tersebut hanya poster yang ditampilkan pada slide. Itu tidak diekstrak dari aliran video.
- **Thumbnail bingkai audio:** Sebuah [IAudioFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/iaudioframe/) dapat menampilkan ikon atau thumbnail melalui `get_PictureFormat()` ; itu bukan data audio yang tertanam.
- **Gambar zoom:** Bentuk zoom slide, zoom bagian, dan zoom ringkasan dapat menggunakan objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) khusus melalui `get_ZoomImage()` .
- **Model bentuk bersarang:** Objek tabel, diagram, dan SmartArt mengimplementasikan [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) , tetapi gambar mereka sering disimpan dalam objek format sel tabel, elemen diagram, atau node SmartArt yang bersarang.
- **Gambar yang dipotong atau ditransformasi:** Mengakses [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) memberi Anda sumber gambar yang disimpan. Itu tidak menerapkan pemotongan, transparansi, perubahan warna, rotasi, atau efek visual lain yang diterapkan oleh bentuk.

## **FAQ**

**Apakah saya dapat mengekstrak gambar asli tanpa pemotongan, efek, atau transformasi bentuk?**

Ya. Akses objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) dan tulis [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/)::`get_BinaryData()` ke disk. Ini mempertahankan gambar terenkripsi asli yang disimpan dalam presentasi, bukan cara gambar tersebut dirender pada slide.

**Apakah saya dapat mengekspor setiap gambar yang diekstrak sebagai PNG?**

Ya. Gunakan [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/)::`get_Image()` untuk mendapatkan objek [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) , lalu panggil [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/)::`Save` dengan [ImageFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/imageformat/)::`Png` . Ini mengonversi output dan mungkin tidak mempertahankan tipe berkas asli atau data vektor.

**Bagaimana cara saya menghindari menyimpan gambar yang sama lebih dari sekali?**

Gunakan hash dari [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/)::`get_BinaryData()` dan simpan hash tersebut dalam satu set. Jika gambar baru memiliki hash yang sudah ada, lewati atau catat referensi lain ke berkas output yang sudah ada.

**Mengapa beberapa bentuk tidak menghasilkan gambar?**

Bingkai gambar, bentuk yang diisi gambar, bingkai objek OLE, bingkai media, bingkai zoom, tabel, diagram, dan objek SmartArt dapat merujuk pada gambar. Beberapa tipe bentuk mengekspor gambar melalui objek format bersarang, sehingga pemeriksaan sederhana `get_PictureFormat()` atau `get_FillFormat()` pada bentuk tidak selalu cukup.

**Apakah saya dapat mengekstrak thumbnail yang ditampilkan untuk bingkai video?**

Ya. Gunakan [IVideoFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` dan baca `get_PictureFormat()->get_Picture()->get_Image()` . Ini mengekstrak gambar poster yang disimpan bersama bingkai video, bukan frame yang dihasilkan dari berkas video.

**Bagaimana saya dapat menentukan bentuk mana yang menggunakan gambar tertentu dari koleksi gambar presentasi?**

Aspose.Slides tidak menyimpan tautan terbalik dari [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) ke bentuk. Bangun pemetaan selama penelusuran: setiap kali Anda menemukan referensi gambar, catat nomor slide, jalur bentuk, dan hash atau item koleksi gambar.

**Apakah saya dapat mengekstrak gambar yang tertanam di dalam objek OLE, seperti dokumen terlampir?**

Anda dapat mengekstrak pratinjau slide objek OLE dari [IOleObjectFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` . Namun, pratinjau tersebut bukan dokumen yang tertanam itu sendiri. Untuk mengekstrak gambar dari dalam berkas tertanam, ekstrak data OLE dan periksa dengan alat yang sesuai untuk tipe berkas tersebut.