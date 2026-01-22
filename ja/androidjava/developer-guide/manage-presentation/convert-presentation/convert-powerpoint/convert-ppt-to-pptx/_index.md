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
description: "Android用Aspose.SlidesでJavaを使い、レガシーなPPTプレゼンテーションを最新のPPTXに高速変換します — 明確なチュートリアル、無料コードサンプル、Microsoft Office不要です。"
---

## **概要**

この記事では、Java を使用して PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法と、オンライン PPT から PPTX 変換アプリの使用方法を説明します。取り上げるトピックは以下の通りです。

- Java で PPT を PPTX に変換する

## **Android で PPT を PPTX に変換する**

PPT を PPTX に変換する Java のサンプルコードについては、以下のセクション「[Convert PPT to PPTX](#convert-ppt-to-pptx)」をご参照ください。コードは PPT ファイルを読み込み、PPTX 形式で保存します。保存形式を変更すれば、PDF、XPS、ODP、HTML などの他の形式にも変換できます（これらの記事で解説）。

- [Android で PPT を PDF に変換](/slides/ja/androidjava/convert-powerpoint-to-pdf/)
- [Android で PPT を XPS に変換](/slides/ja/androidjava/convert-powerpoint-to-xps/)
- [Android で PPT を HTML に変換](/slides/ja/androidjava/convert-powerpoint-to-html/)
- [Android で PPT を ODP に変換](/slides/ja/androidjava/save-presentation/)
- [Android で PPT を PNG に変換](/slides/ja/androidjava/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千件の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、プログラムから実行するのが最適なソリューションです。Aspose.Slides API を使用すれば、数行のコードで変換が可能です。API は PPT プレゼンテーションを PPTX にフル互換で変換でき、以下の操作が可能です。

- マスター、レイアウト、スライドの複雑な構造を変換
- チャートを含むプレゼンテーションを変換
- グループ シェイプ、オートシェイプ（長方形や楕円など）、カスタム ジオメトリ シェイプを変換
- テクスチャや画像の塗りつぶしスタイルを持つオートシェイプを変換
- プレースホルダー、テキスト フレーム、テキスト ホルダーを含むプレゼンテーションを変換

{{% alert color="primary" %}} 

[**Aspose.Slides PPT から PPTX への変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/) をベースに構築されており、基本的な PPT から PPTX への変換機能のライブ例を確認できます。Aspose.Slides Conversion は Web アプリで、PPT 形式のプレゼンテーションファイルをドロップすると PPTX に変換してダウンロードできます。

その他のライブ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 例もご確認ください。
{{% /alert %}} 

## **PPT を PPTX に変換する**
Java を使用した Android 用 Aspose.Slides は、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラス インスタンスを介して PPT にアクセスし、対応する [PPTX](https://docs.fileformat.com/presentation/pptx/) 形式に変換できるようになりました。現在、[PPT](https://docs.fileformat.com/presentation/ppt/) から PPTX への部分的な変換がサポートされています。PPT から PPTX への変換でサポートされている機能と未サポートの機能の詳細は、こちらのドキュメント [link](/slides/ja/androidjava/ppt-to-pptx-conversion/) をご参照ください。

Java を使用した Android 用 Aspose.Slides は、**PPTX** プレゼンテーションファイルを表す [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスを提供します。オブジェクトをインスタンス化すると、Presentation から **PPT** にもアクセスできるようになりました。以下の例は、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
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
|**図：元の PPT プレゼンテーション**|

上記のコード スニペットは、変換後に以下の PPTX プレゼンテーションを生成します。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図：変換後に生成された PPTX プレゼンテーション**|

## **FAQ**

**PPT と PPTX のフォーマットの違いは何ですか？**

PPT は Microsoft PowerPoint が使用していた従来のバイナリ ファイル形式で、PPTX は Microsoft Office 2007 で導入された XML ベースの新形式です。PPTX はパフォーマンスが向上し、ファイルサイズが小さく、データ復元機能も強化されています。

**Aspose.Slides は複数の PPT ファイルをバッチで PPTX に変換できますか？**

はい、Aspose.Slides をループで使用すれば、複数の PPT ファイルをプログラムから自動的に PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツやレイアウトは保持されますか？**

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライドのレイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

**PPT から PDF や HTML など別の形式に変換できますか？**

はい、Aspose.Slides は PPT を [複数の形式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/)（PDF、XPS、HTML、ODP、PNG、JPEG など）に変換する機能をサポートしています。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

**オンラインで PPT から PPTX に変換できるツールはありますか？**

はい、無料の [Aspose.Slides PPT から PPTX 変換ツール](https://products.aspose.app/slides/conversion/ppt-to-pptx) を使用すれば、コードを書かずにブラウザー上で直接変換できます。