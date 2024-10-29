---
title: プレゼンテーションスライド全体の背景を画像として取得
type: docs
weight: 95
url: /ja/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- スライド
- 背景
- スライド背景
- 画像への背景
- PowerPoint
- PPT
- PPTX
- PowerPointプレゼンテーション
- C#
- VB.NET
- Aspose.Slides for .NET
---

PowerPointプレゼンテーションでは、スライドの背景は多くの要素で構成されることがあります。[スライド背景](/slides/ja/net/presentation-background/)として設定された画像に加え、最終的な背景はプレゼンテーションテーマ、カラースキーム、およびマスタースライドとレイアウトスライドに配置された図形によって影響を受ける可能性があります。

Aspose.Slides for .NETでは、プレゼンテーションスライド全体の背景を画像として抽出する簡単な方法は提供されていませんが、以下の手順に従ってこの作業を行うことができます：
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスを使用して、プレゼンテーションをロードします。
1. プレゼンテーションからスライドサイズを取得します。
1. スライドを選択します。
1. 一時的なプレゼンテーションを作成します。
1. 一時的なプレゼンテーションに同じスライドサイズを設定します。
1. 選択したスライドを一時的なプレゼンテーションにクローンします。
1. クローンされたスライドから図形を削除します。
1. クローンされたスライドを画像に変換します。

以下のコード例は、プレゼンテーションスライド全体の背景を画像として抽出します。
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```