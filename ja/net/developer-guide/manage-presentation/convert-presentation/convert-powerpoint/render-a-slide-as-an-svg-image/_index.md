---
title: C#でスライドをSVG画像としてレンダリングする
linktitle: C#でスライドをSVG画像としてレンダリングする
type: docs
weight: 50
url: /ja/net/render-a-slide-as-an-svg-image/
description: この記事では、C#を使用してPowerPointプレゼンテーションをSVG形式に変換する方法について説明します。PPT、PPTX、ODP形式をSVG画像に変換できます。
keywords: C# PowerPointをSVGに変換, C# PPTをSVGに, C# PPTXをSVGに
---

## 概要

この記事では、**C#を使用してPowerPointプレゼンテーションをSVG形式に変換する方法**について説明します。以下のトピックを扱っています。

_形式_: **PowerPoint**
- [C# PowerPointをSVGに](#csharp-powerpoint-to-svg)
- [C# PowerPointをSVGに変換](#csharp-powerpoint-to-svg)
- [C# PowerPointファイルをSVGに変換する方法](#csharp-powerpoint-to-svg)

_形式_: **PPT**
- [C# PPTをSVGに](#csharp-ppt-to-svg)
- [C# PPTをSVGに変換](#csharp-ppt-to-svg)
- [C# PPTファイルをSVGに変換する方法](#csharp-ppt-to-svg)

_形式_: **PPTX**
- [C# PPTXをSVGに](#csharp-pptx-to-svg)
- [C# PPTXをSVGに変換](#csharp-pptx-to-svg)
- [C# PPTXファイルをSVGに変換する方法](#csharp-pptx-to-svg)

_形式_: **ODP**
- [C# ODPをSVGに](#csharp-odp-to-svg)
- [C# ODPをSVGに変換](#csharp-odp-to-svg)
- [C# ODPファイルをSVGに変換する方法](#csharp-odp-to-svg)

_形式_: **スライド**
- [C# PowerPointスライドをSVGに変換](#render-a-slide-as-an-svg-image)
- [C# PPTスライドをSVGに変換](#render-a-slide-as-an-svg-image)
- [C# PPTXスライドをSVGに変換](#render-a-slide-as-an-svg-image)
- [C# ODPスライドをSVGに変換](#render-a-slide-as-an-svg-image)

この記事で扱うその他のトピック。
- [参照](#see-also)

## SVG形式
SVGは、Scalable Vector Graphicsの略で、二次元画像をレンダリングするために使用される標準のグラフィックタイプまたは形式です。SVGは、動作や外観を定義する詳細を持ったXMLのベクターとして画像を保存します。

SVGは、拡張性、相互作用性、パフォーマンス、アクセシビリティ、プログラマビリティなどの点で非常に高い基準を満たす数少ない画像形式の1つです。これらの理由から、Web開発で一般的に使用されます。

次の場合にSVGファイルを使用することを検討するかもしれません。

- **プレゼンテーションを*非常に大きなフォーマット*で印刷する必要がある場合。** SVG画像は、任意の解像度やレベルに拡張できます。SVG画像は、品質を損なうことなく必要に応じて何度でもサイズ変更できます。
- **異なる媒体やプラットフォームでスライドのチャートやグラフを使用する場合。** 多くのリーダーはSVGファイルを解釈できます。
- ***可能な限り最小の画像サイズ*を使用する場合。** SVGファイルは一般的に、他の形式の高解像度の同等物よりも小さいです、特にビットマップ（JPEGやPNG）に基づく形式のものは特にそうです。

## スライドをSVG画像としてレンダリングする

Aspose.Slides for .NETを使用すると、プレゼンテーション内のスライドをSVG画像としてエクスポートできます。SVG画像を生成するための手順は以下のとおりです。

_手順: C#でのPowerPointからSVGへの変換_

以下のサンプルコードは、.NETを使用したこれらの変換を説明します。
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>手順: C#でPowerPointをSVGに変換する</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>手順: C#でPPTをSVGに変換する</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>手順: C#でPPTXをSVGに変換する</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>手順: C#でODPをSVGに変換する</strong></a>

_コード手順:_

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
   * _.ppt_拡張子を使用して、_Presentation_クラス内に**PPT**ファイルをロードします。
   * _.pptx_拡張子を使用して、_Presentation_クラス内に**PPTX**ファイルをロードします。
   * _.odp_拡張子を使用して、_Presentation_クラス内に**ODP**ファイルをロードします。
   * _.pps_拡張子を使用して、_Presentation_クラス内に**PPS**ファイルをロードします。
2. プレゼンテーション内のすべてのスライドを繰り返します。
3. 各スライドをFileStreamを介して自身のSVGファイルに書き込みます。

{{% alert color="primary" %}} 

私たちの[無料Webアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg)を試してみることを検討するかもしれません。ここでは、Aspose.Slides for .NETからPPTをSVGに変換する機能を実装しています。

{{% /alert %}} 

このC#のサンプルコードは、Aspose.Slidesを使用してPowerPointをSVGに変換する方法を示しています： 

``` csharp
// Presentationオブジェクトは、PPT、PPTX、ODPなどのPowerPoint形式をロードできます。
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## 参照 

この記事では、次のトピックも扱っています。コードは上記と同じです。

_形式_: **PowerPoint**
- [C# PowerPointをSVGにコード](#csharp-powerpoint-to-svg)
- [C# PowerPointをSVGにAPI](#csharp-powerpoint-to-svg)
- [C# PowerPointをプログラムでSVGに変換](#csharp-powerpoint-to-svg)
- [C# PowerPointをSVGライブラリ](#csharp-powerpoint-to-svg)
- [C# PowerPointをSVGとして保存](#csharp-powerpoint-to-svg)
- [C# PowerPointからSVGを生成](#csharp-powerpoint-to-svg)
- [C# PowerPointからSVGを作成](#csharp-powerpoint-to-svg)
- [C# PowerPointをSVGコンバータ](#csharp-powerpoint-to-svg)

_形式_: **PPT**
- [C# PPTをSVGにコード](#csharp-ppt-to-svg)
- [C# PPTをSVGにAPI](#csharp-ppt-to-svg)
- [C# PPTをプログラムでSVGに変換](#csharp-ppt-to-svg)
- [C# PPTをSVGライブラリ](#csharp-ppt-to-svg)
- [C# PPTをSVGとして保存](#csharp-ppt-to-svg)
- [C# PPTからSVGを生成](#csharp-ppt-to-svg)
- [C# PPTからSVGを作成](#csharp-ppt-to-svg)
- [C# PPTをSVGコンバータ](#csharp-ppt-to-svg)

_形式_: **PPTX**
- [C# PPTXをSVGにコード](#csharp-pptx-to-svg)
- [C# PPTXをSVGにAPI](#csharp-pptx-to-svg)
- [C# PPTXをプログラムでSVGに変換](#csharp-pptx-to-svg)
- [C# PPTXをSVGライブラリ](#csharp-pptx-to-svg)
- [C# PPTXをSVGとして保存](#csharp-pptx-to-svg)
- [C# PPTXからSVGを生成](#csharp-pptx-to-svg)
- [C# PPTXからSVGを作成](#csharp-pptx-to-svg)
- [C# PPTXをSVGコンバータ](#csharp-pptx-to-svg)

_形式_: **ODP**
- [C# ODPをSVGにコード](#csharp-odp-to-svg)
- [C# ODPをSVGにAPI](#csharp-odp-to-svg)
- [C# ODPをプログラムでSVGに変換](#csharp-odp-to-svg)
- [C# ODPをSVGライブラリ](#csharp-odp-to-svg)
- [C# ODPをSVGとして保存](#csharp-odp-to-svg)
- [C# ODPからSVGを生成](#csharp-odp-to-svg)
- [C# ODPからSVGを作成](#csharp-odp-to-svg)
- [C# ODPをSVGコンバータ](#csharp-odp-to-svg)