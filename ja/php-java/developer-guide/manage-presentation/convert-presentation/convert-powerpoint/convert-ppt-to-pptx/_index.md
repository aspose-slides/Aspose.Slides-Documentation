---
title: PHPでPPTをPPTXに変換
linktitle: PPTからPPTXへ
type: docs
weight: 20
url: /ja/php-java/convert-ppt-to-pptx/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、レガシーな PPT プレゼンテーションを最新の PPTX に高速変換します — 分かりやすいチュートリアル、無料のコードサンプル、Microsoft Office不要です。"
---

## **概要**

このドキュメントでは、PHP とオンライン PPT から PPTX への変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックが含まれます。

- PPT を PPTX に変換

## **PHP で PPT を PPTX に変換する方法**

PPT を PPTX に変換する Java のサンプルコードについては、以下のセクション[Convert PPT to PPTX](#convert-ppt-to-pptx)をご参照ください。これは PPT ファイルを読み込み、PPTX 形式で保存します。保存形式を指定することで、PDF、XPS、ODP、HTML などの他の多くの形式にも保存できます。これらの記事で説明されています。

- [Convert PPT to PDF in PHP](/slides/ja/php-java/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS in PHP](/slides/ja/php-java/convert-powerpoint-to-xps/)
- [Convert PPT to HTML in PHP](/slides/ja/php-java/convert-powerpoint-to-html/)
- [Convert PPT to ODP in PHP](/slides/ja/php-java/save-presentation/)
- [Convert PPT to PNG in PHP](/slides/ja/php-java/convert-powerpoint-to-png/)

## **PPT から PPTX への変換について**
Aspose.Slides API を使用して古い PPT 形式を PPTX に変換します。数千の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適なソリューションはプログラムで実行することです。Aspose.Slides API を使用すれば、数行のコードで実行できます。API は PPT プレゼンテーションを PPTX に完全互換で変換でき、次のことが可能です。

- マスター、レイアウト、スライドの複雑な構造を変換。
- チャートを含むプレゼンテーションを変換。
- グループ シェイプ、オートシェイプ（矩形や楕円など）、カスタム ジオメトリを持つシェイプを変換。
- オートシェイプにテクスチャや画像の塗りつぶしスタイルを持つプレゼンテーションを変換。
- プレースホルダー、テキスト フレーム、テキスト ホルダーを含むプレゼンテーションを変換。

{{% alert color="primary" %}} 

[**Aspose.Slides PPT から PPTX への変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx) アプリをご確認ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは[**Aspose.Slides API**](https://products.aspose.com/slides/php-java/)をベースに構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion は Web アプリで、PPT 形式のプレゼンテーション ファイルをドロップし、PPTX に変換してダウンロードできます。

他のライブ[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)例もご覧ください。

{{% /alert %}} 

## **PPT を PPTX に変換**
PHP via Java 用 Aspose.Slides は、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラス インスタンスを使用して PPT にアクセスし、対応する[PPTX](https://docs.fileformat.com/presentation/pptx/)形式に変換できるようにしました。現在、[PPT](https://docs.fileformat.com/presentation/ppt/)から PPTX への部分的な変換をサポートしています。PPT から PPTX 変換でサポートされている機能とサポートされていない機能の詳細については、こちらのドキュメント[link](/slides/ja/php-java/ppt-to-pptx-conversion/)をご覧ください。

PHP via Java 用 Aspose.Slides は、**PPTX** プレゼンテーション ファイルを表す[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスを提供します。オブジェクトがインスタンス化されたときに Presentation を通じて **PPT** にもアクセスできるようになりました。以下の例は、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。

```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
  $pres = new Presentation("Aspose.ppt");
  try {
    # PPTX プレゼンテーションを PPTX 形式で保存する
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : 元の PPT プレゼンテーション**|

上記のコード スニペットは、変換後に次の PPTX プレゼンテーションを生成しました

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図: 変換後に生成された PPTX プレゼンテーション**|

## **FAQ**

**PPT と PPTX の形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用する旧式のバイナリ ファイル形式で、PPTX は Microsoft Office 2007 以降で導入された XML ベースの新しい形式です。PPTX ファイルはパフォーマンスが向上し、ファイルサイズが小さくなり、データ復旧が改善されます。

**Aspose.Slides は複数の PPT ファイルを PPTX にバッチ変換できますか？**

はい、ループ内で Aspose.Slides を使用して複数の PPT ファイルをプログラムで PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides はプレゼンテーションの高忠実度変換を実現します。スライド レイアウト、アニメーション、シェイプ、チャート、その他のデザイン要素は PPT から PPTX への変換時に保持されます。

**PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は[複数の形式](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/)への変換をサポートしており、PDF、XPS、HTML、ODP、PNG や JPEG などの画像形式にも変換できます。

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい、Aspose.Slides はスタンドアロン API であり、Microsoft PowerPoint やサードパーティ ソフトウェアは不要です。

**PPT から PPTX へのオンライン ツールはありますか？**

はい、無料の[Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx)Web アプリケーションを使用すれば、コードを書かずにブラウザ上で直接変換できます。