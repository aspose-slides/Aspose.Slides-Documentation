---
title: Androidで3Dプレゼンテーションを作成する
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D プレゼンテーション
- 3D 回転
- 3D 奥行き
- 3D 押し出し
- 3D グラデーション
- 3D テキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java でインタラクティブな 3D プレゼンテーションを簡単に作成できます。PowerPoint および OpenDocument フォーマットへ迅速にエクスポートでき、さまざまな用途に活用できます。"
---

## **概要**
Aspose.Slides Java 20.9 以降、プレゼンテーションで 3D を作成できるようになりました。PowerPoint 3D はプレゼンテーションに命を吹き込む方法です。3D プレゼンテーションで実世界のオブジェクトを表示したり、将来のビジネスプロジェクトの 3D モデル、建物やその内部の 3D モデル、ゲームキャラクターの 3D モデル、あるいはデータの 3D 表現を行ったりできます。

PowerPoint の 3D モデルは 2D シェイプから作成でき、次のようなエフェクトを適用します：3D 回転、3D 奥行きと押し出し、3D グラデーション、3D テキストなど。シェイプに適用できる 3D 機能の一覧は **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)** クラスにあります。このクラスのインスタンスは次の方法で取得できます：

- **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape#getThreeDFormat--)** PowerPoint 3D モデルを作成するメソッド。
- **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getThreeDFormat--)** 3D テキスト (WordArt) を作成するメソッド。

**[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)** に実装されているすべてのエフェクトはシェイプとテキストの両方で使用できます。次に **[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)** クラスの主要メソッドを簡単に見てみましょう。以下の例では、テキスト付きの矩形 2D シェイプを作成します。シェイプにカメラビューを取得し、回転を変更して 3D モデルのように見せます。フラットライトとその方向を 3D モデルの上部に設定し、ボリューム感を高めます。素材、押し出し高さ、色を変更することで、3D モデルがよりリアルに見えます。
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


以下は生成された 3D モデルです:
![todo:image_alt_text](img_01_01.png)

## **3D 回転**
PowerPoint での 3D モデルの回転はメニューから行えます:
![todo:image_alt_text](img_02_01.png)

Aspose.Slides API で 3D モデルを回転させるには、**[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getCamera--)** メソッドを使用し、カメラの回転を 3D シェイプに対して設定します:
``` java
IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
// ... 他の 3D シーン パラメータを設定

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


## **3D 奥行きと押し出し**
**[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionHeight--)** と **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getExtrusionColor--)** メソッドはシェイプに押し出しを作成するために使用されます:
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


PowerPoint では、シェイプの奥行きは次の操作で設定します:
![todo:image_alt_text](img_02_02.png)

## **3D グラデーション**
3D グラデーションは PowerPoint の 3D シェイプにボリューム感を付加できます:
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


以下のようになります:
![todo:image_alt_text](img_02_03.png)
  
画像グラデーションを作成することもできます:
``` java
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
// ... 3D を設定: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* プロパティ

IImage thumbnail = slide.getImage(imageScale, imageScale);
thumbnail.save("sample_3d.png", ImageFormat.Png);
thumbnail.dispose();
```


結果は以下の通りです:
![todo:image_alt_text](img_02_04.png)

## **3D テキスト (WordArt)**
3D テキスト (WordArt) を作成するには、以下の手順を実行します:
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
// "Arch Up" WordArt 変換効果を設定
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


結果は以下の通りです:
![todo:image_alt_text](img_02_05.png)

## **よくある質問**

**プレゼンテーションを画像/PDF/HTML にエクスポートする際に 3D エフェクトは保持されますか？**

はい。Slides の 3D エンジンは、対応フォーマットへエクスポートする際に 3D エフェクトをレンダリングします（[images](/slides/ja/androidjava/convert-powerpoint-to-png/)、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/) など）。

**テーマや継承などを考慮した「有効な」(最終的な) 3D パラメータ値を取得できますか？**

はい。Slides は [read effective values](/slides/ja/androidjava/shape-effective-properties/) の API を提供しており（3D の照明やベベルなどを含む）、最終的に適用された設定を確認できます。

**プレゼンテーションをビデオに変換する際に 3D エフェクトは機能しますか？**

はい。ビデオ用のフレームを [generating frames for the video](/slides/ja/androidjava/convert-powerpoint-to-video/) で生成する際、3D エフェクトは [exported images](/slides/ja/androidjava/convert-powerpoint-to-png/) と同様にレンダリングされます。