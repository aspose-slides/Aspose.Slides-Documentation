---
title: ".NET で PPT を PPTX に変換"
linktitle: "PPT から PPTX"
type: docs
weight: 20
url: /ja/net/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- スライド を変換
- PPT を変換
- PPT から PPTX
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用した .NET で、レガシーな PPT プレゼンテーションを最新の PPTX に高速変換します — 明確なチュートリアル、無料の C# コードサンプル、Microsoft Office 不要。"
---

## **概要**

この記事では、C# とオンライン PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックを取り上げます。

- [C# で PPT を PPTX に変換](#convert-ppt-to-pptx)

## **.NET で PPT を PPTX に変換**

C# のサンプルコードで PPT を PPTX に変換する方法については、下記セクション [Convert PPT to PPTX](#convert-ppt-to-pptx) をご参照ください。コードは PPT ファイルを読み込み、PPTX 形式で保存します。保存形式を変更すれば、PDF、XPS、ODP、HTML など、さまざまな形式にも変換できます（これらの記事で詳しく解説しています）。

- [C# で PPT を PDF に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# で PPT を XPS に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# で PPT を HTML に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# で PPT を ODP に変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C# で PPT を画像に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千件の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、プログラムで実行するのが最適です。Aspose.Slides API なら数行のコードで実現できます。API は完全な互換性を備えており、次のような変換が可能です。

- マスタ、レイアウト、スライドの複雑な構造を変換。
- チャートを含むプレゼンテーションを変換。
- グループ シェイプ、矩形や楕円などのオート シェイプ、カスタム ジオメトリを持つシェイプを変換。
- オート シェイプのテクスチャや画像塗りつぶしスタイルを保持したプレゼンテーションを変換。
- プレースホルダー、テキスト フレーム、テキスト ホルダーを含むプレゼンテーションを変換。

{{% alert color="primary" %}} 

以下の [**Aspose.Slides PPT から PPTX への変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** を基盤に構築されており、基本的な PPT から PPTX への変換機能を実際に体験できます。Aspose.Slides Conversion はウェブ アプリで、PPT 形式のプレゼンテーション ファイルをドラッグ＆ドロップするだけで、PPTX に変換してダウンロードできます。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) の例もご確認ください。
{{% /alert %}} 


## **PPT を PPTX に変換**
PPT を PPTX に変換するには、ファイル名と保存形式を **Presentation** クラスの [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドに渡すだけです。以下の C# サンプルは、デフォルト オプションで PPT から PPTX へプレゼンテーションを変換します。
```c#
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTX プレゼンテーションを PPTX 形式で保存します
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


[**PPT と PPTX**](/slides/ja/net/ppt-vs-pptx/) のプレゼンテーション形式の違いや、[**Aspose.Slides が PPT から PPTX への変換をサポートしている方法**](/slides/ja/net/convert-ppt-to-pptx/) について詳しく読むことができます。

## **FAQ**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用していた古いバイナリ ファイル形式で、PPTX は Microsoft Office 2007 以降で導入された XML ベースの新しい形式です。PPTX はパフォーマンスが向上し、ファイル サイズが小さく、データ復旧機能も強化されています。

**.NET で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

**複数の PPT ファイルを一括で PPTX に変換できますか？**

はい、ループ処理で Aspose.Slides を呼び出すことで、複数の PPT ファイルをプログラム的に一括変換できます。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライド レイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は、PPT から PPTX への変換時にそのまま保持されます。

**PPT から PDF や HTML など他の形式へ変換できますか？**

はい、Aspose.Slides は PPT を PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式へも変換できます。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET は単体で動作する API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

**オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT から PPTX 変換ツール](https://products.aspose.app/slides/conversion/ppt-to-pptx) を使用すれば、ブラウザー上でコードを書くことなく直接変換できます。