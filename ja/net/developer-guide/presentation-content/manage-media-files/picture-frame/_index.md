---
title: .NET でのプレゼンテーションにおける画像フレームの管理
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
- 画像の切り抜き
- 切り抜かれた領域の削除
- 画像の圧縮
- StretchOffset
- 画像フレームの書式設定
- 相対スケール
- 画像効果
- アスペクト比
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、プレゼンテーション内の画像フレームを作成、書式設定、リンク、切り抜き、抽出、圧縮します。"
---
## **概要**

画像フレームは、画像を表示するスライド シェイプです。Aspose.Slides では、画像リソースとそれを表示するシェイプは別々のオブジェクトです。 [Presentation] は埋め込み画像リソースをその [Images] コレクションを通じて所有し、 [IPictureFrame] は画像の位置、サイズ、線の書式設定、回転、切り抜き、画像効果、その他フレームレベルの設定を制御します。

同じ画像を複数回表示する場合、この分離は便利です。画像をプレゼンテーションに一度追加し、返された [IPPImage] を保持し、画像フレームを作成するときにその画像リソースを使用します。

画像フレームは PNG や JPEG などのラスタ画像や SVG などのベクタ画像を格納できます。また、プレゼンテーションに画像バイトを格納せず、リンク画像を参照させることもできます。選択はポータビリティ、ファイル サイズ、抽出、およびエクスポート動作に影響するため、書式設定や最適化を適用する前に画像の格納方法を決めておくと便利です。

## **埋め込み画像の追加と書式設定**

埋め込み画像の場合、画像データをプレゼンテーションに追加し、[IShapeCollection.AddPictureFrame] を使用して画像フレームを作成します。画像はプレゼンテーション パッケージの一部になるため、別のコンピュータに移動してもプレゼンテーションは自己完結します。

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

画像フレームは表示されるジオメトリを制御します。フレームサイズを変更しても、埋め込み画像リソースに格納された元のピクセル寸法は変わりません。この違いは後で画像を切り抜いたり圧縮したりする際に重要になります。

## **相対スケールの使用**

[IPictureFrame] はフレームの幅と高さの相対スケーリングを公開しています。`1.0` の値は元の画像サイズの 100% に相当します。相対スケールは、最終寸法を手動で計算する代わりに、元画像サイズとの関係を保持したいワークフローで便利です。

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

相対スケールはフレームのスケール設定を変更しますが、埋め込み画像を再サンプリングしたり圧縮したりはしません。

## **埋め込み画像とリンク画像**

埋め込み画像は画像データをプレゼンテーション内に格納するため、ポータビリティと予測可能なレンダリングに最も安全です。リンク画像は [ISlidesPicture] のリンク パスを使用して外部場所を参照し、画像データを同じ方法で埋め込みません。

リンク画像は PPTX に格納される画像データ量を削減できますが、外部依存性が生じます。リンク先ファイルはプレゼンテーションを開くまたはレンダリングするアプリケーションがアクセスできる状態である必要があります。パスが変更されたり、ファイルが移動されたり、リソースが利用できなくなったりすると、リンク画像は期待どおりに表示されません。メールで送信したり、アーカイブしたり、分離環境でレンダリングする必要があるプレゼンテーションでは、埋め込み画像の方が通常は信頼性が高いです。

### **リンク画像の追加**

次の例は画像フレームを作成し、ローカル画像ファイルを指すように設定します。この例は画像リンクのみを扱い、動画リンクは別のメディア ワークフローであり、意図的にこの例に混在させていません。

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

外部ファイル管理が意図的な場合にリンクを使用します。単に圧縮の代替として使用しないでください。壊れた画像依存性がある小さな PPTX は、サイズの大きい自己完結型プレゼンテーションよりも実用的でないことが多いです。

## **画像フレームから画像を抽出する**

既存のプレゼンテーションから画像を抽出する前に、シェイプが実際に [IPictureFrame] であり、埋め込み画像を含んでいるか確認してください。リンク画像フレームは、同じ方法で抽出できる画像バイトを含んでいない場合があります。

### **ラスタ画像の抽出**

最新の画像 API は [IImage] を直接使用し、古いシステム画像ラッパーは不要です。次の例はスライド上の最初の埋め込みラスタ画像を見つけ、PNG として保存します。

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

[IImage] を通じて保存すると、抽出した画像が要求された出力フォーマットに変換されます。プレゼンテーションに格納されているエンコード済みバイトが必要な場合は、変換されたラスタ ファイルではなく画像リソースのバイナリ データを使用してください。

### **SVG 画像の抽出**

SVG 画像の場合、[IPPImage] は [ISvgImage] オブジェクトを公開します。これにより、画像をラスタ化することなく SVG データを直接取得できます。

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

SVG コンテンツを SVG のまま保持すると、プレゼンテーション内部にベクタ ソースが保存されます。PNG や JPEG などのラスタ エクスポートは、そのベクタ コンテンツをピクセルにレンダリングします。PDF や SVG スライド エクスポートもレンダリング操作であるため、エクスポートされたグラフィックは元の埋め込み SVG のバイト単位のコピーとして扱わず、元のベクタ リソースが必要な場合は埋め込み [ISvgImage] データを使用してください。

## **画像の切り抜き**

切り抜きは、フレーム内で画像のどの部分が表示されるかを変更します。[IPictureFillFormat] の切り抜き値は元画像の寸法に対するパーセンテージです。切り抜きは埋め込み画像から隠れたピクセルを最初に削除するわけではなく、表示領域だけを変更します。

次の例は画像フレームを安全に取得し、切り抜き値を適用します。

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

隠れた画像データは依然として残っているため、後で元のピクセルを失うことなく切り抜きを変更できます。ファイル サイズが重要で、元に戻す必要がない場合は、次のセクションで説明するように切り抜かれた領域を物理的に削除できます。

## **切り抜かれた画像データの削除**

[IPictureFillFormat.DeletePictureCroppedAreas] は現在の切り抜き矩形外の画像データを削除し、結果として得られる画像リソースを返します。これによりファイル サイズを縮小できますが、破壊的な最適化です。プレゼンテーションを保存した後は、削除されたピクセルは後で元に戻すことはできません。

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

このメソッドはプレゼンテーションに新しい画像リソースを追加する可能性があります。元の画像が他の画像フレームでも使用されている場合、これらのフレームは既存のリソースを引き続き必要とするため、削除された領域が必ずしも画像総数の削減につながるわけではありません。WMF や EMF コンテンツをこのメソッドで切り抜くと、切り抜き結果が PNG にラスタ化されます。

## **ラスタ画像の圧縮**

[IPictureFillFormat.CompressImage] は、画像が表示されるサイズに対してラスタ画像の解像度を下げます。同時に切り抜き領域を削除することもできます。メソッドは画像がリサイズまたは切り抜かれた場合に `true`、変更が不要だった場合に `false` を返します。

標準的な目標解像度で十分な場合は、事前定義された [PicturesCompression] 値を使用してください。

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

特定の目標が必要な場合は、列挙値の代わりにカスタムの正の DPI 値を渡すこともできます。

圧縮はラスタ画像を対象としています。SVG やメタファイルの内容はこのラスタ圧縮ワークフローでは縮小されません。また、解像度が下がり切り抜き領域が削除された画像は最適化されたプレゼンテーションから復元できないことを忘れないでください。実際に閲覧またはエクスポートされる最大サイズに基づいて目標解像度を選択し、全体的に最低 DPI を適用するのは避けてください。

## **画像効果の検査**

画像効果はフレームで使用される画像に格納されます。画像変換コレクションには、透明度の固定アルファ変調や明るさ・コントラスト用の輝度などの効果が含まれることがあります。以下の例はスライド上の最初の画像フレームから両方の効果を安全に読み取ります。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

これらの効果はフレーム内で画像がどのようにレンダリングされるかを変更しますが、元の埋め込み画像バイトを書き換えることはありません。

## **画像フレームジオメトリのロック**

[IPictureFrameLock] 設定は、画像フレームに対して無効化される編集操作を制御します。たとえば、アスペクト比ロックはリサイズ時にシェイプの比例を保持します。

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

ロックは画像フレーム シェイプに適用されます。元画像が再サンプリングされたり、同じアスペクト比に永久に変更されたりすることはありません。

## **StretchOffset 値の調整**

画像の塗りつぶしモードが stretch の場合、[IPictureFillFormat] の stretch-offset 値は画像フレームの境界ボックスに対する塗りつぶし矩形を定義します。正のパーセンテージはエッジからのインセットを作り、負のパーセンテージはアウトセットを作ります。

これは切り抜きとは異なります。切り抜き値は元画像のどの部分が表示されるかを選択しますが、stretch offset は表示される画像塗りつぶしが伸びる矩形を変更します。

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

塗りつぶしの配置には stretch offset を使用し、元画像のエッジを隠す目的であれば切り抜きプロパティを使用してください。

## **ストレージ、ファイル サイズ、エクスポート上の考慮点**

画像ストレージと画像フレームの書式設定を別々に扱うと、主なトレードオフが管理しやすくなります。

- **埋め込み画像** はプレゼンテーションを自己完結させ、共有やサーバー側レンダリングに最も信頼性がありますが、大きなラスタ画像は PPTX サイズとメモリ使用量を増加させます。
- **リンク画像** はパッケージを小さく保てますが、プレゼンテーションは外部ファイルが保存されたパスまたは場所で利用可能であることに依存します。
- **切り抜き** は当初は破壊的ではありません。隠れたピクセルは切り抜き領域が明示的に削除されるか圧縮時に除去されるまで埋め込まれたままです。
- **圧縮** は過大なラスタ画像のファイル サイズを大幅に削減できますが、元の解像度を犠牲にします。スライド上の実際の表示サイズが決まってから適用すべきです。
- **SVG 画像** はベクタ の保持が重要な場合は SVG のままにすべきです。ベクタ リソース自体が必要なときは埋め込み SVG を直接抽出してください。ラスタ スライド エクスポートは常にレンダリングされたスライドをピクセルに変換します。
- **繰り返し使用される画像** は、同じファイルを何度もプレゼンテーション ワークフローにロードする代わりに、可能な限り既存の [IPPImage] リソースを再利用してください。

大規模なプレゼンテーションでは、画像最適化は選択的に実施すると最も効果的です。ロゴや図はベクタ コンテンツとして保持し、写真は実際の表示サイズに合わせて圧縮し、後で編集が不要な場合にのみ切り抜きピクセルを削除し、外部リンクは依存性管理が展開設計の一部でない限り避けてください。

## **FAQ**

**画像フレームと画像リソースの違いは何ですか？**

[IPPImage] はプレゼンテーションに関連付けられた画像リソースを表します。 [IPictureFrame] はスライド上の画像を表示し、サイズ、回転、切り抜き値、効果、ロックなどフレームレベルのジオメトリや書式設定を保持するシェイプです。

**画像は埋め込むべきですか、リンクすべきですか？**

プレゼンテーションをポータブルにしたり、アーカイブしたり、外部リソースにアクセスできずにレンダリングする必要がある場合は画像を埋め込んでください。画像ファイルを PPTX の外部に置き、外部場所を確実に管理できる場合にのみリンクを使用してください。

**切り抜きは PPTX のファイル サイズを削減しますか？**

単独では削減しません。通常の切り抜き設定は元画像のピクセルを保持したまま一部を非表示にするだけです。隠れたピクセルを永久に削除したい場合は、[IPictureFillFormat.DeletePictureCroppedAreas] または切り抜き領域削除を伴う画像圧縮を使用してください。

**圧縮後に画像品質を復元できますか？**

できません。圧縮は保存されたラスタ 解像度を下げ、切り抜き領域の削除は画像データを破棄します。後で高解像度の編集が必要になる可能性がある場合は、元のソース画像をプレゼンテーションの外部に保持してください。

**SVG 画像はどのように扱うべきですか？**

ベクタ の忠実度が重要な場合は SVG コンテンツを SVG のまま保持してください。埋め込み [ISvgImage] は直接抽出可能です。PNG や JPEG などのラスタ形式にスライドをレンダリングすると、SVG はそのスライド画像の一部としてピクセルに変換されます。

**既存のスライドを読むときに安全でないキャストを回避するには？**

シェイプの型を使用する前に確認してください。[IPictureFrame] でのパターン マッチングやシェイプ コレクションをそのインターフェイスでフィルタリングすれば、無効なキャストを防ぎ、画像フレームを含まないスライドでもコードが安全に動作します。