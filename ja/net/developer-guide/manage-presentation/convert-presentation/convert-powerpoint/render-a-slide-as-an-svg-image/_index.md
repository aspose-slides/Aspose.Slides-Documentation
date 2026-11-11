---
title: .NET でプレゼンテーションスライドを SVG 画像としてレンダリング
linktitle: スライドから SVG へ
type: docs
weight: 50
url: /ja/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint から SVG へ
- プレゼンテーションから SVG へ
- スライドから SVG へ
- PPT から SVG へ
- PPTX から SVG へ
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

SVG はスケーラブルな XML ベースの画像形式で、Web 公開、スライドビューア、アクセシビリティ ワークフロー、そして自動ポストプロセッシングに適しています。Aspose.Slides は各スライドを個別の SVG ファイルとしてエクスポートし、テキスト、フォント、画像、および SVG 要素の書き出し方法を制御できます。

エクスポートされた SVG がコンパクトで、ブラウザ間で予測可能、またはインタラクティブな使用のために準備が必要な場合は、[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) を使用します。

## **スライドを SVG としてエクスポート**

プレゼンテーションを作成し [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) を作成し、スライドを選択してストリームに書き込みます。以下の例は、プレゼンテーション内のすべてのスライドを個別の SVG ファイルとしてエクスポートします。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

ファイル名はループインデックスではなく、[ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) を使用します。また、スライドビューアや Web ページが特定のシェイプだけを必要とする場合は、[IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) を使用して個々のシェイプをエクスポートすることもできます。

## **SVG 出力の構成**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) は SVG のレンダリングを制御します。テキストフレームの場合、[SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) はレンダリング領域にテキストフレームを含め、[SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) はフレーム回転が適用されるかどうかを決定します。テキストを合字なしで描画する必要がある場合は、[SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) を `true` に設定します。

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

## **矢じりでのラインエンドクロッピングの制御**

SVG 1.1 には、矢じりの下で線が停止すべき位置を指定するマーカーインセット設定がありません。デフォルトでは、Aspose.Slides はエクスポートされた線を短くしてストロークがマーカーを突き抜けないようにします。[SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) を `true` に設定すると、ストロークは線の元の終点まで描画されます。この設定は SVG 出力にのみ影響し、スライド上の線の位置と長さは保持されます。

例では、幅が 2 ポイントと 10 ポイントの線に対して三角形とダイヤモンドの矢じりを描画しています。クロッピング オプションだけを変更して同じスライドを 2 回エクスポートします。

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

比較では、10 ポイント線上の三角形矢じりが示されます。クロッピングが有効な場合は先端が鋭く、無効な場合はストロークがマーカーの斜辺を突き抜けて平らな終端になります。

![クロッピングが有効なときは鋭い先端、無効なときは平らな端になる、拡大された 10 ポイントの三角形矢じり](line-end-cropping.png)

例の他の線では、2 ポイントの三角形で突き抜けたストロークが目立ちにくくなっています。塗りつぶしのダイヤモンドは幅が異なってもストロークの端をカバーします。

## **テキストとフォントの制御**

スライドを SVG にエクスポートするとき、テキストをテキストとして残すかベクタ画像に変換するか、外部フォントをどのように含めるか（または参照するか）を制御できます。以下のオプションは、エクスポートされた SVG における視覚的一貫性、テキスト選択、およびフォント依存性のバランスを取るのに役立ちます。

### **すべてのテキストをベクタライズ**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) を `true` に設定すると、すべてのスライドテキストがベクタ画像として書き出されます。これによりフォント依存性がなくなり、ブラウザ間での視覚結果がより一貫しますが、テキストは SVG テキストとして選択・検索できなくなります。

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

### **外部フォントの取り扱い方法を選択**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) は、外部から読み込まれるフォントに対して [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) の値を使用します。`AddLinksToFontFiles` を選択すると個別のフォントファイルへのリンクが作成され、`Embed` を選択するとフォントデータが SVG に埋め込まれ、`Vectorize` を選択すると外部フォントを使用するテキストだけが画像として描画されます。フォントを埋め込む前にライセンスを確認してください。

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

## **埋め込み画像サイズの縮小**

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) を使用して埋め込み画像の解像度を下げ、[SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) で切り取られた元領域を省略し、[SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) で JPEG エンコード品質を制御します。これらの設定は、画像品質や保持する画像データと引き換えにファイルサイズを削減します。

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

## **メタファイルラスター化解像度の制御**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) は、SVG エクスポート時にメタファイルをラスタライズする際の下限解像度を設定します。EMF や WMF 画像をラスタライズするときの詳細度とファイルサイズのバランスを取るために使用します。SVG 全体の DPI を決定したり、スライド上のすべてのオブジェクトをラスタ画像に強制変換したりするものではありません。

[metafile-rasterization.pptx](metafile-rasterization.pptx) をダウンロードしてください。このファイルには間隔の狭い対角線を持つ EMF 画像が含まれています。以下の例は、[ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) を使用して最初のスライドを 3 つのラスタ化解像度でエクスポートします。その他のエクスポート設定はすべて同一に保たれ、結果を比較できるようになっています。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

出力では、EMF が各 SVG に埋め込まれた PNG に変換されています。以下の測定値は提供されたプレゼンテーションに対するものであり、DPI をピクセル寸法に変換する一般的な式ではありません。

| メタファイルラスター化 DPI | 埋め込み PNG の寸法 | SVG ファイルサイズ (バイト) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

以下の比較では、同じ領域の埋め込みラスタを同一の拡大表示サイズで示しています。72 DPI では対角線が目に見えるピクセル化し、解像度が高くなるほどエッジが滑らかになりますが、SVG ファイルは大きくなります。値を上げても必ずしもすべてのディテールが改善されたり、すべてのエクスポート画像が変化したりするわけではありません。

![72、150、300 DPI の拡大された対角線ディテール](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) は画像解像度の低減を制御し、メタファイルラスター化解像度の変更効果を隠すことがあります。[SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) は JPEG エンコード品質を制御し、メタファイルラスター化解像度は制御しません。

## **シェイプとテキストに安定した ID を割り当てる**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) を使用して各 SVG シェイプの [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) を設定します。テキスト `tspan` 要素にも [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) を設定したい場合は、[ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/) を実装します。いずれかのコントローラは [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) で割り当てます。

以下のコントローラは、シェイプの存続期間中安定した [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/) と、テキストスパン用の再現可能なカウンタを使用します。これにより、変更されていないプレゼンテーションのポストプロセッシングに適した ID が生成されます。

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) 内で、[ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) に [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) の値を渡すことで、エクスポートされたシェイプに JavaScript イベントハンドラを追加します。コントローラは [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) で割り当て、結果をホストするページまたは SVG 文書内で JavaScript 関数を定義します。

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

ホストページはハンドラが参照する JavaScript 関数を定義できます。ID とイベントハンドラを割り当てることで、スライドビューア、アクセシビリティ強化、その他のインタラクティブな SVG ワークフローが可能になります。

## **よくある質問**

**いつ [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) を [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) の代わりに使用すべきですか？**

すべてのテキストがフォントに依存しない必要がある場合は [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) を使用します。外部フォントを使用するテキストだけを画像に変換したい場合は [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) を使用します。

**SVG を小さくする最適な方法は何ですか？**

埋め込み画像を圧縮し、切り取られた画像領域を削除し、対象環境で提供可能な場合はリンクされたフォントファイルを選択することから始めます。画像解像度の低下、JPEG 品質の低下、ベクタライズされたテキストはそれぞれ品質とサイズのトレードオフが異なるため、結果を必ずテストしてください。

**エクスポート後に SVG 要素を変更できますか？**

はい。フォーマットコントローラを通じて ID を割り当て、その ID を使用してポストプロセッシングツールやブラウザスクリプトで該当する SVG 要素を選択できます。