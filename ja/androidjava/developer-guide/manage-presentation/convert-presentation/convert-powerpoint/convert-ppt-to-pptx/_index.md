---
title: Android で PPT を PPTX に変換
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java でレガシー PPT プレゼンテーションを最新の PPTX に高速変換します — 明確なチュートリアル、無料のコードサンプル、Microsoft Office への依存なし。"
---
## **概要**

この記事では、Java とオンライン PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックを取り上げます。

- Java で PPT を PPTX に変換

## **Android で PPT を PPTX に変換**

Java のサンプルコードで PPT を PPTX に変換する方法については、以下のセクション「[Convert PPT to PPTX](#convert-ppt-to-pptx)」をご参照ください。PPT ファイルを読み込み、PPTX 形式で保存するだけです。保存形式を変更すれば、PDF、XPS、ODP、HTML など、さまざまな形式にも変換できます（これらの記事で詳しく説明しています）。

- [Android で PPT を PDF に変換](/slides/ja/androidjava/convert-powerpoint-to-pdf/)
- [Android で PPT を XPS に変換](/slides/ja/androidjava/convert-powerpoint-to-xps/)
- [Android で PPT を HTML に変換](/slides/ja/androidjava/convert-powerpoint-to-html/)
- [Android で PPT を ODP に変換](/slides/ja/androidjava/save-presentation/)
- [Android で PPT を PNG に変換](/slides/ja/androidjava/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千件の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、プログラムで実行するのが最適な方法です。Aspose.Slides API を使えば、数行のコードで変換が可能です。API は完全な互換性を提供し、以下の変換が可能です。

- マスタ、レイアウト、スライドといった複雑な構造の変換
- グラフを含むプレゼンテーションの変換
- グループ シェイプ、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプの変換
- テクスチャや画像で塗りつぶされたオートシェイプの変換
- プレースホルダー、テキスト枠、テキストホルダーを含むプレゼンテーションの変換

{{% alert color="info" %}} 

[**Aspose.Slides PPT から PPTX 変換**](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) アプリをご覧ください:

[](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx)

このアプリは [**Aspose.Slides API**](https://products.aspose.com/slides/ja/androidjava/) をベースに構築されており、基本的な PPT から PPTX への変換機能の実例を確認できます。Aspose.Slides Conversion は Web アプリで、PPT 形式のプレゼンテーションファイルをドラッグ＆ドロップすると、PPTX に変換してダウンロードできます。

他のライブ例は [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ja/conversion/) をご参照ください。
{{% /alert %}} 

## **PPT を PPTX に変換**
Aspose.Slides for Android via Java は、開発者が [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラス インスタンスを介して PPT にアクセスし、対応する [PPTX](https://docs.fileformat.com/presentation/pptx/) 形式に変換できるようにします。現在、[PPT](https://docs.fileformat.com/presentation/ppt/) から PPTX への部分的な変換がサポートされています。

Aspose.Slides for Android via Java は、**PPTX** プレゼンテーション ファイルを表す [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスを提供します。オブジェクトをインスタンス化するときに **PPT** へもアクセスできるようになりました。以下の例は、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。

```java
import com.aspose.slides.*;

// PPT ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Aspose.ppt");
try {
    // PPT プレゼンテーションを PPTX 形式で保存します
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : 元の PPT プレゼンテーション**|

上記のコード スニペットは、変換後に次の PPTX プレゼンテーションを生成します。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図 : 変換後に生成された PPTX プレゼンテーション**|

## **FAQ**

### PPT と PPTX フォーマットの違いは何ですか？

PPT は Microsoft PowerPoint が使用する従来のバイナリ ファイル形式で、PPTX は Microsoft Office 2007 で導入された新しい XML ベースの形式です。PPTX はパフォーマンスが向上し、ファイルサイズが小さく、データ復旧機能が強化されています。

### Aspose.Slides は複数の PPT ファイルをバッチで PPTX に変換できますか？

はい、ループ内で Aspose.Slides を使用すれば、複数の PPT ファイルをプログラムで自動的に PPTX に変換でき、バッチ変換シナリオに最適です。

### 変換後もコンテンツと書式は保持されますか？

Aspose.Slides は高い忠実度でプレゼンテーションを変換します。スライド レイアウト、アニメーション、シェイプ、グラフ、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

### PPT ファイルから PDF や HTML など他の形式に変換できますか？

はい、Aspose.Slides は [複数の形式](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) への変換をサポートしており、PDF、XPS、HTML、ODP、PNG、JPEG などに変換できます。

### Microsoft PowerPoint がインストールされていなくても PPT から PPTX に変換できますか？

はい、Aspose.Slides はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

### PPT から PPTX へのオンライン変換ツールはありますか？

はい、無料の [Aspose.Slides PPT から PPTX コンバータ](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) Web アプリを使用すれば、コードを書かずにブラウザー上で直接変換できます。