---
title: ".NET のプレゼンテーションにおける画像管理の最適化"
linktitle: "画像の管理"
type: docs
weight: 10
url: /ja/net/image/
keywords:
- "画像を追加"
- "画像を挿入"
- "画像を置換"
- "画像コレクション"
- "画像フレーム"
- "リンク画像"
- "背景"
- "PNG を追加"
- "JPG を追加"
- "SVG を追加"
- "SVG をシェイプに変換"
- "外部 SVG リソース"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでラスタ画像と SVG 画像の追加、再利用、リンク、置換、管理方法を学びます。"
---
## **導入**

Aspose.Slides for .NET は画像を扱うための複数の方法を提供しており、目的に応じて使い分けられます。画像をプレゼンテーションに格納したり、画像フレームに表示したり、スライドの背景として使用したり、外部画像へリンクしたり、共有画像リソースを置換したり、SVG コンテンツを編集可能なシェイプに変換したりできます。

個々の画像フレームに対するクロップ、透明度、エフェクト、ストレッチなどの書式設定については、[Picture Frame](/slides/ja/net/picture-frame/) を参照してください。

## **画像モデルの理解**

以下の API 概念は密接に関連していますが、互換的ではありません。

- [プレゼンテーション画像コレクション](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection/) はプレゼンテーションで使用される画像リソースを格納します。[ImageCollection.AddImage](https://reference.aspose.com/slides/ja/net/aspose.slides/imagecollection/addimage/) を使用して画像データを追加し、[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) リソースを取得します。
- [画像フレーム](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/) はスライド、レイアウト、マスタ上に画像を表示するシェイプです。[IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addpictureframe/) を使用して画像リソースをスライド上に配置します。
- スライド背景はシェイプではなくスライドの塗りつぶしの一部として画像を使用します。そのため画像フレームのようには振る舞いません。
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/replaceimage/) は画像リソースを置換します。複数のプレゼンテーション要素がそのリソースを使用している場合、すべてが置換後の画像を使用します。
- SVG をシェイプに変換すると、編集可能なスライドシェイプが作成されます。変換後はコンテンツは単一の画像リソースとしては管理されなくなります。

典型的なワークフローは次のとおりです。画像データを画像コレクションに追加し、[IPPImage] を取得し、そのリソースを画像フレームまたは塗りつぶしで使用します。

## **埋め込み画像の追加**

ローカル画像を挿入するには、ファイルを読み取り、そのデータを画像コレクションに追加し、返された `IPPImage` を使用する画像フレームを作成します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

この方法で追加された画像はプレゼンテーションに埋め込まれるため、元の画像ファイルが利用できなくても生成されたファイルは問題なく表示されます。

### **Web から画像を追加**

画像が HTTP または HTTPS 経由で取得可能な場合、`HttpClient` でバイト列をダウンロードし、プレゼンテーション画像コレクションに追加し、ローカル画像と同様の手順で取得した画像リソースを使用します。

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

長時間稼働するアプリケーションでは、リクエストごとに新しいインスタンスを作成するのではなく `HttpClient` を再利用してください。また、信頼できないソースの場合はリモート URL、レスポンスサイズ、コンテンツタイプを検証してください。

## **スライド間で画像を再利用**

同じ画像が複数回必要な場合は、プレゼンテーションに一度だけ画像を追加し、追加の画像フレームを作成する際に返された [IPPImage] を再利用します。これにより同一のソースデータを何度も読み込むことを防ぎ、共有画像リソースとその使用箇所との関係が明示的になります。

多数のスライドで自動的に表示したいロゴなどのグラフィックは、各スライドに同等のシェイプを追加する代わりに、[スライドマスタ](/slides/ja/net/slide-master/) またはレイアウト上に画像フレームを配置することを検討してください。

## **画像をスライドの背景として使用**

背景画像は画像フレームのシェイプとして追加されるのではなく、スライドの塗りつぶしに割り当てられます。画像がスライド全体の背景を覆い、通常のスライドオブジェクトとして操作されない場合に便利です。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

マスタやレイアウトの背景を含む追加の背景オプションについては、[Presentation Background](/slides/ja/net/presentation-background/) を参照してください。

## **埋め込み画像とリンク画像**

埋め込み画像とリンク画像は可搬性とファイルサイズに関して異なるトレードオフがあります。

- **埋め込み画像:** 画像データがプレゼンテーション内部に保存されます。プレゼンテーションは単体で完結しますが、ファイルサイズに画像データが含まれます。
- **リンク画像:** プレゼンテーションは外部画像へのパスまたは URL を保持します。これによりプレゼンテーションのサイズは減少しますが、外部リソースへのアクセスが必要です。

リンク画像は、画像データを埋め込むのではなく [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/ja/net/aspose.slides/islidespicture/linkpathlong/) を介して外部パスまたは URL を割り当てることで作成できます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

外部リソースへの信頼性が確保できる環境でのみリンク画像を使用してください。オフラインでの使用やシステム間での移動が必要なプレゼンテーションでは、埋め込み画像の方が安全です。

## **SVG 画像の操作**

SVG はベクターフォーマットであり、アイコンや図表など、ラスタ画像と比べて拡大縮小による詳細損失が少ないグラフィックに適しています。Aspose.Slides は SVG を画像リソースとして、または編集可能なスライドシェイプのソースとしてサポートします。

### **SVG を画像として追加**

[SvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/svgimage/) を作成し、画像コレクションに追加して、得られた画像リソースを画像フレームに配置します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **外部リソースを含む SVG ファイル**

SVG は外部画像、スタイルシート、フォントを参照できる場合があります。そのようなケースでは、[SvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/svgimage/) が [IExternalResourceResolver](https://reference.aspose.com/slides/ja/net/aspose.slides.import/iexternalresourceresolver/) とベース URI を受け取るコンストラクタを提供します。リゾルバは相対 URI を許可された絶対 URI にマッピングし、要求されたリソースのストリームを返します。

リゾルバは SVG 処理中に外部リソースへのアクセスを可能にしますが、SVG 自体を自己完結型ドキュメントに書き換えることはしません。SVG を可搬に保つ必要がある場合は、リンク画像に対して `data:` URI を使用するなどして、必要なリソースを SVG 内に埋め込んでください。

信頼できないソースから SVG が提供される場合は、リゾルバがアクセスできるスキーム、ファイル位置、ホストを制限してください。ネットワークリゾルバにはタイムアウト、レスポンスサイズ制限、コンテンツ検証を適用することも推奨します。

### **SVG を編集可能なシェイプに変換**

Aspose.Slides は SVG を編集可能なスライドシェイプのグループに変換できます。これは PowerPoint の対応コマンドと同等です。

![PowerPoint ポップアップメニュー](img_01_01.png)

[ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/) を受け取る [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addgroupshape/) のオーバーロードを使用して変換を実行します。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

SVG をシェイプに変換するのは、個々のベクター要素を PowerPoint シェイプとして編集する必要がある場合に適しています。表示のみが目的であれば、画像として保持した方がシンプルで多数のシェイプ生成を回避できます。

## **既存の画像リソースを置換**

既存の画像リソースを置換したい場合は、[IPPImage.ReplaceImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/replaceimage/) を使用します。これはロゴなどの共有グラフィックに特に便利です。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

複数の画像フレーム、背景、マスタ、レイアウトが同じ画像リソースを使用している場合、そのリソースを置換するとすべての使用箇所が更新されます。単一の画像フレームだけを変更したい場合は、共有リソースを置換せずに別の画像をそのフレームに割り当ててください。

`ReplaceImage` には [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) または別の [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) を受け取るオーバーロードも用意されています。

## **実践的な画像管理のガイダンス**

### **プレゼンテーションサイズの管理**

大きなラスタ画像はプレゼンテーションを不必要に肥大化させます。表示サイズに見合った解像度の画像を使用し、可能な限り共有画像リソースを再利用し、同一の高解像度画像を埋め込みすぎないようにしてください。

すでに画像フレームに配置されたラスタ画像については、[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/compressimage/) を使用して、選択された解像度やクロップ設定に基づき画像データを圧縮できます。これは画像コレクションの管理ではなく画像フレームの処理になるため、関連する書式操作については [Picture Frame](/slides/ja/net/picture-frame/) を参照してください。

### **埋め込みコンテンツとリンクコンテンツの選択**

埋め込みはすべての画像データがファイルに同梱されるため、プレゼンテーションの可搬性が高まります。リンクはファイルサイズを削減できますが、外部依存が発生します。依存が許容でき、かつ安定している場合にのみリンクを使用してください。

### **共有ブランディングの再利用**

ロゴや透かし、装飾グラフィックなどの繰り返し使用する要素は、1 つの画像リソースを作成して再利用します。コンテンツではなくプレゼンテーションのデザインに属するグラフィックは、マスタやレイアウトに配置して対象スライドに継承させると重複を防げます。

### **SVG リソースをポータブルに保つ**

自己完結型の SVG は、外部ファイルやネットワークリソースに依存しないため、移動やレンダリングが容易です。可能な限り必要なリソースを SVG 内に埋め込んでからインポートし、個々のベクター要素の編集が必要な場合にのみシェイプへの変換を行ってください。

### **最新のクロスプラットフォーム Image API を使用**

新規 .NET コードでは、`System.Drawing.Image` や `Bitmap` に依存せず、Aspose.Slides の [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) と [Images](https://reference.aspose.com/slides/ja/net/aspose.slides/images/) API を使用してください。移行ガイダンスは [Modern API](/slides/ja/net/modern-api/) を参照してください。

WMF および EMF は特別な取り扱いが必要です。これらの形式が [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) に渡されると、[ImageCollection.AddImage](https://reference.aspose.com/slides/ja/net/aspose.slides/imagecollection/addimage/) がメタファイルをラスタ PNG 表現に変換して挿入します。メタファイルデータをそのまま保持したい場合は、ストリームベースの [ImageCollection.AddImage](https://reference.aspose.com/slides/ja/net/aspose.slides/imagecollection/addimage/) オーバーロードを使用してください。スプレッドシート等から EMF コンテンツを生成する場合は別途統合ワークフローが必要であり、本記事の範囲外です。

## **FAQ**

**画像コレクションと画像フレームの違いは何ですか？**

画像コレクションは再利用可能な画像リソースを格納します。画像フレームはそのリソースのうちの 1 つを表示するスライドシェイプで、クロップやエフェクトといった画像固有の書式設定を提供します。

**ロゴを全スライドで同じように置換する最良の方法は？**

ロゴが 1 つの画像リソースとして共有されている場合は、[IPPImage.ReplaceImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/replaceimage/) でそのリソースを置換します。プレゼンテーション全体のブランディングを統一したい場合は、ロゴをマスタまたはレイアウトに配置すると、個別スライドへの重複配置を削減できます。

**リンク画像が別のコンピュータで消えるのはなぜですか？**

リンク画像は外部ファイルまたは URL に依存しています。別のコンピュータからそのリソースに到達できない場合、リンク画像は表示されません。プレゼンテーションを自己完結させる必要がある場合は、画像を埋め込んでください。

**挿入した SVG を PowerPoint のシェイプとして編集できますか？**

はい。[IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addgroupshape/) を使用して SVG を変換すると、生成されたグループは 1 つの SVG 画像ではなく、個別に編集可能なスライドシェイプとして扱えます。

**画像が多数あるプレゼンテーションのサイズを小さく保つには？**

共有画像リソースを再利用し、不要に大きなラスタ画像を使用しないようにし、適切な場面でラスタ画像を圧縮し、ブランディングはマスタやレイアウトに配置し、外部依存が許容できる場合にのみリンク画像を使用してください。