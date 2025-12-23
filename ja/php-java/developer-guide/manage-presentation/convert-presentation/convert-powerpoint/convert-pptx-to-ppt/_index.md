---
title: PHP で PPTX を PPT に変換
linktitle: PPTX から PPT
type: docs
weight: 21
url: /ja/php-java/convert-pptx-to-ppt/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPTX を変換
- PPTX から PPT
- PPTX を PPT として保存
- PPTX を PPT にエクスポート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PPTX を PPT に簡単に変換 — プレゼンテーションのレイアウトと品質を保ちながら、PowerPoint フォーマットとのシームレスな互換性を確保します。"
---

## **概要**

この記事では、PHP を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックが取り上げられています。

- PPTX を PPT に変換

## **PHP で PPTX を PPT に変換**

PPTX を PPT に変換する Java のサンプルコードについては、以下のセクション、[Convert PPTX to PPT](#convert-pptx-to-ppt) を参照してください。これは PPTX ファイルを読み込み、PPT 形式で保存するだけです。保存形式を変えることで、PDF、XPS、ODP、HTML などのさまざまな形式にも PPTX ファイルを保存できます。これらの記事で詳しく説明しています。

- [Java PPTX を PDF に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java PPTX を XPS に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java PPTX を HTML に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java PPTX を ODP に変換](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java PPTX を画像に変換](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**
PPTX を PPT に変換するには、ファイル名と保存形式を **Save** メソッド（[**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラス）に渡すだけです。以下の PHP コードサンプルは、デフォルトオプションで PPTX から PPT にプレゼンテーションを変換します。
```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化
  $presentation = new Presentation("template.pptx");
  # プレゼンテーションを PPT として保存
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **FAQ**

**PPTX のすべてのエフェクトや機能は、レガシー PPT（97–2003）形式で保存したときに維持されますか？**

必ずしもそうではありません。PPT 形式は新しい機能（例: 特定のエフェクト、オブジェクト、動作）をサポートしていないため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象になります。特定のスライドだけを変換したい場合は、対象スライドだけを含む新しいプレゼンテーションを作成し、PPT として保存してください。あるいは、スライド単位の変換パラメータをサポートするサービス/API を使用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができます。また、保存した PPT の[保護/暗号化設定を構成](/slides/ja/php-java/password-protected-presentation/)することも可能です。