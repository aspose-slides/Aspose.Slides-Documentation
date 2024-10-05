---
title: .NETでプレゼンテーションを作成する
linktitle: プレゼンテーションを作成する
type: docs
weight: 10
url: /net/create-presentation/
keywords: "PowerPointを作成, PPTX, PPT, プレゼンテーションを作成, プレゼンテーションを初期化, C#, .NET"
description: "C#でプログラムでPowerPointプレゼンテーションを作成する例（PPT, PPTX, ODPなど）。"
---

## PowerPointプレゼンテーションを作成する
選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

1. Presentationクラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shapesオブジェクトが公開するAddAutoShapeメソッドを使用して、ラインタイプのAutoShapeを追加します。
1. 修正したプレゼンテーションをPPTXファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します
    ISlide slide = presentation.Slides[0];

    // ライントタイプのオートシェイプを追加します
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## プレゼンテーションを作成して保存する

<a name="csharp-create-save-presentation"><strong>手順: C#でプレゼンテーションを作成して保存する</strong></a>

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. _Presentation_を[SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)がサポートする任意の形式で保存します。

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## プレゼンテーションを開いて保存する

<a name="csharp-open-save-presentation"><strong>手順: C#でプレゼンテーションを開いて保存する</strong></a>

1. 任意の形式（PPT、PPTX、ODPなど）で[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. _Presentation_を[SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)がサポートする任意の形式で保存します。

```c#
// PPT、PPTX、ODPなどの任意のサポートファイルをPresentationに読み込みます
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```