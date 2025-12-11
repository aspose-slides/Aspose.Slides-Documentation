---
title: Androidで3Dプレゼンテーションを作成
linktitle: 3Dプレゼンテーション
type: docs
weight: 232
url: /ja/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java でインタラクティブな 3D プレゼンテーションを簡単に作成します。PowerPoint および OpenDocument 形式へ高速にエクスポートでき、さまざまな用途に活用できます。"
---

## **概要**
Aspose.Slides Java 20.9 以降、プレゼンテーションで 3D を作成できるようになりました。PowerPoint の 3D はプレゼンテーションに命を吹き込む方法です。実際のオブジェクトを 3D プレゼンテーションで表示したり、将来のビジネスプロジェクトの 3D モデル、建物や内部の 3D モデル、ゲームキャラクターの 3D モデル、またはデータの 3D 表現を示すことができます。

PowerPoint の 3D モデルは 2D シェイプから作成でき、以下のようなエフェクトを適用します：3D 回転、3D 奥行きと押し出し、3D グラデーション、3D テキストなど。シェイプに適用される 3D 機能の一覧は **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)** クラスで確認できます。クラスのインスタンスは次の方法で取得できます：

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)** メソッドは PowerPoint 3D モデルを作成します。
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** メソッドは 3D テキスト（WordArt）を作成します。

**[ThreeDFormat]** に実装されているすべてのエフェクトはシェイプとテキストの両方で使用できます。**[ThreeDFormat]** クラスの主なメソッドを簡単に見てみましょう。次の例では、テキスト付きの長方形 2D シェイプを作成します。シェイプに対してカメラビューを取得し、回転を変更して 3D モデルのように見せます。フラットライトとその方向を 3D モデルの上部に設定することで、モデルにボリュームが加わります。マテリアル、押し出し高さ、色を変更すると、3D モデルがより生き生きとします。
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


以下は結果として得られる 3D モデルです：

![todo:image_alt_text](img_01_01.png)

## **3D回転**
PowerPoint で 3D モデルの回転はメニューから行えます：

![todo:image_alt_text](img_02_01.png)

Aspose.Slides API で 3D モデルを回転させるには、**[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)** メソッドを使用し、カメラの回転を 3D シェイプに対して設定します。
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... 他の 3D シーン パラメータを設定

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


## **3D深度と押し出し**
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** と **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** メソッドはシェイプに押し出しを作成するために使用します：
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
// ... 他の 3D シーン パラメータを設定

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


PowerPoint ではシェイプの深度は以下の方法で設定します：

![todo:image_alt_text](img_02_02.png)

## **3Dグラデーション**
3D グラデーションは PowerPoint の 3D シェイプにボリュームを付加できます：

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


イメージは次のようになります：

![todo:image_alt_text](img_02_03.png)
  
画像グラデーションも作成できます：

``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... setup 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* properties

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


結果は以下の通りです：

![todo:image_alt_text](img_02_04.png)

## **3Dテキスト（WordArt）**
3D テキスト（WordArt）を作成するには、次の手順を実行します：

``` java
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
// set the "Arch Up" WordArt transform effect
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


結果は以下の通りです：

![todo:image_alt_text](img_02_05.png)

## **よくある質問**

**プレゼンテーションを画像/PDF/HTML にエクスポートするとき、3D エフェクトは保持されますか？**

はい。Slides の 3D エンジンは、サポートされている形式（[images](/slides/ja/androidjava/convert-powerpoint-to-png/)、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/) など）にエクスポートする際に 3D エフェクトをレンダリングします。

**テーマや継承などを考慮した「実効」(最終) の 3D パラメータ値を取得できますか？**

はい。Slides は、[read effective values](/slides/ja/androidjava/shape-effective-properties/)（3D の照明、ベベルなどを含む）を取得できる API を提供しており、最終的に適用された設定を確認できます。

**プレゼンテーションをビデオに変換する際に 3D エフェクトは機能しますか？**

はい。[generating frames for the video](/slides/ja/androidjava/convert-powerpoint-to-video/) の際、3D エフェクトは [exported images](/slides/ja/androidjava/convert-powerpoint-to-png/) と同様にレンダリングされます。