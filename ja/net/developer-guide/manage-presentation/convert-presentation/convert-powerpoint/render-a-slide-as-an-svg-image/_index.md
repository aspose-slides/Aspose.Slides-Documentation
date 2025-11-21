---
title: .NET でプレゼンテーションスライドを SVG 画像としてレンダリング
linktitle: スライドを SVG に変換
type: docs
weight: 50
url: /ja/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint を SVG に変換
- プレゼンテーションを SVG に変換
- スライドを SVG に変換
- PPT を SVG に変換
- PPTX を SVG に変換
- PPT を SVG として保存
- PPTX を SVG として保存
- PPT を SVG にエクスポート
- PPTX を SVG にエクスポート
- スライドをレンダリング
- スライドを変換
- スライドをエクスポート
- ベクター画像
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドを SVG 画像としてレンダリングする方法を学びます。シンプルな C# コード例で高品質なビジュアルを実現します。"
---

## **概要**

このドキュメントでは、**C# を使用して PowerPoint プレゼンテーションを SVG 形式に変換する**方法について説明します。以下のトピックを取り上げます。

_Format_: **PowerPoint**
- [C# PowerPoint を SVG に変換](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT を SVG に変換](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX を SVG に変換](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP を SVG に変換](#csharp-odp-to-svg)
- [C# ODP を SVG に変換](#csharp-odp-to-svg)
- [C# ODP を SVG に変換](#csharp-odp-to-svg)

_Format_: **Slide**
- [C# スライドを SVG 画像として変換](#render-a-slide-as-an-svg-image)
- [C# スライドを SVG 画像として変換](#render-a-slide-as-an-svg-image)
- [C# スライドを SVG 画像として変換](#render-a-slide-as-an-svg-image)
- [C# スライドを SVG 画像として変換](#render-a-slide-as-an-svg-image)

この記事で取り上げるその他のトピックです。
- [参照](#see-also)

## **SVG 形式**
SVG（Scalable Vector Graphics の略称）は、二次元画像を描画するために使用される標準的なグラフィックタイプまたはフォーマットです。SVG は画像を XML のベクターとして保存し、動作や外観を定義する詳細情報を含みます。

SVG は、スケーラビリティ、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、非常に高い基準を満たす数少ない画像フォーマットのひとつです。このため、ウェブ開発で広く利用されています。

以下のような場合に SVG ファイルを使用したいかもしれません。

- **プレゼンテーションを *非常に大きな形式* で印刷**します。
- **スライドのチャートやグラフを *異なる媒体やプラットフォーム* で使用**します。
- **画像を *可能な限り最小サイズ* で使用**します。

## **スライドを SVG 画像としてレンダリング**

Aspose.Slides for .NET を使用すると、プレゼンテーション内のスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成してください。

_Steps: PowerPoint to SVG Conversions in C#_

以下のサンプルコードは、.NET を使用したこれらの変換を説明しています。
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>手順: C# で PowerPoint を SVG に変換</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>手順: C# で PPT を SVG に変換</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>手順: C# で PPTX を SVG に変換</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>手順: C# で ODP を SVG に変換</strong></a>

_Code Steps:_

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
   * _.ppt_ 拡張子で _Presentation_ クラス内に **PPT** ファイルを読み込みます。
   * _.pptx_ 拡張子で _Presentation_ クラス内に **PPTX** ファイルを読み込みます。
   * _.odp_ 拡張子で _Presentation_ クラス内に **ODP** ファイルを読み込みます。
   * _.pps_ 拡張子で _Presentation_ クラス内に **PPS** ファイルを読み込みます。
2. プレゼンテーション内のすべてのスライドを反復処理します。
3. 各スライドを FileStream を使用して個別の SVG ファイルに書き込みます。

{{% alert color="primary" %}} 

Aspose.Slides for .NET の PPT から SVG への変換機能を実装した、[無料のウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg) を試してみてください。

{{% /alert %}} 

この C# のサンプルコードは、Aspose.Slides を使用して PowerPoint を SVG に変換する方法を示します。 
``` csharp
// Presentation オブジェクトは PPT、PPTX、ODP などの PowerPoint 形式をロードできます。
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


## **よくある質問**

**なぜ生成された SVG がブラウザ間で見た目が異なることがあるのでしょうか？**

特定の SVG 機能のサポートは、ブラウザエンジンによって異なる方法で実装されています。[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) のパラメータを使用すると、互換性の問題を緩和できます。

**スライドだけでなく個々のシェイプも SVG にエクスポートできますか？**

はい。任意の [シェイプは個別の SVG として保存できます](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) は、アイコン、ピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを 1つの SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオは、1 スライド → 1 SVG です。複数のスライドを 1 つの SVG キャンバスに結合することは、アプリケーションレベルで実行されるポストプロセスです。

## **参照** 

この記事ではこれらのトピックも取り上げています。コードは上記と同じです。

_Format_: **PowerPoint**
- [C# PowerPoint を SVG に変換するコード](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換する API](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換するプログラム的手法](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換するライブラリ](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG として保存](#csharp-powerpoint-to-svg)
- [C# PowerPoint から SVG を生成](#csharp-powerpoint-to-svg)
- [C# PowerPoint から SVG を作成](#csharp-powerpoint-to-svg)
- [C# PowerPoint SVG コンバータ](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT を SVG に変換するコード](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換する API](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換するプログラム的手法](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換するライブラリ](#csharp-ppt-to-svg)
- [C# PPT を SVG として保存](#csharp-ppt-to-svg)
- [C# PPT から SVG を生成](#csharp-ppt-to-svg)
- [C# PPT から SVG を作成](#csharp-ppt-to-svg)
- [C# PPT SVG コンバータ](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX を SVG に変換するコード](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換する API](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換するプログラム的手法](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換するライブラリ](#csharp-pptx-to-svg)
- [C# PPTX を SVG として保存](#csharp-pptx-to-svg)
- [C# PPTX から SVG を生成](#csharp-pptx-to-svg)
- [C# PPTX から SVG を作成](#csharp-pptx-to-svg)
- [C# PPTX SVG コンバータ](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP を SVG に変換するコード](#csharp-odp-to-svg)
- [C# ODP を SVG に変換する API](#csharp-odp-to-svg)
- [C# ODP を SVG に変換するプログラム的手法](#csharp-odp-to-svg)
- [C# ODP を SVG に変換するライブラリ](#csharp-odp-to-svg)
- [C# ODP を SVG として保存](#csharp-odp-to-svg)
- [C# ODP から SVG を生成](#csharp-odp-to-svg)
- [C# ODP から SVG を作成](#csharp-odp-to-svg)
- [C# ODP SVG コンバータ](#csharp-odp-to-svg)