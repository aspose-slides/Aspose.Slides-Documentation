---
title: JavaでPPTをPPTXに変換する
linktitle: PPTからPPTXへ
type: docs
weight: 20
url: /ja/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、レガシーな PPT プレゼンテーションを Java で高速に最新の PPTX に変換します — 明確なチュートリアル、無料のコードサンプル、Microsoft Office への依存なし。"
---

## **概要**

この記事では、Java を使用して PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法と、オンライン PPT から PPTX への変換アプリについて説明します。以下のトピックが取り上げられます。

- Java で PPT を PPTX に変換する

## **Java で PPT を PPTX に変換する**

PPT を PPTX に変換する Java のサンプルコードについては、下記セクション [Convert PPT to PPTX](#convert-ppt-to-pptx) を参照してください。PPT ファイルを読み込み、PPTX 形式で保存するだけです。保存形式を変更すれば、PDF、XPS、ODP、HTML など、さまざまな形式に変換することもできます（これらの記事で解説しています）。

- [Java Convert PPT to PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convert PPT to XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convert PPT to HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convert PPT to ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convert PPT to Image](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千件のプレゼンテーションを PPTX 形式に変換する必要がある場合は、プログラムで実行するのが最適です。Aspose.Slides API なら、数行のコードで実現できます。API は PPT プレゼンテーションから PPTX への完全な互換性をサポートしており、次のような変換が可能です。

- マスター、レイアウト、スライドの複雑な構造を変換
- チャートを含むプレゼンテーションを変換
- グループ シェイプ、オートシェイプ（長方形や楕円など）、カスタムジオメトリを持つシェイプを変換
- テクスチャや画像で塗りつぶされたオートシェイプを変換
- プレースホルダー、テキスト フレーム、テキスト ホルダーを含むプレゼンテーションを変換

{{% alert color="primary" %}} 

[**Aspose.Slides PPT から PPTX への変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリを見てみましょう：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは [**Aspose.Slides API**](https://products.aspose.com/slides/java/) を基に構築されているため、基本的な PPT から PPTX への変換機能の実例が確認できます。Aspose.Slides Conversion は、PPT 形式のプレゼンテーションファイルをドロップして PPTX に変換し、ダウンロードできる Web アプリです。

他のライブ例は [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) をご覧ください。
{{% /alert %}} 

## **PPT を PPTX に変換**
Aspose.Slides for Java は、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを使用して PPT を取得し、対応する [PPTX](https://docs.fileformat.com/presentation/pptx/) 形式に変換できるようになりました。現在、[PPT](https://docs.fileformat.com/presentation/ppt/) から PPTX への部分的な変換をサポートしています。PPT から PPTX への変換でサポートされている機能と未サポートの機能の詳細は、こちらのドキュメント [link](/slides/ja/java/ppt-to-pptx-conversion/) をご参照ください。

Aspose.Slides for Java は、**PPTX** プレゼンテーション ファイルを表す [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスを提供します。オブジェクトのインスタンス化時に **PPT** も同クラスで扱えるようになりました。以下の例は、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Aspose.ppt");
try {
// PPTX プレゼンテーションを PPTX 形式で保存します
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : 元の PPT プレゼンテーション**|

上記コード スニペットは、変換後に次のような PPTX プレゼンテーションを生成します。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図 : 変換後に生成された PPTX プレゼンテーション**|

## **FAQ**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用していた古いバイナリ ファイル形式で、PPTX は Microsoft Office 2007 で導入された XML ベースの新しい形式です。PPTX はパフォーマンスが向上し、ファイル サイズが小さく、データ復旧機能も改善されています。

**Aspose.Slides は複数の PPT ファイルをバッチで PPTX に変換できますか？**

はい。Aspose.Slides をループで使用すれば、複数の PPT ファイルをプログラムから自動的に PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライド レイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換でも保持されます。

**PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい。Aspose.Slides は PPT ファイルを [複数の形式](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/)（PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式）に変換することをサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい。Aspose.Slides はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ ソフトウェアは不要です。

**PPT から PPTX へのオンライン ツールはありますか？**

はい。コードを書かずにブラウザー上で直接変換できる無料の [Aspose.Slides PPT から PPTX 変換ツール](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリをご利用ください。