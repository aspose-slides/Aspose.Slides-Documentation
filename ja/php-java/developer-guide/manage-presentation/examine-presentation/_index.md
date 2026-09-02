---
title: PHP でプレゼンテーション情報を取得および更新する
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/php-java/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して、PowerPoint および OpenDocument のプレゼンテーションのスライド、構造、メタデータを調査し、迅速な洞察とより賢いコンテンツ監査を実現します。"
---
## **概要**

この記事では、Aspose.Slidesでプレゼンテーション情報を検査する方法を示します。プレゼンテーション全体のファイルを読み込まずに現在の形式を判定し、ドキュメントプロパティを読み取り、必要に応じてそれらのプロパティを更新する方法を説明します。

これらの例は[PresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/)および[DocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/)APIをベースにしており、プレゼンテーションメタデータを操作する典型的な手順を示しています。

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）が何であるかを確認したくなることがあります。

プレゼンテーションを読み込まずに形式を確認できます。以下の PHP コードをご覧ください。

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **プレゼンテーションプロパティの取得**

この PHP コードは、プレゼンテーションプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

DocumentPropertiesクラスの[DocumentProperties のプロパティ](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#DocumentProperties--)をご確認いただくこともできます。

## **プレゼンテーションプロパティの更新**

Aspose.Slides は、プレゼンテーションプロパティを変更できる[PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)メソッドを提供します。

以下に示すようなドキュメントプロパティを持つ PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています。

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

ドキュメントプロパティを変更した結果は以下の通りです。

![PowerPoint プレゼンテーションの変更後ドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性に関する詳細情報を得るには、以下のリンクが役立つ場合があります。

- [プレゼンテーションのパスワード保護](/slides/ja/php-java/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/php-java/write-protected-presentation/)

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションレベルで[埋め込みフォント情報](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/getembeddedfonts/)を確認し、次にそれらのエントリを[実際に使用されているフォント](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/getfonts/)と比較して、レンダリングに必須のフォントを特定します。

**ファイルに非表示スライドが含まれているか、またその数をすばやく確認するには？**

[スライドコレクション](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/)を反復し、各スライドの[表示フラグ](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/gethidden/)を確認します。

**カスタムスライドサイズや向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。現在の[スライドサイズ](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/getslidesize/)と向きを標準のプリセットと比較します。これにより、印刷やエクスポート時の動作を予測できます。

**チャートが外部データソースを参照しているかをすばやく確認する方法はありますか？**

はい。すべての[チャート](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/)を走査し、[データ ソース](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getdatasourcetype/)を確認して、データが内部かリンクベースか、破損したリンクがないかを確認します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するには？**

各スライドについてオブジェクト数を集計し、大きな画像、透明度、影、アニメーション、マルチメディアなどをチェックします。その後、概算の複雑度スコアを付与して、パフォーマンス上のボトルネックとなり得るスライドを特定します。