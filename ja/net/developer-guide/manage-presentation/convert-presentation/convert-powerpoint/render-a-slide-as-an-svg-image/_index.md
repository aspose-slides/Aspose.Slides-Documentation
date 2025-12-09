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
description: "Aspose.Slides for .NET を使用して PowerPoint スライドを SVG 画像としてレンダリングする方法を学びます。シンプルな C# コード例で高品質なビジュアルを実現。"
---

## **概要**

この記事では、**C# を使用して PowerPoint プレゼンテーションを SVG 形式に変換する方法**について説明します。以下のトピックについて取り上げます。

_フォーマット_: **PowerPoint**
- [C# PowerPoint を SVG に変換](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換](#csharp-powerpoint-to-svg)
- [C# PowerPoint ファイルを SVG に変換する方法](#csharp-powerpoint-to-svg)

_フォーマット_: **PPT**
- [C# PPT を SVG に変換](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換](#csharp-ppt-to-svg)
- [C# PPT ファイルを SVG に変換する方法](#csharp-ppt-to-svg)

_フォーマット_: **PPTX**
- [C# PPTX を SVG に変換](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換](#csharp-pptx-to-svg)
- [C# PPTX ファイルを SVG に変換する方法](#csharp-pptx-to-svg)

_フォーマット_: **ODP**
- [C# ODP を SVG に変換](#csharp-odp-to-svg)
- [C# ODP を SVG に変換](#csharp-odp-to-svg)
- [C# ODP ファイルを SVG に変換する方法](#csharp-odp-to-svg)

_フォーマット_: **Slide**
- [C# PowerPoint スライドを SVG に変換](#render-a-slide-as-an-svg-image)
- [C# PPT スライドを SVG に変換](#render-a-slide-as-an-svg-image)
- [C# PPTX スライドを SVG に変換](#render-a-slide-as-an-svg-image)
- [C# ODP スライドを SVG に変換](#render-a-slide-as-an-svg-image)

この記事で取り上げるその他のトピック。
- [参照](#see-also)

## **SVG 形式**
SVG—Scalable Vector Graphics の略称で、二次元画像を描画するために使用される標準的なグラフィックタイプまたは形式です。SVG は画像を XML のベクターとして保存し、その動作や外観を定義する詳細を含みます。

SVG は、拡張性、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなどの点で非常に高い基準を満たす数少ない画像形式の一つです。このため、Web 開発で広く利用されています。

次のようなケースで SVG ファイルを使用したくなることがあります。

- **プレゼンテーションを *非常に大きなサイズ* で印刷したい**。SVG 画像は任意の解像度やサイズに拡大でき、品質を損なうことなく何度でもサイズ変更が可能です。
- **スライド内のチャートやグラフを *異なる媒体やプラットフォーム* で使用したい**。ほとんどの閲覧環境が SVG を解釈できます。
- **画像サイズを *可能な限り小さく* したい**。SVG ファイルは、特にビットマップベース（JPEG や PNG）の高解像度画像に比べて一般的にサイズが小さくなります。

## **スライドを SVG 画像としてレンダリング**

Aspose.Slides for .NET を使用すると、プレゼンテーション内のスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成します。

_手順: PowerPoint から SVG への変換 (C#)_

次のサンプルコードは、.NET を使用した変換を説明しています。
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>手順: PowerPoint を SVG に変換 (C#)</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>手順: PPT を SVG に変換 (C#)</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>手順: PPTX を SVG に変換 (C#)</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>手順: ODP を SVG に変換 (C#)</strong></a>

_コード 手順:_

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
   * _.ppt_ 拡張子で **PPT** ファイルを _Presentation_ クラス内に読み込む。
   * _.pptx_ 拡張子で **PPTX** ファイルを _Presentation_ クラス内に読み込む。
   * _.odp_ 拡張子で **ODP** ファイルを _Presentation_ クラス内に読み込む。
   * _.pps_ 拡張子で **PPS** ファイルを _Presentation_ クラス内に読み込む。
2. プレゼンテーション内のすべてのスライドを反復処理します。
3. 各スライドを FileStream を使用して個別の SVG ファイルとして書き出します。

{{% alert color="primary" %}} 
Aspose.Slides for .NET の PPT から SVG への変換機能を実装した、[無料ウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg) をぜひお試しください。 
{{% /alert %}} 

以下の C# サンプルコードは、Aspose.Slides を使用して PowerPoint を SVG に変換する方法を示しています: 
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

**なぜ生成された SVG がブラウザー間で見た目が異なる可能性があるのでしょうか？**

特定の SVG 機能のサポートはブラウザーエンジンごとに実装が異なります。[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) パラメーターを使用すると、互換性の問題を緩和できます。

**スライドだけでなく、個別のシェイプも SVG にエクスポートできますか？**

はい。任意の [shape can be saved as a separate SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) で、アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを単一の SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオは「1 スライド → 1 SVG」です。複数スライドを単一の SVG キャンバスに結合する場合は、アプリケーションレベルでの後処理が必要です。

## **参照** 

この記事でも以下のトピックを取り上げています。コードは上記と同じです。

_フォーマット_: **PowerPoint**
- [C# PowerPoint を SVG に変換するコード](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換する API](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG にプログラムで変換](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換するライブラリ](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG として保存](#csharp-powerpoint-to-svg)
- [C# PowerPoint から SVG を生成](#csharp-powerpoint-to-svg)
- [C# PowerPoint から SVG を作成](#csharp-powerpoint-to-svg)
- [C# PowerPoint → SVG コンバータ](#csharp-powerpoint-to-svg)

_フォーマット_: **PPT**
- [C# PPT を SVG に変換するコード](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換する API](#csharp-ppt-to-svg)
- [C# PPT を SVG にプログラムで変換](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換するライブラリ](#csharp-ppt-to-svg)
- [C# PPT を SVG として保存](#csharp-ppt-to-svg)
- [C# PPT から SVG を生成](#csharp-ppt-to-svg)
- [C# PPT から SVG を作成](#csharp-ppt-to-svg)
- [C# PPT → SVG コンバータ](#csharp-ppt-to-svg)

_フォーマット_: **PPTX**
- [C# PPTX を SVG に変換するコード](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換する API](#csharp-pptx-to-svg)
- [C# PPTX を SVG にプログラムで変換](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換するライブラリ](#csharp-pptx-to-svg)
- [C# PPTX を SVG として保存](#csharp-pptx-to-svg)
- [C# PPTX から SVG を生成](#csharp-pptx-to-svg)
- [C# PPTX から SVG を作成](#csharp-pptx-to-svg)
- [C# PPTX → SVG コンバータ](#csharp-pptx-to-svg)

_フォーマット_: **ODP**
- [C# ODP を SVG に変換するコード](#csharp-odp-to-svg)
- [C# ODP を SVG に変換する API](#csharp-odp-to-svg)
- [C# ODP を SVG にプログラムで変換](#csharp-odp-to-svg)
- [C# ODP を SVG に変換するライブラリ](#csharp-odp-to-svg)
- [C# ODP を SVG として保存](#csharp-odp-to-svg)
- [C# ODP から SVG を生成](#csharp-odp-to-svg)
- [C# ODP から SVG を作成](#csharp-odp-to-svg)
- [C# ODP → SVG コンバータ](#csharp-odp-to-svg)