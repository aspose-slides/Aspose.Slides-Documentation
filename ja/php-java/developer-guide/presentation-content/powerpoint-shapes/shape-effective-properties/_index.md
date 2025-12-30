---
title: PHP でプレゼンテーションからシェイプの効果的なプロパティを取得する
linktitle: 効果的なプロパティ
type: docs
weight: 50
url: /ja/php-java/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 書式
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java が、正確な PowerPoint 表示のために効果的なシェイプ プロパティを計算および適用する方法をご紹介します。"
---

このトピックでは、**effective** と **local** のプロパティについて説明します。これらのレベルで値を直接設定する場合

1. 部分のスライド上の部分プロパティ;
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（部分のテキストフレームシェイプにある場合）;
1. プレゼンテーション全体のテキスト設定;

これらの値は **local** 値と呼ばれます。任意のレベルで、**local** 値は定義されてもよいし、省略されてもよいです。しかし、アプリケーションが部分の見た目を知る必要がある場合、**effective** 値を使用します。**getEffective()** メソッドをローカル形式から呼び出すことで、effective 値を取得できます。

このサンプルコードは、effective 値の取得方法を示しています:
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


## **カメラの Effective プロパティを取得**
Aspose.Slides for PHP via Java は、開発者がカメラの effective プロパティを取得できるようにします。そのために、[**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) インターフェイスが Aspose.Slides に追加されました。[ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) インターフェイスは、effective カメラプロパティを含む不変オブジェクトを表します。[**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードは、カメラの effective プロパティを取得する方法を示しています:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective camera properties =");
    echo("Type: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Field of view: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ライト リグの Effective プロパティを取得**
Aspose.Slides for PHP via Java は、開発者が Light Rig の effective プロパティを取得できるようにします。そのために、[**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) インターフェイスが Aspose.Slides に追加されました。[ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) インターフェイスは、effective ライト リグプロパティを含む不変オブジェクトを表します。[**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードは、Light Rig の effective プロパティを取得する方法を示しています:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective light rig properties =");
    echo("Type: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Direction: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ベベル シェイプの Effective プロパティを取得**
Aspose.Slides for PHP via Java は、開発者がベベル シェイプの effective プロパティを取得できるようにします。そのために、[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) インターフェイスが Aspose.Slides に追加されました。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) インターフェイスは、effective シェイプの面リリーフプロパティを含む不変オブジェクトを表します。[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードは、ベベル シェイプの effective プロパティを取得する方法を示しています:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective shape's top face relief properties =");
    echo("Type: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Width: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Height: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキスト フレームの Effective プロパティを取得**
Aspose.Slides for PHP via Java を使用すると、テキスト フレームの effective プロパティを取得できます。そのために、[**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) インターフェイスが Aspose.Slides に追加されました。これには effective テキスト フレームの書式設定プロパティが含まれます。

このサンプルコードは、effective テキスト フレームの書式設定プロパティを取得する方法を示しています:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Anchoring type: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Autofit type: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Text vertical type: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Margins");
    echo("   Left: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Top: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Right: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Bottom: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキスト スタイルの Effective プロパティを取得**
Aspose.Slides for PHP via Java を使用すると、テキスト スタイルの effective プロパティを取得できます。そのために、[**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) インターフェイスが Aspose.Slides に追加されました。これには effective テキスト スタイルのプロパティが含まれます。

このサンプルコードは、effective テキスト スタイルのプロパティを取得する方法を示しています:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Effective paragraph formatting for style level #" . $i . " =");
      echo("Depth: " . $effectiveStyleLevel->getDepth());
      echo("Indent: " . $effectiveStyleLevel->getIndent());
      echo("Alignment: " . $effectiveStyleLevel->getAlignment());
      echo("Font alignment: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Effective フォント高さ値の取得**
Aspose.Slides for PHP via Java を使用すると、フォント高さの effective プロパティを取得できます。ここでは、プレゼンテーションのさまざまな構造レベルでローカルのフォント高さが設定された後に、部分の effective フォント高さ値が変化する様子を示すコードを提供します。
```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Sample text with first portion");
    $portion1 = new Portion(" and second portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Effective font height just after creation:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Effective font height after setting entire presentation default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Effective font height after setting paragraph default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Effective font height after setting portion #0 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Effective font height after setting portion #1 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブルの Effective 塗りつぶし書式の取得**
Aspose.Slides for PHP via Java を使用すると、テーブルのさまざまな論理部分の effective 塗りつぶし書式を取得できます。そのために、[**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) インターフェイスが Aspose.Slides に追加されました。これには effective 塗りつぶし書式プロパティが含まれます。次の点に注意してください：セルの書式設定は常に行の書式設定より優先され、行は列より優先され、列はテーブル全体より優先されます。
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


## **FAQ**

**「スナップショット」を取得したのか「ライブ オブジェクト」なのかをどう判断し、いつ effective プロパティを再取得すべきか？**

EffectiveData オブジェクトは、呼び出し時点で計算された値の不変のスナップショットです。シェイプのローカルまたは継承設定を変更した場合、更新された値を取得するために effective データを再取得してください。

**レイアウト／マスタスライドの変更は、既に取得した effective プロパティに影響しますか？**

はい、ただし再度取得した後にのみ反映されます。既に取得した EffectiveData オブジェクトは自動で更新されません—レイアウトやマスタを変更した後に再度取得してください。

**EffectiveData を通じて値を変更できますか？**

いいえ。EffectiveData は読み取り専用です。ローカルの書式設定オブジェクト（シェイプ、テキスト、3D など）を変更し、その後再度 effective 値を取得してください。

**シェイプレベルでもレイアウト／マスタでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

そのプロパティが設定されていない場合、effective 値はデフォルトメカニズム（PowerPoint/Aspose.Slides のデフォルト）によって決定されます。その解決された値が EffectiveData のスナップショットの一部となります。

**effective フォント値から、どのレベルがサイズや書体を提供したか判断できますか？**

直接はできません。EffectiveData は最終的な値を返すだけです。ソースを特定するには、部分、段落、テキスト フレームのローカル値や、レイアウト／マスタ／プレゼンテーションのテキスト スタイルを確認し、最初に明示的に定義されている場所を探す必要があります。

**EffectiveData の値がローカル値と同一に見えるのはなぜですか？**

ローカル値が最終的な値となったためです（上位レベルからの継承が不要でした）。このような場合、effective 値はローカル値と同一になります。

**effective プロパティはいつ使い、ローカルプロパティだけを使うのはいつですか？**

すべての継承が適用された「実際の」結果が必要な場合は EffectiveData を使用します（例: 色、インデント、サイズを合わせる場合）。特定のレベルで書式を変更したい場合はローカル プロパティを変更し、必要に応じて EffectiveData を再取得して結果を確認してください。