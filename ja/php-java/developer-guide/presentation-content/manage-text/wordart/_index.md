---
title: PHPでWordArt効果を作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/php-java/wordart/
keywords:
- WordArt
- WordArtの作成
- WordArtテンプレート
- WordArt効果
- 影効果
- 表示効果
- 光彩効果
- WordArt変換
- 3D効果
- 外側の影効果
- 内側の影効果
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via JavaでWordArt効果を作成およびカスタマイズします。このステップバイステップガイドは、開発者がプロフェッショナルなテキストでプレゼンテーションを強化するのに役立ちます。"
---

## **WordArtについて?**
WordArtまたはWord Artは、テキストに効果を適用して目立たせる機能です。たとえば、WordArtを使用すると、テキストの輪郭を付けたり、色（またはグラデーション）で塗りつぶしたり、3D効果を追加したりできます。また、テキストの形状を傾けたり、曲げたり、伸ばしたりすることもできます。 

{{% alert color="primary" %}} 

WordArtは、テキストをグラフィカルオブジェクトのように扱うことができます。一般に、WordArtはテキストをより魅力的または目立たせるために行われる効果や特別な変更のことを指します。 

{{% /alert %}} 

**Microsoft PowerPoint の WordArt**

Microsoft PowerPointでWordArtを使用するには、事前に定義されたWordArtテンプレートのいずれかを選択する必要があります。WordArtテンプレートは、テキストまたはその形状に適用される一連の効果です。 

**Aspose.Slides の WordArt**

Aspose.Slides for PHP via Java 20.10でWordArtのサポートを実装し、その後のAspose.Slides for PHP via Javaリリースで機能を改善しました。

Aspose.Slides for PHP via Java を使用すると、独自のWordArtテンプレート（単一効果または効果の組み合わせ）を簡単に作成し、テキストに適用できます。

## **簡単な WordArt テンプレートを作成し、テキストに適用する**

**Aspose.Slides を使用する** 

まず、次の PHP コードで単純なテキストを作成します:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

次に、効果をより目立たせるためにフォントの高さを大きく設定するコードです:
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```


**Microsoft PowerPoint を使用する**

Microsoft PowerPoint の WordArt 効果メニューに移動します:

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから事前定義された WordArt 効果を選択できます。左側のメニューから新しい WordArt の設定を指定できます。 

利用可能なパラメータまたはオプションの一部は次のとおりです:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides を使用する**

ここでは、テキストに[SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/patternstyle/#SmallGrid)パターンカラーを適用し、幅1の黒いテキスト枠線を追加するコードです:
```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
```


結果のテキスト:

![todo:image_alt_text](image-20200930114108-4.png)

## **他の WordArt 効果を適用する**

**Microsoft PowerPoint を使用する**

プログラムのインターフェイスから、テキスト、テキストブロック、シェイプ、または同様の要素にこれらの効果を適用できます:

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、影、反射、Glow 効果はテキストに適用でき、3D 書式設定と 3D 回転効果はテキストブロックに適用でき、Soft Edges プロパティはシェイプオブジェクトに適用できます（3D 書式設定プロパティが設定されていなくても効果があります）。 

### **影効果を適用する**

ここでは、テキストだけに関連するプロパティを設定します。次のコードでテキストに影効果を適用します :
```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);
```


Aspose.Slides API は、OuterShadow、InnerShadow、PresetShadow の 3 種類の影をサポートしています。 

PresetShadow を使用すると、事前設定された値でテキストに影を適用できます。 

**Microsoft PowerPoint を使用する**

PowerPoint では、1 種類の影しか使用できません。以下は例です:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides を使用する**

Aspose.Slides では、InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。

**注意点:**

- OuterShadow と PresetShadow を同時に使用すると、OuterShadow の効果のみが適用されます。 
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンによります。たとえば PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では OuterShadow の効果が適用されます。 

### **テキストに反射効果を適用する**

次のコードサンプルでテキストに表示を追加します :
```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```


### **テキストに Glow 効果を適用する**

次のコードでテキストに Glow 効果を適用し、輝かせます:
```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```


操作結果:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

影、表示、Glow のパラメータは変更できます。効果のプロパティはテキストの各部分ごとに個別に設定されます。 

{{% /alert %}} 

### **WordArt で変形を使用する**

次のコードで変形プロパティ（テキスト全体に適用）を使用します:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```


結果:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint と Aspose.Slides for PHP via Java の両方で、事前定義された変形タイプがいくつか提供されています。

{{% /alert %}} 

**PowerPoint を使用する**

事前定義された変形タイプにアクセスするには、**書式** → **テキスト効果** → **変形** の順に進みます。

**Aspose.Slides を使用する**

変形タイプを選択するには、TextShapeType 列挙体を使用します。 

### **テキストとシェイプに 3D 効果を適用する**

次のサンプルコードでテキストシェイプに 3D 効果を設定します:
```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```


結果のテキストとシェイプ:

![todo:image_alt_text](image-20200930114816-9.png)

次の PHP コードでテキストに 3D 効果を適用します:
```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```


操作結果:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

テキストまたはシェイプへの 3D 効果の適用および効果間の相互作用は、特定のルールに基づいています。テキストとそのテキストを含むシェイプのシーンを考えてみてください。3D 効果は 3D オブジェクトの表現と、オブジェクトが配置されるシーンを含みます。 

- 図形とテキストの両方にシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。 
- 図形に独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。 
- それ以外の場合（シェイプに元々 3D 効果がない場合）は、シェイプは平面のままで、3D 効果はテキストのみに適用されます。 

これらの説明は ThreeDFormat.getLightRig() および ThreeDFormat.getCamera() メソッドに関連しています。 

{{% /alert %}} 

## **テキストに外側の影効果を適用する**
Aspose.Slides for PHP via Java は、[OuterShadow](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/) および [InnerShadow](https://reference.aspose.com/slides/php-java/aspose.slides/innershadow/) クラスを提供し、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) に含まれるテキストに影効果を適用できます。次の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに Rectangle タイプの AutoShape を追加します。
4. AutoShape に関連付けられた TextFrame にアクセスします。
5. AutoShape の FillType を NoFill に設定します。
6. OuterShadow クラスのインスタンスを作成します。
7. 影の BlurRadius を設定します。
8. 影の Direction を設定します。
9. 影の Distance を設定します。
10. RectanglelAlign を TopLeft に設定します。
11. 影の PresetColor を Black に設定します。
12. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

このサンプルコード（上記手順の実装）は、テキストに外側の影効果を適用する方法を示しています:
```php
  $pres = new Presentation();
  try {
    # スライドの参照を取得
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプの AutoShape を追加
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # 矩形に TextFrame を追加
    $ashp->addTextFrame("Aspose TextBox");
    # テキストの影を取得したい場合に備えてシェイプの塗りつぶしを無効にする
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 外部影を追加し、必要なすべてのパラメータを設定
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # プレゼンテーションをディスクに保存
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプに内側の影効果を適用する**
次の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. Rectangle タイプの AutoShape を追加します。
4. InnerShadowEffect を有効にします。
5. 必要なすべてのパラメータを設定します。
6. ColorType を Scheme に設定します。
7. Scheme Color を設定します。
8. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

このサンプルコード（上記手順に基づく）は、2 つのシェイプ間にコネクタを追加する方法を示しています:
```php
  $pres = new Presentation();
  try {
    # スライドの参照を取得
    $slide = $pres->getSlides()->get_Item(0);
    # 矩形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 矩形に TextFrame を追加
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # InnerShadowEffect を有効化
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # 必要なすべてのパラメータを設定
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # ColorType を Scheme に設定
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # スキームカラーを設定
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # プレゼンテーションを保存
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**異なるフォントやスクリプト（例: アラビア語、中文）で WordArt 効果を使用できますか？**

はい、Aspose.Slides は Unicode をサポートしており、すべての主要なフォントとスクリプトで動作します。影、塗りつぶし、輪郭などの WordArt 効果は言語に関係なく適用できますが、フォントの可用性や描画はシステムにインストールされたフォントに依存する場合があります。

**スライドマスタ要素に WordArt 効果を適用できますか？**

はい、マスタースライド上のシェイプ（タイトルプレースホルダー、フッター、背景テキストなど）に WordArt 効果を適用できます。マスターレイアウトの変更は、関連付けられたすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**

多少影響します。影、Glow、グラデーション塗りなどの WordArt 効果は、追加の書式メタデータが加わるためファイルサイズが若干増加しますが、差はほとんど無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい、`getImage` メソッドを使用して、[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) または [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) クラスから WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングできます。これにより、保存やエクスポート前にメモリ上または画面上で結果をプレビューできます。