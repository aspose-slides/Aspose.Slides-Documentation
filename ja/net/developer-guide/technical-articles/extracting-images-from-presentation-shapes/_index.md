---
title: .NET でプレゼンテーション形状から画像を抽出
linktitle: 形状からの画像
type: docs
weight: 90
url: /ja/net/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションの形状から画像を抽出する、迅速でコードに優しいソリューションです。"
---
## **概要**

プレゼンテーション内の画像は、さまざまな形状タイプで表示される可能性があります。普通の画像フレーム、形状に適用された画像塗りつぶし、OLE オブジェクトのプレビュー画像、ビデオまたはオーディオ フレームのサムネイル、ズーム画像、またはテーブル、チャート、SmartArt 形状に入れ子になった画像などです。Aspose.Slides はこれらの画像をプレゼンテーションの画像コレクションに保存し、[ImageCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/imagecollection/) と [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) オブジェクトで公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートしたいだけの場合は、`presentation.Images` を反復処理します。本稿では別のタスクに焦点を当てます。スライド上で画像が使用されている形状を走査し、保存されたファイルにスライド番号、形状の位置、ソースタイプ（画像フレーム、塗りつぶし画像、メディアプレビュー、OLE プレビュー、またはズーム画像）などの有用なコンテキストを保持できるようにします。

{{% alert title="Tip" color="info" %}}
元のエンコードされた画像データとファイルタイプを保持するには、[IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を使用します。出力を PNG などの特定の形式に正規化したい場合は、[IPPImage.Image](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) と [IImage.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) を使用します。
{{% /alert %}}

## **共通ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保ちます。`SaveOriginalImage` は元の埋め込みバイトを書き込み、MIME タイプから安全な拡張子を選択し、SHA-256 ハッシュで重複する画像バイナリをスキップします。

```c#
using Aspose.Slides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

private static bool SaveOriginalImage(
    IPPImage image,
    string outputDirectory,
    string fileNameBase,
    ISet<string> savedImageHashes)
{
    byte[] imageData = image.BinaryData;
    string imageHash = GetSha256Hash(imageData);
    if (!savedImageHashes.Add(imageHash))
    {
        return false;
    }

    string extension = GetExtensionFromContentType(image.ContentType);
    string fileName = $"{fileNameBase}.{extension}";
    string outputPath = Path.Combine(outputDirectory, fileName);
    File.WriteAllBytes(outputPath, imageData);
    return true;
}

private static void SaveImageAsPng(IPPImage image, string outputDirectory, string fileNameBase)
{
    string fileName = $"{fileNameBase}.png";
    string outputPath = Path.Combine(outputDirectory, fileName);

    using (IImage outputImage = image.Image)
    {
        outputImage.Save(outputPath, ImageFormat.Png);
    }
}

private static IPPImage GetPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.FillType != FillType.Picture)
    {
        return null;
    }

    return fillFormat.PictureFillFormat.Picture.Image;
}

private static IEnumerable<(IShape Shape, string NamePart)> EnumerateShapes(
    IShapeCollection shapes,
    string prefix,
    bool includeGroupedShapes)
{
    int shapeCount = shapes.Count;
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes[shapeIndex];
        int displayIndex = shapeIndex + 1;
        string shapeNamePart = $"{prefix}_shape_{displayIndex}";
        yield return (shape, shapeNamePart);

        if (includeGroupedShapes && shape is IGroupShape groupShape)
        {
            foreach ((IShape Shape, string NamePart) childShape in EnumerateShapes(
                groupShape.Shapes,
                shapeNamePart,
                includeGroupedShapes))
            {
                yield return childShape;
            }
        }
    }
}

private static string GetSha256Hash(byte[] data)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hash = sha256.ComputeHash(data);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}

private static string GetExtensionFromContentType(string contentType)
{
    if (string.IsNullOrWhiteSpace(contentType))
    {
        return "bin";
    }

    string mediaType = contentType.Split(';')[0].Trim().ToLowerInvariant();
    switch (mediaType)
    {
        case "image/jpeg":
            return "jpg";
        case "image/png":
            return "png";
        case "image/gif":
            return "gif";
        case "image/bmp":
            return "bmp";
        case "image/tiff":
            return "tiff";
        case "image/x-emf":
        case "image/emf":
            return "emf";
        case "image/x-wmf":
        case "image/wmf":
            return "wmf";
        case "image/svg+xml":
            return "svg";
        default:
            if (mediaType.StartsWith("image/"))
            {
                string extension = mediaType.Substring("image/".Length);
                return MakeSafeFileNamePart(extension);
            }

            return "bin";
    }
}

private static string MakeSafeFileNamePart(string value)
{
    foreach (char invalidCharacter in Path.GetInvalidFileNameChars())
    {
        value = value.Replace(invalidCharacter, '_');
    }

    return value;
}
```

## **画像フレームから画像を抽出**

単体オブジェクトとして挿入された画像にこのアプローチを使用します。[IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/) は `PictureFormat.Picture.Image` に画像を格納し、[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) オブジェクトを返します。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "extracted-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }
        }
    }
}
```

## **画像で塗りつぶされた形状から画像を抽出**

形状は画像を塗りつぶしとして使用できます。まず形状の塗りつぶしタイプを確認してください: それが[FillType.Picture](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/)でない場合、その塗りつぶしから抽出できる画像はありません。以下の例は[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/)オブジェクトを処理し、[IPPImage.Image](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を使用して各画像を PNG として保存します。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "shape-fill-images");
Directory.CreateDirectory(outputDirectory);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveImageAsPng(image, outputDirectory, item.NamePart);
                }
            }
        }
    }
}
```

## **OLE オブジェクトフレームからプレビュー画像を抽出**

[IOleObjectFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ioleobjectframe/) には、PowerPoint がスライド上のオブジェクトのプレビューとして使用する代替画像が設定されている場合があります。この画像は `SubstitutePictureFormat.Picture.Image` から取得できます。この画像を抽出すると、プレビュー画像が得られ、埋め込まれた OLE パッケージの内容は取得できません。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "ole-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **ビデオフレームからプレビュー画像を抽出**

[IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) も `PictureFormat.Picture.Image` にプレビュー画像を格納できます。これはスライド上に表示されるポスターまたはサムネイルであり、ビデオストリームからデコードされたフレームではありません。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "video-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **オーディオフレームからプレビュー画像を抽出**

[IAudioFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iaudioframe/) は `PictureFormat.Picture.Image` にサムネイルを格納できます。これはスライド上のオーディオオブジェクトに表示される画像です。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "audio-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **ズームオブジェクトから画像を抽出**

[IZoomFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/izoomframe/) と [ISectionZoomFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/isectionzoomframe/) 形状はカスタム画像を使用できます。ズームフレームから `ZoomImage` を取得してください。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IZoomFrame zoomFrame && zoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_zoom";
                SaveOriginalImage(zoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

            if (item.Shape is ISectionZoomFrame sectionZoomFrame && sectionZoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_section_zoom";
                SaveOriginalImage(sectionZoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

        }
    }
}
```

## **サマリーズームフレームから画像を抽出**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/isummaryzoomframe/) も形状です。そのセクション項目はカスタム画像を使用でき、各サマリーズームセクションの `ZoomImage` プロパティで取得できます。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "summary-zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is ISummaryZoomFrame summaryZoomFrame)
            {
                int sectionCount = summaryZoomFrame.SummaryZoomCollection.Count;
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.SummaryZoomCollection[sectionIndex];
                    if (section.ZoomImage != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        string fileNameBase = $"{item.NamePart}_summary_zoom_{displayIndex}";
                        SaveOriginalImage(section.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
```

## **テーブル形状から画像を抽出**

[ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) は形状です。テーブル内の画像は通常、テーブルセルの画像塗りつぶしとして格納されています。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "table-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is ITable table)
            {
                int rowCount = table.Rows.Count;
                int columnCount = table.Columns.Count;
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table[columnIndex, rowIndex];
                        IPPImage image = GetPictureFillImage(cell.CellFormat.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_cell_{rowIndex + 1}_{columnIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **チャート形状から画像を抽出**

[IChart](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/) は形状です。以下の例はチャート領域の画像塗りつぶしから画像を抽出します。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "chart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.Charts.IChart chart)
            {
                IFillFormat fillFormat = chart.FillFormat;
                IPPImage image = GetPictureFillImage(fillFormat);
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_chart_area";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **SmartArt 形状から画像を抽出**

[ISmartArt](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/ismartart/) オブジェクトは形状です。SmartArt のレイアウトに応じて、画像はノードの箇条書き塗りつぶしまたはノード形状の塗りつぶし形式に格納されている場合があります。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "smartart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
            {
                int nodeCount = smartArt.AllNodes.Count;
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[nodeIndex];
                    IPPImage bulletImage = GetPictureFillImage(node.BulletFillFormat);
                    if (bulletImage != null)
                    {
                        string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_bullet";
                        SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.Shapes.Count;
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        var nodeShape = node.Shapes[nodeShapeIndex];
                        IPPImage image = GetPictureFillImage(nodeShape.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_shape_{nodeShapeIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **グループ化された形状内の画像を含める**

グループ化された形状は独自の形状コレクションを持ちます。共有ヘルパー `EnumerateShapes` には `includeGroupedShapes` オプションがあります。 [IGroupShape](https://reference.aspose.com/slides/ja/net/aspose.slides/igroupshape/) オブジェクト内の形状を調べたい場合は、これを `true` に設定してください。以下の例は画像フレーム、画像で塗りつぶされた形状、OLE オブジェクトプレビュー、ビデオフレームサムネイル、オーディオフレームサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズーム画像も含めるには、前節の専門的な抽出ロジックを再利用し、同じ再帰的形状走査を維持してください。

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "all-shape-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                continue;
            }

            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **エッジケースと実用的な注意点**

- **重複画像:** 複数の形状が同じ画像を参照したり、バイトが同一の別々の画像を参照したりすることがあります。ユニークな画像ごとに1つの出力ファイルにしたい場合は、ファイルを書き込む前に[IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) のハッシュを取得してください。
- **元データと変換出力:** [IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を保存すると、埋め込まれた JPEG、PNG、GIF、SVG、EMF、WMF データが保持されます。[IPPImage.Image](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を [IImage.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) を介して保存すると、出力形式を統一したい場合に便利です。
- **サポートされていない塗りつぶしタイプ:** ソリッド、グラデーション、パターン、無塗りつぶしの形状には画像塗りつぶしが含まれません。`PictureFillFormat` を読み取る前に[FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) を確認してください。
- **グループ化された形状:** スライドの上位レベル形状コレクションはグループをフラット化しません。グループ化されたコンテンツが重要な場合は、[IGroupShape.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides/igroupshape/) を再帰的に調べてください。
- **OLE オブジェクトプレビュー:** [IOleObjectFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ioleobjectframe/) は `SubstitutePictureFormat` を通じてプレビュー画像を提供する場合がありますが、その画像はスライドのプレビューであり、OLE オブジェクト内の埋め込まれたファイルではありません。
- **ビデオフレームサムネイル:** [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) は `PictureFormat` を通じてプレビュー画像を提供する場合がありますが、その画像はスライド上に表示されるポスターであり、ビデオストリームから抽出されたものではありません。
- **オーディオフレームサムネイル:** [IAudioFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iaudioframe/) は `PictureFormat` を通じてアイコンまたはサムネイルを提供する場合がありますが、埋め込まれたオーディオデータではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズーム形状は、`ZoomImage` を介してカスタム [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) オブジェクトを使用できる場合があります。
- **入れ子になった形状モデル:** テーブル、チャート、SmartArt オブジェクトは[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) を実装していますが、その画像はしばしば入れ子になったテーブルセル、チャート要素、または SmartArt ノードの書式設定オブジェクトに格納されています。
- **切り抜きまたは変形された画像:** [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) にアクセスすると格納された画像リソースが取得できますが、形状が適用した切り抜き、透明度、再色付け、回転、その他の視覚効果は反映されません。

## **FAQ**

### 画像を切り抜きやエフェクト、形状変換なしで元のまま抽出できますか？

はい。[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) オブジェクトにアクセスし、[IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) をディスクに書き込んでください。これにより、プレゼンテーションに保存されている元のエンコード画像が保持され、スライド上でのレンダリング方法は反映されません。

### 抽出したすべての画像を PNG としてエクスポートできますか？

はい。[IPPImage.Image](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を使用して [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) オブジェクトを取得し、[IImage.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) に [ImageFormat.Png](https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/) を指定して呼び出します。これにより出力が変換され、元のファイルタイプやベクターデータは保持されない可能性があります。

### 同じ画像を複数回保存しないようにするには？

[IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) のハッシュを使用し、ハッシュの集合で管理してください。新しい画像のハッシュが既に存在する場合は、保存をスキップするか、既存の出力ファイルへの別の参照として記録します。

### なぜ一部の形状から画像が取得できないのですか？

画像フレーム、画像で塗りつぶされた形状、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できます。形状タイプによっては、画像が入れ子になった書式設定オブジェクトを通じて公開されるため、単純な `PictureFormat` や形状の `FillFormat` のチェックだけでは不十分な場合があります。

### ビデオフレームに表示されるサムネイルを抽出できますか？

はい。[IVideoFrame.PictureFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) を使用し、`PictureFormat.Picture.Image` を読み取ります。これによりビデオフレームに保存されたポスター画像が抽出され、ビデオファイルから生成されたフレームではありません。

### プレゼンテーションの画像コレクション内の特定の画像を使用している形状を特定するには？

Aspose.Slides は [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) から形状への逆リンクを保持していません。走査中にマッピングを作成してください。画像参照を見つけたら、スライド番号、形状パス、および画像ハッシュまたはコレクション項目を記録します。

### OLE オブジェクト内に埋め込まれた画像（添付ドキュメントなど）を抽出できますか？

[IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ioleobjectframe/) から OLE オブジェクトのスライドプレビューは抽出できますが、そのプレビューは埋め込まれたドキュメントそのものではありません。埋め込まれたファイル内の画像を抽出するには、OLE データを抽出し、該当ファイルタイプ用のツールで確認してください。