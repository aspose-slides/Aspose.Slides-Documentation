---
title: C++ でプレゼンテーション形状から画像を抽出
linktitle: 形状からの画像
type: docs
weight: 90
url: /ja/cpp/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーション内の形状から画像を抽出します。迅速でコードに優しいソリューションです。"
---
## **概要**

プレゼンテーションの画像は、通常の画像フレーム、図形に適用された画像塗りつぶし、OLE オブジェクトのプレビュー画像、動画や音声フレームのサムネイル、ズーム画像、またはテーブル、チャート、SmartArt 図形内にネストされた画像など、さまざまな形状タイプで表示されます。Aspose.Slides はこれらの画像をプレゼンテーションの画像コレクションに保存し、[IImageCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimagecollection/) と [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) オブジェクトで公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートしたいだけの場合は、`presentation->get_Images()` を反復処理します。本記事は別のタスクに焦点を当てています。すなわち、スライド上で画像が使用されている場所を形状を走査して特定し、保存したファイルにスライド番号、形状の位置、ソースタイプ（画像フレーム、塗りつぶし画像、メディアプレビュー、OLE プレビュー、またはズーム画像）などの有用なコンテキストを保持できるようにすることです。

{{% alert title="Tip" color="primary" %}}
元のエンコードされた画像データとファイルタイプを保持するには、[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/)::`get_BinaryData()` を使用します。PNG などの特定のフォーマットに出力を正規化したい場合は、[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/)::`get_Image()` を [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/)::`Save` と組み合わせて使用します。
{{% /alert %}}

## **共通ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保ちます。`SaveOriginalImage` は元の埋め込みバイトを書き込み、MIME タイプから安全な拡張子を選択し、SHA-256 ハッシュに基づいて重複する画像バイナリをスキップします。

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

## **画像フレームから画像を抽出**

単体オブジェクトとして挿入された画像に対してこの方法を使用します。[IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) はその画像を `get_PictureFormat()->get_Picture()->get_Image()` で保持し、[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) オブジェクトを返します。

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

## **画像で塗りつぶされた形状から画像を抽出**

形状は塗りつぶしに画像を使用できます。まず形状の塗りつぶしタイプを確認してください。もし [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/)::`Picture` でなければ、塗りつぶしから抽出できる画像はありません。以下の例は [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) オブジェクトを処理し、[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/)::`get_Image()` を使用して各画像を PNG として保存します。

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

## **OLE オブジェクトフレームからプレビュー画像を抽出**

[IOleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ioleobjectframe/) には、PowerPoint がスライド上でオブジェクトのプレビューとして使用する代替画像が設定されている場合があります。この画像は `get_SubstitutePictureFormat()->get_Picture()->get_Image()` で取得できます。この画像を抽出すると、埋め込まれた OLE パッケージの内容ではなく、プレビュー画像が得られます。

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

## **ビデオフレームからプレビュー画像を抽出**

[IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/) も `get_PictureFormat()->get_Picture()->get_Image()` でプレビュー画像を保持できます。これはスライドに表示されるポスターまたはサムネイルであり、ビデオストリームからデコードされたフレームではありません。

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

## **オーディオフレームからプレビュー画像を抽出**

[IAudioFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iaudioframe/) は `get_PictureFormat()->get_Picture()->get_Image()` でサムネイルを保持できます。これはスライド上のオーディオオブジェクトに表示される画像です。

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

## **ズームオブジェクトから画像を抽出**

[IZoomFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/izoomframe/) と [ISectionZoomFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isectionzoomframe/) の形状はカスタム画像を使用できます。ズームフレームから `get_ZoomImage()` を取得してください。

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

## **サマリーズームフレームから画像を抽出**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isummaryzoomframe/) も形状の一種です。そのセクション項目はカスタム画像を使用でき、各サマリーズームセクションの `get_ZoomImage()` メソッドで取得できます。

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

## **テーブル形状から画像を抽出**

[ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) は形状です。テーブル内の画像は通常、セルの画像塗りつぶしとして保存されます。

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

## **チャート形状から画像を抽出**

[IChart](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichart/) は形状です。以下の例はチャート領域の画像塗りつぶしから画像を抽出します。

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

## **SmartArt 形状から画像を抽出**

[ISmartArt](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/ismartart/) オブジェクトは形状です。SmartArt のレイアウトによっては、画像がノードの箇条書き塗りつぶしやノード形状の塗りつぶし形式に保存されていることがあります。

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

## **グループ化された形状内の画像を含める**

グループ化された形状は独自の形状コレクションを持ちます。共有ヘルパー `EnumerateShapes` には `includeGroupedShapes` オプションがあります。 [IGroupShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igroupshape/) オブジェクト内の形状を調べたい場合は、このオプションを `true` に設定してください。以下の例は画像フレーム、画像で塗りつぶされた形状、OLE オブジェクトのプレビュー、ビデオフレームのサムネイル、オーディオフレームのサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズームの画像も含めるには、前述のセクションの専用抽出ロジックを再利用し、同じ再帰的形状走査を維持してください。

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

## **エッジケースと実用的な注意点**

- **重複画像:** 複数の形状が同じ画像を参照する場合や、バイトが同一の別画像がある場合があります。ユニークな画像ごとに 1 つの出力ファイルにしたい場合は、書き込む前に [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/)::`get_BinaryData()` のハッシュを取得してください。
- **元データと変換出力:** [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/)::`get_BinaryData()` を保存すると、埋め込まれた JPEG、PNG、GIF、SVG、EMF、WMF データが保持されます。[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/)::`Save` を介して [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/)::`get_Image()` を保存すると、PNG などの一貫した出力フォーマットに正規化できます。
- **サポートされていない塗りつぶしタイプ:** 単色、グラデーション、パターン、塗りつぶしなしの形状は画像塗りつぶしを持ちません。`get_PictureFillFormat()` を読む前に [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を確認してください。
- **グループ化された形状:** スライドの最上位形状コレクションはグループをフラット化しません。グループ化されたコンテンツが重要な場合は、[IGroupShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/igroupshape/)::`get_Shapes()` を再帰的に調べてください。
- **OLE オブジェクトのプレビュー:** [IOleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ioleobjectframe/) は `get_SubstitutePictureFormat()` を通じてプレビュー画像を提供することがありますが、これはスライドのプレビュー画像であり、OLE オブジェクト内に埋め込まれたファイルではありません。
- **ビデオフレームのサムネイル:** [IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/) は `get_PictureFormat()` を通じてプレビュー画像を提供することがありますが、これはスライドに表示されるポスター画像であり、ビデオストリームから抽出されたものではありません。
- **オーディオフレームのサムネイル:** [IAudioFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iaudioframe/) は `get_PictureFormat()` を通じてアイコンやサムネイルを提供することがありますが、これは埋め込まれた音声データではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズームの形状は、`get_ZoomImage()` を介してカスタム [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) オブジェクトを使用することがあります。
- **ネストされた形状モデル:** テーブル、チャート、SmartArt オブジェクトは [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) を実装していますが、画像はしばしばテーブルセル、チャート要素、または SmartArt ノードのフォーマットオブジェクト内にネストされています。
- **切り抜きまたは変形された画像:** [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) にアクセスすると、保存された画像リソースが取得できますが、形状が適用した切り抜き、透過、再着色、回転、その他の視覚効果は反映されません。

## **FAQ**

**画像を切り抜きやエフェクト、形状変換なしで元のまま抽出できますか？**

はい。[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) オブジェクトにアクセスし、[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/)::`get_BinaryData()` をディスクに書き込んでください。これにより、プレゼンテーションに保存された元のエンコード画像が保持され、スライド上でのレンダリング方法は反映されません。

**抽出したすべての画像を PNG としてエクスポートできますか？**

はい。[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/)::`get_Image()` を使用して [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) オブジェクトを取得し、[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/)::`Save` に [ImageFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imageformat/)::`Png` を指定して呼び出してください。これにより出力が PNG に変換されますが、元のファイルタイプやベクターデータは保持されない場合があります。

**同じ画像を複数回保存しないようにするにはどうすればよいですか？**

[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/)::`get_BinaryData()` のハッシュを使用し、ハッシュセットで管理します。新しい画像のハッシュが既に存在する場合は、保存をスキップするか、既存の出力ファイルへの別の参照を記録してください。

**なぜ一部の形状から画像が取得できないのですか？**

画像フレーム、画像で塗りつぶされた形状、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できます。一部の形状タイプはネストされたフォーマットオブジェクトを通じて画像を公開するため、単純な `get_PictureFormat()` や形状の `get_FillFormat()` のチェックだけでは不十分なことがあります。

**ビデオフレームのサムネイル画像を抽出できますか？**

はい。[IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` を使用し、`get_PictureFormat()->get_Picture()->get_Image()` を読み取ります。これにより、ビデオフレームに保存されたポスター画像が抽出され、ビデオファイルから生成されたフレームではありません。

**プレゼンテーションの画像コレクション内の特定の画像を使用している形状をどのように特定できますか？**

Aspose.Slides は [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) から形状への逆リンクを保持していません。走査中にマッピングを作成してください。画像参照が見つかったら、スライド番号、形状パス、および画像のハッシュまたはコレクション項目を記録します。

**添付文書など、OLE オブジェクト内に埋め込まれた画像を抽出できますか？**

[IOleObjectFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` から OLE オブジェクトのスライドプレビューは抽出できますが、これは埋め込まれた文書そのものではありません。埋め込まれたファイル内の画像を抽出するには、OLE データを抽出し、該当ファイルタイプ用のツールで解析してください。