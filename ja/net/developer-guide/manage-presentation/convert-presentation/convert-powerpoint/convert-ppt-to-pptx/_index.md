---
title: .NET で PPT を PPTX に変換
linktitle: PPT を PPTX に変換
type: docs
weight: 20
url: /ja/net/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT を PPTX に変換
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でレガシー PPT プレゼンテーションをモダンな PPTX に高速変換 — 明確なチュートリアル、無料の C# コードサンプル、Microsoft Office への依存なし。"
---

## **概要**

この記事では、C# とオンライン PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックが取り上げられます。

- [C#でPPTをPPTXに変換](#convert-ppt-to-pptx)

## **C# で PPT を PPTX に変換**

C# の PPT を PPTX に変換するサンプルコードについては、以下のセクション（[Convert PPT to PPTX](#convert-ppt-to-pptx)）をご覧ください。これは PPT ファイルを読み込み、PPTX 形式で保存するだけです。保存形式を指定することで、PDF、XPS、ODP、HTML などのさまざまな形式にも PPT ファイルを保存できます。これらの記事で説明しています。

- [C#でPPTをPDFに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C#でPPTをXPSに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C#でPPTをHTMLに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C#でPPTをODPに変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C#でPPTを画像に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**

Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適な方法はプログラムで実行することです。Aspose.Slides API を使用すれば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートしており、以下が可能です：

- マスター、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループ シェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- テクスチャや画像の塗りつぶしスタイルを持つオートシェイプを含むプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換する。

{{% alert color="primary" %}} 

次の[**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください:
[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** をベースに構築されており、基本的な PPT から PPTX への変換機能の実際の例を見ることができます。Aspose.Slides Conversion はウェブアプリで、PPT 形式のプレゼンテーションファイルをドロップすると、PPTX に変換されたものをダウンロードできます。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) の例をご覧ください。
{{% /alert %}} 

## **PPT を PPTX に変換**

PPT を PPTX に変換するには、ファイル名と保存形式を [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドに、[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスに渡すだけです。以下の C# コードサンプルは、デフォルトオプションを使用して PPT から PPTX にプレゼンテーションを変換します。
```c#
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTX プレゼンテーションを PPTX 形式で保存します
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


プレゼンテーション形式の [**PPT vs PPTX**](/slides/ja/net/ppt-vs-pptx/) や、[**Aspose.Slides supports PPT to PPTX conversion**](/slides/ja/net/convert-ppt-to-pptx/) の詳細をご覧ください。

## **FAQ**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリファイル形式で、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さくなり、データ復旧が改善されています。

**.NET で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存することが簡単にできます。

**Aspose.Slides は複数の PPT ファイルを PPTX にバッチ変換することをサポートしていますか？**

はい、Aspose.Slides をループで使用して、複数の PPT ファイルをプログラムで PPTX に変換できるため、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides はプレゼンテーションの変換において高い忠実度を保ちます。スライドレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

**PPT ファイルから PDF や HTML などの他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式を含む複数の形式に変換することをサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET は単体の API であり、変換を実行するために Microsoft PowerPoint やサードパーティ製ソフトウェアは必要ありません。

**PPT から PPTX への変換に利用できるオンラインツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリケーションを使用すれば、コードを書かずにブラウザ上で直接変換を実行できます。