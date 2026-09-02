---
title: .NET でプレゼンテーションスライドを SVG 画像としてレンダリング
linktitle: スライドから SVG へ
type: docs
weight: 50
url: /ja/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG
- プレゼンテーションから SVG
- スライドから SVG
- PPT から SVG
- PPTX から SVG
- SVG エクスポート オプション
- インタラクティブ SVG
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET で PowerPoint スライドを SVG 画像としてエクスポートし、フォント、テキスト、画像、ID、イベントを Aspose.Slides で制御します。"
---
## **概要**

SVG は、スケーラブルな XML ベースの画像フォーマットで、ウェブ出版、スライドビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適しています。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、および SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG をコンパクトに保ち、ブラウザ間で予測可能にし、インタラクティブに使用できるようにする必要がある場合は、[SVGOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/) を使用します。

## **スライドを SVG にエクスポート**

[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) を作成し、スライドを選択してストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

ファイル名はループインデックスではなく [ISlide.SlideNumber](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/slidenumber/) を使用します。スライドビューアやウェブページが特定のシェイプのみを必要とする場合は、[IShape.WriteAsSvg](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/writeassvg/) を使用して個別のシェイプをエクスポートすることもできます。

## **SVG出力の構成**

[SVGOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/) は SVG のレンダリングを制御します。テキストフレームについては、[SVGOptions.UseFrameSize](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/useframesize/) がテキストフレームを描画領域に含め、[SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/useframerotation/) がフレームの回転を適用するかどうかを決定します。テキストをリガチャなしで描画する必要がある場合は、[SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/disablefontligatures/) を `true` に設定します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **テキストとフォントの制御**

### **すべてのテキストをベクタライズ**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/vectorizetext/) を `true` に設定すると、スライド上のすべてのテキストがベクタ画像として書き出されます。これによりフォントへの依存がなくなり、ブラウザ間で視覚的な結果がより一貫しますが、テキストは SVG のテキストとして選択や検索ができなくなります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **外部フォントの取り扱い方法の選択**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/externalfontshandling/) は外部から読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへの参照が作成され、`Embed` を選択するとフォントデータが SVG に埋め込まれ、`Vectorize` を選択すると外部フォントを使用するテキストだけがグラフィックとして描画されます。フォントを埋め込む前にライセンスを確認してください。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **埋め込み画像サイズの削減**

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/picturescompression/) を使用して埋め込み画像の解像度を下げ、[SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) で切り取られた元画像領域を省略し、[SVGOptions.JpegQuality](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/jpegquality/) で JPEG エンコード品質を制御します。これらの設定は画像の忠実度や保持される画像データを犠牲にしてファイルサイズを削減します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **シェイプとテキストに安定した ID を割り当て**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/isvgshapeformattingcontroller/) を使用して各 SVG シェイプの [ISvgShape.Id](https://reference.aspose.com/slides/ja/net/aspose.slides.export/isvgshape/id/) を設定します。テキストの `tspan` 要素にも [ISvgTSpan.Id](https://reference.aspose.com/slides/ja/net/aspose.slides.export/isvgtspan/id/) を設定したい場合は、[ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) を実装します。いずれのコントローラも [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) で割り当てます。

以下のコントローラは [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/officeinteropshapeid/) を使用します。これはシェイプの存続期間中に安定しており、テキストスパンには再現可能なカウンタを使用します。このため生成された ID は、変更されていないプレゼンテーションのポストプロセッシングに適しています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **SVG イベントハンドラの追加**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/isvgshapeformattingcontroller/) 内で、[ISvgShape.SetEventHandler](https://reference.aspose.com/slides/ja/net/aspose.slides.export/isvgshape/seteventhandler/) に [SvgEvent](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgevent/) の値を渡して、エクスポートされたシェイプに JavaScript イベントハンドラを追加します。コントローラは [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) で割り当て、結果をホストするページまたは SVG ドキュメント内で JavaScript 関数を定義します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティ機能、その他のインタラクティブな SVG ワークフローが可能になります。

## **FAQ**

**[SVGOptions.VectorizeText](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/vectorizetext/) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgexternalfontshandling/) の代わりに使用すべきタイミングはいつですか？**

[SVGOptions.VectorizeText] は、すべてのテキストをフォントに依存しないようにする必要がある場合に使用します。[SvgExternalFontsHandling.Vectorize] は、外部フォントを使用するテキストのみをグラフィックに変換したい場合に使用します。

**SVG を小さくする最適な方法は何ですか？**

まず、埋め込み画像を圧縮し、切り取られた画像領域を削除し、対象環境で提供できる場合はリンクされたフォントファイルを選択します。画像解像度の低下、JPEG 品質の低下、テキストのベクタライズはそれぞれ品質とサイズのトレードオフが異なるため、結果をテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマッティングコントローラで ID を割り当てた後、ポストプロセッシングツールやブラウザスクリプトで該当する SVG 要素を選択できます。