---
title: プレゼンテーションの確認
type: docs
weight: 30
url: /ja/php-java/examine-presentation/
keywords:
- PowerPoint
- プレゼンテーション
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティの取得
- プロパティの読み取り
- プロパティの変更
- プロパティの修正
- PPTX
- PPT
- PHP
- Java
description: "Javaを介してPHPでPowerPointプレゼンテーションのプロパティを読み取り、変更します"
---

Aspose.Slides for PHP via Javaを使用すると、プレゼンテーションを調べてそのプロパティを把握し、挙動を理解することができます。

{{% alert title="情報" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo)および[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/)クラスには、ここでの操作に使われるプロパティとメソッドが含まれています。

{{% /alert %}} 

## **プレゼンテーション形式の確認**

プレゼンテーションに取り組む前に、現在どの形式（PPT、PPTX、ODPなど）でプレゼンテーションが保存されているかを知りたいと思うことがあります。

プレゼンテーションを読み込まずにその形式を確認できます。以下のPHPコードを参照してください：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **プレゼンテーションプロパティの取得**

このPHPコードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--)クラスの下にあるプロパティも確認したいかもしれません。

## **プレゼンテーションプロパティの更新**

Aspose.Slidesは、プレゼンテーションプロパティを変更するための[PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)メソッドを提供しています。

PowerPointプレゼンテーションが、以下に示すドキュメントプロパティを持っていると仮定しましょう。

![PowerPointプレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています：

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("私のタイトル");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

ドキュメントプロパティを変更した結果は以下に示されています。

![PowerPointプレゼンテーションの変更されたドキュメントプロパティ](output_properties.png)

## **役立つリンク**

プレゼンテーションとそのセキュリティ属性に関するさらに詳細な情報を得るために、以下のリンクが役立つかもしれません：

- [プレゼンテーションが暗号化されているかどうかの確認](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護されているかどうかの確認（読み取り専用）](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [プレゼンテーションをロードする前にパスワード保護されているかどうかの確認](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).