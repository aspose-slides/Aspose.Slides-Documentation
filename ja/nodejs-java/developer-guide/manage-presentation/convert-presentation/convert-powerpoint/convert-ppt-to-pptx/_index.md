---
title: JavaScript で PPT を PPTX に変換
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "古い PPT プレゼンテーションを Aspose.Slides for Node.js で高速に最新の PPTX に変換します。明確なチュートリアル、無料サンプルコード、Microsoft Office 不要。"
---

## **概要**

この記事では、JavaScript とオンライン PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックが取り上げられます。

- JavaScript で PPT を PPTX に変換

## **Java で PPT を PPTX に変換**

PPT を PPTX に変換する JavaScript のサンプルコードは、以下のセクション [Convert PPT to PPTX](#convert-ppt-to-pptx) を参照してください。これは PPT ファイルを読み込んで PPTX 形式で保存するだけです。異なる保存形式を指定することで、PDF、XPS、ODP、HTML などの多くの形式にも PPT ファイルを保存できます。これらの記事で説明されています。

- [JavaScript で PPT を PDF に変換](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)
- [JavaScript で PPT を XPS に変換](/slides/ja/nodejs-java/convert-powerpoint-to-xps/)
- [JavaScript で PPT を HTML に変換](/slides/ja/nodejs-java/convert-powerpoint-to-html/)
- [JavaScript で PPT を ODP に変換](/slides/ja/nodejs-java/save-presentation/)
- [JavaScript で PPT を PNG に変換](/slides/ja/nodejs-java/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適なソリューションはプログラムで実行することです。Aspose.Slides API を使用すれば、数行のコードで実行可能です。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートし、次のことが可能です。

- マスタ、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループ シェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリのシェイプを含むプレゼンテーションを変換する。
- オートシェイプにテクスチャや画像の塗りつぶしスタイルがあるプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換する。

{{% alert color="primary" %}} 
以下の [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください:
[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) を基に構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion は Web アプリで、PPT 形式のプレゼンテーションファイルをドロップすると、PPTX に変換されたものをダウンロードできます。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) の例もご覧ください。
{{% /alert %}} 

## **PPT を PPTX に変換**
Aspose.Slides for Node.js via Java は、開発者が [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラス インスタンスを使用して PPT にアクセスし、対応する [PPTX](https://docs.fileformat.com/presentation/pptx/) 形式に変換できるようにします。現在、[PPT ](https://docs.fileformat.com/presentation/ppt/)から PPTX への部分的な変換をサポートしています。

Aspose.Slides for Node.js via Java は、**PPTX** プレゼンテーション ファイルを表す [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスを提供します。Presentation クラスは、オブジェクトがインスタンス化されたときに **PPT** にもアクセスできるようになりました。以下の例は、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```javascript
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // PPTX プレゼンテーションを PPTX 形式で保存します
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : 元の PPT プレゼンテーション**|

上記のコードスニペットは、変換後に次の PPTX プレゼンテーションを生成しました

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図: 変換後に生成された PPTX プレゼンテーション**|

## **FAQ**

**PPT と PPTX 形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用している古いバイナリ ファイル形式で、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さく、データ復旧が改善されています。

**Aspose.Slides は複数の PPT ファイルを PPTX に一括変換することをサポートしていますか？**

はい、Aspose.Slides をループで使用して、複数の PPT ファイルをプログラムで PPTX に変換できます。これにより、一括変換シナリオに適しています。

**変換後にコンテンツと書式は保持されますか？**

Aspose.Slides はプレゼンテーションの変換において高い忠実度を維持します。スライド レイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換中に保持されます。

**PPT ファイルから PDF や HTML などの他の形式に変換できますか？**

はい、Aspose.Slides は PPT ファイルを PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式を含む複数の形式に変換することをサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides はスタンドアロンの API であり、変換を実行するために Microsoft PowerPoint やサードパーティ ソフトウェアは必要ありません。

**PPT を PPTX に変換するオンラインツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリケーションを使用すれば、コードを書かずにブラウザー上で直接変換を実行できます。