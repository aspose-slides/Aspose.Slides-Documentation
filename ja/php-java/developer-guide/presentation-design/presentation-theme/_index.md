---
title: PHPでプレゼンテーションテーマを管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/php-java/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマ効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してマスタープレゼンテーションテーマを管理し、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
プレゼンテーションテーマはデザイン要素のプロパティを定義します。テーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選んだことになります。

PowerPoint では、テーマは色、[fonts](/slides/ja/php-java/powerpoint-fonts/)、[background styles](/slides/ja/php-java/presentation-background/)、および効果で構成されます。

![theme-constituents](theme-constituents.png)

## **テーマカラーの変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更できます。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SchemeColor) 列挙体の値を提供しています。

この PHP コードはテーマのアクセントカラーを変更する方法を示しています:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

この方法で結果の色の実際の値を取得できます:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

さらにカラー変更操作をデモンストレーションするために、別の要素を作成し、最初の操作で取得したアクセントカラーを割り当てます。その後、テーマの色を変更します:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

メインテーマカラー (1) に輝度変換を適用すると、追加パレット (2) の色が生成されます。その後、これらのテーマカラーを取得および設定できます。

![additional-palette-colors](additional-palette-colors.png)

**1** - メインテーマカラー  

**2** - 追加パレットのカラー

この PHP コードは、メインテーマカラーから取得した追加パレットの色をシェイプで使用する操作を示しています:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # アクセント4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # アクセント4、明るさ80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # アクセント4、明るさ60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # アクセント4、明るさ40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # アクセント4、暗さ25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # アクセント4、暗さ50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **`SchemeColor` を `ColorScheme` のカラーにマッピング**

[SchemeColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/schemecolor/) を使用すると、次のテーマカラー値が含まれていることに気付くかもしれません:

`Background1`、`Background2`、`Text1`、`Text2`。

ただし、`Presentation::getMasterTheme()::getColorScheme()` は [ColorScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/colorscheme/) を返し、対応するカラーを次のように公開します:

`Dark1`、`Dark2`、`Light1`、`Light2`。

この違いは名前だけです。これらの値は同じテーマカラー スロットを指し、マッピングは固定されています:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` と `Dark`/`Light` の間に動的な変換はありません。単に同じテーマカラーの別名です。

この名称の違いは Microsoft Office の用語に由来します。古い Office バージョンでは `Dark 1`、`Light 1`、`Dark 2`、`Light 2` が使用され、新しい UI バージョンでは同じスロットが `Text 1`、`Background 1`、`Text 2`、`Background 2` と表示されます。

## **テーマフォントの変更**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は PowerPoint で使用されるものと同様の特別な識別子を使用します:

* **+mn-lt** - 本文フォント ラテン (Minor Latin Font)
* **+mj-lt** - 見出しフォント ラテン (Major Latin Font)
* **+mn-ea** - 本文フォント 東アジア (Minor East Asian Font)
* **+mj-ea** - 本文フォント 東アジア (Major East Asian Font)

この PHP コードはラテンフォントをテーマ要素に割り当てる方法を示しています:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

この PHP コードはプレゼンテーションテーマのフォントを変更する方法を示しています:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

すべてのテキスト ボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}}  
[PowerPoint fonts](/slides/ja/php-java/powerpoint-fonts/) を確認したい場合があります。  
{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 種類の事前定義済み背景を提供しますが、通常のプレゼンテーションに保存されるのはそのうちの 3 つだけです。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint アプリでプレゼンテーションを保存した後、次の PHP コードを実行してプレゼンテーション内の事前定義済み背景の数を取得できます:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}}  
[BackgroundFillStyles](https://reference.aspose.com/slides/ja/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) プロパティを [FormatScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/FormatScheme) クラスから使用すると、PowerPoint テーマ内の背景スタイルを追加または取得できます。  
{{% /alert %}}

この PHP コードはプレゼンテーションの背景を設定する方法を示しています:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);

```

**インデックスガイド**: 0 は塗りなしを表します。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}}  
[PowerPoint Background](/slides/ja/php-java/presentation-background/) を確認したい場合があります。  
{{% /alert %}}

## **テーマ効果の変更**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を含みます。これらの配列は 3 つの効果 (subtle、moderate、intense) に結合されます。たとえば、特定のシェイプに効果を適用した結果は次のとおりです:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/FormatScheme) クラスの 3 つのプロパティ (**FillStyles**、**LineStyles**、**EffectStyles**) を使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

この PHP コードは要素の一部を変更してテーマ効果を変更する方法を示しています:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

塗りの色、塗りタイプ、影効果などの結果の変化:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Can I apply a theme to a single slide without changing the master?**  
はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、マスターテーマをそのままにして特定のスライドにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidethememanager/) を使用）。

**What’s the safest way to carry a theme from one presentation to another?**  
[Clone slides](/slides/ja/php-java/clone-slides/) とそれらのマスターを対象のプレゼンテーションにコピーします。これにより元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫したままになります。

**How can I see the "effective" values after all inheritance and overrides?**  
テーマ/カラー/フォント/効果の ["effective" views](/slides/ja/php-java/shape-effective-properties/) を使用してください。これらはマスターとローカルオーバーライドが適用された後の最終的に解決されたプロパティを返します。