---
title: JavaでPPTをPPTXに変換
linktitle: PPTからPPTX
type: docs
weight: 20
url: /ja/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java でレガシー PPT プレゼンテーションをモダンな PPTX に高速変換します — 分かりやすいチュートリアル、無料のコードサンプル、Microsoft Office 不要。"
---

## **概要**

この記事では、Java とオンライン PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法について説明します。以下のトピックが取り上げられます。

- Java で PPT を PPTX に変換

## **Java で PPT を PPTX に変換**

PPT を PPTX に変換する Java のサンプルコードについては、以下のセクション [Convert PPT to PPTX](#convert-ppt-to-pptx) をご参照ください。これは PPT ファイルを読み込んで PPTX 形式で保存するだけです。別の保存形式を指定することで、PDF、XPS、ODP、HTML などの多くの形式にも PPT ファイルを保存できます。これらの記事で詳しく説明しています。

- [Java で PPT を PDF に変換](/slides/ja/java/convert-powerpoint-to-pdf/)
- [Java で PPT を XPS に変換](/slides/ja/java/convert-powerpoint-to-xps/)
- [Java で PPT を HTML に変換](/slides/ja/java/convert-powerpoint-to-html/)
- [Java で PPT を ODP に変換](/slides/ja/java/save-presentation/)
- [Java で PPT を PNG に変換](/slides/ja/java/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**

Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適なソリューションはプログラムで実行することです。Aspose.Slides API なら数行のコードで実行可能です。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートしており、次のことが可能です：

- マスター、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループ シェイプ、オートシェイプ（長方形や楕円など）、カスタム ジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- テクスチャや画像の塗りつぶしスタイルを持つオートシェイプを含むプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換する。

{{% alert color="primary" %}} 
以下の [**Aspose.Slides PPT から PPTX への変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは [**Aspose.Slides API**](https://products.aspose.com/slides/java/) に基づいて構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion はウェブアプリで、PPT 形式のプレゼンテーションファイルをドロップすると、PPTX に変換されたファイルをダウンロードできます。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) の例をご覧ください。
{{% /alert %}} 

## **PPT を PPTX に変換**

Aspose.Slides for Java は、開発者が [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを使用して PPT にアクセスし、対応する [PPTX](https://docs.fileformat.com/presentation/pptx/) 形式に変換できるようにしました。現在、[PPT ](https://docs.fileformat.com/presentation/ppt/) から PPTX への部分的な変換をサポートしています。PPT から PPTX 変換でサポートされている機能とサポートされていない機能の詳細については、こちらのドキュメントの [link](/slides/ja/java/ppt-to-pptx-conversion/) をご参照ください。

Aspose.Slides for Java は、**PPTX** プレゼンテーションファイルを表す [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスを提供します。オブジェクトをインスタンス化するときに Presentation を使用して **PPT** にもアクセスできるようになりました。以下の例は、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```java
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
Presentation pres = new Presentation("Aspose.ppt");
try {
// PPTX プレゼンテーションを PPTX 形式で保存
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : 元の PPT プレゼンテーション**|

上記のコードスニペットは、変換後に以下の PPTX プレゼンテーションを生成しました。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図 : 変換後に生成された PPTX プレゼンテーション**|

## **FAQ**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用していた古いバイナリ形式のファイルで、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さく、データ復旧が改善されています。

**Aspose.Slides は複数の PPT ファイルを PPTX にバッチ変換できますか？**

はい、Aspose.Slides をループで使用して、複数の PPT ファイルをプログラムで PPTX に変換できます。これによりバッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は変換時に高い忠実度を保ちます。スライドのレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換中に保持されます。

**PPT ファイルから PDF や HTML といった他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを [multiple formats](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/) に変換することをサポートしており、PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式も含まれます。

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい、Aspose.Slides はスタンドアロン API で、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

**PPT から PPTX への変換にオンラインツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Webアプリケーションを使用すれば、コードを書かずにブラウザ上で直接変換を実行できます。