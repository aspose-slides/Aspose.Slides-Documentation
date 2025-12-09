---
title: .NET で PPT を PPTX に変換
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/net/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT から PPTX
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して、レガシー PPT プレゼンテーションを .NET で高速にモダンな PPTX に変換します — 明確なチュートリアル、無料の C# コードサンプル、Microsoft Office 不要。"
---

## **概要**

この記事では、C# とオンライン PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックを取り上げます。

- [Convert PPT to PPTX in C#](#convert-ppt-to-pptx)

## **C# で PPT を PPTX に変換**

C# のサンプルコードで PPT を PPTX に変換する方法は、以下のセクション（[Convert PPT to PPTX](#convert-ppt-to-pptx)）をご参照ください。このサンプルは PPT ファイルを読み込み、PPTX 形式で保存するだけです。保存形式を変更すれば、PDF、XPS、ODP、HTML などの他の形式にも変換できます（これらの記事で詳しく説明しています）。

- [C# Convert PPT to PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convert PPT to XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convert PPT to HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convert PPT to ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convert PPT to Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千件の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、プログラムで実行するのが最適な方法です。Aspose.Slides API なら数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に完全互換で変換でき、次のような変換が可能です。

- マスター、レイアウト、スライドの複雑な構造を変換
- グラフを含むプレゼンテーションを変換
- グループシェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを変換
- テクスチャや画像で塗りつぶされたオートシェイプを変換
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換

{{% alert color="primary" %}} 

以下の [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** に基づいて構築されており、PPT から PPTX への基本的な変換機能の実例を確認できます。Aspose.Slides Conversion はウェブアプリで、PPT 形式のプレゼンテーションファイルをドロップすると PPTX に変換してダウンロードできます。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 例もご確認ください。
{{% /alert %}} 


## **PPT を PPTX に変換**
PPT を PPTX に変換するには、ファイル名と保存形式を **Presentation** クラスの [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドに渡すだけです。以下の C# サンプルは、デフォルトオプションで PPT から PPTX にプレゼンテーションを変換します。
```c#
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTX プレゼンテーションを PPTX 形式で保存します
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


[**PPT vs PPTX**](/slides/ja/net/ppt-vs-pptx/) のプレゼンテーション形式の違いと、[**Aspose.Slides が PPT から PPTX への変換をサポート**](/slides/ja/net/convert-ppt-to-pptx/) する方法について詳しく読むことができます。

## **FAQ**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリファイル形式で、PPTX は Microsoft Office 2007 以降で導入された XML ベースの新しい形式です。PPTX はパフォーマンスが向上し、ファイルサイズが小さく、データ復旧機能も改善されています。

**.NET で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

**複数の PPT ファイルをバッチで PPTX に変換できますか？**

はい、ループ内で Aspose.Slides を使用すれば、複数の PPT ファイルをプログラムで連続して PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライドレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

**PPT から PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式に変換することをサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

**オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリを使用すれば、コードを書かずにブラウザー上で直接変換できます。