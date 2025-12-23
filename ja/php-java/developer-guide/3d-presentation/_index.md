---
title: PHPで3Dプレゼンテーションを作成
linktitle: 3Dプレゼンテーション
type: docs
weight: 232
url: /ja/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3Dプレゼンテーション
- 3D回転
- 3D奥行き
- 3D押し出し
- 3Dグラデーション
- 3Dテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でインタラクティブな 3D プレゼンテーションを簡単に作成できます。PowerPoint および OpenDocument 形式へ迅速にエクスポートし、さまざまな用途に活用できます。"
---

## **概要**
Aspose.Slides Java 20.9 以降、プレゼンテーションで 3D を作成できるようになりました。PowerPoint 3D は、プレゼンテーションに命を吹き込む手段です。3D プレゼンテーションで実世界のオブジェクトを表示したり、将来のビジネスプロジェクトの 3D モデル、建物やその内部の 3D モデル、ゲームキャラクターの 3D モデル、あるいはデータの 3D 表現を示したりできます。

PowerPoint の 3D モデルは、2D シェイプから作成でき、次のような効果を適用します：3D 回転、3D 奥行きと押し出し、3D グラデーション、3D テキストなど。シェイプに適用できる 3D 機能の一覧は **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** クラスにあります。このクラスのインスタンスは次の方法で取得できます。

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)** メソッドで PowerPoint 3D モデルを作成します。
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** メソッドで 3D テキスト（WordArt）を作成します。

**[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** で実装されているすべての効果は、シェイプとテキストの両方で使用できます。次に **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** クラスの主なメソッドを簡単に見てみましょう。次の例では、テキストを含む矩形の 2D シェイプを作成します。シェイプにカメラビューを取得し、回転させて 3D モデルのように見せます。平坦な光とその方向を 3D モデルの上部に設定し、モデルにボリュームを付加します。素材、押し出し高さ、色を変更すると、3D モデルがより生き生きとします。
``` php 
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("sandbox_3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


以下は結果の 3D モデルです：

![todo:image_alt_text](img_01_01.png)

## **3D 回転**
PowerPoint で 3D モデルを回転させるには、メニューを使用します：

![todo:image_alt_text](img_02_01.png)

Aspose.Slides API で 3D モデルを回転させるには、**[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)** メソッドを使用し、カメラの回転を 3D シェイプに対して設定します：
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... 他の3Dシーンパラメータを設定

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


## **3D 奥行きと押し出し**
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** と **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** メソッドは、シェイプに押し出しを作成するために使用します：
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
# ... 他の 3D シーン パラメータを設定

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


PowerPoint では、シェイプの奥行きは次のように設定します：

![todo:image_alt_text](img_02_02.png)

## **3D グラデーション**
3D グラデーションは PowerPoint の 3D シェイプにボリューム感を付与します：
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getFillFormat()->setFillType(FillType::Gradient);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 255, 140, 0));

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->dispose();
```


実際の見え方は次の通りです：

![todo:image_alt_text](img_02_03.png)
  
画像グラデーションも作成できます：
``` php
$shape->getFillFormat()->setFillType(FillType::Picture);

$image = Images->fromFile("image.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
# ... 3D を設定: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* プロパティ

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


結果は以下の通りです：

![todo:image_alt_text](img_02_04.png)

## **3D テキスト（WordArt）**
3D テキスト（WordArt）を作成するには、以下の手順を実行します：
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getFillFormat()->setFillType(FillType::NoFill);
$shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
$shape->getTextFrame()->setText("3D Text");

$portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
$portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new java("java.awt.Color", 255, 140, 0));
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);
$textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
# "Arch Up" WordArt の変形効果を設定
$textFrameFormat->setTransform(TextShapeType::ArchUp);

$textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
$textFrameFormat->getThreeDFormat()->setDepth(3);
$textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
$textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
$textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
$textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("text3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("text3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


結果は次のとおりです：

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**プレゼンテーションを画像/PDF/HTML にエクスポートする際に、3D 効果は保持されますか？**

はい。Slides の 3D エンジンは、サポートされている形式（[画像](/slides/ja/php-java/convert-powerpoint-to-png/)、[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/php-java/convert-powerpoint-to-html/) など）へのエクスポート時に 3D 効果をレンダリングします。

**テーマや継承などを考慮した「実際の」3D パラメータ値（最終値）を取得できますか？**

はい。Slides は [実際の値を読み取る](/slides/ja/php-java/shape-effective-properties/) API を提供しており、3D の照明やベベルなども含めて最終的に適用された設定を確認できます。

**プレゼンテーションを動画に変換する際に、3D 効果は機能しますか？**

はい。動画用フレームを生成する際（[動画への変換](/slides/ja/php-java/convert-powerpoint-to-video/)）も、3D 効果はエクスポートされた画像と同様にレンダリングされます。