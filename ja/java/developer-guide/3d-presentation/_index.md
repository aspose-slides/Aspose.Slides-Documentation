---
title: 3Dプレゼンテーション
type: docs
weight: 232
url: /java/3d-presentation/
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
- Java
- Aspose.Slides for Java
description: "Javaでの3D PowerPointプレゼンテーション"
---

## 概要
Aspose.Slides Java 20.9以降、プレゼンテーションで3Dを作成することが可能になりました。PowerPoint 3Dは、プレゼンテーションに命を吹き込む方法です。3Dプレゼンテーションを使用して、実世界のオブジェクトを表示したり、将来のビジネスプロジェクトの3Dモデル、建物の3Dモデルやその内装、ゲームキャラクターの3Dモデル、またはデータの3D表現をデモしたりします。

PowerPointの3Dモデルは、2Dシェイプから作成することができ、次のような効果を適用できます：3D回転、3D深さと押し出し、3Dグラデーション、3Dテキストなど。シェイプに適用される3D機能のリストは、**[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**クラスにあります。このクラスのインスタンスは次の方法で取得できます：

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/Shape#getThreeDFormat--)** メソッドを使用してPowerPoint 3Dモデルを作成します。
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** メソッドを使用して3Dテキスト（WordArt）を作成します。

**[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**に実装されているすべての効果は、シェイプとテキストの両方に使用できます。ここでは、**[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)**クラスの主なメソッドを簡単に見ていきましょう。次の例では、テキストのある矩形2Dシェイプを作成します。シェイプのカメラビューを取得し、回転を変更して3Dモデルのように見せます。平面光源を設定し、その方向を3Dモデルの上に向けることで、モデルにより多くのボリュームを与えます。変更されたマテリアル、押し出し高さ、色により3Dモデルはより生き生きと見えます。
```java
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

ここが結果の3Dモデルです：

![todo:image_alt_text](img_01_01.png)

## 3D回転
PowerPointでの3Dモデルの回転は、メニューを介して行えます：

![todo:image_alt_text](img_02_01.png)

Aspose.Slides APIを使用して3Dモデルを回転するには、**[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getCamera--)** メソッドを使用し、3Dシェイプに対するカメラの回転を設定します：

```java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... 他の3Dシーンパラメータを設定

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

## 3D深さと押し出し
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** および **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** メソッドは、シェイプに押し出しを作成するために使用されます：

```java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... 他の3Dシーンパラメータを設定

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

PowerPointでは、シェイプの深さは次のように設定されます：

![todo:image_alt_text](img_02_02.png)

## 3Dグラデーション
3Dグラデーションは、PowerPointの3Dシェイプにより多くのボリュームを与えることができます：

```java
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

こちらがその見た目です：

![todo:image_alt_text](img_02_03.png)

画像グラデーションも作成できます：
```java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... 3D設定: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* プロパティ

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```

こちらが結果です：

![todo:image_alt_text](img_02_04.png)

## 3Dテキスト（WordArt）
3Dテキスト（WordArt）を作成するには、次の操作を行います：
```java
final float imageScale = 2;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getFillFormat().setFillType(FillType.NoFill);
shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
shape.getTextFrame().setText("3D Text");

Portion portion = (Portion)shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
// "Arch Up" WordArt変形効果を設定
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

こちらが結果です：

![todo:image_alt_text](img_02_05.png)

## 対応していない - 近日公開
次のPowerPoint 3D機能はまだサポートされていません：
- ベベル
- マテリアル
- 輪郭
- 照明