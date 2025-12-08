---
title: C# で PPT を PPTX に変換
linktitle: PPT を PPTX に変換
type: docs
weight: 20
url: /ja/net/convert-ppt-to-pptx/
keywords: "C# PPT を PPTX に変換, PowerPoint プレゼンテーションを変換, PPT を PPTX に変換, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint の PPT を C# または .NET で PPTX に変換"
---

## **概要**

この記事では、C# とオンライン PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックが取り上げられています。

- [C# で PPT を PPTX に変換](#convert-ppt-to-pptx)

## **C# PPT を PPTX に変換**

C# のサンプルコードで PPT を PPTX に変換する方法については、以下のセクション、すなわち[**PPT を PPTX に変換**](#convert-ppt-to-pptx) を参照してください。これは PPT ファイルを読み込み、PPTX 形式で保存するだけです。異なる保存形式を指定することで、PDF、XPS、ODP、HTML などの他の多数の形式でも PPT ファイルを保存できます。これらの記事で説明されています。

- [C# PPT を PDF に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# PPT を XPS に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# PPT を HTML に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# PPT を ODP に変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C# PPT を画像に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
古い PPT 形式を Aspose.Slides API で PPTX に変換します。数千の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、プログラムで実行するのが最適なソリューションです。Aspose.Slides API を使用すれば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に完全互換で変換でき、次のことが可能です。

- マスター、レイアウト、スライドの複雑な構造を変換。
- グラフを含むプレゼンテーションを変換。
- グループ シェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを変換。
- テクスチャや画像塗りつぶしスタイルを持つオートシェイプを変換。
- プレースホルダー、テキスト フレーム、テキスト ホルダーを含むプレゼンテーションを変換。

{{% alert color="primary" %}} 

以下の[**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** を基盤に構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion はウェブアプリで、PPT 形式のプレゼンテーション ファイルをドロップすると PPTX に変換してダウンロードできます。

他のライブ例は[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) をご参照ください。
{{% /alert %}} 

## **PPT を PPTX に変換**
PPT を PPTX に変換するには、[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドにファイル名と保存形式を渡すだけです。下の C# コード サンプルは、デフォルト オプションで PPT から PPTX にプレゼンテーションを変換します。
```c#
 // PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTX プレゼンテーションを PPTX 形式で保存します
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


[PPT と PPTX の違い](/slides/ja/net/ppt-vs-pptx/) や、[**Aspose.Slides が PPT から PPTX への変換をサポートする方法**](/slides/ja/net/convert-ppt-to-pptx/) について詳しく読むことができます。

## **FAQ**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリ形式で、PPTX は Microsoft Office 2007 で導入された XML ベースの新しい形式です。PPTX はパフォーマンスが向上し、ファイルサイズが小さくなり、データ復元が改善されています。

**.NET で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

**複数の PPT ファイルをバッチで PPTX に変換できますか？**

はい、Aspose.Slides をループ内で使用すれば、複数の PPT ファイルをプログラム的に PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高忠実度でプレゼンテーションを変換します。スライド レイアウト、アニメーション、シェイプ、グラフ、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

**PPT から PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式への変換もサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

**オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリを使用すれば、コードを書かずにブラウザー上で直接変換できます。