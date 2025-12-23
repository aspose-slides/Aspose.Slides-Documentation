---
title: PHP でプレゼンテーション情報を取得および更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/php-java/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
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
description: "Aspose.Slides for PHP を使用して、PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、迅速な洞察とスマートなコンテンツ監査を実現します。"
---

Aspose.Slides for PHP via Java を使用すると、プレゼンテーションを調査してそのプロパティを把握し、動作を理解できます。

{{% alert title="Info" color="info" %}} 
ここで使用される操作に必要なプロパティとメソッドは、[PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) と [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) クラスに含まれています。
{{% /alert %}} 

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）を確認したい場合があります。

プレゼンテーションを読み込まずに形式を確認できます。以下の PHP コードをご覧ください:
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```


## **プレゼンテーションプロパティの取得**

この PHP コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）の取得方法を示します。
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ...
```


[DocumentProperties のプロパティ](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) をご覧になることができます。

## **プレゼンテーションプロパティの更新**

Aspose.Slides は、プレゼンテーションのプロパティを変更できる [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) メソッドを提供します。

以下に示すように、ドキュメントプロパティが設定された PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています:
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

プレゼンテーションとそのセキュリティ属性に関する詳細情報については、以下のリンクが役立ちます:

- [プレゼンテーションが暗号化されているかの確認](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）かどうかの確認](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ロード前にプレゼンテーションがパスワード保護されているかの確認](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションレベルで [埋め込みフォント情報](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getembeddedfonts/) を探し、次にそれらのエントリを [実際に使用されているフォント](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/) と比較して、レンダリングに必須のフォントを特定します。

**ファイルに非表示スライドがあるか、またその数をすばやく確認するには？**

[スライド コレクション](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) を反復し、各スライドの [可視性フラグ](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) を確認します。

**カスタムスライドサイズと向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。現在の [スライド サイズ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslidesize/) と向きを標準のプリセットと比較します。これにより、印刷やエクスポート時の挙動を予測できます。

**チャートが外部データソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。すべての [チャート](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) を走査し、各チャートの [データ ソース](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) を確認します。データが内部かリンクベースか、壊れたリンクがあるかどうかを把握します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するにはどうすればよいですか？**

各スライドについてオブジェクト数を数え、大きな画像、透過、影、アニメーション、マルチメディアなどをチェックします。概算の複雑度スコアを付けて、パフォーマンス上のボトルネックとなり得るスライドをフラグします。