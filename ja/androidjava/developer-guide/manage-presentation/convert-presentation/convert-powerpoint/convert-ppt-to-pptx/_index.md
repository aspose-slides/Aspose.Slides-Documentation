---
title: Android で PPT を PPTX に変換
linktitle: PPT を PPTX に
type: docs
weight: 20
url: /ja/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT を PPTX に
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java で従来の PPT プレゼンテーションを最新の PPTX に高速変換します — 明確なチュートリアル、無料のコードサンプル、Microsoft Office への依存なし。"
---

## **概要**

この記事では、Java を使用して PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法と、オンライン PPT から PPTX への変換アプリについて説明します。以下のトピックを取り上げます。

- Java で PPT を PPTX に変換する

## **Android で PPT を PPTX に変換する**

PPT を PPTX に変換する Java のサンプルコードについては、以下のセクション「[Convert PPT to PPTX](#convert-ppt-to-pptx)」をご参照ください。これは PPT ファイルを読み込み、PPTX 形式で保存するだけの簡単なサンプルです。保存形式を変更すれば、PDF、XPS、ODP、HTML など多くの形式にも変換できます（これらの記事で詳細を紹介しています）。

- [Convert PPT to PDF on Android](/slides/ja/androidjava/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS on Android](/slides/ja/androidjava/convert-powerpoint-to-xps/)
- [Convert PPT to HTML on Android](/slides/ja/androidjava/convert-powerpoint-to-html/)
- [Convert PPT to ODP on Android](/slides/ja/androidjava/save-presentation/)
- [Convert PPT to PNG on Android](/slides/ja/androidjava/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千件の PPT プレゼンテーションを PPTX に変換する必要がある場合は、プログラムで実行するのが最適な方法です。Aspose.Slides API を使えば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に完全互換で変換でき、次のような変換が可能です。

- マスター、レイアウト、スライドの複雑な構造を変換
- チャートを含むプレゼンテーションを変換
- グループ シェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを変換
- オートシェイプのテクスチャや画像の塗りつぶしスタイルを保持して変換
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換

{{% alert color="primary" %}} 
Aspose.Slides PPT から PPTX への変換アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは[**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/)をベースに構築されているため、基本的な PPT から PPTX への変換機能の実例を確認できます。Aspose.Slides Conversion は Web アプリで、PPT 形式のプレゼンテーションファイルをドロップすると PPTX に変換してダウンロードできます。

他のライブ[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)例もご覧ください。
{{% /alert %}} 

## **PPT を PPTX に変換する**
Java を使用した Android 向け Aspose.Slides は、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを通じて PPT にアクセスし、[PPTX](https://docs.fileformat.com/presentation/pptx/) 形式に変換できるようになりました。現在、[PPT](https://docs.fileformat.com/presentation/ppt/) から PPTX への部分的な変換をサポートしています。

Aspose.Slides for Android via Java は、**PPTX** プレゼンテーション ファイルを表す [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスを提供します。インスタンス化時にオブジェクトを通じて **PPT** にもアクセスできるようになりました。以下のサンプルは、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
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
|**図 : ソース PPT プレゼンテーション**|

上記コード スニペットは、変換後に次の PPTX プレゼンテーションを生成しました。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図 : 変換後に生成された PPTX プレゼンテーション**|

## **FAQ**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用していた従来のバイナリ ファイル形式で、PPTX は Microsoft Office 2007 で導入された XML ベースの新形式です。PPTX はパフォーマンスが向上し、ファイル サイズが小さく、データ復旧も改善されています。

**Aspose.Slides は複数の PPT ファイルをバッチで PPTX に変換できますか？**

はい、ループ内で Aspose.Slides を使用すれば、複数の PPT ファイルをプログラムで PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライド レイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

**PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は [複数の形式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/) への変換をサポートしており、PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式にも変換できます。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides はスタンドアロンの API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

**オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web アプリを使用すれば、コードを書くことなくブラウザ上で直接変換できます。