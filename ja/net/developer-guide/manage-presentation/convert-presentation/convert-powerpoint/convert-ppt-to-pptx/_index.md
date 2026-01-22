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
- PPT から PPTX へ
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でレガシー PPT プレゼンテーションを最新の PPTX に高速変換 — 明確なチュートリアル、無料の C# コードサンプル、Microsoft Office への依存なし。"
---

## **概要**

この記事では、C# を使用したオンライン PPT から PPTX への変換アプリを利用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックを取り上げます。

- [Convert PPT to PPTX in C#](#convert-ppt-to-pptx)

## **.NET で PPT を PPTX に変換**

C# のサンプルコードで PPT を PPTX に変換する方法については、以下のセクション「[Convert PPT to PPTX](#convert-ppt-to-pptx)」をご参照ください。PPT ファイルを読み込み、PPTX 形式で保存します。保存形式を変更すれば、PDF、XPS、ODP、HTML などの他形式にも変換できます（関連記事をご覧ください）。

- [.NET で PPT を PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf/)
- [.NET で PPT を XPS に変換](/slides/ja/net/convert-powerpoint-to-xps/)
- [.NET で PPT を HTML に変換](/slides/ja/net/convert-powerpoint-to-html/)
- [.NET で PPT を ODP に変換](/slides/ja/net/save-presentation/)
- [.NET で PPT を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/)

## **PPT を PPTX に変換するについて**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千件の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、プログラムで実行するのが最適なソリューションです。Aspose.Slides API なら数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に完全互換で変換でき、次の操作が可能です。

- マスター、レイアウト、スライドの複雑な構造を変換
- チャートを含むプレゼンテーションを変換
- グループ シェイプ、オート シェイプ（長方形や楕円など）、カスタムジオメトリ シェイプを変換
- オート シェイプのテクスチャや画像の塗りつぶしスタイルを持つプレゼンテーションを変換
- プレースホルダー、テキスト フレーム、テキスト ホルダーを含むプレゼンテーションを変換

{{% alert color="primary" %}} 

**Aspose.Slides PPT to PPTX 変換** アプリをご確認ください:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは **Aspose.Slides API** に基づいて構築されているため、基本的な PPT から PPTX への変換機能の実例を直接確認できます。Aspose.Slides Conversion はウェブ アプリで、PPT 形式のプレゼンテーション ファイルをドロップすると PPTX に変換された状態でダウンロードできます。

他のライブ **Aspose.Slides Conversion** 例もご覧ください。
{{% /alert %}} 


## **PPT を PPTX に変換**
PPT を PPTX に変換するには、[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスの [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) メソッドにファイル名と保存形式を渡すだけです。以下の C# コード サンプルは、デフォルト オプションで PPT から PPTX への変換を実行します。
```c#
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTX プレゼンテーションを PPTX 形式で保存します
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


[PPT と PPTX](/slides/ja/net/ppt-vs-pptx/) プレゼンテーション形式の違いや、[Aspose.Slides が PPT から PPTX への変換をサポートしている方法](/slides/ja/net/convert-ppt-to-pptx/) について詳しく読むことができます。

## **よくある質問**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリ ファイル形式で、PPTX は Microsoft Office 2007 以降で導入された XML ベースの新しい形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さく、データ復旧が容易です。

**.NET で PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET ライブラリを使用すれば、数行のコードで PPT ファイルを読み込み、PPTX 形式で保存できます。

**複数の PPT ファイルをバッチ変換して PPTX にできますか？**

はい、Aspose.Slides をループ処理で使用すれば、複数の PPT ファイルをプログラム的に PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライド レイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

**PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG、JPEG など複数の形式に変換できます。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides for .NET はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ ソフトウェアは不要です。

**オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリを使用すれば、コードを書かずにブラウザー上で直接変換できます。