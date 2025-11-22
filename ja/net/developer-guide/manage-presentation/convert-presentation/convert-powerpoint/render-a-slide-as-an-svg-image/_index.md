---
title: C# でスライドを SVG 画像としてレンダリング
linktitle: スライドを SVG 画像としてレンダリング
type: docs
weight: 50
url: /ja/net/render-a-slide-as-an-svg-image/
description: この項目では、C# を使用して PowerPoint プレゼンテーションを SVG 形式に変換する方法を説明します。PPT、PPTX、ODP 形式を SVG 画像に変換できます。
keywords: C# PowerPoint を SVG に変換, C# PPT を SVG に変換, C# PPTX を SVG に変換
---

## **概要**

このドキュメントでは、**C# を使用して PowerPoint プレゼンテーションを SVG 形式に変換する方法**について説明します。以下のトピックを取り上げています。

_形式_: **PowerPoint**
- [C# PowerPoint を SVG に変換](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換](#csharp-powerpoint-to-svg)

_形式_: **PPT**
- [C# PPT を SVG に変換](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換](#csharp-ppt-to-svg)

_形式_: **PPTX**
- [C# PPTX を SVG に変換](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換](#csharp-pptx-to-svg)

_形式_: **ODP**
- [C# ODP を SVG に変換](#csharp-odp-to-svg)
- [C# ODP を SVG に変換](#csharp-odp-to-svg)
- [C# ODP を SVG に変換](#csharp-odp-to-svg)

_形式_: **Slide**
- [C# PowerPoint スライドを SVG に変換](#render-a-slide-as-an-svg-image)
- [C# PPT スライドを SVG に変換](#render-a-slide-as-an-svg-image)
- [C# PPTX スライドを SVG に変換](#render-a-slide-as-an-svg-image)
- [C# ODP スライドを SVG に変換](#render-a-slide-as-an-svg-image)

この記事で取り上げているその他のトピック。
- [関連項目](#see-also)

## **SVG 形式**
SVG（Scalable Vector Graphics の略称）は、2 次元画像を描画するために使用される標準的なグラフィックタイプ／形式です。SVG は画像を XML のベクトルとして保存し、動作や外観を定義する詳細情報を含みます。

SVG は、拡張性、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、非常に高い基準を満たす数少ない画像形式のひとつです。そのため、ウェブ開発で広く利用されています。

以下のようなケースで SVG ファイルを使用したい場合があります。

- **プレゼンテーションを *非常に大きなサイズ* で印刷**。SVG 画像は任意の解像度やサイズに拡大でき、品質を損なうことなく何度でもリサイズできます。
- **スライド内のチャートやグラフを *さまざまな媒体やプラットフォーム* で使用**。ほとんどの閲覧者が SVG ファイルを解釈できます。
- **可能な限り *小さなサイズ* の画像を使用**。SVG ファイルは、特にビットマップベース（JPEG や PNG）の高解像度版に比べて一般的にサイズが小さくなります。

## **スライドを SVG 画像としてレンダリング**

Aspose.Slides for .NET を使用すると、プレゼンテーション内のスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成します。

_手順: C# で PowerPoint を SVG に変換_

以下のサンプルコードは、.NET を使用した変換方法を示しています。
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>手順: C# で PowerPoint を SVG に変換</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>手順: C# で PPT を SVG に変換</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>手順: C# で PPTX を SVG に変換</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>手順: C# で ODP を SVG に変換</strong></a>

**コード手順:**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
   - _.ppt_ 拡張子で _Presentation_ クラスに **PPT** ファイルをロードします。  
   - _.pptx_ 拡張子で _Presentation_ クラスに **PPTX** ファイルをロードします。  
   - _.odp_ 拡張子で _Presentation_ クラスに **ODP** ファイルをロードします。  
   - _.pps_ 拡張子で _Presentation_ クラスに **PPS** ファイルをロードします。  
2. プレゼンテーション内のすべてのスライドを反復処理します。  
3. 各スライドを FileStream を介して個別の SVG ファイルに書き出します。

{{% alert color="primary" %}} 

当社の[無料のウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg)をぜひお試しください。Aspose.Slides for .NET の PPT から SVG への変換機能を実装しています。

{{% /alert %}} 

以下の C# サンプルコードは、Aspose.Slides を使用して PowerPoint を SVG に変換する方法を示しています。  
``` csharp
// Presentation オブジェクトは PPT、PPTX、ODP などの PowerPoint フォーマットを読み込むことができます。
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

**なぜ生成された SVG はブラウザ間で見た目が異なる可能性があるのでしょうか？**

特定の SVG 機能のサポートはブラウザエンジンごとに実装が異なります。[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) パラメータを使用すると、互換性の問題を緩和できます。

**スライドだけでなく個々のシェイプも SVG としてエクスポートできますか？**

はい。任意の[shape can be saved as a separate SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)で、アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを 1 つの SVG（ストリップ／ドキュメント）に結合できますか？**

標準的なシナリオは「1 スライド → 1 SVG」です。複数スライドを単一の SVG キャンバスに結合する場合は、アプリケーションレベルでのポストプロセスが必要となります。

## **関連項目** 

この記事でもこれらのトピックを取り上げています。コードは上記と同じです。

_形式_: **PowerPoint**
- [C# PowerPoint を SVG に変換コード](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換 API](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG にプログラム的に変換](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換ライブラリ](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG として保存](#csharp-powerpoint-to-svg)
- [C# PowerPoint から SVG を生成](#csharp-powerpoint-to-svg)
- [C# PowerPoint から SVG を作成](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG コンバータ](#csharp-powerpoint-to-svg)

_形式_: **PPT**
- [C# PPT を SVG に変換コード](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換 API](#csharp-ppt-to-svg)
- [C# PPT を SVG にプログラム的に変換](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換ライブラリ](#csharp-ppt-to-svg)
- [C# PPT を SVG として保存](#csharp-ppt-to-svg)
- [C# PPT から SVG を生成](#csharp-ppt-to-svg)
- [C# PPT から SVG を作成](#csharp-ppt-to-svg)
- [C# PPT to SVG コンバータ](#csharp-ppt-to-svg)

_形式_: **PPTX**
- [C# PPTX を SVG に変換コード](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換 API](#csharp-pptx-to-svg)
- [C# PPTX を SVG にプログラム的に変換](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換ライブラリ](#csharp-pptx-to-svg)
- [C# PPTX を SVG として保存](#csharp-pptx-to-svg)
- [C# PPTX から SVG を生成](#csharp-pptx-to-svg)
- [C# PPTX から SVG を作成](#csharp-pptx-to-svg)
- [C# PPTX to SVG コンバータ](#csharp-pptx-to-svg)

_形式_: **ODP**
- [C# ODP を SVG に変換コード](#csharp-odp-to-svg)
- [C# ODP を SVG に変換 API](#csharp-odp-to-svg)
- [C# ODP を SVG にプログラム的に変換](#csharp-odp-to-svg)
- [C# ODP を SVG に変換ライブラリ](#csharp-odp-to-svg)
- [C# ODP を SVG として保存](#csharp-odp-to-svg)
- [C# ODP から SVG を生成](#csharp-odp-to-svg)
- [C# ODP から SVG を作成](#csharp-odp-to-svg)
- [C# ODP to SVG コンバータ](#csharp-odp-to-svg)