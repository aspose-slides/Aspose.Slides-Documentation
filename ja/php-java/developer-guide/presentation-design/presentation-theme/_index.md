---
title: プレゼンテーションテーマ
type: docs
weight: 10
url: /php-java/presentation-theme/
keywords: "テーマ, パワーポイントテーマ, パワーポイントプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "パワーポイントプレゼンテーションテーマ"
---

プレゼンテーションテーマは、デザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、視覚要素とそのプロパティの特定のセットを基本的に選んでいることになります。

PowerPointでは、テーマは色、[フォント](/slides/php-java/powerpoint-fonts/)、[背景スタイル](/slides/php-java/presentation-background/)、および効果を含みます。

![theme-constituents](theme-constituents.png)

## **テーマカラーを変更する**

パワーポイントテーマは、スライド上のさまざまな要素に特定の色のセットを使用します。色が気に入らない場合は、テーマの新しい色を適用することでそれらを変更できます。新しいテーマカラーを選択できるようにするため、Aspose.Slidesは[SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor)列挙の下に値を提供します。

このPHPコードは、テーマのアクセント色を変更する方法を示しています：

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

このようにして結果カラーの実効値を決定できます：

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

色変更操作を示すために、別の要素を作成し、（最初の操作から）アクセント色をそれに割り当てます。次に、テーマ内の色を変更します：

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定する**

主テーマカラー(1)に輝度変換を適用すると、追加パレット(2)の色が形成されます。その後、それらのテーマ色を設定したり取得したりできます。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主テーマカラー

**2** - 追加パレットの色。

このPHPコードは、主テーマカラーから追加パレットの色を取得し、それを形状に使用する操作を示しています：

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # アクセント4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # アクセント4, 明るい80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # アクセント4, 明るい60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # アクセント4, 暗い25%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # アクセント4, 暗い50%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # アクセント4, 暗い75%
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

## **テーマフォントを変更する**

テーマ及びその他の目的のためにフォントを選択できるようにするため、Aspose.Slidesは次の特別な識別子を使用します（PowerPointで使用されるものに似ています）：

* **+mn-lt** - ボディフォントラテン（マイナーラテンフォント）
* **+mj-lt** - ヘッディングフォントラテン（メジャーラテンフォント）
* **+mn-ea** - ボディフォント東アジア（マイナー東アジアフォント）
* **+mj-ea** - ボディフォント東アジア（メジャー東アジアフォント）

このPHPコードは、テーマ要素にラテンフォントを割り当てる方法を示しています：

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("テーマテキストフォーマット");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

このPHPコードは、プレゼンテーションテーマフォントを変更する方法を示しています：

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

すべてのテキストボックス内のフォントが更新されます。

{{% alert color="primary" title="ヒント" %}} 

[パワーポイントフォント](/slides/php-java/powerpoint-fonts/)を確認することをお勧めします。

{{% /alert %}}

## **テーマの背景スタイルを変更する**

デフォルトでは、パワーポイントアプリは12個のプリセット背景を提供しますが、そのうちの3つだけが一般的なプレゼンテーションに保存されます。

![todo:image_alt_text](presentation-design_8.png)

たとえば、パワーポイントアプリでプレゼンテーションを保存した後、以下のPHPコードを実行して、プレゼンテーション内のプリセット背景の数を確認できます：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("テーマの背景塗りつぶしスタイルの数は " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

[FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme)クラスの[BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--)プロパティを使用すると、パワーポイントテーマの背景スタイルを追加またはアクセスできます。

{{% /alert %}} 

このPHPコードは、プレゼンテーションの背景を設定する方法を示しています：

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);

```

**インデックスガイド**: 0は塗りつぶしなしです。インデックスは1から始まります。

{{% alert color="primary" title="ヒント" %}} 

[パワーポイント背景](/slides/php-java/presentation-background/)を確認することをお勧めします。

{{% /alert %}}

## **テーマ効果を変更する**

パワーポイントテーマは通常、各スタイル配列に3つの値を含みます。それらの配列は、これらの3つの効果：微妙な、中程度、強烈に結合されます。たとえば、次の図は、効果が特定の形状に適用されたときの結果です：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme)クラスの3つのプロパティ（[FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--))を使用すると、テーマ内の要素を変更できます（PowerPointのオプションよりもさらに柔軟に）。

このPHPコードは、要素の一部を変更することでテーマ効果を変更する方法を示しています：

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

塗りつぶし色、塗りつぶしタイプ、シャドウ効果などの結果変更：

![todo:image_alt_text](presentation-design_11.png)