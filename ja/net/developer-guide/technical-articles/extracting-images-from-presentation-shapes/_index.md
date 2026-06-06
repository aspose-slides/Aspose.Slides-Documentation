---
title: .NET でプレゼンテーション シェイプから画像を抽出
linktitle: シェイプからの画像
type: docs
weight: 90
url: /ja/net/extracting-images-from-presentation-shapes/
keywords:
- 画像の抽出
- 画像の取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーション内のシェイプから画像を抽出します - 迅速でコードに優しいソリューション。"
---
## **概要**

プレゼンテーション内の画像は、さまざまなシェイプタイプで表示されます：普通の画像フレーム、シェイプに適用された画像塗りつぶし、OLE オブジェクトのプレビュー画像、ビデオまたはオーディオフレームのサムネイル、ズーム画像、またはテーブル、チャート、SmartArt シェイプ内にネストされた画像などです。Aspose.Slides はこれらの画像をプレゼンテーションの画像コレクションに保存し、[ImageCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/imagecollection/) と [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) オブジェクトで公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートしたいだけの場合は `presentation.Images` を列挙してください。本記事は別のタスクに焦点を当てています：スライド上で画像が使用されている場所をシェイプをたどって検出し、保存したファイルにスライド番号、シェイプの位置、ソースタイプ（画像フレーム、塗りつぶし画像、メディアプレビュー、OLE プレビュー、ズーム画像）といった有用なコンテキストを保持できるようにします。

{{% alert title="Tip" color="primary" %}}
[IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を使用すると、元のエンコード画像データとファイルタイプを保持できます。特定の形式（例: PNG）に出力を正規化したい場合は、[IPPImage.Image](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) と [IImage.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) を使用してください。{{% /alert %}}

## **共有ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保ちます。`SaveOriginalImage` は元の埋め込みバイトを書き込み、MIME タイプから安全な拡張子を選択し、SHA-256 ハッシュで重複画像バイナリをスキップします。

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

単体オブジェクトとして挿入された画像にこのアプローチを使用します。[IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/) は画像を `PictureFormat.Picture.Image` に保持し、[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) オブジェクトを返します。

```c#
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

## **画像で塗りつぶされたシェイプから画像を抽出**

シェイプは画像で塗りつぶすことができます。まずシェイプの塗りつぶしタイプを確認してください：`FillType.Picture` でない場合、その塗りつぶしから抽出できる画像はありません。以下の例は [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) オブジェクトを対象にし、各画像を PNG として [IPPImage.Image](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を介して保存します。

```c#
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

[IOleObjectFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ioleobjectframe/) は、PowerPoint がスライド上のオブジェクトのプレビューとして使用する代替画像を持つことがあります。この画像は `SubstitutePictureFormat.Picture.Image` から取得できます。抽出されるのはプレビュー画像であり、埋め込まれた OLE パッケージの内容ではありません。

```c#
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

[IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) も `PictureFormat.Picture.Image` にプレビュー画像を保持できます。これはスライド上に表示されるポスターまたはサムネイルであり、ビデオストリームからデコードされたフレームではありません。

```c#
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

[IAudioFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iaudioframe/) は `PictureFormat.Picture.Image` にサムネイルを保持できます。これはスライド上のオーディオオブジェクトに表示される画像です。

```c#
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

[IZoomFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/izoomframe/) と [ISectionZoomFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/isectionzoomframe/) シェイプはカスタム画像を使用できます。ズームフレームの `ZoomImage` を読み取ります。

```c#
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

[ISummaryZoomFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/isummaryzoomframe/) もシェイプです。そのセクション項目はカスタム画像を使用でき、各サマリーズームセクションの `ZoomImage` プロパティで取得できます。

```c#
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

## **テーブルシェイプから画像を抽出**

[ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) はシェイプです。テーブル内の画像は通常、セルの画像塗りつぶしとして保存されています。

```c#
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

## **チャートシェイプから画像を抽出**

[IChart](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/) はシェイプです。以下の例はチャート領域の画像塗りつぶしから画像を抽出します。

```c#
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

## **SmartArt シェイプから画像を抽出**

[ISmartArt](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/ismartart/) オブジェクトはシェイプです。SmartArt のレイアウトによっては、画像がノードの箇条書き塗りつぶしやノードシェイプの塗りつぶしフォーマットに格納されます。

```c#
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

## **グループ化シェイプ内の画像を含める**

グループ化シェイプは独自のシェイプコレクションを保持します。共有 `EnumerateShapes` ヘルパーには `includeGroupedShapes` オプションがあります。`IGroupShape` オブジェクト内のシェイプを調査したい場合は `true` に設定してください。以下の例は画像フレーム、画像で塗りつぶされたシェイプ、OLE オブジェクトプレビュー、ビデオフレームサムネイル、オーディオフレームサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズームの画像も含める場合は、前節の専用抽出ロジックを再利用しつつ同じ再帰的シェイプ走査を行ってください。

```c#
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

- **重複画像:** 複数のシェイプが同じ画像を参照したり、バイトが同一の別画像を参照したりすることがあります。ユニークな画像ごとに1つの出力ファイルにしたい場合は、ファイルを書き込む前に [IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) のハッシュを取得してください。
- **元データと変換後出力:** [IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を保存すると埋め込まれた JPEG、PNG、GIF、SVG、EMF、WMF データが保持されます。[IPPImage.Image](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を [IImage.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) で保存すると、出力形式を PNG などに統一できます。
- **サポートされていない塗りつぶしタイプ:** 塗りつぶしがない、単色、グラデーション、パターンのシェイプには画像塗りつぶしが含まれません。`PictureFillFormat` を読む前に [FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) を確認してください。
- **グループ化シェイプ:** 上位スライドのシェイプコレクションはグループをフラット化しません。グループ化された内容が重要な場合は、[IGroupShape.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides/igroupshape/) を再帰的に調べてください。
- **OLE オブジェクトのプレビュー:** [IOleObjectFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ioleobjectframe/) は `SubstitutePictureFormat` を介してプレビュー画像を公開することがありますが、これはスライド上のプレビューであり、OLE オブジェクト内部の埋め込まれたファイルではありません。
- **ビデオフレームのサムネイル:** [IVideoFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) は `PictureFormat` からプレビュー画像を取得できますが、これはスライド上に表示されるポスタ―画像であり、ビデオストリームから抽出されたものではありません。
- **オーディオフレームのサムネイル:** [IAudioFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iaudioframe/) は `PictureFormat` を通じてアイコンやサムネイルを提供しますが、埋め込まれたオーディオデータそのものではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズームのシェイプは `ZoomImage` を介してカスタム [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) オブジェクトを使用できることがあります。
- **ネストされたシェイプモデル:** テーブル、チャート、SmartArt オブジェクトは [IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) を実装していますが、画像はしばしばテーブルセル、チャート要素、SmartArt ノードのフォーマッティングオブジェクトに格納されます。
- **切り抜きまたは変形された画像:** [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) にアクセスすると保存された画像リソースが得られます。シェイプが適用した切り抜き、透明度、色変換、回転、その他の視覚効果は反映されません。

## **FAQ**

**画像を切り抜きやエフェクト、シェイプ変換なしで元のまま抽出できますか？**

はい。 [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) オブジェクトにアクセスし、[IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) をディスクに書き込んでください。これにより、プレゼンテーションに保存されている元のエンコード画像が保持され、スライド上での表示方法は反映されません。

**抽出したすべての画像を PNG 形式でエクスポートできますか？**

はい。 [IPPImage.Image](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) で [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) オブジェクトを取得し、[IImage.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) に [ImageFormat.Png](https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/) を指定して保存してください。これにより出力は PNG に変換され、元のファイルタイプやベクターデータは保持されません。

**同じ画像を複数回保存しないようにするには？**

[IPPImage.BinaryData](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) のハッシュを計算し、ハッシュの集合で管理してください。新しい画像のハッシュが既に存在する場合は保存をスキップするか、既存の出力ファイルへの別の参照として記録します。

**なぜ一部のシェイプから画像が取得できないのですか？**

画像フレーム、画像で塗りつぶされたシェイプ、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できますが、一部のシェイプタイプはネストされたフォーマッティングオブジェクトを通して画像を公開するため、単純な `PictureFormat` やシェイプの `FillFormat` のチェックだけでは検出できないことがあります。

**ビデオフレームに表示されるサムネイルを抽出できますか？**

はい。 [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ivideoframe/) を使用し、`PictureFormat.Picture.Image` を読み取ってください。これによりビデオフレームに格納されたポスター画像が抽出されますが、ビデオファイルから生成されたフレームではありません。

**プレゼンテーション画像コレクション内の特定の画像を使用しているシェイプをどのように特定できますか？**

Aspose.Slides は [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) からシェイプへの逆リンクを保持していません。走査中に画像参照を見つけたら、スライド番号、シェイプのパス、画像のハッシュまたはコレクション項目を記録してマッピングを構築してください。

**OLE オブジェクト内に埋め込まれた画像（添付文書など）を抽出できますか？**

[IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ioleobjectframe/) から OLE オブジェクトのスライドプレビューは抽出できますが、これは埋め込まれたドキュメントそのものではありません。埋め込まれたファイル内部の画像を抽出したい場合は、OLE データを取り出して対象ファイル種別のツールで解析してください。