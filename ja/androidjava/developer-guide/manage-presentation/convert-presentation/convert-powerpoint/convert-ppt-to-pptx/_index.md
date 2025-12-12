---
title: AndroidでPPTをPPTXに変換
linktitle: PPTからPPTXへ
type: docs
weight: 20
url: /ja/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTからPPTXへ
- PPTをPPTXとして保存
- PPTをPPTXにエクスポート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、レガシー PPT プレゼンテーションを最新の PPTX に高速変換する方法 — 明確なチュートリアル、無料コードサンプル、Microsoft Office 不要。"
---

## **概要**

この記事では、Java を使用して PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法と、オンライン PPT から PPTX への変換アプリについて説明します。以下のトピックが取り上げられます。

- Java で PPT を PPTX に変換

## **Android で PPT を PPTX に変換**

Java のサンプルコードで PPT を PPTX に変換する方法については、以下のセクション、[Convert PPT to PPTX](#convert-ppt-to-pptx) を参照してください。これは PPT ファイルを読み込み、PPTX 形式で保存するだけです。異なる保存形式を指定することで、PDF、XPS、ODP、HTML などの多くの形式にも PPT ファイルを保存できます。これらの記事で詳しく説明しています。

- [Java PPT を PDF に変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java PPT を XPS に変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java PPT を HTML に変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java PPT を ODP に変換](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java PPT を画像に変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**

古い PPT 形式を Aspose.Slides API で PPTX に変換します。数千もの PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適な方法はプログラムで行うことです。Aspose.Slides API を使用すれば、数行のコードで実現できます。この API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートしており、以下のことが可能です：

- マスター、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループシェイプ、オートシェイプ（長方形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- テクスチャや画像で塗りつぶされたオートシェイプを含むプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換する。

{{% alert color="primary" %}} 

以下の [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/) をベースに構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion はウェブアプリで、PPT 形式のプレゼンテーションファイルをドロップすると、PPTX に変換されたファイルをダウンロードできます。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) の例をご覧ください。
{{% /alert %}} 

## **PPT を PPTX に変換**

Aspose.Slides for Android via Java は、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを使用して PPT にアクセスし、対応する [PPTX](https://docs.fileformat.com/presentation/pptx/) 形式に変換できるようにしました。現在、[PPT](https://docs.fileformat.com/presentation/ppt/) から PPTX への部分的な変換をサポートしています。PPT から PPTX への変換でサポートされている機能と未サポートの機能の詳細については、こちらのドキュメント [link](/slides/ja/androidjava/ppt-to-pptx-conversion/) をご覧ください。

Aspose.Slides for Android via Java は、**PPTX** プレゼンテーションファイルを表す [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスを提供します。Presentation クラスは、オブジェクトがインスタンス化されたときに **PPT** にもアクセスできるようになりました。以下の例は、PPT プレゼンテーションを PPTX Presentation に変換する方法を示しています。
```java
// PPTX ファイルを表す Presentation オブジェクトを作成します
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

上記のコードスニペットは、変換後に以下の PPTX プレゼンテーションを生成しました

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図: 変換後に生成された PPTX プレゼンテーション**|

## **よくある質問**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する古いバイナリ形式で、PPTX は Microsoft Office 2007 以降に導入された XML ベースの新しい形式です。PPTX はパフォーマンスが向上し、ファイルサイズが小さくなり、データ復元が改善されています。

**Aspose.Slides は複数の PPT ファイルを PPTX に一括変換できますか？**

はい、Aspose.Slides をループで使用して、複数の PPT ファイルをプログラムで PPTX に変換できます。バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライドレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換中に保持されます。

**PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式を含む [複数の形式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/) への変換をサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides はスタンドアロンの API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアを必要とせずに変換を実行できます。

**オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリを使用すれば、コードを書かずにブラウザ上で直接変換できます。