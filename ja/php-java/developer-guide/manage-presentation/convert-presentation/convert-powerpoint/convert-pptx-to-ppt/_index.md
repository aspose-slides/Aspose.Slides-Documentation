---
title: PPTX を PHP で PPT に変換
linktitle: PPTX から PPT
type: docs
weight: 21
url: /ja/php-java/convert-pptx-to-ppt/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- スライド を変換
- PPTX を変換
- PPTX から PPT
- PPTX を PPT として保存
- PPTX を PPT にエクスポート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PPTX を PPT に簡単に変換 — PowerPoint 形式とのシームレスな互換性を確保し、プレゼンテーションのレイアウトと品質を維持します。"
---

## **概要**

この記事では、PHP を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックを扱います。

- PPTX を PPT に変換

## **PHPでPPTXをPPTに変換**

PPTX を PPT に変換する Java のサンプルコードについては、以下のセクション[Convert PPTX to PPT](#convert-pptx-to-ppt)をご参照ください。PPTX ファイルを読み込んで PPT 形式で保存するだけです。保存形式を変更すれば、PDF、XPS、ODP、HTML など他の多数の形式にも変換できます（これらの記事で解説しています）。

- [PHPでPPTXをPDFに変換](/slides/ja/php-java/convert-powerpoint-to-pdf/)
- [PHPでPPTXをXPSに変換](/slides/ja/php-java/convert-powerpoint-to-xps/)
- [PHPでPPTXをHTMLに変換](/slides/ja/php-java/convert-powerpoint-to-html/)
- [PHPでPPTXをODPに変換](/slides/ja/php-java/save-presentation/)
- [PHPでPPTXをPNGに変換](/slides/ja/php-java/convert-powerpoint-to-png/)

## **PPTXをPPTに変換**
PPTX を PPT に変換するには、ファイル名と保存形式を **Save** メソッドに渡すだけです。対象は [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスです。以下の PHP コードサンプルは、デフォルトオプションで PPTX から PPT に変換します。
```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
  $presentation = new Presentation("template.pptx");
  # プレゼンテーションを PPT として保存します
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **よくある質問**

**すべての PPTX のエフェクトや機能は、レガシー PPT（97–2003）形式に保存したときに保持されますか？**

必ずしも保持されません。PPT 形式には新しい機能（特定のエフェクト、オブジェクト、動作など）が存在しないため、変換時に機能が簡略化されたりラスタライズされたりします。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存はプレゼンテーション全体を対象とします。特定スライドだけを変換したい場合は、対象スライドだけで新しいプレゼンテーションを作成して PPT として保存するか、スライド単位の変換パラメータをサポートするサービス／API を利用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードを指定して開くことができます。また、保存する PPT の[保護/暗号化設定を構成](/slides/ja/php-java/password-protected-presentation/)することも可能です。