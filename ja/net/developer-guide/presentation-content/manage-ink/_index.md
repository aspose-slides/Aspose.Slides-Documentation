---
title: .NET でプレゼンテーションのインク オブジェクトを管理する
linktitle: インクの管理
type: docs
weight: 95
url: /ja/net/manage-ink/
keywords:
- インク
- インク オブジェクト
- インク トレース
- インク の管理
- インク の描画
- 描画
- インク エクスポート
- インク レンダリング
- インク の非表示
- IInkOptions
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint のインク オブジェクトを管理し、トレースやブラシ プロパティを編集し、PDF、HTML、SVG、TIFF、画像エクスポート時のインク表示を Aspose.Slides for .NET で制御します。"
---
## **はじめに**

PowerPoint は、フリーフォームのストロークを描くことができるインク機能を提供します。インクは、他のオブジェクトをハイライトしたり、接続やプロセスを示したり、スライド上の特定の項目に注意を引くために使用できます。

[Aspose.Slides.Ink](https://reference.aspose.com/slides/ja/net/aspose.slides.ink/) 名前空間には、インク オブジェクトを操作するために必要なクラスとインターフェイスが含まれています。たとえば、[IInk](https://reference.aspose.com/slides/ja/net/aspose.slides.ink/iink/) インターフェイスは、スライド上のインク オブジェクトを表します。

## **通常のオブジェクトとインク オブジェクトの違い**

PowerPoint のスライド上のオブジェクトは、通常、シェイプ オブジェクトで表されます。最も簡単な形では、シェイプはオブジェクト自体（フレーム）の領域を定義するコンテナであり、コンテナのサイズ、形状、背景などのプロパティを持ちます。詳細については、[Shape Layout Format](https://docs.aspose.com/slides/ja/net/shape-manipulations/#access-layout-formats-for-shape) を参照してください。

しかし、PowerPoint がインク オブジェクトを処理する場合、サイズ以外のオブジェクト フレーム（コンテナ）のすべてのプロパティは無視されます。コンテナ領域のサイズは、標準の [IShape.Width](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/width/) と [IShape.Height](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/height/) プロパティで決定されます：

![ink_powerpoint1](ink_powerpoint1.png)

## **インク トレース**

インク トレースは、ユーザーがデジタルインクで書く際のペンの軌跡を記録するために使用される基本要素です。トレースは、接続されたポイントのシーケンスを保存します。

最もシンプルなエンコード形式は、各サンプル点の X および Y 座標を指定します。すべての接続された点がレンダリングされると、次のような画像が生成されます：

![ink_powerpoint2](ink_powerpoint2.png)

## **描画用ブラシ プロパティ**

ブラシは、インク トレースのポイントを接続する線を描くために使用されます。ブラシには独自の色とサイズがあり、[IInkBrush.Color](https://reference.aspose.com/slides/ja/net/aspose.slides.ink/iinkbrush/color/) と [IInkBrush.Size](https://reference.aspose.com/slides/ja/net/aspose.slides.ink/iinkbrush/size/) プロパティで表されます。

### **インク ブラシの色を設定**

この C# コードは、インク ブラシの色を設定する方法を示しています：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **インク ブラシのサイズを設定**

この C# コードは、インク ブラシのサイズを設定する方法を示しています：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

通常、ブラシの幅と高さは一致せず、そのため PowerPoint はブラシのサイズを表示しません（対応するデータ セクションは灰色表示になります）。ブラシの幅と高さが一致する場合、PowerPoint は次のようにサイズを表示します：

![ink_powerpoint3](ink_powerpoint3.png)

分かりやすくするために、インク オブジェクトの高さを増やし、重要な寸法を確認しましょう：

![ink_powerpoint4](ink_powerpoint4.png)

コンテナ（フレーム）はブラシのサイズを考慮せず、常に線の太さが 0 であるとみなします（前の画像を参照）。

したがって、インク オブジェクト全体の可視領域を決定するには、トレースのブラシ サイズを考慮する必要があります。ここでは、対象オブジェクト（手書きテキスト トレース）がコンテナ（フレーム）のサイズに合わせてスケーリングされています。コンテナのサイズが変わると、ブラシのサイズは一定のままで、逆も同様です。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint はテキスト オブジェクトにも同様の動作を使用します：

![ink_powerpoint6](ink_powerpoint6.png)

## **エクスポートおよびレンダリング時のインク表示の制御**

Aspose.Slides は、エクスポートまたはレンダリングされた出力でインク オブジェクトがどのように表示されるかを制御するための [IInkOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/iinkoptions/) インターフェイスを提供します。そのプロパティを使用してインクを完全に非表示にしたり、インク ブラシのマスク操作の解釈方法を変更したりできます。

Ink options are available through the export or rendering options for several output types:

| 出力 | インク オプション プロパティ |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/ja/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/ja/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/inkoptions/) |
| スライド画像 | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/ja/net/aspose.slides.export/renderingoptions/inkoptions/) |

The same two settings are available through these properties:

- [`HideInk`](https://reference.aspose.com/slides/ja/net/aspose.slides.export/iinkoptions/hideink/) は、インク オブジェクトを出力に含めるかどうかを決定します。デフォルト値は `false` です。
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/ja/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) は、インク ブラシをレンダリングする際にマスク操作を不透明度として解釈するかどうかを決定します。デフォルト値は `true` です。`false` に設定すると、代わりに ROP 操作が使用されます。

### **PDF 出力でインク オブジェクトを非表示にする**

既定では、エクスポート時にインク オブジェクトは表示されたままです。手書きの注釈やその他のインク コンテンツを除いたクリーンな出力が必要な場合は、[IInkOptions.HideInk](https://reference.aspose.com/slides/ja/net/aspose.slides.export/iinkoptions/hideink/) を `true` に設定します。

次の C# サンプルは、すべてのインク オブジェクトを非表示にした状態でプレゼンテーションを PDF にエクスポートします：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **スライドを画像としてレンダリングする際にインク オブジェクトを非表示にする**

スライドをビットマップ画像としてレンダリングする際にインク オブジェクトを非表示にするには、[RenderingOptions.InkOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/renderingoptions/inkoptions/) を設定し、レンダリング オプションを [ISlide.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/) メソッドに渡します。

次の C# サンプルは、インク オブジェクトを除いた PNG 画像として最初のスライドをレンダリングします：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **インク マスクのレンダリングを制御**

[IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ja/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) プロパティは、インク ブラシをレンダリングする際にマスク操作がどのように解釈されるかを制御します。デフォルト値は `true` で、不透明度として扱われます。`false` に設定すると、代わりに ROP 操作が使用されます。

次の C# サンプルは、スライドを SVG にエクスポートし、インク マスク操作に ROP ベースのレンダリングを使用します：

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

プレゼンテーションをエクスポートする場合やスライドを TIFF にレンダリングする場合も、[TiffOptions.InkOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/tiffoptions/inkoptions/) を使用して同じ設定を適用できます。

### **インクを非表示にするか保持するかを選択**

注釈付きプレゼンテーションのクリーンなバージョン（レビュー マークなしで配布する最終コピーなど）としてエクスポートする場合は、[IInkOptions.HideInk](https://reference.aspose.com/slides/ja/net/aspose.slides.export/iinkoptions/hideink/) を `true` に設定します。

インク 注釈が意図したコンテンツの一部である（レビュー コメント、手書きメモ、ハイライト、描画など）場合は、[IInkOptions.HideInk](https://reference.aspose.com/slides/ja/net/aspose.slides.export/iinkoptions/hideink/) をデフォルトの `false` のままにしてください。これにより、アプリケーションは同じプレゼンテーションからソースのインク オブジェクトを変更せずに、レビュー用と最終用の別々の出力を生成できます。

## **FAQ**

**既存のインク ストロークの色やサイズを変更できますか？**

はい。[IInk.Traces](https://reference.aspose.com/slides/ja/net/aspose.slides.ink/iink/traces/) からトレースを取得し、[IInkTrace.Brush](https://reference.aspose.com/slides/ja/net/aspose.slides.ink/iinktrace/brush/) を変更します。ブラシの [IInkBrush.Color](https://reference.aspose.com/slides/ja/net/aspose.slides.ink/iinkbrush/color/) と [IInkBrush.Size](https://reference.aspose.com/slides/ja/net/aspose.slides.ink/iinkbrush/size/) プロパティを設定できます。

**インクを非表示にすると元のプレゼンテーションが変更されますか？**

いいえ。[IInkOptions.HideInk](https://reference.aspose.com/slides/ja/net/aspose.slides.export/iinkoptions/hideink/) は、レンダリングまたはエクスポートされた結果にのみ影響し、ソースのプレゼンテーション内のインク オブジェクトを削除したり変更したりしません。

**どのエクスポート形式がインク オプションをサポートしていますか？**

上記の対応するエクスポートまたはレンダリング オプションを使用して、PDF、HTML、SVG、TIFF、ビットマップ スライド画像のインク オプションを構成できます。

**さらに読む**

* 全般的なシェイプについて読むには、[PowerPoint Shapes](https://docs.aspose.com/slides/ja/net/powerpoint-shapes/) セクションをご覧ください。
* 有効な値に関する詳細は、[Shape Effective Properties](https://docs.aspose.com/slides/ja/net/shape-effective-properties/#get-effective-font-height-value) を参照してください。
* PDF エクスポートの詳細については、[Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ja/net/convert-powerpoint-to-pdf/) を参照してください。
* HTML エクスポートの詳細については、[Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ja/net/convert-powerpoint-to-html/) を参照してください。
* SVG エクスポートの詳細については、[Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ja/net/render-a-slide-as-an-svg-image/) を参照してください。
* TIFF エクスポートの詳細については、[Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ja/net/convert-powerpoint-to-tiff/) を参照してください。
* スライドから画像へのレンダリングの詳細については、[Convert Presentation Slides to Images](https://docs.aspose.com/slides/ja/net/convert-slide/) を参照してください。