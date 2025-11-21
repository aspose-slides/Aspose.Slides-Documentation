---
title: JavaScriptでPPTをPPTXに変換
linktitle: PPTをPPTXに変換
type: docs
weight: 20
url: /ja/nodejs-java/convert-ppt-to-pptx/
keywords: "JavaでPPTをPPTXに変換, JavaScriptのPowerPoint PPTからPPTXへの変換"
description: "JavaScriptでPowerPoint PPTをPPTXに変換します。"
---

## **概要**

この記事では、JavaScript とオンライン PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックが取り上げられます。

- JavaScript で PPT を PPTX に変換

## **Java PPT を PPTX に変換**

JavaScript のサンプルコードで PPT を PPTX に変換する方法については、以下のセクション「[Convert PPT to PPTX](#convert-ppt-to-pptx)」をご参照ください。このコードは PPT ファイルを読み込み、PPTX 形式で保存します。保存形式を指定することで、PDF、XPS、ODP、HTML など多数の他の形式にも PPT ファイルを保存できます。これらの記事で説明しています。

- [Java PPT を PDF に変換](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java PPT を XPS に変換](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java PPT を HTML に変換](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java PPT を ODP に変換](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java PPT を Image に変換](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千もの PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適な方法はプログラムで実行することです。Aspose.Slides API を使えば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートしており、以下が可能です：

- マスター、レイアウト、スライドの複雑な構造を変換します。
- チャートを含むプレゼンテーションを変換します。
- グループ形状、オートシェイプ（長方形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換します。
- テクスチャや画像の塗りつぶしスタイルを持つオートシェイプを含むプレゼンテーションを変換します。
- プレースホルダ、テキストフレーム、テキストホルダーを持つプレゼンテーションを変換します。

{{% alert color="primary" %}} 

以下の [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) をベースに構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion はウェブアプリで、PPT 形式のプレゼンテーションファイルをドロップすると PPTX に変換してダウンロードできます。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) の例をご確認ください。
{{% /alert %}} 

## **PPT を PPTX に変換**
Aspose.Slides for Node.js via Java は、開発者が [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを使用して PPT にアクセスし、対応する [PPTX](https://docs.fileformat.com/presentation/pptx/) 形式に変換できるようになりました。現在、[PPT](https://docs.fileformat.com/presentation/ppt/) の部分的な PPTX 変換をサポートしています。PPT から PPTX への変換でサポートされている機能とサポートされていない機能の詳細については、こちらのドキュメント [link](/slides/ja/nodejs-java/ppt-to-pptx-conversion/)をご覧ください。

Aspose.Slides for Node.js via Java は、**PPTX** プレゼンテーションファイルを表す [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスを提供します。インスタンス化されたオブジェクトでは、Presentation クラスを通じて **PPT** にもアクセスできるようになりました。以下の例は、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```javascript
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // PPTX プレゼンテーションを PPTX 形式で保存
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figure : 元の PPT プレゼンテーション**|

上記のコードスニペットは、変換後に以下の PPTX プレゼンテーションを生成しました。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure：変換後に生成された PPTX プレゼンテーション**|

## **FAQ**

**PPT と PPTX 形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用していた古いバイナリファイル形式で、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX ファイルは、パフォーマンスの向上、ファイルサイズの削減、データ復元性の改善をもたらします。

**Aspose.Slides は複数の PPT ファイルを PPTX にバッチ変換することをサポートしていますか？**

はい、Aspose.Slides をループで使用して複数の PPT ファイルをプログラム的に PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツと書式は保持されますか？**

Aspose.Slides はプレゼンテーションの高忠実度変換を維持します。スライドレイアウト、アニメーション、シェイプ、チャート、およびその他のデザイン要素は PPT から PPTX への変換中に保持されます。

**PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式へ変換することをサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides はスタンドアロン API であり、Microsoft PowerPoint やサードパーティソフトウェアを必要とせずに変換を実行できます。

**PPT から PPTX への変換に利用できるオンラインツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) ウェブアプリを使用すれば、コードを書かずにブラウザー上で直接変換できます。