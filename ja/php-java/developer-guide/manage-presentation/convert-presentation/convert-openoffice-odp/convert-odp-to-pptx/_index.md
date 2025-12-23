---
title: PHPでODPをPPTXに変換
linktitle: ODPからPPTXへ
type: docs
weight: 10
url: /ja/php-java/convert-odp-to-pptx/
keywords:
- OpenDocumentを変換
- プレゼンテーションを変換
- スライドを変換
- ODPを変換
- OpenDocumentからPPTXへ
- ODPからPPTXへ
- ODPをPPTXとして保存
- ODPをPPTXへエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して ODP を PPTX に変換します。クリーンなコード例、バッチのヒント、高品質な結果を提供し、PowerPoint は不要です。"
---

## **ODP を PPTX/PPT プレゼンテーションに変換**
Aspose.Slides for PHP via Java は、プレゼンテーション ファイルを表す [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスを提供します。  
この [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスは、オブジェクトがインスタンス化される際に、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) コンストラクタを使用して ODP にもアクセスできるようになりました。  
以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```php
// ODP ファイルを開く
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # ODP プレゼンテーションを PPTX 形式で保存
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **ライブ例**
以下の [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) ウェブ アプリにアクセスできます。このアプリは **Aspose.Slides API** で構築されており、ODP から PPTX への変換を Aspose.Slides API で実装する方法を示しています。

## **FAQ**

**ODP を PPTX に変換するために Microsoft PowerPoint または LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単体で動作し、ODP/PPTX の読み書きにサードパーティアプリケーションを必要としません。

**変換時にマスタースライド、レイアウト、テーマは保持されますか？**

はい。ライブラリは完全なプレゼンテーション オブジェクト モデルを使用し、マスタースライドやレイアウトを含む構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出に対応しており、パスワードを提供すれば [protected presentations](/slides/ja/php-java/password-protected-presentation/)（ODP を含む）を開いて操作でき、暗号化やドキュメント プロパティへのアクセスも設定可能です。

**Aspose.Slides はクラウドや REST ベースの変換サービスに適していますか？**

はい。ローカル ライブラリを自分のバックエンドで使用することも、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を使用することも可能で、どちらのオプションも ODP → PPTX 変換に対応しています。