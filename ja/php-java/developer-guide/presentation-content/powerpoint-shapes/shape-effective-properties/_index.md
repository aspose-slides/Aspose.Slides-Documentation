---
title: シェイプの効果的なプロパティ
type: docs
weight: 50
url: /php-java/shape-effective-properties/
---

このトピックでは、**効果的**および**ローカル**プロパティについて説明します。これらのレベルで値を直接設定するとき

1. ポーションのスライドの部分プロパティにおいて；
1. プロトタイプシェイプのテキストスタイルのレイアウトまたはマスタースライドで（ポーションのテキストフレームシェイプがある場合）；
1. プレゼンテーションのグローバルテキスト設定で；

それらの値は**ローカル**値と呼ばれます。どのレベルでも、**ローカル**値は定義されたり省略されたりする可能性があります。しかし、アプリケーションがポーションがどのように見えるべきかを知る必要があるとき、**効果的**な値を使用します。**getEffective()**メソッドを使用して、ローカルフォーマットから効果的な値を取得できます。

このサンプルコードは、効果的な値を取得する方法を示しています：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat::getEffective();
    $localPortionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat::getEffective();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **カメラの効果的なプロパティを取得する**
Aspose.Slides for PHP via Javaは、開発者がカメラの効果的なプロパティを取得できるようにします。この目的のために、[**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData)インターフェースがAspose.Slidesに追加されました。[ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData)インターフェースは、効果的なカメラプロパティを含む不変オブジェクトを表します。[**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData)インターフェースのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData)インターフェースの一部として使用され、これは[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)クラスの[効果的な値](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--)のペアです。

このサンプルコードは、カメラの効果的なプロパティを取得する方法を示しています：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= 効果的なカメラプロパティ =");
    echo("タイプ: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("視野角: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("ズーム: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ライトリグの効果的なプロパティを取得する**
Aspose.Slides for PHP via Javaは、開発者がライトリグの効果的なプロパティを取得できるようにします。この目的のために、[**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData)インターフェースがAspose.Slidesに追加されました。[ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData)インターフェースは、効果的なライトリグプロパティを含む不変オブジェクトを表します。[**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData)インターフェースのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData)インターフェースの一部として使用され、これは[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)クラスの[効果的な値](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--)のペアです。

このサンプルコードは、ライトリグの効果的なプロパティを取得する方法を示しています：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= 効果的なライトリグプロパティ =");
    echo("タイプ: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("方向: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ベベルシェイプの効果的なプロパティを取得する**
Aspose.Slides for PHP via Javaは、開発者がベベルシェイプの効果的なプロパティを取得できるようにします。この目的のために、[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)インターフェースがAspose.Slidesに追加されました。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)インターフェースは、効果的なシェイプの面のレリーフプロパティを含む不変オブジェクトを表します。[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)インターフェースのインスタンスは、[**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData))インターフェースの一部として使用され、これは[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)クラスの[効果的な値](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--)のペアです。

このサンプルコードは、ベベルシェイプの効果的なプロパティを取得する方法を示しています：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= 効果的なシェイプの上面レリーフプロパティ =");
    echo("タイプ: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("幅: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("高さ: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキストフレームの効果的なプロパティを取得する**
Aspose.Slides for PHP via Javaを使用すると、テキストフレームの効果的なプロパティを取得できます。この目的のために、[**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData)インターフェースがAspose.Slidesに追加されました。これは、効果的なテキストフレームのフォーマットプロパティを含みます。

このサンプルコードは、効果的なテキストフレームのフォーマットプロパティを取得する方法を示しています：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("アンカーの種類: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("オートフィットの種類: " . $effectiveTextFrameFormat::getAutofitType());
    echo("テキストの垂直タイプ: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("マージン");
    echo("   左: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   上: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   右: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   下: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキストスタイルの効果的なプロパティを取得する**
Aspose.Slides for PHP via Javaを使用すると、テキストスタイルの効果的なプロパティを取得できます。この目的のために、[**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData)インターフェースがAspose.Slidesに追加されました。これは、効果的なテキストスタイルのプロパティを含みます。

このサンプルコードは、効果的なテキストスタイルのプロパティを取得する方法を示しています：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= スタイルレベル #".$i." の効果的な段落フォーマット =");
      echo("深さ: " . $effectiveStyleLevel->getDepth());
      echo("インデント: " . $effectiveStyleLevel->getIndent());
      echo("整列: " . $effectiveStyleLevel->getAlignment());
      echo("フォント整列: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **フォント高さの効果的な値を取得する**
Aspose.Slides for PHP via Javaを使用すると、フォント高さの効果的なプロパティを取得できます。ここでは、異なるプレゼンテーション構造レベルでローカルフォント高さの値が設定された後に、ポーションの効果的なフォント高さの値がどのように変わるかを示すコードを提供します：

```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("最初のポーションのサンプルテキスト");
    $portion1 = new Portion(" と二番目のポーション。");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("作成直後の効果的なフォント高さ:");
    echo("ポーション #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("ポーション #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("プレゼンテーション全体のデフォルトフォント高さ設定後の効果的なフォント高さ:");
    echo("ポーション #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("ポーション #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("段落のデフォルトフォント高さ設定後の効果的なフォント高さ:");
    echo("ポーション #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("ポーション #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("ポーション #0のフォント高さ設定後の効果的なフォント高さ:");
    echo("ポーション #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("ポーション #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("ポーション #1のフォント高さ設定後の効果的なフォント高さ:");
    echo("ポーション #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("ポーション #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テーブルのための効果的なフィルフォーマットを取得する**
Aspose.Slides for PHP via Javaを使用すると、異なるテーブルロジックの部分に対する効果的なフィルフォーマットを取得できます。この目的のために、[**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData)インターフェースがAspose.Slidesに追加されました。これは、効果的なフィルフォーマットプロパティを含みます。このことに注意してください: セルのフォーマットは常に行のフォーマットよりも優先され、行は列のフォーマットよりも優先され、列はテーブル全体よりも優先されます。

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $tableFormatEffective = $tbl->getTableFormat()->getEffective();
    $rowFormatEffective = $tbl->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnFormatEffective = $tbl->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellFormatEffective = $tbl->get_Item(0, 0)->getCellFormat()->getEffective();
    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```