---
title: PowerPoint スライドを .NET で画像に変換する
linktitle: スライドから画像へ
type: docs
weight: 41
url: /ja/net/convert-slide/
keywords:
- スライド変換
- スライドエクスポート
- スライド→画像
- スライドを画像として保存
- スライド→EMF
- スライド→PNG
- スライド→JPEG
- スライド→ビットマップ
- スライド→TIFF
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PPT、PPTX、ODP プレゼンテーションのスライドを C# で PNG、JPEG、GIF、TIFF、EMF などの画像形式に変換します。"
---
## **はじめに**

Aspose.Slides for .NET は、PowerPoint および OpenDocument のプレゼンテーションから個々のスライドを PNG、JPEG、GIF、TIFF などの画像形式でレンダリングできます。

スライドを画像に変換するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスでプレゼンテーションを読み込みます。
2. レンダリングしたいスライドを選択します。
3. 必要に応じて、[RenderingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/renderingoptions/) または [TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/) クラスでレンダリングを設定します。
4. [GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/) メソッドを呼び出します。これにより [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) オブジェクトが返されます。
5. [IImage.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/save/) メソッドを呼び出し、[ImageFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/) の値で出力形式を指定します。

## **スライドを PNG 画像に変換する**

最もシンプルな変換はデフォルトのレンダリング設定を使用します。生成された [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) オブジェクトはメモリ上で処理することも、ファイルに保存することもできます。

次の C# の例は最初のスライドをレンダリングし、PNG 画像として保存します。

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **カスタムサイズでスライドを画像に変換する**

正確なピクセルサイズでスライドをレンダリングするには、[Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) 値を受け取る [GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/) のオーバーロードを使用します。

次の例は 1820 × 1040 ピクセルの JPEG 画像を作成します。

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **ノートとコメント付きスライドを画像に変換する**

デフォルトでは、スライド画像にノートやコメントは含まれません。[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notescommentslayoutingoptions/) オブジェクトを [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) プロパティに割り当てることで、ノートやコメントの表示位置を制御できます。

次の例は、スライドの下部に切り詰めたノートを、右側にコメントを配置します。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
スライドから画像への変換では、[NotesPosition](https://reference.aspose.com/slides/ja/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) プロパティを [BottomFull](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notespositions/) に設定しないでください。ノートは固定画像サイズが収められる以上のテキストを含むことがあります。代わりに [BottomTruncated](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notespositions/) を使用してください。
{{% /alert %}}

## **TIFF オプションを使用したスライドの画像変換**

[TiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/) クラスを使用すると、レンダリングされた TIFF 画像のサイズ、解像度、その他のプロパティを制御できます。

次の例は、最初のスライドを 2160 × 2880 ピクセル、300 DPI の TIFF 画像としてレンダリングします。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **すべてのスライドを画像に変換する**

スライドコレクションを反復処理して、プレゼンテーション全体を一連の画像に変換します。特に除外しない限り、非表示スライドも含まれます。

次の例は、すべてのスライドを横方向・縦方向ともに倍率 2 の JPEG 画像としてレンダリングします。

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **拡張メタファイル出力の作成**

拡張メタファイル (EMF) は、Microsoft Office や Windows メタファイルをサポートする他の Windows アプリケーションとベクターベースのグラフィックをやり取りする必要がある場合に便利です。ピクセルベースの画像とは異なり、EMF はベクタードローイング操作を保持でき、拡大縮小してもシャープさが失われません。ただし、EMF は主に Windows メタファイル対応アプリケーション向けの互換形式であり、汎用的な交換フォーマットではありません。また、ビットマップ画像や一部のエフェクトなどの複雑なスライドコンテンツは、ベクターメタファイルコンテナ内でラスタライズされた要素として格納されることがあります。

### **スライドを EMF にエクスポートする**

[ISlide.WriteAsEmf](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/writeasemf/) メソッドは、[ISlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/) を EMF 形式のターゲット ストリームに書き込みます。次の例はプレゼンテーションを読み込み、最初のスライドを選択し、EMF ファイル ストリームに書き込むものです。

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

呼び出し元は [ISlide.WriteAsEmf](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/writeasemf/) に渡したストリームの所有権を持ち、ストリームを閉じるか破棄する必要があります。Aspose.Slides はストリームの現在位置から書き込みを行い、ストリームはオープンしたままになります。

### **SVG 画像を EMF に変換してプレゼンテーションに追加する**

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/writeasemf/) を使用して SVG コンテンツを EMF に変換します。生成されたバイト列は [IImageCollection.AddImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection/addimage/) でプレゼンテーションに追加でき、[IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addpictureframe/) でスライドに配置できます。

次の例は SVG マークアップから [SvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/svgimage/) を作成し、メモリ内 EMF に変換し、最初のスライドにメタファイルを挿入してプレゼンテーションを保存します。

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/writeasemf/) は宛先ストリームの所有権を取得しません。書き込み後、ストリーム位置は生成データの末尾にあります。上記のように、同じシーク可能ストリームをリーダーに渡す前に `Position` を先頭にリセットしてください。ストリームはコンシューマが読み取りを完了するまで開いたままにし、使用後に破棄します。あるいは `ToArray` を呼び出して返されたバイト配列を [IImageCollection.AddImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection/addimage/) に渡すこともできます。`ToArray` は現在のストリーム位置に関係なく完全なバッファを返します。

EMF の生成は選択された Aspose.Slides for .NET ビルドがサポートするオペレーティング システム上で利用可能ですが、フォントやネイティブ グラフィックスの依存関係が利用できない場合、プラットフォーム間でレンダリング結果が異なることがあります。ソース コンテンツで使用されているフォントをインストールするか、適切な代替フォントを設定し、[プラットフォーム要件](/slides/ja/net/system-requirements/) に従って Aspose.Slides パッケージを構成し、対象の EMF 消費アプリケーションで結果を検証してください。Linux や macOS のアプリケーションは、Windows メタファイルの表示・編集サポートが限定的または一貫性がないことが多いです。

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="info" %}}
プレゼンテーションのスライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが変換を実行するシステムにインストールされ、利用可能である必要があります。たとえば、プレゼンテーションが **Segoe UI Emoji** を使用しているがこのフォントが欠落している場合、出力画像の絵文字はモノクロで表示される可能性があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ。[GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/) メソッドはスライドの静止画像を生成し、アニメーションはエクスポートされません。

**非表示スライドを画像としてエクスポートできますか？**

はい。非表示スライドも通常のスライドと同様にレンダリングできます。上記の例のように処理ループに含めてください。

**スライド画像には影やその他のエフェクトが保持されますか？**

はい。Aspose.Slides はスライド画像内で影、透明度、その他サポートされているグラフィック効果をレンダリングします。