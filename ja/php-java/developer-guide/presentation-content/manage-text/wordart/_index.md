---
title: PHPでWordArt効果を作成および適用
linktitle: WordArt
type: docs
weight: 110
url: /ja/php-java/wordart/
keywords:
- WordArt
- WordArtを作成
- WordArtテンプレート
- WordArt効果
- 影効果
- 表示効果
- グロー効果
- WordArt変換
- 3D効果
- 外部影効果
- 内部影効果
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via JavaでWordArt効果を作成およびカスタマイズします。このステップバイステップガイドは、開発者がプロフェッショナルなテキストでプレゼンテーションを向上させるのに役立ちます。"
---

## **WordArt について?**
WordArt（または Word Art）は、テキストに効果を適用して目立たせることができる機能です。たとえば WordArt を使用すると、テキストに輪郭線を付けたり、色（またはグラデーション）で塗りつぶしたり、3D 効果を追加したりできます。また、テキストの形状をねじったり、曲げたり、伸ばしたりすることもできます。

{{% alert color="primary" %}} 
WordArt はテキストをグラフィックオブジェクトのように扱うことができます。一般的に、WordArt はテキストをより魅力的または目立たせるために行われる効果や特別な変更で構成されています。 
{{% /alert %}} 

**Microsoft PowerPoint の WordArt**

Microsoft PowerPoint で WordArt を使用するには、事前定義された WordArt テンプレートのいずれかを選択する必要があります。WordArt テンプレートは、テキストまたはその形状に適用される効果のセットです。

**Aspose.Slides の WordArt**

Aspose.Slides for PHP via Java 20.10 で WordArt のサポートを実装し、以降の Aspose.Slides for PHP via Java のリリースで機能を改善しました。

Aspose.Slides for PHP via Java を使用すると、独自の WordArt テンプレート（単一の効果または効果の組み合わせ）を簡単に作成し、テキストに適用できます。

## **シンプルな WordArt テンプレートを作成しテキストに適用する**

**Aspose.Slides の使用** 

まず、この PHP コードを使用してシンプルなテキストを作成します:
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

次に、このコードでテキストのフォント高さを大きく設定し、効果をより目立たせます:
```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```


**Microsoft PowerPoint の使用**

Microsoft PowerPoint で WordArt 効果メニューを開きます:
![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから事前定義された WordArt 効果を選択できます。左側のメニューから新しい WordArt の設定を指定できます。

利用可能なパラメータまたはオプションの一部は次のとおりです:
![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides の使用**

ここでは、テキストに [SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid) パターンカラーを適用し、幅 1 の黒いテキスト枠線をこのコードで追加します:
```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
```


結果のテキストは次のとおりです:
![todo:image_alt_text](image-20200930114108-4.png)

## **その他の WordArt 効果を適用する**

**Microsoft PowerPoint の使用**

プログラムのインターフェイスから、テキスト、テキストブロック、図形、または同様の要素にこれらの効果を適用できます:
![todo:image_alt_text](image-20200930114129-5.png)

たとえば、シャドウ、反射、グロウ効果はテキストに適用できます。3D フォーマットと 3D 回転効果はテキストブロックに適用できます。ソフトエッジ プロパティは図形オブジェクトに適用でき（3D フォーマット プロパティが設定されていなくても効果があります）。

### **シャドウ効果を適用する**

ここでは、テキストに関連するプロパティのみを設定することを目的としています。このコードでテキストにシャドウ効果を適用します。
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


Aspose.Slides API は、OuterShadow、InnerShadow、PresetShadow の 3 種類のシャドウをサポートしています。

PresetShadow を使用すると、テキストに（プリセット値で）シャドウを適用できます。

**Microsoft PowerPoint の使用**

PowerPoint では、1 種類のシャドウのみ使用できます。例は次のとおりです:
![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides の使用**

Aspose.Slides は実際に、InnerShadow と PresetShadow の 2 種類のシャドウを同時に適用できます。

注記:
- OuterShadow と PresetShadow を同時に使用すると、OuterShadow の効果のみが適用されます。
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンによって異なります。たとえば、PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では OuterShadow の効果が適用されます。

### **テキストに反射効果を適用する**

このコードサンプルでテキストに反射効果を追加します。
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


### **テキストにグロウ効果を適用する**

このコードを使用してテキストにグロウ効果を適用し、輝かせたり目立たせたりします。
```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```


操作の結果は次のとおりです:
![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
シャドウ、反射、グロウのパラメータは変更できます。効果のプロパティはテキストの各部分に個別に設定されます。 
{{% /alert %}} 

### **WordArt の変形を使用する**

このコードで Transform プロパティ（テキスト全体に固有）を使用します。
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```


結果は次のとおりです:
![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint と Aspose.Slides for PHP via Java の両方が、いくつかの事前定義された変形タイプを提供しています。 
{{% /alert %}} 

**PowerPoint の使用**

事前定義された変形タイプにアクセスするには、**Format** → **TextEffect** → **Transform** の順に進みます。

**Aspose.Slides の使用**

変形タイプを選択するには、TextShapeType 列挙体を使用します。

### **テキストと図形に 3D 効果を適用する**

このサンプルコードでテキスト図形に 3D 効果を設定します:
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


結果のテキストとその形状は次のとおりです:
![todo:image_alt_text](image-20200930114816-9.png)

この PHP コードでテキストに 3D 効果を適用します:
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


操作の結果は次のとおりです:
![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
テキストやその形状への 3D 効果の適用および効果間の相互作用は、特定のルールに基づきます。

テキストとそのテキストを含む形状についてシーンを考えます。3D 効果は 3D オブジェクトの表現と、オブジェクトが配置されるシーンを含みます。

- 図形とテキストの両方にシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。
- 図形に独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。
- それ以外の場合（形状に元々 3D 効果がない場合）、形状は平面のままで、3D 効果はテキストにのみ適用されます。

これらの説明は ThreeDFormat.getLightRig() および ThreeDFormat.getCamera() メソッドに関連しています。 
{{% /alert %}} 

## **テキストに外部シャドウ効果を適用する**

Aspose.Slides for PHP via Java は、[**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow) と [**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow) クラスを提供し、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) に含まれるテキストにシャドウ効果を適用できます。次の手順を実行してください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに Rectangle タイプの AutoShape を追加します。
4. AutoShape に関連付けられた TextFrame にアクセスします。
5. AutoShape の FillType を NoFill に設定します。
6. OuterShadow クラスのインスタンスを作成します。
7. シャドウの BlurRadius を設定します。
8. シャドウの Direction を設定します。
9. シャドウの Distance を設定します。
10. RectanglelAlign を TopLeft に設定します。
11. シャドウの PresetColor を Black に設定します。
12. プレゼンテーションを書き出して [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルに保存します。

上記手順の実装例であるこのサンプルコードは、テキストに外部シャドウ効果を適用する方法を示しています。
```php
  $pres = new Presentation();
  try {
    # スライドの参照を取得
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle タイプの AutoShape を追加
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Rectangle に TextFrame を追加
    $ashp->addTextFrame("Aspose TextBox");
    # テキストのシャドウを取得できるようにシェイプの塗りつぶしを無効化
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 外部シャドウを追加し、必要なすべてのパラメータを設定
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


## **図形に内部シャドウ効果を適用する**

次の手順を実行してください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. Rectangle タイプの AutoShape を追加します。
4. InnerShadowEffect を有効にします。
5. 必要なすべてのパラメータを設定します。
6. ColorType を Scheme に設定します。
7. Scheme Color を設定します。
8. プレゼンテーションを書き出して [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルに保存します。

上記手順に基づくこのサンプルコードは、2 つの図形間にコネクタを追加する方法を示しています。
```php
  $pres = new Presentation();
  try {
    # スライドの参照を取得
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Rectangle に TextFrame を追加
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
    # Scheme カラーを設定
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

**異なるフォントやスクリプト（例: アラビア語、中国語）でも WordArt 効果を使用できますか？**

はい、Aspose.Slides は Unicode をサポートしており、主要なフォントやスクリプトすべてで動作します。シャドウ、塗りつぶし、輪郭などの WordArt 効果は言語に関係なく適用できますが、フォントの可用性やレンダリングはシステムフォントに依存する場合があります。

**スライドマスター要素にも WordArt 効果を適用できますか？**

はい、タイトルプレースホルダー、フッター、背景テキストなど、マスタースライド上の図形にも WordArt 効果を適用できます。マスター レイアウトに加えた変更は、関連付けられたすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**

多少は影響します。シャドウ、グロウ、グラデーション塗りつぶしなどの WordArt 効果は、追加の書式メタデータによりファイルサイズをわずかに増加させることがありますが、差は通常はごくわずかです。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい、[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) または [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) インターフェイスの `getImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ上または画面上で結果をプレビューできます。