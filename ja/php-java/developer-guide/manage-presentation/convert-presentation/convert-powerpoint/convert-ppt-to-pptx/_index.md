---
title: PPTをPPTXに変換
linktitle: PPTをPPTXに変換
type: docs
weight: 20
url: /php-java/convert-ppt-to-pptx/
keywords: "PHP PPTをPPTXに変換, PowerPoint PPTからPPTX"
description: "PowerPoint PPTをPPTXに変換します。"
---

## **概要**

この記事では、PHPを使用してPPT形式のPowerPointプレゼンテーションをPPTX形式に変換する方法と、オンラインでのPPTからPPTXへの変換アプリについて説明します。以下のトピックが含まれています。

- PPTをPPTXに変換

## **JavaでPPTをPPTXに変換**

PPTをPPTXに変換するためのJavaサンプルコードについては、以下のセクション[Convert PPT to PPTX](#convert-ppt-to-pptx)をご覧ください。このコードはPPTファイルを読み込み、PPTX形式で保存します。異なる保存形式を指定することで、PPTファイルをPDF、XPS、ODP、HTMLなどの他の形式に保存することも可能です。これについては、以下の記事で説明します。

- [Java PPTをPDFに変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java PPTをXPSに変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java PPTをHTMLに変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java PPTをODPに変換](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java PPTを画像に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **PPTからPPTXへの変換について**
古いPPT形式をPPTXに変換するには、Aspose.Slides APIを使用します。数千のPPTプレゼンテーションをPPTX形式に変換する必要がある場合、最良の解決策はプログラム的に行うことです。Aspose.Slides APIを使用すれば、数行のコードで実現できます。APIはPPTプレゼンテーションをPPTXに変換するための完全な互換性をサポートしており、以下のことが可能です：

- マスター、レイアウト、スライドの複雑な構造を変換する。
- チャートを含むプレゼンテーションを変換する。
- グループシェイプ、自動シェイプ（矩形や楕円など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換する。
- 自動シェイプにテクスチャや画像の塗りつぶしスタイルを持つプレゼンテーションを変換する。
- プレースホルダー、テキストフレーム、テキストホルダーを持つプレゼンテーションを変換する。

{{% alert color="primary" %}} 

[**Aspose.Slides PPTからPPTXへの変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx)アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは[**Aspose.Slides API**](https://products.aspose.com/slides/php-java/)に基づいて構築されているため、基本的なPPTからPPTXへの変換機能の生きた例を見ることができます。Aspose.Slides Conversionは、PPT形式のプレゼンテーションファイルをドロップしてPPTXに変換してダウンロードすることを可能にするWebアプリです。

他の生きた[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)の例を見つけてください。
{{% /alert %}} 

## **PPTをPPTXに変換**
Aspose.Slides for PHP via Javaは、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを使用してPPTにアクセスし、それを対応する[PPTX](https://docs.fileformat.com/presentation/pptx/)形式に変換することを開発者に提供します。現在、[PPT](https://docs.fileformat.com/presentation/ppt/)をPPTXに部分的に変換することをサポートしています。PPTからPPTXへの変換でサポートされている機能とサポートされていない機能についての詳細は、このドキュメントの[リンク](/slides/php-java/ppt-to-pptx-conversion/)をご覧ください。

Aspose.Slides for PHP via Javaは、**PPTX**プレゼンテーションファイルを表す[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスを提供します。インスタンス化されたオブジェクトを通じてPresentationから**PPT**にもアクセスできるようになりました。以下の例は、PPTプレゼンテーションをPPTXプレゼンテーションに変換する方法を示しています。

```php
  # PPTXファイルを表すPresentationオブジェクトをインスタンス化する
  $pres = new Presentation("Aspose.ppt");
  try {
    # PPTXプレゼンテーションをPPTX形式で保存
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : ソースPPTプレゼンテーション**|

上記のコードスニペットは、変換後に次のPPTXプレゼンテーションを生成しました。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図: 変換後に生成されたPPTXプレゼンテーション**|