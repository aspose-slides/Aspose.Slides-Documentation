---
title: ".NET でプレゼンテーション スライドを SVG 画像としてレンダリング"
linktitle: "スライドから SVG へ"
type: docs
weight: 50
url: /ja/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint を SVG に変換"
- "プレゼンテーションを SVG に変換"
- "スライドを SVG に変換"
- "PPT を SVG に変換"
- "PPTX を SVG に変換"
- "PPT を SVG として保存"
- "PPTX を SVG として保存"
- "PPT を SVG にエクスポート"
- "PPTX を SVG にエクスポート"
- "スライドをレンダリング"
- "スライドを変換"
- "スライドをエクスポート"
- "ベクター画像"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して PowerPoint スライドを SVG 画像としてレンダリングする方法を学びます。シンプルな C# コード例で高品質なビジュアルを実現できます。"
---

## **概要**

この記事では、**C# を使用して PowerPoint プレゼンテーションを SVG 形式に変換する方法**について説明します。以下のトピックを取り上げます。

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
- [C# PowerPoint スライドを SVG に変換](#render-a-slide-as-an-svg-image)
- [C# PPT スライドを SVG に変換](#render-a-slide-as-an-svg-image)
- [C# PPTX スライドを SVG に変換](#render-a-slide-as-an-svg-image)
- [C# ODP スライドを SVG に変換](#render-a-slide-as-an-svg-image)

この記事で扱われているその他のトピック。
- [参照](#see-also)

## **SVG 形式**
SVG（Scalable Vector Graphics の略称）は、2 次元画像を描画するために使用される標準的なグラフィックタイプまたはフォーマットです。SVG は画像をベクターとして XML に保存し、動作や外観を定義する詳細情報を含みます。

SVG は、拡張性、インタラクティブ性、パフォーマンス、アクセシビリティ、プログラマビリティなど、極めて高い基準を満たす数少ない画像フォーマットのひとつです。そのため、ウェブ開発で広く使用されています。

以下のようなケースで SVG ファイルを使用したくなることがあります。

- **プレゼンテーションを*非常に大きなサイズ*で印刷する**。SVG 画像は任意の解像度やサイズに拡大でき、品質を損なうことなく何度でもサイズ変更が可能です。
- **スライドのチャートやグラフを*異なる媒体やプラットフォーム*で使用する**。ほとんどの閲覧ソフトは SVG ファイルを解釈できます。
- **画像を*可能な限り小さなサイズ*で使用する**。SVG ファイルは、特にビットマップ（JPEG や PNG）ベースのフォーマットに比べて、一般的に高解像度の同等品よりもサイズが小さくなります。

## **スライドを SVG 画像としてレンダリング**
Aspose.Slides for .NET を使用すると、プレゼンテーション内のスライドを SVG 画像としてエクスポートできます。以下の手順で SVG 画像を生成してください。

_Steps: PowerPoint to SVG Conversions in C#_

以下のサンプルコードは、.NET を使用したこれらの変換方法を説明しています。
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>手順: C# で PowerPoint を SVG に変換</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>手順: C# で PPT を SVG に変換</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>手順: C# で PPTX を SVG に変換</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>手順: C# で ODP を SVG に変換</strong></a>

_Code Steps:_

1. Presentation クラスのインスタンスを作成します。
   * _.ppt_ 拡張子で **PPT** ファイルを _Presentation_ クラスにロードします。
   * _.pptx_ 拡張子で **PPTX** ファイルを _Presentation_ クラスにロードします。
   * _.odp_ 拡張子で **ODP** ファイルを _Presentation_ クラスにロードします。
   * _.pps_ 拡張子で **PPS** ファイルを _Presentation_ クラスにロードします。
2. プレゼンテーション内のすべてのスライドを反復処理します。
3. 各スライドを FileStream を使用して個別の SVG ファイルに書き込みます。

{{% alert color="primary" %}} 

当社の[無料ウェブアプリケーション](https://products.aspose.app/slides/conversion/ppt-to-svg)を試してみることをお勧めします。このアプリでは、Aspose.Slides for .NET の PPT から SVG への変換機能を実装しています。

{{% /alert %}} 

以下の C# サンプルコードは、Aspose.Slides を使用して PowerPoint を SVG に変換する方法を示しています。 
``` csharp
// Presentation オブジェクトは PPT、PPTX、ODP などの PowerPoint 形式を読み込むことができます。
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


## **FAQ**

**なぜ生成された SVG がブラウザー間で見た目が異なることがあるのでしょうか？**

特定の SVG 機能のサポートは、ブラウザーエンジンごとに実装が異なります。[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) パラメーターを使用すると、互換性の問題を緩和できます。

**スライドだけでなく、個々のシェイプも SVG にエクスポートできますか？**

はい。任意の[シェイプを個別の SVG として保存](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)でき、アイコンやピクトグラム、グラフィックの再利用に便利です。

**複数のスライドを 1 つの SVG（ストリップ/ドキュメント）に結合できますか？**

標準的なシナリオは 1 スライド → 1 SVGです。複数のスライドを 1 つの SVG キャンバスに結合することは、アプリケーションレベルでの後処理として行われます。

## **関連項目**

この記事では、以下のトピックも取り上げています。コードは上記と同じです。

_Format_: **PowerPoint**
- [C# PowerPoint を SVG に変換コード](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換 API](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG にプログラム的に変換](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG に変換ライブラリ](#csharp-powerpoint-to-svg)
- [C# PowerPoint を SVG として保存](#csharp-powerpoint-to-svg)
- [C# PowerPoint から SVG を生成](#csharp-powerpoint-to-svg)
- [C# PowerPoint から SVG を作成](#csharp-powerpoint-to-svg)
- [C# PowerPoint 用 SVG コンバータ](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT を SVG に変換コード](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換 API](#csharp-ppt-to-svg)
- [C# PPT を SVG にプログラム的に変換](#csharp-ppt-to-svg)
- [C# PPT を SVG に変換ライブラリ](#csharp-ppt-to-svg)
- [C# PPT を SVG として保存](#csharp-ppt-to-svg)
- [C# PPT から SVG を生成](#csharp-ppt-to-svg)
- [C# PPT から SVG を作成](#csharp-ppt-to-svg)
- [C# PPT 用 SVG コンバータ](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX を SVG に変換コード](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換 API](#csharp-pptx-to-svg)
- [C# PPTX を SVG にプログラム的に変換](#csharp-pptx-to-svg)
- [C# PPTX を SVG に変換ライブラリ](#csharp-pptx-to-svg)
- [C# PPTX を SVG として保存](#csharp-pptx-to-svg)
- [C# PPTX から SVG を生成](#csharp-pptx-to-svg)
- [C# PPTX から SVG を作成](#csharp-pptx-to-svg)
- [C# PPTX 用 SVG コンバータ](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP を SVG に変換コード](#csharp-odp-to-svg)
- [C# ODP を SVG に変換 API](#csharp-odp-to-svg)
- [C# ODP を SVG にプログラム的に変換](#csharp-odp-to-svg)
- [C# ODP を SVG に変換ライブラリ](#csharp-odp-to-svg)
- [C# ODP を SVG として保存](#csharp-odp-to-svg)
- [C# ODP から SVG を生成](#csharp-odp-to-svg)
- [C# ODP から SVG を作成](#csharp-odp-to-svg)
- [C# ODP 用 SVG コンバータ](#csharp-odp-to-svg)