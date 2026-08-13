---
title: Java で PPT を PPTX に変換する
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/java/convert-ppt-to-pptx/
keywords:
- PowerPoint の変換
- プレゼンテーションを変換する
- スライドを変換する
- PPT を変換する
- PPT から PPTX へ
- PPT を PPTX として保存する
- PPT を PPTX にエクスポートする
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java でレガシー PPT プレゼンテーションを高速にモダンな PPTX に変換します — 分かりやすいチュートリアル、無料のコードサンプル、Microsoft Office への依存なし。"
---
## **概要**

この記事では、Java とオンライン PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックが取り上げられています。

- Java で PPT を PPTX に変換する

## **Java で PPT を PPTX に変換する**

Java のサンプルコードで PPT を PPTX に変換する方法については、以下のセクション、すなわち [Convert PPT to PPTX](#convert-ppt-to-pptx) を参照してください。これは PPT ファイルを読み込み、PPTX 形式で保存します。異なる保存形式を指定することで、PDF、XPS、ODP、HTML などの多くの形式にも PPT ファイルを保存できます。これらの記事で詳しく説明しています。

- [Java で PPT を PDF に変換する](/slides/ja/java/convert-powerpoint-to-pdf/)
- [Java で PPT を XPS に変換する](/slides/ja/java/convert-powerpoint-to-xps/)
- [Java で PPT を HTML に変換する](/slides/ja/java/convert-powerpoint-to-html/)
- [Java で PPT を ODP に変換する](/slides/ja/java/save-presentation/)
- [Java で PPT を PNG に変換する](/slides/ja/java/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**

Aspose.Slides API を使用して、古い PPT 形式を PPTX に変換します。数千もの PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適なソリューションはプログラムで実行することです。Aspose.Slides API を使用すれば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートしており、以下のことが可能です:

- マスター、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループシェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- オートシェイプのテクスチャや画像の塗りつぶしスタイルを持つプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換する。

{{% alert color="info" %}} 
次の [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx)

このアプリは [**Aspose.Slides API**](https://products.aspose.com/slides/ja/java/) をベースに構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion は Web アプリで、PPT 形式のプレゼンテーションファイルをドロップし、変換後の PPTX をダウンロードできるようになっています。

他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ja/conversion/) の例をご覧ください。
{{% /alert %}} 

## **PPT を PPTX に変換する**

Aspose.Slides for Java は、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを使用して PPT にアクセスし、対応する [PPTX](https://docs.fileformat.com/presentation/pptx/) 形式に変換できるようにしました。現在、[PPT](https://docs.fileformat.com/presentation/ppt/) から PPTX への部分的な変換をサポートしています。PPT から PPTX への変換でサポートされている機能とサポートされていない機能の詳細については、こちらのドキュメント [link](/slides/ja/java/ppt-to-pptx-conversion/) をご参照ください。

Aspose.Slides for Java は **PPTX** プレゼンテーションファイルを表す [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスを提供します。Presentation クラスは、インスタンス化時に **PPT** もアクセスできるようになりました。以下の例は、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。

```java
import com.aspose.slides.*;

// PPT ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation("Aspose.ppt");
try {
// PPT プレゼンテーションを PPTX 形式で保存する
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : 元の PPT プレゼンテーション**|

上記コードスニペットは変換後に以下の PPTX プレゼンテーションを生成しました

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図 : 変換後に生成された PPTX プレゼンテーション**|

## **よくある質問**

### PPT と PPTX 形式の違いは何ですか？

PPT は Microsoft PowerPoint が使用していた古いバイナリ形式で、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さくなり、データ復元機能も改善されています。

### Aspose.Slides は複数の PPT ファイルを PPTX に一括変換することをサポートしていますか？

はい、Aspose.Slides をループで使用して、複数の PPT ファイルをプログラムで PPTX に変換できます。これにより、一括変換シナリオに適しています。

### 変換後にコンテンツや書式は保持されますか？

Aspose.Slides はプレゼンテーションの変換において高い忠実度を保ちます。スライドのレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換中に保持されます。

### PPT ファイルから PDF や HTML などの他の形式に変換できますか？

はい、Aspose.Slides は PPT ファイルを [multiple formats](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) に変換することをサポートしており、PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式も含まれます。

### Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？

はい、Aspose.Slides はスタンドアロンの API であり、変換を行うために Microsoft PowerPoint やその他のサードパーティ製ソフトウェアは必要ありません。

### PPT を PPTX に変換するオンラインツールはありますか？

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) Web アプリケーションを使用すれば、コードを書かずにブラウザー上で直接変換を実行できます。