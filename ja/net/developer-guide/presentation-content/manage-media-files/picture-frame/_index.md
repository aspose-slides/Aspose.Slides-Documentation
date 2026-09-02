---
title: .NET でプレゼンテーションの画像フレームを管理する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/net/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 埋め込み画像
- リンク画像
- 画像の抽出
- ラスタ画像
- SVG 画像
- 画像のトリミング
- トリミング領域の削除
- 画像の圧縮
- StretchOffset
- 画像フレームの書式設定
- 相対スケール
- 画像エフェクト
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、トリミング、抽出、圧縮します。"
---
## **概要**

画像フレームは画像を表示するスライドシェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです。`[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/)` は埋め込み画像リソースをその `[Images](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/images/)` コレクションを通じて所有し、`[IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/)` が画像の位置、サイズ、線の書式設定、回転、トリミング、画像効果、その他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合にこの分離は便利です。画像をプレゼンテーションに一度だけ追加し、返された `[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/)` を保持して、画像フレーム作成時にその画像リソースを使用します。

画像フレームは PNG や JPEG といったラスタ画像や SVG といったベクタ画像を含めることができます。また、画像バイトをプレゼンテーションに格納せずにリンク画像を参照させることも可能です。選択はポータビリティ、ファイルサイズ、抽出、エクスポート動作に影響するため、書式設定や最適化を行う前に画像の保存方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、`[IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addpictureframe/)` で画像フレームを作成します。画像はプレゼンテーションパッケージの一部になるため、プレゼンテーションは別のコンピュータに移動しても自己完結します。

次の例は JPEG 画像を追加し、画像のネイティブ寸法でフレームを作成し、線の書式設定と回転を適用します。

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

画像フレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに保存された元のピクセル寸法は変わりません。この区別は後で画像をトリミングまたは圧縮する際に重要になります。

## **相対スケールの使用**

`[IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/)` はフレームの相対幅・高さスケーリングを公開しています。値 `1.0` は元画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算する代わりに、元画像サイズとの関係を保持したいワークフローで有用です。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像をリサンプルしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内部に保存するため、ポータビリティと予測可能なレンダリングに最も安全です。リンク画像は `[ISlidesPicture](https://reference.aspose.com/slides/ja/net/aspose.slides/islidespicture/)` のリンクパスを介して外部ロケーションを保存し、画像データは埋め込みません。

リンク画像は PPTX 内の画像データ量を減らすことができますが、外部依存性を招きます。リンク先ファイルがアクセス可能である必要があり、パスが変わったりファイルが移動したり、リソースが利用できなくなると、リンク画像は期待通りに表示されません。メールで送信したり、アーカイブしたり、隔離環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例は画像フレームを作成し、ローカル画像ファイルへポイントします。これは画像リンクのみを扱い、ビデオリンクは別のメディアワークフローであり、本例には意図的に混在させていません。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

外部ファイル管理が意図的な場合にリンクを使用してください。単に圧縮の代替として使用しないでください。画像依存性が壊れた小さな PPTX は、より大きな自己完結型プレゼンテーションほど有用ではありません。

## **画像フレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、対象シェイプが実際に `[IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/)` であり、埋め込み画像を含んでいるか確認してください。リンク画像フレームは同様に抽出できるバイトを保持していない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は `[IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/)` を直接使用し、旧来のシステムイメージラッパーは不要です。次の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

`[IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/)` を介した保存は、抽出した画像を要求された出力形式に変換します。プレゼンテーションに格納されたエンコード済みバイトが必要な場合は、画像リソースのバイナリデータを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、`[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/)` が `[ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/)` オブジェクトを公開します。これにより、まず画像をラスタライズせずに SVG データを直接取得できます。

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

SVG コンテンツを SVG のままで保持すると、プレゼンテーション内にベクタソースが保存されます。PNG や JPEG といったラスタエクスポートは、そのベクタコンテンツをピクセルに変換します。PDF や SVG スライドエクスポートも同様のレンダリング操作であるため、エクスポートされたグラフィックを元の埋め込み SVG のバイト単位コピーとして扱わないでください。元のベクタリソースが必要な場合は、埋め込み `[ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/)` データを使用してください。

## **画像のトリミング**

トリミングはフレーム内で画像のどの部分が表示されるかを変更します。`[IPictureFillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/)` のトリム値は元画像寸法に対するパーセンテージです。トリミングは埋め込み画像の隠れたピクセルを削除するのではなく、可視領域を変更するだけです。

次の例は画像フレームを安全に取得し、トリム値を適用します。

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

隠れた画像データは依然として存在するため、後からトリミングを変更しても元のピクセルは失われません。ファイルサイズが重要で、元に戻す必要がない場合は、次のセクションで説明するようにトリミング領域を物理的に除去できます。

## **トリミングされた画像データの除去**

`[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)` は現在のトリミング矩形外の画像データを削除し、結果の画像リソースを返します。これによりファイルサイズが削減できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは後からの「アンコート」操作では利用できなくなります。

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

このメソッドはプレゼンテーションに新しい画像リソースを追加することがあります。元画像が他の画像フレームでも使用されている場合、これらのフレームは既存のリソースを引き続き必要とするため、トリミング領域の削除が必ずしも画像総数を減らすわけではありません。WMF や EMF コンテンツをこのメソッドでトリミングすると、結果は PNG にラスタライズされます。

## **ラスタ画像の圧縮**

`[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/compressimage/)` は、画像が表示されるサイズに対してラスタ画像の解像度を下げます。また、同時にトリミング領域を除去できます。メソッドは画像がリサイズまたはトリミングされた場合に `true`、変更が不要だった場合に `false` を返します。

標準的なターゲット解像度で十分な場合は、事前定義された `[PicturesCompression](https://reference.aspose.com/slides/ja/net/aspose.slides.export/picturescompression/)` 値を使用してください。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

特定の目標が必要な場合は、列挙型の代わりにカスタムの正の DPI 値を渡すこともできます。

圧縮はラスタ画像を対象としています。SVG やメタファイルのコンテンツはこのラスタ圧縮ワークフローでは削減されません。また、解像度を下げたりトリミング領域を削除したりした画像は、最適化されたプレゼンテーションから復元できないことを覚えておいてください。最小 DPI を全体に適用するのではなく、実際に閲覧またはエクスポートされる最大サイズに基づいてターゲット解像度を選択してください。

## **画像変換エフェクトの管理**

明るさ、コントラスト、カラートランスフォーム、ブラー、アルファ効果、順序付きチェーン、検査、除去、往復検証を網羅した完全なワークフローについては、`[Image Transform Effects](/slides/ja/net/image-transform-effects/)` を参照してください。

## **画像フレームジオメトリのロック**

`[IPictureFrameLock](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframelock/)` 設定は、画像フレームに対して無効化する編集操作を制御します。たとえば、アスペクト比ロックはサイズ変更時にシェイプの比例を保持します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

ロックは画像フレームシェイプに適用されます。元画像をリサンプルしたり、同じアスペクト比に永久に変更したりすることは強制しません。

## **StretchOffset 値の調整**

画像塗りつぶしモードがストレッチの場合、`[IPictureFillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/)` の stretch‑offset 値は画像フレームのバウンディングボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを、負のパーセンテージはアウトセットを作ります。

これはトリミングとは異なります。トリミング値は元画像のどの部分が可視になるかを選択し、ストレッチオフセットは可視画像塗りつぶしが伸縮される矩形を変更します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

塗りつぶし位置を調整する際は stretch offset を使用し、元画像の端を隠す目的の場合はトリムプロパティを使用してください。

## **保存、ファイルサイズ、エクスポートの考慮事項**

画像保存と画像フレーム書式設定を別々に扱うと、主なトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングで最も信頼性が高いですが、大きなラスタ画像は PPTX のサイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが保存パスやロケーションで利用可能であることに依存します。
- **トリミング** は当初は非破壊的です。隠れたピクセルはトリミング領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイルサイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上の最終サイズが確定した後に適用すべきです。
- **SVG 画像** はベクタ保存が重要な場合は SVG のままで保持すべきです。ベクタリソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスタ形式へのスライドエクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は、同じファイルを何度もプレゼンテーションにロードする代わりに、可能な限り既存の `[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/)` リソースを再利用してください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施するのが最も効果的です。ロゴや図はベクタコンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみトリミングピクセルを削除し、外部リンクは依存管理がデプロイ設計の一部でない限り避けてください。

## **FAQ**

**画像フレームと画像リソースの違いは何ですか？**

`[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/)` はプレゼンテーションに関連付けられた画像リソースを表し、`[IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/)` は画像を表示し、サイズ、回転、トリミング値、エフェクト、ロックなどフレームレベルのジオメトリと書式設定を保持するスライド上のシェイプです。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションをポータブルに、アーカイブに、外部リソースなしでレンダリングする必要がある場合は埋め込み画像を使用してください。外部ファイルを PPTX の外に保持し、外部ロケーションを信頼性高く管理できる場合のみリンク画像を使用してください。

**トリミングは PPTX のファイルサイズを削減しますか？**

単独では削減しません。通常のトリミング設定は画像の一部を非表示にするだけで、基になるピクセルは保持されます。ピクセルを永久に削除したい場合は `[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)` またはトリミング領域除去を伴う画像圧縮を使用してください。

**圧縮後に画像品質を元に戻すことはできますか？**

できません。圧縮は格納されたラスタ解像度を下げ、トリミング領域の除去は画像データを破棄します。後で高解像度での編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーションの外に保存しておいてください。

**SVG 画像はどのように扱うべきですか？**

ベクタの忠実度が重要な場合は SVG コンテンツを SVG のままで保持してください。埋め込み `[ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/)` は直接抽出できます。PNG や JPEG といったラスタ形式へのスライドレンダリングは、SVG をスライド画像の一部としてラスタライズします。

**既存スライドを読むときに安全でないキャストを回避するには？**

シェイプを使用する前にそのタイプを確認してください。`[IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/)` でのパターンマッチングやインターフェイスでのコレクションフィルタリングを行うことで、無効なキャストを防ぎ、画像フレームを含まないスライドでもコードが安全に動作します。