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
- PPTをPPTXへエクスポート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Javaを使用して、レガシーなPPTプレゼンテーションを最新のPPTXに高速変換 — 明確なチュートリアル、無料のコードサンプル、Microsoft Office不要。"
---

## **概要**

この記事では、PHP とオンライン PPT から PPTX 変換アプリを使用して、PPT 形式の PowerPoint プレゼンテーションを PPTX 形式に変換する方法を説明します。以下のトピックが取り上げられています。

- PPT を PPTX に変換

## **PHP で PPT を PPTX に変換**

PPT を PPTX に変換する Java のサンプルコードについては、以下のセクション、すなわち[Convert PPT to PPTX](#convert-ppt-to-pptx)をご覧ください。これは PPT ファイルを読み込み、PPTX 形式で保存するだけです。異なる保存形式を指定することで、PDF、XPS、ODP、HTML など多数の他の形式でも PPT ファイルを保存できます。これらの記事で説明しています。

- [Java PPT を PDF に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java PPT を XPS に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java PPT を HTML に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java PPT を ODP に変換](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java PPT を画像に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **PPT から PPTX 変換について**

古い PPT 形式を Aspose.Slides API で PPTX に変換します。数千の PPT プレゼンテーションを PPTX 形式に変換する必要がある場合、最適なソリューションはプログラムで実行することです。Aspose.Slides API を使用すれば、数行のコードで実現できます。API は PPT プレゼンテーションを PPTX に変換する完全な互換性をサポートしており、以下が可能です：

- マスター、レイアウト、スライドの複雑な構造を変換します。
- チャートを含むプレゼンテーションを変換します。
- グループ形状、オートシェイプ（矩形や楕円など）、カスタムジオメトリを持つ形状を含むプレゼンテーションを変換します。
- オートシェイプのテクスチャや画像塗りつぶしスタイルを持つプレゼンテーションを変換します。
- プレースホルダー、テキストフレーム、テキストホルダーを含むプレゼンテーションを変換します。

{{% alert color="primary" %}} 
以下の[**Aspose.Slides PPT to PPTX 変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx)アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは[**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) をベースに構築されており、基本的な PPT から PPTX への変換機能の実例を見ることができます。Aspose.Slides Conversion はウェブアプリで、PPT 形式のプレゼンテーションファイルをドロップし、PPTX に変換されたものをダウンロードできます。

他のライブな[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)例をご覧ください。
{{% /alert %}} 

## **PPT を PPTX に変換**

Aspose.Slides for PHP via Java は、開発者が[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを使用して PPT にアクセスし、対応する[PPTX](https://docs.fileformat.com/presentation/pptx/)形式に変換できるようにします。現在、[PPT](https://docs.fileformat.com/presentation/ppt/) を PPTX に部分的に変換することをサポートしています。PPT から PPTX 変換でサポートされている機能と未サポートの機能の詳細については、こちらのドキュメント[link](/slides/ja/php-java/ppt-to-pptx-conversion/)をご参照ください。

Aspose.Slides for PHP via Java は、**PPTX** プレゼンテーションファイルを表す[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスを提供します。インスタンス化されたときに、Presentation クラスは **PPT** にもアクセスできるようになりました。以下の例は、PPT プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化
  $pres = new Presentation("Aspose.ppt");
  try {
    # PPTX プレゼンテーションを PPTX 形式で保存
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : ソース PPT プレゼンテーション**|

上記のコードスニペットは、変換後に以下の PPTX プレゼンテーションを生成しました。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図: 変換後の生成された PPTX プレゼンテーション**|

## **よくある質問**

**PPT と PPTX 形式の違いは何ですか？**

PPT は Microsoft PowerPoint が使用していた従来のバイナリファイル形式で、PPTX は Microsoft Office 2007 以降で導入された XML ベースの新しい形式です。PPTX はパフォーマンスが向上し、ファイルサイズが小さく、データ復元が改善されています。

**Aspose.Slides は複数の PPT ファイルをバッチで PPTX に変換できますか？**

はい、Aspose.Slides をループ内で使用して、複数の PPT ファイルをプログラム的に PPTX に変換でき、バッチ変換シナリオに適しています。

**変換後にコンテンツや書式は保持されますか？**

Aspose.Slides は変換時に高い忠実度を維持します。スライドのレイアウト、アニメーション、形状、チャート、その他のデザイン要素は PPT から PPTX への変換中に保持されます。

**PPT ファイルから PDF や HTML など他の形式に変換できますか？**

はい、Aspose.Slides は PDF、XPS、HTML、ODP、PNG、JPEG など、PPT ファイルを[複数の形式](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/)に変換することをサポートしています。

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい、Aspose.Slides はスタンドアロンの API であり、Microsoft PowerPoint やサードパーティ製ソフトウェアは不要です。

**オンラインで PPT を PPTX に変換できるツールはありますか？**

はい、無料の[Aspose.Slides PPT to PPTX コンバータ](https://products.aspose.app/slides/conversion/ppt-to-pptx)ウェブアプリを使用すれば、コードを書かずにブラウザー上で直接変換できます。