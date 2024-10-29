---
title: 3Dプレゼンテーション
type: docs
weight: 232
url: /ja/androidjava/3d-presentation/
keywords:
- 3D
- 3D PowerPoint
- 3Dプレゼンテーション
- 3D回転
- 3D深さ
- 3D押し出し
- 3Dグラデーション
- 3Dテキスト
- PowerPointプレゼンテーション
- Android
- Aspose.Slides for Android via Java
description: "Androidの3D PowerPointプレゼンテーション"
---

## 概要
Aspose.Slides Java 20.9以降、プレゼンテーションで3Dを作成することが可能です。PowerPoint 3Dは、プレゼンテーションに命を吹き込む方法です。3Dプレゼンテーションで実際の世界のオブジェクトを表示し、未来のビジネスプロジェクトの3Dモデルや建物またはその内装の3Dモデル、ゲームキャラクターの3Dモデル、またはデータの3D表現を示します。

PowerPointの3Dモデルは、2D形状から次のような効果を適用することによって作成できます：3D回転、3D深さおよび押し出し、3Dグラデーション、3Dテキストなど。形状に適用される3D機能のリストは**[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**クラスで見つけることができます。このクラスのインスタンスは次のように取得できます：

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)**メソッドを使用してPowerPoint 3Dモデルを作成します。
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)**メソッドを使用して3Dテキスト（WordArt）を作成します。

**[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**に実装されたすべての効果は、形状とテキストの両方に使用できます。ここで**[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)**クラスの主なメソッドを簡単に見てみましょう。次の例では、テキストを持つ長方形の2D形状を作成します。形状にカメラビューを取得し、その回転を変更して3Dモデルのように見えるようにします。3Dモデルの上部にフラットライトとその方向を設定することで、モデルにより多くのボリュームが加わります。変更された材料、押し出しの高さと色は、3Dモデルをより生き生きと見せます。  
``` java 
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("sandbox_3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```

ここに結果として得られた3Dモデルがあります：

![todo:image_alt_text](img_01_01.png)

## 3D回転
PowerPointの3Dモデルの回転はメニューを介して行うことができます：

![todo:image_alt_text](img_02_01.png)

Aspose.Slides APIを使用して3Dモデルを回転させるには、**[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)**メソッドを使用し、3D形状に対するカメラの回転を設定します：

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... その他の3Dシーンパラメータを設定

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

## 3D深さと押し出し
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)**および**[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)**メソッドは、形状に押し出しを作成するために使用されます：

``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... その他の3Dシーンパラメータを設定

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

PowerPointでは、形状の深さは次のように設定されます：

![todo:image_alt_text](img_02_02.png)

## 3Dグラデーション
3Dグラデーションは、PowerPointの3D形状により多くのボリュームを与えることができます：

``` java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.getTextFrame().setText("3D");
shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

shape.getFillFormat().setFillType(FillType.Gradient);
shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.dispose();
```

それがどのように見えるか：

![todo:image_alt_text](img_02_03.png)
  
画像グラデーションを作成することもできます：
``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... 3Dの設定: shape.ThreeDFormat.Camera、shape.ThreeDFormat.LightRig、shape.ThreeDFormat.Extrusion*プロパティを設定

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

ここが結果です：

![todo:image_alt_text](img_02_04.png)

## 3Dテキスト（WordArt）
3Dテキスト（WordArt）を作成するには、以下の手順を実行します：
``` java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getFillFormat().setFillType(FillType.NoFill);
shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
shape.getTextFrame().setText("3Dテキスト");

Portion portion = (Portion)shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
// "アーチ上" WordArt変換効果を設定します
textFrameFormat.setTransform(TextShapeType.ArchUp);

textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
textFrameFormat.getThreeDFormat().setDepth(3);
textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("text3d.png", ImageFormat.Png);
thumbnail.dispose();

presentation.save("text3d.pptx", SaveFormat.Pptx);
presentation.dispose();
```

ここがその結果です：

![todo:image_alt_text](img_02_05.png)

## サポートされていない - 近日公開
以下のPowerPoint 3D機能はまだサポートされていません：
- ベベル
- マテリアル
- 輪郭
- ライティング