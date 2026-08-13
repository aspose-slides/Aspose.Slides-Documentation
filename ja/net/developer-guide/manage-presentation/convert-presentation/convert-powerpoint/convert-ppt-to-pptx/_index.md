---
title: ".NET で PPT を PPTX に変換"
linktitle: "PPT から PPTX"
type: docs
weight: 20
url: /ja/net/convert-ppt-to-pptx/
keywords:
- "PowerPoint を変換"
- "プレゼンテーションを変換"
- "スライドを変換"
- "PPT を変換"
- "PPT から PPTX"
- "PPT を PPTX として保存"
- "PPT を PPTX にエクスポート"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides を使用して、レガシー PPT プレゼンテーションを .NET で高速に最新の PPTX に変換します — 分かりやすいチュートリアル、無料の C# コードサンプル、Microsoft Office に依存しません。"
---
## **概要**

この記事では、C# とオンラインの PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックがカバーされています。

- [.NET で PPT を PPTX に変換](#convert-ppt-to-pptx)

## **.NET で PPT を PPTX に変換**

C# のサンプルコードで PPT を PPTX に変換する方法については、以下のセクション、すなわち [Convert PPT to PPTX](#convert-ppt-to-pptx) を参照してください。このコードは PPT ファイルを読み込み、PPTX 形式で保存するだけです。保存形式を変更すれば、PDF、XPS、ODP、HTML など、他の多数の形式にも PPT ファイルを保存できます。これらの記事で説明しています。

- [.NET で PPT を PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf/)
- [.NET で PPT を XPS に変換](/slides/ja/net/convert-powerpoint-to-xps/)
- [.NET で PPT を HTML に変換](/slides/ja/net/convert-powerpoint-to-html/)
- [.NET で PPT を ODP に変換](/slides/ja/net/save-presentation/)
- [.NET で PPT を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**

Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千もの PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適な解決策はプログラムで実行することです。Aspose.Slides API を使えば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートしており、次のことが可能です。

- マスター、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループ シェイプ、オート シェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- テクスチャや画像の塗りつぶしスタイルを持つオートシェイプを含むプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換する。

{{% alert color="info" %}} 

以下の [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** を基に構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion は Web アプリで、PPT 形式のプレゼンテーションファイルをドロップすると、PPTX に変換されたものをダウンロードできます。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ja/conversion/) の例もご覧ください。

{{% /alert %}} 

## **PPT を PPTX に変換**

PPT を PPTX に変換するには、ファイル名と保存形式を [**Save**](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/methods/save/index) メソッドに、[**Presentation**](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスに渡すだけです。以下の C# コードサンプルは、デフォルトオプションで PPT から PPTX にプレゼンテーションを変換します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTX プレゼンテーションを PPTX 形式で保存します
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

[**PPT vs PPTX**](/slides/ja/net/ppt-vs-pptx/) プレゼンテーション形式の詳細と、[**Aspose.Slides supports PPT to PPTX conversion**](/slides/ja/net/convert-ppt-to-pptx/) の方法についてさらにお読みください。

## **よくある質問**

### PPT と PPTX の形式の違いは何ですか？

PPT は Microsoft PowerPoint が使用する古いバイナリ ファイル形式で、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さくなり、データ復旧機能が改善されています。

### .NET で PPT を PPTX に変換できますか？

はい、Aspose.Slides for .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

### Aspose.Slides は複数の PPT ファイルを PPTX にバッチ変換する機能をサポートしていますか？

はい、Aspose.Slides をループで使用して、複数の PPT ファイルをプログラムで PPTX に変換でき、バッチ変換シナリオに適しています。

### 変換後にコンテンツや書式は保持されますか？

Aspose.Slides はプレゼンテーションの高い忠実度を維持します。スライドレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換中に保持されます。

### PPT ファイルから PDF や HTML など他の形式に変換できますか？

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式を含む複数の形式に変換することをサポートしています。

### Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？

はい、Aspose.Slides for .NET はスタンドアロンの API であり、変換を実行するために Microsoft PowerPoint やサードパーティ製ソフトウェアは必要ありません。

### PPT を PPTX に変換するオンラインツールはありますか？

はい、コードを書くことなくブラウザー上で直接変換できる無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) Web アプリケーションを利用できます。