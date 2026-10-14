---
title: PowerPoint スライドを .NET で PNG に変換
linktitle: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/net/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を実現します。"
---
## **概要**

この記事では、Aspose.Slides for .NET を使用してプレゼンテーション スライドを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP などの形式のプレゼンテーションを読み込み、各スライドをレンダリングし、個別の PNG 画像として保存できます。

以下の例では、サムネイルのレンダリング、スケール係数の設定、出力サイズをピクセル単位で指定する方法、そしてグラデーションのレンダリング スタイルの選択方法を示します。

## **PowerPoint を PNG に変換**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) コレクションでスライドにアクセスします。例では、パラメータなしで [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) を呼び出してサムネイルを作成します。その後、[IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) に [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) を指定して、各レンダリングされたスライドを PNG 画像として保存します。

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
パラメータなしの [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) オーバーロードはスケール 0.2 でレンダリングします。たとえば、720 × 540 ポイントのスライドは 144 × 108 ピクセルのサムネイルになります。出力サイズを制御するには、以下に示すスケール係数を使用したオーバーロードまたは明示的な画像サイズを使用してください。
{{% /alert %}}

## **カスタム寸法で PowerPoint を PNG に変換**

水平および垂直のスケール係数を [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) に渡してレンダリングサイズを制御します。この例では両方の係数が 2 となり、720 × 540 ポイントのスライドは 1440 × 1080 ピクセルの画像になります。等しいスケール係数はスライドのアスペクト比を維持します。各画像は [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) を使用して PNG 形式で保存されます。

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **カスタムサイズで PowerPoint を PNG に変換**

ピクセル単位で出力サイズを指定するには、スケール係数の代わりにサイズを [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) に渡します。この例では、すべてのスライドを 960 × 720 ピクセルでレンダリングし、[IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) で結果を保存します。スライドのアスペクト比に合ったサイズを選択し、画像が伸びるのを防いでください。

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **グラデーションのレンダリング スタイルを選択**

スライドにグラデーション フィルが含まれているが、エクスポートされた PNG の遷移が PowerPoint で見えるものより明るくなる、または異なる場合があります。そのような場合は、[RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) の [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) プロパティを使用して、グラデーションのレンダリング方法を選択できます。

[gradient-styles.pptx](gradient-styles.pptx) をダウンロードしてアプリケーションの作業ディレクトリに配置します。最初のスライドには、上部がシアンからオレンジ、下部が青から黄への 2 つの線形グラデーションが含まれています。各グラデーションは 0% と 100% の 2 つのストップを持ちます。

以下の例はこのプレゼンテーションを読み込み、[ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) を使用して同じ最初のスライドを両方のモードでレンダリングします。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

| デフォルト | PowerPointUI |
| --- | --- |
| ![デフォルトでレンダリングされたシアンからオレンジ、青から黄へのグラデーション](gradient-Default.png) | ![PowerPointUI でレンダリングされた同じグラデーション](gradient-PowerPointUI.png) |

この例では、`Default` は中間色が明るくなり、`PowerPointUI` は中間色が暗くなります。違いはグラデーションの色とストップに依存します。

標準の Aspose.Slides 出力が目的に合う場合は `Default` を選択してください。PowerPoint の外観と一致させることが優先事項の場合は `PowerPointUI` を試してください。両方の出力を目的の結果と比較し、どちらのモードも万能に優れているわけではありません。

## **FAQ**

**スライド全体ではなく、チャートや画像などの特定のシェイプだけをエクスポートするにはどうすればよいですか？**

Aspose.Slides は [個々のシェイプのサムネイル生成](/slides/ja/net/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバー上での並列変換はサポートされていますか？**

はい。スレッドまたはプロセスごとに個別のプレゼンテーション インスタンスを使用してください；[スレッド間で単一のインスタンスを共有しないでください](/slides/ja/net/multithreading/)。

**PNG へのエクスポート時の評価版の制限は何ですか？**

評価モードでは出力画像に透かしが追加され、[その他の制限](/slides/ja/net/licensing/) がライセンスが適用されるまで適用されます。