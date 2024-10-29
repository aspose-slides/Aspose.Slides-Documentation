---
title: PPTXをPPTに変換
linktitle: PPTXをPPTに変換
type: docs
weight: 21
url: /ja/php-java/convert-pptx-to-ppt/
keywords: "PHP PPTXをPPTに変換, PowerPointプレゼンテーションを変換, PPTXをPPT, Java, Aspose.Slides"
description: "PowerPoint PPTXをPPTに変換"
---

## **概要**

この記事では、PHPを使用してPPTX形式のPowerPointプレゼンテーションをPPT形式に変換する方法について説明します。以下のトピックが含まれています。

- PPTXをPPTに変換

## **Java PPTXをPPTに変換**

PPTXをPPTに変換するためのJavaのサンプルコードについては、以下のセクション i.e. [PPTXをPPTに変換](#convert-pptx-to-ppt)を参照してください。これは単にPPTXファイルをロードし、PPT形式で保存します。異なる保存形式を指定することで、PPTXファイルをPDF、XPS、ODP、HTMLなど、他の多くの形式に保存することもできます。これについては、以下の記事で説明しています。

- [Java PPTXをPDFに変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java PPTXをXPSに変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java PPTXをHTMLに変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java PPTXをODPに変換](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java PPTXを画像に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **PPTXをPPTに変換**
PPTXをPPTに変換するには、ファイル名と保存形式を[**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスの**Save**メソッドに渡すだけです。以下のPHPコードサンプルは、デフォルトのオプションを使用してPPTXからPPTにプレゼンテーションを変換します。

```php
  # PPTXファイルを表すPresentationオブジェクトをインスタンス化
  $presentation = new Presentation("template.pptx");
  # プレゼンテーションをPPTとして保存
  $presentation->save("output.ppt", SaveFormat::Ppt);

```