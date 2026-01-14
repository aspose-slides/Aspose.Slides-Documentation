---
title: "PHP でプレゼンテーションからシェイプの有効プロパティを取得する"
linktitle: "有効プロパティ"
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
  - 塗りつぶし 形式
  - PowerPoint
  - プレゼンテーション
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java が PowerPoint の正確なレンダリングのためにシェイプの有効プロパティを計算し適用する方法を紹介します。"
---

このトピックでは、**effective** と **local** のプロパティについて説明します。これらのレベルで値を直接設定すると

1. スライド上の該当部分のプロパティで;
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイルで（該当部分のテキストフレームシェイプがある場合）;
1. プレゼンテーション全体のグローバルテキスト設定で;

それらの値は **local** 値と呼ばれます。任意のレベルで **local** 値は定義されても、定義されなくても構いません。しかし、アプリケーションが部分の見た目を知る必要がある場合は **effective** 値を使用します。**local** フォーマットから **getEffective()** メソッドを使用することで **effective** 値を取得できます。

このサンプルコードは **effective** 値の取得方法を示します:
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


## **カメラの有効プロパティを取得**
Aspose.Slides for PHP via Java は、開発者がカメラの **effective** プロパティを取得できるようにします。この目的のために、`ICameraEffectiveData` クラスが Aspose.Slides に追加されました。`ICameraEffectiveData` クラスは、カメラの有効プロパティを保持する不変オブジェクトを表します。`ICameraEffectiveData` クラスのインスタンスは、`IThreeDFormatEffectiveData` クラスの一部として使用され、これは[effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) のペアであり、[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) クラスに対応します。

このサンプルコードはカメラの有効プロパティを取得する方法を示します:
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


## **ライトリグの有効プロパティを取得**
Aspose.Slides for PHP via Java は、開発者がライトリグの **effective** プロパティを取得できるようにします。この目的のために、`ILightRigEffectiveData` クラスが Aspose.Slides に追加されました。`ILightRigEffectiveData` クラスは、ライトリグの有効プロパティを保持する不変オブジェクトを表します。`ILightRigEffectiveData` クラスのインスタンスは、`IThreeDFormatEffectiveData` クラスの一部として使用され、これは[effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) のペアであり、[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) クラスに対応します。

このサンプルコードはライトリグの有効プロパティを取得する方法を示します:
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


## **ベベルシェイプの有効プロパティを取得**
Aspose.Slides for PHP via Java は、開発者がベベルシェイプの **effective** プロパティを取得できるようにします。この目的のために、`IShapeBevelEffectiveData` クラスが Aspose.Slides に追加されました。`IShapeBevelEffectiveData` クラスは、シェイプの面のリリーフプロパティを保持する不変オブジェクトを表します。`IShapeBevelEffectiveData` クラスのインスタンスは、`IThreeDFormatEffectiveData` クラスの一部として使用され、これは[effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) のペアであり、[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) クラスに対応します。

このサンプルコードはベベルシェイプの有効プロパティを取得する方法を示します:
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


## **テキストフレームの有効プロパティを取得**
Aspose.Slides for PHP via Java を使用すると、テキストフレームの **effective** プロパティを取得できます。この目的のために、`ITextFrameFormatEffectiveData` クラスが Aspose.Slides に追加されました。これはテキストフレームの有効な書式設定プロパティを含みます。

このサンプルコードはテキストフレームの有効書式設定プロパティを取得する方法を示します:
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


## **テキストスタイルの有効プロパティを取得**
Aspose.Slides for PHP via Java を使用すると、テキストスタイルの **effective** プロパティを取得できます。この目的のために、`ITextStyleEffectiveData` クラスが Aspose.Slides に追加されました。これは有効なテキストスタイルプロパティを含みます。

このサンプルコードはテキストスタイルの有効プロパティを取得する方法を示します:
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


## **フォント高さの有効値を取得**
Aspose.Slides for PHP via Java を使用すると、フォント高さの **effective** プロパティを取得できます。ここでは、プレゼンテーションのさまざまな構造レベルでローカルのフォント高さが設定された後に、部分の有効フォント高さがどのように変化するかを示すコードを提供しています:
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


## **テーブルの有効な塗りつぶし形式を取得**
Aspose.Slides for PHP via Java を使用すると、テーブルのさまざまな論理部分の有効な塗りつぶし書式設定を取得できます。この目的のために、`ICellFormatEffectiveData` クラスが Aspose.Slides に追加されました。これは有効な塗りつぶし書式設定プロパティを含みます。注意点として、セルの書式設定は常に行の書式設定より優先され、行は列より優先され、列はテーブル全体より優先されます。
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


## **よくある質問**

**スナップショットを取得したのか、ライブオブジェクトを取得したのかをどのように判断し、いつ再度 effective プロパティを読み取るべきですか？**  
EffectiveData オブジェクトは呼び出し時点で計算された値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合は、更新された値を取得するために EffectiveData を再取得してください。

**レイアウト/マスタースライドを変更すると、すでに取得した effective プロパティに影響しますか？**  
はい、ただし再度読み取ったときにのみ反映されます。取得済みの EffectiveData オブジェクトは自動的に更新されないため、レイアウトやマスターを変更した後に再度要求してください。

**EffectiveData を介して値を変更できますか？**  
できません。EffectiveData は読み取り専用です。ローカルの書式設定オブジェクト（シェイプ/テキスト/3D など）を変更し、必要に応じて再度 EffectiveData を取得して結果を確認してください。

**シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**  
そのプロパティはデフォルトのメカニズム（PowerPoint / Aspose.Slides の既定値）に従って決定されます。決定された値が EffectiveData のスナップショットに含まれます。

**有効なフォント値から、どのレベルがサイズやフォント名を提供したか判断できますか？**  
直接は判断できません。EffectiveData は最終的な値だけを返します。元の定義元を知りたい場合は、部分/段落/テキストフレームのローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを調べて、最初に明示的に設定された場所を特定してください。

**EffectiveData の値がローカル値と同一に見えることがあるのはなぜですか？**  
ローカル値が最終的な値となり、上位レベルからの継承が不要だった場合です。そのようなケースでは effective 値がローカル値と一致します。

**いつ effective プロパティを使用し、いつローカルプロパティだけを操作すべきですか？**  
すべての継承が適用された「実際に表示される」結果が必要なときは EffectiveData を使用してください（例: 色やインデント、サイズの整合性を取る場合）。特定のレベルで書式設定を変更したいときはローカルプロパティを操作し、必要に応じて再度 EffectiveData を取得して結果を検証してください。