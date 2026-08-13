---
title: C++ でプレゼンテーション形状から画像を抽出
linktitle: 形状からの画像
type: docs
weight: 90
url: /ja/cpp/extracting-images-from-presentation-shapes/
keywords:
- 画像を抽出
- 画像を取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションの形状から画像を抽出します。高速でコードフレンドリーなソリューションです。"
---
## **概要**

プレゼンテーション内の画像は、さまざまな形状タイプで表示されます。通常の画像枠、形状に適用された画像塗り、OLE オブジェクトのプレビュー画像、ビデオまたはオーディオ フレームのサムネイル、ズーム画像、またはテーブル、チャート、SmartArt 形状に入れ子になった画像などです。Aspose.Slides はこれらの画像をプレゼンテーションの画像コレクションに格納し、[IImageCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimagecollection/) および [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) オブジェクトで公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートしたいだけの場合は、`presentation->get_Images()` を反復処理します。本記事では別のタスクに焦点を当てます。形状を走査してスライドで画像が使用されている場所を特定し、保存したファイルにスライド番号、形状の位置、ソースタイプ（画像枠、塗り画像、メディアプレビュー、OLE プレビュー、またはズーム画像）といった有用なコンテキストを保持できるようにします。

{{% alert title="Tip" color="info" %}}
元のエンコードされた画像データとファイルタイプを保持するには、[IPPImage]::`get_BinaryData()` を使用します。出力を PNG などの特定の形式に正規化したい場合は、[IPPImage]::`get_Image()` と [IImage]::`Save` を使用します。
{{% /alert %}}

## **共有ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保ちます。`SaveOriginalImage` は元の埋め込みバイトを書き込み、MIME タイプから安全な拡張子を選択し、SHA-256 ハッシュにより重複する画像バイナリをスキップします。

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

## **画像フレームから画像を抽出**

単独オブジェクトとして挿入された画像にこのアプローチを使用します。[IPictureFrame] は `get_PictureFormat()->get_Picture()->get_Image()` で画像を保持し、[IPPImage] オブジェクトを返します。

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

## **画像で塗りつぶされた形状から画像を抽出**

形状は画像を塗りとして使用できます。まず形状の塗りタイプを確認します。[FillType]::`Picture` でない場合、その塗りから抽出できる画像はありません。以下の例は [IAutoShape] オブジェクトを処理し、各画像を [IPPImage]::`get_Image()` を介して PNG として保存します。

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

## **OLE オブジェクトフレームからプレビュー画像を抽出**

[IOleObjectFrame] には、PowerPoint がスライド上でオブジェクトのプレビューとして使用する代替画像が設定されている場合があります。この画像は `get_SubstitutePictureFormat()->get_Picture()->get_Image()` で取得できます。この画像を抽出すると、埋め込まれた OLE パッケージの内容ではなく、プレビュー画像が得られます。

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

## **ビデオフレームからプレビュー画像を抽出**

[IVideoFrame] も `get_PictureFormat()->get_Picture()->get_Image()` にプレビュー画像を保持できます。これはスライド上に表示されるポスターまたはサムネイルであり、ビデオストリームからデコードされたフレームではありません。

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

## **オーディオフレームからプレビュー画像を抽出**

[IAudioFrame] は `get_PictureFormat()->get_Picture()->get_Image()` にサムネイルを保持できます。これはスライド上のオーディオオブジェクトに表示される画像です。

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

## **ズームオブジェクトから画像を抽出**

[IZoomFrame] と [ISectionZoomFrame] 形状はカスタム画像を使用できます。ズームフレームから `get_ZoomImage()` を取得します。

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

## **サマリーズームフレームから画像を抽出**

[ISummaryZoomFrame] も形状です。そのセクション項目はカスタム画像を使用でき、各サマリーズームセクションの `get_ZoomImage()` メソッドで取得できます。

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

## **テーブル形状から画像を抽出**

[ITable] は形状です。テーブル内の画像は通常、セルの画像塗りとして保存されています。

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

## **チャート形状から画像を抽出**

[IChart] は形状です。以下の例はチャート領域の画像塗りから画像を抽出します。

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

## **SmartArt 形状から画像を抽出**

[ISmartArt] オブジェクトは形状です。SmartArt のレイアウトによっては、画像がノードの箇条書き塗りに保存されたり、ノード形状の塗り形式に保存されたりします。

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

## **グループ化された形状内の画像を含める**

グループ化された形状は独自の形状コレクションを持ちます。共有ヘルパー `EnumerateShapes` には `includeGroupedShapes` オプションがあります。[IGroupShape] オブジェクト内の形状を検査したい場合は `true` に設定します。以下の例は画像フレーム、画像で塗りつぶされた形状、OLE オブジェクトプレビュー、ビデオフレームサムネイル、オーディオフレームサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズーム画像も含めるには、前のセクションの専用抽出ロジックを再利用し、同じ再帰的形状走査を維持してください。

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

## **エッジケースと実務上の注意点**

- **重複画像:** 複数の形状が同じ画像を参照するか、バイトが同一の別々の画像を参照することがあります。一意の画像ごとに1つの出力ファイルにしたい場合は、ファイルを書き出す前に [IPPImage]::`get_BinaryData()` のハッシュを取ります。
- **元データと変換後出力の違い:** [IPPImage]::`get_BinaryData()` を保存すると、埋め込まれた JPEG、PNG、GIF、SVG、EMF、WMF データが保持されます。[IPPImage]::`get_Image()` を [IImage]::`Save` で保存すると、一定の出力形式に統一したい場合に便利です。
- **未対応の塗りタイプ:** 単色、グラデーション、パターン、無塗りの形状は画像塗りを持ちません。[FillType] を確認してから `get_PictureFillFormat()` を読むようにしてください。
- **グループ化された形状:** スライドのトップレベル形状コレクションはグループを平坦化しません。グループ化されたコンテンツが重要な場合は、[IGroupShape]::`get_Shapes()` を再帰的に検査してください。
- **OLE オブジェクトのプレビュー:** [IOleObjectFrame] は `get_SubstitutePictureFormat()` でプレビュー画像を提供することがありますが、その画像はスライド上のプレビューであり、OLE オブジェクト内に埋め込まれたファイルではありません。
- **ビデオフレームのサムネイル:** [IVideoFrame] は `get_PictureFormat()` でプレビュー画像を提供することがありますが、その画像はスライド上に表示されるポスターであり、ビデオストリームから抽出されたものではありません。
- **オーディオフレームのサムネイル:** [IAudioFrame] は `get_PictureFormat()` でアイコンやサムネイルを提供することがありますが、これは埋め込まれたオーディオデータではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズーム形状は `get_ZoomImage()` を介してカスタム [IPPImage] オブジェクトを使用することがあります。
- **入れ子形状モデル:** テーブル、チャート、SmartArt オブジェクトは [IShape] を実装しますが、画像はしばしば入れ子になったテーブルセル、チャート要素、または SmartArt ノードの書式設定オブジェクトに保存されています。
- **切り抜きまたは変形された画像:** [IPPImage] にアクセスすると保存された画像リソースが得られますが、形状が適用した切り抜き、透明度、再着色、回転、その他の視覚効果は反映されません。

## **FAQ**

### 元の画像を切り抜きやエフェクト、形状変換なしで抽出できますか？

はい。[IPPImage] オブジェクトにアクセスし、[IPPImage]::`get_BinaryData()` をディスクに書き込んでください。これにより、プレゼンテーションに保存された元のエンコード画像が保持され、スライド上での画像の描画方法は反映されません。

### 抽出したすべての画像を PNG としてエクスポートできますか？

はい。[IPPImage]::`get_Image()` で [IImage] オブジェクトを取得し、[IImage]::`Save` に [ImageFormat]::`Png` を指定してください。これにより出力が変換され、元のファイルタイプやベクターデータが保持されない可能性があります。

### 同じ画像を複数回保存しないようにするには？

[IPPImage]::`get_BinaryData()` のハッシュを使用し、ハッシュを集合に保存します。新しい画像のハッシュが既に存在する場合は、保存をスキップするか、既存の出力ファイルへの別の参照として記録してください。

### なぜ一部の形状から画像が取得できないのですか？

画像枠、画像で塗りつぶされた形状、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できます。一部の形状タイプは入れ子の書式設定オブジェクトを通じて画像を公開するため、単純な `get_PictureFormat()` や形状の `get_FillFormat()` のチェックだけでは不十分なことがあります。

### ビデオフレームに表示されるサムネイルを抽出できますか？

はい。[IVideoFrame]::`get_PictureFormat()` を使用し、`get_PictureFormat()->get_Picture()->get_Image()` を読み取ります。これによりビデオフレームに保存されたポスター画像が抽出され、ビデオファイルから生成されたフレームではありません。

### プレゼンテーションの画像コレクション内の特定の画像を使用している形状をどうやって判別できますか？

Aspose.Slides は [IPPImage] から形状への逆リンクを保持していません。走査中にマッピングを作成してください。画像参照を見つけたら、スライド番号、形状パス、画像ハッシュまたはコレクション項目を記録します。

### 添付ドキュメントなど、OLE オブジェクトに埋め込まれた画像を抽出できますか？

[IOleObjectFrame]::`get_SubstitutePictureFormat()` で OLE オブジェクトのスライドプレビューを抽出できます。ただし、そのプレビューは埋め込まれたドキュメント自体ではありません。埋め込まれたファイル内の画像を抽出するには、OLE データを取り出し、そのファイルタイプに対応したツールで検査してください。