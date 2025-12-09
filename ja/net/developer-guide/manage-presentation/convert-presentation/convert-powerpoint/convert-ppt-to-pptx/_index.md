---
title: .NETでPPTをPPTXに変換
linktitle: PPTからPPTXへ
type: docs
weight: 20
url: /ja/net/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT から PPTX へ
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でレガシーな PPT プレゼンテーションを最新の PPTX に高速変換 — 明確なチュートリアル、無料の C# コードサンプル、Microsoft Office への依存は不要です。"
---

## **概要**

この記事では、C# とオンライン PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックが取り上げられています。

- [C#でPPTをPPTXに変換](#convert-ppt-to-pptx)

## **C#でPPTをPPTXに変換**

C# のサンプルコードで PPT を PPTX に変換する方法については、以下のセクション、すなわち [PPTをPPTXに変換](#convert-ppt-to-pptx) を参照してください。これは PPT ファイルを読み込み、PPTX 形式で保存するだけです。別の保存形式を指定することで、PDF、XPS、ODP、HTML などの多くの形式にも PPT ファイルを保存できます。これらの記事で説明されています。

- [C#でPPTをPDFに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C#でPPTをXPSに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C#でPPTをHTMLに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C#でPPTをODPに変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C#でPPTを画像に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPT から PPTX 変換について**

Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。何千もの PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適な解決策はプログラムで行うことです。Aspose.Slides API を使用すれば、数行のコードだけで実行可能です。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートしており、以下が可能です：

- マスター、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループシェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- テクスチャや画像で塗りつぶしスタイルが設定されたオートシェイプを含むプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換する。

{{% alert color="primary" %}} 

以下の [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** をベースに構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion はウェブアプリで、PPT 形式のプレゼンテーションファイルをドロップすると、PPTX に変換されたファイルをダウンロードできます。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) の例をご覧ください。

{{% /alert %}} 

## **PPT を PPTX に変換**

PPT を PPTX に変換するには、ファイル名と保存形式を [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドに渡すだけです。このメソッドは [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのものです。以下の C# コードサンプルは、デフォルトオプションを使用して PPT から PPTX にプレゼンテーションを変換します。

```c#
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTX プレゼンテーションを PPTX 形式で保存します
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


プレゼンテーション形式の [**PPT vs PPTX**](/slides/ja/net/ppt-vs-pptx/) について詳しく読み、[**Aspose.Slides supports PPT to PPTX conversion**](/slides/ja/net/convert-ppt-to-pptx/) 方法をご確認ください。

## **よくある質問**

**PPT と PPTX 形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリファイル形式で、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX ファイルはパフォーマンスの向上、ファイルサイズの削減、データ復旧の改善を提供します。

**.NET で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

**Aspose.Slides は複数の PPT ファイルを PPTX にバッチ変換できますか？**

はい、Aspose.Slides をループ内で使用して、複数の PPT ファイルをプログラムで PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides はプレゼンテーションの高い忠実度を維持します。スライドレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

**PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式を含む複数の形式に変換することをサポートしています。

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET はスタンドアロンの API であり、変換を実行するために Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

**PPT を PPTX に変換するオンラインツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリケーションを使用すれば、コードを書かずにブラウザー上で直接変換を実行できます。