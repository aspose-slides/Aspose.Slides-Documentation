---
title: ワードアート
type: docs
weight: 110
url: /php-java/wordart/
---


## **ワードアートについて？**
ワードアートは、テキストに効果を適用して目立たせる機能です。例えば、ワードアートを使用すると、テキストをアウトライン化したり、色（またはグラデーション）で塗りつぶしたり、3D効果を追加したりすることができます。また、テキストの形を傾けたり、曲げたり、引き延ばしたりすることもできます。

{{% alert color="primary" %}} 

ワードアートを使用することで、テキストをグラフィックオブジェクトのように扱うことができます。一般的に、ワードアートは、テキストをより魅力的または目立たせるために施された効果や特別な修正で構成されています。

{{% /alert %}} 

**Microsoft PowerPointにおけるワードアート**

Microsoft PowerPointでワードアートを使用するには、あらかじめ定義されたワードアートテンプレートのいずれかを選択する必要があります。ワードアートテンプレートは、テキストまたはその形状に適用される効果のセットです。

**Aspose.Slidesにおけるワードアート**

Aspose.Slides for PHP via Java 20.10では、ワードアートのサポートを実装し、その後のAspose.Slides for PHP via Javaリリースで機能の改善を行いました。

Aspose.Slides for PHP via Javaを使用すると、自分自身のワードアートテンプレート（1つの効果または効果の組み合わせ）を簡単に作成し、テキストに適用できます。

## シンプルなワードアートテンプレートを作成し、テキストに適用する

**Aspose.Slidesを使用して** 

まず、次のPHPコードを使用してシンプルなテキストを作成します：

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
次に、効果をより目立たせるために、テキストのフォントの高さを大きな値に設定します：

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);
```

**Microsoft PowerPointを使用して**

Microsoft PowerPointでワードアート効果メニューに移動します：

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから、あらかじめ定義されたワードアート効果を選択できます。左側のメニューから、新しいワードアートの設定を指定できます。 

これらは利用可能なパラメータやオプションの一部です：

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slidesを使用して**

次に、以下のコードを使用してテキストに[SmallGrid](https://reference.aspose.com/slides/php-java/aspose.slides/PatternStyle#SmallGrid)パターンカラーを適用し、幅1の黒いテキストの境界線を追加します：

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
```

結果のテキスト：

![todo:image_alt_text](image-20200930114108-4.png)

## 他のワードアート効果の適用

**Microsoft PowerPointを使用して**

プログラムのインターフェースから、テキスト、テキストブロック、形状、または同様の要素にこれらの効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

例えば、影、反射、グロー効果はテキストに適用できます。3Dフォーマットと3D回転効果はテキストブロックに適用でき、ソフトエッジプロパティは形状オブジェクトに適用できます（3Dフォーマットプロパティが設定されていない場合でも影響を与えます）。

### 影効果の適用

ここでは、テキストに関連するプロパティのみを設定します。このコードを使用してテキストに影効果を適用します：

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

Aspose.Slides APIは3種類の影をサポートしています：OuterShadow, InnerShadow, およびPresetShadow。

PresetShadowを使用すると、テキストに影を適用できます（プリセット値を使用）。

**Microsoft PowerPointを使用して**

PowerPointでは、1種類の影を使用できます。以下はその例です：

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slidesを使用して**

Aspose.Slidesでは、実際に2種類の影を同時に適用できます：InnerShadowとPresetShadow。

**注意事項：**

- OuterShadowとPresetShadowが一緒に使用されると、OuterShadow効果のみが適用されます。 
- OuterShadowとInnerShadowが同時に使用されると、結果の効果はPowerPointのバージョンによって異なります。例えば、PowerPoint 2013では効果が二重になりますが、PowerPoint 2007ではOuterShadow効果が適用されます。 

### テキストへの表示効果の適用

次のコードサンプルを通じて、テキストに表示を追加します：

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

### テキストへのグロー効果の適用

次のコードを使用して、テキストにグロー効果を適用し、光るようにさせます：

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

操作の結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

影、表示、およびグローのパラメータを変更できます。効果のプロパティは、テキストの各部分に別々に設定されます。

{{% /alert %}} 

### ワードアートにおける変形の使用

次のコードを通じて、テキスト全体のブロックに固有のTransformプロパティを使用します：
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

結果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPointとAspose.Slides for PHP via Javaは、あらかじめ定義された変形タイプを一定数提供します。

{{% /alert %}} 

**PowerPointを使用して**

あらかじめ定義された変形タイプにアクセスするには、**フォーマット** -> **テキスト効果** -> **変形**に進みます。

**Aspose.Slidesを使用して**

変形タイプを選択するには、TextShapeType列挙体を使用します。

### テキストと形状への3D効果の適用

次のサンプルコードを使用して、テキスト形状に3D効果を設定します：

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

結果のテキストとその形状：

![todo:image_alt_text](image-20200930114816-9.png)

次のPHPコードを使用して、テキストに3D効果を適用します：

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

操作の結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

テキストまたはその形状への3D効果の適用および効果間の相互作用は、特定のルールに基づいています。

テキストとそのテキストを含む形状のシーンを考慮してください。3D効果には、3Dオブジェクトの表現とオブジェクトが置かれたシーンが含まれます。

- 両方の図形とテキストにシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。
- 図形に独自のシーンがないが3D表現がある場合、テキストのシーンが使用されます。
- それ以外の場合（形状が元々3D効果を持たない場合）、形状は平坦であり、3D効果はテキストにのみ適用されます。

これらの説明は、ThreeDFormat.getLightRig()およびThreeDFormat.getCamera()メソッドに関連しています。

{{% /alert %}} 

## **テキストへのアウトシャドウ効果の適用**
Aspose.Slides for PHP via Javaは、[**IOuterShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IOuterShadow)および[**IInnerShadow**](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IInnerShadow)クラスを提供しており、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame)で扱われるテキストに影効果を適用できます。以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに長方形タイプのオートシェイプを追加します。
4. オートシェイプに関連するTextFrameにアクセスします。
5. オートシェイプのFillTypeをNoFillに設定します。
6. OuterShadowクラスをインスタンス化します。
7. 影のBlurRadiusを設定します。
8. 影のDirectionを設定します。
9. 影のDistanceを設定します。
10. RectanglelAlignをTopLeftに設定します。
11. 影のPresetColorをBlackに設定します。
12. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして保存します。

次のサンプルコードは、上記の手順の実装であり、テキストにアウトシャドウ効果を適用する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # Get reference of the slide
    $sld = $pres->getSlides()->get_Item(0);
    # Add an AutoShape of Rectangle type
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Add TextFrame to the Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    # Disable shape fill in case we want to get shadow of text
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Add outer shadow and set all necessary parameters
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Write the presentation to disk
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **シェイプへのインナーシャドウ効果の適用**
以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 長方形タイプのオートシェイプを追加します。
4. InnerShadowEffectを有効にします。
5. 必要なすべてのパラメータを設定します。
6. ColorTypeをSchemeとして設定します。
7. Scheme Colorを設定します。
8. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして保存します。

次のサンプルコード（上記の手順に基づく）は、2つのシェイプの間に接続を追加する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # Get reference of the slide
    $slide = $pres->getSlides()->get_Item(0);
    # Add an AutoShape of Rectangle type
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Add TextFrame to the Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Enable InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Set all necessary parameters
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Set ColorType as Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Set Scheme Color
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Save Presentation
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```