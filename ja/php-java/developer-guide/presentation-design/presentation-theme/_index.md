---
title: PHPでプレゼンテーションテーマを管理する
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
description: "Java 経由で PHP 用 Aspose.Slides のプレゼンテーションテーマをマスターし、一貫したブランディングで PowerPoint ファイルを作成、カスタマイズ、変換します。"
---

プレゼンテーションテーマはデザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選んでいることになります。

PowerPoint のテーマは、色、[fonts](/slides/ja/php-java/powerpoint-fonts/)、[background styles](/slides/ja/php-java/presentation-background/)、およびエフェクトで構成されています。

![theme-constituents](theme-constituents.png)

## **テーマ色の変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更します。新しいテーマ色を選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor) 列挙体の値を提供します。

この PHP コードは、テーマのアクセントカラーを変更する方法を示しています：
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


次の方法で、結果となる色の有効な値を取得できます：
```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```


色変更操作をさらに示すために、別の要素を作成し、最初の操作で取得したアクセントカラーを割り当てます。その後、テーマ内の色を変更します：
```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```


新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマ色を設定する**

メインテーマカラー(1) に輝度変換を適用すると、追加パレット(2) から色が生成されます。その後、これらのテーマ色を設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1** - メインテーマカラー

**2** - 追加パレットのカラー

この PHP コードは、メインテーマカラーから取得した追加パレットの色をシェイプで使用する操作を示しています：
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # アクセント 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # アクセント 4、明るさ 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # アクセント 4、明るさ 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # アクセント 4、明るさ 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # アクセント 4、暗さ 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # アクセント 4、暗さ 50%
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


## **テーマフォントの変更**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は PowerPoint で使用されるものと同様の特別な識別子を使用します：

* **+mn-lt** - 本文フォント ラテン語（Minor Latin Font）
* **+mj-lt** - 見出しフォント ラテン語（Major Latin Font）
* **+mn-ea** - 本文フォント 東アジア語（Minor East Asian Font）
* **+mj-ea** - 本文フォント 東アジア語（Major East Asian Font）

この PHP コードは、テーマ要素にラテン語フォントを割り当てる方法を示しています：
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```


この PHP コードは、プレゼンテーションテーマのフォントを変更する方法を示しています：
```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```


すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}} 
PowerPoint のフォントについては、[PowerPoint fonts](/slides/ja/php-java/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 の事前定義された背景を提供しますが、そのうち 3 つだけが典型的なプレゼンテーションに保存されます。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint アプリでプレゼンテーションを保存した後、次の PHP コードを実行してプレゼンテーション内の事前定義背景の数を取得できます：
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
[BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) プロパティを [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) クラスから使用すると、PowerPoint テーマ内の背景スタイルを追加または取得できます。
{{% /alert %}} 

この PHP コードは、プレゼンテーションの背景を設定する方法を示しています：
```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```


**インデックスガイド**: 0 は塗りなしに使用されます。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}} 
PowerPoint の背景については、[PowerPoint Background](/slides/ja/php-java/presentation-background/) をご覧ください。
{{% /alert %}}

## **テーマエフェクトの変更**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を持ちます。これらの配列は 3 つのエフェクト（subtle、moderate、intense）に結合されます。たとえば、特定のシェイプにエフェクトを適用した結果は次のとおりです：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) クラスの 3 つのプロパティ（[FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)）を使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

この PHP コードは、要素の一部を変更してテーマエフェクトを変更する方法を示しています：
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


塗りの色、塗りのタイプ、影のエフェクトなどの結果としての変更：

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**マスターを変更せずに単一のスライドにテーマを適用できますか？**

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、[SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) を使用して、マスターテーマをそのままにローカルテーマをそのスライドだけに適用できます。

**あるプレゼンテーションから別のプレゼンテーションにテーマを安全に移行する最適な方法は何ですか？**

[Clone slides](/slides/ja/php-java/clone-slides/) をマスターと共にターゲットのプレゼンテーションにコピーします。これにより元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫したままです。

**すべての継承とオーバーライドの後に「有効」な値を確認するにはどうすればよいですか？**

テーマ/カラー/フォント/エフェクトの ["effective" views](/slides/ja/php-java/shape-effective-properties/) を使用します。これらはマスターに加えてローカルオーバーライドが適用された後の最終的に解決されたプロパティを返します。